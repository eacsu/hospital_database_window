Imports System.Windows.Forms

Public Class MDIParent1


    '重新登录
    Private Sub menuSys_login_Click(sender As Object, e As EventArgs) Handles 用户登录ToolStripMenuItem.Click
        frmLogin.Show() '以模式方式启动登录窗体
    End Sub

    '添加用户(仅管理员可用)


    '修改密码


    '退出系统
    Private Sub menuSys_exit_Click(sender As Object, e As EventArgs) Handles 用户退出ToolStripMenuItem.Click
        DBDisConnect() '断开数据库连接
        Application.Exit()
    End Sub



    '病人住院登记
    Private Sub menuPM_record_Click(sender As Object, e As EventArgs) Handles 住院登记ToolStripMenuItem.Click
        frmPInfoRecord.ShowDialog()
    End Sub

    '病人档案维护
    Private Sub menuPM_edit_Click(sender As Object, e As EventArgs) Handles 档案维护ToolStripMenuItem.Click
        frmPinfoEdit.ShowDialog()
    End Sub


    '追加预付款
    Private Sub menuFee_prefee_Click(sender As Object, e As EventArgs) Handles 追加预付款ToolStripMenuItem.Click
        frmPreFeeRecord.ShowDialog()
    End Sub

    '用药处方费用
    Private Sub menuFee_lee_Click(sender As Object, e As EventArgs) Handles 用药处方费用ToolStripMenuItem.Click
        frmLcdFeeRecord.ShowDialog()
    End Sub

    '检查治疗费用
    Private Sub menuFee_std_Click(sender As Object, e As EventArgs) Handles 检查治疗费用ToolStripMenuItem.Click
        frmStdFeeRecord.ShowDialog()
    End Sub

    '每日费用清单
    Private Sub menuFee_report_Click(sender As Object, e As EventArgs) Handles 每日费用清单ToolStripMenuItem.Click
        frmFeeDailyReport.ShowDialog()
    End Sub
    Private Sub menu_addUser_Click(sender As Object, e As EventArgs) Handles 添加用户ToolStripMenuItem.Click
        frmUser.ShowDialog()
    End Sub
    Private Sub menu_change_PW_Click(sender As Object, e As EventArgs) Handles 修改密码ToolStripMenuItem.Click
        frmChPw.ShowDialog()
    End Sub

    Private Sub 药品信息维护ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 药品信息添加ToolStripMenuItem.Click

    End Sub

    Private Sub 检查治疗项目维护ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 检查治疗项目添加ToolStripMenuItem.Click

    End Sub
    '药品信息添加
    Private Sub menuLcd_edit_Click(sender As Object, e As EventArgs) Handles 药品信息添加ToolStripMenuItem.Click
        frmLcdRecord.ShowDialog()
    End Sub

    '药品信息维护
    Private Sub menuLcd_find_Click(sender As Object, e As EventArgs) Handles 药品信息维护ToolStripMenuItem.Click
        frmLcdEdit.ShowDialog()
    End Sub

    '检查治疗项目添加
    Private Sub menuCuredItem_add_Click(ByVal sender As Object, ByVal e As EventArgs) Handles 检查治疗项目添加ToolStripMenuItem.Click
        frmCuredItemRecord.ShowDialog()
    End Sub
    '检查治疗项目维护
    Private Sub menuCuredItem_edit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles 检查治疗项目维护ToolStripMenuItem1.Click
        frmCuredItemEdit.ShowDialog()
    End Sub


    '换床位
    Private Sub menuCtl_bed_Click(sender As Object, e As EventArgs) Handles 换床位ToolStripMenuItem.Click
        FrmMoveBed.ShowDialog()
    End Sub

    '转科室
    Private Sub menuCtl_ofic_Click(sender As Object, e As EventArgs) Handles 转科室ToolStripMenuItem.Click
        FrmMoveOfc.ShowDialog()
    End Sub

    '办理出院
    Private Sub menuEndCalc_Click(sender As Object, e As EventArgs) Handles 办理出院ToolStripMenuItem.Click
        frmEndCalc.ShowDialog()
    End Sub

    Private Sub state_Click(sender As Object, e As EventArgs) Handles state.Click

    End Sub
End Class
