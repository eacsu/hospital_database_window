Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.Data.SqlClient

Public Class frmCuredItemEdit
    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Main()

    End Sub
    Private Sub frmCuredItemEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim da As SqlDataAdapter = Nothing
        Dim dt As DataTable
        dt = SQLQRY("Select * from CuredItem", da)
        dGrdP.DataSource = dt
        SetHeadTitle()
    End Sub
    Private Sub SetHeadTitle()
        '设置每列的标题
        dGrdP.Columns(0).HeaderText = "项目编号"
        dGrdP.Columns(1).HeaderText = "项目名称"

        dGrdP.Columns(2).HeaderText = "类型"
        dGrdP.Columns(3).HeaderText = "价格"

        dGrdP.ColumnHeadersHeight = 28
        Dim i As Integer
        For i = 0 To 3
            dGrdP.Columns(i).Width = 90
        Next

    End Sub
    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click


        Dim sqlcmd As String
        Dim dt As DataTable
        Dim ItemID As String
        '以下代码为没有记录或没有选中记录的处理方法
        ItemID = dGrdP.CurrentRow.Cells("Item_ID").Value.ToString()
        If String.IsNullOrEmpty(ItemID) Then
            MsgBox("没有被选中的记录！", vbOKOnly, "提示")
            Exit Sub
        End If
        sqlcmd = "select * from CuredItem Where Item_ID='" & ItemID & "'"
        dt = SQLQRY(sqlcmd, Nothing)
        If dt.Rows.Count = 0 Then
            MsgBox("找不到项目资料"， vbOKOnly, "提示")
            Exit Sub
        End If

        frmCuredItemRecord.Text = "项目信息修改" '修改窗体标题
        frmCuredItemRecord.ItemID.Text = ItemID
        frmCuredItemRecord.ItemName.Text = dt.Rows(0).Item("Name")
        frmCuredItemRecord.ItemClass.Text = dt.Rows(0).Item("Class")
        frmCuredItemRecord.ItemPrice.Text = dt.Rows(0).Item("Fee")

        frmCuredItemRecord.ItemID.Enabled = False

        frmCuredItemRecord.ShowDialog()
    End Sub

    Private Sub cmdFind_Click(sender As Object, e As EventArgs) Handles cmdFind.Click
        Dim sqlcmd As String
        If OptPNo.Checked = False And OptPName.Checked = False And OptAll.Checked = False Then
            MsgBox("请输入要查询的方式！", vbOKOnly, "提示")
        End If
        If OptPNo.Checked = True Then
            If txtPNo.Text = "" Then
                MsgBox("请输入项目编号！", vbOKOnly, "提示")
                txtPNo.Focus()
            End If
            sqlcmd = "select * from CuredItem Where Item_ID='" & txtPNo.Text & "'"
        End If

        If OptPName.Checked = True Then
            If txtPName.Text = "" Then
                MsgBox("请输入项目名称！", vbOKOnly, "提示")
                txtPName.Focus()
            End If
            sqlcmd = "select * from CuredItem Where Name='" & txtPName.Text & "'"
        End If

        If OptAll.Checked = True Then
            sqlcmd = "select * from CuredItem"
        End If

        '以下定义数据适配器da和数据表dt
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim dt As DataTable = New DataTable()
        dt = SQLQRY(sqlcmd, da)
        If dt.Rows.Count = 0 Then
            MsgBox("查无结果！", vbOKOnly, "提示")
            Exit Sub
        End If
        dGrdP.DataSource = dt
        SetHeadTitle()
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class