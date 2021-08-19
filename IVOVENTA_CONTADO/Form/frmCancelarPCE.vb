﻿Imports System.Data.Odbc
Imports AccesoDatos
Imports INTEGRACION_LN
Imports INTEGRACION_EN
Public Class frmCancelarPCE
    Dim coll_iDestino As New Collection
    Public iWinDestino As New AutoCompleteStringCollection
    Dim coll_direccion As New Collection
    Dim aDireccion As New AutoCompleteStringCollection

    Property hnd As Long
    Dim bCondicion As Boolean = False
    Dim bTarifarioGeneral As Boolean
    Dim bOtrasAgencias As Boolean
    Dim bContado As Boolean
    Dim tipo_bole_impre As String
    Dim tipo_factu_impre As String
    Dim TipoComprobante As Integer = 2
    Dim Mro_Digitos_SerieVentas As Integer = 3
    Dim bFAC_Bol As Boolean = False
    Dim Mro_Digitos_Ventas As Integer = 7
    Dim iTipoDoc As Integer
    Dim xIMPRESORA As Integer
    Dim TipoGrid_ As String
    Dim idUnidadAgencias As Integer = -1
    Public Shared iTotalPagado As Double = 0
    Public Shared iVuelto As Double = 0
    Dim iCliente As Integer = 0
    Dim iDespliegue As Byte = 0

    Dim bClienteNuevo As Boolean = True
    Dim bConsignadoNuevo As Boolean = True

    Dim dtCliente, dtConsignado, dtContacto, dtDireccion, dtDireccion2, DtArticulos As DataTable
    Dim dtContactoParalelo As DataTable
    Dim bIngreso As Boolean = False
    Dim bvalidacionGrid As Boolean
    Dim iTipoEntrega As Integer
    Dim TabVenta As TabPage
    Dim iLlamada As Byte
    Dim sEmail As String = ""

    '18-11-2013 hlamas tarifa entrega a domicilio
    Dim dtTarifaServicio As DataTable
    Dim dblMontoEntregaDomicilio As Double = 0
    'hlamas 17-02-2015
    Dim dblMontoDC As Double = 0
    Dim strTipoPago As String = ""
#Region "EMISION DE LA FACTURA/BOLETA ELECTRONICA - JABANTO - 19/05/2016"
    ''' <summary>
    ''' EMISON DE LA FACTURA/BOLETA ELECTRONICA - JABANTO - 18/05/2016
    ''' </summary>
    Private Sub Emisionfe(ByVal numeroComprobante As String, ByVal dtImpresora As DataTable)
        If dtoUSUARIOS.IP = "192.168.50.47" Then
            Return
        End If

        '-->Dando formati al numero de comprobante
        Dim _numeroComprobante() As String = numeroComprobante.Split("-")
        Dim serie As String = _numeroComprobante(0)
        Dim correlativo As String = _numeroComprobante(1)

        Dim fecliente As New FECliente
        fecliente.tipoDocumentoID = iID_TipoDocCli
        fecliente.numeroDocumento = TxtNroDocCliente.Text.Trim()
        fecliente.nombres = TxtNomCliente.Text.Trim.ToUpper()
        'fecliente.direccion = IIf(CboDireccion.SelectedValue > 0, CboDireccion.Text.Trim.ToUpper(), Nothing)

        If ObjVentaCargaContado.v_direccion.Trim.Length > 0 Then
            fecliente.direccion = ObjVentaCargaContado.v_direccion.Trim
        Else
            fecliente.direccion = IIf(CboDireccion.SelectedValue > 0, CboDireccion.Text.Trim.ToUpper(), Nothing)
        End If

        Dim venta As New FEVenta
        venta.cliente = fecliente
        venta.numeroSerie = serie 'LblSerie.Text.Trim()
        venta.numeroCorrelativo = correlativo 'LblNroBoletaFact.Text.Trim()
        venta.fechaEmision = FechaServidor()
        venta.tipoComprobanteID = TipoComprobante
        venta.opGravada = TxtSubtotal.Text.Trim()
        venta.igv = TxtImpuesto.Text.Trim()
        venta.total = TxtTotal.Text.Trim()
        venta.totalLetras = ConvercionNroEnLetras(venta.total)
        venta.formaPago = CboFormaPago.Text.Trim().ToUpper()
        'hlamas 16-05-2017
        'Dim formaPagoID As Integer = Int(ObjVentaCargaContado.coll_Tipo_Pago(CboFormaPago.SelectedIndex.ToString))
        'If (formaPagoID = 5) Then '-->Cortesia
        '    venta.isCortesia = True
        'End If
        If intCortesia = 5 Then '-->Cortesia
            venta.isCortesia = True
        End If
        venta.formaPago = strTipoPago

        '-->Para la impresion
        venta.producto = CboProducto.Text.Trim
        venta.origen = LblCiudad.Text.Trim.ToUpper()
        venta.destino = TxtCiudadDestino.Text.Trim.ToUpper()
        venta.remitenete = DgvLista.CurrentRow.Cells("CLIENTE").Value
        venta.consignado = TxtNombConsignado.Text.Trim.ToUpper()
        venta.tipoEntrega = CboTipoEntrega.Text.Trim.ToUpper()
        venta.direccionEntrega = IIf(CboTipoEntrega.Text.Trim.ToUpper = "AGENCIA", Me.CboAgenciaDest.Text, CboDireccion2.Text.Trim.ToUpper)
        venta.agenciaEmision = dtoUSUARIOS.m_iNombreAgencia
        venta.usuarioEmision = dtoUSUARIOS.NameLogin
        venta.detalleVenta = FEManager.CrearDetalleVenta(GrdDetalleVenta, venta.total, ChkArticulos.Checked, ChkVolumetrico.Checked)
        venta.id = ObjVentaCargaContado.v_IDFACTURA
        venta.tabla = "T_FACTURA_CONTADO"

        'Dim result = FEManager.result
        Dim result = FEManager.sendVentaSunat(venta, dtImpresora)
        If (result.IsCorrect) Then
            Dim objFac As New ClsLbTepsa.dtoFACTURA
            objFac.actualizarEmisonFE(ObjVentaCargaContado.v_IDFACTURA, "T_FACTURA_CONTADO")
        End If
        MessageBox.Show(result.Message, "Emisión F.E.", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
#End Region
    Private Sub FrmVentaContado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    'Dim bDireccionModificada As Boolean

    'Private Property Timer2 As Object

    '********************************************************************
    Private Sub FrmVentaContado_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    End Sub

    Private Sub FrmVentaContado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        dtoUSUARIOS.m_iIdAgencia = dtoUSUARIOS.iIDAGENCIAS
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        GrdDocumentosCliente.ClearSelection()
        GrdDetalleVenta.ClearSelection()

        If TabGuia.SelectedIndex = 0 Then
            Me.BtnBuscar.Focus()
        Else
            Me.BtnGrabar.Focus()
        End If
    End Sub

    Private Sub FrmVentaContado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Dim Factor_ As Double
    Private Sub FrmVentaContado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formato()
        Inicio()

        recuperando_datos_contado = False
        ReDim objComprobanteAsegurada(19)
        bCondicion = False
        sBoleto = ""
        Me.CboDireccion.SelectedIndex = 0
        Me.CboContacto.SelectedIndex = 0
        Me.ConvertirTipoEntrega(0)
        Try
            '**********************************************************
            Me.DiseñaGrdDocumentos() '---> Diseña Grid Documentos clientes
            TipoGrid_ = FormatoGrid.BULTO '--------> Grid Bultos
            Me.DiseñaGrdDetalleVenta() '-> Diseña GridDetalleVenta
            FormatoGrdDetalleVenta() '---> Formato al grid

            bTarifarioGeneral = False
            bContado = False
            'frmb_lee = False

            '*************TIPO DE IMPRESORA****************************
            ObjVentaCargaContado = Nothing
            ObjVentaCargaContado = New dtoVentaCargaContado

            Me.LblFechaServidor.Text = dtoUSUARIOS.m_sFecha '-----------------------> Fecha Hora Servidor
            Me.TxtCiudadDestino.SelectAll()

            'Me.ListarProducto()
            Dim iOpcion As Integer = 0
            'If Acceso.SiRol(G_Rol, Me, 1, 1) Then
            '    iOpcion = 0
            'ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then
            '    iOpcion = 1
            'ElseIf Acceso.SiRol(G_Rol, Me, 1, 3) Then
            '    iOpcion = 2
            'End If
            Me.ListarProducto(iOpcion)

            '********CARGANDO LOS COMBOBOX CORRESPONDIENTES************
            If ObjVentaCargaContado.fnLoadVentaCarga1(dtoUSUARIOS.m_iIdAgencia.ToString) = True Then
                fnCargar_iWin_dt(TxtCiudadDestino, ObjVentaCargaContado.dt_cur_UNIDAD_AGENCIAS, coll_iDestino, iWinDestino, 0)
                ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_T_TARJETAS, CboTarjeta, ObjVentaCargaContado.coll_T_TARJETAS, ObjVentaCargaContado.v_IDFORMA_PAGO)
                ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_Tipo_Pago, CboFormaPago, ObjVentaCargaContado.coll_Tipo_Pago, 1)
                'ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_t_Tipo_Entrega, CboTipoEntrega, ObjVentaCargaContado.coll_t_Tipo_Entrega, 1)

                With Me.CboTipoEntrega
                    .DisplayMember = "tipo_entrega"
                    .ValueMember = "idtipo_entrega"
                    .DataSource = ObjVentaCargaContado.dt_cur_t_Tipo_Entrega
                    .SelectedValue = 0
                End With            '   

                Factor_ = ObjVentaCargaContado.VFactor_
                tipo_bole_impre = ObjVentaCargaContado.tipo_bole_impre
                tipo_factu_impre = ObjVentaCargaContado.tipo_factu_impre
                xIMPRESORA = Impresora

                Me.Text = "Canje Guía de Envío " & dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & _
                "[" & dtoUSUARIOS.m_iNombreAgencia & "] [" & dtoUSUARIOS.m_iNombreUnidadAgencia & "]"

                ' Me.Text = "VENTA CONTADO " & dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & _
                '"[" & ObjVentaCargaContado.Agencia_ & "] [" & ObjVentaCargaContado.Ciudad_ & "]"
                ' Me.LblCiudad.Text = ObjVentaCargaContado.Ciudad_ '----> Nombre Ciudad Origen
                ' Me.LblAgencia.Text = ObjVentaCargaContado.Agencia_ '--> Nombre Agencia Origen
                'Me.LblCiudad.Text = dtoUSUARIOS.m_iNombreUnidadAgencia
                'Me.LblAgencia.Text = dtoUSUARIOS.m_iNombreAgencia
            End If

            '**********************************************************
            If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, , 1) = True Then
                LblSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                LblNroBoletaFact.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                Me.BtnGrabar.Enabled = True
            Else
                MessageBox.Show("Configure Serie y Número de la Boleta de Venta.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BtnGrabar.Enabled = False
            End If
            '**********************************************************
            'xIMPRESORA = fnSeleccionImpresion()
            bFAC_Bol = False
            'frmb_lee = True

            LblTipoComprobante.Text = "BOLETA"
            RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            CboTipoTarifa.SelectedIndex = 0
            AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            CboTipoTarifa.Enabled = True

            GrdDocumentosCliente.ClearSelection()
            GrdDetalleVenta.ClearSelection()
            bvalidacionGrid = False

            Me.TabVenta = TabGuia.TabPages(1)
            Me.TabGuia.Controls.RemoveAt(1)

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********Productos (NORMAL, CARGA ACOMPAÑADA, PYME, MASIVA)*********
    Sub ListarProducto()
        Try
            Dim obj As New dtoVentaCargaContado
            Dim dt As DataTable = obj.ListarProceso()
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            Me.CboProducto.DataSource = dt
            Me.CboProducto.DisplayMember = "nombre_secundario"
            Me.CboProducto.ValueMember = "idprocesos"
            Me.CboProducto.SelectedIndex = 0
            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarProducto(ByVal opcion As Integer)
        Try
            Dim obj As New dtoVentaCargaContado
            Dim dt As DataTable = obj.ListarProceso(opcion)
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            Me.CboProducto.DataSource = dt
            Me.CboProducto.DisplayMember = "nombre_secundario"
            Me.CboProducto.ValueMember = "idprocesos"
            Me.CboProducto.SelectedIndex = 0
            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********Diseñando el grid GrdDetalleVenta**************************
    Sub DiseñaGrdDetalleVenta()
        Try
            Dim Camp1 As String = "", camp2 = "", camp3 = "", camp4 = "", camp5 = "", camp6 = "", camp7 = "", camp8 = ""
            If TipoGrid_ = FormatoGrid.BULTO Then
                Camp1 = "Tipo" : camp2 = "Bulto" : camp3 = "Peso/Volumen"
                camp4 = "Costo" : camp5 = "Sub Neto"
            ElseIf TipoGrid_ = FormatoGrid.ARTICULOS Then
                Camp1 = "Artículo" : camp2 = "Precio" : camp3 = "Cantidad"
                camp4 = "Peso" : camp5 = "T.Costo" : camp6 = "IDARTICULO"
            ElseIf TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                Camp1 = "Tipo" : camp2 = "Bulto" : camp3 = "Altura"
                camp4 = "Ancho" : camp5 = "Largo" : camp6 = "Peso Kg"
                camp7 = "Costo" : camp8 = "Sub Neto"
            End If

            With GrdDetalleVenta
                .Columns.Clear()
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AutoGenerateColumns = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Both
                .RowHeadersWidth = 20
                '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
                '.DefaultCellStyle.SelectionForeColor = Color.Black

                Dim col1 As New DataGridViewTextBoxColumn
                With col1
                    .HeaderText = Camp1
                    .Name = Camp1
                    .DataPropertyName = Camp1
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    If TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .Width = 50
                    ElseIf TipoGrid_ = FormatoGrid.ARTICULOS Then
                        .Width = 150
                    End If
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    .Visible = True
                End With
                GrdDetalleVenta.Columns.Add(col1)


                Dim col2 As New DataGridViewTextBoxColumn
                With col2
                    .HeaderText = camp2
                    .Name = camp2
                    .DataPropertyName = camp2
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    If TipoGrid_ = FormatoGrid.BULTO Or TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .ReadOnly = False
                        .MaxInputLength = 5
                    ElseIf TipoGrid_ = FormatoGrid.ARTICULOS Then
                        .ReadOnly = True
                    End If
                End With
                GrdDetalleVenta.Columns.Add(col2)


                Dim col3 As New DataGridViewTextBoxColumn
                With col3
                    .HeaderText = camp3
                    .Name = camp3
                    .DataPropertyName = camp3
                    If TipoGrid_ = FormatoGrid.BULTO Or TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 9
                    Else
                        .MaxInputLength = 5
                    End If
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = False
                End With
                GrdDetalleVenta.Columns.Add(col3)

                Dim col4 As New DataGridViewTextBoxColumn
                With col4
                    .HeaderText = camp4
                    .Name = camp4
                    .DataPropertyName = camp4
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    If TipoGrid_ = FormatoGrid.BULTO Then
                        .ReadOnly = True
                        .DefaultCellStyle.Format = "0.00"
                    ElseIf TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .ReadOnly = False
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 9
                    ElseIf TipoGrid_ = FormatoGrid.ARTICULOS Then
                        .ReadOnly = False
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 5
                    End If
                End With
                GrdDetalleVenta.Columns.Add(col4)

                Dim col5 As New DataGridViewTextBoxColumn
                With col5
                    .HeaderText = camp5
                    .Name = camp5
                    .DataPropertyName = camp5
                    .DefaultCellStyle.Format = "0.00"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    If TipoGrid_ <> FormatoGrid.VOLUMETRICO Then
                        .ReadOnly = True
                        .MaxInputLength = 9
                    End If
                End With
                GrdDetalleVenta.Columns.Add(col5)

                If TipoGrid_ = FormatoGrid.ARTICULOS Then
                    Dim col6 As New DataGridViewTextBoxColumn
                    With col6
                        .HeaderText = camp6
                        .Name = camp6
                        .DataPropertyName = camp6
                        ' .DefaultCellStyle.Format = "0.00"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .Visible = False
                    End With
                    GrdDetalleVenta.Columns.Add(col6)
                End If

                If TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                    Dim col6 As New DataGridViewTextBoxColumn
                    With col6
                        .HeaderText = camp6
                        .Name = camp6
                        .DataPropertyName = camp6
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 9
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .ReadOnly = True
                    End With
                    GrdDetalleVenta.Columns.Add(col6)

                    Dim col7 As New DataGridViewTextBoxColumn
                    With col7
                        .HeaderText = camp7
                        .Name = camp7
                        .DataPropertyName = camp7
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .ReadOnly = True
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 9
                    End With
                    GrdDetalleVenta.Columns.Add(col7)

                    Dim col8 As New DataGridViewTextBoxColumn
                    With col8
                        .HeaderText = camp8
                        .Name = camp8
                        .DataPropertyName = camp8
                        .DefaultCellStyle.Format = "0.00"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .ReadOnly = True
                        .MaxInputLength = 9
                    End With
                    GrdDetalleVenta.Columns.Add(col8)
                End If

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********Diseñando el grid GrdDocumentosCliente*********************
    Sub DiseñaGrdDocumentos()
        Try
            With GrdDocumentosCliente
                .Rows.Clear()
                .Columns.Clear()
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
                .AllowUserToOrderColumns = True
                '.BackgroundColor = SystemColors.Window
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .ReadOnly = False
                '.AutoGenerateColumns = False
                '.VirtualMode = False
                '.SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersWidth = 20
                '.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With

            Dim col_1 As New DataGridViewTextBoxColumn
            With col_1
                .DisplayIndex = 0
                .DataPropertyName = "ID1"
                .Name = "ID1"
                .HeaderText = "ID1"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With


            Dim col_2 As New DataGridViewTextBoxColumn
            With col_2
                .DisplayIndex = 1
                .DataPropertyName = "ID2"
                .Name = "ID2"
                .HeaderText = "ID2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With



            Dim col_3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            With col_3
                .DisplayIndex = 2
                .DataPropertyName = "Cargo"
                .Name = "Cargo"
                .HeaderText = "Cargo"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Mask = "###-########"
                .DefaultCellStyle.NullValue = ""
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = False
            End With


            Dim col_4 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            With col_4
                .DisplayIndex = 3
                .DataPropertyName = "Seguro"
                .Name = "Seguro"
                .HeaderText = "Seguro"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Mask = "###-########"
                .DefaultCellStyle.NullValue = ""
                .ReadOnly = True
            End With
            GrdDocumentosCliente.Columns.AddRange(col_1, col_2, col_3, col_4)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '*********Añadiendo Formato Al grid GrdDetalleVenta******************
    Sub FormatoGrdDetalleVenta()
        Try
            GrdDetalleVenta.Rows.Clear()
            If TipoGrid_ = FormatoGrid.BULTO Then
                Dim row0 As String() = {"PESO", "", "0.00", "0.00", "0.00"}
                GrdDetalleVenta.Rows().Add(row0)
                Dim row1 As String() = {"VOLUMEN", "", "0.00", "0.00", "0.00"}
                GrdDetalleVenta.Rows().Add(row1)
                Dim row2 As String() = {"SOBRE", "", "0.00", "0.00", "0.00"}
                GrdDetalleVenta.Rows().Add(row2)
                Dim row3 As String() = {"BASE", "", "0.00", "0.00", "0.00"}
                GrdDetalleVenta.Rows().Add(row3)

                GrdDocumentosCliente.Rows.Clear()
                Dim row11 As String() = {"", " ", " ", ""}
                GrdDocumentosCliente.Rows().Add(row11)
                GrdDocumentosCliente.Rows().Add(row11)
                GrdDocumentosCliente.Rows().Add(row11)
            Else
                Dim row0 As String() = {"1", "", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00"}
                GrdDetalleVenta.Rows().Add(row0)
            End If

            TxtSubtotal.Text = "0.00"
            TxtImpuesto.Text = "0.00"
            TxtTotal.Text = "0.00"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "PAGE_VENTA"

#Region "PRODUCTO"

    Sub RefreshNroDocumento(ByVal Producto_ As Integer)
        If iOpcion = 2 Then Return
        If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, Producto_, 1) = True Then
            '*********Quitar Error*************************************  
            LblSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
            LblNroBoletaFact.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
        End If
    End Sub

    Private Sub CboProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboProducto.SelectedIndexChanged
        Try
            If iOpcion = 2 Then
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                Me.CboProducto.SelectedValue = iProceso
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                Return
            End If
            RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            RemoveHandler TxtBoleto.TextChanged, AddressOf TxtBoleto_TextChanged
            Me.CboTipoEntrega.SelectedValue = 0
            sDocCliente = ""
            bClienteModificado = False
            bDireccionModificada = False
            bContactoModificado = False
            bConsignadoModificado = False
            bDirecConsigMod = False

            bConsignadoNuevo = True
            bClienteNuevo = True
            sNombresCli = "" : sApCli = "" : sAmCli = "" : sTelfCliente = "" : sCliente = ""
            Me.LimpiarCliente()

            If CboProducto.SelectedValue = 0 Then '--------------------------------> [NORMAL]
                Me.RefreshNroDocumento(0)
                objGuiaEnvio.TarifaPyme_ = False
                objGuiaEnvio.TarifaMasiva_ = False
                Me.bBoleto = False '-->"N" Base <> 0
                Me.LimpiarDatosGeneral() '-->limpiar datos general
                Me.Grpa.Visible = False
                LblPasajero.Visible = False
                '******TRAERA TARIFA PUBLICA******************              
                bTieneLineaCredito = False
                bDescuento = False
                If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1
                If idUnidadAgencias <> -1 Then
                    Me.fnTarifario()
                Else
                    iOficinaDestino = 0 '--> si repite la Ciudad omitir
                End If
            ElseIf CboProducto.SelectedValue = 6 Then '----------------------------> [CARGA ACOMPAÑADA]  
                Me.RefreshNroDocumento(0)
                objGuiaEnvio.TarifaPyme_ = False
                objGuiaEnvio.TarifaMasiva_ = False
                '**FORMATO PARA CARGA ACOMPAÑADA****          
                Me.LimpiarDatosGeneral()
                Me.TxtCiudadDestino.Enabled = False
                Me.CboAgenciaDest.Items.Clear()
                Me.TxtCiudadDestino.Text = ""
                'Me.Grpa.Text = "Carga Acompañada"
                Me.Grpa.Visible = True
                Me.TxtBoleto.Visible = True
                Me.bBoleto = True '-->"Y" Base = 0
                Me.TxtBoleto.Focus()
                '*********************************
                Me.TipoGrid_ = FormatoGrid.BULTO
                Me.DiseñaGrdDetalleVenta()
                Me.FormatoGrdDetalleVenta()
                '*********************************
            ElseIf CboProducto.SelectedValue = 7 Then '----------------------------> [PYME]
                objGuiaEnvio.TarifaMasiva_ = False
                Me.RefreshNroDocumento(7)
                Me.bBoleto = False '-->"N" Base <> 0
                Me.LimpiarDatosGeneral()
                Me.Grpa.Visible = False
                '***********TARIFA PYME*********               
                bTieneLineaCredito = False
                bDescuento = False
                If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1
                If idUnidadAgencias <> -1 Then
                    objGuiaEnvio.TarifaPyme_ = True
                    Me.fnTarifario()
                Else
                    iOficinaDestino = 0 '--> si repite la Ciudad omitir
                End If
                LblPasajero.Visible = False
                '*******************************
            ElseIf CboProducto.SelectedValue = 8 Then '----------------------------> MASIVA 
                Me.RefreshNroDocumento(8)
                objGuiaEnvio.TarifaPyme_ = False
                Me.bBoleto = False '-->"N" Base <> 0
                Me.LimpiarDatosGeneral()

                Me.Grpa.Visible = False
                Me.TxtBoleto.Visible = False

                '*******TARIFA MASIVA*******
                objGuiaEnvio.TarifaMasiva_ = True
                bTieneLineaCredito = False
                bDescuento = False

                If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1
                If idUnidadAgencias <> -1 Then
                    Me.fnTarifario()
                Else
                    iOficinaDestino = 0
                End If
                LblPasajero.Visible = False
                '***********************************
            ElseIf CboProducto.SelectedValue = 10 Then '--------------------------------> [NORMAL]
                Me.RefreshNroDocumento(0)
                objGuiaEnvio.TarifaPyme_ = False
                objGuiaEnvio.TarifaMasiva_ = False
                Me.bBoleto = False '-->"N" Base <> 0
                Me.LimpiarDatosGeneral() '-->limpiar datos general
                Me.Grpa.Visible = False
                LblPasajero.Visible = False
                '******TRAERA TARIFA PUBLICA******************              
                bTieneLineaCredito = False
                bDescuento = False
                If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1
                If idUnidadAgencias <> -1 Then
                    Me.fnTarifario()
                Else
                    iOficinaDestino = 0 '--> si repite la Ciudad omitir
                End If
            End If
            AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            AddHandler TxtBoleto.TextChanged, AddressOf TxtBoleto_TextChanged

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub LimpiarDatosGeneral()
        Me.TxtCliente.Text = ""
        Me.TxtConsignado.Text = ""
        Me.TxtNombConsignado.Text = ""
        Me.TxtBoleto.Text = ""
        Me.TxtCiudadDestino.Enabled = True
        Me.TxtCiudadDestino.ReadOnly = False
        Me.LimpiarDatosCliente()
    End Sub

#End Region 'OK

#Region "SELECCION ESTANDAR O 24 HORAS"
    Private Sub CboTipoTarifa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoTarifa.SelectedIndexChanged
        Try
            If iOpcion = 2 Then
                RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
                Me.CboTipoTarifa.SelectedValue = iTarifa
                AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
                Return
            End If

            If ChkArticulos.Checked = True Then
                ChkArticulos.Checked = False
            End If

            If CboTipoTarifa.SelectedIndex = 1 Then
                bTieneLineaCredito = False
                bDescuento = False
            End If

            Me.RemoveItemsCargAseg()
            objGuiaEnvio.TarifaPyme_ = IIf(CboProducto.SelectedValue = 7, 1, 0)
            '***********LISTARA TARIFA PUBLICA O CREDITO**********
            If CboProducto.SelectedValue <> 6 AndAlso Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso ObjVentaCargaContado.dt_cur_persona.Rows.Count > 0 Then
                Me.Consulta() '--> si el cliente tiene linea de credito, Descuento, Normal o tiene Articulos
            Else
                If bTieneLineaCredito Then bTieneLineaCredito = False
                If bDescuento Then bDescuento = False
            End If

            Me.ResetCalculo()
            If CboProducto.SelectedValue = 8 Then objGuiaEnvio.TarifaMasiva_ = True
            Me.fnTarifario()
            GrdDetalleVenta("Costo", 0).Value = Format(tarifa_Peso, "0.00")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region 'OK

#Region "CARGA ACOMPAÑADA ----> BOLETO"

    Dim cnn As OdbcConnection '-> Conexion Mysql
    Dim bEntra As Boolean = False
    Dim bBoleto As Boolean = False

    Dim sBoleto As String = ""
    Private Sub TxtBoleto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBoleto.LostFocus
        Try
            Me.Cursor = Cursors.AppStarting
            '*************************************
            objGuiaEnvio.TarifaPyme_ = False
            '*************************************

            sDocCliente = ""
            bDescuento = False
            bTieneLineaCredito = False

            If Me.TxtBoleto.ReadOnly Or Me.TxtBoleto.Text.Trim.Length <= 1 Then
                Me.Cursor = Cursors.Default
                Return
            End If
            If Me.LblTipoComprobante.Text.Substring(0, 1) <> "G" Then
                bCargaAcompañada = False
            End If
            'coneccion a athenea (vyr)
            cnn = New Odbc.OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};SERVER=192.168.200.241;DATABASE=Tepsa;UID=ventas;PWD=10913035110;OPTION=18475")

            Dim sDoc As String = Me.TxtBoleto.Text.Trim
            Dim iPos As Integer = sDoc.IndexOf("-")
            Dim sIzquierda As String = sDoc.Substring(0, iPos).Trim.PadLeft(3, "0")
            Dim sDerecha As String = sDoc.Substring(iPos + 1).Trim.PadLeft(7, "0")
            sDoc = sIzquierda & "-" & sDerecha
            Me.TxtBoleto.Text = sDoc

            Dim sql As String
            sql = "SELECT V.idVenta ID, V.NroBoleto NUMBOLETO, "
            sql = sql & "LEFT(V.FechaPartida,10) FECHAPARTIDA, LEFT(V.HoraPartida, 8) HORAPARTIDA, "
            sql = sql & "P.NroDocumento nrodocumento,P.NroDocumento nu_docu_suna, upper(P.ApellidoPaterno) apepat, "
            sql = sql & "UPPER(P.ApellidoMaterno) apemat, "
            sql = sql & "UPPER(P.Nombres) NOMBRES,UPPER(P.Nombres) NOMBRE,UPPER(P.Nombres) razon_social, V.NroAsiento, upper(R.LocalidadOrigen) ORIGEN, "
            sql = sql & "UPPER(R.LocalidadDestino) DESTINO, "
            sql = sql & "if(V.TipoOperacion='', 'V', 'A') VENTA, V.idPasajero IDPASAJERO, P.PasajeroFrecuente, "
            sql = sql & "codCiudadOrigen,P.idtipodocumento tipo, P.telefono "
            sql = sql & "FROM VtaPasajes V "
            sql = sql & "INNER JOIN Clientes P ON (V.idPasajero = P.idCliente) "
            sql = sql & "INNER JOIN Rutas R ON (V.idRuta = R.idRuta) "
            sql = sql & "WHERE V.NroBoleto='" & sDoc & "' "
            Dim dt As DataTable = ObtieneDT(sql)
            CargarBoleto(dt)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            bBoleto = False
            Controla(True)
            bCargaAcompañada = False
            Me.TxtCiudadDestino.ReadOnly = False
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarBoleto(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            'If sBoleto = TxtBoleto.Text.Trim Then
            '    Return
            'End If

            sBoleto = TxtBoleto.Text.Trim
            Dim sql As String
            'verifica si boleto está asociado a algun documento (guia,boleta,factura)
            Dim dt2 As DataTable
            If Not BoletoAsociado(sBoleto, dt2) Then
                Dim iEstado As Integer = IIf(dt.Rows(0).Item("venta") = "V", 1, 0)
                If iEstado = 1 Then
                    bTecla = False
                    bBoleto = True
                    Controla(False)

                    Me.TxtCiudadDestino.ReadOnly = True
                    Dim iPasajeroFrecuente As Integer = dt.Rows(0).Item("PasajeroFrecuente")
                    If iPasajeroFrecuente = 1 Then
                        'verifica si pasajero frecuente esta activo
                        Dim iPasajero As Integer = dt.Rows(0).Item("idpasajero")
                        sql = "SELECT idPasajeroFrecuente, Estado FROM PasajeroFrecuente WHERE idCliente=" & iPasajero & " "
                        Dim dt1 As DataTable = ObtieneDT(sql)
                        If dt1.Rows.Count > 0 Then
                            iPasajeroFrecuente = IIf(dt1.Rows(0).Item("estado") = "A", 1, 0)
                        End If
                    End If
                    LblPasajero.Visible = True
                    Me.LblPasajero.Text = IIf(iPasajeroFrecuente = 1, "FRECUENTE", "NORMAL")

                    Dim sender1 As New Object
                    Dim ee As New System.ComponentModel.CancelEventArgs
                    'TxtNroDocCliente_LostFocus(sender1, ee) '_Validating
                    bBoleto = True
                    'oracle
                    Dim db As New BaseDatos
                    db.Conectar()

                    'validaciones
                    Dim sOrigen As String = dt.Rows(0).Item("origen").ToString.Trim     'origen boleto
                    Dim sDestino As String = dt.Rows(0).Item("destino").ToString.Trim   'destino boleto
                    Dim iOri As Integer  'origen guia
                    Dim iDes As Integer  'destino guia

                    sql = "select PKG_IVOCARGA_ACOMPANADA.sf_ciudad_id('" & sOrigen & "') from dual"
                    db.CrearComando(sql, CommandType.Text)
                    iOri = db.EjecutarEscalar

                    sql = "select PKG_CARGA_ACOMPANADA.sf_ciudad_id('" & sDestino & "') from dual"
                    db.CrearComando(sql, CommandType.Text)
                    iDes = db.EjecutarEscalar

                    If ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = 0 Then
                        ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                    End If
                    If ObjVentaCargaContado.v_IDAGENCIAS = 0 Then
                        ObjVentaCargaContado.v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                    End If

                    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Then
                        If iOri <> ObjVentaCargaContado.v_IDUNIDAD_ORIGEN Then
                            'Origen de guia no coincide con boleto
                            MessageBox.Show("El Orígen del Boleto no coincide con la Guía.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            bCargaAcompañada = False
                            TxtBoleto.Text = ""
                            Return
                        End If

                        If iDes <> ObjVentaCargaContado.v_IDUNIDAD_DESTINO Then
                            'Destino de guia no coincide con boleto
                            MessageBox.Show("El Destino del Boleto no coincide con la Guía.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            bCargaAcompañada = False
                            TxtBoleto.Text = ""
                            Return
                        End If
                    Else    'comprobante de pago
                        'If (iOri <> ObjVentaCargaContado.v_IDUNIDAD_ORIGEN) And (iDes <> ObjVentaCargaContado.v_IDUNIDAD_ORIGEN) Then
                        '    'unidad destino del boleto es diferente a la unidad destino del comprobante
                        '    MessageBox.Show("La Ciudad Orígen de la Venta no coincide con el Orígen o Destino del Boleto.", "Titán", MessageBoxButtons.OK)
                        '    bCargaAcompañada = False
                        '    TxtBoleto.Text = ""
                        '    Return
                        'End If
                        If iOri <> ObjVentaCargaContado.v_IDUNIDAD_ORIGEN Then
                            'unidad origen del boleto es diferente a la unidad origen del cpu
                            Dim resp As DialogResult = MessageBox.Show("La Ciudad Orígen del boleto no coincide con la Venta." & ControlChars.CrLf & "¿Desea Continuar?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If resp = Windows.Forms.DialogResult.No Then
                                bCargaAcompañada = False
                                TxtBoleto.Text = ""
                                Return
                            Else
                                bOrigenDiferente = True
                            End If
                        End If
                    End If

                    ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = iOri
                    objGuiaEnvio.iIDUNIDAD_AGENCIA = iOri

                    Dim sAgenciaBoleto = dt.Rows(0).Item("codCiudadOrigen")
                    sql = "select PKG_IVOCARGA_ACOMPANADA.sf_agencia_id(" & iOri & ",'" & sAgenciaBoleto & "') from dual"
                    db.CrearComando(sql, CommandType.Text)
                    Dim iAgencia As Integer = db.EjecutarEscalar

                    ObjVentaCargaContado.v_IDAGENCIAS = iAgencia
                    objGuiaEnvio.iIDAGENCIAS = iAgencia

                    TxtCiudadDestino.Text = sDestino
                    bCargaAcompañada = True
                    bCargaAcompañada2 = True

                    iOficinaDestino = 0

                    'If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE <> 85 Then
                    Dim sender As Object
                    Dim e As New System.ComponentModel.CancelEventArgs
                    TxtCiudadDestino_LostFocus(sender, e) '-> obteniendo la ciudad destino del Boleto 
                    'End If

                    'Actualizar
                    If dt.Rows(0).Item("nrodocumento").ToString.Trim.Length > 0 Then
                        TxtNroDocCliente.Text = dt.Rows(0).Item("nrodocumento")
                        TxtNroDocCliente.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                    ElseIf dt.Rows(0).Item("nrodocumento").ToString.Trim.Length = 0 Then
                        TxtNroDocCliente.Text = dt.Rows(0).Item("nrodocumento")
                        TxtNroDocCliente.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                    End If

                    Dim sNombres As String = dt.Rows(0).Item("apepat").ToString.Trim & " " & dt.Rows(0).Item("apemat").ToString.Trim & " " & dt.Rows(0).Item("nombres").ToString.Trim
                    TxtNomCliente.Text = sNombres
                    TxtNomCliente.Tag = dt.Rows(0).Item("apepat").ToString.Trim & "*" & dt.Rows(0).Item("apemat").ToString.Trim

                    TxtNroDocConsignado.Text = dt.Rows(0).Item("nrodocumento").ToString.Trim
                    'TxtNroDocConsignado.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                    TxtNombConsignado.Text = sNombres
                    TxtTelfCliente.Text = IIf(IsDBNull(dt.Rows(0).Item("telefono")), "", dt.Rows(0).Item("telefono"))

                    '****gnr**************                          
                    dtCliente = dt.Copy
                    dtConsignado = dt.Copy
                    'iTipoDoc = Me.ObtieneTipoDocumento(dtCliente.Rows(0).Item("tipo"))
                    '*********************
                    ' TxtTelfCliente.Text = IIf(IsDBNull(dt.Rows(0).Item("telefono")), "", dt.Rows(0).Item("telefono"))
                    Me.Buscar(1)
                    iIDConsignado = 0
                    'Me.TxtNroDocConsignado.Tag = 0
                    bConsignadoNuevo = True
                    bConsignadoModificado = False
                    iID_TipoDocConsig = TxtNroDocCliente.Tag
                    sNombresCli = dt.Rows(0).Item("nombres").ToString.Trim
                    sNombresConsig = dt.Rows(0).Item("nombres").ToString.Trim
                    sapellPatConsig = dt.Rows(0).Item("apepat").ToString.Trim
                    sapellMatConsig = dt.Rows(0).Item("apemat").ToString.Trim
                    sTelefonoConsig = TxtTelfCliente.Text
                    If TxtNroDocConsignado.Text.Trim.Length = 0 Then
                        iID_TipoDocConsig = 9
                        iID_TipoDocCli = 9
                    End If

                    bEntra = True
                Else    'anulado
                    MessageBox.Show("El Boleto de Viaje está anulado", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bBoleto = False
                    'Me.LblBoleto.Text = ""
                    'Me.LblBoleto.Visible = False
                    'Me.lblCarga.Text = "-->CARGA ASEGURADA"
                    'Me.lblCarga.Visible = False
                    Controla(True)
                    Me.TxtCiudadDestino.ReadOnly = False
                    Me.TxtBoleto.Focus()
                End If
                Me.BtnGrabar.Focus()
            Else
                Dim s As String = ""
                For i As Integer = 0 To dt2.Rows.Count - 1
                    s = s & dt2.Rows(i).Item(0) & " " & dt2.Rows(i).Item(1) & Chr(13)
                Next
                MessageBox.Show("El Boleto " & sBoleto & " está asociado a:" & Chr(13) & Chr(13) & s, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bBoleto = False
                'Me.LblBoleto.Text = ""
                'Me.LblBoleto.Visible = False
                'Me.lblCarga.Text = "-->CARGA ASEGURADA"
                'Me.lblCarga.Visible = False
                Controla(True)
                Me.TxtCiudadDestino.ReadOnly = False
                Me.TxtBoleto.Text = ""
                Me.TxtBoleto.Focus()
            End If
        Else

            MessageBox.Show("El Boleto " & Me.TxtBoleto.Text.Trim & " no existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bBoleto = False
            Me.TxtCiudadDestino.ReadOnly = False
            Controla(True)
            Me.TxtBoleto.Text = ""
            Me.TxtBoleto.Focus()
        End If
    End Sub

    Function BoletoAsociado(ByVal boleto As String, ByRef dt As DataTable) As Boolean
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCARGA_ACOMPANADA.sp_boleto_asociado", CommandType.StoredProcedure)
            db.AsignarParametro("vi_boleto", boleto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            dt = db.EjecutarDataTable
            If dt.Rows.Count = 0 Then
                Return False
            Else
                If IsDBNull(dt.Rows(0).Item(0)) Then
                    Return False
                Else
                    Return True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ObtieneDT(ByVal sql As String) As DataTable
        Dim cmd As New OdbcCommand
        cmd.CommandText = sql
        cmd.CommandType = CommandType.Text
        cmd.Connection = cnn
        Dim da As New OdbcDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        Return dt
    End Function

    Sub Controla(ByVal estado As Boolean)
        Me.ChkArticulos.Enabled = estado
    End Sub

    Private Sub TxtBoleto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBoleto.TextChanged
        bCargaAcompañada2 = False
        sBoleto = ""
        iOficinaDestino = 0
        'Controla(True)
        bIngresa = True
        'flagPCEVALIDADOC = True
        fnVALIDARDOCUMENTOS()
        bIngresa = False
        'flagPCEVALIDADOC = False
    End Sub

#End Region 'OK

#Region "DESTINO" '--> OK

    Dim iOficinaDestino As Integer
    Dim CodCiudadDest_ As Integer

    Private Sub TxtCiudadDestino_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCiudadDestino.Enter
        Me.TxtCiudadDestino.SelectAll()
    End Sub

    Sub RemoveItemsCargAseg()
        If es_carga_asegurada Then
            objComprobanteAsegurada = Nothing
            ReDim objComprobanteAsegurada(19)
            es_carga_asegurada = False
        End If
    End Sub

    Private Sub TxtCiudadDestino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCiudadDestino.KeyPress
        If Not Me.ValidaTexto(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

#End Region 'OK

#Region "CONDICION DE LA VENTA"

    'SELECCION TIPO DE ENTREGA (AGENCIA, DOMICILIO)
    Dim bValidaEntrega As Boolean = False
    Private Sub CboTipoEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoEntrega.SelectedIndexChanged
        Try
            If iOpcion = 2 Then
                'RemoveHandler CboTipoEntrega.SelectedIndexChanged, AddressOf CboTipoEntrega_SelectedIndexChanged
                Me.CboTipoEntrega.SelectedValue = iTipoEntrega
                'AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoEntrega_SelectedIndexChanged
                Return
            End If

            'Dim iidTipo As Integer = ObjVentaCargaContado.coll_t_Tipo_Entrega(CboTipoEntrega.SelectedIndex.ToString)
            Dim iidTipo As Integer = CboTipoEntrega.SelectedValue
            Me.ConvertirTipoEntrega(CboTipoEntrega.SelectedValue)

            If CboProducto.SelectedValue = 6 Then Me.ResetCalculo()
            If CboProducto.SelectedValue = 6 And iidTipo = 1 Then '------> Tipo Entrega [Agencia] No Incluye Base
                GrdDetalleVenta(3, 3).Value = "0.00"
                GrdDetalleVenta(4, 3).Value = "0.00"
                Me.Monto_Base = 0.0
                Me.TxtReferencia.Text = ""
            ElseIf CboProducto.SelectedValue = 6 And iidTipo = 2 Then '--> Tipo Entrega [Agencia] Si Icluye Base
                GrdDetalleVenta(3, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                GrdDetalleVenta(4, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                Me.Monto_Base = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'SELECCION FORMA DE PAGO (EFECTIVO, TARJETA, CORTESIA)
    Dim varIdCondicion As Integer = 0
    Private Sub CboFormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboFormaPago.SelectedIndexChanged
        Try
            If iOpcion = 2 Then
                RemoveHandler CboFormaPago.SelectedIndexChanged, AddressOf CboFormaPago_SelectedIndexChanged
                Me.CboFormaPago.SelectedValue = ObjVentaCargaContado.v_IDTIPO_PAGO
                AddHandler CboFormaPago.SelectedIndexChanged, AddressOf CboFormaPago_SelectedIndexChanged
                Return
            End If

            varIdCondicion = Int(ObjVentaCargaContado.coll_Tipo_Pago.Item(CboFormaPago.SelectedIndex.ToString))
            If CboFormaPago.SelectedIndex = 0 Then
                '"EFECTIVO"                  
                CboTarjeta.Enabled = False
                TxtNroTarjeta.Enabled = False
                '
                TxtDescuento.Enabled = True
                GrpDescuento.Enabled = True
                Grpa.Enabled = True
                CboTarjeta.SelectedIndex = -1
                TxtNroTarjeta.Text = ""
            ElseIf CboFormaPago.SelectedIndex = 1 Then
                '"TARJETA"                                              
                CboTarjeta.Enabled = True
                TxtNroTarjeta.Enabled = True
                TxtNroTarjeta.Text = ""
                '
                TxtDescuento.Enabled = True
                GrpDescuento.Enabled = True
                Grpa.Enabled = True
                CboTarjeta.SelectedIndex = 0
            Else
                '"CORTESIA"
                CboTarjeta.Enabled = False
                TxtNroTarjeta.Enabled = False
                '
                TxtDescuento.Enabled = False
                GrpDescuento.Enabled = False
                'Grpa.Enabled = False
                CboTarjeta.SelectedIndex = -1
                TxtNroTarjeta.Text = ""
            End If

            'If frmb_lee = True Then
            If CboTarjeta.Visible = True Then
                Me.CboTarjeta.Focus()
            Else
                Me.TxtNroDocCliente.Focus()
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'SELECCION TARJETA (VISA, MASTER CARD)
    Private Sub CboTarjeta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTarjeta.SelectedIndexChanged
        If iOpcion = 2 Then
            RemoveHandler CboTarjeta.SelectedIndexChanged, AddressOf CboTarjeta_SelectedIndexChanged
            Me.CboTarjeta.SelectedValue = ObjVentaCargaContado.v_IDTARJETAS
            AddHandler CboTarjeta.SelectedIndexChanged, AddressOf CboTarjeta_SelectedIndexChanged
            Return
        End If
        'If frmb_lee = True Then
        If TxtNroTarjeta.Visible = True Then
            Me.TxtNroTarjeta.Focus()
        Else
            Me.TxtNroDocCliente.Focus()
        End If
        'End If
    End Sub

    Private Sub TxtNroTarjeta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroTarjeta.KeyPress
        If Not Me.ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True : TxtNroDocCliente.Focus()
        End If
    End Sub
#End Region 'OK

#Region "CLIENTE"

    Dim sDocCliente As String = ""
    'Dim bBoleto As Boolean = False
    'Dim flagPCE As Boolean = False
    'Dim flagPCEVALIDADOC As Boolean = False
    Dim bIngresa As Boolean
    Dim iForma As Integer = 0
    Dim s_persona_remitente As String = ""
    Dim bCargaAcompañada As Boolean = False
    Dim CONTROL As Integer = 1

    Dim Valida_ As Boolean
    'Private Sub TxtNroDocCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
    '    If CboProducto.SelectedValue <> 6 Then
    '        If FnExisteCliente() = False Then
    '            Valida_ = False
    '            Grpa.Visible = False
    '            Me.LimpiarDatosCliente()
    '            Me.RefreshNroDocumento(0)
    '            '**************************************             
    '            TarifaPublica_ = True
    '            bTieneLineaCredito = False
    '            bDescuento = False
    '            If CboProducto.SelectedValue = 7 Then CboProducto.SelectedValue = 0
    '            fnTarifario()
    '            '**************************************
    '            If CboProducto.SelectedValue <> 6 Then
    '                TxtCiudadDestino.ReadOnly = False
    '                TxtCiudadDestino.Enabled = True
    '            End If

    '            If fnVALIDARDOCUMENTOS2() Then
    '                Valida_ = True
    '            End If
    '        Else
    '            Valida_ = True
    '            sDocCliente = ""
    '            If CboProducto.SelectedValue <> 6 Then
    '                TxtCiudadDestino.ReadOnly = False
    '                TxtCiudadDestino.Enabled = True
    '            End If
    '        End If
    '    Else
    '        Valida_ = True
    '        sDocCliente = ""
    '    End If
    '    AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
    'End Sub

    '***********FUNCIONES******************************************
    'TARIFA PUBLICA EN MEMORIA
    Sub ListaTarifaPublicaMemoria()
        If idUnidadAgencias <> -1 Then
            GrdDetalleVenta(3, 0).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Peso, "0.00")
            GrdDetalleVenta(3, 1).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Volumen, "0.00")
            GrdDetalleVenta(3, 2).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal, "0.00")
            GrdDetalleVenta(3, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
            GrdDetalleVenta(4, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
        End If
    End Sub

    'EXISTE EL CLIENTE 
    Private Function FnExisteCliente() As Boolean
        If ObjVentaCargaContado.BuscarCliente(1, Me.TxtNroDocCliente.Text, dtoUSUARIOS.m_idciudad.ToString, idUnidadAgencias, Me.CboProducto.SelectedValue) = True Then
            ObjVentaCargaContado.v_IDPERSONA = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
            If ObjVentaCargaContado.v_IDPERSONA = 0 Then
                Return False
            Else
                Return True
            End If
        End If
    End Function 'Func 1

    'SI TIENE ARTICULOS,DESCUENTO, LINEA DE CREDITO
    Sub Consulta()
        Try
            'If ObjVentaCargaContado.BuscarCliente(1, Me.TxtNroDocCliente.Text, dtoUSUARIOS.m_idciudad.ToString, idUnidadAgencias) = True Then
            Me.DtArticulos = ObjVentaCargaContado.dt_cur_Articulos.Copy
            'If CboTipoTarifa.Text <> "24 HORAS" Then
            Iid = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
            '****************************************************************************************
            If Iid > 0 Then
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                '**************************TIPO DE CLIENTE [Normal, PYME]****************************
                Dim iProceso As Integer = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(7)
                If iProceso = 0 Then '------> Normal
                    objGuiaEnvio.TarifaPyme_ = False
                    If CboProducto.SelectedValue = 6 Then
                        Me.CboProducto.SelectedValue = 6
                    ElseIf CboProducto.SelectedValue = 8 And bTieneLineaCredito = False Then
                        Me.CboProducto.SelectedValue = 8
                    Else
                        Me.CboProducto.SelectedValue = iProceso
                    End If
                ElseIf iProceso = 7 Then '--> Pyme  
                    Me.CboProducto.SelectedValue = iProceso
                    ' Me.TxtTelfConsignado.Focus()
                    Me.objGuiaEnvio.TarifaPyme_ = True '--> indica q traera tarifa Pyme                                      
                ElseIf iProceso = 8 Then '--> Masiva
                    objGuiaEnvio.TarifaPyme_ = False
                    Me.CboProducto.SelectedValue = iProceso
                    objGuiaEnvio.TarifaMasiva_ = True
                End If
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                '**************************CLIENTE TIENE DESCUENTO***********************************
                iDescuento = IIf(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(4) <> 0, ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(4), 0)
                If iDescuento <> 0 Then
                    iDescuento = iDescuento / 100
                    bDescuento = True
                Else
                    bDescuento = False
                End If
            Else
                bDescuento = False
                ChkArticulos.Enabled = False : ChkArticulos.Checked = False
            End If
            'Else
            'bTieneLineaCredito = False
            'bDescuento = False
            'End If
            'End If

            If Iid > 0 Then
                '****************CLIENTE TIENE [ARTICULOS]*******************************
                If DtArticulos.Rows.Count > 0 Then
                    ChkArticulos.Enabled = True
                Else
                    ChkArticulos.Enabled = False : ChkArticulos.Checked = False
                End If
            Else
                ChkArticulos.Enabled = False : ChkArticulos.Checked = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '**************************************************************
    Private Sub limpiar_documentos_cliente()
        For i As Integer = 0 To 19
            objComprobanteAsegurada(i).FECHA = Nothing
            objComprobanteAsegurada(i).FECHA_ACTUALIZACION = Nothing
            objComprobanteAsegurada(i).FECHA_REGISTRO = Nothing
            objComprobanteAsegurada(i).ID_GUIAS_ENVIO_DOC = Nothing
            objComprobanteAsegurada(i).IDESTADO_REGISTRO = Nothing
            objComprobanteAsegurada(i).IDGUIAS_ENVIO = Nothing
            objComprobanteAsegurada(i).IDROL_USUARIO = Nothing
            objComprobanteAsegurada(i).IDROL_USUARIOMOD = Nothing
            objComprobanteAsegurada(i).IDTIPO_COMPROBANTE = Nothing
            objComprobanteAsegurada(i).IDTIPO_MONEDA = Nothing
            objComprobanteAsegurada(i).IDUSUARIO_PERSONAL = Nothing
            objComprobanteAsegurada(i).IDUSUARIO_PERSONALMOD = Nothing
            objComprobanteAsegurada(i).IP = Nothing
            objComprobanteAsegurada(i).IPMOD = Nothing
            objComprobanteAsegurada(i).MONTO_BASE = Nothing
            objComprobanteAsegurada(i).MONTO_IMPUESTO = Nothing
            objComprobanteAsegurada(i).MONTO_SUB_TOTAL = Nothing
            objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO = Nothing
            objComprobanteAsegurada(i).NRO_DOCU = Nothing
            objComprobanteAsegurada(i).NRO_SERIE = Nothing
            objComprobanteAsegurada(i).OBS = Nothing
            objComprobanteAsegurada(i).PORCEN = Nothing
            objComprobanteAsegurada(i).PORCEN_IMPUESTO = Nothing
            objComprobanteAsegurada(i).TOTAL_COSTO = Nothing
            objComprobanteAsegurada(i).PROCEDENCIA = Nothing
        Next
        es_carga_asegurada = False
        recuperando_datos_contado = False
        'Label5.Visible = False
    End Sub 'func 1

    Private Sub ObtieneMontosAsegurados(ByRef s As Double, ByRef i As Double, ByRef t As Double)
        s = 0
        i = 0
        t = 0
        For Each obj As ClsLbTepsa.dtoCargaAsegurada.ComprobanteAsegurada In objComprobanteAsegurada
            'If Not objComprobanteAsegurada(i).NRO_DOCU Is Nothing Then
            If Not obj.NRO_DOCU Is Nothing Then
                If obj.TIPO = 1 Or obj.TIPO = 0 Then
                    s += obj.MONTO_SUB_TOTAL * obj.MONTO_TIPO_CAMBIO * obj.PORCEN / 100
                    i += obj.MONTO_IMPUESTO * obj.MONTO_TIPO_CAMBIO * obj.PORCEN / 100
                    t += obj.TOTAL_COSTO * obj.MONTO_TIPO_CAMBIO * obj.PORCEN / 100
                Else
                    s += obj.PORCEN / (1 + dtoUSUARIOS.iIGV / 100)
                    Dim iSub As Double = obj.PORCEN / (1 + dtoUSUARIOS.iIGV / 100)
                    i += iSub * (dtoUSUARIOS.iIGV / 100)
                    t += obj.PORCEN
                End If
            End If
        Next
    End Sub

    Private Function fnVALIDARDOCUMENTOS() As Boolean
        Try
            If TxtNroDocCliente.Text.Length = 11 Then
                If fnValidarRUC(TxtNroDocCliente.Text.ToString) Then

                    '*********Quitar Error*************************************                                    
                    If iOpcion <> 2 Then
                        Me.LblTipoComprobante.Text = "FACTURA"
                    End If
                    bFAC_Bol = True
                    TipoComprobante = 1
                    If CboProducto.SelectedValue <> 6 Then '--->Diferente De Carga Acompañada (para mantener la tarifa de carga acompañada)               
                        'fnTarifario()
                        If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, CboProducto.SelectedValue, 1) = True Then
                            '*********Quitar Error*************************************  
                            If iOpcion = 2 Then Return True
                            LblSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            LblNroBoletaFact.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                            'GrpContacto.Enabled = True
                            Return True
                        ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0, 1) = True Then
                            If iOpcion = 2 Then Return True
                            LblSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            LblNroBoletaFact.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                            'GrpContacto.Enabled = True
                            Return True
                        Else
                            '*********Añadir Error*************************************  
                            ' GrpContacto.Enabled = True
                            Return False
                        End If
                    Else
                        'If CboProducto.SelectedValue <> 6 Then
                        If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, CboProducto.SelectedValue, 1) = True Then
                            '*********Quitar Error*************************************  
                            LblSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            LblNroBoletaFact.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                            Return False
                        ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0, 1) = True Then
                            LblSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            LblNroBoletaFact.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                            Return False
                        End If
                        Return False
                        'End If
                    End If
                Else
                    '*********Añadir Error*************************************                  
                    Me.LimpiarDatosCliente()
                    '**********************************************************
                    If iOpcion <> 2 Then
                        LblTipoComprobante.Text = "BOLETA"
                    End If

                    bFAC_Bol = False
                    TxtNroDocCliente.SelectAll()
                    TxtNroDocCliente.Focus()
                    TipoComprobante = 1
                    Return False
                End If
            ElseIf TxtNroDocCliente.Text.Length = 8 Or bIngresa Then
                If CboProducto.SelectedValue <> 6 Then
                    'If flagPCEVALIDADOC = False Then
                    'fnTarifario()
                    'End If
                End If
                Dim vals As String = TxtNroDocCliente.Text
                If iOpcion <> 2 Then
                    LblTipoComprobante.Text = "BOLETA"
                End If

                TxtNroDocContacto.Text = ""

                bFAC_Bol = False
                TipoComprobante = 2

                If iOpcion <> 2 Then
                    If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, CboProducto.SelectedValue, 1) = True Then
                        LblSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                        LblNroBoletaFact.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                        'GrpContacto.Enabled = False
                        Return True
                    ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0, 1) = True Then
                        LblSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                        LblNroBoletaFact.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                        'GrpContacto.Enabled = False
                        Return True
                    Else
                        'Me.LimpiarDatosCliente()
                        Return False
                    End If
                    Return False
                End If
            Else
                If iOpcion <> 2 Then
                    LblTipoComprobante.Text = "BOLETA"
                End If
                'GrpContacto.Enabled = False
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function 'func 3


    Public objGuiaEnvio As New dtoGuiaEnvio
    Dim bControl_Tarifas As Boolean = False
    Dim tarifa_Peso As Double = 0
    Dim tarifa_Volumen As Double = 0
    Dim tarifa_Articulo As Double = 0
    Dim tarifa_Sobre As Double = 0
    Dim Monto_Base As Double = 0
    Dim iTarifa As Integer = 0
    Dim bCargaAcompañada2 As Boolean = False
    Dim iControlMonto_Base As Double = 1
    Dim bTieneLineaCredito As Boolean = False
    Dim bDescuento As Boolean
    Dim iDescuento As Double = 0
    Public Function fnTarifario() As Boolean
        Return False
        Dim flag As Boolean = False
        Try
            bControl_Tarifas = False
            tarifa_Peso = 0
            tarifa_Volumen = 0
            tarifa_Articulo = 0
            Monto_Base = 0

            If CboProducto.SelectedValue = 8 Then objGuiaEnvio.TarifaMasiva_ = True
            '********************Parametros*************************************************************
            objGuiaEnvio.iIDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad.ToString
            objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = idUnidadAgencias 'CodCiudadDest_
            objGuiaEnvio.TipoProducto_ = CboProducto.SelectedValue
            objGuiaEnvio.TipoTarifa_ = CboTipoTarifa.SelectedIndex
            objGuiaEnvio.sNU_DOCU_SUNAT = IIf(Me.TxtNroDocCliente.Text <> "", Me.TxtNroDocCliente.Text, "@")

            '*******************************************************************************************'
            'Listando la tarifa corporativa (ciudad origen, ciudad  destino, cliente)     no incluye igv
            '*******************************************************************************************'           
            If CboTipoTarifa.SelectedIndex = 0 AndAlso Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
                bTarifarioGeneral = False
                tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Sobre
                iTarifa = objGuiaEnvio.iTarifa

                GrdDetalleVenta(3, 0).Value = tarifa_Peso
                GrdDetalleVenta(3, 1).Value = tarifa_Volumen
                GrdDetalleVenta(3, 2).Value = tarifa_Sobre

                If iControlMonto_Base = 1 Then
                    GrdDetalleVenta(3, 3).Value = Monto_Base
                    GrdDetalleVenta(4, 3).Value = Monto_Base
                End If

                flag = True
                bControl_Tarifas = True

                '*******************************************************************************************'
                'Tarifa publica (ciudad origen, ciudad destino)                   incluye igv
                '*******************************************************************************************'
            ElseIf objGuiaEnvio.fnTARIFA_PUBLICA_CARGA2() = True Then
                bContado = objGuiaEnvio.bContado
                bTarifarioGeneral = True

                tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal

                'verifica si esta afecto a monto base para carga acompañada
                If CboProducto.SelectedValue = 6 Then
                    If CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
                        Monto_Base = 0
                    End If
                    'bBoleto = "N"
                End If

                If bTieneLineaCredito Then
                    tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso_credito
                    tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen_credito
                    Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base_credito
                    tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal_credito
                    bContado = False
                    TarifaPublica_ = False
                End If

                If bBoleto = False Then
                    If bDescuento Then
                        tarifa_Peso = tarifa_Peso * (1 - iDescuento)
                        tarifa_Volumen = tarifa_Volumen * (1 - iDescuento)
                        'tarifa_Sobre = tarifa_Sobre * (1 - iDescuento)
                        isDescuento_ = True
                    End If
                End If
                'bBoleto = False

                If ChkVolumetrico.Checked = False Then
                    GrdDetalleVenta("Costo", 0).Value = tarifa_Peso
                    GrdDetalleVenta("Costo", 1).Value = tarifa_Volumen
                    GrdDetalleVenta("Costo", 2).Value = tarifa_Sobre

                    If iControlMonto_Base = 1 Then
                        GrdDetalleVenta("Costo", 3).Value = Monto_Base
                        GrdDetalleVenta("Sub Neto", 3).Value = Monto_Base
                    End If
                End If

                flag = True
                bControl_Tarifas = True
            Else
                flag = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return flag
    End Function

    Dim coll_Direccion_Remitente As New Collection
    Dim coll_Direccion_Destinatario As New Collection
    Dim coll_Nombres_Remitente As New Collection
    Dim coll_Nombres_Destinatario As New Collection
    Public iWinContacto_Remitente As New AutoCompleteStringCollection
    Public iWinDireccion_Remitente As New AutoCompleteStringCollection
    Public iWinPerosaDNI_Remite As New AutoCompleteStringCollection
    Public iWinContacto_Destinatario As New AutoCompleteStringCollection
    Public iWinDireccion_Destinatario As New AutoCompleteStringCollection
    Public iWinPerosaDNI_Destino As New AutoCompleteStringCollection

    Dim b_lee As Boolean = True
    Dim Iid As String
    Public Function sp_linea_credito() As DataTable
        Try
            Dim ll_idpersona As Int32
            Dim ldt_tmp As DataTable
            '
            ll_idpersona = objGuiaEnvio.iIDPERSONA
            objGuiaEnvio.iIDPERSONA = Iid
            ldt_tmp = objGuiaEnvio.sp_linea_credito()
            objGuiaEnvio.iIDPERSONA = ll_idpersona
            Return ldt_tmp
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Sub LimpiarDatosCliente()
        '*******Items carga Asegurada**********
        Me.RemoveItemsCargAseg()
        '*******Datos Cliente******************
        Me.LimpiarCliente()
        '**************************************
        If iOpcion <> 2 Then
            LblTipoComprobante.Text = "BOLETA"
        End If
        TipoComprobante = 2
        If CboProducto.SelectedValue <> 6 Then
            LblPasajero.Visible = False
        End If
        'CboContacto.Enabled = False

        TxtDescuento.Text = ""
        GrpDescuento.Enabled = True
        RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
        'If ChkArticulos.Checked = True Then
        '    chkSobres.Visible = False
        '    txtCantidadSobres.Visible = False
        '    txtMontoBase.Visible = False
        '    txtTotalSobre.Visible = False
        '    lblMontoBase.Visible = False
        '    TipoGrid_ = FormatoGrid.BULTO
        '    Me.DiseñaGrdDetalleVenta()
        '    FormatoGrdDetalleVenta()
        'Else
        '    'Me.ResetCalculo()
        'End If

        'ChkArticulos.Checked = False
        ChkArticulos.Enabled = False
        ChkVolumetrico.Checked = False

        If CboProducto.SelectedValue <> 6 Then
            'TipoGrid_ = FormatoGrid.BULTO
            'Me.DiseñaGrdDetalleVenta()
            'FormatoGrdDetalleVenta()
        End If

        AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged

        'If GrdDetalleVenta.Rows.Count = 5 Then
        'GrdDetalleVenta.Rows.RemoveAt(4)
        'End If

        'If CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
        '    Me.CboDireccion2.DataSource = Nothing
        '    Me.CboDireccion2.Items.Clear()
        '    Me.CboDireccion2.Items.Add(" (SELECCIONE)")
        '    Me.CboDireccion2.SelectedIndex = 0
        'ElseIf CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
        '    Me.CboDireccion2.DataSource = Nothing
        '    Me.CboDireccion2.Items.Clear()
        '    Me.CboDireccion2.Items.Add("AGENCIA")
        '    Me.CboDireccion2.SelectedIndex = 0
        'Else
        '    Me.CboDireccion2.DataSource = Nothing
        '    Me.CboDireccion2.Items.Clear()
        '    Me.CboDireccion2.SelectedIndex = -1
        'End If
    End Sub

    'Private Sub TxtNomCliente_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNomCliente.Validating
    '    Try
    '        If FnExisteCliente() = False Then
    '            Return
    '        End If

    '        Dim b_flag As Boolean = False
    '        If CboProducto.SelectedValue = 6 Then Return
    '        If s_persona_remitente <> Me.TxtNroDocCliente.Text And s_persona_remitente <> "" Then
    '            If TxtNroDocCliente.Text = "" Then Return
    '            MsgBox("El remitente existe con otro nombre, Desea actualizar los datos presione F6", MsgBoxStyle.Information, "Sistema de Seguridad")
    '            b_flag = True
    '            Me.TxtNroDocCliente.Text = s_persona_remitente
    '        End If
    '        e.Cancel = b_flag
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    '**************VALIDACION DEL TEXBOX (TEXTO, NUMERICO, ALFANUMERICO)***********************
    Private Sub TxtNroDocConsignado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroDocConsignado.KeyPress
        If Not Me.ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNroDocCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroDocCliente.KeyPress
        If Not Me.ValidaNroTexto(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNomCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNomCliente.KeyPress
        If Not Me.ValidaTexto(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNombConsignado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombConsignado.KeyPress
        If Not Me.ValidaTexto(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    'Private Sub TxtTelfConsignado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelfConsignado.KeyPress
    '    If Not Me.ValidaNumero(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TxtTelfCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelfCliente.KeyPress
    '    If Not Me.ValidaNumero(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub txtCantidadSobres_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadSobres.KeyPress
        If Not Me.ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

#End Region 'OK

#Region "CONSIGNADO"

    Private Sub BtnConsignado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsignado.Click
        If iOpcion = 2 Then
            Return
        End If
        Dim frm As New FrmConsignado
        frm.iFicha = 1
        Dim iFila As Integer = 0
        Dim sNumero As String = ""
        Dim sConsignado As String = ""
        Dim sNombresConsig As String = ""
        Dim sApePConsig As String = ""
        Dim sApeMConsig As String = ""
        Dim sTelfConsig As String = ""
        Dim iTipo As Integer
        Dim iDepartamento As Integer
        Dim iProvincia As Integer
        Dim iDistrito As Integer
        Dim iId_via As Integer
        Dim sVia As String = ""
        Dim sNumero2 As String = ""
        Dim sManzana As String = ""
        Dim sLote As String = ""
        Dim iId_Nivel As Integer
        Dim sNivel As String = ""
        Dim iId_Zona As Integer
        Dim sZona As String = ""
        Dim iId_Clasificacion As Integer
        Dim sClasificacion As String = ""
        Dim bEsCliente As Boolean = False

        If Me.TxtNroDocConsignado.Text.Trim.Length > 0 Or Me.TxtNombConsignado.Text.Trim.Length > 0 Then
            If Not bConsignadoNuevo Then
                sNumero = IIf(IsDBNull(dtConsignado.Rows(0).Item("nrodocumento")), "", dtConsignado.Rows(0).Item("nrodocumento")) 'Me.TxtNroDocCliente.Text.Trim
                sConsignado = IIf(IsDBNull(dtConsignado.Rows(0).Item("nombres")), "", dtConsignado.Rows(0).Item("nombres"))
                sNombresConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("nombre")), "", dtConsignado.Rows(0).Item("nombre"))
                iTipo = IIf(IsDBNull(dtConsignado.Rows(0).Item("tipo")), "", dtConsignado.Rows(0).Item("tipo"))
                sApePConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("apepat")), "", dtConsignado.Rows(0).Item("apepat"))
                sApeMConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("apemat")), "", dtConsignado.Rows(0).Item("apemat"))
                sTelfConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("telefono")), "", dtConsignado.Rows(0).Item("telefono"))

                If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio And CboDireccion2.SelectedIndex > 0 Then
                    iFila = Me.CboDireccion2.SelectedIndex
                    iDepartamento = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddepartamento")), 0, dtDireccion2.Rows(iFila).Item("iddepartamento"))
                    iProvincia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("idprovincia")), 0, dtDireccion2.Rows(iFila).Item("idprovincia"))
                    iDistrito = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddistrito")), 0, dtDireccion2.Rows(iFila).Item("iddistrito"))
                    iId_via = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_via")), 0, dtDireccion2.Rows(iFila).Item("id_via"))
                    sVia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("via")), "", dtDireccion2.Rows(iFila).Item("via"))
                    sNumero2 = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("numero")), "", dtDireccion2.Rows(iFila).Item("numero"))
                    sManzana = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("manzana")), "", dtDireccion2.Rows(iFila).Item("manzana"))
                    sLote = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("lote")), "", dtDireccion2.Rows(iFila).Item("lote"))
                    iId_Nivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_nivel")), 0, dtDireccion2.Rows(iFila).Item("id_nivel"))
                    sNivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("nivel")), "", dtDireccion2.Rows(iFila).Item("nivel"))
                    iId_Zona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_zona")), 0, dtDireccion2.Rows(iFila).Item("id_zona"))
                    sZona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("zona")), "", dtDireccion2.Rows(iFila).Item("zona"))
                    iId_Clasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Id_Clasificacion")), 0, dtDireccion2.Rows(iFila).Item("Id_Clasificacion"))
                    sClasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Clasificacion")), "", dtDireccion2.Rows(iFila).Item("Clasificacion"))
                End If
                bEsCliente = Me.ChkCliente2.Checked
            Else
                sNumero = IIf(IsDBNull(dtConsignado.Rows(0).Item("nrodocumento")), "", dtConsignado.Rows(0).Item("nrodocumento")) 'Me.TxtNroDocCliente.Text.Trim
                sConsignado = IIf(IsDBNull(dtConsignado.Rows(0).Item("nombres")), "", dtConsignado.Rows(0).Item("nombres"))
                sNombresConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("nombre")), "", dtConsignado.Rows(0).Item("nombre"))
                iTipo = IIf(IsDBNull(dtConsignado.Rows(0).Item("tipo")), "", dtConsignado.Rows(0).Item("tipo"))
                sApePConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("apepat")), "", dtConsignado.Rows(0).Item("apepat"))
                sApeMConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("apemat")), "", dtConsignado.Rows(0).Item("apemat"))
                sTelfConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("telefono")), "", dtConsignado.Rows(0).Item("telefono"))

                If bBoleto = False Then
                    If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                        iFila = Me.CboDireccion2.SelectedIndex
                        iDepartamento = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddepartamento")), 0, dtDireccion2.Rows(iFila).Item("iddepartamento"))
                        iProvincia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("idprovincia")), 0, dtDireccion2.Rows(iFila).Item("idprovincia"))
                        iDistrito = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddistrito")), 0, dtDireccion2.Rows(iFila).Item("iddistrito"))
                        iId_via = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_via")), 0, dtDireccion2.Rows(iFila).Item("id_via"))
                        sVia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("via")), "", dtDireccion2.Rows(iFila).Item("via"))
                        sNumero2 = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("numero")), "", dtDireccion2.Rows(iFila).Item("numero"))
                        sManzana = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("manzana")), "", dtDireccion2.Rows(iFila).Item("manzana"))
                        sLote = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("lote")), "", dtDireccion2.Rows(iFila).Item("lote"))
                        iId_Nivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_nivel")), 0, dtDireccion2.Rows(iFila).Item("id_nivel"))
                        sNivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("nivel")), "", dtDireccion2.Rows(iFila).Item("nivel"))
                        iId_Zona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_zona")), 0, dtDireccion2.Rows(iFila).Item("id_zona"))
                        sZona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("zona")), "", dtDireccion2.Rows(iFila).Item("zona"))
                        iId_Clasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Id_Clasificacion")), 0, dtDireccion2.Rows(iFila).Item("Id_Clasificacion"))
                        sClasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Clasificacion")), "", dtDireccion2.Rows(iFila).Item("Clasificacion"))
                    End If
                    bEsCliente = Me.ChkCliente2.Checked
                End If
            End If
        End If
        If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio And CboDireccion2.SelectedIndex > 0 Then
            iFila = Me.CboDireccion2.SelectedIndex
            iDepartamento = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddepartamento")), 0, dtDireccion2.Rows(iFila).Item("iddepartamento"))
            iProvincia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("idprovincia")), 0, dtDireccion2.Rows(iFila).Item("idprovincia"))
            iDistrito = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddistrito")), 0, dtDireccion2.Rows(iFila).Item("iddistrito"))
            iId_via = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_via")), 0, dtDireccion2.Rows(iFila).Item("id_via"))
            sVia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("via")), "", dtDireccion2.Rows(iFila).Item("via"))
            sNumero2 = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("numero")), "", dtDireccion2.Rows(iFila).Item("numero"))
            sManzana = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("manzana")), "", dtDireccion2.Rows(iFila).Item("manzana"))
            sLote = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("lote")), "", dtDireccion2.Rows(iFila).Item("lote"))
            iId_Nivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_nivel")), 0, dtDireccion2.Rows(iFila).Item("id_nivel"))
            sNivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("nivel")), "", dtDireccion2.Rows(iFila).Item("nivel"))
            iId_Zona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_zona")), 0, dtDireccion2.Rows(iFila).Item("id_zona"))
            sZona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("zona")), "", dtDireccion2.Rows(iFila).Item("zona"))
            iId_Clasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Id_Clasificacion")), 0, dtDireccion2.Rows(iFila).Item("Id_Clasificacion"))
            sClasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Clasificacion")), "", dtDireccion2.Rows(iFila).Item("Clasificacion"))
        End If


        frm.cargar(iTipo, sNumero, sCliente, sConsignado, sNombresConsig, bEsCliente, iDepartamento, iProvincia, iDistrito, iId_via, sVia, sNumero2, _
                   sManzana, sLote, iId_Nivel, sNivel, iId_Zona, sZona, iId_Clasificacion, sClasificacion, sApePConsig, sApeMConsig, sTelfConsig, sNombresCli,
                   sApCli, sAmCli, sTelfCliente, "", iIDConsignado)

        frm.bConsignadoNuevo = bConsignadoNuevo
        frm.iTipoEntrega = Me.CboTipoEntrega.SelectedValue

        iTipoDoc = 0
        If Not (dtCliente Is Nothing) Then
            iTipoDoc = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
        End If

        frm.iTipoDoc = iTipoDoc '--
        frm.sNumeroDoc = Me.TxtNroDocCliente.Text.Trim
        frm.snombre = Me.TxtNomCliente.Text.Trim
        frm.idUnidadAgencias = idUnidadAgencias
        '
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.AppStarting
            Me.CargarConsignado(frm)
            Me.Cursor = Cursors.Default
        End If

        'Dim frm As New FrmConsignado
        'frm.iFicha = 1
        'frm.ShowDialog()
        'If frm.DialogResult = Windows.Forms.DialogResult.OK Then
        '    frm.iTipoEntrega = Me.CboTipoEntrega.SelectedIndex
        '    CargarConsignado(frm)
        'End If
    End Sub

    Private Sub ChkCliente2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente2.CheckedChanged
        If iOpcion = 2 Then
            RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
            ChkCliente2.Checked = Not ChkCliente2.Checked
            AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
            Return
        End If
        Static i As Integer = 0
        If ChkCliente2.Checked Then
            If Me.TxtNroDocCliente.Text.Trim.Length > 0 Or Me.TxtNomCliente.Text.Trim.Length > 0 Then
                dtConsignado = New DataTable
                dtConsignado.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
                dtConsignado.Columns.Add(New DataColumn("nombres", GetType(String)))
                dtConsignado.Columns.Add(New DataColumn("nombre", GetType(String))) 'new
                dtConsignado.Columns.Add(New DataColumn("tipo", GetType(Integer)))
                dtConsignado.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
                dtConsignado.Columns.Add(New DataColumn("telefono", GetType(String)))
                dtConsignado.Columns.Add(New DataColumn("apepat", GetType(String)))
                dtConsignado.Columns.Add(New DataColumn("apemat", GetType(String)))

                Dim dr As DataRow
                dr = dtConsignado.NewRow
                dr("idcontacto_persona") = 0
                dr("nombres") = Me.TxtNomCliente.Text.Trim
                dr("nombre") = sNombresCli 'new
                dr("tipo") = iID_TipoDocCli
                dr("nrodocumento") = Me.TxtNroDocCliente.Text.Trim
                dr("apepat") = sApCli
                dr("apemat") = sAmCli
                dr("telefono") = sTelfCliente
                dtConsignado.Rows.Add(dr)

                Me.TxtNroDocConsignado.Tag = 0
                iIDConsignado = 0
                Me.TxtNroDocConsignado.Text = Me.TxtNroDocCliente.Text.Trim
                Me.TxtNombConsignado.Text = Me.TxtNomCliente.Text.Trim
                sNombresConsig = sNombresCli
                iID_TipoDocConsig = iID_TipoDocCli
                sapellPatConsig = sApCli
                sapellMatConsig = sAmCli
                sTelefonoConsig = Me.TxtTelfCliente.Text.Trim
                Me.txtTelfConsignado.Text = Me.TxtTelfCliente.Text.Trim

                bConsignadoNuevo = True
                bConsignadoModificado = False

                Me.CboDireccion2.Focus()
            Else
                MessageBox.Show("Ingrese el Cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                i = 1
                Me.ChkCliente2.Checked = False
                Me.TxtCliente.Focus()
            End If
        Else
            If i = 0 Then
                dtConsignado.Rows.Clear()
                Me.TxtNroDocConsignado.Text = ""
                Me.TxtNombConsignado.Text = ""
                Me.txtTelfConsignado.Text = ""
            Else
                i = 0
            End If
        End If
    End Sub

    Sub BuscarConsignado()
        Try
            Me.Cursor = Cursors.AppStarting
            Dim iOpcion As Integer = IIf(Me.RbtDocumento3.Checked, 1, 2)
            Dim frm As New FrmConsignado
            Dim sConsignado As String = Me.TxtConsignado.Text.Trim
            Dim iConsignado As Integer
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.BuscarConsignado(sConsignado, iOpcion, idUnidadAgencias)
            dtConsignado = ds.Tables(0)
            bConsignadoNuevo = True

            If ds.Tables(0).Rows.Count = 0 Then
                Me.Cursor = Cursors.Default
                MessageBox.Show("El Consignado no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.LimpiarConsignado()
                frm = New FrmConsignado
                frm.bConsignadoNuevo = bConsignadoNuevo
                frm.iTipoEntrega = Me.CboTipoEntrega.SelectedValue
                frm.iFicha = 1
                frm.ShowDialog()
                Me.Cursor = Cursors.Default
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    CargarConsignado(frm)
                End If
            ElseIf ds.Tables(0).Rows.Count = 1 Then
                Me.MostrarConsignado(ds)
                Me.Cursor = Cursors.Default
            Else
                frm = New FrmConsignado
                frm.iFicha = 0
                frm.idUnidadAgencias = idUnidadAgencias
                frm.cargar(ds.Tables(0), 2)
                frm.ShowDialog()
                Me.Cursor = Cursors.Default
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    ds = obj.BuscarConsignado(frm.TxtNumero.Tag)
                    dtConsignado = ds.Tables(0)
                    Me.MostrarConsignado(ds)
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub MostrarConsignado(ByVal ds As DataSet)
        Try
            bConsignadoNuevo = False
            Me.TxtNroDocConsignado.Tag = ds.Tables(0).Rows(0).Item("idcontacto_persona").ToString.Trim
            iIDConsignado = ds.Tables(0).Rows(0).Item("idcontacto_persona").ToString.Trim
            Me.TxtNroDocConsignado.Text = ds.Tables(0).Rows(0).Item("nrodocumento").ToString.Trim
            Me.TxtNombConsignado.Text = ds.Tables(0).Rows(0).Item("nombres").ToString.Trim '& " " & ds.Tables(0).Rows(0).Item("apepat").ToString.Trim & " " & ds.Tables(0).Rows(0).Item("apemat").ToString.Trim
            Me.txtTelfConsignado.Text = ds.Tables(0).Rows(0).Item("telefono").ToString.Trim

            RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
            If Me.TxtNomCliente.Text.Trim = Me.TxtNombConsignado.Text.Trim Then Me.ChkCliente2.Checked = True Else Me.ChkCliente2.Checked = False
            AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged

            Me.CboDireccion2.Focus()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub LimpiarConsignado()
        Me.TxtNroDocConsignado.Text = ""
        Me.TxtNombConsignado.Text = ""
        Me.txtTelfConsignado.Text = ""
        Me.ChkCliente2.Checked = False
        bConsignadoNuevo = True
    End Sub

    Private Sub TxtConsignado_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtConsignado.Enter
        Me.TxtConsignado.SelectAll()
    End Sub

    Private Sub TxtConsignado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtConsignado.KeyPress
        If Me.RbtDocumento3.Checked Then
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetra(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Public bDirecConsigMod, bConsignadoModificado As Boolean
    Dim sNombresConsig As String = ""
    Dim sReferencia As String = ""
    Dim sapellPatConsig As String = ""
    Dim sapellMatConsig As String = ""
    Dim sTelefonoConsig As String = "" '-->datos consignado
    Dim iID_TipoDocConsig As Integer = 0
    'direccion
    Dim iDepartamentoConsig, iProvinciaConsig, iDistritoConsig, IDviaConsig, id_NivelConsig, id_ZonaConsig, id_ClasificacionConsig, FormatoConsig As Integer
    Dim ViaConsig, ManzanaConsig, loteConsig, NivelConsig, ZonaConsig, NroConsig, ClasificacionConsig As String
    Sub CargarConsignado(ByVal frm As FrmConsignado)
        Me.TxtNroDocConsignado.Text = frm.TxtNumero.Text.Trim
        Me.TxtNombConsignado.Text = frm.TxtConsignado.Text.Trim & " " & frm.txtapePConsig.Text & " " & frm.txtapeMConsig.Text
        Me.txtTelfConsignado.Text = frm.txtTelefono.Text.Trim
        Me.TxtReferencia.Text = frm.TxtReferencia.Text.Trim
        '--
        iID_TipoDocConsig = frm.CboTipoDocumento.SelectedValue
        sNombresConsig = frm.TxtConsignado.Text.Trim
        sReferencia = frm.TxtReferencia.Text.Trim
        sapellPatConsig = frm.txtapePConsig.Text.Trim
        sapellMatConsig = frm.txtapeMConsig.Text.Trim
        sTelefonoConsig = frm.txtTelefono.Text.Trim
        '--
        bDirecConsigMod = frm.bDirecConsigMod
        bConsignadoModificado = frm.bConsignadoModificado

        If frm.TabConsignado.SelectedIndex = 0 Then
            Me.TxtNroDocConsignado.Text = frm.TxtNumero.Text.Trim
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.BuscarConsignado(frm.TxtNumero.Text, 1, dtoUSUARIOS.m_idciudad)
            dtConsignado = ds.Tables(0)
            Me.MostrarConsignado(ds)
        ElseIf frm.TabConsignado.SelectedIndex = 1 Then
            Dim dr As DataRow
            'consignado
            dtConsignado = New DataTable

            dtConsignado = New DataTable
            dtConsignado.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
            dtConsignado.Columns.Add(New DataColumn("nombres", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("nombre", GetType(String)))
            'dtConsignado.Columns.Add(New DataColumn("idtipo_documento_contacto", GetType(Integer)))
            dtConsignado.Columns.Add(New DataColumn("tipo", GetType(Integer)))
            dtConsignado.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("apepat", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("apemat", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("telefono", GetType(String)))

            dr = dtConsignado.NewRow

            bConsignadoNuevo = frm.bConsignadoNuevo
            If frm.bConsignadoNuevo Then
                iIDConsignado = 0
            End If

            dr("idcontacto_persona") = iIDConsignado
            dr("nombres") = frm.TxtConsignado.Text.Trim & " " & frm.txtapePConsig.Text.Trim & " " & frm.txtapeMConsig.Text.Trim
            dr("nombre") = frm.TxtConsignado.Text.Trim
            'dr("idtipo_documento_contacto") = frm.CboTipoDocumento.SelectedValue
            dr("tipo") = frm.CboTipoDocumento.SelectedValue
            dr("nrodocumento") = frm.TxtNumero.Text.Trim
            dr("apepat") = frm.txtapePConsig.Text.Trim
            dr("apemat") = frm.txtapeMConsig.Text.Trim
            dr("telefono") = frm.txtTelefono.Text.Trim
            dtConsignado.Rows.Add(dr)

            RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
            Me.ChkCliente2.Checked = frm.ChkCliente.Checked
            'Me.ChkCliente2.Tag = Me.ChkCliente1.Checked
            AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged

            If frm.bDirecConsigMod AndAlso Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                '-----------
                iDepartamentoConsig = frm.CboDepartamento.SelectedValue
                iProvinciaConsig = frm.CboProvincia.SelectedValue
                iDistritoConsig = frm.CboDistrito.SelectedValue
                IDviaConsig = frm.CboVia.SelectedValue
                ViaConsig = frm.TxtVia.Text
                NroConsig = frm.TxtNumero2.Text
                ManzanaConsig = frm.TxtManzana.Text
                loteConsig = frm.TxtLote.Text
                id_NivelConsig = frm.CboNivel.SelectedValue
                NivelConsig = frm.TxtNivel.Text
                id_ZonaConsig = frm.CboZona.SelectedValue
                ZonaConsig = frm.TxtZona.Text
                id_ClasificacionConsig = frm.CboClasificacion.SelectedValue
                ClasificacionConsig = frm.TxtClasificacion.Text
                If bDireccionModificada Then FormatoConsig = 1
                '-----------

                'Dirección
                Dim sDireccion As String = frm.CboVia.Text & " " & frm.TxtVia.Text.Trim & " "
                If frm.TxtNumero2.Text.Trim.Length > 0 Then
                    sDireccion &= frm.TxtNumero2.Text.Trim & " "
                End If
                If frm.TxtManzana.Text.Trim.Length > 0 Then
                    sDireccion &= frm.TxtManzana.Text.Trim & " " & frm.TxtLote.Text.Trim & " "
                End If
                If frm.CboNivel.SelectedValue > 0 Then
                    sDireccion &= frm.CboNivel.Text & " " & frm.TxtNivel.Text.Trim & " "
                End If
                If frm.CboZona.SelectedValue > 0 Then
                    sDireccion &= frm.CboZona.Text & " " & frm.TxtZona.Text.Trim & " "
                End If
                If frm.CboClasificacion.SelectedValue > 0 Then
                    sDireccion &= frm.CboClasificacion.Text & " " & frm.TxtClasificacion.Text.Trim & " "
                End If

                dtDireccion2 = New DataTable
                dtDireccion2.Columns.Add(New DataColumn("iddireccion_consignado", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("direccion", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("id_via", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("via", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("numero", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("manzana", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("lote", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("id_nivel", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("nivel", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("id_zona", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("zona", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("id_clasificacion", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("clasificacion", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("iddepartamento", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("idprovincia", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("iddistrito", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("de_referencia", GetType(String)))

                dr = dtDireccion2.NewRow
                dr("iddireccion_consignado") = 0
                dr("direccion") = " (SELECCIONE)"
                dr("id_via") = 0
                dr("via") = ""
                dr("numero") = ""
                dr("manzana") = ""
                dr("lote") = ""
                dr("id_nivel") = 0
                dr("nivel") = ""
                dr("id_zona") = 0
                dr("zona") = ""
                dr("id_clasificacion") = 0
                dr("clasificacion") = ""
                dr("iddepartamento") = 0
                dr("idprovincia") = 0
                dr("iddistrito") = 0
                dr("de_referencia") = ""
                dtDireccion2.Rows.Add(dr)

                dr = dtDireccion2.NewRow
                dr("iddireccion_consignado") = -1
                dr("direccion") = sDireccion
                dr("id_via") = frm.CboVia.SelectedValue
                dr("via") = frm.TxtVia.Text.Trim
                dr("numero") = frm.TxtNumero2.Text.Trim
                dr("manzana") = frm.TxtManzana.Text.Trim
                dr("lote") = frm.TxtLote.Text.Trim
                dr("id_nivel") = frm.CboNivel.SelectedValue
                dr("nivel") = frm.TxtNivel.Text.Trim
                dr("id_zona") = frm.CboZona.SelectedValue
                dr("zona") = frm.TxtZona.Text.Trim
                dr("id_clasificacion") = frm.CboClasificacion.SelectedValue
                dr("clasificacion") = frm.TxtClasificacion.Text.Trim
                dr("iddepartamento") = frm.CboDepartamento.SelectedValue
                dr("idprovincia") = frm.CboProvincia.SelectedValue
                dr("iddistrito") = frm.CboDistrito.SelectedValue
                dr("de_referencia") = frm.TxtReferencia.Text.Trim
                dtDireccion2.Rows.Add(dr)

                Me.CboDireccion2.DataSource = dtDireccion2
                CboDireccion2.DisplayMember = "direccion"
                CboDireccion2.ValueMember = "iddireccion_consignado"
                Me.CboDireccion2.SelectedIndex = 1
            End If

            If TxtNroDocCliente.Text.Trim.Length > 0 Then
                Me.ChkCliente2.Checked = IIf(TxtNroDocCliente.Text = TxtNroDocConsignado.Text, 1, 0)
            End If
        End If
    End Sub

    Sub ConvertirTipoEntrega(ByVal tipo As Integer)
        If tipo = TipoEntrega.Agencia Then
            Me.CboDireccion2.DataSource = Nothing
            Me.CboDireccion2.Items.Clear()
            Me.CboDireccion2.Items.Add("AGENCIA")
            Me.CboDireccion2.SelectedIndex = 0
            Me.TxtReferencia.Text = ""
        ElseIf tipo = TipoEntrega.Domicilio Then
            If dtDireccion2 IsNot Nothing Then
                Me.CboDireccion2.DataSource = dtDireccion2
                Me.CboDireccion2.ValueMember = "iddireccion_consignado"
                Me.CboDireccion2.DisplayMember = "direccion"

                If Me.CboDireccion2.Items.Count = 2 Then
                    Me.CboDireccion2.SelectedIndex = 1
                Else
                    Me.CboDireccion2.SelectedIndex = 0
                    Me.TxtReferencia.Text = ""
                End If
            Else
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.Items.Add(" (SELECCIONE)")
                Me.CboDireccion2.SelectedIndex = 0
            End If
        Else
            Me.CboDireccion2.DataSource = Nothing
            Me.CboDireccion2.Items.Clear()
            Me.CboDireccion2.SelectedIndex = -1
            Me.TxtReferencia.Text = ""
        End If
    End Sub


#End Region 'OK

#Region "CONTACTO"
    Dim bTecla As Boolean = False

    Private Sub TxtNroDocContacto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroDocContacto.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)

            If tb.Name.ToUpper = "txtDocCliente_Remitente".ToUpper Then
                bTecla = True
            End If

            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
#End Region 'OK

#Region "DESCUENTO"

    Private Sub TxtDescuento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescuento.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf e.KeyChar = "." Then
                If Not (tb.SelectedText = ".") Then
                    e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "-" Then
                If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                    e.Handled = True
                End If
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TxtDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescuento.TextChanged
        Try
            If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                txtDescDescto.Enabled = True
                txtDescDescto.Text = ""
                TxtDescuento.ReadOnly = False
            Else
                txtDescDescto.Enabled = False
                txtDescDescto.Text = ""
            End If

            If bMontoMinimo = False Then
                '**Calculando Descuento**
                If ChkVolumetrico.Checked = True Then
                    Me.DescuentoM3()
                Else
                    Me.fnCalcularCostoDescuento()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim iControlFacturacion As Double = 0
    Private Sub fnCalcularCostoDescuento()
        Try
            Dim valor1 As Double = 0
            Dim valor2 As Double = 0 'Costo
            Dim Costo As Double = 0
            '******************CALCULO [PESO/VOLUMEN] * [COSTO] Row=0*******************************
            If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 0).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta("Peso/Volumen", 0).Value '--> campo [Peso/Vol] Fila [Peso]
            If Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta("Bulto", 0).Value '----------------> campo [Piezas]   Fila [Peso]
            If Conversion.Val(GrdDetalleVenta("Costo", 0).Value) = 0 Then valor2 = 0 Else Costo = GrdDetalleVenta("Costo", 0).Value '----------------> campo [Piezas]   Fila [Peso]

            If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadPeso_ = "PESO" Then
                If valor1 >= objGuiaEnvio.iPeso_Minimo And valor1 <= objGuiaEnvio.iPeso_Maximo Then
                    GrdDetalleVenta("Sub Neto", 0).Value = objGuiaEnvio.iPrecio_cond_Peso
                ElseIf valor1 > objGuiaEnvio.iPeso_Maximo Then
                    Dim Calculo As Double = (valor1 - objGuiaEnvio.iPeso_Maximo) * (Costo)
                    Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
                    GrdDetalleVenta("Sub Neto", 0).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                ElseIf valor1 < objGuiaEnvio.iPeso_Minimo Then
                    GrdDetalleVenta("Sub Neto", 0).Value = "0.00"
                End If
            Else
                GrdDetalleVenta("Sub Neto", 0).Value = IIf(valor1 * tarifa_Peso = 0, "0.00", FormatNumber(Format((valor1 * tarifa_Peso), "###,###,###.00"), 2))
            End If

            '****************CALCULO [PESO/VOLUMEN] * [COSTO] Row=1*********************************
            If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 1).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta("Peso/Volumen", 1).Value '--> campo [Peso/Vol] Fila [Volumen]
            If Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta("Bulto", 1).Value '----------------> campo [Piezas]   Fila [Volumen]        

            If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadVol_ = "VOL" Then
                If valor1 >= objGuiaEnvio.iVol_Minimo And valor1 <= objGuiaEnvio.iVol_Maximo Then
                    GrdDetalleVenta("Sub Neto", 1).Value = objGuiaEnvio.iPrecio_cond_Vol
                ElseIf valor1 > objGuiaEnvio.iVol_Maximo Then
                    Dim Calculo As Double = (valor1 - objGuiaEnvio.iVol_Maximo) * (tarifa_Volumen)
                    Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Vol)
                    GrdDetalleVenta("Sub Neto", 1).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                ElseIf valor1 < objGuiaEnvio.iVol_Minimo Then
                    GrdDetalleVenta("Sub Neto", 1).Value = "0.00"
                End If
            Else
                GrdDetalleVenta("Sub Neto", 1).Value = IIf(valor1 * tarifa_Volumen = 0, "0.00", FormatNumber(Format((valor1 * tarifa_Volumen), "###,###,###.00"), 2))
            End If

            '****************CALCULO [PESO/VOLUMEN] * [COSTO] Row=2*********************************
            If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 2).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta("Peso/Volumen", 2).Value '--> campo [Peso/Vol] Fila [Sobre]
            If Conversion.Val(GrdDetalleVenta("Bulto", 2).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta("Bulto", 2).Value '----------------> campo [Piezas]   Fila [Sobre]

            GrdDetalleVenta("Sub Neto", 2).Value = IIf(valor2 * tarifa_Sobre = 0, "0.00", FormatNumber(Format((valor2 * tarifa_Sobre), "###,###,###.00"), 2))
            '***************************************************************************************

            If iControlFacturacion > 0 Then
                ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
            Else
                If iControlMonto_Base = 0 Then
                    ObjVentaCargaContado.v_MONTO_BASE = 0
                    Monto_Base = 0
                Else
                    If Monto_Base > 0 Then
                        ObjVentaCargaContado.v_MONTO_BASE = Monto_Base 'Monto_Base
                    End If
                End If
            End If
            '----------------------------------------------------------------------------------------------------------------------------

            Dim Vol, Peso, Sobre As Double
            If Conversion.Val(GrdDetalleVenta("Sub Neto", 0).Value) = 0 Then Vol = 0 Else Vol = GrdDetalleVenta("Sub Neto", 0).Value
            If Conversion.Val(GrdDetalleVenta("Sub Neto", 1).Value) = 0 Then Peso = 0 Else Peso = GrdDetalleVenta("Sub Neto", 1).Value
            If Conversion.Val(GrdDetalleVenta("Sub Neto", 2).Value) = 0 Then Sobre = 0 Else Sobre = GrdDetalleVenta("Sub Neto", 2).Value

            Dim SubTotal As Double = 0
            Dim Monto As Double = 0
            If Vol + Peso > 0 Then
                If iControlMonto_Base = 1 Then
                    SubTotal = Monto_Base + Vol + Peso + Sobre
                Else
                    SubTotal = Vol + Peso + Sobre
                End If
            Else
                SubTotal = Vol + Peso + Sobre
            End If


            Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            Dim intFila As Integer
            '*******APLICACION CARGA ASEGURADA****************
            If es_carga_asegurada Then
                If bTarifarioGeneral And bContado Then
                    intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                    SubTotal += Format(Val(GrdDetalleVenta("Sub Neto", intFila).Value), "0.00")
                Else
                    SubTotal += Val(GrdDetalleVenta("Sub Neto", intFila).Value)
                End If
                '    If bTarifarioGeneral And bContado Then
                '        SubTotal += Format(Val(GrdDetalleVenta("Sub Neto", 4).Value), "0.00")
                '    Else
                '        SubTotal += Val(GrdDetalleVenta("Sub Neto", 4).Value)
                '    End If
            End If

            '*******Entrega a domicilio*************************
            intFila = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
            If intFila > 0 Then
                SubTotal += Format(Val(GrdDetalleVenta("Sub Neto", intFila).Value), "0.00")
            End If
            '****************************************************

            Dim SUB_TOTAL_GENERAL As Double = 0
            '********APLICACION DESCUENTO*********************
            If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                If bTarifarioGeneral And bContado Then
                    SUB_TOTAL_GENERAL = fnTECHO(Format(SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                End If
            Else
                If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            '*****************************APLICACION CALCULO*******************************************************************************************************
            'TxtSubtotal.Text = IIf(SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
            'TxtImpuesto.Text = IIf(IGV * SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
            'TxtTotal.Text = IIf(SUB_TOTAL_GENERAL = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL, "###,###,###.00"), 2))
            '******************************************************************************************************************************************************
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region 'OK

#Region "DETALLE VENTA"

    '***DEFINIENDO TIPO DE CARACTER A LAS CELDAS**************
    Dim tipo_ As String
    Sub TipoCampos()
        Try
            If ChkArticulos.Checked = True Then '--------> ARTICULOS
                If iCOL = 2 Then tipo_ = "Int"
                If iCOL = 3 Then tipo_ = "Float"
            End If

            If ChkVolumetrico.Checked = True Then '------> M3 (VOLUMETRICO)
                If iCOL = 1 Then tipo_ = "Int"
                If iCOL >= 2 Then tipo_ = "Float"
            End If

            If ChkVolumetrico.Checked = False And ChkArticulos.Checked = False Then '-->BULTOS
                If iCOL = 1 Then tipo_ = "Int"
                If iCOL = 2 Then tipo_ = "Float"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***FORMATO MILES PARA LAS CELDAS [EJEMPLO (12,400.25)]***  
    Sub FormatoMiles()
        If tipo_ = "Float" Then '-- tipo decimales
            If Conversion.Val(GrdDetalleVenta(iCOL, iROW).Value) = 0 Then GrdDetalleVenta(iCOL, iROW).Value = "0.00" : Return
            GrdDetalleVenta(iCOL, iROW).Value = FormatNumber(GrdDetalleVenta(iCOL, iROW).Value, 2)
        ElseIf tipo_ = "Int" Then '--> tipo Entero
            If Conversion.Val(GrdDetalleVenta(iCOL, iROW).Value) = 0 Then GrdDetalleVenta(iCOL, iROW).Value = "" : Return
            GrdDetalleVenta(iCOL, iROW).Value = FormatNumber(GrdDetalleVenta(iCOL, iROW).Value, 0)
        End If
    End Sub

    '***RESET VALORES DE LAS CELDAS***************************
    Sub ResetCalculo() '-> reseteando el calculo al cambiar el tipo de entrega 
        Return
        If ChkVolumetrico.Checked = False Then
            For i As Integer = 0 To GrdDetalleVenta.RowCount() - 2
                GrdDetalleVenta(1, i).Value = "" '-----> reset campo [Bulto]
                GrdDetalleVenta(2, i).Value = "0.00" '-> reset campo [Peso/Volumen]
                GrdDetalleVenta(4, i).Value = "0.00" '-> reset campo [Sub Neto]
            Next
        ElseIf ChkVolumetrico.Checked = True Then
            For i As Integer = 0 To GrdDetalleVenta.RowCount() - 1
                GrdDetalleVenta(1, i).Value = ""
                GrdDetalleVenta(2, i).Value = "0.00"
                GrdDetalleVenta(3, i).Value = "0.00"
                GrdDetalleVenta(4, i).Value = "0.00"
                GrdDetalleVenta(5, i).Value = "0.00"
                GrdDetalleVenta(7, i).Value = "0.00"
            Next
        End If

        TxtSubtotal.Text = "0.00"
        TxtImpuesto.Text = "0.00"
        TxtTotal.Text = "0.00"
    End Sub

    Dim bInicio As Boolean
    Dim RowEnter As Integer
    Dim ColEnter As Integer
    Private Sub GrdDetalleVenta_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDetalleVenta.RowEnter
        If TipoGrid_ = FormatoGrid.VOLUMETRICO Then
            RowEnter = e.RowIndex
            ColEnter = e.ColumnIndex
        End If
    End Sub
    '***CONTROL DEL KEYDOWN AL GRID***************************
    Private Sub GrdDetalleVenta_KeyDown(ByVal sender As System.Object, _
                                        ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdDetalleVenta.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If

            Dim index As Integer = CType(sender, DataGridView).CurrentRow.Index

            If TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                Dim UltimaFila As Integer = GrdDetalleVenta.Rows.Count() - 1
                If Keys.Down Or Keys.Up Or Keys.Delete Then
                    If bInicio Then Return
                    Dim Key As Integer = e.KeyValue
                    GenerarDataGridVolumetrico(GrdDetalleVenta, index, UltimaFila, tarifa_Peso, Key)
                    iROW = RowEnter
                    Me.Calculo_M3()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '**************************************************************************************
    '******************CALCULOS[BULTO, ARTICULOS, M3(Volumetrico)]*************************
    Dim iCOL As Integer = 0, iROW As Integer = 0
    Private Sub GrdDetalleVenta_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDetalleVenta.CellEndEdit
        Return
        Try
            iROW = e.RowIndex
            iCOL = e.ColumnIndex

            Me.TipoCampos()
            If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1

            '*********************************************************************
            If ChkVolumetrico.Checked = False And ChkArticulos.Checked = False Then
                If idUnidadAgencias <> -1 Then
                    fnTotalPago() '------------------------> Calculo[GRID BULTOS]  
                End If
                '---
                Me.FormatoMiles()
            End If

            '*********************************************************************
            If ChkArticulos.Enabled = True And ChkArticulos.Checked = True Then
                If idUnidadAgencias <> -1 Then
                    Me.CalculoArticulos() '----------------> Calculo[GRID ARTICULOS] 
                End If
                '---
                Me.FormatoMiles()
            End If

            '********************************************************************
            If ChkVolumetrico.Checked = True Then '-----------------> M3 (VOLUMETRICO)
                If idUnidadAgencias <> -1 Then
                    Me.Calculo_M3()
                End If
                '---
                Me.FormatoMiles()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***CALCULO DE VENTA PARA [CASO BULTOS]*******************
    Dim SubTotal_Costo As Double = 0
    Public Function fnTotalPago() As Boolean
        Dim flag As Boolean = False
        Try
            If ChkVolumetrico.Checked = True Then
                Me.Calculo_M3()
                Return flag
            End If
            '**********Tomando los valores del campo [Peso/Volumen: Peso] y [Peso/Volumen: Volumen] y [Bulto: Sobre]********
            'Si se ingreso un descuento
            Dim PorcentajeDesc As Double = Val(TxtDescuento.Text.ToString) / 100
            Dim ValPeso_Peso As Double = 0, valPeso_Volum As Double = 0, ValNroSobres As Double = 0
            '*********************Formateando las Comas***********************************************
            If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 0).Value) = 0 Then ValPeso_Peso = 0 Else ValPeso_Peso = GrdDetalleVenta("Peso/Volumen", 0).Value
            If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 1).Value) = 0 Then valPeso_Volum = 0 Else valPeso_Volum = GrdDetalleVenta("Peso/Volumen", 1).Value
            If Conversion.Val(GrdDetalleVenta("Bulto", 2).Value) = 0 Then ValNroSobres = 0 Else ValNroSobres = GrdDetalleVenta("Bulto", 2).Value
            '*****************************************************************************************
            Dim IGV As Double = dtoUSUARIOS.iIGV / 100

            '*************************************************************************
            '***********CALCULO [SUB_NETO]= [PESO/VOLUMEN] * [COSTO]******************             
            If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadPeso_ = "PESO" Then '----> Si tiene CONDICION TARIFA(Calculo Peso)               
                Me.fnCalcularCondicionTarifa(0, ValPeso_Peso, GrdDetalleVenta("Costo", 0).Value) '-----------------> [Sub Neto (Peso)]
            Else
                GrdDetalleVenta("Sub Neto", 0).Value = IIf(ValPeso_Peso * tarifa_Peso = 0, "0.00", _
                                     FormatNumber(Format((ValPeso_Peso * tarifa_Peso), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
            End If
            '---
            If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadVol_ = "VOL" Then '----> Si tiene CONDICION TARIFA(Calculo volumen)   
                Me.fnCalcularCondicionTarifa(1, valPeso_Volum, GrdDetalleVenta("Costo", 1).Value) '-----------------> [Sub Neto (Volumen)]
            Else
                GrdDetalleVenta("Sub Neto", 1).Value = IIf(valPeso_Volum * tarifa_Volumen = 0, "0.00", _
                                                    FormatNumber(Format((valPeso_Volum * tarifa_Volumen), "###,###,###.00"), 2)) '-> [Sub Neto (Volumen)]
            End If

            GrdDetalleVenta("Sub Neto", 2).Value = IIf(tarifa_Sobre * ValNroSobres = 0, "0.00", _
                                 FormatNumber(Format((tarifa_Sobre * ValNroSobres), "###,###,###.00"), 2))  '----> [Sub Neto (Sobre)]  



            '*************************************************************************
            If Monto_Base > 0 Then
                ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
            End If

            '**************************************************************************           
            If objGuiaEnvio.CondicionTarifa_ = False Then
                If ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen > 0 Then
                    If iControlMonto_Base = 1 Then
                        SubTotal_Costo = (Monto_Base + ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen + tarifa_Sobre * ValNroSobres) '* (1 - PorcentajeDesc)               
                    Else
                        SubTotal_Costo = (ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen + tarifa_Sobre * ValNroSobres) '* (1 - PorcentajeDesc)
                    End If
                Else
                    SubTotal_Costo = (ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen + tarifa_Sobre * ValNroSobres) '* (1 - PorcentajeDesc)
                End If
            Else
                SubTotal_Costo += tarifa_Sobre * ValNroSobres
                If Monto_Base > 0 Then
                    SubTotal_Costo = (Monto_Base + SubTotal_Costo)
                End If
            End If
            '**************************************************************************


            'TxtSubtotal.Text = SubTotal_Costo
            'TxtImpuesto.Text = IGV * SubTotal_Costo
            'TxtTotal.Text = SubTotal_Costo + IGV * SubTotal_Costo

            If bTarifarioGeneral And bContado Then
                'TxtSubtotal.Text = Format(SubTotal_Costo / (1 + IGV), "###,###,###.0000")
                'TxtImpuesto.Text = IGV * SubTotal_Costo
                'TxtTotal.Text = SubTotal_Costo
            End If

            precio_carga_asegurada()
            SubTotal_Costo = TxtSubtotal.Text

            '********************************ENTREGA A DOMICILIO***********************************************
            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            dblMontoEntregaDomicilio = GestionaMontoTarifaDomicilio(dtTarifaServicio, GrdDetalleVenta)
            SubTotal_Costo = SubTotal_Costo + dblMontoEntregaDomicilio / (1 + IGV)
            '***************************************************************************************************

            '********************************DEVOLUCION DE CARGO************************************************
            dblMontoDC = ObtieneMontoDevolucionCargo()
            SubTotal_Costo = SubTotal_Costo + dblMontoDC / (1 + IGV)
            '********************************DEVOLUCION DE CARGO************************************************


            Dim SUB_TOTAL_GENERAL As Double = 0
            '*******************************[PAGO CON DESCUENTO]***********************************************
            If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
            Else
                If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If
            '**************************************************************************************************
            'TxtSubtotal.Text = IIf(SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
            'TxtImpuesto.Text = IIf(IGV * SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
            'TxtTotal.Text = IIf(SUB_TOTAL_GENERAL = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL, "###,###,###.00"), 2))
            Return flag
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub precio_carga_asegurada()
        If es_carga_asegurada = True Then
            Dim cdblsub_total As Double = 0
            Dim cdblmonto_IGV As Double = 0
            Dim cdblcosto_total As Double = 0

            For i As Integer = 0 To 19
                If Not objComprobanteAsegurada(i).NRO_SERIE Is Nothing Then
                    If objComprobanteAsegurada(i).TIPO = 1 Or objComprobanteAsegurada(i).TIPO = 0 Then
                        cdblsub_total = cdblsub_total + objComprobanteAsegurada(i).MONTO_SUB_TOTAL * objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO * objComprobanteAsegurada(i).PORCEN / 100
                        cdblmonto_IGV = cdblmonto_IGV + objComprobanteAsegurada(i).MONTO_IMPUESTO * objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO * objComprobanteAsegurada(i).PORCEN / 100
                        cdblcosto_total = cdblcosto_total + objComprobanteAsegurada(i).TOTAL_COSTO * objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO * objComprobanteAsegurada(i).PORCEN / 100
                    Else
                        cdblsub_total = cdblsub_total + objComprobanteAsegurada(i).PORCEN / (1 + objComprobanteAsegurada(i).PORCEN_IMPUESTO / 100)
                        Dim iSub As Double = objComprobanteAsegurada(i).PORCEN / (1 + objComprobanteAsegurada(i).PORCEN_IMPUESTO / 100)
                        cdblmonto_IGV = cdblmonto_IGV + (iSub * (objComprobanteAsegurada(i).PORCEN_IMPUESTO / 100))
                        cdblcosto_total = cdblcosto_total + (objComprobanteAsegurada(i).PORCEN)
                    End If
                End If
            Next
            'pendiente

            TxtSubtotal.Text = Replace(TxtSubtotal.Text, ",", "")
            TxtImpuesto.Text = Replace(TxtImpuesto.Text, ",", "")
            TxtTotal.Text = Replace(TxtTotal.Text, ",", "")
            TxtSubtotal.Text = Val(TxtSubtotal.Text) + cdblsub_total
            TxtImpuesto.Text = Val(TxtImpuesto.Text) + cdblmonto_IGV
            TxtTotal.Text = Val(TxtTotal.Text) + cdblcosto_total
        End If
    End Sub


    '***CALCULO DE VENTA PARA [CASO ARTICULOS]****************      

    Private Sub ChkArticulos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkArticulos.CheckedChanged
        Try
            If iOpcion = 2 Then
                RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
                ChkArticulos.Checked = Not ChkArticulos.Checked
                AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
                Return
            End If
            If ChkArticulos.Checked = False Then
                TipoGrid_ = FormatoGrid.BULTO : LbldetalleVenta.Text = "Detalle Venta" : Me.DiseñaGrdDetalleVenta()
                FormatoGrdDetalleVenta()
                Me.tarifarioEnMemoria()
                TxtSubtotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"

                chkSobres.Visible = False
                txtCantidadSobres.Visible = False
                txtTotalSobre.Visible = False
                lblMontoBase.Visible = False
                txtMontoBase.Visible = False
                GrpDescuento.Enabled = True
                Return
            End If


            If DtArticulos.Rows.Count > 0 Then
                If ChkVolumetrico.Checked = True Then ChkVolumetrico.Checked = False
                chkSobres.Checked = False
                TipoGrid_ = FormatoGrid.ARTICULOS : LbldetalleVenta.Text = "Articulos"
                Me.DiseñaGrdDetalleVenta()
                fArticulo = True
                '*********cargando lo datos de articulos**********

                For Each fila As DataRow In DtArticulos.Rows
                    Dim row0 As String() = {fila.Item(1), FormatNumber(fila.Item(2).ToString, 2), "", "0.00", "0.00", fila.Item(0).ToString()}
                    GrdDetalleVenta.Rows().Add(row0)
                Next

                TxtSubtotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"
                Update()

                txtMontoBase.Text = FormatNumber(IIf(Val(Monto_Base) = 0, 0, Monto_Base), 2)
                chkSobres.Visible = True
                txtCantidadSobres.Visible = True
                txtTotalSobre.Visible = True
                lblMontoBase.Visible = True
                txtMontoBase.Visible = True
                GrpDescuento.Enabled = False

                RemoveHandler TxtDescuento.TextChanged, AddressOf TxtDescuento_TextChanged
                TxtDescuento.Text = ""
                txtDescDescto.Enabled = False
                AddHandler TxtDescuento.TextChanged, AddressOf TxtDescuento_TextChanged
            End If
            Me.RemoveItemsCargAseg()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CalculoArticulos()
        Try
            If iCOL = 2 Then '2 = Columna cantidad
                Dim IGV As Double = dtoUSUARIOS.iIGV / 100
                Dim SubTotal_Costo As Double = 0

                objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = 0
                Dim Total As Double = 0
                Dim ii1 As Integer = 0

                Dim Precio_ As Double = 0, Cantidad_ As Double = 0
                If Conversion.Val(GrdDetalleVenta.Rows(iROW).Cells(1).Value) = 0 And Conversion.Val(GrdDetalleVenta.Rows(iROW).Cells(2).Value) = 0 Then
                    Precio_ = 0
                    Cantidad_ = 0
                Else
                    Precio_ = Conversion.Val(GrdDetalleVenta.Rows(iROW).Cells(1).Value)
                    Cantidad_ = Conversion.Val(GrdDetalleVenta.Rows(iROW).Cells(2).Value)
                End If

                GrdDetalleVenta.Rows(iROW).Cells(4).Value = IIf(Precio_ * Cantidad_ = 0, "0.00", Format(Precio_ * Cantidad_, "###,###,####.00"))
                For ii1 = 0 To GrdDetalleVenta.Rows().Count() - 1
                    Total = Total + Convert.ToDouble((GrdDetalleVenta.Rows(ii1).Cells(4).Value))
                Next

                Dim Monto_Sobre As Double = 0
                If chkSobres.Checked = True Then
                    Monto_Sobre = tarifa_Sobre * Conversion.Val(txtCantidadSobres.Text)
                    txtTotalSobre.Visible = True
                    txtTotalSobre.Text = Format(Monto_Sobre, "####,###,###.00")
                End If


                SubTotal_Costo = Monto_Base + Total + Monto_Sobre
                If Total = 0 Then
                    SubTotal_Costo = Monto_Sobre
                End If

                Dim SUB_TOTAL_GENERAL As Double = 0
                If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                    SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                Else
                    If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                        SUB_TOTAL_GENERAL = 0
                    End If
                End If

                '*****************Calculo Operacion*********************************************
                TxtSubtotal.Text = IIf(SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                TxtImpuesto.Text = IIf(IGV * SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                TxtTotal.Text = IIf(SUB_TOTAL_GENERAL = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL, "###,###,###.00"), 2))
                '*******************************************************************************                          
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***CALCULO DE SOBRES (CASO ARTICULOS)********************
    Private Sub chkSobres_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSobres.CheckedChanged
        If chkSobres.Checked = True Then
            txtCantidadSobres.Enabled = True
            txtCantidadSobres.Focus()
        Else
            txtCantidadSobres.Enabled = False
            txtCantidadSobres.Text = ""
            txtTotalSobre.Text = "0.00"
            If ChkVolumetrico.Checked = True Then
                Me.Calculo_M3()
            Else
                Me.CalculoArticulos()
            End If
        End If
    End Sub

    Private Sub txtCantidadSobres_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidadSobres.LostFocus
        If txtCantidadSobres.Text = "" Then
            chkSobres.Checked = False
            txtCantidadSobres.Enabled = False
        End If
    End Sub

    Private Sub txtCantidadSobres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidadSobres.TextChanged
        Try
            If txtCantidadSobres.Text = "" Then
                objGuiaEnvio.iCANTIDAD_SOBRES = 0
                objGuiaEnvio.iIDSINO_SOBRES = 0
                txtTotalSobre.Text = "0.00"

                '****NEW CODIGO*********************************************
                Dim Val As String = "N"
                For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1
                    If GrdDetalleVenta(2, i).Value <> "" Then
                        Val = "Y"
                    End If
                Next

                If Val = "N" Then
                    TxtSubtotal.Text = "0.00"
                    TxtImpuesto.Text = "0.00"
                    TxtTotal.Text = "0.00"
                End If
                '***********************************************************
            Else
                If tarifa_Sobre = 0 Then Return
                txtCantidadSobres.Enabled = True
                txtCantidadSobres.Focus()
                objGuiaEnvio.iCANTIDAD_SOBRES = Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                objGuiaEnvio.iIDSINO_SOBRES = 1
            End If

            If recuperando_datos_contado = False Then
                If ChkVolumetrico.Checked = True Then
                    Me.Calculo_M3() '---------> Sobre M3
                ElseIf (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then
                    Calculo_Sobre() '---------> Sobre Bulto
                Else
                    iCOL = 2
                    Me.CalculoArticulos() '--->Sobre Articulo
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function Calculo_Sobre() As Boolean
        Try
            Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            Dim c__var As Integer = 1
            Dim Monto_Sobre As Double = 0
            If c__var Then
                Monto_Sobre = tarifa_Sobre * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                txtTotalSobre.Text = IIf(Monto_Sobre = 0, "0.00", Format(Monto_Sobre, "####,###,###.00"))
            Else
                Monto_Sobre = 0
                txtTotalSobre.Text = "0.00"
            End If

            Dim Total_Articulo As Double = 0
            If fArticulo = True Then
                Dim ii1 As Integer = 0
                For ii1 = 0 To GrdDetalleVenta.Rows().Count() - 1
                    Total_Articulo = Total_Articulo + Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii1).Cells("T.Costo").Value.ToString)
                Next
                ' Total_Articulo = Total_Articulo '+ Monto_Base * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                If Total_Articulo > 0 Then
                    TxtSubtotal.Text = Format(Monto_Base + Monto_Sobre + Total_Articulo, "####,###,###.00")
                    TxtImpuesto.Text = Format((IGV) * (Monto_Base + Monto_Sobre + Total_Articulo), "####,###,###.00")
                    TxtTotal.Text = Format((1 + IGV) * (Monto_Base + Monto_Sobre + Total_Articulo), "####,###,###.00")
                Else
                    TxtSubtotal.Text = Format(Monto_Sobre, "####,###,###.00")
                    TxtImpuesto.Text = Format((IGV) * (Monto_Sobre), "####,###,###.00")
                    TxtTotal.Text = Format((1 + IGV) * (Monto_Sobre), "####,###,###.00")
                End If
            Else
                TxtSubtotal.Text = Format(Monto_Sobre, "####,###,###.00")
                TxtImpuesto.Text = Format((IGV) * (Monto_Sobre), "####,###,###.00")
                TxtTotal.Text = Format((1 + IGV) * (Monto_Sobre), "####,###,###.00")
            End If


            Dim SUB_TOTAL_GENERAL As Double = 0
            Dim SubTotal_Costo As Double = TxtSubtotal.Text
            If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")) '01/09/2010 
            Else
                If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            TxtSubtotal.Text = Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            TxtImpuesto.Text = Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            TxtTotal.Text = Format(SUB_TOTAL_GENERAL, "###,###,###.00")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            txtTotalSobre.Text = "0.00"
        End Try
        Return False
    End Function

    '***CALCULO M3[VOLUMETRICO]*******************************
    Private Sub ChkVolumetrico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkVolumetrico.CheckedChanged
        Try
            If iOpcion = 2 Then
                RemoveHandler ChkVolumetrico.CheckedChanged, AddressOf ChkVolumetrico_CheckedChanged
                ChkVolumetrico.Checked = Not ChkVolumetrico.Checked
                AddHandler ChkVolumetrico.CheckedChanged, AddressOf ChkVolumetrico_CheckedChanged
                Return
            End If
            If ChkVolumetrico.Checked = True Then
                If ChkArticulos.Checked = True Then ChkArticulos.Checked = False
                RemoveItemsCargAseg() '------------>Limpiando items [carga asegurada]
                TipoGrid_ = FormatoGrid.VOLUMETRICO '--------> Grid Volumetrico
                Me.DiseñaGrdDetalleVenta() '-------> Diseña GridDetalleVenta
                FormatoGrdDetalleVenta() '---------> Formato al grid
                GrdDetalleVenta(6, 0).Value = Format(tarifa_Peso, "0.00")
                txtMontoBase.Text = FormatNumber(IIf(Val(tarifa_Sobre) = 0, 0, tarifa_Sobre), 2)

                chkSobres.Visible = True
                txtCantidadSobres.Visible = True
                txtTotalSobre.Visible = True
                lblMontoBase.Visible = True
                txtMontoBase.Visible = True
                GrpDescuento.Enabled = True
            Else
                TipoGrid_ = FormatoGrid.BULTO '--------------> Grid Bultos
                Me.DiseñaGrdDetalleVenta() '-------> Diseña GridDetalleVenta
                FormatoGrdDetalleVenta() '---------> Formato al grid
                Me.tarifarioEnMemoria()
                RemoveItemsCargAseg() '--->Limpiando items [carga asegurada]
                TxtSubtotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"

                chkSobres.Visible = False
                txtCantidadSobres.Visible = False
                txtTotalSobre.Visible = False
                lblMontoBase.Visible = False
                txtMontoBase.Visible = False
                GrpDescuento.Enabled = True
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Calculo_M3()
        Try
            Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            '************************

            Dim Altura As Double = 0
            If Conversion.Val(GrdDetalleVenta(2, iROW).Value) = 0 Then Altura = 0 _
                                     Else Altura = GrdDetalleVenta(2, iROW).Value

            '************************
            Dim Ancho As Double = 0
            If Conversion.Val(GrdDetalleVenta(3, iROW).Value) = 0 Then Ancho = 0 _
                                    Else Ancho = GrdDetalleVenta(3, iROW).Value

            '************************
            Dim Largo As Double = 0
            If Conversion.Val(GrdDetalleVenta(4, iROW).Value) = 0 Then Largo = 0 _
                                    Else Largo = GrdDetalleVenta(4, iROW).Value

            '******PESO KG***********
            GrdDetalleVenta("Peso Kg", iROW).Value = IIf((Altura * Ancho * Largo) * Factor_ = 0, "0.00", _
                                                        FormatNumber(Format((Altura * Ancho * Largo) * Factor_, "###,###,###.00"), 2))

            '******Llamando la Condicion Tarifa(Calculo)*******
            If objGuiaEnvio.CondicionTarifa_ Then
                fnCalcularCondicionTarifa(iROW, GrdDetalleVenta("Peso Kg", iROW).Value, GrdDetalleVenta("Costo", iROW).Value)
            Else
                '******Sub Neto***********
                GrdDetalleVenta("Sub Neto", iROW).Value = IIf(GrdDetalleVenta("Peso Kg", iROW).Value * Conversion.Val(GrdDetalleVenta("Costo", iROW).Value) = 0, "0.00", _
                                                              FormatNumber(Format((GrdDetalleVenta("Peso Kg", iROW).Value) * Conversion.Val(GrdDetalleVenta("Costo", iROW).Value), "###,###,###.00"), 2))
            End If

            '*****************Calculo Operacion*********************************************   
            Dim SumSubNeto_ As Double = 0
            Dim Valor_ As Double
            For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1
                If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Valor_ = 0 _
                                    Else Valor_ = GrdDetalleVenta("Sub Neto", i).Value
                SumSubNeto_ += Valor_
            Next
            '**********************
            If SumSubNeto_ > 0 Then
                If Monto_Base > 0 Then
                    ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
                End If

                ObjVentaCargaContado.v_MONTO_BASE = 0
                SumSubNeto_ = SumSubNeto_ + Monto_Base
            End If
            '**********************

            Dim Monto_Sobre As Double = 0
            If chkSobres.Checked = True Then
                Monto_Sobre = tarifa_Sobre * Conversion.Val(txtCantidadSobres.Text)
                txtTotalSobre.Visible = True
                txtTotalSobre.Text = Format(Monto_Sobre, "####,###,###.00")
            End If

            '****Añade [Sobres] al la sumaSubNeto*******************************************
            Dim MontoSobre_ As Double = 0
            If (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then MontoSobre_ = _
                                                               (txtCantidadSobres.Text * tarifa_Sobre) ' + Monto_Base
            '*******************************************************************************
            SumSubNeto_ = fnTECHO(Format(SumSubNeto_ + MontoSobre_, "0.000"))
            '*******************************************
            Dim Total_ As Double = SumSubNeto_
            Dim Subtotal_ As Double = Total_ / (1 + IGV)
            Dim Impuesto_ As Double = Subtotal_ * IGV
            '*******************************************
            TxtSubtotal.Text = IIf(Subtotal_ = 0, "0.00", FormatNumber(Format(Subtotal_, "###,###,###.00"), 2))
            TxtImpuesto.Text = IIf(Impuesto_ = 0, "0.00", FormatNumber(Format(Impuesto_, "###,###,###.00"), 2))
            TxtTotal.Text = IIf(Total_ = 0, "0.00", FormatNumber(Total_, 2))
            '*******************************************           

            If (Val(Me.TxtDescuento.Text) / 100) > 0 Then '-> Aplica Descuento
                Me.DescuentoM3()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub DescuentoM3()
        Dim SumSubNeto_ As Double = 0
        Dim Valor_ As Double
        Try
            For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1
                If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Valor_ = 0 _
                                    Else Valor_ = GrdDetalleVenta("Sub Neto", i).Value
                SumSubNeto_ += Valor_
            Next

            Dim IGV As Double = dtoUSUARIOS.iIGV / 100

            '****Añade [Sobres] al la sumaSubNeto*******************************************
            Dim MontoSobre_ As Double = 0
            If (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then MontoSobre_ = _
                                                               (txtCantidadSobres.Text * Monto_Base) + Monto_Base

            SumSubNeto_ = fnTECHO(Format(SumSubNeto_ + MontoSobre_, "0.00"))
            '******DESCUENTO ARTICULOS******************************************************
            Dim SUB_TOTAL_GENERAL As Double = 0
            If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                If bTarifarioGeneral Then
                    SUB_TOTAL_GENERAL = fnTECHO(Format(SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                End If
            Else
                If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            '*******************************************
            Dim Total_ As Double = SUB_TOTAL_GENERAL
            Dim Subtotal_ As Double = Total_ / (1 + IGV)
            Dim Impuesto_ As Double = Subtotal_ * IGV
            '*******************************************

            TxtSubtotal.Text = IIf(Subtotal_ = 0, "0.00", FormatNumber(Format(Subtotal_, "###,###,###.00"), 2))
            TxtImpuesto.Text = IIf(Impuesto_ = 0, "0.00", FormatNumber(Format(Impuesto_, "###,###,###.00"), 2))
            TxtTotal.Text = IIf(Total_ = 0, "0.00", FormatNumber(Total_, 2))

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*************************************************************************
    '***CONDICION TARIFA(CALCULO)*********************************************

    Private Sub fnCalcularCondicionTarifa(ByVal row As Integer, ByVal Peso_Volumen As Double, ByVal Costo As Double)
        Try
            Dim ValorRango_ As Double = 0
            If row = 0 Then
                If Peso_Volumen >= objGuiaEnvio.iPeso_Minimo And Peso_Volumen <= objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
                    GrdDetalleVenta("Sub Neto", row).Value = objGuiaEnvio.iPrecio_cond_Peso
                ElseIf Peso_Volumen > objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
                    Dim Calculo As Double = (Peso_Volumen - objGuiaEnvio.iPeso_Maximo) * (Costo)
                    Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
                    GrdDetalleVenta("Sub Neto", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                ElseIf Peso_Volumen < objGuiaEnvio.iPeso_Minimo Then
                    GrdDetalleVenta("Sub Neto", row).Value = "0.00"
                End If
            ElseIf row = 1 Then
                If Peso_Volumen >= objGuiaEnvio.iVol_Minimo And Peso_Volumen <= objGuiaEnvio.iVol_Maximo And Costo > 0 Then
                    GrdDetalleVenta("Sub Neto", row).Value = objGuiaEnvio.iPrecio_cond_Vol
                ElseIf Peso_Volumen > objGuiaEnvio.iVol_Maximo And Costo > 0 Then
                    Dim Calculo As Double = (Peso_Volumen - objGuiaEnvio.iVol_Maximo) * (Costo)
                    Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Vol)
                    GrdDetalleVenta("Sub Neto", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                ElseIf Peso_Volumen < objGuiaEnvio.iVol_Minimo Then
                    GrdDetalleVenta("Sub Neto", row).Value = "0.00"
                End If
            End If


            Dim ValNroSobres As Double = 0
            Dim Nor_Sobres As Double = 0
            If ChkVolumetrico.Checked = False Then
                If Conversion.Val(GrdDetalleVenta(1, 2).Value) = 0 Then ValNroSobres = 0 Else ValNroSobres = GrdDetalleVenta(1, 2).Value
                Nor_Sobres = Val(IIf(GrdDetalleVenta(1, 2).Value Is Nothing, 0, ValNroSobres))
            End If

            Dim Sub_Neto_ As Double
            Dim Monto As Double

            For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 3
                If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Monto = 0 _
                                Else Monto = GrdDetalleVenta("Sub Neto", i).Value '--> Formateando en caso de Coma
                Sub_Neto_ += Monto
            Next
            SubTotal_Costo = Sub_Neto_

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    '*************************************************************************
    '****************FORMATO SEPARADOS SIN MILES******************************
    Dim BCol_ As Integer, BRow_ As Integer
    Private Sub GrdDetalleVenta_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles GrdDetalleVenta.CellBeginEdit
        return
        Try
            Dim Format_ As Double
            BCol_ = e.ColumnIndex
            BRow_ = e.RowIndex

            If ChkVolumetrico.Checked = False And ChkArticulos.Checked = False Then '----------> Bultos
                If BCol_ = 1 Or BCol_ = 2 Then
                    If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) = 0 Then
                        Return
                    Else
                        Format_ = GrdDetalleVenta(BCol_, BRow_).Value
                    End If
                    GrdDetalleVenta(BCol_, BRow_).Value = Format_
                End If
            End If


            If ChkArticulos.Checked = True Then '-----------> Articulos
                If BCol_ = 2 Or BCol_ = 3 Then
                    If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) = 0 Then
                        Return
                    Else
                        Format_ = GrdDetalleVenta(BCol_, BRow_).Value
                    End If
                    GrdDetalleVenta(BCol_, BRow_).Value = Format_
                End If
            End If

            If ChkVolumetrico.Checked = True Then '-----------> M3
                If BCol_ >= 1 And BCol_ <= 5 Then
                    If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) = 0 Then
                        Return
                    Else
                        Format_ = GrdDetalleVenta(BCol_, BRow_).Value
                    End If
                    GrdDetalleVenta(BCol_, BRow_).Value = Format_
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '****************EVENTOS PARA VALIDAR LAS CELDAS (SOLO TEXTO)*************
    Private WithEvents celda As DataGridViewTextBoxEditingControl
    Private Sub GrdDetalleVenta_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles GrdDetalleVenta.EditingControlShowing
        celda = TryCast(e.Control, DataGridViewTextBoxEditingControl)
    End Sub

    Private Sub celda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles celda.KeyPress
        e.Handled = Me.Numero(e, celda)
    End Sub

    Public Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
        If ChkVolumetrico.Checked = False And ChkArticulos.Checked = False Then '-------------------> BULTOS
            If BCol_ = 2 Then '----->Campo [Peso/Volumen]            
                If UCase(e.KeyChar) Like "[!0-9.]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If

                Dim c As Short = 0
                If UCase(e.KeyChar) Like "[.]" Then
                    If InStr(cajasTexto.Text, ".") > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            ElseIf BCol_ = 1 Then '-->Campo [Bulto]
                If UCase(e.KeyChar) Like "[!0-9]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If
            End If
        ElseIf ChkArticulos.Checked = True Then '---------------> ARTICULOS
            If BCol_ = 3 Then 'Campo [Peso]
                If UCase(e.KeyChar) Like "[!0-9.]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If

                Dim c As Short = 0
                If UCase(e.KeyChar) Like "[.]" Then
                    If InStr(cajasTexto.Text, ".") > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            ElseIf BCol_ = 2 Then '-->Campo [Cantidad]
                If UCase(e.KeyChar) Like "[!0-9]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If
            End If
        End If

        If ChkVolumetrico.Checked = True Then '----------------->M3
            If BCol_ >= 2 Then 'Campo [Peso]
                If UCase(e.KeyChar) Like "[!0-9.]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If

                Dim c As Short = 0
                If UCase(e.KeyChar) Like "[.]" Then
                    If InStr(cajasTexto.Text, ".") > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            ElseIf BCol_ = 1 Then '-->Campo [Cantidad]
                If UCase(e.KeyChar) Like "[!0-9]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If
            End If
        End If

    End Function

#End Region 'OK

#Region "DOCUMENTOS DEL CLIENTE"
    Dim iDigitosSerie As Integer = 3
    Dim iDigitosDcoumento As Integer = 7
    Private Sub DataGridViewDocumentos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDocumentosCliente.CellEndEdit
        Try
            Dim row As Short = e.RowIndex
            Dim col As Short = e.ColumnIndex
            Dim serie_NroDoc() As String = Split(GrdDocumentosCliente(col, row).Value.ToString, "-")
            Dim serie As String = ""
            Dim NroDoc As String = ""
            If serie_NroDoc(0).Length > 0 Then
                serie = RellenoRight(iDigitosSerie, Trim(serie_NroDoc(0)))
                'serie = Trim(serie_NroDoc(0))
            End If

            If serie_NroDoc.Length >= 2 Then
                If serie_NroDoc(1).Length > 0 Then
                    'NroDoc = Trim(serie_NroDoc(1))
                    NroDoc = RellenoRight(iDigitosDcoumento + 1, Trim(serie_NroDoc(1)))
                End If
            End If
            GrdDocumentosCliente(col, row).Value = IIf(serie & "-" & NroDoc = "000-", "", serie & "-" & NroDoc)
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region 'OK

#Region "GRABAR"

    Sub FormateoVariables()
        '**DATOS CLIENTE
        If NombresCliente Is Nothing Then ObjVentaCargaContado.NombresCliente = ""
        If apellPatCli Is Nothing Then ObjVentaCargaContado.apellPatCli = ""
        If apellMatCli Is Nothing Then ObjVentaCargaContado.apellMatCli = ""
        If TelfCliente Is Nothing Then ObjVentaCargaContado.TelefCliente = ""

        '**DIRECCION CLIENTE
        If ViaCli Is Nothing Then ObjVentaCargaContado.viaCli = ""
        If NroCli Is Nothing Then ObjVentaCargaContado.NumeroCli = ""
        If ManzanaCli Is Nothing Then ObjVentaCargaContado.manzanaCli = ""
        If loteCli Is Nothing Then ObjVentaCargaContado.loteCli = ""
        If NivelCli Is Nothing Then ObjVentaCargaContado.nivelCli = ""
        If ZonaCli Is Nothing Then ObjVentaCargaContado.zonaCli = ZonaCli = ""
        If ClasificacionCli Is Nothing Then ObjVentaCargaContado.clasificacionCli = ""
        '**CONTACTO
        If apellPatCont Is Nothing Then ObjVentaCargaContado.apellPatCont = ""
        If apellMatCont Is Nothing Then ObjVentaCargaContado.apellMatCont = ""
        '**DATOS CONSIGNADO
        If sNombresConsig Is Nothing Then ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = ""
        If sapellPatConsig Is Nothing Then ObjVentaCargaContado.apellPatConsig = ""
        If sapellMatConsig Is Nothing Then ObjVentaCargaContado.apellMatConsig = ""
        If sTelefonoConsig Is Nothing Then ObjVentaCargaContado.TelfConsignado = ""
        '**DIRECCION CONSIGNADO
        If ViaConsig Is Nothing Then ObjVentaCargaContado.viaConsig = ""
        If NroConsig Is Nothing Then ObjVentaCargaContado.NumeroConsig = ""
        If ManzanaConsig Is Nothing Then ObjVentaCargaContado.manzanaConsig = ""
        If loteConsig Is Nothing Then ObjVentaCargaContado.loteConsig = ""
        If NivelConsig Is Nothing Then ObjVentaCargaContado.nivelConsig = ""
        If ZonaConsig Is Nothing Then ObjVentaCargaContado.zonaConsig = ""
        If ClasificacionConsig Is Nothing Then ObjVentaCargaContado.clasificacionConsig = ""
    End Sub

    Dim iIdFactura As Integer
    Dim iOficinaOrigen As Integer
    Dim strNroGuias_Remision As String
    Public bControlFiscalizacion As Boolean = False
    Dim intCortesia As Integer = 0
    Sub Grabar()
        Try
            ''CARGA ACOMPAÑADA
            'If recuperando_datos_contado And bCargaAcompañada And Me.TxtBoleto.ReadOnly = False And ObjVentaCargaContado.v_facturado = 0 Then
            '    Dim s As String = Me.TxtBoleto.Text.Trim
            '    Dim obj As New dtoVentaCargaContado
            '    If bCargaAcompañada2 = False Then
            '        bCargaAcompañada = False
            '        s = ""
            '    End If

            '    obj.ActualizaCargaAcompañada(iIdFactura, s, TxtNombConsignado.Text, TxtNroDocConsignado, "", TxtNroDocContacto, TxtNomCliente.Text, TxtNroDocCliente, 0) ', TxtTelfCliente.Text.Trim
            '    MessageBox.Show("Registro Grabado.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    bCargaAcompañada = False
            '    bCargaAcompañada2 = False
            '    fnNUEVO()
            '    limpiar_documentos_cliente()
            '    iOficinaDestino = 0
            '    iOficinaOrigen = 0
            '    Me.Cursor = Cursors.Default
            '    Return
            'ElseIf recuperando_datos_contado And bCargaAcompañada And Me.TxtBoleto.ReadOnly = False And ObjVentaCargaContado.v_facturado = 0 Then 'carga acompañada'And flagPCE
            '    Dim s As String = Me.TxtBoleto.Text.Trim
            '    Dim obj As New dtoVentaCargaContado
            '    If bCargaAcompañada2 = False Then
            '        bCargaAcompañada = False
            '        s = ""
            '    End If
            '    obj.ActualizaCargaAcompañada(iIdFactura, s)
            'ElseIf bCargaAcompañada And LblTipoComprobante.Text.Substring(0, 1) <> "G" And ObjVentaCargaContado.v_facturado = 1 Then 'flagPCE
            '    Me.Cursor = Cursors.Default
            '    Return
            'End If

            If Val(TxtDescuento.Text) = 0 Then
                TxtDescuento.Text = ""
            End If

            'hlamas 16-05-2017
            'If fnGrabar() Then
            If GrabarCancelacion() Then
                'If 1 = 1 Then
                ''If ObjVentaCargaContado.fnNroDocuemnto(2, CboProducto.SelectedValue) = True Then
                ''    LblSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                ''    LblNroBoletaFact.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                ''    LblSerie.Visible = True
                ''    LblNroBoletaFact.Visible = True
                ''ElseIf ObjVentaCargaContado.fnNroDocuemnto(2, 0) = True Then
                ''    LblSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                ''    LblNroBoletaFact.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                ''    LblSerie.Visible = True
                ''    LblNroBoletaFact.Visible = True
                ''End If


                Me.Cursor = Cursors.AppStarting
                sDocCliente = ""
                bBoleto = False
                Select Case iLlamada
                    Case 1
                        Listar(Convert.ToInt64(Me.TxtGuia.Text.Trim))
                    Case 2
                        Listar(Me.TxtDocumento.Text.ToString.Trim)
                    Case 3
                        Listar(Me.DtpFechaInicio.Text, Me.DtpFechaFin.Text, CboCiudadOrigen.SelectedValue, _
                        Me.CboCiudadDestino.SelectedValue, Me.CboAgenciaOrigen.SelectedValue, Me.CboUsuario.SelectedValue, Me.CboEstado.SelectedValue)
                    Case 4
                        Listar(Me.DtpFechaInicio.Text, Me.DtpFechaFin.Text, Me.TxtDocumento.Text.Trim)
                End Select



                Me.TabGuia.SelectedIndex = 0
                Me.Cursor = Cursors.Default
                Me.BtnBuscar.Focus()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub asignar_documentos_clientes()
        With ObjVentaCargaContado
            .v_ID_GUIAS_ENVIO_DOCs = Nothing
            .v_FECHAs = Nothing
            .v_MONTO_TIPO_CAMBIOs = Nothing
            .v_IDTIPO_MONEDAs = Nothing
            .v_IDTIPO_COMPROBANTEs = Nothing
            .v_NRO_SERIEs = Nothing
            .v_NRO_DOCUs = Nothing
            .v_MONTO_IMPUESTOs = Nothing
            .v_TOTAL_COSTOs = Nothing
            .v_PORCENs = Nothing
            .v_OBSs = Nothing
            .v_TIPOs = Nothing
            .v_PROCEDENCIAs = Nothing

            For i As Integer = 0 To 19
                If Not objComprobanteAsegurada(i).NRO_SERIE Is Nothing Then
                    .v_ID_GUIAS_ENVIO_DOCs = .v_ID_GUIAS_ENVIO_DOCs & objComprobanteAsegurada(i).ID_GUIAS_ENVIO_DOC & ";"
                    .v_FECHAs = .v_FECHAs & objComprobanteAsegurada(i).FECHA & ";"
                    .v_MONTO_TIPO_CAMBIOs = .v_MONTO_TIPO_CAMBIOs & objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO & ";"
                    .v_IDTIPO_MONEDAs = .v_IDTIPO_MONEDAs & objComprobanteAsegurada(i).IDTIPO_MONEDA & ";"
                    .v_IDTIPO_COMPROBANTEs = .v_IDTIPO_COMPROBANTEs & objComprobanteAsegurada(i).IDTIPO_COMPROBANTE & ";"
                    .v_NRO_SERIEs = .v_NRO_SERIEs & objComprobanteAsegurada(i).NRO_SERIE & ";"
                    .v_NRO_DOCUs = .v_NRO_DOCUs & objComprobanteAsegurada(i).NRO_DOCU & ";"
                    .v_MONTO_IMPUESTOs = .v_MONTO_IMPUESTOs & objComprobanteAsegurada(i).MONTO_IMPUESTO & ";"
                    .v_TOTAL_COSTOs = .v_TOTAL_COSTOs & objComprobanteAsegurada(i).TOTAL_COSTO & ";"
                    .v_PORCENs = .v_PORCENs & objComprobanteAsegurada(i).PORCEN & ";"
                    .v_OBSs = .v_OBSs & objComprobanteAsegurada(i).OBS & ";"
                    .v_TIPOs = .v_TIPOs & objComprobanteAsegurada(i).TIPO & ";"
                    .v_PROCEDENCIAs = .v_PROCEDENCIAs & objComprobanteAsegurada(i).PROCEDENCIA & ";"
                End If
            Next

            If .v_ID_GUIAS_ENVIO_DOCs Is Nothing Then Exit Sub

            .v_ID_GUIAS_ENVIO_DOCs = Mid(.v_ID_GUIAS_ENVIO_DOCs, 1, Len(.v_ID_GUIAS_ENVIO_DOCs) - 1)
            .v_FECHAs = Mid(.v_FECHAs, 1, Len(.v_FECHAs) - 1)
            .v_MONTO_TIPO_CAMBIOs = Mid(.v_MONTO_TIPO_CAMBIOs, 1, Len(.v_MONTO_TIPO_CAMBIOs) - 1)
            .v_IDTIPO_MONEDAs = Mid(.v_IDTIPO_MONEDAs, 1, Len(.v_IDTIPO_MONEDAs) - 1)
            .v_IDTIPO_COMPROBANTEs = Mid(.v_IDTIPO_COMPROBANTEs, 1, Len(.v_IDTIPO_COMPROBANTEs) - 1)
            .v_NRO_SERIEs = Mid(.v_NRO_SERIEs, 1, Len(.v_NRO_SERIEs) - 1)
            .v_NRO_DOCUs = Mid(.v_NRO_DOCUs, 1, Len(.v_NRO_DOCUs) - 1)
            .v_MONTO_IMPUESTOs = Mid(.v_MONTO_IMPUESTOs, 1, Len(.v_MONTO_IMPUESTOs) - 1)
            .v_TOTAL_COSTOs = Mid(.v_TOTAL_COSTOs, 1, Len(.v_TOTAL_COSTOs) - 1)
            .v_PORCENs = Mid(.v_PORCENs, 1, Len(.v_PORCENs) - 1)
            .v_OBSs = Mid(.v_OBSs, 1, Len(.v_OBSs) - 1)
            .v_TIPOs = Mid(.v_TIPOs, 1, Len(.v_TIPOs) - 1)
            .v_PROCEDENCIAs = Mid(.v_PROCEDENCIAs, 1, Len(.v_PROCEDENCIAs) - 1)
        End With
    End Sub

    Public Function fnImprimirEtiquetas() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            'Dim I As Int16 = 1
            Dim i As Int16 = 0
            'Dim j As Int16 = 1
            Dim j As Int16
            'If bRango Then
            '    j = 1
            'Else
            '    j = correlativo_inicial
            '    'Mod 21/08/2009 
            '    If j = 0 Then j = 1
            'End If
            '''''''''''''''''
            If iRango = 1 Then
                j = 1
            ElseIf iRango = 2 Then
                j = correlativo_inicial
            Else
                j = 1
            End If
            '''''''''''''''
            While i <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(i)(0).ToString
                'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
                'ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")
                prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
                prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
                prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
                prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
                prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
                prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")
                prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")
                prn.EscribeLinea("^PQ1,0,1,Y")
                prn.EscribeLinea("^XZ")
                prn.EscribeLinea(cadena)
                'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                j = j + 1
                i += 1
            End While
            prn.FinDoc()
            '
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function

    Public Function fnImprimirEtiquetasFAC_II() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            Dim I As Int16 = 0
            'Dim j As Int16 = 1
            'Dim j As Int16
            'If bRango Then
            '    j = 1
            'Else
            '    j = correlativo_inicial
            '    'Mod 21/08/2009 
            '    If j = 0 Then j = 1
            'End If
            ''''''''''''''''''''''''
            'Dim j As Int16 = 1
            Dim j As Int16
            If iRango = 1 Then
                j = 1
            ElseIf iRango = 2 Then
                j = correlativo_inicial
            Else
                j = 1
            End If


            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()


            'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
            'ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
            While I <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(I)(0).ToString
                prn.EscribeLinea("<STX><ESC>C0<ETX>")
                prn.EscribeLinea("<STX><ESC>k<ETX>")
                prn.EscribeLinea("<STX><SI>N60<ETX>")
                prn.EscribeLinea("<STX><SI>L197<ETX>")
                prn.EscribeLinea("<STX><SI>S20<ETX>")
                prn.EscribeLinea("<STX><SI>d0<ETX>")
                prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
                prn.EscribeLinea("<STX><SI>l8<ETX>")
                prn.EscribeLinea("<STX><SI>I3<ETX>")
                prn.EscribeLinea("<STX><SI>F20<ETX>")
                prn.EscribeLinea("<STX><SI>D0<ETX>")
                prn.EscribeLinea("<STX><SI>t0<ETX>")
                prn.EscribeLinea("<STX><SI>W394<ETX>")
                prn.EscribeLinea("<STX><SI>g1,567<ETX>")
                prn.EscribeLinea("<STX><ESC>P<ETX>")
                prn.EscribeLinea("<STX>E*;F*;<ETX>")
                prn.EscribeLinea("<STX>L1;<ETX>")
                prn.EscribeLinea("<STX>D0;<ETX>")
                prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h15;w15;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
                prn.EscribeLinea("<STX>D1;<ETX>")
                prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
                prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
                'prn.EscribeLinea("<STX>B3;o96,180;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
                prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
                prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
                prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
                prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
                prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
                prn.EscribeLinea("<STX>R<ETX>")
                prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
                prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")
                '
                prn.EscribeLinea(cadena)
                'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                'I = I + 1
                j = j + 1
                I += 1
            End While
            prn.FinDoc()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function

    Dim iRango As Byte = 0
    Public Function fnImprimirEtiquetasFAC_III() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            Dim I As Int16 = 0
            'Dim j As Int16 = 1
            Dim j As Int16
            ''''''''''''''
            'If bRango Then
            '    j = 1
            'Else
            '    j = correlativo_inicial
            '    'Mod 21/08/2009 
            '    If j = 0 Then j = 1
            'End If
            ''''''''''''''
            If iRango = 1 Then
                j = 1
            ElseIf iRango = 2 Then
                j = correlativo_inicial
            Else
                j = 1
            End If
            '
            While I <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(I)(0).ToString
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                prn.EscribeLinea("A30,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
                prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
                prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")
                prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")
                prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                j = j + 1
                I += 1
            End While
            prn.FinDoc()
            '
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function

    Private ObjReport As ClsLbTepsa.dtoFrmReport
    Const v_ca As String = "->CARGA ASEGURADA"
    Private Function ImprimirFactura() As Boolean
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        Dim flag As Boolean = False
        iSubTotal = 0
        iImpuesto = 0
        iTotal = 0
        Dim obj As New Imprimir
        Try
            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim sImpresora As String = ""
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0

            Dim montoLetras As String = ConvercionNroEnLetras(ObjIMPRESIONFACT_BOL.xTotal_Costo)
            Dim fecha_Systema As String() = Split(dtoUSUARIOS.m_sFecha, "/")
            Dim dia As String = fecha_Systema(0)
            Dim Mes As String = fecha_Systema(1)
            Dim Anio As String = fecha_Systema(2)

            Dim glosa3 As String = ""

            '    Dim GLOSA2 As String = ""
            '    Dim PESO As String = ""
            '    Dim PARCIAL As String = ""
            '    Dim CANTIDAD As String = ""

            '    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
            '        CANTIDAD = ObjIMPRESIONFACT_BOL.xCantidad_Peso & Chr(13)
            '        GLOSA2 = "BULTOS" & Chr(13)
            '        PESO = ObjIMPRESIONFACT_BOL.xTotalPeso & Chr(13)
            '        PARCIAL = Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "####,###,###.00") & Chr(13)
            '    End If

            '    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
            '        CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Vol & "" & Chr(13)
            '        GLOSA2 = GLOSA2 & "BULTOS (V.)" & Chr(13)
            '        PESO = PESO & ObjIMPRESIONFACT_BOL.xTotalVolumen & Chr(13)
            '        PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "####,###,###.00") & Chr(13)
            '    End If

            '    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
            '        CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Sobre & ""
            '        GLOSA2 = GLOSA2 & "SOBRES"
            '        PESO = PESO & ""
            '        PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "####,###,###.00")
            '    End If


            '    ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(GrdDetalleVenta(7, 2).Value)


            '    If CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString) > 400 Then

            '        glosa3 = "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON " & Chr(13) & _
            '        "EL GOBIERNO CENTRAL ,  SEGÚN D.L. Nº  940 - R.S. Nº 158 -2006-SUNAT  / D.S. " & Chr(13) & _
            '        "Nº 033-2006-MTC." & Chr(13) & _
            '        "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829."
            '    Else
            '        glosa3 = ""
            '    End If

            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 1, Me.CboProducto.SelectedValue)
            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            If flag Then
                Dim sConsignado As String = ObjIMPRESIONFACT_BOL.xConsignado.Trim.Replace(";", ",")
                'sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)

                obj.Inicializar()
                obj.Superior = iSuperior
                obj.Izquierda = Iizquierda
                obj.Impresora = sImpresora

                Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
                Dim iLong As Integer
                If Me.CboProducto.SelectedValue <> -100 Then
                    iLong = IIf(iTamaño = 0, 36, iTamaño)
                    y = iLong * pagina + 4
                    y += 1
                    i += 1
                    If es_carga_asegurada Then
                        obj.EscribirLinea(y + 1, 48, ObjIMPRESIONFACT_BOL.xAgenciaDestino & v_ca)
                    Else
                        obj.EscribirLinea(y + 1, 48, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                    End If

                    obj.EscribirLinea(y, 48, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                    obj.EscribirLinea(y + 2, 53, fnGetHora())

                    obj.EscribirLinea(y + 4, 8, dia)
                    obj.EscribirLinea(y + 4, 23, Mes)
                    obj.EscribirLinea(y + 4, 42, Anio)

                    obj.EscribirLinea(y + 5, 13, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 6, 13, ObjIMPRESIONFACT_BOL.xDireccionRemitente)
                    obj.EscribirLinea(y + 7, 13, ObjIMPRESIONFACT_BOL.xOrigen)
                    obj.EscribirLinea(y + 8, 13, sConsignado)
                    obj.EscribirLinea(y + 9, 13, ObjIMPRESIONFACT_BOL.xDireccionConsignado)

                    obj.EscribirLinea(y + 5, 66, ObjIMPRESIONFACT_BOL.xRuc)
                    obj.EscribirLinea(y + 7, 66, ObjIMPRESIONFACT_BOL.xDestino)

                    obj.EscribirLinea(y + 5, 105, ObjIMPRESIONFACT_BOL.xNroRef)
                    obj.EscribirLinea(y + 7, 105, ObjIMPRESIONFACT_BOL.xFormaPago)
                    obj.EscribirLinea(y + 8, 105, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)

                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                        obj.EscribirLinea(y + 12, 13, ObjIMPRESIONFACT_BOL.xCantidad_Peso)
                        obj.EscribirLinea(y + 12, 23, "BULTOS")
                        obj.EscribirLinea(y + 12, 92, ObjIMPRESIONFACT_BOL.xTotalPeso)
                    End If
                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                        obj.EscribirLinea(y + 13, 13, ObjIMPRESIONFACT_BOL.xCantidad_Vol)
                        obj.EscribirLinea(y + 13, 23, "BULTOS (V.)")
                        obj.EscribirLinea(y + 13, 92, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                    End If
                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                        obj.EscribirLinea(y + 14, 13, ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                        obj.EscribirLinea(y + 14, 23, "SOBRES")
                    End If
                    'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto) = 0 Then
                    '    obj.EscribirLinea(y + 14, 13, ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                    '    obj.EscribirLinea(y + 14, 23, "SOBRES")
                    'End If

                    If es_carga_asegurada Then
                        ObtieneMontosAsegurados(iSubTotal, iImpuesto, iTotal)
                        If ObjVentaCargaContado.v_MONTO_DESCUENTO > 0 Then
                            iSubTotal = iSubTotal * (1 - (ObjVentaCargaContado.v_MONTO_DESCUENTO / 100))
                        End If
                        iSubTotal = FormatNumber(iSubTotal, 2)
                        obj.EscribirLinea(y + 15, 23, "SEGURO CARGA")
                        obj.EscribirLinea(y + 15, 110, Format(CDbl(iSubTotal.ToString.ToString), "####,###,###0.00").PadLeft(10, " "))
                        Dim isub As String
                        isub = Format(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total - iSubTotal, "0.00")
                        obj.EscribirLinea(y + 12, 110, isub.ToString.PadLeft(10, " "))
                    Else
                        obj.EscribirLinea(y + 12, 110, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.ToString), "####,###,###0.00").PadLeft(10, " "))
                    End If

                    If CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString) > 400 Then
                        glosa3 = "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON " & Chr(13) & _
                        "EL GOBIERNO CENTRAL ,  SEGÚN D.L. Nº  940 - R.S. Nº 158 -2006-SUNAT  / D.S. " & Chr(13) & _
                        "Nº 033-2006-MTC." & Chr(13) & _
                        "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829."

                        obj.EscribirLinea(y + 16, 23, "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON")
                        obj.EscribirLinea(y + 17, 23, "EL GOBIERNO CENTRAL,SEGÚN D.L. Nº 940 - R.S. Nº 158 -2006-SUNAT/D.S.")
                        obj.EscribirLinea(y + 18, 23, "Nº 033-2006-MTC.")
                        obj.EscribirLinea(y + 19, 23, "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829.")
                    End If

                    obj.EscribirLinea(y + 21, 11, "Son:  " & montoLetras)
                    obj.EscribirLinea(y + 23, 54, dtoUSUARIOS.iLOGIN)
                    'obj.EscribirLinea(y + 22, 54, "19.00")

                    obj.EscribirLinea(y + 21, 85, "S/")
                    obj.EscribirLinea(y + 22, 85, "S/")
                    obj.EscribirLinea(y + 23, 85, "S/")

                    obj.EscribirLinea(y + 21, 110, ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(10, " "))
                    obj.EscribirLinea(y + 22, 110, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###0.00").PadLeft(10, " "))
                    obj.EscribirLinea(y + 23, 110, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###0.00").PadLeft(10, " "))
                Else
                    iLong = IIf(iTamaño = 0, 36, iTamaño)
                    y = iLong * pagina + 8
                    y += 1
                    i += 1
                    obj.EscribirLinea(y, 8, dia & " DE " & MonthName(Mes).ToString.ToUpper)
                    obj.EscribirLinea(y, 33, Anio)

                    obj.EscribirLinea(y, 66, Me.LblCiudad.Text)
                    obj.EscribirLinea(y, 108, ObjIMPRESIONFACT_BOL.xDestino)

                    If Me.CboTipoTarifa.SelectedIndex = 0 Then
                        obj.EscribirLinea(y + 2, 21, "X")
                    ElseIf Me.CboTipoTarifa.SelectedIndex = 1 Then
                        obj.EscribirLinea(y + 2, 31, "X")
                    End If

                    If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                        obj.EscribirLinea(y + 2, 67, "X")
                    Else
                        obj.EscribirLinea(y + 2, 77, "X")
                    End If

                    obj.EscribirLinea(y + 2, 108, ObjIMPRESIONFACT_BOL.TelefonoCliente(iCliente))

                    obj.EscribirLinea(y + 3, 16, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 3, 108, ObjIMPRESIONFACT_BOL.xRuc)
                    obj.EscribirLinea(y + 4, 16, ObjIMPRESIONFACT_BOL.xDireccionRemitente)

                    obj.EscribirLinea(y + 5, 16, sConsignado)
                    obj.EscribirLinea(y + 5, 108, TxtNroDocConsignado.Text.Trim)
                    obj.EscribirLinea(y + 6, 16, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    'obj.EscribirLinea(y + 7, 108, TxtTelfConsignado.Text.Trim)

                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                        obj.EscribirLinea(y + 11, 23, "BULTOS")
                        obj.EscribirLinea(y + 11, 90, ObjIMPRESIONFACT_BOL.xCantidad_Peso)
                        obj.EscribirLinea(y + 11, 102, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotalPeso), "###,###,###0.00").PadLeft(8, " "))
                        obj.EscribirLinea(y + 11, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "###,###,###0.00").PadLeft(10, " "))
                    End If
                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                        obj.EscribirLinea(y + 12, 23, "BULTOS (V.)")
                        obj.EscribirLinea(y + 12, 90, ObjIMPRESIONFACT_BOL.xCantidad_Vol)
                        obj.EscribirLinea(y + 12, 102, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotalVolumen), "###,###,###0.00").PadLeft(8, " "))
                        obj.EscribirLinea(y + 12, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "###,###,###0.00").PadLeft(10, " "))
                    End If

                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                        obj.EscribirLinea(y + 13, 23, "SOBRES")
                        obj.EscribirLinea(y + 13, 90, ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                        obj.EscribirLinea(y + 13, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "###,###,###0.00").PadLeft(10, " "))
                    End If

                    If Not Me.ChkArticulos.Checked And Not Me.ChkVolumetrico.Checked Then
                        If Val(GrdDetalleVenta("Sub Neto", 3).Value) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(GrdDetalleVenta("Sub Neto", 3).Value), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    ElseIf Me.ChkVolumetrico.Checked Then
                        If Val(Me.txtTotalSobre.Text) > 0 Then
                            obj.EscribirLinea(y + 13, 23, "SOBRES")
                            obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                            obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If

                        If Val(Me.txtMontoBase.Text) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.txtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    ElseIf Me.ChkArticulos.Checked Then
                        If Val(Me.txtTotalSobre.Text) > 0 Then
                            obj.EscribirLinea(y + 13, 23, "SOBRES")
                            obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                            obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If

                        If Val(Me.txtMontoBase.Text) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.txtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    End If

                    'If es_carga_asegurada Then
                    'ObtieneMontosAsegurados(iSubTotal, iImpuesto, iTotal)
                    'If ObjVentaCargaContado.v_MONTO_DESCUENTO > 0 Then
                    '    iSubTotal = iSubTotal * (1 - (ObjVentaCargaContado.v_MONTO_DESCUENTO / 100))
                    'End If
                    'iSubTotal = FormatNumber(iSubTotal, 2)
                    'obj.EscribirLinea(y + 15, 23, "SEGURO CARGA")
                    'obj.EscribirLinea(y + 15, 110, Format(CDbl(iSubTotal.ToString.ToString), "####,###,###0.00").PadLeft(10, " "))
                    'Dim isub As String
                    'isub = Format(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total - iSubTotal, "0.00")
                    'obj.EscribirLinea(y + 12, 110, isub.ToString.PadLeft(10, " "))
                    'End If

                    If CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString) > 400 Then
                        obj.EscribirLinea(y + 15, 0, "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON EL GOBIERNO CENTRAL")
                        obj.EscribirLinea(y + 16, 0, "SEGUN D.L. N. 940-R.S. N. 158-2006-SUNAT/D.S. N. 033-2006-MTC.")
                        obj.EscribirLinea(y + 17, 0, "SIRVASE DEPOSITAR A LA CUENTA DEL BANCO DE LA NACION Nº0019-002829.")
                    End If

                    obj.EscribirLinea(y + 17, 120, ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(10, " "))
                    obj.EscribirLinea(y + 18, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###0.00").PadLeft(10, " "))
                    obj.EscribirLinea(y + 20, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###0.00").PadLeft(10, " "))
                End If

                'obj.Comprimido = True
                'obj.Preliminar = True
                'obj.Tamaño = iLong
                'obj.Imprimir()
                'obj.Finalizar()

                'Dim frm As New FrmPreview
                'frm.Tamaño = iLong
                'frm.Documento = 1
                'frm.Text = "Factura"
                'frm.ShowDialog()
                '****************************************
                obj.Comprimido = True
                obj.Tamaño = iLong
                obj.Imprimir()
                obj.Finalizar()
            End If

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

    Public Function ImprimirBoleta() As Boolean
        Dim obj As New Imprimir
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        Dim blnCortesia As Boolean
        Try
            Dim HoraSistema As String = fnGetHora()
            Dim GLOSA2 As String = ""
            Dim PESO As String = ""
            Dim PARCIAL As String = ""
            Dim CANTIDAD As String = ""

            'Dim fecha_Systema As String() = Split(dtoUSUARIOS.m_sFecha, "/")
            Dim fecha_Systema As String()
            fecha_Systema = Split(FechaServidor.ToString.Substring(0, 10), "/")
            Dim dia As String = fecha_Systema(0)
            Dim Mes As String = fecha_Systema(1)
            Dim Anio As String = fecha_Systema(2)

            Dim glosa3 As String = ""

            '
            'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
            '    CANTIDAD = ObjIMPRESIONFACT_BOL.xCantidad_Peso & Chr(13)
            '    GLOSA2 = "BULTOS" & Chr(13)
            '    PESO = ObjIMPRESIONFACT_BOL.xTotalPeso & Chr(13)
            '    PARCIAL = Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "####,###,###.00") & Chr(13)
            'End If

            'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
            '    CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Vol & "" & Chr(13)
            '    GLOSA2 = GLOSA2 & "BULTOS (V.)" & Chr(13)
            '    PESO = PESO & ObjIMPRESIONFACT_BOL.xTotalVolumen & Chr(13)
            '    PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "####,###,###.00") & Chr(13)
            'End If

            'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
            '    CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Sobre & ""
            '    GLOSA2 = GLOSA2 & "SOBRES"
            '    PESO = PESO & ""
            '    PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "####,###,###.00")
            'End If

            'Dim Detalle As String = CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Vol)
            'Detalle = Detalle & "  SOBRE'S: " & CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString
            'GLOSA2 = "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString & Chr(13) & "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString
            ''"P_DETALLE;" & "CANTIDAD: " & CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Sobre) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Vol), _
            ''ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(dtGridViewBultos(7, 2).Value)
            'ObjReport.rutaRpt = PathFrmReport

            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 2, Me.CboProducto.SelectedValue)
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            Dim flag As Boolean
            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            If flag Then
                Dim sConsignado As String = ObjIMPRESIONFACT_BOL.xConsignado.Trim.Replace(";", ",")
                'sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)

                obj.Inicializar()
                obj.Impresora = sImpresora
                obj.Superior = iSuperior
                obj.Izquierda = Iizquierda

                Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
                Dim ilong As Integer

                blnCortesia = False
                If Me.CboFormaPago.SelectedIndex = 2 Then 'Me.grbPromocion.Visible And Me.lblPromocionDescuento.Text = 100 Then
                    blnCortesia = True
                End If

                'hlamas 02-02-2016
                'If Me.CboProducto.SelectedValue = -100 Then
                If dtoUSUARIOS.FormatoBoleta = "A" Then
                    ilong = IIf(iTamaño = 0, 18, iTamaño)
                    y = ilong * pagina + 4
                    y += 1
                    i += 1

                    obj.EscribirLinea(y, 6, ObjIMPRESIONFACT_BOL.xOrigen)
                    obj.EscribirLinea(y + 1, 6, ObjIMPRESIONFACT_BOL.xfecha_factura)
                    obj.EscribirLinea(y + 2, 6, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 3, 6, sConsignado)
                    obj.EscribirLinea(y + 4, 6, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    obj.EscribirLinea(y, 30, ObjIMPRESIONFACT_BOL.xDestino)

                    If es_carga_asegurada Then
                        obj.EscribirLinea(0, 30, v_ca)
                    End If

                    obj.EscribirLinea(y + 1, 30, HoraSistema)
                    obj.EscribirLinea(y + 1, 53, ObjIMPRESIONFACT_BOL.xFormaPago)
                    obj.EscribirLinea(y, 52, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)

                    'y+7=12
                    obj.EscribirLinea(y + 7, 16, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                    obj.EscribirLinea(y + 7, 46, ObjIMPRESIONFACT_BOL.xTotalPeso)
                    obj.EscribirLinea(y + 7, 56, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                    If es_carga_asegurada Then
                        obj.EscribirLinea(y + 7, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                    Else
                        obj.EscribirLinea(y + 7, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    End If

                    obj.EscribirLinea(y + 7, 84, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                    obj.EscribirLinea(y + 7, 105, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                    obj.EscribirLinea(y + 7, 112, ObjIMPRESIONFACT_BOL.xTotalPeso)
                    If es_carga_asegurada Then
                        obj.EscribirLinea(y + 7, 121, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                    Else
                        obj.EscribirLinea(y + 7, 121, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    End If

                    obj.EscribirLinea(y + 8, 16, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)
                    obj.EscribirLinea(y + 8, 84, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)

                    obj.EscribirLinea(y + 10, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    obj.EscribirLinea(y + 10, 121, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))

                    obj.EscribirLinea(0, 16, dtoUSUARIOS.iLOGIN)
                    obj.EscribirLinea(0, 90, dtoUSUARIOS.iLOGIN)

                    If es_carga_asegurada Then
                        ObtieneMontosAsegurados(iSubTotal, iImpuesto, iTotal)
                        iTotal = FormatNumber(iTotal, 2)
                        If ObjVentaCargaContado.v_MONTO_DESCUENTO > 0 Then
                            iTotal = iTotal * (1 - (ObjVentaCargaContado.v_MONTO_DESCUENTO / 100))
                        End If

                        obj.EscribirLinea(y + 9, 16, "SEGURO CARGA")
                        obj.EscribirLinea(y + 9, 67, Format(CDbl(iTotal), "###,###,###.00"))

                        obj.EscribirLinea(y + 9, 84, "SEGURO CARGA")
                        obj.EscribirLinea(y + 9, 121, Format(CDbl(iTotal), "###,###,###.00"))
                    End If

                    obj.EscribirLinea(3, 33, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                    obj.EscribirLinea(y, 89, ObjIMPRESIONFACT_BOL.xOrigen)
                    obj.EscribirLinea(y + 1, 89, ObjIMPRESIONFACT_BOL.xfecha_factura)
                    obj.EscribirLinea(y + 2, 89, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 3, 89, sConsignado)
                    obj.EscribirLinea(y + 4, 89, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    obj.EscribirLinea(y, 105, ObjIMPRESIONFACT_BOL.xDestino)
                    obj.EscribirLinea(y + 1, 114, HoraSistema)

                    obj.EscribirLinea(y + 1, 105, ObjIMPRESIONFACT_BOL.xFormaPago)
                    obj.EscribirLinea(y, 120, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)


                    obj.EscribirLinea(0, 0, ObjIMPRESIONFACT_BOL.xIdFactura)
                    obj.EscribirLinea(4, 30, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                    obj.EscribirLinea(3, 82, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                    obj.EscribirLinea(0, 82, ObjIMPRESIONFACT_BOL.xIdFactura)
                    obj.EscribirLinea(4, 82, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                Else
                    ilong = IIf(iTamaño = 0, 24, iTamaño)
                    y = ilong * pagina + 7
                    y += 1
                    i += 1

                    blnCortesia = False
                    If Me.CboFormaPago.SelectedIndex = 2 Then 'Me.grbPromocion.Visible And Me.lblPromocionDescuento.Text = 100 Then
                        blnCortesia = True
                    End If

                    obj.EscribirLinea(0, 17, CboProducto.Text) 'cambio

                    obj.EscribirLinea(y - 1, 6, dtoUSUARIOS.m_iNombreUnidadAgencia)
                    obj.EscribirLinea(y + 1, 6, ObjIMPRESIONFACT_BOL.xfecha_factura)
                    obj.EscribirLinea(y + 2, 6, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 3, 6, sConsignado)
                    obj.EscribirLinea(y + 4, 6, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    obj.EscribirLinea(y - 1, 30, ObjIMPRESIONFACT_BOL.xDestino)

                    If es_carga_asegurada Then
                        obj.EscribirLinea(0, 30, v_ca)
                    End If

                    obj.EscribirLinea(y + 1, 30, HoraSistema)
                    obj.EscribirLinea(y + 1, 55, CboFormaPago.Text)
                    obj.EscribirLinea(y - 1, 65, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)

                    'y+7=12
                    'hlamas 21-01-2016
                    If ChkArticulos.Checked Then
                        Dim intFilaArticulo As Integer = 7
                        For Each row As DataGridViewRow In Me.GrdDetalleVenta.Rows
                            If row.Cells(0).Value <> "ENTREGA" Then
                                If Val(row.Cells("cantidad").Value) > 0 Then
                                    obj.EscribirLinea(y + intFilaArticulo, 16, row.Cells("cantidad").Value)
                                    obj.EscribirLinea(y + intFilaArticulo, 23, row.Cells("Artículo").Value)
                                    obj.EscribirLinea(y + intFilaArticulo, 46, row.Cells("peso").Value)
                                    intFilaArticulo += 1
                                End If
                            End If
                        Next
                    End If

                    If Not ChkArticulos.Checked Then
                        obj.EscribirLinea(y + 7, 16, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                        obj.EscribirLinea(y + 7, 46, ObjIMPRESIONFACT_BOL.xTotalPeso)
                        obj.EscribirLinea(y + 7, 56, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                    End If

                    If es_carga_asegurada Then
                        obj.EscribirLinea(y + 7, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                    Else
                        obj.EscribirLinea(y + 7, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    End If

                    If Not ChkArticulos.Checked Then
                        obj.EscribirLinea(y + 7, 84, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                        obj.EscribirLinea(y + 7, 112, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                        obj.EscribirLinea(y + 7, 120, ObjIMPRESIONFACT_BOL.xTotalPeso)
                    End If

                    If es_carga_asegurada Then
                        obj.EscribirLinea(y + 7, 127, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                    Else
                        obj.EscribirLinea(y + 7, 127, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    End If

                    If Not ChkArticulos.Checked Then
                        If Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre) > 0 Then
                            obj.EscribirLinea(y + 8, 16, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)
                            obj.EscribirLinea(y + 8, 84, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)
                        End If
                    End If

                    If Not blnCortesia Then
                        obj.EscribirLinea(y + 13, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                        obj.EscribirLinea(y + 13, 127, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    Else
                        obj.EscribirLinea(y + 13, 67, "0.00")
                        obj.EscribirLinea(y + 13, 127, "0.00")
                    End If

                    obj.EscribirLinea(0, 10, dtoUSUARIOS.iLOGIN)


                    If blnCortesia Then
                        obj.EscribirLinea(0, 90, "CORTESIA")
                        obj.EscribirLinea(0, 81, "CORTESIA")
                    Else
                        obj.EscribirLinea(0, 90, dtoUSUARIOS.iLOGIN)
                    End If

                    If es_carga_asegurada Then
                        ObtieneMontosAsegurados(iSubTotal, iImpuesto, iTotal)
                        iTotal = FormatNumber(iTotal, 2)
                        If ObjVentaCargaContado.v_MONTO_DESCUENTO > 0 Then
                            iTotal = iTotal * (1 - (ObjVentaCargaContado.v_MONTO_DESCUENTO / 100))
                        End If

                        obj.EscribirLinea(y + 9, 16, "SEGURO CARGA")
                        obj.EscribirLinea(y + 9, 67, Format(CDbl(iTotal), "###,###,###.00"))

                        obj.EscribirLinea(y + 9, 84, "SEGURO CARGA")
                        obj.EscribirLinea(y + 9, 121, Format(CDbl(iTotal), "###,###,###.00"))
                    End If

                    obj.EscribirLinea(5, 52, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                    obj.EscribirLinea(y - 1, 92, dtoUSUARIOS.m_iNombreUnidadAgencia)
                    obj.EscribirLinea(y + 1, 90, ObjIMPRESIONFACT_BOL.xfecha_factura)
                    obj.EscribirLinea(y + 2, 92, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 3, 92, sConsignado)
                    obj.EscribirLinea(y + 4, 92, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    obj.EscribirLinea(y - 1, 109, ObjIMPRESIONFACT_BOL.xDestino)
                    obj.EscribirLinea(y + 1, 110, HoraSistema)

                    obj.EscribirLinea(y + 1, 127, Me.CboFormaPago.Text)
                    obj.EscribirLinea(y, 130, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)

                    obj.EscribirLinea(0, 0, ObjIMPRESIONFACT_BOL.xIdFactura)
                    obj.EscribirLinea(5, 30, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                    obj.EscribirLinea(3, 83, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                    obj.EscribirLinea(0, 83, ObjIMPRESIONFACT_BOL.xIdFactura)
                    obj.EscribirLinea(5, 83, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                    obj.EscribirLinea(0, 83, CboProducto.Text) 'cambio

                    If blnCortesia Then
                        obj.EscribirLinea(y + 9, 30, "SERVICIOS PRESTADOS A TITULO GRATUITO")
                        obj.EscribirLinea(y + 11, 30, "(SON: CERO y 0/100 SOLES)")
                    End If
                    'ilong = IIf(iTamaño = 0, 36, iTamaño)
                    'y = ilong * pagina + 8
                    'y += 1
                    'i += 1

                    'obj.EscribirLinea(y, 8, dia & " DE " & MonthName(Mes).ToString.ToUpper)
                    'obj.EscribirLinea(y, 33, Anio)

                    'obj.EscribirLinea(y, 66, Me.LblCiudad.Text)
                    'obj.EscribirLinea(y, 108, ObjIMPRESIONFACT_BOL.xDestino)

                    'If Me.CboTipoTarifa.SelectedIndex = 0 Then
                    '    obj.EscribirLinea(y + 2, 21, "X")
                    'ElseIf Me.CboTipoTarifa.SelectedIndex = 1 Then
                    '    obj.EscribirLinea(y + 2, 31, "X")
                    'End If

                    'If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                    '    obj.EscribirLinea(y + 2, 67, "X")
                    'Else
                    '    obj.EscribirLinea(y + 2, 77, "X")
                    'End If

                    'obj.EscribirLinea(y + 2, 108, ObjIMPRESIONFACT_BOL.TelefonoCliente(iCliente))

                    'obj.EscribirLinea(y + 3, 16, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    'obj.EscribirLinea(y + 3, 108, ObjIMPRESIONFACT_BOL.xRuc)
                    'obj.EscribirLinea(y + 4, 16, ObjIMPRESIONFACT_BOL.xDireccionRemitente)

                    'obj.EscribirLinea(y + 5, 16, sConsignado)
                    'obj.EscribirLinea(y + 5, 108, TxtNroDocConsignado.Text.Trim)
                    'obj.EscribirLinea(y + 6, 16, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    '' obj.EscribirLinea(y + 7, 108, TxtTelfConsignado.Text.Trim)

                    'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                    '    obj.EscribirLinea(y + 11, 23, "BULTOS")
                    '    obj.EscribirLinea(y + 11, 90, ObjIMPRESIONFACT_BOL.xCantidad_Peso)
                    '    obj.EscribirLinea(y + 11, 102, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotalPeso), "###,###,###0.00").PadLeft(8, " "))
                    '    obj.EscribirLinea(y + 11, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "###,###,###0.00").PadLeft(10, " "))
                    'End If
                    'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                    '    obj.EscribirLinea(y + 12, 23, "BULTOS (V.)")
                    '    obj.EscribirLinea(y + 12, 90, ObjIMPRESIONFACT_BOL.xCantidad_Vol)
                    '    obj.EscribirLinea(y + 12, 102, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotalVolumen), "###,###,###0.00").PadLeft(8, " "))
                    '    obj.EscribirLinea(y + 12, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "###,###,###0.00").PadLeft(10, " "))
                    'End If
                    'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                    '    obj.EscribirLinea(y + 13, 23, "SOBRES")
                    '    obj.EscribirLinea(y + 13, 90, ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                    '    obj.EscribirLinea(y + 13, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "###,###,###0.00").PadLeft(10, " "))
                    'End If

                    'If Not Me.ChkArticulos.Checked And Not Me.ChkVolumetrico.Checked Then
                    '    If Val(GrdDetalleVenta("Sub Neto", 3).Value) > 0 Then
                    '        obj.EscribirLinea(y + 14, 23, "BASE")
                    '        obj.EscribirLinea(y + 14, 120, Format(CDbl(GrdDetalleVenta("Sub Neto", 3).Value), "###,###,###0.00").PadLeft(10, " "))
                    '    End If
                    'ElseIf Me.ChkVolumetrico.Checked Then
                    '    If Val(Me.txtTotalSobre.Text) > 0 Then
                    '        obj.EscribirLinea(y + 13, 23, "SOBRES")
                    '        obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                    '        obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                    '    End If

                    '    If Val(Me.txtMontoBase.Text) > 0 Then
                    '        obj.EscribirLinea(y + 14, 23, "BASE")
                    '        obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.txtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                    '    End If
                    'ElseIf Me.ChkArticulos.Checked Then
                    '    If Val(Me.txtTotalSobre.Text) > 0 Then
                    '        obj.EscribirLinea(y + 13, 23, "SOBRES")
                    '        obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                    '        obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                    '    End If

                    '    If Val(Me.txtMontoBase.Text) > 0 Then
                    '        obj.EscribirLinea(y + 14, 23, "BASE")
                    '        obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.txtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                    '    End If
                    'End If


                    ''obj.EscribirLinea(y + 17, 120, ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(10, " "))
                    ''obj.EscribirLinea(y + 18, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###0.00").PadLeft(10, " "))
                    'obj.EscribirLinea(y + 17, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###0.00").PadLeft(10, " "))

                End If
                obj.Comprimido = True
                obj.Tamaño = ilong
                obj.Imprimir()
                obj.Finalizar()

                'obj.Comprimido = True
                'obj.Preliminar = True
                'obj.Tamaño = ilong
                'obj.Imprimir()
                'obj.Finalizar()

                'Dim frm As New FrmPreview
                'frm.Tamaño = ilong
                'frm.Documento = 1
                'frm.Text = "Boleta"
                'frm.ShowDialog()
            End If

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function
#End Region 'FIN GRABAR

#Region "NUEVO"

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Me.fnNUEVO()
    End Sub

    Public Function fnNUEVO() As Boolean
        Try
            lblTotalPagado.Visible = False
            lblTotalVenta.Visible = False
            lblVuelto.Visible = False
            txtTotalPagado.Visible = False
            txtTotalVenta.Visible = False
            txtVuelto.Visible = False
            bDescuento = False
            bTieneLineaCredito = False
            sDocCliente = ""
            iOficinaDestino = 0
            TxtCiudadDestino.Text = ""
            Me.CboTipoEntrega.SelectedValue = 0
            RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            TxtNroDocCliente.Text = ""
            AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            Me.LimpiarDatosGeneral()
            Me.CboAgenciaDest.Items.Clear()
            TipoGrid_ = FormatoGrid.BULTO
            Me.DiseñaGrdDetalleVenta()
            Me.FormatoGrdDetalleVenta()
            ChkArticulos.Enabled = False
            ChkArticulos.Checked = False
            ChkVolumetrico.Checked = False
            objComprobanteAsegurada = Nothing
            ReDim objComprobanteAsegurada(19)
            '****carga asegurada***********
            es_carga_asegurada = False
            iTotal_CA = 0
            '******************************
            CboProducto.SelectedIndex = 0
            CboFormaPago.SelectedIndex = 0
            Me.TxtCiudadDestino.Focus()
            '**********
            bClienteModificado = False
            bDireccionModificada = False
            bContactoModificado = False
            bConsignadoModificado = False
            bDirecConsigMod = False

            bConsignadoNuevo = True
            bClienteNuevo = True
            sNombresCli = "" : sApCli = "" : sAmCli = "" : sTelfCliente = "" : sCliente = ""

            'hlamas 16-05-2017
            intCortesia = 0
            strTipoPago = ""

            Me.LimpiarCliente()
            Me.LimpiarConsignado()
            '**********
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
#End Region 'OK

#Region "BTN_CARGA_ASEGURADA"
    Private Sub BtnCargAseg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCargAseg.Click
        Try
            If ChkArticulos.Checked = False Then
                Dim A As New FrmDocCliente

                A.sFecha = LblFechaServidor.Text
                A.bVentaGrabada = recuperando_datos_contado
                A.sDocCliente = sDocCliente
                Acceso.Asignar(A, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    A.ShowDialog()
                    agregar_documentos_asegurados()
                Else
                    MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Dim es_carga_asegurada As Boolean
    Dim iSub_Total_CA As Double = 0, iImpuesto_CA As Double = 0, iTotal_CA As Double = 0
    Dim bMontoMinimo As Boolean
    Dim objCargaAsegurada As New ClsLbTepsa.dtoCargaAsegurada
    Dim fArticulo As Boolean = False
    Dim iFilas As Integer
    Private Sub agregar_documentos_asegurados()
        Try
            Dim monto_carga_asegurada As Double = 0
            Dim iContador As Integer = 0

            es_carga_asegurada = False
            iSub_Total_CA = 0
            iImpuesto_CA = 0
            iTotal_CA = 0

            For k As Integer = 0 To GrdDocumentosCliente.Rows().Count - 1
                GrdDocumentosCliente(3, k).Value = ""
            Next

            For i As Integer = 0 To 18 Step 1
                If Not (objComprobanteAsegurada(iContador).NRO_SERIE Is Nothing) Then
                    If GrdDocumentosCliente.Rows.Count - 1 = i Then
                        GrdDocumentosCliente.Rows.Add()
                    End If
                End If
                iContador += 1
            Next

            For i As Integer = 0 To 18 Step 1
                If Not ((objComprobanteAsegurada(i).NRO_SERIE Is Nothing) And (objComprobanteAsegurada(i + 1).NRO_SERIE Is Nothing)) Then
                    GrdDocumentosCliente.Rows(i).Cells(3).Value = objComprobanteAsegurada(i).NRO_SERIE + "-" + objComprobanteAsegurada(i).NRO_DOCU
                    iFilas += 1
                    es_carga_asegurada = True
                ElseIf Not (objComprobanteAsegurada(i).NRO_SERIE Is Nothing) Then
                    Dim row0 As String() = {"", _
                    "", _
                    objComprobanteAsegurada(i).NRO_SERIE + "-" + objComprobanteAsegurada(i).NRO_DOCU, _
                    "-"}
                    GrdDocumentosCliente.Rows().Add(row0)
                    es_carga_asegurada = True
                End If
                If objComprobanteAsegurada(i).TIPO = 1 Or objComprobanteAsegurada(i).TIPO = 0 Then
                    monto_carga_asegurada = FormatNumber(monto_carga_asegurada + (Val(objComprobanteAsegurada(i).MONTO_SUB_TOTAL) * Val(objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO)) * Val(objComprobanteAsegurada(i).PORCEN) / 100, 2)
                ElseIf objComprobanteAsegurada(i).TIPO = 2 Then
                    Dim iSub As Double = objComprobanteAsegurada(i).PORCEN * Val(objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO) / (1 + dtoUSUARIOS.vImpuesto)
                    monto_carga_asegurada = FormatNumber(monto_carga_asegurada + iSub, 2)
                End If
            Next

            Dim intFila As Integer
            If es_carga_asegurada = True Then
                If ChkVolumetrico.Checked = False Then
                    ObtieneMontosAsegurados(iSub_Total_CA, iImpuesto_CA, iTotal_CA)
                    If iTotal_CA > 0 Then
                        'hlamas 25-11-2013
                        'If GrdDetalleVenta.Rows.Count < 5 Then
                        intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                        If intFila = 0 Then
                            GrdDetalleVenta.Rows.Add()
                            intFila = GrdDetalleVenta.Rows.Count - 1
                        End If
                        'End If
                        GrdDetalleVenta(0, intFila).Value = "CARGA SEGURO"
                        GrdDetalleVenta(2, intFila).Value = "0.00"
                        GrdDetalleVenta(3, intFila).Value = "0.00"
                        If bTarifarioGeneral And bContado Then
                            GrdDetalleVenta(4, intFila).Value = FormatNumber(iTotal_CA, 2)
                        Else
                            GrdDetalleVenta(4, intFila).Value = FormatNumber(iSub_Total_CA, 2)
                        End If
                    End If
                ElseIf ChkVolumetrico.Checked = True Then
                    ObtieneMontosAsegurados(iSub_Total_CA, iImpuesto_CA, iTotal_CA)
                    If iTotal_CA > 0 Then
                        If GrdDetalleVenta.Rows.Count < 2 Then
                            GrdDetalleVenta.Rows.Add()
                            GrdDetalleVenta.Rows(1).ReadOnly = True
                        End If
                        GrdDetalleVenta(0, 1).Value = "CA"
                        GrdDetalleVenta(2, 1).Value = "0.00"
                        GrdDetalleVenta(3, 1).Value = "0.00"
                        GrdDetalleVenta(4, 1).Value = "0.00"
                        GrdDetalleVenta(5, 1).Value = "0.00"
                        GrdDetalleVenta(6, 1).Value = "0.00"
                        If bTarifarioGeneral And bContado Then
                            GrdDetalleVenta(7, 1).Value = FormatNumber(iTotal_CA, 2)
                        Else
                            GrdDetalleVenta(7, 1).Value = FormatNumber(iSub_Total_CA, 2)
                        End If
                    End If
                End If
            Else
                If ChkVolumetrico.Checked = False Then
                    intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                    'If GrdDetalleVenta.Rows.Count = 5 Then
                    If intFila > 0 Then
                        GrdDetalleVenta.Rows.RemoveAt(intFila)
                    End If
                ElseIf ChkVolumetrico.Checked = True Then
                If GrdDetalleVenta.Rows.Count = 2 Then
                    GrdDetalleVenta.Rows.RemoveAt(1)
                End If
            End If
            'Me.Timer2.Stop()
            End If
            If recuperando_datos_contado = False Then
                'fnTotalPago()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
#End Region 'OK

    Dim TarifaPublica_ As Boolean
    Dim TarifLineaCredito_ As Boolean
    Dim isDescuento_ As Boolean
    Sub tarifarioEnMemoria()
        GrdDetalleVenta(3, 0).Value = tarifa_Peso
        GrdDetalleVenta(3, 1).Value = tarifa_Volumen
        GrdDetalleVenta(3, 2).Value = tarifa_Sobre
        GrdDetalleVenta(3, 3).Value = Monto_Base
        GrdDetalleVenta(4, 3).Value = Monto_Base
    End Sub
#End Region

#Region "FUNCIONES DE VALIDACIONES"
    'Funcion Valida Solo [Numero]
    Public Function ValidaNumero(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[0-9\b]") '("^\d+$")  
        If re.IsMatch(txtStr.ToString()) Then
            ValidaNumero = True
        Else
            ValidaNumero = False
        End If
    End Function

    'Funcion Valida Solo [Texto]
    Public Function ValidaTexto(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[ A-ZñÑa-z\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidaTexto = True
        Else
            ValidaTexto = False
        End If
    End Function

    'Funcion valida [Letra y Numero]
    Public Function ValidaNroTexto(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[ A-ZñÑa-z0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidaNroTexto = True
        Else
            ValidaNroTexto = False
        End If
    End Function

    Public Function fnTECHO(ByVal monto As String) As String
        Dim monto_total As String = monto
        Try
            Dim varMonto() As String = Split(monto_total, ".")
            If varMonto.Length > 1 Then
                If Val(varMonto(1).ToString) < 50 Then '12/03/2008 - Puedo modificarse acá poniendo igual 
                    monto_total = varMonto(0) & ".50"
                Else
                    Dim Entero As String() = Split(varMonto(0).ToString, ",")
                    Dim i As Integer = 0
                    monto_total = varMonto(0).ToString
                    If Entero.Length >= 1 Then
                        monto_total = ""
                    End If
                    For i = 0 To Entero.Length - 1
                        monto_total = monto_total & Entero(i).ToString
                    Next
                    'monto_total = Val(monto_total) + 1   -- 01/09/2010 
                    If Val(varMonto(1)) > 500 Then
                        monto_total = Val(monto_total) + 1
                    Else
                        monto_total = Val(monto_total) + 0.5
                    End If
                    ' monto_total = monto_total.ToString & ".00"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        If monto Mod 0.5 = 0 Then
            Return monto
        Else
            Return monto_total
        End If
    End Function

#End Region

    '*****ultimo codigos***********
    'Private Sub GrdDocumentosCliente_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdDocumentosCliente.Enter
    '    GrdDocumentosCliente.ClearSelection()
    '    GrdDetalleVenta.ClearSelection()
    'End Sub

    'Private Sub GrdDetalleVenta_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdDetalleVenta.Enter
    '    GrdDocumentosCliente.ClearSelection()
    '    GrdDetalleVenta.ClearSelection()
    'End Sub

    Private Sub GrdDocumentosCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdDocumentosCliente.LostFocus
        GrdDocumentosCliente.ClearSelection()
    End Sub


    Private Sub GrdDetalleVenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdDetalleVenta.LostFocus
        GrdDetalleVenta.ClearSelection()
    End Sub

    Private Sub GrdDocumentosCliente_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles GrdDocumentosCliente.RowsAdded
        GrdDocumentosCliente.ClearSelection()
        GrdDetalleVenta.ClearSelection()
    End Sub

    Private Sub GrdDetalleVenta_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles GrdDetalleVenta.RowsAdded
        GrdDetalleVenta.ClearSelection()
        GrdDocumentosCliente.ClearSelection()
    End Sub

    Private Sub GrdDetalleVenta_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles GrdDetalleVenta.RowsRemoved
        GrdDetalleVenta.ClearSelection()
        GrdDocumentosCliente.ClearSelection()
    End Sub

    Private Sub RbtDocumento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtDocumento.CheckedChanged, RbtNombre.CheckedChanged
        Me.TxtCliente.Text = ""
        'Me.TxtNroDocCliente.Text = ""
        'Me.TxtNroDocCliente.Tag = ""
        'Me.TxtNomCliente.Text = ""

        If CType(sender, RadioButton).Name = "RbtDocumento" Then
            Me.TxtCliente.MaxLength = 11
        Else
            Me.TxtCliente.MaxLength = 50
        End If
        Me.TxtCliente.Focus()
    End Sub


    Private Sub TxtCliente_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCliente.Enter
        Me.TxtCliente.SelectAll()
    End Sub

    Private Sub TxtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress
        If Me.RbtDocumento.Checked Then
            If Not ValidarLetraNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetra(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub RbtDocumento3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtDocumento3.CheckedChanged, RbtNombre3.CheckedChanged
        Me.TxtConsignado.Text = ""
        'Me.TxtNroDocConsignado.Text = ""
        'Me.TxtNroDocConsignado.Tag = ""
        'Me.TxtNombConsignado.Text = ""

        If CType(sender, RadioButton).Name = "RbtDocumento3" Then
            Me.TxtConsignado.MaxLength = 11
        Else
            Me.TxtConsignado.MaxLength = 50
        End If
        Me.TxtConsignado.Focus()
    End Sub

    Private Sub TxtNroDocCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroDocCliente.TextChanged
        Try
            CONTROL = 2
            objGuiaEnvio.iIDPERSONA = 0
            bCondicion = False
            objGuiaEnvio.iPeso_Maximo = 0
            objGuiaEnvio.iPrecio_cond_Peso = 0
            If iOpcion <> 2 Then
                LblTipoComprobante.Text = "BOLETA"
            End If

            If fnVALIDARDOCUMENTOS() = False Then
                TarifaPublica_ = True
                bDescuento = False
                bTieneLineaCredito = False
            End If

            'If Me.ChkCliente2.Checked Then
            '    Me.ChkCliente2.Checked = False
            'End If
            sDocCliente = TxtNroDocCliente.Text.Trim
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim iID_Persona As Integer
    Sub Mostrar(ByVal ds As DataSet)
        bClienteNuevo = False
        Me.LimpiarDatosCliente()

        '**linea de credito**   
        If ds.Tables(4).Rows.Count > 0 Then
            If CType(ds.Tables(4).Rows(0)("ES_ACTIVO"), Boolean) Then
                bTieneLineaCredito = True
            Else
                bTieneLineaCredito = False
            End If
        Else
            bTieneLineaCredito = False
        End If

        '**Articulos**
        DtArticulos = ds.Tables(5).Copy
        If ds.Tables(5).Rows.Count > 0 Then
            ChkArticulos.Enabled = True
        Else
            ChkArticulos.Enabled = False
            'ChkArticulos.Checked = False
        End If

        '**Descuento****
        If CboProducto.SelectedValue <> 6 Then '-->Diferente De Carga Acompañada
            iDescuento = IIf(ds.Tables(6).Rows(0)("porcentage_descuento") <> 0, ds.Tables(6).Rows(0)("porcentage_descuento"), 0)
            If iDescuento <> 0 Then
                iDescuento = iDescuento / 100
                bDescuento = True
            Else
                bDescuento = False
            End If
        End If

        'hlamas 04-12-2013
        'If bDescuento = False Then
        ObtieneDatosDescuento()
        'End If

        'hlamas 05-12-2013
        dblMontoEntregaDomicilio = ObtieneMontoVenta(DgvLista.CurrentRow.Cells("idtipo_comprobante").Value, DgvLista.CurrentRow.Cells("Idfactura").Value)
        If dblMontoEntregaDomicilio > 0 Then
            AgregarItemVenta("ENTREGA", GrdDetalleVenta)
            Dim intFila As Integer = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
            GrdDetalleVenta("sub neto", intFila).Value = dblMontoEntregaDomicilio
        End If

        '******************************************************
        iID_Persona = ds.Tables(0).Rows(0).Item("idpersona")
        Dim iProceso As Integer = ds.Tables(0).Rows(0).Item("id_proceso")
        'hlamas 17-07-2015
        If Me.CboProducto.SelectedValue = 10 Then
            iProceso = 10
        ElseIf Me.CboProducto.SelectedValue = 81 Then
            iProceso = 81
        ElseIf Me.CboProducto.SelectedValue = 82 Then
            iProceso = 82
        End If
        '******************************************************
        RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
        If iProceso = 0 Then '------> Normal
            objGuiaEnvio.TarifaPyme_ = False
            If CboProducto.SelectedValue = 6 Then
                Me.CboProducto.SelectedValue = 6
            ElseIf CboProducto.SelectedValue = 8 And bTieneLineaCredito = False Then
                Me.CboProducto.SelectedValue = 8
            Else
                Me.CboProducto.SelectedValue = iProceso
            End If
            Me.RefreshNroDocumento(0)
        ElseIf iProceso = 7 Then '--> Pyme  
            If CboProducto.SelectedValue = 6 Then
                Me.CboProducto.SelectedValue = 6
            Else
                Me.CboProducto.SelectedValue = iProceso
            End If
            Me.objGuiaEnvio.TarifaPyme_ = True '--> indica q traera tarifa Pyme                                      
            Me.RefreshNroDocumento(7)
        ElseIf iProceso = 8 Then '--> Masiva
            objGuiaEnvio.TarifaPyme_ = False
            Me.CboProducto.SelectedValue = iProceso
            objGuiaEnvio.TarifaMasiva_ = True
            Me.RefreshNroDocumento(8)
        ElseIf iProceso = 10 Then '------> Normal
            objGuiaEnvio.TarifaPyme_ = False
            If CboProducto.SelectedValue = 6 Then
                Me.CboProducto.SelectedValue = 6
            ElseIf CboProducto.SelectedValue = 8 And bTieneLineaCredito = False Then
                Me.CboProducto.SelectedValue = 8
            Else
                Me.CboProducto.SelectedValue = iProceso
            End If
            Me.RefreshNroDocumento(10)
        End If
        AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
        '********************************************************

        'Me.TxtNroDocCliente.Tag = ds.Tables(0).Rows(0).Item("idpersona")
        Me.TxtNroDocCliente.Text = ds.Tables(0).Rows(0).Item("nu_docu_suna").ToString.Trim
        Me.TxtNomCliente.Text = ds.Tables(0).Rows(0).Item("razon_social").ToString.Trim
        Me.TxtTelfCliente.Text = IIf(IsDBNull(dtCliente.Rows(0).Item("telefono")), "", dtCliente.Rows(0).Item("telefono"))
        sEmail = IIf(IsDBNull(dtCliente.Rows(0).Item("email")), "", dtCliente.Rows(0).Item("email"))

        '--recuperando datos cliente--
        sNombresCli = IIf(IsDBNull(dtCliente.Rows(0).Item("nombres")), "", dtCliente.Rows(0).Item("nombres"))
        sApCli = IIf(IsDBNull(dtCliente.Rows(0).Item("ap")), "", dtCliente.Rows(0).Item("ap"))
        sAmCli = IIf(IsDBNull(dtCliente.Rows(0).Item("am")), "", dtCliente.Rows(0).Item("am"))
        sTelfCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("telefono")), "", dtCliente.Rows(0).Item("telefono"))
        sCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("razon_social")), "", dtCliente.Rows(0).Item("razon_social"))
        iID_TipoDocCli = ds.Tables(0).Rows(0).Item("tipo").ToString.Trim

        With Me.CboDireccion
            dtDireccion = ds.Tables(1)
            .DataSource = dtDireccion
            .DisplayMember = "direccion"
            .ValueMember = "iddireccion_consignado"

            If .Items.Count > 2 Then
                .SelectedIndex = 0
                '.DroppedDown = True
                .Focus()
                Me.Cursor = Cursors.Default
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
                .Focus()
            Else
                .SelectedIndex = 1
                IdDireccionOrigen = CboDireccion.SelectedValue
                .Focus()
            End If
        End With

        'RemoveHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged
        If Not Me.TxtCliente.Text.Trim.Length > 0 Then
            With Me.CboDireccion2
                dtDireccion2 = ds.Tables(2)
                .DataSource = dtDireccion2
                .DisplayMember = "direccion"
                .ValueMember = "iddireccion_consignado"

                If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                    If .Items.Count > 2 Then
                        .SelectedIndex = 0
                        '.DroppedDown = True
                        '.Focus()
                        Me.Cursor = Cursors.Default
                    ElseIf .Items.Count = 1 Then
                        .SelectedIndex = 0
                    Else
                        .SelectedIndex = 1
                    End If
                Else
                    Me.ConvertirTipoEntrega(Me.CboTipoEntrega.SelectedValue)
                End If
            End With
        End If
        'AddHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged

        'RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
        With Me.CboContacto
            dtContacto = ds.Tables(3)
            dtContactoParalelo = ds.Tables(3).Copy
            .DataSource = dtContacto
            .DisplayMember = "nombres"
            .ValueMember = "idcontacto_persona"
            If .Items.Count > 2 Then
                .SelectedIndex = 0
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
            Else
                .SelectedIndex = 1
            End If
            Me.ChkCliente1.Tag = DBNull.Value
        End With
        ' AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged

        'If TipoComprobante = 1 Then
        'CboContacto.Enabled = True
        'ChkCliente1.Enabled = True
        'Else
        'ChkCliente1.Enabled = False
        'CboContacto.Enabled = False
        'CboContacto.SelectedIndex = 0
        'End If
    End Sub

    Sub DespliegaContacto()
        Me.CboContacto.DroppedDown = True
        Me.CboContacto.Focus()
        Me.Cursor = Cursors.Default
    End Sub

    Dim IdDireccionOrigen As Integer
    Private Sub CboDireccion_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDireccion.SelectedValueChanged
        If iDespliegue = 1 Then
            If CboDireccion.SelectedIndex > 0 AndAlso CboContacto.SelectedIndex = 0 And TipoComprobante = 1 Then
                Me.DespliegaContacto()
            End If
        End If
        iDespliegue = 0
    End Sub

    Private Sub CboDireccion_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDireccion.SelectionChangeCommitted
        iDespliegue = 1
    End Sub

    Dim idcontacto As Integer
    Private Sub CboContacto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboContacto.SelectedIndexChanged
        If iOpcion = 2 Then
            RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
            Me.CboContacto.SelectedValue = ObjVentaCargaContado.v_IDPERSONA_ORIGEN
            AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
            Return
        End If
        If Not IsReference(CboContacto.SelectedValue) Then
            If Not bContactoModificado Then
                idcontacto = CboContacto.SelectedValue
            End If
            Me.TxtNroDocContacto.Text = IIf(IsDBNull(dtContacto.Rows(CboContacto.SelectedIndex).Item("nrodocumento")), "", dtContacto.Rows(CboContacto.SelectedIndex).Item("nrodocumento"))
        ElseIf Me.CboContacto.DataSource Is Nothing Then
            If Me.CboContacto.Items.Count > 1 Then
                Dim iFila As Integer = IIf(CboContacto.SelectedIndex < 0, 0, CboContacto.SelectedIndex)
                Me.TxtNroDocContacto.Text = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nrodocumento")), "", dtContacto.Rows(iFila).Item("nrodocumento"))
            End If
        End If

        RemoveHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
        If Me.CboContacto.SelectedIndex = 0 Then
            Me.ChkCliente1.Checked = False
        Else
            'Me.ChkCliente1.Checked = IIf(IsDBNull(Me.ChkCliente1.Tag), Me.ChkCliente1.Checked, Me.ChkCliente1.Tag)
            Me.ChkCliente1.Checked = IIf(TxtNroDocCliente.Text = TxtNroDocContacto.Text, 1, 0)
        End If
        AddHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
    End Sub

    Dim sNombresCli As String = "", sApCli As String = "", sAmCli As String = "", sTelfCliente As String = "", sCliente As String = ""
    Dim iID_TipoDocCli As Integer = 0
    Private Sub BtnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCliente.Click
        Try
            If iOpcion = 2 Then
                Return
            End If
            bvalidacionGrid = False
            Me.Cursor = Cursors.AppStarting
            Dim frm As New FrmCliente2
            frm.iProducto = Me.CboProducto.SelectedValue
            frm.iFicha = 1
            Dim iFila As Integer = 0
            Dim sNumero As String = ""
            Dim iTipo As Integer
            Dim iDepartamento As Integer
            Dim iProvincia As Integer
            Dim iDistrito As Integer
            Dim iId_via As Integer
            Dim sVia As String = ""
            Dim sNumero2 As String = ""
            Dim sManzana As String = ""
            Dim sLote As String = ""
            Dim iId_Nivel As Integer
            Dim sNivel As String = ""
            Dim iId_Zona As Integer
            Dim sZona As String = ""
            Dim iId_Clasificacion As Integer
            Dim sClasificacion As String = ""
            Dim iTipo2 As Integer
            Dim sNumero3 As String = ""
            Dim sContacto As String = ""
            Dim sNombresCont As String = ""
            Dim sApCont As String = ""
            Dim sAmCont As String
            Dim bEsCliente As Boolean = False

            If Me.TxtNroDocCliente.Text.Trim.Length > 0 Or Me.TxtNomCliente.Text.Trim.Length > 0 Then
                If Not bClienteNuevo Then
                    sNumero = IIf(IsDBNull(dtCliente.Rows(iFila).Item("nu_docu_suna")), "", dtCliente.Rows(iFila).Item("nu_docu_suna"))
                    sCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("razon_social")), "", dtCliente.Rows(iFila).Item("razon_social"))
                    'If Not bBoleto Then
                    iTipo = IIf(IsDBNull(dtCliente.Rows(iFila).Item("tipo")), "", dtCliente.Rows(iFila).Item("tipo"))
                    sEmail = IIf(IsDBNull(dtCliente.Rows(iFila).Item("email")), "", dtCliente.Rows(iFila).Item("email"))
                    'Else
                    'iTipo = IIf(IsDBNull(dtCliente.Rows(iFila).Item("tipo")), 9, Me.ObtieneTipoDocumento(dtCliente.Rows(iFila).Item("tipo")))
                    'End If
                    sTelfCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("telefono")), "", dtCliente.Rows(iFila).Item("telefono"))
                    If iTipo = 1 Then
                        sNombresCli = ""
                        sApCli = ""
                        sAmCli = ""
                    Else
                        sNombresCli = IIf(IsDBNull(dtCliente.Rows(0).Item("nombres")), "", dtCliente.Rows(0).Item("nombres"))
                        sApCli = IIf(IsDBNull(dtCliente.Rows(0).Item("ap")), "", dtCliente.Rows(0).Item("ap"))
                        sAmCli = IIf(IsDBNull(dtCliente.Rows(0).Item("am")), "", dtCliente.Rows(0).Item("am"))
                        'If sNombresCli.Trim.Length = 0 Then
                        '    sNombresCli = sCliente
                        'End If
                    End If

                    iFila = Me.CboDireccion.SelectedIndex
                    iDepartamento = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("iddepartamento")), 0, dtDireccion.Rows(iFila).Item("iddepartamento"))
                    iProvincia = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("idprovincia")), 0, dtDireccion.Rows(iFila).Item("idprovincia"))
                    iDistrito = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("iddistrito")), 0, dtDireccion.Rows(iFila).Item("iddistrito"))
                    iId_via = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_via")), 0, dtDireccion.Rows(iFila).Item("id_via"))
                    sVia = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("via")), "", dtDireccion.Rows(iFila).Item("via"))
                    sNumero2 = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("numero")), "", dtDireccion.Rows(iFila).Item("numero"))
                    sManzana = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("manzana")), "", dtDireccion.Rows(iFila).Item("manzana"))
                    sLote = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("lote")), "", dtDireccion.Rows(iFila).Item("lote"))
                    iId_Nivel = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_nivel")), 0, dtDireccion.Rows(iFila).Item("id_nivel"))
                    sNivel = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("nivel")), "", dtDireccion.Rows(iFila).Item("nivel"))
                    iId_Zona = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_zona")), 0, dtDireccion.Rows(iFila).Item("id_zona"))
                    sZona = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("zona")), "", dtDireccion.Rows(iFila).Item("zona"))
                    iId_Clasificacion = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("Id_Clasificacion")), 0, dtDireccion.Rows(iFila).Item("Id_Clasificacion"))
                    sClasificacion = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("Clasificacion")), "", dtDireccion.Rows(iFila).Item("Clasificacion"))

                    iFila = Me.CboContacto.SelectedIndex
                    iTipo2 = IIf(IsDBNull(dtContacto.Rows(iFila).Item("idtipo_documento_contacto")), 0, dtContacto.Rows(iFila).Item("idtipo_documento_contacto"))
                    sNumero3 = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nrodocumento")), "", dtContacto.Rows(iFila).Item("nrodocumento"))
                    sContacto = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nombres")), "", dtContacto.Rows(iFila).Item("nombres"))
                    sNombresCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nombre")), "", dtContacto.Rows(iFila).Item("nombre")) 'new
                    sApCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("apepat")), "", dtContacto.Rows(iFila).Item("apepat"))
                    sAmCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("apemat")), "", dtContacto.Rows(iFila).Item("apemat"))

                    If sContacto.Trim.Length > 0 Then
                        If sContacto.Trim.Substring(0, 1) = "(" Then
                            sContacto = ""
                        End If
                    Else
                        sContacto = ""
                    End If
                    bEsCliente = Me.ChkCliente1.Checked
                Else
                    sNumero = IIf(IsDBNull(dtCliente.Rows(0).Item("nu_docu_suna")), "", dtCliente.Rows(0).Item("nu_docu_suna"))
                    sCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("razon_social")), "", dtCliente.Rows(0).Item("razon_social"))
                    sEmail = IIf(IsDBNull(dtCliente.Rows(iFila).Item("email")), "", dtCliente.Rows(iFila).Item("email"))
                    If Not bBoleto Then
                        iTipo = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
                    Else
                        iTipo = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dtCliente.Rows(0).Item("tipo")))
                    End If
                    sTelfCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("telefono")), "", dtCliente.Rows(iFila).Item("telefono"))
                    If iTipo = 1 Then
                        sNombresCli = ""
                        sApCli = ""
                        sAmCli = ""
                    Else
                        sNombresCli = IIf(IsDBNull(dtCliente.Rows(0).Item("nombres")), "", dtCliente.Rows(0).Item("nombres"))
                        sApCli = IIf(IsDBNull(dtCliente.Rows(0).Item("ap")), "", dtCliente.Rows(0).Item("ap"))
                        sAmCli = IIf(IsDBNull(dtCliente.Rows(0).Item("am")), "", dtCliente.Rows(0).Item("am"))
                        sTelfCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("telefono")), "", dtCliente.Rows(iFila).Item("telefono"))
                    End If
                    If Not bBoleto Then
                        iFila = Me.CboDireccion.SelectedIndex
                        iDepartamento = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("iddepartamento")), 0, dtDireccion.Rows(iFila).Item("iddepartamento"))
                        iProvincia = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("idprovincia")), 0, dtDireccion.Rows(iFila).Item("idprovincia"))
                        iDistrito = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("iddistrito")), 0, dtDireccion.Rows(iFila).Item("iddistrito"))
                        iId_via = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_via")), 0, dtDireccion.Rows(iFila).Item("id_via"))
                        sVia = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("via")), "", dtDireccion.Rows(iFila).Item("via"))
                        sNumero2 = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("numero")), "", dtDireccion.Rows(iFila).Item("numero"))
                        sManzana = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("manzana")), "", dtDireccion.Rows(iFila).Item("manzana"))
                        sLote = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("lote")), "", dtDireccion.Rows(iFila).Item("lote"))
                        iId_Nivel = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_nivel")), 0, dtDireccion.Rows(iFila).Item("id_nivel"))
                        sNivel = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("nivel")), "", dtDireccion.Rows(iFila).Item("nivel"))
                        iId_Zona = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_zona")), 0, dtDireccion.Rows(iFila).Item("id_zona"))
                        sZona = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("zona")), "", dtDireccion.Rows(iFila).Item("zona"))
                        iId_Clasificacion = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_clasificacion")), 0, dtDireccion.Rows(iFila).Item("id_clasificacion"))
                        sClasificacion = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("clasificacion")), "", dtDireccion.Rows(iFila).Item("clasificacion"))

                        If Me.CboContacto.Enabled Then
                            iFila = Me.CboContacto.SelectedIndex
                            iTipo2 = IIf(IsDBNull(dtContacto.Rows(iFila).Item("idtipo_documento_contacto")), 0, dtContacto.Rows(iFila).Item("idtipo_documento_contacto"))
                            sNumero3 = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nrodocumento")), "", dtContacto.Rows(iFila).Item("nrodocumento"))
                            sContacto = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nombres")), "", dtContacto.Rows(iFila).Item("nombres"))
                            sNombresCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nombre")), "", dtContacto.Rows(iFila).Item("nombre")) 'new
                            sApCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("apepat")), "", dtContacto.Rows(iFila).Item("apepat"))
                            sAmCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("apemat")), "", dtContacto.Rows(iFila).Item("apemat"))
                            If sContacto.Trim.Substring(0, 1) = "(" Then
                                sContacto = ""
                            End If
                            bEsCliente = Me.ChkCliente1.Checked
                        End If
                    End If
                End If
            End If

            frm.cargar(sNumero, sCliente, iTipo, sNombresCli, sApCli, sAmCli, iDepartamento, iProvincia, iDistrito, iId_via, sVia, sNumero2, _
                       sManzana, sLote, iId_Nivel, sNivel, iId_Zona, sZona, iId_Clasificacion, _
                       sClasificacion, iTipo2, sNumero3, sContacto, sNombresCont, sApCont, sAmCont, sTelfCliente, bEsCliente, sEmail, 0)

            frm.bClienteNuevo = bClienteNuevo
            frm.bContactoNuevo = IIf(idcontacto > 0, False, True)
            'frm.iTipoComprobante = TipoComprobante
            frm.ShowDialog()
            Me.Cursor = Cursors.Default
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.AppStarting
                Me.CargarCliente(frm)
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim bClienteModificado, bDireccionModificada, bContactoModificado As Boolean
    Dim NombresCliente, apellPatCli, apellMatCli, TelfCliente As String '-->cliente
    Dim NombresCont, apellPatCont, apellMatCont As String '----------------------------->contacto
    Dim iID_TipoDocCont As Integer = 0
    'distrito
    Dim iDepartamentoCli, iProvinciaCli, iDistritoCli, IDviaCli, id_NivelCli, id_ZonaCli, id_ClasificacionCli, FormatoCli As Integer
    Dim ViaCli, ManzanaCli, loteCli, NivelCli, ZonaCli, NroCli, ClasificacionCli As String

    Sub CargarCliente(ByVal frm As FrmCliente2)
        Me.TxtNroDocCliente.Text = frm.TxtNumero.Text
        Me.TxtNomCliente.Text = frm.TxtCliente.Text & " " & frm.TxtAPCliente.Text & " " & frm.TxtAMCliente.Text
        Me.TxtTelfCliente.Text = frm.txtTelefono.Text
        bClienteModificado = frm.bClienteModificado
        bDireccionModificada = frm.bDireccionModificada
        bContactoModificado = frm.bContactoModificado

        '-----datos cliente-------------------------  
        iID_TipoDocCli = frm.CboTipoDocumento.SelectedValue
        sNombresCli = frm.TxtCliente.Text
        sApCli = frm.TxtAPCliente.Text
        sAmCli = frm.TxtAMCliente.Text
        sTelfCliente = frm.txtTelefono.Text
        sEmail = frm.TxtEmail.Text
        '---------------------------------------------
        RemoveHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
        RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
        If frm.TabCliente.SelectedIndex = 0 Then
            Me.TxtNroDocCliente.Text = frm.TxtNumero.Text.Trim
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.Buscar(frm.TxtNumero.Text, 1, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
            dtCliente = ds.Tables(0)
            Me.Mostrar(ds)
        ElseIf frm.TabCliente.SelectedIndex = 1 Then
            Dim dr As DataRow
            'cliente
            dtCliente = New DataTable
            dtCliente.Columns.Add(New DataColumn("idpersona", GetType(Integer)))
            dtCliente.Columns.Add(New DataColumn("razon_social", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("tipo", GetType(Integer)))
            dtCliente.Columns.Add(New DataColumn("nu_docu_suna", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("nombres", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("ap", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("am", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("telefono", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("email", GetType(String)))

            dr = dtCliente.NewRow
            dr("idpersona") = 0
            dr("razon_social") = frm.TxtCliente.Text & " " & frm.TxtAPCliente.Text & " " & frm.TxtAMCliente.Text
            dr("tipo") = frm.CboTipoDocumento.SelectedValue
            dr("nu_docu_suna") = frm.TxtNumero.Text.Trim
            dr("nombres") = frm.TxtCliente.Text.Trim
            dr("ap") = frm.TxtAPCliente.Text.Trim
            dr("am") = frm.TxtAMCliente.Text.Trim
            dr("telefono") = frm.txtTelefono.Text.Trim
            dr("email") = frm.TxtEmail.Text.Trim
            dtCliente.Rows.Add(dr)

            If frm.bDireccionModificada Or dtDireccion Is Nothing Then
                Me.CboDireccion.DataSource = Nothing
                Me.CboDireccion.Items.Clear()

                dtDireccion = New DataTable
                dtDireccion.Columns.Add(New DataColumn("iddireccion_consignado", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("direccion", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("id_via", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("via", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("numero", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("manzana", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("lote", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("id_nivel", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("nivel", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("id_zona", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("zona", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("id_clasificacion", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("clasificacion", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("iddepartamento", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("idprovincia", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("iddistrito", GetType(Integer)))

                dr = dtDireccion.NewRow
                dr("iddireccion_consignado") = 0
                dr("direccion") = " (SELECCIONE)"
                dr("id_via") = 0
                dr("via") = ""
                dr("numero") = ""
                dr("manzana") = ""
                dr("lote") = ""
                dr("id_nivel") = 0
                dr("nivel") = ""
                dr("id_zona") = 0
                dr("zona") = ""
                dr("id_clasificacion") = 0
                dr("clasificacion") = ""
                dr("iddepartamento") = 0
                dr("idprovincia") = 0
                dr("iddistrito") = 0
                dtDireccion.Rows.Add(dr)

                If frm.bDireccionModificada Then
                    '------datos direccion estructurada---------                
                    iDepartamentoCli = frm.CboDepartamento.SelectedValue
                    iProvinciaCli = frm.CboProvincia.SelectedValue
                    iDistritoCli = frm.CboDistrito.SelectedValue
                    IDviaCli = frm.CboVia.SelectedValue
                    ViaCli = frm.TxtVia.Text
                    NroCli = frm.TxtNumero2.Text
                    ManzanaCli = frm.TxtManzana.Text
                    loteCli = frm.TxtLote.Text
                    id_NivelCli = frm.CboNivel.SelectedValue
                    NivelCli = frm.TxtNivel.Text
                    id_ZonaCli = frm.CboZona.SelectedValue
                    ZonaCli = frm.TxtZona.Text
                    id_ClasificacionCli = frm.CboClasificacion.SelectedValue
                    ClasificacionCli = frm.TxtClasificacion.Text
                    FormatoCli = 1

                    'Dirección
                    '20-10-2011
                    'Dim sDireccion As String = frm.CboVia.Text & " " & frm.TxtVia.Text.Trim & " "
                    Dim sDireccion As String = IIf(frm.CboVia.SelectedValue = 0, "", frm.CboVia.Text) & " " & IIf(frm.CboVia.SelectedValue = 0, "", frm.TxtVia.Text.Trim) & " " 'Cambio 03102011
                    sDireccion = sDireccion.Trim & " "
                    If frm.CboVia.SelectedValue > 0 And frm.TxtNumero2.Text.Trim.Length > 0 Then
                        sDireccion &= frm.TxtNumero2.Text.Trim & " "
                    End If

                    If frm.TxtManzana.Text.Trim.Length > 0 Then
                        sDireccion &= "MZ " & frm.TxtManzana.Text.Trim & " LT " & frm.TxtLote.Text.Trim & " "
                    End If
                    If frm.CboNivel.SelectedValue = 0 And frm.CboNivel.SelectedValue > 0 Then
                        sDireccion &= frm.CboNivel.Text & " " & frm.TxtNivel.Text.Trim & " "
                    End If
                    If frm.CboZona.SelectedValue > 0 Then
                        sDireccion &= frm.CboZona.Text & " " & frm.TxtZona.Text.Trim & " "
                    End If
                    If frm.CboClasificacion.SelectedValue = 0 And frm.CboClasificacion.SelectedValue > 0 Then
                        sDireccion &= frm.CboClasificacion.Text & " " & frm.TxtClasificacion.Text.Trim & " "
                    End If
                    If frm.CboDistrito.SelectedValue > 0 Then
                        sDireccion &= frm.CboDistrito.Text
                    End If

                    dr = dtDireccion.NewRow
                    dr("iddireccion_consignado") = -1
                    dr("direccion") = sDireccion.Trim
                    dr("id_via") = frm.CboVia.SelectedValue
                    dr("via") = frm.TxtVia.Text.Trim
                    dr("numero") = frm.TxtNumero2.Text.Trim
                    dr("manzana") = frm.TxtManzana.Text.Trim
                    dr("lote") = frm.TxtLote.Text.Trim
                    dr("id_nivel") = frm.CboNivel.SelectedValue
                    dr("nivel") = frm.TxtNivel.Text.Trim
                    dr("id_zona") = frm.CboZona.SelectedValue
                    dr("zona") = frm.TxtZona.Text.Trim
                    dr("id_clasificacion") = frm.CboClasificacion.SelectedValue
                    dr("clasificacion") = frm.TxtClasificacion.Text.Trim
                    dr("iddepartamento") = frm.CboDepartamento.SelectedValue
                    dr("idprovincia") = frm.CboProvincia.SelectedValue
                    dr("iddistrito") = frm.CboDistrito.SelectedValue
                    dtDireccion.Rows.Add(dr)
                End If
                Me.CboDireccion.DataSource = dtDireccion
                CboDireccion.DisplayMember = "direccion"
                CboDireccion.ValueMember = "iddireccion_consignado"
                If frm.bDireccionModificada Then
                    Me.CboDireccion.SelectedIndex = 1
                Else
                    Me.CboDireccion.SelectedIndex = 0
                End If
            End If

            If frm.bContactoModificado Or dtContacto Is Nothing Then
                Me.CboContacto.DataSource = Nothing
                Me.CboContacto.Items.Clear()

                'Contacto
                iID_TipoDocCont = frm.CboDocContacto.SelectedValue
                NombresCont = frm.TxtContacto.Text.Trim
                apellPatCont = frm.TxtAPContacto.Text.Trim
                apellMatCont = frm.TxtAMContacto.Text.Trim

                'Me.TxtNroDocContacto.Text = frm.txtnrodocumento.Text.Trim
                'Me.CboContacto.DataSource = Nothing
                'Me.CboContacto.Items.Add(NombresCont & " " & apellPatCont & " " & apellMatCont)
                'Me.CboContacto.SelectedIndex = 0

                dtContacto = New DataTable
                dtContacto.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
                dtContacto.Columns.Add(New DataColumn("nombres", GetType(String)))
                dtContacto.Columns.Add(New DataColumn("nombre", GetType(String))) 'new
                dtContacto.Columns.Add(New DataColumn("idtipo_documento_contacto", GetType(Integer)))
                dtContacto.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
                dtContacto.Columns.Add(New DataColumn("apepat", GetType(String)))
                dtContacto.Columns.Add(New DataColumn("apemat", GetType(String)))

                dr = dtContacto.NewRow
                dr("idcontacto_persona") = 0
                dr("nombres") = " (SELECCIONE)"
                dr("idtipo_documento_contacto") = 0
                dr("nrodocumento") = ""
                dtContacto.Rows.Add(dr)

                If frm.TxtContacto.Text.Trim.Length > 0 Then
                    dr = dtContacto.NewRow
                    dr("idcontacto_persona") = idcontacto
                    dr("nombres") = NombresCont & " " & apellPatCont & " " & apellMatCont
                    dr("nombre") = NombresCont 'new                    
                    dr("idtipo_documento_contacto") = frm.CboDocContacto.SelectedValue
                    dr("nrodocumento") = frm.txtnrodocumento.Text.Trim
                    dr("apepat") = apellPatCont 'new
                    dr("apemat") = apellMatCont 'new
                    dtContacto.Rows.Add(dr)
                End If

                AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
                Me.CboContacto.DataSource = dtContacto
                CboContacto.DisplayMember = "nombres"
                CboContacto.ValueMember = "idcontacto_persona"
                Me.CboContacto.SelectedIndex = IIf(dtContacto.Rows.Count > 1, 1, 0)

                RemoveHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
                Me.ChkCliente1.Checked = frm.ChkCliente.Checked
                Me.ChkCliente1.Tag = Me.ChkCliente1.Checked
                AddHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
            End If
            End If

            'CboContacto.Enabled = True
            'ChkCliente1.Enabled = True

            'If TipoComprobante = 1 Then
            'CboContacto.SelectedIndex = 0
            'Else
            'ChkCliente1.Enabled = False
            'CboContacto.Enabled = False
            'CboContacto.SelectedIndex = 0
            'End If
            'AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
            AddHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
    End Sub

    Sub LimpiarCliente()
        Me.TxtNroDocCliente.Text = ""
        Me.TxtNomCliente.Text = ""
        Me.TxtTelfCliente.Text = ""
        'Me.dtCliente.Clear()

        Me.CboDireccion.DataSource = Nothing
        Me.CboDireccion.Items.Clear()
        Me.CboDireccion.Items.Add(" (SELECCIONE)")
        Me.CboDireccion.SelectedIndex = 0

        Me.TxtNroDocContacto.Text = ""

        Me.CboContacto.DataSource = Nothing
        Me.CboContacto.Items.Clear()
        Me.CboContacto.Items.Add(" (SELECCIONE)")
        Me.CboContacto.SelectedIndex = 0

        Me.ChkCliente1.Checked = False
    End Sub

    Sub Buscar(Optional ByVal opcion As Integer = 0)
        Try
            Dim iOpcion As Integer = IIf(Me.RbtDocumento.Checked, 1, 2)
            Dim frm As New FrmCliente2
            Dim scliente As String = IIf(opcion = 0, Me.TxtCliente.Text.Trim, Me.TxtNroDocCliente.Text)
            Dim iCliente As Integer
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.Buscar(scliente, iOpcion, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
            dtCliente = ds.Tables(0)
            bClienteNuevo = True

            If IsDBNull(dtCliente.Rows(0).Item(0)) Then
                If Not bBoleto Then
                    MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.LimpiarCliente()
                    frm = New FrmCliente2
                    frm.bClienteNuevo = bClienteNuevo
                    frm.iFicha = 1
                    frm.ShowDialog()
                    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                        CargarCliente(frm)
                    End If
                    'Else    'carga acompañada
                    '    NuevoClienteCargaAcompañada()
                End If
            ElseIf ds.Tables(0).Rows.Count = 1 Then
                Me.Mostrar(ds)
            Else
                frm.bClienteNuevo = bClienteNuevo
                frm = New FrmCliente2
                frm.iFicha = 0

                frm.cargar(ds.Tables(0), 2)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    ds = obj.Buscar(frm.TxtNumero.Text, 1, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
                    dtCliente = ds.Tables(0)
                    Me.Mostrar(ds)
                End If
            End If
            sDocCliente = TxtCliente.Text.Trim

            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, 1)

        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

    Private Sub CboDireccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDireccion.SelectedIndexChanged
        If iOpcion = 2 Then
            RemoveHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
            Me.CboDireccion.SelectedValue = ObjVentaCargaContado.v_IDDIREECION_ORIGEN
            AddHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
            Return
        End If
        If Not IsReference(CboDireccion.SelectedValue) Then
            If Not bDireccionModificada Then
                IdDireccionOrigen = CboDireccion.SelectedValue
            End If
        End If
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        Try
            If Not Validar() Then
                Return
            End If
            Me.Cursor = Cursors.WaitCursor

            Dim dblTotal As Double, dblSubtotal, dblImpuesto As Double
            With Me.DgvLista
                dblTotal = CType(.CurrentRow.Cells("total_costo").Value, Double)
                dblSubtotal = dblTotal / (1 + (dtoUSUARIOS.iIGV / 100))
                dblImpuesto = dblTotal - dblSubtotal
                Me.TxtTotal.Text = Format(dblTotal, "0.00")
                Me.TxtSubtotal.Text = Format(dblSubtotal, "0.00")
                Me.TxtImpuesto.Text = Format(dblImpuesto, "0.00")
            End With

            Me.Grabar()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim bOrigenDiferente As Boolean = False
    Dim ObjIMPRESIONFACT_BOL As New dtoIMPRESIONFACT_BOL
    Dim ConfiMensajeriaDlg As New FrmConfiMensajeria
    'Public Function fnGrabar() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        '-->Valida la configuarcion de la impresora - jabanto - 17/06/2016
    '        Dim dtImpresora As DataTable = FEManager.buscarPrint()
    '        If dtImpresora Is Nothing Then
    '            MessageBox.Show(FEManager.MESSAGE_NO_PRINT, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Return False
    '        End If

    '        'PARAMETRO TIPO_COMPROBANTE
    '        ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = TipoComprobante
    '        'PARAMETRO v_SERIE_FACTURA******************************************
    '        ObjVentaCargaContado.v_SERIE_FACTURA = LblSerie.Text.Trim

    '        'PARAMETRO v_NRO_FACTURA********************************************
    '        'If TxtNroDocCliente.Text <> "" Then
    '        ObjVentaCargaContado.v_NRO_FACTURA = RellenoRight(Mro_Digitos_Ventas, LblNroBoletaFact.Text)
    '        LblNroBoletaFact.Text = RellenoRight(Mro_Digitos_Ventas, LblNroBoletaFact.Text)
    '        'End If
    '        'PARAMETRO FECHA INGRESO (FECHA_FACTURA)****************************
    '        If bControlFiscalizacion = False Then
    '            ObjVentaCargaContado.v_FECHA_FACTURA = dtoUSUARIOS.m_sFecha
    '        Else
    '            ObjVentaCargaContado.v_FECHA_FACTURA = Format("DD/MM/YYYY", Me.LblFechaServidor.Text)
    '        End If
    '        'PARAMETRO PRODUCTO (IDPROCESOS)************************************
    '        ObjVentaCargaContado.v_iProceso = CboProducto.SelectedValue
    '        'PARAMETRO TIPO TARIFA**********************************************
    '        ObjVentaCargaContado.TipoTarifa = CboTipoTarifa.SelectedIndex

    '        If dtoUSUARIOS.agencia <> dtoUSUARIOS.m_iIdAgencia Or dtoUSUARIOS.agencia <> dtoUSUARIOS.iIDAGENCIAS Then
    '            dtoUSUARIOS.m_iIdAgencia = dtoUSUARIOS.agencia
    '            dtoUSUARIOS.iIDAGENCIAS = dtoUSUARIOS.agencia
    '            dtoUSUARIOS.m_idciudad = dtoUSUARIOS.ciudad
    '        End If

    '        'PARAMETROS CIUDAD ORIGEN (IDUNIDAD_ORIGEN)*************************
    '        ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad

    '        'PARAMETRO AGENCIA ORIGEN*******************************************
    '        ObjVentaCargaContado.v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia


    '        'PARAMETRO CIUDAD DESTINO*******************************************
    '        If idUnidadAgencias > 0 Then
    '            'PARAMETRO (IDCIUDAD_DESTINO)***********************************
    '            ObjVentaCargaContado.v_IDUNIDAD_DESTINO = idUnidadAgencias
    '            'PARAMETRO (IDAGENCIA_DESTINO*********************************
    '            ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = Int(ObjVentaCargaContado.coll_AgenciasVenta(CboAgenciaDest.SelectedIndex.ToString))
    '        End If

    '        'PARAMETRO TIPO ENTREGA (IDTIPO_ENTREGA)****************************
    '        ObjVentaCargaContado.v_IDTIPO_ENTREGA = Me.CboTipoEntrega.SelectedValue 'Int(ObjVentaCargaContado.coll_t_Tipo_Entrega(CboTipoEntrega.SelectedIndex.ToString))
    '        'PARAMETRO TIPO PAGO (IDTIPO_PAGO)**********************************
    '        ObjVentaCargaContado.v_IDTIPO_PAGO = Int(ObjVentaCargaContado.coll_Tipo_Pago(CboFormaPago.SelectedIndex.ToString))

    '        'PARAMETRO TARGETAS (IDTARJETAS)************************************
    '        ObjVentaCargaContado.v_IDTARJETAS = 0
    '        ObjVentaCargaContado.v_NROTARJETA = "@"
    '        If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 Then
    '            'PARAMETRO IDTARJETAS******            
    '            ObjVentaCargaContado.v_IDTARJETAS = Int(ObjVentaCargaContado.coll_T_TARJETAS(CboTarjeta.SelectedIndex.ToString))
    '            'PARAMETRO NROTARJETA******
    '            ObjVentaCargaContado.v_NROTARJETA = IIf(TxtNroTarjeta.Text <> "", TxtNroTarjeta.Text, "@")
    '        End If

    '        '*********************Condiciones de Modificacion***************************
    '        Me.FormateoVariables()

    '        '=================================CLIENTE=======================================================
    '        'PARAMETRO IDPERSONA************,
    '        ObjVentaCargaContado.v_IDPERSONA = IIf(bClienteNuevo, 0, iID_Persona)
    '        'PARAMETRO NRO_DNI_RUC**********
    '        ObjVentaCargaContado.v_NRO_DNI_RUC = IIf(TxtNroDocCliente.Text <> "", TxtNroDocCliente.Text, "@")
    '        'PARAMETRO NOMBRES_RASONSOCIAL**
    '        ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL = IIf(TxtNomCliente.Text <> "", TxtNomCliente.Text, "@")
    '        'PARAMETRO IDDIRECCION_ORIGEN******               
    '        If CboDireccion.SelectedValue = 0 Then
    '            IdDireccionOrigen = -1 '--> sin direccion valor(seleccione)
    '        End If
    '        ObjVentaCargaContado.v_IDDIREECION_ORIGEN = IdDireccionOrigen
    '        'PARAMETRO NOMBRE DE LA DIRECCION**
    '        ObjVentaCargaContado.v_DIRECCION_REMITENTE = IIf(IdDireccionOrigen = -1, "@", CboDireccion.Text)

    '        If (TipoComprobante = 1 Or CboProducto.SelectedValue = 7) Then
    '            sNombresCli = ""
    '        ElseIf ChkCliente1.Checked And TipoComprobante = 1 Then
    '            NombresCont = ""
    '        ElseIf ChkCliente2.Checked And TipoComprobante = 1 Then
    '            sNombresConsig = ""
    '        End If
    '        '---------DATOS DEL CLIENTE------
    '        ObjVentaCargaContado.Cliente_mod = IIf(bClienteModificado, 1, 0)
    '        ObjVentaCargaContado.ID_TipoDocCli = iID_TipoDocCli '--->agre
    '        ObjVentaCargaContado.NombresCliente = sNombresCli
    '        ObjVentaCargaContado.apellPatCli = sApCli
    '        ObjVentaCargaContado.apellMatCli = sAmCli
    '        ObjVentaCargaContado.TelefCliente = IIf(sTelfCliente.Length > 0, sTelfCliente, "@")
    '        ObjVentaCargaContado.sEmail = sEmail

    '        '--DIRECCION ESTRUCTURADO DEL CLIENTE          
    '        ObjVentaCargaContado.DirecCli_mod = IIf(bDireccionModificada, 1, 0)
    '        ObjVentaCargaContado.id_DepartamentoCli = iDepartamentoCli
    '        ObjVentaCargaContado.id_ProvinciaCli = iProvinciaCli
    '        ObjVentaCargaContado.id_DistritoCli = iDistritoCli
    '        ObjVentaCargaContado.id_viaCli = IDviaCli
    '        ObjVentaCargaContado.viaCli = ViaCli
    '        ObjVentaCargaContado.NumeroCli = NroCli
    '        ObjVentaCargaContado.manzanaCli = ManzanaCli
    '        ObjVentaCargaContado.loteCli = loteCli
    '        ObjVentaCargaContado.id_nivelCli = id_NivelCli
    '        ObjVentaCargaContado.nivelCli = NivelCli
    '        ObjVentaCargaContado.id_zonaCli = id_ZonaCli
    '        ObjVentaCargaContado.zonaCli = ZonaCli
    '        ObjVentaCargaContado.id_clasificacionCli = id_ClasificacionCli
    '        ObjVentaCargaContado.clasificacionCli = ClasificacionCli
    '        ObjVentaCargaContado.formatoCli = FormatoCli

    '        '=============================DATOS CONTACTO======================================           
    '        'PARAMETRO ID_NOMBRE_CONTACTO**          
    '        If CboContacto.SelectedIndex = 0 Then
    '            idcontacto = -1
    '        End If
    '        'If idcontacto = 0 AndAlso Me.ChkCliente1.Checked Then
    '        'Dim objContacto As New dtoVentaCargaContado
    '        'Dim dt As DataTable = objContacto.BuscarContacto(TxtNroDocContacto.Text.Trim, TxtNroDocContacto.Text)
    '        'Dim resp As Integer = dt.Rows.Count
    '        'If resp > 0 Then
    '        'bContactoModificado = False
    '        'End If
    '        'End If
    '        'PARAMETRO NOMBRE CONTACTO*****
    '        ObjVentaCargaContado.v_IDPERSONA_ORIGEN = idcontacto
    '        ObjVentaCargaContado.v_NOMBRES_REMITENTE = IIf(Trim(CboContacto.Text) <> "", CboContacto.Text, "@") 'p
    '        ObjVentaCargaContado.contacto_mod = IIf(bContactoModificado, 1, 0)
    '        ObjVentaCargaContado.v_NRO_DOC_REMITENTE = IIf(Trim(TxtNroDocContacto.Text) <> "", TxtNroDocContacto.Text, "@")
    '        ObjVentaCargaContado.ID_TipoDocCont = iID_TipoDocCont
    '        ObjVentaCargaContado.NombreCont = NombresCont
    '        ObjVentaCargaContado.apellPatCont = apellPatCont
    '        ObjVentaCargaContado.apellMatCont = apellMatCont

    '        '======================================CONSIGNADO=================================
    '        'PARAMETRO ID_NOMBRE_CONSIGNADO**
    '        If Me.TxtNroDocConsignado.Tag = 0 AndAlso Me.ChkCliente2.Checked Then
    '            Dim objContacto As New dtoVentaCargaContado
    '            Dim dt As DataTable = objContacto.BuscarContacto(TxtNroDocConsignado.Text)
    '            Dim resp As Integer = dt.Rows.Count
    '            If resp = 0 Then
    '                Me.TxtNroDocConsignado.Tag = 0
    '            Else
    '                Me.TxtNroDocConsignado.Tag = dt.Rows(0).Item(0)
    '                bConsignadoModificado = False
    '            End If
    '        End If
    '        ObjVentaCargaContado.v_IDCONTACTO_DESTINO = IIf(IsNothing(Me.TxtNroDocConsignado.Tag), 0, Me.TxtNroDocConsignado.Tag)
    '        'ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Trim(sNombresConsig.Trim) <> "", sNombresConsig.Trim, "@")
    '        ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Me.TxtNombConsignado.Text.Trim <> "", Me.TxtNombConsignado.Text.Trim, "@")
    '        ObjVentaCargaContado.NombConsignado_mod = IIf(bConsignadoModificado, 1, 0)
    '        ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO = IIf(Trim(TxtNroDocConsignado.Text) <> "", TxtNroDocConsignado.Text, "@")
    '        ObjVentaCargaContado.ID_TipoDocConsig = iID_TipoDocConsig
    '        ObjVentaCargaContado.NombreConsignado = sNombresConsig
    '        ObjVentaCargaContado.apellPatConsig = sapellPatConsig
    '        ObjVentaCargaContado.apellMatConsig = sapellMatConsig
    '        ObjVentaCargaContado.TelfConsignado = IIf(sTelefonoConsig.Length > 0, sTelefonoConsig, "@")

    '        'PARAMETRO ID_DIRECCION_DESTINO**
    '        If CboDireccion2.SelectedIndex = 0 Then
    '            idDireConsignado = -1
    '        End If
    '        ObjVentaCargaContado.v_IDDIREECION_DESTINO = idDireConsignado

    '        '--DIRECCION ESTRUCTURADA CONSIGNADO
    '        ObjVentaCargaContado.DirecConsignado_mod = IIf(bDirecConsigMod, 1, 0)
    '        ObjVentaCargaContado.v_DIRECCION_DESTINATARIO = IIf(idDireConsignado = -1, "@", CboDireccion2.Text)
    '        ObjVentaCargaContado.id_DepartamentoConsig = iDepartamentoConsig
    '        ObjVentaCargaContado.id_ProvinciaConsig = iProvinciaConsig
    '        ObjVentaCargaContado.id_DistritoConsig = iDistritoConsig
    '        ObjVentaCargaContado.id_viaConsig = IDviaConsig
    '        ObjVentaCargaContado.viaConsig = ViaConsig
    '        ObjVentaCargaContado.NumeroConsig = NroConsig
    '        ObjVentaCargaContado.manzanaConsig = ManzanaConsig
    '        ObjVentaCargaContado.loteConsig = loteConsig
    '        ObjVentaCargaContado.id_nivelConsig = id_NivelConsig
    '        ObjVentaCargaContado.nivelConsig = NivelConsig
    '        ObjVentaCargaContado.id_zonaConsig = id_ZonaConsig
    '        ObjVentaCargaContado.zonaConsig = ZonaConsig
    '        ObjVentaCargaContado.id_clasificacionConsig = id_ClasificacionConsig
    '        ObjVentaCargaContado.clasificacionConsig = ClasificacionConsig
    '        ObjVentaCargaContado.formatoConsig = FormatoConsig
    '        ObjVentaCargaContado.sReferencia = TxtReferencia.Text.Trim

    '        '---Nuevos Parametros a agregar---
    '        ObjVentaCargaContado.TarifarioGeneral = IIf(bTarifarioGeneral, 1, 0)
    '        ObjVentaCargaContado.Contado = IIf(bContado, 1, 0)

    '        'nota bOtrasAgencias deberia ser=true no=false
    '        ObjVentaCargaContado.v_OTRAS_AGENCIAS = True 'bOtrasAgencias

    '        'PARAMETROS PARA CARGA ACOMPAÑADA***********************************           
    '        If Val(iTotal_CA) > 0 Then
    '            ObjVentaCargaContado.v_SUB_TOTAL_CA = Format(iSub_Total_CA, "0.00")
    '            ObjVentaCargaContado.v_IMPUESTO_CA = Format(iImpuesto_CA, "0.00")
    '            ObjVentaCargaContado.v_TOTAL_CA = Format(iTotal_CA, "0.00")
    '        Else
    '            ObjVentaCargaContado.v_SUB_TOTAL_CA = 0
    '            ObjVentaCargaContado.v_IMPUESTO_CA = 0
    '            ObjVentaCargaContado.v_TOTAL_CA = 0
    '        End If

    '        'PARAMETRO v_cargo**************************************************
    '        ObjVentaCargaContado.v_cargo = Me.ChkCargo.Checked

    '        ObjVentaCargaContado.v_idagencia_venta = dtoUSUARIOS.m_iIdAgencia
    '        ObjVentaCargaContado.v_idciudad_venta = dtoUSUARIOS.m_idciudad
    '        If CboProducto.SelectedValue = 6 Then 'PARAMETROS CARGA ACOMPAÑADA
    '            ObjVentaCargaContado.v_nroboleto = Me.TxtBoleto.Text
    '            ObjVentaCargaContado.v_carga_acompañada = 1
    '            ObjVentaCargaContado.bOrigenDiferente = bOrigenDiferente
    '            ObjVentaCargaContado.v_TIPO_DOCUMENTO = IIf(IsDBNull(Me.TxtNroDocCliente.Tag), 0, Me.TxtNroDocCliente.Tag)
    '        ElseIf CboProducto.SelectedValue = 0 Then 'PARAMETROS ESTANDAR(NORMAL)
    '            ObjVentaCargaContado.v_nroboleto = ""
    '            ObjVentaCargaContado.v_carga_acompañada = 0 'Nota                
    '            ObjVentaCargaContado.bOrigenDiferente = False
    '            ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
    '        ElseIf CboProducto.SelectedValue = 7 Then 'PARAMETROS PYME
    '            ObjVentaCargaContado.v_nroboleto = ""
    '            ObjVentaCargaContado.v_carga_acompañada = 7
    '            ObjVentaCargaContado.bOrigenDiferente = False
    '            ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
    '        ElseIf CboProducto.SelectedValue = 8 Then
    '            ObjVentaCargaContado.v_nroboleto = ""
    '            ObjVentaCargaContado.v_carga_acompañada = 8
    '            ObjVentaCargaContado.bOrigenDiferente = False
    '            ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
    '        ElseIf CboProducto.SelectedValue = 10 Then 'PARAMETROS ESTANDAR(NORMAL)
    '            ObjVentaCargaContado.v_nroboleto = ""
    '            ObjVentaCargaContado.v_carga_acompañada = 0 'Nota                
    '            ObjVentaCargaContado.bOrigenDiferente = False
    '            ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
    '        End If

    '        ' ObjVentaCargaContado.v_TELEFONO_DESTINATARIO = IIf(Trim(TxtTelfConsignado.Text) <> "", TxtTelfConsignado.Text, "@")
    '        ObjVentaCargaContado.v_MEMO = IIf(Trim(txtDescDescto.Text) <> "", txtDescDescto.Text, "@")
    '        ObjVentaCargaContado.v_MONTO_DESCUENTO = IIf(Trim(TxtDescuento.Text) <> "", TxtDescuento.Text, 0)
    '        '
    '        Dim totalCosto As Double = 0
    '        Dim valor1 As Double = 0
    '        Dim valor2 As Double = 0
    '        '
    '        ObjVentaCargaContado.v_CANTIDAD_X_PESO = 0
    '        ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = 0
    '        ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = 0

    '        ObjVentaCargaContado.v_TOTAL_PESO = 0
    '        ObjVentaCargaContado.v_TOTAL_VOLUMEN = 0
    '        '

    '        '******************************GRID BULTOS*********************************
    '        If ChkArticulos.Checked = False And ChkVolumetrico.Checked = False Then
    '            'PESO
    '            If IsDBNull(GrdDetalleVenta.Rows(0).Cells(2)) = False Then
    '                If Conversion.Val(GrdDetalleVenta(1, 0).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 0).Value
    '                If Conversion.Val(GrdDetalleVenta(2, 0).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(2, 0).Value
    '                ObjVentaCargaContado.v_CANTIDAD_X_PESO = valor1
    '                ObjVentaCargaContado.v_TOTAL_PESO = valor2
    '                totalCosto = valor2 * tarifa_Peso
    '            End If

    '            'VOLUMEN
    '            If IsDBNull(GrdDetalleVenta.Rows(1).Cells(2)) = False Then
    '                If Conversion.Val(GrdDetalleVenta(1, 1).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 1).Value
    '                If Conversion.Val(GrdDetalleVenta(2, 1).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(2, 1).Value
    '                ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = valor1
    '                ObjVentaCargaContado.v_TOTAL_VOLUMEN = valor2
    '                totalCosto = totalCosto + valor2 * tarifa_Volumen
    '            End If

    '            'SOBRE
    '            If IsDBNull(GrdDetalleVenta.Rows(2).Cells(2)) = False Then
    '                If Conversion.Val(GrdDetalleVenta(1, 2).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 2).Value
    '                ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = valor1
    '                totalCosto = totalCosto + valor1 * tarifa_Sobre
    '            End If

    '            tarifa_Peso = Format(Val(GrdDetalleVenta(3, 0).Value), "##,###,###.00")
    '            tarifa_Volumen = Format(Val(GrdDetalleVenta(3, 1).Value), "##,###,###.00")
    '            tarifa_Sobre = Format(Val(GrdDetalleVenta(3, 2).Value), "##,###,###.00")

    '            ''Peso
    '            'If Val(GrdDetalleVenta.Rows(0).Cells(2).Value) > 0 And Val(GrdDetalleVenta.Rows(0).Cells(1).Value) = 0 Then
    '            '    MessageBox.Show("Debe ingresar Nº de Piezas o Bultos para Tipo Peso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            '    Me.Cursor = Cursors.Default
    '            '    Return False
    '            'End If

    '            ''Volumen
    '            'If Val(GrdDetalleVenta.Rows(1).Cells(2).Value) > 0 And Val(GrdDetalleVenta.Rows(1).Cells(1).Value) = 0 Then
    '            '    MessageBox.Show("Debe ingresar Nº de Piezas o Bultos para Tipo Volumen.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            '    Me.Cursor = Cursors.Default
    '            '    Return False
    '            'End If

    '            'If ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_CANTIDAD_X_SOBRE + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN + ObjVentaCargaContado.v_MONTO_PENALIDAD <= 0 Then
    '            '    MsgBox("No puede realizar esta operación debe enviar como mínimo un paquete...", MsgBoxStyle.Information, "Seguridad Sistema")
    '            '    Me.Cursor = Cursors.Default
    '            '    Return False
    '            'End If
    '        End If

    '        '******************************GRID M3*********************************
    '        If ChkVolumetrico.Checked = True Then
    '            'PESO
    '            If IsDBNull(GrdDetalleVenta.Rows(0).Cells(2)) = False Then
    '                'valor1 = Format(Val(GrdDetalleVenta(1, 0).Value), "##,###,####.00")
    '                'valor2 = Format(Val(GrdDetalleVenta(5, 0).Value), "##,###,####.00")
    '                '-------
    '                If Conversion.Val(GrdDetalleVenta(1, 0).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 0).Value
    '                If Conversion.Val(GrdDetalleVenta(5, 0).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(5, 0).Value
    '                '-------

    '                ObjVentaCargaContado.v_CANTIDAD_X_PESO = valor1
    '                ObjVentaCargaContado.v_TOTAL_PESO = valor2
    '                totalCosto = valor2 * tarifa_Peso
    '            End If

    '            'SOBRE
    '            If Val(txtCantidadSobres.Text) > 0 Then
    '                valor1 = Val(txtCantidadSobres.Text)
    '                ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = valor1
    '                totalCosto = totalCosto + valor1 * tarifa_Sobre
    '            End If

    '            '*****MOD******                
    '            ObjVentaCargaContado.v_METROCUBICO = 1
    '            ObjVentaCargaContado.v_ALTURA = FormatNumber(Format(Val(GrdDetalleVenta(2, 0).Value), "##,###,###.00"), 2)
    '            ObjVentaCargaContado.v_ANCHO = Format(Val(GrdDetalleVenta(3, 0).Value), "##,###,###.00")
    '            ObjVentaCargaContado.v_LARGO = Format(Val(GrdDetalleVenta(4, 0).Value), "##,###,###.00")
    '            ObjVentaCargaContado.v_PESO_KG = Format(Val(GrdDetalleVenta(5, 0).Value), "##,###,###.00")
    '            ObjVentaCargaContado.v_FACTOR = Factor_
    '            '**************

    '            'MOD***
    '            tarifa_Peso = Format(Val(GrdDetalleVenta(6, 0).Value), "##,###,###.00")
    '            tarifa_Sobre = Format(Val(txtMontoBase.Text), "##,###,###.00")
    '            '******

    '            'validacion
    '            'If Val(GrdDetalleVenta.Rows(0).Cells(5).Value) > 0 And Val(GrdDetalleVenta.Rows(0).Cells(1).Value) = 0 Then
    '            '    MessageBox.Show("Debe ingresar Nº de Piezas o Bultos para Tipo Peso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            '    '***MOD*****
    '            '    GrdDetalleVenta.Focus()
    '            '    '***********
    '            '    Me.Cursor = Cursors.Default
    '            '    Return False
    '            'End If
    '        Else
    '            ObjVentaCargaContado.v_METROCUBICO = 0
    '            ObjVentaCargaContado.v_ALTURA = 0
    '            ObjVentaCargaContado.v_ANCHO = 0
    '            ObjVentaCargaContado.v_LARGO = 0
    '            ObjVentaCargaContado.v_PESO_KG = 0
    '            ObjVentaCargaContado.v_FACTOR = 0
    '        End If

    '        If chkSobres.Checked = True Then
    '            ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = Val(txtCantidadSobres.Text)
    '        End If

    '        ObjVentaCargaContado.v_PRECIO_X_PESO = tarifa_Peso
    '        ObjVentaCargaContado.v_PRECIO_X_VOLUMEN = tarifa_Volumen
    '        ObjVentaCargaContado.v_PRECIO_X_SOBRE = tarifa_Sobre


    '        ObjVentaCargaContado.v_MONTO_SUB_TOTAL = TxtSubtotal.Text
    '        ObjVentaCargaContado.v_MONTO_IMPUESTO = TxtImpuesto.Text
    '        ObjVentaCargaContado.v_TOTAL_COSTO = TxtTotal.Text

    '        ObjVentaCargaContado.v_IDTIPO_MONEDA = 1 'Soles

    '        ObjVentaCargaContado.v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
    '        ObjVentaCargaContado.v_IP = dtoUSUARIOS.IP
    '        ObjVentaCargaContado.v_IDROL_USUARIO = dtoUSUARIOS.IdRol

    '        ObjVentaCargaContado.v_MONTO_PENALIDAD = 0
    '        ObjVentaCargaContado.v_IDFUNCIONARIO_AUTORIZACION = 0

    '        ObjVentaCargaContado.v_IGV = dtoUSUARIOS.iIGV
    '        ObjVentaCargaContado.v_PORCENT_DEVOLUCION = 0
    '        ObjVentaCargaContado.v_PORCENT_DESCUENTO = Format(Val(TxtDescuento.Text), "###.00")
    '        ObjVentaCargaContado.v_MONTO_RECARGO = 0

    '        '----------------------------------------------------------------------------------------------------------------------------
    '        ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
    '        ObjVentaCargaContado.v_MONTO_PENALIDAD = 0                ' Para la cantidad
    '        ObjVentaCargaContado.v_MONTO_RECARGO = 0                    ' Para El Peso

    '        'hlamas 19-11-2013s
    '        ObjVentaCargaContado.MontoEntregaDomicilio = dblMontoEntregaDomicilio

    '        'hlamas 17-02-2015
    '        ObjVentaCargaContado.MontoDC = dblMontoDC

    '        'hlamas 22-10-2016
    '        ObjVentaCargaContado.intCancelaPCE = 1


    '        '****************************Grid Articulos******************************
    '        If ChkArticulos.Checked = True Then
    '            Try
    '                Dim ii As Integer = 0
    '                For ii = 0 To Me.GrdDetalleVenta.RowCount - 1
    '                    If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
    '                        If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
    '                            ObjVentaCargaContado.v_MONTO_PENALIDAD = ObjVentaCargaContado.v_MONTO_PENALIDAD + Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
    '                            ObjVentaCargaContado.v_MONTO_RECARGO = ObjVentaCargaContado.v_MONTO_RECARGO + Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
    '                        End If
    '                    End If
    '                Next
    '            Catch ex As Exception
    '                MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End Try


    '            Try
    '                Dim kk As Integer = 0
    '                For kk = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
    '                    If IsDBNull(GrdDetalleVenta.Rows(kk).Cells(2)) = False Then
    '                        If IsNumeric(GrdDetalleVenta.Rows(kk).Cells(2).Value.ToString) Then
    '                            If GrdDetalleVenta.Rows(kk).Cells(2).Value <> 0 Then
    '                                'If IsDBNull(GrdDetalleVenta.Rows(kk).Cells(3)) Then
    '                                'MsgBox("Debe ingresar el peso...", MsgBoxStyle.Information, "Seguridad Sistema")
    '                                'Me.Cursor = Cursors.Default
    '                                'Return False
    '                                'End If
    '                                'If Not IsNumeric(GrdDetalleVenta.Rows(kk).Cells(3).Value) Then
    '                                'MsgBox("Debe ingresar el peso...", MsgBoxStyle.Information, "Seguridad Sistema")
    '                                'Me.Cursor = Cursors.Default
    '                                'Return False
    '                                'End If
    '                                'If GrdDetalleVenta.Rows(kk).Cells(3).Value <= 0 Then
    '                                'MsgBox("Debe ingresar el peso mayor que cero...", MsgBoxStyle.Information, "Seguridad Sistema")
    '                                'Me.Cursor = Cursors.Default
    '                                'Return False
    '                                'End If
    '                            End If
    '                        End If
    '                    End If
    '                Next
    '            Catch ex As Exception
    '                MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End Try
    '        End If

    '        '********************fin grid articulos*********************************************************
    '        '----------------------------------------------------------------------------------------------------------------------------
    '        'If ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = ObjVentaCargaContado.v_IDUNIDAD_DESTINO Then
    '        '    MsgBox("No pueden ser iguales el Origen y el Destino...", MsgBoxStyle.Information, "Seguridad Sistema")
    '        '    Me.Cursor = Cursors.Default
    '        '    Return False
    '        'End If
    '        'If TxtCiudadDestino.Text = "" Then
    '        '    MsgBox("Debe definir un destino Para esta OPeracion...", MsgBoxStyle.Information, "Seguridad Sistema")
    '        '    Me.Cursor = Cursors.Default
    '        '    Return False
    '        'End If

    '        'If ObjVentaCargaContado.v_IDTIPO_ENTREGA = 2 Then
    '        '    'If TxtDirecConsignado.Text = "" Then
    '        '    '    MsgBox("Debe Ingresar la Direccion es Obligatoria...")
    '        '    '    TxtDirecConsignado.Focus()
    '        '    '    Return False
    '        '    'End If

    '        '    If CboDireccion2.Text = "" Then
    '        '        MsgBox("Debe Ingresar la Direccion es Obligatoria...")
    '        '        CboDireccion2.Focus()
    '        '        Me.Cursor = Cursors.Default
    '        '        Return False
    '        '    End If
    '        'End If

    '        'CboTipoEntrega
    '        ObjIMPRESIONFACT_BOL.fnClear()

    '        '**MOD***********************************
    '        If ChkArticulos.Checked = False And ChkVolumetrico.Checked = False Then '--BULTOS
    '            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = Val(GrdDetalleVenta("Sub Neto", 0).Value)
    '            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = Val(GrdDetalleVenta("Sub Neto", 1).Value)
    '            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(GrdDetalleVenta("Sub Neto", 2).Value)
    '        ElseIf ChkArticulos.Checked = True Then
    '            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = Val(GrdDetalleVenta("T.Costo", 0).Value) '---ARTICULOS
    '            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = "0.00"
    '            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = "0.00"
    '        End If

    '        If ChkVolumetrico.Checked = True Then
    '            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = Val(GrdDetalleVenta("Sub Neto", 0).Value)
    '            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = "0.00"
    '            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Format(Val(txtTotalSobre.Text), "##,###,###.00")
    '        End If
    '        '****************************************

    '        ObjIMPRESIONFACT_BOL.xCantidad_Peso = ObjVentaCargaContado.v_CANTIDAD_X_PESO
    '        ObjIMPRESIONFACT_BOL.xCantidad_Sobre = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE
    '        ObjIMPRESIONFACT_BOL.xCantidad_Vol = ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN

    '        ObjCODIGOBARRA.clinte = ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL
    '        ObjCODIGOBARRA.NroDOC = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
    '        ObjCODIGOBARRA.AGEDOM = Mid(CboTipoEntrega.Text, 1, 3)

    '        ObjIMPRESIONFACT_BOL.xDestino = TxtCiudadDestino.Text
    '        ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL = Me.LblSerie.Text & "-" & Me.LblNroBoletaFact.Text
    '        ObjIMPRESIONFACT_BOL.xRazonSocial = Me.TxtNomCliente.Text.Trim
    '        ObjIMPRESIONFACT_BOL.xDireccionRemitente = Me.CboDireccion.Text
    '        ObjIMPRESIONFACT_BOL.xRuc = TxtNroDocCliente.Text
    '        ObjIMPRESIONFACT_BOL.xConsignado = Me.TxtNombConsignado.Text
    '        'ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.TxtDirecConsignado.Text'verificar
    '        ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.CboDireccion2.Text
    '        ObjIMPRESIONFACT_BOL.xfecha_factura = Me.LblFechaServidor.Text
    '        ObjIMPRESIONFACT_BOL.xTotalPeso = ObjVentaCargaContado.v_TOTAL_PESO
    '        ObjIMPRESIONFACT_BOL.xTotalVolumen = ObjVentaCargaContado.v_TOTAL_VOLUMEN
    '        ObjIMPRESIONFACT_BOL.xTotalSobres = 0
    '        ObjIMPRESIONFACT_BOL.xNroRef = Me.LblSerie.Text & "-" & Me.LblNroBoletaFact.Text
    '        ObjIMPRESIONFACT_BOL.xMemo = Me.txtDescDescto.Text
    '        ObjIMPRESIONFACT_BOL.xMonto_Sub_Total = Me.TxtSubtotal.Text
    '        ObjIMPRESIONFACT_BOL.xMonto_Impuesto = TxtImpuesto.Text
    '        ObjIMPRESIONFACT_BOL.xTotal_Costo = ObjVentaCargaContado.v_TOTAL_COSTO
    '        ObjIMPRESIONFACT_BOL.xDescuento = IIf(TxtDescuento.Text <> "", TxtDescuento.Text, "")
    '        ObjIMPRESIONFACT_BOL.xAgenciaDestino = IIf(CboAgenciaDest.Text <> "", CboAgenciaDest.Text, "")
    '        ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = CboTipoEntrega.Text

    '        If varIdCondicion = 2 Or varIdCondicion = 5 Then '====> (2=Tarjeta,5=Cortesia)
    '            Me.Cursor = Cursors.AppStarting
    '            asignar_documentos_clientes()

    '            If ObjVentaCargaContado.GrabarIV = True Then
    '                iCliente = ObjVentaCargaContado.v_IDPERSONA
    '                Me.Cursor = Cursors.Default

    '                'hlamas 21-08-2015
    '                'ConfiMensajeriaDlg = New FrmConfiMensajeria
    '                'Acceso.Asignar(ConfiMensajeriaDlg, Me.hnd)
    '                'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
    '                '    ConfiMensajeriaDlg.ShowDialog()
    '                'Else
    '                '    MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                'End If
    '                'ConfiMensajeriaDlg = Nothing

    '                ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString

    '                '-----------------------------------------------------------------
    '                'INSERCION VOLUMETRICO
    '                '-----------------------------------------------------------------
    '                Try
    '                    If ChkVolumetrico.Checked = True Then
    '                        Dim obj As New dtoVentaCargaContado
    '                        Dim ii As Integer = 0
    '                        objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
    '                        objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
    '                        objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
    '                        objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
    '                        objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

    '                        For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
    '                            If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
    '                                If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
    '                                    obj.FNinsert_Volumetrico(
    '                                             ii,
    '                                             0,
    '                                             ObjIMPRESIONFACT_BOL.xIdFactura,
    '                                             GrdDetalleVenta.Rows(ii).Cells("Tipo").Value,
    '                                             GrdDetalleVenta.Rows(ii).Cells("Bulto").Value,
    '                                             GrdDetalleVenta.Rows(ii).Cells("Altura").Value,
    '                                             GrdDetalleVenta.Rows(ii).Cells("Ancho").Value,
    '                                             GrdDetalleVenta.Rows(ii).Cells("Largo").Value,
    '                                             GrdDetalleVenta.Rows(ii).Cells("Peso Kg").Value,
    '                                             Factor_,
    '                                             GrdDetalleVenta.Rows(ii).Cells("Costo").Value)
    '                                End If
    '                            End If
    '                        Next
    '                    End If
    '                Catch ex As Exception
    '                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End Try

    '                '-----------------------------------------------------------------
    '                'INSERCION DE ARTICULOS
    '                '-----------------------------------------------------------------

    '                Try
    '                    If ChkArticulos.Checked = True Then
    '                        Dim ii As Integer = 0
    '                        objGuia_Envio_Articulo.iCONTROL = 1
    '                        objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = 0
    '                        objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
    '                        objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
    '                        objGuia_Envio_Articulo.iDESCUENTO = 0
    '                        objGuia_Envio_Articulo.iPENALIDAD = 0
    '                        objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
    '                        objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
    '                        objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol
    '                        objGuia_Envio_Articulo.iIDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
    '                        objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18

    '                        For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
    '                            If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
    '                                If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
    '                                    objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(5).Value.ToString)
    '                                    objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
    '                                    objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)

    '                                    ObjIMPRESIONFACT_BOL.xCantidad_Peso = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
    '                                    ObjIMPRESIONFACT_BOL.xTotalPeso = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
    '                                    objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells(1).Value.ToString)
    '                                    objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
    '                                End If
    '                            End If
    '                        Next
    '                    End If
    '                Catch ex As Exception
    '                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End Try

    '                '-----------------------------------------------------------------
    '                'INSERCION DE DOCUMENTOS DEL CLIENTE
    '                '-----------------------------------------------------------------   
    '                flat = True
    '                Dim i As Integer = 0
    '                Dim serie_NroDoc() As String
    '                objGuiaEnvio.iControl_Documentos = 1
    '                objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
    '                objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
    '                Dim iContador As Integer = 0
    '                If objGuiaEnvio.iCONTROL = 0 Or objGuiaEnvio.iCONTROL = 1 Then
    '                    For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 2
    '                        Try
    '                            If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Cargo")) = False Then
    '                                'If Trim(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value.ToString) <> "" Then
    '                                If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value) Then
    '                                    serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells(2).Value.ToString, "-")
    '                                    If serie_NroDoc.Length > 1 Then
    '                                        objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
    '                                        objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
    '                                        If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
    '                                            If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
    '                                                If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL() = True Then
    '                                                    strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
    '                                                    iContador = iContador + 1
    '                                                End If
    '                                            End If
    '                                        End If
    '                                    End If
    '                                End If
    '                            End If
    '                        Catch ex As Exception
    '                            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        End Try

    '                        Try
    '                            If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Seguro")) = False Then
    '                                'If Trim(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString) <> "" Then
    '                                If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value) Then
    '                                    serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString, "-")
    '                                    If serie_NroDoc.Length > 1 Then
    '                                        objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
    '                                        objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
    '                                        If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
    '                                            If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
    '                                                If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL() = True Then
    '                                                    strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
    '                                                    iContador = iContador + 1
    '                                                End If
    '                                            End If
    '                                        End If
    '                                    End If
    '                                End If
    '                            End If
    '                        Catch ex As Exception
    '                            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        End Try
    '                    Next
    '                End If

    '                '*******************************************************************
    '                '-->EMISON DE LA FACTURA/BOLETA ELECTRONICA - JABANTO - 19/05/2016
    '                '*******************************************************************
    '                Dim numeroComprobante As String = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
    '                Emisionfe(numeroComprobante, dtImpresora)
    '                '===================================================================


    '                fnNUEVO()
    '                limpiar_documentos_cliente()
    '                flat = True
    '                iOficinaDestino = 0
    '                iOficinaOrigen = 0
    '            Else
    '                Me.Cursor = Cursors.Default
    '                MessageBox.Show("La Venta no se Registró", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If

    '        ElseIf varIdCondicion = 1 Then '-> 1=Efectivo
    '            If bControlFiscalizacion = False Then
    '                Dim varDlgPagos As New frmPagosContado
    '                If varDlgPagos.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '                    If varDlgPagos.txtPagoSoles.Text > 0 Then
    '                        lblTotalPagado.Visible = True
    '                        lblTotalVenta.Visible = True
    '                        lblVuelto.Visible = True
    '                        txtTotalPagado.Visible = True
    '                        txtTotalVenta.Visible = True
    '                        txtVuelto.Visible = True
    '                        txtTotalVenta.Text = FormatNumber(TxtTotal.Text, 2)
    '                        txtTotalPagado.Text = FormatNumber(varDlgPagos.txtPagoSoles.Text, 2)
    '                        txtVuelto.Text = FormatNumber(varDlgPagos.txtVuelto.Text, 2)
    '                    End If
    '                    asignar_documentos_clientes()

    '                    If ObjVentaCargaContado.GrabarIV = True Then
    '                        iCliente = ObjVentaCargaContado.v_IDPERSONA

    '                        'hlamas 21-08-2015
    '                        'ConfiMensajeriaDlg = New FrmConfiMensajeria
    '                        'Acceso.Asignar(ConfiMensajeriaDlg, Me.hnd)
    '                        'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
    '                        '    ConfiMensajeriaDlg.ShowDialog()
    '                        'Else
    '                        '    MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        'End If
    '                        'ConfiMensajeriaDlg = Nothing

    '                        ObjPagosSoles.v_idfactura_contado = ObjVentaCargaContado.v_IDFACTURA
    '                        ObjPagosDolares.v_idfactura_contado = ObjVentaCargaContado.v_IDFACTURA
    '                        ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString

    '                        '-------------------------------------------
    '                        'INSERCION VOLUMETRICO
    '                        '-------------------------------------------
    '                        Try
    '                            If ChkVolumetrico.Checked = True Then
    '                                Dim obj As New dtoVentaCargaContado
    '                                Dim ii As Integer = 0
    '                                objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
    '                                objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
    '                                objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
    '                                objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
    '                                objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

    '                                For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
    '                                    If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
    '                                        If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
    '                                            obj.FNinsert_Volumetrico(
    '                                                     ii,
    '                                                     0,
    '                                                     ObjIMPRESIONFACT_BOL.xIdFactura,
    '                                                     GrdDetalleVenta.Rows(ii).Cells("Tipo").Value,
    '                                                     GrdDetalleVenta.Rows(ii).Cells("Bulto").Value,
    '                                                     GrdDetalleVenta.Rows(ii).Cells("Altura").Value,
    '                                                     GrdDetalleVenta.Rows(ii).Cells("Ancho").Value,
    '                                                     GrdDetalleVenta.Rows(ii).Cells("Largo").Value,
    '                                                     GrdDetalleVenta.Rows(ii).Cells("Peso Kg").Value,
    '                                                     Factor_,
    '                                                     GrdDetalleVenta.Rows(ii).Cells("Costo").Value)
    '                                        End If
    '                                    End If
    '                                Next
    '                            End If
    '                        Catch ex As Exception
    '                            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        End Try


    '                        '-------------------------------------------
    '                        'INSERCION DE ARTICULOS
    '                        '------------------------------------------- 
    '                        Try
    '                            If ChkArticulos.Checked = True Then
    '                                Dim ii As Integer = 0
    '                                objGuia_Envio_Articulo.iCONTROL = 1
    '                                objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = 0
    '                                objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
    '                                objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
    '                                objGuia_Envio_Articulo.iDESCUENTO = 0
    '                                objGuia_Envio_Articulo.iPENALIDAD = 0
    '                                objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
    '                                objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
    '                                objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

    '                                objGuia_Envio_Articulo.iIDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
    '                                objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18
    '                                For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
    '                                    If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
    '                                        If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
    '                                            objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(5).Value.ToString)
    '                                            objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
    '                                            objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
    '                                            objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells(1).Value.ToString)

    '                                            ObjIMPRESIONFACT_BOL.xCantidad_Peso = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
    '                                            ObjIMPRESIONFACT_BOL.xTotalPeso = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)

    '                                            objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
    '                                        End If
    '                                    End If
    '                                Next
    '                            End If
    '                        Catch ex As Exception
    '                            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        End Try


    '                        flat = True
    '                        Dim i As Integer = 0
    '                        Dim serie_NroDoc() As String
    '                        objGuiaEnvio.iControl_Documentos = 1
    '                        objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
    '                        objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
    '                        Dim iContador As Integer = 0

    '                        '-------------------------------------------
    '                        'INICIO DE DOCUMENTOS DEL CLIENTE
    '                        '-------------------------------------------                     
    '                        If objGuiaEnvio.iCONTROL = 0 Or objGuiaEnvio.iCONTROL = 1 Then
    '                            For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 2
    '                                Try
    '                                    If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Cargo")) = False Then
    '                                        'If Trim(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value.ToString) <> "" Then
    '                                        If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value) Then
    '                                            serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells(2).Value.ToString, "-")
    '                                            If serie_NroDoc.Length > 1 Then
    '                                                objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
    '                                                objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
    '                                                If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
    '                                                    If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
    '                                                        If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL() = True Then
    '                                                            strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
    '                                                            iContador = iContador + 1
    '                                                        End If
    '                                                    End If
    '                                                End If
    '                                            End If
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                End Try

    '                                Try
    '                                    If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Seguro")) = False Then
    '                                        'If Trim(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString) <> "" Then
    '                                        If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value) Then
    '                                            serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString, "-")
    '                                            If serie_NroDoc.Length > 1 Then
    '                                                objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
    '                                                objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
    '                                                If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
    '                                                    If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
    '                                                        If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL() = True Then
    '                                                            strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
    '                                                            iContador = iContador + 1
    '                                                        End If
    '                                                    End If
    '                                                End If
    '                                            End If
    '                                        End If
    '                                    End If
    '                                Catch ex As Exception
    '                                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                End Try
    '                            Next
    '                        End If

    '                        '*******************************************************************
    '                        '-->EMISON DE LA FACTURA/BOLETA ELECTRONICA - JABANTO - 19/05/2016
    '                        '*******************************************************************
    '                        Dim numeroComprobante As String = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
    '                        Emisionfe(numeroComprobante, dtImpresora)
    '                        '===================================================================

    '                        fnNUEVO()
    '                        limpiar_documentos_cliente()
    '                        flat = True
    '                        iOficinaDestino = 0
    '                        iOficinaOrigen = 0
    '                    Else
    '                        lblTotalPagado.Visible = False
    '                        lblTotalVenta.Visible = False
    '                        lblVuelto.Visible = False
    '                        txtTotalPagado.Visible = False
    '                        txtTotalVenta.Visible = False
    '                        txtVuelto.Visible = False
    '                        MessageBox.Show("La Venta no se Registró", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    End If
    '                Else
    '                    lblTotalPagado.Visible = False
    '                    lblTotalVenta.Visible = False
    '                    lblVuelto.Visible = False
    '                    txtTotalPagado.Visible = False
    '                    txtTotalVenta.Visible = False
    '                    txtVuelto.Visible = False
    '                    'MsgBox("Cancelo Operacion Puede Intentar el Pago de Nuevo", MsgBoxStyle.Information, "Seguridad Sistema")
    '                End If
    '            Else
    '                asignar_documentos_clientes()
    '                '                   
    '                If ObjVentaCargaContado.GrabarIV() = True Then
    '                    iCliente = ObjVentaCargaContado.v_IDPERSONA
    '                    ''If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
    '                    'If bMontoMinimo Then
    '                    '    ObjVentaCargaContado.fnUPDMONTO_MINIMO(ObjVentaCargaContado.v_IDFACTURA.ToString, Me.objCargaAsegurada.monto_minimo_PCE)
    '                    'End If
    '                    ''End If

    '                    'hlamas 21-08-2015
    '                    'ConfiMensajeriaDlg = New FrmConfiMensajeria
    '                    ''ConfiMensajeriaDlg.ShowDialog()
    '                    'Acceso.Asignar(ConfiMensajeriaDlg, Me.hnd)
    '                    'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
    '                    '    ConfiMensajeriaDlg.ShowDialog()
    '                    'Else
    '                    '    MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    'End If
    '                    'ConfiMensajeriaDlg = Nothing

    '                    TipoComprobante = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
    '                    ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = CboTipoEntrega.Text   ' 27/04/2007
    '                    ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString
    '                    Try
    '                        If ChkArticulos.Enabled = True Then
    '                            Dim ii As Integer = 0
    '                            objGuia_Envio_Articulo.iCONTROL = 1
    '                            objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = 0
    '                            objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
    '                            objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
    '                            objGuia_Envio_Articulo.iDESCUENTO = 0
    '                            objGuia_Envio_Articulo.iPENALIDAD = 0
    '                            objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
    '                            objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
    '                            objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol
    '                            objGuia_Envio_Articulo.iIDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
    '                            objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18
    '                            For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
    '                                If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
    '                                    If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
    '                                        objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(5).Value.ToString)
    '                                        objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
    '                                        objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
    '                                        objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells(1).Value.ToString)
    '                                        objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
    '                                    End If
    '                                End If
    '                            Next
    '                        End If
    '                    Catch ex As Exception
    '                        MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    End Try

    '                    flat = True
    '                    Dim i As Integer = 0
    '                    Dim serie_NroDoc() As String
    '                    objGuiaEnvio.iControl_Documentos = 1
    '                    objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
    '                    objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE

    '                    Dim iContador As Integer = 0

    '                    '************************GRIDVIEW DOCUMENTOS**************************************************************
    '                    If objGuiaEnvio.iCONTROL = 0 Or objGuiaEnvio.iCONTROL = 1 Then
    '                        For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 2
    '                            Try
    '                                If IsDBNull(GrdDocumentosCliente.Rows(i).Cells(2)) = False Then
    '                                    'If GrdDocumentosCliente.Rows(i).Cells(2).Value.ToString <> "" Then
    '                                    If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells(2).Value) Then
    '                                        serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells(2).Value.ToString, "-")
    '                                        If serie_NroDoc.Length > 1 Then
    '                                            objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
    '                                            objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
    '                                            If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
    '                                                If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
    '                                                    If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL() = True Then
    '                                                        strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
    '                                                        iContador = iContador + 1
    '                                                    End If
    '                                                End If
    '                                            End If
    '                                        End If
    '                                    End If
    '                                End If
    '                            Catch ex As Exception
    '                                MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                            End Try

    '                            Try
    '                                If IsDBNull(GrdDocumentosCliente.Rows(i).Cells(3)) = False Then
    '                                    'If GrdDocumentosCliente.Rows(i).Cells(3).Value.ToString <> "" Then
    '                                    If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells(3).Value) Then
    '                                        serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells(3).Value.ToString, "-")
    '                                        If serie_NroDoc.Length > 1 Then
    '                                            objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
    '                                            objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
    '                                            If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
    '                                                If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
    '                                                    If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL() = True Then
    '                                                        strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
    '                                                        iContador = iContador + 1
    '                                                    End If
    '                                                End If
    '                                            End If
    '                                        End If
    '                                    End If
    '                                End If
    '                            Catch ex As Exception
    '                                MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                            End Try
    '                        Next
    '                    End If
    '                    '****************************************************************************************************
    '                    'If MessageBox.Show("¿Está Seguro de Imprimir las Etiquetas?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                    '    If xIMPRESORA = 1 Then
    '                    '        fnImprimirEtiquetas()
    '                    '    Else
    '                    '        If xIMPRESORA = 2 Then
    '                    '            fnImprimirEtiquetasFAC_II()
    '                    '        Else
    '                    '            fnImprimirEtiquetasFAC_III()
    '                    '        End If
    '                    '    End If
    '                    'End If

    '                    '*******************************************************************
    '                    '-->EMISON DE LA FACTURA/BOLETA ELECTRONICA - JABANTO - 19/05/2016
    '                    '*******************************************************************
    '                    Dim numeroComprobante As String = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
    '                    Emisionfe(numeroComprobante, dtImpresora)
    '                    '===================================================================


    '                    TipoComprobante = 2
    '                    fnNUEVO()
    '                    limpiar_documentos_cliente()
    '                    flat = True
    '                    iOficinaDestino = 0
    '                    iOficinaOrigen = 0
    '                End If
    '            End If
    '        End If
    '        bOrigenDiferente = False
    '    Catch ex As Exception
    '        flat = False
    '        Throw New Exception(ex.Message)
    '    End Try
    '    Return flat
    'End Function

    Function Validar() As Boolean
        Dim b As Boolean = True
        If Me.TxtBoleto.Visible Then 'flagPCE And 
            If Me.TxtBoleto.Text.Trim.Length < 2 Then
                b = False
            ElseIf Not bCargaAcompañada Then
                b = False
            End If
        End If

        If Not b And iTipoComprobante = 86 Then
            MessageBox.Show("Asocie un Boleto de Viaje al Comprobante de Venta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtBoleto.Focus()
            Me.Cursor = Cursors.Default
            Return False
        End If

        '*******validacion del Nro Serie************
        If Val(LblSerie.Text.Trim) = 0 Then
            MessageBox.Show("Ingrese el Número de Serie", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.BtnGrabar.Focus()
            Return False
        ElseIf Val(LblNroBoletaFact.Text.Trim) = 0 Then
            MessageBox.Show("Ingrese el Número de Comprobante", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.BtnGrabar.Focus()
            Return False
        End If

        If idUnidadAgencias <= 0 Then
            MessageBox.Show("Seleccione la Ciudad de Destino", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtCiudadDestino.Text = ""
            TxtCiudadDestino.Focus()
            TxtCiudadDestino.SelectAll()
            Return False
        End If

        If Me.CboAgenciaDest.SelectedIndex = 0 Then
            MessageBox.Show("Debe Seleccionar la Agencia de Destino.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboAgenciaDest.Focus()
            Return False
        End If

        If Me.CboFormaPago.SelectedIndex = 1 AndAlso TxtNroTarjeta.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Número de Tarjeta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtNroTarjeta.Focus()
            TxtNroTarjeta.SelectAll()
            Return False
        End If

        '*******validando nombre del cliente********
        If TipoComprobante = 1 Then
            If TxtNroDocCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Cliente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCliente.Text = ""
                TxtCliente.Focus()
                TxtCliente.SelectAll()
                Return False
            End If
        Else
            If TxtNomCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Cliente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCliente.Text = ""
                TxtCliente.Focus()
                TxtCliente.SelectAll()
                Return False
            End If
        End If

        If Me.CboProducto.SelectedValue = 7 AndAlso Me.TxtNroDocCliente.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Nº de Documento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCliente.Text = ""
            TxtCliente.Focus()
            TxtCliente.SelectAll()
            Return False
        End If

        '*************************************Validacion de Campos*****************************************
        'hlamas 21/07/2016
        If iID_TipoDocCli = 1 Then 'tipo de documento de cliente es ruc
            If Not fnValidarRUC(TxtNroDocCliente.Text.Trim) Then
                MessageBox.Show("Ingrese un RUC Válido", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtCliente.Focus()
                Me.TxtCliente.SelectAll()
                Return False
            End If
        ElseIf iID_TipoDocCli = 3 Then 'tipo de documento de cliente es ruc
            If TxtNroDocCliente.Text.Trim.Length <> 8 Then
                MessageBox.Show("Ingrese un DNI Válido", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtCliente.Focus()
                Me.TxtCliente.SelectAll()
                Return False
            End If
        End If

        If TipoComprobante = 1 Then
            If TxtNroDocCliente.Text.Trim.Length = 11 Then
                If fnValidarRUC(TxtNroDocCliente.Text.Trim) = False Then
                    MessageBox.Show("Ingrese un RUC Válido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCliente.Focus()
                    TxtCliente.SelectAll()
                    Return False
                End If
            Else
                MessageBox.Show("Ingrese un RUC Válido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCliente.Focus()
                TxtCliente.SelectAll()
                Return False
            End If
        End If

        If TxtNroDocCliente.Text.Trim.Length = 11 Then         'ruc
            If fnValidarRUC(TxtNroDocCliente.Text.ToString.Trim) Then
                If LblTipoComprobante.Text.Substring(0, 1) <> "F" And LblTipoComprobante.Text.Substring(0, 1) <> "G" Then
                    MessageBox.Show("Se debe generar una Factura", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TxtCliente.Focus() : TxtCliente.SelectAll()
                    Return False
                End If
            Else
                MessageBox.Show("Ingrese un RUC Válido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtCliente.Focus()
                TxtCliente.SelectAll()
                Return False
            End If
        ElseIf TxtNroDocCliente.Text.Trim.Length = 8 Then         'boleta
            If LblTipoComprobante.Text.Substring(0, 1) <> "B" And LblTipoComprobante.Text.Substring(0, 1) <> "G" Then
                MessageBox.Show("Se debe generar una Boleta de Venta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtCliente.Focus() : TxtCliente.SelectAll()
                Return False
            End If
        ElseIf TxtNroDocCliente.Text.Trim.Length > 0 And TxtNroDocCliente.Text.Trim.Length < 6 Then         'sin documento
            If Not bCargaAcompañada Then
                MessageBox.Show("Ingrese Número de Documento Válido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtCliente.Focus() : TxtCliente.SelectAll()
                Return False
            End If
        End If

        'hlamas 10-06-2016
        '------------------------------------------------------------
        If Me.LblTipoComprobante.Text.Trim.Substring(0, 1) = "B" Then '==> Boleta de Venta
            If TxtNroDocCliente.Text.Trim.Length < 8 Then
                MessageBox.Show("Ingrese un DNI válido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCliente.Focus() : TxtCliente.SelectAll()
                Return False
            End If
        End If

        If TipoComprobante = 1 Then
            If Me.CboDireccion.SelectedValue = 0 Then
                MessageBox.Show("Seleccione la Dirección Fiscal", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboDireccion.Focus()
                Return False
            End If
        End If

        'Valida si total de Boleta de Venta es mayor a s/.700.00
        'If CDbl(Me.TxtTotal.Text) > 700 And Me.LblTipoComprobante.Text.Trim.Substring(0, 1) = "B" Then '==> Boleta de Venta
        '    If TxtNroDocCliente.Text.Trim.Length < 8 Then
        '        MessageBox.Show("Para Ventas mayores a S/.700.00 debe ingresar un DNI válido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        TxtCliente.Focus() : TxtCliente.SelectAll()
        '        Return False
        '    End If
        'End If

        'If Me.CboProducto.SelectedValue <> 6 AndAlso Me.CboDireccion.SelectedValue = 0 Then
        '    MessageBox.Show("Seleccione una Dirección", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.CboDireccion.Focus()
        '    Return False
        'End If

        '*******validando nombre del Consignado********
        If TxtNombConsignado.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Consignado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtConsignado.Text = ""
            TxtConsignado.Focus()
            TxtConsignado.SelectAll()
            Return False
        End If

        If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio AndAlso Me.CboDireccion2.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione la Direccion del Consignado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboDireccion2.Focus()
            CboDireccion2.SelectAll()
            Return False
        End If

        Dim iDescuento As Integer = IIf(TxtDescuento.Text.Trim <> "", TxtDescuento.Text.Trim, 0)
        If iDescuento <> 0 Then
            If iDescuento < -1000 Or iDescuento > 1000 Then
                MessageBox.Show("Ingrese un Monto de Descuento Correcto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtDescuento.Focus()
                Me.TxtDescuento.SelectAll()
                Return False
            ElseIf Me.txtDescDescto.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombre de la Persona que Autoriza el Descuento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDescDescto.Text = ""
                txtDescDescto.Focus()
                txtDescDescto.SelectAll()
                Return False
            End If
        End If

        If ChkArticulos.Checked = False And ChkVolumetrico.Checked = False Then
            'Peso
            If Val(GrdDetalleVenta.Rows(0).Cells(2).Value) > 0 And Val(GrdDetalleVenta.Rows(0).Cells(1).Value) = 0 Then
                MessageBox.Show("Ingrese Número de Bultos para Peso", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            'Volumen
            If Val(GrdDetalleVenta.Rows(1).Cells(2).Value) > 0 And Val(GrdDetalleVenta.Rows(1).Cells(1).Value) = 0 Then
                MessageBox.Show("Ingrese Número de Bultos para Volumen", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            'If ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_CANTIDAD_X_SOBRE + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN + ObjVentaCargaContado.v_MONTO_PENALIDAD <= 0 Then
            If Val(GrdDetalleVenta.Rows(0).Cells(2).Value) = 0 And Val(GrdDetalleVenta.Rows(0).Cells(1).Value) > 0 Then
                MessageBox.Show("Ingrese Peso del Envío", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
            If Val(GrdDetalleVenta.Rows(1).Cells(2).Value) = 0 And Val(GrdDetalleVenta.Rows(1).Cells(1).Value) > 0 Then
                MessageBox.Show("Ingrese Volúmen del Envío", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If

        '*******validando Monto Afecto**************
        If Val(TxtTotal.Text) <= 0 Then
            MessageBox.Show("Complete la Venta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.GrdDetalleVenta.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub ChkCliente1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente1.CheckedChanged
        If iOpcion = 2 Then
            RemoveHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
            ChkCliente1.Checked = Not ChkCliente1.Checked
            AddHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
            Return
        End If
        If ChkCliente1.Checked Then
            If Me.TxtNroDocCliente.Text.Trim.Length > 0 Or Me.TxtNomCliente.Text.Trim.Length > 0 Then
                Dim iExisteEsElCliente As Integer = ExisteEsElCliente(Me.TxtNroDocCliente.Text.Trim, CboContacto, dtContactoParalelo, "nrodocumento", "idcontacto_persona")
                Dim iId As Integer = iExisteEsElCliente

                RemoveHandler Me.CboContacto.SelectedIndexChanged, AddressOf Me.CboContacto_SelectedIndexChanged
                Me.CboContacto.DataSource = Nothing
                Me.CboContacto.Items.Clear()
                Me.CboContacto.Items.Add(" (SELECCIONE)")
                Me.CboContacto.Items.Add(Me.TxtNomCliente.Text.Trim)
                Me.TxtNroDocContacto.Text = Me.TxtNroDocCliente.Text.Trim

                dtContacto.Rows.Clear()
                Dim dr As DataRow
                dr = dtContacto.NewRow
                dr("idcontacto_persona") = 0
                dr("nombres") = " (SELECCIONE)"
                dr("nombre") = ""
                dr("idtipo_documento_contacto") = 0
                dr("nrodocumento") = ""
                dr("apepat") = ""
                dr("apemat") = ""
                dtContacto.Rows.Add(dr)

                dr = dtContacto.NewRow
                dr("idcontacto_persona") = iId
                dr("nombres") = Me.TxtNomCliente.Text.Trim
                dr("nombre") = sNombresCli
                dr("idtipo_documento_contacto") = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
                dr("nrodocumento") = Me.TxtNroDocCliente.Text.Trim
                dr("apepat") = sApCli
                dr("apemat") = sAmCli
                dtContacto.Rows.Add(dr)

                idcontacto = iId
                NombresCont = sNombresCli
                iID_TipoDocCont = iID_TipoDocCli
                apellPatCont = sApCli
                apellMatCont = sAmCli

                AddHandler Me.CboContacto.SelectedIndexChanged, AddressOf Me.CboContacto_SelectedIndexChanged
                RemoveHandler Me.CboContacto.SelectedIndexChanged, AddressOf Me.CboContacto_SelectedIndexChanged
                Me.CboContacto.SelectedIndex = 1
                AddHandler Me.CboContacto.SelectedIndexChanged, AddressOf Me.CboContacto_SelectedIndexChanged

                Me.ChkCliente2.Focus()
            Else
                MessageBox.Show("Ingrese el Cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ChkCliente1.Checked = False
                Me.TxtCliente.Focus()
            End If
        Else
            If dtContactoParalelo IsNot Nothing Then
                dtContacto = dtContactoParalelo.Copy
                Me.CboContacto.DataSource = dtContacto
                Me.CboContacto.DisplayMember = "nombres"
                Me.CboContacto.ValueMember = "idcontacto_persona"
                Me.CboContacto.SelectedIndex = 0
            Else
                Me.CboContacto.DataSource = Nothing
                Me.CboContacto.Items.Clear()
                Me.CboContacto.Items.Add(" (SELECCIONE)")
                Me.CboContacto.SelectedIndex = 0
                Me.TxtNroDocContacto.Text = ""
            End If
        End If
        NombresCont = ""
        apellPatCont = ""
        apellMatCont = ""
    End Sub

    Private Sub TxtCiudadDestino_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCiudadDestino.TextChanged

    End Sub

    Dim idDireConsignado, iIDConsignado As Integer
    Private Sub CboDireccion2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDireccion2.SelectedIndexChanged
        Try
            If iOpcion = 2 Then
                RemoveHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged
                Me.CboDireccion2.SelectedValue = ObjVentaCargaContado.v_IDDIREECION_DESTINO
                AddHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged
                Return
            End If

            If CboDireccion2.SelectedIndex = 0 Then '09092011
                TxtReferencia.Text = ""
            Else
                TxtReferencia.Text = IIf(IsDBNull(dtDireccion2.Rows(CboDireccion2.SelectedIndex).Item("de_referencia")), "", dtDireccion2.Rows(CboDireccion2.SelectedIndex).Item("de_referencia"))
                sReferencia = TxtReferencia.Text.Trim
            End If

            If Not bDirecConsigMod Then
                idDireConsignado = CboDireccion2.SelectedValue
                'idDireConsignado = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCiudadDestino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCiudadDestino.LostFocus
        Try
            Return
            Me.Cursor = Cursors.AppStarting
            idUnidadAgencias = iWinDestino.IndexOf(TxtCiudadDestino.Text)
            Dim ErrCiudad_ As String = "" : CodCiudadDest_ = -1
            If idUnidadAgencias >= 0 Then 'existe ciudad
                idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))

                If idUnidadAgencias = iOficinaDestino Then
                    Me.Cursor = Cursors.Default
                    Return
                End If

                RemoveItemsCargAseg() '--->Limpiando items [carga asegurada]
                ChkVolumetrico.Checked = False
                bCondicion = False

                '***Reseteando valores del grid****
                TipoGrid_ = FormatoGrid.BULTO
                Me.DiseñaGrdDetalleVenta()
                FormatoGrdDetalleVenta()
                '**********************************

                CodCiudadDest_ = idUnidadAgencias

                '*******lista las agencias de la ciudad destino*****************
                ObjVentaCargaContado.fnGetAgencias(idUnidadAgencias)
                ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_VarAgencias, CboAgenciaDest, ObjVentaCargaContado.coll_AgenciasVenta, Int(ObjVentaCargaContado.dt_VarAgencias.Rows(0).Item(0)))
                If Me.CboAgenciaDest.Items.Count <= 2 Then
                    Me.CboAgenciaDest.SelectedIndex = 1
                End If

                '***************************************************************               
                Me.objGuiaEnvio.TarifaPyme_ = False
                If FnExisteCliente() = False Then
                    objGuiaEnvio.TarifaPublica_ = True
                    bTieneLineaCredito = False
                    bDescuento = False
                Else
                    If CboProducto.SelectedValue <> 6 Then
                        Me.Consulta() '-->si tiene linea de credito,bdescuento,Articulos
                    ElseIf CboProducto.SelectedValue = 7 Then
                        Me.objGuiaEnvio.TarifaPyme_ = True
                    End If
                End If

                'If CboProducto.SelectedValue <> 6 Then '--->Diferente De Carga Acompañada
                '    If ObjVentaCargaContado.dt_cur_cont_destino.Rows.Count > 0 Then
                '        If ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item(0) > 0 Then
                '            ObjVentaCargaContado.v_IDCONTACTO_DESTINO = Int(ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item("idcontacto_persona").ToString)
                '            TxtNombConsignado.Text = ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item("NombreDestino").ToString
                '            TxtNroDocConsignado.Text = ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item("DniDestino").ToString
                '            txtTelfConsignado.Text = ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item("telefono").ToString
                '        Else
                '            If Not bBoleto Then
                '                ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0
                '                TxtNombConsignado.Text = ""
                '                TxtNroDocConsignado.Text = ""
                '                txtTelfConsignado.Text = ""
                '            End If
                '        End If
                '    Else
                '        If Not bBoleto Then
                '            ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0
                '            TxtNombConsignado.Text = ""
                '            TxtNroDocConsignado.Text = ""
                '            txtTelfConsignado.Text = ""
                '        End If
                '    End If
                '    '----------------------------------------------
                'End If

                '****Obteniendo el Tarifario******               
                fnTarifario()
                '*********************************
                'CboAgenciaDest.Focus()
                Me.Cursor = Cursors.Default
            ElseIf idUnidadAgencias = -1 Then '-> No existe la Ciudad Destino     
                RemoveItemsCargAseg()

                CboAgenciaDest.Items.Clear()
                TipoGrid_ = FormatoGrid.BULTO
                Me.DiseñaGrdDetalleVenta()
                FormatoGrdDetalleVenta()
                bDescuento = False
                bTieneLineaCredito = False
                iOficinaDestino = -1
                ChkArticulos.Enabled = False : ChkArticulos.Checked = False
                ChkVolumetrico.Checked = False
                Me.Cursor = Cursors.Default
            End If
            iOficinaDestino = idUnidadAgencias
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Formato()
        With Me.DgvLista
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .AllowUserToResizeColumns = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.ScrollBars = ScrollBars.Both
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ReadOnly = True 'readonly cuando este false se puede editar
            Dim fecha As New DataGridViewTextBoxColumn
            With fecha
                .HeaderText = "Fecha"
                .Name = "fecha"
                .DataPropertyName = "fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.ReadOnly = True
            End With
            Dim guia As New DataGridViewTextBoxColumn
            With guia
                .HeaderText = "Nº Guía"
                .Name = "guia"
                .DataPropertyName = "guia"
                '.SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 150
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            Dim tipo As New DataGridViewTextBoxColumn
            With tipo
                .HeaderText = "Tipo"
                .Name = "tipo"
                .DataPropertyName = "tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            End With
            'agregar columna al grid
            Dim origen As New DataGridViewTextBoxColumn
            With origen
                .HeaderText = "Orígen"
                .Name = "origen"
                .DataPropertyName = "origen"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Width = 150
            End With
            ' fin de agregado  
            'agregar columna al grid
            Dim destino As New DataGridViewTextBoxColumn
            With destino
                .HeaderText = "Destino"
                .Name = "destino"
                .DataPropertyName = "destino"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim transito As New DataGridViewTextBoxColumn
            With transito
                .HeaderText = "Tránsito"
                .Name = "transito"
                .DataPropertyName = "transito"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim documento As New DataGridViewTextBoxColumn
            With documento
                .HeaderText = "Nº Documento"
                .Name = "documento"
                .DataPropertyName = "documento"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim cliente As New DataGridViewTextBoxColumn
            With cliente
                .HeaderText = "Cliente"
                .Name = "cliente"
                .DataPropertyName = "cliente"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            Dim cantidad As New DataGridViewTextBoxColumn
            With cantidad
                .HeaderText = "Cantidad"
                .Name = "cantidad"
                .DataPropertyName = "cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            Dim total_peso As New DataGridViewTextBoxColumn
            With total_peso
                .HeaderText = "Total Peso"
                .Name = "total_peso"
                .DataPropertyName = "total_peso"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            Dim Total_Volumen As New DataGridViewTextBoxColumn
            With Total_Volumen
                .HeaderText = "Total Volumen"
                .Name = "Total_Volumen"
                .DataPropertyName = "Total_Volumen"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            Dim Precio_x_Peso As New DataGridViewTextBoxColumn
            With Precio_x_Peso
                .HeaderText = "Precio Peso"
                .Name = "Precio_x_Peso"
                .DataPropertyName = "Precio_x_Peso"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            Dim Precio_x_Volumen As New DataGridViewTextBoxColumn
            With Precio_x_Volumen
                .HeaderText = "Precio Volumen"
                .Name = "Precio_x_Volumen"
                .DataPropertyName = "Precio_x_Volumen"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            Dim Precio_x_Sobre As New DataGridViewTextBoxColumn
            With Precio_x_Sobre
                .HeaderText = "Precio Sobre"
                .Name = "Precio_x_Sobre"
                .DataPropertyName = "Precio_x_Sobre"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            Dim Monto_Base As New DataGridViewTextBoxColumn
            With Monto_Base
                .HeaderText = "Monto Base"
                .Name = "Monto_Base"
                .DataPropertyName = "Monto_Base"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Porcent_Descuento As New DataGridViewTextBoxColumn
            With Porcent_Descuento
                .HeaderText = "% Descuento"
                .Name = "Porcent_Descuento"
                .DataPropertyName = "Porcent_Descuento"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Monto_Sub_Total As New DataGridViewTextBoxColumn
            With Monto_Sub_Total
                .HeaderText = "SubTotal"
                .Name = "Monto_Sub_Total"
                .DataPropertyName = "Monto_Sub_Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Monto_Impuesto As New DataGridViewTextBoxColumn
            With Monto_Impuesto
                .HeaderText = "Impuesto"
                .Name = "Monto_Impuesto"
                .DataPropertyName = "Monto_Impuesto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Total_Costo As New DataGridViewTextBoxColumn
            With Total_Costo
                .HeaderText = "Total"
                .Name = "Total_Costo"
                .DataPropertyName = "Total_Costo"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim igv As New DataGridViewTextBoxColumn
            With igv
                .HeaderText = "Igv"
                .Name = "igv"
                .DataPropertyName = "igv"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            Dim usuario As New DataGridViewTextBoxColumn
            With usuario
                .HeaderText = "Usuario"
                .Name = "usuario"
                .DataPropertyName = "usuario"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim Estado_Doc As New DataGridViewTextBoxColumn
            With Estado_Doc
                .HeaderText = "Estado Doc."
                .Name = "Estado_Doc"
                .DataPropertyName = "Estado_Doc"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim Estado_Envio As New DataGridViewTextBoxColumn
            With Estado_Envio
                .HeaderText = "Estado Envío"
                .Name = "Estado_Envio"
                .DataPropertyName = "Estado_Envio"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim Facturado As New DataGridViewTextBoxColumn
            With Facturado
                .HeaderText = "Canje"
                .Name = "Facturado"
                .DataPropertyName = "Facturado"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim proceso As New DataGridViewTextBoxColumn
            With proceso
                .HeaderText = "Producto"
                .Name = "proceso"
                .DataPropertyName = "proceso"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim nroboleto As New DataGridViewTextBoxColumn
            With nroboleto
                .HeaderText = "Nº Boleto"
                .Name = "nroboleto"
                .DataPropertyName = "nroboleto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim comprobante As New DataGridViewTextBoxColumn
            With comprobante
                .HeaderText = "Canje Por"
                .Name = "comprobante"
                .DataPropertyName = "comprobante"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            Dim idtipo_comprobante As New DataGridViewTextBoxColumn
            With idtipo_comprobante
                .HeaderText = "idtipo_comprobante"
                .Name = "idtipo_comprobante"
                .DataPropertyName = "idtipo_comprobante"
                .Visible = False
            End With

            Dim Idestado_Factura As New DataGridViewTextBoxColumn
            With Idestado_Factura
                .HeaderText = "Idestado_Factura"
                .Name = "Idestado_Factura"
                .DataPropertyName = "Idestado_Factura"
                .Visible = False
            End With

            Dim IdFactura As New DataGridViewTextBoxColumn
            With IdFactura
                .HeaderText = "IdFactura"
                .Name = "IdFactura"
                .DataPropertyName = "IdFactura"
                .Visible = False
            End With

            Dim idforma_pago As New DataGridViewTextBoxColumn
            With idforma_pago
                .HeaderText = "idforma_pago"
                .Name = "idforma_pago"
                .DataPropertyName = "idforma_pago"
                .Visible = False
            End With

            Dim idunidad_destino As New DataGridViewTextBoxColumn
            With idunidad_destino
                .HeaderText = "idunidad_destino"
                .Name = "idunidad_destino"
                .DataPropertyName = "idunidad_destino"
                .Visible = False
            End With

            Dim idagencias_destino As New DataGridViewTextBoxColumn
            With idagencias_destino
                .HeaderText = "idagencias_destino"
                .Name = "idagencias_destino"
                .DataPropertyName = "idagencias_destino"
                .Visible = False
            End With

            Dim idunidad_origen As New DataGridViewTextBoxColumn
            With idunidad_origen
                .HeaderText = "idunidad_origen"
                .Name = "idunidad_origen"
                .DataPropertyName = "idunidad_origen"
                .Visible = False
            End With

            Dim idagencias As New DataGridViewTextBoxColumn
            With idagencias
                .HeaderText = "idagencias"
                .Name = "idagencias"
                .DataPropertyName = "idagencias"
                .Visible = False
            End With

            Dim idprocesos As New DataGridViewTextBoxColumn
            With idprocesos
                .HeaderText = "idprocesos"
                .Name = "idprocesos"
                .DataPropertyName = "idprocesos"
                .Visible = False
            End With

            Dim idestado_envio As New DataGridViewTextBoxColumn
            With idestado_envio
                .HeaderText = "idestado_envio"
                .Name = "idestado_envio"
                .DataPropertyName = "idestado_envio"
                .Visible = False
            End With

            .Columns.AddRange(fecha, guia, tipo, origen, destino, transito, documento, cliente, cantidad, _
                              total_peso, Total_Volumen, Precio_x_Peso, Precio_x_Volumen,
                              Precio_x_Sobre, Monto_Base, Porcent_Descuento, _
                              Monto_Sub_Total, Monto_Impuesto, Total_Costo, igv, _
                              usuario, Estado_Doc, Estado_Envio, Facturado, proceso, _
                              nroboleto, comprobante, idtipo_comprobante, Idestado_Factura, IdFactura, _
                              idforma_pago, idunidad_destino, idagencias_destino, idunidad_origen, _
                              idagencias, idprocesos, idestado_envio)
        End With
    End Sub

    Sub Inicio()
        Try
            Dim ds As DataSet = dtoPce.FnInicioPCE()
            ReDim objComprobanteAsegurada(19)

            With Me.CboAgenciaOrigen
                Dim dtAgenciaOrigen As DataTable = ds.Tables(1)
                .DataSource = dtAgenciaOrigen
                .ValueMember = "idagencias"
                .DisplayMember = "nombre_agencia"
            End With

            With Me.CboCiudadOrigen
                Dim dtCiudadOrigen As DataTable = ds.Tables(0)
                .DataSource = dtCiudadOrigen
                .ValueMember = "idunidad_agencia"
                .DisplayMember = "nombre_unidad"
                .SelectedValue = 0
            End With

            With Me.CboCiudadDestino
                .DataSource = ds.Tables(0).Copy
                .ValueMember = "idunidad_agencia"
                .DisplayMember = "nombre_unidad"
                .SelectedValue = 0
            End With

            With Me.CboEstado
                .DataSource = ds.Tables(2).Copy
                .ValueMember = "Idestado_Registro"
                .DisplayMember = "Estado_Registro"
                .SelectedValue = 0
            End With

            'With Me.CboTipoEntrega
            '    .DataSource = ds.Tables(4)
            '    .ValueMember = "Idtipo_Entrega"
            '    .DisplayMember = "Tipo_Entrega"
            'End With

            'With Me.CboFormaPago
            '    .DataSource = ds.Tables(5)
            '    .ValueMember = "Idtipo_Pago"
            '    .DisplayMember = "Tipo_Pago"
            'End With

            'With Me.CboTarjeta
            '    .DataSource = ds.Tables(6)
            '    .ValueMember = "Idtarjetas"
            '    .DisplayMember = "DESCRIPCION"
            'End With

            'With Me.CboProducto
            '    .DataSource = ds.Tables(7)
            '    .ValueMember = "idprocesos"
            '    .DisplayMember = "nombre_secundario"
            'End With

            Me.CboAgenciaOrigen.SelectedValue = dtoUSUARIOS.iIDAGENCIAS

            ToolTip.SetToolTip(Me.BtnBuscar, "Buscar")
            ToolTip.SetToolTip(Me.btnBuscarCliente, "Buscar Cliente o Consignado")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

#Region "Canje"
    Dim iOpcion As Integer = 0
    Sub CargarUsuario(ByVal agencia As Integer)
        Dim obj As New dtoGuia

        With Me.CboUsuario
            .DataSource = obj.ListarUsuario(agencia)
            .DisplayMember = "usuario"
            .ValueMember = "Idusuario_Personal"
            .SelectedValue = dtoUSUARIOS.IdLogin
            If IsNothing(.SelectedValue) Then
                .SelectedValue = 0
            End If
        End With
    End Sub

    Private Sub CboAgenciaOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAgenciaOrigen.SelectedIndexChanged
        If IsReference(Me.CboAgenciaOrigen.SelectedValue) Then Return
        CargarUsuario(CboAgenciaOrigen.SelectedValue)
    End Sub

    '*********CARGAR EL CLIENTE SELECCIONADO**********
    Sub Listar(ByVal NroDoc As String)
        Try
            iLlamada = 2
            Dim obj As New dtoPce
            Dim dtLista As DataTable = obj.Listar(1, NroDoc)

            With Me.DgvLista
                .DataSource = dtLista
                LblRegistros.Text = .Rows.Count
            End With

            If dtLista.Rows.Count = 0 Then
                Me.BtnPCE.Enabled = False
                Me.BtnCA.Enabled = False
                Me.BtnConsultar.Enabled = False
                MessageBox.Show("No Se Encontraron Coincidencias.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.BtnConsultar.Enabled = True
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '************CONSULTAR X NRO GUIA PCE**********  
    Sub Listar(ByVal guia As Long)
        Try
            iLlamada = 1
            Dim obj As New dtoPce
            Dim dtLista As DataTable = obj.Listar(guia)

            With Me.DgvLista
                .DataSource = dtLista
                LblRegistros.Text = .Rows.Count
            End With

            If dtLista.Rows.Count = 0 Then
                Me.BtnPCE.Enabled = False
                Me.BtnCA.Enabled = False
                Me.BtnConsultar.Enabled = False
                MessageBox.Show("No Se Encontraron Coincidencias.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtGuia.Focus()
            Else
                Me.BtnConsultar.Enabled = True
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '************CONSULTAR X NRO DOCUMENTO**********  
    Sub Listar(ByVal fecha1 As String, ByVal fecha2 As String, ByVal documento As String)
        Try
            iLlamada = 4
            Dim obj As New dtoPce
            Dim dtLista As DataTable = obj.Listar(fecha1, fecha2, documento)

            With Me.DgvLista
                .DataSource = dtLista
                LblRegistros.Text = .Rows.Count
            End With

            If dtLista.Rows.Count = 0 Then
                Me.BtnPCE.Enabled = False
                Me.BtnCA.Enabled = False
                Me.BtnConsultar.Enabled = False
                MessageBox.Show("No Se Encontraron Coincidencias.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtDocumento.Focus()
            Else
                Me.BtnConsultar.Enabled = True
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '****BUSCAR(LISTAR) FACTURAS PCE*********
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Listar(Me.DtpFechaInicio.Text, Me.DtpFechaFin.Text, CboCiudadOrigen.SelectedValue, _
                   Me.CboCiudadDestino.SelectedValue, Me.CboAgenciaOrigen.SelectedValue, Me.CboUsuario.SelectedValue, Me.CboEstado.SelectedValue)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Listar(ByVal fecha1 As String, ByVal fecha2 As String, ByVal origen As Integer, ByVal destino As Integer, _
              ByVal agencia As Integer, ByVal usuario As Integer, ByVal estado As Integer)
        Try
            iLlamada = 3
            Dim obj As New dtoPce
            Dim dtLista As DataTable = obj.Listar(fecha1, fecha2, origen, destino, agencia, usuario, estado)

            With Me.DgvLista
                .DataSource = dtLista
                LblRegistros.Text = .Rows.Count
            End With

            If dtLista.Rows.Count = 0 Then
                Me.BtnPCE.Enabled = False
                Me.BtnCA.Enabled = False
                Me.BtnConsultar.Enabled = False
                MessageBox.Show("No Se Encontraron Coincidencias.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                BtnConsultar.Enabled = True
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '****BUSCAR CLIENTES*************
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Cursor = Cursors.AppStarting
            'ObjBusquedaClientes.v_fecha_inicio = DtpFechaInicio.Text
            'ObjBusquedaClientes.v_fecha_final = DtpFechaFin.Text
            Dim ObjfrmBuscarCliente As New frmBuscarCliente
            ObjfrmBuscarCliente.DtpFechaInicio = Me.DtpFechaInicio.Text
            ObjfrmBuscarCliente.DtpFechaFin = Me.DtpFechaFin.Text
            ObjfrmBuscarCliente.Control = 1
            Acceso.Asignar(ObjfrmBuscarCliente, Me.hnd)

            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                If ObjfrmBuscarCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim dtLista As DataTable = ObjfrmBuscarCliente.dtControl_FAC
                    Me.DgvLista.DataSource = dtLista
                    '***************
                    'Me.Listar(ObjBusquedaClientes.IDDOC)
                    '***************                
                    objControlFacturasBol.iControl = 0
                End If
            Else
                MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnPCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPCE.Click
        Try
            Me.Cursor = Cursors.AppStarting
            iOpcion = 1

            Dim row As Integer = DgvLista.SelectedRows.Item(0).Index
            Dim v_idFacura As String = CType(DgvLista.Rows(row).Cells("guia").Value, String)

            '*******Validar la cancelacion del PCE q sea en el destino q le corresponda***
            'If ObjVentaCargaContado.fnSP_VALIDAR_GUIAPCE(v_idFacura) = True Then
            Dim iDestino = Me.DgvLista.CurrentRow.Cells("idunidad_destino").Value
            Dim sDestino = Me.DgvLista.CurrentRow.Cells("destino").Value
            'If iDestino = dtoUSUARIOS.m_idciudad Then
            Me.fnControlDatos(1)

            LblFechaServidor.Text = dtoUSUARIOS.m_sFecha
            ' TxtDirecCliente.Focus()
            ObjVentaCargaContado.V_CONTROL_PCE = True
            Me.CboAgenciaDest.Text = dtoUSUARIOS.m_iNombreAgencia
            RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            CboTipoTarifa.BackColor = System.Drawing.SystemColors.Control
            AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged

            DesactivarControl()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******CANJEAR CA*******************************
    Private Sub BtnCA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCA.Click
        Try
            Dim row As Integer = DgvLista.SelectedRows.Item(0).Index
            'If DgvLista.Rows(row).Cells("idprocesos").Value = 6 Then
            fnControlDatos(1)
            Me.LblFechaServidor.Text = dtoUSUARIOS.m_sFecha
            'TxtDirecCliente.Focus()
            ObjVentaCargaContado.V_CONTROL_PCE = True
            Me.CboAgenciaDest.Text = dtoUSUARIOS.m_iNombreAgencia
            DesactivarControl()
            Me.Cursor = Cursors.Default
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    '****RECUPERANDO LOS DATOS DEL PCE A CANJEAR**************************************
    'Dim iIdFactura As Integer
    Public Function fnControlDatos(ByVal var As Integer) As Boolean
        Try
            Me.TabGuia.Controls.Add(TabVenta)
            Dim row As Integer = DgvLista.SelectedRows.Item(0).Index
            Dim v_idFacura As Long = DgvLista.Rows(row).Cells("idfactura").Value
            iIdFactura = v_idFacura

            ObjVentaCargaContado.v_IDFACTURA = v_idFacura
            Dim ds As DataSet = ObjVentaCargaContado.fnVERDATA_VI(v_idFacura)
            RecuperarVenta(var, ds)
            Me.BtnGrabar.Enabled = True
            Me.TabGuia.SelectTab(1)
            GrdDocumentosCliente.ClearSelection()
            GrdDetalleVenta.ClearSelection()
            'GrdDetalleVenta.Focus()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

    Private Function asignar_seleccionados(ByVal adt_tmp As DataTable) As Boolean
        asignar_seleccionados = False
        Dim indice As Integer = 0
        If adt_tmp.Rows.Count > 0 Then
            For Each fila As DataRow In adt_tmp.Rows
                If Not fila.Item("fecha") Is DBNull.Value Then
                    Try
                        objComprobanteAsegurada(indice).ID_GUIAS_ENVIO_DOC = fila.Item("ID_GUIAS_ENVIO_DOC")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDGUIAS_ENVIO = fila.Item("IDGUIAS_ENVIO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDTIPO_COMPROBANTE = fila.Item("IDTIPO_COMPROBANTE")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).NRO_SERIE = fila.Item("NRO_SERIE")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).NRO_DOCU = fila.Item("NRO_DOCU")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDUSUARIO_PERSONAL = fila.Item("IDUSUARIO_PERSONAL")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDUSUARIO_PERSONALMOD = fila.Item("IDUSUARIO_PERSONALMOD")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDROL_USUARIO = fila.Item("IDROL_USUARIO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDROL_USUARIOMOD = fila.Item("IDROL_USUARIOMOD")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IP = fila.Item("IP")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IPMOD = fila.Item("IPMOD")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).FECHA_REGISTRO = fila.Item("FECHA_REGISTRO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).FECHA_ACTUALIZACION = fila.Item("FECHA_ACTUALIZACION")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDESTADO_REGISTRO = fila.Item("IDESTADO_REGISTRO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).FECHA = fila.Item("FECHA")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO = fila.Item("MONTO_TIPO_CAMBIO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).MONTO_SUB_TOTAL = fila.Item("MONTO_SUB_TOTAL")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).MONTO_IMPUESTO = fila.Item("MONTO_IMPUESTO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).TOTAL_COSTO = fila.Item("TOTAL_COSTO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).OBS = fila.Item("OBS")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDTIPO_MONEDA = fila.Item("IDTIPO_MONEDA")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).PORCEN = fila.Item("PORCEN")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).TIPO = fila.Item("TIPO_MONTO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).PROCEDENCIA = fila.Item("IND_PROCEDENCIA")
                    Catch
                    End Try
                    asignar_seleccionados = True
                End If
                indice = indice + 1
            Next
        End If
    End Function

    '********ultimos***********
    Sub Buscar(ByVal scliente As String, ByVal iopcion As Integer, ByVal m_idciudad As Integer, ByVal idUnidadAgencia As Integer)
        Try
            Dim frm As New FrmCliente2
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet
            If m_idciudad = ObjVentaCargaContado.v_IDUNIDAD_ORIGEN Then
                ds = obj.Buscar(scliente, iopcion, m_idciudad, idUnidadAgencia, Me.iOpcion)
            Else
                ds = obj.Buscar(scliente, iopcion, 0, idUnidadAgencia, Me.iOpcion)
            End If
            dtCliente = ds.Tables(0)
            bClienteNuevo = True

            'If Not bNuevo Then Return

            If IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                If Not bBoleto Then
                    MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.LimpiarCliente()
                    frm = New FrmCliente2
                    frm.bClienteNuevo = bClienteNuevo
                    frm.iFicha = 1
                    frm.ShowDialog()
                    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                        CargarCliente(frm)
                    End If
                End If
            ElseIf ds.Tables(0).Rows.Count = 1 Then
                Me.Mostrar(ds)
            Else
                frm.bClienteNuevo = bClienteNuevo
                frm = New FrmCliente2
                frm.iFicha = 0

                frm.cargar(ds.Tables(0), 2)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    ds = obj.Buscar(frm.TxtNumero.Text, 1, dtoUSUARIOS.m_idciudad, idUnidadAgencias, 0, 0, 0, frm.TxtNumero.Tag)
                    dtCliente = ds.Tables(0)
                    Me.Mostrar(ds)
                End If
            End If
            sDocCliente = TxtCliente.Text.Trim

            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            'If iopcion = 1 Then
            'GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, 1)
            'End If
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

    Sub Buscar(ByVal idPersona As Integer, ByVal m_idciudad As Integer, ByVal idUnidadAgencia As Integer)
        Try
            Dim frm As New FrmCliente2
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.Buscar(idPersona, m_idciudad, idUnidadAgencia)
            dtCliente = ds.Tables(0)
            bClienteNuevo = True

            'If Not bNuevo Then Return

            If IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                If Not bBoleto Then
                    MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.LimpiarCliente()
                    frm = New FrmCliente2
                    frm.bClienteNuevo = bClienteNuevo
                    frm.iFicha = 1
                    frm.ShowDialog()
                    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                        CargarCliente(frm)
                    End If
                    'Else    'carga acompañada
                    '    NuevoClienteCargaAcompañada()
                End If
            ElseIf ds.Tables(0).Rows.Count = 1 Then
                Me.Mostrar(ds)
            Else
                frm.bClienteNuevo = bClienteNuevo
                frm = New FrmCliente2
                frm.iFicha = 0

                frm.cargar(ds.Tables(0), 2)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    ds = obj.Buscar(frm.TxtNumero.Text, 1, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
                    dtCliente = ds.Tables(0)
                    Me.Mostrar(ds)
                End If
            End If
            sDocCliente = TxtCliente.Text.Trim

            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, 1)

        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub
    Dim iTipoComprobante As Integer
    Private Sub DgvLista_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLista.RowEnter
        Try
            Dim iEstado As Integer = DgvLista.Rows(e.RowIndex).Cells("Idestado_Factura").Value
            Dim sFacturado As String = DgvLista.Rows(e.RowIndex).Cells("Facturado").Value
            Dim iProceso As Integer = DgvLista.Rows(e.RowIndex).Cells("idprocesos").Value
            iTipoComprobante = DgvLista.Rows(e.RowIndex).Cells("idtipo_comprobante").Value

            If iEstado = 27 And UCase(sFacturado) = "NO" And iTipoComprobante = 86 Then
                Me.BtnPCE.Enabled = False
                Me.BtnCA.Enabled = True
            Else
                Me.BtnCA.Enabled = False
            End If

            If iEstado = 27 And UCase(sFacturado) = "NO" And iTipoComprobante = 85 Then
                Me.BtnPCE.Enabled = True
                Me.BtnCA.Enabled = False
                Me.btnDescuento.Enabled = True 'DgvLista.Rows(e.RowIndex).Cells("total_costo").Value > 20
            Else
                Me.BtnPCE.Enabled = False
                Me.btnDescuento.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            '----------------
            Me.FnConsultar()
            '----------------
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Sub FnConsultar()
        iOpcion = 2
        Me.DiseñaGrdDocumentos() '-------> Diseña Grid Documentos clientes
        TipoGrid_ = FormatoGrid.BULTO '--> Grid Bultos
        Me.DiseñaGrdDetalleVenta() '-----> Diseña GridDetalleVenta
        FormatoGrdDetalleVenta() '-------> Formato al grid

        recuperando_datos_contado = True
        fnControlDatos(2)
        '**
        'idUnidadAgencias = ObjVentaCargaContado.v_IDUNIDAD_DESTINO
        'ObjVentaCargaContado.fnGetAgencias(idUnidadAgencias)
        'ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_VarAgencias, CboAgenciaDest, ObjVentaCargaContado.coll_AgenciasVenta, Int(ObjVentaCargaContado.dt_VarAgencias.Rows(0).Item(0)))

        RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
        CboTipoTarifa.BackColor = Color.White
        AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
        '***********************************
        CboProducto.BackColor = Color.White
        'TxtDirecConsignado.Enabled = True           
        TxtDescuento.ReadOnly = False
        RbtDocumento3.Enabled = True
        RbtNombre3.Enabled = True
        '  TxtNroTarjeta.Text = ""       
        TxtCiudadDestino.ReadOnly = False
        ChkCliente2.Enabled = True
        ChkCliente1.Enabled = True
        BtnConsignado.Enabled = True
        txtDescDescto.ReadOnly = False
        GrpDestino.Enabled = True
        TxtNroTarjeta.ReadOnly = False
        GrpCondicionVenta.Enabled = True
        GrpCliente.Enabled = True
        CboContacto.Enabled = True
        GrpConsignado.Enabled = True
        GrpDescuento.Enabled = True
        GrdDocumentosCliente.ReadOnly = False
        GrdDetalleVenta.ReadOnly = False
        ChkCargo.Enabled = True
        ChkArticulos.Enabled = True
        chkSobres.Enabled = True
        ChkVolumetrico.Enabled = True
        txtCantidadSobres.ReadOnly = False
        txtMontoBase.ReadOnly = False
        txtTotalSobre.ReadOnly = False
        'BtnCargAseg.Enabled = True
        BtnGrabar.Enabled = True
        'TxtSubtotal.ReadOnly = False
        'TxtImpuesto.ReadOnly = False
        'TxtTotal.ReadOnly = False
        BtnGrabar.Enabled = False
        GrdDetalleVenta.ReadOnly = False
        '----         
        CboTarjeta.BackColor = Color.White
        CboAgenciaDest.BackColor = Color.White
        TxtConsignado.ReadOnly = False
        TxtNroDocCliente.ReadOnly = False
        CboTipoEntrega.BackColor = Color.White
        CboDireccion2.BackColor = Color.White
        TxtNroDocCliente.BackColor = Color.White
        TxtNomCliente.ReadOnly = False
        TxtNomCliente.BackColor = Color.White
        TxtTelfCliente.ReadOnly = False
        TxtTelfCliente.BackColor = Color.White
        TxtNroDocContacto.ReadOnly = False
        TxtNroDocContacto.BackColor = Color.White
        TxtNroDocConsignado.ReadOnly = False
        TxtNroDocConsignado.BackColor = Color.White
        TxtNombConsignado.ReadOnly = False
        TxtNombConsignado.BackColor = Color.White
        txtTelfConsignado.ReadOnly = False
        txtTelfConsignado.BackColor = Color.White
        TxtNroTarjeta.ReadOnly = False
        TxtNroTarjeta.BackColor = Color.White
        CboTarjeta.BackColor = Color.White
        TxtNroTarjeta.BackColor = Color.White
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.Enter And Not BtnGrabar.Focused Then
                If TxtGuia.Focused = True Then
                    If TxtGuia.Text.Trim.Length > 0 Then
                        Me.Cursor = Cursors.AppStarting
                        Dim iGuia As Long = Me.TxtGuia.Text
                        Listar(iGuia)
                        Me.Cursor = Cursors.Default
                    End If
                ElseIf TxtDocumento.Focused = True Then
                    If TxtDocumento.Text.Trim.Length > 0 Then
                        Me.Cursor = Cursors.AppStarting
                        Dim sDocumento As String = Me.TxtDocumento.Text
                        Listar(Me.DtpFechaInicio.Text, Me.DtpFechaFin.Text, sDocumento)
                        Me.Cursor = Cursors.Default
                    End If
                End If

                If Me.TxtCliente.Focused AndAlso Me.TxtCliente.Text.Trim.Length > 0 Then
                    Dim scliente As String = Me.TxtCliente.Text.Trim
                    Dim iOpcion2 As Integer = IIf(Me.RbtDocumento.Checked, 1, 2)
                    Buscar(scliente, iOpcion2, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
                ElseIf Me.TxtConsignado.Focused AndAlso Me.TxtConsignado.Text.Trim.Length > 0 Then 'AndAlso idUnidadAgencias >= 0 Then
                    BuscarConsignado()
                ElseIf Me.CboDireccion.Focused AndAlso Me.CboContacto.Enabled AndAlso Me.CboContacto.Items.Count > 1 AndAlso Me.CboContacto.SelectedIndex = 0 AndAlso Me.CboDireccion.SelectedIndex > 0 Then
                    Me.DespliegaContacto()
                Else
                    SendKeys.Send("{TAB}")
                End If
                If Me.DgvLista.Rows.Count > 0 Then
                    'SendKeys.Send("{TAB}")
                End If

            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                If Me.TabGuia.SelectedIndex = 1 AndAlso Me.BtnGrabar.Enabled Then
                    Dim sender As Object
                    Dim e As EventArgs
                    BtnGrabar_Click(sender, e)
                End If
            Else
                If TxtNroTarjeta.Focused Or TxtCliente.Focused Then
                    bvalidacionGrid = False
                End If

                If iOpcion <= 1 Then
                    'If bvalidacionGrid Then
                    'flat = True
                    'Else
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                    'End If
                    'Else
                    'flat = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return flat
        'Dim blnCancel As Boolean = True
        'Dim flat As Boolean = True
        'Try
        '    Dim var As Integer = msg.WParam.ToInt32
        '    If msg.WParam.ToInt32 = Keys.Enter And Not BtnGrabar.Focused Then
        '        If Me.TxtCliente.Focused AndAlso Me.TxtCliente.Text.Trim.Length > 0 Then
        '            Buscar()
        '        ElseIf Me.TxtConsignado.Focused AndAlso Me.TxtConsignado.Text.Trim.Length > 0 Then 'AndAlso idUnidadAgencias >= 0 Then
        '            BuscarConsignado()
        '        ElseIf Me.CboDireccion.Focused AndAlso Me.CboContacto.Enabled AndAlso Me.CboContacto.Items.Count > 1 AndAlso Me.CboContacto.SelectedIndex = 0 AndAlso Me.CboDireccion.SelectedIndex > 0 Then
        '            Me.DespliegaContacto()
        '        Else
        '            SendKeys.Send("{Tab}")
        '        End If
        '    ElseIf msg.WParam.ToInt32 = Keys.F5 Then
        '        If Me.BtnGrabar.Enabled Then
        '            Dim sender As Object
        '            Dim e As EventArgs
        '            BtnGrabar_Click(sender, e)
        '        End If
        '    Else
        '        flat = MyBase.ProcessCmdKey(msg, KeyData)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        'Return flat
    End Function
    Private Sub GrdDetalleVenta_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDetalleVenta.CellEnter
        bvalidacionGrid = True
    End Sub


    Private Sub DgvLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvLista.DoubleClick
        Try
            Me.Cursor = Cursors.AppStarting
            If DgvLista.Rows.Count <= 0 Then Me.Cursor = Cursors.Default : Return
            '----------------
            Me.FnConsultar()
            '----------------
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
#End Region

    Private Sub TabGuia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabGuia.SelectedIndexChanged
        If TabGuia.SelectedIndex = 0 Then
            Me.TabVenta = TabGuia.TabPages(1)
            Me.TabGuia.Controls.RemoveAt(1)
            Me.BtnBuscar.Focus()
        Else
            Me.BtnGrabar.Focus()
        End If
    End Sub

    Sub DesactivarControl()
        txtDescDescto.ReadOnly = True
        TxtDescuento.ReadOnly = True
        RbtDocumento3.Enabled = False
        RbtNombre3.Enabled = False
        CboAgenciaDest.BackColor = System.Drawing.SystemColors.Control
        TxtCiudadDestino.ReadOnly = True
        ChkCliente2.Enabled = False
        BtnConsignado.Enabled = False
        TxtConsignado.ReadOnly = True
        CboTipoEntrega.BackColor = System.Drawing.SystemColors.Control
        CboDireccion2.BackColor = System.Drawing.SystemColors.Control
        CboProducto.BackColor = System.Drawing.SystemColors.Control
        TxtNroDocCliente.BackColor = System.Drawing.SystemColors.Control
        TxtNroDocCliente.ReadOnly = True
        TxtNomCliente.BackColor = System.Drawing.SystemColors.Control
        TxtNomCliente.ReadOnly = True
        TxtTelfCliente.BackColor = System.Drawing.SystemColors.Control
        TxtTelfCliente.ReadOnly = True
        TxtNroDocContacto.BackColor = System.Drawing.SystemColors.Control
        TxtNroDocContacto.ReadOnly = True
        TxtNroDocConsignado.BackColor = System.Drawing.SystemColors.Control
        TxtNroDocConsignado.ReadOnly = True
        TxtNombConsignado.BackColor = System.Drawing.SystemColors.Control
        TxtNombConsignado.ReadOnly = True
        txtTelfConsignado.BackColor = System.Drawing.SystemColors.Control
        txtTelfConsignado.ReadOnly = True
        ChkCargo.Enabled = False
        ChkVolumetrico.Enabled = False
        ChkArticulos.Enabled = False
        chkSobres.Enabled = False
        txtCantidadSobres.ReadOnly = True
        txtMontoBase.ReadOnly = True
        txtTotalSobre.ReadOnly = True
        Me.GrdDetalleVenta.ReadOnly = True
        Me.ChkCliente1.Enabled = False
        Me.CboContacto.Enabled = False
        CboTarjeta.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNroTarjeta.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Function RecuperarVenta(ByVal idControl As Integer, ByVal ds As DataSet) As Boolean
        Dim iContador As Integer = 0
        Try
            If GrdDetalleVenta.Rows.Count = 5 Then
                GrdDetalleVenta.Rows.RemoveAt(4)
            End If

            bDirecConsigMod = False
            bContactoModificado = False
            bDireccionModificada = False

            '**RECUPERANDO EL PRODUCTO****************************
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            CboProducto.SelectedValue = ObjVentaCargaContado.v_proceso
            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            '**RECUPERANDO EL TIPO DE TARIFA**********************
            RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            CboTipoTarifa.SelectedIndex = ObjVentaCargaContado.TipoTarifa - 1
            AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            '**RECUPERANDO LA [FECHA EMITIDA]*********************
            Me.LblFechaServidor.Text = ObjVentaCargaContado.v_FECHA_FACTURA
            '**RECUPERANDO LA SERIE*********************************
            'Me.TxtSerie.Text = ObjVentaCargaContado.v_SERIE_FACTURA

            If iOpcion = 2 Then
                LblTipoComprobante.Text = "GUIA ENVIO"
                LblTipoComprobante.BackColor = Color.Red
                LblSerie.Text = ObjVentaCargaContado.v_NRO_GUIA
                LblSerie.Width = 118
                Me.LblSerie.Left = 722
                LblTipoComprobante.Width = 118
                LblTipoComprobante.Left = 722
                LblNroBoletaFact.Visible = False
            Else
                LblTipoComprobante.Width = 100
                LblTipoComprobante.BackColor = Color.MidnightBlue
                Me.LblSerie.Text = ObjVentaCargaContado.v_SERIE_FACTURA
                LblSerie.Width = 31
                LblSerie.Left = 740
                '**RECUPERANDO EL NRO DE [BOLETA O FACTURA]*************
                'Me.TxtNroDoc.Text = ObjVentaCargaContado.v_NRO_FACTURA
                Me.LblNroBoletaFact.Text = ObjVentaCargaContado.v_NRO_FACTURA
                LblTipoComprobante.Left = 740
                LblNroBoletaFact.Visible = True
            End If

            '**RECUPERANDO DATOS DEL ORIGEN*************************
            ObjVentaCargaContado.fnGetAgencias_2(ObjVentaCargaContado.v_IDAGENCIAS)
            'Ciudad origen
            LblCiudad.Text = ObjVentaCargaContado.v_UNIDAD_ORIGEN
            CboCiudadOrigen.SelectedValue = ObjVentaCargaContado.v_IDUNIDAD_ORIGEN
            'Agencia origen
            LblAgencia.Text = ObjVentaCargaContado.dt_rstVarAgencias_2.Rows(0).Item(0)
            CboAgenciaOrigen.Text = ObjVentaCargaContado.dt_rstVarAgencias_2.Rows(0).Item(0)
            '**RECUPERANDO DATOS DEL DESTINO************************
            'Ciudad Destino
            Me.TxtCiudadDestino.Text = ObjVentaCargaContado.v_UNIDAD_DESTINO
            iOficinaDestino = ObjVentaCargaContado.v_IDUNIDAD_DESTINO
            idUnidadAgencias = ObjVentaCargaContado.v_IDUNIDAD_DESTINO
            Me.TxtCiudadDestino.Tag = ObjVentaCargaContado.v_IDUNIDAD_DESTINO
            'Agencia Destino
            ObjVentaCargaContado.fnGetAgencias(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_VarAgencias, CboAgenciaDest, ObjVentaCargaContado.coll_AgenciasVenta, ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)

            'dtoUSUARIOS.m_iIdAgencia = ObjVentaCargaContado.v_IDAGENCIAS
            '-----------------[CONDICION DE LA VENTA]--------------------
            '*****Recuperando el [TIPO ENTREGA]
            iTipoEntrega = ObjVentaCargaContado.v_IDTIPO_ENTREGA '- 1
            'b_no_lee_tipo_entrega = False

            ''Recuperando el [TIPOPAGO]*********
            CboTipoEntrega.SelectedValue = iTipoEntrega 'ObjVentaCargaContado.v_IDTIPO_ENTREGA

            Dim TipoPago_ As Integer = ObjVentaCargaContado.v_IDTIPO_PAGO
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_Tipo_Pago, CboFormaPago, ObjVentaCargaContado.coll_Tipo_Pago, ObjVentaCargaContado.v_IDTIPO_PAGO)

            sDocCliente = ObjVentaCargaContado.v_NRO_DNI_RUC.Trim
            Dim Cliente As Integer = ObjVentaCargaContado.v_IDPERSONA
            '----------------------------------------------------------------------------------
            '**************DATOS CLIENTES******************************************************
            '***Buscando el cliente a editar     
            Me.TxtCliente.Text = ""
            If sDocCliente.Trim.Length > 0 Then
                Buscar(sDocCliente, 1, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
            Else
                Buscar(Cliente, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
            End If

            'Recuperando el [TIPOPAGO]*********
            'CboTipoEntrega.SelectedValue = iTipoEntrega 'ObjVentaCargaContado.v_IDTIPO_ENTREGA
            'End If
            '****************
            'Recuperando el [NRO DOCUMENTO CLIENTE, NRO DE RUC, NRO BOLETA]
            RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            Me.TxtNroDocCliente.Text = ObjVentaCargaContado.v_NRO_DNI_RUC.Trim
            Me.TxtNroDocCliente.Tag = ObjVentaCargaContado.v_IDPERSONA '
            AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            'Recuperando el [NOMBRE DEL CLIENTE]
            Me.TxtNomCliente.Text = ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL
            'Recuperando la [DIRECCION DEL CLIENTE]
            IdDireccionOrigen = ObjVentaCargaContado.v_IDDIREECION_ORIGEN
            ' Me.CboDireccion.Items.Add(Trim(ObjVentaCargaContado.v_DIRECCION_REMITENTE))
            RemoveHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
            Me.CboDireccion.SelectedValue = ObjVentaCargaContado.v_IDDIREECION_ORIGEN
            'IdDireccionOrigen = CboDireccion.SelectedValue
            AddHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
            'Recuperando dato [ChkCargo]**************************
            Me.ChkCargo.Checked = ObjVentaCargaContado.v_cargo
            'Recuperando el [TELEFONO DEL CLIENTE]
            Me.TxtTelfCliente.Text = ObjVentaCargaContado.v_TELEFONO_REMITENTE

            '---------------------------------------------------------------------------------
            '**************DATOS CONTACTO*****************************************************                       
            'Recuperando el [NRO DOCUMENTO CONTACTO]
            Me.TxtNroDocContacto.Text = Trim(ObjVentaCargaContado.v_NRO_DOC_REMITENTE)
            Me.TxtNroDocContacto.Tag = ObjVentaCargaContado.v_IDPERSONA_ORIGEN '----NO RECUPERA
            'Recuperando el [NOMBRE DE CONTACTO]          
            RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
            Me.CboContacto.SelectedValue = ObjVentaCargaContado.v_IDPERSONA_ORIGEN
            idcontacto = CboContacto.SelectedValue
            AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged

            RemoveHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
            If iOpcion = 2 Then
                If Me.TxtNroDocCliente.Text.Trim = Me.TxtNroDocContacto.Text.Trim And Me.TxtNroDocCliente.Text.Trim.Length > 0 Then
                    ChkCliente1.Checked = True
                Else
                    ChkCliente1.Checked = False
                End If
            Else
                ChkCliente1.Checked = False
            End If
            AddHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
            '--------------------------------------------------------------------------------
            '**************DATOS CONSIGNADO**************************************************
            Me.TxtConsignado.Text = ""
            Dim dr As DataRow
            dtConsignado = New DataTable
            dtConsignado.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
            dtConsignado.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("nombres", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("nombre", GetType(String)))
            'dtConsignado.Columns.Add(New DataColumn("idtipo_documento_contacto", GetType(Integer)))
            dtConsignado.Columns.Add(New DataColumn("tipo", GetType(Integer)))
            dtConsignado.Columns.Add(New DataColumn("apepat", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("apemat", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("telefono", GetType(String)))
            dr = dtConsignado.NewRow
            dr("idcontacto_persona") = ObjVentaCargaContado.v_IDCONTACTO_DESTINO
            dr("nombres") = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO
            dr("nombre") = ObjVentaCargaContado.v_NOMBRE_CONSIGNADO
            'dr("idtipo_documento_contacto") = frm.CboTipoDocumento.SelectedValue
            dr("tipo") = ObjVentaCargaContado.v_TIPODOC_CONSIGNADO
            dr("nrodocumento") = Trim(ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO)
            dr("apepat") = ObjVentaCargaContado.v_APEPAT_CONSIGNADO
            dr("apemat") = ObjVentaCargaContado.v_APEMAT_CONSIGNADO
            dr("telefono") = ObjVentaCargaContado.v_TELEFONO_DESTINATARIO
            dtConsignado.Rows.Add(dr)

            '***************

            'Recuperando el [NRO DOCUMENTO CONSIGNADO,RUC, BOLETA]
            Me.TxtNroDocConsignado.Tag = Trim(ObjVentaCargaContado.v_IDCONTACTO_DESTINO)
            Me.TxtNroDocConsignado.Text = Trim(ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO)
            'Recuperando el [NOMBRE DEL CONSIGNADO]
            Me.TxtNombConsignado.Text = Trim(ObjVentaCargaContado.v_NOMBRES_DESTINATARIO)
            'Recuperando el IDCONSIGNADO
            ObjVentaCargaContado.v_IDCONTACTO_DESTINO = ObjVentaCargaContado.v_IDCONTACTO_DESTINO
            iIDConsignado = ObjVentaCargaContado.v_IDCONTACTO_DESTINO
            bConsignadoNuevo = False
            'Recuperando La [DIRECCION DEL CONSIGNADO]
            If ObjVentaCargaContado.v_IDTIPO_ENTREGA = TipoEntrega.Agencia Then
                'CboTipoEntrega.SelectedIndex = 0
                '01092011
                Me.ConvertirTipoEntrega(TipoEntrega.Agencia)
                'Me.CboDireccion2.Text = "AGENCIA"
            Else
                CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio
                ObjVentaCargaContado.v_IDDIREECION_DESTINO = ObjVentaCargaContado.v_IDDIREECION_DESTINO
                idDireConsignado = ObjVentaCargaContado.v_IDDIREECION_DESTINO 'Temporal
                'idDireConsignado = 0
                Me.CboDireccion2.SelectedValue = ObjVentaCargaContado.v_IDDIREECION_DESTINO

                '******Ultimo Cambio*****   
                'Dim iFila As Integer = Me.CboDireccion2.SelectedIndex
                'iDepartamentoConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddepartamento")), 0, dtDireccion2.Rows(iFila).Item("iddepartamento"))
                'iProvinciaConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("idprovincia")), 0, dtDireccion2.Rows(iFila).Item("idprovincia"))
                'iDistritoConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddistrito")), 0, dtDireccion2.Rows(iFila).Item("iddistrito"))
                'IDviaConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_via")), 0, dtDireccion2.Rows(iFila).Item("id_via"))
                'ViaConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("via")), "", dtDireccion2.Rows(iFila).Item("via"))
                'NroConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("numero")), "", dtDireccion2.Rows(iFila).Item("numero"))
                'ManzanaConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("manzana")), "", dtDireccion2.Rows(iFila).Item("manzana"))
                'loteConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("lote")), "", dtDireccion2.Rows(iFila).Item("lote"))
                'id_NivelConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_nivel")), 0, dtDireccion2.Rows(iFila).Item("id_nivel"))
                'NivelConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("nivel")), "", dtDireccion2.Rows(iFila).Item("nivel"))
                'id_ZonaConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_zona")), 0, dtDireccion2.Rows(iFila).Item("id_zona"))
                'ZonaConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("zona")), "", dtDireccion2.Rows(iFila).Item("zona"))
                'id_ClasificacionConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Id_Clasificacion")), 0, dtDireccion2.Rows(iFila).Item("Id_Clasificacion"))
                'ClasificacionConsig = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Clasificacion")), "", dtDireccion2.Rows(iFila).Item("Clasificacion"))
                '******
            End If
            'Recuperando el [EL TELEFONO DEL CONSIGNADO]
            Me.txtTelfConsignado.Text = ObjVentaCargaContado.v_TELEFONO_DESTINATARIO

            RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
            If Me.TxtNroDocCliente.Text.Trim = Me.TxtNroDocConsignado.Text.Trim And Me.TxtNroDocCliente.Text.Trim.Length > 0 Then
                ChkCliente2.Checked = True
                'bclienteConsig = True
            Else
                ChkCliente2.Checked = False
                'bclienteConsig = False
            End If
            AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
            '--------------------------------------------------------------------------------
            '**************DATOS DESCUENTO***************************************************
            'Recuperando el [DESCUENTO]
            Me.TxtDescuento.Text = IIf(ObjVentaCargaContado.v_PORCENT_DESCUENTO = 0, "", ObjVentaCargaContado.v_PORCENT_DESCUENTO)

            If Trim(TxtDescuento.Text.Length) > 0 Then
                txtDescDescto.Enabled = True
            Else
                txtDescDescto.Enabled = False
            End If
            'Recuperando la [DESCRIPCION DEL DESCUENTO]
            Me.txtDescDescto.Text = Trim(ObjVentaCargaContado.v_MEMO)

            '--------------------------------------------------------------------------------            
            '*****RECUPERANDO DATOS DEL GRID DETALLE DE VENTA********************************  
            If ObjVentaCargaContado.v_METROCUBICO = 0 Then
                TipoGrid_ = FormatoGrid.BULTO '--------------> Grid Volumetrico
                Me.DiseñaGrdDetalleVenta() '-------> Diseña GridDetalleVenta
                FormatoGrdDetalleVenta() '---------> Formato al grid   

                '**FILA PESO**
                GrdDetalleVenta("Bulto", 0).Value() = ObjVentaCargaContado.v_CANTIDAD_X_PESO
                GrdDetalleVenta("Peso/Volumen", 0).Value() = ObjVentaCargaContado.v_TOTAL_PESO
                'If Conversion.Val(GrdDetalleVenta(iCOL, iROW).Value) = 0 Then GrdDetalleVenta(iCOL, iROW).Value = "0.00" : Return
                'GrdDetalleVenta(iCOL, iROW).Value = FormatNumber(GrdDetalleVenta(iCOL, iROW).Value, 2)
                GrdDetalleVenta("Costo", 0).Value() = ObjVentaCargaContado.v_PRECIO_X_PESO
                tarifa_Peso = ObjVentaCargaContado.v_PRECIO_X_PESO

                '**FILA VOLUMEN**
                GrdDetalleVenta("Bulto", 1).Value() = IIf(ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = 0, "", ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN)
                GrdDetalleVenta("Peso/Volumen", 1).Value() = ObjVentaCargaContado.v_TOTAL_VOLUMEN
                GrdDetalleVenta("Costo", 1).Value() = ObjVentaCargaContado.v_PRECIO_X_VOLUMEN
                tarifa_Volumen = ObjVentaCargaContado.v_PRECIO_X_VOLUMEN

                If ds.Tables(4).Rows.Count > 0 Then
                    objGuiaEnvio.CondicionTarifa_ = True
                    '--
                    objGuiaEnvio.UnidadPeso_ = ds.Tables(4).Rows.Item(0)("UNIDAD")
                    objGuiaEnvio.iPeso_Minimo = ds.Tables(4).Rows.Item(0)("INICIO")
                    objGuiaEnvio.iPeso_Maximo = ds.Tables(4).Rows.Item(0)("FIN")
                    '--
                    objGuiaEnvio.UnidadVol_ = ds.Tables(4).Rows.Item(1)("UNIDAD")
                    objGuiaEnvio.iVol_Minimo = ds.Tables(4).Rows.Item(1)("INICIO")
                    objGuiaEnvio.iVol_Maximo = ds.Tables(4).Rows.Item(1)("FIN")
                    '--
                    objGuiaEnvio.iPrecio_cond_Peso = ds.Tables(4).Rows.Item(0)("MONTO")
                    objGuiaEnvio.iPrecio_cond_Vol = ds.Tables(4).Rows.Item(1)("MONTO")

                    '****CALCULO PESO*****
                    If ObjVentaCargaContado.v_TOTAL_PESO >= objGuiaEnvio.iPeso_Minimo And ObjVentaCargaContado.v_TOTAL_PESO <= objGuiaEnvio.iPeso_Maximo Then
                        GrdDetalleVenta("Sub Neto", 0).Value = objGuiaEnvio.iPrecio_cond_Peso
                    ElseIf ObjVentaCargaContado.v_TOTAL_PESO > objGuiaEnvio.iPeso_Maximo Then
                        Dim Calculo As Double = (ObjVentaCargaContado.v_TOTAL_PESO - objGuiaEnvio.iPeso_Maximo) * (tarifa_Peso)
                        Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
                        GrdDetalleVenta("Sub Neto", 0).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                    ElseIf ObjVentaCargaContado.v_TOTAL_PESO < objGuiaEnvio.iPeso_Minimo Then
                        GrdDetalleVenta("Sub Neto", 0).Value = "0.00"
                    End If

                    '****CALCULO VOLUMEN***
                    If ObjVentaCargaContado.v_TOTAL_VOLUMEN >= objGuiaEnvio.iVol_Minimo And ObjVentaCargaContado.v_TOTAL_VOLUMEN <= objGuiaEnvio.iVol_Maximo Then
                        GrdDetalleVenta("Sub Neto", 1).Value = objGuiaEnvio.iPrecio_cond_Vol
                    ElseIf ObjVentaCargaContado.v_TOTAL_VOLUMEN > objGuiaEnvio.iVol_Maximo Then
                        Dim Calculo2 As Double = (ObjVentaCargaContado.v_TOTAL_VOLUMEN - objGuiaEnvio.iVol_Maximo) * (tarifa_Volumen)
                        Dim SubNeto As Double = (Calculo2 + objGuiaEnvio.iPrecio_cond_Vol)
                        GrdDetalleVenta("Sub Neto", 1).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                    ElseIf ObjVentaCargaContado.v_TOTAL_VOLUMEN < objGuiaEnvio.iVol_Minimo Then
                        GrdDetalleVenta("Sub Neto", 1).Value = "0.00"
                    End If
                Else
                    objGuiaEnvio.CondicionTarifa_ = False
                    GrdDetalleVenta("Sub Neto", 0).Value() = ObjVentaCargaContado.v_TOTAL_PESO * ObjVentaCargaContado.v_PRECIO_X_PESO '* ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100
                    GrdDetalleVenta("Sub Neto", 1).Value() = ObjVentaCargaContado.v_TOTAL_VOLUMEN * ObjVentaCargaContado.v_PRECIO_X_VOLUMEN '* ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100
                End If

                'FILA SOBRE
                GrdDetalleVenta("Bulto", 2).Value() = IIf(ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = 0, "", ObjVentaCargaContado.v_CANTIDAD_X_SOBRE)
                GrdDetalleVenta("Peso/Volumen", 2).Value() = "0.00"
                GrdDetalleVenta("Costo", 2).Value() = ObjVentaCargaContado.v_PRECIO_X_SOBRE
                'Nor_Sobres = ObjVentaCargaContado.v_PRECIO_X_SOBRE
                tarifa_Sobre = ObjVentaCargaContado.v_PRECIO_X_SOBRE
                GrdDetalleVenta("Sub Neto", 2).Value() = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE * ObjVentaCargaContado.v_PRECIO_X_SOBRE
                'FILA BASE
                GrdDetalleVenta("Costo", 3).Value() = Format(ObjVentaCargaContado.v_MONTO_BASE, "###,###.00")
                Monto_Base = ObjVentaCargaContado.v_MONTO_BASE
                GrdDetalleVenta("Sub Neto", 3).Value() = Format(ObjVentaCargaContado.v_MONTO_BASE, "###,###.00")
                '***************************************** 
                'hlamas 25-11-2013
                GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, 1)
                'Me.FormatoMiles()
            End If

            'hlamas 05-12-2013
            dblMontoEntregaDomicilio = Val(ds.Tables(0).Rows(0).Item("monto_entrega_domicilio"))
            If dblMontoEntregaDomicilio > 0 Then
                AgregarItemVenta("ENTREGA", GrdDetalleVenta)
                Dim intFila As Integer = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
                GrdDetalleVenta("sub neto", intFila).Value = dblMontoEntregaDomicilio
            End If

            If TxtNroDocCliente.Text.Trim.Length > 0 Then
                Dim iTarifario = ObjVentaCargaContado.TarifaGeneral(ObjVentaCargaContado.v_NRO_DNI_RUC.Trim, ObjVentaCargaContado.v_IDUNIDAD_ORIGEN, _
                                                    ObjVentaCargaContado.v_IDUNIDAD_DESTINO, 999)
                If iTarifario = 0 Then
                    bTarifarioGeneral = True
                    bContado = True
                Else
                    bTarifarioGeneral = False
                    bContado = False
                End If
            Else
                bTarifarioGeneral = True
                bContado = True
            End If

            'Recuperando el [SUB_TOTAL]**********
            TxtSubtotal.Text = Format(ObjVentaCargaContado.v_MONTO_SUB_TOTAL, "###,###,###.00")
            'Recuperando el [IGV(IMPUESTO)]**********
            TxtImpuesto.Text = Format(ObjVentaCargaContado.v_MONTO_IMPUESTO, "###,###,###.00")
            'Recuperando el [TOTAL]**********
            TxtTotal.Text = Format(ObjVentaCargaContado.v_TOTAL_COSTO, "###,###,###.00")

            If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 Then
                CboTarjeta.Enabled = True
                TxtNroTarjeta.Enabled = True
                ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_T_TARJETAS, CboTarjeta, ObjVentaCargaContado.coll_T_TARJETAS, ObjVentaCargaContado.v_IDTARJETAS)
                'Recuperando el [NRO DE TARJETA]**********
                TxtNroTarjeta.Text = ObjVentaCargaContado.v_NROTARJETA
            Else
                CboTarjeta.Enabled = False
                TxtNroTarjeta.Enabled = False
                TxtNroTarjeta.Text = ""
                RemoveHandler CboTarjeta.SelectedIndexChanged, AddressOf CboTarjeta_SelectedIndexChanged
                CboTarjeta.SelectedIndex = -1
                AddHandler CboTarjeta.SelectedIndexChanged, AddressOf CboTarjeta_SelectedIndexChanged
            End If

            '--------------------------------------------------------------------------------
            '**RECUPERANDO DATOS (GRID ARTICULOS)********************************************          
            If ObjVentaCargaContado.v_CANTIDAD_X_ARTICULO > 0 Then
                TipoGrid_ = FormatoGrid.ARTICULOS : LbldetalleVenta.Text = "Articulos"
                Me.DiseñaGrdDetalleVenta()
                GrpDescuento.Enabled = False
                RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
                ChkArticulos.Checked = True
                AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged

                lblMontoBase.Visible = True
                txtMontoBase.Visible = True
                chkSobres.Visible = True
                txtCantidadSobres.Visible = True
                txtTotalSobre.Visible = True
                Try
                    If ds.Tables(1).Rows.Count > 0 Then
                        fArticulo = True
                        For Each fila As DataRow In ds.Tables(1).Rows
                            Dim row0 As String() = {fila.Item(1), FormatNumber(fila.Item(2).ToString, 2), fila.Item(3).ToString, _
                                                    fila.Item(4).ToString, _
                                                    (fila.Item(2)) * (fila.Item(3)), fila.Item(0).ToString()
                                                   }
                            GrdDetalleVenta.Rows().Add(row0)
                        Next
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
                ChkArticulos.Checked = False
                lblMontoBase.Visible = False
                txtMontoBase.Visible = False
                chkSobres.Visible = False
                txtCantidadSobres.Visible = False
                txtTotalSobre.Visible = False
                AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
            End If

            '--------------------------------------------------------------------------------
            '**RECUPERANDO DATOS M3 (VOLUMETRICO)********************************************
            If ObjVentaCargaContado.v_METROCUBICO = 1 Then
                TipoGrid_ = FormatoGrid.VOLUMETRICO '--------> Grid Volumetrico
                Me.DiseñaGrdDetalleVenta() '-----------------> Diseña GridDetalleVenta                             
                txtMontoBase.Text = ObjVentaCargaContado.v_MONTO_BASE
                RemoveHandler ChkVolumetrico.CheckedChanged, AddressOf ChkVolumetrico_CheckedChanged
                ChkVolumetrico.Checked = True
                AddHandler ChkVolumetrico.CheckedChanged, AddressOf ChkVolumetrico_CheckedChanged

                If ds.Tables(2).Rows.Count > 0 Then
                    fArticulo = True
                    For Each fila As DataRow In ds.Tables(2).Rows
                        Dim row0 As String() = {fila.Item("ITEM"), fila.Item("CANTIDAD"), FormatNumber(fila.Item("ALTURA"), 2), _
                                                FormatNumber(fila.Item("ANCHO"), 2), FormatNumber(fila.Item("LARGO"), 2), _
                                                FormatNumber(fila.Item("PESO_KG"), 2), FormatNumber(fila.Item("PRECIO_COSTO"), 2), _
                                                FormatNumber(fila.Item("PESO_KG"), 2) * FormatNumber(fila.Item("PRECIO_COSTO"), 2)
                                                }
                        GrdDetalleVenta.Rows().Add(row0)
                    Next
                End If

                tarifa_Peso = ObjVentaCargaContado.v_PRECIO_X_PESO
                tarifa_Sobre = ObjVentaCargaContado.v_PRECIO_X_SOBRE
                '------------------------------
                'Recuperando el [SUB_TOTAL]
                TxtSubtotal.Text = Format(ObjVentaCargaContado.v_MONTO_SUB_TOTAL, "###,###,###.00")
                'Recuperando el [IGV(IMPUESTO)]
                TxtImpuesto.Text = Format(ObjVentaCargaContado.v_MONTO_IMPUESTO, "###,###,###.00")
                'Recuperando el [TOTAL]
                TxtTotal.Text = Format(ObjVentaCargaContado.v_TOTAL_COSTO, "###,###,###.00")

                chkSobres.Visible = True
                txtCantidadSobres.Visible = True
                txtTotalSobre.Visible = True
                lblMontoBase.Visible = True
                txtMontoBase.Visible = True
                GrpDescuento.Enabled = True
            Else
                RemoveHandler ChkVolumetrico.CheckedChanged, AddressOf ChkVolumetrico_CheckedChanged
                ChkVolumetrico.Checked = False
                AddHandler ChkVolumetrico.CheckedChanged, AddressOf ChkVolumetrico_CheckedChanged
            End If
            '--------------------------------------------------------------------------------
            '**RECUPERANDO DATOS DOCUMENTOS DEL CLIENTE**************************************
            If ds.Tables(3).Rows.Count > 0 Then
                For i As Integer = 1 To GrdDocumentosCliente.Rows().Count - 1
                    GrdDocumentosCliente.Rows().RemoveAt(0)
                Next

                iFilas = 0
                For Each fila As DataRow In ds.Tables(3).Rows
                    If asignar_seleccionados(ds.Tables(3)) = True Then
                        Me.agregar_documentos_asegurados()
                    End If
                Next

                Try
                    iContador = 0
                    For Each fila As DataRow In ds.Tables(3).Rows
                        If IsDBNull(fila.Item("PORCEN")) Then
                            If iFilas < iContador Then
                                GrdDocumentosCliente.Rows.Add()
                            End If
                            If Not (fila.Item(1) Is Nothing) Then
                                iContador += 1
                            End If
                        End If
                    Next

                    iContador = 0
                    For Each fila As DataRow In ds.Tables(3).Rows
                        If IsDBNull(fila.Item("PORCEN")) Then
                            iContador += 1
                            Dim idDoc0 As String = fila.Item(0)
                            Dim NroDoc0 As String = fila.Item(1)
                            '
                            GrdDocumentosCliente.Rows(iContador - 1).Cells(0).Value = idDoc0
                            GrdDocumentosCliente.Rows(iContador - 1).Cells(2).Value = NroDoc0
                        End If
                    Next
                Catch
                End Try
                'Else
                '    'GrdDocumentosCliente.Rows.Clear()
                '    'GrdDocumentosCliente.Rows.Add(3)
            End If
            If ObjVentaCargaContado.v_CANTIDAD_X_SOBRE > 0 And (ChkVolumetrico.Checked Or ChkArticulos.Checked) Then
                chkSobres.Checked = True
                RemoveHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
                txtCantidadSobres.Text = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE
                txtTotalSobre.Text = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE * ObjVentaCargaContado.v_PRECIO_X_SOBRE
                AddHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
            Else
                chkSobres.Checked = False
                RemoveHandler chkSobres.CheckedChanged, AddressOf chkSobres_CheckedChanged
                txtCantidadSobres.Enabled = False
                txtTotalSobre.Enabled = False
                AddHandler chkSobres.CheckedChanged, AddressOf chkSobres_CheckedChanged
            End If
            '--------------------------------------------------------------------------------
            '**RECUPERANDO DATOS DOCUMENTOS DEL CLIENTE**************************************
            If ObjVentaCargaContado.v_CANTIDAD_X_SOBRE > 0 And ObjVentaCargaContado.v_CANTIDAD_X_ARTICULO > 0 Then
                RemoveHandler chkSobres.CheckedChanged, AddressOf chkSobres_CheckedChanged
                RemoveHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
                chkSobres.Checked = True
                txtCantidadSobres.Enabled = True
                txtTotalSobre.Enabled = True
                txtCantidadSobres.Text = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE
                txtTotalSobre.Text = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE * ObjVentaCargaContado.v_PRECIO_X_SOBRE
                AddHandler chkSobres.CheckedChanged, AddressOf chkSobres_CheckedChanged
                AddHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
            End If

            txtMontoBase.Text = ObjVentaCargaContado.v_MONTO_BASE
            'GrdDetalleVenta.ReadOnly = True
            'fnEnableStadoControl(True)

            If idControl = 2 Then
                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 1 Then
                    TipoComprobante = 1
                    LblTipoComprobante.Text = "FACTURA"
                    'CboContacto.Enabled = True
                    'ChkCliente1.Enabled = True
                Else
                    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 2 Then
                        TipoComprobante = 2
                        If iOpcion <> 2 Then
                            LblTipoComprobante.Text = "BOLETA"
                        End If

                        'CboContacto.Enabled = False
                        'TxtNroDocContacto.Text = ""
                        'ChkCliente1.Enabled = False
                        'CboContacto.Enabled = True
                        'ChkCliente1.Enabled = True
                    End If
                End If
            End If


            If idControl = 1 Then
                CboFormaPago.Enabled = True
                ' TxtDirecCliente.Focus()
            End If


            If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 86 Then
                If fnValidarRUC(TxtNroDocCliente.Text.ToString()) Then
                    LblTipoComprobante.Text = "FACTURA"
                    If es_carga_asegurada Then
                        LblPasajero.Visible = True
                    Else
                        LblPasajero.Visible = False
                    End If
                    TipoComprobante = 1
                Else
                    If iOpcion <> 2 Then
                        LblTipoComprobante.Text = "BOLETA"
                    End If
                    If es_carga_asegurada Then
                        LblPasajero.Visible = True
                    Else
                        LblPasajero.Visible = False
                    End If
                    TipoComprobante = 2
                End If
            End If
            '09-09-2011 richard
            '*******************************************************************            
            'If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 86 Then
            '    If fnValidarRUC(TxtNroDocCliente.Text.ToString()) Then
            '        LblTipoComprobante.Text = "FACTURA"
            '        If es_carga_asegurada Then
            '            LblPasajero.Visible = True
            '        Else
            '            LblPasajero.Visible = False
            '        End If
            '        TipoComprobante = 1                  
            '    Else
            '        If iOpcion <> 2 Then
            '            LblTipoComprobante.Text = "BOLETA"
            '        End If
            '        If es_carga_asegurada Then
            '            LblPasajero.Visible = True
            '        Else
            '            LblPasajero.Visible = False
            '        End If                    
            '        TipoComprobante = 2                   
            '    End If
            'End If

            'LblTipoComprobante.Update()
            'Update()

            Controla(True)

            RemoveHandler TxtBoleto.TextChanged, AddressOf TxtBoleto_TextChanged
            RemoveHandler TxtBoleto.LostFocus, AddressOf TxtBoleto_LostFocus
            Me.TxtBoleto.Text = ObjVentaCargaContado.v_nroboleto

            If ObjVentaCargaContado.v_proceso = 6 And ObjVentaCargaContado.v_nroboleto.Trim.Length > 2 Then
                bCargaAcompañada = True
                Me.TxtBoleto.Enabled = False
                Controla(False)
                Grpa.Visible = True
                TxtBoleto.Visible = True
                TxtCiudadDestino.Enabled = False
                CboAgenciaDest.Enabled = False

                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 AndAlso ObjVentaCargaContado.v_facturado = 0 Then
                    TxtNroDocCliente.Text = TxtNroDocCliente.Text.Trim
                    TxtNroDocConsignado.Text = TxtNroDocConsignado.Text.Trim
                    TxtNomCliente.Text = TxtNomCliente.Text.Trim
                    TxtNombConsignado.Text = TxtNombConsignado.Text.Trim
                    TxtNroDocContacto.Text = TxtNroDocContacto.Text.Trim
                    'TxtNombContacto.Text = TxtNombContacto.Text.Trim
                End If
            Else
                '---
                Me.Grpa.Visible = True
                Me.Grpa.Enabled = True
                Me.TxtBoleto.Visible = True
                Me.TxtBoleto.Enabled = True
                Me.TxtBoleto.ReadOnly = False
                Me.TxtBoleto.Focus()
                '---

                Me.TxtCiudadDestino.Enabled = True
                Me.CboAgenciaDest.Enabled = True

                bCargaAcompañada = False
            End If
            '09-09-2011 richard
            '*********************************************************************
            'If ObjVentaCargaContado.v_proceso = 6 And ObjVentaCargaContado.v_nroboleto.Trim.Length > 2 Then
            '    bCargaAcompañada = True
            '    Me.TxtBoleto.Enabled = False
            '    Controla(False)
            '    Grpa.Visible = True
            '    TxtBoleto.Visible = True
            '    TxtCiudadDestino.Enabled = False
            '    CboAgenciaDest.Enabled = False

            '    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 AndAlso ObjVentaCargaContado.v_facturado = 0 Then
            '        TxtNroDocCliente.Text = TxtNroDocCliente.Text.Trim
            '        TxtNroDocConsignado.Text = TxtNroDocConsignado.Text.Trim
            '        TxtNomCliente.Text = TxtNomCliente.Text.Trim
            '        TxtNombConsignado.Text = TxtNombConsignado.Text.Trim
            '        TxtNroDocContacto.Text = TxtNroDocContacto.Text.Trim
            '        'TxtNombContacto.Text = TxtNombContacto.Text.Trim
            '    End If              
            'Else
            '    '---
            '    Me.Grpa.Visible = True
            '    Me.Grpa.Enabled = True
            '    Me.TxtBoleto.Visible = True
            '    Me.TxtBoleto.Enabled = True
            '    Me.TxtBoleto.ReadOnly = False
            '    Me.TxtBoleto.Focus()
            '    '---

            '    Me.TxtCiudadDestino.Enabled = True
            '    Me.CboAgenciaDest.Enabled = True

            '    bCargaAcompañada = False
            'End If

            'Dim bAsociado As Boolean = False
            'For Each row As DataRow In dtContacto.Rows
            '    If Not IsDBNull(row.Item("nrodocumento")) Then
            '        If row.Item("nrodocumento") = TxtNroDocContacto.Text.Trim Then
            '            bAsociado = True
            '            Exit For
            '        End If
            '    End If
            'Next

            '-------------- Propone Contacto de PCE como facturar a -----------------
            'Verifica si contacto PCE esta asociado a cliente
            If iOpcion <> 2 AndAlso Me.CboContacto.SelectedIndex >= 0 Then
                Dim iPosicion As Integer = Me.CboContacto.SelectedIndex
                RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged

                Me.TxtNroDocCliente.Text = dtContacto.Rows(iPosicion).Item("nrodocumento").ToString.Trim 'TxtNroDocContacto.Text.Trim
                Me.TxtNomCliente.Text = CboContacto.Text.Trim
                sNombresCli = dtContacto.Rows(iPosicion).Item("nombre").ToString.Trim
                sApCli = dtContacto.Rows(iPosicion).Item("apepat").ToString.Trim
                sAmCli = dtContacto.Rows(iPosicion).Item("apemat").ToString.Trim
                sCliente = dtContacto.Rows(iPosicion).Item("nombres").ToString.Trim
                iID_TipoDocCli = dtContacto.Rows(iPosicion).Item("idtipo_documento_contacto").ToString.Trim
                If fnValidarRUC(TxtNroDocCliente.Text.Trim) Then
                    iID_TipoDocCli = 1
                Else
                    If iID_TipoDocCli = 1 Then
                        iID_TipoDocCli = 3
                    End If
                End If
                    TipoComprobante = IIf(iID_TipoDocCli = 1, 1, 2)
                    Me.RefreshNroDocumento(Me.CboProducto.SelectedValue)
                    Me.LblTipoComprobante.Text = IIf(TipoComprobante = 1, "FACTURA", "BOLETA")

                    iID_Persona = ObjVentaCargaContado.BuscarCliente(Me.TxtNroDocCliente.Text)
                    If iID_Persona > 0 Then
                        bClienteNuevo = False
                    Else
                        bClienteNuevo = True
                    End If
                    bClienteModificado = False

                    dtCliente.Rows.Clear()
                    dr = dtCliente.NewRow
                    dr("idpersona") = 0
                    dr("razon_social") = sCliente
                    dr("tipo") = iID_TipoDocCli
                    dr("nu_docu_suna") = TxtNroDocContacto.Text.Trim
                    dr("nombres") = dtContacto.Rows(iPosicion).Item("nombre").ToString.Trim
                    dr("ap") = dtContacto.Rows(iPosicion).Item("apepat").ToString.Trim
                    dr("am") = dtContacto.Rows(iPosicion).Item("apemat").ToString.Trim
                    dr("telefono") = Me.TxtTelfCliente.Text.Trim
                    dtCliente.Rows.Add(dr)

                    iID_TipoDocCont = 0
                    NombresCont = ""
                    apellPatCont = ""
                    apellMatCont = ""

                    RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
                    dtContacto.Rows.Clear()

                    dr = dtContacto.NewRow
                    dr("idcontacto_persona") = 0
                    dr("nombres") = " (SELECCIONE)"
                    dr("idtipo_documento_contacto") = 0
                    dr("nrodocumento") = ""
                    dtContacto.Rows.Add(dr)

                    Me.CboContacto.DataSource = Nothing
                    Me.CboContacto.Items.Add(" (SELECCIONE)")
                    Me.CboContacto.SelectedIndex = 0
                    TxtNroDocContacto.Text = ""

                    bContactoModificado = False
                    idcontacto = 0

                    'Me.CboDireccion.DataSource = Nothing
                    'Me.CboDireccion.Items.Clear()

                    '------datos direccion estructurada---------                
                    'iDepartamentoCli = 0
                    'iProvinciaCli = 0
                    'iDistritoCli = 0
                    'IDviaCli = 0
                    'ViaCli = ""
                    'NroCli = ""
                    'ManzanaCli = ""
                    'loteCli = ""
                    'id_NivelCli = 0
                    'NivelCli = ""
                    'id_ZonaCli = 0
                    'ZonaCli = ""
                    'id_ClasificacionCli = 0
                    'ClasificacionCli = ""
                    'FormatoCli = 0

                    'Me.CboDireccion.DataSource = Nothing
                    'Me.CboDireccion.Items.Add(" (SELECCIONE)")
                    'Me.CboDireccion.SelectedIndex = 0
                    'IdDireccionOrigen = 0
                    bDireccionModificada = False

                    AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
                    AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
            Else
                    RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
                    dtContacto.Rows.Clear()

                    dr = dtContacto.NewRow
                    dr("idcontacto_persona") = 0
                    dr("nombres") = " (SELECCIONE)"
                    dr("idtipo_documento_contacto") = 0
                    dr("nrodocumento") = ""
                    dtContacto.Rows.Add(dr)

                    Me.CboContacto.DataSource = Nothing
                    Me.CboContacto.Items.Add(" (SELECCIONE)")
                    Me.CboContacto.SelectedIndex = 0
                    TxtNroDocContacto.Text = ""

                    '01092011
                    Me.CboDireccion.SelectedValue = 0
                    bContactoModificado = False
                    idcontacto = 0
                    Me.ConvertirTipoEntrega(Me.CboTipoEntrega.SelectedValue)

                    AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
            End If

            AddHandler TxtBoleto.LostFocus, AddressOf TxtBoleto_LostFocus
            AddHandler TxtBoleto.TextChanged, AddressOf TxtBoleto_TextChanged

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

    Sub CutCopyPaste(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TxtCliente.KeyDown, TxtBoleto.KeyDown, TxtConsignado.KeyDown, TxtNomCliente.KeyDown, TxtNroDocCliente.KeyDown, TxtNroDocContacto.KeyDown, TxtNroTarjeta.KeyDown, TxtReferencia.KeyDown, TxtTelfCliente.KeyDown, TxtNroTarjeta.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.V Then
                'CType(sender, TextBox).Text = Clipboard.GetDataObject().GetData(DataFormats.Text)
                CType(sender, TextBox).Paste()
            ElseIf CType(sender, TextBox).Text.Trim.Length > 0 And (e.KeyCode = Keys.X Or e.KeyCode = Keys.C) Then
                Clipboard.Clear()
                'Clipboard.SetText(CType(sender, TextBox).Text)
                CType(sender, TextBox).Copy()
                If e.KeyCode = Keys.X Then
                    CType(sender, TextBox).SelectedText = ""
                End If
            End If
        End If
    End Sub

#Region "Entrega Domicilio"

    Sub GestionaTarifaDomicilio(TipoEntrega As Integer, origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer, servicio As Integer)
        If TipoEntrega <> 2 Or origen = 0 Or destino = 0 Or producto = -1 Or tipo_tarifa = -1 Or tipo_visibilidad = 0 Then
            EliminarItemVenta("ENTREGA", GrdDetalleVenta)
            dtTarifaServicio = Nothing
            dblMontoEntregaDomicilio = 0
        Else
            dtTarifaServicio = ObtieneTarifaServicio(origen, destino, producto, 3, tipo_visibilidad, servicio)
            If dtTarifaServicio.Rows.Count > 0 Then
                AgregarItemVenta("ENTREGA", GrdDetalleVenta)
            Else
                EliminarItemVenta("ENTREGA", GrdDetalleVenta)
                dtTarifaServicio = Nothing
                dblMontoEntregaDomicilio = 0
            End If
        End If
        If TipoGrid_ = FormatoGrid.BULTO Then
            fnTotalPago()
        ElseIf TipoGrid_ <> FormatoGrid.ARTICULOS Then
            iROW = 0
            Calculo_M3()
        End If
    End Sub

    Sub ObtieneDatosDescuento()
        Dim obj As New dtoVentaCargaContado
        Dim dt As DataTable = obj.ObtieneDatosDescuento(DgvLista.Rows(DgvLista.CurrentCell.RowIndex).Cells("Idfactura").Value)
        If dt.Rows.Count > 0 Then
            Me.TxtDescuento.Text = dt.Rows(0).Item(0)
            Me.txtDescDescto.Text = dt.Rows(0).Item(1)
        End If
    End Sub

    Function ObtieneMontoVenta(tipo As Integer, comprobante As Integer) As Double
        Dim obj As New Cls_TarifaServicio_LN
        Return obj.ObtenerMontoVenta(tipo, comprobante)
    End Function

    Function ObtieneTarifaServicio(origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer, servicio As Integer) As DataTable
        Dim objTarifaLN As New Cls_TarifaServicio_LN
        Dim dt As DataTable = objTarifaLN.ObtenerTarifaServicio(origen, destino, producto, tipo_tarifa, tipo_visibilidad, servicio, 0, 1)
        Return dt
    End Function

    Private Sub ChkCargo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkCargo.CheckedChanged
        Try
            If iOpcion = 2 Then
                RemoveHandler ChkCargo.CheckedChanged, AddressOf ChkCargo_CheckedChanged
                ChkCargo.Checked = Not ChkCargo.Checked
                AddHandler ChkCargo.CheckedChanged, AddressOf ChkCargo_CheckedChanged
                Return
            End If


            dblMontoDC = ObtieneMontoDevolucionCargo()
            'If dblMontoDC = 0 Then
            If GrdDetalleVenta.Rows.Count = 0 Then Return
            If TipoGrid_ = FormatoGrid.BULTO Then
                fnTotalPago()
            ElseIf TipoGrid_ <> FormatoGrid.ARTICULOS Then
                iROW = 0
                Calculo_M3()
            End If
            'End If
        Catch
        End Try
    End Sub

    Function ObtieneMontoDevolucionCargo() As Double
        If Me.CboProducto.SelectedValue <> 0 Then Return 0 'solo aplica para tepsa encomiendas

        Dim dblMonto As Double = 0
        If ChkCargo.Checked Then
            dblMonto = dtoVentaCargaContado.MontoDevolucionCargo()
            If dblMonto > 0 Then
                Dim intFila As Integer = BuscarItemVenta("DEV CARGO", GrdDetalleVenta)
                If intFila > 0 Then
                    EliminarItemVenta("DEV CARGO", GrdDetalleVenta)
                End If
                AgregarItemVenta("DEV CARGO", GrdDetalleVenta)

                intFila = BuscarItemVenta("DEV CARGO", GrdDetalleVenta)
                GrdDetalleVenta("Sub Neto", intFila).Value = Format(dblMonto, "0.00")
            End If
        Else
            EliminarItemVenta("DEV CARGO", GrdDetalleVenta)
            dblMonto = 0
        End If
        Return dblMonto
    End Function

#End Region

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close() 'Para que este botón no este por la...
    End Sub

    Public Function GrabarCancelacion() As Boolean
        Dim flat As Boolean = False
        Try
            '-->Valida la configuarcion de la impresora - jabanto - 17/06/2016
            Dim dtImpresora As DataTable = FEManager.buscarPrint()
            If dtImpresora Is Nothing Then
                MessageBox.Show(FEManager.MESSAGE_NO_PRINT, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            'PARAMETRO TIPO_COMPROBANTE
            ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = TipoComprobante
            'PARAMETRO v_SERIE_FACTURA******************************************
            ObjVentaCargaContado.v_SERIE_FACTURA = LblSerie.Text.Trim

            'PARAMETRO v_NRO_FACTURA********************************************
            'If TxtNroDocCliente.Text <> "" Then
            ObjVentaCargaContado.v_NRO_FACTURA = RellenoRight(Mro_Digitos_Ventas, LblNroBoletaFact.Text)
            LblNroBoletaFact.Text = RellenoRight(Mro_Digitos_Ventas, LblNroBoletaFact.Text)
            'End If
            'PARAMETRO FECHA INGRESO (FECHA_FACTURA)****************************
            If bControlFiscalizacion = False Then
                ObjVentaCargaContado.v_FECHA_FACTURA = dtoUSUARIOS.m_sFecha
            Else
                ObjVentaCargaContado.v_FECHA_FACTURA = Format("DD/MM/YYYY", Me.LblFechaServidor.Text)
            End If
            'PARAMETRO PRODUCTO (IDPROCESOS)************************************
            ObjVentaCargaContado.v_iProceso = CboProducto.SelectedValue
            'PARAMETRO TIPO TARIFA**********************************************
            ObjVentaCargaContado.TipoTarifa = CboTipoTarifa.SelectedIndex

            If dtoUSUARIOS.agencia <> dtoUSUARIOS.m_iIdAgencia Or dtoUSUARIOS.agencia <> dtoUSUARIOS.iIDAGENCIAS Then
                dtoUSUARIOS.m_iIdAgencia = dtoUSUARIOS.agencia
                dtoUSUARIOS.iIDAGENCIAS = dtoUSUARIOS.agencia
                dtoUSUARIOS.m_idciudad = dtoUSUARIOS.ciudad
            End If

            'PARAMETROS CIUDAD ORIGEN (IDUNIDAD_ORIGEN)*************************
            ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad

            'PARAMETRO AGENCIA ORIGEN*******************************************
            ObjVentaCargaContado.v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia


            'PARAMETRO CIUDAD DESTINO*******************************************
            If idUnidadAgencias > 0 Then
                'PARAMETRO (IDCIUDAD_DESTINO)***********************************
                ObjVentaCargaContado.v_IDUNIDAD_DESTINO = idUnidadAgencias
                'PARAMETRO (IDAGENCIA_DESTINO*********************************
                ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = Int(ObjVentaCargaContado.coll_AgenciasVenta(CboAgenciaDest.SelectedIndex.ToString))
            End If

            'PARAMETRO TIPO ENTREGA (IDTIPO_ENTREGA)****************************
            ObjVentaCargaContado.v_IDTIPO_ENTREGA = Me.CboTipoEntrega.SelectedValue 'Int(ObjVentaCargaContado.coll_t_Tipo_Entrega(CboTipoEntrega.SelectedIndex.ToString))
            'PARAMETRO TIPO PAGO (IDTIPO_PAGO)**********************************
            ObjVentaCargaContado.v_IDTIPO_PAGO = Int(ObjVentaCargaContado.coll_Tipo_Pago(CboFormaPago.SelectedIndex.ToString))

            'PARAMETRO TARGETAS (IDTARJETAS)************************************
            ObjVentaCargaContado.v_IDTARJETAS = 0
            ObjVentaCargaContado.v_NROTARJETA = "@"
            If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 Then
                'PARAMETRO IDTARJETAS******            
                ObjVentaCargaContado.v_IDTARJETAS = Int(ObjVentaCargaContado.coll_T_TARJETAS(CboTarjeta.SelectedIndex.ToString))
                'PARAMETRO NROTARJETA******
                ObjVentaCargaContado.v_NROTARJETA = IIf(TxtNroTarjeta.Text <> "", TxtNroTarjeta.Text, "@")
            End If

            '*********************Condiciones de Modificacion***************************
            Me.FormateoVariables()

            '=================================CLIENTE=======================================================
            'PARAMETRO IDPERSONA************,
            ObjVentaCargaContado.v_IDPERSONA = IIf(bClienteNuevo, 0, iID_Persona)
            'PARAMETRO NRO_DNI_RUC**********
            ObjVentaCargaContado.v_NRO_DNI_RUC = IIf(TxtNroDocCliente.Text <> "", TxtNroDocCliente.Text, "@")
            'PARAMETRO NOMBRES_RASONSOCIAL**
            ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL = IIf(TxtNomCliente.Text <> "", TxtNomCliente.Text, "@")
            'PARAMETRO IDDIRECCION_ORIGEN****** 
            IdDireccionOrigen = Me.CboDireccion.SelectedValue
            If CboDireccion.SelectedValue = 0 Then
                IdDireccionOrigen = -1 '--> sin direccion valor(seleccione)
            ElseIf CboDireccion.SelectedValue = -1 Then
                IdDireccionOrigen = 0
            End If
            ObjVentaCargaContado.v_IDDIREECION_ORIGEN = IdDireccionOrigen
            'PARAMETRO NOMBRE DE LA DIRECCION**
            ObjVentaCargaContado.v_DIRECCION_REMITENTE = IIf(IdDireccionOrigen = -1, "@", CboDireccion.Text)

            If (TipoComprobante = 1 Or CboProducto.SelectedValue = 7) Then
                sNombresCli = ""
            ElseIf ChkCliente1.Checked And TipoComprobante = 1 Then
                NombresCont = ""
            ElseIf ChkCliente2.Checked And TipoComprobante = 1 Then
                sNombresConsig = ""
            End If
            '---------DATOS DEL CLIENTE------
            ObjVentaCargaContado.Cliente_mod = IIf(bClienteModificado, 1, 0)
            ObjVentaCargaContado.ID_TipoDocCli = iID_TipoDocCli '--->agre
            ObjVentaCargaContado.NombresCliente = sNombresCli
            ObjVentaCargaContado.apellPatCli = sApCli
            ObjVentaCargaContado.apellMatCli = sAmCli
            ObjVentaCargaContado.TelefCliente = IIf(sTelfCliente.Length > 0, sTelfCliente, "@")
            ObjVentaCargaContado.sEmail = sEmail

            '--DIRECCION ESTRUCTURADO DEL CLIENTE          
            ObjVentaCargaContado.DirecCli_mod = IIf(bDireccionModificada, 1, 0)
            ObjVentaCargaContado.id_DepartamentoCli = iDepartamentoCli
            ObjVentaCargaContado.id_ProvinciaCli = iProvinciaCli
            ObjVentaCargaContado.id_DistritoCli = iDistritoCli
            ObjVentaCargaContado.id_viaCli = IDviaCli
            ObjVentaCargaContado.viaCli = ViaCli
            ObjVentaCargaContado.NumeroCli = NroCli
            ObjVentaCargaContado.manzanaCli = ManzanaCli
            ObjVentaCargaContado.loteCli = loteCli
            ObjVentaCargaContado.id_nivelCli = id_NivelCli
            ObjVentaCargaContado.nivelCli = NivelCli
            ObjVentaCargaContado.id_zonaCli = id_ZonaCli
            ObjVentaCargaContado.zonaCli = ZonaCli
            ObjVentaCargaContado.id_clasificacionCli = id_ClasificacionCli
            ObjVentaCargaContado.clasificacionCli = ClasificacionCli
            ObjVentaCargaContado.formatoCli = FormatoCli

            '=============================DATOS CONTACTO======================================           
            'PARAMETRO ID_NOMBRE_CONTACTO**          
            If CboContacto.SelectedIndex = 0 Then
                idcontacto = -1
            End If
            'If idcontacto = 0 AndAlso Me.ChkCliente1.Checked Then
            'Dim objContacto As New dtoVentaCargaContado
            'Dim dt As DataTable = objContacto.BuscarContacto(TxtNroDocContacto.Text.Trim, TxtNroDocContacto.Text)
            'Dim resp As Integer = dt.Rows.Count
            'If resp > 0 Then
            'bContactoModificado = False
            'End If
            'End If
            'PARAMETRO NOMBRE CONTACTO*****
            ObjVentaCargaContado.v_IDPERSONA_ORIGEN = idcontacto
            ObjVentaCargaContado.v_NOMBRES_REMITENTE = IIf(Trim(CboContacto.Text) <> "", CboContacto.Text, "@") 'p
            ObjVentaCargaContado.contacto_mod = IIf(bContactoModificado, 1, 0)
            ObjVentaCargaContado.v_NRO_DOC_REMITENTE = IIf(Trim(TxtNroDocContacto.Text) <> "", TxtNroDocContacto.Text, "@")
            ObjVentaCargaContado.ID_TipoDocCont = iID_TipoDocCont
            ObjVentaCargaContado.NombreCont = NombresCont
            ObjVentaCargaContado.apellPatCont = apellPatCont
            ObjVentaCargaContado.apellMatCont = apellMatCont

            '======================================CONSIGNADO=================================
            'PARAMETRO ID_NOMBRE_CONSIGNADO**
            If Me.TxtNroDocConsignado.Tag = 0 AndAlso Me.ChkCliente2.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(TxtNroDocConsignado.Text)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    Me.TxtNroDocConsignado.Tag = 0
                Else
                    Me.TxtNroDocConsignado.Tag = dt.Rows(0).Item(0)
                    bConsignadoModificado = False
                End If
            End If
            ObjVentaCargaContado.v_IDCONTACTO_DESTINO = IIf(IsNothing(Me.TxtNroDocConsignado.Tag), 0, Me.TxtNroDocConsignado.Tag)
            'ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Trim(sNombresConsig.Trim) <> "", sNombresConsig.Trim, "@")
            ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Me.TxtNombConsignado.Text.Trim <> "", Me.TxtNombConsignado.Text.Trim, "@")
            ObjVentaCargaContado.NombConsignado_mod = IIf(bConsignadoModificado, 1, 0)
            ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO = IIf(Trim(TxtNroDocConsignado.Text) <> "", TxtNroDocConsignado.Text, "@")
            ObjVentaCargaContado.ID_TipoDocConsig = iID_TipoDocConsig
            ObjVentaCargaContado.NombreConsignado = sNombresConsig
            ObjVentaCargaContado.apellPatConsig = sapellPatConsig
            ObjVentaCargaContado.apellMatConsig = sapellMatConsig
            ObjVentaCargaContado.TelfConsignado = IIf(sTelefonoConsig.Length > 0, sTelefonoConsig, "@")

            'PARAMETRO ID_DIRECCION_DESTINO**
            If CboDireccion2.SelectedIndex = 0 Then
                idDireConsignado = -1
            End If
            ObjVentaCargaContado.v_IDDIREECION_DESTINO = idDireConsignado

            '--DIRECCION ESTRUCTURADA CONSIGNADO
            ObjVentaCargaContado.DirecConsignado_mod = IIf(bDirecConsigMod, 1, 0)
            ObjVentaCargaContado.v_DIRECCION_DESTINATARIO = IIf(idDireConsignado = -1, "@", CboDireccion2.Text)
            ObjVentaCargaContado.id_DepartamentoConsig = iDepartamentoConsig
            ObjVentaCargaContado.id_ProvinciaConsig = iProvinciaConsig
            ObjVentaCargaContado.id_DistritoConsig = iDistritoConsig
            ObjVentaCargaContado.id_viaConsig = IDviaConsig
            ObjVentaCargaContado.viaConsig = ViaConsig
            ObjVentaCargaContado.NumeroConsig = NroConsig
            ObjVentaCargaContado.manzanaConsig = ManzanaConsig
            ObjVentaCargaContado.loteConsig = loteConsig
            ObjVentaCargaContado.id_nivelConsig = id_NivelConsig
            ObjVentaCargaContado.nivelConsig = NivelConsig
            ObjVentaCargaContado.id_zonaConsig = id_ZonaConsig
            ObjVentaCargaContado.zonaConsig = ZonaConsig
            ObjVentaCargaContado.id_clasificacionConsig = id_ClasificacionConsig
            ObjVentaCargaContado.clasificacionConsig = ClasificacionConsig
            ObjVentaCargaContado.formatoConsig = FormatoConsig
            ObjVentaCargaContado.sReferencia = TxtReferencia.Text.Trim

            '---Nuevos Parametros a agregar---
            ObjVentaCargaContado.TarifarioGeneral = IIf(bTarifarioGeneral, 1, 0)
            ObjVentaCargaContado.Contado = IIf(bContado, 1, 0)

            'nota bOtrasAgencias deberia ser=true no=false
            ObjVentaCargaContado.v_OTRAS_AGENCIAS = True 'bOtrasAgencias

            'PARAMETROS PARA CARGA ACOMPAÑADA***********************************           
            If Val(iTotal_CA) > 0 Then
                ObjVentaCargaContado.v_SUB_TOTAL_CA = Format(iSub_Total_CA, "0.00")
                ObjVentaCargaContado.v_IMPUESTO_CA = Format(iImpuesto_CA, "0.00")
                ObjVentaCargaContado.v_TOTAL_CA = Format(iTotal_CA, "0.00")
            Else
                ObjVentaCargaContado.v_SUB_TOTAL_CA = 0
                ObjVentaCargaContado.v_IMPUESTO_CA = 0
                ObjVentaCargaContado.v_TOTAL_CA = 0
            End If

            'PARAMETRO v_cargo**************************************************
            ObjVentaCargaContado.v_cargo = Me.ChkCargo.Checked

            ObjVentaCargaContado.v_idagencia_venta = dtoUSUARIOS.m_iIdAgencia
            ObjVentaCargaContado.v_idciudad_venta = dtoUSUARIOS.m_idciudad
            If CboProducto.SelectedValue = 6 Then 'PARAMETROS CARGA ACOMPAÑADA
                ObjVentaCargaContado.v_nroboleto = Me.TxtBoleto.Text
                ObjVentaCargaContado.v_carga_acompañada = 1
                ObjVentaCargaContado.bOrigenDiferente = bOrigenDiferente
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = IIf(IsDBNull(Me.TxtNroDocCliente.Tag), 0, Me.TxtNroDocCliente.Tag)
            ElseIf CboProducto.SelectedValue = 0 Then 'PARAMETROS ESTANDAR(NORMAL)
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = 0 'Nota                
                ObjVentaCargaContado.bOrigenDiferente = False
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
            ElseIf CboProducto.SelectedValue = 7 Then 'PARAMETROS PYME
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = 7
                ObjVentaCargaContado.bOrigenDiferente = False
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
            ElseIf CboProducto.SelectedValue = 8 Then
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = 8
                ObjVentaCargaContado.bOrigenDiferente = False
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
            ElseIf CboProducto.SelectedValue = 10 Then 'PARAMETROS ESTANDAR(NORMAL)
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = 0 'Nota                
                ObjVentaCargaContado.bOrigenDiferente = False
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
            End If

            ' ObjVentaCargaContado.v_TELEFONO_DESTINATARIO = IIf(Trim(TxtTelfConsignado.Text) <> "", TxtTelfConsignado.Text, "@")
            ObjVentaCargaContado.v_MEMO = IIf(Trim(txtDescDescto.Text) <> "", txtDescDescto.Text, "@")
            ObjVentaCargaContado.v_MONTO_DESCUENTO = IIf(Trim(TxtDescuento.Text) <> "", TxtDescuento.Text, 0)
            '
            Dim totalCosto As Double = 0
            Dim valor1 As Double = 0
            Dim valor2 As Double = 0
            '
            ObjVentaCargaContado.v_CANTIDAD_X_PESO = 0
            ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = 0
            ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = 0

            ObjVentaCargaContado.v_TOTAL_PESO = 0
            ObjVentaCargaContado.v_TOTAL_VOLUMEN = 0
            '

            '******************************GRID BULTOS*********************************
            If ChkArticulos.Checked = False And ChkVolumetrico.Checked = False Then
                'PESO
                If IsDBNull(GrdDetalleVenta.Rows(0).Cells(2)) = False Then
                    If Conversion.Val(GrdDetalleVenta(1, 0).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 0).Value
                    If Conversion.Val(GrdDetalleVenta(2, 0).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(2, 0).Value
                    ObjVentaCargaContado.v_CANTIDAD_X_PESO = valor1
                    ObjVentaCargaContado.v_TOTAL_PESO = valor2
                    totalCosto = valor2 * tarifa_Peso
                End If

                'VOLUMEN
                If IsDBNull(GrdDetalleVenta.Rows(1).Cells(2)) = False Then
                    If Conversion.Val(GrdDetalleVenta(1, 1).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 1).Value
                    If Conversion.Val(GrdDetalleVenta(2, 1).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(2, 1).Value
                    ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = valor1
                    ObjVentaCargaContado.v_TOTAL_VOLUMEN = valor2
                    totalCosto = totalCosto + valor2 * tarifa_Volumen
                End If

                'SOBRE
                If IsDBNull(GrdDetalleVenta.Rows(2).Cells(2)) = False Then
                    If Conversion.Val(GrdDetalleVenta(1, 2).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 2).Value
                    ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = valor1
                    totalCosto = totalCosto + valor1 * tarifa_Sobre
                End If

                tarifa_Peso = Format(Val(GrdDetalleVenta(3, 0).Value), "##,###,###.00")
                tarifa_Volumen = Format(Val(GrdDetalleVenta(3, 1).Value), "##,###,###.00")
                tarifa_Sobre = Format(Val(GrdDetalleVenta(3, 2).Value), "##,###,###.00")

                ''Peso
                'If Val(GrdDetalleVenta.Rows(0).Cells(2).Value) > 0 And Val(GrdDetalleVenta.Rows(0).Cells(1).Value) = 0 Then
                '    MessageBox.Show("Debe ingresar Nº de Piezas o Bultos para Tipo Peso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Me.Cursor = Cursors.Default
                '    Return False
                'End If

                ''Volumen
                'If Val(GrdDetalleVenta.Rows(1).Cells(2).Value) > 0 And Val(GrdDetalleVenta.Rows(1).Cells(1).Value) = 0 Then
                '    MessageBox.Show("Debe ingresar Nº de Piezas o Bultos para Tipo Volumen.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Me.Cursor = Cursors.Default
                '    Return False
                'End If

                'If ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_CANTIDAD_X_SOBRE + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN + ObjVentaCargaContado.v_MONTO_PENALIDAD <= 0 Then
                '    MsgBox("No puede realizar esta operación debe enviar como mínimo un paquete...", MsgBoxStyle.Information, "Seguridad Sistema")
                '    Me.Cursor = Cursors.Default
                '    Return False
                'End If
            End If

            '******************************GRID M3*********************************
            If ChkVolumetrico.Checked = True Then
                'PESO
                If IsDBNull(GrdDetalleVenta.Rows(0).Cells(2)) = False Then
                    'valor1 = Format(Val(GrdDetalleVenta(1, 0).Value), "##,###,####.00")
                    'valor2 = Format(Val(GrdDetalleVenta(5, 0).Value), "##,###,####.00")
                    '-------
                    If Conversion.Val(GrdDetalleVenta(1, 0).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 0).Value
                    If Conversion.Val(GrdDetalleVenta(5, 0).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(5, 0).Value
                    '-------

                    ObjVentaCargaContado.v_CANTIDAD_X_PESO = valor1
                    ObjVentaCargaContado.v_TOTAL_PESO = valor2
                    totalCosto = valor2 * tarifa_Peso
                End If

                'SOBRE
                If Val(txtCantidadSobres.Text) > 0 Then
                    valor1 = Val(txtCantidadSobres.Text)
                    ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = valor1
                    totalCosto = totalCosto + valor1 * tarifa_Sobre
                End If

                '*****MOD******                
                ObjVentaCargaContado.v_METROCUBICO = 1
                ObjVentaCargaContado.v_ALTURA = FormatNumber(Format(Val(GrdDetalleVenta(2, 0).Value), "##,###,###.00"), 2)
                ObjVentaCargaContado.v_ANCHO = Format(Val(GrdDetalleVenta(3, 0).Value), "##,###,###.00")
                ObjVentaCargaContado.v_LARGO = Format(Val(GrdDetalleVenta(4, 0).Value), "##,###,###.00")
                ObjVentaCargaContado.v_PESO_KG = Format(Val(GrdDetalleVenta(5, 0).Value), "##,###,###.00")
                ObjVentaCargaContado.v_FACTOR = Factor_
                '**************

                'MOD***
                tarifa_Peso = Format(Val(GrdDetalleVenta(6, 0).Value), "##,###,###.00")
                tarifa_Sobre = Format(Val(txtMontoBase.Text), "##,###,###.00")
                '******

                'validacion
                'If Val(GrdDetalleVenta.Rows(0).Cells(5).Value) > 0 And Val(GrdDetalleVenta.Rows(0).Cells(1).Value) = 0 Then
                '    MessageBox.Show("Debe ingresar Nº de Piezas o Bultos para Tipo Peso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    '***MOD*****
                '    GrdDetalleVenta.Focus()
                '    '***********
                '    Me.Cursor = Cursors.Default
                '    Return False
                'End If
            Else
                ObjVentaCargaContado.v_METROCUBICO = 0
                ObjVentaCargaContado.v_ALTURA = 0
                ObjVentaCargaContado.v_ANCHO = 0
                ObjVentaCargaContado.v_LARGO = 0
                ObjVentaCargaContado.v_PESO_KG = 0
                ObjVentaCargaContado.v_FACTOR = 0
            End If

            If chkSobres.Checked = True Then
                ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = Val(txtCantidadSobres.Text)
            End If

            ObjVentaCargaContado.v_PRECIO_X_PESO = tarifa_Peso
            ObjVentaCargaContado.v_PRECIO_X_VOLUMEN = tarifa_Volumen
            ObjVentaCargaContado.v_PRECIO_X_SOBRE = tarifa_Sobre


            ObjVentaCargaContado.v_MONTO_SUB_TOTAL = TxtSubtotal.Text
            ObjVentaCargaContado.v_MONTO_IMPUESTO = TxtImpuesto.Text
            ObjVentaCargaContado.v_TOTAL_COSTO = TxtTotal.Text

            ObjVentaCargaContado.v_IDTIPO_MONEDA = 1 'Soles

            ObjVentaCargaContado.v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            ObjVentaCargaContado.v_IP = dtoUSUARIOS.IP
            ObjVentaCargaContado.v_IDROL_USUARIO = dtoUSUARIOS.IdRol

            ObjVentaCargaContado.v_MONTO_PENALIDAD = 0
            ObjVentaCargaContado.v_IDFUNCIONARIO_AUTORIZACION = 0

            ObjVentaCargaContado.v_IGV = dtoUSUARIOS.iIGV
            ObjVentaCargaContado.v_PORCENT_DEVOLUCION = 0
            ObjVentaCargaContado.v_PORCENT_DESCUENTO = Format(Val(TxtDescuento.Text), "###.00")
            ObjVentaCargaContado.v_MONTO_RECARGO = 0

            '----------------------------------------------------------------------------------------------------------------------------
            ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
            ObjVentaCargaContado.v_MONTO_PENALIDAD = 0                ' Para la cantidad
            ObjVentaCargaContado.v_MONTO_RECARGO = 0                    ' Para El Peso

            'hlamas 19-11-2013s
            ObjVentaCargaContado.MontoEntregaDomicilio = dblMontoEntregaDomicilio

            'hlamas 17-02-2015
            ObjVentaCargaContado.MontoDC = dblMontoDC

            'hlamas 22-10-2016
            ObjVentaCargaContado.intCancelaPCE = 1


            '****************************Grid Articulos******************************
            If ChkArticulos.Checked = True Then
                Try
                    Dim ii As Integer = 0
                    For ii = 0 To Me.GrdDetalleVenta.RowCount - 1
                        If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                            If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                ObjVentaCargaContado.v_MONTO_PENALIDAD = ObjVentaCargaContado.v_MONTO_PENALIDAD + Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
                                ObjVentaCargaContado.v_MONTO_RECARGO = ObjVentaCargaContado.v_MONTO_RECARGO + Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
                            End If
                        End If
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


                Try
                    Dim kk As Integer = 0
                    For kk = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                        If IsDBNull(GrdDetalleVenta.Rows(kk).Cells(2)) = False Then
                            If IsNumeric(GrdDetalleVenta.Rows(kk).Cells(2).Value.ToString) Then
                                If GrdDetalleVenta.Rows(kk).Cells(2).Value <> 0 Then
                                    'If IsDBNull(GrdDetalleVenta.Rows(kk).Cells(3)) Then
                                    'MsgBox("Debe ingresar el peso...", MsgBoxStyle.Information, "Seguridad Sistema")
                                    'Me.Cursor = Cursors.Default
                                    'Return False
                                    'End If
                                    'If Not IsNumeric(GrdDetalleVenta.Rows(kk).Cells(3).Value) Then
                                    'MsgBox("Debe ingresar el peso...", MsgBoxStyle.Information, "Seguridad Sistema")
                                    'Me.Cursor = Cursors.Default
                                    'Return False
                                    'End If
                                    'If GrdDetalleVenta.Rows(kk).Cells(3).Value <= 0 Then
                                    'MsgBox("Debe ingresar el peso mayor que cero...", MsgBoxStyle.Information, "Seguridad Sistema")
                                    'Me.Cursor = Cursors.Default
                                    'Return False
                                    'End If
                                End If
                            End If
                        End If
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            '********************fin grid articulos*********************************************************
            '----------------------------------------------------------------------------------------------------------------------------
            'If ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = ObjVentaCargaContado.v_IDUNIDAD_DESTINO Then
            '    MsgBox("No pueden ser iguales el Origen y el Destino...", MsgBoxStyle.Information, "Seguridad Sistema")
            '    Me.Cursor = Cursors.Default
            '    Return False
            'End If
            'If TxtCiudadDestino.Text = "" Then
            '    MsgBox("Debe definir un destino Para esta OPeracion...", MsgBoxStyle.Information, "Seguridad Sistema")
            '    Me.Cursor = Cursors.Default
            '    Return False
            'End If

            'If ObjVentaCargaContado.v_IDTIPO_ENTREGA = 2 Then
            '    'If TxtDirecConsignado.Text = "" Then
            '    '    MsgBox("Debe Ingresar la Direccion es Obligatoria...")
            '    '    TxtDirecConsignado.Focus()
            '    '    Return False
            '    'End If

            '    If CboDireccion2.Text = "" Then
            '        MsgBox("Debe Ingresar la Direccion es Obligatoria...")
            '        CboDireccion2.Focus()
            '        Me.Cursor = Cursors.Default
            '        Return False
            '    End If
            'End If

            'CboTipoEntrega
            ObjIMPRESIONFACT_BOL.fnClear()

            '**MOD***********************************
            If ChkArticulos.Checked = False And ChkVolumetrico.Checked = False Then '--BULTOS
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = Val(GrdDetalleVenta("Sub Neto", 0).Value)
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = Val(GrdDetalleVenta("Sub Neto", 1).Value)
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(GrdDetalleVenta("Sub Neto", 2).Value)
            ElseIf ChkArticulos.Checked = True Then
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = Val(GrdDetalleVenta("T.Costo", 0).Value) '---ARTICULOS
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = "0.00"
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = "0.00"
            End If

            If ChkVolumetrico.Checked = True Then
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = Val(GrdDetalleVenta("Sub Neto", 0).Value)
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = "0.00"
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Format(Val(txtTotalSobre.Text), "##,###,###.00")
            End If
            '****************************************

            ObjIMPRESIONFACT_BOL.xCantidad_Peso = ObjVentaCargaContado.v_CANTIDAD_X_PESO
            ObjIMPRESIONFACT_BOL.xCantidad_Sobre = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE
            ObjIMPRESIONFACT_BOL.xCantidad_Vol = ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN

            ObjCODIGOBARRA.clinte = ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL
            ObjCODIGOBARRA.NroDOC = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
            ObjCODIGOBARRA.AGEDOM = Mid(CboTipoEntrega.Text, 1, 3)

            ObjIMPRESIONFACT_BOL.xDestino = TxtCiudadDestino.Text
            ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL = Me.LblSerie.Text & "-" & Me.LblNroBoletaFact.Text
            ObjIMPRESIONFACT_BOL.xRazonSocial = Me.TxtNomCliente.Text.Trim
            ObjIMPRESIONFACT_BOL.xDireccionRemitente = Me.CboDireccion.Text
            ObjIMPRESIONFACT_BOL.xRuc = TxtNroDocCliente.Text
            ObjIMPRESIONFACT_BOL.xConsignado = Me.TxtNombConsignado.Text
            'ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.TxtDirecConsignado.Text'verificar
            ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.CboDireccion2.Text
            ObjIMPRESIONFACT_BOL.xfecha_factura = Me.LblFechaServidor.Text
            ObjIMPRESIONFACT_BOL.xTotalPeso = ObjVentaCargaContado.v_TOTAL_PESO
            ObjIMPRESIONFACT_BOL.xTotalVolumen = ObjVentaCargaContado.v_TOTAL_VOLUMEN
            ObjIMPRESIONFACT_BOL.xTotalSobres = 0
            ObjIMPRESIONFACT_BOL.xNroRef = Me.LblSerie.Text & "-" & Me.LblNroBoletaFact.Text
            ObjIMPRESIONFACT_BOL.xMemo = Me.txtDescDescto.Text
            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total = Me.TxtSubtotal.Text
            ObjIMPRESIONFACT_BOL.xMonto_Impuesto = TxtImpuesto.Text
            ObjIMPRESIONFACT_BOL.xTotal_Costo = ObjVentaCargaContado.v_TOTAL_COSTO
            ObjIMPRESIONFACT_BOL.xDescuento = IIf(TxtDescuento.Text <> "", TxtDescuento.Text, "")
            ObjIMPRESIONFACT_BOL.xAgenciaDestino = IIf(CboAgenciaDest.Text <> "", CboAgenciaDest.Text, "")
            ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = CboTipoEntrega.Text

            'hlamas 16-05-2017
            'Dim varDlgPagos As New frmPagosContado
            Dim dlgPago As New frmPagoContado
            dlgPago.Numero = TxtNroDocCliente.Text.Trim
            dlgPago.Cliente = TxtNomCliente.Text.Trim
            dlgPago.TotalVenta = CType(TxtTotal.Text, Double).ToString("0.00")
            If dlgPago.ShowDialog() = Windows.Forms.DialogResult.OK Then
                lblTotalPagado.Visible = True
                lblTotalVenta.Visible = True
                lblVuelto.Visible = True
                txtTotalPagado.Visible = True
                txtTotalVenta.Visible = True
                txtVuelto.Visible = True
                txtTotalVenta.Text = FormatNumber(dlgPago.lblTotalVenta.Text, 2)
                txtTotalPagado.Text = FormatNumber(dlgPago.lblTotalPago.Text, 2)
                txtVuelto.Text = FormatNumber(dlgPago.lblVuelto.Text, 2)

                asignar_documentos_clientes()

                If ObjVentaCargaContado.GrabarIV = True Then
                    iCliente = ObjVentaCargaContado.v_IDPERSONA

                    'hlamas 21-08-2015
                    'ConfiMensajeriaDlg = New FrmConfiMensajeria
                    'Acceso.Asignar(ConfiMensajeriaDlg, Me.hnd)
                    'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    '    ConfiMensajeriaDlg.ShowDialog()
                    'Else
                    '    MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'End If
                    'ConfiMensajeriaDlg = Nothing

                    ObjPagosSoles.v_idfactura_contado = ObjVentaCargaContado.v_IDFACTURA
                    ObjPagosDolares.v_idfactura_contado = ObjVentaCargaContado.v_IDFACTURA
                    ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString

                    '-------------------------------------------
                    'INSERCION VOLUMETRICO
                    '-------------------------------------------
                    Try
                        If ChkVolumetrico.Checked = True Then
                            Dim obj As New dtoVentaCargaContado
                            Dim ii As Integer = 0
                            objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                            objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
                            objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                            objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                            objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

                            For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                                If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                    If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                        obj.FNinsert_Volumetrico(
                                                 ii,
                                                 0,
                                                 ObjIMPRESIONFACT_BOL.xIdFactura,
                                                 GrdDetalleVenta.Rows(ii).Cells("Tipo").Value,
                                                 GrdDetalleVenta.Rows(ii).Cells("Bulto").Value,
                                                 GrdDetalleVenta.Rows(ii).Cells("Altura").Value,
                                                 GrdDetalleVenta.Rows(ii).Cells("Ancho").Value,
                                                 GrdDetalleVenta.Rows(ii).Cells("Largo").Value,
                                                 GrdDetalleVenta.Rows(ii).Cells("Peso Kg").Value,
                                                 Factor_,
                                                 GrdDetalleVenta.Rows(ii).Cells("Costo").Value)
                                    End If
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try


                    '-------------------------------------------
                    'INSERCION DE ARTICULOS
                    '------------------------------------------- 
                    Try
                        If ChkArticulos.Checked = True Then
                            Dim ii As Integer = 0
                            objGuia_Envio_Articulo.iCONTROL = 1
                            objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = 0
                            objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                            objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
                            objGuia_Envio_Articulo.iDESCUENTO = 0
                            objGuia_Envio_Articulo.iPENALIDAD = 0
                            objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                            objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                            objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

                            objGuia_Envio_Articulo.iIDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                            objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18
                            For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                                If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                    If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                        objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(5).Value.ToString)
                                        objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
                                        objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
                                        objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells(1).Value.ToString)

                                        ObjIMPRESIONFACT_BOL.xCantidad_Peso = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
                                        ObjIMPRESIONFACT_BOL.xTotalPeso = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)

                                        objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
                                    End If
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try


                    flat = True
                    Dim i As Integer = 0
                    Dim serie_NroDoc() As String
                    objGuiaEnvio.iControl_Documentos = 1
                    objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                    objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                    Dim iContador As Integer = 0

                    '-------------------------------------------
                    'INICIO DE DOCUMENTOS DEL CLIENTE
                    '-------------------------------------------                     
                    If objGuiaEnvio.iCONTROL = 0 Or objGuiaEnvio.iCONTROL = 1 Then
                        For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 2
                            Try
                                If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Cargo")) = False Then
                                    'If Trim(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value.ToString) <> "" Then
                                    If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value) Then
                                        serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells(2).Value.ToString, "-")
                                        If serie_NroDoc.Length > 1 Then
                                            objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                            objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                            If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                                If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                                    If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL() = True Then
                                                        strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
                                                        iContador = iContador + 1
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try

                            Try
                                If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Seguro")) = False Then
                                    'If Trim(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString) <> "" Then
                                    If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value) Then
                                        serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString, "-")
                                        If serie_NroDoc.Length > 1 Then
                                            objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                            objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                            If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                                If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                                    If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL() = True Then
                                                        strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
                                                        iContador = iContador + 1
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        Next
                    End If

                    'hlamas 16-05-2017
                    'Grabar tipo de pagos
                    GrabarTipoPago(dlgPago, ObjVentaCargaContado.v_IDFACTURA)

                    'hlamas 16-05-2017
                    GrabarNotaCredito(dlgPago, ObjVentaCargaContado.v_IDPERSONA, dtImpresora)

                    '*******************************************************************
                    '-->EMISON DE LA FACTURA/BOLETA ELECTRONICA - JABANTO - 19/05/2016
                    '*******************************************************************
                    'Dim numeroComprobante As String = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
                    'Emisionfe(numeroComprobante, dtImpresora)
                    '===================================================================

                    fnNUEVO()
                    limpiar_documentos_cliente()
                    flat = True
                    iOficinaDestino = 0
                    iOficinaOrigen = 0
                Else
                    lblTotalPagado.Visible = False
                    lblTotalVenta.Visible = False
                    lblVuelto.Visible = False
                    txtTotalPagado.Visible = False
                    txtTotalVenta.Visible = False
                    txtVuelto.Visible = False
                    MessageBox.Show("La Venta no se Registró", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                lblTotalPagado.Visible = False
                lblTotalVenta.Visible = False
                lblVuelto.Visible = False
                txtTotalPagado.Visible = False
                txtTotalVenta.Visible = False
                txtVuelto.Visible = False
                'MsgBox("Cancelo Operacion Puede Intentar el Pago de Nuevo", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            bOrigenDiferente = False
        Catch ex As Exception
            flat = False
            Throw New Exception(ex.Message)
        End Try
        Return flat
    End Function

    Sub GrabarTipoPago(ByVal frm As frmPagoContado, ByVal comprobante As Integer)
        Try
            Dim obj As New dtoVentaCargaContado
            With frm
                strTipoPago = ""
                For Each row As DataGridViewRow In .dgvPago.Rows
                    obj.GrabarTipoPago(comprobante, row.Cells("tipo_pago").Value, row.Cells("tipo_tarjeta").Value, row.Cells("afecto").Value, _
                                       row.Cells("pago").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, row.Cells("tarjeta").Value)
                    intCortesia = row.Cells("tipo_pago").Value
                    strTipoPago &= TipoPago(row.Cells("tipo_pago").Value) & ","
                Next
                If strTipoPago.Trim.Length > 0 Then
                    strTipoPago = strTipoPago.Substring(0, strTipoPago.Trim.Length - 1)
                End If
            End With
        Catch
        End Try
    End Sub

    Sub GrabarNotaCredito(ByVal frm As frmPagoContado, ByVal cliente As Integer, ByVal dtImpresora As DataTable)
        Try
            Dim intTipoPago As Integer = 0
            Dim dblPago As Double, dblCuota As Double, dblResultado As Double
            Dim intComprobanteOriginal As Integer, intTipo As Integer, strFecha As String, strSerie As String
            Dim dt As New DataTable, dtCtaCte As DataTable
            Dim obj As New dtoVentaCargaContado
            With frm
                For Each row As DataGridViewRow In .dgvPago.Rows 'buscar pago con nota de credito
                    If row.Cells("tipo_pago").Value = 6 Then 'si encuentra pago con nota de credito
                        dtCtaCte = obj.ListarCtaCteDetalle(cliente) 'lista de saldo cta cte por comprobante sin devolucion de dinero
                        If dtCtaCte.Rows.Count > 0 Then
                            dblResultado = row.Cells("pago").Value
                            For Each rowCtaCte As DataRow In dtCtaCte.Rows
                                intComprobanteOriginal = rowCtaCte.Item("comprobante")
                                intTipo = rowCtaCte.Item("tipo")
                                strFecha = rowCtaCte.Item("fecha")
                                strSerie = rowCtaCte.Item("serie")

                                dblCuota = rowCtaCte.Item("monto")
                                If dblResultado - dblCuota >= 0 Then
                                    dblPago = dblCuota
                                Else
                                    dblPago = dblResultado
                                End If
                                dblResultado = dblResultado - dblCuota
                                dt = obj.GrabarNotaCredito(intComprobanteOriginal, 30, row.Cells("pago").Value, dblPago, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.IdLogin, _
                                                      dtoUSUARIOS.IP)
                                EnviarNotaCreditoSunat(dt.Rows(0), row.Cells("pago").Value, dblPago, intTipo, strSerie, strFecha, dtImpresora)

                                If dblResultado <= 0 Then
                                    Exit For
                                End If
                            Next
                        End If
                        Exit For
                    End If
                Next
            End With
        Catch
        End Try
    End Sub

    Private Sub EnviarNotaCreditoSunat(ByVal dataRowNota As DataRow, ByVal total As Double, ByVal pago As Double, ByVal tipo As Integer, ByVal comprobante As String, ByVal fecha As String, _
                                           ByVal dtImpresora As DataTable)
        Dim dblSubtotal As Double, dblImpuesto As Double
        Dim intOperacion As Integer
        Dim strGlosa As String

        dblSubtotal = Math.Round(pago / 1.18, 2)
        dblImpuesto = Math.Round(pago - dblSubtotal, 2)

        If total > pago Then
            intOperacion = 12
            strGlosa = "RETIRO TOTAL DE CARGA"
        Else
            intOperacion = 12
            strGlosa = "RETIRO TOTAL DE CARGA"
        End If

        '-->Nota de credito
        '******************************
        'Busca el Comprobante original
        Dim comprobanteReferenciaID As String = tipo
        Dim comprobanteReferenciaNumero As String = comprobante
        Dim comprobanteReferenciaFecha As String = fecha

        Dim fenote As FENota = Nothing
        If Not (dataRowNota Is Nothing) Then
            Dim fecliente As New FECliente
            fecliente.tipoDocumentoID = dataRowNota("idtipo_doc_identidad").ToString
            fecliente.numeroDocumento = dataRowNota("nu_docu_suna").ToString
            fecliente.nombres = dataRowNota("razon_social").ToString
            fecliente.direccion = dataRowNota("direccionOrigen").ToString

            Dim documentoReferencia As New FEDocumentoReferencia
            documentoReferencia.tipoDocumentoID = comprobanteReferenciaID
            documentoReferencia.numeroDocumento = comprobanteReferenciaNumero
            documentoReferencia.fechaEmision = comprobanteReferenciaFecha

            fenote = New FENota
            fenote.numeroSerie = dataRowNota(0).ToString()
            fenote.numeroCorrelativo = dataRowNota(1).ToString()
            fenote.cliente = fecliente
            fenote.documentoReferencia = documentoReferencia
            fenote.fechaEmison = FechaServidor()
            fenote.igv = dblImpuesto
            fenote.subTotal = dblSubtotal
            fenote.total = pago
            fenote.tipoNota = intOperacion 'Me.dgvLista.CurrentRow.Cells("codigo_sunat").Value 'DirectCast(dgvLista.CurrentRow.Tag, DataRow)("codigo_sunat")
            fenote.descripcionTipoNota = strGlosa 'Me.dgvLista.CurrentRow.Cells("descripcion_sunat").Value 'DirectCast(dgvLista.CurrentRow.Tag, DataRow)("descripcion_sunat")
            fenote.totalLentras = ConvercionNroEnLetras(fenote.total)
            fenote.descripcionSustento = strGlosa.Trim.ToUpper()
            'hlamas 12-04-2017
            fenote.agenciaId = dtoUSUARIOS.iIDAGENCIAS
            fenote.usuarioID = dtoUSUARIOS.IdLogin
            fenote.usuarioInsercion = dtoUSUARIOS.IdLogin
            fenote.usuarioModificacion = dtoUSUARIOS.IdLogin

            fenote.id = dataRowNota("idNotaCredito")
            fenote.tabla = "T_FACTURA_CONTADO"
            fenote.isMonedaSoles = True
        End If

        '-->Valida si solamente debe aplicar una nota de credito, mas no un nuevo comprobante
        If (Not fenote Is Nothing) Then
            Try
                '-->Aplica Solamente una nota de credito
                Dim result = FEManager.sendNota(fenote, True)
                If (result.isCorrect) Then
                    Dim idNotaCredito As Long = dataRowNota("idNotaCredito")
                    Dim objFac As New ClsLbTepsa.dtoFACTURA
                    objFac.actualizarEmisonFE(idNotaCredito, "T_FACTURA_CONTADO")
                End If
                MessageBox.Show(result.Message, "Respuesta WSSunat", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("La Nota de Crédito Electrónica no pudo ser registrada, por favor comuníquese con el Area de Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnDescuento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescuento.Click
        Try
            Dim frm As New frmAgregarDescuento
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                Dim intComprobante As Integer = Me.DgvLista.CurrentRow.Cells("IdFactura").Value
                Dim dblTotal As Double = Me.DgvLista.CurrentRow.Cells("total_costo").Value
                Dim dblDescuento As Double = CType(frm.TxtDescuento.Text, Double)
                Dim strAutoriza As String = frm.txtDescDescto.Text.Trim

                Dim dblMonto As Double = dblTotal - dblTotal * (dblDescuento / 100)
                dblMonto = RedondearMas(dblMonto, 1)

                Dim dblSubtotal As Double = Format(dblMonto / 1.18, "0.00")
                Dim dblImpuesto As Double = Format(dblMonto - dblSubtotal, "0.00")

                Dim obj As New dtoVentaCargaContado
                obj.ActualizarDescuento(intComprobante, dblMonto, dblSubtotal, dblImpuesto, dblDescuento, strAutoriza)
                MessageBox.Show("Comprobante actualizado", "Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BtnPCE.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvLista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLista.CellContentClick

    End Sub
End Class