<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStuMan
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
        Me.lstStudents = New System.Windows.Forms.ListBox()
        Me.butAdd = New System.Windows.Forms.Button()
        Me.butViewInfo = New System.Windows.Forms.Button()
        Me.butRemove = New System.Windows.Forms.Button()
        Me.butPrint = New System.Windows.Forms.Button()
        Me.pntReceipts = New System.Drawing.Printing.PrintDocument()
        Me.SuspendLayout()
        '
        'hypHelp
        '
        Me.hypHelp.AutoSize = True
        Me.hypHelp.Location = New System.Drawing.Point(498, 17)
        Me.hypHelp.Name = "hypHelp"
        Me.hypHelp.Size = New System.Drawing.Size(29, 13)
        Me.hypHelp.TabIndex = 8
        Me.hypHelp.TabStop = True
        Me.hypHelp.Text = "Help"
        '
        'butHome
        '
        Me.butHome.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butHome.Location = New System.Drawing.Point(12, 12)
        Me.butHome.Name = "butHome"
        Me.butHome.Size = New System.Drawing.Size(27, 23)
        Me.butHome.TabIndex = 7
        Me.butHome.Text = "⌂"
        Me.butHome.UseVisualStyleBackColor = True
        '
        'lstStudents
        '
        Me.lstStudents.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstStudents.FormattingEnabled = True
        Me.lstStudents.ItemHeight = 14
        Me.lstStudents.Location = New System.Drawing.Point(12, 41)
        Me.lstStudents.Name = "lstStudents"
        Me.lstStudents.ScrollAlwaysVisible = True
        Me.lstStudents.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstStudents.Size = New System.Drawing.Size(515, 214)
        Me.lstStudents.TabIndex = 15
        '
        'butAdd
        '
        Me.butAdd.Location = New System.Drawing.Point(142, 264)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(106, 23)
        Me.butAdd.TabIndex = 16
        Me.butAdd.Text = "Add Student"
        Me.butAdd.UseVisualStyleBackColor = True
        '
        'butViewInfo
        '
        Me.butViewInfo.Location = New System.Drawing.Point(254, 264)
        Me.butViewInfo.Name = "butViewInfo"
        Me.butViewInfo.Size = New System.Drawing.Size(75, 23)
        Me.butViewInfo.TabIndex = 17
        Me.butViewInfo.Text = "View Info"
        Me.butViewInfo.UseVisualStyleBackColor = True
        '
        'butRemove
        '
        Me.butRemove.Location = New System.Drawing.Point(335, 264)
        Me.butRemove.Name = "butRemove"
        Me.butRemove.Size = New System.Drawing.Size(98, 23)
        Me.butRemove.TabIndex = 18
        Me.butRemove.Text = "Remove Student"
        Me.butRemove.UseVisualStyleBackColor = True
        '
        'butPrint
        '
        Me.butPrint.Location = New System.Drawing.Point(439, 264)
        Me.butPrint.Name = "butPrint"
        Me.butPrint.Size = New System.Drawing.Size(88, 23)
        Me.butPrint.TabIndex = 19
        Me.butPrint.Text = "Print Receipt(s)"
        Me.butPrint.UseVisualStyleBackColor = True
        '
        'pntReceipts
        '
        Me.pntReceipts.DocumentName = "Receipts"
        '
        'frmStuMan
        '
        Me.AcceptButton = Me.butViewInfo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 296)
        Me.Controls.Add(Me.butPrint)
        Me.Controls.Add(Me.butRemove)
        Me.Controls.Add(Me.butViewInfo)
        Me.Controls.Add(Me.butAdd)
        Me.Controls.Add(Me.lstStudents)
        Me.Controls.Add(Me.hypHelp)
        Me.Controls.Add(Me.butHome)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmStuMan"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Students - WorMS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents hypHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents butHome As System.Windows.Forms.Button
    Friend WithEvents lstStudents As System.Windows.Forms.ListBox
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents butViewInfo As System.Windows.Forms.Button
    Friend WithEvents butRemove As System.Windows.Forms.Button
    Friend WithEvents butPrint As System.Windows.Forms.Button
    Friend WithEvents pntReceipts As System.Drawing.Printing.PrintDocument
End Class
