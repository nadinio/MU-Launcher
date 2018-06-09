Imports System.IO

Public Class PatchListBuilder
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If (FolderExplorer.ShowDialog() = DialogResult.OK) Then
            txtDirectory.Text = FolderExplorer.SelectedPath
        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim files As String() = Directory.GetFiles(txtDirectory.Text, "*", SearchOption.AllDirectories)

        If System.IO.File.Exists(txtDirectory.Text & "filelist.txt") = True Then
            System.IO.File.Delete(txtDirectory.Text & "filelist.txt")
            System.IO.File.Create(txtDirectory.Text & "filelist.txt").Close()
        Else
            System.IO.File.Create(txtDirectory.Text & "filelist.txt").Close()
        End If

        Dim textWriter As New System.IO.StreamWriter(txtDirectory.Text & "filelist.txt")
        textWriter.WriteLine("[File List]")

        For i As Integer = 0 To files.Length - 1
            files(i) = files(i).Replace(txtDirectory.Text, "")
            textWriter.WriteLine(files(i))
        Next

        textWriter.Close()
        lblResult.Text = "File list generated successfully!"

    End Sub
End Class
