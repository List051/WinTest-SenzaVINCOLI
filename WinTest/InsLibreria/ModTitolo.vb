'Module ModTitoloForm
'    ' Variabili per il trascinamento della finestra
'    Private isDragging As Boolean = False
'    Private startPoint As Point

'    ' Metodo per personalizzare il titolo del form e consentire lo spostamento
'    Public Sub CentraTitolo(ByVal frm As Form, ByVal titolo As String)
'        ' Creazione della barra del titolo personalizzata
'        Dim pnlTitolo As New Panel()
'        Dim lblTitolo As New Label()
'        Dim btnChiudi As New Button()
'        Dim btnMinimizza As New Button()

'        ' Configurazione della barra del titolo
'        With pnlTitolo
'            .Dock = DockStyle.Top
'            .Height = 40
'            .BackColor = Color.DarkBlue
'            .ForeColor = Color.White
'            .Cursor = Cursors.Hand ' Cambia il cursore per indicare che si può trascinare
'            .Padding = New Padding(5, 5, 5, 5)
'        End With

'        ' Configurazione del Label (titolo)
'        With lblTitolo
'            .Text = titolo
'            .ForeColor = Color.White
'            .Font = New Font("Segoe UI", 12, FontStyle.Bold)
'            .AutoSize = False
'            .TextAlign = ContentAlignment.MiddleCenter
'            .Dock = DockStyle.Fill
'        End With

'        ' Configurazione del pulsante Chiudi
'        With btnChiudi
'            .Text = "X"
'            .ForeColor = Color.White
'            .BackColor = Color.DarkRed
'            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
'            .Size = New Size(40, 40)
'            .Dock = DockStyle.Right
'            AddHandler .Click, Sub(sender, e) frm.Close()
'        End With

'        ' Configurazione del pulsante Minimizza
'        With btnMinimizza
'            .Text = "—"
'            .ForeColor = Color.White
'            .BackColor = Color.DarkGreen
'            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
'            .Size = New Size(40, 40)
'            .Dock = DockStyle.Right
'            AddHandler .Click, Sub(sender, e) frm.WindowState = FormWindowState.Minimized
'        End With

'        ' Rimozione della barra del titolo standard
'        'frm.FormBorderStyle = FormBorderStyle.None
'        frm.FormBorderStyle = FormBorderStyle.FixedSingle
'        frm.ControlBox = False

'        ' Aggiunta dei controlli al panel
'        pnlTitolo.Controls.Add(lblTitolo)
'        pnlTitolo.Controls.Add(btnMinimizza)
'        pnlTitolo.Controls.Add(btnChiudi)

'        ' Aggiunta del panel al form
'        frm.Controls.Add(pnlTitolo)
'        pnlTitolo.BringToFront()

'        ' Aggiunta degli eventi per il trascinamento
'        AddHandler pnlTitolo.MouseDown, AddressOf PnlTitolo_MouseDown
'        AddHandler pnlTitolo.MouseMove, AddressOf PnlTitolo_MouseMove
'        AddHandler pnlTitolo.MouseUp, AddressOf PnlTitolo_MouseUp

'        ' Memorizza il riferimento al form per usarlo negli eventi
'        pnlTitolo.Tag = frm
'    End Sub

'    ' Evento MouseDown: inizia il trascinamento
'    Private Sub PnlTitolo_MouseDown(sender As Object, e As MouseEventArgs)
'        If e.Button = MouseButtons.Left Then
'            isDragging = True
'            startPoint = New Point(e.X, e.Y)
'            DirectCast(sender, Panel).Cursor = Cursors.SizeAll ' Indica che il form è in movimento
'        End If
'    End Sub

'    ' Evento MouseMove: muove la finestra
'    Private Sub PnlTitolo_MouseMove(sender As Object, e As MouseEventArgs)
'        If isDragging Then
'            Dim pnl As Panel = DirectCast(sender, Panel)
'            Dim frm As Form = DirectCast(pnl.Tag, Form)

'            ' Calcola la nuova posizione
'            frm.Left += e.X - startPoint.X
'            frm.Top += e.Y - startPoint.Y
'        End If
'    End Sub

'    ' Evento MouseUp: ferma il trascinamento
'    Private Sub PnlTitolo_MouseUp(sender As Object, e As MouseEventArgs)
'        isDragging = False
'        DirectCast(sender, Panel).Cursor = Cursors.Hand
'    End Sub
'End Module


