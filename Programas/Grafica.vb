Option Strict Off
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form

    'Dim cPuntos As Collection
	Dim sSQL As String
    Dim lFormula As Long
    Dim cCarga As Carga
    Dim cCargas As Collection


    Dim lMinutosActualizar As Long
    Dim lMinutosSinActualizar As Long

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim fGrafica As Form5
        Dim fDetGrafica As Form3
        Dim fDetPunto As Form2
        GuardarPosicion(Me)
        For Each fGrafica In cGraficas
            fGrafica.Close()
            fGrafica = Nothing
        Next fGrafica
        cGraficas = Nothing
        For Each fDetGrafica In cDetGrafica
            fDetGrafica.Close()
            fDetGrafica = Nothing
        Next fDetGrafica
        cDetGrafica = Nothing
        For Each fDetPunto In cDetPunto
            fDetPunto.Close()
            fDetPunto = Nothing
        Next fDetPunto
        cDetPunto = Nothing
        'SaveSetting("MonitorSecadoras", "Grafica", "AnchoGrafica", sAnchoGrafica.ToString)
        'SaveSetting("MonitorSecadoras", "Grafica", "InicioGrafica", sInicioGrafica.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "MinutosActualizar", lMinutosActualizar.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "ColorEntrada", lColorTempEntrada.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "ColorSalida", lColorTempSalida.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "ColorCarga", lColorCarga.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "ColorSecundarioCarga", lColorSecundarioCarga.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "ColorPaso", lColorPaso.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "ColorSecundarioPaso", lColorSecundarioPaso.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "ColorPasoAlt", lColorPasoAlt.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "ColorSecundarioPasoAlt", lColorSecundarioPasoAlt.ToString)


        SaveSetting("MonitorSecadoras", "Grafica", "NombreFuenteP", sNombreFuenteP)
        SaveSetting("MonitorSecadoras", "Grafica", "TamanioPequenio", lTamanioPequenio.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "NombreFuenteG", sNombreFuenteG)
        SaveSetting("MonitorSecadoras", "Grafica", "TamanioGrande", lTamanioGrande.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "Separador", sSeparador)
        SaveSetting("MonitorSecadoras", "Grafica", "Server", sServer)
        SaveSetting("MonitorSecadoras", "Grafica", "SecadoraActual", ToolStripComboBox1.Text)
        SaveSetting("MonitorSecadoras", "Grafica", "EsclavoActual", ToolStripStatusLabel11.Tag)
        SaveSetting("MonitorSecadoras", "Grafica", "VigilarTempEntrada", sVigilarTempEntrada)
        SaveSetting("MonitorSecadoras", "Grafica", "VigilarTempSalida", sVigilarTempSalida)
        SaveSetting("MonitorSecadoras", "Grafica", "RangoAceptable", lRangoAceptable.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "MinutosTempSalidaMantentenida", lMinutosTempSalidaMantenida.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "MinutosTempEntradaMantenida", lMinutosTempEntradaMantenida.ToString)
        SaveSetting("MonitorSecadoras", "Grafica", "EscalaFarenheit", -bEscalaFarenheit)
    End Sub
    Private Sub ActualizarMenuStrip()
        Try
            Select Case Me.Opacity.ToString("0.00")
                Case "1.00"
                    ToolStripMenuItem2.Checked = True
                    ToolStripMenuItem3.Checked = False
                    ToolStripMenuItem4.Checked = False
                    ToolStripMenuItem5.Checked = False
                Case "0.90"
                    ToolStripMenuItem2.Checked = False
                    ToolStripMenuItem3.Checked = True
                    ToolStripMenuItem4.Checked = False
                    ToolStripMenuItem5.Checked = False
                Case "0.80"
                    ToolStripMenuItem2.Checked = False
                    ToolStripMenuItem3.Checked = False
                    ToolStripMenuItem4.Checked = True
                    ToolStripMenuItem5.Checked = False
                Case "0.70"
                    ToolStripMenuItem2.Checked = False
                    ToolStripMenuItem3.Checked = False
                    ToolStripMenuItem4.Checked = False
                    ToolStripMenuItem5.Checked = True
                Case Else
                    ToolStripMenuItem2.Checked = False
                    ToolStripMenuItem3.Checked = False
                    ToolStripMenuItem4.Checked = False
                    ToolStripMenuItem5.Checked = False

            End Select
            If bEscalaFarenheit Then
                FarenheitToolStripMenuItem.Checked = True
                CentigradosToolStripMenuItem.Checked = False
            Else
                FarenheitToolStripMenuItem.Checked = False
                CentigradosToolStripMenuItem.Checked = True

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.AppStarting
        sServer = GetSetting("MonitorSecadoras", "Grafica", "Server", "manttocl")
        'sAnchoGrafica = Val(GetSetting("MonitorSecadoras", "Grafica", "AnchoGrafica", "0.93"))
        'sInicioGrafica = Val(GetSetting("MonitorSecadoras", "Grafica", "InicioGrafica", "0.05"))
        lMinutosActualizar = Val(GetSetting("MonitorSecadoras", "Grafica", "MinutosActualizar", "10"))
        lColorTempEntrada = Val(GetSetting("MonitorSecadoras", "Grafica", "ColorEntrada", "255"))
        lColorTempSalida = Val(GetSetting("MonitorSecadoras", "Grafica", "ColorSalida", "16711680"))
        lColorCarga = Val(GetSetting("MonitorSecadoras", "Grafica", "ColorCarga", "12632256"))
        lColorSecundarioCarga = Val(GetSetting("MonitorSecadoras", "Grafica", "ColorSecundarioCarga", "16777215"))
        lColorPaso = Val(GetSetting("MonitorSecadoras", "Grafica", "ColorPaso", "12632256"))
        lColorSecundarioPaso = Val(GetSetting("MonitorSecadoras", "Grafica", "ColorSecundarioPaso", "16777215"))
        lColorPasoAlt = Val(GetSetting("MonitorSecadoras", "Grafica", "ColorPasoAlt", "8421504"))
        lColorSecundarioPasoAlt = Val(GetSetting("MonitorSecadoras", "Grafica", "ColorSecundarioPasoAlt", "16777215"))



        sNombreFuenteP = GetSetting("MonitorSecadoras", "Grafica", "NombreFuenteP", "Verdana")
        lTamanioPequenio = Val(GetSetting("MonitorSecadoras", "Grafica", "TamanioPequenio", "7"))
        sNombreFuenteG = GetSetting("MonitorSecadoras", "Grafica", "NombreFuenteG", "Verdana")
        lTamanioGrande = Val(GetSetting("MonitorSecadoras", "Grafica", "TamanioGrande", "10"))

        sSeparador = GetSetting("MonitorSecadoras", "Grafica", "Separador", ", ")
        sVigilarTempEntrada = GetSetting("MonitorSecadoras", "Grafica", "VigilarTempEntrada", "198,480,600")
        sVigilarTempSalida = GetSetting("MonitorSecadoras", "Grafica", "VigilarTempSalida", "120,140,170,200")
        lRangoAceptable = Val(GetSetting("MonitorSecadoras", "Grafica", "RangoAceptable", "5"))                      'grados +/- para considerar que se mantiene la temperatura
        lMinutosTempSalidaMantenida = Val(GetSetting("MonitorSecadoras", "Grafica", "MinutosTempSalidaMantenida", "5"))           'minutos para considerar que se mantiene la temperatura 
        lMinutosTempEntradaMantenida = Val(GetSetting("MonitorSecadoras", "Grafica", "MinutosTempEntradaMantenida", "5"))          'minutos para considerar que se mantiene la temperatura 
        bEscalaFarenheit = -Val(GetSetting("MonitorSecadoras", "Grafica", "EscalaFarenheit", "1"))

        ColocarForm(Me)
        '       cFechaInicio = New Collection
        '        cFechaFin = New Collection
        cGraficas = New Collection
        cDetPunto = New Collection
        cDetGrafica = New Collection
        '      cEtiqueta = New Collection
        cCargas = New Collection
        'cBotones = New Collection
        'cIdPunto = New Collection
        'cPuntos = New Collection
        cEsclavos = New Collection
        RealizarConexion()
        Do
            iUsuario = IdUsuario()
        Loop Until iUsuario > 0
        ToolStripStatusLabel3.Text = Now.ToString("yyyy-MM-dd") & " 00:00:00"
        ToolStripStatusLabel1.Text = Now.ToString("yyyy-MM-dd") & " 23:59:59"
        PoblarComboSecadoras()

        ToolStripComboBox1.Text = GetSetting("MonitorSecadoras", "Grafica", "SecadoraActual", "10")
        ToolStripStatusLabel11.Tag = GetSetting("MonitorSecadoras", "Grafica", "EsclavoActual", "10")
        'ToolStripComboBox1.Text = ToolStripStatusLabel11.Text

        ActualizarMenuStrip()
        Me.Cursor = Cursors.Arrow
    End Sub





    Sub PoblarComboSecadoras()
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader

        sSQL = "SELECT esclavo,nombre FROM esclavos"
        mLector = Consulta(sSQL)
        ToolStripComboBox1.Items.Clear()
        cEsclavos.Clear()

        Do While mLector.Read
            ToolStripComboBox1.Items.Add(mLector.Item("nombre"))
            cEsclavos.Add(mLector.Item("esclavo"))
        Loop
        mLector.Close()
        ToolStripComboBox2.Text = ""

    End Sub


    Sub Graficar(ByRef lSecadora As Integer, ByRef sFechaInicio As String, ByRef sFechaFin As String)
        If BackgroundWorker1.IsBusy Then
        Else
            Chart1.Visible = False
            cCargas.Clear()

            Chart1.ChartAreas.Clear()
            Chart1.ChartAreas.Add("Grafica")

            Chart1.ChartAreas(0).CursorX.IsUserEnabled = True
            Chart1.ChartAreas(0).CursorX.IsUserSelectionEnabled = True

            'Chart1.ChartAreas(0).CursorX.
            Chart1.ChartAreas(0).AxisX.ScaleView.Zoomable = True
            Chart1.ChartAreas(0).AxisX.ScrollBar.IsPositionedInside = True
            Chart1.Annotations.Clear()
            Chart1.ChartAreas.Item(0).AxisX.StripLines.Clear()

            Chart1.Series.Clear()
            Chart1.Titles.Clear()
            Chart1.Series.Add("Temp1")
            Chart1.Series.Add("Temp2")
            Chart1.Series.Item("Temp1").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series.Item("Temp2").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series.Item("Temp1").MarkerStyle = DataVisualization.Charting.MarkerStyle.None
            Chart1.Series.Item("Temp2").MarkerStyle = DataVisualization.Charting.MarkerStyle.None
            Chart1.Series.Item("Temp1").BorderWidth = 3
            Chart1.Series.Item("Temp2").BorderWidth = 3
            Chart1.Series.Item("Temp1").XValueType = DataVisualization.Charting.ChartValueType.DateTime
            Chart1.Series.Item("Temp2").XValueType = DataVisualization.Charting.ChartValueType.DateTime
            Chart1.Series.Item("Temp1").IsXValueIndexed = True
            Chart1.Series.Item("Temp2").IsXValueIndexed = True
            Chart1.Series.Item("Temp1").Color = Drawing.ColorTranslator.FromOle(lColorTempEntrada)
            Chart1.Series.Item("Temp2").Color = Drawing.ColorTranslator.FromOle(lColorTempSalida)
            Chart1.Titles.Add("Secadora " & ToolStripStatusLabel11.Text)
            Chart1.Titles.Item(0).Font = New Font(sNombreFuenteP, lTamanioPequenio)
            Chart1.Titles.Add("Inicio: " & ToolStripStatusLabel3.Text & " Fin: " & ToolStripStatusLabel1.Text)
            Chart1.Titles.Item(1).Font = New Font(sNombreFuenteP, lTamanioPequenio)
            Chart1.Titles.Item(1).Docking = DataVisualization.Charting.Docking.Bottom
            Chart1.ChartAreas(0).AxisY.TitleFont = New Font(sNombreFuenteP, lTamanioPequenio)
            If bEscalaFarenheit Then
                Chart1.ChartAreas(0).AxisY.Title = "Temperatura �F"
            Else
                Chart1.ChartAreas(0).AxisY.Title = "Temperatura �C"
            End If
            Chart1.ChartAreas(0).AxisY.LabelStyle.Font = New Font(sNombreFuenteP, lTamanioPequenio)
            Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New Font(sNombreFuenteP, lTamanioPequenio)
            'Chart1.ChartAreas(0).AxisX.LabelStyle.IntervalType = DataVisualization.Charting.DateTimeIntervalType.Hours
            'Chart1.ChartAreas(0).AxisX.LabelStyle.Interval = 1
            'Chart1.ChartAreas(0).AxisX.LabelStyle.IntervalOffset = 0
            Chart1.ChartAreas(0).AxisX.LabelStyle.Format = "HH:mm:ss"
            'Chart1.ChartAreas(0).AxisX.LabelStyle.TruncatedLabels = True
            'Chart1.ChartAreas(0).AxisX.LabelStyle.IsStaggered = False
            'Chart1.ChartAreas(0).AxisX.IsInterlaced = False
            'Chart1.ChartAreas(0).AxisX.LabelStyle.TruncatedLabels = True
            'Chart1.ChartAreas(0).AxisX.LabelStyle.IntervalType = DataVisualization.Charting.DateTimeIntervalType.Hours

            'Chart1.ChartAreas(0).AxisX.LabelStyle.Interval
            Timer1.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            ToolStripComboBox2.Items.Clear()
            'cPuntos.Clear()
            BackgroundWorker1.RunWorkerAsync(lSecadora & sSeparador & sFechaInicio & sSeparador & sFechaFin)

        End If
    End Sub


    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim iContador As Integer
        Dim iCargas As Integer
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
        Dim lFormulaAnterior As Long
        Dim sSecadora As String
        Dim sFechaInicio As String
        Dim sFechaFin As String
        Dim sTemp() As String
        Dim bVentiladorTrabajando As Boolean
        Dim bQuemadorTrabajando As Boolean
        Dim bVentiladorTrabajandoAnterior As Boolean
        Dim lMinuto As Long
        Dim lMinutosDiferencia As Long
        Dim Punto As New PuntoGrafica
        Dim lTemp1Ant As Long
        Dim lTemp2Ant As Long
        Dim dHoraAnt As Date
        Dim m1 As Long
        Dim m2 As Long
        sTemp = Split(e.Argument, sSeparador)

        sSecadora = sTemp(0)
        sFechaInicio = sTemp(1)
        sFechaFin = sTemp(2)
        iContador = 0
        iCargas = 0
        lMinutosDiferencia = DateDiff(DateInterval.Minute, CDate(sFechaInicio), CDate(sFechaFin))
        If lMinutosDiferencia > 0 Then
            For lMinuto = 0 To lMinutosDiferencia
                Punto = Nothing
                Punto.Vacio = True
                sSQL = "SELECT id,fecha,temp1,temp2,formula,display,entrada1,entrada2 FROM lecturas where secadora=" & sSecadora & " and fecha >= date_add('" & sFechaInicio & "',interval " & lMinuto & " minute) and fecha < date_add('" & sFechaInicio & "',interval " & lMinuto + 1 & " minute)"
                mLector = Consulta(sSQL)
                Do While mLector.Read

                    Try

                        'cIdPunto.Add(mLector.Item("id"))
                        Punto.Id = mLector.Item("id")
                        Punto.Temp1 = Escala(mLector.Item("temp1"))
                        Punto.Temp2 = Escala(mLector.Item("temp2"))
                        Punto.Hora = CDate(mLector.Item("fecha"))
                        Punto.Etiqueta1 = ""
                        Punto.Etiqueta2 = ""
                        Punto.Vacio = False
                        Punto.Entrada1 = mLector.Item("entrada1")
                        Punto.Entrada2 = mLector.Item("entrada2")
                        bVentiladorTrabajando = Punto.Entrada1
                        bQuemadorTrabajando = Punto.Entrada2
                        Punto.Tooltip = "Hora:" & vbTab & (CDate(mLector.Item("fecha"))).ToString("HH:mm:ss") & vbCrLf & "Formula:" & vbTab & mLector.Item("formula").ToString & vbCrLf & "Temp entrada:" & vbTab & ValToTemp(mLector.Item("temp1")) & vbCrLf & "Temp salida:" & vbTab & ValToTemp(mLector.Item("temp2")) & vbCrLf & "Display:" & vbTab & mLector.Item("display") & vbCrLf & "Ventilador:" & vbTab & BoolToOnOff(mLector.Item("entrada1")) & vbCrLf & "Quemador:" & vbTab & BoolToOnOff(mLector.Item("entrada2"))
                        If bVentiladorTrabajando = True And bVentiladorTrabajandoAnterior = False Then
                            cCarga.Inicio = CDate(mLector.Item("fecha")).ToString("yyyy-MM-dd HH:mm:ss")
                            cCarga.IdInicio = iContador
                            lFormula = mLector.Item("formula")
                            cCarga.Formula = lFormula
                        End If

                        If bVentiladorTrabajando Then
                            If lFormula = 0 Then
                                lFormula = mLector.Item("formula")
                                cCarga.Formula = lFormula
                            End If

                        End If

                        If bVentiladorTrabajando = False And bVentiladorTrabajandoAnterior = True Then
                            iCargas = iCargas + 1
                            cCarga.Fin = CDate(mLector.Item("fecha")).ToString("yyyy-MM-dd HH:mm:ss")
                            cCarga.Duracion = LapsoTiempo(CDate(cCarga.Inicio), CDate(cCarga.Fin))
                            cCarga.IdFin = iContador
                            cCarga.Id = iCargas
                            cCargas.Add(cCarga)
                        End If
                        bVentiladorTrabajandoAnterior = bVentiladorTrabajando
                        lFormulaAnterior = lFormula
                    Catch

                    End Try
                    m1 = Math.Abs(Pendiente(Punto.Temp1, lTemp1Ant, Punto.Hora, dHoraAnt))
                    m2 = Math.Abs(Pendiente(Punto.Temp2, lTemp2Ant, Punto.Hora, dHoraAnt))
                    If m1 <> 0 Or m2 <> 0 Then
                        If m1 > 3 Then
                            Punto.Etiqueta1 = "Cambio temp" & vbCrLf & Math.Abs(Punto.Temp1 - lTemp1Ant) & Unidades() & " en " & (Punto.Hora - dHoraAnt).TotalSeconds & " seg"
                        End If
                        If m2 > 3 Then
                            Punto.Etiqueta2 = "Cambio temp" & vbCrLf & Math.Abs(Punto.Temp2 - lTemp2Ant) & Unidades() & " en " & (Punto.Hora - dHoraAnt).TotalSeconds & " seg"
                        End If
                        m1 = 0
                        m2 = 0
                    End If
                    lTemp1Ant = Punto.Temp1
                    lTemp2Ant = Punto.Temp2
                    dHoraAnt = Punto.Hora
                    iContador = iContador + 1
                    BackgroundWorker1.ReportProgress((lMinuto / lMinutosDiferencia) * 100, Punto)
                Loop
                mLector.Close()
                If Punto.Vacio Then
                    'cIdPunto.Add(0)
                    iContador = iContador + 1
                    Punto.Hora = CDate(DateAdd(DateInterval.Minute, lMinuto, CDate(sFechaInicio)))
                    BackgroundWorker1.ReportProgress((lMinuto / lMinutosDiferencia) * 100, Punto)
                End If
            Next lMinuto


        End If
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        Dim Punto As PuntoGrafica
        If e.ProgressPercentage <= 100 Then
            ToolStripProgressBar1.Value = e.ProgressPercentage
        End If
        Punto = e.UserState
        'cPuntos.Add(Punto)
        If Punto.Vacio Then
            Chart1.Series.Item("Temp1").Points.AddXY(Punto.Hora, 0)
            Chart1.Series.Item("Temp2").Points.AddXY(Punto.Hora, 0)
            Chart1.Series.Item("Temp1").Points.Item(Chart1.Series.Item("Temp1").Points.Count - 1).IsEmpty = True
            Chart1.Series.Item("Temp2").Points.Item(Chart1.Series.Item("Temp2").Points.Count - 1).IsEmpty = True
        Else
            Chart1.Series.Item("Temp1").Points.AddXY(Punto.Hora, Punto.Temp1)
            Chart1.Series.Item("Temp2").Points.AddXY(Punto.Hora, Punto.Temp2)
            'analizando
            'cuando el quemadoe esta inactivo poner linea punteada
            If Punto.Entrada2 = False Then
                Chart1.Series.Item("Temp1").Points.Item(Chart1.Series.Item("Temp1").Points.Count - 1).BorderWidth = 1
                Chart1.Series.Item("Temp2").Points.Item(Chart1.Series.Item("Temp2").Points.Count - 1).BorderWidth = 1
                'Chart1.Series.Item("Temp1").Points.Item(Chart1.Series.Item("Temp1").Points.Count - 1).BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
                'Chart1.Series.Item("Temp2").Points.Item(Chart1.Series.Item("Temp2").Points.Count - 1).BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
            End If

            Chart1.Series.Item("Temp1").Points.Item(Chart1.Series.Item("Temp1").Points.Count - 1).Tag = Punto.Id
            Chart1.Series.Item("Temp2").Points.Item(Chart1.Series.Item("Temp2").Points.Count - 1).Tag = Punto.Id
            Chart1.Series.Item("Temp1").Points.Item(Chart1.Series.Item("Temp1").Points.Count - 1).ToolTip = Punto.Tooltip
            Chart1.Series.Item("Temp2").Points.Item(Chart1.Series.Item("Temp2").Points.Count - 1).ToolTip = Punto.Tooltip
        End If
        If Len(Punto.Etiqueta1) Then
            Dim x As New System.Windows.Forms.DataVisualization.Charting.CalloutAnnotation

            x.Text = Punto.Etiqueta1
            x.Alignment = ContentAlignment.BottomCenter
            x.AnchorAlignment = ContentAlignment.BottomCenter
            x.LineWidth = 1
            x.CalloutStyle = DataVisualization.Charting.CalloutStyle.SimpleLine
            x.AllowSelecting = False
            x.ToolTip = Punto.Tooltip
            x.AnchorDataPoint = Chart1.Series.Item("Temp1").Points.Item(Chart1.Series.Item("Temp1").Points.Count - 1)
            x.Font = New Font(sNombreFuenteP, lTamanioPequenio)
            Chart1.Annotations.Add(x)
        End If
        If Len(Punto.Etiqueta2) Then
            Dim x As New System.Windows.Forms.DataVisualization.Charting.CalloutAnnotation
            x.Text = Punto.Etiqueta2
            x.Alignment = ContentAlignment.BottomCenter
            x.AnchorAlignment = ContentAlignment.BottomCenter
            x.LineWidth = 1
            x.CalloutStyle = DataVisualization.Charting.CalloutStyle.SimpleLine
            x.AllowSelecting = False
            x.ToolTip = Punto.Tooltip
            x.AnchorDataPoint = Chart1.Series.Item("Temp2").Points.Item(Chart1.Series.Item("Temp2").Points.Count - 1)
            x.Font = New Font(sNombreFuenteP, lTamanioPequenio)
            Chart1.Annotations.Add(x)
        End If

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Dim cCarga As Carga
        For Each cCarga In cCargas
            Dim y As New System.Windows.Forms.DataVisualization.Charting.StripLine
            y.Interval = 0
            y.IntervalOffset = cCarga.IdInicio
            y.StripWidth = cCarga.IdFin - cCarga.IdInicio

            'Chart1.ChartAreas(0).AxisX.CustomLabels.Add(cCarga.IdInicio, cCarga.IdFin, cCarga.Id.ToString, 1, DataVisualization.Charting.LabelMarkStyle.LineSideMark)

            y.BackGradientStyle = DataVisualization.Charting.GradientStyle.TopBottom
            y.BackColor = Drawing.ColorTranslator.FromOle(lColorCarga)
            y.BackSecondaryColor = Drawing.ColorTranslator.FromOle(lColorSecundarioCarga)
            y.Text = cCarga.Id
            y.TextAlignment = StringAlignment.Center
            y.TextOrientation = DataVisualization.Charting.TextOrientation.Horizontal
            y.ToolTip = "Carga:" & vbTab & cCarga.Id & vbCrLf & "Formula:" & vbTab & cCarga.Formula & vbCrLf & "Inicio:" & vbTab & cCarga.Inicio & vbCrLf & "Fin:" & vbTab & cCarga.Fin & vbCrLf & "Duracion:" & vbTab & cCarga.Duracion
            y.Font = New Font(sNombreFuenteP, lTamanioPequenio)
            Chart1.ChartAreas.Item(0).AxisX.StripLines.Add(y)
            ToolStripComboBox2.Items.Add(cCarga.Id & sSeparador & cCarga.Inicio & sSeparador & cCarga.Fin & sSeparador & cCarga.Formula)
            'ToolStripProgressBar1.Value = (cCarga.Id / cCargas.Count) * 100
            'Chart1.Update()
        Next
        ToolStripStatusLabel6.BackColor = Drawing.ColorTranslator.FromOle(lColorTempEntrada)
        ToolStripStatusLabel8.BackColor = Drawing.ColorTranslator.FromOle(lColorTempSalida)

        Me.Cursor = Cursors.Arrow

        Timer1.Enabled = True
        Chart1.Visible = True

    End Sub

    Private Sub FechaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FechaToolStripMenuItem.Click
        Form4.ShowDialog()
        If ToolStripStatusLabel11.Tag = 0 Then
        Else
            PoblarComboSecadoras()
            Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        End If
    End Sub

    Private Sub AnalizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalizarToolStripMenuItem.Click
        Dim fDetGrafica As New Form3
        cDetGrafica.Add(fDetGrafica)
        fDetGrafica.Tag = ToolStripStatusLabel11.Tag & sSeparador & ToolStripStatusLabel3.Text & sSeparador & ToolStripStatusLabel1.Text & sSeparador
        fDetGrafica.Show()
    End Sub

    Private Sub InfoAdicionalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoAdicionalToolStripMenuItem.Click
        infoadicional.ShowDialog()
    End Sub


    Private Sub CargaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargaToolStripMenuItem1.Click
        busqueda.Show()
    End Sub



    Private Sub ToolStripComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        ToolStripStatusLabel11.Text = ToolStripComboBox1.Text
        ToolStripStatusLabel11.Tag = cEsclavos(ToolStripComboBox1.SelectedIndex + 1)
        Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        ToolStripComboBox2.Text = ""
    End Sub



    Private Sub ToolStripComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox2.SelectedIndexChanged
        Dim fGrafica As New Form5
        Dim sSeccion() As String
        cGraficas.Add(fGrafica)
        sSeccion = Split(ToolStripComboBox2.Text, sSeparador)
        fGrafica.Tag = ToolStripStatusLabel11.Tag & sSeparador & sSeccion(1) & sSeparador & sSeccion(2) & sSeparador & sSeccion(3)
        fGrafica.Show()

    End Sub



    Private Sub ToolStripComboBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.Click

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        lMinutosSinActualizar = lMinutosSinActualizar + 1
        If lMinutosSinActualizar >= lMinutosActualizar Then
            If ToolStripStatusLabel11.Tag = 0 Then
                Chart1.Visible = False
            Else
                If CDate(ToolStripStatusLabel1.Text) > Now Then
                    Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
                End If
                lMinutosSinActualizar = 0
            End If
        End If
    End Sub

    Private Sub ToolStripComboBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox2.Click

    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Me.Opacity = 0.7
        ActualizarMenuStrip()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Me.Opacity = 0.8
        ActualizarMenuStrip()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Me.Opacity = 0.9
        ActualizarMenuStrip()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Me.Opacity = 1
        ActualizarMenuStrip()
    End Sub

    Private Sub ToolStripStatusLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel3.Click
        Dim fFechaHora As New Form6
        fFechaHora.DateTimePicker1.Value = ToolStripStatusLabel3.Text
        fFechaHora.DateTimePicker2.Value = ToolStripStatusLabel3.Text
        fFechaHora.ShowDialog()
        If fFechaHora.Tag = True Then
            ToolStripStatusLabel3.Text = fFechaHora.DateTimePicker1.Value.ToString("yyyy-MM-dd") & " " & fFechaHora.DateTimePicker2.Value.ToString("HH:mm:ss")
            Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        End If
    End Sub

    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        Dim fFechaHora As New Form6
        fFechaHora.DateTimePicker1.Value = ToolStripStatusLabel1.Text
        fFechaHora.DateTimePicker2.Value = ToolStripStatusLabel1.Text
        fFechaHora.ShowDialog()
        If fFechaHora.Tag = True Then
            ToolStripStatusLabel1.Text = fFechaHora.DateTimePicker1.Value.ToString("yyyy-MM-dd") & " " & fFechaHora.DateTimePicker2.Value.ToString("HH:mm:ss")
            Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        End If
    End Sub

    Private Sub ColorTempEntradaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorTempEntradaToolStripMenuItem.Click
        ColorDialog1.Color = Drawing.ColorTranslator.FromOle(lColorTempEntrada)
        If ColorDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            lColorTempEntrada = Drawing.ColorTranslator.ToOle(ColorDialog1.Color)
            Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        End If
    End Sub

    Private Sub ColorTempSalidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorTempSalidaToolStripMenuItem.Click
        ColorDialog1.Color = Drawing.ColorTranslator.FromOle(lColorTempSalida)
        If ColorDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            lColorTempSalida = Drawing.ColorTranslator.ToOle(ColorDialog1.Color)
            Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        End If

    End Sub

    Private Sub FuenteGraficaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FuenteGraficaToolStripMenuItem.Click

        FontDialog1.Font = New Font(sNombreFuenteP, lTamanioPequenio)
        If FontDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            sNombreFuenteP = FontDialog1.Font.Name
            lTamanioPequenio = FontDialog1.Font.Size
            Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        End If
    End Sub

    Private Sub ToolStripStatusLabel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel6.Click
        '        AxMSChart1.Select()
        '        AxMSChart1.Plot.SeriesCollection.Item(1).Select()
    End Sub

    Private Sub ToolStripStatusLabel8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel8.Click

        '       AxMSChart1.Select()
        '       AxMSChart1.Plot.SeriesCollection.Item(2).Select()

    End Sub

    Private Sub CentigradosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CentigradosToolStripMenuItem.Click
        bEscalaFarenheit = False
        ActualizarMenuStrip()
    End Sub

    Private Sub FarenheitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FarenheitToolStripMenuItem.Click
        bEscalaFarenheit = True
        ActualizarMenuStrip()
    End Sub

    Private Sub FuenteAnalisisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FuenteAnalisisToolStripMenuItem.Click

        FontDialog1.Font = New Font(sNombreFuenteG, lTamanioGrande)
        If FontDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            sNombreFuenteG = FontDialog1.Font.Name
            lTamanioGrande = FontDialog1.Font.Size

        End If

    End Sub

    Private Sub ActualizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarToolStripMenuItem.Click
        If CDate(ToolStripStatusLabel1.Text) > Now And ToolStripStatusLabel11.Tag > 0 Then
            Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
            lMinutosSinActualizar = 0
        End If
    End Sub

    Private Sub Chart1_AxisViewChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataVisualization.Charting.ViewEventArgs) Handles Chart1.AxisViewChanged
        Dim sInicio As String
        Dim sFin As String
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
        If Double.IsNaN(e.NewPosition) Then
            Chart1.Titles.Item(1).Text = ""
        Else
            sInicio = ""
            sFin = ""

            sSQL = "SELECT fecha FROM lecturas where secadora=" & ToolStripStatusLabel11.Tag & " and id=" & Chart1.Series.Item("Temp1").Points.Item(e.NewPosition - 1).Tag & ""
            mLector = Consulta(sSQL)
            Do While mLector.Read
                sInicio = CDate(mLector.Item("fecha")).ToString("yyyy-MM-dd HH:mm:ss")
            Loop
            mLector.Close()
            sSQL = "SELECT fecha FROM lecturas where secadora=" & ToolStripStatusLabel11.Tag & " and id=" & Chart1.Series.Item("Temp1").Points.Item(e.NewPosition + e.NewSize - 1).Tag & ""
            mLector = Consulta(sSQL)
            Do While mLector.Read
                sFin = CDate(mLector.Item("fecha")).ToString("yyyy-MM-dd HH:mm:ss")
            Loop
            mLector.Close()


            Chart1.Titles.Item(1).Text = "Inicio: " & sInicio & " Fin: " & sFin
        End If

    End Sub

    Private Sub ExportarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarToolStripMenuItem.Click
        SaveFileDialog1.Filter = "Imagen JPG|*.jpg"
        SaveFileDialog1.FileName = "Secadora " & Replace(ToolStripStatusLabel11.Text & " " & ToolStripStatusLabel3.Text & " " & ToolStripStatusLabel1.Text, ":", "_") & ".jpg"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            SaveFileDialog1.FileName = ""
        Else
            Chart1.SaveImage(SaveFileDialog1.FileName, DataVisualization.Charting.ChartImageFormat.Jpeg)
        End If
    End Sub



    Private Sub Chart1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chart1.Click

    End Sub

    Private Sub Chart1_CursorPositionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataVisualization.Charting.CursorEventArgs) Handles Chart1.CursorPositionChanged
        Dim iPosicion As Integer
        Dim mVentana As Mensaje
        If Double.IsNaN(e.NewPosition) Then
        Else

            iPosicion = CInt(e.NewPosition - 1)
            If iPosicion >= 0 And iPosicion <= Chart1.Series.Item("Temp1").Points.Count - 1 Then
                Dim fDetPunto As New Form2
                Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
                mVentana.Ventana = Me
                'mVentana.Puntos = cPuntos
                mVentana.Esclavo = ToolStripStatusLabel11.Tag
                fDetPunto.Tag = mVentana
                cDetPunto.Add(fDetPunto)
                fDetPunto.Text1(0).Text = iPosicion
                sSQL = "SELECT id,fecha,secadora,temp1,temp2,formula,display,entrada1,entrada2,version FROM lecturas where secadora=" & ToolStripStatusLabel11.Tag & " and id=" & Chart1.Series.Item("Temp1").Points.Item(iPosicion).Tag & ""
                mLector = Consulta(sSQL)
                Do While mLector.Read
                    fDetPunto.Text1(1).Text = mLector.Item("id")
                    fDetPunto.Text1(2).Text = CDate(mLector.Item("fecha")).ToString("yyyy-MM-dd HH:mm:ss")
                    fDetPunto.Text1(3).Text = mLector.Item("secadora")
                    fDetPunto.Text1(4).Text = ValToTemp(mLector.Item("temp1"))       'temp entrada
                    fDetPunto.Text1(5).Text = ValToTemp(mLector.Item("temp2"))       'temp salida
                    fDetPunto.Text1(6).Text = mLector.Item("formula")
                    fDetPunto.Text1(7).Text = mLector.Item("display")

                    fDetPunto.Text1(8).Text = BoolToOnOff(mLector.Item("entrada1"))

                    fDetPunto.Text1(9).Text = BoolToOnOff(mLector.Item("entrada2"))
                    fDetPunto.Text1(10).Text = (CInt(mLector.Item("version")) / 100).ToString("0.00")

                    fDetPunto.Text = "Sec " & ToolStripStatusLabel11.Text & " @ " & fDetPunto.Text1(2).Text
                Loop
                fDetPunto.Show()
                mLector.Close()
                'iPosicion
            End If
            'MsgBox(e.NewPosition)
            'MsgBox(Chart1.ChartAreas(0).CursorX.Position)
        End If
    End Sub



    Private Sub CopiarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarToolStripMenuItem.Click
        Dim mImagen As New IO.MemoryStream
        Chart1.SaveImage(mImagen, DataVisualization.Charting.ChartImageFormat.Bmp)
        Dim bImagen As New Bitmap(mImagen)
        Clipboard.SetImage(bImagen)
    End Sub

    Private Sub ColorCargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorCargaToolStripMenuItem.Click
        ColorDialog1.Color = Drawing.ColorTranslator.FromOle(lColorCarga)
        If ColorDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            lColorCarga = Drawing.ColorTranslator.ToOle(ColorDialog1.Color)
            Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        End If

    End Sub

    Private Sub ColorSecundarioCargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorSecundarioCargaToolStripMenuItem.Click
        ColorDialog1.Color = Drawing.ColorTranslator.FromOle(lColorSecundarioCarga)
        If ColorDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            lColorSecundarioCarga = Drawing.ColorTranslator.ToOle(ColorDialog1.Color)
            Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        End If

    End Sub

   

    Private Sub Chart1_PostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs) Handles Chart1.PostPaint

        ToolStripProgressBar1.Value = 0
    End Sub

End Class