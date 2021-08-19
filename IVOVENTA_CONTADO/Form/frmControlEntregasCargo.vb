Imports INTEGRACION_LN

Public Class frmControlEntregasCargo
    Dim iControlEsquema As Integer = 1
    Public iVerEntrega As Integer = 1
    ' Dim daControl_FAC As New OleDb.OleDbDataAdapter
    Dim dtControl_FAC As New System.Data.DataTable
    Dim dvControl_FAC As System.Data.DataView
    'Dim daControl_ART As New OleDb.OleDbDataAdapter
    'Dim dtControl_ART As New System.Data.DataTable
    Dim dvControl_ART As System.Data.DataView
    Public V_IDESTADO_REGISTRO As Integer = 21
    '17/01/2008 
    Dim dt_estado_registro As New DataTable
    Dim dv_estado_registro As New DataView
    Public Cantidad_total As Long 'Cantidad del documento 
    Public total_ya_entregado As Long
    Dim b_no_lee_campo As Boolean = True
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Dim dtConsignado As DataTable

    Private Property txtDNIEntrega As Object

    'Huella Dactilar
    Dim strArchivo As String
    Dim plantilla() As Byte, parametro() As String
    Dim intCalidad As Integer, intProblema As Integer, strMotivo As String

    Private intTipoComprobante As Integer
    Public Property TipoComprobante() As Integer
        Get
            Return intTipoComprobante
        End Get
        Set(ByVal value As Integer)
            intTipoComprobante = value
        End Set
    End Property
    Private intComprobante As Integer
    Public Property Comprobante() As Integer
        Get
            Return intComprobante
        End Get
        Set(ByVal value As Integer)
            intComprobante = value
        End Set
    End Property

    Private intModo As Integer
    Public Property Modo() As Integer
        Get
            Return intModo
        End Get
        Set(ByVal value As Integer)
            intModo = value
        End Set
    End Property


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Label23.Visible = Not Label23.Visible

    End Sub

    Private Sub frmControlEntregasCargo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmControlEntregasCargo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmControlEntregasCargo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            b_no_lee_campo = False
            'Mod.14/09/2009 -->Omendoza - Pasando al datahelper   
            'ModuUtil.LlenarComboIDs(ObjEntregaCarga.fnLoadTarjetas(), Me.cmbTargeta, ObjEntregaCarga.col_tarjetas, 1)
            'ModuUtil.LlenarComboIDs(ObjEntregaCarga.fnTipoPagos(), Me.cmbTipoPago, ObjEntregaCarga.col_tipo_pago, 1)
            Dim lds_tmp As New DataSet
            lds_tmp = ObjEntregaCarga.fnLoadTarjetas()
            ModuUtil.LlenarComboIDs_dt(lds_tmp.Tables(0), Me.cmbTargeta, ObjEntregaCarga.col_tarjetas, 1)
            ModuUtil.LlenarComboIDs_dt(lds_tmp.Tables(1), Me.cmbTipoPago, ObjEntregaCarga.col_tipo_pago, 1)
            'fnCargar_iWin2(txtiWinAgOrigen, txtiWinAgDestino...)
            'dtHora.Text = fnGetHora()

            dtHora.Value = fnGetHora_()
            'dtHora.Text = fnGetHora_()
            'Mod.14/09/2009 -->Omendoza - Pasando al datahelper   
            'If ObjEntregaCarga.fnLoadDatos(ObjEntregaCarga.IDPK, ObjEntregaCarga.IDDOC) = True Then
            '01-10-2011 hlamas
            If ObjEntregaCarga.fnLoadDatos2(ObjEntregaCarga.IDPK, ObjEntregaCarga.IDDOC) = True Then
                TxtNroDocVenta.Text = ObjEntregaCarga.NRODOC
                txtiWinOrigen.Text = ObjEntregaCarga.Origen
                txtiWinDestino.Text = ObjEntregaCarga.Destino
                txtFechaDoc.Text = ObjEntregaCarga.FECHA
                txtTipoEntrega.Text = ObjEntregaCarga.Tipo_Entrega
                lbDescripcionDoc.Text = ObjEntregaCarga.Tipo_Comprobante
                TxtRuc.Text = ObjEntregaCarga.Nu_Docu_Suna
                TxtRasonSocial.Text = ObjEntregaCarga.Razon_Social
                txtSubCuenta.Text = ObjEntregaCarga.Centro_Costo
                Me.BtnNuevo.Enabled = txtTipoEntrega.Text = "DOMICILIO" 'False 'ObjEntregaCarga.Idtipo_Comprobante = 3

                If ObjEntregaCarga.es_carga_asegurada = 1 Then

                    Me.Timer1.Start()
                Else
                    Me.Timer1.Stop()
                    Label23.Visible = False
                    Me.Timer1.Stop()
                End If
                txtRemitente.Text = ObjEntregaCarga.Remitente
                txtDireccionRemitente.Text = ObjEntregaCarga.REM_Direccion
                txtDestinatario.Text = ObjEntregaCarga.Destinatario
                txtDireccionDestinatario.Text = ObjEntregaCarga.Des_Direccion
                txtFormaPago.Text = ObjEntregaCarga.forma_pago
                txtTarjeta.Text = ObjEntregaCarga.Tarjeta
                txtNroTarjeta.Text = ObjEntregaCarga.Nrotarjeta
                If txtNroTarjeta.Text = "" Or txtNroTarjeta.Text = "0" Then
                    txtNroTarjeta.Visible = False
                Else
                    txtNroTarjeta.Visible = True
                End If
                ' 
                txtCondicion.Text = ObjEntregaCarga.Tipo_Pago
                'Modificado - 23/09/2008 - 
                If txtCondicion.Text = "CREDITO" Then
                    Me.Label15.Visible = False
                    Me.cmbTipoPago.Visible = False
                Else
                    Me.Label15.Visible = True
                    Me.cmbTipoPago.Visible = True
                End If
                '
                txtPorcernt_Descuento.Text = ObjEntregaCarga.Porcent_Descuento
                txtMemo.Text = ObjEntregaCarga.Memo
                txtObs.Text = ObjEntregaCarga.v_Obs
                '
                txtNombreRecojo.Text = IIf(ObjEntregaCarga.Nombre_Entrega.Length > 1, ObjEntregaCarga.Nombre_Entrega, ObjEntregaCarga.Destinatario)
                txtNombreRecojo.SelectAll()
                txtNombreRecojo.Focus()
                '
                If ObjEntregaCarga.IdEstadoEnvio = 21 Or ObjEntregaCarga.IdEstadoEnvio = 68 Then ' Modificado 17/01/2008 - 68 Entrega Parcial 
                    txtFechaEntrega.Text = ObjEntregaCarga.Fecha_Entrega
                    dtHora.Text = ObjEntregaCarga.Hora_Entrega
                    txtFechaEntrega.Visible = True
                    dtHora.Visible = True
                ElseIf ObjEntregaCarga.IdEstadoEnvio <> 20 Then
                    txtFechaEntrega.Visible = False
                    dtHora.Visible = False
                End If
                '
                dtFecha.Text = ObjEntregaCarga.Fecha_Entrega
                '
                txtNroDNI.Text = IIf(ObjEntregaCarga.Doc_Entrega.Length > 1, ObjEntregaCarga.Doc_Entrega, "")
                lbEstadoRegistro.Text = ObjEntregaCarga.EstadoEnvio
                txtMontoPago.Text = ObjEntregaCarga.Total_Costo
                txtNroTarjetaPago.Text = ObjEntregaCarga.Nrotarjeta
                fnControlGrid()
                '
                DataGridViewDatos(2, 0).Value = IIf(ObjEntregaCarga.Cantidad_x_Peso > 0, ObjEntregaCarga.Cantidad_x_Peso, "")
                DataGridViewDatos(4, 0).Value = IIf(ObjEntregaCarga.Total_Peso > 0, ObjEntregaCarga.Total_Peso, "")
                DataGridViewDatos(5, 0).Value = ObjEntregaCarga.Precio_x_Peso
                DataGridViewDatos(6, 0).Value = "0.00"
                DataGridViewDatos(7, 0).Value = Format(ObjEntregaCarga.Total_Peso * ObjEntregaCarga.Precio_x_Peso, "###,###,###.00")
                '
                DataGridViewDatos(2, 1).Value = IIf(ObjEntregaCarga.Cantidad_x_Volumen > 0, ObjEntregaCarga.Cantidad_x_Volumen, "")
                DataGridViewDatos(4, 1).Value = IIf(ObjEntregaCarga.Total_Volumen > 0, ObjEntregaCarga.Total_Volumen, "")
                DataGridViewDatos(5, 1).Value = ObjEntregaCarga.Precio_x_Volumen
                DataGridViewDatos(6, 1).Value = "0.00"
                DataGridViewDatos(7, 1).Value = Format(ObjEntregaCarga.Total_Volumen * ObjEntregaCarga.Precio_x_Volumen, "###,###,###.00")
                '
                DataGridViewDatos(2, 2).Value = IIf(ObjEntregaCarga.Cantidad_x_Sobre > 0, ObjEntregaCarga.Cantidad_x_Sobre, "")
                DataGridViewDatos(4, 2).Value = " "
                DataGridViewDatos(5, 2).Value = ObjEntregaCarga.Precio_x_Sobre
                DataGridViewDatos(6, 2).Value = "0.00"
                DataGridViewDatos(7, 2).Value = Format(ObjEntregaCarga.Cantidad_x_Sobre * ObjEntregaCarga.Precio_x_Sobre, "###,###,###.00")
                '
                DataGridViewDatos(2, 3).Value = " "
                DataGridViewDatos(4, 3).Value = " "
                DataGridViewDatos(5, 3).Value = " "
                DataGridViewDatos(6, 3).Value = "0.00"
                DataGridViewDatos(7, 3).Value = IIf(ObjEntregaCarga.Monto_Base > 0, ObjEntregaCarga.Monto_Base, "")
                txtMontoPago.Text = ObjEntregaCarga.Total_Costo
                '
                dtControl_FAC.Clear()
                DataGridViewDoc.Refresh()
                'daControl_FAC.Fill(dtControl_FAC, ObjEntregaCarga.cur_Documentos)
                'dvControl_FAC = dtControl_FAC.DefaultView
                dvControl_FAC = ObjEntregaCarga.dt_cur_Documentos.DefaultView
                DataGridViewDoc.DataSource = dvControl_FAC
                DataGridViewDoc.Refresh()
                '
                'If ObjEntregaCarga.IDPK = 2 Then
                If Int(ObjEntregaCarga.Cantidad_x_Articulos) > 0 Then
                    DataGridViewArticulos.Visible = True
                    DataGridViewDatos.Visible = False
                    'dtControl_ART.Clear()
                    DataGridViewArticulos.Refresh()
                    'daControl_ART.Fill(dtControl_ART, ObjEntregaCarga.cur_Articulos)
                    'dvControl_ART = dtControl_ART.DefaultView
                    'daControl_ART.Fill(dtControl_ART, ObjEntregaCarga.cur_Articulos)
                    dvControl_ART = ObjEntregaCarga.dt_cur_Articulos.DefaultView
                    '
                    DataGridViewArticulos.DataSource = dvControl_ART
                    DataGridViewArticulos.Refresh()
                End If
                '17/01/2008  Modificado 
                'ModuUtil.LlenarComboIDs(ObjEntregaCarga.cur_Estados_Entrega, cmbEstadoRegistro, ObjEntregaCarga.col_Estados_Entrega, 21)
                'daControl_FAC.Fill(dt_estado_registro, ObjEntregaCarga.cur_Estados_Entrega)
                'dv_estado_registro = CargarCombo(Me.cmbEstadoRegistro, dt_estado_registro, "Estado_Registro", "Idestado_Registro", 21)
                dv_estado_registro = CargarCombo(Me.cmbEstadoRegistro, ObjEntregaCarga.dt_cur_Estados_Entrega, "Estado_Registro", "Idestado_Registro", 21)
                '
                Dim iConsignado As Integer = ObjEntregaCarga.Consignado
                dtConsignado = ObjEntregaCarga.dtConsignado
                Me.CargarConsignado(dtConsignado, iConsignado)

                If iVerEntrega = 2 Then
                    'ModuUtil.LlenarComboIDs(ObjEntregaCarga.cur_Estados_Entrega, cmbEstadoRegistro, ObjEntregaCarga.col_Estados_Entrega, 21)
                    cmbEstadoRegistro.Enabled = False
                    cmbEstadoRegistro.Visible = True
                    Me.lbEstadoEnvio.Visible = True
                    txtObs.Enabled = True
                Else
                    'ModuUtil.LlenarComboIDs(ObjEntregaCarga.cur_Estados_Entrega, cmbEstadoRegistro, ObjEntregaCarga.col_Estados_Entrega, ObjEntregaCarga.IdEstadoEnvio)
                    cmbEstadoRegistro.Enabled = False
                    cmbEstadoRegistro.Visible = False
                    Me.lbEstadoEnvio.Visible = False
                    Me.txt_por_entregar.Enabled = False
                End If
            Else
                MsgBox("No Existen Datos para esta Busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            If iVerEntrega = 2 Then
                btnAceptar.Enabled = True
                txtNombreRecojo.Enabled = True
                txtNroTarjetaPago.Enabled = True
                'txtNroDNI.Enabled = True
                cmbTipoPago.Enabled = True
                cmbTargeta.Enabled = True
                dtHora.Enabled = True
                dtFecha.Enabled = True
                txtFechaEntrega.Enabled = True
            End If

            If iVerEntrega = 10 Then
                txtFechaDoc.Enabled = True
                txtFechaDoc.ReadOnly = False
                txtMontoPago.Enabled = True
                txtMontoPago.ReadOnly = False
                btnAceptar.Enabled = True
            End If
            '
            ''Modificado el 15/01/2008
            Cantidad_total = ObjEntregaCarga.l_cantidad_total
            total_ya_entregado = ObjEntregaCarga.l_entregado
            Me.txt_por_entregar.Text = CType(Cantidad_total - total_ya_entregado, String)     '  "0" ' ObjEntregaCarga.l_entregado
            Me.txt_piezas_ya_entregadas.Text = ObjEntregaCarga.l_entregado
            If ObjEntregaCarga.l_por_entregar = 0 Then ' Entregado total 
                Me.txt_por_entregar.Visible = False
                Me.txt_piezas_ya_entregadas.Visible = False
                Me.lab_pieza_a_entregar.Visible = False
                Me.lab_pieza_entregadas.Visible = False
            Else
                Me.txt_por_entregar.Visible = True
                Me.txt_piezas_ya_entregadas.Visible = True
                Me.lab_pieza_a_entregar.Visible = True
                Me.lab_pieza_entregadas.Visible = True
            End If
            '
            'If ObjEntregaCarga.IdEstadoEnvio <> 50 Or ObjEntregaCarga.IdEstadoEnvio <> 21 Then
            '    txtNombreRecojo.Text = ""
            '    txtFechaEntrega.Text = ""
            'End If
            If ObjEntregaCarga.IDPK = 2 Then
                Me.Label19.Visible = True
                Me.txtSubCuenta.Visible = True
            Else
                Me.Label19.Visible = False
                Me.txtSubCuenta.Visible = False
            End If
            b_no_lee_campo = True

            ActivarDesactivar()
            'huella
            If dtoUSUARIOS.huella = 1 Then
                Me.grbHuella.Visible = True
                Try
                    CargarHuella()
                Catch ex As Exception
                End Try
            Else
                Me.grbHuella.Visible = False
            End If

            'verifica si lector de huellas es reconocido por sistema operativo
            Dim obj As New Huella
            Try
                Dim lista As ArrayList = obj.ObtenerDispositivo()
                If lista.Count > 0 Then
                    Me.lblDispositivo.Text = "Dispositivo Listo"
                Else
                    Me.lblDispositivo.Text = "No se encontró Dispositivo"
                End If
            Catch
                Me.lblDispositivo.Text = "No se encontró Dispositivo"
            Finally
                obj = Nothing
            End Try

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Public Function fnControlGrid() As Boolean
        Try
            With DataGridViewDatos
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
            DataGridViewDatos.Columns.Add(col)
            Dim col0 As New DataGridViewTextBoxColumn
            With col0
                .DisplayIndex = 1
                .DataPropertyName = "TIPO PROCESO"
                .HeaderText = "TIPO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            DataGridViewDatos.Columns.Add(col0)

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
                .ReadOnly = True
            End With
            DataGridViewDatos.Columns.Add(col2)

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
            DataGridViewDatos.Columns.Add(col01)

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
                .ReadOnly = True
            End With
            DataGridViewDatos.Columns.Add(col1)
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
            End With
            DataGridViewDatos.Columns.Add(col31)
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
            DataGridViewDatos.Columns.Add(col3)

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
            End With
            DataGridViewDatos.Columns.Add(col4)

            Dim row0 As String() = {"", "PESO", "", "BULTOS", "", "0.00", "0.00", "0.00"}
            DataGridViewDatos.Rows().Add(row0)
            Dim row1 As String() = {"", "VOLUMEN", "", "BULTOS", "", "0.00", "0.00", "0.00"}
            DataGridViewDatos.Rows().Add(row1)
            Dim row2 As String() = {"", "SOBRE", "", "", "", "0.00", "0.00", "0.00"}
            DataGridViewDatos.Rows().Add(row2)
            Dim row3 As String() = {"", "BASE", "", "", "", "0.00", "0.00", "0.00"}
            DataGridViewDatos.Rows().Add(row3)


            With DataGridViewDoc
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
                .DataPropertyName = "Nro_Serie"
                .HeaderText = "SERIE"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DataGridViewDoc.Columns.Add(col_1)

            Dim col_2 As New DataGridViewTextBoxColumn
            'Dim col_2 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            With col_2
                .DisplayIndex = 1
                .DataPropertyName = "Nro_Docu"
                .HeaderText = "NRO GUIA"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '  .Mask = "###-########"
                '.DefaultCellStyle.NullValue = "-"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With
            DataGridViewDoc.Columns.Add(col_2)
            'Dim row4 As String() = {"", "SUB TOTAL", "", "", "", "0.00", "0.00", "0.00"}
            'DataGridViewDatos.Rows().Add(row4)
            'Dim row5 As String() = {"", "TOTAL COSTO", "", "", "", "0.00", "0.00", "0.00"}
            'DataGridViewDatos.Rows().Add(row5)
        Catch ex As Exception

        End Try
    End Function

    Private Sub cmbTipoPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoPago.SelectedIndexChanged
        Try
            Dim varIdCondicion As Integer = Int(ObjEntregaCarga.col_tipo_pago.Item(cmbTipoPago.SelectedIndex.ToString()))
            If varIdCondicion = 2 Then
                Label13.Visible = True
                lbNrotarjeta.Visible = True
                cmbTargeta.Visible = True
                txtNroTarjeta.Visible = True
                txtNroTarjetaPago.Visible = True
            Else
                Label13.Visible = False
                lbNrotarjeta.Visible = False
                cmbTargeta.Visible = False
                txtNroTarjeta.Visible = False
                txtNroTarjetaPago.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Try
            Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridasd Sistena")
        End Try
    End Sub

    Private Sub fnGrabar()
        Try

            If btnAceptar.Enabled = False Then
                MsgBox("No se puede Realizar está Operación....", MsgBoxStyle.Information, "Seguridad Sistema")
                ' Return
                Exit Sub
            End If

            If txtNroDNI.Text = "" Then
                ErrorProvider.SetError(txtNombreRecojo, "Debe Registrar la Persona que se le entrega el/los bulto(s)..")
                MsgBox("Se debe registrar el DNI  de la persona que se le está entregando el/los bulto(s)...", MsgBoxStyle.Information, "Seguridad Sistema...")
                txtNroDNI.Focus()
                Exit Sub
            End If
            If txtNombreRecojo.Text = "" Then
                MsgBox("Se debe registrar el nombre completo de la persona que se le está entregando el/los bulto(s)...", MsgBoxStyle.Information, "Seguridad Sistema...")
                txtNombreRecojo.Focus()
                Exit Sub
            End If

            If valida_fecha_entrega() = False Then
                Exit Sub
            End If
            ' txtNombreRecojo.Focus()
            ' Return

            '17/01/2008 - Validando que halla ingresado el monto de entrega 
            If Me.txt_por_entregar.Text = "0" Then
                MsgBox("Se debe ingresar el nº de pieza(s) a entregar...", MsgBoxStyle.Information, "Sistema de Seguridad...")
                Me.txt_por_entregar.Focus()
                Exit Sub
            End If
            '
            'huella
            If dtoUSUARIOS.huella = 1 Then
                'If dtoUSUARIOS.IP = "192.168.50.218" Or dtoUSUARIOS.IP = "192.168.50.213" Or dtoUSUARIOS.IP = "192.168.50.47" Then
                If Me.picHuella.Image Is Nothing Then
                    MessageBox.Show("Ingrese Huella del Consignado", "Confirmación Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnAgregarHuella.Focus()
                    'blnSalir = False
                    Return
                End If
            End If

            ObjEntregaCarga.x_iControl = ObjEntregaCarga.IDPK ' Si es Boleta o facturas/Boletas
            ObjEntregaCarga.x_idDOC_VENTA = ObjEntregaCarga.IDDOC  ' IdDel Documento
            '
            ObjEntregaCarga.x_idtargeta = Int(ObjEntregaCarga.col_tarjetas.Item(cmbTargeta.SelectedIndex.ToString))
            ObjEntregaCarga.x_idTipoDocumento = Int(ObjEntregaCarga.col_tipo_pago.Item(cmbTipoPago.SelectedIndex.ToString))
            ObjEntregaCarga.x_Nrotarjeta = IIf(txtNroTarjetaPago.Text <> "", txtNroTarjetaPago.Text, "NULL")
            If ObjEntregaCarga.x_idTipoDocumento = 1 Then
                ObjEntregaCarga.x_idtargeta = -666
                ObjEntregaCarga.x_Nrotarjeta = "NULL"
            End If
            '
            ObjEntregaCarga.x_NOMBRES = IIf(txtNombreRecojo.Text <> "", txtNombreRecojo.Text, "NULL")
            ObjEntregaCarga.x_DOC_ENTREGA = IIf(txtNroDNI.Text <> "", txtNroDNI.Text, "NULL")
            ObjEntregaCarga.x_IP = dtoUSUARIOS.IP
            ObjEntregaCarga.x_IDROL_USUARIO = dtoUSUARIOS.IdRol
            ObjEntregaCarga.x_Idusuario_Personal = dtoUSUARIOS.IdLogin
            ObjEntregaCarga.x_FECHA_ENTREGA = dtFecha.Text
            ObjEntregaCarga.x_FECHA_ENTREGA = txtFechaEntrega.Text
            ObjEntregaCarga.x_HORA_ENTREGA = dtHora.Text
            ObjEntregaCarga.v_Obs = IIf(txtObs.Text <> "", txtObs.Text, "NULL")
            ' 
            ObjEntregaCarga.l_idagencia = ObjEntregaCarga.l_idagencia_destino     'dtoUSUARIOS.m_iIdAgencia
            ObjEntregaCarga.l_entregado = CType(Me.txt_por_entregar.Text, Long)
            '
            'ModuUtil.LlenarComboIDs(ObjEntregaCarga.cur_Estados_Entrega, cmbEstadoRegistro, ObjEntregaCarga.col_Estados_Entrega, 21)
            '17/01/2008
            'Dim vx_idEstadoRegistro As Integer = Int(ObjEntregaCarga.col_Estados_Entrega.Item(cmbEstadoRegistro.SelectedIndex.ToString()))
            Dim vx_idEstadoRegistro As Integer = CType(Me.cmbEstadoRegistro.SelectedValue, Long)
            '
            Cantidad_total = ObjEntregaCarga.l_cantidad_total
            Dim ll_tot_entregados As Long
            '
            ll_tot_entregados = CType(Me.txt_por_entregar.Text, Long) + CType(Me.txt_piezas_ya_entregadas.Text, Long)
            '
            'If CType(Me.txt_piezas_ya_entregadas.Text, Long) = 0 Then
            'vx_idEstadoRegistro = 21
            'Else
            'vx_idEstadoRegistro = 68 'Entrega parcial al cliente 
            'End If
            '
            vx_idEstadoRegistro = Me.cmbEstadoRegistro.SelectedValue  ' 21/01/2008 
            '
            If ObjEntregaCarga.fnINSERTAR_ENTREGA_CLIENTES(vx_idEstadoRegistro) = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                V_IDESTADO_REGISTRO = vx_idEstadoRegistro
                '
                Try
                    'ObjWebService.fnWebService(ObjEntregaCarga.x_idTipoDocumento, ObjEntregaCarga.x_idDOC_VENTA, V_IDESTADO_REGISTRO)
                Catch ex As Exception
                End Try
                '
                'huella
                If dtoUSUARIOS.huella = 1 Then
                    'If dtoUSUARIOS.IP = "192.168.50.218" Or dtoUSUARIOS.IP = "192.168.50.213" Or dtoUSUARIOS.IP = "192.168.50.47" Then
                    GrabarHuella()
                End If

                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    'Private Sub DatosPersonalesboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreRecojo.KeyPress
    '    Try
    '        Dim tb As TextBox = CType(sender, TextBox)
    '        If Not IsNumeric(e.KeyChar) And Char.IsLetter(e.KeyChar) Then
    '            e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
    '        ElseIf e.KeyChar = " " Then
    '            If tb.Text.Substring(tb.Text.Length() - 1) = " " Then
    '                e.Handled = True
    '            Else
    '                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
    '            End If
    '        ElseIf e.KeyChar = "." Then
    '            If tb.Text.Substring(tb.Text.Length() - 1) = "." Then
    '                e.Handled = True
    '            Else
    '                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
    '            End If
    '        ElseIf e.KeyChar = "," Then
    '            If tb.Text.Substring(tb.Text.Length() - 1) = "," Then
    '                e.Handled = True
    '            Else
    '                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
    '            End If
    '        ElseIf e.KeyChar = "@" Then
    '            If tb.Text.Substring(tb.Text.Length() - 1) = "@" Then
    '                e.Handled = True
    '            Else
    '                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
    '            End If
    '        ElseIf e.KeyChar = "&" Then
    '            If tb.Text.Substring(tb.Text.Length() - 1) = "&" Then
    '                e.Handled = True
    '            Else
    '                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
    '            End If
    '        ElseIf e.KeyChar = "-" Then
    '            If tb.Text.Substring(tb.Text.Length() - 1) = "-" Then
    '                e.Handled = True
    '            Else
    '                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
    '            End If
    '        ElseIf e.KeyChar = "'" Then
    '            e.Handled = True
    '        ElseIf Not Char.IsControl(e.KeyChar) Then
    '            e.Handled = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
    '    End Try
    'End Sub
    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDNI.KeyPress, txtNroTarjetaPago.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                'ElseIf e.KeyChar = "." Then
                'If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                'e.Handled = True
                'End If
                'ElseIf e.KeyChar = "-" Then
                'If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                'e.Handled = True
                'End If
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32

            If msg.WParam.ToInt32 = Keys.Escape Then
                Close()
            ElseIf msg.WParam.ToInt32 = Keys.Enter Then
                If txtNombreRecojo.Focused = True Then
                    txtNroDNI.Focus()
                    txtNroDNI.SelectAll()
                ElseIf txtNroDNI.Focused = True Then
                    txtFechaEntrega.Focus()
                    txtFechaEntrega.SelectAll()
                ElseIf txtFechaEntrega.Focused = True Then
                    dtHora.Focus()
                ElseIf dtHora.Focused = True Then
                    btnAceptar.Focus()
                ElseIf btnAceptar.Focused = True Then
                    If iVerEntrega = 10 Then
                        ObjVentaCargaContado.fnUPDCARGA_CONTADO(ObjEntregaCarga.IDDOC.ToString(), txtFechaDoc.Text.ToString(), txtMontoPago.Text.ToString())
                    Else
                        fnGrabar()
                    End If
                ElseIf btnSalir.Focused = True Then
                    Close()
                Else
                    SendKeys.Send("{Tab}")
                End If

            ElseIf msg.WParam.ToInt32 = Keys.F1 Then
                If Me.btnVerCheckPoint.Enabled Then
                    VerCheckPoint()
                End If
                'Dim ObjCheckPoint As New FrmCheckPoint
                ''ObjCheckPoint.ShowDialog()

                'Acceso.Asignar(ObjCheckPoint, Me.hnd)
                'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                '    ObjCheckPoint.ShowDialog()
                'Else
                '    MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If
                'ObjCheckPoint = Nothing
            ElseIf msg.WParam.ToInt32 = Keys.F3 Then
                txtNombreRecojo.SelectAll()
                txtNombreRecojo.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F4 Then
                txtNroDNI.Focus()
                txtNroDNI.SelectAll()
            ElseIf msg.WParam.ToInt32 = Keys.F8 Then
                txtFechaEntrega.Focus()
                txtFechaEntrega.SelectAll()
            ElseIf msg.WParam.ToInt32 = Keys.F9 Then
                dtHora.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                'cambio tecla funcion
                If Me.btnAceptar.Enabled Then
                    Me.Aceptar()
                End If
                'If iVerEntrega = 10 Then
                '    ObjVentaCargaContado.fnUPDCARGA_CONTADO(ObjEntregaCarga.IDDOC.ToString(), txtFechaDoc.Text.ToString(), txtMontoPago.Text.ToString())
                'Else
                '    fnGrabar()
                'End If
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
            objGuiaEnvio.iCONTROL = 1
        End Try
        Return flat
    End Function
    Private Sub DatosPersonalesboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreRecojo.KeyPress ', txtObs.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            If Not IsNumeric(e.KeyChar) And Char.IsLetter(e.KeyChar) Then
                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
            ElseIf e.KeyChar = " " Then
                If tb.Text.Substring(tb.Text.Length() - 1) = " " Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "." Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "." Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
                'ElseIf e.KeyChar = "," Then
                '    If tb.Text.Substring(tb.Text.Length() - 1) = "," Then
                '        e.Handled = True
                '    Else
                '        e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                '    End If
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
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub dtFecha_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtFecha.Validating
        valida_fecha_entrega()
    End Sub

    Private Sub dtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFecha.ValueChanged
        Try
            '
            txtFechaEntrega.Text = dtFecha.Text
            '
        Catch ex As Exception

        End Try
    End Sub


    Private Sub dtHora_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtHora.ValueChanged

    End Sub

    Private Sub txt_por_entregar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_por_entregar.TextChanged
        Dim ll_por_entregar As Long
        Try
            If b_no_lee_campo = True Then
                If Me.txt_por_entregar.Text = "" Or Me.txt_por_entregar.Text = " " Then
                    Me.txt_por_entregar.Text = 0
                End If
                'll_por_entregar = Cantidad_total - CType(Me.txt_por_entregar.Text, Long) - total_ya_entregado
                ll_por_entregar = CType(Me.txt_por_entregar.Text, Long) + total_ya_entregado
                '
                Me.txt_piezas_ya_entregadas.Text = CType(ll_por_entregar, String)
                '
                If Cantidad_total - CType(Me.txt_piezas_ya_entregadas.Text, Long) < 0 Then
                    txt_por_entregar.Text = "0"
                    Me.txt_piezas_ya_entregadas.Text = CType(total_ya_entregado, String)
                    MsgBox("No puede entregar  más de " + CType(Cantidad_total - total_ya_entregado, String) + " bulto(s) ", MsgBoxStyle.Information, "Control de Entrega")
                    txt_por_entregar.Focus()
                    Exit Sub
                End If
                '
                If Cantidad_total - CType(Me.txt_piezas_ya_entregadas.Text, Long) = 0 Then
                    Me.cmbEstadoRegistro.SelectedValue = 21 ' Entrega total
                Else
                    Me.cmbEstadoRegistro.SelectedValue = 68 ' Entrega Parcial 
                End If
                '
                Me.lbEstadoRegistro.Text = Me.cmbEstadoRegistro.Text
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub txtFechaEntrega_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaEntrega.Leave
        '   valida_fecha_entrega()
    End Sub
    Private Sub txtFechaEntrega_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaEntrega.TextChanged
        'valida_fecha_entrega()
    End Sub

    Private Sub txtFechaEntrega_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaEntrega.Validated
        'valida_fecha_entrega()
        'Dim ll_anio As Long
        'Dim ld_fecha As Date
        'Try
        '    ll_anio = CType(Mid(txtFechaEntrega.Text, 7, 4), Long)
        '    If ll_anio < 2006 Then
        '        MsgBox("Año no valido ingrese la fecha de entrega, verificar fecha", MsgBoxStyle.Exclamation, "Entrega de bultos")
        '        Me.txtFechaEntrega.Text = dtoUSUARIOS.dfecha_sistema
        '        Me.txtFechaEntrega.Focus()
        '        Exit Sub
        '    End If
        '    Try
        '        ld_fecha = CType(txtFechaEntrega.Text, Date)
        '    Catch ex As Exception
        '        MsgBox("Fecha de entrega no válido, verificar fecha", MsgBoxStyle.Exclamation, "Entrega de bultos")
        '        Me.txtFechaEntrega.Text = dtoUSUARIOS.dfecha_sistema
        '        Me.txtFechaEntrega.Focus()
        '        Exit Sub
        '    End Try
        '    If ld_fecha < CType(txtFechaDoc.Text, Date) Then
        '        MsgBox("Fecha de entrega no puede ser menor a la fecha del documento, verificar fecha", MsgBoxStyle.Exclamation, "Entrega de bultos")
        '        Me.txtFechaEntrega.Text = dtoUSUARIOS.dfecha_sistema
        '        Me.txtFechaEntrega.Focus()
        '        Exit Sub
        '    End If
        'Catch ex As Exception
        '    '
        'End Try
    End Sub
    Function valida_fecha_entrega() As Boolean
        Dim ll_anio As Long
        Dim ld_fecha As Date
        Try
            ll_anio = CType(Mid(txtFechaEntrega.Text, 7, 4), Long)
            If ll_anio < 1996 Then
                MsgBox("Año no valido ingrese la fecha de entrega, verificar fecha", MsgBoxStyle.Exclamation, "Entrega de bultos")
                Me.txtFechaEntrega.Text = dtoUSUARIOS.dfecha_sistema
                Me.txtFechaEntrega.Focus()
                Return False
            End If
            Try
                ld_fecha = CType(txtFechaEntrega.Text, Date)
            Catch ex As Exception
                MsgBox("Fecha de entrega no válido, verificar fecha", MsgBoxStyle.Exclamation, "Entrega de bultos")
                Me.txtFechaEntrega.Text = dtoUSUARIOS.dfecha_sistema
                Me.txtFechaEntrega.Focus()
                Return False
            End Try
            If ld_fecha < CType(txtFechaDoc.Text, Date) Then
                MsgBox("Fecha de entrega no puede ser menor a la fecha del documento, verificar fecha", MsgBoxStyle.Exclamation, "Entrega de bultos")
                Me.txtFechaEntrega.Text = dtoUSUARIOS.dfecha_sistema
                Me.txtFechaEntrega.Focus()
                Return False
            End If
            If ld_fecha > CType(dtoUSUARIOS.dfecha_sistema, Date) Then
                MsgBox("Fecha de entrega no puede ser mayor a la fecha actual, verificar fecha", MsgBoxStyle.Exclamation, "Entrega de bultos")
                Me.txtFechaEntrega.Text = dtoUSUARIOS.dfecha_sistema
                Me.txtFechaEntrega.Focus()
                Return False
            End If
            '
            Return True
        Catch ex As Exception
            Me.txtFechaEntrega.Text = dtoUSUARIOS.dfecha_sistema
            Me.txtFechaEntrega.Focus()
            Return False
        End Try
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Aceptar()
        'If iVerEntrega = 10 Then
        '    ObjVentaCargaContado.fnUPDCARGA_CONTADO(ObjEntregaCarga.IDDOC.ToString(), txtFechaDoc.Text.ToString(), txtMontoPago.Text.ToString())
        'Else
        '    fnGrabar()
        'End If
    End Sub

    Private Sub btnVerCheckPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerCheckPoint.Click
        Me.VerCheckPoint()
    End Sub

    Sub VerCheckPoint()
        Try
            Dim ObjCheckPoint As New FrmCheckPoint
            'ObjCheckPoint.ShowDialog()

            Acceso.Asignar(ObjCheckPoint, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                ObjCheckPoint.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ObjCheckPoint = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Sub CargarConsignado(ByVal dt As DataTable, ByVal consignado As Integer)
        With Me.CboConsignado
            .DataSource = dt
            .ValueMember = "id_consignado"
            .DisplayMember = "nombres"
            .SelectedValue = consignado
        End With
    End Sub

    Private Sub CboConsignado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboConsignado.SelectedIndexChanged
        If Not IsReference(Me.CboConsignado.SelectedValue) Then
            If CboConsignado.SelectedValue = 0 Then
                Me.txtNombreRecojo.Text = ""
                Me.txtNroDNI.Text = ""
                Me.txtNroDNI.Enabled = False
                Me.btnAgregarHuella.Enabled = False
            Else
                Me.txtNombreRecojo.Text = CboConsignado.Text
                Me.txtNroDNI.Text = dtConsignado.Rows(CboConsignado.SelectedIndex).Item(2).ToString.Trim
                Me.txtNroDNI.Enabled = True
            End If
        Else
            Me.txtNombreRecojo.Text = ""
            Me.txtNroDNI.Text = ""
        End If
    End Sub

    Function Validar() As Boolean
        If Me.CboConsignado.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Consignado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboConsignado.Focus()
            Return False
        End If

        If Me.txtNroDNI.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Nº de Documento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNroDNI.Text = ""
            Me.txtNroDNI.Focus()
            Return False
        End If

        If Me.txtNroDNI.Text.Trim.Length < 8 Then
            MessageBox.Show("Ingrese Nº de Documento", "Confirmación Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNroDNI.Text = ""
            Me.txtNroDNI.Focus()
            Return False
        End If

        'Valida si comprobante tiene alguna solicitud pendiente o aprobada
        Dim obj As New Cls_FacturaAdicional_LN
        Dim strTipoOperacion As String = obj.ComprobanteOperacion(ObjEntregaCarga.IDDOC)
        If strTipoOperacion.Trim.Length > 0 Then
            If strTipoOperacion.Trim <> "x" Then
                MessageBox.Show("El Comprobante tiene una solicitud pendiente por " & Chr(13) & strTipoOperacion, "Confirmación Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If

        Return True
    End Function

    Sub Aceptar()
        If iVerEntrega = 10 Then
            ObjVentaCargaContado.fnUPDCARGA_CONTADO(ObjEntregaCarga.IDDOC.ToString(), txtFechaDoc.Text.ToString(), txtMontoPago.Text.ToString())
        Else
            If Not Validar() Then
                Return
            End If

            fnGrabar()
        End If
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dim frm As New FrmConsignadoNuevo
        Acceso.Asignar(frm, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then

            '***CambioR*****************************************
            Dim IDConsignado As String = ""
            dtConsignado = ObjEntregaCarga.dtConsignado
            'For i As Integer = 1 To dtConsignado.Rows.Count - 1
            '    IDConsignado &= dtConsignado.Rows(i)(0) & ";"
            'Next

            'For Each fila As DataRow In dtConsignado.Rows
            '    IDConsignado &= fila.Item(0) & ";"
            'Next
            frm.IDPersona = ObjEntregaCarga.c_idpersona
            frm.IDUnidadDestino = ObjEntregaCarga.l_idagencia_destino 'obj.l_idagencia_destino 
            'frm.IDConsignado = IDConsignado
            frm.IDComprobante = ObjEntregaCarga.IDComprobante
            frm.IDTipoComprobante = ObjEntregaCarga.Idtipo_Comprobante
            '***Fin Cambio***************************************
            frm.ShowDialog()

            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                Dim iControl As Integer
                If ObjEntregaCarga.Idtipo_Comprobante = 3 Then
                    iControl = 2
                Else
                    iControl = 1
                End If
                Dim obj As New dtoVentaCargaContado
                Dim dt As DataTable = obj.ListaConsignado(iControl, ObjEntregaCarga.IDComprobante)
                dtConsignado = dt
                With CboConsignado
                    .DataSource = dt
                    .DisplayMember = "nombres"
                    .ValueMember = "id_consignado"
                End With
            End If
        Else
            MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtObs_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtObs.TextChanged

    End Sub

    Private Sub txtNroDNI_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNroDNI.TextChanged
        'huella
        If dtoUSUARIOS.huella = 1 Then
            Dim intLongitud As Integer = Me.txtNroDNI.Text.Trim.Length
            If intLongitud = 8 Then
                Me.btnAgregarHuella.Enabled = True
            Else
                Me.btnAgregarHuella.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnAgregarHuella_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarHuella.Click
        Dim frm As New frmHuella
        frm.NumeroDocumento = Me.txtNroDNI.Text.Trim
        frm.Consignado = Me.CboConsignado.Text
        frm.Monto = Me.txtMontoPago.Text
        frm.Seguro = 0
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.picHuella.Image = frm.imagen2
            Me.picHuella.SizeMode = PictureBoxSizeMode.StretchImage
            Me.plantilla = frm.plantilla
            Me.parametro = frm.aParametro
            Me.intCalidad = frm.intCalidadHuella
            Me.intProblema = frm.intProblema
            Me.strMotivo = frm.strMotivo
            If Me.picHuella Is Nothing Then
                Me.btnVerHuella.Enabled = False
            Else
                Me.btnVerHuella.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnVerHuella_Click(sender As System.Object, e As System.EventArgs) Handles btnVerHuella.Click
        Try
            Dim frm As New frmVerHuella
            frm.imagen = picHuella.Image
            frm.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Sub GrabarHuella()
        Dim huella As New Huella
        'Dim img As Image = Me.picHuella.Image
        'Dim ms As New MemoryStream
        'Dim img2 As Image = img.Clone
        'img2.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        'img2.Dispose()
        'Dim m() As Byte
        'm = ms.ToArray
        'ms.Close()
        'ms.Dispose()

        'Dim strArchivo As String = parametro(10)
        'Dim intCompresion As Integer = parametro(11)
        'SaveJPGWithCompressionSetting(img, strArchivo, intCompresion)

        'Dim size As Long
        'size = New FileInfo(strArchivo).Length
        'Dim fs As FileStream
        'fs = New FileStream(strArchivo, FileMode.Open)
        'Dim imagen() As Byte
        'ReDim imagen(size)
        'fs.Read(imagen, 0, size)
        'fs.Close()
        'fs.Dispose()

        strMotivo = IIf(strMotivo Is Nothing, "", strMotivo)
        huella.GrabarHuella(TipoComprobante, Comprobante, Me.txtNroDNI.Text.Trim, plantilla, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, intCalidad, intProblema, strMotivo, 1)
    End Sub

    Sub CargarHuella()
        Dim imagen() As Byte
        Dim huella As New Huella

        huella.CargarHuella(TipoComprobante, Comprobante, imagen)
        If imagen Is Nothing Then
            Me.picHuella.Image = Nothing
            plantilla = Nothing
            Me.btnVerHuella.Enabled = False
        Else
            huella.MostrarHuella(imagen, Me.picHuella, 2, 120000)
        End If

        Me.picHuella.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Sub ActivarDesactivar()
        If Modo = 1 Then
            Me.btnAgregarHuella.Visible = False
            Me.btnVerHuella.Left = 60
            Me.btnAceptar.Enabled = False
            'Me.lblCantidadEntregar.Visible = False
            'Me.txtCantidadEntregar.Visible = False
            'Me.grbEntrega.Enabled = False
        End If
    End Sub
End Class