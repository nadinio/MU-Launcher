<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MuLauncher
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MuLauncher))
        Me.xbtn = New System.Windows.Forms.PictureBox()
        Me.strtbtn = New System.Windows.Forms.PictureBox()
        Me.optionbtn = New System.Windows.Forms.PictureBox()
        Me.webby = New System.Windows.Forms.WebBrowser()
        Me.webSite = New System.Windows.Forms.PictureBox()
        Me.forumsBtn = New System.Windows.Forms.PictureBox()
        Me.lblUpdateCheck = New System.Windows.Forms.Label()
        CType(Me.xbtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.strtbtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optionbtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.webSite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.forumsBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'xbtn
        '
        Me.xbtn.BackColor = System.Drawing.Color.Transparent
        Me.xbtn.Image = Global.Muz0r_Launcher.My.Resources.Resources.xbutton
        Me.xbtn.Location = New System.Drawing.Point(756, 60)
        Me.xbtn.Name = "xbtn"
        Me.xbtn.Size = New System.Drawing.Size(14, 14)
        Me.xbtn.TabIndex = 0
        Me.xbtn.TabStop = False
        '
        'strtbtn
        '
        Me.strtbtn.BackgroundImage = Global.Muz0r_Launcher.My.Resources.Resources.start_btn
        Me.strtbtn.Image = Global.Muz0r_Launcher.My.Resources.Resources.start_btn
        Me.strtbtn.Location = New System.Drawing.Point(568, 341)
        Me.strtbtn.Name = "strtbtn"
        Me.strtbtn.Size = New System.Drawing.Size(153, 66)
        Me.strtbtn.TabIndex = 1
        Me.strtbtn.TabStop = False
        '
        'optionbtn
        '
        Me.optionbtn.Image = Global.Muz0r_Launcher.My.Resources.Resources.optionz
        Me.optionbtn.Location = New System.Drawing.Point(468, 392)
        Me.optionbtn.Name = "optionbtn"
        Me.optionbtn.Size = New System.Drawing.Size(84, 15)
        Me.optionbtn.TabIndex = 2
        Me.optionbtn.TabStop = False
        '
        'webby
        '
        Me.webby.Location = New System.Drawing.Point(212, 103)
        Me.webby.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webby.Name = "webby"
        Me.webby.ScrollBarsEnabled = False
        Me.webby.Size = New System.Drawing.Size(433, 228)
        Me.webby.TabIndex = 5
        '
        'webSite
        '
        Me.webSite.BackColor = System.Drawing.Color.Transparent
        Me.webSite.BackgroundImage = Global.Muz0r_Launcher.My.Resources.Resources.websitebtn
        Me.webSite.Location = New System.Drawing.Point(117, 360)
        Me.webSite.Name = "webSite"
        Me.webSite.Size = New System.Drawing.Size(84, 15)
        Me.webSite.TabIndex = 6
        Me.webSite.TabStop = False
        '
        'forumsBtn
        '
        Me.forumsBtn.BackColor = System.Drawing.Color.Transparent
        Me.forumsBtn.BackgroundImage = Global.Muz0r_Launcher.My.Resources.Resources.forumsbtn
        Me.forumsBtn.Location = New System.Drawing.Point(117, 392)
        Me.forumsBtn.Name = "forumsBtn"
        Me.forumsBtn.Size = New System.Drawing.Size(84, 15)
        Me.forumsBtn.TabIndex = 7
        Me.forumsBtn.TabStop = False
        '
        'lblUpdateCheck
        '
        Me.lblUpdateCheck.BackColor = System.Drawing.Color.Transparent
        Me.lblUpdateCheck.ForeColor = System.Drawing.Color.Lime
        Me.lblUpdateCheck.Location = New System.Drawing.Point(242, 360)
        Me.lblUpdateCheck.Name = "lblUpdateCheck"
        Me.lblUpdateCheck.Size = New System.Drawing.Size(310, 15)
        Me.lblUpdateCheck.TabIndex = 8
        Me.lblUpdateCheck.Text = "Checking for Updates..."
        Me.lblUpdateCheck.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'MuLauncher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Muz0r_Launcher.My.Resources.Resources.MuLauncher
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(870, 470)
        Me.Controls.Add(Me.lblUpdateCheck)
        Me.Controls.Add(Me.forumsBtn)
        Me.Controls.Add(Me.webSite)
        Me.Controls.Add(Me.webby)
        Me.Controls.Add(Me.optionbtn)
        Me.Controls.Add(Me.strtbtn)
        Me.Controls.Add(Me.xbtn)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MuLauncher"
        Me.Text = "Muz0r"
        CType(Me.xbtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.strtbtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optionbtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.webSite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.forumsBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents xbtn As System.Windows.Forms.PictureBox
    Friend WithEvents strtbtn As System.Windows.Forms.PictureBox
    Friend WithEvents optionbtn As System.Windows.Forms.PictureBox
    Friend WithEvents webby As System.Windows.Forms.WebBrowser
    Friend WithEvents webSite As System.Windows.Forms.PictureBox
    Friend WithEvents forumsBtn As System.Windows.Forms.PictureBox
    Friend WithEvents lblUpdateCheck As System.Windows.Forms.Label

End Class
