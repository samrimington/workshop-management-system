' ╔════════════════════════════════════════════════════════════════╗
' ----Workshop Management System Project----------------------------
' ----Sam Rimington-------------------------------------------------
' ----A2 Computing--------------------------------------------------
' ----F454----------------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Student Information Viewer/Editor-----------------------------
' --The purpose of this form is to let the user enter information---
' --to add a new student or to view or change the information of----
' --an existing student.--------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Date since last change: 04-12-2014----------------------------
' ╚════════════════════════════════════════════════════════════════╝

Imports WorMS.frmHomeScreen

Public Class dlgStuMan_InfoView
    ' Declare variables and structures for use in this form
    Public intNumberOfStudents, intLocNum As Integer
    Public blnViewInfo, blnChange As Boolean
    Dim intNumberOfResources As Integer
    Dim blnResourcesChanged As Boolean
    Dim strFileName As String
    Dim recStudentEntry As rtpStudentEntry
    Dim recResources() As rtpStudentResource

    Sub subUpdateResourceList()
        lstResources.Items.Clear()
        If intNumberOfResources > 0 Then
            lstResources.Items.Add(String.Format("{0, -32}", "Name") & "Quantity")
            For i = 1 To intNumberOfResources

                ' Next item, read from file and add to resource list
                lstResources.Items.Add(String.Format("{0, -32}", recResources(i - 1).strName) &
                                       recResources(i - 1).sinQuantity & " " & recResources(i - 1).strUnit)
            Next
        End If
    End Sub

    Private Sub dlgStuMan_InfoView_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Copy number of students to here
        intNumberOfStudents = frmStuMan.intNumberOfStudents

        ' Reset number of resources variable,
        ' so data from previously opened students do not mix
        intNumberOfResources = 0

        ' Check whether we are viewing/changing an existing record or adding a new one
        If blnChange Or blnViewInfo Then

            ' Retrieve data from list box index and assign to info view dialog input elements
            FileGet(1, recStudentEntry, intLocNum)
            txtName.Text = Trim(recStudentEntry.strName)
            cmbLevel.SelectedItem = recStudentEntry.strLevel
            txtCostOwed.Text = recStudentEntry.sinCostOwed
            intNumberOfResources = recStudentEntry.bytNumberOfResources
            If recStudentEntry.blnPaid Then
                blpPaid_Yes.Checked = True
            Else
                blpPaid_No.Checked = True
            End If
            If recStudentEntry.blnReceiptPrinted Then
                blpPrinted_Yes.Checked = True
            Else
                blpPrinted_No.Checked = True
            End If

            ' Generate a filename
            strFileName = Replace(Trim(recStudentEntry.strName), " ", "_")

            ' Open student resources file
            FileOpen(2, strFolderLocation & "Student Resources/" & strFileName & ".dat", OpenMode.Random, , , Len(New rtpStudentResource))

            ' Assign student resources to resources list box
            If intNumberOfResources > 0 Then
                For i = 1 To intNumberOfResources
                    ReDim Preserve recResources(i - 1)
                    FileGet(2, recResources(i - 1), i)

                    ' Trim strings in resources
                    recResources(i - 1).strName = Trim(recResources(i - 1).strName)
                    recResources(i - 1).strUnit = Trim(recResources(i - 1).strUnit)
                Next
            End If

            subUpdateResourceList()

            ' Prevent name text box input
            txtName.ReadOnly = True
        Else

            ' If adding a student, assign placeholder values
            cmbLevel.SelectedIndex = 0
            blpPaid_No.Checked = True
            blpPrinted_No.Checked = True
        End If
        If blnViewInfo Then

            ' If we are only viewing student information, disable input
            cmbLevel.Enabled = False
            txtCostOwed.ReadOnly = True
            blpPaid_Yes.Enabled = False
            blpPaid_No.Enabled = False
            blpPrinted_Yes.Enabled = False
            blpPrinted_No.Enabled = False
            lstResources.SelectionMode = SelectionMode.None
            butClear_Res.Enabled = False
            butRemove_Res.Enabled = False
            butOK.Enabled = False
        End If

        ' Disable Remove Resource button
        butRemove_Res.Enabled = False
    End Sub

    Private Sub lstResources_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstResources.SelectedValueChanged
        If Not blnViewInfo Then
            If lstResources.SelectedIndex > 0 Then
                butRemove_Res.Enabled = True
            Else
                butRemove_Res.Enabled = False
                lstResources.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub butClear_Res_Click(sender As Object, e As EventArgs) Handles butClear_Res.Click
        ' Clear resource list box selection
        lstResources.SelectedIndex = -1
    End Sub

    Private Sub butRemove_Res_Click(sender As Object, e As EventArgs) Handles butRemove_Res.Click
        ' Make sure user is sure about removing resource
        If MessageBox.Show("Are you sure you want to remove the selected resource?",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            ' Assign value of selected resource index to variable
            Dim intResIndexToRemove As Integer = lstResources.SelectedIndex - 1

            ' Move all resources in resources array after the index to be removed one place down
            For i = intResIndexToRemove + 1 To recResources.Count - 1
                recResources(i - 1) = recResources(i)
            Next

            ' Update number of resources and max resource index variables
            intNumberOfResources = intNumberOfResources - 1

            ' Redeclare resources array with one less index
            ReDim Preserve recResources(intNumberOfResources - 1)

            blnResourcesChanged = True

            subUpdateResourceList()
        End If
    End Sub

    Private Sub hypHelp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles hypHelp.LinkClicked
        ' Upon clicking the Help hyperlink, open the online help for this form
        dlgHelp.Close()
        dlgHelp.strFormName = Me.Name
        dlgHelp.Show()
    End Sub

    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
        ' Verify data input
        Dim strErrors As String = ""

        ' Reset all colo[u]rs of input objects
        txtName.BackColor = System.Drawing.SystemColors.Window
        txtCostOwed.BackColor = System.Drawing.SystemColors.Window

        ' If we are adding a new student, check that the student name text box input is not blank
        If Not blnChange Then
            If txtName.Text = "" Then
                strErrors = "The student name cannot be blank." & vbCrLf
                txtName.BackColor = Color.Tomato

                ' If true, check that the input contains no forbidden filename characters
            Else
                Dim blnInvalid As Boolean
                Dim strFileName_Test As String = Replace(txtName.Text, " ", "_")
                For Each chrBadChar As Char In System.IO.Path.GetInvalidFileNameChars
                    If InStr(strFileName_Test, chrBadChar) > 0 Then
                        blnInvalid = True
                        Exit For
                    End If
                Next

                If blnInvalid Then
                    strErrors = "The student name cannot contain any of the following characters:" & vbCrLf &
                        " \ / : * ? "" < > |" & vbCrLf
                    txtName.BackColor = Color.Tomato

                    ' If true, check that the input is in the correct format for a name (capital letters at the start of each word)
                Else
                    Dim strName_Temp As String = txtName.Text
                    Dim strName_OldTemp As String = ""
                    Do
                        If Mid(strName_Temp, 1, 1) < "A" Or Mid(strName_Temp, 1, 1) > "Z" Then
                            blnInvalid = True
                        Else
                            strName_OldTemp = strName_Temp
                            strName_Temp = Mid(strName_Temp, InStr(strName_Temp, " ") + 1)
                        End If
                    Loop Until strName_Temp = strName_OldTemp Or blnInvalid

                    If blnInvalid Then
                        strErrors = "The student name must have capital letters at the start of each word." & vbCrLf
                        txtName.BackColor = Color.Tomato

                        ' If all of this is true and other students exist on file,
                        ' check that this student name does not already exist
                    ElseIf intNumberOfStudents > 0 Then
                        Dim i As Integer
                        Do
                            i = i + 1
                            FileGet(1, recStudentEntry, i)
                            If Trim(recStudentEntry.strName) = txtName.Text Then
                                blnInvalid = True
                            End If
                        Loop Until i = intNumberOfStudents Or blnInvalid

                        If blnInvalid Then
                            strErrors = "This student name already exists on file." & vbCrLf
                            txtName.BackColor = Color.Tomato
                        End If
                    End If
                End If
            End If
        End If

        ' Check that the cost owed text box input is not blank
        If txtCostOwed.Text = "" Then
            strErrors = strErrors & "The cost owed cannot be blank." & vbCrLf
            txtCostOwed.BackColor = Color.Tomato

            ' If so, check that input is numeric and then check that it is a positive number
        ElseIf Not IsNumeric(txtCostOwed.Text) Then
            strErrors = strErrors & "The cost owed must be a number." & vbCrLf
            txtCostOwed.BackColor = Color.Tomato
        ElseIf txtCostOwed.Text < 0 Then
            strErrors = strErrors & "The cost owed must be more than or equal to 0." & vbCrLf
            txtCostOwed.BackColor = Color.Tomato

            ' Finally, if all of this is true, check that the input does not exceed two decimal places
            ' To do this verification, a decimal point must exist
        ElseIf InStr(txtCostOwed.Text, ".") > 0 Then
            If Len(Mid(txtCostOwed.Text, InStr(txtCostOwed.Text, ".") + 1)) > 2 Then
                strErrors = strErrors & "The cost owed must not exceed two decimal places." & vbCrLf
                txtCostOwed.BackColor = Color.Tomato
            End If
        End If

        If strErrors = "" Then

            ' Assign data input to student records
            Dim recNewEntry As rtpStudentEntry
            recNewEntry.strName = txtName.Text
            recNewEntry.strLevel = cmbLevel.SelectedItem
            recNewEntry.sinCostOwed = txtCostOwed.Text
            recNewEntry.bytNumberOfResources = intNumberOfResources
            If blpPaid_Yes.Checked Then
                recNewEntry.blnPaid = True
            Else
                recNewEntry.blnPaid = False
            End If
            If blpPrinted_Yes.Checked Then
                recNewEntry.blnReceiptPrinted = True
            Else
                recNewEntry.blnReceiptPrinted = False
            End If

            ' Check that we are not changing a record
            If Not blnChange Then

                ' Find location number so records are sorted in alphabetic order of name
                If intNumberOfStudents > 0 Then
                    intLocNum = 0
                    Dim intNewNameLen As Integer = Len(recNewEntry.strName)
                    Dim blnLocFound As Boolean
                    Do
                        intLocNum = intLocNum + 1
                        FileGet(1, recStudentEntry, intLocNum)

                        ' Next item, find maximum number of characters to search to
                        Dim intMaxLen As Integer
                        Dim intNameLen As Integer = Len(recStudentEntry.strName)
                        If intNewNameLen > intNameLen Then
                            intMaxLen = intNameLen + 1
                        Else
                            intMaxLen = intNewNameLen + 1
                        End If

                        ' Inspect each character to see where new resource should be placed
                        Dim intCharNum As Integer = 1
                        Dim blnAbort As Boolean = False
                        Do While intCharNum <= intMaxLen And Not blnAbort
                            Select Case Mid(recNewEntry.strName, intCharNum, 1)
                                Case Is < Mid(recStudentEntry.strName, intCharNum, 1)
                                    blnAbort = True
                                    blnLocFound = True
                                Case Is > Mid(recStudentEntry.strName, intCharNum, 1)
                                    blnAbort = True
                                Case Else
                                    intCharNum = intCharNum + 1
                            End Select
                        Loop
                    Loop Until blnLocFound Or intLocNum = intNumberOfStudents
                    If Not blnLocFound And intLocNum = intNumberOfStudents Then
                        intLocNum = intLocNum + 1
                    End If
                Else

                    ' In a blank file, we can simply add the record to location 1 with no other checks
                    intLocNum = 1

                    ' Enable print receipts button, since this will be disabled from no records being present
                    frmStuMan.butPrint.Enabled = True
                End If

                ' See if other records exist past this location, otherwise we can skip this
                If intLocNum <= intNumberOfStudents Then

                    ' If so, they must be moved up one place to make room
                    For i = intNumberOfStudents To intLocNum Step -1
                        FileGet(1, recStudentEntry, i)
                        FilePut(1, recStudentEntry, i + 1)
                    Next
                End If
            End If

            ' If resources have been changed, we must make changes to the file
            If blnResourcesChanged Then

                ' If we are changing an existing student, we must delete the old resources file
                FileClose(2)
                My.Computer.FileSystem.DeleteFile(strFolderLocation &
                                                  "Student Resources/" & strFileName & ".dat")

                ' Open a new resources file of the same name
                FileOpen(2, strFolderLocation & "Student Resources/" & strFileName & ".dat", OpenMode.Random, , , Len(New rtpStudentResource))

                ' Add resources to new file
                For i = 0 To recResources.Count - 1
                    FilePut(2, recResources(i), i + 1)
                Next
            End If

            ' Now (finally) write the student to the file
            FilePut(1, recNewEntry, intLocNum)

            ' If we are adding a student, increment the number of students
            If Not blnChange Then
                intNumberOfStudents = intNumberOfStudents + 1
            End If

            Me.Close()
        Else
            MessageBox.Show(strErrors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        ' Reset all colo[u]rs of input objects
        txtName.BackColor = System.Drawing.SystemColors.Window
        txtCostOwed.BackColor = System.Drawing.SystemColors.Window

        Me.Close()
    End Sub

    Private Sub dlgStuMan_InfoView_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Upon closing form, enable and clear elements
        txtName.ReadOnly = False
        cmbLevel.Enabled = True
        txtCostOwed.ReadOnly = False
        blpPaid_Yes.Enabled = True
        blpPaid_No.Enabled = True
        blpPrinted_Yes.Enabled = True
        blpPrinted_No.Enabled = True
        lstResources.SelectionMode = SelectionMode.One
        butClear_Res.Enabled = True
        butRemove_Res.Enabled = True
        butOK.Enabled = True
        txtName.Text = ""
        txtCostOwed.Text = ""
        lstResources.Items.Clear()

        ' Close student resources file
        FileClose(2)

        ' Reset Change, View Info and Resources Changed flags
        blnChange = False
        blnViewInfo = False
        blnResourcesChanged = False
    End Sub
End Class
