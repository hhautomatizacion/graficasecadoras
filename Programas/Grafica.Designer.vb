<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Form1
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel10 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel11 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel9 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.GraficaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FechaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AnalizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InfoAdicionalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripComboBox2 = New System.Windows.Forms.ToolStripComboBox
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConfigurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ColorTempEntradaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ColorTempSalidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ColorCargaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ColorSecundarioCargaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FuenteGraficaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FuenteAnalisisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EscalaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CentigradosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FarenheitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpacidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CargaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel10, Me.ToolStripStatusLabel11, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel9, Me.ToolStripStatusLabel8, Me.ToolStripStatusLabel5, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 278)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StatusStrip1.Size = New System.Drawing.Size(928, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel10
        '
        Me.ToolStripStatusLabel10.Image = CType(resources.GetObject("ToolStripStatusLabel10.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel10.Name = "ToolStripStatusLabel10"
        Me.ToolStripStatusLabel10.Size = New System.Drawing.Size(74, 17)
        Me.ToolStripStatusLabel10.Text = "Secadora:"
        '
        'ToolStripStatusLabel11
        '
        Me.ToolStripStatusLabel11.Name = "ToolStripStatusLabel11"
        Me.ToolStripStatusLabel11.Size = New System.Drawing.Size(21, 17)
        Me.ToolStripStatusLabel11.Text = "XX"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Image = CType(resources.GetObject("ToolStripStatusLabel4.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(55, 17)
        Me.ToolStripStatusLabel4.Text = "Inicio:"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(124, 17)
        Me.ToolStripStatusLabel3.Text = "XXXX-XX-XX XX:XX:XX"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Image = CType(resources.GetObject("ToolStripStatusLabel2.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel2.Text = "Fin:"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(124, 17)
        Me.ToolStripStatusLabel1.Text = "XXXX-XX-XX XX:XX:XX"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Image = CType(resources.GetObject("ToolStripStatusLabel7.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(103, 17)
        Me.ToolStripStatusLabel7.Text = "Temp. Entrada:"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.AutoSize = False
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(17, 17)
        '
        'ToolStripStatusLabel9
        '
        Me.ToolStripStatusLabel9.Image = CType(resources.GetObject("ToolStripStatusLabel9.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel9.Name = "ToolStripStatusLabel9"
        Me.ToolStripStatusLabel9.Size = New System.Drawing.Size(94, 17)
        Me.ToolStripStatusLabel9.Text = "Temp. Salida:"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.AutoSize = False
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(17, 17)
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(90, 17)
        Me.ToolStripStatusLabel5.Spring = True
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(150, 16)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GraficaToolStripMenuItem, Me.ToolStripComboBox1, Me.ToolStripComboBox2, Me.EditarToolStripMenuItem, Me.OpcionesToolStripMenuItem, Me.BuscarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(928, 27)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GraficaToolStripMenuItem
        '
        Me.GraficaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FechaToolStripMenuItem, Me.AnalizarToolStripMenuItem, Me.ExportarToolStripMenuItem, Me.InfoAdicionalToolStripMenuItem, Me.ActualizarToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.GraficaToolStripMenuItem.Name = "GraficaToolStripMenuItem"
        Me.GraficaToolStripMenuItem.Size = New System.Drawing.Size(56, 23)
        Me.GraficaToolStripMenuItem.Text = "Grafica"
        '
        'FechaToolStripMenuItem
        '
        Me.FechaToolStripMenuItem.Name = "FechaToolStripMenuItem"
        Me.FechaToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.FechaToolStripMenuItem.Text = "Fecha..."
        '
        'AnalizarToolStripMenuItem
        '
        Me.AnalizarToolStripMenuItem.Name = "AnalizarToolStripMenuItem"
        Me.AnalizarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.AnalizarToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.AnalizarToolStripMenuItem.Text = "Analizar..."
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ExportarToolStripMenuItem.Text = "Exportar..."
        '
        'InfoAdicionalToolStripMenuItem
        '
        Me.InfoAdicionalToolStripMenuItem.Name = "InfoAdicionalToolStripMenuItem"
        Me.InfoAdicionalToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.InfoAdicionalToolStripMenuItem.Text = "Info. Adicional..."
        '
        'ActualizarToolStripMenuItem
        '
        Me.ActualizarToolStripMenuItem.Name = "ActualizarToolStripMenuItem"
        Me.ActualizarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ActualizarToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ActualizarToolStripMenuItem.Text = "Actualizar"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.AcercaDeToolStripMenuItem.Text = "Acerca de..."
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(75, 23)
        '
        'ToolStripComboBox2
        '
        Me.ToolStripComboBox2.Name = "ToolStripComboBox2"
        Me.ToolStripComboBox2.Size = New System.Drawing.Size(281, 23)
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarToolStripMenuItem})
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(49, 23)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'CopiarToolStripMenuItem
        '
        Me.CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem"
        Me.CopiarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopiarToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.CopiarToolStripMenuItem.Text = "Copiar"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurarToolStripMenuItem, Me.EscalaToolStripMenuItem, Me.OpacidadToolStripMenuItem})
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(69, 23)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        '
        'ConfigurarToolStripMenuItem
        '
        Me.ConfigurarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColorTempEntradaToolStripMenuItem, Me.ColorTempSalidaToolStripMenuItem, Me.ColorCargaToolStripMenuItem, Me.ColorSecundarioCargaToolStripMenuItem, Me.FuenteGraficaToolStripMenuItem, Me.FuenteAnalisisToolStripMenuItem})
        Me.ConfigurarToolStripMenuItem.Name = "ConfigurarToolStripMenuItem"
        Me.ConfigurarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ConfigurarToolStripMenuItem.Text = "Configurar"
        '
        'ColorTempEntradaToolStripMenuItem
        '
        Me.ColorTempEntradaToolStripMenuItem.Name = "ColorTempEntradaToolStripMenuItem"
        Me.ColorTempEntradaToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ColorTempEntradaToolStripMenuItem.Text = "Color Temp. Entrada"
        '
        'ColorTempSalidaToolStripMenuItem
        '
        Me.ColorTempSalidaToolStripMenuItem.Name = "ColorTempSalidaToolStripMenuItem"
        Me.ColorTempSalidaToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ColorTempSalidaToolStripMenuItem.Text = "Color Temp. Salida"
        '
        'ColorCargaToolStripMenuItem
        '
        Me.ColorCargaToolStripMenuItem.Name = "ColorCargaToolStripMenuItem"
        Me.ColorCargaToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ColorCargaToolStripMenuItem.Text = "Color Carga"
        '
        'ColorSecundarioCargaToolStripMenuItem
        '
        Me.ColorSecundarioCargaToolStripMenuItem.Name = "ColorSecundarioCargaToolStripMenuItem"
        Me.ColorSecundarioCargaToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ColorSecundarioCargaToolStripMenuItem.Text = "Color Secundario Carga"
        '
        'FuenteGraficaToolStripMenuItem
        '
        Me.FuenteGraficaToolStripMenuItem.Name = "FuenteGraficaToolStripMenuItem"
        Me.FuenteGraficaToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.FuenteGraficaToolStripMenuItem.Text = "Fuente grafica"
        '
        'FuenteAnalisisToolStripMenuItem
        '
        Me.FuenteAnalisisToolStripMenuItem.Name = "FuenteAnalisisToolStripMenuItem"
        Me.FuenteAnalisisToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.FuenteAnalisisToolStripMenuItem.Text = "Fuente analisis"
        '
        'EscalaToolStripMenuItem
        '
        Me.EscalaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CentigradosToolStripMenuItem, Me.FarenheitToolStripMenuItem})
        Me.EscalaToolStripMenuItem.Name = "EscalaToolStripMenuItem"
        Me.EscalaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EscalaToolStripMenuItem.Text = "Escala"
        '
        'CentigradosToolStripMenuItem
        '
        Me.CentigradosToolStripMenuItem.Name = "CentigradosToolStripMenuItem"
        Me.CentigradosToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.CentigradosToolStripMenuItem.Text = "Centigrados"
        '
        'FarenheitToolStripMenuItem
        '
        Me.FarenheitToolStripMenuItem.Name = "FarenheitToolStripMenuItem"
        Me.FarenheitToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.FarenheitToolStripMenuItem.Text = "Farenheit"
        '
        'OpacidadToolStripMenuItem
        '
        Me.OpacidadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5})
        Me.OpacidadToolStripMenuItem.Name = "OpacidadToolStripMenuItem"
        Me.OpacidadToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OpacidadToolStripMenuItem.Text = "Opacidad"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem2.Text = "100%"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem3.Text = "90%"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem4.Text = "80%"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem5.Text = "70%"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CargaToolStripMenuItem1})
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(54, 23)
        Me.BuscarToolStripMenuItem.Text = "Buscar"
        '
        'CargaToolStripMenuItem1
        '
        Me.CargaToolStripMenuItem1.Name = "CargaToolStripMenuItem1"
        Me.CargaToolStripMenuItem1.Size = New System.Drawing.Size(105, 22)
        Me.CargaToolStripMenuItem1.Text = "Carga"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 60000
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart1.Location = New System.Drawing.Point(0, 27)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(928, 251)
        Me.Chart1.TabIndex = 11
        Me.Chart1.Text = "Chart1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(928, 300)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(4, 30)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Grafica de Secadoras"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GraficaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FechaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnalizarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoAdicionalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigurarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripComboBox2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel9 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel10 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel11 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpacidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorTempEntradaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorTempSalidaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents FuenteGraficaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EscalaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CentigradosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FarenheitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FuenteAnalisisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActualizarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopiarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorCargaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorSecundarioCargaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
#End Region
End Class