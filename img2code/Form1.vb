Public Class Form1
    Const BITS = 16

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFile()
    End Sub

    Private Sub OpenFile()
        Dim dlg As New OpenFileDialog
        If dlg.ShowDialog = DialogResult.OK Then
            Dim code As New Text.StringBuilder

            Dim imageInMemory As New IO.MemoryStream
            Dim ReadingStream = IO.File.OpenRead(dlg.FileName)
            Dim Buffer(2047) As Byte
            Dim ReadBytes = 2047
            While ReadBytes > 0
                ReadBytes = ReadingStream.Read(Buffer, 0, Buffer.Length)
                imageInMemory.Write(Buffer, 0, ReadBytes)
            End While

            ReadingStream.Close()
            imageInMemory.Position = 0

            Dim image As Bitmap = Bitmap.FromStream(imageInMemory)
            SourcePictureBox.Image = image
            Dim ImageBitArray As New List(Of Byte)

            Dim Palette As New Dictionary(Of Color, Integer)
            For y = 0 To image.Height - 1
                For x = 0 To image.Width - 1
                    Dim PixelColor = image.GetPixel(x, y)
                    If Not Palette.ContainsKey(PixelColor) Then
                        Palette.Add(PixelColor, 1)
                    Else
                        Palette(PixelColor) += 1
                    End If
                Next
            Next

            Dim OrderedPalette = Palette.OrderByDescending(Function(ColorCount) ColorCount.Value).Select(Function(ColorCount) ColorCount.Key).ToList

            Dim BitsPerPixel As Integer = (OrderedPalette.Count - 1) \ 2 + 1

            For y = 0 To image.Height - 1
                For x = 0 To image.Width - 1
                    Dim PixelColor = image.GetPixel(x, y)
                    Convert.ToString(OrderedPalette.IndexOf(PixelColor), 2).PadLeft(BitsPerPixel, "0").ToList.ForEach(
                        Sub(b) ImageBitArray.Add(Byte.Parse(b)))
                Next
            Next

            If ImageBitArray.Count Mod BITS > 0 Then
                For i = (BITS - ImageBitArray.Count Mod BITS) To 1 Step -1
                    ImageBitArray.Add(0)
                Next
            End If

            Dim ImageByteArray As New List(Of String)
            For i = 0 To ImageBitArray.Count - 1 Step BITS
                ImageByteArray.Add("0x" + Hex(Convert.ToUInt32(String.Concat(ImageBitArray.Skip(i).Take(BITS).Select(Function(b) b.ToString)), 2)).PadLeft((BITS \ 8) * 2, "0"))
            Next





            Dim SafeFileName As String = ImageNameTextBox.Text

            code.AppendLine("#ifndef _" + SafeFileName + "Image_h")
            code.AppendLine("#define _" + SafeFileName + "Image_h")
            code.AppendLine()
            code.AppendLine("/********************************************************")
            code.AppendFormat(" * Source        : {0}", IO.Path.GetFileName(dlg.FileName)) : code.AppendLine()
            code.AppendFormat(" * Size          : {0}x{1}", image.Width, image.Height) : code.AppendLine()
            code.AppendFormat(" * Bits/Pixel    : {0}", BitsPerPixel) : code.AppendLine()
            code.AppendFormat(" * Palette colors: {0}", OrderedPalette.Count) : code.AppendLine()
            code.AppendFormat(" * Mem Size      : {0}Bytes", 6 + ImageByteArray.Count + OrderedPalette.Count * 4) : code.AppendLine()
            code.AppendLine(" ********************************************************/")
            code.AppendLine()

            code.AppendLine()
            code.AppendFormat("Const Image {0}Image  PROGMEM = {{", SafeFileName) : code.AppendLine()
            code.AppendFormat(vbTab + "{0}, {1}, {2}, {3}, ", image.Width, image.Height, OrderedPalette.Count, BitsPerPixel) : code.AppendLine()
            code.AppendLine(vbTab + "{ // *** Image Data ***")
            Dim ByteArray As New List(Of String)
            For i = 0 To ImageByteArray.Count - 1 Step 16
                ByteArray.Add(vbTab + vbTab + String.Join(", ", ImageByteArray.Skip(i).Take(16)))
            Next
            code.AppendLine(String.Join("," + vbCrLf, ByteArray))
            code.AppendLine(vbTab + "},")

            code.AppendLine(vbTab + "{ // *** Color Palette ***")
            code.AppendLine(String.Join("," + vbCrLf, OrderedPalette.Select(Function(c) String.Format(vbTab + vbTab + "{{{0,4},{1,4},{2,4},{3,4}}}", c.A, c.R, c.G, c.B))))
            code.AppendLine(vbTab + "}")


            code.AppendLine("}")

            code.AppendLine("#endif")


            CodeRichTextBox.Text = code.ToString
        End If

        dlg.Dispose()
    End Sub
End Class



'typedef struct {
'  uint8_t        type;    // PALETTE[1,4,8] Or TRUECOLOR
'  line_t         lines;   // Length Of image (In scanlines)
'  Const uint8_t *palette; // -> PROGMEM color table (NULL If truecolor)
'  Const uint8_t *pixels;  // -> Pixel data In PROGMEM
'} image;

'Const image PROGMEM images[] = {
'  { PALETTE1 ,  100, (const uint8_t *)palette00, pixels00 },
'  { PALETTE4 ,   48, (const uint8_t *)palette01, pixels01 },
'  { PALETTE4 ,   54, (const uint8_t *)palette02, pixels02 },
'  { PALETTE4 ,    1, (const uint8_t *)palette03, pixels03 },
'  { PALETTE4 ,   24, (const uint8_t *)palette04, pixels04 },
'  { PALETTE4 ,    9, (const uint8_t *)palette05, pixels05 },
'  { PALETTE4 ,   26, (const uint8_t *)palette06, pixels06 }
'};