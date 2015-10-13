Public Class busqueda
    Dim cId As Collection
    Dim cCargas As Collection

    'Dim sMensaje() As String = {"Espere", "Espere.", "Espere..", "Espere..."}

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = Replace(TextBox1.Text, "'", "")
        Timer1.Enabled = False : Timer1.Enabled = True
    End Sub

    Sub Busqueda()
        'Dim sID As String
        'Dim cID As Collection
        'Dim iContador As Integer
        Dim sId As String
        Dim cCarga As Carga
        Dim iRegistros As Integer
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
        Dim sSQL As String
        Dim iContador As Integer
        'cID = New Collection
        '"select entradas.id from entradas  left join leidos on leidos.idusuario=" & iUsuario & " and entradas.id=leidos.identrada where leidos.identrada is null"
        Me.Cursor = Cursors.AppStarting
        sSQL = "select * from cargas  where "
        'sSQL = "SELECT * FROM cargas where "
        If Len(TextBox1.Text) > 0 Or Len(TextBox2.Text) > 0 Or Len(TextBox3.Text) > 0 Or Len(TextBox4.Text) > 0 Or Len(TextBox5.Text) > 0 Or Len(TextBox6.Text) > 0 Then
            If Len(TextBox1.Text) > 0 Then
                sSQL = sSQL & "cargas.marca like '" & TextBox1.Text & "%'"
                If Len(TextBox2.Text) > 0 Or Len(TextBox3.Text) > 0 Or Len(TextBox4.Text) > 0 Or Len(TextBox5.Text) > 0 Or Len(TextBox6.Text) > 0 Then sSQL = sSQL & " and "
            End If
            If Len(TextBox2.Text) > 0 Then
                sSQL = sSQL & "cargas.po like '" & TextBox2.Text & "%'"
                If Len(TextBox3.Text) > 0 Or Len(TextBox4.Text) > 0 Or Len(TextBox5.Text) > 0 Or Len(TextBox6.Text) > 0 Then sSQL = sSQL & " and "
            End If
            If Len(TextBox3.Text) > 0 Then
                sSQL = sSQL & "cargas.corte like '" & TextBox3.Text & "%'"
                If Len(TextBox4.Text) > 0 Or Len(TextBox5.Text) > 0 Or Len(TextBox6.Text) > 0 Then sSQL = sSQL & " and "
            End If
            If Len(TextBox4.Text) > 0 Then
                sSQL = sSQL & "cargas.proceso like '" & TextBox4.Text & "%'"
                If Len(TextBox5.Text) > 0 Or Len(TextBox6.Text) > 0 Then sSQL = sSQL & " and "
            End If
            If Len(TextBox5.Text) > 0 Then
                sSQL = sSQL & "cargas.fase like '" & TextBox5.Text & "%'"
                If Len(TextBox6.Text) > 0 Then sSQL = sSQL & " and "
            End If
            If Len(TextBox6.Text) > 0 Then
                sSQL = sSQL & "cargas.observaciones like '" & TextBox6.Text & "%'"
            End If
            If sSQL.EndsWith(" and ") Then
            Else
                sSQL = sSQL & " and "
            End If
        Else
            DataGridView1.RowCount = 0
        End If
        '        sSQL = sSQL & " fecha between '" & DateTimePicker1.Text & "' and date_add('" & DateTimePicker2.Text & "',interval 1 day)"
        sSQL = sSQL & " 1=1"
        DataGridView1.Rows.Clear()
        ToolStripLabel1.Text = "Encontrados: 0"
        mLector = Consulta(Replace(sSQL, "*", "count(*)"))
        If mLector.Read Then
            iRegistros = mLector.Item(0)
        End If
        mLector.Close()
        ToolStripLabel1.Text = "Encontrados: " & iRegistros.ToString
        'DataGridView1.RowCount = iRegistros


        cId.Clear()
        cCargas.Clear()
        If iRegistros > 0 Then
            'BackgroundWorker1.RunWorkerAsync(sSQL)
            DataGridView1.Visible = False
            mLector = Consulta(Replace(sSQL, "*", "idlectura"))
            Do While mLector.Read
                cId.Add(mLector.Item(0))
            Loop
            mLector.Close()
            iContador = 0
            For Each sid In cId
                mLector = Consulta("select * from lecturas where id=" & sId & " and fecha between '" & DateTimePicker1.Text & "' and date_add('" & DateTimePicker2.Text & "',interval 1 day) order by fecha desc")
                Do While mLector.Read
                    'cId.Add(mLector.Item(0))

                    cCarga = New Carga

                    iContador = iContador + 1
                    cCarga.Id = iContador
                    cCarga.IdInicio = mLector.Item("id")
                    cCarga.Esclavo = mLector.Item("secadora")
                    cCarga.Inicio = mLector.Item("fecha")
                    cCarga.Formula = mLector.Item("formula")
                    'DataGridView1.Item(0, iContador).Value = iContador
                    'DataGridView1.Rows.Add(cRen)

                    cCargas.Add(cCarga)
                Loop
                ToolStripLabel1.Text = "Encontrados: " & iContador.ToString
                mLector.Close()

            Next
            For Each cCarga In cCargas
                mLector = Consulta("select * from cargas where idlectura=" & cCarga.IdInicio)
                Do While mLector.Read
                    DataGridView1.Rows.Add(Split(cCarga.Id & sSeparador & cCarga.Esclavo & sSeparador & cCarga.Inicio & sSeparador & cCarga.Formula & sSeparador & mLector.Item("marca") & sSeparador & mLector.Item("po") & sSeparador & mLector.Item("corte") & sSeparador & mLector.Item("proceso") & sSeparador & mLector.Item("fase") & sSeparador & mLector.Item("cantidad") & sSeparador & mLector.Item("observaciones"), sSeparador))
                Loop
                mLector.Close()
            Next

            DataGridView1.Visible = True
        End If
        Me.Cursor = Cursors.Arrow


    End Sub
    Private Sub busqueda_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GuardarPosicion(Me)
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iIter As Integer
        ColocarForm(Me)
        cId = New Collection
        cCargas = New Collection
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("No.", "No.")
        DataGridView1.Columns.Add("Secadora", "Secadora")
        'DataGridView1.Columns.Add("Carga", "Carga")
        DataGridView1.Columns.Add("Inicio", "Inicio")
        DataGridView1.Columns.Add("Formula", "Formula")
        DataGridView1.Columns.Add("Marca", "Marca")
        DataGridView1.Columns.Add("P.O.", "P.O.")
        DataGridView1.Columns.Add("Corte", "Corte")
        DataGridView1.Columns.Add("Proceso", "Proceso")
        DataGridView1.Columns.Add("Fase", "Fase")
        DataGridView1.Columns.Add("Cantidad", "Cantidad")
        DataGridView1.Columns.Add("Observaciones", "Observaciones")
        For iIter = 0 To 10
            DataGridView1.Columns.Item(iIter).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            'DataGridView1.Columns.Item(iIter).SortMode = DataGridViewColumnSortMode.NotSortable
        Next iIter
        'Timer1.Enabled = False : Timer1.Enabled = True
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        TextBox2.Text = Replace(TextBox2.Text, "'", "")
        Timer1.Enabled = False : Timer1.Enabled = True
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        TextBox3.Text = Replace(TextBox3.Text, "'", "")
        Timer1.Enabled = False : Timer1.Enabled = True
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        TextBox4.Text = Replace(TextBox4.Text, "'", "")
        Timer1.Enabled = False : Timer1.Enabled = True
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        TextBox5.Text = Replace(TextBox5.Text, "'", "")
        Timer1.Enabled = False : Timer1.Enabled = True
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        TextBox6.Text = Replace(TextBox6.Text, "'", "")
        Timer1.Enabled = False : Timer1.Enabled = True
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim fGrafica As New Form5
        'Dim sSeccion() As String

        Dim bVentiladorTrabajando As Boolean
        Dim bVentiladorTrabajandoAnterior As Boolean
        Dim sSQL As String
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader
        Dim sHoraInicio As String
        Dim sHoraFin As String
        If e.RowIndex >= 0 Then
            Me.Cursor = Cursors.AppStarting
            sHoraInicio = CDate(DataGridView1.Item(2, e.RowIndex).Value).ToString("yyyy-MM-dd HH:mm:ss")
            'Form1.ToolStripComboBox1.Text = DataGridView1.Item(1, e.RowIndex).Value
            sHoraFin = ""
            sSQL = "SELECT fecha,entrada1 FROM lecturas where secadora=" & DataGridView1.Item(1, e.RowIndex).Value & " and fecha > '" & CDate(DataGridView1.Item(2, e.RowIndex).Value).ToString("yyyy-MM-dd HH:mm:ss") & "' order by fecha"
            mLector = Consulta(sSQL)
            Do While mLector.Read
                bVentiladorTrabajando = mLector.Item("entrada1")
                If bVentiladorTrabajando = False And bVentiladorTrabajandoAnterior = True Then
                    sHoraFin = CDate(mLector.Item("fecha")).ToString("yyyy-MM-dd HH:mm:ss")
                    Exit Do
                End If
                bVentiladorTrabajandoAnterior = bVentiladorTrabajando
            Loop
            mLector.Close()

            cGraficas.Add(fGrafica)
            fGrafica.Tag = DataGridView1.Item(1, e.RowIndex).Value & sSeparador & sHoraInicio & sSeparador & sHoraFin & sSeparador
            fGrafica.Show()
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim fArchivo As IO.StreamWriter
        Dim sContenidoCelda As String
        Dim sResultado As String
        Dim dRenglon As DataGridViewRow
        Dim dCelda As DataGridViewCell
        sResultado = "No.,Secadora,Inicio,Formula,Marca,P.O.,Corte,Proceso,Fase,Cantidad,Observaciones" & vbCrLf

        SaveFileDialog1.DefaultExt = ".csv"
        SaveFileDialog1.FileName = "Export " & (((Now.ToString).Replace(":", "_")).Replace("/", "-")) & ".csv"
        SaveFileDialog1.Filter = "Delimitado por comas|*.csv"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
        Else
            For Each dRenglon In DataGridView1.Rows
                For Each dCelda In dRenglon.Cells
                    sContenidoCelda = dCelda.FormattedValue.ToString
                    If InStr(sContenidoCelda, ",") Then sContenidoCelda = Chr(34) & sContenidoCelda & Chr(34)
                    sResultado = sResultado & sContenidoCelda
                    If dCelda.ColumnIndex < (dRenglon.Cells.Count - 1) Then sResultado = sResultado & ","
                Next
                sResultado = sResultado & vbCrLf
            Next
            'MsgBox(sResultado)

            fArchivo = New IO.StreamWriter(SaveFileDialog1.FileName.ToString)
            fArchivo.Write(sResultado)
            fArchivo.Close()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Timer1.Enabled = False : Timer1.Enabled = True
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        Timer1.Enabled = False : Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Busqueda()
    End Sub

    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cId.Clear()
        DataGridView1.Rows.Clear()
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""

        Timer1.Enabled = False : Timer1.Enabled = True
    End Sub
End Class