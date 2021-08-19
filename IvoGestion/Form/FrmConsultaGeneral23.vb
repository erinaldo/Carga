Public Class FrmConsultaGeneral2
    Public hnd As Long
    Dim objConsultaGeneral As dtoConsultaGeneral2
    Dim coll_Lista_Personas As New Collection
    Dim coll_Remitente As New Collection
    Dim coll_Direccion1 As New Collection
    Dim coll_Consignado As New Collection
    Dim coll_Direccion2 As New Collection
    Dim coll_Contacto As New Collection
    Dim coll_Usuarios As New Collection

    'para ruc y razon social de cliente
    Public iWinPerosa As New AutoCompleteStringCollection
    Public iWinPerosaRUC As New AutoCompleteStringCollection

    'para remitentes de cliente
    Public iWinRemitente As New AutoCompleteStringCollection
    Public iWinRemitente2 As New AutoCompleteStringCollection

    'para direcciones de cliente
    Public iWinDireccion1 As New AutoCompleteStringCollection
    Public iWinDireccion11 As New AutoCompleteStringCollection

    'para consignados de cliente
    Public iWinConsignado As New AutoCompleteStringCollection
    Public iWinConsignado2 As New AutoCompleteStringCollection

    'para direcciones de cliente
    Public iWinDireccion2 As New AutoCompleteStringCollection
    Public iWinDireccion22 As New AutoCompleteStringCollection

    'para contactos de cliente
    Public iWinContacto As New AutoCompleteStringCollection
    Public iWinContacto2 As New AutoCompleteStringCollection

    Dim coll_Tipo_Facturacion As New Collection
    Dim coll_Tipo_Entrega As New Collection
    Dim coll_Unidad_Agencia_Origen As New Collection
    Dim coll_Unidad_Agencia_Destino As New Collection
    Dim coll_Tipo_Comprobante As New Collection
    Dim coll_agencia As New Collection

    Dim coll_AgenciasVenta As New Collection
    Dim coll_AgenciasVenta2 As New Collection

    Dim coll_Tipo_Cliente As New Collection
    Dim coll_Tarjeta As New Collection

    Dim coll_Subcuenta As New Collection
    Dim coll_Funcionario As New Collection

    Dim sCliente As String
    Dim iRuc As Byte

    'Dim objHilo As Threading.Thread
    Dim objConsultaGeneral1 As dtoConsultaGeneral
    Dim iComprobante As Integer = 0
    Dim iComprobante2 As Integer = 0
    Dim iTipo As Integer
    Dim iTipoComprobante As Integer
    Dim bRegistros As Boolean = False
    Dim bInicio As Boolean
    'Dim rsFuncionario As ADODB.Recordset
    Dim rsFuncionario As DataTable

    Public Shared aLista As New ArrayList
    Dim strEstado As String
    Dim sFecha As String

    Dim bNada As Boolean
    Dim bIngreso As Boolean = False

    Dim IdProcesos As Integer = 0

    Private Sub FrmConsultaGeneral2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub
    Private Sub FrmConsultaGeneral2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmConsultaGeneral2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            bInicio = True

            MenuStrip1.Items(1).Visible = False
            MenuStrip1.Items(2).Visible = False
            MenuStrip1.Items(3).Visible = False
            MenuStrip1.Items(4).Visible = False
            MenuStrip1.Items(5).Visible = False
            MenuStrip1.Items(6).Visible = False

            'MenuTab.Items(1).Visible = False
            'MenuTab.Items(2).Visible = False
            'MenuTab.Items(3).Visible = False
            'MenuTab.Items(4).Visible = False
            'MenuTab.Items(5).Visible = False

            'StatusStrip1.Visible = False
            ShadowLabel1.Text = "Consulta de Documentos"
            'MenuTab.Items(1).Visible = False
            MenuTab.Items(0).Text = "Lista"
            MenuTab.Items(1).Text = "Documento"
            MenuTab.Items(2).Text = "Detalle"
            cboEstado.SelectedIndex = 0
            cboTipoFecha.SelectedIndex = 0

            objConsultaGeneral = New dtoConsultaGeneral2
            With objConsultaGeneral
                If .Iniciar Then
                    ModuUtil.LlenarCombo2(.cur_tipo_facturacion, cboTipoFacturacion, coll_Tipo_Facturacion, -1)
                    ModuUtil.LlenarCombo2(.cur_tipo_entrega, cboTipoEntrega, coll_Tipo_Entrega, -1)
                    ModuUtil.LlenarCombo2(.cur_tipo_comprobante, cboTipoDocumento, coll_Tipo_Comprobante, -1)
                    ModuUtil.LlenarCombo2(.cur_tipo_cliente, cboTipoCliente, coll_Tipo_Cliente, -1)
                    ModuUtil.LlenarCombo2(.cur_unidad_agencia_origen, cboOrigen, coll_Unidad_Agencia_Origen, -1)
                    ModuUtil.LlenarCombo2(.cur_unidad_agencia_destino, cboDestino, coll_Unidad_Agencia_Destino, -1)
                    ModuUtil.LlenarCombo2(.cur_tarjeta, cboTarjeta, coll_Tarjeta, -1)

                    ModuUtil.LlenarCombo2(.cur_agencia, cboAgencia, coll_agencia, -1)

                    'datahelper
                    'rsFuncionario = New ADODB.Recordset
                    'rsFuncionario = .cur_funcionario
                    rsFuncionario = .cur_funcionario
                    ModuUtil.LlenarCombo2(.cur_funcionario, cboFuncionario, coll_Funcionario, -1)

                    If objConsultaGeneral.fnLISTA_PERSONAS(dtoUSUARIOS.IdLogin) = True Then
                        'datahelper
                        'fnCargar_iWin2(Me.txtRucCliente, objConsultaGeneral.cur_personas, coll_Lista_Personas, iWinPerosa, 0, iWinPerosaRUC)
                        fnCargar_iWin2_dt2(Me.txtRucCliente, objConsultaGeneral.cur_personas, coll_Lista_Personas, iWinPerosa, 0, iWinPerosaRUC)

                    End If

                    cboDescuento.Items.Add(" -TODOS-")
                    cboDescuento.Items.Add("SI")
                    cboDescuento.Items.Add("NO")
                    cboDescuento.SelectedIndex = 0

                    cboCargos.Items.Add(" -TODOS")
                    cboCargos.Items.Add("SI")
                    cboCargos.Items.Add("NO")
                    cboCargos.SelectedIndex = 0

                    cboVentaArticulo.Items.Add(" -TODOS-")
                    cboVentaArticulo.Items.Add("SI")
                    cboVentaArticulo.Items.Add("NO")
                    cboVentaArticulo.SelectedIndex = 0

                    cboVentaSeguro.Items.Add(" -TODOS-")
                    cboVentaSeguro.Items.Add("SI")
                    cboVentaSeguro.Items.Add("NO")
                    cboVentaSeguro.SelectedIndex = 0
                    '
                    'Adicionando el combo de la Carga Acompañada <-> 05/08/2010
                    '
                    CboCargaAcompanada.Items.Add(" -TODOS-")
                    CboCargaAcompanada.Items.Add("NO")
                    CboCargaAcompanada.Items.Add("SI")
                    CboCargaAcompanada.SelectedIndex = 0

                    cboPyme.Items.Add(" -TODOS-")
                    cboPyme.Items.Add("NO")
                    cboPyme.Items.Add("SI")
                    cboPyme.SelectedIndex = 0

                    CboTe.Items.Add(" -TODOS-")
                    CboTe.Items.Add("NO")
                    CboTe.Items.Add("SI")
                    CboTe.SelectedIndex = 0
                    '
                End If
            End With
            ConfiguraGrid()
            TabMante.SelectedTab = TabDatos
            MenuTab.Items(1).Select()
            txtDocumento.Focus()
            'objHilo = New System.Threading.Thread(AddressOf Mostrar)
            'objHilo.Start()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub cboOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrigen.SelectedIndexChanged
        Dim iUnidadAgenciaOrigen As Integer

        LimpiarGrid()

        iUnidadAgenciaOrigen = coll_Unidad_Agencia_Origen(cboOrigen.SelectedIndex.ToString)
        Dim dt As DataTable = ObjVentaCargaContado.fnGetAgencias(iUnidadAgenciaOrigen)
        If iUnidadAgenciaOrigen >= 0 Then
            objConsultaGeneral.LlenarComboIDs(dt, cboAgenciaOrigen, coll_AgenciasVenta, 0, True)
        Else
            cboAgenciaOrigen.Items.Clear()
            cboAgenciaOrigen.Items.Add("- TODOS-")
            cboAgenciaOrigen.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDestino.SelectedIndexChanged
        Dim iUnidadAgenciaDestino As Integer

        LimpiarGrid()

        iUnidadAgenciaDestino = coll_Unidad_Agencia_Destino(cboDestino.SelectedIndex.ToString)
        Dim dt As DataTable = ObjVentaCargaContado.fnGetAgencias(iUnidadAgenciaDestino)
        If iUnidadAgenciaDestino >= 0 Then
            objConsultaGeneral.LlenarComboIDs(dt, cboAgenciaDestino, coll_AgenciasVenta2, 0, True)
        Else
            cboAgenciaDestino.Items.Clear()
            cboAgenciaDestino.Items.Add("- TODOS-")
            cboAgenciaDestino.SelectedIndex = 0
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32 = Keys.Enter Or msg.WParam.ToInt32 = Keys.Tab Then
            If txtRuc.Focused Then
                Dim i As Integer = iWinPerosaRUC.IndexOf(txtRuc.Text.Trim)
                If i >= 0 Then
                    Dim s As String = iWinPerosa(i)
                    txtRucCliente.Text = s
                    txtRucCliente.Focus()
                Else
                    MessageBox.Show("El Documento no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtRuc.Focus()
                End If
            End If
            If txtRucCliente.Focused Then
                Me.Cursor = Cursors.AppStarting
                Dim indexof As Integer = 0
                sCliente = "-1"
                If iWinPerosa.Count > 0 Then
                    indexof = IIf(iWinPerosa.IndexOf(txtRucCliente.Text.ToUpper) >= 0, iWinPerosa.IndexOf(txtRucCliente.Text.ToUpper), -1)
                    If indexof >= 0 Then
                        If indexof <= iWinPerosaRUC.Count Then
                            Me.txtRuc.Text = iWinPerosaRUC.Item(indexof)
                            If Me.txtRuc.Text.Trim.Length = 11 Then
                                iRuc = 1
                            Else
                                iRuc = 0
                            End If
                        End If

                        Dim iFuncionario As Integer

                        If objConsultaGeneral.ObtieneFuncionario(Int(coll_Lista_Personas(indexof.ToString))) Then
                            If objConsultaGeneral.cur_funcionario_cliente.Rows.Count > 0 Then
                                iFuncionario = objConsultaGeneral.cur_funcionario_cliente.Rows(0).Item(0)
                                cboFuncionario.SelectedIndex = ObtieneFuncionarioIndice(iFuncionario)
                                'datahelper
                                'If objConsultaGeneral.cur_funcionario_cliente.EOF = False And objConsultaGeneral.cur_funcionario_cliente.BOF = False Then
                                '    iFuncionario = objConsultaGeneral.cur_funcionario_cliente.Fields(0).Value
                                '    cboFuncionario.SelectedIndex = ObtieneFuncionarioIndice(iFuncionario)
                            Else
                                cboFuncionario.SelectedIndex = 0
                            End If
                        Else
                            cboFuncionario.SelectedIndex = 0
                        End If

                        'Carga datos de cliente seleccionado
                        objConsultaGeneral.v_IDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                        sCliente = Int(coll_Lista_Personas(indexof.ToString))
                        If iRuc = 1 Then
                            If objConsultaGeneral.CargarDatos Then
                                'datatable
                                'ModuUtil.LlenarComboIDs(objConsultaGeneral.cur_subcuenta, cboSubcuenta, coll_Subcuenta, -1)
                                ModuUtil.LlenarCombo2(objConsultaGeneral.cur_subcuenta, cboSubcuenta, coll_Subcuenta, -1)
                                If objConsultaGeneral.cur_cliente.Rows.Count > 0 Then
                                    'datahelper
                                    'fnCargar_iWin2(Me.txtRemitente, objConsultaGeneral.cur_cliente, coll_Remitente, iWinRemitente, 0, iWinRemitente2)
                                    fnCargar_iWin2_dt2(Me.txtRemitente, objConsultaGeneral.cur_cliente, coll_Remitente, iWinRemitente, 0, iWinRemitente2)
                                End If

                                If objConsultaGeneral.cur_direccion1.Rows.Count > 0 Then
                                    'datahelper
                                    'fnCargar_iWin2(Me.txtDireccionRemitente, objConsultaGeneral.cur_direccion1, coll_Direccion1, iWinDireccion1, 0, iWinDireccion11)
                                    fnCargar_iWin2_dt2(Me.txtDireccionRemitente, objConsultaGeneral.cur_direccion1, coll_Direccion1, iWinDireccion1, 0, iWinDireccion11)
                                End If
                                If objConsultaGeneral.cur_consignado.Rows.Count > 0 Then
                                    'datahelper
                                    'fnCargar_iWin2(Me.txtConsignado, objConsultaGeneral.cur_consignado, coll_Consignado, iWinConsignado, 0, iWinConsignado2)
                                    fnCargar_iWin2_dt2(Me.txtConsignado, objConsultaGeneral.cur_consignado, coll_Consignado, iWinConsignado, 0, iWinConsignado2)
                                End If
                                If objConsultaGeneral.cur_direccion2.Rows.Count > 0 Then
                                    'datahelper
                                    'fnCargar_iWin2(Me.txtDireccionConsignado, objConsultaGeneral.cur_direccion2, coll_Direccion2, iWinDireccion2, 0, iWinDireccion22)
                                    fnCargar_iWin2_dt2(Me.txtDireccionConsignado, objConsultaGeneral.cur_direccion2, coll_Direccion2, iWinDireccion2, 0, iWinDireccion22)
                                End If
                                If objConsultaGeneral.cur_contacto.Rows.Count > 0 Then
                                    'datahelper
                                    'fnCargar_iWin2(Me.txtContacto, objConsultaGeneral.cur_contacto, coll_Contacto, iWinContacto, 0, iWinContacto2)
                                    fnCargar_iWin2_dt2(Me.txtContacto, objConsultaGeneral.cur_contacto, coll_Contacto, iWinContacto, 0, iWinContacto2)
                                End If

                                'datahelper
                                'If objConsultaGeneral.cur_cliente.BOF = False And objConsultaGeneral.cur_cliente.EOF = False Then
                                '    fnCargar_iWin2(Me.txtRemitente, objConsultaGeneral.cur_cliente, coll_Remitente, iWinRemitente, 0, iWinRemitente2)
                                'End If

                                'If objConsultaGeneral.cur_direccion1.BOF = False And objConsultaGeneral.cur_direccion1.EOF = False Then
                                '    fnCargar_iWin2(Me.txtDireccionRemitente, objConsultaGeneral.cur_direccion1, coll_Direccion1, iWinDireccion1, 0, iWinDireccion11)
                                'End If
                                'If objConsultaGeneral.cur_consignado.BOF = False And objConsultaGeneral.cur_consignado.EOF = False Then
                                '    fnCargar_iWin2(Me.txtConsignado, objConsultaGeneral.cur_consignado, coll_Consignado, iWinConsignado, 0, iWinConsignado2)
                                'End If
                                'If objConsultaGeneral.cur_direccion2.BOF = False And objConsultaGeneral.cur_direccion2.EOF = False Then
                                '    fnCargar_iWin2(Me.txtDireccionConsignado, objConsultaGeneral.cur_direccion2, coll_Direccion2, iWinDireccion2, 0, iWinDireccion22)
                                'End If
                                'If objConsultaGeneral.cur_contacto.BOF = False And objConsultaGeneral.cur_contacto.EOF = False Then
                                '    fnCargar_iWin2(Me.txtContacto, objConsultaGeneral.cur_contacto, coll_Contacto, iWinContacto, 0, iWinContacto2)
                                'End If
                            End If
                            Me.cboFuncionario.Enabled = False
                        Else
                            If objConsultaGeneral.CargarDatos2 Then
                                'datahelper
                                fnCargar_iWin_dt(Me.txtDireccionRemitente, objConsultaGeneral.cur_direccion1, coll_Direccion1, iWinDireccion1, 0)
                                fnCargar_iWin_dt(Me.txtConsignado, objConsultaGeneral.cur_consignado, coll_Consignado, iWinConsignado, 0)
                                fnCargar_iWin_dt(Me.txtDireccionConsignado, objConsultaGeneral.cur_direccion2, coll_Direccion2, iWinDireccion2, 0)
                                fnCargar_iWin_dt(Me.txtContacto, objConsultaGeneral.cur_contacto, coll_Contacto, iWinContacto, 0)

                                Me.cboFuncionario.Enabled = False
                            End If
                        End If
                    Else
                        cboSubcuenta.Items.Clear()
                        ModuUtil.LlenarComboIDs_dt(rsFuncionario, cboFuncionario, coll_Funcionario, -1)
                        Me.cboFuncionario.Enabled = True
                    End If
                End If
            End If
            If sCliente = "-1" Or sCliente Is Nothing Then
                txtRemitente.BackColor = txtRemitente.BackColor.FromArgb(224, 224, 224)
                txtDireccionRemitente.BackColor = txtDireccionRemitente.BackColor.FromArgb(224, 224, 224)
                txtConsignado.BackColor = txtConsignado.BackColor.FromArgb(224, 224, 224)
                txtDireccionConsignado.BackColor = txtDireccionConsignado.BackColor.FromArgb(224, 224, 224)
                txtContacto.BackColor = txtContacto.BackColor.FromArgb(224, 224, 224)
                txtRucCliente.Text = ""
                Me.txtRuc.Text = ""
            Else
                txtRemitente.BackColor = Color.White
                txtConsignado.BackColor = Color.White
                txtDireccionRemitente.BackColor = Color.White
                txtDireccionConsignado.BackColor = Color.White
                txtContacto.BackColor = Color.White
            End If

            Me.Cursor = Cursors.Default
        End If
    End Function

    Private Sub txtRucCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRucCliente.KeyPress
        e.KeyChar = e.KeyChar.ToUpper(e.KeyChar)
    End Sub

    Private Sub txtRuc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRuc.LostFocus
        'If sCliente = "-1" Or sCliente Is Nothing Then
        'txtRucCliente.Text = ""
        'Me.txtRuc.Text = ""
        'End If
    End Sub

    Private Sub txtRucCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRucCliente.LostFocus
        If sCliente = "-1" Or sCliente Is Nothing Then
            txtRucCliente.Text = ""
            Me.txtRuc.Text = ""
        End If
    End Sub

    Private Sub txtRucCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRucCliente.TextChanged, txtRuc.TextChanged
        Me.cboSubcuenta.Items.Clear()
        Me.cboFuncionario.Enabled = True
        If Me.cboFuncionario.Items.Count > 0 Then
            Me.cboFuncionario.SelectedIndex = 0
        End If
        Me.txtRemitente.Text = ""
        Me.txtDireccionRemitente.Text = ""
        Me.txtDireccionConsignado.Text = ""
        Me.txtContacto.Text = ""
        Me.txtConsignado.Text = ""
        Me.sCliente = "-1"
        Me.txtContacto.Text = ""
        coll_Subcuenta.Clear()
        LimpiarGrid()


        txtRemitente.BackColor = txtRemitente.BackColor.FromArgb(224, 224, 224)
        txtDireccionRemitente.BackColor = txtDireccionRemitente.BackColor.FromArgb(224, 224, 224)
        txtConsignado.BackColor = txtConsignado.BackColor.FromArgb(224, 224, 224)
        txtDireccionConsignado.BackColor = txtDireccionConsignado.BackColor.FromArgb(224, 224, 224)
        txtContacto.BackColor = txtContacto.BackColor.FromArgb(224, 224, 224)


        'objConsultaGeneral.cur_funcionario.MoveFirst()
        'ModuUtil.LlenarComboIDs(objConsultaGeneral.cur_funcionario, cboFuncionario, coll_Funcionario, -1)
        'coll_Funcionario.Clear()

        'objConsultaGeneral.cur_funcionario.MoveFirst()
        'ModuUtil.LlenarComboIDs(objConsultaGeneral.cur_funcionario, cboFuncionario, objConsultaGeneral.coll_Funcionario, -1)

    End Sub

    Private Sub ConfiguraGrid()
        With dgvDocumento
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .BackgroundColor = SystemColors.Window
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            '.ReadOnly = False
            '.AutoGenerateColumns = False
            '.ScrollBars = ScrollBars.None
            '.DataSource = dtable_Lista_Control_Comprobante
            '.VirtualMode = False

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

            Dim c1 As New DataGridViewTextBoxColumn
            With c1
                .DisplayIndex = 0
                .HeaderText = "Nº Doc."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c1)

            Dim c2 As New DataGridViewTextBoxColumn
            With c2
                .DisplayIndex = 1
                .HeaderText = "Tipo Doc."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c2)

            Dim c2_1 As New DataGridViewTextBoxColumn
            With c2_1
                .DisplayIndex = 2
                .HeaderText = "Tipo Carga"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c2_1)

            Dim c3 As New DataGridViewTextBoxColumn
            With c3
                .DisplayIndex = 3
                .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c3)

            Dim c4 As New DataGridViewTextBoxColumn
            With c4
                .DisplayIndex = 4
                .HeaderText = "Orígen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c4)

            Dim c5 As New DataGridViewTextBoxColumn
            With c5
                .DisplayIndex = 5
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c5)

            Dim c6 As New DataGridViewTextBoxColumn
            With c6
                .DisplayIndex = 6
                .HeaderText = "Cod. Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c6)

            Dim c7 As New DataGridViewTextBoxColumn
            With c7
                .DisplayIndex = 7
                .HeaderText = "Razón Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c7)

            Dim c7_1 As New DataGridViewTextBoxColumn
            With c7_1
                .DisplayIndex = 8
                .HeaderText = "Consignado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c7_1)

            Dim c8 As New DataGridViewTextBoxColumn
            With c8
                .DisplayIndex = 9
                .HeaderText = "Subcuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c8)

            Dim c9 As New DataGridViewTextBoxColumn
            With c9
                .DisplayIndex = 10
                .HeaderText = "Tipo Facturación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c9)

            Dim c10 As New DataGridViewTextBoxColumn
            With c10
                .DisplayIndex = 11
                .HeaderText = "Forma Pago"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c10)

            Dim c11 As New DataGridViewTextBoxColumn
            With c11
                .DisplayIndex = 12
                .HeaderText = "Estado Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c11)

            Dim c12 As New DataGridViewTextBoxColumn
            With c12
                .DisplayIndex = 13
                .HeaderText = "Estado Envío"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c12)

            Dim c13 As New DataGridViewTextBoxColumn
            With c13
                .DisplayIndex = 14
                .HeaderText = "Cantidad Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c13)

            Dim c14 As New DataGridViewTextBoxColumn
            With c14
                .DisplayIndex = 15
                .HeaderText = "Cantidad Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c14)

            Dim c15 As New DataGridViewTextBoxColumn
            With c15
                .DisplayIndex = 16
                .HeaderText = "Cantidad Artículo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c15)

            Dim c16 As New DataGridViewTextBoxColumn
            With c16
                .DisplayIndex = 17
                .HeaderText = "Cantidad Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c16)

            Dim c17 As New DataGridViewTextBoxColumn
            With c17
                .DisplayIndex = 18
                .HeaderText = "Precio Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c17)

            Dim c18 As New DataGridViewTextBoxColumn
            With c18
                .DisplayIndex = 19
                .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c18)

            Dim c19 As New DataGridViewTextBoxColumn
            With c19
                .DisplayIndex = 20
                .HeaderText = "Precio Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c19)

            Dim c20 As New DataGridViewTextBoxColumn
            With c20
                .DisplayIndex = 21
                .HeaderText = "Total Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c20)

            Dim c21 As New DataGridViewTextBoxColumn
            With c21
                .DisplayIndex = 22
                .HeaderText = "Precio Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c21)

            Dim c22 As New DataGridViewTextBoxColumn
            With c22
                .DisplayIndex = 23
                .HeaderText = "Monto Base"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c22)

            Dim c23 As New DataGridViewTextBoxColumn
            With c23
                .DisplayIndex = 24
                .HeaderText = "% Descuento/Incremento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c23)

            Dim c24 As New DataGridViewTextBoxColumn
            With c24
                .DisplayIndex = 25
                .HeaderText = "Monto Descuento/Incremento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c24)

            Dim c25 As New DataGridViewTextBoxColumn
            With c25
                .DisplayIndex = 26
                .HeaderText = "Memo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c25)

            Dim c26 As New DataGridViewTextBoxColumn
            With c26
                .DisplayIndex = 27
                .HeaderText = "¿Cargo?"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c26)

            Dim c27 As New DataGridViewTextBoxColumn
            With c27
                .DisplayIndex = 28
                .HeaderText = "¿Liquidado?"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c27)

            Dim c28 As New DataGridViewTextBoxColumn
            With c28
                .DisplayIndex = 29
                .HeaderText = "¿Prefacturado?"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c28)

            Dim c29 As New DataGridViewTextBoxColumn
            With c29
                .DisplayIndex = 30
                .HeaderText = "¿Facturado?"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c29)

            Dim c30 As New DataGridViewTextBoxColumn
            With c30
                .DisplayIndex = 31
                .HeaderText = "Subtotal CA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c30)

            Dim c31 As New DataGridViewTextBoxColumn
            With c31
                .DisplayIndex = 32
                .HeaderText = "Impuesto CA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c31)

            Dim c32 As New DataGridViewTextBoxColumn
            With c32
                .DisplayIndex = 33
                .HeaderText = "Total CA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c32)

            Dim c33 As New DataGridViewTextBoxColumn
            With c33
                .DisplayIndex = 34
                .HeaderText = "Subtotal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c33)

            Dim c34 As New DataGridViewTextBoxColumn
            With c34
                .DisplayIndex = 35
                .HeaderText = "Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c34)

            Dim c35 As New DataGridViewTextBoxColumn
            With c35
                .DisplayIndex = 36
                .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c35)
            '
            '31/05/2010
            Dim c36 As New DataGridViewTextBoxColumn
            With c36
                .DisplayIndex = 37
                .HeaderText = "Usuario Ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With
            .Columns.Add(c36)
            '
            Dim c37 As New DataGridViewTextBoxColumn
            With c37
                .DisplayIndex = 38
                .HeaderText = "Fec. Recepción"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With
            .Columns.Add(c37)
            '
            Dim c38 As New DataGridViewTextBoxColumn
            With c38
                .DisplayIndex = 39
                .HeaderText = "Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With
            .Columns.Add(c38)
            '
            Dim c39 As New DataGridViewTextBoxColumn
            With c39
                .DisplayIndex = 40
                .HeaderText = "Fec. Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With
            .Columns.Add(c39)
            ' 
            Dim c40 As New DataGridViewTextBoxColumn
            With c40
                .DisplayIndex = 41
                .HeaderText = "Usuario Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With
            .Columns.Add(c40)
            '
            Dim c41 As New DataGridViewTextBoxColumn
            With c41
                .DisplayIndex = 42
                .HeaderText = "Días sin Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With
            .Columns.Add(c41)
            '
            Dim c42 As New DataGridViewTextBoxColumn
            With c42
                .DisplayIndex = 43
                .HeaderText = "Nº incidencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With
            .Columns.Add(c42)

            Dim c43 As New DataGridViewTextBoxColumn
            With c43
                .DisplayIndex = 44
                .HeaderText = "Fec. Incidencia Ult"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With
            .Columns.Add(c43)

            Dim c44 As New DataGridViewTextBoxColumn
            With c44
                .DisplayIndex = 45
                .HeaderText = "IdProcesos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c44)
        End With

        If bNada = False Then
            ConfiguraDGVVenta()
            ConfiguraDGVDocumentos()
            With dgvCheckpoint
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                .AutoGenerateColumns = False
                '    '.DataSource = dtable_Lista_Control_Comprobante
                .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With


            Dim IDVAR As New DataGridViewTextBoxColumn
            With IDVAR
                .DisplayIndex = 0
                .DataPropertyName = "ID_VAR"
                .HeaderText = "PK"

                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dgvCheckpoint.Columns.Add(IDVAR)

            Dim FECHA As New DataGridViewTextBoxColumn
            With FECHA
                .DisplayIndex = 1
                .DataPropertyName = "Fecha"
                .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgvCheckpoint.Columns.Add(FECHA)


            Dim HORA As New DataGridViewTextBoxColumn
            With HORA
                .DisplayIndex = 2
                .DataPropertyName = "HORA"
                .HeaderText = "Hora"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgvCheckpoint.Columns.Add(HORA)

            Dim CIUDAD As New DataGridViewTextBoxColumn
            With CIUDAD
                .DisplayIndex = 3
                .DataPropertyName = "Nombre_Unidad"
                .HeaderText = "Ciudad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgvCheckpoint.Columns.Add(CIUDAD)

            Dim USUARIO As New DataGridViewTextBoxColumn
            With USUARIO
                .DisplayIndex = 4
                .DataPropertyName = "usuario"
                .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgvCheckpoint.Columns.Add(USUARIO)


            Dim OBS As New DataGridViewTextBoxColumn
            With OBS
                .DisplayIndex = 5
                .DataPropertyName = "OBS"
                .HeaderText = "Descripción"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgvCheckpoint.Columns.Add(OBS)
        End If

    End Sub
    Private Sub Ejecutar()
        Dim sUsuarioEstado As String

        If sCliente = "-1" Or sCliente Is Nothing Then
            txtRucCliente.Text = ""
            Me.txtRuc.Text = ""
        End If

        objConsultaGeneral = New dtoConsultaGeneral2
        With objConsultaGeneral
            If cboUsuario.SelectedIndex >= 0 Then
                .UsuarioEstado = coll_Usuarios(cboUsuario.SelectedIndex + 1) 'Me.txtUsuario.Text.Trim
            Else
                .UsuarioEstado = "-1"
            End If
            If .UsuarioEstado = "" Then .UsuarioEstado = "-1"

            If cboTipoFecha.SelectedIndex <> 2 Then
                .Fecha = IIf(cboTipoFecha.SelectedIndex = 0, "-1", "22")
            Else
                .Fecha = cboEstado.SelectedIndex
            End If

            .Estado = cboEstado.SelectedIndex
            .FechaInicio = dtFechaInicio.Text
            .FechaFin = dtFechaFin.Text
            objConsultaGeneral.TipoFacturacion = coll_Tipo_Facturacion(cboTipoFacturacion.SelectedIndex + 1)
            objConsultaGeneral.TipoEntrega = coll_Tipo_Entrega(cboTipoEntrega.SelectedIndex + 1)
            objConsultaGeneral.Origen = coll_Unidad_Agencia_Origen(cboOrigen.SelectedIndex + 1)
            objConsultaGeneral.Destino = coll_Unidad_Agencia_Destino(cboDestino.SelectedIndex + 1)
            objConsultaGeneral.TipoComprobante = coll_Tipo_Comprobante(cboTipoDocumento.SelectedIndex + 1)
            If coll_AgenciasVenta.Count > 0 Then
                objConsultaGeneral.AgenciaOrigen = coll_AgenciasVenta(cboAgenciaOrigen.SelectedIndex + 1)
            Else
                objConsultaGeneral.AgenciaOrigen = "-1"
            End If
            If coll_AgenciasVenta2.Count > 0 Then
                objConsultaGeneral.AgenciaDestino = coll_AgenciasVenta2(cboAgenciaDestino.SelectedIndex + 1)
            Else
                objConsultaGeneral.AgenciaDestino = "-1"
            End If
            objConsultaGeneral.TipoPersona = coll_Tipo_Cliente(cboTipoCliente.SelectedIndex + 1)
            objConsultaGeneral.TipoTarjeta = coll_Tarjeta(cboTarjeta.SelectedIndex + 1)
            objConsultaGeneral.NumeroTarjeta = IIf(txtNumeroTarjeta.Text.Trim = "", "-1", txtNumeroTarjeta.Text)

            If sCliente Is Nothing Then sCliente = "-1"
            objConsultaGeneral.v_IDPERSONA = sCliente

            Dim indice As Integer = 0
            indice = IIf(iWinRemitente.IndexOf(txtRemitente.Text.ToUpper) >= 0, iWinRemitente.IndexOf(txtRemitente.Text.ToUpper), -1)
            If indice = -1 Then
                objConsultaGeneral.Remitente = -1
            Else
                objConsultaGeneral.Remitente = coll_Remitente(indice + 1)
            End If

            indice = IIf(iWinConsignado.IndexOf(txtConsignado.Text.ToUpper) >= 0, iWinConsignado.IndexOf(txtConsignado.Text.ToUpper), -1)
            If indice = -1 Then
                objConsultaGeneral.Consignado = -1
            Else
                objConsultaGeneral.Consignado = coll_Consignado(indice + 1)
            End If

            indice = IIf(iWinDireccion1.IndexOf(txtDireccionRemitente.Text.ToUpper) >= 0, iWinDireccion1.IndexOf(txtDireccionRemitente.Text.ToUpper), -1)
            If indice = -1 Then
                objConsultaGeneral.Dir1 = -1
            Else
                objConsultaGeneral.Dir1 = coll_Direccion1(indice + 1)
            End If

            indice = IIf(iWinDireccion2.IndexOf(txtDireccionConsignado.Text.ToUpper) >= 0, iWinDireccion2.IndexOf(txtDireccionConsignado.Text.ToUpper), -1)
            If indice = -1 Then
                objConsultaGeneral.Dir2 = -1
            Else
                objConsultaGeneral.Dir2 = coll_Direccion2(indice + 1)
            End If

            indice = IIf(iWinContacto.IndexOf(txtContacto.Text.ToUpper) >= 0, iWinContacto.IndexOf(txtContacto.Text.ToUpper), -1)
            If indice = -1 Then
                objConsultaGeneral.Contacto = -1
            Else
                objConsultaGeneral.Contacto = coll_Contacto(indice + 1)
            End If

            If coll_Subcuenta.Count > 0 Then
                objConsultaGeneral.Subcuenta = coll_Subcuenta(cboSubcuenta.SelectedIndex + 1)
            Else
                objConsultaGeneral.Subcuenta = "-1"
            End If

            If coll_Funcionario.Count > 0 Then
                If cboFuncionario.SelectedIndex = -1 Then
                    objConsultaGeneral.Funcionario = coll_Funcionario(1)
                Else
                    objConsultaGeneral.Funcionario = coll_Funcionario(cboFuncionario.SelectedIndex + 1)
                End If
            Else
                objConsultaGeneral.Subcuenta = "-1"
            End If

            If strEstado.Trim.Length = 0 Then
                objConsultaGeneral.Estados = "-1"
            Else
                objConsultaGeneral.Estados = strEstado
            End If

            'Otro filtro
            If txtNumeroPrefactura.Text.Trim = "" Then
                objConsultaGeneral.Prefactura = "-1"
            Else
                objConsultaGeneral.Prefactura = txtNumeroPrefactura.Text.Trim
            End If

            If txtNumeroFactura.Text.Trim = "" Then
                objConsultaGeneral.Factura = "-1"
            Else
                objConsultaGeneral.Factura = txtNumeroFactura.Text.Trim
            End If

            If TxtNumeroGrt.Text.Trim = "" Then
                objConsultaGeneral.Grt = "-1"
            Else
                objConsultaGeneral.Grt = TxtNumeroGrt.Text.Trim
            End If

            If cboCargos.SelectedIndex = 0 Then
                objConsultaGeneral.Cargo = "-1"
            ElseIf cboCargos.SelectedIndex = 1 Then
                objConsultaGeneral.Cargo = "1"
            Else
                objConsultaGeneral.Cargo = "0"
            End If

            If txtLiquidacionCargos.Text.Trim = "" Then
                objConsultaGeneral.DevCargo = "-1"
            Else
                objConsultaGeneral.DevCargo = txtLiquidacionCargos.Text.Trim
            End If

            If cboVentaArticulo.SelectedIndex = 0 Then
                objConsultaGeneral.Articulo = "-1"
            ElseIf cboVentaArticulo.SelectedIndex = 1 Then
                objConsultaGeneral.Articulo = "1"
            Else
                objConsultaGeneral.Articulo = "0"
            End If

            If cboVentaSeguro.SelectedIndex = 0 Then
                objConsultaGeneral.Seguro = "-1"
            ElseIf cboVentaSeguro.SelectedIndex = 1 Then
                objConsultaGeneral.Seguro = "1"
            Else
                objConsultaGeneral.Seguro = "0"
            End If

            If cboDescuento.SelectedIndex = 0 Then
                objConsultaGeneral.Descuento = "-1"
            ElseIf cboDescuento.SelectedIndex = 1 Then
                objConsultaGeneral.Descuento = "1"
            Else
                objConsultaGeneral.Descuento = "0"
            End If
            '05/08/2010 - Se adiciona la venta carga acompañada loco
            If CboCargaAcompanada.SelectedIndex = 0 Then
                objConsultaGeneral.acompanada = "0"
            ElseIf CboCargaAcompanada.SelectedIndex = 1 Then
                objConsultaGeneral.acompanada = "1"   'Venta Normal 
            Else
                objConsultaGeneral.acompanada = "2"   'Venta Carga Acompañada  
            End If

            '15/10/2010 - Se adiciona la venta carga pyme
            If cboPyme.SelectedIndex = 0 Then
                objConsultaGeneral.Pyme = "0"
            ElseIf cboPyme.SelectedIndex = 1 Then
                objConsultaGeneral.Pyme = "1"   'Venta Normal 
            Else
                objConsultaGeneral.Pyme = "2"   'Venta Pyme
            End If

            '13/05/2011 - Se adiciona la venta Tepsa Encomiendas
            If CboTe.SelectedIndex = 0 Then
                objConsultaGeneral.Te = "0"
            ElseIf CboTe.SelectedIndex = 1 Then
                objConsultaGeneral.Te = "1"   'Venta Normal 
            Else
                objConsultaGeneral.Te = "2"   'Venta Tepsa Encomiendas
            End If

            '
            dgvDocumento.Columns.Clear()
            If .Ejecutar Then   'exito
                'datahelper
                'If Not (objConsultaGeneral.curVenta.EOF And objConsultaGeneral.curVenta.BOF) Then
                If objConsultaGeneral.curVenta.Rows.Count > 0 Then
                    bNada = False
                    Mostrar22()
                    lblRegistros.Text = FormatNumber(dgvDocumento.Rows.Count, 0)
                Else
                    Me.Cursor = Cursors.Default
                    bNada = True
                    dgvDocumento.DataSource = Nothing
                    ConfiguraGrid()
                    lblRegistros.Text = "0"
                    MessageBox.Show("No se Encontraron Registros.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else                'error
                Me.Cursor = Cursors.Default
                dgvDocumento.DataSource = Nothing
                dgvDocumentos.Columns.Clear()
                dgvCheckpoint.Columns.Clear()
                dgvCheckpoint.DataSource = Nothing
                dgvVenta.Columns.Clear()
                ConfiguraGrid()
                MessageBox.Show("No se Encontraron Registros.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End With
        'Cabecera()
        Me.Cursor = Cursors.Default
    End Sub
    'Public Function RecordSet_a_DataSet(ByVal rs As ADODB.Recordset) As DataTable

    '    Dim myDA As New System.Data.OleDb.OleDbDataAdapter
    '    Dim myDS As New DataSet("MyTable")
    '    myDA.Fill(myDS, rs, "MyTable")

    '    dgvDocumento.DataSource = myDS
    '    dgvDocumento.DataMember = "MyTable"
    '    Return myDS.Tables(0)
    'End Function

    Private Sub txtNumeroPrefactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroPrefactura.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "-" And InStr(tb.Text, "-") = 0) Then
                e.Handled = False
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub txtNumeroPrefactura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroPrefactura.TextChanged
        LimpiarGrid()
        LimpiarNorelacionados(sender)
    End Sub

    Private Sub txtNumeroFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroFactura.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "-" And InStr(tb.Text, "-") = 0) Then
                e.Handled = False
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub txtNumeroFactura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroFactura.TextChanged
        LimpiarGrid()
        LimpiarNorelacionados(sender)
    End Sub

    Private Sub txtLiquidacionCargos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLiquidacionCargos.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "-" And InStr(tb.Text, "-") = 0) Then
                e.Handled = False
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub txtLiquidacionCargos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLiquidacionCargos.TextChanged
        LimpiarGrid()
        LimpiarNorelacionados(sender)
    End Sub

    Private Sub TxtNumeroGrt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumeroGrt.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "-" And InStr(tb.Text, "-") = 0) Then
                e.Handled = False
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtNumeroGrt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroGrt.TextChanged
        LimpiarGrid()
        LimpiarNorelacionados(sender)
    End Sub

    Private Sub Cabecera()
        dgvDocumento.Columns(0).HeaderText = "Nº Doc."
        dgvDocumento.Columns(1).HeaderText = "Tipo Doc."
        dgvDocumento.Columns(2).HeaderText = "Fecha"
        dgvDocumento.Columns(3).HeaderText = "Orígen"
        dgvDocumento.Columns(4).HeaderText = "Destino"
        dgvDocumento.Columns(5).HeaderText = "Cod. Cliente"
        dgvDocumento.Columns(6).HeaderText = "Razón Social"

        dgvDocumento.Columns(7).HeaderText = "Subcuenta"
        dgvDocumento.Columns(8).HeaderText = "Tipo Facturación"
        dgvDocumento.Columns(9).HeaderText = "Forma Pago"
        dgvDocumento.Columns(10).HeaderText = "Estado Documento"
        dgvDocumento.Columns(11).HeaderText = "Estado Envío"
        dgvDocumento.Columns(12).HeaderText = "Cantidad Peso"
        dgvDocumento.Columns(13).HeaderText = "Cantidad Volumen"
        dgvDocumento.Columns(14).HeaderText = "Cantidad Artículo"
        dgvDocumento.Columns(15).HeaderText = "Cantidad Sobre"
        dgvDocumento.Columns(16).HeaderText = "Precio Sobre"
        dgvDocumento.Columns(17).HeaderText = "Total Peso"
        dgvDocumento.Columns(18).HeaderText = "Precio Peso"
        dgvDocumento.Columns(19).HeaderText = "Total Volumen"
        dgvDocumento.Columns(20).HeaderText = "Precio Volumen"
        dgvDocumento.Columns(21).HeaderText = "Monto Base"
        dgvDocumento.Columns(22).HeaderText = "% Descuento"
        dgvDocumento.Columns(23).HeaderText = "Monto Descuento"
        dgvDocumento.Columns(24).HeaderText = "Memo"
        dgvDocumento.Columns(25).HeaderText = "¿Cargo?"
        dgvDocumento.Columns(26).HeaderText = "¿Liquidado?"
        dgvDocumento.Columns(27).HeaderText = "¿Prefacturado?"
        dgvDocumento.Columns(28).HeaderText = "¿Facturado?"
        dgvDocumento.Columns(29).HeaderText = "Subtotal CA"
        dgvDocumento.Columns(30).HeaderText = "Impuesto CA"
        dgvDocumento.Columns(31).HeaderText = "Total CA"
        dgvDocumento.Columns(32).HeaderText = "Subtotal"
        dgvDocumento.Columns(33).HeaderText = "Impuesto"
        dgvDocumento.Columns(34).HeaderText = "Total"
    End Sub

    Private Sub dgvDocumento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDocumento.DoubleClick
        If dgvDocumento.Rows.Count > 0 Then
            Me.Cursor = Cursors.AppStarting
            Dim iDocumento As Integer = dgvDocumento.SelectedRows.Item(0).Index()
            Dim sDoc As String = dgvDocumento.Rows(iDocumento).Cells(0).Value
            IdProcesos = dgvDocumento.Rows(iDocumento).Cells(45).Value

            TabMante.SelectedTab = TabDatos
            MenuTab.Items(1).Select()

            dgvDocumentos.Columns.Clear()
            ConfiguraDGVDocumentos()

            dgvVenta.Columns.Clear()
            ConfiguraDGVVenta()

            txtDocumento.Text = sDoc
            btnFiltrar2_Click(sender, e)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub txtDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDocumento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.Cursor = Cursors.AppStarting
            Ejecutar2()
        End If
    End Sub

    Private Sub Ejecutar2()
        Try
            Dim sDocumento As String

            sDocumento = txtDocumento.Text.Trim
            If sDocumento = "" Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            objConsultaGeneral1 = New dtoConsultaGeneral
            With objConsultaGeneral1
                .Documento = sDocumento

                If .ObtenerDocumento() Then
                    If objConsultaGeneral1.curId.Rows.Count >= 1 Then
                        For index As Integer = 0 To objConsultaGeneral1.curId.Rows.Count - 1
                            If .Ejecutar1(Convert.ToInt32(objConsultaGeneral1.curId.Rows(index).Item("IdFactura").ToString), Convert.ToInt32(objConsultaGeneral1.curId.Rows(index).Item("IdPersona").ToString), Convert.ToInt32(objConsultaGeneral1.curId.Rows(index).Item("IdPrefactura").ToString), Convert.ToInt32(objConsultaGeneral1.curId.Rows(index).Item("Facturado").ToString), Convert.ToInt32(objConsultaGeneral1.curId.Rows(index).Item("IdTipo_Comprobante").ToString)) Then   'exito
                                If objConsultaGeneral1.curVenta.Rows.Count = 1 Then
                                    bRegistros = False
                                ElseIf objConsultaGeneral1.curVenta.Rows.Count >= 2 Then
                                    bRegistros = True
                                End If
                            Else
                                bRegistros = False
                            End If
                        Next

                        If objConsultaGeneral1.curVenta.Rows.Count > 0 Then
                            If bRegistros Then
                                lblRegistro.Text = "(1/2)"
                                btnAnterior.Enabled = False
                                btnSiguiente.Enabled = True
                            Else
                                lblRegistro.Text = "(0/0)"
                                btnAnterior.Enabled = False
                                btnSiguiente.Enabled = False
                            End If
                            Mostrar(0)
                        Else
                            btnAnterior.Enabled = False
                            btnSiguiente.Enabled = False
                            Me.Cursor = Cursors.Default
                            MessageBox.Show("No se Encontraron Registros.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Limpiar()
                        End If
                        
                        'If objConsultaGeneral1.curVenta.Rows.Count > 0 Then
                        '    bRegistros = False
                        '    iComprobante2 = objConsultaGeneral1.curVenta.Rows(0).Item(42)
                        '    If objConsultaGeneral1.curVenta.Rows.Count > 1 Then
                        '        If objConsultaGeneral1.curVenta.Rows(1).Item(42) <> iComprobante2 Then
                        '            bRegistros = True
                        '        End If
                        '    End If
                        '    If bRegistros Then
                        '        lblRegistro.Text = "(1/2)"
                        '        btnAnterior.Enabled = False
                        '        btnSiguiente.Enabled = True
                        '    Else
                        '        lblRegistro.Text = "(0/0)"
                        '        btnAnterior.Enabled = False
                        '        btnSiguiente.Enabled = False
                        '    End If
                        '    Mostrar(0)
                        'Else
                        '    btnAnterior.Enabled = False
                        '    btnSiguiente.Enabled = False
                        '    Me.Cursor = Cursors.Default
                        '    MessageBox.Show("No se Encontraron Registros.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '    Limpiar()
                        'End If
                    Else
                        btnAnterior.Enabled = False
                        btnSiguiente.Enabled = False
                        Me.Cursor = Cursors.Default
                        MessageBox.Show("No se Encontraron Registros.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

                'If .Ejecutar1 Then   'exito
                '    If objConsultaGeneral1.curVenta.Rows.Count > 0 Then
                '        bRegistros = False
                '        iComprobante2 = objConsultaGeneral1.curVenta.Rows(0).Item(42)
                '        If objConsultaGeneral1.curVenta.Rows.Count > 1 Then
                '            If objConsultaGeneral1.curVenta.Rows(1).Item(42) <> iComprobante2 Then
                '                bRegistros = True
                '            End If
                '        End If
                '        If bRegistros Then
                '            lblRegistro.Text = "(1/2)"
                '            btnAnterior.Enabled = False
                '            btnSiguiente.Enabled = True
                '        Else
                '            lblRegistro.Text = "(0/0)"
                '            btnAnterior.Enabled = False
                '            btnSiguiente.Enabled = False
                '        End If
                '        Mostrar(0)
                '    Else
                '        btnAnterior.Enabled = False
                '        btnSiguiente.Enabled = False
                '        Me.Cursor = Cursors.Default
                '        MessageBox.Show("No se Encontraron Registros.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '        Limpiar()
                '    End If
                'Else                'error
                '    btnAnterior.Enabled = False
                '    btnSiguiente.Enabled = False
                '    Me.Cursor = Cursors.Default
                '    MessageBox.Show("No se Encontraron Registros.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Limpiar()
                'End If


            End With
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub MostrarCheckPoint()
        Try
            Dim ObjEntregaCarga As New dtoEntregaCarga

            ObjEntregaCarga.IDPK = iTipo
            ObjEntregaCarga.IDDOC = iComprobante

            dgvCheckpoint.DataSource = ObjEntregaCarga.fnSP_LIST_CHECK_POINT_2.DefaultView

            dgvCheckpoint.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnCargaAsegurada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If asignar_seleccionados(objConsultaGeneral1.curDocumento) = True Then
            Dim A As New FrmDocCliente

            A.bVentaGrabada = True
            A.iFormulario = 1
            'A.ShowDialog()

            Acceso.Asignar(A, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                A.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub


    Private Sub txtDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDocumento.TextChanged
        If bInicio = False Then
            Limpiar()
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click, btnAnterior.Click
        Mostrar2(sender, e)
    End Sub

    Private Sub Mostrar2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CType(sender, Button).Tag = 1 Then
            If objConsultaGeneral1.curVenta.Rows.Count > 0 Then
                Mostrar(0)
                lblRegistro.Text = "(1/2)"
                btnAnterior.Enabled = False
                btnSiguiente.Enabled = True
            End If
        Else
            If objConsultaGeneral1.curVenta.Rows.Count > 0 Then
                Mostrar(1)
                lblRegistro.Text = "(2/2)"
                btnAnterior.Enabled = True
                btnSiguiente.Enabled = False
            End If
        End If

        'datahelper
        'If CType(sender, Button).Tag = 1 Then
        '    If objConsultaGeneral1.curVenta.BOF = False Then
        '        objConsultaGeneral1.curVenta.MoveFirst()
        '        Mostrar()
        '        lblRegistro.Text = "(1/2)"
        '        btnAnterior.Enabled = False
        '        btnSiguiente.Enabled = True
        '    End If
        'Else
        '    If objConsultaGeneral1.curVenta.EOF = False Then
        '        objConsultaGeneral1.curVenta.MoveNext()
        '        Mostrar()
        '        lblRegistro.Text = "(2/2)"
        '        btnAnterior.Enabled = True
        '        btnSiguiente.Enabled = False
        '    End If
        'End If
    End Sub

    Private Sub Limpiar()
        Me.lblFuncionario.Text = ""
        Me.txtFechaDocumento.Text = ""
        Me.txtTipoDocumento.Text = ""
        Me.txtFormaPago.Text = ""
        Me.txtRuc1.Text = ""
        Me.txtRucCliente1.Text = ""
        Me.txtRemitente1.Text = ""
        Me.txtDireccion1.Text = ""
        Me.txtContacto1.Text = ""
        Me.txtDescuento.Text = ""
        Me.txtMemo.Text = ""
        Me.txtOrigen.Text = ""
        Me.txtDestino.Text = ""
        txtTipoEntrega.Text = ""
        Me.txtAgenciaOrigen.Text = ""
        Me.txtAgenciaDestino.Text = ""
        Me.txtTipoTarjeta.Text = ""
        Me.txtNumeroTarjeta1.Text = ""
        Me.txtSubcuenta.Text = ""
        Me.txtDireccion2.Text = ""
        Me.txtSubtotal.Text = ""
        Me.txtImpuesto.Text = ""
        Me.txtTotal.Text = ""
        Me.txtConsignado1.Text = ""
        Me.lblRecepcion.Text = ""
        '
        '09/08/2010 - 
        '
        Me.txt_nro_boleto.Text = ""        
        Me.txt_nro_boleto.Visible = False
        Me.Lab_boleto.Visible = False
        Me.Lab_tipo_carga.Text = ""
        '
        btnCargaAsegurada.Enabled = False

        dgvVenta(1, 0).Value = 0
        dgvVenta(1, 1).Value = 0
        dgvVenta(1, 2).Value = 0

        dgvVenta(2, 0).Value = "0.00"
        dgvVenta(2, 1).Value = "0.00"

        dgvVenta(3, 0).Value = "0.00"
        dgvVenta(3, 1).Value = "0.00"
        dgvVenta(3, 2).Value = "0.00"
        dgvVenta(3, 3).Value = "0.00"

        dgvVenta(4, 0).Value = "0.00"
        dgvVenta(4, 1).Value = "0.00"
        dgvVenta(4, 2).Value = "0.00"
        dgvVenta(4, 3).Value = "0.00"
        dgvVenta(4, 4).Value = "0.00"

        If dgvDocumentos.Rows.Count > 0 Then
            dgvDocumentos.Rows.Clear()
        End If

        If dgvCheckpoint.Rows.Count > 0 Then
            dgvCheckpoint.DataSource = Nothing
        End If

        btnAnterior.Enabled = False
        btnSiguiente.Enabled = False

        lblRegistro.Text = "(0/0)"
        lblEstado.Text = ""

        TxtPaginaWebCliente.Text = ""
        TxtRepresentante.Text = ""
        TxtTelefonoCliente.Text = ""
        TxtGerenteGeneral.Text = ""
        TxtCelularMsg.Text = ""
        TxtCorreoMsg.Text = ""
        txtPrefactura.Text = ""
        txtFechaEmision.Text = ""
        txtEstado.Text = ""
        txtFechaEstado.Text = ""
        TxtNroLiqDevCarg.Text = ""
        TxtFecEmiLiqDev.Text = ""
        dgvFactura.Rows.Clear()
        DgvDetalle.Rows.Clear()

        txtDocumento.Focus()
    End Sub

    Private Sub FrmConsultaGeneral2_MenuAyuda() Handles Me.MenuAyuda
        Dim sPath As String = Application.StartupPath.ToString & "\HelpTitan.chm"
        Help.ShowHelp(Me, sPath) ', HelpNavigator.TopicId, "2")
    End Sub

    Private Sub FrmConsultaGeneral2_MenuNuevo() Handles Me.MenuNuevo
        Limpiar()
        Limpiar2()
        txtDocumento.Text = ""
    End Sub

    Private Sub btnFiltrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar2.Click
        Me.Cursor = Cursors.AppStarting
        Ejecutar2()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtFechaDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaDocumento.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtOrigen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrigen.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtDestino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDestino.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtTipoDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoDocumento.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtAgenciaOrigen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAgenciaOrigen.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtAgenciaDestino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAgenciaDestino.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtFormaPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFormaPago.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtTipoTarjeta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoTarjeta.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtNumeroTarjeta1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroTarjeta1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtRuc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRuc.KeyPress
        'e.Handled = True
    End Sub

    Private Sub txtRucCliente1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRucCliente1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtSubcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubcuenta.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtRemitente1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemitente1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtConsignado1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConsignado1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtDireccion1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccion1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtDireccion2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccion2.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtContacto1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContacto1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtDescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuento.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtMemo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMemo.KeyPress
        e.Handled = True
    End Sub


    Private Sub txtSubtotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubtotal.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtImpuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtImpuesto.KeyPress
        e.Handled = True
    End Sub


    Private Sub txtTotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotal.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtRuc1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRuc1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtRemitente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemitente.KeyPress
        If sCliente = "-1" Or sCliente Is Nothing Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtConsignado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConsignado.KeyPress
        If sCliente = "-1" Or sCliente Is Nothing Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDireccionRemitente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccionRemitente.KeyPress
        If sCliente = "-1" Or sCliente Is Nothing Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDireccionConsignado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccionConsignado.KeyPress
        If sCliente = "-1" Or sCliente Is Nothing Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtContacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContacto.KeyPress
        If sCliente = "-1" Or sCliente Is Nothing Then
            e.Handled = True
        End If
    End Sub

    Private Sub LimpiarGrid()
        If dgvDocumento.Rows.Count = 0 Then Exit Sub

        lblRegistros.Text = "0"
        dgvDocumento.DataSource = Nothing
        dgvDocumento.Rows.Clear()

        With dgvDocumento
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .BackgroundColor = SystemColors.Window
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            '.ReadOnly = False
            '.AutoGenerateColumns = False
            '.ScrollBars = ScrollBars.None
            '.DataSource = dtable_Lista_Control_Comprobante
            '.VirtualMode = False

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

            Dim c1 As New DataGridViewTextBoxColumn
            With c1
                .DisplayIndex = 0
                .HeaderText = "Nº Doc."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c1)

            Dim c2 As New DataGridViewTextBoxColumn
            With c2
                .DisplayIndex = 1
                .HeaderText = "Tipo Doc."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c2)

            Dim c3 As New DataGridViewTextBoxColumn
            With c3
                .DisplayIndex = 2
                .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c3)

            Dim c4 As New DataGridViewTextBoxColumn
            With c4
                .DisplayIndex = 3
                .HeaderText = "Orígen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c4)

            Dim c5 As New DataGridViewTextBoxColumn
            With c5
                .DisplayIndex = 4
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c5)

            Dim c6 As New DataGridViewTextBoxColumn
            With c6
                .DisplayIndex = 5
                .HeaderText = "Cod. Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c6)

            Dim c7 As New DataGridViewTextBoxColumn
            With c7
                .DisplayIndex = 6
                .HeaderText = "Razón Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c7)

            Dim c8 As New DataGridViewTextBoxColumn
            With c8
                .DisplayIndex = 7
                .HeaderText = "Subcuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c8)

            Dim c9 As New DataGridViewTextBoxColumn
            With c9
                .DisplayIndex = 8
                .HeaderText = "Tipo Facturación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c9)

            Dim c10 As New DataGridViewTextBoxColumn
            With c10
                .DisplayIndex = 9
                .HeaderText = "Forma Pago"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c10)

            Dim c11 As New DataGridViewTextBoxColumn
            With c11
                .DisplayIndex = 10
                .HeaderText = "Estado Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c11)

            Dim c12 As New DataGridViewTextBoxColumn
            With c12
                .DisplayIndex = 11
                .HeaderText = "Estado Envío"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c12)

            Dim c13 As New DataGridViewTextBoxColumn
            With c13
                .DisplayIndex = 12
                .HeaderText = "Cantidad Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c13)

            Dim c14 As New DataGridViewTextBoxColumn
            With c14
                .DisplayIndex = 13
                .HeaderText = "Cantidad Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c14)

            Dim c15 As New DataGridViewTextBoxColumn
            With c15
                .DisplayIndex = 14
                .HeaderText = "Cantidad Artículo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c15)

            Dim c16 As New DataGridViewTextBoxColumn
            With c16
                .DisplayIndex = 15
                .HeaderText = "Cantidad Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c16)

            Dim c17 As New DataGridViewTextBoxColumn
            With c17
                .DisplayIndex = 16
                .HeaderText = "Precio Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c17)

            Dim c18 As New DataGridViewTextBoxColumn
            With c18
                .DisplayIndex = 17
                .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c18)

            Dim c19 As New DataGridViewTextBoxColumn
            With c19
                .DisplayIndex = 18
                .HeaderText = "Precio Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c19)

            Dim c20 As New DataGridViewTextBoxColumn
            With c20
                .DisplayIndex = 19
                .HeaderText = "Total Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c20)

            Dim c21 As New DataGridViewTextBoxColumn
            With c21
                .DisplayIndex = 20
                .HeaderText = "Precio Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c21)

            Dim c22 As New DataGridViewTextBoxColumn
            With c22
                .DisplayIndex = 21
                .HeaderText = "Monto Base"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c22)

            Dim c23 As New DataGridViewTextBoxColumn
            With c23
                .DisplayIndex = 22
                .HeaderText = "% Descuento/Incremento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c23)

            Dim c24 As New DataGridViewTextBoxColumn
            With c24
                .DisplayIndex = 23
                .HeaderText = "Monto Descuento/Incremento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c24)

            Dim c25 As New DataGridViewTextBoxColumn
            With c25
                .DisplayIndex = 24
                .HeaderText = "Memo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c25)

            Dim c26 As New DataGridViewTextBoxColumn
            With c26
                .DisplayIndex = 25
                .HeaderText = "¿Cargo?"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c26)

            Dim c27 As New DataGridViewTextBoxColumn
            With c27
                .DisplayIndex = 26
                .HeaderText = "¿Liquidado?"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c27)

            Dim c28 As New DataGridViewTextBoxColumn
            With c28
                .DisplayIndex = 27
                .HeaderText = "¿Prefacturado?"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c28)

            Dim c29 As New DataGridViewTextBoxColumn
            With c29
                .DisplayIndex = 28
                .HeaderText = "¿Facturado?"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c29)

            Dim c30 As New DataGridViewTextBoxColumn
            With c30
                .DisplayIndex = 29
                .HeaderText = "¿Facturado?"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c30)

            Dim c31 As New DataGridViewTextBoxColumn
            With c31
                .DisplayIndex = 30
                .HeaderText = "Subtotal CA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c31)

            Dim c32 As New DataGridViewTextBoxColumn
            With c32
                .DisplayIndex = 31
                .HeaderText = "Impuesto CA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c32)

            Dim c33 As New DataGridViewTextBoxColumn
            With c33
                .DisplayIndex = 32
                .HeaderText = "Total CA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c33)

            Dim c34 As New DataGridViewTextBoxColumn
            With c34
                .DisplayIndex = 33
                .HeaderText = "Subtotal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c34)

            Dim c35 As New DataGridViewTextBoxColumn
            With c35
                .DisplayIndex = 34
                .HeaderText = "Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c35)

            Dim c36 As New DataGridViewTextBoxColumn
            With c36
                .DisplayIndex = 35
                .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c36)
        End With

        txtPeso.Text = ""
        txtVolumen.Text = ""
        txts.Text = ""
        txti.Text = ""
        txtt.Text = ""

        'Cabecera()
    End Sub

    Private Sub txtUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LimpiarGrid()
    End Sub

    Private Sub dtFechaInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFechaInicio.ValueChanged
        LimpiarGrid()
    End Sub

    Private Sub dtFechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFechaFin.ValueChanged
        LimpiarGrid()
    End Sub

    Private Sub cboTipoFacturacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoFacturacion.SelectedIndexChanged, cboTipoFecha.SelectedIndexChanged
        sFecha = ""
        LimpiarGrid()
    End Sub

    Private Sub cboTipoEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoEntrega.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub cboTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDocumento.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub cboAgenciaOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgenciaOrigen.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub cboAgenciaDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgenciaDestino.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub cboTipoCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoCliente.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub cboTarjeta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTarjeta.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub txtNumeroTarjeta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroTarjeta.TextChanged
        LimpiarGrid()
    End Sub

    Private Sub txtRuc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRuc.TextChanged
        LimpiarGrid()
    End Sub

    Private Sub cboSubcuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubcuenta.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub txtRemitente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemitente.TextChanged
        If txtRemitente.Text.Trim.Length = 0 And txtDireccionRemitente.Text.Trim.Length = 0 And _
        txtConsignado.Text.Trim.Length = 0 And txtDireccionConsignado.Text.Trim.Length = 0 And txtContacto.Text.Trim.Length = 0 Then
            LimpiarFiltroOtros(False)
        Else
            LimpiarFiltroOtros(True)
        End If
        LimpiarGrid()
    End Sub

    Private Sub txtConsignado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConsignado.TextChanged
        If txtRemitente.Text.Trim.Length = 0 And txtDireccionRemitente.Text.Trim.Length = 0 And _
        txtConsignado.Text.Trim.Length = 0 And txtDireccionConsignado.Text.Trim.Length = 0 And txtContacto.Text.Trim.Length = 0 Then
            LimpiarFiltroOtros(False)
        Else
            LimpiarFiltroOtros(True)
        End If
        LimpiarGrid()
    End Sub

    Private Sub txtDireccionRemitente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDireccionRemitente.TextChanged
        If txtRemitente.Text.Trim.Length = 0 And txtDireccionRemitente.Text.Trim.Length = 0 And _
        txtConsignado.Text.Trim.Length = 0 And txtDireccionConsignado.Text.Trim.Length = 0 And txtContacto.Text.Trim.Length = 0 Then
            LimpiarFiltroOtros(False)
        Else
            LimpiarFiltroOtros(True)
        End If
        LimpiarGrid()
    End Sub

    Private Sub txtDireccionConsignado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDireccionConsignado.TextChanged
        If txtRemitente.Text.Trim.Length = 0 And txtDireccionRemitente.Text.Trim.Length = 0 And _
        txtConsignado.Text.Trim.Length = 0 And txtDireccionConsignado.Text.Trim.Length = 0 And txtContacto.Text.Trim.Length = 0 Then
            LimpiarFiltroOtros(False)
        Else
            LimpiarFiltroOtros(True)
        End If
        LimpiarGrid()
    End Sub

    Private Sub txtContacto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContacto.TextChanged
        If txtRemitente.Text.Trim.Length = 0 And txtDireccionRemitente.Text.Trim.Length = 0 And _
        txtConsignado.Text.Trim.Length = 0 And txtDireccionConsignado.Text.Trim.Length = 0 And txtContacto.Text.Trim.Length = 0 Then
            LimpiarFiltroOtros(False)
        Else
            LimpiarFiltroOtros(True)
        End If
        LimpiarGrid()
    End Sub

    Private Sub cboFuncionario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFuncionario.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub cboVentaSeguro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVentaSeguro.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub cboVentaArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVentaArticulo.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub cboDescuento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDescuento.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub cboCargos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCargos.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub Limpiar2()
        cboEstado.SelectedIndex = 0
        'txtUsuario.Text = ""
        dtFechaInicio.Value = Now.ToString
        dtFechaFin.Value = Now.ToString
        cboTipoEntrega.SelectedIndex = 0
        cboOrigen.SelectedIndex = 0
        cboDestino.SelectedIndex = 0
        cboTipoDocumento.SelectedIndex = 0
        cboAgenciaOrigen.SelectedIndex = 0
        cboAgenciaDestino.SelectedIndex = 0
        cboTipoCliente.SelectedIndex = 0
        cboTarjeta.SelectedIndex = 0
        txtNumeroTarjeta.Text = ""
        'txtRuc.Text = ""
        txtRucCliente.Text = ""
        cboSubcuenta.SelectedIndex = -1
        txtRemitente.Text = ""
        txtConsignado.Text = ""
        txtDireccionRemitente.Text = ""
        txtDireccionConsignado.Text = ""
        txtContacto.Text = ""
        txtNumeroPrefactura.Text = ""
        txtNumeroFactura.Text = ""
        txtLiquidacionCargos.Text = ""
        TxtNumeroGrt.Text = ""
        cboVentaSeguro.SelectedIndex = 0
        cboVentaArticulo.SelectedIndex = 0
        cboDescuento.SelectedIndex = 0
        cboCargos.SelectedIndex = 0

        dgvDocumento.DataSource = Nothing
        'ConfiguraGrid()
        'Cabecera()

        cboFuncionario.SelectedIndex = -1
    End Sub

    Private Sub ConfiguraDGVDocumentos()
        With dgvDocumentos
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .BackgroundColor = SystemColors.Window
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .ReadOnly = False
            .AutoGenerateColumns = False
            '.ScrollBars = ScrollBars.None
            '.DataSource = dtable_Lista_Control_Comprobante
            .VirtualMode = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

            Dim d1 As New DataGridViewTextBoxColumn
            With d1
                .DisplayIndex = 0
                .HeaderText = "Doc. Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(d1)

            Dim d2 As New DataGridViewTextBoxColumn
            With d2
                .DisplayIndex = 1
                .HeaderText = "Doc. Seguro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                '.Width = 100
            End With
            .Columns.Add(d2)
        End With
    End Sub

    Private Sub ConfiguraDGVVenta()
        With dgvVenta
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .BackgroundColor = SystemColors.Window
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .ReadOnly = False
            .AutoGenerateColumns = False
            .ScrollBars = ScrollBars.None
            '.DataSource = dtable_Lista_Control_Comprobante
            .VirtualMode = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

            Dim c1 As New DataGridViewTextBoxColumn
            With c1
                .DisplayIndex = 0
                .HeaderText = "TIPO"
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            .Columns.Add(c1)

            Dim c2 As New DataGridViewTextBoxColumn
            With c2
                .DisplayIndex = 1
                .HeaderText = "PIEZAS"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Width = 100
            End With
            .Columns.Add(c2)

            Dim c3 As New DataGridViewTextBoxColumn
            With c3
                .DisplayIndex = 2
                .HeaderText = "PESO/VOL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            .Columns.Add(c3)

            Dim c4 As New DataGridViewTextBoxColumn
            With c4
                .DisplayIndex = 3
                .HeaderText = "COSTO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With
            .Columns.Add(c4)

            Dim c5 As New DataGridViewTextBoxColumn
            With c5
                .DisplayIndex = 4
                .HeaderText = "SUBNETO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With
            .Columns.Add(c5)
            If IdProcesos = 81 Then
                Dim row0 As String() = {"CAJA 5KG", "0", "0.00", "0.00", "0.00"}
                .Rows().Add(row0)
                Dim row1 As String() = {"CAJA 10KG", "0", "0.00", "0.00", "0.00"}
                .Rows().Add(row1)
            Else
                Dim row0 As String() = {"PESO", "0", "0.00", "0.00", "0.00"}
                .Rows().Add(row0)
                Dim row1 As String() = {"VOLUMEN", "0", "0.00", "0.00", "0.00"}
                .Rows().Add(row1)
            End If
            
            Dim row2 As String() = {"SOBRE", "0", "0.00", "0.00", "0.00"}
            .Rows().Add(row2)
            Dim row3 As String() = {"BASE", "0", "0.00", "0.00", "0.00"}
            .Rows().Add(row3)
            Dim row4 As String() = {"CA", "0", "0.00", "0.00", "0.00"}
            .Rows().Add(row4)
        End With
    End Sub

    Private Function ObtieneFuncionarioIndice(ByVal funcionario As Integer) As Integer
        Dim i As Integer

        For i = 1 To coll_Funcionario.Count
            If funcionario = coll_Funcionario(i) Then
                Return i - 1
            End If
        Next
        Return -1
    End Function

    Private Sub LimpiarNorelacionados(ByVal sender As System.Object)
        If CType(sender, TextBox).Text.Trim.Length > 0 Then
            cboEstado.Enabled = False
            cboAgencia.Enabled = False
            cboUsuario.Enabled = False
            dtFechaInicio.Enabled = False
            dtFechaFin.Enabled = False
            cboTipoFecha.Enabled = False
            cboTipoFacturacion.Enabled = False
            cboTipoEntrega.Enabled = False
            cboOrigen.Enabled = False
            cboDestino.Enabled = False
            cboTipoDocumento.Enabled = False
            cboAgenciaOrigen.Enabled = False
            cboAgenciaDestino.Enabled = False
            cboTipoCliente.Enabled = False
            cboTarjeta.Enabled = False
            txtNumeroTarjeta.Enabled = False
            txtRuc.Enabled = False
            txtRucCliente.Enabled = False
            cboFuncionario.Enabled = False

            cboSubcuenta.Enabled = False
            cboSubcuenta.SelectedIndex = IIf(cboSubcuenta.Items.Count = 0, -1, 0)
            txtRemitente.ReadOnly = True
            txtDireccionRemitente.ReadOnly = True
            txtConsignado.ReadOnly = True
            txtDireccionConsignado.ReadOnly = True
            txtContacto.ReadOnly = True

            If CType(sender, TextBox).Tag = 1 Then
                txtNumeroFactura.ReadOnly = True
                TxtNumeroGrt.ReadOnly = True
                txtLiquidacionCargos.ReadOnly = True
            ElseIf CType(sender, TextBox).Tag = 2 Then
                txtNumeroPrefactura.ReadOnly = True
                TxtNumeroGrt.ReadOnly = True
                txtLiquidacionCargos.ReadOnly = True
            ElseIf CType(sender, TextBox).Tag = 3 Then
                txtNumeroPrefactura.ReadOnly = True
                TxtNumeroGrt.ReadOnly = True
                txtNumeroFactura.ReadOnly = True
            Else
                txtNumeroFactura.ReadOnly = True
                txtNumeroPrefactura.ReadOnly = True
                txtLiquidacionCargos.ReadOnly = True
            End If

            cboVentaSeguro.Enabled = False
            cboVentaArticulo.Enabled = False
            cboCargos.Enabled = False
            cboDescuento.Enabled = False

            cboVentaSeguro.SelectedIndex = 0
            cboVentaArticulo.SelectedIndex = 0
            cboCargos.SelectedIndex = 0
            cboDescuento.SelectedIndex = 0
        Else
            cboEstado.Enabled = True
            cboAgencia.Enabled = True
            cboUsuario.Enabled = True
            dtFechaInicio.Enabled = True
            dtFechaFin.Enabled = True
            cboTipoFecha.Enabled = True
            cboTipoFacturacion.Enabled = True
            cboTipoEntrega.Enabled = True
            cboOrigen.Enabled = True
            cboDestino.Enabled = True
            cboTipoDocumento.Enabled = True
            cboAgenciaOrigen.Enabled = True
            cboAgenciaDestino.Enabled = True
            cboTipoCliente.Enabled = True
            cboTarjeta.Enabled = True
            txtNumeroTarjeta.Enabled = True
            txtRuc.Enabled = True
            txtRucCliente.Enabled = True
            cboFuncionario.Enabled = True
            cboSubcuenta.Enabled = True

            txtRemitente.ReadOnly = False
            txtDireccionRemitente.ReadOnly = False
            txtConsignado.ReadOnly = False
            txtDireccionConsignado.ReadOnly = False
            txtContacto.ReadOnly = False

            If CType(sender, TextBox).Tag = 1 Then
                txtNumeroFactura.ReadOnly = False
                TxtNumeroGrt.ReadOnly = False
                txtLiquidacionCargos.ReadOnly = False
            ElseIf CType(sender, TextBox).Tag = 2 Then
                txtNumeroPrefactura.ReadOnly = False
                TxtNumeroGrt.ReadOnly = False
                txtLiquidacionCargos.ReadOnly = False
            ElseIf CType(sender, TextBox).Tag = 3 Then
                txtNumeroPrefactura.ReadOnly = False
                TxtNumeroGrt.ReadOnly = False
                txtNumeroFactura.ReadOnly = False
            Else
                txtNumeroFactura.ReadOnly = False
                txtNumeroPrefactura.ReadOnly = False
                txtLiquidacionCargos.ReadOnly = False
            End If

            cboVentaSeguro.Enabled = True
            cboVentaArticulo.Enabled = True
            cboCargos.Enabled = True
            cboDescuento.Enabled = True
        End If
    End Sub

    Private Sub LimpiarFiltroOtros(ByVal estado As Boolean)
        txtNumeroFactura.ReadOnly = estado
        txtNumeroPrefactura.ReadOnly = estado
        TxtNumeroGrt.ReadOnly = estado
        txtLiquidacionCargos.ReadOnly = estado
    End Sub

    Private Function SeleccionarEstados() As String
        Dim i As Integer
        Dim sEstado As String
        sEstado = ""
        For i = 0 To aLista.Count - 1
            sEstado = sEstado & aLista(i)
            If Not (i = aLista.Count - 1) Then
                sEstado = sEstado & ","
            End If
        Next
        sEstado = sEstado & ""
        Return sEstado
    End Function

    Private Sub cboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedIndexChanged
        LimpiarGrid()

        If (cboEstado.SelectedIndex = 3 Or cboEstado.SelectedIndex = 5) And cboTipoFecha.Items.Count > 2 Then
            'cboEstado.Items.Clear()
            'cboEstado.Items.Add("REGISTRO DOC.")
            'cboEstado.Items.Add("ESTADO(ENVIO)")
            'cboEstado.Items.Add("HISTORICO)")
            cboTipoFecha.Items.RemoveAt(2)
            cboTipoFecha.SelectedIndex = 0
        ElseIf cboTipoFecha.Items.Count = 2 And cboEstado.SelectedIndex <> 3 And cboEstado.SelectedIndex <> 5 Then
            'cboEstado.Items.Clear()
            'cboEstado.Items.Add("REGISTRO DOC.")
            'cboEstado.Items.Add("ESTADO(ENVIO)")
            'cboEstado.SelectedIndex = 0
            'cboEstado.Items.Add("HISTORICO)")
            If cboTipoFecha.Items.Count = 2 Then
                cboTipoFecha.Items.Add("HISTORICO")
            End If
        End If

        If cboEstado.SelectedIndex = 8 Then
            cboTipoFecha.SelectedIndex = 0
            cboTipoFecha.Enabled = False

            cboAgencia.Enabled = False
            cboAgencia.SelectedIndex = 0

            Dim frm As New frmEstado
            frm.Lista = aLista
            'frm.ShowDialog()
            Acceso.Asignar(frm, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.ShowDialog()
                strEstado = SeleccionarEstados()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            strEstado = ""
            aLista.Clear()

            If cboEstado.SelectedIndex = 0 Then
                cboTipoFecha.SelectedIndex = 0
                cboTipoFecha.Enabled = False
                cboAgencia.Enabled = False
                If cboAgencia.Items.Count > 0 Then
                    cboAgencia.SelectedIndex = 0
                End If
            Else
                cboTipoFecha.Enabled = True
                cboAgencia.Enabled = True
                cboAgencia.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub txtTipoEntrega_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoEntrega.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtPeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeso.KeyPress, txts.KeyPress, txti.KeyPress, txtt.KeyPress, txtVolumen.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnUbicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUbicacion.Click
        Dim frm As New FrmUbicacion
        frm.iComprobante = iComprobante
        frm.iTipoComprobante = iTipo
        'frm.ShowDialog()
        Acceso.Asignar(frm, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            frm.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cboAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgencia.SelectedIndexChanged
        If cboAgencia.SelectedIndex > 0 Then
            cboUsuario.Enabled = True
            Dim iUnidadAgenciaOrigen As Integer

            iUnidadAgenciaOrigen = coll_agencia(cboAgencia.SelectedIndex.ToString)
            Dim objUsuario As New dtoConsultaGeneral2
            If objUsuario.fnCARGAR_USUARIOS(iUnidadAgenciaOrigen) Then
                objConsultaGeneral.LlenarComboIDs(objUsuario.cur_usuarios, cboUsuario, coll_Usuarios, 0, False)
                If coll_Usuarios.Count = 0 Then
                    cboUsuario.Enabled = False
                    cboUsuario.SelectedIndex = -1
                End If
            End If
        Else
            cboUsuario.Enabled = False
            cboUsuario.SelectedIndex = -1
        End If
        LimpiarGrid()
    End Sub

    Private Sub txtOrigen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrigen.TextChanged

    End Sub

    Private Sub txtTipoEntrega_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTipoEntrega.TextChanged

    End Sub

    Private Sub cboUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUsuario.SelectedIndexChanged
        LimpiarGrid()
    End Sub

    Private Sub btnFiltrar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Ejecutar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCargaAsegurada_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargaAsegurada.Click
        If asignar_seleccionados(objConsultaGeneral1.curDocumento) = True Then
            Dim A As New FrmDocCliente

            A.bVentaGrabada = True
            A.iFormulario = 1
            'A.ShowDialog()
            Acceso.Asignar(A, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                A.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If
    End Sub

    Private Sub dgvDocumento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDocumento.CellContentClick

    End Sub

    Private Sub TxtCelularMsg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCelularMsg.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtCelularMsg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCelularMsg.TextChanged

    End Sub

    Private Sub GrbComunicación_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrbComunicación.Enter

    End Sub

    Private Sub txtPrefactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrefactura.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtPrefactura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrefactura.TextChanged

    End Sub

    Private Sub TxtPaginaWebCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPaginaWebCliente.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtPaginaWebCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPaginaWebCliente.TextChanged

    End Sub

    Private Sub TxtRepresentante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRepresentante.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtRepresentante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRepresentante.TextChanged

    End Sub

    Private Sub TxtTelefonoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelefonoCliente.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtTelefonoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTelefonoCliente.TextChanged

    End Sub

    Private Sub TxtGerenteGeneral_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGerenteGeneral.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtGerenteGeneral_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGerenteGeneral.TextChanged

    End Sub

    Private Sub TxtCorreoMsg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCorreoMsg.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtCorreoMsg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCorreoMsg.TextChanged

    End Sub

    Private Sub txtFechaEmision_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaEmision.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtFechaEmision_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaEmision.TextChanged

    End Sub

    Private Sub txtEstado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEstado.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtEstado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEstado.TextChanged

    End Sub

    Private Sub txtFechaEstado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaEstado.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtFechaEstado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaEstado.TextChanged

    End Sub

    Private Sub TxtNroLiqDevCarg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroLiqDevCarg.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtNroLiqDevCarg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroLiqDevCarg.TextChanged

    End Sub

    Private Sub TxtFecEmiLiqDev_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFecEmiLiqDev.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtFecEmiLiqDev_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFecEmiLiqDev.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dt As DataTable = System.Data.Common.DbProviderFactories.GetFactoryClasses
        dgv.DataSource = dt
    End Sub

    Private Function FiltrarDataTable(ByVal dt As DataTable, ByVal filter As String, ByVal sort As String) As DataTable
        Try
            Dim rows As DataRow()
            Dim dtNew As DataTable

            dtNew = dt.Clone()
            rows = dt.Select(filter, sort)

            For Each dr As DataRow In rows
                dtNew.ImportRow(dr)
            Next
            Return dtNew

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub Mostrar(ByVal n As Integer)
        Dim iPersona As Integer
        With objConsultaGeneral1.curVenta
            bInicio = True
            txtDocumento.Text = CType(.Rows(n).Item("nro"), String)
            bInicio = False
            lblEstado.Text = CType(.Rows(n).Item("estado"), String)
            iComprobante = CType(.Rows(n).Item("idfactura"), Integer)
            iTipoComprobante = CType(.Rows(n).Item("idtipo_comprobante"), Integer)
            iTipo = CType(.Rows(n).Item("tipo"), Integer)

            txtFechaDocumento.Text = CType(.Rows(n).Item("fecha_factura"), Date)
            txtTipoDocumento.Text = .Rows(n).Item("tipo_documento")
            txtFormaPago.Text = .Rows(n).Item("forma_pago")
            txtRuc1.Text = IIf(IsDBNull(.Rows(n).Item("numero_documento")), "", .Rows(n).Item("numero_documento"))
            txtRucCliente1.Text = .Rows(n).Item("razon_social")
            txtRemitente1.Text = IIf(IsDBNull(.Rows(n).Item("remitente")), "", .Rows(n).Item("remitente"))
            txtDireccion1.Text = .Rows(n).Item("direccion1")
            txtDireccion2.Text = .Rows(n).Item("direccion2")
            txtContacto1.Text = IIf(IsDBNull(.Rows(n).Item("contacto")), "", .Rows(n).Item("contacto"))
            txtDescuento.Text = FormatNumber(.Rows(n).Item("descuento"), 2)
            txtMemo.Text = IIf(IsDBNull(.Rows(n).Item("memo")), "", .Rows(n).Item("memo"))
            txtOrigen.Text = .Rows(n).Item("origen")
            txtDestino.Text = .Rows(n).Item("destino")
            txtAgenciaOrigen.Text = .Rows(n).Item("agencia_origen")
            txtAgenciaDestino.Text = .Rows(n).Item("agencia_destino")
            txtTipoTarjeta.Text = IIf(IsDBNull(.Rows(n).Item("tipo_tarjeta")), "", .Rows(n).Item("tipo_tarjeta"))
            txtNumeroTarjeta1.Text = IIf(IsDBNull(.Rows(n).Item("numero_tarjeta")), "", .Rows(n).Item("numero_tarjeta"))
            txtConsignado1.Text = IIf(IsDBNull(.Rows(n).Item("consignado")), "", .Rows(n).Item("consignado"))
            txtSubtotal.Text = FormatNumber(.Rows(n).Item("subtotal"), 2)
            txtImpuesto.Text = FormatNumber(.Rows(n).Item("impuesto"), 2)
            txtTotal.Text = FormatNumber(.Rows(n).Item("total"), 2)
            lblFuncionario.Text = IIf(IsDBNull(.Rows(n).Item("funcionario")), "", .Rows(n).Item("funcionario"))
            txtSubcuenta.Text = .Rows(n).Item("subcuenta")
            Me.txtTipoEntrega.Text = .Rows(n).Item("entrega")
            Me.lblRecepcion.Text = .Rows(n).Item("recepcion")
            '' 09/08/2010 
            If .Rows(n).Item("idprocesos") = 6 Then   'Carga  Acompañada 
                Me.txt_nro_boleto.Visible = True                
                Me.txt_nro_boleto.Text = IIf(IsDBNull(.Rows(n).Item("nroboleto")), "", .Rows(n).Item("nroboleto"))
                Me.Lab_boleto.Visible = True                
            Else
                Me.Lab_boleto.Visible = False
                Me.txt_nro_boleto.Visible = False
            End If
            Me.Lab_boleto.Refresh()
            Me.Lab_tipo_carga.Text = IIf(IsDBNull(.Rows(n).Item("tipo_carga")), "", .Rows(n).Item("tipo_carga"))

            '''

            dgvVenta.Columns.Clear()
            IdProcesos = .Rows(n).Item("IdProcesos")
            ConfiguraDGVVenta()
            
            dgvVenta(1, 0).Value = .Rows(n).Item("cantidad_x_peso")
            dgvVenta(1, 1).Value = .Rows(n).Item("cantidad_x_volumen")
            dgvVenta(1, 2).Value = .Rows(n).Item("cantidad_x_sobre")

            dgvVenta(2, 0).Value = .Rows(n).Item("total_peso")
            dgvVenta(2, 1).Value = .Rows(n).Item("total_volumen")

            dgvVenta(3, 0).Value = FormatNumber(IIf(IsDBNull(.Rows(n).Item("precio_x_peso")), 0, .Rows(n).Item("precio_x_peso")), 2)
            dgvVenta(3, 1).Value = FormatNumber(.Rows(n).Item("precio_x_volumen"), 2)
            dgvVenta(3, 2).Value = FormatNumber(.Rows(n).Item("precio_x_sobre"), 2)
            dgvVenta(3, 3).Value = FormatNumber(.Rows(n).Item("monto_base"), 2)

            If .Rows(n).Item("IdProcesos") = 81 Then
                dgvVenta(4, 0).Value = FormatNumber(IIf(IsDBNull(.Rows(n).Item("cantidad_x_peso")), 0, .Rows(n).Item("cantidad_x_peso")) * IIf(IsDBNull(.Rows(n).Item("precio_x_peso")), 0, .Rows(n).Item("precio_x_peso")), 2)
                dgvVenta(4, 1).Value = FormatNumber(.Rows(n).Item("cantidad_x_volumen") * .Rows(n).Item("precio_x_volumen"), 2)
            Else
                dgvVenta(4, 0).Value = FormatNumber(IIf(IsDBNull(.Rows(n).Item("total_peso")), 0, .Rows(n).Item("total_peso")) * IIf(IsDBNull(.Rows(n).Item("precio_x_peso")), 0, .Rows(n).Item("precio_x_peso")), 2)
                dgvVenta(4, 1).Value = FormatNumber(.Rows(n).Item("total_volumen") * .Rows(n).Item("precio_x_volumen"), 2)
            End If
            dgvVenta(4, 2).Value = FormatNumber(.Rows(n).Item("cantidad_x_sobre") * .Rows(n).Item("precio_x_sobre"), 2)
            dgvVenta(4, 3).Value = FormatNumber(.Rows(n).Item("monto_base"), 2)
            dgvVenta(4, 4).Value = FormatNumber(IIf(IsDBNull(.Rows(n).Item("sub_total_ca")), 0, .Rows(n).Item("sub_total_ca")), 2)

            iPersona = .Rows(n).Item("idpersona")

            If Val(IIf(IsDBNull(.Rows(n).Item("sub_total_ca")), 0, .Rows(n).Item("sub_total_ca"))) > 0 Then
                btnCargaAsegurada.Enabled = True
            Else
                btnCargaAsegurada.Enabled = False
            End If

            'Actualiza Separador Detalle
            LblNombreCliente.Text = .Rows(n).Item("razon_social")
            TxtNroLiqDevCarg.Text = IIf(Val(.Rows(n).Item("cargo")) = 0, "", .Rows(n).Item("cargo"))
            TxtFecEmiLiqDev.Text = IIf(IsDBNull(.Rows(n).Item("cargofecha")), " ", .Rows(n).Item("cargofecha"))
        End With

        Dim dt As DataTable = objConsultaGeneral1.curDocumento
        'dt = FiltrarDataTable(objConsultaGeneral1.curDocumento, "idtipo_comprobante=" & iTipoComprobante & "", "")
        dt = FiltrarDataTable(objConsultaGeneral1.curDocumento, "idguias_envio=" & iComprobante & "", "")
        With dt 'objConsultaGeneral1.curDocumento
            dgvDocumentos.Rows.Clear()
            If .Rows.Count > 0 Then
                Dim iFila1 As Integer = 0
                Dim iFila2 As Integer = 0
                For Each obj As DataRow In .Rows
                    dgvDocumentos.Rows.Add()
                    If .Rows(0).Item("PORCEN") > 0 Then
                        dgvDocumentos(1, iFila1).Value = obj.Item(3) & "-" & obj.Item(4)
                        iFila1 += 1
                    Else
                        dgvDocumentos(0, iFila2).Value = obj.Item(3) & "-" & obj.Item(4)
                        iFila2 += 1
                    End If
                Next
                'Do While .BOF = False And .EOF = False
                '    dgvDocumentos.Rows.Add()
                '    If .Fields("PORCEN").Value > 0 Then
                '        dgvDocumentos(1, iFila1).Value = .Fields(3).Value & "-" & .Fields(4).Value
                '        iFila1 += 1
                '    Else
                '        dgvDocumentos(0, iFila2).Value = .Fields(3).Value & "-" & .Fields(4).Value
                '        iFila2 += 1
                '    End If
                '    .MoveNext()
                'Loop
                '.MoveFirst()
            End If
        End With

        'Checkpoint
        MostrarCheckPoint()

        'Cliente
        With objConsultaGeneral1.curCliente
            If .Rows.Count > n Then
                TxtGerenteGeneral.Text = Trim(.Rows(n).Item(0))
                TxtRepresentante.Text = Trim(.Rows(n).Item(1))
                TxtPaginaWebCliente.Text = Trim(.Rows(n).Item(2))
                TxtTelefonoCliente.Text = Trim(.Rows(n).Item(3))
            End If
        End With

        'email
        Dim dtEmail As DataTable = objConsultaGeneral1.curEmail
        'dtEmail = objConsultaGeneral1.curEmail
        With dtEmail 'objConsultaGeneral1.curEmail
            dtEmail = FiltrarDataTable(objConsultaGeneral1.curEmail, "idpersona=" & iPersona & "", "")
            Dim s As String = ""
            If .Rows.Count > 0 Then
                For Each obj As DataRow In .Rows
                    s = s & obj.Item(0) & ","
                Next
                s = s.Substring(0, s.ToString.Trim.Length - 1)
            Else
                s = ""
            End If
            TxtCorreoMsg.Text = s
        End With

        'cel
        Dim dtCel As DataTable = objConsultaGeneral1.curCel
        dtCel = FiltrarDataTable(objConsultaGeneral1.curCel, "idpersona=" & iPersona & "", "")
        With dtCel 'objConsultaGeneral1.curCel
            Dim s As String = ""
            If .Rows.Count > 0 Then
                For Each obj As DataRow In .Rows
                    s = s & obj.Item(2) & " " & obj.Item(1) & ","
                Next
                s = s.Substring(0, s.ToString.Trim.Length - 1)
            End If
            TxtCelularMsg.Text = s
        End With

        'Prefactura
        With objConsultaGeneral1.curPrefactura
            If .Rows.Count > n Then
                txtPrefactura.Text = Trim(.Rows(n).Item(0))
                txtFechaEmision.Text = Trim(.Rows(n).Item(1))
                txtEstado.Text = Trim(.Rows(n).Item(2))
                txtFechaEstado.Text = Trim(.Rows(n).Item(3))
            Else
                txtPrefactura.Text = ""
                txtFechaEmision.Text = ""
                txtEstado.Text = ""
                txtFechaEstado.Text = ""
            End If
        End With

        'Factura
        dgvFactura.Rows.Clear()
        Dim dtFactura As DataTable = objConsultaGeneral1.curFactura
        With dtFactura 'objConsultaGeneral1.curFactura
            If .Rows.Count > 0 And IsDBNull(.Rows(0).Item(0)) = False Then
                dtFactura = FiltrarDataTable(objConsultaGeneral1.curFactura, "idpersona=" & iPersona & "", "")
                For Each obj As DataRow In .Rows
                    dgvFactura.Rows.Add()
                    dgvFactura.Rows(dgvFactura.Rows.Count - 1).Cells(1).Value = Trim(obj.Item(0))
                    dgvFactura.Rows(dgvFactura.Rows.Count - 1).Cells(2).Value = Trim(obj.Item(1))
                    dgvFactura.Rows(dgvFactura.Rows.Count - 1).Cells(3).Value = Trim(obj.Item(2))
                    dgvFactura.Rows(dgvFactura.Rows.Count - 1).Cells(0).Value = IIf(IsDBNull(obj.Item(3)), "", obj.Item(3))
                Next
            End If
        End With

        'Detalle de Bultos
        DgvDetalle.Rows.Clear()
        Dim dtBultos As DataTable = objConsultaGeneral1.curBultos
        dtBultos = FiltrarDataTable(objConsultaGeneral1.curBultos, "idtipo_comprobante=" & iTipoComprobante & " and idcomprobante=" & iComprobante & "", "")
        With dtBultos 'objConsultaGeneral1.curBultos
            If .Rows.Count > 0 Then
                For Each obj As DataRow In .Rows
                    DgvDetalle.Rows.Add()
                    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(0).Value = Trim(obj.Item(2))
                    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(1).Value = Trim(obj.Item(3))
                    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(2).Value = Trim(obj.Item(4))
                    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(3).Value = Trim(obj.Item(5))
                    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(4).Value = Trim(obj.Item(6))
                    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(5).Value = Trim(obj.Item(7))
                Next
            End If
        End With

        'datahelper
        '    With objConsultaGeneral1.curVenta
        '        bInicio = True
        '        txtDocumento.Text = CType(.Fields("nro").Value, String)
        '        bInicio = False
        '        lblEstado.Text = CType(.Fields("estado").Value, String)
        '        iComprobante = CType(.Fields("idfactura").Value, Integer)
        '        iTipoComprobante = CType(.Fields("idtipo_comprobante").Value, Integer)
        '        iTipo = CType(.Fields("tipo").Value, Integer)

        '        txtFechaDocumento.Text = CType(.Fields("fecha_factura").Value, Date)
        '        txtTipoDocumento.Text = .Fields("tipo_documento").Value
        '        txtFormaPago.Text = .Fields("forma_pago").Value
        '        txtRuc1.Text = IIf(IsDBNull(.Fields("numero_documento").Value), "", .Fields("numero_documento").Value)
        '        txtRucCliente1.Text = .Fields("razon_social").Value
        '        txtRemitente1.Text = .Fields("remitente").Value
        '        txtDireccion1.Text = .Fields("direccion1").Value
        '        txtDireccion2.Text = .Fields("direccion2").Value
        '        txtContacto1.Text = IIf(IsDBNull(.Fields("contacto").Value), "", .Fields("contacto").Value)
        '        txtDescuento.Text = FormatNumber(.Fields("descuento").Value, 2)
        '        txtMemo.Text = IIf(IsDBNull(.Fields("memo").Value), "", .Fields("memo").Value)
        '        txtOrigen.Text = .Fields("origen").Value
        '        txtDestino.Text = .Fields("destino").Value
        '        txtAgenciaOrigen.Text = .Fields("agencia_origen").Value
        '        txtAgenciaDestino.Text = .Fields("agencia_destino").Value
        '        txtTipoTarjeta.Text = IIf(IsDBNull(.Fields("tipo_tarjeta").Value), "", .Fields("tipo_tarjeta").Value)
        '        txtNumeroTarjeta1.Text = IIf(IsDBNull(.Fields("numero_tarjeta").Value), "", .Fields("numero_tarjeta").Value)
        '        txtConsignado1.Text = IIf(IsDBNull(.Fields("consignado").Value), "", .Fields("consignado").Value)
        '        txtSubtotal.Text = FormatNumber(.Fields("subtotal").Value, 2)
        '        txtImpuesto.Text = FormatNumber(.Fields("impuesto").Value, 2)
        '        txtTotal.Text = FormatNumber(.Fields("total").Value, 2)
        '        lblFuncionario.Text = IIf(IsDBNull(.Fields("funcionario").Value), "", .Fields("funcionario").Value)
        '        txtSubcuenta.Text = .Fields("subcuenta").Value
        '        Me.txtTipoEntrega.Text = .Fields("entrega").Value
        '        Me.lblRecepcion.Text = .Fields("recepcion").Value

        '        dgvVenta(1, 0).Value = .Fields("cantidad_x_peso").Value
        '        dgvVenta(1, 1).Value = .Fields("cantidad_x_volumen").Value
        '        dgvVenta(1, 2).Value = .Fields("cantidad_x_sobre").Value

        '        dgvVenta(2, 0).Value = .Fields("total_peso").Value
        '        dgvVenta(2, 1).Value = .Fields("total_volumen").Value

        '        dgvVenta(3, 0).Value = FormatNumber(IIf(IsDBNull(.Fields("precio_x_peso").Value), 0, .Fields("precio_x_peso").Value), 2)
        '        dgvVenta(3, 1).Value = FormatNumber(.Fields("precio_x_volumen").Value, 2)
        '        dgvVenta(3, 2).Value = FormatNumber(.Fields("precio_x_sobre").Value, 2)
        '        dgvVenta(3, 3).Value = FormatNumber(.Fields("monto_base").Value, 2)

        '        dgvVenta(4, 0).Value = FormatNumber(IIf(IsDBNull(.Fields("total_peso").Value), 0, .Fields("total_peso").Value) * IIf(IsDBNull(.Fields("precio_x_peso").Value), 0, .Fields("precio_x_peso").Value), 2)
        '        dgvVenta(4, 1).Value = FormatNumber(.Fields("total_volumen").Value * .Fields("precio_x_volumen").Value, 2)
        '        dgvVenta(4, 2).Value = FormatNumber(.Fields("cantidad_x_sobre").Value * .Fields("precio_x_sobre").Value, 2)
        '        dgvVenta(4, 3).Value = FormatNumber(.Fields("monto_base").Value, 2)
        '        dgvVenta(4, 4).Value = FormatNumber(IIf(IsDBNull(.Fields("sub_total_ca").Value), 0, .Fields("sub_total_ca").Value), 2)

        '        If Val(IIf(IsDBNull(.Fields("sub_total_ca").Value), 0, .Fields("sub_total_ca").Value)) > 0 Then
        '            btnCargaAsegurada.Enabled = True
        '        Else
        '            btnCargaAsegurada.Enabled = False
        '        End If

        '        'Actualiza Separador Detalle
        '        LblNombreCliente.Text = .Fields("razon_social").Value
        '        TxtNroLiqDevCarg.Text = IIf(Val(.Fields("cargo").Value) = 0, "", .Fields("cargo").Value)
        '        TxtFecEmiLiqDev.Text = IIf(IsDBNull(.Fields("cargofecha").Value), " ", .Fields("cargofecha").Value)
        '    End With

        '    With objConsultaGeneral1.curDocumento
        '        dgvDocumentos.Rows.Clear()
        '        If .State <> 0 Then
        '            If .BOF = False And .EOF = False Then
        '                Dim iFila1 As Integer = 0
        '                Dim iFila2 As Integer = 0
        '                Do While .BOF = False And .EOF = False
        '                    dgvDocumentos.Rows.Add()
        '                    If .Fields("PORCEN").Value > 0 Then
        '                        dgvDocumentos(1, iFila1).Value = .Fields(3).Value & "-" & .Fields(4).Value
        '                        iFila1 += 1
        '                    Else
        '                        dgvDocumentos(0, iFila2).Value = .Fields(3).Value & "-" & .Fields(4).Value
        '                        iFila2 += 1
        '                    End If
        '                    .MoveNext()
        '                Loop
        '                .MoveFirst()
        '            End If
        '        End If
        '    End With

        '    'Checkpoint
        '    MostrarCheckPoint()

        '    'Cliente
        '    With objConsultaGeneral1.curCliente
        '        If .State <> 0 Then
        '            If .BOF = False And .EOF = False Then
        '                TxtGerenteGeneral.Text = Trim(.Fields(0).Value)
        '                TxtRepresentante.Text = Trim(.Fields(1).Value)
        '                TxtPaginaWebCliente.Text = Trim(.Fields(2).Value)
        '                TxtTelefonoCliente.Text = Trim(.Fields(3).Value)
        '            End If
        '        End If
        '    End With

        '    'email
        '    With objConsultaGeneral1.curEmail
        '        Dim s As String = ""
        '        If .State <> 0 Then
        '            If .BOF = False And .EOF = False Then
        '                Do While .BOF = False And .EOF = False
        '                    s = s & .Fields(0).Value & ","
        '                    .MoveNext()
        '                Loop
        '                s = s.Substring(0, s.ToString.Trim.Length - 1)
        '            End If
        '        End If
        '        TxtCorreoMsg.Text = s
        '    End With

        '    'cel
        '    With objConsultaGeneral1.curCel
        '        Dim s As String = ""
        '        If .State <> 0 Then
        '            If .BOF = False And .EOF = False Then
        '                Do While .BOF = False And .EOF = False
        '                    s = s & .Fields(2).Value & " " & .Fields(1).Value & ","
        '                    .MoveNext()
        '                Loop
        '                s = s.Substring(0, s.ToString.Trim.Length - 1)
        '            End If
        '        End If
        '        TxtCelularMsg.Text = s
        '    End With

        '    'Prefactura
        '    With objConsultaGeneral1.curPrefactura
        '        If .State <> 0 Then
        '            If .BOF = False And .EOF = False Then
        '                txtPrefactura.Text = Trim(.Fields(0).Value)
        '                txtFechaEmision.Text = Trim(.Fields(1).Value)
        '                txtEstado.Text = Trim(.Fields(2).Value)
        '                txtFechaEstado.Text = Trim(.Fields(3).Value)
        '            End If
        '        End If
        '    End With

        '    'Factura
        '    dgvFactura.Rows.Clear()
        '    With objConsultaGeneral1.curFactura
        '        If .State <> 0 Then
        '            If .BOF = False And .EOF = False Then
        '                Do While .BOF = False And .EOF = False
        '                    dgvFactura.Rows.Add()
        '                    dgvFactura.Rows(dgvFactura.Rows.Count - 1).Cells(1).Value = Trim(.Fields(0).Value)
        '                    dgvFactura.Rows(dgvFactura.Rows.Count - 1).Cells(2).Value = Trim(.Fields(1).Value)
        '                    dgvFactura.Rows(dgvFactura.Rows.Count - 1).Cells(3).Value = Trim(.Fields(2).Value)
        '                    dgvFactura.Rows(dgvFactura.Rows.Count - 1).Cells(0).Value = IIf(IsDBNull(.Fields(3).Value), "", .Fields(3).Value)
        '                    .MoveNext()
        '                Loop
        '            End If
        '        End If
        '    End With

        '    'Detalle de Bultos
        '    DgvDetalle.Rows.Clear()
        '    With objConsultaGeneral1.curBultos
        '        If .State <> 0 Then
        '            If .BOF = False And .EOF = False Then
        '                Do While .BOF = False And .EOF = False
        '                    DgvDetalle.Rows.Add()
        '                    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(0).Value = Trim(.Fields(0).Value)
        '                    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(1).Value = Trim(.Fields(1).Value)
        '                    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(2).Value = Trim(.Fields(2).Value)
        '                    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(3).Value = Trim(.Fields(3).Value)
        '                    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(4).Value = Trim(.Fields(4).Value)
        '                    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(5).Value = Trim(.Fields(5).Value)
        '                    .MoveNext()
        '                Loop
        '            End If
        '        End If
        '    End With
    End Sub

    'Private Sub Mostrar22()
    'With objConsultaGeneral.curVenta
    '    dgvDocumento.DataSource = Nothing
    '    If .State <> 0 Then
    '        .MoveFirst()
    '        Dim iFila As Integer = 0
    '        If .BOF = False And .EOF = False Then
    '            With dgvDocumento
    '                .AllowUserToAddRows = False
    '                .AllowUserToDeleteRows = False
    '                .AllowUserToOrderColumns = False
    '                .BackgroundColor = SystemColors.Window
    '                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)

    '                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '                .RowHeadersWidth = 10
    '                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
    '                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
    '                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
    '                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

    '                Dim c1 As New DataGridViewTextBoxColumn
    '                With c1
    '                    .DisplayIndex = 0
    '                    .HeaderText = "Nº Doc."
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c1)

    '                Dim c2 As New DataGridViewTextBoxColumn
    '                With c2
    '                    .DisplayIndex = 1
    '                    .HeaderText = "Tipo Doc."
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c2)

    '                Dim c3 As New DataGridViewTextBoxColumn
    '                With c3
    '                    .DisplayIndex = 2
    '                    .HeaderText = "Fecha"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c3)

    '                Dim c4 As New DataGridViewTextBoxColumn
    '                With c4
    '                    .DisplayIndex = 3
    '                    .HeaderText = "Orígen"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c4)

    '                Dim c5 As New DataGridViewTextBoxColumn
    '                With c5
    '                    .DisplayIndex = 4
    '                    .HeaderText = "Destino"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c5)

    '                Dim c6 As New DataGridViewTextBoxColumn
    '                With c6
    '                    .DisplayIndex = 5
    '                    .HeaderText = "Cod. Cliente"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c6)

    '                Dim c7 As New DataGridViewTextBoxColumn
    '                With c7
    '                    .DisplayIndex = 6
    '                    .HeaderText = "Razón Social"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c7)

    '                Dim c8 As New DataGridViewTextBoxColumn
    '                With c8
    '                    .DisplayIndex = 7
    '                    .HeaderText = "Subcuenta"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c8)

    '                Dim c9 As New DataGridViewTextBoxColumn
    '                With c9
    '                    .DisplayIndex = 8
    '                    .HeaderText = "Tipo Facturación"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c9)

    '                Dim c10 As New DataGridViewTextBoxColumn
    '                With c10
    '                    .DisplayIndex = 9
    '                    .HeaderText = "Forma Pago"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c10)

    '                Dim c11 As New DataGridViewTextBoxColumn
    '                With c11
    '                    .DisplayIndex = 10
    '                    .HeaderText = "Estado Documento"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c11)

    '                Dim c12 As New DataGridViewTextBoxColumn
    '                With c12
    '                    .DisplayIndex = 11
    '                    .HeaderText = "Estado Envío"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c12)

    '                Dim c13 As New DataGridViewTextBoxColumn
    '                With c13
    '                    .DisplayIndex = 12
    '                    .HeaderText = "Cantidad Peso"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c13)

    '                Dim c14 As New DataGridViewTextBoxColumn
    '                With c14
    '                    .DisplayIndex = 13
    '                    .HeaderText = "Cantidad Volumen"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c14)

    '                Dim c15 As New DataGridViewTextBoxColumn
    '                With c15
    '                    .DisplayIndex = 14
    '                    .HeaderText = "Cantidad Artículo"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c15)

    '                Dim c16 As New DataGridViewTextBoxColumn
    '                With c16
    '                    .DisplayIndex = 15
    '                    .HeaderText = "Cantidad Sobre"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c16)

    '                Dim c17 As New DataGridViewTextBoxColumn
    '                With c17
    '                    .DisplayIndex = 16
    '                    .HeaderText = "Precio Sobre"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c17)

    '                Dim c18 As New DataGridViewTextBoxColumn
    '                With c18
    '                    .DisplayIndex = 17
    '                    .HeaderText = "Total Peso"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c18)

    '                Dim c19 As New DataGridViewTextBoxColumn
    '                With c19
    '                    .DisplayIndex = 18
    '                    .HeaderText = "Precio Peso"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c19)

    '                Dim c20 As New DataGridViewTextBoxColumn
    '                With c20
    '                    .DisplayIndex = 19
    '                    .HeaderText = "Total Volumen"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c20)

    '                Dim c21 As New DataGridViewTextBoxColumn
    '                With c21
    '                    .DisplayIndex = 20
    '                    .HeaderText = "Precio Volumen"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c21)

    '                Dim c22 As New DataGridViewTextBoxColumn
    '                With c22
    '                    .DisplayIndex = 21
    '                    .HeaderText = "Monto Base"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c22)

    '                Dim c23 As New DataGridViewTextBoxColumn
    '                With c23
    '                    .DisplayIndex = 22
    '                    .HeaderText = "% Descuento/Incremento"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c23)

    '                Dim c24 As New DataGridViewTextBoxColumn
    '                With c24
    '                    .DisplayIndex = 23
    '                    .HeaderText = "Monto Descuento/Incremento"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c24)

    '                Dim c25 As New DataGridViewTextBoxColumn
    '                With c25
    '                    .DisplayIndex = 24
    '                    .HeaderText = "Memo"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c25)

    '                Dim c26 As New DataGridViewTextBoxColumn
    '                With c26
    '                    .DisplayIndex = 25
    '                    .HeaderText = "¿Cargo?"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c26)

    '                Dim c27 As New DataGridViewTextBoxColumn
    '                With c27
    '                    .DisplayIndex = 26
    '                    .HeaderText = "¿Liquidado?"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c27)

    '                Dim c28 As New DataGridViewTextBoxColumn
    '                With c28
    '                    .DisplayIndex = 27
    '                    .HeaderText = "¿Prefacturado?"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c28)

    '                Dim c29 As New DataGridViewTextBoxColumn
    '                With c29
    '                    .DisplayIndex = 28
    '                    .HeaderText = "¿Facturado?"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c29)

    '                Dim c30 As New DataGridViewTextBoxColumn
    '                With c30
    '                    .DisplayIndex = 29
    '                    .HeaderText = "Subtotal CA"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c30)

    '                Dim c31 As New DataGridViewTextBoxColumn
    '                With c31
    '                    .DisplayIndex = 30
    '                    .HeaderText = "Impuesto CA"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c31)

    '                Dim c32 As New DataGridViewTextBoxColumn
    '                With c32
    '                    .DisplayIndex = 31
    '                    .HeaderText = "Total CA"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c32)

    '                Dim c33 As New DataGridViewTextBoxColumn
    '                With c33
    '                    .DisplayIndex = 32
    '                    .HeaderText = "Subtotal"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c33)

    '                Dim c34 As New DataGridViewTextBoxColumn
    '                With c34
    '                    .DisplayIndex = 33
    '                    .HeaderText = "Impuesto"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c34)

    '                Dim c35 As New DataGridViewTextBoxColumn
    '                With c35
    '                    .DisplayIndex = 34
    '                    .HeaderText = "Total"
    '                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '                    .DefaultCellStyle.ForeColor = Color.Black
    '                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    .ReadOnly = True
    '                End With
    '                .Columns.Add(c35)
    '            End With

    '            'Dim dv As New DataView
    '            'Dim dt As New DataTable
    '            'dt = RecordSet_a_DataSet(objConsultaGeneral.curVenta)
    '            'dv = dt.DefaultView
    '            'dgvDocumento.DataSource = dv

    '            Dim iPeso As Double
    '            Dim iVolumen As Double
    '            Dim iSubtotal As Double
    '            Dim iImpuesto As Double
    '            Dim iTotal As Double

    '            Do While .BOF = False And .EOF = False
    '                iPeso += .Fields("cantidad_peso").Value
    '                iVolumen += .Fields("cantidad_volumen").Value
    '                iSubtotal += .Fields("subtotal").Value
    '                iImpuesto += .Fields("impuesto").Value
    '                iTotal += .Fields("total").Value

    '                dgvDocumento.Rows.Add()
    '                dgvDocumento(0, iFila).Value = .Fields(0).Value
    '                dgvDocumento(1, iFila).Value = .Fields(1).Value
    '                dgvDocumento(2, iFila).Value = .Fields(2).Value
    '                dgvDocumento(3, iFila).Value = .Fields(3).Value
    '                dgvDocumento(4, iFila).Value = .Fields(4).Value
    '                dgvDocumento(5, iFila).Value = .Fields(5).Value
    '                dgvDocumento(6, iFila).Value = .Fields(6).Value
    '                dgvDocumento(7, iFila).Value = .Fields(7).Value
    '                dgvDocumento(8, iFila).Value = .Fields(8).Value

    '                dgvDocumento(9, iFila).Value = .Fields(9).Value
    '                dgvDocumento(10, iFila).Value = .Fields(10).Value
    '                dgvDocumento(11, iFila).Value = .Fields(11).Value
    '                dgvDocumento(12, iFila).Value = .Fields(12).Value
    '                dgvDocumento(13, iFila).Value = .Fields(13).Value
    '                dgvDocumento(14, iFila).Value = .Fields(14).Value
    '                dgvDocumento(15, iFila).Value = .Fields(15).Value
    '                dgvDocumento(16, iFila).Value = .Fields(16).Value
    '                dgvDocumento(17, iFila).Value = .Fields(17).Value
    '                dgvDocumento(18, iFila).Value = .Fields(18).Value
    '                dgvDocumento(19, iFila).Value = .Fields(19).Value
    '                dgvDocumento(20, iFila).Value = .Fields(20).Value
    '                dgvDocumento(21, iFila).Value = .Fields(21).Value
    '                dgvDocumento(22, iFila).Value = .Fields(22).Value
    '                dgvDocumento(23, iFila).Value = .Fields(23).Value
    '                dgvDocumento(24, iFila).Value = .Fields(24).Value
    '                dgvDocumento(25, iFila).Value = .Fields(25).Value
    '                dgvDocumento(26, iFila).Value = .Fields(26).Value
    '                dgvDocumento(27, iFila).Value = .Fields(27).Value
    '                dgvDocumento(28, iFila).Value = .Fields(28).Value
    '                dgvDocumento(29, iFila).Value = .Fields(29).Value
    '                dgvDocumento(30, iFila).Value = .Fields(30).Value
    '                dgvDocumento(31, iFila).Value = .Fields(31).Value
    '                dgvDocumento(32, iFila).Value = FormatNumber(.Fields(32).Value, 2)
    '                dgvDocumento(33, iFila).Value = FormatNumber(.Fields(33).Value, 2)
    '                dgvDocumento(34, iFila).Value = FormatNumber(.Fields(34).Value, 2)

    '                iFila += 1
    '                .MoveNext()
    '            Loop
    '            txtPeso.Text = FormatNumber(iPeso, 0)
    '            txtVolumen.Text = FormatNumber(iVolumen, 0)
    '            txts.Text = FormatNumber(iSubtotal, 2)
    '            txti.Text = FormatNumber(iImpuesto, 2)
    '            txtt.Text = FormatNumber(iTotal, 2)
    '            '.MoveFirst()
    '            'objHilo.Abort()
    '        End If
    '    End If
    'End With
    'End Sub

    Private Sub Mostrar22()
        With objConsultaGeneral.curVenta
            dgvDocumento.DataSource = Nothing
            '.MoveFirst()
            Dim iFila As Integer = 0
            If .Rows.Count > 0 Then
                With dgvDocumento
                    .AllowUserToAddRows = False
                    .AllowUserToDeleteRows = False
                    .AllowUserToOrderColumns = False
                    .BackgroundColor = SystemColors.Window
                    .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)

                    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    .RowHeadersWidth = 10
                    .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                    .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                    .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                    .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

                    Dim c1 As New DataGridViewTextBoxColumn
                    With c1
                        .DisplayIndex = 0
                        .HeaderText = "Nº Doc."
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c1)

                    Dim c2 As New DataGridViewTextBoxColumn
                    With c2
                        .DisplayIndex = 1
                        .HeaderText = "Tipo Doc."
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c2)

                    Dim c2_1 As New DataGridViewTextBoxColumn
                    With c2_1
                        .DisplayIndex = 2
                        .HeaderText = "Tipo Carga"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c2_1)


                    Dim c3 As New DataGridViewTextBoxColumn
                    With c3
                        .DisplayIndex = 3
                        .HeaderText = "Fecha"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c3)

                    Dim c4 As New DataGridViewTextBoxColumn
                    With c4
                        .DisplayIndex = 4
                        .HeaderText = "Orígen"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c4)

                    Dim c5 As New DataGridViewTextBoxColumn
                    With c5
                        .DisplayIndex = 5
                        .HeaderText = "Destino"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c5)

                    Dim c6 As New DataGridViewTextBoxColumn
                    With c6
                        .DisplayIndex = 6
                        .HeaderText = "Cod. Cliente"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c6)

                    Dim c7 As New DataGridViewTextBoxColumn
                    With c7
                        .DisplayIndex = 7
                        .HeaderText = "Razón Social"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c7)

                    Dim c7_1 As New DataGridViewTextBoxColumn
                    With c7_1
                        .DisplayIndex = 8
                        .HeaderText = "Consignado"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c7_1)


                    Dim c8 As New DataGridViewTextBoxColumn
                    With c8
                        .DisplayIndex = 9
                        .HeaderText = "Subcuenta"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c8)

                    Dim c9 As New DataGridViewTextBoxColumn
                    With c9
                        .DisplayIndex = 10
                        .HeaderText = "Tipo Facturación"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c9)

                    Dim c10 As New DataGridViewTextBoxColumn
                    With c10
                        .DisplayIndex = 11
                        .HeaderText = "Forma Pago"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c10)

                    Dim c11 As New DataGridViewTextBoxColumn
                    With c11
                        .DisplayIndex = 12
                        .HeaderText = "Estado Documento"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c11)

                    Dim c12 As New DataGridViewTextBoxColumn
                    With c12
                        .DisplayIndex = 13
                        .HeaderText = "Estado Envío"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c12)

                    Dim c13 As New DataGridViewTextBoxColumn
                    With c13
                        .DisplayIndex = 14
                        .HeaderText = "Cantidad Peso"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c13)

                    Dim c14 As New DataGridViewTextBoxColumn
                    With c14
                        .DisplayIndex = 15
                        .HeaderText = "Cantidad Volumen"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c14)

                    Dim c15 As New DataGridViewTextBoxColumn
                    With c15
                        .DisplayIndex = 16
                        .HeaderText = "Cantidad Artículo"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c15)

                    Dim c16 As New DataGridViewTextBoxColumn
                    With c16
                        .DisplayIndex = 17
                        .HeaderText = "Cantidad Sobre"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c16)

                    Dim c17 As New DataGridViewTextBoxColumn
                    With c17
                        .DisplayIndex = 18
                        .HeaderText = "Precio Sobre"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c17)

                    Dim c18 As New DataGridViewTextBoxColumn
                    With c18
                        .DisplayIndex = 19
                        .HeaderText = "Total Peso"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c18)

                    Dim c19 As New DataGridViewTextBoxColumn
                    With c19
                        .DisplayIndex = 20
                        .HeaderText = "Precio Peso"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c19)

                    Dim c20 As New DataGridViewTextBoxColumn
                    With c20
                        .DisplayIndex = 21
                        .HeaderText = "Total Volumen"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c20)

                    Dim c21 As New DataGridViewTextBoxColumn
                    With c21
                        .DisplayIndex = 22
                        .HeaderText = "Precio Volumen"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c21)

                    Dim c22 As New DataGridViewTextBoxColumn
                    With c22
                        .DisplayIndex = 23
                        .HeaderText = "Monto Base"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c22)

                    Dim c23 As New DataGridViewTextBoxColumn
                    With c23
                        .DisplayIndex = 24
                        .HeaderText = "% Descuento/Incremento"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c23)

                    Dim c24 As New DataGridViewTextBoxColumn
                    With c24
                        .DisplayIndex = 25
                        .HeaderText = "Monto Descuento/Incremento"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c24)

                    Dim c25 As New DataGridViewTextBoxColumn
                    With c25
                        .DisplayIndex = 26
                        .HeaderText = "Memo"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c25)

                    Dim c26 As New DataGridViewTextBoxColumn
                    With c26
                        .DisplayIndex = 27
                        .HeaderText = "¿Cargo?"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c26)

                    Dim c27 As New DataGridViewTextBoxColumn
                    With c27
                        .DisplayIndex = 28
                        .HeaderText = "¿Liquidado?"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c27)

                    Dim c28 As New DataGridViewTextBoxColumn
                    With c28
                        .DisplayIndex = 29
                        .HeaderText = "¿Prefacturado?"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c28)

                    Dim c29 As New DataGridViewTextBoxColumn
                    With c29
                        .DisplayIndex = 30
                        .HeaderText = "¿Facturado?"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .ReadOnly = True
                    End With
                    .Columns.Add(c29)

                    Dim c30 As New DataGridViewTextBoxColumn
                    With c30
                        .DisplayIndex = 31
                        .HeaderText = "Subtotal CA"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c30)

                    Dim c31 As New DataGridViewTextBoxColumn
                    With c31
                        .DisplayIndex = 32
                        .HeaderText = "Impuesto CA"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c31)

                    Dim c32 As New DataGridViewTextBoxColumn
                    With c32
                        .DisplayIndex = 33
                        .HeaderText = "Total CA"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c32)

                    Dim c33 As New DataGridViewTextBoxColumn
                    With c33
                        .DisplayIndex = 34
                        .HeaderText = "Subtotal"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c33)

                    Dim c34 As New DataGridViewTextBoxColumn
                    With c34
                        .DisplayIndex = 35
                        .HeaderText = "Impuesto"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c34)

                    Dim c35 As New DataGridViewTextBoxColumn
                    With c35
                        .DisplayIndex = 36
                        .HeaderText = "Total"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c35)
                    '31/05/2010 - 
                    Dim c36 As New DataGridViewTextBoxColumn
                    With c36
                        .DisplayIndex = 37
                        .HeaderText = "Usuario Ingreso"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c36)
                    '
                    Dim c37 As New DataGridViewTextBoxColumn
                    With c37
                        .DisplayIndex = 38
                        .HeaderText = "Fec. Recepción"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c37)
                    '
                    Dim c38 As New DataGridViewTextBoxColumn
                    With c38
                        .DisplayIndex = 39
                        .HeaderText = "Entrega"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c38)
                    '
                    Dim c39 As New DataGridViewTextBoxColumn
                    With c39
                        .DisplayIndex = 40
                        .HeaderText = "Fec. Entrega"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c39)
                    ' 
                    Dim c40 As New DataGridViewTextBoxColumn
                    With c40
                        .DisplayIndex = 41
                        .HeaderText = "Usuario Entrega"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c40)
                    '
                    Dim c41 As New DataGridViewTextBoxColumn
                    With c41
                        .DisplayIndex = 42
                        .HeaderText = "Días sin Entrega"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c41)

                    Dim c42 As New DataGridViewTextBoxColumn
                    With c42
                        .DisplayIndex = 43
                        .HeaderText = "Nº incidencia"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .ReadOnly = True
                    End With
                    .Columns.Add(c42)

                    Dim c43 As New DataGridViewTextBoxColumn
                    With c43
                        .DisplayIndex = 44
                        .HeaderText = "Fec. Incidencia Ult"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .ReadOnly = True
                    End With
                    .Columns.Add(c43)

                    Dim c44 As New DataGridViewTextBoxColumn
                    With c44
                        .DisplayIndex = 45
                        .HeaderText = "IdProcesos"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .ReadOnly = True
                        .Visible = False
                    End With
                    .Columns.Add(c44)

                End With
                '
                Dim iPeso As Double
                Dim iVolumen As Double
                Dim iSubtotal As Double
                Dim iImpuesto As Double
                Dim iTotal As Double

                For Each obj As DataRow In .Rows
                    iPeso += obj.Item("cantidad_peso")
                    iVolumen += obj.Item("cantidad_volumen")
                    iSubtotal += obj.Item("subtotal")
                    iImpuesto += obj.Item("impuesto")
                    iTotal += obj.Item("total")

                    dgvDocumento.Rows.Add()
                    dgvDocumento(0, iFila).Value = obj.Item(0)
                    dgvDocumento(1, iFila).Value = obj.Item(1)
                    'Modificado 06/08/2010 
                    dgvDocumento(2, iFila).Value = obj.Item(43)
                    '
                    dgvDocumento(3, iFila).Value = obj.Item(2)
                    dgvDocumento(4, iFila).Value = obj.Item(3)
                    dgvDocumento(5, iFila).Value = obj.Item(4)
                    dgvDocumento(6, iFila).Value = obj.Item(5)
                    dgvDocumento(7, iFila).Value = obj.Item(6)
                    '03/09/2010 - Se agrega consignado 
                    dgvDocumento(8, iFila).Value = obj.Item(44)
                    '
                    dgvDocumento(9, iFila).Value = obj.Item(7)
                    dgvDocumento(10, iFila).Value = obj.Item(8)

                    dgvDocumento(11, iFila).Value = obj.Item(9)
                    dgvDocumento(12, iFila).Value = obj.Item(10)
                    dgvDocumento(13, iFila).Value = obj.Item(11)
                    dgvDocumento(14, iFila).Value = obj.Item(12)
                    dgvDocumento(15, iFila).Value = obj.Item(13)
                    dgvDocumento(16, iFila).Value = obj.Item(14)
                    dgvDocumento(17, iFila).Value = obj.Item(15)
                    dgvDocumento(18, iFila).Value = obj.Item(16)
                    dgvDocumento(19, iFila).Value = obj.Item(17)
                    dgvDocumento(20, iFila).Value = obj.Item(18)
                    dgvDocumento(21, iFila).Value = obj.Item(19)
                    dgvDocumento(22, iFila).Value = obj.Item(20)
                    dgvDocumento(23, iFila).Value = obj.Item(21)
                    dgvDocumento(24, iFila).Value = obj.Item(22)
                    dgvDocumento(25, iFila).Value = obj.Item(23)
                    dgvDocumento(26, iFila).Value = obj.Item(24)
                    dgvDocumento(27, iFila).Value = obj.Item(25)
                    dgvDocumento(28, iFila).Value = obj.Item(26)
                    dgvDocumento(29, iFila).Value = obj.Item(27)
                    dgvDocumento(30, iFila).Value = obj.Item(28)
                    dgvDocumento(31, iFila).Value = obj.Item(29)
                    dgvDocumento(32, iFila).Value = obj.Item(30)
                    dgvDocumento(33, iFila).Value = obj.Item(31)
                    dgvDocumento(34, iFila).Value = FormatNumber(obj.Item(32), 2)
                    dgvDocumento(35, iFila).Value = FormatNumber(obj.Item(33), 2)
                    dgvDocumento(36, iFila).Value = FormatNumber(obj.Item(34), 2)
                    '
                    dgvDocumento(37, iFila).Value = obj.Item(35)
                    dgvDocumento(38, iFila).Value = obj.Item(36)
                    dgvDocumento(39, iFila).Value = obj.Item(37)
                    dgvDocumento(40, iFila).Value = obj.Item(38)
                    dgvDocumento(41, iFila).Value = obj.Item(39)
                    dgvDocumento(42, iFila).Value = obj.Item(40)
                    dgvDocumento(43, iFila).Value = obj.Item(41)
                    dgvDocumento(44, iFila).Value = obj.Item(42)
                    dgvDocumento(45, iFila).Value = obj.Item(45)
                    '
                    iFila += 1
                Next

                'Do While .BOF = False And .EOF = False
                '    iPeso += .Fields("cantidad_peso").Value
                '    iVolumen += .Fields("cantidad_volumen").Value
                '    iSubtotal += .Fields("subtotal").Value
                '    iImpuesto += .Fields("impuesto").Value
                '    iTotal += .Fields("total").Value

                '    dgvDocumento.Rows.Add()
                '    dgvDocumento(0, iFila).Value = .Fields(0).Value
                '    dgvDocumento(1, iFila).Value = .Fields(1).Value
                '    dgvDocumento(2, iFila).Value = .Fields(2).Value
                '    dgvDocumento(3, iFila).Value = .Fields(3).Value
                '    dgvDocumento(4, iFila).Value = .Fields(4).Value
                '    dgvDocumento(5, iFila).Value = .Fields(5).Value
                '    dgvDocumento(6, iFila).Value = .Fields(6).Value
                '    dgvDocumento(7, iFila).Value = .Fields(7).Value
                '    dgvDocumento(8, iFila).Value = .Fields(8).Value

                '    dgvDocumento(9, iFila).Value = .Fields(9).Value
                '    dgvDocumento(10, iFila).Value = .Fields(10).Value
                '    dgvDocumento(11, iFila).Value = .Fields(11).Value
                '    dgvDocumento(12, iFila).Value = .Fields(12).Value
                '    dgvDocumento(13, iFila).Value = .Fields(13).Value
                '    dgvDocumento(14, iFila).Value = .Fields(14).Value
                '    dgvDocumento(15, iFila).Value = .Fields(15).Value
                '    dgvDocumento(16, iFila).Value = .Fields(16).Value
                '    dgvDocumento(17, iFila).Value = .Fields(17).Value
                '    dgvDocumento(18, iFila).Value = .Fields(18).Value
                '    dgvDocumento(19, iFila).Value = .Fields(19).Value
                '    dgvDocumento(20, iFila).Value = .Fields(20).Value
                '    dgvDocumento(21, iFila).Value = .Fields(21).Value
                '    dgvDocumento(22, iFila).Value = .Fields(22).Value
                '    dgvDocumento(23, iFila).Value = .Fields(23).Value
                '    dgvDocumento(24, iFila).Value = .Fields(24).Value
                '    dgvDocumento(25, iFila).Value = .Fields(25).Value
                '    dgvDocumento(26, iFila).Value = .Fields(26).Value
                '    dgvDocumento(27, iFila).Value = .Fields(27).Value
                '    dgvDocumento(28, iFila).Value = .Fields(28).Value
                '    dgvDocumento(29, iFila).Value = .Fields(29).Value
                '    dgvDocumento(30, iFila).Value = .Fields(30).Value
                '    dgvDocumento(31, iFila).Value = .Fields(31).Value
                '    dgvDocumento(32, iFila).Value = FormatNumber(.Fields(32).Value, 2)
                '    dgvDocumento(33, iFila).Value = FormatNumber(.Fields(33).Value, 2)
                '    dgvDocumento(34, iFila).Value = FormatNumber(.Fields(34).Value, 2)

                '    iFila += 1
                '    .MoveNext()
                'Loop
                txtPeso.Text = FormatNumber(iPeso, 0)
                txtVolumen.Text = FormatNumber(iVolumen, 0)
                txts.Text = FormatNumber(iSubtotal, 2)
                txti.Text = FormatNumber(iImpuesto, 2)
                txtt.Text = FormatNumber(iTotal, 2)
            End If
        End With
    End Sub

    Private Function asignar_seleccionados(ByVal rst As ADODB.Recordset) As Boolean
        'asignar_seleccionados = False
        'Dim indice As Integer = 0
        'If rst.EOF = False And rst.BOF = False Then
        '    ReDim objComprobanteAsegurada(19)
        '    While rst.EOF = False And rst.BOF = False
        '        If Not rst.Fields.Item("fecha").Value Is DBNull.Value Then
        '            Try
        '                objComprobanteAsegurada(indice).ID_GUIAS_ENVIO_DOC = rst.Fields.Item("ID_GUIAS_ENVIO_DOC").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).IDGUIAS_ENVIO = rst.Fields.Item("IDGUIAS_ENVIO").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).IDTIPO_COMPROBANTE = rst.Fields.Item("IDTIPO_COMPROBANTE").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).NRO_SERIE = rst.Fields.Item("NRO_SERIE").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).NRO_DOCU = rst.Fields.Item("NRO_DOCU").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).IDUSUARIO_PERSONAL = rst.Fields.Item("IDUSUARIO_PERSONAL").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).IDUSUARIO_PERSONALMOD = rst.Fields.Item("IDUSUARIO_PERSONALMOD").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).IDROL_USUARIO = rst.Fields.Item("IDROL_USUARIO").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).IDROL_USUARIOMOD = rst.Fields.Item("IDROL_USUARIOMOD").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).IP = rst.Fields.Item("IP").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).IPMOD = rst.Fields.Item("IPMOD").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).FECHA_REGISTRO = rst.Fields.Item("FECHA_REGISTRO").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).FECHA_ACTUALIZACION = rst.Fields.Item("FECHA_ACTUALIZACION").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).IDESTADO_REGISTRO = rst.Fields.Item("IDESTADO_REGISTRO").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).FECHA = rst.Fields.Item("FECHA").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO = rst.Fields.Item("MONTO_TIPO_CAMBIO").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).MONTO_SUB_TOTAL = rst.Fields.Item("MONTO_SUB_TOTAL").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).MONTO_IMPUESTO = rst.Fields.Item("MONTO_IMPUESTO").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).TOTAL_COSTO = rst.Fields.Item("TOTAL_COSTO").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).OBS = rst.Fields.Item("OBS").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).IDTIPO_MONEDA = rst.Fields.Item("IDTIPO_MONEDA").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).PORCEN = rst.Fields.Item("PORCEN").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).TIPO = rst.Fields.Item("TIPO_MONTO").Value
        '            Catch
        '            End Try
        '            Try
        '                objComprobanteAsegurada(indice).PROCEDENCIA = rst.Fields.Item("IND_PROCEDENCIA").Value
        '            Catch
        '            End Try
        '            asignar_seleccionados = True
        '            indice = indice + 1
        '        End If
        '        rst.MoveNext()
        '    End While
        '    rst.MoveFirst()
        'End If
    End Function

    Private Function asignar_seleccionados(ByVal rst As DataTable) As Boolean
        asignar_seleccionados = False
        Dim indice As Integer = 0
        If rst.Rows.Count > 0 Then
            ReDim objComprobanteAsegurada(19)
            For Each obj As DataRow In rst.Rows
                If Not obj.Item("fecha") Is DBNull.Value Then
                    Try
                        objComprobanteAsegurada(indice).ID_GUIAS_ENVIO_DOC = obj.Item("ID_GUIAS_ENVIO_DOC")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDGUIAS_ENVIO = obj.Item("IDGUIAS_ENVIO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDTIPO_COMPROBANTE = obj.Item("IDTIPO_COMPROBANTE")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).NRO_SERIE = obj.Item("NRO_SERIE")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).NRO_DOCU = obj.Item("NRO_DOCU")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDUSUARIO_PERSONAL = obj.Item("IDUSUARIO_PERSONAL")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDUSUARIO_PERSONALMOD = obj.Item("IDUSUARIO_PERSONALMOD")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDROL_USUARIO = obj.Item("IDROL_USUARIO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDROL_USUARIOMOD = obj.Item("IDROL_USUARIOMOD")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IP = obj.Item("IP")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IPMOD = obj.Item("IPMOD")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).FECHA_REGISTRO = obj.Item("FECHA_REGISTRO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).FECHA_ACTUALIZACION = obj.Item("FECHA_ACTUALIZACION")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDESTADO_REGISTRO = obj.Item("IDESTADO_REGISTRO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).FECHA = obj.Item("FECHA")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO = obj.Item("MONTO_TIPO_CAMBIO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).MONTO_SUB_TOTAL = obj.Item("MONTO_SUB_TOTAL")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).MONTO_IMPUESTO = obj.Item("MONTO_IMPUESTO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).TOTAL_COSTO = obj.Item("TOTAL_COSTO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).OBS = obj.Item("OBS")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDTIPO_MONEDA = obj.Item("IDTIPO_MONEDA")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).PORCEN = obj.Item("PORCEN")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).TIPO = obj.Item("TIPO_MONTO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).PROCEDENCIA = obj.Item("IND_PROCEDENCIA")
                    Catch
                    End Try
                    asignar_seleccionados = True
                    indice = indice + 1
                End If
            Next
        End If
    End Function

    Private Sub btnBultosnoLeidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBultosnoLeidos.Click
        'If txtTipoDocumento.Text.Trim.Length = 0 Then Exit Sub
        Dim frm As New frmBultosNoLeidos

        frm.sDocumento = iComprobante
        frm.iTipo = iTipoComprobante
        frm.sDoc = txtTipoDocumento.Text & " " & txtDocumento.Text

        'frm.ShowDialog()

        Acceso.Asignar(frm, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            frm.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    'Cambiar
    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged, btnCargaAsegurada.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub CboCargaAcompanada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCargaAcompanada.SelectedIndexChanged, cboPyme.SelectedIndexChanged
        Me.LimpiarGrid()
    End Sub

    Private Sub CboTe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTe.SelectedIndexChanged
        Me.LimpiarGrid()
    End Sub
End Class