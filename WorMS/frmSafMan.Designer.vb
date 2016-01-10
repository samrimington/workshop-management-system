<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSafMan
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
        Me.grpRecords = New System.Windows.Forms.GroupBox()
        Me.butRemove = New System.Windows.Forms.Button()
        Me.butClear = New System.Windows.Forms.Button()
        Me.butAdd = New System.Windows.Forms.Button()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.lblDateOfCheck = New System.Windows.Forms.Label()
        Me.dtpDateOfCheck = New System.Windows.Forms.DateTimePicker()
        Me.lstRecords = New System.Windows.Forms.ListBox()
        Me.butPrintSheets = New System.Windows.Forms.Button()
        Me.butPrintRecs = New System.Windows.Forms.Button()
        Me.lblPickRecord = New System.Windows.Forms.Label()
        Me.pntTestRecords = New System.Drawing.Printing.PrintDocument()
        Me.pntBlankSheets = New System.Drawing.Printing.PrintDocument()
        Me.grpRecords.SuspendLayout()
        Me.SuspendLayout()
        '
        'hypHelp
        '
        Me.hypHelp.AutoSize = True
        Me.hypHelp.Location = New System.Drawing.Point(386, 17)
        Me.hypHelp.Name = "hypHelp"
        Me.hypHelp.Size = New System.Drawing.Size(29, 13)
        Me.hypHelp.TabIndex = 10
        Me.hypHelp.TabStop = True
        Me.hypHelp.Text = "Help"
        '
        'butHome
        '
        Me.butHome.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butHome.Location = New System.Drawing.Point(12, 12)
        Me.butHome.Name = "butHome"
        Me.butHome.Size = New System.Drawing.Size(27, 23)
        Me.butHome.TabIndex = 9
        Me.butHome.Text = "⌂"
        Me.butHome.UseVisualStyleBackColor = True
        '
        'grpRecords
        '
        Me.grpRecords.Controls.Add(Me.butRemove)
        Me.grpRecords.Controls.Add(Me.butClear)
        Me.grpRecords.Controls.Add(Me.butAdd)
        Me.grpRecords.Controls.Add(Me.txtComments)
        Me.grpRecords.Controls.Add(Me.lblComments)
        Me.grpRecords.Controls.Add(Me.lblDateOfCheck)
        Me.grpRecords.Controls.Add(Me.dtpDateOfCheck)
        Me.grpRecords.Location = New System.Drawing.Point(12, 41)
        Me.grpRecords.Name = "grpRecords"
        Me.grpRecords.Size = New System.Drawing.Size(197, 232)
        Me.grpRecords.TabIndex = 11
        Me.grpRecords.TabStop = False
        Me.grpRecords.Text = "Select Record"
        '
        'butRemove
        '
        Me.butRemove.Location = New System.Drawing.Point(118, 198)
        Me.butRemove.Name = "butRemove"
        Me.butRemove.Size = New System.Drawing.Size(63, 23)
        Me.butRemove.TabIndex = 6
        Me.butRemove.Text = "Remove"
        Me.butRemove.UseVisualStyleBackColor = True
        '
        'butClear
        '
        Me.butClear.Location = New System.Drawing.Point(65, 198)
        Me.butClear.Name = "butClear"
        Me.butClear.Size = New System.Drawing.Size(47, 23)
        Me.butClear.TabIndex = 5
        Me.butClear.Text = "Clear"
        Me.butClear.UseVisualStyleBackColor = True
        '
        'butAdd
        '
        Me.butAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butAdd.Location = New System.Drawing.Point(13, 198)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(46, 23)
        Me.butAdd.TabIndex = 4
        Me.butAdd.Text = "Add"
        Me.butAdd.UseVisualStyleBackColor = True
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(13, 68)
        Me.txtComments.MaxLength = 255
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(168, 123)
        Me.txtComments.TabIndex = 3
        '
        'lblComments
        '
        Me.lblComments.AutoSize = True
        Me.lblComments.Location = New System.Drawing.Point(10, 52)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(56, 13)
        Me.lblComments.TabIndex = 2
        Me.lblComments.Text = "Comments"
        '
        'lblDateOfCheck
        '
        Me.lblDateOfCheck.AutoSize = True
        Me.lblDateOfCheck.Location = New System.Drawing.Point(10, 23)
        Me.lblDateOfCheck.Name = "lblDateOfCheck"
        Me.lblDateOfCheck.Size = New System.Drawing.Size(30, 13)
        Me.lblDateOfCheck.TabIndex = 1
        Me.lblDateOfCheck.Text = "Date"
        '
        'dtpDateOfCheck
        '
        Me.dtpDateOfCheck.Location = New System.Drawing.Point(46, 19)
        Me.dtpDateOfCheck.Name = "dtpDateOfCheck"
        Me.dtpDateOfCheck.Size = New System.Drawing.Size(135, 20)
        Me.dtpDateOfCheck.TabIndex = 0
        '
        'lstRecords
        '
        Me.lstRecords.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstRecords.FormattingEnabled = True
        Me.lstRecords.ItemHeight = 14
        Me.lstRecords.Location = New System.Drawing.Point(220, 60)
        Me.lstRecords.Name = "lstRecords"
        Me.lstRecords.ScrollAlwaysVisible = True
        Me.lstRecords.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstRecords.Size = New System.Drawing.Size(195, 186)
        Me.lstRecords.TabIndex = 15
        '
        'butPrintSheets
        '
        Me.butPrintSheets.Location = New System.Drawing.Point(220, 250)
        Me.butPrintSheets.Name = "butPrintSheets"
        Me.butPrintSheets.Size = New System.Drawing.Size(111, 23)
        Me.butPrintSheets.TabIndex = 16
        Me.butPrintSheets.Text = "Print Blank Sheet(s)"
        Me.butPrintSheets.UseVisualStyleBackColor = True
        '
        'butPrintRecs
        '
        Me.butPrintRecs.Location = New System.Drawing.Point(331, 250)
        Me.butPrintRecs.Name = "butPrintRecs"
        Me.butPrintRecs.Size = New System.Drawing.Size(85, 23)
        Me.butPrintRecs.TabIndex = 17
        Me.butPrintRecs.Text = "Print Selected"
        Me.butPrintRecs.UseVisualStyleBackColor = True
        '
        'lblPickRecord
        '
        Me.lblPickRecord.AutoSize = True
        Me.lblPickRecord.Location = New System.Drawing.Point(217, 41)
        Me.lblPickRecord.Name = "lblPickRecord"
        Me.lblPickRecord.Size = New System.Drawing.Size(66, 13)
        Me.lblPickRecord.TabIndex = 18
        Me.lblPickRecord.Text = "Pick Record"
        '
        'pntTestRecords
        '
        Me.pntTestRecords.DocumentName = "Machine Test Records"
        '
        'pntBlankSheets
        '
        Me.pntBlankSheets.DocumentName = "Blank Machine Test Records Sheet(s)"
        '
        'frmSafMan
        '
        Me.AcceptButton = Me.butAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 281)
        Me.Controls.Add(Me.lblPickRecord)
        Me.Controls.Add(Me.butPrintRecs)
        Me.Controls.Add(Me.butPrintSheets)
        Me.Controls.Add(Me.lstRecords)
        Me.Controls.Add(Me.grpRecords)
        Me.Controls.Add(Me.hypHelp)
        Me.Controls.Add(Me.butHome)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmSafMan"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Machine Test Records - WorMS"
        Me.grpRecords.ResumeLayout(False)
        Me.grpRecords.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents hypHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents butHome As System.Windows.Forms.Button
    Friend WithEvents grpRecords As System.Windows.Forms.GroupBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents lblDateOfCheck As System.Windows.Forms.Label
    Friend WithEvents dtpDateOfCheck As System.Windows.Forms.DateTimePicker
    Friend WithEvents butRemove As System.Windows.Forms.Button
    Friend WithEvents butClear As System.Windows.Forms.Button
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents lstRecords As System.Windows.Forms.ListBox
    Friend WithEvents butPrintSheets As System.Windows.Forms.Button
    Friend WithEvents butPrintRecs As System.Windows.Forms.Button
    Friend WithEvents lblPickRecord As System.Windows.Forms.Label
    Friend WithEvents pntTestRecords As System.Drawing.Printing.PrintDocument
    Friend WithEvents pntBlankSheets As System.Drawing.Printing.PrintDocument
End Class
