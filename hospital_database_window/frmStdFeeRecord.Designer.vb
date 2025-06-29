Imports Microsoft.Data.SqlClient

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStdFeeRecord
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



    Dim ItmNo As String    '检查治疗项目的编号
    Dim ItmPrice As Double    '检查治疗项目的价格
    Dim objItem As ListViewItem    'ListView的Item

    Private Sub frmStdFeeRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable    '数据表对象
        Dim sqlcmd As String

        '清除下拉列表
        CboOfc.Items.Clear()
        CboNo.Items.Clear()
        CboClass.Items.Clear()

        '添加住院科室到下拉列表
        sqlcmd = "SELECT DISTINCT Consultation_Office FROM Patient"
        dt = SQLQRY(sqlcmd, Nothing)
        For i = 0 To dt.Rows.Count - 1
            CboOfc.Items.Add(dt.Rows(i).Item("Consultation_Office"))
        Next

        '添加检查治疗项目分类到下拉列表
        sqlcmd = "SELECT DISTINCT Class FROM CuredItem"
        dt = SQLQRY(sqlcmd, Nothing)
        For i = 0 To dt.Rows.Count - 1
            CboClass.Items.Add(dt.Rows(i).Item("Class"))
        Next
    End Sub


    '选择"住院科室"下拉列表时执行
    Private Sub CboOfc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboOfc.SelectedIndexChanged
        Dim dt As DataTable
        Dim sqlcmd As String

        '清除原有数据
        CboNo.Items.Clear()
        txtName.Text = ""
        txtTotFee.Text = ""

        '加载对应科室的住院号(仅未出院病人)
        sqlcmd = "SELECT DISTINCT Patient_ID FROM Patient " &
             "WHERE Consultation_Office='" & CboOfc.Text & "' " &
             "AND Leave_Time IS NULL"

        dt = SQLQRY(sqlcmd, Nothing)
        For i = 0 To dt.Rows.Count - 1
            CboNo.Items.Add(dt.Rows(i).Item("Patient_ID"))
        Next
    End Sub

    '选择"住院号"下拉列表时执行
    Private Sub CboNo_SelectedIndexChanged(sender As System.Object, ByVal e As System.EventArgs) Handles CboNo.SelectedIndexChanged
        Dim dt As DataTable
        Dim sqlcmd As String

        '查询病人信息
        sqlcmd = "SELECT Name, Total_PreFee FROM Patient WHERE Patient_ID='" & CboNo.Text & "'"
        dt = SQLQRY(sqlcmd, Nothing)

        If dt.Rows.Count = 0 Then
            MsgBox("没有找到这个住院病人！", vbOKOnly, "提示")
        Else
            '显示病人基本信息和预付款
            txtName.Text = dt.Rows(0).Item("Name").ToString()
            txtTotFee.Text = dt.Rows(0).Item("Total_PreFee").ToString()
        End If
    End Sub

    '项目分类选择事件
    Private Sub CboClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboClass.SelectedIndexChanged
        Dim dt As DataTable
        Dim sqlcmd As String

        '查询指定分类的项目
        sqlcmd = "SELECT * FROM CuredItem WHERE Class='" & CboClass.Text & "'"
        dt = SQLQRY(sqlcmd, Nothing)

        '初始化ListView
        LstItem.Items.Clear()
        LstItem.View = View.Details
        LstItem.FullRowSelect = True

        '添加列标题
        LstItem.Columns.Add("项目Id", 100, HorizontalAlignment.Left)
        LstItem.Columns.Add("项目名称", 100, HorizontalAlignment.Left)
        LstItem.Columns.Add("费用", 100, HorizontalAlignment.Right)

        '添加项目数据
        For i = 0 To dt.Rows.Count - 1
            objItem = LstItem.Items.Add(dt.Rows(i).Item("Item_ID"))
            objItem.SubItems.Add(dt.Rows(i).Item("Name"))
            objItem.SubItems.Add(Format(dt.Rows(i).Item("Fee"), "###0.00"))
        Next
    End Sub

    Private Sub LstItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstItem.DoubleClick
        Dim dt As DataTable
        Dim sqlcmd As String
        Dim itemPrice As Double

        '获取选中项目编号
        ItmNo = LstItem.SelectedItems.Item(0).Text

        '查询项目价格
        sqlcmd = "SELECT * FROM CuredItem WHERE Item_ID='" & ItmNo & "'"
        dt = SQLQRY(sqlcmd, Nothing)
        If dt.Rows.Count > 0 Then
            itemPrice = dt.Rows(0).Item("Fee")
        End If

        '显示价格
        txtFee.Text = Format(itemPrice, "###0.00")
        txtFee.Focus()
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        Dim CureFeeNo As Integer
        Dim sqlcmd As String
        Dim da As SqlDataAdapter
        Dim dt As DataTable
        Dim PatNo As String = Trim(CboNo.Text)

        '验证输入
        If PatNo = "" Then
            MsgBox("请首先选择住院病人", vbOKOnly, "提示")
            CboOfc.Focus()
            Exit Sub
        End If

        If LstItem.Items.Count = 0 Or Val(txtFee.Text) = 0 Then
            MsgBox("请选择检查治疗项目", vbOKOnly, "提示")
            LstItem.Focus()
            Exit Sub
        End If

        '统计使用次数
        sqlcmd = "SELECT cnt=count(*) FROM CureFee WHERE Patient_ID='" & PatNo & "' AND FeeItem_ID='" & ItmNo & "'"
        dt = SQLQRY(sqlcmd, Nothing)
        CureFeeNo = dt.Rows(0).Item("cnt") + 1

        '新增费用记录
        sqlcmd = "SELECT * FROM CureFee WHERE Patient_ID='" & PatNo & "' AND FeeItem_ID='" & ItmNo & "'"
        da = Nothing
        dt = SQLQRY(sqlcmd, da)

        da.InsertCommand = New SqlCommandBuilder(da).GetInsertCommand()
        Dim dr As DataRow = dt.NewRow()
        dr("Fee_ID") = CureFeeNo
        dr("Patient_ID") = PatNo
        dr("FeeItem_ID") = ItmNo
        dr("Fee_Type") = "检查治疗费用"
        dr("Fee") = Val(txtFee.Text)
        dr("Cured_Time") = Now
        dt.Rows.Add(dr)
        da.Update(dt)

        MsgBox("添加费用完成", vbOKOnly, "提示")
    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
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
        GroupBox1 = New GroupBox()
        txtTotFee = New TextBox()
        CboNo = New ComboBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        CboOfc = New ComboBox()
        txtName = New TextBox()
        Label1 = New Label()
        GroupBox2 = New GroupBox()
        CboClass = New ComboBox()
        LstItem = New ListView()
        txtFee = New TextBox()
        Label10 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        cmdExit = New Button()
        cmdOK = New Button()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(txtTotFee)
        GroupBox1.Controls.Add(CboNo)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(CboOfc)
        GroupBox1.Controls.Add(txtName)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(12, 16)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(776, 95)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        GroupBox1.Text = "选择病人"
        ' 
        ' txtTotFee
        ' 
        txtTotFee.Enabled = False
        txtTotFee.Location = New Point(469, 59)
        txtTotFee.Name = "txtTotFee"
        txtTotFee.Size = New Size(254, 23)
        txtTotFee.TabIndex = 7
        ' 
        ' CboNo
        ' 
        CboNo.DropDownStyle = ComboBoxStyle.DropDownList
        CboNo.FormattingEnabled = True
        CboNo.Location = New Point(469, 16)
        CboNo.Name = "CboNo"
        CboNo.Size = New Size(254, 25)
        CboNo.TabIndex = 6
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(49, 59)
        Label4.Name = "Label4"
        Label4.Size = New Size(68, 17)
        Label4.TabIndex = 5
        Label4.Text = "病人姓名："
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(370, 19)
        Label3.Name = "Label3"
        Label3.Size = New Size(80, 17)
        Label3.TabIndex = 4
        Label3.Text = "选择住院号："
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(370, 59)
        Label2.Name = "Label2"
        Label2.Size = New Size(56, 17)
        Label2.TabIndex = 3
        Label2.Text = "已付款："
        ' 
        ' CboOfc
        ' 
        CboOfc.DropDownStyle = ComboBoxStyle.DropDownList
        CboOfc.FormattingEnabled = True
        CboOfc.Location = New Point(136, 16)
        CboOfc.Name = "CboOfc"
        CboOfc.Size = New Size(207, 25)
        CboOfc.TabIndex = 2
        ' 
        ' txtName
        ' 
        txtName.Enabled = False
        txtName.Location = New Point(136, 56)
        txtName.Name = "txtName"
        txtName.Size = New Size(207, 23)
        txtName.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(49, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 17)
        Label1.TabIndex = 0
        Label1.Text = "选择住院科室："
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(CboClass)
        GroupBox2.Controls.Add(LstItem)
        GroupBox2.Controls.Add(txtFee)
        GroupBox2.Controls.Add(Label10)
        GroupBox2.Controls.Add(Label9)
        GroupBox2.Controls.Add(Label8)
        GroupBox2.Controls.Add(Label7)
        GroupBox2.Location = New Point(12, 117)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(776, 275)
        GroupBox2.TabIndex = 5
        GroupBox2.TabStop = False
        GroupBox2.Text = "用药选择及费用"
        ' 
        ' CboClass
        ' 
        CboClass.DropDownStyle = ComboBoxStyle.DropDownList
        CboClass.FormattingEnabled = True
        CboClass.Location = New Point(123, 35)
        CboClass.Name = "CboClass"
        CboClass.Size = New Size(254, 25)
        CboClass.TabIndex = 8
        ' 
        ' LstItem
        ' 
        LstItem.Location = New Point(122, 78)
        LstItem.Name = "LstItem"
        LstItem.Size = New Size(601, 128)
        LstItem.TabIndex = 20
        LstItem.UseCompatibleStateImageBehavior = False
        ' 
        ' txtFee
        ' 
        txtFee.Enabled = False
        txtFee.Location = New Point(122, 236)
        txtFee.Name = "txtFee"
        txtFee.Size = New Size(67, 23)
        txtFee.TabIndex = 19
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(49, 43)
        Label10.Name = "Label10"
        Label10.Size = New Size(68, 17)
        Label10.TabIndex = 11
        Label10.Text = "项目分类："
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(49, 78)
        Label9.Name = "Label9"
        Label9.Size = New Size(44, 17)
        Label9.TabIndex = 10
        Label9.Text = vbTab & "项目："
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(49, 119)
        Label8.Name = "Label8"
        Label8.Size = New Size(56, 34)
        Label8.TabIndex = 9
        Label8.Text = "双击项目" & vbCrLf & "条目选择"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(49, 242)
        Label7.Name = "Label7"
        Label7.Size = New Size(44, 17)
        Label7.TabIndex = 8
        Label7.Text = "费用："
        ' 
        ' cmdExit
        ' 
        cmdExit.Location = New Point(382, 412)
        cmdExit.Name = "cmdExit"
        cmdExit.Size = New Size(75, 23)
        cmdExit.TabIndex = 7
        cmdExit.Text = "退出"
        cmdExit.UseVisualStyleBackColor = True
        ' 
        ' cmdOK
        ' 
        cmdOK.Location = New Point(263, 412)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New Size(75, 23)
        cmdOK.TabIndex = 6
        cmdOK.Text = "费用确认"
        cmdOK.UseVisualStyleBackColor = True
        ' 
        ' frmStdFeeRecord
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(GroupBox1)
        Controls.Add(GroupBox2)
        Controls.Add(cmdExit)
        Controls.Add(cmdOK)
        Name = "frmStdFeeRecord"
        Text = "检查治疗费用"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtTotFee As TextBox
    Friend WithEvents CboNo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CboOfc As ComboBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CboClass As ComboBox
    Friend WithEvents LstItem As ListView
    Friend WithEvents txtFee As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmdExit As Button
    Friend WithEvents cmdOK As Button
End Class
