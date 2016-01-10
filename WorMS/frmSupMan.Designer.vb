<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupMan
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
        Me.grpSupplier = New System.Windows.Forms.GroupBox()
        Me.butRemove = New System.Windows.Forms.Button()
        Me.butClear = New System.Windows.Forms.Button()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.butAdd = New System.Windows.Forms.Button()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.spnTimesUsed = New System.Windows.Forms.NumericUpDown()
        Me.lblTimesUsed = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lstSuppliersList = New System.Windows.Forms.ListBox()
        Me.grpSupplier.SuspendLayout()
        CType(Me.spnTimesUsed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'hypHelp
        '
        Me.hypHelp.AutoSize = True
        Me.hypHelp.Location = New System.Drawing.Point(572, 17)
        Me.hypHelp.Name = "hypHelp"
        Me.hypHelp.Size = New System.Drawing.Size(29, 13)
        Me.hypHelp.TabIndex = 6
        Me.hypHelp.TabStop = True
        Me.hypHelp.Text = "Help"
        '
        'butHome
        '
        Me.butHome.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butHome.Location = New System.Drawing.Point(12, 12)
        Me.butHome.Name = "butHome"
        Me.butHome.Size = New System.Drawing.Size(27, 23)
        Me.butHome.TabIndex = 5
        Me.butHome.Text = "⌂"
        Me.butHome.UseVisualStyleBackColor = True
        '
        'grpSupplier
        '
        Me.grpSupplier.Controls.Add(Me.butRemove)
        Me.grpSupplier.Controls.Add(Me.butClear)
        Me.grpSupplier.Controls.Add(Me.txtAddress)
        Me.grpSupplier.Controls.Add(Me.butAdd)
        Me.grpSupplier.Controls.Add(Me.lblAddress)
        Me.grpSupplier.Controls.Add(Me.spnTimesUsed)
        Me.grpSupplier.Controls.Add(Me.lblTimesUsed)
        Me.grpSupplier.Controls.Add(Me.txtName)
        Me.grpSupplier.Controls.Add(Me.lblName)
        Me.grpSupplier.Location = New System.Drawing.Point(12, 41)
        Me.grpSupplier.Name = "grpSupplier"
        Me.grpSupplier.Size = New System.Drawing.Size(223, 222)
        Me.grpSupplier.TabIndex = 7
        Me.grpSupplier.TabStop = False
        Me.grpSupplier.Text = "Select Supplier"
        '
        'butRemove
        '
        Me.butRemove.Location = New System.Drawing.Point(151, 188)
        Me.butRemove.Name = "butRemove"
        Me.butRemove.Size = New System.Drawing.Size(60, 23)
        Me.butRemove.TabIndex = 15
        Me.butRemove.Text = "Remove"
        Me.butRemove.UseVisualStyleBackColor = True
        '
        'butClear
        '
        Me.butClear.Location = New System.Drawing.Point(79, 188)
        Me.butClear.Name = "butClear"
        Me.butClear.Size = New System.Drawing.Size(59, 23)
        Me.butClear.TabIndex = 14
        Me.butClear.Text = "Clear"
        Me.butClear.UseVisualStyleBackColor = True
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(10, 97)
        Me.txtAddress.MaxLength = 127
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(201, 85)
        Me.txtAddress.TabIndex = 10
        '
        'butAdd
        '
        Me.butAdd.Location = New System.Drawing.Point(10, 188)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(52, 23)
        Me.butAdd.TabIndex = 13
        Me.butAdd.Text = "Add"
        Me.butAdd.UseVisualStyleBackColor = True
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(7, 81)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(45, 13)
        Me.lblAddress.TabIndex = 9
        Me.lblAddress.Text = "Address"
        '
        'spnTimesUsed
        '
        Me.spnTimesUsed.Location = New System.Drawing.Point(161, 50)
        Me.spnTimesUsed.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.spnTimesUsed.Name = "spnTimesUsed"
        Me.spnTimesUsed.Size = New System.Drawing.Size(50, 20)
        Me.spnTimesUsed.TabIndex = 5
        '
        'lblTimesUsed
        '
        Me.lblTimesUsed.AutoSize = True
        Me.lblTimesUsed.Location = New System.Drawing.Point(7, 52)
        Me.lblTimesUsed.Name = "lblTimesUsed"
        Me.lblTimesUsed.Size = New System.Drawing.Size(63, 13)
        Me.lblTimesUsed.TabIndex = 4
        Me.lblTimesUsed.Text = "Times Used"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(52, 19)
        Me.txtName.MaxLength = 63
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(159, 20)
        Me.txtName.TabIndex = 3
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(7, 22)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Name"
        '
        'lstSuppliersList
        '
        Me.lstSuppliersList.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSuppliersList.FormattingEnabled = True
        Me.lstSuppliersList.ItemHeight = 14
        Me.lstSuppliersList.Location = New System.Drawing.Point(251, 49)
        Me.lstSuppliersList.Name = "lstSuppliersList"
        Me.lstSuppliersList.ScrollAlwaysVisible = True
        Me.lstSuppliersList.Size = New System.Drawing.Size(350, 214)
        Me.lstSuppliersList.TabIndex = 14
        '
        'frmSupMan
        '
        Me.AcceptButton = Me.butAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 277)
        Me.Controls.Add(Me.lstSuppliersList)
        Me.Controls.Add(Me.grpSupplier)
        Me.Controls.Add(Me.hypHelp)
        Me.Controls.Add(Me.butHome)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmSupMan"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Suppliers - WorMS"
        Me.grpSupplier.ResumeLayout(False)
        Me.grpSupplier.PerformLayout()
        CType(Me.spnTimesUsed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents hypHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents butHome As System.Windows.Forms.Button
    Friend WithEvents grpSupplier As System.Windows.Forms.GroupBox
    Friend WithEvents spnTimesUsed As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTimesUsed As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents butRemove As System.Windows.Forms.Button
    Friend WithEvents butClear As System.Windows.Forms.Button
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents lstSuppliersList As System.Windows.Forms.ListBox
End Class
