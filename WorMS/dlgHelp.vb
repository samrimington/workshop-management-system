' ╔════════════════════════════════════════════════════════════════╗
' ----Workshop Management System Project----------------------------
' ----Sam Rimington-------------------------------------------------
' ----A2 Computing--------------------------------------------------
' ----F454----------------------------------------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Help Viewer---------------------------------------------------
' --The purpose of this form is to let the user view help webpages--
' --for a guide on how to use the program.--------------------------
' ╚════════════════════════════════════════════════════════════════╝
' ╔════════════════════════════════════════════════════════════════╗
' ----Date since last change: 04-12-2014----------------------------
' ╚════════════════════════════════════════════════════════════════╝

Public Class dlgHelp

    Public strFormName As String

    Private Sub dlgHelp_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        ' Take the name of the form that triggered the help dialog and open its help page

        wbrHelp.Navigate("file:///" & Replace(Application.StartupPath, "\", "/") & "/Resources/Help/Help_" & strFormName & ".html")
    End Sub

End Class