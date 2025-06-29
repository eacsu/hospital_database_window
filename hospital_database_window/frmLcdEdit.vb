Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient
Public Class frmLcdEdit
    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Main()

    End Sub
    Private Sub SetHeadTitle()
        '设置每列的标题
        dGrdP.Columns(0).HeaderText = "药品编号"
        dGrdP.Columns(1).HeaderText = "药品名称"
        dGrdP.Columns(2).HeaderText = "规格"
        dGrdP.Columns(3).HeaderText = "类型"
        dGrdP.Columns(4).HeaderText = "价格"
        dGrdP.Columns(5).HeaderText = "有效期"
        dGrdP.ColumnHeadersHeight = 28
        Dim i As Integer
        For i = 0 To 5
            dGrdP.Columns(i).Width = 90
        Next

    End Sub
    Private Sub frmLcdEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim da As SqlDataAdapter = Nothing
        Dim dt As DataTable
        dt = SQLQRY("Select * from Leechdom", da)
        dGrdP.DataSource = dt
        SetHeadTitle()
    End Sub

    Private Sub cmdFind_Click(sender As Object, e As EventArgs) Handles cmdFind.Click
        Dim sqlcmd As String
        If OptPNo.Checked = False And OptPName.Checked = False And OptAll.Checked = False Then
            MsgBox("请输入要查询的方式！", vbOKOnly, "提示")
        End If
        If OptPNo.Checked = True Then
            If txtPNo.Text = "" Then
                MsgBox("请输入药品编号！", vbOKOnly, "提示")
                txtPNo.Focus()
            End If
            sqlcmd = "select * from Leechdom Where Leechdom_ID='" & txtPNo.Text & "'"
        End If

        If OptPName.Checked = True Then
            If txtPName.Text = "" Then
                MsgBox("请输入药品名称！", vbOKOnly, "提示")
                txtPName.Focus()
            End If
            sqlcmd = "select * from Leechdom Where Name='" & txtPName.Text & "'"
        End If

        If OptAll.Checked = True Then
            sqlcmd = "select * from Leechdom"
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

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        Dim sqlcmd As String
        Dim dt As DataTable
        Dim LcdID As String
        '以下代码为没有记录或没有选中记录的处理方法
        LcdID = dGrdP.CurrentRow.Cells("Leechdom_ID").Value.ToString()
        If String.IsNullOrEmpty(LcdID) Then
            MsgBox("没有被选中的记录！", vbOKOnly, "提示")
            Exit Sub
        End If
        sqlcmd = "select * from Leechdom Where Leechdom_ID='" & LcdID & "'"
        dt = SQLQRY(sqlcmd, Nothing)
        If dt.Rows.Count = 0 Then
            MsgBox("找不到药品资料"， vbOKOnly, "提示")
            Exit Sub
        End If

        frmLcdRecord.Text = "药品信息修改" '修改窗体标题
        frmLcdRecord.LcdID.Text = LcdID
        frmLcdRecord.LcdName.Text = dt.Rows(0).Item("Name")
        frmLcdRecord.LcdClass.Text = dt.Rows(0).Item("Specs")
        frmLcdRecord.LcdSpecs.Text = dt.Rows(0).Item("Class")
        frmLcdRecord.Lcdprice.Text = dt.Rows(0).Item("Price")
        frmLcdRecord.LcdDate.Text = dt.Rows(0).Item("Validity_Date")


        frmLcdRecord.LcdID.Enabled = False
        frmLcdRecord.LcdSpecs.Enabled = False


        frmLcdRecord.ShowDialog()
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        Dim LcdID As String
        Dim sqlcmd As String
        '获得当前选择记录的药品编号
        LcdID = dGrdP.CurrentRow.Cells("Leechdom_ID").Value.ToString()
        If String.IsNullOrEmpty(LcdID) Then
            MsgBox("没有被选中的记录！", vbOKOnly, "提示")
            Exit Sub
        End If
        If MsgBox("是否确定需要删除药品档案?", vbYesNo + vbQuestion + vbDefaultButton2, "提示") = vbYes Then
            sqlcmd = "Delete from Leechdom Where Leechdom_ID='" & LcdID & "'"
            SQLDML(sqlcmd)
            MsgBox("已删除该记录！", vbOKOnly, "提示")
            '利用窗体载入时的事件重新载入数据刷新显示
            frmLcdEdit_Load(Me, New EventArgs())
        End If
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub


End Class