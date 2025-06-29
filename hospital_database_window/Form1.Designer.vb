<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Label1 = New Label()
        Label2 = New Label()
        txtUser = New TextBox()
        txtPassw = New TextBox()
        cmdOK = New Button()
        cmdExit = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(159, 102)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(56, 17)
        Label1.TabIndex = 0
        Label1.Text = "用户名："
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(159, 147)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(60, 17)
        Label2.TabIndex = 1
        Label2.Text = "密  码  ："
        ' 
        ' txtUser
        ' 
        txtUser.Location = New Point(251, 102)
        txtUser.Margin = New Padding(2, 3, 2, 3)
        txtUser.Name = "txtUser"
        txtUser.Size = New Size(98, 23)
        txtUser.TabIndex = 2
        txtUser.Text = "admin"
        ' 
        ' txtPassw
        ' 
        txtPassw.Location = New Point(251, 141)
        txtPassw.Margin = New Padding(2, 3, 2, 3)
        txtPassw.Name = "txtPassw"
        txtPassw.PasswordChar = "*"c
        txtPassw.Size = New Size(98, 23)
        txtPassw.TabIndex = 3
        txtPassw.Text = "123456"
        ' 
        ' cmdOK
        ' 
        cmdOK.Location = New Point(184, 196)
        cmdOK.Margin = New Padding(2, 3, 2, 3)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New Size(73, 25)
        cmdOK.TabIndex = 4
        cmdOK.Text = "确认"
        cmdOK.UseVisualStyleBackColor = True
        ' 
        ' cmdExit
        ' 
        cmdExit.Location = New Point(285, 196)
        cmdExit.Margin = New Padding(2, 3, 2, 3)
        cmdExit.Name = "cmdExit"
        cmdExit.Size = New Size(73, 25)
        cmdExit.TabIndex = 5
        cmdExit.Text = "退出"
        cmdExit.UseVisualStyleBackColor = True
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(622, 382)
        Controls.Add(cmdExit)
        Controls.Add(cmdOK)
        Controls.Add(txtPassw)
        Controls.Add(txtUser)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Margin = New Padding(2, 3, 2, 3)
        Name = "frmLogin"
        Text = "登录"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtPassw As TextBox
    Friend WithEvents cmdOK As Button
    Friend WithEvents cmdExit As Button
End Class
