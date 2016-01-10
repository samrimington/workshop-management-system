<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgResMan_LowStockView
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
        Me.lstLowStock = New System.Windows.Forms.ListBox()
        Me.hypHelp = New System.Windows.Forms.LinkLabel()
        Me.butAddToForm = New System.Windows.Forms.Button()
        Me.butPrint = New System.Windows.Forms.Button()
        Me.butClose = New System.Windows.Forms.Button()
        Me.pntLowStockReport = New System.Drawing.Printing.PrintDocument()
        Me.SuspendLayout()
        '
        'lstLowStock
        '
        Me.lstLowStock.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLowStock.FormattingEnabled = True
        Me.lstLowStock.ItemHeight = 14
        Me.lstLowStock.Location = New System.Drawing.Point(12, 12)
        Me.lstLowStock.Name = "lstLowStock"
        Me.lstLowStock.ScrollAlwaysVisible = True
        Me.lstLowStock.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstLowStock.Size = New System.Drawing.Size(792, 256)
        Me.lstLowStock.TabIndex = 0
        '
        'hypHelp
        '
        Me.hypHelp.AutoSize = True
        Me.hypHelp.Location = New System.Drawing.Point(14, 285)
        Me.hypHelp.Name = "hypHelp"
        Me.hypHelp.Size = New System.Drawing.Size(29, 13)
        Me.hypHelp.TabIndex = 1
        Me.hypHelp.TabStop = True
        Me.hypHelp.Text = "Help"
        '
        'butAddToForm
        '
        Me.butAddToForm.Location = New System.Drawing.Point(532, 280)
        Me.butAddToForm.Name = "butAddToForm"
        Me.butAddToForm.Size = New System.Drawing.Size(156, 23)
        Me.butAddToForm.TabIndex = 2
        Me.butAddToForm.Text = "Add Selected to New Form"
        Me.butAddToForm.UseVisualStyleBackColor = True
        '
        'butPrint
        '
        Me.butPrint.Location = New System.Drawing.Point(694, 280)
        Me.butPrint.Name = "butPrint"
        Me.butPrint.Size = New System.Drawing.Size(52, 23)
        Me.butPrint.TabIndex = 3
        Me.butPrint.Text = "Print"
        Me.butPrint.UseVisualStyleBackColor = True
        '
        'butClose
        '
        Me.butClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butClose.Location = New System.Drawing.Point(752, 280)
        Me.butClose.Name = "butClose"
        Me.butClose.Size = New System.Drawing.Size(52, 23)
        Me.butClose.TabIndex = 4
        Me.butClose.Text = "Close"
        Me.butClose.UseVisualStyleBackColor = True
        '
        'pntLowStockReport
        '
        Me.pntLowStockReport.DocumentName = "Low Stock Report"
        '
        'dlgResMan_LowStockView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butClose
        Me.ClientSize = New System.Drawing.Size(814, 315)
        Me.Controls.Add(Me.butClose)
        Me.Controls.Add(Me.butPrint)
        Me.Controls.Add(Me.butAddToForm)
        Me.Controls.Add(Me.hypHelp)
        Me.Controls.Add(Me.lstLowStock)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgResMan_LowStockView"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "View Low Stock - WorMS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstLowStock As System.Windows.Forms.ListBox
    Friend WithEvents hypHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents butAddToForm As System.Windows.Forms.Button
    Friend WithEvents butPrint As System.Windows.Forms.Button
    Friend WithEvents butClose As System.Windows.Forms.Button
    Friend WithEvents pntLowStockReport As System.Drawing.Printing.PrintDocument

End Class
