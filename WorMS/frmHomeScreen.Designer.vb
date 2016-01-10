<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHomeScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHomeScreen))
        Me.hypHelp = New System.Windows.Forms.LinkLabel()
        Me.srpHomeScreen = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.butSafMan = New System.Windows.Forms.Button()
        Me.butStuMan = New System.Windows.Forms.Button()
        Me.butSupMan = New System.Windows.Forms.Button()
        Me.butReqMan = New System.Windows.Forms.Button()
        Me.butReqEdit = New System.Windows.Forms.Button()
        Me.butQuit = New System.Windows.Forms.Button()
        Me.butChangeFileDir = New System.Windows.Forms.Button()
        Me.butResMan = New System.Windows.Forms.Button()
        Me.picWorMS = New System.Windows.Forms.PictureBox()
        Me.ppdPrintPreview = New System.Windows.Forms.PrintPreviewDialog()
        Me.srpHomeScreen.SuspendLayout()
        CType(Me.picWorMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'hypHelp
        '
        Me.hypHelp.AutoSize = True
        Me.hypHelp.Location = New System.Drawing.Point(299, 11)
        Me.hypHelp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.hypHelp.Name = "hypHelp"
        Me.hypHelp.Size = New System.Drawing.Size(37, 17)
        Me.hypHelp.TabIndex = 0
        Me.hypHelp.TabStop = True
        Me.hypHelp.Text = "Help"
        '
        'srpHomeScreen
        '
        Me.srpHomeScreen.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.srpHomeScreen.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel})
        Me.srpHomeScreen.Location = New System.Drawing.Point(0, 541)
        Me.srpHomeScreen.Name = "srpHomeScreen"
        Me.srpHomeScreen.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.srpHomeScreen.Size = New System.Drawing.Size(353, 25)
        Me.srpHomeScreen.SizingGrip = False
        Me.srpHomeScreen.TabIndex = 6
        '
        'tssLabel
        '
        Me.tssLabel.Name = "tssLabel"
        Me.tssLabel.Size = New System.Drawing.Size(150, 20)
        Me.tssLabel.Text = "Sam Rimington, 2014"
        '
        'butSafMan
        '
        Me.butSafMan.Image = CType(resources.GetObject("butSafMan.Image"), System.Drawing.Image)
        Me.butSafMan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butSafMan.Location = New System.Drawing.Point(17, 414)
        Me.butSafMan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butSafMan.Name = "butSafMan"
        Me.butSafMan.Size = New System.Drawing.Size(320, 52)
        Me.butSafMan.TabIndex = 6
        Me.butSafMan.Text = "Manage Machine Test" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Records"
        Me.butSafMan.UseVisualStyleBackColor = True
        '
        'butStuMan
        '
        Me.butStuMan.Image = CType(resources.GetObject("butStuMan.Image"), System.Drawing.Image)
        Me.butStuMan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butStuMan.Location = New System.Drawing.Point(17, 354)
        Me.butStuMan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butStuMan.Name = "butStuMan"
        Me.butStuMan.Size = New System.Drawing.Size(320, 52)
        Me.butStuMan.TabIndex = 5
        Me.butStuMan.Text = "Manage Students"
        Me.butStuMan.UseVisualStyleBackColor = True
        '
        'butSupMan
        '
        Me.butSupMan.Image = CType(resources.GetObject("butSupMan.Image"), System.Drawing.Image)
        Me.butSupMan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butSupMan.Location = New System.Drawing.Point(17, 295)
        Me.butSupMan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butSupMan.Name = "butSupMan"
        Me.butSupMan.Size = New System.Drawing.Size(320, 52)
        Me.butSupMan.TabIndex = 4
        Me.butSupMan.Text = "Manage Suppliers"
        Me.butSupMan.UseVisualStyleBackColor = True
        '
        'butReqMan
        '
        Me.butReqMan.Image = CType(resources.GetObject("butReqMan.Image"), System.Drawing.Image)
        Me.butReqMan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butReqMan.Location = New System.Drawing.Point(17, 236)
        Me.butReqMan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butReqMan.Name = "butReqMan"
        Me.butReqMan.Size = New System.Drawing.Size(320, 52)
        Me.butReqMan.TabIndex = 3
        Me.butReqMan.Text = "View Saved Requisition" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Forms"
        Me.butReqMan.UseVisualStyleBackColor = True
        '
        'butReqEdit
        '
        Me.butReqEdit.Image = CType(resources.GetObject("butReqEdit.Image"), System.Drawing.Image)
        Me.butReqEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butReqEdit.Location = New System.Drawing.Point(17, 177)
        Me.butReqEdit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butReqEdit.Name = "butReqEdit"
        Me.butReqEdit.Size = New System.Drawing.Size(320, 52)
        Me.butReqEdit.TabIndex = 2
        Me.butReqEdit.Text = "New Requisition Form"
        Me.butReqEdit.UseVisualStyleBackColor = True
        '
        'butQuit
        '
        Me.butQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.butQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butQuit.Image = CType(resources.GetObject("butQuit.Image"), System.Drawing.Image)
        Me.butQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butQuit.Location = New System.Drawing.Point(176, 473)
        Me.butQuit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butQuit.Name = "butQuit"
        Me.butQuit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.butQuit.Size = New System.Drawing.Size(160, 52)
        Me.butQuit.TabIndex = 8
        Me.butQuit.Text = "Quit"
        Me.butQuit.UseVisualStyleBackColor = True
        '
        'butChangeFileDir
        '
        Me.butChangeFileDir.Image = CType(resources.GetObject("butChangeFileDir.Image"), System.Drawing.Image)
        Me.butChangeFileDir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butChangeFileDir.Location = New System.Drawing.Point(17, 473)
        Me.butChangeFileDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butChangeFileDir.Name = "butChangeFileDir"
        Me.butChangeFileDir.Size = New System.Drawing.Size(160, 52)
        Me.butChangeFileDir.TabIndex = 7
        Me.butChangeFileDir.Text = "Change Data Directory"
        Me.butChangeFileDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.butChangeFileDir.UseVisualStyleBackColor = True
        '
        'butResMan
        '
        Me.butResMan.Image = CType(resources.GetObject("butResMan.Image"), System.Drawing.Image)
        Me.butResMan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butResMan.Location = New System.Drawing.Point(17, 118)
        Me.butResMan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butResMan.Name = "butResMan"
        Me.butResMan.Size = New System.Drawing.Size(320, 52)
        Me.butResMan.TabIndex = 1
        Me.butResMan.Text = "Manage Resources"
        Me.butResMan.UseVisualStyleBackColor = True
        '
        'picWorMS
        '
        Me.picWorMS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picWorMS.Image = CType(resources.GetObject("picWorMS.Image"), System.Drawing.Image)
        Me.picWorMS.Location = New System.Drawing.Point(16, 37)
        Me.picWorMS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.picWorMS.Name = "picWorMS"
        Me.picWorMS.Size = New System.Drawing.Size(321, 73)
        Me.picWorMS.TabIndex = 1
        Me.picWorMS.TabStop = False
        '
        'ppdPrintPreview
        '
        Me.ppdPrintPreview.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdPrintPreview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdPrintPreview.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdPrintPreview.Enabled = True
        Me.ppdPrintPreview.Icon = CType(resources.GetObject("ppdPrintPreview.Icon"), System.Drawing.Icon)
        Me.ppdPrintPreview.Name = "ppdReceipts"
        Me.ppdPrintPreview.ShowIcon = False
        Me.ppdPrintPreview.Visible = False
        '
        'frmHomeScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butQuit
        Me.ClientSize = New System.Drawing.Size(353, 566)
        Me.Controls.Add(Me.butSafMan)
        Me.Controls.Add(Me.butStuMan)
        Me.Controls.Add(Me.butSupMan)
        Me.Controls.Add(Me.butReqMan)
        Me.Controls.Add(Me.butReqEdit)
        Me.Controls.Add(Me.srpHomeScreen)
        Me.Controls.Add(Me.butQuit)
        Me.Controls.Add(Me.butChangeFileDir)
        Me.Controls.Add(Me.butResMan)
        Me.Controls.Add(Me.picWorMS)
        Me.Controls.Add(Me.hypHelp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "frmHomeScreen"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WorMS"
        Me.srpHomeScreen.ResumeLayout(False)
        Me.srpHomeScreen.PerformLayout()
        CType(Me.picWorMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents hypHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents picWorMS As System.Windows.Forms.PictureBox
    Friend WithEvents butResMan As System.Windows.Forms.Button
    Friend WithEvents butChangeFileDir As System.Windows.Forms.Button
    Friend WithEvents butQuit As System.Windows.Forms.Button
    Friend WithEvents srpHomeScreen As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents butReqEdit As System.Windows.Forms.Button
    Friend WithEvents butReqMan As System.Windows.Forms.Button
    Friend WithEvents butSupMan As System.Windows.Forms.Button
    Friend WithEvents butStuMan As System.Windows.Forms.Button
    Friend WithEvents butSafMan As System.Windows.Forms.Button
    Friend WithEvents ppdPrintPreview As System.Windows.Forms.PrintPreviewDialog

End Class
