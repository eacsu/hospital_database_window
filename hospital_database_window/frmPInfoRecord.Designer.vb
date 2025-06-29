Imports Microsoft.Data.SqlClient

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPInfoRecord
    Inherits System.Windows.Forms.Form
    Private isModify As Boolean = False '标志是否为修改操作
    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '初始化入院日期为入院当天的日期
    Private Sub frmPInfoRecord_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        CboDate.Value = Now
    End Sub
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        Dim da As SqlDataAdapter
        Dim dt As DataTable
        Dim dr As DataRow
        Dim sqlcmd As String

        ' 验证必填字段
        If txtAdNum.Text = "" Or txtName.Text = "" Or txtAge.Text = "" Or txtInDept.Text = "" Or txtAdPay.Text = "" Then
            MsgBox("请输入此项目的数据!", vbExclamation, "提示")
            Exit Sub
        End If

        ' 验证性别选择
        If CboSex.Text = "" Then
            MsgBox("请选择病人性别!", vbExclamation, "提示")
            CboSex.Focus()
            Exit Sub
        End If

        ' 验证年龄和预付款是否为数字
        If Not IsNumeric(txtAge.Text) Then
            MsgBox("请输入有效的年龄!", vbExclamation, "提示")
            txtAge.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtAdPay.Text) Then
            MsgBox("请输入有效的预付款!", vbExclamation, "提示")
            txtAdPay.Focus()
            Exit Sub
        End If

        ' 查询数据库检查住院号是否已存在
        sqlcmd = "SELECT * FROM Patient WHERE Patient_ID='" & Trim(txtAdNum.Text) & "'"
        da = Nothing
        dt = SQLQRY(sqlcmd, da)

        ' 新增记录时检查住院号是否重复
        If txtAdNum.Enabled = True Then
            If dt.Rows.Count > 0 Then
                MsgBox("住院号重复，请重新输入!", vbOKOnly, "提示")
                txtAdNum.Focus()
                Exit Sub
            End If
            isModify = False
            dr = dt.NewRow()
            da.InsertCommand = New SqlCommandBuilder(da).GetInsertCommand()
        Else
            ' 修改记录
            isModify = True
            dr = dt.Rows(0)
            da.UpdateCommand = New SqlCommandBuilder(da).GetUpdateCommand()
        End If

        ' 设置记录字段值
        dr("Patient_ID") = Trim(txtAdNum.Text) '住院号
        dr("Name") = Trim(txtName.Text) '姓名
        dr("Sex") = Trim(CboSex.Text) '性别
        dr("Age") = Trim(txtAge.Text) '年龄
        dr("Native_Place") = Trim(txtOrigin.Text) '籍贯
        dr("Nation") = Trim(txtVolk.Text) '民族
        dr("Consultation_Office") = Trim(txtInDept.Text) '入院科室
        dr("Bed_No") = Trim(txtBedNo.Text) '床位号
        dr("Charge_Doctor") = Trim(txtDoctor.Text) '主治医生
        dr("InCome_Time") = CboDate.Value.ToString("yyyy-MM-dd") '入院日期
        dr("Total_Prefee") = Trim(txtAdPay.Text) '预付款

        ' 新增记录时添加到数据表
        If Not isModify Then
            dt.Rows.Add(dr)
        End If

        ' 更新数据库
        da.Update(dt)
        MsgBox("住院登记或修改记录成功!", vbOKOnly, "提示")
    End Sub
    Private Sub cmdRetry_Click(sender As System.Object, e As System.EventArgs) Handles cmdRetry.Click
        Dim i As Integer
        ' 遍历窗体上所有控件
        For i = 0 To Me.Controls.Count - 1
            ' 清空所有以"txt"开头的文本框控件
            If Me.Controls(i).Name.StartsWith("txt") Then
                Me.Controls(i).Text = ""
            End If
        Next i

        ' 重置其他控件
        CboSex.Text = ""          ' 清空性别选择框
        CboDate.Value = Now       ' 设置日期为当前日期
        txtAdNum.Focus()          ' 将焦点设置到住院号输入框
    End Sub


    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Me.Close()      ' 关闭窗体
        Me.Dispose()    ' 释放窗体资源
    End Sub




    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        AdNuma = New Label()
        Label2 = New Label()
        Origina = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Name1 = New Label()
        Agea = New Label()
        Label9 = New Label()
        Label10 = New Label()
        AdPaya = New Label()
        txtAdNum = New TextBox()
        txtInDept = New TextBox()
        txtAdPay = New TextBox()
        txtDoctor = New TextBox()
        txtVolk = New TextBox()
        txtAge = New TextBox()
        txtName = New TextBox()
        txtBedNo = New TextBox()
        txtOrigin = New TextBox()
        CboSex = New ComboBox()
        CboDate = New DateTimePicker()
        cmdOK = New Button()
        cmdRetry = New Button()
        cmdExit = New Button()
        SuspendLayout()
        ' 
        ' AdNuma
        ' 
        AdNuma.AutoSize = True
        AdNuma.Location = New Point(82, 40)
        AdNuma.Name = "AdNuma"
        AdNuma.Size = New Size(56, 17)
        AdNuma.TabIndex = 0
        AdNuma.Text = "住院号："
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(82, 84)
        Label2.Name = "Label2"
        Label2.Size = New Size(44, 17)
        Label2.TabIndex = 1
        Label2.Text = "性别："
        ' 
        ' Origina
        ' 
        Origina.AutoSize = True
        Origina.Location = New Point(82, 135)
        Origina.Name = "Origina"
        Origina.Size = New Size(44, 17)
        Origina.TabIndex = 2
        Origina.Text = "籍贯："
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(82, 178)
        Label4.Name = "Label4"
        Label4.Size = New Size(68, 17)
        Label4.TabIndex = 3
        Label4.Text = "住院科室："
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(82, 223)
        Label5.Name = "Label5"
        Label5.Size = New Size(56, 17)
        Label5.TabIndex = 4
        Label5.Text = "床位号："
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(82, 262)
        Label6.Name = "Label6"
        Label6.Size = New Size(68, 17)
        Label6.TabIndex = 5
        Label6.Text = "入院时间："
        ' 
        ' Name1
        ' 
        Name1.AutoSize = True
        Name1.Location = New Point(435, 40)
        Name1.Name = "Name1"
        Name1.Size = New Size(68, 17)
        Name1.TabIndex = 6
        Name1.Text = "病人姓名："
        ' 
        ' Agea
        ' 
        Agea.AutoSize = True
        Agea.Location = New Point(435, 84)
        Agea.Name = "Agea"
        Agea.Size = New Size(44, 17)
        Agea.TabIndex = 7
        Agea.Text = "年龄："
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(435, 135)
        Label9.Name = "Label9"
        Label9.Size = New Size(44, 17)
        Label9.TabIndex = 8
        Label9.Text = "民族："
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(435, 223)
        Label10.Name = "Label10"
        Label10.Size = New Size(68, 17)
        Label10.TabIndex = 9
        Label10.Text = "主治医生："
        ' 
        ' AdPaya
        ' 
        AdPaya.AutoSize = True
        AdPaya.Location = New Point(435, 262)
        AdPaya.Name = "AdPaya"
        AdPaya.Size = New Size(56, 17)
        AdPaya.TabIndex = 10
        AdPaya.Text = "预付款："
        ' 
        ' txtAdNum
        ' 
        txtAdNum.Location = New Point(161, 41)
        txtAdNum.Name = "txtAdNum"
        txtAdNum.Size = New Size(100, 23)
        txtAdNum.TabIndex = 11
        ' 
        ' txtInDept
        ' 
        txtInDept.Location = New Point(161, 172)
        txtInDept.Name = "txtInDept"
        txtInDept.Size = New Size(443, 23)
        txtInDept.TabIndex = 12
        ' 
        ' txtAdPay
        ' 
        txtAdPay.Location = New Point(504, 262)
        txtAdPay.Name = "txtAdPay"
        txtAdPay.Size = New Size(100, 23)
        txtAdPay.TabIndex = 13
        ' 
        ' txtDoctor
        ' 
        txtDoctor.Location = New Point(504, 220)
        txtDoctor.Name = "txtDoctor"
        txtDoctor.Size = New Size(100, 23)
        txtDoctor.TabIndex = 14
        ' 
        ' txtVolk
        ' 
        txtVolk.Location = New Point(504, 129)
        txtVolk.Name = "txtVolk"
        txtVolk.Size = New Size(100, 23)
        txtVolk.TabIndex = 15
        ' 
        ' txtAge
        ' 
        txtAge.Location = New Point(504, 81)
        txtAge.Name = "txtAge"
        txtAge.Size = New Size(100, 23)
        txtAge.TabIndex = 16
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(504, 41)
        txtName.Name = "txtName"
        txtName.Size = New Size(100, 23)
        txtName.TabIndex = 17
        ' 
        ' txtBedNo
        ' 
        txtBedNo.Location = New Point(161, 220)
        txtBedNo.Name = "txtBedNo"
        txtBedNo.Size = New Size(100, 23)
        txtBedNo.TabIndex = 18
        ' 
        ' txtOrigin
        ' 
        txtOrigin.Location = New Point(161, 129)
        txtOrigin.Name = "txtOrigin"
        txtOrigin.Size = New Size(100, 23)
        txtOrigin.TabIndex = 19
        ' 
        ' CboSex
        ' 
        CboSex.DisplayMember = "男"
        CboSex.FormattingEnabled = True
        CboSex.Items.AddRange(New Object() {"男", "女"})
        CboSex.Location = New Point(161, 84)
        CboSex.Name = "CboSex"
        CboSex.Size = New Size(121, 25)
        CboSex.TabIndex = 20
        ' 
        ' CboDate
        ' 
        CboDate.Location = New Point(161, 256)
        CboDate.Name = "CboDate"
        CboDate.Size = New Size(200, 23)
        CboDate.TabIndex = 21
        ' 
        ' cmdOK
        ' 
        cmdOK.Location = New Point(221, 349)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New Size(75, 23)
        cmdOK.TabIndex = 22
        cmdOK.Text = "确认"
        cmdOK.UseVisualStyleBackColor = True
        ' 
        ' cmdRetry
        ' 
        cmdRetry.Location = New Point(330, 349)
        cmdRetry.Name = "cmdRetry"
        cmdRetry.Size = New Size(75, 23)
        cmdRetry.TabIndex = 23
        cmdRetry.Text = "重填"
        cmdRetry.UseVisualStyleBackColor = True
        ' 
        ' cmdExit
        ' 
        cmdExit.Location = New Point(428, 349)
        cmdExit.Name = "cmdExit"
        cmdExit.Size = New Size(75, 23)
        cmdExit.TabIndex = 24
        cmdExit.Text = "退出"
        cmdExit.UseVisualStyleBackColor = True
        ' 
        ' frmPInfoRecord
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(cmdExit)
        Controls.Add(cmdRetry)
        Controls.Add(cmdOK)
        Controls.Add(CboDate)
        Controls.Add(CboSex)
        Controls.Add(txtOrigin)
        Controls.Add(txtBedNo)
        Controls.Add(txtName)
        Controls.Add(txtAge)
        Controls.Add(txtVolk)
        Controls.Add(txtDoctor)
        Controls.Add(txtAdPay)
        Controls.Add(txtInDept)
        Controls.Add(txtAdNum)
        Controls.Add(AdPaya)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Agea)
        Controls.Add(Name1)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Origina)
        Controls.Add(Label2)
        Controls.Add(AdNuma)
        Name = "frmPInfoRecord"
        Text = "住院登记"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents AdNuma As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Origina As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Name1 As Label
    Friend WithEvents Agea As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents AdPaya As Label
    Friend WithEvents txtAdNum As TextBox
    Friend WithEvents txtInDept As TextBox
    Friend WithEvents txtAdPay As TextBox
    Friend WithEvents txtDoctor As TextBox
    Friend WithEvents txtVolk As TextBox
    Friend WithEvents txtAge As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtBedNo As TextBox
    Friend WithEvents txtOrigin As TextBox
    Friend WithEvents CboSex As ComboBox
    Friend WithEvents CboDate As DateTimePicker
    Friend WithEvents cmdOK As Button
    Friend WithEvents cmdRetry As Button
    Friend WithEvents cmdExit As Button
End Class
