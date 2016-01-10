' ╔════════════════════════════════════════════════════════════════╗
' ----Workshop Management System Project----------------------------
' ----Sam Rimington-------------------------------------------------
' ----A2 Computing--------------------------------------------------
' ----F454----------------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Supplier Manager----------------------------------------------
' --The purpose of this form is to let the user manage suppliers----
' --for usage in requisition forms and track their usage.-----------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Date since last change: 04-12-2014----------------------------
' ╚════════════════════════════════════════════════════════════════╝

Imports WorMS.frmHomeScreen

Public Class frmSupMan
    ' Declare variables, arrays and structures for use in this form
    Dim intNumberOfSuppliers As Integer
    Dim recSupplier() As rtpSupplier
    Dim recSupplier_Read As rtpSupplier

    Sub subUpdateSuppliers()
        ' If records exist, add them to supplier array and list box
        ' First, clear list box
        lstSuppliersList.Items.Clear()

        ' Add header to list box
        lstSuppliersList.Items.Add(String.Format("{0, -31}", "Name") & "Times Used")

        ReDim Preserve recSupplier(intNumberOfSuppliers - 1)
        For i = 0 To intNumberOfSuppliers - 1
            FileGet(1, recSupplier(i), i + 1)

            ' Trim strings that have just been read
            recSupplier(i).strName = Trim(recSupplier(i).strName)
            recSupplier(i).strAddress = Trim(recSupplier(i).strAddress)

            ' Format Name properly (add ellipsis to end if too large)
            Dim strName_Formatted As String = recSupplier(i).strName
            If Len(strName_Formatted) > 30 Then
                strName_Formatted = Mid(strName_Formatted, 1, 29) & "…"
            End If
            lstSuppliersList.Items.Add(String.Format("{0, -31}", strName_Formatted) &
                                       recSupplier(i).bytTimesUsed)
        Next
    End Sub

    Sub subRemoveSupplier(ByVal intRecNumToRemove As Integer)
        ' Create temporary file
        FileOpen(2, strFolderLocation & "Suppliers_temp.dat", OpenMode.Random, , , Len(New rtpSupplier))

        ' Now refer to index to remove and copy all items to temporary file not related to index
        For i = 1 To intRecNumToRemove - 1
            FileGet(1, recSupplier_Read, i)
            FilePut(2, recSupplier_Read, i)
        Next
        For i = intRecNumToRemove + 1 To intNumberOfSuppliers
            FileGet(1, recSupplier_Read, i)
            FilePut(2, recSupplier_Read, i - 1)
        Next
        FileClose(1, 2)

        ' Now delete old file and rename temporary file so it can be used
        My.Computer.FileSystem.DeleteFile(strFolderLocation & "Suppliers.dat")
        My.Computer.FileSystem.RenameFile(strFolderLocation & "Suppliers_temp.dat", "Suppliers.dat")

        ' Amend number of suppliers
        intNumberOfSuppliers = intNumberOfSuppliers - 1

        ' Open new file
        FileOpen(1, strFolderLocation & "Suppliers.dat", OpenMode.Random, , , Len(New rtpSupplier))
    End Sub

    Sub subResetInputObjectColours()
        ' Reset all colo[u]rs of input objects
        txtName.BackColor = System.Drawing.SystemColors.Window
        txtAddress.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub frmSupMan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Open suppliers file and find number of suppliers
        FileOpen(1, strFolderLocation & "Suppliers.dat", OpenMode.Random, , , Len(New rtpSupplier))
        intNumberOfSuppliers = FileLen(strFolderLocation & "Suppliers.dat") / Len(New rtpSupplier)

        If intNumberOfSuppliers > 0 Then
            subUpdateSuppliers()
        Else
            ' If no records can be found, add a list box item to inform the user of this
            lstSuppliersList.Items.Add("No suppliers can be found")
        End If

        ' Disable Remove button
        butRemove.Enabled = False
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

    Private Sub txtName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtName.KeyPress
        ' Upon typing into the supplier name text box, rename add supplier button back to Add
        butAdd.Text = "Add"
    End Sub

    Private Sub butAdd_Click(sender As Object, e As EventArgs) Handles butAdd.Click
        ' Validate data input first
        Dim strErrors As String = ""

        subResetInputObjectColours()

        ' Check that the supplier name text box input is not blank
        If txtName.Text = "" Then
            strErrors = "The supplier name cannot be blank." & vbCrLf
            txtName.BackColor = Color.Tomato
        End If

        ' Check that the supplier address text box input is not blank
        If txtAddress.Text = "" Then
            strErrors = strErrors & "The supplier address cannot be blank." & vbCrLf
            txtAddress.BackColor = Color.Tomato

            ' If input exists, check that there are no carriage returns
        ElseIf InStr(txtAddress.Text, vbCrLf) > 0 Then
            strErrors = strErrors & "The supplier address must be on a single line." & vbCrLf
            txtAddress.BackColor = Color.Tomato
        End If

        If strErrors = "" Then
            ' Assign values to new supplier structure
            Dim recNewSupplier As rtpSupplier
            recNewSupplier.strName = txtName.Text
            recNewSupplier.strAddress = txtAddress.Text
            recNewSupplier.bytTimesUsed = spnTimesUsed.Value

            Dim intLocNum As Integer
            If butAdd.Text = "Change" Then

                ' If we are changing a record, it must be deleted and added to the file again
                ' to retain its order of times used
                subRemoveSupplier(lstSuppliersList.SelectedIndex)
            End If

            If intNumberOfSuppliers > 0 Then

                ' If records are present, find where to put supplier on file so suppliers remain in order of times used
                If recNewSupplier.bytTimesUsed > 0 Then

                    ' If number of times used exceeds 0, we must find where to put it in file
                    ' to retain its order of times used
                    Dim blnLocFound As Boolean
                    Do

                        ' Next item, inspect number of times used
                        intLocNum = intLocNum + 1
                        FileGet(1, recSupplier_Read, intLocNum)
                        If recNewSupplier.bytTimesUsed >= recSupplier_Read.bytTimesUsed Then
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
                            FileGet(1, recSupplier_Read, i)
                            FilePut(1, recSupplier_Read, i + 1)
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
            FilePut(1, recNewSupplier, intLocNum)

            ' Increment the number of suppliers
            intNumberOfSuppliers = intNumberOfSuppliers + 1

            ' Now update the list box
            subUpdateSuppliers()

            ' Clear the input elements
            txtName.Text = ""
            txtAddress.Text = ""
            spnTimesUsed.Value = 0

            ' Rename Add button to Add
            butAdd.Text = "Add"

            ' Disable Remove button
            butRemove.Enabled = False

            ' Make sure list box is enabled and selected value is cleared
            lstSuppliersList.Enabled = True
            lstSuppliersList.SelectedIndex = -1
        Else
            MessageBox.Show(strErrors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub butClear_Click(sender As Object, e As EventArgs) Handles butClear.Click
        ' Clear the input elements
        txtName.Text = ""
        txtAddress.Text = ""
        spnTimesUsed.Value = 0

        subResetInputObjectColours()

        ' Clear selected value in list box
        lstSuppliersList.SelectedIndex = -1
    End Sub

    Private Sub butRemove_Click(sender As Object, e As EventArgs) Handles butRemove.Click
        ' Make sure user is sure about removing supplier
        If MessageBox.Show("Are you sure you want to remove the selected supplier?",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            subRemoveSupplier(lstSuppliersList.SelectedIndex)

            ' Check if records still exist
            If intNumberOfSuppliers > 0 Then

                ' If so, update the supplier array and list box
                subUpdateSuppliers()

                ' Make sure list box selection is cleared
                lstSuppliersList.SelectedIndex = -1
            Else

                ' Otherwise, clear list box
                lstSuppliersList.Items.Clear()

                ' Add a list box item to inform the user that no suppliers can be found
                lstSuppliersList.Items.Add("No suppliers can be found")
            End If

            ' Rename Add button to Add
            butAdd.Text = "Add"

            ' Disable Remove button
            butRemove.Enabled = False

            ' Clear the input elements
            txtName.Text = ""
            txtAddress.Text = ""
            spnTimesUsed.Value = 0
        End If
    End Sub

    Private Sub lstSuppliersList_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstSuppliersList.SelectedValueChanged
        subResetInputObjectColours()

        ' Check that header has not been selected
        If lstSuppliersList.SelectedIndex > 0 Then

            ' Assign data from selected index to input elements
            txtName.Text = recSupplier(lstSuppliersList.SelectedIndex - 1).strName
            txtAddress.Text = recSupplier(lstSuppliersList.SelectedIndex - 1).strAddress
            spnTimesUsed.Value = recSupplier(lstSuppliersList.SelectedIndex - 1).bytTimesUsed

            ' Rename Add button to Change
            butAdd.Text = "Change"

            ' Enable Remove button
            butRemove.Enabled = True
        Else

            ' Otherwise, rename Add button to Add
            butAdd.Text = "Add"

            ' Disable Remove button
            butRemove.Enabled = False

            ' Clear list box selection
            lstSuppliersList.SelectedIndex = -1
        End If
    End Sub

    Private Sub frmSupMan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Upon closing this form, close all files and show the home screen
        FileClose()
        frmHomeScreen.Show()
    End Sub
End Class