<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLcdEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLcdEdit))
        Me.OptAll = New System.Windows.Forms.RadioButton()
        Me.OptPName = New System.Windows.Forms.RadioButton()
        Me.OptPNo = New System.Windows.Forms.RadioButton()
        Me.txtPName = New System.Windows.Forms.TextBox()
        Me.txtPNo = New System.Windows.Forms.TextBox()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdFind = New System.Windows.Forms.Button()
        Me.dGrdP = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.dGrdP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OptAll
        '
        Me.OptAll.AutoSize = True
        Me.OptAll.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OptAll.Location = New System.Drawing.Point(533, 5)
        Me.OptAll.Name = "OptAll"
        Me.OptAll.Size = New System.Drawing.Size(60, 23)
        Me.OptAll.TabIndex = 19
        Me.OptAll.Text = "全部"
        Me.OptAll.UseVisualStyleBackColor = True
        '
        'OptPName
        '
        Me.OptPName.AutoSize = True
        Me.OptPName.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OptPName.Location = New System.Drawing.Point(276, 5)
        Me.OptPName.Name = "OptPName"
        Me.OptPName.Size = New System.Drawing.Size(90, 23)
        Me.OptPName.TabIndex = 18
        Me.OptPName.Text = "药品名称"
        Me.OptPName.UseVisualStyleBackColor = True
        '
        'OptPNo
        '
        Me.OptPNo.AutoSize = True
        Me.OptPNo.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OptPNo.Location = New System.Drawing.Point(41, 5)
        Me.OptPNo.Name = "OptPNo"
        Me.OptPNo.Size = New System.Drawing.Size(90, 23)
        Me.OptPNo.TabIndex = 17
        Me.OptPNo.Text = "药品编号"
        Me.OptPNo.UseVisualStyleBackColor = True
        '
        'txtPName
        '
        Me.txtPName.Location = New System.Drawing.Point(385, 4)
        Me.txtPName.Name = "txtPName"
        Me.txtPName.Size = New System.Drawing.Size(100, 25)
        Me.txtPName.TabIndex = 16
        '
        'txtPNo
        '
        Me.txtPNo.Location = New System.Drawing.Point(146, 4)
        Me.txtPNo.Name = "txtPNo"
        Me.txtPNo.Size = New System.Drawing.Size(100, 25)
        Me.txtPNo.TabIndex = 15
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(472, 411)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(72, 35)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "退出"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(354, 411)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 35)
        Me.cmdDelete.TabIndex = 13
        Me.cmdDelete.Text = "删除"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cmdEdit.Location = New System.Drawing.Point(241, 411)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(77, 35)
        Me.cmdEdit.TabIndex = 12
        Me.cmdEdit.Text = "修改"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(700, 5)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(72, 28)
        Me.cmdFind.TabIndex = 11
        Me.cmdFind.Text = "查询"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'dGrdP
        '
        Me.dGrdP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGrdP.Location = New System.Drawing.Point(-12, 39)
        Me.dGrdP.Name = "dGrdP"
        Me.dGrdP.ReadOnly = True
        Me.dGrdP.RowHeadersWidth = 51
        Me.dGrdP.RowTemplate.Height = 27
        Me.dGrdP.Size = New System.Drawing.Size(825, 366)
        Me.dGrdP.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1, 405)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 86
        Me.PictureBox1.TabStop = False
        '
        'frmLcdEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.OptAll)
        Me.Controls.Add(Me.OptPName)
        Me.Controls.Add(Me.OptPNo)
        Me.Controls.Add(Me.txtPName)
        Me.Controls.Add(Me.txtPNo)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.dGrdP)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmLcdEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "药品信息维护"
        CType(Me.dGrdP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OptAll As RadioButton
    Friend WithEvents OptPName As RadioButton
    Friend WithEvents OptPNo As RadioButton
    Friend WithEvents txtPName As TextBox
    Friend WithEvents txtPNo As TextBox
    Friend WithEvents cmdExit As Button
    Friend WithEvents cmdDelete As Button
    Friend WithEvents cmdEdit As Button
    Friend WithEvents cmdFind As Button
    Friend WithEvents dGrdP As DataGridView
    Friend WithEvents PictureBox1 As PictureBox
End Class
