Public Class Form1
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFile()
    End Sub

    Private Sub OpenFile()
        Dim dlg As New OpenFileDialog
        If dlg.ShowDialog = DialogResult.OK Then
            Dim image As Bitmap = Bitmap.FromFile(dlg.FileName)
            SourcePictureBox.Image = image
            Dim BitArray As New List(Of Boolean)
            Dim code As New Text.StringBuilder

            Dim Palette As New List(Of String)
            For y = 0 To image.Height - 1
                For x = 0 To image.Width - 1
                    Dim PixelColor = Hex(image.GetPixel(x, y).ToArgb).PadLeft(8, "0")
                    If Not Palette.Contains(PixelColor) Then
                        Palette.Add(PixelColor)
                    End If
                    Dim ZeroBit(Palette.IndexOf(PixelColor)) As Boolean
                    BitArray.AddRange(ZeroBit)
                    BitArray.Add(True)
                Next
            Next
            Dim size = BitArray.ToString.Length
            BitArray.ToString()

            code.AppendLine(BitArray.ToString)
            code.AppendLine(String.Format("Image Bytes = {0}", image.Height * image.Width * 4))
            code.AppendLine(String.Format("BitArray length = {0}b ; {1}B", size, size / 8))
            code.AppendLine(String.Format("Pallete length = {0}", Palette.Count))
            Palette.ForEach(Sub(c) code.AppendLine(c))

            CodeRichTextBox.Text = code.ToString
        End If

        dlg.Dispose()
    End Sub
End Class
