<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMoveBed
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
        Me.TxtAdNum = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtOfi = New System.Windows.Forms.TextBox()
        Me.TxtCBedNo = New System.Windows.Forms.TextBox()
        Me.CmdFind = New System.Windows.Forms.Button()
        Me.CmdEdit = New System.Windows.Forms.Button()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.TxtTBedNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "住院号："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(65, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "病人姓名："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(65, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "住院科室："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(65, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "当前床位："
        '
        'TxtAdNum
        '
        Me.TxtAdNum.Location = New System.Drawing.Point(153, 31)
        Me.TxtAdNum.Name = "TxtAdNum"
        Me.TxtAdNum.Size = New System.Drawing.Size(100, 25)
        Me.TxtAdNum.TabIndex = 4
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(153, 65)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(100, 25)
        Me.TxtName.TabIndex = 5
        '
        'TxtOfi
        '
        Me.TxtOfi.Location = New System.Drawing.Point(153, 100)
        Me.TxtOfi.Name = "TxtOfi"
        Me.TxtOfi.Size = New System.Drawing.Size(100, 25)
        Me.TxtOfi.TabIndex = 6
        '
        'TxtCBedNo
        '
        Me.TxtCBedNo.Location = New System.Drawing.Point(153, 135)
        Me.TxtCBedNo.Name = "TxtCBedNo"
        Me.TxtCBedNo.Size = New System.Drawing.Size(100, 25)
        Me.TxtCBedNo.TabIndex = 7
        '
        'CmdFind
        '
        Me.CmdFind.Location = New System.Drawing.Point(286, 33)
        Me.CmdFind.Name = "CmdFind"
        Me.CmdFind.Size = New System.Drawing.Size(75, 23)
        Me.CmdFind.TabIndex = 8
        Me.CmdFind.Text = "查询"
        Me.CmdFind.UseVisualStyleBackColor = True
        '
        'CmdEdit
        '
        Me.CmdEdit.Location = New System.Drawing.Point(98, 245)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 9
        Me.CmdEdit.Text = "修改"
        Me.CmdEdit.UseVisualStyleBackColor = True
        '
        'CmdExit
        '
        Me.CmdExit.Location = New System.Drawing.Point(222, 245)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(75, 23)
        Me.CmdExit.TabIndex = 10
        Me.CmdExit.Text = "退出"
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'TxtTBedNo
        '
        Me.TxtTBedNo.Location = New System.Drawing.Point(153, 171)
        Me.TxtTBedNo.Name = "TxtTBedNo"
        Me.TxtTBedNo.Size = New System.Drawing.Size(100, 25)
        Me.TxtTBedNo.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(65, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 15)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "更换床位："
        '
        'FrmMoveBed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 315)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtTBedNo)
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdFind)
        Me.Controls.Add(Me.TxtCBedNo)
        Me.Controls.Add(Me.TxtOfi)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.TxtAdNum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "FrmMoveBed"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "换床位"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtAdNum As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents TxtOfi As TextBox
    Friend WithEvents TxtCBedNo As TextBox
    Friend WithEvents CmdFind As Button
    Friend WithEvents CmdEdit As Button
    Friend WithEvents CmdExit As Button
    Friend WithEvents TxtTBedNo As TextBox
    Friend WithEvents Label5 As Label
End Class
