Public Class infoadicional
    Dim cID As Collection

    Private Sub infoadicional_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GuardarPosicion(Me)
        GuardarAnchoColumnas(Me, DataGridView1)
    End Sub
    Private Sub infoadicional_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sSQL As String

        Dim bVentiladorTrabajando As Boolean
        Dim bVentiladorTrabajandoAnterior As Boolean
        Dim sID As String
        Dim iContador As Integer
        Dim iTotalRegistros As Integer
        Dim iSecadora As Integer
        Dim iCarga As Integer
        Dim iSecadoraAnterior As Integer
        Dim iIter As Integer
        Dim mLector As MySql.Data.MySqlClient.MySqlDataReader

        ColocarForm(Me)
        cID = New Collection
        If Len(Form1.ToolStripComboBox1.Text) > 0 Then
            sSQL = "SELECT * FROM lecturas where secadora=" & Form1.ToolStripStatusLabel11.Tag & " and  fecha between '" & Form1.ToolStripStatusLabel3.Text & "' and '" & Form1.ToolStripStatusLabel1.Text & "' order by fecha"
        Else
            sSQL = "SELECT * FROM lecturas where fecha between '" & Form1.ToolStripStatusLabel3.Text & "' and '" & Form1.ToolStripStatusLabel1.Text & "' order by secadora,fecha"
        End If
        mLector = Consulta(sSQL)
        iContador = 0
        Do While mLector.Read
            bVentiladorTrabajando = mLector.Item("entrada1")
            If bVentiladorTrabajando = True And bVentiladorTrabajandoAnterior = False Then
                cID.Add(mLector.Item("id"))
                iContador = iContador + 1
            End If
            bVentiladorTrabajandoAnterior = bVentiladorTrabajando
        Loop
        mLector.Close()
        iTotalRegistros = iContador
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("No.", "No.")
        DataGridView1.Columns.Add("Secadora", "Secadora")
        DataGridView1.Columns.Add("Carga", "Carga")
        DataGridView1.Columns.Add("Inicio", "Inicio")
        DataGridView1.Columns.Add("Formula", "Formula")
        DataGridView1.Columns.Add("Marca", "Marca")
        DataGridView1.Columns.Add("P.O.", "P.O.")
        DataGridView1.Columns.Add("Corte", "Corte")
        DataGridView1.Columns.Add("Proceso", "Proceso")
        DataGridView1.Columns.Add("Fase", "Fase")
        DataGridView1.Columns.Add("Cantidad", "Cantidad")
        DataGridView1.Columns.Add("Observaciones", "Observaciones")

        For iIter = 0 To 11
            DataGridView1.Columns.Item(iIter).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns.Item(iIter).SortMode = DataGridViewColumnSortMode.NotSortable
        Next iIter
        For iIter = 0 To 3
            DataGridView1.Columns.Item(iIter).ReadOnly = True
        Next iIter
        DataGridView1.AllowUserToOrderColumns = False
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowCount = iContador
        iContador = 0

        For Each sID In cID
            DataGridView1.Item(0, iContador).Value = iContador + 1
            sSQL = "SELECT * FROM lecturas where id=" & sID & ""
            mLector = Consulta(sSQL)
            Do While mLector.Read
                iSecadora = mLector.Item(2)
                If iSecadora <> iSecadoraAnterior Then iCarga = 1
                DataGridView1.Item(1, iContador).Value = iSecadora
                DataGridView1.Item(2, iContador).Value = iCarga
                DataGridView1.Item(3, iContador).Value = mLector.Item(1)
                DataGridView1.Item(4, iContador).Value = mLector.Item(5)
                iCarga = iCarga + 1
                iContador = iContador + 1
                iSecadoraAnterior = iSecadora
            Loop
            mLector.Close()
        Next
        iContador = 0

        For Each sID In cID
            sSQL = "SELECT * FROM cargas where idlectura=" & sID & ""
            mLector = Consulta(sSQL)
            Do While mLector.Read
                DataGridView1.Item(5, iContador).Value = mLector.Item("marca")
                DataGridView1.Item(6, iContador).Value = mLector.Item("po")
                DataGridView1.Item(7, iContador).Value = mLector.Item("corte")
                DataGridView1.Item(8, iContador).Value = mLector.Item("proceso")
                DataGridView1.Item(9, iContador).Value = mLector.Item("fase")
                DataGridView1.Item(10, iContador).Value = mLector.Item("cantidad")
                DataGridView1.Item(11, iContador).Value = mLector.Item("observaciones")
            Loop
            mLector.Close()
            iContador = iContador + 1
        Next
        ToolStripLabel1.Text = "Renglones guardados: 0"
        CargarAnchoColumnas(Me, DataGridView1)

    End Sub



    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim sID As String
        Dim iContador As Integer
        Dim sFormula As String
        Dim sMarca As String
        Dim sPO As String
        Dim sCorte As String
        Dim sProceso As String
        Dim sFase As String
        Dim sCantidad As String
        Dim sObservaciones As String
        Dim iGuardados As Integer
        Dim sGuardados As String
        iContador = 0
        iGuardados = 0
        sGuardados = ""
        For Each sID In cID
            bRegistroGuardado = False
            sFormula = DataGridView1.Item(4, iContador).Value
            sMarca = DataGridView1.Item(5, iContador).Value
            sPO = DataGridView1.Item(6, iContador).Value
            sCorte = DataGridView1.Item(7, iContador).Value
            sProceso = DataGridView1.Item(8, iContador).Value
            sFase = DataGridView1.Item(9, iContador).Value
            sCantidad = DataGridView1.Item(10, iContador).Value
            sObservaciones = DataGridView1.Item(11, iContador).Value
            If Len(sFormula) > 0 Then sFormula = sFormula.Replace("'", "´")
            If Len(sMarca) > 0 Then sMarca = sMarca.Replace("'", "´")
            If Len(sPO) > 0 Then sPO = sPO.Replace("'", "´")
            If Len(sCorte) > 0 Then sCorte = sCorte.Replace("'", "´")
            If Len(sProceso) > 0 Then sProceso = sProceso.Replace("'", "´")
            If Len(sFase) > 0 Then sFase = sFase.Replace("'", "´")
            If Len(sCantidad) > 0 Then sCantidad = sCantidad.Replace("'", "´")
            If Len(sObservaciones) > 0 Then sObservaciones = sObservaciones.Replace("'", "´")
            If Len(sFormula) > 0 And Val(sCantidad) > 0 Then
                RegistrarCarga(Val(sID), Val(sFormula), sMarca, sPO, sCorte, sProceso, sFase, Val(sCantidad), sObservaciones)
                If bRegistroGuardado = False Then
                    MsgBox("El renglon " & iContador & "no se ha podido guardar")
                End If
            End If
            iContador = iContador + 1
            If bRegistroGuardado Then
                iGuardados = iGuardados + 1
                If Len(sGuardados) = 0 Then
                    sGuardados = sGuardados & iContador.ToString
                Else
                    sGuardados = sGuardados & sSeparador & iContador.ToString
                End If
            End If
        Next
        If Len(sGuardados) > 0 Then
            ToolStripLabel1.Text = "Renglones guardados: " & iGuardados.ToString & "(" & sGuardados & ")"
        End If
    End Sub




End Class