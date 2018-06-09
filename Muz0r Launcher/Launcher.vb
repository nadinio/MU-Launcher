Imports System.Xml
Imports System.Threading
Imports System.Net
Imports System.IO

Public Class MuLauncher

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

        'navigate webpage
        Try
            Dim bannerURL As String

            Using reader = XmlReader.Create("launch.xml")
                reader.ReadToFollowing("bannerURL")
                bannerURL = reader.ReadElementContentAsString()
            End Using

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
        Dim webURL As String

        Using reader As XmlReader = XmlReader.Create("launch.xml")
            reader.ReadToFollowing("webURL")
            webURL = reader.ReadElementContentAsString()
        End Using

        System.Diagnostics.Process.Start(webURL)
    End Sub

    Private Sub webSite_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles webSite.MouseDown
        Me.webSite.Image = My.Resources.iwebsitebtn
    End Sub

    Private Sub webSite_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles webSite.MouseUp
        Me.webSite.Image = My.Resources.websitebtn
    End Sub

    'Forums button
    Private Sub forumsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles forumsBtn.Click
        Dim forumURL As String

        Using reader As XmlReader = XmlReader.Create("launch.xml")
            reader.ReadToFollowing("forumURL")
            forumURL = reader.ReadElementContentAsString()
        End Using

        System.Diagnostics.Process.Start(forumURL)

    End Sub

    Private Sub forumsBtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles forumsBtn.MouseDown
        Me.forumsBtn.Image = My.Resources.iforumsbtn
    End Sub

    Private Sub forumsBtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles forumsBtn.MouseUp
        Me.forumsBtn.Image = My.Resources.forumsbtn
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown


        Me.strtbtn.Visible = False

        Try
            Dim clientVer As Double?
            Dim serverVer As Double?

            Using clientReader As XmlReader = XmlReader.Create("launch.xml")
                'Read the XML files to determine the server version
                clientReader.ReadToFollowing("serverURL")
                Using serverReader As XmlTextReader = New XmlTextReader(clientReader.ReadElementContentAsString() & "patch/serverinfo.xml")
                    serverVer = If(serverReader.ReadToFollowing("serverVer"), serverReader.ReadElementContentAsDouble, Double.NaN)

                    'Read client XML to determine clientVersion
                    clientVer = If(clientReader.ReadToFollowing("clientVer"), clientReader.ReadElementContentAsDouble, Double.NaN)
                End Using
            End Using


            If clientVer < serverVer Then
                Me.lblUpdateCheck.Text = "Download updates, please wait..."
                updateThread = New Thread(AddressOf updateTask)
                updateThread.IsBackground = True
                updateThread.Start()
            ElseIf clientVer = serverVer Then
                Me.lblUpdateCheck.Text = "Press start to play!"
                Me.strtbtn.Visible = True
            ElseIf clientVer = Double.NaN Or serverVer = Double.NaN Then
                Me.lblUpdateCheck.Text = "Error reading XML files! Cannot update!"
                Me.strtbtn.Visible = True
            End If


        Catch ex As Exception
            Me.lblUpdateCheck.Text = "Could not connect to server, check your connection!"
        End Try


    End Sub

    Private updateThread As Thread
    Private Sub updateTask()

        Dim reqPatches As New ArrayList
        Dim serverUrl As String
        Dim serverVer As Double?

        'pulling in reader from xml
        Using clientReader As XmlReader = XmlReader.Create("launch.xml")
            'Read the XML files to determine the server version
            clientReader.ReadToFollowing("serverURL")
            serverUrl = clientReader.ReadElementContentAsString
            Using serverReader As XmlTextReader = New XmlTextReader(serverUrl & "patch/serverinfo.xml")
                serverVer = If(serverReader.ReadToFollowing("serverVer"), serverReader.ReadElementContentAsDouble, Double.NaN)

                'Read client XML to determine clientVersion
                Dim clientVer As Double? = If(clientReader.ReadToFollowing("clientVer"), clientReader.ReadElementContentAsDouble(), Double.NaN)

                'Determine what patches need to be downloaded
                serverReader.ReadToFollowing("patchList")
                Dim patchList As New ArrayList(serverReader.ReadElementContentAsString.Replace(" ", "").Split(","c))

                For Each patch As Double In patchList
                    If (patch > clientVer) Then
                        reqPatches.Add(patch)
                    End If
                Next
            End Using
        End Using


        ' build the list of files that must be downloaded
        Dim fileList As New ArrayList
        Dim downloadList As New ArrayList
        Dim path As String = Directory.GetCurrentDirectory()

        For i As Integer = 0 To reqPatches.Count - 1
            Dim patchPath As String = serverUrl & "patch/" & reqPatches.Item(i) & "/"
            Dim request = DirectCast(WebRequest.Create(patchPath & "filelist.txt"), HttpWebRequest)
            Dim response = DirectCast(request.GetResponse(), HttpWebResponse)
            Using sr As New StreamReader(response.GetResponseStream())
                Do While sr.Peek() >= 0
                    fileList.Add(sr.ReadLine())
                Loop
                fileList.Remove("[File List]")
            End Using

            For Each file As String In fileList
                If (System.IO.File.Exists(path & file)) Then
                    System.IO.File.Delete(path & file)
                End If
                downloadList.Add(patchPath & file.Replace("\", "/"))
            Next

            ' Download dem files.
            Using wc As New WebClient
                For Each file In downloadList
                    Dim saveLoc As String = path & file.Replace(patchPath, "\")
                    saveLoc = saveLoc.Replace("/", "\")

                    Dim directoryBuilder As String() = saveLoc.Split("\")
                    Dim directoryPath As String = ""

                    For j As Integer = 0 To directoryBuilder.Length - 2
                        directoryPath = directoryPath & directoryBuilder(j) & "\"
                    Next j

                    If (System.IO.Directory.Exists(directoryPath) = False) Then
                        System.IO.Directory.CreateDirectory(directoryPath)
                    End If
                    wc.DownloadFile(New Uri(file), saveLoc)
                Next
            End Using

        Next i

        'change the client version!

        Dim clientXml As XmlDocument = New XmlDocument()
        clientXml.Load("launch.xml")
        clientXml.DocumentElement("clientVer").InnerText = serverVer.ToString
        clientXml.Save("launch.xml")

        ' PRESS START TO PLAY after update
        ' Enable start button



    End Sub

End Class

