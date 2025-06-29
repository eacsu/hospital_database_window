Public Class frmUser
    Sub New()
        InitializeComponent()
        Main()  ' 初始化界面布局
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = Trim(TextBox1.Text)
        Dim password As String = Trim(TextBox2.Text)
        Dim confirmPassword As String = Trim(TextBox3.Text)
        If String.IsNullOrEmpty(username) Then
            MsgBox("请输入用户名", vbExclamation, "提示")
            TextBox1.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(password) Then
            MsgBox("请输入密码", vbExclamation, "提示")
            TextBox2.Focus()
            Exit Sub
        End If
        If password <> confirmPassword Then
            MsgBox("两次输入的密码不一致", vbExclamation, "提示")
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox3.Focus()
            Exit Sub
        End If
        Dim checkSql As String = $"SELECT COUNT(*) FROM LoginUser WHERE login_name='{username}'"
        Dim userExists As Integer = Convert.ToInt32(SQLQRY(checkSql, Nothing).Rows(0)(0))
        If userExists > 0 Then
            MsgBox("该用户名已存在，请使用其他用户名", vbExclamation, "提示")
            TextBox1.Clear()
            TextBox1.Focus()
            Exit Sub
        End If
        Dim insertSql As String = $"INSERT INTO LoginUser (login_name, Login_Passw, User_Type) VALUES ('{username}', '{password}', 1)"
        Try
            SQLQRY(insertSql, Nothing)
            MsgBox("用户创建成功!", vbInformation, "提示")
            Me.Close()
        Catch ex As Exception
            MsgBox($"创建用户失败: {ex.Message}", vbCritical, "错误")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class