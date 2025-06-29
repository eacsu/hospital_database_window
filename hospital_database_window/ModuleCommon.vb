'Imports System.Data
'Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient
Module ModuleCommon
    '定义全局变量
    Public CurUserName As String
    Public CurUserType As String
    Public IsLogin As Boolean
    Public DBConnectionString As String

    '定义模块内部变量
    Private IsConnected As Boolean
    Private conn As SqlConnection

    'Main过程作为登录窗体frmLogin首次被调用的过程，完成整个应用的初始化
    Public Sub Main()
        '使用SQL Server 2008身份验证模式登录
        '设置数据库连接串，其中用户名/密码应设置为实际环境下的值
        'DBConnectionString = "server=(local);database=hosp;Integrated Security=True"
        DBConnectionString = "server=DESKTOP-V63GESV\SQL;database=hosp;Integrated Security=True;TrustServerCertificate=True"
        If DBConnect() = False Then
            End
        End If


    End Sub

    '定义连接到数据库系统的全局函数
    Public Function DBConnect() As Boolean
        If IsConnected = True Then
            Return True
        End If

        On Error GoTo sql_error
        conn = New SqlConnection()
        '设置数据库的连接字符串
        conn.ConnectionString = DBConnectionString
        conn.Open()
        IsConnected = True    '更改已连接标志
        DBConnect = True
        Exit Function

sql_error:
        'Console.WriteLine("数据库连接失败：" & Err.Description)
        MsgBox("数据库连接失败：" & Err.Description, vbOKOnly, "提示")

        On Error Resume Next    '恢复错误
        DBConnect = False
    End Function

    '断开与数据库的连接
    Public Sub DBDisConnect()
        If IsConnected = False Then    '还未连接，不需处理
            Exit Sub
        Else
            conn.Close()    '关闭连接
            conn = Nothing    '释放资源
            IsConnected = False
        End If
    End Sub

    '执行SQL-DML语句操作，如INSERT、UPDATE、DELETE等，没有返回结果
    Public Sub SQLDML(ByVal SQL_DMLStr As String)
        Dim cmd As New SqlCommand()    '创建Command对象
        On Error GoTo sql_error    '定义错误捕获
        DBConnect()    '调用连接过程，连接数据库
        cmd.Connection = conn    '设置cmd的Connection属性
        cmd.CommandText = SQL_DMLStr    '设置需要执行的增、删、改语句
        cmd.ExecuteNonQuery()    '执行增、删、改（DML）命令

sql_exit:
        On Error Resume Next
        cmd = Nothing    '释放资源
        DBDisConnect()
        Exit Sub

sql_error:
        MsgBox("数据库更新操作失败：" & Err.Description, vbOKOnly, "提示")
        Resume sql_exit
    End Sub

    '执行SQL-SELECT语句操作，并返回数据查询记录集
    Public Function SQLQRY(ByVal SQL_QRYStr As String, ByRef sqlAdap As SqlDataAdapter) As DataTable
        Dim dt As New DataTable()    '声明数据表对象dt
        On Error GoTo sql_error
        DBConnect()    '调用连接过程，连接数据库
        Dim da As New SqlDataAdapter()    '声明SqlDataAdapter对象da
        da.SelectCommand = New SqlCommand()    '设置SelectCommand属性为SqlCommand
        da.SelectCommand.Connection = conn    '设置连接对象
        da.SelectCommand.CommandText = SQL_QRYStr    '设置SQL命令
        da.SelectCommand.CommandType = CommandType.Text '指定查询对象的类型
        da.Fill(dt)    '调用Fill方法，从数据源读取数据
        SQLQRY = dt    '返回数据表
        sqlAdap = da

sql_exit:
        On Error Resume Next
        dt = Nothing
        Exit Function

sql_error:
        MsgBox("数据库查询操作失败：" & Err.Description, vbOKOnly, "提示")
        Resume sql_exit
    End Function

    '打开MDI子窗体
    Public Sub showMDIChildForm(ByVal frm As Form, ByVal mainForm As Form)
        frm.MdiParent = mainForm
        frm.TopLevel = False
        frm.BringToFront()
        frm.TopMost = True
        frm.Show()
    End Sub
End Module
