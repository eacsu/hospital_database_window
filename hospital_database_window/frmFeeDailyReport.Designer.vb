Imports Microsoft.Data.SqlClient

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFeeDailyReport
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



    Private Sub frmFeeDailyReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        Dim sqlcmd As String

        '清除下拉列表
        CboOfc.Items.Clear()
        CboNo.Items.Clear()

        '添加住院科室到下拉列表
        sqlcmd = "SELECT DISTINCT Consultation_Office FROM Patient"
        dt = SQLQRY(sqlcmd, Nothing)
        For i = 0 To dt.Rows.Count - 1
            CboOfc.Items.Add(dt.Rows(i).Item("Consultation_Office"))
        Next

        '初始化报告日期为当天
        DTRreportDate.Value = Now
    End Sub




    Private Sub CboNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboNo.SelectedIndexChanged
        Dim dt As DataTable
        Dim sqlcmd As String

        '查询病人信息
        sqlcmd = "SELECT Name,Total_PreFee FROM Patient WHERE Patient_ID='" & CboNo.Text & "'"
        dt = SQLQRY(sqlcmd, Nothing)

        If dt.Rows.Count = 0 Then
            MsgBox("没有找到这个住院病人！", vbOKOnly, "提示")
        Else
            txtName.Text = dt.Rows(0).Item("Name").ToString()
        End If
    End Sub

    '选择"住院科室"下拉列表时执行
    Private Sub CboOfc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboOfc.SelectedIndexChanged
        Dim dt As DataTable
        Dim sqlcmd As String

        '清除原有数据
        CboNo.Items.Clear()
        txtName.Text = ""

        '加载对应科室的住院号(仅未出院病人)
        sqlcmd = "SELECT DISTINCT Patient_ID FROM Patient " &
             "WHERE Consultation_Office='" & CboOfc.Text & "' " &
             "AND Leave_Time IS NULL"

        dt = SQLQRY(sqlcmd, Nothing)
        For i = 0 To dt.Rows.Count - 1
            CboNo.Items.Add(dt.Rows(i).Item("Patient_ID"))
        Next
    End Sub
    Private Sub cmdOKClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim dt As DataTable
        Dim sql As String

        '验证输入
        If Trim(CboNo.Text) = "" Then
            MsgBox("没有选择住院病人！", vbOKOnly, "提示")
            CboNo.Focus()
            Exit Sub
        End If

        '查询每日费用数据
        sql = "SELECT Patient_ID,Name,Sex,Bed_No,Consultation_Office,Charge_Doctor," &
          "Total_PreFee,ISNULL(Lec_Name,'')+ISNULL(Crt_Name,'') AS ItemName," &
          "Fee,CONVERT(CHAR(10),Cured_Time,120) " &
          "FROM DayReportView WHERE Patient_ID='" & CboNo.Text & "' " &
          "AND CONVERT(CHAR(10),Cured_Time,120)='" & DTRreportDate.Value.ToString("yyyy-MM-dd") & "'"

        dt = SQLQRY(sql, Nothing)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            cmdEXCEL.Enabled = False
            MsgBox("没有找到数据！", vbOKOnly, "提示")
            Exit Sub
        End If

        '显示数据
        dGridReport.DataSource = dt
        SetHeadTitle()
        cmdEXCEL.Enabled = True
    End Sub

    Private Sub SetHeadTitle()
        dGridReport.Columns(0).HeaderText = "住院号"
        dGridReport.Columns(1).HeaderText = "病人姓名"
        dGridReport.Columns(2).HeaderText = "性别"
        dGridReport.Columns(3).HeaderText = "床号"
        dGridReport.Columns(4).HeaderText = "住院科室"
        dGridReport.Columns(5).HeaderText = "主治医生"
        dGridReport.Columns(6).HeaderText = "已预交住院费"
        dGridReport.Columns(7).HeaderText = "诊疗项目"
        dGridReport.Columns(8).HeaderText = "诊疗费用"
        dGridReport.Columns(9).HeaderText = "诊疗时间"

        '设置列宽和标题行高
        dGridReport.ColumnHeadersHeight = 28
        dGridReport.Columns(0).Width = 80
        dGridReport.Columns(1).Width = 80
        dGridReport.Columns(2).Width = 60
        dGridReport.Columns(3).Width = 60
        dGridReport.Columns(4).Width = 120
        dGridReport.Columns(5).Width = 80
        dGridReport.Columns(6).Width = 130
        dGridReport.Columns(7).Width = 120
        dGridReport.Columns(8).Width = 80
        dGridReport.Columns(9).Width = 110
    End Sub

    Private Sub cmdEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEXCEL.Click
        Dim TRows As Integer
        Dim myexcel As New Microsoft.Office.Interop.Excel.Application
        Dim mybook As Microsoft.Office.Interop.Excel.Workbook
        Dim mysheet As Microsoft.Office.Interop.Excel.Worksheet

        '创建Excel工作簿
        mybook = myexcel.Workbooks.Add
        mysheet = mybook.Worksheets("Sheet1")
        mysheet.Name = "每日诊疗费用清单"

        '设置Excel格式
        myexcel.ActiveSheet.PageSetup.CenterHorizontally = True
        mysheet.Columns("A:J").Font.Size = 10
        mysheet.Columns("A:J").VerticalAlignment = -4108 'xlCenter
        mysheet.Columns("A:J").HorizontalAlignment = -4108 'xlCenter

        '设置列宽
        mysheet.Columns(1).ColumnWidth = 8
        mysheet.Columns(2).ColumnWidth = 6
        mysheet.Columns(3).ColumnWidth = 6
        mysheet.Columns(4).ColumnWidth = 18
        mysheet.Columns(5).ColumnWidth = 8
        mysheet.Columns(6).ColumnWidth = 11
        mysheet.Columns(7).ColumnWidth = 8
        mysheet.Columns(8).ColumnWidth = 9
        mysheet.Rows(1).RowHeight = 20

        '设置标题
        mysheet.Range(mysheet.Cells(1, 1), mysheet.Cells(1, 10)).MergeCells = True
        mysheet.Cells(1, 1).Value = "每日诊疗费用清单"
        mysheet.Cells(1, 1).Font.Size = 16
        mysheet.Cells(1, 1).Font.Bold = True

        '设置表头
        mysheet.Rows(2).Font.Bold = True
        mysheet.Cells(2, 1).Value = "住院号"
        mysheet.Cells(2, 2).Value = "病人姓名"
        mysheet.Cells(2, 3).Value = "性别"
        mysheet.Cells(2, 4).Value = "床号"
        mysheet.Cells(2, 5).Value = "住院科室"
        mysheet.Cells(2, 6).Value = "主治医生"
        mysheet.Cells(2, 7).Value = "已预交住院费"
        mysheet.Cells(2, 8).Value = "诊疗项目"
        mysheet.Cells(2, 9).Value = "诊疗费用"
        mysheet.Cells(2, 10).Value = "诊疗时间"

        '填充数据
        Dim startRow As Integer = 3
        Dim mydt As DataTable = dGridReport.DataSource
        For col = 0 To mydt.Columns.Count - 1
            For row = 0 To mydt.Rows.Count - 1
                mysheet.Cells(startRow + row, col + 1) = mydt.Rows(row).Item(col)
            Next
        Next

        '显示Excel
        myexcel.Visible = True
        mysheet = Nothing
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
        cmdExit = New Button()
        cmdOK = New Button()
        CboNo = New ComboBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        CboOfc = New ComboBox()
        txtName = New TextBox()
        Label1 = New Label()
        GroupBox1 = New GroupBox()
        DTRreportDate = New DateTimePicker()
        cmdEXCEL = New Button()
        dGridReport = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(dGridReport, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cmdExit
        ' 
        cmdExit.Location = New Point(684, 56)
        cmdExit.Name = "cmdExit"
        cmdExit.Size = New Size(75, 23)
        cmdExit.TabIndex = 10
        cmdExit.Text = "退出"
        cmdExit.UseVisualStyleBackColor = True
        ' 
        ' cmdOK
        ' 
        cmdOK.Location = New Point(684, 18)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New Size(75, 23)
        cmdOK.TabIndex = 9
        cmdOK.Text = "确认"
        cmdOK.UseVisualStyleBackColor = True
        ' 
        ' CboNo
        ' 
        CboNo.DropDownStyle = ComboBoxStyle.DropDownList
        CboNo.FormattingEnabled = True
        CboNo.Location = New Point(469, 16)
        CboNo.Name = "CboNo"
        CboNo.Size = New Size(178, 25)
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
        Label2.Size = New Size(68, 17)
        Label2.TabIndex = 3
        Label2.Text = "报告日期："
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
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(DTRreportDate)
        GroupBox1.Controls.Add(cmdExit)
        GroupBox1.Controls.Add(CboNo)
        GroupBox1.Controls.Add(cmdOK)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(CboOfc)
        GroupBox1.Controls.Add(txtName)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(12, 16)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(776, 95)
        GroupBox1.TabIndex = 8
        GroupBox1.TabStop = False
        GroupBox1.Text = "选择病人"
        ' 
        ' DTRreportDate
        ' 
        DTRreportDate.Location = New Point(469, 59)
        DTRreportDate.Name = "DTRreportDate"
        DTRreportDate.Size = New Size(178, 23)
        DTRreportDate.TabIndex = 11
        ' 
        ' cmdEXCEL
        ' 
        cmdEXCEL.Location = New Point(675, 415)
        cmdEXCEL.Name = "cmdEXCEL"
        cmdEXCEL.Size = New Size(96, 23)
        cmdEXCEL.TabIndex = 12
        cmdEXCEL.Text = "输出到 EXCEL"
        cmdEXCEL.UseVisualStyleBackColor = True
        ' 
        ' dGridReport
        ' 
        dGridReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dGridReport.Location = New Point(12, 135)
        dGridReport.Name = "dGridReport"
        dGridReport.ReadOnly = True
        dGridReport.Size = New Size(776, 274)
        dGridReport.TabIndex = 13
        ' 
        ' frmFeeDailyReport
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(dGridReport)
        Controls.Add(cmdEXCEL)
        Controls.Add(GroupBox1)
        Name = "frmFeeDailyReport"
        Text = "每日费用清单"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dGridReport, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents cmdExit As Button
    Friend WithEvents cmdOK As Button
    Friend WithEvents CboNo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CboOfc As ComboBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DTRreportDate As DateTimePicker
    Friend WithEvents cmdEXCEL As Button
    Friend WithEvents dGridReport As DataGridView
End Class
