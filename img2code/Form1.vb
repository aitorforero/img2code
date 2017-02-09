Public Class Form1
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFile()
    End Sub

    Private Sub OpenFile()
        Dim dlg As New OpenFileDialog
        If dlg.ShowDialog = DialogResult.OK Then
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
            Dim BitArray As New Text.StringBuilder

            Dim Palette As New Dictionary(Of Color, Integer)
            For y = 0 To image.Height - 1
                For x = 0 To image.Width - 1
                    Dim PixelColor = image.GetPixel(x, y)
                    If Not Palette.ContainsKey(PixelColor) Then
                        Palette.Add(PixelColor, 1)
                    Else
                        Palette(PixelColor) += 1
                    End If
                    'BitArray.Append("1".PadLeft(Palette.IndexOf(PixelColor) + 1, "0"))
                Next
            Next
            ' BitArray.Append(New String("0"c, 8 - (BitArray.Length Mod 8)))

            Dim OrderedPalette = Palette.OrderByDescending(Function(ColorCount) ColorCount.Value).Select(Function(ColorCount) ColorCount.Key).ToList
            For y = 0 To image.Height - 1
                For x = 0 To image.Width - 1
                    Dim PixelColor = image.GetPixel(x, y)
                    BitArray.Append("1".PadLeft(OrderedPalette.IndexOf(PixelColor) + 1, "0"))
                Next
            Next
            BitArray.Append(New String("0"c, 8 - (BitArray.Length Mod 8)))


            Dim BitArrayString = BitArray.ToString
            Dim code As New Text.StringBuilder
            Dim ByteArray As New List(Of Byte)
            For i = 0 To BitArray.Length - 1 Step 8
                Dim CurrentByte As Byte = Convert.ToByte(BitArrayString.Substring(i, 8), 2)
                ByteArray.Add(CurrentByte)
                code.Append(Hex(CurrentByte) + ";")
            Next

            Dim SafeFileName As String = IO.Path.GetFileNameWithoutExtension(dlg.FileName)

            code.AppendLine()
            code.AppendLine("/*")
            code.AppendLine(String.Format("Image Bytes = {0}", image.Height * image.Width * 4))
            code.AppendLine(String.Format("BitArray Bytes = {0}", ByteArray.Count))
            code.AppendLine(String.Format("Pallete length = {0}", Palette.Count))
            code.AppendLine("*/")
            code.AppendLine()
            code.AppendFormat("// {0} ************************************************************", IO.Path.GetFileName(dlg.FileName)) : code.AppendLine()
            code.AppendFormat("Const uint8_t PROGMEM {0}_palette[][4] = {{", SafeFileName) : code.AppendLine()
            code.AppendLine(String.Join("," + vbCrLf, OrderedPalette.Select(Function(c) String.Format(vbTab + "{{{0,4},{1,4},{2,4},{3,4}}}", c.A, c.R, c.G, c.B))))
            code.AppendLine("}")
            code.AppendFormat("Const uint8_t PROGMEM {0}_image[] = {{", SafeFileName) : code.AppendLine()
            Dim Pos As Integer = 0
            While Pos < ByteArray.Count
                Dim Max As Integer = 32
                If (ByteArray.Count - Pos - 1) < Max Then
                    Max = ByteArray.Count - Pos - 1
                End If

                String.Join("," + ByteArray.Skip(Pos).Take(Max).Select(Function(B) B.ToString))
            End While
            For i = 0 To BitArray.Length - 1 Step 8
                Dim CurrentByte As Byte = Convert.ToByte(BitArrayString.Substring(i, 8), 2)
                ByteArray.Add(CurrentByte)
                code.Append(Hex(CurrentByte) + ";")
            Next
            code.AppendLine(String.Join("," + vbCrLf, OrderedPalette.Select(Function(c) String.Format(vbTab + "{{{0,4},{1,4},{2,4},{3,4}}}", c.A, c.R, c.G, c.B))))
            code.AppendLine("}")


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