Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.Data
Imports AccesoDatos
Imports INTEGRACION_LN
Imports BarcodeLib

Public Class FrmMantenimientoGuia
    'variables page Buscar
    Dim dtCiudadOrigen As DataTable
    Dim dtAgenciaOrigen As DataTable
    Dim iRango As Byte = 0    '0=normal 1=primera vez 2=reimpresion
    Dim sFecha As String
    Dim sHora As String
    Dim xIMPRESORA As Integer
    Public hnd As Long
    'Variables Page Guia Envio
    Public iwinNro_digito_serie_cliente As New AutoCompleteStringCollection
    Public iWinPersonaRUC As New AutoCompleteStringCollection
    Public iWinPersona As New AutoCompleteStringCollection
    Public coll_Lista_Personas As New Collection
    '----------------------------------------------------------------------
    Dim utilData As New UtilData_LN
    Dim objCargaAsegurada As New ClsLbTepsa.dtoCargaAsegurada
    Public iWinDestino As New AutoCompleteStringCollection
    Dim coll_iDestino As New Collection
    Dim bTarifarioGeneral As Boolean
    Dim bIngreso As Boolean = False
    Dim bOtrasAgencias As Boolean
    Dim iTipoDoc As Integer
    Dim TipoGrid_ As Integer
    Dim bContado As Boolean
    Dim IGV As Double
    Dim dFactor As Double
    Dim MontoMinimoPyme As Double
    Dim iDespliegue As Byte = 0

    Dim bClienteNuevo As Boolean = True
    Dim bConsignadoNuevo As Boolean = True
    Dim dtCliente, dtConsignado, dtContacto, dtRemitente, dtDireccion, dtDireccion2, DtArticulos, DtSubcuenta As DataTable, DtSubcuentaOrigen As DataTable
    Dim dtContactoParalelo, dtRemitenteParalelo As DataTable
    Dim bControl_Busqueda As Boolean = False
    Dim li_iDigitosSerie As Integer = 3
    Dim bInicioCargaAcompañada As Boolean = False
    '18/11/2011
    Dim iBaseArticulo As Integer = 1

    Dim iCiudadDestino As Integer
    Dim iUsuarioCiudad As Integer

    '-->Constantes que guardan relación con la BD
    Dim ID_PRODUCTO_CARGA_EXPRESA As Integer = 5
    Dim ID_PRDUCTO_CARGA_ACOMPANADA As Integer = 6
    Dim ID_PRODUCTO_PYME As Integer = 7
    Dim ID_PRODUCTO_TEPSA_COURIER As Integer = 8
    Dim ID_PRODUCTO_TEPSA_BOX As Integer = 81
    Dim ID_PRODUCTO_TEPSA_BOX_10 As Integer = 82
    Dim ID_PRODUCTO_TEPSA_SOBRES As Integer = 10
    Dim ID_TIPO_PCE As Integer = 1
    Dim ID_TIPO_CREDITO As Integer = 2
    Dim ID_PERSONA_QUIMICA_SUIZA As Integer = 1290
    Dim ID_PERSONA_ECKERD As Integer = 1266
    Dim ID_PERSONA_DATAIMAGENES As Integer = 588692
    Dim ID_PERSONA_OLVA As Integer = 853
    Dim ID_PERSONA_CBC As Integer = 2153948

    Dim flagControl As Boolean = False

    '18-11-2013 hlamas tarifa entrega a domicilio
    Dim dtTarifaServicio As DataTable
    Dim dblMontoEntregaDomicilio As Double = 0

    'hlamas 17-02-2015
    Dim dblMontoDC As Double = 0

    'hlamas 26-08-2015
    Dim blnCargo As Boolean, strObservacionCargo As String

    Dim toolTip As New ToolTip()

    'hlamas 21-01-2016
    Dim dtTarifaArticuloPublico As DataTable

    'hlamas 14-04-2018
    Dim intPerfil As Integer = 1

    Dim Monto_25 As Double = 0
    Dim Monto_40 As Double = 0

    'hlamas 17-06-2019
    Dim intComprobanteRecojo As Integer

    'hlamas 22-07-2019
    Dim blnImprimir As Boolean

#Region "BUSCAR"

    Private Property ChkCargo As Object

    Private Sub FrmMantenimientoGuia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        'Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmMantenimientoGuia_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        TxtCiudadDestino.Focus()
    End Sub

    Private Sub FrmMantenimientoGuia_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        dtoUSUARIOS.m_iIdAgencia = dtoUSUARIOS.iIDAGENCIAS
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        GrdDocumentosCliente.ClearSelection()
        GrdDetalleVenta.ClearSelection()
    End Sub

    Private Sub FrmMantenimientoGuia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub FrmMantenimientoGuiaEnvio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.TabPage2.Parent = Nothing
        Try
            intComprobanteRecojo = 0
            toolTip.SetToolTip(Me.btnAutorizar, "Autorizar Descuento")
            Formato()
            Inicio()
            '------------
            ReDim objComprobanteAsegurada(19)
            sBoleto = ""
            Me.CboDireccion.SelectedIndex = 0
            Me.CboContacto.SelectedIndex = 0
            Me.CboRemitente.SelectedIndex = 0
            Me.ConvertirTipoEntrega(0)

            Me.DiseñaGrdDocumentos()
            TipoGrid_ = FormatoGrid.BULTO '---> Grid Bultos
            Me.DiseñaGrdDetalleVenta() '------> Diseña GridDetalleVenta
            FormatoGrdDetalleVenta() '--------> Formato al grid

            '===Agregado x NConsignado====
            Me.DiseñaGrdNConsignado()
            '=============================

            bTarifarioGeneral = False
            bContado = False

            ObjVentaCargaContado = Nothing
            ObjVentaCargaContado = New dtoVentaCargaContado

            Me.Text = "Mantenimiento Guía de Envío " '& dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & _
            '"[" & dtoUSUARIOS.m_iNombreAgencia & "] [" & dtoUSUARIOS.m_iNombreUnidadAgencia & "]"

            Me.txtFechaGuia.Text = dtoUSUARIOS.m_sFecha '------------> Fecha
            ' Me.LblCiudad.Text = dtoUSUARIOS.m_iNombreUnidadAgencia '-> Unidad Agencia
            ' Me.LblAgencia.Text = dtoUSUARIOS.m_iNombreAgencia '------> Nombre Agencia

            'hlamas 22-03-2016
            'Me.objGuiaEnvio.iCARGO = Int(ChkCargo.Checked)
            Me.objGuiaEnvio.iCARGO = Int(rbtCargoSi.Checked)

            Me.objGuiaEnvio.iCONTROL = 1

            Dim iOpcion As Integer = 0
            If Acceso.SiRol(G_Rol, Me, 1, 1) Then
                iOpcion = 0
            ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then
                iOpcion = 1
            ElseIf Acceso.SiRol(G_Rol, Me, 1, 3) Then
                iOpcion = 2
            ElseIf Acceso.SiRol(G_Rol, Me, 1, 4) Then
                iOpcion = 3
            End If

            If Acceso.SiRol(G_Rol, Me, 2, 1) Then
                blnImprimir = True
            Else
                blnImprimir = False
            End If


            '-->Carga el producto
            Me.ListarProducto(iOpcion)
            CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER

            Me.IGV = dtoUSUARIOS.iIGV / 100
            '---Cargar datos--
            Me.Inicio2()
            '-----------------

            '-->Carga tipo de tarifa
            utilData.cargarCombos("t_tipotarifa", CboTipoTarifa, False)

            'Dim objTarifarioPerso_LN As New Cls_TarifaPublica_LN 'refereanciamos la clase a mostrar
            'objTarifarioPerso_LN.F_CargarOrigen_LN(CboTipoTarifa, "t_tipotarifa")
            'CboTipoTarifa.SelectedIndex = 0


            Me.CondicionMontoMinimoPCE()

            'hlamas 11-03-2019
            'If ObjVentaCargaContado.fnNroDocuemnto(3, CboProducto.SelectedValue) = True Then
            '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
            '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
            '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
            'ElseIf ObjVentaCargaContado.fnNroDocuemnto(3, 0) = True Then
            '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
            '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
            '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
            'Else
            '    MessageBox.Show("Configure Número de Guía de Envío.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    'Me.BtnGrabar.Enabled = False'domenica
            'End If

            '--USUARIO REMOTO--
            'Me.ListarUsuarios(dtoUSUARIOS.m_idciudad)
            '------------------

            RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            'CboTipoTarifa.SelectedIndex = 0
            'AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged

            If iOpcion <> 3 Then
                CboTipo.SelectedValue = 2
            Else
                CboTipo.SelectedValue = 1
            End If

            Me.chkRecojo.Checked = False
            Me.cboCanjeado.Enabled = False
            Me.cboCanjeado.SelectedIndex = 0

            bIngreso = False
            Dim dt2 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt2, Me, ContextMenuStrip)
            bIngreso = True

            '-------
            If Not BMenuContado.Enabled Then
                Me.ContextContado.Items("CambiarContadoACréditoToolStripMenuItem").Visible = False
            End If

            If Not BMenuCredito.Enabled Then
                Me.ContextCredito.Items("CambiarCréditoAContadoToolStripMenuItem").Visible = False
            End If


            '-------

            '---
            'hlamas 13-03-2014
            'CboProducto.Enabled = True

            CboTipoTarifa.Enabled = True
            BtnNuevo.Visible = True
            CboTipoTarifa.SelectedIndex = 1

            'If G_Rol = 1009 Then
            Me.btnImprimir.Visible = True
            'Else
            'Me.BtnImprimir.Visible = False
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarUsuarios(ByVal iIDCiudad As Integer)
        Dim obj As New dtoVentaCargaContado
        Dim dt As DataTable = obj.ListarUsuarios(iIDCiudad, dtoUSUARIOS.IdLogin)
        With Me.CboListaUsuarios
            .DisplayMember = "nombre"
            .ValueMember = "idusuario_personal"
            .DataSource = dt
        End With
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
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft 'Idfactura
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
                .HeaderText = "Cancelado"
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
                .HeaderText = "Cancelado Por"
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

            Dim col_entrega_domicilio As New DataGridViewTextBoxColumn
            With col_entrega_domicilio
                .Name = "monto_entrega_domicilio"
                .DataPropertyName = "monto_entrega_domicilio"
                .HeaderText = "Monto Entrega Domicilio"
                .Visible = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "0.00"
                .DefaultCellStyle.NullValue = "0.00"
            End With

            Dim col_TipoEntrega As New DataGridViewTextBoxColumn
            With col_TipoEntrega
                .Name = "tipo_entrega"
                .DataPropertyName = "tipo_entrega"
                .HeaderText = "tipo_entrega"
                .Visible = False
            End With

            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente"
                .DataPropertyName = "idcliente"
                .HeaderText = "idcliente"
                .Visible = False
            End With

            Dim col_funcionario As New DataGridViewTextBoxColumn
            With col_funcionario
                .Name = "funcionario"
                .DataPropertyName = "funcionario"
                .HeaderText = "Funcionario"
                .Visible = False
            End With

            Dim col_factura As New DataGridViewTextBoxColumn
            With col_factura
                .Name = "factura"
                .DataPropertyName = "factura"
                .HeaderText = "facturado"
                .Visible = False
            End With

            Dim col_prefactura As New DataGridViewTextBoxColumn
            With col_prefactura
                .Name = "prefactura"
                .DataPropertyName = "prefactura"
                .HeaderText = "prefacturado"
                .Visible = False
            End With

            Dim col_formato As New DataGridViewTextBoxColumn
            With col_formato
                .Name = "formato"
                .DataPropertyName = "formato"
                .HeaderText = "Formato"
                .Visible = False
            End With

            Dim col_idusuario_personal As New DataGridViewTextBoxColumn
            With col_idusuario_personal
                .Name = "idusuario_personal"
                .DataPropertyName = "idusuario_personal"
                .HeaderText = "idusuario_personal"
                .Visible = False
            End With

            Dim col_idtipo_tarifa As New DataGridViewTextBoxColumn
            With col_idtipo_tarifa
                .Name = "idtipo_tarifa"
                .DataPropertyName = "idtipo_tarifa"
                .HeaderText = "idtipo_tarifa"
                .Visible = False
            End With

            Dim col_iddireccion_remitente As New DataGridViewTextBoxColumn
            With col_iddireccion_remitente
                .Name = "iddireccion_remitente"
                .DataPropertyName = "iddireccion_remitente"
                .HeaderText = "iddireccion_remitente"
                .Visible = False
            End With

            Dim col_iddireccion_consignado As New DataGridViewTextBoxColumn
            With col_iddireccion_consignado
                .Name = "iddireccion_consignado"
                .DataPropertyName = "iddireccion_consignado"
                .HeaderText = "iddireccion_consignado"
                .Visible = False
            End With

            Dim col_remitente As New DataGridViewTextBoxColumn
            With col_remitente
                .Name = "remitente"
                .DataPropertyName = "remitente"
                .HeaderText = "remitente"
                .Visible = False
            End With

            Dim col_recojo As New DataGridViewTextBoxColumn
            With col_recojo
                .Name = "recojo"
                .DataPropertyName = "recojo"
                .HeaderText = "Nº Recojo"
                .Visible = True
            End With

            Dim col_id_canjeado As New DataGridViewTextBoxColumn
            With col_id_canjeado
                .Name = "id_canjeado"
                .DataPropertyName = "id_canjeado"
                .HeaderText = "id_canjeado"
                .Visible = False
            End With

            Dim col_canjeado As New DataGridViewTextBoxColumn
            With col_canjeado
                .Name = "canjeado"
                .DataPropertyName = "canjeado"
                .HeaderText = "Canjeado"
                .Visible = True
            End With

            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion"
                .DataPropertyName = "direccion"
                .HeaderText = "direccion"
                .Visible = True
            End With


            .Columns.AddRange(fecha, guia, tipo, origen, destino, transito, documento, cliente, cantidad, _
                              total_peso, Total_Volumen, Precio_x_Peso, Precio_x_Volumen,
                              Precio_x_Sobre, Monto_Base, Porcent_Descuento, _
                              Monto_Sub_Total, Monto_Impuesto, Total_Costo, igv, _
                              usuario, Estado_Doc, Estado_Envio, Facturado, proceso, _
                              nroboleto, comprobante, idtipo_comprobante, Idestado_Factura, IdFactura, _
                              idforma_pago, idunidad_destino, idagencias_destino, idunidad_origen, _
                              idagencias, idprocesos, idestado_envio, col_entrega_domicilio, col_TipoEntrega, col_idcliente, col_funcionario, _
                              col_factura, col_prefactura, col_formato, col_idusuario_personal, _
                              col_idtipo_tarifa, col_iddireccion_remitente, col_iddireccion_consignado, col_remitente, _
                              col_recojo, col_id_canjeado, col_canjeado, col_direccion)
        End With
    End Sub

    Sub Inicio()
        Try
            Dim ds As DataSet = dtoGuia.Inicio

            With Me.CboAgenciaOrigen
                dtAgenciaOrigen = ds.Tables(1)
                .DataSource = dtAgenciaOrigen
                .ValueMember = "idagencias"
                .DisplayMember = "nombre_agencia"
                '.SelectedValue = dtoUSUARIOS.m_iIdAgencia
            End With

            With Me.CboCiudadOrigen
                dtCiudadOrigen = ds.Tables(0)
                .DataSource = dtCiudadOrigen
                .ValueMember = "idunidad_agencia"
                .DisplayMember = "nombre_unidad"
                .SelectedIndex = 0
                '.SelectedValue = 0
            End With

            Dim dtCiudad As DataTable = dtCiudadOrigen.Copy
            dtCiudad.Rows(0).Item(1) = " (SELECCIONE)"
            With Me.CboCiudad_Origen
                .DataSource = dtCiudad
                .ValueMember = "idunidad_agencia"
                .DisplayMember = "nombre_unidad"
                .SelectedValue = dtoUSUARIOS.m_idciudad
            End With

            Dim dtCiudad2 As DataTable = dtCiudadOrigen.Copy
            dtCiudad2.Rows(0).Item(1) = " (SELECCIONE)"
            With Me.CboCiudadDestino
                .DataSource = dtCiudad2
                .ValueMember = "idunidad_agencia"
                .DisplayMember = "nombre_unidad"
                .SelectedIndex = 0
                '.SelectedValue = 0
            End With

            With Me.CboEstado
                .DataSource = ds.Tables(2).Copy
                .ValueMember = "Idestado_Registro"
                .DisplayMember = "Estado_Registro"
                .SelectedIndex = 0
                '.SelectedValue = 0
            End With

            Me.CboAgenciaOrigen.SelectedValue = dtoUSUARIOS.iIDAGENCIAS
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub CboCiudad_Origen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCiudad_Origen.SelectedIndexChanged
        Try
            Cursor = Cursors.AppStarting
            If Not IsReference(CboCiudad_Origen.SelectedValue) Then
                If dtoUSUARIOS.m_idciudad = CboCiudad_Origen.SelectedValue Then
                    iUsuarioCiudad = 0
                Else
                    iUsuarioCiudad = CboCiudad_Origen.SelectedValue
                End If

                If iOpcion = 2 Then
                    RemoveHandler CboCiudad_Origen.SelectedIndexChanged, AddressOf CboCiudad_Origen_SelectedIndexChanged
                    CboCiudad_Origen.SelectedValue = iCiudad
                    AddHandler CboCiudad_Origen.SelectedIndexChanged, AddressOf CboCiudad_Origen_SelectedIndexChanged
                    Me.Cursor = Cursors.Default
                    Return
                End If

                ObjVentaCargaContado.fnGetAgencias(CboCiudad_Origen.SelectedValue)
                Dim dt As New DataTable
                dt = ObjVentaCargaContado.dt_VarAgencias.Copy
                With CboAgencia_Origen
                    .DataSource = dt
                    .DisplayMember = "nombre_agencia"
                    .ValueMember = "idagencias"
                End With

                If Me.CboCiudad_Origen.Focused Then
                    Me.DespliegaCboAgencia_Origen()
                End If

                Me.ListarUsuarios(CboCiudad_Origen.SelectedValue)
            End If

            'hlamas 01-09-2013
            If Not IsReference(Me.CboCiudad_Origen.SelectedValue) Then
                CargarSubcuentaOrigen(ObjVentaCargaContado.v_IDPERSONA, Me.CboCiudad_Origen.SelectedValue)
            Else
                CargarSubcuentaOrigen(ObjVentaCargaContado.v_IDPERSONA, dtoUSUARIOS.m_idciudad)
            End If

            'hlamas 13-03-2014
            If Not IsReference(Me.CboCiudad_Origen.SelectedValue) Then
                ClienteProducto(iID_Persona, Me.CboSubCuenta.SelectedValue, Me.CboCiudad_Origen.SelectedValue, idUnidadAgencias)
            End If

            'hlamas 24-02-2014
            If ID_PERSONA_DATAIMAGENES = iID_Persona Then
                Me.ClientePersonalizado(iID_Persona)
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CboCiudadOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCiudadOrigen.SelectedIndexChanged
        If IsReference(Me.CboCiudadOrigen.SelectedValue) Then Return
        Dim sFiltro As String
        If Me.CboCiudadOrigen.SelectedValue = 0 Then
            sFiltro = ""
        Else
            sFiltro = "idunidad_agencia=" & Me.CboCiudadOrigen.SelectedValue & " or idunidad_agencia=0"
        End If
        dtAgenciaOrigen.DefaultView.RowFilter = sFiltro
        CboAgenciaOrigen.SelectedValue = 0
    End Sub

    Private Sub CboAgenciaOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAgenciaOrigen.SelectedIndexChanged
        If IsReference(Me.CboAgenciaOrigen.SelectedValue) Then Return
        CargarUsuario(CboAgenciaOrigen.SelectedValue)
    End Sub

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

    Sub Listar(ByVal fecha1 As String, ByVal fecha2 As String, ByVal origen As Integer, ByVal destino As Integer, _
               ByVal agencia As Integer, ByVal usuario As Integer, ByVal estado As Integer, Optional ByVal recojo As Integer = 0, Optional ByVal canjeado As Integer = 0)
        Try
            Dim obj As New dtoGuia
            Dim dt As DataTable = obj.Listar(fecha1, fecha2, origen, destino, agencia, usuario, estado, recojo, canjeado)
            With Me.DgvLista
                .DataSource = dt
                Me.FormatoColorDgvLista()
            End With

            If dt.Rows.Count <= 0 Then
                MessageBox.Show("No Se Encontraron Coincidencias.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Dim intRecojo As Integer = IIf(Me.chkRecojo.Checked, 1, 0)
            Dim intCanjeado As Integer
            If Me.chkRecojo.Checked Then
                If Me.cboCanjeado.SelectedIndex = 0 Then
                    intCanjeado = -1
                ElseIf Me.cboCanjeado.SelectedIndex = 1 Then
                    intCanjeado = 1
                Else
                    intCanjeado = 0
                End If
            Else
                intCanjeado = -1
            End If

            Listar(Me.DtpFechaInicio.Text, Me.DtpFechaFin.Text, CboCiudadOrigen.SelectedValue, _
                   Me.CboCiudadDestino.SelectedValue, Me.CboAgenciaOrigen.SelectedValue, Me.CboUsuario.SelectedValue, Me.CboEstado.SelectedValue, intRecojo,intCanjeado)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function ValidaNroGuion(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidaNroGuion = True
        Else
            ValidaNroGuion = False
        End If
    End Function

    Sub Listar(ByVal guia As Long)
        Try
            Dim obj As New dtoGuia
            Dim dt As DataTable = obj.Listar(guia)

            With Me.DgvLista
                .DataSource = dt
                Me.FormatoColorDgvLista() 'CambioR 10112011
            End With

            If dt.Rows.Count <= 0 Then
                MessageBox.Show("No Se Encontraron Coincidencias.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Listar(ByVal fecha1 As String, ByVal fecha2 As String, ByVal documento As String)
        Try
            Dim obj As New dtoGuia
            Dim dt As DataTable = obj.Listar(fecha1, fecha2, documento)

            With Me.DgvLista
                .DataSource = dt
            End With

            If dt.Rows.Count <= 0 Then
                MessageBox.Show("No Se Encontraron Coincidencias.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub TxtDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDocumento.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                Me.Cursor = Cursors.AppStarting
                Dim sDocumento As String = Me.TxtDocumento.Text
                Listar(Me.DtpFechaInicio.Text, Me.DtpFechaFin.Text, sDocumento)
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvLista_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles DgvLista.Invalidated

    End Sub

    Private Sub DgvLista_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgvLista.RowsAdded
        Me.LblRegistros.Text = Me.DgvLista.Rows.Count
        Me.btnImprimirLote.Enabled = Me.DgvLista.Rows.Count > 0 And blnImprimir
    End Sub

    Private Sub DgvLista_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgvLista.RowsRemoved
        Me.LblRegistros.Text = Me.DgvLista.Rows.Count
        Estado(Me.DgvLista)
        Me.btnImprimirLote.Enabled = Me.DgvLista.Rows.Count > 0 And blnImprimir
    End Sub

    Private Sub DgvLista_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLista.RowEnter
        Estado(Me.DgvLista, e.RowIndex)
        Me.btnCanjearRecojo.Enabled = Me.DgvLista.Rows(e.RowIndex).Cells("idestado_envio").Value = 12 And Me.DgvLista.Rows(e.RowIndex).Cells("total_costo").Value > 0
    End Sub

    Sub Estado(ByVal dgv As DataGridView, Optional ByVal fila As Integer = 0)
        If dgv.Rows.Count = 0 Then
            Me.BtnEditar.Enabled = False
            Me.BtnConsultar.Enabled = False
            Me.BtnAnular.Enabled = False
            Me.BtnTicket.Enabled = False
            Me.btnImprimir.Enabled = False
            Me.BtnExportar.Enabled = False
        Else
            Me.BtnEditar.Enabled = True
            Me.BtnConsultar.Enabled = True
            Me.BtnAnular.Enabled = True
            Me.BtnTicket.Enabled = True
            Me.btnImprimir.Enabled = True
            Me.BtnExportar.Enabled = True

            Dim iEstado As Integer = dgv.Rows(fila).Cells("Idestado_Factura").Value
            If iEstado = 2 Or iEstado = 3 Or iEstado = 29 Then
                Me.BtnEditar.Enabled = False
                Me.BtnAnular.Enabled = False
                Me.btnImprimir.Enabled = False
                Me.BtnTicket.Enabled = False
                Me.BtnExportar.Enabled = False
            End If
        End If
    End Sub

    Sub Devolver(ByVal comprobante As String, ByVal usuario As Integer, _
           ByVal rol As Integer, ByVal ip As String, ByVal porcentaje As Double)
        Try
            Dim obj As New dtoGuia
            obj.Devolver(comprobante, usuario, rol, ip, porcentaje)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Anular(ByVal comprobante As String, ByVal usuario As Integer, _
               ByVal rol As Integer, ByVal ip As String, ByVal acceso As Integer)
        Try
            Dim obj As New dtoGuia
            obj.Anular(comprobante, usuario, rol, ip, acceso)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Anular(ByVal estado As Integer, ByVal comprobante As String, ByVal usuario As Integer, _
           ByVal rol As Integer, ByVal ip As String, ByVal acceso As Integer)
        Try
            Dim obj As New dtoGuia
            obj.Anular(estado, comprobante, usuario, rol, ip, acceso)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Eliminar(ByVal comprobante As String, ByVal usuario As Integer, _
           ByVal rol As Integer, ByVal ip As String)
        Try
            Dim obj As New dtoGuia
            obj.Eliminar(comprobante, usuario, rol, ip)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function fnImprimirEtiquetasN95() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            'ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            'ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            'Dim I As Int16 = 1
            'Dim i As Int16
            'If bRango Then
            '    i = 1
            'Else
            '    i = correlativo_inicial
            '    'Mod 21/08/2009 
            '    If i = 0 Then i = 1
            'End If
            '''
            Dim i As Int16
            If iRango = 1 Then
                i = 1
            ElseIf iRango = 2 Then
                i = correlativo_inicial
            Else
                i = 1
            End If

            If i <= 0 Then i = 1

            '''''
            'ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            'ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.tipo = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            ObjCODIGOBARRA.id = Me.DgvLista.CurrentRow.Cells("idfactura").Value
            ObjCODIGOBARRA.sp_etiqueta_generada()
            '
            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha
            '
            'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
            '    prn.EscribeLinea("^XA")
            '    prn.EscribeLinea("^PW400")
            '    prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
            '    'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
            '    'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
            '    prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
            '    prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
            '    prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
            '    prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
            '    prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
            '    prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")
            '    prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")
            '    prn.EscribeLinea("^PQ1,0,1,Y")
            '    prn.EscribeLinea("^XZ")
            '    prn.EscribeLinea(cadena)
            '    ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
            '    I = I + 1
            'End While
            '
            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String
            'hlamas 22-03-2016
            'strCargo = IIf(Me.ChkCargo.Checked, "CARGO", "")
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")

            For Each fila As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows
                ObjCODIGOBARRA.CodigoBarra = fila.Item(0)
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")
                prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
                'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
                'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
                prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
                prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
                prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")

                'hlamas 26-08-2015
                'prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
                'prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & strFecha & "^FS")
                prn.EscribeLinea("^FT255,188^AAN,18,10^FH\^FDTEPSAC^FS")
                prn.EscribeLinea("^FT330,188^AAN,20,12^FH\^FD" & strCargo & "^FS")

                'hlamas 26-08-2015
                'prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")

                prn.EscribeLinea("^PQ1,0,1,Y")
                prn.EscribeLinea("^XZ")
                prn.EscribeLinea(cadena)
                'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                i = i + 1
            Next

            prn.FinDoc()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function

    Public Function fnImprimirEtiquetasFAC_IIN95() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            'ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            'ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            'Dim I As Int16 = 1
            'Dim i As Int16
            'If bRango Then
            '    i = 1
            'Else
            '    i = correlativo_inicial
            '    'Mod 21/08/2009 
            '    If i = 0 Then i = 1
            'End If
            '
            Dim i As Int16
            If iRango = 1 Then
                i = 1
            ElseIf iRango = 2 Then
                i = correlativo_inicial
            Else
                i = 1
            End If

            If i <= 0 Then i = 1

            'ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            'ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.tipo = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            ObjCODIGOBARRA.id = Me.DgvLista.CurrentRow.Cells("idfactura").Value
            ObjCODIGOBARRA.sp_etiqueta_generada()
            '
            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha
            '
            'While objGuiaEnvio.cur_codBarras.EOF = False And objGuiaEnvio.cur_codBarras.BOF = False
            'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value

            '    'prn.EscribeLinea("<STX><ESC>C0<ETX>")
            '    'prn.EscribeLinea("<STX><ESC>k<ETX>")
            '    'prn.EscribeLinea("<STX><SI>N60<ETX>")
            '    'prn.EscribeLinea("<STX><SI>L197<ETX>")
            '    'prn.EscribeLinea("<STX><SI>S20<ETX>")
            '    'prn.EscribeLinea("<STX><SI>d0<ETX>")
            '    'prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
            '    'prn.EscribeLinea("<STX><SI>l8<ETX>")
            '    'prn.EscribeLinea("<STX><SI>I3<ETX>")
            '    'prn.EscribeLinea("<STX><SI>F20<ETX>")
            '    'prn.EscribeLinea("<STX><SI>D0<ETX>")
            '    'prn.EscribeLinea("<STX><SI>t0<ETX>")
            '    'prn.EscribeLinea("<STX><SI>W394<ETX>")
            '    'prn.EscribeLinea("<STX><SI>g1,567<ETX>")
            '    'prn.EscribeLinea("<STX><ESC>P<ETX>")
            '    'prn.EscribeLinea("<STX>E*;F*;<ETX>")
            '    'prn.EscribeLinea("<STX>L1;<ETX>")
            '    'prn.EscribeLinea("<STX>D0;<ETX>")
            '    'prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h12;w20;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
            '    'prn.EscribeLinea("<STX>D1;<ETX>")
            '    'prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
            '    'prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
            '    'prn.EscribeLinea("<STX>B3;o96,180;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
            '    'prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
            '    'prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
            '    'prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
            '    'prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
            '    'prn.EscribeLinea("<STX>R<ETX>")
            '    'prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
            '    'prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")

            '    prn.EscribeLinea("<STX><ESC>C0<ETX>")
            '    prn.EscribeLinea("<STX><ESC>k<ETX>")
            '    prn.EscribeLinea("<STX><SI>N60<ETX>")
            '    prn.EscribeLinea("<STX><SI>L197<ETX>")
            '    prn.EscribeLinea("<STX><SI>S20<ETX>")
            '    prn.EscribeLinea("<STX><SI>d0<ETX>")
            '    prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
            '    prn.EscribeLinea("<STX><SI>l8<ETX>")
            '    prn.EscribeLinea("<STX><SI>I3<ETX>")
            '    prn.EscribeLinea("<STX><SI>F20<ETX>")
            '    prn.EscribeLinea("<STX><SI>D0<ETX>")
            '    prn.EscribeLinea("<STX><SI>t0<ETX>")
            '    prn.EscribeLinea("<STX><SI>W394<ETX>")
            '    prn.EscribeLinea("<STX><SI>g1,567<ETX>")
            '    prn.EscribeLinea("<STX><ESC>P<ETX>")
            '    prn.EscribeLinea("<STX>E*;F*;<ETX>")
            '    prn.EscribeLinea("<STX>L1;<ETX>")
            '    prn.EscribeLinea("<STX>D0;<ETX>")
            '    prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h15;w15;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
            '    prn.EscribeLinea("<STX>D1;<ETX>")
            '    prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
            '    prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
            '    'prn.EscribeLinea("<STX>B3;o96,180;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
            '    prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
            '    prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
            '    prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
            '    prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
            '    prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
            '    prn.EscribeLinea("<STX>R<ETX>")
            '    prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
            '    prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")

            '    prn.EscribeLinea(cadena)
            '    ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
            '    I = I + 1
            'End While
            '''''''''''''''
            For Each fila As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows(0).Item(0)
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
                prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
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

                prn.EscribeLinea(cadena)
                'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                i = i + 1
            Next
            '''''''''''''''
            prn.FinDoc()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function

    Public Function fnImprimirEtiquetasFAC_IIN97() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            '
            'Dim i As Int16
            'If bRango Then
            '    i = 1
            'Else
            '    i = correlativo_inicial
            '    'Mod 21/08/2009 
            '    If i = 0 Then i = 1
            'End If
            '
            Dim i As Int16
            If iRango = 1 Then
                i = correlativo_inicial
                If i = 0 Then i = 1
            ElseIf iRango = 2 Then
                i = correlativo_inicial
            Else
                i = 1
            End If

            If i <= 0 Then i = 1

            '
            'ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            'ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.tipo = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            ObjCODIGOBARRA.id = Me.DgvLista.CurrentRow.Cells("idfactura").Value
            ObjCODIGOBARRA.sp_etiqueta_generada()

            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha

            'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
            '    prn.EscribeLinea("N")
            '    prn.EscribeLinea("N")
            '    prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
            '    prn.EscribeLinea("A30,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
            '    prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
            '    prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
            '    prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
            '    prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")
            '    prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")
            '    prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
            '    prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
            '    prn.EscribeLinea("P1")
            '    prn.EscribeLinea("N")
            '    prn.EscribeLinea(cadena)
            '    'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
            '    I = I + 1
            'End While
            '''''''''''''''''''''''''''''''''''''''
            'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False

            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String
            'hlamas 22-03-2016
            'strCargo = IIf(Me.ChkCargo.Checked, "CARGO", "")
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")

            For Each fila As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows
                ObjCODIGOBARRA.CodigoBarra = fila.Item(0)
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                prn.EscribeLinea("A30,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)

                'hlamas 26-08-2015
                'prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
                'prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("A30,163,0,1,1,1,N,""" & strFecha & """")
                prn.EscribeLinea("A230,163,0,1,1,1,N,""TEPSAC""")
                prn.EscribeLinea("A300,163,0,2,1,1,N,""" & strCargo & """")

                'hlamas 26-08-2015
                'prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")

                prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                i = i + 1
            Next
            '''''''''''''''''''''''''''''''''''''''
            prn.FinDoc()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function


    Private Sub DgvLista_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvLista.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim blnAcceso() As Boolean = {False, False}
            intPerfil = 1
            If Not Acceso.SiRol(G_Rol, Me, 1, 1) Then 'Oficina
                If Acceso.SiRol(G_Rol, Me, 1, 2) Then
                    intPerfil = 2
                    Dim intFuncionario As Integer
                    intFuncionario = Me.DgvLista.CurrentRow.Cells("funcionario").Value
                    If intFuncionario <> dtoUSUARIOS.IdLogin Then
                        Return
                    End If
                ElseIf Acceso.SiRol(G_Rol, Me, 1, 3) Then
                    intPerfil = 3
                    Dim intAgencia As Integer
                    intAgencia = Me.DgvLista.CurrentRow.Cells("idagencias").Value
                    If intAgencia <> dtoUSUARIOS.iIDAGENCIAS Then
                        Return
                    Else
                        If Not (Me.DgvLista.CurrentRow.Cells("Idunidad_Origen").Value = 5100 Or Me.DgvLista.CurrentRow.Cells("Idunidad_Origen").Value = 5630) Then
                            Return
                        End If
                    End If
                ElseIf Acceso.SiRol(G_Rol, Me, 1, 4) Then
                    intPerfil = 4
                Else
                    intPerfil = 5
                    Return
                End If
            End If
            If Me.DgvLista.Rows.Count > 0 Then
                Dim intEstado As Integer = Me.DgvLista.CurrentRow.Cells("idestado_envio").Value
                Dim blnOK As Boolean = intEstado <> 21 And intEstado <> 29 'And intEstado <> 50
                'If Me.DgvLista.CurrentRow.Cells("tipo_entrega").Value = 1 And blnOK Then
                If blnOK Then
                    blnAcceso(0) = True
                    'Me.ContextContado.Show(sender, e.X, e.Y)
                End If

                blnOK = intEstado <> 29 'And intEstado <> 50
                Dim intFacturado As Integer = Me.DgvLista.CurrentRow.Cells("factura").Value
                Dim intPrefacturado As Integer = Me.DgvLista.CurrentRow.Cells("prefactura").Value
                blnAcceso(1) = (blnOK And intFacturado = 0 And intPrefacturado = 0) And (intPerfil = 2 Or intPerfil = 4)

                Me.ContextContado.Items(0).Enabled = blnAcceso(0)
                Me.ContextContado.Items(4).Enabled = blnAcceso(1)
                Me.ContextContado.Items(5).Enabled = blnAcceso(1)

                Me.ContextContado.Show(sender, e.X, e.Y)
            End If
        End If
    End Sub

    Private Sub DevolverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevolverToolStripMenuItem.Click
        Try
            Dim sGuia As String = Me.DgvLista.CurrentRow.Cells("guia").Value
            Dim iGuia As Integer = Me.DgvLista.CurrentRow.Cells("IdFactura").Value
            Dim iTipo As Integer = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de devolver la Guía Nº " & sGuia & "?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.AppStarting
                Devolver(iGuia, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IdRol, dtoUSUARIOS.IP, 100)
                Me.Cursor = Cursors.Default
                MessageBox.Show("La Guía Nº " & sGuia & " ha sido Devuelta.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BtnBuscar_Click(sender, e)
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        Try
            Dim sGuia As String = Me.DgvLista.CurrentRow.Cells("guia").Value
            Dim iGuia As Integer = Me.DgvLista.CurrentRow.Cells("IdFactura").Value
            Dim iTipo As Integer = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de eliminar la Guía Nº " & sGuia & "?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.AppStarting
                Eliminar(iGuia, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IdRol, dtoUSUARIOS.IP)
                Me.Cursor = Cursors.Default
                MessageBox.Show("La Guía Nº " & sGuia & " ha sido Eliminada.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BtnBuscar_Click(sender, e)
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***CAMBIAR CONTADO A CREDITO****
    Private Sub CambiarContadoACréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarContadoACréditoToolStripMenuItem.Click
        Dim ll_rol_usuario As Long
        Dim flag As Boolean = False
        Dim dgrv0 As DataGridViewRow
        Dim ls_documento As String
        Dim ls_tipo_comprobante As String
        Dim ll_facturado As Long
        '
        Try
            ll_rol_usuario = dtoUSUARIOS.m_iIdRol
            'If Acceso.SiRol(G_Rol, Me, 8) Then
            dgrv0 = Me.DgvLista.CurrentRow()
            ls_documento = CType(dgrv0.Cells("guia").Value, String)
            Dim resp As DialogResult = MessageBox.Show("Está seguro de cambiar la Guía de Envío Nº " & ls_documento & " a Crédito?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = Windows.Forms.DialogResult.Yes Then
                Dim lobj_pce_a_credito As New frm_pce_a_credito
                lobj_pce_a_credito.pl_idfactura_contado = CType(dgrv0.Cells("IdFactura").Value, String)
                lobj_pce_a_credito.ps_nro_guia_envio = ls_documento

                Acceso.Asignar(lobj_pce_a_credito, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    lobj_pce_a_credito.ShowDialog()
                Else
                    MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                ' Cancelar y refrescar
                If Not lobj_pce_a_credito.pb_cancelar Then
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("La Guía Nº " & ls_documento & " ha sido cambiada a Crédito.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    BtnBuscar_Click(sender, e)
                End If
            End If
            'Else
            'Me.Cursor = Cursors.Default
            'MessageBox.Show("No tiene Acceso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarToolStripMenuItem.Click
        Dim flag As Boolean = False
        Dim dgrv0 As DataGridViewRow
        Dim ls_documento As String
        Try
            'Rol (24) Fiscalización
            'If fnValidar_Rol("24") Then
            'bloque
            '****************************************
            'If Acceso.SiRol(G_Rol, Me, 7) Then
            '    flag = True
            'End If
            'If flag = False Then
            '    MessageBox.Show("No tiene Acceso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If
            '
            dgrv0 = Me.DgvLista.CurrentRow()
            ls_documento = CType(dgrv0.Cells("guia").Value, String)
            Dim resp As DialogResult = MessageBox.Show("Está seguro de actualizar la Guía de Envío Nº " & ls_documento & "?", "Seguridad del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = Windows.Forms.DialogResult.Yes Then
                '** 
                'Actualiza los datos para venta al contado 
                '**
                Dim a As New frm_actualiza_venta_contado
                a.ps_tipo_venta = "C"
                a.pl_idforma_pago = CType(dgrv0.Cells("Idforma_Pago").Value, Long)
                a.ps_idcomprobante = CType(dgrv0.Cells("idfactura").Value, String)
                a.pl_idtipo_comprobante = CType(dgrv0.Cells("Idtipo_Comprobante").Value, Long)
                a.pl_idunidad_agencia = CType(dgrv0.Cells("Idunidad_Destino").Value, Long)
                a.pl_idagencia_destino = CType(dgrv0.Cells("Idagencias_Destino").Value, Long)
                a.ps_razon_social = CType(dgrv0.Cells("cliente").Value, String)
                a.pd_tot_costo = CType(dgrv0.Cells("Total_Costo").Value, Double)
                a.pd_monto_sub_total = CType(dgrv0.Cells("Monto_Sub_Total").Value, Double)
                a.pd_monto_impuesto = CType(dgrv0.Cells("Monto_Impuesto").Value, Double)
                a.ps_tipo_comprobante = CType(dgrv0.Cells("tipo").Value, String)
                a.ps_documento = CType(dgrv0.Cells("guia").Value, String)
                a.ps_agencia_origen = CType(dgrv0.Cells("Origen").Value, String)
                a.ps_fecha_documento = CType(dgrv0.Cells("fecha").Value, String)
                '
                a.pl_idunidad_agencia_origen = CType(dgrv0.Cells("idunidad_origen").Value, Long)
                a.pl_idagencia_origen = CType(dgrv0.Cells("idagencias").Value, Long)
                a.ps_documento_identidad = CType(dgrv0.Cells("documento").Value, String)

                a.pl_proceso = CType(dgrv0.Cells("idprocesos").Value, Long)
                a.ps_boleto = CType(IIf(IsDBNull(dgrv0.Cells("nroboleto").Value), "", dgrv0.Cells("nroboleto").Value), String)
                a.pl_envio = CType(dgrv0.Cells("idEstado_envio").Value, Long)
                a.pl_doc = CType(dgrv0.Cells("idEstado_factura").Value, Long)
                a.ps_idpersona = CType(dgrv0.Cells("idcliente").Value, Long)
                a.cmbagencias_destinos.Enabled = intPerfil = 1 Or intPerfil = 4
                '**
                'a.ShowDialog()
                '**
                Acceso.Asignar(a, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    a.ShowDialog()
                Else
                    MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                If Not a.pb_cancela Then
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("La Guía Nº " & ls_documento & " ha sido Actualizada.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    BtnBuscar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '****CAMBIAR CREDITO A CONTADO***
    Private Sub CambiarCréditoAContadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarCréditoAContadoToolStripMenuItem.Click
        Dim ll_rol_usuario As Long
        Dim flag As Boolean = False
        Dim dgrv0 As DataGridViewRow
        Dim ls_documento As String
        Dim ls_tipo_comprobante As String
        Dim ll_facturado As Long
        '
        Try
            ll_rol_usuario = dtoUSUARIOS.m_iIdRol '
            'If Acceso.SiRol(G_Rol, Me, 8) Then
            dgrv0 = Me.DgvLista.CurrentRow()
            ls_documento = CType(dgrv0.Cells("guia").Value, String)
            Dim iGuia As Integer = Me.DgvLista.CurrentRow.Cells("IdFactura").Value
            Dim resp As DialogResult = MessageBox.Show("Está seguro de cambiar la Guía de Envío Nº " & ls_documento & " a Contado?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.AppStarting
                Dim obj As New dtoGuia
                obj.CreditoContado(iGuia)
                Me.Cursor = Cursors.Default
                MessageBox.Show("La Guía Nº " & ls_documento & " ha sido cambiada a Contado.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BtnBuscar_Click(sender, e)
            End If
            'Else
            'Me.Cursor = Cursors.Default
            'MessageBox.Show("No tiene Acceso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Cursor = Cursors.AppStarting
            ObjBusquedaClientes.v_fecha_inicio = DtpFechaInicio.Text
            ObjBusquedaClientes.v_fecha_final = DtpFechaFin.Text
            Dim ObjfrmBuscarCliente As New frmBuscarCliente
            Acceso.Asignar(ObjfrmBuscarCliente, Me.hnd)

            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                ObjfrmBuscarCliente.Control = 3
                ObjfrmBuscarCliente.DtpFechaInicio = Me.DtpFechaInicio.Text
                ObjfrmBuscarCliente.DtpFechaFin = Me.DtpFechaFin.Text
                If ObjfrmBuscarCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    objControlFacturasBol.iControl = 5
                    '***************
                    Listar(Me.DtpFechaInicio.Text, Me.DtpFechaFin.Text, CboCiudadOrigen.SelectedValue, _
                    Me.CboCiudadDestino.SelectedValue, Me.CboAgenciaOrigen.SelectedValue, Me.CboUsuario.SelectedValue, Me.CboEstado.SelectedValue)
                    '***************
                    ObjBusquedaClientes.idPersona = 0
                    objControlFacturasBol.iControl = 0
                End If
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            ObjBusquedaClientes.idPersona = 0
        End Try
    End Sub

#Region "OPERACIONES"

#Region "Btn Nuevo"
    Dim bNuevo As Boolean
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Try
            Me.Cursor = Cursors.AppStarting
            intComprobanteRecojo = 0
            iOpcion = 1
            bNuevo = True
            BtnGraba.Enabled = True
            CboTipo.SelectedValue = 2 'X Defecto es credito

            'CboProducto.Enabled = False
            'RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            'RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            'CboTipoTarifa.SelectedIndex = -1
            'AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            'AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            Me.txtFechaGuia.Text = dtoUSUARIOS.m_sFecha '--> Fecha Hora Servidor  

            txtFechaGuia.Text = ""
            Me.txtFechaGuia.Format = DateTimePickerFormat.Custom
            Me.txtFechaGuia.CustomFormat = " "

            '--
            Me.FNNUEVO()
            '--
            Me.TabGuia.SelectTab(1)
            CboCiudad_Origen.Focus()

            '---USUARIO REMOTO---
            Me.lblUsuarios.Visible = True
            Me.CboListaUsuarios.Visible = True
            Me.CboListaUsuarios.Enabled = True
            Me.CboTipo.Enabled = True '08122011
            Me.CboListaUsuarios.SelectedValue = 0
            '-----------------------
            CboProducto.SelectedIndex = 0

            'CboCiudad_Origen.SelectedValue = dtoUSUARIOS.m_idciudad

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Btn Editar"
    Dim iOpcion As Integer = 0
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click


        Try
            Me.Cursor = Cursors.AppStarting
            Dim row As Integer = DgvLista.SelectedRows.Item(0).Index
            iOpcion = 1
            bNuevo = False
            intComprobanteRecojo = 0
            Me.limpiar_documentos_cliente()
            '-----
            Me.ControlDatos()
            '-----         
            '---USUARIO REMOTO----
            Me.lblUsuarios.Visible = False
            Me.CboListaUsuarios.Visible = False
            Me.CboListaUsuarios.Enabled = False
            Me.CboListaUsuarios.SelectedValue = 0
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub FormatoEditar(ByVal iTipoComprobante As Integer)

        CboTipo.Enabled = False
        If iTipoComprobante = 3 Then 'credito
            Me.CboProducto.Enabled = False
            Me.CboTipoTarifa.Enabled = True
            Me.CboSubCuenta.Enabled = True
        ElseIf iTipoComprobante = 85 Or iTipoComprobante = 86 Then 'contado
            Me.CboProducto.Enabled = True
            Me.CboTipoTarifa.Enabled = True
            Me.CboSubCuenta.Enabled = False
        End If

        Me.TxtNroDocCliente.ReadOnly = True
        Me.TxtNomCliente.ReadOnly = True
        Me.TxtNumDocRemitente.ReadOnly = True
        Me.TxtNumDocRemitente.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNroDocContacto.ReadOnly = True
        Me.TxtNroDocContacto.BackColor = System.Drawing.SystemColors.Control
        Me.TxtTelfCliente.ReadOnly = True
        'Me.TxtNroDocConsignado.ReadOnly = True
        'Me.TxtNombConsignado.ReadOnly = True
        'Me.TxtTelfConsignado.ReadOnly = True
        Me.TxtDescuento.Enabled = False
        'Me.TxtDescuento.BackColor = System.Drawing.SystemColors.Control
        Me.txtDescDescto.Enabled = False
        'Me.txtDescDescto.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Sub FormatoConsultar()
        Me.CboProducto.Enabled = True
        Me.CboTipoTarifa.Enabled = True
        Me.TxtNroDocCliente.ReadOnly = False
        Me.TxtNomCliente.ReadOnly = False
        Me.TxtNumDocRemitente.ReadOnly = False
        Me.CboSubCuenta.Enabled = True
        Me.TxtNumDocRemitente.BackColor = Color.White
        Me.TxtNroDocContacto.ReadOnly = False
        Me.TxtNroDocContacto.BackColor = Color.White
        Me.TxtTelfCliente.ReadOnly = False
        'Me.TxtNroDocConsignado.ReadOnly = False
        'Me.TxtNombConsignado.ReadOnly = False
        'Me.TxtTelfConsignado.ReadOnly = False
        Me.TxtDescuento.Enabled = True
        'Me.TxtDescuento.BackColor = Color.White
        Me.txtDescDescto.Enabled = True
        'Me.txtDescDescto.BackColor = Color.White
        Me.txtCantidadSobres.ReadOnly = False
        Me.TxtSubTotal.ReadOnly = False
        Me.TxtImpuesto.ReadOnly = False
        Me.TxtTotal.ReadOnly = False

        Me.TxtReferencia.BackColor = Color.White

    End Sub

#End Region

#Region "Btn Consultar"
    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Me.FnConsultar()

            '---USUARIO REMOTO--------
            Me.lblUsuarios.Visible = False
            Me.CboListaUsuarios.Visible = False
            '-------------------------

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvLista_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgvLista.DoubleClick
        Try
            Me.Cursor = Cursors.AppStarting
            Me.FnConsultar()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub FnConsultar()
        Try
            Dim row As Integer = DgvLista.SelectedRows.Item(0).Index
            'iOpcion = 2
            iOpcion = IIf(Me.DgvLista.CurrentRow.Cells("idestado_envio").Value = 12, 1, 2)
            FNNUEVO()

            bNuevo = False
            'limpiar_documentos_cliente()
            '-----
            Me.ControlDatos()
            '-----            
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

    Dim IDGUIAS_ENVIO As Integer
    '***MOSTRAR VENTA CONTADO****
    Dim iIDSubcuenta As Integer, iIDAgenciaDestino As Integer, iCiudad As Integer, iAgencia As Integer, iTipoEntrega As Integer, iTipoVenta As Integer
    Dim Proceso As Integer, iTipoTarifa As Integer
    Dim sFechaGuia As String
    Dim iIDSubcuentaOrigen As Integer

    Sub MostrarVentaContado(ByVal ds As DataSet)
        Try
            If GrdDetalleVenta.Rows.Count = 5 Then
                GrdDetalleVenta.Rows.RemoveAt(4)
            End If

            bDirecConsigMod = False
            bContactoModificado = False
            bDireccionModificada = False

            Me.Text = "Mantenimiento Guia de Envio"
            '**TIPO VENTA*****************************************
            CboTipo.SelectedValue = iTipoVenta
            '**RECUPERANDO EL PRODUCTO****************************
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            CboProducto.SelectedValue = ds.Tables(0).Rows(0).Item("Proceso")
            Proceso = ds.Tables(0).Rows(0).Item("Proceso")
            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            '**RECUPERANDO EL TIPO DE TARIFA**********************
            RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            CboTipoTarifa.SelectedValue = ds.Tables(0).Rows(0).Item("Tipo_Tarifa")
            iTipoTarifa = ds.Tables(0).Rows(0).Item("Tipo_Tarifa")
            AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            '**RECUPERANDO LA [FECHA EMITIDA]*********************
            Me.txtFechaGuia.Text = ds.Tables(0).Rows(0).Item("Fecha_Factura")
            sFechaGuia = ds.Tables(0).Rows(0).Item("Fecha_Factura")
            '**RECUPERANDO LA SERIE*********************************            
            Me.txtNroNroGuia.Text = ds.Tables(0).Rows(0).Item("Nro_Guia")
            '**RECUPERANDO DATOS DEL ORIGEN*************************
            '--Ciudad Origen
            iCiudad = ds.Tables(0).Rows(0).Item("IDUnidad_Origen")
            CboCiudad_Origen.SelectedValue = ds.Tables(0).Rows(0).Item("IDUnidad_Origen")
            '--Agencia Origen
            iAgencia = ds.Tables(0).Rows(0).Item("IDAgencias")
            CboAgencia_Origen.SelectedValue = ds.Tables(0).Rows(0).Item("IDAgencias")

            '**RECUPERANDO DATOS DEL DESTINO*************************
            '--Ciudad Destino
            TxtCiudadDestino.Text = ds.Tables(0).Rows(0).Item("DESTINO")
            idUnidadAgencias = ds.Tables(0).Rows(0).Item("IDDESTINO")
            iCiudadDestino = ds.Tables(0).Rows(0).Item("IDDESTINO")

            ObjVentaCargaContado.fnGetAgencias(ds.Tables(0).Rows(0).Item("IDDESTINO"))
            Dim DtAgenciaDestino As DataTable = ObjVentaCargaContado.dt_VarAgencias.Copy
            With Me.CboAgenciaDest
                DtAgenciaDestino = ObjVentaCargaContado.dt_VarAgencias.Copy
                .DataSource = DtAgenciaDestino
                .DisplayMember = "nombre_agencia"
                .ValueMember = "idagencias"
            End With
            '--Agencia Destino
            iIDAgenciaDestino = ds.Tables(0).Rows(0).Item("IDAGENCIAS_DESTINO")
            CboAgenciaDest.SelectedValue = ds.Tables(0).Rows(0).Item("IDAGENCIAS_DESTINO")

            iTipoEntrega = ds.Tables(0).Rows(0).Item("IDTIPO_ENTREGA")
            CboTipoEntrega.SelectedValue = ds.Tables(0).Rows(0).Item("IDTIPO_ENTREGA")

            '===============================================
            '*****DATOS CLIENTE*****************************
            'sDocCliente = ds.Tables(0).Rows(0).Item("Nu_Docu_Suna").ToString.Trim '    Con Documento
            'Dim Cliente As Integer = ds.Tables(0).Rows(0).Item("IDPersona") '          Sin Documento
            ''------
            'If sDocCliente.Trim.Length > 0 Then
            '    Buscar(sDocCliente, 1, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
            'Else
            '    Buscar(Cliente, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
            'End If           

            'Recuperando el [NRO DOCUMENTO CLIENTE, NRO DE RUC, NRO BOLETA]
            'RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            'Me.TxtNroDocCliente.Text = ds.Tables(0).Rows(0).Item("Nu_Docu_Suna").ToString.Trim
            ''Recuperando el CODIGO DEL CLIENTE
            'Me.TxtNroDocCliente.Tag = ds.Tables(0).Rows(0).Item("IDPersona")
            'AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged

            ''Recuperando el [NOMBRE DEL CLIENTE]
            'Me.TxtNomCliente.Text = ds.Tables(0).Rows(0).Item("Razon_Social")
            ''Recuperando la [DIRECCION DEL CLIENTE]
            'IdDireccionOrigen = ds.Tables(0).Rows(0).Item("iddireecion_origen")
            RemoveHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
            Me.CboDireccion.SelectedValue = ds.Tables(0).Rows(0).Item("iddireecion_origen")
            'IdDireccionOrigen = CboDireccion.SelectedValue
            AddHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged

            'Recuperando dato [ChkCargo]**************************
            'hlamas 22-03-2016
            'Me.ChkCargo.Checked = ds.Tables(0).Rows(0).Item("cargo")
            Me.chkDocumentoCliente.Checked = ds.Tables(0).Rows(0).Item("cargo")
            Me.rbtCargoSi.Checked = ds.Tables(0).Rows(0).Item("cargo")

            'Recuperando el [TELEFONO DEL CLIENTE]

            bClienteModificado = False
            bClienteNuevo = False
            Me.iID_Persona = ds.Tables(0).Rows(0).Item("idpersona")
            Me.TxtNroDocCliente.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NU_DOCU_SUNA")), "", ds.Tables(0).Rows(0).Item("NU_DOCU_SUNA"))
            Me.TxtNomCliente.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Razon_Social")), "", ds.Tables(0).Rows(0).Item("Razon_Social"))
            Me.TxtTelfCliente.Text = IIf(ds.Tables(0).Rows(0).Item("telefono") = " ", "", ds.Tables(0).Rows(0).Item("telefono"))

            sNombresCli = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nombres")), "", ds.Tables(0).Rows(0).Item("nombres"))
            sApCli = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApePaternoCliente")), "", ds.Tables(0).Rows(0).Item("ApePaternoCliente"))
            sAmCli = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApeMaternoCliente")), "", ds.Tables(0).Rows(0).Item("ApeMaternoCliente"))
            sTelfCliente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TelefonoCliente")), "", ds.Tables(0).Rows(0).Item("TelefonoCliente"))
            sRazonSocialCliente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Razon_Social")), "", ds.Tables(0).Rows(0).Item("Razon_Social"))
            iID_TipoDocCli = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TipoDocumentoCliente")), 9, ds.Tables(0).Rows(0).Item("TipoDocumentoCliente"))
            sEmail = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Email")), "", ds.Tables(0).Rows(0).Item("Email"))

            Dim dr As DataRow
            dtCliente = New DataTable
            dtCliente.Columns.Add(New DataColumn("idpersona", GetType(Integer)))
            dtCliente.Columns.Add(New DataColumn("razon_social", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("tipo", GetType(Integer)))
            dtCliente.Columns.Add(New DataColumn("nu_docu_suna", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("nombres", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("ap", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("am", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("telefono", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("Email", GetType(String))) '
            dr = dtCliente.NewRow
            dr("idpersona") = ds.Tables(0).Rows(0).Item("idpersona")
            dr("razon_social") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Razon_Social")), "", ds.Tables(0).Rows(0).Item("Razon_Social"))
            dr("tipo") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TipoDocumentoCliente")), 9, ds.Tables(0).Rows(0).Item("TipoDocumentoCliente"))
            dr("nu_docu_suna") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NU_DOCU_SUNA")), "", ds.Tables(0).Rows(0).Item("NU_DOCU_SUNA"))
            dr("nombres") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nombres")), "", ds.Tables(0).Rows(0).Item("nombres"))
            dr("ap") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApePaternoCliente")), "", ds.Tables(0).Rows(0).Item("ApePaternoCliente"))
            dr("am") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApeMaternoCliente")), "", ds.Tables(0).Rows(0).Item("ApeMaternoCliente"))
            dr("telefono") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TelefonoCliente")), "", ds.Tables(0).Rows(0).Item("TelefonoCliente"))
            dr("Email") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Email")), "", ds.Tables(0).Rows(0).Item("Email"))
            dtCliente.Rows.Add(dr)
            Me.TxtCliente.Text = ""

            'If iOpcion = 2 Then
            'Me.CboListaUsuarios.SelectedValue = Me.DgvLista.CurrentRow.Cells("idusuario_personal").Value
            'Else
            'Me.CboListaUsuarios.SelectedValue = dtoUSUARIOS.IdLogin
            'End If

            '==========================================
            '****DIRECCION CLIENTE*********************

            IdDireccionOrigen = ds.Tables(0).Rows(0).Item("iddireecion_origen")
            'iDepartamento = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("iddepartamento")), 0, ds.Tables(0).Rows(0).Item("iddepartamento"))
            'iProvincia = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("idprovincia")), 0, ds.Tables(0).Rows(0).Item("idprovincia"))
            'iDistrito = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("iddistrito")), 0, ds.Tables(0).Rows(0).Item("iddistrito"))
            'iId_via = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_via")), 0, ds.Tables(0).Rows(0).Item("id_via"))
            'sVia = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("via")), "", ds.Tables(0).Rows(0).Item("via"))
            'sNumero2 = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("numero")), "", ds.Tables(0).Rows(0).Item("numero"))
            'sManzana = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("manzana")), "", ds.Tables(0).Rows(0).Item("manzana"))
            'sLote = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("lote")), "", ds.Tables(0).Rows(0).Item("lote"))
            'iId_Nivel = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_nivel")), 0, ds.Tables(0).Rows(0).Item("id_nivel"))
            'sNivel = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nivel")), "", ds.Tables(0).Rows(0).Item("nivel"))
            'iId_Zona = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_zona")), 0, ds.Tables(0).Rows(0).Item("id_zona"))
            'sZona = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("zona")), "", ds.Tables(0).Rows(0).Item("zona"))
            'iId_Clasificacion = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Id_Clasificacion")), 0, ds.Tables(0).Rows(0).Item("Id_Clasificacion"))
            'sClasificacion = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Clasificacion")), "", ds.Tables(0).Rows(0).Item("Clasificacion"))

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

            If ds.Tables(0).Rows(0).Item("iddireecion_origen") > 0 Then
                dr = dtDireccion.NewRow
                dr("iddireccion_consignado") = ds.Tables(0).Rows(0).Item("iddireecion_origen")
                dr("direccion") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("DirOrigen")), "", ds.Tables(0).Rows(0).Item("DirOrigen"))
                dr("id_via") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_via")), 0, ds.Tables(0).Rows(0).Item("id_via"))
                dr("via") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("via")), "", ds.Tables(0).Rows(0).Item("via"))
                dr("numero") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("numero")), "", ds.Tables(0).Rows(0).Item("numero"))
                dr("manzana") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("manzana")), "", ds.Tables(0).Rows(0).Item("manzana"))
                dr("lote") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("lote")), "", ds.Tables(0).Rows(0).Item("lote"))
                dr("id_nivel") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_nivel")), 0, ds.Tables(0).Rows(0).Item("id_nivel"))
                dr("nivel") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nivel")), "", ds.Tables(0).Rows(0).Item("nivel"))
                dr("id_zona") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_zona")), 0, ds.Tables(0).Rows(0).Item("id_zona"))
                dr("zona") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("zona")), "", ds.Tables(0).Rows(0).Item("zona"))
                dr("id_clasificacion") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Id_Clasificacion")), 0, ds.Tables(0).Rows(0).Item("Id_Clasificacion"))
                dr("clasificacion") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Clasificacion")), "", ds.Tables(0).Rows(0).Item("Clasificacion"))
                dr("iddepartamento") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("iddepartamento")), 0, ds.Tables(0).Rows(0).Item("iddepartamento"))
                dr("idprovincia") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("idprovincia")), 0, ds.Tables(0).Rows(0).Item("idprovincia"))
                dr("iddistrito") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("iddistrito")), 0, ds.Tables(0).Rows(0).Item("iddistrito"))
                dtDireccion.Rows.Add(dr)
            End If
            '-----
            Me.CboDireccion.DataSource = dtDireccion
            CboDireccion.DisplayMember = "direccion"
            CboDireccion.ValueMember = "iddireccion_consignado"
            Me.CboDireccion.SelectedValue = ds.Tables(0).Rows(0).Item("iddireecion_origen")

            '============================
            '********DATOS REMITENTE*****
            'Me.TxtNumDocRemitente.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("DNIRemitente")), "", ds.Tables(0).Rows(0).Item("DNIRemitente"))
            'idRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ID_Remitente")), 0, ds.Tables(0).Rows(0).Item("ID_Remitente"))
            'RemoveHandler CboRemitente.SelectedIndexChanged, AddressOf CboRemitente_SelectedIndexChanged
            'Me.CboRemitente.SelectedValue = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ID_Remitente")), 0, ds.Tables(0).Rows(0).Item("ID_Remitente"))
            'AddHandler CboRemitente.SelectedIndexChanged, AddressOf CboRemitente_SelectedIndexChanged
            ''--
            'If Me.TxtNumDocRemitente.Text.Trim = Me.TxtNroDocCliente.Text.Trim And Me.TxtNroDocCliente.Text.Trim.Length > 0 Then
            '    ChkCliente.Checked = True
            'Else
            '    ChkCliente.Checked = False
            'End If

            'sNroDocRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("DNIRemitente")), "", ds.Tables(0).Rows(0).Item("DNIRemitente"))
            'iID_TipoDocRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TipoDocumRemitente")), 9, ds.Tables(0).Rows(0).Item("TipoDocumRemitente"))
            'sNombreRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombreRemitente")), "", ds.Tables(0).Rows(0).Item("NombreRemitente"))
            'sApRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApePaternoRemitente")), "", ds.Tables(0).Rows(0).Item("ApePaternoRemitente"))
            'sAmRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApeMaternoRemitente")), "", ds.Tables(0).Rows(0).Item("ApeMaternoRemitente"))

            bRemitenteModificado = False
            sNroDocRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("dniremitente")), "", ds.Tables(0).Rows(0).Item("dniremitente"))
            iID_TipoDocRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TipoDocumRemitente")), 9, ds.Tables(0).Rows(0).Item("TipoDocumRemitente"))
            sNombreRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombreRemitente")), "", ds.Tables(0).Rows(0).Item("NombreRemitente"))
            sApRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApePaternoRemitente")), "", ds.Tables(0).Rows(0).Item("ApePaternoRemitente"))
            sAmRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApeMaternoRemitente")), "", ds.Tables(0).Rows(0).Item("ApeMaternoRemitente"))
            '--------

            Me.TxtNumDocRemitente.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("dniremitente")), "", ds.Tables(0).Rows(0).Item("dniremitente"))
            Me.idRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_remitente")), 0, ds.Tables(0).Rows(0).Item("id_remitente"))
            dtRemitente = New DataTable
            dtRemitente.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
            dtRemitente.Columns.Add(New DataColumn("nombres", GetType(String)))
            dtRemitente.Columns.Add(New DataColumn("nombre", GetType(String))) 'new
            dtRemitente.Columns.Add(New DataColumn("idtipo_documento_contacto", GetType(Integer)))
            dtRemitente.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
            dtRemitente.Columns.Add(New DataColumn("apepat", GetType(String)))
            dtRemitente.Columns.Add(New DataColumn("apemat", GetType(String)))

            dr = dtRemitente.NewRow
            dr("idcontacto_persona") = 0
            dr("nombres") = " (SELECCIONE)"
            dr("idtipo_documento_contacto") = 0
            dr("nrodocumento") = ""
            dtRemitente.Rows.Add(dr)


            If Me.idRemitente > 0 Then
                dr = dtRemitente.NewRow
                dr("idcontacto_persona") = ds.Tables(0).Rows(0).Item("id_remitente")
                dr("nombres") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombresRemitente")), "", ds.Tables(0).Rows(0).Item("NombresRemitente"))
                dr("nombre") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombreRemitente")), "", ds.Tables(0).Rows(0).Item("NombreRemitente"))
                dr("idtipo_documento_contacto") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TipoDocumRemitente")), 9, ds.Tables(0).Rows(0).Item("TipoDocumRemitente"))
                dr("nrodocumento") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("dniremitente")), "", ds.Tables(0).Rows(0).Item("dniremitente"))
                dr("apepat") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApePaternoRemitente")), "", ds.Tables(0).Rows(0).Item("ApePaternoRemitente"))
                dr("apemat") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApeMaternoRemitente")), "", ds.Tables(0).Rows(0).Item("ApeMaternoRemitente"))
                dtRemitente.Rows.Add(dr)
            End If

            Me.CboRemitente.DataSource = dtRemitente
            CboRemitente.DisplayMember = "nombres"
            CboRemitente.ValueMember = "idcontacto_persona"
            Me.CboRemitente.SelectedValue = ds.Tables(0).Rows(0).Item("ID_REMITENTE")
            dtRemitenteParalelo = dtRemitente.Copy

            RemoveHandler ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged
            Me.ChkCliente.Checked = False
            If Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso Me.TxtNroDocCliente.Text.Trim = Me.TxtNumDocRemitente.Text.Trim Then
                Me.ChkCliente.Checked = True
            End If
            AddHandler ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged

            '==============================
            '********DATOS CONTACTO********            
            'Me.TxtNroDocContacto.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("dniContacto")), "", ds.Tables(0).Rows(0).Item("dniContacto"))
            ''Recuperando el [NOMBRE DE CONTACTO]          
            'RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged            
            'Me.CboContacto.SelectedValue = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ID_Contacto")), 0, ds.Tables(0).Rows(0).Item("ID_Contacto"))
            'idcontacto = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ID_Contacto")), 0, ds.Tables(0).Rows(0).Item("ID_Contacto"))
            'AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
            ''--
            'If Me.TxtNroDocContacto.Text.Trim = Me.TxtNroDocCliente.Text.Trim And Me.TxtNroDocCliente.Text.Trim.Length > 0 Then
            '    ChkCliente1.Checked = True
            'Else
            '    ChkCliente1.Checked = False
            'End If

            'iID_TipoDocCont = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TipoDocumContacto")), 9, ds.Tables(0).Rows(0).Item("TipoDocumContacto"))
            'NombresCont = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombreContacto")), "", ds.Tables(0).Rows(0).Item("NombreContacto"))
            'apellPatCont = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApePaternoContacto")), "", ds.Tables(0).Rows(0).Item("ApePaternoContacto"))
            'apellMatCont = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApeMaternoContacto")), "", ds.Tables(0).Rows(0).Item("ApeMaternoContacto"))

            bContactoModificado = False

            Me.TxtNroDocContacto.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("dniContacto")), "", ds.Tables(0).Rows(0).Item("dniContacto"))
            Me.idcontacto = ds.Tables(0).Rows(0).Item("ID_Contacto")
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

            If ds.Tables(0).Rows(0).Item("ID_Contacto") > 0 Then
                dr = dtContacto.NewRow
                dr("idcontacto_persona") = ds.Tables(0).Rows(0).Item("ID_Contacto")
                dr("nombres") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombresContacto")), "", ds.Tables(0).Rows(0).Item("NombresContacto"))
                dr("nombre") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombreContacto")), "", ds.Tables(0).Rows(0).Item("NombreContacto"))
                dr("idtipo_documento_contacto") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TipoDocumContacto")), 9, ds.Tables(0).Rows(0).Item("TipoDocumContacto"))
                dr("nrodocumento") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("dniContacto")), "", ds.Tables(0).Rows(0).Item("dniContacto"))
                dr("apepat") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApePaternoContacto")), "", ds.Tables(0).Rows(0).Item("ApePaternoContacto"))
                dr("apemat") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApeMaternoContacto")), "", ds.Tables(0).Rows(0).Item("ApeMaternoContacto"))
                dtContacto.Rows.Add(dr)
            End If

            Me.CboContacto.DataSource = dtContacto
            CboContacto.DisplayMember = "nombres"
            CboContacto.ValueMember = "idcontacto_persona"
            Me.CboContacto.SelectedValue = ds.Tables(0).Rows(0).Item("ID_Contacto")
            dtContactoParalelo = dtContacto.Copy

            RemoveHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
            Me.ChkCliente1.Checked = False
            If Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso Me.TxtNroDocCliente.Text.Trim = Me.TxtNroDocContacto.Text.Trim Then
                Me.ChkCliente1.Checked = True
            End If
            AddHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged



            '=======DATOS CONSIGNADO=================   
            GrdNConsignado.Rows.Clear()
            If ds.Tables(5).Rows.Count > 0 Then
                ChkCliente2.Checked = False
                For Each fila As DataRow In ds.Tables(5).Rows
                    Dim row0 As String() = {fila.Item("IDConsignado"), fila.Item("NroDocumento"), fila.Item("Nombres").ToString, _
                                            fila.Item("Telefono").ToString, _
                                            fila.Item("Nombre"), fila.Item("IDTipoDocDocumento"), _
                                            fila.Item("apepat"), fila.Item("apemat"), 0, fila.Item("IDVentaConsignado")
                                           }
                    GrdNConsignado.Rows().Add(row0)
                Next

                If ds.Tables(5).Rows.Count = 1 AndAlso Me.TxtNroDocCliente.Text.Trim = GrdNConsignado("Nº Documento", 0).Value.Trim And Me.TxtNroDocCliente.Text.Trim.Length > 0 Then
                    ChkCliente2.Checked = True
                End If
            Else
                GrdNConsignado.Rows.Add()
                GrdNConsignado("IDConsignado", 0).Value = ds.Tables(0).Rows(0).Item("IDCONTACTO_DESTINO")
                GrdNConsignado("Nº Documento", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("dniDestinatario")), "", ds.Tables(0).Rows(0).Item("dniDestinatario"))
                GrdNConsignado("Nombres", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Nombres")), "", ds.Tables(0).Rows(0).Item("Nombres"))
                GrdNConsignado("Telefono", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Tel_destino")), "", ds.Tables(0).Rows(0).Item("Tel_destino"))
                GrdNConsignado("nombre", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Nombre")), "", ds.Tables(0).Rows(0).Item("Nombre"))
                GrdNConsignado("tipo", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("idTipoDocConsig")), 9, ds.Tables(0).Rows(0).Item("idTipoDocConsig"))
                GrdNConsignado("apepat", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Apepat")), "", ds.Tables(0).Rows(0).Item("Apepat"))
                GrdNConsignado("apemat", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Apemat")), "", ds.Tables(0).Rows(0).Item("Apemat"))

                If Me.TxtNroDocCliente.Text.Trim = GrdNConsignado("Nº Documento", 0).Value.Trim And Me.TxtNroDocCliente.Text.Trim.Length > 0 Then
                    ChkCliente2.Checked = True
                Else
                    ChkCliente2.Checked = False
                End If
            End If

            'Dim dr As DataRow
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
            dr("idcontacto_persona") = ds.Tables(0).Rows(0).Item("IDContacto_Destino")
            dr("nombres") = ds.Tables(0).Rows(0).Item("Nombres").ToString.Trim
            dr("nombre") = ds.Tables(0).Rows(0).Item("Nombre").ToString.Trim
            dr("tipo") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("IDTipoDocConsig")), 9, ds.Tables(0).Rows(0).Item("idTipoDocConsig"))
            dr("nrodocumento") = ds.Tables(0).Rows(0).Item("DNIDestinatario").ToString.Trim
            dr("apepat") = ds.Tables(0).Rows(0).Item("Apepat").ToString.Trim
            dr("apemat") = ds.Tables(0).Rows(0).Item("Apemat").ToString.Trim
            dr("telefono") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Tel_destino")) = True, "", ds.Tables(0).Rows(0).Item("Tel_destino")).ToString.Trim
            dtConsignado.Rows.Add(dr)
            '***************

            '===================================================
            '*********DATOS DIRECCION CONSIGNADO****************
            'Me.BuscarConsignado(ds.Tables(0).Rows(0).Item("IDCONTACTO_DESTINATARIO"))
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


            Me.idDireConsignado = ds.Tables(0).Rows(0).Item("iddireecion_destino")
            dr = dtDireccion2.NewRow
            dr("iddireccion_consignado") = ds.Tables(0).Rows(0).Item("iddireecion_destino")
            dr("direccion") = ds.Tables(0).Rows(0).Item("dir_Destinatario")
            dr("id_via") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_viaDest")), 0, ds.Tables(0).Rows(0).Item("id_viaDest"))
            dr("via") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("viaDest")), "", ds.Tables(0).Rows(0).Item("viaDest"))
            dr("numero") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("numeroDest")), "", ds.Tables(0).Rows(0).Item("numeroDest"))
            dr("manzana") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("manzanaDest")), "", ds.Tables(0).Rows(0).Item("manzanaDest"))
            dr("lote") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("loteDest")), "", ds.Tables(0).Rows(0).Item("loteDest"))
            dr("id_nivel") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_nivelDest")), 0, ds.Tables(0).Rows(0).Item("id_nivelDest"))
            dr("nivel") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nivelDest")), "", ds.Tables(0).Rows(0).Item("nivelDest"))
            dr("id_zona") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_zonaDest")), 0, ds.Tables(0).Rows(0).Item("id_zonaDest"))
            dr("zona") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("zonaDest")), "", ds.Tables(0).Rows(0).Item("zonaDest"))
            dr("id_clasificacion") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Id_ClasificacionDest")), 0, ds.Tables(0).Rows(0).Item("Id_ClasificacionDest"))
            dr("clasificacion") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ClasificacionDest")), "", ds.Tables(0).Rows(0).Item("ClasificacionDest"))
            dr("iddepartamento") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("iddepartamentoDest")), 0, ds.Tables(0).Rows(0).Item("iddepartamentoDest"))
            dr("idprovincia") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("idprovinciaDest")), 0, ds.Tables(0).Rows(0).Item("idprovinciaDest"))
            dr("iddistrito") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("iddistritoDest")), 0, ds.Tables(0).Rows(0).Item("iddistritoDest"))
            dr("de_referencia") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("de_referencia")), "", ds.Tables(0).Rows(0).Item("de_referencia"))
            dtDireccion2.Rows.Add(dr)

            Me.CboDireccion2.DataSource = dtDireccion2
            CboDireccion2.DisplayMember = "direccion"
            CboDireccion2.ValueMember = "iddireccion_consignado"
            Me.CboDireccion2.SelectedValue = ds.Tables(0).Rows(0).Item("iddireecion_destino")
            Me.TxtReferencia.Text = ds.Tables(0).Rows(0).Item("De_Referencia")
            '******************************************************************

            '*Recuperando el [NRO DOCUMENTO CONSIGNADO,RUC, BOLETA]
            ' Me.TxtNroDocConsignado.Text = ds.Tables(0).Rows(0).Item("DNIDestinatario").ToString.Trim'NCONSIGNADO
            '*Recuperando el [NOMBRE DEL CONSIGNADO]
            'Me.TxtNombConsignado.Text = ds.Tables(0).Rows(0).Item("Nombres").ToString.Trim  NCONSIGNADO
            '*Recuperando el IDCONSIGNADO
            ObjVentaCargaContado.v_IDCONTACTO_DESTINO = ds.Tables(0).Rows(0).Item("IDContacto_Destino")
            iIDConsignado = ds.Tables(0).Rows(0).Item("IDContacto_Destino")
            bConsignadoNuevo = False

            '*Recuperando La [DIRECCION DEL CONSIGNADO]
            If iTipoEntrega = 1 Then
                CboTipoEntrega.SelectedValue = TipoEntrega.Agencia
            Else
                CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio
                ObjVentaCargaContado.v_IDDIREECION_DESTINO = ds.Tables(0).Rows(0).Item("iddireecion_destino")
                Me.CboDireccion2.SelectedValue = ds.Tables(0).Rows(0).Item("iddireecion_destino")
            End If

            ''*Recuperando el [EL TELEFONO DEL CONSIGNADO]
            ''Me.TxtTelfConsignado.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Tel_destino")) = True, "", ds.Tables(0).Rows(0).Item("Tel_destino")).ToString.Trim NCONSIGNADO
            'Me.TxtReferencia.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("De_Referencia")) = True, "", ds.Tables(0).Rows(0).Item("De_Referencia")).ToString.Trim

            'NCONSIGNADO
            'RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
            'If Me.TxtNroDocCliente.Text.Trim = Me.TxtNroDocConsignado.Text.Trim And Me.TxtNroDocCliente.Text.Trim.Length > 0 Then
            '    ChkCliente2.Checked = True               
            'Else
            '    ChkCliente2.Checked = False                
            'End If
            'AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged

            '=========DATOS DESCUENTO=========================
            If ds.Tables(0).Rows(0).Item("Total_Costo") > 20 Then
                Me.TxtDescuento.Enabled = True
                'Me.TxtDescuento.ReadOnly = False
                'Me.TxtDescuento.BackColor = Color.White

                If Trim(TxtDescuento.Text.Length) > 0 Then
                    Me.txtDescDescto.Enabled = True
                    Me.txtDescDescto.ReadOnly = False
                    Me.txtDescDescto.BackColor = Color.White
                Else
                    Me.txtDescDescto.ReadOnly = True
                    Me.txtDescDescto.BackColor = System.Drawing.SystemColors.Control
                End If

                'Recuperando el [DESCUENTO]
                Me.TxtDescuento.Text = IIf(ds.Tables(0).Rows(0).Item("Porcent_Descuento") = 0, "", ds.Tables(0).Rows(0).Item("Porcent_Descuento"))
                'Recuperando la [DESCRIPCION DEL DESCUENTO]
                Me.txtDescDescto.Text = Trim(ds.Tables(0).Rows(0).Item("Memo"))
            Else
                Me.TxtDescuento.Text = ""
                Me.txtDescDescto.Text = ""
                Me.TxtDescuento.Enabled = False
                'Me.TxtDescuento.BackColor = System.Drawing.SystemColors.Control
                Me.txtDescDescto.Enabled = False
                'Me.txtDescDescto.BackColor = System.Drawing.SystemColors.Control
            End If

            Dim bVentaNormal As Boolean
            Dim bVentaVolumetrico As Boolean = IIf(ds.Tables(0).Rows(0).Item("METRO_CUBICO") = 1, 1, 0)
            Dim bVentaArticulos As Boolean = IIf(ds.Tables(0).Rows(0).Item("Cantidad_x_Articulos") > 0, 1, 0)
            If Not bVentaVolumetrico And Not bVentaArticulos Then bVentaNormal = 1 Else bVentaNormal = 0

            '=======RECUPERANDO DATOS DEL GRID DETALLE DE VENTA================

            '************VENTA NORMAL*********
            If bVentaNormal Then
                TipoGrid_ = FormatoGrid.BULTO '--------------> Grid Volumetrico
                Me.DiseñaGrdDetalleVenta() '-------> Diseña GridDetalleVenta
                FormatoGrdDetalleVenta() '---------> Formato al grid   

                '**FILA PESO**
                GrdDetalleVenta("Bulto", 0).Value() = IIf(ds.Tables(0).Rows(0).Item("Cantidad_x_Peso") = 0, "", ds.Tables(0).Rows(0).Item("Cantidad_x_Peso"))
                GrdDetalleVenta("Peso/Volumen", 0).Value() = ds.Tables(0).Rows(0).Item("Total_Peso")
                GrdDetalleVenta("Costo", 0).Value() = ds.Tables(0).Rows(0).Item("Precio_x_Peso")
                tarifa_Peso = ds.Tables(0).Rows(0).Item("Precio_x_Peso")

                If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                    '**FILA VOLUMEN**
                    GrdDetalleVenta("Bulto", 1).Value() = IIf(ds.Tables(0).Rows(0).Item("Cantidad_x_Volumen") = 0, "", ds.Tables(0).Rows(0).Item("Cantidad_x_Volumen"))
                    GrdDetalleVenta("Peso/Volumen", 1).Value() = ds.Tables(0).Rows(0).Item("Total_Volumen")
                    GrdDetalleVenta("Costo", 1).Value() = ds.Tables(0).Rows(0).Item("Precio_x_Volumen")
                    tarifa_Volumen = ds.Tables(0).Rows(0).Item("Precio_x_Volumen")
                End If

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
                    If ds.Tables(0).Rows(0).Item("Total_Peso") >= objGuiaEnvio.iPeso_Minimo And ds.Tables(0).Rows(0).Item("Total_Peso") <= objGuiaEnvio.iPeso_Maximo Then
                        GrdDetalleVenta("Sub Neto", 0).Value = objGuiaEnvio.iPrecio_cond_Peso
                    ElseIf ds.Tables(0).Rows(0).Item("Total_Peso") > objGuiaEnvio.iPeso_Maximo Then
                        Dim Calculo As Double = (ds.Tables(0).Rows(0).Item("Total_Peso") - objGuiaEnvio.iPeso_Maximo) * (tarifa_Peso)
                        Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
                        GrdDetalleVenta("Sub Neto", 0).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                    ElseIf ds.Tables(0).Rows(0).Item("Total_Peso") < objGuiaEnvio.iPeso_Minimo Then
                        GrdDetalleVenta("Sub Neto", 0).Value = "0.00"
                    End If

                    '****CALCULO VOLUMEN***
                    If ds.Tables(0).Rows(0).Item("Total_Volumen") >= objGuiaEnvio.iVol_Minimo And ds.Tables(0).Rows(0).Item("Total_Volumen") <= objGuiaEnvio.iVol_Maximo Then
                        GrdDetalleVenta("Sub Neto", 1).Value = objGuiaEnvio.iPrecio_cond_Vol
                    ElseIf ds.Tables(0).Rows(0).Item("Total_Volumen") > objGuiaEnvio.iVol_Maximo Then
                        Dim Calculo2 As Double = (ds.Tables(0).Rows(0).Item("Total_Volumen") - objGuiaEnvio.iVol_Maximo) * (tarifa_Volumen)
                        Dim SubNeto As Double = (Calculo2 + objGuiaEnvio.iPrecio_cond_Vol)
                        GrdDetalleVenta("Sub Neto", 1).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                    ElseIf ds.Tables(0).Rows(0).Item("Total_Volumen") < objGuiaEnvio.iVol_Minimo Then
                        GrdDetalleVenta("Sub Neto", 1).Value = "0.00"
                    End If
                Else
                    objGuiaEnvio.CondicionTarifa_ = False
                    '****CALCULO PESO*****
                    GrdDetalleVenta("Sub Neto", 0).Value() = ds.Tables(0).Rows(0).Item("Total_Peso") * ds.Tables(0).Rows(0).Item("Precio_x_Peso") '* ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100
                    '****CALCULO VOLUMEN***
                    If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                        GrdDetalleVenta("Sub Neto", 1).Value() = ds.Tables(0).Rows(0).Item("Total_Volumen") * ds.Tables(0).Rows(0).Item("Precio_x_Volumen") '* ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100
                    End If
                End If

                    If Me.CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And Me.CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                        'FILA SOBRE
                        GrdDetalleVenta("Bulto", 2).Value() = IIf(ds.Tables(0).Rows(0).Item("Cantidad_x_Sobre") = 0, "", ds.Tables(0).Rows(0).Item("Cantidad_x_Sobre"))
                        GrdDetalleVenta("Peso/Volumen", 2).Value() = "0.00"
                        GrdDetalleVenta("Costo", 2).Value() = ds.Tables(0).Rows(0).Item("Precio_x_Sobre")
                        tarifa_Sobre = ds.Tables(0).Rows(0).Item("Precio_x_Sobre")
                        GrdDetalleVenta("Sub Neto", 2).Value() = ds.Tables(0).Rows(0).Item("Cantidad_x_Sobre") * ds.Tables(0).Rows(0).Item("Precio_x_Sobre")

                        'FILA BASE
                        GrdDetalleVenta("Costo", 3).Value() = Format(ds.Tables(0).Rows(0).Item("Monto_Base"), "###,###.00")
                        Monto_Base = ds.Tables(0).Rows(0).Item("Monto_Base")
                        GrdDetalleVenta("Sub Neto", 3).Value() = Format(ds.Tables(0).Rows(0).Item("Monto_Base"), "###,###.00")
                    End If

                    '***************************************** 
                    'hlamas 20-11-2013
                    'If ObjVentaCargaContado.MontoEntregaDomicilio > 0 Then
                    If ds.Tables(0).Rows(0).Item("monto_entrega_domicilio") > 0 Then
                        GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, CboCiudadOrigen.SelectedValue, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
                        'AgregarItemVenta("ENTREGA", False)
                        'Dim intFila As Integer = BuscarItemVenta("ENTREGA")
                        'Me.GrdDetalleVenta("Sub Neto", intFila).Value = ObjVentaCargaContado.MontoEntregaDomicilio

                    End If
            End If

            '*********VENTA VOLUMETRICO*************
            If bVentaVolumetrico Then
                TipoGrid_ = FormatoGrid.VOLUMETRICO '--------> Grid Volumetrico
                Me.DiseñaGrdDetalleVenta() '-----------------> Diseña GridDetalleVenta                             
                TxtMontoBase.Text = ds.Tables(0).Rows(0).Item("Monto_Base")
                RemoveHandler ChkM3.CheckedChanged, AddressOf ChkM3_CheckedChanged
                ChkM3.Checked = True
                AddHandler ChkM3.CheckedChanged, AddressOf ChkM3_CheckedChanged

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

                tarifa_Peso = ds.Tables(0).Rows(0).Item("Precio_x_Peso")
                tarifa_Sobre = ds.Tables(0).Rows(0).Item("Precio_x_Sobre")
                '------------------------------

                If ds.Tables(0).Rows(0).Item("monto_entrega_domicilio") > 0 Then
                    GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, CboCiudadOrigen.SelectedValue, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
                End If

                ChkSobres.Visible = True
                txtCantidadSobres.Visible = True
                txtTotalSobre.Visible = True
                LblMontoBase.Visible = True
                TxtMontoBase.Visible = True
                GrpDescuento.Enabled = True
            Else
                RemoveHandler ChkM3.CheckedChanged, AddressOf ChkM3_CheckedChanged
                ChkM3.Checked = False
                AddHandler ChkM3.CheckedChanged, AddressOf ChkM3_CheckedChanged
            End If

            'hlamas 05-12-2013
            dblMontoEntregaDomicilio = Val(ds.Tables(0).Rows(0).Item("monto_entrega_domicilio"))
            If dblMontoEntregaDomicilio > 0 Then
                AgregarItemVenta("ENTREGA", GrdDetalleVenta)
                Dim intFila As Integer = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
                GrdDetalleVenta("sub neto", intFila).Value = dblMontoEntregaDomicilio
            End If

            dblMontoDC = Val(ds.Tables(0).Rows(0).Item("monto_devolucion_cargo"))
            If dblMontoDC > 0 Then
                AgregarItemVenta("DEV CARGO", GrdDetalleVenta)
                Dim intFila As Integer = BuscarItemVenta("DEV CARGO", GrdDetalleVenta)
                GrdDetalleVenta("sub neto", intFila).Value = dblMontoDC
            End If


            '*********VENTA ARTICULOS***************
            If bVentaArticulos Then
                TipoGrid_ = FormatoGrid.ARTICULOS : LbldetalleVenta.Text = "Articulos"
                Me.DiseñaGrdDetalleVenta()
                GrpDescuento.Enabled = False
                RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
                ChkArticulos.Checked = True
                AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged

                LblMontoBase.Visible = True
                TxtMontoBase.Visible = True
                ChkSobres.Visible = True
                txtCantidadSobres.Visible = True
                txtTotalSobre.Visible = True
                '--
                If ds.Tables(1).Rows.Count > 0 Then
                    fArticulo = True
                    For Each fila As DataRow In ds.Tables(1).Rows
                        Dim row0 As String() = {fila.Item("Nombre_Articulo"), FormatNumber(fila.Item("Precio_x_Articulo").ToString, 2), fila.Item("Cantidad_Articulos").ToString, _
                                                fila.Item("Total_Peso").ToString, _
                                                (fila.Item(2)) * (fila.Item(3)), fila.Item("Idarticulos").ToString(), fila.Item("idGuiaArticulo").ToString()
                                               }
                        GrdDetalleVenta.Rows().Add(row0)
                    Next
                End If
                '--
            Else
                RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
                ChkArticulos.Checked = False
                LblMontoBase.Visible = False
                TxtMontoBase.Visible = False
                ChkSobres.Visible = False
                txtCantidadSobres.Visible = False
                txtTotalSobre.Visible = False
                AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
            End If



            '************VENTA CARGA ACOMPAÑADA*************
            RemoveHandler txtBoleto.TextChanged, AddressOf TxtBoleto_TextChanged
            RemoveHandler txtBoleto.LostFocus, AddressOf TxtBoleto_LostFocus
            Me.txtBoleto.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nroboleto")), "", ds.Tables(0).Rows(0).Item("nroboleto"))
            '*********************************************************************
            If ds.Tables(0).Rows(0).Item("proceso") = 6 And ds.Tables(0).Rows(0).Item("nroboleto").ToString.Trim.Length > 2 Then
                Me.bCargaAcompañada = True
                Me.txtBoleto.Enabled = False
                Me.TxtCiudadDestino.Enabled = False
                Me.CboAgenciaDest.Enabled = False
                Me.Grpa.Visible = True
                Me.txtBoleto.Visible = True
            Else
                Me.bCargaAcompañada = False
                Me.txtBoleto.Enabled = True
                Me.TxtCiudadDestino.Enabled = True
                Me.CboAgenciaDest.Enabled = True
                Me.Grpa.Visible = False
                Me.txtBoleto.Visible = False
            End If
            AddHandler txtBoleto.LostFocus, AddressOf TxtBoleto_LostFocus
            AddHandler txtBoleto.TextChanged, AddressOf TxtBoleto_TextChanged


            '====================================================================================
            'Recuperando el [SUB_TOTAL]**********
            TxtSubTotal.Text = Format(ds.Tables(0).Rows(0).Item("Monto_Sub_Total"), "###,###,###.00")
            'Recuperando el [IGV(IMPUESTO)]**********
            TxtImpuesto.Text = Format(ds.Tables(0).Rows(0).Item("Monto_Impuesto"), "###,###,###.00")
            'Recuperando el [TOTAL]**********
            TxtTotal.Text = Format(ds.Tables(0).Rows(0).Item("Total_Costo"), "###,###,###.00")
            '====================================================================================



            '===============RECUPERANDO DATOS DOCUMENTOS DEL CLIENTE=============================
            recuperando_datos_contado = True
            Dim iContador As Integer = 0
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
                    strNroGuias_Remision = ""
                    For Each fila As DataRow In ds.Tables(3).Rows
                        If IsDBNull(fila.Item("PORCEN")) Then
                            iContador += 1
                            Dim idDoc0 As String = fila.Item(0)
                            Dim NroDoc0 As String = fila.Item(1)
                            '
                            GrdDocumentosCliente.Rows(iContador - 1).Cells(0).Value = idDoc0
                            GrdDocumentosCliente.Rows(iContador - 1).Cells(2).Value = NroDoc0
                            strNroGuias_Remision = strNroGuias_Remision & NroDoc0 & ","
                        End If
                    Next
                    If iContador > 0 Then
                        strNroGuias_Remision = strNroGuias_Remision.Substring(0, strNroGuias_Remision.Trim.Length - 1)
                    End If
                Catch
                End Try
            Else
                GrdDocumentosCliente.Rows.Clear()
                GrdDocumentosCliente.Rows.Add(3)
            End If


            '*********RECUPERANDO SOBRES*******
            If ds.Tables(0).Rows(0).Item("Cantidad_x_Sobre") > 0 And (bVentaVolumetrico Or bVentaArticulos) Then
                RemoveHandler ChkSobres.CheckedChanged, AddressOf ChkSobres_CheckedChanged
                ChkSobres.Checked = True
                txtCantidadSobres.Enabled = True
                txtTotalSobre.Enabled = True
                RemoveHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
                TxtMontoBase.Text = Format(ds.Tables(0).Rows(0).Item("Monto_Base"), "###,###.00")
                txtCantidadSobres.Text = ds.Tables(0).Rows(0).Item("Cantidad_x_Sobre")
                txtTotalSobre.Text = ds.Tables(0).Rows(0).Item("Cantidad_x_Sobre") * ds.Tables(0).Rows(0).Item("Precio_x_Sobre")
                AddHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
            Else
                RemoveHandler ChkSobres.CheckedChanged, AddressOf ChkSobres_CheckedChanged
                ChkSobres.Checked = False
                txtCantidadSobres.Enabled = False
                txtTotalSobre.Enabled = False
                txtCantidadSobres.Text = ""
                txtTotalSobre.Text = ""
                AddHandler ChkSobres.CheckedChanged, AddressOf ChkSobres_CheckedChanged
            End If

            '*******Tarifario General
            If TxtNroDocCliente.Text.Trim.Length > 0 Then
                Dim iTarifario = ObjVentaCargaContado.TarifaGeneral(ds.Tables(0).Rows(0).Item("Nu_Docu_Suna").ToString.Trim, _
                                                                    ds.Tables(0).Rows(0).Item("Idunidad_Origen"), _
                                                                    ds.Tables(0).Rows(0).Item("IDDestino"), 999)
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

            '*********************

            ObjVentaCargaContado.fnGetAgencias(CboCiudad_Origen.SelectedValue)
            Dim dt As New DataTable
            dt = ObjVentaCargaContado.dt_VarAgencias.Copy
            With CboAgencia_Origen
                .DataSource = dt
                .DisplayMember = "nombre_agencia"
                .ValueMember = "idagencias"
                .SelectedValue = Me.DgvLista.CurrentRow.Cells("idagencias").Value
            End With
            Me.ListarUsuarios(CboCiudad_Origen.SelectedValue)

            Me.CboListaUsuarios.SelectedValue = Me.DgvLista.CurrentRow.Cells("idusuario_personal").Value
            If intComprobanteRecojo = 1 Then
                Me.CboListaUsuarios.SelectedValue = dtoUSUARIOS.IdLogin
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '***MOSTRAR VENTA CREDITO****
    Dim bSclienteConsignado As Boolean

    Sub MostrarVentaCredito(ByVal ds As DataSet)
        Try
            If GrdDetalleVenta.Rows.Count = 5 Then
                GrdDetalleVenta.Rows.RemoveAt(4)
            End If

            bDirecConsigMod = False
            bContactoModificado = False
            bDireccionModificada = False

            Me.Text = "Mantenimiento Guia de Envio"

            CboTipo.SelectedValue = 2
            CboProducto.SelectedValue = 8

            Me.iID_Persona = ds.Tables(0).Rows(0).Item("idpersona")
            CboTipoTarifa.SelectedIndex = ds.Tables(0).Rows(0).Item("idtipo_tarifa").ToString()

            Me.txtFechaGuia.Format = 2
            sFechaGuia = ds.Tables(0).Rows(0).Item("FECHA_GUIA").ToString()
            txtFechaGuia.Value = ds.Tables(0).Rows(0).Item("FECHA_GUIA").ToString()
            sFechaGuia = ds.Tables(0).Rows(0).Item("FECHA_GUIA").ToString()

            txtNroNroGuia.Text = ds.Tables(0).Rows(0).Item("NRO_GUIA").ToString.Trim

            iCiudad = ds.Tables(0).Rows(0).Item("IDUNIDAD_AGENCIA")
            CboCiudad_Origen.SelectedValue = ds.Tables(0).Rows(0).Item("IDUNIDAD_AGENCIA")

            iAgencia = ds.Tables(0).Rows(0).Item("IDAGENCIAS")
            CboAgencia_Origen.SelectedValue = ds.Tables(0).Rows(0).Item("IDAGENCIAS")

            TxtCiudadDestino.Text = ds.Tables(0).Rows(0).Item("UNIDAD_DESTINO")
            idUnidadAgencias = ds.Tables(0).Rows(0).Item("IDUNIDAD_AGENCIA_DESTINO")
            iCiudadDestino = ds.Tables(0).Rows(0).Item("IDUNIDAD_AGENCIA_DESTINO")

            ObjVentaCargaContado.fnGetAgencias(ds.Tables(0).Rows(0).Item("IDUNIDAD_AGENCIA_DESTINO"))
            Dim DtAgenciaDestino As DataTable = ObjVentaCargaContado.dt_VarAgencias.Copy
            With Me.CboAgenciaDest
                DtAgenciaDestino = ObjVentaCargaContado.dt_VarAgencias.Copy
                .DataSource = DtAgenciaDestino
                .DisplayMember = "nombre_agencia"
                .ValueMember = "idagencias"
            End With
            iIDAgenciaDestino = ds.Tables(0).Rows(0).Item("IDAGENCIAS_DESTINO")
            CboAgenciaDest.SelectedValue = ds.Tables(0).Rows(0).Item("IDAGENCIAS_DESTINO")

            iTipoEntrega = ds.Tables(0).Rows(0).Item("IDTIPO_ENTREGA_CARGA")
            CboTipoEntrega.SelectedValue = ds.Tables(0).Rows(0).Item("IDTIPO_ENTREGA_CARGA")

            '=========================================================================
            '*****DATOS CLIENTE*******************************************************
            bClienteModificado = False
            bClienteNuevo = False
            Me.TxtNroDocCliente.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NU_DOCU_SUNA")), "", ds.Tables(0).Rows(0).Item("NU_DOCU_SUNA"))
            Me.TxtNomCliente.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Razon_Social")), "", ds.Tables(0).Rows(0).Item("Razon_Social"))

            sNombresCli = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nombres")), "", ds.Tables(0).Rows(0).Item("nombres"))
            sApCli = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApePaternoCliente")), "", ds.Tables(0).Rows(0).Item("ApePaternoCliente"))
            sAmCli = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApeMaternoCliente")), "", ds.Tables(0).Rows(0).Item("ApeMaternoCliente"))
            sTelfCliente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TelefonoCliente")), "", ds.Tables(0).Rows(0).Item("TelefonoCliente"))
            sRazonSocialCliente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Razon_Social")), "", ds.Tables(0).Rows(0).Item("Razon_Social"))
            iID_TipoDocCli = ds.Tables(0).Rows(0).Item("TipoDocumentoCliente").ToString.Trim
            sEmail = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Email")), "", ds.Tables(0).Rows(0).Item("Email"))

            Dim dr As DataRow
            dtCliente = New DataTable
            dtCliente.Columns.Add(New DataColumn("idpersona", GetType(Integer)))
            dtCliente.Columns.Add(New DataColumn("razon_social", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("tipo", GetType(Integer)))
            dtCliente.Columns.Add(New DataColumn("nu_docu_suna", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("nombres", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("ap", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("am", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("telefono", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("Email", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("idtipo_facturacion", GetType(Integer)))
            dr = dtCliente.NewRow
            dr("idpersona") = ds.Tables(0).Rows(0).Item("idpersona")
            dr("razon_social") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Razon_Social")), "", ds.Tables(0).Rows(0).Item("Razon_Social"))
            dr("tipo") = iID_TipoDocCli = ds.Tables(0).Rows(0).Item("TipoDocumentoCliente").ToString.Trim
            dr("nu_docu_suna") = ds.Tables(0).Rows(0).Item("NU_DOCU_SUNA")
            dr("nombres") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nombres")), "", ds.Tables(0).Rows(0).Item("nombres"))
            dr("ap") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApePaternoCliente")), "", ds.Tables(0).Rows(0).Item("ApePaternoCliente"))
            dr("am") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApeMaternoCliente")), "", ds.Tables(0).Rows(0).Item("ApeMaternoCliente"))
            dr("telefono") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TelefonoCliente")), "", ds.Tables(0).Rows(0).Item("TelefonoCliente"))
            dr("Email") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Email")), "", ds.Tables(0).Rows(0).Item("Email"))
            dr("idtipo_facturacion") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("idtipo_facturacion")), "", ds.Tables(0).Rows(0).Item("idtipo_facturacion"))
            dtCliente.Rows.Add(dr)

            Me.TxtCliente.Text = ""
            Me.RbtDocumento.Checked = True
            Me.TxtCliente.Text = Me.TxtNroDocCliente.Text

            'BuscarClienteCredito(Me.TxtCliente.Text, 1, CboCiudad_Origen.SelectedValue, ds.Tables(0).Rows(0).Item("IDUNIDAD_AGENCIA_DESTINO"))
            '==========================================
            '****DIRECCION CLIENTE*********************

            IdDireccionOrigen = ds.Tables(0).Rows(0).Item("IDDIRECCION_REMITENTE")
            'iDepartamento = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("iddepartamento")), 0, ds.Tables(0).Rows(0).Item("iddepartamento"))
            'iProvincia = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("idprovincia")), 0, ds.Tables(0).Rows(0).Item("idprovincia"))
            'iDistrito = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("iddistrito")), 0, ds.Tables(0).Rows(0).Item("iddistrito"))
            'iId_via = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_via")), 0, ds.Tables(0).Rows(0).Item("id_via"))
            'sVia = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("via")), "", ds.Tables(0).Rows(0).Item("via"))
            'sNumero2 = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("numero")), "", ds.Tables(0).Rows(0).Item("numero"))
            'sManzana = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("manzana")), "", ds.Tables(0).Rows(0).Item("manzana"))
            'sLote = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("lote")), "", ds.Tables(0).Rows(0).Item("lote"))
            'iId_Nivel = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_nivel")), 0, ds.Tables(0).Rows(0).Item("id_nivel"))
            'sNivel = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nivel")), "", ds.Tables(0).Rows(0).Item("nivel"))
            'iId_Zona = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_zona")), 0, ds.Tables(0).Rows(0).Item("id_zona"))
            'sZona = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("zona")), "", ds.Tables(0).Rows(0).Item("zona"))
            'iId_Clasificacion = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Id_Clasificacion")), 0, ds.Tables(0).Rows(0).Item("Id_Clasificacion"))
            'sClasificacion = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Clasificacion")), "", ds.Tables(0).Rows(0).Item("Clasificacion"))

            'Me.CboDireccion.DataSource = Nothing
            'Me.CboDireccion.Items.Clear()
            'dtDireccion = New DataTable
            'dtDireccion.Columns.Add(New DataColumn("iddireccion_consignado", GetType(Integer)))
            'dtDireccion.Columns.Add(New DataColumn("direccion", GetType(String)))
            'dtDireccion.Columns.Add(New DataColumn("id_via", GetType(Integer)))
            'dtDireccion.Columns.Add(New DataColumn("via", GetType(String)))
            'dtDireccion.Columns.Add(New DataColumn("numero", GetType(String)))
            'dtDireccion.Columns.Add(New DataColumn("manzana", GetType(String)))
            'dtDireccion.Columns.Add(New DataColumn("lote", GetType(String)))
            'dtDireccion.Columns.Add(New DataColumn("id_nivel", GetType(Integer)))
            'dtDireccion.Columns.Add(New DataColumn("nivel", GetType(String)))
            'dtDireccion.Columns.Add(New DataColumn("id_zona", GetType(Integer)))
            'dtDireccion.Columns.Add(New DataColumn("zona", GetType(String)))
            'dtDireccion.Columns.Add(New DataColumn("id_clasificacion", GetType(Integer)))
            'dtDireccion.Columns.Add(New DataColumn("clasificacion", GetType(String)))
            'dtDireccion.Columns.Add(New DataColumn("iddepartamento", GetType(Integer)))
            'dtDireccion.Columns.Add(New DataColumn("idprovincia", GetType(Integer)))
            'dtDireccion.Columns.Add(New DataColumn("iddistrito", GetType(Integer)))

            'dr = dtDireccion.NewRow
            'dr("iddireccion_consignado") = 0
            'dr("direccion") = " (SELECCIONE)"
            'dr("id_via") = 0
            'dr("via") = ""
            'dr("numero") = ""
            'dr("manzana") = ""
            'dr("lote") = ""
            'dr("id_nivel") = 0
            'dr("nivel") = ""
            'dr("id_zona") = 0
            'dr("zona") = ""
            'dr("id_clasificacion") = 0
            'dr("clasificacion") = ""
            'dr("iddepartamento") = 0
            'dr("idprovincia") = 0
            'dr("iddistrito") = 0
            'dtDireccion.Rows.Add(dr)

            'If ds.Tables(0).Rows(0).Item("IDDIRECCION_REMITENTE") > 0 Then
            '    dr = dtDireccion.NewRow
            '    dr("iddireccion_consignado") = ds.Tables(0).Rows(0).Item("IDDIRECCION_REMITENTE")
            '    dr("direccion") = ds.Tables(0).Rows(0).Item("dir_Remitente")
            '    dr("id_via") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_via")), 0, ds.Tables(0).Rows(0).Item("id_via"))
            '    dr("via") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("via")), "", ds.Tables(0).Rows(0).Item("via"))
            '    dr("numero") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("numero")), "", ds.Tables(0).Rows(0).Item("numero"))
            '    dr("manzana") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("manzana")), "", ds.Tables(0).Rows(0).Item("manzana"))
            '    dr("lote") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("lote")), "", ds.Tables(0).Rows(0).Item("lote"))
            '    dr("id_nivel") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_nivel")), 0, ds.Tables(0).Rows(0).Item("id_nivel"))
            '    dr("nivel") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nivel")), "", ds.Tables(0).Rows(0).Item("nivel"))
            '    dr("id_zona") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_zona")), 0, ds.Tables(0).Rows(0).Item("id_zona"))
            '    dr("zona") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("zona")), "", ds.Tables(0).Rows(0).Item("zona"))
            '    dr("id_clasificacion") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Id_Clasificacion")), 0, ds.Tables(0).Rows(0).Item("Id_Clasificacion"))
            '    dr("clasificacion") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Clasificacion")), "", ds.Tables(0).Rows(0).Item("Clasificacion"))
            '    dr("iddepartamento") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("iddepartamento")), 0, ds.Tables(0).Rows(0).Item("iddepartamento"))
            '    dr("idprovincia") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("idprovincia")), 0, ds.Tables(0).Rows(0).Item("idprovincia"))
            '    dr("iddistrito") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("iddistrito")), 0, ds.Tables(0).Rows(0).Item("iddistrito"))
            '    dtDireccion.Rows.Add(dr)
            'End If
            ''-----
            'Me.CboDireccion.DataSource = dtDireccion
            'CboDireccion.DisplayMember = "direccion"
            'CboDireccion.ValueMember = "iddireccion_consignado"
            'Me.CboDireccion.SelectedValue = ds.Tables(0).Rows(0).Item("IDDIRECCION_REMITENTE")

            '==============================================================================
            '*********DATOS REMITENTE******************************************************
            'Remitente            
            bRemitenteModificado = False
            sNroDocRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NroDocumentoRemitente")), "", ds.Tables(0).Rows(0).Item("NroDocumentoRemitente"))
            iID_TipoDocRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TipoDocumentoRemitente")), "", ds.Tables(0).Rows(0).Item("TipoDocumentoRemitente"))
            sNombreRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombreRemitente")), "", ds.Tables(0).Rows(0).Item("NombreRemitente"))
            sApRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApellPaternoRemitente")), "", ds.Tables(0).Rows(0).Item("ApellPaternoRemitente"))
            sAmRemitente = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApellMaternoRemitente")), "", ds.Tables(0).Rows(0).Item("ApellMaternoRemitente"))
            '--------

            Me.TxtNumDocRemitente.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NroDocumentoRemitente")), "", ds.Tables(0).Rows(0).Item("NroDocumentoRemitente"))
            Me.idRemitente = ds.Tables(0).Rows(0).Item("ID_REMITENTE")
            dtRemitente = New DataTable
            dtRemitente.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
            dtRemitente.Columns.Add(New DataColumn("nombres", GetType(String)))
            dtRemitente.Columns.Add(New DataColumn("nombre", GetType(String))) 'new
            dtRemitente.Columns.Add(New DataColumn("idtipo_documento_contacto", GetType(Integer)))
            dtRemitente.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
            dtRemitente.Columns.Add(New DataColumn("apepat", GetType(String)))
            dtRemitente.Columns.Add(New DataColumn("apemat", GetType(String)))

            dr = dtRemitente.NewRow
            dr("idcontacto_persona") = 0
            dr("nombres") = " (SELECCIONE)"
            dr("idtipo_documento_contacto") = 0
            dr("nrodocumento") = ""
            dtRemitente.Rows.Add(dr)


            If ds.Tables(0).Rows(0).Item("ID_REMITENTE") > 0 Then
                dr = dtRemitente.NewRow
                dr("idcontacto_persona") = ds.Tables(0).Rows(0).Item("ID_REMITENTE")
                dr("nombres") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombresRemitente")), "", ds.Tables(0).Rows(0).Item("NombresRemitente"))
                dr("nombre") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombreRemitente")), "", ds.Tables(0).Rows(0).Item("NombreRemitente"))
                dr("idtipo_documento_contacto") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TipoDocumentoRemitente")), 9, ds.Tables(0).Rows(0).Item("TipoDocumentoRemitente"))
                dr("nrodocumento") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NroDocumentoRemitente")), "", ds.Tables(0).Rows(0).Item("NroDocumentoRemitente"))
                dr("apepat") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApellPaternoRemitente")), "", ds.Tables(0).Rows(0).Item("ApellPaternoRemitente"))
                dr("apemat") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApellMaternoRemitente")), "", ds.Tables(0).Rows(0).Item("ApellMaternoRemitente"))
                dtRemitente.Rows.Add(dr)
            End If

            Me.CboRemitente.DataSource = dtRemitente
            CboRemitente.DisplayMember = "nombres"
            CboRemitente.ValueMember = "idcontacto_persona"
            Me.CboRemitente.SelectedValue = ds.Tables(0).Rows(0).Item("ID_REMITENTE")
            dtRemitenteParalelo = dtRemitente.Copy

            RemoveHandler ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged
            Me.ChkCliente.Checked = False
            If Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso Me.TxtNroDocCliente.Text.Trim = Me.TxtNumDocRemitente.Text.Trim Then
                Me.ChkCliente.Checked = True
            End If
            AddHandler ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged
            If Me.idRemitente = 0 Then
                Me.ChkCliente.Checked = True
            End If

            '=============================================================================
            '*********DATOS CONTACTO******************************************************
            bContactoModificado = False

            Me.TxtNroDocContacto.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NroDocumentoContacto")), "", ds.Tables(0).Rows(0).Item("NroDocumentoContacto"))
            Me.idcontacto = ds.Tables(0).Rows(0).Item("idcontacto")
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

            If ds.Tables(0).Rows(0).Item("idcontacto") > 0 Then
                dr = dtContacto.NewRow
                dr("idcontacto_persona") = ds.Tables(0).Rows(0).Item("idcontacto")
                dr("nombres") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombresContacto")), "", ds.Tables(0).Rows(0).Item("NombresContacto"))
                dr("nombre") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombreContacto")), "", ds.Tables(0).Rows(0).Item("NombreContacto"))
                dr("idtipo_documento_contacto") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TipoDocumentoContacto")), 9, ds.Tables(0).Rows(0).Item("TipoDocumentoContacto"))
                dr("nrodocumento") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NroDocumentoContacto")), "", ds.Tables(0).Rows(0).Item("NroDocumentoContacto"))
                dr("apepat") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApellPaternoContacto")), "", ds.Tables(0).Rows(0).Item("ApellPaternoContacto"))
                dr("apemat") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApellMaternoContacto")), "", ds.Tables(0).Rows(0).Item("ApellMaternoContacto"))
                dtContacto.Rows.Add(dr)
            End If

            Me.CboContacto.DataSource = dtContacto
            CboContacto.DisplayMember = "nombres"
            CboContacto.ValueMember = "idcontacto_persona"
            Me.CboContacto.SelectedValue = ds.Tables(0).Rows(0).Item("idcontacto")
            dtContactoParalelo = dtContacto.Copy

            RemoveHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
            Me.ChkCliente1.Checked = False
            If (Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso Me.TxtNroDocCliente.Text.Trim = Me.TxtNroDocContacto.Text.Trim) Then
                Me.ChkCliente1.Checked = True
            End If
            AddHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged

            If Me.idcontacto = 0 Then
                Me.ChkCliente1.Checked = True
            End If

            '=====================================
            '****SUBCUENTA DESTINO************************
            Me.iIDSubcuenta = ds.Tables(0).Rows(0).Item("IDCENTRO_COSTO")
            With Me.CboSubCuenta
                DtSubcuenta = ds.Tables(4).Copy
                .DataSource = DtSubcuenta
                .DisplayMember = "CENTRO_COSTO"
                .ValueMember = "IDCENTRO_COSTO"
                .SelectedValue = ds.Tables(0).Rows(0).Item("IDCENTRO_COSTO")
            End With

            '****SUBCUENTA ORIGEN************************
            Me.iIDSubcuentaOrigen = ds.Tables(0).Rows(0).Item("IDCENTRO_COSTO_ORIGEN")
            With Me.CboSubCuentaOrigen
                DtSubcuentaOrigen = ds.Tables(6).Copy
                .DataSource = DtSubcuentaOrigen
                .DisplayMember = "CENTRO_COSTO"
                .ValueMember = "IDCENTRO_COSTO"
                .SelectedValue = ds.Tables(0).Rows(0).Item("IDCENTRO_COSTO_ORIGEN")
            End With
            Me.CboSubCuentaOrigen.Enabled = True
            '======================================
            '*******DATOS CONSIGNADO***************
            GrdNConsignado.Rows.Clear()
            If ds.Tables(5).Rows.Count > 0 Then
                bSclienteConsignado = False
                ChkCliente2.Checked = False
                For Each fila As DataRow In ds.Tables(5).Rows
                    Dim row0 As String() = {fila.Item("IDConsignado"), fila.Item("NroDocumento"), fila.Item("Nombres").ToString, _
                                            fila.Item("Telefono").ToString, _
                                            fila.Item("Nombre"), fila.Item("IDTipoDocDocumento"), _
                                            fila.Item("apepat"), fila.Item("apemat"), 0, fila.Item("IDVentaConsignado")
                                           }
                    GrdNConsignado.Rows().Add(row0)
                Next

                If ds.Tables(5).Rows.Count = 1 AndAlso Me.TxtNroDocCliente.Text.Trim = GrdNConsignado("Nº Documento", 0).Value.Trim And Me.TxtNroDocCliente.Text.Trim.Length > 0 Then
                    bSclienteConsignado = True
                    ChkCliente2.Checked = True
                End If
            Else
                GrdNConsignado.Rows.Add()
                GrdNConsignado("IDConsignado", 0).Value = ds.Tables(0).Rows(0).Item("idcontacto_destinatario")
                GrdNConsignado("Nº Documento", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NroDocumentoConsignado")), "", ds.Tables(0).Rows(0).Item("NroDocumentoConsignado"))
                GrdNConsignado("Nombres", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombresConsignado")), "", ds.Tables(0).Rows(0).Item("NombresConsignado"))
                GrdNConsignado("Telefono", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TelefonoConsignado")), "", ds.Tables(0).Rows(0).Item("TelefonoConsignado"))
                GrdNConsignado("nombre", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombreConsignado")), "", ds.Tables(0).Rows(0).Item("NombreConsignado"))
                GrdNConsignado("tipo", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TipoDocumentoConsignado")), 9, ds.Tables(0).Rows(0).Item("TipoDocumentoConsignado"))
                GrdNConsignado("apepat", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApellidoPaternoConsig")), "", ds.Tables(0).Rows(0).Item("ApellidoPaternoConsig"))
                GrdNConsignado("apemat", 0).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApellidoMaternoConsig")), "", ds.Tables(0).Rows(0).Item("ApellidoMaternoConsig"))

                If Me.TxtNroDocCliente.Text.Trim = GrdNConsignado("Nº Documento", 0).Value.Trim And Me.TxtNroDocCliente.Text.Trim.Length > 0 Then
                    bSclienteConsignado = True
                    ChkCliente2.Checked = True
                Else
                    bSclienteConsignado = False
                    ChkCliente2.Checked = False
                    If GrdNConsignado("IDConsignado", 0).Value = 0 Then
                        GrdNConsignado.Rows.Clear()
                    End If
                End If
            End If

            '===================================================
            '*********DATOS DIRECCION CONSIGNADO****************
            'Me.BuscarConsignado(ds.Tables(0).Rows(0).Item("IDCONTACTO_DESTINATARIO"))
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


            Me.idDireConsignado = ds.Tables(0).Rows(0).Item("IDDIRECCION_DESTINATARIO")
            dr = dtDireccion2.NewRow
            dr("iddireccion_consignado") = ds.Tables(0).Rows(0).Item("IDDIRECCION_DESTINATARIO")
            dr("direccion") = ds.Tables(0).Rows(0).Item("dir_Destinatario")
            dr("id_via") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_viaDest")), 0, ds.Tables(0).Rows(0).Item("id_viaDest"))
            dr("via") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("viaDest")), "", ds.Tables(0).Rows(0).Item("viaDest"))
            dr("numero") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("numeroDest")), "", ds.Tables(0).Rows(0).Item("numeroDest"))
            dr("manzana") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("manzanaDest")), "", ds.Tables(0).Rows(0).Item("manzanaDest"))
            dr("lote") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("loteDest")), "", ds.Tables(0).Rows(0).Item("loteDest"))
            dr("id_nivel") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_nivelDest")), 0, ds.Tables(0).Rows(0).Item("id_nivelDest"))
            dr("nivel") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nivelDest")), "", ds.Tables(0).Rows(0).Item("nivelDest"))
            dr("id_zona") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("id_zonaDest")), 0, ds.Tables(0).Rows(0).Item("id_zonaDest"))
            dr("zona") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("zonaDest")), "", ds.Tables(0).Rows(0).Item("zonaDest"))
            dr("id_clasificacion") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Id_ClasificacionDest")), 0, ds.Tables(0).Rows(0).Item("Id_ClasificacionDest"))
            dr("clasificacion") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ClasificacionDest")), "", ds.Tables(0).Rows(0).Item("ClasificacionDest"))
            dr("iddepartamento") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("iddepartamentoDest")), 0, ds.Tables(0).Rows(0).Item("iddepartamentoDest"))
            dr("idprovincia") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("idprovinciaDest")), 0, ds.Tables(0).Rows(0).Item("idprovinciaDest"))
            dr("iddistrito") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("iddistritoDest")), 0, ds.Tables(0).Rows(0).Item("iddistritoDest"))
            dr("de_referencia") = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("de_referencia")), "", ds.Tables(0).Rows(0).Item("de_referencia"))
            dtDireccion2.Rows.Add(dr)
            Me.CboDireccion2.DataSource = dtDireccion2
            CboDireccion2.DisplayMember = "direccion"
            CboDireccion2.ValueMember = "iddireccion_consignado"

            Me.CboDireccion2.SelectedValue = ds.Tables(0).Rows(0).Item("IDDIRECCION_DESTINATARIO")
            Me.TxtReferencia.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("De_Referencia")), "", ds.Tables(0).Rows(0).Item("De_Referencia"))


            '============================================
            '=======DATOS DETALLE VENTA==================    
            Dim bVentaNormal As Boolean
            Dim bVentaVolumetrico As Boolean = IIf(ds.Tables(0).Rows(0).Item("METRO_CUBICO") = 1, 1, 0)
            Dim bVentaArticulos As Boolean = IIf(ds.Tables(0).Rows(0).Item("Cantidad_x_Unidad_Arti") > 0, 1, 0)
            If Not bVentaVolumetrico And Not bVentaArticulos Then bVentaNormal = 1 Else bVentaNormal = 0

            '***RECUPERANDO VENTA NORMAL****
            If bVentaNormal Then
                TipoGrid_ = FormatoGrid.BULTO '--------------> Grid Volumetrico
                Me.DiseñaGrdDetalleVenta() '-------> Diseña GridDetalleVenta
                FormatoGrdDetalleVenta() '---------> Formato al grid   

                '**FILA PESO**
                GrdDetalleVenta("Bulto", 0).Value() = IIf(ds.Tables(0).Rows(0).Item("CANTIDAD") = 0, "", ds.Tables(0).Rows(0).Item("CANTIDAD"))
                GrdDetalleVenta("Peso/Volumen", 0).Value() = ds.Tables(0).Rows(0).Item("TOTAL_PESO")
                GrdDetalleVenta("Costo", 0).Value() = ds.Tables(0).Rows(0).Item("PRECIO_X_PESO")
                GrdDetalleVenta("Sub Neto", 0).Value() = ds.Tables(0).Rows(0).Item("TOTAL_PESO") * ds.Tables(0).Rows(0).Item("PRECIO_X_PESO")
                tarifa_Peso = ds.Tables(0).Rows(0).Item("PRECIO_X_PESO")

                '**FILA VOLUMEN**
                GrdDetalleVenta("Bulto", 1).Value() = IIf(ds.Tables(0).Rows(0).Item("CANTIDAD_X_UNIDAD_VOLUMEN") = 0, "", ds.Tables(0).Rows(0).Item("CANTIDAD_X_UNIDAD_VOLUMEN"))
                GrdDetalleVenta("Peso/Volumen", 1).Value() = ds.Tables(0).Rows(0).Item("TOTAL_VOLUMEN")
                GrdDetalleVenta("Costo", 1).Value() = ds.Tables(0).Rows(0).Item("PRECIO_X_VOLUMEN")
                GrdDetalleVenta("Sub Neto", 1).Value() = ds.Tables(0).Rows(0).Item("TOTAL_VOLUMEN") * ds.Tables(0).Rows(0).Item("PRECIO_X_VOLUMEN")
                tarifa_Volumen = ds.Tables(0).Rows(0).Item("PRECIO_X_VOLUMEN")

                'FILA SOBRE
                GrdDetalleVenta("Bulto", 2).Value() = IIf(ds.Tables(0).Rows(0).Item("CANTIDAD_SOBRES") = 0, "", ds.Tables(0).Rows(0).Item("CANTIDAD_SOBRES"))
                GrdDetalleVenta("Peso/Volumen", 2).Value() = "0.00"
                GrdDetalleVenta("Costo", 2).Value() = ds.Tables(0).Rows(0).Item("PRECIO_SOBRE")
                tarifa_Sobre = ds.Tables(0).Rows(0).Item("PRECIO_SOBRE")
                GrdDetalleVenta("Sub Neto", 2).Value() = ds.Tables(0).Rows(0).Item("CANTIDAD_SOBRES") * ds.Tables(0).Rows(0).Item("PRECIO_SOBRE")
                'FILA BASE
                GrdDetalleVenta("Costo", 3).Value() = ds.Tables(0).Rows(0).Item("MONTO_BASE")
                Monto_Base = ds.Tables(0).Rows(0).Item("MONTO_BASE")
                GrdDetalleVenta("Sub Neto", 3).Value() = Format(ds.Tables(0).Rows(0).Item("MONTO_BASE"), "###,###.00")
            End If

            '******RECUPERANDO VOLUMETRICO****
            If bVentaVolumetrico Then
                TipoGrid_ = FormatoGrid.VOLUMETRICO '--------> Grid Volumetrico
                Me.DiseñaGrdDetalleVenta() '-----------------> Diseña GridDetalleVenta                             
                'TxtMontoBase.Text = ds.Tables(1).Rows(0).Item("Monto_Base")
                RemoveHandler ChkM3.CheckedChanged, AddressOf ChkM3_CheckedChanged
                ChkM3.Checked = True
                AddHandler ChkM3.CheckedChanged, AddressOf ChkM3_CheckedChanged

                If ds.Tables(1).Rows.Count > 0 Then
                    fArticulo = True
                    For Each fila As DataRow In ds.Tables(1).Rows
                        Dim row0 As String() = {fila.Item("ITEM"), fila.Item("CANTIDAD"), FormatNumber(fila.Item("ALTURA"), 2), _
                                                FormatNumber(fila.Item("ANCHO"), 2), FormatNumber(fila.Item("LARGO"), 2), _
                                                FormatNumber(fila.Item("PESO_KG"), 2), FormatNumber(fila.Item("PRECIO_COSTO"), 2), _
                                                FormatNumber(fila.Item("PESO_KG"), 2) * FormatNumber(fila.Item("PRECIO_COSTO"), 2)
                                                }
                        GrdDetalleVenta.Rows().Add(row0)
                    Next
                End If

                tarifa_Peso = ds.Tables(0).Rows(0).Item("Precio_x_Peso")
                'tarifa_Sobre = ds.Tables(0).Rows(0).Item("Precio_x_Sobre")
                '------------------------------
                ChkSobres.Visible = True
                txtCantidadSobres.Visible = True
                txtTotalSobre.Visible = True
                LblMontoBase.Visible = True
                TxtMontoBase.Visible = True
                GrpDescuento.Enabled = True
            Else
                RemoveHandler ChkM3.CheckedChanged, AddressOf ChkM3_CheckedChanged
                ChkM3.Checked = False
                AddHandler ChkM3.CheckedChanged, AddressOf ChkM3_CheckedChanged
            End If




            '******RECUPERANDO ARTICULOS***********************************            
            If bVentaArticulos Then
                TipoGrid_ = FormatoGrid.ARTICULOS : LbldetalleVenta.Text = "Articulos"
                Me.DiseñaGrdDetalleVenta()
                GrpDescuento.Enabled = False
                RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
                ChkArticulos.Checked = True
                AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged

                LblMontoBase.Visible = True
                TxtMontoBase.Visible = True
                ChkSobres.Visible = True
                txtCantidadSobres.Visible = True
                txtTotalSobre.Visible = True
                '--        
                If ds.Tables(3).Rows.Count > 0 Then
                    fArticulo = True
                    For Each fila As DataRow In ds.Tables(3).Rows
                        Dim row0 As String() = {fila.Item("Nombre_Articulo"), FormatNumber(fila.Item("Precio_Final").ToString, 2), fila.Item("Cantidad_Articulos").ToString, _
                                                fila.Item(4).ToString, fila.Item(6).ToString, _
                                                (fila.Item(2)) * IIf(IsDBNull(fila.Item(3)), "0", fila.Item(3)), fila.Item(0).ToString(), fila.Item("idGuiaArticulo").ToString()
                                               }
                        GrdDetalleVenta.Rows().Add(row0)
                    Next
                End If
                '--
            Else
                RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
                ChkArticulos.Checked = False
                LblMontoBase.Visible = False
                TxtMontoBase.Visible = False
                ChkSobres.Visible = False
                txtCantidadSobres.Visible = False
                txtTotalSobre.Visible = False
                AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
            End If

            If ds.Tables(0).Rows(0).Item("cargo") = 1 Then
                chkDocumentoCliente.Checked = True
                Me.rbtCargoSi.Checked = True
                Me.rbtCargoNo.Checked = False
            Else
                chkDocumentoCliente.Checked = False
                Me.rbtCargoSi.Checked = False
                Me.rbtCargoNo.Checked = True
            End If

            '******RECUPERANDO DOCUMENTOS CLIENTE**************************
            strNroGuias_Remision = ""
            Dim iContador As Integer = 0
            If ds.Tables(2).Rows.Count > 0 Then
                Dim i As Integer = 0
                For i = 1 To GrdDocumentosCliente.Rows().Count - 1
                    GrdDocumentosCliente.Rows().RemoveAt(0)
                Next

                Dim idDoc1 As String = ""
                Dim NroDoc1 As String = ""
                Dim idDoc0 As String
                Dim NroDoc0 As String
                '
                Dim lb_par_activo As Boolean = False
                For Each fila As DataRow In ds.Tables(2).Rows
                    iContador += 1
                    idDoc1 = ""
                    NroDoc1 = ""
                    idDoc0 = fila.Item(0)
                    NroDoc0 = fila.Item(1)
                    Dim row0 As String() = {idDoc0, idDoc1, NroDoc0, NroDoc1}
                    GrdDocumentosCliente.Rows().Add(row0)
                    strNroGuias_Remision = strNroGuias_Remision & NroDoc0 & ","
                    idDoc0 = ""
                    NroDoc0 = ""
                Next
                If iContador > 0 Then
                    strNroGuias_Remision = strNroGuias_Remision.Substring(0, strNroGuias_Remision.Trim.Length - 1)
                End If
            Else
                GrdDocumentosCliente.Rows.Clear()
                Dim row11 As String() = {"", " ", " ", ""}
                GrdDocumentosCliente.Rows().Add(row11)
                GrdDocumentosCliente.Rows().Add(row11)
                GrdDocumentosCliente.Rows().Add(row11)
            End If

            'If Me.CboTipo.SelectedIndex = 0 Then
            '    ID_PERSONA_QUIMICA_SUIZA = -10
            'Else
            '    ID_PERSONA_QUIMICA_SUIZA = 1290
            'End If
            'txtdt.Clear()
            'lbldt.Visible = (iID_Persona = ID_PERSONA_QUIMICA_SUIZA And CboCiudad_Origen.SelectedValue = 5100)
            'txtdt.Visible = (iID_Persona = ID_PERSONA_QUIMICA_SUIZA And CboCiudad_Origen.SelectedValue = 5100)
            'TxtTelfCliente.Size = IIf(iID_Persona = ID_PERSONA_QUIMICA_SUIZA, New Size(120, 20), New Size(329, 20))
            'IIf(iID_Persona = ID_PERSONA_QUIMICA_SUIZA, txtdt.Focus, TxtConsignado.Focus)
            'If iID_Persona = ID_PERSONA_QUIMICA_SUIZA And CboCiudad_Origen.SelectedValue = 5100 Then
            '    Me.txtdt.Text = ds.Tables(0).Rows(0).Item("dt").ToString.Trim
            'End If

            'hlamas 07-02-2019
            If Me.CboTipo.SelectedIndex = 0 Then
                ID_PERSONA_CBC = -10
            Else
                ID_PERSONA_CBC = 2153948
            End If

            txtdt.Clear()
            lblDT.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
            txtdt.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
            Me.dtpFechaRecojo.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
            TxtTelfCliente.Size = IIf(iID_Persona = ID_PERSONA_CBC, New Size(86, 20), New Size(329, 20))
            IIf(iID_Persona = ID_PERSONA_CBC, txtdt.Focus, TxtConsignado.Focus)

            'Recuperando el [SUB_TOTAL]**********
            TxtSubTotal.Text = Format(ds.Tables(0).Rows(0).Item("TOTAL_COSTO") - ds.Tables(0).Rows(0).Item("MONTO_IMPUESTO"), "###,###,###.00")
            'Recuperando el [IGV(IMPUESTO)]******
            TxtImpuesto.Text = Format(ds.Tables(0).Rows(0).Item("MONTO_IMPUESTO"), "###,###,###.00")
            'Recuperando el [TOTAL]**************
            TxtTotal.Text = Format(ds.Tables(0).Rows(0).Item("TOTAL_COSTO"), "###,###,###.00")

            ObjVentaCargaContado.fnGetAgencias(CboCiudad_Origen.SelectedValue)
            Dim dt As New DataTable
            dt = ObjVentaCargaContado.dt_VarAgencias.Copy
            With CboAgencia_Origen
                .DataSource = dt
                .DisplayMember = "nombre_agencia"
                .ValueMember = "idagencias"
                .SelectedValue = Me.DgvLista.CurrentRow.Cells("idagencias").Value
            End With
            Me.ListarUsuarios(CboCiudad_Origen.SelectedValue)

            'If iOpcion = 2 Then
            'Me.CboListaUsuarios.SelectedValue = Me.DgvLista.CurrentRow.Cells("idusuario_personal").Value
            'Else
            'Me.CboListaUsuarios.SelectedValue = dtoUSUARIOS.IdLogin
            'End If
            Me.CboListaUsuarios.SelectedValue = Me.DgvLista.CurrentRow.Cells("idusuario_personal").Value
            If intComprobanteRecojo = 1 Then
                Me.CboListaUsuarios.SelectedValue = dtoUSUARIOS.IdLogin
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

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

#Region "Btn Imprimir"
    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Dim sGuia As String = Me.DgvLista.CurrentRow.Cells("guia").Value
            Dim iGuia As Integer = Me.DgvLista.CurrentRow.Cells("IdFactura").Value
            Dim iTipo As Integer = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value

            imprime(iTipo, iGuia)
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Btn Ticket"
    Private Sub BtnTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTicket.Click
        Try
            Dim objEtiqueta As New dtoGuiaEnvio
            Dim ll_idusuario_tmp As Long
            ObjVentaCargaContado.V_CONTROL_PCE = False
            Dim row As Integer = DgvLista.SelectedRows.Item(0).Index

            'If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.No Then Exit Sub

            Dim v_idFacura As Integer = DgvLista.Rows(row).Cells("IdFactura").Value
            'Verifica si documento para el cual se reimprimiran etiquetas ya ha sido impreso
            Dim iDoc As Integer
            Dim sDoc As String
            Dim iControl As Integer
            If DgvLista.Rows(row).Cells("idtipo_comprobante").Value = 3 Then
                iDoc = 3
                iControl = 3
                sDoc = "GE"
            Else
                iDoc = 85
                iControl = 2
                sDoc = "PCE"
            End If
            If objEtiqueta.fnEtiquetaImpresa(iDoc, v_idFacura) Then
                If objEtiqueta.dt_cur_etiqueta.Rows(0)(0) = 1 Then
                    'Obtener usuario y password de usuario que reimprime
                    ll_idusuario_tmp = dtoUSUARIOS.IdLogin
                    Dim lfrmusuario_entrega As New frmUsuarioEtiqueta
                    lfrmusuario_entrega.Lab_tip_dcto.Text = sDoc '24/10/2008
                    lfrmusuario_entrega.txt_dcto.Text = DgvLista.Rows(row).Cells("guia").Value '24/10/2008
                    lfrmusuario_entrega.txt_origen.Text = DgvLista.Rows(row).Cells("origen").Value
                    lfrmusuario_entrega.txt_destino.Text = DgvLista.Rows(row).Cells("destino").Value

                    lfrmusuario_entrega.txtLogin.Text = dtoUSUARIOS.iLOGIN
                    lfrmusuario_entrega.txtPasswor.Focus()

                    'lfrmusuario_entrega.ShowDialog()
                    Acceso.Asignar(lfrmusuario_entrega, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        lfrmusuario_entrega.ShowDialog()
                    Else
                        MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                    If lfrmusuario_entrega.pb_cancelar = True Then
                        Exit Sub ' No hace nada 
                    End If
                    'dtoUSUARIOS.IdLogin = lfrmusuario_entrega.pl_idusuario_personal
                    ll_idusuario_tmp = lfrmusuario_entrega.pl_idusuario_personal
                End If
            End If

            'Genera etiquetas
            Dim sMotivo As String
            Dim sEtiqueta As String
            Dim ll_total As Long
            '
            ll_total = DgvLista.Rows(row).Cells("cantidad").Value
            '
            If objEtiqueta.dt_cur_etiqueta.Rows(0)(0) = 1 Then
                Dim a As New FrmRangoEtiquetas()
                a.total_bultos = ll_total
                'a.ShowDialog()
                'Acceso.Asignar(a, Me.hnd)
                'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                a.ShowDialog()
                If a.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                sMotivo = a.txtMotivo.Text
                sEtiqueta = a.NumeUDini.Value
                'bRango = False
                iRango = 2
                'Else
                'MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Return
                'End If
            Else
                Dim a As New FrmRangoEtiquetas2()
                a.total_bultos = ll_total
                '
                'a.ShowDialog()
                'Acceso.Asignar(a, Me.hnd)
                'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                a.ShowDialog()
                If a.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                'bRango = True
                'iRango = 1
                'Else
                'MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Return
                'End If
            End If

            If correlativo_inicial = -1 Then Exit Sub

            'If ObjVentaCargaContado.fnREIMPRESIONCODIGOS(1, v_idFacura) = True Then
            ObjVentaCargaContado.UsuarioEtiqueta = ll_idusuario_tmp 'dtoUSUARIOS.IdLogin
            If ObjVentaCargaContado.fnREIMPRESIONCODIGOSII(iControl, v_idFacura, correlativo_inicial, correlativo_final) = True Then
                'If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then
                '''''''''
                'hlamas 26/08/2009
                'Obtiene Fecha y Hora
                ObjVentaCargaContado.fnFechaRegistro(iDoc, v_idFacura)
                sFecha = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(0)
                sHora = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(1)


                If xIMPRESORA = 1 Or xIMPRESORA = 4 Then
                    fnImprimirEtiquetasN95()
                Else
                    If xIMPRESORA = 2 Then
                        fnImprimirEtiquetasFAC_IIN95()
                    Else
                        fnImprimirEtiquetasFAC_IIN97()
                    End If

                    If objEtiqueta.dt_cur_etiqueta.Rows(0)(0) = 1 Then
                        'Actualiza auditoria de reimpresion de etiquetas
                        Dim objReimpresionEtiquetas As New dtoGuiaEnvio
                        If objReimpresionEtiquetas.fnActualizaReimpresion(iDoc, v_idFacura, ObjCODIGOBARRA.CodigoBarra, sMotivo, CDate(ObjCODIGOBARRA.Fecha), ll_idusuario_tmp, ObjCODIGOBARRA.fnGetHora, sEtiqueta) Then
                        End If
                    Else
                        ObjCODIGOBARRA.tipo = iDoc
                        ObjCODIGOBARRA.id = v_idFacura
                        ObjCODIGOBARRA.sp_etiqueta_generada()
                    End If

                End If
                'End If
            Else
                MsgBox("No puede cargar esta data, faltan datos...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If

            If objEtiqueta.dt_cur_etiqueta.Rows(0)(0) = 1 Then
                'dtoUSUARIOS.IdLogin = ll_idusuario_tmp
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
#End Region

#Region "Btn Exportar"
    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            fnEXCELGrid(Me.DgvLista)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region


#Region "Btn Anular"

    Private Sub BtnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        Try
            Dim sGuia As String = Me.DgvLista.CurrentRow.Cells("guia").Value
            Dim iGuia As Integer = Me.DgvLista.CurrentRow.Cells("IdFactura").Value
            Dim iTipo As Integer = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            Dim iEstado As Integer = Me.DgvLista.CurrentRow.Cells("Idestado_Factura").Value
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de anular la Guía Nº " & sGuia & "?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.AppStarting
                Dim iOpcion As Integer = 0
                If Acceso.SiRol(G_Rol, Me, 1) Then
                    iOpcion = 1
                End If
                If iTipo = 85 Then
                    Anular(iGuia, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IdRol, dtoUSUARIOS.IP, iOpcion)
                Else
                    Anular(iEstado, iGuia, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IdRol, dtoUSUARIOS.IP, iOpcion)
                End If
                Me.Cursor = Cursors.Default
                MessageBox.Show("La Guía Nº " & sGuia & " ha sido Anulada.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BtnBuscar_Click(sender, e)
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'CambioR 10112011---
    Sub FormatoColorDgvLista()
        For i As Integer = 0 To Me.DgvLista.RowCount - 1
            If DgvLista.Rows(i).Cells("Idestado_Factura").Value = 2 Then
                DgvLista.Rows(i).DefaultCellStyle.BackColor = Color.Red
                DgvLista.Rows(i).DefaultCellStyle.ForeColor = Color.White
                'DgvLista.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(255, 0, 0)
            End If
        Next
    End Sub

#End Region


#Region "Btn Salir"
    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
#End Region

#End Region



#End Region

#Region "VENTA CREDITO"

#Region "Diseñador Grid"

    '*********Diseñando el grid GrdDetalleVenta**************************
    Sub DiseñaGrdDetalleVenta()
        Try
            Dim Camp1 As String = "", camp2 = "", camp3 = "", camp4 = "", camp5 = "", camp6 = "", camp7 = "", camp8 = ""

            If TipoGrid_ = FormatoGrid.BULTO Then
                Camp1 = "Tipo" : camp2 = "Bulto" : camp3 = "Peso/Volumen"
                camp4 = "Costo" : camp5 = "Sub Neto"
            ElseIf TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue <> 2 Then
                Camp1 = "Articulos" : camp2 = "Precio" : camp3 = "Cantidad"
                camp4 = "Peso" : camp5 = "P.Total" : camp6 = "IDARTICULO" : camp7 = "idGuiaArticulo" 'MARI
            ElseIf TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue = 2 Then
                Camp1 = "Articulos" : camp2 = "Precio" : camp3 = "Cantidad"
                'hlamas 11-03-2019
                camp4 = "M3" : camp5 = "Peso" : camp6 = "P.Total" : camp7 = "IDARTICULO" : camp8 = "idGuiaArticulo"
                'camp4 = "Peso" : camp5 = "P.Total" : camp6 = "IDARTICULO" : camp7 = "idGuiaArticulo"
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
                .RowHeadersWidth = 20
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Both
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
                '.DefaultCellStyle.SelectionForeColor = Color.Black

                Dim col1 As New DataGridViewTextBoxColumn
                With col1
                    .HeaderText = Camp1
                    .Name = Camp1
                    .DataPropertyName = Camp1
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill 'm
                    If TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .Width = 100
                    ElseIf TipoGrid_ = FormatoGrid.ARTICULOS Then
                        ' .Width = 100
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Else
                        .Width = 100
                    End If
                    ' .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    .Visible = True
                End With
                GrdDetalleVenta.Columns.Add(col1)

                Dim col2 As New DataGridViewTextBoxColumn
                With col2
                    .HeaderText = camp2
                    .Name = camp2
                    .DataPropertyName = camp2
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill 'm
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    If TipoGrid_ = FormatoGrid.BULTO Or TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .ReadOnly = False
                        .MaxInputLength = 5
                    ElseIf TipoGrid_ = FormatoGrid.ARTICULOS Then
                        .ReadOnly = True
                        .Width = 40
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
                        .Width = 90
                    Else
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .MaxInputLength = 5
                    End If
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
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill 'm
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    If TipoGrid_ = FormatoGrid.BULTO Then
                        .ReadOnly = True
                        .DefaultCellStyle.Format = "0.00"
                    ElseIf TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .ReadOnly = False
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 9
                    ElseIf TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue <> 2 Then
                        .ReadOnly = False
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 5
                        .Width = 35
                    ElseIf TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue = 2 Then
                        .ReadOnly = False
                        .Visible = False
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 5
                        .Width = 35
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
                    If TipoGrid_ = FormatoGrid.VOLUMETRICO Or CboTipo.SelectedValue = 2 Then
                        .ReadOnly = False
                        .MaxInputLength = 9
                    End If

                    If TipoGrid_ = FormatoGrid.BULTO Then
                        .ReadOnly = True
                        .MaxInputLength = 9
                    End If
                End With
                GrdDetalleVenta.Columns.Add(col5)

                If TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue = 2 Then
                    Dim col6 As New DataGridViewTextBoxColumn
                    With col6
                        .HeaderText = camp6
                        .Name = camp6
                        .DataPropertyName = camp6
                        ' .DefaultCellStyle.Format = "0.00"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .Visible = True
                        .ReadOnly = True
                    End With
                    GrdDetalleVenta.Columns.Add(col6)

                    Dim col7 As New DataGridViewTextBoxColumn
                    With col7
                        .HeaderText = camp7
                        .Name = camp7
                        .DataPropertyName = camp7
                        ' .DefaultCellStyle.Format = "0.00"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .Visible = False
                    End With
                    GrdDetalleVenta.Columns.Add(col7)

                    Dim col8 As New DataGridViewTextBoxColumn
                    With col8
                        .HeaderText = camp8
                        .Name = camp8
                        .DataPropertyName = camp8
                        ' .DefaultCellStyle.Format = "0.00"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .Visible = False
                    End With
                    GrdDetalleVenta.Columns.Add(col8)

                ElseIf TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue <> 2 Then
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



                    Dim col7 As New DataGridViewTextBoxColumn
                    With col7
                        .HeaderText = camp7
                        .Name = camp7
                        .DataPropertyName = camp7
                        ' .DefaultCellStyle.Format = "0.00"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .Visible = False
                    End With
                    GrdDetalleVenta.Columns.Add(col7)
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



            'Dim col_3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'With col_3
            '    .DisplayIndex = 2
            '    .DataPropertyName = "Cargo"
            '    .Name = "Cargo"
            '    .HeaderText = "Cargo"
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '    .Mask = "###-########"
            '    .DefaultCellStyle.NullValue = ""
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '    .ReadOnly = False
            'End With

            Dim col_3 As New DataGridViewTextBoxColumn
            With col_3
                .DisplayIndex = 2
                .DataPropertyName = "Cargo"
                .Name = "Cargo"
                .HeaderText = "Cargo"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .MaxInputLength = 13
                '.Mask = "###-########"
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
                If CboProducto.SelectedValue = 81 Then
                    Dim row0 As String() = {"CAJA 5KG", "", "0.00", "0.00", "0.00"}
                    GrdDetalleVenta.Rows().Add(row0)
                ElseIf CboProducto.SelectedValue = 82 Then
                    Dim row0 As String() = {"CAJA 10KG", "", "0.00", "0.00", "0.00"}
                    GrdDetalleVenta.Rows().Add(row0)
                Else
                    Dim row0 As String() = {"PESO", "", "0.00", "0.00", "0.00"}
                    GrdDetalleVenta.Rows().Add(row0)
                    Dim row1 As String() = {"VOLUMEN", "", "0.00", "0.00", "0.00"}
                    GrdDetalleVenta.Rows().Add(row1)
                    Dim row2 As String() = {"SOBRE", "", "0.00", "0.00", "0.00"}
                    GrdDetalleVenta.Rows().Add(row2)
                    Dim row3 As String() = {"BASE", "", "0.00", "0.00", "0.00"}
                    GrdDetalleVenta.Rows().Add(row3)

                    If bNuevo Then
                        GrdDocumentosCliente.Rows.Clear()
                        Dim row11 As String() = {"", " ", " ", ""}
                        GrdDocumentosCliente.Rows().Add(row11)
                        GrdDocumentosCliente.Rows().Add(row11)
                        GrdDocumentosCliente.Rows().Add(row11)
                    End If
                End If
            Else
                Dim row0 As String() = {"1", "", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00"}
                GrdDetalleVenta.Rows().Add(row0)
            End If

                If CboTipo.SelectedValue <> 1 Then
                    TxtSubTotal.Text = "0.00"
                    TxtImpuesto.Text = "0.00"
                    TxtTotal.Text = "0.00"
                End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

    '*********Funcion Condicion MONTO MINIMO (PCE)***********************
    Dim monto_minimo_PCE As Double
    Sub CondicionMontoMinimoPCE()
        Try
            If CboTipo.SelectedValue = 1 Then
                If dtoGuia.MinimoPce(dtoUSUARIOS.m_idciudad, idUnidadAgencias, iID_Persona) = 1 Then
                    CboSubCuenta.Enabled = False
                    TxtSubTotal.Text = FormatNumber(Format(monto_minimo_PCE / (1 + IGV), "###,###,###.00"), 2)
                    TxtImpuesto.Text = FormatNumber(IGV * Format(monto_minimo_PCE / (1 + IGV), "###,###,###.00"), 2)
                    TxtTotal.Text = FormatNumber(Format(monto_minimo_PCE, "###,###,###.00"), 2)
                Else
                    Dim dblTotal As Double = TxtTotal.Text
                    TxtSubTotal.Text = FormatNumber(Format(dblTotal / (1 + IGV), "###,###,###.00"), 2)
                    TxtImpuesto.Text = FormatNumber(IGV * Format(dblTotal / (1 + IGV), "###,###,###.00"), 2)
                    TxtTotal.Text = FormatNumber(Format(dblTotal, "###,###,###.00"), 2)
                End If

                'CboSubCuenta.Enabled = False
                'TxtSubTotal.Text = FormatNumber(Format(monto_minimo_PCE / (1 + IGV), "###,###,###.00"), 2)
                'TxtImpuesto.Text = FormatNumber(IGV * Format(monto_minimo_PCE / (1 + IGV), "###,###,###.00"), 2)
                'TxtTotal.Text = FormatNumber(Format(monto_minimo_PCE, "###,###,###.00"), 2)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '--agregado 04022012
    Sub CondicionMontoMinimoPYME()
        Try
            If CboProducto.SelectedValue = 7 Then
                Dim IGV As Double = dtoUSUARIOS.iIGV / 100
                TxtSubtotal.Text = FormatNumber(Format(MontoMinimoPyme / (1 + IGV), "###,###,###.00"), 2)
                TxtImpuesto.Text = FormatNumber(IGV * Format(MontoMinimoPyme / (1 + IGV), "###,###,###.00"), 2)
                TxtTotal.Text = FormatNumber(Format(MontoMinimoPyme, "###,###,###.00"), 2)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Inicio2()
        Dim obj As New dtoGuia
        Dim ds As DataSet = obj.InicioGuia(dtoUSUARIOS.IdLogin)

        '========================================================================================================            
        '0)*******Cargando Tipos ([Credito], [Pago_Contra_Entrega (PCE)], [Recojo_Carga_Acompañada (PCA)])**
        Dim dt As DataTable
        dt = New DataTable
        dt = ds.Tables(0)
        Me.CboTipo.DataSource = dt.DefaultView
        Me.CboTipo.DisplayMember = "descripcion"
        Me.CboTipo.ValueMember = "id_tipo_guia_envio"

        ''1)*******Cargando Listado Producto***************
        'dt = New DataTable
        'dt = ds.Tables(1)
        'Me.CboProducto.DataSource = dt.DefaultView
        'Me.CboProducto.DisplayMember = "nombre_secundario"
        'Me.CboProducto.ValueMember = "idprocesos"
        '2)*******Cargando filtrado de las agencias*******
        dt = New DataTable
        dt = ds.Tables(1)
        fnCargar_iWin_dt(TxtCiudadDestino, dt, coll_iDestino, iWinDestino, 0)
        '3)*******Cargando los tipos de entrega***********
        dt = New DataTable
        dt = ds.Tables(2)
        Me.CboTipoEntrega.DataSource = dt.DefaultView
        Me.CboTipoEntrega.DisplayMember = "Tipo_Entrega"
        Me.CboTipoEntrega.ValueMember = "Idtipo_Entrega"
        Me.CboTipoEntrega.SelectedValue = 0

        '4)*******Seleccion de Impresion******************
        dt = New DataTable
        dt = ds.Tables(3)
        If dt.Rows.Count > 0 Then
            Me.xIMPRESORA = dt.Rows(0).Item("IMPRESION")
            NOMBRE_IMPRESORA = dt.Rows(0).Item("Control_Impresoras")
        Else
            Me.xIMPRESORA = 0
        End If

        '6)*******Cargando Monto Minimo PCE***************
        dt = New DataTable
        dt = ds.Tables(4)
        If dt.Rows.Count > 0 Then
            monto_minimo_PCE = dt.Rows(0).Item(0)
            dFactor = dt.Rows(0).Item(0)
            MontoMinimoPyme = dt.Rows(0).Item("MONTO_MINIMO_PYME") '04022012
        Else
            monto_minimo_PCE = 0
            dFactor = 0
        End If
    End Sub

#Region "CARGA ACOMPAÑADA ----> BOLETO"
    Dim cnn As OdbcConnection '-> Conexion Mysql
    Dim bEntra As Boolean = False    
    Dim sBoleto As String = ""
    Dim bCargaAcompañada As Boolean = False
    Dim bOrigenDiferente As Boolean = False

    Private Sub txtBoleto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoleto.KeyDown

    End Sub

    Private Sub txtBoleto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBoleto.KeyPress
        If ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf Asc(e.KeyChar.ToString.ToUpper) >= 65 And Asc(e.KeyChar.ToString.ToUpper) <= 90 Then 'e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
    Private Sub TxtBoleto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBoleto.LostFocus
        Try
            Me.Cursor = Cursors.AppStarting
            If iOpcion = 2 Then
                Me.Cursor = Cursors.Default
                Return
            End If
            '*************************************
            objGuiaEnvio.TarifaPyme_ = False
            '*************************************

            sDocCliente = ""
            bDescuento = False
            bTieneLineaCredito = False

            If Me.txtBoleto.ReadOnly Or Me.txtBoleto.Text.Trim.Length <= 1 Then
                Me.Cursor = Cursors.Default
                Return
            End If
            If Me.LblTipoComprobante.Text.Substring(0, 1) <> "G" Then
                bCargaAcompañada = False
            End If

            'hlamas 07-04-2014 CA coneccion a MYSQL
            'coneccion a athenea (vyr)
            'cnn = New Odbc.OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};SERVER=192.168.200.241;DATABASE=Tepsa;UID=ventas;PWD=10913035110;OPTION=18475")

            Dim sDoc As String = Me.txtBoleto.Text.Trim
            Dim iPos As Integer = sDoc.IndexOf("-")
            Dim sIzquierda As String = sDoc.Substring(0, iPos).Trim.PadLeft(3, "0")
            Dim sDerecha As String = sDoc.Substring(iPos + 1).Trim.PadLeft(7, "0")
            sDoc = sIzquierda & "-" & sDerecha
            Me.txtBoleto.Text = sDoc

            Dim obj As New dto_CargaAcompañada
            Dim dt As DataTable = obj.ObtenerBoleto(sDoc)
            CargarBoleto(dt)

            'nu_docu_suna
            'Dim sql As String
            'sql = "SELECT V.idVenta ID, V.NroBoleto NUMBOLETO, "
            'sql = sql & "LEFT(V.FechaPartida,10) FECHAPARTIDA, LEFT(V.HoraPartida, 8) HORAPARTIDA, "
            'sql = sql & "P.NroDocumento nrodocumento,P.NroDocumento nu_docu_suna, upper(P.ApellidoPaterno) ap, upper(P.ApellidoPaterno) ap, "
            'sql = sql & "UPPER(P.ApellidoMaterno) apemat,UPPER(P.ApellidoMaterno) am, "
            'sql = sql & "UPPER(P.Nombres) NOMBRES,UPPER(P.Nombres) NOMBRE,UPPER(P.Nombres) razon_social, V.NroAsiento, upper(R.LocalidadOrigen) ORIGEN, "
            'sql = sql & "UPPER(R.LocalidadDestino) DESTINO, "
            'sql = sql & "if(V.TipoOperacion='', 'V', 'A') VENTA, V.idPasajero IDPASAJERO, P.PasajeroFrecuente, "
            'sql = sql & "codCiudadOrigen,P.idtipodocumento tipo, P.telefono,'' email "
            'sql = sql & "FROM VtaPasajes V "
            'sql = sql & "INNER JOIN Clientes P ON (V.idPasajero = P.idCliente) "
            'sql = sql & "INNER JOIN Rutas R ON (V.idRuta = R.idRuta) "
            'sql = sql & "WHERE V.NroBoleto='" & sDoc & "' "

            'sql = "SELECT V.idVenta ID, V.NroBoleto NUMBOLETO, "
            'sql = sql & "LEFT(V.FechaPartida,10) FECHAPARTIDA, LEFT(V.HoraPartida, 8) HORAPARTIDA, "
            'sql = sql & "P.NroDocumento nrodocumento,P.NroDocumento nu_docu_suna, upper(P.ApellidoPaterno) ap, upper(P.ApellidoPaterno) apepat, "
            'sql = sql & "UPPER(P.ApellidoMaterno) apemat, UPPER(P.ApellidoMaterno) am, "
            'sql = sql & "UPPER(P.Nombres) NOMBRES,UPPER(P.Nombres) NOMBRE,UPPER(P.Nombres) razon_social, V.NroAsiento, upper(R.LocalidadOrigen) ORIGEN, "
            'sql = sql & "UPPER(R.LocalidadDestino) DESTINO, "
            'sql = sql & "if(V.TipoTransaccion='V', 'V', 'A') VENTA, V.idPasajero IDPASAJERO, P.PasajeroFrecuente, "
            'sql = sql & "codCiudadOrigen,P.idtipodocumento tipo, P.telefono, '' email "
            'sql = sql & "FROM VtaPasajes V "
            'sql = sql & "inner join "
            'sql = sql & "(select max(idVenta) idVenta from VtaPasajes where NroBoleto='" & sDoc & "' GROUP BY NroControl) V1 "
            'sql = sql & "on (V.idVenta = V1.idVenta) "
            'sql = sql & "INNER JOIN Clientes P ON (V.idPasajero = P.idCliente) "
            'sql = sql & "INNER JOIN Rutas R ON (V.idRuta = R.idRuta) "
            'sql = sql & "WHERE V.NroBoleto='" & sDoc & "' "
            'Dim dt As DataTable = ObtieneDT(sql)
            'CargarBoleto(dt)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            bBoleto = False
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
            Dim iTipo As Integer
            For Each row As DataRow In dt.Rows
                iTipo = row.Item("tipo")
                row.Item("tipo") = ObtieneTipoDocumento(iTipo)
            Next

            sBoleto = TxtBoleto.Text.Trim
            Dim sql As String
            'verifica si boleto está asociado a algun documento (guia,boleta,factura)
            Dim dt2 As DataTable
            If Not BoletoAsociado(sBoleto, dt2) Then
                Dim iEstado As Integer = IIf(dt.Rows(0).Item("venta") = "V", 1, 0)
                If iEstado = 1 Then                   
                    bBoleto = True                 

                    Me.TxtCiudadDestino.ReadOnly = True
                    Dim iPasajeroFrecuente As Integer = dt.Rows(0).Item("PasajeroFrecuente")
                    'If iPasajeroFrecuente = 1 Then
                    '    'verifica si pasajero frecuente esta activo
                    '    Dim iPasajero As Integer = dt.Rows(0).Item("idpasajero")
                    '    sql = "SELECT idPasajeroFrecuente, Estado FROM PasajeroFrecuente WHERE idCliente=" & iPasajero & " "
                    '    Dim dt1 As DataTable = ObtieneDT(sql)
                    '    If dt1.Rows.Count > 0 Then
                    '        iPasajeroFrecuente = IIf(dt1.Rows(0).Item("estado") = "A", 1, 0)
                    '    End If
                    'End If
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

                        'If iDes <> ObjVentaCargaContado.v_IDUNIDAD_DESTINO Then
                        '    'Destino de guia no coincide con boleto
                        '    MessageBox.Show("El Destino del Boleto no coincide con la Guía.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '    bCargaAcompañada = False
                        '    TxtBoleto.Text = ""
                        '    Return
                        'End If
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
                        'TxtNroDocCliente.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 1, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                        TxtNroDocCliente.Tag = dt.Rows(0).Item("tipo")
                    ElseIf dt.Rows(0).Item("nrodocumento").ToString.Trim.Length = 0 Then
                        TxtNroDocCliente.Text = dt.Rows(0).Item("nrodocumento")
                        'TxtNroDocCliente.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 1, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                        TxtNroDocCliente.Tag = dt.Rows(0).Item("tipo")
                    End If
                    iID_TipoDocCli = TxtNroDocCliente.Tag

                    '--
                    Dim sNombres As String = dt.Rows(0).Item("nombres").ToString.Trim & " " & dt.Rows(0).Item("apepat").ToString.Trim & " " & dt.Rows(0).Item("apemat").ToString.Trim
                    TxtNomCliente.Text = sNombres
                    TxtNomCliente.Tag = dt.Rows(0).Item("apepat").ToString.Trim & "*" & dt.Rows(0).Item("apemat").ToString.Trim
                    TxtTelfCliente.Text = IIf(IsDBNull(dt.Rows(0).Item("telefono")), "", dt.Rows(0).Item("telefono"))
                    '--
                    '**********Comentado x NConsignado***************************************************************************************
                    'TxtNroDocConsignado.Text = dt.Rows(0).Item("nrodocumento").ToString.Trim
                    'TxtNombConsignado.Text = sNombres
                    'TxtTelfConsignado.Text = IIf(IsDBNull(dt.Rows(0).Item("telefono")), "", dt.Rows(0).Item("telefono"))

                    '****Haciendo una copia del DT**************                          
                    dtCliente = dt.Copy
                    dtConsignado = dt.Copy
                    'iTipoDoc = Me.ObtieneTipoDocumento(dtCliente.Rows(0).Item("tipo"))
                    '*********************
                    ' TxtTelfCliente.Text = IIf(IsDBNull(dt.Rows(0).Item("telefono")), "", dt.Rows(0).Item("telefono"))
                    If TxtNroDocCliente.Text.Trim.Length > 0 Then
                        bInicioCargaAcompañada = True
                        Me.Buscar(1)
                        bInicioCargaAcompañada = False
                    Else
                        Me.InicializarDT()
                    End If

                    Me.ChkCliente.Checked = True
                    Me.ChkCliente1.Checked = True
                    Me.ChkCliente2.Checked = True

                    iIDConsignado = 0
                    bConsignadoNuevo = True
                    bConsignadoModificado = False
                    iID_TipoDocConsig = TxtNroDocCliente.Tag

                    '****cliente****
                    sNombresCli = dt.Rows(0).Item("nombres").ToString.Trim
                    sApCli = dt.Rows(0).Item("ap").ToString.Trim
                    sAmCli = dt.Rows(0).Item("am").ToString.Trim
                    sTelfCliente = TxtTelfCliente.Text.Trim
                    sEmail = dt.Rows(0).Item("email").ToString.Trim
                    '****Remitente******                    
                    sNombreRemitente = sNombresCli
                    iID_TipoDocRemitente = iID_TipoDocCli
                    sNroDocRemitente = Me.TxtNroDocCliente.Text.Trim
                    sApRemitente = sApCli
                    sAmRemitente = sAmCli
                    '****Contacto*******
                    idcontacto = Iid
                    NombresCont = sNombresCli
                    iID_TipoDocCont = iID_TipoDocCli
                    apellPatCont = sApCli
                    apellMatCont = sAmCli
                    '****Consignado*****
                    iID_TipoDocConsig = TxtNroDocCliente.Tag
                    sNombresConsig = dt.Rows(0).Item("nombres").ToString.Trim
                    sapellPatConsig = dt.Rows(0).Item("ap").ToString.Trim
                    sapellMatConsig = dt.Rows(0).Item("am").ToString.Trim
                    sTelefonoConsig = TxtTelfCliente.Text.Trim

                    '****Comentado x NConsignado************************
                    'If TxtNroDocConsignado.Text.Trim.Length = 0 Then
                    '    iID_TipoDocConsig = 9
                    '    iID_TipoDocCli = 9
                    'End If
                    bEntra = True
                Else    'anulado
                    MessageBox.Show("El Boleto de Viaje está anulado", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bBoleto = False
                    Me.TxtCiudadDestino.ReadOnly = False
                    Me.TxtBoleto.Focus()
                End If
                Me.BtnGraba.Focus()
            Else
                Dim s As String = ""
                For i As Integer = 0 To dt2.Rows.Count - 1
                    s = s & dt2.Rows(i).Item(0) & " " & dt2.Rows(i).Item(1) & Chr(13)
                Next
                MessageBox.Show("El Boleto " & sBoleto & " está asociado a:" & Chr(13) & Chr(13) & s, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bBoleto = False
                Me.TxtCiudadDestino.ReadOnly = False
                Me.TxtBoleto.Text = ""
                Me.TxtBoleto.Focus()
            End If
        Else
            MessageBox.Show("El Boleto " & Me.TxtBoleto.Text.Trim & " no existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bBoleto = False
            Me.TxtCiudadDestino.ReadOnly = False
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

    Private Sub TxtBoleto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoleto.TextChanged
        bCargaAcompañada2 = False
        sBoleto = ""
        iOficinaDestino = 0
        'Controla(True)
        bIngresa = True
        flagPCEVALIDADOC = True
        fnVALIDARDOCUMENTOS()
        bIngresa = False
        flagPCEVALIDADOC = False
    End Sub

#End Region 'OK

    '*********SELECCION TIPO [PCE], [CREDITO], [RECOJO CARGA ACOMPAÑADA]
#Region "TIPO"
    Private Sub CboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipo.SelectedIndexChanged
        Try
            If iOpcion = 2 Then
                RemoveHandler CboTipo.SelectedIndexChanged, AddressOf CboTipo_SelectedIndexChanged
                Me.CboTipo.SelectedValue = iTipoVenta
                AddHandler CboTipo.SelectedIndexChanged, AddressOf CboTipo_SelectedIndexChanged

                If CboTipo.SelectedValue = 1 Then
                    Me.ListarProducto(0)
                Else
                    Me.ListarProducto(4)
                End If
                Return
            End If

            If IsReference(CboTipo.SelectedValue) Then Return
            Me.Cursor = Cursors.AppStarting

            Me.TxtCliente.Text = ""
            Me.TxtConsignado.Text = ""

            '---CambioR 10112011----
            Me.TxtNroDocCliente.Text = ""
            Me.TxtNomCliente.Text = ""
            Me.FNNUEVO()
            '----------------------

            'Me.LimpiarDatosCliente()
            'Me.LimpiarDatosGeneral()
            'Me.LimpiarConsignado()

            If CboTipo.SelectedValue = 1 Then '-------> Pago Contra Entrega
                Me.ListarProducto(0)
                LblContacto.Text = "Facturar a"
                sDocCliente = ""
                'sRazonSocial = ""               
                Me.CboSubCuenta.Enabled = False
                Me.CondicionMontoMinimoPCE() '-------->    Monto minimo PCE
                '*******************************
                Me.bTieneLineaCredito = False
                Me.bDescuento = False
                Me.Grpa.Visible = False
                Me.TxtCiudadDestino.ReadOnly = False
                Me.TxtCiudadDestino.Enabled = True
                If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1

                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                CboProducto.SelectedIndex = 0
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                CboTipoTarifa.Enabled = True
                RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
                CboTipoTarifa.SelectedIndex = 1
                AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged

                If idUnidadAgencias <> -1 Then
                    If Not ChkArticulos.Checked And ChkM3.Checked = False Then Me.fnTarifario() 'CambioR 10112011
                Else
                    Me.iOficinaDestino = 0 '--> si repite la Ciudad omitir
                End If

                '****************************************
                If CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
                    If CboProducto.SelectedValue = 6 Then Me.ResetCalculo()
                Else
                    If ObjVentaCargaContado.dt_cur_dire_destino.Rows.Count > 0 Then
                        ObjVentaCargaContado.v_IDDIREECION_DESTINO = Int(ObjVentaCargaContado.dt_cur_dire_destino.Rows(0).Item(0).ToString)
                    Else
                        ObjVentaCargaContado.v_IDDIREECION_DESTINO = 0
                    End If
                    If CboProducto.SelectedValue = 6 Then Me.ResetCalculo()
                End If
                '****************************************

                'hlamas 11-03-2019
                'If ObjVentaCargaContado.fnNroDocuemnto(3, CboProducto.SelectedValue) = True Then
                '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                '    txtNroNroGuia.SelectAll()
                '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text
                'ElseIf ObjVentaCargaContado.fnNroDocuemnto(3, 0) = True Then
                '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                '    txtNroNroGuia.SelectAll()
                '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text
                'End If

                'If CboTipo.SelectedValue = 1 Then 'PCE
                Me.CboTipoEntrega.SelectedValue = 1
                'End If

                BtnCargAseg.Enabled = True
                CboProducto.Enabled = True
                CboSubCuenta.DataSource = Nothing

                '*****18112011*****
                'Dim s As Object
                'Dim ee As New System.Windows.Forms.DataGridViewCellEventArgs(2, 0)
                'GrdDetalleVenta_CellEndEdit(s, ee)
                '*****
            ElseIf CboTipo.SelectedValue = 2 Then '----------------------------> credito
                'hlamas 09-05-2015
                Me.TxtDescuento.Text = ""
                Me.TxtDescuento.Enabled = False
                Me.txtDescDescto.Text = ""
                Me.txtDescDescto.Enabled = False

                'Carga Productos de carga expressa              
                Me.ListarProducto(4)
                '----CambioR 09102011--
                Me.TxtNroDocCliente.Text = ""
                Me.TxtNomCliente.Text = ""
                Me.FNNUEVO()
                LimpiarDatosCliente()
                '----------------------

                LblContacto.Text = "Contacto"
                sDocCliente = ""
                'sRazonSocial = ""
                Me.TxtDescuento.Text = ""
                'Me.TxtDescuento.Enabled = False
                Me.txtDescDescto.Enabled = False
                Me.bTieneLineaCredito = False
                Me.bDescuento = False
                Me.Grpa.Visible = False
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                'RemoveHandler TxtNomCliente.TextChanged, AddressOf TxtRasonSocialCliente_TextChanged
                RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
                Me.CboSubCuenta.DataSource = Nothing
                Me.CboSubCuenta.Enabled = True
                Me.ChkSobres.Enabled = False
                Me.BtnCargAseg.Enabled = False
                Me.CboProducto.Enabled = True
                CboProducto.SelectedIndex = 0
                'Me.CboProducto.SelectedIndex = -1
                'Me.CboTipoTarifa.Enabled = False
                Me.CboTipoTarifa.SelectedIndex = 1
                If CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then '"AGENCIA"
                    If CboAgenciaDest.Text = "" Then
                        'TxtDirecConsignado.Text = "AGENCIA"
                    Else
                        'TxtDirecConsignado.Text = CboAgenciaDest.Text
                    End If
                Else
                    'TxtDirecConsignado.Text = ""
                End If
                '******
                Me.TxtCiudadDestino.ReadOnly = False
                Me.TxtCiudadDestino.Enabled = True
                Me.Grpa.Visible = False
                LblPasajero.Visible = False
                '******
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                'AddHandler TxtNomCliente.TextChanged, AddressOf TxtRasonSocialCliente_TextChanged
                AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged

                'hlamas 13-03-2014
                Me.CboProducto.Enabled = False

            ElseIf CboTipo.SelectedValue = 3 Then '---> recojo carga acompañada
                LblContacto.Text = "Facturar a"
                objGuiaEnvio.TarifaPyme_ = False
                objGuiaEnvio.TarifaMasiva_ = False
                '**FORMATO PARA CARGA ACOMPAÑADA****
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                CboProducto.SelectedValue = 6
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                Me.CboSubCuenta.DataSource = Nothing
                Me.CboSubCuenta.Enabled = False
                Me.TxtCiudadDestino.Enabled = True
                Me.CboAgenciaDest.DataSource = Nothing
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
                '-----
                Me.CboProducto.Enabled = False
                Me.CboTipoTarifa.Enabled = False
                Me.CboTipoTarifa.SelectedIndex = -1
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Sistema de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

    '*********SELECCION DE PRODUCTO [NORMAL], [CARGA ACOMPAÑADA], [PYME], [TEPSA ENCOMIENDA]*** 
#Region "PRODUCTO"
    Dim idProducto As Integer
    Private Sub CboProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboProducto.SelectedIndexChanged
        Try
            'If iOpcion = 2 And iTipoVenta = 2 Then
            '    RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            '    Me.CboProducto.SelectedIndex = -1
            '    AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            '    Return
            'ElseIf iOpcion = 2 And iTipoVenta <> 2 Then
            '    RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            '    Me.CboProducto.SelectedValue = Proceso ' or 3
            '    AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            '    Return
            'End If

            If iOpcion = 2 Then
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                Me.CboProducto.SelectedValue = Me.DgvLista.CurrentRow.Cells("idprocesos").Value
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
            sNombresCli = "" : sApCli = "" : sAmCli = "" : sTelfCliente = "" : sRazonSocialCliente = ""
            Me.LimpiarCliente()
            Me.LimpiarConsignado()

            If CboProducto.SelectedValue = 0 Then '--------------------------------> [NORMAL]
                'Me.RefreshNroDocumento(0)
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
                'Me.RefreshNroDocumento(0)
                objGuiaEnvio.TarifaPyme_ = False
                objGuiaEnvio.TarifaMasiva_ = False
                '**FORMATO PARA CARGA ACOMPAÑADA****          
                Me.LimpiarDatosGeneral()
                Me.TxtCiudadDestino.Enabled = False
                Me.CboAgenciaDest.DataSource = Nothing
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
                'Me.RefreshNroDocumento(7)
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
                'Me.RefreshNroDocumento(8)
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
            ElseIf CboProducto.SelectedValue = 5 Then '-------- TEPSA COURIER

                objGuiaEnvio.TarifaPyme_ = False
                Me.bBoleto = False '-->"N" Base <> 0
                Me.LimpiarDatosGeneral()

                If idUnidadAgencias <> -1 Then
                    Me.fnTarifario()
                Else
                    iOficinaDestino = 0
                End If
            ElseIf CboProducto.SelectedValue = 10 Then '--------------------------------> [TEPSA SOBRES]
                'hlamas 11-09-2015
                Me.CboProducto.SelectedValue = 0

                'Me.RefreshNroDocumento(0)
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
            ElseIf CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then '----------------------------> TEPSA BOX
                'Me.RefreshNroDocumento(0)
                objGuiaEnvio.TarifaPyme_ = False
                objGuiaEnvio.TarifaMasiva_ = False
                Me.bBoleto = False '-->"N" Base <> 0
                Me.LimpiarDatosGeneral() '-->limpiar datos general

                Me.Grpa.Visible = False
                Me.txtBoleto.Visible = False
                Me.LblPasajero.Visible = False

                '*******TARIFA TEPSA BOX*******
                objGuiaEnvio.TarifaBox_ = True
                bTieneLineaCredito = False
                bDescuento = False

                If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1
                If idUnidadAgencias <> -1 Then
                    Me.fnTarifario()
                Else
                    iOficinaDestino = 0
                End If
                LblPasajero.Visible = False
            Else
                TipoGrid_ = FormatoGrid.BULTO
                DiseñaGrdDetalleVenta()
                Me.ResetCalculo()
            End If
            AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            AddHandler TxtBoleto.TextChanged, AddressOf TxtBoleto_TextChanged

            '-->10/09/2013 - jabanto
            '-->Oculta los campos DT(Docuemento de transporte)
            lbldt.Visible = False
            txtdt.Visible = False
            Me.dtpFechaRecojo.Visible = False
            Me.dtpFechaRecojo.Checked = False
            TxtTelfCliente.Size = New Size(329, 20)
            txtdt.Clear()

            'hlamas 23-09-2013
            Me.ControlaSubcuentaOrigen(False)
            CboSubCuenta.DataSource = Nothing

            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
            End If

            'CboSubCuentaOrigen.Enabled = False
            'CboSubCuentaOrigen.DataSource = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "TARIFA"
    Private Sub CboTipoTarifa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoTarifa.SelectedIndexChanged
        Try
            If iOpcion = 2 Then
                RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
                If iTipoVenta = 2 Then
                    Me.CboTipoTarifa.SelectedIndex = 1
                Else
                    Me.CboTipoTarifa.SelectedValue = iTipoTarifa
                End If
                AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
                Me.Cursor = Cursors.Default
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

            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            If Not IsReference(CboTipoTarifa.SelectedValue) Then
                GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
            End If

            Me.fnTarifario()
            GrdDetalleVenta("Costo", 0).Value = Format(tarifa_Peso, "0.00")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "DESTINO"
    Dim iOficinaDestino As Integer
    Dim CodCiudadDest_ As Integer
    Dim lb_no_lee As Boolean = True
    Dim idUnidadAgencias As Integer = -1
    '****CIUDAD*****
    Private Sub TxtCiudadDestino_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCiudadDestino.Enter
        TxtCiudadDestino.SelectAll()
    End Sub

    Private Sub TxtCiudadDestino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCiudadDestino.LostFocus
        Try
            Me.Cursor = Cursors.AppStarting
            If iOpcion = 2 Then
                Me.Cursor = Cursors.Default
                Return
            End If

            idUnidadAgencias = iWinDestino.IndexOf(TxtCiudadDestino.Text)
            Dim ErrCiudad_ As String = "" : CodCiudadDest_ = -1

            If idUnidadAgencias >= 0 Then '-> existe ciudad  

                If bNuevo Then
                    dtDireccion2 = Nothing
                    CboDireccion2.DataSource = Nothing
                    Me.CboDireccion2.Items.Clear()
                    Me.CboDireccion2.Items.Add(" (SELECCIONE)")
                    Me.CboDireccion2.SelectedIndex = 0
                    RemoveItemsCargAseg() '--->Limpiando items [carga asegurada]
                    ChkM3.Checked = False
                End If

                idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))

                'hlamas 24-02-2014
                If Me.CboTipoEntrega.SelectedValue = 2 Then
                    ActualizaDireccion(CboDireccion2)
                End If

                If idUnidadAgencias = iCiudadDestino Then
                    Me.Cursor = Cursors.Default
                    Return
                End If

                '***Reseteando valores del grid****
                TipoGrid_ = FormatoGrid.BULTO
                Me.DiseñaGrdDetalleVenta()
                FormatoGrdDetalleVenta()
                '**********************************
                CodCiudadDest_ = idUnidadAgencias
                ObjVentaCargaContado.fnGetAgencias(idUnidadAgencias, 1)
                Dim DtAgenciaDestino As DataTable = ObjVentaCargaContado.dt_VarAgencias.Copy

                With Me.CboAgenciaDest
                    DtAgenciaDestino = ObjVentaCargaContado.dt_VarAgencias.Copy
                    .DataSource = DtAgenciaDestino
                    .DisplayMember = "nombre_agencia"
                    .ValueMember = "idagencias"
                    If .Items.Count > 2 Then
                        .SelectedIndex = 0
                        .DroppedDown = True
                        .Focus()
                        Me.Cursor = Cursors.Default
                    ElseIf .Items.Count = 1 Then
                        .SelectedIndex = 0
                        .Focus()
                    Else
                        .SelectedIndex = 1
                        .Focus()
                    End If
                End With

                '*********************************
                'If bNuevo Then
                Me.objGuiaEnvio.TarifaPyme_ = False
                If FnExisteCliente() = False Then
                    If CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                        objGuiaEnvio.TarifaPublica_ = False
                        objGuiaEnvio.TarifaBox_ = True
                    Else
                        objGuiaEnvio.TarifaPublica_ = True
                    End If
                    bTieneLineaCredito = False
                    bDescuento = False
                Else
                    If CboProducto.SelectedValue <> 6 Then
                        Me.Consulta() '-->si tiene linea de credito,bdescuento,Articulos
                    ElseIf CboProducto.SelectedValue = 7 Then
                        Me.objGuiaEnvio.TarifaPyme_ = True
                    ElseIf CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                        objGuiaEnvio.TarifaBox_ = True
                    End If
                End If
                'End If

                '****OBTENIENDO EL TARIFARIO******    
                If (CboTipo.SelectedValue = 2 And CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER) Then
                    fnTarifario()
                    'fncValidarEnvioRetorno_Destino_CentroCosto()
                    Me.Cursor = Cursors.Default
                ElseIf Me.CboTipo.SelectedValue <> 2 Or (Me.CboTipo.SelectedValue = 2 And Me.TxtCliente.Text.Trim.Length > 0 And _
                                                        CboProducto.SelectedValue = ID_PRODUCTO_CARGA_EXPRESA) Then
                    fnTarifario()
                    'fncValidarEnvioRetorno_Destino_CentroCosto()
                    Me.Cursor = Cursors.Default
                End If


                'If Me.CboTipo.SelectedValue <> 2 Or (Me.CboTipo.SelectedValue = 2 And Me.TxtCliente.Text.Trim.Length > 0) Then
                '    fnTarifario()
                '    Me.Cursor = Cursors.Default
                'End If

                If Not bNuevo Then
                    fnTarifario()
                End If

                ' Me.NewfnTarifario()
                '*********************************
                'hlamas 13-03-2014
                ClienteProducto(iID_Persona, Me.CboSubCuenta.SelectedValue, Me.CboCiudad_Origen.SelectedValue, idUnidadAgencias)

                'hlamas 24-02-2014
                If ID_PERSONA_DATAIMAGENES = iID_Persona Then
                    Me.ClientePersonalizado(iID_Persona)
                End If

                Me.Cursor = Cursors.Default
            ElseIf idUnidadAgencias = -1 Then '-> No existe la Ciudad Destino
                RemoveItemsCargAseg()
                CboAgenciaDest.DataSource = Nothing
                TipoGrid_ = FormatoGrid.BULTO
                Me.DiseñaGrdDetalleVenta()
                FormatoGrdDetalleVenta()
                bDescuento = False
                bTieneLineaCredito = False
                iOficinaDestino = -1
                ChkArticulos.Enabled = False : ChkArticulos.Checked = False
                ChkM3.Checked = False
                Me.Cursor = Cursors.Default
            End If
            iOficinaDestino = idUnidadAgencias

            'hlamas 01-10-2013
            Me.CargarSubcuentaDestino(ObjVentaCargaContado.v_IDPERSONA, idUnidadAgencias)

            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)

            iCiudadDestino = idUnidadAgencias
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'SI TIENE ARTICULOS,DESCUENTO, LINEA DE CREDITO
    Sub Consulta()
        Try
            'hlamas 21-01-2016
            ChkArticulos.Tag = Nothing
            Me.DtArticulos = ObjVentaCargaContado.dt_cur_Articulos.Copy
            Iid = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
            '****************************************************************************************
            If Iid > 0 Then
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                '**************************TIPO DE CLIENTE [Normal, PYME]****************************
                If CboTipo.SelectedValue <> 2 Then
                    Dim iProceso As Integer = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(7)
                    If iProceso = 0 Or (iProceso = 7 And ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(8) <> TxtCliente.Text.Trim) Then '------> Normal
                        objGuiaEnvio.TarifaPyme_ = False
                        If CboProducto.SelectedValue = 6 Then
                            Me.CboProducto.SelectedValue = 6
                        ElseIf CboProducto.SelectedValue = 8 And bTieneLineaCredito = False Then
                            Me.CboProducto.SelectedValue = 8
                        ElseIf CboProducto.SelectedValue = 81 Then
                            Me.CboProducto.SelectedValue = 81
                        ElseIf CboProducto.SelectedValue = 82 Then
                            Me.CboProducto.SelectedValue = 82
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
                    ElseIf iProceso = 81 Or iProceso = 82 Then '--> Tepsa Box
                        Me.CboProducto.SelectedValue = iProceso
                        objGuiaEnvio.TarifaPyme_ = False
                        objGuiaEnvio.TarifaMasiva_ = False
                        objGuiaEnvio.TarifaBox_ = True
                        Me.CboProducto.SelectedValue = iProceso
                    End If
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
            If Iid > 0 Then
                '****************CLIENTE TIENE [ARTICULOS]*******************************
                If DtArticulos.Rows.Count > 0 Then
                    ChkArticulos.Enabled = True
                    'hlamas 21-01-2016
                    ChkArticulos.Tag = 1
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

    '****AGENCIA*****
    Private Sub CboAgenciaDest_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAgenciaDest.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.AppStarting
            If Not IsReference(CboAgenciaDest.SelectedValue) Then
                If iOpcion = 2 Then
                    RemoveHandler CboAgenciaDest.SelectedIndexChanged, AddressOf CboAgenciaDest_SelectedIndexChanged
                    Me.CboAgenciaDest.SelectedValue = iIDAgenciaDestino
                    AddHandler CboAgenciaDest.SelectedIndexChanged, AddressOf CboAgenciaDest_SelectedIndexChanged
                    Me.Cursor = Cursors.Default
                    Return
                End If
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

    'TIPO ENTREGA, SUB_CUENTA
#Region "CONDICION"
    '****ENTREGA****
    Private Sub CboTipoEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoEntrega.SelectedIndexChanged
        Try
            If Not IsReference(CboTipoEntrega.SelectedValue) Then
                If iOpcion = 2 Then
                    RemoveHandler CboTipoEntrega.SelectedIndexChanged, AddressOf CboTipoEntrega_SelectedIndexChanged
                    CboTipoEntrega.SelectedValue = iTipoEntrega
                    AddHandler CboTipoEntrega.SelectedIndexChanged, AddressOf CboTipoEntrega_SelectedIndexChanged
                    Me.Cursor = Cursors.Default
                    Return
                End If

                Dim iidTipo As Integer = CboTipoEntrega.SelectedValue
                'If (iidTipo = 2 Or iidTipo = 0) AndAlso Me.CboTipo.SelectedValue = 1 Then 'si pce es a domicilio se fuerza a agencia
                'Me.CboTipoEntrega.SelectedValue = 1
                'Return
                'End If
                Me.ConvertirTipoEntrega(CboTipoEntrega.SelectedValue)

                If CboProducto.SelectedValue = 6 Then Me.ResetCalculo()
                '09-09-2011 richard
                If CboTipo.SelectedValue <> 3 Then
                    If CboProducto.SelectedValue = 6 And iidTipo = 1 Then '------> Tipo Entrega [Agencia] No Incluye Base
                        GrdDetalleVenta(3, 3).Value = "0.00"
                        GrdDetalleVenta(4, 3).Value = "0.00"
                        Me.Monto_Base = 0.0
                        Me.TxtReferencia.Text = "" '09092011
                    ElseIf CboProducto.SelectedValue = 6 And iidTipo = 2 Then '--> Tipo Entrega [Agencia] Si Icluye Base
                        GrdDetalleVenta(3, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                        GrdDetalleVenta(4, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                        Me.Monto_Base = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                    End If
                Else
                    GrdDetalleVenta(3, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                    GrdDetalleVenta(4, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                    Me.Monto_Base = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                End If

                'hlamas 24-02-2014
                If Me.CboTipoEntrega.SelectedValue = 2 AndAlso Me.CboDireccion2.Items.Count <= 1 Then
                    ActualizaDireccion(CboDireccion2)
                End If

                'hlamas 15-11-2013
                'Tarifa Entrega a Domicilio
                GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)

                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Or CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                    fnTarifario()
                    fnTotalPago()
                    'CalculoArticulos()
                End If
                Me.RbtDocumento.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '****SUB CUENTA****    
    Dim CboSubCuentaSelectedIndex_ As Boolean
    Private Sub CboSubCuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSubCuenta.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.AppStarting
            If Not IsReference(CboSubCuenta.SelectedValue) Then
                flagControl = True

                If iOpcion = 2 Then
                    RemoveHandler CboSubCuenta.SelectedIndexChanged, AddressOf CboSubCuenta_SelectedIndexChanged
                    Me.CboSubCuenta.SelectedValue = iIDSubcuenta
                    AddHandler CboSubCuenta.SelectedIndexChanged, AddressOf CboSubCuenta_SelectedIndexChanged
                    Me.Cursor = Cursors.Default
                    Return
                End If

                If CboSubCuenta.Focused = True Then
                    Me.ResetCalculo()
                    Dim iOpcion As Integer = IIf(Me.RbtDocumento.Checked, 1, 2)
                    Dim iCliente As Integer = iID_Persona 'iOpcion = 2, Me.TxtCliente.Text.Trim,

                    Dim obj As New dtoGuiaEnvio
                    'Consultando X SubCuenta

                    'Dim ds As DataSet = obj.BuscarClienteCredito(iCliente, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias, CboSubCuenta.SelectedValue) 'dtoUSUARIOS.m_idciudad
                    Dim ds As DataSet = obj.BuscarClienteCredito(iCliente, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias, CboSubCuenta.SelectedValue)

                    'dtCliente = ds.Tables(0)
                    ChkCliente.Checked = False
                    ChkCliente1.Checked = False
                    Me.MostrarClienteCreditoXSubCuenta(ds)

                    'hlamas 24-02-2014
                    Me.ClientePersonalizado(iCliente)

                    'hlamas 13-03-2014
                    ClienteProducto(iID_Persona, Me.CboSubCuenta.SelectedValue, Me.CboCiudad_Origen.SelectedValue, idUnidadAgencias)

                    If Me.CboProducto.SelectedIndex > -1 Then
                        fnTarifario()
                    End If
                End If
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'FUNCION MOSTRAR DATOS SUB_CUENTA
    Sub MostrarClienteCreditoXSubCuenta(ByVal ds As DataSet)
        bClienteNuevo = False
        'Me.LimpiarDatosCliente()
        LimpiaDatosCliente()

        '**Articulos**
        DtArticulos = ds.Tables(2).Copy
        If ds.Tables(2).Rows.Count > 0 Then
            ChkArticulos.Enabled = True
        Else
            ChkArticulos.Enabled = False : ChkArticulos.Checked = False
        End If

        
        With Me.CboDireccion2
            dtDireccion = ds.Tables(0)
            .DataSource = dtDireccion
            .DisplayMember = "direccion"
            .ValueMember = "iddireccion_consignado"

            If .Items.Count > 2 Then
                .SelectedIndex = 0
                .DroppedDown = True
                ' .Focus()
                Me.Cursor = Cursors.Default
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
                ' .Focus()
            Else
                .SelectedIndex = 1
                IdDireccionOrigen = CboDireccion2.SelectedValue
                '  .Focus()
            End If
        End With

        'RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
        With Me.CboContacto
            dtContacto = ds.Tables(1)
            dtContactoParalelo = ds.Tables(1).Copy
            .DataSource = dtContacto
            .DisplayMember = "nombres"
            .ValueMember = "idcontacto_persona"
            If .Items.Count > 2 Then
                .SelectedIndex = 0
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
                ChkCliente1.Checked = True
            Else
                .SelectedIndex = 1
            End If
            'Me.ChkCliente1.Tag = DBNull.Value
        End With

        With Me.CboRemitente
            dtRemitente = ds.Tables(1).Copy
            dtRemitenteParalelo = ds.Tables(1).Copy
            .DataSource = dtRemitente
            .DisplayMember = "nombres"
            .ValueMember = "idcontacto_persona"
            If .Items.Count > 2 Then
                .SelectedIndex = 0
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
                ChkCliente.Checked = True
            Else
                .SelectedIndex = 1
            End If
            'Me.ChkCliente.Tag = DBNull.Value
        End With

        ' AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged

        If TipoComprobante = 1 Then
            CboContacto.Enabled = True
            ChkCliente1.Enabled = True
        End If
    End Sub
#End Region

#Region "CLIENTE"

    '****X NOMBRE O NRO DOCUMENTO DEL CLIENTE******
    Private Sub RbtDocumento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtDocumento.CheckedChanged, RbtNombre.CheckedChanged
        Me.TxtCliente.Text = ""
        If CType(sender, RadioButton).Name = "RbtDocumento" Then
            Me.TxtCliente.MaxLength = 11
        Else
            Me.TxtCliente.MaxLength = 50
        End If
        Me.TxtCliente.Focus()
    End Sub
    'Cliente
    Dim sNombresCli As String = "", sApCli As String = "", sAmCli As String = "", sTelfCliente As String = "", sEmail = "", sRazonSocialCliente As String = ""
    Dim iID_TipoDocCli As Integer = 0
    'Remitente
    Dim sNombreRemitente As String = "", sApRemitente As String = "", sAmRemitente As String = "", sNroDocRemitente As String = ""
    Dim iID_TipoDocRemitente As Integer = 0
    Dim bClienteCredito As Boolean

    '***BUSCAR CLIENTE***
    Private Sub BtnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCliente.Click
        Try
            If iOpcion = 2 Then
                Return
            End If

            Me.Cursor = Cursors.AppStarting
            Dim frm As New FrmCliente3
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
            Dim sAmCont As String = ""
            Dim bEsCliente As Boolean = False

            Dim iTipo3 As Integer
            Dim sNroDocRemitente As String = ""
            Dim sRemitente As String = ""
            Dim sNombresRemitente As String = ""
            Dim sAp As String = ""
            Dim sAm As String = ""
            Dim bEsCliente2 As Boolean = False

            If Me.TxtNroDocCliente.Text.Trim.Length > 0 Or Me.TxtNomCliente.Text.Trim.Length > 0 Then
                If Not bClienteNuevo Then
                    sNumero = IIf(IsDBNull(dtCliente.Rows(iFila).Item("nu_docu_suna")), "", dtCliente.Rows(iFila).Item("nu_docu_suna"))
                    sRazonSocialCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("razon_social")), "", dtCliente.Rows(iFila).Item("razon_social"))
                    iTipo = IIf(IsDBNull(dtCliente.Rows(iFila).Item("tipo")), "", dtCliente.Rows(iFila).Item("tipo"))
                    sTelfCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("telefono")), "", dtCliente.Rows(iFila).Item("telefono"))
                    sEmail = IIf(IsDBNull(dtCliente.Rows(iFila).Item("Email")), "", dtCliente.Rows(iFila).Item("Email"))
                    If iTipo = 1 Then
                        sNombresCli = ""
                        sApCli = ""
                        sAmCli = ""
                    Else
                        sNombresCli = IIf(IsDBNull(dtCliente.Rows(0).Item("nombres")), "", dtCliente.Rows(0).Item("nombres"))
                        sApCli = IIf(IsDBNull(dtCliente.Rows(0).Item("ap")), "", dtCliente.Rows(0).Item("ap"))
                        sAmCli = IIf(IsDBNull(dtCliente.Rows(0).Item("am")), "", dtCliente.Rows(0).Item("am"))                        
                    End If

                    iFila = IIf(Me.CboDireccion.SelectedIndex = -1, 0, Me.CboDireccion.SelectedIndex)
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

                    iFila = IIf(Me.CboContacto.SelectedIndex = -1, 0, Me.CboContacto.SelectedIndex)
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

                    iFila = IIf(Me.CboRemitente.SelectedIndex = -1, 0, Me.CboRemitente.SelectedIndex)
                    iTipo3 = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("idtipo_documento_contacto")), 0, dtRemitente.Rows(iFila).Item("idtipo_documento_contacto"))
                    sNroDocRemitente = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nrodocumento")), "", dtRemitente.Rows(iFila).Item("nrodocumento"))
                    sRemitente = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nombres")), "", dtRemitente.Rows(iFila).Item("nombres"))
                    sNombresRemitente = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nombre")), "", dtRemitente.Rows(iFila).Item("nombre")) 'new
                    sAp = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("apepat")), "", dtRemitente.Rows(iFila).Item("apepat"))
                    sAm = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("apemat")), "", dtRemitente.Rows(iFila).Item("apemat"))

                    If sRemitente.Trim.Substring(0, 1) = "(" Then
                        sRemitente = ""
                    End If
                    bEsCliente2 = Me.ChkCliente.Checked
                Else
                    sNumero = IIf(IsDBNull(dtCliente.Rows(0).Item("nu_docu_suna")), "", dtCliente.Rows(0).Item("nu_docu_suna"))
                    sRazonSocialCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("razon_social")), "", dtCliente.Rows(0).Item("razon_social"))
                    If Not bBoleto Then
                        iTipo = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
                    Else
                        'iTipo = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dtCliente.Rows(0).Item("tipo")))
                        iTipo = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
                    End If
                    sTelfCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("telefono")), "", dtCliente.Rows(iFila).Item("telefono"))
                    sEmail = IIf(IsDBNull(dtCliente.Rows(iFila).Item("Email")), "", dtCliente.Rows(iFila).Item("Email")) '07092011

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
                        iFila = IIf(Me.CboDireccion.SelectedIndex = -1, 0, Me.CboDireccion.SelectedIndex)
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
                            iFila = IIf(Me.CboContacto.SelectedIndex = -1, 0, Me.CboContacto.SelectedIndex)
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

                        If Me.CboRemitente.Enabled Then
                            iFila = IIf(Me.CboRemitente.SelectedIndex = -1, 0, Me.CboRemitente.SelectedIndex)
                            iTipo3 = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("idtipo_documento_contacto")), 0, dtRemitente.Rows(iFila).Item("idtipo_documento_contacto"))
                            sNroDocRemitente = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nrodocumento")), "", dtRemitente.Rows(iFila).Item("nrodocumento"))
                            sRemitente = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nombres")), "", dtRemitente.Rows(iFila).Item("nombres"))
                            sNombresRemitente = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nombre")), "", dtRemitente.Rows(iFila).Item("nombre")) 'new
                            sAp = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("apepat")), "", dtRemitente.Rows(iFila).Item("apepat"))
                            sAm = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("apemat")), "", dtRemitente.Rows(iFila).Item("apemat"))
                            If sRemitente.Trim.Substring(0, 1) = "(" Then
                                sRemitente = ""
                            End If
                            bEsCliente2 = Me.ChkCliente.Checked
                        End If
                    End If
                    bEsCliente = Me.ChkCliente1.Checked
                    bEsCliente2 = Me.ChkCliente.Checked
                End If
            End If

            If iOpcion = 1 And bNuevo = False Then
                frm.txtTelefono.Enabled = False
            End If
            frm.bClienteNuevo = bClienteNuevo
            frm.GrbContacto.Text = IIf(Me.CboTipo.SelectedValue = 2, "Contacto", "Facturar a")
            '04092011
            frm.iTipoVenta = IIf(Me.CboTipo.SelectedValue = TipoVenta.Credito, TipoVenta.Credito, TipoVenta.Contado)
            frm.bRemitenteNuevo = IIf(idRemitente > 0, False, True)
            frm.bContactoNuevo = IIf(idcontacto > 0, False, True)

            frm.cargar(sNumero, sRazonSocialCliente, iTipo, sNombresCli, sApCli, sAmCli, iDepartamento, iProvincia, iDistrito, iId_via, sVia, sNumero2, _
                       sManzana, sLote, iId_Nivel, sNivel, iId_Zona, sZona, iId_Clasificacion, _
                       sClasificacion, iTipo2, sNumero3, sContacto, sNombresCont, sApCont, sAmCont, sTelfCliente, bEsCliente, bEsCliente2, sNombresCli, _
                       sApCli, sAmCli, sTelfCliente, iTipo3, sNroDocRemitente, sRemitente, sNombresRemitente, sAp, sAm, sEmail, bClienteCredito)

            frm.ShowDialog()
            Me.Cursor = Cursors.Default
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.AppStarting
                Me.CargarCliente(frm)

                'hlamas 13-03-2014
                ClienteProducto(iID_Persona, Me.CboSubCuenta.SelectedValue, Me.CboCiudad_Origen.SelectedValue, idUnidadAgencias)

                'hlamas 24-02-2014
                ClientePersonalizado(iID_Persona)

                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '****NRO DOCUMENTO******
    Dim sDocCliente As String = ""
    Dim s_persona_remitente As String = ""
    Dim flagPCEVALIDADOC As Boolean = False
    Private Sub TxtNroDocCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroDocCliente.TextChanged
        Try
            If CboTipo.SelectedValue = 1 Or CboTipo.SelectedValue = 2 Then '---> Contado
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                If CboProducto.SelectedValue <> 6 Then
                    If FnExisteCliente() = False Then '                       
                        Me.LimpiarDatosCliente()
                        'Me.RefreshNroDocumento(0)
                        '**************************************             
                        TarifaPublica_ = True
                        bTieneLineaCredito = False
                        bDescuento = False
                        If CboProducto.SelectedValue = 7 Then CboProducto.SelectedValue = 0

                        'hlamas 01-10-2013
                        Me.CargarSubcuentaOrigen(ObjVentaCargaContado.v_IDPERSONA, objGuiaEnvio.iIDUNIDAD_AGENCIA)
                        Me.CargarSubcuentaDestino(ObjVentaCargaContado.v_IDPERSONA, idUnidadAgencias)

                        fnTarifario()
                        '**************************************
                        If CboProducto.SelectedValue <> 6 Then
                            TxtCiudadDestino.ReadOnly = False
                            TxtCiudadDestino.Enabled = True
                        End If

                        If fnVALIDARDOCUMENTOS() Then
                        End If
                    Else
                        sDocCliente = ""
                        If CboProducto.SelectedValue <> 6 Then
                            TxtCiudadDestino.ReadOnly = False
                            TxtCiudadDestino.Enabled = True
                        End If
                        'hlamas 01-10-2013
                        Me.CargarSubcuentaOrigen(ObjVentaCargaContado.v_IDPERSONA, objGuiaEnvio.iIDUNIDAD_AGENCIA)
                        Me.CargarSubcuentaDestino(ObjVentaCargaContado.v_IDPERSONA, idUnidadAgencias)

                        fnTarifario()
                    End If
                Else
                    sDocCliente = ""
                    If Me.ChkCliente2.Checked Then
                        RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
                        Me.ChkCliente2.Checked = False
                        AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
                    End If
                End If
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            ElseIf CboTipo.SelectedValue = 2 Then '---> Credito
                'If TxtNroDocCliente.Text = "" Then
                '    Me.LimpiarDatosCliente()
                '    TxtNomCliente.Text = ""
                'End If
                CONTROL = 2
                bControl_Busqueda = True
                Me.fb_buscar_cliente()
            End If

            'hlamas 24-02-2014
            'If Me.CboTipo.SelectedValue = 2 Then
            Me.TxtCiudadDestino.Enabled = True
            Me.CboTipoEntrega.Enabled = True
            Me.CboDireccion2.Enabled = True
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ExisteEsElCliente(ByVal numero As String, ByVal cbo As ComboBox, ByVal dt As DataTable, ByVal campo As String, ByVal campo2 As String) As Integer
        Dim sNumero As String
        For i As Integer = 1 To dt.Rows.Count - 1
            sNumero = IIf(IsDBNull(dt.Rows(i).Item(campo)), "", dt.Rows(i).Item(campo))
            If numero.Trim = sNumero.Trim Then
                Return dt.Rows(i).Item(campo2)
            End If
        Next
        Return 0
    End Function

    'FUNCION BUSCAR (CLIENTE)    
    Sub Buscar(Optional ByVal opcion As Integer = 0)
        Try
            Me.Cursor = Cursors.AppStarting
            Dim iOpcion As Integer = IIf(Me.RbtDocumento.Checked, 1, 2)
            Dim frm As New FrmCliente3
            Dim scliente As String = IIf(opcion = 0, Me.TxtCliente.Text.Trim, Me.TxtNroDocCliente.Text)
            Dim iCliente As Integer
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.Buscar(scliente, iOpcion, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias)
            Dim bClienteExisteCA As Boolean = False
            If bInicioCargaAcompañada Then
                If ds.Tables(0).Rows(0).Item(0).ToString <> "" Then '06092011
                    'If ds.Tables(0).Rows.Count > 0 Then
                    bClienteExisteCA = True
                    'dtCliente = ds.Tables(0)
                    If ds.Tables(0).Rows(0).Item("ap").ToString.Trim <> "" Then 'Agregado Cambio
                        dtCliente = ds.Tables(0)
                    End If
                    'Me.ChkCliente2.Checked=False
                Else
                    InicializarDT() '06092011 habilitado
                    'dtCliente = ds.Tables(0)'Comentado en Observacion (No existe el cliente de CA no deberia tomar ds.tables)
                End If
            Else
                dtCliente = ds.Tables(0)
            End If

            bClienteNuevo = True
            'If Not bInicioCargaAcompañada Then
            '    Me.Cursor = Cursors.Default
            '    MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    frm = New FrmCliente3
            '    frm.bClienteNuevo = bClienteNuevo
            '    bClienteCredito = False
            '    frm.iFicha = 1
            '    frm.TxtNumero.Text = IIf(RbtDocumento.Checked, scliente.Trim, "") '22092011 Agregado ayuda nroDocumento
            '    frm.ShowDialog()
            '    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            '        Me.LimpiarCliente()
            '        CargarCliente(frm)
            '    End If
            'End If

            If IsDBNull(dtCliente.Rows(0).Item(0)) Then
                If Not bInicioCargaAcompañada Then
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frm = New FrmCliente3
                    frm.bClienteNuevo = bClienteNuevo
                    bClienteCredito = False
                    frm.iFicha = 1
                    frm.TxtNumero.Text = IIf(RbtDocumento.Checked, scliente.Trim, "") '22092011 Agregado ayuda nroDocumento
                    frm.ShowDialog()
                    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                        Me.LimpiarCliente()
                        CargarCliente(frm)
                    End If
                End If
            ElseIf (ds.Tables(0).Rows.Count = 1 And Not bInicioCargaAcompañada) Or (bInicioCargaAcompañada And bClienteExisteCA) Then
                Me.Mostrar(ds)
                ChkCliente.Checked = True
                ChkCliente1.Checked = True
            ElseIf Not bInicioCargaAcompañada Then
                frm.bClienteNuevo = bClienteNuevo
                frm = New FrmCliente3
                frm.iFicha = 0

                frm.cargar(ds.Tables(0), 2)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    If frm.bClienteNuevo Then
                        CargarCliente(frm)
                    Else
                        ds = obj.Buscar(frm.TxtNumero.Tag, 3, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias)
                        dtCliente = ds.Tables(0)
                        Me.Mostrar(ds)
                        ChkCliente.Checked = True
                        ChkCliente1.Checked = True
                    End If
                End If
            End If
            sDocCliente = TxtCliente.Text.Trim

            'hlamas 14-02-2019
            ClienteProducto(iID_Persona, 999, Me.CboCiudad_Origen.SelectedValue, idUnidadAgencias)

            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Throw New Exception
        End Try
    End Sub

    Sub InicializarDT()
        '****REMITENTE***
        Dim dr As DataRow
        Me.CboRemitente.DataSource = Nothing
        Me.CboRemitente.Items.Clear()
        dtRemitente = New DataTable
        dtRemitente.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
        dtRemitente.Columns.Add(New DataColumn("nombres", GetType(String)))
        dtRemitente.Columns.Add(New DataColumn("nombre", GetType(String))) 'new
        dtRemitente.Columns.Add(New DataColumn("idtipo_documento_contacto", GetType(Integer)))
        dtRemitente.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
        dtRemitente.Columns.Add(New DataColumn("apepat", GetType(String)))
        dtRemitente.Columns.Add(New DataColumn("apemat", GetType(String)))

        dr = dtRemitente.NewRow
        dr("idcontacto_persona") = 0
        dr("nombres") = " (SELECCIONE)"
        dr("idtipo_documento_contacto") = 0
        dr("nrodocumento") = ""
        dtRemitente.Rows.Add(dr)
        dtRemitenteParalelo = dtRemitente.Copy

        Me.CboRemitente.DataSource = dtRemitente
        CboRemitente.DisplayMember = "nombres"
        CboRemitente.ValueMember = "idcontacto_persona"
        Me.CboRemitente.SelectedIndex = IIf(dtRemitente.Rows.Count > 1, 1, 0)

        '*****CONTACTO*****
        Me.CboContacto.DataSource = Nothing
        Me.CboContacto.Items.Clear()
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
        dtContactoParalelo = dtContacto.Copy

        Me.CboContacto.DataSource = dtContacto
        CboContacto.DisplayMember = "nombres"
        CboContacto.ValueMember = "idcontacto_persona"
        Me.CboContacto.SelectedIndex = IIf(dtContacto.Rows.Count > 1, 1, 0)
    End Sub

    Dim iID_Persona As Integer
    Sub Mostrar(ByVal ds As DataSet)
        'hlamas 21-01-2016
        ChkArticulos.Tag = Nothing
        bClienteNuevo = False
        If bNuevo Then Me.LimpiarDatosCliente()
        fnTarifario()

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


        If (dtCliente.Rows(0).Item("Cliente_Corporativo")) = 1 Then
            bClienteCredito = True
        Else
            bClienteCredito = False
        End If
        '**Articulos**
        DtArticulos = ds.Tables(5).Copy
        If ds.Tables(5).Rows.Count > 0 Then
            iBaseArticulo = ds.Tables(5).Rows(0).Item("base")
            ChkArticulos.Enabled = True
            'hlamas 21-01-2016
            ChkArticulos.Tag = 1
        Else
            ChkArticulos.Enabled = False : ChkArticulos.Checked = False
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

        '******************************************************
        iID_Persona = ds.Tables(0).Rows(0).Item("idpersona")
        Dim iProceso As Integer = ds.Tables(0).Rows(0).Item("id_proceso")
        '******************************************************
        If bNuevo Then
            If CboTipo.SelectedValue <> 2 Then ' Solo contado
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                If iProceso = 0 Then '------> Normal  Or (iProceso = 7 And ds.Tables(0).Rows(0).Item("codigo_cliente") <> TxtCliente.Text.Trim)
                    objGuiaEnvio.TarifaPyme_ = False
                    If CboProducto.SelectedValue = 6 Then
                        Me.CboProducto.SelectedValue = 6
                    ElseIf CboProducto.SelectedValue = 8 Then 'And bTieneLineaCredito = False Then
                        Me.CboProducto.SelectedValue = 8
                    ElseIf CboProducto.SelectedValue = 81 Then
                        Me.CboProducto.SelectedValue = 81
                    ElseIf CboProducto.SelectedValue = 82 Then
                        Me.CboProducto.SelectedValue = 82
                    Else
                        Me.CboProducto.SelectedValue = iProceso
                    End If
                    'Me.RefreshNroDocumento(0)
                ElseIf iProceso = 7 Then '--> Pyme  
                    If CboProducto.SelectedValue = 6 Then
                        Me.CboProducto.SelectedValue = 6
                    Else
                        Me.CboProducto.SelectedValue = iProceso
                        Me.CondicionMontoMinimoPYME() '--Monto Minimo 04022012
                    End If
                    Me.objGuiaEnvio.TarifaPyme_ = True '--> indica q traera tarifa Pyme                                      
                    'Me.RefreshNroDocumento(7)
                ElseIf iProceso = 8 Then '--> Masiva
                    objGuiaEnvio.TarifaPyme_ = False
                    Me.CboProducto.SelectedValue = iProceso
                    objGuiaEnvio.TarifaMasiva_ = True
                    'Me.RefreshNroDocumento(8)
                ElseIf iProceso = 10 Then '------> Normal Or (iProceso = 7 And ds.Tables(0).Rows(0).Item("codigo_cliente") <> TxtCliente.Text.Trim)
                    objGuiaEnvio.TarifaPyme_ = False
                    If CboProducto.SelectedValue = 6 Then
                        Me.CboProducto.SelectedValue = 6
                    ElseIf CboProducto.SelectedValue = 8 Then 'And bTieneLineaCredito = False Then
                        Me.CboProducto.SelectedValue = 8
                    Else
                        Me.CboProducto.SelectedValue = iProceso
                    End If
                ElseIf iProceso = 81 Or iProceso = 82 Then
                    objGuiaEnvio.TarifaPyme_ = False
                    objGuiaEnvio.TarifaMasiva_ = False
                    objGuiaEnvio.TarifaBox_ = True
                    Me.CboProducto.SelectedValue = iProceso
                    'Me.RefreshNroDocumento(0)
                End If
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            End If
        End If
        '********************************************************

        'Me.TxtNroDocCliente.Tag = ds.Tables(0).Rows(0).Item("idpersona")
        If bNuevo Then
            Me.TxtNroDocCliente.Text = ds.Tables(0).Rows(0).Item("nu_docu_suna").ToString.Trim
            Me.TxtNomCliente.Text = ds.Tables(0).Rows(0).Item("razon_social").ToString.Trim
            Me.TxtTelfCliente.Text = IIf(IsDBNull(dtCliente.Rows(0).Item("telefono")), "", dtCliente.Rows(0).Item("telefono"))
        End If

        '--recuperando datos cliente--
        sNombresCli = IIf(IsDBNull(dtCliente.Rows(0).Item("nombres")), "", dtCliente.Rows(0).Item("nombres"))
        sApCli = IIf(IsDBNull(dtCliente.Rows(0).Item("ap")), "", dtCliente.Rows(0).Item("ap"))
        sAmCli = IIf(IsDBNull(dtCliente.Rows(0).Item("am")), "", dtCliente.Rows(0).Item("am"))
        sTelfCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("telefono")), "", dtCliente.Rows(0).Item("telefono"))
        sRazonSocialCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("razon_social")), "", dtCliente.Rows(0).Item("razon_social"))
        iID_TipoDocCli = ds.Tables(0).Rows(0).Item("tipo").ToString.Trim
        sEmail = IIf(IsDBNull(dtCliente.Rows(0).Item("Email")), "", dtCliente.Rows(0).Item("Email"))

        With Me.CboDireccion
            dtDireccion = ds.Tables(1)
            .DataSource = dtDireccion
            .DisplayMember = "direccion"
            .ValueMember = "iddireccion_consignado"
            If bNuevo Then
                If .Items.Count > 2 Then
                    .SelectedIndex = 0
                    .DroppedDown = True
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
            End If
        End With

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

        With Me.CboRemitente
            dtRemitente = ds.Tables(3).Copy
            dtRemitenteParalelo = ds.Tables(3).Copy
            .DataSource = dtRemitente
            .DisplayMember = "nombres"
            .ValueMember = "idcontacto_persona"
            If .Items.Count > 2 Then
                .SelectedIndex = 0
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
            Else
                .SelectedIndex = 1
            End If
            Me.ChkCliente.Tag = DBNull.Value
        End With

        ' AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged

        If TipoComprobante = 1 Then
            CboContacto.Enabled = True
            ChkCliente1.Enabled = True
        End If

        If Me.CboProducto.SelectedValue <> 6 Then  'solo aplica para tepsa encomiendas y tepsa courier office
            'hlamas 22-03-2016
            'verifica si cliente tiene devolucion de cargo por defecto
            Dim obj As New Cls_ClienteCargo_LN
            Dim intTipo As Integer = 2
            Dim intDevCargo As Integer = obj.DevolucionCargo(intTipo, iID_Persona)
            If intDevCargo >= 1 Then
                If Me.chkDocumentoCliente.Checked = False Then
                    Me.chkDocumentoCliente.Checked = True
                    Me.rbtCargoSi.Checked = True
                Else
                    If Me.rbtCargoSi.Checked = False Then
                        Me.rbtCargoSi.Checked = True
                    End If
                End If
            Else
                If Me.chkDocumentoCliente.Checked Then
                    Me.chkDocumentoCliente.Checked = False
                End If
            End If
        End If
        '----------------------------------------------------------

        '01/09/2011
        'Informa si el cliente tiene crédito y va a emitir PCE
        If bNuevo Then
            If Me.CboTipo.SelectedValue = 1 AndAlso bTieneLineaCredito Then
                Dim sMje As String
                sMje = "El Cliente tiene Línea de Crédito." & vbCrLf
                sMje &= "¿Está Seguro de Emitir un Pago Contraentrega?"
                Dim dlgRespuesta As DialogResult
                dlgRespuesta = MessageBox.Show(sMje, "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.No Then
                    Dim sNumeroDocumento As String = Me.TxtNroDocCliente.Text.Trim
                    Me.CboTipo.SelectedValue = 2
                    Me.RbtDocumento.Checked = True
                    Me.TxtCliente.Text = sNumeroDocumento
                    Me.BuscarClienteCredito()
                End If
            End If
        End If
        'hlamas 21-01-2016
        fnTarifario()

        '-->10/09/2013 ajabanto - Implemetación de la funcionalidad del DT(Documento de transporte) utilizado por Quimica suiza.
        '->Solo se visualiza cuando el cliente es Química Suiza
        'If Me.CboTipo.SelectedIndex = 0 Then
        '    ID_PERSONA_QUIMICA_SUIZA = -10
        'Else
        '    ID_PERSONA_QUIMICA_SUIZA = 1290
        'End If
        'txtdt.Clear()
        'lbldt.Visible = (iID_Persona = ID_PERSONA_QUIMICA_SUIZA And CboCiudad_Origen.SelectedValue = 5100)
        'txtdt.Visible = (iID_Persona = ID_PERSONA_QUIMICA_SUIZA And CboCiudad_Origen.SelectedValue = 5100)
        'TxtTelfCliente.Size = IIf(iID_Persona = ID_PERSONA_QUIMICA_SUIZA, New Size(120, 20), New Size(329, 20))
        'IIf(iID_Persona = ID_PERSONA_QUIMICA_SUIZA, txtdt.Focus, TxtConsignado.Focus)

        'hlamas 07-02-2019
        If Me.CboTipo.SelectedIndex = 0 Then
            ID_PERSONA_CBC = -10
        Else
            ID_PERSONA_CBC = 2153948
        End If

        txtdt.Clear()
        lblDT.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        txtdt.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        Me.dtpFechaRecojo.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        TxtTelfCliente.Size = IIf(iID_Persona = ID_PERSONA_CBC, New Size(86, 20), New Size(329, 20))
        IIf(iID_Persona = ID_PERSONA_CBC, txtdt.Focus, TxtConsignado.Focus)
    End Sub

    Dim bClienteModificado, bDireccionModificada, bContactoModificado, bRemitenteModificado As Boolean
    Dim NombresCliente, apellPatCli, apellMatCli, TelfCliente As String '--------------->cliente
    Dim NombresCont, apellPatCont, apellMatCont As String '----------------------------->contacto
    Dim iID_TipoDocCont As Integer = 0
    'distrito
    Dim iDepartamentoCli, iProvinciaCli, iDistritoCli, IDviaCli, id_NivelCli, id_ZonaCli, id_ClasificacionCli, FormatoCli As Integer
    Dim ViaCli, ManzanaCli, loteCli, NivelCli, ZonaCli, NroCli, ClasificacionCli As String
    Private Sub CargarCliente(ByVal frm As FrmCliente3)

        RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
        Me.TxtNroDocCliente.Text = frm.TxtNumero.Text
        AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged

        Me.TxtNomCliente.Text = frm.TxtCliente.Text & " " & frm.TxtAPCliente.Text & " " & frm.TxtAMCliente.Text
        Me.TxtTelfCliente.Text = frm.txtTelefono.Text
        '--
        bClienteModificado = frm.bClienteModificado
        bDireccionModificada = frm.bDireccionModificada
        bContactoModificado = frm.bContactoModificado
        bRemitenteModificado = frm.bRemitenteModificado
        '--
        '-----datos cliente-------------------------  
        iID_TipoDocCli = frm.CboTipoDocumento.SelectedValue
        If iID_TipoDocCli = 1 Then
            sRazonSocialCliente = frm.TxtCliente.Text
            sNombresCli = ""
        Else
            sRazonSocialCliente = frm.TxtCliente.Text
            sNombresCli = frm.TxtCliente.Text
        End If
        sApCli = frm.TxtAPCliente.Text
        sAmCli = frm.TxtAMCliente.Text
        sTelfCliente = frm.txtTelefono.Text
        sEmail = frm.TxtEmail.Text.Trim '07092011

        Dim IntTipoFacturacion As Integer
        If Me.CboTipo.SelectedIndex = 0 Then
            IntTipoFacturacion = 0
        ElseIf bNuevo = False Then
            IntTipoFacturacion = dtCliente.Rows(0).Item("idtipo_facturacion")
        End If
        '---------------------------------------------
        RemoveHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
        RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
        If frm.TabCliente.SelectedIndex = 0 Then
            Me.TxtNroDocCliente.Text = frm.TxtNumero.Text.Trim
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.Buscar(frm.TxtNumero.Text, 1, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias)
            dtCliente = ds.Tables(0)
            Me.Mostrar(ds)
            Me.ChkCliente.Checked = True
            Me.ChkCliente1.Checked = True
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
            dtCliente.Columns.Add(New DataColumn("Email", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("idtipo_facturacion", GetType(Integer))) '

            dr = dtCliente.NewRow
            dr("idpersona") = 0
            dr("razon_social") = frm.TxtCliente.Text & " " & frm.TxtAPCliente.Text & " " & frm.TxtAMCliente.Text
            dr("tipo") = frm.CboTipoDocumento.SelectedValue
            dr("nu_docu_suna") = frm.TxtNumero.Text.Trim
            dr("nombres") = frm.TxtCliente.Text.Trim
            dr("ap") = frm.TxtAPCliente.Text.Trim
            dr("am") = frm.TxtAMCliente.Text.Trim
            dr("telefono") = frm.txtTelefono.Text.Trim
            dr("Email") = frm.TxtEmail.Text.Trim '
            dr("idtipo_facturacion") = IntTipoFacturacion
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
                    'Dim sDireccion As String = frm.CboVia.Text & " " & frm.TxtVia.Text.Trim & " "
                    Dim sDireccion As String = IIf(frm.CboVia.SelectedValue = 0, "", frm.CboVia.Text) & " " & IIf(frm.CboVia.SelectedValue = 0, "", frm.TxtVia.Text.Trim) & " " 'Cambio 03102011
                    'sDireccion = Trim(sDireccion)

                    If frm.CboVia.SelectedValue > 0 And frm.TxtNumero2.Text.Trim.Length > 0 Then
                        sDireccion &= frm.TxtNumero2.Text.Trim & " "
                    End If

                    If frm.TxtManzana.Text.Trim.Length > 0 Then
                        sDireccion &= "MZ " & frm.TxtManzana.Text.Trim & " LT " & frm.TxtLote.Text.Trim & " "
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

            If frm.bContactoModificado Or IsNothing(dtContacto) Then
                Me.CboContacto.DataSource = Nothing
                Me.CboContacto.Items.Clear()

                'Contacto
                iID_TipoDocCont = frm.CboDocContacto.SelectedValue
                NombresCont = frm.TxtContacto.Text.Trim
                apellPatCont = frm.TxtAPContacto.Text.Trim
                apellMatCont = frm.TxtAMContacto.Text.Trim

                Me.TxtNroDocContacto.Text = frm.txtnrodocumento.Text.Trim
                Me.CboContacto.DataSource = Nothing
                Me.CboContacto.Items.Add(NombresCont & " " & apellPatCont & " " & apellMatCont)
                Me.CboContacto.SelectedIndex = 0

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
                dtContactoParalelo = dtContacto.Copy

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

            If frm.bRemitenteModificado Or IsNothing(dtRemitente) Then
                Me.CboRemitente.DataSource = Nothing
                Me.CboRemitente.Items.Clear()

                'Remitente
                sNroDocRemitente = frm.TxtNumeroRemitente.Text
                iID_TipoDocRemitente = frm.CboDocRemitente.SelectedValue
                sNombreRemitente = frm.TxtRemitente.Text.Trim
                sApRemitente = frm.TxtAPRemitente.Text.Trim
                sAmRemitente = frm.TxtAMRemitente.Text.Trim

                dtRemitente = New DataTable
                dtRemitente.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
                dtRemitente.Columns.Add(New DataColumn("nombres", GetType(String)))
                dtRemitente.Columns.Add(New DataColumn("nombre", GetType(String))) 'new
                dtRemitente.Columns.Add(New DataColumn("idtipo_documento_contacto", GetType(Integer)))
                dtRemitente.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
                dtRemitente.Columns.Add(New DataColumn("apepat", GetType(String)))
                dtRemitente.Columns.Add(New DataColumn("apemat", GetType(String)))

                dr = dtRemitente.NewRow
                dr("idcontacto_persona") = 0
                dr("nombres") = " (SELECCIONE)"
                dr("idtipo_documento_contacto") = 0
                dr("nrodocumento") = ""
                dtRemitente.Rows.Add(dr)

                If frm.TxtRemitente.Text.Trim.Length > 0 Then
                    dr = dtRemitente.NewRow
                    dr("idcontacto_persona") = -1
                    dr("nombres") = sNombreRemitente & " " & sApRemitente & " " & sAmRemitente
                    dr("nombre") = sNombreRemitente 'new                    
                    dr("idtipo_documento_contacto") = frm.CboDocRemitente.SelectedValue
                    dr("nrodocumento") = frm.TxtNumeroRemitente.Text.Trim
                    dr("apepat") = sApRemitente 'new
                    dr("apemat") = sAmRemitente 'new
                    dtRemitente.Rows.Add(dr)
                End If
                dtRemitenteParalelo = dtRemitente.Copy

                AddHandler CboRemitente.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
                Me.CboRemitente.DataSource = dtRemitente
                CboRemitente.DisplayMember = "nombres"
                CboRemitente.ValueMember = "idcontacto_persona"
                Me.CboRemitente.SelectedIndex = IIf(dtRemitente.Rows.Count > 1, 1, 0)

                RemoveHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
                Me.ChkCliente1.Checked = frm.ChkCliente.Checked
                Me.ChkCliente1.Tag = Me.ChkCliente1.Checked
                AddHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
            End If
            If Me.ChkCliente2.Checked Then
                Me.ChkCliente2.Checked = False
                Me.ChkCliente2.Checked = True
            End If
            'hlamas 21-01-2016
            Me.ChkArticulos.Checked = False
            Me.ChkArticulos.Tag = Nothing
            DtArticulos = dtTarifaArticuloPublico
        End If

        If TipoComprobante = 1 Then
            CboContacto.Enabled = True
            ChkCliente1.Enabled = True
            'CboContacto.SelectedIndex = 0
            'Else
            '    ChkCliente1.Enabled = False
            '    CboContacto.Enabled = False
            'CboContacto.SelectedIndex = 0
        End If
        'AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
        AddHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
    End Sub

    '****DIRECCION CLIENTE**
    Dim IdDireccionOrigen As Integer
    Private Sub CboDireccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDireccion.SelectedIndexChanged
        If Not IsReference(CboDireccion.SelectedValue) Then
            If iOpcion = 2 Then
                RemoveHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
                CboDireccion.SelectedValue = IdDireccionOrigen
                AddHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
                Return
            End If

            If Not bDireccionModificada Then
                IdDireccionOrigen = CboDireccion.SelectedValue
            End If
        End If
    End Sub

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


    'FUNCION BUSCAR (CLIENTE CREDITO)PARA EDICION
    Sub BuscarClienteCredito(Optional ByVal opcion As Integer = 0)
        Try
            Dim iOpcion As Integer = IIf(Me.RbtDocumento.Checked, 1, 2)
            Dim frm As New FrmCliente3
            Dim scliente As String = IIf(opcion = 0, Me.TxtCliente.Text.Trim, Me.TxtNroDocCliente.Text)
            Dim iCliente As Integer
            Dim obj As New dtoGuiaEnvio
            Dim ds As DataSet = obj.BuscarClienteCredito(scliente, iOpcion, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias)
            dtCliente = ds.Tables(0)
            bClienteNuevo = True

            If IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                If Not bBoleto Then
                    MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Me.LimpiarCliente()
                    Return
                End If
            ElseIf ds.Tables(0).Rows.Count = 1 Then
                Me.MostrarClienteCredito(ds)
                If Not (iOpcion = 1 And bNuevo = False) Then
                    ChkCliente.Checked = True
                    ChkCliente1.Checked = True
                End If
            Else
                frm.bClienteNuevo = bClienteNuevo
                frm = New FrmCliente3
                frm.iFicha = 0

                frm.cargar(ds.Tables(0), 2)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    ds = obj.BuscarClienteCredito(frm.TxtNumero.Text, 1, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias)
                    dtCliente = ds.Tables(0)
                    Me.MostrarClienteCredito(ds)
                    If Not (iOpcion = 1 And bNuevo = False) Then
                        ChkCliente.Checked = True
                        ChkCliente1.Checked = True
                    End If
                End If
            End If


            'hlamas 13-03-2014
            If Not Me.ChkArticulos.Checked Then
                ClienteProducto(iID_Persona, Me.CboSubCuenta.SelectedValue, Me.CboCiudad_Origen.SelectedValue, idUnidadAgencias)
            End If

            'hlamas 24-02-2014
            ClientePersonalizado(iID_Persona)

            sDocCliente = TxtCliente.Text.Trim
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

    'FUNCION BUSCAR (CLIENTE CREDITO) CUANDO ES MODIFICACION
    Sub BuscarClienteCredito(ByVal NroDocumento As String, ByVal iOpcion As Integer, ByVal CiudadOrigen As Integer, ByVal IdUnidadAgencia As Integer)
        Try
            Dim obj As New dtoGuiaEnvio
            Dim ds As DataSet = obj.BuscarClienteCredito(NroDocumento, iOpcion, CiudadOrigen, IdUnidadAgencia)
            dtCliente = ds.Tables(0)
            If ds.Tables(0).Rows.Count = 1 Then
                Me.MostrarClienteCredito(ds)
            End If

            'hlamas 13-03-2014
            ClienteProducto(iID_Persona, Me.CboSubCuenta.SelectedValue, Me.CboCiudad_Origen.SelectedValue, idUnidadAgencias)

            'hlamas 24-02-2014
            ClientePersonalizado(iID_Persona)

            sDocCliente = TxtCliente.Text.Trim
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

    'FUNCION MOSTRAR DATOS CREDITO
    Sub MostrarClienteCredito(ByVal ds As DataSet)

        If bNuevo Then Me.LimpiarDatosCliente()
        bClienteNuevo = False

        If (dtCliente.Rows(0).Item("Cliente_Corporativo")) = 1 Then
            bTieneLineaCredito = True
            bClienteCredito = True
        Else
            bTieneLineaCredito = False
            bClienteCredito = False
        End If

        '**Articulos**
        DtArticulos = ds.Tables(4).Copy
        If ds.Tables(4).Rows.Count > 0 Then
            ChkArticulos.Enabled = True
        Else
            ChkArticulos.Enabled = False : ChkArticulos.Checked = False
        End If

        '*
        iID_Persona = ds.Tables(0).Rows(0).Item("idpersona")
        Dim iProceso As Integer = ds.Tables(0).Rows(0).Item("id_proceso")
        '*****************************************************************

        'Me.TxtNroDocCliente.Tag = ds.Tables(0).Rows(0).Item("idpersona")
        Me.TxtNroDocCliente.Text = ds.Tables(0).Rows(0).Item("nu_docu_suna").ToString.Trim
        Me.TxtNomCliente.Text = ds.Tables(0).Rows(0).Item("razon_social").ToString.Trim
        Me.TxtTelfCliente.Text = IIf(IsDBNull(dtCliente.Rows(0).Item("telefono")), "", dtCliente.Rows(0).Item("telefono"))

        '--recuperando datos cliente--       
        sNombresCli = IIf(IsDBNull(dtCliente.Rows(0).Item("nombres")), "", dtCliente.Rows(0).Item("nombres"))
        sApCli = IIf(IsDBNull(dtCliente.Rows(0).Item("ap")), "", dtCliente.Rows(0).Item("ap"))
        sAmCli = IIf(IsDBNull(dtCliente.Rows(0).Item("am")), "", dtCliente.Rows(0).Item("am"))
        sTelfCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("telefono")), "", dtCliente.Rows(0).Item("telefono"))
        sRazonSocialCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("razon_social")), "", dtCliente.Rows(0).Item("razon_social"))
        iID_TipoDocCli = ds.Tables(0).Rows(0).Item("tipo").ToString.Trim
        Dim iIDTipoFacturacion As Integer = ds.Tables(0).Rows(0).Item("Idtipo_Facturacion")
        MostrarTipoFacturacion(iIDTipoFacturacion)
        'hlamas 22-3-2016
        'If iIDTipoFacturacion = 3 Then
        '    ChkCargo.Checked = True
        'Else
        '    ChkCargo.Checked = False
        'End If
        If iIDTipoFacturacion = 3 Then
            Me.chkDocumentoCliente.Checked = True
            Me.rbtCargoSi.Checked = True
            Me.rbtCargoNo.Visible = False
        ElseIf bNuevo Then
            Me.chkDocumentoCliente.Checked = False
            Me.rbtCargoSi.Checked = False
            Me.rbtCargoNo.Visible = True
            Me.rbtCargoNo.Checked = False
        End If

        With Me.CboDireccion
            dtDireccion = ds.Tables(1)
            .DataSource = dtDireccion
            .DisplayMember = "direccion"
            .ValueMember = "iddireccion_consignado"

            If bNuevo Then
                If .Items.Count > 2 Then
                    .SelectedIndex = 0
                    .DroppedDown = True
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
            End If
        End With

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

        With Me.CboRemitente
            dtRemitente = ds.Tables(3).Copy
            dtRemitenteParalelo = ds.Tables(3).Copy
            .DataSource = dtRemitente
            .DisplayMember = "nombres"
            .ValueMember = "idcontacto_persona"
            If .Items.Count > 2 Then
                .SelectedIndex = 0
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
            Else
                .SelectedIndex = 1
            End If
            Me.ChkCliente.Tag = DBNull.Value
        End With

        'With Me.CboSubCuenta
        '    DtSubcuenta = ds.Tables(5).Copy
        '    .DataSource = DtSubcuenta
        '    .DisplayMember = "CENTRO_COSTO"
        '    .ValueMember = "IDCENTRO_COSTO"
        '    .SelectedValue = 999
        'End With

        ''-->jabanto - 13/09/2013 - carga la subCuenta origen
        'If (iID_Persona = Cls_Constantes_LN.ID_PERSONA_ECKERD And CboProducto.SelectedValue = Cls_Constantes_LN.ID_PRODUCTO_CARGA_EXPRESA) Then
        '    CboSubCuentaOrigen.Enabled = True
        '    With Me.CboSubCuentaOrigen
        '        DtSubcuenta = ds.Tables(6).Copy
        '        .DataSource = DtSubcuenta
        '        .DisplayMember = "CENTRO_COSTO"
        '        .ValueMember = "IDCENTRO_COSTO"
        '        .SelectedValue = 999
        '    End With
        'Else
        '    CboSubCuentaOrigen.DataSource = Nothing
        '    CboSubCuentaOrigen.Enabled = False
        'End If

        ' AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged

        If TipoComprobante = 1 Then
            CboContacto.Enabled = True
            ChkCliente1.Enabled = True
        End If

        'hlamas 22-03-2016
        If iIDTipoFacturacion <> 3 Then  'solo aplica para tepsa encomiendas y tepsa courier office
            'hlamas 22-03-2016
            'verifica si cliente tiene devolucion de cargo por defecto
            Dim obj As New Cls_ClienteCargo_LN
            Dim intTipo As Integer = 2
            Dim intDevCargo As Integer = obj.DevolucionCargo(intTipo, iID_Persona)
            If intDevCargo >= 1 Then
                If Me.chkDocumentoCliente.Checked = False Then
                    Me.chkDocumentoCliente.Checked = True
                    Me.rbtCargoSi.Checked = True
                Else
                    If Me.rbtCargoSi.Checked = False Then
                        Me.rbtCargoSi.Checked = True
                    End If
                End If
            Else
                If Me.chkDocumentoCliente.Checked Then
                    Me.chkDocumentoCliente.Checked = False
                End If
            End If
        End If
        '----------------------------------------------------------

        '-->10/09/2013 ajabanto - Implemetación de la funcionalidad del DT(Documento de transporte) utilizado por Quimica suiza.
        '->Solo se visualiza cuando el cliente es Química Suiza
        'If Me.CboTipo.SelectedIndex = 0 Then
        '    ID_PERSONA_QUIMICA_SUIZA = -10
        'Else
        '    ID_PERSONA_QUIMICA_SUIZA = 1290
        'End If
        'txtdt.Clear()
        'lbldt.Visible = (iID_Persona = ID_PERSONA_QUIMICA_SUIZA And CboCiudad_Origen.SelectedValue = 5100)
        'txtdt.Visible = (iID_Persona = ID_PERSONA_QUIMICA_SUIZA And CboCiudad_Origen.SelectedValue = 5100)
        'TxtTelfCliente.Size = IIf(iID_Persona = ID_PERSONA_QUIMICA_SUIZA, New Size(120, 20), New Size(329, 20))
        'IIf(iID_Persona = ID_PERSONA_QUIMICA_SUIZA, txtdt.Focus, TxtConsignado.Focus)

        'hlamas 07-02-2019
        txtdt.Clear()
        lblDT.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        txtdt.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        Me.dtpFechaRecojo.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        TxtTelfCliente.Size = IIf(iID_Persona = ID_PERSONA_CBC, New Size(86, 20), New Size(329, 20))
        IIf(iID_Persona = ID_PERSONA_CBC, txtdt.Focus, TxtConsignado.Focus)

        'hlamas 23-09-2013
        If iID_Persona = ID_PERSONA_ECKERD Then
            ControlaSubcuentaOrigen(True)
        Else
            ControlaSubcuentaOrigen(False)
        End If
        'Me.lblSubcuentaOrigen.Visible = iID_Persona = ID_PERSONA_ECKERD
        'Me.CboSubCuentaOrigen.Visible = iID_Persona = ID_PERSONA_ECKERD


    End Sub

#Region "D?"
    'EXISTE EL CLIENTE 
    Private Function FnExisteCliente() As Boolean
        Try
            If ObjVentaCargaContado.fnBuscarCliente(1, Me.TxtNroDocCliente.Text, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias) = True Then
                ObjVentaCargaContado.v_IDPERSONA = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
                If ObjVentaCargaContado.v_IDPERSONA = 0 Then
                    Return False
                Else
                    Return True
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Dim Iid As String
    Dim bBoleto As Boolean = False
    Private Function fnBuscarCliente() As Boolean
        Dim flag As Boolean = False
        Dim iAgenciaOrigen As Integer
        Try
            'b_lee = False
            iAgenciaOrigen = IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad)
            If bOtrasAgencias Then
                iAgenciaOrigen = ObjVentaCargaContado.v_IDUNIDAD_ORIGEN
            End If

            'Buscando El cliente (Control, NroDocumento, RazonSocial, IDAgenciaOrigen,IDCiudadDest) 
            If ObjVentaCargaContado.fnBuscarCliente(1, Me.TxtNroDocCliente.Text, iAgenciaOrigen, idUnidadAgencias) = True Then

                '**********[Verifica si cliente tiene linea de credito]*********************************************              
                Iid = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
                Dim ldt_tmp As New DataTable
                ldt_tmp = sp_linea_credito() '-> llamando el stored Procedure                
                If ldt_tmp.Rows.Count > 0 Then
                    If CType(ldt_tmp.Rows(0).Item("ES_ACTIVO"), Boolean) Then
                        bTieneLineaCredito = True
                    Else
                        bTieneLineaCredito = False
                    End If
                Else
                    bTieneLineaCredito = False
                End If
                flag = True

                '*************************CARGANDO LOS DATOS DEL CLIENTE BUSCADO************************************
                'Codigo cliente
                ObjVentaCargaContado.v_IDPERSONA = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
                If ObjVentaCargaContado.v_IDPERSONA = 0 Then Return False '-> No encontro el cliente

                '-> iProceso = al tipo de Producto q pertenece El NroDocumento del Cliente (NORMAL,PYME)
                Dim iProceso As Integer = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(7)

                'TxtRazonSocialRem.Text = Trim(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(1))
                TxtNomCliente.Text = Trim(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(1))
                's_persona_remitente = TxtRazonSocialRem.Text
                '*************************************************
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
                ElseIf iProceso = 7 Then '--> Pyme  
                    If CboProducto.SelectedValue = 6 Then
                        Me.CboProducto.SelectedValue = 6
                    Else
                        Me.CboProducto.SelectedValue = iProceso
                    End If
                    'Me.TxtTelfConsignado.Focus()
                    Me.objGuiaEnvio.TarifaPyme_ = True '--> indica q traera tarifa Pyme                                      
                ElseIf iProceso = 8 Then '--> Masiva
                    objGuiaEnvio.TarifaPyme_ = False
                    Me.CboProducto.SelectedValue = iProceso
                    objGuiaEnvio.TarifaMasiva_ = True
                End If
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                '**************DATOS CLIENTES************************************************************
                Me.TxtNroDocCliente.Text = Trim(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(6))
                If TxtNroDocCliente.Text = "" Then Return flag
                Me.TxtNroDocCliente.Tag = (ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(5))
                'TxtNroDocRem.Text = Trim(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(6))
                ' Me.TxtTelfCliente.Text = Trim(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(2))
                iControlMonto_Base = Trim(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(3))

                If ObjVentaCargaContado.dt_cur_dire_origen.Rows.Count > 0 Then
                    ObjVentaCargaContado.v_IDDIREECION_ORIGEN = Int(ObjVentaCargaContado.dt_cur_dire_origen.Rows(0).Item(0).ToString)
                    'TxtDirecRem.Text = ObjVentaCargaContado.dt_cur_dire_origen.Rows(0).Item(1).ToString
                Else
                    'TxtDirecRem.Text = ""
                    ObjVentaCargaContado.v_IDDIREECION_ORIGEN = 0
                End If

                '**************CLIENTE TIENE DESCUENTO***************************************************  
                If CboProducto.SelectedValue <> 6 Then '--->Diferente De Carga Acompañada
                    iDescuento = IIf(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(4) <> 0, ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(4), 0)
                    '
                    If iDescuento <> 0 Then
                        iDescuento = iDescuento / 100
                        bDescuento = True
                    Else
                        bDescuento = False
                    End If
                End If

                '**************DATOS CONTACTO*************************************************************
                If ObjVentaCargaContado.dt_cur_cont_origen.Rows.Count > 0 Then
                    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = Int(ObjVentaCargaContado.dt_cur_cont_origen.Rows(0).Item(0).ToString)
                    'TxtRazonSocialCont.Text = Trim(ObjVentaCargaContado.dt_cur_cont_origen.Rows(0).Item(1).ToString)
                    TxtNroDocContacto.Text = Trim(ObjVentaCargaContado.dt_cur_cont_origen.Rows(0).Item(3).ToString)
                    TxtTelfCliente.Text = Trim(ObjVentaCargaContado.dt_cur_cont_origen.Rows(0).Item(5).ToString)
                Else
                    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = 0
                    'TxtRazonSocialCont.Text = ""
                    TxtNroDocContacto.Text = ""
                End If


                '**************DATOS COSIGNADO*************************************************************
                If CboProducto.SelectedValue <> 6 Then '--->Diferente De Carga Acompañada
                    If ObjVentaCargaContado.dt_cur_cont_destino.Rows.Count > 0 Then
                        ObjVentaCargaContado.v_IDCONTACTO_DESTINO = Int(ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item(0).ToString)

                        '****Comentado x NConsignado******
                        'TxtNombConsignado.Text = ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item(1).ToString
                        'TxtNroDocConsignado.Text = ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item(2).ToString
                        'TxtTelfConsignado.Text = ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item(3).ToString
                        '**********************************
                    Else
                        If Not bBoleto Then
                            ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0
                            '****Comentado x NConsignado******
                            'TxtNombConsignado.Text = ""
                            'TxtNroDocConsignado.Text = ""
                        End If
                    End If

                    If ObjVentaCargaContado.dt_cur_dire_destino.Rows.Count > 0 Then
                        ObjVentaCargaContado.v_IDDIREECION_DESTINO = Int(ObjVentaCargaContado.dt_cur_dire_destino.Rows(0).Item(0).ToString)
                        'TxtDirecConsignado.Text = ObjVentaCargaContado.dt_cur_dire_destino.Rows(0).Item(1).ToString
                        'If CboTipoEntrega.Text.Trim <> "AGENCIA" And TxtDirecConsignado.Text.Trim = "AGENCIA" Then TxtDirecConsignado.Text = ""
                    Else
                        'TxtDirecConsignado.Text = ""
                        ObjVentaCargaContado.v_IDDIREECION_DESTINO = 0
                    End If
                End If

            Else
                ObjVentaCargaContado.v_IDPERSONA = 0
                'TxtRazonSocialRem.Text = ""
                ' TxtTelfCliente.Text = ""
                Me.TxtNroDocCliente.Tag = ""

                ObjVentaCargaContado.v_IDPERSONA_ORIGEN = 0
                'TxtRazonSocialCont.Text = ""
                TxtNroDocContacto.Text = ""

                ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0
                '****Comentado x NConsignado****
                'TxtNombConsignado.Text = ""
                'TxtNroDocConsignado.Text = ""

                'TxtDirecRem.Text = ""
                ObjVentaCargaContado.v_IDDIREECION_ORIGEN = 0
                'TxtDirecConsignado.Enabled = True
                'TxtDirecConsignado.Text = ""
                ObjVentaCargaContado.v_IDDIREECION_DESTINO = 0
                s_persona_remitente = ""
            End If
            'If ObjVentaCargaContado.v_IDPERSONA > 0 Then ' Encontro a la persona 
            '    TxtRasonSocialConsig.Focus()
            'End If

            '****************CLIENTE TIENE [ARTICULOS]*******************************
            If ObjVentaCargaContado.dt_cur_Articulos.Rows.Count > 0 Then
                ChkArticulos.Enabled = True
            Else
                ChkArticulos.Enabled = False : ChkArticulos.Checked = False
            End If
            '************************************************************************                       
        Catch ex As Exception
            Throw New Exception(ex.Message)
            flag = False
        End Try
        Return flag
    End Function

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
            Throw New Exception(ex.Message)
        End Try
    End Function

    Dim TipoComprobante As Integer
    Dim bIngresa As Boolean
    Private Function fnVALIDARDOCUMENTOS() As Boolean
        Try
            If TxtNroDocCliente.Text.Length = 11 Then
                If fnValidarRUC(TxtNroDocCliente.Text.ToString) Then
                    TipoComprobante = 3
                    If CboProducto.SelectedValue <> 6 Then '--->Diferente De Carga Acompañada (para mantener la tarifa de carga acompañada)               
                        fnTarifario()
                        ' Me.NewfnTarifario()
                        'hlamas 11-03-2019
                        'If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante) = True Then
                        '    '*********Quitar Error**************************************  
                        '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                        '    Return True
                        'Else
                        '    Return False
                        'End If
                    Else
                        If CboProducto.SelectedValue <> 6 Then
                            'hlamas 11-03-2019
                            'If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante) = True Then
                            '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                            '    Return True
                            'Else
                            '    Return False
                            'End If
                        End If
                    End If
                Else
                    '*********Añadir Error*************************************                  
                    Me.LimpiarDatosCliente()
                    '**********************************************************                                   
                    TxtNroDocCliente.SelectAll()
                    TxtNroDocCliente.Focus()
                    TipoComprobante = 3
                    Return False
                End If
            ElseIf TxtNroDocCliente.Text.Length = 8 Or bIngresa Then
                If CboProducto.SelectedValue <> 6 Then
                    If flagPCEVALIDADOC = False Then
                        fnTarifario()
                        '  Me.NewfnTarifario()
                    End If
                End If
                'Dim vals As String = TxtRazonSocialRem.Text
                TxtNroDocContacto.Text = ""
                'TxtRazonSocialCont.Text = ""

                TipoComprobante = 3
                'hlamas 11-03-2019
                'If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante) = True Then
                '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                '    Return True
                'Else
                '    Return False
                'End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
            Throw New Exception(ex.Message)
        End Try
    End Function

    Function fb_buscar_cliente() As Boolean
        Try
            Dim lb_retorna As Boolean
            lb_retorna = False
            If BuscarClientesGuia_Envio() = True Then
                lb_retorna = True
                fnTarifario()
            End If

            Return lb_retorna
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Dim CONTROL As Integer = 3
    Public iWinContacto_Remitente As New AutoCompleteStringCollection
    Public iWinDireccion_Remitente As New AutoCompleteStringCollection
    Public iWinDireccion_Destinatario As New AutoCompleteStringCollection
    Public iWinContacto_Destinatario As New AutoCompleteStringCollection
    Public iWinPersonaDNI_Remite As New AutoCompleteStringCollection
    Public iWinPersonaDNI_Destino As New AutoCompleteStringCollection
    Private Function BuscarClientesGuia_Envio() As Boolean
        Dim flag As Boolean = False
        Try
            If CONTROL = 4 Then
                CONTROL = 1
            End If

            objGuiaEnvio.iControl_Busqueda = CONTROL
            If CONTROL <> 2 Then
                objGuiaEnvio.iIDPERSONA = 0
            End If

            'TxtGuiaEnvio.Text = RellenoRight(NroDigitos_Guias, TxtGuiaEnvio.Text)

            If TxtCiudadDestino.Text <> "" Then
                objGuiaEnvio.iIDUNIDAD_AGENCIA = IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad)
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = CodCiudadDest_
            Else
                objGuiaEnvio.iIDUNIDAD_AGENCIA = 999
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 999
            End If

            If objGuiaEnvio.iIDUNIDAD_AGENCIA = objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO Then
                Return flag
            End If

            'If Me.TxtGuiaEnvio.Text <> "" And TxtGuiaEnvio.Text.Length() > 0 And bControl_Busqueda = False Then
            '    objGuiaEnvio.sNRO_GUIA = TxtGuiaEnvio.Text
            'Else
            objGuiaEnvio.sNRO_GUIA = "@"
            'End If

            Dim indexof As Integer = 0
            'If iWinPersona.Count > 0 Then
            indexof = iWinPersona.IndexOf(TxtNomCliente.Text) 'filtrado x razon Social
            objGuiaEnvio.iIDPERSONA = -1
            If indexof = -1 Then indexof = iWinPersonaRUC.IndexOf(TxtNroDocCliente.Text) 'filtrado x Nro Ruc

            If indexof >= 0 Then
                objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA

                'Recupera los datos 
                If indexof <= iWinPersonaRUC.Count Then
                    Me.TxtNroDocCliente.Text = iWinPersonaRUC.Item(indexof)
                    Me.li_iDigitosSerie = iwinNro_digito_serie_cliente.Item(indexof)
                    Me.objGuiaEnvio.iID_REMITENTE = objGuiaEnvio.iIDPERSONA
                    Me.objGuiaEnvio.iREMITENTE = TxtNomCliente.Text
                    Me.objGuiaEnvio.iNRODOC_REM = TxtNroDocCliente.Text
                    Me.bControl_Busqueda = True
                    bTieneLineaCredito = True
                End If
            Else
                MessageBox.Show("El cliente no tiene línea de crédito, revise sus datos", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'End If


            If objGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC() = True Then
                flag = True
                Me.TxtNroDocCliente.Text = objGuiaEnvio.sNU_DOCU_SUNAT.ToString
                Me.TxtNomCliente.Text = objGuiaEnvio.sRASON_SOCIAL.ToString
                'Me.TxtRazonSocialRem.Text = TxtRasonSocialCliente.Text
                'Me.TxtNroDocRem.Text = TxtNroDocCliente.Text

                'hlamas 22-03-2016
                'If objGuiaEnvio.iIDTipoFacturacion = 3 Then
                '    ChkCargo.Checked = True
                'Else
                '    ChkCargo.Checked = False
                'End If
                MostrarTipoFacturacion(objGuiaEnvio.iIDTipoFacturacion)
                If objGuiaEnvio.iIDTipoFacturacion = 3 Then
                    Me.chkDocumentoCliente.Checked = True
                    Me.rbtCargoSi.Checked = True
                    Me.rbtCargoNo.Visible = False
                Else
                    Me.chkDocumentoCliente.Checked = False
                    Me.rbtCargoSi.Checked = False
                    Me.rbtCargoNo.Visible = True
                    Me.rbtCargoNo.Checked = False
                End If

                '*************LLenando la Subcuenta************
                If objGuiaEnvio.dt_cur_Sub_Cuenta.Rows.Count > 0 Then
                    ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_cur_Sub_Cuenta, CboSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, objGuiaEnvio.iIDCENTRO_COSTO)
                    CboSubCuenta.SelectedIndex = 0
                End If


                '*******Obteniendo Los Datos Del Contacto******
                If objGuiaEnvio.dt_cur_Nombres_Remitente.Rows.Count > 0 Then
                    objGuiaEnvio.iIDCONTACTO_PERSONA = Int(objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(0).ToString)
                    'TxtRazonSocialCont.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(1).ToString
                    TxtNroDocContacto.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(2).ToString
                Else
                    objGuiaEnvio.iIDCONTACTO_PERSONA = -1
                    'TxtRazonSocialCont.Text = ""
                    Me.TxtNroDocContacto.Text = ""
                End If

                '*******Obteniendo Los Datos Del Remitente*****
                'fnCargar_iWin2(TxtRazonSocialCont, objGuiaEnvio.dt_cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPersonaDNI_Remite)
                If objGuiaEnvio.dt_cur_Direccion_Remitente.Rows.Count > 0 Then
                    objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(0).ToString)
                    'TxtDirecRem.Text = objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(1).ToString
                Else
                    'TxtDirecRem.Text = ""
                    objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
                End If
                'fnCargar_iWin_dt(TxtDirecRem, objGuiaEnvio.dt_cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
                Me.TxtTelfCliente.Text = ""


                '*******Obteniendo Los Datos Del Consignado*****
                objGuiaEnvio.iIDTEFONO_REMITENTE = -1
                If objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows.Count > 0 Then
                    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(0).ToString)
                    '***Comentado x NConsignado*****************************
                    'TxtNombConsignado.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(1).ToString
                    'TxtNroDocConsignado.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(2).ToString
                    '*******************************************************
                Else
                    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = -1
                    'TxtNombConsignado.Text = ""
                    'TxtNroDocConsignado.Text = ""
                End If

                '***Comentado x NConsignado****************
                'fnCargar_iWin2(TxtNombConsignado, objGuiaEnvio.dt_cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO, iWinPersonaDNI_Destino)
                Dim idTipoDire As Integer = 0
                If idTipoDire = 2 Then
                    If objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows.Count > 0 Then
                        objGuiaEnvio.iIDDIRECCION_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(0).ToString)
                        'TxtDirecConsignado.Text = objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(1).ToString
                    Else
                        objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
                        'TxtDirecConsignado.Text = ""
                    End If
                    'fnCargar_iWin_dt(Me.TxtDirecConsignado, objGuiaEnvio.dt_cur_Direccion_Destinatario, objGuiaEnvio.coll_Direccion_Destinatario, iWinDireccion_Destinatario, objGuiaEnvio.iIDDIRECCION_DESTINATARIO)
                End If

                If objGuiaEnvio.dt_rst_Articulos.Rows.Count > 0 Then
                    ChkArticulos.Enabled = True
                Else
                    ChkArticulos.Enabled = False : ChkArticulos.Checked = False
                End If

                'TxtTelfConsignado.Text = ""
                objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1


                TxtSubTotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"
            Else
                flag = False
            End If
        Catch ex As Exception
            flag = False
            Throw New Exception(ex.Message)
        End Try
        Return flag
    End Function

    Private Sub CARGAR_DATOS_CLIENTE()
        BuscarClientesGuia_EnvioCC()
    End Sub

    Dim iWinCLIENTE_Remitente As New AutoCompleteStringCollection
    Dim iWinCLIENTEDNI_Remite As New AutoCompleteStringCollection
    Private Function BuscarClientesGuia_EnvioCC() As Boolean
        Dim flag As Boolean = False
        Try
            If CONTROL = 4 Then
                CONTROL = 1
            End If
            '***********************Parametros**********************************
            objGuiaEnvio.iControl_Busqueda = CONTROL
            If CONTROL <> 2 Then
                objGuiaEnvio.iIDPERSONA = 0
            End If
            'TxtGuiaEnvio.Text = RellenoRight(NroDigitos_Guias, TxtGuiaEnvio.Text)
            If TxtCiudadDestino.Text <> "" Then
                objGuiaEnvio.iIDUNIDAD_AGENCIA = IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad)
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = CodCiudadDest_
            Else
                objGuiaEnvio.iIDUNIDAD_AGENCIA = 999
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 999
            End If

            'If Me.TxtGuiaEnvio.Text <> "" And TxtGuiaEnvio.Text.Length() > 0 And bControl_Busqueda = False Then
            '    objGuiaEnvio.sNRO_GUIA = TxtGuiaEnvio.Text
            'Else
            '    objGuiaEnvio.sNRO_GUIA = "@"
            'End If
            '*******************************************************************

            CONTROL = 2
            Dim indexof As Integer = 0
            If iWinPersona.Count > 0 Then
                'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
                indexof = iWinPersonaRUC.IndexOf(TxtNroDocCliente.Text)
                objGuiaEnvio.iIDPERSONA = -1
                If indexof >= 0 Then
                    objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                    objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA
                    If indexof <= iWinPersona.Count Then
                        Me.TxtNomCliente.Text = iWinPersona.Item(indexof)
                        objGuiaEnvio.iID_REMITENTE = objGuiaEnvio.iIDPERSONA
                        objGuiaEnvio.iREMITENTE = TxtNomCliente.Text
                        objGuiaEnvio.iNRODOC_REM = Me.TxtNroDocCliente.Text
                        bControl_Busqueda = True
                    End If
                Else
                    MessageBox.Show("El Cliente no tiene línea de crédito, revise sus datos", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If


            objGuiaEnvio.iIDCENTRO_COSTO = CboSubCuenta.SelectedValue

            If objGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC_CC() = True Then
                flag = True
                Me.TxtNroDocCliente.Text = objGuiaEnvio.sNU_DOCU_SUNAT.ToString
                Me.TxtNomCliente.Text = objGuiaEnvio.sRASON_SOCIAL.ToString

                'TxtRazonSocialRem.Text = TxtRasonSocialCliente.Text
                'TxtNroDocRem.Text = TxtNroDocCliente.Text

                'lbTipoFacturacion.Text = objGuiaEnvio.iIDTipoFacturacion.ToString

                'hlamas 22-03-2016
                'If objGuiaEnvio.iIDTipoFacturacion = 3 Then
                '    ChkCargo.Checked = True
                'Else
                '    ChkCargo.Checked = False
                'End If
                MostrarTipoFacturacion(objGuiaEnvio.iIDTipoFacturacion)
                If objGuiaEnvio.iIDTipoFacturacion = 3 Then
                    Me.chkDocumentoCliente.Checked = True
                    Me.rbtCargoSi.Checked = True
                    Me.rbtCargoNo.Visible = False
                Else
                    Me.chkDocumentoCliente.Checked = False
                    Me.rbtCargoSi.Checked = False
                    Me.rbtCargoNo.Visible = True
                    Me.rbtCargoNo.Checked = False
                End If

                objGuiaEnvio.coll_Nombres_CLIENTE_REMITENTE.Clear()
                '*****Recuperando Datos Remitente***************************
                If objGuiaEnvio.dt_cur_CLIENTE_REMITENTE.Rows.Count > 0 Then
                    objGuiaEnvio.iID_REMITENTE = Int(objGuiaEnvio.dt_cur_CLIENTE_REMITENTE.Rows(0).Item(0).ToString)
                    'TxtRazonSocialRem.Text = objGuiaEnvio.dt_cur_CLIENTE_REMITENTE.Rows(0).Item(1).ToString
                    'TxtNroDocRem.Text = objGuiaEnvio.dt_cur_CLIENTE_REMITENTE.Rows(0).Item(2).ToString
                    'fnCargar_iWin2_dt2(TxtRazonSocialRem, objGuiaEnvio.dt_cur_CLIENTE_REMITENTE, objGuiaEnvio.coll_Nombres_CLIENTE_REMITENTE, iWinCLIENTE_Remitente, objGuiaEnvio.iID_REMITENTE, iWinCLIENTEDNI_Remite)
                Else
                    objGuiaEnvio.iID_REMITENTE = -1
                    'TxtRazonSocialRem.Text = ""
                    'Me.TxtNroDocRem.Text = ""
                    'fnCargar_iWin2_dt2(TxtRazonSocialRem, objGuiaEnvio.dt_cur_CLIENTE_REMITENTE, objGuiaEnvio.coll_Nombres_CLIENTE_REMITENTE, iWinCLIENTE_Remitente, objGuiaEnvio.iID_REMITENTE, iWinCLIENTEDNI_Remite)
                End If

                objGuiaEnvio.coll_Direccion_Remitente.Clear()
                If objGuiaEnvio.dt_cur_Direccion_Remitente.Rows.Count > 0 Then
                    objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(0).ToString)
                    'TxtDirecRem.Text = objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(1).ToString
                    'fnCargar_iWin_dt(TxtDirecRem, objGuiaEnvio.dt_cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
                Else
                    'TxtDirecRem.Text = ""
                    objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
                    'fnCargar_iWin_dt(TxtDirecRem, objGuiaEnvio.dt_cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
                End If

                '*****Recuperando Datos Contacto****************************
                objGuiaEnvio.coll_Nombres_Remitente.Clear()
                If objGuiaEnvio.dt_cur_Nombres_Remitente.Rows.Count > 0 Then
                    objGuiaEnvio.iIDCONTACTO_PERSONA = Int(objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(0).ToString)
                    'TxtRazonSocialCont.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(1).ToString
                    TxtNroDocContacto.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(2).ToString
                    'fnCargar_iWin2_dt2(TxtRazonSocialCont, objGuiaEnvio.dt_cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPersonaDNI_Remite)
                Else
                    objGuiaEnvio.iIDCONTACTO_PERSONA = -1
                    'TxtRazonSocialCont.Text = ""
                    Me.TxtNroDocContacto.Text = ""
                    'fnCargar_iWin2_dt2(TxtRazonSocialCont, objGuiaEnvio.dt_cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPersonaDNI_Remite)
                End If

                Me.TxtTelfCliente.Text = ""
                objGuiaEnvio.iIDTEFONO_REMITENTE = -1

                '*****Recuperando Datos Consignado*****************************
                If objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows.Count > 0 Then
                    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(0).ToString)
                    '***Comentado x NConsignado**********
                    'TxtNombConsignado.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(1).ToString
                    'TxtNroDocConsignado.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(2).ToString
                    'fnCargar_iWin2_dt2(TxtNombConsignado, objGuiaEnvio.dt_cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO, iWinPersonaDNI_Destino)
                    '*************************************
                Else
                    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = -1
                    '***Comentado x NConsignado*****
                    'TxtNombConsignado.Text = ""
                    'TxtNroDocConsignado.Text = ""
                    '*******************************
                End If

                If CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                    If objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows.Count > 0 Then
                        objGuiaEnvio.iIDDIRECCION_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(0).ToString)
                        'TxtDirecConsignado.Text = objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(1).ToString
                        'fnCargar_iWin_dt(Me.TxtDirecConsignado, objGuiaEnvio.dt_cur_Direccion_Destinatario, objGuiaEnvio.coll_Direccion_Destinatario, iWinDireccion_Destinatario, objGuiaEnvio.iIDDIRECCION_DESTINATARIO)
                    Else
                        objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
                        'TxtDirecConsignado.Text = ""
                    End If
                End If

                '**Comentado x NConsignado
                'TxtTelfConsignado.Text = ""
                objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1

                TxtSubTotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"


                If objGuiaEnvio.dt_rst_Articulos.Rows.Count > 0 Then
                    ChkArticulos.Enabled = True
                End If

            Else
                'Call ClearData()               
                flag = False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
            flag = False
        End Try
        Return flag
    End Function

    Private Sub cargar_articulos()
        Try
            Dim idPersona As Integer = iWinPersona.IndexOf(TxtNomCliente.Text)

            '**********Parametros*******************************************************
            objGuiaEnvio.iIDCENTRO_COSTO = Int(objGuiaEnvio.coll_Sub_Cuenta.Item(CboSubCuenta.SelectedIndex.ToString))
            objGuiaEnvio.iIDUNIDAD_AGENCIA = IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad)
            objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = CodCiudadDest_
            objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas.Item(idPersona.ToString))
            '***************************************************************************

            '********Devuelve true si la subcuenta tiene Articulos**********************
            If objGuiaEnvio.fnSP_CONSULTA_ARTI_SUB_CUENTA() = True Then
                ChkArticulos.Enabled = True
            Else
                ChkArticulos.Enabled = False
            End If

            '***************************************************************************
            For i As Integer = 0 To GrdDetalleVenta.RowCount - 2
                GrdDetalleVenta(2, i).Value() = "0.00"
                GrdDetalleVenta(4, i).Value() = "0.00"
            Next
            TxtSubTotal.Text = "0.00"
            TxtImpuesto.Text = "0.00"
            TxtTotal.Text = "0.00"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Dim bTieneLineaCredito As Boolean = False
    Dim bCargaAcompañada2 As Boolean = False
    Dim bControl_Tarifas As Boolean = False
    Dim iControlMonto_Base As Double = 1
    Dim tarifa_Articulo As Double = 0
    Dim tarifa_Volumen As Double = 0
    Dim tarifa_Sobre As Double = 0
    Dim tarifa_Peso As Double = 0
    Dim iDescuento As Double = 0
    Dim iTarifa As Integer = 0
    Dim bDescuento As Boolean
    Public objGuiaEnvio As New dtoGuiaEnvio
    Public Function fnTarifario() As Boolean
        Dim flag As Boolean = False
        Try
            bControl_Tarifas = False
            tarifa_Peso = 0
            tarifa_Volumen = 0
            tarifa_Articulo = 0
            Monto_Base = 0
            tarifa_Sobre = 0

            'If CboProducto.SelectedValue = 8 Then objGuiaEnvio.TarifaMasiva_ = True
            If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER Then objGuiaEnvio.TarifaMasiva_ = True
            If CboProducto.SelectedValue = ID_PRODUCTO_PYME Then objGuiaEnvio.TarifaPyme_ = True
            '********************Parametros*************************************************************
            objGuiaEnvio.iIDUNIDAD_AGENCIA = IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad)
            objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = idUnidadAgencias 'CodCiudadDest_
            objGuiaEnvio.TipoProducto_ = CboProducto.SelectedValue
            'objGuiaEnvio.TipoTarifa_ = IIf(CboTipoTarifa.SelectedIndex = -1, 0, CboTipoTarifa.SelectedIndex)
            If IsNumeric(CboTipoTarifa.SelectedValue) Then
                objGuiaEnvio.TipoTarifa_ = CboTipoTarifa.SelectedValue
            Else
                objGuiaEnvio.TipoTarifa_ = 0
            End If
            objGuiaEnvio.sNU_DOCU_SUNAT = IIf(Me.TxtNroDocCliente.Text <> "", Me.TxtNroDocCliente.Text, "@")
            objGuiaEnvio.iIDCENTRO_COSTO = IIf(CboSubCuenta.SelectedValue Is Nothing, 999, CboSubCuenta.SelectedValue)
            objGuiaEnvio.iIPRODUCTO = IIf(CboProducto.SelectedValue Is Nothing, 0, CboProducto.SelectedValue)
            '*******************************************************************************************'
            'Listando la tarifa corporativa (ciudad origen, ciudad  destino, cliente)     no incluye igv
            '*******************************************************************************************'           
            'If (CboTipoTarifa.SelectedIndex = 0 Or CboTipo.SelectedValue = 2) AndAlso Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
            objGuiaEnvio.iTipo = Me.CboTipo.SelectedValue
            If CboTipo.SelectedValue = 2 AndAlso Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
                bTarifarioGeneral = False
                tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Sobre
                iTarifa = objGuiaEnvio.iTarifa

                'hlamas 07/05/2015
                objGuiaEnvio.iPeso_Maximo = objGuiaEnvio.iPeso_Maximo
                objGuiaEnvio.iVol_Maximo = 0 'objGuiaEnvio.iVol_Maximo
                objGuiaEnvio.iPrecio_cond_Peso = objGuiaEnvio.iPrecio_cond_Peso
                objGuiaEnvio.iPrecio_cond_Vol = 0 'objGuiaEnvio.iPrecio_cond_Vol
                objGuiaEnvio.CondicionTarifa_ = False

                If (objGuiaEnvio.iPeso_Maximo > 0) Then
                    objGuiaEnvio.UnidadPeso_ = "PESO"
                    objGuiaEnvio.iPeso_Minimo = 0.01
                    objGuiaEnvio.CondicionTarifa_ = True
                End If
                If (objGuiaEnvio.iVol_Maximo > 0) Then
                    objGuiaEnvio.UnidadVol_ = "VOL"
                    objGuiaEnvio.iVol_Minimo = 0.01
                    objGuiaEnvio.CondicionTarifa_ = True
                End If

                GrdDetalleVenta("Costo", 0).Value = tarifa_Peso
                GrdDetalleVenta("Costo", 1).Value = tarifa_Volumen
                GrdDetalleVenta("Costo", 2).Value = tarifa_Sobre

                If iControlMonto_Base = 1 Then
                    GrdDetalleVenta("Costo", 3).Value = Monto_Base
                    GrdDetalleVenta("Sub Neto", 3).Value = Monto_Base
                End If

                flag = True
                bControl_Tarifas = True
                bContado = False

                'ElseIf objGuiaEnvio.fnTARIFA_PUBLICA_CARGA2() = True Then
            ElseIf objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO > 0 Then
                '*******************************************************************************************'
                'Tarifa publica (ciudad origen, ciudad destino)                   incluye igv
                '*******************************************************************************************'
                Dim tarifaCarga As New dtoTarifasCargo
                Dim objVentaContado As New dtoVentaCargaContado

                Dim intTipoEntrega As Integer = 0
                If Me.CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Or Me.CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                    intTipoEntrega = Me.CboTipoEntrega.SelectedValue
                End If

                'hlamas 21-01-2016
                tarifaCarga = ObjVentaCargaContado.ObtenerTarifaPublica(objGuiaEnvio.iIDUNIDAD_AGENCIA, _
                                                                          objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, CboProducto.SelectedValue, _
                                                                         objGuiaEnvio.TipoTarifa_, intTipoEntrega)
                'tarifaCarga = objVentaContado.obtenerTarifas(objGuiaEnvio.iIDUNIDAD_AGENCIA, _
                '                                         objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, _
                '                                         objGuiaEnvio.iIPRODUCTO, _
                '                                        objGuiaEnvio.TipoTarifa_)

                If IsNothing(tarifaCarga) = False Then
                    bContado = True
                    bTarifarioGeneral = True

                    '-->Pasa valores al objeto objGuiaEnvio
                    objGuiaEnvio.iTarifa_Publica_Monto_Peso = tarifaCarga.precioPeso
                    objGuiaEnvio.iTarifa_Publica_Monto_Volumen = tarifaCarga.precioVolumen
                    objGuiaEnvio.iTarifa_Publica_Monto_Base = tarifaCarga.precioBase
                    objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal = tarifaCarga.precioSobre
                    objGuiaEnvio.iPeso_Maximo = tarifaCarga.pesoMinimo
                    objGuiaEnvio.iVol_Maximo = tarifaCarga.volumnenMinimo
                    objGuiaEnvio.iPrecio_cond_Peso = tarifaCarga.fleteMinimoPeso
                    objGuiaEnvio.iPrecio_cond_Vol = tarifaCarga.fleteMinimoVolumen
                    objGuiaEnvio.iMonto25 = tarifaCarga.importeArticulo_Caja5
                    objGuiaEnvio.iMonto40 = tarifaCarga.importeArticulo_Caja10

                    'hlamas 21-01-2016 temporal 
                    'Dim dt As DataTable = ObjVentaCargaContado.ObtenerTarifa(objGuiaEnvio.sNU_DOCU_SUNAT, dtoUSUARIOS.m_idciudad.ToString, idUnidadAgencias, _
                    '                                                       intTipoEntrega, CboProducto.SelectedValue, objGuiaEnvio.TipoTarifa_)
                    Dim dt As DataTable = ObjVentaCargaContado.ObtenerTarifa(iID_Persona, dtoUSUARIOS.m_idciudad.ToString, idUnidadAgencias, _
                                                                                               intTipoEntrega, CboProducto.SelectedValue, objGuiaEnvio.TipoTarifa_, 999)
                    If dt.Rows.Count > 0 Then
                        If Not IsDBNull(dt.Rows(0).Item(0)) Then
                            If dt.Rows(0).Item(0) >= 0 Then
                                objGuiaEnvio.iTarifa_Publica_Monto_Peso = dt.Rows(0).Item(0)
                            End If
                            If dt.Rows(0).Item(1) >= 0 Then
                                objGuiaEnvio.iTarifa_Publica_Monto_Volumen = dt.Rows(0).Item(1)
                            End If
                            If dt.Rows(0).Item(2) >= 0 Then
                                tarifa_Articulo = dt.Rows(0).Item(2)
                            End If
                            If dt.Rows(0).Item(3) >= 0 Then
                                objGuiaEnvio.iTarifa_Publica_Monto_Base = dt.Rows(0).Item(3)
                            End If
                            If dt.Rows(0).Item(4) >= 0 Then
                                objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal = dt.Rows(0).Item(4)
                            End If
                            If dt.Rows(0).Item(5) >= 0 Then
                                objGuiaEnvio.iPeso_Maximo = dt.Rows(0).Item(5)
                            End If
                            If dt.Rows(0).Item(6) >= 0 Then
                                objGuiaEnvio.iVol_Maximo = dt.Rows(0).Item(6)
                            End If
                            If dt.Rows(0).Item(7) >= 0 Then
                                objGuiaEnvio.iPrecio_cond_Peso = dt.Rows(0).Item(7)
                            End If
                            If dt.Rows(0).Item(8) >= 0 Then
                                objGuiaEnvio.iPrecio_cond_Vol = dt.Rows(0).Item(8)
                            End If
                            If dt.Rows(0).Item(9) >= 0 Then
                                objGuiaEnvio.iMonto25 = dt.Rows(0).Item(9)
                            End If
                            If dt.Rows(0).Item(10) >= 0 Then
                                objGuiaEnvio.iMonto40 = dt.Rows(0).Item(10)
                            End If
                        End If
                    End If

                    '-->Pasa valores a la variables publicas
                    tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                    tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                    tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                    Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                    tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal
                    Monto_25 = objGuiaEnvio.iMonto25
                    Monto_40 = objGuiaEnvio.iMonto40

                    '-->Asigna valores con la condicion de peso minimo y/o volumne minimo.
                    objGuiaEnvio.CondicionTarifa_ = False
                    'If (CboTipo.SelectedValue = 2) Then
                    If (tarifaCarga.pesoMinimo > 0) Then
                        objGuiaEnvio.UnidadPeso_ = "PESO"
                        objGuiaEnvio.iPeso_Minimo = 0.01
                        objGuiaEnvio.CondicionTarifa_ = True
                    End If
                    If (tarifaCarga.volumnenMinimo > 0) Then
                        objGuiaEnvio.UnidadVol_ = "VOL"
                        objGuiaEnvio.iVol_Minimo = 0.01
                        objGuiaEnvio.CondicionTarifa_ = True
                    End If
                    'End If

                    'verifica si esta afecto a monto base para carga acompañada
                    If CboProducto.SelectedValue = 6 Then
                        If CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
                            Monto_Base = 0
                        End If
                        'bBoleto = "N"
                    End If

                    'If bTieneLineaCredito And CboProducto.SelectedValue = 0 Then
                    '    tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso_credito
                    '    tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen_credito
                    '    Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base_credito
                    '    tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal_credito
                    '    bContado = False
                    '    TarifaPublica_ = False
                    'End If

                    If bBoleto = False Then
                        If bDescuento Then
                            tarifa_Peso = tarifa_Peso * (1 - iDescuento)
                            tarifa_Volumen = tarifa_Volumen * (1 - iDescuento)
                            'tarifa_Sobre = tarifa_Sobre * (1 - iDescuento)
                            isDescuento_ = True
                        End If
                    End If
                    flag = True
                    bControl_Tarifas = True
                Else
                    flag = False
                End If
                'hlamas 21-01-2016 recupera tarifa de articulos publico
                dtTarifaArticuloPublico = ObjVentaCargaContado.dtTarifaArticuloPublico
                If ChkArticulos.Tag Is Nothing And dtTarifaArticuloPublico.Rows.Count > 0 Then
                    DtArticulos = dtTarifaArticuloPublico
                    Me.ChkArticulos.Enabled = True
                    Me.ChkArticulos.Checked = False
                ElseIf ChkArticulos.Tag Is Nothing Then
                    DtArticulos = Nothing
                    Me.ChkArticulos.Enabled = False
                    Me.ChkArticulos.Checked = False
                End If
            Else
                flag = False
            End If

            If Not (iOpcion = 1 And bNuevo = False) Then
                Me.ResetCalculo()
            End If

            If Me.CboProducto.SelectedValue <> 81 And Me.CboProducto.SelectedValue <> 82 Then 'And Not Me.ChkArticulos.Checked Then
                If ChkM3.Checked = False Then
                    GrdDetalleVenta("Costo", 0).Value = tarifa_Peso
                    GrdDetalleVenta("Costo", 1).Value = tarifa_Volumen
                    GrdDetalleVenta("Costo", 2).Value = tarifa_Sobre

                    If iControlMonto_Base = 1 Then
                        GrdDetalleVenta("Costo", 3).Value = Monto_Base
                        GrdDetalleVenta("Sub Neto", 3).Value = Monto_Base
                    End If
                End If
            End If
            flagControl = False

            '-->colova valores de la tarifa del grid
            For i As Integer = 0 To GrdDetalleVenta.Rows.Count - 1
                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then
                    'Select Case i
                    'Case 0
                    GrdDetalleVenta("Costo", 0).Value = Format(Monto_25, "0.00")
                    'Case 1
                    'GrdDetalleVenta("Costo", 1).Value = Format(Monto_40, "0.00")
                    'End Select
                ElseIf CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                    'Select Case i
                    'Case 0
                    GrdDetalleVenta("Costo", 0).Value = Format(Monto_40, "0.00")
                    'Case 1
                    'GrdDetalleVenta("Costo", 1).Value = Format(Monto_40, "0.00")
                    'End Select
                Else
                    Select Case i
                        Case 0
                            GrdDetalleVenta("Costo", 0).Value = Format(tarifa_Peso, "0.00")
                        Case 1
                            GrdDetalleVenta("Costo", 1).Value = Format(tarifa_Volumen, "0.00")
                        Case 2
                            GrdDetalleVenta("Costo", 2).Value = Format(tarifa_Sobre, "0.00")
                        Case 3
                            GrdDetalleVenta("Costo", 3).Value = Format(Monto_Base, "0.00")
                            GrdDetalleVenta("Sub Neto", 3).Value = Format(Monto_Base, "0.00")
                    End Select
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return flag
    End Function

    Dim TipoTarifa_ As Integer
    Dim TipoProducto_ As Integer
    Dim iPeso_Minimo As Double = 0
    Dim iPeso_Maximo As Double = 0
    Dim iPrecio_cond_Peso As Double = 0
    Dim TarifaPublica_ As Boolean
    Dim TarifaPyme_ As Boolean
    Dim TarifaMasiva_ As Boolean
    Dim Unidad_ As String
    Dim CondicionTarifa_ As Boolean
    Dim dPRECIO_X_UNIDAD As Double
    'Public Function NewfnTarifario() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        bControl_Tarifas = False
    '        tarifa_Peso = 0
    '        tarifa_Volumen = 0
    '        tarifa_Articulo = 0
    '        Monto_Base = 0

    '        If CboProducto.SelectedValue = 8 Then objGuiaEnvio.TarifaMasiva_ = True
    '        '*******************Parametros**************************************************************            
    '        objGuiaEnvio.iIDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad.ToString
    '        objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = CodCiudadDest_
    '        objGuiaEnvio.TipoProducto_ = CboProducto.SelectedValue
    '        objGuiaEnvio.TipoTarifa_ = CboTipoTarifa.SelectedIndex
    '        objGuiaEnvio.sNU_DOCU_SUNAT = IIf(Me.TxtNroDocCliente.Text <> "", Me.TxtNroDocCliente.Text, "@")
    '        If CboTipo.SelectedValue = 2 Then
    '            If CboSubCuenta.SelectedIndex.ToString <> -1 Then
    '                objGuiaEnvio.iIDCENTRO_COSTO = Int(objGuiaEnvio.coll_Sub_Cuenta.Item(CboSubCuenta.SelectedIndex.ToString))
    '            Else
    '                objGuiaEnvio.iIDCENTRO_COSTO = 999
    '            End If

    '        End If

    '        Dim obj As New dtoGuia
    '        '*******************************************************************************************'
    '        'Listando la tarifa corporativa (ciudad origen, ciudad  destino, cliente)---> no incluye igv
    '        '*******************************************************************************************' 
    '        If objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
    '            bTarifarioGeneral = False
    '            tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
    '            tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
    '            tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
    '            Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
    '            tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Sobre
    '            iTarifa = objGuiaEnvio.iTarifa

    '            GrdDetalleVenta(3, 0).Value = tarifa_Peso
    '            GrdDetalleVenta(3, 1).Value = tarifa_Volumen
    '            GrdDetalleVenta(3, 2).Value = tarifa_Sobre

    '            If iControlMonto_Base = 1 Then
    '                GrdDetalleVenta(3, 3).Value = Monto_Base
    '                GrdDetalleVenta(4, 3).Value = Monto_Base
    '            End If

    '            flag = True
    '            bControl_Tarifas = True

    '            Dim ds As DataSet = obj.fnTARIFA_PUBLICA_CARGA1(dtoUSUARIOS.m_idciudad.ToString, CodCiudadDest_, CboProducto.SelectedValue, CboTipoTarifa.SelectedIndex)
    '            If ds.Tables(0).Rows.Count > 0 Then
    '                Monto_Base = Format(ds.Tables(0).Rows(0).Item(1), "##,###.00")
    '                tarifa_Peso = Format(ds.Tables(0).Rows(0).Item(2), "##,###.00")
    '                tarifa_Volumen = Format(ds.Tables(0).Rows(0).Item(3), "##,###.00")
    '                'iTarifa_Publica_Monto_Base_Xpostal = Format(ds.Tables(0).Rows(0).Item(7), "##,###.00")
    '                tarifa_Sobre = Format(IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_SOBRE")), 0, ds.Tables(0).Rows(0).Item("CG_X_SOBRE")), "##,###.00")
    '                tarifa_Articulo = Format(IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_SOBRE")), 0, ds.Tables(0).Rows(0).Item("CG_X_SOBRE")))
    '                iTarifa = ds.Tables(0).Rows(0).Item("tarifa")
    '                '                                       
    '                If ds.Tables(1).Rows.Count > 0 Then
    '                    If ds.Tables(1).Rows(0).Item("UNIDAD") = "PESO" Then
    '                        iPeso_Minimo = ds.Tables(1).Rows(0).Item("INICIO")
    '                        iPeso_Maximo = ds.Tables(1).Rows(0).Item("FIN")
    '                        iPrecio_cond_Peso = ds.Tables(1).Rows(0).Item("PRECIO_FINAL")
    '                    End If

    '                    'If ds.Tables(1).Rows(0).Item("UNIDAD") = "VOLUMEN" Then
    '                    '    iVol_Minimo = ds.Tables(1).Rows(0).Item("INICIO")
    '                    '    iVol_Maximo = ds.Tables(1).Rows(0).Item("FIN")
    '                    '    iPrecio_cond_Vol = ds.Tables(1).Rows(0).Item("PRECIO_FINAL")
    '                    'End If
    '                End If
    '                flag = True
    '            Else
    '                flag = False
    '            End If
    '        Else
    '            '*******************************************************************************************'
    '            'Tarifa publica (ciudad origen, ciudad destino)-----------------------> incluye igv
    '            '*******************************************************************************************'               
    '            Dim ds As DataSet = obj.fnTARIFA_PUBLICA_CARGA1(dtoUSUARIOS.m_idciudad.ToString, CodCiudadDest_, CboProducto.SelectedValue, CboTipoTarifa.SelectedIndex)

    '            'cargando si la tarifa tiene condicion tarifa
    '            If ds.Tables(1).Rows.Count > 0 Then
    '                If ds.Tables(1).Rows(0).Item(0) IsNot System.DBNull.Value Then
    '                    Unidad_ = ds.Tables(1).Rows(0).Item("UNIDAD")
    '                    iPeso_Minimo = ds.Tables(1).Rows(0).Item("INICIO")
    '                    iPeso_Maximo = ds.Tables(1).Rows(0).Item("FIN")
    '                    iPrecio_cond_Peso = ds.Tables(1).Rows(0).Item("MONTO")
    '                    TipoTarifa_ = ds.Tables(1).Rows(0).Item("TIPO_TARIFA")
    '                    TipoProducto_ = ds.Tables(1).Rows(0).Item("ID_PRODUCTO")
    '                    CondicionTarifa_ = True
    '                Else
    '                    CondicionTarifa_ = False
    '                End If
    '            Else
    '                CondicionTarifa_ = False
    '            End If

    '            If ds.Tables(0).Rows.Count = 1 And ds.Tables(0).Rows(0).Item(0) = 1 Then
    '                If TipoTarifa_ = 0 Then '---> TARIFA 48 HORAS
    '                    tarifa_Peso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_PESO")), 0, ds.Tables(0).Rows(0).Item("CG_X_PESO"))
    '                    tarifa_Volumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_VOLUMEN")), 0, ds.Tables(0).Rows(0).Item("CG_X_VOLUMEN"))
    '                    Monto_Base = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_MONTO_BASE")), 0, ds.Tables(0).Rows(0).Item("CG_MONTO_BASE"))
    '                    tarifa_Articulo = Monto_Base
    '                    tarifa_Sobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_SOBRE")), 0, ds.Tables(0).Rows(0).Item("CG_X_SOBRE"))
    '                    bContado = IIf(ds.Tables(0).Rows(0).Item("CONTADO") = 1, True, False)

    '                    If TarifaPyme_ Then
    '                        tarifa_Peso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PY_PESO_CONTADO")), 0, ds.Tables(0).Rows(0).Item("PY_PESO_CONTADO"))
    '                        tarifa_Volumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO")), 0, ds.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO"))
    '                        Monto_Base = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PY_BASE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("PY_BASE_CONTADO"))
    '                        tarifa_Articulo = Monto_Base
    '                        tarifa_Sobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO"))
    '                        TarifaPyme_ = False
    '                    ElseIf TarifaMasiva_ Then
    '                        tarifa_Peso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma48_PESO_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma48_PESO_CONTADO"))
    '                        tarifa_Volumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma48_VOLUMEN_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma48_VOLUMEN_CONTADO"))
    '                        Monto_Base = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma48_BASE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma48_BASE_CONTADO"))
    '                        tarifa_Sobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma48_SOBRE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma48_SOBRE_CONTADO"))
    '                        tarifa_Articulo = 0
    '                        TarifaMasiva_ = False
    '                    End If
    '                Else '----------------------> TARIFA 24 HORAS
    '                    If TarifaMasiva_ Then
    '                        tarifa_Peso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma24_PESO_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma24_PESO_CONTADO"))
    '                        tarifa_Volumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma24_VOLUMEN_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma24_VOLUMEN_CONTADO"))
    '                        Monto_Base = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma24_BASE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma24_BASE_CONTADO"))
    '                        tarifa_Sobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma24_SOBRE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma24_SOBRE_CONTADO"))
    '                        TarifaMasiva_ = False
    '                    Else
    '                        tarifa_Peso = 0
    '                        tarifa_Volumen = 0
    '                        tarifa_Articulo = 0
    '                        tarifa_Sobre = 0
    '                    End If
    '                End If

    '                'verifica si esta afecto a monto base para carga acompañada
    '                If CboProducto.SelectedValue = 6 Then
    '                    If CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
    '                        Monto_Base = 0
    '                    End If
    '                End If

    '                If bTieneLineaCredito Then
    '                    tarifa_Peso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_PESO_CREDITO")), 0, ds.Tables(0).Rows(0).Item("CG_X_PESO_CREDITO"))
    '                    tarifa_Volumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_VOLUMEN_CREDITO")), 0, ds.Tables(0).Rows(0).Item("CG_X_VOLUMEN_CREDITO"))
    '                    Monto_Base = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_MONTO_BASE_CREDITO")), 0, ds.Tables(0).Rows(0).Item("CG_MONTO_BASE_CREDITO"))
    '                    tarifa_Sobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_SOBRE_CREDITO")), 0, ds.Tables(0).Rows(0).Item("CG_X_SOBRE_CREDITO"))
    '                    bContado = False
    '                    TarifaPublica_ = False
    '                End If

    '                '

    '                If bDescuento Then
    '                    tarifa_Peso = tarifa_Peso * (1 - iDescuento)
    '                    tarifa_Volumen = tarifa_Volumen * (1 - iDescuento)
    '                    'tarifa_Sobre = tarifa_Sobre * (1 - iDescuento)
    '                    isDescuento_ = True
    '                End If

    '                If ChkM3.Checked = False Then
    '                    GrdDetalleVenta("Costo", 0).Value = tarifa_Peso
    '                    GrdDetalleVenta("Costo", 1).Value = tarifa_Volumen
    '                    GrdDetalleVenta("Costo", 2).Value = tarifa_Sobre

    '                    If iControlMonto_Base = 1 Then
    '                        GrdDetalleVenta("Costo", 3).Value = Monto_Base
    '                        GrdDetalleVenta("Sub Neto", 3).Value = Monto_Base
    '                    End If
    '                End If

    '                flag = True
    '                bControl_Tarifas = True

    '                If bContado = 0 Then
    '                    If tarifa_Sobre <= 0 Then
    '                        tarifa_Sobre = Monto_Base
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    '    Return flag
    'End Function

#End Region


#End Region

#Region "REMITENTE"
    '****NOMBRE  REMITENTE**
    Dim idRemitente As Integer
    Private Sub CboRemitente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRemitente.SelectedIndexChanged
        If Not IsReference(CboRemitente.SelectedValue) Then
            If iOpcion = 2 Then
                RemoveHandler CboRemitente.SelectedIndexChanged, AddressOf CboRemitente_SelectedIndexChanged
                CboRemitente.SelectedValue = idRemitente
                AddHandler CboRemitente.SelectedIndexChanged, AddressOf CboRemitente_SelectedIndexChanged
                Return
            End If

            If Not bRemitenteModificado Then
                If Not (iOpcion = 1 And bNuevo = False) Then
                    idRemitente = CboRemitente.SelectedValue
                End If
            End If
            Me.TxtNumDocRemitente.Text = IIf(IsDBNull(dtRemitente.Rows(CboRemitente.SelectedIndex).Item("nrodocumento")), "", dtRemitente.Rows(CboRemitente.SelectedIndex).Item("nrodocumento"))
            sNroDocRemitente = Me.TxtNumDocRemitente.Text
        ElseIf Me.CboRemitente.DataSource Is Nothing Then
            If Me.CboRemitente.Items.Count > 1 Then
                Dim iFila As Integer = IIf(CboRemitente.SelectedIndex < 0, 0, CboRemitente.SelectedIndex)
                Me.TxtNumDocRemitente.Text = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nrodocumento")), "", dtRemitente.Rows(iFila).Item("nrodocumento"))
                sNroDocRemitente = Me.TxtNumDocRemitente.Text
            End If
        End If

        RemoveHandler ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged
        If Me.CboRemitente.SelectedIndex = 0 Then
            Me.ChkCliente.Checked = False
        Else
            'Me.ChkCliente1.Checked = IIf(IsDBNull(Me.ChkCliente1.Tag), Me.ChkCliente1.Checked, Me.ChkCliente1.Tag)
            Me.ChkCliente.Checked = IIf(TxtNroDocCliente.Text = TxtNumDocRemitente.Text, 1, 0)
        End If
        AddHandler ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged
    End Sub

    '****(REMITENTE) ES EL CLIENTE
    Private Sub ChkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente.CheckedChanged

        If iOpcion = 2 Then
            RemoveHandler ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged
            ChkCliente.Checked = Not ChkCliente.Checked
            AddHandler ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged
            Return
        End If

        If ChkCliente.Checked Then
            If Me.TxtNroDocCliente.Text.Trim.Length > 0 Or Me.TxtNomCliente.Text.Trim.Length > 0 Then
                Dim iExisteEsElCliente As Integer = ExisteEsElCliente(Me.TxtNroDocCliente.Text.Trim, CboRemitente, dtRemitenteParalelo, "nrodocumento", "idcontacto_persona")
                Dim iId As Integer = iExisteEsElCliente

                RemoveHandler Me.CboRemitente.SelectedIndexChanged, AddressOf Me.CboRemitente_SelectedIndexChanged
                Me.CboRemitente.DataSource = Nothing
                Me.CboRemitente.Items.Clear()
                Me.CboRemitente.Items.Add(" (SELECCIONE)")
                Me.CboRemitente.Items.Add(Me.TxtNomCliente.Text.Trim)
                Me.TxtNumDocRemitente.Text = Me.TxtNroDocCliente.Text.Trim

                dtRemitente.Rows.Clear()
                Dim dr As DataRow
                dr = dtRemitente.NewRow
                dr("idcontacto_persona") = 0
                dr("nombres") = " (SELECCIONE)"
                dr("nombre") = "" '
                dr("idtipo_documento_contacto") = 0
                dr("nrodocumento") = ""
                dr("apepat") = "" '
                dr("apemat") = "" '
                dtRemitente.Rows.Add(dr)

                dr = dtRemitente.NewRow
                dr("idcontacto_persona") = iId
                dr("nombres") = Me.TxtNomCliente.Text.Trim
                dr("nombre") = sNombresCli '
                dr("idtipo_documento_contacto") = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
                dr("nrodocumento") = Me.TxtNroDocCliente.Text.Trim
                dr("apepat") = sApCli '
                dr("apemat") = sAmCli '               
                dtRemitente.Rows.Add(dr)

                idRemitente = iId
                sNombreRemitente = sNombresCli
                iID_TipoDocRemitente = iID_TipoDocCli
                sNroDocRemitente = Me.TxtNroDocCliente.Text.Trim
                sApRemitente = sApCli
                sAmRemitente = sAmCli

                AddHandler Me.CboRemitente.SelectedIndexChanged, AddressOf Me.CboRemitente_SelectedIndexChanged
                RemoveHandler Me.CboRemitente.SelectedIndexChanged, AddressOf Me.CboRemitente_SelectedIndexChanged
                Me.CboRemitente.SelectedIndex = 1
                AddHandler Me.CboRemitente.SelectedIndexChanged, AddressOf Me.CboRemitente_SelectedIndexChanged

                Me.ChkCliente2.Focus()
            Else
                MessageBox.Show("Ingrese el Cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ChkCliente.Checked = False
                Me.TxtCliente.Focus()
            End If
        Else
            If dtRemitenteParalelo IsNot Nothing Then
                dtRemitente = dtRemitenteParalelo.Copy
                Me.CboRemitente.DataSource = dtRemitente
                Me.CboRemitente.DisplayMember = "nombres"
                Me.CboRemitente.ValueMember = "idcontacto_persona"
                Me.CboRemitente.SelectedIndex = 0
            Else
                Me.CboRemitente.DataSource = Nothing
                Me.CboRemitente.Items.Clear()
                Me.CboRemitente.Items.Add(" (SELECCIONE)")
                Me.CboRemitente.SelectedIndex = 0
                Me.TxtNumDocRemitente.Text = ""
            End If
        End If
        NombresCont = ""
        apellPatCont = ""
        apellMatCont = ""
    End Sub
#End Region

#Region "CONTACTO"

    '****NOMBRE  CONTACTO********
    Dim idcontacto As Integer
    Private Sub CboContacto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboContacto.SelectedIndexChanged
        If Not IsReference(CboContacto.SelectedValue) Then
            If iOpcion = 2 Then
                RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
                CboContacto.SelectedValue = idcontacto
                AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
                Return
            End If

            If Not bContactoModificado Then
                If Not (iOpcion = 1 And bNuevo = False) Then
                    idcontacto = CboContacto.SelectedValue
                End If
            End If
            Me.TxtNroDocContacto.Text = IIf(IsDBNull(dtContacto.Rows(CboContacto.SelectedIndex).Item("nrodocumento")), "", dtContacto.Rows(CboContacto.SelectedIndex).Item("nrodocumento"))
            Me.iID_TipoDocCont = IIf(IsDBNull(dtContacto.Rows(CboContacto.SelectedIndex).Item("idtipo_documento_contacto")), 9, dtContacto.Rows(CboContacto.SelectedIndex).Item("idtipo_documento_contacto"))
            Me.NombresCont = IIf(IsDBNull(dtContacto.Rows(CboContacto.SelectedIndex).Item("nombre")), "", dtContacto.Rows(CboContacto.SelectedIndex).Item("nombre"))
            Me.apellPatCont = IIf(IsDBNull(dtContacto.Rows(CboContacto.SelectedIndex).Item("apepat")), "", dtContacto.Rows(CboContacto.SelectedIndex).Item("apepat"))
            Me.apellMatCont = IIf(IsDBNull(dtContacto.Rows(CboContacto.SelectedIndex).Item("apemat")), "", dtContacto.Rows(CboContacto.SelectedIndex).Item("apemat"))

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

    '****CONTACTO) ES EL CLIENTE (
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

#End Region

#Region "CONSIGNADO"

    '***BUSCAR CONSIGNADO**
    Dim iIDConsignado As Integer
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
        Dim iTipo As Integer = 3 '18112011
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
        sReferencia = "" 'CambioR 18112011

        If Me.GrdNConsignado.Rows.Count > 0 Then
            '==agregado x NConsignado===
            bConsignadoNuevo = False
            'bExiste = True

            '19-10-2011
            Dim iIndice As Integer = Me.GrdNConsignado.CurrentCell.RowIndex
            iIDConsignado = GrdNConsignado("IDConsignado", iIndice).Value
            sNumero = GrdNConsignado("Nº Documento", iIndice).Value
            sConsignado = GrdNConsignado("Nombres", iIndice).Value
            sNombresConsig = GrdNConsignado("nombre", iIndice).Value
            iTipo = GrdNConsignado("tipo", iIndice).Value
            sApePConsig = GrdNConsignado("apepat", iIndice).Value
            sApeMConsig = GrdNConsignado("apemat", iIndice).Value
            sTelfConsig = GrdNConsignado("Telefono", iIndice).Value
            '=============================

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
                sReferencia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("De_Referencia")), "", dtDireccion2.Rows(iFila).Item("De_Referencia"))
            End If
            bEsCliente = Me.ChkCliente2.Checked
        End If
        '01092011
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
            sReferencia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("De_Referencia")), "", dtDireccion2.Rows(iFila).Item("De_Referencia"))
        End If

        frm.cargar(iTipo, sNumero, sRazonSocialCliente, sConsignado, sNombresConsig, bEsCliente, iDepartamento, iProvincia, iDistrito, iId_via, sVia, sNumero2, _
                   sManzana, sLote, iId_Nivel, sNivel, iId_Zona, sZona, iId_Clasificacion, sClasificacion, sApePConsig, sApeMConsig, sTelfConsig, sNombresCli,
                   sApCli, sAmCli, sTelfCliente, sReferencia, iIDConsignado)

        If Me.GrdNConsignado.Rows.Count = 0 Then bConsignadoNuevo = True 'CambioR 18112011

        frm.bConsignadoNuevo = bConsignadoNuevo
        frm.iTipoEntrega = Me.CboTipoEntrega.SelectedValue

        iTipoDoc = 0
        If Not (dtCliente Is Nothing) Then
            If bBoleto Then
                'iTipoDoc = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", ObtieneTipoDocumento(dtCliente.Rows(0).Item("tipo")))
                iTipoDoc = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
            Else
                iTipoDoc = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
            End If
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
    End Sub

    '***ES EL CLIENTE PARA EL CONSIGNADO**
    Private Sub ChkCliente2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente2.CheckedChanged

        If iOpcion = 2 Then
            RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
            ChkCliente2.Checked = bSclienteConsignado
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
                dr("nombre") = sNombresCli.Trim 'new
                dr("tipo") = iID_TipoDocCli
                dr("nrodocumento") = Me.TxtNroDocCliente.Text.Trim
                dr("apepat") = sApCli
                dr("apemat") = sAmCli
                dr("telefono") = sTelfCliente
                dtConsignado.Rows.Add(dr)

                '***Comentado x Nconsignado***
                'Me.TxtNroDocConsignado.Tag = 0
                '==Agregado x Nconsignado==
                iNroDocumentoTag = 0
                '===

                iIDConsignado = 0
                'Me.TxtNroDocConsignado.Text = Me.TxtNroDocCliente.Text.Trim
                'Me.TxtNombConsignado.Text = Me.TxtNomCliente.Text.Trim
                sNombresConsig = sNombresCli.Trim
                iID_TipoDocConsig = iID_TipoDocCli
                sapellPatConsig = sApCli
                sapellMatConsig = sAmCli
                sTelefonoConsig = Me.TxtTelfCliente.Text.Trim
                'Me.TxtTelfConsignado.Text = Me.TxtTelfCliente.Text.Trim
                '******************************

                bConsignadoNuevo = True
                bConsignadoModificado = False
                Me.CboDireccion2.Focus()

                '=====Agregado x NConsignado======================
                GrdNConsignado.Rows.Clear()
                GrdNConsignado.Rows.Add()
                GrdNConsignado("IDConsignado", 0).Value = 0
                GrdNConsignado("Nº Documento", 0).Value = Me.TxtNroDocCliente.Text.Trim
                GrdNConsignado("Nombres", 0).Value = Me.TxtNomCliente.Text.Trim
                GrdNConsignado("Telefono", 0).Value = Me.TxtTelfCliente.Text.Trim
                GrdNConsignado("nombre", 0).Value = sNombresCli
                GrdNConsignado("tipo", 0).Value = iID_TipoDocCli
                GrdNConsignado("apepat", 0).Value = sApCli
                GrdNConsignado("apemat", 0).Value = sAmCli
                GrdNConsignado("Modificado", 0).Value = "0"
                '==================================================
            Else
                MessageBox.Show("Ingrese el Cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                i = 1
                Me.ChkCliente2.Checked = False
                Me.TxtCliente.Focus()
            End If
        Else
            If i = 0 Then
                If Not IsNothing(dtConsignado) Then
                    dtConsignado.Rows.Clear()
                End If
                '==Agregado x Nconsignado============
                GrdNConsignado.Rows.Clear()
                '====================================

                '***Comentado x NConsignado**********
                'Me.TxtNroDocConsignado.Text = ""
                'Me.TxtNombConsignado.Text = ""
                'Me.TxtTelfConsignado.Text = ""
                '************************************
            Else
            i = 0
            End If
            End If
    End Sub

    '***BUSCAR CONSIGNADO*****************
    Sub BuscarConsignado()
        Try
            Me.Cursor = Cursors.AppStarting
            Dim iOpcion As Integer = IIf(Me.RbtDocumento3.Checked, 1, 2)
            Dim frm As New FrmConsignado
            Dim sConsignado As String = Me.TxtConsignado.Text.Trim
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.BuscarConsignado(sConsignado, iOpcion, idUnidadAgencias)
            dtConsignado = ds.Tables(0)
            bConsignadoNuevo = True

            If ds.Tables(0).Rows.Count = 0 Then
                Me.Cursor = Cursors.Default
                MessageBox.Show("El Consignado no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)

                '****CambioR 18112011********
                Dim iFila As Integer = 0
                Dim sNumero As String = ""
                sConsignado = ""
                Dim sNombresConsig As String = ""
                Dim sApePConsig As String = ""
                Dim sApeMConsig As String = ""
                Dim sTelfConsig As String = ""
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
                sReferencia = ""

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
                    sReferencia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("De_Referencia")), "", dtDireccion2.Rows(iFila).Item("De_Referencia"))
                End If

                frm.cargar(3, sNumero, sRazonSocialCliente, sConsignado, sNombresConsig, 0, iDepartamento, iProvincia, iDistrito, iId_via, sVia, sNumero2, _
                   sManzana, sLote, iId_Nivel, sNivel, iId_Zona, sZona, iId_Clasificacion, sClasificacion, sApePConsig, sApeMConsig, sTelfConsig, sNombresCli,
                   sApCli, sAmCli, sTelfCliente, sReferencia, iIDConsignado)
                '******************************

                '===Agregado x NConsignado=====
                If Me.ChkCliente2.Checked Then Me.ChkCliente2.Checked = False
                'bExiste = False
                '==============================

                frm = New FrmConsignado
                frm.bConsignadoNuevo = bConsignadoNuevo
                frm.iTipoEntrega = Me.CboTipoEntrega.SelectedValue
                frm.iFicha = 1
                frm.TxtNumero.Text = IIf(RbtDocumento3.Checked, sConsignado.Trim, "") '22092011 Agregado ayuda nroDocumento
                frm.idUnidadAgencias = idUnidadAgencias
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
                    If frm.bConsignadoNuevo Then
                        CargarConsignado(frm)
                    Else
                        ds = obj.BuscarConsignado(frm.TxtNumero.Tag)
                        dtConsignado = ds.Tables(0)
                        Me.MostrarConsignado(ds)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub MostrarConsignado(ByVal ds As DataSet)
        Try
            bConsignadoNuevo = False
            '****comentado x nconsignado******
            'Me.TxtNroDocConsignado.Tag = ds.Tables(0).Rows(0).Item("idcontacto_persona").ToString.Trim
            iNroDocumentoTag = ds.Tables(0).Rows(0).Item("idcontacto_persona").ToString.Trim
            iIDConsignado = ds.Tables(0).Rows(0).Item("idcontacto_persona").ToString.Trim
            'Me.TxtNroDocConsignado.Text = ds.Tables(0).Rows(0).Item("nrodocumento").ToString.Trim
            'Me.TxtNombConsignado.Text = ds.Tables(0).Rows(0).Item("nombres").ToString.Trim '& " " & ds.Tables(0).Rows(0).Item("apepat").ToString.Trim & " " & ds.Tables(0).Rows(0).Item("apemat").ToString.Trim
            'Me.txtTelfConsignado.Text = ds.Tables(0).Rows(0).Item("telefono").ToString.Trim

            '====Agregado x NConsignados=============================================
            If ChkCliente2.Checked Then GrdNConsignado.Rows.Clear()
            Dim bExiste As Boolean = False
            If iIDConsignado > 0 And GrdNConsignado.Rows.Count > 0 Then
                For i As Integer = 0 To GrdNConsignado.Rows.Count - 1
                    If iIDConsignado = GrdNConsignado("IDConsignado", i).Value Then
                        bExiste = True
                    End If
                Next
            End If

            If Not bExiste Then
                Me.ActualizarGrid(ds)
            End If
            '=========================================================================

            '****comentado x NConsignado***********************************************
            'RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
            'If Me.TxtNomCliente.Text.Trim = Me.TxtNombConsignado.Text.Trim Then Me.ChkCliente2.Checked = True Else Me.ChkCliente2.Checked = False
            'AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged

            Me.CboDireccion2.Focus()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub BuscarConsignado(ByVal IdConsignado As Integer)
        Try
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.BuscarConsignado(IdConsignado)
            dtConsignado = ds.Tables(0)
            If ds.Tables(0).Rows.Count = 1 Then
                Me.MostrarConsignado(ds)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '***CARGAR CONSIGNADO*****************
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
        If frm.bConsignadoNuevo Then
            '***Comentado x NConsignado****
            'TxtNroDocConsignado.Tag = 0

            '===Agregado x NConsignado=====
            iNroDocumentoTag = 0
            '==============================
        End If
        '***Comentado x NConsignado********
        'Me.TxtNroDocConsignado.Text = frm.TxtNumero.Text.Trim
        'Me.TxtNombConsignado.Text = frm.TxtConsignado.Text.Trim & " " & frm.txtapePConsig.Text & " " & frm.txtapeMConsig.Text
        'Me.txtTelfConsignado.Text = frm.txtTelefono.Text.Trim
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
            '***Comentado x NConsignado*****************************
            'Me.TxtNroDocConsignado.Text = frm.TxtNumero.Text.Trim

            Dim obj As New dtoVentaCargaContado
            Dim ds As New DataSet
            'Comentado x NConsignado
            'If Me.TxtNroDocConsignado.Text.Trim.Length > 0 Then
            If frm.TxtNumero.Text.Trim.Length > 0 Then
                ds = obj.BuscarConsignado(frm.TxtNumero.Text, 1, dtoUSUARIOS.m_idciudad)
            Else
                ds = obj.BuscarConsignado(frm.TxtNumero.Tag)
            End If
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
                '===Agregado x NConsignado======
                'bExiste = False
                If ChkCliente2.Checked Then GrdNConsignado.Rows.Clear()
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
            'Me.ChkCliente1.Tag = Me.ChkCliente1.Checked
            AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged

            '=======================Agregado x NConsignado========================================
            '19-10-2011
            Dim iIndice As Integer = -1
            If Me.GrdNConsignado.Rows.Count > 0 And Not bConsignadoNuevo Then
                iIndice = Me.GrdNConsignado.CurrentCell.RowIndex
            End If
            If bConsignadoNuevo And frm.TxtNumero.Text.Trim.Length > 0 Then
                iIndice = ValorGrid(Me.GrdNConsignado, "Nº Documento", frm.TxtNumero.Text.Trim)
            End If
            'If iIDConsignado = 0 And (Not ExisteValorGrid(Me.GrdNConsignado, "Nº Documento", frm.TxtNumero.Text.Trim) Or frm.TxtNumero.Text.Trim.Length = 0) Then
            If iIDConsignado = 0 And iIndice = -1 Then '(iIndice = -1 Or frm.TxtNumero.Text.Trim.Length = 0) Then
                row = GrdNConsignado.Rows.Count()
                GrdNConsignado.Rows.Add()
                GrdNConsignado("IDConsignado", row).Value = iIDConsignado
                GrdNConsignado("Nº Documento", row).Value = frm.TxtNumero.Text.Trim
                GrdNConsignado("Nombres", row).Value = frm.TxtConsignado.Text.Trim & " " & frm.txtapePConsig.Text.Trim & " " & frm.txtapeMConsig.Text.Trim
                GrdNConsignado("Telefono", row).Value = frm.txtTelefono.Text.Trim
                GrdNConsignado("nombre", row).Value = frm.TxtConsignado.Text.Trim
                GrdNConsignado("tipo", row).Value = frm.CboTipoDocumento.SelectedValue
                GrdNConsignado("apepat", row).Value = frm.txtapePConsig.Text.Trim
                GrdNConsignado("apemat", row).Value = frm.txtapeMConsig.Text.Trim
                GrdNConsignado("Modificado", row).Value = 0
            Else
                GrdNConsignado("Nº Documento", iIndice).Value = frm.TxtNumero.Text.Trim
                GrdNConsignado("Nombres", iIndice).Value = frm.TxtConsignado.Text.Trim & " " & frm.txtapePConsig.Text.Trim & " " & frm.txtapeMConsig.Text.Trim
                GrdNConsignado("Telefono", iIndice).Value = frm.txtTelefono.Text.Trim
                GrdNConsignado("nombre", iIndice).Value = frm.TxtConsignado.Text.Trim
                GrdNConsignado("tipo", iIndice).Value = frm.CboTipoDocumento.SelectedValue
                GrdNConsignado("apepat", iIndice).Value = frm.txtapePConsig.Text.Trim
                GrdNConsignado("apemat", iIndice).Value = frm.txtapeMConsig.Text.Trim
                If bConsignadoModificado Then
                    GrdNConsignado("Modificado", iIndice).Value = 1
                End If
            End If
            '=====================================================================================

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
                'Dim sDireccion As String = frm.CboVia.Text & " " & frm.TxtVia.Text.Trim & " "
                Dim sDireccion As String = IIf(frm.CboVia.SelectedValue = 0, "", frm.CboVia.Text) & " " & frm.TxtVia.Text.Trim & " " 'Cambio 03102011                
                If frm.TxtNumero2.Text.Trim.Length > 0 Then
                    sDireccion &= frm.TxtNumero2.Text.Trim & " "
                End If

                If frm.TxtManzana.Text.Trim.Length > 0 Then
                    sDireccion &= "MZ " & frm.TxtManzana.Text.Trim & " LT " & frm.TxtLote.Text.Trim & " "
                End If

                If frm.CboNivel.SelectedValue > 0 Then
                    sDireccion &= frm.CboNivel.Text & " " & frm.TxtNivel.Text.Trim & " "
                End If

                '20-10-2011
                If frm.CboZona.SelectedValue > 0 Then
                    sDireccion &= frm.CboZona.Text & " " & frm.TxtZona.Text.Trim & " "
                End If

                If frm.CboClasificacion.SelectedValue > 0 Then
                    sDireccion &= frm.CboClasificacion.Text & " " & frm.TxtClasificacion.Text.Trim & " "
                End If

                If frm.CboDistrito.SelectedValue > 0 Then
                    sDireccion &= frm.CboDistrito.Text
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
                'dr("direccion") = sDireccion
                dr("direccion") = Trim(sDireccion) 'Cambio 03102011
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

            '***Comentado x NConsignado******************************
            'If TxtNroDocCliente.Text.Trim.Length > 0 Then
            'Me.ChkCliente2.Checked = IIf(TxtNroDocCliente.Text = TxtNroDocConsignado.Text, 1, 0)
            'End If
        End If
    End Sub

    '***DIREECCION CONSIGNADO*************
    Dim idDireConsignado As Integer
    Private Sub CboDireccion2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDireccion2.SelectedIndexChanged
        Try
            If Not IsReference(CboDireccion2.SelectedValue) Then
                If iOpcion = 2 Then
                    RemoveHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged
                    CboDireccion2.SelectedValue = idDireConsignado
                    AddHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged
                    Return
                End If

                If Not bDirecConsigMod Then
                    RemoveHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged
                    idDireConsignado = CboDireccion2.SelectedValue
                    AddHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

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

    Private Sub TxtDescuento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDescuento.LostFocus
        'If Val(TxtTotal.Text) = monto_minimo_PCE Then
        '    TxtDescuento.Text = ""
        '    TxtDescuento.Enabled = False
        '    txtDescDescto.Text = ""
        '    txtDescDescto.Enabled = False
        'End If
    End Sub

    Private Sub TxtDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescuento.TextChanged
        Try
            If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                txtDescDescto.Text = ""
                'hlamas 07-12-2015
                'txtDescDescto.Enabled = True
                'TxtDescuento.ReadOnly = False
                If Val(TxtDescuento.Text) > 0 Then
                    Me.btnAutorizar.Enabled = True
                    txtDescDescto.Enabled = False
                Else
                    Me.btnAutorizar.Enabled = False
                    txtDescDescto.Enabled = True
                    TxtDescuento.ReadOnly = False
                End If
            Else
                'hlamas 07-12-2015
                Me.btnAutorizar.Enabled = False
                txtDescDescto.Enabled = False
                txtDescDescto.Text = ""
            End If

            If bMontoMinimo = False Then
                '**Calculando Descuento**
                If ChkM3.Checked = True Then
                    Me.DescuentoM3()
                Else
                    If Me.CboTipo.SelectedValue = 1 Then
                        Me.fnCalcularCostoDescuento()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try
        '    If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
        '        Me.txtDescDescto.Enabled = True
        '        Me.txtDescDescto.ReadOnly = False
        '        Me.txtDescDescto.BackColor = Color.White
        '        txtDescDescto.Text = ""
        '        'TxtDescuento.ReadOnly = False
        '    Else
        '        Me.txtDescDescto.ReadOnly = True
        '        Me.txtDescDescto.BackColor = System.Drawing.SystemColors.Control
        '        txtDescDescto.Text = ""
        '    End If

        '    If bMontoMinimo = False Then
        '        '**Calculando Descuento**
        '        If ChkM3.Checked = True Then
        '            Me.DescuentoM3()
        '        Else
        '            'Me.fnCalcularCostoDescuento()
        '            'hlamas 09-05-2015
        '            If Me.CboTipo.SelectedValue = 1 Then
        '                Me.fnCalcularCostoDescuento()
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
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
                If CboProducto.SelectedValue = 81 or CboProducto.SelectedValue=82 Then
                    GrdDetalleVenta("Sub Neto", 0).Value = IIf(valor2 * tarifa_Peso = 0, "0.00", FormatNumber(Format((valor2 * tarifa_Peso), "###,###,###.00"), 2))
                Else
                    GrdDetalleVenta("Sub Neto", 0).Value = IIf(valor1 * tarifa_Peso = 0, "0.00", FormatNumber(Format((valor1 * tarifa_Peso), "###,###,###.00"), 2))
                End If
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
                If Me.CboProducto.SelectedValue <> 81 Or Me.CboProducto.SelectedValue <> 82 Then
                    If CboProducto.SelectedValue = 81 Then
                        GrdDetalleVenta("Sub Neto", 1).Value = IIf(valor2 * tarifa_Volumen = 0, "0.00", FormatNumber(Format((valor2 * tarifa_Volumen), "###,###,###.00"), 2))
                    Else
                        GrdDetalleVenta("Sub Neto", 1).Value = IIf(valor1 * tarifa_Volumen = 0, "0.00", FormatNumber(Format((valor1 * tarifa_Volumen), "###,###,###.00"), 2))
                    End If
                End If
            End If

            '****************CALCULO [PESO/VOLUMEN] * [COSTO] Row=2*********************************
            If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 2).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta("Peso/Volumen", 2).Value '--> campo [Peso/Vol] Fila [Sobre]
                If Conversion.Val(GrdDetalleVenta("Bulto", 2).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta("Bulto", 2).Value '----------------> campo [Piezas]   Fila [Sobre]

                GrdDetalleVenta("Sub Neto", 2).Value = IIf(valor2 * tarifa_Sobre = 0, "0.00", FormatNumber(Format((valor2 * tarifa_Sobre), "###,###,###.00"), 2))
            End If
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
            If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                If Conversion.Val(GrdDetalleVenta("Sub Neto", 2).Value) = 0 Then Sobre = 0 Else Sobre = GrdDetalleVenta("Sub Neto", 2).Value
            End If

            Dim SubTotal As Double = 0
            Dim Monto As Double = 0
            If Vol + Peso > 0 Then
                If CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                    SubTotal = (Monto_Base + Peso + Vol + Sobre) / (1 + Me.IGV)
                Else
                    If iControlMonto_Base = 1 Then
                        SubTotal = Monto_Base + Vol + Peso + Sobre
                    Else
                        SubTotal = Vol + Peso + Sobre
                    End If
                End If
            Else
                If CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                    SubTotal = (Monto_Base + Peso + Vol + Sobre) / (1 + Me.IGV)
                Else
                    SubTotal = Vol + Peso + Sobre
                End If
            End If

            Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            '*******APLICACION CARGA ASEGURADA****************
            'hlamas 23-11-2013
            Dim intFila As Integer
            If es_carga_asegurada Then
                If bTarifarioGeneral And bContado Then
                    intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                    SubTotal += Format(Val(GrdDetalleVenta("Sub Neto", intFila).Value), "0.00")
                Else
                    SubTotal += Val(GrdDetalleVenta("Sub Neto", intFila).Value)
                End If
                'If bTarifarioGeneral And bContado Then
                '    SubTotal += Format(Val(GrdDetalleVenta("Sub Neto", 4).Value), "0.00")
                'Else
                '    SubTotal += Val(GrdDetalleVenta("Sub Neto", 4).Value)
                'End If
            End If
            '*******Entrega a domicilio*************************
            intFila = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
            If intFila > 0 Then
                SubTotal += Format(Val(GrdDetalleVenta("Sub Neto", intFila).Value), "0.00")
            End If
            '****************************************************
            '********************************DEVOLUCION DE CARGO************************************************
            intFila = BuscarItemVenta("DEV CARGO", GrdDetalleVenta)
            If intFila > 0 Then
                'dblMontoDC = ObtieneMontoDevolucionCargo()
                SubTotal += Format(Val(GrdDetalleVenta("Sub Neto", intFila).Value), "0.00")
            End If
            '********************************DEVOLUCION DE CARGO************************************************

            Dim SUB_TOTAL_GENERAL As Double = 0
            '********APLICACION DESCUENTO*********************
            If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                'hlamas 11-09-2015
                'SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                    SUB_TOTAL_GENERAL = RedondearMas(SUB_TOTAL_GENERAL, 1)
                End If

                If bTarifarioGeneral And bContado Then
                    'hlamas 11-09-2015
                    'SUB_TOTAL_GENERAL = fnTECHO(Format(SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                    SUB_TOTAL_GENERAL = Format(SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                    If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                        SUB_TOTAL_GENERAL = RedondearMas(SUB_TOTAL_GENERAL, 1)
                    End If
                End If
            Else
                If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If


            If (SUB_TOTAL_GENERAL < monto_minimo_PCE) Then
                'TxtDescuento.Enabled = False
                Me.CondicionMontoMinimoPCE()
            Else
                TxtDescuento.Enabled = True
                'Me.TxtDescuento.BackColor = Color.White

                '*****************************APLICACION CALCULO*******************************************************************************************************
                TxtSubTotal.Text = IIf(SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                TxtImpuesto.Text = IIf(IGV * SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                TxtTotal.Text = IIf(SUB_TOTAL_GENERAL = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL, "###,###,###.00"), 2))
                '******************************************************************************************************************************************************
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "GRABAR"

    '***GRABAR**
    Private Sub BtnGraba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGraba.Click
        Try
            If Not Validar() Then
                Return
            End If
            Me.Cursor = Cursors.AppStarting
            Me.Grabar()
            CboProducto.SelectedIndex = 0
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '****VALIDAR**
    Function Validar() As Boolean
        If Me.CboTipo.SelectedIndex = 0 Then
            Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
            objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
                MessageBox.Show("Aperture su Turno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Function
            End If
            objLIQUI_TURNOS = Nothing
        End If

        Dim b As Boolean = True
        If Me.TxtBoleto.Visible Then 'flagPCE And 
            If Me.TxtBoleto.Text.Trim.Length < 2 Then
                b = False
            ElseIf Not bCargaAcompañada Then
                b = False
            End If
        End If

        If Not b Then
            MessageBox.Show("Asocie un Boleto de Viaje al Comprobante de Venta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtBoleto.Focus()
            Me.Cursor = Cursors.Default
            Return False
        End If

        'hlamas 11-03-2019
        If Me.txtFechaGuia.Format = 8 Then
            MessageBox.Show("Ingrese la Fecha de Comprobante", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtFechaGuia.Focus()
            Return False
        End If

        'hlamas 13-10-2015
        If Me.txtFechaGuia.Value > FechaServidor() Then
            MessageBox.Show("La Fecha de Comprobante debe ser menor o igual a la Fecha actual", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtFechaGuia.Focus()
            Return False
        End If

        'hlamas 21-10-2015
        If Me.CboTipo.SelectedIndex = 1 Then
            Dim objCierre As New Cls_CierreProvision_LN
            If objCierre.ProvisionAbierta(Me.txtFechaGuia.Value.ToShortDateString) = 0 Then
                MessageBox.Show("La Fecha de Comprobante pertenece a un Período de Provisión Cerrado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtFechaGuia.Focus()
                Return False
            End If
        End If

        'hlamas 13-03-2014
        If Me.CboTipo.SelectedIndex = 1 AndAlso Me.CboProducto.SelectedValue <= 0 Then
            MessageBox.Show("El Cliente Crédito no tiene asociado ningún producto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cursor = Cursors.Default
            Me.CboProducto.Focus()
            Return False
        End If

        '----VALIDACION USUARIO REMOTO----       
        If CboListaUsuarios.SelectedValue = 0 And bNuevo = True Then
            MessageBox.Show("Seleccione el usuario remoto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboListaUsuarios.Focus()
            CboListaUsuarios.SelectAll()
            Return False
        End If

        If CboAgencia_Origen.SelectedValue = 0 And bNuevo = True Then
            MessageBox.Show("Seleccione la Agencia origen", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboAgenciaOrigen.Focus()
            CboAgenciaOrigen.SelectAll()
            Return False
        End If

        '----------------------------------
        '*******validacion del Nro Serie************
        'hlamas 11-03-2019
        'If Val(txtNroNroGuia.Text.Trim) = 0 Then
        '    MessageBox.Show("Ingrese el Número de Serie", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.Grbdestino.Focus()
        '    Return False
        '    'ElseIf Val(LblNroBoletaFact.Text.Trim) = 0 Then
        '    '    MessageBox.Show("Ingrese el Número de Comprobante", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    '    Me.BtnGrabar.Focus()
        '    '    Return False
        'End If

        If idUnidadAgencias <= 0 Then
            MessageBox.Show("Seleccione la Ciudad de Destino", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtCiudadDestino.Text = ""
            TxtCiudadDestino.Focus()
            TxtCiudadDestino.SelectAll()
            Return False
        End If

        If IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad) = idUnidadAgencias Then
            MessageBox.Show("Seleccione una Ciudad Destino diferente a la Ciudad Orígen", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtCiudadDestino.Focus()
            Me.TxtCiudadDestino.SelectAll()
            Return False
        End If

        If CboAgenciaDest.SelectedValue = 0 Then
            MessageBox.Show("Seleccione la Agencia de Destino", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboAgenciaDest.Focus()
            CboAgenciaDest.SelectAll()
            Return False
        End If

        If CboTipoEntrega.SelectedValue = 0 Then
            MessageBox.Show("Seleccione el Tipo de Entrega.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboTipoEntrega.Focus()
            Return False
        End If

        If CboTipo.SelectedValue = 1 Then
            If idUnidadAgencias = 601 Then
                MessageBox.Show("No están permitidos envíos para la ciudad destino seleccionada", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboTipo.Focus()
                Return False
            End If
        End If

        'If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 AndAlso TxtNroTarjeta.Text.Trim.Length = 0 Then
        '    MessageBox.Show("Ingrese Número de Tarjeta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    TxtNroTarjeta.Focus()
        '    TxtNroTarjeta.SelectAll()
        '    Return False
        'End If

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


        If (Me.CboSubCuenta.SelectedValue = -1 Or Me.CboSubCuenta.SelectedValue = 0) And Me.CboTipo.SelectedValue = 2 Then
            MessageBox.Show("Seleccione la subcuenta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboSubCuenta.Focus()
            Return False
        End If

        '*************************************Validacion de Campos*****************************************
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

                'hlamas 24-07-2015
                If Me.CboTipo.SelectedValue = 2 Then
                    'hlamas 22-03-2016
                    If dtCliente.Rows(0).Item("idtipo_facturacion") = 3 Then
                        If Not Me.rbtCargoSi.Checked Then
                            Me.chkDocumentoCliente.Checked = True
                            Me.rbtCargoSi.Checked = True
                        End If
                        'If TxtNroDocCliente.Text.ToString.Trim = "20100085225" Then
                        '    If Not TieneCargo() Then
                        '        MessageBox.Show("Ingrese Cargos del Cliente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '        Return False
                        '    End If
                    End If
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

        If iID_Persona = ID_PERSONA_ECKERD Then
            Dim obj As New dtoGuia
            Dim intResultado As Integer = obj.ClienteSubcuenta(iID_Persona, Me.CboSubCuentaOrigen.SelectedValue, Me.CboSubCuenta.SelectedValue)
            If intResultado > 1 Then
                If intResultado = 2 Then
                    MessageBox.Show("Seleccione una subcuenta diferente de GENERICO", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.CboSubCuentaOrigen.Focus()
                    Return False
                End If
                If intResultado = 3 Then
                    MessageBox.Show("Seleccione una subcuenta diferente de GENERICO", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.CboSubCuenta.Focus()
                    Return False
                End If
            End If
        ElseIf iID_Persona = ID_PERSONA_DATAIMAGENES And Me.CboCiudad_Origen.SelectedValue = 5100 Then
            If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                MessageBox.Show("El Cliente sólo puede realizar envíos en Agencia", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboTipoEntrega.Focus()
                Return False
            End If
        ElseIf iID_Persona = ID_PERSONA_OLVA AndAlso Me.CboCiudad_Origen.SelectedValue = 5100 And idUnidadAgencias <> 601 Then
            If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                MessageBox.Show("El Cliente sólo puede realizar envíos en Agencia", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboTipoEntrega.Focus()
                Return False
            End If

        End If

        '01092011
        'If Me.CboProducto.SelectedValue <> 6 AndAlso Me.CboDireccion.SelectedValue = 0 Then
        'If Me.CboTipo.SelectedValue = 2 AndAlso Me.CboDireccion.SelectedIndex = 0 Then
        'MessageBox.Show("Seleccione una Dirección", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Me.CboDireccion.Focus()
        'Return False
        'End If
        '----
        If Me.CboRemitente.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Remitente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboRemitente.Focus()
            Return False
        End If

        If Me.CboContacto.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Contacto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboContacto.Focus()
            Return False
        End If

        '-->10/09/2013 - jabanto - Reliza la validacion del ingreso del DT(Documento de Transporte), solo si es visible 
        '-->Es obligatorio si el producto seleccionado es CARGA EXPRESS, caso contrario es opcional
        'If (txtdt.Visible And CboProducto.SelectedValue = ID_PERSONA_CBC) Then
        '    If (txtdt.Text.Trim.Length = 0) Then
        '        MessageBox.Show("Ingrese el DT (Documento de Transporte)", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        txtdt.Focus()
        '        Return False
        '    ElseIf (txtdt.Text.Length < 7) Then '-->Valida que el campo DT contenga 7 digitos
        '        MessageBox.Show("El DT (Documento de Transporte) debe tener 7 dígitos", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        txtdt.Focus()
        '        Return False
        '    ElseIf Val(txtdt.Text) <= 0 Then
        '        MessageBox.Show("El DT (Documento de Transporte) debe ser válido", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        txtdt.Focus()
        '        Return False
        '    End If
        If (txtdt.Visible And CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER) Then
            'And dtoUSUARIOS.m_idciudad = 5100
            If Not Me.dtpFechaRecojo.Checked Then
                MessageBox.Show("Ingrese Fecha de Recojo", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpFechaRecojo.Focus()
                Return False
            End If
            If (txtdt.Text.Trim.Length = 0) Then
                MessageBox.Show("Ingrese el Documento de Transporte", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtdt.Focus()
                Return False
                'ElseIf (txtdt.Text.Length < 7) Then '-->Valida que el campo DT contenga 7 digitos
                '    MessageBox.Show("El DT (Documento de Transporte) debe tener 7 dígitos", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    txtdt.Focus()
                '    Return False
            ElseIf Val(txtdt.Text) <= 0 Then
                MessageBox.Show("El Documento de Transporte debe ser válido", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtdt.Focus()
                Return False
            End If
        ElseIf txtdt.Visible And txtdt.Text.Trim.Length > 0 Then
            If (txtdt.Text.Length < 7) Then '-->Valida que el campo DT contenga 7 digitos
                MessageBox.Show("El DT (Documento de Transporte) debe tener 7 dígitos", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtdt.Focus()
                Return False
            ElseIf Val(txtdt.Text) <= 0 Then
                MessageBox.Show("El DT (Documento de Transporte) debe ser válido", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtdt.Focus()
                Return False
            End If
        End If


        '-->jabanto - 14/09/2013. Realiza la valizadion SOLO PARA ECKERD si la subCuenta destino tiene configurado el CODIGO SAP.
        'If (CboTipo.SelectedValue = Cls_Constantes_LN.TIPO_CREDITO And CboProducto.SelectedValue = Cls_Constantes_LN.ID_PRODUCTO_CARGA_EXPRESA) Then
        '    If (iID_Persona = Cls_Constantes_LN.ID_PERSONA_ECKERD And CboSubCuenta.SelectedValue <> Cls_Constantes_LN.ID_CENTRO_COSTO_GENERICO) Then
        '        If IsDBNull(DirectCast(CboSubCuenta.SelectedItem, DataRowView)("codigoSap")) Then
        '            MessageBox.Show("No puede continuar con la emisión de la Guía," & Chr(13) & "la SubCuenta destino no tiene configurado un CÓDIGO SAP.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Return False
        '        End If
        '    End If
        'End If

        '*******validando nombre del Consignado********
        '***Comentado x NConsignado**************************
        'If TxtNombConsignado.Text.Trim.Length = 0 Then
        '    MessageBox.Show("Seleccione el Consignado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    TxtConsignado.Text = ""
        '    TxtConsignado.Focus()
        '    TxtConsignado.SelectAll()
        '    Return False
        'End If

        '=====Agregado(Reemplasado) x NConsignado=============
        If GrdNConsignado.Rows.Count = 0 Then
            MessageBox.Show("Ingrese el Consignado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtConsignado.Text = ""
            TxtConsignado.Focus()
            TxtConsignado.SelectAll()
            Return False
        End If
        '=====================================================

        If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio AndAlso Me.CboDireccion2.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione la Direccion del Consignado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboDireccion2.Focus()
            CboDireccion2.SelectAll()
            Return False
        End If

        Dim iDescuento As Integer = IIf(TxtDescuento.Text.Trim <> "", TxtDescuento.Text.Trim, 0)
        If iDescuento <> 0 Then
            If iDescuento < -100 Or iDescuento > 100 Then
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

        If Me.chkDocumentoCliente.Checked Then 'selecciono con documento del cliente
            If Me.rbtCargoSi.Checked = False And Me.rbtCargoNo.Checked = False Then 'no selecciono si documento cliente es con cargo o sin cargo
                MessageBox.Show("Seleccione si documento del cliente es " & Chr(13) & Chr(13) & "CON DEVOLUCION DE CARGO o SIN DEVOLUCION DE CARGO", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.rbtCargoSi.Focus()
                Me.rbtCargoSi.Checked = False
                Return False
            End If
            'hlamas 18-03-2015
            If Me.rbtCargoSi.Checked Then
                If Not ModuUtil.TieneCargo(Me.GrdDocumentosCliente, 2) Then
                    Dim frm As New frmCargoValidacion
                    frm.ShowDialog()
                    blnCargo = frm.rbtSi.Checked
                    If Not blnCargo Then
                        strObservacionCargo = frm.txtMotivo.Text.Trim
                    Else
                        strObservacionCargo = ""
                        Me.GrdDocumentosCliente.Focus()
                        Return False
                    End If
                End If
            Else
                If Not ModuUtil.TieneCargo(Me.GrdDocumentosCliente, 2) Then
                    MessageBox.Show("Ingrese Documentos del Cliente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.GrdDocumentosCliente.Focus()
                    Return False
                End If
            End If
        End If

        If (ChkArticulos.Checked = False) And ChkM3.Checked = False Then
            If Me.CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_SOBRES Then 'tepsa sobres
                If Val(GrdDetalleVenta.Rows(0).Cells(2).Value) > 0 Or Val(GrdDetalleVenta.Rows(0).Cells(1).Value) > 0 Then
                    MessageBox.Show("No puede Ingresar Peso", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
                If Val(GrdDetalleVenta.Rows(1).Cells(2).Value) > 0 Or Val(GrdDetalleVenta.Rows(1).Cells(1).Value) > 0 Then
                    MessageBox.Show("No puede Ingresar Volumen", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            Else
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

            '--> 10/09/2013 - jabanto - evita el registro de la guía con 0 bultos
            Dim isCorrectoCantBultos As Boolean = False
            '->valida cantidad Peso
            isCorrectoCantBultos = Val(GrdDetalleVenta.Rows(0).Cells(1).Value) > 0
            '->si es falso valida cantidad volumen
            If Not (isCorrectoCantBultos) Then isCorrectoCantBultos = Val(GrdDetalleVenta.Rows(1).Cells(1).Value) > 0
            '->si es falso valida cantidad sobres
            If Not (isCorrectoCantBultos) Then isCorrectoCantBultos = Val(GrdDetalleVenta.Rows(2).Cells(1).Value) > 0

            If Not (isCorrectoCantBultos) Then
                MessageBox.Show("Debe de completar el ingreso de la cantidad de bultos o Sobres, " & Chr(13) & "según la condición que corresponda.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        ElseIf Me.ChkArticulos.Checked Then 'hlamas 21-01-2016
            For Each row As DataGridViewRow In Me.GrdDetalleVenta.Rows
                If Me.CboTipo.SelectedIndex = 0 Then
                    If Val(row.Cells(2).Value) = 0 And Val(row.Cells(3).Value) > 0 Then
                        MessageBox.Show("Ingrese la Cantidad", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                    If Val(row.Cells(2).Value) > 0 And Val(row.Cells(3).Value) = 0 Then
                        MessageBox.Show("Ingrese el Peso", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                Else
                    If Val(row.Cells(2).Value) = 0 And Val(row.Cells(4).Value) > 0 Then
                        MessageBox.Show("Ingrese la Cantidad", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                    If Val(row.Cells(2).Value) > 0 And Val(row.Cells(4).Value) = 0 Then
                        MessageBox.Show("Ingrese el Peso", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                End If

                'hlamas 11-03-2019
                'If Val(row.Cells(2).Value) = 0 And Val(row.Cells(3).Value) > 0 Then
                '    MessageBox.Show("Ingrese la Cantidad", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Return False
                'End If
                'If Val(row.Cells(2).Value) > 0 And Val(row.Cells(3).Value) = 0 Then
                '    MessageBox.Show("Ingrese el Peso", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Return False
                'End If
            Next
        End If

            '*******validando Monto Afecto**************
            Dim Sum As Double
            If Not ChkArticulos.Checked And CboTipo.SelectedValue = 1 Then
                For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 2 'CambioR 10112011
                    If GrdDetalleVenta("Sub Neto", i).Value < 0 Then
                        MessageBox.Show("Los Subtotales no deben ser negativos", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                    Sum += Val(GrdDetalleVenta("Sub Neto", i).Value)
                Next

                If Sum <= 0 Then
                    MessageBox.Show("Complete la Venta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.GrdDetalleVenta.Focus()
                    Return False
                End If
            End If

            If Val(TxtTotal.Text) <= 0 Then
                MessageBox.Show("Complete la Venta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.GrdDetalleVenta.Focus()
                Return False
            End If

            '01/09/2011
            'Informa si el cliente tiene crédito y va a emitir PCE
            If bNuevo Then
                If Me.CboTipo.SelectedValue = 1 AndAlso bTieneLineaCredito Then
                    Dim sMje As String
                    sMje = "El Cliente tiene Línea de Crédito." & vbCrLf
                    sMje &= "¿Está Seguro de Emitir un Pago Contraentrega?"
                    Dim dlgRespuesta As DialogResult
                    dlgRespuesta = MessageBox.Show(sMje, "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If dlgRespuesta = Windows.Forms.DialogResult.No Then
                        Return False
                    End If
                End If
            End If
            Return True
    End Function

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
    Public bControlFiscalizacion As Boolean = False
    Dim control_venta As Boolean
    Dim Mro_Digitos_SerieVentas As Integer = 3
    Sub Grabar()
        Try
            If Val(TxtDescuento.Text) = 0 Then
                TxtDescuento.Text = ""
            End If

            If bNuevo Then
                If CboTipo.SelectedValue <> 2 Then '=====> CONTADO INSERTAR
                    If fnGrabarContado() = True Then
                        'hlamas 11-03-2019
                        'If ObjVentaCargaContado.fnNroDocuemnto(3, CboProducto.SelectedValue) = True Then
                        '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                        '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                        '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
                        'ElseIf ObjVentaCargaContado.fnNroDocuemnto(3, 0) = True Then
                        '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                        '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                        '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
                        'End If
                        sDocCliente = ""
                        bBoleto = False
                        BtnCargAseg.Enabled = True
                        RemoveItemsCargAseg()
                    End If
                End If
            Else
                If CboTipo.SelectedValue <> 2 Then '=====> CONTADO ACTUALIZAR
                    If FnActualizarContado() = True Then
                        sDocCliente = ""
                        bBoleto = False
                        TabGuia.SelectTab(0)
                        'Dim sender As Object
                        'Dim e As New System.ComponentModel.CancelEventArgs
                        'BtnBuscar_Click(sender, e)
                    End If
                End If
            End If

            If bNuevo Then
                If CboTipo.SelectedValue = 2 Then '==========> CREDITO INSERTAR 
                    If FnGrabarCredito() = True Then
                        'hlamas 11-03-2019
                        'If ObjVentaCargaContado.fnNroDocuemnto(3, 0) = True Then 'nota 0 x q no tiene producto=0
                        '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                        '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                        '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
                        'End If
                    End If
                End If
                BtnCargAseg.Enabled = False
            Else
                If CboTipo.SelectedValue = 2 Then '==========> CREDITO ACTUALIZAR 
                    If FnActualizarCredito() = True Then
                        Dim strGuia As String = Me.DgvLista.CurrentRow.Cells("guia").Value
                        Me.Cursor = Cursors.AppStarting
                        Dim iGuia As Long = strGuia
                        Listar(iGuia)
                        Me.Cursor = Cursors.Default

                        TabGuia.SelectTab(0)
                        'Dim sender As Object
                        'Dim e As New System.ComponentModel.CancelEventArgs
                        'BtnBuscar_Click(sender, e)
                    End If
                End If
            End If


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '**INSERTAR CONTADO
    Dim ObjIMPRESIONFACT_BOL As New dtoIMPRESIONFACT_BOL
    Dim ConfiMensajeriaDlg As New FrmConfiMensajeria
    Public Function fnGrabarContado() As Boolean
        Dim flat As Boolean = False
        Try
            'PARAMETRO TIPO_COMPROBANTE
            If CboTipo.SelectedValue = 1 Then
                ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85
            ElseIf CboTipo.SelectedValue = 3 Then
                ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 86
            End If

            'PARAMETRO v_SERIE_FACTURA******************************************
            ObjVentaCargaContado.v_SERIE_FACTURA = "000"
            'PARAMETRO v_NRO_FACTURA********************************************
            'hlamas 11-03-2019
            'ObjVentaCargaContado.v_NRO_FACTURA = txtNroNroGuia.Text
            ObjVentaCargaContado.v_NRO_FACTURA = ""
            'PARAMETRO FECHA INGRESO (FECHA_FACTURA)****************************
            If bControlFiscalizacion = False Then
                ObjVentaCargaContado.v_FECHA_FACTURA = dtoUSUARIOS.m_sFecha
            Else
                ObjVentaCargaContado.v_FECHA_FACTURA = Format("DD/MM/YYYY", Me.txtFechaGuia.Text)
            End If
            'PARAMETRO PRODUCTO (IDPROCESOS)************************************
            ObjVentaCargaContado.v_iProceso = CboProducto.SelectedValue
            'PARAMETRO TIPO TARIFA**********************************************
            ObjVentaCargaContado.TipoTarifa = CboTipoTarifa.SelectedValue 'IIf(CboTipoTarifa.SelectedIndex = -1, 0, CboTipoTarifa.SelectedIndex)
            'PARAMETROS CIUDAD ORIGEN (IDUNIDAD_ORIGEN)*************************
            ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = CboCiudad_Origen.SelectedValue 'dtoUSUARIOS.m_idciudad

            'PARAMETRO AGENCIA ORIGEN*******************************************
            ObjVentaCargaContado.v_IDAGENCIAS = CboAgencia_Origen.SelectedValue 'dtoUSUARIOS.m_iIdAgencia

            'PARAMETRO CIUDAD DESTINO*******************************************
            If idUnidadAgencias > 0 Then
                'PARAMETRO (IDCIUDAD_DESTINO)***********************************
                ObjVentaCargaContado.v_IDUNIDAD_DESTINO = idUnidadAgencias
                'PARAMETRO (IDAGENCIA_DESTINO*********************************
                ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = CboAgenciaDest.SelectedValue
            End If

            'PARAMETRO TIPO ENTREGA (IDTIPO_ENTREGA)****************************
            ObjVentaCargaContado.v_IDTIPO_ENTREGA = CboTipoEntrega.SelectedValue
            'PARAMETRO TIPO PAGO (IDTIPO_PAGO)**********************************efectivo, tarjeta, cortesia
            ObjVentaCargaContado.v_IDTIPO_PAGO = 1 'Int(ObjVentaCargaContado.coll_Tipo_Pago(CboFormaPago.SelectedIndex.ToString))
            'PARAMETRO 
            ObjVentaCargaContado.v_IDFORMA_PAGO = IIf(CboTipo.SelectedValue = 1, 3, CboTipo.SelectedValue)
            'PARAMETRO TARGETAS (IDTARJETAS)************************************
            ObjVentaCargaContado.v_IDTARJETAS = 0
            ObjVentaCargaContado.v_NROTARJETA = "@"
            If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 Then
                'PARAMETRO IDTARJETAS******            
                ObjVentaCargaContado.v_IDTARJETAS = 0 'Int(ObjVentaCargaContado.coll_T_TARJETAS(CboTarjeta.SelectedIndex.ToString))
                'PARAMETRO NROTARJETA******
                ObjVentaCargaContado.v_NROTARJETA = "@" 'IIf(TxtNroTarjeta.Text <> "", TxtNroTarjeta.Text, "@")
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
            If CboDireccion.SelectedValue = 0 Then
                IdDireccionOrigen = -1 '--> sin direccion valor(seleccione)
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
            ObjVentaCargaContado.ID_TipoDocCli = iID_TipoDocCli
            ObjVentaCargaContado.NombresCliente = sNombresCli
            ObjVentaCargaContado.apellPatCli = sApCli
            ObjVentaCargaContado.apellMatCli = sAmCli
            ObjVentaCargaContado.TelefCliente = IIf(sTelfCliente.Length > 0, sTelfCliente, "@")
            ObjVentaCargaContado.sEmail = sEmail.trim '07092011

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

            '=============================DATOS REMITENTE=====================================
            'PARAMETRO ID_NOMBRE_REMITENTE**
            If CboRemitente.SelectedIndex = 0 Then
                idRemitente = -1
            End If
            If idcontacto = 0 AndAlso Me.ChkCliente.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNumDocRemitente.Text)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    Me.TxtNumDocRemitente.Tag = 0
                    idRemitente = 0
                Else
                    Me.TxtNumDocRemitente.Tag = dt.Rows(0).Item(0)
                    idRemitente = dt.Rows(0).Item(0)
                    bRemitenteModificado = False
                End If
            End If
            'PARAMETRO NOMBRE REMITENTE*****
            ObjVentaCargaContado.iIDRemitente = idRemitente
            ObjVentaCargaContado.sNombresRemitente = IIf(idRemitente = -1, "@", CboRemitente.Text)
            ObjVentaCargaContado.iRemitenteModificado = IIf(bRemitenteModificado, 1, 0)
            ObjVentaCargaContado.sNumeroDocumento = IIf(sNroDocRemitente.Trim = "", "@", sNroDocRemitente.Trim)
            ObjVentaCargaContado.iID_TipoDocumentoRemitente = iID_TipoDocRemitente
            ObjVentaCargaContado.sNombreRemitente = sNombreRemitente
            ObjVentaCargaContado.sApellidoPaternoRemitente = sApRemitente
            ObjVentaCargaContado.sApellidoMaternoRemitente = sAmRemitente

            '=============================DATOS CONTACTO======================================           
            'PARAMETRO ID_NOMBRE_CONTACTO**          
            If CboContacto.SelectedIndex = 0 Then
                idcontacto = -1
            End If
            If idcontacto = 0 AndAlso Me.ChkCliente1.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNroDocContacto.Text)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    Me.TxtNroDocContacto.Tag = 0
                    idcontacto = 0
                Else
                    Me.TxtNroDocContacto.Tag = dt.Rows(0).Item(0)
                    idcontacto = dt.Rows(0).Item(0)
                    bContactoModificado = False
                End If
            End If
            'PARAMETRO NOMBRE CONTACTO*****
            ObjVentaCargaContado.v_IDPERSONA_ORIGEN = idcontacto
            ObjVentaCargaContado.v_NOMBRES_REMITENTE = IIf(idcontacto = -1, "@", CboContacto.Text)
            ObjVentaCargaContado.contacto_mod = IIf(bContactoModificado, 1, 0)
            ObjVentaCargaContado.v_NRO_DOC_REMITENTE = IIf(Trim(TxtNroDocContacto.Text) <> "", TxtNroDocContacto.Text, "@")
            ObjVentaCargaContado.ID_TipoDocCont = iID_TipoDocCont
            ObjVentaCargaContado.NombreCont = NombresCont
            ObjVentaCargaContado.apellPatCont = apellPatCont
            ObjVentaCargaContado.apellMatCont = apellMatCont

            '======================================CONSIGNADO=================================  
            '====Agregado x NConsignado================================
            If Me.iIDConsignado = 0 AndAlso Me.ChkCliente2.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(GrdNConsignado("Nº Documento", 0).Value) 'TxtNroDocConsignado.Text Comentado
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    iIDConsignado = 0
                    GrdNConsignado("IDConsignado", 0).Value = "0"
                Else
                    iIDConsignado = dt.Rows(0).Item(0)
                    GrdNConsignado("IDConsignado", 0).Value = dt.Rows(0).Item(0)
                    bConsignadoModificado = True
                End If
            End If

            '***Comentado x NConsignado***********************
            'If Me.iIDConsignado = 0 AndAlso Me.ChkCliente2.Checked Then
            '    Dim objContacto As New dtoVentaCargaContado
            '    Dim dt As DataTable = objContacto.BuscarContacto(TxtNroDocConsignado.Text)
            '    Dim resp As Integer = dt.Rows.Count
            '    If resp = 0 Then
            '        iIDConsignado = 0
            '    Else
            '        iIDConsignado = dt.Rows(0).Item(0)
            '        bConsignadoModificado = True
            '    End If
            'End If

            '***Comentado x NConsignado***********************
            'PARAMETRO ID_NOMBRE_CONSIGNADO**
            'ObjVentaCargaContado.v_IDCONTACTO_DESTINO = IIf(IsNothing(iIDConsignado), 0, iIDConsignado)
            ''ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Trim(sNombresConsig.Trim) <> "", sNombresConsig.Trim, "@")
            'ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Me.TxtNombConsignado.Text.Trim <> "", Me.TxtNombConsignado.Text.Trim, "@")
            'ObjVentaCargaContado.NombConsignado_mod = IIf(bConsignadoModificado, 1, 0)
            'ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO = IIf(Trim(TxtNroDocConsignado.Text) <> "", TxtNroDocConsignado.Text, "@")
            'ObjVentaCargaContado.ID_TipoDocConsig = iID_TipoDocConsig
            'ObjVentaCargaContado.NombreConsignado = sNombresConsig
            'ObjVentaCargaContado.apellPatConsig = sapellPatConsig
            'ObjVentaCargaContado.apellMatConsig = sapellMatConsig
            'ObjVentaCargaContado.TelfConsignado = IIf(sTelefonoConsig.Length > 0, sTelefonoConsig, "@")

            '===Agregado x NConsignado==============================
            Me.LimpiarNConsignados()
            For i As Integer = 0 To GrdNConsignado.Rows.Count() - 1
                ObjVentaCargaContado.v_IDCONTACTO_DESTINO &= GrdNConsignado("IDConsignado", i).Value & ";"
                ObjVentaCargaContado.v_NOMBRES_DESTINATARIO &= GrdNConsignado("Nombres", i).Value & ";"
                ObjVentaCargaContado.NombreConsignado &= GrdNConsignado("nombre", i).Value & ";"
                ObjVentaCargaContado.apellPatConsig &= GrdNConsignado("apepat", i).Value & ";"
                ObjVentaCargaContado.apellMatConsig &= GrdNConsignado("apemat", i).Value & ";"
                ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO &= GrdNConsignado("Nº Documento", i).Value & ";"
                ObjVentaCargaContado.ID_TipoDocConsig &= GrdNConsignado("tipo", i).Value & ";"
                ObjVentaCargaContado.TelfConsignado &= GrdNConsignado("Telefono", i).Value & ";"
                ObjVentaCargaContado.NombConsignado_mod &= GrdNConsignado("Modificado", i).Value & ";"
            Next
            '========================================================

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
            ObjVentaCargaContado.sReferencia = TxtReferencia.Text.Trim '09092011

            '---Nuevos Parametros a agregar---
            ObjVentaCargaContado.TarifarioGeneral = IIf(bTarifarioGeneral, 1, 0)
            ObjVentaCargaContado.Contado = IIf(bContado, 1, 0)
            ObjVentaCargaContado.v_MONTO_MINIMOs = monto_minimo_PCE

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
            'hlamas 22-03-2016
            'ObjVentaCargaContado.v_cargo = Me.ChkCargo.Checked
            ObjVentaCargaContado.v_cargo = Me.rbtCargoSi.Checked

            ObjVentaCargaContado.v_idagencia_venta = 0 'dtoUSUARIOS.m_iIdAgencia
            ObjVentaCargaContado.v_idciudad_venta = 0 'dtoUSUARIOS.m_idciudad

            If CboProducto.SelectedValue = 6 Then 'PARAMETROS CARGA ACOMPAÑADA
                'ObjVentaCargaContado.v_nroboleto = Me.TxtBoleto.Text
                ObjVentaCargaContado.v_nroboleto = IIf(Me.TxtBoleto.Text.Trim = "-", "", Me.TxtBoleto.Text.Trim)
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
            If (ChkArticulos.Checked = False Or ChkArticulos.Enabled = False) And ChkM3.Checked = False Then
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
                If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                    If IsDBNull(GrdDetalleVenta.Rows(2).Cells(2)) = False Then
                        If Conversion.Val(GrdDetalleVenta(1, 2).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 2).Value
                        ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = valor1
                        totalCosto = totalCosto + valor1 * tarifa_Sobre
                    End If
                End If

                tarifa_Peso = Format(Val(GrdDetalleVenta(3, 0).Value), "##,###,###.00")
                tarifa_Volumen = Format(Val(GrdDetalleVenta(3, 1).Value), "##,###,###.00")
                If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                    tarifa_Sobre = Format(Val(GrdDetalleVenta(3, 2).Value), "##,###,###.00")
                End If
            End If

            '******************************GRID M3*********************************
            If ChkM3.Checked = True Then
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
                ObjVentaCargaContado.v_FACTOR = dFactor
                '**************

                'MOD***
                tarifa_Peso = Format(Val(GrdDetalleVenta(6, 0).Value), "##,###,###.00")
                tarifa_Sobre = Format(Val(TxtMontoBase.Text), "##,###,###.00")
                '******
            Else
                ObjVentaCargaContado.v_METROCUBICO = 0
                ObjVentaCargaContado.v_ALTURA = 0
                ObjVentaCargaContado.v_ANCHO = 0
                ObjVentaCargaContado.v_LARGO = 0
                ObjVentaCargaContado.v_PESO_KG = 0
                ObjVentaCargaContado.v_FACTOR = 0
            End If

            If ChkSobres.Checked = True Then
                ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = Val(txtCantidadSobres.Text)
            End If

            ObjVentaCargaContado.v_PRECIO_X_PESO = tarifa_Peso
            ObjVentaCargaContado.v_PRECIO_X_VOLUMEN = tarifa_Volumen
            ObjVentaCargaContado.v_PRECIO_X_SOBRE = tarifa_Sobre


            ObjVentaCargaContado.v_MONTO_SUB_TOTAL = TxtSubTotal.Text
            ObjVentaCargaContado.v_MONTO_IMPUESTO = TxtImpuesto.Text
            ObjVentaCargaContado.v_TOTAL_COSTO = TxtTotal.Text

            ObjVentaCargaContado.v_IDTIPO_MONEDA = 1 'Soles

            '--USUARIO REMOTO----
            ObjVentaCargaContado.v_IDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin
            ObjVentaCargaContado.iIDUsuarioRemoto = dtoUSUARIOS.IdLogin
            '--------------------

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

            'hlamas 19-11-2013
            ObjVentaCargaContado.MontoEntregaDomicilio = dblMontoEntregaDomicilio
            'hlamas 17-02-2015
            ObjVentaCargaContado.MontoDC = dblMontoDC

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
            End If

            'CboTipoEntrega
            ObjIMPRESIONFACT_BOL.fnClear()

            '**MOD***********************************
            If ChkArticulos.Checked = False And ChkArticulos.Enabled = False And ChkM3.Checked = False Then '--BULTOS
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = Val(GrdDetalleVenta("Sub Neto", 0).Value)
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = Val(GrdDetalleVenta("Sub Neto", 1).Value)
                If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                    ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(GrdDetalleVenta("Sub Neto", 2).Value)
                End If
            ElseIf ChkArticulos.Checked = True Then
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = "0.00" '---ARTICULOS
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = "0.00"
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = "0.00"
            End If

            If ChkM3.Checked = True Then
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

            ObjIMPRESIONFACT_BOL.xOrigen = ObjVentaCargaContado.v_UNIDAD_ORIGEN
            ObjIMPRESIONFACT_BOL.xDestino = TxtCiudadDestino.Text
            'hlamas 11-03-2019
            'ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL = Me.txtNroNroGuia.Text '& "-" & Me.LblNroBoletaFact.Text
            ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL = ""
            ObjIMPRESIONFACT_BOL.xRazonSocial = Me.TxtNomCliente.Text.Trim
            'ObjIMPRESIONFACT_BOL.xDireccionRemitente = Me.TxtDirecCliente.Text
            ObjIMPRESIONFACT_BOL.xRuc = TxtNroDocCliente.Text
            'ObjIMPRESIONFACT_BOL.xConsignado = Me.TxtNombConsignado.Text
            ObjIMPRESIONFACT_BOL.xConsignado = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO ' 'Me.TxtNombConsignado.Text 'Agregado NConsignado
            'ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.TxtDirecConsignado.Text'verificar
            ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.CboDireccion2.Text
            ObjIMPRESIONFACT_BOL.xfecha_factura = Me.txtFechaGuia.Text
            ObjIMPRESIONFACT_BOL.xTotalPeso = ObjVentaCargaContado.v_TOTAL_PESO
            ObjIMPRESIONFACT_BOL.xTotalVolumen = ObjVentaCargaContado.v_TOTAL_VOLUMEN
            ObjIMPRESIONFACT_BOL.xTotalSobres = 0
            ObjIMPRESIONFACT_BOL.xFormaPago = CboTipo.Text
            'hlamas 11-03-2019
            'ObjIMPRESIONFACT_BOL.xNroRef = Me.txtNroNroGuia.Text '& "-" & Me.LblNroBoletaFact.Text
            ObjIMPRESIONFACT_BOL.xNroRef = ""
            ObjIMPRESIONFACT_BOL.xMemo = Me.txtDescDescto.Text
            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total = Me.TxtSubTotal.Text
            ObjIMPRESIONFACT_BOL.xMonto_Impuesto = TxtImpuesto.Text
            ObjIMPRESIONFACT_BOL.xTotal_Costo = ObjVentaCargaContado.v_TOTAL_COSTO
            ObjIMPRESIONFACT_BOL.xDescuento = IIf(TxtDescuento.Text <> "", TxtDescuento.Text, "")
            ObjIMPRESIONFACT_BOL.xAgenciaDestino = IIf(CboAgenciaDest.Text <> "", CboAgenciaDest.Text, "")
            ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = CboTipoEntrega.Text


            'hlamas 11-03-2019
            'If fnDigito_Chequeo(txtNroNroGuia.Text) = True Then
            txtNroNroGuia.Text = RellenoRight(NroDigitos_Guias, txtNroNroGuia.Text.Trim)
            ObjVentaCargaContado.v_SERIE_FACTURA = "000"
            ObjVentaCargaContado.v_NRO_FACTURA = txtNroNroGuia.Text
            ' ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85              
            'IMPRESION DE GUIA DE ENVIO
            '***************************************************************************************************************************
            Try
                v_Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
                v_destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            Catch ex As Exception
                MsgBox("Verifique sus datos de IATA en la GUIA", MsgBoxStyle.Information, "Seguridad Sistema")
            End Try

            v_iDestino = "       "
            v_iCredito = "       "
            v_iDomicilio = "      "
            v_iAgencia = "      "

            If CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
                p_domicilio = ""
                p_agencia = "X"
            Else
                p_domicilio = "X"
                p_agencia = ""
            End If

            p_contado = ""
            p_destino = "X"
            p_credito = ""

            ObjRptGuiaEnvio.p_NroGUIA = txtNroNroGuia.Text
            ObjRptGuiaEnvio.p_tipo_entrega = v_iDomicilio & v_iAgencia
            ObjRptGuiaEnvio.p_ruc = TxtNroDocCliente.Text & "-" & ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL

            ObjRptGuiaEnvio.p_contacto = "FACTURAR A: " & IIf(CboContacto.Text <> "", CboContacto.Text, "") 'gnr
            ObjRptGuiaEnvio.p_codigo_iata_ori = v_Origen
            ObjRptGuiaEnvio.p_codigo_iata_desti = v_destino
            ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI = Me.TxtTelfCliente.Text
            'ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI = Me.TxtTelfConsignado.Text
            ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI = ObjVentaCargaContado.TelfConsignado 'GrdNConsignado("Telefono", 0).Value 'Me.TxtTelfConsignado.Text Comentado x NConsignado
            ObjRptGuiaEnvio.P_REMITENTE = Me.TxtNomCliente.Text
            ObjRptGuiaEnvio.P_DIRECCION_REMI = IIf(Me.CboDireccion.Text <> "", CboDireccion.Text, "") 'gnr
            ObjRptGuiaEnvio.P_DIRECCION_DESTI = IIf(Me.CboDireccion2.Text <> "", CboDireccion2.Text, "") 'gnr
            'ObjRptGuiaEnvio.P_NOMBRES_DESTI = Me.TxtNombConsignado.Text
            ObjRptGuiaEnvio.P_NOMBRES_DESTI = GrdNConsignado("Nombres", 0).Value 'Me.TxtNombConsignado.Text
            ObjRptGuiaEnvio.P_FECHA_GUIA = txtFechaGuia.Text
            'ObjRptGuiaEnvio.P_TOTAL_BULTOS = ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_CANTIDAD_X_ARTICULO + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN
            ObjRptGuiaEnvio.P_TOTAL_BULTOS = ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_MONTO_PENALIDAD + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN
            ObjRptGuiaEnvio.P_TOTAL_VOLUMEN = ObjVentaCargaContado.v_TOTAL_VOLUMEN
            ObjRptGuiaEnvio.P_TOTAL_PESO = ObjVentaCargaContado.v_TOTAL_PESO + ObjVentaCargaContado.v_MONTO_RECARGO
            ObjRptGuiaEnvio.P_TOTAL_SOBRES = IIf(ObjVentaCargaContado.v_CANTIDAD_X_SOBRE.ToString() <> "", ObjVentaCargaContado.v_CANTIDAD_X_SOBRE.ToString(), " ")

            ObjCODIGOBARRA.Cantidad = ObjRptGuiaEnvio.P_TOTAL_BULTOS
            ObjCODIGOBARRA.NroDOC = Mid(ObjRptGuiaEnvio.p_NroGUIA, 7, Len(ObjRptGuiaEnvio.p_NroGUIA))
            ObjCODIGOBARRA.clinte = ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL
            ObjCODIGOBARRA.Origen = v_Origen
            ObjCODIGOBARRA.Destino = v_destino & IIf(es_carga_asegurada = True, v_ca, "")
            ObjCODIGOBARRA.AGEDOM = "PCE"  'Mid(cmbTipo_Entrega.Text, 1, 3)
            ObjRptGuiaEnvio.P_PROVINCIA = TxtCiudadDestino.Text
            '**********************************************************************************************************************************************
            'End If


            asignar_documentos_clientes()

            If ObjVentaCargaContado.GrabarVIII() = True Then
                ConfiMensajeriaDlg = New FrmConfiMensajeria
                Acceso.Asignar(ConfiMensajeriaDlg, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    'hlamas 14-08-2015
                    ConfiMensajeriaDlg.Tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                    ConfiMensajeriaDlg.Comprobante = ObjVentaCargaContado.v_IDFACTURA
                    ConfiMensajeriaDlg.ShowDialog()
                Else
                    MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ConfiMensajeriaDlg = Nothing

                TipoComprobante = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = CboTipoEntrega.Text   ' 27/04/2007
                ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString

                '-----------------------------------------------------------------
                'INSERCION VOLUMETRICO
                '-----------------------------------------------------------------
                Try
                    If ChkM3.Checked = True Then
                        Dim obj As New dtoVentaCargaContado
                        Dim ii As Integer = 0
                        objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                        objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
                        objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                        objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin USUARIO REMOTO
                        objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol
                        'hlamas 28-11-2013
                        For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                            If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                If GrdDetalleVenta.Rows(ii).Cells("sub neto").Value > 0 And IsNumeric(GrdDetalleVenta.Rows(ii).Cells("Tipo").Value) Then
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
                                             dFactor,
                                             GrdDetalleVenta.Rows(ii).Cells("Costo").Value)
                                End If
                            End If
                        Next
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                '-----------------------------------------------------------------
                'INSERCION DE ARTICULOS
                '-----------------------------------------------------------------
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
                        objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin USUARIO REMOTO
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
                                    objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
                                End If
                            End If
                        Next
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                '-----------------------------------------------------------------
                'INSERCION DE DOCUMENTOS DEL CLIENTE
                '-----------------------------------------------------------------   
                flat = True
                Dim i As Integer = 0
                Dim serie_NroDoc() As String
                objGuiaEnvio.iControl_Documentos = 1
                objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                objGuiaEnvio.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue '--> USUARIO REMOTO
                Dim iContador As Integer = 0
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

                '****************************************************************************************************
                'If Me.CboTipo.SelectedIndex <> 2 Then
                '    If bControlFiscalizacion = False Then
                '        If MsgBox("Esta Seguro de Imprimir GUIA DE ENVIO ?.....", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                '            ImprimirGuiaEnvio()
                '        End If
                '    End If
                'End If

                'If Me.CboTipo.SelectedIndex <> 2 Then
                '    If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then
                '        If xIMPRESORA = 1 Then
                '            fnImprimirEtiquetas()
                '        Else
                '            If xIMPRESORA = 2 Then
                '                fnImprimirEtiquetasFAC_II()
                '            Else
                '                fnImprimirEtiquetasFAC_III()
                '            End If
                '            'fnImprimirEtiquetasFAC_II()
                '        End If
                '    End If
                'End If
                ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text
                TipoComprobante = 2
                FNNUEVO()
                'limpiar_documentos_cliente()
                flat = True
                iOficinaDestino = 0
            End If
            bOrigenDiferente = False
        Catch ex As Exception
            flat = False
            Throw New Exception(ex.Message)
        End Try
        Return flat
    End Function

    '**ACTUALIZAR CONTADO
    Public Function FnActualizarContado() As Boolean
        Dim flat As Boolean = False
        Try
            'PARAMETRO TIPO_COMPROBANTE
            If CboTipo.SelectedValue = 1 Then
                ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85
            ElseIf CboTipo.SelectedValue = 3 Then
                ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 86
            End If

            'PARAMETRO v_SERIE_FACTURA******************************************
            ObjVentaCargaContado.v_SERIE_FACTURA = "000"
            'PARAMETRO v_NRO_FACTURA********************************************
            ObjVentaCargaContado.v_NRO_FACTURA = txtNroNroGuia.Text
            'PARAMETRO FECHA INGRESO (FECHA_FACTURA)****************************
            'If bControlFiscalizacion = False Then
            'ObjVentaCargaContado.v_FECHA_FACTURA = dtoUSUARIOS.m_sFecha
            'Else
            ObjVentaCargaContado.v_FECHA_FACTURA = Format("DD/MM/YYYY", Me.txtFechaGuia.Text)
            'End If
            'PARAMETRO PRODUCTO (IDPROCESOS)************************************
            ObjVentaCargaContado.v_iProceso = CboProducto.SelectedValue
            'PARAMETRO TIPO TARIFA**********************************************
            ObjVentaCargaContado.TipoTarifa = CboTipoTarifa.SelectedValue 'IIf(CboTipoTarifa.SelectedIndex = -1, 0, CboTipoTarifa.SelectedIndex)
            'PARAMETROS CIUDAD ORIGEN (IDUNIDAD_ORIGEN)*************************
            ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = CboCiudad_Origen.SelectedValue 'dtoUSUARIOS.m_idciudad

            'PARAMETRO AGENCIA ORIGEN*******************************************
            ObjVentaCargaContado.v_IDAGENCIAS = CboAgencia_Origen.SelectedValue 'dtoUSUARIOS.m_iIdAgencia

            'PARAMETRO CIUDAD DESTINO*******************************************
            If idUnidadAgencias > 0 Then
                'PARAMETRO (IDCIUDAD_DESTINO)***********************************
                ObjVentaCargaContado.v_IDUNIDAD_DESTINO = idUnidadAgencias
                'PARAMETRO (IDAGENCIA_DESTINO*********************************
                ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = CboAgenciaDest.SelectedValue
            End If

            'PARAMETRO TIPO ENTREGA (IDTIPO_ENTREGA)****************************
            ObjVentaCargaContado.v_IDTIPO_ENTREGA = CboTipoEntrega.SelectedValue
            'PARAMETRO TIPO PAGO (IDTIPO_PAGO)**********************************efectivo, tarjeta, cortesia
            ObjVentaCargaContado.v_IDTIPO_PAGO = 1 'Int(ObjVentaCargaContado.coll_Tipo_Pago(CboFormaPago.SelectedIndex.ToString))
            'PARAMETRO 
            ObjVentaCargaContado.v_IDFORMA_PAGO = IIf(CboTipo.SelectedValue = 1, 3, CboTipo.SelectedValue)
            'PARAMETRO TARGETAS (IDTARJETAS)************************************
            ObjVentaCargaContado.v_IDTARJETAS = 0
            ObjVentaCargaContado.v_NROTARJETA = "@"
            If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 Then
                'PARAMETRO IDTARJETAS******            
                ObjVentaCargaContado.v_IDTARJETAS = 0 'Int(ObjVentaCargaContado.coll_T_TARJETAS(CboTarjeta.SelectedIndex.ToString))
                'PARAMETRO NROTARJETA******
                ObjVentaCargaContado.v_NROTARJETA = "@" 'IIf(TxtNroTarjeta.Text <> "", TxtNroTarjeta.Text, "@")
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
            If CboDireccion.SelectedIndex = 0 Then
                IdDireccionOrigen = -1 '--> sin direccion valor(seleccione)
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
            '---------DATOS DEL CLIENTE------'---------DATOS DEL CLIENTE------
            ObjVentaCargaContado.Cliente_mod = IIf(bClienteModificado, 1, 0)
            ObjVentaCargaContado.ID_TipoDocCli = iID_TipoDocCli
            ObjVentaCargaContado.NombresCliente = sNombresCli
            ObjVentaCargaContado.apellPatCli = sApCli
            ObjVentaCargaContado.apellMatCli = sAmCli
            ObjVentaCargaContado.TelefCliente = IIf(sTelfCliente.Length > 0, sTelfCliente, "@")
            ObjVentaCargaContado.sEmail = sEmail.trim '07092011

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

            '=============================DATOS REMITENTE=====================================
            'PARAMETRO ID_NOMBRE_REMITENTE**
            If CboRemitente.SelectedIndex = 0 Then
                idRemitente = -1
            End If
            If idRemitente = 0 AndAlso Me.ChkCliente.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNumDocRemitente.Text)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    Me.TxtNumDocRemitente.Tag = 0
                    idRemitente = 0
                Else
                    Me.TxtNumDocRemitente.Tag = dt.Rows(0).Item(0)
                    idRemitente = dt.Rows(0).Item(0)
                    bRemitenteModificado = False
                End If
            End If
            'PARAMETRO NOMBRE REMITENTE*****
            ObjVentaCargaContado.iIDRemitente = idRemitente
            ObjVentaCargaContado.sNombresRemitente = IIf(idRemitente = -1, "@", CboRemitente.Text)
            ObjVentaCargaContado.iRemitenteModificado = IIf(bRemitenteModificado, 1, 0)
            ObjVentaCargaContado.sNumeroDocumento = IIf(sNroDocRemitente.Trim = "", "@", sNroDocRemitente.Trim)
            ObjVentaCargaContado.iID_TipoDocumentoRemitente = iID_TipoDocRemitente
            ObjVentaCargaContado.sNombreRemitente = sNombreRemitente
            ObjVentaCargaContado.sApellidoPaternoRemitente = sApRemitente
            ObjVentaCargaContado.sApellidoMaternoRemitente = sAmRemitente

            '=============================DATOS CONTACTO======================================           
            'PARAMETRO ID_NOMBRE_CONTACTO**          
            If CboContacto.SelectedIndex = 0 Then
                idcontacto = -1
            End If
            If idcontacto = 0 AndAlso Me.ChkCliente1.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNroDocContacto.Text)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    Me.TxtNroDocContacto.Tag = 0
                    idcontacto = 0
                Else
                    Me.TxtNroDocContacto.Tag = dt.Rows(0).Item(0)
                    idcontacto = dt.Rows(0).Item(0)
                    bContactoModificado = False
                End If
            End If
            'PARAMETRO NOMBRE CONTACTO*****
            ObjVentaCargaContado.v_IDPERSONA_ORIGEN = idcontacto
            ObjVentaCargaContado.v_NOMBRES_REMITENTE = IIf(idcontacto = -1, "@", CboContacto.Text)
            ObjVentaCargaContado.contacto_mod = IIf(bContactoModificado, 1, 0)
            ObjVentaCargaContado.v_NRO_DOC_REMITENTE = IIf(Trim(TxtNroDocContacto.Text) <> "", TxtNroDocContacto.Text, "@")
            ObjVentaCargaContado.ID_TipoDocCont = iID_TipoDocCont
            ObjVentaCargaContado.NombreCont = NombresCont
            ObjVentaCargaContado.apellPatCont = apellPatCont
            ObjVentaCargaContado.apellMatCont = apellMatCont

            '======================================CONSIGNADO=================================   
            '====Agregado x NConsignado================================
            If Me.iIDConsignado = 0 AndAlso Me.ChkCliente2.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(GrdNConsignado("Nº Documento", 0).Value) 'TxtNroDocConsignado.Text Comentado
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    iIDConsignado = 0
                    GrdNConsignado("IDConsignado", 0).Value = "0"
                Else
                    iIDConsignado = dt.Rows(0).Item(0)
                    GrdNConsignado("IDConsignado", 0).Value = dt.Rows(0).Item(0)
                    bConsignadoModificado = True
                End If
            End If

            '***Comentado x NConsignado***********************
            'If Me.iIDConsignado = 0 AndAlso Me.ChkCliente2.Checked Then
            '    Dim objContacto As New dtoVentaCargaContado
            '    Dim dt As DataTable = objContacto.BuscarContacto(TxtNroDocConsignado.Text)
            '    Dim resp As Integer = dt.Rows.Count
            '    If resp = 0 Then
            '        iIDConsignado = 0
            '    Else
            '        iIDConsignado = dt.Rows(0).Item(0)
            '        bConsignadoModificado = True
            '    End If
            'End If

            '***Comentado x NConsignado***********************
            'PARAMETRO ID_NOMBRE_CONSIGNADO**
            'ObjVentaCargaContado.v_IDCONTACTO_DESTINO = IIf(IsNothing(iIDConsignado), 0, iIDConsignado)
            ''ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Trim(sNombresConsig.Trim) <> "", sNombresConsig.Trim, "@")
            'ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Me.TxtNombConsignado.Text.Trim <> "", Me.TxtNombConsignado.Text.Trim, "@")
            'ObjVentaCargaContado.NombConsignado_mod = IIf(bConsignadoModificado, 1, 0)
            'ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO = IIf(Trim(TxtNroDocConsignado.Text) <> "", TxtNroDocConsignado.Text, "@")
            'ObjVentaCargaContado.ID_TipoDocConsig = iID_TipoDocConsig
            'ObjVentaCargaContado.NombreConsignado = sNombresConsig
            'ObjVentaCargaContado.apellPatConsig = sapellPatConsig
            'ObjVentaCargaContado.apellMatConsig = sapellMatConsig
            'ObjVentaCargaContado.TelfConsignado = IIf(sTelefonoConsig.Length > 0, sTelefonoConsig, "@")

            '===Agregado x NConsignado==============================
            Me.LimpiarNConsignados()
            For i As Integer = 0 To GrdNConsignado.Rows.Count() - 1
                ObjVentaCargaContado.v_IDCONTACTO_DESTINO &= GrdNConsignado("IDConsignado", i).Value & ";"
                ObjVentaCargaContado.v_NOMBRES_DESTINATARIO &= GrdNConsignado("Nombres", i).Value & ";"
                ObjVentaCargaContado.NombreConsignado &= GrdNConsignado("nombre", i).Value & ";"
                ObjVentaCargaContado.apellPatConsig &= GrdNConsignado("apepat", i).Value & ";"
                ObjVentaCargaContado.apellMatConsig &= GrdNConsignado("apemat", i).Value & ";"
                ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO &= GrdNConsignado("Nº Documento", i).Value & ";"
                ObjVentaCargaContado.ID_TipoDocConsig &= GrdNConsignado("tipo", i).Value & ";"
                ObjVentaCargaContado.TelfConsignado &= GrdNConsignado("Telefono", i).Value & ";"
                ObjVentaCargaContado.NombConsignado_mod &= GrdNConsignado("Modificado", i).Value & ";"
                ObjVentaCargaContado.IDVentaConsignado &= GrdNConsignado("IDVentaConsignado", i).Value & ";"
            Next
            '========================================================

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
            ObjVentaCargaContado.sReferencia = TxtReferencia.Text.Trim '09092011

            '---Nuevos Parametros a agregar---
            ObjVentaCargaContado.TarifarioGeneral = IIf(bTarifarioGeneral, 1, 0)
            ObjVentaCargaContado.Contado = IIf(bContado, 1, 0)
            ObjVentaCargaContado.v_MONTO_MINIMOs = monto_minimo_PCE

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
            'hlamas 22-03-2016
            'ObjVentaCargaContado.v_cargo = Me.ChkCargo.Checked
            ObjVentaCargaContado.v_cargo = Me.rbtCargoSi.Checked

            ObjVentaCargaContado.v_idagencia_venta = 0 'dtoUSUARIOS.m_iIdAgencia
            ObjVentaCargaContado.v_idciudad_venta = 0 'dtoUSUARIOS.m_idciudad

            If CboProducto.SelectedValue = 6 Then 'PARAMETROS CARGA ACOMPAÑADA
                'ObjVentaCargaContado.v_nroboleto = Me.TxtBoleto.Text
                ObjVentaCargaContado.v_nroboleto = IIf(Me.TxtBoleto.Text.Trim = "-", "", Me.TxtBoleto.Text.Trim)
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
            If (ChkArticulos.Checked = False) And ChkM3.Checked = False Then   'Or ChkArticulos.Enabled = False
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
            End If

            '******************************GRID M3*********************************
            If ChkM3.Checked = True Then
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
                ObjVentaCargaContado.v_FACTOR = dFactor
                '**************

                'MOD***
                tarifa_Peso = Format(Val(GrdDetalleVenta(6, 0).Value), "##,###,###.00")
                tarifa_Sobre = Format(Val(TxtMontoBase.Text), "##,###,###.00")
                '******
            Else
                ObjVentaCargaContado.v_METROCUBICO = 0
                ObjVentaCargaContado.v_ALTURA = 0
                ObjVentaCargaContado.v_ANCHO = 0
                ObjVentaCargaContado.v_LARGO = 0
                ObjVentaCargaContado.v_PESO_KG = 0
                ObjVentaCargaContado.v_FACTOR = 0
            End If

            If ChkSobres.Checked = True Then
                ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = Val(txtCantidadSobres.Text)
            End If

            ObjVentaCargaContado.v_PRECIO_X_PESO = tarifa_Peso
            ObjVentaCargaContado.v_PRECIO_X_VOLUMEN = tarifa_Volumen
            ObjVentaCargaContado.v_PRECIO_X_SOBRE = tarifa_Sobre


            ObjVentaCargaContado.v_MONTO_SUB_TOTAL = TxtSubTotal.Text
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
            End If

            'CboTipoEntrega
            ObjIMPRESIONFACT_BOL.fnClear()

            '**MOD***********************************
            If ChkArticulos.Checked = False And ChkArticulos.Enabled = False And ChkM3.Checked = False Then '--BULTOS
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = Val(GrdDetalleVenta("Sub Neto", 0).Value)
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = Val(GrdDetalleVenta("Sub Neto", 1).Value)
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(GrdDetalleVenta("Sub Neto", 2).Value)
            ElseIf ChkArticulos.Checked = True Then
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = "0.00" '---ARTICULOS
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = "0.00"
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = "0.00"
            End If

            If ChkM3.Checked = True Then
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

            ObjIMPRESIONFACT_BOL.xOrigen = ObjVentaCargaContado.v_UNIDAD_ORIGEN
            ObjIMPRESIONFACT_BOL.xDestino = TxtCiudadDestino.Text
            ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL = Me.txtNroNroGuia.Text '& "-" & Me.LblNroBoletaFact.Text
            ObjIMPRESIONFACT_BOL.xRazonSocial = Me.TxtNomCliente.Text.Trim
            'ObjIMPRESIONFACT_BOL.xDireccionRemitente = Me.TxtDirecCliente.Text
            ObjIMPRESIONFACT_BOL.xRuc = TxtNroDocCliente.Text
            'ObjIMPRESIONFACT_BOL.xConsignado = Me.TxtNombConsignado.Text
            ObjIMPRESIONFACT_BOL.xConsignado = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO ' 'Me.TxtNombConsignado.Text 'Agregado NConsignado
            'ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.TxtDirecConsignado.Text'verificar
            ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.CboDireccion2.Text
            ObjIMPRESIONFACT_BOL.xfecha_factura = Me.txtFechaGuia.Text
            ObjIMPRESIONFACT_BOL.xTotalPeso = ObjVentaCargaContado.v_TOTAL_PESO
            ObjIMPRESIONFACT_BOL.xTotalVolumen = ObjVentaCargaContado.v_TOTAL_VOLUMEN
            ObjIMPRESIONFACT_BOL.xTotalSobres = 0
            ObjIMPRESIONFACT_BOL.xFormaPago = CboTipo.Text
            ObjIMPRESIONFACT_BOL.xNroRef = Me.txtNroNroGuia.Text '& "-" & Me.LblNroBoletaFact.Text
            ObjIMPRESIONFACT_BOL.xMemo = Me.txtDescDescto.Text
            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total = Me.TxtSubTotal.Text
            ObjIMPRESIONFACT_BOL.xMonto_Impuesto = TxtImpuesto.Text
            ObjIMPRESIONFACT_BOL.xTotal_Costo = ObjVentaCargaContado.v_TOTAL_COSTO
            ObjIMPRESIONFACT_BOL.xDescuento = IIf(TxtDescuento.Text <> "", TxtDescuento.Text, "")
            ObjIMPRESIONFACT_BOL.xAgenciaDestino = IIf(CboAgenciaDest.Text <> "", CboAgenciaDest.Text, "")
            ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = CboTipoEntrega.Text


            If fnDigito_Chequeo(txtNroNroGuia.Text) = True Then
                txtNroNroGuia.Text = RellenoRight(NroDigitos_Guias, txtNroNroGuia.Text.Trim)
                ObjVentaCargaContado.v_SERIE_FACTURA = "000"
                ObjVentaCargaContado.v_NRO_FACTURA = txtNroNroGuia.Text
                '***************************************************************************************************************************
                Try
                    v_Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
                    v_destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
                Catch ex As Exception
                    MsgBox("Verifique sus datos de IATA ewn la GUIA", MsgBoxStyle.Information, "Seguridad Sistema")
                End Try

                v_iDestino = "       "
                v_iCredito = "       "
                v_iDomicilio = "      "
                v_iAgencia = "      "

                If CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
                    p_domicilio = ""
                    p_agencia = "X"
                Else
                    p_domicilio = "X"
                    p_agencia = ""
                End If

                p_contado = ""
                p_destino = "X"
                p_credito = ""

                ObjRptGuiaEnvio.p_NroGUIA = txtNroNroGuia.Text
                ObjRptGuiaEnvio.p_tipo_entrega = v_iDomicilio & v_iAgencia
                ObjRptGuiaEnvio.p_ruc = TxtNroDocCliente.Text & "-" & ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL

                ObjRptGuiaEnvio.p_contacto = "FACTURAR A: " & IIf(CboContacto.Text <> "", CboContacto.Text, "") 'gnr
                ObjRptGuiaEnvio.p_codigo_iata_ori = v_Origen
                ObjRptGuiaEnvio.p_codigo_iata_desti = v_destino
                ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI = Me.TxtTelfCliente.Text
                'ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI = Me.TxtTelfConsignado.Text
                ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI = ObjVentaCargaContado.TelfConsignado 'GrdNConsignado("Telefono", 0).Value 'Me.TxtTelfConsignado.Text Comentado x NConsignado
                ObjRptGuiaEnvio.P_REMITENTE = Me.TxtNomCliente.Text
                ObjRptGuiaEnvio.P_DIRECCION_REMI = IIf(Me.CboDireccion.Text <> "", CboDireccion.Text, "") 'gnr
                ObjRptGuiaEnvio.P_DIRECCION_DESTI = IIf(Me.CboDireccion2.Text <> "", CboDireccion2.Text, "") 'gnr
                'ObjRptGuiaEnvio.P_NOMBRES_DESTI = Me.TxtNombConsignado.Text
                ObjRptGuiaEnvio.P_NOMBRES_DESTI = GrdNConsignado("Nombres", 0).Value 'Me.TxtNombConsignado.Text
                ObjRptGuiaEnvio.P_FECHA_GUIA = txtFechaGuia.Text
                'ObjRptGuiaEnvio.P_TOTAL_BULTOS = ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_CANTIDAD_X_ARTICULO + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN
                ObjRptGuiaEnvio.P_TOTAL_BULTOS = ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_MONTO_PENALIDAD + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN
                ObjRptGuiaEnvio.P_TOTAL_VOLUMEN = ObjVentaCargaContado.v_TOTAL_VOLUMEN
                ObjRptGuiaEnvio.P_TOTAL_PESO = ObjVentaCargaContado.v_TOTAL_PESO + ObjVentaCargaContado.v_MONTO_RECARGO
                ObjRptGuiaEnvio.P_TOTAL_SOBRES = IIf(ObjVentaCargaContado.v_CANTIDAD_X_SOBRE.ToString() <> "", ObjVentaCargaContado.v_CANTIDAD_X_SOBRE.ToString(), " ")

                ObjCODIGOBARRA.Cantidad = ObjRptGuiaEnvio.P_TOTAL_BULTOS
                ObjCODIGOBARRA.NroDOC = Mid(ObjRptGuiaEnvio.p_NroGUIA, 7, Len(ObjRptGuiaEnvio.p_NroGUIA))
                ObjCODIGOBARRA.clinte = ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL
                ObjCODIGOBARRA.Origen = v_Origen
                ObjCODIGOBARRA.Destino = v_destino & IIf(es_carga_asegurada = True, v_ca, "")
                ObjCODIGOBARRA.AGEDOM = "PCE"  'Mid(cmbTipo_Entrega.Text, 1, 3)
                ObjRptGuiaEnvio.P_PROVINCIA = TxtCiudadDestino.Text
                '**********************************************************************************************************************************************
            End If


            asignar_documentos_clientes()

            If ObjVentaCargaContado.ActualizarPCEContado() = True Then
                TipoComprobante = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = CboTipoEntrega.Text
                ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString

                '-----------------------------------------------------------------
                'INSERCION VOLUMETRICO
                '-----------------------------------------------------------------
                Try
                    If ChkM3.Checked = True Then
                        Dim obj As New dtoVentaCargaContado
                        Dim ii As Integer = 0
                        objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                        objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
                        objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                        objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                        objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

                        For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                            If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" And IsNumeric(GrdDetalleVenta.Rows(ii).Cells("Tipo").Value) Then
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
                                             dFactor,
                                             GrdDetalleVenta.Rows(ii).Cells("Costo").Value)
                                End If
                            End If
                        Next
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                '-----------------------------------------------------------------
                'INSERCION DE ARTICULOS
                '-----------------------------------------------------------------
                Try
                    If ChkArticulos.Checked = True Then
                        Dim ii As Integer = 0                                                
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
                                    objGuia_Envio_Articulo.iCONTROL = IIf(GrdDetalleVenta.Rows(ii).Cells("idGuiaArticulo").Value.ToString = "", 1, 2) 'CambioR 10112011
                                    objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = IIf(GrdDetalleVenta.Rows(ii).Cells("idGuiaArticulo").Value.ToString = "", 0, GrdDetalleVenta.Rows(ii).Cells("idGuiaArticulo").Value.ToString) 'cambioR 10112011
                                    objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(5).Value.ToString)
                                    objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
                                    objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
                                    objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells(1).Value.ToString)
                                    objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
                                End If
                            End If
                        Next
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



                '-----------------------------------------------------------------
                'INSERCION DE DOCUMENTOS DEL CLIENTE' agregar
                '-----------------------------------------------------------------   
                flat = True
                Dim i As Integer = 0
                Dim serie_NroDoc() As String
                Dim iContador As Integer = 0
                objGuiaEnvio.iIDGUIAS_ENVIO = ObjVentaCargaContado.v_IDFACTURA
                objGuiaEnvio.V_IDTIPO_COMPROBANTE = 85
                For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 1
                    Try
                        If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("cargo")) = False Then
                            If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("cargo").Value) Then
                                serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("cargo").Value.ToString, "-")
                                If serie_NroDoc.Length > 1 Then
                                    objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                    objGuiaEnvio.iNro_Docu = serie_NroDoc(1)

                                    If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                        If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                            objGuiaEnvio.iControl_Documentos = iContador
                                            If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL_I() = True Then
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
                        If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("seguro")) = False Then
                            'If GrdDocumentosCliente.Rows(i).Cells(3).Value.ToString <> "" Then
                            If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("seguro").Value) Then
                                serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("seguro").Value.ToString, "-")
                                If serie_NroDoc.Length > 1 Then
                                    objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                    objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                    If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                        If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                            If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL_I() = True Then
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
                '****************************************************************************************************   
                flat = True
            End If
        Catch ex As Exception
            flat = False
            Throw New Exception(ex.Message)
        End Try
        Return flat
    End Function

    '**INSERTAR CREDITO 
    Public Function FnGrabarCredito() As Boolean
        Dim flat As Boolean = False
        Try
            'If fnDigito_Chequeo(Me.txtNroNroGuia.Text.ToString) = False Then
            '    MessageBox.Show("Ingrese un Nº de Guía Correcto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    txtNroNroGuia.Focus()
            '    txtNroNroGuia.SelectAll()
            '    Return False
            'End If

            strNroGuias_Remision = ""
            v_Origen = objGuiaEnvio.fnIATA(objGuiaEnvio.iIDUNIDAD_AGENCIA)
            v_destino = objGuiaEnvio.fnIATA(objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO)

            Dim flagGuia As Boolean = False
            'If Int(CORRELATIVO) = Int(txtNroNroGuia.Text) Then
            flagGuia = True
            'End If
            ObjRptGuiaEnvio.P_PROVINCIA = TxtCiudadDestino.Text
            ObjRptGuiaEnvio.P_CARGO = IIf(objGuiaEnvio.iIDTipoFacturacion = 3, "X", " ")

            If Grabar_GuiaEnvio() = True Then
                'hlamas 11-03-2019
                'If flagGuia = True Then
                '    ObjVentaCargaContado.fnIncrementarNroDoc(3)
                'End If

                'If MessageBox.Show("¿Desea Imprimir la Guía?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                '    v_iDestino = "       "
                '    v_iCredito = "       "
                '    v_iDomicilio = "      "
                '    v_iAgencia = "      "

                '    If objGuiaEnvio.iIDTIPO_ENTREGA_CARGA = 1 Then
                '        p_domicilio = ""
                '        p_agencia = "X"
                '    Else
                '        p_domicilio = "X"
                '        p_agencia = ""
                '    End If
                '    ObjRptGuiaEnvio.p_forma_pago = v_iDestino & v_iCredito

                '    If objGuiaEnvio.iIDFORMA_PAGO = 1 Then
                '        p_contado = "X"
                '        p_destino = ""
                '        p_credito = ""
                '    ElseIf objGuiaEnvio.iIDFORMA_PAGO = 2 Then
                '        p_contado = ""
                '        p_destino = ""
                '        p_credito = "X"
                '    Else
                '        p_contado = ""
                '        p_destino = "X"
                '        p_credito = ""
                '    End If

                '    ObjRptGuiaEnvio.p_NroGUIA = txtNroNroGuia.Text
                '    ObjRptGuiaEnvio.p_tipo_entrega = v_iDomicilio & v_iAgencia
                '    ObjRptGuiaEnvio.p_ruc = Me.TxtNroDocCliente.Text & "-" & Me.TxtNomCliente.Text
                '    ' ObjRptGuiaEnvio.p_tipo_entrega = ObjRptGuiaEnvio.p_tipo_entrega
                '    'ObjRptGuiaEnvio.p_forma_pago = ObjRptGuiaEnvio.p_forma_pago
                '    ObjRptGuiaEnvio.p_contacto = IIf(CboContacto.SelectedIndex = 0, "", CboContacto.Text)
                '    ObjRptGuiaEnvio.p_codigo_iata_ori = v_Origen
                '    ObjRptGuiaEnvio.p_codigo_iata_desti = v_destino
                '    ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI = Me.TxtTelfCliente.Text
                '    ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI = sTelefonoConsignado 'GrdNConsignado("Telefono", 0).Value 'Me.TxtTelfConsignado.Text
                '    ObjRptGuiaEnvio.P_REMITENTE = IIf(CboRemitente.SelectedIndex = 0, "", CboRemitente.Text) ' Me.txtCliente_Remitente.Text 
                '    ObjRptGuiaEnvio.P_DIRECCION_REMI = IIf(CboDireccion.SelectedIndex = 0, "", CboDireccion.Text) 'Me.txtDireccionRemitente.Text
                '    ObjRptGuiaEnvio.P_DIRECCION_DESTI = IIf(CboDireccion2.SelectedIndex = 0, "", CboDireccion2.Text) 'Me.txtDireccionDestinatario.Text
                '    ObjRptGuiaEnvio.P_NOMBRES_DESTI = sNombresConsignado 'GrdNConsignado("Nombres", 0).Value 'Me.TxtNombConsignado.Text
                '    ObjRptGuiaEnvio.P_FECHA_GUIA = Me.txtFechaGuia.Text
                '    ObjRptGuiaEnvio.P_TOTAL_BULTOS = objGuiaEnvio.iCANTIDAD + objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN + objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI
                '    ObjRptGuiaEnvio.P_TOTAL_VOLUMEN = objGuiaEnvio.dTOTAL_VOLUMEN.ToString

                '    ObjRptGuiaEnvio.P_TOTAL_PESO = objGuiaEnvio.dTOTAL_PESO.ToString


                '    ObjRptGuiaEnvio.P_TOTAL_SOBRES = IIf(objGuiaEnvio.iCANTIDAD_SOBRES.ToString <> "", objGuiaEnvio.iCANTIDAD_SOBRES.ToString, " ")


                '    ObjCODIGOBARRA.Cantidad = ObjRptGuiaEnvio.P_TOTAL_BULTOS
                '    ObjCODIGOBARRA.NroDOC = ObjRptGuiaEnvio.p_NroGUIA
                '    ObjCODIGOBARRA.clinte = TxtNomCliente.Text
                '    ObjCODIGOBARRA.Origen = v_Origen
                '    ObjCODIGOBARRA.Destino = v_destino
                '    ObjCODIGOBARRA.AGEDOM = Mid(CboTipoEntrega.Text, 1, 3)

                '    fnInprecion_Guia_Envio()
                'End If

                ObjCODIGOBARRA.Cantidad = objGuiaEnvio.iCANTIDAD + objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN + objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + objGuiaEnvio.iCANTIDAD_SOBRES
                ObjCODIGOBARRA.NroDOC = txtNroNroGuia.Text
                ObjCODIGOBARRA.clinte = TxtNomCliente.Text
                ObjCODIGOBARRA.Origen = v_Origen
                ObjCODIGOBARRA.Destino = v_destino
                ObjCODIGOBARRA.AGEDOM = Mid(CboTipoEntrega.Text, 1, 3)

                'If MsgBox("Esta Seguro de Imprimir Etiquetas...", MsgBoxStyle.YesNoCancel, "Seguridad") = MsgBoxResult.Yes Then
                '    If xIMPRESORA = 1 Then
                '        fnImprimirEtiquetasGUIA()
                '    Else
                '        If xIMPRESORA = 2 Then
                '            fnImprimirEtiquetasGUIA_II()
                '        Else
                '            fnImprimirEtiquetasGUIA_III()
                '        End If
                '    End If
                'End If
                Me.FNNUEVO()
                flat = True
            End If
        Catch ex As Exception
            flat = False
            Throw New Exception(ex.Message)
        End Try
        Return flat
    End Function

    Dim iTOTAL_BULTOS As String = ""
    Dim iTOTAL_VOLUMEN As String = ""
    Dim iTOTAL_PESO As String = ""
    Dim sNombresConsignado As String = ""
    Dim sTelefonoConsignado As String = ""
    Private Function Grabar_GuiaEnvio() As Boolean
        Dim flat As Boolean = True
        Dim lb_valida As Boolean
        Try
            'PARAMETRO IDGUIA ENVIO
            Dim iIDGUIAS_ENVIO As Integer = 0
            Dim sFECHA_GUIA As String = txtFechaGuia.Text '---------------------------------> PARAMETRO FECHA GUIA            
            Dim sNRO_GUIA As String = RellenoRight(NroDigitos_Guias, txtNroNroGuia.Text.Trim) '--> PARAMETRO NRO GUIA             
            '=================================CLIENTE=======================================================                                           
            If (TipoComprobante = 1 Or CboProducto.SelectedValue = 7) Then
                sNombresCli = ""
            ElseIf ChkCliente1.Checked And TipoComprobante = 1 Then
                NombresCont = ""
            ElseIf ChkCliente2.Checked And TipoComprobante = 1 Then
                sNombresConsig = ""
            End If

            '---------DATOS DEL CLIENTE------
            Dim iClienteModificado As Integer = IIf(bClienteModificado, 1, 0)
            Dim iIDPERSONA As Integer = IIf(bClienteNuevo, 0, iID_Persona) '---------------------->  PARAMETRO IDPERSONA    
            Dim sNombresCliente As String = IIf(TxtNomCliente.Text <> "", TxtNomCliente.Text, "@") ' PARAMETRO NOMBRES O RAZON SOCIAL
            Dim sNumeroDocumentoCliente As String = IIf(TxtNroDocCliente.Text <> "", TxtNroDocCliente.Text, "@")
            Dim iID_TipoDocumentoCliente As Integer = iID_TipoDocCli '--->agre
            Dim sNombreCliente As String = sNombresCli
            Dim sApellidoPaternoCliente As String = sApCli
            Dim sApellidoMaternoCliente As String = sAmCli
            Dim TelefonoCliente As String = IIf(sTelfCliente.Length > 0, sTelfCliente, "@")

            '--DIRECCION ESTRUCTURADO DEL CLIENTE          
            Dim iDireccionCliente_Mod As Integer = IIf(bDireccionModificada, 1, 0)
            'PARAMETRO IDDIRECCION_ORIGEN******
            If CboDireccion.SelectedValue = 0 Then
                IdDireccionOrigen = -1
            Else
                IdDireccionOrigen = CboDireccion.SelectedValue
            End If
            Dim IDDIREECION_ORIGEN As Integer = IdDireccionOrigen
            'PARAMETRO NOMBRE DE LA DIRECCION**
            Dim NombreDireccion_Origen As String = IIf(IdDireccionOrigen = -1, "@", CboDireccion.Text)
            'ObjVentaCargaContado.id_DepartamentoCli = iDepartamentoCli
            'ObjVentaCargaContado.id_ProvinciaCli = iProvinciaCli
            'ObjVentaCargaContado.id_DistritoCli = iDistritoCli
            'ObjVentaCargaContado.id_viaCli = IDviaCli
            'ObjVentaCargaContado.viaCli = ViaCli
            'ObjVentaCargaContado.NumeroCli = NroCli
            'ObjVentaCargaContado.manzanaCli = ManzanaCli
            'ObjVentaCargaContado.loteCli = loteCli
            'ObjVentaCargaContado.id_nivelCli = id_NivelCli
            'ObjVentaCargaContado.nivelCli = NivelCli
            'ObjVentaCargaContado.id_zonaCli = id_ZonaCli
            'ObjVentaCargaContado.zonaCli = ZonaCli
            'ObjVentaCargaContado.id_clasificacionCli = id_ClasificacionCli
            'ObjVentaCargaContado.clasificacionCli = ClasificacionCli          


            '=============================DATOS REMITENTE=====================================
            If CboRemitente.SelectedIndex = 0 Then
                idRemitente = -1
            End If
            If idcontacto = 0 AndAlso Me.ChkCliente.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNumDocRemitente.Text)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    Me.TxtNumDocRemitente.Tag = 0
                    idRemitente = 0
                Else
                    Me.TxtNumDocRemitente.Tag = dt.Rows(0).Item(0)
                    idRemitente = dt.Rows(0).Item(0)
                    bRemitenteModificado = False
                End If
            End If

            'PARAMETRO ID_NOMBRE_REMITENTE**
            Dim iRemitenteModificado As Integer = IIf(bRemitenteModificado, 1, 0)
            Dim iIDRemitente As Integer = idRemitente
            Dim sNombresRemitente As String = IIf(idRemitente = -1, "@", CboRemitente.Text)
            Dim sNumeroDocumentoRemitente As String = IIf(sNroDocRemitente.Trim = "", "@", sNroDocRemitente.Trim)
            Dim iID_TipoDocumentoRemitente As Integer = iID_TipoDocRemitente
            Dim sNombRemitente As String = IIf(iID_TipoDocRemitente = 1, "", sNombreRemitente)
            Dim sApellidoPaternoRemitente As String = sApRemitente
            Dim sApellidoMaternoRemitente As String = sAmRemitente

            '=============================DATOS CONTACTO======================================                           
            'PARAMETRO ID_NOMBRE_CONTACTO**          
            If CboContacto.SelectedIndex = 0 Then
                idcontacto = -1
            End If

            If idcontacto = 0 AndAlso Me.ChkCliente1.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNroDocContacto.Text)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    Me.TxtNroDocContacto.Tag = 0
                    idcontacto = 0
                Else
                    Me.TxtNroDocContacto.Tag = dt.Rows(0).Item(0)
                    idcontacto = dt.Rows(0).Item(0)
                    bContactoModificado = False
                End If
            End If

            Dim iContactoModificado As Integer = IIf(bContactoModificado, 1, 0)
            Dim iIDcontacto As Integer = idcontacto
            Dim sNombresContacto As String = IIf(idcontacto = -1, "@", CboContacto.Text) '            
            Dim sNumeroDocumentoContacto As String = IIf(Trim(TxtNroDocContacto.Text) <> "", TxtNroDocContacto.Text, "@")
            Dim iIDTipoDocumentoContacto As Integer = iID_TipoDocCont
            Dim sNombreContacto As String = IIf(iID_TipoDocCont = 1, "", NombresCont)
            Dim sApellidoPaternoContacto As String = apellPatCont
            Dim sApellidoMaternoContacto As String = apellMatCont

            '======================================CONSIGNADO=================================   
            '***Comentado x NConsignado****
            'If iIDConsignado = 0 AndAlso Me.ChkCliente2.Checked Then
            '    Dim objContacto As New dtoVentaCargaContado
            '    Dim dt As DataTable = objContacto.BuscarContacto(TxtNroDocConsignado.Text)
            '    Dim resp As Integer = dt.Rows.Count
            '    If resp = 0 Then
            '        iIDConsignado = 0
            '    Else
            '        iIDConsignado = dt.Rows(0).Item(0)
            '        bConsignadoModificado = False
            '    End If
            'End If

            '===Agregado x NConsignado==============================
            If iIDConsignado = 0 AndAlso Me.ChkCliente2.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(GrdNConsignado("Nº Documento", 0).Value)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    GrdNConsignado("IDConsignado", 0).Value = 0
                Else
                    GrdNConsignado("IDConsignado", 0).Value = dt.Rows(0).Item(0)
                    GrdNConsignado("Modificado", 0).Value = "0"
                End If
            End If

            '========================================================
            '***Comentado x NConsignado**
            'Dim iConsignadoModificado As Integer = IIf(bConsignadoModificado, 1, 0)
            'Dim iID_Consignado As Integer = IIf(IsNothing(iIDConsignado), 0, iIDConsignado)
            'Dim sNombresConsignado As String = "" ' IIf(Me.TxtNombConsignado.Text.Trim <> "", Me.TxtNombConsignado.Text.Trim, "@")axl
            'Dim sNumeroDocumentoConsignado As String = "" ' IIf(Trim(TxtNroDocConsignado.Text) <> "", TxtNroDocConsignado.Text, "@")axl
            'Dim iIDTipoDocumentoConsignado As Integer = iID_TipoDocConsig
            'Dim sNombreConsignado As String = sNombresConsig
            'Dim sApellidoPaternoConsignado As String = sapellPatConsig
            'Dim sApellidoMaternoConsignado As String = sapellMatConsig
            'Dim sTelefonoConsignado As String = IIf(sTelefonoConsig.Length > 0, sTelefonoConsig, "@")
            'rose

            '===Agregado x NConsignado==============================
            Dim iConsignadoModificado As String = ""
            Dim iID_Consignado As String = ""
            sNombresConsignado = ""
            Dim sNumeroDocumentoConsignado As String = ""
            Dim iIDTipoDocumentoConsignado As String = ""
            Dim sNombreConsignado As String = ""
            Dim sApellidoPaternoConsignado As String = ""
            Dim sApellidoMaternoConsignado As String = ""
            sTelefonoConsignado = ""

            For i As Integer = 0 To GrdNConsignado.Rows.Count() - 1
                iID_Consignado &= GrdNConsignado("IDConsignado", i).Value & ";"
                sNombresConsignado &= GrdNConsignado("Nombres", i).Value & ";"
                sNombreConsignado &= GrdNConsignado("nombre", i).Value & ";"
                sApellidoPaternoConsignado &= GrdNConsignado("apepat", i).Value & ";"
                sApellidoMaternoConsignado &= GrdNConsignado("apemat", i).Value & ";"
                sNumeroDocumentoConsignado &= GrdNConsignado("Nº Documento", i).Value & ";"
                iIDTipoDocumentoConsignado &= GrdNConsignado("tipo", i).Value & ";"
                sTelefonoConsignado &= GrdNConsignado("Telefono", i).Value & ";"
                iConsignadoModificado &= GrdNConsignado("Modificado", i).Value & ";"
            Next
            '========================================================

            '*****DIRECCION ESTRUCTURADA CONSIGNADO*****
            'PARAMETRO ID_DIRECCION_DESTINO**
            If CboDireccion2.SelectedIndex = 0 Then
                idDireConsignado = -1
            End If
            ObjVentaCargaContado.v_IDDIREECION_DESTINO = idDireConsignado
            Dim iDirecConsignado_mod As Integer = IIf(bDirecConsigMod, 1, 0)
            ObjVentaCargaContado.v_DIRECCION_DESTINATARIO = IIf(idDireConsignado = -1, "@", CboDireccion2.Text)

            '----------------------------------------------------------------------            
            Dim iIDTIPO_ENTREGA As Integer = CboTipoEntrega.SelectedValue 'PARAMETRO TIPO ENTREGA CARGA (Agencia,Domicilio)            
            Dim iIDFORMA_PAGO As Integer = 2 'PARAMETRO FORMA PAGO 'Int(objGuiaEnvio.coll_Lista_Forma_Pagos.Item(Me.cmbFormaCredito.SelectedIndex.ToString()))            
            Dim iAGENCIA_ORIGEN As Integer = CboCiudad_Origen.SelectedValue 'objGuiaEnvio.iIDUNIDAD_AGENCIA 'PARAMETRO IDUNIDAD AGENCIA_ORIGEN  'agregar 'Int(coll_iOrigen.Item(iWinDestino.IndexOf(txtiWinOrigen.Text) + 1))
            Dim iIDCIUDAD_TRANSITO As Integer = objGuiaEnvio.iIDUNIDAD_AGENCIA 'PARAMETRO IDCIUDAD TRANSITO
            Dim iAGENCIA_DESTINO As Integer = idUnidadAgencias 'PARAMETRO IDAGENCIA DESTINO  'agregar'Int(coll_iDestino.Item(iWinDestino.IndexOf(txtiWinDestino.Text) + 1))
            Dim iIDAGENCIAS As Integer = CboAgencia_Origen.SelectedValue 'dtoUSUARIOS.m_iIdAgencia 'PARAMETRO IDAGENCIAS'Agregar codigo           
            Dim sIDDIRECCION_REMITENTE As String = IdDireccionOrigen 'PARAMETRO IDDIRECCION REMITENTE

            'PARAMETRO IDTELEFONO REMITENTE
            'OBSERVACION
            'If iWinTelefono_Remitente.Count > 0 Then
            '    indexof = iWinTelefono_Remitente.IndexOf(txtTelefonoRemitente.Text)
            '    objGuiaEnvio.iIDTEFONO_REMITENTE = -1
            '    If indexof >= 0 Then
            '        objGuiaEnvio.iIDTEFONO_REMITENTE = Int(objGuiaEnvio.coll_Telefono_Remitente.Item(indexof.ToString))
            '    End If
            'End If
            Dim sIDCONTACTO_REMITENTE As String = idcontacto 'CboContacto.SelectedValue 'PARAMETRO IDCONTACTOREMITENTE
            Dim sIDTELEFONO_REMITENTE As String = 0 'PARAMETRO IDTELEFONO REMITENTE
            Dim sIDCONTACTO_DESTINATARIO As String = IIf(IsNothing(iIDConsignado), 0, iIDConsignado) 'CODIGO NOMBRE CONSIGNADO 'Int(objGuiaEnvio.coll_Nombres_Destinatario.Item(indexof.ToString))
            Dim sIDDIRECCION_DESTINATARIO As String = idDireConsignado  'CODIGO DIRECCION CONSIGNADO'Int(objGuiaEnvio.coll_Direccion_Destinatario.Item(indexof.ToString))

            'PARAMETRO IDTELEFONO CONSIGNADO
            'OBSERVACION
            'If iWinTelefono_Destinatario.Count > 0 Then
            '    indexof = iWinTelefono_Destinatario.IndexOf(txtTelefonoDestinatario.Text)
            '    objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1
            '    If indexof >= 0 Then
            '        objGuiaEnvio.iIDTEFONO_CONSIGNADO = Int(objGuiaEnvio.coll_Telefono_Destinatario.Item(indexof.ToString))
            '    End If
            'End If
            Dim sIDTELEFONO_CONSIGNADO As String = 0 'PARAMETRO IDTELEFONO CONSIGNADO

            Dim iCANTIDAD As Integer = 0  'Unidades Peso
            Dim iCANTIDAD_X_UNIDAD_VOLUMEN As Integer = 0 'Unidades Volumen
            Dim iCANTIDAD_X_UNIDAD_ARTI As Integer = 0 'Unidades Articulos
            Dim dTOTAL_VOLUMEN As Double = 0
            Dim dTOTAL_PESO As Double = 0
            Dim iCANTIDAD_SOBRES As Integer
            Dim dMONTO_BASE As Double
            Dim dPrecio_x_Volumen As Double
            Dim dPrecio_x_Peso As Double
            Dim dPrecioSobre As Double

            Dim totalCosto As Double = 0
            Dim valor1 As Double = 0
            Dim valor2 As Double = 0

            'Camp1 = "Tipo" : camp2 = "Bulto" : camp3 = "Altura"
            'camp4 = "Ancho" : camp5 = "Largo" : camp6 = "Peso Kg"
            'camp7 = "Costo" : camp8 = "Sub Neto"

            If TipoGrid_ = FormatoGrid.BULTO Then
                'PESO                
                iCANTIDAD = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Bulto", 0).Value.ToString)), "##,###,####.00")
                dTOTAL_PESO = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Peso/Volumen", 0).Value.ToString)), "##,###,####.00")
                dPrecio_x_Peso = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 0).Value.ToString)), "##,###,####.00") ' Costo x Peso                 

                'VOLUMEN                
                iCANTIDAD_X_UNIDAD_VOLUMEN = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Bulto", 1).Value.ToString)), "##,###,####.00")
                dTOTAL_VOLUMEN = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Peso/Volumen", 1).Value.ToString)), "##,###,####.00")
                dPrecio_x_Volumen = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 1).Value.ToString)), "##,###,####.00") ' Costo x volumen 

                'SOBRE
                iCANTIDAD_SOBRES = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Bulto", 2).Value.ToString)), "##,###,####.00")
                dPrecioSobre = tarifa_Sobre

                dMONTO_BASE = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 3).Value.ToString)), "##,###,####.00") ' Base
            End If


            'PARAMETRO MONTO BASE            


            Dim iMetroCubico As Integer = 0
            If ChkM3.Checked Then
                iMetroCubico = 1
                valor2 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Bulto", 1).Value.ToString)), "##,###,###.00")
                iCANTIDAD_X_UNIDAD_VOLUMEN = valor2 'PARAMETRO iCANTIDAD_X_UNIDAD_VOLUMEN
                valor1 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 1).Value.ToString)), "##,###,###.00")
                valor2 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Peso Kg", 1).Value.ToString)), "##,###,###.00")
                dTOTAL_VOLUMEN = valor2 'PARAMETRO DTOTAL_VOLUMEN
                ' totalCosto = totalCosto + valor1 * valor2 + Monto_Base
            End If


            If ChkArticulos.Checked Then
                Dim Total As Double = 0
                Dim ii1 As Integer = 0
                For ii1 = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                    Total = Total + Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii1).Cells("Cantidad").Value.ToString)
                    'PARAMETRO iCANTIDAD_X_UNIDAD_ARTI                    
                    iCANTIDAD_X_UNIDAD_ARTI = iCANTIDAD_X_UNIDAD_ARTI + Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii1).Cells("Cantidad").Value.ToString) 'CambioR 09112011
                Next
            End If


            'PARAMETRO dPRECIO_X_UNIDAD
            Dim dPRECIO_X_UNIDAD As Double = tarifa_Articulo 'kgr
            'PARAMETRO dIMPUESTO
            Dim dIMPUESTO As Double = IGV
            'PARAMETRO dMONTO_IMPUESTO
            Dim dMONTO_IMPUESTO As Double = Me.TxtImpuesto.Text
            'PARAMETRO dTOTAL_COSTO
            Dim dTOTAL_COSTO As Double = Me.TxtTotal.Text

            'PARAMETRO iIDROL_USUARIO
            Dim iIDROL_USUARIO As Integer = dtoUSUARIOS.IdRol
            'PARAMETRO sIP
            Dim sIP As String = dtoUSUARIOS.IP
            'PARAMETRO iIDESTADO_REGISTRO
            Dim iIDESTADO_REGISTRO As Integer = 18

            'PARAMETRO iNOMBRES_REMITENTE
            Dim sNOMBRES_REMITENTE As String = ""
            If Me.CboRemitente.Text <> "" And Me.CboRemitente.Text.Length > 3 Then
                sNOMBRES_REMITENTE = Me.CboRemitente.Text
            Else
                sNOMBRES_REMITENTE = "NULL"
            End If

            'PARAMETRO iDNI_REMITENTE
            Dim sDNI_REMITENTE As String = ""
            If TxtNroDocContacto.Text <> "" And TxtNroDocContacto.Text.Length > 5 Then
                sDNI_REMITENTE = Me.TxtNroDocContacto.Text
            Else
                sDNI_REMITENTE = "@"
            End If

            'PARAMETRO iDIRECCION_REMITENTE
            Dim sDIRECCION_REMITENTE As String = ""
            If CboDireccion.Text <> "" And CboDireccion.Text.Length > 5 Then
                sDIRECCION_REMITENTE = CboDireccion.Text
            End If

            'PARAMETRO iNOMBRES_DESTINATARIO... (CONSIGNADO)
            Dim sNOMBRES_DESTINATARIO As String = ""
            'If TxtNombConsignado.Text <> "" And TxtNombConsignado.Text.Length > 5 Then
            '    sNOMBRES_DESTINATARIO = TxtNombConsignado.Text
            'End If axl

            'PARAMETRO sDNI_DESTINATARIO
            Dim sDNI_DESTINATARIO As String = ""
            'If TxtNroDocConsignado.Text <> "" Then '19/08/2008 -  And txtDNIDestinatario.Text.Length > 5 Then ---> No se sabe el nº dcto del consignado
            '    sDNI_DESTINATARIO = TxtNroDocConsignado.Text
            'End If axl

            'PARAMETRO iDIRECCION_DESTINATARIO
            Dim sDIRECCION_DESTINATARIO As String = ""
            If CboDireccion2.Text <> "" And CboDireccion2.Text.Length > 5 Then
                sDIRECCION_DESTINATARIO = CboDireccion2.Text
            End If
            'PARAMETRO iCARGO

            'hlamas 22-03-2016
            'Dim iCARGO As Integer = Int(ChkCargo.Checked)
            Dim iCARGO As Integer = Int(Me.rbtCargoSi.Checked)

            'PARAMETRO sTelefono_Remitente
            Dim sTelefono_Remitente As String = IIf(TxtTelfCliente.Text <> "", TxtTelfCliente.Text, "NULL")
            'PARAMETRO sTelefono_Destinatario
            Dim sTelefono_Destinatario As String = "" 'IIf(TxtTelfConsignado.Text <> "", TxtTelfConsignado.Text, "NULL") axl

            'PARAMETRO iID_REMITENTE
            Dim sID_REMITENTE As String = 0
            'PARAMETRO iREMITENTE 
            Dim sREMITENTE As String = CboRemitente.Text 'OBSERVACION
            'PARAMETRO iNRODOC_REM
            Dim sNRODOC_REM As String = TxtNumDocRemitente.Text
            'PARAMETRO iIDCENTRO_COSTO
            Dim iIDCENTRO_COSTO As Integer = CboSubCuenta.SelectedValue


            Dim iIDSINO_SOBRES As Integer
            If ChkSobres.Checked = True Then
                'PARAMETRO iCANTIDAD_SOBRES
                iCANTIDAD_SOBRES = Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                'PARAMETRO iIDSINO_SOBRES
                iIDSINO_SOBRES = 1
            End If

            'PARAMETRO iIDAGENCIAS_DESTINO
            Dim iIDAGENCIAS_DESTINO As Integer = CboAgenciaDest.SelectedValue

            objGuiaEnvio.iIDCONTACTO_PERSONA = 0
            objGuiaEnvio.iIDDIRECCION_CONSIGNADO = 0


            'OBSERVACION
            'If Me.dtGridViewArticulo.Visible = True Then
            '    objGuiaEnvio.dTOTAL_PESO = fn_peso_desde_articulos()
            'End If

            'If Me.dtGridViewArticulo.Visible = True Then
            '    objGuiaEnvio.dTOTAL_VOLUMEN = fn_Volumen_desde_articulos()
            'End If

            '----------------------------------------------------------------------------------------------------------------------            
            'objGuiaEnvio.dMONTO_BASE = Monto_Base '26/08/2008  Se toma el valor de los bultos                       
            iTOTAL_BULTOS = ""
            iTOTAL_VOLUMEN = ""
            iTOTAL_PESO = ""
            objGuiaEnvio.iCANTIDAD = iCANTIDAD
            objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN = iCANTIDAD_X_UNIDAD_VOLUMEN
            objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = iCANTIDAD_X_UNIDAD_ARTI
            objGuiaEnvio.iCANTIDAD_SOBRES = iCANTIDAD_SOBRES
            objGuiaEnvio.dTOTAL_VOLUMEN = dTOTAL_VOLUMEN
            objGuiaEnvio.dTOTAL_PESO = dTOTAL_PESO
            objGuiaEnvio.iIDTIPO_ENTREGA_CARGA = Me.CboTipoEntrega.SelectedValue
            objGuiaEnvio.iIDFORMA_PAGO = 1

            Dim sReferencia As String = TxtReferencia.Text.Trim
            Dim iDescuento As Double = IIf(TxtDescuento.Text.Trim <> "", TxtDescuento.Text, 0)
            Dim sAutoriza As String = IIf(TxtDescuento.Text.Trim <> "", txtDescDescto.Text, "")

            '---USUARIO REMOTO---                   
            Dim iIDUSUARIO_PERSONAL As Integer = CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin
            Dim iIDUsuarioRemoto As Integer = dtoUSUARIOS.IdLogin
            '--------------------
            Dim strFechaRecojo As String = ""
            If Me.dtpFechaRecojo.Visible Then
                strFechaRecojo = Me.dtpFechaRecojo.Value.ToShortDateString
            End If
            '=========================================================
            If objGuiaEnvio.GrabarGuiaCredito_I(0, sFECHA_GUIA, sNRO_GUIA, iIDTIPO_ENTREGA, iIDFORMA_PAGO, _
                                              iAGENCIA_ORIGEN, iIDCIUDAD_TRANSITO, iAGENCIA_DESTINO, iIDAGENCIAS, sIDCONTACTO_REMITENTE, _
                                              sIDDIRECCION_REMITENTE, sIDTELEFONO_REMITENTE, sIDCONTACTO_DESTINATARIO, sIDDIRECCION_DESTINATARIO, _
                                              sIDTELEFONO_CONSIGNADO, dMONTO_BASE, dTOTAL_PESO, iCANTIDAD, dTOTAL_VOLUMEN, iCANTIDAD_X_UNIDAD_VOLUMEN, _
                                              iCANTIDAD_X_UNIDAD_ARTI, dPRECIO_X_UNIDAD, dIMPUESTO, dMONTO_IMPUESTO, dTOTAL_COSTO, iIDUSUARIO_PERSONAL, _
                                              iIDROL_USUARIO, sIP, iIDESTADO_REGISTRO, sNOMBRES_REMITENTE, sDNI_REMITENTE, sDIRECCION_REMITENTE, _
                                              sNOMBRES_DESTINATARIO, sDNI_DESTINATARIO, sDIRECCION_DESTINATARIO, dPrecio_x_Volumen, dPrecio_x_Peso, dPrecioSobre, _
                                              iCARGO, sTelefono_Remitente, sTelefono_Destinatario, sID_REMITENTE, sREMITENTE, sNRODOC_REM, iIDCENTRO_COSTO, _
                                              iCANTIDAD_SOBRES, iIDSINO_SOBRES, iIDAGENCIAS_DESTINO, iClienteModificado, iIDPERSONA, sNombresCliente, _
                                              sNumeroDocumentoCliente, iID_TipoDocumentoCliente, sNombreCliente, sApellidoPaternoCliente, _
                                              sApellidoMaternoCliente, TelefonoCliente, iRemitenteModificado, iIDRemitente, sNombRemitente, _
                                              sNumeroDocumentoRemitente, iID_TipoDocumentoRemitente, sNombreRemitente, sApellidoPaternoRemitente, _
                                              sApellidoMaternoRemitente, iContactoModificado, iIDcontacto, sNombresContacto, sNumeroDocumentoContacto, _
                                              iIDTipoDocumentoContacto, sNombreContacto, sApellidoPaternoContacto, sApellidoMaternoContacto, _
                                             iConsignadoModificado, iID_Consignado, sNombresConsignado, sNumeroDocumentoConsignado, _
                                             iIDTipoDocumentoConsignado, sNombreConsignado, sApellidoPaternoConsignado, sApellidoMaternoConsignado, _
                                             sTelefonoConsignado, iDireccionCliente_Mod, iDepartamentoCli, iProvinciaCli, iDistritoCli,
                                             IDviaCli, ViaCli, NroCli, ManzanaCli, loteCli, id_NivelCli, NivelCli, id_ZonaCli, ZonaCli, _
                                             id_ClasificacionCli, ClasificacionCli, iDirecConsignado_mod, iDepartamentoConsig, iProvinciaConsig, _
                                             iDistritoConsig, IDviaConsig, ViaConsig, NroConsig, ManzanaConsig, loteConsig, id_NivelConsig, _
                                             NivelConsig, id_ZonaConsig, ZonaConsig, id_ClasificacionConsig, ClasificacionConsig, sEmail, sReferencia, iMetroCubico, iDescuento, sAutoriza, iIDUsuarioRemoto, CboTipoTarifa.SelectedValue _
                                             , , CboProducto.SelectedValue, txtdt.Text.Trim, CboSubCuentaOrigen.SelectedValue, strFechaRecojo) = True Then


                iTOTAL_BULTOS = objGuiaEnvio.iCANTIDAD + objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN + objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + objGuiaEnvio.iCANTIDAD_SOBRES
                iTOTAL_VOLUMEN = objGuiaEnvio.dTOTAL_VOLUMEN
                iTOTAL_PESO = objGuiaEnvio.dTOTAL_PESO

                '-----------------------------------------------------------------
                'INSERCION VOLUMETRICO
                '-----------------------------------------------------------------
                Try
                    If ChkM3.Checked = True Then
                        Dim obj As New dtoVentaCargaContado
                        Dim ii As Integer = 0
                        objGuia_Envio_Articulo.iIDGUIAS_ENVIO = objGuiaEnvio.iIDGUIAS_ENVIO
                        objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
                        objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                        objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin USUARIO REMOTO
                        objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

                        For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                            If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" And IsNumeric(GrdDetalleVenta.Rows(ii).Cells("Tipo").Value) Then
                                    obj.FNinsert_Volumetrico(
                                             ii,
                                             0,
                                             objGuiaEnvio.iIDGUIAS_ENVIO,
                                             GrdDetalleVenta.Rows(ii).Cells("Tipo").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Bulto").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Altura").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Ancho").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Largo").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Peso Kg").Value,
                                             dFactor,
                                             GrdDetalleVenta.Rows(ii).Cells("Costo").Value)
                                End If
                            End If
                        Next
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                '-----------------------------------------------------------------
                'INSERCION DE ARTICULOS
                '-----------------------------------------------------------------                
                objGuia_Envio_Articulo.iCONTROL = 1
                objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = 0
                objGuia_Envio_Articulo.iIDGUIAS_ENVIO = objGuiaEnvio.iIDGUIAS_ENVIO
                objGuia_Envio_Articulo.iIGV = IGV
                objGuia_Envio_Articulo.iDESCUENTO = 0
                objGuia_Envio_Articulo.iPENALIDAD = 0
                objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin USUARIO REMOTO
                objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol
                objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18

                If ChkArticulos.Checked = True Then
                    For ii As Integer = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                        If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                            If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells("IDARTICULO").Value.ToString)
                                objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells("Cantidad").Value.ToString)
                                If GrdDetalleVenta.Rows(ii).Cells("M3").Value.ToString = "" Then
                                    objGuia_Envio_Articulo.iMETRO_CUBICO = 0
                                Else
                                    objGuia_Envio_Articulo.iMETRO_CUBICO = CDbl(GrdDetalleVenta.Rows(ii).Cells("M3").Value.ToString)
                                End If
                                objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells("Peso").Value.ToString)
                                objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells("Precio").Value.ToString)
                                objGuia_Envio_Articulo.fnINSTUPD_GENVIO_ARTICULOS_RGT()
                            End If
                        End If
                    Next
                End If


                '---------------DETALLE DOCUMENTOS----------------------------------
                flat = True
                Dim i As Integer = 0
                Dim serie_NroDoc() As String
                objGuiaEnvio.iControl_Documentos = 1
                objGuiaEnvio.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'USUARIO REMOTO
                Dim iContador As Integer = 0
                'If objGuiaEnvio.iCONTROL = 1 Then
                For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 2
                    Try
                        If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Cargo")) = False Then
                            'If Trim(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value.ToString) <> "" Then
                            If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value) Then
                                serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value.ToString, "-")
                                If serie_NroDoc.Length > 1 Then
                                    objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                    objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                    strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
                                    If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                        If objGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS() = True Then
                                            iContador = iContador + 1
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
                            'If GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString <> "" Then
                            If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value) Then
                                serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString, "-")
                                If serie_NroDoc.Length > 1 Then
                                    objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                    objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                    strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
                                    If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                        If objGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS() = True Then
                                            iContador = iContador + 1
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Next
                'End If
            Else
                Me.Cursor = Cursors.Default
                'MessageBox.Show("La Guia no se Registró", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                flat = False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
            flat = False
        End Try
        Return flat
    End Function

    'ACTUALIZAR CREDITO
    Public Function FnActualizarCredito() As Boolean

        strNroGuias_Remision = ""
        v_Origen = objGuiaEnvio.fnIATA(objGuiaEnvio.iIDUNIDAD_AGENCIA)
        v_destino = objGuiaEnvio.fnIATA(objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO)

        ObjRptGuiaEnvio.P_PROVINCIA = TxtCiudadDestino.Text
        ObjRptGuiaEnvio.P_CARGO = IIf(objGuiaEnvio.iIDTipoFacturacion = 3, "X", " ")


        Dim flat As Boolean = True
        Dim lb_valida As Boolean
        Try
            'PARAMETRO IDGUIA ENVIO
            Dim iIDGUIAS_ENVIO As Integer = 0
            Dim sFECHA_GUIA As String = txtFechaGuia.Text '---------------------------------> PARAMETRO FECHA GUIA            
            Dim sNRO_GUIA As String = RellenoRight(NroDigitos_Guias, txtNroNroGuia.Text.Trim) '--> PARAMETRO NRO GUIA             
            '=================================CLIENTE=======================================================                                           
            If (TipoComprobante = 1 Or CboProducto.SelectedValue = 7) Then
                sNombresCli = ""
            ElseIf ChkCliente1.Checked And TipoComprobante = 1 Then
                NombresCont = ""
            ElseIf ChkCliente2.Checked And TipoComprobante = 1 Then
                sNombresConsig = ""
            End If

            '---------DATOS DEL CLIENTE------
            Dim iClienteModificado As Integer = IIf(bClienteModificado, 1, 0)
            Dim iIDPERSONA As Integer = IIf(bClienteNuevo, 0, iID_Persona) '---------------------->  PARAMETRO IDPERSONA    
            Dim sNombresCliente As String = IIf(TxtNomCliente.Text <> "", TxtNomCliente.Text, "@") ' PARAMETRO NOMBRES O RAZON SOCIAL
            Dim sNumeroDocumentoCliente As String = IIf(TxtNroDocCliente.Text <> "", TxtNroDocCliente.Text, "@")
            Dim iID_TipoDocumentoCliente As Integer = iID_TipoDocCli '--->agre
            Dim sNombreCliente As String = sNombresCli
            Dim sApellidoPaternoCliente As String = sApCli
            Dim sApellidoMaternoCliente As String = sAmCli
            Dim TelefonoCliente As String = IIf(sTelfCliente.Length > 0, sTelfCliente, "@")

            '--DIRECCION ESTRUCTURADO DEL CLIENTE          
            Dim iDireccionCliente_Mod As Integer = IIf(bDireccionModificada, 1, 0)
            'PARAMETRO IDDIRECCION_ORIGEN******
            If CboDireccion.SelectedValue = 0 Then
                IdDireccionOrigen = -1
            End If
            Dim IDDIREECION_ORIGEN As Integer = IdDireccionOrigen
            'PARAMETRO NOMBRE DE LA DIRECCION**
            Dim NombreDireccion_Origen As String = IIf(IdDireccionOrigen = -1, "@", CboDireccion.Text)

            '=============================DATOS REMITENTE=====================================
            If CboRemitente.SelectedIndex = 0 Then
                idRemitente = -1
            Else
                If Me.CboRemitente.Items.Count <= 2 Then
                    idRemitente = 0
                Else
                    If Me.CboRemitente.SelectedValue <> idRemitente Then
                        idRemitente = Me.CboRemitente.SelectedValue
                        bRemitenteModificado = True
                    End If
                End If
            End If
            If idRemitente = 0 AndAlso Me.ChkCliente.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNumDocRemitente.Text)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    Me.TxtNumDocRemitente.Tag = 0
                    idRemitente = 0
                Else
                    Me.TxtNumDocRemitente.Tag = dt.Rows(0).Item(0)
                    idRemitente = dt.Rows(0).Item(0)
                    bRemitenteModificado = False
                End If
            End If

            'PARAMETRO ID_NOMBRE_REMITENTE**
            Dim iRemitenteModificado As Integer = IIf(bRemitenteModificado, 1, 0)
            Dim iIDRemitente As Integer = idRemitente
            Dim sNombresRemitente As String = IIf(idRemitente = -1, "@", CboRemitente.Text)
            Dim sNumeroDocumentoRemitente As String = IIf(sNroDocRemitente.Trim = "", "@", sNroDocRemitente.Trim)
            Dim iID_TipoDocumentoRemitente As Integer = iID_TipoDocRemitente
            Dim sNombRemitente As String = IIf(iID_TipoDocRemitente = 1, "", sNombreRemitente)
            Dim sApellidoPaternoRemitente As String = sApRemitente
            Dim sApellidoMaternoRemitente As String = sAmRemitente

            '=============================DATOS CONTACTO======================================                           
            'PARAMETRO ID_NOMBRE_CONTACTO**          
            If CboContacto.SelectedIndex = 0 Then
                idcontacto = -1
            Else
                If Me.CboContacto.Items.Count <= 2 Then
                    idcontacto = 0
                Else
                    If Me.CboContacto.SelectedValue <> idcontacto Then
                        idcontacto = Me.CboContacto.SelectedValue
                        bContactoModificado = True
                    End If
                End If
            End If

            If idcontacto = 0 AndAlso Me.ChkCliente1.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNroDocContacto.Text)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    Me.TxtNroDocContacto.Tag = 0
                    idcontacto = 0
                Else
                    Me.TxtNroDocContacto.Tag = dt.Rows(0).Item(0)
                    idcontacto = dt.Rows(0).Item(0)
                    bContactoModificado = False
                End If
            End If

            Dim iContactoModificado As Integer = IIf(bContactoModificado, 1, 0)
            Dim iIDcontacto As Integer = idcontacto
            Dim sNombresContacto As String = IIf(idcontacto = -1, "@", CboContacto.Text) '            
            Dim sNumeroDocumentoContacto As String = IIf(Trim(TxtNroDocContacto.Text) <> "", TxtNroDocContacto.Text, "@")
            Dim iIDTipoDocumentoContacto As Integer = iID_TipoDocCont
            Dim sNombreContacto As String = IIf(iID_TipoDocCont = 1, "", NombresCont)
            Dim sApellidoPaternoContacto As String = apellPatCont
            Dim sApellidoMaternoContacto As String = apellMatCont

            '======================================CONSIGNADO=================================   
            '***Comentado x NConsignado****           
            '===Agregado x NConsignado==============================
            If iIDConsignado = 0 AndAlso Me.ChkCliente2.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(GrdNConsignado("Nº Documento", 0).Value)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    GrdNConsignado("IDConsignado", 0).Value = 0
                Else
                    GrdNConsignado("IDConsignado", 0).Value = dt.Rows(0).Item(0)
                    GrdNConsignado("Modificado", 0).Value = "0"
                End If
            End If

            '===Agregado x NConsignado==============================
            Dim iConsignadoModificado As String = ""
            Dim iID_Consignado As String = ""
            sNombresConsignado = ""
            Dim sNumeroDocumentoConsignado As String = ""
            Dim iIDTipoDocumentoConsignado As String = ""
            Dim sNombreConsignado As String = ""
            Dim sApellidoPaternoConsignado As String = ""
            Dim sApellidoMaternoConsignado As String = ""
            sTelefonoConsignado = ""
            Dim IDVentaConsignado As String = ""

            For i As Integer = 0 To GrdNConsignado.Rows.Count() - 1
                iID_Consignado &= GrdNConsignado("IDConsignado", i).Value & ";"
                sNombresConsignado &= GrdNConsignado("Nombres", i).Value & ";"
                sNombreConsignado &= GrdNConsignado("nombre", i).Value & ";"
                sApellidoPaternoConsignado &= GrdNConsignado("apepat", i).Value & ";"
                sApellidoMaternoConsignado &= GrdNConsignado("apemat", i).Value & ";"
                sNumeroDocumentoConsignado &= GrdNConsignado("Nº Documento", i).Value & ";"
                iIDTipoDocumentoConsignado &= GrdNConsignado("tipo", i).Value & ";"
                sTelefonoConsignado &= GrdNConsignado("Telefono", i).Value & ";"
                iConsignadoModificado &= GrdNConsignado("Modificado", i).Value & ";"
                IDVentaConsignado &= GrdNConsignado("IDVentaConsignado", i).Value & ";"
            Next
            '========================================================

            '*****DIRECCION ESTRUCTURADA CONSIGNADO*****
            'PARAMETRO ID_DIRECCION_DESTINO**
            If CboDireccion2.SelectedIndex = 0 Then
                idDireConsignado = -1
            End If
            ObjVentaCargaContado.v_IDDIREECION_DESTINO = idDireConsignado
            Dim iDirecConsignado_mod As Integer = IIf(bDirecConsigMod, 1, 0)
            ObjVentaCargaContado.v_DIRECCION_DESTINATARIO = IIf(idDireConsignado = -1, "@", CboDireccion2.Text)

            '----------------------------------------------------------------------            
            Dim iIDTIPO_ENTREGA As Integer = CboTipoEntrega.SelectedValue 'PARAMETRO TIPO ENTREGA CARGA (Agencia,Domicilio)            
            Dim iIDFORMA_PAGO As Integer = 2 'PARAMETRO FORMA PAGO 'Int(objGuiaEnvio.coll_Lista_Forma_Pagos.Item(Me.cmbFormaCredito.SelectedIndex.ToString()))            
            Dim iAGENCIA_ORIGEN As Integer = CboCiudad_Origen.SelectedValue 'objGuiaEnvio.iIDUNIDAD_AGENCIA 'PARAMETRO IDUNIDAD AGENCIA_ORIGEN  'agregar 'Int(coll_iOrigen.Item(iWinDestino.IndexOf(txtiWinOrigen.Text) + 1))
            Dim iIDCIUDAD_TRANSITO As Integer = objGuiaEnvio.iIDUNIDAD_AGENCIA 'PARAMETRO IDCIUDAD TRANSITO
            Dim iAGENCIA_DESTINO As Integer = idUnidadAgencias 'PARAMETRO IDAGENCIA DESTINO  'agregar'Int(coll_iDestino.Item(iWinDestino.IndexOf(txtiWinDestino.Text) + 1))
            Dim iIDAGENCIAS As Integer = CboAgencia_Origen.SelectedValue 'dtoUSUARIOS.m_iIdAgencia 'PARAMETRO IDAGENCIAS'Agregar codigo           
            Dim sIDDIRECCION_REMITENTE As String = IdDireccionOrigen 'PARAMETRO IDDIRECCION REMITENTE

            Dim sIDCONTACTO_REMITENTE As String = idcontacto 'CboContacto.SelectedValue 'PARAMETRO IDCONTACTOREMITENTE
            Dim sIDTELEFONO_REMITENTE As String = 0 'PARAMETRO IDTELEFONO REMITENTE
            Dim sIDCONTACTO_DESTINATARIO As String = IIf(IsNothing(iIDConsignado), 0, iIDConsignado) 'CODIGO NOMBRE CONSIGNADO 'Int(objGuiaEnvio.coll_Nombres_Destinatario.Item(indexof.ToString))
            Dim sIDDIRECCION_DESTINATARIO As String = idDireConsignado  'CODIGO DIRECCION CONSIGNADO'Int(objGuiaEnvio.coll_Direccion_Destinatario.Item(indexof.ToString))

            'PARAMETRO IDTELEFONO CONSIGNADO
            'OBSERVACION
            'If iWinTelefono_Destinatario.Count > 0 Then
            '    indexof = iWinTelefono_Destinatario.IndexOf(txtTelefonoDestinatario.Text)
            '    objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1
            '    If indexof >= 0 Then
            '        objGuiaEnvio.iIDTEFONO_CONSIGNADO = Int(objGuiaEnvio.coll_Telefono_Destinatario.Item(indexof.ToString))
            '    End If
            'End If
            Dim sIDTELEFONO_CONSIGNADO As String = 0 'PARAMETRO IDTELEFONO CONSIGNADO

            Dim iCANTIDAD As Integer = 0  'Unidades Peso
            Dim iCANTIDAD_X_UNIDAD_VOLUMEN As Integer = 0 'Unidades Volumen
            Dim iCANTIDAD_X_UNIDAD_ARTI As Integer = 0 'Unidades Articulos
            Dim dTOTAL_VOLUMEN As Double = 0
            Dim dTOTAL_PESO As Double = 0
            Dim iCANTIDAD_SOBRES As Integer
            Dim dMONTO_BASE As Double
            Dim dPrecio_x_Volumen As Double
            Dim dPrecio_x_Peso As Double
            Dim dPrecioSobre As Double

            Dim totalCosto As Double = 0
            Dim valor1 As Double = 0
            Dim valor2 As Double = 0
            Dim Bulto As Double = 0
            Dim Peso As Double = 0


            If TipoGrid_ = FormatoGrid.BULTO Then
                If Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) = 0 Then Bulto = 0 Else Bulto = GrdDetalleVenta("Bulto", 0).Value
                If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 0).Value) = 0 Then Peso = 0 Else Peso = GrdDetalleVenta("Peso/Volumen", 0).Value

                'PESO                
                iCANTIDAD = Bulto 'Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Bulto", 0).Value.ToString)), "##,###,####.00")
                dTOTAL_PESO = Peso 'Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Peso/Volumen", 0).Value.ToString)), "##,###,####.00")
                dPrecio_x_Peso = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 0).Value.ToString)), "##,###,####.00") ' Costo x Peso  

                'VOLUMEN                
                If Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) = 0 Then Bulto = 0 Else Bulto = GrdDetalleVenta("Bulto", 1).Value
                If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 1).Value) = 0 Then Peso = 0 Else Peso = GrdDetalleVenta("Peso/Volumen", 1).Value

                iCANTIDAD_X_UNIDAD_VOLUMEN = Bulto 'Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Bulto", 1).Value.ToString)), "##,###,####.00")
                dTOTAL_VOLUMEN = Peso 'Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Peso/Volumen", 1).Value.ToString)), "##,###,####.00")
                dPrecio_x_Volumen = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 1).Value.ToString)), "##,###,####.00") ' Costo x volumen 

                'SOBRE
                If Conversion.Val(GrdDetalleVenta("Bulto", 2).Value) = 0 Then Bulto = 0 Else Bulto = GrdDetalleVenta("Bulto", 2).Value
                iCANTIDAD_SOBRES = Bulto 'Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Bulto", 2).Value.ToString)), "##,###,####.00")
                dPrecioSobre = tarifa_Sobre

                dMONTO_BASE = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 3).Value.ToString)), "##,###,####.00") ' Base
            End If


            'PARAMETRO MONTO BASE            

            Dim iMetroCubico As Integer = 0
            If ChkM3.Checked Then
                If Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) = 0 Then Bulto = 0 Else Bulto = GrdDetalleVenta("Bulto", 1).Value
                iMetroCubico = 1
                iCANTIDAD_X_UNIDAD_VOLUMEN = Bulto 'PARAMETRO iCANTIDAD_X_UNIDAD_VOLUMEN

                valor1 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 1).Value.ToString)), "##,###,###.00")
                valor2 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Peso Kg", 1).Value.ToString)), "##,###,###.00")
                dTOTAL_VOLUMEN = valor2 'PARAMETRO DTOTAL_VOLUMEN
                ' totalCosto = totalCosto + valor1 * valor2 + Monto_Base
            End If


            If ChkArticulos.Checked Then
                Dim Total As Double = 0
                Dim ii1 As Integer = 0
                For ii1 = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                    Total = Total + Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii1).Cells("Cantidad").Value.ToString)
                    'PARAMETRO iCANTIDAD_X_UNIDAD_ARTI                    
                    iCANTIDAD_X_UNIDAD_ARTI = iCANTIDAD_X_UNIDAD_ARTI + Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii1).Cells("Cantidad").Value.ToString) 'CambioR 09112011
                Next
            End If


            'PARAMETRO dPRECIO_X_UNIDAD
            Dim dPRECIO_X_UNIDAD As Double = tarifa_Articulo 'kgr
            'PARAMETRO dIMPUESTO
            Dim dIMPUESTO As Double = IGV
            'PARAMETRO dMONTO_IMPUESTO
            Dim dMONTO_IMPUESTO As Double = Me.TxtImpuesto.Text
            'PARAMETRO dTOTAL_COSTO
            Dim dTOTAL_COSTO As Double = Me.TxtTotal.Text
            'PARAMETRO iIDUSUARIO_PERSONAL
            Dim iIDUSUARIO_PERSONAL As Integer = dtoUSUARIOS.IdLogin
            'PARAMETRO iIDROL_USUARIO
            Dim iIDROL_USUARIO As Integer = dtoUSUARIOS.IdRol
            'PARAMETRO sIP
            Dim sIP As String = dtoUSUARIOS.IP
            'PARAMETRO iIDESTADO_REGISTRO
            Dim iIDESTADO_REGISTRO As Integer = 18

            'PARAMETRO iNOMBRES_REMITENTE
            Dim sNOMBRES_REMITENTE As String = ""
            If Me.CboRemitente.Text <> "" And Me.CboRemitente.Text.Length > 3 Then
                sNOMBRES_REMITENTE = Me.CboRemitente.Text
            Else
                sNOMBRES_REMITENTE = "NULL"
            End If

            'PARAMETRO iDNI_REMITENTE
            Dim sDNI_REMITENTE As String = ""
            If TxtNroDocContacto.Text <> "" And TxtNroDocContacto.Text.Length > 5 Then
                sDNI_REMITENTE = Me.TxtNroDocContacto.Text
            Else
                sDNI_REMITENTE = "@"
            End If

            'PARAMETRO iDIRECCION_REMITENTE
            Dim sDIRECCION_REMITENTE As String = ""
            If CboDireccion.Text <> "" And CboDireccion.Text.Length > 5 Then
                sDIRECCION_REMITENTE = CboDireccion.Text
            End If

            'PARAMETRO iNOMBRES_DESTINATARIO... (CONSIGNADO)
            Dim sNOMBRES_DESTINATARIO As String = ""
            'If TxtNombConsignado.Text <> "" And TxtNombConsignado.Text.Length > 5 Then
            '    sNOMBRES_DESTINATARIO = TxtNombConsignado.Text
            'End If axl

            'PARAMETRO sDNI_DESTINATARIO
            Dim sDNI_DESTINATARIO As String = ""
            'If TxtNroDocConsignado.Text <> "" Then '19/08/2008 -  And txtDNIDestinatario.Text.Length > 5 Then ---> No se sabe el nº dcto del consignado
            '    sDNI_DESTINATARIO = TxtNroDocConsignado.Text
            'End If axl

            'PARAMETRO iDIRECCION_DESTINATARIO
            Dim sDIRECCION_DESTINATARIO As String = ""
            If CboDireccion2.Text <> "" And CboDireccion2.Text.Length > 5 Then
                sDIRECCION_DESTINATARIO = CboDireccion2.Text
            End If
            'PARAMETRO iCARGO

            'hlamas 22-03-2016
            'Dim iCARGO As Integer = Int(ChkCargo.Checked)
            Dim iCARGO As Integer = Int(rbtCargoSi.Checked)

            'PARAMETRO sTelefono_Remitente
            Dim sTelefono_Remitente As String = IIf(TxtTelfCliente.Text <> "", TxtTelfCliente.Text, "NULL")
            'PARAMETRO sTelefono_Destinatario
            Dim sTelefono_Destinatario As String = "" 'IIf(TxtTelfConsignado.Text <> "", TxtTelfConsignado.Text, "NULL") axl

            'PARAMETRO iID_REMITENTE
            Dim sID_REMITENTE As String = 0
            'PARAMETRO iREMITENTE 
            Dim sREMITENTE As String = CboRemitente.Text 'OBSERVACION
            'PARAMETRO iNRODOC_REM
            Dim sNRODOC_REM As String = TxtNumDocRemitente.Text
            'PARAMETRO iIDCENTRO_COSTO
            Dim iIDCENTRO_COSTO As Integer = CboSubCuenta.SelectedValue


            Dim iIDSINO_SOBRES As Integer
            If ChkSobres.Checked = True Then
                'PARAMETRO iCANTIDAD_SOBRES
                iCANTIDAD_SOBRES = Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                'PARAMETRO iIDSINO_SOBRES
                iIDSINO_SOBRES = 1
            End If

            'PARAMETRO iIDAGENCIAS_DESTINO
            Dim iIDAGENCIAS_DESTINO As Integer = CboAgenciaDest.SelectedValue

            objGuiaEnvio.iIDCONTACTO_PERSONA = 0
            objGuiaEnvio.iIDDIRECCION_CONSIGNADO = 0


            'OBSERVACION
            'If Me.dtGridViewArticulo.Visible = True Then
            '    objGuiaEnvio.dTOTAL_PESO = fn_peso_desde_articulos()
            'End If

            'If Me.dtGridViewArticulo.Visible = True Then
            '    objGuiaEnvio.dTOTAL_VOLUMEN = fn_Volumen_desde_articulos()
            'End If

            '----------------------------------------------------------------------------------------------------------------------            
            'objGuiaEnvio.dMONTO_BASE = Monto_Base '26/08/2008  Se toma el valor de los bultos                       
            iTOTAL_BULTOS = ""
            iTOTAL_VOLUMEN = ""
            iTOTAL_PESO = ""
            objGuiaEnvio.iCANTIDAD = iCANTIDAD
            objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN = iCANTIDAD_X_UNIDAD_VOLUMEN
            objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = iCANTIDAD_X_UNIDAD_ARTI
            objGuiaEnvio.iCANTIDAD_SOBRES = iCANTIDAD_SOBRES
            objGuiaEnvio.dTOTAL_VOLUMEN = dTOTAL_VOLUMEN
            objGuiaEnvio.dTOTAL_PESO = dTOTAL_PESO
            objGuiaEnvio.iIDTIPO_ENTREGA_CARGA = Me.CboTipoEntrega.SelectedValue
            objGuiaEnvio.iIDFORMA_PAGO = 1

            Dim sReferencia As String = TxtReferencia.Text.Trim

            '=========================================================
            If objGuiaEnvio.ActualizarCredito(IDGUIAS_ENVIO, sFECHA_GUIA, sNRO_GUIA, iIDTIPO_ENTREGA, iIDFORMA_PAGO, _
                                              iAGENCIA_ORIGEN, iIDCIUDAD_TRANSITO, iAGENCIA_DESTINO, iIDAGENCIAS, sIDCONTACTO_REMITENTE, _
                                              sIDDIRECCION_REMITENTE, sIDTELEFONO_REMITENTE, sIDCONTACTO_DESTINATARIO, sIDDIRECCION_DESTINATARIO, _
                                              sIDTELEFONO_CONSIGNADO, dMONTO_BASE, dTOTAL_PESO, iCANTIDAD, dTOTAL_VOLUMEN, iCANTIDAD_X_UNIDAD_VOLUMEN, _
                                              iCANTIDAD_X_UNIDAD_ARTI, dPRECIO_X_UNIDAD, dIMPUESTO, dMONTO_IMPUESTO, dTOTAL_COSTO, iIDUSUARIO_PERSONAL, _
                                              iIDROL_USUARIO, sIP, iIDESTADO_REGISTRO, sNOMBRES_REMITENTE, sDNI_REMITENTE, sDIRECCION_REMITENTE, _
                                              sNOMBRES_DESTINATARIO, sDNI_DESTINATARIO, sDIRECCION_DESTINATARIO, dPrecio_x_Volumen, dPrecio_x_Peso, dPrecioSobre, _
                                              iCARGO, sTelefono_Remitente, sTelefono_Destinatario, sID_REMITENTE, sREMITENTE, sNRODOC_REM, iIDCENTRO_COSTO, _
                                              iCANTIDAD_SOBRES, iIDSINO_SOBRES, iIDAGENCIAS_DESTINO, iClienteModificado, iIDPERSONA, sNombresCliente, _
                                              sNumeroDocumentoCliente, iID_TipoDocumentoCliente, sNombreCliente, sApellidoPaternoCliente, _
                                              sApellidoMaternoCliente, TelefonoCliente, iRemitenteModificado, iIDRemitente, sNombresRemitente, _
                                              sNumeroDocumentoRemitente, iID_TipoDocumentoRemitente, sNombRemitente, sApellidoPaternoRemitente, _
                                              sApellidoMaternoRemitente, iContactoModificado, iIDcontacto, sNombresContacto, sNumeroDocumentoContacto, _
                                              iIDTipoDocumentoContacto, sNombreContacto, sApellidoPaternoContacto, sApellidoMaternoContacto, _
                                             iConsignadoModificado, iID_Consignado, sNombresConsignado, sNumeroDocumentoConsignado, _
                                             iIDTipoDocumentoConsignado, sNombreConsignado, sApellidoPaternoConsignado, sApellidoMaternoConsignado, _
                                             sTelefonoConsignado, IDVentaConsignado, iDireccionCliente_Mod, iDepartamentoCli, iProvinciaCli, iDistritoCli,
                                             IDviaCli, ViaCli, NroCli, ManzanaCli, loteCli, id_NivelCli, NivelCli, id_ZonaCli, ZonaCli, _
                                             id_ClasificacionCli, ClasificacionCli, iDirecConsignado_mod, iDepartamentoConsig, iProvinciaConsig, _
                                             iDistritoConsig, IDviaConsig, ViaConsig, NroConsig, ManzanaConsig, loteConsig, id_NivelConsig, _
                                             NivelConsig, id_ZonaConsig, ZonaConsig, id_ClasificacionConsig, ClasificacionConsig, sEmail, sReferencia, iMetroCubico, Me.CboTipoTarifa.SelectedIndex) = True Then


                iTOTAL_BULTOS = objGuiaEnvio.iCANTIDAD + objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN + objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + objGuiaEnvio.iCANTIDAD_SOBRES
                iTOTAL_VOLUMEN = objGuiaEnvio.dTOTAL_VOLUMEN
                iTOTAL_PESO = objGuiaEnvio.dTOTAL_PESO

                '-----------------------------------------------------------------
                'INSERCION VOLUMETRICO
                '-----------------------------------------------------------------
                Try
                    If ChkM3.Checked = True Then
                        Dim obj As New dtoVentaCargaContado
                        Dim ii As Integer = 0
                        objGuia_Envio_Articulo.iIDGUIAS_ENVIO = objGuiaEnvio.iIDGUIAS_ENVIO
                        objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
                        objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                        objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                        objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

                        For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                            If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" And IsNumeric(GrdDetalleVenta.Rows(ii).Cells("Tipo").Value) Then
                                    obj.FNinsert_Volumetrico(
                                             ii,
                                             0,
                                             objGuiaEnvio.iIDGUIAS_ENVIO,
                                             GrdDetalleVenta.Rows(ii).Cells("Tipo").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Bulto").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Altura").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Ancho").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Largo").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Peso Kg").Value,
                                             dFactor,
                                             GrdDetalleVenta.Rows(ii).Cells("Costo").Value)
                                End If
                            End If
                        Next
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                '-----------------------------------------------------------------
                'INSERCION DE ARTICULOS
                '-----------------------------------------------------------------                                
                objGuia_Envio_Articulo.iIDGUIAS_ENVIO = objGuiaEnvio.iIDGUIAS_ENVIO
                objGuia_Envio_Articulo.iIGV = IGV
                objGuia_Envio_Articulo.iDESCUENTO = 0
                objGuia_Envio_Articulo.iPENALIDAD = 0
                objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol
                objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18

                If ChkArticulos.Checked = True Then
                    For ii As Integer = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                        If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                            If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                If IsNothing(GrdDetalleVenta.Rows(ii).Cells("idGuiaArticulo").Value) Then
                                    objGuia_Envio_Articulo.iCONTROL = 1
                                    objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = 0
                                Else
                                    objGuia_Envio_Articulo.iCONTROL = 2
                                    objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = GrdDetalleVenta.Rows(ii).Cells("idGuiaArticulo").Value.ToString
                                End If
                                'objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = IIf(GrdDetalleVenta.Rows(ii).Cells("idGuiaArticulo").Value.ToString = "", 0, GrdDetalleVenta.Rows(ii).Cells("idGuiaArticulo").Value.ToString) 'cambioR 10112011
                                objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells("IDARTICULO").Value.ToString)
                                objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells("Cantidad").Value.ToString)
                                If Val(GrdDetalleVenta.Rows(ii).Cells("M3").Value.ToString) = 0 Then
                                    objGuia_Envio_Articulo.iMETRO_CUBICO = 0
                                Else
                                    objGuia_Envio_Articulo.iMETRO_CUBICO = CDbl(GrdDetalleVenta.Rows(ii).Cells("M3").Value.ToString)
                                End If
                                objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells("Peso").Value.ToString)
                                objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells("Precio").Value.ToString)
                                objGuia_Envio_Articulo.fnINSTUPD_GENVIO_ARTICULOS_RGT()
                            End If
                        End If
                    Next
                End If


                '---------------DETALLE DOCUMENTOS----------------------------------
                flat = True
                Dim i As Integer = 0
                Dim serie_NroDoc() As String
                Dim iContador As Integer = 0
                'If objGuiaEnvio.iCONTROL = 1 Then
                For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 1
                    Try
                        objGuiaEnvio.iControl_Documentos = i
                        If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Cargo")) = False Then
                            'If Trim(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value.ToString) <> "" Then
                            If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value) Then
                                serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value.ToString, "-")
                                If serie_NroDoc.Length > 1 Then
                                    objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                    objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                    strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
                                    If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                        If objGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS_I() = True Then
                                            iContador = iContador + 1
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
                            'If GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString <> "" Then
                            If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value) Then
                                serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString, "-")
                                If serie_NroDoc.Length > 1 Then
                                    objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                    objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                    strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
                                    If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                        If objGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS_I() = True Then
                                            iContador = iContador + 1
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Next
                'End If
            Else
                Me.Cursor = Cursors.Default
                'MessageBox.Show("La Guia no se Registró", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                flat = False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
            flat = False
        End Try
        Return flat
    End Function

#Region "FUNCIONES DE IMPRESIONES GUIA_ENVIO CREDITO"

    Public Function fnInprecion_Guia_Envio() As Boolean
        Dim obj As New Imprimir
        Try
            ObjRptGuiaEnvio.p_Hora_Guia = fnGetHora()
            Dim objImpresoras As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt As DataTable = objImpresoras.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 3)
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, iIzquierda As Integer = 0
            Dim flags As Boolean
            If dt.Rows.Count = 0 Then
                flags = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flags = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamaño")
                    iSuperior = dt.Rows(0).Item("superior")
                    iIzquierda = dt.Rows(0).Item("izquierda")
                    flags = True
                End If
            End If

            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            Dim iLong As Integer = IIf(iTamaño = 0, 22, iTamaño)

            y = iLong * pagina + 2
            i += 1

            If flags Then
                Dim sConsignado As String = ObjRptGuiaEnvio.P_NOMBRES_DESTI.Trim.Replace(";", ",")
                sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)

                obj.Inicializar()
                obj.Impresora = sImpresora
                obj.Superior = iSuperior
                obj.Izquierda = iIzquierda

                obj.EscribirLinea(y, 22, ObjRptGuiaEnvio.p_NroGUIA)
                obj.EscribirLinea(y, 82, ObjRptGuiaEnvio.p_codigo_iata_ori)
                obj.EscribirLinea(y, 92, ObjRptGuiaEnvio.p_codigo_iata_desti)
                obj.EscribirLinea(y + 2, 0, ObjRptGuiaEnvio.p_ruc)
                obj.EscribirLinea(y + 5, 0, ObjRptGuiaEnvio.P_REMITENTE)
                If ObjRptGuiaEnvio.P_DIRECCION_REMI.ToString.Length > 40 Then
                    obj.EscribirLinea(y + 3, 0, ObjRptGuiaEnvio.P_DIRECCION_REMI.ToString.Substring(0, 41))
                    obj.EscribirLinea(y + 4, 0, ObjRptGuiaEnvio.P_DIRECCION_REMI.ToString.Substring(41))
                Else
                    obj.EscribirLinea(y + 6, 0, ObjRptGuiaEnvio.P_DIRECCION_REMI)
                End If

                obj.EscribirLinea(y + 5, 59, sConsignado)
                obj.EscribirLinea(y + 6, 59, ObjRptGuiaEnvio.P_DIRECCION_DESTI)

                obj.EscribirLinea(y + 2, 33, p_domicilio)
                obj.EscribirLinea(y + 2, 43, p_agencia)
                obj.EscribirLinea(y + 2, 54, p_contado)
                obj.EscribirLinea(y + 2, 64, p_destino)
                obj.EscribirLinea(y + 2, 76, p_credito)

                'obj.EscribirLinea(ObjRptGuiaEnvio.P_CARGO)
                obj.EscribirLinea(y + 9, 0, ObjRptGuiaEnvio.p_contacto)
                obj.EscribirLinea(y + 8, 29, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI)
                obj.EscribirLinea(y + 8, 59, ObjRptGuiaEnvio.P_PROVINCIA)
                obj.EscribirLinea(y + 8, 84, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI)


                'obj.EscribirLinea(Mid(strNroGuias_Remision, 1, 80))
                If Not (strNroGuias_Remision Is Nothing) Then
                    If Val(strNroGuias_Remision.Trim.Length) < 126 Then
                        strNroGuias_Remision = strNroGuias_Remision & Space(126 - Len(strNroGuias_Remision.Trim))
                    End If
                    strNroGuias_Remision = Mid(strNroGuias_Remision.Trim, 1, 126)

                    Dim iGuiones As Integer
                    iGuiones = DevuelveGuiones(strNroGuias_Remision)
                    If iGuiones >= 7 Then       '3 lineas
                        obj.EscribirLinea(y + 11, 0, Trim(Mid(strNroGuias_Remision, 1, 42)))
                        obj.EscribirLinea(y + 12, 0, Trim(Mid(strNroGuias_Remision, 43, 42)))
                        obj.EscribirLinea(y + 13, 0, Trim(Mid(strNroGuias_Remision, 86, 42)))
                    ElseIf iGuiones >= 4 Then   '2 lineas
                        obj.EscribirLinea(y + 11, 0, Trim(Mid(strNroGuias_Remision, 1, 42)))
                        obj.EscribirLinea(y + 12, 0, Trim(Mid(strNroGuias_Remision, 43, 42)))
                    Else                        '1 linea
                        obj.EscribirLinea(y + 11, 0, Trim(Mid(strNroGuias_Remision, 1, 42)))
                    End If
                End If

                obj.EscribirLinea(y + 17, 26, Format(CDate(ObjRptGuiaEnvio.P_FECHA_GUIA), "dd     MM      yy"))
                obj.EscribirLinea(y + 13, 49, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_BULTOS), 2))
                obj.EscribirLinea(y + 13, 57, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_PESO), 2))
                obj.EscribirLinea(y + 13, 65, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_VOLUMEN), 2))
                obj.EscribirLinea(y + 13, 78, dtoUSUARIOS.m_sFecha)
                obj.EscribirLinea(y + 13, 92, ObjRptGuiaEnvio.p_Hora_Guia)
                obj.EscribirLinea(y + 14, 57, "Nº SOBRES " & ObjRptGuiaEnvio.P_TOTAL_SOBRES)

                obj.Comprimido = True
                obj.Tamaño = iLong
                obj.Imprimir()
                obj.Finalizar()
            Else
                Dim objImpresora As New dtoVentaCargaContado
                ''Dim flag = objImpresora.fnSP_Buscar_Impresora(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
                ''19/08/2008 - Solo se trabaja con el tipo de comprobante de GE - omendoza            
                ''Lima
                '04/05/2009 - Cambio por el datahelper 
                Dim flag = objImpresora.fnSP_Buscar_Impresora(3, dtoUSUARIOS.IP)
                If flag Then
                    Dim objImprimir As New ImprimirTexto("Draft Condensed", 8, objImpresora.v_Impresora, "guia", 1305, 1305)

                    'Envío de impresión texto Guía de Envío (Nuevo)
                    'Dim objImprimir As New ImprimirTexto("Arial", 8, "PDFCreator", "tres", 1305, 1305)
                    objImprimir.Agregar(210, 25, ObjRptGuiaEnvio.p_NroGUIA)
                    objImprimir.Agregar(485, 15, ObjRptGuiaEnvio.p_codigo_iata_ori)
                    objImprimir.Agregar(545, 15, ObjRptGuiaEnvio.p_codigo_iata_desti)
                    objImprimir.Agregar(0, 55, ObjRptGuiaEnvio.p_ruc)
                    objImprimir.Agregar(25, 105, ObjRptGuiaEnvio.P_REMITENTE)
                    objImprimir.Agregar(25, 120, ObjRptGuiaEnvio.P_DIRECCION_REMI)

                    objImprimir.Agregar(355, 105, ObjRptGuiaEnvio.P_NOMBRES_DESTI)
                    objImprimir.Agregar(355, 120, ObjRptGuiaEnvio.P_DIRECCION_DESTI)

                    objImprimir.Agregar(190, 55, p_domicilio)
                    objImprimir.Agregar(245, 55, p_agencia)
                    objImprimir.Agregar(310, 55, p_contado)
                    objImprimir.Agregar(370, 55, p_destino)
                    objImprimir.Agregar(435, 55, p_credito)
                    objImprimir.Agregar(570, 55, ObjRptGuiaEnvio.P_CARGO)

                    objImprimir.Agregar(25, 175, ObjRptGuiaEnvio.p_contacto)

                    objImprimir.Agregar(162, 155, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI)
                    objImprimir.Agregar(370, 155, ObjRptGuiaEnvio.P_PROVINCIA)
                    objImprimir.Agregar(525, 155, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI)

                    objImprimir.Agregar(20, 210, Mid(strNroGuias_Remision, 1, 80))
                    objImprimir.Agregar(155, 300, Format(CDate(ObjRptGuiaEnvio.P_FECHA_GUIA), "dd     MM      yy"))

                    objImprimir.Agregar(280, 235, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_BULTOS), 2))
                    objImprimir.Agregar(330, 235, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_PESO), 2))
                    objImprimir.Agregar(380, 235, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_VOLUMEN), 2))

                    objImprimir.Agregar(450, 240, dtoUSUARIOS.m_sFecha)
                    objImprimir.Agregar(535, 240, ObjRptGuiaEnvio.p_Hora_Guia)

                    objImprimir.Agregar(300, 252, "Nº SOBRES " & ObjRptGuiaEnvio.P_TOTAL_SOBRES)

                    objImprimir.Imprimir()
                    objImprimir = Nothing
                Else
                    '
                    'MessageBox.Show("El Documento no tiene asociado una impresora.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '
                    ''19/08/2008 - Inicio comentado - Omendoza - Printer 
                    Dim ObjReport As New ClsLbTepsa.dtoFrmReport
                    ObjReport.rutaRpt = PathFrmReport
                    'ObjReport.rutaRpt = "\\192.168.50.196\ReportesRitcher\"
                    'ObjReport.conectar(rptservice, rptuser, rptpass)
                    ObjReport.printrptlpt(True, "", "GUI007.RPT", _
                    "p_domicilio;" & p_domicilio, _
                    "p_agencia;" & p_agencia, _
                    "p_contado;" & p_contado, _
                    "p_destino;" & p_destino, _
                    "p_credito;" & p_credito, _
                    "p_ruc;" & ObjRptGuiaEnvio.p_ruc, _
                    "p_codigo_iata_ori;" & ObjRptGuiaEnvio.p_codigo_iata_ori, _
                    "p_codigo_iata_desti;" & ObjRptGuiaEnvio.p_codigo_iata_desti, _
                    "P_NROCOMUNICACION_CONTACTO_ORI;" & ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI, _
                    "P_NROCOMUNICACION_CONTACTO_DESTI;" & ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI, _
                    "P_REMITENTE;" & ObjRptGuiaEnvio.P_REMITENTE, _
                    "P_DIRECCION_REMI;" & ObjRptGuiaEnvio.P_DIRECCION_REMI, _
                    "P_DIRECCION_DESTI;" & ObjRptGuiaEnvio.P_DIRECCION_DESTI, _
                    "P_NOMBRES_DESTI;" & ObjRptGuiaEnvio.P_NOMBRES_DESTI, _
                    "P_DOCUMENTOS;" & Mid(strNroGuias_Remision, 1, 80), _
                    "P_FECHA_GUIA;" & Format(CDate(ObjRptGuiaEnvio.P_FECHA_GUIA), "dd     MM      yy"), _
                    "P_TOTAL_BULTOS;" & FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_BULTOS), 2), _
                    "P_TOTAL_VOLUMEN;" & FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_VOLUMEN), 3), _
                    "P_TOTAL_PESO;" & FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_PESO), 2), _
                    "P_SOBRES;" & "NRO SOBRES : " & ObjRptGuiaEnvio.P_TOTAL_SOBRES, _
                    "P_CONTACTO;" & ObjRptGuiaEnvio.p_contacto, _
                    "P_LOGIN;" & " ", _
                    "P_NRO_GUIA;" & ObjRptGuiaEnvio.p_NroGUIA, _
                    "P_HORA_GUIA;" & ObjRptGuiaEnvio.p_Hora_Guia, _
                    "P_FECHA_RECIBIDO;" & dtoUSUARIOS.m_sFecha, _
                    "P_PROVINCIA;" & ObjRptGuiaEnvio.P_PROVINCIA, _
                    "P_CLIE_CARGO;" & ObjRptGuiaEnvio.P_CARGO)
                End If
            End If
            ' Fin de la modificación 19/08/2008 - Omendoza 
        Catch ex As Exception
            obj.Finalizar()
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    Dim bRango As Boolean
    Public Function fnImprimirEtiquetasGUIA() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)

            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            '   ObjCODIGOBARRA.Cantidad = objGuiaEnvio.v_CANTIDAD_ETIQUETAS

            'Dim I As Int16 = 1
            Dim i As Int16
            If bRango Then
                i = 1
            Else
                i = correlativo_inicial
                'Mod 21/08/2009 
                If i = 0 Then i = 1
            End If

            If i <= 0 Then i = 1

            'ObjCODIGOBARRA.tipo = 3
            'ObjCODIGOBARRA.id = objGuiaEnvio.iIDGUIAS_ENVIO
            ObjCODIGOBARRA.tipo = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            ObjCODIGOBARRA.id = Me.DgvLista.CurrentRow.Cells("idfactura").Value
            ObjCODIGOBARRA.sp_etiqueta_generada()
            '26/08/2009 - Obtiene Fecha y Hora - Hlamas
            '04/09/2009 - Obtiene Fecha y Hora x datahelper 
            ObjVentaCargaContado.fnFechaRegistro(3, objGuiaEnvio.iIDGUIAS_ENVIO)
            '
            sFecha = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(0)
            sHora = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(1)
            ' 
            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha

            '05/09/2009 - Cambiando por el datahelper 
            'While objGuiaEnvio.cur_codBarras.EOF = False And objGuiaEnvio.cur_codBarras.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = objGuiaEnvio.cur_codBarras.Fields.Item(0).Value
            '    prn.EscribeLinea("^XA")
            '    prn.EscribeLinea("^PW400")
            '    prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & objGuiaEnvio.cur_codBarras.Fields.Item(1).Value.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
            '    'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
            '    'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
            '    prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
            '    prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
            '    prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
            '    prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
            '    prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
            '    prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")
            '    prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")
            '    prn.EscribeLinea("^PQ1,0,1,Y")
            '    prn.EscribeLinea("^XZ")
            '    prn.EscribeLinea(cadena)
            '    objGuiaEnvio.cur_codBarras.MoveNext()
            '    I = I + 1
            'End While
            '''
            For Each row As DataRow In objGuiaEnvio.dt_cur_codBarras.Rows
                ObjCODIGOBARRA.CodigoBarra = row.Item(0)
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")
                prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & row.Item(1).ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
                'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
                'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
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
                i = i + 1
            Next
            prn.FinDoc()
        Catch ex As Exception
            MsgBox(ex.ToString)
            flag = False
        End Try
        Return flag
    End Function

    Public Function fnImprimirEtiquetasGUIA_II() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)

            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            '   ObjCODIGOBARRA.Cantidad = objGuiaEnvio.v_CANTIDAD_ETIQUETAS

            'Dim I As Int16 = 1
            Dim i As Int16
            If bRango Then
                i = 1
            Else
                i = correlativo_inicial
                'Mod 21/08/2009 
                If i = 0 Then i = 1
            End If

            If i <= 0 Then i = 1

            'ObjCODIGOBARRA.tipo = 3
            'ObjCODIGOBARRA.id = objGuiaEnvio.iIDGUIAS_ENVIO
            ObjCODIGOBARRA.tipo = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            ObjCODIGOBARRA.id = Me.DgvLista.CurrentRow.Cells("idfactura").Value
            ObjCODIGOBARRA.sp_etiqueta_generada()
            '25/08/2009 - Obtiene Fecha y Hora - Hlamas
            '04/09/2009 - Obtiene Fecha y Hora x datahelper 
            ObjVentaCargaContado.fnFechaRegistro(3, objGuiaEnvio.iIDGUIAS_ENVIO)
            sFecha = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(0)
            sHora = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(1)
            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha
            '
            '04/09/2009 - Cambio x datahelper
            '
            'While objGuiaEnvio.cur_codBarras.EOF = False And objGuiaEnvio.cur_codBarras.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = objGuiaEnvio.cur_codBarras.Fields.Item(0)
            '    prn.EscribeLinea("<STX><ESC>C0<ETX>")
            '    prn.EscribeLinea("<STX><ESC>k<ETX>")
            '    prn.EscribeLinea("<STX><SI>N60<ETX>")
            '    prn.EscribeLinea("<STX><SI>L197<ETX>")
            '    prn.EscribeLinea("<STX><SI>S20<ETX>")
            '    prn.EscribeLinea("<STX><SI>d0<ETX>")
            '    prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
            '    prn.EscribeLinea("<STX><SI>l8<ETX>")
            '    prn.EscribeLinea("<STX><SI>I3<ETX>")
            '    prn.EscribeLinea("<STX><SI>F20<ETX>")
            '    prn.EscribeLinea("<STX><SI>D0<ETX>")
            '    prn.EscribeLinea("<STX><SI>t0<ETX>")
            '    prn.EscribeLinea("<STX><SI>W394<ETX>")
            '    prn.EscribeLinea("<STX><SI>g1,567<ETX>")
            '    prn.EscribeLinea("<STX><ESC>P<ETX>")
            '    prn.EscribeLinea("<STX>E*;F*;<ETX>")
            '    prn.EscribeLinea("<STX>L1;<ETX>")
            '    prn.EscribeLinea("<STX>D0;<ETX>")
            '    prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h15;w15;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
            '    prn.EscribeLinea("<STX>D1;<ETX>")
            '    prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & objGuiaEnvio.cur_codBarras.Fields.Item(1).Value.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
            '    prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
            '    'prn.EscribeLinea("<STX>B3;o96,180;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
            '    prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
            '    prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
            '    prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
            '    prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
            '    prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
            '    prn.EscribeLinea("<STX>R<ETX>")
            '    prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
            '    prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")

            '    prn.EscribeLinea(cadena)
            '    objGuiaEnvio.cur_codBarras.MoveNext()
            '    I = I + 1
            'End While
            '''''''''''
            For Each row As DataRow In objGuiaEnvio.dt_cur_codBarras.Rows
                ObjCODIGOBARRA.CodigoBarra = row.Item(0)
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
                prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & row.Item(1).ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
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
                '
                i = i + 1
            Next
            '''''''''''
            prn.FinDoc()
        Catch ex As Exception
            MsgBox(ex.ToString)
            flag = False
        End Try
        Return flag
    End Function

    Public Function fnImprimirEtiquetasGUIA_III() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            '   ObjCODIGOBARRA.Cantidad = objGuiaEnvio.v_CANTIDAD_ETIQUETAS
            'Dim I As Int16 = 1
            Dim i As Int16
            If bRango Then
                i = 1
            Else
                i = correlativo_inicial
                'Mod 21/08/2009 
                If i = 0 Then i = 1
            End If

            If i <= 0 Then i = 1

            'ObjCODIGOBARRA.tipo = 3
            'ObjCODIGOBARRA.id = objGuiaEnvio.iIDGUIAS_ENVIO
            ObjCODIGOBARRA.tipo = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            ObjCODIGOBARRA.id = Me.DgvLista.CurrentRow.Cells("idfactura").Value
            ObjCODIGOBARRA.sp_etiqueta_generada()
            '26/08/2009 - Obtiene Fecha y Hora - Hlamas 
            '04/09/2009 - Obtiene Fecha y Hora x datahelper 
            ObjVentaCargaContado.fnFechaRegistro(3, objGuiaEnvio.iIDGUIAS_ENVIO)
            sFecha = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(0)
            sHora = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(1)
            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha
            '04/09/2009 - Cambio por datahelper 
            'While objGuiaEnvio.cur_codBarras.EOF = False And objGuiaEnvio.cur_codBarras.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = objGuiaEnvio.cur_codBarras.Fields.Item(0).Value
            '    prn.EscribeLinea("N")
            '    prn.EscribeLinea("N")
            '    '
            '    prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
            '    prn.EscribeLinea("A30,47,0,4,1,1,N,""" & Mid(ObjCODIGOBARRA.NroDOC, 5, 13) & " -" & objGuiaEnvio.cur_codBarras.Fields.Item(1).Value.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
            '    prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
            '    prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
            '    prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
            '    prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")
            '    prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")
            '    prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
            '    prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
            '    '
            '    prn.EscribeLinea("P1")
            '    prn.EscribeLinea("N")
            '    prn.EscribeLinea(cadena)
            '    objGuiaEnvio.cur_codBarras.MoveNext()
            '    I = I + 1
            'End While
            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String
            'hlamas 22-03-2016
            'strCargo = IIf(Me.ChkCargo.Checked, "CARGO", "")
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")

            For Each row As DataRow In objGuiaEnvio.dt_cur_codBarras.Rows
                ObjCODIGOBARRA.CodigoBarra = row.Item(0)
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                '
                prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                prn.EscribeLinea("A30,47,0,4,1,1,N,""" & Mid(ObjCODIGOBARRA.NroDOC, 5, 13) & " -" & row.Item(1).ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)

                'hlamas 26-08-2015
                'prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
                'prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("A30,163,0,1,1,1,N,""" & strFecha & """")
                prn.EscribeLinea("A271,163,0,1,1,1,N,""TEPSAC""")
                prn.EscribeLinea("A341,163,0,2,1,1,N,""" & strCargo & """")

                'hlamas 26-08-2015
                'prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")

                prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
                '
                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                '
                i = i + 1
            Next
            '
            prn.FinDoc()
        Catch ex As Exception
            MsgBox(ex.ToString)
            flag = False
        End Try
        Return flag
    End Function


#End Region



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
    Dim fnCONTROLDATOS As Boolean = False
    Dim strNroGuias_Remision As String = ""
    Dim v_Origen, v_destino As String
    Dim CORRELATIVO As String = "0"
    Dim ObjRptGuiaEnvio As New dtoRptGuiaEnvio()
    Public Function fnControlFecha_GuiaEnvio(ByVal dtFechaGuia As String) As Boolean
        Dim flag As Boolean = True
        Try
            'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnSQLLIQUIDACIONES() = True Then
                objGuiaEnvio.FEC_MAX_APERTURA_LIQ = ""
                objGuiaEnvio.FEC_MAX_CIERRE_LIQ = ""
            End If
            If CDate(dtFechaGuia) > CDate(dtoUSUARIOS.m_sFecha) Or CDate(dtFechaGuia) <= CDate("01/01/1996") Then
                flag = False
            End If
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function

#End Region
    '******************************
#Region "DETALLE VENTA"

    '==================CALCULOS[BULTO, ARTICULOS, M3(VOLUMETRICO)]=========================
    Dim iCOL As Integer = 0, iROW As Integer = 0
    Dim VBase As Boolean
    Private Sub GrdDetalleVenta_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDetalleVenta.CellEndEdit
        Try
            If iOpcion = 2 Then
                Return
            End If

            iROW = e.RowIndex
            iCOL = e.ColumnIndex

            'hlamas 03-08-2015
            If Me.CboProducto.SelectedValue = 0 And Me.ChkArticulos.Checked = False Then
                If e.RowIndex = 2 Then
                    If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) > 0 Then
                        GrdDetalleVenta(BCol_, BRow_).Value = 0
                    End If
                End If
            End If

            'valida si se ingresa peso o volumen sin tarifa
            If Me.CboTipo.SelectedValue = 1 And Me.ChkArticulos.Checked = False Then
                If e.RowIndex = 0 Or e.RowIndex = 1 Then
                    If Conversion.Val(GrdDetalleVenta(3, BRow_).Value) = 0 Then
                        If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) > 0 Then
                            GrdDetalleVenta(BCol_, BRow_).Value = 0
                        End If
                    End If
                End If
            End If

            Me.TipoCampos()
            If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1

            '*******************************************************************************
            If ChkM3.Checked = False And ChkArticulos.Checked = False Then
                If idUnidadAgencias <> -1 Then
                    If CboTipo.SelectedValue = 1 Then
                        fnTotalPago() '------------------------> Calculo[GRID BULTOS]PCE
                    Else
                        Total_Pagar(iROW, iCOL) '--------------> Calculo[GRID BULTOS]CREDITO
                    End If
                End If
                '---
                Me.FormatoMiles()
            End If

            '*******************************************************************************
            If ChkArticulos.Checked = True Then
                If idUnidadAgencias <> -1 Then
                    If CboTipo.SelectedValue = 1 Then
                        Me.CalculoArticulos() '---------------> Calculo[GRID ARTICULOS] PCE 
                    Else
                        Me.calculoGrdArticulos() '------------> Calculo[GRID ARTICULOS] CREDITO
                    End If
                End If
                '---
                Me.FormatoMiles()
            End If

            '*******************************************************************************
            If ChkM3.Checked = True Then '
                If idUnidadAgencias <> -1 Then
                    bInicio = False
                    Me.Calculo_M3() '--------------------------> Calculo M3 (VOLUMETRICO)
                End If
                '---
                Me.FormatoMiles()
            End If

            'hlamas 11-09-2015
            If CboTipo.SelectedValue = 1 Then
                If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                    TxtDescuento_TextChanged(Nothing, Nothing)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********CALCULO BULTOS PCE*****************************
    Dim SubTotal_Costo As Double = 0
    Public Function fnTotalPago() As Boolean
        Dim flag As Boolean = False
        Try
            If ChkM3.Checked = True Then
                Me.Calculo_M3()
                Return flag
            End If
            '**********Tomando los valores del campo [Peso/Volumen: Peso] y [Peso/Volumen: Volumen] y [Bulto: Sobre]********
            'Si se ingreso un descuento
            Dim PorcentajeDesc As Double = 0 'Val(TxtDescuento.Text.ToString) / 100

            Dim ValPeso_Peso As Double = 0, valPeso_Volum As Double = 0, ValNroSobres As Double = 0
            '*********************Formateando las Comas***********************************************
            If Val(GrdDetalleVenta("Peso/Volumen", 0).Value) = 0 Then
                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then
                    GrdDetalleVenta("Peso/Volumen", 0).Value = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 5
                    ValPeso_Peso = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 5
                ElseIf CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                    GrdDetalleVenta("Peso/Volumen", 0).Value = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 10
                    ValPeso_Peso = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 10
                Else
                    ValPeso_Peso = 0
                End If
            Else
                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then
                    GrdDetalleVenta("Peso/Volumen", 0).Value = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 5
                    ValPeso_Peso = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 5
                ElseIf CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                    GrdDetalleVenta("Peso/Volumen", 0).Value = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 10
                    ValPeso_Peso = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 10
                Else
                    ValPeso_Peso = GrdDetalleVenta("Peso/Volumen", 0).Value
                End If
            End If

            'hlamas 11-09-2015
            ValPeso_Peso = RedondearMas(ValPeso_Peso)
            GrdDetalleVenta("Peso/Volumen", 0).Value = ValPeso_Peso

            If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                If Val(GrdDetalleVenta("Peso/Volumen", 1).Value) = 0 Then
                    If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then
                        GrdDetalleVenta("Peso/Volumen", 1).Value = Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) * 10
                        valPeso_Volum = Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) * 10
                    Else
                        valPeso_Volum = 0
                    End If
                Else
                    If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then
                        GrdDetalleVenta("Peso/Volumen", 1).Value = Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) * 10
                        valPeso_Volum = Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) * 10
                    Else
                        valPeso_Volum = GrdDetalleVenta("Peso/Volumen", 1).Value
                    End If
                End If
            End If

            'hlamas 11-09-2015
            valPeso_Volum = RedondearMas(valPeso_Volum)
            GrdDetalleVenta("Peso/Volumen", 1).Value = valPeso_Volum

            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                If Val(GrdDetalleVenta("Bulto", 2).Value) = 0 Then ValNroSobres = 0 Else ValNroSobres = GrdDetalleVenta("Bulto", 2).Value
            End If
            '*****************************************************************************************
            Dim IGV As Double = dtoUSUARIOS.iIGV / 100

            '*************************************************************************
            '***********CALCULO [SUB_NETO]= [PESO/VOLUMEN] * [COSTO]******************             
            If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadPeso_ = "PESO" Then '----> Si tiene CONDICION TARIFA(Calculo Peso)               
                Me.fnCalcularCondicionTarifa(0, ValPeso_Peso, GrdDetalleVenta("Costo", 0).Value) '-----------------> [Sub Neto (Peso)]
            Else
                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX And Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                    GrdDetalleVenta("Sub Neto", 0).Value = IIf(GrdDetalleVenta("Bulto", 0).Value * Monto_25 = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 0).Value * Monto_25), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
                ElseIf CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 And Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                    GrdDetalleVenta("Sub Neto", 0).Value = IIf(GrdDetalleVenta("Bulto", 0).Value * Monto_40 = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 0).Value * Monto_40), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
                Else
                    GrdDetalleVenta("Sub Neto", 0).Value = IIf(ValPeso_Peso * tarifa_Peso = 0, "0.00", _
                                         FormatNumber(Format((ValPeso_Peso * tarifa_Peso), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
                End If
            End If
            '---
            If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadVol_ = "VOL" Then '----> Si tiene CONDICION TARIFA(Calculo volumen)   
                    Me.fnCalcularCondicionTarifa(1, valPeso_Volum, GrdDetalleVenta("Costo", 1).Value) '-----------------> [Sub Neto (Volumen)]
                Else
                    If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX And Val(GrdDetalleVenta("Bulto", 1).Value) > 0 Then
                        'GrdDetalleVenta("Sub Neto", 1).Value = IIf(GrdDetalleVenta("Bulto", 1).Value * tarifa_Volumen = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 1).Value * tarifa_Volumen), "###,###,###.00"), 2)) '-> [Sub Neto (Volumen)]
                        GrdDetalleVenta("Sub Neto", 1).Value = IIf(GrdDetalleVenta("Bulto", 1).Value * Monto_40 = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 1).Value * Monto_40), "###,###,###.00"), 2)) '-> [Sub Neto (Volumen)]
                    Else
                        GrdDetalleVenta("Sub Neto", 1).Value = IIf(valPeso_Volum * tarifa_Volumen = 0, "0.00", _
                                                            FormatNumber(Format((valPeso_Volum * tarifa_Volumen), "###,###,###.00"), 2)) '-> [Sub Neto (Volumen)]
                    End If
                End If
            End If

            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                GrdDetalleVenta("Sub Neto", 2).Value = IIf(tarifa_Sobre * ValNroSobres = 0, "0.00", _
                                     FormatNumber(Format((tarifa_Sobre * ValNroSobres), "###,###,###.00"), 2))  '----> [Sub Neto (Sobre)]  
            End If

            '*************************************************************************

            If Monto_Base > 0 Then
                ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
            End If

            '**************************************************************************           
            If objGuiaEnvio.CondicionTarifa_ = False Then
                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then
                    If Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                        SubTotal_Costo = Monto_Base + ((GrdDetalleVenta("Bulto", 0).Value * Monto_25) / (1 + IGV))
                    End If
                    'If GrdDetalleVenta("Bulto", 1).Value <> "" Then
                    'SubTotal_Costo = SubTotal_Costo + ((GrdDetalleVenta("Bulto", 1).Value * Monto_40) / (1 + IGV))
                    'End If
                    SubTotal_Costo = SubTotal_Costo + (tarifa_Sobre * ValNroSobres)
                ElseIf CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                    If Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                        SubTotal_Costo = Monto_Base + ((GrdDetalleVenta("Bulto", 0).Value * Monto_40) / (1 + IGV))
                    End If
                    'If GrdDetalleVenta("Bulto", 1).Value <> "" Then
                    'SubTotal_Costo = SubTotal_Costo + ((GrdDetalleVenta("Bulto", 1).Value * Monto_40) / (1 + IGV))
                    'End If
                    SubTotal_Costo = SubTotal_Costo + (tarifa_Sobre * ValNroSobres)
                Else
                    If ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen > 0 Then
                        If iControlMonto_Base = 1 Then
                            SubTotal_Costo = (Monto_Base + ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen + tarifa_Sobre * ValNroSobres) '* (1 - PorcentajeDesc)               
                        Else
                            SubTotal_Costo = (ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen + tarifa_Sobre * ValNroSobres) '* (1 - PorcentajeDesc)
                        End If
                    Else
                        SubTotal_Costo = (ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen + tarifa_Sobre * ValNroSobres) '* (1 - PorcentajeDesc)
                    End If
                End If
            Else
                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then '-->Tepsa box
                    If Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                        SubTotal_Costo = Monto_Base + ((GrdDetalleVenta("Bulto", 0).Value * Monto_25) / (1 + IGV))
                    End If
                    'If GrdDetalleVenta("Bulto", 1).Value <> "" Then
                    'SubTotal_Costo = SubTotal_Costo + ((GrdDetalleVenta("Bulto", 1).Value * Monto_40) / (1 + IGV))
                    'End If
                    SubTotal_Costo = SubTotal_Costo + (tarifa_Sobre * ValNroSobres)
                ElseIf CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then '-->Tepsa box
                    If Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                        SubTotal_Costo = Monto_Base + ((GrdDetalleVenta("Bulto", 0).Value * Monto_40) / (1 + IGV))
                    End If
                    'If GrdDetalleVenta("Bulto", 1).Value <> "" Then
                    'SubTotal_Costo = SubTotal_Costo + ((GrdDetalleVenta("Bulto", 1).Value * Monto_40) / (1 + IGV))
                    'End If
                    SubTotal_Costo = SubTotal_Costo + (tarifa_Sobre * ValNroSobres)
                Else
                    SubTotal_Costo += tarifa_Sobre * ValNroSobres
                    If Monto_Base > 0 Then
                        SubTotal_Costo = (Monto_Base + SubTotal_Costo)
                    End If
            End If
            End If

            '**************************************************************************
            TxtSubTotal.Text = SubTotal_Costo
            TxtImpuesto.Text = IGV * SubTotal_Costo
            TxtTotal.Text = SubTotal_Costo + IGV * SubTotal_Costo

            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                If bTarifarioGeneral And bContado Then
                    TxtSubTotal.Text = Format(SubTotal_Costo / (1 + IGV), "###,###,###.0000")
                    TxtImpuesto.Text = IGV * SubTotal_Costo
                    TxtTotal.Text = SubTotal_Costo
                End If
            End If

            precio_carga_asegurada()
            SubTotal_Costo = TxtSubTotal.Text
            '********************************ENTREGA A DOMICILIO***********************************************
            dblMontoEntregaDomicilio = GestionaMontoTarifaDomicilio(dtTarifaServicio, GrdDetalleVenta)
            SubTotal_Costo = SubTotal_Costo + dblMontoEntregaDomicilio / (1 + IGV)
            '***************************************************************************************************

            '********************************DEVOLUCION DE CARGO************************************************
            dblMontoDC = ObtieneMontoDevolucionCargo()
            SubTotal_Costo = SubTotal_Costo + dblMontoDC / (1 + IGV)
            '********************************DEVOLUCION DE CARGO************************************************

            Dim SUB_TOTAL_GENERAL As Double = 0
            '*******************************[PAGO CON DESCUENTO]***********************************************
            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                    'hlamas 11-09-2015
                    'SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                    SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                Else
                    If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                        SUB_TOTAL_GENERAL = 0
                    End If
                End If
            Else
                SUB_TOTAL_GENERAL = SubTotal_Costo + IGV * SubTotal_Costo
            End If
            '**************************************************************************************************

            '********************************ENTREGA A DOMICILIO***********************************************
            'dblMontoEntregaDomicilio = GestionaMontoTarifaDomicilio()
            'SUB_TOTAL_GENERAL = SUB_TOTAL_GENERAL + dblMontoEntregaDomicilio
            '***************************************************************************************************

            If CboTipo.SelectedValue = 1 Then
                If CboProducto.SelectedValue = 7 And (SUB_TOTAL_GENERAL / IIf(Val(PorcentajeDesc) = 0, 1, PorcentajeDesc) < MontoMinimoPyme) Then
                    Me.CondicionMontoMinimoPYME()
                ElseIf (SUB_TOTAL_GENERAL / IIf(Val(PorcentajeDesc) = 0, 1, PorcentajeDesc) < monto_minimo_PCE) And CboProducto.SelectedValue <> 7 Then
                    TxtDescuento.Enabled = False
                    'Me.TxtDescuento.BackColor = System.Drawing.SystemColors.Control
                    Me.CondicionMontoMinimoPCE()
                Else
                    Me.TxtDescuento.Enabled = True
                    'Me.TxtDescuento.BackColor = Color.White

                    Me.TxtSubTotal.Text = IIf(SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                    Me.TxtImpuesto.Text = IIf(IGV * SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                    Me.TxtTotal.Text = IIf(SUB_TOTAL_GENERAL = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL, "###,###,###.00"), 2))
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return False
        End Try
        Return flag
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

            TxtSubTotal.Text = Replace(TxtSubTotal.Text, ",", "")
            TxtImpuesto.Text = Replace(TxtImpuesto.Text, ",", "")
            TxtTotal.Text = Replace(TxtTotal.Text, ",", "")
            TxtSubTotal.Text = Val(TxtSubTotal.Text) + cdblsub_total
            TxtImpuesto.Text = Val(TxtImpuesto.Text) + cdblmonto_IGV
            TxtTotal.Text = Val(TxtTotal.Text) + cdblcosto_total
        End If
    End Sub

    '********CALCULO BULTOS CREDITO*************************
    Dim fArticulo As Boolean = False
    Dim Monto_Base As Double = 0
    Dim lb_datos_editados As Boolean = False
    Private Function Total_Pagar(ByVal iROW As Integer, ByVal iCOL As Integer) As Boolean
        Try

            Dim ValPeso_Peso As Double = 0, valPeso_Volum As Double = 0, ValNroSobres As Double = 0, Base As Double = 0
            '*********************Formateando las Comas***********************************************
            If Val(GrdDetalleVenta("Peso/Volumen", 0).Value) = 0 Then ValPeso_Peso = 0 Else ValPeso_Peso = GrdDetalleVenta("Peso/Volumen", 0).Value
            'hlamas 11-09-2015
            ValPeso_Peso = RedondearMas(ValPeso_Peso)
            GrdDetalleVenta("Peso/Volumen", 0).Value = ValPeso_Peso

            If Val(GrdDetalleVenta("Peso/Volumen", 1).Value) = 0 Then valPeso_Volum = 0 Else valPeso_Volum = GrdDetalleVenta("Peso/Volumen", 1).Value
            'hlamas 11-09-2015
            valPeso_Volum = RedondearMas(valPeso_Volum)
            GrdDetalleVenta("Peso/Volumen", 1).Value = valPeso_Volum

            If Val(GrdDetalleVenta("Bulto", 2).Value) = 0 Then ValNroSobres = 0 Else ValNroSobres = GrdDetalleVenta("Bulto", 2).Value
            If Val(GrdDetalleVenta("Sub Neto", 3).Value) = 0 Then Base = 0 Else Base = GrdDetalleVenta("Sub Neto", 3).Value
            '*****************************************************************************************
            'hlamas 26-08/2014 redondeo peso para eckerd
            If iID_Persona = ID_PERSONA_ECKERD Then
                If ValPeso_Peso > 0 And ValPeso_Peso < 1 Then
                    ValPeso_Peso = 1
                    GrdDetalleVenta("Peso/Volumen", 0).Value = ValPeso_Peso
                End If
                If valPeso_Volum > 0 And valPeso_Volum < 1 Then
                    valPeso_Volum = 1
                    GrdDetalleVenta("Peso/Volumen", 1).Value = valPeso_Volum
                End If
            End If

            '*************************************************************************
            '***********CALCULO [SUB_NETO]= [PESO/VOLUMEN] * [COSTO]****************** 
            'If objGuiaEnvio.CondicionTarifa_ Then '----------------->  === CONDICION TARIFA              
            '    Me.fnCalcularCondicionTarifa(iROW, ValPeso_Peso, GrdDetalleVenta("Costo", 0).Value) '-----------------> [Sub Neto (Peso)]
            'Else
            '    GrdDetalleVenta("Sub Neto", 0).Value = IIf(ValPeso_Peso * tarifa_Peso = 0, "0.00", _
            '                         FormatNumber(Format((ValPeso_Peso * tarifa_Peso), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
            'End If
            'GrdDetalleVenta("Sub Neto", 1).Value = IIf(valPeso_Volum * tarifa_Volumen = 0, "0.00", _
            '                         FormatNumber(Format((valPeso_Volum * tarifa_Volumen), "###,###,###.00"), 2)) '---> [Sub Neto (Volumen)]

            Dim subNeto As Double = 0.0
            Dim colPeso As Integer = 0
            Dim colVol As Integer = 1
            Dim pesoMinimo As Double = objGuiaEnvio.iPeso_Maximo
            Dim fleteMinimo As Double = objGuiaEnvio.iPrecio_cond_Peso
            Dim subNetoPeso As Double = GrdDetalleVenta("Sub Neto", colPeso).Value
            Dim subNetoVolumen As Double = GrdDetalleVenta("Sub Neto", colVol).Value

            If objGuiaEnvio.CondicionTarifa_ Then '-----------------> === CONDICION TARIFA 
                If (CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER) Then
                    If (iROW = colPeso) Then
                        If (ValPeso_Peso <= pesoMinimo) Then
                            Me.fnCalcularCondicionTarifa(iROW, ValPeso_Peso, GrdDetalleVenta("Costo", colPeso).Value)

                            If (ValPeso_Peso = 0) Then '-->Aplica la refla del flete minomo al volumen
                                Me.fnCalcularCondicionTarifa(colVol, valPeso_Volum, GrdDetalleVenta("Costo", colVol).Value)
                                'ElseIf (valPeso_Volum < pesoMinimo) Then '-->No aplica la regla fete mimimo al volumne
                                'subNetoPeso = valPeso_Volum * tarifa_Volumen
                                'GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                            Else 'hlamas 09-05-2015
                                If (valPeso_Volum < pesoMinimo) Then
                                    subNetoPeso = valPeso_Volum * tarifa_Volumen
                                    GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                                Else
                                    subNetoPeso = valPeso_Volum * tarifa_Volumen
                                    GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                                End If
                            End If

                        ElseIf (ValPeso_Peso > pesoMinimo) Then
                            Me.fnCalcularCondicionTarifa(iROW, ValPeso_Peso, GrdDetalleVenta("Costo", colPeso).Value)
                            If (valPeso_Volum < pesoMinimo) Then
                                subNetoPeso = valPeso_Volum * tarifa_Volumen
                                GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                            Else 'hlamas 09-05-2015
                                subNetoPeso = valPeso_Volum * tarifa_Volumen
                                GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                            End If
                        ElseIf (valPeso_Volum <= pesoMinimo) Then
                            Me.fnCalcularCondicionTarifa(iROW, ValPeso_Peso, GrdDetalleVenta("Costo", colVol).Value)
                        ElseIf (valPeso_Volum > pesoMinimo) Then
                            subNetoPeso = valPeso_Volum * tarifa_Volumen
                            GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                        End If
                    ElseIf (iROW = colVol) Then
                        If (ValPeso_Peso = 0) Then
                            Me.fnCalcularCondicionTarifa(iROW, valPeso_Volum, GrdDetalleVenta("Costo", colVol).Value)

                        ElseIf (ValPeso_Peso <= pesoMinimo) Then
                            Me.fnCalcularCondicionTarifa(iROW, valPeso_Volum, GrdDetalleVenta("Costo", colVol).Value)

                            subNetoPeso = valPeso_Volum * tarifa_Volumen
                            GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                        ElseIf (ValPeso_Peso > pesoMinimo) Then
                            subNetoPeso = valPeso_Volum * tarifa_Volumen
                            GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                        ElseIf (valPeso_Volum <= pesoMinimo) Then
                            Me.fnCalcularCondicionTarifa(iROW, valPeso_Volum, GrdDetalleVenta("Costo", colVol).Value)
                        ElseIf (valPeso_Volum > pesoMinimo) Then
                            subNetoPeso = valPeso_Volum * tarifa_Volumen
                            GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                        End If
                    End If
                Else
                    Me.fnCalcularCondicionTarifa(iROW, ValPeso_Peso, GrdDetalleVenta("Costo", 0).Value) '-----------------> [Sub Neto (Peso)]
                    Me.fnCalcularCondicionTarifa(iROW, valPeso_Volum, GrdDetalleVenta("Costo", 1).Value) '-----------------> [Sub Neto (Volumen)]
                End If
            Else
                GrdDetalleVenta("Sub Neto", 0).Value = IIf(ValPeso_Peso * tarifa_Peso = 0, "0.00", _
                                     FormatNumber(Format((ValPeso_Peso * tarifa_Peso), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 

                GrdDetalleVenta("Sub Neto", 1).Value = IIf(valPeso_Volum * tarifa_Volumen = 0, "0.00", _
                                    FormatNumber(Format((valPeso_Volum * tarifa_Volumen), "###,###,###.00"), 2)) '---> [Sub Neto (Volumen)]
            End If

            GrdDetalleVenta("Sub Neto", 2).Value = IIf(tarifa_Sobre * ValNroSobres = 0, "0.00", _
                                     FormatNumber(Format((tarifa_Sobre * ValNroSobres), "###,###,###.00"), 2))  '-----> [Sub Neto (Sobre)]    
            '*************************************************************************

            Dim Sum_SubTotal As Double = 0
            'hlamas 17-12-2013
            If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER Then
                For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 2
                    Dim val As Double = IIf(GrdDetalleVenta("Sub Neto", i).Value = 0, 0, GrdDetalleVenta("Sub Neto", i).Value)
                    Sum_SubTotal += val
                Next
            Else
                Sum_SubTotal += ((ValPeso_Peso * tarifa_Peso) + (valPeso_Volum * tarifa_Volumen) + (tarifa_Sobre * ValNroSobres))
            End If

            If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER Then '-->Tepsa Courier
                '-->No incluye IGV
                If Sum_SubTotal > 0 AndAlso Monto_Base > 0 Then
                    If ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen > 0 Then
                        Sum_SubTotal += Base
                    End If
                End If
                Sum_SubTotal = Sum_SubTotal / (1 + IGV)
            Else
                If Sum_SubTotal > 0 AndAlso Monto_Base > 0 Then
                    If ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen > 0 Then
                        Sum_SubTotal += Base
                    End If
                End If
            End If

            'If Sum_SubTotal > 0 AndAlso Monto_Base > 0 Then
            '    If ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen > 0 Then 'error de neison
            '        Sum_SubTotal += Base
            '    End If
            'End If

            '****************CALCULO**************************
            TxtSubTotal.Text = IIf(Sum_SubTotal = 0, "0.00", Format(Sum_SubTotal, "####,###,###.00"))
            TxtImpuesto.Text = IIf((IGV * Sum_SubTotal) = 0, "0.00", Format((IGV) * (Sum_SubTotal), "####,###,###.00"))
            TxtTotal.Text = IIf((1 + IGV) * (Sum_SubTotal) = 0, "0.00", Format((1 + IGV) * (Sum_SubTotal), "####,###,###.00"))
            '*************************************************

            'hlamas 17-12-2013 se corrige redondeo de ventas credito
            If CboProducto.SelectedValue = ID_PRODUCTO_CARGA_EXPRESA Then
                Dim dblTotal As Double = Me.TxtTotal.Text
                If dblTotal > 0 Then
                    Dim dblSubtotal As Double = dblTotal / (1 + IGV)
                    TxtSubTotal.Text = Format(dblSubtotal, "####,###,###.00")
                    TxtImpuesto.Text = Format(dblSubtotal * IGV, "####,###,###.00")
                End If
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return False
        End Try
        Return False
    End Function

    '********ARTICULOS**************************************
    Private Sub ChkArticulos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkArticulos.CheckedChanged
        Try
            If iOpcion = 2 Then
                RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
                ChkArticulos.Checked = Not ChkArticulos.Checked
                AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
                Return
            End If

            Me.Cursor = Cursors.AppStarting
            If Not ChkArticulos.Checked Then
                TipoGrid_ = FormatoGrid.BULTO : LbldetalleVenta.Text = "Detalle Venta" : Me.DiseñaGrdDetalleVenta()
                FormatoGrdDetalleVenta()
                Me.tarifarioEnMemoria()

                TxtSubTotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"

                '****************************
                ChkSobres.Visible = False
                txtCantidadSobres.Visible = False
                txtTotalSobre.Visible = False
                LblMontoBase.Visible = False
                TxtMontoBase.Visible = False
                RemoveHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
                RemoveHandler ChkSobres.CheckedChanged, AddressOf ChkSobres_CheckedChanged
                txtCantidadSobres.Text = ""
                txtTotalSobre.Text = "0.00"
                ChkSobres.Checked = False
                Me.CondicionMontoMinimoPCE()
                Me.Cursor = Cursors.Default
                AddHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
                AddHandler ChkSobres.CheckedChanged, AddressOf ChkSobres_CheckedChanged
                Return
            End If

            Me.TxtDescuento.Enabled = False
            'Me.TxtDescuento.BackColor = System.Drawing.SystemColors.Control

            If ChkM3.Checked = True Then ChkM3.Checked = False
            TipoGrid_ = FormatoGrid.ARTICULOS : LbldetalleVenta.Text = "Articulos"
            Me.DiseñaGrdDetalleVenta()

            If CboTipo.SelectedValue = 1 Then
                If DtArticulos.Rows.Count > 0 Then 'ObjVentaCargaContado.dt_cur_Articulos.Rows.Count > 0 Then
                    ChkSobres.Checked = False
                    fArticulo = True
                    '*********cargando lo datos de articulos**********
                    '*********cargando lo datos de articulos**********
                    For Each fila As DataRow In DtArticulos.Rows
                        Dim row0 As String() = {fila.Item(1), FormatNumber(fila.Item(2).ToString, 2), "", "0.00", "0.00", fila.Item(0).ToString()}
                        GrdDetalleVenta.Rows().Add(row0)
                    Next

                    'For Each fila As DataRow In ObjVentaCargaContado.dt_cur_Articulos.Rows
                    'Dim row0 As String() = {fila.Item(1), FormatNumber(fila.Item(2).ToString, 2), "", "0.00", "0.00", fila.Item(0).ToString()}
                    'GrdDetalleVenta.Rows().Add(row0)
                    'Next
                End If
            ElseIf CboTipo.SelectedValue = 2 Then
                If DtArticulos.Rows.Count > 0 Then
                    For Each fila As DataRow In DtArticulos.Rows
                        Dim row0 As String() = {fila.Item(1).ToString, fila.Item(2).ToString, "", "0.00", "0.00", "0.00", fila.Item(0).ToString()}
                        GrdDetalleVenta.Rows().Add(row0)
                        If fila.Item(0).ToString() = 211 Then
                            GrdDetalleVenta.Columns.Item("M3").Visible = True
                        End If
                    Next
                End If
            End If

            TxtSubTotal.Text = "0.00"
            TxtImpuesto.Text = "0.00"
            TxtTotal.Text = "0.00"

            Update()
            'TxtMontoBase.Text = FormatNumber(IIf(Val(Monto_Base) = 0, 0, Monto_Base), 2)
            If iBaseArticulo = 1 Then
                TxtMontoBase.Text = FormatNumber(IIf(Val(Monto_Base) = 0, 0, Monto_Base), 2)
            Else
                TxtMontoBase.Text = "0.00"
            End If
            ChkSobres.Visible = True
            ChkSobres.Enabled = True

            txtCantidadSobres.Visible = True : txtCantidadSobres.Enabled = False
            txtTotalSobre.Visible = True : txtTotalSobre.ReadOnly = True
            LblMontoBase.Visible = True
            TxtMontoBase.Visible = True : TxtMontoBase.ReadOnly = True
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********CALCULO ARTICULOS (PCE)************************
    Sub CalculoArticulos()
        Try
            If iCOL = 2 Or iCOL = 3 Then '2 = Columna cantidad
                Dim IGV As Double = dtoUSUARIOS.iIGV / 100
                Dim SubTotal_Costo As Double = 0

                objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = 0
                Dim Total As Double = 0
                Dim ii1 As Integer = 0

                Dim Precio_ As Double = 0, Cantidad_ As Double = 0
                If Conversion.Val(GrdDetalleVenta.Rows(iROW).Cells("Precio").Value) = 0 Then Precio_ = 0 Else Precio_ = GrdDetalleVenta.Rows(iROW).Cells("Precio").Value
                If Conversion.Val(GrdDetalleVenta.Rows(iROW).Cells("Cantidad").Value) = 0 Then Cantidad_ = 0 Else Cantidad_ = GrdDetalleVenta.Rows(iROW).Cells("Cantidad").Value


                GrdDetalleVenta.Rows(iROW).Cells("P.Total").Value = IIf(Precio_ * Cantidad_ = 0, "0.00", Format(Precio_ * Cantidad_, "###,###,####.00"))

                Dim Valor As Double
                For ii1 = 0 To GrdDetalleVenta.Rows().Count() - 1
                    If Val(GrdDetalleVenta.Rows(ii1).Cells("P.Total").Value) = 0 Then
                        Valor = 0
                    Else
                        Valor = GrdDetalleVenta.Rows(ii1).Cells("P.Total").Value
                    End If
                    '---------------------
                    Total = Total + Valor
                    '---------------------
                Next
                '------------------------------
                Dim Monto_Sobre As Double = 0
                If ChkSobres.Checked = True Then
                    Monto_Sobre = tarifa_Sobre * Conversion.Val(txtCantidadSobres.Text)
                    txtTotalSobre.Visible = True
                    txtTotalSobre.Text = Format(Monto_Sobre, "####,###,###.00")
                End If
                '------------------------------

                'SubTotal_Costo = Monto_Base + Total + Monto_Sobre
                '18/11/2011
                If iBaseArticulo = 1 Then
                    SubTotal_Costo = Monto_Base + Total + Monto_Sobre
                Else
                    SubTotal_Costo = Total + Monto_Sobre
                End If


                If Total = 0 Then
                    SubTotal_Costo = Monto_Sobre
                End If

                Dim SUB_TOTAL_GENERAL As Double = 0
                If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                    'hlamas 11-09-2015
                    'SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal_Costo * (1 - Val("") / 100), "###,###,###.000")
                    SUB_TOTAL_GENERAL = Format(SubTotal_Costo * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                Else
                    If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                        SUB_TOTAL_GENERAL = 0
                    End If
                End If

                '*****************Calculo Operacion*********************************************
                TxtSubTotal.Text = IIf(SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                TxtImpuesto.Text = IIf(IGV * SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                TxtTotal.Text = IIf(SUB_TOTAL_GENERAL = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL, "###,###,###.00"), 2))
                '*******************************************************************************                          
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '********CALCULO ARTICULOS Y SOBRES (CREDITO)***********
    Sub calculoGrdArticulos()
        Try
            objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = 0
            Dim Total As Double = 0
            Dim ii1 As Integer = 0

            Dim Cant_ As Double = 0
            If Val(GrdDetalleVenta.Rows(iROW).Cells("Cantidad").Value) = 0 Then
                Cant_ = 0
            Else
                Cant_ = GrdDetalleVenta.Rows(iROW).Cells("Cantidad").Value
            End If

            If GrdDetalleVenta.Rows(iROW).Cells("IDARTICULO").Value = 211 Then
                GrdDetalleVenta.Rows(iROW).Cells("P.Total").Value = Format(GrdDetalleVenta.Rows(iROW).Cells("Precio").Value * GrdDetalleVenta.Rows(iROW).Cells("M3").Value, "###,###,###.00")
                GrdDetalleVenta.Rows(iROW).Cells("Cantidad").Value = Format(Val(Replace(GrdDetalleVenta.Rows(iROW).Cells("Cantidad").Value.ToString, ",", "")), "###,###,###")
            Else
                GrdDetalleVenta.Rows(iROW).Cells("P.Total").Value = IIf(GrdDetalleVenta.Rows(iROW).Cells("Precio").Value * Cant_ = 0, "0.00", _
                                                                        Format(GrdDetalleVenta.Rows(iROW).Cells("Precio").Value * Cant_, "###,###,###.00"))
                GrdDetalleVenta.Rows(iROW).Cells("M3").Value = "0.00"
            End If

            For ii1 = 0 To GrdDetalleVenta.Rows().Count() - 1
                Total = Total + CDbl(GrdDetalleVenta.Rows(ii1).Cells("P.Total").Value.ToString)
                objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + Cant_
            Next

            Dim Monto_Sobre As Double = 0

            If ChkSobres.Checked = True Then
                Monto_Sobre = (tarifa_Sobre * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text))
                txtTotalSobre.Visible = True
                txtTotalSobre.Text = IIf(Monto_Sobre = 0, "0.00", Format(Monto_Sobre, "#,###,###,###.00"))
            End If
            '************
            If Total = 0 Then VBase = False Else _
                            VBase = True

            '***         
            Total = Total + tarifa_Sobre * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
            If VBase Then Total += Monto_Base : VBase = False
            '***

            'hlamas 11-03-2019
            TxtSubTotal.Text = IIf(Total = 0, "0.00", FormatNumber(Format(Total / (1 + IGV), "###,###,###.00"), 2))
            TxtImpuesto.Text = IIf(Total * IGV = 0, "0.00", FormatNumber(Format(IGV * Total / (1 + IGV), "###,###,###.00"), 2))
            TxtTotal.Text = IIf(Total * (1 + IGV) = 0, "0.00", FormatNumber(Format(Total, "###,###,###.00"), 2))
            '********************TOTALES********************************************************************
            'TxtSubTotal.Text = IIf(Total = 0, "0.00", Format(Total, "##,####,###.00"))
            'TxtImpuesto.Text = IIf(Total * IGV = 0, "0.00", Format(Total * IGV, "##,####,###.00"))
            'TxtTotal.Text = IIf(Total * (1 + IGV) = 0, "0.00", Format(Total * (1 + IGV), "##,####,####.00"))
            '***********************************************************************************************
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '********CALCULO M3 (PCE)*******************************
    Private Sub ChkM3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkM3.CheckedChanged
        Try
            If iOpcion = 2 Then
                RemoveHandler ChkM3.CheckedChanged, AddressOf ChkM3_CheckedChanged
                ChkM3.Checked = ChkM3.Checked
                AddHandler ChkM3.CheckedChanged, AddressOf ChkM3_CheckedChanged
                Return
            End If

            If ChkM3.Checked = True Then
                bInicio = True
                If ChkArticulos.Checked = True Then ChkArticulos.Checked = False
                RemoveItemsCargAseg() '------------> Limpiando items [carga asegurada]
                TipoGrid_ = FormatoGrid.VOLUMETRICO '--------> Grid Volumetrico
                Me.DiseñaGrdDetalleVenta() '-------> Diseña GridDetalleVenta
                FormatoGrdDetalleVenta() '---------> Formato al grid
                GrdDetalleVenta(6, 0).Value = Format(tarifa_Peso, "0.00")
                TxtMontoBase.Text = FormatNumber(IIf(Val(tarifa_Sobre) = 0, 0, tarifa_Sobre), 2)

                ChkSobres.Visible = True
                ChkSobres.Enabled = True
                txtCantidadSobres.Visible = True
                txtCantidadSobres.Enabled = False
                txtTotalSobre.Visible = True
                LblMontoBase.Visible = True
                TxtMontoBase.Visible = True
                GrpDescuento.Enabled = True
                Me.CondicionMontoMinimoPCE()

                '--NuevaCondicion MontoMinimo 04022012
                If CboProducto.SelectedValue = 7 Then
                    Me.CondicionMontoMinimoPYME()
                End If
            Else
                TipoGrid_ = FormatoGrid.BULTO '--------------> Grid Bultos
                Me.DiseñaGrdDetalleVenta() '-------> Diseña GridDetalleVenta
                FormatoGrdDetalleVenta() '---------> Formato al grid
                Me.tarifarioEnMemoria()
                RemoveItemsCargAseg() '--->Limpiando items [carga asegurada]
                TxtSubTotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"

                ChkSobres.Visible = False
                txtCantidadSobres.Visible = False
                txtTotalSobre.Visible = False
                LblMontoBase.Visible = False
                TxtMontoBase.Visible = False
                GrpDescuento.Enabled = True
                Me.CondicionMontoMinimoPCE()

                '--NuevaCondicion MontoMinimo 04022012
                If CboProducto.SelectedValue = 7 Then
                    Me.CondicionMontoMinimoPYME()
                End If
            End If
            'hlamas 28-11-2013
            GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, CboCiudadOrigen.SelectedValue, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Calculo_M3()

        ' Modificado por Diego Zegarra T. 08/07/2013
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
            'hlamas 11-09-2015
            'GrdDetalleVenta("Peso Kg", iROW).Value = IIf((Altura * Ancho * Largo) * dFactor = 0, "0.00", _
            '                                            FormatNumber(Format((Altura * Ancho * Largo) * dFactor, "###,###,###.00"), 2))
            Dim dblPeso As Double = Altura * Ancho * Largo * dFactor
            GrdDetalleVenta("Peso Kg", iROW).Value = IIf((Altura * Ancho * Largo) * dFactor = 0, "0.00", FormatNumber(Format(RedondearMas(dblPeso), "###,###,###.00"), 2))

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
                'hlamas 28-11-2013
                If IsNumeric(GrdDetalleVenta("tipo", i).Value) Then
                    If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Valor_ = 0 _
                                        Else Valor_ = GrdDetalleVenta("Sub Neto", i).Value
                    SumSubNeto_ += Valor_
                End If
            Next
            '**********************
            If SumSubNeto_ > 0 Then
                If Monto_Base > 0 Then
                    ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
                End If

                ObjVentaCargaContado.v_MONTO_BASE = 0
                SumSubNeto_ = SumSubNeto_ + Monto_Base
            End If
            ''**********************

            Dim Monto_Sobre As Double = 0
            If ChkSobres.Checked = True Then
                Monto_Sobre = tarifa_Sobre * Conversion.Val(txtCantidadSobres.Text)
                txtTotalSobre.Visible = True
                txtTotalSobre.Text = Format(Monto_Sobre, "####,###,###.00")
            End If

            '****Añade [Sobres] al la sumaSubNeto*******************************************
            Dim MontoSobre_ As Double = 0
            If (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then MontoSobre_ = _
                                                               (txtCantidadSobres.Text * tarifa_Sobre) ' + Monto_Base


            '****Validando el Monto Sobre Valor 0*******************************************
            If (txtTotalSobre.Text = "") Then
                txtTotalSobre.Text = 0.0
            End If


            'hlamas 28-11-2013
            '********************************ENTREGA A DOMICILIO***********************************************
            dblMontoEntregaDomicilio = GestionaMontoTarifaDomicilio(dtTarifaServicio, GrdDetalleVenta, TipoGrid_)
            SumSubNeto_ = SumSubNeto_ + dblMontoEntregaDomicilio
            '********************************CARGA SEGURO*******************************************************************

            '********************************DEVOLUCION DE CARGO************************************************
            dblMontoDC = ObtieneMontoDevolucionCargo()
            SumSubNeto_ = SumSubNeto_ + dblMontoDC
            '********************************DEVOLUCION DE CARGO************************************************

            'precio_carga_asegurada()
            'SumSubNeto_ = TxtSubtotal.Text
            Dim intFila As Integer = BuscarItemVenta("SEGURO", GrdDetalleVenta)
            If intFila > 0 Then
                SumSubNeto_ += Val(GrdDetalleVenta("sub neto", intFila).Value)
            End If

            '*******************************************************************************
            'hlamas 11-09-2015
            'SumSubNeto_ = fnTECHO(Format(SumSubNeto_ + MontoSobre_, "0.000"))
            SumSubNeto_ = Format(SumSubNeto_ + MontoSobre_, "0.000")
            '*******************************************
            Dim Total_ As Double = SumSubNeto_
            Dim Subtotal_ As Double = Total_ / (1 + IGV)
            Dim Impuesto_ As Double = Subtotal_ * IGV

            'Dim Total_ As Double
            'Dim Subtotal_ As Double
            'Dim Impuesto_ As Double

            'Subtotal_ = SumSubNeto_ + txtTotalSobre.Text + CType(txtMontoBase.Text, Double)
            'Impuesto_ = Subtotal_ * IGV
            'Total_ = Impuesto_ + Subtotal_


            '*******************************************
            If CboProducto.SelectedValue = 7 And Total_ <= MontoMinimoPyme Then '04022012
                Me.CondicionMontoMinimoPYME()
            Else
                TxtSubTotal.Text = IIf(Subtotal_ = 0, "0.00", FormatNumber(Format(Subtotal_, "###,###,###.00"), 2))
                TxtImpuesto.Text = IIf(Impuesto_ = 0, "0.00", FormatNumber(Format(Impuesto_, "###,###,###.00"), 2))
                TxtTotal.Text = IIf(Total_ = 0, "0.00", FormatNumber(Total_, 2))
            End If

            '*******************************************           

            If (Val(Me.TxtDescuento.Text) / 100) > 0 Then '-> Aplica Descuento
                Me.DescuentoM3()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'Try
        '    Dim IGV As Double = dtoUSUARIOS.iIGV / 100
        '    '************************
        '    Dim Altura As Double = 0
        '    If Conversion.Val(GrdDetalleVenta(2, iROW).Value) = 0 Then Altura = 0 _
        '                             Else Altura = GrdDetalleVenta(2, iROW).Value
        '    '************************
        '    Dim Ancho As Double = 0
        '    If Conversion.Val(GrdDetalleVenta(3, iROW).Value) = 0 Then Ancho = 0 _
        '                            Else Ancho = GrdDetalleVenta(3, iROW).Value
        '    '************************
        '    Dim Largo As Double = 0
        '    If Conversion.Val(GrdDetalleVenta(4, iROW).Value) = 0 Then Largo = 0 _
        '                            Else Largo = GrdDetalleVenta(4, iROW).Value

        '    '******PESO KG***********
        '    GrdDetalleVenta("Peso Kg", iROW).Value = IIf((Altura * Ancho * Largo) * dFactor = 0, "0.00", _
        '                                                FormatNumber(Format((Altura * Ancho * Largo) * dFactor, "###,###,###.00"), 2))

        '    '******Llamando la Condicion Tarifa(Calculo)*******
        '    If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadPeso_ = "PESO" Then
        '        fnCalcularCondicionTarifa(iROW, GrdDetalleVenta("Peso Kg", iROW).Value, GrdDetalleVenta("Costo", iROW).Value)
        '    Else
        '        '******SUB_NETO***********
        '        GrdDetalleVenta("Sub Neto", iROW).Value = IIf(GrdDetalleVenta("Peso Kg", iROW).Value * Conversion.Val(GrdDetalleVenta("Costo", iROW).Value) = 0, "0.00", _
        '                                                      FormatNumber(Format((GrdDetalleVenta("Peso Kg", iROW).Value) * Conversion.Val(GrdDetalleVenta("Costo", iROW).Value), "###,###,###.00"), 2))
        '    End If


        '    '*****************Calculo Operacion*********************************************   
        '    Dim SumSubNeto_ As Double = 0
        '    Dim Valor_ As Double
        '    For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1
        '        If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Valor_ = 0 _
        '                            Else Valor_ = GrdDetalleVenta("Sub Neto", i).Value
        '        SumSubNeto_ += Valor_
        '    Next
        '    '**********************
        '    If SumSubNeto_ > 0 Then
        '        If Monto_Base > 0 Then
        '            ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
        '        End If

        '        ObjVentaCargaContado.v_MONTO_BASE = 0
        '        SumSubNeto_ = SumSubNeto_ + Monto_Base
        '    End If
        '    '**********************

        '    Dim Monto_Sobre As Double = 0
        '    If ChkSobres.Checked = True Then
        '        Monto_Sobre = tarifa_Sobre * Conversion.Val(txtCantidadSobres.Text)
        '        txtTotalSobre.Visible = True
        '        txtTotalSobre.Text = Format(Monto_Sobre, "####,###,###.00")
        '    End If

        '    '****Añade [Sobres] al la sumaSubNeto*******************************************
        '    Dim MontoSobre_ As Double = 0
        '    If (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then MontoSobre_ = _
        '                                                       (txtCantidadSobres.Text * tarifa_Sobre) ' + Monto_Base
        '    '*******************************************************************************
        '    SumSubNeto_ = fnTECHO(Format(SumSubNeto_ + MontoSobre_, "0.000"))
        '    '*******************************************
        '    Dim Total_ As Double
        '    Dim Subtotal_ As Double
        '    Dim Impuesto_ As Double

        '    If bTarifarioGeneral And bContado = False Then
        '        Total_ = SumSubNeto_ * (1 + IGV) 'fnTECHO(Format(SumSubNeto_ * (1 + IGV), "0.000"))
        '        Subtotal_ = Total_ / (1 + IGV)
        '        Impuesto_ = Subtotal_ * IGV
        '    Else
        '        Total_ = SumSubNeto_
        '        Subtotal_ = Total_ / (1 + IGV)
        '        Impuesto_ = Subtotal_ * IGV
        '    End If


        '    If (Total_ < MontoMinimoPyme) And CboTipo.SelectedValue = 1 And CboProducto.SelectedValue = 7 Then
        '        Me.CondicionMontoMinimoPYME()
        '    ElseIf (Total_ < monto_minimo_PCE) And CboTipo.SelectedValue = 1 And CboProducto.SelectedValue <> 7 Then
        '        Me.TxtDescuento.ReadOnly = True
        '        Me.TxtDescuento.BackColor = System.Drawing.SystemColors.Control
        '        Me.CondicionMontoMinimoPCE()
        '    Else
        '        '*******************************************               
        '        Me.TxtDescuento.ReadOnly = False
        '        Me.TxtDescuento.BackColor = Color.White

        '        TxtSubTotal.Text = IIf(Subtotal_ = 0, "0.00", FormatNumber(Format(Subtotal_, "###,###,###.00"), 2))
        '        TxtImpuesto.Text = IIf(Impuesto_ = 0, "0.00", FormatNumber(Format(Impuesto_, "###,###,###.00"), 2))
        '        TxtTotal.Text = IIf(Total_ = 0, "0.00", FormatNumber(Total_, 2))
        '        '******************************************* 
        '    End If

        '    'If (Val(Me.TxtDescuento.Text) / 100) > 0 Then '-> Aplica Descuento
        '    '    Me.DescuentoM3()
        '    'End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    '********CALCULO DESCUENTO M3***************************
    Sub DescuentoM3()
        Dim SumSubNeto_ As Double = 0
        Dim Valor_ As Double
        Try
            For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1
                If IsNumeric(GrdDetalleVenta("tipo", i).Value) Then
                    If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Valor_ = 0 _
                                        Else Valor_ = GrdDetalleVenta("Sub Neto", i).Value
                    SumSubNeto_ += Valor_
                End If
            Next

            Dim IGV As Double = dtoUSUARIOS.iIGV / 100

            '****Añade [Sobres] al la sumaSubNeto*******************************************
            Dim MontoSobre_ As Double = 0
            If (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then MontoSobre_ = _
                                                               (txtCantidadSobres.Text * Monto_Base) 'hlamas 28-11-2013 + Monto_Base

            'hlamas 11-09-2015
            'SumSubNeto_ = fnTECHO(Format(SumSubNeto_ + MontoSobre_, "0.00"))
            SumSubNeto_ = Format(SumSubNeto_ + MontoSobre_, "0.00")

            'hlamas 28-11-2013
            '********Agrega Monto Base*********************************
            If Val(Me.TxtMontoBase.Text) > 0 Then
                'hlamas 11-09-2015
                'SumSubNeto_ = fnTECHO(Format(SumSubNeto_ + Val(Me.TxtMontoBase.Text), "0.00"))
                SumSubNeto_ = Format(SumSubNeto_ + Val(Me.TxtMontoBase.Text), "0.00")
            End If

            Dim intFila As Integer
            '********Agrega Entrega Domicilio***************************
            intFila = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
            If intFila > 0 Then
                'hlamas 11-09-2015
                'SumSubNeto_ = fnTECHO(Format(SumSubNeto_ + Val(GrdDetalleVenta("SUB NETO", intFila).Value), "0.00"))
                SumSubNeto_ = Format(SumSubNeto_ + Val(GrdDetalleVenta("SUB NETO", intFila).Value), "0.00")
            End If

            '********************************DEVOLUCION DE CARGO************************************************
            intFila = BuscarItemVenta("DEV CARGO", GrdDetalleVenta)
            If intFila > 0 Then
                'dblMontoDC = ObtieneMontoDevolucionCargo()
                SumSubNeto_ += Format(Val(GrdDetalleVenta("Sub Neto", intFila).Value), "0.00")
            End If
            '********************************DEVOLUCION DE CARGO************************************************

            '********Agregar Carga Seguro*******************************
            intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
            If intFila > 0 Then
                'hlamas 11-09-2015
                'SumSubNeto_ = fnTECHO(Format(SumSubNeto_ + Val(GrdDetalleVenta("SUB NETO", intFila).Value), "0.00"))
                SumSubNeto_ = Format(SumSubNeto_ + Val(GrdDetalleVenta("SUB NETO", intFila).Value), "0.00")
            End If
            '******DESCUENTO ARTICULOS******************************************************
            Dim SUB_TOTAL_GENERAL As Double = 0
            If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                'hlamas 11-09-2015
                'SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                SUB_TOTAL_GENERAL = Format((1 + IGV) * SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                    SUB_TOTAL_GENERAL = RedondearMas(SUB_TOTAL_GENERAL, 1)
                End If
                If bTarifarioGeneral Then
                    'hlamas 11-09-2015
                    'SUB_TOTAL_GENERAL = fnTECHO(Format(SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                    SUB_TOTAL_GENERAL = Format((1 + IGV) * SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                    If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                        SUB_TOTAL_GENERAL = RedondearMas(SUB_TOTAL_GENERAL, 1)
                    End If
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

            If CboProducto.SelectedValue = 7 And Total_ <= MontoMinimoPyme Then 'agregado 04022012
                Me.CondicionMontoMinimoPYME()
            Else
                TxtSubTotal.Text = IIf(Subtotal_ = 0, "0.00", FormatNumber(Format(Subtotal_, "###,###,###.00"), 2))
                TxtImpuesto.Text = IIf(Impuesto_ = 0, "0.00", FormatNumber(Format(Impuesto_, "###,###,###.00"), 2))
                TxtTotal.Text = IIf(Total_ = 0, "0.00", FormatNumber(Total_, 2))
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'Dim SumSubNeto_ As Double = 0
        'Dim Valor_ As Double
        'Try
        '    For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1
        '        If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Valor_ = 0 _
        '                            Else Valor_ = GrdDetalleVenta("Sub Neto", i).Value
        '        SumSubNeto_ += Valor_
        '    Next

        '    Dim IGV As Double = dtoUSUARIOS.iIGV / 100

        '    '****Añade [Sobres] al la sumaSubNeto*******************************************
        '    Dim MontoSobre_ As Double = 0
        '    If (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then MontoSobre_ = _
        '                                                       (txtCantidadSobres.Text * Monto_Base) + Monto_Base

        '    SumSubNeto_ = fnTECHO(Format(SumSubNeto_ + MontoSobre_, "0.00"))
        '    '******DESCUENTO ARTICULOS******************************************************
        '    Dim SUB_TOTAL_GENERAL As Double = 0
        '    If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
        '        SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
        '        If bTarifarioGeneral Then
        '            SUB_TOTAL_GENERAL = fnTECHO(Format(SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
        '        End If
        '    Else
        '        If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
        '            SUB_TOTAL_GENERAL = 0
        '        End If
        '    End If

        '    '*******************************************
        '    Dim Total_ As Double = SUB_TOTAL_GENERAL
        '    Dim Subtotal_ As Double = Total_ / (1 + IGV)
        '    Dim Impuesto_ As Double = Subtotal_ * IGV
        '    '*******************************************
        '    'agreagado 04022012
        '    If Total_ < MontoMinimoPyme And CboTipo.SelectedValue = 1 And CboProducto.SelectedValue = 7 Then
        '        Me.CondicionMontoMinimoPYME()
        '    ElseIf (Total_ < monto_minimo_PCE) And CboTipo.SelectedValue = 1 And CboProducto.SelectedValue <> 7 Then
        '        'TxtDescuento.Enabled = False
        '        Me.CondicionMontoMinimoPCE()
        '    Else
        '        Me.TxtDescuento.ReadOnly = False
        '        Me.TxtDescuento.BackColor = Color.White

        '        TxtSubTotal.Text = IIf(Subtotal_ = 0, "0.00", FormatNumber(Format(Subtotal_, "###,###,###.00"), 2))
        '        TxtImpuesto.Text = IIf(Impuesto_ = 0, "0.00", FormatNumber(Format(Impuesto_, "###,###,###.00"), 2))
        '        TxtTotal.Text = IIf(Total_ = 0, "0.00", FormatNumber(Total_, 2))
        '    End If

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    '********CALCULO CONDICION TARIFA***********************
    Private Sub fnCalcularCondicionTarifa(ByVal row As Integer, ByVal Peso_Volumen As Double, ByVal Costo As Double)
        Try
            If ChkM3.Checked Then
                If Peso_Volumen >= objGuiaEnvio.iPeso_Minimo And Peso_Volumen <= objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
                    GrdDetalleVenta("Sub Neto", row).Value = objGuiaEnvio.iPrecio_cond_Peso
                ElseIf Peso_Volumen > objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
                    Dim Calculo As Double = (Peso_Volumen - objGuiaEnvio.iPeso_Maximo) * (Costo)
                    Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
                    GrdDetalleVenta("Sub Neto", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                ElseIf Peso_Volumen < objGuiaEnvio.iPeso_Minimo Then
                    GrdDetalleVenta("Sub Neto", row).Value = "0.00"
                End If
            Else
                If (CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER) Then
                    If row = 0 Or row = 1 Then
                        If Peso_Volumen >= objGuiaEnvio.iPeso_Minimo And Peso_Volumen <= objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
                            GrdDetalleVenta("Sub Neto", row).Value = objGuiaEnvio.iPrecio_cond_Peso
                        ElseIf Peso_Volumen > objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
                            Dim Calculo As Double = (Peso_Volumen - objGuiaEnvio.iPeso_Maximo) * (Costo)
                            Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
                            GrdDetalleVenta("Sub Neto", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                        ElseIf Peso_Volumen < objGuiaEnvio.iPeso_Minimo Then
                            GrdDetalleVenta("Sub Neto", row).Value = "0.00"
                        End If
                    End If
                Else
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

                End If

            End If

            Dim ValNroSobres As Double = 0
            Dim Nor_Sobres As Double = 0
            If ChkM3.Checked = False Then
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

    '********SOBRES*****************************************
    Private Sub ChkSobres_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSobres.CheckedChanged
        Try

            If iOpcion = 2 Then
                RemoveHandler ChkSobres.CheckedChanged, AddressOf ChkSobres_CheckedChanged
                ChkSobres.Checked = Not ChkCliente2.Checked
                AddHandler ChkSobres.CheckedChanged, AddressOf ChkSobres_CheckedChanged
                Return
            End If

            RemoveHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
            If ChkSobres.Checked = True Then
                txtCantidadSobres.Enabled = True
            Else
                txtCantidadSobres.Enabled = False
            End If

            If ChkSobres.Checked = True Then
                txtCantidadSobres.Enabled = True
                txtCantidadSobres.Focus()
            Else
                txtCantidadSobres.Enabled = False
                txtCantidadSobres.Text = ""
                txtTotalSobre.Text = "0.00"
                If ChkM3.Checked = True Then
                    'Me.Calculo_M3()
                Else
                    If CboTipo.SelectedValue = 1 Then
                        Me.CalculoArticulos() '----> PCE
                    ElseIf CboTipo.SelectedValue = 2 Then
                        Me.calculoGrdArticulos() '--> CREDITO
                    End If

                End If
            End If
            AddHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCantidadSobres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidadSobres.TextChanged
        Try
            If CboTipo.SelectedValue = 1 Then
                If txtCantidadSobres.Text = "" Then
                    objGuiaEnvio.iCANTIDAD_SOBRES = 0
                    objGuiaEnvio.iIDSINO_SOBRES = 0
                    txtTotalSobre.Text = "0.00"

                    '****NEW CODIGO*********************************************
                    Dim Val As Boolean = False
                    For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1
                        If GrdDetalleVenta(2, i).Value <> "" Then
                            Val = True
                        End If
                    Next

                    If Val Then
                        TxtSubTotal.Text = "0.00"
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
                    If ChkM3.Checked = True Then
                        Me.Calculo_M3() '---------> Sobre M3
                    ElseIf (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then
                        Calculo_Sobre() '---------> Sobre Bulto
                    Else
                        iCOL = 2
                        Me.CalculoArticulos() '--->Sobre Articulo
                    End If
                End If
            Else
                If ChkArticulos.Enabled = True And ChkArticulos.Checked = True Then
                    Me.calculoGrdArticulos()
                End If
            End If
            '----------------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub txtCantSobres_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidadSobres.LostFocus
        If txtCantidadSobres.Text = "" Then
            RemoveHandler ChkSobres.CheckedChanged, AddressOf ChkSobres_CheckedChanged
            ChkSobres.Checked = False
            txtCantidadSobres.Enabled = False
            AddHandler ChkSobres.CheckedChanged, AddressOf ChkSobres_CheckedChanged
        End If
    End Sub

    '********CALCULO SOBRES PCE*****************************
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
            Dim T_Costo As Double = 0
            If fArticulo = True Then
                Dim ii1 As Integer = 0
                For ii1 = 0 To GrdDetalleVenta.Rows().Count() - 1
                    If Val(GrdDetalleVenta.Rows(ii1).Cells("P.Total").Value) = 0 Then T_Costo = 0 Else _
                                                   T_Costo = GrdDetalleVenta.Rows(ii1).Cells("P.Total").Value
                    Total_Articulo = Total_Articulo + T_Costo
                Next
                ' Total_Articulo = Total_Articulo '+ Monto_Base * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                If Total_Articulo > 0 Then
                    TxtSubTotal.Text = Format(Monto_Base + Monto_Sobre + Total_Articulo, "####,###,###.00")
                    TxtImpuesto.Text = Format((IGV) * (Monto_Base + Monto_Sobre + Total_Articulo), "####,###,###.00")
                    TxtTotal.Text = Format((1 + IGV) * (Monto_Base + Monto_Sobre + Total_Articulo), "####,###,###.00")
                Else
                    TxtSubTotal.Text = Format(Monto_Sobre, "####,###,###.00")
                    TxtImpuesto.Text = Format((IGV) * (Monto_Sobre), "####,###,###.00")
                    TxtTotal.Text = Format((1 + IGV) * (Monto_Sobre), "####,###,###.00")
                End If
            Else
                TxtSubTotal.Text = Format(Monto_Sobre, "####,###,###.00")
                TxtImpuesto.Text = Format((IGV) * (Monto_Sobre), "####,###,###.00")
                TxtTotal.Text = Format((1 + IGV) * (Monto_Sobre), "####,###,###.00")
            End If

            Dim SUB_TOTAL_GENERAL As Double = 0
            Dim SubTotal_Costo As Double = TxtSubTotal.Text
            If (1 - Val("") / 100) > 0 Then
                'hlamas 11-09-2015
                'SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val("") / 100), "###,###,###.0000")) '01/09/2010 
                SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal_Costo * (1 - Val("") / 100), "###,###,###.0000") '01/09/2010
            Else
                If (1 - Val("") / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            TxtSubTotal.Text = Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            TxtImpuesto.Text = Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            TxtTotal.Text = Format(SUB_TOTAL_GENERAL, "###,###,###.00")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

    Dim isDescuento_ As Boolean
    Sub tarifarioEnMemoria()
        Try
            GrdDetalleVenta(3, 0).Value = tarifa_Peso
            GrdDetalleVenta(3, 1).Value = tarifa_Volumen
            GrdDetalleVenta(3, 2).Value = tarifa_Sobre
            GrdDetalleVenta(3, 3).Value = Monto_Base
            GrdDetalleVenta(4, 3).Value = Monto_Base
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '***FUNCION FNTECHO REDONDEAR MONTO***************************************
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
            Throw New Exception(ex.Message)
        End Try
        If monto Mod 0.5 = 0 Then
            Return monto
        Else
            Return monto_total
        End If
    End Function

    '***DEFINIENDO TIPO DE CARACTER A LAS CELDAS******************************
    Dim tipo_ As String
    Sub TipoCampos()
        Try
            If ChkArticulos.Checked = True And CboTipo.SelectedValue = 1 Then '-------------> ARTICULOS
                If BCol_ = 2 Then tipo_ = "Int"
                If BCol_ = 3 Then tipo_ = "Float"
            ElseIf ChkArticulos.Checked = True And CboTipo.SelectedValue = 2 Then
                If BCol_ = 2 Then tipo_ = "Int"
                If BCol_ >= 3 Then tipo_ = "Float"
            End If

            If ChkM3.Checked = True Then '--------------------------------------------------> M3 (VOLUMETRICO)
                If BCol_ = 1 Then tipo_ = "Int"
                If BCol_ >= 2 Then tipo_ = "Float"
            End If

            If ChkM3.Checked = False And ChkArticulos.Checked = False Then '----------------> BULTOS
                If BCol_ = 1 Then tipo_ = "Int"
                If BCol_ = 2 Then tipo_ = "Float"
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '*******************VALIDACION PARA LAS CELDAS (SOLO NUMEROS)*************
    Private WithEvents celda As DataGridViewTextBoxEditingControl
    Dim GrdDocumentos As Boolean
    Dim GrdDetVenta As Boolean
    Private Sub GrdDocumentosCliente_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles GrdDocumentosCliente.EditingControlShowing
        'Me.TipoCampos()
        GrdDocumentos = True
        GrdDetVenta = False
        celda = TryCast(e.Control, DataGridViewTextBoxEditingControl)
        If TypeOf e.Control Is TextBox Then '***CONVERTIR CARACTERES A MAYUSCULAS EN EL DATAGRID
            DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
        End If
    End Sub

    Private Sub GrdDetalleVenta_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles GrdDetalleVenta.EditingControlShowing
        GrdDetVenta = True
        GrdDocumentos = False
        Me.TipoCampos()
        celda = TryCast(e.Control, DataGridViewTextBoxEditingControl)
    End Sub

    Private Sub celda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles celda.KeyPress
        If GrdDocumentos Then
            e.Handled = Me.NumeroDocu(e, celda)
        ElseIf GrdDetVenta Then
            e.Handled = Me.Numero(e, celda)
        End If
    End Sub

    Public Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef Celda As TextBox) As Boolean
        Try
            If tipo_ = "Float" Then
                If UCase(e.KeyChar) Like "[!0-9.]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If

                Dim c As Short = 0
                If UCase(e.KeyChar) Like "[.]" Then
                    If InStr(Celda.Text, ".") > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            ElseIf tipo_ = "Int" Then
                If UCase(e.KeyChar) Like "[!0-9]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function NumeroDocu(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef Celda As TextBox) As Boolean

        Try
            If Asc(e.KeyChar) = Keys.Back Then
                Return False
            End If

            If Celda.TextLength + 1 < 4 And Not UCase(e.KeyChar) Like "[-]" Then
                If UCase(e.KeyChar) Like "[ A-ZÑ0-9\b]" Then
                    Return False
                Else
                    Return True
                End If
            ElseIf Celda.TextLength + 1 = 4 And UCase(e.KeyChar) Like "[-]" Then
                Return False
            ElseIf Celda.TextLength + 1 > 4 And Not UCase(e.KeyChar) Like "[-]" Then
                If UCase(e.KeyChar) Like "[0-9-]" Then
                    Return False
                Else
                    Return True
                End If
            End If

            Dim c As Short = 0
            If UCase(e.KeyChar) Like "[-]" Then
                If InStr(Celda.Text, "-") > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If          
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    '****************FORMATO SEPARADOS SIN MILES******************************
    Dim BCol_ As Integer, BRow_ As Integer
    Private Sub GrdDetalleVenta_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles GrdDetalleVenta.CellBeginEdit
        Try
            'hlamas 28-11-2013
            If TipoGrid_ = FormatoGrid.VOLUMETRICO AndAlso Not IsNumeric(GrdDetalleVenta("TIPO", e.RowIndex).Value) Then
                e.Cancel = True
            End If
            '--------------
            Me.TipoCampos()
            '--------------           
            Dim Formato_ As Double
            BCol_ = e.ColumnIndex
            BRow_ = e.RowIndex

            If ChkM3.Checked = False And ChkArticulos.Checked = False Then '----------> Bultos
                If BCol_ = 1 Or BCol_ = 2 Then
                    If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) = 0 Then
                        Return
                    Else
                        Formato_ = GrdDetalleVenta(BCol_, BRow_).Value
                    End If
                    '------
                    GrdDetalleVenta(BCol_, BRow_).Value = Formato_
                End If
            End If


            If ChkArticulos.Checked = True Then '-------------------------------------> Articulos
                If BCol_ = 2 Or BCol_ = 3 Then
                    If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) = 0 Then
                        Return
                    Else
                        Formato_ = GrdDetalleVenta(BCol_, BRow_).Value
                    End If
                    '------
                    GrdDetalleVenta(BCol_, BRow_).Value = Formato_
                End If
            End If

            If ChkM3.Checked = True Then '----------------------------------------------> M3
                If BCol_ >= 1 And BCol_ <= 5 Then
                    If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) = 0 Then
                        Return
                    Else
                        Formato_ = GrdDetalleVenta(BCol_, BRow_).Value
                    End If
                    '------
                    GrdDetalleVenta(BCol_, BRow_).Value = Formato_
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***FORMATO MILES PARA LAS CELDAS [EJEMPLO (12,400.25)]*******************  
    Sub FormatoMiles()
        Try
            If tipo_ = "Float" Then '-- tipo decimales
                If Conversion.Val(GrdDetalleVenta(iCOL, iROW).Value) = 0 Then GrdDetalleVenta(iCOL, iROW).Value = "0.00" : Return
                GrdDetalleVenta(iCOL, iROW).Value = FormatNumber(GrdDetalleVenta(iCOL, iROW).Value, 2)
            ElseIf tipo_ = "Int" Then '--> tipo Entero
                If Conversion.Val(GrdDetalleVenta(iCOL, iROW).Value) = 0 Then GrdDetalleVenta(iCOL, iROW).Value = "" : Return
                GrdDetalleVenta(iCOL, iROW).Value = FormatNumber(GrdDetalleVenta(iCOL, iROW).Value, 0)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '***RESET VALORES DE LAS CELDAS*******************************************
    Sub ResetCalculo() '-> reseteando el calculo al cambiar el tipo de entrega 
        Try
            If ChkM3.Checked = False Then '-----------------------------> BULTO
                For i As Integer = 0 To GrdDetalleVenta.RowCount() - 2
                    GrdDetalleVenta("Bulto", i).Value = "" '------------> reset campo [Bulto]
                    GrdDetalleVenta("Peso/Volumen", i).Value = "0.00" '-> reset campo [Peso/Volumen]
                    GrdDetalleVenta("Sub Neto", i).Value = "0.00" '-----> reset campo [Sub Neto]
                Next
            ElseIf ChkM3.Checked = True Then '---------------------------> M3
                For i As Integer = 0 To GrdDetalleVenta.RowCount() - 1
                    GrdDetalleVenta("Bulto", i).Value = ""
                    GrdDetalleVenta("Altura", i).Value = "0.00"
                    GrdDetalleVenta("Ancho", i).Value = "0.00"
                    GrdDetalleVenta("Largo", i).Value = "0.00"
                    GrdDetalleVenta("Peso Kg", i).Value = "0.00"
                    GrdDetalleVenta("Sub Neto", i).Value = "0.00"
                Next
            End If

            If CboTipo.SelectedValue <> 1 Then
                TxtSubTotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"
            ElseIf CboTipo.SelectedValue = 1 Then
                Me.CondicionMontoMinimoPCE()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
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

    '***CONTROL DEL KEYDOWN AL GRID*******************************************
    Private Sub GrdDetalleVenta_KeyDown(ByVal sender As System.Object, _
                                        ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdDetalleVenta.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If

            Dim index As Integer = CType(sender, DataGridView).CurrentRow.Index
            If TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                Dim UltimaFila As Integer = GrdDetalleVenta.Rows.Count() - 1
                If (Keys.Down = e.KeyCode Or Keys.Up = e.KeyCode Or Keys.Delete = e.KeyCode) And IsNumeric(GrdDetalleVenta("tipo", index).Value) Then
                    If bInicio Then Return
                    Dim Key As Integer = e.KeyValue
                    GenerarDataGridVolumetrico(GrdDetalleVenta, index, UltimaFila, tarifa_Peso, Key)
                    'hlamas 28-11-2013
                    iROW = 0 'RowEnter
                    Me.Calculo_M3()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "SEGURO"
    Private Sub BtnCargAseg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCargAseg.Click
        Try
            If ChkArticulos.Checked = False Then
                Dim A As New FrmDocCliente

                A.sFecha = txtFechaGuia.Text
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

    Dim iSub_Total_CA As Double = 0, iImpuesto_CA As Double = 0, iTotal_CA As Double = 0
    Dim bMontoMinimo As Boolean
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
                If ChkM3.Checked = False Then
                    ObtieneMontosAsegurados(iSub_Total_CA, iImpuesto_CA, iTotal_CA)
                    If iTotal_CA > 0 Then
                        'hlamas 21-11-2013
                        'If GrdDetalleVenta.Rows.Count < 5 Then
                        intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                        If intFila = 0 Then
                            GrdDetalleVenta.Rows.Add()
                            intFila = GrdDetalleVenta.Rows.Count - 1
                        End If
                        'End If
                        'hlamas 21-11-2013
                        GrdDetalleVenta(0, intFila).Value = "CARGA SEGURO"
                        GrdDetalleVenta(2, intFila).Value = "0.00"
                        GrdDetalleVenta(3, intFila).Value = "0.00"
                        If bTarifarioGeneral And bContado Then
                            GrdDetalleVenta(4, intFila).Value = FormatNumber(iTotal_CA, 2)
                        Else
                            GrdDetalleVenta(4, intFila).Value = FormatNumber(iSub_Total_CA, 2)
                        End If
                    End If
                    'Me.Timer2.Start()
                ElseIf ChkM3.Checked = True Then
                    ObtieneMontosAsegurados(iSub_Total_CA, iImpuesto_CA, iTotal_CA)
                    If iTotal_CA > 0 Then
                        'If GrdDetalleVenta.Rows.Count < 2 Then
                        'GrdDetalleVenta.Rows.Add()
                        'GrdDetalleVenta.Rows(1).ReadOnly = True
                        'End If
                        intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                        If intFila = 0 Then
                            GrdDetalleVenta.Rows.Add()
                            intFila = GrdDetalleVenta.Rows.Count - 1
                        End If
                        GrdDetalleVenta(0, intFila).Value = "CARGA SEGURO"
                        GrdDetalleVenta(2, intFila).Value = "0.00"
                        GrdDetalleVenta(3, intFila).Value = "0.00"
                        GrdDetalleVenta(4, intFila).Value = "0.00"
                        GrdDetalleVenta(5, intFila).Value = "0.00"
                        GrdDetalleVenta(6, intFila).Value = "0.00"
                        If bTarifarioGeneral And bContado Then
                            GrdDetalleVenta(7, intFila).Value = FormatNumber(iTotal_CA, 2)
                        Else
                            GrdDetalleVenta(7, intFila).Value = FormatNumber(iSub_Total_CA, 2)
                        End If
                End If
                'Me.Timer2.Start()
                End If
            Else
                If ChkM3.Checked = False Then
                    intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                    'If GrdDetalleVenta.Rows.Count = 5 Then
                    If intFila > 0 Then
                        GrdDetalleVenta.Rows.RemoveAt(intFila)
                    End If
                ElseIf ChkM3.Checked = True Then
                    intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                    If intFila > 0 Then
                        GrdDetalleVenta.Rows.RemoveAt(intFila)
                    End If
                    'If GrdDetalleVenta.Rows.Count = 2 Then
                    'GrdDetalleVenta.Rows.RemoveAt(1)
                    'End If
                End If
                'Me.Timer2.Stop()
                End If
            If recuperando_datos_contado = False Then
                'hlamas 28-11-2013
                iROW = 0
                fnTotalPago()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub ObtieneMontosAsegurados(ByRef s As Double, ByRef i As Double, ByRef t As Double)
        Try
            s = 0
            i = 0
            t = 0
            For Each obj As ClsLbTepsa.dtoCargaAsegurada.ComprobanteAsegurada In objComprobanteAsegurada
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
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "BTN NUEVO"
    Sub FNNUEVO()
        Try
            Me.CboListaUsuarios.Enabled = True
            Me.CboCiudad_Origen.Enabled = True
            Me.CboAgencia_Origen.Enabled = True
            Me.RbtDocumento.Enabled = True
            Me.RbtNombre.Enabled = True
            Me.TxtCliente.Enabled = True

            bDescuento = False
            bTieneLineaCredito = False
            sDocCliente = ""
            iOficinaDestino = 0
            CboCiudad_Origen.SelectedValue = 0
            Me.CboAgencia_Origen.SelectedValue = 0
            TxtCiudadDestino.Text = ""
            Me.CboTipoEntrega.SelectedValue = 0

            'hlamas 24-02-2014
            Me.CboTipoEntrega.Enabled = True
            Me.TxtCiudadDestino.Enabled = True
            Me.CboDireccion2.Enabled = True

            RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            TxtNroDocCliente.Text = ""
            AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            Me.LimpiarDatosGeneral()
            TipoGrid_ = FormatoGrid.BULTO
            Me.DiseñaGrdDetalleVenta()
            Me.FormatoGrdDetalleVenta()
            ChkArticulos.Enabled = False
            ChkArticulos.Checked = False
            ChkM3.Checked = False
            objComprobanteAsegurada = Nothing
            ReDim objComprobanteAsegurada(19)
            '****carga asegurada***********
            es_carga_asegurada = False
            iTotal_CA = 0
            '******************************
            Me.CboSubCuenta.DataSource = Nothing
            Me.CboSubCuentaOrigen.DataSource = Nothing

            Me.CboAgenciaDest.DataSource = Nothing
            If CboTipo.SelectedValue = 1 Then
                CboProducto.SelectedIndex = 0
            ElseIf CboTipo.SelectedValue = 2 Then
                CboProducto.SelectedIndex = -1
            End If

            'CboFormaPago.SelectedIndex = 0
            Me.TxtCiudadDestino.Focus()
            '**********
            bClienteModificado = False
            bDireccionModificada = False

            bRemitenteModificado = False
            bContactoModificado = False

            bConsignadoModificado = False
            bDirecConsigMod = False

            bConsignadoNuevo = True
            bClienteNuevo = True
            'limpiando los codigos
            iID_Persona = 0
            idRemitente = 0
            idcontacto = 0
            iIDConsignado = 0

            Me.CboAgencia_Origen.SelectedValue = 0

            sNombresCli = "" : sApCli = "" : sAmCli = "" : sTelfCliente = "" : sRazonSocialCliente = ""
            RbtDocumento3.Checked = True
            RbtDocumento.Checked = True
            Me.LimpiarCliente()
            Me.LimpiarConsignado()

            'hlamas 22-03-2016
            'ChkCargo.Checked = False
            ControlaCargo(False)
            MostrarTipoFacturacion(0)

            ChkSobres.Checked = False
            txtCantidadSobres.Text = ""
            txtTotalSobre.Text = ""
            TxtMontoBase.Text = ""
            '**********  
            '02092011
            strNroGuias_Remision = ""
            limpiar_documentos_cliente()

            sTelefonoConsig = ""
            sTelfCliente = ""

            ChkCliente.Checked = False
            ChkCliente1.Checked = False
            ChkCliente2.Checked = False

            'Limpia variables de dirección origen
            ObjVentaCargaContado.id_DepartamentoCli = 0
            ObjVentaCargaContado.id_ProvinciaCli = 0
            ObjVentaCargaContado.id_DistritoCli = 0
            ObjVentaCargaContado.id_viaCli = 0
            ObjVentaCargaContado.viaCli = ""
            ObjVentaCargaContado.NumeroCli = ""
            ObjVentaCargaContado.manzanaCli = ""
            ObjVentaCargaContado.loteCli = ""
            ObjVentaCargaContado.id_nivelCli = 0
            ObjVentaCargaContado.nivelCli = ""
            ObjVentaCargaContado.id_zonaCli = 0
            ObjVentaCargaContado.zonaCli = ""
            ObjVentaCargaContado.id_clasificacionCli = 0
            ObjVentaCargaContado.clasificacionCli = ""
            dtDireccion = Nothing

            'Limpia variables de dirección destino
            Me.CboDireccion2.DataSource = Nothing
            Me.CboDireccion2.Items.Clear()
            Me.CboDireccion2.Items.Add("AGENCIA")
            Me.CboDireccion2.SelectedIndex = 0
            iDepartamentoConsig = 0
            iProvinciaConsig = 0
            iDistritoConsig = 0
            IDviaConsig = 0
            ViaConsig = ""
            NroConsig = ""
            ManzanaConsig = ""
            loteConsig = ""
            id_NivelConsig = 0
            NivelConsig = ""
            id_ZonaConsig = 0
            ZonaConsig = ""
            id_ClasificacionConsig = 0
            ClasificacionConsig = ""
            TxtReferencia.Text = ""
            sReferencia = ""
            dtDireccion2 = Nothing

            iCiudadDestino = 0


            '===Agregado x NConsignado=============
            Me.GrdNConsignado.Rows.Clear()
            Me.LimpiarNConsignados()
            '======================================

            '--------

            'hlamas 11-03-2019
            txtNroNroGuia.Text = ""
            ObjVentaCargaContado.NroDoc = ""
            CORRELATIVO = ""
            'If CboProducto.SelectedValue <> Nothing AndAlso ObjVentaCargaContado.fnNroDocuemnto(3, CboProducto.SelectedValue) = True Then
            '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
            '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
            '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
            'ElseIf ObjVentaCargaContado.fnNroDocuemnto(3, 0) = True Then
            '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
            '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
            '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
            'End If



            '-->10/09/2013 - jabanto
            '-->Oculta los campos DT(Docuemento de transporte)
            lblDT.Visible = False
            txtdt.Visible = False
            Me.dtpFechaRecojo.Visible = False
            Me.dtpFechaRecojo.Checked = False
            TxtTelfCliente.Size = New Size(329, 20)
            txtdt.Clear()
            'hlamas 23-09-2013
            Me.ControlaSubcuentaOrigen(False)
            strNroGuias_Remision = ""

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

    '=================FUNCIONES===
#Region "Keypress"
    Private Sub TxtNroDocConsignado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Me.ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCantSobres_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadSobres.KeyPress
        If Not Me.ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
#End Region

#Region "FUNCIONES LIMPIAR"

    Sub LimpiarDatosGeneral()
        Me.TxtCliente.Text = ""
        Me.TxtConsignado.Text = ""
        '***Comentado x NConsignado*****
        'Me.TxtNombConsignado.Text = ""
        Me.TxtBoleto.Text = ""
        Me.TxtCiudadDestino.Enabled = True

        'hlamas 24-02-2014
        Me.CboTipoEntrega.Enabled = True
        Me.CboDireccion2.Enabled = True

        Me.TxtCiudadDestino.ReadOnly = False
        Me.LimpiarDatosCliente()
    End Sub

    Sub LimpiarConsignado()
        '*****Comentado x NConsignado*******
        'Me.TxtNroDocConsignado.Text = ""
        'Me.TxtNombConsignado.Text = ""
        'Me.TxtTelfConsignado.Text = ""

        '===Agregado x NConsignado==========
        GrdNConsignado.Rows.Clear()
        '===================================

        Me.ChkCliente2.Checked = False
        bConsignadoNuevo = True
    End Sub

    Sub LimpiarCliente()
        If Not CboSubCuenta.Focused Then
            Me.TxtNroDocCliente.Text = ""
            Me.TxtNomCliente.Text = ""
        End If

        Me.CboDireccion.DataSource = Nothing
        Me.CboDireccion.Items.Clear()
        Me.CboDireccion.Items.Add(" (SELECCIONE)")
        Me.CboDireccion.SelectedIndex = 0

        Me.TxtNumDocRemitente.Text = ""
        Me.TxtNroDocContacto.Text = ""
        Me.TxtTelfCliente.Text = ""

        Me.CboRemitente.DataSource = Nothing
        Me.CboRemitente.Items.Clear()
        Me.CboRemitente.Items.Add(" (SELECCIONE)")
        Me.CboRemitente.SelectedIndex = 0

        Me.CboContacto.DataSource = Nothing
        Me.CboContacto.Items.Clear()
        Me.CboContacto.Items.Add(" (SELECCIONE)")
        Me.CboContacto.SelectedIndex = 0
    End Sub

    Sub LimpiarDatosCliente()
        '*******Items carga Asegurada**********
        Me.RemoveItemsCargAseg()
        '*******Datos Cliente******************
        Me.LimpiarCliente()
        '**************************************
        'LblTipoComprobante.Text = "BOLETA"
        TipoComprobante = 2
        If CboProducto.SelectedValue <> 6 Then
            LblPasajero.Visible = False
        End If
        'CboContacto.Enabled = False

        TxtDescuento.Text = ""
        GrpDescuento.Enabled = True
        RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
        If ChkArticulos.Checked = True Then
            ChkSobres.Visible = False
            txtCantidadSobres.Visible = False
            TxtMontoBase.Visible = False
            txtTotalSobre.Visible = False
            LblMontoBase.Visible = False
            TipoGrid_ = FormatoGrid.BULTO
            Me.DiseñaGrdDetalleVenta()
            FormatoGrdDetalleVenta()
        Else
            'Me.ResetCalculo()
            If (CboTipo.SelectedValue = ID_TIPO_CREDITO) Then Me.ResetCalculo()
        End If

        ChkArticulos.Checked = False : ChkArticulos.Enabled = False
        ChkM3.Checked = False

        If CboProducto.SelectedValue <> 6 Then
            TipoGrid_ = FormatoGrid.BULTO
            Me.DiseñaGrdDetalleVenta()
            FormatoGrdDetalleVenta()
        End If

        AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged

        If GrdDetalleVenta.Rows.Count = 5 Then
            GrdDetalleVenta.Rows.RemoveAt(4)
        End If

        If Not CboSubCuenta.Focused Then
            If CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.Items.Add(" (SELECCIONE)")
                Me.CboDireccion2.SelectedIndex = 0
            ElseIf CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.Items.Add("AGENCIA")
                Me.CboDireccion2.SelectedIndex = 0
            Else
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.SelectedIndex = -1
            End If
        End If

    End Sub
    Sub LimpiaDatosCliente()
        '*******Items carga Asegurada**********
        Me.RemoveItemsCargAseg()
        '*******Datos Cliente******************
        TipoComprobante = 2
        If CboProducto.SelectedValue <> 6 Then
            LblPasajero.Visible = False
        End If
        'CboContacto.Enabled = False

        TxtDescuento.Text = ""
        GrpDescuento.Enabled = True
        RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
        If ChkArticulos.Checked = True Then
            ChkSobres.Visible = False
            txtCantidadSobres.Visible = False
            TxtMontoBase.Visible = False
            txtTotalSobre.Visible = False
            LblMontoBase.Visible = False
            TipoGrid_ = FormatoGrid.BULTO
            Me.DiseñaGrdDetalleVenta()
            FormatoGrdDetalleVenta()
        Else
            'Me.ResetCalculo()
            If (CboTipo.SelectedValue = ID_TIPO_CREDITO) Then Me.ResetCalculo()
        End If

        ChkArticulos.Checked = False : ChkArticulos.Enabled = False
        ChkM3.Checked = False

        If CboProducto.SelectedValue <> 6 Then
            TipoGrid_ = FormatoGrid.BULTO
            Me.DiseñaGrdDetalleVenta()
            FormatoGrdDetalleVenta()
        End If

        AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged

        If GrdDetalleVenta.Rows.Count = 5 Then
            GrdDetalleVenta.Rows.RemoveAt(4)
        End If

        If Not CboSubCuenta.Focused Then
            If CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.Items.Add(" (SELECCIONE)")
                Me.CboDireccion2.SelectedIndex = 0
            ElseIf CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.Items.Add("AGENCIA")
                Me.CboDireccion2.SelectedIndex = 0
            Else
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.SelectedIndex = -1
            End If
        End If

        EliminarItemVenta("SEGURO", GrdDetalleVenta)
        EliminarItemVenta("ENTREGA", GrdDetalleVenta)
    End Sub

    Dim es_carga_asegurada As Boolean
    Sub RemoveItemsCargAseg()
        'If es_carga_asegurada Then
        objComprobanteAsegurada = Nothing
        ReDim objComprobanteAsegurada(19)
        es_carga_asegurada = False
        'End If
    End Sub

#End Region

#Region "Funciones Validaciones"

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

    'Funcion Control de Teclas
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.Enter And Not Grbdestino.Focused Then
                If CboTipo.SelectedValue <> 2 AndAlso Me.TxtCliente.Focused AndAlso Me.TxtCliente.Text.Trim.Length > 0 Then
                    Buscar()
                ElseIf CboTipo.SelectedValue = 2 AndAlso Me.TxtCliente.Focused AndAlso Me.TxtCliente.Text.Trim.Length > 0 Then
                    BuscarClienteCredito()
                ElseIf Me.TxtConsignado.Focused AndAlso Me.TxtConsignado.Text.Trim.Length > 0 Then 'AndAlso idUnidadAgencias >= 0 Then
                    BuscarConsignado()
                    'ElseIf Me.CboDireccion.Focused AndAlso Me.CboRemitente.Enabled AndAlso Me.CboRemitente.Items.Count > 1 AndAlso Me.CboRemitente.SelectedIndex = 0 AndAlso Me.CboDireccion.SelectedIndex > 0 Then
                    'Me.DespliegaRemitente()
                ElseIf Me.CboDireccion.Focused Then
                    If Me.CboDireccion.Items.Count > 0 And Not (Me.CboDireccion.SelectedValue Is Nothing) Then
                        Dim intValor As Integer = Me.CboDireccion.SelectedValue
                        Me.CboDireccion.SelectedIndex = 0
                        Me.CboDireccion.SelectedValue = intValor
                    End If
                    If Me.CboRemitente.Enabled AndAlso Me.CboRemitente.Items.Count > 1 AndAlso Me.CboRemitente.SelectedIndex = 0 AndAlso Me.CboDireccion.SelectedIndex > 0 Then
                        Me.DespliegaRemitente()
                    ElseIf Me.CboDireccion.DroppedDown = False Then
                        SendKeys.Send("{Tab}")
                    End If
                ElseIf Me.CboDireccion2.Focused Then
                    If Me.CboDireccion2.Items.Count > 0 And Not (Me.CboDireccion2.SelectedValue Is Nothing) Then
                        Dim intValor As Integer = Me.CboDireccion2.SelectedValue
                        Me.CboDireccion2.SelectedIndex = 0
                        Me.CboDireccion2.SelectedValue = intValor
                    End If
                    If Me.CboDireccion2.DroppedDown = False Then
                        SendKeys.Send("{Tab}")
                    End If
                    'ElseIf Me.CboRemitente.Focused AndAlso Me.CboContacto.Enabled AndAlso Me.CboContacto.Items.Count > 1 AndAlso Me.CboContacto.SelectedIndex = 0 AndAlso Me.CboRemitente.SelectedIndex > 0 Then
                    'Me.DespliegaContacto()
                ElseIf Me.CboRemitente.Focused Then
                    If Me.CboRemitente.Items.Count > 0 And Not (Me.CboRemitente.SelectedValue Is Nothing) Then
                        Dim intValor As Integer = Me.CboRemitente.SelectedValue
                        Me.CboRemitente.SelectedIndex = 0
                        Me.CboRemitente.SelectedValue = intValor
                    End If
                    If Me.CboContacto.Enabled AndAlso Me.CboContacto.Items.Count > 1 AndAlso Me.CboContacto.SelectedIndex = 0 AndAlso Me.CboRemitente.SelectedIndex > 0 Then
                        Me.DespliegaContacto()
                    ElseIf CboRemitente.DroppedDown = False Then
                        SendKeys.Send("{Tab}")
                    End If
                ElseIf Me.CboContacto.Focused Then
                    If Me.CboContacto.Items.Count > 0 And Not (Me.CboContacto.SelectedValue Is Nothing) Then
                        Dim intValor As Integer = Me.CboContacto.SelectedValue
                        Me.CboContacto.SelectedIndex = 0
                        Me.CboContacto.SelectedValue = intValor
                    End If
                    If CboContacto.DroppedDown = False Then
                        SendKeys.Send("{Tab}")
                    End If
                ElseIf Me.CboCiudad_Origen.Focused Then
                    Me.DespliegaCboAgencia_Origen()
                ElseIf txtNroNroGuia.Focused AndAlso Me.txtNroNroGuia.Text.Trim.Length > 0 Then
                    'hlamas 11-03-2019
                    'If ValidarCodigoEAN13(Me.txtNroNroGuia.Text.Trim) Then
                    '    'Me.FnConsultar()
                    'Else
                    '    MessageBox.Show("Ingrese un Numero de Guía Valido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    '    txtNroNroGuia.Text = ""
                    '    txtNroNroGuia.Focus()
                    'End If
                ElseIf Me.CboSubCuenta.Focused Then
                    If Me.CboSubCuenta.Items.Count > 0 Then
                        If Me.CboSubCuenta.SelectedIndex > 0 Then
                            CboSubCuenta.SelectedValue = 999
                            CboDireccion.DroppedDown = False
                            CboDireccion2.DroppedDown = False
                        End If
                    End If
                ElseIf Me.TxtGuia.Focused Then
                    Me.Cursor = Cursors.AppStarting
                    Dim iGuia As Long = Me.TxtGuia.Text
                    Listar(iGuia)
                    Me.Cursor = Cursors.Default
                ElseIf Me.TxtDocumento.Focused Then
                    Me.Cursor = Cursors.AppStarting
                    Dim sDocumento As String = Me.TxtDocumento.Text
                    Listar(Me.DtpFechaInicio.Text, Me.DtpFechaFin.Text, sDocumento)
                    Me.Cursor = Cursors.Default
                Else
                    SendKeys.Send("{Tab}")
                End If
                'ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                '    If Me.TabGuia.SelectedIndex = 1 AndAlso Me.Grbdestino.Enabled Then
                '        Dim sender As Object
                '        Dim e As EventArgs
                '        Me.BtnGraba_Click(sender, e)
                '        Me.Cursor = Cursors.Default
                '    End If
            Else
                If iOpcion <= 1 Then
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                Else
                    If msg.WParam.ToInt32 = Keys.Tab Or msg.WParam.ToInt32 = Keys.Enter Then
                        flat = MyBase.ProcessCmdKey(msg, KeyData)
                    Else
                        flat = True
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return flat
    End Function

    Function ValidarCodigoEAN13(strNroGuia As String) As Boolean
        Dim Longitud As Integer = 0
        Dim DigitoControl As Integer = 0
        Dim Pares As Integer = 0
        Dim Impares As Integer = 0
        Dim Resultado As Integer = 0
        Try
            Longitud = Len(strNroGuia)
            If Longitud <= 13 Then
                strNroGuia = strNroGuia.PadLeft(13, "0")
                Longitud = Len(strNroGuia)
            Else
                Return False
            End If
            DigitoControl = strNroGuia.Substring(Longitud - 1, 1)
            strNroGuia = strNroGuia.Substring(0, Longitud - 1)

            For i As Integer = 1 To Len(strNroGuia)
                If i Mod 2 = 0 Then
                    Pares = Pares + Convert.ToInt32(strNroGuia.Substring(i - 1, 1))
                Else
                    Impares = Impares + Convert.ToInt32(strNroGuia.Substring(i - 1, 1))
                End If
            Next

            Pares = Pares * 3
            Resultado = Pares + Impares
            Resultado = Resultado Mod 10

            Resultado = 10 - Resultado

            If Resultado = 10 Then
                Resultado = 0
            End If

            If Resultado = DigitoControl Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

#End Region

#Region "IMPRESIONES"

    Dim p_agencia, v_iDestino, v_iCredito, v_iDomicilio, v_iAgencia, p_domicilio, p_contado, p_destino, p_credito As String
    Public Function ImprimirGuiaEnvio() As Boolean
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        Dim obj As New Imprimir
        Try
            ObjRptGuiaEnvio.p_Hora_Guia = fnGetHora()
            'Dim objImpresora As New dtoVentaCargaContado
            If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Then
                ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3
            End If

            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 3)
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            Dim flag As Boolean
            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamaño")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            Dim iLong As Integer = IIf(iTamaño = 0, 22, iTamaño)

            y = iLong * pagina + 2
            i += 1

            If flag Then
                obj.Inicializar()
                obj.Impresora = sImpresora
                obj.Superior = iSuperior
                obj.Izquierda = Iizquierda

                If es_carga_asegurada Then
                    obj.EscribirLinea(y, 22, ObjRptGuiaEnvio.p_NroGUIA & v_ca)
                Else
                    obj.EscribirLinea(y, 22, ObjRptGuiaEnvio.p_NroGUIA)
                End If

                obj.EscribirLinea(y, 82, ObjRptGuiaEnvio.p_codigo_iata_ori)
                obj.EscribirLinea(y, 92, ObjRptGuiaEnvio.p_codigo_iata_desti)
                obj.EscribirLinea(y + 2, 0, ObjRptGuiaEnvio.p_ruc)
                obj.EscribirLinea(y + 5, 0, ObjRptGuiaEnvio.P_REMITENTE)

                If ObjRptGuiaEnvio.P_DIRECCION_REMI.ToString.Length > 40 Then
                    obj.EscribirLinea(y + 3, 0, ObjRptGuiaEnvio.P_DIRECCION_REMI.ToString.Substring(0, 41))
                    obj.EscribirLinea(y + 4, 0, ObjRptGuiaEnvio.P_DIRECCION_REMI.ToString.Substring(41))
                Else
                    If Trim(ObjRptGuiaEnvio.P_DIRECCION_REMI) <> "(SELECCIONE)" Then
                        obj.EscribirLinea(y + 6, 0, ObjRptGuiaEnvio.P_DIRECCION_REMI)
                    End If
                End If
                    obj.EscribirLinea(y + 5, 59, ObjRptGuiaEnvio.P_NOMBRES_DESTI)
                    obj.EscribirLinea(y + 6, 59, ObjRptGuiaEnvio.P_DIRECCION_DESTI)

                    obj.EscribirLinea(y + 2, 33, p_domicilio)
                    obj.EscribirLinea(y + 2, 43, p_agencia)
                    obj.EscribirLinea(y + 2, 54, p_contado)
                    obj.EscribirLinea(y + 2, 64, p_destino)
                    obj.EscribirLinea(y + 2, 76, p_credito)

                    'obj.EscribirLinea(ObjRptGuiaEnvio.P_CARGO)
                    obj.EscribirLinea(y + 9, 0, ObjRptGuiaEnvio.p_contacto)
                    'obj.EscribirLinea(y + 9, 0, "FACTURAR A: " & ObjRptGuiaEnvio.P_NOMBRES_DESTI)

                    obj.EscribirLinea(y + 8, 29, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI)
                    obj.EscribirLinea(y + 8, 59, ObjRptGuiaEnvio.P_PROVINCIA)
                    obj.EscribirLinea(y + 8, 84, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI)

                    If Not (strNroGuias_Remision Is Nothing) Then
                        If Val(strNroGuias_Remision.Trim.Length) < 126 Then
                            strNroGuias_Remision = strNroGuias_Remision & Space(126 - Len(strNroGuias_Remision.Trim))
                        End If
                        strNroGuias_Remision = Mid(strNroGuias_Remision.Trim, 1, 126)

                        Dim iGuiones As Integer
                        iGuiones = DevuelveGuiones(strNroGuias_Remision)
                        If iGuiones >= 7 Then       '3 lineas
                            obj.EscribirLinea(y + 11, 0, Trim(Mid(strNroGuias_Remision, 1, 42)))
                            obj.EscribirLinea(y + 12, 0, Trim(Mid(strNroGuias_Remision, 43, 42)))
                            obj.EscribirLinea(y + 13, 0, Trim(Mid(strNroGuias_Remision, 86, 42)))
                        ElseIf iGuiones >= 4 Then   '2 lineas
                            obj.EscribirLinea(y + 11, 0, Trim(Mid(strNroGuias_Remision, 1, 42)))
                            obj.EscribirLinea(y + 12, 0, Trim(Mid(strNroGuias_Remision, 43, 42)))
                        Else                        '1 linea
                            obj.EscribirLinea(y + 11, 0, Trim(Mid(strNroGuias_Remision, 1, 42)))
                        End If
                    End If

                    'obj.EscribirLinea(y + 17, 26, Format(CDate(ObjRptGuiaEnvio.P_FECHA_GUIA), "dd     MM      yy"))
                    obj.EscribirLinea(y + 17, 26, Format(CDate(FechaServidor.ToString.Substring(0, 10)), "dd     MM      yy"))

                    obj.EscribirLinea(y + 13, 49, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_BULTOS), 2))
                    obj.EscribirLinea(y + 13, 57, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_PESO), 2))
                    obj.EscribirLinea(y + 13, 65, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_VOLUMEN), 2))
                    obj.EscribirLinea(y + 13, 78, FechaServidor.ToString.Substring(0, 10))
                    obj.EscribirLinea(y + 13, 92, ObjRptGuiaEnvio.p_Hora_Guia)
                    If ObjRptGuiaEnvio.P_TOTAL_SOBRES > 0 Then
                        obj.EscribirLinea(y + 14, 57, "Nº SOBRES " & ObjRptGuiaEnvio.P_TOTAL_SOBRES)
                    End If

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

    Public Function fnImprimirEtiquetas() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            Dim strAgenciaDestino As String = dtoVentaCargaContado.AgenciaAbreviado(ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)

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
            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String

            'hlamas 22-03-2016
            'strCargo = IIf(Me.ChkCargo.Checked, "CARGO", "")
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")
            Dim strTipo As String = ObtieneTipoComprobante(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
            Dim strAgeDom As String
            Dim strProducto As String = ObtieneProducto(Me.CboProducto.SelectedValue)

            While i <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                strAgeDom = ObjCODIGOBARRA.AGEDOM & "  " & strTipo
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(i)(0).ToString
                'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
                'ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")
                'prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
                prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & strAgeDom & "^FS")
                prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
                prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
                prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
                'hlamas 26-08-2015
                'prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
                'prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")

                strProducto = strProducto & "  " & strAgenciaDestino
                strProducto = strProducto.Trim
                prn.EscribeLinea("^FT21,165^AAN,18,10^FH\^FD" & strProducto & "^FS")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & strFecha & "^FS")
                prn.EscribeLinea("^FT255,188^AAN,18,10^FH\^FDTEPSA^FS")
                prn.EscribeLinea("^FT330,188^AAN,20,12^FH\^FD" & strCargo & "^FS")

                'hlamas 26-08-2015
                'prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")

                prn.EscribeLinea("^PQ1,0,1,Y")
                prn.EscribeLinea("^XZ")
                prn.EscribeLinea(cadena)
                'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                j = j + 1
                i += 1
            End While
            prn.FinDoc()
            '
            'ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            'ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.tipo = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            ObjCODIGOBARRA.id = Me.DgvLista.CurrentRow.Cells("idfactura").Value
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

            If I <= 0 Then I = 1

            'ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            'ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.tipo = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            ObjCODIGOBARRA.id = Me.DgvLista.CurrentRow.Cells("idfactura").Value
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
            Dim strAgenciaDestino As String = dtoVentaCargaContado.AgenciaAbreviado(ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)

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

            If j <= 0 Then j = 1
            '
            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String

            'hlamas 22-03-2016
            'strCargo = IIf(Me.ChkCargo.Checked, "CARGO", "")
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")
            Dim strTipo As String = ObtieneTipoComprobante(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
            Dim strAgeDom As String
            Dim strProducto As String = ObtieneProducto(Me.CboProducto.SelectedValue)
            While I <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                strAgeDom = ObjCODIGOBARRA.AGEDOM & "  " & strTipo
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(I)(0).ToString
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                prn.EscribeLinea("A30,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                prn.EscribeLinea("A317,47,0,3,1,1,N,""" & strAgeDom & """")
                'prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)

                'hlamas 26-08-2015
                'prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
                'prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")

                strProducto = strProducto & "  " & strAgenciaDestino
                strProducto = strProducto.Trim
                prn.EscribeLinea("A30,140,0,3,1,1,N,""" & strProducto & """")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("A30,163,0,1,1,1,N,""" & strFecha & """")
                prn.EscribeLinea("A230,163,0,1,1,1,N,""JOTASYS""")
                prn.EscribeLinea("A300,163,0,2,1,1,N,""" & strCargo & """")

                'prn.EscribeLinea("A271,163,0,1,1,1,N,""TEPSAC""")
                'prn.EscribeLinea("A341,163,0,2,1,1,N,""" & strCargo & """")

                'hlamas 26-08-2015
                'prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")

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
            'ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            'ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.tipo = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            ObjCODIGOBARRA.id = Me.DgvLista.CurrentRow.Cells("idfactura").Value
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
                    iTamaño = dt.Rows(0).Item("tamaño")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            If flag Then
                obj.Inicializar()
                obj.Superior = iSuperior
                obj.Izquierda = Iizquierda
                obj.Impresora = sImpresora

                Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
                Dim iLong As Integer
                If Me.CboProducto.SelectedValue <> 8 Then
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
                    obj.EscribirLinea(y + 8, 13, ObjIMPRESIONFACT_BOL.xConsignado)
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
                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto) = 0 Then
                        obj.EscribirLinea(y + 14, 13, ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                        obj.EscribirLinea(y + 14, 23, "SOBRES")
                    End If

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

                    obj.EscribirLinea(y + 21, 85, "S/.")
                    obj.EscribirLinea(y + 22, 85, "S/.")
                    obj.EscribirLinea(y + 23, 85, "S/.")

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

                    obj.EscribirLinea(y, 66, Me.CboCiudad_Origen.Text)
                    obj.EscribirLinea(y, 108, ObjIMPRESIONFACT_BOL.xDestino)

                    If Me.CboTipoTarifa.SelectedValue = 1 Then
                        obj.EscribirLinea(y + 2, 21, "X")
                    ElseIf Me.CboTipoTarifa.SelectedValue = 2 Then
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

                    obj.EscribirLinea(y + 5, 16, ObjIMPRESIONFACT_BOL.xConsignado) 'ya viene Concatenado
                    'obj.EscribirLinea(y + 5, 108, TxtNroDocConsignado.Text.Trim)
                    obj.EscribirLinea(y + 5, 108, ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO) 'GrdNConsignado("Nº Documento", 0).Value
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

                    If Not Me.ChkArticulos.Checked And Not Me.ChkM3.Checked Then
                        If Val(GrdDetalleVenta("Sub Neto", 3).Value) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(GrdDetalleVenta("Sub Neto", 3).Value), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    ElseIf Me.ChkM3.Checked Then
                        If Val(Me.txtTotalSobre.Text) > 0 Then
                            obj.EscribirLinea(y + 13, 23, "SOBRES")
                            obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                            obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If

                        If Val(Me.TxtMontoBase.Text) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.TxtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    ElseIf Me.ChkArticulos.Checked Then
                        If Val(Me.txtTotalSobre.Text) > 0 Then
                            obj.EscribirLinea(y + 13, 23, "SOBRES")
                            obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                            obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If

                        If Val(Me.TxtMontoBase.Text) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.TxtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
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

    Dim iCliente As Integer = 0
    Public Function ImprimirBoleta() As Boolean
        Dim obj As New Imprimir
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        Try
            Dim HoraSistema As String = fnGetHora()
            Dim GLOSA2 As String = ""
            Dim PESO As String = ""
            Dim PARCIAL As String = ""
            Dim CANTIDAD As String = ""

            Dim fecha_Systema As String() = Split(dtoUSUARIOS.m_sFecha, "/")
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
            ''ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(GrdDetalleVenta(7, 2).Value)
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
                    iTamaño = dt.Rows(0).Item("tamaño")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            If flag Then
                obj.Inicializar()
                obj.Impresora = sImpresora
                obj.Superior = iSuperior
                obj.Izquierda = Iizquierda

                Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0

                Dim ilong As Integer

                Dim sConsignado As String = ObjIMPRESIONFACT_BOL.xConsignado.Trim.Replace(";", ",")
                sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)

                If Me.CboProducto.SelectedValue <> 8 Then
                    ilong = IIf(iTamaño = 0, 18, iTamaño)
                    y = ilong * pagina + 4
                    y += 1
                    i += 1

                    obj.EscribirLinea(y, 6, ObjIMPRESIONFACT_BOL.xOrigen)
                    obj.EscribirLinea(y + 1, 6, ObjIMPRESIONFACT_BOL.xfecha_factura)
                    obj.EscribirLinea(y + 2, 6, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 3, 6, ObjIMPRESIONFACT_BOL.xConsignado)
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
                    obj.EscribirLinea(y + 3, 89, ObjIMPRESIONFACT_BOL.xConsignado)
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
                    ilong = IIf(iTamaño = 0, 36, iTamaño)
                    y = ilong * pagina + 8
                    y += 1
                    i += 1

                    obj.EscribirLinea(y, 8, dia & " DE " & MonthName(Mes).ToString.ToUpper)
                    obj.EscribirLinea(y, 33, Anio)

                    obj.EscribirLinea(y, 66, Me.CboCiudad_Origen.Text)
                    obj.EscribirLinea(y, 108, ObjIMPRESIONFACT_BOL.xDestino)

                    If Me.CboTipoTarifa.SelectedValue = 1 Then
                        obj.EscribirLinea(y + 2, 21, "X")
                    ElseIf Me.CboTipoTarifa.SelectedValue = 2 Then
                        obj.EscribirLinea(y + 2, 31, "X")
                    End If

                    If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                        obj.EscribirLinea(y + 2, 67, "X")
                    ElseIf ObjVentaCargaContado.v_IDTIPO_ENTREGA = 0 Then
                        obj.EscribirLinea(y + 2, 77, "X")
                    End If

                    obj.EscribirLinea(y + 2, 108, ObjIMPRESIONFACT_BOL.TelefonoCliente(iCliente))

                    obj.EscribirLinea(y + 3, 16, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 3, 108, ObjIMPRESIONFACT_BOL.xRuc)
                    obj.EscribirLinea(y + 4, 16, ObjIMPRESIONFACT_BOL.xDireccionRemitente)

                    obj.EscribirLinea(y + 5, 16, sConsignado)
                    'obj.EscribirLinea(y + 5, 108, TxtNroDocConsignado.Text.Trim)
                    obj.EscribirLinea(y + 5, 108, ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO) 'GrdNConsignado("Nº Documento", 0).Value
                    obj.EscribirLinea(y + 6, 16, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    ' obj.EscribirLinea(y + 7, 108, TxtTelfConsignado.Text.Trim)

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

                    If Not Me.ChkArticulos.Checked And Not Me.ChkM3.Checked Then
                        If Val(GrdDetalleVenta("Sub Neto", 3).Value) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(GrdDetalleVenta("Sub Neto", 3).Value), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    ElseIf Me.ChkM3.Checked Then
                        If Val(Me.txtTotalSobre.Text) > 0 Then
                            obj.EscribirLinea(y + 13, 23, "SOBRES")
                            obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                            obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If

                        If Val(Me.TxtMontoBase.Text) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.TxtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    ElseIf Me.ChkArticulos.Checked Then
                        If Val(Me.txtTotalSobre.Text) > 0 Then
                            obj.EscribirLinea(y + 13, 23, "SOBRES")
                            obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                            obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If

                        If Val(Me.TxtMontoBase.Text) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.TxtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    End If


                    'obj.EscribirLinea(y + 17, 120, ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(10, " "))
                    'obj.EscribirLinea(y + 18, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###0.00").PadLeft(10, " "))
                    obj.EscribirLinea(y + 17, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###0.00").PadLeft(10, " "))

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
#End Region

#Region "FUNCIONES"

    Sub ListarProducto(ByVal opcion As Integer)
        Try
            Dim obj As New dtoVentaCargaContado
            Dim dt As DataTable = obj.ListarProceso(opcion)
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged

            Dim dtp As New DataTable
            dtp.Columns.Add("idprocesos").DataType = GetType(Integer)
            dtp.Columns.Add("nombre_secundario").DataType = GetType(String)

            For Each row As DataRow In dt.Rows
                If (CboTipo.SelectedValue = 1) Then '-->PCE
                    'If (row("idprocesos") <> ID_PRODUCTO_TEPSA_COURIER) Then '-->para PCE no carga el producto TEPSA CURRIER
                    dtp.Rows.Add(row("idprocesos"), row("nombre_secundario"))
                    'End If
                Else '-->CREDITO
                dtp.Rows.Add(row("idprocesos"), row("nombre_secundario"))
                End If
            Next

            Me.CboProducto.DataSource = dtp
            Me.CboProducto.DisplayMember = "nombre_secundario"
            Me.CboProducto.ValueMember = "idprocesos"
            Me.CboProducto.SelectedIndex = 0

            'Me.CboProducto.DataSource = dt
            'Me.CboProducto.DisplayMember = "nombre_secundario"
            'Me.CboProducto.ValueMember = "idprocesos"
            'Me.CboProducto.SelectedIndex = 0
            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            Dim sender As Object
            Dim e As EventArgs
            CboProducto_SelectedIndexChanged(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub DespliegaRemitente()
        Me.CboRemitente.DroppedDown = True
        Me.CboRemitente.Focus()
        Me.Cursor = Cursors.Default
    End Sub

    Sub DespliegaContacto()
        Me.CboContacto.DroppedDown = True
        Me.CboContacto.Focus()
        Me.Cursor = Cursors.Default
    End Sub

    Sub DespliegaCboAgencia_Origen()
        With CboAgencia_Origen
            If bNuevo Then
                If .Items.Count > 2 Then
                    .SelectedIndex = 0
                    .DroppedDown = True
                    .Focus()
                    Me.Cursor = Cursors.Default
                ElseIf .Items.Count = 1 Then
                    .SelectedIndex = 0
                    .Focus()
                Else
                    .SelectedIndex = 1
                    .Focus()
                End If
            End If
        End With
    End Sub

    Sub ConvertirTipoEntrega(ByVal tipo As Integer)
        If tipo = TipoEntrega.Agencia Then
            Me.CboDireccion2.DataSource = Nothing
            Me.CboDireccion2.Items.Clear()
            Me.CboDireccion2.Items.Add("AGENCIA")
            Me.CboDireccion2.SelectedIndex = 0
        ElseIf tipo = TipoEntrega.Domicilio Then
            If dtDireccion2 IsNot Nothing Then
                Me.CboDireccion2.DataSource = dtDireccion2
                Me.CboDireccion2.ValueMember = "iddireccion_consignado"
                Me.CboDireccion2.DisplayMember = "direccion"

                If Me.CboDireccion2.Items.Count = 2 Then
                    Me.CboDireccion2.SelectedIndex = 1
                Else
                    Me.CboDireccion2.SelectedIndex = 0
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
        End If
    End Sub

#End Region

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

    Private Sub txtNroNroGuia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroNroGuia.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNroNroGuia_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNroNroGuia.Validating
        txtNroNroGuia.Text = RellenoRight(NroDigitos_Guias, txtNroNroGuia.Text.Trim)
    End Sub
#End Region
    Private Sub CboAgencia_Origen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAgencia_Origen.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.AppStarting
            If Not IsReference(CboAgencia_Origen.SelectedValue) Then
                If iOpcion = 2 Then
                    RemoveHandler CboAgencia_Origen.SelectedIndexChanged, AddressOf CboAgencia_Origen_SelectedIndexChanged
                    CboAgencia_Origen.SelectedValue = iAgencia
                    AddHandler CboAgencia_Origen.SelectedIndexChanged, AddressOf CboAgencia_Origen_SelectedIndexChanged
                    Me.Cursor = Cursors.Default
                    Return
                End If
                'dtoUSUARIOS.m_iIdAgencia = CboAgencia_Origen.SelectedValue
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtFechaGuia_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaGuia.Enter

    End Sub
    Private Sub txtFechaGuia_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaGuia.ValueChanged
        If iOpcion = 2 AndAlso Not IsNothing(sFechaGuia) Then
            txtFechaGuia.Text = sFechaGuia
        ElseIf iOpcion = 1 And bNuevo Then
            Me.txtFechaGuia.Format = 2
        End If
    End Sub

    'Con Documento nuevas funciones
    Sub Buscar(ByVal scliente As String, ByVal iopcion As Integer, ByVal m_idciudad As Integer, ByVal idUnidadAgencia As Integer)
        Try
            Dim frm As New FrmCliente2
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.Buscar(scliente, iopcion, m_idciudad, idUnidadAgencia)
            dtCliente = ds.Tables(0)
            bClienteNuevo = True

            If ds.Tables(0).Rows.Count = 1 Then
                Me.Mostrar(ds)
            Else
                MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            sDocCliente = TxtCliente.Text.Trim
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

    'Sin Documento
    Sub Buscar(ByVal idPersona As Integer, ByVal m_idciudad As Integer, ByVal idUnidadAgencia As Integer)
        Try
            Dim frm As New FrmCliente2
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.Buscar(idPersona, m_idciudad, idUnidadAgencia)
            dtCliente = ds.Tables(0)
            bClienteNuevo = True

            'If Not bNuevo Then Return

            If ds.Tables(0).Rows.Count = 1 Then
                Me.Mostrar(ds)
            Else
                 MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            sDocCliente = TxtCliente.Text.Trim

        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

    '-----------NUEVO CODIGO NCONSIGNADO--------   
    Sub DiseñaGrdNConsignado()
        Try

            Dim Camp0 As String = "", camp1 = "", camp2 = "", camp3 = "", camp4 = "", camp5 = "", camp6 = "", camp7 = "", camp8 = "", camp9 = ""
            Camp0 = "IDConsignado" : camp1 = "N. Doc." : camp2 = "Nombres" : camp3 = "Telefono"
            camp4 = "nombre" : camp5 = "tipo" : camp6 = "apepat" : camp7 = "apemat" : camp8 = "Modificado" : camp9 = "IDVentaConsignado"

            With GrdNConsignado
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
                .RowHeadersWidth = 10
                .DefaultCellStyle.WrapMode = DataGridViewTriState.False
                '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
                '.DefaultCellStyle.SelectionForeColor = Color.Black

                Dim col0 As New DataGridViewTextBoxColumn
                With col0
                    .HeaderText = Camp0
                    .Name = Camp0
                    .DataPropertyName = Camp0
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    .Visible = False
                End With
                .Columns.Add(col0)

                Dim col1 As New DataGridViewTextBoxColumn
                With col1
                    .HeaderText = "N. Doc."
                    .Name = "Nº Documento"
                    .DataPropertyName = "Nº Documento"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    '.Width = 75
                End With
                .Columns.Add(col1)


                Dim col2 As New DataGridViewTextBoxColumn
                With col2
                    .HeaderText = camp2
                    .Name = camp2
                    .DataPropertyName = camp2
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    '.Width = 300
                End With
                .Columns.Add(col2)


                Dim col3 As New DataGridViewTextBoxColumn
                With col3
                    .HeaderText = camp3
                    .Name = camp3
                    .DataPropertyName = camp3
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                End With
                .Columns.Add(col3)

                Dim col4 As New DataGridViewTextBoxColumn
                With col4
                    .HeaderText = camp4
                    .Name = camp4
                    .DataPropertyName = camp4
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Visible = False
                End With
                .Columns.Add(col4)

                Dim col5 As New DataGridViewTextBoxColumn
                With col5
                    .HeaderText = camp5
                    .Name = camp5
                    .DataPropertyName = camp5
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Visible = False
                End With
                .Columns.Add(col5)

                Dim col6 As New DataGridViewTextBoxColumn
                With col6
                    .HeaderText = camp6
                    .Name = camp6
                    .DataPropertyName = camp6
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Visible = False
                End With
                .Columns.Add(col6)

                Dim col7 As New DataGridViewTextBoxColumn
                With col7
                    .HeaderText = camp7
                    .Name = camp7
                    .DataPropertyName = camp7
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Visible = False
                End With
                .Columns.Add(col7)

                Dim col8 As New DataGridViewTextBoxColumn
                With col8
                    .HeaderText = camp8
                    .Name = camp8
                    .DataPropertyName = camp8
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Visible = False
                End With
                .Columns.Add(col8)

                Dim col9 As New DataGridViewTextBoxColumn
                With col9
                    .HeaderText = camp9
                    .Name = camp9
                    .DataPropertyName = camp9
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Visible = False
                End With
                .Columns.Add(col9)
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub LimpiarNConsignados()
        ObjVentaCargaContado.v_IDCONTACTO_DESTINO = ""
        ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = ""
        ObjVentaCargaContado.NombreConsignado = ""
        ObjVentaCargaContado.apellPatConsig = ""
        ObjVentaCargaContado.apellMatConsig = ""
        ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO = ""
        ObjVentaCargaContado.ID_TipoDocConsig = ""
        ObjVentaCargaContado.TelfConsignado = ""
        ObjVentaCargaContado.NombConsignado_mod = ""
        ObjVentaCargaContado.IDVentaConsignado = ""
    End Sub

    'ACTUALIZA O REGISTRA NUEVO CONSIGNADO
    Dim indice As Integer = 0    
    'Dim bExiste As Boolean
    Dim iNroDocumentoTag As Integer
    Public DTNconsignado As DataTable

    Dim row As Integer
    Private Sub ActualizarGrid(ByVal ds As DataSet)
        row = GrdNConsignado.Rows.Count()
        GrdNConsignado.Rows.Add()
        GrdNConsignado("IDConsignado", row).Value = iIDConsignado
        GrdNConsignado("Nº Documento", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nrodocumento")), "", ds.Tables(0).Rows(0).Item("nrodocumento"))
        GrdNConsignado("Nombres", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nombres")), "", ds.Tables(0).Rows(0).Item("nombres"))
        GrdNConsignado("Telefono", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("telefono")), "", ds.Tables(0).Rows(0).Item("telefono"))
        GrdNConsignado("nombre", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nombre")), "", ds.Tables(0).Rows(0).Item("nombre"))
        GrdNConsignado("tipo", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("tipo")), "", ds.Tables(0).Rows(0).Item("tipo"))
        GrdNConsignado("apepat", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("apepat")), "", ds.Tables(0).Rows(0).Item("apepat"))
        GrdNConsignado("apemat", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("apemat")), "", ds.Tables(0).Rows(0).Item("apemat"))
        GrdNConsignado("Modificado", row).Value = "0"
        GrdNConsignado("IDVentaConsignado", row).Value = "0"
        Me.TxtConsignado.Text = ""
        RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
        If Me.TxtNroDocCliente.Text.Trim = GrdNConsignado("Nº Documento", row).Value AndAlso Me.TxtNroDocCliente.Text.Trim <> "" Then Me.ChkCliente2.Checked = True Else Me.ChkCliente2.Checked = False
        AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
        '=======================================================================================
    End Sub

    Sub EliminarItem()
        Me.GrdNConsignado.Rows.Remove(Me.GrdNConsignado.CurrentRow)
        If ChkCliente2.Checked Then ChkCliente2.Checked = False
    End Sub

    '19-10-2011
    'Dim iIndice As Integer             

    '17112011

    Private Sub RbtNombre3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtNombre3.CheckedChanged
        Me.TxtConsignado.Text = ""
        If CType(sender, RadioButton).Name = "RbtDocumento" Then
            Me.TxtConsignado.MaxLength = 11
        Else
            Me.TxtConsignado.MaxLength = 50
        End If
        Me.TxtCliente.Focus()
    End Sub

    Private Sub RbtDocumento3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtDocumento3.CheckedChanged
        Me.TxtConsignado.Text = ""
        If CType(sender, RadioButton).Name = "RbtDocumento" Then
            Me.TxtConsignado.MaxLength = 11
        Else
            Me.TxtConsignado.MaxLength = 50
        End If
        Me.TxtCliente.Focus()
    End Sub

    Private Sub TabGuia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabGuia.SelectedIndexChanged
        If TabGuia.SelectedIndex = 0 Then
            iOpcion = 0
        End If
        GrdDocumentosCliente.ClearSelection()
        GrdDetalleVenta.ClearSelection()
    End Sub
   
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If GrdNConsignado.Rows.Count > 0 Then
            Dim iResp As Integer = MessageBox.Show("¿Está Seguro de Eliminar el Consignado?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If iResp = vbYes Then
                Me.EliminarItem()
            End If
        End If
    End Sub

    Private Sub ActualizarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim flag As Boolean = False
        Dim dgrv0 As DataGridViewRow
        Dim ls_documento As String
        Try
            'Rol (24) Fiscalización
            'If fnValidar_Rol("24") Then
            'bloque
            '****************************************
            'If Acceso.SiRol(G_Rol, Me, 7) Then
            '    flag = True
            'End If
            'If flag = False Then
            '    MessageBox.Show("No tiene Acceso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If
            '
            dgrv0 = Me.DgvLista.CurrentRow()
            ls_documento = CType(dgrv0.Cells("guia").Value, String)
            Dim resp As DialogResult = MessageBox.Show("Está seguro de actualizar la Guía de Envío Nº " & ls_documento & "?", "Seguridad del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = Windows.Forms.DialogResult.Yes Then
                '** 
                'Actualiza los datos para venta al contado 
                '**
                Dim a As New frm_actualiza_venta_contado
                a.ps_tipo_venta = "C"
                a.pl_idforma_pago = CType(dgrv0.Cells("Idforma_Pago").Value, Long)
                a.ps_idcomprobante = CType(dgrv0.Cells("idfactura").Value, String)
                a.pl_idtipo_comprobante = CType(dgrv0.Cells("Idtipo_Comprobante").Value, Long)
                a.pl_idunidad_agencia = CType(dgrv0.Cells("Idunidad_Destino").Value, Long)
                a.pl_idagencia_destino = CType(dgrv0.Cells("Idagencias_Destino").Value, Long)
                a.ps_razon_social = CType(dgrv0.Cells("cliente").Value, String)
                a.pd_tot_costo = CType(dgrv0.Cells("Total_Costo").Value, Double)
                a.pd_monto_sub_total = CType(dgrv0.Cells("Monto_Sub_Total").Value, Double)
                a.pd_monto_impuesto = CType(dgrv0.Cells("Monto_Impuesto").Value, Double)
                a.ps_tipo_comprobante = CType(dgrv0.Cells("tipo").Value, String)
                a.ps_documento = CType(dgrv0.Cells("guia").Value, String)
                a.ps_agencia_origen = CType(dgrv0.Cells("Origen").Value, String)
                a.ps_fecha_documento = CType(dgrv0.Cells("fecha").Value, String)
                '
                a.pl_idunidad_agencia_origen = CType(dgrv0.Cells("idunidad_origen").Value, Long)
                a.pl_idagencia_origen = CType(dgrv0.Cells("idagencias").Value, Long)
                a.ps_documento_identidad = CType(dgrv0.Cells("documento").Value, String)

                a.pl_proceso = CType(dgrv0.Cells("idprocesos").Value, Long)
                a.ps_boleto = CType(IIf(IsDBNull(dgrv0.Cells("nroboleto").Value), "", dgrv0.Cells("nroboleto").Value), String)
                a.pl_envio = CType(dgrv0.Cells("idEstado_envio").Value, Long)
                a.pl_doc = CType(dgrv0.Cells("idEstado_factura").Value, Long)
                '**
                a.ShowDialog()
                '**
                Acceso.Asignar(a, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    a.ShowDialog()
                Else
                    MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                If Not a.pb_cancela Then
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("La Guía Nº " & ls_documento & " ha sido Actualizada.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    BtnBuscar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNuevo.EnabledChanged, BtnEditar.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
    
    Private Sub BtnRecepcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecepcion.Click
        Try
            Dim objFrm As New FrmRecepcionGuias
            'objFrm.ShowDialog()

            Acceso.Asignar(objFrm, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                objFrm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            objFrm = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub txtdt_GotFocus(sender As Object, e As System.EventArgs) Handles txtdt.GotFocus
        Me.txtdt.SelectAll()
    End Sub

    Private Sub txtdt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtdt.KeyPress
        If (Char.IsDigit(e.KeyChar)) Then
            e.Handled = False
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Sub ControlaSubcuentaOrigen(estado As Boolean)
        If Not estado Then
            Me.CboSubCuentaOrigen.Enabled = False
        Else
            Me.CboSubCuentaOrigen.Enabled = True
        End If
    End Sub

    Sub CargarSubcuentaDestino(cliente As Integer, ciudad As Integer)
        objGuiaEnvio.dt_cur_Sub_Cuenta_Destino = dtoVentaCargaContado.ListarSubcuentas(cliente, ciudad)
        If (objGuiaEnvio.dt_cur_Sub_Cuenta_Destino.Rows.Count > 0) Then
            With Me.CboSubCuenta
                .DataSource = objGuiaEnvio.dt_cur_Sub_Cuenta_Destino
                .DisplayMember = "CENTRO_COSTO"
                .ValueMember = "IDCENTRO_COSTO"
                .SelectedValue = 999
            End With
        End If
    End Sub

    Sub CargarSubcuentaOrigen(cliente As Integer, ciudad As Integer)
        objGuiaEnvio.dt_cur_Sub_Cuenta = dtoVentaCargaContado.ListarSubcuentas(cliente, ciudad)
        If (objGuiaEnvio.dt_cur_Sub_Cuenta.Rows.Count > 0) Then
            With Me.CboSubCuentaOrigen
                .DataSource = objGuiaEnvio.dt_cur_Sub_Cuenta
                .DisplayMember = "CENTRO_COSTO"
                .ValueMember = "IDCENTRO_COSTO"
                .SelectedValue = 999
            End With
            If ID_PERSONA_ECKERD = cliente And Me.CboTipo.SelectedIndex = 1 Then
                Me.ControlaSubcuentaOrigen(True)
            Else
                Me.ControlaSubcuentaOrigen(False)
            End If
        End If
    End Sub

#Region "Entrega Domicilio"
    Sub GestionaTarifaDomicilio(TipoEntrega As Integer, origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer, servicio As Integer, cliente As Integer)
        'If TipoEntrega <> 2 Or origen = 0 Or destino = 0 Or producto = -1 Or tipo_tarifa = -1 Or tipo_visibilidad = 0 Then
        If origen = 0 Or destino = 0 Or producto = -1 Or tipo_tarifa = -1 Or tipo_visibilidad = 0 Then
            EliminarItemVenta("ENTREGA", GrdDetalleVenta)
            dtTarifaServicio = Nothing
            dblMontoEntregaDomicilio = 0
        Else
            dtTarifaServicio = ObtieneTarifaServicio(origen, destino, producto, 3, tipo_visibilidad, servicio, cliente)
            If dtTarifaServicio.Rows.Count > 0 Then
                AgregarItemVenta("ENTREGA", GrdDetalleVenta)
            Else
                EliminarItemVenta("ENTREGA", GrdDetalleVenta)
                dtTarifaServicio = Nothing
                dblMontoEntregaDomicilio = 0
            End If
        End If
        If GrdDetalleVenta.Rows.Count = 0 Then Return
        'hlamas 26-08-2015
        'Tarifa entrega es solo para contado
        If Me.CboTipo.SelectedIndex = 1 Then Return

        If TipoGrid_ = FormatoGrid.BULTO Then
            fnTotalPago()
        ElseIf TipoGrid_ <> FormatoGrid.ARTICULOS Then
            iROW = 0
            Calculo_M3()
        End If
    End Sub

    Function ObtieneTarifaServicio(origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer, servicio As Integer, cliente As Integer) As DataTable
        Dim objTarifaLN As New Cls_TarifaServicio_LN
        Dim dt As DataTable = objTarifaLN.ObtenerTarifaServicio(origen, destino, producto, tipo_tarifa, tipo_visibilidad, servicio, cliente, 1)
        Return dt
    End Function

    Sub ActualizaDireccion(cbo As ComboBox)
        Dim obj As New dtoGuiaEnvio
        Dim dt As DataTable = obj.ClienteDireccion(iID_Persona, Me.CboCiudad_Origen.SelectedValue, idUnidadAgencias)
        With cbo
            dtDireccion2 = dt
            .DataSource = dt
            .DisplayMember = "direccion"
            .ValueMember = "iddireccion_consignado"
        End With
    End Sub

    Sub ClientePersonalizado(cliente As Integer)
        If Me.CboTipo.SelectedValue <> 2 And cliente > 0 Then Return
        If ID_PERSONA_DATAIMAGENES = cliente Then
            'hlamas 23-04-2014
            'If objGuiaEnvio.iIDUNIDAD_AGENCIA <> 5100 And objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 5100 Then
            If dtoGuiaEnvio.VenderEnCiudad(cliente, objGuiaEnvio.iIDUNIDAD_AGENCIA, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO) = False Then
                MessageBox.Show("El Cliente " & Me.TxtNomCliente.Text.Trim & " no puede realizar envíos de Provincia a Lima", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DiseñaGrdDetalleVenta()
                FormatoGrdDetalleVenta()
                tarifa_Peso = 0
                tarifa_Volumen = 0
                tarifa_Articulo = 0
                Monto_Base = 0
                tarifa_Sobre = 0
                Return
            End If
        End If

        If objGuiaEnvio.iIDUNIDAD_AGENCIA <> 5100 Then Return
        Dim objCliPer As New dtoGuiaEnvio
        Dim dt As DataTable = objCliPer.ClientePersonalizado(cliente)
        With dt
            If .Rows.Count > 0 Then 'cliente tiene datos personalizados
                If Not IsDBNull(.Rows(0).Item(0)) Then
                    Dim strActivar As String = .Rows(0).Item("ACTIVAR")

                    Dim intTipoEntrega As Integer = .Rows(0).Item("idtipo_entrega")
                    If intTipoEntrega > 0 Then
                        Me.CboTipoEntrega.SelectedValue = intTipoEntrega
                    End If

                    Dim strDestino As String = .Rows(0).Item("destino")
                    If strDestino.Trim.Length > 0 Then
                        idUnidadAgencias = .Rows(0).Item("iddestino")
                        Me.TxtCiudadDestino.Text = strDestino
                        Me.TxtCiudadDestino_LostFocus(Nothing, Nothing)
                    End If
                    Dim intDireccion As Integer = .Rows(0).Item("iddireccion")
                    If intTipoEntrega > 0 And strDestino.Trim.Length > 0 And intDireccion > 0 Then
                        Dim dtDir As DataTable = objCliPer.ClienteDireccion(iID_Persona, 1, idUnidadAgencias)
                        With Me.CboDireccion2
                            dtDireccion2 = dtDir
                            .DataSource = dtDir
                            .DisplayMember = "direccion"
                            .ValueMember = "iddireccion_consignado"
                        End With
                    End If
                    If intDireccion > 0 Then
                        Me.CboDireccion2.SelectedValue = intDireccion
                    End If

                    ClienteActivarPersonalizado(strActivar)
                End If
            End If
        End With
    End Sub

    Sub ClienteActivarPersonalizado(config As String)
        Me.TxtCiudadDestino.Enabled = IIf(config.Substring(0, 1) = "1", True, False)
        Me.CboTipoEntrega.Enabled = IIf(config.Substring(1, 1) = "1", True, False)
        Me.CboDireccion2.Enabled = IIf(config.Substring(2, 1) = "1", True, False)
    End Sub

    'Function BuscarProducto(cliente As Integer, subcuenta As Integer, origen As Integer, destino As Integer) As Integer
    '    Dim objClienteProducto As New Cls_ClienteProducto_LN
    '    Dim intProducto As Integer = objClienteProducto.BuscarProducto(cliente, subcuenta, origen, destino)
    '    Return intProducto
    'End Function

    Function BuscarProducto(ByVal cliente As Integer, ByVal subcuenta As Integer, ByVal origen As Integer, ByVal destino As Integer, ByVal contado As Integer) As Integer
        Dim objClienteProducto As New Cls_ClienteProducto_LN
        Dim intProducto As Integer = objClienteProducto.BuscarProducto(cliente, subcuenta, origen, destino, contado)
        Return intProducto
    End Function

    Sub ClienteProducto(ByVal cliente As Integer, ByVal subcuenta As Integer, ByVal origen As Integer, ByVal destino As Integer)
        'If Me.CboTipo.SelectedValue = 1 Then Return
        If cliente = 0 Or subcuenta = 0 Or origen = 0 Or destino = 0 Then Return

        Dim intContado As Integer = IIf(Me.CboTipo.SelectedIndex = 0, 1, 0)
        Dim intProducto As Integer = Me.BuscarProducto(cliente, subcuenta, origen, destino, intContado)
        If intProducto > 0 Then
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            Me.CboProducto.SelectedValue = intProducto
            Me.fnTarifario()
            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
        ElseIf intContado = 1 Then
            If Me.CboProducto.SelectedValue = 1 Then
                'Me.CboProducto.SelectedIndex = 0
            End If
            Me.CboProducto.Enabled = True
            Me.fnTarifario()
        Else
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            Me.CboProducto.SelectedIndex = -1
            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            DiseñaGrdDetalleVenta()
            FormatoGrdDetalleVenta()
            tarifa_Peso = 0
            tarifa_Volumen = 0
            tarifa_Articulo = 0
            Monto_Base = 0
            tarifa_Sobre = 0
            'Me.CboProducto.Enabled = False
            Me.CboProducto.Enabled = IIf(intContado = 0, False, True)
        End If
    End Sub

    Private Sub ChkCargo_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Try
            'hlamas 07-08-2015
            'la tarifa de devolucion de cargos solo se aplica a venta contado
            If Me.CboTipo.SelectedIndex <> 0 Then Return

            'If iOpcion = 2 Then
            '    RemoveHandler ChkCargo.CheckedChanged, AddressOf ChkCargo_CheckedChanged
            '    ChkCargo.Checked = Not ChkCliente2.Checked
            '    AddHandler ChkCargo.CheckedChanged, AddressOf ChkCargo_CheckedChanged
            '    Return
            'End If

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
        'hlamas 22-03-2016
        'If ChkCargo.Checked Then
        If rbtCargoSi.Checked Then
            dblMonto = dtoVentaCargaContado.MontoDevolucionCargo(0, iID_Persona)
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

    Function TieneCargo() As Boolean
        For Each row As DataGridViewRow In Me.GrdDocumentosCliente.Rows
            If Not IsNothing(row.Cells(2).Value) Then
                If row.Cells(2).Value.ToString.Trim.Length > 4 Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

#End Region

    Private Sub TxtCiudadDestino_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCiudadDestino.TextChanged

    End Sub

    Private Sub btnAutorizar_Click(sender As System.Object, e As System.EventArgs) Handles btnAutorizar.Click
        Dim frm As New frmUsuarioDescuento
        frm.Descuento = Me.TxtDescuento.Text
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtDescDescto.Text = frm.cboUsuario.Text
        End If
    End Sub

    Sub ControlaCargo(estado As Boolean)
        Me.GrdDocumentosCliente.Enabled = IIf(iOpcion = 1, True, estado)
        Me.chkDocumentoCliente.Checked = estado
        Me.rbtCargoSi.Enabled = IIf(iOpcion = 1, True, estado)
        Me.rbtCargoSi.Checked = False
        Me.rbtCargoNo.Enabled = IIf(iOpcion = 1, True, estado)
        Me.rbtCargoNo.Checked = False
        If Me.lblTipoFacturacion.Tag <> 3 Then
            Me.rbtCargoNo.Visible = True
        End If

        If estado Then
        Else
            Dim blnLimpiar As Boolean
            blnLimpiar = True
            If bNuevo = False And iOpcion = 1 Then
                blnLimpiar = False
            End If
            If blnLimpiar Then
                LimpiarGrid(GrdDocumentosCliente, 2)
            End If
        End If
    End Sub

    Private Sub rbtCargoSi_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtCargoSi.CheckedChanged
        'hlamas 22-03-2016
        If Me.CboTipo.SelectedIndex = 1 Then Return
        dblMontoDC = ObtieneMontoDevolucionCargo()
        If GrdDetalleVenta.Rows.Count = 0 Then Return
        If TipoGrid_ = FormatoGrid.BULTO Then
            fnTotalPago()
        ElseIf TipoGrid_ <> FormatoGrid.ARTICULOS Then
            iROW = 0
            Calculo_M3()
        End If
    End Sub

    Private Sub chkDocumentoCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDocumentoCliente.CheckedChanged
        'hlamas 22-03-2016
        If Me.CboProducto.SelectedValue = 6 Then 'no aplica para carga acompañada
            If Me.chkDocumentoCliente.Checked Then
                Me.chkDocumentoCliente.Checked = False
            End If
            Return
        End If
        ControlaCargo(Me.chkDocumentoCliente.Checked)
    End Sub

    Sub MostrarTipoFacturacion(tipo As Integer)
        Dim strTipo As String
        Select Case tipo
            Case 1
                strTipo = "I"
            Case 2
                strTipo = "II"
            Case 3
                strTipo = "III"
            Case Else
                strTipo = ""
        End Select

        If tipo >= 1 Then
            Me.lblTipoFacturacion.Text = "TIPO FACTURACION " & strTipo
        Else
            Me.lblTipoFacturacion.Text = ""
        End If
        Me.lblTipoFacturacion.Tag = tipo
    End Sub

    Private Sub FueraDeZonaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FueraDeZonaToolStripMenuItem.Click
        Try
            Dim frm As New frmMontoFueraZona
            frm.TotalFZ = Me.DgvLista.CurrentRow.Cells("Total_Costo").Value
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                ActualizarFueraZona(frm)
                Me.TxtGuia.Text = Me.DgvLista.CurrentRow.Cells("guia").Value
                Me.Cursor = Cursors.AppStarting
                Dim iGuia As Long = Me.TxtGuia.Text
                Listar(iGuia)
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActualizarFueraZona(ByVal frm As frmMontoFueraZona)
        With frm
            Dim intId As Integer = Me.DgvLista.CurrentRow.Cells("IdFactura").Value
            Dim obj As New dtoGuia
            obj.ActualizarFueraZona(intId, CType(frm.txtMonto.Text, Double), CType(frm.lblImpuesto.Text, Double), CType(frm.lblTotal.Text, Double), dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
        End With
    End Sub

    Sub ActualizarSeguro(ByVal frm As frmMontoFueraZona)
        With frm
            Dim intId As Integer = Me.DgvLista.CurrentRow.Cells("IdFactura").Value
            Dim obj As New dtoGuia
            obj.ActualizarSeguro(intId, CType(frm.txtMonto.Text, Double), CType(frm.lblImpuesto.Text, Double), CType(frm.lblTotal.Text, Double), dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
        End With
    End Sub

    Public Sub imprime(ByVal documento As Integer, ByVal factura As Integer)
        Dim obj As New Imprimir
        Dim sCargaAsegurada As String = "->CARGA ASEGURADA"
        Try
            Dim ldt_cur_datos_venta As New DataTable
            Dim lds_tmp As New DataSet

            Dim flag As Boolean = False
            Dim iSubTotal As Double = 0, iImpuesto As Double = 0, iTotal As Double = 0
            lds_tmp = ObjVentaCargaContado.fn_SP_VER_VENTACONTADO_II(documento, factura, G_Rol) 'paola
            ldt_cur_datos_venta = lds_tmp.Tables(0)

            If documento = 85 Then
                Dim dtImpresora As DataTable = FEManager.buscarPrint()
                ImprimirTicket(ObjVentaCargaContado, dtImpresora)
            ElseIf documento = 3 Then
                Dim intFormato As Integer = Me.DgvLista.CurrentRow.Cells("formato").Value
                If intFormato = 1 Then
                    Dim dtImpresora As DataTable = FEManager.buscarPrint()
                    ImprimirTicketGE(ObjVentaCargaContado, dtImpresora)
                Else
                    Dim documentoreal As Integer = documento
                    'Dim objImpresora As New dtoVentaCargaContado
                    Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
                    Dim objImprimir As New ImprimirTexto()
                    Dim sImpresora As String = ""
                    Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
                    '
                    If documento = 85 Then
                        documento = 3
                    End If
                    'flag = objImpresora.fnSP_Buscar_Impresora(documento, dtoUSUARIOS.IP)
                    Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, documento)
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
                        Dim sDocumento As String
                        If documento = 1 Then
                            sDocumento = "factura"
                        ElseIf documento = 2 Then
                            sDocumento = "boleta"
                        Else
                            sDocumento = "guia"
                        End If
                        'objImprimir = New ImprimirTexto("Draft Condensed", 8, objImpresora.v_Impresora, sDocumento, 1305, 1305)

                        If documento = 1 Then       'Factura
                            obj = New Imprimir
                            obj.Inicializar()
                            obj.Superior = iSuperior
                            obj.Izquierda = Iizquierda
                            obj.Impresora = sImpresora

                            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
                            Dim iLong As Integer = IIf(iTamaño = 0, 36, iTamaño)

                            y = iLong * pagina + 4
                            y += 1
                            i += 1

                            obj.EscribirLinea(y, 48, ldt_cur_datos_venta.Rows(0).Item("serie_factura") & "-" & ldt_cur_datos_venta.Rows(0).Item("nro_factura"))

                            If ldt_cur_datos_venta.Rows(0).Item("es_carga_asegurada") = 1 Then
                                obj.EscribirLinea(y + 1, 48, ldt_cur_datos_venta.Rows(0).Item("agencia_destino") & sCargaAsegurada)
                            Else
                                obj.EscribirLinea(y + 1, 48, ldt_cur_datos_venta.Rows(0).Item("agencia_destino"))
                            End If

                            obj.EscribirLinea(y + 2, 53, ldt_cur_datos_venta.Rows(0).Item("hora_factura"))
                            obj.EscribirLinea(y + 4, 8, DatePart(DateInterval.Day, ldt_cur_datos_venta.Rows(0).Item("fecha_factura")).ToString.PadLeft(2, "0"))
                            obj.EscribirLinea(y + 4, 23, DatePart(DateInterval.Month, ldt_cur_datos_venta.Rows(0).Item("fecha_factura")).ToString.PadLeft(2, "0"))
                            obj.EscribirLinea(y + 4, 42, DatePart(DateInterval.Year, ldt_cur_datos_venta.Rows(0).Item("fecha_factura")))
                            obj.EscribirLinea(y + 5, 13, ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                            obj.EscribirLinea(y + 6, 13, ldt_cur_datos_venta.Rows(0).Item("dirorigen"))

                            obj.EscribirLinea(y + 7, 13, ldt_cur_datos_venta.Rows(0).Item("origen"))
                            obj.EscribirLinea(y + 8, 13, ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                            obj.EscribirLinea(y + 9, 13, ldt_cur_datos_venta.Rows(0).Item("dirdestino"))
                            obj.EscribirLinea(y + 5, 66, ldt_cur_datos_venta.Rows(0).Item("Nu_Docu_Suna"))
                            obj.EscribirLinea(y + 7, 66, ldt_cur_datos_venta.Rows(0).Item("destino"))
                            obj.EscribirLinea(y + 5, 105, ldt_cur_datos_venta.Rows(0).Item("serie_factura") & "-" & ldt_cur_datos_venta.Rows(0).Item("nro_factura"))

                            If ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 1 Then
                                obj.EscribirLinea(y + 7, 105, "CONTADO")
                            ElseIf ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 2 Then
                                obj.EscribirLinea(y + 7, 105, "CREDITO")
                            Else
                                obj.EscribirLinea(y + 7, 105, "PAGO CONTRA ENTREGA")
                            End If

                            If ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 1 Then
                                obj.EscribirLinea(y + 8, 105, "AGENCIA")
                            Else
                                obj.EscribirLinea(y + 8, 105, "DOMICILIO")
                            End If

                            obj.EscribirLinea(y + 12, 13, ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso"))
                            obj.EscribirLinea(y + 12, 23, "BULTOS")
                            obj.EscribirLinea(y + 12, 92, ldt_cur_datos_venta.Rows(0).Item("total_peso"))
                            obj.EscribirLinea(y + 13, 13, ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen"))
                            obj.EscribirLinea(y + 13, 23, "BULTOS (V.)")
                            obj.EscribirLinea(y + 13, 92, ldt_cur_datos_venta.Rows(0).Item("total_volumen"))
                            obj.EscribirLinea(y + 14, 13, ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Sobre"))
                            obj.EscribirLinea(y + 14, 23, "SOBRES")

                            If CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")) > 400 Then
                                obj.EscribirLinea(y + 15, 23, "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUT.")
                                obj.EscribirLinea(y + 16, 23, "CON EL GOBIERNO CENTRAL,SEGUN D.L. N. 940 - R.S. N.")
                                obj.EscribirLinea(y + 17, 23, "158-2006-SUNAT/D.S. N. 033-2006-MTC.")
                                obj.EscribirLinea(y + 18, 23, "Sirvase,depositar a la Cta. del Bco. de la Nación N.0019-002829.")
                            End If
                            obj.EscribirLinea(y + 12, 110, ldt_cur_datos_venta.Rows(0).Item("Monto_Sub_Total").ToString.PadLeft(10, " "))

                            Dim montoLetras As String = ConvercionNroEnLetras(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")))
                            obj.EscribirLinea(y + 21, 11, "Son:  " & montoLetras)

                            obj.EscribirLinea(y + 23, 54, ldt_cur_datos_venta.Rows(0).Item("usuario"))
                            'obj.EscribirLinea(y + 22, 54, "19.00")

                            obj.EscribirLinea(y + 21, 85, "S/.")
                            obj.EscribirLinea(y + 22, 85, "S/.")
                            obj.EscribirLinea(y + 23, 85, "S/.")

                            obj.EscribirLinea(y + 21, 110, ldt_cur_datos_venta.Rows(0).Item("Monto_Sub_Total").ToString.PadLeft(10, " "))
                            obj.EscribirLinea(y + 22, 110, Format(CDbl(ldt_cur_datos_venta.Rows(0).Item("MONTO_IMPUESTO")), "####,###,###0.00").PadLeft(10, " "))
                            obj.EscribirLinea(y + 23, 110, Format(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")), "####,###,###0.00").PadLeft(10, " "))

                            obj.Comprimido = True
                            obj.Preliminar = True
                            obj.Tamaño = iLong
                            obj.Imprimir()
                            obj.Finalizar()

                            Dim frm As New FrmPreview
                            frm.Tamaño = iLong
                            frm.Documento = 1
                            frm.Text = "Factura"
                            frm.ShowDialog()

                        ElseIf documento = 2 Then   'Boleta
                            obj = New Imprimir
                            obj.Inicializar()
                            obj.Superior = iSuperior
                            obj.Izquierda = Iizquierda
                            obj.Impresora = sImpresora

                            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
                            Dim iLong As Integer = IIf(iTamaño = 0, 18, iTamaño)

                            y = iLong * pagina + 4
                            y += 1
                            i += 1

                            Dim HoraSistema As String = fnGetHora()
                            obj.EscribirLinea(y, 6, ldt_cur_datos_venta.Rows(0).Item("origen"))
                            obj.EscribirLinea(y + 1, 6, ldt_cur_datos_venta.Rows(0).Item("fecha_factura"))
                            obj.EscribirLinea(y + 2, 6, ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                            obj.EscribirLinea(y + 3, 6, ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                            obj.EscribirLinea(y + 4, 6, ldt_cur_datos_venta.Rows(0).Item("dirdestino"))
                            obj.EscribirLinea(y, 30, ldt_cur_datos_venta.Rows(0).Item("destino"))
                            obj.EscribirLinea(y + 1, 30, ldt_cur_datos_venta.Rows(0).Item("hora_factura"))

                            If ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 1 Then
                                obj.EscribirLinea(y + 1, 53, "CONTADO")
                            ElseIf ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 2 Then
                                obj.EscribirLinea(y + 1, 53, "CREDITO")
                            Else
                                obj.EscribirLinea(y + 1, 53, "PAGO CONTRA ENTREGA")
                            End If

                            If ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 1 Then
                                obj.EscribirLinea(y, 52, "AGENCIA")
                            Else
                                obj.EscribirLinea(y, 52, "DOMICILIO")
                            End If

                            '11
                            obj.EscribirLinea(y + 7, 16, "BULTOS   " & Val(Val(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso"))) + Val(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")))
                            obj.EscribirLinea(y + 7, 46, Val(ldt_cur_datos_venta.Rows(0).Item("total_peso")))
                            obj.EscribirLinea(y + 7, 56, Val(ldt_cur_datos_venta.Rows(0).Item("Total_Volumen")))
                            obj.EscribirLinea(y + 7, 67, Format(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")), "###,###,###.00"))

                            obj.EscribirLinea(y + 7, 84, "BULTOS  " & Val(Val(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso"))) + Val(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")))
                            obj.EscribirLinea(y + 7, 105, Val(ldt_cur_datos_venta.Rows(0).Item("Total_Volumen")))
                            obj.EscribirLinea(y + 7, 112, Val(ldt_cur_datos_venta.Rows(0).Item("total_peso")))
                            obj.EscribirLinea(y + 7, 121, Format(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")), "###,###,###.00"))

                            '12
                            obj.EscribirLinea(y + 8, 16, "SOBRES   " & Val(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Sobre")))
                            obj.EscribirLinea(y + 8, 84, "SOBRES  " & Val(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Sobre")))

                            obj.EscribirLinea(3, 33, ldt_cur_datos_venta.Rows(0).Item("serie_factura") & "-" & ldt_cur_datos_venta.Rows(0).Item("nro_factura"))
                            obj.EscribirLinea(y, 89, ldt_cur_datos_venta.Rows(0).Item("origen"))
                            obj.EscribirLinea(y + 1, 89, ldt_cur_datos_venta.Rows(0).Item("fecha_factura"))
                            obj.EscribirLinea(y + 2, 89, ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                            obj.EscribirLinea(y + 3, 89, ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                            obj.EscribirLinea(y + 4, 89, ldt_cur_datos_venta.Rows(0).Item("dirdestino"))
                            obj.EscribirLinea(y, 105, ldt_cur_datos_venta.Rows(0).Item("destino"))
                            obj.EscribirLinea(y + 1, 114, ldt_cur_datos_venta.Rows(0).Item("hora_factura"))

                            If ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 1 Then
                                obj.EscribirLinea(y + 1, 105, "CONTADO")
                            ElseIf ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 2 Then
                                obj.EscribirLinea(y + 1, 105, "CREDITO")
                            Else
                                obj.EscribirLinea(y + 1, 105, "PAGO CONTRA ENTREGA")
                            End If

                            If ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 1 Then
                                obj.EscribirLinea(y, 120, "AGENCIA")
                            Else
                                obj.EscribirLinea(y, 120, "DOMICILIO")
                            End If
                            obj.EscribirLinea(0, 0, factura)

                            If ldt_cur_datos_venta.Rows(0).Item("es_carga_asegurada") = 1 Then
                                obj.EscribirLinea(0, 30, sCargaAsegurada)
                                obj.EscribirLinea(0, 16, ldt_cur_datos_venta.Rows(0).Item("usuario"))
                            Else
                                obj.EscribirLinea(0, 16, ldt_cur_datos_venta.Rows(0).Item("usuario"))
                            End If
                            obj.EscribirLinea(4, 30, ldt_cur_datos_venta.Rows(0).Item("agencia_destino"))
                            obj.EscribirLinea(3, 82, ldt_cur_datos_venta.Rows(0).Item("serie_factura") & "-" & ldt_cur_datos_venta.Rows(0).Item("nro_factura"))
                            obj.EscribirLinea(0, 82, factura)
                            obj.EscribirLinea(4, 82, ldt_cur_datos_venta.Rows(0).Item("agencia_destino"))
                            obj.EscribirLinea(0, 90, ldt_cur_datos_venta.Rows(0).Item("usuario"))
                            obj.EscribirLinea(y + 10, 67, Format(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")), "###,###,###.00"))
                            obj.EscribirLinea(y + 10, 121, Format(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")), "###,###,###.00"))

                            obj.Comprimido = True
                            obj.Preliminar = True
                            obj.Tamaño = iLong
                            obj.Imprimir()
                            obj.Finalizar()

                            Dim frm As New FrmPreview
                            frm.Documento = 2
                            frm.Tamaño = iLong
                            frm.Text = "Boleta"
                            frm.ShowDialog()

                        ElseIf documento = 3 Then       'guia de envio
                            obj = New Imprimir
                            obj.Inicializar()
                            obj.Superior = iSuperior
                            obj.Izquierda = Iizquierda
                            obj.Impresora = sImpresora

                            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
                            Dim iLong As Integer = IIf(iTamaño = 0, 22, iTamaño)

                            y = iLong * pagina + 2
                            i += 1

                            'fnInprecion_Guia_Envio()

                            ObjRptGuiaEnvio.p_Hora_Guia = fnGetHora()
                            'If ldt_cur_datos_venta.Rows(0).Item("es_carga_asegurada") = 1 Then
                            '    obj.EscribirLinea(y, 22, ldt_cur_datos_venta.Rows(0).Item("Nro_Guia") & sCargaAsegurada)
                            'Else
                            '    obj.EscribirLinea(y, 22, ldt_cur_datos_venta.Rows(0).Item("Nro_Guia"))
                            'End If

                            obj.EscribirLinea(2, 33, ldt_cur_datos_venta.Rows(0).Item("Producto")) 'cambio
                            'obj.EscribirLinea(y + 0, 50, CboProducto.Text) 'cambio 
                            obj.EscribirLinea(y, 22, ldt_cur_datos_venta.Rows(0).Item("Nro_Guia"))
                            obj.EscribirLinea(y, 82, ldt_cur_datos_venta.Rows(0).Item("origen_iata"))
                            obj.EscribirLinea(y, 92, ldt_cur_datos_venta.Rows(0).Item("destino_iata"))
                            obj.EscribirLinea(y + 2, 0, ldt_cur_datos_venta.Rows(0).Item("Nu_Docu_Suna") & "-" & ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                            obj.EscribirLinea(y + 5, 0, ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                            If ldt_cur_datos_venta.Rows(0).Item("DirOrigen").ToString.Trim.Length > 40 Then
                                obj.EscribirLinea(y + 6, 0, ldt_cur_datos_venta.Rows(0).Item("DirOrigen").ToString.Substring(0, 41))
                                obj.EscribirLinea(y + 7, 0, ldt_cur_datos_venta.Rows(0).Item("DirOrigen").ToString.Substring(41))
                            Else
                                obj.EscribirLinea(y + 6, 0, ldt_cur_datos_venta.Rows(0).Item("DirOrigen"))
                            End If

                            obj.EscribirLinea(y + 5, 59, ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                            obj.EscribirLinea(y + 6, 59, ldt_cur_datos_venta.Rows(0).Item("dirdestino"))

                            '------------   
                            If lds_tmp.Tables(2).Rows.Count > 0 Then
                                Dim NroDoc0 As String
                                '
                                Dim lb_par_activo As Boolean = False

                                Dim p As Integer = 11
                                For Each fila As DataRow In lds_tmp.Tables(2).Rows
                                    NroDoc0 = fila.Item(1)
                                    obj.EscribirLinea(y + p, 0, NroDoc0)
                                    NroDoc0 = ""
                                    p += 1
                                Next
                            End If
                            '------------

                            If ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 2 Then
                                obj.EscribirLinea(y + 2, 33, "X")
                            ElseIf ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 1 Then
                                obj.EscribirLinea(y + 2, 42, "X")
                            End If

                            If ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 1 Then
                                obj.EscribirLinea(y + 2, 54, "X")
                            ElseIf ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 2 Then
                                obj.EscribirLinea(y + 2, 64, "X")
                            Else
                                obj.EscribirLinea(y + 2, 76, "X")
                            End If
                            obj.EscribirLinea(y + 9, 0, ldt_cur_datos_venta.Rows(0).Item("destinatario")) '"FACTURAR A: " &
                            obj.EscribirLinea(y + 8, 29, ldt_cur_datos_venta.Rows(0).Item("telefono"))
                            obj.EscribirLinea(y + 8, 59, ldt_cur_datos_venta.Rows(0).Item("destino"))
                            obj.EscribirLinea(y + 8, 84, IIf(IsDBNull(ldt_cur_datos_venta.Rows(0).Item("telefono_consignado")), "", ldt_cur_datos_venta.Rows(0).Item("telefono_consignado")))
                            obj.EscribirLinea(y + 17, 26, Format(CDate(ldt_cur_datos_venta.Rows(0).Item("fecha_factura")), "dd     MM      yy"))


                            If documentoreal = 85 Then
                                Dim c As Integer = 0
                                If lds_tmp.Tables(1).Rows.Count > 0 Then
                                    For Each fila As DataRow In lds_tmp.Tables(1).Rows
                                        c += fila.Item("CANTIDAD_ARTICULOS")
                                    Next
                                    obj.EscribirLinea(y + 13, 26, FormatNumber(CDbl(c), 2))
                                Else
                                    obj.EscribirLinea(y + 13, 26, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso")) + CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")), 2))
                                End If

                                obj.EscribirLinea(y + 13, 34, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Peso")), 2))
                                obj.EscribirLinea(y + 13, 42, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Volumen")), 2))
                                obj.EscribirLinea(y + 13, 55, ldt_cur_datos_venta.Rows(0).Item("fecha_factura"))
                                obj.EscribirLinea(y + 13, 69, ldt_cur_datos_venta.Rows(0).Item("hora_factura"))
                                obj.EscribirLinea(y + 13, 10, "TOTAL A PAGAR S/. " & FormatNumber(ldt_cur_datos_venta.Rows(0).Item("Total_Costo"), 2))
                            Else
                                Dim c As Integer = 0
                                If lds_tmp.Tables(1).Rows.Count > 0 Then
                                    For Each fila As DataRow In lds_tmp.Tables(1).Rows
                                        c += fila.Item("CANTIDAD_ARTICULOS")
                                    Next
                                    obj.EscribirLinea(y + 13, 49, FormatNumber(CDbl(c), 2))
                                Else
                                    obj.EscribirLinea(y + 13, 49, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso")) + CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")), 2))
                                End If

                                obj.EscribirLinea(y + 13, 57, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Peso")), 2))
                                obj.EscribirLinea(y + 13, 65, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Volumen")), 2))
                                obj.EscribirLinea(y + 13, 78, ldt_cur_datos_venta.Rows(0).Item("fecha_factura"))
                                obj.EscribirLinea(y + 13, 92, ldt_cur_datos_venta.Rows(0).Item("hora_factura"))
                            End If
                            obj.EscribirLinea(y + 14, 57, "N. SOBRES " & ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Sobre"))


                            'obj.Comprimido = True
                            'obj.Preliminar = True
                            'obj.Tamaño = iLong
                            'obj.Imprimir()
                            'obj.Finalizar()

                            'Dim frm As New FrmPreview
                            'frm.Documento = 3
                            'frm.Tamaño = iLong
                            'frm.Text = "Guía de Envío"
                            'frm.ShowDialog()

                            obj.Comprimido = True
                            obj.Tamaño = iLong
                            obj.Imprimir()
                            obj.Finalizar()

                            'Actualiza auditoria de reimpresion de guias
                            Dim objReimpresion As New dtoVentaCargaContado
                            objReimpresion.AuditoriaReimpresion(documento, factura, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)


                            '    ObjRptGuiaEnvio.p_Hora_Guia = fnGetHora()
                            '    If ldt_cur_datos_venta.Rows(0).Item("es_carga_asegurada") = 1 Then
                            '        objImprimir.Agregar(210, 25, ldt_cur_datos_venta.Rows(0).Item("Nro_Guia") & sCargaAsegurada)
                            '    Else
                            '        objImprimir.Agregar(210, 25, ldt_cur_datos_venta.Rows(0).Item("Nro_Guia"))
                            '    End If
                            '    objImprimir.Agregar(485, 15, ldt_cur_datos_venta.Rows(0).Item("origen_iata"))
                            '    objImprimir.Agregar(545, 15, ldt_cur_datos_venta.Rows(0).Item("destino_iata"))
                            '    objImprimir.Agregar(0, 55, ldt_cur_datos_venta.Rows(0).Item("Nu_Docu_Suna") & "-" & ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                            '    objImprimir.Agregar(25, 105, ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                            '    objImprimir.Agregar(25, 120, ldt_cur_datos_venta.Rows(0).Item("DirOrigen"))
                            '    objImprimir.Agregar(355, 105, ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                            '    objImprimir.Agregar(355, 120, ldt_cur_datos_venta.Rows(0).Item("dirdestino"))

                            '    If ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 2 Then
                            '        objImprimir.Agregar(190, 55, "X")
                            '    ElseIf ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 1 Then
                            '        objImprimir.Agregar(245, 55, "X")
                            '    End If

                            '    If ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 1 Then
                            '        objImprimir.Agregar(310, 55, "X")
                            '    ElseIf ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 2 Then
                            '        objImprimir.Agregar(435, 55, "X")
                            '    Else
                            '        objImprimir.Agregar(370, 55, "X")
                            '    End If
                            '    objImprimir.Agregar(25, 175, "FACTURAR A: " & ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                            '    objImprimir.Agregar(162, 155, ldt_cur_datos_venta.Rows(0).Item("telefono"))
                            '    objImprimir.Agregar(370, 155, ldt_cur_datos_venta.Rows(0).Item("destino"))
                            '    objImprimir.Agregar(525, 155, IIf(IsDBNull(ldt_cur_datos_venta.Rows(0).Item("telefono_consignado")), "", ldt_cur_datos_venta.Rows(0).Item("telefono_consignado")))
                            '    objImprimir.Agregar(155, 300, Format(CDate(ldt_cur_datos_venta.Rows(0).Item("fecha_factura")), "dd     MM      yy"))
                            '    objImprimir.Agregar(280, 235, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso")) + CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")), 2))
                            '    objImprimir.Agregar(330, 235, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso")), 2))
                            '    objImprimir.Agregar(380, 235, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")), 2))
                            '    objImprimir.Agregar(450, 240, ldt_cur_datos_venta.Rows(0).Item("fecha_factura"))
                            '    objImprimir.Agregar(535, 240, ldt_cur_datos_venta.Rows(0).Item("hora_factura"))
                            '    objImprimir.Agregar(300, 252, "Nº SOBRES " & ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Sobre"))
                        End If
                        'objImprimir.Imprimir()
                    Else
                        MessageBox.Show("El Documento no tiene asociado una impresora.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    objImprimir = Nothing
                    objImpresora = Nothing
                End If
            End If

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub ImprimirTicket(ByVal venta As dtoVentaCargaContado, ByVal impresora As DataTable, Optional ByVal venta2 As dtoVentaCargaContado = Nothing)
        Dim prn As New FEManager
        Dim feventa As New FEVenta
        Dim fecliente As New FECliente
        Dim blnVolumetrico As Boolean = Me.ChkM3.Checked

        fecliente.tipoDocumentoID = dtCliente.Rows(0).Item("tipo") 'venta.ID_TipoDocCli
        fecliente.numeroDocumento = dtCliente.Rows(0).Item("nu_docu_suna") 'venta.v_NRO_DNI_RUC
        fecliente.nombres = dtCliente.Rows(0).Item("razon_social")

        'If ObjVentaCargaContado.v_direccion.Trim.Length > 0 Then
        'fecliente.direccion = ObjVentaCargaContado.v_direccion.Trim.ToUpper
        'Else
        fecliente.direccion = Me.DgvLista.CurrentRow.Cells("direccion").Value 'IIf(CboDireccion.SelectedIndex > 0, CboDireccion.Text.Trim.ToUpper(), "")
        'End If
        feventa.cliente = fecliente

        Dim strSerie As String = ""

        feventa.numeroSerie = "" 'strSerie & Me.lblSerie.Text 'venta.v_SERIE_FACTURA
        feventa.numeroCorrelativo = Me.DgvLista.CurrentRow.Cells("guia").Value 'venta.v_NRO_FACTURA

        feventa.fechaEmision = Me.DgvLista.CurrentRow.Cells("fecha").Value 'FechaServidor()
        feventa.tipoComprobanteID = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value  'venta.v_IDTIPO_COMPROBANTE
        feventa.opGravada = 0
        feventa.igv = 0
        feventa.total = CDbl(Me.DgvLista.CurrentRow.Cells("Total_Costo").Value)
        feventa.totalLetras = ObjVentaCargaContado.v_nroboleto
        feventa.formaPago = "" 'IIf(cmbFormaPago.SelectedIndex = 0, "", cmbFormaPago.Text.Trim().ToUpper())
        Dim formaPagoID As Integer = 0 'cboFormaPago.SelectedValue
        feventa.isCortesia = False

        '-->Para la impresion
        feventa.producto = CboProducto.Text
        feventa.origen = Me.CboCiudad_Origen.Text
        feventa.destino = TxtCiudadDestino.Text.Trim.ToUpper()
        feventa.remitenete = fecliente.nombres

        ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = ""
        For i As Integer = 0 To GrdNConsignado.Rows.Count() - 1
            ObjVentaCargaContado.v_NOMBRES_DESTINATARIO &= GrdNConsignado("Nombres", i).Value & ";"
        Next

        Dim sConsignado As String = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO.Trim.Replace(";", ",")
        sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)
        feventa.consignado = sConsignado

        feventa.tipoEntrega = Me.CboTipoEntrega.Text
        feventa.direccionEntrega = Me.CboDireccion2.Text
        feventa.agenciaEmision = Me.CboAgencia_Origen.Text 'dtoUSUARIOS.m_iNombreAgencia
        feventa.usuarioEmision = Me.DgvLista.CurrentRow.Cells("usuario").Value 'dtoUSUARIOS.NameLogin
        feventa.detalleVenta = FEManager.crearDetallePCE(GrdDetalleVenta, CDbl(Me.TxtTotal.Text), Me.ChkArticulos.Checked, blnVolumetrico, venta.v_iProceso, 0)
        feventa.id = Me.DgvLista.CurrentRow.Cells("IdFactura").Value 'ObjVentaCargaContado.v_IDFACTURA
        feventa.totalLetras = strNroGuias_Remision
        feventa.direccionFiscal = IIf(Me.rbtCargoSi.Checked, "SI", "NO")
        feventa.tabla = "T_FACTURA_CONTADO"

        Dim result As New servicefe.Result
        'Dim result As New feserviceDesarrollo.Result
        prn.Print(feventa, impresora)
    End Sub

    Sub ImprimirTicketGE(ByVal venta As dtoVentaCargaContado, ByVal impresora As DataTable, Optional ByVal venta2 As dtoVentaCargaContado = Nothing)
        Dim prn As New FEManager
        Dim feventa As New FEVenta
        Dim fecliente As New FECliente

        fecliente.tipoDocumentoID = dtCliente.Rows(0).Item("tipo") 'venta.ID_TipoDocCli
        fecliente.numeroDocumento = dtCliente.Rows(0).Item("nu_docu_suna") 'venta.v_NRO_DNI_RUC
        fecliente.nombres = dtCliente.Rows(0).Item("razon_social")

        'If ObjVentaCargaContado.v_direccion.Trim.Length > 0 Then
        'fecliente.direccion = ObjVentaCargaContado.v_direccion.Trim.ToUpper
        'Else
        fecliente.direccion = Me.DgvLista.CurrentRow.Cells("direccion").Value
        'IIf(CboDireccion.SelectedIndex > 0, CboDireccion.Text.Trim.ToUpper(), "")
        'End If
        feventa.cliente = fecliente

        Dim strSerie As String = ""

        feventa.numeroSerie = "" 'strSerie & Me.lblSerie.Text 'venta.v_SERIE_FACTURA
        feventa.numeroCorrelativo = Me.DgvLista.CurrentRow.Cells("guia").Value 'venta.v_NRO_FACTURA

        feventa.fechaEmision = Me.DgvLista.CurrentRow.Cells("fecha").Value 'FechaServidor()
        feventa.tipoComprobanteID = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value  'venta.v_IDTIPO_COMPROBANTE
        feventa.opGravada = 0
        feventa.igv = 0
        feventa.total = CDbl(Me.DgvLista.CurrentRow.Cells("Total_Costo").Value)
        feventa.totalLetras = ObjVentaCargaContado.v_nroboleto
        feventa.formaPago = Me.CboContacto.Text 'IIf(cmbFormaPago.SelectedIndex = 0, "", cmbFormaPago.Text.Trim().ToUpper())
        Dim formaPagoID As Integer = 0 'cboFormaPago.SelectedValue
        feventa.isCortesia = False

        '-->Para la impresion
        feventa.producto = CboProducto.Text
        feventa.origen = Me.CboCiudad_Origen.Text
        feventa.destino = TxtCiudadDestino.Text.Trim.ToUpper()
        feventa.remitenete = Me.CboRemitente.Text

        ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = ""
        For i As Integer = 0 To GrdNConsignado.Rows.Count() - 1
            ObjVentaCargaContado.v_NOMBRES_DESTINATARIO &= GrdNConsignado("Nombres", i).Value & ";"
        Next

        Dim sConsignado As String = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO.Trim.Replace(";", ",")
        sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)
        feventa.consignado = sConsignado

        feventa.tipoEntrega = Me.CboTipoEntrega.Text
        feventa.direccionEntrega = Me.CboDireccion2.Text
        feventa.agenciaEmision = Me.CboAgencia_Origen.Text 'dtoUSUARIOS.m_iNombreAgencia
        feventa.usuarioEmision = Me.DgvLista.CurrentRow.Cells("usuario").Value
        feventa.detalleVenta = FEManager.crearDetallePCE(GrdDetalleVenta, CDbl(Me.TxtTotal.Text), Me.ChkArticulos.Checked, False, venta.v_iProceso, 0)
        feventa.id = Me.DgvLista.CurrentRow.Cells("IdFactura").Value 'ObjVentaCargaContado.v_IDFACTURA
        feventa.MontoLetras = strNroGuias_Remision
        feventa.direccionFiscal = IIf(Me.rbtCargoSi.Checked, "SI", "NO")
        'feventa.tabla = "T_FACTURA_CONTADO"

        Dim barra As String = feventa.numeroCorrelativo
        Dim strRuta As String = Path.PathSys & "\barra.png"
        Dim bytes() As Byte = CodigoBarra(barra, strRuta)

        Dim result As New servicefe.Result
        'Dim result As New feserviceDesarrollo.Result
        prn.PrintGE(feventa, impresora, bytes)
    End Sub
    
    Private Sub DgvLista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLista.CellContentClick

    End Sub

    Private Sub btnCanjearRecojo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCanjearRecojo.Click
        Try
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de canjear el recojo a comprobante?", "Canjear Recojo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.AppStarting
                Dim obj As New dtoGuiaEnvio
                obj.CanjearRecojo(Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value, Me.DgvLista.CurrentRow.Cells("IdFactura").Value, _
                                  dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)

                Me.TxtGuia.Text = Me.DgvLista.CurrentRow.Cells("guia").Value
                Dim iGuia As Long = Me.TxtGuia.Text
                Listar(iGuia)
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNroNroGuia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroNroGuia.TextChanged
        Dim a As String = Me.txtNroNroGuia.Text
    End Sub

    Private Sub CboListaUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboListaUsuarios.SelectedIndexChanged
        If iOpcion = 2 Then
            Me.CboListaUsuarios.SelectedValue = Me.DgvLista.CurrentRow.Cells("idusuario_personal").Value
        End If
    End Sub

    Function ObtieneProducto(ByVal producto As Integer) As String
        Select Case producto
            Case 0
                Return ""
            Case 6
                Return "CA"
            Case 8
                Return "TC"
            Case 10
                Return "SOB"
            Case 81
                Return "BOX"
            Case 82
                Return "BOX2"
        End Select
    End Function

    Function ObtieneTipoComprobante(ByVal tipo As Integer) As String
        Select Case tipo
            Case 1
                Return "FAC"
            Case 2
                Return "BOL"
            Case 3
                Return "GE"
            Case 85
                Return "PCE"
        End Select
    End Function

    Sub ControlDatos()
        Try
            Dim row As Integer = DgvLista.SelectedRows.Item(0).Index

            Dim iTipoComprobante As Integer = DgvLista.Rows(row).Cells("idtipo_comprobante").Value
            Dim iIDGuia_Envio As Integer = DgvLista.Rows(row).Cells("IdFactura").Value

            If iOpcion = 1 Then 'Editar
                Me.FormatoEditar(iTipoComprobante)
                BtnGraba.Enabled = True
                Me.CboListaUsuarios.Enabled = False
                Me.CboCiudad_Origen.Enabled = False
                Me.CboAgencia_Origen.Enabled = False
                Me.RbtDocumento.Enabled = False
                Me.RbtNombre.Enabled = False
                Me.TxtCliente.Enabled = False
            ElseIf iOpcion = 2 Then 'Consultar
                Me.FormatoConsultar()
                BtnGraba.Enabled = False
                Me.CboListaUsuarios.Enabled = True
                Me.CboCiudad_Origen.Enabled = True
                Me.CboAgencia_Origen.Enabled = True
                Me.RbtDocumento.Enabled = True
                Me.RbtNombre.Enabled = True
                Me.TxtCliente.Enabled = True
            End If
            '-----
            intComprobanteRecojo = 0
            If Me.DgvLista.CurrentRow.Cells("idestado_envio").Value = 12 Then
                intComprobanteRecojo = 1
            End If
            If iTipoComprobante = 85 Then 'Contado PCE
                Me.btnImprimir.Enabled = DgvLista.Rows(row).Cells("formato").Value = 1
                iTipoVenta = 1
                Dim ds As DataSet = objGuiaEnvio.RecuperarVentaContado(iIDGuia_Envio)
                Me.MostrarVentaContado(ds)
                ObjVentaCargaContado.v_IDFACTURA = iIDGuia_Envio

                'hlamas 12-06-2019
                'edicion de recojo
                If Me.DgvLista.CurrentRow.Cells("idestado_envio").Value = 12 Then
                    intComprobanteRecojo = 1
                    If TipoGrid_ = 2 Then
                        Me.ChkArticulos.Tag = 1
                        Me.ChkArticulos.Checked = True
                    End If
                    Buscar(1)
                    If Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso Me.TxtNroDocCliente.Text.Trim = idRemitente Then
                        Me.CboRemitente.SelectedValue = idRemitente
                        Me.CboContacto.SelectedValue = idcontacto
                    End If
                    IdDireccionOrigen = Val("" & Me.DgvLista.CurrentRow.Cells("iddireccion_remitente").Value)
                    Me.CboDireccion.SelectedValue = IdDireccionOrigen
                    idDireConsignado = Val("" & Me.DgvLista.CurrentRow.Cells("iddireccion_consignado").Value)
                    Me.CboDireccion2.SelectedValue = idDireConsignado
                    If Val(Me.TxtTotal.Text) > 0 Then
                        'fnTarifario()
                        Consulta()
                    End If
                End If

            ElseIf iTipoComprobante = 3 Then 'Credito
                iTipoVenta = 2
                Dim ds As DataSet = objGuiaEnvio.RecuperarVentaCredito(iIDGuia_Envio)
                Me.MostrarVentaCredito(ds)
                Me.btnImprimir.Enabled = Val(Me.TxtTotal.Text) > 0

                'hlamas 11-03-2019
                'edicion de recojo
                If Me.DgvLista.CurrentRow.Cells("idestado_envio").Value = 12 Then
                    intComprobanteRecojo = 1
                    If TipoGrid_ = 2 Then
                        Me.ChkArticulos.Tag = 1
                        Me.ChkArticulos.Checked = True
                    End If
                    BuscarClienteCredito()

                    If Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso Me.TxtNroDocCliente.Text.Trim = idRemitente Then
                        Me.CboRemitente.SelectedValue = idRemitente
                        Me.CboContacto.SelectedValue = idcontacto
                    End If
                    IdDireccionOrigen = Val("" & Me.DgvLista.CurrentRow.Cells("iddireccion_remitente").Value)
                    Me.CboDireccion.SelectedValue = IdDireccionOrigen
                    idDireConsignado = Val("" & Me.DgvLista.CurrentRow.Cells("iddireccion_consignado").Value)
                    Me.CboDireccion2.SelectedValue = idDireConsignado
                    If Val(Me.TxtTotal.Text) > 0 Then
                        'fnTarifario()
                        Consulta()
                    End If
                End If

                IDGUIAS_ENVIO = iIDGuia_Envio
            End If
            '-----
            GrdDocumentosCliente.ClearSelection()
            GrdDetalleVenta.ClearSelection()
            TabGuia.SelectTab(1)
            GrdDetalleVenta.Focus()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Recupera(ByVal row As Integer)
        Try
            'Dim row As Integer = DgvLista.SelectedRows.Item(0).Index

            Dim iTipoComprobante As Integer = DgvLista.Rows(row).Cells("idtipo_comprobante").Value
            Dim iIDGuia_Envio As Integer = DgvLista.Rows(row).Cells("IdFactura").Value

            If iOpcion = 1 Then 'Editar
                Me.FormatoEditar(iTipoComprobante)
                BtnGraba.Enabled = True
                Me.CboListaUsuarios.Enabled = False
                Me.CboCiudad_Origen.Enabled = False
                Me.CboAgencia_Origen.Enabled = False
                Me.RbtDocumento.Enabled = False
                Me.RbtNombre.Enabled = False
                Me.TxtCliente.Enabled = False
            ElseIf iOpcion = 2 Then 'Consultar
                Me.FormatoConsultar()
                BtnGraba.Enabled = False
                Me.CboListaUsuarios.Enabled = True
                Me.CboCiudad_Origen.Enabled = True
                Me.CboAgencia_Origen.Enabled = True
                Me.RbtDocumento.Enabled = True
                Me.RbtNombre.Enabled = True
                Me.TxtCliente.Enabled = True
            End If
            '-----
            intComprobanteRecojo = 0
            If Me.DgvLista.CurrentRow.Cells("idestado_envio").Value = 12 Then
                intComprobanteRecojo = 1
            End If
            If iTipoComprobante = 85 Then 'Contado PCE
                Me.btnImprimir.Enabled = DgvLista.Rows(row).Cells("formato").Value = 1
                iTipoVenta = 1
                Dim ds As DataSet = objGuiaEnvio.RecuperarVentaContado(iIDGuia_Envio)
                Me.MostrarVentaContado(ds)
                ObjVentaCargaContado.v_IDFACTURA = iIDGuia_Envio

                'hlamas 12-06-2019
                'edicion de recojo
                If Me.DgvLista.CurrentRow.Cells("idestado_envio").Value = 12 Then
                    intComprobanteRecojo = 1
                    If TipoGrid_ = 2 Then
                        Me.ChkArticulos.Tag = 1
                        Me.ChkArticulos.Checked = True
                    End If
                    Buscar(1)
                    If Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso Me.TxtNroDocCliente.Text.Trim = idRemitente Then
                        Me.CboRemitente.SelectedValue = idRemitente
                        Me.CboContacto.SelectedValue = idcontacto
                    End If
                    IdDireccionOrigen = Val("" & Me.DgvLista.CurrentRow.Cells("iddireccion_remitente").Value)
                    Me.CboDireccion.SelectedValue = IdDireccionOrigen
                    idDireConsignado = Val("" & Me.DgvLista.CurrentRow.Cells("iddireccion_consignado").Value)
                    Me.CboDireccion2.SelectedValue = idDireConsignado
                    If Val(Me.TxtTotal.Text) > 0 Then
                        'fnTarifario()
                        Consulta()
                    End If
                End If

            ElseIf iTipoComprobante = 3 Then 'Credito
                iTipoVenta = 2
                Dim ds As DataSet = objGuiaEnvio.RecuperarVentaCredito(iIDGuia_Envio)
                Me.MostrarVentaCredito(ds)
                Me.btnImprimir.Enabled = Val(Me.TxtTotal.Text) > 0

                'hlamas 11-03-2019
                'edicion de recojo
                If Me.DgvLista.CurrentRow.Cells("idestado_envio").Value = 12 Then
                    intComprobanteRecojo = 1
                    If TipoGrid_ = 2 Then
                        Me.ChkArticulos.Tag = 1
                        Me.ChkArticulos.Checked = True
                    End If
                    BuscarClienteCredito()

                    If Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso Me.TxtNroDocCliente.Text.Trim = idRemitente Then
                        Me.CboRemitente.SelectedValue = idRemitente
                        Me.CboContacto.SelectedValue = idcontacto
                    End If
                    IdDireccionOrigen = Val("" & Me.DgvLista.CurrentRow.Cells("iddireccion_remitente").Value)
                    Me.CboDireccion.SelectedValue = IdDireccionOrigen
                    idDireConsignado = Val("" & Me.DgvLista.CurrentRow.Cells("iddireccion_consignado").Value)
                    Me.CboDireccion2.SelectedValue = idDireConsignado
                    If Val(Me.TxtTotal.Text) > 0 Then
                        'fnTarifario()
                        Consulta()
                    End If
                End If

                IDGUIAS_ENVIO = iIDGuia_Envio
            End If
            '-----
            'GrdDocumentosCliente.ClearSelection()
            'GrdDetalleVenta.ClearSelection()
            'TabGuia.SelectTab(1)
            'GrdDetalleVenta.Focus()
            Dim sGuia As String = Me.DgvLista.Rows(row).Cells("guia").Value
            Dim iGuia As Integer = Me.DgvLista.Rows(row).Cells("IdFactura").Value
            Dim iTipo As Integer = Me.DgvLista.Rows(row).Cells("idtipo_comprobante").Value

            imprime(iTipo, iGuia)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Imprimir()
        Dim sGuia As String = Me.DgvLista.CurrentRow.Cells("guia").Value
        Dim iGuia As Integer = Me.DgvLista.CurrentRow.Cells("IdFactura").Value
        Dim iTipo As Integer = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value

        imprime(iTipo, iGuia)
    End Sub

    Private Sub btnImprimirLote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirLote.Click
        Try
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de realizar la impresión?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.AppStarting
                Dim fila As Integer
                With Me.DgvLista
                    iOpcion = 2
                    For Each row As DataGridViewRow In .Rows
                        fila = row.Index
                        DgvLista.CurrentCell = DgvLista.Rows(fila).Cells(0)
                        Recupera(fila)
                    Next
                    Cursor = Cursors.Default
                    MessageBox.Show("Se Realizó la impresión", "Imprimir", MessageBoxButtons.OK)
                    iOpcion = 1
                End With
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub GrdDetalleVenta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDetalleVenta.CellContentClick

    End Sub

    Private Sub SeguroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeguroToolStripMenuItem.Click
        Try
            Dim frm As New frmMontoFueraZona
            frm.TotalFZ = Me.DgvLista.CurrentRow.Cells("Total_Costo").Value
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                ActualizarSeguro(frm)
                Me.TxtGuia.Text = Me.DgvLista.CurrentRow.Cells("guia").Value
                Me.Cursor = Cursors.AppStarting
                Dim iGuia As Long = Me.TxtGuia.Text
                Listar(iGuia)
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkRecojo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecojo.CheckedChanged
        Me.cboCanjeado.SelectedIndex = 0
        If chkRecojo.Checked Then
            Me.cboCanjeado.Enabled = True
        Else
            Me.cboCanjeado.Enabled = False
        End If
    End Sub

    Private Sub TxtGuia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGuia.TextChanged

    End Sub
End Class