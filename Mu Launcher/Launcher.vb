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
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False

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
        Dim path As String = Directory.GetCurrentDirectory()

        For i As Integer = 0 To reqPatches.Count - 1
            Dim fileList As New ArrayList
            Dim CRCList As New ArrayList
            Dim downloadList As New Dictionary(Of String, String)
            Dim patchPath As String = serverUrl & "patch/" & reqPatches.Item(i) & "/"
            Dim request = DirectCast(WebRequest.Create(patchPath & "filelist.txt"), HttpWebRequest)
            Dim response = DirectCast(request.GetResponse(), HttpWebResponse)
            Using sr As New StreamReader(response.GetResponseStream())
                Do While sr.Peek() >= 0
                    Dim splitLine As String() = sr.ReadLine.Split(",")
                    fileList.Add(splitLine(0))
                    CRCList.Add(splitLine(1).Replace(" ", ""))
                Loop
            End Using

            For j As Integer = 0 To fileList.Count - 1
                downloadList.Add(patchPath & fileList(j).Replace("\", "/"), CRCList(j))
            Next j

            ' Download dem files.
            For Each kvp As KeyValuePair(Of String, String) In downloadList
                Dim saveLoc As String = path & kvp.Key.Replace(patchPath, "\")
                saveLoc = saveLoc.Replace("/", "\")

                Dim directoryBuilder As String() = saveLoc.Split("\")
                Dim directoryPath As String = ""

                For j As Integer = 0 To directoryBuilder.Length - 2
                    directoryPath = directoryPath & directoryBuilder(j) & "\"
                Next j

                If (IO.Directory.Exists(directoryPath) = False) Then
                    IO.Directory.CreateDirectory(directoryPath)
                End If

                Do
                    If (IO.File.Exists(saveLoc)) Then
                        IO.File.Delete(saveLoc)
                    End If
                    Using wc As New WebClient
                        wc.DownloadFile(New Uri(kvp.Key), saveLoc)
                    End Using
                Loop Until kvp.Value.Equals(GetCRC32(saveLoc))

            Next
        Next i

        'change the client version!
        Dim clientXml As XmlDocument = New XmlDocument()
        clientXml.Load("launch.xml")
        clientXml.DocumentElement("clientVer").InnerText = serverVer.ToString
        clientXml.Save("launch.xml")

        'allow launcher to launch
        Me.lblUpdateCheck.Text = "Client has been updated, press start to play!"
        Me.strtbtn.Visible = True

    End Sub

    'The author of this CRC32 code is Tim Hartwig.
    Public Function GetCRC32(ByVal sFileName As String) As String
        Try
            Using FS As FileStream = New FileStream(sFileName, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)


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
            End Using
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class

