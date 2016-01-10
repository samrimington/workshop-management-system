' ╔════════════════════════════════════════════════════════════════╗
' ----Workshop Management System Project----------------------------
' ----Sam Rimington-------------------------------------------------
' ----A2 Computing--------------------------------------------------
' ----F454----------------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Resource Manager----------------------------------------------
' --The purpose of this form is to let the user track, add, change--
' --and remove resource stock in the workshop.----------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Date since last change: 04-12-2014----------------------------
' ╚════════════════════════════════════════════════════════════════╝

Imports WorMS.frmHomeScreen

Public Class frmResMan

    ' Declare variables, arrays and structures for use in this form
    Public intNumberOfResources As Integer
    Public blnQuit As Boolean
    Dim intStartCategoryIndex,
        intMaxCategoryIndex,
        intNumberOfStudents As Integer
    Dim sinOldQuantity As Single
    Dim strCategory(0) As String
    Dim blnEmptyIndex() As Boolean
    Dim recResource_Read As rtpResource


    Function StartCategoryIndex(ByVal Index)
        ' Make sure selected index points to values
        StartCategoryIndex = -1
        If Not blnEmptyIndex(Index) Then
            Dim i As Integer
            Dim blnIndexFound As Boolean
            Do
                i = i + 1
                FileGet(1, recResource_Read, i)
                If Trim(recResource_Read.strCategory) = strCategory(Index) Then
                    StartCategoryIndex = i
                    blnIndexFound = True
                End If
            Loop Until i = intNumberOfResources Or blnIndexFound
        End If
    End Function

    Sub subUpdateList(ByVal intCategoryIndex)
        ' Clear items in list box
        lstResourceList.Items.Clear()

        ' Make sure the index associated with the category selected has values on file
        If Not blnEmptyIndex(intCategoryIndex) Then

            ' Add a header to the list box first
            lstResourceList.Items.Add(String.Format("{0, -64}", "Resource") & "Amount")

            ' Add resources matching selected category to list box
            Dim blnIndexFound, blnIndexPassed As Boolean
            Dim i As Integer = 1
            Do
                FileGet(1, recResource_Read, i)
                If Trim(recResource_Read.strCategory) = cmbCategory.SelectedItem.ToString Then
                    lstResourceList.Items.Add(String.Format("{0, -64}", recResource_Read.strName) &
                                              recResource_Read.sinQuantity & " " & recResource_Read.strUnit)
                    blnIndexFound = True
                ElseIf blnIndexFound Then
                    blnIndexPassed = True
                End If
                i = i + 1
            Loop Until blnIndexPassed Or i = intNumberOfResources + 1
        Else

            ' Otherwise, add an item saying no resources of this category could be found
            lstResourceList.Items.Add("No resources of this category can be found")
        End If
    End Sub

    Sub subDisableAll()
        cmbCategory.Enabled = False
        butAdd_Cat.Enabled = False
        butRemove_Cat.Enabled = False
        txtName_Res.Enabled = False
        txtStockLeft_Res.Enabled = False
        txtMinStock_Res.Enabled = False
        txtUnit_Res.Enabled = False
        cmbStuResp_Res.Enabled = False
        butAdd_Res.Enabled = False
        butClear_Res.Enabled = False
        butRemove_Res.Enabled = False
        butViewLowStock.Enabled = False
    End Sub

    Sub subEnableAll()
        cmbCategory.Enabled = True
        butAdd_Cat.Enabled = True
        butRemove_Cat.Enabled = True
        txtName_Res.Enabled = True
        txtStockLeft_Res.Enabled = True
        txtMinStock_Res.Enabled = True
        txtUnit_Res.Enabled = True
        cmbStuResp_Res.Enabled = True
        butAdd_Res.Enabled = True
        butClear_Res.Enabled = True
        butRemove_Res.Enabled = True
        butViewLowStock.Enabled = True
    End Sub

    Sub subClearAll()
        ' Clear any input elements in the Select Category group box
        txtName_Res.Text = ""
        txtStockLeft_Res.Text = ""
        txtMinStock_Res.Text = ""
        txtUnit_Res.Text = ""

        subResetInputObjectColours()

        ' Make sure Student Responsible combo box has None selected
        cmbStuResp_Res.SelectedIndex = 0

        ' Clear list box selection
        lstResourceList.SelectedIndex = -1
    End Sub

    Sub subUpdateCategoryComboBox()
        ' Clear combo box and add new categories to it
        cmbCategory.Items.Clear()
        For i = 0 To intMaxCategoryIndex
            cmbCategory.Items.Add(strCategory(i))
        Next
    End Sub

    Sub subResetInputObjectColours()
        ' Reset all colo[u]rs of input objects
        txtName_Res.BackColor = System.Drawing.SystemColors.Window
        txtStockLeft_Res.BackColor = System.Drawing.SystemColors.Window
        txtMinStock_Res.BackColor = System.Drawing.SystemColors.Window
        txtUnit_Res.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub frmResMan_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Make sure Student Responsible combo box has None selected
        cmbStuResp_Res.SelectedIndex = 0

        ' Disable remove resource button
        butRemove_Res.Enabled = False

        ' Open files for use in this form and get number of resources
        FileOpen(1, strFolderLocation & "Resource_Stock.dat", OpenMode.Random, , , Len(New rtpResource))
        intNumberOfResources = FileLen(strFolderLocation & "Resource_Stock.dat") / Len(New rtpResource)

        If intNumberOfResources > 0 Then

            ' If records have been found, get the categories associated
            ' Find the categories to add to combo box
            FileGet(1, recResource_Read, 1)
            strCategory(0) = Trim(recResource_Read.strCategory)
            intMaxCategoryIndex = 0
            For i = 2 To intNumberOfResources
                FileGet(1, recResource_Read, i)
                Dim blnExists As Boolean = False
                For j = 0 To intMaxCategoryIndex
                    If Trim(recResource_Read.strCategory) = strCategory(j) Then
                        blnExists = True
                    End If
                Next
                If Not blnExists Then
                    ReDim Preserve strCategory(intMaxCategoryIndex + 1)
                    strCategory(intMaxCategoryIndex + 1) = Trim(recResource_Read.strCategory)
                    intMaxCategoryIndex = intMaxCategoryIndex + 1
                End If
            Next

            ReDim blnEmptyIndex(intMaxCategoryIndex)

            ' Add found categories to the categories combo box
            For i = 0 To intMaxCategoryIndex
                cmbCategory.Items.Add(strCategory(i))
            Next

            ' Select first category in combo box and update the resource list accordingly
            cmbCategory.SelectedIndex = 0
            subUpdateList(0)

            ' Update start category index variable
            intStartCategoryIndex = StartCategoryIndex(0)
        Else
            ' If no records can be found, add a list box item to inform the user of this
            lstResourceList.Items.Add("No resources can be found")

            intMaxCategoryIndex = -1

            ' Now disable all objects, apart from the add category button
            subDisableAll()
            butAdd_Cat.Enabled = True
        End If

        ' Update student responsible combo box
        ' Open student records file and find number of students
        FileOpen(2, strFolderLocation & "Students.dat", OpenMode.Random, , , Len(New rtpStudentEntry))
        intNumberOfStudents = FileLen(strFolderLocation & "Students.dat") / Len(New rtpStudentEntry)

        ' If students exist on file, add them to student combo box one by one
        If intNumberOfStudents > 0 Then

            Dim recStudentEntry As rtpStudentEntry
            recStudentEntry.strName = ""
            recStudentEntry.strLevel = ""

            Dim strName_Formatted As String

            For i = 1 To intNumberOfStudents
                FileGet(2, recStudentEntry, i)

                ' Format name correctly
                strName_Formatted = Trim(recStudentEntry.strName)
                If Len(strName_Formatted) > 29 Then
                    strName_Formatted = Mid(strName_Formatted, 1, 28) & "…"
                End If

                ' Add item
                cmbStuResp_Res.Items.Add(strName_Formatted & " (" & recStudentEntry.strLevel & ")")
            Next
        End If

        ' Disable student responsible combo box for now
        cmbStuResp_Res.Enabled = False
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

    Private Sub cmbCategory_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedValueChanged
        ' Rename add resource button back to Add
        butAdd_Res.Text = "Add"

        subClearAll()

        ' Update the list according to the new combo box index
        subUpdateList(cmbCategory.SelectedIndex)

        ' Update start category index variable
        intStartCategoryIndex = StartCategoryIndex(cmbCategory.SelectedIndex)
    End Sub

    Private Sub butAdd_Cat_Click(sender As Object, e As EventArgs) Handles butAdd_Cat.Click
        ' Input category to input box and validate
        Dim strNewCategory As String
        Dim blnInvalid As Boolean
        Do
            blnInvalid = False
            strNewCategory = InputBox("Enter new category")

            ' Check that input does not exceed character limit
            If Len(strNewCategory) > 15 Then
                MessageBox.Show("You have entered too many characters. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                blnInvalid = True
            Else

                ' Check that input is not the same as any existing category
                Dim i As Integer
                While i <= intMaxCategoryIndex
                    If strCategory(i) = strNewCategory Then
                        MessageBox.Show("This category already exists. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        blnInvalid = True
                    End If
                    i = i + 1
                End While
            End If
        Loop Until Not blnInvalid

        ' Check that input is not blank (generally means Cancel)
        ' Check if we have at least one category already
        If strNewCategory <> "" Then
            If intMaxCategoryIndex > -1 Then

                ' If so, we must add the category to the array, keeping it in alphabetical order
                Dim intNewCategoryIndex As Integer
                Dim intNewCategoryLen = Len(strNewCategory)
                Dim blnNewIndexFound As Boolean
                Do

                    ' Next item, find maximum number of characters to search up to
                    Dim intMaxLen As Integer = 0
                    Dim intCategoryLen = Len(strCategory(intNewCategoryIndex))
                    If intNewCategoryLen > intCategoryLen Then
                        intMaxLen = intCategoryLen + 1
                    Else
                        intMaxLen = intNewCategoryLen + 1
                    End If

                    ' Inspect each character to find index where new category should be placed
                    Dim intCharNum As Integer = 1
                    Dim blnAbort As Boolean = False
                    blnNewIndexFound = False
                    Do While intCharNum <= intMaxLen And Not blnAbort
                        Select Case Mid(strNewCategory, intCharNum, 1)
                            Case Is < Mid(strCategory(intNewCategoryIndex), intCharNum, 1)
                                blnAbort = True
                                blnNewIndexFound = True
                            Case Is > Mid(strCategory(intNewCategoryIndex), intCharNum, 1)
                                blnAbort = True
                            Case Else
                                intCharNum = intCharNum + 1
                        End Select
                    Loop
                    intNewCategoryIndex = intNewCategoryIndex + 1
                Loop Until blnNewIndexFound Or intNewCategoryIndex = intMaxCategoryIndex + 1
                If blnNewIndexFound Then

                    ' The location is within other values so the index must be changed
                    ' For any location which is beyond all other values, the index can remain
                    ' above by 1
                    intNewCategoryIndex = intNewCategoryIndex - 1
                End If

                ' See if other values are present past this index and move them one place up
                ' Otherwise, add to end of array
                ReDim Preserve strCategory(intMaxCategoryIndex + 1)

                If strCategory(intNewCategoryIndex) IsNot Nothing Then
                    For i = intMaxCategoryIndex To intNewCategoryIndex Step -1
                        strCategory(i + 1) = strCategory(i)
                    Next
                End If
                strCategory(intNewCategoryIndex) = strNewCategory

                ' The new category will have no values so we update the
                ' empty index boolean accordingly
                ReDim Preserve blnEmptyIndex(intMaxCategoryIndex + 1)
                For i = intMaxCategoryIndex To intNewCategoryIndex Step -1
                    blnEmptyIndex(i + 1) = blnEmptyIndex(i)
                Next
                blnEmptyIndex(intNewCategoryIndex) = True

                intMaxCategoryIndex = intMaxCategoryIndex + 1

                ' Update start category index variable
                intStartCategoryIndex = -1

                ' Enable all objects apart from student responsible combo box and remove resource button
                subEnableAll()
                cmbStuResp_Res.Enabled = False
                butRemove_Res.Enabled = False

                ' Update categories in combo box
                subUpdateCategoryComboBox()

                ' Select new category in combo box
                cmbCategory.SelectedIndex = intNewCategoryIndex
            Else
                ' If the array is empty, we can simply add the category in index 0
                ReDim strCategory(0)
                strCategory(0) = strNewCategory
                intMaxCategoryIndex = intMaxCategoryIndex + 1

                ' The new category will have no values so we update the
                ' empty index boolean accordingly
                ReDim blnEmptyIndex(0)
                blnEmptyIndex(0) = True

                ' Enable all objects apart from student responsible combo box and remove resource button
                subEnableAll()
                cmbStuResp_Res.Enabled = False
                butRemove_Res.Enabled = False

                ' Add single new category to combo box
                cmbCategory.Items.Add(strCategory(0))

                'Select new category in combo box
                cmbCategory.SelectedIndex = 0
            End If

            ' Bring focus to Name text box
            txtName_Res.Focus()
        End If
    End Sub

    Private Sub butRemove_Cat_Click(sender As Object, e As EventArgs) Handles butRemove_Cat.Click
        ' Make sure the user is sure about removing the category
        If MessageBox.Show("Are you sure you want to remove the selected category (and its contents)?",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            ' Assign value of category combo box to variable
            Dim strCategoryToRemove As String = cmbCategory.SelectedItem.ToString()

            ' Now check that the index has values
            ' If it does not, we do not need to bother looking for its records on file
            Dim intIndexToClear As Integer = cmbCategory.SelectedIndex
            If Not blnEmptyIndex(intIndexToClear) Then

                ' First, find all items with category different of that to category to remove
                ' and move to new, temporary file
                FileOpen(3, strFolderLocation & "Resource_Stock_temp.dat", OpenMode.Random, , , Len(New rtpResource))
                Dim intNewNumOfRecs As Integer = 1
                For i = 1 To intNumberOfResources
                    FileGet(1, recResource_Read, i)
                    If Trim(recResource_Read.strCategory) <> strCategoryToRemove Then
                        FilePut(3, recResource_Read, intNewNumOfRecs)
                        intNewNumOfRecs = intNewNumOfRecs + 1
                    End If
                Next
                intNewNumOfRecs = intNewNumOfRecs - 1
                FileClose(1, 3)

                ' Delete the old file and rename temporary file so it can be used
                My.Computer.FileSystem.DeleteFile(strFolderLocation & "Resource_Stock.dat")
                My.Computer.FileSystem.RenameFile(strFolderLocation & "Resource_Stock_temp.dat", "Resource_Stock.dat")

                ' Open the new file
                FileOpen(1, strFolderLocation & "Resource_Stock.dat", OpenMode.Random, , , Len(New rtpResource))

                ' Update number of records
                intNumberOfResources = intNewNumOfRecs
            End If

            ' Check that there is more than one category in category array
            If intMaxCategoryIndex <> 0 Then

                ' Check if there are categories past the category index to be cleared
                If intIndexToClear < intMaxCategoryIndex + 1 Then

                    ' Update category array
                    intMaxCategoryIndex = intMaxCategoryIndex - 1

                    For i = intIndexToClear + 1 To intMaxCategoryIndex + 1
                        strCategory(i - 1) = strCategory(i)
                    Next
                    ReDim Preserve strCategory(intMaxCategoryIndex)

                    ' Update empty index boolean array
                    For i = intIndexToClear + 1 To intMaxCategoryIndex + 1
                        blnEmptyIndex(i - 1) = blnEmptyIndex(i)
                    Next
                    ReDim Preserve blnEmptyIndex(intMaxCategoryIndex)
                End If

                ' Update categories in combo box
                subUpdateCategoryComboBox()

                ' Select first category in combo box
                cmbCategory.SelectedIndex = 0
            Else

                'Otherwise, clear category array and all inputs
                ReDim strCategory(0)
                subClearAll()
                cmbCategory.Items.Clear()
                lstResourceList.Items.Clear()

                intStartCategoryIndex = -1
                intMaxCategoryIndex = -1
                ReDim blnEmptyIndex(0)

                ' Update number of records
                intNumberOfResources = 0

                ' Add a list box item to inform the user that no resources can be found
                lstResourceList.Items.Add("No resources can be found")

                ' Now disable all objects, apart from the add category button
                subDisableAll()
                butAdd_Cat.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtName_Res_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtName_Res.KeyPress
        ' Upon typing into the resource name text box, rename add resource button back to Add
        butAdd_Res.Text = "Add"

        ' Unselect combo box selection
        lstResourceList.SelectedIndex = -1

        ' Disable student responsible combo box and remove resource button
        cmbStuResp_Res.Enabled = False
        butRemove_Res.Enabled = False
    End Sub

    Private Sub butAdd_Res_Click(sender As Object, e As EventArgs) Handles butAdd_Res.Click
        ' Let's validate the data input first
        Dim strErrors As String = ""

        subResetInputObjectColours()

        ' Starting with name text box input, check it is not blank
        If txtName_Res.Text = "" Then
            strErrors = "The resource name cannot be blank." & vbCrLf
            txtName_Res.BackColor = Color.Tomato
        End If

        ' Now check that the stock left text box input is not blank
        If txtStockLeft_Res.Text = "" Then
            strErrors = strErrors & "The stock left cannot be blank." & vbCrLf
            txtStockLeft_Res.BackColor = Color.Tomato

            ' If so, check that input is numeric and then check that it is a positive number
        ElseIf Not IsNumeric(txtStockLeft_Res.Text) Then
            strErrors = strErrors & "The stock left must be a number." & vbCrLf
            txtStockLeft_Res.BackColor = Color.Tomato
        ElseIf txtStockLeft_Res.Text < 0 Then
            strErrors = strErrors & "The stock left must be more than or equal to 0." & vbCrLf
            txtStockLeft_Res.BackColor = Color.Tomato
        End If

        ' Check that the minimum stock text box input is not blank
        If txtMinStock_Res.Text = "" Then
            strErrors = strErrors & "The minimum stock cannot be blank." & vbCrLf
            txtMinStock_Res.BackColor = Color.Tomato

            ' If so, check that input is numeric and then check that it is a positive number
        ElseIf Not IsNumeric(txtMinStock_Res.Text) Then
            strErrors = strErrors & "The minimum stock must be a number." & vbCrLf
            txtMinStock_Res.BackColor = Color.Tomato
        ElseIf txtMinStock_Res.Text < 0 Then
            strErrors = strErrors & "The minimum stock must be more than or equal to 0." & vbCrLf
            txtMinStock_Res.BackColor = Color.Tomato
        End If

        ' Now check that the unit text box input is not blank
        If txtUnit_Res.Text = "" Then
            strErrors = strErrors & "The resource units cannot be blank." & vbCrLf
            txtUnit_Res.BackColor = Color.Tomato
        End If

        ' Check that, if a student responsible has been selected, the new quantity is lower than the old quantity
        If cmbStuResp_Res.SelectedIndex > 0 Then
            If txtStockLeft_Res.Text >= sinOldQuantity Then
                strErrors = strErrors &
                    "When a student responsible is selected, the new resource stock must be lower than the old resource stock." & vbCrLf
                txtStockLeft_Res.BackColor = Color.Tomato
            End If
        End If

        ' Also make that we are not changing a record
        If strErrors = "" And butAdd_Res.Text = "Add" Then

            ' Now that we know input is valid, create a new resource structure
            ' and assign text inputs to new structure
            Dim recNewResource As rtpResource
            recNewResource.strCategory = cmbCategory.SelectedItem.ToString
            recNewResource.strName = txtName_Res.Text
            recNewResource.sinQuantity = txtStockLeft_Res.Text
            recNewResource.sinMinQuantity = txtMinStock_Res.Text
            recNewResource.strUnit = txtUnit_Res.Text

            ' Now find where to put the new resource on file
            ' First, check if there are records already present and instance of category already exists
            If intNumberOfResources > 0 And Not blnEmptyIndex(cmbCategory.SelectedIndex) Then

                ' If an instance of the category can be found on file,
                ' Find the end location using the start location
                Dim intCategoryEnd As Integer
                Dim i As Integer = intStartCategoryIndex
                If intStartCategoryIndex > 0 And i <= intNumberOfResources Then
                    Do While i <= intNumberOfResources And intCategoryEnd = 0
                        FileGet(1, recResource_Read, i)
                        If Trim(recResource_Read.strCategory) <> strCategory(cmbCategory.SelectedIndex) Then
                            intCategoryEnd = i - 1
                        End If
                        i = i + 1
                    Loop

                    ' If we could not find the end of category (reached number of records), category end must be at EOF
                    If i = intNumberOfResources + 1 And intCategoryEnd = 0 Then
                        intCategoryEnd = i - 1
                    End If

                    ' Now we can start checking the cluster to see where the resource must go
                    Dim intLocNum As Integer = intStartCategoryIndex - 1
                    Dim intNewNameLen As Integer = Len(recNewResource.strName)
                    Dim blnLocFound As Boolean
                    Do
                        intLocNum = intLocNum + 1
                        FileGet(1, recResource_Read, intLocNum)

                        ' Next item, find maximum number of characters to search to
                        Dim intMaxLen As Integer
                        Dim intNameLen As Integer = Len(recResource_Read.strName)
                        If intNewNameLen > intNameLen Then
                            intMaxLen = intNameLen + 1
                        Else
                            intMaxLen = intNewNameLen + 1
                        End If

                        ' Inspect each character to see where new resource should be placed
                        Dim intCharNum As Integer = 1
                        Dim blnAbort As Boolean = False
                        Do While intCharNum <= intMaxLen And Not blnAbort
                            Select Case Mid(recNewResource.strName, intCharNum, 1)
                                Case Is < Mid(recResource_Read.strName, intCharNum, 1)
                                    blnAbort = True
                                    blnLocFound = True
                                Case Is > Mid(recResource_Read.strName, intCharNum, 1)
                                    blnAbort = True
                                Case Else
                                    intCharNum = intCharNum + 1
                            End Select
                        Loop
                    Loop Until blnLocFound Or intLocNum = intCategoryEnd
                    If Not blnLocFound And intLocNum = intCategoryEnd Then
                        intLocNum = intLocNum + 1
                    End If

                    ' See if other records exist past this location, otherwise we can skip this
                    If intLocNum <= intNumberOfResources Then

                        ' If so, they must be moved up one place to make room
                        For i = intNumberOfResources To intLocNum Step -1
                            FileGet(1, recResource_Read, i)
                            FilePut(1, recResource_Read, i + 1)
                        Next
                    End If

                    ' Now (finally) write the new resource to the file
                    FilePut(1, recNewResource, intLocNum)
                Else

                    ' If we've reached the EOF, add new resource onto the EOF
                    FilePut(1, recNewResource, intNumberOfResources + 1)
                End If

            ElseIf intNumberOfResources > 0 And blnEmptyIndex(cmbCategory.SelectedIndex) Then

                ' If no previous instances of the category exists on file
                ' We must find a location for the new record where the categories remain in alphabetic order
                Dim intLocNum As Integer
                Dim intNewCatLen As Integer = Len(recNewResource.strCategory)
                Dim blnLocFound As Boolean
                Do
                    intLocNum = intLocNum + 1
                    FileGet(1, recResource_Read, intLocNum)

                    ' Next item, find maximum number of characters to search to
                    Dim intMaxLen As Integer
                    Dim intCatLen As Integer = Len(recResource_Read.strCategory)
                    If intNewCatLen > intCatLen Then
                        intMaxLen = intCatLen + 1
                    Else
                        intMaxLen = intNewCatLen + 1
                    End If

                    ' Inspect each character to see where new category cluster should be placed
                    Dim intCharNum As Integer = 1
                    Dim blnAbort As Boolean = False
                    Do While intCharNum <= intMaxLen And Not blnAbort
                        Select Case Mid(recNewResource.strCategory, intCharNum, 1)
                            Case Is < Mid(recResource_Read.strCategory, intCharNum, 1)
                                blnAbort = True
                                blnLocFound = True
                            Case Is > Mid(recResource_Read.strCategory, intCharNum, 1)
                                blnAbort = True
                            Case Else
                                intCharNum = intCharNum + 1
                        End Select
                    Loop
                Loop Until blnLocFound Or intLocNum = intNumberOfResources
                If Not blnLocFound And intLocNum = intNumberOfResources Then
                    intLocNum = intLocNum + 1
                End If

                ' See if other records exist past this location
                If intLocNum <= intNumberOfResources Then

                    ' If so, they must be moved up one place to make room
                    For i = intNumberOfResources To intLocNum Step -1
                        FileGet(1, recResource_Read, i)
                        FilePut(1, recResource_Read, i + 1)
                    Next
                End If

                ' Now (finally) write the new resource to the file
                FilePut(1, recNewResource, intLocNum)
            Else

                ' If the file is blank we can simply add the new resource with no checks
                FilePut(1, recNewResource, 1)
            End If

            ' Increment number of resources
            intNumberOfResources = intNumberOfResources + 1

            ' Since index now points to values, update empty index boolean
            blnEmptyIndex(cmbCategory.SelectedIndex) = False

            ' Update start category index
            intStartCategoryIndex = StartCategoryIndex(cmbCategory.SelectedIndex)

            ' Enable and clear all elements
            subEnableAll()
            subClearAll()

            ' Disable student responsible combo box and remove resource button
            cmbStuResp_Res.Enabled = False
            butRemove_Res.Enabled = False

            ' Update the list box
            subUpdateList(cmbCategory.SelectedIndex)
        ElseIf strErrors = "" Then

            ' We must need to append this record since Append Boolean is true
            ' Assign text inputs to new structure
            Dim recNewResource As rtpResource
            recNewResource.strCategory = cmbCategory.SelectedItem.ToString
            recNewResource.strName = txtName_Res.Text
            recNewResource.sinQuantity = txtStockLeft_Res.Text
            recNewResource.sinMinQuantity = txtMinStock_Res.Text
            recNewResource.strUnit = txtUnit_Res.Text

            ' Add resource change to student responsible (if one is selected)
            If cmbStuResp_Res.SelectedIndex > 0 Then

                Dim recNewStudentEntry As rtpStudentEntry
                recNewStudentEntry.strName = ""
                recNewStudentEntry.strLevel = ""

                FileGet(2, recNewStudentEntry, cmbStuResp_Res.SelectedIndex)

                ' Update number of student resources
                recNewStudentEntry.bytNumberOfResources = recNewStudentEntry.bytNumberOfResources + 1
                FilePut(2, recNewStudentEntry, cmbStuResp_Res.SelectedIndex)

                ' Generate a filename
                Dim strFileName As String = Replace(Trim(recNewStudentEntry.strName), " ", "_") & ".dat"

                ' Assign resource data to student resource record, formatting name as appropriate
                Dim recNewStuRes As rtpStudentResource
                recNewStuRes.strName = txtName_Res.Text
                If Len(Trim(recNewStuRes.strName)) > 31 Then
                    recNewStuRes.strName = Mid(Trim(recNewStuRes.strName), 1, 30) & "…"
                End If

                ' Round quantity to prevent floating point errors
                recNewStuRes.sinQuantity = Math.Round(sinOldQuantity - recNewResource.sinQuantity, 2)
                recNewStuRes.strUnit = txtUnit_Res.Text

                ' Write resource to next available location in student resources file
                FileOpen(3, strFolderLocation & "Student Resources/" & strFileName, OpenMode.Random, , , Len(New rtpStudentResource))
                FilePut(3, recNewStuRes, recNewStudentEntry.bytNumberOfResources)
                FileClose(3)
            End If

            ' Use start location of category cluster and the index
            ' provided by the list box selection to overwrite the record on file
            FilePut(1, recNewResource, intStartCategoryIndex + lstResourceList.SelectedIndex - 1)

            ' Enable and clear all elements
            subEnableAll()
            subClearAll()

            ' Disable remove resource button and student combo box
            butRemove_Res.Enabled = False
            cmbStuResp_Res.Enabled = False

            ' Update the list box
            subUpdateList(cmbCategory.SelectedIndex)
        Else
            MessageBox.Show(strErrors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' Bring focus to Name text box
        txtName_Res.Focus()
    End Sub

    Private Sub butClear_Res_Click(sender As Object, e As EventArgs) Handles butClear_Res.Click
        subClearAll()
    End Sub

    Private Sub butRemove_Res_Click(sender As Object, e As EventArgs) Handles butRemove_Res.Click
        ' Now make sure user is sure about removing resource
        If MessageBox.Show("Are you sure you want to remove the selected resource?",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            ' Assign value of selected resource index to variable
            Dim intResIndexToRemove As Integer = lstResourceList.SelectedIndex - 1

            ' Refer to the index to remove and copy all items to temporary file that are not related to it
            FileOpen(3, strFolderLocation & "Resource_Stock_temp.dat", OpenMode.Random, , , Len(New rtpResource))
            For i = 1 To intStartCategoryIndex + intResIndexToRemove - 1
                FileGet(1, recResource_Read, i)
                FilePut(3, recResource_Read, i)
            Next
            For i = intStartCategoryIndex + intResIndexToRemove + 1 To intNumberOfResources
                FileGet(1, recResource_Read, i)
                FilePut(3, recResource_Read, i - 1)
            Next
            FileClose(1, 3)

            ' Delete the old file and rename temporary file so it can be used
            My.Computer.FileSystem.DeleteFile(strFolderLocation & "Resource_Stock.dat")
            My.Computer.FileSystem.RenameFile(strFolderLocation & "Resource_Stock_temp.dat", "Resource_Stock.dat")

            ' Update number of records
            intNumberOfResources = intNumberOfResources - 1

            ' Open the new file
            FileOpen(1, strFolderLocation & "Resource_Stock.dat", OpenMode.Random, , , Len(New rtpResource))

            ' Check that an instance of the category still exists on file
            ' So we know if we need to update the list box or combo box
            Dim blnCategoryFound As Boolean
            For i = 1 To intNumberOfResources
                FileGet(1, recResource_Read, i)
                If Trim(recResource_Read.strCategory) = strCategory(cmbCategory.SelectedIndex) Then
                    blnCategoryFound = True
                End If
            Next

            ' Rename Add Resource button to Add
            butAdd_Res.Text = "Add"

            If blnCategoryFound Then

                ' If instances of the category still exist, keep the combo box the same
                ' Update the list with the same index
                subUpdateList(cmbCategory.SelectedIndex)

                ' Update start location of category cluster
                intStartCategoryIndex = StartCategoryIndex(cmbCategory.SelectedIndex)

                'Clear all inputs
                subClearAll()
            Else

                ' Update start location of category cluster
                intStartCategoryIndex = -1

                ' Otherwise, clear all inputs
                subClearAll()
                lstResourceList.Items.Clear()

                ' Add an item saying no resources of this category could be found
                lstResourceList.Items.Add("No resources of this category can be found")

                ' Update empty index array for this index
                blnEmptyIndex(cmbCategory.SelectedIndex) = True

                ' Enable all objects
                subEnableAll()
            End If

            ' Disable student responsible combo box and remove resource button
            cmbStuResp_Res.Enabled = False
            butRemove_Res.Enabled = False

            ' Bring focus to Name text box
            txtName_Res.Focus()
        End If
    End Sub

    Private Sub lstResourceList_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstResourceList.SelectedValueChanged
        subResetInputObjectColours()

        ' Check that header has not been selected
        If lstResourceList.SelectedIndex > 0 Then

            ' Update start category index variable
            intStartCategoryIndex = StartCategoryIndex(cmbCategory.SelectedIndex)

            ' Read record index from file
            FileGet(1, recResource_Read, intStartCategoryIndex + lstResourceList.SelectedIndex - 1)

            ' Assign data to text boxes, ensuring all strings are trimmed
            txtName_Res.Text = Trim(recResource_Read.strName)
            txtStockLeft_Res.Text = recResource_Read.sinQuantity
            txtMinStock_Res.Text = recResource_Read.sinMinQuantity
            txtUnit_Res.Text = Trim(recResource_Read.strUnit)

            sinOldQuantity = recResource_Read.sinQuantity

            ' Rename Add Resource button to Change
            butAdd_Res.Text = "Change"

            ' Enable remove resource button and student responsible combo box
            butRemove_Res.Enabled = True
            cmbStuResp_Res.Enabled = True
        Else

            ' Otherwise, make sure Add resource button has correct name
            butAdd_Res.Text = "Add"

            sinOldQuantity = 0

            ' Disable remove resource button and student responsible combo box
            butRemove_Res.Enabled = False
            cmbStuResp_Res.Enabled = False

            ' Clear list box selection
            lstResourceList.SelectedIndex = -1
        End If
    End Sub

    Private Sub butViewLowStock_Click(sender As Object, e As EventArgs) Handles butViewLowStock.Click
        ' Upon clicking the View Low Stock button, show the Low Stock Viewer as a dialog
        dlgResMan_LowStockView.ShowDialog()
    End Sub

    Private Sub frmResMan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If Not blnQuit Then
            ' Upon closing this form, show the home screen
            frmHomeScreen.Show()
        Else
            blnQuit = False
        End If

        ' Close all files
        FileClose()
    End Sub
End Class