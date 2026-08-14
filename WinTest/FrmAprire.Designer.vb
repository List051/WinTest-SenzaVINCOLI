<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAprire
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnFadeOut = New System.Windows.Forms.Button()
        Me.PanelTest = New System.Windows.Forms.Panel()
        Me.DTGAprire = New System.Windows.Forms.DataGridView()
        Me.CboTabella = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RjCircSalvaTabella = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.PanelTest.SuspendLayout()
        CType(Me.DTGAprire, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjCircSalvaTabella, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 138)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(607, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Apre la tabella di Default impostata su  Clienti"
        '
        'BtnFadeOut
        '
        Me.BtnFadeOut.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnFadeOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFadeOut.Location = New System.Drawing.Point(1496, 194)
        Me.BtnFadeOut.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnFadeOut.Name = "BtnFadeOut"
        Me.BtnFadeOut.Size = New System.Drawing.Size(245, 48)
        Me.BtnFadeOut.TabIndex = 6
        Me.BtnFadeOut.Text = "Chiudi"
        Me.BtnFadeOut.UseVisualStyleBackColor = False
        '
        'PanelTest
        '
        Me.PanelTest.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PanelTest.Controls.Add(Me.DTGAprire)
        Me.PanelTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelTest.Location = New System.Drawing.Point(46, 194)
        Me.PanelTest.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelTest.Name = "PanelTest"
        Me.PanelTest.Size = New System.Drawing.Size(1865, 510)
        Me.PanelTest.TabIndex = 7
        '
        'DTGAprire
        '
        Me.DTGAprire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTGAprire.Location = New System.Drawing.Point(27, 84)
        Me.DTGAprire.Margin = New System.Windows.Forms.Padding(4)
        Me.DTGAprire.Name = "DTGAprire"
        Me.DTGAprire.RowHeadersWidth = 51
        Me.DTGAprire.Size = New System.Drawing.Size(1812, 361)
        Me.DTGAprire.TabIndex = 0
        '
        'CboTabella
        '
        Me.CboTabella.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTabella.FormattingEnabled = True
        Me.CboTabella.Location = New System.Drawing.Point(995, 129)
        Me.CboTabella.Margin = New System.Windows.Forms.Padding(4)
        Me.CboTabella.Name = "CboTabella"
        Me.CboTabella.Size = New System.Drawing.Size(287, 37)
        Me.CboTabella.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(730, 139)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(225, 29)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Seleziona Tabella"
        '
        'RjCircSalvaTabella
        '
        Me.RjCircSalvaTabella.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjCircSalvaTabella.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjCircSalvaTabella.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjCircSalvaTabella.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjCircSalvaTabella.BorderSize = 2
        Me.RjCircSalvaTabella.GradientAngle = 50.0!
        Me.RjCircSalvaTabella.Image = Global.WinTest.My.Resources.Resources.agobg
        Me.RjCircSalvaTabella.Location = New System.Drawing.Point(1315, 87)
        Me.RjCircSalvaTabella.Name = "RjCircSalvaTabella"
        Me.RjCircSalvaTabella.Size = New System.Drawing.Size(100, 100)
        Me.RjCircSalvaTabella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjCircSalvaTabella.TabIndex = 10
        Me.RjCircSalvaTabella.TabStop = False
        '
        'FrmAprire
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1924, 821)
        Me.Controls.Add(Me.RjCircSalvaTabella)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CboTabella)
        Me.Controls.Add(Me.PanelTest)
        Me.Controls.Add(Me.BtnFadeOut)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmAprire"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmAprire"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelTest.ResumeLayout(False)
        CType(Me.DTGAprire, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjCircSalvaTabella, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents BtnFadeOut As Button
    Friend WithEvents PanelTest As Panel
    Friend WithEvents DTGAprire As DataGridView
    Friend WithEvents CboTabella As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents RjCircSalvaTabella As RJCodeAdvance.RJControls.RJCircularPictureBox
End Class
