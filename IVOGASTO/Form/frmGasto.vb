Imports System.Linq
Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class frmGasto
    Dim intOperacion As Operacion
    Dim intTipoGasto As TipoGasto
    Dim intNivel As Integer
    Dim intTipoPago As Integer

    Dim dtResumen As DataTable
    'arreglos para configurar resumen de gastos
    Dim aCampo(3) As Boolean
    Dim aGrupo(4) As Boolean

    Dim dtResumenProvision As DataTable
    'arreglo para configurar provision de gastos
    Dim aGrupoProvision(4) As Boolean

    'Fuera Zona
    Dim colCliente As New Collection
    Dim autoCliente As New AutoCompleteStringCollection

    Dim tabSolicitud As TabPage, tabAceptacion As TabPage, tabAprobacion As TabPage
    Dim tabSolicitarRecojo As TabPage, tabAprobarRecojo As TabPage
    Dim tabSolicitarEstiba As TabPage, tabAprobarEstiba As TabPage
    Dim tabSolicitarTraslado As TabPage, tabAprobarTraslado As TabPage

    Dim tabSolicitarEmbalaje As TabPage, tabAceptarEmbalaje As TabPage, tabAprobarEmbalaje As TabPage

    'Reparto
    Dim intLlamada As Integer = 0
    Dim intIngresa As Integer = 1
    Dim intModo As Integer = 1

#Region "Propiedades"
    Private intVenta As Integer
    Public Property Venta() As Integer
        Get
            Return intVenta
        End Get
        Set(ByVal value As Integer)
            intVenta = value
        End Set
    End Property

#End Region

#Region "Configurar Grid"
    Private Sub ConfigurarDGVRecojoAprobacion(ByVal opcion As Integer, ByVal dgv As DataGridView)
        With dgv
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvRecojo)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            If opcion = 1 Then
                Dim x As Integer = 0
                Dim col_id_grt As New DataGridViewTextBoxColumn
                With col_id_grt
                    .Name = "id_grt" : .DataPropertyName = "id_grt" : .DisplayIndex = x : .HeaderText = "id_grt" : .Visible = False
                End With
                x += +1
                Dim col_bus As New DataGridViewTextBoxColumn
                With col_bus
                    .Name = "bus" : .DataPropertyName = "bus"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Bus"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_grt As New DataGridViewTextBoxColumn
                With col_grt
                    .Name = "grt" : .DataPropertyName = "grt"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº GRT"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_origen As New DataGridViewTextBoxColumn
                With col_origen
                    .Name = "origen" : .DataPropertyName = "origen"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_destino As New DataGridViewTextBoxColumn
                With col_destino
                    .Name = "destino" : .DataPropertyName = "destino"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_peso As New DataGridViewTextBoxColumn
                With col_peso
                    .Name = "peso" : .DataPropertyName = "peso"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_cantidad As New DataGridViewTextBoxColumn
                With col_cantidad
                    .Name = "cantidad" : .DataPropertyName = "cantidad"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
                End With
                x += +1
                Dim col_total As New DataGridViewTextBoxColumn
                With col_total
                    .Name = "total" : .DataPropertyName = "total"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "Total"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '.DefaultCellStyle.Format = "###,###,###.00"
                End With
                .Columns.AddRange(col_id_grt, col_bus, col_grt, col_origen, col_destino, col_peso, col_cantidad, col_estado, col_total)
            Else
                Dim x As Integer = 0
                Dim col_id As New DataGridViewTextBoxColumn
                With col_id
                    .Name = "id" : .DataPropertyName = "id"
                    .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
                End With
                x += +1
                Dim col_id_2 As New DataGridViewTextBoxColumn
                With col_id_2
                    .Name = "id_2" : .DataPropertyName = "id_2"
                    .DisplayIndex = x : .HeaderText = "id_2" : .Visible = False
                End With
                x += +1
                Dim col_fecha As New DataGridViewTextBoxColumn
                With col_fecha
                    .Name = "fecha" : .DataPropertyName = "fecha"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "dd/MM/yyyy"
                End With
                x += +1
                Dim col_tipo As New DataGridViewTextBoxColumn
                With col_tipo
                    .Name = "tipo" : .DataPropertyName = "tipo"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_comprobante As New DataGridViewTextBoxColumn
                With col_comprobante
                    .Name = "comprobante" : .DataPropertyName = "comprobante"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Doc."
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_origen As New DataGridViewTextBoxColumn
                With col_origen
                    .Name = "origen" : .DataPropertyName = "origen"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_destino As New DataGridViewTextBoxColumn
                With col_destino
                    .Name = "destino" : .DataPropertyName = "destino"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_cliente As New DataGridViewTextBoxColumn
                With col_cliente
                    .Name = "cliente" : .DataPropertyName = "cliente"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_peso As New DataGridViewTextBoxColumn
                With col_peso
                    .Name = "peso" : .DataPropertyName = "peso"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_cantidad As New DataGridViewTextBoxColumn
                With col_cantidad
                    .Name = "cantidad" : .DataPropertyName = "cantidad"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Bultos" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
                End With
                x += +1
                Dim col_id_comprobante As New DataGridViewTextBoxColumn
                With col_id_comprobante
                    .Name = "id_comprobante" : .DataPropertyName = "id_comprobante"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "id_comprobante"
                End With
                x += +1
                Dim col_id_tipo As New DataGridViewTextBoxColumn
                With col_id_tipo
                    .Name = "id_tipo" : .DataPropertyName = "id_tipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_tipo"
                End With
                x += +1
                Dim col_id_origen As New DataGridViewTextBoxColumn
                With col_id_origen
                    .Name = "id_origen" : .DataPropertyName = "id_origen" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_origen"
                End With
                x += +1
                Dim col_id_destino As New DataGridViewTextBoxColumn
                With col_id_destino
                    .Name = "id_destino" : .DataPropertyName = "id_destino" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_destino"
                End With
                x += +1
                Dim col_id_persona As New DataGridViewTextBoxColumn
                With col_id_persona
                    .Name = "id_persona" : .DataPropertyName = "id_persona" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_persona"
                End With
                x += +1
                Dim col_total As New DataGridViewTextBoxColumn
                With col_total
                    .Name = "total" : .DataPropertyName = "total"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '.DefaultCellStyle.Format = "###,###,###.00"
                End With
                .Columns.AddRange(col_id, col_id_2, col_fecha, col_tipo, col_comprobante, col_origen, col_destino, col_cliente, _
                                  col_peso, col_cantidad, col_estado, col_id_comprobante, col_id_tipo, col_id_origen, col_id_destino, col_id_persona, col_total)
            End If
        End With
    End Sub
    Sub FormateardgvLista()
        With dgvLista
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "id" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_operacion As New DataGridViewTextBoxColumn
            With col_id_operacion
                .Name = "id_operacion" : .DataPropertyName = "id_operacion" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_operacion As New DataGridViewTextBoxColumn
            With col_operacion
                .Name = "operacion" : .DataPropertyName = "operacion"
                .DisplayIndex = x : .HeaderText = "Operación" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .HeaderText = "agencia" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Solicitud"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad"
                .DisplayIndex = x : .HeaderText = "Ciudad" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_solicitud As New DataGridViewTextBoxColumn
            With col_fecha_solicitud
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Solicitud"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_operacion As New DataGridViewTextBoxColumn
            With col_fecha_operacion
                .Name = "fecha_operacion" : .DataPropertyName = "fecha_operacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Operacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = True : .HeaderText = "id estado" : .Visible = False
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_desaprobacion As New DataGridViewTextBoxColumn
            With col_fecha_desaprobacion
                .Name = "fecha_desaprobacion" : .DataPropertyName = "fecha_desaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Desaprobacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_anulacion As New DataGridViewTextBoxColumn
            With col_fecha_anulacion
                .Name = "fecha_anulacion" : .DataPropertyName = "fecha_anulacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Anulación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_agencia As New DataGridViewTextBoxColumn
            With col_id_agencia
                .Name = "id_agencia" : .DataPropertyName = "id_agencia"
                .DisplayIndex = x : .HeaderText = "id_agencia" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tiempo1 As New DataGridViewTextBoxColumn
            With col_tiempo1
                .Name = "tiempo1" : .DataPropertyName = "tiempo1"
                .DisplayIndex = x : .HeaderText = "tiempo1" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tiempo2 As New DataGridViewTextBoxColumn
            With col_tiempo2
                .Name = "tiempo2" : .DataPropertyName = "tiempo2"
                .DisplayIndex = x : .HeaderText = "tiempo2" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_solicitante As New DataGridViewTextBoxColumn
            With col_id_solicitante
                .Name = "id_solicitante" : .DataPropertyName = "id_solicitante"
                .DisplayIndex = x : .HeaderText = "id_solicitante" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .HeaderText = "solicitante" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tarifa_oficina As New DataGridViewTextBoxColumn
            With col_tarifa_oficina
                .Name = "tarifa_oficina" : .DataPropertyName = "tarifa_oficina"
                .DisplayIndex = x : .HeaderText = "tarifa_oficina" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_gasto As New DataGridViewTextBoxColumn
            With col_tipo_gasto
                .Name = "tipo_gasto" : .DataPropertyName = "tipo_gasto"
                .DisplayIndex = x : .HeaderText = "tipo_gasto" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .HeaderText = "tipo" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_gasto_adicional As New DataGridViewTextBoxColumn
            With col_tipo_gasto_adicional
                .Name = "tipo_gasto_adicional" : .DataPropertyName = "tipo_gasto_adicional"
                .DisplayIndex = x : .HeaderText = "tipo_gasto_adicional" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_adicional As New DataGridViewTextBoxColumn
            With col_tipo_adicional
                .Name = "tipo_adicional" : .DataPropertyName = "tipo_adicional"
                .DisplayIndex = x : .HeaderText = "tipo_adicional" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_gasto_adicional As New DataGridViewTextBoxColumn
            With col_gasto_adicional
                .Name = "gasto_adicional" : .DataPropertyName = "gasto_adicional"
                .DisplayIndex = x : .HeaderText = "gasto_adicional" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_responsable_adicional As New DataGridViewTextBoxColumn
            With col_responsable_adicional
                .Name = "responsable_adicional" : .DataPropertyName = "responsable_adicional"
                .DisplayIndex = x : .HeaderText = "responsable_adicional" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .HeaderText = "peso" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .HeaderText = "cantidad" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_ciudad As New DataGridViewTextBoxColumn
            With col_id_ciudad
                .Name = "id_ciudad" : .DataPropertyName = "id_ciudad"
                .DisplayIndex = x : .HeaderText = "id_ciudad" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion" : .DisplayIndex = x : .HeaderText = "direccion" : .Visible = False
            End With
            x += +1
            Dim col_id_reparto As New DataGridViewTextBoxColumn
            With col_id_reparto
                .Name = "id_reparto" : .DataPropertyName = "id_reparto" : .DisplayIndex = x : .HeaderText = "id_reparto" : .Visible = False
            End With
            x += +1
            Dim col_id_proveedor As New DataGridViewTextBoxColumn
            With col_id_proveedor
                .Name = "id_proveedor" : .DataPropertyName = "id_proveedor" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_ruc As New DataGridViewTextBoxColumn
            With col_ruc
                .Name = "ruc" : .DataPropertyName = "ruc" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_proveedor As New DataGridViewTextBoxColumn
            With col_proveedor
                .Name = "proveedor" : .DataPropertyName = "proveedor" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .HeaderText = "Observacion" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_formato As New DataGridViewTextBoxColumn
            With col_formato
                .Name = "formato" : .DataPropertyName = "formato" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_id_rep As New DataGridViewTextBoxColumn
            With col_id_rep
                .Name = "id_rep" : .DataPropertyName = "id_rep" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_id_rec As New DataGridViewTextBoxColumn
            With col_id_rec
                .Name = "id_rec" : .DataPropertyName = "id_rec" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_observacion2 As New DataGridViewTextBoxColumn
            With col_observacion2
                .Name = "observacion2" : .DataPropertyName = "observacion2"
                .DisplayIndex = x : .HeaderText = "Observación por Desaprobación" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With


            .Columns.AddRange(col_id, col_ciudad, col_agencia, col_numero, col_fecha_solicitud, col_fecha_operacion, col_monto, col_id_estado, col_estado, _
                              col_fecha_aprobacion, col_fecha_desaprobacion, col_fecha_anulacion, col_id_agencia, col_tiempo1, col_tiempo2, _
                              col_id_solicitante, col_solicitante, col_observacion, col_tarifa_oficina, _
                              col_tipo_gasto, col_tipo, col_tipo_gasto_adicional, col_tipo_adicional, col_gasto_adicional, col_responsable_adicional, _
                              col_peso, col_cantidad, col_id_ciudad, col_direccion, col_id_reparto, col_id_proveedor, col_ruc, col_proveedor, _
                              col_id_operacion, col_operacion, col_formato, col_id_rep, col_id_rec, col_observacion2)
        End With
    End Sub
    Sub FormateardgvGasto()
        With dgvGenerarGasto
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id_agencia As New DataGridViewTextBoxColumn
            With col_id_agencia
                .Name = "id_agencia" : .DataPropertyName = "id_agencia"
                .DisplayIndex = x : .HeaderText = "id_agencia" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .HeaderText = "Agencia" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .HeaderText = "Tipo" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .HeaderText = "Comprobante" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_tipo As New DataGridViewTextBoxColumn
            With col_id_tipo
                .Name = "id_tipo" : .DataPropertyName = "id_tipo" : .DisplayIndex = x : .HeaderText = "id_tipo" : .Visible = False
            End With
            x += +1
            Dim col_id_comprobante As New DataGridViewTextBoxColumn
            With col_id_comprobante
                .Name = "id_comprobante" : .DataPropertyName = "id_comprobante" : .DisplayIndex = x : .HeaderText = "id_comprobante" : .Visible = False
            End With
            x += +1
            Dim col_fecha1 As New DataGridViewTextBoxColumn
            With col_fecha1
                .Name = "fecha1" : .DataPropertyName = "fecha1"
                .DisplayIndex = x : .HeaderText = "Fecha Inicio" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha2 As New DataGridViewTextBoxColumn
            With col_fecha2
                .Name = "fecha2" : .DataPropertyName = "fecha2"
                .DisplayIndex = x : .HeaderText = "Fecha Fin" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .HeaderText = "Peso" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Bultos" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0"
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Monto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_monto_tarifa As New DataGridViewTextBoxColumn
            With col_monto_tarifa
                .Name = "monto_tarifa" : .DataPropertyName = "monto_tarifa"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tarifa"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_produccion As New DataGridViewTextBoxColumn
            With col_produccion
                .Name = "produccion" : .DataPropertyName = "produccion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Tiempo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_objetivo As New DataGridViewTextBoxColumn
            With col_objetivo
                .Name = "objetivo" : .DataPropertyName = "objetivo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Objetivo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_cumplio As New DataGridViewTextBoxColumn
            With col_cumplio
                .Name = "cumplio" : .DataPropertyName = "cumplio"
                .DisplayIndex = x : .Visible = False : .HeaderText = "cumplio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0"
            End With
            x += +1
            Dim col_cumplimiento As New DataGridViewTextBoxColumn
            With col_cumplimiento
                .Name = "cumplimiento" : .DataPropertyName = "cumplimiento"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Cumplimiento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_bono As New DataGridViewTextBoxColumn
            With col_bono
                .Name = "bono" : .DataPropertyName = "bono"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tarifa Bono"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_monto_bono As New DataGridViewTextBoxColumn
            With col_monto_bono
                .Name = "monto_bono" : .DataPropertyName = "monto_bono"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Monto Bono"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto" : .DisplayIndex = x : .HeaderText = "producto" : .Visible = False
            End With
            x += +1
            Dim col_centro_costo As New DataGridViewTextBoxColumn
            With col_centro_costo
                .Name = "centro_costo" : .DataPropertyName = "centro_costo" : .DisplayIndex = x : .HeaderText = "centro_costo" : .Visible = False
            End With
            .Columns.AddRange(col_id_agencia, col_agencia, col_id_tipo, col_tipo, col_id_comprobante, col_comprobante, col_fecha1, col_fecha2, _
                              col_peso, col_cantidad, col_monto, col_monto_tarifa, col_produccion, col_objetivo, col_cumplio, col_cumplimiento, _
                              col_bono, col_monto_bono, col_total, col_producto, col_centro_costo)
        End With
    End Sub
    Sub FormateardgvGastoConsultaCab()
        With dgvGenerarGastoConsultaCab
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "id" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad"
                .DisplayIndex = x : .HeaderText = "Ciudad" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha1 As New DataGridViewTextBoxColumn
            With col_fecha1
                .Name = "fecha1" : .DataPropertyName = "fecha1"
                .DisplayIndex = x : .HeaderText = "Fecha Inicio" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha2 As New DataGridViewTextBoxColumn
            With col_fecha2
                .Name = "fecha2" : .DataPropertyName = "fecha2"
                .DisplayIndex = x : .HeaderText = "Fecha Fin" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_gasto As New DataGridViewTextBoxColumn
            With col_tipo_gasto
                .Name = "tipo_gasto" : .DataPropertyName = "tipo_gasto" : .DisplayIndex = x : .HeaderText = "Tipo Gasto" : .Visible = False
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .HeaderText = "Peso" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Bultos" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0"
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_facturado As New DataGridViewTextBoxColumn
            With col_facturado
                .Name = "facturado" : .DataPropertyName = "facturado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Facturado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_idfacturado As New DataGridViewTextBoxColumn
            With col_idfacturado
                .Name = "idfacturado" : .DataPropertyName = "idfacturado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idfacturado"
            End With
            .Columns.AddRange(col_id, col_ciudad, col_fecha1, col_fecha2, col_tipo_gasto, col_peso, col_cantidad, col_monto, col_facturado, col_idfacturado)
        End With
    End Sub
    Sub FormateardgvGastoConsulta()
        With dgvGenerarGastoConsulta
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id_agencia As New DataGridViewTextBoxColumn
            With col_id_agencia
                .Name = "id_agencia" : .DataPropertyName = "id_agencia"
                .DisplayIndex = x : .HeaderText = "id_agencia" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .HeaderText = "Agencia" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .HeaderText = "Tipo" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .HeaderText = "Comprobante" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_tipo As New DataGridViewTextBoxColumn
            With col_id_tipo
                .Name = "id_tipo" : .DataPropertyName = "id_tipo" : .DisplayIndex = x : .HeaderText = "id_tipo" : .Visible = False
            End With
            x += +1
            Dim col_id_comprobante As New DataGridViewTextBoxColumn
            With col_id_comprobante
                .Name = "id_comprobante" : .DataPropertyName = "id_comprobante" : .DisplayIndex = x : .HeaderText = "id_comprobante" : .Visible = False
            End With
            x += +1
            Dim col_fecha1 As New DataGridViewTextBoxColumn
            With col_fecha1
                .Name = "fecha1" : .DataPropertyName = "fecha1"
                .DisplayIndex = x : .HeaderText = "Fecha Inicio" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha2 As New DataGridViewTextBoxColumn
            With col_fecha2
                .Name = "fecha2" : .DataPropertyName = "fecha2"
                .DisplayIndex = x : .HeaderText = "Fecha Fin" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .HeaderText = "Peso" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Bultos" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0"
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Monto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_monto_tarifa As New DataGridViewTextBoxColumn
            With col_monto_tarifa
                .Name = "monto_tarifa" : .DataPropertyName = "monto_tarifa"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tarifa"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_produccion As New DataGridViewTextBoxColumn
            With col_produccion
                .Name = "produccion" : .DataPropertyName = "produccion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Tiempo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_objetivo As New DataGridViewTextBoxColumn
            With col_objetivo
                .Name = "objetivo" : .DataPropertyName = "objetivo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Objetivo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_cumplio As New DataGridViewTextBoxColumn
            With col_cumplio
                .Name = "cumplio" : .DataPropertyName = "cumplio"
                .DisplayIndex = x : .Visible = False : .HeaderText = "cumplio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0"
            End With
            x += +1
            Dim col_cumplimiento As New DataGridViewTextBoxColumn
            With col_cumplimiento
                .Name = "cumplimiento" : .DataPropertyName = "cumplimiento"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Cumplimiento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_bono As New DataGridViewTextBoxColumn
            With col_bono
                .Name = "bono" : .DataPropertyName = "bono"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tarifa Bono"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_monto_bono As New DataGridViewTextBoxColumn
            With col_monto_bono
                .Name = "monto_bono" : .DataPropertyName = "monto_bono"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Monto Bono"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto" : .DisplayIndex = x : .HeaderText = "producto" : .Visible = False
            End With
            x += +1
            Dim col_centro_costo As New DataGridViewTextBoxColumn
            With col_centro_costo
                .Name = "centro_costo" : .DataPropertyName = "centro_costo" : .DisplayIndex = x : .HeaderText = "centro_costo" : .Visible = False
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .HeaderText = "id" : .Visible = False
            End With
            .Columns.AddRange(col_id_agencia, col_agencia, col_id_tipo, col_tipo, col_id_comprobante, col_comprobante, col_fecha1, col_fecha2, _
                              col_peso, col_cantidad, col_monto, col_monto_tarifa, col_produccion, col_objetivo, col_cumplio, col_cumplimiento, _
                              col_bono, col_monto_bono, col_total, col_producto, col_centro_costo, col_id)
        End With
    End Sub
    Sub FormateardgvReparto()
        With dgvReparto
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id_reparto As New DataGridViewTextBoxColumn
            With col_id_reparto
                .Name = "id_reparto" : .DataPropertyName = "id_reparto" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_reparto"
            End With
            x += +1
            Dim col_movil As New DataGridViewTextBoxColumn
            With col_movil
                .Name = "movil" : .DataPropertyName = "movil"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Móvil" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_responsable As New DataGridViewTextBoxColumn
            With col_responsable
                .Name = "responsable" : .DataPropertyName = "responsable"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Responsable" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_hora_salida As New DataGridViewTextBoxColumn
            With col_hora_salida
                .Name = "hora_salida" : .DataPropertyName = "hora_salida"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Salida" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_fecha_fin As New DataGridViewTextBoxColumn
            With col_fecha_fin
                .Name = "fecha_fin" : .DataPropertyName = "fecha_fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_produccion As New DataGridViewTextBoxColumn
            With col_produccion
                .Name = "produccion" : .DataPropertyName = "produccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tiempo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "direccion" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_responsable As New DataGridViewTextBoxColumn
            With col_id_responsable
                .Name = "id_responsable" : .DataPropertyName = "id_responsable" : .DisplayIndex = x : .Visible = False
            End With
            .Columns.AddRange(col_id_reparto, col_movil, col_responsable, col_hora_salida, col_fecha_inicio, col_fecha_fin, col_produccion, col_peso, col_cantidad, col_direccion, col_id_responsable)
        End With
    End Sub
    Sub FormateardgvRepartoGasto()
        With dgvRepartoGasto
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF
            Dim x As Integer = 0
            Dim col_id_reparto As New DataGridViewTextBoxColumn
            With col_id_reparto
                .Name = "id_reparto" : .DataPropertyName = "id_reparto" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_reparto"
            End With
            x += +1
            Dim col_movil As New DataGridViewTextBoxColumn
            With col_movil
                .Name = "movil" : .DataPropertyName = "movil"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Móvil" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_responsable As New DataGridViewTextBoxColumn
            With col_responsable
                .Name = "responsable" : .DataPropertyName = "responsable"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Responsable" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_hora_salida As New DataGridViewTextBoxColumn
            With col_hora_salida
                .Name = "hora_salida" : .DataPropertyName = "hora_salida"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Salida" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_responsable As New DataGridViewTextBoxColumn
            With col_id_responsable
                .Name = "id_responsable" : .DataPropertyName = "id_responsable" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_responsable"
            End With
            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_fecha_fin As New DataGridViewTextBoxColumn
            With col_fecha_fin
                .Name = "fecha_fin" : .DataPropertyName = "fecha_fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_produccion As New DataGridViewTextBoxColumn
            With col_produccion
                .Name = "produccion" : .DataPropertyName = "produccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tiempo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Bultos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.DefaultCellStyle.Format = "###,###,###.00"
            End With
            .Columns.AddRange(col_id_reparto, col_movil, col_responsable, col_hora_salida, col_id_responsable, col_fecha_inicio, col_fecha_fin, col_produccion, col_peso, col_cantidad, col_total)
        End With
    End Sub
    Sub FormateardgvResumen()
        With dgvResumen
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad"
                .DisplayIndex = x : .HeaderText = "Ciudad" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_concepto As New DataGridViewTextBoxColumn
            With col_concepto
                .Name = "concepto" : .DataPropertyName = "concepto"
                .DisplayIndex = x : .HeaderText = "Concepto" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_centro_costo As New DataGridViewTextBoxColumn
            With col_centro_costo
                .Name = "centro_costo" : .DataPropertyName = "centro_costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Centro Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Producto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "Peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_spkg As New DataGridViewTextBoxColumn
            With col_spkg
                .Name = "spkg" : .DataPropertyName = "spkg"
                .DisplayIndex = x : .Visible = True : .HeaderText = "SPKg" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            .Columns.AddRange(col_ciudad, col_concepto, col_centro_costo, col_producto, col_monto, col_peso, col_spkg)
        End With
    End Sub
    Sub FormateardgvRepartoTipoGasto(ByVal dgv As DataGridView)
        With dgv 'dgvRepartoTipoGasto
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_recojo" : .DataPropertyName = "fecha_recojo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_fecha_fin As New DataGridViewTextBoxColumn
            With col_fecha_fin
                .Name = "fecha_entrega" : .DataPropertyName = "fecha_entrega"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Bultos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.AddRange(col_tipo, col_comprobante, col_fecha_inicio, col_fecha_fin, col_peso, col_cantidad, col_agencia)
        End With
    End Sub
    Sub FormateardgvAprobacionTipoGasto()
        With dgvLista
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "id" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .HeaderText = "Número" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad"
                .DisplayIndex = x : .HeaderText = "Ciudad" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_solicitud As New DataGridViewTextBoxColumn
            With col_fecha_solicitud
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud"
                .DisplayIndex = x : .HeaderText = "Fecha Solicitud" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_operacion As New DataGridViewTextBoxColumn
            With col_fecha_operacion
                .Name = "fecha_operacion" : .DataPropertyName = "fecha_operacion"
                .DisplayIndex = x : .HeaderText = "Fecha Operación" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_responsable As New DataGridViewTextBoxColumn
            With col_responsable
                .Name = "responsable" : .DataPropertyName = "responsable"
                .DisplayIndex = x : .HeaderText = "Responsable" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_gasto As New DataGridViewTextBoxColumn
            With col_tipo_gasto
                .Name = "tipo_gasto" : .DataPropertyName = "tipo_gasto"
                .DisplayIndex = x : .HeaderText = "Tipo Gasto" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .HeaderText = "Solicitante" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .HeaderText = "observacion" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_ciudad As New DataGridViewTextBoxColumn
            With col_id_ciudad
                .Name = "id_ciudad" : .DataPropertyName = "id_ciudad"
                .DisplayIndex = x : .HeaderText = "id_ciudad" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_responsable As New DataGridViewTextBoxColumn
            With col_id_responsable
                .Name = "id_responsable" : .DataPropertyName = "id_responsable"
                .DisplayIndex = x : .HeaderText = "id_responsable" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.AddRange(col_id, col_numero, col_ciudad, col_fecha_solicitud, col_fecha_operacion, col_responsable, col_tipo_gasto, _
                              col_solicitante, col_observacion, col_id_ciudad, col_id_responsable)
        End With
    End Sub
    Private Sub ConfigurarDGVResultado()
        With dgvResultado
            Cls_Utilitarios.FormatDataGridView(dgvResultado)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .AutoGenerateColumns = False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = False
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = False
            .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_sel As New DataGridViewCheckBoxColumn
            With col_sel
                .HeaderText = "Seleccionar"
                .Name = "sel"
                '.DataPropertyName = "IDESTADO_REGISTRO"
                '.Width = 200
                '.ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                '.Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DisplayIndex = x
            End With
            x += 1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Id" : .Visible = False
            End With
            x += +1
            Dim col_concepto As New DataGridViewTextBoxColumn
            With col_concepto
                .Name = "concepto" : .DataPropertyName = "concepto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Concepto" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Número" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha" : .DefaultCellStyle.Format = "dd/MM/yyyy"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente" : .DisplayIndex = x : .Visible = True : .HeaderText = "Descripcion"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_subtotal As New DataGridViewTextBoxColumn
            With col_subtotal
                .Name = "subtotal" : .DataPropertyName = "subtotal"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subtotal" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_impuesto As New DataGridViewTextBoxColumn
            With col_impuesto
                .Name = "impuesto" : .DataPropertyName = "impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Impuesto" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_concepto As New DataGridViewTextBoxColumn
            With col_id_concepto
                .Name = "id_concepto" : .DataPropertyName = "id_concepto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_concepto"
            End With
            .Columns.AddRange(col_sel, col_id, col_concepto, col_numero, col_fecha, col_cliente, col_subtotal, col_impuesto, col_total, _
                              col_estado, col_id_concepto)
        End With
    End Sub
    Private Sub ConfigurarDGVFactura()
        With dgvFactura
            Cls_Utilitarios.FormatDataGridView(dgvFactura)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .AutoGenerateColumns = False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = False
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Id" : .Visible = False
            End With
            x += +1
            Dim col_concepto As New DataGridViewTextBoxColumn
            With col_concepto
                .Name = "concepto" : .DataPropertyName = "concepto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Concepto" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Número"
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Descripción" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_subtotal As New DataGridViewTextBoxColumn
            With col_subtotal
                .Name = "subtotal" : .DataPropertyName = "subtotal"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subtotal" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_impuesto As New DataGridViewTextBoxColumn
            With col_impuesto
                .Name = "impuesto" : .DataPropertyName = "impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Impuesto" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_id_concepto As New DataGridViewTextBoxColumn
            With col_id_concepto
                .Name = "id_concepto" : .DataPropertyName = "id_concepto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "id_concepto"
            End With
            .Columns.AddRange(col_id, col_concepto, col_numero, col_cliente, col_subtotal, col_impuesto, col_total, col_id_concepto)
        End With
    End Sub
    Private Sub ConfigurarDGVImprimir()
        With dgvImprimir
            Cls_Utilitarios.FormatDataGridView(dgvImprimir)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .AutoGenerateColumns = False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = False
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Id" : .Visible = False
            End With
            x += +1
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ciudad" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_oficina As New DataGridViewTextBoxColumn
            With col_oficina
                .Name = "oficina" : .DataPropertyName = "oficina"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Oficina" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
            End With
            x += +1
            Dim col_factura As New DataGridViewTextBoxColumn
            With col_factura
                .Name = "factura" : .DataPropertyName = "factura"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Factura"
            End With
            x += +1
            Dim col_ruc As New DataGridViewTextBoxColumn
            With col_ruc
                .Name = "ruc" : .DataPropertyName = "ruc"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ruc"
            End With
            x += +1
            Dim col_razon_social As New DataGridViewTextBoxColumn
            With col_razon_social
                .Name = "razon_social" : .DataPropertyName = "razon_social"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Razon Social"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_subtotal As New DataGridViewTextBoxColumn
            With col_subtotal
                .Name = "subtotal" : .DataPropertyName = "subtotal"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subtotal" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_impuesto As New DataGridViewTextBoxColumn
            With col_impuesto
                .Name = "impuesto" : .DataPropertyName = "impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Impuesto" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_liquidacion As New DataGridViewTextBoxColumn
            With col_liquidacion
                .Name = "liquidacion" : .DataPropertyName = "liquidacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Nº Liq."
            End With
            x += +1
            Dim col_TipoAfectacion As New DataGridViewTextBoxColumn
            With col_TipoAfectacion
                .Name = "TipoAfectacion" : .DataPropertyName = "TipoAfectacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Afectación"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.AddRange(col_id, col_ciudad, col_oficina, col_fecha, col_factura, col_ruc, col_razon_social, col_subtotal, col_impuesto, col_total, col_liquidacion, col_TipoAfectacion)
        End With
    End Sub
    Private Sub ConfigurarDGVDetalle()
        With dgvDetalle
            Cls_Utilitarios.FormatDataGridView(dgvDetalle)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .AutoGenerateColumns = False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = False
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .HeaderText = "fecha" : .Visible = False
            End With
            x += +1
            Dim col_factura As New DataGridViewTextBoxColumn
            With col_factura
                .Name = "factura" : .DataPropertyName = "factura"
                .DisplayIndex = x : .Visible = False : .HeaderText = "factura"
            End With
            x += +1
            Dim col_ruc As New DataGridViewTextBoxColumn
            With col_ruc
                .Name = "ruc" : .DataPropertyName = "ruc"
                .DisplayIndex = x : .Visible = False : .HeaderText = "ruc"
            End With
            x += +1
            Dim col_razon_social As New DataGridViewTextBoxColumn
            With col_razon_social
                .Name = "razon_social" : .DataPropertyName = "razon_social"
                .DisplayIndex = x : .Visible = False : .HeaderText = "razon_social"
            End With
            x += +1
            Dim col_concepto As New DataGridViewTextBoxColumn
            With col_concepto
                .Name = "concepto" : .DataPropertyName = "concepto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Concepto"
            End With
            x += +1
            Dim col_numero_solicitud As New DataGridViewTextBoxColumn
            With col_numero_solicitud
                .Name = "numero_solicitud" : .DataPropertyName = "numero_solicitud"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Solicitud"
            End With
            x += +1
            Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Operación"
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Descripción" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_costo As New DataGridViewTextBoxColumn
            With col_costo
                .Name = "costo" : .DataPropertyName = "costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Costo" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            .Columns.AddRange(col_fecha, col_factura, col_ruc, col_razon_social, col_concepto, col_numero_solicitud, col_fecha_aprobacion, col_cliente, col_costo)
        End With
    End Sub

    Private Sub ConfigurarDGVRecojo(ByVal opcion As Integer)
        With dgvRecojo
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvRecojo)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            If opcion = 1 Then
                Dim x As Integer = 0
                Dim col_id_grt As New DataGridViewTextBoxColumn
                With col_id_grt
                    .Name = "id_grt" : .DataPropertyName = "id_grt" : .DisplayIndex = x : .HeaderText = "id_grt" : .Visible = False
                End With
                x += +1
                Dim col_bus As New DataGridViewTextBoxColumn
                With col_bus
                    .Name = "bus" : .DataPropertyName = "bus"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Bus"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_grt As New DataGridViewTextBoxColumn
                With col_grt
                    .Name = "grt" : .DataPropertyName = "grt"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº GRT"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_origen As New DataGridViewTextBoxColumn
                With col_origen
                    .Name = "origen" : .DataPropertyName = "origen"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_destino As New DataGridViewTextBoxColumn
                With col_destino
                    .Name = "destino" : .DataPropertyName = "destino"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_peso As New DataGridViewTextBoxColumn
                With col_peso
                    .Name = "peso" : .DataPropertyName = "peso"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_cantidad As New DataGridViewTextBoxColumn
                With col_cantidad
                    .Name = "cantidad" : .DataPropertyName = "cantidad"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
                End With
                .Columns.AddRange(col_id_grt, col_bus, col_grt, col_origen, col_destino, col_peso, col_cantidad, col_estado)
            Else
                Dim x As Integer = 0
                Dim col_id As New DataGridViewTextBoxColumn
                With col_id
                    .Name = "id" : .DataPropertyName = "id"
                    .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
                End With
                x += +1
                Dim col_id_2 As New DataGridViewTextBoxColumn
                With col_id_2
                    .Name = "id_2" : .DataPropertyName = "id_2"
                    .DisplayIndex = x : .HeaderText = "id_2" : .Visible = False
                End With
                x += +1
                Dim col_fecha As New DataGridViewTextBoxColumn
                With col_fecha
                    .Name = "fecha" : .DataPropertyName = "fecha"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "dd/MM/yyyy"
                End With
                x += +1
                Dim col_tipo As New DataGridViewTextBoxColumn
                With col_tipo
                    .Name = "tipo" : .DataPropertyName = "tipo"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_comprobante As New DataGridViewTextBoxColumn
                With col_comprobante
                    .Name = "comprobante" : .DataPropertyName = "comprobante"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Doc."
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_origen As New DataGridViewTextBoxColumn
                With col_origen
                    .Name = "origen" : .DataPropertyName = "origen"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_destino As New DataGridViewTextBoxColumn
                With col_destino
                    .Name = "destino" : .DataPropertyName = "destino"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_cliente As New DataGridViewTextBoxColumn
                With col_cliente
                    .Name = "cliente" : .DataPropertyName = "cliente"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_peso As New DataGridViewTextBoxColumn
                With col_peso
                    .Name = "peso" : .DataPropertyName = "peso"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_cantidad As New DataGridViewTextBoxColumn
                With col_cantidad
                    .Name = "cantidad" : .DataPropertyName = "cantidad"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
                End With
                x += +1
                Dim col_id_comprobante As New DataGridViewTextBoxColumn
                With col_id_comprobante
                    .Name = "id_comprobante" : .DataPropertyName = "id_comprobante"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "id_comprobante"
                End With
                x += +1
                Dim col_id_tipo As New DataGridViewTextBoxColumn
                With col_id_tipo
                    .Name = "id_tipo" : .DataPropertyName = "id_tipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_tipo"
                End With
                x += +1
                Dim col_id_origen As New DataGridViewTextBoxColumn
                With col_id_origen
                    .Name = "id_origen" : .DataPropertyName = "id_origen" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_origen"
                End With
                x += +1
                Dim col_id_destino As New DataGridViewTextBoxColumn
                With col_id_destino
                    .Name = "id_destino" : .DataPropertyName = "id_destino" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_destino"
                End With
                x += +1
                Dim col_id_persona As New DataGridViewTextBoxColumn
                With col_id_persona
                    .Name = "id_persona" : .DataPropertyName = "id_persona" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_persona"
                End With
                x += +1
                Dim col_producto As New DataGridViewTextBoxColumn
                With col_producto
                    .Name = "producto" : .DataPropertyName = "producto" : .DisplayIndex = x : .Visible = False : .HeaderText = "producto"
                End With
                .Columns.AddRange(col_id, col_id_2, col_fecha, col_tipo, col_comprobante, col_origen, col_destino, col_cliente, _
                                  col_peso, col_cantidad, col_estado, col_id_comprobante, col_id_tipo, col_id_origen, col_id_destino, col_id_persona, col_producto)
            End If
        End With
    End Sub
    Sub FormateardgvListaEstiba()
        With dgvListaEstiba
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With
            x += +1
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad" : .DisplayIndex = x : .Visible = True : .HeaderText = "Ciudad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_operacion As New DataGridViewTextBoxColumn
            With col_fecha_operacion
                .Name = "fecha_operacion" : .DataPropertyName = "fecha_operacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_operacion As New DataGridViewTextBoxColumn
            With col_operacion
                .Name = "operacion" : .DataPropertyName = "operacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Operación" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_hora_inicio As New DataGridViewTextBoxColumn
            With col_hora_inicio
                .Name = "hora_inicio" : .DataPropertyName = "hora_inicio" : .DisplayIndex = x : .Visible = False : .HeaderText = "hora_inicio"
            End With
            x += +1
            Dim col_hora_fin As New DataGridViewTextBoxColumn
            With col_hora_fin
                .Name = "hora_fin" : .DataPropertyName = "hora_fin" : .DisplayIndex = x : .Visible = False : .HeaderText = "hora_fin"
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_solicitud As New DataGridViewTextBoxColumn
            With col_fecha_solicitud
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud" : .DisplayIndex = x : .Visible = True
                .HeaderText = "Fecha Solicitud"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_desaprobacion As New DataGridViewTextBoxColumn
            With col_fecha_desaprobacion
                .Name = "fecha_desaprobacion" : .DataPropertyName = "fecha_desaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Desaprobación" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_anulacion As New DataGridViewTextBoxColumn
            With col_fecha_anulacion
                .Name = "fecha_anulacion" : .DataPropertyName = "fecha_anulacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Anulación" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_operacion As New DataGridViewTextBoxColumn
            With col_id_operacion
                .Name = "id_operacion" : .DataPropertyName = "id_operacion" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_id_proveedor As New DataGridViewTextBoxColumn
            With col_id_proveedor
                .Name = "id_proveedor" : .DataPropertyName = "id_proveedor" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_ruc As New DataGridViewTextBoxColumn
            With col_ruc
                .Name = "ruc" : .DataPropertyName = "ruc" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_proveedor As New DataGridViewTextBoxColumn
            With col_proveedor
                .Name = "proveedor" : .DataPropertyName = "proveedor" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_numero_estiba As New DataGridViewTextBoxColumn
            With col_numero_estiba
                .Name = "numero_estiba" : .DataPropertyName = "numero_estiba" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_facturado As New DataGridViewTextBoxColumn
            With col_facturado
                .Name = "facturado" : .DataPropertyName = "facturado" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_id_solicitante As New DataGridViewTextBoxColumn
            With col_id_solicitante
                .Name = "id_solicitante" : .DataPropertyName = "id_solicitante" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .HeaderText = "Observacion" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_formato As New DataGridViewTextBoxColumn
            With col_formato
                .Name = "formato" : .DataPropertyName = "formato" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_observacion2 As New DataGridViewTextBoxColumn
            With col_observacion2
                .Name = "observacion2" : .DataPropertyName = "observacion2"
                .DisplayIndex = x : .HeaderText = "Observacion por Desaprobación" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_ciudad, col_fecha_operacion, col_operacion, col_monto, col_estado, col_fecha_solicitud, col_fecha_aprobacion, _
                              col_fecha_desaprobacion, col_fecha_anulacion, col_id_operacion, _
                              col_id_proveedor, col_ruc, col_proveedor, col_numero, col_solicitante, _
                              col_observacion, col_numero_estiba, col_facturado, col_id_estado, col_hora_inicio, col_hora_fin, col_formato, col_observacion2)
        End With
    End Sub
    Private Sub ConfigurarDGVEstiba(ByVal opcion As Integer)
        With dgvEstiba
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvRecojo)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            If opcion = 1 Then
                Dim x As Integer = 0
                Dim col_id_grt As New DataGridViewTextBoxColumn
                With col_id_grt
                    .Name = "id_grt" : .DataPropertyName = "id_grt" : .DisplayIndex = x : .HeaderText = "id_grt" : .Visible = False
                End With
                x += +1
                Dim col_bus As New DataGridViewTextBoxColumn
                With col_bus
                    .Name = "bus" : .DataPropertyName = "bus"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Bus"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_grt As New DataGridViewTextBoxColumn
                With col_grt
                    .Name = "grt" : .DataPropertyName = "grt"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº GRT"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_origen As New DataGridViewTextBoxColumn
                With col_origen
                    .Name = "origen" : .DataPropertyName = "origen"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_destino As New DataGridViewTextBoxColumn
                With col_destino
                    .Name = "destino" : .DataPropertyName = "destino"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_peso As New DataGridViewTextBoxColumn
                With col_peso
                    .Name = "peso" : .DataPropertyName = "peso"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_cantidad As New DataGridViewTextBoxColumn
                With col_cantidad
                    .Name = "cantidad" : .DataPropertyName = "cantidad"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
                End With
                .Columns.AddRange(col_id_grt, col_bus, col_grt, col_origen, col_destino, col_peso, col_cantidad, col_estado)
            Else
                Dim x As Integer = 0
                Dim col_id As New DataGridViewTextBoxColumn
                With col_id
                    .Name = "id" : .DataPropertyName = "id"
                    .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
                End With
                x += +1
                Dim col_id_2 As New DataGridViewTextBoxColumn
                With col_id_2
                    .Name = "id_2" : .DataPropertyName = "id_2"
                    .DisplayIndex = x : .HeaderText = "id_2" : .Visible = False
                End With
                x += +1
                Dim col_fecha As New DataGridViewTextBoxColumn
                With col_fecha
                    .Name = "fecha" : .DataPropertyName = "fecha"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "dd/MM/yyyy"
                End With
                x += +1
                Dim col_tipo As New DataGridViewTextBoxColumn
                With col_tipo
                    .Name = "tipo" : .DataPropertyName = "tipo"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_comprobante As New DataGridViewTextBoxColumn
                With col_comprobante
                    .Name = "comprobante" : .DataPropertyName = "comprobante"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Doc."
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_origen As New DataGridViewTextBoxColumn
                With col_origen
                    .Name = "origen" : .DataPropertyName = "origen"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_destino As New DataGridViewTextBoxColumn
                With col_destino
                    .Name = "destino" : .DataPropertyName = "destino"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_cliente As New DataGridViewTextBoxColumn
                With col_cliente
                    .Name = "cliente" : .DataPropertyName = "cliente"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_peso As New DataGridViewTextBoxColumn
                With col_peso
                    .Name = "peso" : .DataPropertyName = "peso"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_cantidad As New DataGridViewTextBoxColumn
                With col_cantidad
                    .Name = "cantidad" : .DataPropertyName = "cantidad"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
                End With
                x += +1
                Dim col_id_comprobante As New DataGridViewTextBoxColumn
                With col_id_comprobante
                    .Name = "id_comprobante" : .DataPropertyName = "id_comprobante"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "id_comprobante"
                End With
                x += +1
                Dim col_id_tipo As New DataGridViewTextBoxColumn
                With col_id_tipo
                    .Name = "id_tipo" : .DataPropertyName = "id_tipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_tipo"
                End With
                x += +1
                Dim col_id_origen As New DataGridViewTextBoxColumn
                With col_id_origen
                    .Name = "id_origen" : .DataPropertyName = "id_origen" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_origen"
                End With
                x += +1
                Dim col_id_destino As New DataGridViewTextBoxColumn
                With col_id_destino
                    .Name = "id_destino" : .DataPropertyName = "id_destino" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_destino"
                End With
                x += +1
                Dim col_id_persona As New DataGridViewTextBoxColumn
                With col_id_persona
                    .Name = "id_persona" : .DataPropertyName = "id_persona" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_persona"
                End With
                x += +1
                Dim col_producto As New DataGridViewTextBoxColumn
                With col_producto
                    .Name = "producto" : .DataPropertyName = "producto" : .DisplayIndex = x : .Visible = False : .HeaderText = "producto"
                End With
                .Columns.AddRange(col_id, col_id_2, col_fecha, col_tipo, col_comprobante, col_origen, col_destino, col_cliente, _
                                  col_peso, col_cantidad, col_estado, col_id_comprobante, col_id_tipo, col_id_origen, col_id_destino, col_id_persona, col_producto)
            End If
        End With
    End Sub
    Private Sub ConfigurarDGVEstibaAprobacion(ByVal opcion As Integer)
        With dgvEstibaAprobacion
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvRecojo)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            If opcion = 1 Then
                Dim x As Integer = 0
                Dim col_id_grt As New DataGridViewTextBoxColumn
                With col_id_grt
                    .Name = "id_grt" : .DataPropertyName = "id_grt" : .DisplayIndex = x : .HeaderText = "id_grt" : .Visible = False
                End With
                x += +1
                Dim col_bus As New DataGridViewTextBoxColumn
                With col_bus
                    .Name = "bus" : .DataPropertyName = "bus"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Bus"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_grt As New DataGridViewTextBoxColumn
                With col_grt
                    .Name = "grt" : .DataPropertyName = "grt"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº GRT"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_origen As New DataGridViewTextBoxColumn
                With col_origen
                    .Name = "origen" : .DataPropertyName = "origen"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_destino As New DataGridViewTextBoxColumn
                With col_destino
                    .Name = "destino" : .DataPropertyName = "destino"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_peso As New DataGridViewTextBoxColumn
                With col_peso
                    .Name = "peso" : .DataPropertyName = "peso"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_cantidad As New DataGridViewTextBoxColumn
                With col_cantidad
                    .Name = "cantidad" : .DataPropertyName = "cantidad"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
                End With
                .Columns.AddRange(col_id_grt, col_bus, col_grt, col_origen, col_destino, col_peso, col_cantidad, col_estado)
            Else
                Dim x As Integer = 0
                Dim col_id As New DataGridViewTextBoxColumn
                With col_id
                    .Name = "id" : .DataPropertyName = "id"
                    .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
                End With
                x += +1
                Dim col_id_2 As New DataGridViewTextBoxColumn
                With col_id_2
                    .Name = "id_2" : .DataPropertyName = "id_2"
                    .DisplayIndex = x : .HeaderText = "id_2" : .Visible = False
                End With
                x += +1
                Dim col_fecha As New DataGridViewTextBoxColumn
                With col_fecha
                    .Name = "fecha" : .DataPropertyName = "fecha"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "dd/MM/yyyy"
                End With
                x += +1
                Dim col_tipo As New DataGridViewTextBoxColumn
                With col_tipo
                    .Name = "tipo" : .DataPropertyName = "tipo"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_comprobante As New DataGridViewTextBoxColumn
                With col_comprobante
                    .Name = "comprobante" : .DataPropertyName = "comprobante"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Doc."
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_origen As New DataGridViewTextBoxColumn
                With col_origen
                    .Name = "origen" : .DataPropertyName = "origen"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_destino As New DataGridViewTextBoxColumn
                With col_destino
                    .Name = "destino" : .DataPropertyName = "destino"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_cliente As New DataGridViewTextBoxColumn
                With col_cliente
                    .Name = "cliente" : .DataPropertyName = "cliente"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_peso As New DataGridViewTextBoxColumn
                With col_peso
                    .Name = "peso" : .DataPropertyName = "peso"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_cantidad As New DataGridViewTextBoxColumn
                With col_cantidad
                    .Name = "cantidad" : .DataPropertyName = "cantidad"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Bultos" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
                End With
                x += +1
                Dim col_id_comprobante As New DataGridViewTextBoxColumn
                With col_id_comprobante
                    .Name = "id_comprobante" : .DataPropertyName = "id_comprobante"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "id_comprobante"
                End With
                x += +1
                Dim col_id_tipo As New DataGridViewTextBoxColumn
                With col_id_tipo
                    .Name = "id_tipo" : .DataPropertyName = "id_tipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_tipo"
                End With
                x += +1
                Dim col_id_origen As New DataGridViewTextBoxColumn
                With col_id_origen
                    .Name = "id_origen" : .DataPropertyName = "id_origen" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_origen"
                End With
                x += +1
                Dim col_id_destino As New DataGridViewTextBoxColumn
                With col_id_destino
                    .Name = "id_destino" : .DataPropertyName = "id_destino" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_destino"
                End With
                x += +1
                Dim col_id_persona As New DataGridViewTextBoxColumn
                With col_id_persona
                    .Name = "id_persona" : .DataPropertyName = "id_persona" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_persona"
                End With
                .Columns.AddRange(col_id, col_id_2, col_fecha, col_tipo, col_comprobante, col_origen, col_destino, col_cliente, _
                                  col_peso, col_cantidad, col_estado, col_id_comprobante, col_id_tipo, col_id_origen, col_id_destino, col_id_persona)
            End If
        End With
    End Sub
    Private Sub ConfigurarDGVCalculoProvision()
        With dgvCalculoProvision
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvRecojo)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id_ciudad As New DataGridViewTextBoxColumn
            With col_id_ciudad
                .Name = "id_ciudad" : .DataPropertyName = "id_ciudad" : .DisplayIndex = x : .HeaderText = "id_ciudad" : .Visible = False
            End With
            x += +1
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ciudad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_id_proveedor As New DataGridViewTextBoxColumn
            With col_id_proveedor
                .Name = "id_proveedor" : .DataPropertyName = "id_proveedor" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_proveedor"
            End With
            x += +1
            Dim col_id_concepto As New DataGridViewTextBoxColumn
            With col_id_concepto
                .Name = "id_concepto" : .DataPropertyName = "id_concepto" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_concepto"
            End With
            x += +1
            Dim col_concepto As New DataGridViewTextBoxColumn
            With col_concepto
                .Name = "concepto" : .DataPropertyName = "concepto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Concepto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_proveedor As New DataGridViewTextBoxColumn
            With col_proveedor
                .Name = "proveedor" : .DataPropertyName = "proveedor"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Proveedor"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_factura As New DataGridViewTextBoxColumn
            With col_factura
                .Name = "factura" : .DataPropertyName = "factura"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Factura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_solicitud As New DataGridViewTextBoxColumn
            With col_solicitud
                .Name = "solicitud" : .DataPropertyName = "solicitud" : .DisplayIndex = x : .Visible = False : .HeaderText = "solicitud"
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            .Columns.AddRange(col_id_ciudad, col_id_concepto, col_id_proveedor, col_ciudad, col_concepto, col_proveedor, col_factura, col_solicitud, col_monto)
        End With
    End Sub
    Private Sub ConfigurarDGVConsultaProvision()
        With dgvConsultaProvision
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvRecojo)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_guia As New DataGridViewTextBoxColumn
            With col_guia
                .Name = "guia" : .DataPropertyName = "guia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Guía" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_subtotal As New DataGridViewTextBoxColumn
            With col_subtotal
                .Name = "subtotal" : .DataPropertyName = "subtotal"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subtotal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_impuesto As New DataGridViewTextBoxColumn
            With col_impuesto
                .Name = "impuesto" : .DataPropertyName = "impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_monto_fuera_zona As New DataGridViewTextBoxColumn
            With col_monto_fuera_zona
                .Name = "monto_fuera_zona" : .DataPropertyName = "monto_fuera_zona"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Fuera Zona"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            .Columns.AddRange(col_origen, col_destino, col_fecha, col_guia, col_cliente, col_subtotal, col_impuesto, col_total, col_monto_fuera_zona, col_fecha_aprobacion)
        End With
    End Sub
    Sub FormateardgvListaTraslado()
        With dgvListaTraslado
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With
            x += +1
            Dim col_fecha_operacion As New DataGridViewTextBoxColumn
            With col_fecha_operacion
                .Name = "fecha_operacion" : .DataPropertyName = "fecha_operacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_solicitud As New DataGridViewTextBoxColumn
            With col_fecha_solicitud
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud" : .DisplayIndex = x : .Visible = True
                .HeaderText = "Fecha Solicitud"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_desaprobacion As New DataGridViewTextBoxColumn
            With col_fecha_desaprobacion
                .Name = "fecha_desaprobacion" : .DataPropertyName = "fecha_desaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Desaprobación" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_anulacion As New DataGridViewTextBoxColumn
            With col_fecha_anulacion
                .Name = "fecha_anulacion" : .DataPropertyName = "fecha_anulacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Anulación" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad" : .DisplayIndex = x : .Visible = True : .HeaderText = "Ciudad"
            End With
            x += +1
            Dim col_id_operacion As New DataGridViewTextBoxColumn
            With col_id_operacion
                .Name = "id_operacion" : .DataPropertyName = "id_operacion" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_id_proveedor As New DataGridViewTextBoxColumn
            With col_id_proveedor
                .Name = "id_proveedor" : .DataPropertyName = "id_proveedor" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_ruc As New DataGridViewTextBoxColumn
            With col_ruc
                .Name = "ruc" : .DataPropertyName = "ruc" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_proveedor As New DataGridViewTextBoxColumn
            With col_proveedor
                .Name = "proveedor" : .DataPropertyName = "proveedor" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_numero_estiba As New DataGridViewTextBoxColumn
            With col_numero_estiba
                .Name = "numero_estiba" : .DataPropertyName = "numero_estiba" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_facturado As New DataGridViewTextBoxColumn
            With col_facturado
                .Name = "facturado" : .DataPropertyName = "facturado" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_id_solicitante As New DataGridViewTextBoxColumn
            With col_id_solicitante
                .Name = "id_solicitante" : .DataPropertyName = "id_solicitante" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_id_movil As New DataGridViewTextBoxColumn
            With col_id_movil
                .Name = "id_movil" : .DataPropertyName = "id_movil" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .HeaderText = "Observacion" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_formato As New DataGridViewTextBoxColumn
            With col_formato
                .Name = "formato" : .DataPropertyName = "formato" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_observacion2 As New DataGridViewTextBoxColumn
            With col_observacion2
                .Name = "observacion2" : .DataPropertyName = "observacion2"
                .DisplayIndex = x : .HeaderText = "Observacion por Desaprobación" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_fecha_operacion, col_monto, col_estado, col_fecha_solicitud, col_fecha_aprobacion, _
                              col_fecha_desaprobacion, col_fecha_anulacion, col_ciudad, col_id_operacion, _
                              col_id_proveedor, col_ruc, col_proveedor, col_numero, col_solicitante, _
                              col_observacion, col_numero_estiba, col_facturado, col_id_estado, col_id_movil, col_formato, col_observacion2)
        End With
    End Sub
    Private Sub ConfigurarDGVTraslado(ByVal opcion As Integer)
        With dgvTraslado
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvRecojo)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            If opcion = 1 Then
                Dim x As Integer = 0
                Dim col_id_grt As New DataGridViewTextBoxColumn
                With col_id_grt
                    .Name = "id_grt" : .DataPropertyName = "id_grt" : .DisplayIndex = x : .HeaderText = "id_grt" : .Visible = False
                End With
                x += +1
                Dim col_bus As New DataGridViewTextBoxColumn
                With col_bus
                    .Name = "bus" : .DataPropertyName = "bus"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Bus"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_grt As New DataGridViewTextBoxColumn
                With col_grt
                    .Name = "grt" : .DataPropertyName = "grt"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº GRT"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_origen As New DataGridViewTextBoxColumn
                With col_origen
                    .Name = "origen" : .DataPropertyName = "origen"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_destino As New DataGridViewTextBoxColumn
                With col_destino
                    .Name = "destino" : .DataPropertyName = "destino"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_peso As New DataGridViewTextBoxColumn
                With col_peso
                    .Name = "peso" : .DataPropertyName = "peso"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_cantidad As New DataGridViewTextBoxColumn
                With col_cantidad
                    .Name = "cantidad" : .DataPropertyName = "cantidad"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
                End With
                .Columns.AddRange(col_id_grt, col_bus, col_grt, col_origen, col_destino, col_peso, col_cantidad, col_estado)
            Else
                Dim x As Integer = 0
                Dim col_id As New DataGridViewTextBoxColumn
                With col_id
                    .Name = "id" : .DataPropertyName = "id"
                    .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
                End With
                x += +1
                Dim col_id_2 As New DataGridViewTextBoxColumn
                With col_id_2
                    .Name = "id_2" : .DataPropertyName = "id_2"
                    .DisplayIndex = x : .HeaderText = "id_2" : .Visible = False
                End With
                x += +1
                Dim col_fecha As New DataGridViewTextBoxColumn
                With col_fecha
                    .Name = "fecha" : .DataPropertyName = "fecha"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "dd/MM/yyyy"
                End With
                x += +1
                Dim col_tipo As New DataGridViewTextBoxColumn
                With col_tipo
                    .Name = "tipo" : .DataPropertyName = "tipo"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_comprobante As New DataGridViewTextBoxColumn
                With col_comprobante
                    .Name = "comprobante" : .DataPropertyName = "comprobante"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Doc."
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_origen As New DataGridViewTextBoxColumn
                With col_origen
                    .Name = "origen" : .DataPropertyName = "origen"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_destino As New DataGridViewTextBoxColumn
                With col_destino
                    .Name = "destino" : .DataPropertyName = "destino"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_cliente As New DataGridViewTextBoxColumn
                With col_cliente
                    .Name = "cliente" : .DataPropertyName = "cliente"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_peso As New DataGridViewTextBoxColumn
                With col_peso
                    .Name = "peso" : .DataPropertyName = "peso"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_cantidad As New DataGridViewTextBoxColumn
                With col_cantidad
                    .Name = "cantidad" : .DataPropertyName = "cantidad"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
                End With
                x += +1
                Dim col_id_comprobante As New DataGridViewTextBoxColumn
                With col_id_comprobante
                    .Name = "id_comprobante" : .DataPropertyName = "id_comprobante"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "id_comprobante"
                End With
                x += +1
                Dim col_id_tipo As New DataGridViewTextBoxColumn
                With col_id_tipo
                    .Name = "id_tipo" : .DataPropertyName = "id_tipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_tipo"
                End With
                x += +1
                Dim col_id_origen As New DataGridViewTextBoxColumn
                With col_id_origen
                    .Name = "id_origen" : .DataPropertyName = "id_origen" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_origen"
                End With
                x += +1
                Dim col_id_destino As New DataGridViewTextBoxColumn
                With col_id_destino
                    .Name = "id_destino" : .DataPropertyName = "id_destino" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_destino"
                End With
                x += +1
                Dim col_id_persona As New DataGridViewTextBoxColumn
                With col_id_persona
                    .Name = "id_persona" : .DataPropertyName = "id_persona" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_persona"
                End With
                x += +1
                Dim col_producto As New DataGridViewTextBoxColumn
                With col_producto
                    .Name = "producto" : .DataPropertyName = "producto" : .DisplayIndex = x : .Visible = False : .HeaderText = "producto"
                End With
                .Columns.AddRange(col_id, col_id_2, col_fecha, col_tipo, col_comprobante, col_origen, col_destino, col_cliente, _
                                  col_peso, col_cantidad, col_estado, col_id_comprobante, col_id_tipo, col_id_origen, col_id_destino, col_id_persona, col_producto)
            End If
        End With
    End Sub
    Private Sub ConfigurarDGVTrasladoAprobacion(ByVal opcion As Integer)
        With dgvTrasladoAprobacion
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvRecojo)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            If opcion = 1 Then
                Dim x As Integer = 0
                Dim col_id_grt As New DataGridViewTextBoxColumn
                With col_id_grt
                    .Name = "id_grt" : .DataPropertyName = "id_grt" : .DisplayIndex = x : .HeaderText = "id_grt" : .Visible = False
                End With
                x += +1
                Dim col_bus As New DataGridViewTextBoxColumn
                With col_bus
                    .Name = "bus" : .DataPropertyName = "bus"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Bus"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_grt As New DataGridViewTextBoxColumn
                With col_grt
                    .Name = "grt" : .DataPropertyName = "grt"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº GRT"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_origen As New DataGridViewTextBoxColumn
                With col_origen
                    .Name = "origen" : .DataPropertyName = "origen"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_destino As New DataGridViewTextBoxColumn
                With col_destino
                    .Name = "destino" : .DataPropertyName = "destino"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_peso As New DataGridViewTextBoxColumn
                With col_peso
                    .Name = "peso" : .DataPropertyName = "peso"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_cantidad As New DataGridViewTextBoxColumn
                With col_cantidad
                    .Name = "cantidad" : .DataPropertyName = "cantidad"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
                End With
                .Columns.AddRange(col_id_grt, col_bus, col_grt, col_origen, col_destino, col_peso, col_cantidad, col_estado)
            Else
                Dim x As Integer = 0
                Dim col_id As New DataGridViewTextBoxColumn
                With col_id
                    .Name = "id" : .DataPropertyName = "id"
                    .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
                End With
                x += +1
                Dim col_id_2 As New DataGridViewTextBoxColumn
                With col_id_2
                    .Name = "id_2" : .DataPropertyName = "id_2"
                    .DisplayIndex = x : .HeaderText = "id_2" : .Visible = False
                End With
                x += +1
                Dim col_fecha As New DataGridViewTextBoxColumn
                With col_fecha
                    .Name = "fecha" : .DataPropertyName = "fecha"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "dd/MM/yyyy"
                End With
                x += +1
                Dim col_tipo As New DataGridViewTextBoxColumn
                With col_tipo
                    .Name = "tipo" : .DataPropertyName = "tipo"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_comprobante As New DataGridViewTextBoxColumn
                With col_comprobante
                    .Name = "comprobante" : .DataPropertyName = "comprobante"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Doc."
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_origen As New DataGridViewTextBoxColumn
                With col_origen
                    .Name = "origen" : .DataPropertyName = "origen"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_destino As New DataGridViewTextBoxColumn
                With col_destino
                    .Name = "destino" : .DataPropertyName = "destino"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_cliente As New DataGridViewTextBoxColumn
                With col_cliente
                    .Name = "cliente" : .DataPropertyName = "cliente"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                x += +1
                Dim col_peso As New DataGridViewTextBoxColumn
                With col_peso
                    .Name = "peso" : .DataPropertyName = "peso"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_cantidad As New DataGridViewTextBoxColumn
                With col_cantidad
                    .Name = "cantidad" : .DataPropertyName = "cantidad"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Bultos" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
                End With
                x += +1
                Dim col_id_comprobante As New DataGridViewTextBoxColumn
                With col_id_comprobante
                    .Name = "id_comprobante" : .DataPropertyName = "id_comprobante"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "id_comprobante"
                End With
                x += +1
                Dim col_id_tipo As New DataGridViewTextBoxColumn
                With col_id_tipo
                    .Name = "id_tipo" : .DataPropertyName = "id_tipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_tipo"
                End With
                x += +1
                Dim col_id_origen As New DataGridViewTextBoxColumn
                With col_id_origen
                    .Name = "id_origen" : .DataPropertyName = "id_origen" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_origen"
                End With
                x += +1
                Dim col_id_destino As New DataGridViewTextBoxColumn
                With col_id_destino
                    .Name = "id_destino" : .DataPropertyName = "id_destino" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_destino"
                End With
                x += +1
                Dim col_id_persona As New DataGridViewTextBoxColumn
                With col_id_persona
                    .Name = "id_persona" : .DataPropertyName = "id_persona" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_persona"
                End With
                .Columns.AddRange(col_id, col_id_2, col_fecha, col_tipo, col_comprobante, col_origen, col_destino, col_cliente, _
                                  col_peso, col_cantidad, col_estado, col_id_comprobante, col_id_tipo, col_id_origen, col_id_destino, col_id_persona)
            End If
        End With
    End Sub
#End Region

#Region "Variables"
    Dim tabSolicitudReparto As TabPage, tabAprobacionReparto As TabPage
#End Region

#Region "Tab"
    Private Sub tabReparto_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabReparto.SelectedIndexChanged
        Static tab As TabPage
        If tabReparto.SelectedTab Is tabReparto.TabPages("tabLista") Then
            If intNivel = 1 Or intNivel = 4 Then
                tsbNuevo.Enabled = True : tsbEditar.Enabled = Me.dgvLista.Rows.Count > 0 : tsbAnular.Enabled = Me.dgvLista.Rows.Count > 0
            Else
                tsbNuevo.Enabled = False : tsbEditar.Enabled = Me.dgvLista.Rows.Count > 0 : tsbAnular.Enabled = False
            End If
            tsbGrabar.Enabled = False
            FormateardgvLista()
            cboEstadoSolicitudReparto_SelectedIndexChanged(Nothing, Nothing)

        ElseIf tabReparto.SelectedTab Is tabReparto.TabPages("tabSolicitar") Then
            If intModo = 1 Then
                LimpiarSolicitudReparto()
                tsbNuevo_Click(Nothing, Nothing)
            End If
            'LimpiarSolicitudReparto()
            'If tab Is tabReparto.TabPages("tabLista") AndAlso Me.dgvLista.Rows.Count > 0 Then
            '    tsbEditar_Click(Nothing, Nothing)
            'Else
            'tsbNuevo_Click(Nothing, Nothing)
            'End If
            If intNivel <> 1 And intNivel <> 4 Then
                Me.tsbGrabar.Enabled = False
            End If

        ElseIf tabReparto.SelectedTab Is tabReparto.TabPages("tabGenerarGasto") Then
            tool.Items(0).Enabled = False : tool.Items(1).Enabled = False : tool.Items(2).Enabled = False : tool.Items(3).Enabled = False
            InicioGenerarGasto()
            If intTipoPago <> intTipoGasto.Peso Then
                Me.btnCalcular.Enabled = False
            End If

        ElseIf tabReparto.SelectedTab Is tabReparto.TabPages("tabAprobar") Then
            LimpiarAprobacionReparto()
            Me.tsbNuevo.Enabled = False
            Me.tsbGrabar.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False

            Dim intAdicional As Integer = 0, intTipoPago As Integer
            If Me.dgvLista.Rows.Count > 0 Then
                If Me.dgvLista.CurrentRow.Cells("id_operacion").Value = 1 Then
                    intAdicional = Me.dgvLista.CurrentRow.Cells("gasto_adicional").Value
                Else
                    intAdicional = 0
                End If
                intTipoPago = IIf(intAdicional = 0, Me.dgvLista.CurrentRow.Cells("tipo_gasto").Value, Me.dgvLista.CurrentRow.Cells("tipo_gasto_adicional").Value)
            End If

            If intTipoPago = intTipoGasto.Hora Then 'Me.lblTipoPago.Tag = intTipoGasto.Hora Then
                Me.lblTiempo1Gasto.Visible = True
                Me.lblTiempo1.Visible = True
            ElseIf intTipoPago = intTipoGasto.Dia Then
                Me.lblTiempo1Gasto.Visible = False
                Me.lblTiempo1.Visible = False
            ElseIf intTipoPago = intTipoGasto.Peso Then
                Me.lblTiempo1Gasto.Visible = False
                Me.lblTiempo1.Visible = False
            End If
            If Me.dgvLista.Rows.Count > 0 Then
                Me.rbtSiGasto.Enabled = True
                Me.rbtNoGasto.Enabled = True
                Me.txtObservacionGasto.Enabled = True
                Me.btnAceptarGasto.Enabled = True
                Me.grbRepartoGasto.Enabled = True

                Me.lblFechaGasto.Text = Me.dgvLista.CurrentRow.Cells("fecha_operacion").Value
                Me.lblCiudadGasto.Text = Me.dgvLista.CurrentRow.Cells("ciudad").Value
                Me.lblSolicitanteGasto.Text = Me.dgvLista.CurrentRow.Cells("solicitante").Value

                Me.lblTipoGasto.Text = IIf(intAdicional = 0, Me.dgvLista.CurrentRow.Cells("tipo").Value, Me.dgvLista.CurrentRow.Cells("tipo_adicional").Value)

                Me.lblTiempo1Gasto.Text = Format(Me.dgvLista.CurrentRow.Cells("tiempo1").Value, "###,###,###0.00")
                Me.lblTiempo2Gasto.Text = Format(Me.dgvLista.CurrentRow.Cells("tiempo2").Value, "###,###,###0.00")

                Me.lblTarifaCiudadGasto.Text = Format(CDbl(Me.dgvLista.CurrentRow.Cells("tarifa_oficina").Value), "###,###,###0.00")
                Me.lblMontoGasto.Text = Format(CDbl(Me.dgvLista.CurrentRow.Cells("monto").Value), "###,###,###0.00")

                Dim intID As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
                ListarReparto(intID)
                Me.btnAceptarGasto.Focus()
            Else
                Me.rbtSiGasto.Enabled = False
                Me.rbtNoGasto.Enabled = False
                Me.txtObservacionGasto.Enabled = False
                Me.btnAceptarGasto.Enabled = False
            End If
            End If
            tab = tabReparto.SelectedTab
    End Sub

    Private Sub tabGasto_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabGasto.SelectedIndexChanged
        If tabGasto.SelectedTab Is tabGasto.TabPages("tabRepartir") Then
            InicializarMenu()
            tabReparto_SelectedIndexChanged(Nothing, Nothing)
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabFz") Then
            Inicio()
            tabFueraZona_SelectedIndexChanged(Nothing, Nothing)
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabEstibar") Then
            InicioEstiba()
            tabEstiba_SelectedIndexChanged(Nothing, Nothing)
            Me.cboEstadoSolicitudEstiba.SelectedIndex = 1
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabTrasladar") Then
            InicioTraslado()
            tabTraslado_SelectedIndexChanged(Nothing, Nothing)
            Me.cboEstadoSolicitudTraslado.SelectedIndex = 1
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabEmbalar") Then
            InicializarMenu()
            InicioEmbalaje()
            tabEmbalaje_SelectedIndexChanged(Nothing, Nothing)
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabResumen") Then
            InicializarMenu()
            FormateardgvResumen()
            'InicioResumen()
            tool.Items(0).Enabled = False : tool.Items(1).Enabled = False : tool.Items(2).Enabled = False : tool.Items(3).Enabled = False
            aCampo(0) = True : aGrupo(0) = True
            TotalCabecera()
            CalcularCelda()
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabProvisionar") Then
            aGrupoProvision(0) = True
            aGrupoProvision(1) = True
            aGrupoProvision(2) = True
            aGrupoProvision(3) = True

            InicioProvision()
            tabProvision_SelectedIndexChanged(Nothing, Nothing)

            Me.chkCiudadProvision.Checked = aGrupoProvision(0) : Me.chkConceptoProvision.Checked = aGrupoProvision(1) : Me.chkProveedorProvision.Checked = aGrupoProvision(2) : Me.chkFacturaProvision.Checked = aGrupoProvision(3)
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabFacturar") Then
            InicializarMenu()
            With Me.cboTipoAfectacion
                .DisplayMember = "descripcion"
                .ValueMember = "codigo"
                .DataSource = ListarTipoControl(16, 2)
                If dtoUSUARIOS.iIDAGENCIAS = 1805 Or dtoUSUARIOS.iIDAGENCIAS = 3842 Or dtoUSUARIOS.iIDAGENCIAS = 2671 Or dtoUSUARIOS.iIDAGENCIAS = 2641 Or _
                    dtoUSUARIOS.iIDAGENCIAS = 1809 Or dtoUSUARIOS.iIDAGENCIAS = 1810 Or dtoUSUARIOS.iIDAGENCIAS = 1807 Or dtoUSUARIOS.iIDAGENCIAS = 1804 Then
                    .SelectedValue = 2
                    .Enabled = False
                Else
                    .SelectedValue = 1
                    .Enabled = True
                End If
            End With
            If intNivel = 1 Or intNivel = 4 Then
                Me.lblProveedor.Visible = False
                Me.cboProveedor.Visible = False
            Else
                Me.lblProveedor.Visible = True
                Me.cboProveedor.Visible = True
            End If

            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            Me.tsbGrabar.Enabled = False
            ConfigurarDGVResultado()
            Me.dtpInicioImprimir.Value = "01/" & dtpInicioImprimir.Value.Month.ToString.PadLeft(2, "0") & "/" & dtpInicioImprimir.Value.Year
            Me.dtpInicioLista.Value = "01/" & dtpInicioLista.Value.Month.ToString.PadLeft(2, "0") & "/" & dtpInicioLista.Value.Year
            Me.dtpFinLista.Value = Now

            Me.cboConceptoFacturacion.SelectedIndex = 0
            Me.cboEstadoFacturacion.SelectedIndex = 1
        End If
    End Sub

    Private Sub tabGastoVariable_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabGastoVariable.SelectedIndexChanged
        'InicializarMenu()
        If tabGastoVariable.SelectedIndex = 0 Then
            tool.Items(0).Enabled = False
            tool.Items(2).Enabled = True
            tool.Items(2).Enabled = Me.dgvGenerarGasto.Rows.Count > 0
            tool.Items(3).Enabled = False
            Me.btnCalcular.Text = "Calcular"
            Me.dgvGenerarGasto.DataSource = Nothing
            Me.tsbGrabar.Enabled = False

            Me.dtpFechaInicio.Visible = True : Me.dtpFechaFin.Visible = True
            Me.dtpFechaInicio2.Visible = False : Me.dtpFechaFin2.Visible = False
        Else
            tool.Items(0).Enabled = False
            tool.Items(2).Enabled = False
            tool.Items(3).Enabled = True
            tool.Items(3).Enabled = Me.dgvGenerarGastoConsulta.Rows.Count > 0
            Me.btnCalcular.Text = "Consultar"

            Me.dtpFechaInicio.Visible = False : Me.dtpFechaFin.Visible = False
            Me.dtpFechaInicio2.Visible = True : Me.dtpFechaFin2.Visible = True
        End If
        TotalGastoVariable(tabGastoVariable.SelectedIndex)
    End Sub
#End Region
    Sub CalcularGasto()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable = obj.CalcularGasto(Me.cboCiudadGenerarGasto.SelectedValue, Me.dtpFechaInicio.Value.ToShortDateString, Me.dtpFechaFin.Value.ToShortDateString, _
                                                    1, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            Me.dgvGenerarGasto.DataSource = dt

            If dgvGenerarGasto.Rows.Count > 0 Then
                Dim dblTotal As Double = IIf(IsDBNull(dt.Compute("sum(total)", "")), 0, dt.Compute("sum(total)", ""))
                If dblTotal > 0 Then
                    tool.Items(2).Enabled = True
                Else
                    tool.Items(2).Enabled = False
                End If
            Else
                tool.Items(2).Enabled = False
            End If
            TotalGastoVariable(0)

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCalcular_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcular.Click
        If Me.tabGastoVariable.SelectedIndex = 0 Then
            CalcularGasto()
        Else
            ConsultarGasto()
        End If
    End Sub

    Private Sub tsbGrabar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabar.Click
        If tabGasto.SelectedTab Is tabGasto.TabPages("tabRepartir") Then
            If tabReparto.SelectedTab Is tabReparto.TabPages("tabSolicitar") Then
                GrabarSolicitudReparto()
            ElseIf tabReparto.SelectedTab Is tabReparto.TabPages("tabGenerarGasto") Then
                ObtenerProveedor()
            End If
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabFz") Then
            If tabFueraZona.SelectedTab Is tabFueraZona.TabPages("tabSolicitudZona") Then
                GrabarSolicitud()
            End If
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabEstibar") Then
            If tabEstiba.SelectedTab Is tabEstiba.TabPages("tabSolicitudEstiba") Then
                If Me.rbtGrt.Checked Then
                    GrabarSolicitudEstiba()
                Else
                    GrabarSolicitudEstibaComprobante()
                End If
            End If
            ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabTrasladar") Then
            If tabTraslado.SelectedTab Is tabTraslado.TabPages("tabSolicitudTraslado") Then
                If Me.rbtGrtTraslado.Checked Then
                    GrabarSolicitudTraslado()
                Else
                    GrabarSolicitudTrasladoComprobante()
                End If
            End If
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabEmbalar") Then
            If tabEmbalaje.SelectedTab Is tabEmbalaje.TabPages("tabSolicitudEmbalaje") Then
                GrabarSolicitudEmbalaje()
            End If
        End If
    End Sub

    Sub GrabarSolicitudTrasladoComprobante()
        If Val(Me.txtMontoTraslado.Text) = 0 Then
            MessageBox.Show("Ingrese Monto", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMontoTraslado.Focus()
            Return
        End If

        Dim blnRucValido As Boolean = fnValidarRUC(txtRucProveedorTraslado.Text)
        intLlamada = 1
        Me.txtRucProveedorTraslado_LostFocus(Nothing, Nothing)
        intLlamada = 0
        If Not blnRucValido Then
            MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRucProveedorTraslado.Focus()
            Return
        End If

        If Me.txtRazonSocialProveedorTraslado.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Razón Social", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRazonSocialProveedorTraslado.Text = ""
            txtRazonSocialProveedorTraslado.Focus()
            Return
        End If

        If ObtieneItemActivo(Me.dgvTraslado) = 0 Then
            MessageBox.Show("Ingrese los Comprobantes", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtGrtTraslado.Focus()
            Return
        End If

        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable
            Dim intID As Integer, intID_2 As Integer
            Dim intTipo As Integer, intComprobante As Integer, intEstado As Integer, intMovil As Integer
            Dim intProveedor As Integer, strRuc As String, strRazonSocial As String

            intProveedor = IIf(IsNothing(Me.txtRucProveedorTraslado.Tag), 0, Val(Me.txtRucProveedorTraslado.Tag))
            strRuc = Me.txtRucProveedorTraslado.Text.Trim
            strRazonSocial = Me.txtRazonSocialProveedorTraslado.Text.Trim

            If intOperacion = Operacion.Nuevo Then
                intID = 0 : intID_2 = 0
            Else
                intID = Me.dgvListaTraslado.CurrentRow.Cells("id").Value
                If Me.dgvTraslado.Rows.Count > 0 Then
                    intID_2 = Me.dgvTraslado.Rows(0).Cells("id_2").Value
                Else
                    intID_2 = 0
                End If
            End If
            For Each row As DataGridViewRow In Me.dgvTraslado.Rows
                intTipo = row.Cells("id_tipo").Value
                intComprobante = row.Cells("id_comprobante").Value
                intEstado = row.Cells("estado").Value
                dt = obj.GrabarSolicitudTraslado(intID, intID_2, dtoUSUARIOS.m_idciudad, Me.dtpFechaOperacionTraslado.Value.ToShortDateString, _
                                               dtoUSUARIOS.m_iIdAgencia, dtoUSUARIOS.IdLogin, Me.txtObservacionTraslado.Text.Trim, CDbl(Me.txtMontoTraslado.Text), _
                                               intTipo, intComprobante, _
                                               row.Cells("fecha").Value, row.Cells("id_origen").Value, row.Cells("id_destino").Value, row.Cells("id_persona").Value, _
                                               row.Cells("peso").Value, row.Cells("cantidad").Value, row.Cells("producto").Value, intEstado, _
                                               intProveedor, strRuc, strRazonSocial, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                intID = dt.Rows(0).Item(0)
                intID_2 = dt.Rows(0).Item(1)
            Next

            'Me.ListarTraslado(dtoUSUARIOS.m_idciudad, Me.cboEstadoSolicitudTraslado.SelectedIndex, Me.dgvListaTraslado)
            Me.ListarTraslado(Me.dgvListaTraslado)
            tabTraslado.SelectedIndex = 0
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub GrabarSolicitudReparto()
        If Me.chkReparto.Checked = False And Me.chkRecojo.Checked = False Then
            MessageBox.Show("Ingrese las operaciones de Reparto y/o Recojo", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.chkReparto.Focus()
            Return
        End If

        Dim blnRucValido As Boolean = fnValidarRUC(txtRucProveedorReparto.Text)
        intLlamada = 1
        Me.txtRucProveedorReparto_LostFocus(Nothing, Nothing)
        intLlamada = 0
        If Not blnRucValido Then
            MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRucProveedorReparto.Focus()
            Return
        End If

        If Me.txtRazonSocialProveedorReparto.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Razón Social", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRazonSocialProveedorReparto.Text = ""
            txtRazonSocialProveedorReparto.Focus()
            Return
        End If

        Dim objValida As New Cls_Gasto_LN
        If Not objValida.ValidaRepartoRecojo(dtoUSUARIOS.m_idciudad, Me.dtpFechaOperacion.Value.ToShortDateString) Then
            MessageBox.Show("La solicitud con Fecha de Operación " & Me.dtpFechaOperacion.Value.ToShortDateString & " ya Existe", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If Me.chkReparto.Checked Then 'Reparto
            If Not Me.chkTipoPagoAdicional.Checked Then
                If Me.lblTipoPago.Text.Trim.Length = 0 Then
                    MessageBox.Show("No tiene Asignado el Tipo de Pago", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                If Me.lblTipoPago.Tag = intTipoGasto.Peso Then
                    MessageBox.Show("No se Registran Solicitudes para el Tipo de Pago por PESO", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            Else
                'Valida Pago Adicional
                If Me.chkTipoPagoAdicional.Checked Then
                    If Me.cboResponsable.SelectedValue = 0 Then
                        MessageBox.Show("Seleccione Responsable Pago Adicional", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.cboResponsable.Focus()
                        Me.cboResponsable.DroppedDown = True
                        Return
                    End If
                End If
            End If

            If Me.dgvReparto.Rows.Count = 0 Then
                MessageBox.Show("Debe Cargar el Reparto", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtTiempoCiudad.Focus()
                Return
            End If

            If Me.chkTipoPagoAdicional.Checked = False And Val(Me.lblTiempoSugerido.Text) = 0 Then
                MessageBox.Show("No Existe Carga Entregada", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtTiempoCiudad.Focus()
                Return
            End If

            If ObtieneTipoPago() = intTipoGasto.Hora Then 'Me.lblTipoPago.Tag = 2 Then 'valida si se ingreso tiempo de reparto para el tipo de pago hora
                If Val(Me.txtTiempoCiudad.Text) = 0 Then
                    MessageBox.Show("Ingrese Tiempo", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtTiempoCiudad.Focus()
                    Return
                End If
            ElseIf ObtieneTipoPago() = intTipoGasto.Adicional Then
                If Val(Me.txtTiempoCiudad.Text) = 0 Then
                    MessageBox.Show("Ingrese Monto", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtTiempoCiudad.Focus()
                    Return
                End If
            End If

            If Not Me.chkTipoPagoAdicional.Checked And Not (ObtieneTipoPago() = intTipoGasto.Adicional) Then
                If Val(Me.lblMontoCiudad.Text) = 0 Then
                    MessageBox.Show("Ingrese Monto", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtTiempoCiudad.Focus()
                    Return
                End If
            End If
        End If

        If Me.chkRecojo.Checked Then 'Recojo
            If ObtieneTipoPago() = intTipoGasto.Hora Then 'Me.lblTipoPago.Tag = 2 Then 'valida si se ingreso tiempo de reparto para el tipo de pago hora
                If Val(Me.txtTiempoCiudad.Text) = 0 Then
                    MessageBox.Show("Ingrese Tiempo", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtTiempoCiudad.Focus()
                    Return
                End If
            ElseIf ObtieneTipoPago() = intTipoGasto.Adicional Then
                If Val(Me.txtTiempoCiudad.Text) = 0 Then
                    MessageBox.Show("Ingrese Monto", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtTiempoCiudad.Focus()
                    Return
                End If
            End If

            If Not Me.chkTipoPagoAdicional.Checked And Not (ObtieneTipoPago() = intTipoGasto.Adicional) Then
                If Val(Me.lblTarifaCiudad.Text) = 0 Then
                    MessageBox.Show("Ingrese Tarifa", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtTiempoCiudad.Focus()
                    Return
                End If
            End If

            If Me.rbtGrtRecojo.Checked Then
                If ObtieneItemActivo(Me.dgvRecojo) = 0 Then
                    MessageBox.Show("Ingrese la GRT", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtGrtRecojo.Focus()
                    Return
                End If
            Else
                If ObtieneItemActivo(Me.dgvRecojo) = 0 Then
                    MessageBox.Show("Ingrese los Comprobantes", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtComprobanteRecojo.Focus()
                    Return
                End If
            End If
        End If

        'hlamas 06-01-2020
        Try
            Dim blnGraba As Boolean = True
            Dim intFila As Integer = -1
            Dim intOpcion As Integer = 0
            If intOperacion = Operacion.Nuevo Then
                Dim intTipo As Integer, intComprobante As Integer
                Dim blnExiste As Boolean
                Dim obj As New Cls_Gasto_LN
                If Me.chkRecojo.Checked Then
                    For Each row As DataGridViewRow In Me.dgvRecojo.Rows
                        intTipo = row.Cells("id_tipo").Value
                        intComprobante = row.Cells("id_comprobante").Value
                        blnExiste = obj.ExisteComprobanteRecojo(intTipo, intComprobante)
                        If blnExiste Then
                            blnGraba = False
                            intFila = row.Index
                            intOpcion = 2
                            Exit For
                        End If
                    Next
                End If
            End If
            'If blnlGraba Then
            Cursor = Cursors.WaitCursor
            Dim intProveedor As Integer, strRuc As String, strRazonSocial As String, intID As Integer
            intProveedor = IIf(IsNothing(Me.txtRucProveedorReparto.Tag), 0, Val(Me.txtRucProveedorReparto.Tag))
            strRuc = Me.txtRucProveedorReparto.Text.Trim
            strRazonSocial = Me.txtRazonSocialProveedorReparto.Text.Trim

            Dim intCuentaOperacion As Integer
            Dim intIDGasto As Integer
            Dim objEN As New Cls_Gasto_EN
            If Me.chkReparto.Checked Then 'Graba Reparto
                intCuentaOperacion += 1
                If intOperacion = Operacion.Nuevo Then
                    intID = 0
                Else
                    If Me.dgvLista.CurrentRow.Cells("id_operacion").Value <> 3 Then
                        intID = dgvLista.CurrentRow.Cells("id").Value
                    Else
                        intID = dgvLista.CurrentRow.Cells("id_rep").Value
                    End If
                End If
                objEN.ID = intID
                objEN.Agencia = dtoUSUARIOS.iIDAGENCIAS
                objEN.FechaInicio = Me.lblFechaReparto.Text
                objEN.Solicitante = dtoUSUARIOS.IdLogin
                objEN.Observacion = Me.txtObservacionReparto.Text.Trim
                objEN.Tiempo1 = Me.lblTiempoSugerido.Text
                objEN.Tiempo2 = IIf(ObtieneTipoPago() = intTipoGasto.Hora, Me.txtTiempoCiudad.Text, objEN.Tiempo1)
                objEN.MontoAgencia = Me.lblTarifaCiudad.Text
                objEN.Monto = CType(Me.lblMontoReparto.Text, Double) 'Me.lblMontoCiudad.Text
                If Me.lblTipoPago.Text.Trim.Length > 0 Then
                    objEN.TipoGasto = Me.lblTipoPago.Tag
                Else
                    If Me.chkTipoPagoAdicional.Checked Then
                        objEN.TipoGasto = 10
                    Else
                        objEN.TipoGasto = 0
                    End If
                End If
                objEN.Ciudad = dtoUSUARIOS.m_idciudad
                objEN.FechaOperacion = Me.dtpFechaOperacion.Value.ToShortDateString

                If Me.chkTipoPagoAdicional.Checked Then
                    objEN.TipoGastoAdicional = 10
                    objEN.ResponsableAdicional = Me.cboResponsable.SelectedValue
                    objEN.Reparto = Me.cboHoraSalida.SelectedValue
                Else
                    objEN.TipoGastoAdicional = 0
                    objEN.ResponsableAdicional = 0
                    objEN.Reparto = 0
                End If
                objEN.GastoAdicional = IIf(Me.chkTipoPagoAdicional.Checked, 1, 0)

                objEN.Proveedor = intProveedor
                objEN.Ruc = strRuc
                objEN.RazonSocial = strRazonSocial

                objEN.Usuario = dtoUSUARIOS.IdLogin
                objEN.IP = dtoUSUARIOS.IP

                Dim obj As New Cls_Gasto_LN
                intIDGasto = obj.GrabarSolicitud(objEN)
            End If

            Dim intRecojo As Integer
            If Me.chkRecojo.Checked Then 'Graba Recojo
                intCuentaOperacion += 1
                If Me.rbtGrtRecojo.Checked Then
                    GrabarSolicitudRecojo(intRecojo)
                Else
                    Me.GrabarSolicitudRecojoComprobante(intRecojo)
                End If
            End If

            If intCuentaOperacion = 2 Then
                Dim dblPeso As Double
                Dim intCantidad As Integer
                dblPeso = CType(Me.lblPesoReparto.Text, Double) + CType(Me.lblPesoRecojo.Text, Double)
                intCantidad = CType(Me.lblCantidadReparto.Text, Integer) + CType(Me.lblCantidadRecojo.Text, Integer)
                If intOperacion = Operacion.Modificar Then
                    intIDGasto = Me.dgvLista.CurrentRow.Cells("id_rep").Value
                    intRecojo = Me.dgvLista.CurrentRow.Cells("id_rec").Value
                End If
                GrabarSolicitudCabecera(intIDGasto, intRecojo, Me.dtpFechaOperacion.Value.ToShortDateString, CType(Me.lblMontoCiudad.Text, Double), _
                                        Me.txtObservacionReparto.Text.Trim, intProveedor, objEN.TipoGasto, dblPeso, intCantidad, CType(Me.lblTarifaCiudad.Text, Double))
            End If

            Me.ListarSolicitudReparto()
            Me.tabReparto.SelectedIndex = 0
            Cursor = Cursors.Default
            'Else
            '    If intOpcion = 2 Then
            '        MessageBox.Show("El Comprobante " & Me.dgvRecojo.Rows(intFila).Cells("comprobante").Value & " ya está asociado a una Solicitud", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If
            'End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GrabarSolicitudCabecera(ByVal reparto As Integer, ByVal recojo As Integer, _
                                ByVal FechaOperacion As String, ByVal monto As Double, ByVal observacion As String, ByVal proveedor As Integer, _
                                ByVal TipoGasto As Integer, ByVal peso As Double, ByVal cantidad As Integer, ByVal MontoTarifa As Double)
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable
            Dim intID As Integer, intID_2 As Integer

            If intOperacion = Operacion.Nuevo Then
                intID = 0 : intID_2 = 0
            Else
                intID = Me.dgvLista.CurrentRow.Cells("id").Value
            End If
            obj.GrabarSolicitudCabecera(intID, reparto, recojo, dtoUSUARIOS.m_idciudad, FechaOperacion, monto, observacion, proveedor, _
                                        TipoGasto, peso, cantidad, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol, MontoTarifa)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GrabarSolicitudRecojoComprobante(Optional ByRef id As Integer = 0)
        Dim intProveedor As Integer, strRuc As String, strRazonSocial As String, intID As Integer
        Dim intTipo As Integer, intComprobante As Integer, intEstado As Integer, intID_2 As Integer
        Dim dt As DataTable
        Dim obj As New Cls_Gasto_LN
        Dim dblMontoTarifa As Double

        If Val(Me.lblTarifaCiudad.Text) = 0 Then
            dblMontoTarifa = 0
        Else
            dblMontoTarifa = CType(Me.lblTarifaCiudad.Text, Double) 'CType(Me.lblMontoCiudad.Text, Double)
        End If

        intProveedor = IIf(IsNothing(Me.txtRucProveedorReparto.Tag), 0, Val(Me.txtRucProveedorReparto.Tag))
        strRuc = Me.txtRucProveedorReparto.Text.Trim
        strRazonSocial = Me.txtRazonSocialProveedorReparto.Text.Trim

        If Me.lblTipoPago.Text.Trim.Length > 0 Then
            intTipoGasto = Me.lblTipoPago.Tag
        Else
            If Me.chkTipoPagoAdicional.Checked Then
                intTipoGasto = 10
            Else
                intTipoGasto = 0
            End If
        End If

        If intOperacion = Operacion.Nuevo Then
            intID = 0 : intID_2 = 0
        Else
            If Me.dgvLista.CurrentRow.Cells("id_operacion").Value = 3 Then
                intID = Me.dgvLista.CurrentRow.Cells("id_rec").Value
            Else
                intID = Me.dgvLista.CurrentRow.Cells("id").Value
            End If
            If Me.dgvRecojo.Rows.Count > 0 Then
                intID_2 = Me.dgvRecojo.Rows(0).Cells("id_2").Value
            Else
                intID_2 = 0
            End If
        End If
        For Each row As DataGridViewRow In Me.dgvRecojo.Rows
            intTipo = row.Cells("id_tipo").Value
            intComprobante = row.Cells("id_comprobante").Value
            intEstado = row.Cells("estado").Value
            dt = obj.GrabarSolicitudRecojo(intID, intID_2, dtoUSUARIOS.m_idciudad, Me.dtpFechaOperacion.Value.ToShortDateString, _
                                           dtoUSUARIOS.m_iIdAgencia, dtoUSUARIOS.IdLogin, _
                                           Me.txtObservacionReparto.Text.Trim, CDbl(Me.lblMontoRecojo.Text), _
                                           intTipo, intComprobante, _
                                           row.Cells("fecha").Value, row.Cells("id_origen").Value, row.Cells("id_destino").Value, row.Cells("id_persona").Value, _
                                           row.Cells("peso").Value, row.Cells("cantidad").Value, row.Cells("producto").Value, intEstado, _
                                           intProveedor, strRuc, strRazonSocial, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, intTipoGasto, dblMontoTarifa)
            intID = dt.Rows(0).Item(0)
            intID_2 = dt.Rows(0).Item(1)
        Next
        id = intID
    End Sub

    Sub Grabar()
        Cursor = Cursors.WaitCursor
        Try
            Dim objEN As New Cls_Gasto_EN
            objEN.Ciudad = dtoUSUARIOS.m_idciudad
            objEN.FechaInicio = Me.dtpFechaInicio.Value.ToShortDateString
            objEN.FechaFin = Me.dtpFechaFin.Value.ToShortDateString

            Dim intProveedor As Integer, strRuc As String, strRazonSocial As String

            intProveedor = IIf(IsNothing(Me.txtRucProveedorPeso.Tag), 0, Val(Me.txtRucProveedorPeso.Tag))
            strRuc = Me.txtRucProveedorPeso.Text.Trim
            strRazonSocial = Me.txtRazonSocialProveedorPeso.Text.Trim

            objEN.Proveedor = intProveedor
            objEN.Ruc = strRuc
            objEN.RazonSocial = strRazonSocial

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            Dim obj As New Cls_Gasto_LN
            obj.GrabarGasto(objEN)
            Cursor = Cursors.Default
            MessageBox.Show("Se Generó Archivo de Gastos", "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.pnlProveedor.Visible = False

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub InicioGenerarGasto()
        Dim obj As New Cls_Gasto_LN

        With cboCiudadGenerarGasto
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarCiudad
            .SelectedValue = dtoUSUARIOS.m_idciudad
            .Enabled = False
        End With

        Dim strFecha As String = FechaServidor()
        Me.dtpFechaInicio.Value = "01/" & Format(dtpFechaInicio.Value.Month, "00") & "/" & dtpFechaInicio.Value.Year
        Me.dtpFechaInicio2.Value = "01/" & Format(dtpFechaInicio2.Value.Month, "00") & "/" & dtpFechaInicio2.Value.Year

        FormateardgvGasto()
        FormateardgvGastoConsulta()
        FormateardgvGastoConsultaCab()
        tabGastoVariable_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Sub ConsultarGasto()
        Try
            Cursor = Cursors.WaitCursor
            Dim objEN As New Cls_Gasto_EN
            objEN.Ciudad = dtoUSUARIOS.m_idciudad
            objEN.FechaInicio = Me.dtpFechaInicio2.Value.ToShortDateString
            objEN.FechaFin = Me.dtpFechaFin2.Value.ToShortDateString

            Dim objLN As New Cls_Gasto_LN
            Me.dgvGenerarGastoConsultaCab.DataSource = objLN.ListarGasto(objEN)

            'Me.tool.Items(3).Enabled = Me.dgvGenerarGastoConsulta.Rows.Count > 0
            TotalGastoVariable(1)

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ConsultarGastoDetalle(ByVal id As Integer)
        Try
            Cursor = Cursors.WaitCursor
            Dim objEN As New Cls_Gasto_EN
            objEN.ID = id

            Dim objLN As New Cls_Gasto_LN
            Me.dgvGenerarGastoConsulta.DataSource = objLN.ListarGasto(id)

            'Me.tool.Items(3).Enabled = Me.dgvGenerarGastoConsultaCab.Rows.Count > 0
            TotalGastoVariable(1)

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click
        If tabGasto.SelectedTab Is tabGasto.TabPages("tabRepartir") Then
            If tabReparto.SelectedTab Is tabReparto.TabPages("tabLista") Then
                Dim dlgRespuesta As DialogResult
                dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvLista.CurrentRow.Cells("numero").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = vbYes Then
                    AnularSolicitud()
                    ListarSolicitudReparto()
                End If
            ElseIf tabReparto.SelectedTab Is tabReparto.TabPages("tabGenerarGasto") Then
                Dim dlgRespuesta As DialogResult
                dlgRespuesta = MessageBox.Show("¿Está seguro de anular el Cálculo de Gastos " & Chr(13) & Chr(13) & "De: " & Me.dtpFechaInicio2.Value.ToShortDateString & " A: " & Me.dtpFechaFin2.Value.ToShortDateString & "?", "Gastos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    AnularGasto()
                End If
            End If
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabFz") Then
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvListaSolicitud.CurrentRow.Cells("numero_solicitud").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = vbYes Then
                Anular()
                ListarSolicitud()
                'If Me.dgvListaSolicitud.Rows.Count > 0 Then
                'Me.btnModificarZona.Enabled = dgvSolicitudZona.Rows(Me.dgvSolicitudZona.CurrentCell.RowIndex).Cells("idestado").Value = 1
                'Me.btnAnularZona.Enabled = dgvSolicitudZona.Rows(Me.dgvSolicitudZona.CurrentCell.RowIndex).Cells("idestado").Value = 1
                'End If
            End If
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabEstibar") Then
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvListaEstiba.CurrentRow.Cells("numero").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = vbYes Then
                AnularEstiba()
                'ListarEstiba(dtoUSUARIOS.m_idciudad, Me.cboEstadoSolicitudEstiba.SelectedIndex, Me.dgvListaEstiba, Me.dtpInicioEstiba.Value.ToShortDateString, Me.dtpFinEstiba.Value.ToShortDateString)
                ListarEstiba(Me.dgvListaEstiba)
            End If
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabTrasladar") Then
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvListaTraslado.CurrentRow.Cells("numero").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = vbYes Then
                AnularTraslado()
                ListarTraslado(Me.dgvListaEstiba)
            End If
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabEmbalar") Then
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvListaSolicitudEmbalaje.CurrentRow.Cells("numero_solicitud").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = vbYes Then
                AnularEmbalaje()
                ListarSolicitudEmbalaje()
                If Me.dgvListaSolicitud.Rows.Count = 0 Then
                    Me.tsbEditar.Enabled = False
                    Me.tsbAnular.Enabled = False
                    'Me.btnModificarZona.Enabled = dgvSolicitudZona.Rows(Me.dgvSolicitudZona.CurrentCell.RowIndex).Cells("idestado").Value = 1
                    'Me.btnAnularZona.Enabled = dgvSolicitudZona.Rows(Me.dgvSolicitudZona.CurrentCell.RowIndex).Cells("idestado").Value = 1
                End If
            End If
        End If
    End Sub

    Sub AnularSolicitud()
        Try
            Dim objEN As New Cls_Gasto_EN
            objEN.ID = Me.dgvLista.CurrentRow.Cells("id").Value
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            With Me.dgvLista
                Dim obj As New Cls_Gasto_LN
                If .CurrentRow.Cells("id_operacion").Value = 1 Then
                    obj.AnularSolicitud(objEN)
                ElseIf .CurrentRow.Cells("id_operacion").Value = 2 Then
                    obj.AnularSolicitudRecojo(Me.dgvLista.CurrentRow.Cells("id").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                Else
                    obj.AnularSolicitudCabecera(Me.dgvLista.CurrentRow.Cells("id").Value, Me.dgvLista.CurrentRow.Cells("id_rep").Value, _
                                                Me.dgvLista.CurrentRow.Cells("id_rec").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AnularGasto()
        Try
            Dim objEN As New Cls_Gasto_EN
            objEN.Ciudad = dtoUSUARIOS.m_idciudad
            objEN.FechaInicio = Me.dtpFechaInicio2.Value.ToShortDateString
            objEN.FechaFin = Me.dtpFechaFin2.Value.ToShortDateString
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            Dim obj As New Cls_Gasto_LN
            obj.AnularGasto(objEN)
            Me.btnCalcular_Click(Nothing, Nothing)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarRepartoModificacion(ByVal id As Integer, Optional ByVal mixto As Integer = 0)
        Try
            Cursor = Cursors.WaitCursor
            Dim objEN As New Cls_Gasto_EN
            objEN.ID = id
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objEN.Mixto = mixto

            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable = obj.ListarReparto(objEN)
            'Me.dgvReparto.DataSource = dt
            With Me.dgvReparto
                If dt.Rows.Count > 0 Then
                    Dim intFila As Integer
                    For Each row As DataRow In dt.Rows
                        If Not ExisteValorGrid(Me.dgvReparto, 0, row.Item("id_reparto")) Then
                            .Rows.Add()
                            intFila = .Rows.Count - 1
                            .Rows(intFila).Cells("id_reparto").Value = row.Item("id_reparto")
                            .Rows(intFila).Cells("movil").Value = row.Item("movil")
                            .Rows(intFila).Cells("responsable").Value = row.Item("responsable")
                            .Rows(intFila).Cells("hora_salida").Value = row.Item("hora_salida")
                            .Rows(intFila).Cells("fecha_inicio").Value = row.Item("fecha_inicio")
                            .Rows(intFila).Cells("fecha_fin").Value = row.Item("fecha_fin")
                            .Rows(intFila).Cells("produccion").Value = row.Item("produccion")
                            .Rows(intFila).Cells("peso").Value = row.Item("peso")
                            .Rows(intFila).Cells("cantidad").Value = row.Item("cantidad")
                            .Rows(intFila).Cells("direccion").Value = 0 'row.Item("direccion")
                            .Rows(intFila).Cells("id_responsable").Value = row.Item("id_responsable")
                        End If
                    Next
                End If
            End With
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarHojaRuta(ByVal ciudad As Integer, ByVal fecha As String, ByVal responsable As Integer, ByVal dgv As DataGridView)
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable = obj.ListarHojaRuta(ciudad, fecha, responsable)
            dgv.DataSource = dt

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarReparto(ByVal id As Integer)
        Try
            Cursor = Cursors.WaitCursor
            Dim dtReparto As DataTable
            Dim objEN As New Cls_Gasto_EN
            Dim intID As Integer = id

            objEN.ID = intID
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable, dt2 As DataTable
            If Me.dgvLista.CurrentRow.Cells("id_operacion").Value = 1 Then
                grbRepartoGasto.Text = "Reparto"
                grbRepartoGasto.Height = 300
                grbRecojoGasto.Visible = False
                dt = obj.ListarReparto(objEN)
                Me.dgvRepartoGasto.DataSource = dt
            ElseIf Me.dgvLista.CurrentRow.Cells("id_operacion").Value = 2 Then
                grbRepartoGasto.Text = "Recojo"
                grbRepartoGasto.Height = 300
                grbRecojoGasto.Visible = False
                dt = ListarRecojoDetalle(intID, Me.dgvLista.CurrentRow.Cells("formato").Value)
                Me.dgvRepartoGasto.DataSource = dt
                If Me.dgvLista.CurrentRow.Cells("formato").Value = 0 Then
                    ConfigurarDGVRecojoAprobacion(1, Me.dgvRepartoGasto)
                Else
                    ConfigurarDGVRecojoAprobacion(2, Me.dgvRepartoGasto)
                End If
            Else
                grbRepartoGasto.Text = "Reparto"
                grbRepartoGasto.Height = 300
                grbRepartoGasto.Height = 147
                grbRecojoGasto.Visible = True

                'reparto
                intID = Me.dgvLista.CurrentRow.Cells("id_rep").Value
                objEN.ID = intID
                dt = obj.ListarReparto(objEN)
                Me.dgvRepartoGasto.DataSource = dt

                dtReparto = obj.RecuperarReparto(intID)
                If dtReparto.Rows.Count > 0 Then
                    Me.lblTiempo1Gasto.Text = Format(dtReparto.Rows(0).Item("tiempo1"), "###,###,###0.00")
                    Me.lblTiempo2Gasto.Text = Format(dtReparto.Rows(0).Item("tiempo2"), "###,###,###0.00")
                End If

                'recojo
                intID = Me.dgvLista.CurrentRow.Cells("id_rec").Value
                objEN.ID = intID
                dt2 = ListarRecojoDetalle(intID, Me.dgvLista.CurrentRow.Cells("formato").Value)
                Me.dgvRecojoGasto.DataSource = dt2
                If Me.dgvLista.CurrentRow.Cells("formato").Value = 0 Then
                    ConfigurarDGVRecojoAprobacion(1, Me.dgvRecojoGasto)
                Else
                    ConfigurarDGVRecojoAprobacion(2, Me.dgvRecojoGasto)
                End If
            End If

            Dim intCantidadGasto As Integer
            Dim dblPesoGasto As Double
            Dim dblPesoGastoReparto As Double
            intCantidadGasto = IIf(IsDBNull(dt.Compute("sum(cantidad)", "")), 0, dt.Compute("sum(cantidad)", ""))
            dblPesoGasto = IIf(IsDBNull(dt.Compute("sum(peso)", "")), 0, dt.Compute("sum(peso)", ""))
            dblPesoGastoReparto = dblPesoGasto

            If Not IsNothing(dt2) Then
                dblPesoGasto += IIf(IsDBNull(dt2.Compute("sum(peso)", "")), 0, dt2.Compute("sum(peso)", ""))
                intCantidadGasto += IIf(IsDBNull(dt2.Compute("sum(cantidad)", "")), 0, dt2.Compute("sum(cantidad)", ""))
            End If

            Me.lblCantidadGasto.Text = Format(intCantidadGasto, "###,###,###0.00")
            Me.lblPesoGasto.Text = Format(dblPesoGasto, "###,###,###0.00")

            Me.txtObservacionAprobacionGasto.Text = IIf(IsDBNull(Me.dgvLista.CurrentRow.Cells("observacion").Value), "", Me.dgvLista.CurrentRow.Cells("observacion").Value)

            Dim dblPeso As Double = Me.lblPesoGasto.Text
            Dim dblTiempo As Double = Me.lblTiempo1Gasto.Text
            Dim dblPesoHora As Double = IIf(dblTiempo = 0, 0, dblPeso / dblTiempo)
            Me.lblPesoHora.Text = Format(dblPesoHora, "###,###,###0.00")

            Dim dblSoles As Double = Me.lblMontoGasto.Text
            Dim dblSolesKg As Double = dblSoles / IIf(dblPeso = 0, 1, dblPeso)
            Me.lblSolesKg.Text = Format(dblSolesKg, "###,###,###0.00")

            'Dim intCantidad As Integer = IIf(IsDBNull(dt.Compute("sum(cantidad)", "")), 0, dt.Compute("sum(cantidad)", ""))
            Dim intPuntosEntrega As Integer = Me.dgvLista.CurrentRow.Cells("direccion").Value
            Dim dblEntregaHora As Double = intPuntosEntrega / IIf(dblTiempo = 0, 1, dblTiempo)
            Me.lblEntregaHora.Text = Format(dblEntregaHora, "###,###,###0.00")

            Dim dblTotal As Double = IIf(IsDBNull(dt.Compute("sum(total)", "")), 0, dt.Compute("sum(total)", ""))
            If Not IsNothing(dt2) Then
                dblTotal += IIf(IsDBNull(dt2.Compute("sum(total)", "")), 0, dt2.Compute("sum(total)", ""))
            End If

            Me.lblSobreCobrado.Text = Format(IIf(dblTotal = 0, 0, dblSoles / dblTotal * 100), "###,###,###0.00")
            Me.lblCobrado.Text = Format(dblTotal, "###,###,###0.00")

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ObtieneTipoPago() As Integer
        If Me.chkReparto.Checked Then
            If Not Me.chkTipoPagoAdicional.Checked Then
                If Val(Me.lblTipoPago.Tag) = 0 Then
                    Return 0
                Else
                    Return Me.lblTipoPago.Tag
                End If
            Else
                Return 10
            End If
        ElseIf Me.chkRecojo.Checked Then
            Return 10
        Else
            If Val(Me.lblTipoPago.Tag) = 0 Then
                Return 0
            Else
                Return Me.lblTipoPago.Tag
            End If
        End If
    End Function

    Sub ListarReparto()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN
            Dim dt As New DataTable
            Dim objEN As New Cls_Gasto_EN
            objEN.Ciudad = dtoUSUARIOS.m_idciudad
            objEN.FechaInicio = Me.dtpFechaOperacion.Value.ToShortDateString
            objEN.TipoGasto = ObtieneTipoPago() 'Me.lblTipoPago.Tag 
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            If Me.chkTipoPagoAdicional.Checked Then
                With Me.dgvReparto
                    objEN.Responsable = IIf(Me.cboResponsable.SelectedIndex > 0, Me.cboResponsable.SelectedValue, 0)
                    If Me.cboHoraSalida.Items.Count > 1 Then
                        objEN.Reparto = IIf(Me.cboHoraSalida.SelectedValue = 0, -1, Me.cboHoraSalida.SelectedValue)
                    Else
                        objEN.Reparto = -1
                    End If
                    Dim intOpcion As Integer
                    intOpcion = IIf(Me.dgvReparto.Rows.Count = 0, 1, 2)
                    dt = obj.ListarHojaRuta(objEN, intOpcion)
                End With
            Else
                objEN.Responsable = IIf(Me.cboResponsable.SelectedIndex > 0, Me.cboResponsable.SelectedValue, 0)
                objEN.Reparto = 0
                dt = obj.ListarHojaRuta(objEN, 0)
            End If

            'Me.dgvReparto.DataSource = dt
            With Me.dgvReparto
                If dt.Rows.Count > 0 Then
                    Dim intFila As Integer
                    For Each row As DataRow In dt.Rows
                        If Not ExisteValorGrid(Me.dgvReparto, 0, row.Item("id_reparto")) Then
                            .Rows.Add()
                            intFila = .Rows.Count - 1
                            .Rows(intFila).Cells("id_reparto").Value = row.Item("id_reparto")
                            .Rows(intFila).Cells("movil").Value = row.Item("movil")
                            .Rows(intFila).Cells("responsable").Value = row.Item("responsable")
                            .Rows(intFila).Cells("hora_salida").Value = row.Item("hora_salida")
                            .Rows(intFila).Cells("fecha_inicio").Value = row.Item("fecha_inicio")
                            .Rows(intFila).Cells("fecha_fin").Value = row.Item("fecha_fin")
                            .Rows(intFila).Cells("produccion").Value = row.Item("produccion")
                            .Rows(intFila).Cells("peso").Value = IIf(row.Item("peso") = 0, 0.5, row.Item("peso"))
                            .Rows(intFila).Cells("cantidad").Value = row.Item("cantidad")
                            .Rows(intFila).Cells("direccion").Value = row.Item("direccion")
                        End If
                    Next
                End If
            End With

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub InicializarMenu()
        tool.Items(0).Visible = True : tool.Items(1).Visible = True : tool.Items(2).Visible = True : tool.Items(3).Visible = True
        tool.Items(0).Enabled = True : tool.Items(1).Enabled = True : tool.Items(2).Enabled = True : tool.Items(3).Enabled = True

        Dim obj As New Cls_Gasto_LN
        With Me.cboCiudadReparto
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarCiudad(1)
            If intNivel = 1 Or intNivel = 4 Or intNivel = 5 Then
                .SelectedValue = dtoUSUARIOS.m_idciudad
                .Enabled = False
            Else
                .SelectedValue = 0
                .Enabled = True
            End If
        End With
    End Sub

    Sub ActualizarReparto()
        Dim dblTiempo As Double = 0, dblPeso As Double = 0, intCantidad As Integer = 0, dblSoles As Double = 0, dblSpkg As Double = 0
        With dgvReparto
            If .Rows.Count > 0 Then
                For Each row As DataGridViewRow In .Rows
                    dblTiempo += IIf(IsDBNull(row.Cells("produccion").Value), 0, row.Cells("produccion").Value)
                    dblPeso += IIf(IsDBNull(row.Cells("peso").Value), 0, row.Cells("peso").Value)
                    intCantidad += IIf(IsDBNull(row.Cells("cantidad").Value), 0, row.Cells("cantidad").Value)
                Next
            End If
        End With
        With dgvRecojo
            If .Rows.Count > 0 Then
                For Each row As DataGridViewRow In .Rows
                    'dblTiempo += IIf(IsDBNull(row.Cells("produccion").Value), 0, row.Cells("produccion").Value)
                    dblPeso += IIf(IsDBNull(row.Cells("peso").Value), 0, row.Cells("peso").Value)
                    intCantidad += IIf(IsDBNull(row.Cells("cantidad").Value), 0, row.Cells("cantidad").Value)
                Next
            End If
        End With
        Me.lblPesoSolicitud.Text = Format(dblPeso, "0.00")
        Me.lblBultoSolicitud.Text = intCantidad
        'Me.lblEntregaSolicitud.Text = Format(intCantidad / IIf(dblTiempo = 0, 1, dblTiempo), "0.00")

        Dim intPuntosEntrega As Integer
        If Me.chkReparto.Checked Then
            If intOperacion = Operacion.Modificar Then
                intPuntosEntrega = Me.dgvLista.CurrentRow.Cells("direccion").Value
            Else
                If Me.dgvReparto.Rows.Count > 0 Then
                    intPuntosEntrega = Me.dgvReparto.Rows(0).Cells("direccion").Value
                Else
                    intPuntosEntrega = 0
                End If
            End If
        End If

        Dim dblEntregaHora As Double = intPuntosEntrega / IIf(dblTiempo = 0, 1, dblTiempo)
        Me.lblEntregaSolicitud.Text = Format(dblEntregaHora, "###,###,###0.00")

        Me.lblSpkgSolicitud.Text = Format(IIf(Me.lblMontoCiudad.Text = "", 0, Me.lblMontoCiudad.Text) / IIf(dblPeso = 0, 1, dblPeso), "0.00")

        Me.lblTiempoSugerido.Text = Format(dblTiempo, "0.00")
        'Me.txtTiempoCiudad.Focus()
    End Sub

    Private Sub txtTiempoOficina_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTiempoCiudad.Enter
        txtTiempoCiudad.SelectAll()
    End Sub

    Private Sub txtTiempoOficina_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTiempoCiudad.GotFocus
        txtTiempoCiudad.SelectAll()
    End Sub

    Private Sub txtTiempoOficina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTiempoCiudad.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtTiempoCiudad.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTiempoOficina_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTiempoCiudad.LostFocus
        If Val(Me.txtTiempoCiudad.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtTiempoCiudad.Text)
            Me.txtTiempoCiudad.Text = Format(dblMonto, "0.00")
        Else
            Me.txtTiempoCiudad.Text = ""
        End If
    End Sub
    Private Sub txtObservacionReparto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacionReparto.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtObservacionReparto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacionReparto.KeyPress
        If intNivel = 1 Or intNivel = 4 Then
            If Asc(e.KeyChar) = Keys.Enter Then
                e.Handled = True
                'GrabarSolicitudReparto()
                Me.chkReparto.Focus()
            End If
        End If
    End Sub

    Function ObtieneSalidaBus() As Integer
        Try
            Dim intSalida As Integer = 0, blnExiste As Boolean = False
            For j As Integer = 0 To Me.dgvReparto.Rows.Count - 1
                intSalida += 1
                For i As Integer = j + 1 To Me.dgvReparto.Rows.Count - 1
                    If Me.dgvReparto.Rows(j).Cells("movil").Value = Me.dgvReparto.Rows(i).Cells("movil").Value Then
                        intSalida -= 1
                        Exit For
                    End If
                Next
            Next
            Return intSalida
        Catch
            Return 0
        End Try
    End Function

    Private Sub txtTiempoOficina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTiempoCiudad.TextChanged
        Dim dblTiempoOficina As Double, dblTarifaOficina As Double, dblMontoGasto As Double

        dblTiempoOficina = IIf(Val(Me.txtTiempoCiudad.Text) = 0, 0, Me.txtTiempoCiudad.Text)
        dblTarifaOficina = Me.lblTarifaCiudad.Text
        If ObtieneTipoPago() = intTipoGasto.Hora Then 'Me.lblTipoPago.Tag = 2 Then
            dblMontoGasto = dblTiempoOficina * dblTarifaOficina
        ElseIf ObtieneTipoPago() = intTipoGasto.Dia Then
            'dblMontoGasto = Me.dgvReparto.Rows.Count * dblTarifaOficina
            'dblMontoGasto = ObtieneSalidaBus() * dblTarifaOficina
            dblMontoGasto = dblTarifaOficina
        ElseIf ObtieneTipoPago() = intTipoGasto.Peso Then
            If Me.dgvReparto.Rows.Count = 1 Then
                dblMontoGasto = Me.dgvReparto.Rows(0).Cells("peso").Value * dblTarifaOficina
            Else
                dblMontoGasto = 0
            End If
        Else
            dblMontoGasto = dblTiempoOficina
        End If
        Me.lblMontoCiudad.Text = Format(dblMontoGasto, "0.00")

        If dblTiempoOficina = 0 Then dblTiempoOficina = 1

        If ObtieneTipoPago() <> intTipoGasto.Adicional Then
            Dim intPuntosEntrega As Integer
            If intOperacion = Operacion.Modificar Then
                intPuntosEntrega = Me.dgvLista.CurrentRow.Cells("direccion").Value
            Else
                If Me.dgvReparto.Rows.Count > 0 Then
                    intPuntosEntrega = Me.dgvReparto.Rows(0).Cells("direccion").Value
                Else
                    intPuntosEntrega = 0
                End If
            End If
            Me.lblEntregaSolicitud.Text = Format(intPuntosEntrega / IIf(dblTiempoOficina = 0, 1, dblTiempoOficina), "0.00")
        End If
        Me.lblSpkgSolicitud.Text = Format(Me.lblMontoCiudad.Text / IIf(Val(Me.lblPesoSolicitud.Text) = 0, 1, Me.lblPesoSolicitud.Text), "0.00")

        TotalRepartoRecojo()
    End Sub

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        intOperacion = Operacion.Nuevo

        If tabGasto.SelectedTab Is tabGasto.TabPages("tabRepartir") Then
            intModo = 1
            Me.chkReparto.Enabled = True
            Me.chkRecojo.Enabled = True

            Me.lblPesoSolicitud.Text = "0.00"
            Me.lblBultoSolicitud.Text = "0.00"
            Me.lblEntregaSolicitud.Text = "0.00"
            Me.lblSpkgSolicitud.Text = "0.00"

            Me.rbtComprobanteRecojo.Enabled = True
            Me.rbtGrtRecojo.Enabled = True
            Me.grbRecojoComprobante.Enabled = True
            Me.grbRecojoGrt.Enabled = True
            Me.btnAgregarRecojo.Enabled = True

            LimpiarSolicitudReparto()
            Me.dtpFechaOperacion.Value = Me.lblFechaReparto.Text
            dtpFechaOperacion_ValueChanged(Nothing, Nothing)
            Me.lblSolicitanteReparto.Text = dtoUSUARIOS.NameLogin

            TipoGasto()

            Me.tsbNuevo.Enabled = False : Me.tsbEditar.Enabled = False : Me.tsbGrabar.Enabled = True : Me.tsbAnular.Enabled = False
            Me.dtpFechaOperacion.Enabled = True
            Me.txtTiempoCiudad.Enabled = True
            Me.txtObservacionReparto.Enabled = True

            Me.txtRucProveedorReparto.Enabled = True
            Me.txtRazonSocialProveedorReparto.Enabled = True

            RemoveHandler tabReparto.SelectedIndexChanged, AddressOf tabReparto_SelectedIndexChanged
            tabReparto.SelectedIndex = 1
            AddHandler tabReparto.SelectedIndexChanged, AddressOf tabReparto_SelectedIndexChanged
            Me.dtpFechaOperacion.Focus()

        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabFz") Then
            LimpiarSolicitud()
            Me.lblNumeroSolicitud.Text = dtoFueraZona.ObtieneNumeroSolicitud(dtoUSUARIOS.iIDAGENCIAS)
            Me.lblSolicitante.Text = dtoUSUARIOS.NameLogin

            Me.dtpFechaFueraZona.Enabled = True
            Me.txtCodigoCliente.Enabled = True
            Me.txtCliente.Enabled = True
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbGrabar.Enabled = True
            Me.tsbAnular.Enabled = False

            Me.txtCosto.Enabled = True
            Me.txtKilometro.Enabled = True
            Me.txtHora.Enabled = True
            Me.txtLocalidad.Enabled = True
            Me.txtObservacion.Enabled = True
            Me.btnAgregarGE.Enabled = True
            Me.btnEliminarGE.Enabled = False
            Me.dgvGuiaEnvio.Enabled = True
            Me.tsbGrabar.Enabled = True

            Me.txtRucProveedorFueraZona.Enabled = True
            Me.txtRazonSocialProveedorFueraZona.Enabled = True

            If intNivel <> 1 And intNivel <> 4 Then
                Me.dtpFechaFueraZona.Enabled = False
                Me.txtCodigoCliente.Enabled = False
                Me.txtCliente.Enabled = False
                Me.txtCosto.Enabled = False
                Me.txtKilometro.Enabled = False
                Me.txtHora.Enabled = False
                Me.txtLocalidad.Enabled = False
                Me.txtObservacion.Enabled = False
                Me.btnAgregarGE.Enabled = False
                Me.btnEliminarGE.Enabled = False
                Me.dgvGuiaEnvio.Enabled = False
                Me.tsbGrabar.Enabled = False
            End If

            RemoveHandler tabFueraZona.SelectedIndexChanged, AddressOf tabFueraZona_SelectedIndexChanged
            Me.tabFueraZona.SelectedTab = Me.tabFueraZona.TabPages("tabSolicitudZona")
            AddHandler tabFueraZona.SelectedIndexChanged, AddressOf tabFueraZona_SelectedIndexChanged
            Me.dtpFechaFueraZona.Focus()
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabEstibar") Then
            Me.lblPesoEstiba.Text = "0.00"
            Me.lblCantidadEstiba.Text = "0.00"

            LimpiarSolicitudEstiba()
            Me.dtpFechaOperacionEstiba.Value = Me.lblFechaEstiba.Text
            Me.lblSolicitanteEstiba.Text = dtoUSUARIOS.NameLogin

            Me.tsbNuevo.Enabled = False : Me.tsbEditar.Enabled = False : Me.tsbGrabar.Enabled = True : Me.tsbAnular.Enabled = False
            Me.dtpFechaOperacionEstiba.Enabled = True

            Me.txtMontoEstiba.Enabled = True
            Me.txtObservacionEstiba.Enabled = True
            Me.dtpFechaOperacionEstiba.Enabled = True
            Me.txtRucProveedor.Enabled = True
            Me.txtRazonSocialProveedor.Enabled = True

            Me.txtGrtEstiba.Enabled = True
            Me.btnAgregarEstiba.Enabled = True
            Me.btnQuitarGrt.Enabled = False

            Me.dtpHoraInicioEstiba.Enabled = True
            Me.dtpHoraFinEstiba.Enabled = True

            Me.cboTipoOperacionEstiba.Enabled = True
            Me.txtNumeroEstiba.Enabled = True

            RemoveHandler tabEstiba.SelectedIndexChanged, AddressOf tabEstiba_SelectedIndexChanged
            tabEstiba.SelectedIndex = 1
            AddHandler tabEstiba.SelectedIndexChanged, AddressOf tabEstiba_SelectedIndexChanged
            Me.dtpFechaOperacionEstiba.Focus()
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabTrasladar") Then
            Me.lblPesoTraslado.Text = "0.00"
            Me.lblCantidadTraslado.Text = "0.00"

            LimpiarSolicitudTraslado()
            Me.dtpFechaOperacionTraslado.Value = Me.lblfechaTraslado.Text
            Me.lblSolicitanteTraslado.Text = dtoUSUARIOS.NameLogin

            Me.tsbNuevo.Enabled = False : Me.tsbEditar.Enabled = False : Me.tsbGrabar.Enabled = True : Me.tsbAnular.Enabled = False
            Me.dtpFechaOperacionTraslado.Enabled = True

            Me.txtMontoTraslado.Enabled = True
            Me.txtObservacionTraslado.Enabled = True
            Me.dtpFechaOperacionTraslado.Enabled = True
            Me.txtRucProveedorTraslado.Enabled = True
            Me.txtRazonSocialProveedorTraslado.Enabled = True

            Me.txtGrtTraslado.Enabled = True
            Me.btnAgregarTraslado.Enabled = True
            Me.btnQuitarGrtTraslado.Enabled = False

            RemoveHandler tabTraslado.SelectedIndexChanged, AddressOf tabTraslado_SelectedIndexChanged
            tabTraslado.SelectedIndex = 1
            AddHandler tabTraslado.SelectedIndexChanged, AddressOf tabTraslado_SelectedIndexChanged
            Me.dtpFechaOperacionTraslado.Focus()
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabEmbalar") Then
            LimpiarSolicitudEmbalaje()
            Me.lblNumeroSolicitudEmbalaje.Text = dtoFueraZona.ObtieneNumeroSolicitudEmbalaje(dtoUSUARIOS.iIDAGENCIAS)
            Me.lblSolicitanteEmbalaje.Text = dtoUSUARIOS.NameLogin

            Me.dtpFechaEmbalaje.Enabled = True
            Me.txtCodigoClienteEmbalaje.Enabled = True
            Me.txtClienteEmbalaje.Enabled = True
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbGrabar.Enabled = True
            Me.tsbAnular.Enabled = False

            Me.txtCostoEmbalaje.Enabled = True
            'Me.txtKilometro.Enabled = True
            'Me.txtHora.Enabled = True
            'Me.txtLocalidad.Enabled = True
            Me.txtObservacionEmbalaje.Enabled = True
            Me.btnAgregarGEEmbalaje.Enabled = True
            Me.btnEliminarGEEmbalaje.Enabled = False
            Me.dgvGuiaEnvioEmbalaje.Enabled = True
            Me.tsbGrabar.Enabled = True

            Me.txtRucProveedorEmbalaje.Enabled = True
            Me.txtRazonSocialProveedorEmbalaje.Enabled = True

            If intNivel <> 1 And intNivel <> 4 Then
                Me.dtpFechaEmbalaje.Enabled = False
                Me.txtCodigoClienteEmbalaje.Enabled = False
                Me.txtClienteEmbalaje.Enabled = False
                Me.txtCostoEmbalaje.Enabled = False
                'Me.txtKilometro.Enabled = False
                'Me.txtHora.Enabled = False
                'Me.txtLocalidad.Enabled = False
                Me.txtObservacionEmbalaje.Enabled = False
                Me.btnAgregarGEEmbalaje.Enabled = False
                Me.btnEliminarGEEmbalaje.Enabled = False
                Me.dgvGuiaEnvioEmbalaje.Enabled = False
                Me.tsbGrabar.Enabled = False
            End If

            RemoveHandler tabEmbalaje.SelectedIndexChanged, AddressOf tabEmbalaje_SelectedIndexChanged
            Me.tabEmbalaje.SelectedTab = Me.tabEmbalaje.TabPages("tabSolicitudEmbalaje")
            AddHandler tabEmbalaje.SelectedIndexChanged, AddressOf tabEmbalaje_SelectedIndexChanged
            Me.dtpFechaEmbalaje.Focus()
        End If
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        If tabGasto.SelectedTab Is tabGasto.TabPages("tabRepartir") Then
            If tabReparto.TabPages.IndexOf(tabSolicitudReparto) > -1 Then
                intModo = 2
                intOperacion = Operacion.Modificar

                Me.tsbNuevo.Enabled = False : Me.tsbEditar.Enabled = False : Me.tsbGrabar.Enabled = Me.dgvLista.CurrentRow.Cells("id_estado").Value = 1
                Me.tsbAnular.Enabled = False
                LimpiarSolicitudReparto()

                MostrarSolicitudReparto(dgvLista.CurrentCell.RowIndex)

                Me.dtpFechaOperacion.Enabled = False
                Me.chkTipoPagoAdicional.Enabled = False
                Me.cboResponsable.Enabled = False
                Me.cboHoraSalida.Enabled = False
                Me.btnAgregarReparto.Enabled = False
                Me.btnQuitarReparto.Enabled = False

                Me.grbZonaReparto.Enabled = True

                Me.tabReparto.SelectedTab = Me.tabReparto.TabPages("tabSolicitar")
                Me.txtTiempoCiudad.Focus()
                Me.txtTiempoCiudad.SelectAll()
                intModo = 1
            Else
                Me.tabReparto.SelectedTab = Me.tabReparto.TabPages("tabAprobar")
            End If
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabFz") Then
            If tabFueraZona.TabPages.IndexOf(tabSolicitud) > -1 Then
                intOperacion = Operacion.Modificar
                MostrarSolicitud(dgvListaSolicitud.CurrentCell.RowIndex)

                Dim intID As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("id").Value
                ListarGuiaEnvio(intID, Me.dgvGuiaEnvio)

                Me.dtpFechaFueraZona.Enabled = False
                Me.txtCodigoCliente.Enabled = False
                Me.txtCliente.Enabled = False

                Me.tabFueraZona.SelectedTab = Me.tabFueraZona.TabPages("tabSolicitudZona")
                Me.txtCosto.Focus()
            ElseIf tabFueraZona.TabPages.IndexOf(tabAceptacion) > -1 Then
                Me.tabFueraZona.SelectedTab = Me.tabFueraZona.TabPages("tabAceptacionZona")
            ElseIf tabFueraZona.TabPages.IndexOf(tabAprobacion) > -1 Then
                Me.tabFueraZona.SelectedTab = Me.tabFueraZona.TabPages("tabAprobacionZona")
            End If
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabEstibar") Then
            If tabEstiba.TabPages.IndexOf(tabSolicitudEstiba) > -1 Then
                intOperacion = Operacion.Modificar

                Me.tsbNuevo.Enabled = False : Me.tsbEditar.Enabled = False : Me.tsbGrabar.Enabled = Me.dgvListaEstiba.CurrentRow.Cells("id_estado").Value = 1
                Me.tsbAnular.Enabled = False

                MostrarSolicitudEstiba(dgvListaEstiba.CurrentCell.RowIndex)

                Me.tabEstiba.SelectedTab = Me.tabEstiba.TabPages("tabSolicitudEstiba")
                Me.dtpFechaOperacionEstiba.Focus()
                Me.dtpFechaOperacionEstiba.Enabled = False
            Else
                Me.tabEstiba.SelectedTab = Me.tabEstiba.TabPages("tabAprobacionEstiba")
            End If
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabTrasladar") Then
            If tabTraslado.TabPages.IndexOf(tabSolicitudTraslado) > -1 Then
                intOperacion = Operacion.Modificar

                Me.tsbNuevo.Enabled = False : Me.tsbEditar.Enabled = False : Me.tsbGrabar.Enabled = Me.dgvListaTraslado.CurrentRow.Cells("id_estado").Value = 1
                Me.tsbAnular.Enabled = False

                MostrarSolicitudTraslado(dgvListaTraslado.CurrentCell.RowIndex)

                Me.tabTraslado.SelectedTab = Me.tabTraslado.TabPages("tabSolicitudTraslado")
                Me.dtpFechaOperacionTraslado.Focus()
                Me.dtpFechaOperacionTraslado.Enabled = False
            Else
                Me.tabTraslado.SelectedTab = Me.tabTraslado.TabPages("tabAprobacionTraslado")
            End If
        ElseIf tabGasto.SelectedTab Is tabGasto.TabPages("tabEmbalar") Then
            If tabEmbalaje.TabPages.IndexOf(tabSolicitudEmbalaje) > -1 Then
                intOperacion = Operacion.Modificar
                MostrarSolicitudEmbalaje(dgvListaSolicitudEmbalaje.CurrentCell.RowIndex)

                Dim intID As Integer = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("id").Value
                ListarGuiaEnvioEmbalaje(intID, Me.dgvGuiaEnvioEmbalaje)

                Me.dtpFechaEmbalaje.Enabled = False
                Me.txtCodigoClienteEmbalaje.Enabled = False
                Me.txtClienteEmbalaje.Enabled = False

                Me.tabEmbalaje.SelectedTab = Me.tabEmbalaje.TabPages("tabSolicitudEmbalaje")
                Me.txtCostoEmbalaje.Focus()
            ElseIf tabEmbalaje.TabPages.IndexOf(tabAceptacionEmbalaje) > -1 Then
                Me.tabEmbalaje.SelectedTab = Me.tabEmbalaje.TabPages("tabAceptacionEmbalaje")
            ElseIf tabEmbalaje.TabPages.IndexOf(tabAprobacionEmbalaje) > -1 Then
                Me.tabEmbalaje.SelectedTab = Me.tabEmbalaje.TabPages("tabAprobacionEmbalaje")
            End If
        End If
    End Sub

    Sub Distribuir()
        Dim intTipoPago = ObtieneTipoPago()
        If intTipoPago > 0 Then
            If intTipoPago = 10 Then 'adicional
                Me.lblTiempo.Visible = True : Me.lblTiempoSugerido.Visible = True : Me.lblTiempoCiudad.Visible = True : txtTiempoCiudad.Visible = True
                Me.lblTarifa.Left = 464 : Me.lblTarifaCiudad.Left = 533 : Me.lblMonto.Left = 712 : Me.lblMontoCiudad.Left = 748
                Me.lblTiempoCiudad.Text = "Monto"
                txtTiempoOficina_TextChanged(Nothing, Nothing)
            ElseIf intTipoPago = intTipoGasto.Hora Then
                Me.lblTiempo.Visible = True : Me.lblTiempoSugerido.Visible = True : Me.lblTiempoCiudad.Visible = True : txtTiempoCiudad.Visible = True
                Me.lblTarifa.Left = 464 : Me.lblTarifaCiudad.Left = 533 : Me.lblMonto.Left = 712 : Me.lblMontoCiudad.Left = 748
                txtTiempoOficina_TextChanged(Nothing, Nothing)
            Else
                Me.lblTiempo.Visible = True : Me.lblTiempoSugerido.Visible = True : Me.lblTiempoCiudad.Visible = False : txtTiempoCiudad.Visible = False
                Me.lblTarifa.Left = 190 : Me.lblTarifaCiudad.Left = 270 : Me.lblMonto.Left = 500 : Me.lblMontoCiudad.Left = 570
                'Me.txtTiempoCiudad.Text = "0.00"
                txtTiempoOficina_TextChanged(Nothing, Nothing)
            End If
        End If
    End Sub

    Sub MostrarSolicitudReparto(ByVal row As Integer)
        With dgvLista
            Me.lblNumeroSolicitudReparto.Text = .Rows(row).Cells("numero").Value
            Me.lblFechaReparto.Text = .Rows(row).Cells("fecha_solicitud").Value
            Me.lblCiudad.Text = .Rows(row).Cells("ciudad").Value
            Me.lblSolicitanteReparto.Text = .Rows(row).Cells("solicitante").Value
            Me.txtObservacionReparto.Text = IIf(IsDBNull(.Rows(row).Cells("observacion").Value), "", .Rows(row).Cells("observacion").Value)

            RemoveHandler dtpFechaOperacion.ValueChanged, AddressOf dtpFechaOperacion_ValueChanged
            Me.dtpFechaOperacion.Value = .Rows(row).Cells("fecha_operacion").Value
            AddHandler dtpFechaOperacion.ValueChanged, AddressOf dtpFechaOperacion_ValueChanged

            'TipoGasto()

            Me.lblTipoPago.Text = .Rows(row).Cells("tipo").Value
            Me.lblTipoPago.Tag = .Rows(row).Cells("tipo_gasto").Value

            Me.lblTarifaCiudad.Text = Format(IIf(IsDBNull(.Rows(row).Cells("tarifa_oficina").Value), 0, .Rows(row).Cells("tarifa_oficina").Value), "###,###,###0.00")
            Me.lblMontoCiudad.Text = Format(.Rows(row).Cells("monto").Value, "###,###,###0.00")
            Me.lblTiempoSugerido.Text = Format(.Rows(row).Cells("tiempo1").Value, "###,###,###0.00")

            Me.txtRucProveedorReparto.Text = IIf(IsDBNull(.CurrentRow.Cells("ruc").Value), "", .CurrentRow.Cells("ruc").Value)
            If Not IsDBNull(.CurrentRow.Cells("id_proveedor").Value) Then
                Me.txtRucProveedorReparto.Tag = IIf(.CurrentRow.Cells("id_proveedor").Value = 0, "", (.CurrentRow.Cells("id_proveedor").Value))
            Else
                Me.txtRucProveedorReparto.Tag = 0
            End If
            Me.txtRazonSocialProveedorReparto.Text = IIf(IsDBNull(.CurrentRow.Cells("proveedor").Value), "", .CurrentRow.Cells("proveedor").Value)
            Me.txtRazonSocialProveedorReparto.Enabled = False

            Me.lblPesoSolicitud.Text = Format(.Rows(row).Cells("peso").Value, "0.00")
            Me.lblBultoSolicitud.Text = Format(.Rows(row).Cells("cantidad").Value, "0.00")

            Me.chkReparto.Enabled = False
            Me.chkRecojo.Enabled = False
            If .Rows(row).Cells("id_operacion").Value = 1 Then 'reparto
                RemoveHandler chkReparto.CheckedChanged, AddressOf chkReparto_CheckedChanged
                chkReparto.Checked = True
                AddHandler chkReparto.CheckedChanged, AddressOf chkReparto_CheckedChanged
                If .Rows(row).Cells("id_operacion").Value = 1 Then
                    If .Rows(row).Cells("gasto_adicional").Value = 1 Then
                        Me.chkTipoPagoAdicional.Checked = True
                        Me.cboResponsable.SelectedValue = .Rows(row).Cells("responsable_adicional").Value
                        Me.cboHoraSalida.SelectedValue = .Rows(row).Cells("id_reparto").Value
                    Else
                        Me.chkTipoPagoAdicional.Checked = False
                    End If
                    If .Rows(row).Cells("gasto_adicional").Value = 1 Or Me.lblTipoPago.Text = "ADICIONAL" Then
                        Me.txtTiempoCiudad.Text = Format(.Rows(row).Cells("monto").Value, "###,###,###0.00")
                    Else
                        Me.txtTiempoCiudad.Text = Format(.Rows(row).Cells("tiempo2").Value, "###,###,###0.00")
                    End If
                End If
                Dim intID As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
                Dim blnMixto As Boolean = .Rows(row).Cells("id_operacion").Value = 3
                ListarRepartoModificacion(intID, IIf(blnMixto, 1, 0))

            ElseIf .Rows(row).Cells("id_operacion").Value = 2 Then 'recojo
                chkRecojo.Checked = True
                If dgvLista.Rows(row).Cells("formato").Value = 0 Then
                    Me.rbtGrtRecojo.Checked = True
                Else
                    Me.rbtComprobanteRecojo.Checked = True
                End If
                Me.txtTiempoCiudad.Text = Format(.Rows(row).Cells("monto").Value, "###,###,###0.00")
                Me.dgvRecojo.Rows.Clear()
                Dim intID As Integer = .CurrentRow.Cells("id").Value
                Dim obj As New Cls_Gasto_LN
                Dim blnMixto As Boolean = .Rows(row).Cells("id_operacion").Value = 3
                Dim dt As DataTable = obj.ListarRecojoDetalle(intID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, .Rows(row).Cells("formato").Value, IIf(blnMixto, 1, 0))
                Dim intFila As Integer = 0
                For Each row1 As DataRow In dt.Rows
                    intFila += 1
                    AgregarRecojo(dt, Me.dgvRecojo, .Rows(row).Cells("formato").Value, intFila - 1, 1)
                Next
            Else 'ambos
                chkRecojo.Checked = True
                chkReparto.Checked = True
                If dgvLista.Rows(row).Cells("formato").Value = 0 Then
                    Me.rbtGrtRecojo.Checked = True
                Else
                    Me.rbtComprobanteRecojo.Checked = True
                End If
                Me.txtTiempoCiudad.Text = Format(.Rows(row).Cells("monto").Value, "###,###,###0.00")
                Me.dgvRecojo.Rows.Clear()
                Dim intID As Integer = .CurrentRow.Cells("id_rec").Value
                Dim obj As New Cls_Gasto_LN
                Dim blnMixto As Boolean = .Rows(row).Cells("id_operacion").Value = 3
                Dim dt As DataTable = obj.ListarRecojoDetalle(intID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, .Rows(row).Cells("formato").Value, IIf(blnMixto, 1, 0))
                Dim intFila As Integer = 0
                For Each row1 As DataRow In dt.Rows
                    intFila += 1
                    AgregarRecojo(dt, Me.dgvRecojo, .Rows(row).Cells("formato").Value, intFila - 1, 1)
                Next

                intID = Me.dgvLista.CurrentRow.Cells("id_rep").Value
                Dim dtReparto As DataTable = obj.RecuperarReparto(intID)
                If dtReparto.Rows(0).Item("gasto_adicional") = 1 Then
                    Me.chkTipoPagoAdicional.Checked = True
                    Me.cboResponsable.SelectedValue = dtReparto.Rows(0).Item("responsable_adicional")
                    Me.cboHoraSalida.SelectedValue = dtReparto.Rows(0).Item("id_reparto")
                Else
                    Me.chkTipoPagoAdicional.Checked = False
                End If
                If dtReparto.Rows(0).Item("gasto_adicional") = 1 Or Me.lblTipoPago.Text = "ADICIONAL" Then
                    'Me.txtTiempoCiudad.Text = Format(dtReparto.Rows(0).Item("monto"), "###,###,###0.00")
                Else
                    Me.txtTiempoCiudad.Text = Format(dtReparto.Rows(0).Item("tiempo2"), "###,###,###0.00")
                End If
                ListarRepartoModificacion(intID, 1)
            End If

            If .Rows(row).Cells("id_estado").Value = 1 Then
                Me.txtTiempoCiudad.Enabled = True
                Me.txtObservacionReparto.Enabled = True
                Me.txtRucProveedorReparto.Enabled = True
                Me.tsbGrabar.Enabled = True
            Else
                Me.txtTiempoCiudad.Enabled = False
                Me.txtObservacionReparto.Enabled = False
                Me.txtRucProveedorReparto.Enabled = False
                Me.txtRazonSocialProveedorReparto.Enabled = False
                Me.tsbGrabar.Enabled = False
            End If
        End With
        Distribuir()
        ActualizarReparto()
        TotalizarRecojo()
        TotalRepartoRecojo()

        Me.rbtComprobanteRecojo.Enabled = False
        Me.rbtGrtRecojo.Enabled = False
        Me.grbRecojoComprobante.Enabled = False
        Me.grbRecojoGrt.Enabled = False
        Me.btnAgregarRecojo.Enabled = False
        Me.btnQuitar.Enabled = False

    End Sub
    Sub ListarSolicitudReparto()
        Try
            Dim objEN As New Cls_Gasto_EN
            objEN.Ciudad = IIf(intNivel = 1 Or intNivel = 4, dtoUSUARIOS.m_idciudad, Me.cboCiudadReparto.SelectedValue)
            objEN.Estado = Me.cboEstadoSolicitudReparto.SelectedIndex
            If Me.rbtSeguimientoReparto.Checked Then
                objEN.FechaInicio = Me.dtpInicioReparto.Value.ToShortDateString
                objEN.FechaFin = Me.dtpFinReparto.Value.ToShortDateString
            Else
                objEN.FechaInicio = "01/01/2015"
                objEN.FechaFin = "01/01/2060"
            End If

            Dim obj As New Cls_Gasto_LN
            'Dim dt As DataTable = obj.ListarSolicitud(objEN)
            Dim dt As DataTable = obj.ListarSolicitudRepartoRecojo(objEN)
            Me.dgvLista.DataSource = dt
            Me.dgvLista.Refresh()
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarCombo()
        Me.cboEstadoSolicitudReparto.Items.Add("(TODO)")
        Me.cboEstadoSolicitudReparto.Items.Add("PENDIENTE")
        Me.cboEstadoSolicitudReparto.Items.Add("APROBADO")
        Me.cboEstadoSolicitudReparto.Items.Add("DESAPROBADO")
        Me.cboEstadoSolicitudReparto.Items.Add("ANULADO")
    End Sub

    Private Sub cboEstadoSolicitudReparto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstadoSolicitudReparto.SelectedIndexChanged
        'ListarSolicitudReparto()
        'If Me.dgvLista.Rows.Count > 0 Then
        '    Me.tsbEditar.Enabled = True
        '    If Me.dgvLista.CurrentRow.Cells("id_estado").Value = 1 Then
        '        Me.tsbAnular.Enabled = True
        '        Me.tsbEditar.Enabled = True
        '    Else
        '        Me.tsbAnular.Enabled = False
        '        'Me.tsbEditar.Enabled = False
        '    End If
        'Else
        '    Me.tsbEditar.Enabled = False
        '    Me.tsbAnular.Enabled = False
        'End If
    End Sub

    Sub LimpiarSolicitudReparto()
        FormateardgvReparto()
        Me.chkReparto.Checked = False
        'Me.dgvReparto.DataSource = Nothing
        Me.dgvReparto.Rows.Clear()
        Me.lblNumeroSolicitudReparto.Text = ""
        Me.lblCiudad.Text = dtoUSUARIOS.m_iNombreUnidadAgencia
        Me.lblSolicitanteReparto.Text = dtoUSUARIOS.NameLogin
        Me.lblTiempoSugerido.Text = "0.00"
        Me.txtTiempoCiudad.Text = ""
        Me.lblTarifaCiudad.Text = "0.00" 'Format(dblTarifaOficina, "0.00")
        Me.lblMontoCiudad.Text = "0.00"
        Me.txtObservacionReparto.Text = ""

        Me.txtRucProveedorReparto.Text = ""
        Me.txtRazonSocialProveedorReparto.Text = ""

        TipoGasto()
        Me.lblFechaReparto.Text = Format(FechaServidor, "Short Date")

        Me.chkTipoPagoAdicional.Checked = False
        Me.cboResponsable.DataSource = Nothing

        Me.chkRecojo.Checked = False
        Me.txtGrtRecojo.Text = ""
        Me.txtComprobanteRecojo.Text = ""
        Me.cboTipoRecojo.SelectedIndex = 0
        Me.dgvRecojo.Rows.Clear()

    End Sub

    Sub LimpiarAprobacionReparto()
        FormateardgvRepartoGasto()
        'Me.lblFechaGasto.Text = ""
        Me.lblTipoGasto.Text = ""
        Me.lblCiudadGasto.Text = dtoUSUARIOS.m_iNombreAgencia
        Me.lblSolicitanteGasto.Text = dtoUSUARIOS.NameLogin

        Me.lblPesoGasto.Text = "0.00" : Me.lblCantidadGasto.Text = "0.00"
        Me.lblPesoHora.Text = "0.00" : Me.lblSolesKg.Text = "0.00" : lblEntregaHora.Text = "0.00"
        Me.lblTiempo1Gasto.Text = "0.00" : lblTiempo2Gasto.Text = "0.00" : Me.lblTarifaCiudadGasto.Text = "0.00"
        Me.lblMontoGasto.Text = "0.00" : Me.lblSobreCobrado.Text = "0.00" : Me.lblCobrado.Text = "0.00"

        Me.txtObservacionAprobacionGasto.Text = ""

        Me.rbtSiGasto.Checked = True : Me.txtObservacionGasto.Text = ""
        Me.dgvRepartoGasto.DataSource = Nothing
    End Sub

    Sub TipoGasto()
        Try
            Dim intOpcion As Integer = 0
            Dim objEN As New Cls_Gasto_EN
            Dim obj As New Cls_Gasto_LN

            objEN.Ciudad = dtoUSUARIOS.m_idciudad
            'objEN.FechaInicio = Me.dtpFechaOperacion.Value.ToShortDateString 'Me.lblFecha.Text

            Dim dt As DataTable = obj.ListarTipoGasto(objEN)
            If dt.Rows.Count > 0 Then
                lblTipoPago.Tag = dt.Rows(0).Item("id")
                lblTipoPago.Text = dt.Rows(0).Item("tipo")
                Me.chkTipoPagoAdicional.Enabled = True
            Else
                lblTipoPago.Text = ""
                lblTipoPago.Tag = ""
                Me.chkTipoPagoAdicional.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmGasto_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        pnlConfiguracion.Visible = False
    End Sub

    Private Sub frmGasto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim obj As New Cls_Gasto_LN
        intTipoPago = obj.ObtieneTipoPago(dtoUSUARIOS.m_idciudad)

        ActualizarCombo()
        RemoveHandler cboEstadoSolicitudReparto.SelectedIndexChanged, AddressOf cboEstadoSolicitudReparto_SelectedIndexChanged
        Me.cboEstadoSolicitudReparto.SelectedIndex = 1
        AddHandler cboEstadoSolicitudReparto.SelectedIndexChanged, AddressOf cboEstadoSolicitudReparto_SelectedIndexChanged

        RemoveHandler tabGasto.SelectedIndexChanged, AddressOf tabGasto_SelectedIndexChanged
        ControlaAcceso()
        AddHandler tabGasto.SelectedIndexChanged, AddressOf tabGasto_SelectedIndexChanged

        tabGasto_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub dgvLista_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        If intNivel = 1 Or intNivel = 4 Then
            If Me.dgvLista.Rows.Count > 0 Then
                If Me.rbtSeguimientoReparto.Checked Then
                    If Me.dgvLista.Rows(e.RowIndex).Cells("id_estado").Value = 1 Then
                        Me.tsbAnular.Enabled = True
                    Else
                        Me.tsbAnular.Enabled = False
                    End If
                End If
            End If
        Else
            Me.tsbAnular.Enabled = False
        End If
    End Sub

    Private Sub btnAceptarGasto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarGasto.Click
        If Me.rbtNoGasto.Checked Then
            If Me.txtObservacionGasto.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Motivo", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtObservacionGasto.Text = ""
                Me.txtObservacionGasto.Focus()
                Return
            End If
        End If

        With Me.dgvLista
            If .CurrentRow.Cells("id_operacion").Value = 1 Then
                AprobarReparto()
            ElseIf .CurrentRow.Cells("id_operacion").Value = 2 Then
                AprobarRecojo()
            Else
                AprobarSolicitudCabecera()
            End If
        End With
    End Sub

    Sub AprobarSolicitudCabecera()
        Try
            If Me.rbtSiGasto.Checked Then 'aprueba
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    AprobarSolicitudCabecera(2)
                    MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudReparto()
                    tabReparto.SelectedTab = tabReparto.TabPages("tabLista")
                    Cursor = Cursors.Default
                End If
            ElseIf Me.rbtNoGasto.Checked Then 'no aprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    AprobarSolicitudCabecera(3)
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudReparto()
                    tabReparto.SelectedTab = tabReparto.TabPages("tabLista")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AprobarSolicitudCabecera(ByVal estado As Integer)
        Cursor = Cursors.WaitCursor
        Try
            Dim objLN As New Cls_Gasto_LN
            Dim intID As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
            Dim intReparto As Integer = Me.dgvLista.CurrentRow.Cells("id_rep").Value
            Dim intRecojo As Integer = Me.dgvLista.CurrentRow.Cells("id_rec").Value
            Dim dblPrecio As Double, strObservacion As String
            If estado = 2 Then
                strObservacion = ""
            ElseIf estado = 3 Then
                strObservacion = Me.txtObservacionAprobacionGasto.Text.Trim
            End If

            Dim objEN As New Cls_Gasto_EN
            objEN.ID = intID
            objEN.Rep = intReparto
            objEN.Rec = intRecojo
            objEN.Estado = estado
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            objLN.AprobarSolicitudCabecera(objEN)
            'objLN.AprobarSolicitudCabecera(intID, strObservacion, estado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub AprobarSolicitudRecojo(ByVal estado As Integer)
        Cursor = Cursors.WaitCursor
        Try
            Dim objLN As New Cls_Gasto_LN
            Dim intID As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
            Dim dblPrecio As Double, strObservacion As String
            If estado = 2 Then
                strObservacion = ""
            ElseIf estado = 3 Then
                strObservacion = Me.txtObservacionGasto.Text.Trim
            End If
            objLN.AprobarSolicitudRecojo(intID, strObservacion, estado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub AprobarRecojo()
        Try
            If Me.rbtSiGasto.Checked Then 'aprueba
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    AprobarSolicitudRecojo(2)
                    MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudReparto()
                    tabReparto.SelectedTab = tabReparto.TabPages("tabLista")
                    Cursor = Cursors.Default
                End If
            ElseIf Me.rbtNoGasto.Checked Then 'no aprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    AprobarSolicitudRecojo(3)
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudReparto()
                    tabReparto.SelectedTab = tabReparto.TabPages("tabLista")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub AprobarReparto()
        Try
            If Me.rbtSiGasto.Checked Then 'aprueba
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    AprobarSolicitudReparto(2)
                    MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudReparto()
                    tabReparto.SelectedTab = tabReparto.TabPages("tabLista")
                    Cursor = Cursors.Default
                End If
            ElseIf Me.rbtNoGasto.Checked Then 'no aprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    AprobarSolicitudReparto(3)
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudReparto()
                    tabReparto.SelectedTab = tabReparto.TabPages("tabLista")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AprobarSolicitudReparto(ByVal estado As Integer)
        Cursor = Cursors.WaitCursor
        Try
            Dim objLN As New Cls_Gasto_LN
            Dim intID As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
            Dim dblPrecio As Double, strObservacion As String
            If estado = 2 Then
                strObservacion = ""
            ElseIf estado = 3 Then
                strObservacion = Me.txtObservacionGasto.Text.Trim
            End If

            Dim objEN As New Cls_Gasto_EN
            objEN.ID = intID
            objEN.Observacion = strObservacion
            objEN.Estado = estado
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objLN.AprobarSolicitud(objEN)

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

#Region "Resumen"
    Sub InicioResumen()
        Try
            Dim obj As New Cls_Gasto_LN
            Dim ds As DataSet = obj.InicioResumen
            With Me.cboCiudad
                .DisplayMember = "descripcion" : .ValueMember = "id" : .DataSource = ds.Tables(0)
            End With
            With Me.cboConcepto
                .DisplayMember = "descripcion" : .ValueMember = "id" : .DataSource = ds.Tables(1)
            End With
            With Me.cboCentroCosto
                .DisplayMember = "descripcion" : .ValueMember = "id" : .DataSource = ds.Tables(2)
            End With
            With Me.cboProducto
                .DisplayMember = "descripcion" : .ValueMember = "id" : .DataSource = ds.Tables(3)
            End With
            With Me.cboTipoEntrega
                .DisplayMember = "descripcion" : .ValueMember = "id" : .DataSource = ds.Tables(4)
            End With
            dtpInicioResumen.Value = "01/" & Format(dtpInicioResumen.Value.Month, "00") & "/" & dtpInicioResumen.Value.Year

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarResumen()
        Try
            Dim objEN As New Cls_Gasto_EN
            objEN.Ciudad = Me.cboCiudad.SelectedValue
            objEN.Concepto = Me.cboConcepto.SelectedIndex
            objEN.CentroCosto = Me.cboCentroCosto.SelectedValue
            objEN.Producto = Me.cboProducto.SelectedValue
            objEN.TipoEntrega = Me.cboTipoEntrega.SelectedValue
            objEN.FechaInicio = Me.dtpInicioResumen.Value.ToShortDateString
            objEN.FechaFin = Me.dtpFinResumen.Value.ToShortDateString
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            Dim obj As New Cls_Gasto_LN
            dtResumen = obj.ListarResumen(objEN)
            Me.dgvResumen.DataSource = dtResumen

            TotalResumen()

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Cursor = Cursors.WaitCursor
        ListarResumen()
        ConfigurarResumen()
        Cursor = Cursors.Default
    End Sub
#End Region

    Private Sub dtpFechaOperacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFechaOperacion.Enter
        dtpFechaOperacion.Select()
    End Sub

    Private Sub dtpFechaOperacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaOperacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dtpFechaOperacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaOperacion.ValueChanged
        Try
            'Return
            Dim obj As New Cls_Gasto_LN
            lblTarifaCiudad.Text = Format(obj.ObtieneTarifaGasto(dtoUSUARIOS.m_idciudad, ObtieneTipoPago), "0.00")

            'If intOperacion = Operacion.Nuevo Then
            'ListarReparto()
            'End If
            If Me.chkReparto.Checked Then
                ListarReparto()
            End If
            Distribuir()
            'ActualizarReparto()

            'If Me.chkTipoPagoAdicional.Checked And intIngresa = 1 Then
            'ListarResponsable()
            'ListarHoraSalida()
            'End If
            'intIngresa = 1
            'Me.txtTiempoCiudad.Focus()
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvRepartoGasto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRepartoGasto.DoubleClick
        'If Me.dgvLista.CurrentRow.Cells("id_operacion").Value = 1 Then
        With Me.dgvRepartoGasto
            If .Rows.Count > 0 Then
                Dim frm As New frmHojaRuta
                frm.Ciudad = dgvLista.CurrentRow.Cells("id_ciudad").Value
                frm.NombreCiudad = dgvLista.CurrentRow.Cells("ciudad").Value
                frm.Fecha = Me.lblFechaGasto.Text
                frm.NombreResponsable = .CurrentRow.Cells("responsable").Value
                frm.Responsable = .CurrentRow.Cells("id_responsable").Value
                frm.Reparto = IIf(IsDBNull(.CurrentRow.Cells("id_reparto").Value), 0, .CurrentRow.Cells("id_reparto").Value)
                frm.HoraSalida = IIf(IsDBNull(.CurrentRow.Cells("id_reparto").Value), "", .CurrentRow.Cells("hora_salida").Value)
                frm.ShowDialog()
            End If
        End With
        'End If
    End Sub

    Sub TotalGastoVariable(ByVal opcion As Integer)
        Dim dblTotal As Double = 0, dblPeso As Double = 0
        If tabGastoVariable.SelectedIndex = 0 Then
            For Each row As DataGridViewRow In Me.dgvGenerarGasto.Rows
                dblTotal += row.Cells("total").Value
                dblPeso += row.Cells("peso").Value
            Next
        Else
            For Each row As DataGridViewRow In Me.dgvGenerarGastoConsultaCab.Rows
                dblTotal += row.Cells("monto").Value
                dblPeso += row.Cells("peso").Value
            Next
        End If
        Me.lblTotalGenerarGasto.Text = Format(dblTotal, "###,###,###0.00")
        Me.lblPesoGenerarGasto.Text = Format(dblPeso, "###,###,###0.00")
    End Sub

    Sub ListarSolicitudTipoGasto(ByVal estado As Integer)
        Try
            Dim obj As New Cls_Gasto_LN
            dgvLista.DataSource = obj.ListarSolicitudTipoGasto(estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLista.DoubleClick
        If dgvLista.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dtpInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.dgvResultado.DataSource = Nothing
        CalcularTotal()
    End Sub

    Private Sub dtpFin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.dgvResultado.DataSource = Nothing
        CalcularTotal()
    End Sub

    Private Sub txtRuc_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRuc.Enter
        txtRuc.SelectAll()
    End Sub

    Private Sub txtRazonSocial_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazonSocial.Enter
        txtRazonSocial.SelectAll()
    End Sub

    Private Sub txtSerieFactura_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieFactura.Enter
        txtSerieFactura.SelectAll()
    End Sub

    Private Sub txtNumeroFactura_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroFactura.Enter
        txtNumeroFactura.SelectAll()
    End Sub

    Private Sub txtRuc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRuc.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeroFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroFactura.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSerieFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieFactura.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRazonSocial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazonSocial.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dtpFechaFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaFactura.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgvResultado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResultado.CellContentClick
        If e.ColumnIndex <> 0 Then Return
        CalcularTotal()
    End Sub

    Private Sub dgvResultado_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvResultado.CellMouseUp
        If Me.dgvResultado.Rows.Count = 0 Then Return
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim strEstado As String = Me.dgvResultado.CurrentRow.Cells("estado").Value.ToString.Substring(0, 1)
            If strEstado = "F" Then
                Me.dgvResultado.CurrentRow.Cells(0).Value = 0
                dgvResultado.RefreshEdit()
                CalcularTotal()
                Return
            End If
        End If
    End Sub

    Private Sub dgvResultado_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvResultado.CurrentCellDirtyStateChanged
        dgvResultado.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Sub SeleccionarCheckDgv(ByVal dgv As DataGridView, ByVal col As Integer, ByVal estado As Integer)
        Dim strEstado As String
        For Each row As DataGridViewRow In dgv.Rows
            If estado = 1 Then
                strEstado = row.Cells("estado").Value.ToString.Substring(0, 1)
                If strEstado <> "F" Then
                    row.Cells(col).Value = estado
                End If
            Else
                row.Cells(col).Value = estado
            End If
        Next
    End Sub

    Private Sub btnSeleccionarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarTodo.Click
        SeleccionarCheckDgv(Me.dgvResultado, 0, 1)
        CalcularTotal()
    End Sub

    Private Sub btnEliminarSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarSeleccion.Click
        SeleccionarCheckDgv(Me.dgvResultado, 0, 0)
        CalcularTotal()
    End Sub

    Sub ListarProveedor(ByVal inicio As String, ByVal fin As String)
        Dim obj As New dtoFueraZona
        Dim dt As DataTable = obj.ListarProveedor(inicio, fin)
        With Me.cboProveedor
            .DisplayMember = "proveedor"
            .ValueMember = "ruc"
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Private Sub CalcularTotal()
        Dim dblSubtotal As Double = 0, dblImpuesto As Double = 0, dblTotal As Double = 0
        With dgvResultado
            For Each row As DataGridViewRow In .Rows
                If row.Cells(0).Value = 1 Then
                    dblSubtotal += row.Cells("subtotal").Value
                    dblImpuesto += row.Cells("impuesto").Value
                    dblTotal += row.Cells("total").Value
                End If
            Next
        End With
        Me.lblSubtotalLista.Text = Format(dblSubtotal, "###,###,###0.00")
        Me.lblImpuestoLista.Text = Format(dblImpuesto, "###,###,###0.00")
        Me.lblTotalLista.Text = Format(dblTotal, "###,###,###0.00")
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Try
            Cursor = Cursors.AppStarting
            Dim intEstado As Integer = -1
            If Me.cboEstadoFacturacion.SelectedIndex > 0 Then
                intEstado = IIf(Me.cboEstadoFacturacion.SelectedIndex = 1, 0, 1)
            End If

            Dim objEN As New Cls_Gasto_EN
            objEN.Ciudad = dtoUSUARIOS.m_idciudad
            objEN.FechaInicio = Me.dtpInicioLista.Value.ToShortDateString
            objEN.FechaFin = Me.dtpFinLista.Value.ToShortDateString
            objEN.Concepto = Me.cboConceptoFacturacion.SelectedIndex
            objEN.Estado = intEstado
            objEN.Proveedor = Me.cboProveedorFacturacion.SelectedValue

            Dim intRol As Integer = 0
            If dtoUSUARIOS.IdRol = 1049 Then
                intRol = 1
            Else
                intRol = 0
            End If

            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable = obj.ListarGastoAprobado(objEN, intRol)
            dgvResultado.DataSource = dt
            CalcularTotal()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarPendientesFacturar(Optional ByVal TipoAfectacion As Integer = 1)
        With dgvResultado
            Dim dblSubtotal_1 As Double = 0, dblImpuesto_1 As Double = 0, dblTotal_1 As Double = 0
            Dim strRuc As String = "", strRazonSocial As String = ""

            If Me.cboProveedorFacturacion.Items.Count > 1 Then
                If Me.cboProveedorFacturacion.SelectedIndex > 0 Then
                    strRuc = Me.cboProveedorFacturacion.Text.Trim.Substring(0, 11).Trim
                    strRazonSocial = Me.cboProveedorFacturacion.Text.Trim.Substring(11).Trim
                End If
            End If
            Me.txtRuc.Text = strRuc
            Me.txtRazonSocial.Text = strRazonSocial

            Me.dgvFactura.Rows.Clear()
            For Each row As DataGridViewRow In .Rows
                If row.Cells(0).Value = 1 Then
                    With dgvFactura
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Cells("id").Value = row.Cells("id").Value
                        .Rows(.Rows.Count - 1).Cells("concepto").Value = row.Cells("concepto").Value
                        .Rows(.Rows.Count - 1).Cells("numero").Value = row.Cells("numero").Value
                        .Rows(.Rows.Count - 1).Cells("cliente").Value = row.Cells("cliente").Value
                        .Rows(.Rows.Count - 1).Cells("id_concepto").Value = row.Cells("id_concepto").Value

                        Dim dblSubtotal As Double = row.Cells("subtotal").Value
                        Dim dblTotal As Double = dblSubtotal * (1 + (dtoUSUARIOS.iIGV / 100))
                        Dim dblImpuesto As Double = dblTotal - dblSubtotal

                        If TipoAfectacion > 1 Then
                            dblTotal = row.Cells("subtotal").Value
                            dblSubtotal = row.Cells("subtotal").Value
                            dblImpuesto = 0
                        End If

                        dblSubtotal_1 += dblSubtotal
                        dblImpuesto_1 += dblImpuesto
                        dblTotal_1 += dblTotal

                        .Rows(.Rows.Count - 1).Cells("subtotal").Value = Format(dblSubtotal, "###,###,###0.00")
                        .Rows(.Rows.Count - 1).Cells("impuesto").Value = Format(dblImpuesto, "###,###,###0.00")
                        .Rows(.Rows.Count - 1).Cells("total").Value = Format(dblTotal, "###,###,###0.00")
                    End With
                End If
            Next
            'Totales
            Me.lblSubtotal.Text = Format(dblSubtotal_1, "###,###,###0.00")
            Me.lblImpuesto.Text = Format(dblImpuesto_1, "###,###,###0.00")
            Me.lblTotal.Text = Format(dblTotal_1, "###,###,###0.00")
        End With
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Not fnValidarRUC(txtRuc.Text) Then
            MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRuc.Focus()
            Return
        End If

        If Me.txtRazonSocial.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Razón Social", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRazonSocial.Text = ""
            txtRazonSocial.Focus()
            Return
        End If

        If Me.txtSerieFactura.Text.Trim.Length <= 2 Then
            MessageBox.Show("Nº de Serie no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSerieFactura.Text = ""
            txtSerieFactura.Focus()
            Return
        End If

        If Me.txtNumeroFactura.Text.Trim.Length = 0 Then
            MessageBox.Show("Nº de Factura no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNumeroFactura.Text = ""
            txtNumeroFactura.Focus()
            Return
        End If

        If Me.cboTipoAfectacion.SelectedValue = 0 Then
            MessageBox.Show("Seleccione tipo de afectación", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoAfectacion.Focus()
            Me.cboTipoAfectacion.DroppedDown = True
            Return
        End If

        If Me.dgvFactura.Rows.Count = 0 Then
            MessageBox.Show("Seleccione Gastos a Facturar", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        GrabarFactura()

    End Sub

    Sub GrabarFactura()
        Try
            Cursor = Cursors.AppStarting
            Dim obj As New Cls_Gasto_LN
            With Me.dgvFactura
                Dim intId As Integer = 0
                For Each row As DataGridViewRow In .Rows
                    intId = obj.GrabarFactura(Me.dtpFechaFactura.Value.ToShortDateString, Me.txtSerieFactura.Text, Me.txtNumeroFactura.Text, Me.txtRuc.Text.Trim, _
                                      Me.txtRazonSocial.Text.Trim, dtoUSUARIOS.m_idciudad, dtoUSUARIOS.iIDAGENCIAS, row.Cells("id_concepto").Value, _
                                      Me.lblSubtotal.Text, Me.lblImpuesto.Text, Me.lblTotal.Text, _
                                      intId, row.Cells("id").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, Me.cboTipoAfectacion.SelectedValue)
                Next
            End With
            Cursor = Cursors.Default
            MessageBox.Show("Factura Actualizada", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRuc.Text = ""
            Me.txtRazonSocial.Text = ""
            Me.txtSerieFactura.Text = ""
            Me.txtNumeroFactura.Text = ""
            Me.dtpFechaFactura.Value = Now
            Me.dgvFactura.Rows.Clear()
            Me.lblSubtotal.Text = "0.00"
            Me.lblImpuesto.Text = "0.00"
            Me.lblTotal.Text = "0.00"
            Me.cboEstadoFacturacion.SelectedIndex = 1
            Me.btnFiltrar_Click(Nothing, Nothing)
            tabFacturacion.SelectedTab = tabFacturacion.TabPages("tabImprimirFactura")

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.ToString, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tabFacturacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabFacturacion.SelectedIndexChanged
        If tabFacturacion.SelectedTab Is tabFacturacion.TabPages("tabFactura") Then
            ConfigurarDGVFactura()
            CargarPendientesFacturar(Me.cboTipoAfectacion.SelectedValue)
            If Me.dgvFactura.Rows.Count > 0 Then
                Me.btnGrabar.Enabled = True
            Else
                Me.btnGrabar.Enabled = False
            End If
            Me.txtRuc.Focus()

        ElseIf tabFacturacion.SelectedTab Is tabFacturacion.TabPages("tabImprimirFactura") Then
            ConfigurarDGVImprimir()
            ConfigurarDGVDetalle()
            If Me.dgvImprimir.Rows.Count > 0 Then
                Me.btnImprimir.Enabled = True
            Else
                Me.btnImprimir.Enabled = False
                Me.btnLiquidar.Enabled = False
            End If
        ElseIf tabFacturacion.SelectedTab Is tabFacturacion.TabPages("tabListaFactura") Then
            CalcularTotal()
        End If
    End Sub

    Private Sub btnFiltrarImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrarImprimir.Click
        Try
            Cursor = Cursors.AppStarting
            Dim dt As DataTable
            Dim obj As New Cls_Gasto_LN
            If intNivel = 1 Or intNivel = 4 Then
                Dim intRol As Integer = 0
                If dtoUSUARIOS.IdRol = 1049 Then
                    intRol = 1
                Else
                    intRol = 0
                End If
                dt = obj.ListarFactura(dtoUSUARIOS.m_idciudad, Me.dtpInicioImprimir.Value.ToShortDateString, Me.dtpFinImprimir.Value.ToShortDateString, intRol, intRol)
            Else
                Dim strRuc As String = Me.cboProveedor.SelectedValue
                dt = obj.ListarFactura(Me.dtpInicioImprimir.Value.ToShortDateString, Me.dtpFinImprimir.Value.ToShortDateString, strRuc)
            End If
            dgvImprimir.DataSource = dt
            If Me.dgvImprimir.Rows.Count > 0 Then
                Me.btnImprimir.Enabled = True
            Else
                dgvDetalle.DataSource = Nothing
                Me.btnImprimir.Enabled = False
                Me.btnLiquidar.Enabled = False
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpInicioImprimir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicioImprimir.ValueChanged
        If intNivel <> 1 And intNivel <> 4 Then 'Me.cboProveedor.Visible Then
            ListarProveedor(Me.dtpInicioImprimir.Value.ToShortDateString, Me.dtpFinImprimir.Value.ToShortDateString)
        End If
        btnFiltrarImprimir_Click(Nothing, Nothing)
    End Sub

    Private Sub dtpFinImprimir_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFinImprimir.ValueChanged
        If intNivel <> 1 And intNivel <> 4 Then 'Me.cboProveedor.Visible Then
            ListarProveedor(Me.dtpInicioImprimir.Value.ToShortDateString, Me.dtpFinImprimir.Value.ToShortDateString)
        End If
        btnFiltrarImprimir_Click(Nothing, Nothing)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim obj As New Imprimir
        Try
            Dim dblSubtotal As Double = 0, dblImpuesto As Double = 0, dblTotal As Double = 0
            Dim intID As Integer = Me.dgvImprimir.CurrentRow.Cells("id").Value

            Dim obj1 As New Cls_Gasto_LN
            Dim dt As DataTable = obj1.ListarFactura(intID)

            Dim sImpresora As String
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0, iFila As Integer = 0
            Dim iLong As Long = 0

            obj.Inicializar()

            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt2 As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 37)
            If dt2.Rows.Count = 0 Then
                sImpresora = ""
            Else
                If IsDBNull(dt2.Rows(0).Item("impresora")) Then
                    sImpresora = ""
                Else
                    sImpresora = dt2.Rows(0).Item("impresora")
                    iTamaño = dt2.Rows(0).Item("tamano")
                    iSuperior = dt2.Rows(0).Item("superior")
                    Iizquierda = dt2.Rows(0).Item("izquierda")
                End If
            End If
            obj.Superior = iSuperior
            obj.Izquierda = Iizquierda

            obj.Impresora = sImpresora
            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            iLong = IIf(iTamaño = 0, 71, iTamaño)

            y = 2
            obj.EscribirLinea(y, 40, "SUSTENTO DE FACTURA")
            y = 5
            obj.EscribirLinea(y, 10, "OFICINA") ': obj.EscribirLinea(y, 50, "Nº LIQUIDACION")
            y = 6
            obj.EscribirLinea(y, 10, "PROVEEDOR")
            y = 7
            obj.EscribirLinea(y, 10, "FECHA") : obj.EscribirLinea(y, 40, "FACTURA")

            y = 12
            obj.EscribirLinea(y, 10, "NUMERO") : obj.EscribirLinea(y, 20, "FECHA OPERACION") : obj.EscribirLinea(y, 34, "CONCEPTO")
            obj.EscribirLinea(y, 47, "DESCRIPCION") : obj.EscribirLinea(y, 75, "COSTO ENVIO")
            For Each row As DataRow In dt.Rows
                iFila += 1
                If iFila = 1 Then
                    obj.EscribirLinea(5, 22, row("agencia").ToString) : obj.EscribirLinea(6, 22, row("ruc").ToString) : obj.EscribirLinea(6, 35, row("razon_social").ToString)
                    'obj.EscribirLinea(5, 80, row("liquidacion").ToString)
                    obj.EscribirLinea(7, 22, FechaServidor)
                    obj.EscribirLinea(7, 60, row("factura").ToString)
                End If
                obj.EscribirLinea(y + iFila, 12, row("numero_solicitud").ToString.Trim.PadRight(5, " ").Substring(0, 5))
                obj.EscribirLinea(y + iFila, 20, row("fecha").ToString.Trim.PadRight(10, " ").Substring(0, 10))
                obj.EscribirLinea(y + iFila, 34, row("concepto").ToString.Trim.PadRight(20, " ").Substring(0, 20))
                obj.EscribirLinea(y + iFila, 47, row("cliente").ToString.Trim.PadRight(40, " ").Substring(0, 40))
                obj.EscribirLinea(y + iFila, 75, Format(row("costo"), "####,###,###0.00").PadLeft(10, " "))

                dblSubtotal = row("subtotal") : dblImpuesto = row("impuesto") : dblTotal = row("total")
            Next
            y = y + iFila + 2
            obj.EscribirLinea(y + 2, 60, "SUBTOTAL") : obj.EscribirLinea(y + 3, 60, "IMPUESTO") : obj.EscribirLinea(y + 4, 60, "TOTAL")
            obj.EscribirLinea(y + 2, 75, Format(dblSubtotal, "###,###,###0.00").PadLeft(10, " "))
            obj.EscribirLinea(y + 3, 75, Format(dblImpuesto, "###,###,###0.00").PadLeft(10, " "))
            obj.EscribirLinea(y + 4, 75, Format(dblTotal, "###,###,###0.00").PadLeft(10, " "))

            obj.Comprimido = True
            obj.Preliminar = True
            obj.Tamaño = iLong
            obj.Imprimir()
            obj.Finalizar()

            Dim frm As New FrmPreview
            frm.Documento = 37
            frm.Tamaño = 66
            frm.Text = "Sustento Factura"
            frm.ShowDialog()
        Catch ex As Exception
            obj.Finalizar()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub dgvImprimir_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvImprimir.RowEnter
        If Me.dgvImprimir.Rows.Count > 0 Then
            If intNivel = 3 Then
                Dim intLiquidacion As Integer = IIf(IsDBNull(Me.dgvImprimir.Rows(e.RowIndex).Cells("liquidacion").Value), 0, Me.dgvImprimir.Rows(e.RowIndex).Cells("liquidacion").Value)
                If intLiquidacion = 0 Then
                    Me.btnLiquidar.Enabled = True
                Else
                    Me.btnLiquidar.Enabled = False
                End If
            Else
                Me.btnLiquidar.Enabled = False
            End If

            Dim intID As Integer = Me.dgvImprimir.Rows(e.RowIndex).Cells("id").Value

            Dim obj1 As New Cls_Gasto_LN
            Dim dt As DataTable = obj1.ListarFactura(intID)

            Me.dgvDetalle.DataSource = dt
        Else
            Me.btnLiquidar.Enabled = False
        End If
    End Sub

    Private Sub cboProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProveedor.SelectedIndexChanged
        btnFiltrarImprimir_Click(Nothing, Nothing)
    End Sub

    Private Sub cboCiudadGenerarGasto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCiudadGenerarGasto.SelectedIndexChanged
        If tabGastoVariable.SelectedIndex = 0 Then
            lblTotalGenerarGasto.Text = "0.00"
            lblPesoGenerarGasto.Text = "0.00"
            dgvGenerarGasto.DataSource = Nothing
            Me.tsbGrabar.Enabled = False
        Else
            dgvGenerarGastoConsultaCab.DataSource = Nothing
            dgvGenerarGastoConsulta.DataSource = Nothing
        End If
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaInicio.ValueChanged, dtpFechaInicio2.ValueChanged
        If tabGastoVariable.SelectedIndex = 0 Then
            lblTotalGenerarGasto.Text = "0.00"
            lblPesoGenerarGasto.Text = "0.00"
            dgvGenerarGasto.DataSource = Nothing
            Me.tsbGrabar.Enabled = False
        Else
            dgvGenerarGastoConsultaCab.DataSource = Nothing
            dgvGenerarGastoConsulta.DataSource = Nothing
            Me.tsbAnular.Enabled = False
        End If
    End Sub

    Private Sub dtpFechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaFin.ValueChanged, dtpFechaFin2.ValueChanged
        If tabGastoVariable.SelectedIndex = 0 Then
            lblTotalGenerarGasto.Text = "0.00"
            lblPesoGenerarGasto.Text = "0.00"
            dgvGenerarGasto.DataSource = Nothing
            Me.tsbGrabar.Enabled = False
        Else
            dgvGenerarGastoConsultaCab.DataSource = Nothing
            dgvGenerarGastoConsulta.DataSource = Nothing
            Me.tsbAnular.Enabled = False
        End If
    End Sub

    Private Sub dgvGenerarGastoConsultaCab_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGenerarGastoConsultaCab.RowEnter
        ConsultarGastoDetalle(Me.dgvGenerarGastoConsultaCab.Rows(e.RowIndex).Cells("id").Value)
        Me.tsbAnular.Enabled = Me.dgvGenerarGastoConsultaCab.Rows(e.RowIndex).Cells("idfacturado").Value = 0
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        pnlConfiguracion.Visible = False
    End Sub

    Sub Resumen1(ByRef dtJoin)
        If aGrupo(0) And aGrupo(1) = False And aGrupo(2) = False And aGrupo(3) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad Into Grouping = Group _
                          Select ciudad, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList

        ElseIf aGrupo(0) And aGrupo(1) And aGrupo(2) = False And aGrupo(3) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!concepto Into Grouping = Group _
                          Select ciudad, concepto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(0) And aGrupo(1) = False And aGrupo(2) And aGrupo(3) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!centro_costo Into Grouping = Group _
                          Select ciudad, centro_costo, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(0) And aGrupo(1) = False And aGrupo(2) = False And aGrupo(3) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!producto Into Grouping = Group _
                          Select ciudad, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList

        ElseIf aGrupo(0) And aGrupo(1) And aGrupo(2) And aGrupo(3) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!concepto, row!centro_costo Into Grouping = Group _
                          Select ciudad, concepto, centro_costo, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(0) And aGrupo(1) = False And aGrupo(2) And aGrupo(3) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!centro_costo, row!producto Into Grouping = Group _
                          Select ciudad, centro_costo, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(0) And aGrupo(1) And aGrupo(2) = False And aGrupo(3) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!concepto, row!producto Into Grouping = Group _
                          Select ciudad, concepto, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList

        ElseIf aGrupo(0) And aGrupo(1) And aGrupo(2) And aGrupo(3) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!concepto, row!centro_costo, row!producto Into Grouping = Group _
                          Select ciudad, concepto, centro_costo, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        End If
    End Sub

    Sub Resumen2(ByRef dtJoin)
        If aGrupo(1) And aGrupo(0) = False And aGrupo(2) = False And aGrupo(3) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!concepto Into Grouping = Group _
                          Select concepto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList

        ElseIf aGrupo(1) And aGrupo(0) And aGrupo(2) = False And aGrupo(3) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!concepto Into Grouping = Group _
                          Select ciudad, concepto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(1) And aGrupo(0) = False And aGrupo(2) And aGrupo(3) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!concepto, row!centro_costo Into Grouping = Group _
                          Select concepto, centro_costo, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(1) And aGrupo(0) = False And aGrupo(2) = False And aGrupo(3) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!concepto, row!producto Into Grouping = Group _
                          Select concepto, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList

        ElseIf aGrupo(1) And aGrupo(0) And aGrupo(2) And aGrupo(3) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!concepto, row!centro_costo Into Grouping = Group _
                          Select ciudad, concepto, centro_costo, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(1) And aGrupo(0) = False And aGrupo(2) And aGrupo(3) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!concepto, row!centro_costo, row!producto Into Grouping = Group _
                          Select concepto, centro_costo, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(1) And aGrupo(0) And aGrupo(2) = False And aGrupo(3) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!concepto, row!producto Into Grouping = Group _
                          Select ciudad, concepto, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList

        ElseIf aGrupo(1) And aGrupo(0) And aGrupo(2) And aGrupo(3) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!concepto, row!centro_costo, row!producto Into Grouping = Group _
                          Select ciudad, concepto, centro_costo, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        End If
    End Sub

    Sub Resumen3(ByRef dtJoin)
        If aGrupo(2) And aGrupo(0) = False And aGrupo(1) = False And aGrupo(3) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!centro_costo Into Grouping = Group _
                          Select centro_costo, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList

        ElseIf aGrupo(2) And aGrupo(0) And aGrupo(1) = False And aGrupo(3) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!centro_costo Into Grouping = Group _
                          Select ciudad, centro_costo, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(2) And aGrupo(0) = False And aGrupo(1) And aGrupo(3) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!concepto, row!centro_costo Into Grouping = Group _
                          Select concepto, centro_costo, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(2) And aGrupo(0) = False And aGrupo(1) = False And aGrupo(3) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!centro_costo, row!producto Into Grouping = Group _
                          Select centro_costo, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList

        ElseIf aGrupo(2) And aGrupo(0) And aGrupo(1) And aGrupo(3) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!concepto, row!centro_costo Into Grouping = Group _
                          Select ciudad, concepto, centro_costo, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(2) And aGrupo(0) = False And aGrupo(1) And aGrupo(3) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!concepto, row!centro_costo, row!producto Into Grouping = Group _
                          Select concepto, centro_costo, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(2) And aGrupo(0) And aGrupo(1) = False And aGrupo(3) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!concepto, row!producto Into Grouping = Group _
                          Select ciudad, concepto, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList

        ElseIf aGrupo(1) And aGrupo(0) And aGrupo(2) And aGrupo(3) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!concepto, row!centro_costo, row!producto Into Grouping = Group _
                          Select ciudad, concepto, centro_costo, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        End If
    End Sub

    Sub Resumen4(ByRef dtJoin)
        If aGrupo(3) And aGrupo(0) = False And aGrupo(1) = False And aGrupo(2) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!producto Into Grouping = Group _
                          Select producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList

        ElseIf aGrupo(3) And aGrupo(0) And aGrupo(1) = False And aGrupo(2) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!producto Into Grouping = Group _
                          Select ciudad, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(3) And aGrupo(0) = False And aGrupo(1) And aGrupo(2) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!concepto, row!producto Into Grouping = Group _
                          Select concepto, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(3) And aGrupo(0) = False And aGrupo(1) = False And aGrupo(2) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!centro_costo, row!producto Into Grouping = Group _
                          Select centro_costo, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList

        ElseIf aGrupo(3) And aGrupo(0) And aGrupo(1) And aGrupo(2) = False Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!concepto, row!producto Into Grouping = Group _
                          Select ciudad, concepto, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(3) And aGrupo(0) = False And aGrupo(1) And aGrupo(2) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!concepto, row!centro_costo, row!producto Into Grouping = Group _
                          Select concepto, centro_costo, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        ElseIf aGrupo(3) And aGrupo(0) And aGrupo(1) = False And aGrupo(2) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!centro_costo, row!producto Into Grouping = Group _
                          Select ciudad, centro_costo, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList

        ElseIf aGrupo(1) And aGrupo(0) And aGrupo(2) And aGrupo(3) Then
            dtJoin = (From row In dtResumen.Rows Group row By row!ciudad, row!concepto, row!centro_costo, row!producto Into Grouping = Group _
                          Select ciudad, concepto, centro_costo, producto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto)), peso = Grouping.Sum(Function(p) Decimal.Parse(p!peso))).ToList
        End If
    End Sub

    Sub TotalResumen()
        If Me.dgvResumen.Rows.Count > 0 And (aCampo(0) Or aCampo(1) Or aCampo(2)) And (aGrupo(0) Or aGrupo(1) Or aGrupo(2) Or aGrupo(3)) Then
            Dim dblGasto As Double = IIf(IsDBNull(dtResumen.Compute("sum(monto)", "")), 0, dtResumen.Compute("sum(monto)", ""))
            Dim dblPeso As Double = IIf(IsDBNull(dtResumen.Compute("sum(peso)", "")), 0, dtResumen.Compute("sum(peso)", ""))
            Dim dblSpkg As Double = dblGasto / IIf(dblPeso = 0, 1, dblPeso)
            Me.lblTotalGasto.Text = Format(dblGasto, "###,###,###0.00")
            Me.lblTotalPeso.Text = Format(dblPeso, "###,###,###0.00")
            Me.lblSpkg.Text = Format(dblSpkg, "###,###,###0.00")
            Me.btnExportar.Enabled = True
        Else
            Me.lblTotalGasto.Text = Format(0, "###,###,###0.00")
            Me.lblTotalPeso.Text = Format(0, "###,###,###0.00")
            Me.lblSpkg.Text = Format(0, "###,###,###0.00")
            Me.btnExportar.Enabled = False
        End If
    End Sub

    Sub TotalCabecera()
        With Me.dgvResumen
            .Columns("ciudad").Visible = aGrupo(0)
            .Columns("concepto").Visible = aGrupo(1)
            .Columns("centro_costo").Visible = aGrupo(2)
            .Columns("producto").Visible = aGrupo(3)

            .Columns("monto").Visible = aCampo(0)
            .Columns("peso").Visible = aCampo(1)
            .Columns("spkg").Visible = aCampo(2)
        End With
    End Sub

    Sub ConfigurarResumen()
        Dim dtJoin
        If aGrupo(0) Then
            Resumen1(dtJoin)
        ElseIf aGrupo(1) Then
            Resumen2(dtJoin)
        ElseIf aGrupo(2) Then
            Resumen3(dtJoin)
        ElseIf aGrupo(3) Then
            Resumen4(dtJoin)
        End If

        With Me.dgvResumen
            .DataSource = Nothing
            .DataSource = dtJoin
        End With

        CalcularCelda()
    End Sub

    Private Sub chkCiudad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCiudad.CheckedChanged, chkConcepto.CheckedChanged, chkCentroCosto.CheckedChanged, chkProducto.CheckedChanged, chkMonto.CheckedChanged, chkPeso.CheckedChanged, chkSpkg.CheckedChanged
        aGrupo(0) = Me.chkCiudad.Checked : aGrupo(1) = Me.chkConcepto.Checked : aGrupo(2) = Me.chkCentroCosto.Checked : aGrupo(3) = Me.chkProducto.Checked
        aCampo(0) = Me.chkMonto.Checked : aCampo(1) = Me.chkPeso.Checked : aCampo(2) = Me.chkSpkg.Checked

        If Not IsNothing(dtResumen) Then
            If dtResumen.Rows.Count > 0 Then
                ConfigurarResumen()
            Else
                Me.dgvResumen.DataSource = Nothing
            End If
        End If

        TotalCabecera()
        TotalResumen()
    End Sub

    Private Sub btnConfiguracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfiguracion.Click
        RemoveHandler chkCiudad.CheckedChanged, AddressOf chkCiudad_CheckedChanged
        Me.chkCiudad.Checked = aGrupo(0) : Me.chkConcepto.Checked = aGrupo(1) : Me.chkCentroCosto.Checked = aGrupo(2) : Me.chkProducto.Checked = aGrupo(3)
        Me.chkMonto.Checked = aCampo(0) : Me.chkPeso.Checked = aCampo(1) : Me.chkSpkg.Checked = aCampo(2)
        AddHandler chkCiudad.CheckedChanged, AddressOf chkCiudad_CheckedChanged

        pnlConfiguracion.Visible = Not pnlConfiguracion.Visible
    End Sub

    Sub CalcularCelda()
        Dim dblMonto As Double, dblPeso As Double, dblSpkg As Double
        With dgvResumen
            For Each row As DataGridViewRow In .Rows
                dblMonto = row.Cells("monto").Value
                dblPeso = row.Cells("peso").Value
                dblSpkg = dblMonto / IIf(dblPeso = 0, 1, dblPeso)
                row.Cells("spkg").Value = Format(dblSpkg, "0.00")
            Next
        End With
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Cursor = Cursors.AppStarting
        Dim xlApp As New Excel.Application()
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        Dim dblTotal As Double = 0, intColumna As Integer = 0
        Try
            Dim rowIndex, colIndex, i, j As Integer
            rowIndex = 1
            colIndex = 0
            xlBook = xlApp.Workbooks().Add
            xlSheet = xlBook.Worksheets("hoja1")

            'detalle
            rowIndex = 1
            For i = 0 To dgvResumen.Rows.Count - 1
                rowIndex = rowIndex + 1
                colIndex = 0
                For j = 0 To dgvResumen.Columns.Count - 1
                    If dgvResumen.Columns(j).Visible Then
                        colIndex = colIndex + 1
                        xlApp.Cells(1, colIndex) = dgvResumen.Columns(j).Name.ToString.ToUpper
                        xlApp.Cells(rowIndex, colIndex) = dgvResumen.Rows(i).Cells(j).Value
                        xlSheet.Range(xlSheet.Cells(rowIndex, colIndex), xlSheet.Cells(rowIndex, colIndex)).NumberFormat = "###,###,###.00"
                        If dgvResumen.Columns(j).Name.ToString.ToUpper = "MONTO" Then
                            intColumna = colIndex
                            dblTotal += dgvResumen.Rows(i).Cells(j).Value
                        End If
                    End If
                Next
            Next
            xlApp.Cells(rowIndex + 1, intColumna - 1) = "TOTAL"
            xlApp.Cells(rowIndex + 1, intColumna) = Format(dblTotal, "###,###,###0.00")

            xlSheet.Range(xlSheet.Cells(1, 1), xlSheet.Cells(1, colIndex)).Font.Bold = True
            xlSheet.Range(xlSheet.Cells(rowIndex + 1, intColumna - 1), xlSheet.Cells(rowIndex + 1, intColumna)).Font.Bold = True
            xlSheet.Columns.AutoFit()

            Cursor = Cursors.Default
            xlApp.Visible = True
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            xlApp.Quit()
            xlApp.Visible = False
        End Try
    End Sub

    Private Sub cboTipoPagoAdicional_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.chkTipoPagoAdicional.Checked Then
            intIngresa = 0
            dtpFechaOperacion_ValueChanged(Nothing, Nothing)
        End If
    End Sub

    Sub ListarResponsable()
        Dim obj As New Cls_Gasto_LN
        Dim objEN As New Cls_Gasto_EN

        objEN.FechaInicio = Me.dtpFechaOperacion.Value.ToShortDateString
        objEN.Ciudad = dtoUSUARIOS.m_idciudad
        With Me.cboResponsable
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarResponsable(objEN)
            If Me.cboResponsable.Items.Count = 2 Then
                Me.cboResponsable.SelectedIndex = 1
            End If
        End With
    End Sub

    Sub ListarHoraSalida()
        Dim obj As New Cls_Reparto_LN
        Dim intResponsable As Integer

        intResponsable = Me.cboResponsable.SelectedValue
        With Me.cboHoraSalida
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarHoraSalida(dtoUSUARIOS.m_idciudad, Me.dtpFechaOperacion.Value.ToShortDateString, intResponsable)
            .SelectedValue = 0
        End With
    End Sub

    Private Sub chkTipoPagoAdicional_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTipoPagoAdicional.CheckedChanged
        'Me.dgvReparto.DataSource = Nothing
        Me.dgvReparto.Rows.Clear()
        If chkTipoPagoAdicional.Checked Then
            Me.lblTiempoCiudad.Text = "Monto"
            ListarResponsable()
            Me.cboResponsable.Enabled = True
            Me.cboHoraSalida.Enabled = True
            Me.btnAgregarReparto.Enabled = True
            'Me.btnQuitarReparto.Enabled = False
        Else
            Me.lblTiempoCiudad.Text = "Tiempo Reparto"
            Me.cboResponsable.DataSource = Nothing
            Me.cboResponsable.Enabled = False
            Me.cboHoraSalida.DataSource = Nothing
            Me.cboHoraSalida.Enabled = False
            Me.btnAgregarReparto.Enabled = False
            Me.btnQuitarReparto.Enabled = False
            'Actualiza contenido de la pantalla
            dtpFechaOperacion_ValueChanged(Nothing, Nothing)
        End If
        'Me.btnConsultarListaReparto_Click(Nothing, Nothing)
    End Sub

    Private Sub cboResponsable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboResponsable.SelectedIndexChanged
        If Me.chkTipoPagoAdicional.Checked Then
            intIngresa = 0
            ListarHoraSalida()
            'Me.btnConsultarListaReparto_Click(Nothing, Nothing)
            'dtpFechaOperacion_ValueChanged(Nothing, Nothing)
        End If
    End Sub
    '----------------------------------------------------FUERA ZONA ----------------------------------------------------------------------
#Region "Grid"
    Private Sub ConfigurarDGVListaSolicitud()
        With dgvListaSolicitud
            Cls_Utilitarios.FormatDataGridView(dgvListaSolicitud)
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_solicitud As New DataGridViewTextBoxColumn
            With col_solicitud
                .Name = "numero_solicitud" : .DataPropertyName = "numero_solicitud"
                .DisplayIndex = x : .HeaderText = "Nº Solicitud"
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
            End With
            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_costo As New DataGridViewTextBoxColumn
            With col_costo
                .Name = "costo" : .DataPropertyName = "costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Costo" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio Aceptado" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_precio_observacion As New DataGridViewTextBoxColumn
            With col_precio_observacion
                .Name = "precio_observacion" : .DataPropertyName = "precio_observacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio Observado" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_precio_aprobacion As New DataGridViewTextBoxColumn
            With col_precio_aprobacion
                .Name = "precio" : .DataPropertyName = "precio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio Aprobado" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_aceptacion As New DataGridViewTextBoxColumn
            With col_aceptacion
                .Name = "fecha_aceptacion" : .DataPropertyName = "fecha_aceptacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aceptación"
            End With
            x += +1
            Dim col_observado As New DataGridViewTextBoxColumn
            With col_observado
                .Name = "fecha_observacion" : .DataPropertyName = "fecha_observacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Observación"
            End With
            x += +1
            Dim col_aprobacion As New DataGridViewTextBoxColumn
            With col_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación"
            End With
            x += +1
            Dim col_noaceptacion As New DataGridViewTextBoxColumn
            With col_noaceptacion
                .Name = "fecha_noaceptacion" : .DataPropertyName = "fecha_noaceptacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha no Aceptación"
            End With
            x += +1
            Dim col_desaprobacion As New DataGridViewTextBoxColumn
            With col_desaprobacion
                .Name = "fecha_desaprobacion" : .DataPropertyName = "fecha_desaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Desaprobación"
            End With
            x += +1
            Dim col_anulacion As New DataGridViewTextBoxColumn
            With col_anulacion
                .Name = "fecha_anulacion" : .DataPropertyName = "fecha_anulacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Anulación"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id"
            End With
            x += +1
            Dim col_observacion_observacion As New DataGridViewTextBoxColumn
            With col_observacion_observacion
                .Name = "observacion_observacion" : .DataPropertyName = "observacion_observacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Observación"
            End With
            x += +1
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcliente"
            End With
            x += +1
            Dim col_oficina As New DataGridViewTextBoxColumn
            With col_oficina
                .Name = "oficina" : .DataPropertyName = "oficina"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Oficina" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "solicitante"
            End With
            x += +1
            Dim col_contacto As New DataGridViewTextBoxColumn
            With col_contacto
                .Name = "contacto" : .DataPropertyName = "contacto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "contacto"
            End With
            x += +1
            Dim col_funcionario As New DataGridViewTextBoxColumn
            With col_funcionario
                .Name = "funcionario" : .DataPropertyName = "funcionario"
                .DisplayIndex = x : .Visible = False : .HeaderText = "funcionario"
            End With
            x += +1
            Dim col_localidad As New DataGridViewTextBoxColumn
            With col_localidad
                .Name = "localidad" : .DataPropertyName = "localidad"
                .DisplayIndex = x : .Visible = False : .HeaderText = "localidad"
            End With
            x += +1
            Dim col_km As New DataGridViewTextBoxColumn
            With col_km
                .Name = "km" : .DataPropertyName = "km"
                .DisplayIndex = x : .Visible = False : .HeaderText = "km"
            End With
            x += +1
            Dim col_hora As New DataGridViewTextBoxColumn
            With col_hora
                .Name = "hora" : .DataPropertyName = "hora"
                .DisplayIndex = x : .Visible = False : .HeaderText = "hora"
            End With
            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id estado"
            End With
            x += +1
            Dim col_id_proveedor As New DataGridViewTextBoxColumn
            With col_id_proveedor
                .Name = "id_proveedor" : .DataPropertyName = "id_proveedor" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_ruc As New DataGridViewTextBoxColumn
            With col_ruc
                .Name = "ruc" : .DataPropertyName = "ruc" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_proveedor As New DataGridViewTextBoxColumn
            With col_proveedor
                .Name = "proveedor" : .DataPropertyName = "proveedor" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Observación" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_observacion2 As New DataGridViewTextBoxColumn
            With col_observacion2
                .Name = "observacion2" : .DataPropertyName = "observacion2"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Observación por Desaprobación" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_solicitud, col_fecha, col_codigo, col_cliente, col_costo, col_total, col_precio_observacion, col_precio_aprobacion, col_estado, _
                              col_aceptacion, col_observado, col_aprobacion, col_noaceptacion, col_desaprobacion, col_anulacion, _
                              col_observacion, col_observacion_observacion, col_id, col_idcliente, col_oficina, col_solicitante, col_contacto, _
                              col_funcionario, col_localidad, col_km, col_hora, col_idestado, col_id_proveedor, col_ruc, col_proveedor, col_observacion2)
        End With
    End Sub
    Private Sub ConfigurarDGVGuiaEnvio()
        With dgvGuiaEnvio
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idtipo As New DataGridViewTextBoxColumn
            With col_idtipo
                .Name = "idtipo" : .DataPropertyName = "idtipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo"
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_origen As New DataGridViewTextBoxColumn
            With col_agencia_origen
                .Name = "agencia_origen" : .DataPropertyName = "agencia_origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_destino As New DataGridViewTextBoxColumn
            With col_agencia_destino
                .Name = "agencia_destino" : .DataPropertyName = "agencia_destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dirección"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            x += +1
            Dim col_idcomprobante As New DataGridViewTextBoxColumn
            With col_idcomprobante
                .Name = "idcomprobante" : .DataPropertyName = "idcomprobante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcomprobante"
            End With
            x += +1
            Dim col_idagencias As New DataGridViewTextBoxColumn
            With col_idagencias
                .Name = "idagencia_origen" : .DataPropertyName = "idagencia_origen"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_origen"
            End With
            x += +1
            Dim col_idagencias_destino As New DataGridViewTextBoxColumn
            With col_idagencias_destino
                .Name = "idagencia_destino" : .DataPropertyName = "idagencia_destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_destino"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_fecha, col_idtipo, col_tipo, col_comprobante, col_origen, col_destino, col_agencia_origen, col_agencia_destino, col_total, _
                              col_cantidad, col_peso, col_direccion, _
                              col_idcomprobante, col_idagencias, col_idagencias_destino, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVGuiaEnvioAceptacion()
        With dgvGuiaEnvioAceptacion
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idtipo As New DataGridViewTextBoxColumn
            With col_idtipo
                .Name = "idtipo" : .DataPropertyName = "idtipo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo"
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_guia As New DataGridViewTextBoxColumn
            With col_guia
                .Name = "guia" : .DataPropertyName = "guia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_origen As New DataGridViewTextBoxColumn
            With col_agencia_origen
                .Name = "agencia_origen" : .DataPropertyName = "agencia_origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_destino As New DataGridViewTextBoxColumn
            With col_agencia_destino
                .Name = "agencia_destino" : .DataPropertyName = "agencia_destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dirección"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idguia As New DataGridViewTextBoxColumn
            With col_idguia
                .Name = "idguia" : .DataPropertyName = "idguia"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idguia"
            End With
            x += +1
            Dim col_idagencias As New DataGridViewTextBoxColumn
            With col_idagencias
                .Name = "idagencia_origen" : .DataPropertyName = "idagencia_origen"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_origen"
            End With
            x += +1
            Dim col_idagencias_destino As New DataGridViewTextBoxColumn
            With col_idagencias_destino
                .Name = "idagencia_destino" : .DataPropertyName = "idagencia_destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_destino"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_fecha, col_idtipo, col_tipo, col_guia, col_origen, col_destino, col_agencia_origen, col_agencia_destino, col_total, _
                              col_cantidad, col_peso, col_direccion, _
                              col_idguia, col_idagencias, col_idagencias_destino, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVGuiaEnvioAprobacion()
        With dgvGuiaEnvioAprobacion
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idtipo As New DataGridViewTextBoxColumn
            With col_idtipo
                .Name = "idtipo" : .DataPropertyName = "idtipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo"
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_guia As New DataGridViewTextBoxColumn
            With col_guia
                .Name = "guia" : .DataPropertyName = "guia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_origen As New DataGridViewTextBoxColumn
            With col_agencia_origen
                .Name = "agencia_origen" : .DataPropertyName = "agencia_origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_destino As New DataGridViewTextBoxColumn
            With col_agencia_destino
                .Name = "agencia_destino" : .DataPropertyName = "agencia_destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dirección"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idguia As New DataGridViewTextBoxColumn
            With col_idguia
                .Name = "idguia" : .DataPropertyName = "idguia"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idguia"
            End With
            x += +1
            Dim col_idagencias As New DataGridViewTextBoxColumn
            With col_idagencias
                .Name = "idagencia_origen" : .DataPropertyName = "idagencia_origen"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_origen"
            End With
            x += +1
            Dim col_idagencias_destino As New DataGridViewTextBoxColumn
            With col_idagencias_destino
                .Name = "idagencia_destino" : .DataPropertyName = "idagencia_destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_destino"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_fecha, col_idtipo, col_tipo, col_guia, col_origen, col_destino, col_agencia_origen, col_agencia_destino, col_total, _
                              col_cantidad, col_peso, col_direccion, _
                              col_idguia, col_idagencias, col_idagencias_destino, col_estado)
        End With
    End Sub

#End Region

#Region "Lista"
    Sub LlenarCombo(ByVal cliente As Integer)
        Dim objLN As New Cls_LineaCredito_LN
        With cboContactoAceptacion
            .DataSource = Nothing
            .DataSource = objLN.ListarContactoCredito(cliente, "")
            .DisplayMember = "CONTACTO"
            .ValueMember = "ID"
            .SelectedValue = 0
        End With
    End Sub

#End Region

#Region "Solicitud"
    Sub Inicio()
        Dim obj As New dtoFueraZona
        Dim dt As DataTable = obj.ListarCliente

        Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        ObjProcesos.fnCargar_iWin_r(Me.txtCliente, dt.DefaultView, colCliente, autoCliente, 0)

        ConfigurarDGVGuiaEnvio()
        ConfigurarDGVListaSolicitud()

        Dim obj2 As New Cls_Gasto_LN
        With Me.cboCiudadFueraZona
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj2.ListarCiudad(1)
            '.SelectedValue = 0
        End With

        If intNivel = 1 Or intNivel = 4 Then
            ActualizaCombo()
            Me.cboEstadoSolicitud.SelectedIndex = 1
            Me.cboCiudadFueraZona.SelectedValue = dtoUSUARIOS.m_idciudad
            Me.cboCiudadFueraZona.Enabled = False
        ElseIf intNivel = 2 Then
            ActualizaCombo(2)
            Me.cboEstadoSolicitud.SelectedIndex = 0
            Me.cboCiudadFueraZona.SelectedValue = 0
            Me.cboCiudadFueraZona.Enabled = True
        ElseIf intNivel = 3 Then
            ActualizaCombo()
            Me.cboEstadoSolicitud.SelectedIndex = 1
            Me.cboCiudadFueraZona.SelectedValue = 0
            Me.cboCiudadFueraZona.Enabled = True
        Else
            ActualizaCombo()
            Me.cboEstadoSolicitud.SelectedIndex = 1
            Me.cboCiudadFueraZona.SelectedValue = 0
            Me.cboCiudadFueraZona.Enabled = False
        End If
    End Sub
    Private Sub txtCliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyUp
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
                SendKeys.Send(vbTab)
            Else
                Me.txtCodigoCliente.Text = ""
            End If
        End If
    End Sub

    Private Sub txtCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.LostFocus
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            Me.txtCliente.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtCodigoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                If Me.txtCodigoCliente.Text.Trim.Length > 0 Then
                    Dim obj As New dtoCarga
                    Dim strCodigoCliente As String = Me.txtCodigoCliente.Text.Trim
                    Dim dt As DataTable = obj.ObtieneCliente(strCodigoCliente)
                    If dt.Rows.Count > 0 Then
                        Me.txtCliente.Text = dt.Rows(0).Item("cliente")
                        SendKeys.Send(vbTab)
                    Else
                        MessageBox.Show("El Cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCodigoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.LostFocus
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            Me.txtCliente.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub
#End Region

#Region "Administrador"
    Sub ControlaAcceso()
        'Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabRecojer"))

        tabSolicitud = tabFueraZona.TabPages("tabSolicitudZona")
        tabAceptacion = tabFueraZona.TabPages("tabAceptacionZona")
        tabAprobacion = tabFueraZona.TabPages("tabAprobacionZona")
        tabFacturar = tabFueraZona.TabPages("tabImpresionZona")

        tabSolicitudReparto = tabReparto.TabPages("tabSolicitar")
        tabGenerarGasto = tabReparto.TabPages("tabGenerarGasto")
        tabAprobacionReparto = tabReparto.TabPages("tabAprobar")

        tabSolicitarEstiba = tabEstiba.TabPages("tabSolicitudEstiba")
        tabAprobarEstiba = tabEstiba.TabPages("tabAprobacionEstiba")

        tabSolicitarTraslado = tabTraslado.TabPages("tabSolicitudTraslado")
        tabAprobarTraslado = tabTraslado.TabPages("tabAprobacionTraslado")

        tabSolicitarEmbalaje = tabEmbalaje.TabPages("tabSolicitudEmbalaje")
        tabAceptarEmbalaje = tabEmbalaje.TabPages("tabAceptacionEmbalaje")
        tabAprobarEmbalaje = tabEmbalaje.TabPages("tabAprobacionEmbalaje")
        'tabFacturarEstiba = tabFueraZona.TabPages("tabImpresionEstiba")

        Me.tsbEditar.Enabled = False
        Me.tsbGrabar.Enabled = False
        Me.tsbAnular.Enabled = False

        If Acceso.SiRol(G_Rol, Me, 1, 1) Or Acceso.SiRol(G_Rol, Me, 1, 5) Then 'Oficina
            intNivel = 1
            Me.tsbNuevo.Enabled = True
            'Me.tsbEditar.Text = "Editar"
            Me.rbtSeguimiento.Checked = True
            Me.pnlOpcion.Visible = False
            Me.pnlEstado.Visible = True

            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabResumen"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabProvisionar"))

            Me.tabReparto.TabPages.Remove(tabReparto.TabPages("tabAprobar"))
            Me.tabReparto.TabPages.Remove(tabReparto.TabPages("tabGenerarGasto"))
            Me.tabEstiba.TabPages.Remove(tabEstiba.TabPages("tabAprobacionEstiba"))
            Me.tabTraslado.TabPages.Remove(tabTraslado.TabPages("tabAprobacionTraslado"))

            Me.rbtSeguimientoEmbalaje.Checked = True
            Me.pnlOpcionEmbalaje.Visible = False
            Me.pnlEstadoEmbalaje.Visible = True

            Me.rbtSeguimientoReparto.Checked = True : Me.rbtPorAprobarReparto.Checked = False
            Me.rbtSeguimientoReparto.Visible = False : Me.rbtPorAprobarReparto.Visible = False

            If dtoUSUARIOS.IdRol = 1049 Then
                Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabRepartir"))
                Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabFz"))
                Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabEstibar"))
                Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabTrasladar"))
            End If

        ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then 'Funcionario
            intNivel = 2
            Me.tsbNuevo.Enabled = False
            'Me.tsbEditar.Text = "Aceptar"

            Me.rbtSeguimiento.Visible = True
            Me.rbtPorAceptar.Checked = True
            Me.rbtPorAprobar.Visible = False
            Me.pnlEstado.Visible = True

            Me.rbtSeguimientoEmbalaje.Visible = True
            Me.rbtPorAceptarEmbalaje.Checked = True
            Me.rbtPorAprobarEmbalaje.Visible = False
            Me.pnlEstadoEmbalaje.Visible = True

            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabRepartir"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabFacturar"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabResumen"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabProvisionar"))
            'Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabRecojer"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabEstibar"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabTrasladar"))

        ElseIf Acceso.SiRol(G_Rol, Me, 1, 3) Then 'Consulta
            intNivel = 3
            Me.tsbNuevo.Enabled = False
            'Me.tsbEditar.Text = "Aprobar"

            Me.rbtSeguimiento.Visible = True
            Me.rbtPorAprobar.Checked = True
            Me.rbtPorAceptar.Visible = False
            Me.pnlEstado.Visible = False

            Me.rbtSeguimientoEmbalaje.Visible = True
            Me.rbtPorAprobarEmbalaje.Checked = True
            Me.rbtPorAceptarEmbalaje.Visible = False
            Me.pnlEstadoEmbalaje.Visible = False

            Me.rbtSeguimientoReparto.Checked = False
            Me.rbtPorAprobarReparto.Checked = True

            Me.tabEstiba.TabPages.Remove(tabEstiba.TabPages("tabSolicitudEstiba"))
            Me.tabTraslado.TabPages.Remove(tabTraslado.TabPages("tabSolicitudTraslado"))

            tsbNuevo.Enabled = False : tsbGrabar.Enabled = False : tsbAnular.Enabled = False
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 4) Then 'Oficina
            intNivel = 4
            Me.tsbNuevo.Enabled = True
            Me.rbtSeguimiento.Checked = True
            Me.pnlOpcion.Visible = False
            Me.pnlEstado.Visible = True

            Me.rbtSeguimientoEmbalaje.Checked = True
            Me.pnlOpcionEmbalaje.Visible = False
            Me.pnlEstadoEmbalaje.Visible = True

            'Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabResumen"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabProvisionar"))

            Me.tabReparto.TabPages.Remove(tabReparto.TabPages("tabAprobar"))
            Me.tabReparto.TabPages.Remove(tabReparto.TabPages("tabGenerarGasto"))
            Me.tabEstiba.TabPages.Remove(tabEstiba.TabPages("tabAprobacionEstiba"))
            Me.tabTraslado.TabPages.Remove(tabTraslado.TabPages("tabAprobacionTraslado"))

            Me.rbtSeguimientoReparto.Checked = True : Me.rbtPorAprobarReparto.Checked = False
            Me.rbtSeguimientoReparto.Visible = False : Me.rbtPorAprobarReparto.Visible = False
        Else
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabRepartir"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabFz"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabFacturar"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabResumen"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabProvisionar"))
            'Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabRecojer"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabEstibar"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabTrasladar"))
            Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabEmbalar"))
            tsbNuevo.Enabled = False : tsbGrabar.Enabled = False : tsbAnular.Enabled = False : tsbEditar.Enabled = False
        End If

        If Not Acceso.SiRol(G_Rol, Me, 1, 1) And Not Acceso.SiRol(G_Rol, Me, 1, 4) Then
            Me.tabFacturacion.TabPages.Remove(tabFacturacion.TabPages("tabListaFactura"))
            Me.tabFacturacion.TabPages.Remove(tabFacturacion.TabPages("tabFactura"))

            ConfigurarDGVImprimir()
            ConfigurarDGVDetalle()
            If Me.dgvImprimir.Rows.Count > 0 Then
                Me.btnImprimir.Enabled = True
            Else
                Me.btnImprimir.Enabled = False
                Me.btnLiquidar.Enabled = False
            End If
        End If

        If Acceso.SiRol(G_Rol, Me, 1, 3) Or Acceso.SiRol(G_Rol, Me, 1, 4) Then
            InicioResumen()
        End If
    End Sub
#End Region

    Private Sub txtCosto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCosto.Enter
        If Val(txtCosto.Text) > 0 Then
            Me.txtCosto.Text = Replace(Me.txtCosto.Text, ",", "")
        Else
            Me.txtCosto.Text = ""
        End If
    End Sub

    Private Sub txtCosto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCosto.GotFocus
        txtCosto.SelectAll()
    End Sub

    Private Sub txtCosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCosto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtCosto.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtKilometro_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKilometro.Enter
        If Val(txtKilometro.Text) > 0 Then
            Me.txtKilometro.Text = Replace(Me.txtKilometro.Text, ",", "")
        Else
            Me.txtKilometro.Text = ""
        End If
    End Sub

    Private Sub txtKilometro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilometro.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCosto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCosto.LostFocus
        If Val(Me.txtCosto.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtCosto.Text)
            Me.txtCosto.Text = Format(dblMonto, "#,###,###0.00")
        Else
            Me.txtCosto.Text = ""
        End If
    End Sub

    Private Sub btnAgregarGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarGE.Click
        Dim intCliente As Integer
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            intCliente = 0
        Else
            intCliente = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
        End If
        Dim intTipo As Integer
        If Acceso.SiRol(G_Rol, Me, 1, 1) Then 'Credito
            intTipo = 1
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 5) Then 'Contado
            intTipo = 2
        End If

        Dim frm As New frmAgregarGuiaEnvio
        frm.IDCliente = intCliente
        frm.Cliente = Me.txtCliente.Text.Trim

        frm.AgenciaDestino = dtoUSUARIOS.iIDAGENCIAS
        frm.NombreAgenciaDestino = dtoUSUARIOS.m_iNombreAgencia

        frm.Tipo = intTipo
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Venta = frm.cboTipo.SelectedIndex
            If AgregarGuiaEnvio(frm) = 0 Then
                MessageBox.Show("Las Guías de Envío ya existen en la Lista", "Agregar Guía de Envío", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MessageBox.Show("La Guía de Envío " & frm.dgvResultado.Rows(0).Cells("guia").Value & " ya existe en la lista", "Agregar Guía de Envío", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAgregarGE.Focus()
            End If
        Else
            Me.btnAgregarGE.Focus()
        End If
    End Sub

    Function AgregarGuiaEnvio(ByVal frm As frmAgregarGuiaEnvio, Optional ByVal opcion As Integer = 1) As Integer
        Dim intRegistros As Integer = 0
        For Each row As DataGridViewRow In frm.dgvResultado.Rows
            If row.Cells(0).Value = 1 Then
                If opcion = 1 Then
                    If Not ExisteValorGrid(Me.dgvGuiaEnvio, 13, row.Cells("id").Value) Then
                        Me.dgvGuiaEnvio.Rows.Add()
                        Me.dgvGuiaEnvio(0, Me.dgvGuiaEnvio.Rows.Count - 1).Value = 0
                        Me.dgvGuiaEnvio(1, Me.dgvGuiaEnvio.Rows.Count - 1).Value = Format(row.Cells("fecha").Value, "dd/MM/yyyy")
                        Me.dgvGuiaEnvio(2, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("idtipo").Value
                        Me.dgvGuiaEnvio(3, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("tipo").Value
                        Me.dgvGuiaEnvio(4, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("comprobante").Value
                        Me.dgvGuiaEnvio(5, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("origen").Value
                        Me.dgvGuiaEnvio(6, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("destino").Value
                        Me.dgvGuiaEnvio(7, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("agencia_origen").Value
                        Me.dgvGuiaEnvio(8, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("agencia_destino").Value
                        Me.dgvGuiaEnvio(9, Me.dgvGuiaEnvio.Rows.Count - 1).Value = Format(row.Cells("total").Value, "###,###,###0.00")
                        Me.dgvGuiaEnvio(10, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("cantidad").Value
                        Me.dgvGuiaEnvio(11, Me.dgvGuiaEnvio.Rows.Count - 1).Value = Format(row.Cells("peso").Value, "###,###,###0.00")
                        Me.dgvGuiaEnvio(12, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("direccion").Value
                        Me.dgvGuiaEnvio(13, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("id").Value
                        Me.dgvGuiaEnvio(14, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("idagencia_origen").Value
                        Me.dgvGuiaEnvio(15, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("idagencia_destino").Value
                        Me.dgvGuiaEnvio(16, Me.dgvGuiaEnvio.Rows.Count - 1).Value = 0
                        intRegistros += 1
                    End If
                Else
                    Me.dgvGuiaEnvio(1, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("fecha").Value
                    Me.dgvGuiaEnvio(2, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("idtipo").Value
                    Me.dgvGuiaEnvio.CurrentRow.Cells(3).Value = row.Cells("tipo").Value
                    Me.dgvGuiaEnvio.CurrentRow.Cells(4).Value = row.Cells("comprobante").Value
                    Me.dgvGuiaEnvio(5, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("origen").Value
                    Me.dgvGuiaEnvio(6, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("destino").Value
                    Me.dgvGuiaEnvio(7, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("agencia_origen").Value
                    Me.dgvGuiaEnvio(8, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("agencia_destino").Value
                    Me.dgvGuiaEnvio(9, Me.dgvGuiaEnvio.Rows.Count - 1).Value = Format(row.Cells("total").Value, "###,###,###0.00")
                    Me.dgvGuiaEnvio(10, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("cantidad").Value
                    Me.dgvGuiaEnvio(11, Me.dgvGuiaEnvio.Rows.Count - 1).Value = Format(row.Cells("peso").Value, "###,###,###0.00")
                    Me.dgvGuiaEnvio(12, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("direccion").Value
                    Me.dgvGuiaEnvio(13, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("id").Value
                    Me.dgvGuiaEnvio(14, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("idagencias").Value
                    Me.dgvGuiaEnvio(15, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("idagencias_destino").Value
                    intRegistros += 1
                End If
            End If
        Next
        Return intRegistros
    End Function

    Sub GrabarSolicitud(ByVal cliente As Integer)
        Try
            Dim intID As Integer, intNumeroSolicitud As Integer, strFecha As String, strObservacion As String
            Dim dblCosto As Double, intUsuario As Integer, strIP As String, dblKm As Double, strHora As String, strLocalidad As String
            Dim intProveedor As Integer, strRuc As String, strRazonSocial As String

            intProveedor = IIf(IsNothing(Me.txtRucProveedorFueraZona.Tag), 0, Val(Me.txtRucProveedorFueraZona.Tag))
            strRuc = Me.txtRucProveedorFueraZona.Text.Trim
            strRazonSocial = Me.txtRazonSocialProveedorFueraZona.Text.Trim

            Dim objLN As New dtoFueraZona
            If intOperacion = Operacion.Nuevo Then
                intID = 0
            Else
                intID = dgvListaSolicitud.CurrentRow.Cells("id").Value
            End If
            intNumeroSolicitud = Me.lblNumeroSolicitud.Text
            strFecha = Me.dtpFechaFueraZona.Value.ToShortDateString
            strObservacion = Me.txtObservacion.Text.Trim
            dblCosto = CDbl(Me.txtCosto.Text)
            dblKm = CDbl(Me.txtKilometro.Text)
            strHora = Me.txtHora.Text
            strLocalidad = Me.txtLocalidad.Text.Trim

            intUsuario = dtoUSUARIOS.IdLogin
            strIP = dtoUSUARIOS.IP

            Dim intCiudad As Integer, intAgencia As Integer, intAgenciaGasto As Integer
            intCiudad = dtoUSUARIOS.m_iIdUnidadAgenciaReal
            intAgencia = dtoUSUARIOS.iIDAGENCIAS

            If Venta = 2 Then 'credito 'contado
                intAgenciaGasto = Me.dgvGuiaEnvio.CurrentRow.Cells("idagencia_destino").Value
            Else
                intAgenciaGasto = 0
            End If

            Dim intIDZona As Integer = objLN.GrabarSolicitud(intID, intNumeroSolicitud, cliente, strObservacion, dblCosto, _
                                                             intCiudad, intAgencia, _
                                                             dblKm, strHora, strLocalidad, intProveedor, strRuc, strRazonSocial, _
                                                             strFecha, intUsuario, strIP, intAgenciaGasto)


            'Actualizar guias de envio
            With Me.dgvGuiaEnvio
                For Each row As DataGridViewRow In .Rows
                    intID = IIf(IsDBNull(row.Cells("id").Value), 0, row.Cells("id").Value)
                    Dim intIDFz As Integer = intIDZona
                    strFecha = row.Cells("fecha").Value
                    Dim intTipo As Integer = row.Cells("idtipo").Value
                    Dim intGuia As Integer = row.Cells("idcomprobante").Value
                    Dim intEstado As Integer = row.Cells("estado").Value
                    Dim strOrigen As String = row.Cells("origen").Value
                    Dim strDestino As String = row.Cells("destino").Value
                    Dim dblTotal As Double = row.Cells("total").Value
                    Dim strGuia As String = row.Cells("comprobante").Value
                    Dim intAgenciaOrigen As Integer = row.Cells("idagencia_origen").Value
                    Dim intAgenciaDestino As Integer = row.Cells("idagencia_destino").Value
                    Dim intCantidad As Integer = row.Cells("cantidad").Value
                    Dim dblPeso As Double = row.Cells("peso").Value
                    Dim strDireccion As String = row.Cells("direccion").Value

                    objLN.GrabarGuiaEnvio(intID, intIDFz, strFecha, intTipo, intGuia, intEstado, strOrigen, strDestino, dblTotal, strGuia, intAgenciaOrigen, intAgenciaDestino, _
                                          intCantidad, dblPeso, strDireccion, _
                                          intUsuario, strIP)
                Next
            End With

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub ListarSolicitud()
        Try
            Dim strEstado As String, intOpcion As Integer = 0, intCiudad As Integer
            Dim strInicio As String, strFin As String
            Dim strComprobante As String

            strInicio = Me.dtpInicioFueraZona.Value.ToShortDateString
            strFin = Me.dtpFinFueraZona.Value.ToShortDateString
            If Me.rbtSeguimiento.Checked Then 'seguimiento
                strEstado = Me.cboEstadoSolicitud.SelectedIndex
            ElseIf Me.rbtPorAceptar.Checked Then
                strInicio = "" : strFin = ""
                If Me.cboEstadoSolicitud.SelectedIndex = 0 Then
                    strEstado = "1,3" 'pendientes y observados
                Else
                    strEstado = IIf(Me.cboEstadoSolicitud.SelectedIndex = 1, 1, 3)
                End If
            ElseIf Me.rbtPorAprobar.Checked Then
                strEstado = "2" 'aceptados
                strInicio = "" : strFin = ""
            End If
            strComprobante = Me.txtComprobanteFueraZonaBuscar.Text.Trim

            Dim obj As New dtoFueraZona
            intCiudad = Me.cboCiudadFueraZona.SelectedValue

            dgvListaSolicitud.DataSource = obj.ListarSolicitud(strEstado, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.IdLogin, intNivel, _
                                                               strInicio, strFin, intCiudad, intOpcion, strComprobante)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MostrarSolicitud(ByVal row As Integer)
        With dgvListaSolicitud
            Me.lblNumeroSolicitud.Text = .Rows(row).Cells("numero_solicitud").Value
            Me.dtpFechaFueraZona.Value = .Rows(row).Cells("fecha_solicitud").Value
            Me.lblOficina.Text = .Rows(row).Cells("oficina").Value
            Me.lblSolicitante.Text = .Rows(row).Cells("solicitante").Value

            Me.txtCodigoCliente.Text = .Rows(row).Cells("codigo").Value
            Me.txtCliente.Text = .Rows(row).Cells("cliente").Value

            Me.txtCosto.Text = Format(.Rows(row).Cells("costo").Value, "###,###,###0.00")
            Me.txtKilometro.Text = IIf(IsDBNull(.Rows(row).Cells("km").Value), "", .Rows(row).Cells("km").Value)
            Me.txtHora.Text = IIf(IsDBNull(.Rows(row).Cells("hora").Value), "", .Rows(row).Cells("hora").Value)
            Me.txtLocalidad.Text = IIf(IsDBNull(.Rows(row).Cells("localidad").Value), "", .Rows(row).Cells("localidad").Value)

            Me.txtRucProveedorFueraZona.Text = IIf(IsDBNull(.CurrentRow.Cells("ruc").Value), "", .CurrentRow.Cells("ruc").Value)
            If Not IsDBNull(.CurrentRow.Cells("id_proveedor").Value) Then
                Me.txtRucProveedorFueraZona.Tag = IIf(.CurrentRow.Cells("id_proveedor").Value = 0, "", (.CurrentRow.Cells("id_proveedor").Value))
            Else
                Me.txtRucProveedorFueraZona.Tag = 0
            End If
            Me.txtRazonSocialProveedorFueraZona.Text = IIf(IsDBNull(.CurrentRow.Cells("proveedor").Value), "", .CurrentRow.Cells("proveedor").Value)
            Me.txtRazonSocialProveedorFueraZona.Enabled = False

            Me.txtObservacion.Text = .Rows(row).Cells("observacion").Value

            If .Rows(row).Cells("idestado").Value = 1 And (intNivel = 1 Or intNivel = 4) Then
                Me.txtCosto.Enabled = True
                Me.txtKilometro.Enabled = True
                Me.txtHora.Enabled = True
                Me.txtLocalidad.Enabled = True
                Me.txtObservacion.Enabled = True
                Me.btnAgregarGE.Enabled = True
                Me.btnEliminarGE.Enabled = True
                Me.dgvGuiaEnvio.Enabled = True
                Me.txtRucProveedorFueraZona.Enabled = True
                Me.tsbGrabar.Enabled = True
            Else
                Me.txtCosto.Enabled = False
                Me.txtKilometro.Enabled = False
                Me.txtHora.Enabled = False
                Me.txtLocalidad.Enabled = False
                Me.txtObservacion.Enabled = False
                Me.btnAgregarGE.Enabled = False
                Me.btnEliminarGE.Enabled = False
                Me.dgvGuiaEnvio.Enabled = False
                Me.txtRucProveedorFueraZona.Enabled = False
                Me.txtRazonSocialProveedorFueraZona.Enabled = False
                Me.tsbGrabar.Enabled = False
            End If
        End With
    End Sub

    Sub GrabarSolicitud()
        Try
            Dim intCliente As Integer
            If intOperacion = Operacion.Nuevo Then
                If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
                    intCliente = 0
                Else
                    intCliente = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
                End If

                If intCliente = 0 Then
                    MessageBox.Show("Seleccione el Cliente", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtCliente.Focus()
                    Return
                End If
            End If

            If Val(Me.txtCosto.Text) = 0 Then
                MessageBox.Show("Ingrese Costo", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtCosto.Focus()
                Return
            End If

            If Me.txtLocalidad.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese la Localidad de Entrega", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtLocalidad.Text = ""
                Me.txtLocalidad.Focus()
                Return
            End If

            If Val(Me.txtKilometro.Text) = 0 Then
                MessageBox.Show("Ingrese la Distancia en Kilómetros", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtKilometro.Focus()
                Return
            End If

            txtHora_LostFocus(Nothing, Nothing)
            If Me.txtHora.Text = "00:00" Then
                MessageBox.Show("Ingrese la Distancia en Horas", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtHora.Focus()
                Return
            End If

            If Mid(Trim(txtHora.Text), 1, 2) > "23" Or Mid(Trim(txtHora.Text), 4, 2) > "59" Then
                MessageBox.Show("Ingrese la Distancia correcta en Horas", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtHora.Focus()
                Return
            End If

            Dim blnRucValido As Boolean = fnValidarRUC(txtRucProveedorFueraZona.Text)
            intLlamada = 1
            Me.txtRucProveedorFueraZona_LostFocus(Nothing, Nothing)
            intLlamada = 0
            If Not blnRucValido Then
                MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtRucProveedorFueraZona.Focus()
                Return
            End If

            If Me.txtRazonSocialProveedorFueraZona.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Razón Social", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtRazonSocialProveedorFueraZona.Text = ""
                txtRazonSocialProveedorFueraZona.Focus()
                Return
            End If

            If Me.txtObservacion.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese la Observación", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtObservacion.Text = ""
                Me.txtObservacion.Focus()
                Return
            End If

            If Me.dgvGuiaEnvio.Rows.Count = 0 Or Not dtoUtilitario.FilasGridVisible(Me.dgvGuiaEnvio) Then
                MessageBox.Show("Seleccione las Guías de Envío", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAgregarGE.Focus()
                Return
            End If

            'hlamas 26-09-2016
            'Valida que comprobante no esté asociado a una solicitud pendiente,aceptada,aprobada u observada
            'With Me.dgvGuiaEnvio
            '    Dim obj As New dtoFueraZona
            '    Dim strMensaje As String
            '    For Each row As DataGridViewRow In .Rows
            '        Dim intTipo As Integer = row.Cells("idtipo").Value
            '        Dim intGuia As Integer = row.Cells("idcomprobante").Value

            '        Dim blnDisponible As Boolean = obj.ComprobanteDisponible(intTipo, intGuia)
            '        If Not blnDisponible Then 'comprobante no está disponible
            '            strMensaje = "El Comprobante " & row.Cells("tipo").Value & " " & row.Cells("comprobante").Value & " "
            '            strMensaje = strMensaje & "no está Disponible" & Chr(13)
            '            strMensaje = strMensaje & "Se encuentra asociado a una solicitud activa"
            '            MessageBox.Show(strMensaje, "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '            Return
            '        End If
            '    Next
            'End With

            'graba solicitud fuera de zona
            Cursor = Cursors.WaitCursor
            GrabarSolicitud(intCliente)
            ListarSolicitud()

            Dim intID As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("id").Value
            ListarGuiaEnvio(intID, Me.dgvGuiaEnvio)

            If Me.dgvListaSolicitud.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                If intNivel = 1 Or intNivel = 4 Then
                    Me.tsbAnular.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                End If
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
            Me.tabFueraZona.SelectedTab = Me.tabFueraZona.TabPages("tabListaZona")

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboEstadoSolicitud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstadoSolicitud.SelectedIndexChanged
        'Me.btnConsultarFueraZona_Click(Nothing, Nothing)
        'ListarSolicitud()
        'If Me.dgvListaSolicitud.Rows.Count > 0 Then
        '    Me.tsbEditar.Enabled = True
        '    If Me.dgvListaSolicitud.CurrentRow.Cells("idestado").Value = 1 And (intNivel = 1 Or intNivel = 4) Then
        '        Me.tsbAnular.Enabled = True
        '    Else
        '        Me.tsbAnular.Enabled = False
        '    End If
        'Else
        '    Me.tsbEditar.Enabled = False
        '    Me.tsbAnular.Enabled = False
        'End If
    End Sub

    Private Sub dgvListaSolicitud_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListaSolicitud.DoubleClick
        If Me.dgvListaSolicitud.Rows.Count > 0 Then
            tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Sub ListarGuiaEnvio(ByVal id As Integer, ByVal dgv As DataGridView)
        Dim objLN As New dtoFueraZona
        Dim dt As DataTable = objLN.ListarGuiaEnvio(id)
        With dgv
            .Rows.Clear()
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .Rows.Add()
                    dgv(0, .Rows.Count - 1).Value = row.Item("id")
                    dgv(1, .Rows.Count - 1).Value = Format(row.Item("fecha"), "dd/MM/yyyy")
                    dgv(2, .Rows.Count - 1).Value = row.Item("idtipo")
                    dgv(3, .Rows.Count - 1).Value = row.Item("tipo")
                    dgv(4, .Rows.Count - 1).Value = row.Item("guia")
                    dgv(5, .Rows.Count - 1).Value = row.Item("origen")
                    dgv(6, .Rows.Count - 1).Value = row.Item("destino")
                    dgv(7, .Rows.Count - 1).Value = row.Item("agencia_origen")
                    dgv(8, .Rows.Count - 1).Value = row.Item("agencia_destino")
                    dgv(9, .Rows.Count - 1).Value = row.Item("total")
                    dgv(10, .Rows.Count - 1).Value = row.Item("cantidad")
                    dgv(11, .Rows.Count - 1).Value = row.Item("peso")
                    dgv(12, .Rows.Count - 1).Value = row.Item("direccion")

                    dgv(13, .Rows.Count - 1).Value = row.Item("idguia")
                    dgv(14, .Rows.Count - 1).Value = row.Item("idagencia_origen")
                    dgv(15, .Rows.Count - 1).Value = row.Item("idagencia_destino")

                    dgv(16, .Rows.Count - 1).Value = row.Item("estado")
                Next
            End If
        End With
    End Sub

    Private Sub dgvGuiaEnvio_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvGuiaEnvio.RowsAdded
        Me.btnEliminarGE.Enabled = Me.dgvGuiaEnvio.Rows.Count > 0 And Me.btnAgregarGE.Enabled
    End Sub

    Private Sub dgvGuiaEnvio_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvGuiaEnvio.RowsRemoved
        Me.btnEliminarGE.Enabled = Me.dgvGuiaEnvio.Rows.Count > 0
    End Sub

    Private Sub btnEliminarGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarGE.Click
        With dgvGuiaEnvio
            If .Rows.Count > 0 Then
                Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está Seguro de Desactivar la Guía de Envío Seleccionada?", "Desactivar Guía de Envío", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    If dgvGuiaEnvio.CurrentRow.Cells("estado").Value = 0 Then
                        .Rows.Remove(.CurrentRow)
                    Else
                        dgvGuiaEnvio.CurrentRow.Cells("estado").Value = 2
                        dgvGuiaEnvio.CurrentRow.Visible = False
                    End If
                    If Not dtoUtilitario.FilasGridVisible(Me.dgvGuiaEnvio) Then
                        Me.btnEliminarGE.Enabled = False
                    End If
                    If Me.btnEliminarGE.Enabled Then
                        Dim intFila As Integer = dtoUtilitario.FilaGridVisiblePrimera(Me.dgvGuiaEnvio)
                        .Rows(intFila).Selected = True
                        .CurrentCell = .Rows(intFila).Cells(1)
                    End If
                End If
            End If
        End With
    End Sub

    Sub ControlaOpcion() Handles rbtSeguimiento.CheckedChanged, rbtPorAceptar.CheckedChanged, rbtPorAprobar.CheckedChanged
        Me.txtComprobanteFueraZonaBuscar.Text = ""
        If rbtSeguimiento.Checked Then
            Me.pnlEstado.Visible = True
            Me.lblComprobanteFueraZonaBuscar.Visible = True
            Me.txtComprobanteFueraZonaBuscar.Visible = True
            ActualizaCombo()
            If intNivel = 2 Or intNivel = 3 Then
                Me.cboEstadoSolicitud.SelectedIndex = 1
            End If

            If tabFueraZona.TabPages.IndexOf(tabAceptacion) > -1 Then
                Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabAceptacionZona"))
            End If
            If tabFueraZona.TabPages.IndexOf(tabSolicitud) = -1 Then
                Me.tabFueraZona.TabPages.Add(tabSolicitud)
            End If
            If tabFueraZona.TabPages.IndexOf(tabAprobacion) > -1 Then
                Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabAprobacionZona"))
            End If
            'If intNivel2 = 2 Then
            '    If tabFueraZona.TabPages.IndexOf(tabFacturar) >= 1 Then
            '        Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabImpresionZona"))
            '    End If
            '    If tabFueraZona.TabPages.IndexOf(tabFacturar) = -1 Then
            '        Me.tabFueraZona.TabPages.Add(tabFacturar)
            '    End If
            'End If
        ElseIf rbtPorAceptar.Checked Then
            Me.pnlEstado.Visible = True
            Me.lblComprobanteFueraZonaBuscar.Visible = False
            Me.txtComprobanteFueraZonaBuscar.Visible = False
            ActualizaCombo(2)

            RemoveHandler cboEstadoSolicitud.SelectedIndexChanged, AddressOf cboEstadoSolicitud_SelectedIndexChanged
            Me.cboEstadoSolicitud.SelectedIndex = 0
            AddHandler cboEstadoSolicitud.SelectedIndexChanged, AddressOf cboEstadoSolicitud_SelectedIndexChanged

            If tabFueraZona.TabPages.IndexOf(tabSolicitud) > -1 Then
                Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabSolicitudZona"))
            End If
            If tabFueraZona.TabPages.IndexOf(tabAceptacion) = -1 Then
                Me.tabFueraZona.TabPages.Add(tabAceptacion)
            End If
            If tabFueraZona.TabPages.IndexOf(tabAprobacion) > -1 Then
                Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabAprobacionZona"))
            End If
        ElseIf rbtPorAprobar.Checked Then
            Me.pnlEstado.Visible = False
            Me.lblComprobanteFueraZonaBuscar.Visible = False
            Me.txtComprobanteFueraZonaBuscar.Visible = False
            If tabFueraZona.TabPages.IndexOf(tabSolicitud) > -1 Then
                Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabSolicitudZona"))
            End If
            If tabFueraZona.TabPages.IndexOf(tabAprobacion) = -1 Then
                Me.tabFueraZona.TabPages.Add(tabAprobacion)
            End If
            If tabFueraZona.TabPages.IndexOf(tabAceptacion) > -1 Then
                Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabAceptacionZona"))
            End If
            'If intNivel2 = 2 Then
            '    If tabFueraZona.TabPages.IndexOf(tabFacturar) >= 1 Then
            '        Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabImpresionZona"))
            '    End If
            '    If tabFueraZona.TabPages.IndexOf(tabFacturar) = -1 Then
            '        Me.tabFueraZona.TabPages.Add(tabFacturar)
            '    End If
            'End If
        End If
        ListarSolicitud()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub txtPrecioAceptacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecioAceptacion.Enter
        If Val(txtPrecioAceptacion.Text) > 0 Then
            Me.txtPrecioAceptacion.Text = Replace(Me.txtPrecioAceptacion.Text, ",", "")
        Else
            Me.txtPrecioAceptacion.Text = "0.00"
        End If
    End Sub

    Private Sub txtPrecioAceptacion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecioAceptacion.GotFocus
        txtPrecioAceptacion.SelectAll()
    End Sub

    Private Sub txtPrecioAceptacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioAceptacion.KeyPress
        If Not ValidarNumeroReal(e.KeyChar, Me.txtPrecioAceptacion.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecioAceptacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecioAceptacion.LostFocus
        If Val(Me.txtPrecioAceptacion.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtPrecioAceptacion.Text)
            Me.txtPrecioAceptacion.Text = Format(dblMonto, "#,###,###0.00")
        Else
            Me.txtPrecioAceptacion.Text = "0.00"
        End If
    End Sub

    Private Sub btnAceptarAceptacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarAceptacion.Click
        If Val(Me.txtPrecioAceptacion.Text) = 0 Then
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("El Precio es 0" & Chr(13) & Chr(13) & "¿Está seguro de Continuar?", "Aceptar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.No Then
                Me.txtPrecioAceptacion.Focus()
                Return
            End If
        End If

        If Me.cboContactoAceptacion.SelectedValue = 0 Then
            MessageBox.Show("Seleccione el Contacto", "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboContactoAceptacion.Focus()
            Me.cboContactoAceptacion.DroppedDown = True
            Return
        End If

        If Me.rbtNoAceptacion.Checked AndAlso Me.txtObservacionAceptacion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Motivo", "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtObservacionAceptacion.Text = ""
            Me.txtObservacionAceptacion.Focus()
            Return
        End If

        Aceptar()
    End Sub

    Sub LimpiarAceptacion()
        Me.lblCodigoAceptacion.Text = ""
        Me.lblRazonSocialAceptacion.Text = ""
        Me.lblOficinaAceptacion.Text = ""
        Me.lblSolicitanteAceptacion.Text = ""
        Me.lblLocalidadAceptacion.Text = ""
        Me.lblKmAceptacion.Text = ""
        Me.lblHoraAceptacion.Text = ""
        Me.lblObservacionAceptacion.Text = ""
        Me.dgvGuiaEnvioAceptacion.Rows.Clear()
        Me.lblCostoAceptacion.Text = ""
        Me.txtPrecioAceptacion.Text = ""
        Me.cboContactoAceptacion.DataSource = Nothing
        Me.rbtSiAceptacion.Checked = True
        Me.txtObservacionAceptacion.Text = ""
    End Sub

    Function ObtieneSuma(ByVal dgv As DataGridView, ByVal columna As Integer) As Double
        Try
            Dim dblSuma As Double = 0
            For Each row As DataGridViewRow In dgv.Rows
                dblSuma += row.Cells(columna).Value
            Next
            Return dblSuma

        Catch
            Return 0
        End Try
    End Function

    Private Sub tabFueraZona_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabFueraZona.SelectedIndexChanged
        Me.tsbImprimir.Enabled = False
        If tabFueraZona.SelectedTab Is tabFueraZona.TabPages("tabListaZona") Then
            If intNivel = 1 Or intNivel = 4 Then
                Me.tsbNuevo.Enabled = True
            Else
                Me.tsbNuevo.Enabled = False
            End If
            Me.tsbGrabar.Enabled = False
            If Me.dgvListaSolicitud.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                If Me.dgvListaSolicitud.CurrentRow.Cells("idestado").Value = 1 And (intNivel = 1 Or intNivel = 4) Then
                    Me.tsbAnular.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                End If
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
            ConfigurarDGVGuiaEnvio()

        ElseIf tabFueraZona.SelectedTab Is tabFueraZona.TabPages("tabSolicitudZona") Then
            LimpiarSolicitud()
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            If Me.dgvListaSolicitud.Rows.Count > 0 Then
                tsbEditar_Click(Nothing, Nothing)
            Else
                tsbNuevo_Click(Nothing, Nothing)
                'Me.tsbGrabar.Enabled = False
            End If
        ElseIf tabFueraZona.SelectedTab Is tabFueraZona.TabPages("tabaceptacionzona") Then
            LimpiarAceptacion()
            Me.tsbGrabar.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            ConfigurarDGVGuiaEnvioAceptacion()
            If Me.dgvListaSolicitud.Rows.Count > 0 Then
                Dim intEstado As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("idestado").Value
                If intEstado = 1 Then
                    Me.txtPrecioAceptacion.Enabled = True
                Else
                    Me.txtPrecioAceptacion.Enabled = False
                End If
                Me.cboContactoAceptacion.Enabled = True
                Me.rbtSiAceptacion.Enabled = True
                Me.rbtNoAceptacion.Enabled = True
                Me.txtObservacionAceptacion.Enabled = True
                Me.btnAceptarAceptacion.Enabled = True
                Me.grbGuiaEnvioAceptacion.Enabled = True

                Dim intCliente As Integer = dgvListaSolicitud.CurrentRow.Cells("idcliente").Value
                LlenarCombo(intCliente)

                Me.lblCodigoAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("codigo").Value
                Me.lblRazonSocialAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("cliente").Value
                Me.lblOficinaAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("oficina").Value
                Me.lblSolicitanteAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("solicitante").Value

                Me.lblLocalidadAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("localidad").Value
                Me.lblKmAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("km").Value
                Me.lblHoraAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("hora").Value

                If IsDBNull(Me.dgvListaSolicitud.CurrentRow.Cells("observacion_observacion").Value) Then
                    Me.lblObservacionAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("observacion").Value
                Else
                    Me.lblObservacionAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("observacion_observacion").Value
                End If

                Me.lblCostoAceptacion.Text = Format(CDbl(Me.dgvListaSolicitud.CurrentRow.Cells("costo").Value), "###,###,###0.00")

                If intEstado = 1 Then
                    Me.txtPrecioAceptacion.Text = Format(CDbl(Me.lblCostoAceptacion.Text) * 2, "###,###,###0.00")
                Else
                    Me.txtPrecioAceptacion.Text = Format(IIf(IsDBNull(Me.dgvListaSolicitud.CurrentRow.Cells("precio_observacion").Value), Me.dgvListaSolicitud.CurrentRow.Cells("precio").Value, Me.dgvListaSolicitud.CurrentRow.Cells("precio_observacion").Value), "###,###,###0.00")
                End If

                Dim intID As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("id").Value
                ListarGuiaEnvio(intID, Me.dgvGuiaEnvioAceptacion)

                Me.cboContactoAceptacion.Focus()
                Me.txtPrecioAceptacion.Focus()
            Else
                Me.txtPrecioAceptacion.Enabled = False
                Me.cboContactoAceptacion.Enabled = False
                Me.rbtSiAceptacion.Enabled = False
                Me.rbtNoAceptacion.Enabled = False
                Me.txtObservacionAceptacion.Enabled = False
                Me.btnAceptarAceptacion.Enabled = False
                Me.grbGuiaEnvioAceptacion.Enabled = False
            End If

        ElseIf tabFueraZona.SelectedTab Is tabFueraZona.TabPages("tabaprobacionzona") Then
            LimpiarAprobacion()
            Me.tsbGrabar.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            ConfigurarDGVGuiaEnvioAprobacion()
            If Me.dgvListaSolicitud.Rows.Count > 0 Then
                Me.rbtSiAprobacion.Enabled = True
                Me.rbtNoAprobacion.Enabled = True
                Me.txtObservacionAprobacion.Enabled = True
                Me.btnAceptarAprobacion.Enabled = True
                Me.grbGuiaEnvioAprobacion.Enabled = True

                Me.lblCodigoAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("codigo").Value
                Me.lblRazonSocialAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("cliente").Value
                Me.lblContactoAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("contacto").Value

                Me.lblOficinaAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("oficina").Value
                Me.lblSolicitanteAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("solicitante").Value
                Me.lblFuncionarioAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("funcionario").Value

                Me.lblLocalidadAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("localidad").Value
                Me.lblKmAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("km").Value
                Me.lblHoraAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("hora").Value

                Me.lblCostoAprobacion.Text = Format(CDbl(Me.dgvListaSolicitud.CurrentRow.Cells("costo").Value), "###,###,###0.00")
                Me.lblPrecioAceptadoAprobacion.Text = Format(CDbl(Me.dgvListaSolicitud.CurrentRow.Cells("total").Value), "###,###,###0.00")
                Me.txtPrecioAprobacion.Text = Format(CDbl(Me.dgvListaSolicitud.CurrentRow.Cells("total").Value), "###,###,###0.00")

                Dim intID As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("id").Value
                ListarGuiaEnvio(intID, Me.dgvGuiaEnvioAprobacion)

                Dim dblPeso As Double = ObtieneSuma(Me.dgvGuiaEnvioAprobacion, 9)
                Dim dblMonto As Double = ObtieneSuma(Me.dgvGuiaEnvioAprobacion, 7)

                Me.lblPesoAprobacion.Text = Format(dblPeso, "0.00")
                Me.lblMontoAprobacion.Text = Format(dblMonto, "0.00")

                Me.btnAceptarAprobacion.Focus()
            Else
                Me.rbtSiAprobacion.Enabled = False
                Me.rbtNoAprobacion.Enabled = False
                Me.txtObservacionAprobacion.Enabled = False
                Me.btnAceptarAprobacion.Enabled = False
                Me.grbGuiaEnvioAprobacion.Enabled = False
            End If
        End If
    End Sub

    Private Sub AceptarSolicitud(ByVal estado As Integer)
        Cursor = Cursors.WaitCursor
        Try
            Dim objLN As New dtoFueraZona
            Dim intID As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("id").Value
            Dim dblPrecio As Double, strObservacion As String, intContacto As Integer
            If estado = 2 Or estado = 3 Then
                dblPrecio = CDbl(Me.txtPrecioAceptacion.Text)
                intContacto = Me.cboContactoAceptacion.SelectedValue
                strObservacion = ""
            Else
                strObservacion = Me.txtObservacionAceptacion.Text.Trim
                dblPrecio = 0
                intContacto = 0
            End If
            objLN.AceptarSolicitud(intID, estado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dblPrecio, strObservacion, intContacto)

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub LimpiarSolicitud()
        Me.lblNumeroSolicitud.Text = ""
        Me.dtpFechaFueraZona.Value = Format(FechaServidor, "Short Date")
        Me.lblOficina.Text = dtoUSUARIOS.m_iNombreAgencia
        Me.lblSolicitante.Text = ""
        Me.txtCodigoCliente.Text = ""
        Me.txtCliente.Text = ""
        Me.txtCosto.Text = ""
        Me.txtKilometro.Text = ""
        Me.txtHora.Text = ""
        Me.txtLocalidad.Text = ""
        Me.txtObservacion.Text = ""
        Me.txtRucProveedorFueraZona.Text = ""
        Me.txtRazonSocialProveedorFueraZona.Text = ""
        Me.dgvGuiaEnvio.Rows.Clear()
    End Sub

    Sub Aceptar()
        Try
            If Me.rbtSiAceptacion.Checked Then 'acepta
                Dim strMensaje As String = "¿Está Seguro de Aceptar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aceptar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim intEstado As Integer = IIf(Me.dgvListaSolicitud.CurrentRow.Cells("idestado").Value = 1, 2, 3)
                    AceptarSolicitud(intEstado)
                    If intEstado = 2 Then
                        MessageBox.Show("Solicitud Aceptada", "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    Me.ListarSolicitud()
                    tabFueraZona.SelectedTab = tabFueraZona.TabPages("tabListaZona")
                    Cursor = Cursors.Default
                End If
            Else 'no acepta
                If MessageBox.Show("¿Está Seguro de No Aceptar la Solicitud?", "Aceptar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    AceptarSolicitud(5)
                    MessageBox.Show("Solicitud no Aceptada", "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitud()
                    tabFueraZona.SelectedTab = tabFueraZona.TabPages("tabListaZona")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtSiAprobacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiAprobacion.CheckedChanged
        Me.txtPrecioAprobacion.Text = Me.lblPrecioAceptadoAprobacion.Text
        Me.txtPrecioAprobacion.Enabled = False
        Me.txtObservacionAprobacion.Text = ""
        Me.txtObservacionAprobacion.Enabled = False
        Me.btnAceptarAprobacion.Focus()
    End Sub

    Private Sub rbtNoAprobacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoAprobacion.CheckedChanged
        Me.txtPrecioAprobacion.Text = ""
        Me.txtPrecioAprobacion.Enabled = False
        Me.txtObservacionAprobacion.Text = ""
        Me.txtObservacionAprobacion.Enabled = True
        Me.txtObservacionAprobacion.Focus()
    End Sub

    Private Sub rbtPrecioAceptacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPrecioAceptacion.CheckedChanged
        Me.txtPrecioAprobacion.Enabled = True
        Me.txtPrecioAprobacion.Text = Me.lblPrecioAceptadoAprobacion.Text
        Me.txtObservacionAprobacion.Text = ""
        Me.txtObservacionAprobacion.Enabled = True
        Me.txtPrecioAprobacion.Focus()
    End Sub

    Private Sub txtObservacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservacion.Enter
        txtObservacion.SelectAll()
    End Sub

    Private Sub txtObservacionAceptacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservacionAceptacion.Enter
        txtObservacionAceptacion.SelectAll()
    End Sub

    Sub LimpiarAprobacion()
        Me.lblCodigoAprobacion.Text = ""
        Me.lblRazonSocialAprobacion.Text = ""
        Me.lblOficinaAprobacion.Text = ""
        Me.lblSolicitanteAprobacion.Text = ""
        Me.dgvGuiaEnvioAprobacion.Rows.Clear()
        Me.lblLocalidadAprobacion.Text = ""
        Me.lblKmAprobacion.Text = ""
        Me.lblHoraAprobacion.Text = ""
        Me.lblCostoAprobacion.Text = ""
        Me.txtPrecioAprobacion.Text = ""
        Me.lblContactoAprobacion.Text = ""
        Me.lblFuncionarioAprobacion.Text = ""
        Me.lblPrecioAceptadoAprobacion.Text = ""
        Me.rbtSiAprobacion.Checked = True
        Me.txtObservacionAprobacion.Text = ""
        Me.lblPesoAprobacion.Text = ""
        Me.lblMontoAprobacion.Text = ""
    End Sub

    Private Sub btnAceptarAprobacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarAprobacion.Click
        If Not Me.rbtNoAprobacion.Checked Then
            If Val(Me.txtPrecioAprobacion.Text) = 0 Then
                Dim dlgRespuesta As DialogResult
                dlgRespuesta = MessageBox.Show("El Precio es 0" & Chr(13) & Chr(13) & "¿Está seguro de Continuar?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.No Then
                    Me.rbtPrecioAceptacion.Checked = True
                    Me.txtPrecioAceptacion.Enabled = True
                    Me.txtPrecioAceptacion.Focus()
                    Return
                End If
            End If
            If Me.rbtPrecioAceptacion.Checked Then
                If CDbl(Me.txtPrecioAprobacion.Text) = CDbl(Me.lblPrecioAceptadoAprobacion.Text) Then
                    MessageBox.Show("El Precio Modificado debe ser diferente al Precio Aceptado", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtPrecioAprobacion.Focus()
                    Return
                End If
            End If
        ElseIf Me.rbtNoAprobacion.Checked AndAlso Me.txtObservacionAprobacion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Motivo", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtObservacionAprobacion.Text = ""
            Me.txtObservacionAprobacion.Focus()
            Return
        End If

        Aprobar()

    End Sub

    Sub Aprobar()
        Try
            If Me.rbtSiAprobacion.Checked Then 'aprueba
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    AprobarSolicitud(4)
                    MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitud()
                    tabFueraZona.SelectedTab = tabFueraZona.TabPages("tabListaZona")
                    Cursor = Cursors.Default
                End If
            ElseIf Me.rbtNoAprobacion.Checked Then 'no aprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    AprobarSolicitud(6)
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitud()
                    tabFueraZona.SelectedTab = tabFueraZona.TabPages("tabListaZona")
                    Cursor = Cursors.Default
                End If
            Else 'solicitud observada con precio modificado
                Dim strMensaje As String = "¿Está Seguro de Modificar el Precio Aceptado por el Cliente?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    AprobarSolicitud(3)
                    MessageBox.Show("Solicitud Actualizada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitud()
                    tabFueraZona.SelectedTab = tabFueraZona.TabPages("tabListaZona")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AprobarSolicitud(ByVal estado As Integer)
        Cursor = Cursors.WaitCursor
        Try
            Dim objLN As New dtoFueraZona
            Dim intID As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("id").Value
            Dim dblPrecio As Double, strObservacion As String
            If estado = 4 Then
                dblPrecio = CDbl(Me.txtPrecioAprobacion.Text)
                strObservacion = ""
            ElseIf estado = 6 Then
                strObservacion = Me.txtObservacionAprobacion.Text.Trim
                dblPrecio = 0
            Else 'estado=3
                dblPrecio = CDbl(Me.txtPrecioAprobacion.Text)
                If Me.txtObservacionAprobacion.Text.Trim.Length > 0 Then
                    strObservacion = Me.txtObservacionAprobacion.Text.Trim
                Else
                    txtObservacion.Text = ""
                End If
            End If
            objLN.AprobarSolicitud(intID, estado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dblPrecio, strObservacion)

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Anular()
        Try
            Dim objLN As New dtoFueraZona

            Dim intID As Integer = dgvListaSolicitud.CurrentRow.Cells("id").Value
            objLN.AnularSolicitud(intID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservacion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvListaSolicitud_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaSolicitud.RowEnter
        If Me.dgvListaSolicitud.Rows.Count > 0 Then
            If Me.dgvListaSolicitud.Rows(e.RowIndex).Cells("idestado").Value = 1 And (intNivel = 1 Or intNivel = 4) Then
                Me.tsbAnular.Enabled = True
            Else
                Me.tsbAnular.Enabled = False
            End If
        End If
    End Sub

    Sub ActualizaCombo(Optional ByVal opcion As Integer = 1)
        Me.cboEstadoSolicitud.Items.Clear()
        If opcion = 1 Then
            Me.cboEstadoSolicitud.Items.Add("(TODOS)")
            Me.cboEstadoSolicitud.Items.Add("PENDIENTE")
            Me.cboEstadoSolicitud.Items.Add("ACEPTADO")
            Me.cboEstadoSolicitud.Items.Add("OBSERVADO")
            Me.cboEstadoSolicitud.Items.Add("APROBADO")
            Me.cboEstadoSolicitud.Items.Add("NO ACEPTADO")
            Me.cboEstadoSolicitud.Items.Add("DESAPROBADO")
            Me.cboEstadoSolicitud.Items.Add("ANULADO")
        Else
            Me.cboEstadoSolicitud.Items.Add("(TODOS)")
            Me.cboEstadoSolicitud.Items.Add("PENDIENTE")
            Me.cboEstadoSolicitud.Items.Add("OBSERVADO")
        End If
    End Sub

    Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged
        Me.dgvGuiaEnvio.Rows.Clear()
    End Sub

    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Me.dgvGuiaEnvio.Rows.Clear()
    End Sub

    Sub ListarGastoProveedor()
        Try
            Dim dt As DataTable
            Dim obj As New Cls_Gasto_LN
            Dim intEstado As Integer = -1
            If Me.cboEstadoFacturacion.SelectedIndex > 0 Then
                intEstado = IIf(Me.cboEstadoFacturacion.SelectedIndex = 1, 0, 1)
            End If

            dt = obj.ListarGastoProveedor(dtoUSUARIOS.m_idciudad, Me.dtpInicioLista.Value.ToShortDateString, Me.dtpFinLista.Value.ToShortDateString, _
            Me.cboConceptoFacturacion.SelectedIndex, intEstado)
            With Me.cboProveedorFacturacion
                .ValueMember = "id"
                .DisplayMember = "descripcion"
                .DataSource = dt
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboEstadoFacturacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstadoFacturacion.SelectedIndexChanged
        'btnFiltrar_Click(Nothing, Nothing)
        ListarGastoProveedor()
    End Sub

    Private Sub dtpInicioLista_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicioLista.ValueChanged
        'btnFiltrar_Click(Nothing, Nothing)
        ListarGastoProveedor()
    End Sub

    Private Sub dtpFinLista_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFinLista.ValueChanged
        'btnFiltrar_Click(Nothing, Nothing)
        ListarGastoProveedor()
    End Sub

    Private Sub txtKilometro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKilometro.LostFocus
        If Val(Me.txtKilometro.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtKilometro.Text)
            Me.txtKilometro.Text = Format(dblMonto, "#,###,###0")
        Else
            Me.txtKilometro.Text = ""
        End If
    End Sub

    Private Sub txtHora_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHora.GotFocus
        txtHora.SelectAll()
    End Sub

    Private Sub txtHora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHora.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtHora_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHora.LostFocus
        Dim strHora As String, strMinuto As String, strTexto As String = "", intPosicion As Integer, intLongitud As Integer

        strTexto = Me.txtHora.Text.Trim
        intPosicion = strTexto.IndexOf(":")
        intPosicion += 1
        intLongitud = strTexto.Length

        strHora = txtHora.Text.Substring(0, 2)

        If intLongitud > intPosicion Then
            strMinuto = txtHora.Text.Trim.Substring(intPosicion, intLongitud - intPosicion)
        Else
            strMinuto = "0"
        End If

        If Val(strHora) = 0 Then strHora = "0"
        strHora = strHora.Trim.PadLeft(2, "0")
        strMinuto = strMinuto.Trim.PadLeft(2, "0")

        strTexto = strHora.Trim & ":" & strMinuto.Trim

        Me.txtHora.Mask = ""
        Me.txtHora.Text = strTexto
        Me.txtHora.Mask = "00:00"
        Me.txtHora.Refresh()
    End Sub

    Private Sub txtLocalidad_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalidad.Enter
        Me.txtLocalidad.SelectAll()
    End Sub

    Private Sub txtLocalidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocalidad.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboHoraSalida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHoraSalida.SelectedIndexChanged
        intIngresa = 0
        'Me.btnConsultarListaReparto_Click(Nothing, Nothing)
    End Sub

    '----------------------------------------------------Recojo------------------------------------------------------
    Function ObtieneItemActivo(ByVal dgv As DataGridView) As Integer
        Dim i As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells("estado").Value < 2 Then
                i += 1
            End If
        Next
        Return i
    End Function

    Sub GrabarSolicitudRecojo(Optional ByRef id As Integer = 0)
        Dim dblMonto As Double, dblMontoTarifa As Double
        If Val(Me.lblMontoCiudad.Text) = 0 Then
            dblMonto = 0
        Else
            dblMonto = CType(Me.lblMontoRecojo.Text, Double) 'CType(Me.lblMontoCiudad.Text, Double)
        End If
        If dblMonto = 0 Then
            MessageBox.Show("Ingrese Monto", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtTiempoCiudad.Focus()
            Return
        End If
        If Val(Me.lblTarifaCiudad.Text) = 0 Then
            dblMontoTarifa = 0
        Else
            dblMontoTarifa = CType(Me.lblTarifaCiudad.Text, Double) 'CType(Me.lblMontoCiudad.Text, Double)
        End If

        Dim blnRucValido As Boolean = fnValidarRUC(txtRucProveedorReparto.Text)
        intLlamada = 1
        Me.txtRucProveedorReparto_LostFocus(Nothing, Nothing)
        intLlamada = 0
        If Not blnRucValido Then
            MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRucProveedorReparto.Focus()
            Return
        End If

        If Me.txtRazonSocialProveedorReparto.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Razón Social", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRazonSocialProveedorReparto.Text = ""
            txtRazonSocialProveedorReparto.Focus()
            Return
        End If

        If ObtieneItemActivo(Me.dgvRecojo) = 0 Then
            MessageBox.Show("Ingrese la GRT", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtGrtRecojo.Focus()
            Return
        End If
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable
            Dim intID As Integer, intID_2 As Integer
            Dim intTipo As Integer, intComprobante As Integer, intEstado As Integer
            Dim intProveedor As Integer, strRuc As String, strRazonSocial As String
            Dim intTipoGasto As Integer

            intProveedor = IIf(IsNothing(Me.txtRucProveedorReparto.Tag), 0, Val(Me.txtRucProveedorReparto.Tag))
            strRuc = Me.txtRucProveedorReparto.Text.Trim
            strRazonSocial = Me.txtRazonSocialProveedorReparto.Text.Trim

            If Me.lblTipoPago.Text.Trim.Length > 0 Then
                intTipoGasto = Me.lblTipoPago.Tag
            Else
                If Me.chkTipoPagoAdicional.Checked Then
                    intTipoGasto = 10
                Else
                    intTipoGasto = 0
                End If
            End If

            If intOperacion = Operacion.Nuevo Then
                intID = 0 : intID_2 = 0
            Else
                intID = Me.dgvLista.CurrentRow.Cells("id").Value
            End If
            For Each row As DataGridViewRow In Me.dgvRecojo.Rows
                intEstado = row.Cells("estado").Value
                dt = obj.GrabarSolicitudRecojo(intID, dtoUSUARIOS.m_idciudad, Me.dtpFechaOperacion.Value.ToShortDateString, _
                                               dtoUSUARIOS.m_iIdAgencia, intProveedor, strRuc, strRazonSocial, dtoUSUARIOS.IdLogin, _
                                               Me.txtObservacionReparto.Text.Trim, dblMonto,
                                               row.Cells("peso").Value, row.Cells("cantidad").Value, _
                                               row.Cells("id_grt").Value, intEstado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, intTipoGasto, dblMontoTarifa)
                intID = dt.Rows(0).Item(0)
            Next
            id = intID
            'Me.ListarRecojo()
            'tabRecojo.SelectedIndex = 0
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtComprobanteRecojo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComprobanteRecojo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAgregarRecojo_Click(Nothing, Nothing)
        End If
    End Sub

    Sub TotalizarRecojo()
        Dim dblPeso As Double = 0
        Dim intCantidad As Integer = 0

        With Me.dgvRecojo
            For Each row As DataGridViewRow In .Rows
                If row.Cells("estado").Value < 2 Then
                    dblPeso += row.Cells("peso").Value
                    intCantidad += row.Cells("cantidad").Value
                End If
            Next
        End With
        Me.lblPesoRecojo.Text = Format(dblPeso, "###,###,###0.00")
        Me.lblCantidadRecojo.Text = intCantidad

        If dblPeso + intCantidad = 0 Then
            Me.btnQuitar.Enabled = False
        Else
            Me.btnQuitar.Enabled = True
        End If
    End Sub

    Sub Agregar(ByVal dt As DataTable, ByVal dgv As DataGridView, ByVal formato As Integer, Optional ByVal fila As Integer = 0, Optional ByVal opcion As Integer = 0)
        With dgv
            .Rows.Add()
            If formato = 0 Then
                dgv(0, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_grt")
                dgv(1, .Rows.Count - 1).Value = dt.Rows(fila).Item("bus")

                dgv(2, .Rows.Count - 1).Value = dt.Rows(fila).Item("grt")
                dgv(3, .Rows.Count - 1).Value = dt.Rows(fila).Item("origen")
                dgv(4, .Rows.Count - 1).Value = dt.Rows(fila).Item("destino")
                dgv(5, .Rows.Count - 1).Value = dt.Rows(fila).Item("peso")
                dgv(6, .Rows.Count - 1).Value = dt.Rows(fila).Item("cantidad")
                If opcion = 0 Then
                    dgv(7, .Rows.Count - 1).Value = 0
                Else
                    dgv(7, .Rows.Count - 1).Value = dt.Rows(fila).Item("estado")
                End If
                dgv(8, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_origen")
                dgv(9, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_destino")
                dgv(10, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_persona")
                dgv(1, .Rows.Count - 1).Value = dt.Rows(fila).Item("producto")
            Else
                If opcion = 0 Then
                    dgv(0, .Rows.Count - 1).Value = 0 'id cabecera
                    dgv(1, .Rows.Count - 1).Value = 0 'id detalle
                    dgv(10, .Rows.Count - 1).Value = 0 'nuevo
                Else
                    dgv(0, .Rows.Count - 1).Value = dt.Rows(fila).Item("id") 'id cabecera
                    dgv(1, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_2") 'id detalle
                    dgv(10, .Rows.Count - 1).Value = dt.Rows(fila).Item("estado") 'nuevo
                End If
                dgv(2, .Rows.Count - 1).Value = CDate(dt.Rows(fila).Item("fecha"))
                dgv(3, .Rows.Count - 1).Value = dt.Rows(fila).Item("tipo")
                dgv(4, .Rows.Count - 1).Value = dt.Rows(fila).Item("comprobante")
                dgv(5, .Rows.Count - 1).Value = dt.Rows(fila).Item("origen")
                dgv(6, .Rows.Count - 1).Value = dt.Rows(fila).Item("destino")
                dgv(7, .Rows.Count - 1).Value = dt.Rows(fila).Item("cliente")
                dgv(8, .Rows.Count - 1).Value = dt.Rows(fila).Item("peso")
                dgv(9, .Rows.Count - 1).Value = dt.Rows(fila).Item("cantidad")
                dgv(11, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_comprobante")
                dgv(12, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_tipo")
                dgv(13, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_origen")
                dgv(14, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_destino")
                dgv(15, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_persona")
                dgv(16, .Rows.Count - 1).Value = dt.Rows(fila).Item("producto")
            End If
        End With
    End Sub

    Sub QuitarRecojo()
        Dim strMensaje As String
        If Me.rbtGrtRecojo.Checked Then
            strMensaje = "¿Está Seguro de anular el Nº de GRT Seleccionado?"
        Else
            strMensaje = "¿Está Seguro de anular el Comprobante Seleccionado?"
        End If
        With dgvRecojo
            If .Rows.Count > 0 Then
                Dim dlgRespuesta As DialogResult = MessageBox.Show(strMensaje, "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    If dgvRecojo.CurrentRow.Cells("estado").Value = 0 Then 'Comprobante no grabado
                        .Rows.Remove(.CurrentRow)
                    Else 'Comprobante grabado
                        dgvRecojo.CurrentRow.Cells("estado").Value = 2
                        dgvRecojo.CurrentRow.Visible = False
                    End If
                    TotalizarRecojo()

                    Dim i As Integer = 0
                    If ObtieneItemActivo(Me.dgvRecojo) > 0 Then
                        For Each row As DataGridViewRow In .Rows
                            If row.Cells("estado").Value < 2 Then
                                Exit For
                            End If
                            i += 1
                        Next
                        .Rows(i).Selected = True
                        .CurrentCell = .Rows(i).Cells(2)
                    End If
                End If
                TotalRepartoRecojo()
            End If
        End With
    End Sub

    Sub AnularRecojo()
        Try
            Dim obj As New Cls_Gasto_LN
            obj.AnularSolicitudRecojo(Me.dgvListaRecojo.CurrentRow.Cells("id").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            'ListarRecojo()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarRecojoDetalle(ByVal id As Integer)
        Dim obj As New Cls_Gasto_LN
        Me.dgvRecojo.DataSource = obj.ListarRecojoDetalle(id)
    End Sub

    Function ListarRecojoDetalle(ByVal id As Integer, ByVal formato As Integer, Optional ByVal mixto As Integer = 0) As DataTable
        Dim obj As New Cls_Gasto_LN
        Return obj.ListarRecojoDetalle(id, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, formato, mixto)
    End Function

    Private Sub cboMovilRecojo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            'Me.txtMontoRecojo.Focus()
        End If
    End Sub

    Private Sub txtObservacionRecojo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservacionRecojo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnLiquidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiquidar.Click
        Dim strFactura As String
        strFactura = Me.dgvImprimir.CurrentRow.Cells("factura").Value

        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de Liquidar la Factura " & strFactura & "?", "Liquidar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Dim intID As Integer = Me.dgvImprimir.CurrentRow.Cells("id").Value
            Liquidar(intID)
        End If
    End Sub

    Sub Liquidar(ByVal id As Integer)
        Cursor = Cursors.WaitCursor
        Try
            Dim obj As New Cls_Gasto_LN
            Dim intNumero As Integer = obj.LiquidarFactura(id, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            Cursor = Cursors.Default
            MessageBox.Show("Se liquidó la Factura con el Nº de Liquidación : " & intNumero, "Factura Liquidada", MessageBoxButtons.OK)
            btnFiltrarImprimir_Click(Nothing, Nothing)

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Liquidar Factura", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarProveedor(ByVal ruc As String, ByRef id As Integer, ByRef razon_social As String)
        Try
            Dim obj As New Cls_Gasto_LN

            Dim dt As DataTable = obj.ListarProveedor(ruc)
            If dt.Rows.Count > 0 Then
                id = dt.Rows(0).Item("id").ToString
                razon_social = dt.Rows(0).Item("proveedor").ToString
            Else
                id = 0
                razon_social = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Buscar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '---------------------------------- ESTIBA ------------------------------------

    Sub TotalizarEstiba()
        Dim dblPeso As Double = 0
        Dim intCantidad As Integer = 0

        With Me.dgvEstiba
            For Each row As DataGridViewRow In .Rows
                If row.Cells("estado").Value < 2 Then
                    dblPeso += row.Cells("peso").Value
                    intCantidad += row.Cells("cantidad").Value
                End If
            Next
        End With
        Me.lblPesoEstiba.Text = Format(dblPeso, "###,###,###0.00")
        Me.lblCantidadEstiba.Text = intCantidad

        If dblPeso + intCantidad = 0 Then
            Me.btnQuitarGrt.Enabled = False
        Else
            Me.btnQuitarGrt.Enabled = True
        End If
    End Sub

    Sub LimpiarAprobacionEstiba()
        lblFechaEstibaAprobacion.Text = Format(FechaServidor, "Short Date")
        Me.lblCiudadEstibaAprobacion.Text = ""
        Me.lblSolicitanteEstibaAprobacion.Text = ""
        Me.dgvEstibaAprobacion.DataSource = Nothing
        Me.lblMontoEstibaAprobacion.Text = ""
        Me.lblObservacionEstibaAprobacion.Text = ""

        Me.rbtSiEstibaAprobacion.Checked = True
        Me.txtObservacionEstibaAprobacion.Text = ""
        Me.lblPesoEstibaAprobacion.Text = ""
        Me.lblCantidadEstibaAprobacion.Text = ""
        Me.lblSolesKgEstiba.Text = ""
    End Sub

    Sub LimpiarSolicitudEstiba()
        'FormateardgvListaRecojo()
        Me.dgvEstiba.Rows.Clear()
        Me.dtpHoraInicioEstiba.Value = Now
        Me.dtpHoraFinEstiba.Value = Now

        Me.txtRucProveedor.Text = ""
        Me.txtRazonSocialProveedor.Text = ""

        Me.cboTipoOperacionEstiba.SelectedIndex = 0
        Me.txtNumeroEstiba.Text = ""

        Me.lblNumeroSolicitudEstiba.Text = ""
        Me.lblCiudadEstiba.Text = dtoUSUARIOS.m_iNombreUnidadAgencia
        Me.lblSolicitanteEstiba.Text = dtoUSUARIOS.NameLogin

        Me.txtMontoEstiba.Text = "0.00"
        Me.txtObservacionEstiba.Text = ""
        Me.txtGrtEstiba.Text = ""
        Me.cboTipoOperacionEstiba.SelectedIndex = 0

        Me.lblFechaEstiba.Text = Format(FechaServidor, "Short Date")
        Me.btnQuitarGrt.Enabled = False

        LimpiarEstiba()
    End Sub

    Sub ListarEstibaDetalle(ByVal id As Integer, ByVal formato As Integer)
        Dim obj As New Cls_Gasto_LN
        Me.dgvEstibaAprobacion.DataSource = obj.ListarEstibaDetalle(id, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, formato)
    End Sub

    Sub LimpiarEstiba()
        Dim dtEstiba As New Cls_Gasto_LN
        dtEstiba.LimpiarEstiba(dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
    End Sub

    Sub InicioEstiba()
        LimpiarEstiba()

        Dim obj As New Cls_Gasto_LN
        With Me.cboCiudadEstiba
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarCiudad(1)
            If intNivel = 1 Or intNivel = 4 Or intNivel = 5 Then
                .SelectedValue = dtoUSUARIOS.m_idciudad
                .Enabled = False
                Me.rbtSeguimientoEstiba.Visible = False
                Me.rbtPorAprobarEstiba.Visible = False
            Else
                .SelectedValue = 0
                .Enabled = True
                Me.rbtSeguimientoEstiba.Visible = True
                Me.rbtPorAprobarEstiba.Visible = True
                Me.rbtPorAprobarEstiba.Checked = True
            End If
        End With

        ConfigurarDGVEstiba(1)
        ConfigurarDGVEstibaAprobacion(1)
    End Sub

    Sub AgregarEstiba(ByVal dt As DataTable, ByVal dgv As DataGridView, ByVal formato As Integer, Optional ByVal fila As Integer = 0, Optional ByVal opcion As Integer = 0)
        With dgv
            .Rows.Add()
            If formato = 0 Then
                dgv(0, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_grt")
                dgv(1, .Rows.Count - 1).Value = dt.Rows(fila).Item("bus")
                dgv(2, .Rows.Count - 1).Value = dt.Rows(fila).Item("grt")
                dgv(3, .Rows.Count - 1).Value = dt.Rows(fila).Item("origen")
                dgv(4, .Rows.Count - 1).Value = dt.Rows(fila).Item("destino")
                dgv(5, .Rows.Count - 1).Value = dt.Rows(fila).Item("peso")
                dgv(6, .Rows.Count - 1).Value = dt.Rows(fila).Item("cantidad")
                If opcion = 0 Then
                    dgv(7, .Rows.Count - 1).Value = 0
                Else
                    dgv(7, .Rows.Count - 1).Value = dt.Rows(fila).Item("estado")
                End If
            Else
                If opcion = 0 Then
                    dgv(0, .Rows.Count - 1).Value = 0 'id cabecera
                    dgv(1, .Rows.Count - 1).Value = 0 'id detalle
                    dgv(10, .Rows.Count - 1).Value = 0 'nuevo
                Else
                    dgv(0, .Rows.Count - 1).Value = dt.Rows(fila).Item("id") 'id cabecera
                    dgv(1, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_2") 'id detalle
                    dgv(10, .Rows.Count - 1).Value = dt.Rows(fila).Item("estado") 'nuevo
                End If
                dgv(2, .Rows.Count - 1).Value = CDate(dt.Rows(fila).Item("fecha"))
                dgv(3, .Rows.Count - 1).Value = dt.Rows(fila).Item("tipo")
                dgv(4, .Rows.Count - 1).Value = dt.Rows(fila).Item("comprobante")
                dgv(5, .Rows.Count - 1).Value = dt.Rows(fila).Item("origen")
                dgv(6, .Rows.Count - 1).Value = dt.Rows(fila).Item("destino")
                dgv(7, .Rows.Count - 1).Value = dt.Rows(fila).Item("cliente")
                dgv(8, .Rows.Count - 1).Value = dt.Rows(fila).Item("peso")
                dgv(9, .Rows.Count - 1).Value = dt.Rows(fila).Item("cantidad")
                dgv(11, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_comprobante")
                dgv(12, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_tipo")
                dgv(13, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_origen")
                dgv(14, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_destino")
                dgv(15, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_persona")
                dgv(16, .Rows.Count - 1).Value = dt.Rows(fila).Item("producto")
            End If
        End With
    End Sub

    Private Sub tabEstiba_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabEstiba.SelectedIndexChanged
        If tabEstiba.SelectedTab Is tabEstiba.TabPages("tabListaEstiba") Then
            If tabEstiba.TabPages.IndexOf(tabSolicitudEstiba) > -1 Then
                tsbNuevo.Enabled = True : tsbEditar.Enabled = Me.dgvListaEstiba.Rows.Count > 0 : tsbAnular.Enabled = Me.dgvListaEstiba.Rows.Count > 0
                tsbGrabar.Enabled = False
            Else
                tsbNuevo.Enabled = False : tsbEditar.Enabled = Me.dgvListaEstiba.Rows.Count > 0 : tsbAnular.Enabled = False
                tsbGrabar.Enabled = False
            End If
            FormateardgvListaEstiba()
        ElseIf tabEstiba.SelectedTab Is tabEstiba.TabPages("tabSolicitudEstiba") Then
            LimpiarSolicitudEstiba()
            If Me.dgvListaEstiba.Rows.Count > 0 Then
                tsbEditar_Click(Nothing, Nothing)
            Else
                tsbNuevo_Click(Nothing, Nothing)
            End If
            'Me.tsbGrabar.Enabled = False
        ElseIf tabEstiba.SelectedTab Is tabEstiba.TabPages("tabAprobacionEstiba") Then
            LimpiarAprobacionEstiba()
            Me.tsbGrabar.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False

            If Me.dgvListaEstiba.Rows.Count > 0 Then
                Me.rbtSiEstibaAprobacion.Enabled = True
                Me.rbtNoEstibaAprobacion.Enabled = True
                Me.txtObservacionEstibaAprobacion.Enabled = True
                Me.btnAceptarEstibaAprobacion.Enabled = True
                Me.grbEstibaAprobacion.Enabled = True

                Me.lblFechaEstibaAprobacion.Text = Me.dgvListaEstiba.CurrentRow.Cells("fecha_operacion").Value
                Me.lblHoraInicioAprobacion.Text = Me.dgvListaEstiba.CurrentRow.Cells("hora_inicio").Value
                Me.lblHoraFinAprobacion.Text = Me.dgvListaEstiba.CurrentRow.Cells("hora_fin").Value
                Me.lblTipoOperacionAprobacion.Text = Me.dgvListaEstiba.CurrentRow.Cells("operacion").Value
                Me.lblNumeroEstibadorAprobacion.Text = Me.dgvListaEstiba.CurrentRow.Cells("numero_estiba").Value

                Me.lblCiudadEstibaAprobacion.Text = Me.dgvListaEstiba.CurrentRow.Cells("ciudad").Value
                Me.lblSolicitanteEstibaAprobacion.Text = Me.dgvListaEstiba.CurrentRow.Cells("solicitante").Value
                Me.lblObservacionEstibaAprobacion.Text = Me.dgvListaEstiba.CurrentRow.Cells("observacion").Value

                Me.lblMontoEstibaAprobacion.Text = Format(CDbl(Me.dgvListaEstiba.CurrentRow.Cells("monto").Value), "###,###,###0.00")

                Dim intID As Integer = Me.dgvListaEstiba.CurrentRow.Cells("id").Value
                ListarEstibaDetalle(intID, Me.dgvListaEstiba.CurrentRow.Cells("formato").Value)

                Dim dblPeso As Double = ObtieneSuma(Me.dgvEstibaAprobacion, Me.dgvEstibaAprobacion.Columns("peso").Index)
                Dim intCantidad As Double = ObtieneSuma(Me.dgvEstibaAprobacion, Me.dgvEstibaAprobacion.Columns("cantidad").Index)

                Me.lblPesoEstibaAprobacion.Text = Format(dblPeso, "0.00")
                Me.lblCantidadEstibaAprobacion.Text = intCantidad

                Dim dblSoles As Double = Me.lblMontoEstibaAprobacion.Text
                Dim dblSolesKg As Double = dblSoles / dblPeso
                Me.lblSolesKgEstiba.Text = Format(dblSolesKg, "###,###,###0.00")

                If Me.dgvListaEstiba.CurrentRow.Cells("formato").Value = 0 Then
                    ConfigurarDGVEstibaAprobacion(1)
                Else
                    ConfigurarDGVEstibaAprobacion(2)
                End If

                Me.btnAceptarEstibaAprobacion.Focus()

                If Me.dgvListaEstiba.CurrentRow.Cells("id_estado").Value > 1 Then
                    Me.rbtSiEstibaAprobacion.Enabled = False
                    Me.rbtNoEstibaAprobacion.Enabled = False
                    Me.txtObservacionEstibaAprobacion.Enabled = False
                    Me.btnAceptarEstibaAprobacion.Enabled = False
                    Me.grbEstibaAprobacion.Enabled = False
                End If
            Else
                Me.rbtSiEstibaAprobacion.Enabled = False
                Me.rbtNoEstibaAprobacion.Enabled = False
                Me.txtObservacionEstibaAprobacion.Enabled = False
                Me.btnAceptarEstibaAprobacion.Enabled = False
                Me.grbEstibaAprobacion.Enabled = False
            End If
        End If
    End Sub

    Sub QuitarEstiba()
        Dim strMensaje As String
        If Me.rbtGrt.Checked Then
            strMensaje = "¿Está Seguro de Desactivar el Nº de GRT Seleccionado?"
        Else
            strMensaje = "¿Está Seguro de Desactivar el Comprobante Seleccionado?"
        End If
        With dgvEstiba
            If .Rows.Count > 0 Then
                Dim dlgRespuesta As DialogResult = MessageBox.Show(strMensaje, "Desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    If dgvEstiba.CurrentRow.Cells("estado").Value = 0 Then 'GRT no grabado
                        .Rows.Remove(.CurrentRow)
                    Else 'Comprobante grabado
                        dgvEstiba.CurrentRow.Cells("estado").Value = 2
                        dgvEstiba.CurrentRow.Visible = False
                    End If
                    TotalizarEstiba()

                    Dim i As Integer = 0
                    If ObtieneItemActivo(Me.dgvEstiba) > 0 Then
                        For Each row As DataGridViewRow In .Rows
                            If row.Cells("estado").Value < 2 Then
                                i += 1
                                Exit For
                            End If
                        Next
                        .Rows(i).Selected = True
                        .CurrentCell = .Rows(i).Cells(2)
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub btnAgregarEstiba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarEstiba.Click
        Try
            If Me.rbtGrt.Checked Then
                If Me.txtGrtEstiba.Text.Trim.Length = 0 Then Return
            Else
                If Me.txtComprobanteEstiba.Text.Trim.Length = 0 Then Return
            End If
            If Me.cboTipoOperacionEstiba.SelectedIndex = 0 Then
                MessageBox.Show("Seleccione Tipo de Operación", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoOperacionEstiba.DroppedDown = True
                Me.cboTipoOperacionEstiba.Focus()
                Return
            End If

            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN

            If Me.rbtGrt.Checked Then
                Dim strNroDoc As String() = Split(txtGrtEstiba.Text, "-")
                Dim intSerie As Integer, intNumero As Integer
                If strNroDoc.Length > 1 Then
                    If Val(strNroDoc(0)) > 0 And Val(strNroDoc(1)) > 0 Then
                        intSerie = strNroDoc(0)
                        intNumero = strNroDoc(1)
                    Else
                        If Val(strNroDoc(1)) > 0 Then
                            intNumero = strNroDoc(1)
                        End If
                    End If
                ElseIf strNroDoc.Length = 1 Then
                    If Val(strNroDoc(0)) > 0 Then
                        intNumero = strNroDoc(0)
                    End If
                End If

                If intSerie = 0 And intNumero = 0 Then
                    Cursor = Cursors.Default
                    Return
                End If

                Dim dt As DataTable = obj.ListarGrt(intSerie, intNumero, Me.cboTipoOperacionEstiba.SelectedIndex, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, 1)
                If dt.Rows.Count > 0 Then
                    If Not ExisteValorGrid(Me.dgvEstiba, Me.dgvEstiba.Columns("id_grt").Index, dt.Rows(0).Item("id_grt")) Then
                        AgregarEstiba(dt, dgvEstiba, 0)
                        Me.txtGrtEstiba.Focus()
                        Me.txtGrtEstiba.SelectAll()
                    Else
                        Cursor = Cursors.Default
                        MessageBox.Show("El Nº de GRT ya existe en la Lista", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtGrtEstiba.Focus()
                        Me.txtGrtEstiba.SelectAll()
                    End If
                Else
                    Cursor = Cursors.Default
                    MessageBox.Show("El Nº de GRT no se encuentra Disponible", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtGrtEstiba.Focus()
                    Me.txtGrtEstiba.SelectAll()
                End If
            Else
                Dim strNroDoc As String() = Split(txtComprobanteEstiba.Text, "-")
                If strNroDoc.Length > 1 Then
                    If strNroDoc(0).Trim.Length > 1 And Val(strNroDoc(1)) > 0 Then
                        ObjEntrega_Recojo.v_serie = strNroDoc(0)
                        ObjEntrega_Recojo.v_nroDoc = strNroDoc(1)
                    Else
                        ObjEntrega_Recojo.v_serie = "0"
                        ObjEntrega_Recojo.v_nroDoc = "0"
                    End If
                Else
                    If strNroDoc.Length = 1 Then
                        ObjEntrega_Recojo.v_serie = "-1"
                        ObjEntrega_Recojo.v_nroDoc = strNroDoc(0)
                    Else
                        ObjEntrega_Recojo.v_serie = "0"
                        ObjEntrega_Recojo.v_nroDoc = "0"
                    End If
                End If

                Dim dt As DataTable = obj.ListarDisponibleEstiba(ObjEntrega_Recojo.v_serie, ObjEntrega_Recojo.v_nroDoc, Me.cboTipoEstiba.SelectedIndex)
                If dt.Rows.Count > 0 Then
                    If Not ExisteValorGrid(Me.dgvEstiba, Me.dgvEstiba.Columns("id_comprobante").Index, dt.Rows(0).Item("id_comprobante")) Then
                        Agregar(dt, dgvEstiba, 1)
                        Me.txtComprobanteEstiba.Focus()
                        Me.txtComprobanteEstiba.SelectAll()
                    Else
                        Cursor = Cursors.Default
                        MessageBox.Show("El Comprobante ya existe en la Lista", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtComprobanteEstiba.Focus()
                        Me.txtComprobanteEstiba.SelectAll()
                    End If
                Else
                    Cursor = Cursors.Default
                    MessageBox.Show("El Comprobante no se encuentra Disponible", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtComprobanteEstiba.Focus()
                    Me.txtComprobanteEstiba.SelectAll()
                End If

            End If
            TotalizarEstiba()
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Estiba", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtGrtEstiba.Focus()
            Me.txtGrtEstiba.SelectAll()
        End Try
    End Sub

    Private Sub btnQuitarGrt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarGrt.Click
        If Me.dgvEstiba.Rows.Count > 0 Then
            QuitarEstiba()
        End If
    End Sub

    Sub GrabarSolicitudEstiba()
        If Me.cboTipoOperacionEstiba.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Tipo de Operación", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoOperacionEstiba.Focus()
            Me.cboTipoOperacionEstiba.DroppedDown = True
            Return
        End If

        If Val(Me.txtNumeroEstiba.Text) = 0 Then
            MessageBox.Show("Ingrese Nº de Estibas", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroEstiba.Focus()
            Return
        End If

        If Val(Me.txtMontoEstiba.Text) = 0 Then
            MessageBox.Show("Ingrese Monto", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMontoEstiba.Focus()
            Return
        End If

        Dim blnRucValido As Boolean = fnValidarRUC(txtRucProveedor.Text)
        intLlamada = 1
        Me.txtRucProveedor_LostFocus(Nothing, Nothing)
        intLlamada = 0
        If Not blnRucValido Then
            MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRucProveedor.Focus()
            Return
        End If

        If Me.txtRazonSocialProveedor.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Razón Social", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRazonSocialProveedor.Text = ""
            txtRazonSocialProveedor.Focus()
            Return
        End If

        If ObtieneItemActivo(Me.dgvEstiba) = 0 Then
            MessageBox.Show("Ingrese la GRT", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtGrtEstiba.Focus()
            Return
        End If

        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable
            Dim intID As Integer, intID_2 As Integer
            Dim intTipo As Integer, intComprobante As Integer, intEstado As Integer
            Dim intProveedor As Integer, strRuc As String, strRazonSocial As String

            intProveedor = IIf(IsNothing(Me.txtRucProveedor.Tag), 0, Val(Me.txtRucProveedor.Tag))
            strRuc = Me.txtRucProveedor.Text.Trim
            strRazonSocial = Me.txtRazonSocialProveedor.Text.Trim

            If intOperacion = Operacion.Nuevo Then
                intID = 0 : intID_2 = 0
            Else
                intID = Me.dgvListaEstiba.CurrentRow.Cells("id").Value
            End If
            For Each row As DataGridViewRow In Me.dgvEstiba.Rows
                intEstado = row.Cells("estado").Value
                dt = obj.GrabarSolicitudEstiba(intID, dtoUSUARIOS.m_idciudad, Me.cboTipoOperacionEstiba.SelectedIndex, Me.dtpFechaOperacionEstiba.Value.ToShortDateString, _
                                               dtoUSUARIOS.m_iIdAgencia, intProveedor, strRuc, strRazonSocial, dtoUSUARIOS.IdLogin, _
                                               Me.txtObservacionEstiba.Text.Trim, CDbl(Me.txtMontoEstiba.Text), row.Cells("peso").Value, row.Cells("cantidad").Value, _
                                               Me.txtNumeroEstiba.Text, Me.dtpHoraInicioEstiba.Text, Me.dtpHoraFinEstiba.Text, _
                                               row.Cells("id_grt").Value, intEstado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                intID = dt.Rows(0).Item(0)
            Next

            'Me.ListarEstiba(dtoUSUARIOS.m_idciudad, Me.cboEstadoSolicitudEstiba.SelectedIndex, Me.dgvListaEstiba, Me.dtpInicioEstiba.Value.ToShortDateString, Me.dtpFinEstiba.Value.ToShortDateString)
            Me.ListarEstiba(Me.dgvListaEstiba)
            tabEstiba.SelectedIndex = 0
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GrabarSolicitudEstibaComprobante()
        If Me.cboTipoOperacionEstiba.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Tipo de Operación", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoOperacionEstiba.Focus()
            Me.cboTipoOperacionEstiba.DroppedDown = True
            Return
        End If

        If Val(Me.txtNumeroEstiba.Text) = 0 Then
            MessageBox.Show("Ingrese Nº de Estibas", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroEstiba.Focus()
            Return
        End If

        If Val(Me.txtMontoEstiba.Text) = 0 Then
            MessageBox.Show("Ingrese Monto", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMontoEstiba.Focus()
            Return
        End If

        Dim blnRucValido As Boolean = fnValidarRUC(txtRucProveedor.Text)
        intLlamada = 1
        Me.txtRucProveedor_LostFocus(Nothing, Nothing)
        intLlamada = 0
        If Not blnRucValido Then
            MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRucProveedor.Focus()
            Return
        End If

        If Me.txtRazonSocialProveedor.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Razón Social", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRazonSocialProveedor.Text = ""
            txtRazonSocialProveedor.Focus()
            Return
        End If

        If ObtieneItemActivo(Me.dgvEstiba) = 0 Then
            MessageBox.Show("Ingrese los Comprobantes", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtComprobanteEstiba.Focus()
            Return
        End If

        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable
            Dim intID As Integer, intID_2 As Integer
            Dim intTipo As Integer, intComprobante As Integer, intEstado As Integer
            Dim intProveedor As Integer, strRuc As String, strRazonSocial As String

            intProveedor = IIf(IsNothing(Me.txtRucProveedor.Tag), 0, Val(Me.txtRucProveedor.Tag))
            strRuc = Me.txtRucProveedor.Text.Trim
            strRazonSocial = Me.txtRazonSocialProveedor.Text.Trim

            If intOperacion = Operacion.Nuevo Then
                intID = 0 : intID_2 = 0
            Else
                intID = Me.dgvListaEstiba.CurrentRow.Cells("id").Value
                If Me.dgvEstiba.Rows.Count > 0 Then
                    intID_2 = Me.dgvEstiba.Rows(0).Cells("id_2").Value
                Else
                    intID_2 = 0
                End If
            End If
            For Each row As DataGridViewRow In Me.dgvEstiba.Rows
                intTipo = row.Cells("id_tipo").Value
                intComprobante = row.Cells("id_comprobante").Value
                intEstado = row.Cells("estado").Value
                dt = obj.GrabarSolicitudEstiba(intID, intID_2, dtoUSUARIOS.m_idciudad, Me.cboTipoOperacionEstiba.SelectedIndex, _
                                               Me.dtpHoraInicioEstiba.Text, Me.dtpHoraFinEstiba.Text, Me.txtNumeroEstiba.Text, Me.dtpFechaOperacionEstiba.Value.ToShortDateString, _
                                               dtoUSUARIOS.m_iIdAgencia, dtoUSUARIOS.IdLogin, _
                                               Me.txtObservacionEstiba.Text.Trim, CDbl(Me.txtMontoEstiba.Text), _
                                               intTipo, intComprobante, _
                                               row.Cells("fecha").Value, row.Cells("id_origen").Value, row.Cells("id_destino").Value, row.Cells("id_persona").Value, _
                                               row.Cells("peso").Value, row.Cells("cantidad").Value, row.Cells("producto").Value, intEstado, _
                                               intProveedor, strRuc, strRazonSocial, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                intID = dt.Rows(0).Item(0)
                intID_2 = dt.Rows(0).Item(1)
            Next

            Me.ListarEstiba(Me.dgvListaEstiba)
            tabEstiba.SelectedIndex = 0
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtMontoEstiba_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoEstiba.Enter
        Me.txtMontoEstiba.SelectAll()
    End Sub

    Private Sub txtMontoEstiba_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoEstiba.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtMontoEstiba.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMontoEstiba_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoEstiba.LostFocus
        If Val(Me.txtMontoEstiba.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtMontoEstiba.Text)
            Me.txtMontoEstiba.Text = Format(dblMonto, "0.00")
        Else
            Me.txtMontoEstiba.Text = ""
        End If
    End Sub

    Private Sub txtNumeroEstiba_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroEstiba.Enter
        Me.txtNumeroEstiba.SelectAll()
    End Sub

    Private Sub txtNumeroEstiba_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroEstiba.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtObservacionEstiba_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacionEstiba.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservacionEstiba_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacionEstiba.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    'Sub ListarEstiba(ByVal ciudad As Integer, ByVal estado As Integer, ByVal dgv As DataGridView, ByVal inicio As String, ByVal fin As String)
    Sub ListarEstiba(ByRef dgv As DataGridView)
        Dim strComprobante As String
        Try
            Cursor = Cursors.WaitCursor
            Dim intCiudad As Integer, intEstado As Integer
            Dim strInicio As String, strFin As String
            If Not pnlEstadoEstibas.Visible Then
                intCiudad = Me.cboCiudadEstiba.SelectedValue
                strInicio = "01/01/2018"
                strFin = Format(FechaServidor, "Short Date")
                intEstado = 1
                strComprobante = ""
            Else
                intCiudad = Me.cboCiudadEstiba.SelectedValue
                strInicio = Me.dtpInicioEstiba.Value.ToShortDateString
                strFin = Me.dtpFinEstiba.Value.ToShortDateString
                intEstado = Me.cboEstadoSolicitudEstiba.SelectedIndex()
                strComprobante = Me.txtComprobanteEstibaBuscar.Text.Trim
            End If

            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable = obj.ListarEstiba(intCiudad, intEstado, strInicio, strFin,strComprobante)
            dgv.AllowUserToAddRows = False
            dgv.DataSource = dt
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboEstadoSolicitudEstiba_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ListarEstiba(dtoUSUARIOS.m_idciudad, Me.cboEstadoSolicitudEstiba.SelectedIndex, Me.dgvListaEstiba)
        'If Me.dgvListaEstiba.Rows.Count > 0 Then
        '    Me.tsbEditar.Enabled = True
        '    If Me.dgvListaEstiba.CurrentRow.Cells("id_estado").Value = 1 Then
        '        Me.tsbAnular.Enabled = IIf(tabEstiba.TabPages.IndexOf(tabSolicitudEstiba) > -1, True, False)
        '        Me.tsbEditar.Enabled = True
        '    Else
        '        Me.tsbAnular.Enabled = False
        '        'Me.tsbEditar.Enabled = False
        '    End If
        'Else
        '    Me.tsbEditar.Enabled = False
        '    Me.tsbAnular.Enabled = False
        'End If
    End Sub

    Sub MostrarSolicitudEstiba(ByVal row As Integer)
        With dgvListaEstiba
            If .Rows(row).Cells("formato").Value = 0 Then
                Me.rbtGrt.Checked = True
            Else
                Me.rbtComprobante.Checked = True
            End If

            Me.lblNumeroSolicitudEstiba.Text = .Rows(row).Cells("numero").Value
            Me.lblFechaEstiba.Text = .Rows(row).Cells("fecha_solicitud").Value
            Me.lblCiudadEstiba.Text = .Rows(row).Cells("ciudad").Value
            Me.lblSolicitanteEstiba.Text = .Rows(row).Cells("solicitante").Value
            Me.txtObservacionEstiba.Text = IIf(IsDBNull(.Rows(row).Cells("observacion").Value), "", .Rows(row).Cells("observacion").Value)

            Me.dtpFechaOperacionEstiba.Value = .Rows(row).Cells("fecha_operacion").Value

            Dim d As Date
            Dim s As String
            s = dgvListaEstiba.Rows(row).Cells("hora_inicio").Value
            s = "01/01/2018" & " " & s.Substring(0, 6) & IIf(s.Substring(6, 1).ToUpper = "A", "AM", "PM")
            Me.dtpHoraInicioEstiba.Value = DateTime.Parse(s)

            s = dgvListaEstiba.Rows(row).Cells("hora_fin").Value
            s = "01/01/2018" & " " & s.Substring(0, 6) & IIf(s.Substring(6, 1).ToUpper = "A", "AM", "PM")
            Me.dtpHoraFinEstiba.Value = DateTime.Parse(s)

            Me.cboTipoOperacionEstiba.SelectedIndex = .Rows(row).Cells("id_operacion").Value
            Me.txtNumeroEstiba.Text = .Rows(row).Cells("numero_estiba").Value

            Me.txtRucProveedor.Text = IIf(IsDBNull(.CurrentRow.Cells("ruc").Value), "", .CurrentRow.Cells("ruc").Value)
            If Not IsDBNull(.CurrentRow.Cells("id_proveedor").Value) Then
                Me.txtRucProveedor.Tag = IIf(.CurrentRow.Cells("id_proveedor").Value = 0, "", (.CurrentRow.Cells("id_proveedor").Value))
            Else
                Me.txtRucProveedor.Tag = 0
            End If
            Me.txtRazonSocialProveedor.Text = IIf(IsDBNull(.CurrentRow.Cells("proveedor").Value), "", .CurrentRow.Cells("proveedor").Value)
            Me.txtRazonSocialProveedor.Enabled = False

            Me.txtMontoEstiba.Text = Format(.Rows(row).Cells("monto").Value, "###,###,###0.00")

            Me.dgvEstiba.Rows.Clear()
            Dim intID As Integer = .CurrentRow.Cells("id").Value
            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable = obj.ListarEstibaDetalle(intID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, .Rows(row).Cells("formato").Value)

            Dim intFila As Integer = 0
            For Each row1 As DataRow In dt.Rows
                intFila += 1
                AgregarEstiba(dt, Me.dgvEstiba, .Rows(row).Cells("formato").Value, intFila - 1, 1)
            Next

            TotalizarEstiba()

            If .Rows(row).Cells("id_estado").Value = 1 Then
                Me.txtMontoEstiba.Enabled = True
                Me.txtObservacionEstiba.Enabled = True
                Me.dtpFechaOperacionEstiba.Enabled = True
                'Me.cboMovilRecojo.Enabled = True
                Me.cboProveedor.Enabled = True
                Me.txtGrtEstiba.Enabled = True
                Me.btnAgregarEstiba.Enabled = True
                Me.btnQuitarGrt.Enabled = True

                Me.dtpHoraInicioEstiba.Enabled = True
                Me.dtpHoraFinEstiba.Enabled = True

                Me.txtRucProveedor.Enabled = True
                'Me.txtRazonSocialProveedor.Enabled = True

                Me.cboTipoOperacionEstiba.Enabled = True
                Me.txtNumeroEstiba.Enabled = True

                Me.rbtComprobante.Enabled = False

                Me.grbEstibaGrt.Enabled = True
                Me.grbEstibaComprobante.Enabled = True

                If Me.rbtGrt.Checked Then
                    Me.rbtComprobante.Enabled = False
                    Me.rbtGrt.Enabled = True
                Else
                    Me.rbtGrt.Enabled = False
                    Me.rbtComprobante.Enabled = True
                End If

                Me.tsbGrabar.Enabled = True
            Else
                Me.txtMontoEstiba.Enabled = False
                Me.txtObservacionEstiba.Enabled = False
                Me.dtpFechaOperacionEstiba.Enabled = False
                'Me.cboMovilRecojo.Enabled = False
                Me.cboProveedor.Enabled = True
                Me.txtGrtEstiba.Enabled = False
                Me.btnAgregarEstiba.Enabled = False
                Me.btnQuitarGrt.Enabled = False

                Me.dtpHoraInicioEstiba.Enabled = False
                Me.dtpHoraFinEstiba.Enabled = False

                Me.txtRucProveedor.Enabled = False
                Me.txtRazonSocialProveedor.Enabled = False

                Me.cboTipoOperacionEstiba.Enabled = False
                Me.txtNumeroEstiba.Enabled = False

                Me.rbtGrt.Enabled = False
                Me.rbtComprobante.Enabled = False
                Me.grbEstibaGrt.Enabled = False
                Me.grbEstibaComprobante.Enabled = False

                Me.tsbGrabar.Enabled = False
            End If
        End With
    End Sub

    Private Sub dgvListaEstiba_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListaEstiba.DoubleClick
        If Me.dgvListaEstiba.Rows.Count > 0 Then
            tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dtpHoraInicioEstiba_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpHoraInicioEstiba.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dtpHoraFinEstiba_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpHoraFinEstiba.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboMovilEstiba_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboTipoOperacionEstiba_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoOperacionEstiba.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtGrtEstiba_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrtEstiba.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAgregarEstiba_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgvListaEstiba_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaEstiba.RowEnter
        If tabEstiba.TabPages.IndexOf(tabSolicitudEstiba) > -1 Then
            If Me.dgvListaEstiba.Rows.Count > 0 Then
                If Me.dgvListaEstiba.Rows(e.RowIndex).Cells("id_estado").Value = 1 Then
                    Me.tsbAnular.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                End If
            End If
        End If
    End Sub

    Sub AnularEstiba()
        Try
            Dim obj As New Cls_Gasto_LN
            obj.AnularSolicitudEstiba(Me.dgvListaEstiba.CurrentRow.Cells("id").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            ListarEstiba(Me.dgvEstiba)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpFechaOperacionEstiba_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaOperacionEstiba.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.dtpHoraInicioEstiba.Focus()
        End If
    End Sub

    Private Sub btnAceptarEstibaAprobacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarEstibaAprobacion.Click
        If Me.rbtNoEstibaAprobacion.Checked Then
            If Me.txtObservacionEstibaAprobacion.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Motivo", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtObservacionEstibaAprobacion.Text = ""
                Me.txtObservacionEstibaAprobacion.Focus()
                Return
            End If
        End If
        AprobarEstiba()
    End Sub

    Sub AprobarEstiba()
        Try
            If Me.rbtSiEstibaAprobacion.Checked Then 'aprueba
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    AprobarSolicitudEstiba(2)
                    MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Me.ListarEstiba(dtoUSUARIOS.m_idciudad, Me.cboEstadoSolicitudEstiba.SelectedIndex, Me.dgvListaEstiba, Me.dtpInicioEstiba.Value.ToShortDateString, Me.dtpFinEstiba.Value.ToShortDateString)
                    Me.ListarEstiba(Me.dgvListaEstiba)
                    tabEstiba.SelectedTab = tabEstiba.TabPages("tabListaEstiba")
                    Cursor = Cursors.Default
                End If
            ElseIf Me.rbtNoEstibaAprobacion.Checked Then 'no aprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    AprobarSolicitudEstiba(3)
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Me.ListarEstiba(dtoUSUARIOS.m_idciudad, Me.cboEstadoSolicitudEstiba.SelectedIndex, Me.dgvListaEstiba, Me.dtpInicioEstiba.Value.ToShortDateString, Me.dtpFinEstiba.Value.ToShortDateString)
                    Me.ListarEstiba(Me.dgvListaEstiba)
                    tabEstiba.SelectedTab = tabEstiba.TabPages("tabListaEstiba")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AprobarSolicitudEstiba(ByVal estado As Integer)
        Cursor = Cursors.WaitCursor
        Try
            Dim objLN As New Cls_Gasto_LN
            Dim intID As Integer = Me.dgvListaEstiba.CurrentRow.Cells("id").Value
            Dim dblPrecio As Double, strObservacion As String
            If estado = 2 Then
                strObservacion = ""
            ElseIf estado = 3 Then
                strObservacion = Me.txtObservacionEstibaAprobacion.Text.Trim
            End If
            objLN.AprobarSolicitudEstiba(intID, strObservacion, estado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub txtRucProveedor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedor.Enter
        txtRucProveedor.SelectAll()
    End Sub

    Private Sub txtRucProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRucProveedor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtRucProveedor_LostFocus(Nothing, Nothing)
            If Me.txtRazonSocialProveedor.Enabled Then
                Me.txtRazonSocialProveedor.Focus()
            Else
                SendKeys.Send(vbTab)
            End If
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRucProveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedor.LostFocus
        If Me.txtRucProveedor.Text.Trim.Length > 0 Then
            Dim intId As Integer = 0, strRazonSocial As String = "", strRuc As String
            strRuc = Me.txtRucProveedor.Text.Trim
            ListarProveedor(strRuc, intId, strRazonSocial)
            If intId > 0 Then
                Me.txtRucProveedor.Tag = intId
                Me.txtRazonSocialProveedor.Text = strRazonSocial
                Me.txtRazonSocialProveedor.Enabled = False
            ElseIf intLlamada = 0 Then
                Me.txtRucProveedor.Tag = ""
                Me.txtRazonSocialProveedor.Text = ""
                Me.txtRazonSocialProveedor.Enabled = True
                Me.txtRazonSocialProveedor.Focus()
            End If
        Else
            Me.txtRazonSocialProveedor.Focus()
        End If
    End Sub

    Private Sub txtRucProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRucProveedor.TextChanged
        Me.txtRazonSocialProveedor.Text = ""
        Me.txtRucProveedor.Tag = ""
        Me.txtRazonSocialProveedor.Enabled = True
    End Sub

    Private Sub txtRazonSocialProveedor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazonSocialProveedor.Enter
        txtRazonSocialProveedor.SelectAll()
    End Sub

    Private Sub txtRazonSocialProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazonSocialProveedor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboConceptoFacturacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboConceptoFacturacion.SelectedIndexChanged
        ListarGastoProveedor()
    End Sub

    Private Sub txtRucProveedorReparto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedorReparto.Enter
        txtRucProveedorReparto.SelectAll()
    End Sub

    Private Sub txtRucProveedorReparto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRucProveedorReparto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtRucProveedorReparto_LostFocus(Nothing, Nothing)
            If Me.txtRazonSocialProveedorReparto.Enabled Then
                Me.txtRazonSocialProveedorReparto.Focus()
            Else
                SendKeys.Send(vbTab)
            End If
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRucProveedorReparto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedorReparto.LostFocus
        If Me.txtRucProveedorReparto.Text.Trim.Length > 0 Then
            Dim intId As Integer = 0, strRazonSocial As String = "", strRuc As String
            strRuc = Me.txtRucProveedorReparto.Text.Trim
            ListarProveedor(strRuc, intId, strRazonSocial)
            If intId > 0 Then
                Me.txtRucProveedorReparto.Tag = intId
                Me.txtRazonSocialProveedorReparto.Text = strRazonSocial
                Me.txtRazonSocialProveedorReparto.Enabled = False
            ElseIf intLlamada = 0 Then
                Me.txtRucProveedorReparto.Tag = ""
                Me.txtRazonSocialProveedorReparto.Text = ""
                Me.txtRazonSocialProveedorReparto.Enabled = True
                Me.txtRazonSocialProveedorReparto.Focus()
            End If
        Else
            Me.txtRazonSocialProveedorReparto.Focus()
        End If
    End Sub

    Private Sub txtRucProveedorReparto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedorReparto.TextChanged
        Me.txtRazonSocialProveedorReparto.Text = ""
        Me.txtRucProveedorReparto.Tag = ""
        Me.txtRazonSocialProveedorReparto.Enabled = True
    End Sub

    Private Sub txtRazonSocialProveedorReparto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazonSocialProveedorReparto.Enter
        txtRazonSocialProveedorReparto.SelectAll()
    End Sub

    Private Sub txtRazonSocialProveedorReparto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazonSocialProveedorReparto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtRucProveedorFueraZona_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedorFueraZona.Enter
        txtRucProveedorFueraZona.SelectAll()
    End Sub

    Private Sub txtRucProveedorFueraZona_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRucProveedorFueraZona.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtRucProveedorFueraZona_LostFocus(Nothing, Nothing)
            If Me.txtRazonSocialProveedorFueraZona.Enabled Then
                Me.txtRazonSocialProveedorFueraZona.Focus()
            Else
                SendKeys.Send(vbTab)
            End If
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRucProveedorFueraZona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedorFueraZona.LostFocus
        If Me.txtRucProveedorFueraZona.Text.Trim.Length > 0 Then
            Dim intId As Integer = 0, strRazonSocial As String = "", strRuc As String
            strRuc = Me.txtRucProveedorFueraZona.Text.Trim
            ListarProveedor(strRuc, intId, strRazonSocial)
            If intId > 0 Then
                Me.txtRucProveedorFueraZona.Tag = intId
                Me.txtRazonSocialProveedorFueraZona.Text = strRazonSocial
                Me.txtRazonSocialProveedorFueraZona.Enabled = False
            ElseIf intLlamada = 0 Then
                Me.txtRucProveedorFueraZona.Tag = ""
                Me.txtRazonSocialProveedorFueraZona.Text = ""
                Me.txtRazonSocialProveedorFueraZona.Enabled = True
                Me.txtRazonSocialProveedorFueraZona.Focus()
            End If
        Else
            Me.txtRazonSocialProveedorFueraZona.Focus()
        End If
    End Sub

    Private Sub txtRucProveedorFueraZona_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedorFueraZona.TextChanged
        Me.txtRazonSocialProveedorFueraZona.Text = ""
        Me.txtRucProveedorFueraZona.Tag = ""
        Me.txtRazonSocialProveedorFueraZona.Enabled = True
    End Sub

    Private Sub txtRazonSocialProveedorFueraZona_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazonSocialProveedorFueraZona.Enter
        txtRazonSocialProveedorFueraZona.SelectAll()
    End Sub

    Private Sub txtRazonSocialProveedorFueraZona_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazonSocialProveedorFueraZona.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub btnCancelarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarProveedor.Click
        Me.pnlProveedor.Visible = False
    End Sub

    Sub ObtenerProveedor()
        Me.txtRucProveedorPeso.Text = ""
        Me.txtRazonSocialProveedorPeso.Text = ""

        Dim obj As New Cls_Gasto_LN
        Dim dt As DataTable = obj.ObtieneProveedor(dtoUSUARIOS.m_idciudad, 2)
        If dt.Rows(0).Item(0) > 0 Then
            Me.txtRucProveedorPeso.Text = dt.Rows(0).Item(1)
            txtRucProveedorPeso_LostFocus(Nothing, Nothing)
        End If
        pnlProveedor.Visible = True
        Me.txtRucProveedorPeso.Focus()
    End Sub

    Private Sub btnAceptarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarProveedor.Click
        Dim blnRucValido As Boolean = fnValidarRUC(txtRucProveedorPeso.Text)
        intLlamada = 1
        Me.txtRucProveedorPeso_LostFocus(Nothing, Nothing)
        intLlamada = 0
        If Not blnRucValido Then
            MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRucProveedorPeso.Focus()
            Return
        End If

        If Me.txtRazonSocialProveedorPeso.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Razón Social", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRazonSocialProveedorPeso.Text = ""
            txtRazonSocialProveedorPeso.Focus()
            Return
        End If

        Grabar()
    End Sub

    Private Sub txtRucProveedorPeso_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedorPeso.Enter
        txtRucProveedorPeso.SelectAll()
    End Sub

    Private Sub txtRucProveedorPeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRucProveedorPeso.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtRucProveedorPeso_LostFocus(Nothing, Nothing)
            If Me.txtRazonSocialProveedorPeso.Enabled Then
                Me.txtRazonSocialProveedorPeso.Focus()
            Else
                SendKeys.Send(vbTab)
            End If
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRucProveedorPeso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedorPeso.LostFocus
        If Me.txtRucProveedorPeso.Text.Trim.Length > 0 Then
            Dim intId As Integer = 0, strRazonSocial As String = "", strRuc As String
            strRuc = Me.txtRucProveedorPeso.Text.Trim
            ListarProveedor(strRuc, intId, strRazonSocial)
            If intId > 0 Then
                Me.txtRucProveedorPeso.Tag = intId
                Me.txtRazonSocialProveedorPeso.Text = strRazonSocial
                Me.txtRazonSocialProveedorPeso.Enabled = False
            ElseIf intLlamada = 0 Then
                Me.txtRucProveedorPeso.Tag = ""
                Me.txtRazonSocialProveedorPeso.Text = ""
                Me.txtRazonSocialProveedorPeso.Enabled = True
                Me.txtRazonSocialProveedorPeso.Focus()
            End If
        Else
            Me.txtRazonSocialProveedorPeso.Focus()
        End If
    End Sub

    Private Sub txtRucProveedorPeso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRucProveedorPeso.TextChanged
        Me.txtRazonSocialProveedorPeso.Text = ""
        Me.txtRucProveedorPeso.Tag = ""
        Me.txtRazonSocialProveedorPeso.Enabled = True
    End Sub

    Private Sub txtRazonSocialProveedorPeso_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazonSocialProveedorPeso.Enter
        txtRazonSocialProveedorPeso.SelectAll()
    End Sub

    Private Sub txtRazonSocialProveedorPeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazonSocialProveedorPeso.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub tabProvision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabProvision.SelectedIndexChanged
        tsbNuevo.Enabled = False : tsbEditar.Enabled = False : tsbAnular.Enabled = False : tsbGrabar.Enabled = False
        If tabProvision.SelectedTab Is tabProvision.TabPages("tabCalculoProvision") Then
            Me.lblCiudadProvision.Visible = True
            Me.cboCiudadProvision.Visible = True
            Me.cboConceptoProvision.Visible = True
            Me.lblConceptoProvision.Visible = True

            If Me.lblMensajeProvision.Text = "" And Me.dgvCalculoProvision.Rows.Count > 0 And Me.cboCiudadProvision.SelectedValue = 0 And Me.cboConceptoProvision.SelectedValue = 0 Then
                Me.btnCierreProvision.Visible = True
                Me.btnCierreProvision.Enabled = Me.btnCierreProvision.Enabled = aGrupoProvision(0) And aGrupoProvision(1) And aGrupoProvision(2) And aGrupoProvision(3)
            Else
                Me.btnCierreProvision.Visible = True
                Me.btnCierreProvision.Enabled = False
            End If
            Me.lblMensajeProvision.Visible = True

            Me.dtpPeriodoProvision.Visible = True
            Me.dtpPeriodoProvisionConsulta.Visible = False

            'dtpPeriodoProvision_ValueChanged(Nothing, Nothing)
        Else
            Me.lblCiudadProvision.Visible = False
            Me.cboCiudadProvision.Visible = False
            Me.cboConceptoProvision.Visible = False
            Me.lblConceptoProvision.Visible = False
            Me.btnCierreProvision.Visible = False
            Me.lblMensajeProvision.Visible = False
            Me.dtpPeriodoProvision.Visible = False
            Me.dtpPeriodoProvisionConsulta.Visible = True

            ConfigurarDGVConsultaProvision()
        End If
    End Sub

    Private Sub btnCalcularProvision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcularProvision.Click
        If tabProvision.SelectedTab Is tabProvision.TabPages("tabCalculoProvision") Then
            If Me.lblMensajeProvision.Text = "" Then
                ListarProvision()
                TotalProvision(0)

                ActualizaEstadoProvision()
                ConfigurarResumenProvision()

                Me.btnCierreProvision.Enabled = Me.lblMensajeProvision.Text = "" And Me.dgvCalculoProvision.Rows.Count > 0 And Me.cboCiudadProvision.SelectedValue = 0 And Me.cboConceptoProvision.SelectedValue = 0
                If Me.btnCierreProvision.Enabled Then
                    Me.btnCierreProvision.Enabled = aGrupoProvision(0) And aGrupoProvision(1) And aGrupoProvision(2) And aGrupoProvision(3)
                End If
            Else
                ConsultarProvision()
                TotalProvision(1)
            End If
        Else
            ListarFueraZonaAprobados()
        End If
    End Sub

    Sub ListarProvision()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN
            Dim strFecha As String, strInicio As String, strFin As String, intCiudad As Integer, intConcepto As Integer

            strFecha = Me.dtpPeriodoProvision.Value.ToShortDateString
            strInicio = "01/" & Format(CDate(strFecha), "MM/yyyy")
            strFin = "01/" + Format(CDate(strFecha), "MM/yyyy")
            strFin = DateAdd(DateInterval.Month, 1, CDate(strFin))
            strFin = DateAdd(DateInterval.Day, -1, CDate(strFin))

            intCiudad = Me.cboCiudadProvision.SelectedValue
            intConcepto = Me.cboConceptoProvision.SelectedValue

            Dim ds As DataSet = obj.ListarProvision(strInicio, strFin, intCiudad, intConcepto, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            dtResumenProvision = ds.Tables(0)
            Me.dgvCalculoProvision.DataSource = dtResumenProvision

            TotalResumenProvision()
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Provisión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizaEstadoProvision()
        Dim obj As New Cls_Gasto_LN
        Dim strFecha As String, strInicio As String

        strFecha = Me.dtpPeriodoProvision.Value.ToShortDateString
        strInicio = "01/" & Format(CDate(strFecha), "MM/yyyy")
        Dim dt As DataTable = obj.EstadoProvision(strInicio)

        Me.lblMensajeProvision.Text = IIf(Val(dt.Rows(0).Item(0)) = 0, "", "CERRADO")
        Me.lblMensajeProvision.Visible = True
    End Sub

    Private Sub dtpPeriodoProvision_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPeriodoProvision.ValueChanged, dtpPeriodoProvisionConsulta.ValueChanged
        If tabProvision.SelectedTab Is tabProvision.TabPages("tabCalculoProvision") Then
            Me.dgvCalculoProvision.DataSource = Nothing
            dtResumenProvision = Nothing
            Me.btnCierreProvision.Enabled = False
            Me.lblMensajeProvision.Visible = False
            Me.lblMensajeProvision.Text = ""
            Me.lblTotalMontoProvision.Text = "0.00"

            ActualizaEstadoProvision()
            Me.btnCierreProvision.Enabled = Me.lblMensajeProvision.Text = "" And Me.dgvCalculoProvision.Rows.Count > 0 And Me.cboCiudadProvision.SelectedValue = 0 And Me.cboConceptoProvision.SelectedValue = 0
            If Me.btnCierreProvision.Enabled Then
                Me.btnCierreProvision.Enabled = aGrupoProvision(0) And aGrupoProvision(1) And aGrupoProvision(2) And aGrupoProvision(3)
            End If
        Else
            Me.dgvConsultaProvision.DataSource = Nothing
            Me.lblTotalConsultaProvision.Text = "0.00"
        End If
    End Sub

    Sub ConsultarProvision()
        Cursor = Cursors.WaitCursor
        Try
            Dim obj As New Cls_Gasto_LN
            Dim strFecha As String, strInicio As String, strConcepto As String
            Dim intCiudad As Integer

            strFecha = Me.dtpPeriodoProvision.Value.ToShortDateString
            strInicio = "01/" & Format(CDate(strFecha), "MM/yyyy")
            intCiudad = Me.cboCiudadProvision.SelectedValue
            Select Case Me.cboConceptoProvision.SelectedValue
                Case 0
                    strConcepto = ""
                Case 1
                    strConcepto = "0101"
                Case 2
                    strConcepto = "0201"
                Case 3
                    strConcepto = "0301"
                Case 4
                    strConcepto = "0401"
                Case 5
                    strConcepto = "0501"
                Case 6
                    strConcepto = "0601"
                Case 7
                    strConcepto = "0701"
                Case 8
                    strConcepto = "0801"
            End Select
            Dim dt As DataTable = obj.ConsultarProvision(strInicio, intCiudad, strConcepto)
            dtResumenProvision = dt
            Me.dgvCalculoProvision.DataSource = dt
            TotalResumenProvision()

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Provisión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCierreProvision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCierreProvision.Click
        Dim strFechaServidor = FechaServidor()
        Dim dlgRespuesta As Integer
        dlgRespuesta = MessageBox.Show("Está seguro de cerrar la Provisión" & Chr(13) & Chr(13) & _
                                       "Período : " & Me.dtpPeriodoProvision.Text & Chr(13) & _
                                       "Fecha y Hora : " & strFechaServidor & "?", "Cierre de Provisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = vbYes Then
            CerrarProvision()
        End If
    End Sub

    Sub TotalProvision(ByVal opcion As Integer)
        Dim dblTotal As Double = 0
        If tabProvision.SelectedIndex = 0 Then
            For Each row As DataGridViewRow In Me.dgvCalculoProvision.Rows
                dblTotal += row.Cells("monto").Value
            Next
            Me.lblTotalMontoProvision.Text = Format(dblTotal, "###,###,###0.00")
        End If
    End Sub
    Sub CerrarProvision()
        Cursor = Cursors.WaitCursor
        Try
            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable
            Dim strFecha As String = Me.dtpPeriodoProvision.Value.ToShortDateString
            Dim intId As Integer = 0
            Dim intProveedor As Integer
            Dim strFactura As String
            Dim intSolicitud As Integer

            strFecha = "01/" & Format(CDate(strFecha), "MM/yyyy")
            For Each row As DataGridViewRow In Me.dgvCalculoProvision.Rows
                intProveedor = IIf(IsDBNull(row.Cells("id_proveedor").Value), 0, row.Cells("id_proveedor").Value)
                strFactura = IIf(IsDBNull(row.Cells("factura").Value), "", row.Cells("factura").Value)
                intSolicitud = IIf(IsDBNull(row.Cells("solicitud").Value), 0, row.Cells("solicitud").Value)
                dt = obj.CerrarProvision(intId, strFecha, FechaServidor, row.Cells("id_ciudad").Value, intProveedor, strFactura, intSolicitud, _
                                         row.Cells("id_concepto").Value, row.Cells("monto").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                intId = dt.Rows(0).Item(0)
            Next
            lblMensajeProvision.Text = "CERRADO"
            Cursor = Cursors.Default
            MessageBox.Show("Provisión Cerrada", "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Provisión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarFueraZonaAprobados()
        Dim obj As New dtoFueraZona
        Dim strFecha As String, strInicio As String, strFin As String

        strFecha = Me.dtpPeriodoProvisionConsulta.Value.ToShortDateString
        strInicio = "01/" & Format(CDate(strFecha), "MM/yyyy")
        strFin = "01/" + Format(CDate(strFecha), "MM/yyyy")
        strFin = DateAdd(DateInterval.Month, 1, CDate(strFin))
        strFin = DateAdd(DateInterval.Day, -1, CDate(strFin))

        Dim dt As DataTable = obj.ListarFueraZonaAprobados(strInicio, strFin)
        Me.dgvConsultaProvision.DataSource = dt
        TotalConsultaFueraZona()
    End Sub

    Sub TotalConsultaFueraZona()
        Dim dblTotal As Double = 0
        For Each row As DataGridViewRow In Me.dgvConsultaProvision.Rows
            dblTotal += row.Cells("monto_fuera_zona").Value
        Next
        Me.lblTotalConsultaProvision.Text = Format(dblTotal, "###,###,###0.00")
    End Sub

    Sub InicioProvision()
        Try
            Dim obj As New Cls_Gasto_LN
            Dim ds As DataSet = obj.InicioProvision

            With Me.cboCiudadProvision
                .DisplayMember = "descripcion"
                .ValueMember = "id"
                .DataSource = ds.Tables(0)
                .SelectedValue = 0
            End With

            With Me.cboConceptoProvision
                .DisplayMember = "descripcion"
                .ValueMember = "id"
                .DataSource = ds.Tables(1)
                .SelectedValue = 0
            End With

            ConfigurarDGVCalculoProvision()
            ActualizaEstadoProvision()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Provisión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConfiguracionProvision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfiguracionProvision.Click
        RemoveHandler chkCiudadProvision.CheckedChanged, AddressOf chkCiudadProvision_CheckedChanged
        'Me.chkCiudadProvision.Checked = aGrupoProvision(0) : Me.chkConceptoProvision.Checked = aGrupoProvision(1) : Me.chkProveedorProvision.Checked = aGrupoProvision(2) : Me.chkFacturaProvision.Checked = aGrupoProvision(3)
        AddHandler chkCiudadProvision.CheckedChanged, AddressOf chkCiudadProvision_CheckedChanged

        pnlConfiguracionProvision.Visible = Not pnlConfiguracionProvision.Visible
    End Sub

    Private Sub btnSalirProvision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirProvision.Click
        pnlConfiguracionProvision.Visible = False
    End Sub

    Private Sub chkCiudadProvision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCiudadProvision.CheckedChanged, chkConceptoProvision.CheckedChanged, chkProveedorProvision.CheckedChanged, chkFacturaProvision.CheckedChanged
        aGrupoProvision(0) = Me.chkCiudadProvision.Checked : aGrupoProvision(1) = Me.chkConceptoProvision.Checked : aGrupoProvision(2) = Me.chkProveedorProvision.Checked : aGrupoProvision(3) = Me.chkFacturaProvision.Checked
        If Not IsNothing(dtResumenProvision) Then
            If dtResumenProvision.Rows.Count > 0 Then
                ConfigurarResumenProvision()
            Else
                Me.dgvCalculoProvision.DataSource = Nothing
            End If
        End If

        TotalCabeceraProvision()
        TotalResumenProvision()

        Me.btnCierreProvision.Enabled = aGrupoProvision(0) And aGrupoProvision(1) And aGrupoProvision(2) And aGrupoProvision(3)
    End Sub

    Sub ConfigurarResumenProvision()
        Dim dtJoin
        If aGrupoProvision(0) Then
            ResumenProvision1(dtJoin)
        ElseIf aGrupoProvision(1) Then
            ResumenProvision2(dtJoin)
        ElseIf aGrupoProvision(2) Then
            ResumenProvision3(dtJoin)
        ElseIf aGrupoProvision(3) Then
            ResumenProvision4(dtJoin)
        End If

        With Me.dgvCalculoProvision
            '.DataSource = Nothing
            .DataSource = dtJoin
        End With
    End Sub

    Sub TotalResumenProvision()
        If Me.dgvCalculoProvision.Rows.Count > 0 And (aGrupoProvision(0) Or aGrupoProvision(1) Or aGrupoProvision(2) Or aGrupoProvision(3)) Then
            Dim dblGasto As Double = IIf(IsDBNull(dtResumenProvision.Compute("sum(monto)", "")), 0, dtResumenProvision.Compute("sum(monto)", ""))
            Me.lblTotalMontoProvision.Text = Format(dblGasto, "###,###,###0.00")
            Me.btnExportarProvision.Enabled = True
        Else
            Me.lblTotalMontoProvision.Text = Format(0, "###,###,###0.00")
            Me.btnExportarProvision.Enabled = False
        End If
    End Sub

    Sub TotalCabeceraProvision()
        With Me.dgvCalculoProvision
            .Columns("ciudad").Visible = aGrupoProvision(0)
            .Columns("concepto").Visible = aGrupoProvision(1)
            .Columns("proveedor").Visible = aGrupoProvision(2)
            .Columns("factura").Visible = aGrupoProvision(3)
        End With
    End Sub

    Sub ResumenProvision1(ByRef dtJoin)
        'ciudad
        If aGrupoProvision(0) And aGrupoProvision(1) = False And aGrupoProvision(2) = False And aGrupoProvision(3) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!id_ciudad Into Grouping = Group _
                          Select ciudad, id_ciudad, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'ciudad,concepto
        ElseIf aGrupoProvision(0) And aGrupoProvision(1) And aGrupoProvision(2) = False And aGrupoProvision(3) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!concepto, row!id_ciudad, row!id_concepto Into Grouping = Group _
                          Select ciudad, concepto, id_ciudad, id_concepto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'ciudad,proveedor
        ElseIf aGrupoProvision(0) And aGrupoProvision(1) = False And aGrupoProvision(2) And aGrupoProvision(3) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!proveedor, row!id_ciudad, row!id_proveedor Into Grouping = Group _
                          Select ciudad, proveedor, id_ciudad, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'ciudad,factura
        ElseIf aGrupoProvision(0) And aGrupoProvision(1) = False And aGrupoProvision(2) = False And aGrupoProvision(3) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!factura, row!id_ciudad Into Grouping = Group _
                          Select ciudad, factura, id_ciudad, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'ciudad,concepto,proveedor,factura
        ElseIf aGrupoProvision(0) And aGrupoProvision(1) And aGrupoProvision(2) And aGrupoProvision(3) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!concepto, row!proveedor, row!factura, row!id_ciudad, row!id_concepto, row!id_proveedor Into Grouping = Group _
                          Select ciudad, concepto, proveedor, factura, id_ciudad, id_concepto, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'ciudad,concepto,proveedor
        ElseIf aGrupoProvision(0) And aGrupoProvision(1) And aGrupoProvision(2) And aGrupoProvision(3) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!concepto, row!proveedor, row!id_ciudad, row!id_concepto, row!id_proveedor Into Grouping = Group _
                          Select ciudad, concepto, proveedor, id_ciudad, id_concepto, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'ciudad,concepto,factura
        ElseIf aGrupoProvision(0) And aGrupoProvision(1) And aGrupoProvision(2) = False And aGrupoProvision(3) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!concepto, row!factura, row!id_ciudad, row!id_concepto Into Grouping = Group _
                          Select ciudad, concepto, factura, id_ciudad, id_concepto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'ciudad,proveedor,factura
        ElseIf aGrupoProvision(0) And aGrupoProvision(1) = False And aGrupoProvision(2) And aGrupoProvision(3) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!proveedor, row!factura, row!id_ciudad, row!id_proveedor Into Grouping = Group _
                          Select ciudad, proveedor, factura, id_ciudad, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList
        End If
    End Sub

    Sub ResumenProvision2(ByRef dtJoin)
        'concepto
        If aGrupoProvision(1) And aGrupoProvision(0) = False And aGrupoProvision(2) = False And aGrupoProvision(3) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!concepto, row!id_concepto Into Grouping = Group _
                          Select concepto, id_concepto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'concepto,ciudad
        ElseIf aGrupoProvision(1) And aGrupoProvision(0) And aGrupoProvision(2) = False And aGrupoProvision(3) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!concepto, row!id_ciudad, row!id_concepto Into Grouping = Group _
                          Select ciudad, concepto, id_ciudad, id_concepto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'concepto,proveedor
        ElseIf aGrupoProvision(1) And aGrupoProvision(0) = False And aGrupoProvision(2) And aGrupoProvision(3) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!concepto, row!proveedor, row!id_concepto, row!id_proveedor Into Grouping = Group _
                          Select concepto, proveedor, id_concepto, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'concepto,factura
        ElseIf aGrupoProvision(1) And aGrupoProvision(0) = False And aGrupoProvision(2) = False And aGrupoProvision(3) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!concepto, row!factura, row!id_concepto Into Grouping = Group _
                          Select concepto, factura, id_concepto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'concepto,ciudad,proveedor,factura
        ElseIf aGrupoProvision(1) And aGrupoProvision(0) And aGrupoProvision(2) And aGrupoProvision(3) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!concepto, row!proveedor, row!id_concepto, row!id_proveedor Into Grouping = Group _
                          Select concepto, proveedor, id_concepto, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'concepto,ciudad,proveedor
        ElseIf aGrupoProvision(1) And aGrupoProvision(0) And aGrupoProvision(2) And aGrupoProvision(3) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!concepto, row!proveedor, row!id_ciudad, row!id_concepto, row!id_proveedor Into Grouping = Group _
                          Select ciudad, concepto, proveedor, id_ciudad, id_concepto, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'concepto,ciudad,factura
        ElseIf aGrupoProvision(1) And aGrupoProvision(0) And aGrupoProvision(2) = False And aGrupoProvision(3) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!concepto, row!factura, row!id_ciudad, row!id_concepto Into Grouping = Group _
                          Select ciudad, concepto, factura, id_ciudad, id_concepto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'concepto,proveedor,factura
        ElseIf aGrupoProvision(1) And aGrupoProvision(0) = False And aGrupoProvision(2) And aGrupoProvision(3) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!concepto, row!proveedor, row!factura, row!id_concepto, row!id_proveedor Into Grouping = Group _
                          Select concepto, proveedor, factura, id_concepto, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

        End If
    End Sub

    Sub ResumenProvision3(ByRef dtJoin)
        'proveedor
        If aGrupoProvision(2) And aGrupoProvision(0) = False And aGrupoProvision(1) = False And aGrupoProvision(3) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!proveedor, row!id_proveedor Into Grouping = Group _
                          Select proveedor, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'proveedor,ciudad
        ElseIf aGrupoProvision(2) And aGrupoProvision(0) And aGrupoProvision(1) = False And aGrupoProvision(3) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!proveedor, row!id_ciudad, row!id_proveedor Into Grouping = Group _
                          Select ciudad, proveedor, id_ciudad, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'proveedor,concepto
        ElseIf aGrupoProvision(2) And aGrupoProvision(0) = False And aGrupoProvision(1) And aGrupoProvision(3) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!concepto, row!proveedor, row!id_concepto, row!id_proveedor Into Grouping = Group _
                          Select concepto, proveedor, id_concepto, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'proveedor,factura
        ElseIf aGrupoProvision(2) And aGrupoProvision(0) = False And aGrupoProvision(1) = False And aGrupoProvision(3) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!proveedor, row!factura, row!id_proveedor Into Grouping = Group _
                          Select proveedor, factura, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'proveedor,ciudad,concepto,factura
        ElseIf aGrupoProvision(2) And aGrupoProvision(0) And aGrupoProvision(1) And aGrupoProvision(3) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!concepto, row!proveedor, row!factura, row!id_ciudad, row!id_concepto, row!id_proveedor Into Grouping = Group _
                          Select ciudad, concepto, proveedor, factura, id_ciudad, id_concepto, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'proveedor,ciudad,concepto
        ElseIf aGrupoProvision(2) And aGrupoProvision(0) And aGrupoProvision(1) And aGrupoProvision(3) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!concepto, row!proveedor, row!id_ciudad, row!id_concepto, row!id_proveedor Into Grouping = Group _
                          Select ciudad, concepto, proveedor, id_ciudad, id_concepto.id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'proveedor,ciudad,factura
        ElseIf aGrupoProvision(2) And aGrupoProvision(0) And aGrupoProvision(1) = False And aGrupoProvision(3) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!proveedor, row!factura, row!id_ciudad, row!id_proveedor Into Grouping = Group _
                          Select ciudad, proveedor, factura, id_ciudad, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'proveedor,concepto,factura
        ElseIf aGrupoProvision(2) And aGrupoProvision(0) = False And aGrupoProvision(1) And aGrupoProvision(3) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!concepto, row!proveedor, row!factura, row!id_concepto, row!id_proveedor Into Grouping = Group _
                          Select concepto, proveedor, factura, id_concepto, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList
        End If
    End Sub

    Sub ResumenProvision4(ByRef dtJoin)
        'factura
        If aGrupoProvision(3) And aGrupoProvision(0) = False And aGrupoProvision(1) = False And aGrupoProvision(2) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!factura Into Grouping = Group _
                          Select factura, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'factura,ciudad
        ElseIf aGrupoProvision(3) And aGrupoProvision(0) And aGrupoProvision(1) = False And aGrupoProvision(2) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!factura, row!id_ciudad Into Grouping = Group _
                          Select ciudad, factura, id_ciudad, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'factura,concepto
        ElseIf aGrupoProvision(3) And aGrupoProvision(0) = False And aGrupoProvision(1) And aGrupoProvision(2) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!concepto, row!factura, row!id_concepto Into Grouping = Group _
                          Select concepto, factura, id_concepto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'factura,proveedor
        ElseIf aGrupoProvision(3) And aGrupoProvision(0) = False And aGrupoProvision(1) = False And aGrupoProvision(2) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!proveedor, row!factura, row!id_proveedor Into Grouping = Group _
                          Select proveedor, factura, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'factura,ciudad,concepto,proveedor
        ElseIf aGrupoProvision(3) And aGrupoProvision(0) And aGrupoProvision(1) And aGrupoProvision(2) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!concepto, row!proveedor, row!factura, row!id_ciudad, row!id_concepto, row!id_proveedor Into Grouping = Group _
                          Select ciudad, concepto, proveedor, id_ciudad, id_concepto, id_proveedor, factura, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'factura,ciudad,concepto
        ElseIf aGrupoProvision(3) And aGrupoProvision(0) And aGrupoProvision(1) And aGrupoProvision(2) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!concepto, row!factura, row!id_ciudad, row!id_concepto Into Grouping = Group _
                          Select ciudad, concepto, factura, id_ciudad, id_concepto, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'factura,ciudad,proveedor
        ElseIf aGrupoProvision(3) And aGrupoProvision(0) And aGrupoProvision(1) = False And aGrupoProvision(2) = False Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!ciudad, row!proveedor, row!factura, row!id_ciudad, row!id_proveedor Into Grouping = Group _
                          Select ciudad, proveedor, factura, id_ciudad, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList

            'factura,concepto,proveedor
        ElseIf aGrupoProvision(3) And aGrupoProvision(0) = False And aGrupoProvision(1) And aGrupoProvision(2) Then
            dtJoin = (From row In dtResumenProvision.Rows Group row By row!concepto, row!proveedor, row!factura, row!id_concepto, row!id_proveedor Into Grouping = Group _
                          Select concepto, proveedor, factura, id_concepto, id_proveedor, monto = Grouping.Sum(Function(p) Decimal.Parse(p!monto))).ToList
        End If
    End Sub

    Private Sub btnExportarProvision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarProvision.Click
        Cursor = Cursors.AppStarting
        Dim xlApp As New Excel.Application()
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        Dim dblTotal As Double = 0, intColumna As Integer = 0
        Try
            Dim rowIndex, colIndex, i, j As Integer
            rowIndex = 1
            colIndex = 0
            xlBook = xlApp.Workbooks().Add
            xlSheet = xlBook.Worksheets("hoja1")

            'detalle
            rowIndex = 1
            For i = 0 To dgvCalculoProvision.Rows.Count - 1
                rowIndex = rowIndex + 1
                colIndex = 0
                For j = 0 To dgvCalculoProvision.Columns.Count - 1
                    If dgvCalculoProvision.Columns(j).Visible Then
                        colIndex = colIndex + 1
                        xlApp.Cells(1, colIndex) = dgvCalculoProvision.Columns(j).Name.ToString.ToUpper
                        xlApp.Cells(rowIndex, colIndex) = dgvCalculoProvision.Rows(i).Cells(j).Value
                        xlSheet.Range(xlSheet.Cells(rowIndex, colIndex), xlSheet.Cells(rowIndex, colIndex)).NumberFormat = "###,###,###.00"
                        If dgvCalculoProvision.Columns(j).Name.ToString.ToUpper = "MONTO" Then
                            intColumna = colIndex
                            dblTotal += dgvCalculoProvision.Rows(i).Cells(j).Value
                        End If
                    End If
                Next
            Next
            xlApp.Cells(rowIndex + 1, intColumna - 1) = "TOTAL"
            xlApp.Cells(rowIndex + 1, intColumna) = Format(dblTotal, "###,###,###0.00")

            xlSheet.Range(xlSheet.Cells(1, 1), xlSheet.Cells(1, colIndex)).Font.Bold = True
            xlSheet.Range(xlSheet.Cells(rowIndex + 1, intColumna - 1), xlSheet.Cells(rowIndex + 1, intColumna)).Font.Bold = True
            xlSheet.Columns.AutoFit()

            Cursor = Cursors.Default
            xlApp.Visible = True
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            xlApp.Quit()
            xlApp.Visible = False
        End Try

    End Sub

    '--------------------------------------------------- TRASLADO --------------------------------------------------------------------
    Sub LimpiarSolicitudTraslado()
        'FormateardgvListaRecojo()
        Me.dgvTraslado.Rows.Clear()

        Me.txtRucProveedorTraslado.Text = ""
        Me.txtRazonSocialProveedorTraslado.Text = ""

        Me.lblNumeroSolicitudTraslado.Text = ""
        Me.lblCiudadTraslado.Text = dtoUSUARIOS.m_iNombreUnidadAgencia
        Me.lblSolicitanteTraslado.Text = dtoUSUARIOS.NameLogin

        Me.txtMontoTraslado.Text = "0.00"
        Me.txtObservacionTraslado.Text = ""
        Me.txtGrtTraslado.Text = ""

        Me.lblfechaTraslado.Text = Format(FechaServidor, "Short Date")
        Me.btnQuitarGrtTraslado.Enabled = False

        LimpiarTraslado()
    End Sub

    Sub LimpiarTraslado()
        Dim dtEstiba As New Cls_Gasto_LN
        dtEstiba.LimpiarEstiba(dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
    End Sub

    Sub AgregarTraslado(ByVal dt As DataTable, ByVal dgv As DataGridView, ByVal formato As Integer, Optional ByVal fila As Integer = 0, Optional ByVal opcion As Integer = 0)
        With dgv
            .Rows.Add()
            If formato = 0 Then
                dgv(0, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_grt")
                dgv(1, .Rows.Count - 1).Value = dt.Rows(fila).Item("bus")

                dgv(2, .Rows.Count - 1).Value = dt.Rows(fila).Item("grt")
                dgv(3, .Rows.Count - 1).Value = dt.Rows(fila).Item("origen")
                dgv(4, .Rows.Count - 1).Value = dt.Rows(fila).Item("destino")
                dgv(5, .Rows.Count - 1).Value = dt.Rows(fila).Item("peso")
                dgv(6, .Rows.Count - 1).Value = dt.Rows(fila).Item("cantidad")
                If opcion = 0 Then
                    dgv(7, .Rows.Count - 1).Value = 0
                Else
                    dgv(7, .Rows.Count - 1).Value = dt.Rows(fila).Item("estado")
                End If
            Else
                If opcion = 0 Then
                    dgv(0, .Rows.Count - 1).Value = 0 'id cabecera
                    dgv(1, .Rows.Count - 1).Value = 0 'id detalle
                    dgv(10, .Rows.Count - 1).Value = 0 'nuevo
                Else
                    dgv(0, .Rows.Count - 1).Value = dt.Rows(fila).Item("id") 'id cabecera
                    dgv(1, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_2") 'id detalle
                    dgv(10, .Rows.Count - 1).Value = dt.Rows(fila).Item("estado") 'nuevo
                End If
                dgv(2, .Rows.Count - 1).Value = CDate(dt.Rows(fila).Item("fecha"))
                dgv(3, .Rows.Count - 1).Value = dt.Rows(fila).Item("tipo")
                dgv(4, .Rows.Count - 1).Value = dt.Rows(fila).Item("comprobante")
                dgv(5, .Rows.Count - 1).Value = dt.Rows(fila).Item("origen")
                dgv(6, .Rows.Count - 1).Value = dt.Rows(fila).Item("destino")
                dgv(7, .Rows.Count - 1).Value = dt.Rows(fila).Item("cliente")
                dgv(8, .Rows.Count - 1).Value = dt.Rows(fila).Item("peso")
                dgv(9, .Rows.Count - 1).Value = dt.Rows(fila).Item("cantidad")
                dgv(11, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_comprobante")
                dgv(12, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_tipo")
                dgv(13, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_origen")
                dgv(14, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_destino")
                dgv(15, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_persona")
                dgv(16, .Rows.Count - 1).Value = dt.Rows(fila).Item("producto")
            End If
        End With
    End Sub

    Sub TotalizarTraslado()
        Dim dblPeso As Double = 0
        Dim intCantidad As Integer = 0

        With Me.dgvTraslado
            For Each row As DataGridViewRow In .Rows
                If row.Cells("estado").Value < 2 Then
                    dblPeso += row.Cells("peso").Value
                    intCantidad += row.Cells("cantidad").Value
                End If
            Next
        End With
        Me.lblPesoTraslado.Text = Format(dblPeso, "###,###,###0.00")
        Me.lblCantidadTraslado.Text = intCantidad

        If dblPeso + intCantidad = 0 Then
            Me.btnQuitarGrtTraslado.Enabled = False
        Else
            Me.btnQuitarGrtTraslado.Enabled = True
        End If
    End Sub

    Sub MostrarSolicitudTraslado(ByVal row As Integer)
        With dgvListaTraslado
            If .Rows(row).Cells("formato").Value = 0 Then
                Me.rbtGrtTraslado.Checked = True
            Else
                Me.rbtComprobanteTraslado.Checked = True
            End If

            Me.lblNumeroSolicitudTraslado.Text = .Rows(row).Cells("numero").Value
            Me.lblfechaTraslado.Text = .Rows(row).Cells("fecha_solicitud").Value
            Me.lblCiudadTraslado.Text = .Rows(row).Cells("ciudad").Value
            Me.lblSolicitanteTraslado.Text = .Rows(row).Cells("solicitante").Value
            Me.txtObservacionTraslado.Text = IIf(IsDBNull(.Rows(row).Cells("observacion").Value), "", .Rows(row).Cells("observacion").Value)

            Me.dtpFechaOperacionTraslado.Value = .Rows(row).Cells("fecha_operacion").Value

            Me.txtRucProveedorTraslado.Text = IIf(IsDBNull(.CurrentRow.Cells("ruc").Value), "", .CurrentRow.Cells("ruc").Value)
            If Not IsDBNull(.CurrentRow.Cells("id_proveedor").Value) Then
                Me.txtRucProveedorTraslado.Tag = IIf(.CurrentRow.Cells("id_proveedor").Value = 0, "", (.CurrentRow.Cells("id_proveedor").Value))
            Else
                Me.txtRucProveedorTraslado.Tag = 0
            End If
            Me.txtRazonSocialProveedorTraslado.Text = IIf(IsDBNull(.CurrentRow.Cells("proveedor").Value), "", .CurrentRow.Cells("proveedor").Value)
            Me.txtRazonSocialProveedorTraslado.Enabled = False

            Me.txtMontoTraslado.Text = Format(.Rows(row).Cells("monto").Value, "###,###,###0.00")

            Me.dgvTrasladoAprobacion.Rows.Clear()
            Dim intID As Integer = .CurrentRow.Cells("id").Value
            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable = obj.ListarTrasladoDetalle(intID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, .Rows(row).Cells("formato").Value)

            Dim intFila As Integer = 0
            For Each row1 As DataRow In dt.Rows
                intFila += 1
                AgregarTraslado(dt, Me.dgvTraslado, .Rows(row).Cells("formato").Value, intFila - 1, 1)
            Next

            TotalizarTraslado()

            If .Rows(row).Cells("id_estado").Value = 1 Then
                Me.txtMontoTraslado.Enabled = True
                Me.txtObservacionTraslado.Enabled = True
                Me.dtpFechaOperacionTraslado.Enabled = True

                Me.txtGrtTraslado.Enabled = True
                Me.btnAgregarTraslado.Enabled = True
                Me.btnQuitarGrtTraslado.Enabled = True

                Me.txtRucProveedorTraslado.Enabled = True
                'Me.txtRazonSocialProveedor.Enabled = True

                Me.grbTrasladoGrt.Enabled = True
                Me.grbTrasladoComprobante.Enabled = True

                If Me.rbtGrtTraslado.Checked Then
                    Me.rbtComprobanteTraslado.Enabled = False
                    Me.rbtGrtTraslado.Enabled = True
                Else
                    Me.rbtGrtTraslado.Enabled = False
                    Me.rbtComprobanteTraslado.Enabled = True
                End If

                Me.tsbGrabar.Enabled = True
            Else
                Me.txtMontoTraslado.Enabled = False
                Me.txtObservacionTraslado.Enabled = False
                Me.dtpFechaOperacionTraslado.Enabled = False
                Me.txtGrtTraslado.Enabled = False
                Me.btnAgregarTraslado.Enabled = False
                Me.btnQuitarGrtTraslado.Enabled = False

                Me.txtRucProveedorTraslado.Enabled = False
                Me.txtRazonSocialProveedorTraslado.Enabled = False

                Me.rbtGrtTraslado.Enabled = False
                Me.rbtComprobanteTraslado.Enabled = False
                Me.grbTrasladoGrt.Enabled = False
                Me.grbTrasladoComprobante.Enabled = False

                Me.tsbGrabar.Enabled = False
            End If
        End With
    End Sub

    Sub LimpiarAprobacionTraslado()
        lblFechaTrasladoAprobacion.Text = Format(FechaServidor, "Short Date")
        Me.lblCiudadTrasladoAprobacion.Text = ""
        Me.lblSolicitanteTrasladoAprobacion.Text = ""
        Me.dgvTrasladoAprobacion.DataSource = Nothing
        Me.lblMontoTrasladoAprobacion.Text = ""
        Me.lblObservacionTrasladoAprobacion.Text = ""

        Me.rbtSiTrasladoAprobacion.Checked = True
        Me.txtObservacionTrasladoAprobacion.Text = ""
        Me.lblPesoTrasladoAprobacion.Text = ""
        Me.lblCantidadTrasladoAprobacion.Text = ""
        Me.lblSolesKgTraslado.Text = ""
    End Sub

    Sub ListarTrasladoDetalle(ByVal id As Integer, ByVal formato As Integer)
        Dim obj As New Cls_Gasto_LN
        Me.dgvTrasladoAprobacion.DataSource = obj.ListarTrasladoDetalle(id, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, formato)
    End Sub

    Private Sub tabTraslado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabTraslado.SelectedIndexChanged
        If tabTraslado.SelectedTab Is tabTraslado.TabPages("tabListaTraslado") Then
            If tabTraslado.TabPages.IndexOf(tabSolicitudTraslado) > -1 Then
                tsbNuevo.Enabled = True : tsbEditar.Enabled = Me.dgvListaTraslado.Rows.Count > 0 : tsbAnular.Enabled = Me.dgvListaTraslado.Rows.Count > 0
                tsbGrabar.Enabled = False
            Else
                tsbNuevo.Enabled = False : tsbEditar.Enabled = Me.dgvListaTraslado.Rows.Count > 0 : tsbAnular.Enabled = False
                tsbGrabar.Enabled = False
            End If
            FormateardgvListaTraslado()
        ElseIf tabTraslado.SelectedTab Is tabTraslado.TabPages("tabSolicitudTraslado") Then
            LimpiarSolicitudTraslado()
            If Me.dgvListaTraslado.Rows.Count > 0 Then
                tsbEditar_Click(Nothing, Nothing)
            Else
                tsbNuevo_Click(Nothing, Nothing)
            End If
        ElseIf tabTraslado.SelectedTab Is tabTraslado.TabPages("tabAprobacionTraslado") Then
            LimpiarAprobacionTraslado()
            Me.tsbGrabar.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False

            If Me.dgvListaTraslado.Rows.Count > 0 Then
                Me.rbtSiTrasladoAprobacion.Enabled = True
                Me.rbtNoTrasladoAprobacion.Enabled = True
                Me.txtObservacionTrasladoAprobacion.Enabled = True
                Me.btnAceptarTrasladoAprobacion.Enabled = True
                Me.grbTrasladoAprobacion.Enabled = True

                Me.lblFechaTrasladoAprobacion.Text = Me.dgvListaTraslado.CurrentRow.Cells("fecha_operacion").Value

                Me.lblCiudadTrasladoAprobacion.Text = Me.dgvListaTraslado.CurrentRow.Cells("ciudad").Value
                Me.lblSolicitanteTrasladoAprobacion.Text = Me.dgvListaTraslado.CurrentRow.Cells("solicitante").Value
                Me.lblObservacionTrasladoAprobacion.Text = Me.dgvListaTraslado.CurrentRow.Cells("observacion").Value

                Me.lblMontoTrasladoAprobacion.Text = Format(CDbl(Me.dgvListaTraslado.CurrentRow.Cells("monto").Value), "###,###,###0.00")

                Dim intID As Integer = Me.dgvListaTraslado.CurrentRow.Cells("id").Value
                ListarTrasladoDetalle(intID, Me.dgvListaTraslado.CurrentRow.Cells("formato").Value)

                Dim dblPeso As Double = ObtieneSuma(Me.dgvTrasladoAprobacion, Me.dgvTrasladoAprobacion.Columns("peso").Index)
                Dim intCantidad As Double = ObtieneSuma(Me.dgvTrasladoAprobacion, Me.dgvTrasladoAprobacion.Columns("cantidad").Index)

                Me.lblPesoTrasladoAprobacion.Text = Format(dblPeso, "0.00")
                Me.lblCantidadTrasladoAprobacion.Text = intCantidad

                Dim dblSoles As Double = Me.lblMontoTrasladoAprobacion.Text
                Dim dblSolesKg As Double = dblSoles / dblPeso
                Me.lblSolesKgTraslado.Text = Format(dblSolesKg, "###,###,###0.00")

                If Me.dgvListaTraslado.CurrentRow.Cells("formato").Value = 0 Then
                    ConfigurarDGVTrasladoAprobacion(1)
                Else
                    ConfigurarDGVTrasladoAprobacion(2)
                End If
                Me.btnAceptarTrasladoAprobacion.Focus()

                If Me.dgvListaTraslado.CurrentRow.Cells("id_estado").Value > 1 Then
                    Me.rbtSiTrasladoAprobacion.Enabled = False
                    Me.rbtNoTrasladoAprobacion.Enabled = False
                    Me.txtObservacionTrasladoAprobacion.Enabled = False
                    Me.btnAceptarTrasladoAprobacion.Enabled = False
                    Me.grbTrasladoAprobacion.Enabled = False
                End If
            Else
                Me.rbtSiTrasladoAprobacion.Enabled = False
                Me.rbtNoTrasladoAprobacion.Enabled = False
                Me.txtObservacionTrasladoAprobacion.Enabled = False
                Me.btnAceptarTrasladoAprobacion.Enabled = False
                Me.grbTrasladoAprobacion.Enabled = False
            End If
        End If
    End Sub

    Sub QuitarTraslado()
        Dim strMensaje As String
        If Me.rbtGrtTraslado.Checked Then
            strMensaje = "¿Está Seguro de Desactivar el Nº de GRT Seleccionado?"
        Else
            strMensaje = "¿Está Seguro de Desactivar el Comprobante Seleccionado?"
        End If
        With dgvTraslado
            If .Rows.Count > 0 Then
                Dim dlgRespuesta As DialogResult = MessageBox.Show(strMensaje, "Desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    If dgvTraslado.CurrentRow.Cells("estado").Value = 0 Then 'GRT no grabado
                        .Rows.Remove(.CurrentRow)
                    Else 'Comprobante grabado
                        dgvTraslado.CurrentRow.Cells("estado").Value = 2
                        dgvTraslado.CurrentRow.Visible = False
                    End If
                    TotalizarTraslado()

                    Dim i As Integer = 0
                    If ObtieneItemActivo(Me.dgvTraslado) > 0 Then
                        For Each row As DataGridViewRow In .Rows
                            If row.Cells("estado").Value < 2 Then
                                i += 1
                                Exit For
                            End If
                        Next
                        .Rows(i).Selected = True
                        .CurrentCell = .Rows(i).Cells(2)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub btnQuitarGrtTraslado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarGrtTraslado.Click
        If Me.dgvTraslado.Rows.Count > 0 Then
            QuitarTraslado()
        End If
    End Sub

    Private Sub btnAgregarTraslado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarTraslado.Click
        Try
            If Me.rbtGrtTraslado.Checked Then
                If Me.txtGrtTraslado.Text.Trim.Length = 0 Then Return
            Else
                If Me.txtComprobanteTraslado.Text.Trim.Length = 0 Then Return
            End If

            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN

            If Me.rbtGrtTraslado.Checked Then
                Dim strNroDoc As String() = Split(txtGrtTraslado.Text, "-")
                Dim intSerie As Integer, intNumero As Integer

                If strNroDoc.Length > 1 Then
                    If Val(strNroDoc(0)) > 0 And Val(strNroDoc(1)) > 0 Then
                        intSerie = strNroDoc(0)
                        intNumero = strNroDoc(1)
                    Else
                        If Val(strNroDoc(1)) > 0 Then
                            intNumero = strNroDoc(1)
                        End If
                    End If
                ElseIf strNroDoc.Length = 1 Then
                    If Val(strNroDoc(0)) > 0 Then
                        intNumero = strNroDoc(0)
                    End If
                End If

                If intSerie = 0 And intNumero = 0 Then
                    Cursor = Cursors.Default
                    Return
                End If

                Dim dt As DataTable = obj.ListarGrtTraslado(intSerie, intNumero, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, 1)
                If dt.Rows.Count > 0 Then
                    If Not ExisteValorGrid(Me.dgvTraslado, Me.dgvTraslado.Columns("id_grt").Index, dt.Rows(0).Item("id_grt")) Then
                        AgregarTraslado(dt, dgvTraslado, 0)
                        Me.txtGrtTraslado.Focus()
                        Me.txtGrtTraslado.SelectAll()
                    Else
                        Cursor = Cursors.Default
                        MessageBox.Show("El Nº de GRT ya existe en la Lista", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtGrtTraslado.Focus()
                        Me.txtGrtTraslado.SelectAll()
                    End If
                Else
                    Cursor = Cursors.Default
                    MessageBox.Show("El Nº de GRT no se encuentra Disponible", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtGrtTraslado.Focus()
                    Me.txtGrtTraslado.SelectAll()
                End If
            Else
                Dim strNroDoc As String() = Split(txtComprobanteTraslado.Text, "-")
                If strNroDoc.Length > 1 Then
                    If strNroDoc(0).Trim.Length > 1 And Val(strNroDoc(1)) > 0 Then
                        ObjEntrega_Recojo.v_serie = strNroDoc(0)
                        ObjEntrega_Recojo.v_nroDoc = strNroDoc(1)
                    Else
                        ObjEntrega_Recojo.v_serie = "0"
                        ObjEntrega_Recojo.v_nroDoc = "0"
                    End If
                Else
                    If strNroDoc.Length = 1 Then
                        ObjEntrega_Recojo.v_serie = "-1"
                        ObjEntrega_Recojo.v_nroDoc = strNroDoc(0)
                    Else
                        ObjEntrega_Recojo.v_serie = "0"
                        ObjEntrega_Recojo.v_nroDoc = "0"
                    End If
                End If

                Dim dt As DataTable = obj.ListarDisponibleTraslado(ObjEntrega_Recojo.v_serie, ObjEntrega_Recojo.v_nroDoc, Me.cboTipoTraslado.SelectedIndex)
                If dt.Rows.Count > 0 Then
                    If Not ExisteValorGrid(Me.dgvTraslado, Me.dgvTraslado.Columns("id_comprobante").Index, dt.Rows(0).Item("id_comprobante")) Then
                        Agregar(dt, dgvTraslado, 1)
                        Me.txtComprobanteTraslado.Focus()
                        Me.txtComprobanteTraslado.SelectAll()
                    Else
                        Cursor = Cursors.Default
                        MessageBox.Show("El Comprobante ya existe en la Lista", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtComprobanteTraslado.Focus()
                        Me.txtComprobanteTraslado.SelectAll()
                    End If
                Else
                    Cursor = Cursors.Default
                    MessageBox.Show("El Comprobante no se encuentra Disponible", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtComprobanteTraslado.Focus()
                    Me.txtComprobanteTraslado.SelectAll()
                End If
            End If
            TotalizarTraslado()
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Traslado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtGrtTraslado.Focus()
            Me.txtGrtTraslado.SelectAll()
        End Try
    End Sub

    Private Sub txtObservacionTraslado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacionTraslado.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservacionTraslado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacionTraslado.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtMontoTraslado_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoTraslado.Enter
        Me.txtMontoTraslado.SelectAll()
    End Sub

    Private Sub txtMontoTraslado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoTraslado.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtMontoTraslado.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMontoTraslado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoTraslado.LostFocus
        If Val(Me.txtMontoTraslado.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtMontoTraslado.Text)
            Me.txtMontoTraslado.Text = Format(dblMonto, "0.00")
        Else
            Me.txtMontoTraslado.Text = ""
        End If
    End Sub

    Private Sub txtRucProveedorTraslado_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedorTraslado.Enter
        txtRucProveedorTraslado.SelectAll()
    End Sub

    Private Sub txtRucProveedorTraslado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRucProveedorTraslado.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtRucProveedorTraslado_LostFocus(Nothing, Nothing)
            If Me.txtRazonSocialProveedorTraslado.Enabled Then
                Me.txtRazonSocialProveedorTraslado.Focus()
            Else
                SendKeys.Send(vbTab)
            End If
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRucProveedorTraslado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedorTraslado.LostFocus
        If Me.txtRucProveedorTraslado.Text.Trim.Length > 0 Then
            Dim intId As Integer = 0, strRazonSocial As String = "", strRuc As String
            strRuc = Me.txtRucProveedorTraslado.Text.Trim
            ListarProveedor(strRuc, intId, strRazonSocial)
            If intId > 0 Then
                Me.txtRucProveedorTraslado.Tag = intId
                Me.txtRazonSocialProveedorTraslado.Text = strRazonSocial
                Me.txtRazonSocialProveedorTraslado.Enabled = False
            ElseIf intLlamada = 0 Then
                Me.txtRucProveedorTraslado.Tag = ""
                Me.txtRazonSocialProveedorTraslado.Text = ""
                Me.txtRazonSocialProveedorTraslado.Enabled = True
                Me.txtRazonSocialProveedorTraslado.Focus()
            End If
        Else
            Me.txtRazonSocialProveedorTraslado.Focus()
        End If
    End Sub

    Private Sub txtRucProveedorTraslado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRucProveedorTraslado.TextChanged
        Me.txtRazonSocialProveedorTraslado.Text = ""
        Me.txtRucProveedorTraslado.Tag = ""
        Me.txtRazonSocialProveedorTraslado.Enabled = True
    End Sub

    Private Sub txtRazonSocialProveedorTraslado_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazonSocialProveedorTraslado.Enter
        txtRazonSocialProveedorTraslado.SelectAll()
    End Sub

    Private Sub txtRazonSocialProveedorTraslado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazonSocialProveedorTraslado.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboEstadoSolicitudTraslado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ListarTraslado(dtoUSUARIOS.m_idciudad, Me.cboEstadoSolicitudTraslado.SelectedIndex, Me.dgvListaTraslado)
        'If Me.dgvListaTraslado.Rows.Count > 0 Then
        '    Me.tsbEditar.Enabled = True
        '    If Me.dgvListaTraslado.CurrentRow.Cells("id_estado").Value = 1 Then
        '        Me.tsbAnular.Enabled = IIf(tabTraslado.TabPages.IndexOf(tabSolicitudTraslado) > -1, True, False)
        '        Me.tsbEditar.Enabled = True
        '    Else
        '        Me.tsbAnular.Enabled = False
        '        'Me.tsbEditar.Enabled = False
        '    End If
        'Else
        '    Me.tsbEditar.Enabled = False
        '    Me.tsbAnular.Enabled = False
        'End If
    End Sub

    'Sub ListarTraslado(ByVal ciudad As Integer, ByVal estado As Integer, ByVal dgv As DataGridView, ByVal inicio As String, ByVal fin As String)
    Sub ListarTraslado(ByRef dgv As DataGridView)
        Dim strComprobante As String
        Try
            Cursor = Cursors.WaitCursor
            Dim intCiudad As Integer, intEstado As Integer
            Dim strInicio As String, strFin As String
            If Not pnlEstadoTraslados.Visible Then
                intCiudad = 0
                strInicio = "01/01/2018"
                strFin = Format(FechaServidor, "Short Date")
                intEstado = 1
                strComprobante = ""
            Else
                intCiudad = Me.cboCiudadTraslado.SelectedValue
                strInicio = Me.dtpInicioTraslado.Value.ToShortDateString
                strFin = Me.dtpFinTraslado.Value.ToShortDateString
                intEstado = Me.cboEstadoSolicitudTraslado.SelectedIndex()
                strComprobante = Me.txtComprobanteTrasladoBuscar.Text.Trim
            End If

            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable = obj.ListarTraslado(intCiudad, intEstado, strInicio, strFin,strComprobante)
            dgv.DataSource = dt

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvListaTraslado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListaTraslado.DoubleClick
        If Me.dgvListaTraslado.Rows.Count > 0 Then
            tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtGrtTraslado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAgregarTraslado_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnAceptarTrasladoAprobacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarTrasladoAprobacion.Click
        If Me.rbtNoTrasladoAprobacion.Checked Then
            If Me.txtObservacionTrasladoAprobacion.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Motivo", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtObservacionTrasladoAprobacion.Text = ""
                Me.txtObservacionTrasladoAprobacion.Focus()
                Return
            End If
        End If
        AprobarTraslado()
    End Sub

    Sub AprobarTraslado()
        Try
            If Me.rbtSiTrasladoAprobacion.Checked Then 'aprueba
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    AprobarSolicitudTraslado(2)
                    MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Me.ListarTraslado(dtoUSUARIOS.m_idciudad, Me.cboEstadoSolicitudTraslado.SelectedIndex, Me.dgvListaTraslado)
                    Me.ListarTraslado(Me.dgvListaTraslado)
                    tabTraslado.SelectedTab = tabTraslado.TabPages("tabListaTraslado")
                    Cursor = Cursors.Default
                End If
            ElseIf Me.rbtNoTrasladoAprobacion.Checked Then 'no aprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    AprobarSolicitudTraslado(3)
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Me.ListarTraslado(dtoUSUARIOS.m_idciudad, Me.cboEstadoSolicitudTraslado.SelectedIndex, Me.dgvListaTraslado)
                    Me.ListarTraslado(Me.dgvListaTraslado)
                    tabTraslado.SelectedTab = tabTraslado.TabPages("tabListaTraslado")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AprobarSolicitudTraslado(ByVal estado As Integer)
        Cursor = Cursors.WaitCursor
        Try
            Dim objLN As New Cls_Gasto_LN
            Dim intID As Integer = Me.dgvListaTraslado.CurrentRow.Cells("id").Value
            Dim dblPrecio As Double, strObservacion As String
            If estado = 2 Then
                strObservacion = ""
            ElseIf estado = 3 Then
                strObservacion = Me.txtObservacionTrasladoAprobacion.Text.Trim
            End If
            objLN.AprobarSolicitudTraslado(intID, strObservacion, estado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub InicioTraslado()
        LimpiarTraslado()
        FormateardgvListaTraslado()

        Dim obj As New Cls_Reparto_LN
        'Dim dt As DataTable = obj.ListarMovil(dtoUSUARIOS.m_idciudad, 0)

        Dim obj2 As New Cls_Gasto_LN
        With Me.cboCiudadTraslado
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj2.ListarCiudad(1)
            If intNivel = 1 Or intNivel = 4 Or intNivel = 5 Then
                .SelectedValue = dtoUSUARIOS.m_idciudad
                .Enabled = False
                Me.rbtSeguimientoTraslado.Visible = False
                Me.rbtPorAprobarTraslado.Visible = False
            Else
                .SelectedValue = 0
                .Enabled = True
                Me.rbtSeguimientoTraslado.Visible = True
                Me.rbtPorAprobarTraslado.Visible = True
                Me.rbtPorAprobarTraslado.Checked = True
            End If
        End With
        ConfigurarDGVTraslado(1)
        ConfigurarDGVTrasladoAprobacion(1)
    End Sub

    Sub GrabarSolicitudTraslado()
        If Val(Me.txtMontoTraslado.Text) = 0 Then
            MessageBox.Show("Ingrese Monto", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMontoTraslado.Focus()
            Return
        End If

        Dim blnRucValido As Boolean = fnValidarRUC(txtRucProveedorTraslado.Text)
        intLlamada = 1
        Me.txtRucProveedorTraslado_LostFocus(Nothing, Nothing)
        intLlamada = 0
        If Not blnRucValido Then
            MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRucProveedorTraslado.Focus()
            Return
        End If

        If Me.txtRazonSocialProveedorTraslado.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Razón Social", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRazonSocialProveedorTraslado.Text = ""
            txtRazonSocialProveedorTraslado.Focus()
            Return
        End If

        If ObtieneItemActivo(Me.dgvTraslado) = 0 Then
            MessageBox.Show("Ingrese la GRT", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtGrtTraslado.Focus()
            Return
        End If

        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN
            Dim dt As DataTable
            Dim intID As Integer, intID_2 As Integer
            Dim intTipo As Integer, intComprobante As Integer, intEstado As Integer, intMovil As Integer
            Dim intProveedor As Integer, strRuc As String, strRazonSocial As String

            intProveedor = IIf(IsNothing(Me.txtRucProveedorTraslado.Tag), 0, Val(Me.txtRucProveedorTraslado.Tag))
            strRuc = Me.txtRucProveedorTraslado.Text.Trim
            strRazonSocial = Me.txtRazonSocialProveedorTraslado.Text.Trim

            If intOperacion = Operacion.Nuevo Then
                intID = 0 : intID_2 = 0
            Else
                intID = Me.dgvListaTraslado.CurrentRow.Cells("id").Value
            End If
            For Each row As DataGridViewRow In Me.dgvTraslado.Rows
                intEstado = row.Cells("estado").Value
                dt = obj.GrabarSolicitudTraslado(intID, dtoUSUARIOS.m_idciudad, Me.dtpFechaOperacionTraslado.Value.ToShortDateString, _
                                               dtoUSUARIOS.m_iIdAgencia, intProveedor, strRuc, strRazonSocial, dtoUSUARIOS.IdLogin, _
                                               Me.txtObservacionTraslado.Text.Trim, CDbl(Me.txtMontoTraslado.Text), row.Cells("peso").Value, row.Cells("cantidad").Value, _
                                               row.Cells("id_grt").Value, intEstado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                intID = dt.Rows(0).Item(0)
            Next

            'Me.ListarTraslado(dtoUSUARIOS.m_idciudad, Me.cboEstadoSolicitudTraslado.SelectedIndex, Me.dgvListaTraslado)
            Me.ListarTraslado(Me.dgvListaTraslado)
            tabTraslado.SelectedIndex = 0
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpFechaOperacionTraslado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaOperacionTraslado.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboMovilTraslado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Sub AnularTraslado()
        Try
            Dim obj As New Cls_Gasto_LN
            obj.AnularSolicitudTraslado(Me.dgvListaTraslado.CurrentRow.Cells("id").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            'ListarTraslado(dtoUSUARIOS.m_idciudad, Me.cboEstadoSolicitudTraslado.SelectedValue, Me.dgvListaTraslado)
            ListarTraslado(Me.dgvListaTraslado)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpFechaFueraZona_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaFueraZona.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboProveedorFacturacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProveedorFacturacion.SelectedIndexChanged
        Me.dgvResultado.DataSource = Nothing
        CalcularTotal()
    End Sub

    Private Sub dgvTrasladoAprobacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvTrasladoAprobacion.DoubleClick
        If Me.dgvTrasladoAprobacion.Rows.Count > 0 Then
            Dim frm As New frmGRTDetalle
            frm.ID = Me.dgvTrasladoAprobacion.CurrentRow.Cells(0).Value
            frm.ShowDialog()
        End If
    End Sub

    Private Sub dgvEstibaAprobacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvEstibaAprobacion.DoubleClick
        If Me.dgvEstibaAprobacion.Rows.Count > 0 Then
            Dim frm As New frmGRTDetalle
            frm.ID = Me.dgvEstibaAprobacion.CurrentRow.Cells(0).Value
            frm.ShowDialog()
        End If
    End Sub

    Private Sub btnConsultarReparto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarReparto.Click
        Try
            Cursor = Cursors.WaitCursor
            ListarSolicitudReparto()
            If Me.dgvLista.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                If Me.dgvLista.CurrentRow.Cells("id_estado").Value = 1 Then
                    Me.tsbAnular.Enabled = True
                    Me.tsbEditar.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                    'Me.tsbEditar.Enabled = False
                End If
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboTipoAfectacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoAfectacion.SelectedIndexChanged
        Dim intTipoAfectacion As Integer = Me.cboTipoAfectacion.SelectedValue
        CargarPendientesFacturar(intTipoAfectacion)
    End Sub

    Private Sub btnConsultarFueraZona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarFueraZona.Click
        Try
            Cursor = Cursors.WaitCursor
            ListarSolicitud()
            If Me.dgvListaSolicitud.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                If Me.dgvListaSolicitud.CurrentRow.Cells("idestado").Value = 1 And (intNivel = 1 Or intNivel = 4) Then
                    Me.tsbAnular.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                End If
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConsultarEstiba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarEstiba.Click
        Try
            Cursor = Cursors.WaitCursor
            ListarEstiba(Me.dgvListaEstiba)
            If Me.dgvListaEstiba.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                If Me.dgvListaEstiba.CurrentRow.Cells("id_estado").Value = 1 Then
                    Me.tsbAnular.Enabled = IIf(tabEstiba.TabPages.IndexOf(tabSolicitudEstiba) > -1, True, False)
                    Me.tsbEditar.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                    'Me.tsbEditar.Enabled = False
                End If
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConsultarTraslado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarTraslado.Click
        Try
            Cursor = Cursors.WaitCursor
            'ListarTraslado(intCiudad, intEstado, Me.dgvListaTraslado, strInicio, strFin)
            ListarTraslado(Me.dgvListaTraslado)
            If Me.dgvListaTraslado.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                If Me.dgvListaTraslado.CurrentRow.Cells("id_estado").Value = 1 Then
                    Me.tsbAnular.Enabled = IIf(tabTraslado.TabPages.IndexOf(tabSolicitudTraslado) > -1, True, False)
                    Me.tsbEditar.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                    'Me.tsbEditar.Enabled = False
                End If
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtGrt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtGrt.CheckedChanged, rbtComprobante.CheckedChanged
        If Me.rbtGrt.Checked Then
            Me.ConfigurarDGVEstiba(1)
            Me.grbEstibaGrt.Visible = True
            Me.grbEstibaComprobante.Visible = False
            Me.dgvEstiba.Rows.Clear()
            Me.txtGrtEstiba.Focus()
        Else
            Me.ConfigurarDGVEstiba(2)
            Me.grbEstibaGrt.Visible = False
            Me.grbEstibaComprobante.Visible = True
            Me.cboTipoEstiba.SelectedIndex = 0
            Me.dgvEstiba.Rows.Clear()
            Me.txtComprobanteEstiba.Focus()
        End If
    End Sub

    Sub ControlaOpcionReparto() Handles rbtPorAprobarReparto.CheckedChanged, rbtSeguimientoReparto.CheckedChanged
        If Me.rbtSeguimientoReparto.Checked Then
            FormateardgvLista()
            cboEstadoSolicitudReparto_SelectedIndexChanged(Nothing, Nothing)
            pnlEstadoReparto.Visible = True
            If tabReparto.TabPages.IndexOf(tabSolicitudReparto) = -1 Then
                Me.tabReparto.TabPages.Add(tabSolicitudReparto)
            End If
            If tabReparto.TabPages.IndexOf(tabGenerarGasto) = -1 Then
                Me.tabReparto.TabPages.Add(tabGenerarGasto)
            End If
            If tabReparto.TabPages.IndexOf(tabAprobacionReparto) > -1 Then
                Me.tabReparto.TabPages.Remove(tabReparto.TabPages("tabAprobar"))
            End If
            If intNivel = 1 Or intNivel = 4 Then
                tsbNuevo.Enabled = True : tsbEditar.Enabled = Me.dgvLista.Rows.Count > 0 : tsbAnular.Enabled = Me.dgvLista.Rows.Count > 0
            Else
                tsbNuevo.Enabled = False : tsbEditar.Enabled = Me.dgvLista.Rows.Count > 0 : tsbAnular.Enabled = False
            End If
            ListarSolicitudReparto()
        Else
            tool.Items(0).Enabled = False : tool.Items(2).Enabled = False : tool.Items(3).Enabled = False
            ListarSolicitudReparto()
            Me.cboEstadoSolicitudReparto.SelectedIndex = 1
            Me.pnlEstadoReparto.Visible = False

            If tabReparto.TabPages.IndexOf(tabSolicitudReparto) > -1 Then
                Me.tabReparto.TabPages.Remove(tabReparto.TabPages("tabSolicitar"))
            End If
            If tabReparto.TabPages.IndexOf(tabGenerarGasto) > -1 Then
                Me.tabReparto.TabPages.Remove(tabReparto.TabPages("tabGenerarGasto"))
            End If
            If tabReparto.TabPages.IndexOf(tabAprobacionReparto) = -1 Then
                Me.tabReparto.TabPages.Add(tabAprobacionReparto)
            End If
        End If
    End Sub

    Private Sub rbtSeguimientoEstiba_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSeguimientoEstiba.CheckedChanged, rbtPorAprobarEstiba.CheckedChanged
        If Me.rbtSeguimientoEstiba.Checked Then
            Me.pnlEstadoEstibas.Visible = True
        Else
            Me.pnlEstadoEstibas.Visible = False
        End If
        Me.dgvListaEstiba.DataSource = Nothing
        Me.btnConsultarEstiba_Click(Nothing, Nothing)
    End Sub

    Private Sub rbtSeguimientoTraslado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSeguimientoTraslado.CheckedChanged, rbtPorAprobarTraslado.CheckedChanged
        If Me.rbtSeguimientoTraslado.Checked Then
            Me.pnlEstadoTraslados.Visible = True
        Else
            Me.pnlEstadoTraslados.Visible = False
        End If
        Me.btnConsultarTraslado_Click(Nothing, Nothing)
    End Sub

    Private Sub txtComprobanteEstiba_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComprobanteEstiba.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAgregarEstiba_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub rbtGrtTraslado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtGrtTraslado.CheckedChanged, rbtComprobanteTraslado.CheckedChanged
        If Me.rbtGrtTraslado.Checked Then
            Me.ConfigurarDGVTraslado(1)
            Me.grbTrasladoGrt.Visible = True
            Me.grbTrasladoComprobante.Visible = False
            Me.dgvTraslado.Rows.Clear()
            Me.txtGrtTraslado.Focus()
        Else
            Me.ConfigurarDGVTraslado(2)
            Me.grbTrasladoGrt.Visible = False
            Me.grbTrasladoComprobante.Visible = True
            Me.cboTipoTraslado.SelectedIndex = 0
            Me.dgvTraslado.Rows.Clear()
            Me.txtComprobanteTraslado.Focus()
        End If
    End Sub

    Private Sub txtComprobanteTraslado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComprobanteTraslado.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAgregarTraslado_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub rbtGrtRecojo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtGrtRecojo.CheckedChanged, rbtComprobanteRecojo.CheckedChanged
        If Me.rbtGrtRecojo.Checked Then
            Me.ConfigurarDGVRecojo(1)
            Me.grbRecojoGrt.Visible = True
            Me.grbRecojoComprobante.Visible = False
            Me.dgvRecojo.Rows.Clear()
            Me.txtComprobanteRecojo.Text = ""
            Me.txtGrtRecojo.Focus()
        Else
            Me.ConfigurarDGVRecojo(2)
            Me.grbRecojoGrt.Visible = False
            Me.grbRecojoComprobante.Visible = True
            Me.cboTipoRecojo.SelectedIndex = 0
            Me.dgvRecojo.Rows.Clear()
            Me.txtGrtRecojo.Text = ""
            Me.txtComprobanteRecojo.Focus()
        End If
        TotalRepartoRecojo()
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        If Me.dgvRecojo.Rows.Count > 0 Then
            QuitarRecojo()
        End If
    End Sub

    Sub AgregarRecojo(ByVal dt As DataTable, ByVal dgv As DataGridView, ByVal formato As Integer, Optional ByVal fila As Integer = 0, Optional ByVal opcion As Integer = 0)
        With dgv
            .Rows.Add()
            If formato = 0 Then
                dgv(0, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_grt")
                dgv(1, .Rows.Count - 1).Value = dt.Rows(fila).Item("bus")

                dgv(2, .Rows.Count - 1).Value = dt.Rows(fila).Item("grt")
                dgv(3, .Rows.Count - 1).Value = dt.Rows(fila).Item("origen")
                dgv(4, .Rows.Count - 1).Value = dt.Rows(fila).Item("destino")
                dgv(5, .Rows.Count - 1).Value = dt.Rows(fila).Item("peso")
                dgv(6, .Rows.Count - 1).Value = dt.Rows(fila).Item("cantidad")
                If opcion = 0 Then
                    dgv(7, .Rows.Count - 1).Value = 0
                Else
                    dgv(7, .Rows.Count - 1).Value = dt.Rows(fila).Item("estado")
                End If
            Else
                If opcion = 0 Then
                    dgv(0, .Rows.Count - 1).Value = 0 'id cabecera
                    dgv(1, .Rows.Count - 1).Value = 0 'id detalle
                    dgv(10, .Rows.Count - 1).Value = 0 'nuevo
                Else
                    dgv(0, .Rows.Count - 1).Value = dt.Rows(fila).Item("id") 'id cabecera
                    dgv(1, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_2") 'id detalle
                    dgv(10, .Rows.Count - 1).Value = dt.Rows(fila).Item("estado") 'nuevo
                End If
                dgv(2, .Rows.Count - 1).Value = CDate(dt.Rows(fila).Item("fecha"))
                dgv(3, .Rows.Count - 1).Value = dt.Rows(fila).Item("tipo")
                dgv(4, .Rows.Count - 1).Value = dt.Rows(fila).Item("comprobante")
                dgv(5, .Rows.Count - 1).Value = dt.Rows(fila).Item("origen")
                dgv(6, .Rows.Count - 1).Value = dt.Rows(fila).Item("destino")
                dgv(7, .Rows.Count - 1).Value = dt.Rows(fila).Item("cliente")
                dgv(8, .Rows.Count - 1).Value = dt.Rows(fila).Item("peso")
                dgv(9, .Rows.Count - 1).Value = dt.Rows(fila).Item("cantidad")
                dgv(11, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_comprobante")
                dgv(12, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_tipo")
                dgv(13, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_origen")
                dgv(14, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_destino")
                dgv(15, .Rows.Count - 1).Value = dt.Rows(fila).Item("id_persona")
                dgv(16, .Rows.Count - 1).Value = dt.Rows(fila).Item("producto")
            End If
        End With
    End Sub
    Private Sub btnAgregarRecojo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarRecojo.Click
        Try
            If Me.rbtGrtRecojo.Checked Then
                If Me.txtGrtRecojo.Text.Trim.Length = 0 Then Return
            Else
                If Me.txtComprobanteRecojo.Text.Trim.Length = 0 Then Return
            End If

            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN

            If Me.rbtGrtRecojo.Checked Then
                Dim strNroDoc As String() = Split(txtGrtRecojo.Text, "-")
                Dim intSerie As Integer, intNumero As Integer

                If strNroDoc.Length > 1 Then
                    If Val(strNroDoc(0)) > 0 And Val(strNroDoc(1)) > 0 Then
                        intSerie = strNroDoc(0)
                        intNumero = strNroDoc(1)
                    Else
                        If Val(strNroDoc(1)) > 0 Then
                            intNumero = strNroDoc(1)
                        End If
                    End If
                ElseIf strNroDoc.Length = 1 Then
                    If Val(strNroDoc(0)) > 0 Then
                        intNumero = strNroDoc(0)
                    End If
                End If

                If intSerie = 0 And intNumero = 0 Then
                    Cursor = Cursors.Default
                    Return
                End If

                Dim dt As DataTable = obj.ListarGrtRecojo(intSerie, intNumero, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, 1)
                If dt.Rows.Count > 0 Then
                    If Not ExisteValorGrid(Me.dgvRecojo, Me.dgvRecojo.Columns("id_grt").Index, dt.Rows(0).Item("id_grt")) Then
                        AgregarRecojo(dt, dgvRecojo, 0)
                        Me.txtGrtRecojo.Focus()
                        Me.txtGrtRecojo.SelectAll()
                    Else
                        Cursor = Cursors.Default
                        MessageBox.Show("El Nº de GRT ya existe en la Lista", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtGrtRecojo.Focus()
                        Me.txtGrtRecojo.SelectAll()
                    End If
                Else
                    Cursor = Cursors.Default
                    MessageBox.Show("El Nº de GRT no se encuentra Disponible", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtGrtTraslado.Focus()
                    Me.txtGrtTraslado.SelectAll()
                End If
            Else
                Dim strNroDoc As String() = Split(txtComprobanteRecojo.Text, "-")
                If strNroDoc.Length > 1 Then
                    If strNroDoc(0).Trim.Length > 1 And Val(strNroDoc(1)) > 0 Then
                        ObjEntrega_Recojo.v_serie = strNroDoc(0)
                        ObjEntrega_Recojo.v_nroDoc = strNroDoc(1)
                    Else
                        ObjEntrega_Recojo.v_serie = "0"
                        ObjEntrega_Recojo.v_nroDoc = "0"
                    End If
                Else
                    If strNroDoc.Length = 1 Then
                        ObjEntrega_Recojo.v_serie = "-1"
                        ObjEntrega_Recojo.v_nroDoc = strNroDoc(0)
                    Else
                        ObjEntrega_Recojo.v_serie = "0"
                        ObjEntrega_Recojo.v_nroDoc = "0"
                    End If
                End If

                Dim dt As DataTable = obj.ListarDisponible(ObjEntrega_Recojo.v_serie, ObjEntrega_Recojo.v_nroDoc, Me.cboTipoRecojo.SelectedIndex)
                If dt.Rows.Count > 0 Then
                    If Not ExisteValorGrid(Me.dgvRecojo, Me.dgvRecojo.Columns("id_comprobante").Index, dt.Rows(0).Item("id_comprobante")) Then
                        Agregar(dt, dgvRecojo, 1)
                        Me.txtComprobanteRecojo.Focus()
                        Me.txtComprobanteRecojo.SelectAll()
                    Else
                        Cursor = Cursors.Default
                        MessageBox.Show("El Comprobante ya existe en la Lista", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtComprobanteRecojo.Focus()
                        Me.txtComprobanteRecojo.SelectAll()
                    End If
                Else
                    Cursor = Cursors.Default
                    MessageBox.Show("El Comprobante no se encuentra Disponible", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtComprobanteRecojo.Focus()
                    Me.txtComprobanteRecojo.SelectAll()
                End If
            End If
            TotalizarRecojo()
            TotalRepartoRecojo()
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Reparto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtComprobanteRecojo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAgregarRecojo_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtGrtRecojo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrtRecojo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAgregarRecojo_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub chkReparto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReparto.CheckedChanged
        'Me.grbZonaReparto.Enabled = Me.chkReparto.Checked
        Me.grbPagoAdicional.Enabled = Me.chkReparto.Checked
        btnQuitarReparto.Enabled = False

        If Me.chkReparto.Checked Then
            Me.btnConsultarListaReparto_Click(Nothing, Nothing)
            TotalRepartoRecojo()
        Else
            Me.chkTipoPagoAdicional.Checked = False
            'Me.dgvReparto.DataSource = Nothing
            Me.dgvReparto.Rows.Clear()
            Distribuir()
            TotalRepartoRecojo()
        End If
    End Sub

    Private Sub chkRecojo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecojo.CheckedChanged
        Me.grbZonaRecojo.Enabled = Me.chkRecojo.Checked
        Me.cboTipoRecojo.SelectedIndex = 0
        Me.txtGrtRecojo.Text = ""
        Me.txtComprobanteRecojo.Text = ""
        If Me.chkRecojo.Checked Then
            Me.rbtComprobanteRecojo.Checked = True
            Me.txtComprobanteRecojo.Focus()
        Else
            Me.dgvRecojo.Rows.Clear()
            TotalRepartoRecojo()
        End If
        Distribuir()
    End Sub

    Private Sub btnConsultarListaReparto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarListaReparto.Click
        Dim obj As New Cls_Gasto_LN
        lblTarifaCiudad.Text = Format(obj.ObtieneTarifaGasto(dtoUSUARIOS.m_idciudad, ObtieneTipoPago), "0.00")
        If intOperacion = Operacion.Nuevo Then
            ListarReparto()
        End If
        Distribuir()
        ActualizarReparto()

        'If Me.chkTipoPagoAdicional.Checked And intIngresa = 11 Then
        '    ListarResponsable()
        '    ListarHoraSalida()
        'End If
        'intIngresa = 1
        TotalRepartoRecojo()
    End Sub

    Sub TotalRepartoRecojo()
        Dim dt As DataTable
        Dim dblMonto As Double, dblPeso1 As Double = 0, dblPeso2 As Double, intCantidad As Integer = 0
        If Val(Me.lblMontoCiudad.Text) = 0 Then
            dblMonto = 0
        Else
            dblMonto = Me.lblMontoCiudad.Text
        End If
        If Me.chkReparto.Checked Then
            If Me.dgvReparto.Rows.Count > 0 Then
                With Me.dgvReparto
                    For Each row As DataGridViewRow In .Rows
                        'If row.Cells("estado").Value < 2 Then
                        dblPeso1 += row.Cells("peso").Value
                        intCantidad += row.Cells("cantidad").Value
                        'End If
                    Next
                End With
            End If
        End If
        Me.lblPesoReparto.Text = Format(dblPeso1, "###,###,###0.00")
        Me.lblCantidadReparto.Text = intCantidad

        intCantidad = 0
        If Me.chkRecojo.Checked Then
            If Me.dgvRecojo.Rows.Count > 0 Then
                With Me.dgvRecojo
                    For Each row As DataGridViewRow In .Rows
                        If row.Cells("estado").Value < 2 Then
                            dblPeso2 += row.Cells("peso").Value
                            intCantidad += row.Cells("cantidad").Value
                        End If
                    Next
                End With
            End If
        End If
        Me.lblPesoRecojo.Text = Format(dblPeso2, "###,###,###0.00")
        Me.lblCantidadRecojo.Text = intCantidad

        Dim dblTotal As Double = dblPeso1 + dblPeso2
        If dblTotal > 0 Then
            Dim dblMonto1 As Double, dblMonto2 As Double
            dblMonto1 = dblPeso1 / dblTotal * 100
            dblMonto2 = dblPeso2 / dblTotal * 100
            dblMonto1 = dblMonto * dblMonto1 / 100
            dblMonto2 = dblMonto * dblMonto2 / 100
            Me.lblMontoReparto.Text = Format(dblMonto1, "0.00")
            Me.lblMontoRecojo.Text = Format(dblMonto2, "0.00")
        Else
            Me.lblMontoReparto.Text = "0.00"
            Me.lblMontoRecojo.Text = "0.00"
        End If
        ActualizarReparto()
    End Sub

    Private Function dgvListaRecojo() As Object
        Throw New NotImplementedException
    End Function

    Private Sub txtGrtTraslado_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrtTraslado.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAgregarTraslado_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtObservacionAprobacionGasto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacionAprobacionGasto.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnAgregarReparto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarReparto.Click
        Me.btnConsultarListaReparto_Click(Nothing, Nothing)
        If Me.chkTipoPagoAdicional.Checked Then
            Me.btnQuitarReparto.Enabled = Me.dgvReparto.Rows.Count > 0
        Else
            Me.btnQuitarReparto.Enabled = False
        End If
    End Sub

    Private Sub btnQuitarReparto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarReparto.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de anular el reparto seleccionado?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            With Me.dgvReparto
                .Rows.RemoveAt(.CurrentCell.RowIndex)
                ActualizarReparto()
                TotalRepartoRecojo()
            End With
        End If
    End Sub

    Private Sub dgvRepartoGasto_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRepartoGasto.CellContentClick

    End Sub

    Private Sub dgvReparto_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReparto.CellContentClick

    End Sub

    Private Sub dgvReparto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvReparto.DoubleClick
        If Me.dgvLista.Rows.Count = 0 Then Return
        If Me.dgvLista.CurrentRow.Cells("id_operacion").Value = 1 Or Me.dgvLista.CurrentRow.Cells("id_operacion").Value = 3 Then
            With Me.dgvReparto
                If .Rows.Count > 0 Then
                    Dim frm As New frmHojaRuta
                    frm.Ciudad = dgvLista.CurrentRow.Cells("id_ciudad").Value
                    frm.NombreCiudad = dgvLista.CurrentRow.Cells("ciudad").Value
                    frm.Fecha = dgvLista.CurrentRow.Cells("fecha_operacion").Value 'Me.lblFechaGasto.Text
                    frm.NombreResponsable = .CurrentRow.Cells("responsable").Value
                    frm.Responsable = .CurrentRow.Cells("id_responsable").Value
                    frm.Reparto = IIf(IsDBNull(.CurrentRow.Cells("id_reparto").Value), 0, .CurrentRow.Cells("id_reparto").Value)
                    frm.HoraSalida = IIf(IsDBNull(.CurrentRow.Cells("id_reparto").Value), "", .CurrentRow.Cells("hora_salida").Value)
                    frm.ShowDialog()
                End If
            End With
        End If
    End Sub

    '-----------------------------------------------EMBALAJE----------------------------------------------------------------
    Private Sub ConfigurarDGVGuiaEnvioEmbalaje()
        With dgvGuiaEnvioEmbalaje
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idtipo As New DataGridViewTextBoxColumn
            With col_idtipo
                .Name = "idtipo" : .DataPropertyName = "idtipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo"
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_origen As New DataGridViewTextBoxColumn
            With col_agencia_origen
                .Name = "agencia_origen" : .DataPropertyName = "agencia_origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_destino As New DataGridViewTextBoxColumn
            With col_agencia_destino
                .Name = "agencia_destino" : .DataPropertyName = "agencia_destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dirección"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            x += +1
            Dim col_idcomprobante As New DataGridViewTextBoxColumn
            With col_idcomprobante
                .Name = "idcomprobante" : .DataPropertyName = "idcomprobante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcomprobante"
            End With
            x += +1
            Dim col_idagencias As New DataGridViewTextBoxColumn
            With col_idagencias
                .Name = "idagencia_origen" : .DataPropertyName = "idagencia_origen"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_origen"
            End With
            x += +1
            Dim col_idagencias_destino As New DataGridViewTextBoxColumn
            With col_idagencias_destino
                .Name = "idagencia_destino" : .DataPropertyName = "idagencia_destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_destino"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_fecha, col_idtipo, col_tipo, col_comprobante, col_origen, col_destino, col_agencia_origen, col_agencia_destino, col_total, _
                              col_cantidad, col_peso, col_direccion, _
                              col_idcomprobante, col_idagencias, col_idagencias_destino, col_estado)
        End With
    End Sub

    Private Sub ConfigurarDGVListaSolicitudEmbalaje()
        With dgvListaSolicitudEmbalaje
            Cls_Utilitarios.FormatDataGridView(dgvListaSolicitudEmbalaje)
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_solicitud As New DataGridViewTextBoxColumn
            With col_solicitud
                .Name = "numero_solicitud" : .DataPropertyName = "numero_solicitud"
                .DisplayIndex = x : .HeaderText = "Nº Solicitud"
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
            End With
            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_costo As New DataGridViewTextBoxColumn
            With col_costo
                .Name = "costo" : .DataPropertyName = "costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Costo" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio Aceptado" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_precio_observacion As New DataGridViewTextBoxColumn
            With col_precio_observacion
                .Name = "precio_observacion" : .DataPropertyName = "precio_observacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio Observado" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_precio_aprobacion As New DataGridViewTextBoxColumn
            With col_precio_aprobacion
                .Name = "precio" : .DataPropertyName = "precio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio Aprobado" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_aceptacion As New DataGridViewTextBoxColumn
            With col_aceptacion
                .Name = "fecha_aceptacion" : .DataPropertyName = "fecha_aceptacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aceptación"
            End With
            x += +1
            Dim col_observado As New DataGridViewTextBoxColumn
            With col_observado
                .Name = "fecha_observacion" : .DataPropertyName = "fecha_observacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Observación"
            End With
            x += +1
            Dim col_aprobacion As New DataGridViewTextBoxColumn
            With col_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación"
            End With
            x += +1
            Dim col_noaceptacion As New DataGridViewTextBoxColumn
            With col_noaceptacion
                .Name = "fecha_noaceptacion" : .DataPropertyName = "fecha_noaceptacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha no Aceptación"
            End With
            x += +1
            Dim col_desaprobacion As New DataGridViewTextBoxColumn
            With col_desaprobacion
                .Name = "fecha_desaprobacion" : .DataPropertyName = "fecha_desaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Desaprobación"
            End With
            x += +1
            Dim col_anulacion As New DataGridViewTextBoxColumn
            With col_anulacion
                .Name = "fecha_anulacion" : .DataPropertyName = "fecha_anulacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Anulación"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id"
            End With
            x += +1
            Dim col_observacion_observacion As New DataGridViewTextBoxColumn
            With col_observacion_observacion
                .Name = "observacion_observacion" : .DataPropertyName = "observacion_observacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Observación"
            End With
            x += +1
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcliente"
            End With
            x += +1
            Dim col_oficina As New DataGridViewTextBoxColumn
            With col_oficina
                .Name = "oficina" : .DataPropertyName = "oficina"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Oficina" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "solicitante"
            End With
            x += +1
            Dim col_contacto As New DataGridViewTextBoxColumn
            With col_contacto
                .Name = "contacto" : .DataPropertyName = "contacto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "contacto"
            End With
            x += +1
            Dim col_funcionario As New DataGridViewTextBoxColumn
            With col_funcionario
                .Name = "funcionario" : .DataPropertyName = "funcionario"
                .DisplayIndex = x : .Visible = False : .HeaderText = "funcionario"
            End With
            x += +1
            Dim col_localidad As New DataGridViewTextBoxColumn
            With col_localidad
                .Name = "localidad" : .DataPropertyName = "localidad"
                .DisplayIndex = x : .Visible = False : .HeaderText = "localidad"
            End With
            x += +1
            Dim col_km As New DataGridViewTextBoxColumn
            With col_km
                .Name = "km" : .DataPropertyName = "km"
                .DisplayIndex = x : .Visible = False : .HeaderText = "km"
            End With
            x += +1
            Dim col_hora As New DataGridViewTextBoxColumn
            With col_hora
                .Name = "hora" : .DataPropertyName = "hora"
                .DisplayIndex = x : .Visible = False : .HeaderText = "hora"
            End With
            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id estado"
            End With
            x += +1
            Dim col_id_proveedor As New DataGridViewTextBoxColumn
            With col_id_proveedor
                .Name = "id_proveedor" : .DataPropertyName = "id_proveedor" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_ruc As New DataGridViewTextBoxColumn
            With col_ruc
                .Name = "ruc" : .DataPropertyName = "ruc" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_proveedor As New DataGridViewTextBoxColumn
            With col_proveedor
                .Name = "proveedor" : .DataPropertyName = "proveedor" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Observación" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_observacion2 As New DataGridViewTextBoxColumn
            With col_observacion2
                .Name = "observacion2" : .DataPropertyName = "observacion2"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Observación por Desaprobación" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_solicitud, col_fecha, col_codigo, col_cliente, col_costo, col_total, col_precio_observacion, col_precio_aprobacion, col_estado, _
                              col_aceptacion, col_observado, col_aprobacion, col_noaceptacion, col_desaprobacion, col_anulacion, _
                              col_observacion, col_observacion_observacion, col_id, col_idcliente, col_oficina, col_solicitante, col_contacto, _
                              col_funcionario, col_localidad, col_km, col_hora, col_idestado, col_id_proveedor, col_ruc, col_proveedor, col_observacion2)
        End With
    End Sub

    Sub ActualizaComboEmbalaje(Optional ByVal opcion As Integer = 1)
        Me.cboestadoSolicitudEmbalaje.Items.Clear()
        If opcion = 1 Then
            Me.cboestadoSolicitudEmbalaje.Items.Add("(TODOS)")
            Me.cboestadoSolicitudEmbalaje.Items.Add("PENDIENTE")
            Me.cboestadoSolicitudEmbalaje.Items.Add("ACEPTADO")
            Me.cboestadoSolicitudEmbalaje.Items.Add("OBSERVADO")
            Me.cboestadoSolicitudEmbalaje.Items.Add("APROBADO")
            Me.cboestadoSolicitudEmbalaje.Items.Add("NO ACEPTADO")
            Me.cboestadoSolicitudEmbalaje.Items.Add("DESAPROBADO")
            Me.cboestadoSolicitudEmbalaje.Items.Add("ANULADO")
        Else
            Me.cboestadoSolicitudEmbalaje.Items.Add("(TODOS)")
            Me.cboestadoSolicitudEmbalaje.Items.Add("PENDIENTE")
            Me.cboestadoSolicitudEmbalaje.Items.Add("OBSERVADO")
        End If
    End Sub

    Sub InicioEmbalaje()
        Dim obj As New dtoFueraZona
        Dim dt As DataTable = obj.ListarCliente

        Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        ObjProcesos.fnCargar_iWin_r(Me.txtClienteEmbalaje, dt.DefaultView, colCliente, autoCliente, 0)

        ConfigurarDGVGuiaEnvioEmbalaje()
        ConfigurarDGVListaSolicitudEmbalaje()

        Dim obj2 As New Cls_Gasto_LN
        With Me.cboCiudadEmbalaje
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj2.ListarCiudad(1)
            '.SelectedValue = 0
        End With

        If intNivel = 1 Or intNivel = 4 Then
            ActualizaComboEmbalaje()
            Me.cboestadoSolicitudEmbalaje.SelectedIndex = 1
            Me.cboCiudadEmbalaje.SelectedValue = dtoUSUARIOS.m_idciudad
            Me.cboCiudadEmbalaje.Enabled = False
        ElseIf intNivel = 2 Then
            ActualizaComboEmbalaje(2)
            Me.cboestadoSolicitudEmbalaje.SelectedIndex = 0
            Me.cboCiudadEmbalaje.SelectedValue = 0
            Me.cboCiudadEmbalaje.Enabled = True
        ElseIf intNivel = 3 Then
            ActualizaComboEmbalaje()
            Me.cboestadoSolicitudEmbalaje.SelectedIndex = 1
            Me.cboCiudadEmbalaje.SelectedValue = 0
            Me.cboCiudadEmbalaje.Enabled = True
        Else
            ActualizaComboEmbalaje()
            Me.cboestadoSolicitudEmbalaje.SelectedIndex = 1
            Me.cboCiudadEmbalaje.SelectedValue = 0
            Me.cboCiudadEmbalaje.Enabled = False
        End If
    End Sub

    Sub LimpiarSolicitudEmbalaje()
        Me.lblNumeroSolicitudEmbalaje.Text = ""
        Me.dtpFechaEmbalaje.Value = Format(FechaServidor, "Short Date")
        Me.lblOficinaEmbalaje.Text = dtoUSUARIOS.m_iNombreAgencia
        Me.lblSolicitanteEmbalaje.Text = ""
        Me.txtCodigoClienteEmbalaje.Text = ""
        Me.txtClienteEmbalaje.Text = ""
        Me.txtCostoEmbalaje.Text = ""
        'Me.txtKilometro.Text = ""
        'Me.txtHora.Text = ""
        'Me.txtLocalidad.Text = ""
        Me.txtObservacionEmbalaje.Text = ""
        Me.txtRucProveedorEmbalaje.Text = ""
        Me.txtRazonSocialProveedorEmbalaje.Text = ""
        Me.dgvGuiaEnvioEmbalaje.Rows.Clear()
    End Sub

    Private Sub ConfigurarDGVGuiaEnvioAceptacionEmbalaje()
        With dgvGuiaEnvioAceptacionEmbalaje
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idtipo As New DataGridViewTextBoxColumn
            With col_idtipo
                .Name = "idtipo" : .DataPropertyName = "idtipo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo"
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_guia As New DataGridViewTextBoxColumn
            With col_guia
                .Name = "guia" : .DataPropertyName = "guia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_origen As New DataGridViewTextBoxColumn
            With col_agencia_origen
                .Name = "agencia_origen" : .DataPropertyName = "agencia_origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_destino As New DataGridViewTextBoxColumn
            With col_agencia_destino
                .Name = "agencia_destino" : .DataPropertyName = "agencia_destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dirección"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idguia As New DataGridViewTextBoxColumn
            With col_idguia
                .Name = "idguia" : .DataPropertyName = "idguia"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idguia"
            End With
            x += +1
            Dim col_idagencias As New DataGridViewTextBoxColumn
            With col_idagencias
                .Name = "idagencia_origen" : .DataPropertyName = "idagencia_origen"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_origen"
            End With
            x += +1
            Dim col_idagencias_destino As New DataGridViewTextBoxColumn
            With col_idagencias_destino
                .Name = "idagencia_destino" : .DataPropertyName = "idagencia_destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_destino"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_fecha, col_idtipo, col_tipo, col_guia, col_origen, col_destino, col_agencia_origen, col_agencia_destino, col_total, _
                              col_cantidad, col_peso, col_direccion, _
                              col_idguia, col_idagencias, col_idagencias_destino, col_estado)
        End With
    End Sub

    Private Sub ConfigurarDGVGuiaEnvioAprobacionEmbalaje()
        With dgvGuiaEnvioAprobacionEmbalaje
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idtipo As New DataGridViewTextBoxColumn
            With col_idtipo
                .Name = "idtipo" : .DataPropertyName = "idtipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo"
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_guia As New DataGridViewTextBoxColumn
            With col_guia
                .Name = "guia" : .DataPropertyName = "guia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_origen As New DataGridViewTextBoxColumn
            With col_agencia_origen
                .Name = "agencia_origen" : .DataPropertyName = "agencia_origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_destino As New DataGridViewTextBoxColumn
            With col_agencia_destino
                .Name = "agencia_destino" : .DataPropertyName = "agencia_destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dirección"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idguia As New DataGridViewTextBoxColumn
            With col_idguia
                .Name = "idguia" : .DataPropertyName = "idguia"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idguia"
            End With
            x += +1
            Dim col_idagencias As New DataGridViewTextBoxColumn
            With col_idagencias
                .Name = "idagencia_origen" : .DataPropertyName = "idagencia_origen"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_origen"
            End With
            x += +1
            Dim col_idagencias_destino As New DataGridViewTextBoxColumn
            With col_idagencias_destino
                .Name = "idagencia_destino" : .DataPropertyName = "idagencia_destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_destino"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_fecha, col_idtipo, col_tipo, col_guia, col_origen, col_destino, col_agencia_origen, col_agencia_destino, col_total, _
                              col_cantidad, col_peso, col_direccion, _
                              col_idguia, col_idagencias, col_idagencias_destino, col_estado)
        End With
    End Sub

    Sub LimpiarAprobacionEmbalaje()
        Me.lblCodigoAprobacionEmbalaje.Text = ""
        Me.lblRazonSocialAprobacionEmbalaje.Text = ""
        Me.lbloficinaAprobacionEmbalaje.Text = ""
        Me.lblSolicitanteAprobacionEmbalaje.Text = ""
        Me.dgvGuiaEnvioAprobacionEmbalaje.Rows.Clear()
        'Me.lblLocalidadAprobacion.Text = ""
        'Me.lblKmAprobacion.Text = ""
        'Me.lblHoraAprobacion.Text = ""
        Me.lblCostoAprobacionEmbalaje.Text = ""
        Me.txtPrecioAprobacionEmbalaje.Text = ""
        'Me.lblContactoAprobacion.Text = ""
        Me.lblFuncionarioAprobacionEmbalaje.Text = ""
        Me.lblPrecioAceptadoAprobacionEmbalaje.Text = ""
        Me.rbtSiAprobacionEmbalaje.Checked = True
        Me.txtObservacionAprobacionEmbalaje.Text = ""
        Me.lblPesoAprobacionEmbalaje.Text = ""
        Me.lblMontoAprobacionEmbalaje.Text = ""
    End Sub

    Private Sub tabEmbalaje_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabEmbalaje.SelectedIndexChanged
        Me.tsbImprimir.Enabled = False
        If tabEmbalaje.SelectedTab Is tabEmbalaje.TabPages("tablistaEmbalaje") Then
            If intNivel = 1 Or intNivel = 4 Then
                Me.tsbNuevo.Enabled = True
            Else
                Me.tsbNuevo.Enabled = False
            End If
            Me.tsbGrabar.Enabled = False
            If Me.dgvListaSolicitudEmbalaje.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                If Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("idestado").Value = 1 And (intNivel = 1 Or intNivel = 4) Then
                    Me.tsbAnular.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                End If
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
            ConfigurarDGVGuiaEnvioEmbalaje()

        ElseIf tabEmbalaje.SelectedTab Is tabEmbalaje.TabPages("tabSolicitudEmbalaje") Then
            LimpiarSolicitudEmbalaje()
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            If Me.dgvListaSolicitudEmbalaje.Rows.Count > 0 Then
                tsbEditar_Click(Nothing, Nothing)
            Else
                tsbNuevo_Click(Nothing, Nothing)
                'Me.tsbGrabar.Enabled = False
            End If
        ElseIf tabEmbalaje.SelectedTab Is tabEmbalaje.TabPages("tabaceptacionembalaje") Then
            LimpiarAceptacionEmbalaje()
            Me.tsbGrabar.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            ConfigurarDGVGuiaEnvioAceptacionEmbalaje()
            If Me.dgvListaSolicitudEmbalaje.Rows.Count > 0 Then
                Dim intEstado As Integer = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("idestado").Value
                If intEstado = 1 Then
                    Me.txtPrecioAceptacionEmbalaje.Enabled = True
                Else
                    Me.txtPrecioAceptacionEmbalaje.Enabled = False
                End If
                'Me.cboContactoAceptacion.Enabled = True
                Me.rbtSiAceptacionEmbalaje.Enabled = True
                Me.rbtNoAceptacionEmbalaje.Enabled = True
                Me.txtObservacionAceptacionEmbalaje.Enabled = True
                Me.btnAceptarAceptacionEmbalaje.Enabled = True
                Me.grbGuiaEnvioAceptacionEmbalaje.Enabled = True

                Dim intCliente As Integer = dgvListaSolicitudEmbalaje.CurrentRow.Cells("idcliente").Value
                'LlenarCombo(intCliente)

                Me.lblCodigoAceptacionEmbalaje.Text = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("codigo").Value
                Me.lblRazonSocialAceptacionEmbalaje.Text = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("cliente").Value
                Me.lblOficinaAceptacionEmbalaje.Text = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("oficina").Value
                Me.lblSolicitanteAceptacionEmbalaje.Text = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("solicitante").Value

                'Me.lblLocalidadAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("localidad").Value
                'Me.lblKmAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("km").Value
                'Me.lblHoraAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("hora").Value

                If IsDBNull(Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("observacion_observacion").Value) Then
                    Me.lblObservacionAceptacionEmbalaje.Text = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("observacion").Value
                Else
                    Me.lblObservacionAceptacionEmbalaje.Text = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("observacion_observacion").Value
                End If

                Me.lblCostoAceptacionEmbalaje.Text = Format(CDbl(Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("costo").Value), "###,###,###0.00")

                If intEstado = 1 Then
                    Me.txtPrecioAceptacionEmbalaje.Text = Format(CDbl(Me.lblCostoAceptacionEmbalaje.Text) * 2, "###,###,###0.00")
                Else
                    Me.txtPrecioAceptacionEmbalaje.Text = Format(Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("precio_observacion").Value, "###,###,###0.00")
                End If

                Dim intID As Integer = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("id").Value
                ListarGuiaEnvioEmbalaje(intID, Me.dgvGuiaEnvioAceptacionEmbalaje)

                'Me.cboContactoAceptacion.Focus()
                Me.txtPrecioAceptacionEmbalaje.Focus()
            Else
                Me.txtPrecioAceptacionEmbalaje.Enabled = False
                'Me.cboContactoAceptacion.Enabled = False
                Me.rbtSiAceptacionEmbalaje.Enabled = False
                Me.rbtNoAceptacionEmbalaje.Enabled = False
                Me.txtObservacionAceptacionEmbalaje.Enabled = False
                Me.btnAceptarAceptacionEmbalaje.Enabled = False
                Me.grbGuiaEnvioAceptacionEmbalaje.Enabled = False
            End If

        ElseIf tabEmbalaje.SelectedTab Is tabEmbalaje.TabPages("tabaprobacionembalaje") Then
            LimpiarAprobacionEmbalaje()
            Me.tsbGrabar.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            ConfigurarDGVGuiaEnvioAprobacionEmbalaje()
            If Me.dgvListaSolicitudEmbalaje.Rows.Count > 0 Then
                Me.rbtSiAprobacionEmbalaje.Enabled = True
                Me.rbtNoAprobacionEmbalaje.Enabled = True
                Me.txtObservacionAprobacionEmbalaje.Enabled = True
                Me.btnAceptarAprobacionEmbalaje.Enabled = True
                Me.grbGuiaEnvioAprobacionEmbalaje.Enabled = True

                Me.lblCodigoAprobacionEmbalaje.Text = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("codigo").Value
                Me.lblRazonSocialAprobacionEmbalaje.Text = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("cliente").Value
                'Me.lblContactoAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("contacto").Value

                Me.lbloficinaAprobacionEmbalaje.Text = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("oficina").Value
                Me.lblSolicitanteAprobacionEmbalaje.Text = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("solicitante").Value
                Me.lblFuncionarioAprobacionEmbalaje.Text = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("funcionario").Value

                'Me.lblLocalidadAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("localidad").Value
                'Me.lblKmAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("km").Value
                'Me.lblHoraAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("hora").Value

                Me.lblCostoAprobacionEmbalaje.Text = Format(CDbl(Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("costo").Value), "###,###,###0.00")
                Me.lblPrecioAceptadoAprobacionEmbalaje.Text = Format(CDbl(Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("total").Value), "###,###,###0.00")
                Me.txtPrecioAprobacionEmbalaje.Text = Format(CDbl(Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("total").Value), "###,###,###0.00")

                Dim intID As Integer = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("id").Value
                ListarGuiaEnvioEmbalaje(intID, Me.dgvGuiaEnvioAprobacionEmbalaje)

                Dim dblPeso As Double = ObtieneSuma(Me.dgvGuiaEnvioAprobacionEmbalaje, 11)
                Dim dblMonto As Double = ObtieneSuma(Me.dgvGuiaEnvioAprobacionEmbalaje, 9)

                Me.lblPesoAprobacionEmbalaje.Text = Format(dblPeso, "0.00")
                Me.lblMontoAprobacionEmbalaje.Text = Format(dblMonto, "0.00")

                Me.btnAceptarAprobacionEmbalaje.Focus()
            Else
                Me.rbtSiAprobacionEmbalaje.Enabled = False
                Me.rbtNoAprobacionEmbalaje.Enabled = False
                Me.txtObservacionAprobacionEmbalaje.Enabled = False
                Me.btnAceptarAprobacionEmbalaje.Enabled = False
                Me.grbGuiaEnvioAprobacionEmbalaje.Enabled = False
            End If
        End If
    End Sub

    Sub MostrarSolicitudEmbalaje(ByVal row As Integer)
        With dgvListaSolicitudEmbalaje
            Me.lblNumeroSolicitudEmbalaje.Text = .Rows(row).Cells("numero_solicitud").Value
            Me.dtpFechaEmbalaje.Value = .Rows(row).Cells("fecha_solicitud").Value
            Me.lblOficinaEmbalaje.Text = .Rows(row).Cells("oficina").Value
            Me.lblSolicitanteEmbalaje.Text = .Rows(row).Cells("solicitante").Value

            Me.txtCodigoClienteEmbalaje.Text = .Rows(row).Cells("codigo").Value
            Me.txtClienteEmbalaje.Text = .Rows(row).Cells("cliente").Value

            Me.txtCostoEmbalaje.Text = Format(.Rows(row).Cells("costo").Value, "###,###,###0.00")
            'Me.txtKilometro.Text = IIf(IsDBNull(.Rows(row).Cells("km").Value), "", .Rows(row).Cells("km").Value)
            'Me.txtHora.Text = IIf(IsDBNull(.Rows(row).Cells("hora").Value), "", .Rows(row).Cells("hora").Value)
            'Me.txtLocalidad.Text = IIf(IsDBNull(.Rows(row).Cells("localidad").Value), "", .Rows(row).Cells("localidad").Value)

            Me.txtRucProveedorEmbalaje.Text = IIf(IsDBNull(.CurrentRow.Cells("ruc").Value), "", .CurrentRow.Cells("ruc").Value)
            If Not IsDBNull(.CurrentRow.Cells("id_proveedor").Value) Then
                Me.txtRucProveedorEmbalaje.Tag = IIf(.CurrentRow.Cells("id_proveedor").Value = 0, "", (.CurrentRow.Cells("id_proveedor").Value))
            Else
                Me.txtRucProveedorEmbalaje.Tag = 0
            End If
            Me.txtRazonSocialProveedorEmbalaje.Text = IIf(IsDBNull(.CurrentRow.Cells("proveedor").Value), "", .CurrentRow.Cells("proveedor").Value)
            Me.txtRazonSocialProveedorEmbalaje.Enabled = False

            Me.txtObservacionEmbalaje.Text = .Rows(row).Cells("observacion").Value

            If .Rows(row).Cells("idestado").Value = 1 And (intNivel = 1 Or intNivel = 4) Then
                Me.txtCostoEmbalaje.Enabled = True
                'Me.txtKilometro.Enabled = True
                'Me.txtHora.Enabled = True
                'Me.txtLocalidad.Enabled = True
                Me.txtObservacionEmbalaje.Enabled = True
                Me.btnAgregarGEEmbalaje.Enabled = True
                Me.btnEliminarGEEmbalaje.Enabled = True
                Me.dgvGuiaEnvioEmbalaje.Enabled = True
                Me.txtRucProveedorEmbalaje.Enabled = True
                Me.tsbGrabar.Enabled = True
            Else
                Me.txtCostoEmbalaje.Enabled = False
                'Me.txtKilometro.Enabled = False
                'Me.txtHora.Enabled = False
                'Me.txtLocalidad.Enabled = False
                Me.txtObservacionEmbalaje.Enabled = False
                Me.btnAgregarGEEmbalaje.Enabled = False
                Me.btnEliminarGEEmbalaje.Enabled = False
                Me.dgvGuiaEnvioEmbalaje.Enabled = False
                Me.txtRucProveedorEmbalaje.Enabled = False
                Me.txtRazonSocialProveedorEmbalaje.Enabled = False
                Me.tsbGrabar.Enabled = False
            End If
        End With
    End Sub

    Sub GrabarSolicitudEmbalaje(ByVal cliente As Integer)
        Try
            Dim intID As Integer, intNumeroSolicitud As Integer, strFecha As String, strObservacion As String
            Dim dblCosto As Double, intUsuario As Integer, strIP As String, dblKm As Double, strHora As String, strLocalidad As String
            Dim intProveedor As Integer, strRuc As String, strRazonSocial As String

            intProveedor = IIf(IsNothing(Me.txtRucProveedorEmbalaje.Tag), 0, Val(Me.txtRucProveedorEmbalaje.Tag))
            strRuc = Me.txtRucProveedorEmbalaje.Text.Trim
            strRazonSocial = Me.txtRazonSocialProveedorEmbalaje.Text.Trim

            Dim objLN As New dtoFueraZona
            If intOperacion = Operacion.Nuevo Then
                intID = 0
            Else
                intID = dgvListaSolicitudEmbalaje.CurrentRow.Cells("id").Value
            End If
            intNumeroSolicitud = Me.lblNumeroSolicitudEmbalaje.Text
            strFecha = Me.dtpFechaEmbalaje.Value.ToShortDateString
            strObservacion = Me.txtObservacionEmbalaje.Text.Trim
            dblCosto = CDbl(Me.txtCostoEmbalaje.Text)
            'dblKm = CDbl(Me.txtKilometro.Text)
            'strHora = Me.txtHora.Text
            'strLocalidad = Me.txtLocalidad.Text.Trim

            intUsuario = dtoUSUARIOS.IdLogin
            strIP = dtoUSUARIOS.IP

            Dim intCiudad As Integer, intAgencia As Integer, intAgenciaGasto As Integer
            intCiudad = dtoUSUARIOS.m_iIdUnidadAgenciaReal
            intAgencia = dtoUSUARIOS.iIDAGENCIAS

            If Venta = 2 Then 'credito 'contado
                intAgenciaGasto = Me.dgvGuiaEnvioEmbalaje.CurrentRow.Cells("idagencia_destino").Value
            Else
                intAgenciaGasto = 0
            End If

            Dim intIDZona As Integer = objLN.GrabarSolicitudEmbalaje(intID, intNumeroSolicitud, cliente, strObservacion, dblCosto, _
                                                             intCiudad, intAgencia, _
                                                             intProveedor, strRuc, strRazonSocial, _
                                                             strFecha, intUsuario, strIP, intAgenciaGasto)
            'Actualizar guias de envio
            With Me.dgvGuiaEnvioEmbalaje
                For Each row As DataGridViewRow In .Rows
                    intID = IIf(IsDBNull(row.Cells("id").Value), 0, row.Cells("id").Value)
                    Dim intIDFz As Integer = intIDZona
                    strFecha = row.Cells("fecha").Value
                    Dim intTipo As Integer = row.Cells("idtipo").Value
                    Dim intGuia As Integer = row.Cells("idcomprobante").Value
                    Dim intEstado As Integer = row.Cells("estado").Value
                    Dim strOrigen As String = row.Cells("origen").Value
                    Dim strDestino As String = row.Cells("destino").Value
                    Dim dblTotal As Double = row.Cells("total").Value
                    Dim strGuia As String = row.Cells("comprobante").Value
                    Dim intAgenciaOrigen As Integer = row.Cells("idagencia_origen").Value
                    Dim intAgenciaDestino As Integer = row.Cells("idagencia_destino").Value
                    Dim intCantidad As Integer = row.Cells("cantidad").Value
                    Dim dblPeso As Double = row.Cells("peso").Value
                    Dim strDireccion As String = row.Cells("direccion").Value

                    objLN.GrabarGuiaEnvioEmbalaje(intID, intIDFz, strFecha, intTipo, intGuia, intEstado, strOrigen, strDestino, dblTotal, strGuia, intAgenciaOrigen, intAgenciaDestino, _
                                          intCantidad, dblPeso, strDireccion, _
                                          intUsuario, strIP)
                Next
            End With

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub ListarSolicitudEmbalaje()
        Try
            Dim strEstado As String, intOpcion As Integer = 0, intCiudad As Integer
            Dim strInicio As String, strFin As String

            strInicio = Me.dtpInicioEmbalaje.Value.ToShortDateString
            strFin = Me.dtpFinEmbalaje.Value.ToShortDateString
            If Me.rbtSeguimientoEmbalaje.Checked Then 'seguimiento
                strEstado = Me.cboestadoSolicitudEmbalaje.SelectedIndex
            ElseIf Me.rbtPorAceptarEmbalaje.Checked Then
                strInicio = "" : strFin = ""
                If Me.cboestadoSolicitudEmbalaje.SelectedIndex = 0 Then
                    strEstado = "1,3" 'pendientes y observados
                Else
                    strEstado = IIf(Me.cboestadoSolicitudEmbalaje.SelectedIndex = 1, 1, 3)
                End If
            ElseIf Me.rbtPorAprobarEmbalaje.Checked Then
                strEstado = "2" 'aceptados
                strInicio = "" : strFin = ""
            End If
            Dim obj As New dtoFueraZona
            intCiudad = Me.cboCiudadEmbalaje.SelectedValue

            dgvListaSolicitudEmbalaje.DataSource = obj.ListarSolicitudEmbalaje(strEstado, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.IdLogin, intNivel, _
                                                               strInicio, strFin, intCiudad, intOpcion)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AnularEmbalaje()
        Try
            Dim objLN As New dtoFueraZona

            Dim intID As Integer = dgvListaSolicitudEmbalaje.CurrentRow.Cells("id").Value
            objLN.AnularSolicitudEmbalaje(intID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboEstadoSolicitudEmbalaje_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboestadoSolicitudEmbalaje.SelectedIndexChanged
        'Me.btnConsultarFueraZona_Click(Nothing, Nothing)
        'ListarSolicitud()
        'If Me.dgvListaSolicitud.Rows.Count > 0 Then
        '    Me.tsbEditar.Enabled = True
        '    If Me.dgvListaSolicitud.CurrentRow.Cells("idestado").Value = 1 And (intNivel = 1 Or intNivel = 4) Then
        '        Me.tsbAnular.Enabled = True
        '    Else
        '        Me.tsbAnular.Enabled = False
        '    End If
        'Else
        '    Me.tsbEditar.Enabled = False
        '    Me.tsbAnular.Enabled = False
        'End If
    End Sub

    Sub ControlaOpcionEmbalaje() Handles rbtSeguimientoEmbalaje.CheckedChanged, rbtPorAceptarEmbalaje.CheckedChanged, rbtPorAprobarEmbalaje.CheckedChanged
        If rbtSeguimientoEmbalaje.Checked Then
            Me.pnlEstadoEmbalaje.Visible = True
            ActualizaComboEmbalaje()
            If intNivel = 2 Or intNivel = 3 Then
                Me.cboestadoSolicitudEmbalaje.SelectedIndex = 1
            End If

            If tabEmbalaje.TabPages.IndexOf(tabAceptacionEmbalaje) > -1 Then
                Me.tabEmbalaje.TabPages.Remove(tabEmbalaje.TabPages("tabAceptacionEmbalaje"))
            End If
            If tabEmbalaje.TabPages.IndexOf(tabSolicitudEmbalaje) = -1 Then
                Me.tabEmbalaje.TabPages.Add(tabSolicitudEmbalaje)
            End If
            If tabEmbalaje.TabPages.IndexOf(tabAprobacionEmbalaje) > -1 Then
                Me.tabEmbalaje.TabPages.Remove(tabEmbalaje.TabPages("tabAprobacionEmbalaje"))
            End If
            'If intNivel2 = 2 Then
            '    If tabFueraZona.TabPages.IndexOf(tabFacturar) >= 1 Then
            '        Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabImpresionZona"))
            '    End If
            '    If tabFueraZona.TabPages.IndexOf(tabFacturar) = -1 Then
            '        Me.tabFueraZona.TabPages.Add(tabFacturar)
            '    End If
            'End If
        ElseIf rbtPorAceptarEmbalaje.Checked Then
            Me.pnlEstadoEmbalaje.Visible = True
            ActualizaComboEmbalaje(2)

            RemoveHandler cboestadoSolicitudEmbalaje.SelectedIndexChanged, AddressOf cboEstadoSolicitudEmbalaje_SelectedIndexChanged
            Me.cboestadoSolicitudEmbalaje.SelectedIndex = 0
            AddHandler cboestadoSolicitudEmbalaje.SelectedIndexChanged, AddressOf cboEstadoSolicitudEmbalaje_SelectedIndexChanged

            If tabEmbalaje.TabPages.IndexOf(tabSolicitudEmbalaje) > -1 Then
                Me.tabEmbalaje.TabPages.Remove(tabEmbalaje.TabPages("tabSolicitudEmbalaje"))
            End If
            If tabEmbalaje.TabPages.IndexOf(tabAceptacionEmbalaje) = -1 Then
                Me.tabEmbalaje.TabPages.Add(tabAceptacionEmbalaje)
            End If
            If tabEmbalaje.TabPages.IndexOf(tabAprobacionEmbalaje) > -1 Then
                Me.tabEmbalaje.TabPages.Remove(tabEmbalaje.TabPages("tabAprobacionEmbalaje"))
            End If
        ElseIf rbtPorAprobarEmbalaje.Checked Then
            Me.pnlEstadoEmbalaje.Visible = False
            If tabEmbalaje.TabPages.IndexOf(tabSolicitudEmbalaje) > -1 Then
                Me.tabEmbalaje.TabPages.Remove(tabEmbalaje.TabPages("tabSolicitudEmbalaje"))
            End If
            If tabEmbalaje.TabPages.IndexOf(tabAprobacionEmbalaje) = -1 Then
                Me.tabEmbalaje.TabPages.Add(tabAprobacionEmbalaje)
            End If
            If tabEmbalaje.TabPages.IndexOf(tabAceptacionEmbalaje) > -1 Then
                Me.tabEmbalaje.TabPages.Remove(tabEmbalaje.TabPages("tabAceptacionEmbalaje"))
            End If
            'If intNivel2 = 2 Then
            '    If tabFueraZona.TabPages.IndexOf(tabFacturar) >= 1 Then
            '        Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabImpresionZona"))
            '    End If
            '    If tabFueraZona.TabPages.IndexOf(tabFacturar) = -1 Then
            '        Me.tabFueraZona.TabPages.Add(tabFacturar)
            '    End If
            'End If
        End If
        ListarSolicitudEmbalaje()
    End Sub

    Sub GrabarSolicitudEmbalaje()
        Try
            Dim intCliente As Integer
            If intOperacion = Operacion.Nuevo Then
                If autoCliente.IndexOf(Me.txtClienteEmbalaje.Text) = -1 Then
                    intCliente = 0
                Else
                    intCliente = Int(colCliente.Item(autoCliente.IndexOf(Me.txtClienteEmbalaje.Text).ToString))
                End If

                If intCliente = 0 Then
                    MessageBox.Show("Seleccione el Cliente", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtClienteEmbalaje.Focus()
                    Return
                End If
            End If

            If Val(Me.txtCostoEmbalaje.Text) = 0 Then
                MessageBox.Show("Ingrese Costo", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtCostoEmbalaje.Focus()
                Return
            End If

            'If Me.txtLocalidad.Text.Trim.Length = 0 Then
            '    MessageBox.Show("Ingrese la Localidad de Entrega", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.txtLocalidad.Text = ""
            '    Me.txtLocalidad.Focus()
            '    Return
            'End If

            'If Val(Me.txtKilometro.Text) = 0 Then
            '    MessageBox.Show("Ingrese la Distancia en Kilómetros", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.txtKilometro.Focus()
            '    Return
            'End If

            'txtHora_LostFocus(Nothing, Nothing)
            'If Me.txtHora.Text = "00:00" Then
            '    MessageBox.Show("Ingrese la Distancia en Horas", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Me.txtHora.Focus()
            '    Return
            'End If

            'If Mid(Trim(txtHora.Text), 1, 2) > "23" Or Mid(Trim(txtHora.Text), 4, 2) > "59" Then
            'MessageBox.Show("Ingrese la Distancia correcta en Horas", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Me.txtHora.Focus()
            'Return
            'End If

            Dim blnRucValido As Boolean = fnValidarRUC(txtRucProveedorEmbalaje.Text)
            intLlamada = 1
            Me.txtRucProveedorEmbalaje_LostFocus(Nothing, Nothing)

            intLlamada = 0
            If Not blnRucValido Then
                MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtRucProveedorEmbalaje.Focus()
                Return
            End If

            If Me.txtRazonSocialProveedorEmbalaje.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Razón Social", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtRazonSocialProveedorEmbalaje.Text = ""
                txtRazonSocialProveedorEmbalaje.Focus()
                Return
            End If

            If Me.txtObservacionEmbalaje.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese la Observación", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtObservacionEmbalaje.Text = ""
                Me.txtObservacionEmbalaje.Focus()
                Return
            End If

            If Me.dgvGuiaEnvioEmbalaje.Rows.Count = 0 Or Not dtoUtilitario.FilasGridVisible(Me.dgvGuiaEnvioEmbalaje) Then
                MessageBox.Show("Seleccione las Guías de Envío", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAgregarGEEmbalaje.Focus()
                Return
            End If

            'graba solicitud embalaje
            Cursor = Cursors.WaitCursor
            GrabarSolicitudEmbalaje(intCliente)
            ListarSolicitudEmbalaje()

            Dim intID As Integer = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("id").Value
            ListarGuiaEnvioEmbalaje(intID, Me.dgvGuiaEnvioEmbalaje)

            If Me.dgvListaSolicitudEmbalaje.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                If intNivel = 1 Or intNivel = 4 Then
                    Me.tsbAnular.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                End If
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
            Me.tabEmbalaje.SelectedTab = Me.tabEmbalaje.TabPages("tabListaEmbalaje")

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpFechaEmbalaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaEmbalaje.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dtpFechaFueraZona_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaFueraZona.ValueChanged

    End Sub

    Private Sub txtCodigoClienteEmbalaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoClienteEmbalaje.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                If Me.txtCodigoClienteEmbalaje.Text.Trim.Length > 0 Then
                    Dim obj As New dtoCarga
                    Dim strCodigoCliente As String = Me.txtCodigoClienteEmbalaje.Text.Trim
                    Dim dt As DataTable = obj.ObtieneCliente(strCodigoCliente)
                    If dt.Rows.Count > 0 Then
                        Me.txtClienteEmbalaje.Text = dt.Rows(0).Item("cliente")
                        SendKeys.Send(vbTab)
                    Else
                        MessageBox.Show("El Cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCodigoClienteEmbalaje_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoClienteEmbalaje.LostFocus
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            Me.txtClienteEmbalaje.Text = ""
            Me.txtCodigoClienteEmbalaje.Text = ""
        End If
    End Sub

    Private Sub txtCodigoClienteEmbalaje_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoClienteEmbalaje.TextChanged
        Me.dgvGuiaEnvioEmbalaje.Rows.Clear()
    End Sub

    Private Sub txtClienteEmbalaje_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClienteEmbalaje.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Not autoCliente.IndexOf(txtClienteEmbalaje.Text) = -1 Then
                Dim ObjPersona As New ClsLbTepsa.dtoPersona
                With ObjPersona
                    .IDPERSONA = Int(colCliente.Item(autoCliente.IndexOf(Me.txtClienteEmbalaje.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'Datahelper
                    ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                    Me.txtCodigoClienteEmbalaje.Text = .CODIGO_CLIENTE
                End With
                SendKeys.Send(vbTab)
            Else
                Me.txtCodigoClienteEmbalaje.Text = ""
            End If
        End If
    End Sub

    Private Sub txtClienteEmbalaje_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClienteEmbalaje.LostFocus
        If autoCliente.IndexOf(Me.txtClienteEmbalaje.Text) = -1 Then
            Me.txtClienteEmbalaje.Text = ""
            Me.txtCodigoClienteEmbalaje.Text = ""
        End If
    End Sub

    Private Sub txtClienteEmbalaje_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClienteEmbalaje.TextChanged
        Me.dgvGuiaEnvioEmbalaje.Rows.Clear()
    End Sub

    Private Sub txtCostoEmbalaje_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCostoEmbalaje.Enter
        If Val(txtCostoEmbalaje.Text) > 0 Then
            Me.txtCostoEmbalaje.Text = Replace(Me.txtCostoEmbalaje.Text, ",", "")
        Else
            Me.txtCostoEmbalaje.Text = ""
        End If
    End Sub

    Private Sub txtCostoEmbalaje_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCostoEmbalaje.GotFocus
        txtCostoEmbalaje.SelectAll()
    End Sub

    Private Sub txtCostoEmbalaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostoEmbalaje.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtCostoEmbalaje.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCostoEmbalaje_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCostoEmbalaje.LostFocus
        If Val(Me.txtCostoEmbalaje.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtCostoEmbalaje.Text)
            Me.txtCostoEmbalaje.Text = Format(dblMonto, "#,###,###0.00")
        Else
            Me.txtCostoEmbalaje.Text = ""
        End If
    End Sub

    Private Sub txtRucProveedorEmbalaje_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedorEmbalaje.Enter
        txtRucProveedorEmbalaje.SelectAll()
    End Sub

    Private Sub txtRucProveedorEmbalaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRucProveedorEmbalaje.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtRucProveedorEmbalaje_LostFocus(Nothing, Nothing)
            If Me.txtRazonSocialProveedorEmbalaje.Enabled Then
                Me.txtRazonSocialProveedorEmbalaje.Focus()
            Else
                SendKeys.Send(vbTab)
            End If
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRucProveedorEmbalaje_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedorEmbalaje.LostFocus
        If Me.txtRucProveedorEmbalaje.Text.Trim.Length > 0 Then
            Dim intId As Integer = 0, strRazonSocial As String = "", strRuc As String
            strRuc = Me.txtRucProveedorEmbalaje.Text.Trim
            ListarProveedor(strRuc, intId, strRazonSocial)
            If intId > 0 Then
                Me.txtRucProveedorEmbalaje.Tag = intId
                Me.txtRazonSocialProveedorEmbalaje.Text = strRazonSocial
                Me.txtRazonSocialProveedorEmbalaje.Enabled = False
            ElseIf intLlamada = 0 Then
                Me.txtRucProveedorEmbalaje.Tag = ""
                Me.txtRazonSocialProveedorEmbalaje.Text = ""
                Me.txtRazonSocialProveedorEmbalaje.Enabled = True
                Me.txtRazonSocialProveedorEmbalaje.Focus()
            End If
        Else
            Me.txtRazonSocialProveedorEmbalaje.Focus()
        End If
    End Sub

    Private Sub txtRucProveedorEmbalaje_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucProveedorEmbalaje.TextChanged
        Me.txtRazonSocialProveedorEmbalaje.Text = ""
        Me.txtRucProveedorEmbalaje.Tag = ""
        Me.txtRazonSocialProveedorEmbalaje.Enabled = True
    End Sub

    Private Sub txtRazonSocialProveedorEmbalaje_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazonSocialProveedorEmbalaje.Enter
        txtRazonSocialProveedorEmbalaje.SelectAll()
    End Sub

    Private Sub txtRazonSocialProveedorEmbalaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazonSocialProveedorEmbalaje.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservacionEmbalaje_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservacionEmbalaje.Enter
        txtObservacionEmbalaje.SelectAll()
    End Sub

    Private Sub txtObservacionEmbalaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacionEmbalaje.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservacionEmbalaje_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacionEmbalaje.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Function AgregarGuiaEnvioEmbalaje(ByVal frm As frmAgregarGuiaEnvio, Optional ByVal opcion As Integer = 1) As Integer
        Dim intRegistros As Integer = 0
        For Each row As DataGridViewRow In frm.dgvResultado.Rows
            If row.Cells(0).Value = 1 Then
                If opcion = 1 Then
                    If Not ExisteValorGrid(Me.dgvGuiaEnvioEmbalaje, 13, row.Cells("id").Value) Then
                        Me.dgvGuiaEnvioEmbalaje.Rows.Add()
                        Me.dgvGuiaEnvioEmbalaje(0, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = 0
                        Me.dgvGuiaEnvioEmbalaje(1, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = Format(row.Cells("fecha").Value, "dd/MM/yyyy")
                        Me.dgvGuiaEnvioEmbalaje(2, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("idtipo").Value
                        Me.dgvGuiaEnvioEmbalaje(3, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("tipo").Value
                        Me.dgvGuiaEnvioEmbalaje(4, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("comprobante").Value
                        Me.dgvGuiaEnvioEmbalaje(5, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("origen").Value
                        Me.dgvGuiaEnvioEmbalaje(6, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("destino").Value
                        Me.dgvGuiaEnvioEmbalaje(7, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("agencia_origen").Value
                        Me.dgvGuiaEnvioEmbalaje(8, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("agencia_destino").Value
                        Me.dgvGuiaEnvioEmbalaje(9, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = Format(row.Cells("total").Value, "###,###,###0.00")
                        Me.dgvGuiaEnvioEmbalaje(10, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("cantidad").Value
                        Me.dgvGuiaEnvioEmbalaje(11, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = Format(row.Cells("peso").Value, "###,###,###0.00")
                        Me.dgvGuiaEnvioEmbalaje(12, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("direccion").Value
                        Me.dgvGuiaEnvioEmbalaje(13, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("id").Value
                        Me.dgvGuiaEnvioEmbalaje(14, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("idagencia_origen").Value
                        Me.dgvGuiaEnvioEmbalaje(15, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("idagencia_destino").Value
                        Me.dgvGuiaEnvioEmbalaje(16, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = 0
                        intRegistros += 1
                    End If
                Else
                    Me.dgvGuiaEnvioEmbalaje(1, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("fecha").Value
                    Me.dgvGuiaEnvioEmbalaje(2, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("idtipo").Value
                    Me.dgvGuiaEnvioEmbalaje.CurrentRow.Cells(3).Value = row.Cells("tipo").Value
                    Me.dgvGuiaEnvioEmbalaje.CurrentRow.Cells(4).Value = row.Cells("comprobante").Value
                    Me.dgvGuiaEnvioEmbalaje(5, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("origen").Value
                    Me.dgvGuiaEnvioEmbalaje(6, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("destino").Value
                    Me.dgvGuiaEnvioEmbalaje(7, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("agencia_origen").Value
                    Me.dgvGuiaEnvioEmbalaje(8, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("agencia_destino").Value
                    Me.dgvGuiaEnvioEmbalaje(9, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = Format(row.Cells("total").Value, "###,###,###0.00")
                    Me.dgvGuiaEnvioEmbalaje(10, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("cantidad").Value
                    Me.dgvGuiaEnvioEmbalaje(11, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = Format(row.Cells("peso").Value, "###,###,###0.00")
                    Me.dgvGuiaEnvioEmbalaje(12, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("direccion").Value
                    Me.dgvGuiaEnvioEmbalaje(13, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("id").Value
                    Me.dgvGuiaEnvioEmbalaje(14, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("idagencias").Value
                    Me.dgvGuiaEnvioEmbalaje(15, Me.dgvGuiaEnvioEmbalaje.Rows.Count - 1).Value = row.Cells("idagencias_destino").Value
                    intRegistros += 1
                End If
            End If
        Next
        Return intRegistros
    End Function

    Private Sub btnEliminarGEEmbalaje_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarGEEmbalaje.Click
        With dgvGuiaEnvioEmbalaje
            If .Rows.Count > 0 Then
                Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está Seguro de Desactivar la Guía de Envío Seleccionada?", "Desactivar Guía de Envío", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    If dgvGuiaEnvioEmbalaje.CurrentRow.Cells("estado").Value = 0 Then
                        .Rows.Remove(.CurrentRow)
                    Else
                        dgvGuiaEnvioEmbalaje.CurrentRow.Cells("estado").Value = 2
                        dgvGuiaEnvioEmbalaje.CurrentRow.Visible = False
                    End If
                    If Not dtoUtilitario.FilasGridVisible(Me.dgvGuiaEnvioEmbalaje) Then
                        Me.btnEliminarGEEmbalaje.Enabled = False
                    End If
                    If Me.btnEliminarGEEmbalaje.Enabled Then
                        Dim intFila As Integer = dtoUtilitario.FilaGridVisiblePrimera(Me.dgvGuiaEnvioEmbalaje)
                        .Rows(intFila).Selected = True
                        .CurrentCell = .Rows(intFila).Cells(1)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub btnAgregarGEEmbalaje_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarGEEmbalaje.Click
        Dim intCliente As Integer
        If autoCliente.IndexOf(Me.txtClienteEmbalaje.Text) = -1 Then
            intCliente = 0
        Else
            intCliente = Int(colCliente.Item(autoCliente.IndexOf(Me.txtClienteEmbalaje.Text).ToString))
        End If
        Dim intTipo As Integer
        If Acceso.SiRol(G_Rol, Me, 1, 1) Then 'Credito
            intTipo = 1
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 5) Then 'Contado
            intTipo = 2
        End If

        Dim frm As New frmAgregarGuiaEnvio
        frm.IDCliente = intCliente
        frm.Cliente = Me.txtClienteEmbalaje.Text.Trim

        frm.AgenciaDestino = dtoUSUARIOS.iIDAGENCIAS
        frm.NombreAgenciaDestino = dtoUSUARIOS.m_iNombreAgencia

        frm.Tipo = intTipo
        frm.getOperacion = 1
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Venta = frm.cboTipo.SelectedIndex
            If AgregarGuiaEnvioEmbalaje(frm) = 0 Then
                MessageBox.Show("Las Guías de Envío ya existen en la Lista", "Agregar Guía de Envío", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MessageBox.Show("La Guía de Envío " & frm.dgvResultado.Rows(0).Cells("guia").Value & " ya existe en la lista", "Agregar Guía de Envío", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAgregarGEEmbalaje.Focus()
            End If
        Else
            Me.btnAgregarGEEmbalaje.Focus()
        End If
    End Sub

    Private Sub btnConsultarEmbalaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarEmbalaje.Click
        Try
            Cursor = Cursors.WaitCursor
            ListarSolicitudEmbalaje()
            If Me.dgvListaSolicitudEmbalaje.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                If Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("idestado").Value = 1 And (intNivel = 1 Or intNivel = 4) Then
                    Me.tsbAnular.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                End If
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtPrecioAceptacionEmbalaje_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecioAceptacionEmbalaje.Enter
        If Val(txtPrecioAceptacionEmbalaje.Text) > 0 Then
            Me.txtPrecioAceptacionEmbalaje.Text = Replace(Me.txtPrecioAceptacionEmbalaje.Text, ",", "")
        Else
            Me.txtPrecioAceptacionEmbalaje.Text = "0.00"
        End If
    End Sub

    Private Sub txtPrecioAceptacionEmbalaje_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecioAceptacionEmbalaje.GotFocus
        txtPrecioAceptacionEmbalaje.SelectAll()
    End Sub

    Private Sub txtPrecioAceptacionEmbalaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioAceptacionEmbalaje.KeyPress
        If Not ValidarNumeroReal(e.KeyChar, Me.txtPrecioAceptacionEmbalaje.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecioAceptacionEmbalaje_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecioAceptacionEmbalaje.LostFocus
        If Val(Me.txtPrecioAceptacionEmbalaje.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtPrecioAceptacionEmbalaje.Text)
            Me.txtPrecioAceptacionEmbalaje.Text = Format(dblMonto, "#,###,###0.00")
        Else
            Me.txtPrecioAceptacionEmbalaje.Text = "0.00"
        End If
    End Sub

    Private Sub txtObservacionAceptacionEmbalaje_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservacionAceptacionEmbalaje.Enter
        txtObservacionAceptacionEmbalaje.SelectAll()
    End Sub

    Sub AceptarEmbalaje()
        Try
            If Me.rbtSiAceptacionEmbalaje.Checked Then 'acepta
                Dim strMensaje As String = "¿Está Seguro de Aceptar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aceptar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim intEstado As Integer '= IIf(Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("idestado").Value = 1, 2, 3)
                    Dim dblCosto As Double = CDbl(Me.lblCostoAceptacionEmbalaje.Text)
                    Dim dblPrecio As Double = CDbl(Me.txtPrecioAceptacionEmbalaje.Text)
                    If dblPrecio >= (dblCosto * 2) Then
                        intEstado = 3
                    Else
                        If Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("idestado").Value = 1 Then
                            intEstado = 2
                        Else
                            intEstado = 3
                        End If
                    End If
                    AceptarSolicitudEmbalaje(intEstado)
                    If intEstado = 2 Then
                        MessageBox.Show("Solicitud Aceptada", "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    Me.ListarSolicitudEmbalaje()
                    tabEmbalaje.SelectedTab = tabEmbalaje.TabPages("tabListaEmbalaje")
                    Cursor = Cursors.Default
                End If
            Else 'no acepta
                If MessageBox.Show("¿Está Seguro de No Aceptar la Solicitud?", "Aceptar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    AceptarSolicitudEmbalaje(5)
                    MessageBox.Show("Solicitud no Aceptada", "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudEmbalaje()
                    tabEmbalaje.SelectedTab = tabEmbalaje.TabPages("tabListaEmbalaje")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AceptarSolicitudEmbalaje(ByVal estado As Integer)
        Cursor = Cursors.WaitCursor
        Try
            Dim objLN As New dtoFueraZona
            Dim intID As Integer = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("id").Value
            Dim dblPrecio As Double, strObservacion As String
            If estado = 2 Or estado = 3 Then
                dblPrecio = CDbl(Me.txtPrecioAceptacionEmbalaje.Text)
                strObservacion = ""
            Else
                strObservacion = Me.txtObservacionAceptacionEmbalaje.Text.Trim
                dblPrecio = 0
            End If
            objLN.AceptarSolicitudEmbalaje(intID, estado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dblPrecio, strObservacion)

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub btnAceptarAceptacionEmbalaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarAceptacionEmbalaje.Click
        If Val(Me.txtPrecioAceptacionEmbalaje.Text) = 0 Then
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("El Precio es 0" & Chr(13) & Chr(13) & "¿Está seguro de Continuar?", "Aceptar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.No Then
                Me.txtPrecioAceptacionEmbalaje.Focus()
                Return
            End If
        End If

        If Me.rbtNoAceptacionEmbalaje.Checked AndAlso Me.txtObservacionAceptacionEmbalaje.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Motivo", "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtObservacionAceptacionEmbalaje.Text = ""
            Me.txtObservacionAceptacionEmbalaje.Focus()
            Return
        End If
        AceptarEmbalaje()
    End Sub

    Private Sub rbtSiAprobacionEmbalaje_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiAprobacionEmbalaje.CheckedChanged
        Me.txtPrecioAprobacionEmbalaje.Text = Me.lblPrecioAceptadoAprobacionEmbalaje.Text
        Me.txtPrecioAprobacionEmbalaje.Enabled = False
        Me.txtObservacionAprobacionEmbalaje.Text = ""
        Me.txtObservacionAprobacionEmbalaje.Enabled = False
        Me.btnAceptarAprobacionEmbalaje.Focus()
    End Sub

    Private Sub rbtNoAprobacionEmbalaje_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoAprobacionEmbalaje.CheckedChanged
        Me.txtPrecioAprobacionEmbalaje.Text = ""
        Me.txtPrecioAprobacionEmbalaje.Enabled = False
        Me.txtObservacionAprobacionEmbalaje.Text = ""
        Me.txtObservacionAprobacionEmbalaje.Enabled = True
        Me.txtObservacionAprobacionEmbalaje.Focus()
    End Sub

    Private Sub rbtPrecioAceptacionEmbalaje_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPrecioAceptacionEmbalaje.CheckedChanged
        Me.txtPrecioAprobacionEmbalaje.Enabled = True
        Me.txtPrecioAprobacionEmbalaje.Text = Me.lblPrecioAceptadoAprobacionEmbalaje.Text
        Me.txtObservacionAprobacionEmbalaje.Text = ""
        Me.txtObservacionAprobacionEmbalaje.Enabled = True
        Me.txtPrecioAprobacionEmbalaje.Focus()
    End Sub

    Private Sub txtPrecioAprobacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecioAprobacion.Enter
        Me.txtPrecioAprobacion.SelectAll()
    End Sub

    Private Sub txtPrecioAprobacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioAprobacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtPrecioAprobacion.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecioAprobacionEmbalaje_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecioAprobacionEmbalaje.Enter
        Me.txtPrecioAprobacionEmbalaje.SelectAll()
    End Sub

    Private Sub txtPrecioAprobacionEmbalaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioAprobacionEmbalaje.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtPrecioAprobacionEmbalaje.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnAceptarAprobacionEmbalaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarAprobacionEmbalaje.Click
        If Not Me.rbtNoAprobacionEmbalaje.Checked Then
            If Val(Me.txtPrecioAprobacionEmbalaje.Text) = 0 Then
                Dim dlgRespuesta As DialogResult
                dlgRespuesta = MessageBox.Show("El Precio es 0" & Chr(13) & Chr(13) & "¿Está seguro de Continuar?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.No Then
                    Me.rbtPrecioAceptacionEmbalaje.Checked = True
                    Me.txtPrecioAceptacionEmbalaje.Enabled = True
                    Me.txtPrecioAceptacionEmbalaje.Focus()
                    Return
                End If
            End If
            If Me.rbtPrecioAceptacionEmbalaje.Checked Then
                If CDbl(Me.txtPrecioAprobacionEmbalaje.Text) = CDbl(Me.lblPrecioAceptadoAprobacionEmbalaje.Text) Then
                    MessageBox.Show("El Precio Modificado debe ser diferente al Precio Aceptado", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtPrecioAprobacionEmbalaje.Focus()
                    Return
                End If
            End If
        ElseIf Me.rbtNoAprobacionEmbalaje.Checked AndAlso Me.txtObservacionAprobacionEmbalaje.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Motivo", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtObservacionAprobacionEmbalaje.Text = ""
            Me.txtObservacionAprobacionEmbalaje.Focus()
            Return
        End If

        AprobarEmbalaje()

    End Sub

    Sub AprobarEmbalaje()
        Try
            If Me.rbtSiAprobacionEmbalaje.Checked Then 'aprueba
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    AprobarSolicitudEmbalaje(4)
                    MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudEmbalaje()
                    tabEmbalaje.SelectedTab = tabEmbalaje.TabPages("tabListaEmbalaje")
                    Cursor = Cursors.Default
                End If
            ElseIf Me.rbtNoAprobacionEmbalaje.Checked Then 'no aprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    AprobarSolicitudEmbalaje(6)
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudEmbalaje()
                    tabEmbalaje.SelectedTab = tabEmbalaje.TabPages("tabListaEmbalaje")
                    Cursor = Cursors.Default
                End If
            Else 'solicitud observada con precio modificado
                Dim strMensaje As String = "¿Está Seguro de Modificar el Precio Aceptado por el Cliente?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    AprobarSolicitudEmbalaje(3)
                    MessageBox.Show("Solicitud Actualizada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudEmbalaje()
                    tabEmbalaje.SelectedTab = tabEmbalaje.TabPages("tabListaEmbalaje")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AprobarSolicitudEmbalaje(ByVal estado As Integer)
        Cursor = Cursors.WaitCursor
        Try
            Dim objLN As New dtoFueraZona
            Dim intID As Integer = Me.dgvListaSolicitudEmbalaje.CurrentRow.Cells("id").Value
            Dim dblPrecio As Double, strObservacion As String
            If estado = 4 Then
                dblPrecio = CDbl(Me.txtPrecioAprobacionEmbalaje.Text)
                strObservacion = ""
            ElseIf estado = 6 Then
                strObservacion = Me.txtObservacionAprobacionEmbalaje.Text.Trim
                dblPrecio = 0
            Else 'estado=3
                dblPrecio = CDbl(Me.txtPrecioAprobacionEmbalaje.Text)
                If Me.txtObservacionAprobacionEmbalaje.Text.Trim.Length > 0 Then
                    strObservacion = Me.txtObservacionAprobacionEmbalaje.Text.Trim
                Else
                    txtObservacion.Text = ""
                End If
            End If
            objLN.AprobarSolicitudEmbalaje(intID, estado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dblPrecio, strObservacion)

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub dgvGuiaEnvioEmbalaje_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvGuiaEnvioEmbalaje.RowsAdded
        Me.btnEliminarGEEmbalaje.Enabled = Me.dgvGuiaEnvioEmbalaje.Rows.Count > 0 And Me.btnAgregarGEEmbalaje.Enabled
    End Sub

    Private Sub dgvGuiaEnvioEmbalaje_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvGuiaEnvioEmbalaje.RowsRemoved
        Me.btnEliminarGEEmbalaje.Enabled = Me.dgvGuiaEnvioEmbalaje.Rows.Count > 0
    End Sub

    Sub ListarGuiaEnvioEmbalaje(ByVal id As Integer, ByVal dgv As DataGridView)
        Dim objLN As New dtoFueraZona
        Dim dt As DataTable = objLN.ListarGuiaEnvioEmbalaje(id)
        With dgv
            .Rows.Clear()
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .Rows.Add()
                    dgv(0, .Rows.Count - 1).Value = row.Item("id")
                    dgv(1, .Rows.Count - 1).Value = Format(row.Item("fecha"), "dd/MM/yyyy")
                    dgv(2, .Rows.Count - 1).Value = row.Item("idtipo")
                    dgv(3, .Rows.Count - 1).Value = row.Item("tipo")
                    dgv(4, .Rows.Count - 1).Value = row.Item("guia")
                    dgv(5, .Rows.Count - 1).Value = row.Item("origen")
                    dgv(6, .Rows.Count - 1).Value = row.Item("destino")
                    dgv(7, .Rows.Count - 1).Value = row.Item("agencia_origen")
                    dgv(8, .Rows.Count - 1).Value = row.Item("agencia_destino")
                    dgv(9, .Rows.Count - 1).Value = row.Item("total")
                    dgv(10, .Rows.Count - 1).Value = row.Item("cantidad")
                    dgv(11, .Rows.Count - 1).Value = row.Item("peso")
                    dgv(12, .Rows.Count - 1).Value = row.Item("direccion")

                    dgv(13, .Rows.Count - 1).Value = row.Item("idguia")
                    dgv(14, .Rows.Count - 1).Value = row.Item("idagencia_origen")
                    dgv(15, .Rows.Count - 1).Value = row.Item("idagencia_destino")

                    dgv(16, .Rows.Count - 1).Value = row.Item("estado")
                Next
            End If
        End With
    End Sub

    Private Sub dgvListaSolicitudEmbalaje_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListaSolicitudEmbalaje.DoubleClick
        If Me.dgvListaSolicitudEmbalaje.Rows.Count > 0 Then
            tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgvListaSolicitudEmbalaje_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaSolicitudEmbalaje.RowEnter
        If Me.dgvListaSolicitudEmbalaje.Rows.Count > 0 Then
            If Me.dgvListaSolicitudEmbalaje.Rows(e.RowIndex).Cells("idestado").Value = 1 And (intNivel = 1 Or intNivel = 4) Then
                Me.tsbAnular.Enabled = True
            Else
                Me.tsbAnular.Enabled = False
            End If
        End If
    End Sub

    Sub LimpiarAceptacionEmbalaje()
        Me.lblCodigoAceptacionEmbalaje.Text = ""
        Me.lblRazonSocialAceptacionEmbalaje.Text = ""
        Me.lblOficinaAceptacionEmbalaje.Text = ""
        Me.lblSolicitanteAceptacionEmbalaje.Text = ""
        Me.lblObservacionAceptacionEmbalaje.Text = ""
        Me.dgvGuiaEnvioAceptacionEmbalaje.Rows.Clear()
        Me.lblCostoAceptacionEmbalaje.Text = ""
        Me.txtPrecioAceptacionEmbalaje.Text = ""
        Me.rbtSiAceptacionEmbalaje.Checked = True
        Me.txtObservacionAceptacionEmbalaje.Text = ""
    End Sub

    Private Sub ControlaOpcion(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSeguimiento.CheckedChanged, rbtPorAprobar.CheckedChanged, rbtPorAceptar.CheckedChanged

    End Sub
End Class