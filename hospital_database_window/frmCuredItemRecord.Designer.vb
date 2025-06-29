<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuredItemRecord
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCuredItemRecord))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdRetry = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.ItemPrice = New System.Windows.Forms.TextBox()
        Me.ItemName = New System.Windows.Forms.TextBox()
        Me.ItemID = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ItemClass = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(333, 154)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 15)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "*"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(604, 154)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 15)
        Me.Label15.TabIndex = 81
        Me.Label15.Text = "*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(604, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 15)
        Me.Label13.TabIndex = 79
        Me.Label13.Text = "*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(333, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 15)
        Me.Label12.TabIndex = 78
        Me.Label12.Text = "*"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(482, 245)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(82, 40)
        Me.cmdExit.TabIndex = 77
        Me.cmdExit.Text = "退出"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdRetry
        '
        Me.cmdRetry.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cmdRetry.Location = New System.Drawing.Point(343, 245)
        Me.cmdRetry.Name = "cmdRetry"
        Me.cmdRetry.Size = New System.Drawing.Size(83, 40)
        Me.cmdRetry.TabIndex = 76
        Me.cmdRetry.Text = "重填"
        Me.cmdRetry.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(204, 245)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(90, 40)
        Me.cmdOK.TabIndex = 75
        Me.cmdOK.Text = "确认"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'ItemPrice
        '
        Me.ItemPrice.Location = New System.Drawing.Point(227, 151)
        Me.ItemPrice.Name = "ItemPrice"
        Me.ItemPrice.Size = New System.Drawing.Size(100, 25)
        Me.ItemPrice.TabIndex = 73
        '
        'ItemName
        '
        Me.ItemName.Location = New System.Drawing.Point(498, 81)
        Me.ItemName.Name = "ItemName"
        Me.ItemName.Size = New System.Drawing.Size(100, 25)
        Me.ItemName.TabIndex = 71
        '
        'ItemID
        '
        Me.ItemID.Location = New System.Drawing.Point(227, 81)
        Me.ItemID.Name = "ItemID"
        Me.ItemID.Size = New System.Drawing.Size(100, 25)
        Me.ItemID.TabIndex = 70
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(143, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 19)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "价  格："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(398, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 19)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "类  型："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(398, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 19)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "项目名称："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(99, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 19)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "项目编号(J--)："
        '
        'ItemClass
        '
        Me.ItemClass.FormattingEnabled = True
        Me.ItemClass.Items.AddRange(New Object() {"护理", "一般治疗", "一般检查"})
        Me.ItemClass.Location = New System.Drawing.Point(498, 151)
        Me.ItemClass.Name = "ItemClass"
        Me.ItemClass.Size = New System.Drawing.Size(100, 23)
        Me.ItemClass.TabIndex = 83
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 245)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(122, 83)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 86
        Me.PictureBox1.TabStop = False
        '
        'frmCuredItemRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 325)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ItemClass)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdRetry)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.ItemPrice)
        Me.Controls.Add(Me.ItemName)
        Me.Controls.Add(Me.ItemID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCuredItemRecord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "检查项目添加"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cmdExit As Button
    Friend WithEvents cmdRetry As Button
    Friend WithEvents cmdOK As Button
    Friend WithEvents ItemPrice As TextBox
    Friend WithEvents ItemName As TextBox
    Friend WithEvents ItemID As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ItemClass As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
