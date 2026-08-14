
'  Visualizza Clienti - Salva Modifiche
Imports System.Data.SqlClient
    Imports System.Configuration
    Imports CustomMessageBoxVB
    Imports WinItalPascal


    Public Class FemInsClienti
        ' Questi sono i campi privati per gestire i dati dei clienti e degli ordini
        ' in questo modo posso usare:
        '    dvClienti = New DataView(dtClienti)
        '    dtClienti = DB.FillDataTable("SELECT * FROM Clienti")

        Private dtOrdini As DataTable
        Private dvOrdini As DataView

        Private dtClienti As DataTable
        Private dvClienti As DataView

        Private dtView As DataView
        Private bsFatture As New BindingSource
        Private bsOrdini As New BindingSource
        Private bsClienti As New BindingSource
        ' REMOVED: Public Property ConfigurationManager As Object

        Private Sub FemInsClienti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            'TODO: questa riga di codice carica i dati nella tabella 'WinDBGdRDataSet.Ordini'. È possibile spostarla o rimuoverla se necessario.
            'Me.OrdiniTableAdapter.Fill(Me.WinDBGdRDataSet.Ordini)
            'TODO: questa riga di codice carica i dati nella tabella 'WinDBGdRDataSet.Clienti'. È possibile spostarla o rimuoverla se necessario.
            ' Me.ClientiTableAdapter.Fill(Me.WinDBGdRDataSet.Clienti)
            dvOrdini = New DataView(dtOrdini)
            dvClienti = New DataView(dtClienti)
            dtClienti = DB.FillDataTable("SELECT * FROM Clienti")
            dtOrdini = DB.FillDataTable("SELECT * FROM Ordini")

            CaricaDGV(ClientiDataGrid, "Select * from clienti")
            ImpColCli(ClientiDataGrid)
            CaricaDGV(OrdiniDataGrid, "Select * from ordini")
            ImpColOrd(OrdiniDataGrid)

            ScreenUtility.FullScreen(Me)
            FrmTitolo.CTitolo(Me, "Gesionale Clienti")
            ColoraDgv(OrdiniDataGrid, ClientiDataGrid)
            Dim imgSalva As Image = My.Resources.social_page

        End Sub


    #Region "Filtra Ordini del cliente"

        Private Sub ClientiDataGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ClientiDataGrid.CellClick
            If e.RowIndex < 0 Then Exit Sub
            ' If IdClienti Is Nothing Then Exit Sub
            Dim idCli As Integer =
                CInt(ClientiDataGrid.Rows(e.RowIndex).Cells("IDClienti").Value)
            ResetFiltro(OrdiniDataGrid)
            GridFilter.FiltraDgv(
                OrdiniDataGrid,
                $"IDCliOrd = {idCli}")
            ' Utilizzando il modulo ColoraGrid posso fare in questo modo
            ColoraDgv(OrdiniDataGrid, ClientiDataGrid)
            ' avevo fatto questa 
            'colDgv()
        End Sub


        ' Questo è stato inserito in Libreria
        'Private Sub FiltraDgv(
        'dgv As DataGridView,
        'filtro As String)

        '    Dim dv As DataView =
        '    DirectCast(dgv.DataSource, DataView)

        '    dv.RowFilter = filtro

        'End Sub
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

    #End Region



    #Region " Salva Clienti - Integrato con libreria DB"

        ' Helper: prende il valore della cella e lo trasforma in parametro (DBNull se vuoto)
        Private Function MakeParamFromCell(paramName As String, rowIndex As Integer, colIndex As Integer) As SqlParameter
            Dim cell = ClientiDataGrid.Rows(rowIndex).Cells(colIndex).Value
            Dim value As Object = If(cell Is Nothing OrElse IsDBNull(cell), DBNull.Value, cell)
            Return New SqlParameter(paramName, value)
        End Function

        Sub SalvaClienti()
            Try
                ' 1) Commit modifiche in corso sul DataGrid / BindingSource
                Me.Validate()
                If ClientiDataGrid.IsCurrentCellInEditMode Then ClientiDataGrid.EndEdit()
                ' Se esiste una BindingSource generata dal designer chiamata ClientiBindingSource la chiudiamo
                Try
                    Dim pi = Me.GetType().GetProperty("ClientiBindingSource")
                    If pi IsNot Nothing Then
                        Dim bs = TryCast(pi.GetValue(Me, Nothing), BindingSource)
                        bs?.EndEdit()
                    End If
                Catch
                    ' ignoriamo errori di riflessione
                End Try

                ' 2) Controllo che sia selezionata una riga
                If ClientiDataGrid.SelectedCells.Count = 0 Then
                    RJMessageBox.Show("Seleziona una riga o inserisci un nuovo record prima di salvare.")
                    Return
                End If

                Dim rigaCorrente As Integer = ClientiDataGrid.CurrentCell.RowIndex
                Dim cellId = ClientiDataGrid.Rows(rigaCorrente).Cells(0).Value
                Dim isUpdate As Boolean = (cellId IsNot Nothing AndAlso Not IsDBNull(cellId) AndAlso Not String.IsNullOrEmpty(cellId.ToString()))

                If isUpdate Then
    #Region "MODIFICA RECORD ESISTENTE"
                    Dim id As Integer = Convert.ToInt32(cellId)
                    Dim query As String = "UPDATE Clienti
                                             SET Cliente = @Cliente, 
                                                 Indirizzo = @Indirizzo, 
                                                 Citta = @Citta, 
                                                 Prov = @Prov, 
                                                 CAP = @CAP, 
                                                 Tel = @Tel,
                                                 P_IVA = @P_IVA
                                             WHERE IDClienti = @ID"
                    Dim pars As New List(Of SqlParameter) From {
                        MakeParamFromCell("@Cliente", rigaCorrente, 1),
                        MakeParamFromCell("@Indirizzo", rigaCorrente, 2),
                        MakeParamFromCell("@Citta", rigaCorrente, 3),
                        MakeParamFromCell("@Prov", rigaCorrente, 4),
                        MakeParamFromCell("@CAP", rigaCorrente, 5),
                        MakeParamFromCell("@Tel", rigaCorrente, 6),
                        MakeParamFromCell("@P_IVA", rigaCorrente, 7),
                        New SqlParameter("@ID", id)
                    }

                    DB.ExecuteNonQuery(query, pars)
                    RJMessageBox.Show("Record modificato con successo!")
    #End Region
                Else
    #Region "NUOVO INSERIMENTO"
                    ' Recupera ultimo ID usando FillDataTable dalla libreria DB
                    Dim dtId As DataTable = DB.FillDataTable("SELECT ISNULL(MAX(IDClienti), 0) AS MaxID FROM Clienti")
                    Dim ultimoID As Integer = 0
                    If dtId IsNot Nothing AndAlso dtId.Rows.Count > 0 Then
                        ultimoID = Convert.ToInt32(dtId.Rows(0)("MaxID"))
                    End If

                    Dim nuovoID As Integer = ultimoID + 1

                    Dim queryInsert As String = "INSERT INTO Clienti (IDClienti, Cliente, Indirizzo, Citta, Prov, CAP, Tel, P_IVA) 
                                                   VALUES (@IDClienti, @Cliente, @Indirizzo, @Citta, @Prov, @CAP, @Tel, @P_IVA);"

                    Dim parsInsert As New List(Of SqlParameter) From {
                        New SqlParameter("@IDClienti", nuovoID),
                        MakeParamFromCell("@Cliente", rigaCorrente, 1),
                        MakeParamFromCell("@Indirizzo", rigaCorrente, 2),
                        MakeParamFromCell("@Citta", rigaCorrente, 3),
                        MakeParamFromCell("@Prov", rigaCorrente, 4),
                        MakeParamFromCell("@CAP", rigaCorrente, 5),
                        MakeParamFromCell("@Tel", rigaCorrente, 6),
                        MakeParamFromCell("@P_IVA", rigaCorrente, 7)
                    }

                    DB.ExecuteNonQuery(queryInsert, parsInsert)

                    ' Aggiorna la cella ID nel DataGridView con il nuovo ID calcolato
                    ClientiDataGrid.Rows(rigaCorrente).Cells(0).Value = nuovoID

                    RJMessageBox.Show("Nuovo record inserito con successo!")
    #End Region
                End If

            Catch ex As Exception
                RJMessageBox.Show("Errore: " & ex.Message)
            End Try
        End Sub

    #End Region

    #Region "Imposta colonne"

        Sub ImpColCli(ByRef dgv As DataGridView)

            ' Imposta il font generale per tutto il DataGridView
            dgv.Font = New Font("Segoe UI", 10, FontStyle.Regular)

            ' Imposta il font per l'header delle colonne
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            dgv.Columns(0).Width = 100
            dgv.Columns(0).HeaderText = "ID Clienti"
            dgv.Columns(1).Width = 300
            dgv.Columns(2).Width = 300
            dgv.Columns(3).Width = 250
            'dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            'dgv.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgv.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgv.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgv.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End Sub


        ' Alternativa Ordini
        Sub ImpColOrd(ByRef dgv As DataGridView)    ' ODataGrid
            ' Imposta il font generale per tutto il DataGridView
            dgv.Font = New Font("Segoe UI", 10, FontStyle.Regular)

            ' Imposta il font per l'header delle colonne
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            dgv.Columns(0).Width = 50
            dgv.Columns(0).HeaderText = "ID Ord"
            dgv.Columns(1).Width = 50
            dgv.Columns(2).Width = 100
            dgv.Columns(3).Width = 300
            dgv.Columns(4).Width = 260
            dgv.Columns(5).Width = 280
            dgv.Columns(6).Width = 80
            dgv.Columns(7).Width = 80

        End Sub

    #End Region



        Private Sub RjCircSalva_Click(sender As Object, e As EventArgs) Handles RjCircSalva.Click

            Try
                ' Assicuriamoci che gli edit siano terminati prima del salvataggio
                Me.Validate()
                If ClientiDataGrid.IsCurrentCellInEditMode Then ClientiDataGrid.EndEdit()
                Try
                    Dim pi = Me.GetType().GetProperty("ClientiBindingSource")
                    If pi IsNot Nothing Then
                        Dim bs = TryCast(pi.GetValue(Me, Nothing), BindingSource)
                        bs?.EndEdit()
                    End If
                Catch
                End Try

                GridUtility.ConvertiMaiuscolo(ClientiDataGrid)

                SalvaClienti()
                ' Questi sono stati eliminati
                ''Me.ClientiBindingSource.EndEdit()
                ''Me.TableAdapterManager.UpdateAll(Me.WinDBGdRDataSet)

                ' Specifiche delle modifiche scritte nel file di Log
                Dim Utente As String = If(ClientiDataGrid.CurrentRow.Cells(1).Value IsNot Nothing, ClientiDataGrid.CurrentRow.Cells(1).Value.ToString(), String.Empty)
                Dim Id As String = If(ClientiDataGrid.CurrentRow.Cells(0).Value IsNot Nothing, ClientiDataGrid.CurrentRow.Cells(0).Value.ToString(), String.Empty)
                LogLeggiScrivi.ScriviLogMsg($"Cliente con Id {Id} " & "a nome di " & $"{Utente}" & " salvato correttamente")

                'LogLeggiScrivi.ScriviLogMsg($"Salvato {ClientiDataGrid.Rows.Count } record")
                If RJMessageBox.Show("Vuoi cancellare record vecchi nel file di log?", "Conferma",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) = DialogResult.Yes Then

                    LogLeggiScrivi.ClearLog(1) ' il numero è opzionale , da default elimina 5 gruppi

                End If
                ' Per leggere Avviso corto va bene
                Dim leggiLog = RJMessageBox.Show(LogReader.ReadLog(), "Apro il file di log")
            Catch ex As Exception
                LogLeggiScrivi.ScriviLog("File Log", ex)   ' con nuovo file di Log
                FrameworkLogger.LogError(ex, "SALVA Clienti") ' Alternativa
                RJMessageBox.Show(
                "ERRORE SALVATAGGIO: " & ex.Message,
                "Errore",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
            End Try
            ' coloro i datagrid 
            ColoraDgv(OrdiniDataGrid, ClientiDataGrid)
        End Sub

    #Region "Controllo inserimento corretto"

        'Private Function VerificaDatiClienti() As Boolean

        '    For Each r As DataGridViewRow In ClientiDataGrid.Rows
        '        If Not r.IsNewRow Then

        '            ' --- Controllo CAP (colonna 5) ---
        '            Dim cap As String = Convert.ToString(r.Cells(5).Value).Trim()

        '            If cap.Length <> 5 OrElse Not cap.All(AddressOf Char.IsDigit) Then

        '                RJMessageBox.Show("Errore: il CAP deve contenere 5 cifre numeriche." &
        '                   vbCrLf & "Riga: " & r.Index + 1, "Errore inserimento",
        '                MessageBoxButtons.OK, MessageBoxIcon.Error)

        '                Return False
        '            End If

        '            ' --- Controllo P_IVA (colonna 7) ---
        '            Dim piva As String = Convert.ToString(r.Cells(7).Value).Trim()

        '            If piva = "" Then

        '                RJMessageBox.Show("Errore: il campo P.IVA / Codice Fiscale non può essere vuoto." &
        '                   vbCrLf & "Riga: " & r.Index + 1, "Errore inserimento",
        '                MessageBoxButtons.OK, MessageBoxIcon.Error)

        '                Return False
        '            End If

        '            ' SOLO NUMERI → deve essere lungo 11
        '            If piva.All(AddressOf Char.IsDigit) Then
        '                If piva.Length <> 11 Then

        '                    RJMessageBox.Show("Errore: la Partita IVA deve contenere esattamente 11 cifre numeriche" &
        '                   vbCrLf & "Riga: " & r.Index + 1, "Errore inserimento",
        '                MessageBoxButtons.OK, MessageBoxIcon.Error)

        '                    Return False
        '                End If

        '                ' LETTERE + NUMERI → deve essere lungo 16
        '            ElseIf piva.Any(AddressOf Char.IsLetter) Then
        '                If piva.Length <> 16 Then
        '                    RJMessageBox.Show("Errore: il Codice Fiscale deve contenere esattamente 16 caratteri alfanumerici.  " &
        '                   vbCrLf & "Riga: " & r.Index + 1, "Errore inserimento",
        '                MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                    Return False
        '                End If

        '                ' Caso non valido (caratteri strani)
        '            Else

        '                RJMessageBox.Show("Errore: il campo P.IVA / Codice Fiscale contiene caratteri non validi.  " &
        '                   vbCrLf & "Riga: " & r.Index + 1, "Errore inserimento",
        '                MessageBoxButtons.OK, MessageBoxIcon.Error)

        '                Return False
        '            End If

        '        End If
        '    Next

        '    Return True
        'End Function

    #End Region


        Private Sub RjBtnLog_Click(sender As Object, e As EventArgs) Handles RjBtnLog.Click
            ' Per leggere Avviso corto va bene
            Dim leggiLog = RJMessageBox.Show(LogReader.ReadLog(), "Apro il file di log")
        End Sub

        Private Sub TxtCerca_TextChanged(sender As Object, e As EventArgs) Handles TxtCerca.TextChanged

            GridUtility.FiltraTutti(ClientiDataGrid, dtClienti, TxtCerca.Text)
            GridUtility.EvidenziaTesto(ClientiDataGrid, TxtCerca.Text)

            If TxtCerca.Text = "" Then
                ColoraDgv(OrdiniDataGrid, ClientiDataGrid)
            End If
        End Sub

        Private Sub RjCircularPictureBox1_Click(sender As Object, e As EventArgs) Handles RjCircularPictureBox1.Click
            TxtCerca.Text = ""
            ColoraDgv(OrdiniDataGrid, ClientiDataGrid)
        End Sub


End Class