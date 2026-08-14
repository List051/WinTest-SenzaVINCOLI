<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFattura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFattura))
        Me.FDataGrid = New System.Windows.Forms.DataGridView()
        Me.RjCircSalvaFattura = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCerca = New System.Windows.Forms.TextBox()
        Me.RjBtnLog = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.FDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjCircSalvaFattura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjBtnLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FDataGrid
        '
        Me.FDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FDataGrid.Location = New System.Drawing.Point(44, 233)
        Me.FDataGrid.Name = "FDataGrid"
        Me.FDataGrid.RowHeadersWidth = 51
        Me.FDataGrid.RowTemplate.Height = 24
        Me.FDataGrid.Size = New System.Drawing.Size(1724, 452)
        Me.FDataGrid.TabIndex = 0
        '
        'RjCircSalvaFattura
        '
        Me.RjCircSalvaFattura.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjCircSalvaFattura.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjCircSalvaFattura.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjCircSalvaFattura.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjCircSalvaFattura.BorderSize = 2
        Me.RjCircSalvaFattura.GradientAngle = 50.0!
        Me.RjCircSalvaFattura.Image = Global.WinTest.My.Resources.Resources.edit
        Me.RjCircSalvaFattura.Location = New System.Drawing.Point(634, 104)
        Me.RjCircSalvaFattura.Name = "RjCircSalvaFattura"
        Me.RjCircSalvaFattura.Size = New System.Drawing.Size(100, 100)
        Me.RjCircSalvaFattura.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjCircSalvaFattura.TabIndex = 13
        Me.RjCircSalvaFattura.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 158)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(235, 29)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Cerca nel DataGrid"
        '
        'TxtCerca
        '
        Me.TxtCerca.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtCerca.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCerca.Location = New System.Drawing.Point(301, 153)
        Me.TxtCerca.Name = "TxtCerca"
        Me.TxtCerca.Size = New System.Drawing.Size(234, 34)
        Me.TxtCerca.TabIndex = 14
        '
        'RjBtnLog
        '
        Me.RjBtnLog.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjBtnLog.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjBtnLog.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjBtnLog.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjBtnLog.BorderSize = 2
        Me.RjBtnLog.GradientAngle = 50.0!
        Me.RjBtnLog.Image = CType(resources.GetObject("RjBtnLog.Image"), System.Drawing.Image)
        Me.RjBtnLog.Location = New System.Drawing.Point(882, 109)
        Me.RjBtnLog.Name = "RjBtnLog"
        Me.RjBtnLog.Size = New System.Drawing.Size(95, 95)
        Me.RjBtnLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjBtnLog.TabIndex = 19
        Me.RjBtnLog.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(819, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 25)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "LOG"
        '
        'FrmFattura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1800, 1055)
        Me.Controls.Add(Me.RjBtnLog)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtCerca)
        Me.Controls.Add(Me.RjCircSalvaFattura)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FDataGrid)
        Me.Name = "FrmFattura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmFattura"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.FDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjCircSalvaFattura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjBtnLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FDataGrid As DataGridView
    Friend WithEvents RjCircSalvaFattura As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtCerca As TextBox
    Friend WithEvents RjBtnLog As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents Label3 As Label
End Class
