' ╔════════════════════════════════════════════════════════════════╗
' ----Workshop Management System Project----------------------------
' ----Sam Rimington-------------------------------------------------
' ----A2 Computing--------------------------------------------------
' ----F454----------------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Student Manager-----------------------------------------------
' --The purpose of this form is to let the user manage student------
' --records and the resources they have used. Receipts can also be--
' --printed for students who have paid what they owe in the costs---
' --of using resources.---------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Date since last change: 04-12-2014----------------------------
' ╚════════════════════════════════════════════════════════════════╝

Imports WorMS.frmHomeScreen

Public Class frmStuMan
    ' Declare variables, arrays and structures for use in this form
    Public intNumberOfStudents, intCurrentRecordNum, intNumberOfPages As Integer
    Dim recStudentEntry_Read As rtpStudentEntry
    Dim strListFormat As String = "{0, -32}{1, -6}{2, -11}{3, -6}{4, -14}"

    Sub subUpdateStuList()
        ' Clear students list
        lstStudents.Items.Clear()

        If intNumberOfStudents > 0 Then
            ' If students can be found, add header to list
            lstStudents.Items.Add(String.Format(strListFormat, "Name", "Level", "Cost Owed",
                                                "Paid?", "Rcpt. Printed?"))

            ' Read and add each student onto list
            For i = 1 To intNumberOfStudents
                FileGet(1, recStudentEntry_Read, i)

                ' Format student name correctly
                Dim strName_Formatted As String = Trim(recStudentEntry_Read.strName)
                If Len(strName_Formatted) > 31 Then
                    strName_Formatted = Mid(strName_Formatted, 1, 30) & "…"
                End If

                ' Format paid and cheque printed boolean values to show either Yes or No
                Dim strPaid_Formatted As String = "No"
                If recStudentEntry_Read.blnPaid Then
                    strPaid_Formatted = "Yes"
                End If

                Dim strReciPrinted_Formatted As String = "No"
                If recStudentEntry_Read.blnReceiptPrinted Then
                    strReciPrinted_Formatted = "Yes"
                End If

                ' Add students to list
                lstStudents.Items.Add(String.Format(strListFormat, strName_Formatted, recStudentEntry_Read.strLevel,
                                                    FormatCurrency(recStudentEntry_Read.sinCostOwed), strPaid_Formatted,
                                                    strReciPrinted_Formatted))
            Next
        Else
            ' If students cannot be found, simply state this in a list box item
            lstStudents.Items.Add("No students can be found")
        End If

        lstStudents.SelectedIndex = -1
        butAdd.Text = "Add Student"
        butViewInfo.Enabled = False
        butPrint.Enabled = False
        butRemove.Enabled = False
    End Sub

    Private Sub frmStuMan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Open students file and find number of records
        FileOpen(1, strFolderLocation & "Students.dat", OpenMode.Random, , , Len(New rtpStudentEntry))
        intNumberOfStudents = FileLen(strFolderLocation & "Students.dat") / Len(New rtpStudentEntry)

        subUpdateStuList()
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

    Private Sub lstStudents_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstStudents.SelectedValueChanged
        ' Check that actual item, apart from header, is selected
        If lstStudents.SelectedIndex > 0 Then
            If lstStudents.SelectedIndices.Count > 1 Then
                butAdd.Text = "Add Student"
                butViewInfo.Enabled = False
                butPrint.Enabled = True
                butRemove.Enabled = False
            Else
                butAdd.Text = "Change Student"
                butViewInfo.Enabled = True
                butPrint.Enabled = True
                butRemove.Enabled = True
            End If
        Else
            lstStudents.SelectedIndex = -1
            butAdd.Text = "Add Student"
            butViewInfo.Enabled = False
            butPrint.Enabled = False
            butRemove.Enabled = False
        End If
    End Sub

    Private Sub butAdd_Click(sender As Object, e As EventArgs) Handles butAdd.Click
        If butAdd.Text = "Change Student" Then
            dlgStuMan_InfoView.blnChange = True
            dlgStuMan_InfoView.intLocNum = lstStudents.SelectedIndex
        End If

        dlgStuMan_InfoView.ShowDialog()

        intNumberOfStudents = dlgStuMan_InfoView.intNumberOfStudents
        subUpdateStuList()
    End Sub

    Private Sub butViewInfo_Click(sender As Object, e As EventArgs) Handles butViewInfo.Click
        dlgStuMan_InfoView.blnViewInfo = True
        dlgStuMan_InfoView.intLocNum = lstStudents.SelectedIndex

        dlgStuMan_InfoView.ShowDialog()
    End Sub

    Private Sub butRemove_Click(sender As Object, e As EventArgs) Handles butRemove.Click
        ' Make sure user is sure about removing student
        If MessageBox.Show("Are you sure you want to remove the selected student?",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            ' Remove resources file associated with student
            FileGet(1, recStudentEntry_Read, lstStudents.SelectedIndex)
            Dim strFilePath As String = strFolderLocation & "Student Resources/" & Replace(Trim(recStudentEntry_Read.strName), " ", "_") & ".dat"
            If My.Computer.FileSystem.FileExists(strFilePath) Then
                My.Computer.FileSystem.DeleteFile(strFilePath)
            End If

            ' Create temporary file and move all students other than selected student to it
            FileOpen(2, strFolderLocation & "Students_temp.dat", OpenMode.Random, , , Len(New rtpStudentEntry))
            For i = 1 To lstStudents.SelectedIndex - 1
                FileGet(1, recStudentEntry_Read, i)
                FilePut(2, recStudentEntry_Read, i)
            Next
            For i = lstStudents.SelectedIndex + 1 To intNumberOfStudents
                FileGet(1, recStudentEntry_Read, i)
                FilePut(2, recStudentEntry_Read, i - 1)
            Next
            FileClose(1, 2)

            ' Delete the old file and rename temporary file so it can be used
            My.Computer.FileSystem.DeleteFile(strFolderLocation & "Students.dat")
            My.Computer.FileSystem.RenameFile(strFolderLocation & "Students_temp.dat", "Students.dat")

            ' Amend number of students
            intNumberOfStudents = intNumberOfStudents - 1

            ' Open the new file
            FileOpen(1, strFolderLocation & "Students.dat", OpenMode.Random, , , Len(New rtpStudentEntry))

            subUpdateStuList()
        End If
    End Sub

    Private Sub butPrint_Click(sender As Object, e As EventArgs) Handles butPrint.Click
        ' First verify that none of the students have not paid or have had
        ' a receipt already printed
        Dim i As Integer = -1
        Do
            i = i + 1
            FileGet(1, recStudentEntry_Read, lstStudents.SelectedIndices(i))
        Loop Until i = lstStudents.SelectedIndices.Count - 1 Or Not recStudentEntry_Read.blnPaid Or recStudentEntry_Read.blnReceiptPrinted
        Dim blnProceed As Boolean
        If Not recStudentEntry_Read.blnPaid Then

            ' Notify user a student has not paid
            If MessageBox.Show("One of the students you selected has not yet paid. Do you wish to continue printing receipts for these students?",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                blnProceed = True
            End If
        ElseIf recStudentEntry_Read.blnReceiptPrinted Then

            ' Notify user a student has already had their receipt printed
            If MessageBox.Show("One of the students you selected has already had their receipt printed. Do you wish to continue printing receipts for these students?",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                blnProceed = True
            End If
        Else
            blnProceed = True
        End If
        If blnProceed Then

            ' If we are proceeding, amend the receipt printed boolean for each student
            For i = 0 To lstStudents.SelectedIndices.Count - 1
                FileGet(1, recStudentEntry_Read, lstStudents.SelectedIndices(i))
                recStudentEntry_Read.blnReceiptPrinted = True
                FilePut(1, recStudentEntry_Read, lstStudents.SelectedIndices(i))
            Next

            ' Reset record number variable, number of pages and print preview opened boolean
            intCurrentRecordNum = 0
            intNumberOfPages = 0
            blnPrintPreviewOpened = False

            frmHomeScreen.ppdPrintPreview.Document = pntReceipts
            frmHomeScreen.ppdPrintPreview.Width = 800
            frmHomeScreen.ppdPrintPreview.Height = 600
            frmHomeScreen.ppdPrintPreview.ShowDialog()

            subUpdateStuList()
        End If
    End Sub

    Private Sub pntReceipts_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pntReceipts.PrintPage
        ' Declaring variables
        Dim fntTitle As New Font("Courier New", 15, FontStyle.Underline Or FontStyle.Bold)
        Dim fntEntry As New Font("Courier New", 9, FontStyle.Regular)
        Const strEntryFormat As String = "{0, -15}{1, -30}"
        Dim strCurrentDate As String = FormatDateTime(Now, DateFormat.ShortDate)
        Dim x, y, intNumberOfPrintedReceipts As Integer
        Dim y_assign As Integer = -70

        intNumberOfPages = intNumberOfPages + 1
        e.HasMorePages = False

        ' Print receipts
        ' Base format on whether list box selection number
        ' from selected items list is odd or even
        For i = intCurrentRecordNum To lstStudents.SelectedIndices.Count - 1

            If (i + 1) Mod 2 <> 0 Then

                ' Odd number, print receipt to left of page
                x = 50

                ' Since this is an odd number receipt, we must amend the assigned location of y also
                y_assign = y_assign + 120
            Else
                ' Even number, print receipt to right of page
                x = 420
            End If

            y = y_assign

            ' Print title
            e.Graphics.DrawString("Receipt", fntTitle, Brushes.Black, x, y)

            ' Seperate title from content
            y = y + 2 * fntEntry.Height

            ' Print receipt number entry
            e.Graphics.DrawString(String.Format(strEntryFormat, "No.", New String(".", 30)),
                                  fntEntry, Brushes.Black, x, y)
            y = y + fntEntry.Height

            ' Print date entry
            e.Graphics.DrawString(String.Format(strEntryFormat, "Date", strCurrentDate),
                                  fntEntry, Brushes.Black, x, y)
            y = y + fntEntry.Height

            ' From here, we will need to get data from file relating to the student selected
            FileGet(1, recStudentEntry_Read, lstStudents.SelectedIndices(i))

            ' Format name as appropriate
            Dim strName_Formatted As String = Trim(recStudentEntry_Read.strName)
            If Len(strName_Formatted) > 30 Then
                strName_Formatted = Mid(strName_Formatted, 1, 29) & "…"
            End If

            ' Print name entry
            e.Graphics.DrawString(String.Format(strEntryFormat, "Received from", strName_Formatted),
                                  fntEntry, Brushes.Black, x, y)
            y = y + fntEntry.Height

            ' Print cost owed (paid) entry
            e.Graphics.DrawString(String.Format(strEntryFormat, "The sum of", FormatCurrency(recStudentEntry_Read.sinCostOwed)),
                                  fntEntry, Brushes.Black, x, y)
            y = y + fntEntry.Height

            ' Print signature entry
            e.Graphics.DrawString(String.Format(strEntryFormat, "Signature", New String(".", 30)),
                                  fntEntry, Brushes.Black, x, y)

            intNumberOfPrintedReceipts = intNumberOfPrintedReceipts + 1

            ' Check if the page is full and if we need to starting writing on a new page
            If intNumberOfPrintedReceipts = 16 Then
                intCurrentRecordNum = i + 1
                e.HasMorePages = True
                Exit For
            End If
        Next

        ' Print page number
        e.Graphics.DrawString(intNumberOfPages, fntEntry, Brushes.Black, 420, 1050)
    End Sub

    Private Sub pntReceipts_EndPrint(sender As Object, e As Printing.PrintEventArgs) Handles pntReceipts.EndPrint
        subInformMultiplePages(intNumberOfPages)
    End Sub

    Private Sub frmStuMan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Upon closing this form, close all files and show the home screen
        FileClose()
        frmHomeScreen.Show()
    End Sub
End Class