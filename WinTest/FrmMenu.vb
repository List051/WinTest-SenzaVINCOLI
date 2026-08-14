
'Imports System.Windows.Forms
'Imports System.Drawing

Imports CustomMessageBoxVB
Imports WinItalPascal
Public Class FrmMenu


    Private Sub FrmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ScreenUtility.FullScreen(Me)
        FrmTitolo.CTitolo(Me, "Gestione DB con WinItalPascal")

    End Sub
    Private Sub CloseOpenForm()
        ' Crea una lista dei form aperti (senza modificare Application.OpenForms durante il ciclo)
        Dim openFormsList As New List(Of Form)

        ' Aggiungi i form aperti alla lista
        For Each f As Form In Application.OpenForms
            ' Escludi FrmMenu dalla chiusura
            If f.Name <> "Form1" Then
                openFormsList.Add(f)
            End If
        Next

        ' Chiudi ogni form nella lista, tranne FrmMenu
        For Each f As Form In openFormsList
            If f.Name = "FrmClienti" AndAlso f.Visible Then   ' Gestione Clienti
                f.Close()
                'ElseIf f.Name = "FrmB" AndAlso f.Visible Then ' Stampa Report Clienti
                '    f.Close()
                'ElseIf f.Name = "FrmC" AndAlso f.Visible Then ' Gestione Clienti
                '    f.Close()
                'ElseIf f.Name = "FrmD" AndAlso f.Visible Then ' Gestione Ordini
                '    f.Close()
                'ElseIf f.Name = "FrmM" AndAlso f.Visible Then ' Gestione Materiale
                '    f.Close()
                'ElseIf f.Name = "FrmFattura" AndAlso f.Visible Then ' Gestione Fattura
                '    f.Close()
                'ElseIf f.Name = "FrmReport" AndAlso f.Visible Then ' Gestione Report
                '    f.Close()
            End If
        Next
    End Sub
    Private Sub BtnEsciChiudi_Click(sender As Object, e As EventArgs) Handles BtnEsciChiudi.Click
        Dim result As DialogResult = RJMessageBox.Show("Sei sicuro di voler uscire?", "Uscita",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnApriClienti_Click(sender As Object, e As EventArgs) Handles BtnApriClienti.Click
        'CloseOpenForm()
        'With FrmClienti   ' da fare
        '    .TopLevel = False
        '    PanelBody.Controls.Add(FrmClienti)
        '    .BringToFront()
        '    .Show()
        'End With
    End Sub

    Private Sub BtnFrmAprire_Click(sender As Object, e As EventArgs) Handles BtnFrmAprire.Click
        FrmAprire.Show()
    End Sub

    Private Sub BtnApriOrdini_Click(sender As Object, e As EventArgs) Handles BtnApriOrdini.Click
        ' apri Ordini da fare
    End Sub

    Private Sub BtnCliOrd_Click(sender As Object, e As EventArgs) Handles BtnCliOrd.Click
        FrmCliOrd.Show()
    End Sub

    Private Sub BtnInsClientiSenzaBS_Click(sender As Object, e As EventArgs) Handles BtnInsClientiSenzaBS.Click
        FemInsClienti.Show()
    End Sub

    Private Sub BtnApriFatture_Click(sender As Object, e As EventArgs) Handles BtnApriFatture.Click
        FrmFattura.Show()
    End Sub


    Private Sub RjBtnInfo_Click(sender As Object, e As EventArgs) Handles RjBtnInfo.Click
        RJMessageBox.Show("Info per cambio DataSet")
        Info.Show()
    End Sub
End Class
