<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResMan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.butHome = New System.Windows.Forms.Button()
        Me.grpCategory = New System.Windows.Forms.GroupBox()
        Me.butRemove_Cat = New System.Windows.Forms.Button()
        Me.butAdd_Cat = New System.Windows.Forms.Button()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.hypHelp = New System.Windows.Forms.LinkLabel()
        Me.grpResource = New System.Windows.Forms.GroupBox()
        Me.txtUnit_Res = New System.Windows.Forms.TextBox()
        Me.butRemove_Res = New System.Windows.Forms.Button()
        Me.butClear_Res = New System.Windows.Forms.Button()
        Me.butAdd_Res = New System.Windows.Forms.Button()
        Me.cmbStuResp_Res = New System.Windows.Forms.ComboBox()
        Me.lblStudent = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.txtMinStock_Res = New System.Windows.Forms.TextBox()
        Me.lblMinStock = New System.Windows.Forms.Label()
        Me.txtStockLeft_Res = New System.Windows.Forms.TextBox()
        Me.lblStockLeft_Res = New System.Windows.Forms.Label()
        Me.txtName_Res = New System.Windows.Forms.TextBox()
        Me.lblName_Res = New System.Windows.Forms.Label()
        Me.lstResourceList = New System.Windows.Forms.ListBox()
        Me.butViewLowStock = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.grpCategory.SuspendLayout()
        Me.grpResource.SuspendLayout()
        Me.SuspendLayout()
        '
        'butHome
        '
        Me.butHome.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butHome.Location = New System.Drawing.Point(12, 11)
        Me.butHome.Name = "butHome"
        Me.butHome.Size = New System.Drawing.Size(27, 23)
        Me.butHome.TabIndex = 0
        Me.butHome.Text = "⌂"
        Me.butHome.UseVisualStyleBackColor = True
        '
        'grpCategory
        '
        Me.grpCategory.Controls.Add(Me.butRemove_Cat)
        Me.grpCategory.Controls.Add(Me.butAdd_Cat)
        Me.grpCategory.Controls.Add(Me.cmbCategory)
        Me.grpCategory.Location = New System.Drawing.Point(12, 41)
        Me.grpCategory.Name = "grpCategory"
        Me.grpCategory.Size = New System.Drawing.Size(226, 53)
        Me.grpCategory.TabIndex = 2
        Me.grpCategory.TabStop = False
        Me.grpCategory.Text = "Select Category"
        '
        'butRemove_Cat
        '
        Me.butRemove_Cat.Location = New System.Drawing.Point(196, 19)
        Me.butRemove_Cat.Name = "butRemove_Cat"
        Me.butRemove_Cat.Size = New System.Drawing.Size(21, 21)
        Me.butRemove_Cat.TabIndex = 2
        Me.butRemove_Cat.Text = "-"
        Me.butRemove_Cat.UseVisualStyleBackColor = True
        '
        'butAdd_Cat
        '
        Me.butAdd_Cat.Location = New System.Drawing.Point(169, 19)
        Me.butAdd_Cat.Name = "butAdd_Cat"
        Me.butAdd_Cat.Size = New System.Drawing.Size(21, 21)
        Me.butAdd_Cat.TabIndex = 1
        Me.butAdd_Cat.Text = "+"
        Me.butAdd_Cat.UseVisualStyleBackColor = True
        '
        'cmbCategory
        '
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(13, 19)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(150, 21)
        Me.cmbCategory.TabIndex = 0
        '
        'hypHelp
        '
        Me.hypHelp.AutoSize = True
        Me.hypHelp.Location = New System.Drawing.Point(775, 16)
        Me.hypHelp.Name = "hypHelp"
        Me.hypHelp.Size = New System.Drawing.Size(29, 13)
        Me.hypHelp.TabIndex = 1
        Me.hypHelp.TabStop = True
        Me.hypHelp.Text = "Help"
        '
        'grpResource
        '
        Me.grpResource.Controls.Add(Me.txtUnit_Res)
        Me.grpResource.Controls.Add(Me.butRemove_Res)
        Me.grpResource.Controls.Add(Me.butClear_Res)
        Me.grpResource.Controls.Add(Me.butAdd_Res)
        Me.grpResource.Controls.Add(Me.cmbStuResp_Res)
        Me.grpResource.Controls.Add(Me.lblStudent)
        Me.grpResource.Controls.Add(Me.lblUnit)
        Me.grpResource.Controls.Add(Me.txtMinStock_Res)
        Me.grpResource.Controls.Add(Me.lblMinStock)
        Me.grpResource.Controls.Add(Me.txtStockLeft_Res)
        Me.grpResource.Controls.Add(Me.lblStockLeft_Res)
        Me.grpResource.Controls.Add(Me.txtName_Res)
        Me.grpResource.Controls.Add(Me.lblName_Res)
        Me.grpResource.Location = New System.Drawing.Point(12, 101)
        Me.grpResource.Name = "grpResource"
        Me.grpResource.Size = New System.Drawing.Size(226, 224)
        Me.grpResource.TabIndex = 3
        Me.grpResource.TabStop = False
        Me.grpResource.Text = "Select Resource"
        '
        'txtUnit_Res
        '
        Me.txtUnit_Res.Location = New System.Drawing.Point(142, 107)
        Me.txtUnit_Res.MaxLength = 10
        Me.txtUnit_Res.Name = "txtUnit_Res"
        Me.txtUnit_Res.Size = New System.Drawing.Size(72, 20)
        Me.txtUnit_Res.TabIndex = 7
        '
        'butRemove_Res
        '
        Me.butRemove_Res.Location = New System.Drawing.Point(154, 190)
        Me.butRemove_Res.Name = "butRemove_Res"
        Me.butRemove_Res.Size = New System.Drawing.Size(60, 23)
        Me.butRemove_Res.TabIndex = 12
        Me.butRemove_Res.Text = "Remove"
        Me.butRemove_Res.UseVisualStyleBackColor = True
        '
        'butClear_Res
        '
        Me.butClear_Res.Location = New System.Drawing.Point(80, 190)
        Me.butClear_Res.Name = "butClear_Res"
        Me.butClear_Res.Size = New System.Drawing.Size(61, 23)
        Me.butClear_Res.TabIndex = 11
        Me.butClear_Res.Text = "Clear"
        Me.butClear_Res.UseVisualStyleBackColor = True
        '
        'butAdd_Res
        '
        Me.butAdd_Res.Location = New System.Drawing.Point(13, 190)
        Me.butAdd_Res.Name = "butAdd_Res"
        Me.butAdd_Res.Size = New System.Drawing.Size(52, 23)
        Me.butAdd_Res.TabIndex = 10
        Me.butAdd_Res.Text = "Add"
        Me.butAdd_Res.UseVisualStyleBackColor = True
        '
        'cmbStuResp_Res
        '
        Me.cmbStuResp_Res.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStuResp_Res.FormattingEnabled = True
        Me.cmbStuResp_Res.Items.AddRange(New Object() {"None"})
        Me.cmbStuResp_Res.Location = New System.Drawing.Point(13, 154)
        Me.cmbStuResp_Res.Name = "cmbStuResp_Res"
        Me.cmbStuResp_Res.Size = New System.Drawing.Size(201, 21)
        Me.cmbStuResp_Res.TabIndex = 9
        '
        'lblStudent
        '
        Me.lblStudent.AutoSize = True
        Me.lblStudent.Location = New System.Drawing.Point(11, 138)
        Me.lblStudent.Name = "lblStudent"
        Me.lblStudent.Size = New System.Drawing.Size(108, 13)
        Me.lblStudent.TabIndex = 8
        Me.lblStudent.Text = "Student Responsible:"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(11, 110)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(26, 13)
        Me.lblUnit.TabIndex = 6
        Me.lblUnit.Text = "Unit"
        '
        'txtMinStock_Res
        '
        Me.txtMinStock_Res.Location = New System.Drawing.Point(167, 79)
        Me.txtMinStock_Res.Name = "txtMinStock_Res"
        Me.txtMinStock_Res.Size = New System.Drawing.Size(47, 20)
        Me.txtMinStock_Res.TabIndex = 5
        '
        'lblMinStock
        '
        Me.lblMinStock.AutoSize = True
        Me.lblMinStock.Location = New System.Drawing.Point(10, 82)
        Me.lblMinStock.Name = "lblMinStock"
        Me.lblMinStock.Size = New System.Drawing.Size(55, 13)
        Me.lblMinStock.TabIndex = 4
        Me.lblMinStock.Text = "Min Stock"
        '
        'txtStockLeft_Res
        '
        Me.txtStockLeft_Res.Location = New System.Drawing.Point(167, 50)
        Me.txtStockLeft_Res.Name = "txtStockLeft_Res"
        Me.txtStockLeft_Res.Size = New System.Drawing.Size(47, 20)
        Me.txtStockLeft_Res.TabIndex = 3
        '
        'lblStockLeft_Res
        '
        Me.lblStockLeft_Res.AutoSize = True
        Me.lblStockLeft_Res.Location = New System.Drawing.Point(10, 53)
        Me.lblStockLeft_Res.Name = "lblStockLeft_Res"
        Me.lblStockLeft_Res.Size = New System.Drawing.Size(56, 13)
        Me.lblStockLeft_Res.TabIndex = 2
        Me.lblStockLeft_Res.Text = "Stock Left"
        '
        'txtName_Res
        '
        Me.txtName_Res.Location = New System.Drawing.Point(71, 21)
        Me.txtName_Res.MaxLength = 63
        Me.txtName_Res.Name = "txtName_Res"
        Me.txtName_Res.Size = New System.Drawing.Size(143, 20)
        Me.txtName_Res.TabIndex = 1
        '
        'lblName_Res
        '
        Me.lblName_Res.AutoSize = True
        Me.lblName_Res.Location = New System.Drawing.Point(10, 25)
        Me.lblName_Res.Name = "lblName_Res"
        Me.lblName_Res.Size = New System.Drawing.Size(35, 13)
        Me.lblName_Res.TabIndex = 0
        Me.lblName_Res.Text = "Name"
        '
        'lstResourceList
        '
        Me.lstResourceList.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstResourceList.FormattingEnabled = True
        Me.lstResourceList.ItemHeight = 14
        Me.lstResourceList.Location = New System.Drawing.Point(244, 44)
        Me.lstResourceList.Name = "lstResourceList"
        Me.lstResourceList.ScrollAlwaysVisible = True
        Me.lstResourceList.Size = New System.Drawing.Size(560, 242)
        Me.lstResourceList.TabIndex = 13
        '
        'butViewLowStock
        '
        Me.butViewLowStock.Location = New System.Drawing.Point(698, 302)
        Me.butViewLowStock.Name = "butViewLowStock"
        Me.butViewLowStock.Size = New System.Drawing.Size(106, 23)
        Me.butViewLowStock.TabIndex = 14
        Me.butViewLowStock.Text = "View Low Stock"
        Me.butViewLowStock.UseVisualStyleBackColor = True
        '
        'frmResMan
        '
        Me.AcceptButton = Me.butAdd_Res
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 335)
        Me.Controls.Add(Me.butViewLowStock)
        Me.Controls.Add(Me.lstResourceList)
        Me.Controls.Add(Me.grpResource)
        Me.Controls.Add(Me.hypHelp)
        Me.Controls.Add(Me.grpCategory)
        Me.Controls.Add(Me.butHome)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmResMan"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Resources - WorMS"
        Me.grpCategory.ResumeLayout(False)
        Me.grpResource.ResumeLayout(False)
        Me.grpResource.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butHome As System.Windows.Forms.Button
    Friend WithEvents grpCategory As System.Windows.Forms.GroupBox
    Friend WithEvents butRemove_Cat As System.Windows.Forms.Button
    Friend WithEvents butAdd_Cat As System.Windows.Forms.Button
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents hypHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents grpResource As System.Windows.Forms.GroupBox
    Friend WithEvents butRemove_Res As System.Windows.Forms.Button
    Friend WithEvents butClear_Res As System.Windows.Forms.Button
    Friend WithEvents butAdd_Res As System.Windows.Forms.Button
    Friend WithEvents cmbStuResp_Res As System.Windows.Forms.ComboBox
    Friend WithEvents lblStudent As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents txtMinStock_Res As System.Windows.Forms.TextBox
    Friend WithEvents lblMinStock As System.Windows.Forms.Label
    Friend WithEvents txtStockLeft_Res As System.Windows.Forms.TextBox
    Friend WithEvents lblStockLeft_Res As System.Windows.Forms.Label
    Friend WithEvents txtName_Res As System.Windows.Forms.TextBox
    Friend WithEvents lblName_Res As System.Windows.Forms.Label
    Friend WithEvents lstResourceList As System.Windows.Forms.ListBox
    Friend WithEvents butViewLowStock As System.Windows.Forms.Button
    Friend WithEvents txtUnit_Res As System.Windows.Forms.TextBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
