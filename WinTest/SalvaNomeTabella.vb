
'' Associa il DataTable al DataGridView e conserva il nome della tabella nel Tag

'Imports System.Data.SqlClient
'Imports System.Data
'Imports System.Configuration
'Imports WinItalPascal

'Public Class DBSalvaTabelle

'    Private ReadOnly _connString As String

'    Public Sub New()
'        ' Ottieni la connection string dall'oggetto SqlConnection restituito da DB.GetConnection()
'        Using cn As SqlConnection = DB.GetConnection()
'            If cn Is Nothing Then
'                Throw New InvalidOperationException("DB.GetConnection() ha restituito Nothing.")
'            End If
'            _connString = cn.ConnectionString
'        End Using
'    End Sub

'    ' Esempio di metodo che usa la connection string correttamente
'    Public Function EseguiScalar(sql As String, Optional params As IEnumerable(Of SqlParameter) = Nothing) As Object
'        Using cn As New SqlConnection(_connString)
'            Using cmd As New SqlCommand(sql, cn)
'                If params IsNot Nothing Then
'                    cmd.Parameters.AddRange(params.ToArray())
'                End If
'                cn.Open()
'                Return cmd.ExecuteScalar()
'            End Using
'        End Using
'    End Function

'    Public ReadOnly Property ConnectionString As String
'        Get
'            Return _connString
'        End Get
'    End Property


'    Private Function GetPrimaryKey(tableName As String) As String()
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
'        If pkCols.Count > 0 Then dt.PrimaryKey = pkCols.ToArray()
'    End Sub

'    Public Sub BloccaColonneNonModificabili(dgv As DataGridView, tableName As String)
'        Dim pkNames = GetPrimaryKey(tableName)
'        For Each col As DataGridViewColumn In dgv.Columns
'            If pkNames.Contains(col.Name) Then
'                col.ReadOnly = True
'                col.DefaultCellStyle.BackColor = Color.LightGray
'            End If
'            If col.ValueType Is GetType(Integer) AndAlso col.Name.ToLower.Contains("id") Then
'                col.ReadOnly = True
'                col.DefaultCellStyle.BackColor = Color.LightGray
'            End If
'            If col.ValueType Is GetType(Byte()) Then
'                col.ReadOnly = True
'                col.DefaultCellStyle.BackColor = Color.LightGray
'            End If
'        Next
'    End Sub

'    Private Function MapTypeToSqlDbType(t As Type) As SqlDbType
'        If t Is GetType(String) Then Return SqlDbType.NVarChar
'        If t Is GetType(Integer) Then Return SqlDbType.Int
'        If t Is GetType(Long) Then Return SqlDbType.BigInt
'        If t Is GetType(Decimal) Then Return SqlDbType.Decimal
'        If t Is GetType(Double) Then Return SqlDbType.Float
'        If t Is GetType(Single) Then Return SqlDbType.Real
'        If t Is GetType(Boolean) Then Return SqlDbType.Bit
'        If t Is GetType(DateTime) Then Return SqlDbType.DateTime
'        If t Is GetType(Byte()) Then Return SqlDbType.VarBinary
'        If t Is GetType(Short) Then Return SqlDbType.SmallInt
'        If t Is GetType(Byte) Then Return SqlDbType.TinyInt
'        If t Is GetType(Guid) Then Return SqlDbType.UniqueIdentifier
'        Return SqlDbType.NVarChar
'    End Function

'    Public Function Salva(dgv As DataGridView) As Boolean
'        Dim dt As DataTable = TryCast(dgv.DataSource, DataTable)
'        If dt Is Nothing Then Return False
'        Dim tableName As String = TryCast(dgv.Tag, String)
'        If String.IsNullOrEmpty(tableName) Then Return False

'        ImpostaPKNelDataTable(dt, tableName)
'        Dim pkCols = dt.PrimaryKey.Select(Function(c) c.ColumnName).ToArray()

'        Try
'            Using cn As New SqlConnection(_connString)
'                cn.Open()
'                Dim da As New SqlDataAdapter("SELECT * FROM " & tableName, cn)

'                ' UPDATE
'                Dim updateSql As String =
'                    "UPDATE " & tableName & " SET " &
'                    String.Join(", ", dt.Columns.Cast(Of DataColumn)().
'                        Where(Function(c) Not pkCols.Contains(c.ColumnName)).
'                        Select(Function(c) "[" & c.ColumnName & "] = @" & c.ColumnName)) &
'                    " WHERE " &
'                    String.Join(" AND ", pkCols.Select(Function(c) "[" & c & "] = @PK_" & c))

'                Dim updateCmd As New SqlCommand(updateSql, cn)
'                For Each col As DataColumn In dt.Columns
'                    If Not pkCols.Contains(col.ColumnName) Then
'                        Dim p As New SqlParameter("@" & col.ColumnName, MapTypeToSqlDbType(col.DataType))
'                        p.SourceColumn = col.ColumnName
'                        p.SourceVersion = DataRowVersion.Current
'                        updateCmd.Parameters.Add(p)
'                    End If
'                Next
'                For Each pk In pkCols
'                    Dim pkCol As DataColumn = dt.Columns(pk)
'                    Dim ppk As New SqlParameter("@PK_" & pk, MapTypeToSqlDbType(pkCol.DataType))
'                    ppk.SourceColumn = pk
'                    ppk.SourceVersion = DataRowVersion.Original
'                    updateCmd.Parameters.Add(ppk)
'                Next
'                da.UpdateCommand = updateCmd

'                ' INSERT
'                Dim insertCols = dt.Columns.Cast(Of DataColumn)().
'                    Where(Function(c) Not c.AutoIncrement).Select(Function(c) c.ColumnName).ToArray()

'                Dim insertSql As String =
'                    "INSERT INTO " & tableName &
'                    " (" & String.Join(", ", insertCols.Select(Function(c) "[" & c & "]")) & ") VALUES (" &
'                    String.Join(", ", insertCols.Select(Function(c) "@" & c)) & ")"

'                Dim insertCmd As New SqlCommand(insertSql, cn)
'                For Each colName In insertCols
'                    Dim col As DataColumn = dt.Columns(colName)
'                    Dim p As New SqlParameter("@" & colName, MapTypeToSqlDbType(col.DataType))
'                    p.SourceColumn = colName
'                    p.SourceVersion = DataRowVersion.Current
'                    insertCmd.Parameters.Add(p)
'                Next
'                da.InsertCommand = insertCmd

'                ' DELETE
'                Dim deleteSql As String =
'                    "DELETE FROM " & tableName & " WHERE " &
'                    String.Join(" AND ", pkCols.Select(Function(c) "[" & c & "] = @PK_" & c))

'                Dim deleteCmd As New SqlCommand(deleteSql, cn)
'                For Each pk In pkCols
'                    Dim col As DataColumn = dt.Columns(pk)
'                    Dim p As New SqlParameter("@PK_" & pk, MapTypeToSqlDbType(col.DataType))
'                    p.SourceColumn = pk
'                    p.SourceVersion = DataRowVersion.Original
'                    deleteCmd.Parameters.Add(p)
'                Next
'                da.DeleteCommand = deleteCmd

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

