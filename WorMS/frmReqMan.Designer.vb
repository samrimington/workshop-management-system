<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReqMan
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
        Me.hypHelp = New System.Windows.Forms.LinkLabel()
        Me.grpType = New System.Windows.Forms.GroupBox()
        Me.blpDrafts = New System.Windows.Forms.RadioButton()
        Me.blpUnprinted = New System.Windows.Forms.RadioButton()
        Me.blpPrinted = New System.Windows.Forms.RadioButton()
        Me.lstReqFormsList = New System.Windows.Forms.ListBox()
        Me.butChange = New System.Windows.Forms.Button()
        Me.butExport = New System.Windows.Forms.Button()
        Me.butRemove = New System.Windows.Forms.Button()
        Me.grpType.SuspendLayout()
        Me.SuspendLayout()
        '
        'butHome
        '
        Me.butHome.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butHome.Location = New System.Drawing.Point(12, 12)
        Me.butHome.Name = "butHome"
        Me.butHome.Size = New System.Drawing.Size(27, 23)
        Me.butHome.TabIndex = 1
        Me.butHome.Text = "⌂"
        Me.butHome.UseVisualStyleBackColor = True
        '
        'hypHelp
        '
        Me.hypHelp.AutoSize = True
        Me.hypHelp.Location = New System.Drawing.Point(342, 18)
        Me.hypHelp.Name = "hypHelp"
        Me.hypHelp.Size = New System.Drawing.Size(29, 13)
        Me.hypHelp.TabIndex = 2
        Me.hypHelp.TabStop = True
        Me.hypHelp.Text = "Help"
        '
        'grpType
        '
        Me.grpType.Controls.Add(Me.blpDrafts)
        Me.grpType.Controls.Add(Me.blpUnprinted)
        Me.grpType.Controls.Add(Me.blpPrinted)
        Me.grpType.Location = New System.Drawing.Point(12, 41)
        Me.grpType.Name = "grpType"
        Me.grpType.Size = New System.Drawing.Size(356, 49)
        Me.grpType.TabIndex = 3
        Me.grpType.TabStop = False
        Me.grpType.Text = "Select Type"
        '
        'blpDrafts
        '
        Me.blpDrafts.AutoSize = True
        Me.blpDrafts.Location = New System.Drawing.Point(265, 19)
        Me.blpDrafts.Name = "blpDrafts"
        Me.blpDrafts.Size = New System.Drawing.Size(53, 17)
        Me.blpDrafts.TabIndex = 2
        Me.blpDrafts.Text = "Drafts"
        Me.blpDrafts.UseVisualStyleBackColor = True
        '
        'blpUnprinted
        '
        Me.blpUnprinted.AutoSize = True
        Me.blpUnprinted.Location = New System.Drawing.Point(140, 19)
        Me.blpUnprinted.Name = "blpUnprinted"
        Me.blpUnprinted.Size = New System.Drawing.Size(71, 17)
        Me.blpUnprinted.TabIndex = 1
        Me.blpUnprinted.Text = "Unprinted"
        Me.blpUnprinted.UseVisualStyleBackColor = True
        '
        'blpPrinted
        '
        Me.blpPrinted.AutoSize = True
        Me.blpPrinted.Location = New System.Drawing.Point(32, 19)
        Me.blpPrinted.Name = "blpPrinted"
        Me.blpPrinted.Size = New System.Drawing.Size(58, 17)
        Me.blpPrinted.TabIndex = 0
        Me.blpPrinted.Text = "Printed"
        Me.blpPrinted.UseVisualStyleBackColor = True
        '
        'lstReqFormsList
        '
        Me.lstReqFormsList.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstReqFormsList.FormattingEnabled = True
        Me.lstReqFormsList.ItemHeight = 14
        Me.lstReqFormsList.Location = New System.Drawing.Point(12, 96)
        Me.lstReqFormsList.Name = "lstReqFormsList"
        Me.lstReqFormsList.ScrollAlwaysVisible = True
        Me.lstReqFormsList.Size = New System.Drawing.Size(356, 242)
        Me.lstReqFormsList.TabIndex = 14
        '
        'butChange
        '
        Me.butChange.Enabled = False
        Me.butChange.Location = New System.Drawing.Point(110, 344)
        Me.butChange.Name = "butChange"
        Me.butChange.Size = New System.Drawing.Size(75, 23)
        Me.butChange.TabIndex = 15
        Me.butChange.Text = "Reuse"
        Me.butChange.UseVisualStyleBackColor = True
        '
        'butExport
        '
        Me.butExport.Enabled = False
        Me.butExport.Location = New System.Drawing.Point(191, 344)
        Me.butExport.Name = "butExport"
        Me.butExport.Size = New System.Drawing.Size(99, 23)
        Me.butExport.TabIndex = 16
        Me.butExport.Text = "Export to Excel"
        Me.butExport.UseVisualStyleBackColor = True
        '
        'butRemove
        '
        Me.butRemove.Enabled = False
        Me.butRemove.Location = New System.Drawing.Point(296, 344)
        Me.butRemove.Name = "butRemove"
        Me.butRemove.Size = New System.Drawing.Size(75, 23)
        Me.butRemove.TabIndex = 17
        Me.butRemove.Text = "Remove"
        Me.butRemove.UseVisualStyleBackColor = True
        '
        'frmReqMan
        '
        Me.AcceptButton = Me.butChange
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 378)
        Me.Controls.Add(Me.butRemove)
        Me.Controls.Add(Me.butExport)
        Me.Controls.Add(Me.butChange)
        Me.Controls.Add(Me.lstReqFormsList)
        Me.Controls.Add(Me.grpType)
        Me.Controls.Add(Me.hypHelp)
        Me.Controls.Add(Me.butHome)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmReqMan"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Saved Requisition Forms - WorMS"
        Me.grpType.ResumeLayout(False)
        Me.grpType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butHome As System.Windows.Forms.Button
    Friend WithEvents hypHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents grpType As System.Windows.Forms.GroupBox
    Friend WithEvents blpDrafts As System.Windows.Forms.RadioButton
    Friend WithEvents blpUnprinted As System.Windows.Forms.RadioButton
    Friend WithEvents blpPrinted As System.Windows.Forms.RadioButton
    Friend WithEvents lstReqFormsList As System.Windows.Forms.ListBox
    Friend WithEvents butChange As System.Windows.Forms.Button
    Friend WithEvents butExport As System.Windows.Forms.Button
    Friend WithEvents butRemove As System.Windows.Forms.Button
End Class
