

Imports System.Configuration
Imports System.Data.SqlClient
Imports CustomMessageBoxVB
Imports WinItalPascal
'Imports WinItalPascal.WinTest.Lib.Data

Public Class FrmAprire

    Private IsLoading As Boolean = True

    ' Istanza riutilizzabile della classe di salvataggio
    Private ReadOnly DBSalva As New DBSalvaTabelle()

    ' Istanza della classe di salvataggio
    'Private DBSalva As New DBSalvaTabelle()

#Region " FORM LOAD "

    Private Sub FrmAprire_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FrmTitolo.CTitolo(Me, "Demo di FormHelper.ApriFormFade")

        AddHandler DTGAprire.DataBindingComplete, AddressOf DTGAprire_DataBindingComplete

        ' Carica tabella di default
        '  CaricaTabella("clienti")

        ' Carica la tabella "Clienti" all'avvio (modificare il nome se necessario)
        CaricaDGV(DTGAprire, "Clienti")

        ' Carica lista tabelle SQL
        Dim dtTables As DataTable = DB.GetTables()

        CboTabella.DataSource = dtTables
        CboTabella.DisplayMember = "TABLE_NAME"
        CboTabella.ValueMember = "TABLE_NAME"

        If CboTabella.Items.Count > 0 Then
            CboTabella.SelectedIndex = 0
        End If

        IsLoading = False

        ' Colori colonne
        ColoraDgv(DTGAprire)

    End Sub

#End Region

#Region " EVENTI "

    Private Sub DTGAprire_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        Dim dgv = DirectCast(sender, DataGridView)
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgv.AutoResizeColumns(DataGridViewAutoSizeColumnMode.AllCells)
    End Sub

    Private Sub CboTabella_SelectionChangeCommitted(sender As Object, e As EventArgs) _
        Handles CboTabella.SelectionChangeCommitted

        CaricaTabella(CboTabella.SelectedValue.ToString())

    End Sub

    Private Sub CboTabella_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles CboTabella.SelectedIndexChanged

        If IsLoading Then Exit Sub
        CaricaTabella(CboTabella.SelectedValue.ToString())

    End Sub

#End Region

#Region " CARICA TABELLA "

    ''' <summary>
    ''' Carica i dati nella griglia usando DB.FillDataTable, imposta Tag con il nome tabella
    ''' e applica le regole di DBSalvaTabelle (PK e blocco colonne non modificabili).
    ''' </summary>
    Public Sub CaricaDGV(dgv As DataGridView, tableName As String)
        If String.IsNullOrEmpty(tableName) OrElse dgv Is Nothing Then Return

        ' Usa la tua libreria per riempire il DataTable
        Dim sql As String = $"SELECT * FROM {tableName}"
        Dim dt As DataTable = DB.FillDataTable(sql)

        If dt Is Nothing Then
            RJMessageBox.Show($"Nessun dato per la tabella '{tableName}'.")
            Return
        End If

        ' Associa il DataTable al DataGridView e conserva il nome della tabella nel Tag
        dgv.DataSource = dt
        dgv.Tag = tableName

        ' Imposta alcune proprietà utili
        dgv.AutoGenerateColumns = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.AllowUserToAddRows = True

        ' Applica PK e blocco colonne usando l'istanza di classe DBSalva
        Try
            DBSalva.ImpostaPKNelDataTable(dt, tableName)
            DBSalva.BloccaColonneNonModificabili(dgv, tableName)
        Catch ex As Exception
            ' Non bloccare il caricamento se qualcosa fallisce qui, solo loggare
            RJMessageBox.Show("Attenzione: " & ex.Message)
        End Try
    End Sub


    Private Sub CaricaTabella(nomeTabella As String)

        Try
            Dim sql As String = "SELECT * FROM " & nomeTabella
            Dim dt As DataTable = DB.FillDataTable(sql)

            ' Imposta PK nel DataTable
            DBSalva.ImpostaPKNelDataTable(dt, nomeTabella)

            ' Imposta DataSource
            DTGAprire.DataSource = dt

            ' Memorizza il nome tabella nel Tag
            DTGAprire.Tag = nomeTabella

            ' Salva in Maiuscolo
            GridUtility.ConvertiMaiuscolo(DTGAprire)

            ' Blocca colonne non modificabili
            DBSalva.BloccaColonneNonModificabili(DTGAprire, nomeTabella)

            ' Colori colonne
            ColoraDgv(DTGAprire)

        Catch ex As SqlException
            MsgBox("SQL ERROR: " & ex.Number & vbCrLf & ex.Message)
            FrameworkLogger.LogError(ex, "CaricaTabella")
        End Try

    End Sub

#End Region

#Region " SALVA TABELLA "

    Private Sub RjCircSalvaTabella_Click(sender As Object, e As EventArgs) Handles RjCircSalvaTabella.Click
        ' DBSalva.Salva(DTGAprire)
        Try
            ' Assicuriamoci che gli edit siano terminati
            Me.Validate()
            If DTGAprire.IsCurrentCellInEditMode Then DTGAprire.EndEdit()
            Dim tableName As String = TryCast(DTGAprire.Tag, String)
            If String.IsNullOrEmpty(tableName) Then
                RJMessageBox.Show("Nome tabella non impostato. Usa CaricaDGV(dgv, ""TableName"").")
                Return
            End If

            Dim ok As Boolean = DBSalva.Salva(DTGAprire)

            If ok Then
                ' Ricarica per riflettere eventuali valori calcolati/identity aggiornati
                CaricaDGV(DTGAprire, tableName)
            End If

            ColoraDgv(DTGAprire)

            If RJMessageBox.Show("Vuoi cancellare record vecchi nel file di log?", "Conferma",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question) = DialogResult.Yes Then

                LogLeggiScrivi.ClearLog() ' il numero è opzionale , da default elimina 5 gruppi

            End If

            FrameworkLogger.Log("Salvato la Tabella  -->  " & tableName)
            Dim leggiLog = RJMessageBox.Show(LogReader.ReadLog(), "Apro il file di log")

        Catch ex As Exception
            RJMessageBox.Show("Errore salvataggio: " & ex.Message)
        End Try

    End Sub

#End Region

#Region " COLORA COLONNE SU CLICK "

    Private Sub DTGAprire_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DTGAprire.CellContentClick

        ColoraDgv(DTGAprire)

    End Sub

#End Region

#Region " CHIUSURA FORM "

    Private Sub BtnFadeOut_Click(sender As Object, e As EventArgs) Handles BtnFadeOut.Click
        Close()
    End Sub

#End Region

End Class
