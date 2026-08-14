
Imports WinItalPascal

Public Class FrmUno
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            FrmTitolo.CTitolo(Me, "Gestione Titolo Form al Centro")
            ' Oppure se inserisci il titolo nelle Proprietà del Form
            ' CentraTitolo(Me, Me.Text)

            PopupHelper.AttachPopup(RjCircularPictureBox2, "Ciao, sono un messaggio di popup!")

        Catch ex As Exception
            MessageBox.Show("Errore nel caricamento delle immagini: " & ex.Message)
        End Try
    End Sub


End Class
