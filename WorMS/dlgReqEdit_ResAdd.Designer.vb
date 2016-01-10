<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgReqEdit_ResAdd
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
        Me.lblCatNum = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblCostPP = New System.Windows.Forms.Label()
        Me.txtCatNum = New System.Windows.Forms.TextBox()
        Me.txtCostPP = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.spnQuantity = New System.Windows.Forms.NumericUpDown()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.lblVAT = New System.Windows.Forms.Label()
        Me.txtVAT = New System.Windows.Forms.TextBox()
        Me.hypHelp = New System.Windows.Forms.LinkLabel()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.butOK = New System.Windows.Forms.Button()
        CType(Me.spnQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCatNum
        '
        Me.lblCatNum.AutoSize = True
        Me.lblCatNum.Location = New System.Drawing.Point(12, 18)
        Me.lblCatNum.Name = "lblCatNum"
        Me.lblCatNum.Size = New System.Drawing.Size(95, 13)
        Me.lblCatNum.TabIndex = 0
        Me.lblCatNum.Text = "Catalogue Number"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(12, 47)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(58, 13)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Item Name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(135, 43)
        Me.txtName.MaxLength = 63
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(147, 20)
        Me.txtName.TabIndex = 3
        '
        'lblCostPP
        '
        Me.lblCostPP.AutoSize = True
        Me.lblCostPP.Location = New System.Drawing.Point(12, 77)
        Me.lblCostPP.Name = "lblCostPP"
        Me.lblCostPP.Size = New System.Drawing.Size(117, 13)
        Me.lblCostPP.TabIndex = 4
        Me.lblCostPP.Text = "Cost per piece            £"
        '
        'txtCatNum
        '
        Me.txtCatNum.Location = New System.Drawing.Point(135, 14)
        Me.txtCatNum.MaxLength = 31
        Me.txtCatNum.Name = "txtCatNum"
        Me.txtCatNum.Size = New System.Drawing.Size(147, 20)
        Me.txtCatNum.TabIndex = 1
        '
        'txtCostPP
        '
        Me.txtCostPP.Location = New System.Drawing.Point(135, 73)
        Me.txtCostPP.Name = "txtCostPP"
        Me.txtCostPP.Size = New System.Drawing.Size(59, 20)
        Me.txtCostPP.TabIndex = 5
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(12, 109)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(46, 13)
        Me.lblQuantity.TabIndex = 6
        Me.lblQuantity.Text = "Quantity"
        '
        'spnQuantity
        '
        Me.spnQuantity.Location = New System.Drawing.Point(135, 105)
        Me.spnQuantity.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.spnQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.spnQuantity.Name = "spnQuantity"
        Me.spnQuantity.Size = New System.Drawing.Size(59, 20)
        Me.spnQuantity.TabIndex = 7
        Me.spnQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblDiscount
        '
        Me.lblDiscount.AutoSize = True
        Me.lblDiscount.Location = New System.Drawing.Point(12, 140)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Size = New System.Drawing.Size(118, 13)
        Me.lblDiscount.TabIndex = 8
        Me.lblDiscount.Text = "Discount (each)         £ "
        '
        'txtDiscount
        '
        Me.txtDiscount.Location = New System.Drawing.Point(135, 136)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Size = New System.Drawing.Size(59, 20)
        Me.txtDiscount.TabIndex = 9
        '
        'lblVAT
        '
        Me.lblVAT.AutoSize = True
        Me.lblVAT.Location = New System.Drawing.Point(12, 168)
        Me.lblVAT.Name = "lblVAT"
        Me.lblVAT.Size = New System.Drawing.Size(115, 13)
        Me.lblVAT.TabIndex = 10
        Me.lblVAT.Text = "VAT (each)                £"
        '
        'txtVAT
        '
        Me.txtVAT.Location = New System.Drawing.Point(135, 164)
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.Size = New System.Drawing.Size(59, 20)
        Me.txtVAT.TabIndex = 11
        '
        'hypHelp
        '
        Me.hypHelp.AutoSize = True
        Me.hypHelp.Location = New System.Drawing.Point(12, 203)
        Me.hypHelp.Name = "hypHelp"
        Me.hypHelp.Size = New System.Drawing.Size(29, 13)
        Me.hypHelp.TabIndex = 12
        Me.hypHelp.TabStop = True
        Me.hypHelp.Text = "Help"
        '
        'butCancel
        '
        Me.butCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(215, 203)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(67, 23)
        Me.butCancel.TabIndex = 14
        Me.butCancel.Text = "Cancel"
        '
        'butOK
        '
        Me.butOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.butOK.Location = New System.Drawing.Point(142, 203)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(67, 23)
        Me.butOK.TabIndex = 13
        Me.butOK.Text = "OK"
        '
        'dlgReqEdit_ResAdd
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(294, 237)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.hypHelp)
        Me.Controls.Add(Me.txtVAT)
        Me.Controls.Add(Me.lblVAT)
        Me.Controls.Add(Me.txtDiscount)
        Me.Controls.Add(Me.lblDiscount)
        Me.Controls.Add(Me.spnQuantity)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.txtCostPP)
        Me.Controls.Add(Me.lblCostPP)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtCatNum)
        Me.Controls.Add(Me.lblCatNum)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgReqEdit_ResAdd"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Resource to Requisition Form - WorMS"
        CType(Me.spnQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCatNum As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblCostPP As System.Windows.Forms.Label
    Friend WithEvents txtCatNum As System.Windows.Forms.TextBox
    Friend WithEvents txtCostPP As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents spnQuantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDiscount As System.Windows.Forms.Label
    Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents lblVAT As System.Windows.Forms.Label
    Friend WithEvents txtVAT As System.Windows.Forms.TextBox
    Friend WithEvents hypHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents butOK As System.Windows.Forms.Button
End Class
