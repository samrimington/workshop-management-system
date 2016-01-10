' ╔════════════════════════════════════════════════════════════════╗
' ----Workshop Management System Project----------------------------
' ----Sam Rimington-------------------------------------------------
' ----A2 Computing--------------------------------------------------
' ----F454----------------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Home Screen---------------------------------------------------
' --The purpose of this form is to let the user access all----------
' --functionalities throughout the program.-------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Date since last change: 04-12-2014----------------------------
' ╚════════════════════════════════════════════════════════════════╝

Public Class frmHomeScreen

    Public Shared blnPrintPreviewOpened As Boolean

    Shared Sub subInformMultiplePages(ByVal intNumberOfPages As Integer)
        ' If there are no more pages to print and multiple pages have been printed,
        ' show a message box informing the user how the remaining pages are viewed
        ' Make sure this message box only appears once after the print preview dialog is opened
        If intNumberOfPages > 1 And Not blnPrintPreviewOpened Then
            MessageBox.Show("This document contains multiple pages. Use the controls on the top of this print preview to view the remaining pages.",
                            "Multiple Pages", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnPrintPreviewOpened = True
        End If
    End Sub

    ' Declare all file structures here upon startup so they can be used by all other forms in system
    ' Resources file
    Public Structure rtpResource
        <VBFixedString(15)> Dim strCategory As String   '15 bytes
        <VBFixedString(63)> Dim strName As String       '63 bytes
        <VBFixedString(10)> Dim strUnit As String       '10 bytes
        Dim sinQuantity, sinMinQuantity As Single       '8 bytes
    End Structure

    ' Requisition form entries file
    Public Structure rtpReqFormEntry
        <VBFixedString(16)> Dim strFileName As String           '16 bytes
        <VBFixedString(63)> Dim strSupplier As String           '63 bytes
        <VBFixedString(127)> Dim strAddress As String           '127 bytes
        <VBFixedString(127)> Dim strNewSupplierReason As String '127 bytes
        <VBFixedString(127)> Dim strBenefitDetails As String    '127 bytes
        <VBFixedString(63)> Dim strAuthDeptManager As String    '63 bytes
        Dim dteDateOfSave As Date                               '8 bytes
        Dim sinOverallCost As Single                            '4 bytes
        Dim bytNumberOfResources As Integer                     '1 byte
    End Structure

    ' Requisition form resources files
    Public Structure rtpReqFormResource
        <VBFixedString(31)> Dim strCatalogueNumber As String                '31 bytes
        <VBFixedString(63)> Dim strName As String                           '63 bytes
        Dim bytLedgerCode, bytQuantity As Byte                              '2 bytes
        Dim sinCostPerPiece, sinDiscount, sinVAT, sinTotalCost As Single    '16 bytes
    End Structure

    ' Suppliers file
    Public Structure rtpSupplier
        <VBFixedString(63)> Dim strName As String       '63 bytes
        <VBFixedString(127)> Dim strAddress As String   '127 bytes
        Dim bytTimesUsed As Byte                        '1 byte
    End Structure

    ' Student entries file
    Public Structure rtpStudentEntry
        <VBFixedString(63)> Dim strName As String   '63 bytes
        <VBFixedString(2)> Dim strLevel As String   '2 bytes
        Dim sinCostOwed As Single                   '4 bytes
        Dim blnPaid, blnReceiptPrinted As Boolean   '4 bytes
        Dim bytNumberOfResources As Byte            '1 byte
    End Structure

    ' Student resources files
    Public Structure rtpStudentResource
        <VBFixedString(63)> Dim strName As String   '63 bytes
        <VBFixedString(10)> Dim strUnit As String   '10 bytes
        Dim sinQuantity As Single                   '4 bytes
    End Structure

    ' Machine test record file
    Public Structure rtpSafetyRecord
        <VBFixedString(255)> Dim strComments As String  '255 bytes
        Dim dteDateOfCheck As Date                      '8 bytes
    End Structure

    ' Assign a folder location set to a subfolder in the default location for documents
    Public Shared strFolderLocation As String = System.IO.Path.GetFullPath(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/WorMS/")

    Sub subMakeFolders()
        ' Main folder will be created as well as these subfolders
        'Requisition forms
        My.Computer.FileSystem.CreateDirectory(strFolderLocation & "Draft Requisition Forms/")
        My.Computer.FileSystem.CreateDirectory(strFolderLocation & "Printed Requisition Forms/")
        My.Computer.FileSystem.CreateDirectory(strFolderLocation & "Unprinted Requisition Forms/")

        'Students
        My.Computer.FileSystem.CreateDirectory(strFolderLocation & "Student Resources/")
    End Sub

    Private Sub frmHomeScreen_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Make sure all folders have been created for forms
        subMakeFolders()
    End Sub

    Private Sub hypHelp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles hypHelp.LinkClicked
        ' Upon clicking the Help hyperlink, open the online help for this form
        dlgHelp.Hide()
        dlgHelp.strFormName = Me.Name
        dlgHelp.Show()
    End Sub

    Private Sub butResMan_Click(sender As Object, e As EventArgs) Handles butResMan.Click
        ' Upon clicking Manage Resources, hide the home screen and show the Resource Manager
        Me.Hide()
        frmResMan.Show()
    End Sub

    Private Sub butReqEdit_Click(sender As Object, e As EventArgs) Handles butReqEdit.Click
        ' Upon clicking New Requisition Form, hide the home screen and show the Requisition Form Editor
        Me.Hide()
        frmReqEdit.Show()
    End Sub

    Private Sub butReqMan_Click(sender As Object, e As EventArgs) Handles butReqMan.Click
        ' Upon clicking View Saved Requisition Forms, hide the home screen and show the Requisition Form Manager
        Me.Hide()
        frmReqMan.blpPrinted.Checked = True
        frmReqMan.Show()
    End Sub

    Private Sub butSupMan_Click(sender As Object, e As EventArgs) Handles butSupMan.Click
        ' Upon clicking Manage Suppliers, hide the home screen and show the Supplier Manager
        Me.Hide()
        frmSupMan.Show()
    End Sub

    Private Sub butStuMan_Click(sender As Object, e As EventArgs) Handles butStuMan.Click
        ' Upon clicking Manage Students, hide the home screen and show the Student Manager
        Me.Hide()
        frmStuMan.Show()
    End Sub

    Private Sub butSafMan_Click(sender As Object, e As EventArgs) Handles butSafMan.Click
        ' Upon clicking Manage Machine Test Records, hide the home screen and show the Machine Test Records Manager
        Me.Hide()
        frmSafMan.Show()
    End Sub

    Private Sub butChangeFileDir_Click(sender As Object, e As EventArgs) Handles butChangeFileDir.Click
        ' Upon clicking the Change File Directory button, show the Change File Directory form as a dialog
        dlgHomeScreen_ChangeFileDir.ShowDialog()

        ' If new location is given, change the folder location to the new folder location
        ' Otherwise, leave as it is
        If dlgHomeScreen_ChangeFileDir.strNewFolderLocation <> "" Then
            strFolderLocation = dlgHomeScreen_ChangeFileDir.strNewFolderLocation
            subMakeFolders()
        End If
    End Sub

    Private Sub butQuit_Click(sender As Object, e As EventArgs) Handles butQuit.Click
        ' Upon clicking the Quit button, close the home screen
        Me.Close()

        ' Th-Th-Th-Th-That's all folks!
    End Sub

End Class
