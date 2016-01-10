' ╔════════════════════════════════════════════════════════════════╗
' ----Workshop Management System Project----------------------------
' ----Sam Rimington-------------------------------------------------
' ----A2 Computing--------------------------------------------------
' ----F454----------------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Requisition Form Manager--------------------------------------
' --The purpose of this form is to let the user manage saved--------
' --requisition forms.----------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Date since last change: 04-12-2014----------------------------
' ╚════════════════════════════════════════════════════════════════╝

Imports WorMS.frmHomeScreen
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmReqMan
    ' Declare variables and structures for use in this form
    Dim strSelectedCategory As String
    Dim recReqFormEntry_Read As rtpReqFormEntry


    Sub subUpdateReqList()
        ' Open requisition form entries file and find number of requisition forms
        FileClose()
        FileOpen(1, strFolderLocation & strSelectedCategory & "_Requisition_Forms.dat", OpenMode.Random, , , Len(New rtpReqFormEntry))
        Dim intNumberOfReqForms As Integer = FileLen(strFolderLocation & strSelectedCategory & "_Requisition_Forms.dat") / Len(New rtpReqFormEntry)

        ' Clear requisition form list
        lstReqFormsList.Items.Clear()

        If intNumberOfReqForms > 0 Then
            ' If forms can be found, add header to list - base first entry on selected category
            If strSelectedCategory = "Printed" Then
                lstReqFormsList.Items.Add(String.Format("{0, -15}", "Date Printed") & "Supplier")
            Else
                lstReqFormsList.Items.Add(String.Format("{0, -15}", "Date Saved") & "Supplier")
            End If

            ' Open requisition form list file and find each requisition form for the category
            For i = 1 To intNumberOfReqForms
                FileGet(1, recReqFormEntry_Read, i)

                ' Format supplier name correctly
                Dim strSupplier_Formatted As String = Trim(recReqFormEntry_Read.strSupplier)
                If Len(strSupplier_Formatted) > 14 Then
                    strSupplier_Formatted = Mid(strSupplier_Formatted, 1, 13) & "…"
                End If

                ' Add requisition form to list
                lstReqFormsList.Items.Add(String.Format("{0, -15}", FormatDateTime(recReqFormEntry_Read.dteDateOfSave, DateFormat.ShortDate)) & strSupplier_Formatted)
            Next
        Else
            ' If forms cannot be found, simply state this in a list box item
            lstReqFormsList.Items.Add("No forms of this type can be found")
        End If

        lstReqFormsList.SelectedIndex = -1
        butChange.Enabled = False
        butExport.Enabled = False
        butRemove.Enabled = False
    End Sub

    Sub subRemoveEntry(ByVal strSelectedFolder As String, ByVal intSelectedIndex As Integer)
        ' Find number of requisition forms
        Dim intNumberOfReqForms As Integer = FileLen(strFolderLocation & strSelectedFolder & "_Requisition_Forms.dat") / Len(New rtpReqFormEntry)

        ' Remove requisition form entry from requisition form entries file by creating temporary file with records other than entry to be removed
        FileClose()
        FileOpen(1, strFolderLocation & strSelectedFolder & "_Requisition_Forms.dat", OpenMode.Random, , , Len(New rtpReqFormEntry))
        FileOpen(2, strFolderLocation & strSelectedFolder & "_Requisition_Forms_temp.dat", OpenMode.Random, , , Len(New rtpReqFormEntry))
        For i = 1 To intSelectedIndex - 1
            FileGet(1, recReqFormEntry_Read, i)
            FilePut(2, recReqFormEntry_Read, i)
        Next
        For i = intSelectedIndex + 1 To intNumberOfReqForms
            FileGet(1, recReqFormEntry_Read, i)
            FilePut(2, recReqFormEntry_Read, i - 1)
        Next
        FileClose(1, 2)

        ' Delete the old file and rename temporary file so it can be used
        My.Computer.FileSystem.DeleteFile(strFolderLocation & strSelectedFolder & "_Requisition_Forms.dat")
        My.Computer.FileSystem.RenameFile(strFolderLocation & strSelectedFolder & "_Requisition_Forms_temp.dat", strSelectedFolder & "_Requisition_Forms.dat")

        ' Open the new file
        FileOpen(1, strFolderLocation & strSelectedFolder & "_Requisition_Forms.dat", OpenMode.Random, , , Len(New rtpReqFormEntry))
    End Sub

    Private Sub butHome_Click(sender As Object, e As EventArgs) Handles butHome.Click
        ' Upon clicking the home button, close this form
        Me.Close()
    End Sub

    Private Sub hypHelp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles hypHelp.LinkClicked
        ' Upon clicking the Help hyperlink, open the online help for this form
        dlgHelp.Hide()
        dlgHelp.strFormName = Me.Name
        dlgHelp.Show()
    End Sub

    Private Sub blpPrinted_CheckedChanged(sender As Object, e As EventArgs) Handles blpPrinted.CheckedChanged
        If blpPrinted.Checked Then
            strSelectedCategory = "Printed"
            subUpdateReqList()

            butChange.Text = "Reuse"

            butChange.Enabled = False
            butExport.Enabled = False
            butRemove.Enabled = False
        End If
    End Sub

    Private Sub blpUnprinted_CheckedChanged(sender As Object, e As EventArgs) Handles blpUnprinted.CheckedChanged
        If blpUnprinted.Checked Then
            strSelectedCategory = "Unprinted"
            subUpdateReqList()

            butChange.Text = "Reuse"

            butChange.Enabled = False
            butExport.Enabled = False
            butRemove.Enabled = False
        End If
    End Sub

    Private Sub blpDrafts_CheckedChanged(sender As Object, e As EventArgs) Handles blpDrafts.CheckedChanged
        If blpDrafts.Checked Then
            strSelectedCategory = "Draft"
            subUpdateReqList()

            butChange.Text = "Change"

            butChange.Enabled = False
            butExport.Enabled = False
            butRemove.Enabled = False
        End If
    End Sub

    Private Sub lstReqFormsList_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstReqFormsList.SelectedValueChanged
        ' Check header has not been selected
        If lstReqFormsList.SelectedIndex > 0 Then
            butChange.Enabled = True
            If butChange.Text = "Reuse" Then
                butExport.Enabled = True
            End If
            butRemove.Enabled = True
        Else
            lstReqFormsList.SelectedIndex = -1

            butChange.Enabled = False
            butExport.Enabled = False
            butRemove.Enabled = False
        End If
    End Sub

    Private Sub butChange_Click(sender As Object, e As EventArgs) Handles butChange.Click
        frmReqEdit.blnOpeningExistingForm = True

        ' Get data associated with list box selection
        FileGet(1, frmReqEdit.recReqFormEntryInput, lstReqFormsList.SelectedIndex)

        ' Bring selected folder value over to frmReqEdit
        frmReqEdit.strSelectedCategory = strSelectedCategory

        ' Close this form and open frmReqEdit
        Me.Close()
        frmReqEdit.Show()
    End Sub

    Private Sub butExport_Click(sender As Object, e As EventArgs) Handles butExport.Click     
        Dim objExcel As New Excel.Application
        Dim objBook As Excel.Workbook
        Dim objSheet As Excel.Worksheet

        ' Find an available file name for the sheet to export
        Dim strDate As String = CStr(Now.Day) & "-" & CStr(Now.Month) & "-" & CStr(Now.Year)
        Dim intID As Integer
        Dim blnIDFound As Boolean
        Do
            intID = intID + 1
            If Not My.Computer.FileSystem.FileExists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) &
                                                     strDate & "_" & intID & ".xls") Then
                blnIDFound = True
            End If
        Loop Until blnIDFound

        System.IO.File.WriteAllBytes(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) &
                                     "/" & strDate & "_" & intID & ".xls", My.Resources.Requisition_form_template)

        ' Get data associated with list box selection
        FileGet(1, recReqFormEntry_Read, lstReqFormsList.SelectedIndex)

        ' Trim recReqFormEntry strings
        recReqFormEntry_Read.strAddress = Trim(recReqFormEntry_Read.strAddress)
        recReqFormEntry_Read.strAuthDeptManager = Trim(recReqFormEntry_Read.strAuthDeptManager)
        recReqFormEntry_Read.strBenefitDetails = Trim(recReqFormEntry_Read.strBenefitDetails)
        recReqFormEntry_Read.strNewSupplierReason = Trim(recReqFormEntry_Read.strNewSupplierReason)
        recReqFormEntry_Read.strSupplier = Trim(recReqFormEntry_Read.strSupplier)
        recReqFormEntry_Read.strFileName = Trim(recReqFormEntry_Read.strFileName)

        objBook = objExcel.Workbooks.Open(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) &
                                          "/" & strDate & "_" & intID & ".xls")
        objSheet = objBook.Sheets("Sheet1")

        ' Add requisition form headers
        ' Supplier
        objSheet.Cells(6, 3) = recReqFormEntry_Read.strSupplier

        ' Address
        If Len(recReqFormEntry_Read.strAddress) > 63 Then
            objSheet.Cells(7, 3) = Mid(recReqFormEntry_Read.strAddress, 1, 63)
            objSheet.Cells(8, 3) = Mid(recReqFormEntry_Read.strAddress, 64)
        Else
            objSheet.Cells(7, 3) = recReqFormEntry_Read.strAddress
        End If

        ' New Supplier Reasons
        If Len(recReqFormEntry_Read.strNewSupplierReason) > 63 Then
            objSheet.Cells(9, 3) = Mid(recReqFormEntry_Read.strNewSupplierReason, 1, 63)
            objSheet.Cells(10, 3) = Mid(recReqFormEntry_Read.strNewSupplierReason, 64)
        Else
            objSheet.Cells(9, 3) = recReqFormEntry_Read.strNewSupplierReason
        End If

        ' New Supplier Benefits
        If Len(recReqFormEntry_Read.strBenefitDetails) > 63 Then
            objSheet.Cells(7, 6) = Mid(recReqFormEntry_Read.strBenefitDetails, 1, 63)
            objSheet.Cells(8, 6) = Mid(recReqFormEntry_Read.strBenefitDetails, 64)
        Else
            objSheet.Cells(7, 6) = recReqFormEntry_Read.strBenefitDetails
        End If

        ' Authorised Department Manager
        objSheet.Cells(24, 3) = recReqFormEntry_Read.strAuthDeptManager

        ' Date
        objSheet.Cells(24, 6) = Now.Date()

        ' Total cost
        objSheet.Cells(24, 10) = recReqFormEntry_Read.sinOverallCost

        ' Add requisition form resources
        Dim recResource_Read As rtpReqFormResource
        recResource_Read.strCatalogueNumber = ""
        recResource_Read.strName = ""
        FileOpen(2, strFolderLocation & strSelectedCategory & " Requisition Forms/" & recReqFormEntry_Read.strFileName, OpenMode.Random, , , Len(New rtpReqFormResource))
        For i = 1 To recReqFormEntry_Read.bytNumberOfResources
            FileGet(2, recResource_Read, i)

            ' Trim recResource strings
            recResource_Read.strCatalogueNumber = Trim(recResource_Read.strCatalogueNumber)
            recResource_Read.strName = Trim(recResource_Read.strName)

            ' Ledger code
            objSheet.Cells(14 + i, 2) = i

            ' Catalogue/ISBN number
            objSheet.Cells(14 + i, 3) = recResource_Read.strCatalogueNumber

            ' Item
            objSheet.Cells(14 + i, 4) = recResource_Read.strName

            ' Item cost
            objSheet.Cells(14 + i, 6) = recResource_Read.sinCostPerPiece

            ' Quantity
            objSheet.Cells(14 + i, 7) = recResource_Read.bytQuantity

            ' Discount
            objSheet.Cells(14 + i, 8) = recResource_Read.sinDiscount

            ' VAT
            objSheet.Cells(14 + i, 9) = recResource_Read.sinVAT

            ' Total cost
            objSheet.Cells(14 + i, 10) = recResource_Read.sinTotalCost
        Next
        FileClose(2)
        objBook.Close(True)
        objExcel.Quit()

        If strSelectedCategory = "Unprinted" Then
            Dim blnFound As Boolean

            ' Increment number of times used in supplier file
            ' Remove supplier from file first, declare Supplier file structure
            Dim recSupplier_Read As rtpSupplier
            recSupplier_Read.strName = ""
            recSupplier_Read.strAddress = ""

            ' Find supplier on file, open suppliers file and get number of records
            FileOpen(2, strFolderLocation & "Suppliers.dat", OpenMode.Random, , , Len(New rtpSupplier))
            Dim intNumberOfSuppliers As Integer = FileLen(strFolderLocation & "Suppliers.dat") / Len(New rtpSupplier)

            Dim intRecNumToRemove As Integer
            Do
                intRecNumToRemove = intRecNumToRemove + 1
                FileGet(2, recSupplier_Read, intRecNumToRemove)
                If Trim(recSupplier_Read.strName) = recReqFormEntry_Read.strSupplier Then
                    blnFound = True
                End If
            Loop Until blnFound Or intRecNumToRemove = intNumberOfSuppliers

            ' We can continue only if we have found the requisition form's supplier in the suppliers file
            ' and that the times used does not exceed 255
            If blnFound And recSupplier_Read.bytTimesUsed < 255 Then
                Dim recSupplierKeep As rtpSupplier = recSupplier_Read
                recSupplierKeep.bytTimesUsed = recSupplierKeep.bytTimesUsed + 1

                ' Create temporary file and copy all other items to it
                FileOpen(3, strFolderLocation & "Suppliers_temp.dat", OpenMode.Random, , , Len(New rtpSupplier))

                ' Now refer to index to remove and copy all items to temporary file not related to index
                For i = 1 To intRecNumToRemove - 1
                    FileGet(2, recSupplier_Read, i)
                    FilePut(3, recSupplier_Read, i)
                Next
                For i = intRecNumToRemove + 1 To intNumberOfSuppliers
                    FileGet(2, recSupplier_Read, i)
                    FilePut(3, recSupplier_Read, i - 1)
                Next
                FileClose(2, 3)

                ' Now delete old file and rename temporary file so it can be used
                My.Computer.FileSystem.DeleteFile(strFolderLocation & "Suppliers.dat")
                My.Computer.FileSystem.RenameFile(strFolderLocation & "Suppliers_temp.dat", "Suppliers.dat")

                ' Open new file
                FileOpen(2, strFolderLocation & "Suppliers.dat", OpenMode.Random, , , Len(New rtpSupplier))

                ' Amend number of suppliers
                intNumberOfSuppliers = intNumberOfSuppliers - 1

                Dim intLocNum As Integer
                If intNumberOfSuppliers > 0 Then

                    ' If records are present, find where to put supplier on file so suppliers remain in order of times used
                    If recSupplierKeep.bytTimesUsed > 0 Then

                        ' If number of times used exceeds 0, we must find where to put it in file
                        ' to retain its order of times used
                        Dim blnLocFound As Boolean
                        Do

                            ' Next item, inspect number of times used
                            intLocNum = intLocNum + 1
                            FileGet(2, recSupplier_Read, intLocNum)
                            If recSupplierKeep.bytTimesUsed >= recSupplier_Read.bytTimesUsed Then
                                blnLocFound = True
                            ElseIf intLocNum = intNumberOfSuppliers Then
                                intLocNum = intLocNum + 1
                                blnLocFound = True
                            End If
                        Loop Until blnLocFound
                        If intLocNum <= intNumberOfSuppliers Then

                            ' If records exist on or past the location number,
                            ' they must be moved up to make room
                            For i = intNumberOfSuppliers To intLocNum Step -1
                                FileGet(2, recSupplier_Read, i)
                                FilePut(2, recSupplier_Read, i + 1)
                            Next
                        End If
                    Else

                        ' If new times used is 0, location number will be end of file
                        intLocNum = intNumberOfSuppliers + 1
                    End If
                Else

                    ' In a blank file, new supplier can be added to line 1 without any checks
                    intLocNum = 1
                End If

                ' Now we can write the record to file in the correct location
                FilePut(2, recSupplierKeep, intLocNum)
            End If
            FileClose(2)

            ' Copy requisition form file to Printed folder and delete original
            FileGet(1, recReqFormEntry_Read, lstReqFormsList.SelectedIndex)
            Dim strOldFileName As String = recReqFormEntry_Read.strFileName
            intID = 1
            recReqFormEntry_Read.strFileName = strDate & "_" & intID & ".dat"
            blnFound = False
            Do
                If My.Computer.FileSystem.FileExists(strFolderLocation & "Printed Requisition Forms/" &
                                                     recReqFormEntry_Read.strFileName) Then
                    intID = intID + 1
                    recReqFormEntry_Read.strFileName = strDate & "_" & intID & ".dat"
                Else
                    blnFound = True
                End If
            Loop Until blnFound
            FileCopy(strFolderLocation & "Unprinted Requisition Forms/" & strOldFileName,
                     strFolderLocation & "Printed Requisition Forms/" & recReqFormEntry_Read.strFileName)
            My.Computer.FileSystem.DeleteFile(strFolderLocation &
                                              "Unprinted Requisition Forms/" & strOldFileName)

            ' Remove requisition form entry from Unprinted form list file
            subRemoveEntry("Unprinted", lstReqFormsList.SelectedIndex)
            FileClose()

            ' Update date of save
            recReqFormEntry_Read.dteDateOfSave = Date.Now()

            ' Open Printed forms file and find number of requisition form entries
            FileOpen(1, strFolderLocation & "Printed_Requisition_Forms.dat", OpenMode.Random, , , Len(New rtpReqFormEntry))
            Dim intNumberOfReqForms As Integer = FileLen(strFolderLocation & "Printed_Requisition_Forms.dat") / Len(New rtpReqFormEntry)

            ' Add requisition form entry to end of Printed form list file
            FilePut(1, recReqFormEntry_Read, intNumberOfReqForms + 1)
            FileClose(1)

            blpPrinted.Checked = True
        End If

        MessageBox.Show("The requisition form has been successfully exported to:-" &
                        vbCrLf & vbCrLf & " " & System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub butRemove_Click(sender As Object, e As EventArgs) Handles butRemove.Click
        ' Make sure user is sure about removing supplier
        If MessageBox.Show("Are you sure you want to remove the requisition form?",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            ' Retrieve file name of list box selection
            FileGet(1, recReqFormEntry_Read, lstReqFormsList.SelectedIndex)

            ' Remove requisition form from forms folder
            My.Computer.FileSystem.DeleteFile(strFolderLocation & strSelectedCategory & " Requisition Forms/" & Trim(recReqFormEntry_Read.strFileName))

            subRemoveEntry(strSelectedCategory, lstReqFormsList.SelectedIndex)

            subUpdateReqList()
        End If
    End Sub

    Private Sub frmReqMan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If Not frmReqEdit.blnOpeningExistingForm Then

            ' Upon closing this form, show the home screen
            frmHomeScreen.Show()
        End If

        ' Close all files
        FileClose()
    End Sub

End Class