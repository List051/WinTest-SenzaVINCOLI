

Imports System.Data.SqlClient
Imports System.Configuration
Imports CustomMessageBoxVB
Imports WinItalPascal

Public Class FrmCliOrd

    'Private dvOrdini As DataView
    Private DgClienti As DataGridView
    Private dgvOrd As DataGridView

    Private dtView As DataTable
    Private dtOrd As DataTable

    Private dtOrdini As DataTable
    Private dvOrdini As DataView

    Private dtClienti As DataTable
    Private dvClienti As DataView

    Private bsOrdini As New BindingSource
    Private bsClienti As New BindingSource


#Region " FORM LOAD "

    Private Sub FrmCliOrd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ScreenUtility.FullScreen(Me)
        FrmTitolo.CTitolo(Me, "Gestione Clienti - Secondo me + semplice ;)")

        DgClienti = ClientiDataGrid

        DgClienti.DataSource = DB.FillDataTable("SELECT * FROM Clienti")

        dgvOrd = OrdiniDataGrid
        dgvOrd.DataSource = DB.FillDataTable("SELECT * FROM Ordini")

        '' Aggiungi l'handler per l'evento SelectionChanged
        'AddHandler ClientiDataGrid.SelectionChanged, AddressOf ClientiDataGrid_SelectionChanged

        '' Imposta la DataView per OrdiniDataGrid
        'Dim dtOrdini As DataTable = CType(OrdiniDataGrid.DataSource, DataTable)
        'dvOrdini = New DataView(dtOrdini)
        ''***
        '' Imposta la DataView come DataSource per OrdiniDataGrid
        'OrdiniDataGrid.DataSource = dvOrdini
        dtOrdini = DB.FillDataTable("SELECT * FROM Ordini")
        dtClienti = DB.FillDataTable("SELECT * FROM Clienti")

        dvOrdini = New DataView(dtOrdini)
        dvClienti = New DataView(dtClienti)

        ' BIND UNA SOLA VOLTA       
        OrdiniDataGrid.DataSource = dvOrdini
        ClientiDataGrid.DataSource = dvClienti

        dtClienti = DB.FillDataTable("SELECT * FROM Clienti")


        ColoraDgv(ClientiDataGrid, OrdiniDataGrid)
        ' GridUtility.ColoraColonne(DgClienti, Colori.ColoreTipo.Giallo, Colori.ColoreTipo.VerdeChiaro, Colori.ColoreTipo.Azzurro)

        '  GridUtility.ColoraColonne(dgvOrd, Colori.ColoreTipo.Giallo, Colori.ColoreTipo.VerdeChiaro, Colori.ColoreTipo.Azzurro)

        ' Aggiungo Popup ai Btn
        Dim imgAggiorna As Image = My.Resources.add
        Dim imgAggClienti As Image = My.Resources.confTel
        Dim imgAggElenco As Image = My.Resources.cheque

        PopupHelper.AttachPopup(RjAggiorna, vbCrLf & "Aggiorna dati" & vbCrLf & "Salva i dati modificati nella cella", imgAggiorna, Color.Aquamarine, Color.Blue)
        PopupHelper.AttachPopup(RjAggClienti, vbCrLf & "Aggiungi cliente" & vbCrLf & "Inserisci un Nuovo Cliente", imgAggClienti, Color.Aquamarine, Color.Blue)
        PopupHelper.AttachPopup(RjBtnAggElenco, vbCrLf & "Ricarica elenco" & vbCrLf & "Aggiorna intera giglia Clienti", imgAggElenco, Color.Aquamarine, Color.Blue)
    End Sub

#End Region

#Region " EVENTI "


    Private Sub ClientiDataGrid_SelectionChanged(sender As Object, e As DataGridViewCellEventArgs) Handles ClientiDataGrid.CellClick

        Try
            '  id della tabella Clienti dalla riga selezionata
            If e.RowIndex < 0 Then Exit Sub

            ' Tabella Clienti ho IdClienti  -  Tabella Ordini ho IDCliOrd
            Dim idCli As Integer = CInt(ClientiDataGrid.Rows(e.RowIndex).Cells("IdClienti").Value)
            ResetFiltro(OrdiniDataGrid)
            GridFilter.FiltraDgv(OrdiniDataGrid, $"IDCliOrd = {idCli}")

            'ClientiDataGrid.CurrentRow IsNot Nothing Then
            '    Dim idCliente As Integer = Convert.ToInt32(ClientiDataGrid.CurrentRow.Cells("IDClienti").Value)
            '    ' Filtra la DataView per mostrare solo gli ordini del cliente selezionato
            '    dvOrdini.RowFilter = $"IDCliOrd = {idCliente}"

            'Else
            '    ' Se non c'è una riga selezionata, mostra tutti gli ordini
            '    dvOrdini.RowFilter = String.Empty
            'End If

            ColoraDgv(ClientiDataGrid, OrdiniDataGrid)
            ' GridUtility.ColoraColonne(DgClienti, Colori.ColoreTipo.Giallo, Colori.ColoreTipo.VerdeChiaro, Colori.ColoreTipo.Azzurro)

            '  GridUtility.ColoraColonne(dgvOrd, Colori.ColoreTipo.Giallo, Colori.ColoreTipo.VerdeChiaro, Colori.ColoreTipo.Azzurro)
        Catch ex As Exception
            FrameworkLogger.LogError(ex, "File Log Errori")
            RJMessageBox.Show("Errore durante il caricamento del form: " & ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region


#Region "Filtra clienti - Ordini"


    Private Sub ResetFiltro(dgv As DataGridView)
        Dim dv As DataView = Nothing

        If TypeOf dgv.DataSource Is BindingSource Then
            Dim bs = DirectCast(dgv.DataSource, BindingSource)
            If bs.List IsNot Nothing AndAlso TypeOf bs.List Is DataView Then
                dv = DirectCast(bs.List, DataView)
            ElseIf TypeOf bs.DataSource Is DataTable Then
                dv = DirectCast(DirectCast(bs.DataSource, DataTable).DefaultView, DataView)
            End If
        ElseIf TypeOf dgv.DataSource Is DataView Then
            dv = DirectCast(dgv.DataSource, DataView)
        ElseIf TypeOf dgv.DataSource Is DataTable Then
            dv = DirectCast(DirectCast(dgv.DataSource, DataTable).DefaultView, DataView)
        End If

        If dv IsNot Nothing Then dv.RowFilter = String.Empty
    End Sub

    Private Sub FiltraDgv(
    dgv As DataGridView,
    filtro As String)

        Dim dv As DataView =
        DirectCast(dgv.DataSource, DataView)

        dv.RowFilter = filtro

    End Sub

#End Region



#Region " FUNZIONI "


    Private Sub RjAggiorna_Click(sender As Object, e As EventArgs) Handles RjAggiorna.Click
        Try

            AggiornaDati()
            ' Aggiorna i dati da database
            ''DgClienti.DataSource = DB.FillDataTable("SELECT * FROM Clienti")
            ''dgvOrd.DataSource = DB.FillDataTable("SELECT * FROM Ordini")


            dtOrdini = DB.FillDataTable("SELECT * FROM Ordini")
            dtClienti = DB.FillDataTable("SELECT * FROM Clienti")

            ColoraDgv(ClientiDataGrid, OrdiniDataGrid)
            ' GridUtility.ColoraColonne(DgClienti, Colori.ColoreTipo.Giallo, Colori.ColoreTipo.VerdeChiaro, Colori.ColoreTipo.Azzurro)
            '  GridUtility.ColoraColonne(dgvOrd, Colori.ColoreTipo.Giallo, Colori.ColoreTipo.VerdeChiaro, Colori.ColoreTipo.Azzurro)
        Catch ex As Exception
            FrameworkLogger.LogError(ex, "File Log Errori")
            RJMessageBox.Show("Errore durante il caricamento del form: " & ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AggiornaDati()

        GridUtility.ConvertiMaiuscolo(ClientiDataGrid)
        Try
            ' Assicura che l'edit corrente sia committato
            If ClientiDataGrid.IsCurrentCellInEditMode Then ClientiDataGrid.EndEdit()
            If TypeOf ClientiDataGrid.DataSource Is BindingSource Then
                DirectCast(ClientiDataGrid.DataSource, BindingSource).EndEdit()
            End If
            Dim cm = TryCast(Me.BindingContext(ClientiDataGrid.DataSource), CurrencyManager)
            cm?.EndCurrentEdit()

            ' Recupera il DataTable in modo sicuro
            Dim dt As DataTable = Nothing
            If TypeOf ClientiDataGrid.DataSource Is DataTable Then
                dt = DirectCast(ClientiDataGrid.DataSource, DataTable)
            ElseIf TypeOf ClientiDataGrid.DataSource Is DataView Then
                dt = DirectCast(ClientiDataGrid.DataSource, DataView).Table
            ElseIf TypeOf ClientiDataGrid.DataSource Is BindingSource Then
                Dim bs = DirectCast(ClientiDataGrid.DataSource, BindingSource)
                If TypeOf bs.DataSource Is DataTable Then
                    dt = DirectCast(bs.DataSource, DataTable)
                ElseIf TypeOf bs.List Is DataView Then
                    dt = DirectCast(bs.List, DataView).Table
                End If
            End If

            If dt Is Nothing Then
                RJMessageBox.Show("Impossibile ottenere il DataTable dalla griglia.")
                Return
            End If

            ' Trova colonne con nome Id (case-insensitive)
            Dim idColName As String = dt.Columns.Cast(Of DataColumn)().
            Select(Function(c) c.ColumnName).
            FirstOrDefault(Function(n) String.Equals(n, "IdClienti", StringComparison.OrdinalIgnoreCase) OrElse String.Equals(n, "IDClienti", StringComparison.OrdinalIgnoreCase))
            If String.IsNullOrEmpty(idColName) Then
                RJMessageBox.Show("Colonna IDClienti non trovata nel DataTable.")
                Return
            End If

            ' Prendi solo le righe modificate
            Dim changed As DataTable = dt.GetChanges(DataRowState.Modified)
            If changed Is Nothing OrElse changed.Rows.Count = 0 Then
                RJMessageBox.Show("Nessuna modifica da salvare.")
                Return
            End If

            Dim modificate As Integer = 0
            Dim sb As New System.Text.StringBuilder()

            For Each row As DataRow In changed.Rows
                ' Logging diagnostico
                Dim idVal = If(row.IsNull(idColName), Nothing, row(idColName))
                sb.AppendLine("ID: " & If(idVal IsNot Nothing, idVal.ToString(), "<null>"))

                ' Costruisci i parametri gestendo DBNull
                Dim sql As String =
                "UPDATE Clienti SET " &
                "Cliente=@Cliente, Indirizzo=@Indirizzo, Citta=@Citta, Prov=@Prov, CAP=@CAP, Tel=@Tel, P_IVA=@P_IVA " &
                $"WHERE {idColName}=@IdClienti"

                Dim params As New List(Of SqlParameter)
                Dim getVal = Function(col As String) As Object
                                 If Not row.Table.Columns.Contains(col) Then Return DBNull.Value
                                 If row.IsNull(col) Then Return DBNull.Value
                                 Return row(col)
                             End Function

                params.Add(New SqlParameter("@Cliente", getVal("Cliente")))
                params.Add(New SqlParameter("@Indirizzo", getVal("Indirizzo")))
                params.Add(New SqlParameter("@Citta", getVal("Citta")))
                params.Add(New SqlParameter("@Prov", getVal("Prov")))
                params.Add(New SqlParameter("@CAP", getVal("CAP")))
                params.Add(New SqlParameter("@Tel", getVal("Tel")))
                params.Add(New SqlParameter("@P_IVA", getVal("P_IVA")))
                params.Add(New SqlParameter("@IdClienti", getVal(idColName)))

                ' Esegui l'update tramite la tua libreria
                DB.ExecuteNonQuery(sql, params)

                ' Dettaglio modifiche ( confronto Original vs Current se disponibili )
                For Each col As DataColumn In dt.Columns
                    Dim orig As String = String.Empty
                    Try
                        If row.Table.Columns.Contains(col.ColumnName) AndAlso row.RowState <> DataRowState.Added Then
                            orig = If(row.IsNull(col.ColumnName), String.Empty, row(col.ColumnName, DataRowVersion.Original).ToString())
                        End If
                    Catch
                    End Try
                    Dim curr = If(row.IsNull(col.ColumnName), String.Empty, row(col.ColumnName, DataRowVersion.Current).ToString())
                    If orig <> curr Then
                        sb.AppendLine(col.ColumnName & ": " & orig & " → " & curr)
                    End If
                Next

                sb.AppendLine("---------------------")
                modificate += 1
            Next

            FrameworkLogger.Log("Righe modificate: " & modificate & vbCrLf & sb.ToString())

        Catch ex As Exception
            FrameworkLogger.LogError(ex, "AggiornaDati")
            RJMessageBox.Show("Errore durante il salvataggio: " & ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''Sub AggiornaDati()

    ''    Try

    ''        DgClienti.EndEdit()
    ''        BindingContext(DgClienti.DataSource).EndCurrentEdit()

    ''        Dim dt As DataTable = CType(DgClienti.DataSource, DataTable)

    ''        Dim modificate As Integer = 0
    ''        Dim sb As New System.Text.StringBuilder()

    ''        For Each row As DataRow In dt.Rows
    ''            If row.RowState = DataRowState.Modified Then
    ''                modificate += 1
    ''            End If
    ''        Next

    ''        For Each row As DataRow In dt.Rows

    ''            If row.RowState = DataRowState.Modified Then

    ''                sb.AppendLine("ID: " & row("IdClienti").ToString())

    ''                ' UPDATE DB
    ''                Dim sql As String =
    ''                "UPDATE Clienti SET " &
    ''                "Cliente=@Cliente, " &
    ''                "Indirizzo=@Indirizzo, " &
    ''                "Citta=@Citta, " &
    ''                "Prov=@Prov, " &
    ''                "CAP=@CAP, " &
    ''                "Tel=@Tel, " &
    ''                "P_IVA=@P_IVA " &
    ''                "WHERE IdClienti=@IdClienti"

    ''                Dim params As New List(Of SqlParameter)

    ''                params.Add(New SqlParameter("@Cliente", row("Cliente")))
    ''                params.Add(New SqlParameter("@Indirizzo", row("Indirizzo")))
    ''                params.Add(New SqlParameter("@Citta", row("Citta")))
    ''                params.Add(New SqlParameter("@Prov", row("Prov")))
    ''                params.Add(New SqlParameter("@CAP", row("CAP")))
    ''                params.Add(New SqlParameter("@Tel", row("Tel")))
    ''                params.Add(New SqlParameter("@P_IVA", row("P_IVA")))
    ''                params.Add(New SqlParameter("@IdClienti", row("IdClienti")))

    ''                DB.ExecuteNonQuery(sql, params)

    ''                ' DETTAGLIO MODIFICHE
    ''                For Each col As DataColumn In dt.Columns

    ''                    If row(col.ColumnName, DataRowVersion.Original).ToString() <>
    ''                   row(col.ColumnName, DataRowVersion.Current).ToString() Then

    ''                        sb.AppendLine(
    ''                        col.ColumnName & ": " &
    ''                        row(col.ColumnName, DataRowVersion.Original).ToString() &
    ''                        " → " &
    ''                        row(col.ColumnName, DataRowVersion.Current).ToString()
    ''                    )

    ''                    End If

    ''                Next

    ''                sb.AppendLine("---------------------")

    ''            End If
    ''        Next
    ''        FrameworkLogger.Log("Aggiunta del rigo modificato" & modificate & vbCrLf & vbCrLf & sb.ToString())
    ''        RJMessageBox.Show(
    ''        "Righe modificate: " & modificate & vbCrLf & vbCrLf & sb.ToString(),
    ''        "Aggiornamento Clienti"
    ''    )

    ''    Catch ex As Exception
    ''        FrameworkLogger.LogError(ex, "File Log Errori")
    ''        RJMessageBox.Show(
    ''        "Errore durante il salvataggio: " & ex.Message,
    ''        "Errore",
    ''        MessageBoxButtons.OK,
    ''        MessageBoxIcon.Error
    ''    )
    ''    End Try

    ''End Sub

#End Region

#Region " CLICK BUTTON "

    Private Sub RjAggClienti_Click(sender As Object, e As EventArgs) Handles RjAggClienti.Click
        ' FrmInsCliente.ShowDialog()
    End Sub

    Private Sub RjBtnAggElenco_Click(sender As Object, e As EventArgs) Handles RjBtnAggElenco.Click
        DgClienti = ClientiDataGrid

        DgClienti.DataSource = DB.FillDataTable("SELECT * FROM Clienti")
        ColoraDgv(ClientiDataGrid)
        ' GridUtility.ColoraColonne(DgClienti, Colori.ColoreTipo.Giallo, Colori.ColoreTipo.VerdeChiaro, Colori.ColoreTipo.Azzurro)

    End Sub

    Private Sub RjLeggiLog_Click(sender As Object, e As EventArgs) Handles RjLeggiLog.Click
        RJMessageBox.Show(LogReader.ReadLog(), "Funzione di lettura del log")
    End Sub

    Private Sub RjCircSpostaFrm_Click(sender As Object, e As EventArgs) Handles RjCircSpostaFrm.Click
        '  FrmSposta.Show()
    End Sub

    Private Sub RjCircFrmAprire_Click(sender As Object, e As EventArgs) Handles RjCircFrmAprire.Click
        FrmAprire.Show()
    End Sub
#End Region

End Class