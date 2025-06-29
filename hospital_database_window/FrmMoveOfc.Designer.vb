<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMoveOfc
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtAdNum = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtCOffice = New System.Windows.Forms.TextBox()
        Me.TxtNOffice = New System.Windows.Forms.TextBox()
        Me.TxtNBedNo = New System.Windows.Forms.TextBox()
        Me.TxtNDoctor = New System.Windows.Forms.TextBox()
        Me.CmdFind = New System.Windows.Forms.Button()
        Me.CmdEdit = New System.Windows.Forms.Button()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(71, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "住院号："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "病人姓名："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "当前科室："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(56, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "更换科室："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(56, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "更换床位："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(56, 220)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "主治医生："
        '
        'TxtAdNum
        '
        Me.TxtAdNum.Location = New System.Drawing.Point(144, 25)
        Me.TxtAdNum.Name = "TxtAdNum"
        Me.TxtAdNum.Size = New System.Drawing.Size(100, 25)
        Me.TxtAdNum.TabIndex = 6
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(144, 63)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(100, 25)
        Me.TxtName.TabIndex = 7
        '
        'TxtCOffice
        '
        Me.TxtCOffice.Location = New System.Drawing.Point(144, 100)
        Me.TxtCOffice.Name = "TxtCOffice"
        Me.TxtCOffice.Size = New System.Drawing.Size(191, 25)
        Me.TxtCOffice.TabIndex = 8
        '
        'TxtNOffice
        '
        Me.TxtNOffice.Location = New System.Drawing.Point(144, 137)
        Me.TxtNOffice.Name = "TxtNOffice"
        Me.TxtNOffice.Size = New System.Drawing.Size(191, 25)
        Me.TxtNOffice.TabIndex = 9
        '
        'TxtNBedNo
        '
        Me.TxtNBedNo.Location = New System.Drawing.Point(144, 173)
        Me.TxtNBedNo.Name = "TxtNBedNo"
        Me.TxtNBedNo.Size = New System.Drawing.Size(100, 25)
        Me.TxtNBedNo.TabIndex = 10
        '
        'TxtNDoctor
        '
        Me.TxtNDoctor.Location = New System.Drawing.Point(144, 210)
        Me.TxtNDoctor.Name = "TxtNDoctor"
        Me.TxtNDoctor.Size = New System.Drawing.Size(100, 25)
        Me.TxtNDoctor.TabIndex = 11
        '
        'CmdFind
        '
        Me.CmdFind.Location = New System.Drawing.Point(301, 27)
        Me.CmdFind.Name = "CmdFind"
        Me.CmdFind.Size = New System.Drawing.Size(75, 23)
        Me.CmdFind.TabIndex = 12
        Me.CmdFind.Text = "查询"
        Me.CmdFind.UseVisualStyleBackColor = True
        '
        'CmdEdit
        '
        Me.CmdEdit.Location = New System.Drawing.Point(74, 295)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 13
        Me.CmdEdit.Text = "修改"
        Me.CmdEdit.UseVisualStyleBackColor = True
        '
        'CmdExit
        '
        Me.CmdExit.Location = New System.Drawing.Point(222, 295)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(75, 23)
        Me.CmdExit.TabIndex = 14
        Me.CmdExit.Text = "退出"
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'FrmMoveOfc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 350)
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdFind)
        Me.Controls.Add(Me.TxtNDoctor)
        Me.Controls.Add(Me.TxtNBedNo)
        Me.Controls.Add(Me.TxtNOffice)
        Me.Controls.Add(Me.TxtCOffice)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.TxtAdNum)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "FrmMoveOfc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "转科室"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtAdNum As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents TxtCOffice As TextBox
    Friend WithEvents TxtNOffice As TextBox
    Friend WithEvents TxtNBedNo As TextBox
    Friend WithEvents TxtNDoctor As TextBox
    Friend WithEvents CmdFind As Button
    Friend WithEvents CmdEdit As Button
    Friend WithEvents CmdExit As Button
End Class
