' doppio vedi DBSalvaTabelle

'Imports System.Data.SqlClient
'Imports System.Data
'Imports System.Configuration

'Public Class DBSalvaTabelle

'    Private ReadOnly _connString As String

'    Public Sub New()
'        _connString = ConfigurationManager.ConnectionStrings("MiaConnessione").ConnectionString
'    End Sub

'    '===========================================================
'    ' 1) RILEVAMENTO AUTOMATICO DELLA PRIMARY KEY
'    '===========================================================
'    Public Function GetPrimaryKey(tableName As String) As String()

'        Const sql As String =
'            "SELECT KU.COLUMN_NAME
'             FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC
'             INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KU
'                 ON TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
'             WHERE TC.TABLE_NAME = @tab
'               AND TC.CONSTRAINT_TYPE = 'PRIMARY KEY'
'             ORDER BY KU.ORDINAL_POSITION"

'        Dim pkList As New List(Of String)

'        Using cn As New SqlConnection(_connString)
'            Using cmd As New SqlCommand(sql, cn)
'                cmd.Parameters.AddWithValue("@tab", tableName)
'                cn.Open()

'                Using rd = cmd.ExecuteReader()
'                    While rd.Read()
'                        pkList.Add(rd.GetString(0))
'                    End While
'                End Using
'            End Using
'        End Using

'        Return pkList.ToArray()
'    End Function

'    '===========================================================
'    ' 2) IMPOSTA LA PK NEL DATATABLE
'    '===========================================================
'    Public Sub ImpostaPKNelDataTable(dt As DataTable, tableName As String)

'        Dim pkNames = GetPrimaryKey(tableName)

'        If pkNames.Length = 0 Then
'            MsgBox("ATTENZIONE: La tabella '" & tableName & "' non ha una Primary Key.")
'            Exit Sub
'        End If

'        Dim pkCols As New List(Of DataColumn)

'        For Each pk In pkNames
'            If dt.Columns.Contains(pk) Then
'                pkCols.Add(dt.Columns(pk))
'            Else
'                MsgBox("ATTENZIONE: La colonna PK '" & pk & "' non esiste nel DataTable.")
'            End If
'        Next

'        If pkCols.Count > 0 Then
'            dt.PrimaryKey = pkCols.ToArray()
'        End If

'    End Sub

'    '===========================================================
'    ' 3) BLOCCO AUTOMATICO DELLE COLONNE NON MODIFICABILI
'    '===========================================================
'    Public Sub BloccaColonneNonModificabili(dgv As DataGridView, tableName As String)

'        Dim pkNames = GetPrimaryKey(tableName)

'        For Each col As DataGridViewColumn In dgv.Columns

'            ' Blocca PK
'            If pkNames.Contains(col.Name) Then
'                col.ReadOnly = True
'                col.DefaultCellStyle.BackColor = Color.LightGray
'            End If

'            ' Blocca colonne Identity
'            If col.ValueType Is GetType(Integer) AndAlso col.Name.ToLower.Contains("id") Then
'                col.ReadOnly = True
'                col.DefaultCellStyle.BackColor = Color.LightGray
'            End If

'            ' Blocca colonne Timestamp / RowVersion
'            If col.ValueType Is GetType(Byte()) Then
'                col.ReadOnly = True
'                col.DefaultCellStyle.BackColor = Color.LightGray
'            End If

'        Next

'    End Sub

'    '===========================================================
'    ' 4) SALVATAGGIO UNIVERSALE CON COMANDI SQL MANUALI
'    '===========================================================
'    Public Function Salva(dgv As DataGridView) As Boolean

'        Dim dt As DataTable = TryCast(dgv.DataSource, DataTable)
'        If dt Is Nothing Then Return False

'        Dim tableName As String = TryCast(dgv.Tag, String)
'        If String.IsNullOrEmpty(tableName) Then Return False

'        ' Imposta PK nel DataTable
'        ImpostaPKNelDataTable(dt, tableName)

'        Dim pkCols = dt.PrimaryKey.Select(Function(c) c.ColumnName).ToArray()

'        Try
'            Using cn As New SqlConnection(_connString)
'                cn.Open()

'                Dim da As New SqlDataAdapter("SELECT * FROM " & tableName, cn)

'                '===========================================================
'                ' UPDATE
'                '===========================================================
'                Dim updateSql As String =
'                    "UPDATE " & tableName & " SET " &
'                    String.Join(", ", dt.Columns.Cast(Of DataColumn)().
'                        Where(Function(c) Not pkCols.Contains(c.ColumnName)).
'                        Select(Function(c) c.ColumnName & " = @" & c.ColumnName)) &
'                    " WHERE " &
'                    String.Join(" AND ", pkCols.Select(Function(c) c & " = @PK_" & c))

'                Dim updateCmd As New SqlCommand(updateSql, cn)

'                For Each col As DataColumn In dt.Columns
'                    If Not pkCols.Contains(col.ColumnName) Then
'                        updateCmd.Parameters.Add("@" & col.ColumnName, SqlDbType.VarChar, 255, col.ColumnName)
'                    End If
'                Next

'                For Each pk In pkCols
'                    updateCmd.Parameters.Add("@PK_" & pk, SqlDbType.VarChar, 255, pk)
'                Next

'                da.UpdateCommand = updateCmd

'                '===========================================================
'                ' INSERT
'                '===========================================================
'                Dim insertCols = dt.Columns.Cast(Of DataColumn)().
'                    Where(Function(c) Not c.AutoIncrement).Select(Function(c) c.ColumnName).ToArray()

'                Dim insertSql As String =
'                    "INSERT INTO " & tableName &
'                    " (" & String.Join(", ", insertCols) & ") VALUES (" &
'                    String.Join(", ", insertCols.Select(Function(c) "@" & c)) & ")"

'                Dim insertCmd As New SqlCommand(insertSql, cn)

'                For Each col In insertCols
'                    insertCmd.Parameters.Add("@" & col, SqlDbType.VarChar, 255, col)
'                Next

'                da.InsertCommand = insertCmd

'                '===========================================================
'                ' DELETE
'                '===========================================================
'                Dim deleteSql As String =
'                    "DELETE FROM " & tableName & " WHERE " &
'                    String.Join(" AND ", pkCols.Select(Function(c) c & " = @PK_" & c))

'                Dim deleteCmd As New SqlCommand(deleteSql, cn)

'                For Each pk In pkCols
'                    deleteCmd.Parameters.Add("@PK_" & pk, SqlDbType.VarChar, 255, pk)
'                Next

'                da.DeleteCommand = deleteCmd

'                '===========================================================
'                ' ESEGUI SALVATAGGIO
'                '===========================================================
'                da.Update(dt)

'                MsgBox("Modifiche salvate nella tabella: " & tableName)
'                Return True

'            End Using

'        Catch ex As Exception
'            MsgBox("Errore nel salvataggio: " & ex.Message)
'            Return False
'        End Try

'    End Function

'End Class



'Imports System.Data.SqlClient
'Imports System.Data
'Imports System.Configuration

'Public Class DBSalvaTabelle

'    Private ReadOnly _connString As String

'    Public Sub New()
'        _connString = ConfigurationManager.ConnectionStrings("MiaConnessione").ConnectionString
'    End Sub

'    '===========================================================
'    ' 1) RILEVAMENTO AUTOMATICO DELLA PRIMARY KEY
'    '===========================================================
'    Public Function GetPrimaryKey(tableName As String) As String()

'        Const sql As String =
'            "SELECT KU.COLUMN_NAME
'             FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC
'             INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KU
'                 ON TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
'             WHERE TC.TABLE_NAME = @tab
'               AND TC.CONSTRAINT_TYPE = 'PRIMARY KEY'
'             ORDER BY KU.ORDINAL_POSITION"

'        Dim pkList As New List(Of String)

'        Using cn As New SqlConnection(_connString)
'            Using cmd As New SqlCommand(sql, cn)
'                cmd.Parameters.AddWithValue("@tab", tableName)
'                cn.Open()

'                Using rd = cmd.ExecuteReader()
'                    While rd.Read()
'                        pkList.Add(rd.GetString(0))
'                    End While
'                End Using
'            End Using
'        End Using

'        Return pkList.ToArray()
'    End Function

'    '===========================================================
'    ' 2) IMPOSTA LA PK NEL DATATABLE
'    '===========================================================
'    Public Sub ImpostaPKNelDataTable(dt As DataTable, tableName As String)

'        Dim pkNames = GetPrimaryKey(tableName)

'        If pkNames.Length = 0 Then
'            MsgBox("ATTENZIONE: La tabella '" & tableName & "' non ha una Primary Key.")
'            Exit Sub
'        End If

'        Dim pkCols As New List(Of DataColumn)

'        For Each pk In pkNames
'            If dt.Columns.Contains(pk) Then
'                pkCols.Add(dt.Columns(pk))
'            Else
'                MsgBox("ATTENZIONE: La colonna PK '" & pk & "' non esiste nel DataTable.")
'            End If
'        Next

'        If pkCols.Count > 0 Then
'            dt.PrimaryKey = pkCols.ToArray()
'        End If

'    End Sub

'    '===========================================================
'    ' 3) BLOCCO AUTOMATICO DELLE COLONNE NON MODIFICABILI
'    '===========================================================
'    Public Sub BloccaColonneNonModificabili(dgv As DataGridView, tableName As String)

'        Dim pkNames = GetPrimaryKey(tableName)

'        For Each col As DataGridViewColumn In dgv.Columns

'            ' Blocca PK
'            If pkNames.Contains(col.Name) Then
'                col.ReadOnly = True
'                col.DefaultCellStyle.BackColor = Color.LightGray
'            End If

'            ' Blocca colonne Identity
'            If col.ValueType Is GetType(Integer) AndAlso col.Name.ToLower.Contains("id") Then
'                col.ReadOnly = True
'                col.DefaultCellStyle.BackColor = Color.LightGray
'            End If

'            ' Blocca colonne Timestamp / RowVersion
'            If col.ValueType Is GetType(Byte()) Then
'                col.ReadOnly = True
'                col.DefaultCellStyle.BackColor = Color.LightGray
'            End If

'        Next

'    End Sub

'    '===========================================================
'    ' 4) SALVATAGGIO UNIVERSALE CON COMANDI SQL MANUALI
'    '===========================================================
'    Public Function Salva(dgv As DataGridView) As Boolean

'        Dim dt As DataTable = TryCast(dgv.DataSource, DataTable)
'        If dt Is Nothing Then Return False

'        Dim tableName As String = TryCast(dgv.Tag, String)
'        If String.IsNullOrEmpty(tableName) Then Return False

'        ' Imposta PK nel DataTable
'        ImpostaPKNelDataTable(dt, tableName)

'        Dim pkCols = dt.PrimaryKey.Select(Function(c) c.ColumnName).ToArray()

'        Try
'            Using cn As New SqlConnection(_connString)
'                cn.Open()

'                Dim da As New SqlDataAdapter("SELECT * FROM " & tableName, cn)

'                '===========================================================
'                ' UPDATE
'                '===========================================================
'                Dim updateSql As String =
'                    "UPDATE " & tableName & " SET " &
'                    String.Join(", ", dt.Columns.Cast(Of DataColumn)().
'                        Where(Function(c) Not pkCols.Contains(c.ColumnName)).
'                        Select(Function(c) c.ColumnName & " = @" & c.ColumnName)) &
'                    " WHERE " &
'                    String.Join(" AND ", pkCols.Select(Function(c) c & " = @PK_" & c))

'                Dim updateCmd As New SqlCommand(updateSql, cn)

'                For Each col As DataColumn In dt.Columns
'                    If Not pkCols.Contains(col.ColumnName) Then
'                        updateCmd.Parameters.Add("@" & col.ColumnName, SqlDbType.VarChar, 255, col.ColumnName)
'                    End If
'                Next

'                For Each pk In pkCols
'                    updateCmd.Parameters.Add("@PK_" & pk, SqlDbType.VarChar, 255, pk)
'                Next

'                da.UpdateCommand = updateCmd

'                '===========================================================
'                ' INSERT
'                '===========================================================
'                Dim insertCols = dt.Columns.Cast(Of DataColumn)().
'                    Where(Function(c) Not c.AutoIncrement).Select(Function(c) c.ColumnName).ToArray()

'                Dim insertSql As String =
'                    "INSERT INTO " & tableName &
'                    " (" & String.Join(", ", insertCols) & ") VALUES (" &
'                    String.Join(", ", insertCols.Select(Function(c) "@" & c)) & ")"

'                Dim insertCmd As New SqlCommand(insertSql, cn)

'                For Each col In insertCols
'                    insertCmd.Parameters.Add("@" & col, SqlDbType.VarChar, 255, col)
'                Next

'                da.InsertCommand = insertCmd

'                '===========================================================
'                ' DELETE
'                '===========================================================
'                Dim deleteSql As String =
'                    "DELETE FROM " & tableName & " WHERE " &
'                    String.Join(" AND ", pkCols.Select(Function(c) c & " = @PK_" & c))

'                Dim deleteCmd As New SqlCommand(deleteSql, cn)

'                For Each pk In pkCols
'                    deleteCmd.Parameters.Add("@PK_" & pk, SqlDbType.VarChar, 255, pk)
'                Next

'                da.DeleteCommand = deleteCmd

'                '===========================================================
'                ' ESEGUI SALVATAGGIO
'                '===========================================================
'                da.Update(dt)

'                MsgBox("Modifiche salvate nella tabella: " & tableName)
'                Return True

'            End Using

'        Catch ex As Exception
'            MsgBox("Errore nel salvataggio: " & ex.Message)
'            Return False
'        End Try

'    End Function

'End Class













'Imports System.Data.SqlClient
'Imports System.Data

'Public Class DBSalvaTabelle

'    Private ReadOnly _connString As String

'    Public Sub New(connString As String)
'        _connString = connString
'    End Sub

'    '===========================================================
'    ' 1) RILEVAMENTO AUTOMATICO DELLA PRIMARY KEY
'    '===========================================================
'    Public Function GetPrimaryKey(tableName As String) As String

'        Const sql As String =
'            "SELECT COLUMN_NAME 
'             FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
'             WHERE TABLE_NAME = @tab 
'             AND CONSTRAINT_NAME LIKE 'PK_%'"

'        Using cn As New SqlConnection(_connString)
'            Using cmd As New SqlCommand(sql, cn)
'                cmd.Parameters.AddWithValue("@tab", tableName)
'                cn.Open()

'                Dim result = cmd.ExecuteScalar()
'                If result IsNot Nothing Then
'                    Return result.ToString()
'                End If
'            End Using
'        End Using

'        Return Nothing
'    End Function

'    '===========================================================
'    ' 2) BLOCCO AUTOMATICO DELLE COLONNE NON MODIFICABILI
'    '===========================================================
'    Public Sub BloccaColonneNonModificabili(dgv As DataGridView, tableName As String)

'        Dim pk As String = GetPrimaryKey(tableName)
'        If pk Is Nothing Then Exit Sub

'        For Each col As DataGridViewColumn In dgv.Columns

'            ' Blocca PK
'            If col.Name = pk Then
'                col.ReadOnly = True
'                col.DefaultCellStyle.BackColor = Color.LightGray
'            End If

'            ' Blocca colonne Identity
'            If col.ValueType Is GetType(Integer) AndAlso col.Name.ToLower.Contains("id") Then
'                col.ReadOnly = True
'                col.DefaultCellStyle.BackColor = Color.LightGray
'            End If

'            ' Blocca colonne Timestamp
'            If col.ValueType Is GetType(Byte()) Then
'                col.ReadOnly = True
'                col.DefaultCellStyle.BackColor = Color.LightGray
'            End If

'        Next

'    End Sub

'    '===========================================================
'    ' 3) SALVATAGGIO UNIVERSALE DEL DATATABLE
'    '===========================================================
'    Public Function Salva(dgv As DataGridView) As Boolean

'        Dim dt As DataTable = TryCast(dgv.DataSource, DataTable)
'        If dt Is Nothing Then
'            MsgBox("Nessun DataTable da salvare.")
'            Return False
'        End If

'        Dim tableName As String = TryCast(dgv.Tag, String)
'        If String.IsNullOrEmpty(tableName) Then
'            MsgBox("Nome tabella non trovato nel Tag del DataGridView.")
'            Return False
'        End If

'        Try
'            Using cn As New SqlConnection(_connString)
'                cn.Open()

'                Dim sql As String = "SELECT * FROM " & tableName
'                Dim da As New SqlDataAdapter(sql, cn)
'                Dim cb As New SqlCommandBuilder(da)

'                da.Update(dt)

'                MsgBox("Modifiche salvate nella tabella: " & tableName)
'                Return True

'            End Using

'        Catch ex As Exception
'            MsgBox("Errore nel salvataggio: " & ex.Message)
'            Return False
'        End Try

'    End Function

'End Class
