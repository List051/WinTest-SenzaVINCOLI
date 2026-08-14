<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCliOrd
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ClientiDataGrid = New System.Windows.Forms.DataGridView()
        Me.OrdiniDataGrid = New System.Windows.Forms.DataGridView()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.RjCircSpostaFrm = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.RjLeggiLog = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.RjBtnAggElenco = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.RjAggClienti = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.RjAggiorna = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RjCircFrmAprire = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        CType(Me.ClientiDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdiniDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjCircSpostaFrm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjLeggiLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjBtnAggElenco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjAggClienti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjAggiorna, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjCircFrmAprire, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ClientiDataGrid
        '
        Me.ClientiDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ClientiDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ClientiDataGrid.Location = New System.Drawing.Point(72, 201)
        Me.ClientiDataGrid.Name = "ClientiDataGrid"
        Me.ClientiDataGrid.RowHeadersWidth = 51
        Me.ClientiDataGrid.RowTemplate.Height = 24
        Me.ClientiDataGrid.Size = New System.Drawing.Size(1302, 332)
        Me.ClientiDataGrid.TabIndex = 0
        '
        'OrdiniDataGrid
        '
        Me.OrdiniDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.OrdiniDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OrdiniDataGrid.Location = New System.Drawing.Point(72, 562)
        Me.OrdiniDataGrid.Name = "OrdiniDataGrid"
        Me.OrdiniDataGrid.RowHeadersWidth = 51
        Me.OrdiniDataGrid.RowTemplate.Height = 24
        Me.OrdiniDataGrid.Size = New System.Drawing.Size(1302, 284)
        Me.OrdiniDataGrid.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(747, 129)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(182, 29)
        Me.Label22.TabIndex = 57
        Me.Label22.Text = "Leggi File Log"
        '
        'RjCircSpostaFrm
        '
        Me.RjCircSpostaFrm.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjCircSpostaFrm.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjCircSpostaFrm.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjCircSpostaFrm.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjCircSpostaFrm.BorderSize = 2
        Me.RjCircSpostaFrm.GradientAngle = 50.0!
        Me.RjCircSpostaFrm.Image = Global.WinTest.My.Resources.Resources.add
        Me.RjCircSpostaFrm.Location = New System.Drawing.Point(992, 111)
        Me.RjCircSpostaFrm.Name = "RjCircSpostaFrm"
        Me.RjCircSpostaFrm.Size = New System.Drawing.Size(67, 67)
        Me.RjCircSpostaFrm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjCircSpostaFrm.TabIndex = 58
        Me.RjCircSpostaFrm.TabStop = False
        '
        'RjLeggiLog
        '
        Me.RjLeggiLog.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjLeggiLog.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjLeggiLog.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjLeggiLog.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjLeggiLog.BorderSize = 2
        Me.RjLeggiLog.GradientAngle = 50.0!
        Me.RjLeggiLog.Image = Global.WinTest.My.Resources.Resources.errore
        Me.RjLeggiLog.Location = New System.Drawing.Point(663, 100)
        Me.RjLeggiLog.Name = "RjLeggiLog"
        Me.RjLeggiLog.Size = New System.Drawing.Size(78, 78)
        Me.RjLeggiLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjLeggiLog.TabIndex = 56
        Me.RjLeggiLog.TabStop = False
        '
        'RjBtnAggElenco
        '
        Me.RjBtnAggElenco.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjBtnAggElenco.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjBtnAggElenco.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjBtnAggElenco.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjBtnAggElenco.BorderSize = 2
        Me.RjBtnAggElenco.GradientAngle = 50.0!
        Me.RjBtnAggElenco.Image = Global.WinTest.My.Resources.Resources.popEdit
        Me.RjBtnAggElenco.Location = New System.Drawing.Point(479, 111)
        Me.RjBtnAggElenco.Name = "RjBtnAggElenco"
        Me.RjBtnAggElenco.Size = New System.Drawing.Size(67, 67)
        Me.RjBtnAggElenco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjBtnAggElenco.TabIndex = 5
        Me.RjBtnAggElenco.TabStop = False
        '
        'RjAggClienti
        '
        Me.RjAggClienti.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjAggClienti.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjAggClienti.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjAggClienti.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjAggClienti.BorderSize = 2
        Me.RjAggClienti.GradientAngle = 50.0!
        Me.RjAggClienti.Image = Global.WinTest.My.Resources.Resources.add
        Me.RjAggClienti.Location = New System.Drawing.Point(334, 111)
        Me.RjAggClienti.Name = "RjAggClienti"
        Me.RjAggClienti.Size = New System.Drawing.Size(67, 67)
        Me.RjAggClienti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjAggClienti.TabIndex = 4
        Me.RjAggClienti.TabStop = False
        '
        'RjAggiorna
        '
        Me.RjAggiorna.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjAggiorna.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjAggiorna.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjAggiorna.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjAggiorna.BorderSize = 2
        Me.RjAggiorna.GradientAngle = 50.0!
        Me.RjAggiorna.Image = Global.WinTest.My.Resources.Resources.edit
        Me.RjAggiorna.Location = New System.Drawing.Point(188, 111)
        Me.RjAggiorna.Name = "RjAggiorna"
        Me.RjAggiorna.Size = New System.Drawing.Size(67, 67)
        Me.RjAggiorna.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjAggiorna.TabIndex = 3
        Me.RjAggiorna.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.WinTest.My.Resources.Resources.Form_NON_Utilizza
        Me.PictureBox1.Location = New System.Drawing.Point(72, 852)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1154, 126)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'RjCircFrmAprire
        '
        Me.RjCircFrmAprire.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjCircFrmAprire.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjCircFrmAprire.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjCircFrmAprire.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjCircFrmAprire.BorderSize = 2
        Me.RjCircFrmAprire.GradientAngle = 50.0!
        Me.RjCircFrmAprire.Image = Global.WinTest.My.Resources.Resources.order
        Me.RjCircFrmAprire.Location = New System.Drawing.Point(1101, 111)
        Me.RjCircFrmAprire.Name = "RjCircFrmAprire"
        Me.RjCircFrmAprire.Size = New System.Drawing.Size(67, 67)
        Me.RjCircFrmAprire.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjCircFrmAprire.TabIndex = 59
        Me.RjCircFrmAprire.TabStop = False
        '
        'FrmCliOrd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1398, 1055)
        Me.Controls.Add(Me.RjCircFrmAprire)
        Me.Controls.Add(Me.RjCircSpostaFrm)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.RjLeggiLog)
        Me.Controls.Add(Me.RjBtnAggElenco)
        Me.Controls.Add(Me.RjAggClienti)
        Me.Controls.Add(Me.RjAggiorna)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.OrdiniDataGrid)
        Me.Controls.Add(Me.ClientiDataGrid)
        Me.Name = "FrmCliOrd"
        Me.Text = "FrmCliOrd"
        CType(Me.ClientiDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdiniDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjCircSpostaFrm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjLeggiLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjBtnAggElenco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjAggClienti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjAggiorna, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjCircFrmAprire, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ClientiDataGrid As DataGridView
    Friend WithEvents OrdiniDataGrid As DataGridView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents RjAggiorna As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents RjAggClienti As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents RjBtnAggElenco As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents Label22 As Label
    Friend WithEvents RjLeggiLog As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents RjCircSpostaFrm As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents RjCircFrmAprire As RJCodeAdvance.RJControls.RJCircularPictureBox
End Class
