Imports System.Xml
Imports System.Threading
Imports System.Net
Imports System.IO

Public Class Muz0r

    Dim a, b As Integer
    Dim newPoint As New System.Drawing.Point()


    'Moves the window
    Private Sub ab_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        a = Control.MousePosition.X - Me.Location.X
        b = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub ab_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = MouseButtons.Left Then
            newPoint = Control.MousePosition
            newPoint.X = newPoint.X - a
            newPoint.Y = newPoint.Y - b
            Me.Location = newPoint
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Setting the transparent background
        Me.BackColor = Color.Empty
        TransparencyKey = Me.BackColor

        Dim reader As XmlReader

        'navigate webpage
        Try
            reader = XmlReader.Create("launch.xml")

            reader.ReadToFollowing("bannerURL")
            Dim bannerURL As String = reader.ReadElementContentAsString()

            webby.Navigate(bannerURL)
            Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
            Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        Catch ex As Exception
            Console.Write("File not found")
        End Try



    End Sub

    'setting up xbutton

    Private Sub xbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles xbtn.Click
        Me.Close()
    End Sub

    Private Sub xbtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles xbtn.MouseDown
        xbtn.Image = My.Resources.ixbutton
    End Sub

    Private Sub xbtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles xbtn.MouseUp
        xbtn.Image = My.Resources.xbutton
    End Sub
    Private Sub strtbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles strtbtn.Click
        Process.Start("Main.exe")
        Me.Close()
    End Sub

    Private Sub strtbtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles strtbtn.MouseDown
        strtbtn.Image = My.Resources.istart_btn
    End Sub

    Private Sub strtbtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles strtbtn.MouseUp
        strtbtn.Image = My.Resources.start_btn
    End Sub

    'setting up options button

    Private Sub optionbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optionbtn.Click
        Options.Show()
    End Sub

    Private Sub optionbtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles optionbtn.MouseDown
        optionbtn.Image = My.Resources.ioptionz
    End Sub

    Private Sub optionbtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles optionbtn.MouseUp
        optionbtn.Image = My.Resources.optionz
    End Sub

    ' Website button
    Private Sub webSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles webSite.Click

        Dim reader As XmlReader = XmlReader.Create("launch.xml")

        reader.ReadToFollowing("webURL")
        Dim webURL As String = reader.ReadElementContentAsString()

        System.Diagnostics.Process.Start(webURL)

        reader.Close()
    End Sub

    Private Sub webSite_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles webSite.MouseDown
        Me.webSite.Image = My.Resources.iwebsitebtn
    End Sub

    Private Sub webSite_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles webSite.MouseUp
        Me.webSite.Image = My.Resources.websitebtn
    End Sub

    'Forums button
    Private Sub forumsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles forumsBtn.Click
        Dim reader As XmlReader = XmlReader.Create("launch.xml")
 
        reader.ReadToFollowing("forumURL")
        Dim forumURL As String = reader.ReadElementContentAsString()

        System.Diagnostics.Process.Start(forumURL)

        reader.Close()
    End Sub

    Private Sub forumsBtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles forumsBtn.MouseDown
        Me.forumsBtn.Image = My.Resources.iforumsbtn
    End Sub

    Private Sub forumsBtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles forumsBtn.MouseUp
        Me.forumsBtn.Image = My.Resources.forumsbtn
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Dim clientReader As XmlReader


        Me.strtbtn.Visible = False

        Try
            clientReader = XmlReader.Create("launch.xml")

            'Read the XML files to determine the server version
            clientReader.ReadToFollowing("serverURL")
            Dim serverXMLpath As String = clientReader.ReadElementContentAsString() & "Updater/serverInfo.xml"
            Dim serverReader As XmlTextReader = New XmlTextReader(serverXMLpath)
            serverReader.ReadToFollowing("serverVer")
            Dim serverVer As Double = serverReader.ReadElementContentAsDouble()

            'Read client XML to determine clientVersion
            clientReader.ReadToFollowing("clientVer")
            Dim clientVer As Double = clientReader.ReadElementContentAsDouble()

            If clientVer < serverVer Then
                Me.lblUpdateCheck.Text = "Download updates, please wait..."
                updateThread = New Thread(AddressOf updateTask)
                updateThread.IsBackground = True
                updateThread.Start()
            Else
                Me.lblUpdateCheck.Text = "Press start to play!"
                Me.strtbtn.Visible = True
            End If

            clientReader.Close()
            serverReader.Close()
        Catch ex As Exception
            Me.lblUpdateCheck.Text = "Could not connect to server, check your connection!"
        End Try




    End Sub

    Private updateThread As Thread
    Private Sub updateTask()

        'pulling in reader from xml
        Dim clientReader As XmlReader = XmlReader.Create("launch.xml")

        'Read the XML files to determine the server version
        clientReader.ReadToFollowing("serverURL")
        Dim serverURL As String = clientReader.ReadElementContentAsString()
        Dim serverXMLpath As String = serverURL & "Updater/serverInfo.xml"
        Dim serverReader As XmlTextReader = New XmlTextReader(serverXMLpath)
        serverReader.ReadToFollowing("serverVer")
        Dim serverVer As Double = serverReader.ReadElementContentAsDouble()

        'Read client XML to determine clientVersion
        clientReader.ReadToFollowing("clientVer")
        Dim clientVer As Double = clientReader.ReadElementContentAsDouble()

        'Determine what updates need to be downloaded
  
        serverReader.ReadToFollowing("totalUpdates")
        Dim totalUpdates As Integer = serverReader.ReadElementContentAsInt()

        ' build the list of patches that must be updated
        Dim patchList As New ArrayList

        For i As Integer = 1 To totalUpdates
            serverReader.ReadToFollowing("update" & i)
            Dim versionTest As Double = serverReader.ReadElementContentAsDouble()
            If (versionTest > clientVer) Then
                patchList.Add(versionTest)
            End If
        Next i

        ' build the list of files that must be downloaded
        Dim fileList As New ArrayList
        Dim fileListBuilder As New ArrayList

        For i As Integer = 0 To patchList.Count - 1
            Dim patchPath As String = serverURL & "Updater/" & patchList(patchList.Count - (i + 1)) & "/"
            Dim patchXMLpath As String = patchPath & patchList(patchList.Count - (i + 1)) & ".xml"
            Dim patchReader As XmlTextReader = New XmlTextReader(patchXMLpath)

            patchReader.ReadToFollowing("totalFiles")
            Dim totalFilesInPatch As Integer = patchReader.ReadElementContentAsInt()



            For j As Integer = 1 To totalFilesInPatch
                patchReader.ReadToFollowing("file" & j)
                Dim fileString As String = patchReader.ReadElementContentAsString()

                If fileListBuilder.Contains(fileString) Then
                    ' Do nothing
                Else
                    fileListBuilder.Add(fileString)
                    fileList.Add(patchPath & fileString)
                End If
            Next j

        Next i


        Dim path As String = Directory.GetCurrentDirectory()


        'download files into a Downloads directory
        Dim wc As New WebClient()
        Dim x As Integer = 0
        For Each File In fileList
            Dim lastElement As Integer = fileList(x).ToString.Split("/").Length

            If Directory.Exists(path & "\Downloads") = False Then
                Directory.CreateDirectory(path & "\Downloads")
            End If

            wc.DownloadFile(fileList(x), path & "\Downloads\" & fileList(x).ToString.Split("/")(lastElement - 1))
            x += 1
        Next

        ' Moving files into correct directories
        For i As Integer = 0 To fileListBuilder.Count - 1
            Dim directoryArray() As String = fileListBuilder(i).ToString.Split("/")
            Dim directoryString As String = ""

            If (directoryArray.Length > 1) Then
                For j As Integer = 0 To directoryArray.Length - 2
                    directoryString = directoryString & "\" & directoryArray(j)
                Next j

                If Directory.Exists(path & directoryString) = False Then
                    Directory.CreateDirectory(path & directoryString)
                End If

                If File.Exists(path & directoryString & "\" & directoryArray(directoryArray.Length - 1)) Then
                    File.Delete(path & directoryString & "\" & directoryArray(directoryArray.Length - 1))
                    File.Move(path & "\Downloads\" & directoryArray(directoryArray.Length - 1), path & directoryString & "\" & directoryArray(directoryArray.Length - 1))
                Else
                    File.Move(path & "\Downloads\" & directoryArray(directoryArray.Length - 1), path & directoryString & "\" & directoryArray(directoryArray.Length - 1))
                End If
            Else
                If File.Exists(path & "\" & directoryArray(directoryArray.Length - 1)) Then
                    File.Delete(path & "\" & directoryArray(directoryArray.Length - 1))
                    File.Move(path & "\Downloads\" & directoryArray(directoryArray.Length - 1), path & "\" & directoryArray(directoryArray.Length - 1))
                Else
                    File.Move(path & "\Downloads\" & directoryArray(directoryArray.Length - 1), path & "\" & directoryArray(directoryArray.Length - 1))
                End If
            End If
        Next i

        Directory.Delete(path & "\Downloads\")


        clientReader.Close()

        'change the client version!
        'Dim clientWriter As XmlWriter = XmlWriter.Create("launch.xml")
        'clientWriter.WriteElementString("clientVer", serverVer)


        Console.WriteLine("Files downloaded!")

        ' PRESS START TO PLAY after update
        ' Enable start button


        serverReader.Close()
    End Sub

End Class

