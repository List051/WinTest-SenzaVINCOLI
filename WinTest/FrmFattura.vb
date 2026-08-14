
Imports System.Data.SqlClient
Imports WinItalPascal
Imports CustomMessageBoxVB


Public Class FrmFattura

    ' per tabella Fattura
    Private dtFattura As New DataTable
    Private dvFattura As New DataView


    Private Sub FrmFattura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FrmTitolo.CTitolo(Me, "Gestione completa - Solo WinItalPascal")

#Region "Apre la tabella Fattura"

        Dim FQryT As String = "SELECT * FROM Fattura"
        dvFattura = New DataView(dtFattura)
        dtFattura = DB.FillDataTable("SELECT * FROM Fattura")

        DataGVLoad.ApriDGV(FDataGrid, FQryT)

        ImpColFat(FDataGrid)
        ' coloro i datagrid 
        ColoraDgv(FDataGrid)

#End Region

    End Sub

#Region "Salva Fattura"
    Private Sub RjCircSalvaFattura_Click(sender As Object, e As EventArgs) Handles RjCircSalvaFattura.Click
        GridUtility.ConvertiMaiuscolo(FDataGrid)

        Try
            ' Ciclo tutte le righe del DataGrid
            For Each row As DataGridViewRow In FDataGrid.Rows
                If row.IsNewRow Then Continue For

                ' Leggo i valori della riga
                Dim IDCli As Integer = CInt(row.Cells("IDCli").Value)
                Dim IDOrd As Integer = CInt(row.Cells("IDOrd").Value)
                Dim Num As Integer = CInt(row.Cells("Num").Value)
                Dim DataFat As Date = CDate(row.Cells("DataFat").Value)
                Dim NomeFat As String = CStr(row.Cells("NomeFat").Value)
                Dim Mat As String = CStr(row.Cells("Mat").Value)
                Dim Qta As Integer = CInt(row.Cells("Qta").Value)
                Dim Prezzo As Decimal = CDec(row.Cells("Prezzo").Value)
                Dim Importo As Decimal = CDec(row.Cells("Importo").Value)

                ' Imposto automaticamente i campi richiesti
                Dim Pagato As String = "Attesa"
                Dim DataFutura As Date = Date.Today.AddDays(30)

                ' Se IDFat è NULL → INSERT
                If row.Cells("IDFat").Value Is Nothing OrElse IsDBNull(row.Cells("IDFat").Value) Then

                    Dim sqlInsert As String =
                    "INSERT INTO dbo.Fattura
                    (IDCli, IDOrd, Num, DataFat, NomeFat, Mat, Qta, Prezzo, Importo, Pagato)
                    VALUES
                    (@IDCli, @IDOrd, @Num, @DataFat, @NomeFat, @Mat, @Qta, @Prezzo, @Importo, @Pagato)"

                    Dim p As New List(Of SqlParameter) From {
                    New SqlParameter("@IDCli", IDCli),
                    New SqlParameter("@IDOrd", IDOrd),
                    New SqlParameter("@Num", Num),
                    New SqlParameter("@DataFat", DataFat),
                    New SqlParameter("@NomeFat", NomeFat),
                    New SqlParameter("@Mat", Mat),
                    New SqlParameter("@Qta", Qta),
                    New SqlParameter("@Prezzo", Prezzo),
                    New SqlParameter("@Importo", Importo),
                    New SqlParameter("@Pagato", Pagato)
                }

                    DB.ExecuteNonQuery(sqlInsert, p)

                Else
                    ' UPDATE se IDFat esiste
                    Dim IDFat As Integer = CInt(row.Cells("IDFat").Value)

                    Dim sqlUpdate As String =
                    "UPDATE dbo.Fattura SET
                        IDCli = @IDCli,
                        IDOrd = @IDOrd,
                        Num = @Num,
                        DataFat = @DataFat,
                        NomeFat = @NomeFat,
                        Mat = @Mat,
                        Qta = @Qta,
                        Prezzo = @Prezzo,
                        Importo = @Importo,
                        Pagato = @Pagato
                    WHERE IDFat = @IDFat"

                    Dim p As New List(Of SqlParameter) From {
                    New SqlParameter("@IDCli", IDCli),
                    New SqlParameter("@IDOrd", IDOrd),
                    New SqlParameter("@Num", Num),
                    New SqlParameter("@DataFat", DataFat),
                    New SqlParameter("@NomeFat", NomeFat),
                    New SqlParameter("@Mat", Mat),
                    New SqlParameter("@Qta", Qta),
                    New SqlParameter("@Prezzo", Prezzo),
                    New SqlParameter("@Importo", Importo),
                    New SqlParameter("@Pagato", Pagato),
                    New SqlParameter("@IDFat", IDFat)
                }

                    DB.ExecuteNonQuery(sqlUpdate, p)
                End If
            Next


            ' Specifiche delle modifiche scritte nel file di Log
            Dim Utente As String = If(FDataGrid.CurrentRow.Cells(5).Value IsNot Nothing, FDataGrid.CurrentRow.Cells(5).Value.ToString(), String.Empty)
            Dim Id As String = If(FDataGrid.CurrentRow.Cells(0).Value IsNot Nothing, FDataGrid.CurrentRow.Cells(0).Value.ToString(), String.Empty)
            LogLeggiScrivi.ScriviLogMsg($"Fattura del Cliente con Id {Id} " & "a nome di " & $"{Utente}" & " salvato correttamente")

            RJMessageBox.Show("Fatture salvate correttamente.", "Salvataggio")

            If RJMessageBox.Show("Vuoi cancellare record vecchi nel file di log?", "Conferma",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question) = DialogResult.Yes Then

                LogLeggiScrivi.ClearLog() ' il numero è opzionale , da default elimina 5 gruppi

            End If
            ' Mostro log
            Dim leggiLog = RJMessageBox.Show(LogReader.ReadLog(), "Apro il file di log")

        Catch ex As Exception
            LogLeggiScrivi.ScriviLog("File Log", ex)
            FrameworkLogger.LogError(ex, "SALVA Fattura")
            RJMessageBox.Show("ERRORE SALVATAGGIO: " & ex.Message,
                          "Errore",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
        End Try

        ' Colora il DataGrid
        ColoraDgv(FDataGrid)
    End Sub
#End Region


#Region "Funzione Log - Cerca Evidenziata"


    Private Sub RjBtnLog_Click(sender As Object, e As EventArgs) Handles RjBtnLog.Click
        ' Per leggere Avviso corto va bene
        Dim leggiLog = RJMessageBox.Show(LogReader.ReadLog(), "Apro il file di log")
    End Sub

    Private Sub TxtCerca_TextChanged(sender As Object, e As EventArgs) Handles TxtCerca.TextChanged

        GridUtility.FiltraTutti(FDataGrid, dtFattura, TxtCerca.Text)
        GridUtility.EvidenziaTesto(FDataGrid, TxtCerca.Text)

        If TxtCerca.Text = "" Then
            ColoraDgv(FDataGrid)
        End If

    End Sub

#End Region

#Region "Imposta colonne del FDataGrid"

    ' Alternativa Fattura
    Sub ImpColFat(ByRef dgv As DataGridView)    ' FDataGrid

        ' Font generale
        dgv.Font = New Font("Segoe UI", 10, FontStyle.Regular)

        ' Header colonne: font + colori
        With dgv.ColumnHeadersDefaultCellStyle
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .BackColor = Color.LightBlue      ' <-- colore sfondo header
            .ForeColor = Color.DarkBlue       ' <-- colore testo header
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' Per vedere il colore dell’header serve questo:
        dgv.EnableHeadersVisualStyles = False

        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        dgv.Columns(0).Width = 50
        dgv.Columns(0).HeaderText = "ID Fat"
        dgv.Columns(1).Width = 50
        dgv.Columns(1).HeaderText = "ID Cli"
        dgv.Columns(2).Width = 50
        dgv.Columns(2).HeaderText = "ID Ord"
        dgv.Columns(3).Width = 50
        dgv.Columns(3).HeaderText = "N. Fat"
        dgv.Columns(4).Width = 100
        dgv.Columns(4).HeaderText = "Data Fattura"
        dgv.Columns(5).Width = 310
        dgv.Columns(5).HeaderText = "Cliente"
        dgv.Columns(6).Width = 340
        dgv.Columns(6).HeaderText = "Materiale"
        dgv.Columns(7).Width = 50
        dgv.Columns(7).HeaderText = "Qta"
        dgv.Columns(8).Width = 80
        dgv.Columns(8).HeaderText = "Prezzo"
        dgv.Columns(9).Width = 80
        dgv.Columns(9).Tag = "N2"               ' utlizzo AutoFormatForm inserito in libreria
        dgv.Columns(9).HeaderText = "Impoto"
        dgv.Columns(10).Width = 80
        dgv.Columns(10).HeaderText = "Pagato"

        GridUtility.AutoFormat(Me)          ' Aggiunto nella mia libreria - Controlla i Tag in Proprietà

    End Sub


#End Region


End Class