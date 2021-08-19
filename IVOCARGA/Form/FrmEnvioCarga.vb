'Imports System.Windows.Forms.VisualStyles
'Imports OutlookStyleControls
'Imports HierarchicalGrid
'Imports Dapfor.Net.Ui
Imports WinControls.ListView

Structure Datos
    Public peso As String
    Public envios As String
End Structure

Public Class frmEnvioCarga
    Dim colCliente As New Collection
    Dim autoCliente As New AutoCompleteStringCollection

    Dim eLista As Datos
    Dim alista As New ArrayList

    Dim NodoSeleccionado As TreeListNode
    Dim dt As DataTable

    Sub Inicio()
        Dim obj As New dtoCarga
        Dim ds As DataSet = obj.InicioOperacion

        With cboEstado
            .DataSource = ds.Tables(0)
            .DisplayMember = "estado"
            .ValueMember = "id"
            .SelectedIndex = 0
        End With
        With cboProducto
            .DataSource = ds.Tables(1)
            .DisplayMember = "producto"
            .ValueMember = "id"
            .SelectedIndex = 0
        End With
        With cboOrigen
            .DataSource = ds.Tables(2)
            .DisplayMember = "ciudad"
            .ValueMember = "id"
            .SelectedIndex = 0
        End With
        With cboDestino
            .DataSource = ds.Tables(2).Copy
            .DisplayMember = "ciudad"
            .ValueMember = "id"
            .SelectedIndex = 0
        End With
        With cboSegmento
            .DataSource = ds.Tables(4)
            .DisplayMember = "segmento"
            .ValueMember = "id"
            .SelectedIndex = 0
        End With

        Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        ObjProcesos.fnCargar_iWin_r(Me.txtCliente, ds.Tables(3).DefaultView, colCliente, autoCliente, 0)

        ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cboFuncionario, "", "", 3, " (TODO)")

        Me.cboTipoEntrega.SelectedIndex = 0
    End Sub

    Private Sub frmEnvioCarga_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.tree.Nodes.Count > 0 Then
                Me.Cursor = Cursors.AppStarting
                cmsOpcion.Show(sender, e.X, e.Y)
                Me.Cursor = Cursors.Default
            End If
        End If

    End Sub

    Private Sub Form1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Cursor = Cursors.Default
    End Sub

    Private Sub txtCliente_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Not autoCliente.IndexOf(txtCliente.Text) = -1 Then
                Dim ObjPersona As New ClsLbTepsa.dtoPersona
                With ObjPersona
                    .IDPERSONA = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'Datahelper
                    ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                    Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                End With
            Else
                Me.txtCodigoCliente.Text = ""
            End If
        End If
    End Sub

    Private Sub txtCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtCliente.LostFocus
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            Me.txtCliente.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtCodigoCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                If Me.txtCodigoCliente.Text.Trim.Length > 0 Then
                    Dim obj As New dtoCarga
                    Dim strCodigoCliente As String = Me.txtCodigoCliente.Text.Trim
                    Dim dt As DataTable = obj.ObtieneCliente(strCodigoCliente)
                    If dt.Rows.Count > 0 Then
                        Me.txtCliente.Text = dt.Rows(0).Item("cliente")
                    Else
                        MessageBox.Show("El Cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCodigoCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtCodigoCliente.LostFocus
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            Me.txtCliente.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtCodigoCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Limpiar
    End Sub

    Private Sub txtCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCliente.TextChanged
        Limpiar()
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstado.SelectedIndexChanged
        Limpiar()
    End Sub

    Private Sub cboProducto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProducto.SelectedIndexChanged
        Limpiar()
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaInicio.ValueChanged
        Limpiar()
    End Sub

    Private Sub dtpFechaFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaFin.ValueChanged
        Limpiar()
    End Sub

    Private Sub cboFuncionario_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboFuncionario.SelectedIndexChanged
        Limpiar()
    End Sub

    Private Sub cboOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOrigen.SelectedIndexChanged
        Limpiar()
    End Sub

    Private Sub cboDestino_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDestino.SelectedIndexChanged
        Limpiar()
    End Sub

    Private Sub cboSegmento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSegmento.SelectedIndexChanged
        Limpiar()
    End Sub

    Private Sub dgvLista_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex > 3 AndAlso e.ColumnIndex Mod 2 <> 0 Then
            If Not IsDBNull(e.Value) AndAlso e.Value = 0 Then
                e.Value = ""
            End If
        End If
    End Sub

    Sub Formatear()
        'With dgvLista
        '    .Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
        '    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        '    .ReadOnly = True
        '    .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        '    .ColumnHeadersHeight = 35
        '    .AllowUserToAddRows = False

        '    For Each col As DataGridViewColumn In .Columns
        '        If col.Index > 3 Then
        '            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '            col.HeaderCell.Tag = col.HeaderText
        '            If col.Index Mod 2 = 0 Then
        '                col.HeaderText = "Kg"
        '                col.DefaultCellStyle.Format = "0.00"
        '            Else
        '                col.HeaderText = "Envios"
        '            End If
        '        End If
        '    Next

        'Dim dblTotal As Double = 0
        'For Each col1 As DataGridViewColumn In .Columns
        '    If col1.Index > 3 Then
        '        For Each row1 As DataGridViewRow In .Rows
        '            dblTotal += IIf(IsDBNull(row1.Cells(col1.Index).Value), 0, row1.Cells(col1.Index).Value)
        '        Next
        '        If dblTotal > 0 Then
        '            .Rows(.Rows.Count - 1).Cells(col1.Index).Value = dblTotal
        '            dblTotal = 0
        '        End If
        '    End If
        'Next

        'Dim intTotal As Integer = 0
        'dblTotal = 0
        'For Each row1 As DataGridViewRow In .Rows
        '    For Each col1 As DataGridViewColumn In .Columns
        '        If col1.Index > 3 Then
        '            If col1.Index Mod 2 = 0 Then
        '                dblTotal += IIf(IsDBNull(row1.Cells(col1.Index).Value), 0, row1.Cells(col1.Index).Value)
        '            Else
        '                intTotal += IIf(IsDBNull(row1.Cells(col1.Index).Value), 0, row1.Cells(col1.Index).Value)
        '            End If
        '        End If
        '    Next
        '    If dblTotal > 0 Then
        '        row1.Cells(.Columns.Count - 1).Value = dblTotal
        '        dblTotal = 0
        '    End If
        '    If intTotal > 0 Then
        '        row1.Cells(.Columns.Count - 1).Value = intTotal
        '        intTotal = 0
        '    End If
        'Next
        'End With
    End Sub

    Private Sub dgvLista_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        'With Me.dgvLista
        '    Dim j As Integer = 4
        '    While j < .Columns.Count
        '        Dim r1 As Rectangle = Me.dgvLista.GetCellDisplayRectangle(j, -1, True)
        '        r1.X += 1
        '        r1.Y += 1
        '        r1.Width = r1.Width * 2 - 2
        '        r1.Height = r1.Height / 2 - 8

        '        e.Graphics.FillRectangle(New SolidBrush(Me.dgvLista.ColumnHeadersDefaultCellStyle.BackColor), r1)

        '        Dim format As New StringFormat()

        '        format.Alignment = StringAlignment.Center
        '        format.LineAlignment = StringAlignment.Center
        '        e.Graphics.DrawString(.Columns(j).HeaderCell.Tag.ToString.Substring(1, 10), Me.dgvLista.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.dgvLista.ColumnHeadersDefaultCellStyle.ForeColor), r1, format)
        '        j += 2
        '    End While
        'End With
    End Sub

    Private Sub dgvLista_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs)
        'If (e.ColumnIndex = 0 Or e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3) AndAlso e.RowIndex <> -1 Then
        '    Using gridBrush As Brush = New SolidBrush(Me.dgvLista.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)
        '        Using gridLinePen As Pen = New Pen(gridBrush)
        '            e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

        '            If e.RowIndex < dgvLista.Rows.Count - 2 AndAlso dgvLista.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
        '                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
        '            End If

        '            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

        '            If Not e.Value Is Nothing Then
        '                If e.RowIndex > 0 AndAlso dgvLista.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value.ToString() = e.Value.ToString() Then
        '                Else
        '                    e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
        '                End If
        '            End If
        '            e.Handled = True
        '        End Using
        '    End Using
        'End If
    End Sub

    Public Class RootDataObject
        Dim strName As String
        Sub New()
        End Sub
        Sub New(name As String)
            strName = name
        End Sub
        Public ReadOnly Property Name() As String
            Get
                Return strName
            End Get
        End Property
    End Class

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor = Cursors.AppStarting
            'Dim rec As Rectangle = Screen.PrimaryScreen.WorkingArea

            'Dim classResize As New clsResizeForm
            'classResize.ResizeForm(Me, 1280, 800)

            'Me.Location = Screen.PrimaryScreen.WorkingArea.Location
            'Me.Size = Screen.PrimaryScreen.WorkingArea.Size
            Inicio()

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltrar.Click
        Try
            If Me.cboEstado.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Estado de la Carga", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboEstado.Focus()
                Return
            End If

            If DateDiff(DateInterval.Day, Me.dtpFechaInicio.Value, Me.dtpFechaFin.Value) > 31 Then
                MessageBox.Show("El Rango de fechas no debe ser mayor a 1 mes", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpFechaInicio.Focus()
                Return
            End If

            Cursor = Cursors.AppStarting
            Filtrar()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub _addSubItems(ByVal aObj As ContainerListViewObject, peso As Double, envios As Integer)
        With aObj.SubItems
            Dim intContador = 0
            Dim item As Datos
            Dim strPeso As String, strEnvios As String = IIf(envios = 0, "", envios)
            Dim dblPeso As Double
            For Each item In alista
                If intContador = 0 Then
                    strPeso = IIf(peso = 0, "", Format(peso, "0.00"))
                    .Add(strPeso.Trim)
                    .Add(envios.ToString.Trim)
                End If
                dblPeso = Val(item.peso)
                strPeso = IIf(dblPeso = 0, "", dblPeso.ToString("0.00"))

                strEnvios = IIf(item.envios = "0", "", item.envios)
                .Add(strPeso.Trim)
                .Add(strEnvios.Trim)
                intContador = 1
            Next
        End With
    End Sub

    Sub ObtieneTotal(dt As DataTable, nivel As Integer, ByRef peso As Double, ByRef envios As Integer, Optional destino As String = "", Optional producto As String = "", Optional segmento As String = "", Optional cliente As String = "")
        Dim intEnvios As Integer, dblPeso As Double = 0
        Dim intFecha As Integer = DateDiff(DateInterval.Day, Me.dtpFechaInicio.Value, Me.dtpFechaFin.Value)
        Dim strPeso As String = "", strEnvios As String = ""
        Dim dblPesoTotal As Double = 0, intEnviosTotal As Integer = 0

        If nivel = 1 Then
            Dim filas() As DataRow = dt.Select("nivel=1 and destino='" & destino & "'")
            For Each row As DataRow In filas
                For i As Integer = 0 To intFecha
                    strPeso = "peso" & i + 1
                    strEnvios = "envios" & i + 1
                    dblPeso = IIf(IsDBNull(row.Item(strPeso)), 0, row.Item(strPeso))
                    intEnvios = IIf(IsDBNull(row.Item(strEnvios)), 0, row.Item(strEnvios))

                    dblPesoTotal += dblPeso
                    intEnviosTotal += intEnvios

                    eLista.envios = intEnvios
                    eLista.peso = dblPeso
                    alista.Add(eLista)
                Next
            Next
        ElseIf nivel = 2 Then
            Dim filas() As DataRow = dt.Select("nivel=2 and destino='" & destino & "' and producto='" & producto & "'")
            For Each row As DataRow In filas
                For i As Integer = 0 To intFecha
                    strPeso = "peso" & i + 1
                    strEnvios = "envios" & i + 1
                    dblPeso = IIf(IsDBNull(row.Item(strPeso)), 0, row.Item(strPeso))
                    intEnvios = IIf(IsDBNull(row.Item(strEnvios)), 0, row.Item(strEnvios))

                    dblPesoTotal += dblPeso
                    intEnviosTotal += intEnvios

                    eLista.envios = intEnvios
                    eLista.peso = dblPeso
                    alista.Add(eLista)
                Next
            Next
        ElseIf nivel = 3 Then
            Dim filas() As DataRow = dt.Select("nivel=3 and destino='" & destino & "' and producto='" & producto & "' and segmento='" & segmento & "'")
            For Each row As DataRow In filas
                For i As Integer = 0 To intFecha
                    strPeso = "peso" & i + 1
                    strEnvios = "envios" & i + 1
                    dblPeso = IIf(IsDBNull(row.Item(strPeso)), 0, row.Item(strPeso))
                    intEnvios = IIf(IsDBNull(row.Item(strEnvios)), 0, row.Item(strEnvios))

                    dblPesoTotal += dblPeso
                    intEnviosTotal += intEnvios

                    eLista.envios = intEnvios
                    eLista.peso = dblPeso
                    alista.Add(eLista)
                Next
            Next
        ElseIf nivel = 4 Then
            Dim filas() As DataRow = dt.Select("nivel=4 and destino='" & destino & "' and producto='" & producto & "' and segmento='" & segmento & "' and cliente='" & cliente & "'")
            For Each row As DataRow In filas
                For i As Integer = 0 To intFecha
                    strPeso = "peso" & i + 1
                    strEnvios = "envios" & i + 1
                    dblPeso = IIf(IsDBNull(row.Item(strPeso)), 0, row.Item(strPeso))
                    intEnvios = IIf(IsDBNull(row.Item(strEnvios)), 0, row.Item(strEnvios))

                    dblPesoTotal += dblPeso
                    intEnviosTotal += intEnvios

                    eLista.envios = intEnvios
                    eLista.peso = dblPeso
                    alista.Add(eLista)
                Next
            Next
        ElseIf nivel = 0 Then
            For i As Integer = 0 To intFecha
                strPeso = "peso" & i + 1
                strEnvios = "envios" & i + 1

                dblPeso = IIf(IsDBNull(dt.Compute("sum(" & strPeso & ")", "nivel=1")), 0, dt.Compute("sum(" & strPeso & ")", "nivel=1"))
                intEnvios = IIf(IsDBNull(dt.Compute("sum(" & strEnvios & ")", "nivel=1")), 0, dt.Compute("sum(" & strEnvios & ")", "nivel=1"))

                'dblPeso = IIf(IsDBNull(row.Item(strPeso)), 0, row.Item(strPeso))
                'intEnvios = IIf(IsDBNull(row.Item(strEnvios)), 0, row.Item(strEnvios))

                dblPesoTotal += dblPeso
                intEnviosTotal += intEnvios

                eLista.envios = intEnvios
                eLista.peso = dblPeso
                alista.Add(eLista)
            Next
            'Dim filas() As DataRow = dt.Select("nivel=1")
            'For Each row As DataRow In filas
            '    For i As Integer = 0 To intFecha
            '        strPeso = "peso" & i + 1
            '        strEnvios = "envios" & i + 1
            '        dblPeso = IIf(IsDBNull(row.Item(strPeso)), 0, row.Item(strPeso))
            '        intEnvios = IIf(IsDBNull(row.Item(strEnvios)), 0, row.Item(strEnvios))

            '        dblPesoTotal += dblPeso
            '        intEnviosTotal += intEnvios

            '        eLista.envios = intEnvios
            '        eLista.peso = dblPeso
            '        alista.Add(eLista)
            '    Next
            'Next
        End If
        peso = dblPesoTotal
        envios = intEnviosTotal
    End Sub

    Sub Filtrar()
        Dim obj As New dtoCarga

        Dim intCliente As Integer
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            intCliente = 0
        Else
            intCliente = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
        End If
        Dim ds As DataSet = obj.prueba(Me.cboEstado.SelectedValue, _
        Me.cboOrigen.SelectedValue, Me.cboDestino.SelectedValue, _
        Me.cboProducto.SelectedValue, _
        Me.dtpFechaInicio.Value.ToShortDateString, Me.dtpFechaFin.Value.ToShortDateString,
        Me.cboFuncionario.SelectedValue, Me.cboSegmento.SelectedValue, intCliente, Me.cboTipoEntrega.SelectedIndex, _
        Me.cboAgenciaOrigen.SelectedValue, Me.cboAgenciaDestino.SelectedValue)

        dt = ds.Tables(0)
        With tree
            .Nodes.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                Cabecera()

                Dim dblPeso As Double = 0, intEnvios As Integer = 0
                Dim strDestino As String = "", strProducto As String = "", strSegmento As String = "", strCliente As String = ""

                Dim padre As New TreeListNode(), hijo1 As New TreeListNode(), hijo2 As New TreeListNode(), hijo3 As New TreeListNode()
                Dim total As New TreeListNode()
                For Each row As DataRow In ds.Tables(0).Rows
                    If row.Item("destino").ToString <> strDestino Or strDestino = "" Then
                        alista.Clear()
                        ObtieneTotal(ds.Tables(1), 1, dblPeso, intEnvios, row.Item("destino"))
                        padre = New TreeListNode(row.Item("destino"))
                        padre.TextAlign = HorizontalAlignment.Right
                        Me._addSubItems(padre, dblPeso, intEnvios)
                        tree.Nodes.Add(padre)
                    End If
                    If (row.Item("destino").ToString <> strDestino Or row.Item("producto").ToString <> strProducto) Or strProducto = "" Then
                        alista.Clear()
                        ObtieneTotal(ds.Tables(1), 2, dblPeso, intEnvios, row.Item("destino"), row.Item("producto"))
                        hijo1 = New TreeListNode(row.Item("producto"))
                        hijo1.TextAlign = HorizontalAlignment.Right
                        Me._addSubItems(hijo1, dblPeso, intEnvios)
                        padre.Nodes.Add(hijo1)
                    End If
                    If (row.Item("destino").ToString <> strDestino Or row.Item("producto").ToString <> strProducto Or row.Item("segmento").ToString <> strSegmento) Or strSegmento = "" Then
                        alista.Clear()
                        ObtieneTotal(ds.Tables(1), 3, dblPeso, intEnvios, row.Item("destino"), row.Item("producto"), row.Item("segmento"))
                        hijo2 = New TreeListNode(row.Item("segmento"))
                        hijo2.TextAlign = HorizontalAlignment.Right
                        Me._addSubItems(hijo2, dblPeso, intEnvios)
                        hijo1.Nodes.Add(hijo2)
                    End If
                    If (row.Item("destino").ToString <> strDestino Or row.Item("producto").ToString <> strProducto Or row.Item("segmento").ToString <> strSegmento Or row.Item("cliente").ToString <> strCliente) Or strCliente = "" Then
                        alista.Clear()
                        ObtieneTotal(ds.Tables(1), 4, dblPeso, intEnvios, row.Item("destino"), row.Item("producto"), row.Item("segmento"), row.Item("cliente"))
                        hijo3 = New TreeListNode(row.Item("cliente"))
                        hijo3.TextAlign = HorizontalAlignment.Right
                        Me._addSubItems(hijo3, dblPeso, intEnvios)
                        hijo2.Nodes.Add(hijo3)
                    End If

                    strDestino = row.Item("destino").ToString
                    strProducto = row.Item("producto").ToString
                    strSegmento = row.Item("segmento").ToString
                    strCliente = row.Item("cliente").ToString
                Next 'treeview

                'agrega fila total por dia
                padre = New TreeListNode("TOTAL")
                padre.TextAlign = HorizontalAlignment.Right
                alista.Clear()
                ObtieneTotal(ds.Tables(1), 0, dblPeso, intEnvios)
                Me._addSubItems(padre, dblPeso, intEnvios)

                padre.Font = New Font("Microsoft Sans Serif", 8.5!, FontStyle.Bold)
                tree.Nodes.Add(padre)

                'agregar total
                Me.lblPeso.Text = Format(dblPeso, "###,###,###,###.00")
                Me.lblEnvios.Text = Format(intEnvios)

                'eliminar columnas sin monto
                Dim strCadena As String, intColumna As Integer = 3

                Dim intFecha As Integer = DateDiff(DateInterval.Day, Me.dtpFechaInicio.Value, Me.dtpFechaFin.Value)
                For i As Integer = 0 To intFecha
                    strCadena = "sum(peso" & i + 1 & ")"
                    Dim intValor1 As Integer = IIf(IsDBNull(dt.Compute(strCadena, "")), 0, dt.Compute(strCadena, ""))

                    strCadena = "sum(envios" & i + 1 & ")"
                    Dim intValor2 As Integer = IIf(IsDBNull(dt.Compute(strCadena, "")), 0, dt.Compute(strCadena, ""))

                    If intValor1 + intValor2 = 0 Then
                        tree.Columns(intColumna).Hidden = True
                        tree.Columns(intColumna + 1).Hidden = True
                    End If
                    intColumna += 2
                Next

                Me.btnExportar.Enabled = True
            Else
                Me.btnExportar.Enabled = False
            End If
        End With
    End Sub

    Private Sub tree_AfterSelect(sender As Object, e As WinControls.ListView.EventArgClasses.ContainerListViewEventArgs) Handles tree.AfterSelect
        Dim Nde As TreeListNode = DirectCast(e.Item, TreeListNode)

        If (Not Nde Is Nothing) Then
            Me.lblGrupo.Text = Nde.FullPath
        Else
            Me.lblGrupo.Text = String.Empty
        End If

        NodoSeleccionado = Nde
    End Sub

    Private Sub tree_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tree.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.tree.Nodes.Count > 0 Then
                Me.Cursor = Cursors.AppStarting
                cmsOpcion.Show(sender, e.X, e.Y)
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub Cabecera()
        Dim intFecha As Integer = DateDiff(DateInterval.Day, Me.dtpFechaInicio.Value, Me.dtpFechaFin.Value)
        Dim strFecha As String = Me.dtpFechaInicio.Value.ToShortDateString
        With Me.tree.Columns
            .Clear()
            .Add("Grupo", 250, HorizontalAlignment.Center)
            .Add("Total Peso", 80, HorizontalAlignment.Center)
            .Add("Total Envios", 80, HorizontalAlignment.Center)
            For i As Integer = 0 To intFecha
                .Add(New ContainerColumnHeader(strFecha & " Kg", 100))
                .Add(New ContainerColumnHeader("Envio", 65))
                strFecha = DateAdd(DateInterval.Day, 1, CDate(strFecha))
            Next
            If intFecha >= 5 Then
                .Add("", 70, HorizontalAlignment.Left)
            End If
        End With
    End Sub

    Sub Limpiar()
        tree.Nodes.Clear()
        tree.Columns.Clear()
        Me.lblEnvios.Text = ""
        Me.lblPeso.Text = ""
        Me.lblGrupo.Text = ""
        Me.btnExportar.Enabled = False
    End Sub

    Private Sub ExpandirNodoSeleccionadoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExpandirNodoSeleccionadoToolStripMenuItem.Click
        ExpandirColapsarNodo(NodoSeleccionado, 1)
    End Sub

    Private Sub ColapsarNodoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ColapsarNodoToolStripMenuItem.Click
        ExpandirColapsarNodo(NodoSeleccionado, 2)
    End Sub

    Private Sub ExpandirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExpandirToolStripMenuItem.Click
        Dim intNivel As Integer = NodoSeleccionado.Level

        For Each node As TreeListNode In tree.Nodes
            ExpandirColapsarNodo(node, 1, intNivel)
        Next
    End Sub

    Private Sub ColapsarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ColapsarToolStripMenuItem.Click
        Dim intNivel As Integer = NodoSeleccionado.Level

        For Each node As TreeListNode In tree.Nodes
            ExpandirColapsarNodo(node, 2, intNivel)
        Next
    End Sub

    Sub ExpandirColapsarNodo(nodo As TreeListNode, operacion As Integer, Optional nivel As Integer = -1)
        If operacion = 1 Then
            If nivel = -1 Then
                nodo.Expand()
            ElseIf nodo.Level <= nivel Then
                nodo.Expand()
            End If
        Else
            If nivel = -1 Then
                nodo.Collapse()
            ElseIf nodo.Level = nivel Then
                nodo.Collapse()
            End If
        End If
        For Each node As TreeListNode In nodo.Nodes
            If operacion = 1 Then
                If nivel = -1 Then
                    node.Expand()
                ElseIf node.Level <= nivel Then
                    node.Expand()
                End If
            Else
                If nivel = -1 Then
                    node.Collapse()
                ElseIf node.Level = nivel Then
                    node.Collapse()
                End If
            End If
            ExpandirColapsarNodo(node, operacion, nivel)
        Next
    End Sub

    Private Sub btnExportar_Click(sender As System.Object, e As System.EventArgs) Handles btnExportar.Click
        Cursor = Cursors.AppStarting
        Dim xlApp As New Excel.Application()
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        Try
            Dim rowIndex, colIndex, i, j As Integer
            rowIndex = 1
            colIndex = 0
            xlBook = xlApp.Workbooks().Add
            xlSheet = xlBook.Worksheets("hoja1")

            'cabecera
            For i = 0 To tree.Columns.Count - 1
                colIndex = colIndex + 1
                If i >= 3 Then
                    If i Mod 2 <> 0 Then
                        If tree.Columns(i).Text.ToString.Length > 0 Then
                            Dim strFecha As String = tree.Columns(i).Text.Substring(0, 10)
                            xlApp.Cells(1, colIndex + 1) = " " & strFecha
                            xlApp.Cells(2, colIndex + 1) = "PESO"
                        End If
                    Else
                        xlApp.Cells(2, colIndex + 1) = tree.Columns(i).Text.ToString.ToUpper
                    End If
                Else
                    If tree.Columns(i).Text.ToString.ToUpper = "GRUPO" Then
                        xlApp.Cells(2, colIndex) = tree.Columns(i).Text.ToString.ToUpper
                    Else
                        'xlApp.Cells(2, colIndex + 3) = tree.Columns(i).Text.ToString.ToUpper
                    End If
                End If
            Next
            'detalle
            rowIndex = 2
            For i = 0 To dt.Rows.Count - 1
                rowIndex = rowIndex + 1
                colIndex = 0
                For j = 0 To dt.Columns.Count - 1
                    colIndex = colIndex + 1
                    If j < 4 Then
                        xlApp.Cells(rowIndex, colIndex) = dt.Rows(i).Item(j).ToString
                    Else
                        If Val(dt.Rows(i).Item(j).ToString) = 0 Then
                            xlApp.Cells(rowIndex, colIndex) = ""
                        Else
                            xlApp.Cells(rowIndex, colIndex) = dt.Rows(i).Item(j).ToString
                        End If
                    End If
                Next
            Next

            With xlSheet
                '.Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Name = "Arial"
                .Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Bold = True
                .Range(.Cells(2, 1), .Cells(2, colIndex)).Font.Bold = True
                '.Range(.Cells(1, 1), .Cells(rowIndex, colIndex)).Borders.LineStyle = 1

                Dim car As String = "D"
                For i = 0 To tree.Columns.Count - 1
                    If i >= 3 Then
                        If i Mod 2 <> 0 Then
                            .Range(.Cells(3, i), .Cells(dt.Rows.Count - 1 + 3, i)).NumberFormat = "###,###,###.00"
                        End If
                        'car = Chr(Asc(car) + 1)
                        car = IncrementaCarExcel(car)
                        xlApp.Cells(dt.Rows.Count + 3, i + 2) = "=sum(" & car & "1:" & car & dt.Rows.Count + 2 & ")"
                        .Range(.Cells(dt.Rows.Count + 3, i + 2), .Cells(dt.Rows.Count + 3, i + 2)).NumberFormat = "###,###,###.00"
                        .Range(.Cells(dt.Rows.Count + 3, i + 2), .Cells(dt.Rows.Count + 3, i + 2)).Font.Bold = True
                    End If
                Next
                xlApp.Cells(dt.Rows.Count + 5, 4) = "TOTAL PESO" : xlApp.Cells(dt.Rows.Count + 5, 5) = Me.lblPeso.Text
                xlApp.Cells(dt.Rows.Count + 6, 4) = "TOTAL ENVIOS" : xlApp.Cells(dt.Rows.Count + 6, 5) = Me.lblEnvios.Text
                .Range(.Cells(dt.Rows.Count + 5, 4), .Cells(dt.Rows.Count + 6, 5)).Font.Bold = True

                .Columns.AutoFit()
            End With

            Cursor = Cursors.Default
            xlApp.Visible = True
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            xlApp.Quit()
            xlApp.Visible = False
        End Try
    End Sub

    Function IncrementaCarExcel(car As String) As String
        Dim car1 As String = ""
        Dim car2 As String = ""
        Dim car3 As String = ""

        car1 = car
        If Asc(car1) + 1 <= 90 Then
            car3 = Chr(Asc(car1) + 1)
        Else
            If car.Length = 1 Then
                car1 = "A"
                car2 = "A"
            Else
                car1 = "A"
                car2 = Chr(Asc(car1) + 1)
            End If
            car3 = car1 + car2
        End If
        Return car3
    End Function

    Private Sub cboOrigen_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboOrigen.SelectedValueChanged
        If IsReference(Me.cboOrigen.SelectedValue) Then Return
        Dim obj As New dtoCarga
        Dim dt As DataTable = obj.ListarAgencias(cboOrigen.SelectedValue)
        With Me.cboAgenciaOrigen
            .DataSource = dt
            .DisplayMember = "agencia"
            .ValueMember = "id"
        End With
    End Sub

    Private Sub cboDestino_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboDestino.SelectedValueChanged
        If IsReference(Me.cboDestino.SelectedValue) Then Return
        Dim obj As New dtoCarga
        Dim dt As DataTable = obj.ListarAgencias(cboDestino.SelectedValue)
        With Me.cboAgenciaDestino
            .DataSource = dt
            .DisplayMember = "agencia"
            .ValueMember = "id"
        End With
    End Sub

    Private Sub cboTipoEntrega_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoEntrega.SelectedIndexChanged
        Limpiar()
    End Sub

    Private Sub cboAgenciaOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAgenciaOrigen.SelectedIndexChanged
        Limpiar()
    End Sub

    Private Sub cboAgenciaDestino_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAgenciaDestino.SelectedIndexChanged
        Limpiar()
    End Sub
End Class