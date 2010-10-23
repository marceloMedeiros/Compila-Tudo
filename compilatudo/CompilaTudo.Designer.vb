<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompilaTudo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnPastaRaiz = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.procurarPasta = New System.Windows.Forms.FolderBrowserDialog
        Me.txtPastaRaiz = New System.Windows.Forms.TextBox
        Me.terminal = New System.Windows.Forms.TextBox
        Me.btnGerarBat = New System.Windows.Forms.Button
        Me.salvarArquivo = New System.Windows.Forms.SaveFileDialog
        Me.pbar = New System.Windows.Forms.ProgressBar
        Me.sttb = New System.Windows.Forms.TextBox
        Me.btnCompilar = New System.Windows.Forms.Button
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.txtPastaDestino = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnPastaDestino = New System.Windows.Forms.Button
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ConfiguraçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParametrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPastaRaiz
        '
        Me.btnPastaRaiz.Location = New System.Drawing.Point(350, 64)
        Me.btnPastaRaiz.Name = "btnPastaRaiz"
        Me.btnPastaRaiz.Size = New System.Drawing.Size(75, 23)
        Me.btnPastaRaiz.TabIndex = 1
        Me.btnPastaRaiz.Text = "Procurar"
        Me.btnPastaRaiz.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Pasta raiz:"
        '
        'txtPastaRaiz
        '
        Me.txtPastaRaiz.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtPastaRaiz.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtPastaRaiz.Location = New System.Drawing.Point(12, 64)
        Me.txtPastaRaiz.Name = "txtPastaRaiz"
        Me.txtPastaRaiz.Size = New System.Drawing.Size(332, 20)
        Me.txtPastaRaiz.TabIndex = 0
        '
        'terminal
        '
        Me.terminal.BackColor = System.Drawing.Color.Black
        Me.terminal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.terminal.Location = New System.Drawing.Point(12, 134)
        Me.terminal.Multiline = True
        Me.terminal.Name = "terminal"
        Me.terminal.ReadOnly = True
        Me.terminal.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.terminal.Size = New System.Drawing.Size(780, 388)
        Me.terminal.TabIndex = 4
        Me.terminal.TabStop = False
        '
        'btnGerarBat
        '
        Me.btnGerarBat.Location = New System.Drawing.Point(636, 535)
        Me.btnGerarBat.Name = "btnGerarBat"
        Me.btnGerarBat.Size = New System.Drawing.Size(75, 23)
        Me.btnGerarBat.TabIndex = 5
        Me.btnGerarBat.Text = "Gerar BAT"
        Me.btnGerarBat.UseVisualStyleBackColor = True
        '
        'pbar
        '
        Me.pbar.Location = New System.Drawing.Point(615, 565)
        Me.pbar.Maximum = 0
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(193, 23)
        Me.pbar.Step = 1
        Me.pbar.TabIndex = 6
        '
        'sttb
        '
        Me.sttb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.sttb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.sttb.BackColor = System.Drawing.SystemColors.Control
        Me.sttb.Enabled = False
        Me.sttb.Location = New System.Drawing.Point(0, 565)
        Me.sttb.Name = "sttb"
        Me.sttb.ReadOnly = True
        Me.sttb.Size = New System.Drawing.Size(620, 20)
        Me.sttb.TabIndex = 7
        Me.sttb.TabStop = False
        '
        'btnCompilar
        '
        Me.btnCompilar.Location = New System.Drawing.Point(717, 535)
        Me.btnCompilar.Name = "btnCompilar"
        Me.btnCompilar.Size = New System.Drawing.Size(75, 23)
        Me.btnCompilar.TabIndex = 6
        Me.btnCompilar.Text = "Compilar"
        Me.btnCompilar.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'txtPastaDestino
        '
        Me.txtPastaDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtPastaDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtPastaDestino.Location = New System.Drawing.Point(12, 104)
        Me.txtPastaDestino.Name = "txtPastaDestino"
        Me.txtPastaDestino.Size = New System.Drawing.Size(332, 20)
        Me.txtPastaDestino.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(352, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Pasta destino, onde serão colocado o .bat e/ou os arquivos compilados.:"
        '
        'btnPastaDestino
        '
        Me.btnPastaDestino.Location = New System.Drawing.Point(350, 104)
        Me.btnPastaDestino.Name = "btnPastaDestino"
        Me.btnPastaDestino.Size = New System.Drawing.Size(75, 23)
        Me.btnPastaDestino.TabIndex = 3
        Me.btnPastaDestino.Text = "Procurar"
        Me.btnPastaDestino.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraçõesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(804, 24)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConfiguraçõesToolStripMenuItem
        '
        Me.ConfiguraçõesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParametrosToolStripMenuItem})
        Me.ConfiguraçõesToolStripMenuItem.Name = "ConfiguraçõesToolStripMenuItem"
        Me.ConfiguraçõesToolStripMenuItem.Size = New System.Drawing.Size(96, 20)
        Me.ConfiguraçõesToolStripMenuItem.Text = "Configurações"
        '
        'ParametrosToolStripMenuItem
        '
        Me.ParametrosToolStripMenuItem.Name = "ParametrosToolStripMenuItem"
        Me.ParametrosToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ParametrosToolStripMenuItem.Text = "Alterar"
        '
        'CompilaTudo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 588)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnPastaDestino)
        Me.Controls.Add(Me.txtPastaDestino)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCompilar)
        Me.Controls.Add(Me.pbar)
        Me.Controls.Add(Me.sttb)
        Me.Controls.Add(Me.btnGerarBat)
        Me.Controls.Add(Me.txtPastaRaiz)
        Me.Controls.Add(Me.terminal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPastaRaiz)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "CompilaTudo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ferramenta para Compilação em Lote"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPastaRaiz As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents procurarPasta As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtPastaRaiz As System.Windows.Forms.TextBox
    Friend WithEvents terminal As System.Windows.Forms.TextBox
    Friend WithEvents btnGerarBat As System.Windows.Forms.Button
    Friend WithEvents salvarArquivo As System.Windows.Forms.SaveFileDialog
    Friend WithEvents pbar As System.Windows.Forms.ProgressBar
    Friend WithEvents sttb As System.Windows.Forms.TextBox
    Friend WithEvents btnCompilar As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtPastaDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnPastaDestino As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ConfiguraçõesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParametrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
