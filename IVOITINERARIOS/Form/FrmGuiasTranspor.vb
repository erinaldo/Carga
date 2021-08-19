'Imports System.Data.OleDb
Public Class FrmGuiasTranspor
    Inherits FrmFormBase
    Dim Clase As New dtoGuiasTransp
    Dim ClaseDet As New dtoGuiasTranspDet    
    Dim Impresion As New ClsPrint
    ' Dim rstGen,, rstArt,rstDetaDoc,rstMed As ADODB.Recordset   Modificado 09/06/2007 - Omendoza 
    'Dim rstDetaDoc, rstUnd, rstMov, rstEnt, rstFor, rstDetalle, rstRet, rstBuscar, rstSalidas, rstGuiaEnvio As ADODB.Recordset
    'Dim rstDetaDoc, rstDetalle, rstRet, rstSalidas As ADODB.Recordset
    '
    'Dim rst_agencia_all, rsttemporal, rstagencias_filtro As New ADODB.Recordset
    'Dim rsttemporal As New ADODB.Recordset
    '
    'Dim dr4, da As New OleDbDataAdapter
    Dim dt, DtOrigen, DtDestino, DtCbMov, DtCbUnd, DtCbDes, DtCbEnt, DtCbEnt_tmp, DtCbFor, DtCbArt, DtCbMed, DtDetalle, DtDetaDoc, DtIti, DtDetaCopy, DtSalidas, dtGuiaEnvio, dtHoraSalida As New System.Data.DataTable
    Dim dtagencia_all, dtagencias_filtro As New System.Data.DataTable
    Dim DvOrigen, DvDestino, DvAgencia, DvCbMov, DvCbUnd, DvCbDes, DvCbEnt, DvCbEnt_tmp, DvCbArt, DvCbMed, DvDetalle, DvDetaDoc, DvDetaCopy, dvIti, DvSalidas, dvGuiaEnvio As DataView
    'Dim  DvCbFor As DataView  ' 17/07/2009 - Solo modificado para que sea de uso local  
    Dim dvagencia_all, dvagencias_filtro As DataView
    Dim dr, dr2, DrRuta, DrAge1, DrAge2, DrCopy As DataRowView
    Dim Fact, filcb, conta, AgeOri, AgeDes, i, IDUser As Integer
    Dim valor, NAgeOri, NAgeDes, CiuOri, CiuDes, hora_ini, hora_fin, horinia, horfina As String
    Dim fec_ini, fec_fin, rfec_ini, rfec_fin, fecinia, fecfina As Date
    Dim FlgTre As Integer
    Dim ndias As Double
    Dim chora As String
    Dim tipo_guia_transpor_impre As String
    Dim l_iidegencia_ori As Long
    Dim b_copia As Boolean
    '
    Dim b_habilita_grabar As Boolean = True
    Dim STxtCodDes As String = ""
    '****************************************************************************************************************
    Dim dr3 As DataRowView
    Dim b_nolee As Boolean = True
    Dim WithEvents WinSockCliente As New Cliente()
    'Variables creadas por Tepsa 
    Dim Nro_Digitos_guiatransportista As Integer = 7   'Nro Cabecera
    Dim Nro_Digitos_Serguiatransportista As Integer = 3 'Nro Serie 
    ' 01/02/2008  -> Recupera la variable de la agencia  para saber si es inhouse(es_terminal)   = 5 
    Dim es_inhouse As Boolean = False
    '
    Dim pb_nolee_codigo_iata As Boolean = False
    Dim fb_cambia_fact As Boolean = True
    '
    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Dim iLong As Integer
    ''' <summary>
    ''' Realiza la reimpresion de tikect de los comprobantes ingresados a la guia de transportista.
    ''' </summary>
    ''' <param name="dataTable">DT con los comprobantes a reimprimir</param>
    Sub reimpresionTicket(dataTable As DataTable)
        For Each row As DataRow In dataTable.Rows
            Dim fecliente As New FECliente
            fecliente.tipoDocumentoID = row.Item("tipo_documento").ToString()
            fecliente.numeroDocumento = row.Item("numero_documento").ToString()
            fecliente.nombres = row.Item("cliente").ToString()
            fecliente.direccion = IIf(IsDBNull(row.Item("direccion_origen")), "", row.Item("direccion_origen").ToString())
            Dim venta As New FEVenta
            Dim serie As String = row.Item("Comprobante").ToString().Split("-")(0)
            Dim correlativo As String = row.Item("Comprobante").ToString().Split("-")(1)
            venta.cliente = fecliente
            venta.numeroSerie = serie
            venta.numeroCorrelativo = correlativo
            venta.fechaEmision = Convert.ToDateTime(row.Item("fecha_emision").ToString()).ToString("dd/MM/yyyy")
            venta.tipoComprobanteID = row.Item("Tipo")
            venta.opGravada = row.Item("monto_sub_total")
            venta.igv = row.Item("monto_impuesto")
            venta.total = row.Item("total_costo")
            venta.totalLetras = ConvercionNroEnLetras(venta.total)
            venta.formaPago = row.Item("tipo_pago").ToString()
            venta.producto = row.Item("producto").ToString()
            venta.origen = row.Item("origen").ToString()
            venta.destino = row.Item("destino").ToString()
            venta.remitenete = fecliente.nombres
            venta.consignado = row.Item("consignado").ToString()
            venta.tipoEntrega = row.Item("tipo_entrega").ToString()
            venta.direccionEntrega = row.Item("direccion_destino").ToString()
            venta.agenciaEmision = row.Item("agencia_emision").ToString()
            venta.usuarioEmision = row.Item("usuario").ToString()
            Dim result = FEManager.reimprimirComprobante(venta)
            If Not (result.isCorrect) Then
                MessageBox.Show("No se puedo imprimir el Comprobante N° " & row.Item("Comprobante").ToString(), "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next
    End Sub

    'Sub ImprimirTicket(ByVal venta As dtoVentaCargaContado, ByVal impresora As DataTable, Optional ByVal venta2 As dtoVentaCargaContado = Nothing)
    '    Dim prn As New FEManager
    '    Dim feventa As New FEVenta
    '    Dim fecliente As New FECliente

    '    fecliente.tipoDocumentoID = dtCliente.Rows(0).Item("tipo") 'venta.ID_TipoDocCli
    '    fecliente.numeroDocumento = dtCliente.Rows(0).Item("nu_docu_suna") 'venta.v_NRO_DNI_RUC
    '    fecliente.nombres = dtCliente.Rows(0).Item("razon_social")

    '    'If ObjVentaCargaContado.v_direccion.Trim.Length > 0 Then
    '    'fecliente.direccion = ObjVentaCargaContado.v_direccion.Trim.ToUpper
    '    'Else
    '    fecliente.direccion = IIf(CboDireccion.SelectedIndex > 0, CboDireccion.Text.Trim.ToUpper(), "")
    '    'End If
    '    feventa.cliente = fecliente

    '    Dim strSerie As String = ""

    '    feventa.numeroSerie = "" 'strSerie & Me.lblSerie.Text 'venta.v_SERIE_FACTURA
    '    feventa.numeroCorrelativo = Me.DgvLista.CurrentRow.Cells("guia").Value 'venta.v_NRO_FACTURA

    '    feventa.fechaEmision = FechaServidor()
    '    feventa.tipoComprobanteID = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value  'venta.v_IDTIPO_COMPROBANTE
    '    feventa.opGravada = 0
    '    feventa.igv = 0
    '    feventa.total = CDbl(Me.DgvLista.CurrentRow.Cells("Total_Costo").Value)
    '    feventa.totalLetras = ObjVentaCargaContado.v_nroboleto
    '    feventa.formaPago = "" 'IIf(cmbFormaPago.SelectedIndex = 0, "", cmbFormaPago.Text.Trim().ToUpper())
    '    Dim formaPagoID As Integer = 0 'cboFormaPago.SelectedValue
    '    feventa.isCortesia = False

    '    '-->Para la impresion
    '    feventa.producto = CboProducto.Text
    '    feventa.origen = Me.CboCiudad_Origen.Text
    '    feventa.destino = TxtCiudadDestino.Text.Trim.ToUpper()
    '    feventa.remitenete = fecliente.nombres

    '    For i As Integer = 0 To GrdNConsignado.Rows.Count() - 1
    '        ObjVentaCargaContado.v_NOMBRES_DESTINATARIO &= GrdNConsignado("Nombres", i).Value & ";"
    '    Next

    '    Dim sConsignado As String = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO.Trim.Replace(";", ",")
    '    sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)
    '    feventa.consignado = sConsignado

    '    feventa.tipoEntrega = Me.CboTipoEntrega.Text
    '    feventa.direccionEntrega = Me.CboDireccion2.Text
    '    feventa.agenciaEmision = dtoUSUARIOS.m_iNombreAgencia
    '    feventa.usuarioEmision = dtoUSUARIOS.NameLogin
    '    feventa.detalleVenta = FEManager.crearDetallePCE(GrdDetalleVenta, CDbl(Me.TxtTotal.Text), Me.ChkArticulos.Checked, False, venta.v_iProceso, 0)
    '    feventa.id = Me.DgvLista.CurrentRow.Cells("IdFactura").Value 'ObjVentaCargaContado.v_IDFACTURA
    '    feventa.tabla = "T_FACTURA_CONTADO"

    '    Dim result As New servicefe.Result
    '    'Dim result As New feserviceDesarrollo.Result
    '    prn.Print(feventa, impresora)
    'End Sub

    Private Sub Conectar()
        'Try
        '    With WinSockCliente
        '        'Determino a donde se quiere conectar el usuario 
        '        .IPDelHost = IPServer
        '        .PuertoDelHost = Port
        '        .Conectar()
        '    End With
        'Catch ex As Exception
        '    MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema ...")
        'End Try
    End Sub
    Private Sub WinSockCliente_DatosRecibidos(ByVal datos As String) Handles WinSockCliente.DatosRecibidos
        Try
            'If datos.Length() > 0 Then
            '    Call BuscaRecojos()
            'End If
            'MsgBox("Recibiendo Datos", MsgBoxStyle.Information, "Segurida Sistema")
            BuscaRecojos()
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema...")
        End Try
    End Sub
    Private Sub Enviar_Datos(ByVal strDatos As String)
        Try
            WinSockCliente.EnviarDatos(strDatos)
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema...")
        End Try
    End Sub
    Private Sub WinSockCliente_ConexionTerminada() Handles WinSockCliente.ConexionTerminada
        Try
            MsgBox("Finalizo la conexion", MsgBoxStyle.Information, "Segurida Sistema")
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub FrmGuiasTranspor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmGuiasTranspor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    '****************************************************************************************************************
    Private Sub FrmGuiasTranspor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ldv_DvCbFor As DataView
        Try
            '
            ' Debe colocarse esto con un tecla (F5) nro de guías  grabar_guia()
            '
            Me.cboTipoComprobante.SelectedIndex = 0
            dtoUSUARIOS.m_iNombreUnidadAgencia = fnGetCiudad(dtoUSUARIOS.m_idciudad.ToString)
            '01/02/2008 <-> Verifica si está asociada al inhose 
            If fnGetAGENCIA_esterminal(dtoUSUARIOS.iIDAGENCIAS.ToString) = 5 Then
                es_inhouse = True
            End If
            '
            dtoUSUARIOS.m_iNombreAgencia = fnGetAGENCIA(dtoUSUARIOS.m_iIdAgencia.ToString)
            Me.Text = "GUIA TRANSPORTISTA [" & dtoUSUARIOS.iLOGIN & " ] Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & " [ " & dtoUSUARIOS.m_iNombreAgencia & " ][ " & dtoUSUARIOS.m_iNombreUnidadAgencia & "] "
            '---
            Me.CbTipoServ.Enabled = False ' 06/09/2007 
            '---
            l_iidegencia_ori = dtoUSUARIOS.m_iIdAgencia
            '---        
            Call IniciarImagenes()
            STxtCodDes = ""   'Inicializando variable
            b_copia = False
            ShadowLabel1.Text = "Guias de Remisión Transportista"
            TxtFechaIni._MyFecha = Convert.ToString(Today)
            TxtFechaFin._MyFecha = Convert.ToString(Today)
            dt.Clear()
            'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
            'rstUnd = Clase.Lista ' rstGen.NextRecordset y a todo lo que le sigue. 
            'rstMov = rstUnd.NextRecordset
            'rstDetaDoc = rstUnd.NextRecordset
            'rstEnt = rstUnd.NextRecordset
            'rstFor = rstUnd.NextRecordset
            'rstagencias_filtro = rstUnd.NextRecordset ' Recupera la agencia
            'rst_agencia_all = rstUnd.NextRecordset
            'dr4.Fill(DtCbUnd, rstUnd)
            'dr4.Fill(DtCbMov, rstMov)
            'dr4.Fill(DtDetaDoc, rstDetaDoc)
            'dr4.Fill(DtCbEnt, rstEnt)
            'dr4.Fill(DtCbFor, rstFor)
            'dr4.Fill(dtagencias_filtro, rstagencias_filtro)
            'dr4.Fill(dtagencia_all, rst_agencia_all)
            'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
            Dim lds_tmp As New DataSet
            lds_tmp = Clase.Lista
            '
            DtCbUnd = lds_tmp.Tables(0)
            DtCbMov = lds_tmp.Tables(1)
            DtDetaDoc = lds_tmp.Tables(2)
            DtCbEnt = lds_tmp.Tables(3)
            DtCbFor = lds_tmp.Tables(4)
            dtagencias_filtro = lds_tmp.Tables(5)
            dtagencia_all = lds_tmp.Tables(6)
            '
            DvCbUnd = DtCbUnd.DefaultView
            DvCbMov = DtCbMov.DefaultView
            '
            DtCbDes = DtCbUnd.Copy
            DvCbDes = DtCbDes.DefaultView
            DtOrigen = DtCbUnd.Copy
            DvOrigen = DtOrigen.DefaultView
            DtDestino = DtCbUnd.Copy
            DvDestino = DtDestino.DefaultView
            '
            DvCbUnd.RowFilter = "idunidad_agencia <> 9999"
            DvCbDes.RowFilter = "idunidad_agencia <> 9999"
            '
            DvCbEnt = DtCbEnt.DefaultView
            '
            b_nolee = False
            'LlenaCombo2(DvOrigen, CbOrigen, "NOMBRE_UNIDAD") Hecho por Eduardo 
            DvOrigen = CargarCombo(CbOrigen, DtOrigen, "nombre_unidad", "idunidad_agencia", dtoUSUARIOS.m_idciudad)  ' Por defecto 0 No debe aparecer nada 
            '
            LlenaCombo2(DvDestino, CbDestino, "NOMBRE_UNIDAD")
            '
            ' LlenaCombo2(DvCbMov, CbChofer, "NOMBRE")  comentado 11/01/2007 
            DvCbMov = CargarCombo(CbChofer, DtCbMov, "NOMBRE", "idusuario_personal", 0) ' Creado 11/01/2007
            '
            '
            'LlenaCombo2(DvCbUnd, CbOriDet, "NOMBRE_UNIDAD") ' Hecho por Eduardo 18/12/2006
            DvCbUnd = CargarCombo(CbOriDet, DtOrigen, "nombre_unidad", "idunidad_agencia", dtoUSUARIOS.m_idciudad)
            '
            'Cambiado por Tepsa 10-Nov-2006 
            'LlenaCombo2(DvCbDes, CbDesDet, "NOMBRE_UNIDAD")  ' Hecho por Eduardo
            DvCbDes = CargarCombo(CbDesDet, DtCbDes, "nombre_unidad", "idunidad_agencia", 0)  ' Por defecto 0 No debe aparecer nada 
            'LlenaCombo2(DvCbEnt, CbBus, "NOMBRE_TRANSPORTE") 'Hecho por Eduardo cambiado por Tepsa 20/12/2006 
            DvCbEnt = CargarCombo(CbBus, DtCbEnt, "NOMBRE_TRANSPORTE", "idunidad_transporte", 0)  ' Por defecto 0 No debe aparecer nada 
            'Cargar agencias 
            dvagencias_filtro = CargarCombo(Me.cmbagencia, dtagencias_filtro, "nombre_agencia", "idagencia", dtoUSUARIOS.m_iIdAgencia)  ' Debe aparecer la agencia con la que se ha connectado
            dvagencia_all = CargarCombo(Me.cmb_agencia_destino, dtagencia_all, "nombre_agencia", "idagencia", -666)
            '
            'LlenaCombo2(DvCbEnt, CbBus, "PLACA")
            'LlenaCombo2(DvCbFor, CbTipoServ, "TIPO_SERVICIO")
            ldv_DvCbFor = CargarCombo(Me.CbTipoServ, DtCbFor, "TIPO_SERVICIO", "IDTIPO_SERVICIO", 0)

            '
            Try
                DvDetaDoc = DtDetaDoc.DefaultView
            Catch ex As Exception
                '
            End Try
            '
            'DtDetaCopy = DtDetalle.Copy
            'DvDetaCopy = DtDetaCopy.DefaultView
            DvDetaDoc.AllowNew = False
            FlgTre = 0
            Fact = 0
            TxtCliente.Text = "%"
            MenuTab.Items(0).Text = "BUSQUEDA"
            MenuTab.Items(1).Text = "DATOS GENERALES"
            Call GrillaDetaDoc()
            b_nolee = True

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If FlgTre = 0 Then
            If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
                If txtGuiaEnvio.Focused = True Then
                    fnCargardatos()
                Else
                    SendKeys.Send("{Tab}")
                End If

                Return True
            End If
            Return MyBase.ProcessCmdKey(msg, keyData)
        Else
            FlgTre = 0
        End If
    End Function
    Private Sub BtBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBusca.Click
        Call BuscaGuiasTransporte()
    End Sub
    Private Sub BtBusca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtBusca.GotFocus
        FlgTre = 1
    End Sub
    Sub GrillaMante()
        DataGridViewLista.Columns.Clear()
        With DataGridViewLista
            .AllowUserToAddRows = True
            .AllowUserToDeleteRows = True
            .AllowUserToOrderColumns = True
            .BackgroundColor = Color.White
            '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
            .ReadOnly = True
            .AutoGenerateColumns = False
            .DataSource = DvAgencia
            .VirtualMode = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
        End With

        'Dim idEstadoImage As New DataGridViewImageColumn
        'With idEstadoImage
        '    .DataPropertyName = "imagen"
        '    .HeaderText = "CT"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        '    .DisplayIndex = 0
        '    .Visible = True
        '    .Image = bmActivo
        'End With
        'DataGridViewLista.Columns.Add(idEstadoImage)
        '
        Dim col00 As New DataGridViewTextBoxColumn
        With col00
            .DataPropertyName = "nombre_agencia"
            .HeaderText = "Agencia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        End With
        DataGridViewLista.Columns.Add(col00)
        '
        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DataPropertyName = "serie_guia_transportista"
            .HeaderText = "Serie"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        End With
        DataGridViewLista.Columns.Add(col0)
        '
        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "nro_guia_transportista"
            .HeaderText = "Nº Guía Transportista"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col1)
        '
        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "fecha_salida"
            .HeaderText = "Fecha"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "d"
        End With
        DataGridViewLista.Columns.Add(col2)
        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DataPropertyName = "origen"
            .HeaderText = "Origen"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill            
        End With
        DataGridViewLista.Columns.Add(col3)
        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DataPropertyName = "destino"
            .HeaderText = "Destino"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col4)
        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DataPropertyName = "tipo_servicio"
            .HeaderText = "Servicio"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        End With
        DataGridViewLista.Columns.Add(col5)
        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .DataPropertyName = "idunidad_transporte"
            .HeaderText = "Bus"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        End With
        DataGridViewLista.Columns.Add(col6)
        '
        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .DataPropertyName = "estado_registro"
            .Name = "estado_registro"
            .HeaderText = "Estado Bus"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col7)
        '
        Dim co18 As New DataGridViewTextBoxColumn
        With co18
            .DataPropertyName = "idagencias"
            .Name = "idagencias"
            .HeaderText = "Agencia Origen"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
            .ReadOnly = False
        End With
        DataGridViewLista.Columns.Add(co18)
        ' 
        Dim co19 As New DataGridViewTextBoxColumn
        With co19
            .DataPropertyName = "idagencias_destino"
            .Name = "idagencias_destino"
            .HeaderText = "Agencia Destino"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
            .ReadOnly = False
        End With
        DataGridViewLista.Columns.Add(co19)
        'Modificado - 11/08/2009 
        Dim co20 As New DataGridViewTextBoxColumn
        With co20
            .DataPropertyName = "idusuario_personal_piloto"
            .Name = "idusuario_personal_piloto"
            .HeaderText = "Piloto"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
            .ReadOnly = False
        End With
        DataGridViewLista.Columns.Add(co20)

        Dim co21 As New DataGridViewTextBoxColumn
        With co21
            .DataPropertyName = "idguia_transportista"
            .Name = "id"
            .HeaderText = "id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
            .ReadOnly = False
        End With
        DataGridViewLista.Columns.Add(co21)

        Dim co22 As New DataGridViewTextBoxColumn
        With co22
            .DataPropertyName = "tipo_carga"
            .Name = "tipo_carga"
            .HeaderText = "tipo_carga"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
            .ReadOnly = False
        End With
        DataGridViewLista.Columns.Add(co22)

        'Dim col7 As New DataGridViewTextBoxColumn
        'With col7
        '    .DataPropertyName = "estado_registro"
        '    .HeaderText = "Nom Estado"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With
        'DataGridViewLista.Columns.Add(col7)
        'Dim col8 As New DataGridViewCheckBoxColumn
        'With col8
        '    .DataPropertyName = "flag"
        '    .HeaderText = "Nom Estado"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With
        'DataGridViewLista.Columns.Add(col8)
        'Dim col8 As New DataGridViewTextBoxColumn
        'With col8
        '    .DataPropertyName = "AGENCIA_DESTINO"
        '    .HeaderText = "Agencia Destino"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        'End With
        'DataGridDeta.Columns.Add(col8)
    End Sub
    Sub GrillaDeta()
        DataGridViewUnd.Columns.Clear()
        With DataGridViewUnd
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .BackgroundColor = SystemColors.Window
            '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
            .ReadOnly = False
            .AutoGenerateColumns = False
            .DataSource = DvDetalle
            .VirtualMode = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DataPropertyName = "tipo_comprobante"
            .HeaderText = "Tipo"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.NullValue = ""
            .ReadOnly = True
        End With
        DataGridViewUnd.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "nro_doc"
            .HeaderText = "Nro.Doc"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet 'FILL
            .ReadOnly = True
        End With
        DataGridViewUnd.Columns.Add(col1)

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "cantidad"
            .HeaderText = "Cantidad"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            '.Visible = False
        End With
        DataGridViewUnd.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DataPropertyName = "saldo"
            .HeaderText = "Saldo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.DefaultCellStyle.Format = "d"
            .ReadOnly = True
        End With
        DataGridViewUnd.Columns.Add(col3)

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DataPropertyName = "total_peso"
            .HeaderText = "Tot.Peso"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
        End With
        DataGridViewUnd.Columns.Add(col4)

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DataPropertyName = "total_volumen"
            .HeaderText = "Tot.Volumen"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            '.DefaultCellStyle.Format = "d"
        End With
        DataGridViewUnd.Columns.Add(col5)

        Dim col6 As New DataGridViewCheckBoxColumn
        With col6
            .DataPropertyName = "flgenv"
            .HeaderText = "Sel"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = False
        End With
        DataGridViewUnd.Columns.Add(col6)

        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .DataPropertyName = "subtotal"
            .Name = "subtotal"
            .HeaderText = "Subtotal"
            .Visible = True
        End With
        DataGridViewUnd.Columns.Add(col7)

        Dim col8 As New DataGridViewTextBoxColumn
        With col8
            .DataPropertyName = "idcomprobante"
            .Name = "idcomprobante"
            .HeaderText = "idcomprobante"
            .Visible = False
        End With
        DataGridViewUnd.Columns.Add(col8)

        Dim col9 As New DataGridViewTextBoxColumn
        With col9
            .DataPropertyName = "producto"
            .Name = "producto"
            .HeaderText = "producto"
            .Visible = False
        End With
        DataGridViewUnd.Columns.Add(col9)
    End Sub

    Sub GrillaDetaDoc()
        DataGridViewGuia.Columns.Clear()
        With DataGridViewGuia
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .BackgroundColor = SystemColors.Window
            '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
            .ReadOnly = False
            .AutoGenerateColumns = False
            .DataSource = DvDetaDoc
            .VirtualMode = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DataPropertyName = "tipo_comprobante"
            .HeaderText = "Tipo"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.NullValue = ""
            .ReadOnly = True
        End With
        DataGridViewGuia.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "nro_doc"
            .HeaderText = "Nro.Doc"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        DataGridViewGuia.Columns.Add(col1)

        Dim col1b As New DataGridViewTextBoxColumn
        With col1b
            .DataPropertyName = "iata"
            .HeaderText = "IATA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        DataGridViewGuia.Columns.Add(col1b)

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "cantidad"
            .HeaderText = "Cantidad"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = False
            '.Visible = False
        End With
        DataGridViewGuia.Columns.Add(col2)

        'Dim col3 As New DataGridViewTextBoxColumn
        'With col3
        '    .DataPropertyName = "saldo"
        '    .HeaderText = "Saldo"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    '.DefaultCellStyle.Format = "d"
        '    .ReadOnly = True
        'End With
        'DataGridViewUnd.Columns.Add(col3)

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DataPropertyName = "total_peso"
            .HeaderText = "Tot.Peso"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
        End With
        DataGridViewGuia.Columns.Add(col4)

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DataPropertyName = "total_volumen"
            .HeaderText = "Tot.Volumen"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            '.DefaultCellStyle.Format = "d"
        End With
        DataGridViewGuia.Columns.Add(col5)

        Dim col6 As New DataGridViewCheckBoxColumn
        With col6
            .DataPropertyName = "flgenv"
            .HeaderText = "Sel"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = False
        End With
        DataGridViewGuia.Columns.Add(col6)
        '
        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .DataPropertyName = "saldo"
            .Name = "saldo"
            .HeaderText = "Saldo"
            .Visible = False
        End With
        DataGridViewGuia.Columns.Add(col7)

        Dim col8 As New DataGridViewTextBoxColumn
        With col8
            .DataPropertyName = "subtotal"
            .Name = "subtotal"
            .HeaderText = "Subtotal"
            .Visible = True
        End With
        DataGridViewGuia.Columns.Add(col8)

        Dim col9 As New DataGridViewTextBoxColumn
        With col9
            .DataPropertyName = "idtipo_comprobante"
            .HeaderText = "idtipo_comprobante"
            .Name = "idtipo_comprobante"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.NullValue = ""
            .ReadOnly = True
            .Visible = False
        End With
        DataGridViewGuia.Columns.Add(col9)

        Dim col10 As New DataGridViewTextBoxColumn
        With col10
            .DataPropertyName = "idcomprobante"
            .HeaderText = "idcomprobante"
            .Name = "idcomprobante"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.NullValue = ""
            .ReadOnly = True
            .Visible = False
        End With
        DataGridViewGuia.Columns.Add(col10)

        Dim col11 As New DataGridViewTextBoxColumn
        With col11
            .DataPropertyName = "producto"
            .HeaderText = "producto"
            .Name = "producto"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.NullValue = ""
            .ReadOnly = True
            .Visible = False
        End With
        DataGridViewGuia.Columns.Add(col11)
    End Sub
    'Private Sub CbOriDet_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbOriDet.SelectedIndexChanged
    '    filcb = CbOriDet.SelectedIndex
    '    If filcb >= 0 Then
    '        dr = DvCbOde.Item(filcb)
    '        valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
    '        DvCbRut.RowFilter = "idunidad_agencia = " & valor
    '        DvCbAg1.RowFilter = "idunidad_agencia = " & valor
    '        filcb = DvCbRut.Count
    '        If filcb > 0 Then
    '            dr = DvCbRut.Item(0)
    '            valor = IIf(IsDBNull(dr("idunidad_agencia_destino")) = True, "0", dr("idunidad_agencia_destino").ToString)
    '            DvCbAg2.RowFilter = "idunidad_agencia = " & valor
    '        Else
    '            DvCbAg1.RowFilter = "idunidad_agencia = 0"
    '            DvCbAg2.RowFilter = "idunidad_agencia = 0"
    '        End If
    '    Else
    '        DvCbRut.RowFilter = "idunidad_agencia = 0"
    '        DvCbAg1.RowFilter = "idunidad_agencia = 0"
    '        DvCbAg2.RowFilter = "idunidad_agencia = 0"
    '    End If
    'End Sub

    'Private Sub CbRuta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbRuta.SelectedIndexChanged
    '    filcb = CbRuta.SelectedIndex
    '    If filcb >= 0 Then
    '        dr = DvCbRut.Item(filcb)
    '        valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
    '        DvCbAg1.RowFilter = "idunidad_agencia = " & valor
    '        valor = IIf(IsDBNull(dr("idunidad_agencia_destino")) = True, "0", dr("idunidad_agencia_destino").ToString)
    '        DvCbAg2.RowFilter = "idunidad_agencia = " & valor
    '    Else
    '        DvCbAg1.RowFilter = "idunidad_agencia = 0"
    '        DvCbAg2.RowFilter = "idunidad_agencia = 0"
    '    End If
    'End Sub

    'Private Sub TxtHora_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtHora.Validating
    '    If TxtHora.Text <> "  :" Then
    '        Try
    '            If Mid(Trim(TxtHora.Text), 1, 2) > "23" Or Mid(Trim(TxtHora.Text), 4, 2) > "59" Then
    '                MessageBox.Show("Hora Incorrecta", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                e.Cancel = True
    '            Else
    '                Call RecalculaFechas(Convert.ToDateTime(TxtFecInicio.GetMyFecha))
    '            End If
    '        Catch ex As Exception
    '            MsgBox("Formato de Hora Incorrecto", MsgBoxStyle.Critical, "Titan")
    '            e.Cancel = True
    '        End Try
    '    End If
    'End Sub
    Private Sub FrmGuiasTranspor_MenuCancelar() Handles Me.MenuCancelar
        If fb_cambia_fact = False Then
            Fact = 0
        End If

        If b_copia = True Then
            volver_origen_bus()
        End If
        ' Tepsa colocando a su estado original 
        Me.txthorasalida.Text = ""
        '
        CbBus.Enabled = True
        'CbTipoServ.Enabled = True
        TxtFecInicio.Enabled = True
        CbItinerarios.Enabled = True
        CbOriDet.Enabled = True
        CbDesDet.Enabled = True
        chkcontroldestino.Enabled = True
        TxtCodDes.Enabled = True
        CbChofer.Enabled = True
        btnEnvio.Enabled = True
        txtGuiaEnvio.Enabled = True
        BtAgregar.Enabled = True
        BtSacar.Enabled = True
        DataGridViewUnd.Enabled = True
        DataGridViewGuia.Enabled = True
        ' 
        b_habilita_grabar = True
        GrabarToolStripMenuItem.Enabled = True
        STxtCodDes = ""
        'Me.labnroregistro_old.Text = "0"
        Me.lbNroRagistros.Text = "0"
    End Sub
    Private Sub FrmGuiasTranspor_MenuEditar() Handles Me.MenuEditar
        Try
            Fact = 2
            Call Edicion()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Titan")
            Exit Sub
        End Try
    End Sub
    Private Sub FrmGuiasTranspor_MenuEliminar() Handles Me.MenuEliminar
        ' Debe eliminar la guía, quitar la asociación comprobantes (Guias de envio y venta al contado) 
        Dim filarow As Integer
        Dim lid As Long
        Dim DrUnd As DataRowView
        Dim resp As DialogResult
        Dim sserie, snrodocumento As String
        Dim dr, dr2 As DataRowView
        Dim origen, destino As Integer
        'Dim rstgrilla As New ADODB.Recordset
        '13/08/2009 - 
        If DataGridViewLista.RowCount < 1 Then
            Exit Sub
        End If
        ' --
        filarow = DataGridViewLista.CurrentRow.Index
        If filarow >= 0 Then
            DrUnd = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
            dr = DvOrigen.Item(CbOrigen.SelectedIndex)
            dr2 = DvDestino.Item(CbDestino.SelectedIndex)
            origen = dr("idunidad_agencia")
            destino = dr2("idunidad_agencia")
            lid = CType(DrUnd("IDGUIA_TRANSPORTISTA"), Long)
            sserie = Convert.ToString(DrUnd("serie_guia_transportista"))
            snrodocumento = Convert.ToString(DrUnd("nro_guia_transportista"))
            '
            sserie = RellenoRight(3, sserie)
            snrodocumento = RellenoRight(7, snrodocumento)
            '
            resp = MessageBox.Show("¿Esta seguro de eliminar la guía de transportista? " & sserie & " - " & snrodocumento, "Guía de Transportista", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If resp = Windows.Forms.DialogResult.Yes Then
                Clase.ID = lid
                Clase.IP = dtoUSUARIOS.IP
                Clase.Rol = dtoUSUARIOS.IdRol
                Clase.Usuario = dtoUSUARIOS.IdLogin
                Clase.CiuOrigen = origen
                Clase.CiuDestino = destino
                Clase.FecIni = TxtFechaIni.GetMyFecha
                Clase.Fecfin = TxtFechaFin.GetMyFecha
                DvAgencia = Nothing
                DvAgencia = New DataView
                dt = Nothing
                dt = New DataTable
                'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
                'rstgrilla = Clase.fnanulaguiatransportista()
                'da.Fill(dt, rstgrilla)
                dt = Clase.fnanulaguiatransportista()
                ' Debe Refrescar la Grilla 
                '''''''''''''''''''''                
                DvAgencia = dt.DefaultView
                DvAgencia.AllowNew = False
                Call GrillaMante() ' Cargando de nuevo los datos con las grillas 
            End If
        Else
            MessageBox.Show("No seleccionado ninguna guía de transportista para anular", "Guía de Transportista", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub
    Private Sub FrmGuiasTranspor_MenuGrabar() Handles Me.MenuGrabar
        grabar_guia()
    End Sub
    Private Sub FrmGuiasTranspor_MenuImprimir() Handles Me.MenuImprimir
        Try
            ImprimirGuia()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'If DataGridViewLista.RowCount < 1 Then
        '    Exit Sub
        'End If
        'Try
        '    ObjReport.Dispose()
        'Catch
        'End Try
        'ObjReport = New ClsLbTepsa.dtoFrmReport
        'Dim b_actualizo As Boolean = False
        'Dim iidguia_transportista As Integer
        '' Debe tener el número de guía de transportista 
        'If Fact = 2 Then
        '    If TxtSerie.Text = "" Or TxtNroGuia.Text = "" Then
        '        MessageBox.Show("Falta ingresar el número de guía", "Guía de Transportista", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '        If TxtSerie.Text = "" Then
        '            TxtSerie.Focus()
        '        End If
        '        If TxtNroGuia.Text = "" Then
        '            TxtNroGuia.Focus()
        '        End If
        '        Exit Sub
        '    End If
        '    '
        '    If TxtID.Text = "" Then
        '        MessageBox.Show("Primero, debe grabar la guía, para emitirla", "Guía de Transportista", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '        Exit Sub
        '    End If
        '    '
        '    iidguia_transportista = CType(TxtID.Text, Integer)
        '    '
        '    ' Recuperando la información para el reporte 
        '    ' Pasando los valores
        'Else
        '    'Dim rsIti As ADODB.Recordset
        '    Dim filarow As Integer
        '    Dim DrUnd As DataRowView
        '    Dim sserie As String
        '    Dim snrodocumento As String
        '    Dim ll_idusuario_píloto As Long

        '    filarow = DataGridViewLista.CurrentRow.Index
        '    If filarow >= 0 Then
        '        Dim idagencia_origen, idagencia_destino, idunidad_agencia, idunidad_agencia_destino As Long
        '        DrUnd = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
        '        '
        '        idagencia_origen = IIf(IsDBNull(Convert.ToString(DrUnd("idagencias"))) = True, -666, Convert.ToString(DrUnd("idagencias")))
        '        idagencia_destino = IIf(IsDBNull(Convert.ToString(DrUnd("idagencias_destino"))) = True Or Convert.ToString(DrUnd("idagencias_destino")) = "", -666, Convert.ToString(DrUnd("idagencias_destino")))
        '        idunidad_agencia = IIf(IsDBNull(Convert.ToString(DrUnd("idunidad_agencia"))) = True Or Convert.ToString(DrUnd("idunidad_agencia")) = "", -666, Convert.ToString(DrUnd("idunidad_agencia")))
        '        idunidad_agencia_destino = IIf(IsDBNull(Convert.ToString(DrUnd("idunidad_agencia_destino"))) = True Or Convert.ToString(DrUnd("idunidad_agencia_destino")) = "", -666, Convert.ToString(DrUnd("idunidad_agencia_destino")))
        '        iidguia_transportista = Convert.ToString(DrUnd("IDGUIA_TRANSPORTISTA"))
        '        ll_idusuario_píloto = IIf(IsDBNull(Convert.ToString(DrUnd("idusuario_personal_piloto"))) = True Or Convert.ToString(DrUnd("idusuario_personal_piloto")) = "", -666, Convert.ToString(DrUnd("idusuario_personal_piloto")))
        '        'If idagencia_origen <> idagencia_destino Then
        '        If idunidad_agencia <> idunidad_agencia_destino Then
        '            If IsDBNull(DrUnd("serie_guia_transportista")) = True Or IsDBNull(DrUnd("nro_guia_transportista")) = True Then
        '                If fn_actualiza_guia_transportista(True) = False Then
        '                    Exit Sub
        '                End If
        '                b_actualizo = True
        '            End If
        '            ' Verificar si las agencias son iguales debe seleccionar una agencia especifica 
        '            ' Contemplando el manifiesto (Omendoza) 
        '            '
        '        Else
        '            ' Activa ventana de actualizacion 
        '            ' Debe validar que la agencia sean diferentes y tenga pilotos  -- 31/08/2009
        '            If (idagencia_origen = idunidad_agencia_destino) Or (idagencia_destino = -666) Or (ll_idusuario_píloto = -666) Then
        '                Dim Obj_actagencia_y_piloto As New frm_act_agencia_y_piloto
        '                Obj_actagencia_y_piloto.dt_ciudad = DtOrigen.Copy
        '                Obj_actagencia_y_piloto.dv_ciudad = CargarCombo(Obj_actagencia_y_piloto.cmb_ciudad_destino, Obj_actagencia_y_piloto.dt_ciudad, "nombre_unidad", "idunidad_agencia", dtoUSUARIOS.m_idciudad)  ' Por defecto 0 No debe aparecer nada 
        '                '
        '                Obj_actagencia_y_piloto.dt_agencia = dtagencias_filtro.Copy
        '                Obj_actagencia_y_piloto.dv_agencia = CargarCombo(Obj_actagencia_y_piloto.cmb_agencia_destino, Obj_actagencia_y_piloto.dt_agencia, "nombre_agencia", "idagencia", dtoUSUARIOS.m_iIdAgencia)  ' Aparecera la agencias destino
        '                Obj_actagencia_y_piloto.dv_agencia.RowFilter = "idagencia <> " + CType(idagencia_origen, String)
        '                '
        '                Obj_actagencia_y_piloto.dt_piloto = DtCbMov.Copy
        '                Obj_actagencia_y_piloto.dv_piloto = CargarCombo(Obj_actagencia_y_piloto.cmb_piloto, Obj_actagencia_y_piloto.dt_piloto, "NOMBRE", "idusuario_personal", -666)  ' Apareceran los pilotos 
        '                '
        '                Obj_actagencia_y_piloto.l_idguia_transportista = iidguia_transportista
        '                Obj_actagencia_y_piloto.l_idusuario_personal = CType(dtoUSUARIOS.IdLogin, Long)
        '                Obj_actagencia_y_piloto.s_ip = dtoUSUARIOS.IP
        '                'Obj_actagencia_y_piloto.ShowDialog()

        '                Acceso.Asignar(Obj_actagencia_y_piloto, Me.hnd)
        '                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
        '                    Obj_actagencia_y_piloto.ShowDialog()
        '                Else
        '                    MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                    Return
        '                End If

        '                Obj_actagencia_y_piloto = Nothing
        '            End If
        '        End If

        '    End If
        'End If
        ''---
        'Dim iidfuncionario, iidtipo_persona, icliente_corporativo, iidestado_registro As Integer
        ''
        'ObjReport.rutaRpt = PathFrmReport
        'ObjReport.conectar(rptservice, rptuser, rptpass)   'Esta conexion por ahora está en prueba (rptservice, rptuser, rptpass) '  ("tepsa", "titan", "titan")

        'Dim dv As New DataView
        'Dim objVENTA_CONTADO As New ClsLbTepsa.dtoVENTA_CONTADO
        'objVENTA_CONTADO.IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
        ''DATAHELPER
        'dv = objVENTA_CONTADO.sp_tipo_format_impre()


        ''tipo_bole_impre = dv.Table.Rows(0)("tipo_bole_impre")
        ''tipo_factu_impre = dv.Table.Rows(0)("tipo_factu_impre")
        'tipo_guia_transpor_impre = dv.Table.Rows(0)("tipo_guia_transpor_impre")
        ''
        'If Me.rbguia.Checked = True Then
        '    If tipo_guia_transpor_impre = "A" Then
        '        ObjReport.printrpt(False, "", "GUIAT001.rpt", _
        '                               "p_usuario;" & dtoUSUARIOS.iLOGIN, _
        '                               "iidguia_transportista;" & iidguia_transportista)
        '    Else
        '        'ObjReport.printrpt(False, "", "GUIAT007.rpt", _
        '        '                                       "p_usuario;" & dtoUSUARIOS.iLOGIN, _
        '        '                                       "IIDGUIA_TRANSPORTISTA;" & iidguia_transportista)
        '        Dim obj As New dtoGuiasTransp
        '        Dim dt As DataTable = obj.Guia_Transportista(iidguia_transportista)
        '        Imprimir(dt)

        '        obj = Nothing
        '    End If

        'Else
        '    'ObjReport.printrpt(False, "", "GUIAT003.rpt", _
        '    '                       "p_usuario;" & dtoUSUARIOS.iLOGIN, _
        '    '                       "iidguia_transportista;" & iidguia_transportista)
        '    Dim obj As New dtoGuiasTransp
        '    Dim dt As DataTable = obj.Manifiesto(iidguia_transportista)
        '    Manifiesto(dt)
        'End If
        ''
        'If b_actualizo = True Then
        '    Call BuscaGuiasTransporte()
        'End If
        ''---- 
        ''Dim PrDialog As New PrintPreviewDialog
        ''Dim Campos As New ArrayList
        ''If Fact = 0 Then
        ''    Impresion.Titulo = "Relacion de Itinerarios"
        ''    Impresion.Orientacion = 1
        ''    Impresion.DGV = DataGridViewLista
        ''    Impresion.TopDetalle = 100
        ''Else
        ''    Impresion.Titulo = "Relacion de Tramos"
        ''    Campos.Add("Nro.Itinerario :")
        ''    Campos.Add("100")
        ''    Campos.Add("50")
        ''    Campos.Add(Trim(TxtID.Text))
        ''    Campos.Add("250")
        ''    Campos.Add("50")
        ''    Campos.Add("Ruta           :")
        ''    Campos.Add("100")
        ''    Campos.Add("70")
        ''    Campos.Add(Trim(CbRuta.Text))
        ''    Campos.Add("250")
        ''    Campos.Add("70")
        ''    Campos.Add("Servicio        :")
        ''    Campos.Add("550")
        ''    Campos.Add("70")
        ''    Campos.Add(Trim(CbSerDet.Text))
        ''    Campos.Add("700")
        ''    Campos.Add("70")
        ''    Campos.Add("Fecha Partida  :")
        ''    Campos.Add("100")
        ''    Campos.Add("90")
        ''    Campos.Add(Trim(TxtFecInicio.GetMyFecha))
        ''    Campos.Add("250")
        ''    Campos.Add("90")
        ''    Campos.Add("Hora Partida    :")
        ''    Campos.Add("550")
        ''    Campos.Add("90")
        ''    Campos.Add(Trim(TxtHora.Text))
        ''    Campos.Add("700")
        ''    Campos.Add("90")
        ''    Campos.Add("Agencia Origen :")
        ''    Campos.Add("100")
        ''    Campos.Add("110")
        ''    Campos.Add(Trim(CbAge1.Text))
        ''    Campos.Add("250")
        ''    Campos.Add("110")
        ''    Campos.Add("Agencia Destino :")
        ''    Campos.Add("550")
        ''    Campos.Add("110")
        ''    Campos.Add(Trim(CbAge2.Text))
        ''    Campos.Add("700")
        ''    Campos.Add("110")
        ''    Impresion.TopDetalle = 200
        ''    Impresion.Orientacion = 1
        ''    Impresion.DGV = DataGridDeta
        ''End If
        ''Impresion.Lista = Campos
        ''PrDialog.Document = Impresion
        ''PrDialog.ShowDialog()
    End Sub
    Private Sub FrmGuiasTranspor_MenuNuevo() Handles Me.MenuNuevo
        Fact = 1
        STxtCodDes = ""
        TxtFecInicio._MyFecha = Today.ToString
        DtDetalle.Clear()
        DtDetaDoc.Clear()
        DtIti.Clear()
        TxtBus.Text = ""
        TxtCodDes.Text = ""
        TxtSerie.Text = ""
        TxtNroGuia.Text = ""
        TxtID.Text = ""
        TxtNroSalida.Text = ""
        TxtSerie.Enabled = True
        TxtNroGuia.Enabled = True
        TxtID.Enabled = True
        TxtCodDes.Enabled = True
        CbOriDet.Enabled = True
        CbDesDet.Enabled = True
        CbOriDet.BackColor = Color.White
        CbDesDet.BackColor = Color.White
        TxtSerie.BackColor = Color.White
        TxtNroGuia.BackColor = Color.White
        TxtID.BackColor = Color.White
        TxtCodDes.BackColor = Color.White
        txtGuiaEnvio.Text = ""
        'TxtRuta.Text = ""
        'TxtHora.Text = ""
        CbBus.Enabled = True
        DvCbDes.RowFilter = "idunidad_agencia <> 9999"
        CbTipoServ.Text = "JOTASYS"
        If DvCbEnt.Count < 1 Then
            'If CbBus.SelectedIndex < 0 Then  ' Modificado por Tepsa 22/12/2006
            MessageBox.Show("No existe bodegas cerradas para este día", "Guía transportista", MessageBoxButtons.OK, MessageBoxIcon.Information)
            fb_cambia_fact = True
            FrmGuiasTranspor_MenuCancelar()
            fb_cambia_fact = False
            Exit Sub
        End If
        '
        CbBus.SelectedValue = -1 ' Por defecto no debe aparacer nada seleccionado 2007
        'CbBus.SelectedIndex    = 0  Comentado por Tepsa 23/12/2006
        'CbDesDet.SelectedIndex = 0  Comentado por Tepsa 23/12/2006 
        '
        ' CbOriDet.SelectedIndex = UbicaComboDirecto(DvCbUnd, dtoUSUARIOS.iIDAGENCIAS.ToString, "idunidad_agencia", "nombre_unidad") ' Comentado  por tepsa 18/12/2006
        CbOriDet.SelectedValue = dtoUSUARIOS.m_idciudad
        ' Recuperando la serie y el Nro de documento 
        '01/02/2008 
        If es_inhouse = False Then
            fnNroDocumento(8)
        Else
            TxtSerie.Text = ""
            TxtNroGuia.Text = ""
            chkcontroldestino.Checked = True
        End If

        Me.chkCa.Enabled = True
        Me.chkCa.Checked = False
        Me.cboCarga.SelectedIndex = -1
        '        
    End Sub
    'Private Sub BtnElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnElimina.Click
    '    'Try
    '    '    filcb = DvDetalle.Count
    '    '    If filcb > 0 Then
    '    '        filcb = DataGridDeta.CurrentRow.Index
    '    '        If filcb >= 0 Then
    '    '            If filcb + 1 = DvDetalle.Count Then
    '    '                Call UpdateCopyDetail(filcb)
    '    '                DvDetalle.Delete(filcb)
    '    '            Else
    '    '                dr = DvDetalle.Item(filcb)
    '    '                fec_ini = dr("fecha_partida")
    '    '                conta = dr("item")
    '    '                AgeOri = dr("idunidad_origen")
    '    '                CiuOri = dr("origen")
    '    '                SwDetAge1 = dr("idagencia_origen")
    '    '                NAgeOri = dr("agencia_origen")
    '    '                dr("flgdel") = 1
    '    '                dr = DvDetalle.Item(filcb + 1)
    '    '                AgeDes = dr("idunidad_destino")
    '    '                CiuDes = dr("destino")
    '    '                SwDetAge2 = dr("idagencia_destino")
    '    '                NAgeDes = dr("agencia_destino")
    '    '                dr("flgdel") = 1
    '    '                DvCbDetRut.RowFilter = "idunidad_agencia = " & Convert.ToString(AgeOri) & " and idunidad_agencia_destino = " & Convert.ToString(AgeDes)
    '    '                If DvCbDetRut.Count > 0 Then
    '    '                    DrRuta = DvCbDetRut.Item(0)
    '    '                    filcb = DvDetalle.Count
    '    '                    DvDetalle.AllowNew = True
    '    '                    DvDetalle.AddNew()
    '    '                    dr = DvDetalle.Item(filcb)
    '    '                    dr("item") = conta
    '    '                    dr("idrutas_itinerarios") = 0
    '    '                    dr("idrutas") = DrRuta("idrutas")
    '    '                    dr("origen") = DrRuta("origen")
    '    '                    dr("destino") = DrRuta("destino")
    '    '                    dr("dias_viaje") = DrRuta("dias_viaje")
    '    '                    dr("horas_viaje") = DrRuta("horas_de_viaje")
    '    '                    dr("idagencia_origen") = SwDetAge1
    '    '                    dr("agencia_origen") = NAgeOri
    '    '                    dr("idagencia_destino") = SwDetAge2
    '    '                    dr("agencia_destino") = NAgeDes
    '    '                    dr("idunidad_origen") = DrRuta("idunidad_agencia")
    '    '                    dr("idunidad_destino") = DrRuta("idunidad_agencia_destino")
    '    '                    filcb = DvDetalle.Count
    '    '                    DvDetalle.AddNew()
    '    '                    DvDetalle.Delete(filcb)
    '    '                    DvDetalle.AllowNew = False
    '    '                    For i = 1 To DvDetalle.Count
    '    '                        If i > DvDetalle.Count Then
    '    '                            Exit For
    '    '                        End If
    '    '                        dr = DvDetalle.Item(i - 1)
    '    '                        conta = IIf(IsDBNull(dr("flgdel")) = True, 0, dr("flgdel"))
    '    '                        If conta = 1 Then
    '    '                            Call UpdateCopyDetail(i - 1)
    '    '                            DvDetalle.Delete(i - 1)
    '    '                            i = i - 1
    '    '                        End If
    '    '                    Next
    '    '                    DvDetalle.Sort = "item"
    '    '                    Call RecalculaFechas(Convert.ToDateTime(TxtFecInicio.GetMyFecha))
    '    '                Else
    '    '                    MsgBox("Ruta " + CiuOri + "-" + CiuDes + " No Existe", MsgBoxStyle.Critical, "Seguridad Sistema")
    '    '                End If
    '    '            End If
    '    '        End If
    '    '    End If
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    'End Try
    'End Sub

    'Private Sub BtnInserta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInserta.Click
    '    Try
    '        If TxtFecInicio.GetMyFecha = "  /  /" Then
    '            MsgBox("Fecha de Partida Vacia, Verifique", MsgBoxStyle.Critical, "Seguridad Sistema")
    '            Exit Sub
    '        End If
    '        If TxtHora.Text = "  :" Then
    '            MsgBox("Hora de Partida Vacia, Verifique", MsgBoxStyle.Critical, "Seguridad Sistema")
    '            Exit Sub
    '        End If
    '        If DvDetalle.Count > 0 Then
    '            filcb = DataGridDeta.CurrentRow.Index
    '            dr = DvDetalle.Item(filcb)
    '            SwDetRuta = IIf(IsDBNull(dr("idunidad_origen")) = True, 0, dr("idunidad_origen"))
    '            AgeDes = IIf(IsDBNull(dr("idunidad_destino")) = True, 0, dr("idunidad_destino"))
    '            fec_ini = dr("fecha_partida")
    '            conta = dr("item")
    '            SwDetAge1 = 0
    '            Dim Detalle As New FrmDetaItinerarios(DvCbDetRut, DvCbDetAg1, DvCbDetAg2)
    '            Detalle.ShowDialog()
    '            AgeOri = Detalle.AgeOri
    '            If SwFlgDet = 1 Then
    '                DvCbDetRut.RowFilter = "idunidad_agencia = " & Convert.ToString(AgeOri) & " and idunidad_agencia_destino = " & Convert.ToString(AgeDes)
    '                If DvCbDetRut.Count = 0 Then
    '                    MsgBox("Destino no tiene Ruta Asociada", MsgBoxStyle.Critical, "Seguridad Sistema")
    '                    DvCbDetRut.RowFilter = ""
    '                    Exit Sub
    '                End If
    '                DvCbDetRut.RowFilter = "idrutas = " + SwDetRuta.ToString
    '                If DvCbDetRut.Count > 0 Then
    '                    DrRuta = DvCbDetRut.Item(0)
    '                    DrAge1 = DvCbDetAg1.Item(SwDetAge1)
    '                    DrAge2 = DvCbDetAg2.Item(SwDetAge2)
    '                    Call UpdateCopyDetail(filcb)
    '                    DvDetalle.Delete(filcb)
    '                    filcb = DvDetalle.Count
    '                    DvDetalle.AllowNew = True
    '                    DvDetalle.AddNew()
    '                    dr = DvDetalle.Item(filcb)
    '                    dr("item") = conta
    '                    dr("idrutas_itinerarios") = 0
    '                    dr("idrutas") = DrRuta("idrutas")
    '                    dr("origen") = DrRuta("origen")
    '                    dr("destino") = DrRuta("destino")
    '                    dr("dias_viaje") = DrRuta("dias_viaje")
    '                    dr("horas_viaje") = DrRuta("horas_de_viaje")
    '                    dr("idagencia_origen") = DrAge1("idagencias")
    '                    dr("agencia_origen") = DrAge1("nombre_agencia")
    '                    dr("idagencia_destino") = DrAge2("idagencias")
    '                    dr("agencia_destino") = DrAge2("nombre_agencia")
    '                    dr("idunidad_origen") = DrRuta("idunidad_agencia")
    '                    dr("idunidad_destino") = DrRuta("idunidad_agencia_destino")
    '                    fec_ini = fec_fin
    '                    DvCbDetRut.RowFilter = "idunidad_agencia = " & Convert.ToString(AgeOri) & " and idunidad_agencia_destino = " & Convert.ToString(AgeDes)
    '                    If DvCbDetRut.Count > 0 Then
    '                        DrRuta = DvCbDetRut.Item(0)
    '                        filcb = DvDetalle.Count
    '                        DvDetalle.AddNew()
    '                        dr = DvDetalle.Item(filcb)
    '                        dr("item") = conta + 5
    '                        dr("idrutas_itinerarios") = 0
    '                        dr("idrutas") = DrRuta("idrutas")
    '                        dr("origen") = DrRuta("origen")
    '                        dr("destino") = DrRuta("destino")
    '                        dr("dias_viaje") = DrRuta("dias_viaje")
    '                        dr("horas_viaje") = DrRuta("horas_de_viaje")
    '                        dr("idagencia_origen") = DrAge1("idagencias")
    '                        dr("agencia_origen") = DrAge1("nombre_agencia")
    '                        dr("idagencia_destino") = DrAge2("idagencias")
    '                        dr("agencia_destino") = DrAge2("nombre_agencia")
    '                        dr("idunidad_origen") = DrRuta("idunidad_agencia")
    '                        dr("idunidad_destino") = DrRuta("idunidad_agencia_destino")
    '                        filcb = DvDetalle.Count
    '                        DvDetalle.AddNew()
    '                        DvDetalle.Delete(filcb)
    '                    End If
    '                    DvDetalle.AllowNew = False
    '                    DvDetalle.Sort = "item"
    '                    Call RecalculaFechas(Convert.ToDateTime(TxtFecInicio.GetMyFecha))
    '                End If
    '                DvCbDetRut.RowFilter = ""
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub

    'Private Sub TxtFecInicio_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtFecInicio.Validating
    '    If TxtFecInicio.GetMyFecha <> "  /  /" Then
    '        Try
    '            fec_ini = Convert.ToDateTime(TxtFecInicio.GetMyFecha)
    '            TxtFecIni._MyFecha = TxtFecInicio.GetMyFecha
    '            TxtFecFin._MyFecha = TxtFecInicio.GetMyFecha
    '            Call RecalculaFechas(Convert.ToDateTime(TxtFecInicio.GetMyFecha))
    '        Catch ex As Exception
    '            MsgBox("Formato de Fecha Incorrecto", MsgBoxStyle.Critical, "Seguridad Sistema")
    '            e.Cancel = True
    '        End Try
    '    End If
    'End Sub


    'Private Sub BtnAyuRut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAyuRut.Click
    '    DtAyuRut = DtCbRut.Copy
    '    Dim Ayuda As New FrmRutas
    '    Ayuda.ShowDialog()
    '    DtCbRut = DtAyuRut.Copy
    '    DtCbDetRut = DtAyuRut.Copy
    '    DvCbRut = DtCbRut.DefaultView
    '    DvCbDetRut = DtCbDetRut.DefaultView
    '    LlenaCombo2(DvCbRut, CbRuta, "nombre_ruta")
    'End Sub


    'Private Sub BtnAyuAge1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAyuAge1.Click
    '    Try
    '        NAgeOri = DvCbAg1.RowFilter
    '        NAgeDes = DvCbAg2.RowFilter
    '        DtAyuRut = DtCbAg1.Copy
    '        DvCbAg1.RowFilter = ""
    '        DvCbAg2.RowFilter = ""
    '        Dim Ayuda As New FrmAgencias
    '        Ayuda.ShowDialog()
    '        DtCbAg1 = DtAyuRut.Copy
    '        DtCbAg2 = DtAyuRut.Copy
    '        DtCbDetAg1 = DtAyuRut.Copy
    '        DtCbDetAg2 = DtAyuRut.Copy
    '        DvCbAg1 = DtCbAg1.DefaultView
    '        DvCbAg2 = DtCbAg2.DefaultView
    '        DvCbDetAg1 = DtCbDetAg1.DefaultView
    '        DvCbDetAg2 = DtCbDetAg2.DefaultView
    '        LlenaCombo2(DvCbAg1, CbAge1, "nombre_agencia")
    '        LlenaCombo2(DvCbAg2, CbAge2, "nombre_agencia")
    '        DvCbAg1.RowFilter = NAgeOri
    '        DvCbAg2.RowFilter = NAgeDes
    '    Catch ex As Exception
    '        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub

    'Private Sub BtnAyuAge2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAyuAge2.Click
    '    Try
    '        NAgeOri = DvCbAg1.RowFilter
    '        NAgeDes = DvCbAg2.RowFilter
    '        DtAyuRut = DtCbAg1.Copy
    '        DvCbAg1.RowFilter = ""
    '        DvCbAg2.RowFilter = ""
    '        Dim Ayuda As New FrmAgencias
    '        Ayuda.ShowDialog()
    '        DtCbAg1 = DtAyuRut.Copy
    '        DtCbAg2 = DtAyuRut.Copy
    '        DtCbDetAg1 = DtAyuRut.Copy
    '        DtCbDetAg2 = DtAyuRut.Copy
    '        DvCbAg1 = DtCbAg1.DefaultView
    '        DvCbAg2 = DtCbAg2.DefaultView
    '        DvCbDetAg1 = DtCbDetAg1.DefaultView
    '        DvCbDetAg2 = DtCbDetAg2.DefaultView
    '        LlenaCombo2(DvCbAg1, CbAge1, "nombre_agencia")
    '        LlenaCombo2(DvCbAg2, CbAge2, "nombre_agencia")
    '        DvCbAg1.RowFilter = NAgeOri
    '        DvCbAg2.RowFilter = NAgeDes
    '    Catch ex As Exception
    '        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub
    Sub Edicion()
        'Dim rsIti As ADODB.Recordset
        Dim filarow As Integer
        Dim DrUnd As DataRowView
        Dim lidunidad_agencia_dest As Long
        Dim lidunidad_transporte As Long
        Dim lidunidad_trans As Long
        Dim lid_agencia_destino As Long
        'Dim rsttemporal As New ADODB.Recordset
        '
        Dim lestado_bus As Long  'Estado del Bus 
        '
        Try
            b_copia = False
            filarow = DataGridViewLista.CurrentRow.Index
            If filarow >= 0 Then
                DrUnd = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
                '        ClaseDet.ID = Convert.ToString(DrUnd("iditinerarios"))
                '        DtDetalle.Clear()
                '        rstDetalle = ClaseDet.Lista
                '        dr4.Fill(DtDetalle, rstDetalle)
                '        DvDetalle = DtDetalle.DefaultView
                '        DtDetaCopy = DtDetalle.Copy
                '        DvDetaCopy = DtDetaCopy.DefaultView            
                TxtID.Text = Convert.ToString(DrUnd("IDGUIA_TRANSPORTISTA"))
                TxtSerie.Text = Convert.ToString(DrUnd("serie_guia_transportista"))
                TxtNroGuia.Text = Convert.ToString(DrUnd("nro_guia_transportista"))
                'TxtSerie.Enabled = False
                'TxtNroGuia.Enabled = False
                'TxtSerie.BackColor = System.Drawing.SystemColors.Info
                'TxtNroGuia.BackColor = System.Drawing.SystemColors.Info
                TxtFecInicio._MyFecha = DrUnd("fecha_salida")
                lestado_bus = 0
                If DrUnd("idunidad_transporte") = False Then
                    lidunidad_transporte = -666
                Else
                    lidunidad_transporte = CType(DrUnd("idunidad_transporte"), Long)
                End If
                '
                If IsDBNull(DrUnd("hora_salida")) = True Then
                    Me.txthorasalida.Text = ""
                Else
                    Me.txthorasalida.Text = CType(DrUnd("hora_salida"), String)
                End If
                '
                If IsDBNull(DrUnd("idagencias_destino")) = True Then
                    Me.cmb_agencia_destino.SelectedValue = -666
                    lid_agencia_destino = -666
                Else
                    Me.cmb_agencia_destino.SelectedValue = CType(DrUnd("idagencias_destino"), Long)
                    lid_agencia_destino = CType(DrUnd("idagencias_destino"), Long)
                End If
                '
                If IsDBNull(DrUnd("nro_salida")) = False Then
                    TxtNroSalida.Text = DrUnd("nro_salida")
                    If TxtNroSalida.Text = "-1" Then
                        TxtNroSalida.Text = "S/N"
                    End If
                    'Estado del Numero de Salida 
                    If IsDBNull(DrUnd("estado_bus")) = False Then
                        lestado_bus = CType(DrUnd("estado_bus"), Long)
                    End If
                Else
                    TxtNroSalida.Text = ""
                End If
                '
                TxtNroSalida.Enabled = False  ' Tepsa 11/11/2006
                '
                'If DtCbEnt.Rows.Count < 1 Then  'Comentado el día 26/01/2007
                '
                If DtCbEnt.Rows.Count >= 1 Then  'Creado por Tepsa                 
                    ' Requerido 
                    b_copia = True
                    DtCbEnt_tmp = Nothing
                    DvCbEnt_tmp = Nothing
                    DtCbEnt_tmp = New DataTable
                    DvCbEnt_tmp = New DataView
                    DtCbEnt_tmp = DtCbEnt.Copy
                    DvCbEnt_tmp = DtCbEnt.DefaultView 'DtCbEnt_tmp.DefaultView 
                    ''Recuperando el nro de salida 
                    'Clase.nrosalida_real = TxtNroSalida.Text
                    'rsttemporal = Clase.fn_sp_recupera_nrosalida()
                    '' Cargando de nuevo los valores 
                    'DtCbEnt = Nothing
                    'DvCbEnt = Nothing
                    'DtCbEnt = New DataTable
                    'DvCbEnt = New DataView
                    ''
                    'dr4.Fill(DtCbEnt, rsttemporal)
                    'DvCbEnt = DtCbEnt.DefaultView
                    '' 
                    ''Comentado hecho por Eduardo  
                    ''LlenaCombo2(DvCbEnt, CbBus, "NOMBRE_TRANSPORTE")
                    ''               
                    'DvCbEnt = CargarCombo(CbBus, DtCbEnt, "NOMBRE_TRANSPORTE", "idunidad_transporte", lidunidad_transporte)
                End If
                If TxtNroSalida.Text = "" Then
                    Clase.nrosalida_real = -666
                Else
                    If TxtNroSalida.Text = "S/N" Then  ' Si el Número de salida no tine Nº se pondra -1
                        Clase.nrosalida_real = -1
                    Else
                        Clase.nrosalida_real = TxtNroSalida.Text
                    End If

                End If
                'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
                'rsttemporal = Clase.fn_sp_recupera_nrosalida()
                ' Cargando de nuevo los valores 
                DtCbEnt = Nothing
                DvCbEnt = Nothing
                DtCbEnt = New DataTable
                DvCbEnt = New DataView
                '
                'dr4.Fill(DtCbEnt, rsttemporal)
                DtCbEnt = Clase.fn_sp_recupera_nrosalida()
                DvCbEnt = DtCbEnt.DefaultView
                ' 
                DvCbEnt = CargarCombo(CbBus, DtCbEnt, "NOMBRE_TRANSPORTE", "idunidad_transporte", lidunidad_transporte)
                'Agregado por Tepsa 21/12/2006 
                If DtCbEnt.Rows.Count > 0 Then
                    If IsDBNull(DtCbEnt.Rows(0)(0)) = True Then
                        lidunidad_trans = -666
                    Else
                        lidunidad_trans = CType(DtCbEnt.Rows(0)(0), Long)
                    End If
                Else
                    lidunidad_trans = -666
                End If
                '
                txtGuiaEnvio.Text = ""
                If IsDBNull(DrUnd("idunidad_transporte")) = True Then
                    TxtBus.Text = ""
                Else
                    TxtBus.Text = DrUnd("idunidad_transporte")  'Modificado por Tepsa 22/11/2006
                End If
                '
                CbBus.SelectedValue = lidunidad_trans ' Comentado por Tepsa 21/12/2006
                '
                'TxtBus.Text = CType(DrUnd("nro_unidad_transporte"), String)
                'Comentado por Tepsa 20/12/2006, las 2 líneas de abajo.   
                'CbOriDet.SelectedIndex = UbicaCombo2(DvCbUnd, DrUnd, "idunidad_agencia", "idunidad_agencia", "nombre_unidad")
                'CbDesDet.SelectedIndex = UbicaCombo2(DvCbDes, DrUnd, "idunidad_agencia", "idunidad_agencia_destino", "nombre_unidad")
                '
                CbOriDet.SelectedValue = CType(DrUnd("idunidad_agencia"), Long)
                lidunidad_agencia_dest = CType(DrUnd("idunidad_agencia_destino"), Long)
                CbDesDet.SelectedValue = lidunidad_agencia_dest
                '
                TxtCodDes.Enabled = False
                CbOriDet.Enabled = False
                CbDesDet.Enabled = False
                TxtCodDes.BackColor = System.Drawing.SystemColors.Info
                CbOriDet.BackColor = System.Drawing.SystemColors.Info
                CbDesDet.BackColor = System.Drawing.SystemColors.Info
                '
                'Modificado 17/07/2009 - Se comento p'q' solo se necesita el valor 
                'SelectedIndex = UbicaCombo2(DvCbFor, DrUnd, "idtipo_servicio", "idtipo_servicio", "tipo_servicio")
                Me.CbTipoServ.SelectedValue = DrUnd("idtipo_servicio")
                '
                '
                If IsDBNull(DrUnd("idusuario_personal_piloto")) = True Then
                    Try 'Solo para q' no mueste el mensaje 
                        CbChofer.SelectedIndex = -666
                    Catch ex As Exception

                    End Try
                Else
                    CbChofer.SelectedIndex = UbicaCombo2(DvCbMov, DrUnd, "idusuario_personal", "idusuario_personal_piloto", "NOMBRE")
                End If
                '
                '
                'Comentado por tepsa el 20/12/2006 
                'CbBus.SelectedIndex = UbicaCombo2(DvCbEnt, DrUnd, "idunidad_transporte", "idunidad_transporte", "NOMBRE_TRANSPORTE")
                Clase.CiuOrigen = DrUnd("idunidad_agencia")
                'Clase.CiuDestino = DrUnd("idunidad_agencia_destino")
                Clase.CiuDestino = lidunidad_agencia_dest
                Clase.IATA = DrUnd("codigo_iata")
                Clase.IATADes = DrUnd("codigo_iata_destino")
                '12/08/2009 - Verificar 
                Clase.idagencia_ori = DrUnd("idagencias") 'verificar 

                'hlamas 27/02/2017
                If DrUnd("TIPO_CARGA") = 0 Then
                    Me.chkCa.Checked = False
                Else
                    Me.chkCa.Checked = True
                    'RemoveHandler Me.cboCarga.SelectedIndexChanged, AddressOf Me.cboCarga_SelectedIndexChanged
                    Me.cboCarga.SelectedIndex = DrUnd("TIPO_CARGA") - 1
                    'addHandler Me.cboCarga.SelectedIndexChanged, AddressOf Me.cboCarga_SelectedIndexChanged
                End If
                If Me.chkCa.Checked Then
                    Clase.FechaPartida = Me.TxtFecInicio.GetMyFecha
                    Clase.HoraPartida = IIf(Me.cboCA.SelectedIndex = 0, "", Me.cboCA.Text)
                    Clase.Ca = 1
                Else
                    Clase.Ca = 0
                    Clase.FechaPartida = ""
                    Clase.HoraPartida = ""
                End If
                Me.chkCa.Enabled = False
                Me.cboCarga.Enabled = False

                'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
                Dim lds_tmp As New DataSet
                '
                'rsIti = Clase.BuscaItinerario_2
                'rstDetalle = rsIti.NextRecordset
                'dr4.Fill(DtIti, rsIti)
                'dr4.Fill(DtDetalle, rstDetalle)
                '
                DtDetalle.Clear()
                DtIti.Clear()
                '
                lds_tmp = Clase.BuscaItinerario_2
                DtIti = lds_tmp.Tables(0)
                DtDetalle = lds_tmp.Tables(1)

                ComprobanteRepetido(DtDetalle)

                dtHoraSalida = lds_tmp.Tables(2)
                '
                dvIti = DtIti.DefaultView
                '
                DvDetalle = DtDetalle.DefaultView
                DvDetalle.AllowNew = False
                Call GrillaDeta()
                '
                ClaseDet.ID = Convert.ToString(DrUnd("IDGUIA_TRANSPORTISTA"))
                DtDetaDoc.Clear()
                'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
                'rstDetaDoc = ClaseDet.Lista()
                'dr4.Fill(DtDetaDoc, rstDetaDoc)
                DtDetaDoc = ClaseDet.Lista()
                DvDetaDoc = DtDetaDoc.DefaultView
                DvDetaDoc.AllowNew = False
                Call GrillaDetaDoc()
                TabMante.SelectedIndex = 1
                ' Desabilitando valores 
                TxtBus.ReadOnly = True
                CbBus.Enabled = False
                CbBus.BackColor = System.Drawing.SystemColors.Info
                TxtMarca.ReadOnly = True
                TxtMarca.BackColor = System.Drawing.SystemColors.Info
                TxtPlaca.ReadOnly = True
                TxtPlaca.BackColor = System.Drawing.SystemColors.Info
                ''''''''
                ' Recupera el estado del bus para bloquear los campos de la guía de transportista 
                If lestado_bus = 35 Or lestado_bus = 36 Or lestado_bus = 37 Then
                    CbBus.Enabled = False
                    CbTipoServ.Enabled = False
                    TxtFecInicio.Enabled = False
                    CbItinerarios.Enabled = False
                    CbOriDet.Enabled = False
                    CbDesDet.Enabled = False
                    chkcontroldestino.Enabled = False
                    TxtCodDes.Enabled = False
                    CbChofer.Enabled = False
                    btnEnvio.Enabled = False
                    txtGuiaEnvio.Enabled = False
                    BtAgregar.Enabled = False
                    BtSacar.Enabled = False
                    DataGridViewUnd.Enabled = False
                    'DataGridViewGuia.Enabled = False
                    GrabarToolStripMenuItem.Enabled = False
                    b_habilita_grabar = False
                End If
                ''''''''
                '
                'LlenaCombo2(DvCbMov, CbChofer, "NOMBRE")
                'LlenaCombo2(DvCbUnd, CbOriDet, "NOMBRE_UNIDAD")
                'LlenaCombo2(DvCbDes, CbDesDet, "NOMBRE_UNIDAD")
                'LlenaCombo2(DvCbEnt, CbBus, "NOMBRE_TRANSPORTE")
                ''LlenaCombo2(DvCbEnt, CbBus, "PLACA")
                'LlenaCombo2(DvCbFor, CbTipoServ, "TIPO_SERVICIO")
                '        CbRuta.SelectedIndex = UbicaCombo2(DvCbRut, DrUnd, "idrutas", "idrutas", "nombre_ruta")
                '        CbAge1.SelectedIndex = UbicaCombo2(DvCbAg1, DrUnd, "idagencias", "idagencia_origen", "nombre_agencia")
                '        CbAge2.SelectedIndex = UbicaCombo2(DvCbAg2, DrUnd, "idagencias", "idagencia_destino", "nombre_agencia")
                '        CbSerDet.SelectedIndex = UbicaCombo2(DvCbSde, DrUnd, "idclase", "idclase", "clase")
                '        TxtMensaje.Text = "Modificacion"
                '        TxtFecIni.Enabled = False
                '        TxtFecFin.Enabled = False
                '        ImprimirToolStripMenuItem.Enabled = True
                '        'Call GrillaMante()
                '        CbOriDet.Focus()
                ImprimirToolStripMenuItem.Enabled = True   ' Tepsa - O.
                Me.lbNroRagistros.Text = DataGridViewGuia.Rows.Count
                'Paso al ultima fila 11/08/2009 
                TxtSerie.Enabled = False
                TxtNroGuia.Enabled = False
                TxtSerie.BackColor = System.Drawing.SystemColors.Info
                TxtNroGuia.BackColor = System.Drawing.SystemColors.Info
                '''''''''''''''''''''''''
                If lid_agencia_destino > 0 Then
                    Me.cmb_agencia_destino.SelectedValue = lid_agencia_destino
                End If
            End If
            Spk()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    'Sub RecalculaFechas(ByVal fec_inicial As Date)
    '    If DvDetalle.Count > 0 Then
    '        fec_ini = DateAdd(DateInterval.Hour, Convert.ToDouble(Mid(TxtHora.Text, 1, 2)), fec_inicial)
    '        fec_ini = DateAdd(DateInterval.Minute, Convert.ToDouble(Mid(TxtHora.Text, 4, 2)), fec_ini)
    '        hora_ini = Mid(Convert.ToString(fec_ini), 12, 13)
    '        For i = 1 To DvDetalle.Count
    '            If i > DvDetalle.Count Then
    '                Exit For
    '            End If
    '            dr = DvDetalle.Item(i - 1)
    '            ndias = IIf(IsDBNull(dr("dias_viaje")) = True, 0, dr("dias_viaje"))
    '            chora = IIf(IsDBNull(dr("horas_viaje")) = True, "00:00", dr("horas_viaje"))
    '            fec_fin = CalculaFechaLlegada(ndias, chora, fec_ini)

    '            dr("hora_partida") = Mid(Convert.ToString(fec_ini), 12, 13)
    '            dr("hora_llegada") = Mid(Convert.ToString(fec_fin), 12, 13)
    '            dr("fecha_partida") = fec_ini
    '            dr("fecha_llegada") = fec_fin
    '            hora_fin = Mid(Convert.ToString(fec_fin), 12, 13)
    '            fec_ini = fec_fin
    '        Next
    '    End If

    'End Sub
    'Sub UpdateCopyDetail(ByVal SId As Integer)
    '    DrCopy = DvDetalle.Item(SId)
    '    If DrCopy("idrutas_itinerarios") > 0 Then
    '        DvDetaCopy.Sort = "idrutas_itinerarios"
    '        IDUser = DvDetaCopy.Find(DrCopy("idrutas_itinerarios"))
    '        If IDUser >= 0 Then
    '            dr2 = DvDetaCopy.Item(IDUser)
    '            dr2("flgdel") = 1
    '        End If
    '    End If
    'End Sub
    Public Function BuscaRecojos() As Boolean

        'Dim movil, ruta, estado As Integer

        'Dim rstbus As ADODB.Recordset
        'Try
        '    DtDetalle.Clear()
        '    If CbMovil.Items().Count > 0 Then
        '        Dim dt1 As Object = CbMovil.SelectedIndex
        '        Dim dt2 As Object = CbRutMov.SelectedIndex
        '        Dim dt3 As Object = CbEstado.SelectedIndex
        '        If IsNothing(dt1) = False And IsNothing(dt2) = False And IsNothing(dt3) = False Then
        '            dr = DvCbMov.Item(CbMovil.SelectedIndex)
        '            dr2 = DvCbRut.Item(CbRutMov.SelectedIndex)
        '            dr3 = DvCbSta.Item(CbEstado.SelectedIndex)
        '        Else
        '            dr = DvCbMov.Item(0)
        '            dr2 = DvCbRut.Item(0)
        '            dr3 = DvCbSta.Item(0)
        '        End If
        '    Else
        '        dr = DvCbMov.Item(0)
        '        dr2 = DvCbRut.Item(0)
        '        dr3 = DvCbSta.Item(0)
        '    End If



        '    movil = dr("IDUNIDAD_TRANSPORTE")
        '    ruta = dr2("IDRUTA_ENTREGA_RECOJO")
        '    estado = dr3("IDESTADO_REGISTRO")
        '    Clase.Movil = movil
        '    Clase.Ruta = ruta
        '    Clase.Estado = estado
        '    If Trim(TxtCliente.Text) = "" Then
        '        TxtCliente.Text = "%"
        '    End If
        '    If IsNumeric(TxtCliente.Text) = True Then
        '        Clase.Ruc = Trim(TxtCliente.Text)
        '        Clase.Cliente = "ZZZZ"
        '    Else
        '        Clase.Ruc = "0"
        '        Clase.Cliente = Trim(TxtCliente.Text)
        '    End If
        '    Clase.Fecha_Ini = TxtFechaIni.GetMyFecha
        '    Clase.Fecha_Fin = TxtFechaFin.GetMyFecha
        '    rstbus = Clase.Buscar
        '    dr4.Fill(DtDetalle, rstbus)
        '    DvDetalle = DtDetalle.DefaultView
        '    DvDetalle.AllowNew = False
        '    'MessageBox.Show(DvDetalle.Count.ToString)
        '    Call GrillaMante()
        '    'DvCbRut.RowFilter = "idunidad_agencia = " + origen.ToString + " and idunidad_agencia_destino = " + destino.ToString
        '    'If DvCbRut.Count > 0 Or origen = 9999 Or destino = 9999 Then
        '    '    dr = DvCbRut.Item(0)
        '    '    Clase.Ruta = dr("idrutas")
        '    '    Clase.Fecha_Ini = TxtFechaIni.GetMyFecha
        '    '    Clase.Fecha_Lle = TxtFechaFin.GetMyFecha
        '    '    DtIti.Clear()
        '    '    rstIti = Clase.Buscar
        '    '    da.Fill(DtIti, rstIti)
        '    '    DvAgencia = DtIti.DefaultView
        '    '    DvAgencia.AllowNew = False
        '    '    Call GrillaMante2()
        '    'Else
        '    '    MsgBox("El Origen y Destino Seleccionado no tiene una Ruta Registrada", MsgBoxStyle.Critical, "Seguridad Sistema")
        '    'End If
        '    'DvCbRut.RowFilter = ""
        'Catch ex As Exception
        '    MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        'End Try
        Return False
    End Function
    Private Sub GridListaPedidos_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridViewLista.CellFormatting
        'Dim strvar As String = ""
        'Try
        '    strvar = e.RowIndex.ToString()
        '    'If bformatImage = True Then
        '    If e.ColumnIndex = 0 Then
        '        Dim IdEstado As Integer
        '        IdEstado = DataGridViewLista.Rows().Count
        '        If e.RowIndex >= 0 And DataGridViewLista.Rows().Count - 1 >= e.RowIndex Then
        '            dr = DvDetalle.Item(e.RowIndex)
        '            IdEstado = dr("idestado_recojo")
        '            'If IsDBNull(DataGridViewLista.Rows(e.RowIndex).Cells(1).Value) = False Then
        '            '    ' GridListaPedidos.Rows(e.RowIndex).Cells(0).Tag = 1
        '            '    IdEstado = DataGridViewLista.Rows(e.RowIndex).Cells(9).Value
        '            '    'IdEstado = GridListaPedidos.Rows(e.RowIndex).Cells(1).Value
        '            '    'IdEstado = GridListaPedidos.Rows(e.RowIndex).Cells(9).Value
        '            'Else
        '            '    IdEstado = 0
        '            'End If
        '            'IdEstado = IIf(IsNothing(DataGridViewUser.Rows(e.RowIndex).Cells(7).Value), 0, DataGridViewUser.Rows(e.RowIndex).Cells(7).Value)
        '            Select Case IdEstado
        '                Case 10
        '                    e.Value = bmActivo
        '                Case 11
        '                    e.Value = bmPendiente
        '                Case 3
        '                    e.Value = bmEliminado
        '                Case Else
        '                    e.Value = bmPendiente
        '            End Select
        '            'GridListaPedidos.UpdateCellValue(e.ColumnIndex, e.RowIndex)
        '            'GridListaPedidos.Update()
        '            'Update()

        '        End If
        '    End If

        '    'End If

        'Catch ex As Exception
        '    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema" & strvar)
        'End Try
    End Sub
    Private Sub ChkDocu_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If ChkDocu.Checked = True Then
        '    SplitGuiaEnvio.Panel1Collapsed = False
        '    SplitGuiaEnvio.Panel2Collapsed = False
        'Else
        '    SplitGuiaEnvio.Panel1Collapsed = True
        '    SplitGuiaEnvio.Panel2Collapsed = False
        'End If
    End Sub
    Private Sub ChkDirec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ChkDirec.Checked = True Then
        '    CbBus.Visible = False
        '    TxtDireccion.Visible = True
        'Else
        '    CbBus.Visible = True
        '    TxtDireccion.Visible = False
        'End If
    End Sub
    Private Sub ChkContac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ChkContac.Checked = True Then
        '    CbChofer.Visible = False
        '    TxtContacto.Visible = True
        'Else
        '    CbChofer.Visible = True
        '    TxtContacto.Visible = False
        'End If
    End Sub
    Private Sub TxtCodDes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodDes.Validating
        'Dim rsIti As ADODB.Recordset
        Dim lds_tmp As New DataSet
        Dim drvOri, drvDes As DataRowView
        If TxtCodDes.Text <> "" Then
            valor = Trim(TxtCodDes.Text)
            DvCbDes.RowFilter = "idunidad_agencia <> 9999 and codigo_iata = '" + valor + "'"
            If DvCbDes.Count = 0 Then
                MsgBox("Codigo de Destino no Existe", MsgBoxStyle.Critical, "Seguridad Sistema")
                TxtCodDes.Text = ""
                DvCbDes.RowFilter = "idunidad_agencia <> 9999"
                e.Cancel = True
            Else
                'Tepsa, se le agrega el if para que lea una sola vez  23/11/2006
                If TxtCodDes.Text <> STxtCodDes Then
                    drvOri = DvCbUnd.Item(CbOriDet.SelectedIndex)
                    drvDes = DvCbDes.Item(0)
                    Clase.CiuOrigen = drvOri("idunidad_agencia")
                    Clase.CiuDestino = drvDes("idunidad_agencia")
                    Clase.IATA = drvOri("codigo_iata")
                    Clase.IATADes = TxtCodDes.Text
                    Clase.idagencia_ori = dtoUSUARIOS.iIDAGENCIAS

                    'hlamas 27/02/2017
                    If Me.chkCa.Checked Then
                        Clase.FechaPartida = Me.TxtFecInicio.GetMyFecha
                        Clase.HoraPartida = IIf(Me.cboCA.SelectedIndex = 0, "", Me.cboCA.Text)
                        Clase.Ca = 1
                    Else
                        Clase.Ca = 0
                        Clase.FechaPartida = ""
                        Clase.HoraPartida = ""
                    End If
                    'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
                    'rsIti = Clase.BuscaItinerario_2
                    'rstDetalle = rsIti.NextRecordset
                    'dr4.Fill(DtIti, rsIti)
                    'dr4.Fill(DtDetalle, rstDetalle)
                    '
                    DtDetalle.Clear()
                    DtIti.Clear()
                    lds_tmp = Clase.BuscaItinerario_2
                    DtIti = lds_tmp.Tables(0)
                    DtDetalle = lds_tmp.Tables(1)

                    ComprobanteRepetido(DtDetalle)

                    dtHoraSalida = lds_tmp.Tables(2)
                    '
                    dvIti = DtIti.DefaultView
                    DvDetalle = DtDetalle.DefaultView
                    DvDetalle.AllowNew = False
                    Call GrillaDeta()
                    If dvIti.Count > 0 Then
                        LlenaCombo2(dvIti, CbItinerarios, "ITINERARIO")
                        TxtFecInicio.Focus()
                        TxtNroSalida.Enabled = True
                    Else
                        MessageBox.Show("Destino sin Itinerarios Registrados... Verifique", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        TxtNroSalida.Enabled = False
                    End If
                    If dvIti.Count = 0 Then
                        MessageBox.Show("Destino sin Documentos Pendientes... Verifique", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    'drvIti = dvIti.Item(0)
                    'TxtItinerarios.Text = drvIti("iditinerarios")
                    STxtCodDes = TxtCodDes.Text
                End If
            End If
        Else
            DvCbDes.RowFilter = "idunidad_agencia <> 9999"
            TxtFecInicio.Focus()
        End If
    End Sub
    Private Sub CbDesDet_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDesDet.SelectedIndexChanged
        'Dim rstDetaDoc_tmp As New ADODB.Recordset
        Dim ldestino As Long
        Dim drdes As DataRowView
        Try
            If b_nolee Then
                dvagencia_all.RowFilter = ""
                If CbDesDet.SelectedIndex >= 0 Then
                    ldestino = CType(CbDesDet.SelectedValue, Long)
                    DataGridViewGuia.Columns.Clear()  ' Creado por Tepsa 12/10/2006, Vuelve a generar la grilla  
                    ' Devolviendo los valores ' Tepsa 14/11/2006
                    DtDetaDoc = Nothing
                    DvDetaDoc = Nothing
                    DtDetaDoc = New DataTable
                    DvDetaDoc = New DataView
                    'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
                    'rstDetaDoc_tmp = Clase.fn_sp_recupera_detalle_blanco
                    'dr4.Fill(DtDetaDoc, rstDetaDoc_tmp)
                    DtDetaDoc = Clase.fn_sp_recupera_detalle_blanco
                    DvDetaDoc = DtDetaDoc.DefaultView
                    GrillaDetaDoc()
                    '
                    pb_nolee_codigo_iata = True

                    drdes = DvCbDes.Item(CbDesDet.SelectedIndex)
                    TxtCodDes.Text = ""
                    CbDesDet.SelectedValue = ldestino
                    If pb_nolee_codigo_iata = True Then
                        TxtCodDes.Text = drdes("codigo_iata")
                        dvagencia_all.RowFilter = "idunidad_agencia = " & ldestino

                    End If
                    pb_nolee_codigo_iata = False
                    '
                End If
                '
                If Me.CbOriDet.SelectedValue = Me.CbDesDet.SelectedValue Then
                    Me.CbTipoServ.SelectedValue = 8 ' En caso que la ciudad origen y destino sea igual considera 8 Trans. Zonal 
                    Me.CbTipoServ.Enabled = False
                    TxtBus.Text = "998" ' Tranferencia zonal 
                    Me.TxtSerie.Text = ""
                    Me.TxtNroGuia.Text = ""
                    Me.TxtSerie.Enabled = False    '11/08/2009 - modificado
                    Me.TxtNroGuia.Enabled = False
                Else
                    If Me.CbTipoServ.SelectedValue = 8 Then
                        Me.CbTipoServ.SelectedValue = 0
                        Me.TxtBus.Text = ""
                    End If
                    If Fact <> 2 Then
                        Me.TxtSerie.Enabled = True     '11/08/2009 - Modificado 
                        Me.TxtNroGuia.Enabled = True
                    Else
                        Me.TxtSerie.Enabled = False     '11/08/2009 - Modificado 
                        Me.TxtNroGuia.Enabled = False
                    End If
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub CbItinerarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbItinerarios.SelectedIndexChanged
        If b_nolee Then
            If CbItinerarios.SelectedIndex >= 0 Then
                Dim drdes As DataRowView
                drdes = dvIti.Item(CbItinerarios.SelectedIndex)
                TxtNroSalida.Text = drdes("nro_salida")
                'TxtHora.Text = drdes("hora_partida")
            End If
        End If
    End Sub
    Private Sub CbBus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbBus.SelectedIndexChanged
        'Dim ls_destino As String
        Dim lidtipo_servicio As Long
        Try
            If b_nolee Then   'Omendoza 
                If CbBus.SelectedIndex >= 0 Then
                    Dim drbus As DataRowView
                    drbus = DvCbEnt.Item(CbBus.SelectedIndex)
                    ' Mendoza 
                    TxtBus.Text = CType(drbus("nro_unidad_transporte"), String)
                    TxtMarca.Text = drbus("modelo_movil")
                    TxtPlaca.Text = drbus("placa")
                    lidtipo_servicio = CType(drbus("idtipo_servicio"), Long)
                    Me.txtKilometraje.Text = Format(drbus("kilometros"), "#,###,###0.00")
                    Spk()

                    'Me.CbTipoServ.SelectedValue = lidtipo_servicio
                    '
                    'Cba.ValueMember
                    If IsDBNull(drbus("idtipo_servicio")) = False Then
                        CbTipoServ.Text = CType(drbus("tipo_servicio"), String)
                        'CbTipoServ.SelectedValue = CType(drbus("idtipo_servicio"), Long)
                    End If
                    ' Recupera la hora de salida 
                    If IsDBNull(drbus("hora_salida")) = False Then
                        Me.txthorasalida.Text = CType(drbus("hora_salida"), String)
                    End If
                    '
                    TxtNroSalida.Text = drbus("nrosalida")
                    'Recupera los destinos asociados, Creado por Tepsa 
                    recupera_combo_destino(TxtNroSalida.Text)
                    '
                    CbItinerarios.SelectedValue = drbus("nrosalida")
                    'unidad_origen
                    'CbOriDet.SelectedValue = drbus("idagencia_origen")
                    'CbOriDet.Text = Nothing
                    '
                    CbOriDet.Text = drbus("unidad_origen")
                    'unidad_destino
                    Me.CbDesDet.SelectedValue = CType(drbus("idunidad_agencia_destino"), Long) ' CType(drbus("idunidad_agencia_destino"), Object)
                    If IsDBNull(drbus("usuario_chofer")) = False Then
                        Me.CbChofer.SelectedValue = CType(drbus("usuario_chofer"), Long) 'CType(drbus("usuario_chofer"), Object)
                    End If

                    '
                    'Estado antes de cambiar a la forma - 11/11/2006
                    'DvCbDes.RowFilter = ""
                    'CbDesDet.Text = CType(drbus("unidad_destino"), String)  ' Modificado por Tepsa 
                    'DvCbDes.RowFilter = ""
                    '

                    'CbDesDet.SelectedIndex = recupera_index(DvCbDes, "nombre_unidad", CType(drbus("unidad_destino"), String)) 'mendoza
                    'CbDesDet.SelectedIndex = UbicaComboDirecto(DvCbDes, CType(drbus("unidad_destino"), String), "NOMBRE_UNIDAD", "NOMBRE_UNIDAD")
                    'CbDesDet.SelectedIndex = UbicaCombo2(DvCbDes, DrUnd, "idunidad_agencia", "idunidad_agencia_destino", "nombre_unidad")                    

                    TxtFecInicio._MyFecha = CType(drbus("fecha_salida"), String)
                    If IsDBNull(drbus("nombre")) = True Then
                        CbChofer.SelectedValue = -666
                        CbChofer.Text = ""
                    Else
                        If Trim(drbus("nombre")) = "" Then
                            CbChofer.Text = ""
                            CbChofer.SelectedValue = -666
                        Else
                            CbChofer.Text = drbus("nombre")
                        End If
                        'CbChofer.SelectedValue = drbus("usuario_chofer")
                    End If
                    '--
                    If IsDBNull(drbus("nro_licencia")) = True Then
                        TxtLicencia.Text = ""
                    Else
                        TxtLicencia.Text = drbus("nro_licencia")
                    End If
                    '--
                    If IsDBNull(drbus("ruc_tercero")) = True Then
                        TxtRucTerc.Text = "0"
                    Else
                        TxtRucTerc.Text = drbus("ruc_tercero")
                    End If
                    If IsDBNull(drbus("nom_tercero")) = True Then
                        TxtTercero.Text = ""
                    Else
                        TxtTercero.Text = drbus("nom_tercero")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub TxtBus_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBus.Validating
        '
        'Comentado por Tepsa 12/11/2006 
        '
        'Dim drvBus As DataRowView
        'If TxtBus.Text <> "" Then
        '    valor = Trim(TxtBus.Text)
        '    DvCbEnt.RowFilter = "nro_unidad_transporte = " + valor
        '    If DvCbEnt.Count = 0 Then
        '        MsgBox("Numero de Bus no Existe", MsgBoxStyle.Critical, "Seguridad Sistema")
        '        TxtBus.Text = ""
        '        DvCbEnt.RowFilter = ""
        '        e.Cancel = True
        '    Else
        '        drvBus = DvCbEnt.Item(0)
        '        TxtMarca.Text = drvBus("modelo_movil")
        '        TxtPlaca.Text = drvBus("placa")
        '    End If
        'Else
        '    DvCbEnt.RowFilter = ""
        '    CbChofer.Focus()
        'End If
    End Sub
    Private Sub CbChofer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbChofer.SelectedIndexChanged
        If b_nolee Then
            If CbChofer.SelectedIndex >= 0 Then
                Dim drchofer As DataRowView
                drchofer = DvCbMov.Item(CbChofer.SelectedIndex)
                TxtLicencia.Text = IIf(IsDBNull(drchofer("nro_licencia")) = True, "", drchofer("nro_licencia"))
            End If
        End If
    End Sub

    Function TipoProducto(ByVal producto As Integer) As Integer
        If producto = 6 Then 'producto = 11 Then
            Return 1
        ElseIf producto = 11 Then
            Return 2
        Else
            Return 3
        End If
    End Function

    Function ProductoValido(ByVal producto As Integer) As Boolean
        With DataGridViewGuia
            For Each row As DataGridViewRow In .Rows
                If Not (TipoProducto(row.Cells("producto").Value) = TipoProducto(producto)) Then
                    Return False
                End If
            Next
            Return True
        End With
    End Function

    Private Sub BtAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAgregar.Click
        Dim i, k As Integer
        Dim dro, drc, drv As DataRowView
        Dim FValor, IDAge, bus As Integer
        Dim IDValor, vNroGuia As String
        Try
            '--- 05/02/2008 
            If es_inhouse = False Then
                If CbBus.SelectedValue < 0 Or TxtBus.Text = "" Then   '11/01/2007 
                    MsgBox("Falta seleccionar el Nº de Bus...", MsgBoxStyle.Critical, "Titan")
                    CbBus.Focus()
                    Exit Sub
                End If
            End If
            '--- 
            For i = 1 To DvDetalle.Count
                If i - 1 >= DvDetalle.Count Then
                    Exit For
                End If
                drv = DvDetalle.Item(i - 1)
                If Not ProductoValido(drv("producto")) Then
                    Exit For
                End If
                FValor = IIf(IsDBNull(drv("flgenv")) = True, 0, drv("flgenv"))
                If FValor = 1 Then
                    DvDetaDoc.Sort = "nro_doc"
                    vNroGuia = drv("nro_doc")
                    bus = DvDetaDoc.Find(vNroGuia)
                    If bus < 0 Then
                        k = DvDetaDoc.Count
                        DvDetaDoc.AllowNew = True
                        DvDetaDoc.AddNew()
                        drc = DvDetaDoc.Item(k)
                        drc("nro_doc") = vNroGuia
                        drc("idcomprobante") = drv("idcomprobante")
                        drc("IDGUIA_TRANSPORTISTA_DETALL") = drv("IDGUIA_TRANSPORTISTA_DETALL")
                        drc("tipo_comprobante") = drv("tipo_comprobante")
                        '
                        drc("idtipo_comprobante") = drv("idtipo_comprobante")
                        drc("cantidad") = drv("saldo")
                        drc("saldo") = drv("saldo")
                        drc("total_peso") = drv("total_peso")
                        drc("total_volumen") = drv("total_volumen")
                        drc("can_orig") = drv("cantidad")
                        drc("iata") = drv("iata")
                        'drc("idempresas_concesion") = IDValor
                        drc("flgenv") = 0
                        drc("subtotal") = drv("subtotal")
                        drc("producto") = drv("producto")
                        DvDetaDoc.AllowNew = False
                        DvDetalle.Delete(i - 1)
                        i = i - 1
                    End If
                End If
            Next
            k = DvDetalle.Count
            DvDetalle.AllowNew = True
            DvDetalle.AddNew()
            DvDetalle.AllowNew = False
            DvDetalle.Delete(k)
            DataGridViewGuia.Focus()
            lbNroRagistros.Text = DataGridViewGuia.Rows.Count
            Spk()
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema...")
        End Try

        'dro = DvAgencia.Item(DataGridViewUnd.CurrentRow.Index)
        'IDValor = IIf(IsDBNull(dro("idempresas_concesion")) = True, "0", dro("idempresas_concesion").ToString)

    End Sub

    Private Sub BtSacar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSacar.Click
        Dim i, k As Integer
        Dim dro, drc, drv As DataRowView
        Dim FValor, IDAge, bus As Integer
        Dim filtro, vNroGuia, ls_mensaje As String
        ' Dim lrst_datos As New ADODB.Recordset
        Dim ldt_tmp As DataTable
        filtro = DvDetalle.RowFilter
        DvDetalle.RowFilter = ""
        Dim IDValor As String
        Dim ll_codigo As Long
        'dro = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
        'IDValor = IIf(IsDBNull(dro("idempresas_concesion")) = True, "0", dro("idempresas_concesion").ToString)
        For i = 1 To DvDetaDoc.Count
            If i - 1 >= DvDetaDoc.Count Then
                Exit For
            End If
            drv = DvDetaDoc.Item(i - 1)
            FValor = IIf(IsDBNull(drv("flgenv")) = True, 0, drv("flgenv"))
            If FValor = 1 Then
                DvDetalle.Sort = "nro_doc"
                vNroGuia = drv("nro_doc")
                bus = DvDetalle.Find(IDAge)
                If bus < 0 Then
                    ' Elimina el documento de la guia de transportista 
                    ClaseDet.ID = CType(drv("IDGUIA_TRANSPORTISTA_DETALL"), String)
                    If ClaseDet.ID <> 0 Then
                        ClaseDet.Cantidad = CType(drv("cantidad"), Long)
                        'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
                        'lrst_datos = ClaseDet.fn_eliminar_item_gtrans()
                        ldt_tmp = ClaseDet.fn_eliminar_item_gtrans
                        ll_codigo = CType(ldt_tmp.Rows(0).Item(0), Long)
                        ls_mensaje = CType(ldt_tmp.Rows(0).Item(1), String)
                        If ll_codigo <> 0 Then
                            MsgBox("Código error " + CType(ll_codigo, String) + " " + ls_mensaje, MsgBoxStyle.Information, "Sistema de Seguridad")
                            Exit Sub
                        End If
                        '
                    End If

                    Dim intProducto As Integer
                    intProducto = IIf(Me.chkCa.Checked, 1, 2)
                    If TipoProducto(drv("producto")) = intProducto Then
                        k = DvDetalle.Count
                        DvDetalle.AllowNew = True
                        DvDetalle.AddNew()
                        drc = DvDetalle.Item(k)
                        drc("nro_doc") = vNroGuia
                        drc("idcomprobante") = drv("idcomprobante")
                        drc("IDGUIA_TRANSPORTISTA_DETALL") = drv("IDGUIA_TRANSPORTISTA_DETALL")
                        drc("idtipo_comprobante") = drv("idtipo_comprobante")
                        drc("iata") = drv("iata")
                        drc("tipo_comprobante") = drv("tipo_comprobante")
                        'drc("cantidad") = drv("cantidad")  Modificado por Tepsa 14/11/2006 
                        drc("cantidad") = drv("saldo") '
                        drc("saldo") = drv("saldo")
                        drc("total_peso") = drv("total_peso")
                        drc("total_volumen") = drv("total_volumen")
                        drc("flgenv") = 0
                        drc("subtotal") = drv("subtotal")
                        drc("producto") = drv("producto")
                        '
                        DvDetalle.AllowNew = False
                    End If
                    DvDetaDoc.Delete(i - 1)
                    i = i - 1
                End If
            End If
        Next
        Spk()
        k = DvDetalle.Count
        DvDetalle.AllowNew = True
        DvDetalle.AddNew()
        DvDetalle.AllowNew = False
        DvDetalle.Delete(k)
        DvDetalle.RowFilter = filtro
        DataGridViewUnd.Focus()
        lbNroRagistros.Text = DataGridViewGuia.Rows.Count
        'Me.labnroregistro_old.Text = Me.DataGridViewGuia.Rows.Count
        'Me.lbNroRagistros.Text = Me.DataGridViewGuia.Rows.Count
    End Sub
    Private Sub CbTipoServ_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbTipoServ.SelectedIndexChanged
        'If b_nolee Then
        '    TxtBus.Enabled = True
        '    TxtBus.BackColor = Color.White
        '    CbBus.Enabled = True
        '    CbBus.BackColor = Color.White
        '    If CbTipoServ.Text = "TEPSA" Then
        '        TxtNroSalida.Enabled = True
        '        TxtNroSalida.BackColor = Color.White
        '        CbItinerarios.Enabled = True
        '        CbItinerarios.BackColor = Color.White
        '        '
        '        ' Tepsa 06/11/2006 
        '        '
        '        'TxtBus.Enabled = True
        '        'TxtBus.BackColor = Color.White
        '        'CbBus.Enabled = True
        '        'CbBus.BackColor = Color.White
        '        CbChofer.Enabled = True
        '        CbChofer.BackColor = Color.White
        '        TxtMarca.Enabled = False
        '        TxtMarca.BackColor = System.Drawing.SystemColors.Info
        '        TxtPlaca.Enabled = False
        '        TxtPlaca.BackColor = System.Drawing.SystemColors.Info
        '        TxtLicencia.Enabled = False
        '        TxtLicencia.BackColor = System.Drawing.SystemColors.Info
        '        TxtRucTerc.Enabled = False
        '        TxtRucTerc.BackColor = System.Drawing.SystemColors.Info
        '        TxtTercero.Enabled = False
        '        TxtTercero.BackColor = System.Drawing.SystemColors.Info
        '        CbTipoServ.Text = "TEPSA"
        '    ElseIf CbTipoServ.Text = "CARGUERO" Then
        '        TxtNroSalida.Enabled = False
        '        TxtNroSalida.BackColor = System.Drawing.SystemColors.Info
        '        CbItinerarios.Enabled = False
        '        CbItinerarios.BackColor = System.Drawing.SystemColors.Info
        '        TxtBus.Enabled = True
        '        TxtBus.BackColor = Color.White
        '        CbBus.Enabled = True
        '        CbBus.BackColor = Color.White
        '        CbChofer.Enabled = True
        '        CbChofer.BackColor = Color.White
        '        TxtMarca.Enabled = False
        '        TxtMarca.BackColor = System.Drawing.SystemColors.Info
        '        TxtPlaca.Enabled = False
        '        TxtPlaca.BackColor = System.Drawing.SystemColors.Info
        '        TxtLicencia.Enabled = False
        '        TxtLicencia.BackColor = System.Drawing.SystemColors.Info
        '        TxtRucTerc.Enabled = False
        '        TxtRucTerc.BackColor = System.Drawing.SystemColors.Info
        '        TxtTercero.Enabled = False
        '        TxtTercero.BackColor = System.Drawing.SystemColors.Info
        '        CbTipoServ.Text = "CARGUERO"
        '    Else
        '        TxtNroSalida.Enabled = False
        '        TxtNroSalida.BackColor = System.Drawing.SystemColors.Info
        '        CbItinerarios.Enabled = False
        '        CbItinerarios.BackColor = System.Drawing.SystemColors.Info
        '        'TxtBus.Enabled = False
        '        'TxtBus.BackColor = System.Drawing.SystemColors.Info
        '        'CbBus.Enabled = False
        '        'CbBus.BackColor = System.Drawing.SystemColors.Info
        '        CbChofer.Enabled = False
        '        CbChofer.BackColor = System.Drawing.SystemColors.Info
        '        TxtMarca.Enabled = True
        '        TxtMarca.BackColor = Color.White
        '        TxtPlaca.Enabled = True
        '        TxtPlaca.BackColor = Color.White
        '        TxtLicencia.Enabled = True
        '        TxtLicencia.BackColor = Color.White
        '        TxtRucTerc.Enabled = True
        '        TxtRucTerc.BackColor = Color.White
        '        TxtTercero.Enabled = True
        '        TxtTercero.BackColor = Color.White
        '        CbTipoServ.Text = "TERCERO"
        '    End If
        'End If
    End Sub
    Sub BuscaGuiasTransporte()
        Dim origen, destino As Integer
        Dim dr, dr2 As DataRowView
        Try
            dr = DvOrigen.Item(CbOrigen.SelectedIndex)
            dr2 = DvDestino.Item(CbDestino.SelectedIndex)
            'dr3 = DvCbSer.Item(CbServicio.SelectedIndex)
            origen = dr("idunidad_agencia")
            destino = dr2("idunidad_agencia")
            'Clase.Clase = dr3("idclase")
            If origen = 9999 Or destino = 9999 Then
                If TxtFechaIni.GetMyFecha <> TxtFechaFin.GetMyFecha Then
                    MessageBox.Show("Para el caso de la opcion TODOS, debe ser solo para un rango de un dia", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            'DvCbRut.RowFilter = "idunidad_agencia = " + origen.ToString + " and idunidad_agencia_destino = " + destino.ToString
            'If DvCbRut.Count > 0 Or origen = 9999 Or destino = 9999 Then                
            'dr = DvCbRut.Item(0)
            'Clase.Ruta = dr("idrutas")
            Clase.CiuOrigen = origen
            Clase.CiuDestino = destino
            Clase.idagencia_ori = CType(Me.cmbagencia.SelectedValue, Long)   'Modificado por Omendoza 26/01/2007 dtoUSUARIOS.m_iIdAgencia()
            Clase.FecIni = TxtFechaIni.GetMyFecha
            Clase.Fecfin = TxtFechaFin.GetMyFecha
            dt.Clear()
            'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
            Dim ldt_tmp As DataTable
            'rstBuscar = Clase.Buscar
            ldt_tmp = Clase.Buscar
            'da.Fill(dt, rstBuscar)
            DvAgencia = ldt_tmp.DefaultView
            DvAgencia.AllowNew = False
            Call GrillaMante()
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub TxtNroSalida_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNroSalida.Validating
        Try
            If dvIti.Count > 0 Then
                CbItinerarios.SelectedIndex = UbicaComboDirecto(dvIti, TxtNroSalida.Text, "nro_salida", "ITINERARIO")
                'CbOriDet.SelectedIndex = UbicaCombo2(DvCbUnd, DrUnd, "idunidad_agencia", "idunidad_agencia", "nombre_unidad")
                'LlenaCombo2(dvIti, CbItinerarios, "ITINERARIO")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEnvio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnvio.Click
        If txtGuiaEnvio.Text <> "" Then
            dtGuiaEnvio.Clear()
            Dim drvGuiaEnvio As DataRowView
            If txtGuiaEnvio.Text.ToString.Length = 12 Then
                txtGuiaEnvio.Text = "0" & txtGuiaEnvio.Text
            End If
            Clase.NroGuia = txtGuiaEnvio.Text
            'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
            'rstGuiaEnvio = Clase.BuscaGuiasEnvio
            'dr4.Fill(dtGuiaEnvio, rstGuiaEnvio)
            dtGuiaEnvio = Clase.BuscaGuiasEnvio
            dvGuiaEnvio = dtGuiaEnvio.DefaultView
            If dvGuiaEnvio.Count > 0 Then
                drvGuiaEnvio = dvGuiaEnvio.Item(0)
                If drvGuiaEnvio("idestado_registro") = 18 Then
                    Dim i, k As Integer
                    Dim drc, drv As DataRowView
                    Dim FValor, IDAge, bus As Integer
                    Dim nro_doc As String, intTipoComprobante As Integer
                    Try
                        For i = 1 To dvGuiaEnvio.Count
                            drv = dvGuiaEnvio.Item(i - 1)
                            '
                            ' DvDetaDoc.RowFilter = "nro_doc = '" + drv("nro_doc").ToString + "'"  Hecho por Eduardo 
                            '
                            'DvDetaDoc.Sort = "nro_doc"
                            'IDAge = drv("nro_doc")     Modificado por Tepsa 
                            nro_doc = CType(drv("nro_doc"), String)
                            intTipoComprobante = drv("intTipoComprobante")
                            '
                            ' bus = DvDetaDoc.Find(IDAge)
                            ' bus = DvDetaDoc.Count Hecho por Eduardo 
                            '
                            'If bus = 0 Then ' Hecho por Eduardo 1010/11/2006
                            If verfica_repetidos(nro_doc, intTipoComprobante) Then   ' Modificado por Tepsa 
                                DvDetaDoc.RowFilter = ""
                                k = DvDetaDoc.Count
                                DvDetaDoc.AllowNew = True
                                DvDetaDoc.AddNew()
                                drc = DvDetaDoc.Item(k)
                                drc("nro_doc") = nro_doc ' IDAge  MOdificado por tepsa 10/11/2006
                                drc("idcomprobante") = drv("idcomprobante")
                                drc("IDGUIA_TRANSPORTISTA_DETALL") = drv("IDGUIA_TRANSPORTISTA_DETALL")
                                drc("tipo_comprobante") = drv("tipo_comprobante")
                                drc("idtipo_comprobante") = drv("idtipo_comprobante")
                                drc("iata") = drv("iata")
                                'drc("cantidad") = drv("cantidad")  ' Modificado por Tepsa 14/11/2006 
                                drc("cantidad") = drv("saldo")
                                drc("saldo") = drv("saldo")
                                drc("total_peso") = drv("total_peso")
                                drc("total_volumen") = drv("total_volumen")
                                'drc("idempresas_concesion") = IDValor
                                drc("flgenv") = 0
                                drc("subtotal") = drv("subtotal")
                                DvDetaDoc.AllowNew = False
                                'DvDetalle.Delete(i - 1)
                                'i = i - 1
                            Else
                                DvDetaDoc.RowFilter = ""
                                MessageBox.Show("Guia ya Existe... Verifique", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Next
                        'k = DvDetalle.Count
                        'DvDetalle.AllowNew = True
                        'DvDetalle.AddNew()
                        'DvDetalle.AllowNew = False
                        'DvDetalle.Delete(k)
                        txtGuiaEnvio.Text = ""
                        DataGridViewGuia.Focus()
                    Catch ex As Exception
                        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema...")
                    End Try
                Else
                    MessageBox.Show("Estado del documento no es el permitido en esta opción", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtGuiaEnvio.Text = ""
                End If
            Else
                MessageBox.Show("Documento No Existe", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuiaEnvio.Text = ""
            End If
            txtGuiaEnvio.Focus()
        End If
    End Sub

    Private Sub DataGridViewGuia_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridViewGuia.CellBeginEdit

    End Sub
    Private Sub DataGridViewGuia_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridViewGuia.CellValidating
        ' Dim l_saldo As Long
        Dim l_cantidad As Long
        If e.ColumnIndex = 3 Then
            Dim drvDoc As DataRowView
            drvDoc = DvDetaDoc.Item(DataGridViewGuia.CurrentRow.Index)

            Dim dtv As New DataView
            dtv = DataGridViewGuia.DataSource

            '-->12/09/2013-jabanto 
            '-> valida numeros negativos
            If Val(e.FormattedValue) < 0 Then
                e.Cancel = True
                MessageBox.Show("No se permiten valores negativos como Cantidad.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            '
            If IsDBNull(drvDoc("saldo")) = False Then
                l_cantidad = CType(drvDoc("saldo"), Long)
            Else
                l_cantidad = 0
            End If
            '
            If IsDBNull(Convert.ToInt16(e.FormattedValue)) = False Then
                If Convert.ToInt16(e.FormattedValue) > l_cantidad Then
                    'If Convert.ToInt16(e.FormattedValue) > drvDoc("can_orig") Then 12/01/2007 - tepsa 
                    MessageBox.Show("Cifra no puede ser mayor al Total", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                End If
            Else
                MessageBox.Show("Falta registrar el Nº de Bultos a enviar ", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If
        End If
        lbNroRagistros.Text = DataGridViewGuia.Rows.Count
    End Sub
    Sub validando_guiastransportista()
        'Procedimiento creado por tepsa 
        Dim sserguia, snroguia As String
        'Dim Mybusqueda As ADODB.Recordset
        Dim Mybusqueda As DataTable
        Try
            '01/08/2008 - Para que no valide cuando es un inhose 
            If es_inhouse = False Then
                'Si no tiene datos registrados 
                If TxtSerie.Text = "" Or TxtNroGuia.Text = "" Then
                    Exit Sub
                End If
                sserguia = TxtSerie.Text
                snroguia = TxtNroGuia.Text
            Else
                sserguia = "null"
                snroguia = "null"
            End If
            '
            Clase.Serie = sserguia
            Clase.NroGuia = snroguia
            ' 
            Mybusqueda = Clase.valida_guiatransportista
            If Mybusqueda.Rows.Count > 0 Then
                If Mybusqueda.Rows(0).Item(0) = "GUIA EXISTE" Then
                    MessageBox.Show(Mybusqueda.Rows(0).Item(0), "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtNroGuia.Text = ""
                    Me.TxtNroGuia.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub TxtNroGuia_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroGuia.Validated
        If Fact <> 2 Then
            validando_guiastransportista()   'Tepsa 
        End If
    End Sub
    Private Sub TxtSerie_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSerie.Validating
        If Fact <> 2 Then
            validando_guiastransportista()  ' Tepsa 
        End If
    End Sub
    Private Sub CbDesDet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbDesDet.TextChanged
        '
    End Sub
    Private Sub TxtCodDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodDes.TextChanged
        ' Cuando cambia debe de recuperar los datos - Creado por Tepsa 
        'Dim rsIti As ADODB.Recordset
        Dim lds_tmp As New DataSet
        Dim drvOri, drvDes As DataRowView
        Try
            If pb_nolee_codigo_iata = True Then
                If TxtCodDes.Text <> "" Or (TxtCodDes.Text = "" And Me.cboCarga.SelectedIndex = 1) Then
                    valor = Trim(TxtCodDes.Text)
                    'DvCbDes.RowFilter = "idunidad_agencia <> 9999 and codigo_iata = '" + valor + "'"
                    If DvCbDes.Count = 0 Then
                        MsgBox("Codigo de Destino no Existe", MsgBoxStyle.Critical, "Seguridad Sistema")
                        TxtCodDes.Text = ""
                        DvCbDes.RowFilter = "idunidad_agencia <> 9999"
                        Exit Sub
                    Else
                        'If Not (TxtNroSalida.Text = "") Then
                        'If Not (TxtNroSalida.Text = "") Or es_inhouse = True Then   --> Modificado 12/08/2009 
                        If Not (TxtNroSalida.Text = "") Or es_inhouse = True Or (Me.CbOriDet.SelectedValue = Me.CbDesDet.SelectedValue) Then
                            If TxtCodDes.Text <> STxtCodDes Or DtDetalle.Rows.Count < 1 Or (TxtCodDes.Text = "" And Me.cboCarga.SelectedIndex = 1) Then
                                drvOri = DvCbUnd.Item(CbOriDet.SelectedIndex)
                                drvDes = DvCbDes.Item(0)
                                'recuperando el nro de salida
                                If TxtNroSalida.Text = "S/N" Then
                                    Clase.nrosalida_real = -1
                                Else
                                    'If (es_inhouse = True And TxtNroSalida.Text = "" Then
                                    If (es_inhouse = True And TxtNroSalida.Text = "") Or (Me.CbOriDet.SelectedValue = Me.CbDesDet.SelectedValue) Then
                                        Clase.nrosalida_real = -666 ' Como es inhouse y no ha puesto el número de salida 
                                    Else
                                        Clase.nrosalida_real = CType(TxtNroSalida.Text, Long)
                                    End If
                                End If
                                '
                                Clase.CiuOrigen = drvOri("idunidad_agencia")
                                'Clase.CiuDestino = drvDes("idunidad_agencia")  'Creado por Eduardo Modificado el 12/11/2006
                                Clase.CiuDestino = CbDesDet.SelectedValue
                                Clase.IATA = drvOri("codigo_iata")
                                Clase.IATADes = TxtCodDes.Text
                                Clase.idagencia_ori = dtoUSUARIOS.iIDAGENCIAS '12/08/2009 


                                'hlamas 27/02/2017
                                If Me.chkCa.Checked Then
                                    Clase.FechaPartida = Me.TxtFecInicio.GetMyFecha
                                    Clase.HoraPartida = IIf(Me.cboCA.SelectedIndex = 0, "", Me.cboCA.Text)
                                    Clase.Ca = Me.cboCarga.SelectedIndex + 1
                                    If Me.cboCarga.SelectedIndex = 1 And Me.CbDesDet.SelectedValue = 0 Then
                                        Clase.Salida = Val("" & Me.TxtNroSalida.Text)
                                    Else
                                        Clase.Salida = 0
                                    End If
                                Else
                                    Clase.Ca = 0
                                    Clase.FechaPartida = ""
                                    Clase.HoraPartida = ""
                                    Clase.Salida = 0
                                End If


                                    DtDetalle.Clear()
                                    DtIti.Clear()
                                    'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
                                    'rsIti = Clase.BuscaItinerario_2
                                    'rstDetalle = rsIti.NextRecordset
                                    'dr4.Fill(DtIti, rsIti)
                                    'dr4.Fill(DtDetalle, rstDetalle)
                                lds_tmp = Clase.BuscaItinerario_2(Clase.Salida)
                                    DtIti = lds_tmp.Tables(0)
                                    DtDetalle = lds_tmp.Tables(1)
                                    dtHoraSalida = lds_tmp.Tables(2)

                                    ComprobanteRepetido(DtDetalle)

                                    '
                                    dvIti = DtIti.DefaultView
                                    DvDetalle = DtDetalle.DefaultView
                                    DvDetalle.AllowNew = False
                                    Call GrillaDeta()

                                    'Comentado por Tepsa 12/11/2006
                                    'If dvIti.Count > 0 Then
                                    '    LlenaCombo2(dvIti, CbItinerarios, "ITINERARIO")
                                    '    TxtFecInicio.Focus()
                                    '    TxtNroSalida.Enabled = True
                                    'Else
                                    '    MessageBox.Show("Destino sin Itinerarios Registrados... Verifique", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    '    TxtNroSalida.Enabled = False
                                    'End If
                                    'If dvIti.Count = 0 Then
                                    '    MessageBox.Show("Destino sin Documentos Pendientes... Verifique", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    'End If
                                    'drvIti = dvIti.Item(0)
                                    'TxtItinerarios.Text = drvIti("iditinerarios")

                                End If
                                STxtCodDes = TxtCodDes.Text
                            End If
                    End If
                Else
                    DvCbDes.RowFilter = "idunidad_agencia <> 9999"
                    DataGridViewUnd.DataSource = Nothing
                    TxtFecInicio.Focus()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Function recupera_index(ByVal dva As DataView, ByVal camposeleccionado As String, ByVal valor As String)
        Dim valor2 As String
        Dim filcb As Integer
        Dim drc As DataRowView
        '
        Try ' Omendoza 
            drc = dva.Item(filcb)
            valor2 = drc(camposeleccionado)
            filcb = dva.Find(valor)
            If filcb < 0 Then
                filcb = 0
            End If
            Return filcb
        Catch ex As Exception
            Return 0
        End Try
        '
    End Function
    Function verfica_repetidos(ByVal valor As String, ByVal tipo As Integer) As Boolean
        Dim fila As Long
        Dim snro_documento As String
        Dim intTipoComprobante As Integer
        Try
            For fila = 0 To DataGridViewGuia.Rows.Count - 1
                snro_documento = CType(DataGridViewGuia.Rows(fila).Cells(1).Value, String)
                intTipoComprobante = DataGridViewGuia.Rows(fila).Cells("idtipo_comprobante").Value
                If snro_documento = valor And intTipoComprobante = tipo Then
                    Return False
                End If
            Next
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
            Return False
        End Try
    End Function
    Private Sub TxtSerie_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSerie.Leave
        TxtSerie.Text = RellenoRight(Nro_Digitos_Serguiatransportista, TxtSerie.Text)
    End Sub
    Private Sub TxtNroGuia_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroGuia.Leave
        TxtNroGuia.Text = RellenoRight(Nro_Digitos_guiatransportista, TxtNroGuia.Text)
    End Sub
    Private Sub recupera_combo_destino(ByVal nrosalida As String)
        If es_inhouse = False Then
            If IsDBNull(nrosalida) = True Or nrosalida = "" Then   '11/01/2007 
                MsgBox("Falta seleccionar el Nº de Bus...", MsgBoxStyle.Critical, "Titan")
                CbBus.Focus()
                Exit Sub
            End If
        End If
        Dim lnrosalida As Long = nrosalida
        'Dim rstdestinobus As New ADODB.Recordset        
        Dim lidunidad_agencia_dest As Long
        '
        DtCbDes = Nothing
        DvCbDes = Nothing
        DtCbDes = New DataTable
        DvCbDes = New DataView
        If Me.chkcontroldestino.Checked = True Then  ' Debe mostrar todos los Destinos 
            DtCbDes = DtCbUnd.Copy
            DvCbDes = DtCbDes.DefaultView
        Else  'Debe mostrar todos los Destinos por donde pasa el bus 
            Clase.nrosalida_real = CType(nrosalida, Long)
            'rstdestinobus = Clase.fn_sp_recupera_destino_bus()
            'dr4.Fill(DtCbDes, rstdestinobus)
            DtCbDes = Clase.fn_sp_recupera_destino_bus(1)
            DvCbDes = DtCbDes.DefaultView
        End If
        If CbDesDet.SelectedValue < 1 Then
            lidunidad_agencia_dest = 0
        Else
            lidunidad_agencia_dest = CbDesDet.SelectedValue
        End If
        DvCbDes = CargarCombo(CbDesDet, DtCbDes, "nombre_unidad", "idunidad_agencia", lidunidad_agencia_dest)
        CbDesDet.SelectedValue = lidunidad_agencia_dest 'Ingresando Linea x Tepsa 20/12/2006 
        'LlenaCombo2(DvCbDes, CbDesDet, "NOMBRE_UNIDAD")
    End Sub
    Private Sub chkcontroldestino_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcontroldestino.CheckedChanged
        Dim lidunidad_agencia_destino As Long
        lidunidad_agencia_destino = CType(CbDesDet.SelectedValue, Long)
        If chkcontroldestino.Checked = True Then
            recupera_combo_destino("0")
        Else
            recupera_combo_destino(TxtNroSalida.Text)
        End If
        CbDesDet.SelectedValue = lidunidad_agencia_destino
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        DvDetalle.RowFilter = "tipo_comprobante = 'GUIA' "
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        DvDetalle.RowFilter = "tipo_comprobante <> 'GUIA' "
    End Sub
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        DvDetalle.RowFilter = ""
    End Sub
    Sub volver_origen_bus()
        ' Cargando de nuevo los valores 
        DtCbEnt = Nothing
        DvCbEnt = Nothing
        DtCbEnt = New DataTable
        DvCbEnt = New DataView
        '
        DtCbEnt = DtCbEnt_tmp.Copy
        DvCbEnt = DtCbEnt_tmp.DefaultView 'DtCbEnt.DefaultView
        '
        'LlenaCombo2(DvCbEnt, CbBus, "NOMBRE_TRANSPORTE") '26/01/207
        '
        DvCbEnt = CargarCombo(CbBus, DtCbEnt, "NOMBRE_TRANSPORTE", "idunidad_transporte", 0)  ' Por defecto 0 No debe aparecer nada 
        '
        DtCbEnt_tmp = Nothing
        DvCbEnt_tmp = Nothing
        b_copia = False
    End Sub

    Private Sub DataGridViewGuia_RowLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewGuia.RowLeave
        'Me.labnroregistro_old.Text = Me.DataGridViewGuia.Rows.Count
        Me.lbNroRagistros.Text = 0 'Me.DataGridViewGuia.Rows.Count 26/01/2007
    End Sub
    Private Sub TabDatos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabDatos.Enter
        If b_habilita_grabar = False Then
            GrabarToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub TxtFechaIni_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFechaIni.Leave
        TxtFechaFin._MyFecha = TxtFechaIni.GetMyFecha
    End Sub
    Public Sub fnNroDocumento(ByVal idDocumento As Integer)
        Try
            Dim ldt_tmp As New DataTable
            ldt_tmp = Clase.fnNroDocumento(idDocumento)
            If ldt_tmp.Rows.Count > 0 Then
                TxtSerie.Text = ldt_tmp.Rows(0).Item(0).ToString
                TxtNroGuia.Text = ldt_tmp.Rows(0).Item(1).ToString
                If idDocumento = 3 Then
                    '    NroDoc = NroDoc.Substring(2, NroDoc.Length - 2)
                    TxtNroGuia.Text = fnGeneraDigitoChequeo(TxtNroGuia.Text)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnadicional_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadicional.Click
        Try
            Dim a As New frmguiatransportistaadicional
            'a.ShowDialog(Me)

            Acceso.Asignar(a, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                a.ShowDialog(Me)
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            a = Nothing
        Catch EXC As Exception
            MsgBox(EXC.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub
    Public Function fnCargardatos() As Boolean
        Dim lvalor As Long
        Try
            lvalor = txtGuiaEnvio.Text
            txtGuiaEnvio.Text = RellenoRight(12, txtGuiaEnvio.Text)
        Catch ex As Exception

        End Try
        Try
            ' Nº de lineas que debe manejarse por Parametro (actualmente es de 35 reg.)
            If DataGridViewGuia.Rows.Count + 1 > 35 Then ' Nº de lineas que debe manejarse por Parametro (actualmente es de 35 reg.)
                MessageBox.Show("La guía de transportista ya tiene 35 documentos asociados a la guía de transportista", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If
            If txtGuiaEnvio.Text <> "" Then
                dtGuiaEnvio.Clear()
                Dim drvGuiaEnvio As DataRowView
                If txtGuiaEnvio.Text.ToString.Length = 12 And IsNumeric(Me.txtGuiaEnvio.Text) Then
                    txtGuiaEnvio.Text = "0" & txtGuiaEnvio.Text
                End If
                Clase.TipoComprobante = Me.cboTipoComprobante.SelectedIndex
                Clase.NroGuia = txtGuiaEnvio.Text
                'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
                'rstGuiaEnvio = Clase.BuscaGuiasEnvio
                'dr4.Fill(dtGuiaEnvio, rstGuiaEnvio)
                '
                '19/11/2009
                If Me.CbOriDet.SelectedValue <> Me.CbDesDet.SelectedValue Then
                    dtGuiaEnvio = Clase.BuscaGuiasEnvio
                Else
                    Dim ll_ciudad_destino As Long
                    ll_ciudad_destino = Clase.CiuDestino
                    Clase.CiuDestino = Me.CbDesDet.SelectedValue
                    Clase.AgenciaOrigen = dtoUSUARIOS.iIDAGENCIAS
                    Clase.AgenciaDestino = cmb_agencia_destino.SelectedValue
                    dtGuiaEnvio = Clase.BuscaGuiasEnvio_zonal
                    Clase.CiuDestino = ll_ciudad_destino
                End If
                '---
                dvGuiaEnvio = dtGuiaEnvio.DefaultView
                If dvGuiaEnvio.Count > 0 Then
                    drvGuiaEnvio = dvGuiaEnvio.Item(0)

                    ' 07/07/2009 - 19 Despachado se modifico para que pueda ingresar lo desapcahdo hasta que sea un destino final 
                    '68 Entrega parcial
                    '69 Reparto Parcial
                    If drvGuiaEnvio("idestado_envio") = 18 Or _
                       drvGuiaEnvio("idestado_envio") = 19 Or _
                       drvGuiaEnvio("idestado_envio") = 40 Or _
                       drvGuiaEnvio("idestado_envio") = 41 Or _
                       drvGuiaEnvio("idestado_envio") = 68 Or _
                       drvGuiaEnvio("idestado_envio") = 69 Or _
                       Me.CbOriDet.SelectedValue = Me.CbDesDet.SelectedValue Then  '16/11/2009
                        Dim i, k As Integer
                        Dim drc, drv As DataRowView
                        Dim FValor, IDAge, bus As Integer
                        Dim nro_doc As String
                        Dim intTipoComprobante As Integer
                        Try
                            For i = 1 To dvGuiaEnvio.Count
                                drv = dvGuiaEnvio.Item(i - 1)
                                Dim intProducto As Integer
                                'intProducto = IIf(Me.chkCa.Checked, 1, 2)
                                If Me.chkCa.Checked Then
                                    intProducto = Me.cboCarga.SelectedIndex + 1
                                Else
                                    intProducto = 3
                                End If
                                If Not ProductoValido(drv("producto")) Then
                                    Exit For
                                End If
                                If Not (TipoProducto(drv("producto")) = intProducto) Then
                                    Exit For
                                End If
                                '
                                ' DvDetaDoc.RowFilter = "nro_doc = '" + drv("nro_doc").ToString + "'"  Hecho por Eduardo 
                                '
                                'DvDetaDoc.Sort = "nro_doc"
                                'IDAge = drv("nro_doc")     Modificado por Tepsa 
                                intTipoComprobante = drv("idtipo_comprobante")
                                nro_doc = CType(drv("nro_doc"), String)
                                '
                                ' bus = DvDetaDoc.Find(IDAge)
                                ' bus = DvDetaDoc.Count Hecho por Eduardo 
                                '
                                'Verifica si va al mismo destino, 19/03/2007
                                'If es_inhouse = False Then
                                If Me.CbOriDet.SelectedValue <> Me.CbDesDet.SelectedValue Then '16/07/2009 - Siempre debe verificar que sea diferente para verificar que es una GT interporvincial en caso contrario solo será zonal 
                                    If Me.TxtCodDes.Text <> CType(drv("codigo_iata"), String) Then
                                        Dim resp As DialogResult = MessageBox.Show("El destino " + CType(drv("codigo_iata"), String) + " no coincide con él de la guía, ¿Desea continuar? ", "Guía Transportista", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        If resp = Windows.Forms.DialogResult.No Then
                                            Me.txtGuiaEnvio.Text = ""
                                            Exit Function
                                        End If
                                    End If
                                End If
                                'End If
                                '
                                'If bus = 0 Then ' Hecho por Eduardo  10/11/2006 

                                If verfica_repetidos(nro_doc, intTipoComprobante) Then   ' Modificado por Tepsa '19/03/2007
                                    DvDetaDoc.RowFilter = ""
                                    k = DvDetaDoc.Count
                                    DvDetaDoc.AllowNew = True
                                    DvDetaDoc.AddNew()
                                    drc = DvDetaDoc.Item(k)
                                    drc("nro_doc") = nro_doc ' IDAge  MOdificado por tepsa 10/11/2006
                                    drc("idcomprobante") = drv("idcomprobante")
                                    drc("IDGUIA_TRANSPORTISTA_DETALL") = drv("IDGUIA_TRANSPORTISTA_DETALL")
                                    drc("tipo_comprobante") = drv("tipo_comprobante")
                                    drc("idtipo_comprobante") = drv("idtipo_comprobante")
                                    drc("iata") = drv("iata")
                                    'drc("cantidad") = drv("cantidad")  ' Modificado por Tepsa 14/11/2006 
                                    drc("can_orig") = drv("cantidad")  '
                                    drc("cantidad") = drv("saldo")
                                    drc("saldo") = drv("saldo")
                                    drc("total_peso") = drv("total_peso")
                                    drc("total_volumen") = drv("total_volumen")
                                    'drc("idempresas_concesion") = IDValor
                                    drc("flgenv") = 0
                                    drc("subtotal") = drv("subtotal")
                                    drc("producto") = drv("producto")
                                    DvDetaDoc.AllowNew = False
                                    'DvDetalle.Delete(i - 1)
                                    'i = i - 1
                                    busca_dcto(nro_doc) 'Add - 05/12/2007
                                Else
                                    DvDetaDoc.RowFilter = ""
                                    MessageBox.Show("Guia ya Existe... Verifique", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Next
                            'k = DvDetalle.Count
                            'DvDetalle.AllowNew = True
                            'DvDetalle.AddNew()
                            'DvDetalle.AllowNew = False
                            'DvDetalle.Delete(k)
                            txtGuiaEnvio.Text = ""
                            DataGridViewGuia.Focus()
                        Catch ex As Exception
                            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema...")
                        End Try
                    Else
                        '19/03/2007 
                        If drvGuiaEnvio("recupera_guia") = "-" Then
                            MessageBox.Show("Estado del documento no es el permitido en esta opción", "Guía de Transportista", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("El documento se encuentra en la(s) guía(s) " + CType(drvGuiaEnvio("recupera_guia"), String), "Guía de Transportista", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        txtGuiaEnvio.Text = ""
                    End If
                Else
                    MessageBox.Show("Documento No Existe", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtGuiaEnvio.Text = ""
                End If
                txtGuiaEnvio.Focus()
            End If
            lbNroRagistros.Text = DataGridViewGuia.Rows.Count
            If DataGridViewGuia.Rows.Count = 35 Then ' Nº de lineas que debe manejarse por Parametro (actualmente es de 35 reg.)
                MessageBox.Show("La guía de transportista permite como máximo 35 documentos, ya llego a su tope ", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

        End Try
        Return False
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim drv As DataRowView
            For i As Integer = 0 To DataGridViewGuia.Rows.Count - 1
                DataGridViewGuia.Item(6, i).Value = 1
            Next
            lbNroRagistros.Text = DataGridViewGuia.Rows.Count
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNinguno.Click
        Try
            Dim drv As DataRowView
            For i As Integer = 0 To DataGridViewGuia.Rows.Count - 1
                DataGridViewGuia.Item(6, i).Value = 0
            Next
            lbNroRagistros.Text = DataGridViewGuia.Rows.Count
        Catch ex As Exception

        End Try
    End Sub
    Private Sub grabar_guia()
        Dim lds_tmp As DataSet
        If b_habilita_grabar = True Then
            Dim icontador As Integer = 0   ' Para determinar cuantos registros han sido
            If DvDetaDoc.Count = 0 Then
                MessageBox.Show("Guía sin Detalle", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'Valida que detalle tenga cantidad
            Dim intCantidad As Integer = 0
            For i = 1 To DvDetaDoc.Count
                dr = DvDetaDoc.Item(i - 1)
                intCantidad += dr("CANTIDAD")
            Next
            If intCantidad = 0 Then
                MessageBox.Show("Guía sin Cantidad", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If Me.TxtBus.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nº del Bus", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtBus.Focus()
                Exit Sub
            End If
            If Me.CbTipoServ.SelectedValue < 0 Then
                MessageBox.Show("Seleccione tipo de Servicio", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CbTipoServ.Focus()
                Exit Sub
            End If

            If es_inhouse = False Then
                Dim lb_paso As Boolean = False
                ' 27/03/2008 -  Considerar como transferencia zonal 
                If CbOriDet.SelectedValue = CbDesDet.SelectedValue Then
                    TxtBus.Text = "998"
                    lb_paso = True
                ElseIf Me.chkCa.Checked And Me.cboCarga.SelectedIndex = 1 Then
                    lb_paso = True
                End If
                ' 
                If Trim(TxtSerie.Text) = "" And lb_paso = False Then
                    MsgBox("Ingrese Nº de Serie", MsgBoxStyle.Critical, "Titan")
                    Exit Sub
                End If
                If Trim(TxtNroGuia.Text) = "" And lb_paso = False Then
                    MsgBox("Ingrese Nº de Guia", MsgBoxStyle.Critical, "Titan")
                    Exit Sub
                End If
                '
                If lb_paso = False Then
                    If CbBus.SelectedValue < 0 Then 'Modificado el 11/01/2007 
                        MsgBox("Seleccione Nº de Bus", MsgBoxStyle.Critical, "Titan")
                        CbBus.Focus()
                        Exit Sub
                    End If
                End If
                '
                If TxtBus.Text = "" And lb_paso = False Then  'Modificado el 11/01/2007 ' y lb_paso = False 12/08/2009
                    MsgBox("Seleccione Nº de Bus", MsgBoxStyle.Critical, "Titan")
                    CbBus.Focus()
                    Exit Sub
                End If
            End If
            '29/12/2007 - Modificado.
            If Me.cmb_agencia_destino.SelectedValue = 0 Or Me.cmb_agencia_destino.SelectedValue = -666 Then
                MsgBox("Falta ingresar la agencia destino...", MsgBoxStyle.Critical, "Titan")
                Me.cmb_agencia_destino.Focus()
                Exit Sub
            End If
            '17/07/2009 - Valida si la ciudad origen y Destino son iguales debe ser transferencia zonal 
            If Me.CbOriDet.SelectedValue = Me.CbDesDet.SelectedValue Then
                Me.CbTipoServ.SelectedValue = 8 ' En caso que la ciudad origen y destino sea igual considera 8 Trans. Zonal 
                Me.CbTipoServ.Enabled = False
                '
            End If

            If Me.CbTipoServ.SelectedValue <> 3 And Me.CbTipoServ.SelectedValue <> 8 Then
                If Me.TxtMarca.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Marca del Bus", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If Me.TxtPlaca.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Placa del Bus", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If Me.CbChofer.SelectedValue < 0 Then
                    MessageBox.Show("Seleccione Piloto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.CbChofer.Focus()
                    Exit Sub
                End If
                If Me.TxtLicencia.Text.Trim.Length < 9 Then
                    MessageBox.Show("Ingrese Nº de Licencia", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtLicencia.Focus()
                    Exit Sub
                End If
            ElseIf Me.CbTipoServ.SelectedValue = 3 Then
                If fnValidarRUC(Me.TxtRucTerc.Text.Trim) = False Then
                    MessageBox.Show("Ingrese Ruc Válido", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtRucTerc.Focus()
                    Exit Sub
                End If
                If Me.TxtTercero.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Razón Social del Proveedor", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtTercero.Focus()
                    Exit Sub
                End If
            End If

            'If TxtFecInicio.GetMyFecha = "  /  /" Then
            '    MsgBox("Fecha de Partida Vacia, Verifique", MsgBoxStyle.Critical, "Seguridad Sistema")
            '    Exit Sub
            'End If
            'If TxtHora.Text = "  :" Then
            '    MsgBox("Hora de Partida Vacia, Verifique", MsgBoxStyle.Critical, "Seguridad Sistema")
            '    Exit Sub
            'End If
            ''If Trim(TxtNomAgencia.Text) = "" Then
            ''    MsgBox("Nombre de Agencia Vacio... Verifique!!!", MsgBoxStyle.Critical, "Titan")
            ''    Exit Sub
            ''End If
            ''If Trim(TxtCodAge.Text) = "" Then
            ''    MsgBox("Codigo de Agencia Vacio... Verifique!!!", MsgBoxStyle.Critical, "Titan")
            ''    Exit Sub
            ''End If
            Dim drori, drdes, drbus, drcho, drser, drsal As DataRowView
            'drrut = DvCbRut.Item(CbRuta.SelectedIndex)
            Try
                If Fact = 1 Then
                    Clase.ID = 0
                Else
                    Clase.ID = TxtID.Text
                End If
                drori = DvCbUnd.Item(CbOriDet.SelectedIndex)
                '
                drdes = DvCbDes.Item(CbDesDet.SelectedIndex)
                '
                If es_inhouse = False Then
                    Try
                        drbus = DvCbEnt.Item(CbBus.SelectedIndex)
                    Catch ex As Exception
                        ' No debe mostrar ningún error, cuando no exista  
                    End Try
                    '
                    'El if agregado por Tepsa 11/11/2006 
                    If CbChofer.SelectedIndex >= 0 Then
                        drcho = DvCbMov.Item(CbChofer.SelectedIndex)
                    End If
                    '
                    '17/07/2009 Solo debe Recuperar el tipo de servicio  
                    'drser = DvCbFor.Item(CbTipoServ.SelectedIndex)
                    '
                End If
                'drsal = dvIti.Item(CbItinerarios.SelectedIndex)
                Clase.Accion = Fact
                If es_inhouse = False Then
                    Clase.Serie = TxtSerie.Text
                    Clase.NroGuia = TxtNroGuia.Text
                    If (CbOriDet.SelectedValue = CbDesDet.SelectedValue) Or Me.cboCarga.SelectedIndex = 1 Then 'add - 12/08/2009  
                        Clase.Serie = "0"    '"null"
                        Clase.NroGuia = "0"  '"null" 
                    End If
                Else
                    Clase.Serie = "0"        '"null" 
                    Clase.NroGuia = "0"      '"null" 
                End If
                Clase.FechaGuia = TxtFecInicio.GetMyFecha
                Clase.CiuOrigen = drori("idunidad_agencia")
                Clase.CiuDestino = drdes("idunidad_agencia")
                If TxtBus.Text <> "998" Then ' Para las moviles 
                    If TxtBus.Text = "" Then
                        Clase.Bus = -666
                    Else
                        If IsDBNull(drbus("idunidad_transporte")) = False Then
                            Clase.Bus = Convert.ToInt16(drbus("idunidad_transporte"))
                        Else
                            Clase.Bus = -666  'drbus("idunidad_transporte
                        End If
                    End If
                Else
                    Clase.Bus = 991 'Nro de bus 998 su id unidad transporte 991 

                End If
                If CbChofer.SelectedIndex < 0 Then  'Condición iif será creado por Tepsa... 
                    Clase.Chofer = -666
                Else
                    If es_inhouse = False Then
                        Clase.Chofer = drcho("idusuario_personal")
                    Else
                        Clase.Chofer = -666
                    End If
                End If
                '
                'If es_inhouse = False Then
                '    If IsDBNull(drser("idtipo_servicio")) = False Then
                '        If Clase.Bus = 991 Then
                '            Clase.TipoServicio = 8 ' Transferencia Zonal 
                '        Else
                '            Clase.TipoServicio = drser("idtipo_servicio")
                '        End If
                '    Else
                '        Clase.TipoServicio = -666
                '    End If
                'Else
                '    Clase.TipoServicio = -666
                'End If
                '17/07/2009 - No interesa el bus para colocar el tipo de servicio - 
                If Me.CbTipoServ.SelectedValue < 1 Then
                    Clase.TipoServicio = -666
                Else
                    Clase.TipoServicio = Me.CbTipoServ.SelectedValue
                End If
                '
                'If (TxtNroSalida.Text = "S/N"  then ' 12/08/2009 Modificado
                If (TxtNroSalida.Text = "S/N") Or (CbOriDet.SelectedValue = CbDesDet.SelectedValue) Then
                    Clase.NroSalida = -1
                Else
                    Clase.NroSalida = IIf(TxtNroSalida.Text = "", "NULL", TxtNroSalida.Text)
                End If
                Clase.Marca = IIf(TxtMarca.Text = "", "NULL", TxtMarca.Text)
                Clase.Placa = IIf(TxtPlaca.Text = "", "NULL", TxtPlaca.Text)
                Clase.Licencia = IIf(TxtLicencia.Text = "", "NULL", TxtLicencia.Text)
                Clase.RUCTercero = IIf(TxtRucTerc.Text = "", "null", TxtRucTerc.Text)
                Clase.NomTercero = IIf(TxtTercero.Text = "", "null", TxtTercero.Text)
                Clase.Usuario = dtoUSUARIOS.IdLogin
                Clase.Rol = dtoUSUARIOS.IdRol
                Clase.IP = dtoUSUARIOS.IP
                Clase.idagencia_ori = l_iidegencia_ori
                Clase.idagencia_dest = Me.cmb_agencia_destino.SelectedValue  '-666   ' Por ahora no está grabando el destino 
                ' Lineas incrementadas el día 13/07/2007 - Definiendo Guías Transportista 
                If Clase.CiuOrigen = Clase.CiuDestino Or Me.cboCarga.SelectedIndex = 1 Then
                    Clase.s_stipo_guia = "M" 'Manifiesto
                Else
                    Clase.s_stipo_guia = "G" 'Guia Transportista 
                End If

                If Me.chkCa.Checked Then
                    Clase.TipoCarga = Me.cboCarga.SelectedIndex + 1
                Else
                    Clase.TipoCarga = 0
                End If

                '
                'Clase.Estado = drest("idestado_registro")
                Clase.Estado = 1
                'Clase.spk = CDbl(IIf(Me.txtSpk.Text.Trim = "", 0, Me.txtSpk.Text))
                '
                lds_tmp = Nothing
                lds_tmp = New DataSet
                'rst = Clase.Grabar
                '
                lds_tmp = Clase.Grabar
                'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
                'If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
                If Convert.ToInt16(lds_tmp.Tables(0).Rows(0).Item(0)) = 0 Then
                    'rstRet = rst.NextRecordset()
                    '
                    MsgBox("Guía Transportista " + TxtSerie.Text + " - " + TxtNroGuia.Text + "  Grabado Correctamente", MsgBoxStyle.Information, "Titan")
                    ClaseDet.Accion = Fact
                    ClaseDet.Usuario = dtoUSUARIOS.IdLogin
                    ClaseDet.Rol = dtoUSUARIOS.IdRol
                    ClaseDet.IP = dtoUSUARIOS.IP
                    ClaseDet.Estado = 1
                    ClaseDet.IDGuia = lds_tmp.Tables(1).Rows(0).Item(0) 'rstRet.Fields(0).Value
                    '
                    'Modificado 04/12/2007 - Ya no debe eliminar                     
                    'ClaseDet.fn_eliminar_det_guiatrans()
                    '
                    'Verificando el nro el nro de línea  
                    Dim linea As Long
                    Dim pasada As Long
                    linea = 1
                    pasada = 1
                    For i = 1 To DvDetaDoc.Count
                        dr = DvDetaDoc.Item(i - 1)
                        'If dr("IDGUIA_TRANSPORTISTA_DETALL") = 0 Then 'Comentado por Tepsa  19/11/2006
                        ClaseDet.Accion = 1
                        '                   Else ' Comentado por Tepsa  19/11/2006
                        'ClaseDet.Accion = 2     ' Comentado por Tepsa  19/11/2006
                        '                  End If ' Comentado por Tepsa 19/11/2006
                        '
                        ClaseDet.ID = dr("IDGUIA_TRANSPORTISTA_DETALL")
                        If ClaseDet.ID = 0 Then
                            ClaseDet.Accion = 1
                        Else
                            ClaseDet.Accion = 2
                        End If
                        ClaseDet.Cantidad = dr("CANTIDAD")
                        '
                        If IsDBNull(dr("total_peso")) = False Then
                            ClaseDet.TotPeso = dr("total_peso")
                        Else
                            ClaseDet.TotPeso = 0
                        End If
                        ' 
                        If IsDBNull(dr("total_volumen")) = False Then
                            ClaseDet.TotVolumen = dr("total_volumen")
                        Else
                            ClaseDet.TotVolumen = 0
                        End If
                        '
                        ClaseDet.TipoComp = dr("idtipo_comprobante")
                        ClaseDet.Comprobante = dr("idcomprobante")
                        ClaseDet.NroDoc = dr("nro_doc")
                        'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
                        'rst = ClaseDet.Grabar
                        Dim lds_tmp1 As New DataSet
                        lds_tmp1 = ClaseDet.Grabar
                        'If Convert.ToInt16(lds_tmp.Tables(0).Rows(0).Item(0)) = 0 Then   ' tepsa 
                        If Convert.ToInt16(lds_tmp1.Tables(0).Rows(0).Item(0)) = 0 Then   ' tepsa 
                            icontador = icontador + 1
                            '    MsgBox("Detalle Grabado Correctamente", MsgBoxStyle.Information, "Titan")
                        Else
                            MessageBox.Show("Descripcion : " + Trim(Convert.ToString(lds_tmp1.Tables(0).Rows(0).Item(1))), "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        If linea = 35 And DvDetaDoc.Count > 35 * (pasada) Then   'Generado por Tepsa 22/11/2006
                            If es_inhouse = False Then
                                ' Incremento una nueva Guía 
                                lds_tmp = Clase.fnIncrementarNroDoc(8) ' 
                                ' Genera una Nueva Guía 
                                fnNroDocumento(8)
                            End If
                            ' Graba la nueva cabacera                              
                            'rst = Nothing
                            'rst = New ADODB.Recordset
                            '
                            If es_inhouse = 5 Then
                                Clase.Serie = TxtSerie.Text
                                Clase.NroGuia = TxtNroGuia.Text
                            Else
                                Clase.Serie = "null"
                                Clase.NroGuia = "null"
                            End If
                            '
                            Clase.ID = 0
                            Clase.Accion = Fact
                            'rst = Clase.Grabar
                            'Mod.26/09/2009 -->Omendoza - Pasando al datahelper   
                            lds_tmp = Nothing
                            lds_tmp = New DataSet
                            lds_tmp = Clase.Grabar
                            'If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
                            If Convert.ToInt16(lds_tmp.Tables(0).Rows(0).Item(0)) = 0 Then
                                'rstRet = rst.NextRecordset()
                                ' Adiciona el nuevo valor a la guia detalle 
                                'ClaseDet.IDGuia = CType(rstRet.Fields(0).Value, Long)
                                ClaseDet.IDGuia = CType(lds_tmp.Tables(1).Rows(0).Item(0), Long)
                                MsgBox("Guía Transportista " + TxtSerie.Text + " - " + TxtNroGuia.Text + "  Grabado Correctamente", MsgBoxStyle.Information, "Titan")
                            Else
                                MessageBox.Show("Descripcion : " + Trim(Convert.ToString(lds_tmp.Tables(0).Rows(0).Item(1))), "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If                                 '
                            ' 
                            linea = 1
                            pasada = pasada + 1
                        Else
                            linea = linea + 1
                        End If
                        lds_tmp1 = Nothing
                    Next
                    ' Tepsa
                    If icontador > 0 Then
                        MsgBox("Detalle, " + CType(icontador, String) + " registro(s) Grabado Correctamente", MsgBoxStyle.Information, "Titan")
                    End If
                    '--
                    'If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
                    '    MsgBox("Detalle Grabado Correctamente", MsgBoxStyle.Information, "Titan")
                    'Else
                    '    MessageBox.Show("Descripcion : " + Trim(Convert.ToString(rst.Fields(1).Value)), "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End If
                    '--
                    ' Fact = 0   '12/11/2006
                    TabMante.SelectedIndex = 0
                    '
                    b_nolee = False
                    CbDesDet.SelectedValue = 0   '12/08/2009 --> Recupera coloc
                    b_nolee = True
                    '
                    If Fact = 1 Then
                        'Incrementar el nro del documento (Guía transportista'Tepsa 21/11/2006 
                        lds_tmp = Clase.fnIncrementarNroDoc(8) ' GUIA REMISION DE TRANSPORTISTA
                    End If
                    '
                    Call BuscaGuiasTransporte()
                Else
                    'MessageBox.Show("Descripcion : " + Trim(Convert.ToString(rst.Fields(1).Value)), "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MessageBox.Show("Descripcion : " + Trim(Convert.ToString(lds_tmp.Tables(0).Rows(0).Item(1))), "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                '
                'Existia código comentado por Eduardo, ha sido eliminado 
                '
                'Restableciendo el valor original del bus 
                If b_copia = True Then
                    volver_origen_bus()
                End If
                '
            Catch Exp As Exception
                MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
                Exit Sub
            End Try
            'Me.labnroregistro_old.Text = "0"
            Me.lbNroRagistros.Text = "0"
        Else
            ' Tepsa colocando a su estado original 
            CbBus.Enabled = True
            'CbTipoServ.Enabled = True
            TxtFecInicio.Enabled = False
            CbItinerarios.Enabled = True
            CbOriDet.Enabled = True
            CbDesDet.Enabled = True
            chkcontroldestino.Enabled = True
            TxtCodDes.Enabled = True
            CbChofer.Enabled = True
            btnEnvio.Enabled = True
            txtGuiaEnvio.Enabled = True
            BtAgregar.Enabled = True
            BtSacar.Enabled = True
            DataGridViewUnd.Enabled = True
            DataGridViewGuia.Enabled = True
            ' 
            b_habilita_grabar = True
            GrabarToolStripMenuItem.Enabled = True
            TabMante.SelectedIndex = 0
            '
            b_nolee = False
            CbDesDet.SelectedValue = 0   '12/08/2009 --> Recupera coloc
            b_nolee = True
            '
            Call BuscaGuiasTransporte()
            '
        End If
        STxtCodDes = ""
        Fact = 0   '11/01/2007 - Tepsa
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub
    Sub busca_dcto(ByVal ls_dcto As String)
        '
        Dim drv As DataRowView
        Dim FValor, IDAge, bus As Integer
        Dim IDValor, vNroGuia As String
        Try
            '--- E
            If DvDetalle Is Nothing Then
                Exit Sub
            End If
            '
            For i = 1 To DvDetalle.Count
                If i - 1 >= DvDetalle.Count Then
                    Exit For
                End If
                drv = DvDetalle.Item(i - 1)
                If IsDBNull(drv("nro_doc")) = False Then
                    If drv("nro_doc") = ls_dcto Then
                        DvDetalle.Delete(i - 1)
                        Exit Sub
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub ActuaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_gt.Click
        Try
            fn_actualiza_guia_transportista(True) ' Si ordena 
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    'Emitir la guía de trasportista 
    Function fn_actualiza_guia_transportista(ByVal ab_ordena As Boolean) As Boolean
        Dim filarow As Integer
        Dim lid As Long
        Dim DrUnd As DataRowView
        Dim sserie, snrodocumento As String
        Dim resp As DialogResult
        '
        Dim ll_idunidad_trans As Long
        Dim ll_idagencia_origen As Long
        '
        Try
            '
            filarow = DataGridViewLista.CurrentRow.Index
            If DataGridViewLista.Rows.Count < 1 Then
                Return False
            End If
            DrUnd = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
            lid = CType(DrUnd("IDGUIA_TRANSPORTISTA"), Long)
            ll_idunidad_trans = CType(DrUnd("idunidad_transporte"), Long)
            ll_idagencia_origen = CType(DrUnd("idagencias"), Long)
            '
            sserie = IIf(IsDBNull(DrUnd("serie_guia_transportista")) = True, "null", Convert.ToString(DrUnd("serie_guia_transportista")))
            snrodocumento = IIf(IsDBNull(DrUnd("nro_guia_transportista")) = True, "null", Convert.ToString(DrUnd("nro_guia_transportista")))
            If sserie = "null" Or snrodocumento = "null" Then  ' Si tiene algunos como nulos debe ingresar para que se actualice directamente
                resp = Windows.Forms.DialogResult.Yes
            Else
                '
                resp = MessageBox.Show("¿Esta seguro de actualizar la guía de transportista? " & sserie & " - " & snrodocumento, "Guía de Transportista", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If
            If resp = Windows.Forms.DialogResult.Yes Then
                '04/02/2008 - Invocando a la ventana que llama para actualizar la guía 
                Dim obj_actualiza_gt As New frm_actualiza_gt
                '
                obj_actualiza_gt.ps_serie_gt = sserie
                obj_actualiza_gt.ps_nro_gt = snrodocumento
                '
                obj_actualiza_gt.pl_idagencia = ll_idagencia_origen
                obj_actualiza_gt.pl_idguia_transportista = lid
                obj_actualiza_gt.pl_nro_bus_ant = ll_idunidad_trans
                'obj_actualiza_gt.ShowDialog()

                Acceso.Asignar(obj_actualiza_gt, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    obj_actualiza_gt.ShowDialog()
                Else
                    MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

                If ab_ordena Then
                    If obj_actualiza_gt.pb_cancelar = False Then
                        ' Refresca la ventana 
                        Call BuscaGuiasTransporte()
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Function

    Private Sub CbOriDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbOriDet.SelectedIndexChanged
        If b_nolee Then
            If Me.CbOriDet.SelectedValue = Me.CbDesDet.SelectedValue Then
                Me.CbTipoServ.SelectedValue = 8 ' En caso que la ciudad origen y destino sea igual considera 8 Trans. Zonal 
                Me.CbTipoServ.Enabled = False
                TxtBus.Text = "998" ' Tranferencia zonal 
                Me.TxtSerie.Text = ""
                Me.TxtNroGuia.Text = ""
                Me.TxtSerie.Enabled = False    '11/08/2009 - modificado
                Me.TxtNroGuia.Enabled = False
            Else
                '
                'Me.CbTipoServ.SelectedValue = 0
                If Me.CbTipoServ.SelectedValue = 8 Then
                    Me.CbTipoServ.SelectedValue = 0
                    Me.TxtBus.Text = ""
                End If
                ' Me.CbTipoServ.Enabled = True
                Me.TxtSerie.Enabled = True     '11/08/2009 - Modificado 
                Me.TxtNroGuia.Enabled = True
                '
            End If
        End If
    End Sub

    Sub Cabecera(ByVal dt As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        obj.EscribirLinea(iLong * y + 10, 12, dt.Rows(0).Item("serie_guia_transportista"))
        obj.EscribirLinea(iLong * y + 10, 16, dt.Rows(0).Item("nro_guia_transportista"))
        obj.EscribirLinea(iLong * y + 10, 26, "Codigo MTC: 1516471CNG")

        obj.EscribirLinea(iLong * y + 11, 12, dt.Rows(0).Item("agencia partida"))
        obj.EscribirLinea(iLong * y + 11, 90, dt.Rows(0).Item("fecha_salida"))
        obj.EscribirLinea(iLong * y + 11, 102, dt.Rows(0).Item("hora_salida"))

        obj.EscribirLinea(iLong * y + 12, 12, dt.Rows(0).Item("agencia llegada"))
        obj.EscribirLinea(iLong * y + 12, 91, dt.Rows(0).Item("fecha_llegada"))
    End Sub

    Sub Total(ByVal dt As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        obj.EscribirLinea(y + 1, 25, Replicate("-", 103))

        Dim iCantidad As Integer = dt.Compute("sum(total_bultos_en_guia)", "")
        Dim iCantidad2 As Integer = dt.Compute("sum(cantidad)", "")
        Dim iPeso As Integer = dt.Compute("sum(total_peso_en_guia)", "")
        Dim iPeso2 As Integer = dt.Compute("sum(total_peso)", "")

        obj.EscribirLinea(y + 2, 26, "T. Bultos en Doc.:")
        obj.EscribirLinea(y + 2, 48, Format(iCantidad, "####,###,###0.00").PadLeft(5, " "))

        obj.EscribirLinea(y + 2, 60, "T. Peso en Doc.:")
        obj.EscribirLinea(y + 2, 77, Format(iPeso, "####,###,###0.00").PadLeft(10, " "))

        obj.EscribirLinea(y + 2, 93, "TOTAL")
        obj.EscribirLinea(y + 2, 105, Format(iCantidad2, "####,###,###0.00").PadLeft(5, " "))
        obj.EscribirLinea(y + 2, 113, Format(iPeso2, "####,###,###0.00").PadLeft(10, " "))
    End Sub

    Sub Pie(ByVal dt As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        obj.EscribirLinea(iLong * y + 54, 18, IIf(IsDBNull(dt.Rows(0).Item("marca_bus")), "", dt.Rows(0).Item("marca_bus")))

        obj.EscribirLinea(iLong * y + 55, 18, IIf(IsDBNull(dt.Rows(0).Item("placa_bus")), "", dt.Rows(0).Item("placa_bus")))
        obj.EscribirLinea(iLong * y + 55, 63, IIf(IsDBNull(dt.Rows(0).Item("ape_nombre_piloto")), "", dt.Rows(0).Item("ape_nombre_piloto")))

        obj.EscribirLinea(iLong * y + 57, 18, IIf(IsDBNull(dt.Rows(0).Item("nro_unidad_transporte")), "", dt.Rows(0).Item("nro_unidad_transporte")))
        obj.EscribirLinea(iLong * y + 58, 24, IIf(IsDBNull(dt.Rows(0).Item("ruc_tercero")), "", dt.Rows(0).Item("ruc_tercero")))
        obj.EscribirLinea(iLong * y + 59, 18, IIf(IsDBNull(dt.Rows(0).Item("nro_licencia")), "", dt.Rows(0).Item("nro_licencia")))

        obj.EscribirLinea(iLong * y + 60, 18, IIf(IsDBNull(dt.Rows(0).Item("nom_tercero")), "", dt.Rows(0).Item("nom_tercero")))
        obj.EscribirLinea(iLong * y + 61, 18, dtoUSUARIOS.iLOGIN)
        obj.EscribirLinea(iLong * y + 61, 70, IIf(IsDBNull(dt.Rows(0).Item("fecha_salida")), "", dt.Rows(0).Item("fecha_salida")))
    End Sub

    Sub Imprimir(ByVal dt As DataTable)
        Dim obj As New Imprimir
        Try
            Dim sImpresora As String
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0

            obj.Inicializar()
            dtoUSUARIOS.IP = "10.1.0.194"
            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt2 As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 8)
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
            iLong = IIf(iTamaño = 0, 66, iTamaño)

            'cabecera
            Cabecera(dt, obj, pagina)
            y = iLong * pagina + 14
            For Each row As DataRow In dt.Rows
                y += 1
                i += 1
                obj.EscribirLinea(y, 0, i.ToString.PadLeft(2, " "))
                obj.EscribirLinea(y, 4, row("ruc"))
                obj.EscribirLinea(y, 21, row("tipo_comprobante"))
                obj.EscribirLinea(y, 32, row("nro_doc"))
                obj.EscribirLinea(y, 55, row("detalle"))
                obj.EscribirLinea(y, 105, Format(row("cantidad"), "####,###,###0.00").PadLeft(5, " "))
                obj.EscribirLinea(y, 113, Format(row("total_peso"), "####,###,###0.00").PadLeft(10, " "))
                obj.EscribirLinea(y, 124, IIf(IsDBNull(row("es_carga_asegurada")), "", row("es_carga_asegurada")))
                obj.EscribirLinea(y, 127, IIf(IsDBNull(row("es_carga_acompanada")), "", row("es_carga_acompanada")))
                If i Mod 35 = 0 Then
                    'totales
                    Total(dt, obj, y)

                    'pie de pagina
                    Pie(dt, obj, pagina)

                    pagina += 1
                    Cabecera(dt, obj, pagina)
                    y = iLong * pagina + 14
                End If
            Next
            'totales
            Total(dt, obj, y)
            'pie de pagina
            Pie(dt, obj, pagina)

            obj.Comprimido = True
            obj.Preliminar = True
            obj.Tamaño = iLong
            obj.Imprimir()
            obj.Finalizar()

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub CabeceraManifiesto(ByVal dt As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        'obj.EscribirLinea(iLong * y + 10, 19, dt.Rows(0).Item("serie_guia_transportista"))
        'obj.EscribirLinea(iLong * y + 10, 19, dt.Rows(0).Item("nro_guia_transportista"))

        Dim n As Integer = 1
        obj.EscribirLinea(iLong * y + n, 1, "T.E.P.S.A.C.")
        obj.EscribirLinea(iLong * y + n, 55, "MANIFIESTO DE CARGA")
        obj.EscribirLinea(iLong * y + n, 119, Date.Now.ToShortDateString)

        obj.EscribirLinea(iLong * y + n + 1, 1, "GUIAT003")
        obj.EscribirLinea(iLong * y + n + 1, 119, Date.Now.ToShortTimeString)

        obj.EscribirLinea(iLong * y + n + 2, 119, "Pag " & y + 1)

        obj.EscribirLinea(iLong * y + n + 4, 1, "PUNTO DE PARTIDA:")
        obj.EscribirLinea(iLong * y + n + 4, 19, dt.Rows(0).Item("agencia partida"))
        obj.EscribirLinea(iLong * y + n + 4, 93, "FECHA DE PARTIDA:")
        obj.EscribirLinea(iLong * y + n + 4, 112, dt.Rows(0).Item("fecha_salida"))
        obj.EscribirLinea(iLong * y + n + 4, 124, dt.Rows(0).Item("hora_salida"))

        obj.EscribirLinea(iLong * y + n + 5, 1, "PUNTO DE LLEGADA:")
        obj.EscribirLinea(iLong * y + n + 5, 19, dt.Rows(0).Item("agencia llegada"))
        obj.EscribirLinea(iLong * y + n + 5, 93, "FECHA DE LLEGADA:")
        obj.EscribirLinea(iLong * y + n + 5, 112, dt.Rows(0).Item("fecha_llegada"))

        obj.EscribirLinea(iLong * y + n + 7, 1, Replicate("-", 129))
        obj.EscribirLinea(iLong * y + n + 8, 2, "NRO.")
        obj.EscribirLinea(iLong * y + n + 8, 7, "RUC")
        obj.EscribirLinea(iLong * y + n + 8, 28, "DOC")
        obj.EscribirLinea(iLong * y + n + 8, 39, "NRO. DOCUMENTO")
        obj.EscribirLinea(iLong * y + n + 8, 62, "DESCRIPCION")
        obj.EscribirLinea(iLong * y + n + 8, 112, "CANTIDAD")
        obj.EscribirLinea(iLong * y + n + 8, 125, "PESO")
        obj.EscribirLinea(iLong * y + n + 9, 1, Replicate("-", 129))
    End Sub

    Sub TotaManifiesto(ByVal dt As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        obj.EscribirLinea(y + 1, 108, Replicate("-", 9))
        obj.EscribirLinea(y + 1, 121, Replicate("-", 9))

        Dim iCantidad As Integer = dt.Compute("sum(cantidad)", "")
        Dim iPeso As Integer = dt.Compute("sum(total_peso)", "")

        obj.EscribirLinea(y + 2, 107, Format(iCantidad, "####,###,###0.00").PadLeft(10, " "))
        obj.EscribirLinea(y + 2, 120, Format(iPeso, "####,###,###0.00").PadLeft(10, " "))
    End Sub

    Sub PieManifiesto(ByVal dt As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        Dim n As Integer = 54

        obj.EscribirLinea(iLong * y + n, 1, "MARCA DEL VEHICULO :")
        obj.EscribirLinea(iLong * y + n, 22, IIf(IsDBNull(dt.Rows(0).Item("marca_bus")), "", dt.Rows(0).Item("marca_bus")))
        obj.EscribirLinea(iLong * y + n, 73, IIf(IsDBNull(dt.Rows(0).Item("ape_nombre_piloto")), "", dt.Rows(0).Item("ape_nombre_piloto")))

        obj.EscribirLinea(iLong * y + n + 1, 1, "PLACA NRO. :")
        obj.EscribirLinea(iLong * y + n + 1, 14, IIf(IsDBNull(dt.Rows(0).Item("placa_bus")), "", dt.Rows(0).Item("placa_bus")))

        obj.EscribirLinea(iLong * y + n + 2, 1, "CONFIGURACION VEHICULAR :")
        obj.EscribirLinea(iLong * y + n + 2, 27, IIf(IsDBNull(dt.Rows(0).Item("nro_unidad_transporte")), "", dt.Rows(0).Item("nro_unidad_transporte")))

        obj.EscribirLinea(iLong * y + n + 3, 1, "NRO. CERTIFICADO INSCRIPCION :")
        obj.EscribirLinea(iLong * y + n + 3, 32, IIf(IsDBNull(dt.Rows(0).Item("ruc_tercero")), "", dt.Rows(0).Item("ruc_tercero")))

        obj.EscribirLinea(iLong * y + n + 4, 1, "NRO. LICENCIA CONDUCIR :")
        obj.EscribirLinea(iLong * y + n + 4, 26, IIf(IsDBNull(dt.Rows(0).Item("nro_licencia")), "", dt.Rows(0).Item("nro_licencia")))

        obj.EscribirLinea(iLong * y + n + 5, 1, "NOMBRE Y RAZON SOCIAL EMPRESA SUBCONTRATADA :")
        obj.EscribirLinea(iLong * y + n + 5, 47, IIf(IsDBNull(dt.Rows(0).Item("nom_tercero")), "", dt.Rows(0).Item("nom_tercero")))

        obj.EscribirLinea(iLong * y + n + 5, 73, "FECHA :")
        obj.EscribirLinea(iLong * y + n + 5, 81, IIf(IsDBNull(dt.Rows(0).Item("fecha_salida")), "", dt.Rows(0).Item("fecha_salida")))

        obj.EscribirLinea(iLong * y + n + 7, 1, dtoUSUARIOS.iLOGIN)
    End Sub

    Sub Manifiesto(ByVal dt As DataTable)
        Dim obj As New Imprimir
        Try
            Dim sImpresora As String
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0

            obj.Inicializar()
            'Dim sImpresora As String = obj.ObtieneImpresora(8, dtoUSUARIOS.IP)
            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt2 As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 8)
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
            obj.Impresora = sImpresora
            obj.Superior = iSuperior
            obj.Izquierda = Iizquierda

            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            iLong = IIf(iTamaño = 0, 66, iTamaño)

            'cabecera
            CabeceraManifiesto(dt, obj, pagina)
            y = iLong * pagina + 10
            For Each row As DataRow In dt.Rows
                y += 1
                i += 1
                obj.EscribirLinea(y, 1, i.ToString.PadLeft(3, " "))
                obj.EscribirLinea(y, 7, row("ruc"))
                obj.EscribirLinea(y, 28, row("tipo_comprobante"))
                obj.EscribirLinea(y, 39, row("nro_doc"))
                obj.EscribirLinea(y, 62, row("detalle"))
                obj.EscribirLinea(y, 112, Format(row("cantidad"), "####,###,###0.00").PadLeft(5, " "))
                obj.EscribirLinea(y, 120, Format(row("total_peso"), "####,###,###0.00").PadLeft(10, " "))
                obj.EscribirLinea(y, 131, IIf(IsDBNull(row("es_carga_asegurada")), "", row("es_carga_asegurada")))
                obj.EscribirLinea(y, 134, IIf(IsDBNull(row("es_carga_acompanada")), "", row("es_carga_acompanada")))

                If i Mod 35 = 0 Then
                    'totales
                    TotaManifiesto(dt, obj, y)

                    'pie de pagina
                    PieManifiesto(dt, obj, pagina)

                    pagina += 1
                    CabeceraManifiesto(dt, obj, pagina)
                    y = iLong * pagina + 10
                End If
            Next
            'totales
            TotaManifiesto(dt, obj, y)
            'pie de pagina
            PieManifiesto(dt, obj, pagina)

            obj.Comprimido = True
            obj.Preliminar = True
            obj.Tamaño = iLong
            obj.Imprimir()
            obj.Finalizar()
        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub ImprimirGuia()
        If DataGridViewLista.RowCount < 1 Then
            Exit Sub
        End If

        Try
            ObjReport = New ClsLbTepsa.dtoFrmReport
            Dim b_actualizo As Boolean = False
            Dim iidguia_transportista As Integer
            ' Debe tener el número de guía de transportista 
            If Fact = 2 Then
                If TxtSerie.Text = "" Or TxtNroGuia.Text = "" Then
                    MessageBox.Show("Falta ingresar el número de guía", "Guía de Transportista", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    If TxtSerie.Text = "" Then
                        TxtSerie.Focus()
                    End If
                    If TxtNroGuia.Text = "" Then
                        TxtNroGuia.Focus()
                    End If
                    Exit Sub
                End If
                '
                If TxtID.Text = "" Then
                    MessageBox.Show("Primero, debe grabar la guía, para emitirla", "Guía de Transportista", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                '
                iidguia_transportista = CType(TxtID.Text, Integer)
                '
                ' Recuperando la información para el reporte 
                ' Pasando los valores
            Else
                'Dim rsIti As ADODB.Recordset
                Dim filarow As Integer
                Dim DrUnd As DataRowView
                'Dim sserie As String
                'Dim snrodocumento As String
                Dim ll_idusuario_píloto As Long

                filarow = DataGridViewLista.CurrentRow.Index
                If filarow >= 0 Then
                    Dim idagencia_origen, idagencia_destino, idunidad_agencia, idunidad_agencia_destino As Long
                    DrUnd = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
                    '
                    idagencia_origen = IIf(IsDBNull(Convert.ToString(DrUnd("idagencias"))) = True, -666, Convert.ToString(DrUnd("idagencias")))
                    idagencia_destino = IIf(IsDBNull(Convert.ToString(DrUnd("idagencias_destino"))) = True Or Convert.ToString(DrUnd("idagencias_destino")) = "", -666, Convert.ToString(DrUnd("idagencias_destino")))
                    idunidad_agencia = IIf(IsDBNull(Convert.ToString(DrUnd("idunidad_agencia"))) = True Or Convert.ToString(DrUnd("idunidad_agencia")) = "", -666, Convert.ToString(DrUnd("idunidad_agencia")))
                    idunidad_agencia_destino = IIf(IsDBNull(Convert.ToString(DrUnd("idunidad_agencia_destino"))) = True Or Convert.ToString(DrUnd("idunidad_agencia_destino")) = "", -666, Convert.ToString(DrUnd("idunidad_agencia_destino")))
                    iidguia_transportista = Convert.ToString(DrUnd("IDGUIA_TRANSPORTISTA"))
                    ll_idusuario_píloto = IIf(IsDBNull(Convert.ToString(DrUnd("idusuario_personal_piloto"))) = True Or Convert.ToString(DrUnd("idusuario_personal_piloto")) = "", -666, Convert.ToString(DrUnd("idusuario_personal_piloto")))
                    If idunidad_agencia <> idunidad_agencia_destino Then
                        If IsDBNull(DrUnd("serie_guia_transportista")) = True Or IsDBNull(DrUnd("nro_guia_transportista")) = True Then
                            If fn_actualiza_guia_transportista(True) = False Then
                                Exit Sub
                            End If
                            b_actualizo = True
                        End If
                        ' Verificar si las agencias son iguales debe seleccionar una agencia especifica 
                        ' Contemplando el manifiesto (Omendoza) 
                        '
                    Else
                        ' Activa ventana de actualizacion 
                        ' Debe validar que la agencia sean diferentes y tenga pilotos  -- 31/08/2009
                        If (idagencia_origen = idunidad_agencia_destino) Or (idagencia_destino = -666) Or (ll_idusuario_píloto = -666) Then
                            Dim Obj_actagencia_y_piloto As New frm_act_agencia_y_piloto
                            Obj_actagencia_y_piloto.dt_ciudad = DtOrigen.Copy
                            Obj_actagencia_y_piloto.dv_ciudad = CargarCombo(Obj_actagencia_y_piloto.cmb_ciudad_destino, Obj_actagencia_y_piloto.dt_ciudad, "nombre_unidad", "idunidad_agencia", dtoUSUARIOS.m_idciudad)  ' Por defecto 0 No debe aparecer nada 
                            '
                            Obj_actagencia_y_piloto.dt_agencia = dtagencias_filtro.Copy
                            Obj_actagencia_y_piloto.dv_agencia = CargarCombo(Obj_actagencia_y_piloto.cmb_agencia_destino, Obj_actagencia_y_piloto.dt_agencia, "nombre_agencia", "idagencia", dtoUSUARIOS.m_iIdAgencia)  ' Aparecera la agencias destino
                            Obj_actagencia_y_piloto.dv_agencia.RowFilter = "idagencia <> " + CType(idagencia_origen, String)
                            '
                            Obj_actagencia_y_piloto.dt_piloto = DtCbMov.Copy
                            Obj_actagencia_y_piloto.dv_piloto = CargarCombo(Obj_actagencia_y_piloto.cmb_piloto, Obj_actagencia_y_piloto.dt_piloto, "NOMBRE", "idusuario_personal", -666)  ' Apareceran los pilotos 
                            '
                            Obj_actagencia_y_piloto.l_idguia_transportista = iidguia_transportista
                            Obj_actagencia_y_piloto.l_idusuario_personal = CType(dtoUSUARIOS.IdLogin, Long)
                            Obj_actagencia_y_piloto.s_ip = dtoUSUARIOS.IP

                            Acceso.Asignar(Obj_actagencia_y_piloto, Me.hnd)
                            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                                Obj_actagencia_y_piloto.ShowDialog()
                            Else
                                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return
                            End If

                            Obj_actagencia_y_piloto = Nothing
                        End If
                    End If

                End If
            End If
            '---
            'Dim iidfuncionario, iidtipo_persona, icliente_corporativo, iidestado_registro As Integer
            '
            'ObjReport.rutaRpt = PathFrmReport
            'ObjReport.conectar(rptservice, rptuser, rptpass)   'Esta conexion por ahora está en prueba (rptservice, rptuser, rptpass) '  ("tepsa", "titan", "titan")

            Dim dv As New DataView
            Dim objVENTA_CONTADO As New ClsLbTepsa.dtoVENTA_CONTADO
            objVENTA_CONTADO.IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
            'DATAHELPER
            dv = objVENTA_CONTADO.sp_tipo_format_impre()


            'tipo_bole_impre = dv.Table.Rows(0)("tipo_bole_impre")
            'tipo_factu_impre = dv.Table.Rows(0)("tipo_factu_impre")
            tipo_guia_transpor_impre = dv.Table.Rows(0)("tipo_guia_transpor_impre")
            '
            If Me.rbguia.Checked = True Then
                If tipo_guia_transpor_impre = "A" Then
                    'ObjReport.printrpt(False, "", "GUIAT001.rpt", _
                    '                       "p_usuario;" & dtoUSUARIOS.iLOGIN, _
                    '                       "iidguia_transportista;" & iidguia_transportista)

                    'DIEGO 25-05-2013
                    MsgBox("Datos Mal Ingresados, Comuniquese con Sistemas")

                Else
                    'ObjReport.printrpt(False, "", "GUIAT007.rpt", _
                    '                                       "p_usuario;" & dtoUSUARIOS.iLOGIN, _
                    '                                       "IIDGUIA_TRANSPORTISTA;" & iidguia_transportista)

                    Dim obj As New dtoGuiasTransp
                    Dim dt As DataTable = obj.Guia_Transportista(iidguia_transportista)
                    Imprimir(dt)

                    Dim frm As New FrmPreview
                    frm.Documento = 8
                    frm.Tamaño = iLong
                    frm.Text = "Guía de Transportista"
                    frm.ShowDialog()

                    'si usuario imprimio grt
                    If frm.Impreso = 1 Then
                        obj.GuiaTransportistaImpresa(iidguia_transportista, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                    End If
                    obj = Nothing
                End If
            Else
                iidguia_transportista = Me.DataGridViewLista.CurrentRow.Cells("id").Value
                Dim frmImprimir As New frmImprimirManifiesto
                frmImprimir.ShowDialog()
                If frmImprimir.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    Return
                End If
                Dim obj As New dtoGuiasTransp
                If frmImprimir.rbtLaser.Checked Then
                    ObjReport.rutaRpt = PathFrmReport
                    ObjReport.conectar(rptservice, rptuser, rptpass)   'Esta conexion por ahora está en prueba (rptservice, rptuser, rptpass) '  ("tepsa", "titan", "titan")
                    ObjReport.printrpt(False, "", "GUIAT003-1.rpt", _
                                           "p_usuario;" & dtoUSUARIOS.iLOGIN, _
                                           "iidguia_transportista;" & iidguia_transportista)
                Else
                    Dim dt As DataTable = obj.Manifiesto(iidguia_transportista)
                    Manifiesto(dt)
                    Dim frm As New FrmPreview
                    frm.Documento = 8
                    frm.Tamaño = iLong
                    frm.Text = "Manifiesto de Carga"
                    frm.ShowDialog()
                    'si usuario imprimio manifiesto
                    If frm.Impreso = 1 Then
                        obj.GuiaTransportistaImpresa(iidguia_transportista, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                    End If
                End If
                obj = Nothing
                ''ObjReport.printrpt(False, "", "GUIAT003.rpt", _
                ''                       "p_usuario;" & dtoUSUARIOS.iLOGIN, _
                ''                       "iidguia_transportista;" & iidguia_transportista)
                'Dim obj As New dtoGuiasTransp
                'Dim dt As DataTable = obj.Manifiesto(iidguia_transportista)
                'Manifiesto(dt)

                'Dim frm As New FrmPreview
                'frm.Documento = 8
                'frm.Tamaño = iLong
                'frm.Text = "Manifiesto de Carga"
                'frm.ShowDialog()

                ''si usuario imprimio manifiesto
                'If frm.Impreso = 1 Then
                '    obj.GuiaTransportistaImpresa(iidguia_transportista, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                'End If

                'obj = Nothing
            End If
            '
            If b_actualizo = True Then
                Call BuscaGuiasTransporte()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Spk()
        Dim iSubtotal As Double = 0
        Try
            'Obtiene subtotal
            For Each row As DataGridViewRow In DataGridViewGuia.Rows
                iSubtotal += IIf(IsDBNull(row.Cells("subtotal").Value), 0, row.Cells("subtotal").Value)
            Next

            Dim iKilometros As Double = IIf(Me.txtKilometraje.Text.Trim = "", 0, CDbl(Me.txtKilometraje.Text))
            Me.txtSubtotalAcumulado.Text = Format(iSubtotal, "#,###,###0.00")
            Me.txtSpk.Text = Format(iSubtotal / iKilometros, "#,###,###0.00")
        Catch ex As Exception
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem7.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub TxtBus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus.TextChanged

    End Sub

    Private Sub txtGuiaEnvio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuiaEnvio.TextChanged

    End Sub

    Private Sub ImprimirTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirTicketToolStripMenuItem.Click
        Try
            If (MessageBox.Show("¿Realmente desea imprimir los Ticket?", "Impresión de Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                Cursor = Cursors.WaitCursor
                Dim intId As Integer = DataGridViewLista.CurrentRow.Cells("id").Value
                Dim objeto As Object = DirectCast(DataGridViewLista.DataSource, DataView).Item(DataGridViewLista.CurrentRow.Index)
                Dim obj As New dtoGuiasTransp
                Dim dt As DataTable = obj.ListarGrt(intId)

                If (dt.Rows.Count = 0) Then
                    MessageBox.Show("No se han encontrado comprobantes válidos (Facturas y/o Boletas) en la GRT, para la reimpresión de Tickets.")
                    Return
                End If

                '-->Realiza la reimpresion de todos los ticket (Boletas y Facturas) de la GRT
                reimpresionTicket(dt)


                Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Imprimir Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Private Sub DataGridViewLista_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridViewLista.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            '---> jabanto - 21/07/2016
            With DataGridViewLista
                'seleccionamos la fila completa del control DataGridView.
                Dim hti As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                ' Obtenemos la parte del control a las que pertenecen las coordenadas.
                If hti.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(hti.RowIndex).Cells(hti.ColumnIndex)
                    menu_for_gt.Show(sender, .PointToClient(Windows.Forms.Cursor.Position))

                    ImprimirTicketToolStripMenuItem.Enabled = True

                    '-->Valida la reimpresion 
                    Dim unidadAgenciaOrigen As Long = DirectCast(DataGridViewLista.DataSource, DataView).Item(DataGridViewLista.CurrentRow.Index).Item("IDUNIDAD_AGENCIA")
                    Dim unidadAgenciaDestino As Long = DirectCast(DataGridViewLista.DataSource, DataView).Item(DataGridViewLista.CurrentRow.Index).Item("IDUNIDAD_AGENCIA_DESTINO")
                    Dim fechaSalida As Date = DirectCast(DataGridViewLista.DataSource, DataView).Item(DataGridViewLista.CurrentRow.Index).Item("FECHA_SALIDA")
                    Dim permitir = validarImpresionTicket(unidadAgenciaOrigen, unidadAgenciaDestino, fechaSalida)
                    ImprimirTicketToolStripMenuItem.Enabled = permitir
                End If
            End With
        End If
    End Sub
    Private Sub ImprimirTicketToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirTicketToolStripMenuItem1.Click
        Try
            If (MessageBox.Show("¿Realmente desea imprimir el Ticket?", "Impresión de Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                Cursor = Cursors.WaitCursor
                Dim intTipo As Integer = DataGridViewGuia.CurrentRow.Cells("idtipo_comprobante").Value
                Dim intId As Integer = DataGridViewGuia.CurrentRow.Cells("idcomprobante").Value
                Dim obj As New dtoGuiasTransp
                Dim dt As DataTable = obj.ListarComprobante(intTipo, intId)

                '--->Realiza la reimpresion del Ticket del Comprobante seleccionado
                reimpresionTicket(dt)

                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Imprimir Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    ''' <summary>
    ''' Valida la reimpresion del comprobante electronico
    ''' </summary>
    ''' <param name="unidadAgenciaOrigen">Identificador de la unidad agencia origen</param>
    ''' <param name="unidadAgenciaDestino">Identificador de la unidad agencia destino</param>
    ''' <param name="fechaSalida">fceha de salida o emision de la grt</param>
    ''' <returns>true=si esta permitida la reimpresion, false=Lo contrario</returns>
    Private Function validarImpresionTicket(ByVal unidadAgenciaOrigen As Long, ByVal unidadAgenciaDestino As Long, ByVal fechaSalida As Date) As Boolean
        '-->Valida si es una transferencia Zonal.
        If (unidadAgenciaOrigen = unidadAgenciaDestino) Then
            Return False
        Else
            '-->Valida por fecha de emision
            Dim fechaServer As Date = Convert.ToDateTime(FechaServidor()).ToString("dd/MM/yyyy")

            Dim dias As Integer = (fechaServer - fechaSalida).TotalDays
            '-->Solo permite 1 dia
            If (dias > 1) Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub chkCa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCa.CheckedChanged
        pb_nolee_codigo_iata = True
        STxtCodDes = ""
        TxtCodDes_TextChanged(Nothing, Nothing)
        If Me.chkCa.Checked Then
            Me.cboCarga.SelectedIndex = 0
            Me.cboCarga.Enabled = True
            ListarHoraSalida()
        Else
            Me.cboCarga.SelectedIndex = -1
            Me.cboCarga.Enabled = False
            Me.cboCA.Items.Clear()
            Me.cboCA.Enabled = False
            If Fact <> 2 Then
                fnNroDocumento(8)
            End If
            Me.TxtSerie.Enabled = True
            Me.TxtNroGuia.Enabled = True
            End If
            If Me.DataGridViewGuia.Rows.Count > 0 Then
                Me.Button1_Click(Nothing, Nothing)
                Me.BtSacar_Click(Nothing, Nothing)
            End If
    End Sub

    Sub ListarHoraSalida()
        Me.cboCA.Items.Clear()
        Me.cboCA.Items.Add("(TODO)")
        If dtHoraSalida.Rows.Count > 0 Then
            If IsDBNull(dtHoraSalida.Rows(0).Item(0)) = False Then
                For Each row As DataRow In dtHoraSalida.Rows
                    Me.cboCA.Items.Add(row.Item("hora"))
                Next
                Me.cboCA.Enabled = True
            Else
                Me.cboCA.Enabled = False
            End If
        Else
            Me.cboCA.Enabled = False
        End If
        Me.cboCA.SelectedIndex = 0
    End Sub

    Private Sub cboCA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCA.SelectedIndexChanged
        pb_nolee_codigo_iata = True
        STxtCodDes = ""
        TxtCodDes_TextChanged(Nothing, Nothing)
    End Sub

    Sub ComprobanteRepetido(ByVal dt As DataTable)
        Try
            With DataGridViewGuia
                If .Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        For Each row As DataGridViewRow In .Rows
                            If dt.Rows(i).Item("idcomprobante") = row.Cells("idcomprobante").Value Then
                                dt.Rows.RemoveAt(i)
                            End If
                        Next
                    Next
                End If
            End With
        Catch
        End Try
    End Sub

    Private Sub DataGridViewGuia_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridViewGuia.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            '---> jabanto - 21/07/2016
            With DataGridViewGuia
                'seleccionamos la fila completa del control DataGridView.
                Dim hti As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                ' Obtenemos la parte del control a las que pertenecen las coordenadas.
                If hti.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(hti.RowIndex).Cells(hti.ColumnIndex)

                    '-->Validamos el tipo de comprobante (Solo disponible para Boletas y Facturas)
                    Dim intTipo As Integer = .CurrentRow.Cells("idtipo_comprobante").Value
                    Dim guiaTransportistaID As Integer = DirectCast(.DataSource, DataView).Item(.CurrentRow.Index).Item("IDGUIA_TRANSPORTISTA")

                    If guiaTransportistaID > 0 AndAlso (intTipo = FEManager.TITAN_ID_TIPCOM_FACTURA Or intTipo = FEManager.TITAN_ID_TIPCOM_BOLETA Or intTipo = 85) Then
                        '-->Valida la reimpresion 
                        Dim unidadAgenciaOrigen As Long = DirectCast(DataGridViewLista.DataSource, DataView).Item(DataGridViewLista.CurrentRow.Index).Item("IDUNIDAD_AGENCIA")
                        Dim unidadAgenciaDestino As Long = DirectCast(DataGridViewLista.DataSource, DataView).Item(DataGridViewLista.CurrentRow.Index).Item("IDUNIDAD_AGENCIA_DESTINO")
                        Dim fechaSalida As Date = DirectCast(DataGridViewLista.DataSource, DataView).Item(DataGridViewLista.CurrentRow.Index).Item("FECHA_SALIDA")
                        Dim permitir = validarImpresionTicket(unidadAgenciaOrigen, unidadAgenciaDestino, fechaSalida)

                        If (permitir) Then
                            contextDetalle.Show(sender, .PointToClient(Windows.Forms.Cursor.Position))
                        End If
                    End If
                End If
            End With



            'If DataGridViewGuia.Rows.Count > 0 Then
            '    Dim intTipo As Integer = DataGridViewGuia.CurrentRow.Cells("idtipo_comprobante").Value
            '    If intTipo = 1 Or intTipo = 2 Then
            '        contextDetalle.Show(sender, e.X, e.Y)
            '    End If
            'End If
        End If
    End Sub

    Private Sub DataGridViewUnd_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridViewUnd.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.DataGridViewUnd.Rows.Count > 0 Then
                contextPendiente.Show(sender, e.X, e.Y)
            End If
        End If
    End Sub

    Private Sub TodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TodoToolStripMenuItem.Click
        SeleccionarCheckDgv(Me.DataGridViewUnd, 6, 1)
    End Sub

    Private Sub NingunoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NingunoToolStripMenuItem.Click
        SeleccionarCheckDgv(Me.DataGridViewUnd, 6, 0)
    End Sub


    Private Sub cboCarga_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarga.SelectedIndexChanged
        If Fact = 2 Then Return
        pb_nolee_codigo_iata = True
        STxtCodDes = ""
        TxtCodDes_TextChanged(Nothing, Nothing)
        If Me.DataGridViewGuia.Rows.Count > 0 Then
            Me.Button1_Click(Nothing, Nothing)
            Me.BtSacar_Click(Nothing, Nothing)
        End If
        If Me.cboCarga.SelectedIndex = 0 Then
            fnNroDocumento(8)
            Me.TxtSerie.Enabled = True
            Me.TxtNroGuia.Enabled = True
        Else
            Me.TxtSerie.Text = ""
            Me.TxtNroGuia.Text = ""
            Me.TxtSerie.Enabled = False
            Me.TxtNroGuia.Enabled = False
        End If
    End Sub
End Class