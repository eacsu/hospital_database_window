Imports Microsoft.Data.SqlClient

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPinfoEdit
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
    Private Sub SetHeadTitle()
        ' 设置每列标题(将英文字段名转为中文显示)
        dGrdp.Columns(0).HeaderText = "住院号"
        dGrdp.Columns(1).HeaderText = "病人姓名"
        dGrdp.Columns(2).HeaderText = "性别"
        dGrdp.Columns(3).HeaderText = "年龄"
        dGrdp.Columns(4).HeaderText = "籍贯"
        dGrdp.Columns(5).HeaderText = "民族"
        dGrdp.Columns(6).HeaderText = "主治医生"
        dGrdp.Columns(7).HeaderText = "住院科室"
        dGrdp.Columns(8).HeaderText = "床位号"
        dGrdp.Columns(9).HeaderText = "入院日期"
        dGrdp.Columns(10).HeaderText = "预付款"

        ' 设置表头高度
        dGrdp.ColumnHeadersHeight = 28

        ' 设置列宽
        Dim i As Integer
        For i = 0 To 10
            dGrdp.Columns(i).Width = 90  ' 前11列统一宽度为90
        Next i

        ' 隐藏出院日期列(第12列)
        dGrdp.Columns(11).Width = 0
    End Sub

    Private Sub frmPInfoEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim da As SqlDataAdapter = Nothing  ' 定义数据适配器变量
        Dim dt As DataTable

        ' 查询所有病人信息
        dt = SQLQRY("SELECT * FROM Patient", da)

        ' 绑定数据到DataGridView控件
        dGrdp.DataSource = dt

        ' 设置表格标题和样式
        SetHeadTitle()
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Dim sqlcmd As String = ""

        ' 验证查询方式选择 - 修正RadioButton检查方式
        If Not OptPNo.Checked And Not OptPName.Checked And Not OptAll.Checked Then
            MsgBox("请输入要查询的方式", vbOKOnly, "提示")
            Exit Sub
        End If

        ' 按住院号查询
        If OptPNo.Checked Then
            If String.IsNullOrEmpty(txtPNo.Text) Then
                MsgBox("请输入住院号", vbOKOnly, "提示")
                txtPNo.Focus() ' 修正为.Focus()方法
                Exit Sub
            End If
            sqlcmd = "SELECT * FROM Patient WHERE Patient_ID='" & txtPNo.Text & "'"
        End If

        ' 按病人姓名查询
        If OptPName.Checked Then
            If String.IsNullOrEmpty(txtPName.Text) Then
                MsgBox("请输入病人姓名", vbOKOnly, "提示")
                txtPName.Focus() ' 修正为.Focus()方法
                Exit Sub
            End If
            sqlcmd = "SELECT * FROM Patient WHERE Name='" & txtPName.Text & "'"
        End If

        ' 查询所有记录
        If OptAll.Checked Then
            sqlcmd = "SELECT * FROM Patient"
        End If

        ' 执行查询
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim dt As DataTable = New DataTable()
        dt = SQLQRY(sqlcmd, da)

        ' 检查查询结果
        If dt.Rows.Count = 0 Then
            MsgBox("查无结果", vbOKOnly, "提示")
            Exit Sub
        End If

        ' 刷新数据显示
        dGrdp.DataSource = dt
        SetHeadTitle()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Dim sqlcmd As String
        Dim dt As DataTable
        Dim PatientID As String

        ' 获取当前选中记录的住院号
        PatientID = dGrdp.CurrentRow.Cells("Patient_ID").Value.ToString()

        ' 验证是否选择了记录
        If String.IsNullOrEmpty(PatientID) Then
            MsgBox("没有被选择的记录!", vbOKOnly, "提示")
            Exit Sub
        End If

        ' 查询选中病人的详细信息
        sqlcmd = "SELECT * FROM Patient WHERE Patient_ID='" & PatientID & "'"
        dt = SQLQRY(sqlcmd, Nothing)

        ' 验证查询结果
        If dt.Rows.Count = 0 Then
            MsgBox("找不到病人资料!", vbOKOnly, "提示")
            Exit Sub
        End If

        ' 检查病人是否已出院
        If dt.Rows(0).Item("Leave_Time") & "" <> "" Then
            MsgBox("该病人已经出院了！", vbOKOnly, "提示")
            Exit Sub
        End If

        ' 打开修改窗体并填充数据
        frmPInfoRecord.Text = "病人住院信息修改"  ' 修改窗体标题
        ' 填充各字段数据
        frmPInfoRecord.txtAdNum.Text = PatientID  ' 住院号
        frmPInfoRecord.txtName.Text = dt.Rows(0).Item("Name")  ' 病人姓名
        frmPInfoRecord.txtAge.Text = dt.Rows(0).Item("Age")  ' 年龄
        frmPInfoRecord.CboSex.Text = dt.Rows(0).Item("Sex")  ' 性别
        frmPInfoRecord.txtOrigin.Text = dt.Rows(0).Item("Native_Place")  ' 籍贯
        frmPInfoRecord.txtVolk.Text = dt.Rows(0).Item("Nation")  ' 民族
        frmPInfoRecord.txtInDept.Text = dt.Rows(0).Item("Consultation_Office")  ' 住院科室
        frmPInfoRecord.txtBedNo.Text = dt.Rows(0).Item("Bed_No")  ' 床位号
        frmPInfoRecord.txtDoctor.Text = dt.Rows(0).Item("Charge_Doctor")  ' 主治医生
        frmPInfoRecord.CboDate.Text = dt.Rows(0).Item("InCome_Time")  ' 入院时间
        frmPInfoRecord.txtAdPay.Text = dt.Rows(0).Item("Total_PreFee")  ' 预付款

        ' 禁用不允许修改的字段
        frmPInfoRecord.txtAdNum.Enabled = False  ' 住院号
        frmPInfoRecord.txtInDept.Enabled = False  ' 住院科室
        frmPInfoRecord.txtBedNo.Enabled = False  ' 床位号
        frmPInfoRecord.txtadpay.Enabled = False  ' 预付款
        frmPInfoRecord.cmdRetry.Enabled = False  ' 禁用重填按钮
        frmPInfoRecord.ShowDialog()
    End Sub


    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim PatientID As String
        Dim sqlcmd As String

        ' 获取当前选中记录的住院号
        PatientID = dGrdp.CurrentRow.Cells("Patient_ID").Value.ToString()

        ' 验证是否选择了记录
        If String.IsNullOrEmpty(PatientID) Then
            MsgBox("没有被选择的记录!", vbOKOnly, "提示")
            Exit Sub
        End If

        ' 确认删除操作
        If MsgBox("是否确实需要删除该病人档案？", vbYesNo + vbQuestion + vbDefaultButton2, "提示") = vbYes Then
            ' 执行删除操作
            sqlcmd = "DELETE FROM Patient WHERE Patient_ID='" & PatientID & "'"
            SQLDML(sqlcmd)  ' 执行删除SQL语句

            MsgBox("已删除该记录!", vbOKOnly, "提示")

            ' 刷新数据列表
            frmPInfoEdit_Load(Me, New EventArgs())
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()      ' 关闭窗体
        Me.Dispose()    ' 释放资源
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        dGrdp = New DataGridView()
        cmdEdit = New Button()
        cmdDelete = New Button()
        cmdExit = New Button()
        cmdFind = New Button()
        txtPNo = New TextBox()
        txtPName = New TextBox()
        OptPNo = New RadioButton()
        OptAll = New RadioButton()
        OptPName = New RadioButton()
        CType(dGrdp, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dGrdp
        ' 
        dGrdp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dGrdp.Location = New Point(12, 60)
        dGrdp.Name = "dGrdp"
        dGrdp.ReadOnly = True
        dGrdp.Size = New Size(723, 333)
        dGrdp.TabIndex = 0
        ' 
        ' cmdEdit
        ' 
        cmdEdit.Location = New Point(217, 415)
        cmdEdit.Name = "cmdEdit"
        cmdEdit.Size = New Size(75, 23)
        cmdEdit.TabIndex = 1
        cmdEdit.Text = "修改"
        cmdEdit.UseVisualStyleBackColor = True
        ' 
        ' cmdDelete
        ' 
        cmdDelete.Location = New Point(312, 415)
        cmdDelete.Name = "cmdDelete"
        cmdDelete.Size = New Size(75, 23)
        cmdDelete.TabIndex = 2
        cmdDelete.Text = "删除"
        cmdDelete.UseVisualStyleBackColor = True
        ' 
        ' cmdExit
        ' 
        cmdExit.Location = New Point(409, 415)
        cmdExit.Name = "cmdExit"
        cmdExit.Size = New Size(75, 23)
        cmdExit.TabIndex = 3
        cmdExit.Text = "退出"
        cmdExit.UseVisualStyleBackColor = True
        ' 
        ' cmdFind
        ' 
        cmdFind.Location = New Point(577, 27)
        cmdFind.Name = "cmdFind"
        cmdFind.Size = New Size(75, 23)
        cmdFind.TabIndex = 4
        cmdFind.Text = "查询"
        cmdFind.UseVisualStyleBackColor = True
        ' 
        ' txtPNo
        ' 
        txtPNo.Location = New Point(123, 28)
        txtPNo.Name = "txtPNo"
        txtPNo.Size = New Size(100, 23)
        txtPNo.TabIndex = 5
        ' 
        ' txtPName
        ' 
        txtPName.Location = New Point(356, 28)
        txtPName.Name = "txtPName"
        txtPName.Size = New Size(100, 23)
        txtPName.TabIndex = 6
        ' 
        ' OptPNo
        ' 
        OptPNo.AutoSize = True
        OptPNo.Location = New Point(55, 27)
        OptPNo.Name = "OptPNo"
        OptPNo.Size = New Size(62, 21)
        OptPNo.TabIndex = 7
        OptPNo.TabStop = True
        OptPNo.Text = "住院号"
        OptPNo.UseVisualStyleBackColor = True
        ' 
        ' OptAll
        ' 
        OptAll.AutoSize = True
        OptAll.Location = New Point(489, 29)
        OptAll.Name = "OptAll"
        OptAll.Size = New Size(50, 21)
        OptAll.TabIndex = 8
        OptAll.TabStop = True
        OptAll.Text = "全部"
        OptAll.UseVisualStyleBackColor = True
        ' 
        ' OptPName
        ' 
        OptPName.AutoSize = True
        OptPName.Location = New Point(287, 28)
        OptPName.Name = "OptPName"
        OptPName.Size = New Size(74, 21)
        OptPName.TabIndex = 9
        OptPName.TabStop = True
        OptPName.Text = "病人姓名"
        OptPName.UseVisualStyleBackColor = True
        ' 
        ' frmPinfoEdit
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(746, 450)
        Controls.Add(OptPName)
        Controls.Add(OptAll)
        Controls.Add(OptPNo)
        Controls.Add(txtPName)
        Controls.Add(txtPNo)
        Controls.Add(cmdFind)
        Controls.Add(cmdExit)
        Controls.Add(cmdDelete)
        Controls.Add(cmdEdit)
        Controls.Add(dGrdp)
        Name = "frmPinfoEdit"
        Text = "病人档案维护"
        CType(dGrdp, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dGrdp As DataGridView
    Friend WithEvents cmdEdit As Button
    Friend WithEvents cmdDelete As Button
    Friend WithEvents cmdExit As Button
    Friend WithEvents cmdFind As Button
    Friend WithEvents txtPNo As TextBox
    Friend WithEvents txtPName As TextBox
    Friend WithEvents OptPNo As RadioButton
    Friend WithEvents OptAll As RadioButton
    Friend WithEvents OptPName As RadioButton
End Class
