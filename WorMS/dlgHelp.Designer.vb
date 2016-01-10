<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgHelp
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
        Me.wbrHelp = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'wbrHelp
        '
        Me.wbrHelp.AllowWebBrowserDrop = False
        Me.wbrHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbrHelp.Location = New System.Drawing.Point(0, 0)
        Me.wbrHelp.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbrHelp.Name = "wbrHelp"
        Me.wbrHelp.Size = New System.Drawing.Size(784, 442)
        Me.wbrHelp.TabIndex = 0
        Me.wbrHelp.WebBrowserShortcutsEnabled = False
        '
        'dlgHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 442)
        Me.Controls.Add(Me.wbrHelp)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "dlgHelp"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Help - WorMS"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wbrHelp As System.Windows.Forms.WebBrowser
End Class
