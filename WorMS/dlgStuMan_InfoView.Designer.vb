<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgStuMan_InfoView
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
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.cmbLevel = New System.Windows.Forms.ComboBox()
        Me.lblCostOwed = New System.Windows.Forms.Label()
        Me.txtCostOwed = New System.Windows.Forms.TextBox()
        Me.blpPaid_Yes = New System.Windows.Forms.RadioButton()
        Me.blpPaid_No = New System.Windows.Forms.RadioButton()
        Me.grpResources = New System.Windows.Forms.GroupBox()
        Me.butRemove_Res = New System.Windows.Forms.Button()
        Me.butClear_Res = New System.Windows.Forms.Button()
        Me.lstResources = New System.Windows.Forms.ListBox()
        Me.butOK = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.hypHelp = New System.Windows.Forms.LinkLabel()
        Me.grpPaid = New System.Windows.Forms.GroupBox()
        Me.grpPrinted = New System.Windows.Forms.GroupBox()
        Me.blpPrinted_No = New System.Windows.Forms.RadioButton()
        Me.blpPrinted_Yes = New System.Windows.Forms.RadioButton()
        Me.grpResources.SuspendLayout()
        Me.grpPaid.SuspendLayout()
        Me.grpPrinted.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(49, 18)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(143, 15)
        Me.txtName.MaxLength = 63
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(176, 20)
        Me.txtName.TabIndex = 1
        '
        'lblLevel
        '
        Me.lblLevel.AutoSize = True
        Me.lblLevel.Location = New System.Drawing.Point(49, 50)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(33, 13)
        Me.lblLevel.TabIndex = 2
        Me.lblLevel.Text = "Level"
        '
        'cmbLevel
        '
        Me.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLevel.FormattingEnabled = True
        Me.cmbLevel.Items.AddRange(New Object() {"AS", "A2"})
        Me.cmbLevel.Location = New System.Drawing.Point(143, 47)
        Me.cmbLevel.MaxDropDownItems = 2
        Me.cmbLevel.Name = "cmbLevel"
        Me.cmbLevel.Size = New System.Drawing.Size(70, 21)
        Me.cmbLevel.TabIndex = 3
        '
        'lblCostOwed
        '
        Me.lblCostOwed.AutoSize = True
        Me.lblCostOwed.Location = New System.Drawing.Point(49, 82)
        Me.lblCostOwed.Name = "lblCostOwed"
        Me.lblCostOwed.Size = New System.Drawing.Size(89, 13)
        Me.lblCostOwed.TabIndex = 4
        Me.lblCostOwed.Text = "Cost Owed        £"
        '
        'txtCostOwed
        '
        Me.txtCostOwed.Location = New System.Drawing.Point(143, 79)
        Me.txtCostOwed.Name = "txtCostOwed"
        Me.txtCostOwed.Size = New System.Drawing.Size(70, 20)
        Me.txtCostOwed.TabIndex = 5
        '
        'blpPaid_Yes
        '
        Me.blpPaid_Yes.AutoSize = True
        Me.blpPaid_Yes.Location = New System.Drawing.Point(70, 11)
        Me.blpPaid_Yes.Name = "blpPaid_Yes"
        Me.blpPaid_Yes.Size = New System.Drawing.Size(43, 17)
        Me.blpPaid_Yes.TabIndex = 7
        Me.blpPaid_Yes.TabStop = True
        Me.blpPaid_Yes.Text = "Yes"
        Me.blpPaid_Yes.UseVisualStyleBackColor = True
        '
        'blpPaid_No
        '
        Me.blpPaid_No.AutoSize = True
        Me.blpPaid_No.Location = New System.Drawing.Point(162, 11)
        Me.blpPaid_No.Name = "blpPaid_No"
        Me.blpPaid_No.Size = New System.Drawing.Size(39, 17)
        Me.blpPaid_No.TabIndex = 8
        Me.blpPaid_No.TabStop = True
        Me.blpPaid_No.Text = "No"
        Me.blpPaid_No.UseVisualStyleBackColor = True
        '
        'grpResources
        '
        Me.grpResources.Controls.Add(Me.butRemove_Res)
        Me.grpResources.Controls.Add(Me.butClear_Res)
        Me.grpResources.Controls.Add(Me.lstResources)
        Me.grpResources.Location = New System.Drawing.Point(13, 181)
        Me.grpResources.Name = "grpResources"
        Me.grpResources.Size = New System.Drawing.Size(352, 205)
        Me.grpResources.TabIndex = 12
        Me.grpResources.TabStop = False
        Me.grpResources.Text = "Resources"
        '
        'butRemove_Res
        '
        Me.butRemove_Res.Location = New System.Drawing.Point(276, 172)
        Me.butRemove_Res.Name = "butRemove_Res"
        Me.butRemove_Res.Size = New System.Drawing.Size(67, 23)
        Me.butRemove_Res.TabIndex = 15
        Me.butRemove_Res.Text = "Remove"
        Me.butRemove_Res.UseVisualStyleBackColor = True
        '
        'butClear_Res
        '
        Me.butClear_Res.Location = New System.Drawing.Point(217, 172)
        Me.butClear_Res.Name = "butClear_Res"
        Me.butClear_Res.Size = New System.Drawing.Size(53, 23)
        Me.butClear_Res.TabIndex = 14
        Me.butClear_Res.Text = "Clear"
        Me.butClear_Res.UseVisualStyleBackColor = True
        '
        'lstResources
        '
        Me.lstResources.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstResources.FormattingEnabled = True
        Me.lstResources.ItemHeight = 14
        Me.lstResources.Location = New System.Drawing.Point(10, 19)
        Me.lstResources.Name = "lstResources"
        Me.lstResources.ScrollAlwaysVisible = True
        Me.lstResources.Size = New System.Drawing.Size(333, 144)
        Me.lstResources.TabIndex = 13
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(219, 396)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(70, 23)
        Me.butOK.TabIndex = 17
        Me.butOK.Text = "OK"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(295, 396)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(70, 23)
        Me.butCancel.TabIndex = 18
        Me.butCancel.Text = "Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'hypHelp
        '
        Me.hypHelp.AutoSize = True
        Me.hypHelp.Location = New System.Drawing.Point(12, 400)
        Me.hypHelp.Name = "hypHelp"
        Me.hypHelp.Size = New System.Drawing.Size(29, 13)
        Me.hypHelp.TabIndex = 16
        Me.hypHelp.TabStop = True
        Me.hypHelp.Text = "Help"
        '
        'grpPaid
        '
        Me.grpPaid.Controls.Add(Me.blpPaid_No)
        Me.grpPaid.Controls.Add(Me.blpPaid_Yes)
        Me.grpPaid.Location = New System.Drawing.Point(52, 105)
        Me.grpPaid.Name = "grpPaid"
        Me.grpPaid.Size = New System.Drawing.Size(267, 33)
        Me.grpPaid.TabIndex = 6
        Me.grpPaid.TabStop = False
        Me.grpPaid.Text = "Paid?"
        '
        'grpPrinted
        '
        Me.grpPrinted.Controls.Add(Me.blpPrinted_No)
        Me.grpPrinted.Controls.Add(Me.blpPrinted_Yes)
        Me.grpPrinted.Location = New System.Drawing.Point(52, 144)
        Me.grpPrinted.Name = "grpPrinted"
        Me.grpPrinted.Size = New System.Drawing.Size(267, 33)
        Me.grpPrinted.TabIndex = 9
        Me.grpPrinted.TabStop = False
        Me.grpPrinted.Text = "Receipt Printed?"
        '
        'blpPrinted_No
        '
        Me.blpPrinted_No.AutoSize = True
        Me.blpPrinted_No.Location = New System.Drawing.Point(162, 11)
        Me.blpPrinted_No.Name = "blpPrinted_No"
        Me.blpPrinted_No.Size = New System.Drawing.Size(39, 17)
        Me.blpPrinted_No.TabIndex = 11
        Me.blpPrinted_No.TabStop = True
        Me.blpPrinted_No.Text = "No"
        Me.blpPrinted_No.UseVisualStyleBackColor = True
        '
        'blpPrinted_Yes
        '
        Me.blpPrinted_Yes.AutoSize = True
        Me.blpPrinted_Yes.Location = New System.Drawing.Point(70, 11)
        Me.blpPrinted_Yes.Name = "blpPrinted_Yes"
        Me.blpPrinted_Yes.Size = New System.Drawing.Size(43, 17)
        Me.blpPrinted_Yes.TabIndex = 10
        Me.blpPrinted_Yes.TabStop = True
        Me.blpPrinted_Yes.Text = "Yes"
        Me.blpPrinted_Yes.UseVisualStyleBackColor = True
        '
        'dlgStuMan_InfoView
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(376, 431)
        Me.Controls.Add(Me.grpPrinted)
        Me.Controls.Add(Me.grpPaid)
        Me.Controls.Add(Me.hypHelp)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.grpResources)
        Me.Controls.Add(Me.txtCostOwed)
        Me.Controls.Add(Me.lblCostOwed)
        Me.Controls.Add(Me.cmbLevel)
        Me.Controls.Add(Me.lblLevel)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgStuMan_InfoView"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Student - WorMS"
        Me.grpResources.ResumeLayout(False)
        Me.grpPaid.ResumeLayout(False)
        Me.grpPaid.PerformLayout()
        Me.grpPrinted.ResumeLayout(False)
        Me.grpPrinted.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents cmbLevel As System.Windows.Forms.ComboBox
    Friend WithEvents lblCostOwed As System.Windows.Forms.Label
    Friend WithEvents txtCostOwed As System.Windows.Forms.TextBox
    Friend WithEvents blpPaid_Yes As System.Windows.Forms.RadioButton
    Friend WithEvents blpPaid_No As System.Windows.Forms.RadioButton
    Friend WithEvents grpResources As System.Windows.Forms.GroupBox
    Friend WithEvents butRemove_Res As System.Windows.Forms.Button
    Friend WithEvents butClear_Res As System.Windows.Forms.Button
    Friend WithEvents lstResources As System.Windows.Forms.ListBox
    Friend WithEvents butOK As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents hypHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents grpPaid As System.Windows.Forms.GroupBox
    Friend WithEvents grpPrinted As System.Windows.Forms.GroupBox
    Friend WithEvents blpPrinted_No As System.Windows.Forms.RadioButton
    Friend WithEvents blpPrinted_Yes As System.Windows.Forms.RadioButton

End Class
