Option Strict Off
Option Explicit On
Friend Class Form2
	Inherits System.Windows.Forms.Form
    Dim mDatos As Mensaje
    'Dim cPuntos As Collection

    Private Sub Form2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'cPuntos = New Collection
        mDatos = Me.Tag
        'cPuntos = mDatos.Puntos
        Me.TopMost = True
        Label1(1).Text = "Id"
        Label1(2).Text = "Fecha"
        Label1(3).Text = "Secadora"
        Label1(4).Text = "Temp Entrada"
        Label1(5).Text = "Temp Salida"
        Label1(6).Text = "Formula"
        Label1(7).Text = "Display"
        Label1(8).Text = "Ventilador"
        Label1(9).Text = "Quemador"

    End Sub


    Private Sub ActualizarCuadro(ByVal SQL As String)
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
        Dim lIter As Long
        For lIter = 1 To 10
            Text1(lIter).Text = ""
        Next
        mLector = Consulta(SQL)
        If mLector.Read Then
            Text1(1).Text = mLector.Item("id")
            Text1(2).Text = CDate(mLector.Item("fecha")).ToString("yyyy-MM-dd HH:mm:ss")
            Text1(3).Text = mLector.Item("secadora")         'secadora
            Text1(4).Text = ValToTemp(mLector.Item("temp1"))
            Text1(5).Text = ValToTemp(mLector.Item("temp2"))
            Text1(6).Text = mLector.Item("formula")
            Text1(7).Text = mLector.Item("display")
            Text1(8).Text = BoolToOnOff(mLector.Item("entrada1"))
            Text1(9).Text = BoolToOnOff(mLector.Item("entrada2"))
            Text1(10).Text = (CInt(mLector.Item("version")) / 100).ToString("0.00")
            Text = "Sec " & Text1(3).Text & " @ " & Text1(2).Text
        End If
        mLector.Close()


    End Sub
    Private Function BuscaInicio() As String
        Dim sSQL As String
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
        Dim bVentiladorTrabajando As Boolean
        Dim bVentiladorTrabajandoAnterior As Boolean
        BuscaInicio = ""
        sSQL = "SELECT fecha,entrada1 FROM lecturas where secadora=" & Text1(3).Text & " and id < " & Text1(1).Text & " order by id DESC"
        mLector = Consulta(sSQL)
        Do While mLector.Read
            bVentiladorTrabajando = mLector.Item("entrada1")
            If bVentiladorTrabajando = False And bVentiladorTrabajandoAnterior = True Then
                BuscaInicio = CDate(mLector.Item("fecha")).ToString("yyyy-MM-dd HH:mm:ss")
                Exit Function
            End If
            bVentiladorTrabajandoAnterior = bVentiladorTrabajando
        Loop
        mLector.Close()

    End Function
    Private Function BuscaFin() As String
        Dim sSQL As String
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
        Dim bVentiladorTrabajando As Boolean
        Dim bVentiladorTrabajandoAnterior As Boolean
        BuscaFin = ""

        sSQL = "SELECT fecha,entrada1 FROM lecturas where secadora=" & Text1(3).Text & " and id > " & Text1(1).Text & " order by id"
        mLector = Consulta(sSQL)
        Do While mLector.Read
            bVentiladorTrabajando = mLector.Item("entrada1")
            If bVentiladorTrabajando = False And bVentiladorTrabajandoAnterior = True Then
                BuscaFin = CDate(mLector.Item("fecha")).ToString("yyyy-MM-dd HH:mm:ss")
                Exit Function
            End If
            bVentiladorTrabajandoAnterior = bVentiladorTrabajando
        Loop
        mLector.Close()

    End Function

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim sFechaInicio As String
        Dim sFechaFin As String
        Dim fGrafica As New Form5

        sFechaInicio = BuscaInicio()
        sFechaFin = BuscaFin()
        If Len(sFechaInicio) And Len(sFechaFin) Then
            Form1.ToolStripComboBox2.Text = ""
            cGraficas.Add(fGrafica)
            fGrafica.Tag = Text1(3).Text & sSeparador & sFechaInicio & sSeparador & sFechaFin & sSeparador
            fGrafica.Show()
        End If

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim sSQL As String
        Dim fVentana As Form5
        Dim lPunto As Long

        lPunto = Val(Text1(0).Text) - 1
        If lPunto < 0 Then lPunto = 0




        If mDatos.Ventana.Name = "Form1" Then
            If lPunto > Form1.Chart1.Series.Item("Temp1").Points.Count - 1 Then lPunto = Form1.Chart1.Series.Item("Temp1").Points.Count - 1
            Text1(0).Text = lPunto
            sSQL = "SELECT id,fecha,secadora,temp1,temp2,formula,display,entrada1,entrada2,version FROM lecturas where secadora=" & mDatos.Esclavo & " and id =" & Form1.Chart1.Series.Item("Temp1").Points.Item(lPunto).Tag & ""
            Form1.Chart1.ChartAreas(0).CursorX.SetCursorPosition(lPunto + 1)
        Else

            fVentana = mDatos.Ventana
            If lPunto > fVentana.Chart1.Series.Item("Temp1").Points.Count - 1 Then lPunto = fVentana.Chart1.Series.Item("Temp1").Points.Count - 1
            Text1(0).Text = lPunto
            sSQL = "SELECT id,fecha,secadora,temp1,temp2,formula,display,entrada1,entrada2,version FROM lecturas where secadora=" & mDatos.Esclavo & " and id =" & fVentana.Chart1.Series.Item("Temp1").Points.Item(lPunto).Tag & ""

            fVentana.Chart1.ChartAreas(0).CursorX.SetCursorPosition(lPunto + 1)

        End If
        ActualizarCuadro(sSQL)
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim fVentana As Form5
        Dim sSQL As String
        Dim lPunto As Long

        lPunto = Val(Text1(0).Text) + 1
        If lPunto < 0 Then lPunto = 0

        If mDatos.Ventana.Name = "Form1" Then
            If lPunto > Form1.Chart1.Series.Item("Temp1").Points.Count - 1 Then lPunto = Form1.Chart1.Series.Item("Temp1").Points.Count - 1
            Text1(0).Text = lPunto
            sSQL = "SELECT id,fecha,secadora,temp1,temp2,formula,display,entrada1,entrada2,version FROM lecturas where secadora=" & mDatos.Esclavo & " and id =" & Form1.Chart1.Series.Item("Temp1").Points.Item(lPunto).Tag & ""
            Form1.Chart1.ChartAreas(0).CursorX.SetCursorPosition(lPunto + 1)
        Else
            fVentana = mDatos.Ventana
            If lPunto > fVentana.Chart1.Series.Item("Temp1").Points.Count - 1 Then lPunto = fVentana.Chart1.Series.Item("Temp1").Points.Count - 1
            Text1(0).Text = lPunto
            sSQL = "SELECT id,fecha,secadora,temp1,temp2,formula,display,entrada1,entrada2,version FROM lecturas where secadora=" & mDatos.Esclavo & " and id =" & fVentana.Chart1.Series.Item("Temp1").Points.Item(lPunto).Tag & ""
            fVentana.Chart1.ChartAreas(0).CursorX.SetCursorPosition(lPunto + 1)
        End If
        ActualizarCuadro(sSQL)
    End Sub

    
    Private Sub SuprimirKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _Text1_1.KeyPress, _Text1_2.KeyPress, _Text1_3.KeyPress, _Text1_4.KeyPress, _Text1_5.KeyPress, _Text1_6.KeyPress, _Text1_7.KeyPress, _Text1_8.KeyPress, _Text1_9.KeyPress, _Text1_10.KeyPress, _Text1_0.KeyPress
        e.Handled = True
    End Sub

    
   
End Class