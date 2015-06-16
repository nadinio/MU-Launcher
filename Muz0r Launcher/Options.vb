Imports Microsoft.Win32

Public Class Options

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

    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Resolutions:
        ' 1 = 800 x 600
        ' 2 = 1024 x 768
        ' 3 = 1280 x 1024

        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        Me.BackColor = Color.Empty
        TransparencyKey = Me.BackColor


        Dim acctValue As String = CStr(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Webzen\MU\Config", "ID", String.Empty))
        Dim winModeVal As Integer = CInt(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Webzen\MU\Config", "WindowMode", 0))
        Dim soundVal As Integer = CInt(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Webzen\MU\Config", "SoundOnOff", 1))
        Dim musicVal As Integer = CInt(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Webzen\MU\Config", "MusicOnOff", 1))
        Dim resVal As Integer = CInt(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Webzen\MU\Config", "Resolution", 1))
        Dim colrDep As Integer = CInt(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Webzen\MU\Config", "ColorDepth", 0))

        Me.txtAcct.Text = acctValue

        If winModeVal = 1 Then
            Me.chkWinMode.Checked = True
        End If

        If soundVal = 1 Then
            Me.chkSound.Checked = True
        End If

        If musicVal = 1 Then
            Me.chkMusic.Checked = True
        End If

        If colrDep = 0 Then
            Me.rad16bit.Checked = True
        Else
            Me.rad32bit.Checked = True
        End If

        Select Case resVal
            Case 1
                rad800600.Checked = True
            Case 2
                rad1024768.Checked = True
            Case 3
                rad12801024.Checked = True
        End Select

    End Sub
    Private Sub xbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xbtn.Click
        Dim acctValue As String = Me.txtAcct.Text
        Dim winModeVal As Integer
        Dim soundVal As Integer
        Dim musicVal As Integer
        Dim resVal As Integer
        Dim colrDep As Integer

        If rad16bit.Checked Then
            colrDep = 0
        ElseIf rad32bit.Checked Then
            colrDep = 1
        End If


        If Me.chkWinMode.Checked Then
            winModeVal = 1
        Else
            winModeVal = 0
        End If


        If Me.chkSound.Checked Then
            soundVal = 1
        Else
            soundVal = 0
        End If


        If chkMusic.Checked Then
            musicVal = 1
        Else
            musicVal = 0
        End If

        If rad800600.Checked Then
            resVal = 1
        ElseIf rad1024768.Checked Then
            resVal = 2
        ElseIf rad12801024.Checked Then
            resVal = 3
        End If


        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Webzen\MU\Config", "ID", acctValue)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Webzen\MU\Config", "WindowMode", winModeVal)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Webzen\MU\Config", "SoundOnOff", soundVal)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Webzen\MU\Config", "MusicOnOff", musicVal)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Webzen\MU\Config", "Resolution", resVal)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Webzen\MU\Config", "ColorDepth", colrDep)


        Me.Close()
    End Sub

    Private Sub xbtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles xbtn.MouseDown
        Me.xbtn.Image = My.Resources.ixbutton
    End Sub

    Private Sub xbtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles xbtn.MouseUp
        Me.xbtn.Image = My.Resources.xbutton
    End Sub
End Class