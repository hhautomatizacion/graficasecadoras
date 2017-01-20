Public Class Form5
    Dim cPasos As Collection
    Dim sComentario As String
    Dim bValvVisible As Boolean
    Dim bTemp1Visible As Boolean
    Dim bTemp2Visible As Boolean
    Dim bSet1Visible As Boolean
    Dim bSet2Visible As Boolean

    Private Sub Form5_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'GuardarPosicion(Me)
        If Me.WindowState = FormWindowState.Minimized Then
        Else
            SaveSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Opacidad", Me.Opacity.ToString)
            SaveSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Estado", Me.WindowState.ToString)
            SaveSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Top", Me.Top)
            SaveSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Left", Me.Left)
            SaveSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Width", Me.Width)
            SaveSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Height", Me.Height)
        End If

        SaveSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Temp1Visible", -bTemp1Visible)
        SaveSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Temp2Visible", -bTemp2Visible)
        SaveSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Set1Visible", -bSet1Visible)
        SaveSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Set2Visible", -bSet2Visible)
        SaveSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "ValvVisible", -bValvVisible)

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
        Catch ex As Exception

        End Try

        TempEntradaToolStripMenuItem.Checked = bTemp1Visible
        TempSalidaToolStripMenuItem.Checked = bTemp2Visible
        SetEntradaToolStripMenuItem.Checked = bSet1Visible
        SetSalidaToolStripMenuItem.Checked = bSet2Visible
        PosicionValvToolStripMenuItem.Checked = bValvVisible
    End Sub
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sTemp() As String
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
        Dim iTop As Integer
        Dim iLeft As Integer
        Dim iWidth As Integer
        Dim iHeight As Integer
        Dim sOpacidad As Single

        sTemp = Split(Me.Tag.ToString, sSeparador)
        mLector = Consulta("SELECT nombre FROM esclavos WHERE esclavo=" & sTemp(0))
        If mLector.Read Then
            ToolStripStatusLabel11.Text = mLector.Item("nombre")
            ToolStripStatusLabel11.Tag = sTemp(0)
        End If
        mLector.Close()


        sOpacidad = Val(GetSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Opacidad", "1"))
        iTop = Val(GetSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Top", "0"))
        iLeft = Val(GetSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Left", "0"))
        iWidth = Val(GetSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Width", "800"))
        iHeight = Val(GetSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Height", "300"))
        If iLeft > System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - iWidth Then iLeft = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - iWidth
        If iTop > System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - iHeight Then iTop = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - iHeight
        If iLeft < 0 Then iLeft = 0
        If iTop < 0 Then iTop = 0
        Me.Opacity = sOpacidad
        If GetSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Estado", "Normal") = "Normal" Then
            Me.Top = iTop
            Me.Left = iLeft
            Me.Width = iWidth
            Me.Height = iHeight
        Else
            Me.WindowState = FormWindowState.Maximized
        End If



        cPasos = New Collection
        'ColocarForm(Me)

        bTemp1Visible = -Val(GetSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Temp1Visible", "1"))
        bTemp2Visible = -Val(GetSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Temp2Visible", "1"))
        bSet1Visible = -Val(GetSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Set1Visible", "1"))
        bSet2Visible = -Val(GetSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "Set2Visible", "1"))
        bValvVisible = -Val(GetSetting("MonitorSecadoras", "Grafica" & ToolStripStatusLabel11.Text, "ValvVisible", "1"))

        ToolStripStatusLabel3.Text = sTemp(1)
        ToolStripStatusLabel1.Text = sTemp(2)
        ToolStripStatusLabel13.Text = sTemp(3)
        Me.Text = "Secadora " & ToolStripStatusLabel11.Text & sSeparador & "(" & sTemp(1) & " - " & sTemp(2) & ")"
        Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        ActualizarMenuStrip()
    End Sub
    Sub Graficar(ByRef sSecadora As String, ByRef sFechaInicio As String, ByRef sFechaFin As String)
        If BackgroundWorker1.IsBusy Then
        Else
            Chart1.Visible = False
            Chart1.ChartAreas.Clear()
            Chart1.Series.Clear()
            Chart1.Titles.Clear()
            Chart1.ChartAreas.Add("Grafica")
            Chart1.ChartAreas(0).CursorX.IsUserEnabled = True
            Chart1.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
            Chart1.ChartAreas(0).AxisX.ScaleView.Zoomable = True
            Chart1.ChartAreas(0).AxisX.ScrollBar.IsPositionedInside = True


            Chart1.Series.Add("Set1")
            Chart1.Series.Add("Set2")
            Chart1.Series.Add("Valv")
            Chart1.Series.Add("Temp1")
            Chart1.Series.Add("Temp2")

            Chart1.Series.Item("Temp1").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series.Item("Temp2").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series.Item("Set1").ChartType = DataVisualization.Charting.SeriesChartType.Range
            Chart1.Series.Item("Set2").ChartType = DataVisualization.Charting.SeriesChartType.Range
            Chart1.Series.Item("Valv").ChartType = DataVisualization.Charting.SeriesChartType.Line

            Chart1.Series.Item("Temp1").BorderWidth = 3
            Chart1.Series.Item("Temp2").BorderWidth = 3
            Chart1.Series.Item("Valv").BorderWidth = 3


            Chart1.Series.Item("Temp1").Color = Drawing.ColorTranslator.FromOle(lColorTempEntrada)
            Chart1.Series.Item("Temp2").Color = Drawing.ColorTranslator.FromOle(lColorTempSalida)
            Chart1.Series.Item("Valv").Color = Drawing.ColorTranslator.FromOle(lColorValvula)
            Chart1.Series.Item("Set1").Color = Drawing.ColorTranslator.FromOle(lColorset)
            Chart1.Series.Item("Set2").Color = Drawing.ColorTranslator.FromOle(lColorset)

            Chart1.Titles.Add("Secadora " & ToolStripStatusLabel11.Text)
            Chart1.Titles.Item(0).Font = New Font(sNombreFuenteP, lTamanioPequenio)
            Chart1.Titles.Add("Inicio: " & ToolStripStatusLabel3.Text & " Fin: " & ToolStripStatusLabel1.Text)
            Chart1.Titles.Item(1).Font = New Font(sNombreFuenteP, lTamanioPequenio)
            Chart1.Titles.Item(1).Docking = DataVisualization.Charting.Docking.Bottom
            Chart1.ChartAreas(0).AxisY.TitleFont = New Font(sNombreFuenteP, lTamanioPequenio)
            If bEscalaFarenheit Then
                Chart1.ChartAreas(0).AxisY.Maximum = lMaximoGrafica + (4 * lRangoAceptable)
                Chart1.ChartAreas(0).AxisY.Title = "Temperatura °F"
            Else
                Chart1.ChartAreas(0).AxisY.Maximum = Escala(lMaximoGrafica + (4 * lRangoAceptable))
                Chart1.ChartAreas(0).AxisY.Title = "Temperatura °C"
            End If
            ToolStripProgressBar1.Maximum = DateDiff(DateInterval.Minute, CDate(sFechaInicio), CDate(sFechaFin))

            Chart1.ChartAreas(0).AxisY.LabelStyle.Font = New Font(sNombreFuenteP, lTamanioPequenio)
            Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New Font(sNombreFuenteP, lTamanioPequenio)
            Me.Cursor = Cursors.WaitCursor
            BackgroundWorker1.RunWorkerAsync(sSecadora & sSeparador & sFechaInicio & sSeparador & sFechaFin)
        End If
    End Sub


    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim iContador As Integer
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
        Dim lPaso As Long
        Dim lPasoTemp As Long
        Dim lPasoAnterior As Long
        Dim pPaso As Paso
        Dim sSecadora As String
        Dim sFechaInicio As String
        Dim sFechaFin As String
        Dim sTemp() As String
        Dim sSQL As String
        Dim Punto As New PuntoGrafica
        Dim lMinuto As Long
        Dim lMinutosDiferencia As Long
        Dim lTemp1Ant As Long
        Dim lTemp2Ant As Long
        Dim dHoraAnt As Date
        Dim m2 As Long
        Dim m1 As Long
        Dim lFormula As Integer
        Dim lTimeStamp As Long
        Dim lAnteriorTimeStamp As Long
        Dim iIter As Integer

        sTemp = Split(e.Argument, sSeparador)
        sSecadora = sTemp(0)
        sFechaInicio = sTemp(1)
        sFechaFin = sTemp(2)
        iContador = 0
        pPaso = New Paso

        '       cPasos.Add(pPaso)
        'pPaso.Inicio = CDate(sFechaInicio).ToString("HH:mm:ss")
        'pPaso.IdInicio = 0
        lMinutosDiferencia = DateDiff(DateInterval.Minute, CDate(sFechaInicio), CDate(sFechaFin))
        lAnteriorTimeStamp = Long.MaxValue - 1
        lMinuto = 0
        If lMinutosDiferencia > 0 Then
            'For lMinuto = 0 To lMinutosDiferencia
            Punto = Nothing
            Punto.Vacio = True
            sSQL = "SELECT id,fecha, (TO_SECONDS(fecha) DIV 60) AS ts,temp1,temp2,formula,display,entrada1,entrada2 FROM lecturas WHERE secadora=" & sSecadora & " AND fecha >= '" & sFechaInicio & "' AND fecha <= '" & sFechaFin & "'"
            Debug.Print(sSQL)
            mLector = Consulta(sSQL)
            Do While mLector.Read
                Punto.Vacio = False
                Punto.Etiqueta1 = ""
                Punto.Etiqueta2 = ""
                Try
                    lTimeStamp = Val(mLector.Item("ts"))
                    If lTimeStamp > lAnteriorTimeStamp Then
                        lMinuto = lMinuto + 1
                    End If
                    If lTimeStamp > lAnteriorTimeStamp + 1 Then
                        For iIter = lAnteriorTimeStamp + 1 To lTimeStamp
                            Punto.Vacio = True
                            Punto.Hora = DateAdd(DateInterval.Minute, iContador, CDate(sFechaInicio))
                            BackgroundWorker1.ReportProgress(lMinuto, Punto)
                            iContador = iContador + 1
                            lMinuto = lMinuto + 1
                        Next
                        Punto.Vacio = False
                    End If
                    Punto.Id = mLector.Item("id")
                    Punto.Temp1 = Escala(mLector.Item("temp1"))
                    Punto.Temp2 = Escala(mLector.Item("temp2"))
                    Punto.Entrada1 = mLector.Item("entrada1")
                    Punto.Entrada2 = mLector.Item("entrada2")
                    Punto.Hora = (CDate(mLector.Item("fecha")))
                    lPasoTemp = ObtenerPaso(mLector.Item("display"))
                    Punto.Valv = ObtenerValv(mLector.Item("display"))
                    If lPasoTemp <> 0 Then
                        lPaso = lPasoTemp
                    End If
                    If CBool(mLector.Item("entrada1")) = False Then
                        lPaso = 0
                    End If
                    Punto.Paso = lPaso
                    If lFormula = 0 Then
                        lFormula = mLector.Item("formula")
                    End If
                    Punto.Formula = lFormula
                    Punto.Tooltip = "Hora:" & vbTab & (CDate(mLector.Item("fecha"))).ToString("HH:mm:ss") & vbCrLf & "Formula:" & vbTab & mLector.Item("formula").ToString & vbCrLf & "Temp entrada:" & vbTab & ValToTemp(mLector.Item("temp1")) & vbCrLf & "Temp salida:" & vbTab & ValToTemp(mLector.Item("temp2")) & vbCrLf & "Display:" & vbTab & mLector.Item("display") & vbCrLf & "Ventilador:" & vbTab & BoolToOnOff(mLector.Item("ENTRADA1")) & vbCrLf & "Quemador:" & vbTab & BoolToOnOff(mLector.Item("ENTRADA2"))
                    'If iContador = 0 Then
                    'pPaso.IdInicio = 0
                    'pPaso.Inicio = Punto.Hora.ToString("HH:mm:ss")
                    'End If
                    '                 cPasos.Item(cPasos.Count).id = lPaso
                    '                cPasos.Item(cPasos.Count).idfin = iContador
                    '               cPasos.Item(cPasos.Count).fin = Punto.Hora.ToString("HH:mm:ss")

                    If lPaso <> lPasoAnterior Then
                        '           Debug.Print(lPaso & " ," & lPasoAnterior)
                        pPaso.Id = lPasoAnterior
                        pPaso.IdFin = iContador
                        pPaso.Fin = dHoraAnt.ToString("HH:mm:ss")
                        pPaso.Duracion = LapsoTiempo(CDate(pPaso.Inicio), CDate(pPaso.Fin))

                        cPasos.Add(pPaso)
                        pPaso = New Paso
                        'cPasos.Item(cPasos.Count).inicio = Punto.Hora.ToString("HH:mm:ss")
                        'cPasos.Item(cPasos.Count).idinicio = iContador
                        'cPasos.Item(cPasos.Count).inicio = Punto.Hora.ToString("HH:mm:ss")
                        pPaso.IdInicio = iContador
                        pPaso.Inicio = Punto.Hora.ToString("HH:mm:ss")
                        lPasoAnterior = lPaso

                    End If
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
                BackgroundWorker1.ReportProgress(lMinuto, Punto)
                'If lTimeStamp > lAnteriorTimeStamp Then
                iContador = iContador + 1
                'End If
                lAnteriorTimeStamp = lTimeStamp
            Loop
            mLector.Close()

            'If Punto.Vacio Then
            'iContador = iContador + 1
            'Punto.Hora = DateAdd(DateInterval.Minute, lMinuto, CDate(sFechaInicio))
            'BackgroundWorker1.ReportProgress((lMinuto / lMinutosDiferencia) * 100, Punto)
            'End If
            'Next lMinuto
        End If
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Dim Punto As PuntoGrafica
        Dim iSet As Integer
        Dim iLimSup As Integer
        Dim iLimInf As Integer

        Debug.Print(e.ProgressPercentage & "/" & ToolStripProgressBar1.Maximum)
        If e.ProgressPercentage <= ToolStripProgressBar1.Maximum Then
            ToolStripProgressBar1.Value = e.ProgressPercentage
        End If
        Punto = e.UserState
        If Punto.Vacio Then

            Chart1.Series.Item("Temp1").Points.AddY(0)
            Chart1.Series.Item("Temp2").Points.AddY(0)
            Chart1.Series.Item("Set1").Points.AddY(0)
            Chart1.Series.Item("Set2").Points.AddY(0)
            Chart1.Series.Item("Valv").Points.AddY(0)

            Chart1.Series.Item("Temp1").Points.Item(Chart1.Series.Item("Temp1").Points.Count - 1).AxisLabel = Punto.Hora.ToString("HH:mm:ss")
            Chart1.Series.Item("Temp2").Points.Item(Chart1.Series.Item("Temp2").Points.Count - 1).AxisLabel = Punto.Hora.ToString("HH:mm:ss")
            Chart1.Series.Item("Set1").Points.Item(Chart1.Series.Item("Set2").Points.Count - 1).AxisLabel = Punto.Hora.ToString("HH:mm:ss")
            Chart1.Series.Item("Set2").Points.Item(Chart1.Series.Item("Set2").Points.Count - 1).AxisLabel = Punto.Hora.ToString("HH:mm:ss")
            Chart1.Series.Item("Valv").Points.Item(Chart1.Series.Item("Valv").Points.Count - 1).AxisLabel = Punto.Hora.ToString("HH:mm:ss")

            Chart1.Series.Item("Temp1").Points.Item(Chart1.Series.Item("Temp1").Points.Count - 1).IsEmpty = True
            Chart1.Series.Item("Temp2").Points.Item(Chart1.Series.Item("Temp2").Points.Count - 1).IsEmpty = True
            Chart1.Series.Item("Set1").Points.Item(Chart1.Series.Item("Set2").Points.Count - 1).IsEmpty = True
            Chart1.Series.Item("Set2").Points.Item(Chart1.Series.Item("Set2").Points.Count - 1).IsEmpty = True
            Chart1.Series.Item("Valv").Points.Item(Chart1.Series.Item("Valv").Points.Count - 1).IsEmpty = True
        Else
            Chart1.Series.Item("Temp1").Points.AddXY(Punto.Hora.ToString("HH:mm:ss"), Punto.Temp1)
            Chart1.Series.Item("Temp2").Points.AddXY(Punto.Hora.ToString("HH:mm:ss"), Punto.Temp2)

            'quitar este if
            If Punto.Valv < 4000 Then
                Chart1.Series.Item("Valv").Points.AddXY(Punto.Hora.ToString("HH:mm:ss"), Escala(lMaximoGrafica) * Punto.Valv / 4000)
            Else
                Chart1.Series.Item("Valv").Points.AddXY(Punto.Hora.ToString("HH:mm:ss"), 0)
            End If

            If cFormulasTempEntrada.Contains(Punto.Formula.ToString & "," & Punto.Paso.ToString) Then
                iSet = Escala(Val(cFormulasTempEntrada(Punto.Formula.ToString & "," & Punto.Paso.ToString)))
                iLimSup = Escala(Val(cFormulasTempEntrada(Punto.Formula.ToString & "," & Punto.Paso.ToString)) + lRangoAceptable)
                iLimInf = Escala(Val(cFormulasTempEntrada(Punto.Formula.ToString & "," & Punto.Paso.ToString)) - lRangoAceptable)
                Chart1.Series.Item("Set1").Points.AddXY(Punto.Hora.ToString("HH:mm:ss"), iSet)
                Chart1.Series.Item("Set1").Points.Item(Chart1.Series.Item("Set1").Points.Count - 1).SetValueY(iLimSup, iLimInf)
            Else
                Chart1.Series.Item("Set1").Points.AddY(0)
                Chart1.Series.Item("Set1").Points.Item(Chart1.Series.Item("Set1").Points.Count - 1).IsEmpty = True
            End If
            If cFormulasTempSalida.Contains(Punto.Formula.ToString & "," & Punto.Paso.ToString) Then
                iSet = Escala(Val(cFormulasTempSalida(Punto.Formula.ToString & "," & Punto.Paso.ToString)))
                iLimSup = Escala(Val(cFormulasTempSalida(Punto.Formula.ToString & "," & Punto.Paso.ToString)) + lRangoAceptable)
                iLimInf = Escala(Val(cFormulasTempSalida(Punto.Formula.ToString & "," & Punto.Paso.ToString)) - lRangoAceptable)
                Chart1.Series.Item("Set2").Points.AddXY(Punto.Hora.ToString("HH:mm:ss"), iSet)
                Chart1.Series.Item("Set2").Points.Item(Chart1.Series.Item("Set2").Points.Count - 1).SetValueY(iLimSup, iLimInf)
            Else
                Chart1.Series.Item("Set2").Points.AddY(0)
                Chart1.Series.Item("Set2").Points.Item(Chart1.Series.Item("Set2").Points.Count - 1).IsEmpty = True
            End If

            If Punto.Entrada2 = False Then
                Chart1.Series.Item("Temp1").Points.Item(Chart1.Series.Item("Temp1").Points.Count - 1).BorderWidth = 1
                Chart1.Series.Item("Temp2").Points.Item(Chart1.Series.Item("Temp2").Points.Count - 1).BorderWidth = 1
            End If
            Chart1.Series.Item("Temp1").Points.Item(Chart1.Series.Item("Temp1").Points.Count - 1).Tag = Punto.Id
            Chart1.Series.Item("Temp2").Points.Item(Chart1.Series.Item("Temp2").Points.Count - 1).Tag = Punto.Id
            Chart1.Series.Item("Temp1").Points.Item(Chart1.Series.Item("Temp1").Points.Count - 1).ToolTip = Punto.Tooltip
            Chart1.Series.Item("Temp2").Points.Item(Chart1.Series.Item("Temp2").Points.Count - 1).ToolTip = Punto.Tooltip
            Chart1.Series.Item("Valv").Points.Item(Chart1.Series.Item("Valv").Points.Count - 1).ToolTip = Punto.Tooltip
        End If
            If Len(Punto.Etiqueta1) Then
                Using aAnotacionTemp1 As New System.Windows.Forms.DataVisualization.Charting.CalloutAnnotation
                    aAnotacionTemp1.Text = Punto.Etiqueta1
                    aAnotacionTemp1.Alignment = ContentAlignment.BottomCenter
                    aAnotacionTemp1.AnchorAlignment = ContentAlignment.BottomCenter
                    aAnotacionTemp1.LineWidth = 1
                    aAnotacionTemp1.CalloutStyle = DataVisualization.Charting.CalloutStyle.SimpleLine
                    aAnotacionTemp1.AllowSelecting = False
                    aAnotacionTemp1.ToolTip = Punto.Tooltip
                    aAnotacionTemp1.AnchorDataPoint = Chart1.Series.Item("Temp1").Points.Item(Chart1.Series.Item("Temp1").Points.Count - 1)
                    aAnotacionTemp1.Font = New Font(sNombreFuenteP, lTamanioPequenio)
                    Chart1.Annotations.Add(aAnotacionTemp1)
                End Using
            End If
            If Len(Punto.Etiqueta2) Then
                Using aAnotacionTemp2 As New System.Windows.Forms.DataVisualization.Charting.CalloutAnnotation
                    aAnotacionTemp2.Text = Punto.Etiqueta2
                    aAnotacionTemp2.Alignment = ContentAlignment.BottomCenter
                    aAnotacionTemp2.AnchorAlignment = ContentAlignment.BottomCenter
                    aAnotacionTemp2.LineWidth = 1
                    aAnotacionTemp2.CalloutStyle = DataVisualization.Charting.CalloutStyle.SimpleLine
                    aAnotacionTemp2.AllowSelecting = False
                    aAnotacionTemp2.ToolTip = Punto.Tooltip
                    aAnotacionTemp2.AnchorDataPoint = Chart1.Series.Item("Temp2").Points.Item(Chart1.Series.Item("Temp2").Points.Count - 1)
                    aAnotacionTemp2.Font = New Font(sNombreFuenteP, lTamanioPequenio)
                    Chart1.Annotations.Add(aAnotacionTemp2)
                End Using
            End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Dim pPaso As Paso

        For Each pPaso In cPasos
            'Debug.Print(pPaso.Id & " " & pPaso.Inicio & " - " & pPaso.Fin)
            Using slPaso As New System.Windows.Forms.DataVisualization.Charting.StripLine
                slPaso.Interval = 0
                slPaso.IntervalOffset = pPaso.IdInicio
                slPaso.StripWidth = pPaso.IdFin - pPaso.IdInicio
                slPaso.BackGradientStyle = DataVisualization.Charting.GradientStyle.TopBottom
                If pPaso.Id Mod 2 Then
                    slPaso.BackColor = Drawing.ColorTranslator.FromOle(lColorPaso)
                    slPaso.BackSecondaryColor = Drawing.ColorTranslator.FromOle(lColorSecundarioPaso)
                Else
                    slPaso.BackColor = Drawing.ColorTranslator.FromOle(lColorPasoAlt)
                    slPaso.BackSecondaryColor = Drawing.ColorTranslator.FromOle(lColorSecundarioPasoAlt)
                End If
                slPaso.Text = pPaso.Id
                slPaso.TextAlignment = StringAlignment.Center
                slPaso.TextOrientation = DataVisualization.Charting.TextOrientation.Horizontal
                slPaso.ToolTip = "Paso:" & vbTab & pPaso.Id & vbCrLf & "Inicio:" & vbTab & pPaso.Inicio & vbCrLf & "Fin:" & vbTab & pPaso.Fin & vbCrLf & "Duracion:" & vbTab & pPaso.Duracion
                slPaso.Font = New Font(sNombreFuenteP, lTamanioPequenio)
                Chart1.ChartAreas.Item(0).AxisX.StripLines.Add(slPaso)
            End Using
        Next pPaso

        Chart1.Series.Item("Temp1").Enabled = bTemp1Visible
        Chart1.Series.Item("Temp2").Enabled = bTemp2Visible
        Chart1.Series.Item("Valv").Enabled = bValvVisible

        ToolStripStatusLabel6.BackColor = Drawing.ColorTranslator.FromOle(lColorTempEntrada)
        ToolStripStatusLabel8.BackColor = Drawing.ColorTranslator.FromOle(lColorTempSalida)
        Chart1.Visible = True
        Me.Cursor = Cursors.Arrow
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

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Me.Opacity = 1
        ActualizarMenuStrip()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Me.Opacity = 0.9
        ActualizarMenuStrip()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Me.Opacity = 0.8
        ActualizarMenuStrip()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Me.Opacity = 0.7
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

    Private Sub Chart1_AxisViewChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataVisualization.Charting.ViewEventArgs) Handles Chart1.AxisViewChanged
        Dim sSQL As String
        Dim sInicio As String
        Dim sFin As String
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader

        If Double.IsNaN(e.NewPosition) Then
            Chart1.Titles.Item(1).Text = ""
        Else
            sInicio = ""
            sFin = ""
            sSQL = "SELECT fecha FROM lecturas WHERE secadora=" & ToolStripStatusLabel11.Tag & " AND id=" & Chart1.Series.Item(1).Points.Item(e.NewPosition - 1).Tag & ""
            mLector = Consulta(sSQL)
            Do While mLector.Read
                sInicio = CDate(mLector.Item("fecha")).ToString("yyyy-MM-dd HH:mm:ss")
            Loop
            mLector.Close()
            sSQL = "SELECT fecha FROM lecturas WHERE secadora=" & ToolStripStatusLabel11.Tag & " AND id=" & Chart1.Series.Item(1).Points.Item(e.NewPosition + e.NewSize - 1).Tag & ""
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
    Private Sub Chart1_CursorPositionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataVisualization.Charting.CursorEventArgs) Handles Chart1.CursorPositionChanged
        Dim sSQL As String
        Dim iPosicion As Integer
        Dim mVentana As Mensaje

        If Double.IsNaN(e.NewPosition) Then
        Else
            iPosicion = CInt(e.NewPosition - 1)
            If iPosicion >= 0 And iPosicion <= Chart1.Series.Item(1).Points.Count - 1 Then
                Dim fDetPunto As New Form2
                Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
                mVentana.Ventana = Me
                mVentana.Esclavo = ToolStripStatusLabel11.Tag
                fDetPunto.Tag = mVentana
                cDetPunto.Add(fDetPunto)
                sSQL = "SELECT id,fecha,secadora,temp1,temp2,formula,display,entrada1,entrada2,version FROM lecturas WHERE secadora=" & ToolStripStatusLabel11.Tag & " AND id=" & Chart1.Series.Item("Temp1").Points.Item(iPosicion).Tag & ""
                mLector = Consulta(sSQL)
                Do While mLector.Read
                    fDetPunto.Text1(1).Text = mLector.Item("id")
                    fDetPunto.Text1(2).Text = CDate(mLector.Item("fecha")).ToString("yyyy-MM-dd HH:mm:ss")
                    fDetPunto.Text1(3).Text = mLector.Item("secadora")
                    fDetPunto.Text1(4).Text = ValToTemp(mLector.Item("temp1"))
                    fDetPunto.Text1(5).Text = ValToTemp(mLector.Item("temp2"))
                    fDetPunto.Text1(6).Text = mLector.Item("formula")
                    fDetPunto.Text1(7).Text = mLector.Item("display")
                    fDetPunto.Text1(8).Text = BoolToOnOff(mLector.Item("entrada1"))
                    fDetPunto.Text1(9).Text = BoolToOnOff(mLector.Item("entrada2"))
                    fDetPunto.Text1(10).Text = (CInt(mLector.Item("version")) / 100).ToString("0.00")
                    fDetPunto.Text = "Sec " & ToolStripStatusLabel11.Text & " @ " & fDetPunto.Text1(2).Text
                Loop
                fDetPunto.Text1(0).Text = iPosicion.ToString
                fDetPunto.Show()
                mLector.Close()
            End If
        End If
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarToolStripMenuItem.Click
        Dim mImagen As New IO.MemoryStream
        Dim bImagen As New Bitmap(mImagen)

        Chart1.SaveImage(mImagen, DataVisualization.Charting.ChartImageFormat.Bmp)
        Clipboard.SetImage(bImagen)
    End Sub


    Private Sub ColorPasoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPasoToolStripMenuItem.Click
        ColorDialog1.Color = Drawing.ColorTranslator.FromOle(lColorPaso)
        If ColorDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            lColorPaso = Drawing.ColorTranslator.ToOle(ColorDialog1.Color)
            Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        End If
    End Sub

    Private Sub ColorPasoAltToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPasoAltToolStripMenuItem.Click
        ColorDialog1.Color = Drawing.ColorTranslator.FromOle(lColorPasoAlt)
        If ColorDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            lColorPasoAlt = Drawing.ColorTranslator.ToOle(ColorDialog1.Color)
            Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        End If
    End Sub

    Private Sub ColorSecundarioPasoAltToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorSecundarioPasoAltToolStripMenuItem.Click
        ColorDialog1.Color = Drawing.ColorTranslator.FromOle(lColorSecundarioPasoAlt)
        If ColorDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            lColorSecundarioPasoAlt = Drawing.ColorTranslator.ToOle(ColorDialog1.Color)
            Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        End If
    End Sub

    Private Sub ColorSecundarioPasoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorSecundarioPasoToolStripMenuItem.Click
        ColorDialog1.Color = Drawing.ColorTranslator.FromOle(lColorSecundarioPaso)
        If ColorDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            lColorSecundarioPaso = Drawing.ColorTranslator.ToOle(ColorDialog1.Color)
            Graficar(ToolStripStatusLabel11.Tag, ToolStripStatusLabel3.Text, ToolStripStatusLabel1.Text)
        End If
    End Sub

    Private Sub Chart1_PostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs) Handles Chart1.PostPaint
        ToolStripProgressBar1.Value = 0
    End Sub

    Private Sub TempSallidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PosicionValvToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PosicionValvToolStripMenuItem.Click
        bValvVisible = Not bValvVisible
        Chart1.Series.Item("Valv").Enabled = bValvVisible
        ActualizarMenuStrip()
    End Sub

    Private Sub OpacidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpacidadToolStripMenuItem.Click

    End Sub

    Private Sub TempEntradaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TempEntradaToolStripMenuItem.Click
        bTemp1Visible = Not bTemp1Visible
        Chart1.Series.Item("Temp1").Enabled = bTemp1Visible
        ActualizarMenuStrip()
    End Sub

    Private Sub TempSalidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TempSalidaToolStripMenuItem.Click
        bTemp2Visible = Not bTemp2Visible
        Chart1.Series.Item("Temp2").Enabled = bTemp2Visible
        ActualizarMenuStrip()

    End Sub

    Private Sub SetEntradaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetEntradaToolStripMenuItem.Click
        bSet1Visible = Not bSet1Visible
        Chart1.Series.Item("Set1").Enabled = bSet1Visible
        ActualizarMenuStrip()
    End Sub

    Private Sub SetSalidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetSalidaToolStripMenuItem.Click
        bSet2Visible = Not bSet2Visible
        Chart1.Series.Item("Set2").Enabled = bSet2Visible
        ActualizarMenuStrip()
    End Sub
End Class