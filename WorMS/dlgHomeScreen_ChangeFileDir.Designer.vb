<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgHomeScreen_ChangeFileDir
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
        Me.lblSelectDir = New System.Windows.Forms.Label()
        Me.txtFileDirectory = New System.Windows.Forms.TextBox()
        Me.butBrowse = New System.Windows.Forms.Button()
        Me.hypHelp = New System.Windows.Forms.LinkLabel()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.butOK = New System.Windows.Forms.Button()
        Me.fbdFolderLocation = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'lblSelectDir
        '
        Me.lblSelectDir.AutoSize = True
        Me.lblSelectDir.Location = New System.Drawing.Point(13, 13)
        Me.lblSelectDir.Name = "lblSelectDir"
        Me.lblSelectDir.Size = New System.Drawing.Size(99, 13)
        Me.lblSelectDir.TabIndex = 1
        Me.lblSelectDir.Text = "Select file directory:"
        '
        'txtFileDirectory
        '
        Me.txtFileDirectory.Location = New System.Drawing.Point(16, 30)
        Me.txtFileDirectory.Name = "txtFileDirectory"
        Me.txtFileDirectory.ReadOnly = True
        Me.txtFileDirectory.Size = New System.Drawing.Size(295, 20)
        Me.txtFileDirectory.TabIndex = 2
        '
        'butBrowse
        '
        Me.butBrowse.Location = New System.Drawing.Point(318, 30)
        Me.butBrowse.Name = "butBrowse"
        Me.butBrowse.Size = New System.Drawing.Size(67, 20)
        Me.butBrowse.TabIndex = 3
        Me.butBrowse.Text = "Browse"
        Me.butBrowse.UseVisualStyleBackColor = True
        '
        'hypHelp
        '
        Me.hypHelp.AutoSize = True
        Me.hypHelp.Location = New System.Drawing.Point(13, 69)
        Me.hypHelp.Name = "hypHelp"
        Me.hypHelp.Size = New System.Drawing.Size(29, 13)
        Me.hypHelp.TabIndex = 4
        Me.hypHelp.TabStop = True
        Me.hypHelp.Text = "Help"
        '
        'butCancel
        '
        Me.butCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(318, 64)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(67, 23)
        Me.butCancel.TabIndex = 1
        Me.butCancel.Text = "Cancel"
        '
        'butOK
        '
        Me.butOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.butOK.Location = New System.Drawing.Point(245, 64)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(67, 23)
        Me.butOK.TabIndex = 0
        Me.butOK.Text = "OK"
        '
        'dlgHomeScreen_ChangeFileDir
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(397, 96)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.hypHelp)
        Me.Controls.Add(Me.butBrowse)
        Me.Controls.Add(Me.txtFileDirectory)
        Me.Controls.Add(Me.lblSelectDir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgHomeScreen_ChangeFileDir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "WorMS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSelectDir As System.Windows.Forms.Label
    Friend WithEvents txtFileDirectory As System.Windows.Forms.TextBox
    Friend WithEvents butBrowse As System.Windows.Forms.Button
    Friend WithEvents hypHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents butOK As System.Windows.Forms.Button
    Friend WithEvents fbdFolderLocation As System.Windows.Forms.FolderBrowserDialog

End Class
