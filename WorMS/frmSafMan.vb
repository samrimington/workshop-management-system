' ╔════════════════════════════════════════════════════════════════╗
' ----Workshop Management System Project----------------------------
' ----Sam Rimington-------------------------------------------------
' ----A2 Computing--------------------------------------------------
' ----F454----------------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Machine Test Records Manager----------------------------------
' --The purpose of this form is to let the user add and manage------
' --records for weekly machinery safety testing, as well as to------
' --print blank record sheets for writing records onto paper for----
' --typing up later.------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Date since last change: 04-12-2014----------------------------
' ╚════════════════════════════════════════════════════════════════╝

Imports WorMS.frmHomeScreen

Public Class frmSafMan
    ' Declare variables and structures for use in this form
    Dim intNumberOfRecords, intCurrentRecordNum, intNumberOfPages As Integer
    Dim recSafetyRecord_Read As rtpSafetyRecord

    Sub subUpdateList()
        ' Clear list
        lstRecords.Items.Clear()

        ' Read and display each record on file
        For i = 1 To intNumberOfRecords
            FileGet(1, recSafetyRecord_Read, i)
            lstRecords.Items.Add(FormatDateTime(recSafetyRecord_Read.dteDateOfCheck, DateFormat.ShortDate))
        Next

        ' Disable Remove button and Print Selected button
        butRemove.Enabled = False
        butPrintRecs.Enabled = False
    End Sub

    Private Sub frmSafMan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set maximum allowable date in date-time picker
        dtpDateOfCheck.MaxDate = Today()

        ' Open files for use in form and get number of records
        FileOpen(1, strFolderLocation & "Machine_Testing_Records.dat", OpenMode.Random, , , Len(New rtpSafetyRecord))
        intNumberOfRecords = FileLen(strFolderLocation & "Machine_Testing_Records.dat") / Len(New rtpSafetyRecord)

        subUpdateList()

        If intNumberOfRecords = 0 Then

            ' If no records can be found on file, display a message box to inform the user of this
            MessageBox.Show("No machine testing records could be found. A new file will be generated in the selected folder when a new resource is added.",
                            "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub butAdd_Click(sender As Object, e As EventArgs) Handles butAdd.Click
        ' Verify data input
        Dim strErrors As String = ""

        ' Reset the colo[u]r of the comments text box
        txtComments.BackColor = System.Drawing.SystemColors.Window

        ' Check that the comments text box input is not blank
        If txtComments.Text = "" Then
            strErrors = "The safety testing record comments cannot be blank." & vbCrLf
            txtComments.BackColor = Color.Tomato

            ' If it is not blank, check that comments text box does not have any carriage returns
        ElseIf InStr(txtComments.Text, vbCrLf) > 0 Then
            strErrors = "The safety testing record comments must be on a single line." & vbCrLf
            txtComments.BackColor = Color.Tomato
        End If

        If strErrors = "" Then

            ' Assign input to new record structure
            Dim recNewSafetyRecord As rtpSafetyRecord
            recNewSafetyRecord.strComments = txtComments.Text
            recNewSafetyRecord.dteDateOfCheck = dtpDateOfCheck.Value

            ' Check records file is not blank
            Dim srtLocNum As UShort
            If intNumberOfRecords > 0 Then

                ' Find where to put new record on file so records remain in order of date
                Dim blnLocFound As Boolean
                Do
                    srtLocNum = srtLocNum + 1
                    FileGet(1, recSafetyRecord_Read, srtLocNum)
                    If DateTime.Compare(recNewSafetyRecord.dteDateOfCheck, recSafetyRecord_Read.dteDateOfCheck) >= 0 Then
                        blnLocFound = True
                    End If
                Loop Until blnLocFound Or srtLocNum = intNumberOfRecords
                If srtLocNum = intNumberOfRecords And Not blnLocFound Then
                    srtLocNum = srtLocNum + 1
                End If

                ' See if other records exist past this location
                If srtLocNum <= intNumberOfRecords Then

                    ' If so, they must be moved up one place to make room
                    For i = intNumberOfRecords To srtLocNum Step -1
                        FileGet(1, recSafetyRecord_Read, i)
                        FilePut(1, recSafetyRecord_Read, i + 1)
                    Next
                End If
            Else

                ' If no records can be found, the new record can simply be added to line 1 without any checks
                srtLocNum = 1
            End If

            ' Now write record to file in location found
            FilePut(1, recNewSafetyRecord, srtLocNum)

            ' Increment number of records
            intNumberOfRecords = intNumberOfRecords + 1

            subUpdateList()

            ' Clear input objects
            dtpDateOfCheck.Value = Today()
            txtComments.Text = ""

        Else
            MessageBox.Show(strErrors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub butClear_Click(sender As Object, e As EventArgs) Handles butClear.Click
        ' Clear input objects
        dtpDateOfCheck.Value = Today()
        txtComments.Text = ""

        ' Reset the colo[u]r of the comments text box
        txtComments.BackColor = System.Drawing.SystemColors.Window

        ' Clear list box selection
        lstRecords.SelectedIndex = -1

        ' Disable the print selected button (if not done so already)
        butPrintRecs.Enabled = False
    End Sub

    Private Sub butRemove_Click(sender As Object, e As EventArgs) Handles butRemove.Click
        ' Verify that user wishes to remove record
        If MessageBox.Show("Are you sure you want to remove the selected safety testing record?",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            ' Set record number to remove
            Dim srtRecordNumToRemove As UShort = lstRecords.SelectedIndex + 1

            ' Copy records other than one to be removed to a temporary file
            FileOpen(2, strFolderLocation & "Machine_Testing_Records_temp.dat", OpenMode.Random, , , Len(New rtpSafetyRecord))
            For i = 1 To srtRecordNumToRemove - 1
                FileGet(1, recSafetyRecord_Read, i)
                FilePut(2, recSafetyRecord_Read, i)
            Next
            For i = srtRecordNumToRemove + 1 To intNumberOfRecords
                FileGet(1, recSafetyRecord_Read, i)
                FilePut(2, recSafetyRecord_Read, i - 1)
            Next
            FileClose(1, 2)

            ' Delete old file and rename temporary file so it can be used
            My.Computer.FileSystem.DeleteFile(strFolderLocation & "Machine_Testing_Records.dat")
            My.Computer.FileSystem.RenameFile(strFolderLocation & "Machine_Testing_Records_temp.dat", "Machine_Testing_Records.dat")

            ' Now open the new file
            FileOpen(1, strFolderLocation & "Machine_Testing_Records.dat", OpenMode.Random, , , Len(New rtpSafetyRecord))

            ' Amend number of records
            intNumberOfRecords = intNumberOfRecords - 1

            ' Clear list box selection
            lstRecords.SelectedIndex = -1

            subUpdateList()
        End If
    End Sub

    Private Sub lstRecords_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRecords.SelectedIndexChanged
        ' Reset the colo[u]r of the comments text box
        txtComments.BackColor = System.Drawing.SystemColors.Window

        ' See if any items have been selected, if so, disable new input from being entered
        If lstRecords.SelectedIndices.Count > 0 Then

            dtpDateOfCheck.Enabled = False
            txtComments.ReadOnly = True
            butAdd.Enabled = False

            ' If one item has been selected, update the select record input objects
            If lstRecords.SelectedIndices.Count = 1 Then
                FileGet(1, recSafetyRecord_Read, lstRecords.SelectedIndex + 1)
                dtpDateOfCheck.Value = recSafetyRecord_Read.dteDateOfCheck
                txtComments.Text = Trim(recSafetyRecord_Read.strComments)

                butRemove.Enabled = True
                butPrintRecs.Enabled = True
            Else
                ' If more than one item has been selected, clear any existing inputs
                dtpDateOfCheck.Value = Today()
                txtComments.Text = ""

                butRemove.Enabled = False

                ' If the number of records selected does not exceed 16, enable the print selected button
                ' This is so the amount of records do not cause an overflow if printed
                If lstRecords.SelectedIndices.Count > 1 Then
                    butPrintRecs.Enabled = True
                Else
                    butPrintRecs.Enabled = False
                End If
            End If
        Else

            ' If no items have been selected, clear existing inputs and allow new input to be entered
            dtpDateOfCheck.Value = Today()
            txtComments.Text = ""

            dtpDateOfCheck.Enabled = True
            txtComments.ReadOnly = False
            butAdd.Enabled = True
            butRemove.Enabled = False
        End If
    End Sub

    Private Sub butPrintSheets_Click(sender As Object, e As EventArgs) Handles butPrintSheets.Click
        ' Ask user how many blank sheets they want printing -  input number of pages to input box
        ' and validate, use a string for the moment so we do not come across runtime errors during validation
        Dim strPagesToPrint_Verify As String
        Dim blnInvalid As Boolean
        Do
            blnInvalid = False
            strPagesToPrint_Verify = InputBox("Enter number of pages to print")

            ' Proceed with validation if input is not an empty string
            If strPagesToPrint_Verify <> "" Then

                ' Check that input is a number
                If Not IsNumeric(strPagesToPrint_Verify) Then
                    MessageBox.Show("You must enter a number. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    blnInvalid = True

                    ' Check that input is greater than or equal to 1
                ElseIf strPagesToPrint_Verify < 1 Then
                    MessageBox.Show("You must enter a number greater than or equal to 1. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    blnInvalid = True
                End If
            End If
        Loop Until Not blnInvalid

        ' Proceed as long as the input is not an empty string (generally means cancel)
        If strPagesToPrint_Verify <> "" Then

            ' Assign input to number of pages
            pntBlankSheets.PrinterSettings.Copies = CInt(strPagesToPrint_Verify)

            ' Print sheets
            pntBlankSheets.Print()
        End If
    End Sub

    Private Sub butPrintRecs_Click(sender As Object, e As EventArgs) Handles butPrintRecs.Click
        ' Reset record number variable, number of pages and print preview opened boolean
        intCurrentRecordNum = lstRecords.SelectedIndices.Count - 1
        intNumberOfPages = 0
        blnPrintPreviewOpened = False

        frmHomeScreen.ppdPrintPreview.Document = pntTestRecords
        frmHomeScreen.ppdPrintPreview.Width = 800
        frmHomeScreen.ppdPrintPreview.Height = 600
        frmHomeScreen.ppdPrintPreview.ShowDialog()
    End Sub

    Private Sub pntBlankSheets_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pntBlankSheets.PrintPage
        Dim fntTitle As New Font("Courier New", 15, FontStyle.Underline Or FontStyle.Bold)
        Dim fntHeader As New Font("Courier New", 9, FontStyle.Bold)
        Dim fntRegular As New Font("Courier New", 9, FontStyle.Regular)
        Const strReportFormat As String = "{0, -20}{1, -32}{2, -40}"
        Dim x As Integer = 50
        Dim y As Integer = 50

        ' Print title
        e.Graphics.DrawString("Workshop Machinery Safety Testing", fntTitle, Brushes.Black, 200, y)

        ' Print blank line and header
        y = y + 2 * fntRegular.Height
        e.Graphics.DrawString(String.Format(strReportFormat, "Date (w/e)", "Staff signature", "Comments/Action required"),
                              fntHeader, Brushes.Black, x, y)

        ' Print blank lines for writing test records
        For i = 0 To 16
            y = y + 2 * fntRegular.Height
            e.Graphics.DrawString(String.Format("{0, -52}{1, -40}", "", New String(".", 38)),
                                  fntRegular, Brushes.Black, x, y)
            y = y + fntRegular.Height
            e.Graphics.DrawString(String.Format(strReportFormat,
                                                New String(".", 18), New String(".", 30),
                                                New String(".", 38)), fntRegular, Brushes.Black, x, y)
            y = y + fntRegular.Height
            e.Graphics.DrawString(String.Format("{0, -52}{1, -40}", "", New String(".", 38)),
                                  fntRegular, Brushes.Black, x, y)
        Next
    End Sub

    Private Sub pntTestRecords_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pntTestRecords.PrintPage
        Dim fntTitle As New Font("Courier New", 15, FontStyle.Underline Or FontStyle.Bold)
        Dim fntHeader As New Font("Courier New", 9, FontStyle.Bold)
        Dim fntRegular As New Font("Courier New", 9, FontStyle.Regular)
        Const strReportFormat As String = "{0, -20}{1, -32}{2, -40}"
        Dim x As Integer = 50
        Dim y As Integer = 50

        intNumberOfPages = intNumberOfPages + 1
        e.HasMorePages = False

        ' Print title if this is the first page
        If intNumberOfPages = 1 Then
            e.Graphics.DrawString("Workshop Machinery Safety Testing", fntTitle, Brushes.Black, 200, y)

            ' Print blank line
            y = y + 2 * fntRegular.Height
        End If

        ' Print header
        e.Graphics.DrawString(String.Format(strReportFormat, "Date (w/e)", "Staff signature", "Comments/Action required"),
                              fntHeader, Brushes.Black, x, y)

        y = y + fntRegular.Height

        ' Print lines for test records
        For i = intCurrentRecordNum To 0 Step -1
            y = y + fntRegular.Height
            Dim blnMultilineComments As Boolean = False

            ' Retrieve data from next record
            FileGet(1, recSafetyRecord_Read, lstRecords.SelectedIndices(i) + 1)

            ' See if comments string is any more than 40 characters
            If Len(Trim(recSafetyRecord_Read.strComments)) > 40 Then

                ' If so, set multiline boolean to True
                ' Otherwise, leave it as false
                blnMultilineComments = True
            End If

            ' Print next line
            If blnMultilineComments Then

                ' If the comments required multiple lines to fit, the input must be formatted for this to work
                Dim strComments_Amended As String = Trim(recSafetyRecord_Read.strComments)

                ' First line contains only the first section of the comments
                e.Graphics.DrawString(String.Format("{0, -52}{1, -40}", "", Mid(strComments_Amended, 1, 39)),
                                      fntRegular, Brushes.Black, x, y)

                y = y + fntRegular.Height

                ' The second line contains the date and dots for writing a signature, any leading spaces in the
                ' cut string are removed
                strComments_Amended = LTrim(Mid(strComments_Amended, 40))
                e.Graphics.DrawString(String.Format(strReportFormat,
                                                FormatDateTime(recSafetyRecord_Read.dteDateOfCheck, DateFormat.ShortDate),
                                                New String(".", 30), Mid(strComments_Amended, 1, 39)),
                                                fntRegular, Brushes.Black, x, y)

                ' If more lines are needed, these will only feature the comments to the right of the page
                ' Leading spaces in each cut string are removed as usual
                Do While Len(strComments_Amended) > 0
                    y = y + fntRegular.Height
                    strComments_Amended = LTrim(Mid(strComments_Amended, 40))
                    e.Graphics.DrawString(String.Format("{0, -52}{1, -40}", "", Mid(strComments_Amended, 1, 39)),
                                          fntRegular, Brushes.Black, x, y)
                Loop
            Else

                ' If the comments can fit on one line, print all of the information onto a single line
                e.Graphics.DrawString(String.Format(strReportFormat,
                                                    FormatDateTime(recSafetyRecord_Read.dteDateOfCheck, DateFormat.ShortDate),
                                                    New String(".", 30), Trim(recSafetyRecord_Read.strComments)),
                                                    fntRegular, Brushes.Black, x, y)

                y = y + fntRegular.Height
            End If

            ' Check if the page is full and if we need to starting writing on a new page
            If y >= 900 Then
                intCurrentRecordNum = i + 1
                e.HasMorePages = True
                Exit For
            End If
        Next

        ' If the maximum height for adding records has not been reached 
        ' and this is the last page, add some blank lines for records to be written down
        If Not e.HasMorePages Then
            y = y - fntRegular.Height
            Do While y < 950
                y = y + 2 * fntRegular.Height
                e.Graphics.DrawString(String.Format("{0, -52}{1, -40}", "", New String(".", 38)),
                                      fntRegular, Brushes.Black, x, y)
                y = y + fntRegular.Height
                e.Graphics.DrawString(String.Format(strReportFormat,
                                                    New String(".", 18), New String(".", 30),
                                                    New String(".", 38)), fntRegular, Brushes.Black, x, y)
                y = y + fntRegular.Height
                e.Graphics.DrawString(String.Format("{0, -52}{1, -40}", "", New String(".", 38)),
                                      fntRegular, Brushes.Black, x, y)
            Loop
        End If

        ' Print page number
        e.Graphics.DrawString(intNumberOfPages, fntRegular, Brushes.Black, 420, 1050)
    End Sub

    Private Sub pntTestRecords_EndPrint(sender As Object, e As Printing.PrintEventArgs) Handles pntTestRecords.EndPrint
        subInformMultiplePages(intNumberOfPages)
    End Sub

    Private Sub frmSafMan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Upon closing this form, close all files and show the home screen
        FileClose()
        frmHomeScreen.Show()
    End Sub
End Class