Option Strict Off
Option Explicit On
Imports MySql.Data.MySqlClient
Module Module1
    Public mConexion As MySqlConnection
    Public cGraficas As Collection
    Public cDetPunto As Collection
    Public cDetGrafica As Collection
    Public cEsclavos As Collection
    Public lColorTempEntrada As Integer
    Public lColorTempSalida As Integer
    Public lColorCarga As Integer
    Public lColorSecundarioCarga As Integer
    Public lColorPaso As Integer
    Public lColorSecundarioPaso As Integer
    Public lColorPasoAlt As Integer
    Public lColorSecundarioPasoAlt As Integer


    Public bEscalaFarenheit As Boolean
    Public sNombreFuenteP As String
    Public lTamanioPequenio As Long
    Public sNombreFuenteG As String
    Public lTamanioGrande As Long

    Public sServer As String
    'Public sAnchoGrafica As Single
    'Public sInicioGrafica As Single
    Public iUsuario As Integer
    Public bRegistroGuardado As Boolean
    Public sSeparador As String
    Public sVigilarTempEntrada As String
    Public sVigilarTempSalida As String

    Public lMinutosTempSalidaMantenida As Long
    Public lMinutosTempEntradaMantenida As Long
    Public lRangoAceptable As Long
    Public Structure Temperatura
        Public Valor As Integer
        Public Fecha As Date
    End Structure
    Public Structure Mensaje
        Public Ventana As Form
        Public Inicio As Date
        Public Fin As Date
        Public Esclavo As Integer
        'Public Puntos As Collection
    End Structure
    Public Structure Paso
        Public Numero As Integer
        Public Id As Integer
        Public Inicio As Date
        Public IdInicio As Integer
        Public Fin As Date
        Public IdFin As Integer
        Public Duracion As String
    End Structure
    Public Structure Carga
        Public Id As Integer
        Public Esclavo As Integer
        Public Inicio As String
        Public IdInicio As Integer
        Public Fin As String
        Public IdFin As Integer
        Public Duracion As String
        Public Formula As Integer
    End Structure
    Public Structure PuntoGrafica
        Public Id As Integer
        Public Temp1 As Integer
        Public Temp2 As Integer
        Public Display As String
        Public Hora As Date
        Public Etiqueta1 As String
        Public Etiqueta2 As String
        Public Entrada1 As Boolean
        Public Entrada2 As Boolean
        Public Tooltip As String
        Public Vacio As Boolean
    End Structure
    Function ObtenerPaso(ByVal sDisplay As String) As Long
        Dim sTemp As String
        Dim sPaso As String
        Dim iIter As Integer
        Dim lPaso As Long
        Dim sCaracter As String
        sTemp = ""
        Try
            If Len(sDisplay) > 0 Then
                sTemp = sDisplay
                If InStr(sTemp, Chr(128)) Then
                    sDisplay = Mid(sTemp, InStr(sTemp, Chr(128)) + 1)
                End If
                If InStr(sTemp, Chr(160)) Then
                    For iIter = 150 To 159
                        sTemp = sTemp.Replace(Chr(iIter), "")
                    Next iIter
                    For iIter = 161 To 170
                        sTemp = sTemp.Replace(Chr(iIter), "")
                    Next iIter
                    'Debug.Print(lPaso)
                End If

                sTemp = sTemp.Substring(1, 40)
                If InStr(sTemp, "Paso #") > 0 Then
                    sPaso = ""
                    iIter = InStr(sTemp, "Paso #") + 6
                    Do

                        sCaracter = sTemp.Substring(iIter, 1)
                        If IsNumeric(sCaracter) Then sPaso = sPaso & sCaracter
                        iIter = iIter + 1
                    Loop Until sCaracter = "L" Or sCaracter = "#" Or iIter >= Len(sTemp)
                    lPaso = Val(sPaso)
                ElseIf InStr(sTemp, "Linea") > 0 Then
                    sPaso = ""
                    iIter = InStr(sTemp, "Linea") - 3
                    Do

                        sCaracter = sTemp.Substring(iIter, 1)
                        If IsNumeric(sCaracter) Then sPaso = sPaso & sCaracter
                        iIter = iIter + 1
                    Loop Until sCaracter = "L" Or iIter >= Len(sTemp)
                    lPaso = Val(sPaso)

                End If


            Else
                lPaso = 0
            End If
        Catch
            'Imprimir("Error al obtener formula. (" & sDisplay & ") secadora " & iSecadora.ToString)
            lPaso = -1
        End Try

        Debug.Print(lPaso & vbTab & sTemp & vbTab & sDisplay)
        ObtenerPaso = lPaso
    End Function


    Sub RealizarConexion()

        mConexion = New MySqlConnection()
        If mConexion.State = ConnectionState.Open Then

        Else
            Try
                mConexion.ConnectionString = "server=" & sServer & ";" & "user=root;" & "password=manttocl;" & "database=dryermon"
                mConexion.Open()
            Catch mierror As MySqlException
                If mierror.Number = 1042 Then
                    If MsgBox("No se encuentra el servidor " & vbCrLf & sServer, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                        End
                    End If
                    RealizarConexion()
                End If
            End Try
        End If
    End Sub
    Function IdUsuario() As Integer
        Dim bEncontrado As Boolean
        Dim mComando As MySqlCommand
        Dim mDataReader As MySqlDataReader
        Dim sSQL As String
        Dim sUsuario As String
        Dim sTerminal As String
        Dim sVersion As String
        Dim iIdUsuario As Integer
        sUsuario = Left(Environment.UserName, 20)
        sTerminal = Left(Environment.MachineName, 20)
        sVersion = Left(Application.ProductVersion.ToString, 15)
        sUsuario = sUsuario.Replace("'", "")
        sTerminal = sTerminal.Replace("'", "")
        mComando = New MySqlCommand
        iIdUsuario = 0
        sSQL = ""
        bEncontrado = False
        If mConexion.State = ConnectionState.Open Then
            Do
                mComando.Connection = mConexion
                sSQL = "select id from usuarios where usuario='" & sUsuario & "' and terminal='" & sTerminal & "'"
                mDataReader = Consulta(sSQL)
                If mDataReader.Read Then
                    iIdUsuario = mDataReader.Item(0)
                    bEncontrado = True
                Else
                    bEncontrado = False
                End If
                mDataReader.Close()
                If bEncontrado Then
                    sSQL = "update usuarios set version='" & sVersion & "',fechalogin='" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "' where id=" & iIdUsuario.ToString
                    mComando.CommandText = sSQL
                    mComando.ExecuteNonQuery()
                Else
                    sSQL = "insert into usuarios values (0,'" & sUsuario & "','" & sTerminal & "','" & sVersion & "','" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "','" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "')"
                    mComando.CommandText = sSQL
                    mComando.ExecuteNonQuery()
                End If
            Loop Until iIdUsuario > 0
        End If
        IdUsuario = iIdUsuario
    End Function
    Sub RegistrarCarga(ByVal iIdLectura As Integer, ByVal iFormula As Integer, ByVal sMarca As String, ByVal sPO As String, ByVal sCorte As String, ByVal sProceso As String, ByVal sFase As String, ByVal iCantidad As Integer, ByVal sObservaciones As String)
        Dim mComando As MySqlCommand
        Dim mLector As MySqlDataReader
        Dim sSQL As String
        Dim bRepetido As Boolean
        bRepetido = False
        mComando = New MySql.Data.MySqlClient.MySqlCommand
        If mConexion.State = ConnectionState.Open Then
            sSQL = ""
            Try
                mLector = Consulta("select id from cargas where idlectura=" & iIdLectura.ToString & " and formula=" & iFormula.ToString & " and marca='" & sMarca & "' and po='" & sPO & "' and corte='" & sCorte & "' and proceso='" & sProceso & "' and fase='" & sFase & "' and cantidad=" & iCantidad.ToString & " and observaciones='" & sObservaciones & "'")
                If mLector.Read Then
                    If mLector.Item("id") > 0 Then
                        bRepetido = True
                    End If
                End If
                mLector.Close()
                If Not bRepetido Then
                    mComando.Connection = mConexion
                    sSQL = "insert into cargas values (0," & iIdLectura.ToString & ",'" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "'," & iFormula.ToString & ",'" & sMarca & "','" & sPO & "','" & sCorte & "','" & sProceso & "','" & sFase & "'," & iCantidad.ToString & ",'" & sObservaciones & "'," & iUsuario.ToString & ")"
                    mComando.CommandText = sSQL
                    mComando.ExecuteNonQuery()
                End If
                bRegistroGuardado = True
            Catch mierror As MySqlException
                MsgBox(mierror.ToString)
                bRegistroGuardado = False
            End Try
        Else
            RealizarConexion()
            bRegistroGuardado = False
        End If
    End Sub
    Sub GuardarAnchoColumnas(ByVal Forma As Form, ByVal DataGrid As DataGridView)
        Dim iColumna As Integer
        For iColumna = 0 To DataGrid.Columns.Count - 1
            SaveSetting("MonitorSecadoras", "Grafica", Forma.Name & "AnchoColumna" & iColumna, DataGrid.Columns.Item(iColumna).Width.ToString)
        Next
    End Sub
    Sub CargarAnchoColumnas(ByVal Forma As Form, ByVal DataGrid As DataGridView)
        Dim iColumna As Integer
        For iColumna = 0 To DataGrid.Columns.Count - 1
            DataGrid.Columns.Item(iColumna).Width = Val(GetSetting("MonitorSecadoras", "Grafica", Forma.Name & "AnchoColumna" & iColumna.ToString, "100"))
        Next
    End Sub
    Sub GuardarPosicion(ByVal Forma As Form)
        If Forma.WindowState = FormWindowState.Minimized Then
        Else
            SaveSetting("MonitorSecadoras", "Grafica", Forma.Name & "Opacidad", Forma.Opacity.ToString)
            SaveSetting("MonitorSecadoras", "Grafica", Forma.Name & "Estado", Forma.WindowState.ToString)
            SaveSetting("MonitorSecadoras", "Grafica", Forma.Name & "Top", Forma.Top)
            SaveSetting("MonitorSecadoras", "Grafica", Forma.Name & "Left", Forma.Left)
            SaveSetting("MonitorSecadoras", "Grafica", Forma.Name & "Width", Forma.Width)
            SaveSetting("MonitorSecadoras", "Grafica", Forma.Name & "Height", Forma.Height)
        End If
    End Sub
    Sub ColocarForm(ByVal Forma As Form)
        Dim iTop As Integer
        Dim iLeft As Integer
        Dim iWidth As Integer
        Dim iHeight As Integer
        Dim sOpacidad As Single
        sOpacidad = Val(GetSetting("MonitorSecadoras", "Grafica", Forma.Name & "Opacidad", "1"))
        iTop = Val(GetSetting("MonitorSecadoras", "Grafica", Forma.Name & "Top", "0"))
        iLeft = Val(GetSetting("MonitorSecadoras", "Grafica", Forma.Name & "Left", "0"))
        iWidth = Val(GetSetting("MonitorSecadoras", "Grafica", Forma.Name & "Width", "400"))
        iHeight = Val(GetSetting("MonitorSecadoras", "Grafica", Forma.Name & "Height", "300"))

        If iLeft > System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - iWidth Then iLeft = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - iWidth
        If iTop > System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - iHeight Then iTop = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - iHeight
        If iLeft < 0 Then iLeft = 0
        If iTop < 0 Then iTop = 0

        Forma.Opacity = sOpacidad
        Forma.Top = iTop
        Forma.Left = iLeft
        Forma.Width = iWidth
        Forma.Height = iHeight
        If GetSetting("MonitorSecadoras", "Grafica", Forma.Name & "Estado", "Normal") = "Normal" Then
        Else
            Forma.WindowState = FormWindowState.Maximized
        End If

    End Sub


    Sub MouseEncima(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim iItem As Integer
        Dim sTexto As String
        iItem = Val(sender.Text) - 1
        If iItem < Form1.ToolStripComboBox2.Items.Count Then
            sTexto = Mid(Form1.ToolStripComboBox2.Items(iItem), InStr(Form1.ToolStripComboBox2.Items(iItem), sSeparador) + Len(sSeparador))
            Form1.ToolTip1.Show(sTexto, sender, 0, sender.Height, 3000)
        End If
    End Sub

    Function Consulta(ByVal sSQL As String) As MySqlDataReader
        Dim mComando As MySqlCommand
        Dim mDataReader As MySqlDataReader
        mComando = New MySqlCommand
        If mConexion.State = ConnectionState.Open Then
            mComando.Connection = mConexion
            mComando.CommandText = sSQL
            Try
                mDataReader = mComando.ExecuteReader
            Catch mierror As MySql.Data.MySqlClient.MySqlException
                Select Case mierror.Number
                    Case 1064
                        mDataReader = Consulta("select * from usuarios where id=0")
                    Case Else
                        RealizarConexion()
                        mDataReader = Consulta(sSQL)
                End Select
            End Try
        Else
            RealizarConexion()
            mDataReader = Consulta(sSQL)
        End If
        Consulta = mDataReader
    End Function
    Function LapsoTiempo(ByVal dInicio As Date, ByVal dFin As Date) As String
        Dim sTemp As String
        Dim iDias As Integer
        Dim iHoras As Integer
        Dim iMinutos As Integer
        Dim iSegundos As Integer
        Dim sResultado As String
        'Dim sFormato As String
        Dim dTemp As TimeSpan
        dTemp = (dFin.Subtract(dInicio))
        iDias = dTemp.Days
        iHoras = dTemp.Hours
        iMinutos = dTemp.Minutes
        iSegundos = dTemp.Seconds
        sResultado = ""
        sTemp = ""
        If iDias > 0 Then sResultado = iDias & " dias "
        If iHoras > 0 Then sResultado = sResultado & iHoras.ToString("00") & ":"
        If iMinutos > 0 Or iHoras > 0 Then sResultado = sResultado & iMinutos.ToString("00") & ":"
        sResultado = sResultado & iSegundos.ToString("00")
        If iSegundos > 0 Then sTemp = " segundos"
        If iMinutos > 0 Then sTemp = " minutos"
        If iHoras > 0 Then sTemp = " horas"
        If iHoras = 0 And iMinutos = 0 And iSegundos = 0 Then sResultado = "nada"
        sResultado = sResultado & sTemp
        LapsoTiempo = sResultado
    End Function

    Function ValToTemp(ByVal lTemp As Integer) As String
        Dim sResultado As String
        If bEscalaFarenheit Then
            sResultado = lTemp.ToString("0").PadLeft(4) & " °F"
        Else
            sResultado = ((lTemp - 32) / 1.8).ToString("0").PadLeft(4) & " °C"
        End If
        ValToTemp = sResultado
    End Function
    Function Escala(ByVal lTemp As Integer) As Integer
        Dim lResultado As Integer
        If bEscalaFarenheit Then
            lResultado = lTemp
        Else
            lResultado = (lTemp - 32) / 1.8
        End If
        Escala = lResultado
    End Function
    Function BoolToOnOff(ByVal Estado As Boolean) As String
        Dim sResultado As String
        If Estado Then
            sResultado = "Encendido"
        Else
            sResultado = "Apagado"
        End If
        BoolToOnOff = sResultado
    End Function
    Function Unidades() As String
        If bEscalaFarenheit Then
            Unidades = "°F"
        Else
            Unidades = "°C"
        End If
    End Function
    Function Pendiente(ByVal TemperaturaActual As Long, ByVal TemperaturaAnterior As Long, ByVal HoraActual As Date, ByVal HoraAnterior As Date) As Long
        If TemperaturaActual <> TemperaturaAnterior And HoraActual <> HoraAnterior Then
            Pendiente = (TemperaturaActual - TemperaturaAnterior) / ((HoraActual - HoraAnterior).TotalSeconds)
        Else
            Pendiente = 0
        End If
    End Function
End Module