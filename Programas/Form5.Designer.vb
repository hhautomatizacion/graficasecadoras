<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.AnalizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GraficaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InfoAdicionalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.VerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.TempEntradaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TempSalidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PosicionValvToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.OpacidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConfigurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ColorPasoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ColorSecundarioPasoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ColorPasoAltToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ColorSecundarioPasoAltToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel11 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel10 = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel12 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel13 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel9 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.SetEntradaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SetSalidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AnalizarToolStripMenuItem
        '
        Me.AnalizarToolStripMenuItem.Name = "AnalizarToolStripMenuItem"
        Me.AnalizarToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AnalizarToolStripMenuItem.Text = "Analizar..."
        '
        'GraficaToolStripMenuItem
        '
        Me.GraficaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnalizarToolStripMenuItem, Me.ExportarToolStripMenuItem, Me.InfoAdicionalToolStripMenuItem})
        Me.GraficaToolStripMenuItem.Name = "GraficaToolStripMenuItem"
        Me.GraficaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.GraficaToolStripMenuItem.Text = "Grafica"
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ExportarToolStripMenuItem.Text = "Exportar..."
        '
        'InfoAdicionalToolStripMenuItem
        '
        Me.InfoAdicionalToolStripMenuItem.Name = "InfoAdicionalToolStripMenuItem"
        Me.InfoAdicionalToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.InfoAdicionalToolStripMenuItem.Text = "Info. Adicional..."
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GraficaToolStripMenuItem, Me.VerToolStripMenuItem, Me.EditarToolStripMenuItem, Me.OpcionesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1052, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'VerToolStripMenuItem
        '
        Me.VerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripSeparator2, Me.OpacidadToolStripMenuItem})
        Me.VerToolStripMenuItem.Name = "VerToolStripMenuItem"
        Me.VerToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.VerToolStripMenuItem.Text = "Ver"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TempEntradaToolStripMenuItem, Me.TempSalidaToolStripMenuItem, Me.SetEntradaToolStripMenuItem, Me.SetSalidaToolStripMenuItem, Me.PosicionValvToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem1.Text = "Series"
        '
        'TempEntradaToolStripMenuItem
        '
        Me.TempEntradaToolStripMenuItem.Name = "TempEntradaToolStripMenuItem"
        Me.TempEntradaToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.TempEntradaToolStripMenuItem.Text = "Temp. Entrada"
        '
        'TempSalidaToolStripMenuItem
        '
        Me.TempSalidaToolStripMenuItem.Name = "TempSalidaToolStripMenuItem"
        Me.TempSalidaToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.TempSalidaToolStripMenuItem.Text = "Temp. Salida"
        '
        'PosicionValvToolStripMenuItem
        '
        Me.PosicionValvToolStripMenuItem.Name = "PosicionValvToolStripMenuItem"
        Me.PosicionValvToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.PosicionValvToolStripMenuItem.Text = "Posicion Valv."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
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
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(114, 22)
        Me.ToolStripMenuItem2.Text = "100%"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(114, 22)
        Me.ToolStripMenuItem3.Text = "90%"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(114, 22)
        Me.ToolStripMenuItem4.Text = "80%"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(114, 22)
        Me.ToolStripMenuItem5.Text = "70%"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarToolStripMenuItem})
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'CopiarToolStripMenuItem
        '
        Me.CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem"
        Me.CopiarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopiarToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.CopiarToolStripMenuItem.Text = "Copiar"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurarToolStripMenuItem})
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        '
        'ConfigurarToolStripMenuItem
        '
        Me.ConfigurarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColorPasoToolStripMenuItem, Me.ColorSecundarioPasoToolStripMenuItem, Me.ToolStripSeparator1, Me.ColorPasoAltToolStripMenuItem, Me.ColorSecundarioPasoAltToolStripMenuItem})
        Me.ConfigurarToolStripMenuItem.Name = "ConfigurarToolStripMenuItem"
        Me.ConfigurarToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ConfigurarToolStripMenuItem.Text = "Configurar"
        '
        'ColorPasoToolStripMenuItem
        '
        Me.ColorPasoToolStripMenuItem.Name = "ColorPasoToolStripMenuItem"
        Me.ColorPasoToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.ColorPasoToolStripMenuItem.Text = "Color Paso"
        '
        'ColorSecundarioPasoToolStripMenuItem
        '
        Me.ColorSecundarioPasoToolStripMenuItem.Name = "ColorSecundarioPasoToolStripMenuItem"
        Me.ColorSecundarioPasoToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.ColorSecundarioPasoToolStripMenuItem.Text = "Color Secundario Paso"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(205, 6)
        '
        'ColorPasoAltToolStripMenuItem
        '
        Me.ColorPasoAltToolStripMenuItem.Name = "ColorPasoAltToolStripMenuItem"
        Me.ColorPasoAltToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.ColorPasoAltToolStripMenuItem.Text = "Color Paso Alt"
        '
        'ColorSecundarioPasoAltToolStripMenuItem
        '
        Me.ColorSecundarioPasoAltToolStripMenuItem.Name = "ColorSecundarioPasoAltToolStripMenuItem"
        Me.ColorSecundarioPasoAltToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.ColorSecundarioPasoAltToolStripMenuItem.Text = "Color Secundario Paso Alt"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(227, 17)
        Me.ToolStripStatusLabel5.Spring = True
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Image = CType(resources.GetObject("ToolStripStatusLabel4.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(52, 17)
        Me.ToolStripStatusLabel4.Text = "Inicio:"
        '
        'ToolStripStatusLabel11
        '
        Me.ToolStripStatusLabel11.Name = "ToolStripStatusLabel11"
        Me.ToolStripStatusLabel11.Size = New System.Drawing.Size(19, 17)
        Me.ToolStripStatusLabel11.Text = "XX"
        '
        'ToolStripStatusLabel10
        '
        Me.ToolStripStatusLabel10.Image = CType(resources.GetObject("ToolStripStatusLabel10.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel10.Name = "ToolStripStatusLabel10"
        Me.ToolStripStatusLabel10.Size = New System.Drawing.Size(72, 17)
        Me.ToolStripStatusLabel10.Text = "Secadora:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel10, Me.ToolStripStatusLabel11, Me.ToolStripStatusLabel12, Me.ToolStripStatusLabel13, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel9, Me.ToolStripStatusLabel8, Me.ToolStripStatusLabel5, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 461)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StatusStrip1.Size = New System.Drawing.Size(1052, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel12
        '
        Me.ToolStripStatusLabel12.Image = CType(resources.GetObject("ToolStripStatusLabel12.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel12.Name = "ToolStripStatusLabel12"
        Me.ToolStripStatusLabel12.Size = New System.Drawing.Size(65, 17)
        Me.ToolStripStatusLabel12.Text = "Formula:"
        '
        'ToolStripStatusLabel13
        '
        Me.ToolStripStatusLabel13.Name = "ToolStripStatusLabel13"
        Me.ToolStripStatusLabel13.Size = New System.Drawing.Size(19, 17)
        Me.ToolStripStatusLabel13.Text = "XX"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(110, 17)
        Me.ToolStripStatusLabel3.Text = "XXXX-XX-XX XX:XX:XX"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Image = CType(resources.GetObject("ToolStripStatusLabel2.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(41, 17)
        Me.ToolStripStatusLabel2.Text = "Fin:"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(110, 17)
        Me.ToolStripStatusLabel1.Text = "XXXX-XX-XX XX:XX:XX"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Image = CType(resources.GetObject("ToolStripStatusLabel7.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(65, 17)
        Me.ToolStripStatusLabel7.Text = "Entrada:"
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
        Me.ToolStripStatusLabel9.Size = New System.Drawing.Size(55, 17)
        Me.ToolStripStatusLabel9.Text = "Salida:"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.AutoSize = False
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(17, 17)
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Chart1
        '
        ChartArea4.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea4)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart1.Location = New System.Drawing.Point(0, 24)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(1052, 437)
        Me.Chart1.TabIndex = 14
        Me.Chart1.Text = "Chart1"
        '
        'SetEntradaToolStripMenuItem
        '
        Me.SetEntradaToolStripMenuItem.Name = "SetEntradaToolStripMenuItem"
        Me.SetEntradaToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.SetEntradaToolStripMenuItem.Text = "Set Entrada"
        '
        'SetSalidaToolStripMenuItem
        '
        Me.SetSalidaToolStripMenuItem.Name = "SetSalidaToolStripMenuItem"
        Me.SetSalidaToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.SetSalidaToolStripMenuItem.Text = "Set Salida"
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 483)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form5"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents AnalizarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GraficaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoAdicionalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel11 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel10 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel9 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents VerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpacidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel12 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel13 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopiarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigurarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorPasoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorSecundarioPasoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorPasoAltToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorSecundarioPasoAltToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TempEntradaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PosicionValvToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TempSalidaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetEntradaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetSalidaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
