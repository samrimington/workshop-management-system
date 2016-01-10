' ╔════════════════════════════════════════════════════════════════╗
' ----Workshop Management System Project----------------------------
' ----Sam Rimington-------------------------------------------------
' ----A2 Computing--------------------------------------------------
' ----F454----------------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Folder Location Selector--------------------------------------
' --The purpose of this form is to let the user change where data---
' --files are stored for the program to use.------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Date since last change: 04-12-2014----------------------------
' ╚════════════════════════════════════════════════════════════════╝

Imports WorMS.frmHomeScreen

Public Class dlgHomeScreen_ChangeFileDir

    Public strNewFolderLocation As String

    Private Sub dlgHomeScreen_ChangeFileDir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFileDirectory.Text = strFolderLocation
    End Sub

    Private Sub butBrowse_Click(sender As Object, e As EventArgs) Handles butBrowse.Click
        ' Upon clicking browse, show the folder location dialog
        fbdFolderLocation.ShowDialog()

        ' Assign the selected location to variable
        strNewFolderLocation = fbdFolderLocation.SelectedPath.ToString()

        ' See whether a WorMS folder has been selected, if not, add it to the end of the location variable
        If Strings.Right(strNewFolderLocation, 5) <> "WorMS" Then
            strNewFolderLocation = System.IO.Path.GetFullPath(strNewFolderLocation & "/WorMS/")
        Else
            strNewFolderLocation = System.IO.Path.GetFullPath(strNewFolderLocation & "/")
        End If

        ' Check if location variable is blank (generally means Cancel)
        If fbdFolderLocation.SelectedPath.ToString() <> "" Then
            txtFileDirectory.Text = strNewFolderLocation
        End If
    End Sub

    Private Sub hypHelp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles hypHelp.LinkClicked
        ' Upon clicking the Help hyperlink, open the online help for this form
        dlgHelp.Close()
        dlgHelp.strFormName = Me.Name
        dlgHelp.Show()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOK.Click
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        strNewFolderLocation = ""
        Me.Close()
    End Sub

End Class
