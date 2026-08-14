<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FemInsClienti
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FemInsClienti))
        Me.ClientiDataGrid = New System.Windows.Forms.DataGridView()
        Me.OrdiniDataGrid = New System.Windows.Forms.DataGridView()
        Me.RjCircSalva = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RjBtnLog = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RjCircularPictureBox1 = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCerca = New System.Windows.Forms.TextBox()
        CType(Me.ClientiDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdiniDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjCircSalva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjBtnLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjCircularPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ClientiDataGrid
        '
        Me.ClientiDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ClientiDataGrid.Location = New System.Drawing.Point(30, 234)
        Me.ClientiDataGrid.Name = "ClientiDataGrid"
        Me.ClientiDataGrid.RowHeadersWidth = 51
        Me.ClientiDataGrid.RowTemplate.Height = 24
        Me.ClientiDataGrid.Size = New System.Drawing.Size(1861, 398)
        Me.ClientiDataGrid.TabIndex = 0
        '
        'OrdiniDataGrid
        '
        Me.OrdiniDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OrdiniDataGrid.Location = New System.Drawing.Point(30, 702)
        Me.OrdiniDataGrid.Name = "OrdiniDataGrid"
        Me.OrdiniDataGrid.ReadOnly = True
        Me.OrdiniDataGrid.RowHeadersWidth = 51
        Me.OrdiniDataGrid.RowTemplate.Height = 24
        Me.OrdiniDataGrid.Size = New System.Drawing.Size(1861, 350)
        Me.OrdiniDataGrid.TabIndex = 1
        '
        'RjCircSalva
        '
        Me.RjCircSalva.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjCircSalva.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjCircSalva.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjCircSalva.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjCircSalva.BorderSize = 2
        Me.RjCircSalva.GradientAngle = 50.0!
        Me.RjCircSalva.Image = Global.WinTest.My.Resources.Resources.folders2
        Me.RjCircSalva.Location = New System.Drawing.Point(39, 100)
        Me.RjCircSalva.Name = "RjCircSalva"
        Me.RjCircSalva.Size = New System.Drawing.Size(100, 100)
        Me.RjCircSalva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjCircSalva.TabIndex = 2
        Me.RjCircSalva.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(77, 651)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(253, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ordini collegati al Cliente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(163, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(337, 25)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "       Salva Inserimenti o Modifiche"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.RjBtnLog.Location = New System.Drawing.Point(1173, 102)
        Me.RjBtnLog.Name = "RjBtnLog"
        Me.RjBtnLog.Size = New System.Drawing.Size(64, 64)
        Me.RjBtnLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjBtnLog.TabIndex = 17
        Me.RjBtnLog.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1110, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 25)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "LOG"
        '
        'RjCircularPictureBox1
        '
        Me.RjCircularPictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjCircularPictureBox1.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjCircularPictureBox1.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjCircularPictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjCircularPictureBox1.BorderSize = 2
        Me.RjCircularPictureBox1.GradientAngle = 50.0!
        Me.RjCircularPictureBox1.Image = CType(resources.GetObject("RjCircularPictureBox1.Image"), System.Drawing.Image)
        Me.RjCircularPictureBox1.Location = New System.Drawing.Point(580, 113)
        Me.RjCircularPictureBox1.Name = "RjCircularPictureBox1"
        Me.RjCircularPictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.RjCircularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjCircularPictureBox1.TabIndex = 19
        Me.RjCircularPictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(684, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 25)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Cerca Cliente"
        '
        'TxtCerca
        '
        Me.TxtCerca.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TxtCerca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCerca.Location = New System.Drawing.Point(689, 143)
        Me.TxtCerca.Name = "TxtCerca"
        Me.TxtCerca.Size = New System.Drawing.Size(139, 30)
        Me.TxtCerca.TabIndex = 20
        '
        'FemInsClienti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 864)
        Me.Controls.Add(Me.TxtCerca)
        Me.Controls.Add(Me.RjCircularPictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RjBtnLog)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RjCircSalva)
        Me.Controls.Add(Me.OrdiniDataGrid)
        Me.Controls.Add(Me.ClientiDataGrid)
        Me.Name = "FemInsClienti"
        Me.Text = "FemInsClienti"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClientiDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdiniDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjCircSalva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjBtnLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjCircularPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ClientiDataGrid As DataGridView
    Friend WithEvents OrdiniDataGrid As DataGridView
    Friend WithEvents RjCircSalva As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents RjBtnLog As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents RjCircularPictureBox1 As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtCerca As TextBox
End Class
