' ╔════════════════════════════════════════════════════════════════╗
' ----Workshop Management System Project----------------------------
' ----Sam Rimington-------------------------------------------------
' ----A2 Computing--------------------------------------------------
' ----F454----------------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Requisition Form Editor---------------------------------------
' --The purpose of this form is to let the user manage create new---
' --and change or reuse existing requisition forms. Once forms------
' --have been filled in, they can be saved as a draft or final------
' --copy.-----------------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Date since last change: 04-12-2014----------------------------
' ╚════════════════════════════════════════════════════════════════╝

Imports WorMS.frmHomeScreen

Public Class frmReqEdit
    ' Declare variables, arrays and structures for use in this form
    Public blnOpeningExistingForm, blnAddResourcesFromLowStock As Boolean
    Public strSelectedCategory As String
    Dim blnSaving, blnQuit As Boolean
    Dim intNumberOfSuppliers As Integer
    Dim sinOverallCost As Single
    Dim strDate As String = CStr(Now.Day) & "-" & CStr(Now.Month) & "-" & CStr(Now.Year)
    Dim strResourceListFormat As String = "{0, -2}{1, -16}{2, -24}{3, -6}{4, -12}"
    Dim recReqFormEntry_Read As rtpReqFormEntry
    Public recReqFormEntryInput As rtpReqFormEntry
    Public recSupplier() As rtpSupplier
    Public recResource(0) As rtpReqFormResource


    Sub subAddResourceToList(ByVal intResourceIndex As Integer)
        ' Format item to add to resource list
        ' First declare variables for formatted items
        Dim strCatNum_Formatted, strName_Formatted As String

        ' Catalogue number
        strCatNum_Formatted = recResource(intResourceIndex).strCatalogueNumber
        If Len(recResource(intResourceIndex).strCatalogueNumber) > 14 Then
            strCatNum_Formatted = Mid(strCatNum_Formatted, 1, 14) & "…"
        End If

        ' Name
        strName_Formatted = recResource(intResourceIndex).strName
        If Len(recResource(intResourceIndex).strName) > 22 Then
            strName_Formatted = Mid(strName_Formatted, 1, 22) & "…"
        End If

        ' Add resource to resource list
        lstResourceList.Items.Add(String.Format(strResourceListFormat, intResourceIndex + 1, strCatNum_Formatted,
                                                strName_Formatted, recResource(intResourceIndex).bytQuantity,
                                                FormatCurrency(recResource(intResourceIndex).sinTotalCost)))
    End Sub

    Sub subClearListandAddHeader()
        lstResourceList.Items.Clear()
        lstResourceList.Items.Add(String.Format(strResourceListFormat, "", "Cat. Num", "Item Name", "Amnt", "Total Cost"))
    End Sub

    Sub subMakeReqFormFile(ByVal strSelectedCategory As String)
        ' Find a valid ID number to use for file name that does not clash with other files
        Dim intID As Integer
        Dim blnIDFound As Boolean
        Do
            intID = intID + 1
            If Not My.Computer.FileSystem.FileExists(strFolderLocation & strSelectedCategory & " Requisition Forms/" & strDate & "_" & intID & ".dat") Then
                blnIDFound = True
            End If
        Loop Until blnIDFound

        ' Open files to be used
        FileOpen(1, strFolderLocation & strSelectedCategory & "_Requisition_Forms.dat", OpenMode.Random, , , Len(New rtpReqFormEntry))
        FileOpen(2, strFolderLocation & strSelectedCategory & " Requisition Forms/" & strDate & "_" & intID & ".dat",
                 OpenMode.Random, , , Len(New rtpReqFormResource))

        ' Now we found an ID to use, put resources in file
        For i = 0 To recResource.Count - 1
            FilePut(2, recResource(i), i + 1)
        Next

        ' Assign remaining input elements to requisition form entry record structure
        Dim recNewReqFormEntry As rtpReqFormEntry
        recNewReqFormEntry.strFileName = ""
        recNewReqFormEntry.strAddress = ""
        recNewReqFormEntry.strAuthDeptManager = ""
        recNewReqFormEntry.strBenefitDetails = ""
        recNewReqFormEntry.strNewSupplierReason = ""
        recNewReqFormEntry.strSupplier = ""

        recNewReqFormEntry.strFileName = strDate & "_" & intID & ".dat"
        If cmbSupplier.SelectedItem <> "" Then
            recNewReqFormEntry.strSupplier = recSupplier(cmbSupplier.SelectedIndex).strName
        End If
        recNewReqFormEntry.strAddress = txtAddress.Text
        recNewReqFormEntry.strAuthDeptManager = txtAuthDeptManager.Text
        recNewReqFormEntry.strNewSupplierReason = txtNewSupplierReason.Text
        recNewReqFormEntry.strBenefitDetails = txtNewSupplierBenefits.Text
        recNewReqFormEntry.dteDateOfSave = Now.Date()
        recNewReqFormEntry.sinOverallCost = txtOverallCost.Text
        recNewReqFormEntry.bytNumberOfResources = recResource.Count

        ' Find number of requisition forms
        Dim intNumberOfReqForms As Integer = FileLen(strFolderLocation & strSelectedCategory & "_Requisition_Forms.dat") / Len(New rtpReqFormEntry)

        ' Write entry record structure to end of requisition form list file
        FilePut(1, recNewReqFormEntry, intNumberOfReqForms + 1)
    End Sub

    Sub subResetInputObjectColours()
        ' Reset all colo[u]rs of input objects
        txtAuthDeptManager.BackColor = System.Drawing.SystemColors.Window
        txtNewSupplierReason.BackColor = System.Drawing.SystemColors.Window
        txtNewSupplierBenefits.BackColor = System.Drawing.SystemColors.Window
        lstResourceList.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub frmReqEdit_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Open suppliers file and find number of suppliers
        FileOpen(3, strFolderLocation & "Suppliers.dat", OpenMode.Random, , , Len(New rtpSupplier))
        intNumberOfSuppliers = FileLen(strFolderLocation & "Suppliers.dat") / Len(New rtpSupplier)

        If intNumberOfSuppliers > 0 Then

            ' If suppliers exist, add them to supplier array and combo box
            ReDim recSupplier(intNumberOfSuppliers - 1)
            For i = 0 To intNumberOfSuppliers - 1
                FileGet(3, recSupplier(i), i + 1)

                ' Trim supplier record strings
                recSupplier(i).strName = Trim(recSupplier(i).strName)
                recSupplier(i).strAddress = Trim(recSupplier(i).strAddress)

                If Len(recSupplier(i).strName) <= 20 Then
                    cmbSupplier.Items.Add(recSupplier(i).strName & " (" & recSupplier(i).bytTimesUsed & ")")
                Else
                    cmbSupplier.Items.Add(Mid(recSupplier(i).strName, 1, 19) & "… (" &
                                          recSupplier(i).bytTimesUsed & ")")
                End If
            Next

            ' Add header to resource list box
            subClearListandAddHeader()

            If blnOpeningExistingForm Then

                ' See if stored supplier exists in suppliers file
                Dim i As Integer = -1
                Dim blnFound As Boolean
                If Len(Trim(recReqFormEntryInput.strSupplier)) <> 63 Then
                    Do
                        i = i + 1
                        If Trim(recReqFormEntryInput.strSupplier) = recSupplier(i).strName Then

                            ' If so, we can assign the supplier combo box to it
                            blnFound = True
                        End If
                    Loop Until blnFound Or i = recSupplier.Count - 1
                    If Not blnFound And i = recSupplier.Count - 1 Then

                        ' If not, show a message box informing the user that the supplier can't be found
                        MessageBox.Show("The supplier stored in this form cannot be found in the suppliers file. If you wish to use:-" & vbCrLf & vbCrLf & " " &
                                        Trim(recReqFormEntryInput.strSupplier) & vbCrLf & vbCrLf & "as the supplier, add it through the Supplier Manager.",
                                        "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        cmbSupplier.SelectedIndex = -1
                    Else
                        cmbSupplier.SelectedIndex = i
                        txtAddress.Text = Trim(recReqFormEntryInput.strAddress)
                    End If
                Else

                    ' If supplier is blank, we simply set the combo box to blank
                    cmbSupplier.SelectedIndex = -1
                End If

                ' Assign remaining values of selected form to Requisition Form Editor input elements
                txtAuthDeptManager.Text = Trim(recReqFormEntryInput.strAuthDeptManager)
                txtNewSupplierReason.Text = Trim(recReqFormEntryInput.strNewSupplierReason)
                txtNewSupplierBenefits.Text = Trim(recReqFormEntryInput.strBenefitDetails)
                txtOverallCost.Text = recReqFormEntryInput.sinOverallCost.ToString("N2")

                sinOverallCost = recReqFormEntryInput.sinOverallCost

                ' Add resources to list box
                FileOpen(2, strFolderLocation & strSelectedCategory & " Requisition Forms/" & Trim(recReqFormEntryInput.strFileName),
                         OpenMode.Random, , , Len(New rtpReqFormResource))
                For i = 1 To recReqFormEntryInput.bytNumberOfResources
                    ReDim Preserve recResource(i - 1)
                    FileGet(2, recResource(i - 1), i)
                    recResource(i - 1).strCatalogueNumber = Trim(recResource(i - 1).strCatalogueNumber)
                    recResource(i - 1).strName = Trim(recResource(i - 1).strName)
                    subAddResourceToList(i - 1)
                Next
                FileClose(2)

                blnOpeningExistingForm = False
            End If

            If blnAddResourcesFromLowStock Then
                For i = 0 To recResource.Count - 1
                    subAddResourceToList(i)
                Next
            End If
        Else

            ' If no records can be found, display a message box to inform the user this form cannot be used without suppliers
            MessageBox.Show("No existing suppliers could be found in the specified folder location. In order to use this form, suppliers must be added through the Supplier Manager.",
                            "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Close this form
            blnQuit = True
            Me.Close()
        End If
    End Sub

    Private Sub cmbSupplier_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSupplier.SelectedValueChanged
        If cmbSupplier.SelectedIndex > -1 Then

            ' Set Address box text to address of the supplier selected
            txtAddress.Text = recSupplier(cmbSupplier.SelectedIndex).strAddress
        End If
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

    Private Sub lstResourceList_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstResourceList.SelectedValueChanged
        ' Check that header has not been selected
        If lstResourceList.SelectedIndex > 0 Then
            butAdd_Res.Enabled = True
            butAdd_Res.Text = "Change Resource"
            butRemove_Res.Enabled = True
        Else
            lstResourceList.SelectedIndex = -1
            If recResource.Count = 8 Then
                butAdd_Res.Enabled = False
            End If
            butAdd_Res.Text = "Add New Resource"
            butRemove_Res.Enabled = False
        End If
    End Sub

    Private Sub butAdd_Res_Click(sender As Object, e As EventArgs) Handles butAdd_Res.Click
        If butAdd_Res.Text = "Add New Resource" Then
            dlgReqEdit_ResAdd.Text = "Add Resource to Requisition Form - WorMS"

            ' Open the add resource dialog as a dialog menu
            If dlgReqEdit_ResAdd.ShowDialog() = Windows.Forms.DialogResult.OK Then

                ' Write new resource to array
                If recResource(0).strName <> "" Then
                    ReDim Preserve recResource(recResource.Count)
                End If
                recResource(recResource.Count - 1) = dlgReqEdit_ResAdd.recNewResource

                ' Reset the colo[u]r of the resource list
                lstResourceList.BackColor = System.Drawing.SystemColors.Window

                subAddResourceToList(recResource.Count - 1)

                ' Add to total cost
                sinOverallCost = sinOverallCost + recResource(recResource.Count - 1).sinTotalCost

                ' Update total cost
                txtOverallCost.Text = sinOverallCost.ToString("N2")
            End If
        Else
            dlgReqEdit_ResAdd.Text = "Change Resource in Requisition Form - WorMS"
            Dim intSelectedResIndex As Integer = lstResourceList.SelectedIndex - 1

            ' Assign selected resource values to dialog menu input elements
            ' Make sure a value of 0 in cost per piece is not shown in its text box
            dlgReqEdit_ResAdd.txtCatNum.Text = recResource(intSelectedResIndex).strCatalogueNumber
            dlgReqEdit_ResAdd.txtName.Text = recResource(intSelectedResIndex).strName
            If recResource(intSelectedResIndex).sinCostPerPiece > 0 Then
                dlgReqEdit_ResAdd.txtCostPP.Text = recResource(intSelectedResIndex).sinCostPerPiece
            End If
            dlgReqEdit_ResAdd.spnQuantity.Value = recResource(intSelectedResIndex).bytQuantity
            dlgReqEdit_ResAdd.txtDiscount.Text = recResource(intSelectedResIndex).sinDiscount
            dlgReqEdit_ResAdd.txtVAT.Text = recResource(intSelectedResIndex).sinVAT

            ' Open the change resource dialog as a dialog menu
            If dlgReqEdit_ResAdd.ShowDialog() = Windows.Forms.DialogResult.OK Then

                ' If OK was selected, and data was validated,
                ' Remove old overall cost from total cost
                sinOverallCost = sinOverallCost - recResource(intSelectedResIndex).sinTotalCost

                ' Write updated resource to array
                recResource(intSelectedResIndex) = dlgReqEdit_ResAdd.recNewResource

                ' Clear resource list and add header to resource list box
                subClearListandAddHeader()

                ' Reset the colo[u]r of the resource list
                lstResourceList.BackColor = System.Drawing.SystemColors.Window

                If recResource.Count = 8 Then
                    butAdd_Res.Enabled = False
                End If
                butAdd_Res.Text = "Add New Resource"
                butRemove_Res.Enabled = False

                ' Update resource list
                For i = 0 To recResource.Count - 1
                    subAddResourceToList(i)
                Next

                ' Add to total cost
                sinOverallCost = sinOverallCost + recResource(intSelectedResIndex).sinTotalCost

                ' Update total cost
                txtOverallCost.Text = sinOverallCost.ToString("N2")
            End If

            ' Make sure add resource button is disabled if eight resources have already been input
            If recResource.Count = 8 Then
                butAdd_Res.Enabled = False
            End If
        End If
    End Sub

    Private Sub butClear_Res_Click(sender As Object, e As EventArgs) Handles butClear_Res.Click
        lstResourceList.SelectedIndex = -1
    End Sub

    Private Sub butRemove_Res_Click(sender As Object, e As EventArgs) Handles butRemove_Res.Click
        ' Verify if user really wishes to remove resource
        If MessageBox.Show("Are you sure you want to remove the selected resource?",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            ' If so, assign list box selection to variable
            Dim bytResIndexToRemove As Byte = lstResourceList.SelectedIndex - 1

            ' Remove from total cost
            sinOverallCost = sinOverallCost - recResource(bytResIndexToRemove).sinTotalCost

            ' Update total cost
            txtOverallCost.Text = sinOverallCost.ToString("N2")

            ' Make sure add resource button is enabled
            butAdd_Res.Enabled = True

            ' Clear resource list and add header to resource list box
            subClearListandAddHeader()

            butAdd_Res.Text = "Add New Resource"
            butRemove_Res.Enabled = False

            ' See if values exist past index to be removed
            If recResource.Count > 1 Then

                ' If so, reorder items after index
                For i = bytResIndexToRemove + 1 To recResource.Count - 1
                    recResource(i - 1) = recResource(i)
                Next

                ' Redim the array with one less index
                ReDim Preserve recResource(recResource.Count - 2)

                ' Update resource list
                For i = 0 To recResource.Count - 1
                    subAddResourceToList(i)
                Next

            Else
                ' Otherwise, clear resource array
                ReDim recResource(0)
            End If
        End If
    End Sub

    Private Sub butClear_Form_Click(sender As Object, e As EventArgs) Handles butClear_Form.Click
        ' Verify if user really wishes to clear form
        If MessageBox.Show("Are you sure you want to clear the form? Any data input will be lost.",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            ' If so, clear all data input in the form
            cmbSupplier.SelectedIndex = -1
            txtAddress.Text = ""
            txtAuthDeptManager.Text = ""
            txtNewSupplierReason.Text = ""
            txtNewSupplierBenefits.Text = ""

            subResetInputObjectColours()

            ' Clear resource array
            ReDim recResource(0)

            ' Clear resource list and add header
            subClearListandAddHeader()

            butAdd_Res.Text = "Add New Resource"
            butRemove_Res.Enabled = False

            ' Clear total cost variable and text box value
            sinOverallCost = 0
            txtOverallCost.Text = "0.00"
        End If
    End Sub

    Private Sub butSaveDraft_Click(sender As Object, e As EventArgs) Handles butSaveDraft.Click
        ' Verify data input
        Dim strErrors As String = ""

        subResetInputObjectColours()

        ' If new supplier reasons text box input is not blank, check there are no carriage returns
        If InStr(txtNewSupplierReason.Text, vbCrLf) > 0 Then
            strErrors = "The new supplier reasons must be on a single line." & vbCrLf
            txtNewSupplierReason.BackColor = Color.Tomato
        End If

        ' If new supplier benefits text box input is not blank, check there are no carriage returns
        If InStr(txtNewSupplierBenefits.Text, vbCrLf) > 0 Then
            strErrors = strErrors & "The new supplier benefits must be on a single line." & vbCrLf
            txtNewSupplierBenefits.BackColor = Color.Tomato
        End If

        ' Check that resources have been added
        If lstResourceList.Items.Count < 2 Then
            strErrors = strErrors & "The requisition form must contain at least one resource." & vbCrLf
            lstResourceList.BackColor = Color.Tomato
        ElseIf blnAddResourcesFromLowStock Then

            ' If we have added resources from the low stock dialog, check that none
            ' of the catalogue number strings in the resources are blank
            Dim blnAbort As Boolean
            Dim i As Integer = -1
            Do
                i = i + 1
                If recResource(i).strCatalogueNumber = "" Then
                    strErrors = strErrors & "All resources must contain a catalogue number." & vbCrLf
                    lstResourceList.BackColor = Color.Tomato
                    blnAbort = True
                End If
                If Not blnAbort Then
                    blnAddResourcesFromLowStock = False
                End If
            Loop Until blnAbort Or i = recResource.Count - 1
        End If

        If strErrors = "" Then

            subMakeReqFormFile("Draft")

            ' Ensure drafts bullet point in frmReqMan is checked
            frmReqMan.blpDrafts.Checked = True

            ' Close this form and show the Requisition Form Manager
            blnSaving = True

            Me.Close()
            frmReqMan.Show()
        Else
            MessageBox.Show(strErrors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub butSaveFinal_Click(sender As Object, e As EventArgs) Handles butSaveFinal.Click
        ' Verify data input
        Dim strErrors As String = ""

        subResetInputObjectColours()

        ' Check that a supplier has been selected
        If cmbSupplier.SelectedIndex < 0 Then
            strErrors = "The requisition form must contain a supplier." & vbCrLf
        End If

        ' Check that the authorised department manager text box input is not blank
        If txtAuthDeptManager.Text = "" Then
            strErrors = strErrors & "The authorised department manager cannot be blank." & vbCrLf
            txtAuthDeptManager.BackColor = Color.Tomato
        End If

        ' If new supplier reasons text box input is not blank, check there are no carriage returns
        If InStr(txtNewSupplierReason.Text, vbCrLf) > 0 Then
            strErrors = strErrors & "The new supplier reasons must be on a single line." & vbCrLf
            txtNewSupplierReason.BackColor = Color.Tomato
        End If

        ' If new supplier benefits text box input is not blank, check there are no carriage returns
        If InStr(txtNewSupplierBenefits.Text, vbCrLf) > 0 Then
            strErrors = strErrors & "The new supplier benefits must be on a single line." & vbCrLf
            txtNewSupplierBenefits.BackColor = Color.Tomato
        End If

        ' Check that resources have been added
        If lstResourceList.Items.Count < 2 Then
            strErrors = strErrors & "The requisition form must contain at least one resource." & vbCrLf
            lstResourceList.BackColor = Color.Tomato
        ElseIf blnAddResourcesFromLowStock Then
            ' If we have added resources from the low stock dialog, check that none
            ' of the catalogue number strings in the resources are blank
            Dim blnAbort As Boolean
            Dim i As Integer = -1
            Do
                i = i + 1
                If recResource(i).strCatalogueNumber = "" Then
                    strErrors = strErrors & "All resources must contain a catalogue number." & vbCrLf
                    lstResourceList.BackColor = Color.Tomato
                    blnAbort = True
                End If
            Loop Until blnAbort Or i = recResource.Count - 1
            If Not blnAbort Then
                blnAddResourcesFromLowStock = False
            End If
        End If

        If strErrors = "" Then

            subMakeReqFormFile("Unprinted")

            ' Ensure unprinted bullet point in frmReqMan is checked
            frmReqMan.blpUnprinted.Checked = True

            ' Close this form and show the Requisition Form Manager
            blnSaving = True

            Me.Close()
            frmReqMan.Show()
        Else
            MessageBox.Show(strErrors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub frmReqEdit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSaving And Not blnQuit Then
            ' Make sure user is sure about closing form
            If MessageBox.Show("Are you sure you want to close this form? Unsaved changes will be lost.",
                               "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                ' Upon clicking OK, let this form close and show the home screen
                FileClose()
                frmHomeScreen.Show()
            Else

                ' Otherwise, stop this form from closing
                e.Cancel = True
            End If
        Else
            blnSaving = False
        End If

        If blnQuit Then
            blnQuit = False
            FileClose()
            frmHomeScreen.Show()
        End If
    End Sub

End Class