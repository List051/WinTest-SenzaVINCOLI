
Imports WinItalPascal

Public Class Info

    Private Sub Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FrmTitolo.CTitolo(Me, "Sostituzione del DataSet senza problemi nel progetto")
        CentraMonitor(Me)

    End Sub

#Region "Eliminata dalla libreria"

    ' è sufficiente impostare in proprità CenterScreen
    Public Sub CentraMonitor(frm As Form)

        Try

            If frm Is Nothing Then Exit Sub

            ' schermo corrente del form
            Dim screen As Screen = Screen.FromControl(frm)

            ' area utilizzabile
            Dim area As Rectangle = screen.WorkingArea

            ' dimensioni form
            frm.Width = area.Width - 300
            frm.Height = area.Height - 100

            ' centratura
            frm.Left = area.Left + (area.Width - frm.Width) \ 2
            frm.Top = area.Top + (area.Height - frm.Height) \ 2

        Catch ex As Exception

            FrameworkLogger.LogError(ex, "FormHelper.CentraMonitor")

        End Try

        ' Utilizzovo con  FormHelper.CentraMonitor(Me)
    End Sub
#End Region

End Class