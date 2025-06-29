Imports Microsoft.Data.SqlClient

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPreFeeRecord
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


    Private Sub frmPreFeeRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        Dim sqlcmd As String

        '初始化下拉列表
        CboOfc.Items.Clear()
        CboNo.Items.Clear()

        '加载住院科室数据
        sqlcmd = "SELECT DISTINCT Consultation_Office FROM Patient"
        dt = SQLQRY(sqlcmd, Nothing)
        For i = 0 To dt.Rows.Count - 1
            CboOfc.Items.Add(dt.Rows(i).Item("Consultation_Office"))
        Next
    End Sub


    Private Sub CboOfc_SelectedIndexChanged(sender As System.Object, ByVal e As System.EventArgs) Handles CboOfc.SelectedIndexChanged
        Dim dt As DataTable
        Dim sqlcmd As String

        '清除原有数据
        CboNo.Items.Clear()
        txtName.Text = ""

        '加载对应科室的住院号
        sqlcmd = "SELECT DISTINCT Patient_ID FROM Patient " &
             "WHERE Consultation_Office='" & CboOfc.Text & "' " &
             "AND Leave_Time IS NULL"  '只包含未出院病人

        dt = SQLQRY(sqlcmd, Nothing)
        For i = 0 To dt.Rows.Count - 1
            CboNo.Items.Add(dt.Rows(i).Item("Patient_ID"))
        Next
    End Sub

    Private Sub CboNo_SelectedIndexChanged(sender As System.Object, ByVal e As System.EventArgs) Handles CboNo.SelectedIndexChanged
        Dim dt As DataTable
        Dim sqlcmd As String

        '查询病人信息
        sqlcmd = "SELECT Name, Total_PreFee FROM Patient WHERE Patient_ID='" & CboNo.Text & "'"
        dt = SQLQRY(sqlcmd, Nothing)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            MsgBox("没有找到这个住院病人！", vbOKOnly, "提示")
        Else
            '显示病人信息和预付款
            txtName.Text = dt.Rows(0).Item("Name").ToString()
            txtTotFee.Text = dt.Rows(0).Item("Total_PreFee").ToString()
        End If
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim PatientID As String
        Dim addFee As Double
        Dim sqlcmd As String
        Dim da As SqlDataAdapter
        Dim dt As DataTable

        '获取输入
        PatientID = CboNo.Text

        '验证输入
        If PatientID = "" Then
            MsgBox("还没有选择住院病人的住院号！", vbOKOnly, "提示")
            Exit Sub
        End If

        If Not IsNumeric(txtPreFee.Text) Then
            MsgBox("需要输入有效的预付款数值！", vbOKOnly, "提示")
            Exit Sub
        End If

        addFee = Val(txtPreFee.Text)

        '更新预付款
        sqlcmd = "SELECT * FROM Patient WHERE Patient_ID='" & PatientID & "'"
        da = Nothing
        dt = SQLQRY(sqlcmd, da)

        If dt.Rows.Count > 0 Then
            '增加预付款
            dt.Rows(0).Item("Total_PreFee") = dt.Rows(0).Item("Total_PreFee") + addFee

            '保存更改
            da.UpdateCommand = New SqlCommandBuilder(da).GetUpdateCommand()
            da.Update(dt)

            MsgBox("追加预付款完成", vbOKOnly, "提示")
        Else
            MsgBox("找不到住院号！", vbOKOnly, "提示")
        End If
    End Sub

    Private Sub cmdExit_Click(sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub



    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        CboOfc = New ComboBox()
        CboNo = New ComboBox()
        cmdOK = New Button()
        Label1 = New Label()
        txtName = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        txtTotFee = New TextBox()
        txtPreFee = New TextBox()
        cmdExit = New Button()
        SuspendLayout()
        ' 
        ' CboOfc
        ' 
        CboOfc.DropDownStyle = ComboBoxStyle.DropDownList
        CboOfc.FormattingEnabled = True
        CboOfc.Location = New Point(178, 25)
        CboOfc.Name = "CboOfc"
        CboOfc.Size = New Size(540, 25)
        CboOfc.TabIndex = 0
        ' 
        ' CboNo
        ' 
        CboNo.DropDownStyle = ComboBoxStyle.DropDownList
        CboNo.FormattingEnabled = True
        CboNo.Location = New Point(178, 87)
        CboNo.Name = "CboNo"
        CboNo.Size = New Size(540, 25)
        CboNo.TabIndex = 1
        ' 
        ' cmdOK
        ' 
        cmdOK.Location = New Point(270, 371)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New Size(75, 23)
        cmdOK.TabIndex = 2
        cmdOK.Text = "确认"
        cmdOK.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(59, 33)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 17)
        Label1.TabIndex = 3
        Label1.Text = "选择住院科室："
        ' 
        ' txtName
        ' 
        txtName.Enabled = False
        txtName.Location = New Point(178, 155)
        txtName.Name = "txtName"
        txtName.Size = New Size(540, 23)
        txtName.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(59, 95)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 17)
        Label2.TabIndex = 5
        Label2.Text = "选择住院号："
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(59, 158)
        Label3.Name = "Label3"
        Label3.Size = New Size(68, 17)
        Label3.TabIndex = 6
        Label3.Text = "病人姓名："
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(59, 225)
        Label4.Name = "Label4"
        Label4.Size = New Size(56, 17)
        Label4.TabIndex = 7
        Label4.Text = "已付款："
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(59, 295)
        Label5.Name = "Label5"
        Label5.Size = New Size(80, 17)
        Label5.TabIndex = 8
        Label5.Text = "追加预付款："
        ' 
        ' txtTotFee
        ' 
        txtTotFee.Enabled = False
        txtTotFee.Location = New Point(178, 225)
        txtTotFee.Name = "txtTotFee"
        txtTotFee.Size = New Size(540, 23)
        txtTotFee.TabIndex = 9
        ' 
        ' txtPreFee
        ' 
        txtPreFee.Location = New Point(178, 295)
        txtPreFee.Name = "txtPreFee"
        txtPreFee.Size = New Size(540, 23)
        txtPreFee.TabIndex = 10
        ' 
        ' cmdExit
        ' 
        cmdExit.Location = New Point(422, 371)
        cmdExit.Name = "cmdExit"
        cmdExit.Size = New Size(75, 23)
        cmdExit.TabIndex = 11
        cmdExit.Text = "退出"
        cmdExit.UseVisualStyleBackColor = True
        ' 
        ' frmPreFeeRecord
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(cmdExit)
        Controls.Add(txtPreFee)
        Controls.Add(txtTotFee)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(txtName)
        Controls.Add(Label1)
        Controls.Add(cmdOK)
        Controls.Add(CboNo)
        Controls.Add(CboOfc)
        Name = "frmPreFeeRecord"
        Text = "追加预付款"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CboOfc As ComboBox
    Friend WithEvents CboNo As ComboBox
    Friend WithEvents cmdOK As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTotFee As TextBox
    Friend WithEvents txtPreFee As TextBox
    Friend WithEvents cmdExit As Button
End Class
