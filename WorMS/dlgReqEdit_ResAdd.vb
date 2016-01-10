' ╔════════════════════════════════════════════════════════════════╗
' ----Workshop Management System Project----------------------------
' ----Sam Rimington-------------------------------------------------
' ----A2 Computing--------------------------------------------------
' ----F454----------------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Requested Resource Editor-------------------------------------
' --The purpose of this form is to let the user add resources to a--
' --requisition form through the Requisition Form Editor.-----------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Date since last change: 04-12-2014----------------------------
' ╚════════════════════════════════════════════════════════════════╝

Imports WorMS.frmHomeScreen

Public Class dlgReqEdit_ResAdd
    ' Declare variables and structures for use in this form
    Public recNewResource As rtpReqFormResource

    Sub subResetInputObjectColours()
        ' Reset all colo[u]rs of input objects
        txtCatNum.BackColor = System.Drawing.SystemColors.Window
        txtName.BackColor = System.Drawing.SystemColors.Window
        txtCostPP.BackColor = System.Drawing.SystemColors.Window
        txtDiscount.BackColor = System.Drawing.SystemColors.Window
        txtVAT.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub dlgReqEdit_ResAdd_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Make sure category number is focused
        txtCatNum.Focus()
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

        subResetInputObjectColours()

        ' Check that the catalogue number text box input is not blank
        If txtCatNum.Text = "" Then
            strErrors = "The resource catalogue number cannot be blank." & vbCrLf
            txtCatNum.BackColor = Color.Tomato
        End If

        ' Check that the resource name text box input is not blank
        If txtName.Text = "" Then
            strErrors = strErrors & "The resource name cannot be blank." & vbCrLf
            txtName.BackColor = Color.Tomato
        End If

        ' Check that the cost per piece text box input is not blank
        If txtCostPP.Text = "" Then
            strErrors = strErrors & "The cost per piece cannot be blank." & vbCrLf
            txtCostPP.BackColor = Color.Tomato

            ' If so, check that input is numeric and then check that it is a positive number
        ElseIf Not IsNumeric(txtCostPP.Text) Then
            strErrors = strErrors & "The cost per piece must be a number." & vbCrLf
            txtCostPP.BackColor = Color.Tomato
        ElseIf txtCostPP.Text < 0 Then
            strErrors = strErrors & "The cost per piece must be more than or equal to 0." & vbCrLf
            txtCostPP.BackColor = Color.Tomato

            ' Finally, if all of this is true, check that the input does not exceed two decimal places
            ' To do this verification, a decimal point must exist
        ElseIf InStr(txtCostPP.Text, ".") > 0 Then
            If Len(Mid(txtCostPP.Text, InStr(txtCostPP.Text, ".") + 1)) > 2 Then
                strErrors = strErrors & "The cost per piece must not exceed two decimal places." & vbCrLf
                txtCostPP.BackColor = Color.Tomato
            End If
        End If

        ' Check that the discount amount text box input is not blank
        If txtDiscount.Text = "" Then
            strErrors = strErrors & "The discount amount cannot be blank." & vbCrLf
            txtDiscount.BackColor = Color.Tomato

            ' If so, check that input is numeric and then check that it is a positive number
        ElseIf Not IsNumeric(txtDiscount.Text) Then
            strErrors = strErrors & "The discount amount must be a number." & vbCrLf
            txtDiscount.BackColor = Color.Tomato
        ElseIf txtDiscount.Text < 0 Then
            strErrors = strErrors & "The discount amount must be more than or equal to 0." & vbCrLf
            txtDiscount.BackColor = Color.Tomato

            ' Finally, if all of this is true, check that the input does not exceed two decimal places
            ' To do this verification, a decimal point must exist
        ElseIf InStr(txtDiscount.Text, ".") > 0 Then
            If Len(Mid(txtDiscount.Text, InStr(txtDiscount.Text, ".") + 1)) > 2 Then
                strErrors = strErrors & "The discount amount must not exceed two decimal places." & vbCrLf
                txtDiscount.BackColor = Color.Tomato
            End If
        End If

        ' Check that the VAT text box input is not blank
        If txtVAT.Text = "" Then
            strErrors = strErrors & "The VAT amount cannot be blank." & vbCrLf
            txtVAT.BackColor = Color.Tomato

            ' If so, check that input is numeric and then check that it is a positive number
        ElseIf Not IsNumeric(txtVAT.Text) Then
            strErrors = strErrors & "The VAT amount must be a number." & vbCrLf
            txtVAT.BackColor = Color.Tomato
        ElseIf txtVAT.Text < 0 Then
            strErrors = strErrors & "The VAT amount must be more than or equal to 0." & vbCrLf
            txtVAT.BackColor = Color.Tomato

            ' Finally, if all of this is true, check that the input does not exceed two decimal places
            ' To do this verification, a decimal point must exist
        ElseIf InStr(txtVAT.Text, ".") > 0 Then
            If Len(Mid(txtVAT.Text, InStr(txtVAT.Text, ".") + 1)) > 2 Then
                strErrors = strErrors & "The VAT amount must not exceed two decimal places." & vbCrLf
                txtVAT.BackColor = Color.Tomato
            End If
        End If

        If strErrors = "" Then

            ' If valid, add resource to the resource record structure array
            recNewResource.strCatalogueNumber = txtCatNum.Text
            recNewResource.strName = txtName.Text
            recNewResource.sinCostPerPiece = txtCostPP.Text
            recNewResource.bytQuantity = spnQuantity.Value
            recNewResource.sinDiscount = txtDiscount.Text
            recNewResource.sinVAT = txtVAT.Text

            ' With total cost, round answer to avoid floating point errors
            recNewResource.sinTotalCost = Math.Round(recNewResource.bytQuantity * (recNewResource.sinCostPerPiece +
                                                                                   recNewResource.sinVAT -
                                                                                   recNewResource.sinDiscount), 2)

            Me.DialogResult = Windows.Forms.DialogResult.OK

            ' Clear all inputs before closing
            txtCatNum.Text = ""
            txtName.Text = ""
            txtCostPP.Text = ""
            spnQuantity.Value = 1
            txtDiscount.Text = ""
            txtVAT.Text = ""
            Me.Close()
        Else
            MessageBox.Show(strErrors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        ' Clear all inputs before closing
        txtCatNum.Text = ""
        txtName.Text = ""
        txtCostPP.Text = ""
        spnQuantity.Value = 1
        txtDiscount.Text = ""
        txtVAT.Text = ""
        Me.Close()
    End Sub

End Class