Public Class frmChPw

    Sub New()
        InitializeComponent()
        Main()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = Trim(TextBox1.Text)
        Dim oldPassword As String = Trim(TextBox3.Text)
        Dim newPassword As String = Trim(TextBox2.Text)
        If String.IsNullOrEmpty(username) Then
            MsgBox("请输入用户名", vbExclamation, "提示")
            TextBox1.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(oldPassword) Then
            MsgBox("请输入原密码", vbExclamation, "提示")
            TextBox3.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(newPassword) Then
            MsgBox("请输入新密码", vbExclamation, "提示")
            TextBox2.Focus()
            Exit Sub
        End If

        ' 从数据库验证原密码 (假设 CurUserName 是当前登录用户名) 
        Dim dt As DataTable
        Dim sqlcmd As String
        sqlcmd = "SELECT*FROM LoginUser WHERE Login_Name='" & username & "'"
        dt = SQLQRY(sqlcmd, Nothing)
        If dt.Rows.Count = 0 Then
            MsgBox("输入的用户名或密码不对，请重新输入"， vbOKOnly, "提示")
            TextBox1.Clear()
            TextBox3.Clear()
            TextBox1.Focus()
            Exit Sub
        End If
        If Trim(dt.Rows(0).Item("Login_Passw")) <> oldPassword Then
            MsgBox("输入的用户名或密码不对，请重新输入"， vbOKOnly, "提示")
            TextBox1.Clear()
            TextBox3.Clear()
            TextBox1.Focus()
            Exit Sub
        End If
        ' 更新密码到数据库
        Dim sqlUpdate As String = $"UPDATE LoginUser SET Login_Passw='{newPassword}' WHERE Login_Name='{CurUserName}'"

        Try
            SQLQRY(sqlUpdate, Nothing)
            MsgBox("密码修改成功!", vbInformation, "提示")
            Me.Close()
        Catch ex As Exception
            MsgBox($"密码修改失败: {ex.Message}", vbCritical, "错误")
        End Try
    End Sub

    ' 取消按钮事件
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class