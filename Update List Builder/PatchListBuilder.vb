Imports System.IO

Public Class PatchListBuilder
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If (FolderExplorer.ShowDialog() = DialogResult.OK) Then
            txtDirectory.Text = FolderExplorer.SelectedPath
        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim files As String()
        If System.IO.File.Exists(txtDirectory.Text & "\filelist.txt") = True Then
            System.IO.File.Delete(txtDirectory.Text & "\filelist.txt")
            files = Directory.GetFiles(txtDirectory.Text, "*", SearchOption.AllDirectories)
            System.IO.File.Create(txtDirectory.Text & "\filelist.txt").Close()
        Else
            files = Directory.GetFiles(txtDirectory.Text, "*", SearchOption.AllDirectories)
            System.IO.File.Create(txtDirectory.Text & "\filelist.txt").Close()
        End If

        Dim textWriter As New System.IO.StreamWriter(txtDirectory.Text & "\filelist.txt")

        For i As Integer = 0 To files.Length - 1
            files(i) = files(i).Replace(txtDirectory.Text & "\", "")
            textWriter.WriteLine(files(i) & ", " & GetCRC32(txtDirectory.Text & "\" & files(i)))
        Next


        textWriter.Close()
        lblResult.Text = "File list generated successfully!"

    End Sub

    'The author of this CRC32 code is Tim Hartwig.
    Public Function GetCRC32(ByVal sFileName As String) As String
        Try
            Dim FS As FileStream = New FileStream(sFileName, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
            Dim CRC32Result As Integer = &HFFFFFFFF
            Dim Buffer(4096) As Byte
            Dim ReadSize As Integer = 4096
            Dim Count As Integer = FS.Read(Buffer, 0, ReadSize)
            Dim CRC32Table(256) As Integer
            Dim DWPolynomial As Integer = &HEDB88320
            Dim DWCRC As Integer
            Dim i As Integer, j As Integer, n As Integer
            'Create CRC32 Table
            For i = 0 To 255
                DWCRC = i
                For j = 8 To 1 Step -1
                    If (DWCRC And 1) Then
                        DWCRC = ((DWCRC And &HFFFFFFFE) \ 2&) And &H7FFFFFFF
                        DWCRC = DWCRC Xor DWPolynomial
                    Else
                        DWCRC = ((DWCRC And &HFFFFFFFE) \ 2&) And &H7FFFFFFF
                    End If
                Next j
                CRC32Table(i) = DWCRC
            Next i
            'Calcualting CRC32 Hash
            Do While (Count > 0)
                For i = 0 To Count - 1
                    n = (CRC32Result And &HFF) Xor Buffer(i)
                    CRC32Result = ((CRC32Result And &HFFFFFF00) \ &H100) And &HFFFFFF
                    CRC32Result = CRC32Result Xor CRC32Table(n)
                Next i
                Count = FS.Read(Buffer, 0, ReadSize)
            Loop
            Return Hex(Not (CRC32Result))
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class
