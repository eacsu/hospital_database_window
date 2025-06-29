Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient
Public Class frmEndCalc
    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Main()
    End Sub
    Private Sub frmEndCalc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DataTable '数据表
        Dim sqlcmd As String
        '清除下拉列表
        CboOfc.Items.Clear()
        CboNo.Items.Clear()

        '添加科室到下拉列表
        sqlcmd = "select distinct Consultation_Office From Patient"
        dt = SQLQRY(sqlcmd, Nothing)
        For i = 0 To dt.Rows.Count - 1
            CboOfc.Items.Add(dt.Rows(i).Item("Consultation_Office"))
        Next
    End Sub

    Private Sub CboOfc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboOfc.SelectedIndexChanged
        Dim dt As DataTable
        Dim sqlcmd As String
        CboNo.Items.Clear()  '清除下拉列表
        txtName.Text = ""   '清楚病人姓名内容
        '以下代码用于添加对应住院科室下的所有住院号到下拉列表
        sqlcmd = "Select Distinct Patient_ID from Patient "
        sqlcmd = sqlcmd & "Where Consultation_Office='" & CboOfc.Text & "'"
        sqlcmd = sqlcmd & "AND Leave_Time IS NULL"  '不含出院病人
        dt = SQLQRY(sqlcmd, Nothing)
        For i = 0 To dt.Rows.Count - 1
            CboNo.Items.Add(dt.Rows(i).Item("Patient_ID"))
        Next
    End Sub

    Private Sub CboNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboNo.SelectedIndexChanged
        Dim dt As DataTable
        Dim sqlcmd As String
        sqlcmd = "select Name from Patient "
        sqlcmd = sqlcmd & "where Patient_ID='" & CboNo.Text & "'"
        dt = SQLQRY(sqlcmd, Nothing)
        If dt.Rows.Count = 0 Then
            MsgBox("没有找到该病人!", vbOKOnly, "提示")
        Else
            txtName.Text = dt.Rows(0).Item("Name").ToString()

        End If
    End Sub

    Private Sub changeBed_Click(sender As Object, e As EventArgs) Handles changeBed.Click
        Dim dt As DataTable
        Dim sqlcmd As String
        Dim da As SqlDataAdapter
        sqlcmd = "Update Patient Set Leave_Time= '" & Now & "'where Patient_ID='" & CboNo.Text & "'"
        dt = SQLQRY(sqlcmd, da)
        MsgBox("成功办理出院",, "提示")
    End Sub
End Class