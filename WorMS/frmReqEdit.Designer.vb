<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReqEdit
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
        Me.hypHelp = New System.Windows.Forms.LinkLabel()
        Me.butHome = New System.Windows.Forms.Button()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.cmbSupplier = New System.Windows.Forms.ComboBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.lblAuthDeptManager = New System.Windows.Forms.Label()
        Me.txtAuthDeptManager = New System.Windows.Forms.TextBox()
        Me.txtNewSupplierReason = New System.Windows.Forms.TextBox()
        Me.lblNewSupplierReason = New System.Windows.Forms.Label()
        Me.txtNewSupplierBenefits = New System.Windows.Forms.TextBox()
        Me.lblNewSupplierBenefits = New System.Windows.Forms.Label()
        Me.grpResources = New System.Windows.Forms.GroupBox()
        Me.butClear_Res = New System.Windows.Forms.Button()
        Me.butRemove_Res = New System.Windows.Forms.Button()
        Me.butAdd_Res = New System.Windows.Forms.Button()
        Me.lstResourceList = New System.Windows.Forms.ListBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtOverallCost = New System.Windows.Forms.TextBox()
        Me.butSaveFinal = New System.Windows.Forms.Button()
        Me.butSaveDraft = New System.Windows.Forms.Button()
        Me.butClear_Form = New System.Windows.Forms.Button()
        Me.grpResources.SuspendLayout()
        Me.SuspendLayout()
        '
        'hypHelp
        '
        Me.hypHelp.AutoSize = True
        Me.hypHelp.Location = New System.Drawing.Point(436, 17)
        Me.hypHelp.Name = "hypHelp"
        Me.hypHelp.Size = New System.Drawing.Size(29, 13)
        Me.hypHelp.TabIndex = 4
        Me.hypHelp.TabStop = True
        Me.hypHelp.Text = "Help"
        '
        'butHome
        '
        Me.butHome.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butHome.Location = New System.Drawing.Point(12, 12)
        Me.butHome.Name = "butHome"
        Me.butHome.Size = New System.Drawing.Size(27, 23)
        Me.butHome.TabIndex = 3
        Me.butHome.Text = "⌂"
        Me.butHome.UseVisualStyleBackColor = True
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Location = New System.Drawing.Point(12, 48)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(45, 13)
        Me.lblSupplier.TabIndex = 5
        Me.lblSupplier.Text = "Supplier"
        '
        'cmbSupplier
        '
        Me.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSupplier.FormattingEnabled = True
        Me.cmbSupplier.Location = New System.Drawing.Point(63, 44)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(153, 21)
        Me.cmbSupplier.TabIndex = 6
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(12, 77)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(45, 13)
        Me.lblAddress.TabIndex = 7
        Me.lblAddress.Text = "Address"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(15, 93)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(201, 85)
        Me.txtAddress.TabIndex = 8
        '
        'lblAuthDeptManager
        '
        Me.lblAuthDeptManager.AutoSize = True
        Me.lblAuthDeptManager.Location = New System.Drawing.Point(12, 219)
        Me.lblAuthDeptManager.Name = "lblAuthDeptManager"
        Me.lblAuthDeptManager.Size = New System.Drawing.Size(128, 13)
        Me.lblAuthDeptManager.TabIndex = 9
        Me.lblAuthDeptManager.Text = "Authorised Dept Manager"
        '
        'txtAuthDeptManager
        '
        Me.txtAuthDeptManager.Location = New System.Drawing.Point(15, 236)
        Me.txtAuthDeptManager.MaxLength = 63
        Me.txtAuthDeptManager.Name = "txtAuthDeptManager"
        Me.txtAuthDeptManager.Size = New System.Drawing.Size(201, 20)
        Me.txtAuthDeptManager.TabIndex = 10
        '
        'txtNewSupplierReason
        '
        Me.txtNewSupplierReason.Location = New System.Drawing.Point(264, 60)
        Me.txtNewSupplierReason.MaxLength = 127
        Me.txtNewSupplierReason.Multiline = True
        Me.txtNewSupplierReason.Name = "txtNewSupplierReason"
        Me.txtNewSupplierReason.Size = New System.Drawing.Size(195, 70)
        Me.txtNewSupplierReason.TabIndex = 12
        '
        'lblNewSupplierReason
        '
        Me.lblNewSupplierReason.AutoSize = True
        Me.lblNewSupplierReason.Location = New System.Drawing.Point(261, 45)
        Me.lblNewSupplierReason.Name = "lblNewSupplierReason"
        Me.lblNewSupplierReason.Size = New System.Drawing.Size(126, 13)
        Me.lblNewSupplierReason.TabIndex = 11
        Me.lblNewSupplierReason.Text = "Reasons for new supplier"
        '
        'txtNewSupplierBenefits
        '
        Me.txtNewSupplierBenefits.Location = New System.Drawing.Point(264, 149)
        Me.txtNewSupplierBenefits.MaxLength = 127
        Me.txtNewSupplierBenefits.Multiline = True
        Me.txtNewSupplierBenefits.Name = "txtNewSupplierBenefits"
        Me.txtNewSupplierBenefits.Size = New System.Drawing.Size(195, 107)
        Me.txtNewSupplierBenefits.TabIndex = 14
        '
        'lblNewSupplierBenefits
        '
        Me.lblNewSupplierBenefits.AutoSize = True
        Me.lblNewSupplierBenefits.Location = New System.Drawing.Point(261, 133)
        Me.lblNewSupplierBenefits.Name = "lblNewSupplierBenefits"
        Me.lblNewSupplierBenefits.Size = New System.Drawing.Size(130, 13)
        Me.lblNewSupplierBenefits.TabIndex = 13
        Me.lblNewSupplierBenefits.Text = "Benefits from new supplier"
        '
        'grpResources
        '
        Me.grpResources.Controls.Add(Me.butClear_Res)
        Me.grpResources.Controls.Add(Me.butRemove_Res)
        Me.grpResources.Controls.Add(Me.butAdd_Res)
        Me.grpResources.Controls.Add(Me.lstResourceList)
        Me.grpResources.Location = New System.Drawing.Point(15, 272)
        Me.grpResources.Name = "grpResources"
        Me.grpResources.Size = New System.Drawing.Size(450, 158)
        Me.grpResources.TabIndex = 15
        Me.grpResources.TabStop = False
        Me.grpResources.Text = "Resources"
        '
        'butClear_Res
        '
        Me.butClear_Res.Location = New System.Drawing.Point(237, 127)
        Me.butClear_Res.Name = "butClear_Res"
        Me.butClear_Res.Size = New System.Drawing.Size(97, 23)
        Me.butClear_Res.TabIndex = 17
        Me.butClear_Res.Text = "Clear Selection"
        Me.butClear_Res.UseVisualStyleBackColor = True
        '
        'butRemove_Res
        '
        Me.butRemove_Res.Enabled = False
        Me.butRemove_Res.Location = New System.Drawing.Point(340, 127)
        Me.butRemove_Res.Name = "butRemove_Res"
        Me.butRemove_Res.Size = New System.Drawing.Size(104, 23)
        Me.butRemove_Res.TabIndex = 18
        Me.butRemove_Res.Text = "Remove Selected"
        Me.butRemove_Res.UseVisualStyleBackColor = True
        '
        'butAdd_Res
        '
        Me.butAdd_Res.Location = New System.Drawing.Point(123, 127)
        Me.butAdd_Res.Name = "butAdd_Res"
        Me.butAdd_Res.Size = New System.Drawing.Size(108, 23)
        Me.butAdd_Res.TabIndex = 16
        Me.butAdd_Res.Text = "Add New Resource"
        Me.butAdd_Res.UseVisualStyleBackColor = True
        '
        'lstResourceList
        '
        Me.lstResourceList.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstResourceList.FormattingEnabled = True
        Me.lstResourceList.ItemHeight = 14
        Me.lstResourceList.Location = New System.Drawing.Point(6, 19)
        Me.lstResourceList.Name = "lstResourceList"
        Me.lstResourceList.ScrollAlwaysVisible = True
        Me.lstResourceList.Size = New System.Drawing.Size(438, 102)
        Me.lstResourceList.TabIndex = 15
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(334, 439)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(70, 13)
        Me.lblTotal.TabIndex = 16
        Me.lblTotal.Text = "Total           £"
        '
        'txtOverallCost
        '
        Me.txtOverallCost.Location = New System.Drawing.Point(406, 436)
        Me.txtOverallCost.Name = "txtOverallCost"
        Me.txtOverallCost.ReadOnly = True
        Me.txtOverallCost.Size = New System.Drawing.Size(59, 20)
        Me.txtOverallCost.TabIndex = 17
        Me.txtOverallCost.Text = "0.00"
        '
        'butSaveFinal
        '
        Me.butSaveFinal.Location = New System.Drawing.Point(384, 463)
        Me.butSaveFinal.Name = "butSaveFinal"
        Me.butSaveFinal.Size = New System.Drawing.Size(81, 23)
        Me.butSaveFinal.TabIndex = 21
        Me.butSaveFinal.Text = "Save As Final"
        Me.butSaveFinal.UseVisualStyleBackColor = True
        '
        'butSaveDraft
        '
        Me.butSaveDraft.Location = New System.Drawing.Point(295, 463)
        Me.butSaveDraft.Name = "butSaveDraft"
        Me.butSaveDraft.Size = New System.Drawing.Size(83, 23)
        Me.butSaveDraft.TabIndex = 20
        Me.butSaveDraft.Text = "Save As Draft"
        Me.butSaveDraft.UseVisualStyleBackColor = True
        '
        'butClear_Form
        '
        Me.butClear_Form.Location = New System.Drawing.Point(208, 463)
        Me.butClear_Form.Name = "butClear_Form"
        Me.butClear_Form.Size = New System.Drawing.Size(81, 23)
        Me.butClear_Form.TabIndex = 19
        Me.butClear_Form.Text = "Clear Form"
        Me.butClear_Form.UseVisualStyleBackColor = True
        '
        'frmReqEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 496)
        Me.Controls.Add(Me.butClear_Form)
        Me.Controls.Add(Me.butSaveFinal)
        Me.Controls.Add(Me.butSaveDraft)
        Me.Controls.Add(Me.txtOverallCost)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.grpResources)
        Me.Controls.Add(Me.txtNewSupplierBenefits)
        Me.Controls.Add(Me.lblNewSupplierBenefits)
        Me.Controls.Add(Me.txtNewSupplierReason)
        Me.Controls.Add(Me.lblNewSupplierReason)
        Me.Controls.Add(Me.txtAuthDeptManager)
        Me.Controls.Add(Me.lblAuthDeptManager)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.cmbSupplier)
        Me.Controls.Add(Me.lblSupplier)
        Me.Controls.Add(Me.hypHelp)
        Me.Controls.Add(Me.butHome)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmReqEdit"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Requisition Form - WorMS"
        Me.grpResources.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents hypHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents butHome As System.Windows.Forms.Button
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents cmbSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblAuthDeptManager As System.Windows.Forms.Label
    Friend WithEvents txtAuthDeptManager As System.Windows.Forms.TextBox
    Friend WithEvents txtNewSupplierReason As System.Windows.Forms.TextBox
    Friend WithEvents lblNewSupplierReason As System.Windows.Forms.Label
    Friend WithEvents txtNewSupplierBenefits As System.Windows.Forms.TextBox
    Friend WithEvents lblNewSupplierBenefits As System.Windows.Forms.Label
    Friend WithEvents grpResources As System.Windows.Forms.GroupBox
    Friend WithEvents butClear_Res As System.Windows.Forms.Button
    Friend WithEvents butRemove_Res As System.Windows.Forms.Button
    Friend WithEvents butAdd_Res As System.Windows.Forms.Button
    Friend WithEvents lstResourceList As System.Windows.Forms.ListBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtOverallCost As System.Windows.Forms.TextBox
    Friend WithEvents butSaveFinal As System.Windows.Forms.Button
    Friend WithEvents butSaveDraft As System.Windows.Forms.Button
    Friend WithEvents butClear_Form As System.Windows.Forms.Button
End Class
