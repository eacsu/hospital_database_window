Public Class frmLogin
    Sub New()
        InitializeComponent()
        Main()
    End Sub
    ' 显示主窗体
    Dim mainForm As New MDIParent1()

    ' "确定"按钮事件 cmdOK_Click
    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim dt As DataTable ' 返回查询数据表对象
        Dim sqlcmd As String ' 用于存放查询用户名和密码的SQL语句
        Dim username As String ' 存放输入的用户名
        Dim password As String ' 存放输入的用户密码

        username = Trim(txtUser.Text)
        password = Trim(txtPassw.Text)

        If username = "" Then
            MsgBox("请输入用户名")
            txtUser.Focus()
            Exit Sub
        End If

        sqlcmd = "SELECT * FROM LoginUser WHERE login_name='" & username & "'"
        dt = SQLQRY(sqlcmd, Nothing)

        If dt.Rows.Count = 0 Then
            MsgBox("输入的用户名不对，请重新输入", vbOKOnly, "提示")
            txtUser.Focus()
            Exit Sub
        End If

        ' 比较数据表字段：Rows(0)表示第1条记录
        If Trim(dt.Rows(0).Item("Login_Passw")) <> password Then
            MsgBox("输入的密码不对，请重新输入", vbOKOnly, "提示")
            txtPassw.Focus()
            Exit Sub
        End If

        ' 用户名和密码都正确
        CurUserName = username ' 记录当前的用户名
        CurUserType = dt.Rows(0).Item("User_Type") ' 记录当前的用户类型
        IsLogin = True
        mainForm.state.Text = "当前用户：" & CurUserName & "，用户类型：" & CurUserType ' 更新主窗体状态栏"
        MsgBox("登陆成功！", vbOKOnly, "提示")
        txtPassw.Focus()

        ' 隐藏登录窗体（不是关闭）
        Me.Hide()

        ' 显示主窗体

        mainForm.Show() ' 主窗体显示后，登录窗体保持隐藏
    End Sub

    ' "退出"按钮事件 cmdExit_Click
    'Private Sub cmdExit_Click(sender As Object, e As EventArgs)
    '    Hide()

    '    ' 显示主窗体

    '    mainForm.Show() ' 主窗体显示后，登录窗体保持隐藏
    'End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Hide()

        ' 显示主窗体

        mainForm.Show() ' 主窗体显示后，登录窗体保持隐藏
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtUser_TextChanged(sender As Object, e As EventArgs) Handles txtUser.TextChanged

    End Sub
End Class