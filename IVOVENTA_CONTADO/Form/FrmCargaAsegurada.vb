'Imports PrinterTxt
Imports System.Data.Odbc
Imports System.Data
Imports AccesoDatos
Public Class FrmCargaAsegurada

    Dim sDocCliente As String = ""
    Dim objCargaAsegurada As New ClsLbTepsa.dtoCargaAsegurada

    Dim es_carga_asegurada As Boolean
    Const v_ca As String = "->CARGA ASEGURADA"

    Dim ConfiMensajeriaDlg As New FrmConfiMensajeria

    Dim tipo_bole_impre As String
    Dim tipo_factu_impre As String
    Dim CORRELATIVO As String
    Dim ObjfrmBuscarCliente As New frmBuscarCliente
    Dim DlgManteClienteContado As New frmManteClienteContado
    Dim DlgfrmManteClienteContado As New frmManteClienteContado
    'Dim rstDatos As New ADODB.Recordset
    Dim coll_iOrigen As New Collection
    Dim coll_iDestino As New Collection
    Public iWinDestino As New AutoCompleteStringCollection
    Private ObjProcesosVentaContado As New FrmProcesosVentaContado
    Dim bFAC_Bol As Boolean = False  '" FACTURA true    --- -Boleta False
    Dim bControl_Tarifas As Boolean = False

    Dim tarifa_Peso As Double = 0
    Dim tarifa_Volumen As Double = 0
    Dim tarifa_Articulo As Double = 0
    Dim tarifa_Sobre As Double = 0
    Dim Monto_Base As Double = 0
    Dim iTarifa As Integer = 0

    Dim iControlMonto_Base As Double = 1
    Dim iControlFacturacion As Double = 0

    Dim Mro_Digitos_Ventas As Integer = 7
    Dim Mro_Digitos_SerieVentas As Integer = 3
    Dim TipoComprobante As Integer = 2
    Dim varIdCondicion As Integer = 0
    Dim iROW_ACTUAL As Integer = 0
    Dim iCOL_ACTUAL As Integer = 0
    Dim iROW As Integer = 0
    Dim iCOL As Integer = 0
    ' Dim daControl_FAC As New OleDb.OleDbDataAdapter
    Dim dtControl_FAC As New System.Data.DataTable
    Dim dvControl_FAC As System.Data.DataView
    Dim bformatImage As Boolean = False
    Dim IDGRIESTADO_REG As Integer = 27
    Dim IDFACTURADO_REG As Integer = 28

    Dim control_venta As Boolean
    Dim CONTROL As Integer = 1
    Dim coll_Direccion_Remitente As New Collection
    Dim coll_Direccion_Destinatario As New Collection
    Dim coll_Nombres_Remitente As New Collection
    Dim coll_Nombres_Destinatario As New Collection
    Dim ObjIMPRESIONFACT_BOL As New dtoIMPRESIONFACT_BOL
    Dim xCiudadOrigen As String
    Dim xAgenciaLocal As String
    Dim xIMPRESORA As Integer
    Public bControlFiscalizacion As Boolean = False
    Dim fArticulo As Boolean = False

    Dim iDigitosSerie As Integer = 3
    Dim iDigitosDcoumento As Integer = 7
    Dim flagPCE As Boolean = False
    Dim flagPCEVALIDADOC As Boolean = False
    Dim valorf3 As Boolean = False
    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim ObjRptGuiaEnvio As New dtoRptGuiaEnvio()
    Dim v_Origen, v_destino, p_agencia, v_iDestino, v_iCredito, v_iDomicilio, v_iAgencia, p_domicilio, p_contado, p_destino, p_credito, strNroGuias_Remision As String
    ' 03/10/2007 
    Dim b_lee As Boolean = True
    Dim s_persona_remitente As String = ""
    '08/02/2008
    'Dim ldt_tarjeta As New DataTable
    Dim ldv_tarjeta As New DataView

    'hlamas
    Dim iOficinaDestino As Integer
    Dim bMontoMinimo As Boolean
    Dim iFilas As Integer
    Dim iSub_Total_CA As Double = 0, iImpuesto_CA As Double = 0, iTotal_CA As Double = 0
    Dim bCondicion As Boolean = False

    Dim bOtrasAgencias As Boolean
    Dim iOrigen2 As Integer
    Dim iOficinaOrigen As Integer
    Dim bTarifarioGeneral As Boolean
    Dim bContado As Boolean
    Dim bDescuento As Boolean
    Dim iDescuento As Double = 0
    Dim bTieneLineaCredito As Boolean = False
    Dim Iid As String
    Public Shared iTotalPagado As Double = 0
    Public Shared iVuelto As Double = 0
    'Dim bRango As Boolean = False
    '
    Dim iRango As Byte = 0    '0=normal 1=primera vez 2=reimpresion
    Dim sFecha As String
    Dim sHora As String
    Dim frmb_lee As Boolean = True
    '
    Dim b_no_lee_tipo_entrega As Boolean = True
    Dim bIngreso As Boolean = False
    Public hnd As Long

    'conección a athenea-vyr
    Dim cnn As OdbcConnection

    Dim bCargaAcompañada As Boolean = False
    Dim bCargaAcompañada2 As Boolean = False
    Dim iIdFactura As Integer
    Dim bEntra As Boolean = False
    Dim bOrigenDiferente As Boolean = False
    Dim sBoleto As String = ""
    Dim iForma As Integer = 0
    Dim bBoleto As Boolean = False
    Dim bIngresa As Boolean
    Dim bValida As Boolean = False
    Dim bValidaEntrega As Boolean = False
    Dim bTecla As Boolean = False
    Dim iPce As Integer = 0

#Region "VARIABLES DE FILTRO"

    Public iWinContacto_Remitente As New AutoCompleteStringCollection
    Public iWinDireccion_Remitente As New AutoCompleteStringCollection
    Public iWinPerosaDNI_Remite As New AutoCompleteStringCollection

    Public iWinContacto_Destinatario As New AutoCompleteStringCollection
    Public iWinDireccion_Destinatario As New AutoCompleteStringCollection
    Public iWinPerosaDNI_Destino As New AutoCompleteStringCollection

#End Region

    Private Sub FrmCargaAsegurada_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        txtiWinDestino.Focus()
    End Sub
    Private Sub FrmCargAsegurada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AnularToolStripMenuItem.Enabled = False
        recuperando_datos_contado = False
        ReDim objComprobanteAsegurada(19)
        'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
        'objCargaAsegurada.SP_RECUPERA_MONTO_MINIMO_PCE(cnn)
        objCargaAsegurada.SP_RECUPERA_MONTO_MINIMO_PCE()
        '
        bCondicion = False
        sBoleto = ""
        Try
            '''
            frmb_lee = False
            '''
            bTarifarioGeneral = False
            bContado = False
            'Verifica si el usuario puede trabajar otras agencias
            Dim objOtrasAgencias As New dtoCONTROLUSUARIOS
            iOrigen2 = -1
            objOtrasAgencias.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            If objOtrasAgencias.GetOtrasAgencias() Then
                If objOtrasAgencias.iIDOTRAS_AGENCIAS = 1 Then
                    bOtrasAgencias = True
                Else
                    bOtrasAgencias = False
                End If
            Else
                bOtrasAgencias = False
            End If

            '01/10/2007 - Iniciando la variable ObjVentaCargaContado 
            ObjVentaCargaContado = Nothing
            ObjVentaCargaContado = New dtoVentaCargaContado
            '
            If ObjVentaCargaContado.fnCONTROL_VERSIONES() = True Then
                tipo_bole_impre = ObjVentaCargaContado.tipo_bole_impre
                tipo_factu_impre = ObjVentaCargaContado.tipo_factu_impre
            End If
            '
            dtoUSUARIOS.m_iNombreUnidadAgencia = fnGetCiudad(dtoUSUARIOS.m_idciudad.ToString)
            dtoUSUARIOS.m_iNombreAgencia = fnGetAGENCIA(dtoUSUARIOS.m_iIdAgencia.ToString)

            Me.Text = "VENTAS CARGA....." & dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & " [ " & dtoUSUARIOS.m_iNombreAgencia & " ][ " & dtoUSUARIOS.m_iNombreUnidadAgencia & "] "
            'objLOG.fnLog("LOAD MAIN FACTURA")
            ToolStripMenuItem1.Text = "&BUSCAR"
            ToolStripMenuItem2.Text = "&FACTURAS Y/O BOLETAS "
            'Mod.15/09/2009 -->Omendoza - Pasando al datahelper   
            If ObjVentaCargaContado.fnLoadVentaCarga() = True Then
                ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_t_tipo_comprobante, cmbFACBOL, ObjVentaCargaContado.coll_t_tipo_comprobante, 1)
                fnCargar_iWin_dt(txtiWinDestino, ObjVentaCargaContado.dt_cur_UNIDAD_AGENCIAS, coll_iDestino, iWinDestino, 0)
                '
                ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_t_Tipo_Entrega, cmbTipo_Entrega, ObjVentaCargaContado.coll_t_Tipo_Entrega, 1)
                ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_Tipo_Pago, cmbTipoPago, ObjVentaCargaContado.coll_Tipo_Pago, 1)
                ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_t_Forma_Pago, cmbFormaPago, ObjVentaCargaContado.coll_t_Forma_Pago, 1)
                '
                If bOtrasAgencias Then
                    lblOrigen.Visible = True
                    cmbAgenciaOrigen.Visible = True
                    'Mod.16/09/2009 -->Omendoza - Pasando al datahelper   
                    ObjVentaCargaContado.fnGetAgencias_1()

                    'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.rstVarAgencias_1, cmbAgenciaOrigen, ObjVentaCargaContado.coll_AgenciasOrigen, Int(ObjVentaCargaContado.rstVarAgencias_1.Fields(0).Value))
                    'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.rstVarAgencias_1, cmbAgenciaOrigen, ObjVentaCargaContado.coll_AgenciasOrigen, Int(dtoUSUARIOS.m_iIdAgencia.ToString))
                    ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_rstVarAgencias_1, cmbAgenciaOrigen, ObjVentaCargaContado.coll_AgenciasOrigen, Int(dtoUSUARIOS.m_iIdAgencia.ToString))
                Else
                    lblOrigen.Visible = False
                    cmbAgenciaOrigen.Visible = False
                    'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.cur_t_Tipo_Entrega, cmbTipo_Entrega, ObjVentaCargaContado.coll_t_Tipo_Entrega, 1)
                    'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.cur_Tipo_Pago, cmbTipoPago, ObjVentaCargaContado.coll_Tipo_Pago, 1)
                    'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.cur_t_Forma_Pago, cmbFormaPago, ObjVentaCargaContado.coll_t_Forma_Pago, 1)                

                    'ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_t_Tipo_Entrega, cmbTipo_Entrega, ObjVentaCargaContado.coll_t_Tipo_Entrega, 1)
                    'ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_Tipo_Pago, cmbTipoPago, ObjVentaCargaContado.coll_Tipo_Pago, 1)
                    'ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_t_Forma_Pago, cmbFormaPago, ObjVentaCargaContado.coll_t_Forma_Pago, 1)
                End If

                '08/02/2008
                Try
                    'daControl_FAC.Fill(ldt_tarjeta, ObjVentaCargaContado.cur_T_TARJETAS)
                    'ldv_tarjeta = CargarCombo(Me.cmbTargeta, ldt_tarjeta, "descripcion", "idtarjetas", 0)
                    ldv_tarjeta = CargarCombo(Me.cmbTargeta, ObjVentaCargaContado.dt_cur_T_TARJETAS, "descripcion", "idtarjetas", 0)
                    '
                    'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.cur_T_TARJETAS, cmbTargeta, ObjVentaCargaContado.coll_T_TARJETAS, 1)
                Catch ex As Exception
                    Dim ls_string As String
                    ls_string = ex.Message
                End Try
            End If
            'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnLISTA_AGENCIAS_UNIDADES() = True Then
                'ModuUtil.LlenarComboIDs2(objGuiaEnvio.rst_Lista_Unidades_Agencia, cmbOrigen, objGuiaEnvio.coll_Lista_Origen, 9999, cmbDestino, objGuiaEnvio.coll_Lista_Destino, 9999)
                ModuUtil.LlenarComboIDs2(objGuiaEnvio.dt_Lista_Unidades_Agencia, cmbOrigen, objGuiaEnvio.coll_Lista_Origen, 9999, cmbDestino, objGuiaEnvio.coll_Lista_Destino, 9999)
            End If
            '
            'rst = New ADODB.Recordset
            'rst = VOCONTROLUSUARIO.ListarAgencias(-1)
            '
            Dim lobj_adoserver As New AdoServer

            lobj_adoserver.ListarAgencias()
            '
            'ModuUtil.LlenarComboIDs(rst, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            ModuUtil.LlenarComboIDs_dt(lobj_adoserver.dt_Listar_agencias, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            'ModuUtil.LlenarComboIDs(rst, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            '
            'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA(dtoUSUARIOS.m_iIdAgencia) = True Then
                '01/09/2009 - Mod. x Datahelper x Datatable 
                'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
                ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
            Else
                NingunoComboIDs(cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios)
            End If
            '
            'Mod.15/09/2009 -->Omendoza - Pasando al datahelper   
            '
            'rst = Nothing
            'rst = ObjVentaCargaContado.fnListarEstadoFactura()
            Dim ldt_tmp As New DataTable
            ldt_tmp = ObjVentaCargaContado.fnListarEstadoFactura()
            ModuUtil.LlenarComboIDs_dt(ldt_tmp, cmbEstados, objGuiaEnvio.coll_Lista_Estados, 999)
            fnLoadGrid()
            ',              'txtAgenDestino
            txtFecha.Text = dtoUSUARIOS.m_sFecha
            txtiWinDestino.Focus()
            txtiWinDestino.SelectAll()

            If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, ChkProceso.Checked) = True Then
                txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
            ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0) = True Then
                txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
            Else
                MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
            End If
            'cmbCondicionPago
            'cmbFormaPago
            'cmbTargeta
            SelectMenu(1)

            txtiWinDestino.SelectAll()
            txtiWinDestino.Focus()
            dtFechaInicio.Text = dtoUSUARIOS.m_sFecha
            dtFechaFin.Text = dtoUSUARIOS.m_sFecha

            'If fnValidar_Rol("18") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 1) Then
                cmbAgencia.Enabled = False
                cmbUsuarios.Enabled = False
                btnNuevo.Enabled = False
                btnAnular.Enabled = False
                btnDevolucion.Enabled = False
            End If

            'If fnValidar_Rol("23") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 2) Then
                cmbAgencia.Enabled = False
                cmbUsuarios.Enabled = False
                btnNuevo.Enabled = True
                btnAnular.Enabled = True
                btnDevolucion.Enabled = True
            End If

            'If fnValidar_Rol("14") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 3) Then
                cmbAgencia.Enabled = True
                cmbUsuarios.Enabled = True
                btnNuevo.Enabled = True
                btnAnular.Enabled = True
                btnDevolucion.Enabled = True
            End If
            lbFactBoleta.Text = "BOLETA VENTA"
            If es_carga_asegurada Then
                lblCarga.Visible = True
            Else
                lblCarga.Visible = False
            End If

            'hlamas 08-10-2010 carga acompañada
            If bCargaAcompañada Then
                lblCarga.Text = "--> CARGA ACOMPAÑADA"
                lblCarga.Visible = True
            Else
                lblCarga.Text = "--> CARGA ASEGURADA"
                lblCarga.Visible = False
            End If

            bFAC_Bol = False
            TipoComprobante = 2
            If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, ChkProceso.Checked) = True Then
                txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
            ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0) = True Then
                txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
            Else
                MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
            End If
            xIMPRESORA = fnSeleccionImpresion()
            fnLoadGrid_Control()

            If dtGridViewArticulo.Visible Then
                lblMontoBase.Visible = True
                txtMontoBase.Visible = True
            Else
                lblMontoBase.Visible = False
                txtMontoBase.Visible = False
            End If
            txtiWinDestino.Focus()
            '''''
            frmb_lee = True
            '''''

            If ObjVentaCargaContado.v_IDAGENCIAS = 0 Then
                ObjVentaCargaContado.v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
            End If

            If dtoGuiaEnvio.AccesoPyme(dtoUSUARIOS.IP) = 1 Then
                Me.ChkProceso.Visible = True
                bPyme = True
            Else
                Me.ChkProceso.Visible = False
                bPyme = False
            End If

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            'objLOG.fnLogErr(ex.ToString)
            dtFechaInicio.Text = dtoUSUARIOS.m_sFecha
            dtFechaFin.Text = dtoUSUARIOS.m_sFecha
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub btnEnditarOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnditarOrigen.Click
    '    Try
    '        If DlgManteClienteContado.ShowDialog() = Windows.Forms.DialogResult.OK Then

    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    Private Sub cmbTipoPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoPago.SelectedIndexChanged
        Try
            varIdCondicion = Int(ObjVentaCargaContado.coll_Tipo_Pago.Item(cmbTipoPago.SelectedIndex.ToString))
            If varIdCondicion = 2 Then
                lbTargeta.Visible = True
                cmbTargeta.Visible = True
                txtNroTarjeta.Visible = True
                txtPorcernt_Descuento.Enabled = True
                cmbTargeta.Enabled = True
                txtNroTarjeta.Enabled = True
                txtNroTarjeta.ReadOnly = False '09/08/2007
            Else
                If varIdCondicion = 5 Then
                    txtPorcernt_Descuento.Enabled = False
                    lbMemo.Visible = True
                    txtMemo.Visible = True

                    lbTargeta.Visible = False
                    cmbTargeta.Visible = False
                    txtNroTarjeta.Visible = False
                    cmbTargeta.Enabled = False
                    txtNroTarjeta.Enabled = False
                Else
                    lbTargeta.Visible = False
                    cmbTargeta.Visible = False
                    txtNroTarjeta.Visible = False
                    cmbTargeta.Enabled = False
                    txtNroTarjeta.Enabled = False
                    txtPorcernt_Descuento.Enabled = True
                End If
                '''                
            End If
            If frmb_lee = True Then
                If cmbTargeta.Visible = True Then
                    Me.cmbTargeta.Focus()
                Else
                    Me.txtDocCliente_Remitente.Focus()
                End If
            End If
            '''
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Public Function fnLoadGrid() As Boolean  ' Omendoza 
        Try
            With dtGridViewControl_FACBOL
                '    .AllowUserToAddRows = False
                '    .AllowUserToDeleteRows = False
                '    .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                '    .AutoGenerateColumns = False
                '    '.DataSource = dtable_Lista_Control_Comprobante
                '    .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            Dim idEstadoImage As New DataGridViewImageColumn
            With idEstadoImage
                .DataPropertyName = "imagen"
                .HeaderText = "CL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DisplayIndex = 0
                .Visible = True
                '.ValuesAreIcons = True
                '.InheritedStyle.BackColor = Color.Transparent
                .Image = bmActivo
            End With
            dtGridViewControl_FACBOL.Columns.Add(idEstadoImage)

            Dim colID As New DataGridViewTextBoxColumn
            With colID
                .DisplayIndex = 1
                .DataPropertyName = "Idfactura"
                .Name = "Idfactura"
                .HeaderText = "Idfactura"

                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(colID)

            Dim colIDESTADO As New DataGridViewTextBoxColumn
            With colIDESTADO
                .DisplayIndex = 2
                .Name = "Idestado_Factura"
                .DataPropertyName = "Idestado_Factura"
                .HeaderText = "Idestado_Factura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(colIDESTADO)


            Dim FAC_BOL As New DataGridViewTextBoxColumn
            With FAC_BOL
                .DisplayIndex = 3
                .DataPropertyName = "FAC_BOL"
                .Name = "FAC_BOL"
                .HeaderText = "FAC/BOL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(FAC_BOL)

            Dim TIPO As New DataGridViewTextBoxColumn
            With TIPO
                .DisplayIndex = 4
                .DataPropertyName = "Tipo"
                .HeaderText = "TIPO"
                .Name = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(TIPO)
            Dim Fecha_Factura As New DataGridViewTextBoxColumn
            With Fecha_Factura
                .DisplayIndex = 5
                .DataPropertyName = "Fecha_Factura"
                .Name = "Fecha_Factura"
                .HeaderText = "FECHA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Fecha_Factura)
            Dim Origen As New DataGridViewTextBoxColumn
            With Origen
                .DisplayIndex = 6
                .DataPropertyName = "Origen"
                .Name = "Origen"
                .HeaderText = "ORIGEN"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Origen)
            Dim Destino As New DataGridViewTextBoxColumn
            With Destino
                .DisplayIndex = 7
                .DataPropertyName = "Destino"
                .HeaderText = "DESTNO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Destino)
            Dim Trancito As New DataGridViewTextBoxColumn
            With Trancito
                .DisplayIndex = 8
                .DataPropertyName = "Trancito"
                .HeaderText = "TRANSITO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Trancito)

            Dim DNI_RUC As New DataGridViewTextBoxColumn
            With DNI_RUC
                .DisplayIndex = 9
                .DataPropertyName = "DNI_RUC"
                .Name = "DNI_RUC"
                .HeaderText = "DNI/RUC"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(DNI_RUC)

            Dim razon_social As New DataGridViewTextBoxColumn
            With razon_social
                .DisplayIndex = 10
                .DataPropertyName = "razon_social"
                .HeaderText = "RAZON SOCIAL"
                .Name = "razon_social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(razon_social)
            Dim Tipo_Pago As New DataGridViewTextBoxColumn
            With Tipo_Pago
                .DisplayIndex = 11
                .DataPropertyName = "Tipo_Pago"
                .HeaderText = "TIPO PAGO"
                .Name = "Tipo_Pago"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Tipo_Pago)
            Dim forma_pago As New DataGridViewTextBoxColumn
            With forma_pago
                .DisplayIndex = 12
                .DataPropertyName = "forma_pago"
                .Name = "forma_pago"
                .HeaderText = "FORMA PAGO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(forma_pago)

            Dim cantidad As New DataGridViewTextBoxColumn
            With cantidad
                .DisplayIndex = 13
                .DataPropertyName = "cantidad"
                .HeaderText = "CANTIDAD"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(cantidad)

            Dim Total_Peso As New DataGridViewTextBoxColumn
            With Total_Peso
                .DisplayIndex = 14
                .DataPropertyName = "Total_Peso"
                .HeaderText = "TOT. PESO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Total_Peso)

            Dim Total_Volumen As New DataGridViewTextBoxColumn
            With Total_Volumen
                .DisplayIndex = 15
                .DataPropertyName = "Total_Volumen"
                .HeaderText = "TOT. VOL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Total_Volumen)

            Dim Precio_x_Peso As New DataGridViewTextBoxColumn
            With Precio_x_Peso
                .DisplayIndex = 16
                .DataPropertyName = "Precio_x_Peso"
                .HeaderText = "P. PESO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Precio_x_Peso)

            Dim Precio_x_Volumen As New DataGridViewTextBoxColumn
            With Precio_x_Volumen
                .DisplayIndex = 17
                .DataPropertyName = "Precio_x_Volumen"
                .HeaderText = "P. VOL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Precio_x_Volumen)

            Dim Precio_x_Sobre As New DataGridViewTextBoxColumn
            With Precio_x_Sobre
                .DisplayIndex = 18
                .DataPropertyName = "Precio_x_Sobre"
                .HeaderText = "P. SOBRE"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Precio_x_Sobre)

            Dim Monto_Base As New DataGridViewTextBoxColumn
            With Monto_Base
                .DisplayIndex = 19
                .DataPropertyName = "Monto_Base"
                .HeaderText = "BASE"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Monto_Base)

            Dim Porcent_Descuento As New DataGridViewTextBoxColumn
            With Porcent_Descuento
                .DisplayIndex = 20
                .DataPropertyName = "Porcent_Descuento"
                .HeaderText = "% DESC"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Porcent_Descuento)

            Dim Monto_Impuesto As New DataGridViewTextBoxColumn
            With Monto_Impuesto
                .DisplayIndex = 21
                .DataPropertyName = "Monto_Impuesto"
                .Name = "Monto_Impuesto"
                .HeaderText = "IGV"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Monto_Impuesto)

            Dim Monto_Sub_Total As New DataGridViewTextBoxColumn
            With Monto_Sub_Total
                .DisplayIndex = 22
                .DataPropertyName = "Monto_Sub_Total"
                .Name = "Monto_Sub_Total"
                .HeaderText = "SUB TOTAL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Monto_Sub_Total)
            'dtGridViewControl_FACBOL.Rows(0).Visible = False

            Dim Total_Costo As New DataGridViewTextBoxColumn
            With Total_Costo
                .DisplayIndex = 23
                .DataPropertyName = "Total_Costo"
                .Name = "Total_Costo"
                .HeaderText = "TOTAL COSTO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Total_Costo)

            Dim login_creacion As New DataGridViewTextBoxColumn
            With login_creacion
                .DisplayIndex = 24
                .DataPropertyName = "login_creacion"
                .HeaderText = "USUARIO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(login_creacion)

            Dim Estado_Doc As New DataGridViewTextBoxColumn
            With Estado_Doc
                .DisplayIndex = 25
                .DataPropertyName = "Estado_Doc"
                .HeaderText = "ESTADO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Estado_Doc)

            Dim Estado_Envio As New DataGridViewTextBoxColumn
            With Estado_Envio
                .DisplayIndex = 26
                .DataPropertyName = "Estado_Envio"
                .HeaderText = "EST. ENVIO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Estado_Envio)

            Dim Idestado_Factura As New DataGridViewTextBoxColumn
            With Idestado_Factura
                .DisplayIndex = 27
                .Name = "Idestado_Factura"
                .DataPropertyName = "Idestado_Factura"
                .HeaderText = "EST. ENVIO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Idestado_Factura)

            Dim Facturado As New DataGridViewTextBoxColumn
            With Facturado
                .DisplayIndex = 28
                .Name = "Facturado"
                .DataPropertyName = "Facturado"
                .HeaderText = "FACTURADO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Facturado)
            '
            Dim Idtipo_Comprobante As New DataGridViewTextBoxColumn
            With Idtipo_Comprobante
                .DisplayIndex = 29
                .Name = "Idtipo_Comprobante"
                .DataPropertyName = "Idtipo_Comprobante"
                .HeaderText = "ID Tipo Comp."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Idtipo_Comprobante)
            '
            Dim Idunidad_Destino As New DataGridViewTextBoxColumn
            With Idunidad_Destino
                .DisplayIndex = 30
                .Name = "Idunidad_Destino"
                .DataPropertyName = "Idunidad_Destino"
                .HeaderText = "Ciudad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Idunidad_Destino)
            '
            Dim Idagencias_Destino As New DataGridViewTextBoxColumn
            With Idagencias_Destino
                .DisplayIndex = 31
                .Name = "Idagencias_Destino"
                .DataPropertyName = "Idagencias_Destino"
                .HeaderText = "Agencia Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Idagencias_Destino)
            '
            Dim tipo_comprobante As New DataGridViewTextBoxColumn
            With tipo_comprobante
                .DisplayIndex = 32
                .Name = "tipo_comprobante"
                .DataPropertyName = "tipo_comprobante"
                .HeaderText = "Tipo Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(tipo_comprobante)
            '
            Dim Idforma_Pago As New DataGridViewTextBoxColumn
            With Idforma_Pago
                .DisplayIndex = 33
                .Name = "Idforma_Pago"
                .DataPropertyName = "Idforma_Pago"
                .HeaderText = "Id Forma Pago"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Idforma_Pago)
            '
            Dim lfecha_documento As New DataGridViewTextBoxColumn
            With lfecha_documento
                .DisplayIndex = 34
                .Name = "fecha_documento"
                .DataPropertyName = "fecha_documento"
                .HeaderText = "Fecha Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(lfecha_documento)
            '
            Dim lidagencia_origen As New DataGridViewTextBoxColumn
            With lidagencia_origen
                .DisplayIndex = 35
                .Name = "idagencia_origen"
                .DataPropertyName = "idagencia_origen"
                .HeaderText = "Id agencia Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(lidagencia_origen)
            '
            Dim lIdunidad_Origen As New DataGridViewTextBoxColumn
            With lIdunidad_Origen
                .DisplayIndex = 36
                .Name = "Idunidad_Origen"
                .DataPropertyName = "Idunidad_Origen"
                .HeaderText = "Id Unidad_Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(lIdunidad_Origen)

            'Dim proceso As New DataGridViewTextBoxColumn
            'With lIdunidad_Origen
            '    .DisplayIndex = 37
            '    .Name = "Idunidad_Origen"
            '    .DataPropertyName = "idprocesos"
            '    .HeaderText = "Proceso"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = False
            'End With
            'dtGridViewControl_FACBOL.Columns.Add(proceso)

            '
            'Dim Nro_Guia As New DataGridViewTextBoxColumn
            'With Nro_Guia
            '    .DisplayIndex = 28
            '    .DataPropertyName = "Nro_Guia"
            '    .HeaderText = "Nro_GUIA"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'dtGridViewControl_FACBOL.Columns.Add(Nro_Guia)

            With dtGridViewBultos
                '.Dock = DockStyle.Fill
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToOrderColumns = False
                '.RowsDefaultCellStyle.WrapMode =
                .AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = False
                .AutoGenerateColumns = False
                '.DataSource = dtable_Lista_Control_Comprobante
                .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersWidth = 14
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            Dim col As New DataGridViewTextBoxColumn
            With col
                .DisplayIndex = 0
                .DataPropertyName = "var"
                .HeaderText = "ID"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewBultos.Columns.Add(col)
            Dim col0 As New DataGridViewTextBoxColumn
            With col0
                .DisplayIndex = 1
                .DataPropertyName = "TIPO PROCESO"
                .HeaderText = "TIPO"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 80
            End With
            dtGridViewBultos.Columns.Add(col0)

            Dim col2 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .DisplayIndex = 2
                .DataPropertyName = "Cantidad"
                .HeaderText = "PIEZAS"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Mask = "####0"
                .ReadOnly = False
            End With
            dtGridViewBultos.Columns.Add(col2)

            Dim col01 As New DataGridViewTextBoxColumn
            With col01
                .DisplayIndex = 3
                .DataPropertyName = "DESCRIPCION"
                .HeaderText = "DESCRIPCION"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dtGridViewBultos.Columns.Add(col01)

            'Dim col1 As New DataGridViewTextBoxColumn
            Dim col1 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .DisplayIndex = 4
                .DataPropertyName = "PESO_VOLUMEN"
                .HeaderText = "PESO/VOLUMEN"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.Mask = "####,###,###.000"
                .DefaultCellStyle.Format = "####,###,###.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            dtGridViewBultos.Columns.Add(col1)
            '-------------------------------------------------------------------------------
            Dim col31 As New DataGridViewTextBoxColumn
            With col31
                .DisplayIndex = 5
                .DataPropertyName = "COSTO"
                .HeaderText = "COSTO"
                .ReadOnly = True
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Mask = "99999999.999" 'Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
                .DefaultCellStyle.Format = "##,###,###.00"
                .DefaultCellStyle.NullValue = "0.00"
                '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
                .Width = 100
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            dtGridViewBultos.Columns.Add(col31)
            '-------------------------------------------------------------------------

            'Dim col3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            Dim col3 As New DataGridViewTextBoxColumn
            With col3
                .DisplayIndex = 6
                .DataPropertyName = "DESCUENTO"
                .HeaderText = "DESCUENTO"
                .ReadOnly = True
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Mask = "99999999.999" 'Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
                .DefaultCellStyle.Format = "##,###,###.00"
                .DefaultCellStyle.NullValue = "0.00"
                '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
                .Width = 100
                .Visible = False
            End With
            dtGridViewBultos.Columns.Add(col3)

            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .DisplayIndex = 7
                .DataPropertyName = "NETO"
                .HeaderText = "SUB_NETO"
                .ReadOnly = True
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Mask = "99999999.999" 'Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
                .DefaultCellStyle.Format = "##,###,###.00"
                .DefaultCellStyle.NullValue = "0.00"
                '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
                .Width = 100
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            dtGridViewBultos.Columns.Add(col4)

            Dim row0 As String() = {"", "PESO", "", "BULTOS", "", "0.00", "0.00", "0.00"}
            dtGridViewBultos.Rows().Add(row0)
            Dim row1 As String() = {"", "VOLUMEN", "", "BULTOS", "", "0.00", "0.00", "0.00"}
            dtGridViewBultos.Rows().Add(row1)
            Dim row2 As String() = {"", "SOBRE", "", "", "", "0.00", "0.00", "0.00"}
            dtGridViewBultos.Rows().Add(row2)
            Dim row3 As String() = {"", "BASE", "", "", "", "0.00", "0.00", "0.00"}
            dtGridViewBultos.Rows().Add(row3)
            'Dim row4 As String() = {"", "CA", "", "", "", "", "", "0.00"}
            'dtGridViewBultos.Rows().Add(row4)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Function

    'Private Sub cmbFACBOL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFACBOL.SelectedIndexChanged, cmbAgenciaVenta.SelectedIndexChanged
    '    Try
    '        lbFactBoleta.Text = "BOLETA VENTA"
    '        TipoComprobante = 2
    '    Catch ex As Exception
    '        lbFactBoleta.Text = "ERROR...."
    '    End Try
    'End Sub
    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClienteDNIRUC.KeyPress, txtDNIDestinatario.KeyPress, txtTelefonoRemitente.KeyPress, txtTelefonoDestinatario.KeyPress, txtClienteDNIRUC.KeyPress, txtSERIE.KeyPress, txtNroDocFACBOL.KeyPress, txtDocCliente_Remitente.KeyPress, txtDNIContacto.KeyPress, txtNroGuia.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)

            If tb.Name.ToUpper = "txtDocCliente_Remitente".ToUpper Then
                bTecla = True
            End If

            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(e.KeyChar)
                'e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                'ElseIf e.KeyChar = "." Then
                'If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                'e.Handled = True
                'End If
                'ElseIf e.KeyChar = "-" Then
                'If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                'e.Handled = True
                'End If
            ElseIf Not Char.IsControl(e.KeyChar) Then
                If e.KeyChar = "-" Then
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub txtiWinDestino_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtiWinDestino.Validating
        Try
            '04/10/2007 
            'Dim lidagencias As Long
            'hlamas
            If txtiWinDestino.ReadOnly And Not bCargaAcompañada Then Exit Try

            Dim idUnidadAgencias As Integer = iWinDestino.IndexOf(txtiWinDestino.Text)
            If idUnidadAgencias >= 0 Then
                idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))
                If idUnidadAgencias = iOficinaDestino Then Exit Sub
                If idUnidadAgencias > 0 Then
                    'hlamas
                    If idUnidadAgencias <> iOficinaDestino Then
                        bCondicion = False
                        dtGridViewBultos.Rows(0).Cells(2).Value = ""
                        dtGridViewBultos.Rows(1).Cells(2).Value = ""
                        dtGridViewBultos.Rows(2).Cells(2).Value = ""
                        dtGridViewBultos.Rows(3).Cells(2).Value = ""

                        dtGridViewBultos.Rows(0).Cells(4).Value = ""
                        dtGridViewBultos.Rows(1).Cells(4).Value = ""
                        dtGridViewBultos.Rows(2).Cells(4).Value = ""
                        dtGridViewBultos.Rows(3).Cells(4).Value = ""

                        'hlamas
                        txtSub_Total.Text = ""
                        txtMonto_IGV.Text = ""
                        txtCosto_Total.Text = ""
                    End If

                    ObjVentaCargaContado.fnGetAgencias(idUnidadAgencias)
                    ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_VarAgencias, cmbAgenciaVenta, ObjVentaCargaContado.coll_AgenciasVenta, Int(ObjVentaCargaContado.dt_VarAgencias.Rows(0).Item(0)))
                    fnTarifario()
                Else
                    cmbAgenciaVenta.Controls.Clear()
                    cmbAgenciaVenta.Items.Clear()
                End If
            ElseIf dtGridViewBultos.Rows.Count > 0 Then

                dtGridViewBultos.Rows(0).Cells(2).Value = ""
                dtGridViewBultos.Rows(1).Cells(2).Value = ""
                dtGridViewBultos.Rows(2).Cells(2).Value = ""
                dtGridViewBultos.Rows(3).Cells(2).Value = ""

                dtGridViewBultos.Rows(0).Cells(3).Value = ""
                dtGridViewBultos.Rows(1).Cells(3).Value = ""
                dtGridViewBultos.Rows(2).Cells(3).Value = ""
                dtGridViewBultos.Rows(3).Cells(3).Value = ""

                dtGridViewBultos.Rows(0).Cells(4).Value = ""
                dtGridViewBultos.Rows(1).Cells(4).Value = ""
                dtGridViewBultos.Rows(2).Cells(4).Value = ""
                dtGridViewBultos.Rows(3).Cells(4).Value = ""

                dtGridViewBultos.Rows(0).Cells(6).Value = ""
                dtGridViewBultos.Rows(1).Cells(6).Value = ""
                dtGridViewBultos.Rows(2).Cells(6).Value = ""
                dtGridViewBultos.Rows(3).Cells(6).Value = ""

                dtGridViewBultos.Rows(0).Cells(5).Value = "0.00"
                dtGridViewBultos.Rows(1).Cells(5).Value = "0.00"
                dtGridViewBultos.Rows(2).Cells(5).Value = "0.00"
                dtGridViewBultos.Rows(3).Cells(5).Value = "0.00"

                dtGridViewBultos.Rows(0).Cells(7).Value = "0.00"
                dtGridViewBultos.Rows(1).Cells(7).Value = "0.00"
                dtGridViewBultos.Rows(2).Cells(7).Value = "0.00"
                dtGridViewBultos.Rows(3).Cells(7).Value = "0.00"
                Me.txtSub_Total.Text = ""
                Me.txtMonto_IGV.Text = ""
                Me.txtCosto_Total.Text = ""
            End If

            If Not bCargaAcompañada Then
                If txtDocCliente_Remitente.Text.Length > 0 Then
                    fnBuscarCliente()
                End If
            Else
                If Not bValidaEntrega Then
                    If txtDocCliente_Remitente.Text.Length > 0 Then
                        fnBuscarCliente()
                    End If
                End If
            End If

            'If idUnidadAgencias <> iOficinaDestino Then
            If dtGridViewArticulo.Visible Then
                fArticulo = False
                dtGridViewBultos.Visible = True
                dtGridViewArticulo.Visible = False
                lbArticulos.Text = "( F11 ) ARTICULOS"
                dtGridViewBultos.Focus()
                'fnControlArticulo_Peso()

                txtTotalSobre.Visible = False
                txtCantidadSobres.Visible = False
                checkSobres.Visible = False
                txtCantidadSobres.Text = 0
            End If
            'End If
            iOficinaDestino = idUnidadAgencias

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub txtDocCliente_Remitente_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDocCliente_Remitente.Validating
        Try
            'hlamas
            If txtDocCliente_Remitente.Text.Trim = sDocCliente Then Exit Sub
            If bBoleto Then
                If Not bValida Then
                    bValida = False
                    Return
                End If
            End If
            bCondicion = False
            objGuiaEnvio.iPeso_Maximo = 0
            objGuiaEnvio.iPrecio_cond_Peso = 0
            If flagPCE = False Then limpiar_documentos_cliente()
            agregar_documentos_asegurados()
            If flagPCEVALIDADOC = False Then
                fnVALIDARDOCUMENTOS()
            Else
                Try
                    If fnValidarRUC(txtDocCliente_Remitente.Text.ToString) Then
                        lbFactBoleta.Text = "FACTURA"
                        If es_carga_asegurada Then
                            lblCarga.Visible = True
                        Else
                            lblCarga.Visible = False
                        End If

                        'hlamas 08-10-2010 carga acompañada
                        If bCargaAcompañada Then
                            lblCarga.Text = "--> CARGA ACOMPAÑADA"
                            lblCarga.Visible = True
                        Else
                            lblCarga.Text = "--> CARGA ASEGURADA"
                            lblCarga.Visible = False
                        End If


                        bFAC_Bol = True
                        TipoComprobante = 1
                        If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, ChkProceso.Checked) = True Then
                            txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                        ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0) = True Then
                            txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                        Else
                            MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
                        End If
                    Else
                        lbFactBoleta.Text = "BOLETA VENTA"
                        If es_carga_asegurada Then
                            lblCarga.Visible = True
                        Else
                            lblCarga.Visible = False
                        End If

                        'hlamas 08-10-2010 carga acompañada
                        If bCargaAcompañada Then
                            lblCarga.Text = "--> CARGA ACOMPAÑADA"
                            lblCarga.Visible = True
                        Else
                            lblCarga.Text = "--> CARGA ASEGURADA"
                            lblCarga.Visible = False
                        End If

                        bFAC_Bol = False
                        TipoComprobante = 2
                        If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, ChkProceso.Checked) = True Then
                            txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                        ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0) = True Then
                            txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                        Else
                            MsgBox("No podra Realizar esta Operación El Nro de Factura/Boleta no esta configurado")
                        End If
                    End If
                    '
                    If ObjVentaCargaContado.fnSP_BUSCAR_PERSONA(txtDocCliente_Remitente.Text) = True Then
                        ObjVentaCargaContado.v_IDPERSONA = ObjVentaCargaContado.v_IDNOMBRES_CONTROL
                        ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL = ObjVentaCargaContado.v_NOMBRES_CONTROL
                        ObjVentaCargaContado.v_NRO_DNI_RUC = ObjVentaCargaContado.v_DNI_CONTROL
                        txtCliente_Remitente.Text = ObjVentaCargaContado.v_NOMBRES_CONTROL
                        '04/10/2007 - Persona remitente 
                        s_persona_remitente = txtCliente_Remitente.Text
                        '
                        Me.txtTelefonoRemitente.Text = ObjVentaCargaContado.v_TELEFONO_REMITENTE
                        '
                        If bCargaAcompañada Then
                            Me.txtDocCliente_Remitente.Tag = ObjVentaCargaContado.v_TIPO_DOCUMENTO
                        End If
                        txtCliente_Remitente.Focus()
                        txtCliente_Remitente.SelectAll()
                    Else
                        'txtDocCliente_Remitente.Text = ""
                        txtCliente_Remitente.Text = ""
                        txtCliente_Remitente.Focus()
                        txtCliente_Remitente.Tag = Nothing
                        'txtDireccionRemitente.Text = ""
                    End If
                Catch ex As Exception
                    '
                End Try
                valorf3 = True
            End If
            sDocCliente = txtDocCliente_Remitente.Text.Trim
        Catch ex As Exception

        End Try
    End Sub
    Private Function fnVALIDARDOCUMENTOS() As Boolean
        Try
            If txtDocCliente_Remitente.Text.Length = 11 Then
                If fnValidarRUC(txtDocCliente_Remitente.Text.ToString) Then
                    lbFactBoleta.Text = "FACTURA"
                    If es_carga_asegurada Then
                        lblCarga.Visible = True
                    Else
                        lblCarga.Visible = False
                    End If

                    'hlamas 08-10-2010 carga acompañada
                    If bCargaAcompañada Then
                        lblCarga.Text = "--> CARGA ACOMPAÑADA"
                        lblCarga.Visible = True
                    Else
                        lblCarga.Text = "--> CARGA ASEGURADA"
                        lblCarga.Visible = False
                    End If

                    bFAC_Bol = True
                    TipoComprobante = 1
                    If flagPCEVALIDADOC = False Then
                        fnTarifario()
                    End If
                    If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, ChkProceso.Checked) = True Then
                        txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                        txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                    ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0) = True Then
                        txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                        txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                    Else
                        MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
                    End If
                Else
                    If bCargaAcompañada Then
                        Return True
                    End If
                    MsgBox("El Valor del Nro de RUC es Invalido para la SUNAT, Revise el Nro de RUC", MsgBoxStyle.Information, "Seguridad Sistema")
                    If flagPCEVALIDADOC = False Then
                        fnTarifario()
                    End If
                    lbFactBoleta.Text = "BOLETA VENTA"
                    If es_carga_asegurada Then
                        lblCarga.Visible = True
                    Else
                        lblCarga.Visible = False
                    End If

                    'hlamas 08-10-2010 carga acompañada
                    If bCargaAcompañada Then
                        lblCarga.Text = "--> CARGA ACOMPAÑADA"
                        lblCarga.Visible = True
                    Else
                        lblCarga.Text = "--> CARGA ASEGURADA"
                        lblCarga.Visible = False
                    End If


                    bFAC_Bol = False
                    txtDocCliente_Remitente.SelectAll()
                    txtDocCliente_Remitente.Focus()
                    TipoComprobante = 2
                    If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, ChkProceso.Checked) = True Then
                        txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                        txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                    ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0) = True Then
                        txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                        txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                    Else
                        MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
                    End If
                End If

            ElseIf txtDocCliente_Remitente.Text.Length = 8 Or bIngresa Then
                If flagPCEVALIDADOC = False Then
                    fnTarifario()
                End If
                lbFactBoleta.Text = "BOLETA VENTA"
                If es_carga_asegurada Then
                    lblCarga.Visible = True
                Else
                    lblCarga.Visible = False
                End If

                'hlamas 08-10-2010 carga acompañada
                If bCargaAcompañada Then
                    lblCarga.Text = "--> CARGA ACOMPAÑADA"
                    lblCarga.Visible = True
                Else
                    lblCarga.Text = "--> CARGA ASEGURADA"
                    lblCarga.Visible = False
                End If


                bFAC_Bol = False
                TipoComprobante = 2
                If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, ChkProceso.Checked) = True Then
                    txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                    txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0) = True Then
                    txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                    txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                Else
                    MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
                End If
            Else
                If txtiWinDestino.Text <> "" Then
                    If flagPCEVALIDADOC = False Then
                        fnTarifario()
                    End If
                Else
                    ' MsgBox("Debe Elegir un destino...", MsgBoxStyle.Information, "Seguridad Sistema")
                    Return False
                End If
                If bCargaAcompañada Then
                    Return True
                End If
                MsgBox("El Valor del Nro de Documento es Invalido para la SUNAT ", MsgBoxStyle.Information, "Seguridad Sistema")
                lbFactBoleta.Text = "BOLETA VENTA"
                If es_carga_asegurada Then
                    lblCarga.Visible = True
                Else
                    lblCarga.Visible = False
                End If

                'hlamas 08-10-2010 carga acompañada
                If bCargaAcompañada Then
                    lblCarga.Text = "--> CARGA ACOMPAÑADA"
                    lblCarga.Visible = True
                Else
                    lblCarga.Text = "--> CARGA ASEGURADA"
                    lblCarga.Visible = False
                End If


                Me.txtDocCliente_Remitente.Focus()

                'txtDocCliente_Remitente.Text = ""
                'txtDocCliente_Remitente.Focus()
                bFAC_Bol = False
                TipoComprobante = 2
                If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, ChkProceso.Checked) = True Then
                    txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                    txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0) = True Then
                    txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                    txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                Else
                    MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
                End If
            End If
            '            cmbTipoPago.SelectedIndex.ToString  
            'Dim varid_tmp As Integer = Int(ObjVentaCargaContado.coll_Tipo_Pago(cmbTipoPago.SelectedIndex.ToString))
            Dim varid_tmp As Integer = ObjVentaCargaContado.coll_t_Forma_Pago(cmbFormaPago.SelectedIndex.ToString)
            iForma = varid_tmp
            If varid_tmp = 4 Then varid_tmp = 3
            If varid_tmp = 3 Then
                lbNombresRasonSocial.Text = "CLIENTE"
                lbFacturador.Text = "FACTURAR A :"
                txtNroGuia.Text = ""
                txtNroGuia.Visible = True
                txtSERIE.Visible = False
                txtSERIE.Text = "000"
                txtNroDocFACBOL.Visible = False
                TipoComprobante = 3
                If ObjVentaCargaContado.fnNroDocuemnto(3, ChkProceso.Checked) = True Then
                    txtNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                    'txtNroGuia.SelectAll()
                    'txtNroGuia.Focus()
                    txtCliente_Remitente.SelectAll()
                    txtCliente_Remitente.Focus()
                ElseIf ObjVentaCargaContado.fnNroDocuemnto(3, 0) = True Then
                    txtNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                    'txtNroGuia.SelectAll()
                    'txtNroGuia.Focus()
                    txtCliente_Remitente.SelectAll()
                    txtCliente_Remitente.Focus()
                Else
                    MsgBox("No podra Realizar esta Operacion El Nro de Guia Envio no esta configurado")
                End If
                If iForma = 3 Then
                    lbFactBoleta.Text = "GUIA DE ENVIO PCE"
                ElseIf iForma = 4 Then
                    lbFactBoleta.Text = "GUIA ENVIO RECOJO"
                End If
                If es_carga_asegurada Then
                    lblCarga.Visible = True
                Else
                    lblCarga.Visible = False
                End If

                'hlamas 08-10-2010 carga acompañada
                If bCargaAcompañada Then
                    lblCarga.Text = "--> CARGA ACOMPAÑADA"
                    lblCarga.Visible = True
                Else
                    lblCarga.Text = "--> CARGA ASEGURADA"
                    lblCarga.Visible = False
                End If


            End If
        Catch ex As Exception

        End Try
        Return False
    End Function
    Private Sub DatosPersonalesboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente_Remitente.KeyPress, txtContactoRemitente.KeyPress, txtCliente_Destinatario.KeyPress
        Dim lb_paso As Boolean = False
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            If Not IsNumeric(e.KeyChar) And Char.IsLetter(e.KeyChar) Then ' 08/02/2008
                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
            ElseIf e.KeyChar = " " Then

                If tb.Text.Substring(tb.Text.Length() - 1) = " " Then
                    e.Handled = True
                    'Else                            ---> 08/02/2008 
                    '    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "." Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "." Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "," Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "," Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "@" Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "@" Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "&" Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "&" Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "-" Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "-" Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "'" Then
                e.Handled = True
                'ElseIf Not Char.IsControl(e.KeyChar) Then
                '    e.Handled = True
            End If
            e.Handled = False
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
 
    Private Function RellenoRight(ByVal Nro As Integer, ByVal texto As String) As String
        Dim cCount As Integer = Len(texto)
        Dim sNewCadena As String = texto
        If Nro = cCount Then
            Return texto
        End If
        Try
            Dim i As Integer
            For i = 1 To Nro - cCount
                sNewCadena = "0" & sNewCadena
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return sNewCadena
    End Function

    Public Function fnTarifario() As Boolean
        Dim flag As Boolean = False

        Try
            'Para Traer en una sola la tarifa Origen Destino
            bControl_Tarifas = False
            tarifa_Peso = 0
            tarifa_Volumen = 0
            tarifa_Articulo = 0
            Monto_Base = 0

            If ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = 0 Then
                ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                objGuiaEnvio.iIDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad 'iIDUNIDAD_AGENCIA_DESTINO
                If bOtrasAgencias Then
                    ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = 0
                    objGuiaEnvio.iIDUNIDAD_AGENCIA = 0
                End If
            Else
                ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = ObjVentaCargaContado.v_IDUNIDAD_ORIGEN
                objGuiaEnvio.iIDUNIDAD_AGENCIA = ObjVentaCargaContado.v_IDUNIDAD_ORIGEN
            End If

            Dim idUnidadAgencias As Integer = iWinDestino.IndexOf(txtiWinDestino.Text)
            If idUnidadAgencias < 0 Then
                MsgBox("No es Correcto la Ciudad Destino...", MsgBoxStyle.Information, "Seguridad Sistema")
                txtiWinDestino.Focus()
                Return False
            End If
            idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))
            If idUnidadAgencias > 0 Then
                ObjVentaCargaContado.v_IDUNIDAD_DESTINO = idUnidadAgencias
                ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = Int(ObjVentaCargaContado.coll_AgenciasVenta(cmbAgenciaVenta.SelectedIndex.ToString))
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = idUnidadAgencias
            Else
                MsgBox("No es Correcto la Ciudad Destino...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return False
            End If

            'bDescuento = IIf(Val(Me.txtPorcernt_Descuento.Text) = 0, False, True)
            'iDescuento = Val(Me.txtPorcernt_Descuento.Text) / 100

            objGuiaEnvio.sNU_DOCU_SUNAT = IIf(Me.txtDocCliente_Remitente.Text <> "", Me.txtDocCliente_Remitente.Text, "@")

            'If Not bDescuento Then      'cliente no tiene descuento
            'Mod. 27/08/2009 -->Omendoza - Pasando al datahelper   
            If Me.ChkProceso.Checked Then
                iProceso = 7
            Else
                iProceso = 0
            End If
            If objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
                bTarifarioGeneral = False
                tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Sobre
                iTarifa = objGuiaEnvio.iTarifa

                dtGridViewBultos(5, 0).Value = tarifa_Peso
                dtGridViewBultos(5, 1).Value = tarifa_Volumen
                dtGridViewBultos(5, 2).Value = tarifa_Sobre

                If bCargaAcompañada2 Then
                    If Me.lbFactBoleta.Text.Substring(0, 1) <> "G" And cmbTipo_Entrega.SelectedIndex = 0 Then
                        Monto_Base = 0
                        iControlMonto_Base = 0
                    End If
                Else
                    If iTarifa = 2 Then
                        iControlMonto_Base = 1
                    End If
                End If

                If iControlMonto_Base = 1 Then
                    dtGridViewBultos(5, 3).Value = Monto_Base
                    dtGridViewBultos(7, 3).Value = Monto_Base
                End If

                flag = True
                bControl_Tarifas = True
                'Mod. 21/08/2009 -->Omendoza - Pasando al datahelper  - No se hizo ningún cambio  
            ElseIf objGuiaEnvio.fnTARIFA_PUBLICA_CARGA1() = True Then
                bContado = objGuiaEnvio.bContado
                bTarifarioGeneral = True

                tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base

                'verifica si esta afecto a monto base para carga acompañada
                If bCargaAcompañada2 Then
                    If Me.lbFactBoleta.Text.Substring(0, 1) <> "G" And cmbTipo_Entrega.SelectedIndex = 0 Then
                        Monto_Base = 0
                    End If
                End If

                tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal

                If bTieneLineaCredito Then
                    tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso_credito
                    tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen_credito
                    Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base_credito
                    'tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Sobre_Credito  -- 30/01/2009 
                    tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal_credito
                    bContado = False
                End If

                If bDescuento Then
                    tarifa_Peso = tarifa_Peso * (1 - iDescuento)
                    tarifa_Volumen = tarifa_Volumen * (1 - iDescuento)
                    'tarifa_Sobre = tarifa_Sobre * (1 - iDescuento)
                End If

                dtGridViewBultos(5, 0).Value = tarifa_Peso
                dtGridViewBultos(5, 1).Value = tarifa_Volumen
                dtGridViewBultos(5, 2).Value = tarifa_Sobre

                If iControlMonto_Base = 1 Then
                    dtGridViewBultos(5, 3).Value = Monto_Base
                    dtGridViewBultos(7, 3).Value = Monto_Base
                End If
                flag = True
                bControl_Tarifas = True
            Else
                flag = False
                MsgBox("NO EXISTE TARIFA PARA ESTE ORIGEN Y DESTINO, NI ASOCIADO A UNA TARIFA DEL CLIENTE", MsgBoxStyle.Information, "REVICE SUS DATOS")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flag
    End Function
  
    Private Sub dtGridViewBultos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewBultos.CellEndEdit
        Try
            fnTotalPago()
            Dim row As Short = e.RowIndex
            Dim col As Short = e.ColumnIndex
            iROW_ACTUAL = e.RowIndex
            iCOL_ACTUAL = e.ColumnIndex
            iROW = e.RowIndex
            iCOL = e.ColumnIndex
            Dim valor1 As Double = Val(dtGridViewBultos(4, row).Value)
            Dim valor2 As Double = Val(dtGridViewBultos(2, row).Value)
            fnCalcularCosto(row, valor1, valor2)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub fnCalcularCostoDescuento()
        Try
            Dim valor1 As Double = Val(dtGridViewBultos(4, 0).Value)
            Dim valor2 As Double = Val(dtGridViewBultos(2, 0).Value)

            dtGridViewBultos(6, 0).Value = "0.00"
            If bCondicion = False Then
                dtGridViewBultos(7, 0).Value = Format((valor1 * tarifa_Peso), "###,###,###.00")
            End If

            valor1 = Val(dtGridViewBultos(4, 1).Value)
            valor2 = Val(dtGridViewBultos(2, 1).Value)
            dtGridViewBultos(6, 1).Value = "0.00"
            dtGridViewBultos(7, 1).Value = Format((valor1 * tarifa_Volumen), "###,###,###.00")

            valor1 = Val(dtGridViewBultos(4, 2).Value)
            valor2 = Val(dtGridViewBultos(2, 2).Value)

            dtGridViewBultos(7, 2).Value = Format((valor2 * tarifa_Sobre), "###,###,###.00")


            '----------------------------------------------------------------------------------------------------------------------------
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
            Dim SubTotal As Double = 0
            If Val(dtGridViewBultos(7, 0).Value) + Val(dtGridViewBultos(7, 1).Value) > 0 Then
                If iControlMonto_Base = 1 Then
                    SubTotal = Monto_Base + fnNumeroDecimal(dtGridViewBultos(7, 0).Value) + fnNumeroDecimal(dtGridViewBultos(7, 1).Value) + fnNumeroDecimal(dtGridViewBultos(7, 2).Value)
                Else
                    SubTotal = fnNumeroDecimal(dtGridViewBultos(7, 0).Value) + fnNumeroDecimal(dtGridViewBultos(7, 1).Value) + fnNumeroDecimal(dtGridViewBultos(7, 2).Value)
                End If

            Else
                SubTotal = fnNumeroDecimal(dtGridViewBultos(7, 0).Value) + fnNumeroDecimal(dtGridViewBultos(7, 1).Value) + fnNumeroDecimal(dtGridViewBultos(7, 2).Value)
            End If


            Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            If es_carga_asegurada Then
                If bTarifarioGeneral And bContado Then
                    SubTotal += Format(Val(dtGridViewBultos(7, 4).Value), "0.00")
                Else
                    SubTotal += Val(dtGridViewBultos(7, 4).Value)
                End If
            End If

            Dim SUB_TOTAL_GENERAL As Double = 0
            If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) > 0 Then
                SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00"))
                If bTarifarioGeneral And bContado Then
                    SUB_TOTAL_GENERAL = fnTECHO(Format(SubTotal * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00"))
                End If
            Else
                If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            txtSub_Total.Text = Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            txtMonto_IGV.Text = Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            txtCosto_Total.Text = Format(SUB_TOTAL_GENERAL, "###,###,###.00")


            'txtSub_Total.Text = SubTotal
            'txtMonto_IGV.Text = Format(SubTotal * dtoUSUARIOS.iIGV / 100, "###,###,###.00")
            'txtCosto_Total.Text = Format(SubTotal * (1 + dtoUSUARIOS.iIGV / 100), "###,###,###.00")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Try
            Dim idAgencia As Integer
            idAgencia = Int(cmbAgencia.SelectedIndex)
            If idAgencia >= 0 Then
                idAgencia = IIf(cmbAgencia.SelectedIndex.ToString() <> "", Int(objGuiaEnvio.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString())), 0)
                'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
                If objGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA(idAgencia) = True Then
                    '01/09/2009 - Mod. x Datahelper x Datatable 
                    'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, 0)
                    ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, 0)
                Else
                    NingunoComboIDs(cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            iOficinaDestino = 0
            'iOficinaOrigen = 0
            recuperando_datos_contado = False
            ObjVentaCargaContado.V_CONTROL_PCE = False
            SelectMenu(1)
            fnNUEVO()
            limpiar_documentos_cliente()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPorcernt_Descuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcernt_Descuento.KeyPress
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
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub txtPorcernt_Descuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorcernt_Descuento.TextChanged
        If recuperando_datos_contado Then Exit Sub
        Try
            If Val(txtPorcernt_Descuento.Text) > 0 Or Val(txtPorcernt_Descuento.Text) < 0 Then
                txtMemo.Visible = True
                lbMemo.Visible = True
                txtMemo.Text = ""
                txtMemo.ReadOnly = False
                txtPorcernt_Descuento.ReadOnly = False
            Else
                txtMemo.Visible = False
                lbMemo.Visible = False
                txtMemo.Text = ""
            End If
            If bMontoMinimo = False Then
                fnCalcularCostoDescuento()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Function fnBuscarFacturas() As Boolean
        '  Try
        objControlFacturasBol.origen = Int(objGuiaEnvio.coll_Lista_Origen(cmbOrigen.SelectedIndex.ToString))
        objControlFacturasBol.destino = Int(objGuiaEnvio.coll_Lista_Destino(cmbDestino.SelectedIndex.ToString))
        If objControlFacturasBol.iControl = 5 Then
            objControlFacturasBol.idUsuario = ObjBusquedaClientes.idPersona
        Else
            objControlFacturasBol.idUsuario = Int(objGuiaEnvio.coll_Lista_Usuarios(cmbUsuarios.SelectedIndex.ToString))
        End If


        Dim strNroDoc As String() = Split(txtNroSerieDoc.Text, "-")
        If strNroDoc.Length > 1 Then
            If Val(strNroDoc(0)) > 0 And Val(strNroDoc(1)) > 0 Then
                objControlFacturasBol.serie = strNroDoc(0)
                objControlFacturasBol.nrodoc = strNroDoc(1)
            Else
                objControlFacturasBol.serie = "0"
                objControlFacturasBol.nrodoc = strNroDoc(0)
            End If

        Else
            If strNroDoc.Length = 1 Then
                objControlFacturasBol.serie = "0"
                objControlFacturasBol.nrodoc = "0"
                If txtNroSerieDoc.Text <> "" Then
                    objControlFacturasBol.nrodoc = strNroDoc(0)
                End If
            Else
                objControlFacturasBol.serie = "0"
                objControlFacturasBol.nrodoc = "0"
            End If

        End If

        If objControlFacturasBol.iControl = 5 Then
            objControlFacturasBol.serie = ObjBusquedaClientes.IDTIPO
            objControlFacturasBol.nrodoc = ObjBusquedaClientes.IDDOC
        End If

        objControlFacturasBol.RucRazonSocial = IIf(txtClienteDNIRUC.Text <> "", txtClienteDNIRUC.Text, "0")
        objControlFacturasBol.estadoFactura = Int(objGuiaEnvio.coll_Lista_Estados(cmbEstados.SelectedIndex.ToString))
        objControlFacturasBol.fecha_inicio = dtFechaInicio.Text
        objControlFacturasBol.fecha_final = dtFechaFin.Text
        Me.Cursor = Cursors.AppStarting
        If objControlFacturasBol.fnControlfacturasBol() = True Then
            Me.Cursor = Cursors.Default
            dtControl_FAC.Clear()
            dtGridViewControl_FACBOL.Refresh()
            'Mod.11/09/2009 -->Omendoza - Pasando al datahelper   
            'dtControl_FAC = objControlFacturasBol.dt_rstFacturasBol
            'daControl_FAC.Fill(dtControl_FAC, objControlFacturasBol.rstFacturasBol)
            dvControl_FAC = objControlFacturasBol.dt_rstFacturasBol.DefaultView ' dtControl_FAC.DefaultView
            bformatImage = True
            dtGridViewControl_FACBOL.DataSource = dvControl_FAC
            dtGridViewControl_FACBOL.Refresh()
            dtGridViewControl_FACBOL.Update()
            lbNroRegistro.Text = dvControl_FAC.Count
            If dvControl_FAC.Count = 0 Then
                MsgBox("No Se han Encontrado Ninguna Resultado para esta busqueda..., en toda la Base de datos", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            bformatImage = True
        Else
            Me.Cursor = Cursors.Default
            MsgBox("No Se han Encontrado Ninguna Resultado para esta busqueda..., en toda la Base de datos", MsgBoxStyle.Information, "Seguridad Sistema")
        End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        Return False
    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        objControlFacturasBol.iControl = 1
        fnBuscarFacturas()
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Try
            ObjVentaCargaContado.V_CONTROL_PCE = False
            'objLOG.fnLog("ANULACION DE UN DOCUMENTO....")
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                Return
            End If
            ObjProcesosVentaContado.iControl = 1
            ObjProcesosVentaContado.idFacturaBoleta = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            If ObjVentaCargaContado.fnValidarProceso(ObjProcesosVentaContado.idFacturaBoleta) = False Then
                MsgBox("No puede realizar está operación, ya está anulada...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If

            If ObjProcesosVentaContado.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                If ObjVentaCargaContado.fnANULDEVVENAS(ObjProcesosVentaContado.iControl, ObjProcesosVentaContado.idFacturaBoleta, 0) = True Then

                    If ObjVentaCargaContado.v_CONTROL_ANUDEV = 1 Then
                        dtGridViewControl_FACBOL.Rows(row).DataGridView(IDGRIESTADO_REG, row).Value = 2
                        dtGridViewControl_FACBOL.UpdateCellValue(0, row)
                        'objLOG.fnLog("ANULACION CORRECTA....")
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDevolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDevolucion.Click
        Try
            ObjVentaCargaContado.V_CONTROL_PCE = False
            'objLOG.fnLog("INICIO DE UNA DEVOLUCION....")
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                Return
            End If
            ObjProcesosVentaContado.iControl = 2
            ObjProcesosVentaContado.idFacturaBoleta = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            If ObjVentaCargaContado.fnValidarProceso(ObjProcesosVentaContado.idFacturaBoleta) = False Then
                MsgBox("No puede realizar está operación, ya se realizo la devolución...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            If ObjProcesosVentaContado.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                Dim x_PORCENT_DEVOLUCION As Double = ObjProcesosVentaContado.x_PORCENT_DEVOLUCION
                If ObjVentaCargaContado.fnANULDEVVENAS(ObjProcesosVentaContado.iControl, ObjProcesosVentaContado.idFacturaBoleta, ObjProcesosVentaContado.x_PORCENT_DEVOLUCION) = True Then
                    dtGridViewControl_FACBOL.Rows(row).DataGridView(IDGRIESTADO_REG, row).Value = 29
                    dtGridViewControl_FACBOL.UpdateCellValue(0, row)
                    'objLOG.fnLog("DEVOLUCION REALIZADA CORRECTAMENTE....")
                End If
            End If
        Catch ex As Exception
            '
        End Try
    End Sub

    Private Sub dtGridViewControl_FACBOL_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtGridViewControl_FACBOL.CellFormatting
        Dim strvar As String = ""
        Try
            strvar = e.RowIndex.ToString()
            If bformatImage = True Then
                If e.ColumnIndex = 0 Then
                    Dim IdEstado, Facturado As Integer
                    If e.RowIndex >= 0 And dtGridViewControl_FACBOL.Rows().Count - 1 >= e.RowIndex Then
                        'Dim vIdEstado As Object
                        If IsDBNull(dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells(IDFACTURADO_REG).Value) = False Then
                            IdEstado = dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells("Idestado_Factura").Value
                            Facturado = dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells("Facturado").Value
                            If Facturado = 1 Then
                                IdEstado = 30
                            End If
                        Else
                            If IsDBNull(dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells(IDGRIESTADO_REG).Value) = False Then
                                IdEstado = dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells(IDGRIESTADO_REG).Value
                                dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells(1).Tag = 1
                            Else
                                IdEstado = 0
                            End If
                        End If


                        'IdEstado = IIf(IsNothing(DataGridViewUser.Rows(e.RowIndex).Cells(7).Value), 0, DataGridViewUser.Rows(e.RowIndex).Cells(7).Value)
                        Select Case IdEstado
                            Case 18
                                e.Value = bmpFACTURA_EMITIDA
                            Case 27
                                e.Value = bmpFACTURA_EMITIDA
                            Case 2
                                e.Value = bmpFACTURA_ANULADA
                            Case 29
                                e.Value = bmpFACTURA_DEVUELTA
                            Case 30
                                e.Value = C_FACTURADO
                            Case Else
                                e.Value = bmpNoImagen
                        End Select
                    End If
                End If
                dtGridViewControl_FACBOL.Update()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema" & strvar)
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
    'Public Function fnImprimirEtiquetasFAC_II() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim prn As New PrinterTxt.PrintTxt
    '        Dim cadena As String = ""
    '        Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
    '        'prn.Nombre_impresora = "PRNZEBRA"
    '        prn.Nombre_impresora = NOMBRE_IMPRESORA
    '        Dim EXISTE As Boolean = prn.SetearImpresora()

    '        ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
    '        ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
    '        ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
    '        ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

    '        Dim I As Int16 = 1
    '        'While objGuiaEnvio.cur_codBarras.EOF = False And objGuiaEnvio.cur_codBarras.BOF = False
    '        While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
    '            ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value

    '            prn.EscribeLinea("<STX><ESC>C0<ETX>")
    '            prn.EscribeLinea("<STX><ESC>k<ETX>")
    '            prn.EscribeLinea("<STX><SI>N60<ETX>")
    '            prn.EscribeLinea("<STX><SI>L197<ETX>")
    '            prn.EscribeLinea("<STX><SI>S20<ETX>")
    '            prn.EscribeLinea("<STX><SI>d0<ETX>")
    '            prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
    '            prn.EscribeLinea("<STX><SI>l8<ETX>")
    '            prn.EscribeLinea("<STX><SI>I3<ETX>")
    '            prn.EscribeLinea("<STX><SI>F20<ETX>")
    '            prn.EscribeLinea("<STX><SI>D0<ETX>")
    '            prn.EscribeLinea("<STX><SI>t0<ETX>")
    '            prn.EscribeLinea("<STX><SI>W394<ETX>")
    '            prn.EscribeLinea("<STX><SI>g1,567<ETX>")
    '            prn.EscribeLinea("<STX><ESC>P<ETX>")
    '            prn.EscribeLinea("<STX>E*;F*;<ETX>")
    '            prn.EscribeLinea("<STX>L1;<ETX>")
    '            prn.EscribeLinea("<STX>D0;<ETX>")
    '            prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h15;w15;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
    '            prn.EscribeLinea("<STX>D1;<ETX>")
    '            prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
    '            prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
    '            'prn.EscribeLinea("<STX>B3;o96,180;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
    '            prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
    '            prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
    '            prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
    '            prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
    '            prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
    '            prn.EscribeLinea("<STX>R<ETX>")
    '            prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
    '            prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")


    '            'prn.EscribeLinea("<STX><ESC>C0<ETX>")
    '            'prn.EscribeLinea("<STX><ESC>k<ETX>")
    '            'prn.EscribeLinea("<STX><SI>N60<ETX>")
    '            'prn.EscribeLinea("<STX><SI>L197<ETX>")
    '            'prn.EscribeLinea("<STX><SI>S20<ETX>")
    '            'prn.EscribeLinea("<STX><SI>d0<ETX>")
    '            'prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
    '            'prn.EscribeLinea("<STX><SI>l8<ETX>")
    '            'prn.EscribeLinea("<STX><SI>I3<ETX>")
    '            'prn.EscribeLinea("<STX><SI>F20<ETX>")
    '            'prn.EscribeLinea("<STX><SI>D0<ETX>")
    '            'prn.EscribeLinea("<STX><SI>t0<ETX>")
    '            'prn.EscribeLinea("<STX><SI>W394<ETX>")
    '            'prn.EscribeLinea("<STX><SI>g1,567<ETX>")
    '            'prn.EscribeLinea("<STX><ESC>P<ETX>")
    '            'prn.EscribeLinea("<STX>E*;F*;<ETX>")
    '            'prn.EscribeLinea("<STX>L1;<ETX>")
    '            'prn.EscribeLinea("<STX>D0;<ETX>")
    '            'prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h12;w20;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
    '            'prn.EscribeLinea("<STX>D1;<ETX>")
    '            'prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
    '            'prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
    '            'prn.EscribeLinea("<STX>B3;o96,180;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
    '            'prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
    '            'prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
    '            'prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
    '            'prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
    '            'prn.EscribeLinea("<STX>R<ETX>")
    '            'prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
    '            'prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")


    '            prn.EscribeLinea(cadena)
    '            ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
    '            I = I + 1
    '        End While
    '        prn.FinDoc()
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    'Public Function fnImprimirEtiquetas() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim prn As New PrinterTxt.PrintTxt
    '        Dim cadena As String = ""
    '        Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
    '        'prn.Nombre_impresora = "PRNZEBRA"
    '        prn.Nombre_impresora = NOMBRE_IMPRESORA
    '        Dim EXISTE As Boolean = prn.SetearImpresora()

    '        ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
    '        ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
    '        ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
    '        ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

    '        Dim I As Int16 = 1
    '        While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
    '            ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
    '            prn.EscribeLinea("^XA")
    '            prn.EscribeLinea("^PW400")
    '            prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
    '            'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
    '            'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
    '            prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
    '            prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
    '            prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
    '            prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
    '            prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
    '            prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")
    '            prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")
    '            prn.EscribeLinea("^PQ1,0,1,Y")
    '            prn.EscribeLinea("^XZ")
    '            prn.EscribeLinea(cadena)
    '            ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
    '            I = I + 1
    '        End While
    '        prn.FinDoc()
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function


    Private Function fnPISO(ByVal monto As String, ByVal PISOTECHO As Boolean, ByVal nroDigito As Integer) As String

        Dim strPISOTECHO As String = ""
        Try
            Dim ArrayStr() As String = Split(monto, ".")
            If ArrayStr.Length > 1 Then
                Dim var As Integer = Int(ArrayStr(0))
                If Len(var) = 1 Then

                End If
                If Len(var) = 2 Then

                End If
                If Len(var) = 3 Then

                End If

                If PISOTECHO = True Then

                Else

                End If
                strPISOTECHO = ArrayStr(1) & ArrayStr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return strPISOTECHO
    End Function
    Public Function fnEnableStadoControl(ByVal control As Boolean) As Boolean
        Dim flag As Boolean = False
        Try
            txtiWinDestino.ReadOnly = control
            txtSERIE.ReadOnly = control
            txtNroDocFACBOL.ReadOnly = control

            cmbFormaPago.Enabled = IIf(control = False, True, False)
            cmbAgenciaVenta.Enabled = IIf(control = False, True, False)
            cmbTipo_Entrega.Enabled = IIf(control = False, True, False)
            cmbTipoPago.Enabled = IIf(control = False, True, False)
            cmbTargeta.Enabled = IIf(control = False, True, False)

            '   txtFecha.ReadOnly = control
            txtNroTarjeta.ReadOnly = control
            txtDocCliente_Remitente.ReadOnly = control
            txtCliente_Remitente.ReadOnly = control
            txtDireccionRemitente.ReadOnly = control
            txtContactoRemitente.ReadOnly = control

            txtDNIContacto.ReadOnly = control

            'txtTelefonoRemitente.ReadOnly = control
            txtPorcernt_Descuento.ReadOnly = control
            txtMemo.ReadOnly = control
            txtDNIDestinatario.ReadOnly = control
            txtCliente_Destinatario.ReadOnly = control
            txtDireccionDestinatario.ReadOnly = control
            txtTelefonoDestinatario.ReadOnly = control
            dtGridViewBultos.ReadOnly = control
        Catch ex As Exception

        End Try
    End Function
    Private Function fnBuscarCliente() As Boolean
        Dim flag As Boolean = False
        Dim iAgenciaOrigen As Integer
        Try
            b_lee = False
            iAgenciaOrigen = dtoUSUARIOS.m_idciudad
            If bOtrasAgencias Then
                iAgenciaOrigen = ObjVentaCargaContado.v_IDUNIDAD_ORIGEN
            End If
            Dim iProducto As Integer
            'Mod.16/09/2009 -->Omendoza - Pasando al datahelper 
            iProducto = 0
            Me.ChkProceso.Checked = False
            If ObjVentaCargaContado.fnBuscarCliente(1, Me.txtDocCliente_Remitente.Text, "@", iAgenciaOrigen, ObjVentaCargaContado.v_IDUNIDAD_DESTINO) = True Then
                '16-11-2008
                'Verifica si cliente tiene linea de credito
                'Iid = ObjVentaCargaContado.cur_persona.Fields.Item(0).Value

                iProducto = IIf(IsDBNull(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(7)), 0, ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(7))
                Iid = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
                'Mod.16/09/2009 -->Omendoza - Pasando al datahelper   
                'Dim rstLinea As ADODB.Recordset
                Dim ldt_tmp As New DataTable
                ldt_tmp = sp_linea_credito()
                'If Not rstLinea.BOF And Not rstLinea.EOF Then
                If ldt_tmp.Rows.Count > 0 Then
                    'If CType(rstLinea("ES_ACTIVO").Value, Boolean) Then
                    If CType(ldt_tmp.Rows(0).Item("ES_ACTIVO"), Boolean) Then
                        bTieneLineaCredito = True
                    Else
                        bTieneLineaCredito = False
                    End If
                Else
                    bTieneLineaCredito = False
                End If
                '
                flag = True
                ObjVentaCargaContado.v_IDPERSONA = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
                If ObjVentaCargaContado.v_IDPERSONA = 0 Then ' No encontro el cliente 
                    Return False
                End If

                txtCliente_Remitente.Text = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(1)
                '
                s_persona_remitente = txtCliente_Remitente.Text

                Me.txtDocCliente_Remitente.Tag = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(5)
                'If Me.txtDocCliente_Remitente.Text.Trim.Substring(0, 1) = "P" And Me.ChkProceso.Visible Then
                If iProducto = 7 And Me.ChkProceso.Visible Then
                    Me.txtDocCliente_Remitente.Text = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(6)
                    Me.ChkProceso.Checked = True
                End If
                '
                txtTelefonoRemitente.Text = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(2)
                iControlMonto_Base = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(3)
                '
                '15-11-2008
                'txtPorcernt_Descuento.Text = IIf(ObjVentaCargaContado.cur_persona.Fields.Item(4).Value <> 0, ObjVentaCargaContado.cur_persona.Fields.Item(4).Value, "")
                iDescuento = IIf(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(4) <> 0, ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(4), 0)
                '
                If iDescuento <> 0 Then
                    iDescuento = iDescuento / 100
                    bDescuento = True
                Else
                    bDescuento = False
                End If

                '
                ' CONTACTO REMITENTE
                '
                'If ObjVentaCargaContado.cur_cont_origen.BOF = False And ObjVentaCargaContado.cur_cont_origen.EOF = False Then
                '    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = Int(ObjVentaCargaContado.cur_cont_origen.Fields.Item(0).Value.ToString)
                '    txtContactoRemitente.Text = ObjVentaCargaContado.cur_cont_origen.Fields.Item(1).Value.ToString
                '    txtDNIContacto.Text = ObjVentaCargaContado.cur_cont_origen.Fields.Item(2).Value.ToString
                '    fnCargar_iWin2(txtContactoRemitente, ObjVentaCargaContado.cur_cont_origen, coll_Nombres_Remitente, iWinContacto_Remitente, ObjVentaCargaContado.v_IDPERSONA_ORIGEN, iWinPerosaDNI_Remite)
                'Else
                '    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = 0
                '    txtContactoRemitente.Text = ""
                '    txtDNIContacto.Text = ""
                'End If
                If ObjVentaCargaContado.dt_cur_cont_origen.Rows.Count > 0 Then
                    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = Int(ObjVentaCargaContado.dt_cur_cont_origen.Rows(0).Item(0).ToString)
                    txtContactoRemitente.Text = ObjVentaCargaContado.dt_cur_cont_origen.Rows(0).Item(1).ToString
                    txtDNIContacto.Text = ObjVentaCargaContado.dt_cur_cont_origen.Rows(0).Item(2).ToString
                    '                    fnCargar_iWin2(txtContactoRemitente, ObjVentaCargaContado.dt_cur_cont_origen, coll_Nombres_Remitente, iWinContacto_Remitente, ObjVentaCargaContado.v_IDPERSONA_ORIGEN, iWinPerosaDNI_Remite)
                Else
                    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = 0
                    txtContactoRemitente.Text = ""
                    txtDNIContacto.Text = ""
                End If
                fnCargar_iWin2(txtContactoRemitente, ObjVentaCargaContado.dt_cur_cont_origen, coll_Nombres_Remitente, iWinContacto_Remitente, ObjVentaCargaContado.v_IDPERSONA_ORIGEN, iWinPerosaDNI_Remite)
                '//CONTACTO DIRECCIONES REMITENTE
                'If ObjVentaCargaContado.cur_dire_origen.BOF = False And ObjVentaCargaContado.cur_dire_origen.EOF = False Then
                '    ObjVentaCargaContado.v_IDDIREECION_ORIGEN = Int(ObjVentaCargaContado.cur_dire_origen.Fields.Item(0).Value.ToString)
                '    txtDireccionRemitente.Text = ObjVentaCargaContado.cur_dire_origen.Fields.Item(1).Value.ToString
                '    fnCargar_iWin(txtDireccionRemitente, ObjVentaCargaContado.cur_dire_origen, coll_Direccion_Remitente, iWinDireccion_Remitente, ObjVentaCargaContado.v_IDDIREECION_ORIGEN)
                'Else
                '    txtDireccionRemitente.Text = ""
                '    ObjVentaCargaContado.v_IDDIREECION_ORIGEN = 0
                'End If
                '
                If ObjVentaCargaContado.dt_cur_dire_origen.Rows.Count > 0 Then
                    ObjVentaCargaContado.v_IDDIREECION_ORIGEN = Int(ObjVentaCargaContado.dt_cur_dire_origen.Rows(0).Item(0).ToString)
                    txtDireccionRemitente.Text = ObjVentaCargaContado.dt_cur_dire_origen.Rows(0).Item(1).ToString
                    'fnCargar_iWin_dt(txtDireccionRemitente, ObjVentaCargaContado.dt_cur_dire_origen, coll_Direccion_Remitente, iWinDireccion_Remitente, ObjVentaCargaContado.v_IDDIREECION_ORIGEN)
                Else
                    txtDireccionRemitente.Text = ""
                    ObjVentaCargaContado.v_IDDIREECION_ORIGEN = 0
                End If
                fnCargar_iWin_dt(txtDireccionRemitente, ObjVentaCargaContado.dt_cur_dire_origen, coll_Direccion_Remitente, iWinDireccion_Remitente, ObjVentaCargaContado.v_IDDIREECION_ORIGEN)
                ''''''''''''
                Dim varIdFormaPago As Integer = Int(ObjVentaCargaContado.coll_t_Forma_Pago.Item(cmbFormaPago.SelectedIndex.ToString()))
                iForma = varIdFormaPago
                If varIdFormaPago = 4 Then varIdFormaPago = 3
                If varIdFormaPago = 3 Then
                    txtContactoRemitente.Text = ""
                    txtDNIContacto.Text = ""
                End If

                '//CONTACTO DESTINATARIO
                'If ObjVentaCargaContado.cur_cont_destino.BOF = False And ObjVentaCargaContado.cur_cont_destino.EOF = False Then
                '    ObjVentaCargaContado.v_IDCONTACTO_DESTINO = Int(ObjVentaCargaContado.cur_cont_destino.Fields.Item(0).Value.ToString)
                '    txtCliente_Destinatario.Text = ObjVentaCargaContado.cur_cont_destino.Fields.Item(1).Value.ToString
                '    txtDNIDestinatario.Text = ObjVentaCargaContado.cur_cont_destino.Fields.Item(2).Value.ToString
                '    fnCargar_iWin2(txtCliente_Destinatario, ObjVentaCargaContado.cur_cont_destino, coll_Nombres_Destinatario, iWinContacto_Destinatario, ObjVentaCargaContado.v_IDCONTACTO_DESTINO, iWinPerosaDNI_Destino)
                'Else
                '    ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0
                '    txtCliente_Destinatario.Text = ""
                '    txtDNIDestinatario.Text = ""
                'End If
                '
                If ObjVentaCargaContado.dt_cur_cont_destino.Rows.Count > 0 Then
                    ObjVentaCargaContado.v_IDCONTACTO_DESTINO = Int(ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item(0).ToString)
                    txtCliente_Destinatario.Text = ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item(1).ToString
                    txtDNIDestinatario.Text = ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item(2).ToString
                    'fnCargar_iWin2(txtCliente_Destinatario, ObjVentaCargaContado.dt_cur_cont_destino, coll_Nombres_Destinatario, iWinContacto_Destinatario, ObjVentaCargaContado.v_IDCONTACTO_DESTINO, iWinPerosaDNI_Destino)
                Else
                    If Not bBoleto Then
                        ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0
                        txtCliente_Destinatario.Text = ""
                        txtDNIDestinatario.Text = ""
                    End If
                End If
                If ObjVentaCargaContado.dt_cur_cont_destino.Rows.Count > 0 And Not bBoleto Then
                    fnCargar_iWin2(txtCliente_Destinatario, ObjVentaCargaContado.dt_cur_cont_destino, coll_Nombres_Destinatario, iWinContacto_Destinatario, ObjVentaCargaContado.v_IDCONTACTO_DESTINO, iWinPerosaDNI_Destino)
                End If
                '
                '//CONTACTO DIRECCIONES DESTINATARIO
                'If ObjVentaCargaContado.cur_dire_destino.BOF = False And ObjVentaCargaContado.cur_dire_destino.EOF = False Then
                '    ObjVentaCargaContado.v_IDDIREECION_DESTINO = Int(ObjVentaCargaContado.cur_dire_destino.Fields.Item(0).Value.ToString)
                '    txtDireccionDestinatario.Text = ObjVentaCargaContado.cur_dire_destino.Fields.Item(1).Value.ToString
                '    fnCargar_iWin(txtDireccionDestinatario, ObjVentaCargaContado.cur_dire_destino, coll_Direccion_Destinatario, iWinDireccion_Destinatario, ObjVentaCargaContado.v_IDDIREECION_DESTINO)
                'Else
                '    txtDireccionDestinatario.Text = ""
                '    ObjVentaCargaContado.v_IDDIREECION_DESTINO = 0
                'End If
                '
                If ObjVentaCargaContado.dt_cur_dire_destino.Rows.Count > 0 Then
                    ObjVentaCargaContado.v_IDDIREECION_DESTINO = Int(ObjVentaCargaContado.dt_cur_dire_destino.Rows(0).Item(0).ToString)
                    txtDireccionDestinatario.Text = ObjVentaCargaContado.dt_cur_dire_destino.Rows(0).Item(1).ToString
                    'fnCargar_iWin_dt(txtDireccionDestinatario, ObjVentaCargaContado.dt_cur_dire_destino, coll_Direccion_Destinatario, iWinDireccion_Destinatario, ObjVentaCargaContado.v_IDDIREECION_DESTINO)
                Else
                    txtDireccionDestinatario.Text = ""
                    ObjVentaCargaContado.v_IDDIREECION_DESTINO = 0
                End If
                fnCargar_iWin_dt(txtDireccionDestinatario, ObjVentaCargaContado.dt_cur_dire_destino, coll_Direccion_Destinatario, iWinDireccion_Destinatario, ObjVentaCargaContado.v_IDDIREECION_DESTINO)
                '
                Dim tmpTipoEntrega As Integer = ObjVentaCargaContado.coll_t_Tipo_Entrega(Me.cmbTipo_Entrega.SelectedIndex.ToString)
                If tmpTipoEntrega = 1 Then
                    txtDireccionDestinatario.Text = "AGENCIA"
                Else
                    If txtDireccionDestinatario.Text = "AGENCIA" Then
                        txtDireccionDestinatario.Text = ""
                    End If
                End If
            Else
                ObjVentaCargaContado.v_IDPERSONA = 0
                txtCliente_Remitente.Text = ""
                txtTelefonoRemitente.Text = ""
                Me.txtDocCliente_Remitente.Tag = ""

                ObjVentaCargaContado.v_IDPERSONA_ORIGEN = 0
                txtContactoRemitente.Text = ""
                txtDNIContacto.Text = ""

                ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0
                txtCliente_Destinatario.Text = ""
                txtDNIDestinatario.Text = ""

                txtDireccionRemitente.Text = ""
                ObjVentaCargaContado.v_IDDIREECION_ORIGEN = 0
                txtDireccionDestinatario.Text = ""
                ObjVentaCargaContado.v_IDDIREECION_DESTINO = 0
                '04/10/2007 
                s_persona_remitente = ""
            End If
            Dim i As Integer = 0
            For i = 0 To 3
                dtGridViewBultos(2, i).Value() = ""
                dtGridViewBultos(4, i).Value() = "0.00"
                dtGridViewBultos(5, i).Value() = "0.00"
                dtGridViewBultos(6, i).Value() = "0.00"
                dtGridViewBultos(7, i).Value() = "0.00"
            Next
            fnTarifario()
            dtGridViewBultos(5, 0).Value() = tarifa_Peso
            dtGridViewBultos(5, 1).Value() = tarifa_Volumen
            dtGridViewBultos(5, 2).Value() = tarifa_Sobre

            If iControlMonto_Base = 1 Then
                dtGridViewBultos(7, 3).Value() = Monto_Base
            Else
                dtGridViewBultos(5, 3).Value() = "0.00"
                dtGridViewBultos(7, 3).Value() = "0.00"
            End If

            dtGridViewBultos(3, 0).Value() = "BULTOS"
            dtGridViewBultos(3, 1).Value() = "BULTOS"


            For i = 1 To dtGridViewArticulo.Rows().Count
                dtGridViewArticulo.Rows().RemoveAt(0)
            Next

            Try
                '    If ObjVentaCargaContado.cur_Articulos.State = 1 Then
                '        While ObjVentaCargaContado.cur_Articulos.BOF = False And ObjVentaCargaContado.cur_Articulos.EOF = False
                '            Dim row0 As String() = {Int(ObjVentaCargaContado.cur_Articulos.Fields.Item(0).Value).ToString, ObjVentaCargaContado.cur_Articulos.Fields.Item(1).Value, ObjVentaCargaContado.cur_Articulos.Fields.Item(2).Value.ToString, "", "", "0.00"}
                '            dtGridViewArticulo.Rows().Add(row0)
                '            ObjVentaCargaContado.cur_Articulos.MoveNext()
                '        End While
                'End If
                If ObjVentaCargaContado.dt_cur_Articulos.Rows.Count > 0 Then
                    For Each fila As DataRow In ObjVentaCargaContado.dt_cur_Articulos.Rows
                        Dim row0 As String() = {Int(fila.Item(0)).ToString, fila.Item(1), fila.Item(2).ToString, "", "", "0.00"}
                        dtGridViewArticulo.Rows().Add(row0)
                    Next
                End If
            Catch ex As Exception

            End Try
            'Modificado 04/10/2007 
            'If ObjVentaCargaContado.v_IDPERSONA > 0 Then ' Encontro a la persona 
            '    txtCliente_Destinatario.Focus()
            'End If
            '
            b_lee = True
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            flag = False
        End Try
        Return flag
    End Function
    Public Function fnMantenimienteCliente(ByVal OgirenDestino As Integer, ByVal iNRODOC As TextBox, ByVal iNOMBRES As TextBox, ByVal iDireccion As TextBox, ByVal iCONTROLINSUP As Integer, ByVal iCONTROTABLAS As Integer) As Boolean
        Try
            ObjManteClienteContado.iCONTROLINSUP = iCONTROLINSUP
            ObjManteClienteContado.iCONTROTABLAS = iCONTROTABLAS
            ObjManteClienteContado.v_Rason_Social = iNOMBRES.Text
            ObjManteClienteContado.v_NroDoc = iNRODOC.Text
            ObjManteClienteContado.v_Direccion = iDireccion.Text
            '
            Dim indexof As Integer = -1
            ObjManteClienteContado.v_idContacto = 0
            ObjManteClienteContado.v_idDireccion = 0
            If OgirenDestino = 1 Then
                If ObjVentaCargaContado.v_IDPERSONA <= 0 Then
                    MsgBox("No puede realizar esta Operacion de Modificacion No existe el Cliente...", MsgBoxStyle.Information, "Seguridad Sistema")
                    Return False
                End If
                ObjManteClienteContado.v_idContacto = ObjVentaCargaContado.v_IDPERSONA
                ObjManteClienteContado.v_idpersona = ObjVentaCargaContado.v_IDPERSONA
                If iWinDireccion_Remitente.Count > 0 Then
                    indexof = iWinDireccion_Remitente.IndexOf(iDireccion.Text)
                    ObjManteClienteContado.v_idDireccion = -1
                    If indexof >= 0 Then
                        ObjManteClienteContado.v_idDireccion = Int(coll_Direccion_Remitente.Item(indexof.ToString))
                    End If
                End If
            End If
            If OgirenDestino = 2 Then
                If iWinContacto_Remitente.Count > 0 And coll_Nombres_Remitente.Count > 0 Then
                    indexof = IIf(iWinContacto_Remitente.IndexOf(iNOMBRES.Text) >= 0, iWinContacto_Remitente.IndexOf(iNOMBRES.Text), -1)
                    ObjManteClienteContado.v_idContacto = -1
                    If indexof >= 0 Then
                        ObjManteClienteContado.v_idContacto = Int(coll_Nombres_Remitente.Item(indexof.ToString))
                    End If
                End If
                If iWinDireccion_Remitente.Count > 0 Then
                    indexof = iWinDireccion_Remitente.IndexOf(iDireccion.Text)
                    ObjManteClienteContado.v_idDireccion = -1
                    If indexof >= 0 Then
                        ObjManteClienteContado.v_idDireccion = Int(coll_Direccion_Remitente.Item(indexof.ToString))
                    End If
                End If
            End If
            If OgirenDestino = 3 Then
                If iWinContacto_Destinatario.Count > 0 And coll_Nombres_Destinatario.Count > 0 Then
                    indexof = IIf(iWinContacto_Destinatario.IndexOf(iNOMBRES.Text) >= 0, iWinContacto_Destinatario.IndexOf(iNOMBRES.Text), -1)
                    ObjManteClienteContado.v_idContacto = 0
                    If indexof >= 0 Then
                        ObjManteClienteContado.v_idContacto = Int(coll_Nombres_Destinatario.Item(indexof.ToString))
                    End If
                End If
                If iWinDireccion_Destinatario.Count > 0 Then
                    indexof = iWinDireccion_Destinatario.IndexOf(iDireccion.Text)
                    ObjManteClienteContado.v_idDireccion = 0
                    If indexof >= 0 Then
                        ObjManteClienteContado.v_idDireccion = Int(coll_Direccion_Destinatario.Item(indexof.ToString))
                    End If
                End If
            End If
            If ObjManteClienteContado.v_idContacto <= 0 Then
                MsgBox("No puede realizar esta Operacion de Modificacion No existe el Cliente/Contacto...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return False
            End If
            DlgfrmManteClienteContado.iPersonaContacto = OgirenDestino
            Acceso.Asignar(DlgfrmManteClienteContado, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                If DlgfrmManteClienteContado.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    iNRODOC.Text = ObjManteClienteContado.v_NroDoc
                    iNOMBRES.Text = ObjManteClienteContado.v_Rason_Social
                    ' 
                    '04/10/2007 
                    s_persona_remitente = iNOMBRES.Text
                    '
                    iDireccion.Text = ObjManteClienteContado.v_Direccion
                    txtPorcernt_Descuento.Text = ObjManteClienteContado.v_porcentage_descuento
                    iControlMonto_Base = ObjManteClienteContado.v_base
                End If

            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


            'If DlgfrmManteClienteContado.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    iNRODOC.Text = ObjManteClienteContado.v_NroDoc
            '    iNOMBRES.Text = ObjManteClienteContado.v_Rason_Social
            '    ' 
            '    '04/10/2007 
            '    s_persona_remitente = iNOMBRES.Text
            '    '
            '    iDireccion.Text = ObjManteClienteContado.v_Direccion
            '    txtPorcernt_Descuento.Text = ObjManteClienteContado.v_porcentage_descuento
            '    iControlMonto_Base = ObjManteClienteContado.v_base
            'End If
        Catch ex As Exception
        End Try
        Return False
    End Function
    Private Function fnImprimirFACTURA() As Boolean
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        iSubTotal = 0
        iImpuesto = 0
        iTotal = 0
        Try
            Dim montoLetras As String = ConvercionNroEnLetras(ObjIMPRESIONFACT_BOL.xTotal_Costo)
            Dim fecha_Systema As String() = Split(dtoUSUARIOS.m_sFecha, "/")
            Dim dia As String = fecha_Systema(0)
            Dim Mes As String = fecha_Systema(1)
            Dim Anio As String = fecha_Systema(2)

            Dim glosa3 As String = ""

            Dim GLOSA2 As String = ""
            Dim PESO As String = ""
            Dim PARCIAL As String = ""
            Dim CANTIDAD As String = ""

            Try
                ObjReport.Dispose()
            Catch
            End Try
            ObjReport = New ClsLbTepsa.dtoFrmReport


            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                CANTIDAD = ObjIMPRESIONFACT_BOL.xCantidad_Peso & Chr(13)
                GLOSA2 = "BULTOS" & Chr(13)
                PESO = ObjIMPRESIONFACT_BOL.xTotalPeso & Chr(13)
                PARCIAL = Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "####,###,###.00") & Chr(13)
            End If

            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Vol & "" & Chr(13)
                GLOSA2 = GLOSA2 & "BULTOS (V.)" & Chr(13)
                PESO = PESO & ObjIMPRESIONFACT_BOL.xTotalVolumen & Chr(13)
                PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "####,###,###.00") & Chr(13)
            End If

            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Sobre & ""
                GLOSA2 = GLOSA2 & "SOBRES"
                PESO = PESO & ""
                PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "####,###,###.00")
            End If


            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(dtGridViewBultos(7, 2).Value)

            ObjReport.rutaRpt = PathFrmReport


            If CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString) >= 400 Then

                glosa3 = "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON " & Chr(13) & _
                "EL GOBIERNO CENTRAL ,  SEGÚN D.L. Nº  940 - R.S. Nº 158 -2006-SUNAT  / D.S. " & Chr(13) & _
                "Nº 033-2006-MTC." & Chr(13) & _
                "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829."
            Else
                glosa3 = ""

            End If

            'ObjIMPRESIONFACT_BOL.xDireccionRemitente, _

            Select Case tipo_factu_impre
                Case "A"
                    ObjReport.printrptlpt(True, "", "FAC006.RPT", _
                    "P_MONTO_LETRAS;" & montoLetras, _
                    "P_MENSAJE;" & "...", _
                    "P_GLOSA02;" & GLOSA2, _
                    "P_GLOSA03;" & glosa3, _
                    "P_NRO_FACTURA;" & ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL, _
                    "P_CODIGO_CLIENTE;" & ObjIMPRESIONFACT_BOL.xRuc, _
                    "P_RAZON_SOCIAL;" & ObjIMPRESIONFACT_BOL.xRazonSocial, _
                    "P_DIRECCION_PERSONA;" & ObjIMPRESIONFACT_BOL.xDireccionRemitente, _
                    "P_REMITENTE;" & ObjIMPRESIONFACT_BOL.xRemitente, _
                    "P_DESTINATARIO;" & ObjIMPRESIONFACT_BOL.xConsignado, _
                    "P_DIRECCION_REMI;" & " ", _
                    "P_DIRECCION_DESTI;" & ObjIMPRESIONFACT_BOL.xDireccionConsignado, _
                    "P_LOGIN;" & dtoUSUARIOS.iLOGIN, _
                    "P_REFE;" & ObjIMPRESIONFACT_BOL.xNroRef, _
                    "P_MEMO;" & ObjIMPRESIONFACT_BOL.xMemo, _
                    "P_FORMA_PAGO;" & ObjIMPRESIONFACT_BOL.xFormaPago, _
                    "P_SUB_TOTAL;" & ObjIMPRESIONFACT_BOL.xMonto_Sub_Total, _
                    "P_MONTO_IMPUESTO;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###.00"), _
                    "P_TOTAL_COSTO;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###.00"), _
                    "P_DIA_FACTURA;" & dia, _
                    "P_MES_FACTURA;" & Mes, _
                    "P_ANIO_FACTURA;" & Anio, _
                    "P_GLOSA;" & " ", _
                    "P_ORIGEN;" & ObjIMPRESIONFACT_BOL.xOrigen, _
                    "P_DESTINO;" & ObjIMPRESIONFACT_BOL.xDestino & IIf(es_carga_asegurada = True, v_ca, ""), _
                    "P_PESO;" & PESO, _
                    "P_PARCIAL;" & PARCIAL, _
                    "P_CANTIDAD;" & CANTIDAD, _
                   "P_HORA;" & fnGetHora(), _
                    "P_DESCUENTO;" & ObjIMPRESIONFACT_BOL.xDescuento, _
                    "P_AGENCIA;" & ObjIMPRESIONFACT_BOL.xAgenciaDestino _
                    )
                Case "N"
                    Dim sImpresora As String = imprimir.ObtieneImpresora(1, dtoUSUARIOS.IP)

                    If sImpresora.Trim.Length > 0 Then
                        Dim obj As New Imprimir
                        obj.Inicializar()
                        obj.Impresora = sImpresora

                        If es_carga_asegurada Then
                            'objImprimir.Agregar(290, 108, ObjIMPRESIONFACT_BOL.xAgenciaDestino & v_ca)
                            obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xAgenciaDestino & v_ca)
                        Else
                            'objImprimir.Agregar(290, 108, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                            obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                        End If

                        'objImprimir.Agregar(290, 108, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                        'objImprimir.Agregar(290, 75, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                        'objImprimir.Agregar(290, 121, fnGetHora())
                        obj.EscribirLinea(fnGetHora())

                        'objImprimir.Agregar(60, 153, dia)
                        obj.EscribirLinea(dia)
                        'objImprimir.Agregar(140, 153, Mes)
                        obj.EscribirLinea(Mes)
                        'objImprimir.Agregar(240, 153, Anio)
                        obj.EscribirLinea(Anio)

                        'objImprimir.Agregar(85, 167, ObjIMPRESIONFACT_BOL.xRazonSocial)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xRazonSocial)
                        'objImprimir.Agregar(85, 184, ObjIMPRESIONFACT_BOL.xDireccionRemitente)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xDireccionRemitente)
                        'objImprimir.Agregar(85, 201, ObjIMPRESIONFACT_BOL.xOrigen)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xOrigen)
                        'objImprimir.Agregar(85, 218, ObjIMPRESIONFACT_BOL.xConsignado)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xConsignado)
                        'objImprimir.Agregar(85, 235, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xDireccionConsignado)

                        'objImprimir.Agregar(390, 167, ObjIMPRESIONFACT_BOL.xRuc)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xRuc)
                        'objImprimir.Agregar(390, 201, ObjIMPRESIONFACT_BOL.xDestino)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xDestino)

                        'objImprimir.Agregar(622, 167, ObjIMPRESIONFACT_BOL.xNroRef)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xNroRef)
                        'objImprimir.Agregar(622, 201, ObjIMPRESIONFACT_BOL.xFormaPago)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xFormaPago)
                        'objImprimir.Agregar(622, 218, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)

                        If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                            'objImprimir.Agregar(80, 300, ObjIMPRESIONFACT_BOL.xCantidad_Peso)
                            obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xCantidad_Peso)
                            'objImprimir.Agregar(175, 300, "BULTOS")
                            obj.EscribirLinea("BULTOS")
                            'objImprimir.Agregar(550, 300, ObjIMPRESIONFACT_BOL.xTotalPeso)
                            obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xTotalPeso)
                        End If
                        If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                            'objImprimir.Agregar(80, 317, ObjIMPRESIONFACT_BOL.xCantidad_Vol)
                            obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xCantidad_Vol)
                            'objImprimir.Agregar(175, 317, "BULTOS (V.)")
                            obj.EscribirLinea("BULTOS (V.)")
                            'objImprimir.Agregar(550, 317, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                            obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xTotalVolumen)
                        End If
                        If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                            'objImprimir.Agregar(80, 334, ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                            obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                            'objImprimir.Agregar(175, 334, "SOBRES")
                            obj.EscribirLinea("SOBRES")
                        End If

                        If es_carga_asegurada Then
                            ObtieneMontosAsegurados(iSubTotal, iImpuesto, iTotal)
                            If ObjVentaCargaContado.v_MONTO_DESCUENTO > 0 Then
                                iSubTotal = iSubTotal * (1 - (ObjVentaCargaContado.v_MONTO_DESCUENTO / 100))
                            End If
                            iSubTotal = FormatNumber(iSubTotal, 2)
                            'objImprimir.Agregar(635, 345, iSubTotal.ToString.PadLeft(20, " "))
                            obj.EscribirLinea(iSubTotal.ToString.PadLeft(20, " "))
                            'objImprimir.Agregar(175, 345, "SEGURO CARGA")
                            obj.EscribirLinea("SEGURO CARGA")
                            Dim isub As String
                            isub = Format(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total - iSubTotal, "0.00")
                            'objImprimir.Agregar(635, 300, isub.ToString.PadLeft(20, " "))
                            obj.EscribirLinea(isub.ToString.PadLeft(20, " "))
                        Else
                            'objImprimir.Agregar(635, 300, ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(20, " "))
                            obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(20, " "))
                        End If

                        If CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString) >= 400 Then
                            glosa3 = "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON " & Chr(13) & _
                            "EL GOBIERNO CENTRAL ,  SEGÚN D.L. Nº  940 - R.S. Nº 158 -2006-SUNAT  / D.S. " & Chr(13) & _
                            "Nº 033-2006-MTC." & Chr(13) & _
                            "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829."

                            'objImprimir.Agregar(145, 349, "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON")
                            'objImprimir.Agregar(145, 364, "EL GOBIERNO CENTRAL,SEGÚN D.L. Nº 940 - R.S. Nº 158 -2006-SUNAT/D.S.")
                            'objImprimir.Agregar(145, 379, "Nº 033-2006-MTC.")
                            'objImprimir.Agregar(145, 394, "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829.")
                            obj.EscribirLinea("OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON")
                            obj.EscribirLinea("EL GOBIERNO CENTRAL,SEGÚN D.L. Nº 940 - R.S. Nº 158 -2006-SUNAT/D.S.")
                            obj.EscribirLinea("Nº 033-2006-MTC.")
                            obj.EscribirLinea("Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829.")
                        End If

                        'objImprimir.Agregar(135, 401, "Son:  " & montoLetras)
                        obj.EscribirLinea("Son:  " & montoLetras)
                        'objImprimir.Agregar(270, 487, dtoUSUARIOS.iLOGIN)
                        obj.EscribirLinea(dtoUSUARIOS.iLOGIN)

                        'objImprimir.Agregar(460, 455, "19.00")
                        obj.EscribirLinea(FormatNumber(dtoUSUARIOS.iIGV, 2))

                        'objImprimir.Agregar(580, 427, "S/.")
                        obj.EscribirLinea("S/.")
                        'objImprimir.Agregar(580, 443, "S/.")
                        obj.EscribirLinea("S/.")
                        'objImprimir.Agregar(580, 461, "S/.")
                        obj.EscribirLinea("S/.")

                        'objImprimir.Agregar(635, 427, ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(20, " "))
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(20, " "))
                        'objImprimir.Agregar(635, 443, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###0.00").PadLeft(20, " "))
                        obj.EscribirLinea(Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###0.00").PadLeft(20, " "))
                        'objImprimir.Agregar(635, 461, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###0.00").PadLeft(20, " "))
                        obj.EscribirLinea(Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###0.00").PadLeft(20, " "))

                        'obj.Imprimir()
                        'obj.Finalizar()
                        obj.Comprimido = True
                        obj.Preliminar = True
                        obj.Tamaño = 36
                        obj.Imprimir()
                        obj.Finalizar()

                        Dim frm As New FrmPreview
                        frm.Tamaño = 36
                        frm.Documento = 1
                        frm.Text = "Factura"
                        frm.ShowDialog()


                    Else
                        'Envío de impresión texto Factura (Nuevo)
                        'Dim objImprimir As New ImprimirTexto("Arial", 8, "PDFCreator", "dos", 1305, 1305)
                        Dim objImpresora As New dtoVentaCargaContado
                        Dim flag = objImpresora.fnSP_Buscar_Impresora(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE, dtoUSUARIOS.IP)

                        If flag Then
                            Dim objImprimir As New ImprimirTexto("Draft Condensed", 8, objImpresora.v_Impresora, "factura", 1305, 1305)

                            If es_carga_asegurada Then
                                objImprimir.Agregar(290, 108, ObjIMPRESIONFACT_BOL.xAgenciaDestino & v_ca)
                            Else
                                objImprimir.Agregar(290, 108, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                            End If

                            objImprimir.Agregar(290, 108, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                            objImprimir.Agregar(290, 75, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                            objImprimir.Agregar(290, 121, fnGetHora())

                            objImprimir.Agregar(60, 153, dia)
                            objImprimir.Agregar(140, 153, Mes)
                            objImprimir.Agregar(240, 153, Anio)

                            objImprimir.Agregar(85, 167, ObjIMPRESIONFACT_BOL.xRazonSocial)
                            objImprimir.Agregar(85, 184, ObjIMPRESIONFACT_BOL.xDireccionRemitente)
                            objImprimir.Agregar(85, 201, ObjIMPRESIONFACT_BOL.xOrigen)
                            objImprimir.Agregar(85, 218, ObjIMPRESIONFACT_BOL.xConsignado)
                            objImprimir.Agregar(85, 235, ObjIMPRESIONFACT_BOL.xDireccionConsignado)

                            objImprimir.Agregar(390, 167, ObjIMPRESIONFACT_BOL.xRuc)
                            objImprimir.Agregar(390, 201, ObjIMPRESIONFACT_BOL.xDestino)

                            objImprimir.Agregar(622, 167, ObjIMPRESIONFACT_BOL.xNroRef)
                            objImprimir.Agregar(622, 201, ObjIMPRESIONFACT_BOL.xFormaPago)
                            objImprimir.Agregar(622, 218, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)

                            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                                objImprimir.Agregar(80, 300, ObjIMPRESIONFACT_BOL.xCantidad_Peso)
                                objImprimir.Agregar(175, 300, "BULTOS")
                                objImprimir.Agregar(550, 300, ObjIMPRESIONFACT_BOL.xTotalPeso)
                            End If
                            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                                objImprimir.Agregar(80, 317, ObjIMPRESIONFACT_BOL.xCantidad_Vol)
                                objImprimir.Agregar(175, 317, "BULTOS (V.)")
                                objImprimir.Agregar(550, 317, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                            End If
                            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                                objImprimir.Agregar(80, 334, ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                                objImprimir.Agregar(175, 334, "SOBRES")
                            End If

                            If es_carga_asegurada Then
                                ObtieneMontosAsegurados(iSubTotal, iImpuesto, iTotal)
                                If ObjVentaCargaContado.v_MONTO_DESCUENTO > 0 Then
                                    iSubTotal = iSubTotal * (1 - (ObjVentaCargaContado.v_MONTO_DESCUENTO / 100))
                                End If
                                iSubTotal = FormatNumber(iSubTotal, 2)
                                objImprimir.Agregar(635, 345, iSubTotal.ToString.PadLeft(20, " "))
                                objImprimir.Agregar(175, 345, "SEGURO CARGA")
                                Dim isub As String
                                isub = Format(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total - iSubTotal, "0.00")
                                objImprimir.Agregar(635, 300, isub.ToString.PadLeft(20, " "))
                            Else
                                objImprimir.Agregar(635, 300, ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(20, " "))
                            End If

                            If CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString) >= 400 Then
                                glosa3 = "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON " & Chr(13) & _
                                "EL GOBIERNO CENTRAL ,  SEGÚN D.L. Nº  940 - R.S. Nº 158 -2006-SUNAT  / D.S. " & Chr(13) & _
                                "Nº 033-2006-MTC." & Chr(13) & _
                                "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829."

                                objImprimir.Agregar(145, 349, "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON")
                                objImprimir.Agregar(145, 364, "EL GOBIERNO CENTRAL,SEGÚN D.L. Nº 940 - R.S. Nº 158 -2006-SUNAT/D.S.")
                                objImprimir.Agregar(145, 379, "Nº 033-2006-MTC.")
                                objImprimir.Agregar(145, 394, "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829.")
                            End If

                            'objImprimir.Agregar(635, 300, ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(20, " "))
                            objImprimir.Agregar(135, 401, "Son:  " & montoLetras)
                            objImprimir.Agregar(270, 487, dtoUSUARIOS.iLOGIN)

                            objImprimir.Agregar(460, 455, FormatNumber(dtoUSUARIOS.iIGV, 2))

                            objImprimir.Agregar(580, 427, "S/.")
                            objImprimir.Agregar(580, 443, "S/.")
                            objImprimir.Agregar(580, 461, "S/.")

                            'objImprimir.Agregar(635, 394, ObjIMPRESIONFACT_BOL.xDescuento.PadLeft(20, " "))
                            objImprimir.Agregar(635, 427, ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(20, " "))
                            objImprimir.Agregar(635, 443, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###0.00").PadLeft(20, " "))
                            objImprimir.Agregar(635, 461, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###0.00").PadLeft(20, " "))


                            objImprimir.Imprimir()
                            objImprimir = Nothing
                        Else
                            'MessageBox.Show("El Documento no tiene asociado una impresora.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ObjReport.printrptlpt(True, "", "FAC006_PROV.RPT", _
                                                "P_MONTO_LETRAS;" & montoLetras, _
                                                "P_MENSAJE;" & "...", _
                                                "P_GLOSA02;" & GLOSA2, _
                                                "P_GLOSA03;" & glosa3, _
                                                "P_NRO_FACTURA;" & ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL, _
                                                "P_CODIGO_CLIENTE;" & ObjIMPRESIONFACT_BOL.xRuc, _
                                                "P_RAZON_SOCIAL;" & ObjIMPRESIONFACT_BOL.xRazonSocial, _
                                                "P_DIRECCION_PERSONA;" & ObjIMPRESIONFACT_BOL.xDireccionRemitente, _
                                                "P_REMITENTE;" & ObjIMPRESIONFACT_BOL.xRemitente, _
                                                "P_DESTINATARIO;" & ObjIMPRESIONFACT_BOL.xConsignado, _
                                                "P_DIRECCION_REMI;" & " ", _
                                                "P_DIRECCION_DESTI;" & ObjIMPRESIONFACT_BOL.xDireccionConsignado, _
                                                "P_LOGIN;" & dtoUSUARIOS.iLOGIN, _
                                                "P_REFE;" & ObjIMPRESIONFACT_BOL.xNroRef, _
                                                "P_MEMO;" & ObjIMPRESIONFACT_BOL.xMemo, _
                                                "P_FORMA_PAGO;" & ObjIMPRESIONFACT_BOL.xFormaPago, _
                                                "P_SUB_TOTAL;" & ObjIMPRESIONFACT_BOL.xMonto_Sub_Total, _
                                                "P_MONTO_IMPUESTO;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###.00"), _
                                                "P_TOTAL_COSTO;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###.00"), _
                                                "P_DIA_FACTURA;" & dia, _
                                                "P_MES_FACTURA;" & Mes, _
                                                "P_ANIO_FACTURA;" & Anio, _
                                                "P_GLOSA;" & " ", _
                                                "P_ORIGEN;" & ObjIMPRESIONFACT_BOL.xOrigen, _
                                                "P_DESTINO;" & ObjIMPRESIONFACT_BOL.xDestino & IIf(es_carga_asegurada = True, v_ca, ""), _
                                                "P_PESO;" & PESO, _
                                                "P_PARCIAL;" & PARCIAL, _
                                                "P_CANTIDAD;" & CANTIDAD, _
                                               "P_HORA;" & fnGetHora(), _
                                                "P_DESCUENTO;" & ObjIMPRESIONFACT_BOL.xDescuento, _
                                                "P_AGENCIA;" & ObjIMPRESIONFACT_BOL.xAgenciaDestino, _
                                                "P_TIPO_ENTREGA;" & ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA _
                                                )

                        End If
                    End If

                    'ObjReport.printrptlpt(True, "", "FAC006_PROV.RPT", _
                    '                    "P_MONTO_LETRAS;" & montoLetras, _
                    '                    "P_MENSAJE;" & "...", _
                    '                    "P_GLOSA02;" & GLOSA2, _
                    '                    "P_GLOSA03;" & glosa3, _
                    '                    "P_NRO_FACTURA;" & ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL, _
                    '                    "P_CODIGO_CLIENTE;" & ObjIMPRESIONFACT_BOL.xRuc, _
                    '                    "P_RAZON_SOCIAL;" & ObjIMPRESIONFACT_BOL.xRazonSocial, _
                    '                    "P_DIRECCION_PERSONA;" & ObjIMPRESIONFACT_BOL.xDireccionRemitente, _
                    '                    "P_REMITENTE;" & ObjIMPRESIONFACT_BOL.xRemitente, _
                    '                    "P_DESTINATARIO;" & ObjIMPRESIONFACT_BOL.xConsignado, _
                    '                    "P_DIRECCION_REMI;" & " ", _
                    '                    "P_DIRECCION_DESTI;" & ObjIMPRESIONFACT_BOL.xDireccionConsignado, _
                    '                    "P_LOGIN;" & dtoUSUARIOS.iLOGIN, _
                    '                    "P_REFE;" & ObjIMPRESIONFACT_BOL.xNroRef, _
                    '                    "P_MEMO;" & ObjIMPRESIONFACT_BOL.xMemo, _
                    '                    "P_FORMA_PAGO;" & ObjIMPRESIONFACT_BOL.xFormaPago, _
                    '                    "P_SUB_TOTAL;" & ObjIMPRESIONFACT_BOL.xMonto_Sub_Total, _
                    '                    "P_MONTO_IMPUESTO;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###.00"), _
                    '                    "P_TOTAL_COSTO;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###.00"), _
                    '                    "P_DIA_FACTURA;" & dia, _
                    '                    "P_MES_FACTURA;" & Mes, _
                    '                    "P_ANIO_FACTURA;" & Anio, _
                    '                    "P_GLOSA;" & " ", _
                    '                    "P_ORIGEN;" & ObjIMPRESIONFACT_BOL.xOrigen, _
                    '                    "P_DESTINO;" & ObjIMPRESIONFACT_BOL.xDestino & IIf(es_carga_asegurada = True, v_ca, ""), _
                    '                    "P_PESO;" & PESO, _
                    '                    "P_PARCIAL;" & PARCIAL, _
                    '                    "P_CANTIDAD;" & CANTIDAD, _
                    '                   "P_HORA;" & fnGetHora(), _
                    '                    "P_DESCUENTO;" & ObjIMPRESIONFACT_BOL.xDescuento, _
                    '                    "P_AGENCIA;" & ObjIMPRESIONFACT_BOL.xAgenciaDestino, _
                    '                    "P_TIPO_ENTREGA;" & ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA _
                    '                    )
            End Select
            'Tepsa. 
            'P_GLOSA;" & " " POR NUESTRO SERVICIO DE TRANSPORTE DE CARGA EN ATENCIÓN A SUS ORDENES, SEGÚN RELACIÓN ADJUNTA", _
            ' = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function
    Public Function fnImprimirBOLETA() As Boolean
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport
        Try
            Dim HoraSistema As String = fnGetHora()
            Dim GLOSA2 As String = ""
            Dim PESO As String = ""
            Dim PARCIAL As String = ""
            Dim CANTIDAD As String = ""
            '
            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                CANTIDAD = ObjIMPRESIONFACT_BOL.xCantidad_Peso & Chr(13)
                GLOSA2 = "BULTOS" & Chr(13)
                PESO = ObjIMPRESIONFACT_BOL.xTotalPeso & Chr(13)
                PARCIAL = Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "####,###,###.00") & Chr(13)
            End If

            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Vol & "" & Chr(13)
                GLOSA2 = GLOSA2 & "BULTOS (V.)" & Chr(13)
                PESO = PESO & ObjIMPRESIONFACT_BOL.xTotalVolumen & Chr(13)
                PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "####,###,###.00") & Chr(13)
            End If

            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Sobre & ""
                GLOSA2 = GLOSA2 & "SOBRES"
                PESO = PESO & ""
                PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "####,###,###.00")
            End If

            Dim Detalle As String = CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Vol)
            Detalle = Detalle & "  SOBRE'S: " & CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString
            GLOSA2 = "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString & Chr(13) & "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString
            '"P_DETALLE;" & "CANTIDAD: " & CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Sobre) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Vol), _
            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(dtGridViewBultos(7, 2).Value)
            ObjReport.rutaRpt = PathFrmReport
            Select Case tipo_bole_impre
                Case "A"
                    ObjReport.printrptlpt(True, "", "FAC007.RPT", _
                    "P_SERVICIO;" & "ENCOMIENDAS", _
                    "P_ORIGEN;" & ObjIMPRESIONFACT_BOL.xOrigen, _
                    "P_DESTINO;" & ObjIMPRESIONFACT_BOL.xDestino & IIf(es_carga_asegurada = True, v_ca, ""), _
                    "P_FECHA_EMISION;" & ObjIMPRESIONFACT_BOL.xfecha_factura, _
                    "P_FORMA_PAGO;" & ObjIMPRESIONFACT_BOL.xFormaPago, _
                    "P_REMITENTE;" & ObjIMPRESIONFACT_BOL.xRazonSocial, _
                    "P_OPERACION_DESTINO;" & "...", _
                    "P_TIPO_SERVICIO;" & "ENCOMIENDA", _
                    "P_CONSIGNADO;" & ObjIMPRESIONFACT_BOL.xConsignado, _
                    "P_DIRECCION;" & ObjIMPRESIONFACT_BOL.xDireccionConsignado, _
                    "P_PESO;" & ObjIMPRESIONFACT_BOL.xTotalPeso, _
                    "P_VOLUMEN;" & ObjIMPRESIONFACT_BOL.xTotalVolumen, _
                    "P_FLETE;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"), _
                    "P_DETALLE;" & GLOSA2, _
                    "P_NUMERO_BOLETA;" & ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL, _
                    "P_HORA_GUIA;" & "HORA : " & HoraSistema, _
                    "P_TOTAL;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "###,###,###.00"), _
                    "P_LOGIN;" & dtoUSUARIOS.iLOGIN, _
                    "P_INTERNO;" & ObjIMPRESIONFACT_BOL.xIdFactura, _
                    "P_AGENCIA;" & ObjIMPRESIONFACT_BOL.xAgenciaDestino _
                    )
                Case "N"
                    Dim sImpresora As String = Imprimir.ObtieneImpresora(2, dtoUSUARIOS.IP)

                    If sImpresora.Trim.Length > 0 Then
                        Dim obj As New Imprimir
                        obj.Inicializar()
                        obj.Impresora = sImpresora

                        'objImprimir.Agregar(15, 73, ObjIMPRESIONFACT_BOL.xOrigen)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xOrigen)
                        'objImprimir.Agregar(15, 91, ObjIMPRESIONFACT_BOL.xfecha_factura)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xfecha_factura)
                        'objImprimir.Agregar(15, 109, ObjIMPRESIONFACT_BOL.xRazonSocial)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xRazonSocial)
                        'objImprimir.Agregar(15, 127, ObjIMPRESIONFACT_BOL.xConsignado)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xConsignado)
                        'objImprimir.Agregar(15, 145, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                        'objImprimir.Agregar(162, 73, ObjIMPRESIONFACT_BOL.xDestino)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xDestino)

                        If es_carga_asegurada Then
                            'objImprimir.Agregar(70, 1, v_ca)
                            obj.EscribirLinea(v_ca)
                        End If
                        'objImprimir.Agregar(162, 91, HoraSistema)
                        obj.EscribirLinea(HoraSistema)

                        'objImprimir.Agregar(290, 91, ObjIMPRESIONFACT_BOL.xFormaPago)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xFormaPago)
                        'objImprimir.Agregar(335, 73, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)

                        'objImprimir.Agregar(100, 178, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                        obj.EscribirLinea("BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                        'objImprimir.Agregar(100, 193, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)
                        obj.EscribirLinea("SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)
                        'objImprimir.Agregar(250, 178, ObjIMPRESIONFACT_BOL.xTotalPeso)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xTotalPeso)
                        'objImprimir.Agregar(290, 178, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xTotalVolumen)

                        If es_carga_asegurada Then
                            'objImprimir.Agregar(250, 208, dtoUSUARIOS.iLOGIN)
                            obj.EscribirLinea(dtoUSUARIOS.iLOGIN)
                            ObtieneMontosAsegurados(iSubTotal, iImpuesto, iTotal)
                            iTotal = FormatNumber(iTotal, 2)
                            If ObjVentaCargaContado.v_MONTO_DESCUENTO > 0 Then
                                iTotal = iTotal * (1 - (ObjVentaCargaContado.v_MONTO_DESCUENTO / 100))
                            End If

                            'objImprimir.Agregar(360, 208, Format(CDbl(iTotal), "###,###,###.00"))
                            obj.EscribirLinea(Format(CDbl(iTotal), "###,###,###.00"))
                            'objImprimir.Agregar(100, 208, "SEGURO CARGA")
                            obj.EscribirLinea("SEGURO CARGA")
                            'objImprimir.Agregar(360, 178, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                            obj.EscribirLinea(Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))

                            'objImprimir.Agregar(480, 208, "SEGURO CARGA")
                            obj.EscribirLinea("SEGURO CARGA")
                            'objImprimir.Agregar(700, 208, Format(CDbl(iTotal), "###,###,###.00"))
                            obj.EscribirLinea(Format(CDbl(iTotal), "###,###,###.00"))
                            'objImprimir.Agregar(630, 208, dtoUSUARIOS.iLOGIN)
                            obj.EscribirLinea(dtoUSUARIOS.iLOGIN)
                            'objImprimir.Agregar(700, 178, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                            obj.EscribirLinea(Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                        Else
                            'objImprimir.Agregar(360, 178, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                            obj.EscribirLinea(Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                            'objImprimir.Agregar(100, 208, dtoUSUARIOS.iLOGIN)
                            obj.EscribirLinea(dtoUSUARIOS.iLOGIN)

                            'objImprimir.Agregar(700, 178, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                            obj.EscribirLinea(Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                            'objImprimir.Agregar(480, 208, dtoUSUARIOS.iLOGIN)
                            obj.EscribirLinea(dtoUSUARIOS.iLOGIN)
                        End If

                        'objImprimir.Agregar(162, 33, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)

                        'objImprimir.Agregar(480, 73, ObjIMPRESIONFACT_BOL.xOrigen)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xOrigen)
                        'objImprimir.Agregar(480, 91, ObjIMPRESIONFACT_BOL.xfecha_factura)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xfecha_factura)
                        'objImprimir.Agregar(480, 109, ObjIMPRESIONFACT_BOL.xRazonSocial)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xRazonSocial)
                        'objImprimir.Agregar(480, 127, ObjIMPRESIONFACT_BOL.xConsignado)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xConsignado)
                        'objImprimir.Agregar(480, 145, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                        'objImprimir.Agregar(585, 73, ObjIMPRESIONFACT_BOL.xDestino)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xDestino)
                        'objImprimir.Agregar(585, 91, HoraSistema)
                        obj.EscribirLinea(HoraSistema)

                        'objImprimir.Agregar(675, 91, ObjIMPRESIONFACT_BOL.xFormaPago)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xFormaPago)
                        'objImprimir.Agregar(695, 73, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)
                        'objImprimir.Agregar(360, 238, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                        obj.EscribirLinea(Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))

                        'objImprimir.Agregar(0, 33, ObjIMPRESIONFACT_BOL.xIdFactura)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xIdFactura)
                        'objImprimir.Agregar(162, 58, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xAgenciaDestino)

                        'objImprimir.Agregar(440, 33, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                        'objImprimir.Agregar(440, 48, ObjIMPRESIONFACT_BOL.xIdFactura)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xIdFactura)
                        'objImprimir.Agregar(440, 63, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xAgenciaDestino)

                        'objImprimir.Agregar(480, 178, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                        obj.EscribirLinea("BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                        'objImprimir.Agregar(480, 193, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)
                        obj.EscribirLinea("SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)

                        'objImprimir.Agregar(580, 178, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xTotalVolumen)
                        'objImprimir.Agregar(650, 178, ObjIMPRESIONFACT_BOL.xTotalPeso)
                        obj.EscribirLinea(ObjIMPRESIONFACT_BOL.xTotalPeso)

                        'objImprimir.Agregar(700, 238, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                        obj.EscribirLinea(Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))

                        obj.Imprimir()
                        obj.Finalizar()

                    Else
                        'Envío de impresión texto Boleta (Nuevo)
                        Dim objImpresora As New dtoVentaCargaContado
                        Dim flag = objImpresora.fnSP_Buscar_Impresora(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE, dtoUSUARIOS.IP)
                        If flag Then
                            Dim objImprimir As New ImprimirTexto("Draft Condensed", 8, objImpresora.v_Impresora, "boleta", 1305, 1305)

                            objImprimir.Agregar(15, 73, ObjIMPRESIONFACT_BOL.xOrigen)
                            objImprimir.Agregar(15, 91, ObjIMPRESIONFACT_BOL.xfecha_factura)
                            objImprimir.Agregar(15, 109, ObjIMPRESIONFACT_BOL.xRazonSocial)
                            objImprimir.Agregar(15, 127, ObjIMPRESIONFACT_BOL.xConsignado)
                            objImprimir.Agregar(15, 145, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                            objImprimir.Agregar(162, 73, ObjIMPRESIONFACT_BOL.xDestino)

                            If es_carga_asegurada Then
                                objImprimir.Agregar(70, 1, v_ca)
                            End If
                            objImprimir.Agregar(162, 91, HoraSistema)

                            objImprimir.Agregar(290, 91, ObjIMPRESIONFACT_BOL.xFormaPago)
                            objImprimir.Agregar(335, 73, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)

                            objImprimir.Agregar(100, 178, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                            objImprimir.Agregar(100, 193, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)
                            objImprimir.Agregar(250, 178, ObjIMPRESIONFACT_BOL.xTotalPeso)
                            objImprimir.Agregar(290, 178, ObjIMPRESIONFACT_BOL.xTotalVolumen)

                            If es_carga_asegurada Then
                                objImprimir.Agregar(250, 208, dtoUSUARIOS.iLOGIN)
                                ObtieneMontosAsegurados(iSubTotal, iImpuesto, iTotal)
                                iTotal = FormatNumber(iTotal, 2)
                                If ObjVentaCargaContado.v_MONTO_DESCUENTO > 0 Then
                                    iTotal = iTotal * (1 - (ObjVentaCargaContado.v_MONTO_DESCUENTO / 100))
                                End If
                                'objImprimir.Agregar(635, 345, iTotal.ToString.PadLeft(20, " "))
                                objImprimir.Agregar(360, 208, Format(CDbl(iTotal), "###,###,###.00"))
                                objImprimir.Agregar(100, 208, "SEGURO CARGA")
                                objImprimir.Agregar(360, 178, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))

                                objImprimir.Agregar(480, 208, "SEGURO CARGA")
                                objImprimir.Agregar(700, 208, Format(CDbl(iTotal), "###,###,###.00"))
                                objImprimir.Agregar(630, 208, dtoUSUARIOS.iLOGIN)
                                objImprimir.Agregar(700, 178, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                            Else
                                objImprimir.Agregar(360, 178, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                                objImprimir.Agregar(100, 208, dtoUSUARIOS.iLOGIN)

                                objImprimir.Agregar(700, 178, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                                objImprimir.Agregar(480, 208, dtoUSUARIOS.iLOGIN)
                            End If

                            objImprimir.Agregar(162, 33, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)

                            objImprimir.Agregar(480, 73, ObjIMPRESIONFACT_BOL.xOrigen)
                            objImprimir.Agregar(480, 91, ObjIMPRESIONFACT_BOL.xfecha_factura)
                            objImprimir.Agregar(480, 109, ObjIMPRESIONFACT_BOL.xRazonSocial)
                            objImprimir.Agregar(480, 127, ObjIMPRESIONFACT_BOL.xConsignado)
                            objImprimir.Agregar(480, 145, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                            objImprimir.Agregar(585, 73, ObjIMPRESIONFACT_BOL.xDestino)
                            objImprimir.Agregar(585, 91, HoraSistema)

                            objImprimir.Agregar(675, 91, ObjIMPRESIONFACT_BOL.xFormaPago)
                            objImprimir.Agregar(695, 73, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)
                            objImprimir.Agregar(360, 238, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))

                            objImprimir.Agregar(0, 33, ObjIMPRESIONFACT_BOL.xIdFactura)
                            objImprimir.Agregar(162, 58, ObjIMPRESIONFACT_BOL.xAgenciaDestino)

                            objImprimir.Agregar(440, 33, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                            objImprimir.Agregar(440, 48, ObjIMPRESIONFACT_BOL.xIdFactura)
                            objImprimir.Agregar(440, 63, ObjIMPRESIONFACT_BOL.xAgenciaDestino)

                            'objImprimir.Agregar(325, 225, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))


                            objImprimir.Agregar(480, 178, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                            objImprimir.Agregar(480, 193, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)

                            objImprimir.Agregar(580, 178, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                            objImprimir.Agregar(650, 178, ObjIMPRESIONFACT_BOL.xTotalPeso)

                            objImprimir.Agregar(700, 238, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))


                            objImprimir.Imprimir()
                            objImprimir = Nothing
                        Else
                            'MessageBox.Show("El Documento no tiene asociado una impresora.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ObjReport.printrptlpt(True, "", "FAC007_PROV.RPT", _
                            "P_SERVICIO;" & "ENCOMIENDAS", _
                            "P_ORIGEN;" & ObjIMPRESIONFACT_BOL.xOrigen, _
                            "P_DESTINO;" & ObjIMPRESIONFACT_BOL.xDestino & IIf(es_carga_asegurada = True, v_ca, ""), _
                            "P_FECHA_EMISION;" & ObjIMPRESIONFACT_BOL.xfecha_factura, _
                            "P_FORMA_PAGO;" & ObjIMPRESIONFACT_BOL.xFormaPago, _
                            "P_REMITENTE;" & ObjIMPRESIONFACT_BOL.xRazonSocial, _
                            "P_OPERACION_DESTINO;" & "...", _
                            "P_TIPO_SERVICIO;" & "ENCOMIENDA", _
                            "P_CONSIGNADO;" & ObjIMPRESIONFACT_BOL.xConsignado, _
                            "P_DIRECCION;" & ObjIMPRESIONFACT_BOL.xDireccionConsignado, _
                            "P_PESO;" & ObjIMPRESIONFACT_BOL.xTotalPeso, _
                            "P_VOLUMEN;" & ObjIMPRESIONFACT_BOL.xTotalVolumen, _
                            "P_FLETE;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"), _
                            "P_DETALLE;" & GLOSA2, _
                            "P_NUMERO_BOLETA;" & ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL, _
                            "P_HORA_GUIA;" & "HORA : " & HoraSistema, _
                            "P_TOTAL;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "###,###,###.00"), _
                            "P_LOGIN;" & dtoUSUARIOS.iLOGIN, _
                            "P_INTERNO;" & ObjIMPRESIONFACT_BOL.xIdFactura, _
                            "P_AGENCIA;" & ObjIMPRESIONFACT_BOL.xAgenciaDestino, _
                            "P_TIPO_ENTREGA;" & ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA _
                            )

                        End If
                    End If

                    'ObjReport.printrptlpt(True, "", "FAC007_PROV.RPT", _
                    '"P_SERVICIO;" & "ENCOMIENDAS", _
                    '"P_ORIGEN;" & ObjIMPRESIONFACT_BOL.xOrigen, _
                    '"P_DESTINO;" & ObjIMPRESIONFACT_BOL.xDestino & IIf(es_carga_asegurada = True, v_ca, ""), _
                    '"P_FECHA_EMISION;" & ObjIMPRESIONFACT_BOL.xfecha_factura, _
                    '"P_FORMA_PAGO;" & ObjIMPRESIONFACT_BOL.xFormaPago, _
                    '"P_REMITENTE;" & ObjIMPRESIONFACT_BOL.xRazonSocial, _
                    '"P_OPERACION_DESTINO;" & "...", _
                    '"P_TIPO_SERVICIO;" & "ENCOMIENDA", _
                    '"P_CONSIGNADO;" & ObjIMPRESIONFACT_BOL.xConsignado, _
                    '"P_DIRECCION;" & ObjIMPRESIONFACT_BOL.xDireccionConsignado, _
                    '"P_PESO;" & ObjIMPRESIONFACT_BOL.xTotalPeso, _
                    '"P_VOLUMEN;" & ObjIMPRESIONFACT_BOL.xTotalVolumen, _
                    '"P_FLETE;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"), _
                    '"P_DETALLE;" & GLOSA2, _
                    '"P_NUMERO_BOLETA;" & ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL, _
                    '"P_HORA_GUIA;" & "HORA : " & HoraSistema, _
                    '"P_TOTAL;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "###,###,###.00"), _
                    '"P_LOGIN;" & dtoUSUARIOS.iLOGIN, _
                    '"P_INTERNO;" & ObjIMPRESIONFACT_BOL.xIdFactura, _
                    '"P_AGENCIA;" & ObjIMPRESIONFACT_BOL.xAgenciaDestino, _
                    '"P_TIPO_ENTREGA;" & ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA _
                    ')
            End Select
            ObjReport = Nothing

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
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
            '
        End Try
        'Modificado 12/03/2008 tema de redondeo 
        If monto Mod 0.5 = 0 Then
            Return monto
        Else
            Return monto_total
        End If

    End Function

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        Try
            SelectMenu(1)
            fnNUEVO()
            limpiar_documentos_cliente()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AnularToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularToolStripMenuItem.Click
        Try
            'objLOG.fnLog("ANULACION DE UN DOCUMENTO....")
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                Return
            End If
            ObjProcesosVentaContado.iControl = 1
            ObjProcesosVentaContado.idFacturaBoleta = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            If ObjVentaCargaContado.fnValidarProceso(ObjProcesosVentaContado.idFacturaBoleta) = False Then
                MsgBox("No puede realizar está operación, ya está anulada...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If

            If ObjProcesosVentaContado.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                If ObjVentaCargaContado.fnANULDEVVENAS(ObjProcesosVentaContado.iControl, ObjProcesosVentaContado.idFacturaBoleta, 0) = True Then

                    If ObjVentaCargaContado.v_CONTROL_ANUDEV = 1 Then
                        dtGridViewControl_FACBOL.Rows(row).DataGridView(IDGRIESTADO_REG, row).Value = 2
                        dtGridViewControl_FACBOL.UpdateCellValue(0, row)
                        'objLOG.fnLog("ANULACION CORRECTA....")
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DevolucionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevolucionToolStripMenuItem.Click
        Try
            'objLOG.fnLog("INICIO DE UNA DEVOLUCION....")
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                Return
            End If
            ObjProcesosVentaContado.iControl = 2
            ObjProcesosVentaContado.idFacturaBoleta = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            If ObjVentaCargaContado.fnValidarProceso(ObjProcesosVentaContado.idFacturaBoleta) = False Then
                MsgBox("No puede realizar está operación, ya está devolución...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            If ObjProcesosVentaContado.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                Dim x_PORCENT_DEVOLUCION As Double = ObjProcesosVentaContado.x_PORCENT_DEVOLUCION
                If ObjVentaCargaContado.fnANULDEVVENAS(ObjProcesosVentaContado.iControl, ObjProcesosVentaContado.idFacturaBoleta, ObjProcesosVentaContado.x_PORCENT_DEVOLUCION) = True Then
                    dtGridViewControl_FACBOL.Rows(row).DataGridView(IDGRIESTADO_REG, row).Value = 29
                    dtGridViewControl_FACBOL.UpdateCellValue(0, row)
                    'objLOG.fnLog("Devolución realizada correctamente....")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub VerDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerDataToolStripMenuItem.Click
        Try
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim v_idFacura As Integer = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            Iid = v_idFacura
            If ObjVentaCargaContado.fnVERDATA_IV(v_idFacura) = True Then
                SelectMenu(1)
                fnVERDATOSVENTACONTADO(2)
                ObjVentaCargaContado.fnClearOBJ(2)
            Else
                MsgBox("No puede cargar esta data, faltan datos...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox("revizar datos....", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    'Private Sub txtCliente_Remitente_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCliente_Remitente.Validating
    '    fnVALIDARDOCUMENTOS()
    'End Sub
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            ObjBusquedaClientes.v_fecha_inicio = dtFechaInicio.Text
            ObjBusquedaClientes.v_fecha_final = dtFechaFin.Text

            Acceso.Asignar(ObjfrmBuscarCliente, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                If ObjfrmBuscarCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    objControlFacturasBol.iControl = 5
                    fnBuscarFacturas()
                    ObjBusquedaClientes.idPersona = 0
                    objControlFacturasBol.iControl = 0
                End If
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'If ObjfrmBuscarCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    objControlFacturasBol.iControl = 5
            '    fnBuscarFacturas()
            '    ObjBusquedaClientes.idPersona = 0
            '    objControlFacturasBol.iControl = 0
            'End If
        Catch ex As Exception
            ObjBusquedaClientes.idPersona = 0
        End Try
    End Sub

    Private Sub txtCosto_Total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCosto_Total.TextChanged
        Try
            If bControlFiscalizacion = True Then
                ' Modificado 08/03/2007
                txtSub_Total.Text = Format(Val(txtCosto_Total.Text) / (1 + (dtoUSUARIOS.iIGV) / 100), "###,###,###.00")
                txtMonto_IGV.Text = Format(Val(txtCosto_Total.Text) - Val(txtSub_Total.Text), "###,###,###.00")
                '
                'txtSub_Total.Text = Val(txtCosto_Total.Text) / (1 + (dtoUSUARIOS.iIGV) / 100)
                'txtMonto_IGV.Text = Val(txtCosto_Total.Text) - Val(txtSub_Total.Text)
                '           
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnTIKET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTIKET.Click
        Try
            Dim objEtiqueta As New dtoGuiaEnvio
            Dim ll_idusuario_tmp As Long
            ObjVentaCargaContado.V_CONTROL_PCE = False
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If

            If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.No Then Exit Sub

            Dim v_idFacura As Integer = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            'Verifica si documento para el cual se reimprimiran etiquetas ya ha sido impreso
            Dim iDoc As Integer
            Dim sDoc As String
            If Mid(dtGridViewControl_FACBOL.Rows(row).Cells(3).Value, 1, 1) = "B" Then
                iDoc = 2
                sDoc = "BOLETA"
            ElseIf Mid(dtGridViewControl_FACBOL.Rows(row).Cells(3).Value, 1, 1) = "F" Then
                iDoc = 1
                sDoc = "FACTURA"
            Else
                iDoc = 85
                sDoc = "PCE"
            End If
            If objEtiqueta.fnEtiquetaImpresa(iDoc, dtGridViewControl_FACBOL.Rows(row).Cells(1).Value) Then
                If objEtiqueta.dt_cur_etiqueta.Rows(0)(0) = 1 Then
                    'Obtener usuario y password de usuario que reimprime
                    ll_idusuario_tmp = dtoUSUARIOS.IdLogin
                    Dim lfrmusuario_entrega As New frmUsuarioEtiqueta
                    lfrmusuario_entrega.Lab_tip_dcto.Text = sDoc '24/10/2008
                    lfrmusuario_entrega.txt_dcto.Text = dtGridViewControl_FACBOL.Rows(row).Cells(2).Value '24/10/2008
                    lfrmusuario_entrega.txt_origen.Text = dtGridViewControl_FACBOL.Rows(row).Cells(6).Value
                    lfrmusuario_entrega.txt_destino.Text = dtGridViewControl_FACBOL.Rows(row).Cells(5).Value

                    lfrmusuario_entrega.txtLogin.Text = dtoUSUARIOS.iLOGIN
                    lfrmusuario_entrega.txtPasswor.Focus()

                    'lfrmusuario_entrega.ShowDialog()
                    Acceso.Asignar(lfrmusuario_entrega, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        lfrmusuario_entrega.ShowDialog()
                    Else
                        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                    If lfrmusuario_entrega.pb_cancelar = True Then
                        Exit Sub ' No hace nada 
                    End If
                    dtoUSUARIOS.IdLogin = lfrmusuario_entrega.pl_idusuario_personal
                End If
            End If

            'Genera etiquetas
            Dim sMotivo As String
            Dim sEtiqueta As String
            Dim ll_total As Long
            '
            ll_total = dtGridViewControl_FACBOL.Rows(row).Cells(12).Value
            '
            If objEtiqueta.dt_cur_etiqueta.Rows(0)(0) = 1 Then
                Dim a As New FrmRangoEtiquetas()
                a.total_bultos = ll_total
                'a.ShowDialog()
                Acceso.Asignar(a, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    a.ShowDialog()
                    sMotivo = a.txtMotivo.Text
                    sEtiqueta = a.NumeUDini.Value
                    'bRango = False
                    iRango = 2
                Else
                    MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            Else
                Dim a As New FrmRangoEtiquetas2()
                '
                a.total_bultos = ll_total
                '
                'a.ShowDialog()
                Acceso.Asignar(a, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    a.ShowDialog()
                    'bRango = True
                    iRango = 1
                Else
                    MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            End If

            If correlativo_inicial = -1 Then Exit Sub

            'If ObjVentaCargaContado.fnREIMPRESIONCODIGOS(1, v_idFacura) = True Then
            ObjVentaCargaContado.UsuarioEtiqueta = dtoUSUARIOS.IdLogin
            If ObjVentaCargaContado.fnREIMPRESIONCODIGOSII(1, v_idFacura, correlativo_inicial, correlativo_inicial) = True Then
                'If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then
                '''''''''
                'hlamas 26/08/2009
                'Obtiene Fecha y Hora
                ObjVentaCargaContado.fnFechaRegistro(iDoc, v_idFacura)
                sFecha = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(0)
                sHora = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(1)


                If xIMPRESORA = 1 Then
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
                        If objReimpresionEtiquetas.fnActualizaReimpresion(iDoc, dtGridViewControl_FACBOL.Rows(row).Cells(1).Value, ObjCODIGOBARRA.CodigoBarra, sMotivo, CDate(ObjCODIGOBARRA.Fecha), dtoUSUARIOS.IdLogin, ObjCODIGOBARRA.fnGetHora, sEtiqueta) Then
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
                dtoUSUARIOS.IdLogin = ll_idusuario_tmp
            End If

        Catch ex As Exception
            MsgBox("revisar datos....", MsgBoxStyle.Information, "Seguridad Sistema")
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
            '''''
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
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
                prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
                prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")
                prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")
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

            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
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

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        Try

            'If fnValidar_Rol("24") = False Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 4) Then
                MsgBox("Usted no Tiene Acceso...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            'objLOG.fnLog("INICIO DE UNA ELIMIANCION....")
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                Return
            End If
            Dim idFacturaBoleta As String = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            If MsgBox("Esta Seguro que quiere Eliminar este documento" & dtGridViewControl_FACBOL.Rows(row).Cells(2).Value.ToString, MsgBoxStyle.YesNoCancel, "") = MsgBoxResult.Yes Then
                If ObjVentaCargaContado.fnELIMINAR_DOCUMENTO(idFacturaBoleta) = False Then
                    dtGridViewControl_FACBOL.Rows.RemoveAt(row)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub


    Private Sub dtGridViewControl_FACBOL_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtGridViewControl_FACBOL.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                ContextMenuStrip.Show(sender, e.X, e.Y)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub ExportExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcelToolStripMenuItem.Click
        Try
            fnEXCELGrid(dtGridViewControl_FACBOL)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub
    'Public Function fnImprimirEtiquetasFAC_III() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim prn As New PrinterTxt.PrintTxt
    '        Dim cadena As String = ""
    '        Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
    '        'prn.Nombre_impresora = "PRNZEBRA"
    '        prn.Nombre_impresora = NOMBRE_IMPRESORA
    '        Dim EXISTE As Boolean = prn.SetearImpresora()

    '        ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
    '        ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
    '        ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
    '        ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

    '        Dim I As Int16 = 1
    '        'While objGuiaEnvio.cur_codBarras.EOF = False And objGuiaEnvio.cur_codBarras.BOF = False
    '        While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
    '            ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
    '            prn.EscribeLinea("N")
    '            prn.EscribeLinea("N")
    '            prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
    '            prn.EscribeLinea("A30,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
    '            prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
    '            prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
    '            prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
    '            prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")
    '            prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")
    '            prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
    '            prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
    '            'prn.EscribeLinea("A260,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
    '            'prn.EscribeLinea("A260,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
    '            'prn.EscribeLinea("A547,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
    '            'prn.EscribeLinea("A260,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
    '            'prn.EscribeLinea("A260,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
    '            'prn.EscribeLinea("A551,163,0,1,1,1,N,""TEPSAC""")
    '            'prn.EscribeLinea("A435,163,0,1,1,1,N,""" & HoraActual & """")
    '            'prn.EscribeLinea("A319,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
    '            'prn.EscribeLinea("B378,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
    '            prn.EscribeLinea("P1")
    '            prn.EscribeLinea("N")
    '            prn.EscribeLinea(cadena)
    '            ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
    '            I = I + 1
    '        End While
    '        prn.FinDoc()
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
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
            '
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
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
            For Each fila As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows
                ObjCODIGOBARRA.CodigoBarra = fila.Item(0)
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                prn.EscribeLinea("A30,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
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
    Private Function fnLoadGrid_Control() As Boolean
        Try
            With dtGridViewArticulo
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToOrderColumns = False
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = False
                .AutoGenerateColumns = False
                '.DataSource = dtable_Lista_Control_Comprobante
                .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            Dim col_Art1 As New DataGridViewTextBoxColumn
            With col_Art1
                .DisplayIndex = 0
                .DataPropertyName = "idarticulos"
                .HeaderText = "idarticulos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewArticulo.Columns.Add(col_Art1)
            Dim col_Art2 As New DataGridViewTextBoxColumn
            With col_Art2
                .DisplayIndex = 1
                .DataPropertyName = "Nombre_Articulo"
                .HeaderText = "ARTICULO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewArticulo.Columns.Add(col_Art2)
            Dim col_Art0 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'Dim col_Art0 As New DataGridViewTextBoxColumn
            With col_Art0
                .DisplayIndex = 2
                .DataPropertyName = "Precio_Final"
                .HeaderText = "PRECIO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "####,###.00"
                .Mask = "####,###.00"
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewArticulo.Columns.Add(col_Art0)
            Dim col_Art3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'Dim col_Art3 As New DataGridViewTextBoxColumn
            With col_Art3
                .DisplayIndex = 3
                .DataPropertyName = "Cantidad"
                .HeaderText = "CANTIDAD"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Mask = "#####0"
                .ReadOnly = False
                .Visible = True
            End With
            dtGridViewArticulo.Columns.Add(col_Art3)
            Dim col_Art4 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'Dim col_Art0 As New DataGridViewTextBoxColumn
            With col_Art4
                .DisplayIndex = 4
                .DataPropertyName = "PESO_TOTAL"
                .HeaderText = "PESO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.DefaultCellStyle.Format = "####,###.00"
                '.Mask = "####,###.00"
                .ReadOnly = False
                .Visible = True
            End With
            dtGridViewArticulo.Columns.Add(col_Art4)
            Dim col_Art5 As New DataGridViewTextBoxColumn
            With col_Art5
                .DisplayIndex = 5
                .DataPropertyName = "TOTAL_COSTO"
                .HeaderText = "T.COSTO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewArticulo.Columns.Add(col_Art5)
            With DataGridViewDocumentos
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
                .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = False
                .AutoGenerateColumns = False
                '.DataSource = dtable_Lista_Control_Comprobante
                .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            Dim col_1 As New DataGridViewTextBoxColumn
            With col_1
                .DisplayIndex = 0
                .DataPropertyName = "id1"
                .HeaderText = "ID1"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewDocumentos.Columns.Add(col_1)
            Dim col_0 As New DataGridViewTextBoxColumn
            With col_0
                .DisplayIndex = 1
                .DataPropertyName = "id2"
                .HeaderText = "ID2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            DataGridViewDocumentos.Columns.Add(col_0)
            'Dim col1 As New DataGridViewTextBoxColumn
            Dim col_2 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            With col_2
                .DisplayIndex = 2
                .DataPropertyName = "NRODOCUMENTO1"
                .HeaderText = "DOC. CARGO"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Mask = "###-########"
                .DefaultCellStyle.NullValue = "-"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = False
            End With
            DataGridViewDocumentos.Columns.Add(col_2)
            Dim col_3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'Dim col2 As New DataGridViewTextBoxColumn
            With col_3
                .DisplayIndex = 3
                .DataPropertyName = "NRODOCUMENTO2"
                .HeaderText = "DOC. SEGURO"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Mask = "###-########"
                .DefaultCellStyle.NullValue = "-"
                .ReadOnly = True
            End With
            DataGridViewDocumentos.Columns.Add(col_3)
            Dim row11 As String() = {"", "", "-", "-"}
            DataGridViewDocumentos.Rows().Add(row11)
            DataGridViewDocumentos.Rows().Add(row11)
        Catch ex As Exception

        End Try
    End Function

    Private Sub dtGridViewArticulo_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewArticulo.CellEndEdit
        Try
            Dim row As Short = e.RowIndex
            Dim col As Short = e.ColumnIndex
            Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            Dim SubTotal_Costo As Double = 0

            If col = 3 Then
                fnTarifario()
                'If fnTarifario() = True Then
                If dtGridViewArticulo.Visible = True Then
                    objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = 0
                    Dim Total As Double = 0
                    Dim ii1 As Integer = 0

                    dtGridViewArticulo.Rows(row).Cells(5).Value = Format(Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(row).Cells(2).Value) * Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(row).Cells(3).Value), "###,###,####.00")
                    'dtGridViewArticulo.Rows(row).Cells(3).Value = Format(Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(row).Cells(3).Value), "###,###,####.000")
                    For ii1 = 0 To dtGridViewArticulo.Rows().Count() - 1
                        Total = Total + Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(ii1).Cells(5).Value.ToString)
                        'objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString)
                    Next

                    Dim Monto_Sobre As Double = 0
                    If checkSobres.Checked = True Then
                        Monto_Sobre = tarifa_Sobre * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                        txtTotalSobre.Visible = True
                        txtTotalSobre.Text = Format(Monto_Sobre, "####,###,###.00")
                    End If

                    SubTotal_Costo = Monto_Base + Total + Monto_Sobre
                    If Total = 0 Then
                        SubTotal_Costo = Monto_Sobre
                    End If

                    Dim SUB_TOTAL_GENERAL As Double = 0
                    If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) > 0 Then
                        SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00"))
                    Else
                        If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) = 0 Then
                            SUB_TOTAL_GENERAL = 0
                        End If
                    End If


                    txtSub_Total.Text = Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
                    txtMonto_IGV.Text = Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
                    txtCosto_Total.Text = Format(SUB_TOTAL_GENERAL, "###,###,###.00")

                    'txtSub_Total.Text = Format(SUB_TOTAL_GENERAL, "##,####,####.00")
                    'txtMonto_IGV.Text = Format(SUB_TOTAL_GENERAL * dtoUSUARIOS.iIGV / 100, "##,####,####.00")
                    'txtCosto_Total.Text = Format(SUB_TOTAL_GENERAL * (1 + dtoUSUARIOS.iIGV / 100), "##,####,####.00")

                    'txtSubTotal.Text = Format(Total, "##,####,####.00")
                    'txMontotIGV.Text = Format(Total * IGV, "##,####,####.00")
                    'txtTotal_Pago.Text = Format(Total * (1 + IGV), "##,####,####.00")
                End If
                'End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub fnControl_Articulos()
        Try
            Dim i As Integer = 0
            If dtGridViewArticulo.Rows().Count >= 1 And es_carga_asegurada Then
                MessageBox.Show("No puede realizar venta de artículos con Carga Asegurada.", "Titán", MessageBoxButtons.OK)
                Exit Sub
            End If

            If fArticulo = False Then
                If dtGridViewArticulo.Rows().Count >= 1 Then
                    If recuperando_datos_contado = False Then
                        fArticulo = True
                        dtGridViewBultos.Visible = False
                        dtGridViewArticulo.Visible = True
                        lbArticulos.Text = "( F11 ) PESO VOLUMEN"
                        dtGridViewArticulo.Focus()
                        fnControlArticulo_Peso()

                        txtTotalSobre.Visible = True
                        txtCantidadSobres.Visible = True
                        txtCantidadSobres.Text = 0
                        checkSobres.Visible = True

                        lblMinimo.Visible = False
                        lblMontoMinimo.Visible = False

                        lblMontoBase.Visible = True
                        txtMontoBase.Visible = True
                        txtMontoBase.Text = FormatNumber(IIf(Val(Monto_Base) = 0, 0, Monto_Base), 2)
                        txtPorcernt_Descuento.Text = ""
                        txtPorcernt_Descuento.Enabled = False
                        txtMemo.Text = ""
                        txtMemo.Visible = False
                        lbMemo.Visible = False

                        'fnArticulo_Peso()           
                    End If
                    'lblMontoBase.Visible = True
                    'txtMontoBase.Visible = True
                Else
                    lblMontoBase.Visible = False
                    txtMontoBase.Visible = False
                    If recuperando_datos_contado = False Then
                        MsgBox("No Puede realizar esta Operación, No Tiene Articulos Asociados", MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                End If
            Else
                lblMontoBase.Visible = False
                txtMontoBase.Visible = False
                fArticulo = False
                dtGridViewBultos.Visible = True
                dtGridViewArticulo.Visible = False
                lbArticulos.Text = "( F11 ) ARTICULOS"
                dtGridViewBultos.Focus()
                fnControlArticulo_Peso()

                txtTotalSobre.Visible = False
                txtCantidadSobres.Visible = False
                checkSobres.Visible = False
                txtCantidadSobres.Text = 0
                txtPorcernt_Descuento.Enabled = True
                If Val(txtPorcernt_Descuento.Text.Trim) > 0 Then
                    txtMemo.Enabled = True
                End If

                'fnArticulo_Peso()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub fnControlArticulo_Peso()
        Try

            Dim i As Integer = 0
            For i = 0 To 3
                dtGridViewBultos(2, i).Value() = ""
                dtGridViewBultos(3, i).Value() = ""
                dtGridViewBultos(4, i).Value() = "0.00"
            Next

            For i = 0 To dtGridViewArticulo.Rows.Count
                dtGridViewArticulo(5, i).Value() = "0.00"
                dtGridViewArticulo(4, i).Value() = ""
                dtGridViewArticulo(3, i).Value() = ""
            Next

            Me.txtSub_Total.Text = "0.00"
            Me.txtMonto_IGV.Text = "0.00"
            Me.txtCosto_Total.Text = "0.00"
            Me.Update()
        Catch ex As Exception
            Me.txtSub_Total.Text = "0.00"
            Me.txtMonto_IGV.Text = "0.00"
            Me.txtCosto_Total.Text = "0.00"
            Me.Update()
        End Try
    End Sub
    Private Sub fnArticulo_Peso()
        Try
            Dim i As Integer = 0
            For i = 0 To 2
                dtGridViewBultos(2, i).Value() = ""
                dtGridViewBultos(3, i).Value() = ""
                dtGridViewBultos(4, i).Value() = "0.00"
            Next
            For i = 1 To dtGridViewArticulo.Rows.Count
                dtGridViewArticulo.Rows().RemoveAt(0)
            Next
            txtSub_Total.Text = "0.00"
            txtMonto_IGV.Text = "0.00"
            txtCosto_Total.Text = "0.00"
            Me.Update()
        Catch ex As Exception
            Me.txtSub_Total.Text = "0.00"
            Me.txtMonto_IGV.Text = "0.00"
            Me.txtCosto_Total.Text = "0.00"
            Me.Update()
        End Try
    End Sub

    Private Sub DataGridViewDocumentos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewDocumentos.CellEndEdit
        Try
            Dim row As Short = e.RowIndex
            Dim col As Short = e.ColumnIndex
            Dim serie_NroDoc() As String = Split(DataGridViewDocumentos(col, row).Value.ToString, "-")
            Dim serie As String = ""
            Dim NroDoc As String = ""
            If serie_NroDoc(0).Length > 0 Then
                serie = RellenoRight(iDigitosSerie, Trim(serie_NroDoc(0)))
            End If
            If serie_NroDoc.Length >= 2 Then
                If serie_NroDoc(1).Length > 0 Then
                    NroDoc = RellenoRight(iDigitosDcoumento + 1, Trim(serie_NroDoc(1)))
                End If
            End If
            DataGridViewDocumentos(col, row).Value = serie & "-" & NroDoc
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub checkSobres_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkSobres.CheckedChanged
        Try
            Try
                If checkSobres.Checked = True Then
                    txtCantidadSobres.Visible = True
                    txtCantidadSobres.Focus()
                    txtCantidadSobres.SelectAll()
                Else
                    txtCantidadSobres.Visible = False
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub txtCantidadSobres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidadSobres.TextChanged
        Try
            If recuperando_datos_contado = False Then
                Total_Pagar()
            End If
        Catch ex As Exception
            txtSub_Total.Text = "0.00"
            txtMonto_IGV.Text = "0.00"
            txtCosto_Total.Text = "0.00"
        End Try
    End Sub

    Private Sub checkSobres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkSobres.Click
        Try
            If checkSobres.Checked = True Then
                fnTarifario()
                txtCantidadSobres.Visible = True
                objGuiaEnvio.iCANTIDAD_SOBRES = Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                objGuiaEnvio.iIDSINO_SOBRES = 1
                txtTotalSobre.Visible = True
                Total_Pagar()
            Else

                txtCantidadSobres.Visible = False
                objGuiaEnvio.iCANTIDAD_SOBRES = 0
                objGuiaEnvio.iIDSINO_SOBRES = 0
                txtTotalSobre.Visible = True
                txtTotalSobre.Text = "0.00"
                txtCantidadSobres.Text = "0"
                Total_Pagar()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Function Total_Pagar() As Boolean
        Try
            Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            'txtSubTotal.Text = Format(dtGridViewBultos(4, 0).Value + dtGridViewBultos(4, 1).Value + dtGridViewBultos(4, 2).Value, "######.000")
            Dim Costo_Peso As Double = CDbl(dtGridViewBultos(4, 0).Value.ToString)
            Dim Costo_Volumen As Double = CDbl(dtGridViewBultos(4, 1).Value.ToString)
            'Dim Costo_Articulo As Double = CDbl(dtGridViewBultos(4, 2).Value.ToString)
            '  Dim Monto_Base As Double = objGuiaEnvio.dMONTO_BASE  'CDbl(dtGridViewBultos(4, 2).Value.ToString)

            Dim ivol As Double = 0
            If dtGridViewBultos(2, 1).Value <> Nothing And dtGridViewBultos(3, 1).Value <> Nothing Then
                ivol = Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(2, 1).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(3, 1).Value.ToString)
            End If

            Dim ipes As Double = 0
            If dtGridViewBultos(2, 0).Value <> Nothing And dtGridViewBultos(3, 0).Value <> Nothing Then
                ipes = Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(2, 0).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(3, 0).Value.ToString)
            End If
            'Dim ivol As Double = CDbl(dtGridViewBultos(2, 1).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(3, 1).Value.ToString)
            'Dim ipes As Double = CDbl(dtGridViewBultos(2, 0).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(3, 0).Value.ToString)

            If ivol > 0 Then
                'Costo_Volumen = Costo_Volumen + Monto_Base
                Costo_Volumen = Costo_Volumen
            Else
                Costo_Volumen = 0
            End If

            If ipes = 0 Then
                Costo_Peso = 0
            End If

            Dim c__var As Integer = 1
            Dim Monto_Sobre As Double = 0
            If c__var Then
                Monto_Sobre = tarifa_Sobre * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                txtTotalSobre.Visible = True
                txtTotalSobre.Text = Format(Monto_Sobre, "####,###,###.00")
            Else
                txtTotalSobre.Visible = False
                Monto_Sobre = 0
                txtTotalSobre.Text = "0.00"
            End If

            If ivol > 0 And ipes >= 0 Then
                txtSub_Total.Text = Format(Monto_Sobre + Costo_Peso + Costo_Volumen + Monto_Base, "####,###,###.00")
                txtMonto_IGV.Text = Format((IGV) * (Monto_Sobre + Costo_Peso + Costo_Volumen + Monto_Base), "####,###,###.00")
                txtCosto_Total.Text = Format((1 + IGV) * (Monto_Sobre + Costo_Peso + Costo_Volumen + Monto_Base), "####,###,###.00")

            ElseIf ipes > 0 And ivol >= 0 Then

                txtSub_Total.Text = Format(Monto_Sobre + Costo_Peso + Monto_Base, "####,###,###.00")
                txtMonto_IGV.Text = Format((IGV) * (Monto_Sobre + Costo_Peso + Monto_Base), "####,###,###.00")
                txtCosto_Total.Text = Format((1 + IGV) * (Monto_Sobre + Costo_Peso + Monto_Base), "####,###,###.00")

            ElseIf ipes = 0 And ivol = 0 Then
                Dim Total_Articulo As Double = 0
                If fArticulo = True Then
                    'objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = 0
                    Dim ii1 As Integer = 0
                    For ii1 = 0 To dtGridViewArticulo.Rows().Count() - 1
                        Total_Articulo = Total_Articulo + Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(ii1).Cells(5).Value.ToString)
                        'objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString)
                    Next
                    ' Total_Articulo = Total_Articulo '+ Monto_Base * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                    If Total_Articulo > 0 Then
                        txtSub_Total.Text = Format(Monto_Base + Monto_Sobre + Total_Articulo, "####,###,###.00")
                        txtMonto_IGV.Text = Format((IGV) * (Monto_Base + Monto_Sobre + Total_Articulo), "####,###,###.00")
                        txtCosto_Total.Text = Format((1 + IGV) * (Monto_Base + Monto_Sobre + Total_Articulo), "####,###,###.00")
                    Else
                        txtSub_Total.Text = Format(Monto_Sobre, "####,###,###.00")
                        txtMonto_IGV.Text = Format((IGV) * (Monto_Sobre), "####,###,###.00")
                        txtCosto_Total.Text = Format((1 + IGV) * (Monto_Sobre), "####,###,###.00")
                    End If
                Else
                    txtSub_Total.Text = Format(Monto_Sobre, "####,###,###.00")
                    txtMonto_IGV.Text = Format((IGV) * (Monto_Sobre), "####,###,###.00")
                    txtCosto_Total.Text = Format((1 + IGV) * (Monto_Sobre), "####,###,###.00")
                End If
            Else
                txtSub_Total.Text = "0.00"
                txtMonto_IGV.Text = "0.00"
                txtCosto_Total.Text = "0.00"
            End If
            Dim SUB_TOTAL_GENERAL As Double = 0
            'Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            Dim SubTotal_Costo As Double = txtSub_Total.Text
            If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) > 0 Then
                SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.0000")) '01/09/2010 
            Else
                If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If
            txtSub_Total.Text = Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            txtMonto_IGV.Text = Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            txtCosto_Total.Text = Format(SUB_TOTAL_GENERAL, "###,###,###.00")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            txtTotalSobre.Text = "0.00"
        End Try
        Return False
    End Function
    Private Sub btnPCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPCE.Click
        Try
            flagPCE = False
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            '  Dim v_idFacura As Integer = dtGridViewControl_FACBOL.Rows(row).Cells(2).Value
            ' Modificado 27/09/2007 - Omendoza
            'Dim v_idFacura As String = dtGridViewControl_FACBOL.Rows(row).Cells(2).Value 
            Dim v_idFacura As String = CType(dtGridViewControl_FACBOL.Rows(row).Cells("FAC_BOL").Value, String)
            '
            'Dim v_Nro As Integer = dtGridViewControl_FACBOL.Rows(row).Cells(2).Value

            If ObjVentaCargaContado.fnSP_VALIDAR_GUIAPCE(v_idFacura) = True Then
                iPce = 0
                flagPCE = True
                flagPCEVALIDADOC = True
                '04/10/2007 - Por defecto se hace visible el dgv 
                Me.dtGridViewBultos.Visible = True
                ' 
                recuperando_datos_contado = True
                fnControlDatos(1)
                txtFecha.Text = dtoUSUARIOS.m_sFecha
                txtDireccionRemitente.Focus()
                ObjVentaCargaContado.V_CONTROL_PCE = True
                '04/10/2007 -> Recupera la agencia que hace el pago 
                Me.cmbAgenciaVenta.Text = dtoUSUARIOS.m_iNombreAgencia
                '
            ElseIf dtGridViewControl_FACBOL.Rows(row).Cells("idprocesos").Value = 6 And _
            dtGridViewControl_FACBOL.Rows(row).Cells("idtipo_comprobante").Value = "85" Then
                flagPCE = True
                flagPCEVALIDADOC = True
                iPce = 1
                '04/10/2007 - Por defecto se hace visible el dgv 
                Me.dtGridViewBultos.Visible = True
                ' 
                recuperando_datos_contado = True
                fnControlDatos(1)
                txtFecha.Text = dtoUSUARIOS.m_sFecha
                txtDireccionRemitente.Focus()
                ObjVentaCargaContado.V_CONTROL_PCE = True
                '04/10/2007 -> Recupera la agencia que hace el pago 
                Me.cmbAgenciaVenta.Text = dtoUSUARIOS.m_iNombreAgencia
            Else
                MsgBox("No esta Permitido esta Operacion para este Documento...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If

        Catch ex As Exception
            MsgBox("No Puede Realizar esta Operacion...", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnVerData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerData.Click
        Try
            'dtGridViewBultos.Enabled = False
            dtGridViewArticulo.Enabled = False
            DataGridViewDocumentos.Enabled = False
            limpiar_documentos_cliente()
            ObjVentaCargaContado.V_CONTROL_PCE = False
            flagPCE = False
            '04/10/2007 - Por defecto se hace visible el dgv 
            Me.dtGridViewBultos.Visible = True
            '
            recuperando_datos_contado = True

            fnControlDatos(2)

        Catch ex As Exception
        End Try
    End Sub
    Public Function fnControlDatos(ByVal var As Integer) As Boolean
        Try
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return False
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return False
            End If
            'Dim v_idFacura As Integer = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            Dim v_idFacura As Long = dtGridViewControl_FACBOL.Rows(row).Cells("idfactura").Value
            iIdFactura = v_idFacura
            If ObjVentaCargaContado.fnVERDATA_IV(v_idFacura) = True Then
                SelectMenu(1)
                fnVERDATOSVENTACONTADO(var)
                'If var <> 1 Then
                ' ObjVentaCargaContado.fnClearOBJ(var)
                'End If
            Else
                MsgBox("No puede cargar esta data, faltan datos...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            txtNroGuia.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        fnControlOperaciones()
    End Sub
    Private Sub fnControlOperaciones()
        Dim valor1 As Double, valor2 As Double
        Try
            'hlamas 06-08-2010 carga acompañada
            Me.TxtBoleto.Visible = True
            Me.LblBoleto.Visible = True

            Me.ChkAcompaña.Visible = False
            Me.ChkAcompaña.Checked = False

            Dim varID As Integer = ObjVentaCargaContado.coll_t_Forma_Pago(cmbFormaPago.SelectedIndex.ToString)
            iForma = varID
            If varID = 4 Then
                Me.ChkAcompaña.Checked = True
                varID = 3
            ElseIf varID = 3 Then
                Me.TxtBoleto.Text = ""
                'Me.TxtBoleto.Visible = False
                'Me.LblBoleto.Visible = False
                bCargaAcompañada = False
                Me.LblBoleto.Visible = False
                Me.TxtBoleto.Visible = False
                Me.ChkAcompaña.Checked = False
            Else
                Me.ChkAcompaña.Checked = False
            End If

            cmbTipoPago.Enabled = True

            If varIdCondicion = 2 Then
                cmbTargeta.Visible = True
                txtNroTarjeta.Visible = True
                lbTargeta.Visible = True
            End If

            If varID = 3 Then
                'hlamas 06-08-2010 carga acompañada
                If Not recuperando_datos_contado Then
                    Me.TxtBoleto.Text = ""
                    'Me.TxtBoleto.Visible = False
                    'Me.LblBoleto.Visible = False
                    bCargaAcompañada = False
                    'Me.ChkAcompaña.Visible = True
                Else
                    Me.TxtBoleto.Visible = True
                    Me.LblBoleto.Visible = True
                    Me.ChkAcompaña.Visible = False
                End If
                '
                Descubrir_contacto()
                '
                lbNombresRasonSocial.Text = "CLIENTE"
                lbFacturador.Text = "FACTURAR A :"
                txtNroGuia.Text = ""

                txtNroGuia.Visible = True
                txtNroGuia.Enabled = True

                txtSERIE.Visible = False
                txtSERIE.Text = "000"
                txtNroDocFACBOL.Visible = False


                If ObjVentaCargaContado.fnNroDocuemnto(3, Me.ChkProceso.Checked) = True Then
                    txtNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                    txtNroGuia.SelectAll()
                    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroGuia.Text
                    valor1 = Val(dtGridViewBultos(4, 0).Value)
                    valor2 = Val(dtGridViewBultos(2, 0).Value)
                    fnCalcularCosto(0, valor1, valor2)
                ElseIf ObjVentaCargaContado.fnNroDocuemnto(3, 0) = True Then
                    txtNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                    txtNroGuia.SelectAll()
                    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroGuia.Text
                    valor1 = Val(dtGridViewBultos(4, 0).Value)
                    valor2 = Val(dtGridViewBultos(2, 0).Value)
                    fnCalcularCosto(0, valor1, valor2)
                Else
                    MsgBox("No podra Realizar esta Operacion. El Nro de Guia Envio no esta configurado.")
                End If

                If iForma = 3 Then
                    lbFactBoleta.Text = "GUIA DE ENVIO PCE"
                Else
                    lbFactBoleta.Text = "GUIA ENVIO RECOJO"
                End If
                If es_carga_asegurada Then
                    lblCarga.Visible = True
                Else
                    lblCarga.Visible = False
                End If

                'hlamas 08-10-2010 carga acompañada
                If bCargaAcompañada Then
                    lblCarga.Text = "--> CARGA ACOMPAÑADA"
                    lblCarga.Visible = True
                Else
                    lblCarga.Text = "--> CARGA ASEGURADA"
                    lblCarga.Visible = False
                End If


                cmbTipoPago.Enabled = False
                cmbTargeta.Visible = False
                txtNroTarjeta.Visible = False
                lbTargeta.Visible = False

                txtContactoRemitente.Text = ""
                txtDNIContacto.Text = ""

            Else
                Try
                    Me.TxtBoleto.Text = ""
                    'Me.TxtBoleto.Visible = False
                    'Me.LblBoleto.Visible = False
                    bCargaAcompañada = False
                    'Me.ChkAcompaña.Visible = True

                    bMontoMinimo = False
                    If Int(ObjVentaCargaContado.v_NRO_GUIA) > 0 And (varID <> 3 Or varID <> 85) Then
                        lbNombresRasonSocial.Text = "FACTURAR A"
                        lbFacturador.Text = "CLIENTE "
                    Else
                        If Len(txtDocCliente_Remitente.Text) = 11 Then '07/12/2009 - Tiene que ver con el ruc, visualiza el contacto 
                            Descubrir_contacto()
                            lbNombresRasonSocial.Text = "CLIENTE-REMI"
                            lbFacturador.Text = "Contacto"
                            lbConsignado.Text = "Consig (F4)"
                        Else
                            ocultar_contacto()
                        End If
                        '
                        'lbNombresRasonSocial.Text = "CLIENTE-REMI"
                        'lbFacturador.Text = "Contacto"
                        'lbConsignado.Text = "Consig (F4)"
                    End If
                Catch ex As Exception
                    If Len(txtDocCliente_Remitente.Text) = 11 Then '07/12/2009 - Tiene que ver con el ruc, visualiza el contacto 
                        Descubrir_contacto()
                        Me.Grp_factura.Text = "Contacto "
                    Else
                        ocultar_contacto()
                    End If

                    'lbNombresRasonSocial.Text = "CLIENTE-REMI"
                    'lbFacturador.Text = "Contacto"
                    'lbConsignado.Text = "Consig (F4)"
                End Try


                txtNroGuia.Text = "NULL"
                txtNroGuia.Visible = False

                txtNroDocFACBOL.Visible = True
                txtSERIE.Visible = True
                'lbFactBoleta.Text = "BOLETA VENTA"
                'bFAC_Bol = False
                'TipoComprobante = 2
                'If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante,ChkProceso.Checked) = True Then
                '    txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                '    txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                'Else
                '    MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
                'End If
                If txtDocCliente_Remitente.Text.Length = 11 Then
                    If fnValidarRUC(txtDocCliente_Remitente.Text.ToString) Then
                        lbFactBoleta.Text = "FACTURA"
                        If es_carga_asegurada Then
                            lblCarga.Visible = True
                        Else
                            lblCarga.Visible = False
                        End If

                        'hlamas 08-10-2010 carga acompañada
                        If bCargaAcompañada Then
                            lblCarga.Text = "--> CARGA ACOMPAÑADA"
                            lblCarga.Visible = True
                        Else
                            lblCarga.Text = "--> CARGA ASEGURADA"
                            lblCarga.Visible = False
                        End If


                        bFAC_Bol = True
                        TipoComprobante = 1
                        'fnTarifario()
                        If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, ChkProceso.Checked) = True Then
                            txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)

                            valor1 = Val(dtGridViewBultos(4, 0).Value)
                            valor2 = Val(dtGridViewBultos(2, 0).Value)
                            fnCalcularCosto(0, valor1, valor2)
                        ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0) = True Then
                            txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)

                            valor1 = Val(dtGridViewBultos(4, 0).Value)
                            valor2 = Val(dtGridViewBultos(2, 0).Value)
                            fnCalcularCosto(0, valor1, valor2)
                        Else
                            MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
                        End If
                    Else
                        'MsgBox("El Valor del Nro de RUC es Invalido para la SUNAT, Revice su Nro de RUC", MsgBoxStyle.Information, "Seguridad Sistema")
                        ' fnTarifario()
                        lbFactBoleta.Text = "BOLETA VENTA"
                        If es_carga_asegurada Then
                            lblCarga.Visible = True
                        Else
                            lblCarga.Visible = False
                        End If

                        'hlamas 08-10-2010 carga acompañada
                        If bCargaAcompañada Then
                            lblCarga.Text = "--> CARGA ACOMPAÑADA"
                            lblCarga.Visible = True
                        Else
                            lblCarga.Text = "--> CARGA ASEGURADA"
                            lblCarga.Visible = False
                        End If


                        bFAC_Bol = False
                        txtDocCliente_Remitente.SelectAll()
                        txtDocCliente_Remitente.Focus()
                        TipoComprobante = 2
                        If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, ChkProceso.Checked) = True Then
                            txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                            valor1 = Val(dtGridViewBultos(4, 0).Value)
                            valor2 = Val(dtGridViewBultos(2, 0).Value)
                            fnCalcularCosto(0, valor1, valor2)
                        ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0) = True Then
                            txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                            valor1 = Val(dtGridViewBultos(4, 0).Value)
                            valor2 = Val(dtGridViewBultos(2, 0).Value)
                            fnCalcularCosto(0, valor1, valor2)
                        Else
                            MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
                        End If
                    End If
                Else
                    ' fnTarifario()
                    lbFactBoleta.Text = "BOLETA VENTA"
                    If es_carga_asegurada Then
                        lblCarga.Visible = True
                    Else
                        lblCarga.Visible = False
                    End If

                    'hlamas 08-10-2010 carga acompañada
                    If bCargaAcompañada Then
                        lblCarga.Text = "--> CARGA ACOMPAÑADA"
                        lblCarga.Visible = True
                    Else
                        lblCarga.Text = "--> CARGA ASEGURADA"
                        lblCarga.Visible = False
                    End If


                    bFAC_Bol = False
                    txtDocCliente_Remitente.SelectAll()
                    txtDocCliente_Remitente.Focus()
                    TipoComprobante = 2
                    If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, ChkProceso.Checked) = True Then
                        txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                        txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)

                        valor1 = Val(dtGridViewBultos(4, 0).Value)
                        valor2 = Val(dtGridViewBultos(2, 0).Value)
                        fnCalcularCosto(0, valor1, valor2)
                    ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0) = True Then
                        txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                        txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)

                        valor1 = Val(dtGridViewBultos(4, 0).Value)
                        valor2 = Val(dtGridViewBultos(2, 0).Value)
                        fnCalcularCosto(0, valor1, valor2)
                    Else
                        MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
                    End If
                End If
            End If
                ' 04/03/2009 
                If b_no_lee_tipo_entrega = True Then
                    cambio_tipo_entrega(varID)
                End If
                '
        Catch ex As Exception
            If Len(txtDocCliente_Remitente.Text) = 11 Then '07/12/2009 - Tiene que ver con el ruc, visualiza el contacto 
                Descubrir_contacto()
                Me.Grp_factura.Text = "Contacto "
                lbNombresRasonSocial.Text = "CLIENTE-REMI"
                lbFacturador.Text = "Contacto"
                lbConsignado.Text = "Consig (F4)"
            Else
                ocultar_contacto()
            End If
            'lbNombresRasonSocial.Text = "CLIENTE-REMI"
            'lbFacturador.Text = "Contacto"
            'lbConsignado.Text = "Consig (F4)"
        End Try
    End Sub

    Private Sub txtDNIContacto_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDNIContacto.Validating
        Try
            If flagPCEVALIDADOC = False Then
                If ObjVentaCargaContado.fnSP_BUSCAR_PERSONACONTACTOS(txtDNIContacto.Text.Trim) = True Then

                    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = ObjVentaCargaContado.v_IDNOMBRES_CONTROL
                    ObjVentaCargaContado.v_NOMBRES_REMITENTE = ObjVentaCargaContado.v_NOMBRES_CONTROL
                    ObjVentaCargaContado.v_NRO_DOC_REMITENTE = ObjVentaCargaContado.v_DNI_CONTROL
                    txtContactoRemitente.Text = ObjVentaCargaContado.v_NOMBRES_CONTROL
                    Me.txtDNIContacto.Tag = ObjVentaCargaContado.v_TIPO_DOCUMENTO
                    ' txtTelefonoRemitente.Focus()   --> 01/12/2009
                    'txtContactoRemitente.Focus()
                    'txtContactoRemitente.SelectAll()
                Else
                    Me.txtDNIContacto.Tag = ""
                    'txtDocCliente_Remitente.Text = ""
                    'if txtContactoRemitente.Text 
                    ' txtContactoRemitente.Text = ""
                    '       txtTelefonoRemitente.Focus() --> 01/12/2009
                    'txtDireccionRemitente.Text = ""
                End If
                ' valorf3 = True
            End If
        Catch ex As Exception
            '
        End Try

    End Sub

    'Private Sub txtDNIDestinatario_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDNIDestinatario.Validating
    '    Try
    '        If flagPCEVALIDADOC = False Then
    '            If ObjVentaCargaContado.fnSP_BUSCAR_PERSONACONTACTOS(txtDNIDestinatario.Text) = True Then

    '                ObjVentaCargaContado.v_IDCONTACTO_DESTINO = ObjVentaCargaContado.v_IDNOMBRES_CONTROL
    '                ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = ObjVentaCargaContado.v_NOMBRES_CONTROL
    '                ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO = ObjVentaCargaContado.v_DNI_CONTROL

    '                txtCliente_Destinatario.Text = ObjVentaCargaContado.v_NOMBRES_CONTROL

    '                txtCliente_Destinatario.Focus()
    '                txtCliente_Destinatario.SelectAll()
    '            Else
    '                'txtDocCliente_Remitente.Text = ""
    '                txtCliente_Destinatario.Text = ""
    '                txtCliente_Destinatario.Focus()
    '                'ObjVentaCargaContado.v_NOMBRES_DESTINATARIO()
    '                'ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO()
    '                ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0
    '                'txtDireccionRemitente.Text = ""
    '            End If
    '            ' valorf3 = True
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub ControlDescuentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDescuentosToolStripMenuItem.Click
        Try
            'If fnValidar_Rol("11") = True Or fnValidar_Rol("12") = True Or fnValidar_Rol("7") = True Or fnValidar_Rol("1") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 5) Then
                If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                    MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                    Return
                End If
                Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
                If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                    MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                    Return
                End If
                Dim v_idFacura As Integer = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
                ObjControlDescuento.v_IDFACTURA = v_idFacura

                Dim ObjGenerarDescuentoVenta As New FrmGenerarDescuentoVenta
                'ObjGenerarDescuentoVenta.ShowDialog()

                Acceso.Asignar(ObjGenerarDescuentoVenta, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    ObjGenerarDescuentoVenta.ShowDialog()
                Else
                    MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                ObjGenerarDescuentoVenta = Nothing
            Else
                MsgBox("Usted No Tiene Acceso...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If

            'End If
        Catch ex As Exception
            MsgBox("revizar datos....", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub CambiarPCEFISCALIZACIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarPCEFISCALIZACIONToolStripMenuItem.Click
        Try
            'Control 
            'If fnValidar_Rol("24") = True Or fnValidar_Rol("1") = True Or fnValidar_Rol("26") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 6) Then
                If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                    MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                    Return
                End If
                Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
                If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                    MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                    Return
                End If
                Dim v_idFacura As Integer = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
                ObjControlDescuento.v_IDFACTURA = v_idFacura


            Else
                MsgBox("Usted No Tiene Acceso...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If

            'End If
        Catch ex As Exception
            MsgBox("revisar datos....", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub txtDocCliente_Remitente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDocCliente_Remitente.Leave
        Try
            If txtDocCliente_Remitente.Text.Trim = sDocCliente.Trim Or (flagPCE) Then Exit Sub
            If bBoleto Then
                If Not bValida Then
                    Return
                End If
            End If

            txtSub_Total.Text = ""
            txtMonto_IGV.Text = ""
            txtCosto_Total.Text = ""
            If txtDocCliente_Remitente.Text <> "" Then
                CONTROL = 2
                If flagPCEVALIDADOC = False Then
                    objGuiaEnvio.iIDPERSONA = 0
                    If fnBuscarCliente() = True Then
                        'If b_lee = True Then
                        '    txtCliente_Destinatario.Focus()
                        '    txtCliente_Destinatario.SelectAll()
                        'End If
                    Else
                        Me.txtCliente_Remitente.Text = ""
                    End If
                End If
            End If

            'If txtDocCliente_Remitente.Text.Trim <> sDocCliente.Trim Then
            If dtGridViewArticulo.Visible Then
                fArticulo = False
                dtGridViewBultos.Visible = True
                dtGridViewArticulo.Visible = False
                lbArticulos.Text = "( F11 ) ARTICULOS"
                dtGridViewBultos.Focus()
                'fnControlArticulo_Peso()

                txtTotalSobre.Visible = False
                txtCantidadSobres.Visible = False
                checkSobres.Visible = False
                txtCantidadSobres.Text = 0
            End If
            'End If
        Catch ex As Exception
            '
        End Try
        If Len(txtDocCliente_Remitente.Text) = 11 Then '07/12/2009 - Tiene que ver con el ruc, visualiza el contacto 
            Descubrir_contacto()
            Me.Grp_factura.Text = "Contacto "
            lbNombresRasonSocial.Text = "CLIENTE-REMI"
            lbFacturador.Text = "Contacto"
            lbConsignado.Text = "Consig (F4)"
        Else
            'If Me.cmbFormaPago.Text <> "PAGO CONTRA ENTREGA" Then  'Por la definición de la forma de pago
            If Me.cmbFormaPago.SelectedIndex = 0 Then
                ocultar_contacto()
            End If
        End If
        '
        'Descubrir_contacto()
        '


        'Try
        '    If txtDocCliente_Remitente.Text <> "" Then
        '        CONTROL = 2
        '        If flagPCEVALIDADOC = False Then
        '            objGuiaEnvio.iIDPERSONA = 0
        '            If fnBuscarCliente() = True Then
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Private Sub txtContactoRemitente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContactoRemitente.Leave
        Try
            Dim indexof As Integer = 0
            If b_lee = True Then
                'txtDNIContacto.Text = "" -- Comentado 01/12/2009 - 
                indexof = IIf(iWinContacto_Remitente.IndexOf(txtContactoRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtContactoRemitente.Text), -1)
                ObjVentaCargaContado.v_IDPERSONA_ORIGEN = -1
                If indexof >= 0 Then
                    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = Int(coll_Nombres_Remitente(indexof.ToString))
                    If indexof <= iWinPerosaDNI_Remite.Count Then
                        If txtDNIContacto.Text = "" Then
                            txtDNIContacto.Text = iWinPerosaDNI_Remite.Item(indexof)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            '
        End Try
    End Sub
    Private Sub txtCliente_Destinatario_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente_Destinatario.Leave
        Try
            If b_lee = True Then
                Dim indexof As Integer = 0
                indexof = IIf(iWinContacto_Destinatario.IndexOf(txtCliente_Destinatario.Text) >= 0, iWinContacto_Destinatario.IndexOf(txtCliente_Destinatario.Text), -1)
                ObjVentaCargaContado.v_IDCONTACTO_DESTINO = -1
                If indexof >= 0 Then
                    ObjVentaCargaContado.v_IDCONTACTO_DESTINO = Int(coll_Nombres_Destinatario(indexof.ToString))
                    If indexof <= iWinPerosaDNI_Destino.Count Then
                        If txtDNIDestinatario.Text = "" Then ' Se agregado la línea de registro 
                            txtDNIDestinatario.Text = iWinPerosaDNI_Destino.Item(indexof)
                        End If
                    End If
                Else
                    'txtDNIDestinatario.Text = ""  01/12/2009 - 
                End If
            End If
        Catch ex As Exception
            '
        End Try
    End Sub
    Private Sub dtGridViewBultos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtGridViewBultos.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtCliente_Remitente_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCliente_Remitente.Validating
        Try
            Dim b_flag As Boolean = False
            '
            If s_persona_remitente <> Me.txtCliente_Remitente.Text And s_persona_remitente <> "" And flagPCE = False Then
                MsgBox("El remitente existe con otro nombre, Desea actualizar los datos presione F6", MsgBoxStyle.Information, "Sistema de Seguridad")
                b_flag = True
                Me.txtCliente_Remitente.Text = s_persona_remitente
            End If
            e.Cancel = b_flag
            '
        Catch ex As Exception
            '
        End Try
    End Sub
#Region "Actualiza datos"
    Private Sub ActualizaDocumentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizaDocumentoToolStripMenuItem.Click
        Dim flag As Boolean = False
        Dim dgrv0 As DataGridViewRow
        Dim ls_documento As String
        Dim ls_tipo_comprobante As String
        Try
            'Rol (24) Fiscalización
            'If fnValidar_Rol("24") Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 7) Then
                flag = True
            End If
            If flag = False Then
                MsgBox("Usted no tiene Acceso", MsgBoxStyle.Information, "Seguridad Sistema")
                Exit Sub
            End If
            '
            If Me.dtGridViewControl_FACBOL.Rows.Count < 1 Then
                MsgBox("No se encontro ningún registro", MsgBoxStyle.Information, "Sistema Venta Contado")
                Exit Sub
            End If
            ' 
            dgrv0 = Me.dtGridViewControl_FACBOL.CurrentRow()
            ls_tipo_comprobante = CType(dgrv0.Cells("tipo_comprobante").Value, String)
            ls_documento = CType(dgrv0.Cells("FAC_BOL").Value, String)
            Dim resp As DialogResult = MessageBox.Show("Está seguro(a) de actualizar el(la) " & ls_tipo_comprobante & " Nº documento " & ls_documento & " ? ", "Seguridad del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = Windows.Forms.DialogResult.Yes Then
                ' 
                'Actualiza los datos para venta al contado 
                '
                Dim a As New frm_actualiza_venta_contado
                a.ps_tipo_venta = "C"
                a.pl_idforma_pago = CType(dgrv0.Cells("Idforma_Pago").Value, Long)
                a.ps_idcomprobante = CType(dgrv0.Cells("idfactura").Value, String)
                a.pl_idtipo_comprobante = CType(dgrv0.Cells("Idtipo_Comprobante").Value, Long)
                a.pl_idunidad_agencia = CType(dgrv0.Cells("Idunidad_Destino").Value, Long)
                a.pl_idagencia_destino = CType(dgrv0.Cells("Idagencias_Destino").Value, Long)
                a.ps_razon_social = CType(dgrv0.Cells("razon_social").Value, String)
                a.pd_tot_costo = CType(dgrv0.Cells("Total_Costo").Value, Double)
                a.pd_monto_sub_total = CType(dgrv0.Cells("Monto_Sub_Total").Value, Double)
                a.pd_monto_impuesto = CType(dgrv0.Cells("Monto_Impuesto").Value, Double)
                a.ps_tipo_comprobante = CType(dgrv0.Cells("tipo_comprobante").Value, String)
                a.ps_documento = CType(dgrv0.Cells("FAC_BOL").Value, String)
                a.ps_agencia_origen = CType(dgrv0.Cells("Origen").Value, String)
                a.ps_fecha_documento = CType(dgrv0.Cells("fecha_documento").Value, String)
                '
                a.pl_idunidad_agencia_origen = CType(dgrv0.Cells("Idunidad_Origen").Value, Long)
                a.pl_idagencia_origen = CType(dgrv0.Cells("idagencia_origen").Value, Long)
                a.ps_documento_identidad = CType(dgrv0.Cells("DNI_RUC").Value, String)

                a.pl_proceso = CType(dgrv0.Cells("idprocesos").Value, Long)
                a.ps_boleto = CType(IIf(IsDBNull(dgrv0.Cells("nroboleto").Value), "", dgrv0.Cells("nroboleto").Value), String)
                a.pl_envio = CType(dgrv0.Cells("idEstado_envio").Value, Long)
                a.pl_doc = CType(dgrv0.Cells("idEstado_factura").Value, Long)
                '
                'a.ShowDialog()
                Acceso.Asignar(a, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    a.ShowDialog()
                Else
                    MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                If a.pb_cancela = False Then
                    'Recuperar los datos 
                    ' objControlFacturasBol.iControl = 1
                    fnBuscarFacturas()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
#End Region

    Private Sub CambiarPCEACréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarPCEACréditoToolStripMenuItem.Click
        Dim ll_rol_usuario As Long
        Dim flag As Boolean = False
        Dim dgrv0 As DataGridViewRow
        Dim ls_documento As String
        Dim ls_tipo_comprobante As String
        Dim ll_facturado As Long
        '
        Try
            ll_rol_usuario = dtoUSUARIOS.m_iIdRol
            'Rol (36) Servicio al cliente 
            'If fnValidar_Rol("36") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 8) Then
                dgrv0 = Me.dtGridViewControl_FACBOL.CurrentRow()
                'ls_tipo_comprobante = CType(dgrv0.Cells("tipo_comprobante").Value, String)
                ll_facturado = CType(dgrv0.Cells("Facturado").Value, Long)
                If ll_facturado = 1 Then
                    MsgBox("El PCE está facturado, no se puede cambiar a crédito", MsgBoxStyle.Information, "PCE a Crédito")
                    Exit Sub
                End If
                ls_tipo_comprobante = CType(dgrv0.Cells("tipo").Value, String)
                If ls_tipo_comprobante = "PCE" Then ' 85 Pce 
                    ls_documento = CType(dgrv0.Cells("FAC_BOL").Value, String)
                    Dim resp As DialogResult = MessageBox.Show("Está seguro(a) de actualizar la Guía de envío Nº  " & ls_documento & " ? ", "PCE a Crédito", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If resp = Windows.Forms.DialogResult.Yes Then
                        Dim lobj_pce_a_credito As New frm_pce_a_credito
                        lobj_pce_a_credito.pl_idfactura_contado = CType(dgrv0.Cells("idfactura").Value, String)
                        lobj_pce_a_credito.ps_nro_guia_envio = ls_documento
                        'lobj_pce_a_credito.ShowDialog()

                        Acceso.Asignar(lobj_pce_a_credito, Me.hnd)
                        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                            lobj_pce_a_credito.ShowDialog()
                        Else
                            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return
                        End If

                        ' Cancelar y refrescar
                        If lobj_pce_a_credito.pb_cancelar = False Then
                            fnBuscarFacturas()
                        End If
                    End If
                Else
                    MsgBox("El documento seleccionado no es PCE, no se puede cambiar a Crédito", MsgBoxStyle.Information, "PCE a Crédito")
                End If
            Else
                MsgBox("Usted no tiene Acceso a cambiar PCE a Guías Crédito, debe solicitarlo al servicio al cliente", MsgBoxStyle.Information, "PCE a Crédito")
            End If
            dtoUSUARIOS.m_iIdRol = ll_rol_usuario
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub AnularPCEPasadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularPCEPasadosToolStripMenuItem.Click
        '12/03/2008 - Evento nuevo Anular Pce Pasados
        Dim ll_rol_usuario As Long
        Dim flag As Boolean = False
        Dim dgrv0 As DataGridViewRow
        Dim ls_documento As String
        Dim ls_tipo_comprobante As String
        Dim ll_facturado As Long
        '
        Try
            ll_rol_usuario = dtoUSUARIOS.m_iIdRol
            'Todos tienen acceso 
            dgrv0 = Me.dtGridViewControl_FACBOL.CurrentRow()
            ls_tipo_comprobante = CType(dgrv0.Cells("tipo").Value, String)
            If ls_tipo_comprobante = "PCE" Then ' 85 Pce 
                ll_facturado = CType(dgrv0.Cells("Facturado").Value, Long)
                If ll_facturado = 1 Then
                    MsgBox("El PCE está facturado, no se puede anular", MsgBoxStyle.Information, "Anular Pce")
                    Exit Sub
                End If
                ls_documento = CType(dgrv0.Cells("FAC_BOL").Value, String)
                Dim resp As DialogResult = MessageBox.Show("Está seguro(a) de anular  la Guía de envío Nº  " & ls_documento & " ? ", "Anular PCE", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = Windows.Forms.DialogResult.Yes Then
                    Dim lobj_anular_pce As New frm_anular_pce
                    lobj_anular_pce.ps_idfactura_contado = CType(dgrv0.Cells("idfactura").Value, String)
                    lobj_anular_pce.ps_des_tipo_comprobante = CType(dgrv0.Cells("tipo_comprobante").Value, String)
                    'lobj_anular_pce.ShowDialog()

                    Acceso.Asignar(lobj_anular_pce, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        lobj_anular_pce.ShowDialog()
                        If lobj_anular_pce.pb_cancelar = False Then
                            fnBuscarFacturas()
                        End If
                    Else
                        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End If
            Else
                MsgBox("El documento seleccionado no es PCE, no se puede anular", MsgBoxStyle.Information, "PCE a Crédito")
            End If
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            '
            ErrorProvider.Dispose()
            '
            Dim var As Integer = msg.WParam.ToInt32
            ' 01/10/2007 - Se le agrago msg.WParam.ToInt32 = Keys.Tab en la primera condición 

            If MyClass.ModifierKeys And Keys.Control Then

                If msg.WParam.ToInt32 = Keys.F8 Then
                    If Me.btnSeguro.Enabled Then
                        Seguro()
                    End If
                    'If dtGridViewArticulo.Visible = False And flagPCE = False Then
                    '    Dim A As New FrmDocCliente

                    '    A.sFecha = txtFecha.Text
                    '    A.bVentaGrabada = recuperando_datos_contado
                    '    A.sDocCliente = sDocCliente
                    '    'A.ShowDialog()
                    '    Acceso.Asignar(A, Me.hnd)
                    '    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    '        A.ShowDialog()
                    '        agregar_documentos_asegurados()
                    '    Else
                    '        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    End If
                    'End If
                ElseIf msg.WParam.ToInt32 = Keys.V Then
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                End If
            ElseIf msg.WParam.ToInt32 = Keys.Enter Then
                If Me.dtGridViewBultos.Focused = True Then
                    'fnTarifario()
                    SendKeys.Send("{Tab}")
                ElseIf txtNroSerieDoc.Focused = True Then
                    objControlFacturasBol.iControl = 2
                    fnBuscarFacturas()
                ElseIf txtClienteDNIRUC.Focused = True Then
                    If txtClienteDNIRUC.Text <> "" Then
                        objControlFacturasBol.iControl = 3
                        fnBuscarFacturas()
                    Else
                        SendKeys.Send("{Tab}")
                    End If
                    '04/10/2007 <-> Se está colocando en el evento Leave del campo 
                ElseIf txtDocCliente_Remitente.Focused = True Then
                    'If txtDocCliente_Remitente.Text <> "" Then
                    '    CONTROL = 2
                    '    If flagPCEVALIDADOC = False Then
                    '        objGuiaEnvio.iIDPERSONA = 0
                    '        If fnBuscarCliente() = True Then
                    '            txtCliente_Destinatario.Focus()
                    '            txtCliente_Destinatario.SelectAll()
                    '        Else
                    '            SendKeys.Send("{Tab}")
                    '        End If
                    '    Else
                    '        SendKeys.Send("{Tab}")
                    '    End If
                    'Else
                    SendKeys.Send("{Tab}")
                    'End If
                    ''If BuscarClientesGuia_Envio() = True Then
                    ''    SendKeys.Send("{Tab}")
                    ''End If
                    '04/10/2007 <-> Se está colocando en el evento Leave del campo 
                ElseIf txtContactoRemitente.Focused = True Then
                    '    'MsgBox("Exe...")
                    '    Dim indexof As Integer = 0
                    '    txtDNIContacto.Text = ""
                    '    indexof = IIf(iWinContacto_Remitente.IndexOf(txtContactoRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtContactoRemitente.Text), -1)
                    '    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = -1
                    '    If indexof >= 0 Then
                    '        ObjVentaCargaContado.v_IDPERSONA_ORIGEN = Int(coll_Nombres_Remitente(indexof.ToString))
                    '        If indexof <= iWinPerosaDNI_Remite.Count Then
                    '            txtDNIContacto.Text = iWinPerosaDNI_Remite.Item(indexof)
                    '        End If
                    '    End If
                    SendKeys.Send("{Tab}")
                    '    '--------------------------------------------------------------------------
                    '04/10/2007 <-> Se está colocando en el evento Leave del campo 
                ElseIf txtCliente_Destinatario.Focused = True Then
                    '    'MsgBox("Exe...")
                    '    Dim indexof As Integer = 0
                    '    'txtDNIDestinatario.Text = ""
                    '    indexof = IIf(iWinContacto_Destinatario.IndexOf(txtCliente_Destinatario.Text) >= 0, iWinContacto_Destinatario.IndexOf(txtCliente_Destinatario.Text), -1)
                    '    ObjVentaCargaContado.v_IDCONTACTO_DESTINO = -1
                    '    If indexof >= 0 Then
                    '        ObjVentaCargaContado.v_IDCONTACTO_DESTINO = Int(coll_Nombres_Destinatario(indexof.ToString))
                    '        If indexof <= iWinPerosaDNI_Destino.Count Then
                    '            txtDNIDestinatario.Text = iWinPerosaDNI_Destino.Item(indexof)
                    '        End If
                    '    Else
                    '        txtDNIDestinatario.Text = ""
                    '    End If
                    SendKeys.Send("{Tab}")
                Else
                    SendKeys.Send("{Tab}")
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F1 Then
                cmbTipo_Entrega.Focus()

            ElseIf msg.WParam.ToInt32 = Keys.F2 Then
                txtDocCliente_Remitente.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.Escape Then
                If MsgBox("Esta Seguro que Quiere cancelar esta Operacion...?", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                    ObjVentaCargaContado.V_CONTROL_PCE = False
                    fnNUEVO()
                    limpiar_documentos_cliente()
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F3 Then
                If Me.btnNuevo.Enabled Then
                    If recuperando_datos_contado = False Then
                        fnNUEVO()
                        limpiar_documentos_cliente()
                        SelectMenu(1)
                    End If
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F4 Then
                txtCliente_Destinatario.Focus()
                txtCliente_Destinatario.SelectAll()

                'txtDNIDestinatario.Focus()
                'txtDNIDestinatario.SelectAll()

            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                If Me.btnGrabar.Enabled Then
                    Grabar()
                End If
                'If recuperando_datos_contado And flagPCE = False Then Exit Function
                'If TabMante.SelectedIndex = 0 Then
                '    SendKeys.Send("{Tab}")
                '    GoTo FINAL
                'End If

                'If control_venta = True Then
                '    fnNUEVO()
                '    limpiar_documentos_cliente()
                'End If

                'If Val(txtPorcernt_Descuento.Text) = 0 Then
                '    txtPorcernt_Descuento.Text = ""
                'End If

                'If TipoComprobante = 1 Then
                '    If txtDocCliente_Remitente.Text.ToString.Length = 11 Then
                '        If fnValidarRUC(txtDocCliente_Remitente.Text.ToString) = False Then
                '            MsgBox("No puede realizar esta Operacion de Factura, el Nro de Docuemnto es Invalido")
                '            Return False
                '        End If
                '    Else
                '        MsgBox("No puede realizar esta Operacion de Factura, el Nro de Docuemnto es Invalido", MsgBoxStyle.Information, "Seguriadad Sistema")
                '        Return False
                '    End If
                'End If

                'If txtCliente_Remitente.Text.Trim = "" Then
                '    MsgBox("No Puede Realizar esta Operacion no tiene Cliente remitente ...", MsgBoxStyle.Information, "Seguridad Sistema")
                '    txtCliente_Remitente.Text = ""
                '    txtCliente_Remitente.Focus()
                '    Return False
                'End If
                'If txtCliente_Destinatario.Text.Trim = "" Then
                '    MsgBox("No Puede Realizar esta Operacion no tiene Cliente Destinatario ...", MsgBoxStyle.Information, "Seguridad Sistema")
                '    txtCliente_Destinatario.Text = ""
                '    txtCliente_Destinatario.Focus()
                '    Return False
                'End If
                ''
                'If Me.txtTelefonoRemitente.Text = "" Or Len(Me.txtTelefonoRemitente.Text) < 7 Then
                '    ErrorProvider.SetError(Me.txtTelefonoRemitente, "Debe Ingresar el telefono del remitente es obligatorio o los digitos del teléfono son pocos...")
                '    Me.txtTelefonoRemitente.Focus()
                '    Return False
                'End If
                ''
                'Dim varDescuento As Integer = IIf(txtPorcernt_Descuento.Text <> "", txtPorcernt_Descuento.Text, 0)

                'If Val(txtCosto_Total.Text) <= 0 And varDescuento <> 100 Then
                '    MsgBox("No Puede Realizar esta Operacion no tiene monto afecto...,No Tiene el Descuento Apropiado", MsgBoxStyle.Information, "Seguridad Sistema")
                '    Return False
                'End If
                'Dim varIdFormaPago As Integer = Int(ObjVentaCargaContado.coll_t_Forma_Pago.Item(cmbFormaPago.SelectedIndex.ToString()))
                'If varIdFormaPago = 3 Then
                '    If txtContactoRemitente.Text = "" Then
                '        MsgBox("No puede Realizar esta Operacion, debe tener un nombre de Facturador... ", MsgBoxStyle.Information, "Seguridad Sistema")
                '        txtContactoRemitente.Focus()
                '        Return False
                '    End If
                'End If
                ''Confirmar 

                'If fnGrabar() = True Then
                '    'ObjVentaCargaContado.fnIncrementarNroDoc(TipoComprobante)
                '    'ObjVentaCargaContado.fnIncrementarNroDoc(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
                '    If ObjVentaCargaContado.fnNroDocuemnto(2) = True Then
                '        txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                '        txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)

                '        txtSERIE.Visible = True
                '        txtNroDocFACBOL.Visible = True

                '        txtNroGuia.Visible = False
                '        txtNroGuia.Text = ""
                '    Else
                '        MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
                '        Return False
                '    End If


                'End If
            ElseIf msg.WParam.ToInt32 = Keys.F7 Then
                dtGridViewBultos.Focus()
                dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(0).Cells(2)
                dtGridViewBultos.Rows(0).Cells(2).Selected = True

            ElseIf msg.WParam.ToInt32 = Keys.F6 Then
                If Me.btnClientes.Enabled Then
                    clientes()
                End If
                'If txtDocCliente_Remitente.Focused = True Or txtCliente_Remitente.Focused = True Then
                '    If txtCliente_Remitente.Text <> "" Then
                '        If fnMantenimienteCliente(1, txtDocCliente_Remitente, txtCliente_Remitente, txtDireccionRemitente, 1, 1) = True Then
                '        End If
                '    End If
                'End If

                'If txtContactoRemitente.Focused = True Or txtDNIContacto.Focused = True Then
                '    If txtContactoRemitente.Text <> "" Then
                '        If fnMantenimienteCliente(2, txtDNIContacto, txtContactoRemitente, txtDireccionRemitente, 1, 2) = True Then
                '        End If
                '    End If
                'End If
                'If txtCliente_Destinatario.Focused = True Or txtDNIDestinatario.Focused = True Then
                '    If txtCliente_Destinatario.Text <> "" Then
                '        If fnMantenimienteCliente(3, txtDNIDestinatario, txtCliente_Destinatario, txtDireccionDestinatario, 1, 2) = True Then

                '        End If
                '    End If
                'End If
                ''    txtCantidad_Peso.Focus()
                ''txtCantidad_Peso.SelectAll()

            ElseIf msg.WParam.ToInt32 = Keys.F8 Then
                txtPorcernt_Descuento.Focus()
                txtPorcernt_Descuento.SelectAll()
            ElseIf msg.WParam.ToInt32 = Keys.F9 Then
                'txtNroDocFACBOL.Focus()
                'txtNroDocFACBOL.SelectAll()
                txtNroGuia.Focus()
                txtNroGuia.SelectAll()
                'txtCosto_Total.Focus()
                'txtCosto_Total.SelectAll()
            ElseIf msg.WParam.ToInt32 = Keys.F10 Then
                txtiWinDestino.Focus()
                txtiWinDestino.SelectAll()
            ElseIf msg.WParam.ToInt32 = Keys.F11 Then
                If Me.btnArticulos.Enabled Then
                    fnControl_Articulos()
                End If

                'If dtGridViewArticulo.Visible = False Then
                '    dtGridViewArticulo.Visible = True
                '    dtGridViewArticulo.Focus()
                '    dtGridViewBultos.Visible = False
                'Else
                '    dtGridViewArticulo.Visible = False
                '    dtGridViewBultos.Visible = True
                'End If

                'cmbTipoPago.Focus()
                'cmbTipoPago.SelectAll()
            ElseIf msg.WParam.ToInt32 = Keys.F12 Then
                If MsgBox("Esta Seguro que quiere salir de ventas al contado ", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                    Close()
                End If
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
FINAL:
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function
    Public Function fnGrabar() As Boolean

        Dim flat As Boolean = False
        Try
            ObjVentaCargaContado.v_OTRAS_AGENCIAS = bOtrasAgencias

            If Val(iTotal_CA) > 0 Then
                ObjVentaCargaContado.v_SUB_TOTAL_CA = Format(iSub_Total_CA, "0.00")
                ObjVentaCargaContado.v_IMPUESTO_CA = Format(iImpuesto_CA, "0.00")
                ObjVentaCargaContado.v_TOTAL_CA = Format(iTotal_CA, "0.00")
            Else
                ObjVentaCargaContado.v_SUB_TOTAL_CA = 0
                ObjVentaCargaContado.v_IMPUESTO_CA = 0
                ObjVentaCargaContado.v_TOTAL_CA = 0
            End If
            '
            If ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = 0 Then
                ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
            End If

            If Val(txtPorcernt_Descuento.Text) > 0 Or Val(txtPorcernt_Descuento.Text) < 0 Then
                If Me.txtMemo.Text = "" Then
                    MsgBox("Debe tener autorizacion...", MsgBoxStyle.Information, "Seguridad Sistema")
                    ErrorProvider.SetError(txtMemo, "Escriba Nombre que Autoriza el Descuento....")
                    txtMemo.Focus()
                    txtMemo.SelectAll()
                    Return False
                End If
            End If

            If flagPCE = False Then
                If fnTarifario() = False Then
                    MsgBox("Error de Carga de Tarifa", MsgBoxStyle.Information, "Seguridad Sistema")
                    Return False
                End If
            End If
            If TipoComprobante = 1 Or TipoComprobante = 2 Or TipoComprobante = 3 Then
                ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = TipoComprobante
            Else
                MsgBox("Debe definir un Tipo de Comprobante...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return False
            End If

            'If txtDocCliente_Remitente.Text.Trim.Length = 0 Then
            'MsgBox("El Valor del Nro de Documento es Invalido para la SUNAT ", MsgBoxStyle.Information, "Seguridad Sistema")
            'Return False
            'End If

            'validar problemas hlamas
            If txtDocCliente_Remitente.Text.Trim.Length = 11 Then         'ruc
                If fnValidarRUC(txtDocCliente_Remitente.Text.ToString.Trim) Then
                    If lbFactBoleta.Text.Substring(0, 1) <> "F" And lbFactBoleta.Text.Substring(0, 1) <> "G" Then
                        MessageBox.Show("Se debe generar una Factura al Cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtDocCliente_Remitente.Focus()
                        Exit Function
                    End If
                Else
                    MessageBox.Show("R.U.C. no válido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtDocCliente_Remitente.Focus()
                    Exit Function
                End If
            ElseIf txtDocCliente_Remitente.Text.Trim.Length = 8 Then         'boleta
                If lbFactBoleta.Text.Substring(0, 1) <> "B" And lbFactBoleta.Text.Substring(0, 1) <> "G" Then
                    MessageBox.Show("Se debe generar una Boleta de Venta al Cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtDocCliente_Remitente.Focus()
                    Exit Function
                End If
            ElseIf txtDocCliente_Remitente.Text.Trim.Length <> 0 Then         'sin documento
                If Not bCargaAcompañada Then
                    MessageBox.Show("Documento no válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtDocCliente_Remitente.Focus()
                    Exit Function
                End If
            End If

            ObjVentaCargaContado.v_SERIE_FACTURA = txtSERIE.Text.Trim

            If txtCliente_Remitente.Text <> "" Then
                ObjVentaCargaContado.v_NRO_FACTURA = RellenoRight(Mro_Digitos_Ventas, txtNroDocFACBOL.Text)
                txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, txtNroDocFACBOL.Text)
            End If

            If bControlFiscalizacion = False Then
                ObjVentaCargaContado.v_FECHA_FACTURA = dtoUSUARIOS.m_sFecha
            Else
                ObjVentaCargaContado.v_FECHA_FACTURA = Format("DD/MM/YYYY", Me.txtFecha.Text)
            End If
            ObjVentaCargaContado.v_IDTIPO_PAGO = Int(ObjVentaCargaContado.coll_Tipo_Pago(cmbTipoPago.SelectedIndex.ToString))
            ObjVentaCargaContado.v_IDFORMA_PAGO = Int(ObjVentaCargaContado.coll_t_Forma_Pago(cmbFormaPago.SelectedIndex.ToString))
            iForma = ObjVentaCargaContado.v_IDFORMA_PAGO
            If ObjVentaCargaContado.v_IDFORMA_PAGO = 4 Then ObjVentaCargaContado.v_IDFORMA_PAGO = 3
            'If ObjVentaCargaContado.v_IDFORMA_PAGO = 3 Then
            '    If fnValidarRUC(txtDocCliente_Remitente.Text.ToString) = False Then
            '        ErrorProvider.SetError(txtDocCliente_Remitente, "Debe Ingresar Un RUC VALIDO")
            '        txtDocCliente_Remitente.Focus()
            '        txtDocCliente_Remitente.SelectAll()
            '        Return False
            '    End If

            '    If fnValidarRUC(txtDNIDestinatario.Text.ToString) = False Then
            '        ErrorProvider.SetError(txtDNIDestinatario, "Debe Ingresar Un RUC VALIDO")
            '        txtDNIDestinatario.Focus()
            '        txtDNIDestinatario.SelectAll()
            '        Return False
            '    End If
            'End If
            If ObjVentaCargaContado.v_IDFORMA_PAGO = 3 Then
                txtNroGuia.Text = RellenoRight(NroDigitos_Guias, txtNroGuia.Text)
            End If

            ObjVentaCargaContado.v_IDTIPO_ENTREGA = Int(ObjVentaCargaContado.coll_t_Tipo_Entrega(cmbTipo_Entrega.SelectedIndex.ToString))
            ObjVentaCargaContado.v_IDTARJETAS = 0
            ObjVentaCargaContado.v_NROTARJETA = "@"
            If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 Then
                '
                ' Modificado 11/02/2008 
                'ObjVentaCargaContado.v_IDTARJETAS = Int(ObjVentaCargaContado.coll_Tipo_Pago(cmbTipoPago.SelectedIndex.ToString))
                ObjVentaCargaContado.v_IDTARJETAS = Me.cmbTargeta.SelectedValue
                '
                If txtNroTarjeta.Text = "" Then
                    MsgBox("Debe Escribir el Nro de Tarjeta", MsgBoxStyle.Information, "Seguridad Sistema")
                    ErrorProvider.SetError(txtNroTarjeta, "Nro de Tarjeta No valido")
                    txtNroTarjeta.Focus()
                    txtNroTarjeta.SelectAll()
                    Return False
                End If
                ObjVentaCargaContado.v_NROTARJETA = IIf(txtNroTarjeta.Text <> "", txtNroTarjeta.Text, "@")
            End If
            '
            If ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = 0 Then
                ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
            End If
            '
            If ObjVentaCargaContado.v_IDAGENCIAS = 0 Then
                ObjVentaCargaContado.v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
            End If
            '
            Dim idUnidadAgencias As Integer = iWinDestino.IndexOf(txtiWinDestino.Text)
            idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))
            If idUnidadAgencias > 0 Then
                ObjVentaCargaContado.v_IDUNIDAD_DESTINO = idUnidadAgencias
                ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = Int(ObjVentaCargaContado.coll_AgenciasVenta(cmbAgenciaVenta.SelectedIndex.ToString))
                'Omendoza 27/09/2007 - Cuando el PCE está en otra agencia destino, se colaca la agencia que recibe el pago 
                If flagPCE = True Then
                    If ObjVentaCargaContado.v_IDAGENCIAS_DESTINO <> dtoUSUARIOS.m_iIdAgencia And TipoComprobante <> 3 Then
                        If Not bCargaAcompañada Then
                            ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = dtoUSUARIOS.m_iIdAgencia
                        End If
                    End If
                End If
                ' 
            Else
                MsgBox("No es Correcto la Ciudad Destino...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return False
            End If
            Dim indexof As Integer = 0
            ObjVentaCargaContado.v_IDPERSONA = 0
            ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL = IIf(txtCliente_Remitente.Text <> "", txtCliente_Remitente.Text, "@")
            ObjVentaCargaContado.v_NRO_DNI_RUC = IIf(txtDocCliente_Remitente.Text <> "", txtDocCliente_Remitente.Text, "@")
            ObjVentaCargaContado.v_cargo = Me.chkcargo.Checked
            ObjVentaCargaContado.v_IDPERSONA_ORIGEN = 0            '
            ObjVentaCargaContado.v_NRO_DOC_REMITENTE = IIf(txtDNIContacto.Text <> "", txtDNIContacto.Text, "@")
            ObjVentaCargaContado.v_NOMBRES_REMITENTE = IIf(txtContactoRemitente.Text <> "", txtContactoRemitente.Text, "@")

            'hlamas 06-08-2010 carga acompañada
            If bCargaAcompañada Then
                ObjVentaCargaContado.v_nroboleto = Me.TxtBoleto.Text
                ObjVentaCargaContado.v_carga_acompañada = 1
                'ObjVentaCargaContado.v_idagencia_venta = dtoUSUARIOS.m_idciudad
                If Me.cmbFormaPago.SelectedIndex = 0 Then
                    ObjVentaCargaContado.v_idagencia_venta = dtoUSUARIOS.m_iIdAgencia
                Else
                    ObjVentaCargaContado.v_idagencia_venta = 0
                End If
                ObjVentaCargaContado.bOrigenDiferente = bOrigenDiferente
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = IIf(IsDBNull(Me.txtDocCliente_Remitente.Tag), 0, Me.txtDocCliente_Remitente.Tag)
            ElseIf iProceso = 0 Then
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = IIf(Me.ChkAcompaña.Checked, 1, 0)
                ObjVentaCargaContado.v_idagencia_venta = 0
                ObjVentaCargaContado.bOrigenDiferente = False
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
            ElseIf iProceso = 7 Then
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = 7
                ObjVentaCargaContado.v_idagencia_venta = 0
                ObjVentaCargaContado.bOrigenDiferente = False
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
            End If

            If iWinContacto_Remitente.Count > 0 And coll_Nombres_Remitente.Count > 0 Then
                indexof = IIf(iWinContacto_Remitente.IndexOf(txtContactoRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtContactoRemitente.Text), -1)
                ObjVentaCargaContado.v_IDPERSONA_ORIGEN = 0
                If indexof >= 0 Then
                    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = Int(coll_Nombres_Remitente.Item(indexof.ToString))
                Else
                    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = 0
                    ' ObjVentaCargaContado.v_NOMBRES_REMITENTE = "@"
                End If
            End If

            ObjVentaCargaContado.v_DIRECCION_REMITENTE = IIf(txtDireccionRemitente.Text <> "", txtDireccionRemitente.Text, "@")
            If ObjVentaCargaContado.v_DIRECCION_REMITENTE = "@" Then
                ObjVentaCargaContado.v_IDDIREECION_ORIGEN = 0
            Else
                If iWinDireccion_Remitente.Count > 0 Then
                    indexof = iWinDireccion_Remitente.IndexOf(txtDireccionRemitente.Text)
                    ObjVentaCargaContado.v_IDDIREECION_ORIGEN = 0
                    If indexof >= 0 Then
                        ObjVentaCargaContado.v_IDDIREECION_ORIGEN = Int(coll_Direccion_Remitente.Item(indexof.ToString))
                    Else
                        ObjVentaCargaContado.v_IDDIREECION_ORIGEN = 0
                        'ObjVentaCargaContado.v_DIRECCION_REMITENTE = "@"
                    End If
                End If
            End If

            ObjVentaCargaContado.v_TELEFONO_REMITENTE = IIf(txtTelefonoRemitente.Text <> "", txtTelefonoRemitente.Text, "@")
            'ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0
            ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO = IIf(txtDNIDestinatario.Text <> "", txtDNIDestinatario.Text, "@")
            ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(txtCliente_Destinatario.Text <> "", txtCliente_Destinatario.Text, "@")

            If iWinContacto_Destinatario.Count > 0 And coll_Nombres_Destinatario.Count > 0 Then
                indexof = IIf(iWinContacto_Destinatario.IndexOf(txtCliente_Destinatario.Text) >= 0, iWinContacto_Destinatario.IndexOf(txtCliente_Destinatario.Text), -1)
                '   ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0
                If indexof >= 0 Then
                    If ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0 Then
                        ObjVentaCargaContado.v_IDCONTACTO_DESTINO = Int(coll_Nombres_Destinatario.Item(indexof.ToString))
                    End If
                Else
                    ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0
                    'txtCliente_Destinatario.Text = "@"
                End If
            End If
            '
            ObjVentaCargaContado.v_DIRECCION_DESTINATARIO = IIf(txtDireccionDestinatario.Text <> "", txtDireccionDestinatario.Text, "@")
            If ObjVentaCargaContado.v_DIRECCION_DESTINATARIO = "@" Then
                ObjVentaCargaContado.v_IDDIREECION_DESTINO = 0
            Else
                If iWinDireccion_Destinatario.Count > 0 Then
                    indexof = iWinDireccion_Destinatario.IndexOf(txtDireccionDestinatario.Text)
                    ObjVentaCargaContado.v_IDDIREECION_DESTINO = 0
                    If indexof >= 0 Then
                        ObjVentaCargaContado.v_IDDIREECION_DESTINO = Int(coll_Direccion_Destinatario.Item(indexof.ToString))
                    Else
                        ObjVentaCargaContado.v_IDDIREECION_DESTINO = 0
                        'ObjVentaCargaContado.v_DIRECCION_DESTINATARIO = "@"
                    End If
                End If
            End If
            '
            ObjVentaCargaContado.v_TELEFONO_DESTINATARIO = IIf(txtTelefonoDestinatario.Text <> "", txtTelefonoDestinatario.Text, "@")
            ObjVentaCargaContado.v_MEMO = IIf(txtMemo.Text <> "", txtMemo.Text, "@")
            ObjVentaCargaContado.v_MONTO_DESCUENTO = IIf(txtPorcernt_Descuento.Text <> "", txtPorcernt_Descuento.Text, 0)
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
            'PESO
            If IsDBNull(dtGridViewBultos.Rows(0).Cells(2)) = False Then
                valor1 = Format(Val(dtGridViewBultos(2, 0).Value), "##,###,####.00")
                valor2 = Format(Val(dtGridViewBultos(4, 0).Value), "##,###,####.00")

                ObjVentaCargaContado.v_CANTIDAD_X_PESO = valor1
                ObjVentaCargaContado.v_TOTAL_PESO = valor2
                totalCosto = valor2 * tarifa_Peso
            End If

            'VOLUMEN
            If IsDBNull(dtGridViewBultos.Rows(1).Cells(2)) = False Then
                valor1 = Format(Val(dtGridViewBultos(2, 1).Value), "##,###,###.00")
                valor2 = Format(Val(dtGridViewBultos(4, 1).Value), "##,###,###.00")
                ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = valor1
                ObjVentaCargaContado.v_TOTAL_VOLUMEN = valor2
                totalCosto = totalCosto + valor2 * tarifa_Volumen
            End If

            'SOBRE
            If IsDBNull(dtGridViewBultos.Rows(2).Cells(2)) = False Then
                valor1 = Format(Val(dtGridViewBultos(2, 2).Value), "##,###,###.00")
                'hlamas
                ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = valor1
                If valor1 = 0 Then
                    valor1 = Val(txtCantidadSobres.Text)
                    ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = valor1
                End If
                totalCosto = totalCosto + valor1 * tarifa_Sobre
            End If
            'txtSub_Total.Text = Format(Monto_Base + totalCosto - Val(Me.txtPorcernt_Descuento.Text) * totalCosto / 100, "##,###,###.00")
            'txtMonto_IGV.Text = Format((Monto_Base + totalCosto - Val(Me.txtPorcernt_Descuento.Text) * totalCosto / 100) * (0.01 * dtoUSUARIOS.iIGV), "##,###,###.00")
            'txtCosto_Total.Text = Format((Monto_Base + totalCosto - Val(Me.txtPorcernt_Descuento.Text) * totalCosto / 100) * (1 + 0.01 * dtoUSUARIOS.iIGV), "##,###,###.00")

            'If es_carga_asegurada = True Then
            '    ObjVentaCargaContado.v_PRECIO_X_PESO = 0
            '    ObjVentaCargaContado.v_PRECIO_X_VOLUMEN = 0
            '    ObjVentaCargaContado.v_PRECIO_X_SOBRE = 0
            'Else
            '    ObjVentaCargaContado.v_PRECIO_X_PESO = tarifa_Peso
            '    ObjVentaCargaContado.v_PRECIO_X_VOLUMEN = tarifa_Volumen
            '    ObjVentaCargaContado.v_PRECIO_X_SOBRE = tarifa_Sobre
            'End If

            tarifa_Peso = Format(Val(dtGridViewBultos(5, 0).Value), "##,###,###.00")
            tarifa_Volumen = Format(Val(dtGridViewBultos(5, 1).Value), "##,###,###.00")
            tarifa_Sobre = Format(Val(dtGridViewBultos(5, 2).Value), "##,###,###.00")

            ObjVentaCargaContado.v_PRECIO_X_PESO = tarifa_Peso
            ObjVentaCargaContado.v_PRECIO_X_VOLUMEN = tarifa_Volumen
            ObjVentaCargaContado.v_PRECIO_X_SOBRE = tarifa_Sobre


            ObjVentaCargaContado.v_MONTO_SUB_TOTAL = txtSub_Total.Text
            ObjVentaCargaContado.v_MONTO_IMPUESTO = txtMonto_IGV.Text
            ObjVentaCargaContado.v_TOTAL_COSTO = txtCosto_Total.Text

            ObjVentaCargaContado.v_IDTIPO_MONEDA = 1 'Soles

            ObjVentaCargaContado.v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            ObjVentaCargaContado.v_IP = dtoUSUARIOS.IP
            ObjVentaCargaContado.v_IDROL_USUARIO = dtoUSUARIOS.IdRol

            ObjVentaCargaContado.v_MONTO_PENALIDAD = 0
            ObjVentaCargaContado.v_IDFUNCIONARIO_AUTORIZACION = 0

            ObjVentaCargaContado.v_IGV = dtoUSUARIOS.iIGV
            ObjVentaCargaContado.v_PORCENT_DEVOLUCION = 0
            ObjVentaCargaContado.v_PORCENT_DESCUENTO = Format(Val(txtPorcernt_Descuento.Text), "###.00")
            ObjVentaCargaContado.v_MONTO_RECARGO = 0
            '----------------------------------------------------------------------------------------------------------------------------
            ObjVentaCargaContado.v_MONTO_BASE = Monto_Base

            ObjVentaCargaContado.v_MONTO_PENALIDAD = 0                ' Para la cantidad
            ObjVentaCargaContado.v_MONTO_RECARGO = 0                    ' Para El Peso

            Try
                Dim ii As Integer = 0
                For ii = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
                    If IsDBNull(dtGridViewArticulo.Rows(ii).Cells(3)) = False Then
                        If dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString <> "" Then
                            ObjVentaCargaContado.v_MONTO_PENALIDAD = ObjVentaCargaContado.v_MONTO_PENALIDAD + Int(dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString)
                            ObjVentaCargaContado.v_MONTO_RECARGO = ObjVentaCargaContado.v_MONTO_RECARGO + Int(dtGridViewArticulo.Rows(ii).Cells(4).Value.ToString)
                        End If
                    End If
                Next
            Catch ex As Exception

            End Try
            If dtGridViewArticulo.Visible = True Then
                Try
                    Dim kk As Integer = 0
                    For kk = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
                        If IsDBNull(dtGridViewArticulo.Rows(kk).Cells(3)) = False Then
                            If IsNumeric(dtGridViewArticulo.Rows(kk).Cells(3).Value.ToString) Then
                                If dtGridViewArticulo.Rows(kk).Cells(3).Value <> 0 Then
                                    If IsDBNull(dtGridViewArticulo.Rows(kk).Cells(4)) Then
                                        MsgBox("Debe ingresar el peso...", MsgBoxStyle.Information, "Seguridad Sistema")
                                        Return False
                                    End If
                                    If Not IsNumeric(dtGridViewArticulo.Rows(kk).Cells(4).Value) Then
                                        MsgBox("Debe ingresar el peso...", MsgBoxStyle.Information, "Seguridad Sistema")
                                        Return False
                                    End If
                                    If dtGridViewArticulo.Rows(kk).Cells(4).Value <= 0 Then
                                        MsgBox("Debe ingresar el peso mayor que cero...", MsgBoxStyle.Information, "Seguridad Sistema")
                                        Return False
                                    End If

                                End If
                            End If
                        End If
                    Next
                Catch ex As Exception

                End Try
            End If

            'If iControlFacturacion > 0 Then
            '    ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
            'Else
            '    If iControlMonto_Base = 0 Then
            '        ObjVentaCargaContado.v_MONTO_BASE = 0
            '    Else
            '        ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
            '    End If
            'End If
            '----------------------------------------------------------------------------------------------------------------------------
            If ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = ObjVentaCargaContado.v_IDUNIDAD_DESTINO Then
                MsgBox("No pueden ser iguales el Origen y el Destino...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return False
            End If
            If txtiWinDestino.Text = "" Then
                MsgBox("Debe definir un detino Para esta OPeracion...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return False
            End If

            If ObjVentaCargaContado.v_IDTIPO_ENTREGA = 2 Then
                If txtDireccionDestinatario.Text = "" Then
                    ErrorProvider.SetError(txtDireccionDestinatario, "Debe Ingresar la Direccion es Obligatoria...")
                    txtDireccionDestinatario.Focus()
                    Return False
                End If
            End If
            'hlamas
            'Verifica si Cantidad (pieza o bulto) de Tipos(peso,volumen) tienen su peso/volumen asociado
            'Peso
            If Val(dtGridViewBultos.Rows(0).Cells(4).Value) > 0 And Val(dtGridViewBultos.Rows(0).Cells(2).Value) = 0 Then
                MessageBox.Show("Debe ingresar Nº de Piezas o Bultos para Tipo Peso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            'Volumen
            If Val(dtGridViewBultos.Rows(1).Cells(4).Value) > 0 And Val(dtGridViewBultos.Rows(1).Cells(2).Value) = 0 Then
                MessageBox.Show("Debe ingresar Nº de Piezas o Bultos para Tipo Volumen.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            If ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_CANTIDAD_X_SOBRE + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN + ObjVentaCargaContado.v_MONTO_PENALIDAD <= 0 Then
                MsgBox("No puede realizar esta operación debe enviar como mínimo un paquete...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return False
            End If
            'cmbTipo_Entrega
            ObjIMPRESIONFACT_BOL.fnClear()
            Try
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = Val(dtGridViewBultos(7, 0).Value)
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = Val(dtGridViewBultos(7, 1).Value)
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(dtGridViewBultos(7, 2).Value)
            Catch ex As Exception

            End Try
            ObjIMPRESIONFACT_BOL.xCantidad_Peso = ObjVentaCargaContado.v_CANTIDAD_X_PESO
            ObjIMPRESIONFACT_BOL.xCantidad_Sobre = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE
            ObjIMPRESIONFACT_BOL.xCantidad_Vol = ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN

            ObjCODIGOBARRA.clinte = ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL
            ObjCODIGOBARRA.NroDOC = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
            ObjCODIGOBARRA.AGEDOM = Mid(cmbTipo_Entrega.Text, 1, 3)

            If flagPCE = False Then
                If bOtrasAgencias = False Then
                    ObjIMPRESIONFACT_BOL.xOrigen = dtoUSUARIOS.m_iNombreUnidadAgencia
                Else
                    'ObjIMPRESIONFACT_BOL.xOrigen = ObjVentaCargaContado.v_IDUNIDAD_ORIGEN
                    'Mod.16/09/2009 -->Omendoza - Pasando al datahelper   
                    ObjVentaCargaContado.fnNombreUnidadAgencia(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
                    'ObjIMPRESIONFACT_BOL.xOrigen = ObjVentaCargaContado.rstVarUnidad(0).Value
                    ObjIMPRESIONFACT_BOL.xOrigen = ObjVentaCargaContado.dt_rstVarUnidad.Rows(0).Item(0)
                End If
            Else
                ObjIMPRESIONFACT_BOL.xOrigen = ObjVentaCargaContado.v_UNIDAD_ORIGEN
            End If
            ObjIMPRESIONFACT_BOL.xDestino = txtiWinDestino.Text
            ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL = Me.txtSERIE.Text & "-" & Me.txtNroDocFACBOL.Text
            ObjIMPRESIONFACT_BOL.xRazonSocial = Me.txtCliente_Remitente.Text
            ObjIMPRESIONFACT_BOL.xDireccionRemitente = Me.txtDireccionRemitente.Text
            ObjIMPRESIONFACT_BOL.xRuc = txtDocCliente_Remitente.Text
            ObjIMPRESIONFACT_BOL.xRemitente = Me.txtContactoRemitente.Text
            ObjIMPRESIONFACT_BOL.xConsignado = Me.txtCliente_Destinatario.Text
            ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.txtDireccionDestinatario.Text
            ObjIMPRESIONFACT_BOL.xfecha_factura = Me.txtFecha.Text
            ObjIMPRESIONFACT_BOL.xTotalPeso = ObjVentaCargaContado.v_TOTAL_PESO
            ObjIMPRESIONFACT_BOL.xTotalVolumen = ObjVentaCargaContado.v_TOTAL_VOLUMEN
            ObjIMPRESIONFACT_BOL.xTotalSobres = 0
            ObjIMPRESIONFACT_BOL.xFormaPago = cmbFormaPago.Text
            ObjIMPRESIONFACT_BOL.xNroRef = Me.txtSERIE.Text & "-" & Me.txtNroDocFACBOL.Text
            ObjIMPRESIONFACT_BOL.xMemo = Me.txtMemo.Text
            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total = Me.txtSub_Total.Text
            ObjIMPRESIONFACT_BOL.xMonto_Impuesto = txtMonto_IGV.Text
            ObjIMPRESIONFACT_BOL.xTotal_Costo = ObjVentaCargaContado.v_TOTAL_COSTO
            ObjIMPRESIONFACT_BOL.xDescuento = IIf(txtPorcernt_Descuento.Text <> "", txtPorcernt_Descuento.Text, "")
            ObjIMPRESIONFACT_BOL.xAgenciaDestino = IIf(cmbAgenciaVenta.Text <> "", cmbAgenciaVenta.Text, "")
            ' ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
            ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = cmbTipo_Entrega.Text   '27/04/2007
            If ObjVentaCargaContado.v_IDFORMA_PAGO = 3 Then
                If fnDigito_Chequeo(txtNroGuia.Text) = True Then
                    txtNroGuia.Text = RellenoRight(NroDigitos_Guias, txtNroGuia.Text)
                    ObjVentaCargaContado.v_SERIE_FACTURA = "000"
                    ObjVentaCargaContado.v_NRO_FACTURA = txtNroGuia.Text
                    ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3
                    'IMPRESION DE GUIA DE ENVIO
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

                    If ObjVentaCargaContado.v_IDTIPO_ENTREGA = 1 Then
                        p_domicilio = ""
                        p_agencia = "X"
                    Else
                        p_domicilio = "X"
                        p_agencia = ""
                    End If

                    p_contado = ""
                    p_destino = "X"
                    p_credito = ""

                    ObjRptGuiaEnvio.p_NroGUIA = txtNroGuia.Text
                    ObjRptGuiaEnvio.p_tipo_entrega = v_iDomicilio & v_iAgencia
                    ObjRptGuiaEnvio.p_ruc = txtDocCliente_Remitente.Text & "-" & ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL
                    ' ObjRptGuiaEnvio.p_tipo_entrega = ObjRptGuiaEnvio.p_tipo_entrega
                    'ObjRptGuiaEnvio.p_forma_pago = ObjRptGuiaEnvio.p_forma_pago


                    ObjRptGuiaEnvio.p_contacto = "FACTURAR A: " & IIf(txtContactoRemitente.Text <> "", txtContactoRemitente.Text, "")
                    ObjRptGuiaEnvio.p_codigo_iata_ori = v_Origen
                    ObjRptGuiaEnvio.p_codigo_iata_desti = v_destino
                    ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI = Me.txtTelefonoRemitente.Text
                    ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI = Me.txtTelefonoDestinatario.Text
                    ObjRptGuiaEnvio.P_REMITENTE = Me.txtCliente_Remitente.Text
                    ObjRptGuiaEnvio.P_DIRECCION_REMI = Me.txtDireccionRemitente.Text
                    ObjRptGuiaEnvio.P_DIRECCION_DESTI = Me.txtDireccionDestinatario.Text
                    ObjRptGuiaEnvio.P_NOMBRES_DESTI = Me.txtCliente_Destinatario.Text
                    ObjRptGuiaEnvio.P_FECHA_GUIA = txtFecha.Text
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
                    ObjRptGuiaEnvio.P_PROVINCIA = txtiWinDestino.Text
                    '**********************************************************************************************************************************************
                End If
            End If

            '15-01-2009  Se modificó 
            If flagPCE = True Then
                If TipoComprobante = 1 Or TipoComprobante = 2 Then
                    If txtDocCliente_Remitente.Text.ToString.Length = 11 Then
                        If fnValidarRUC(txtDocCliente_Remitente.Text.ToString) = True Then
                            TipoComprobante = 1
                        Else
                            TipoComprobante = 2
                        End If
                    Else
                        TipoComprobante = 2
                    End If
                End If
            End If
            'ObjVentaCargaContado.v_NRO_GUIA 
            If varIdCondicion = 2 Or varIdCondicion = 5 Then
                asignar_documentos_clientes()
                'Mod.17/09/2009 -->Omendoza - Pasando al datahelper   
                'If ObjVentaCargaContado.GrabarII(cnn) = True Then
                If ObjVentaCargaContado.GrabarII = True Then

                    ConfiMensajeriaDlg = New FrmConfiMensajeria
                    'ConfiMensajeriaDlg.ShowDialog()
                    Acceso.Asignar(ConfiMensajeriaDlg, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        ConfiMensajeriaDlg.ShowDialog()
                    Else
                        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ConfiMensajeriaDlg = Nothing

                    ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString
                    Try
                        If dtGridViewArticulo.Visible = True Then
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
                            For ii = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
                                If IsDBNull(dtGridViewArticulo.Rows(ii).Cells(3)) = False Then
                                    If dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString <> "" Then
                                        objGuia_Envio_Articulo.iIDARTICULOS = Int(dtGridViewArticulo.Rows(ii).Cells(0).Value.ToString)
                                        objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString)
                                        objGuia_Envio_Articulo.iPESO = Int(dtGridViewArticulo.Rows(ii).Cells(4).Value.ToString)
                                        objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(ii).Cells(2).Value.ToString)
                                        'Mod. 21/08/2009 -->Omendoza - Pasando al datahelper   
                                        'If objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS() = True Then
                                        'End If
                                        objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
                                    End If
                                End If
                            Next
                        End If

                    Catch ex As Exception

                    End Try


                    flat = True
                    Dim i As Integer = 0
                    Dim serie_NroDoc() As String
                    objGuiaEnvio.iControl_Documentos = 1
                    objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                    objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                    Dim iContador As Integer = 0
                    If objGuiaEnvio.iCONTROL = 1 Or objGuiaEnvio.iCONTROL = 0 Then
                        For i = 0 To Me.DataGridViewDocumentos.Rows().Count() - 2
                            Try
                                If IsDBNull(DataGridViewDocumentos.Rows(i).Cells(2)) = False Then
                                    If DataGridViewDocumentos.Rows(i).Cells(2).Value.ToString <> "" Then
                                        serie_NroDoc = Split(DataGridViewDocumentos.Rows(i).Cells(2).Value.ToString, "-")
                                        If serie_NroDoc.Length > 1 Then
                                            objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                            objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                            If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                                If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                                    'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper   
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
                                'MsgBox("....")
                            End Try

                            Try
                                If IsDBNull(DataGridViewDocumentos.Rows(i).Cells(3)) = False Then
                                    If DataGridViewDocumentos.Rows(i).Cells(3).Value.ToString <> "" Then
                                        serie_NroDoc = Split(DataGridViewDocumentos.Rows(i).Cells(3).Value.ToString, "-")
                                        If serie_NroDoc.Length > 1 Then
                                            objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                            objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                            If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                                If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                                    'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper   
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
                                'MsgBox("....")
                            End Try

                        Next
                    End If

                    'if msgbox "Esta Seguro de Imprimir etiquetas ?",MsgBoxStyle.YesNoCancel,"Seguridad Sistema" =MsgBoxResult.Yes then

                    'End If
                    'ObjCODIGOBARRA.Cantidad = "5"

                    If bControlFiscalizacion = False Then
                        MsgBox("Verifique su Impresora...que este conectado", MsgBoxStyle.Exclamation, "Seguridad Sistema")
                        If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 1 Then
                            'fnImprimirFACTURA()
                            ImprimirFactura()
                        Else
                            'fnImprimirBOLETA()
                            ImprimirBoleta()
                        End If
                    End If

                    If flagPCEVALIDADOC = False Then
                        If Me.cmbFormaPago.SelectedIndex <> 2 Then
                            If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then
                                If xIMPRESORA = 1 Then
                                    fnImprimirEtiquetas()
                                Else
                                    If xIMPRESORA = 2 Then
                                        fnImprimirEtiquetasFAC_II()
                                    Else
                                        fnImprimirEtiquetasFAC_III()
                                    End If
                                    'fnImprimirEtiquetasFAC_II()
                                End If
                            End If
                        End If
                    End If

                    fnNUEVO()
                    limpiar_documentos_cliente()
                    flat = True
                    iOficinaDestino = 0
                    iOficinaOrigen = 0

                Else
                    MsgBox("Operacion Cancelada....Verifique su Configuracion Documentaria", MsgBoxStyle.Information, "Seguridad Sistema")
                End If

            ElseIf varIdCondicion = 1 Then
                If ObjVentaCargaContado.v_IDFORMA_PAGO = 1 And bControlFiscalizacion = False Then
                    Dim varDlgPagos As New frmPagosContado
                    If varDlgPagos.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        If iTotalPagado > 0 Then
                            lblTotalPagado.Visible = True
                            lblTotalVenta.Visible = True
                            lblVuelto.Visible = True
                            txtTotalPagado.Visible = True
                            txtTotalVenta.Visible = True
                            txtVuelto.Visible = True

                            txtTotalVenta.Text = FormatNumber(txtCosto_Total.Text, 2)
                            txtTotalPagado.Text = FormatNumber(iTotalPagado, 2)
                            txtVuelto.Text = FormatNumber(iVuelto, 2)
                        End If

                        asignar_documentos_clientes()
                        'Mod.17/09/2009 -->Omendoza - Pasando al datahelper   
                        'If ObjVentaCargaContado.GrabarII(cnn) = True Then
                        If ObjVentaCargaContado.GrabarII = True Then
                            If lblMontoMinimo.Visible Then 'ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
                                'If bMontoMinimo Then
                                ObjVentaCargaContado.fnUPDMONTO_MINIMO(ObjVentaCargaContado.v_IDFACTURA.ToString, lblMontoMinimo.Text)
                                'End If
                            End If
                            '15/09/2009 - Ojo debe moverse la mensajeria antes que graba el comprobante de venta 
                            ConfiMensajeriaDlg = New FrmConfiMensajeria
                            'ConfiMensajeriaDlg.ShowDialog()

                            Acceso.Asignar(ConfiMensajeriaDlg, Me.hnd)
                            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                                ConfiMensajeriaDlg.ShowDialog()
                            Else
                                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            ConfiMensajeriaDlg = Nothing

                            ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = cmbTipo_Entrega.Text  '27/04/2007
                            ObjPagosSoles.v_idfactura_contado = ObjVentaCargaContado.v_IDFACTURA
                            ObjPagosDolares.v_idfactura_contado = ObjVentaCargaContado.v_IDFACTURA
                            ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString

                            Try
                                If dtGridViewArticulo.Visible = True Then
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
                                    For ii = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
                                        If IsDBNull(dtGridViewArticulo.Rows(ii).Cells(3)) = False Then
                                            If dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString <> "" Then
                                                objGuia_Envio_Articulo.iIDARTICULOS = Int(dtGridViewArticulo.Rows(ii).Cells(0).Value.ToString)
                                                objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString)
                                                objGuia_Envio_Articulo.iPESO = Int(dtGridViewArticulo.Rows(ii).Cells(4).Value.ToString)
                                                objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(ii).Cells(2).Value.ToString)
                                                'Mod. 21/08/2009 -->Omendoza - Pasando al datahelper   
                                                'If objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS() = True Then
                                                'End If
                                                objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
                                            End If
                                        End If
                                    Next
                                End If

                            Catch ex As Exception

                            End Try


                            flat = True
                            Dim i As Integer = 0
                            Dim serie_NroDoc() As String
                            objGuiaEnvio.iControl_Documentos = 1
                            objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                            objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                            Dim iContador As Integer = 0

                            '-------------------------------------------
                            'INICIO DE DOCUENTOS DEL CLIENTE
                            '-------------------------------------------
                            'If es_carga_asegurada = False Then
                            If objGuiaEnvio.iCONTROL = 0 Or objGuiaEnvio.iCONTROL = 1 Then
                                For i = 0 To Me.DataGridViewDocumentos.Rows().Count() - 2
                                    Try
                                        If IsDBNull(DataGridViewDocumentos.Rows(i).Cells(2)) = False Then
                                            If DataGridViewDocumentos.Rows(i).Cells(2).Value.ToString <> "" Then
                                                serie_NroDoc = Split(DataGridViewDocumentos.Rows(i).Cells(2).Value.ToString, "-")
                                                If serie_NroDoc.Length > 1 Then
                                                    objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                                    objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                                    If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                                        If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                                            'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper 
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
                                        'MsgBox("....")
                                    End Try

                                    Try
                                        If IsDBNull(DataGridViewDocumentos.Rows(i).Cells(3)) = False Then
                                            If DataGridViewDocumentos.Rows(i).Cells(3).Value.ToString <> "" Then
                                                serie_NroDoc = Split(DataGridViewDocumentos.Rows(i).Cells(3).Value.ToString, "-")
                                                If serie_NroDoc.Length > 1 Then
                                                    objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                                    objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                                    If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                                        If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                                            'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper   
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
                                        'MsgBox("....")
                                    End Try

                                Next
                            End If
                            'End If
                            '-------------------------------------------
                            'FIN DE INGREO DE DOCUMENTOS DEL CLIENTE
                            '-------------------------------------------



                            If bControlFiscalizacion = False Then
                                MsgBox("Verifique su Impresora, que este conectado...", MsgBoxStyle.Exclamation, "Seguridad Sistema")
                                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 1 Then
                                    'fnImprimirFACTURA()
                                    ImprimirFactura()
                                Else
                                    'fnImprimirBOLETA()
                                    ImprimirBoleta()
                                End If
                            End If

                            If flagPCEVALIDADOC = False Then
                                If Me.cmbFormaPago.SelectedIndex <> 2 Then
                                    If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then
                                        If xIMPRESORA = 1 Then
                                            fnImprimirEtiquetas()
                                        Else
                                            If xIMPRESORA = 2 Then
                                                fnImprimirEtiquetasFAC_II()
                                            Else
                                                fnImprimirEtiquetasFAC_III()
                                            End If
                                            ' fnImprimirEtiquetasFAC_II()
                                        End If
                                    End If
                                End If
                            End If
                            '15/09/2009 - No deberia ingresar 2 veces 
                            If ObjPagosSoles.fnGrabarPagos() = True Then

                            End If
                            If ObjPagosDolares.fnGrabarPagos() = True Then

                            End If
                            '
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
                            MsgBox("Operacion Cancelada....Verifique su Configuracion Documentaria", MsgBoxStyle.Information, "Seguridad Sistema")
                        End If
                    Else
                        lblTotalPagado.Visible = False
                        lblTotalVenta.Visible = False
                        lblVuelto.Visible = False
                        txtTotalPagado.Visible = False
                        txtTotalVenta.Visible = False
                        txtVuelto.Visible = False

                        MsgBox("Cancelo Operacion Puede Intentar el Pago de Nuevo", MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                Else
                    asignar_documentos_clientes()
                    '
                    'Mod.17/09/2009 -->Omendoza - Pasando al datahelper   
                    'If ObjVentaCargaContado.GrabarII(cnn) = True Then
                    '
                    'ObjVentaCargaContado.v_carga_acompañada = bCargaAcompañada
                    If ObjVentaCargaContado.GrabarII() = True Then
                        'If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Then
                        If bMontoMinimo Then
                            ObjVentaCargaContado.fnUPDMONTO_MINIMO(ObjVentaCargaContado.v_IDFACTURA.ToString, Me.objCargaAsegurada.monto_minimo_PCE)
                        End If
                        'End If

                        ConfiMensajeriaDlg = New FrmConfiMensajeria
                        'ConfiMensajeriaDlg.ShowDialog()
                        Acceso.Asignar(ConfiMensajeriaDlg, Me.hnd)
                        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                            ConfiMensajeriaDlg.ShowDialog()
                        Else
                            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        ConfiMensajeriaDlg = Nothing

                        TipoComprobante = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                        ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = cmbTipo_Entrega.Text   ' 27/04/2007
                        ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString
                        Try
                            If dtGridViewArticulo.Visible = True Then
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
                                For ii = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
                                    If IsDBNull(dtGridViewArticulo.Rows(ii).Cells(3)) = False Then
                                        If dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString <> "" Then
                                            objGuia_Envio_Articulo.iIDARTICULOS = Int(dtGridViewArticulo.Rows(ii).Cells(0).Value.ToString)
                                            objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString)
                                            objGuia_Envio_Articulo.iPESO = dtGridViewArticulo.Rows(ii).Cells(4).Value
                                            objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(ii).Cells(2).Value.ToString)
                                            'Mod. 21/08/2009 -->Omendoza - Pasando al datahelper   
                                            'If objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS() = True Then
                                            'End If
                                            objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
                                        End If
                                    End If
                                Next
                            End If

                        Catch ex As Exception

                        End Try

                        flat = True
                        Dim i As Integer = 0
                        Dim serie_NroDoc() As String
                        objGuiaEnvio.iControl_Documentos = 1
                        objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                        objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE

                        Dim iContador As Integer = 0

                        If objGuiaEnvio.iCONTROL = 0 Or objGuiaEnvio.iCONTROL = 1 Then
                            For i = 0 To Me.DataGridViewDocumentos.Rows().Count() - 2
                                Try
                                    If IsDBNull(DataGridViewDocumentos.Rows(i).Cells(2)) = False Then
                                        If DataGridViewDocumentos.Rows(i).Cells(2).Value.ToString <> "" Then
                                            serie_NroDoc = Split(DataGridViewDocumentos.Rows(i).Cells(2).Value.ToString, "-")
                                            If serie_NroDoc.Length > 1 Then
                                                objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                                objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                                If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                                    If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                                        'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper   
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
                                    'MsgBox("....")
                                End Try

                                Try
                                    If IsDBNull(DataGridViewDocumentos.Rows(i).Cells(3)) = False Then
                                        If DataGridViewDocumentos.Rows(i).Cells(3).Value.ToString <> "" Then
                                            serie_NroDoc = Split(DataGridViewDocumentos.Rows(i).Cells(3).Value.ToString, "-")
                                            If serie_NroDoc.Length > 1 Then
                                                objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                                objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                                If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                                    If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                                        'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper   
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
                                    'MsgBox("....")
                                End Try

                            Next
                        End If

                        If Me.cmbFormaPago.SelectedIndex <> 2 Then
                            If bControlFiscalizacion = False Then
                                If MsgBox("Esta Seguro de Imprimir GUIA DE ENVIO ?.....", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                                    'fnInprecion_Guia_Envio()
                                    ImprimirGuiaEnvio()
                                End If

                                'If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 1 Then
                                '    fnImprimirFACTURA()
                                'Else
                                '    fnImprimirBOLETA()
                                'End If
                            End If
                        End If

                        If Me.cmbFormaPago.SelectedIndex <> 2 Then
                            If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then
                                If xIMPRESORA = 1 Then
                                    fnImprimirEtiquetas()
                                Else
                                    If xIMPRESORA = 2 Then
                                        fnImprimirEtiquetasFAC_II()
                                    Else
                                        fnImprimirEtiquetasFAC_III()
                                    End If
                                    'fnImprimirEtiquetasFAC_II()
                                End If
                            End If
                        End If
                        TipoComprobante = 2
                        fnNUEVO()
                        limpiar_documentos_cliente()
                        flat = True
                        iOficinaDestino = 0
                        iOficinaOrigen = 0

                    End If
                    End If

                End If

                bOrigenDiferente = False
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            flat = False
        End Try
        Return flat
    End Function
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

    Private Sub dtGridViewBultos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewBultos.CellContentClick

    End Sub
    Private Sub fnCalcularCosto(ByVal row As Integer, ByVal valor1 As Double, ByVal valor2 As Double)
        Try

            If row = 0 Then
                If valor2 = 0 Then
                    dtGridViewBultos(6, row).Value = "0.00"
                    dtGridViewBultos(7, row).Value = Format((valor1 * tarifa_Peso), "###,###,###.00")
                Else
                    If objGuiaEnvio.iPeso_Minimo <= valor1 And valor1 <= objGuiaEnvio.iPeso_Maximo Then
                        dtGridViewBultos(6, row).Value = "0.00"
                        dtGridViewBultos(7, row).Value = Format(objGuiaEnvio.iPrecio_cond_Peso, "###,###,###.00")
                        bCondicion = True
                    Else
                        bCondicion = False
                        dtGridViewBultos(6, row).Value = "0.00"
                        dtGridViewBultos(7, row).Value = Format((valor1 * tarifa_Peso), "###,###,###.00")
                    End If
                End If

            ElseIf row = 1 Then
                dtGridViewBultos(6, row).Value = "0.00"
                dtGridViewBultos(7, row).Value = Format((valor1 * tarifa_Volumen), "###,###,###.00")
            ElseIf row = 2 Then
                dtGridViewBultos(7, row).Value = Format((valor2 * tarifa_Sobre), "###,###,###.00")
            End If

            '----------------------------------------------------------------------------------------------------------------------------
            If iControlFacturacion > 0 Then
                If Monto_Base > 0 Then
                    ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
                End If
            Else
                If iControlMonto_Base = 0 Then
                    ObjVentaCargaContado.v_MONTO_BASE = 0
                    Monto_Base = 0
                Else
                    If Monto_Base > 0 And iControlMonto_Base = 1 Then
                        ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
                    End If
                End If
            End If
            '----------------------------------------------------------------------------------------------------------------------------

            Dim SubTotal As Double = 0

            If Val(dtGridViewBultos(7, 0).Value) + Val(dtGridViewBultos(7, 1).Value) > 0 Then
                'SubTotal = Monto_Base + Val(dtGridViewBultos(7, 0).Value.ToString) + Val(dtGridViewBultos(7, 1).Value) + Val(dtGridViewBultos(7, 2).Value)
                'SubTotal = Monto_Base + Val(Format(dtGridViewBultos(7, 0).Value, "####.00")) + Val(Format(dtGridViewBultos(7, 1).Value, "####.00")) + Val(Format(dtGridViewBultos(7, 2).Value, "####.00"))
                If iControlMonto_Base = 1 Then
                    SubTotal = Monto_Base + fnNumeroDecimal(dtGridViewBultos(7, 0).Value.ToString) + fnNumeroDecimal(dtGridViewBultos(7, 1).Value.ToString) + fnNumeroDecimal(dtGridViewBultos(7, 2).Value.ToString)
                Else
                    SubTotal = fnNumeroDecimal(dtGridViewBultos(7, 0).Value.ToString) + fnNumeroDecimal(dtGridViewBultos(7, 1).Value.ToString) + fnNumeroDecimal(dtGridViewBultos(7, 2).Value.ToString)
                End If

            Else
                ' SubTotal = Val(Format(dtGridViewBultos(7, 0).Value, "####.00")) + Val(Format(dtGridViewBultos(7, 1).Value, "####.00")) + Val(Format(dtGridViewBultos(7, 2).Value, "####.00"))
                'SubTotal = dtGridViewBultos(7, 0).Value + dtGridViewBultos(7, 1).Value + dtGridViewBultos(7, 2).Value
                SubTotal = fnNumeroDecimal(dtGridViewBultos(7, 0).Value.ToString) + fnNumeroDecimal(dtGridViewBultos(7, 1).Value.ToString) + fnNumeroDecimal(dtGridViewBultos(7, 2).Value.ToString)
            End If
            Dim Total_Costo As Double = 0
            Dim Sub_Total As Double = 0

            'If SubTotal > 0 Then
            '    Total_Costo = fnTECHO(SubTotal * (1 + (dtoUSUARIOS.iIGV / 100)))
            '    Sub_Total = Total_Costo / (1 + (dtoUSUARIOS.iIGV / 100))
            'End If


            Dim SUB_TOTAL_GENERAL As Double = 0
            If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) > 0 Then
                SUB_TOTAL_GENERAL = fnTECHO(Format(SubTotal * (1 + (dtoUSUARIOS.iIGV / 100)) * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.0000")) ' 01/09/2010
                Total_Costo = SUB_TOTAL_GENERAL
                Sub_Total = SUB_TOTAL_GENERAL / (1 + (dtoUSUARIOS.iIGV / 100))

                'hlamas 30-10-2008
                If bTarifarioGeneral Then
                    'SUB_TOTAL_GENERAL = fnTECHO(Format(SubTotal * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00"))
                    'Total_Costo = SUB_TOTAL_GENERAL
                    'Sub_Total = SUB_TOTAL_GENERAL / (1 + (dtoUSUARIOS.iIGV / 100))
                End If

            Else
                If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            txtSub_Total.Text = Format(Sub_Total, "###,###,###.00")
            txtMonto_IGV.Text = Format(Total_Costo - Sub_Total, "###,###,###.00")
            txtCosto_Total.Text = Format(Total_Costo, "###,###,###.00")

            fnTotalPago()


        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        'Label5.Visible = Not Label5.Visible

    End Sub

    Private Sub agregar_documentos_asegurados()
        Dim monto_carga_asegurada As Double = 0
        'Dim iSubTotal As Double = 0, iImpuesto As Double = 0, iTotal As Double = 0
        Dim iContador As Integer = 0

        es_carga_asegurada = False
        iSub_Total_CA = 0
        iImpuesto_CA = 0
        iTotal_CA = 0

        For k As Integer = 1 To DataGridViewDocumentos.Rows().Count - 1
            DataGridViewDocumentos.Rows(k).Cells(3).Value = ""
        Next
        DataGridViewDocumentos.Rows(0).Cells(3).Value = ""

        For i As Integer = 0 To 18 Step 1
            If Not (objComprobanteAsegurada(iContador).NRO_SERIE Is Nothing) Then
                If DataGridViewDocumentos.Rows.Count - 1 = i Then
                    DataGridViewDocumentos.Rows.Add()
                End If
            End If
            iContador += 1
        Next

        For i As Integer = 0 To 18 Step 1
            If Not ((objComprobanteAsegurada(i).NRO_SERIE Is Nothing) And (objComprobanteAsegurada(i + 1).NRO_SERIE Is Nothing)) Then
                'Dim row0 As String() = {"", _
                '"", _
                'objComprobanteAsegurada(i).NRO_SERIE + "-" + objComprobanteAsegurada(i).NRO_DOCU, _
                'objComprobanteAsegurada(i + 1).NRO_SERIE + "-" + objComprobanteAsegurada(i + 1).NRO_DOCU}

                'DataGridViewDocumentos.Rows().Add(row0)
                DataGridViewDocumentos.Rows(i).Cells(3).Value = objComprobanteAsegurada(i).NRO_SERIE + "-" + objComprobanteAsegurada(i).NRO_DOCU
                iFilas += 1

                'If DataGridViewDocumentos.Rows.Count - 1 = i Then
                'DataGridViewDocumentos.Rows.Add()
                'End If

                es_carga_asegurada = True
            ElseIf Not (objComprobanteAsegurada(i).NRO_SERIE Is Nothing) Then
                Dim row0 As String() = {"", _
                "", _
                objComprobanteAsegurada(i).NRO_SERIE + "-" + objComprobanteAsegurada(i).NRO_DOCU, _
                "-"}
                DataGridViewDocumentos.Rows().Add(row0)
                es_carga_asegurada = True
            End If
            If objComprobanteAsegurada(i).TIPO = 1 Or objComprobanteAsegurada(i).TIPO = 0 Then
                monto_carga_asegurada = FormatNumber(monto_carga_asegurada + (Val(objComprobanteAsegurada(i).MONTO_SUB_TOTAL) * Val(objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO)) * Val(objComprobanteAsegurada(i).PORCEN) / 100, 2)
            ElseIf objComprobanteAsegurada(i).TIPO = 2 Then
                Dim iSub As Double = objComprobanteAsegurada(i).PORCEN * Val(objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO) / (1 + dtoUSUARIOS.vImpuesto)
                monto_carga_asegurada = FormatNumber(monto_carga_asegurada + iSub, 2)
            End If
        Next
        If es_carga_asegurada = True Then
            ObtieneMontosAsegurados(iSub_Total_CA, iImpuesto_CA, iTotal_CA)
            If iTotal_CA > 0 Then
                If dtGridViewBultos.Rows.Count < 5 Then
                    dtGridViewBultos.Rows.Add()
                End If
                dtGridViewBultos(1, 4).Value = "CA"
                If bTarifarioGeneral And bContado Then
                    dtGridViewBultos(7, 4).Value = FormatNumber(iTotal_CA, 2)
                Else
                    dtGridViewBultos(7, 4).Value = FormatNumber(iSub_Total_CA, 2)
                End If
            End If
            'DataGridViewDocumentos.ReadOnly = True
            Me.Timer1.Start()
        Else
            If dtGridViewBultos.Rows.Count = 5 Then
                dtGridViewBultos.Rows.RemoveAt(4)
            End If
            'DataGridViewDocumentos.ReadOnly = False
            Me.Timer1.Stop()
            'Label5.Visible = False
        End If
        If recuperando_datos_contado = False Then
            fnTotalPago()
        End If
        If es_carga_asegurada Then
            lblCarga.Visible = True
        Else
            lblCarga.Visible = False
        End If

        'hlamas 08-10-2010 carga acompañada
        If bCargaAcompañada Then
            lblCarga.Text = "--> CARGA ACOMPAÑADA"
            lblCarga.Visible = True
        Else
            lblCarga.Text = "--> CARGA ASEGURADA"
            lblCarga.Visible = False
        End If


        'Dim iFila = DataGridViewDocumentos.Rows().Count - 1
        'For k As Integer = 0 To iFila
        'If Val(DataGridViewDocumentos.Rows(k).Cells(3).Value) = 0 And Val(DataGridViewDocumentos.Rows(k).Cells(2).Value) = 0 Then
        ' If Not (k = iFila) Then
        'DataGridViewDocumentos.Rows.RemoveAt(k)
        'End If
        'End If
        'Next
    End Sub

    Private Function fnVERDATOSVENTACONTADO(ByVal idControl As Integer) As Boolean
        Dim iContador As Integer = 0
        '
        Try

            If dtGridViewBultos.Rows.Count = 5 Then
                dtGridViewBultos.Rows.RemoveAt(4)
            End If
            'Me.ChkProceso.Checked = False
            ObjVentaCargaContado.fnGetAgencias(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            '01/09/2009 - Mod. x datahelper x datatable 
            'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.rstVarAgencias, cmbAgenciaVenta, ObjVentaCargaContado.coll_AgenciasVenta, ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_VarAgencias, cmbAgenciaVenta, ObjVentaCargaContado.coll_AgenciasVenta, ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)
            'ObjVentaCargaContado.cur_t_tipo_comprobante.MoveFirst()
            'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.cur_t_tipo_comprobante, cmbFACBOL, ObjVentaCargaContado.coll_t_tipo_comprobante, 1)

            If bOtrasAgencias Then
                'ObjVentaCargaContado.fnGetAgencias_1()
                'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.rstVarAgencias_1, cmbOrigen, ObjVentaCargaContado.coll_AgenciasOrigen, ObjVentaCargaContado.v_IDAGENCIAS)
                'Mod.16/09/2009 -->Omendoza - Pasando al datahelper   
                ObjVentaCargaContado.fnGetAgencias_2(ObjVentaCargaContado.v_IDAGENCIAS)
                'txtOrigen.Text = ObjVentaCargaContado.rstVarAgencias_2(0).Value
                txtOrigen.Text = ObjVentaCargaContado.dt_rstVarAgencias_2.Rows(0).Item(0)

                txtOrigen.Visible = True
                cmbAgenciaOrigen.Visible = False
            End If

            'ObjVentaCargaContado.cur_t_Tipo_Entrega.MoveFirst()
            'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.cur_t_Tipo_Entrega, cmbTipo_Entrega, ObjVentaCargaContado.coll_t_Tipo_Entrega, ObjVentaCargaContado.v_IDTIPO_ENTREGA)
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_t_Tipo_Entrega, cmbTipo_Entrega, ObjVentaCargaContado.coll_t_Tipo_Entrega, ObjVentaCargaContado.v_IDTIPO_ENTREGA)
            b_no_lee_tipo_entrega = False
            'ObjVentaCargaContado.cur_Tipo_Pago.MoveFirst()
            'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.cur_Tipo_Pago, cmbTipoPago, ObjVentaCargaContado.coll_Tipo_Pago, ObjVentaCargaContado.v_IDTIPO_PAGO)
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_Tipo_Pago, cmbTipoPago, ObjVentaCargaContado.coll_Tipo_Pago, ObjVentaCargaContado.v_IDTIPO_PAGO)

            If flagPCE = True Then
                txtDireccionRemitente.Text = ""
                txtDireccionRemitente.Focus()
                ObjVentaCargaContado.v_DIRECCION_REMITENTE = ""
                ObjVentaCargaContado.v_IDDIREECION_ORIGEN = 0
            Else
                txtDireccionRemitente.Text = ObjVentaCargaContado.v_DIRECCION_REMITENTE
            End If

            'If fnValidar_Rol("24") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 9) Then
                If flagPCE = True Then
                    txtFecha.Enabled = True
                    txtFecha.ReadOnly = False
                    'Else
                    'txtFecha.Enabled = False
                    ' txtFecha.ReadOnly = True
                End If
            End If

            Dim flagPCEDatos As Boolean = False
            If idControl = 1 And ObjVentaCargaContado.v_IDFORMA_PAGO = 3 Then
                flagPCEDatos = True
                ObjVentaCargaContado.v_IDFORMA_PAGO = 1
                'ObjVentaCargaContado.cur_t_Forma_Pago.MoveFirst()
                ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_t_Forma_Pago, cmbFormaPago, ObjVentaCargaContado.coll_t_Forma_Pago, ObjVentaCargaContado.v_IDFORMA_PAGO)

                txtDocCliente_Remitente.Enabled = True
                txtCliente_Remitente.Enabled = True
                txtDocCliente_Remitente.ReadOnly = False
                txtCliente_Remitente.ReadOnly = False

                txtDireccionRemitente.Enabled = True
                txtDireccionRemitente.ReadOnly = False

                txtDNIDestinatario.Enabled = False
                txtDNIContacto.Enabled = False
                'txtDNIDestinatario.Enabled = True
                'txtCliente_Destinatario.Enabled = True
                'txtDNIDestinatario.ReadOnly = False
                'txtCliente_Destinatario.ReadOnly = False
                txtDireccionRemitente.Focus()
            Else
                'ObjVentaCargaContado.cur_t_Forma_Pago.MoveFirst()
                'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.cur_t_Forma_Pago, cmbFormaPago, ObjVentaCargaContado.coll_t_Forma_Pago, ObjVentaCargaContado.v_IDFORMA_PAGO)
                ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_t_Forma_Pago, cmbFormaPago, ObjVentaCargaContado.coll_t_Forma_Pago, ObjVentaCargaContado.v_IDFORMA_PAGO)

                txtDocCliente_Remitente.Enabled = False
                txtCliente_Remitente.Enabled = False
                txtDocCliente_Remitente.ReadOnly = True
                txtCliente_Remitente.ReadOnly = True

                txtDireccionRemitente.Enabled = False
                txtDireccionRemitente.ReadOnly = True
                'txtDNIDestinatario.Enabled = False
                'txtCliente_Destinatario.Enabled = False
                'txtDNIDestinatario.ReadOnly = True
                'txtCliente_Destinatario.ReadOnly = True

            End If


            txtSERIE.Text = ObjVentaCargaContado.v_SERIE_FACTURA
            txtNroDocFACBOL.Text = ObjVentaCargaContado.v_NRO_FACTURA
            txtNroGuia.Text = ObjVentaCargaContado.v_NRO_GUIA

            Me.Text = " CIUDAD ORIGEN : " & ObjVentaCargaContado.v_UNIDAD_ORIGEN
            txtiWinDestino.Text = ObjVentaCargaContado.v_UNIDAD_DESTINO
            txtFecha.Text = ObjVentaCargaContado.v_FECHA_FACTURA
            Me.chkcargo.Checked = ObjVentaCargaContado.v_cargo


            If flagPCEDatos = True Then
                txtDocCliente_Remitente.Text = ObjVentaCargaContado.v_NRO_DOC_REMITENTE.Trim
                txtCliente_Remitente.Text = ObjVentaCargaContado.v_NOMBRES_REMITENTE
                '04/10/2007 -> Valido nombre de la persona
                s_persona_remitente = ObjVentaCargaContado.v_NOMBRES_REMITENTE

                If ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL <> " " Then
                    txtContactoRemitente.Text = IIf(ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL <> "@", ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL, "")
                Else
                    txtContactoRemitente.Text = ""
                End If
                If ObjVentaCargaContado.v_NRO_DNI_RUC <> " " Then
                    txtDNIContacto.Text = IIf(ObjVentaCargaContado.v_NRO_DNI_RUC <> "@", ObjVentaCargaContado.v_NRO_DNI_RUC, "")
                Else
                    txtDNIContacto.Text = ""
                End If
                txtDireccionRemitente.Focus()
            Else
                txtDocCliente_Remitente.Text = ObjVentaCargaContado.v_NRO_DNI_RUC.Trim
                txtDocCliente_Remitente.Tag = ObjVentaCargaContado.v_idpersona_cli
                txtCliente_Remitente.Text = ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL

                txtContactoRemitente.Text = ObjVentaCargaContado.v_NOMBRES_REMITENTE
                txtDNIContacto.Text = ObjVentaCargaContado.v_NRO_DOC_REMITENTE
                txtDNIContacto.Tag = ObjVentaCargaContado.v_idpersona_ori
            End If

            txtTelefonoRemitente.Text = ObjVentaCargaContado.v_TELEFONO_REMITENTE
            txtPorcernt_Descuento.Text = ObjVentaCargaContado.v_PORCENT_DESCUENTO

            txtDNIDestinatario.Text = ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO
            If flagPCEDatos = False Then
                txtDNIDestinatario.Tag = ObjVentaCargaContado.v_idpersona_des
            End If

            txtCliente_Destinatario.Text = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO
            txtDireccionDestinatario.Text = ObjVentaCargaContado.v_DIRECCION_DESTINATARIO
            '
            Me.txtTelefonoDestinatario.Text = ObjVentaCargaContado.v_TELEFONO_DESTINATARIO
            '
            'txtTelefonoDestinatario.Text = ""
            txtMemo.Text = ObjVentaCargaContado.v_MEMO
            If ObjVentaCargaContado.v_MEMO.Length > 0 Then
                txtMemo.Visible = True
            Else
                txtMemo.Visible = False
            End If

            txtSub_Total.Text = Format(ObjVentaCargaContado.v_MONTO_SUB_TOTAL, "###,###,###.00")
            txtMonto_IGV.Text = Format(ObjVentaCargaContado.v_MONTO_IMPUESTO, "###,###,###.00")
            txtCosto_Total.Text = Format(ObjVentaCargaContado.v_TOTAL_COSTO, "###,###,###.00")
            dtGridViewBultos(2, 0).Value() = ObjVentaCargaContado.v_CANTIDAD_X_PESO
            dtGridViewBultos(4, 0).Value() = ObjVentaCargaContado.v_TOTAL_PESO
            dtGridViewBultos(5, 0).Value() = ObjVentaCargaContado.v_PRECIO_X_PESO
            dtGridViewBultos(6, 0).Value() = ObjVentaCargaContado.v_TOTAL_PESO * ObjVentaCargaContado.v_PRECIO_X_PESO '* ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100
            dtGridViewBultos(7, 0).Value() = ObjVentaCargaContado.v_TOTAL_PESO * ObjVentaCargaContado.v_PRECIO_X_PESO '* (1 - (ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100))

            dtGridViewBultos(2, 1).Value() = ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN
            dtGridViewBultos(4, 1).Value() = ObjVentaCargaContado.v_TOTAL_VOLUMEN
            dtGridViewBultos(5, 1).Value() = ObjVentaCargaContado.v_PRECIO_X_VOLUMEN
            dtGridViewBultos(6, 1).Value() = ObjVentaCargaContado.v_TOTAL_VOLUMEN * ObjVentaCargaContado.v_PRECIO_X_VOLUMEN '* ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100
            dtGridViewBultos(7, 1).Value() = ObjVentaCargaContado.v_TOTAL_VOLUMEN * ObjVentaCargaContado.v_PRECIO_X_VOLUMEN '* (1 - (ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100))

            dtGridViewBultos(2, 2).Value() = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE
            dtGridViewBultos(4, 2).Value() = ""
            dtGridViewBultos(5, 2).Value() = ObjVentaCargaContado.v_PRECIO_X_SOBRE
            dtGridViewBultos(6, 2).Value() = "0.00" 'ObjVentaCargaContado.v_CANTIDAD_X_SOBRE * ObjVentaCargaContado.v_PRECIO_X_SOBRE * ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100
            dtGridViewBultos(7, 2).Value() = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE * ObjVentaCargaContado.v_PRECIO_X_SOBRE

            dtGridViewBultos(5, 3).Value() = Format(ObjVentaCargaContado.v_MONTO_BASE, "###,###.00")
            dtGridViewBultos(6, 3).Value() = "0.00"
            dtGridViewBultos(7, 3).Value() = Format(ObjVentaCargaContado.v_MONTO_BASE, "###,###.00")
            dtGridViewBultos(3, 0).Value() = "BULTOS"
            dtGridViewBultos(3, 1).Value() = "BULTOS"

            'fnTotalPago()

            If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 Then

                lbTargeta.Visible = True
                cmbTargeta.Visible = True
                lbNrotarjeta.Visible = True
                txtNroTarjeta.Visible = True
                ' 08/02/2008 - Modificado 
                'ObjVentaCargaContado.cur_T_TARJETAS.MoveFirst()......,,,
                'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.cur_T_TARJETAS, cmbTargeta, ObjVentaCargaContado.coll_T_TARJETAS, ObjVentaCargaContado.v_IDTARJETAS)
                ' 08/02/2008 - 
                '                ldv_tarjeta = CargarCombo(Me.cmbTargeta, ldt_tarjeta, "DESCRIPCION", "Idtarjetas", ObjVentaCargaContado.v_IDTARJETAS)
                If ObjVentaCargaContado.v_IDTARJETAS = 2 Then
                    Me.cmbTargeta.SelectedValue = 21
                Else
                    If ObjVentaCargaContado.v_IDTARJETAS = 1 Then
                        Me.cmbTargeta.SelectedValue = 19
                    Else
                        Me.cmbTargeta.SelectedValue = ObjVentaCargaContado.v_IDTARJETAS 'Me.cmbTargeta.SelectedValue
                    End If
                End If
                txtNroTarjeta.Text = ObjVentaCargaContado.v_NROTARJETA
            Else
                lbTargeta.Visible = False
                cmbTargeta.Visible = False
                lbNrotarjeta.Visible = False
                txtNroTarjeta.Visible = False
            End If

            'cur_Articulos            Cur_DATOS_VENTA()
            Dim i As Integer = 0
            For i = 1 To dtGridViewArticulo.Rows().Count
                dtGridViewArticulo.Rows().RemoveAt(0)
            Next
            If ObjVentaCargaContado.v_CANTIDAD_X_ARTICULO > 0 Then
                lblMontoBase.Visible = True
                txtMontoBase.Visible = True
                dtGridViewArticulo.Visible = True
                Try
                    'If ObjVentaCargaContado.cur_Articulos.State = 1 Then
                    If ObjVentaCargaContado.dt_cur_Articulos.Rows.Count > 0 Then
                        '
                        dtGridViewArticulo.Visible = True
                        dtGridViewBultos.Visible = False
                        '
                        'Mod.16/09/2009 -->Omendoza - Pasando al datahelper   
                        '
                        'While ObjVentaCargaContado.cur_Articulos.BOF = False And ObjVentaCargaContado.cur_Articulos.EOF = False
                        '    Dim row0 As String() = {Int(ObjVentaCargaContado.cur_Articulos.Fields.Item(0).Value).ToString, ObjVentaCargaContado.cur_Articulos.Fields.Item(1).Value, ObjVentaCargaContado.cur_Articulos.Fields.Item(2).Value.ToString, ObjVentaCargaContado.cur_Articulos.Fields.Item(3).Value.ToString, ObjVentaCargaContado.cur_Articulos.Fields.Item(4).Value.ToString, (ObjVentaCargaContado.cur_Articulos.Fields.Item(2).Value) * (ObjVentaCargaContado.cur_Articulos.Fields.Item(3).Value)}
                        '    dtGridViewArticulo.Rows().Add(row0)
                        '    ObjVentaCargaContado.cur_Articulos.MoveNext()
                        'End While
                        For Each fila As DataRow In ObjVentaCargaContado.dt_cur_Articulos.Rows
                            Dim row0 As String() = {Int(fila.Item(0)).ToString, fila.Item(1), fila.Item(2).ToString, fila.Item(3).ToString, fila.Item(4).ToString, (fila.Item(2)) * (fila.Item(3))}
                            dtGridViewArticulo.Rows().Add(row0)
                        Next
                    End If
                Catch ex As Exception
                    '
                End Try
            Else
                dtGridViewArticulo.Visible = False
                lblMontoBase.Visible = False
                txtMontoBase.Visible = False
            End If
            '
            '18/09/2009
            'If ObjVentaCargaContado.cur_Documentos.State = 1 Then
            If ObjVentaCargaContado.dt_cur_Documentos.Rows.Count > 0 Then
                For i = 1 To DataGridViewDocumentos.Rows().Count - 1
                    DataGridViewDocumentos.Rows().RemoveAt(0)
                Next

                iFilas = 0
                'While ObjVentaCargaContado.cur_Documentos.BOF = False And ObjVentaCargaContado.cur_Documentos.EOF = False
                '    If asignar_seleccionados(ObjVentaCargaContado.cur_Documentos) = True Then
                '        Me.agregar_documentos_asegurados()
                '    End If
                'End While

                For Each fila As DataRow In ObjVentaCargaContado.dt_cur_Documentos.Rows
                    If asignar_seleccionados(ObjVentaCargaContado.dt_cur_Documentos) = True Then
                        Me.agregar_documentos_asegurados()
                    End If
                Next

                Try
                    iContador = 0
                    'ObjVentaCargaContado.cur_Documentos.MoveFirst()
                    'While ObjVentaCargaContado.cur_Documentos.BOF = False And ObjVentaCargaContado.cur_Documentos.EOF = False
                    '    If IsDBNull(ObjVentaCargaContado.cur_Documentos("PORCEN").Value) Then
                    '        If iFilas < iContador Then
                    '            DataGridViewDocumentos.Rows.Add()
                    '        End If
                    '        If Not (ObjVentaCargaContado.cur_Documentos.Fields.Item(1).Value Is Nothing) Then
                    '            iContador += 1
                    '        End If
                    '    End If
                    '    ObjVentaCargaContado.cur_Documentos.MoveNext()
                    'End While
                    '
                    'Mod.16/09/2009 -->Omendoza - Pasando al datahelper   
                    For Each fila As DataRow In ObjVentaCargaContado.dt_cur_Documentos.Rows
                        If IsDBNull(fila.Item("PORCEN")) Then
                            If iFilas < iContador Then
                                DataGridViewDocumentos.Rows.Add()
                            End If
                            If Not (fila.Item(1) Is Nothing) Then
                                iContador += 1
                            End If
                        End If
                    Next
                    '
                    'ObjVentaCargaContado.cur_Documentos.MoveFirst()
                    '
                    iContador = 0

                    'While ObjVentaCargaContado.cur_Documentos.BOF = False And ObjVentaCargaContado.cur_Documentos.EOF = False
                    '    If ObjVentaCargaContado.cur_Documentos.BOF = False And ObjVentaCargaContado.cur_Documentos.EOF = False Then
                    '        If IsDBNull(ObjVentaCargaContado.cur_Documentos("PORCEN").Value) Then
                    '            iContador += 1
                    '            Dim idDoc0 As String = ObjVentaCargaContado.cur_Documentos.Fields.Item(0).Value
                    '            Dim NroDoc0 As String = ObjVentaCargaContado.cur_Documentos.Fields.Item(1).Value
                    '            '
                    '            DataGridViewDocumentos.Rows(iContador - 1).Cells(0).Value = idDoc0
                    '            DataGridViewDocumentos.Rows(iContador - 1).Cells(2).Value = NroDoc0
                    '        End If
                    '        ObjVentaCargaContado.cur_Documentos.MoveNext()
                    '    End If
                    'End While

                    For Each fila As DataRow In ObjVentaCargaContado.dt_cur_Documentos.Rows
                        If IsDBNull(fila.Item("PORCEN")) Then
                            iContador += 1
                            Dim idDoc0 As String = fila.Item(0)
                            Dim NroDoc0 As String = fila.Item(1)
                            '
                            DataGridViewDocumentos.Rows(iContador - 1).Cells(0).Value = idDoc0
                            DataGridViewDocumentos.Rows(iContador - 1).Cells(2).Value = NroDoc0
                        End If
                    Next
                Catch
                End Try
            End If

            '    While ObjVentaCargaContado.cur_Documentos.BOF = False And ObjVentaCargaContado.cur_Documentos.EOF = False
            '        If asignar_seleccionados(ObjVentaCargaContado.cur_Documentos) = False Then
            '            If ObjVentaCargaContado.cur_Documentos.BOF = False And ObjVentaCargaContado.cur_Documentos.EOF = False Then
            '                Dim idDoc0 As String = ObjVentaCargaContado.cur_Documentos.Fields.Item(0).Value
            '                Dim NroDoc0 As String = ObjVentaCargaContado.cur_Documentos.Fields.Item(1).Value
            '                Dim idDoc1 As String = ""
            '                Dim NroDoc1 As String = "-"
            '                ObjVentaCargaContado.cur_Documentos.MoveNext()
            '                If ObjVentaCargaContado.cur_Documentos.BOF = False And ObjVentaCargaContado.cur_Documentos.EOF = False Then
            '                    idDoc1 = ObjVentaCargaContado.cur_Documentos.Fields.Item(0).Value
            '                    NroDoc1 = ObjVentaCargaContado.cur_Documentos.Fields.Item(1).Value
            '                End If
            '                Dim row0 As String() = {idDoc0, idDoc1, NroDoc0, NroDoc1}
            '                DataGridViewDocumentos.Rows().Add(row0)
            '                If ObjVentaCargaContado.cur_Documentos.EOF = False And ObjVentaCargaContado.cur_Documentos.BOF = False Then
            '                    ObjVentaCargaContado.cur_Documentos.MoveNext()
            '                End If
            '            End If
            '        Else
            '            Me.agregar_documentos_asegurados()
            '        End If
            '    End While
            'End If

            If ObjVentaCargaContado.v_CANTIDAD_X_SOBRE > 0 And ObjVentaCargaContado.v_CANTIDAD_X_ARTICULO > 0 Then
                checkSobres.Visible = True
                txtCantidadSobres.Visible = True
                txtTotalSobre.Visible = True
                txtCantidadSobres.Text = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE
                txtTotalSobre.Text = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE * ObjVentaCargaContado.v_PRECIO_X_SOBRE
            Else
                checkSobres.Visible = False
                txtCantidadSobres.Visible = False
                txtTotalSobre.Visible = False
            End If
            txtMontoBase.Text = ObjVentaCargaContado.v_MONTO_BASE

            dtGridViewBultos.ReadOnly = True
            fnEnableStadoControl(True)

            If idControl = 2 Then
                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 1 Then
                    lbFactBoleta.Text = "FACTURA"
                    '
                    Descubrir_contacto_ver_data()
                    Me.Grp_factura.Text = "Contacto "
                    '
                Else
                    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 2 Then
                        lbFactBoleta.Text = "BOLETA DE VENTA"
                    Else
                        If iForma = 3 Then
                            lbFactBoleta.Text = "GUIA DE ENVIO PCE"
                        ElseIf iForma = 4 Then
                            lbFactBoleta.Text = "GUIA ENVIO RECOJO"
                        End If
                    End If
                End If
                If es_carga_asegurada Then
                    lblCarga.Visible = True
                Else
                    lblCarga.Visible = False
                End If

                'hlamas 08-10-2010 carga acompañada
                If bCargaAcompañada Then
                    lblCarga.Text = "--> CARGA ACOMPAÑADA"
                    lblCarga.Visible = True
                Else
                    lblCarga.Text = "--> CARGA ASEGURADA"
                    lblCarga.Visible = False
                End If

            End If

            If idControl = 1 Then
                'txtDNIDestinatario.Enabled = True
                'txtCliente_Destinatario.Enabled = True
                'txtDNIDestinatario.ReadOnly = False
                'txtCliente_Destinatario.ReadOnly = False

                txtDocCliente_Remitente.Enabled = True
                txtCliente_Remitente.Enabled = True
                txtDireccionRemitente.Enabled = True

                txtDocCliente_Remitente.ReadOnly = False
                txtCliente_Remitente.ReadOnly = False
                txtDireccionRemitente.ReadOnly = False

                'txtContactoRemitente.Enabled = True
                'txtDNIContacto.Enabled = True
                'txtContactoRemitente.ReadOnly = False
                'txtDNIContacto.ReadOnly = False

                cmbTipoPago.Enabled = True
                txtDireccionRemitente.Focus()
            End If

            If idControl = 2 Then
                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Then
                    txtSERIE.Visible = False
                    txtNroDocFACBOL.Visible = False
                    txtNroGuia.Visible = True
                Else
                    txtSERIE.Visible = True
                    txtNroDocFACBOL.Visible = True
                    txtNroGuia.Visible = False
                End If
            Else
                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Then
                    If fnValidarRUC(txtDocCliente_Remitente.Text.ToString()) Then
                        lbFactBoleta.Text = "FACTURA"
                        If es_carga_asegurada Then
                            lblCarga.Visible = True
                        Else
                            lblCarga.Visible = False
                        End If

                        'hlamas 08-10-2010 carga acompañada
                        If bCargaAcompañada Then
                            lblCarga.Text = "--> CARGA ACOMPAÑADA"
                            lblCarga.Visible = True
                        Else
                            lblCarga.Text = "--> CARGA ASEGURADA"
                            lblCarga.Visible = False
                        End If


                        bFAC_Bol = True
                        TipoComprobante = 1
                        txtDireccionRemitente.Focus()
                        'txtDocCliente_Remitente.SelectAll()
                        'txtDocCliente_Remitente.Focus()
                        Descubrir_contacto()
                    Else
                        lbFactBoleta.Text = "BOLETA VENTA"
                        If es_carga_asegurada Then
                            lblCarga.Visible = True
                        Else
                            lblCarga.Visible = False
                        End If

                        'hlamas 08-10-2010 carga acompañada
                        If bCargaAcompañada Then
                            lblCarga.Text = "--> CARGA ACOMPAÑADA"
                            lblCarga.Visible = True
                        Else
                            lblCarga.Text = "--> CARGA ASEGURADA"
                            lblCarga.Visible = False
                        End If

                        bFAC_Bol = False
                        TipoComprobante = 2
                        txtDireccionRemitente.Focus()
                    End If

                    'ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 2
                    'TipoComprobante = 2

                    If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, ChkProceso.Checked) = True Then
                        txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                        txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                        txtSERIE.Visible = True
                        txtNroDocFACBOL.Visible = True
                        Me.txtNroGuia.Visible = False
                    ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0) = True Then
                        txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                        txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                        txtSERIE.Visible = True
                        txtNroDocFACBOL.Visible = True
                        Me.txtNroGuia.Visible = False
                    Else
                        MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
                    End If

                End If
            End If


            lbFactBoleta.Update()
            Update()

            'If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Then
            If ObjVentaCargaContado.v_MONTO_MINIMOs > 0 And Not bCargaAcompañada Then
                lblMontoMinimo.Visible = True
                lblMinimo.Visible = True
                lblMontoMinimo.Text = FormatNumber(ObjVentaCargaContado.v_MONTO_MINIMOs, 2)
            Else
                lblMontoMinimo.Visible = False
                lblMinimo.Visible = False
                lblMontoMinimo.Text = ""
            End If

            If dtGridViewArticulo.Visible Then
                lblMontoMinimo.Visible = False
                lblMinimo.Visible = False
                lblMontoMinimo.Text = ""
            End If
            '
            b_no_lee_tipo_entrega = True

            'hlamas 08-10-2010 carga acompañada
            Controla(True)
            bCargaAcompañada2 = False
            Me.TxtBoleto.Text = ObjVentaCargaContado.v_nroboleto
            If ObjVentaCargaContado.v_proceso = 6 And ObjVentaCargaContado.v_nroboleto.Trim.Length > 2 Then
                bCargaAcompañada = True
                bCargaAcompañada2 = True
                Me.TxtBoleto.Enabled = False
                Controla(False)

                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 AndAlso ObjVentaCargaContado.v_facturado = 0 Then
                    Me.TxtBoleto.Enabled = True
                    txtDocCliente_Remitente.ReadOnly = False
                    txtDocCliente_Remitente.Enabled = True
                    txtDocCliente_Remitente.Text = txtDocCliente_Remitente.Text.Trim

                    txtDNIDestinatario.ReadOnly = False
                    txtDNIDestinatario.Enabled = True
                    txtDNIDestinatario.Text = txtDNIDestinatario.Text.Trim

                    txtCliente_Remitente.ReadOnly = False
                    txtCliente_Remitente.Enabled = True
                    txtCliente_Remitente.Text = txtCliente_Remitente.Text.Trim

                    txtCliente_Destinatario.ReadOnly = False
                    txtCliente_Destinatario.Enabled = True
                    txtCliente_Destinatario.Text = txtCliente_Destinatario.Text.Trim

                    'txtDireccionRemitente.ReadOnly = False
                    'txtDireccionRemitente.Enabled = True

                    'txtDireccionDestinatario.ReadOnly = False
                    'txtDireccionDestinatario.Enabled = True

                    'txtTelefonoRemitente.ReadOnly = True
                    'txtTelefonoRemitente.Enabled = False

                    'txtTelefonoDestinatario.ReadOnly = False
                    'txtTelefonoDestinatario.Enabled = True

                    txtDNIContacto.ReadOnly = False
                    txtDNIContacto.Enabled = True
                    txtDNIContacto.Text = txtDNIContacto.Text.Trim

                    txtContactoRemitente.ReadOnly = False
                    txtContactoRemitente.Enabled = True
                    txtContactoRemitente.Text = txtContactoRemitente.Text.Trim
                End If
            Else
                If ObjVentaCargaContado.v_proceso = 7 Then
                    'Me.ChkProceso.Enabled = False
                    iProceso = 7
                    'Me.ChkProceso.Checked = True
                End If

                bCargaAcompañada = False
                bCargaAcompañada2 = False
                Me.TxtBoleto.Enabled = True

                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Then
                    If ObjVentaCargaContado.v_proceso = 6 Then
                        Me.TxtBoleto.Visible = True
                        Me.LblBoleto.Visible = True
                        Controla(False)
                    Else
                        Me.TxtBoleto.Visible = False
                        Me.LblBoleto.Visible = False
                    End If
                End If
                End If

                If bCargaAcompañada Then
                    lblCarga.Text = "--> CARGA ACOMPAÑADA"
                    lblCarga.Visible = True
                Else
                    lblCarga.Text = "--> CARGA ASEGURADA"
                    lblCarga.Visible = False
                End If

                Me.txtiWinDestino.Enabled = False
                Me.txtiWinDestino.ReadOnly = True

        Catch ex As Exception
            Controla(True)
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function
    'Private Function asignar_seleccionados(ByVal rst As ADODB.Recordset) As Boolean
    '    asignar_seleccionados = False
    '    Dim indice As Integer = 0
    '    If rst.EOF = False And rst.BOF = False Then
    '        While rst.EOF = False And rst.BOF = False
    '            If Not rst.Fields.Item("fecha").Value Is DBNull.Value Then
    '                Try
    '                    objComprobanteAsegurada(indice).ID_GUIAS_ENVIO_DOC = rst.Fields.Item("ID_GUIAS_ENVIO_DOC").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).IDGUIAS_ENVIO = rst.Fields.Item("IDGUIAS_ENVIO").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).IDTIPO_COMPROBANTE = rst.Fields.Item("IDTIPO_COMPROBANTE").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).NRO_SERIE = rst.Fields.Item("NRO_SERIE").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).NRO_DOCU = rst.Fields.Item("NRO_DOCU").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).IDUSUARIO_PERSONAL = rst.Fields.Item("IDUSUARIO_PERSONAL").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).IDUSUARIO_PERSONALMOD = rst.Fields.Item("IDUSUARIO_PERSONALMOD").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).IDROL_USUARIO = rst.Fields.Item("IDROL_USUARIO").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).IDROL_USUARIOMOD = rst.Fields.Item("IDROL_USUARIOMOD").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).IP = rst.Fields.Item("IP").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).IPMOD = rst.Fields.Item("IPMOD").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).FECHA_REGISTRO = rst.Fields.Item("FECHA_REGISTRO").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).FECHA_ACTUALIZACION = rst.Fields.Item("FECHA_ACTUALIZACION").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).IDESTADO_REGISTRO = rst.Fields.Item("IDESTADO_REGISTRO").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).FECHA = rst.Fields.Item("FECHA").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO = rst.Fields.Item("MONTO_TIPO_CAMBIO").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).MONTO_SUB_TOTAL = rst.Fields.Item("MONTO_SUB_TOTAL").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).MONTO_IMPUESTO = rst.Fields.Item("MONTO_IMPUESTO").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).TOTAL_COSTO = rst.Fields.Item("TOTAL_COSTO").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).OBS = rst.Fields.Item("OBS").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).IDTIPO_MONEDA = rst.Fields.Item("IDTIPO_MONEDA").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).PORCEN = rst.Fields.Item("PORCEN").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).TIPO = rst.Fields.Item("TIPO_MONTO").Value
    '                Catch
    '                End Try
    '                Try
    '                    objComprobanteAsegurada(indice).PROCEDENCIA = rst.Fields.Item("IND_PROCEDENCIA").Value
    '                Catch
    '                End Try
    '                asignar_seleccionados = True
    '            End If
    '            indice = indice + 1
    '            rst.MoveNext()
    '        End While
    '        'rst.MoveFirst()
    '    End If
    'End Function
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

    Private Sub precio_carga_asegurada()
        If es_carga_asegurada = True Then
            'dtGridViewBultos(6, 0).Value = "0.00"
            'dtGridViewBultos(6, 1).Value = "0.00"
            'dtGridViewBultos(6, 2).Value = "0.00"
            'dtGridViewBultos(6, 3).Value = "0.00"


            'dtGridViewBultos(7, 0).Value = "0.00"
            'dtGridViewBultos(7, 1).Value = "0.00"
            'dtGridViewBultos(7, 2).Value = "0.00"
            'dtGridViewBultos(7, 3).Value = "0.00"
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

                        'Me.txtSub_TotalF.Text = FormatNumber(Val(Me.txtSub_TotalF.Text) + (objComprobanteAsegurada(k).PORCEN / (1 + objComprobanteAsegurada(indice).PORCEN_IMPUESTO / 100)), 2)
                        'iSub = objComprobanteAsegurada(k).PORCEN / (1 + objComprobanteAsegurada(indice).PORCEN_IMPUESTO / 100)
                        'Me.txtMonto_IGVF.Text = FormatNumber(Val(Me.txtMonto_IGVF.Text) + (iSub * (objComprobanteAsegurada(indice).PORCEN_IMPUESTO / 100)), 2)
                        'Me.txtCosto_TotalF.Text = FormatNumber(Val(Me.txtCosto_TotalF.Text) + (objComprobanteAsegurada(k).PORCEN), 2)
                    End If
                End If
            Next
            'pendiente

            txtSub_Total.Text = Replace(txtSub_Total.Text, ",", "")
            txtMonto_IGV.Text = Replace(txtMonto_IGV.Text, ",", "")
            txtCosto_Total.Text = Replace(txtCosto_Total.Text, ",", "")
            txtSub_Total.Text = Val(txtSub_Total.Text) + cdblsub_total
            txtMonto_IGV.Text = Val(txtMonto_IGV.Text) + cdblmonto_IGV
            txtCosto_Total.Text = Val(txtCosto_Total.Text) + cdblcosto_total
            'dtGridViewBultos(7, 0).Value = Format(cdblsub_total, "###,###,###.00")
            'dtGridViewBultos(6, 0).Value = Format(cdblsub_total, "###,###,###.00")

        End If
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
        Me.Timer1.Stop()
        'Label5.Visible = False

    End Sub

    Public Function fnTotalPago() As Boolean
        Dim flag As Boolean = False
        Try
            Dim PorcentajeDesc As Double = Val(txtPorcernt_Descuento.Text.ToString) / 100
            Dim Peso_Peso As Double = Val(IIf(dtGridViewBultos(4, 0).Value Is Nothing, 0, dtGridViewBultos(4, 0).Value))
            Dim Peso_Volumen As Double = Val(IIf(dtGridViewBultos(4, 1).Value Is Nothing, 0, dtGridViewBultos(4, 1).Value))
            Dim Nor_Sobres As Double = Val(IIf(dtGridViewBultos(2, 2).Value Is Nothing, 0, dtGridViewBultos(2, 2).Value))

            Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            Dim SubTotal_Costo As Double = 0
            Dim ivol As Double = 0
            If dtGridViewBultos(2, 1).Value <> Nothing And dtGridViewBultos(4, 1).Value <> Nothing And dtGridViewBultos(4, 1).Value <> Nothing Then
                ivol = Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(2, 1).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(4, 1).Value.ToString)
            End If
            Dim ipes As Double = 0
            If dtGridViewBultos(2, 0).Value <> Nothing And dtGridViewBultos(4, 0).Value <> Nothing Then
                ipes = Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(2, 0).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(4, 0).Value.ToString)
            End If

            'los precios estan cambiando a cero

            'dtGridViewBultos(5, 0).Value = Peso_Peso * tarifa_Peso * PorcentajeDesc
            'dtGridViewBultos(5, 1).Value = Peso_Volumen * tarifa_Volumen * PorcentajeDesc
            'dtGridViewBultos(5, 2).Value = tarifa_Sobre * Nor_Sobres * PorcentajeDesc


            dtGridViewBultos(6, 0).Value = Peso_Peso * tarifa_Peso * (1 - PorcentajeDesc)
            dtGridViewBultos(6, 1).Value = Peso_Volumen * tarifa_Volumen * (1 - PorcentajeDesc)
            dtGridViewBultos(6, 2).Value = tarifa_Sobre * Nor_Sobres * (1 - PorcentajeDesc)
            '----------------------------------------------------------------------------------------------------------------------------
            If Monto_Base > 0 Then
                ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
            End If
            'If iControlFacturacion > 0 Then
            '    ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
            'Else
            '    If iControlMonto_Base = 0 Then
            '        ObjVentaCargaContado.v_MONTO_BASE = 0
            '        Monto_Base = 0
            '    Else
            '        ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
            '    End If
            'End If
            '----------------------------------------------------------------------------------------------------------------------------
            If Peso_Peso * tarifa_Peso + Peso_Volumen * tarifa_Volumen > 0 Then
                If iControlMonto_Base = 1 Then
                    If bCondicion Then
                        SubTotal_Costo = (Monto_Base + objGuiaEnvio.iPrecio_cond_Peso + Peso_Volumen * tarifa_Volumen + tarifa_Sobre * Nor_Sobres) '* (1 - PorcentajeDesc)
                    Else
                        SubTotal_Costo = (Monto_Base + Peso_Peso * tarifa_Peso + Peso_Volumen * tarifa_Volumen + tarifa_Sobre * Nor_Sobres) '* (1 - PorcentajeDesc)
                    End If
                Else
                    If bCondicion Then
                        SubTotal_Costo = (objGuiaEnvio.iPrecio_cond_Peso + Peso_Volumen * tarifa_Volumen + tarifa_Sobre * Nor_Sobres) '* (1 - PorcentajeDesc)
                    Else
                        SubTotal_Costo = (Peso_Peso * tarifa_Peso + Peso_Volumen * tarifa_Volumen + tarifa_Sobre * Nor_Sobres) '* (1 - PorcentajeDesc)
                    End If
                End If
            Else
                If bCondicion Then
                    SubTotal_Costo = (objGuiaEnvio.iPrecio_cond_Peso + Peso_Volumen * tarifa_Volumen + tarifa_Sobre * Nor_Sobres) '* (1 - PorcentajeDesc)
                Else
                    SubTotal_Costo = (Peso_Peso * tarifa_Peso + Peso_Volumen * tarifa_Volumen + tarifa_Sobre * Nor_Sobres) '* (1 - PorcentajeDesc)
                End If
            End If
            '  Dim SUB_TOTAL_GENERAL As Double = fnTECHO(Format((1 + IGV) * SubTotal_Costo, "###,###,###.00"))
            ' Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            'If bCondicion Then
            ' SubTotal_Costo = objGuiaEnvio.iPrecio_cond_Peso
            'End If

            txtSub_Total.Text = SubTotal_Costo
            txtMonto_IGV.Text = IGV * SubTotal_Costo
            txtCosto_Total.Text = SubTotal_Costo + IGV * SubTotal_Costo

            'hlamas 30-10-2008
            If bTarifarioGeneral And bContado Then
                txtSub_Total.Text = Format(SubTotal_Costo / (1 + IGV), "###,###,###.0000") '01/09/2010 
                txtMonto_IGV.Text = IGV * SubTotal_Costo
                txtCosto_Total.Text = SubTotal_Costo
            End If

            precio_carga_asegurada()

            SubTotal_Costo = txtSub_Total.Text

            Dim SUB_TOTAL_GENERAL As Double = 0
            If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) > 0 Then
                SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.000")) '01/09/2010 

                'hlamas 30-10-2008
                If bTarifarioGeneral Then
                    'SUB_TOTAL_GENERAL = fnTECHO(Format(SubTotal_Costo * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00"))
                End If
            Else
                If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            Dim varID As Integer = ObjVentaCargaContado.coll_t_Forma_Pago(cmbFormaPago.SelectedIndex.ToString)
            iForma = varID
            If varID = 4 Then varID = 3

            If varID = 3 Then

                If (SUB_TOTAL_GENERAL / IIf(Val(PorcentajeDesc) = 0, 1, PorcentajeDesc) < Me.objCargaAsegurada.monto_minimo_PCE And fArticulo = False) And (Not bCargaAcompañada2) Then

                    txtSub_Total.Text = Format(Me.objCargaAsegurada.monto_minimo_PCE / (1 + IGV), "###,###,###.00")
                    txtMonto_IGV.Text = Format(IGV * Me.objCargaAsegurada.monto_minimo_PCE / (1 + IGV), "###,###,###.00")
                    txtCosto_Total.Text = Format(Me.objCargaAsegurada.monto_minimo_PCE)
                    bMontoMinimo = True
                Else
                    txtSub_Total.Text = Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
                    txtMonto_IGV.Text = Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
                    txtCosto_Total.Text = Format(SUB_TOTAL_GENERAL, "###,###,###.00")
                    bMontoMinimo = False
                End If
            Else
                txtSub_Total.Text = Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
                txtMonto_IGV.Text = Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
                txtCosto_Total.Text = Format(SUB_TOTAL_GENERAL, "###,###,###.00")
            End If

            If bMontoMinimo And varID = 3 And Not bCargaAcompañada Then
                lblMontoMinimo.Text = Format(Me.objCargaAsegurada.monto_minimo_PCE, "###,###,###.00")
                lblMinimo.Visible = True
                lblMontoMinimo.Visible = True
                txtPorcernt_Descuento.ReadOnly = True
                txtPorcernt_Descuento.Text = ""
                txtMemo.Text = ""
                txtMemo.ReadOnly = True
            Else
                lblMontoMinimo.Text = 0
                lblMinimo.Visible = False
                lblMontoMinimo.Visible = False
                txtPorcernt_Descuento.ReadOnly = False
                txtMemo.ReadOnly = False
            End If
            'txtSub_Total.Text = Format(SubTotal_Costo, "000,000,000.00")
            'txtMonto_IGV.Text = Format(IGV * SubTotal_Costo, "000,000,000.00")
            'txtCosto_Total.Text = Format((1 + IGV) * SubTotal_Costo, "000,000,000.0")
        Catch ex As Exception
            txtSub_Total.Text = "0.00"
            txtMonto_IGV.Text = "0.00"
            txtCosto_Total.Text = "0.00"
            flag = False
        End Try
        Return flag
    End Function
    Public Function fnNUEVO() As Boolean
        Try
            'hlamas 06-08-2010 carga acompañada
            bCargaAcompañada = False
            bCargaAcompañada2 = False
            Me.TxtBoleto.Text = ""
            Me.TxtBoleto.Enabled = True
            Me.lblCarga.Text = "--> CARGA ASEGURADA"
            Me.lblCarga.Visible = False

            lblTotalPagado.Visible = False
            lblTotalVenta.Visible = False
            lblVuelto.Visible = False
            txtTotalPagado.Visible = False
            txtTotalVenta.Visible = False
            txtVuelto.Visible = False
            '
            ' 01/10/2007 - Limpiando la variable 

            recuperando_datos_contado = False
            dtGridViewBultos.Enabled = True
            dtGridViewArticulo.Enabled = True
            DataGridViewDocumentos.Enabled = True

            es_carga_asegurada = False
            If dtGridViewBultos.Rows.Count = 5 Then
                dtGridViewBultos.Rows.RemoveAt(4)
            End If
            ObjVentaCargaContado.v_IDPERSONA = 0
            objGuiaEnvio.iIDPERSONA = 0
            '
            flagPCEVALIDADOC = False
            ObjVentaCargaContado.V_CONTROL_PCE = False
            ObjVentaCargaContado.v_UNIDAD_ORIGEN = dtoUSUARIOS.m_iNombreUnidadAgencia

            strNroGuias_Remision = ""
            flagPCE = False
            If bControlFiscalizacion = False Then
                Me.txtFecha.Text = dtoUSUARIOS.m_sFecha
            End If
            '04/10/2007 - Inicializando variables
            s_persona_remitente = ""
            '
            objGuiaEnvio.iPeso_Maximo = 0
            objGuiaEnvio.iPrecio_cond_Peso = 0
            txtiWinDestino.Text = ""
            txtNroDocFACBOL.Text = ""
            txtNroTarjeta.Text = ""
            txtDocCliente_Remitente.Text = ""
            txtCliente_Remitente.Text = ""
            txtDireccionRemitente.Text = ""
            txtContactoRemitente.Text = ""
            txtDNIContacto.Text = ""
            txtTelefonoRemitente.Text = ""
            txtPorcernt_Descuento.Text = ""
            txtDNIDestinatario.Text = ""
            txtCliente_Destinatario.Text = ""
            txtDireccionDestinatario.Text = ""
            txtTelefonoDestinatario.Text = ""
            txtSub_Total.Text = "0.00"
            txtMonto_IGV.Text = "0.00"
            txtCosto_Total.Text = "0.00"
            bCondicion = False

            iSub_Total_CA = 0
            iImpuesto_CA = 0
            iTotal_CA = 0

            txtiWinDestino.Enabled = True
            txtNroTarjeta.Enabled = True
            txtDocCliente_Remitente.Enabled = True
            txtCliente_Remitente.Enabled = True
            txtDireccionRemitente.Enabled = True
            txtContactoRemitente.Enabled = True
            txtDNIContacto.Enabled = True
            txtTelefonoRemitente.Enabled = True
            txtPorcernt_Descuento.Enabled = True
            txtDNIDestinatario.Enabled = True
            txtCliente_Destinatario.Enabled = True
            txtDireccionDestinatario.Enabled = True
            txtTelefonoDestinatario.Enabled = True
            lblCarga.Visible = False
            'lblMontoBase.Text = ""


            'Me.Timer1.Stop()
            'Label5.Visible = False

            txtiWinDestino.ReadOnly = False
            txtNroTarjeta.ReadOnly = False
            txtDocCliente_Remitente.ReadOnly = False
            txtCliente_Remitente.ReadOnly = False
            txtDireccionRemitente.ReadOnly = False
            txtContactoRemitente.ReadOnly = False
            txtDNIContacto.ReadOnly = False
            txtTelefonoRemitente.ReadOnly = False
            txtPorcernt_Descuento.ReadOnly = False
            txtDNIDestinatario.ReadOnly = False
            txtCliente_Destinatario.ReadOnly = False
            txtDireccionDestinatario.ReadOnly = False
            txtTelefonoDestinatario.ReadOnly = False
            chkcargo.Checked = False
            iOficinaDestino = 0

            txtMemo.Visible = False
            lbMemo.Visible = False
            txtMemo.Text = ""
            txtPorcernt_Descuento.Visible = True
            txtPorcernt_Descuento.ReadOnly = False

            Dim i As Integer = 0
            For i = 0 To dtGridViewBultos.Rows.Count - 1
                dtGridViewBultos(2, i).Value() = ""

                dtGridViewBultos(4, i).Value() = "0.00"
                dtGridViewBultos(5, i).Value() = "0.00"
                dtGridViewBultos(6, i).Value() = "0.00"
                dtGridViewBultos(7, i).Value() = "0.00"
            Next
            dtGridViewBultos(3, 0).Value() = "BULTOS"
            dtGridViewBultos(3, 1).Value() = "BULTOS"

            'ObjVentaCargaContado.cur_Tipo_Pago.MoveFirst()
            'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.cur_Tipo_Pago, cmbTipoPago, ObjVentaCargaContado.coll_Tipo_Pago, 1)
            '21/09/2009 - 
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_Tipo_Pago, cmbTipoPago, ObjVentaCargaContado.coll_Tipo_Pago, 1)
            'ObjVentaCargaContado.cur_t_Tipo_Entrega.MoveFirst()
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_t_Tipo_Entrega, cmbTipo_Entrega, ObjVentaCargaContado.coll_t_Tipo_Entrega, 1)
            '
            'ObjVentaCargaContado.cur_t_Forma_Pago.MoveFirst()
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_t_Forma_Pago, cmbFormaPago, ObjVentaCargaContado.coll_t_Forma_Pago, 1)
            '
            'Modificado 08/02/2008 
            'ObjVentaCargaContado.cur_T_TARJETAS.MoveFirst()
            'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.cur_T_TARJETAS, cmbTargeta, ObjVentaCargaContado.coll_T_TARJETAS, 1)
            '
            cmbTargeta.SelectedValue = 1  'Por defecto saldra visa  08/02/2008
            '
            cmbAgenciaVenta.DropDownStyle = ComboBoxStyle.DropDownList
            cmbAgenciaVenta.Controls.Clear()
            cmbAgenciaVenta.Items.Clear()

            lbFactBoleta.Text = "..."
            'txtiWinDestino.Focus()


            lbTargeta.Visible = False
            cmbTargeta.Visible = False
            lbNrotarjeta.Visible = False
            txtNroTarjeta.Visible = False
            Me.Text = "VENTAS CARGA....." & dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & " [ " & dtoUSUARIOS.m_iNombreAgencia & " ] ** [ " & dtoUSUARIOS.m_iNombreUnidadAgencia & " ]"
            If bOtrasAgencias = False Then
                ObjVentaCargaContado.fnClearOBJ(2)
            End If
            lbFactBoleta.Text = "BOLETA VENTA"
            If es_carga_asegurada Then
                lblCarga.Visible = True
            Else
                lblCarga.Visible = False
            End If

            'hlamas 08-10-2010 carga acompañada
            If bCargaAcompañada Then
                lblCarga.Text = "--> CARGA ACOMPAÑADA"
                lblCarga.Visible = True
            Else
                lblCarga.Text = "--> CARGA ASEGURADA"
                lblCarga.Visible = False
            End If


            bFAC_Bol = False
            'TipoComprobante = 2
            If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, ChkProceso.Checked) = True Then
                txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
            ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0) = True Then
                txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
            Else
                MsgBox("No podrá realizar esta Operación el Nº de Factura/Boleta no está configurado")
            End If

            If Me.dtGridViewBultos.Visible = False Then
                fnControl_Articulos()
            End If

            For i = 1 To DataGridViewDocumentos.Rows.Count - 1
                DataGridViewDocumentos.Rows().RemoveAt(0)
            Next
            DataGridViewDocumentos.Rows(0).Cells(0).Value = ""
            DataGridViewDocumentos.Rows(0).Cells(1).Value = ""
            DataGridViewDocumentos.Rows(0).Cells(2).Value = ""
            DataGridViewDocumentos.Rows(0).Cells(3).Value = ""

            Dim row11 As String() = {"", "", "", ""}
            'DataGridViewDocumentos.Rows().Add(row11)
            'DataGridViewDocumentos.Rows().Add(row11)
            For i = 0 To 2
                dtGridViewBultos(2, i).Value() = ""
                dtGridViewBultos(3, i).Value() = ""
                dtGridViewBultos(4, i).Value() = "0.00"
                dtGridViewBultos(5, i).Value() = "0.00"
            Next
            For i = 1 To dtGridViewArticulo.Rows.Count
                dtGridViewArticulo.Rows().RemoveAt(0)
            Next
            fArticulo = False
            dtGridViewBultos.Visible = True
            dtGridViewArticulo.Visible = False
            lbArticulos.Text = "( F11 ) ARTICULOS"
            dtGridViewBultos.Focus()
            checkSobres.Visible = False
            txtCantidadSobres.Text = 0
            txtTotalSobre.Text = 0
            txtTotalSobre.Visible = False
            txtCantidadSobres.Visible = False
            lblMinimo.Visible = False
            lblMontoMinimo.Text = ""
            lblMontoMinimo.Visible = False

            fnEnableStadoControl(False)
            lbNombresRasonSocial.Text = "Cliente-remi "
            lbFacturador.Text = "Contacto : "
            txtiWinDestino.Focus()
            valorf3 = False

            iOficinaDestino = 0

            If bOtrasAgencias = False Then
                ObjVentaCargaContado.v_UNIDAD_ORIGEN = dtoUSUARIOS.m_iNombreUnidadAgencia
                'iOficinaOrigen = 0
            Else
                ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_rstVarAgencias_1, cmbAgenciaOrigen, ObjVentaCargaContado.coll_AgenciasOrigen, Int(dtoUSUARIOS.m_iIdAgencia.ToString))
                ' loco
            End If

            txtOrigen.Text = ""
            txtOrigen.Visible = False

            If bOtrasAgencias Then
                cmbAgenciaOrigen.Visible = True
            End If

            If bOtrasAgencias = False Then
                'iOrigen2 = 0
                'ObjVentaCargaContado.v_IDAGENCIAS = 0
                'ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = 0
                'objGuiaEnvio.iIDUNIDAD_AGENCIA = 0
                'cmbAgenciaOrigen.SelectedIndex = -1
                'cmbAgenciaOrigen.SelectedValue = 0
                cmbAgenciaOrigen.Focus()
            End If
            txtMontoBase.Text = "0.00"
            lblMontoBase.Visible = False
            txtMontoBase.Visible = False
            txtPorcernt_Descuento.ReadOnly = False
            txtPorcernt_Descuento.Enabled = True
            ' 02/06/2009 - Por defecto debe volver al usuario inicial, la agencia origen y la unidad destino 
            ObjVentaCargaContado.v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
            ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad

            recuperando_datos_contado = False
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Function

    Private Sub dtGridViewBultos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewBultos.CellEnter
        'If e.RowIndex = 4 Then
        '    dtGridViewBultos.CurrentRow.ReadOnly = True
        'Else
        '    dtGridViewBultos.CurrentRow.ReadOnly = False
        'End If


    End Sub

    Private Sub txtDocCliente_Remitente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDocCliente_Remitente.TextChanged
        s_persona_remitente = ""
        Me.txtDocCliente_Remitente.Tag = 0
        If bCargaAcompañada And bTecla Then
            bValida = True
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            Dim iResp As Integer
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index

            Dim iFactura As String = dtGridViewControl_FACBOL.Rows(row).Cells("idfactura").Value
            Dim iDocumento As Integer = dtGridViewControl_FACBOL.Rows(row).Cells("Idtipo_Comprobante").Value

            'iResp = MessageBox.Show("¿Desea Imprimir el Documento?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            'If iResp = vbYes Then
            'fnImprimirBOLETA()
            'End If
            imprime(iDocumento, iFactura)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub imprime(ByVal documento As Integer, ByVal factura As Integer)
        Dim obj As New Imprimir
        Try
            Dim ldt_cur_datos_venta As New DataTable
            Dim lds_tmp As New DataSet
            '
            Dim flag As Boolean = False
            Dim iSubTotal As Double = 0, iImpuesto As Double = 0, iTotal As Double = 0
            lds_tmp = ObjVentaCargaContado.fn_SP_VER_VENTACONTADO_I(factura)
            '
            ldt_cur_datos_venta = lds_tmp.Tables(0)
            '
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
                    iTamaño = dt.Rows(0).Item("tamaño")
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
                        obj.EscribirLinea(y + 1, 48, ldt_cur_datos_venta.Rows(0).Item("agencia_destino") & v_ca)
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

                    If CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")) >= 400 Then
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
                        obj.EscribirLinea(0, 30, v_ca)
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

                    ObjRptGuiaEnvio.p_Hora_Guia = fnGetHora()
                    If ldt_cur_datos_venta.Rows(0).Item("es_carga_asegurada") = 1 Then
                        obj.EscribirLinea(y, 22, ldt_cur_datos_venta.Rows(0).Item("Nro_Guia") & v_ca)
                    Else
                        obj.EscribirLinea(y, 22, ldt_cur_datos_venta.Rows(0).Item("Nro_Guia"))
                    End If
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
                    obj.EscribirLinea(y + 9, 0, "FACTURAR A: " & ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                    obj.EscribirLinea(y + 8, 29, ldt_cur_datos_venta.Rows(0).Item("telefono"))
                    obj.EscribirLinea(y + 8, 59, ldt_cur_datos_venta.Rows(0).Item("destino"))
                    obj.EscribirLinea(y + 8, 84, IIf(IsDBNull(ldt_cur_datos_venta.Rows(0).Item("telefono_consignado")), "", ldt_cur_datos_venta.Rows(0).Item("telefono_consignado")))
                    obj.EscribirLinea(y + 17, 26, Format(CDate(ldt_cur_datos_venta.Rows(0).Item("fecha_factura")), "dd     MM      yy"))
                    obj.EscribirLinea(y + 13, 49, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso")) + CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")), 2))
                    obj.EscribirLinea(y + 13, 57, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso")), 2))
                    obj.EscribirLinea(y + 13, 65, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")), 2))
                    obj.EscribirLinea(y + 13, 78, ldt_cur_datos_venta.Rows(0).Item("fecha_factura"))
                    obj.EscribirLinea(y + 13, 92, ldt_cur_datos_venta.Rows(0).Item("hora_factura"))
                    obj.EscribirLinea(y + 14, 57, "N. SOBRES " & ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Sobre"))

                    obj.Comprimido = True
                    obj.Preliminar = True
                    obj.Tamaño = iLong
                    obj.Imprimir()
                    obj.Finalizar()

                    Dim frm As New FrmPreview
                    frm.Documento = 3
                    frm.Tamaño = iLong
                    frm.Text = "PCE Guía de Envío"
                    frm.ShowDialog()


                    '    ObjRptGuiaEnvio.p_Hora_Guia = fnGetHora()
                    '    If ldt_cur_datos_venta.Rows(0).Item("es_carga_asegurada") = 1 Then
                    '        objImprimir.Agregar(210, 25, ldt_cur_datos_venta.Rows(0).Item("Nro_Guia") & v_ca)
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

        Catch ex As Exception
            obj.finalizar()
            Throw New Exception(ex.Message)
        End Try
    End Sub

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

    Private Sub LimpiarCA()
        Dim i As Integer = 0

        For Each obj As ClsLbTepsa.dtoCargaAsegurada.ComprobanteAsegurada In objComprobanteAsegurada
            i += 1
            objComprobanteAsegurada(i).ID_GUIAS_ENVIO_DOC = Nothing
            objComprobanteAsegurada(i).FECHA = Nothing
            objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO = Nothing
            objComprobanteAsegurada(i).IDTIPO_MONEDA = Nothing
            objComprobanteAsegurada(i).IDTIPO_COMPROBANTE = Nothing
            objComprobanteAsegurada(i).NRO_SERIE = Nothing
            objComprobanteAsegurada(i).NRO_DOCU = Nothing
            objComprobanteAsegurada(i).MONTO_IMPUESTO = Nothing
            objComprobanteAsegurada(i).TOTAL_COSTO = Nothing
            objComprobanteAsegurada(i).PORCEN = Nothing
            objComprobanteAsegurada(i).OBS = Nothing
            objComprobanteAsegurada(i).PROCEDENCIA = Nothing
        Next
    End Sub

    Private Sub txtOrigen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrigen.TextChanged
        iOficinaDestino = 0
    End Sub

    Private Sub txtOrigen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOrigen.Validating
        If coll_iOrigen.Count = 0 Then Return
        Dim iOrigen As Integer
        'iOrigen = iWinOrigen.IndexOf(txtOrigen2.Text)

        If iOrigen >= 0 Then
            iOrigen = Int(coll_iOrigen.Item(iOrigen.ToString))
            ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = iOrigen
            objGuiaEnvio.iIDUNIDAD_AGENCIA = iOrigen
            'sOrigen = txtOrigen2.Text.Trim.ToUpper
        Else
            'txtOrigen2.Text = sOrigen
        End If

        If iOficinaOrigen <> iOrigen Then
            txtiWinDestino_Validating(sender, e)
        End If

        iOficinaOrigen = iOrigen
    End Sub


    Public Function fnInprecion_Guia_Envio() As Boolean
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double

        Try
            ObjRptGuiaEnvio.p_Hora_Guia = fnGetHora()
            Dim objImpresora As New dtoVentaCargaContado
            If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Then
                ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3
            End If

            Dim sImpresora As String = Imprimir.ObtieneImpresora(3, dtoUSUARIOS.IP)
            If sImpresora.Trim.Length > 0 Then
                Dim obj As New Imprimir
                obj.Inicializar()
                obj.Impresora = sImpresora
                If es_carga_asegurada Then
                    'objImprimir.Agregar(210, 25, ObjRptGuiaEnvio.p_NroGUIA & v_ca)
                    obj.EscribirLinea(ObjRptGuiaEnvio.p_NroGUIA & v_ca)
                Else
                    'objImprimir.Agregar(210, 25, ObjRptGuiaEnvio.p_NroGUIA)
                    obj.EscribirLinea(ObjRptGuiaEnvio.p_NroGUIA)
                End If

                'objImprimir.Agregar(485, 15, ObjRptGuiaEnvio.p_codigo_iata_ori)
                obj.EscribirLinea(ObjRptGuiaEnvio.p_codigo_iata_ori)
                'objImprimir.Agregar(545, 15, ObjRptGuiaEnvio.p_codigo_iata_desti)
                obj.EscribirLinea(ObjRptGuiaEnvio.p_codigo_iata_desti)
                'objImprimir.Agregar(0, 55, ObjRptGuiaEnvio.p_ruc)
                obj.EscribirLinea(ObjRptGuiaEnvio.p_ruc)
                'objImprimir.Agregar(25, 105, ObjRptGuiaEnvio.P_REMITENTE)
                obj.EscribirLinea(ObjRptGuiaEnvio.P_REMITENTE)
                'objImprimir.Agregar(25, 120, ObjRptGuiaEnvio.P_DIRECCION_REMI)
                obj.EscribirLinea(ObjRptGuiaEnvio.P_DIRECCION_REMI)
                'objImprimir.Agregar(355, 105, ObjRptGuiaEnvio.P_NOMBRES_DESTI)
                obj.EscribirLinea(ObjRptGuiaEnvio.P_NOMBRES_DESTI)
                'objImprimir.Agregar(355, 120, ObjRptGuiaEnvio.P_DIRECCION_DESTI)
                obj.EscribirLinea(ObjRptGuiaEnvio.P_DIRECCION_DESTI)

                'objImprimir.Agregar(190, 55, p_domicilio)
                obj.EscribirLinea(p_domicilio)
                'objImprimir.Agregar(245, 55, p_agencia)
                obj.EscribirLinea(p_agencia)
                'objImprimir.Agregar(310, 55, p_contado)
                obj.EscribirLinea(p_contado)
                'objImprimir.Agregar(370, 55, p_destino)
                obj.EscribirLinea(p_destino)
                'objImprimir.Agregar(435, 55, p_credito)
                obj.EscribirLinea(p_credito)

                'objImprimir.Agregar(570, 55, ObjRptGuiaEnvio.P_CARGO)
                obj.EscribirLinea(ObjRptGuiaEnvio.P_CARGO)
                'objImprimir.Agregar(25, 175, ObjRptGuiaEnvio.p_contacto)
                obj.EscribirLinea(ObjRptGuiaEnvio.p_contacto)

                'objImprimir.Agregar(162, 155, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI)
                obj.EscribirLinea(ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI)
                'objImprimir.Agregar(370, 155, ObjRptGuiaEnvio.P_PROVINCIA)
                obj.EscribirLinea(ObjRptGuiaEnvio.P_PROVINCIA)
                'objImprimir.Agregar(525, 155, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI)
                obj.EscribirLinea(ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI)

                If Not (strNroGuias_Remision Is Nothing) Then
                    If Val(strNroGuias_Remision.Trim.Length) < 126 Then
                        strNroGuias_Remision = strNroGuias_Remision & Space(126 - Len(strNroGuias_Remision.Trim))
                    End If
                    strNroGuias_Remision = Mid(strNroGuias_Remision.Trim, 1, 126)

                    Dim iGuiones As Integer
                    iGuiones = DevuelveGuiones(strNroGuias_Remision)
                    If iGuiones >= 7 Then       '3 lineas
                        'objImprimir.Agregar(20, 210, Trim(Mid(strNroGuias_Remision, 1, 42)))
                        obj.EscribirLinea(Trim(Mid(strNroGuias_Remision, 1, 42)))
                        'objImprimir.Agregar(20, 225, Trim(Mid(strNroGuias_Remision, 43, 42)))
                        obj.EscribirLinea(Trim(Mid(strNroGuias_Remision, 43, 42)))
                        'objImprimir.Agregar(20, 240, Trim(Mid(strNroGuias_Remision, 86, 42)))
                        obj.EscribirLinea(Trim(Mid(strNroGuias_Remision, 86, 42)))
                    ElseIf iGuiones >= 4 Then   '2 lineas
                        'objImprimir.Agregar(20, 210, Trim(Mid(strNroGuias_Remision, 1, 42)))
                        obj.EscribirLinea(Trim(Mid(strNroGuias_Remision, 1, 42)))
                        'objImprimir.Agregar(20, 225, Trim(Mid(strNroGuias_Remision, 43, 42)))
                        obj.EscribirLinea(Trim(Mid(strNroGuias_Remision, 43, 42)))
                    Else                        '1 linea
                        'objImprimir.Agregar(20, 210, Trim(Mid(strNroGuias_Remision, 1, 42)))
                        obj.EscribirLinea(Trim(Mid(strNroGuias_Remision, 1, 42)))
                    End If
                End If

                'objImprimir.Agregar(155, 300, Format(CDate(ObjRptGuiaEnvio.P_FECHA_GUIA), "dd     MM      yy"))
                obj.EscribirLinea(Format(CDate(ObjRptGuiaEnvio.P_FECHA_GUIA), "dd     MM      yy"))

                'objImprimir.Agregar(280, 235, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_BULTOS), 2))
                obj.EscribirLinea(FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_BULTOS), 2))
                'objImprimir.Agregar(330, 235, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_PESO), 2))
                obj.EscribirLinea(FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_PESO), 2))
                'objImprimir.Agregar(380, 235, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_VOLUMEN), 2))
                obj.EscribirLinea(FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_VOLUMEN), 2))

                'objImprimir.Agregar(450, 240, dtoUSUARIOS.m_sFecha)
                obj.EscribirLinea(dtoUSUARIOS.m_sFecha)
                'objImprimir.Agregar(535, 240, ObjRptGuiaEnvio.p_Hora_Guia)
                obj.EscribirLinea(ObjRptGuiaEnvio.p_Hora_Guia)
                'objImprimir.Agregar(300, 252, "Nº SOBRES " & ObjRptGuiaEnvio.P_TOTAL_SOBRES)
                obj.EscribirLinea("Nº SOBRES " & ObjRptGuiaEnvio.P_TOTAL_SOBRES)

                obj.Imprimir()
                obj.Finalizar()

            Else
                Dim flag = objImpresora.fnSP_Buscar_Impresora(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE, dtoUSUARIOS.IP)
                If flag Then
                    Dim objImprimir As New ImprimirTexto("Draft Condensed", 8, objImpresora.v_Impresora, "guia", 1305, 1305)
                    If es_carga_asegurada Then
                        objImprimir.Agregar(210, 25, ObjRptGuiaEnvio.p_NroGUIA & v_ca)
                    Else
                        objImprimir.Agregar(210, 25, ObjRptGuiaEnvio.p_NroGUIA)
                    End If

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

                    If Not (strNroGuias_Remision Is Nothing) Then
                        If Val(strNroGuias_Remision.Trim.Length) < 126 Then
                            strNroGuias_Remision = strNroGuias_Remision & Space(126 - Len(strNroGuias_Remision.Trim))
                        End If
                        strNroGuias_Remision = Mid(strNroGuias_Remision.Trim, 1, 126)

                        Dim iGuiones As Integer
                        iGuiones = DevuelveGuiones(strNroGuias_Remision)
                        If iGuiones >= 7 Then       '3 lineas
                            objImprimir.Agregar(20, 210, Trim(Mid(strNroGuias_Remision, 1, 42)))
                            objImprimir.Agregar(20, 225, Trim(Mid(strNroGuias_Remision, 43, 42)))
                            objImprimir.Agregar(20, 240, Trim(Mid(strNroGuias_Remision, 86, 42)))
                        ElseIf iGuiones >= 4 Then   '2 lineas
                            objImprimir.Agregar(20, 210, Trim(Mid(strNroGuias_Remision, 1, 42)))
                            objImprimir.Agregar(20, 225, Trim(Mid(strNroGuias_Remision, 43, 42)))
                        Else                        '1 linea
                            objImprimir.Agregar(20, 210, Trim(Mid(strNroGuias_Remision, 1, 42)))
                        End If
                    End If

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
                    'MessageBox.Show("El Documento no tiene asociado una impresora.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ObjReport As New ClsLbTepsa.dtoFrmReport
                    ObjReport.rutaRpt = PathFrmReport

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
                    "P_TOTAL_VOLUMEN;" & FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_VOLUMEN), 2), _
                    "P_TOTAL_PESO;" & FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_PESO), 2), _
                    "P_SOBRES;" & "NRO SOBRES : " & ObjRptGuiaEnvio.P_TOTAL_SOBRES, _
                    "P_CONTACTO;" & ObjRptGuiaEnvio.p_contacto, _
                    "P_LOGIN;" & " ", _
                    "P_NRO_GUIA;" & ObjRptGuiaEnvio.p_NroGUIA, _
                    "P_HORA_GUIA;" & ObjRptGuiaEnvio.p_Hora_Guia, _
                    "P_FECHA_RECIBIDO;" & dtoUSUARIOS.m_sFecha, _
                    "P_PROVINCIA;" & ObjRptGuiaEnvio.P_PROVINCIA & IIf(es_carga_asegurada = True, v_ca, ""), _
                    "P_CLIE_CARGO;" & ObjRptGuiaEnvio.P_CARGO)

                End If
            End If

            'Dim ObjReport As New ClsLbTepsa.dtoFrmReport
            'ObjReport.rutaRpt = PathFrmReport

            'ObjReport.printrptlpt(True, "", "GUI007.RPT", _
            '"p_domicilio;" & p_domicilio, _
            '"p_agencia;" & p_agencia, _
            '"p_contado;" & p_contado, _
            '"p_destino;" & p_destino, _
            '"p_credito;" & p_credito, _
            '"p_ruc;" & ObjRptGuiaEnvio.p_ruc, _
            '"p_codigo_iata_ori;" & ObjRptGuiaEnvio.p_codigo_iata_ori, _
            '"p_codigo_iata_desti;" & ObjRptGuiaEnvio.p_codigo_iata_desti, _
            '"P_NROCOMUNICACION_CONTACTO_ORI;" & ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI, _
            '"P_NROCOMUNICACION_CONTACTO_DESTI;" & ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI, _
            '"P_REMITENTE;" & ObjRptGuiaEnvio.P_REMITENTE, _
            '"P_DIRECCION_REMI;" & ObjRptGuiaEnvio.P_DIRECCION_REMI, _
            '"P_DIRECCION_DESTI;" & ObjRptGuiaEnvio.P_DIRECCION_DESTI, _
            '"P_NOMBRES_DESTI;" & ObjRptGuiaEnvio.P_NOMBRES_DESTI, _
            '"P_DOCUMENTOS;" & Mid(strNroGuias_Remision, 1, 80), _
            '"P_FECHA_GUIA;" & Format(CDate(ObjRptGuiaEnvio.P_FECHA_GUIA), "dd     MM      yy"), _
            '"P_TOTAL_BULTOS;" & FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_BULTOS), 2), _
            '"P_TOTAL_VOLUMEN;" & FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_VOLUMEN), 2), _
            '"P_TOTAL_PESO;" & FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_PESO), 2), _
            '"P_SOBRES;" & "NRO SOBRES : " & ObjRptGuiaEnvio.P_TOTAL_SOBRES, _
            '"P_CONTACTO;" & ObjRptGuiaEnvio.p_contacto, _
            '"P_LOGIN;" & " ", _
            '"P_NRO_GUIA;" & ObjRptGuiaEnvio.p_NroGUIA, _
            '"P_HORA_GUIA;" & ObjRptGuiaEnvio.p_Hora_Guia, _
            '"P_FECHA_RECIBIDO;" & dtoUSUARIOS.m_sFecha, _
            '"P_PROVINCIA;" & ObjRptGuiaEnvio.P_PROVINCIA & IIf(es_carga_asegurada = True, v_ca, ""), _
            '"P_CLIE_CARGO;" & ObjRptGuiaEnvio.P_CARGO)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function
    'Public Function sp_linea_credito_2009() As ADODB.Recordset
    '    Try
    '        Dim Obj As Object() = {"sp_linea_credito", 4, Iid, 2}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function
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
            '
            '
            '    Dim ls_sql As String
            '    Dim db_bd As New BaseDatos
            '    Dim ldt_tmp As DataTable            'conecta con la Bd
            '    '
            '    db_bd.Conectar()
            '    db_bd.CrearComando("sp_linea_credito", CommandType.StoredProcedure)
            '    'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '    db_bd.AsignarParametro("ni_idpersona", Iid, OracleClient.OracleType.Int32)
            '    'Variables de salidas 
            '    db_bd.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            '    'Desconectar 
            '    db_bd.Desconectar()
            '    '
            '    ldt_tmp = db_bd.EjecutarDataTable
            '    '
            '    Return ldt_tmp
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
            '    Throw New Exception(ex.Excepcion)
        End Try
        '
    End Function

    Private Sub txtNroSerieDoc_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtNroSerieDoc.MaskInputRejected

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

    'Public Function fnImprimirEtiquetasFAC_IIN95() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim prn As New PrinterTxt.PrintTxt
    '        Dim cadena As String = ""
    '        Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
    '        prn.Nombre_impresora = NOMBRE_IMPRESORA
    '        Dim EXISTE As Boolean = prn.SetearImpresora()

    '        Dim I As Int16 = 0
    '        Dim j As Int16 = 1
    '        While I <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
    '            ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(I)(0).ToString
    '            'Dim I As Int16 = 1
    '            'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
    '            'ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
    '            prn.EscribeLinea("<STX><ESC>C0<ETX>")
    '            prn.EscribeLinea("<STX><ESC>k<ETX>")
    '            prn.EscribeLinea("<STX><SI>N60<ETX>")
    '            prn.EscribeLinea("<STX><SI>L197<ETX>")
    '            prn.EscribeLinea("<STX><SI>S20<ETX>")
    '            prn.EscribeLinea("<STX><SI>d0<ETX>")
    '            prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
    '            prn.EscribeLinea("<STX><SI>l8<ETX>")
    '            prn.EscribeLinea("<STX><SI>I3<ETX>")
    '            prn.EscribeLinea("<STX><SI>F20<ETX>")
    '            prn.EscribeLinea("<STX><SI>D0<ETX>")
    '            prn.EscribeLinea("<STX><SI>t0<ETX>")
    '            prn.EscribeLinea("<STX><SI>W394<ETX>")
    '            prn.EscribeLinea("<STX><SI>g1,567<ETX>")
    '            prn.EscribeLinea("<STX><ESC>P<ETX>")
    '            prn.EscribeLinea("<STX>E*;F*;<ETX>")
    '            prn.EscribeLinea("<STX>L1;<ETX>")
    '            prn.EscribeLinea("<STX>D0;<ETX>")
    '            prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h15;w15;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
    '            prn.EscribeLinea("<STX>D1;<ETX>")
    '            prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
    '            prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
    '            'prn.EscribeLinea("<STX>B3;o96,180;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
    '            prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
    '            prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
    '            prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
    '            prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
    '            prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
    '            prn.EscribeLinea("<STX>R<ETX>")
    '            prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
    '            prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")

    '            prn.EscribeLinea(cadena)
    '            'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
    '            'I = I + 1
    '            j = j + 1
    '            I += 1
    '        End While
    '        prn.FinDoc()
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    'Public Function fnImprimirEtiquetasFAC_IIN97() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim prn As New PrinterTxt.PrintTxt
    '        Dim cadena As String = ""
    '        Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
    '        prn.Nombre_impresora = NOMBRE_IMPRESORA
    '        Dim EXISTE As Boolean = prn.SetearImpresora()

    '        'Dim I As Int16 = 1
    '        'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
    '        'ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
    '        Dim I As Int16 = 0
    '        Dim j As Int16 = 1
    '        While I <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
    '            ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(I)(0).ToString
    '            prn.EscribeLinea("N")
    '            prn.EscribeLinea("N")
    '            prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
    '            prn.EscribeLinea("A30,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
    '            prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
    '            prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
    '            prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
    '            prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")
    '            prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")
    '            prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
    '            prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
    '            prn.EscribeLinea("P1")
    '            prn.EscribeLinea("N")
    '            prn.EscribeLinea(cadena)
    '            j = j + 1
    '            I += 1
    '            'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
    '            'I = I + 1
    '        End While
    '        prn.FinDoc()
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Private Sub cmbAgenciaVenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgenciaVenta.SelectedIndexChanged

    End Sub
    '04/03/2009 - Se valida el tipo de entrega, indicar que solo con PCE deberá ser en Agencia 
    Sub cambio_tipo_entrega(ByVal al_tipo_entrega As Long)
        Try
            Dim iidTipo As Integer = ObjVentaCargaContado.coll_t_Tipo_Entrega(cmbTipo_Entrega.SelectedIndex.ToString)
            'loco
            txtDireccionDestinatario.Text = "AGENCIA"
            Me.cmbTipo_Entrega.SelectedIndex = 0 'Agencia 
            Me.txtDireccionDestinatario.Text = "AGENCIA"
            '
            If al_tipo_entrega = 3 Then
                txtDireccionDestinatario.Enabled = False
                Me.cmbTipo_Entrega.Enabled = False
            Else
                txtDireccionDestinatario.Enabled = True
                Me.cmbTipo_Entrega.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub txtMontoBase_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMontoBase.TextChanged

    End Sub
    Sub ocultar_contacto()
        Me.Grp_factura.Visible = False
        Me.txtDNIContacto.Visible = False
        Me.txtDNIContacto.Text = ""
        Label40.Visible = False
        lbFacturador.Visible = False
        txtContactoRemitente.Visible = False
        txtContactoRemitente.Text = ""
    End Sub
    Sub Descubrir_contacto()
        Me.Grp_factura.Visible = True
        Me.txtDNIContacto.Visible = True
        Me.txtDNIContacto.Text = ""
        Label40.Visible = True
        lbFacturador.Visible = True
        txtContactoRemitente.Visible = True
        txtContactoRemitente.Text = ""
    End Sub
    Sub Descubrir_contacto_ver_data()
        Me.Grp_factura.Visible = True
        Me.txtDNIContacto.Visible = True
        Label40.Visible = True
        lbFacturador.Visible = True
        txtContactoRemitente.Visible = True
    End Sub

    Private Sub cmbTargeta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTargeta.SelectedIndexChanged
        If frmb_lee = True Then
            If txtNroTarjeta.Visible = True Then
                Me.txtNroTarjeta.Focus()
            Else
                Me.txtDocCliente_Remitente.Focus()
            End If
        End If
    End Sub

    Private Sub FrmCargaAsegurada_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Sub Grabar()
        Try
            Dim b As Boolean = True
            If flagPCE And Me.TxtBoleto.Visible Then
                If Me.TxtBoleto.Text.Trim.Length < 2 Then
                    b = False
                ElseIf Not bCargaAcompañada Then
                    b = False
                End If
            End If
            If Not b Then
                MessageBox.Show("Debe asociar un boleto a este comprobante de venta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            If recuperando_datos_contado And bCargaAcompañada And lbFactBoleta.Text.Substring(0, 1) = "G" And Me.TxtBoleto.ReadOnly = False And ObjVentaCargaContado.v_facturado = 0 Then 'carga acompañada
                Dim s As String = Me.TxtBoleto.Text.Trim
                Dim obj As New dtoVentaCargaContado
                If bCargaAcompañada2 = False Then
                    bCargaAcompañada = False
                    s = ""
                End If
                obj.ActualizaCargaAcompañada(iIdFactura, s, txtCliente_Destinatario.Text, txtDNIDestinatario, txtContactoRemitente.Text, txtDNIContacto, txtCliente_Remitente.Text, txtDocCliente_Remitente, txtTelefonoRemitente.Text.Trim)
                MessageBox.Show("Registro Grabado.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bCargaAcompañada = False
                bCargaAcompañada2 = False
                fnNUEVO()
                limpiar_documentos_cliente()
                iOficinaDestino = 0
                iOficinaOrigen = 0
                Return
            ElseIf recuperando_datos_contado And bCargaAcompañada And flagPCE And Me.TxtBoleto.ReadOnly = False And ObjVentaCargaContado.v_facturado = 0 Then 'carga acompañada
                Dim s As String = Me.TxtBoleto.Text.Trim
                Dim obj As New dtoVentaCargaContado
                If bCargaAcompañada2 = False Then
                    bCargaAcompañada = False
                    s = ""
                End If
                obj.ActualizaCargaAcompañada(iIdFactura, s)
                'MessageBox.Show("Registro Grabado.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'bCargaAcompañada = False
                'bCargaAcompañada2 = False
                'fnNUEVO()
                'limpiar_documentos_cliente()
                'iOficinaDestino = 0
                'iOficinaOrigen = 0

            ElseIf flagPCE And bCargaAcompañada And lbFactBoleta.Text.Substring(0, 1) <> "G" And ObjVentaCargaContado.v_facturado = 1 Then
                Return
            End If
            If recuperando_datos_contado And flagPCE = False Then
                Exit Sub
            End If

            If TabMante.SelectedIndex = 0 Then
                SendKeys.Send("{Tab}")
                GoTo FINAL
            End If

            If control_venta = True Then
                fnNUEVO()
                limpiar_documentos_cliente()
            End If

            If Val(txtPorcernt_Descuento.Text) = 0 Then
                txtPorcernt_Descuento.Text = ""
            End If

            If TipoComprobante = 1 Then
                If txtDocCliente_Remitente.Text.ToString.Length = 11 Then
                    If fnValidarRUC(txtDocCliente_Remitente.Text.ToString) = False Then
                        MsgBox("No puede realizar esta Operacion de Factura, el Nro de Docuemnto es Invalido")
                        Return
                    End If
                Else
                    MsgBox("No puede realizar esta Operacion de Factura, el Nro de Docuemnto es Invalido", MsgBoxStyle.Information, "Seguriadad Sistema")
                    Return
                End If
            End If

            If txtCliente_Remitente.Text.Trim = "" Then
                MsgBox("No Puede Realizar esta Operacion no tiene Cliente remitente ...", MsgBoxStyle.Information, "Seguridad Sistema")
                txtCliente_Remitente.Text = ""
                txtCliente_Remitente.Focus()
                Return
            End If
            If txtCliente_Destinatario.Text.Trim = "" Then
                MsgBox("No Puede Realizar esta Operacion no tiene Cliente Destinatario ...", MsgBoxStyle.Information, "Seguridad Sistema")
                txtCliente_Destinatario.Text = ""
                txtCliente_Destinatario.Focus()
                Return
            End If
            '
            If Me.txtTelefonoRemitente.Text = "" Or Len(Me.txtTelefonoRemitente.Text) < 7 Then
                ErrorProvider.SetError(Me.txtTelefonoRemitente, "Debe Ingresar el telefono del remitente es obligatorio o los digitos del teléfono son pocos...")
                Me.txtTelefonoRemitente.Focus()
                Return
            End If
            '
            Dim varDescuento As Integer = IIf(txtPorcernt_Descuento.Text <> "", txtPorcernt_Descuento.Text, 0)

            If Val(txtCosto_Total.Text) <= 0 And varDescuento <> 100 Then
                MsgBox("No Puede Realizar esta Operacion no tiene monto afecto...,No Tiene el Descuento Apropiado", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim varIdFormaPago As Integer = Int(ObjVentaCargaContado.coll_t_Forma_Pago.Item(cmbFormaPago.SelectedIndex.ToString()))
            iForma = varIdFormaPago
            If varIdFormaPago = 4 Then varIdFormaPago = 3
            If varIdFormaPago = 3 Then
                If txtContactoRemitente.Text = "" Then
                    MsgBox("No puede Realizar esta Operacion, debe tener un nombre de Facturador... ", MsgBoxStyle.Information, "Seguridad Sistema")
                    txtContactoRemitente.Focus()
                    Return
                End If
            End If
            'Confirmar 

            If fnGrabar() = True Then
                'ObjVentaCargaContado.fnIncrementarNroDoc(TipoComprobante)
                'ObjVentaCargaContado.fnIncrementarNroDoc(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)

                If ObjVentaCargaContado.fnNroDocuemnto(2, Me.ChkProceso.Checked) = True Then
                    txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                    txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)

                    txtSERIE.Visible = True
                    txtNroDocFACBOL.Visible = True

                    txtNroGuia.Visible = False
                    txtNroGuia.Text = ""
                ElseIf ObjVentaCargaContado.fnNroDocuemnto(2, 0) = True Then
                    txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                    txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)

                    txtSERIE.Visible = True
                    txtNroDocFACBOL.Visible = True

                    txtNroGuia.Visible = False
                    txtNroGuia.Text = ""
                Else
                    MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
                    Return
                End If
                sDocCliente = ""
                bBoleto = False
            End If
FINAL:
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub

    Private Sub btnSeguro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeguro.Click
        Seguro()
    End Sub

    Private Sub btnClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClientes.Click
        Clientes()
    End Sub

    Private Sub btnArticulos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArticulos.Click
        fnControl_Articulos()
    End Sub

    Sub Seguro()
        Try
            If dtGridViewArticulo.Visible = False And flagPCE = False Then
                Dim A As New FrmDocCliente

                A.sFecha = txtFecha.Text
                A.bVentaGrabada = recuperando_datos_contado
                A.sDocCliente = sDocCliente
                'A.ShowDialog()
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

    Sub Clientes()
        Try
            If txtDocCliente_Remitente.Focused = True Or txtCliente_Remitente.Focused = True Then
                If txtCliente_Remitente.Text <> "" Then
                    If fnMantenimienteCliente(1, txtDocCliente_Remitente, txtCliente_Remitente, txtDireccionRemitente, 1, 1) = True Then
                    End If
                End If
            End If

            If txtContactoRemitente.Focused = True Or txtDNIContacto.Focused = True Then
                If txtContactoRemitente.Text <> "" Then
                    If fnMantenimienteCliente(2, txtDNIContacto, txtContactoRemitente, txtDireccionRemitente, 1, 2) = True Then
                    End If
                End If
            End If
            If txtCliente_Destinatario.Focused = True Or txtDNIDestinatario.Focused = True Then
                If txtCliente_Destinatario.Text <> "" Then
                    If fnMantenimienteCliente(3, txtDNIDestinatario, txtCliente_Destinatario, txtDireccionDestinatario, 1, 2) = True Then

                    End If
                End If
            End If
            '    txtCantidad_Peso.Focus()
            'txtCantidad_Peso.SelectAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevo.EnabledChanged, btnAnular.EnabledChanged, btnDevolucion.EnabledChanged, btnVerData.EnabledChanged, btnImprimir.EnabledChanged, btnPCE.EnabledChanged, btnTIKET.EnabledChanged, btnCerrar.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Public Function ImprimirBoleta() As Boolean
        Dim obj As New Imprimir
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        Try
            Dim HoraSistema As String = fnGetHora()
            Dim GLOSA2 As String = ""
            Dim PESO As String = ""
            Dim PARCIAL As String = ""
            Dim CANTIDAD As String = ""
            '
            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                CANTIDAD = ObjIMPRESIONFACT_BOL.xCantidad_Peso & Chr(13)
                GLOSA2 = "BULTOS" & Chr(13)
                PESO = ObjIMPRESIONFACT_BOL.xTotalPeso & Chr(13)
                PARCIAL = Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "####,###,###.00") & Chr(13)
            End If

            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Vol & "" & Chr(13)
                GLOSA2 = GLOSA2 & "BULTOS (V.)" & Chr(13)
                PESO = PESO & ObjIMPRESIONFACT_BOL.xTotalVolumen & Chr(13)
                PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "####,###,###.00") & Chr(13)
            End If

            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Sobre & ""
                GLOSA2 = GLOSA2 & "SOBRES"
                PESO = PESO & ""
                PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "####,###,###.00")
            End If

            Dim Detalle As String = CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Vol)
            Detalle = Detalle & "  SOBRE'S: " & CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString
            GLOSA2 = "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString & Chr(13) & "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString
            '"P_DETALLE;" & "CANTIDAD: " & CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Sobre) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Vol), _
            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(dtGridViewBultos(7, 2).Value)
            ObjReport.rutaRpt = PathFrmReport

            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 2)
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
            Dim iLong As Integer = IIf(iTamaño = 0, 18, iTamaño)

            y = iLong * pagina + 4
            y += 1
            i += 1

            If flag Then
                obj.Inicializar()
                obj.Impresora = sImpresora
                obj.Superior = iSuperior
                obj.Izquierda = Iizquierda

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

                obj.Comprimido = True
                obj.Tamaño = iLong
                obj.Imprimir()
                obj.Finalizar()

                'Dim frm As New FrmPreview
                'frm.Tamaño = iTamaño
                'frm.Text = "Boleta"
                'frm.ShowDialog()
            End If

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

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
                    obj.EscribirLinea(y + 6, 0, ObjRptGuiaEnvio.P_DIRECCION_REMI)
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
            End If

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

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

            Dim GLOSA2 As String = ""
            Dim PESO As String = ""
            Dim PARCIAL As String = ""
            Dim CANTIDAD As String = ""

            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                CANTIDAD = ObjIMPRESIONFACT_BOL.xCantidad_Peso & Chr(13)
                GLOSA2 = "BULTOS" & Chr(13)
                PESO = ObjIMPRESIONFACT_BOL.xTotalPeso & Chr(13)
                PARCIAL = Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "####,###,###.00") & Chr(13)
            End If

            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Vol & "" & Chr(13)
                GLOSA2 = GLOSA2 & "BULTOS (V.)" & Chr(13)
                PESO = PESO & ObjIMPRESIONFACT_BOL.xTotalVolumen & Chr(13)
                PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "####,###,###.00") & Chr(13)
            End If

            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Sobre & ""
                GLOSA2 = GLOSA2 & "SOBRES"
                PESO = PESO & ""
                PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "####,###,###.00")
            End If


            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(dtGridViewBultos(7, 2).Value)


            If CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString) >= 400 Then

                glosa3 = "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON " & Chr(13) & _
                "EL GOBIERNO CENTRAL ,  SEGÚN D.L. Nº  940 - R.S. Nº 158 -2006-SUNAT  / D.S. " & Chr(13) & _
                "Nº 033-2006-MTC." & Chr(13) & _
                "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829."
            Else
                glosa3 = ""
            End If

            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 1)
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
                Dim iLong As Integer = IIf(iTamaño = 0, 36, iTamaño)

                y = iLong * pagina + 4
                y += 1
                i += 1
                If es_carga_asegurada Then
                    obj.EscribirLinea(y + 1, 48, ObjIMPRESIONFACT_BOL.xAgenciaDestino & v_ca)
                Else
                    obj.EscribirLinea(y + 1, 48, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                End If

                'obj.EscribirLinea(4, 30, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
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

                If CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString) >= 400 Then
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

    Function ObtieneTipoDocumento(ByVal tipo As Integer)
        Dim valor As Integer
        Select Case tipo
            Case 1
                valor = 9
            Case 2
                valor = 3
            Case 3
                valor = 2
            Case 4
                valor = 99
            Case 5
                valor = 5
            Case 6
                valor = 22
            Case 8
                valor = 1
            Case 9
                valor = 22
            Case Else
                valor = 9
        End Select
        Return valor
    End Function
    Private Sub TxtBoleto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBoleto.TextChanged
        bCargaAcompañada2 = False
        Me.lblCarga.Text = "-->CARGA ASEGURADA"
        Me.lblCarga.Visible = False
        sBoleto = ""
        iOficinaDestino = 0
        Controla(True)
        Me.LblTipoPasajero.Visible = False
        Me.txtiWinDestino.ReadOnly = False

        If Not recuperando_datos_contado Then
            txtTelefonoRemitente.Text = ""

            Me.txtiWinDestino.Text = ""
            Me.txtiWinDestino.Enabled = True

            Me.txtDocCliente_Remitente.Text = ""
            Me.txtDocCliente_Remitente.Enabled = True

            Me.txtCliente_Remitente.Text = ""
            Me.txtCliente_Remitente.Enabled = True

            Me.txtDNIDestinatario.Text = ""
            Me.txtDNIDestinatario.Enabled = True

            Me.txtCliente_Destinatario.Text = ""
            Me.txtCliente_Destinatario.Enabled = True
        End If

        bIngresa = True
        flagPCEVALIDADOC = True
        fnVALIDARDOCUMENTOS()
        Me.ocultar_contacto()
        bIngresa = False
        flagPCEVALIDADOC = False

        Me.lblCarga.Text = "-->CARGA ASEGURADA"
        Me.lblCarga.Visible = False
    End Sub

    Private Sub TxtBoleto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBoleto.Validated
        Try
            sDocCliente = ""
            If Me.TxtBoleto.ReadOnly Or Me.TxtBoleto.Text.Trim.Length <= 1 Then Return
            If Me.lbFactBoleta.Text.Substring(0, 1) <> "G" Then
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
            sql = sql & "P.NroDocumento DOCIDENTIDAD, upper(P.ApellidoPaterno) APPATERNO, "
            sql = sql & "UPPER(P.ApellidoMaterno) APMATERNO, "
            sql = sql & "UPPER(P.Nombres) NOMBRES, V.NroAsiento, upper(R.LocalidadOrigen) ORIGEN, "
            sql = sql & "UPPER(R.LocalidadDestino) DESTINO, "
            sql = sql & "if(V.TipoOperacion='', 'V', 'A') VENTA, V.idPasajero IDPASAJERO, P.PasajeroFrecuente, "
            sql = sql & "codCiudadOrigen,P.idtipodocumento tipo, P.telefono "
            sql = sql & "FROM VtaPasajes V "
            sql = sql & "INNER JOIN Clientes P ON (V.idPasajero = P.idCliente) "
            sql = sql & "INNER JOIN Rutas R ON (V.idRuta = R.idRuta) "
            sql = sql & "WHERE V.NroBoleto='" & sDoc & "' "
            Dim dt As DataTable = ObtieneDT(sql)
            CargarBoleto(dt)

        Catch ex As Exception
            bBoleto = False
            Controla(True)
            bCargaAcompañada = False
            Me.txtiWinDestino.ReadOnly = False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbAgenciaOrigen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgenciaOrigen.SelectedIndexChanged
        Dim iOrigen As Integer

        If bOtrasAgencias Then
            If cmbAgenciaOrigen.SelectedIndex = -1 Then
                Exit Sub
            End If
        End If

        ObjVentaCargaContado.v_IDAGENCIAS = Int(ObjVentaCargaContado.coll_AgenciasOrigen(cmbAgenciaOrigen.SelectedIndex.ToString))
        'Mod.16/09/2009 -->Omendoza - Pasando al datahelper   
        ObjVentaCargaContado.fnGetUnidadAgencia(ObjVentaCargaContado.v_IDAGENCIAS)
        iOrigen = ObjVentaCargaContado.dt_rstAgencias.Rows(0).Item(0)
        'If ObjVentaCargaContado.rstAgencias.Fields(0).Value > 0 Then
        If ObjVentaCargaContado.dt_rstAgencias.Rows(0).Item(0) > 0 Then
            ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = iOrigen
            objGuiaEnvio.iIDUNIDAD_AGENCIA = iOrigen
        End If

        If iOrigen2 <> iOrigen Then
            iOficinaDestino = 0
            Dim ee As EventArgs
            txtiWinDestino_Validating(sender, ee)
        End If

        iOrigen2 = iOrigen
    End Sub

    Sub CargarBoleto(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            If sBoleto = TxtBoleto.Text.Trim Then
                Return
            End If
            sBoleto = TxtBoleto.Text.Trim
            Dim sql As String
            'verifica si boleto está asociado a algun documento (guia,boleta,factura)
            Dim dt2 As DataTable
            If Not BoletoAsociado(sBoleto, dt2) Then
                Dim iEstado As Integer = IIf(dt.Rows(0).Item("venta") = "V", 1, 0)
                If iEstado = 1 Then
                    bValida = False
                    bTecla = False
                    bBoleto = True
                    Controla(False)
                    Me.txtiWinDestino.ReadOnly = True
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
                    Me.LblTipoPasajero.Text = IIf(iPasajeroFrecuente = 1, "PASAJERO FRECUENTE", "PASAJERO NORMAL")

                    Dim sender1 As New Object
                    Dim ee As New System.ComponentModel.CancelEventArgs
                    txtDocCliente_Remitente_Leave(sender1, ee)
                    txtDocCliente_Remitente_Validating(sender1, ee)

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

                    txtiWinDestino.Text = sDestino
                    bCargaAcompañada = True
                    bCargaAcompañada2 = True

                    iOficinaDestino = 0

                    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE <> 85 Then
                        Dim sender As Object
                        Dim e As New System.ComponentModel.CancelEventArgs
                        txtiWinDestino_Validating(sender, e)
                    End If

                    Dim sNombres As String = dt.Rows(0).Item("appaterno").ToString.Trim & " " & dt.Rows(0).Item("apmaterno").ToString.Trim & " " & dt.Rows(0).Item("nombres").ToString.Trim

                    If dt.Rows(0).Item("docidentidad").ToString.Trim.Length > 0 Then
                        txtDocCliente_Remitente.Text = dt.Rows(0).Item("docidentidad")
                        txtDocCliente_Remitente.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                    ElseIf txtDocCliente_Remitente.Text.Trim.Length = 0 Then
                        txtDocCliente_Remitente.Text = dt.Rows(0).Item("docidentidad")
                        txtDocCliente_Remitente.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                    End If
                    txtCliente_Remitente.Text = sNombres

                    txtDNIDestinatario.Text = dt.Rows(0).Item("docidentidad")
                    txtDNIDestinatario.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                    txtCliente_Destinatario.Text = sNombres

                    If lbFactBoleta.Text.Substring(0, 1) = "G" Then
                        txtDNIContacto.Text = dt.Rows(0).Item("docidentidad")
                        txtDNIContacto.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                        txtContactoRemitente.Text = sNombres
                    End If

                    txtTelefonoRemitente.Text = IIf(IsDBNull(dt.Rows(0).Item("telefono")), "", dt.Rows(0).Item("telefono"))

                    Me.LblTipoPasajero.Visible = True
                    'bCargaAcompañada = True
                    'bCargaAcompañada2 = True

                    Me.lblCarga.Text = "-->CARGA ACOMPAÑADA"
                    Me.lblCarga.Visible = True

                    'Me.txtiWinDestino.ReadOnly = False

                    txtDocCliente_Remitente.ReadOnly = False
                    txtDocCliente_Remitente.Enabled = True

                    txtDNIDestinatario.ReadOnly = False
                    txtDNIDestinatario.Enabled = True

                    txtCliente_Remitente.ReadOnly = False
                    txtCliente_Remitente.Enabled = True

                    txtCliente_Destinatario.ReadOnly = False
                    txtCliente_Destinatario.Enabled = True

                    'txtDireccionRemitente.ReadOnly = False
                    'txtDireccionRemitente.Enabled = True

                    'txtDireccionDestinatario.ReadOnly = False
                    'txtDireccionDestinatario.Enabled = True

                    'txtTelefonoRemitente.ReadOnly = False
                    'txtTelefonoRemitente.Enabled = True

                    'txtTelefonoDestinatario.ReadOnly = False
                    'txtTelefonoDestinatario.Enabled = True

                    txtDNIContacto.ReadOnly = False
                    txtDNIContacto.Enabled = True

                    txtContactoRemitente.ReadOnly = False
                    txtContactoRemitente.Enabled = True

                    bEntra = True
                Else    'anulado
                    MessageBox.Show("El Boleto de Viaje está anulado", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bBoleto = False
                    Me.LblBoleto.Text = ""
                    Me.LblBoleto.Visible = False
                    Me.lblCarga.Text = "-->CARGA ASEGURADA"
                    Me.lblCarga.Visible = False
                    Controla(True)
                    Me.txtiWinDestino.ReadOnly = False
                    Me.TxtBoleto.Focus()
                End If
            Else
                Dim s As String = ""
                For i As Integer = 0 To dt2.Rows.Count - 1
                    s = s & dt2.Rows(i).Item(0) & " " & dt2.Rows(i).Item(1) & Chr(13)
                Next
                MessageBox.Show("El Boleto " & sBoleto & " está asociado a:" & Chr(13) & Chr(13) & s, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bBoleto = False
                Me.LblBoleto.Text = ""
                Me.LblBoleto.Visible = False
                Me.lblCarga.Text = "-->CARGA ASEGURADA"
                Me.lblCarga.Visible = False
                Controla(True)
                Me.txtiWinDestino.ReadOnly = False
                Me.TxtBoleto.Text = ""
                Me.TxtBoleto.Focus()
            End If
        Else
            MessageBox.Show("El Boleto " & Me.TxtBoleto.Text.Trim & " no existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bBoleto = False
            Me.txtiWinDestino.ReadOnly = False
            Me.LblBoleto.Text = ""
            Me.LblBoleto.Visible = False
            Controla(True)

            Me.lblCarga.Text = "-->CARGA ASEGURADA"
            Me.lblCarga.Visible = False
            Me.TxtBoleto.Text = ""
            Me.TxtBoleto.Focus()
        End If
    End Sub

    Sub Controla(ByVal estado As Boolean)
        Me.btnArticulos.Enabled = estado
        'Me.btnSeguro.Enabled = estado
    End Sub

    Private Sub TxtBoleto_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles TxtBoleto.MaskInputRejected

    End Sub

    Private Sub ChkAcompaña_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAcompaña.CheckedChanged
        iOficinaDestino = 0
        If ChkAcompaña.Checked Then
            bCargaAcompañada2 = True
        Else
            bCargaAcompañada2 = False
        End If

        'Dim ee As New System.ComponentModel.CancelEventArgs
        'txtiWinDestino_Validating(sender, ee)


        'sBoleto = ""
        'If bCargaAcompañada2 And Me.lbFactBoleta.Text.Substring(0, 1) = "G" Then
        'TxtBoleto_Validated(sender, e)
        'End If


        Dim valor1 As Double = Val(dtGridViewBultos(4, 0).Value)
        Dim valor2 As Double = Val(dtGridViewBultos(2, 0).Value)
        fnCalcularCosto(0, valor1, valor2)

    End Sub

    Private Sub txtCliente_Remitente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente_Remitente.TextChanged

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
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function

    Private Sub cmbTipo_Entrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo_Entrega.SelectedIndexChanged
        Try
            Dim iidTipo As Integer = ObjVentaCargaContado.coll_t_Tipo_Entrega(cmbTipo_Entrega.SelectedIndex.ToString)
            If iidTipo = 1 Then
                txtDireccionDestinatario.Text = "AGENCIA"
                txtDireccionDestinatario.Enabled = False
            Else
                txtDireccionDestinatario.Text = ""
                txtDireccionDestinatario.Enabled = True
            End If

            'sBoleto = ""
            If bCargaAcompañada And Me.lbFactBoleta.Text.Substring(0, 1) <> "G" Then
                'TxtBoleto_Validated(sender, e)
                iOficinaDestino = 0
                Dim ee As New System.ComponentModel.CancelEventArgs
                'Me.txtiWinDestino_Validating(sender, ee)
                'Dim sender1 As New Object
                bValidaEntrega = True
                txtiWinDestino_Validating(sender, ee)
                bValidaEntrega = False
                'Dim ee As New System.ComponentModel.CancelEventArgs
                'txtDocCliente_Remitente_Leave(sender, ee)
                'txtDocCliente_Remitente_Validating(sender, ee)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ChkProceso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkProceso.CheckedChanged
        If Me.flagPCE Then Return
        dtGridViewBultos.Rows(0).Cells(2).Value = ""
        dtGridViewBultos.Rows(1).Cells(2).Value = ""
        dtGridViewBultos.Rows(2).Cells(2).Value = ""
        dtGridViewBultos.Rows(3).Cells(2).Value = ""

        dtGridViewBultos.Rows(0).Cells(4).Value = ""
        dtGridViewBultos.Rows(1).Cells(4).Value = ""
        dtGridViewBultos.Rows(2).Cells(4).Value = ""
        dtGridViewBultos.Rows(3).Cells(4).Value = ""

        'hlamas
        txtSub_Total.Text = ""
        txtMonto_IGV.Text = ""
        txtCosto_Total.Text = ""

        Dim iTipo As Integer
        If lbFactBoleta.Text.Substring(0, 1) = "F" Then
            iTipo = 1
        ElseIf lbFactBoleta.Text.Substring(0, 1) = "B" Then
            iTipo = 2
        ElseIf lbFactBoleta.Text.Substring(0, 1) = "G" Then
            iTipo = 3
        End If

        If iTipo <> 3 Then
            If ObjVentaCargaContado.fnNroDocuemnto(iTipo, ChkProceso.Checked) = True Then
                txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
            ElseIf ObjVentaCargaContado.fnNroDocuemnto(iTipo, 0) = True Then
                txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
            Else
                txtSERIE.Text = ""
                txtNroDocFACBOL.Text = ""
                MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
            End If
        Else
            If ObjVentaCargaContado.fnNroDocuemnto(iTipo, ChkProceso.Checked) = True Then
                txtNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
            ElseIf ObjVentaCargaContado.fnNroDocuemnto(iTipo, 0) = True Then
                txtNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
            Else
                txtNroGuia.Text = ""
                CORRELATIVO = 0
                MsgBox("No podra Realizar esta Operacion El Nro de Guia Envio no esta configurado")
            End If
        End If
        fnTarifario()
    End Sub

    Private Sub txtiWinDestino_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtiWinDestino.TextChanged

    End Sub

    Private Sub FrmCargaAsegurada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub dtGridViewControl_FACBOL_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewControl_FACBOL.CellContentClick

    End Sub
End Class

