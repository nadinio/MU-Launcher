<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
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
        Me.txtAcct = New System.Windows.Forms.TextBox()
        Me.chkWinMode = New System.Windows.Forms.CheckBox()
        Me.chkMusic = New System.Windows.Forms.CheckBox()
        Me.chkSound = New System.Windows.Forms.CheckBox()
        Me.grpRes = New System.Windows.Forms.GroupBox()
        Me.rad12801024 = New System.Windows.Forms.RadioButton()
        Me.rad1024768 = New System.Windows.Forms.RadioButton()
        Me.rad800600 = New System.Windows.Forms.RadioButton()
        Me.grpColor = New System.Windows.Forms.GroupBox()
        Me.rad32bit = New System.Windows.Forms.RadioButton()
        Me.rad16bit = New System.Windows.Forms.RadioButton()
        Me.xbtn = New System.Windows.Forms.PictureBox()
        Me.rad1366768 = New System.Windows.Forms.RadioButton()
        Me.rad640480 = New System.Windows.Forms.RadioButton()
        Me.rad16001280 = New System.Windows.Forms.RadioButton()
        Me.grpRes.SuspendLayout()
        Me.grpColor.SuspendLayout()
        CType(Me.xbtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtAcct
        '
        Me.txtAcct.Location = New System.Drawing.Point(127, 262)
        Me.txtAcct.Name = "txtAcct"
        Me.txtAcct.Size = New System.Drawing.Size(97, 20)
        Me.txtAcct.TabIndex = 1
        Me.txtAcct.Text = "Account Name"
        '
        'chkWinMode
        '
        Me.chkWinMode.AutoSize = True
        Me.chkWinMode.BackColor = System.Drawing.Color.Transparent
        Me.chkWinMode.Location = New System.Drawing.Point(109, 292)
        Me.chkWinMode.Name = "chkWinMode"
        Me.chkWinMode.Size = New System.Drawing.Size(75, 17)
        Me.chkWinMode.TabIndex = 3
        Me.chkWinMode.Text = "Win Mode"
        Me.chkWinMode.UseVisualStyleBackColor = False
        '
        'chkMusic
        '
        Me.chkMusic.AutoSize = True
        Me.chkMusic.BackColor = System.Drawing.Color.Transparent
        Me.chkMusic.Location = New System.Drawing.Point(40, 330)
        Me.chkMusic.Name = "chkMusic"
        Me.chkMusic.Size = New System.Drawing.Size(90, 17)
        Me.chkMusic.TabIndex = 4
        Me.chkMusic.Text = "Music On/Off"
        Me.chkMusic.UseVisualStyleBackColor = False
        '
        'chkSound
        '
        Me.chkSound.AutoSize = True
        Me.chkSound.BackColor = System.Drawing.Color.Transparent
        Me.chkSound.Location = New System.Drawing.Point(187, 330)
        Me.chkSound.Name = "chkSound"
        Me.chkSound.Size = New System.Drawing.Size(93, 17)
        Me.chkSound.TabIndex = 5
        Me.chkSound.Text = "Sound On/Off"
        Me.chkSound.UseVisualStyleBackColor = False
        '
        'grpRes
        '
        Me.grpRes.BackColor = System.Drawing.Color.Transparent
        Me.grpRes.Controls.Add(Me.rad16001280)
        Me.grpRes.Controls.Add(Me.rad640480)
        Me.grpRes.Controls.Add(Me.rad1366768)
        Me.grpRes.Controls.Add(Me.rad12801024)
        Me.grpRes.Controls.Add(Me.rad1024768)
        Me.grpRes.Controls.Add(Me.rad800600)
        Me.grpRes.Location = New System.Drawing.Point(43, 54)
        Me.grpRes.Name = "grpRes"
        Me.grpRes.Size = New System.Drawing.Size(278, 70)
        Me.grpRes.TabIndex = 6
        Me.grpRes.TabStop = False
        '
        'rad12801024
        '
        Me.rad12801024.AutoSize = True
        Me.rad12801024.Location = New System.Drawing.Point(6, 40)
        Me.rad12801024.Name = "rad12801024"
        Me.rad12801024.Size = New System.Drawing.Size(78, 17)
        Me.rad12801024.TabIndex = 2
        Me.rad12801024.TabStop = True
        Me.rad12801024.Text = "1280x1024"
        Me.rad12801024.UseVisualStyleBackColor = True
        '
        'rad1024768
        '
        Me.rad1024768.AutoSize = True
        Me.rad1024768.Location = New System.Drawing.Point(180, 19)
        Me.rad1024768.Name = "rad1024768"
        Me.rad1024768.Size = New System.Drawing.Size(72, 17)
        Me.rad1024768.TabIndex = 1
        Me.rad1024768.TabStop = True
        Me.rad1024768.Text = "1024x768"
        Me.rad1024768.UseVisualStyleBackColor = True
        '
        'rad800600
        '
        Me.rad800600.AutoSize = True
        Me.rad800600.Location = New System.Drawing.Point(92, 19)
        Me.rad800600.Name = "rad800600"
        Me.rad800600.Size = New System.Drawing.Size(66, 17)
        Me.rad800600.TabIndex = 0
        Me.rad800600.TabStop = True
        Me.rad800600.Text = "800x600"
        Me.rad800600.UseVisualStyleBackColor = True
        '
        'grpColor
        '
        Me.grpColor.BackColor = System.Drawing.Color.Transparent
        Me.grpColor.Controls.Add(Me.rad32bit)
        Me.grpColor.Controls.Add(Me.rad16bit)
        Me.grpColor.Location = New System.Drawing.Point(87, 164)
        Me.grpColor.Name = "grpColor"
        Me.grpColor.Size = New System.Drawing.Size(193, 40)
        Me.grpColor.TabIndex = 7
        Me.grpColor.TabStop = False
        '
        'rad32bit
        '
        Me.rad32bit.AutoSize = True
        Me.rad32bit.Location = New System.Drawing.Point(105, 19)
        Me.rad32bit.Name = "rad32bit"
        Me.rad32bit.Size = New System.Drawing.Size(48, 17)
        Me.rad32bit.TabIndex = 1
        Me.rad32bit.TabStop = True
        Me.rad32bit.Text = "32bit"
        Me.rad32bit.UseVisualStyleBackColor = True
        '
        'rad16bit
        '
        Me.rad16bit.AutoSize = True
        Me.rad16bit.Location = New System.Drawing.Point(26, 19)
        Me.rad16bit.Name = "rad16bit"
        Me.rad16bit.Size = New System.Drawing.Size(48, 17)
        Me.rad16bit.TabIndex = 0
        Me.rad16bit.TabStop = True
        Me.rad16bit.Text = "16bit"
        Me.rad16bit.UseVisualStyleBackColor = True
        '
        'xbtn
        '
        Me.xbtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.xbtn.BackColor = System.Drawing.Color.Transparent
        Me.xbtn.BackgroundImage = Global.MuLauncher.My.Resources.Resources.xbutton
        Me.xbtn.Location = New System.Drawing.Point(316, 17)
        Me.xbtn.Name = "xbtn"
        Me.xbtn.Size = New System.Drawing.Size(14, 14)
        Me.xbtn.TabIndex = 0
        Me.xbtn.TabStop = False
        '
        'rad1366768
        '
        Me.rad1366768.AutoSize = True
        Me.rad1366768.Location = New System.Drawing.Point(92, 40)
        Me.rad1366768.Name = "rad1366768"
        Me.rad1366768.Size = New System.Drawing.Size(72, 17)
        Me.rad1366768.TabIndex = 3
        Me.rad1366768.TabStop = True
        Me.rad1366768.Text = "1366x768"
        Me.rad1366768.UseVisualStyleBackColor = True
        '
        'rad640480
        '
        Me.rad640480.AutoSize = True
        Me.rad640480.Location = New System.Drawing.Point(6, 19)
        Me.rad640480.Name = "rad640480"
        Me.rad640480.Size = New System.Drawing.Size(66, 17)
        Me.rad640480.TabIndex = 4
        Me.rad640480.TabStop = True
        Me.rad640480.Text = "640x480"
        Me.rad640480.UseVisualStyleBackColor = True
        '
        'rad16001280
        '
        Me.rad16001280.AutoSize = True
        Me.rad16001280.Location = New System.Drawing.Point(180, 40)
        Me.rad16001280.Name = "rad16001280"
        Me.rad16001280.Size = New System.Drawing.Size(78, 17)
        Me.rad16001280.TabIndex = 5
        Me.rad16001280.TabStop = True
        Me.rad16001280.Text = "1600x1280"
        Me.rad16001280.UseVisualStyleBackColor = True
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 375)
        Me.Controls.Add(Me.grpColor)
        Me.Controls.Add(Me.grpRes)
        Me.Controls.Add(Me.chkSound)
        Me.Controls.Add(Me.chkMusic)
        Me.Controls.Add(Me.chkWinMode)
        Me.Controls.Add(Me.txtAcct)
        Me.Controls.Add(Me.xbtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Options"
        Me.Text = "Options"
        Me.grpRes.ResumeLayout(False)
        Me.grpRes.PerformLayout()
        Me.grpColor.ResumeLayout(False)
        Me.grpColor.PerformLayout()
        CType(Me.xbtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents xbtn As System.Windows.Forms.PictureBox
    Friend WithEvents txtAcct As System.Windows.Forms.TextBox
    Friend WithEvents chkWinMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkMusic As System.Windows.Forms.CheckBox
    Friend WithEvents chkSound As System.Windows.Forms.CheckBox
    Friend WithEvents grpRes As System.Windows.Forms.GroupBox
    Friend WithEvents rad12801024 As System.Windows.Forms.RadioButton
    Friend WithEvents rad1024768 As System.Windows.Forms.RadioButton
    Friend WithEvents rad800600 As System.Windows.Forms.RadioButton
    Friend WithEvents grpColor As System.Windows.Forms.GroupBox
    Friend WithEvents rad32bit As System.Windows.Forms.RadioButton
    Friend WithEvents rad16bit As System.Windows.Forms.RadioButton
    Friend WithEvents rad640480 As RadioButton
    Friend WithEvents rad1366768 As RadioButton
    Friend WithEvents rad16001280 As RadioButton
End Class
