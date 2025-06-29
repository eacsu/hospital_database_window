<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLcdRecord
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLcdRecord))
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdRetry = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.LcdClass = New System.Windows.Forms.ComboBox()
        Me.Lcdprice = New System.Windows.Forms.TextBox()
        Me.LcdSpecs = New System.Windows.Forms.TextBox()
        Me.LcdName = New System.Windows.Forms.TextBox()
        Me.LcdID = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LcdDate = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(587, 167)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 15)
        Me.Label15.TabIndex = 60
        Me.Label15.Text = "*"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(316, 160)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 15)
        Me.Label14.TabIndex = 59
        Me.Label14.Text = "*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(587, 96)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 15)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(316, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 15)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "*"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(457, 313)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(83, 37)
        Me.cmdExit.TabIndex = 56
        Me.cmdExit.Text = "退出"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdRetry
        '
        Me.cmdRetry.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cmdRetry.Location = New System.Drawing.Point(318, 313)
        Me.cmdRetry.Name = "cmdRetry"
        Me.cmdRetry.Size = New System.Drawing.Size(84, 37)
        Me.cmdRetry.TabIndex = 55
        Me.cmdRetry.Text = "重填"
        Me.cmdRetry.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(179, 313)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(91, 37)
        Me.cmdOK.TabIndex = 54
        Me.cmdOK.Text = "确认"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'LcdClass
        '
        Me.LcdClass.FormattingEnabled = True
        Me.LcdClass.Items.AddRange(New Object() {"处方药", "非处方药"})
        Me.LcdClass.Location = New System.Drawing.Point(481, 155)
        Me.LcdClass.Name = "LcdClass"
        Me.LcdClass.Size = New System.Drawing.Size(100, 23)
        Me.LcdClass.TabIndex = 52
        '
        'Lcdprice
        '
        Me.Lcdprice.Location = New System.Drawing.Point(210, 231)
        Me.Lcdprice.Name = "Lcdprice"
        Me.Lcdprice.Size = New System.Drawing.Size(100, 25)
        Me.Lcdprice.TabIndex = 51
        '
        'LcdSpecs
        '
        Me.LcdSpecs.Location = New System.Drawing.Point(210, 158)
        Me.LcdSpecs.Name = "LcdSpecs"
        Me.LcdSpecs.Size = New System.Drawing.Size(100, 25)
        Me.LcdSpecs.TabIndex = 46
        '
        'LcdName
        '
        Me.LcdName.Location = New System.Drawing.Point(481, 83)
        Me.LcdName.Name = "LcdName"
        Me.LcdName.Size = New System.Drawing.Size(100, 25)
        Me.LcdName.TabIndex = 45
        '
        'LcdID
        '
        Me.LcdID.Location = New System.Drawing.Point(210, 84)
        Me.LcdID.Name = "LcdID"
        Me.LcdID.Size = New System.Drawing.Size(100, 25)
        Me.LcdID.TabIndex = 44
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.Location = New System.Drawing.Point(382, 231)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 19)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "有效期："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(126, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 19)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "价  格："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(381, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 19)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "类  型："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(125, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 19)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "规  格："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(381, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 19)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "药品名称："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(82, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 19)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "药品编号(Y--)："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(316, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 15)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(587, 234)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 15)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "*"
        '
        'LcdDate
        '
        Me.LcdDate.Location = New System.Drawing.Point(481, 228)
        Me.LcdDate.Name = "LcdDate"
        Me.LcdDate.Size = New System.Drawing.Size(100, 25)
        Me.LcdDate.TabIndex = 63
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 345)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(82, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 86
        Me.PictureBox1.TabStop = False
        '
        'frmLcdRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 401)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LcdDate)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdRetry)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.LcdClass)
        Me.Controls.Add(Me.Lcdprice)
        Me.Controls.Add(Me.LcdSpecs)
        Me.Controls.Add(Me.LcdName)
        Me.Controls.Add(Me.LcdID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmLcdRecord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "药品信息添加"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cmdExit As Button
    Friend WithEvents cmdRetry As Button
    Friend WithEvents cmdOK As Button
    Friend WithEvents LcdClass As ComboBox
    Friend WithEvents Lcdprice As TextBox
    Friend WithEvents LcdSpecs As TextBox
    Friend WithEvents LcdName As TextBox
    Friend WithEvents LcdID As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LcdDate As TextBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
