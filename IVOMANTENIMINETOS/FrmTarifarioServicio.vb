Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class FrmTarifaServicio
    Dim utilData As New UtilData_LN
    Dim utilitario As New Cls_Utilitarios

    Dim intTarifa As Integer = 0
    Dim intOpcion As Integer

    Dim blnEditaTarifa As Boolean = False
    Dim intFilasTarifa As Integer = 0

    Dim strFechaActivacion As String

    Public hnd As Long

#Region "Configurar Grid"
    Private Sub ConfigurarDGVLista()
        With dgvLista
            utilitario.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_idtarifa_servicio As New DataGridViewTextBoxColumn
            With col_idtarifa_servicio
                .Name = "idtarifa_servicio" : .DataPropertyName = "idtarifa_servicio"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino" : .HeaderText = "Destino"
                .DisplayIndex = x : .Visible = True
            End With
            x += +1
            Dim col_generico As New DataGridViewTextBoxColumn
            With col_generico
                .Name = "generico" : .DataPropertyName = "generico"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Generico"
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso" : .HeaderText = "Peso"
                .DisplayIndex = x : .Visible = True ': .DefaultCellStyle.Format = "0.00"
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_volumen As New DataGridViewTextBoxColumn
            With col_volumen
                .Name = "volumen" : .DataPropertyName = "volumen" : .HeaderText = "Volumen"
                .DisplayIndex = x : .Visible = True : .DefaultCellStyle.Format = "0.00"
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_sobre As New DataGridViewTextBoxColumn
            With col_sobre
                .Name = "sobre" : .DataPropertyName = "sobre" : .HeaderText = "Sobre"
                .DisplayIndex = x : .Visible = True : .DefaultCellStyle.Format = "0.00"
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto" : .HeaderText = "Producto"
                .DisplayIndex = x : .Visible = True
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_tipo_tarifa As New DataGridViewTextBoxColumn
            With col_tipo_tarifa
                .Name = "tipo_tarifa" : .DataPropertyName = "tipo_tarifa" : .HeaderText = "Tipo Tarifa"
                .DisplayIndex = x : .Visible = True
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_visibilidad As New DataGridViewTextBoxColumn
            With col_visibilidad
                .Name = "visibilidad" : .DataPropertyName = "visibilidad" : .HeaderText = "Visibilidad"
                .DisplayIndex = x : .Visible = True
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_servicio As New DataGridViewTextBoxColumn
            With col_servicio
                .Name = "servicio" : .DataPropertyName = "servicio" : .HeaderText = "Servicio"
                .DisplayIndex = x : .Visible = True
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            .Columns.AddRange(col_idtarifa_servicio, col_origen, col_destino, col_generico, col_peso, col_volumen, col_sobre, col_producto, _
                              col_tipo_tarifa, col_visibilidad, col_servicio)
        End With
    End Sub

    Private Sub ConfigurarDGVTarifa()
        With dgvTarifa
            'utilitario.FormatDataGridView(dgvTarifa)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            'Dim x As Integer = 0
            'Dim col_idunidad As New DataGridViewTextBoxColumn
            'With col_idunidad
            '    .Name = "idunidad" : .DataPropertyName = "idunidad"
            '    .DisplayIndex = x : .Visible = True
            'End With

            'x += +1
            Dim x As Integer = 0
            Dim col_concepto As New DataGridViewComboBoxColumn
            With col_concepto
                .Name = "idunidad" : .DataPropertyName = "idunidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Unidad" ': .ReadOnly = True
                .DisplayStyleForCurrentCellOnly = True : .ValueType = GetType(System.Int32)

                Dim obj As New Cls_TarifaServicio_LN
                .DataSource = obj.ListarUnidad()
                .DisplayMember = "unidad"
                .ValueMember = "idunidad"
            End With

            x += +1
            Dim col_inicio As New DataGridViewTextBoxColumn
            With col_inicio
                .Name = "inicio" : .DataPropertyName = "inicio" : .HeaderText = "Inicio"
                .DisplayIndex = x : .Visible = True : .DefaultCellStyle.Format = "0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .MaxInputLength = 12
                .ValueType = GetType(System.Double) : .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            x += +1
            Dim col_fin As New DataGridViewTextBoxColumn
            With col_fin
                .Name = "fin" : .DataPropertyName = "fin" : .HeaderText = "Fin"
                .DisplayIndex = x : .Visible = True : .DefaultCellStyle.Format = "0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .MaxInputLength = 12
                .ValueType = GetType(System.Double) : .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto" : .HeaderText = "Monto"
                .DisplayIndex = x : .Visible = True : .DefaultCellStyle.Format = "0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .MaxInputLength = 12
                .ValueType = GetType(System.Double) : .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            x += 1
            Dim col_modificacion As New DataGridViewTextBoxColumn
            With col_modificacion
                .Name = "modificado" : .HeaderText = "Modificado"
                .DisplayIndex = x : .Visible = False : .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            .Columns.AddRange(col_concepto, col_inicio, col_fin, col_monto, col_modificacion)
        End With
    End Sub
#End Region

#Region "Metodos"
    Sub Nuevo()
        'Me.ListarTarifa(Me.cboOrigen.SelectedValue, Me.cboDestino.SelectedValue, Me.cboProducto.SelectedValue, _
        'Me.cboTipoTarifa.SelectedValue, Me.cboTipoVisibilidad.SelectedValue, Me.cboServicio.SelectedValue)
        intOpcion = 1
        intTarifa = 0
        Me.Limpiar()

        'Me.ListarUnidad()
        Me.tabTarifario.SelectedIndex = 1
        ActivarDesactivar(True)
        Me.cboOrigen.Focus()
    End Sub

    Sub Limpiar()
        Me.cboOrigen.SelectedIndex = 0
        Me.cboDestino.SelectedIndex = 0
        Me.cboProducto.SelectedIndex = 0
        Me.cboTipoTarifa.SelectedIndex = 3
        Me.cboTipoVisibilidad.SelectedIndex = 3
        Me.cboServicio.SelectedIndex = 0

        Me.dgvTarifa.DataSource = Nothing
        Me.dgvTarifa.Rows.Clear()
        Me.AgregarUnidad()
    End Sub

    Sub ActivarDesactivar(estado As Boolean)
        Me.cboOrigen.Enabled = estado
        Me.cboDestino.Enabled = estado
        Me.cboProducto.Enabled = estado
        Me.cboTipoTarifa.Enabled = estado
        Me.cboTipoVisibilidad.Enabled = estado
        Me.cboServicio.Enabled = estado
        Me.dtpFechaActivacion.Enabled = estado

        'si la fecha actual es menor a la fecha de activación de la tarifa se puede modificar
        If intOpcion = 2 Then
            Dim datFechaServidor As Date = FechaServidor()
            If datFechaServidor.Date.ToShortDateString < Me.dtpFechaActivacion.Value Then
                Me.dtpFechaActivacion.Enabled = True
            End If
        End If
    End Sub

    Sub Editar()
        intOpcion = 2

        intTarifa = Me.dgvLista.CurrentRow.Cells("idtarifa_servicio").Value
        Me.ListarTarifa(intTarifa)

        ActivarDesactivar(False)

        RemoveHandler tabTarifario.SelectedIndexChanged, AddressOf tabTarifario_SelectedIndexChanged
        Me.tabTarifario.SelectedIndex = 1
        AddHandler tabTarifario.SelectedIndexChanged, AddressOf tabTarifario_SelectedIndexChanged

        Me.dgvTarifa.Focus()
    End Sub

    Function Validar() As Boolean
        Dim blnValidar As Boolean

        blnValidar = False
        If Me.cboOrigen.SelectedValue <> -1 Then
            If Me.cboOrigen.SelectedValue = Me.cboDestino.SelectedValue Then
                MessageBox.Show("La Ciudad Origen y Destino deben ser diferentes", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboOrigen.Focus()
                Me.cboOrigen.DroppedDown = True
                Return blnValidar
            End If
        End If

        If Me.cboProducto.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Producto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboProducto.Focus()
            Me.cboProducto.DroppedDown = True
            Return blnValidar
        End If

        If Me.cboTipoTarifa.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Tipo de Tarifa", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoTarifa.Focus()
            Me.cboTipoTarifa.DroppedDown = True
            Return blnValidar
        End If

        If Me.cboTipoVisibilidad.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Tipo de Visibilidad", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoVisibilidad.Focus()
            Me.cboTipoVisibilidad.DroppedDown = True
            Return blnValidar
        End If

        If Me.cboServicio.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Servicio", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboServicio.Focus()
            Me.cboServicio.DroppedDown = True
            Return blnValidar
        End If

        If intOpcion = 1 Then
            If TarifaExiste() Then
                Dim strMensaje As String
                strMensaje = "La Tarifa con:" & Chr(13)
                strMensaje &= "Origen : " & Me.cboOrigen.Text & Chr(13)
                strMensaje &= "Destino : " & Me.cboDestino.Text & Chr(13)
                strMensaje &= "Producto : " & Me.cboProducto.Text & Chr(13)
                strMensaje &= "Tipo Tarifa : " & Me.cboTipoTarifa.Text & Chr(13)
                strMensaje &= "Visibilidad : " & Me.cboTipoVisibilidad.Text & Chr(13)
                strMensaje &= "Servicio : " & Me.cboServicio.Text & Chr(13) & Chr(13)
                strMensaje &= "Se encuentra registrada" & Chr(13)
                MessageBox.Show(strMensaje, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboOrigen.Focus()
                cboOrigen.DroppedDown = True
                Return blnValidar
            End If
        End If

        'Valida detalle del tarifario de servicios
        Dim intUnidad As Integer, dblInicio As Double, dblFin As Double, dblMonto As Double
        Dim intEstado As Int16 = 0, intFila As Integer = 0, intColumna As Integer = 0, intAcumulado As Integer = 0
        With dgvTarifa
            For Each row As DataGridViewRow In .Rows
                intFila += 1
                intUnidad = IIf(IsDBNull(row.Cells("idunidad").Value), 0, row.Cells("idunidad").Value)

                dblInicio = IIf(IsDBNull(row.Cells("inicio").Value), 0, row.Cells("inicio").Value)
                dblFin = IIf(IsDBNull(row.Cells("fin").Value), 0, row.Cells("fin").Value)
                dblMonto = IIf(IsDBNull(row.Cells("monto").Value), 0, row.Cells("monto").Value)

                'intAcumulado += IIf(dblInicio = 0 And dblFin = 0 And dblMonto = 0, 0, 1)
                intAcumulado += IIf(dblInicio = 0 And dblMonto = 0, 0, 1)

                If Me.ValidaItemTarifa(intUnidad, dblInicio, dblFin, dblMonto) = False Then
                    If intUnidad = 0 Then
                        intEstado = 6
                    ElseIf dblInicio = 0 And dblFin = 0 And dblMonto = 0 Then
                        intEstado = 5
                    ElseIf dblInicio = 0 Then
                        intEstado = 1
                    ElseIf dblMonto = 0 Then
                        intEstado = 3
                    ElseIf dblFin = 0 Then
                        intEstado = -2
                    End If
                    'Exit For
                End If
                If (dblFin > 0) AndAlso (dblInicio > dblFin) Then
                    intEstado = 4
                    Exit For
                End If
            Next
            If intEstado > 0 Or intAcumulado = 0 Then
                intFila -= 1
                Dim strMensaje As String = ""
                If intEstado = 1 Then
                    strMensaje = "Ingrese Valor Inicio"
                    intColumna = 1
                ElseIf intEstado = 2 Then
                    strMensaje = "Ingrese Valor Fin"
                    intColumna = 2
                ElseIf intEstado = 3 Then
                    strMensaje = "Ingrese Valor Monto"
                    intColumna = 3
                ElseIf intEstado = 4 Then
                    strMensaje = "El Valor Inicio no debe ser mayor al Valor Fin"
                    intColumna = 1
                ElseIf intEstado = 5 Then
                    strMensaje = "Ingrese Valor Inicio"
                    intColumna = 1
                ElseIf intEstado = 6 Then
                    strMensaje = "Seleccione la Unidad"
                    intColumna = 0
                ElseIf intAcumulado = 0 Then
                    strMensaje = "Ingrese la Tarifa"
                    intFila = 0
                    intColumna = 1
                End If
                MessageBox.Show(strMensaje, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dgvTarifa.Focus()
                Me.dgvTarifa.CurrentCell = Me.dgvTarifa.Rows(intFila).Cells(intColumna)
                Return blnValidar
            Else
                If intEstado = -2 Then  'verificar infinitos
                    intFila = TarifaInfinita()
                    If intFila > 0 Then
                        MessageBox.Show("Debe establecer sólo un rango infinito por Unidad", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.dgvTarifa.Focus()
                        Me.dgvTarifa.CurrentCell = Me.dgvTarifa.Rows(intFila).Cells(2)
                        Return blnValidar
                    End If
                End If
            End If

            Dim intTarifaCruzada As Integer = TarifaCruzada()
            If intTarifaCruzada > 0 Then
                MessageBox.Show("Rangos de la Tarifa Incorrectos", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dgvTarifa.Focus()
                Me.dgvTarifa.CurrentCell = Me.dgvTarifa.Rows(intTarifaCruzada - 1).Cells(1)
                Return blnValidar
            End If

            If intOpcion = 2 Then
                Dim blnFechaActivacionMod As Boolean = False
                If strFechaActivacion <> Me.dtpFechaActivacion.Value.Date.ToShortDateString Then
                    blnFechaActivacionMod = True
                End If
                If TarifaModificada() = False And intFilasTarifa = dgvTarifa.Rows.Count - 1 And blnFechaActivacionMod = False Then
                    MessageBox.Show("Modifique la Tarifa", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dgvTarifa.Focus()
                    Me.dgvTarifa.CurrentCell = Me.dgvTarifa.Rows(0).Cells(1)
                    Return blnValidar
                End If
            End If
        End With

        blnValidar = True
        Return blnValidar
    End Function

    Function ValidaItemTarifa(u As Integer, a As Integer, b As Integer, c As Integer) As Boolean
        If u = 0 Then
            Return False
        ElseIf a > 0 And (c = 0) Then
            Return False
        ElseIf b > 0 And (a = 0 Or c = 0) Then
            Return False
        ElseIf c > 0 And (a = 0) Then
            Return False
        ElseIf a = 0 And c = 0 Then
            Return False
        End If
        'If u = 0 Then
        '    Return False
        'ElseIf a > 0 And (b = 0 Or c = 0) Then
        '    Return False
        'ElseIf b > 0 And (a = 0 Or c = 0) Then
        '    Return False
        'ElseIf c > 0 And (a = 0 Or b = 0) Then
        '    Return False
        'ElseIf a = 0 And b = 0 And c = 0 Then
        '    Return False
        'End If
        Return True
    End Function

    Private Sub Grabar()
        Try
            Dim obj As New Cls_TarifaServicio_LN
            Dim objTarifa As New Cls_TarifaServicio_EN

            With objTarifa
                .IDTarifa = intTarifa
                .Opcion = intOpcion
                .Origen = Me.cboOrigen.SelectedValue
                .Destino = Me.cboDestino.SelectedValue
                .Producto = Me.cboProducto.SelectedValue
                .TipoTarifa = Me.cboTipoTarifa.SelectedValue
                .TipoVisibilidad = Me.cboTipoVisibilidad.SelectedValue
                .Servicio = Me.cboServicio.SelectedValue
                .FechaActivacion = Me.dtpFechaActivacion.Value.ToShortDateString
                .Usuario = dtoUSUARIOS.IdLogin
                .IP = dtoUSUARIOS.IP
                For Each row As DataGridViewRow In dgvTarifa.Rows
                    'If row.Cells("monto").Value > 0 Then
                    .Unidad = row.Cells("idunidad").Value
                    .Inicio = row.Cells("inicio").Value
                    .Fin = row.Cells("fin").Value
                    .Monto = row.Cells("monto").Value
                    .IDTarifa = obj.GrabarTarifa(objTarifa)
                    If .Opcion = 2 Then
                        .Opcion = 3
                    End If
                    'End If
                Next
            End With
            MessageBox.Show("Tarifa Actualizada", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActualizarFiltros()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub ListarTarifa(tarifa As Integer)
        Try
            Me.ConfigurarDGVTarifa()
            Dim objTarifa As New Cls_TarifaServicio_LN
            Dim ds As DataSet = objTarifa.ListarTarifaServicio(tarifa)
            'Visualiza Cabecera
            Me.cboOrigen.SelectedValue = ds.Tables(0).Rows(0).Item("origen")
            Me.cboDestino.SelectedValue = ds.Tables(0).Rows(0).Item("destino")
            Me.cboProducto.SelectedValue = ds.Tables(0).Rows(0).Item("producto")
            Me.cboTipoTarifa.SelectedValue = ds.Tables(0).Rows(0).Item("tipo_tarifa")
            Me.cboTipoVisibilidad.SelectedValue = ds.Tables(0).Rows(0).Item("visibilidad")
            Me.cboServicio.SelectedValue = ds.Tables(0).Rows(0).Item("servicio")
            Me.dtpFechaActivacion.Value = ds.Tables(0).Rows(0).Item("fecha_activacion")
            strFechaActivacion = Me.dtpFechaActivacion.Text

            'Visualiza Detalle
            'Me.dgvTarifa.DataSource = ds.Tables(1).DefaultView
            With ds.Tables(1)
                If .Rows.Count > 0 Then
                    dgvTarifa.DataSource = Nothing
                    Dim i As Integer
                    For Each row As DataRow In ds.Tables(1).Rows
                        dgvTarifa.Rows.Add()
                        dgvTarifa.Rows(i).Cells(0).Value = row.Item(0)
                        dgvTarifa.Rows(i).Cells(1).Value = row.Item(1)
                        dgvTarifa.Rows(i).Cells(2).Value = row.Item(2)
                        dgvTarifa.Rows(i).Cells(3).Value = row.Item(3)
                        i += 1
                    Next
                End If
                intFilasTarifa = dgvTarifa.Rows.Count - 1
            End With

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub FrmTarifarioServicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        utilData.cargarCombos("t_unidadAgencia", cboBusq_Origen, True)
        utilData.cargarCombos(, cboBusq_Destino, True, cboBusq_Origen.DataSource)
        utilData.cargarCombos("t_procesos", CboBusq_Producto, True)
        utilData.cargarCombos("t_tipotarifa", cboBusq_TipoTarifa, True)
        utilData.cargarCombos("t_tipo_control", CboBusq_Servicio, True, , "1")

        utilData.cargarTipoVisibilidad(CboBusq_TipoVisibildad, True)
        utilData.cargarCombos(, cboOrigen, True, cboBusq_Origen.DataSource)
        utilData.cargarCombos(, cboDestino, True, cboBusq_Origen.DataSource)
        utilData.cargarCombos(, cboProducto, False, CboBusq_Producto.DataSource)
        utilData.cargarCombos(, cboTipoTarifa, False, cboBusq_TipoTarifa.DataSource, , "AMBOS", 3)
        utilData.cargarCombos(, cboServicio, False, CboBusq_Servicio.DataSource)
        utilData.cargarTipoVisibilidad(cboTipoVisibilidad, False)

        Me.ConfigurarDGVLista()
        Me.ConfigurarDGVTarifa()
    End Sub


    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Validar() Then
                Grabar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles TsbNuevo.Click
        Try
            Me.Nuevo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarTarifa(origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer, servicio As Integer)
        Me.ConfigurarDGVLista()
        Dim obj As New Cls_TarifaServicio_LN
        Dim dt As DataTable = obj.ListarTarifaServicio(origen, destino, producto, tipo_tarifa, tipo_visibilidad, servicio)
        dgvLista.DataSource = dt
        'If dt.Rows.Count > 0 Then
        '    If dt.Compute("sum(generico1)", "") = 0 Then
        '        dgvLista.Columns("generico").Visible = False
        '    Else
        '        dgvLista.Columns("generico").Visible = True
        '    End Ifs
        '    If dt.Compute("sum(peso1)", "") = 0 Then
        '        dgvLista.Columns("peso").Visible = False
        '    Else
        '        dgvLista.Columns("peso").Visible = True
        '    End If
        '    If dt.Compute("sum(volumen1)", "") = 0 Then
        '        dgvLista.Columns("volumen").Visible = False
        '    Else
        '        dgvLista.Columns("volumen").Visible = True
        '    End If
        '    If dt.Compute("sum(sobre1)", "") = 0 Then
        '        dgvLista.Columns("sobre").Visible = False
        '    Else
        '        dgvLista.Columns("sobre").Visible = True
        '    End If
        'Else
        '    dgvLista.Columns.Remove("generico")
        '    dgvLista.Columns.Remove("peso")
        '    dgvLista.Columns.Remove("volumen")
        '    dgvLista.Columns.Remove("sobre")
        'End If
    End Sub

    Sub ListarUnidad()
        Me.ConfigurarDGVTarifa()
        Dim obj As New Cls_TarifaServicio_LN
        'dgvTarifa.DataSource = obj.ListarUnidad()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.tabTarifario.SelectedIndex = 0
        Me.btnConsultar.Focus()
    End Sub

    Private Sub dgvTarifa_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvTarifa.CellBeginEdit
        If e.ColumnIndex > 0 Then
            Dim dblTarifaOld As Double
            If IsNothing(dgvTarifa.CurrentRow.Tag) Then
                dblTarifaOld = dgvTarifa.CurrentRow.Cells("inicio").Value + dgvTarifa.CurrentRow.Cells("fin").Value + dgvTarifa.CurrentRow.Cells("monto").Value
                dgvTarifa.CurrentRow.Tag = dblTarifaOld
            End If
        End If
        blnEditaTarifa = True
    End Sub

    Private Sub dgvTarifa_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTarifa.CellEndEdit
        If e.ColumnIndex > 0 Then
            If IsDBNull(dgvTarifa(e.ColumnIndex, e.RowIndex).Value) Then
                dgvTarifa.CurrentRow.Cells(e.ColumnIndex).Value = "0.00"
            Else
                If dgvTarifa(e.ColumnIndex, e.RowIndex).Value.ToString.Trim.Length >= 12 Then
                    Dim strValor As String = dgvTarifa(e.ColumnIndex, e.RowIndex).Value
                    strValor = strValor.Trim.Substring(0, 10) & ".00"
                    dgvTarifa(e.ColumnIndex, e.RowIndex).Value = strValor
                End If
            End If
        End If

        If e.ColumnIndex > 0 And dgvTarifa.CurrentRow.Cells("modificado").Value <> 2 Then
            Dim dblTarifaNew As Double
            dblTarifaNew = dgvTarifa.CurrentRow.Cells("inicio").Value + dgvTarifa.CurrentRow.Cells("fin").Value + dgvTarifa.CurrentRow.Cells("monto").Value
            If dblTarifaNew <> dgvTarifa.CurrentRow.Tag Then
                dgvTarifa.CurrentRow.Cells("modificado").Value = 1
            Else
                dgvTarifa.CurrentRow.Cells("modificado").Value = Nothing
            End If
        End If
        blnEditaTarifa = False
    End Sub

    Private Sub dgvTarifa_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvTarifa.EditingControlShowing
        If TypeOf e.Control Is TextBox Then
            Dim validar As TextBox = CType(e.Control, TextBox)
            AddHandler validar.KeyPress, AddressOf Validar_KeyPress
        End If
    End Sub

    Sub Validar_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim intColumna As Integer = Me.dgvTarifa.CurrentCell.ColumnIndex
        Dim chrCaracter As Char = e.KeyChar

        If intColumna >= 1 Then
            Dim txt As TextBox = CType(sender, TextBox)

            If Not ValidarNumeroReal(chrCaracter, txt.Text) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvTarifa_LostFocus(sender As Object, e As System.EventArgs) Handles dgvTarifa.LostFocus
        dgvTarifa.ClearSelection()
    End Sub

    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        Try
            Me.ListarTarifa(Me.cboBusq_Origen.SelectedValue, Me.cboBusq_Destino.SelectedValue, Me.CboBusq_Producto.SelectedValue, _
            Me.cboBusq_TipoTarifa.SelectedValue, Me.CboBusq_TipoVisibildad.SelectedValue, Me.CboBusq_Servicio.SelectedValue)
            If Me.dgvLista.Rows.Count = 0 Then
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            Else
                Me.tsbEditar.Enabled = True
                Me.tsbAnular.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub tsbEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsbEditar.Click
        Try
            Me.Editar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvLista_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvLista.DoubleClick
        If dgvLista.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Sub ActualizarFiltros()
        Me.cboBusq_Origen.SelectedValue = Me.cboOrigen.SelectedValue
        Me.cboBusq_Destino.SelectedValue = Me.cboDestino.SelectedValue
        Me.CboBusq_Producto.SelectedValue = Me.cboProducto.SelectedValue
        Me.cboBusq_TipoTarifa.SelectedIndex = 0
        Me.CboBusq_TipoVisibildad.SelectedIndex = 0
        Me.CboBusq_Servicio.SelectedValue = Me.cboServicio.SelectedValue
        btnConsultar_Click(Nothing, Nothing)
        Me.tabTarifario.SelectedIndex = 0
    End Sub

    Function TarifaModificada() As Boolean
        With dgvTarifa
            For Each row As DataGridViewRow In .Rows
                If Not IsNothing(row.Cells("modificado").Value) Then
                    Return True
                End If
            Next
            Return False
        End With
    End Function

    Private Sub tsbAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsbAnular.Click
        Try
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Tarifa Seleccionada?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Anular(Me.dgvLista.CurrentRow.Cells("idtarifa_servicio").Value)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Anular(tarifa As Integer)
        Try
            Dim obj As New Cls_TarifaServicio_LN
            Dim objTarifa As New Cls_TarifaServicio_EN

            With objTarifa
                .IDTarifa = tarifa
                .Usuario = dtoUSUARIOS.IdLogin
                .IP = dtoUSUARIOS.IP
                obj.Anular(objTarifa)
            End With
            MessageBox.Show("La Tarifa ha sido Anulada", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnConsultar_Click(Nothing, Nothing)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub tabTarifario_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabTarifario.SelectedIndexChanged
        If tabTarifario.SelectedIndex = 1 Then
            Me.TsbNuevo_Click(Nothing, Nothing)
        End If
    End Sub

    Function TarifaExiste() As Boolean
        Try
            Dim obj As New Cls_TarifaServicio_LN
            Dim objTarifa As New Cls_TarifaServicio_EN

            With objTarifa
                .Origen = cboOrigen.SelectedValue
                .Destino = cboDestino.SelectedValue
                .Producto = cboProducto.SelectedValue
                .TipoTarifa = cboTipoTarifa.SelectedValue
                .TipoVisibilidad = cboTipoVisibilidad.SelectedValue
                .Servicio = cboServicio.SelectedValue
                Return obj.ExisteTarifaServicio(objTarifa)
            End With

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Private Sub dgvTarifa_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvTarifa.CurrentCellDirtyStateChanged
        dgvTarifa.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Function TarifaCompleta(fila As Integer) As Boolean
        With dgvTarifa
            If IsDBNull(dgvTarifa.CurrentCell.Value) Then
                dgvTarifa.CurrentCell.Value = "0.00"
            End If
            If .Rows(fila).Cells(0).Value > 0 And .Rows(fila).Cells(1).Value > 0 And .Rows(fila).Cells(3).Value > 0 Then
                Return True
            Else
                Return False
            End If
        End With
    End Function

    Sub AgregarUnidad()
        With dgvTarifa
            Dim intUltimaFila As Integer
            If .Rows.Count = 0 Then
                .Rows.Add()
            Else
                intUltimaFila = .Rows.Count - 1
                'If .Rows(intUltimaFila).Cells(0).Value > 0 And .Rows(intUltimaFila).Cells(2).Value > 0 And .Rows(intUltimaFila).Cells(3).Value > 0 Then
                If TarifaCompleta(intUltimaFila) Then
                    .Rows.Add()
                    intUltimaFila = .Rows.Count - 1
                    .CurrentCell = .Rows(intUltimaFila).Cells(0)
                Else
                    Return
                End If
            End If
            .Rows(intUltimaFila).Cells("idunidad").Value = Nothing
            .Rows(intUltimaFila).Cells("inicio").Value = 0
            .Rows(intUltimaFila).Cells("fin").Value = 0
            .Rows(intUltimaFila).Cells("monto").Value = 0
            .Rows(intUltimaFila).Cells("modificado").Value = 2
        End With
    End Sub

    Sub EliminarUnidad()
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Eliminar la Tarifa Seleccionada?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            With dgvTarifa
                If .Rows.Count > 0 Then
                    .Rows.RemoveAt(.CurrentCell.RowIndex)
                    If .Rows.Count = 0 Then
                        AgregarUnidad()
                    End If
                End If
            End With
        End If
    End Sub

    Sub QuitarUnidad()
        'dgvTarifa.Rows.RemoveAt(dgvTarifa.CurrentCell.RowIndex)
        'dgvTarifa.Rows.RemoveAt(1)
        dgvTarifa.Rows.RemoveAt(dgvTarifa.Rows.Count - 1)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim flat As Boolean = True

        If msg.WParam.ToInt32 = Keys.Enter And (Me.dgvTarifa.Focused Or blnEditaTarifa) Then
            If dgvTarifa.CurrentCell.RowIndex = dgvTarifa.Rows.Count - 1 And dgvTarifa.CurrentCell.ColumnIndex = 3 Then
                If blnEditaTarifa = False Then
                    'AgregarUnidad()
                    SendKeys.Send(vbTab)
                Else
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                End If
            Else
                SendKeys.Send(vbTab)
            End If
        ElseIf (msg.WParam.ToInt32 = Keys.Insert Or (msg.WParam.ToInt32 = Keys.Down And dgvTarifa.CurrentCell.RowIndex = dgvTarifa.Rows.Count - 1)) Then
            AgregarUnidad()
        ElseIf msg.WParam.ToInt32 = Keys.Up And dgvTarifa.CurrentCell.RowIndex = dgvTarifa.Rows.Count - 1 And Me.TarifaCompleta(dgvTarifa.CurrentCell.RowIndex) = False And Me.dgvTarifa.Focused Then
            QuitarUnidad()
        ElseIf msg.WParam.ToInt32 = Keys.Delete And Me.dgvTarifa.Focused Then
            EliminarUnidad()
        Else
            flat = MyBase.ProcessCmdKey(msg, KeyData)
        End If
        Return flat
    End Function

    Function TarifaCruzada() As Integer
        With dgvTarifa
            If .Rows.Count > 1 Then
                Dim id As Integer, x As Integer = 0, dblFin As Double = 0
                For Each row As DataGridViewRow In .Rows
                    id = row.Cells("idunidad").Value
                    x += 1
                    For i As Integer = x To .Rows.Count - 1
                        If row.Cells("idunidad").Value = .Rows(i).Cells("idunidad").Value Then
                            dblFin = If(row.Cells("fin").Value = 0, 99999999999, row.Cells("fin").Value)
                            If .Rows(i).Cells("inicio").Value >= row.Cells("inicio").Value And .Rows(i).Cells("inicio").Value <= dblFin Then
                                Return i + 1
                            End If
                        End If
                    Next
                Next
            End If
            Return 0
        End With
    End Function

    Function TarifaInfinita() As Integer
        With dgvTarifa
            If .Rows.Count > 1 Then
                Dim id As Integer, x As Integer = 0
                For Each row As DataGridViewRow In .Rows
                    id = row.Cells("idunidad").Value
                    x += 1
                    If row.Cells("fin").Value = 0 Then
                        For i As Integer = x To .Rows.Count - 1
                            If row.Cells("idunidad").Value = .Rows(i).Cells("idunidad").Value Then
                                If .Rows(i).Cells("fin").Value = 0 Then
                                    Return x
                                End If
                            End If
                        Next
                    End If
                Next
            End If
            Return 0
        End With
    End Function

    Private Sub dgvTarifa_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvTarifa.MouseClick
        If dgvTarifa.CurrentCell.RowIndex < dgvTarifa.Rows.Count - 1 And Me.TarifaCompleta(dgvTarifa.Rows.Count - 1) = False And Me.dgvTarifa.Focused And dgvTarifa.Rows.Count > 1 Then
            QuitarUnidad()
        End If
    End Sub

    Private Sub dgvTarifa_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTarifa.CellContentClick

    End Sub

    Private Sub dgvLista_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellContentClick

    End Sub
End Class