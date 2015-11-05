Public Class Form3
    Dim sFormatoAcomodar As String

    Private Sub Form3_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GuardarPosicion(Me)
    End Sub
    Function FormatoHora(ByVal dFecha As Date) As String
        FormatoHora = dFecha.ToString("hh:mm:ss tt") & ""
    End Function
    Function FormatoTiempo(ByVal dFecha As Date) As String
        Dim sTemp As String
        Dim iDias As Integer
        Dim iHoras As Integer
        Dim iMinutos As Integer
        Dim iSegundos As Integer
        Dim sResultado As String
        Dim dTemp As Date

        dTemp = dFecha
        iDias = dTemp.Day
        iHoras = dTemp.Hour
        iMinutos = dTemp.Minute
        iSegundos = dTemp.Second
        sResultado = ""
        sTemp = ""
        If iDias > 1 Then sResultado = iDias & " dias "
        If iHoras > 0 Then sResultado = sResultado & iHoras.ToString("00") & ":"
        If iMinutos > 0 Or iHoras > 0 Then sResultado = sResultado & iMinutos.ToString("00") & ":"
        sResultado = sResultado & iSegundos.ToString("00")
        If iSegundos > 0 Then sTemp = " segundos"
        If iMinutos > 0 Then sTemp = " minutos"
        If iHoras > 0 Then sTemp = " horas"
        If iHoras = 0 And iMinutos = 0 And iSegundos = 0 Then sResultado = "nada"
        sResultado = sResultado & sTemp
        FormatoTiempo = sResultado
    End Function
    Function MinTemp(ByVal Secadora As Integer, ByVal Campo As String, ByVal Inicio As Date, ByVal Fin As Date) As Collection
        Dim cResultado As Collection
        Dim tResultado As Temperatura
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
        Dim lMinimo As Long
        Dim sSQL As String

        cResultado = New Collection
        sSQL = "SELECT MIN(" & Campo & ") AS minimo FROM lecturas WHERE secadora=" & Secadora.ToString & " AND fecha BETWEEN '" & Inicio.ToString("yyyy-MM-dd HH:mm:ss") & "' AND '" & Fin.ToString("yyyy-MM-dd HH:mm:ss") & "'"
        mLector = Consulta(sSQL)
        If mLector.Read Then
            lMinimo = mLector.Item("minimo")
        End If
        mLector.Close()
        sSQL = "SELECT fecha FROM lecturas WHERE " & Campo & "=" & lMinimo & " AND secadora=" & Secadora.ToString & " AND fecha BETWEEN '" & Inicio.ToString("yyyy-MM-dd HH:mm:ss") & "' AND '" & Fin.ToString("yyyy-MM-dd HH:mm:ss") & "'"
        mLector = Consulta(sSQL)
        Do While mLector.Read
            tResultado = Nothing
            tResultado.Valor = lMinimo
            tResultado.Fecha = mLector.Item("fecha")
            cResultado.Add(tResultado)
        Loop
        mLector.Close()
        MinTemp = cResultado
    End Function
    Function MaxTemp(ByVal Secadora As Integer, ByVal Campo As String, ByVal Inicio As Date, ByVal Fin As Date) As Collection
        Dim cResultado As Collection
        Dim tResultado As Temperatura
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
        Dim lMaximo As Long
        Dim sSQL As String

        cResultado = New Collection
        sSQL = "SELECT MAX(" & Campo & ") AS maximo FROM lecturas WHERE secadora=" & Secadora.ToString & " AND fecha BETWEEN '" & Inicio.ToString("yyyy-MM-dd HH:mm:ss") & "' AND '" & Fin.ToString("yyyy-MM-dd HH:mm:ss") & "'"
        mLector = Consulta(sSQL)
        If mLector.Read Then
            lMaximo = mLector.Item("maximo")
        End If
        mLector.Close()
        sSQL = "SELECT fecha FROM lecturas WHERE " & Campo & "=" & lMaximo & " AND secadora=" & Secadora.ToString & " AND fecha BETWEEN '" & Inicio.ToString("yyyy-MM-dd HH:mm:ss") & "' AND '" & Fin.ToString("yyyy-MM-dd HH:mm:ss") & "'"
        mLector = Consulta(sSQL)
        Do While mLector.Read
            tResultado = Nothing
            tResultado.Valor = lMaximo
            tResultado.Fecha = mLector.Item("fecha")
            cResultado.Add(tResultado)
        Loop
        mLector.Close()
        MaxTemp = cResultado
    End Function
    Private Sub detallegrafica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   Autor: emmanuel156@gmail.com
        '
        '   [ ] Mostrar barra de progreso mientras se realiza el analisis.

        Dim sSecadora As String
        Dim sFechaInicio As String
        Dim sFechaFin As String
        Dim dTiempoRegistrado As Date
        Dim TiempoTrabajo As Date
        Dim TiempoAnterior As Date
        Dim UltimoTiempo As Date
        Dim PrimerTiempo As Date
        Dim bVentiladorTrabajandoAnterior As Boolean
        Dim bVentiladorTrabajando As Boolean
        Dim lContador As Long
        Dim sInfoAdicional As String
        Dim lIter As Long
        Dim sTempSalida() As String
        Dim sSQL As String
        Dim sTempEntrada() As String
        Dim iTempSalidaAnterior() As Integer
        Dim iTempEntradaAnterior() As Integer
        Dim iMaxTempEntrada As Integer
        Dim iMaxTempSalida As Integer
        Dim dHoraMaxTempEntrada As Date
        Dim dHoraMaxTempSalida As Date
        Dim iMinTempEntrada As Integer
        Dim iMinTempSalida As Integer
        Dim dHoraMinTempEntrada As Date
        Dim dHoraMinTempSalida As Date
        Dim dTiempoTempSalidaMantenida() As Date
        Dim dTiempoTempEntradaMantenida() As Date
        Dim sCarga As String
        Dim bMantieneTempSalida() As Boolean
        Dim bMantieneTempEntrada() As Boolean
        Dim lTotalCargas As Long
        Dim sCargas As String
        Dim lFormula As Long
        Dim dIniciaFormula As Date
        Dim sTemp() As String
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
        Dim cCargas As Collection
        Dim dCuentaCargas As SortedList

        dCuentaCargas = New SortedList
        ColocarForm(Me)
        Try
            ListBox1.Font = New Font(sNombreFuenteG, lTamanioGrande)
        Catch
        End Try
        sTemp = Split(Me.Tag.ToString, sSeparador)
        sSecadora = sTemp(0)
        sFechaInicio = sTemp(1)
        sFechaFin = sTemp(2)
        mLector = Consulta("SELECT nombre FROM esclavos WHERE esclavo=" & sSecadora)
        If mLector.Read Then
            Me.Text = "Secadora " & mLector.Item("nombre") & ", " & sFechaInicio & " - " & sFechaFin & ""
            ListBox1.Items.Add("Secadora:         :" & vbTab & mLector.Item("nombre"))
        End If
        mLector.Close()
        sTempEntrada = Split(sVigilarTempEntrada, ",")
        ReDim iTempEntradaAnterior(UBound(sTempEntrada))
        ReDim bMantieneTempEntrada(UBound(sTempEntrada))
        ReDim dTiempoTempEntradaMantenida(UBound(sTempEntrada))

        sTempSalida = Split(sVigilarTempSalida, ",")
        ReDim iTempSalidaAnterior(UBound(sTempSalida))
        ReDim bMantieneTempSalida(UBound(sTempSalida))
        ReDim dTiempoTempSalidaMantenida(UBound(sTempSalida))
        sSQL = "SELECT * FROM lecturas WHERE secadora=" & sSecadora & " AND fecha BETWEEN '" & sFechaInicio & "' AND '" & sFechaFin & "' ORDER BY fecha"
        lContador = 0
        dTiempoRegistrado = New Date
        TiempoTrabajo = New Date
        UltimoTiempo = New Date
        cCargas = New Collection
        sInfoAdicional = ""
        sCargas = ""
        lTotalCargas = 1
        mLector = Consulta(sSQL)
        iMinTempEntrada = 1024
        iMinTempSalida = 1024
        Do While mLector.Read
            UltimoTiempo = mLector.Item(1)
            bVentiladorTrabajando = mLector.Item(7)
            If lContador = 0 Then
                PrimerTiempo = mLector.Item(1)
            Else
                If ((UltimoTiempo - TiempoAnterior).Hours * 60 + (UltimoTiempo - TiempoAnterior).Minutes) > 1 Then
                    sInfoAdicional = sInfoAdicional & "Sin registro de las " & FormatoHora(TiempoAnterior) & " a las " & FormatoHora(UltimoTiempo) & " (" & LapsoTiempo(TiempoAnterior, UltimoTiempo) & ")" & vbCrLf
                    bVentiladorTrabajando = False
                Else
                    dTiempoRegistrado = dTiempoRegistrado + (UltimoTiempo - TiempoAnterior)
                End If
            End If
            If bVentiladorTrabajando And bVentiladorTrabajandoAnterior = False Then
                lFormula = CInt(mLector.Item(5))
                dIniciaFormula = UltimoTiempo
            End If
            If bVentiladorTrabajando And bVentiladorTrabajandoAnterior = True Then
                If lFormula = 0 Then
                    lFormula = CInt(mLector.Item(5))
                End If
                If (UltimoTiempo - TiempoAnterior).TotalMinutes < 2 Then
                    TiempoTrabajo = TiempoTrabajo + (UltimoTiempo - TiempoAnterior)
                End If
            End If
            If bVentiladorTrabajandoAnterior = True And bVentiladorTrabajando = False Then
                If dCuentaCargas.ContainsKey(lFormula) Then
                    dCuentaCargas(lFormula) = dCuentaCargas(lFormula) + 1
                Else
                    dCuentaCargas.Add(lFormula, 1)
                End If
                sCargas = sCargas & lTotalCargas & vbTab & " Inicia formula: " & lFormula.ToString.PadLeft(3) & " a las " & vbTab & FormatoHora(dIniciaFormula) & ", termina " & vbTab & FormatoHora(UltimoTiempo) & " duracion " & LapsoTiempo(dIniciaFormula, UltimoTiempo) & vbCrLf

                lTotalCargas = lTotalCargas + 1
                cCargas.Add(sSecadora & sSeparador & (lTotalCargas - 1).ToString & sSeparador & dIniciaFormula.ToString("yyyy-MM-dd HH:mm:ss") & sSeparador & UltimoTiempo.ToString("yyyy-MM-dd HH:mm:ss"))
            End If

            If mLector.Item(3) > iMaxTempEntrada Then
                iMaxTempEntrada = mLector.Item(3)
                dHoraMaxTempEntrada = mLector.Item("fecha")

            End If
            If mLector.Item(4) > iMaxTempSalida Then
                iMaxTempSalida = mLector.Item(4)
                dHoraMaxTempSalida = mLector.Item("fecha")

            End If
            If mLector.Item(3) < iMinTempEntrada Then
                iMinTempEntrada = mLector.Item(3)
                dHoraMinTempEntrada = mLector.Item("fecha")

            End If
            If mLector.Item(4) < iMinTempSalida Then
                iMinTempSalida = mLector.Item(4)
                dHoraMinTempSalida = mLector.Item("fecha")

            End If
            bVentiladorTrabajandoAnterior = bVentiladorTrabajando
            TiempoAnterior = UltimoTiempo
            lContador = lContador + 1
        Loop
        mLector.Close()
        If PrimerTiempo.Day = UltimoTiempo.Day Then
            sFormatoAcomodar = "hh:mm:ss tt"
        Else
            sFormatoAcomodar = "yyyy-MM-dd hh:mm:ss tt"
        End If
        lTotalCargas = 0
        ListBox1.Items.Add("Hora de inicio    :" & vbTab & (PrimerTiempo).ToString("yyyy-MM-dd HH:mm:ss"))
        ListBox1.Items.Add("Hora de fin       :" & vbTab & (UltimoTiempo).ToString("yyyy-MM-dd HH:mm:ss"))
        ListBox1.Items.Add("Tiempo grafica    :" & vbTab & LapsoTiempo(PrimerTiempo, UltimoTiempo))
        ListBox1.Items.Add("Tiempo registrado :" & vbTab & FormatoTiempo(dTiempoRegistrado))
        ListBox1.Items.Add("Tiempo trabajo    :" & vbTab & FormatoTiempo(TiempoTrabajo))
        ListBox1.Items.Add("-")
        ListBox1.Items.Add("Minima temp entrada :" & vbTab & ValToTemp(iMinTempEntrada) & " a las " & FormatoHora(dHoraMinTempEntrada) & "")
        ListBox1.Items.Add("Minima temp salida  :" & vbTab & ValToTemp(iMinTempSalida) & " a las " & FormatoHora(dHoraMinTempSalida) & "")
        ListBox1.Items.Add("Maxima temp entrada :" & vbTab & ValToTemp(iMaxTempEntrada) & " a las " & FormatoHora(dHoraMaxTempEntrada) & "")
        ListBox1.Items.Add("Maxima temp salida  :" & vbTab & ValToTemp(iMaxTempSalida) & " a las " & FormatoHora(dHoraMaxTempSalida) & "")
        ListBox1.Items.Add("Temp entrada        :" & vbTab & Drawing.ColorTranslator.FromOle(lColorTempEntrada).ToString)
        ListBox1.Items.Add("Temp salida         :" & vbTab & Drawing.ColorTranslator.FromOle(lColorTempSalida).ToString)
        ListBox1.Items.Add("-")
        For Each lIter In dCuentaCargas.Keys
            ListBox1.Items.Add("Formula " & vbTab & lIter.ToString.PadLeft(3) & ": " & vbTab & dCuentaCargas(lIter) & " cargas")
            lTotalCargas = lTotalCargas + dCuentaCargas(lIter)
        Next lIter
        ListBox1.Items.Add("Total de cargas:" & vbTab & lTotalCargas.ToString.PadLeft(5) & " cargas")
        ListBox1.Items.Add("-")
        For Each sCarga In cCargas
            sTemp = Split(sCarga, sSeparador)
            sFechaInicio = sTemp(2)
            sFechaFin = sTemp(3)
            AnalizarCarga(sSecadora, sTemp(1), sFechaInicio, sFechaFin)
        Next sCarga
        sTemp = Split(sInfoAdicional, vbCrLf)
        For lIter = 0 To UBound(sTemp)
            ListBox1.Items.Add(sTemp(lIter))
        Next lIter

        ListBox1.Items.Add("Rango aceptable de variacion de temperatura: " & Chr(177) & ValToTemp(lRangoAceptable))
        ListBox1.Items.Add("+")
    End Sub

    Private Sub AnalizarCarga(ByVal sSecadora As String, ByVal sCarga As String, ByVal sFechaInicio As String, ByVal sFechaFin As String)
        '   Autor: emmanuel156@gmail.com
        '
        '   [x] Corregir error donde tiempo inicio paso es mayor que tiempo fin paso. (Realizado el 25oct2015 por emmanuel156@gmail.com)
        '   [ ] Reemplazar busqueda de temperaturas maxima minima por consulta sql.

        Dim dTiempoRegistrado As Date
        Dim TiempoTrabajo As Date
        Dim TiempoAnterior As Date
        Dim UltimoTiempo As Date
        Dim PrimerTiempo As Date
        Dim bVentiladorTrabajandoAnterior As Boolean
        Dim bVentiladorTrabajando As Boolean
        Dim lContador As Long
        Dim sInfoAdicional As String
        Dim lIter As Long
        Dim sTempSalida() As String
        Dim sSQL As String
        Dim sVigilaTemperaturas As String
        Dim sTempEntrada() As String
        Dim iTempSalidaAnterior() As Integer
        Dim iTempEntradaAnterior() As Integer
        Dim iMaxTempEntrada As Integer
        Dim iMaxTempSalida As Integer
        Dim dHoraMaxTempEntrada As Date
        Dim dHoraMaxTempSalida As Date
        Dim dTiempoMaxTempEntrada As Date
        Dim dTiempoMaxTempSalida As Date
        Dim iMinTempEntrada As Integer
        Dim iMinTempSalida As Integer
        Dim dHoraMinTempEntrada As Date
        Dim dHoraMinTempSalida As Date
        Dim dTiempoMinTempEntrada As Date
        Dim dTiempoMinTempSalida As Date
        Dim dTiempoTempSalidaMantenida() As Date
        Dim dTiempoTempEntradaMantenida() As Date
        Dim iPasoAnterior As Integer
        Dim iPasoActual As Integer
        Dim bMantieneTempSalida() As Boolean
        Dim bMantieneTempEntrada() As Boolean
        Dim sCargas As String
        Dim lFormula As Long
        Dim dIniciaFormula As Date
        Dim sTemp() As String
        Dim sMantieneTempSalida As String
        Dim sMantieneTempEntrada As String
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
        Dim cID As Collection
        Dim cPasos As Collection
        Dim pPaso As Paso
        Dim tTemperatura As Temperatura

        ColocarForm(Me)
        sTempEntrada = Split(sVigilarTempEntrada, ",")
        ReDim iTempEntradaAnterior(UBound(sTempEntrada))
        ReDim bMantieneTempEntrada(UBound(sTempEntrada))
        ReDim dTiempoTempEntradaMantenida(UBound(sTempEntrada))
        sTempSalida = Split(sVigilarTempSalida, ",")
        ReDim iTempSalidaAnterior(UBound(sTempSalida))
        ReDim bMantieneTempSalida(UBound(sTempSalida))
        ReDim dTiempoTempSalidaMantenida(UBound(sTempSalida))
        sSQL = "SELECT * FROM lecturas WHERE secadora=" & sSecadora & " AND fecha BETWEEN '" & sfechainicio & "' AND '" & sfechafin & "' ORDER BY fecha"
        lContador = 0
        dTiempoRegistrado = New Date
        TiempoTrabajo = New Date
        UltimoTiempo = New Date
        cID = New Collection
        cPasos = New Collection
        sInfoAdicional = ""
        sVigilaTemperaturas = ""
        sCargas = ""
        sMantieneTempSalida = ""
        sMantieneTempEntrada = ""
        iMinTempEntrada = 1024
        iMinTempSalida = 1024
        mLector = Consulta(sSQL)
        Do While mLector.Read
            UltimoTiempo = mLector.Item(1)
            bVentiladorTrabajando = mLector.Item(7)
            If lContador = 0 Then
                PrimerTiempo = mLector.Item(1)
                iPasoAnterior = ObtenerPaso(mLector.Item("display"))
            Else
                If ((UltimoTiempo - TiempoAnterior).Hours * 60 + (UltimoTiempo - TiempoAnterior).Minutes) > 1 Then
                    sInfoAdicional = sInfoAdicional & "Sin registro de las " & FormatoHora(TiempoAnterior) & " a las " & FormatoHora(UltimoTiempo) & " (" & LapsoTiempo(TiempoAnterior, UltimoTiempo) & ")" & vbCrLf
                    bVentiladorTrabajando = False
                Else
                    dTiempoRegistrado = dTiempoRegistrado + (UltimoTiempo - TiempoAnterior)
                End If
            End If

            If bVentiladorTrabajando And bVentiladorTrabajandoAnterior = False Then
                cID.Add(mLector.Item("id"))
                lFormula = CInt(mLector.Item(5))
                dIniciaFormula = UltimoTiempo
                pPaso.Inicio = UltimoTiempo
                iPasoAnterior = ObtenerPaso(mLector.Item("display"))
            End If
            If bVentiladorTrabajando Then
                If ObtenerPaso(mLector.Item("display")) > 0 Then
                    iPasoActual = ObtenerPaso(mLector.Item("display"))
                End If
                If iPasoActual <> iPasoAnterior Then
                    If TiempoAnterior > CDate("00:00:00") Then
                        pPaso.Numero = iPasoAnterior
                        pPaso.Duracion = LapsoTiempo(CDate(pPaso.Inicio), TiempoAnterior)
                        pPaso.Fin = TiempoAnterior
                        cPasos.Add(pPaso)
                        pPaso = Nothing
                        pPaso.Inicio = UltimoTiempo
                    Else
                        iPasoActual = iPasoAnterior
                    End If
                End If
            End If
            If bVentiladorTrabajando And bVentiladorTrabajandoAnterior = True Then
                If lFormula = 0 Then lFormula = CInt(mLector.Item(5))

                If (UltimoTiempo - TiempoAnterior).TotalMinutes < 2 Then
                    TiempoTrabajo = TiempoTrabajo + (UltimoTiempo - TiempoAnterior)
                End If
            End If
            If bVentiladorTrabajandoAnterior = True And bVentiladorTrabajando = False Then
                pPaso.Fin = TiempoAnterior
                pPaso.Duracion = LapsoTiempo(CDate(pPaso.Inicio), TiempoAnterior)
                pPaso.Numero = iPasoAnterior
                cPasos.Add(pPaso)
                sCargas = sCargas & sCarga & vbTab & " Inicia formula: " & lFormula.ToString.PadLeft(3) & " a las " & FormatoHora(dIniciaFormula) & ", termina " & FormatoHora(UltimoTiempo) & " duracion " & LapsoTiempo(dIniciaFormula, UltimoTiempo) & vbCrLf
            End If

            If mLector.Item(3) > iMaxTempEntrada Then
                iMaxTempEntrada = mLector.Item(3)
                dHoraMaxTempEntrada = mLector.Item("fecha")
                dTiempoMaxTempEntrada = CDate((UltimoTiempo - PrimerTiempo).ToString)
            End If
            If mLector.Item(4) > iMaxTempSalida Then
                iMaxTempSalida = mLector.Item(4)
                dHoraMaxTempSalida = mLector.Item("fecha")
                dTiempoMaxTempSalida = CDate((UltimoTiempo - PrimerTiempo).ToString)
            End If
            If mLector.Item(3) < iMinTempEntrada Then
                iMinTempEntrada = mLector.Item(3)
                dHoraMinTempEntrada = mLector.Item("fecha")
                dTiempoMinTempEntrada = CDate((UltimoTiempo - PrimerTiempo).ToString)
            End If
            If mLector.Item(4) < iMinTempSalida Then
                iMinTempSalida = mLector.Item(4)
                dHoraMinTempSalida = mLector.Item("fecha")
                dTiempoMinTempSalida = CDate((UltimoTiempo - PrimerTiempo).ToString)
            End If
            For lIter = 0 To UBound(sTempEntrada)
                If mLector.Item(3) >= Val(sTempEntrada(lIter)) And iTempEntradaAnterior(lIter) < Val(sTempEntrada(lIter)) Then
                    If Not bMantieneTempEntrada(lIter) Then
                        sVigilaTemperaturas = sVigilaTemperaturas & FormatoHora(UltimoTiempo) & ": Alcanza " & ValToTemp(sTempEntrada(lIter)) & " de entrada a " & LapsoTiempo(PrimerTiempo, UltimoTiempo) & " de comenzar" & vbCrLf
                    End If
                End If
                If mLector.Item(3) > (Val(sTempEntrada(lIter)) - lRangoAceptable) And mLector.Item(3) < (Val(sTempEntrada(lIter)) + lRangoAceptable) Then
                    If bMantieneTempEntrada(lIter) = False Then
                        sMantieneTempEntrada = FormatoHora(UltimoTiempo) & ": Mantiene temperatura de entrada cerca de " & ValToTemp(sTempEntrada(lIter)) & " de " & FormatoHora(UltimoTiempo) & " a "
                        dTiempoTempEntradaMantenida(lIter) = UltimoTiempo
                    End If
                    bMantieneTempEntrada(lIter) = True
                Else
                    If bMantieneTempEntrada(lIter) Then
                        If (UltimoTiempo - dTiempoTempEntradaMantenida(lIter)).Hours * 60 + (UltimoTiempo - dTiempoTempEntradaMantenida(lIter)).Minutes >= lMinutosTempEntradaMantenida Then
                            sMantieneTempEntrada = sMantieneTempEntrada & FormatoHora(UltimoTiempo) & " (" & LapsoTiempo(dTiempoTempEntradaMantenida(lIter), UltimoTiempo) & ")" & vbCrLf
                            sVigilaTemperaturas = sVigilaTemperaturas & sMantieneTempEntrada
                        Else
                            sMantieneTempEntrada = ""
                        End If
                    End If
                    bMantieneTempEntrada(lIter) = False
                End If
                iTempEntradaAnterior(lIter) = mLector.Item(3)
            Next lIter
            For lIter = 0 To UBound(sTempSalida)
                If mLector.Item(4) >= Val(sTempSalida(lIter)) And iTempSalidaAnterior(lIter) < Val(sTempSalida(lIter)) Then
                    If Not bMantieneTempSalida(lIter) Then
                        sVigilaTemperaturas = sVigilaTemperaturas & FormatoHora(UltimoTiempo) & ": Alcanza " & ValToTemp(sTempSalida(lIter)) & " de salida a " & LapsoTiempo(PrimerTiempo, UltimoTiempo) & " de comenzar " & vbCrLf
                    End If
                End If
                If mLector.Item(4) > (Val(sTempSalida(lIter)) - lRangoAceptable) And mLector.Item(4) < (Val(sTempSalida(lIter)) + lRangoAceptable) Then
                    If bMantieneTempSalida(lIter) = False Then
                        sMantieneTempSalida = FormatoHora(UltimoTiempo) & ": Mantiene temperatura de salida cerca de " & ValToTemp(sTempSalida(lIter)) & " de " & FormatoHora(UltimoTiempo) & " a "
                        dTiempoTempSalidaMantenida(lIter) = UltimoTiempo
                    End If
                    bMantieneTempSalida(lIter) = True
                Else
                    If bMantieneTempSalida(lIter) Then
                        If (UltimoTiempo - dTiempoTempSalidaMantenida(lIter)).Hours * 60 + (UltimoTiempo - dTiempoTempSalidaMantenida(lIter)).Minutes >= lMinutosTempSalidaMantenida Then
                            sMantieneTempSalida = sMantieneTempSalida & FormatoHora(UltimoTiempo) & " (" & CDate((UltimoTiempo - dTiempoTempSalidaMantenida(lIter)).ToString).ToString("mm:ss") & " minutos)" & vbCrLf
                            sVigilaTemperaturas = sVigilaTemperaturas & sMantieneTempSalida
                        Else
                            sMantieneTempSalida = ""
                        End If
                    End If
                    bMantieneTempSalida(lIter) = False
                End If
                iTempSalidaAnterior(lIter) = mLector.Item(4)
            Next lIter
            iPasoAnterior = iPasoActual
            bVentiladorTrabajandoAnterior = bVentiladorTrabajando
            TiempoAnterior = UltimoTiempo
            lContador = lContador + 1
        Loop
        mLector.Close()
        ListBox1.Items.Add("-")
        sTemp = Split(sCargas, vbCrLf)
        For lIter = 0 To UBound(sTemp)
            ListBox1.Items.Add(sTemp(lIter))
            If lIter < cID.Count Then
                sSQL = "SELECT * FROM cargas WHERE idlectura=" & cID.Item(lIter + 1) & " ORDER BY fecha DESC"
                mLector = Consulta(sSQL)
                If mLector.Read Then
                    ListBox1.Items.Add(vbTab & "Marca: " & mLector.Item("marca") & vbTab & "P.O.: " & mLector.Item("po") & vbTab & "Corte: " & mLector.Item("corte") & vbTab & "Proceso: " & mLector.Item("proceso") & vbTab & "Fase: " & mLector.Item("fase"))
                    ListBox1.Items.Add(vbTab & "Cantidad: " & vbTab & mLector.Item("cantidad") & " piezas")
                    If Len(mLector.Item("observaciones")) > 0 Then
                        ListBox1.Items.Add(vbTab & "Observaciones: " & vbTab & mLector.Item("observaciones"))
                    End If
                End If
                mLector.Close()
            End If
        Next lIter


        ListBox1.Items.Add("-")
        For Each pPaso In cPasos
            ListBox1.Items.Add(vbTab & "Paso: " & pPaso.Numero & " inicia " & pPaso.Inicio.ToString(sFormatoAcomodar) & " termina " & pPaso.Fin.ToString(sFormatoAcomodar) & " duracion " & pPaso.Duracion)
            For Each tTemperatura In MinTemp(sSecadora, "temp1", pPaso.Inicio, pPaso.Fin)
                ListBox1.Items.Add(vbTab & vbTab & "Minima temp entrada :" & ValToTemp(tTemperatura.Valor) & " a las " & tTemperatura.Fecha.ToString(sFormatoAcomodar))
            Next tTemperatura
            For Each tTemperatura In MinTemp(sSecadora, "temp2", pPaso.Inicio, pPaso.Fin)
                ListBox1.Items.Add(vbTab & vbTab & "Minima temp salida  :" & ValToTemp(tTemperatura.Valor) & " a las " & tTemperatura.Fecha.ToString(sFormatoAcomodar))
            Next tTemperatura
            For Each tTemperatura In MaxTemp(sSecadora, "temp1", pPaso.Inicio, pPaso.Fin)
                ListBox1.Items.Add(vbTab & vbTab & "Maxima temp entrada :" & ValToTemp(tTemperatura.Valor) & " a las " & tTemperatura.Fecha.ToString(sFormatoAcomodar))
            Next tTemperatura
            For Each tTemperatura In MaxTemp(sSecadora, "temp2", pPaso.Inicio, pPaso.Fin)
                ListBox1.Items.Add(vbTab & vbTab & "Maxima temp salida  :" & ValToTemp(tTemperatura.Valor) & " a las " & tTemperatura.Fecha.ToString(sFormatoAcomodar))
            Next tTemperatura
        Next pPaso
        ListBox1.Items.Add("-")
        ListBox1.Items.Add(vbTab & "Minima temp entrada :" & vbTab & ValToTemp(iMinTempEntrada) & " a " & FormatoTiempo(dTiempoMinTempEntrada) & " de comenzar (" & FormatoHora(dHoraMinTempEntrada) & ")")
        ListBox1.Items.Add(vbTab & "Minima temp salida  :" & vbTab & ValToTemp(iMinTempSalida) & " a " & FormatoTiempo(dTiempoMinTempSalida) & " de comenzar (" & FormatoHora(dHoraMinTempSalida) & ")")
        ListBox1.Items.Add(vbTab & "Maxima temp entrada :" & vbTab & ValToTemp(iMaxTempEntrada) & " a " & FormatoTiempo(dTiempoMaxTempEntrada) & " de comenzar (" & FormatoHora(dHoraMaxTempEntrada) & ")")
        ListBox1.Items.Add(vbTab & "Maxima temp salida  :" & vbTab & ValToTemp(iMaxTempSalida) & " a " & FormatoTiempo(dTiempoMaxTempSalida) & " de comenzar (" & FormatoHora(dHoraMaxTempSalida) & ")")


        ListBox1.Items.Add("-")
        sTemp = Split(sVigilaTemperaturas, vbCrLf)
        For lIter = 0 To UBound(sTemp)
            ListBox1.Items.Add(vbTab & sTemp(lIter))
        Next lIter
        ListBox1.Items.Add("-")
        sTemp = Split(sInfoAdicional, vbCrLf)
        For lIter = 0 To UBound(sTemp)
            ListBox1.Items.Add(vbTab & sTemp(lIter))
        Next lIter
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ExportarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarToolStripMenuItem.Click
        Dim w As IO.StreamWriter
        Dim sLinea As String

        SaveFileDialog1.FileName = Replace(Me.Text, ":", "") & ".txt"
        SaveFileDialog1.Filter = "Archivo de texto|*.txt"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
        Else
            w = New IO.StreamWriter(SaveFileDialog1.FileName, True)
            For Each sLinea In ListBox1.Items
                w.WriteLine(sLinea)
            Next sLinea
            w.Close()
        End If

    End Sub

    Private Sub SeleccionarTodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarTodoToolStripMenuItem.Click
        Dim iRenglon As Integer

        For iRenglon = 0 To ListBox1.Items.Count - 1
            ListBox1.SetSelected(iRenglon, True)
        Next iRenglon
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarToolStripMenuItem.Click
        Dim sTexto As New System.Text.StringBuilder
        Dim iRenglon As Integer

        For iRenglon = 0 To ListBox1.SelectedItems.Count - 1
            sTexto.Append(ListBox1.SelectedItems.Item(iRenglon).ToString)
            sTexto.Append(vbCrLf)
        Next
        My.Computer.Clipboard.SetText(sTexto.ToString)
    End Sub
End Class