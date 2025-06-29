Imports Microsoft.Data.SqlClient

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLcdFeeRecord
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


    Dim lecNo As String '药品编号
    Dim lecFee As Double '用药费用
    Dim objItem As ListViewItem 'ListView的Item


    Private Sub frmLcdFeeRecord_Load(sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        Dim sqlcmd As String

        '初始化下拉列表
        CboOfc.Items.Clear()
        CboNo.Items.Clear()
        CboClass.Items.Clear()

        '加载住院科室
        sqlcmd = "SELECT DISTINCT Consultation_Office FROM Patient"
        dt = SQLQRY(sqlcmd, Nothing)
        For i = 0 To dt.Rows.Count - 1
            CboOfc.Items.Add(dt.Rows(i).Item("Consultation_Office"))
        Next

        '加载药品分类
        sqlcmd = "SELECT DISTINCT Class FROM Leechdom"
        dt = SQLQRY(sqlcmd, Nothing)
        For i = 0 To dt.Rows.Count - 1
            CboClass.Items.Add(dt.Rows(i).Item("Class"))
        Next
    End Sub
    '选择"住院科室"下拉列表时执行
    Private Sub CboOfc_SelectedIndexChanged(sender As System.Object, ByVal e As System.EventArgs) Handles CboOfc.SelectedIndexChanged
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
    Private Sub CboClass_SelectedIndexChanged(sender As System.Object, ByVal e As System.EventArgs) Handles CboClass.SelectedIndexChanged
        Dim dt As DataTable
        Dim sqlcmd As String

        '查询指定分类的药品
        sqlcmd = "SELECT * FROM Leechdom WHERE Class='" & CboClass.Text & "'"
        dt = SQLQRY(sqlcmd, Nothing)

        '初始化ListView
        LstLee.Items.Clear()
        LstLee.View = View.Details
        LstLee.FullRowSelect = True

        '添加列标题
        LstLee.Columns.Add("编号", 100, HorizontalAlignment.Left)
        LstLee.Columns.Add("名称", 100, HorizontalAlignment.Left)
        LstLee.Columns.Add("规格", 100, HorizontalAlignment.Left)
        LstLee.Columns.Add("用药价格", 100, HorizontalAlignment.Right)

        '添加药品数据
        For i = 0 To dt.Rows.Count - 1
            objItem = LstLee.Items.Add(dt.Rows(i).Item("Leechdom_ID"))
            With objItem
                .SubItems.Add(dt.Rows(i).Item("Name"))
                .SubItems.Add(dt.Rows(i).Item("Specs"))
                .SubItems.Add(Format(dt.Rows(i).Item("Price"), "####0.00"))
            End With
        Next
    End Sub

    Private Sub LstLee_DoubleClick(sender As Object, ByVal e As System.EventArgs) Handles LstLee.DoubleClick
        Dim dt As DataTable
        Dim sqlcmd As String
        Dim leePrice As Double

        '获取选中药品编号
        lecNo = LstLee.SelectedItems.Item(0).Text

        '查询药品价格
        sqlcmd = "SELECT * FROM Leechdom WHERE Leechdom_ID='" & lecNo & "'"
        dt = SQLQRY(sqlcmd, Nothing)
        If dt.Rows.Count > 0 Then
            leePrice = dt.Rows(0).Item("Price")
        End If

        '显示价格并计算费用
        txtPrice.Text = Format(leePrice, "####0.00")
        txtNums_TextChanged(LstLee, New EventArgs())
        txtNums.Focus()
    End Sub


    Private Sub txtNums_TextChanged(sender As Object, ByVal e As System.EventArgs) Handles txtNums.TextChanged
        lecFee = Val(txtPrice.Text) * Val(txtNums.Text)
        txtFee.Text = lecFee
    End Sub


    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
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

        If Val(txtPrice.Text) = 0 Then
            MsgBox("请选择用药", vbOKOnly, "提示")
            LstLee.Focus()
            Exit Sub
        End If

        If lecFee = 0 Then
            MsgBox("费用为零", vbOKOnly, "提示")
            txtNums.Focus()
            Exit Sub
        End If

        '统计使用次数
        sqlcmd = "SELECT cnt=count(*) FROM CureFee WHERE Patient_ID='" & PatNo & "' AND FeeItem_ID='" & lecNo & "'"
        dt = SQLQRY(sqlcmd, Nothing)
        CureFeeNo = dt.Rows(0).Item("cnt") + 1

        '新增费用记录
        sqlcmd = "SELECT * FROM CureFee WHERE Patient_ID='" & PatNo & "' AND FeeItem_ID='" & lecNo & "'"
        da = Nothing
        dt = SQLQRY(sqlcmd, da)

        da.InsertCommand = New SqlCommandBuilder(da).GetInsertCommand()
        Dim dr As DataRow = dt.NewRow()
        dr("Fee_ID") = CureFeeNo
        dr("Patient_ID") = PatNo
        dr("FeeItem_ID") = lecNo
        dr("Fee_Type") = "用药处方费用"
        dr("Fee") = lecFee
        dr("Cured_Time") = Now
        dt.Rows.Add(dr)
        da.Update(dt)

        MsgBox("添加费用完成", vbOKOnly, "提示")
    End Sub


    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
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
        GroupBox2 = New GroupBox()
        Label1 = New Label()
        cmdOK = New Button()
        txtName = New TextBox()
        CboOfc = New ComboBox()
        cmdExit = New Button()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        CboNo = New ComboBox()
        txtTotFee = New TextBox()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        txtPrice = New TextBox()
        txtNums = New TextBox()
        txtFee = New TextBox()
        LstLee = New ListView()
        CboClass = New ComboBox()
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
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(776, 95)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "选择病人"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(CboClass)
        GroupBox2.Controls.Add(LstLee)
        GroupBox2.Controls.Add(txtFee)
        GroupBox2.Controls.Add(txtNums)
        GroupBox2.Controls.Add(txtPrice)
        GroupBox2.Controls.Add(Label12)
        GroupBox2.Controls.Add(Label11)
        GroupBox2.Controls.Add(Label10)
        GroupBox2.Controls.Add(Label9)
        GroupBox2.Controls.Add(Label8)
        GroupBox2.Controls.Add(Label7)
        GroupBox2.Controls.Add(Label6)
        GroupBox2.Controls.Add(Label5)
        GroupBox2.Location = New Point(12, 113)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(776, 275)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        GroupBox2.Text = "用药选择及费用"
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
        ' cmdOK
        ' 
        cmdOK.Location = New Point(263, 408)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New Size(75, 23)
        cmdOK.TabIndex = 2
        cmdOK.Text = "费用确认"
        cmdOK.UseVisualStyleBackColor = True
        ' 
        ' txtName
        ' 
        txtName.Enabled = False
        txtName.Location = New Point(136, 56)
        txtName.Name = "txtName"
        txtName.Size = New Size(207, 23)
        txtName.TabIndex = 1
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
        ' cmdExit
        ' 
        cmdExit.Location = New Point(382, 408)
        cmdExit.Name = "cmdExit"
        cmdExit.Size = New Size(75, 23)
        cmdExit.TabIndex = 3
        cmdExit.Text = "退出"
        cmdExit.UseVisualStyleBackColor = True
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
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(370, 19)
        Label3.Name = "Label3"
        Label3.Size = New Size(80, 17)
        Label3.TabIndex = 4
        Label3.Text = "选择住院号："
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
        ' CboNo
        ' 
        CboNo.DropDownStyle = ComboBoxStyle.DropDownList
        CboNo.FormattingEnabled = True
        CboNo.Location = New Point(469, 16)
        CboNo.Name = "CboNo"
        CboNo.Size = New Size(254, 25)
        CboNo.TabIndex = 6
        ' 
        ' txtTotFee
        ' 
        txtTotFee.Enabled = False
        txtTotFee.Location = New Point(469, 59)
        txtTotFee.Name = "txtTotFee"
        txtTotFee.Size = New Size(254, 23)
        txtTotFee.TabIndex = 7
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(207, 215)
        Label5.Name = "Label5"
        Label5.Size = New Size(32, 17)
        Label5.TabIndex = 6
        Label5.Text = "数量"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(112, 215)
        Label6.Name = "Label6"
        Label6.Size = New Size(56, 17)
        Label6.TabIndex = 7
        Label6.Text = "用药价格"
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
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(49, 119)
        Label8.Name = "Label8"
        Label8.Size = New Size(56, 34)
        Label8.TabIndex = 9
        Label8.Text = "双击药品" & vbCrLf & "条目选择"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(49, 78)
        Label9.Name = "Label9"
        Label9.Size = New Size(44, 17)
        Label9.TabIndex = 10
        Label9.Text = vbTab & "药品："
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(49, 43)
        Label10.Name = "Label10"
        Label10.Size = New Size(68, 17)
        Label10.TabIndex = 11
        Label10.Text = "药品分类："
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(266, 242)
        Label11.Name = "Label11"
        Label11.Size = New Size(17, 17)
        Label11.TabIndex = 12
        Label11.Text = vbTab & "="
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(174, 242)
        Label12.Name = "Label12"
        Label12.Size = New Size(13, 17)
        Label12.TabIndex = 13
        Label12.Text = vbTab & "*"
        ' 
        ' txtPrice
        ' 
        txtPrice.Enabled = False
        txtPrice.Location = New Point(101, 239)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(67, 23)
        txtPrice.TabIndex = 17
        ' 
        ' txtNums
        ' 
        txtNums.Location = New Point(193, 239)
        txtNums.Name = "txtNums"
        txtNums.Size = New Size(65, 23)
        txtNums.TabIndex = 18
        ' 
        ' txtFee
        ' 
        txtFee.Enabled = False
        txtFee.Location = New Point(289, 239)
        txtFee.Name = "txtFee"
        txtFee.Size = New Size(67, 23)
        txtFee.TabIndex = 19
        ' 
        ' LstLee
        ' 
        LstLee.Location = New Point(122, 78)
        LstLee.Name = "LstLee"
        LstLee.Size = New Size(601, 128)
        LstLee.TabIndex = 20
        LstLee.UseCompatibleStateImageBehavior = False
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
        ' frmLcdFeeRecord
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(cmdExit)
        Controls.Add(cmdOK)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Name = "frmLcdFeeRecord"
        Text = "用药处方费用"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmdOK As Button
    Friend WithEvents txtTotFee As TextBox
    Friend WithEvents CboNo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CboOfc As ComboBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtNums As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmdExit As Button
    Friend WithEvents LstLee As ListView
    Friend WithEvents txtFee As TextBox
    Friend WithEvents CboClass As ComboBox
End Class
