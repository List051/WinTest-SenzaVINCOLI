
'' Modulo completo: AutoFormat Form (TextBox + DataGridView)
' in un modulo --> Public Module ModAutoFormat

'Public NotInheritable Class GridUtility   ' in libreria

'    Private Sub New()
'    End Sub
' ***************
'
'    ' ==========================================================
'    '   FORMATTATORE COMPLETO PER TEXTBOX + DATAGRIDVIEW
'    '   Usa la proprietà Tag per decidere il formato
'    ' ==========================================================

'    Public Sub AutoFormatForm(form As Form)
'        AutoFormatTextBox(form)
'        AutoFormatDGV(form)
'    End Sub


'    ' ==========================================================
'    '   TEXTBOX
'    ' ==========================================================
'    Private Sub AutoFormatTextBox(form As Form)
'        For Each ctrl As Control In form.Controls
'            If TypeOf ctrl Is TextBox Then
'                Dim txt As TextBox = DirectCast(ctrl, TextBox)
'                ApplyFormatTextBox(txt)
'            End If
'        Next
'    End Sub

'    Private Sub ApplyFormatTextBox(txt As TextBox)
'        If txt.Tag Is Nothing Then Exit Sub

'        Dim tagFmt As String = txt.Tag.ToString().ToLower()
'        Dim val As Decimal = SafeDecimal(txt.Text)

'        Select Case tagFmt
'            Case "n0" : txt.Text = val.ToString("N0")
'            Case "n2" : txt.Text = val.ToString("N2")
'            Case "c2" : txt.Text = val.ToString("C2")
'            Case "p2" : txt.Text = val.ToString("P2")
'            Case "d4" : txt.Text = val.ToString("D4")
'        End Select
'    End Sub


'    ' ==========================================================
'    '   DATAGRIDVIEW
'    ' ==========================================================
'    Private Sub AutoFormatDGV(form As Form)
'        For Each ctrl As Control In form.Controls
'            If TypeOf ctrl Is DataGridView Then
'                Dim dgv As DataGridView = DirectCast(ctrl, DataGridView)
'                For Each col As DataGridViewColumn In dgv.Columns
'                    ApplyFormatDGV(col)
'                Next
'            End If
'        Next
'    End Sub

'    Private Sub ApplyFormatDGV(col As DataGridViewColumn)
'        If col.Tag Is Nothing Then Exit Sub

'        Dim tagFmt As String = col.Tag.ToString().ToLower()

'        Select Case tagFmt
'            Case "n0"
'                col.DefaultCellStyle.Format = "N0"
'                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

'            Case "n2"
'                col.DefaultCellStyle.Format = "N2"
'                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

'            Case "c2"
'                col.DefaultCellStyle.Format = "C2"
'                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

'            Case "p2"
'                col.DefaultCellStyle.Format = "P2"
'                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

'            Case "d4"
'                col.DefaultCellStyle.Format = "D4"
'                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
'        End Select
'    End Sub


'    ' ==========================================================
'    '   CONVERSIONE SICURA
'    ' ==========================================================
'    Private Function SafeDecimal(val As Object) As Decimal
'        If val Is Nothing Then Return 0D

'        Dim s As String = val.ToString().Trim()

'        s = s.Replace("€", "").Trim()
'        s = s.Replace("%", "").Trim()
'        s = s.Replace(".", ",")   ' Italia

'        Dim d As Decimal = 0D
'        Decimal.TryParse(s, d)
'        Return d
'    End Function

'End Module

'AutoFormatForm(Me)          ' Aggiunto in un modulo
'GridUtility.AutoFormatForm(Me)          ' Aggiunto nella mia libreria