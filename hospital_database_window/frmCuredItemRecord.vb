Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient
Public Class frmCuredItemRecord
    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Main()

    End Sub
    Private Sub frmCuredItemRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim da As SqlDataAdapter   '定义da为数据适配器变量
        Dim dt As DataTable ' = New DataTable()   '返回dt查询表对象

        Dim sqlcmd As String '查询字符串变量

        '以下验证是否输入数据
        If ItemID.Text = "" Or ItemName.Text = "" Or ItemClass.Text = "" Or ItemClass.Text = "" Then
            MsgBox("请输入项目数据！", vbExclamation, "提示")
            Exit Sub
        End If


        '以下产生查询记录集，为新增记录和修改记录做准备
        sqlcmd = "Select* FROM Leechdom WHERE Leechdom_ID='"
        sqlcmd = sqlcmd & Trim(ItemID.Text) & "'"

        '执行查询，返回数据表对象dt,通过地址传递返回数据适配器da
        da = Nothing
        dt = SQLQRY(sqlcmd, da)

        If ItemID.Enabled = True Then
            If dt.Rows.Count > 0 Then
                MsgBox("项目编号重复！", vbOKOnly, "提示")
                ItemID.Focus()
                Exit Sub
            End If
            '住院号不重复则添加记录    

            '为适配器新增记录，准备插入语句
            sqlcmd = "insert into CuredItem(Item_ID,Name,Class,Fee) values ('" & Trim(ItemID.Text) & "','" & Trim(ItemName.Text) & "','" & Trim(ItemClass.Text) & "','" & Trim(ItemPrice.Text) & "')"

        Else
            '修改记录

            '为适配器更新记录，准备更新语句
            sqlcmd = "update CuredItem Set Name='" & Trim(ItemName.Text) & "',Class='" & Trim(ItemClass.Text) & "',Price='" & Trim(ItemPrice.Text) & "' where Item_ID='" & Trim(ItemID.Text) & "'"
        End If
        dt = SQLQRY(sqlcmd, da)


    End Sub

    Private Sub cmdRetry_Click(sender As Object, e As EventArgs) Handles cmdRetry.Click
        Dim i As Integer
        For i = 0 To Me.Controls.Count - 1
            If Me.Controls(i).Name.StartsWith("Item") Then
                Me.Controls(i).Text = ""
            End If
        Next
        ItemClass.Text = ""
        ItemID.Focus()
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class