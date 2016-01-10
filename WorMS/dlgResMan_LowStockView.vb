' ╔════════════════════════════════════════════════════════════════╗
' ----Workshop Management System Project----------------------------
' ----Sam Rimington-------------------------------------------------
' ----A2 Computing--------------------------------------------------
' ----F454----------------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Low Stock Viewer----------------------------------------------
' --The purpose of this form is to let the user view resource-------
' --stock low in quantity, displaying the amount each resource is---
' --under their minimum stock. The list of resources low in stock---
' --may be printed and resources in the list may be selected to-----
' --add to a new requisition form.----------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Date since last change: 04-12-2014----------------------------
' ╚════════════════════════════════════════════════════════════════╝

Imports WorMS.frmHomeScreen

Public Class dlgResMan_LowStockView
    ' Declare variables and structures for use in this form
    Dim intNumberOfResources, intResListIndex(), intCurrentRecordNum, intNumberOfPages As Integer
    Dim intIndexCount As Integer = -1
    Dim recResource_Read As rtpResource

    Private Sub dlgResMan_LowStockView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' We must search through the records on file, compare their stock
        ' with the minimum stock and add to list box if stock is lower than this
        Dim sinAmountUnder As Single
        Dim strListFormat As String = "{0, -64}{1, -15}{2, -15}{3, -15}"
        intNumberOfResources = frmResMan.intNumberOfResources
        lstLowStock.Items.Clear()
        lstLowStock.Items.Add(String.Format(strListFormat, "Resource", "Amount", "Min Amount", "Amount Under"))
        intIndexCount = -1
        ReDim intResListIndex(0)
        For i = 1 To intNumberOfResources
            FileGet(1, recResource_Read, i)

            ' If we find a resource like this, we add it to the list box and
            ' also take its index for later reference
            If recResource_Read.sinQuantity <= recResource_Read.sinMinQuantity Then
                intIndexCount = intIndexCount + 1
                ReDim Preserve intResListIndex(intIndexCount)
                intResListIndex(intIndexCount) = i
                sinAmountUnder = recResource_Read.sinMinQuantity - recResource_Read.sinQuantity

                ' Ensure to round amount under values when concatenating to avoid floating point errors
                lstLowStock.Items.Add(String.Format(strListFormat, recResource_Read.strName,
                                              recResource_Read.sinQuantity & " " & recResource_Read.strUnit,
                                              recResource_Read.sinMinQuantity & " " & recResource_Read.strUnit,
                                              Math.Round(sinAmountUnder, 2) & " " & recResource_Read.strUnit))

                ' Make sure Print and Add to Form buttons are enabled
                butPrint.Enabled = True
                butAddToForm.Enabled = True
            End If
        Next
        If intIndexCount = -1 Then

            ' If no records are added, disable Print button
            butPrint.Enabled = False
        End If

        ' Disable Add to Form button
        butAddToForm.Enabled = False
    End Sub

    Private Sub lstLowStock_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstLowStock.SelectedIndexChanged
        ' As long as header is not selected, enable add to form button
        ' If no values are selected or header is selected, disable add to form button
        If lstLowStock.SelectedIndex > 0 And lstLowStock.SelectedIndices.Count <= 8 Then
            butAddToForm.Enabled = True
        Else
            lstLowStock.SelectedIndex = -1
            butAddToForm.Enabled = False
        End If
    End Sub

    Private Sub hypHelp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles hypHelp.LinkClicked
        ' Upon clicking the Help hyperlink, open the online help for this form
        dlgHelp.Close()
        dlgHelp.strFormName = Me.Name
        dlgHelp.Show()
    End Sub

    Private Sub butAddToForm_Click(sender As Object, e As EventArgs) Handles butAddToForm.Click
        ' Assign selected resources to resources array in frmReqEdit, trimming strings where necessary
        For i = 0 To lstLowStock.SelectedIndices.Count - 1
            FileGet(1, recResource_Read, intResListIndex(lstLowStock.SelectedIndices(i) - 1))
            ReDim Preserve frmReqEdit.recResource(i)
            frmReqEdit.recResource(i).strName = Trim(recResource_Read.strName)
            frmReqEdit.recResource(i).bytQuantity = 1
        Next

        ' Close this form and frmResMan and open frmReqEdit
        frmResMan.blnQuit = True
        frmReqEdit.blnAddResourcesFromLowStock = True
        Me.Close()
        frmResMan.Close()
        frmReqEdit.Show()
    End Sub

    Private Sub butPrint_Click(sender As Object, e As EventArgs) Handles butPrint.Click
        ' Reset record number variable, number of pages and print preview opened boolean
        intCurrentRecordNum = 0
        intNumberOfPages = 0
        blnPrintPreviewOpened = False

        frmHomeScreen.ppdPrintPreview.Document = pntLowStockReport
        frmHomeScreen.ppdPrintPreview.Width = 800
        frmHomeScreen.ppdPrintPreview.Height = 600
        frmHomeScreen.ppdPrintPreview.ShowDialog()
    End Sub

    Private Sub butClose_Click(sender As Object, e As EventArgs) Handles butClose.Click
        Me.Close()
    End Sub

    Private Sub pntLowStockReport_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pntLowStockReport.PrintPage
        ' Declaring variables
        Dim fntTitle As New Font("Courier New", 15, FontStyle.Underline Or FontStyle.Bold)
        Dim fntHeader As New Font("Courier New", 9, FontStyle.Bold)
        Dim fntRegular As New Font("Courier New", 9, FontStyle.Regular)
        Const strReportFormat As String = "{0, -40}{1, -16}{2, -16}{3, -16}"
        Dim x As Integer = 50
        Dim y As Integer = 50

        intNumberOfPages = intNumberOfPages + 1
        e.HasMorePages = False

        ' Print title if this is the first page
        If intCurrentRecordNum = 0 Then
            e.Graphics.DrawString("Low Stock Report - " & Now.Date, fntTitle, Brushes.Black, 220, y)

            ' Print blank line
            y = y + 2 * fntRegular.Height
        End If

        ' Print header
        e.Graphics.DrawString(String.Format(strReportFormat, "Resource", "Category", "Amount", "Min Amount"),
                              fntHeader, Brushes.Black, x, y)

        ' Print lines for stock
        For i = intCurrentRecordNum To intIndexCount

            y = y + fntRegular.Height
            Dim blnMultilineName As Boolean = False

            ' Retrieve data from next record
            FileGet(1, recResource_Read, intResListIndex(i))

            ' Trim read strings
            recResource_Read.strCategory = Trim(recResource_Read.strCategory)
            recResource_Read.strName = Trim(recResource_Read.strName)
            recResource_Read.strUnit = Trim(recResource_Read.strUnit)

            ' See if resource name is any more than 32 characters
            If Len(recResource_Read.strName) > 32 Then

                ' If so, set multiline boolean to True
                ' Otherwise, leave it as false
                blnMultilineName = True
            End If

            ' Print next line
            If blnMultilineName Then
                Dim intExcess As Integer = Len(recResource_Read.strName) - 31
                e.Graphics.DrawString(String.Format(strReportFormat, Mid(recResource_Read.strName, 1, 32),
                                                    recResource_Read.strCategory,
                                                    recResource_Read.sinQuantity & " " & recResource_Read.strUnit,
                                                    recResource_Read.sinMinQuantity & " " & recResource_Read.strUnit),
                                                    fntRegular, Brushes.Black, x, y)
                y = y + fntRegular.Height
                e.Graphics.DrawString(Mid(recResource_Read.strName, 32, intExcess), fntRegular, Brushes.Black, x, y)
            Else
                e.Graphics.DrawString(String.Format(strReportFormat, recResource_Read.strName,
                                                    recResource_Read.strCategory,
                                                    recResource_Read.sinQuantity & " " & recResource_Read.strUnit,
                                                    recResource_Read.sinMinQuantity & " " & recResource_Read.strUnit),
                                                    fntRegular, Brushes.Black, x, y)
            End If

            ' Check if the page is full and if we need to starting writing on a new page
            If y >= 1000 Then
                intCurrentRecordNum = i + 1
                e.HasMorePages = True
                Exit For
            End If
        Next

        ' Print page number
        e.Graphics.DrawString(intNumberOfPages, fntRegular, Brushes.Black, 420, 1050)
    End Sub

    Private Sub pntLowStockReport_EndPrint(sender As Object, e As Printing.PrintEventArgs) Handles pntLowStockReport.EndPrint
        subInformMultiplePages(intNumberOfPages)
    End Sub

End Class
