<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MDIParent1
    Inherits System.Windows.Forms.Form

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


    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIParent1))
        StatusStrip = New StatusStrip()
        ToolStripStatusLabel = New ToolStripStatusLabel()
        ToolTip = New ToolTip(components)
        MenuStrip1 = New MenuStrip()
        系统管理ToolStripMenuItem = New ToolStripMenuItem()
        用户登录ToolStripMenuItem = New ToolStripMenuItem()
        添加用户ToolStripMenuItem = New ToolStripMenuItem()
        修改密码ToolStripMenuItem = New ToolStripMenuItem()
        用户退出ToolStripMenuItem = New ToolStripMenuItem()
        病人管理ToolStripMenuItem = New ToolStripMenuItem()
        住院登记ToolStripMenuItem = New ToolStripMenuItem()
        档案维护ToolStripMenuItem = New ToolStripMenuItem()
        收费管理ToolStripMenuItem = New ToolStripMenuItem()
        追加预付款ToolStripMenuItem = New ToolStripMenuItem()
        用药处方费用ToolStripMenuItem = New ToolStripMenuItem()
        检查治疗费用ToolStripMenuItem = New ToolStripMenuItem()
        每日费用清单ToolStripMenuItem = New ToolStripMenuItem()
        资料管理ToolStripMenuItem = New ToolStripMenuItem()
        药品信息添加ToolStripMenuItem = New ToolStripMenuItem()
        药品信息维护ToolStripMenuItem = New ToolStripMenuItem()
        检查治疗项目添加ToolStripMenuItem = New ToolStripMenuItem()
        检查治疗项目维护ToolStripMenuItem1 = New ToolStripMenuItem()
        流动管理ToolStripMenuItem = New ToolStripMenuItem()
        换床位ToolStripMenuItem = New ToolStripMenuItem()
        转科室ToolStripMenuItem = New ToolStripMenuItem()
        办理出院ToolStripMenuItem = New ToolStripMenuItem()
        state = New Label()
        PictureBox1 = New PictureBox()
        StatusStrip.SuspendLayout()
        MenuStrip1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' StatusStrip
        ' 
        StatusStrip.ImageScalingSize = New Size(20, 20)
        StatusStrip.Items.AddRange(New ToolStripItem() {ToolStripStatusLabel})
        StatusStrip.Location = New Point(0, 570)
        StatusStrip.Name = "StatusStrip"
        StatusStrip.Padding = New Padding(2, 0, 16, 0)
        StatusStrip.Size = New Size(737, 22)
        StatusStrip.TabIndex = 7
        StatusStrip.Text = "StatusStrip"
        ' 
        ' ToolStripStatusLabel
        ' 
        ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        ToolStripStatusLabel.Size = New Size(32, 17)
        ToolStripStatusLabel.Text = "状态"
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {系统管理ToolStripMenuItem, 病人管理ToolStripMenuItem, 收费管理ToolStripMenuItem, 资料管理ToolStripMenuItem, 流动管理ToolStripMenuItem, 办理出院ToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(5, 2, 0, 2)
        MenuStrip1.Size = New Size(737, 25)
        MenuStrip1.TabIndex = 9
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' 系统管理ToolStripMenuItem
        ' 
        系统管理ToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {用户登录ToolStripMenuItem, 添加用户ToolStripMenuItem, 修改密码ToolStripMenuItem, 用户退出ToolStripMenuItem})
        系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem"
        系统管理ToolStripMenuItem.Size = New Size(68, 21)
        系统管理ToolStripMenuItem.Text = "系统管理"
        ' 
        ' 用户登录ToolStripMenuItem
        ' 
        用户登录ToolStripMenuItem.Name = "用户登录ToolStripMenuItem"
        用户登录ToolStripMenuItem.Size = New Size(124, 22)
        用户登录ToolStripMenuItem.Text = "用户登录"
        ' 
        ' 添加用户ToolStripMenuItem
        ' 
        添加用户ToolStripMenuItem.Name = "添加用户ToolStripMenuItem"
        添加用户ToolStripMenuItem.Size = New Size(124, 22)
        添加用户ToolStripMenuItem.Text = "添加用户"
        ' 
        ' 修改密码ToolStripMenuItem
        ' 
        修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem"
        修改密码ToolStripMenuItem.Size = New Size(124, 22)
        修改密码ToolStripMenuItem.Text = "修改密码"
        ' 
        ' 用户退出ToolStripMenuItem
        ' 
        用户退出ToolStripMenuItem.Name = "用户退出ToolStripMenuItem"
        用户退出ToolStripMenuItem.Size = New Size(124, 22)
        用户退出ToolStripMenuItem.Text = "用户退出"
        ' 
        ' 病人管理ToolStripMenuItem
        ' 
        病人管理ToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {住院登记ToolStripMenuItem, 档案维护ToolStripMenuItem})
        病人管理ToolStripMenuItem.Name = "病人管理ToolStripMenuItem"
        病人管理ToolStripMenuItem.Size = New Size(68, 21)
        病人管理ToolStripMenuItem.Text = "病人管理"
        ' 
        ' 住院登记ToolStripMenuItem
        ' 
        住院登记ToolStripMenuItem.Name = "住院登记ToolStripMenuItem"
        住院登记ToolStripMenuItem.Size = New Size(180, 22)
        住院登记ToolStripMenuItem.Text = "住院登记"
        ' 
        ' 档案维护ToolStripMenuItem
        ' 
        档案维护ToolStripMenuItem.Name = "档案维护ToolStripMenuItem"
        档案维护ToolStripMenuItem.Size = New Size(180, 22)
        档案维护ToolStripMenuItem.Text = "档案维护"
        ' 
        ' 收费管理ToolStripMenuItem
        ' 
        收费管理ToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {追加预付款ToolStripMenuItem, 用药处方费用ToolStripMenuItem, 检查治疗费用ToolStripMenuItem, 每日费用清单ToolStripMenuItem})
        收费管理ToolStripMenuItem.Name = "收费管理ToolStripMenuItem"
        收费管理ToolStripMenuItem.Size = New Size(68, 21)
        收费管理ToolStripMenuItem.Text = "收费管理"
        ' 
        ' 追加预付款ToolStripMenuItem
        ' 
        追加预付款ToolStripMenuItem.Name = "追加预付款ToolStripMenuItem"
        追加预付款ToolStripMenuItem.Size = New Size(148, 22)
        追加预付款ToolStripMenuItem.Text = "追加预付款"
        ' 
        ' 用药处方费用ToolStripMenuItem
        ' 
        用药处方费用ToolStripMenuItem.Name = "用药处方费用ToolStripMenuItem"
        用药处方费用ToolStripMenuItem.Size = New Size(148, 22)
        用药处方费用ToolStripMenuItem.Text = "用药处方费用"
        ' 
        ' 检查治疗费用ToolStripMenuItem
        ' 
        检查治疗费用ToolStripMenuItem.Name = "检查治疗费用ToolStripMenuItem"
        检查治疗费用ToolStripMenuItem.Size = New Size(148, 22)
        检查治疗费用ToolStripMenuItem.Text = "检查治疗费用"
        ' 
        ' 每日费用清单ToolStripMenuItem
        ' 
        每日费用清单ToolStripMenuItem.Name = "每日费用清单ToolStripMenuItem"
        每日费用清单ToolStripMenuItem.Size = New Size(148, 22)
        每日费用清单ToolStripMenuItem.Text = "每日费用清单"
        ' 
        ' 资料管理ToolStripMenuItem
        ' 
        资料管理ToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {药品信息添加ToolStripMenuItem, 药品信息维护ToolStripMenuItem, 检查治疗项目添加ToolStripMenuItem, 检查治疗项目维护ToolStripMenuItem1})
        资料管理ToolStripMenuItem.Name = "资料管理ToolStripMenuItem"
        资料管理ToolStripMenuItem.Size = New Size(68, 21)
        资料管理ToolStripMenuItem.Text = "资料管理"
        ' 
        ' 药品信息添加ToolStripMenuItem
        ' 
        药品信息添加ToolStripMenuItem.Name = "药品信息添加ToolStripMenuItem"
        药品信息添加ToolStripMenuItem.Size = New Size(172, 22)
        药品信息添加ToolStripMenuItem.Text = "药品信息添加"
        ' 
        ' 药品信息维护ToolStripMenuItem
        ' 
        药品信息维护ToolStripMenuItem.Name = "药品信息维护ToolStripMenuItem"
        药品信息维护ToolStripMenuItem.Size = New Size(172, 22)
        药品信息维护ToolStripMenuItem.Text = "药品信息维护"
        ' 
        ' 检查治疗项目添加ToolStripMenuItem
        ' 
        检查治疗项目添加ToolStripMenuItem.Name = "检查治疗项目添加ToolStripMenuItem"
        检查治疗项目添加ToolStripMenuItem.Size = New Size(172, 22)
        检查治疗项目添加ToolStripMenuItem.Text = "检查治疗项目添加"
        ' 
        ' 检查治疗项目维护ToolStripMenuItem1
        ' 
        检查治疗项目维护ToolStripMenuItem1.Name = "检查治疗项目维护ToolStripMenuItem1"
        检查治疗项目维护ToolStripMenuItem1.Size = New Size(172, 22)
        检查治疗项目维护ToolStripMenuItem1.Text = "检查治疗项目维护"
        ' 
        ' 流动管理ToolStripMenuItem
        ' 
        流动管理ToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {换床位ToolStripMenuItem, 转科室ToolStripMenuItem})
        流动管理ToolStripMenuItem.Name = "流动管理ToolStripMenuItem"
        流动管理ToolStripMenuItem.Size = New Size(68, 21)
        流动管理ToolStripMenuItem.Text = "流动管理"
        ' 
        ' 换床位ToolStripMenuItem
        ' 
        换床位ToolStripMenuItem.Name = "换床位ToolStripMenuItem"
        换床位ToolStripMenuItem.Size = New Size(112, 22)
        换床位ToolStripMenuItem.Text = "换床位"
        ' 
        ' 转科室ToolStripMenuItem
        ' 
        转科室ToolStripMenuItem.Name = "转科室ToolStripMenuItem"
        转科室ToolStripMenuItem.Size = New Size(112, 22)
        转科室ToolStripMenuItem.Text = "转科室"
        ' 
        ' 办理出院ToolStripMenuItem
        ' 
        办理出院ToolStripMenuItem.Name = "办理出院ToolStripMenuItem"
        办理出院ToolStripMenuItem.Size = New Size(68, 21)
        办理出院ToolStripMenuItem.Text = "办理出院"
        ' 
        ' state
        ' 
        state.AutoSize = True
        state.Location = New Point(549, 0)
        state.Name = "state"
        state.Size = New Size(44, 17)
        state.TabIndex = 11
        state.Text = "未登录"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.ErrorImage = Nothing
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.InitialImage = Nothing
        PictureBox1.Location = New Point(0, 28)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(737, 508)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 13
        PictureBox1.TabStop = False
        ' 
        ' MDIParent1
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(737, 592)
        Controls.Add(PictureBox1)
        Controls.Add(state)
        Controls.Add(StatusStrip)
        Controls.Add(MenuStrip1)
        IsMdiContainer = True
        MainMenuStrip = MenuStrip1
        Margin = New Padding(3, 4, 3, 4)
        Name = "MDIParent1"
        Text = "病人住院管理系统"
        StatusStrip.ResumeLayout(False)
        StatusStrip.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 系统管理ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 用户登录ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 添加用户ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 修改密码ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 用户退出ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 病人管理ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 住院登记ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 档案维护ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 收费管理ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 追加预付款ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 用药处方费用ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 检查治疗费用ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 每日费用清单ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 资料管理ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 药品信息添加ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 流动管理ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 办理出院ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 药品信息维护ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 检查治疗项目添加ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 换床位ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 转科室ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 检查治疗项目维护ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents state As Label
    Friend WithEvents PictureBox1 As PictureBox

End Class
