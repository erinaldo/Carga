Imports INTEGRACION_LN
Imports INTEGRACION_EN
Public Class FrmTarifarioCliente
    Dim dvidcentro_costo As New DataView
    Dim vAccionRegistro As Integer
    Dim lista_tarifas As Boolean = False
    Dim bIngreso As Boolean
    Public hnd As Long
    Dim idTarifa_CargaCliente As Integer
    Dim dt_Resultado2 As Integer
#Region "Atributos"
    'Private objTarifaCargaCliente_LN As Cls_TarifaCargaClientes_LN
    'Private objBuscarTarifaCargaCliente_LN As Cls_TarifaCargaClientes_LN
#End Region
#Region " DECLARACION DE VARIABLES "

    'Private DataAdapterGenerics As New OleDbDataAdapter
    Private dtRoles As New System.Data.DataTable
    Private dtUsuarioRoles As New System.Data.DataTable
    Private dtUsuarioRolesA As New System.Data.DataTable

    Dim dvListaClientes As New DataView
    Dim dvRoles As New DataView
    Dim dvUsuarioRoles As New DataView
    Dim dvUsuarioRolesA As New DataView

    'Dim rstRoles As ADODB.Recordset = Nothing
    'Dim rstUsuarioRoles As ADODB.Recordset = Nothing

    Dim dvListaClientesA As DataView
    Dim dvListaClientesB As DataView

    Dim accionA As Integer = 0
    Dim accionB As Integer = 0

    Dim dvTempA As DataView
    Dim dvTempB As DataView

    Dim dvArticulos As New DataView
    Dim dvArticulosEncomienda As New DataView

    'Dim rstValores As ADODB.Recordset
    'Dim rstOrigen As ADODB.Recordset
    Dim dtOrigen As New DataTable
    Dim dtDestino As New DataTable
    Dim dvOrigen As New DataView
    Dim dvDestino As New DataView

    'Dim rstTarifasPublicas As ADODB.Recordset

    Dim vBase As Boolean
    Dim vPeso As Boolean
    Dim vVolumen As Boolean
    Dim Vsobre As Boolean

    Dim Funcionario As String
    Dim dvTarifasCliente As New DataView
    ' 
    Dim dtTarifasPublicas As New DataTable   ' Creado por Tepsa 
    Dim idciudad_origen As Integer
    Dim idciudad_destino As Integer
    '
    '20/10/2007 - Recupera el codigo del cliente
    Dim ls_idpersona As String
    Dim ls_razon_social As String
    Dim ls_codigo_cliente As String
    Dim ls_porcentaje_descuento As String
    Dim b_lee As Boolean = True
    '
#End Region

    Private Sub FrmTarifarioCliente_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmTarifarioCliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmTarifarioCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        btncargaTarifa.Visible = False
        rdbnaturales.Enabled = True ' false
        rdbAmbos.Enabled = True     ' false 
        '
        rdbnaturales.Visible = True  ' false 
        rdbAmbos.Visible = True  ' false 
        ' 
        MenuTab.Items(0).Text = "LISTA CLIENTES"
        MenuTab.Items(1).Text = "LISTA TARIFAS"
        MenuTab.Items(1).Visible = False
        MenuTab.Items(2).Text = "ESTABLECER TARIFAS"
        HabilitarMenu(MenuTab)
        '  Tepsa - Añadiendo las variables principales 
        MyUsuario = dtoUSUARIOS.IdLogin
        MyRol = dtoUSUARIOS.IdRol
        MyIP = dtoUSUARIOS.IP
        '
        ShadowLabel1.Text = "Tarifas Carga - Cliente"
        txtCodigoCLiente.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        txtNombreCliente.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        txtFuncionarioActual.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        Me.txt_porcentaje_descuento.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        TxtFecIni._MyFecha = Today
        TxtFecFin.Enabled = False
        TxtFecFin.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        txtID.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")

        DesactivaMontosPublicos(txtMontoBaseCarga, txtPrecioPesoCarga, txtPrecioVolumenCarga, _
                                txtMontoBaseEncomienda, txtPrecioPesoEncomienda, txtPrecioVolumenEncomienda, _
                                txtPrecioPostalBase, txtPrecioPostalPeso, txtPrecioPostalVolumen, _
                                txtMontoBaseGiro, txtPorctNormal, txtPorctTelefono, txt_cg_sobre)

        rdbCarga.Checked = True
        chkCondicional.Checked = True
        rdbArticulos.Checked = True
        rdbJuridicos.Checked = True

        vAccionRegistro = 0

        Try
            'datahelper
            'rstValores = Funciones.CargarOrigenDestino()
            'rstOrigen = rstValores.NextRecordset
            'Dim da As New OleDbDataAdapter
            'da.Fill(dtOrigen, rstOrigen)
            'dtDestino = dtOrigen.Copy
            Dim ds As DataSet = Funciones.CargarOrigenDestino()
            dtOrigen = ds.Tables(1)
            dtDestino = dtOrigen.Copy
            'dtDestino = ds.Tables(1)

            b_lee = False
            dvOrigen = Funciones.CargarCombo(cmbOrigen, dtOrigen, "NOMBRE_UNIDAD", "IDUNIDAD_AGENCIA", dtoUSUARIOS.m_idciudad)
            dvDestino = Funciones.CargarCombo(cmbDestino, dtDestino, "NOMBRE_UNIDAD", "IDUNIDAD_AGENCIA", 5630)
            dvOrigen.RowFilter = "IDUNIDAD_AGENCIA<>9999"
            dvDestino.RowFilter = "IDUNIDAD_AGENCIA<>9999"
            '
            ' Modificado  25/07/2007 - Haciendo el filtro por funcionario de negocios
            '
            '  If MyRol <> 11 Then '(32) Supervisor de funcionario de negocios (15) Credito y cobranzas
            If Not Acceso.SiRol(G_Rol, Me, 1) Then
                Call Funciones.LlenaTreeFuncionarios(MyTreeView)
                Me.btnCargarClientes.Enabled = True
            Else
                ' Modificado el dia 25/06/2007 - Omendoza, se puso 
                Call Funciones.LlenaTreeSoloFuncionarios(MyUsuario, MyTreeView)
                dvListaClientes = CargarGrillaClientes_x_funcionario(MyUsuario, Me.DataGridLista)
                DataGridLista.Columns(4).Visible = True
                DataGridLista.Columns(5).Visible = False
                DataGridLista.Columns(40).Visible = False
                Me.btnCargarClientes.Enabled = False
                'Me.MyTreeView.ImageIndex = 1
                Me.MyTreeView.ExpandAll()
            End If
            '
            '
            'Call Funciones.LlenaTreeFuncionarios(MyTreeView)  ---> Modificado por Omendoza 07/07/2007 
            ' 
            ' Crear Unidad de Agencia Modificado por Tepsa 
            cmbOrigen.SelectedValue = dtoUSUARIOS.m_idciudad
            idciudad_origen = dtoUSUARIOS.m_idciudad
            idciudad_destino = 5630   'Agencia Destino              
            ' dvArticulos = Funciones.CargarArticulos(dgvArticulo)
            dgvArticulo.Columns.Clear()
            dvArticulos = Funciones.CargarArticulos_x_cliente(dgvArticulo, txtCodigoCLiente.Text, -1, idciudad_origen, idciudad_destino)
            '
            ' Call CargarUnidades(Me.dgvCondicional) 'tepsa 
            Call CargarTarifasCondicional(Me.dgvCondicional, 0)
            '
            b_lee = True

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmTarifarioCliente_MenuCancelar() Handles Me.MenuCancelar
        MenuTab.Items(0).Enabled = True
        MenuTab.Items(1).Visible = False
        MenuTab.Items(2).Enabled = False

        SelectMenu(0)
        SplitContainer2.Panel1Collapsed = False
        NuevoToolStripMenuItem.Enabled = True
        EdicionToolStripMenuItem.Enabled = True
        CancelarToolStripmenuItem.Enabled = False
        CancelarToolStripmenuItem.Visible = False
        GrabarToolStripMenuItem.Enabled = False
        EliminarToolStripMenuItem.Enabled = True
        ExportarToolStripMenuItem.Enabled = True
        ImprimirToolStripMenuItem.Enabled = True
    End Sub

    Private Sub FrmTarifarioCliente_MenuEditar() Handles Me.MenuEditar
        Try
            Dim ls_funcionario As String
            Dim ld_porc_dscto As Double

            If Me.DataGridLista.RowCount > 0 Then
                Me.DataGridLista.Focus()
                MenuTab.Items(0).Enabled = False
                Dim dgvr As New DataGridViewRow
                MenuTab.Items(1).Visible = True
                SelectMenu(1)
                vAccionRegistro = 2
                dgvr = Me.DataGridLista.CurrentRow()
                dvTarifasCliente = Funciones.CargarTarifaCliente(CType(dgvr.Cells("CODIGO").Value, String), dgvTarifasCliente)
                '20/10/2007
                ls_codigo_cliente = CType(dgvr.Cells("CODIGO").Value, String)
                ls_idpersona = CType(dgvr.Cells("id").Value, String)
                ls_razon_social = CType(dgvr.Cells("RAZONSOCIAL").Value, String)
                If IsDBNull(dgvr.Cells("FUNCIONARIO").Value) = True Then
                    ls_funcionario = ""
                Else
                    ls_funcionario = CType(dgvr.Cells("FUNCIONARIO").Value, String)
                End If

                If IsDBNull(dgvr.Cells("DESCUENTO").Value) = True Then
                    ls_porcentaje_descuento = 0
                Else
                    ls_porcentaje_descuento = CType(dgvr.Cells("DESCUENTO").Value, String)
                End If
                If dgvTarifasCliente.Rows.Count > 0 Then  'Cuando no tiene datos va
                    If IsDBNull(dgvTarifasCliente.Rows(0).Cells("porc_descuento").Value) = False Then
                        ld_porc_dscto = CType(dgvTarifasCliente.Rows(0).Cells("porc_descuento").Value, Double)
                        If ls_porcentaje_descuento <> CType(ld_porc_dscto, String) Then
                            ls_porcentaje_descuento = CType(ld_porc_dscto, String)
                        End If
                    End If
                End If
                '
                'Codigo de Edicion de la Plantilla
                SelectMenu(1)
                SplitContainer2.Panel1Collapsed = True
                NuevoToolStripMenuItem.Enabled = False
                EdicionToolStripMenuItem.Enabled = False
                CancelarToolStripmenuItem.Enabled = True
                CancelarToolStripmenuItem.Visible = True
                GrabarToolStripMenuItem.Enabled = True 'Colocar en todos los formualrios esto, luego de dshabilitarlos.
                EliminarToolStripMenuItem.Enabled = False
                ExportarToolStripMenuItem.Enabled = False
                ImprimirToolStripMenuItem.Enabled = False
                '
                Me.txt_codigo_cliente1.Text = ls_codigo_cliente
                Me.txt_funcionario1.Text = ls_funcionario
                Me.txt_razon_social1.Text = ls_razon_social
                Me.txt_descuento.Text = ls_porcentaje_descuento
                '
                Me.txt_codigo_cliente1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
                Me.txt_funcionario1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
                Me.txt_razon_social1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
                Me.txt_descuento.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
                '
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------CREADO POR DIEGO ZEGARRA 13/07/2013-----------4 CAPAS ------------------------------------------

    Private Sub FrmTarifarioCliente_MenuGrabar() Handles Me.MenuGrabar
        Dim codigoCliente As String
        Dim Origen As String
        Dim Destino As String
        Dim bflag As Boolean = False
        Dim rstBusqueda As String
        Try
            F_Valida_LineaCreditoActiva() 'Valida si el Cliente tiene linea de Credito Activa, sino no tiene no podras ingresar Tarifas y te botara

            If (dt_Resultado2 > 0) Then
                Dim Obligatorios() As Object = {Me.txtMontoBaseCargaFinal, Me.txtPrecioPesoCargaFinal, Me.txtPrecioVolumenCargaFinal, Me.txtMontoBaseEncomiendaFinal, Me.txtPrecioPesoEncomiendaFinal, Me.txtPrecioVolumenEncomiendaFinal, Me.txtPrecioPostalFinal, Me.txtPrecioPostalPesoFinal, Me.txtPrecioPostalVolumenFinal, Me.txtMontoBaseGiroFinal, Me.txtPorctNormalFinal, Me.txtPorctTelefonoFinal}
                If Funciones.Validaciones(Obligatorios) = 0 Then
                    'rstBusqueda = Funciones.BuscaTarifarioII(txtCodigoCLiente.Text, cmbOrigen.SelectedValue, cmbDestino.SelectedValue)
                    If rstBusqueda > 0 Then
                        If (MessageBox.Show("YA EXISTE UNA TARIFA PARA LA RUTA " & cmbOrigen.Text & " - " & cmbDestino.Text & Chr(13) & _
                                           " Desea Modificar la Tarifa?", "Mensaje Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
                            F_Editar_Tarifa()
                        Else
                            txtMontoBaseCargaFinal.Focus()
                        End If
                    Else
                        Call GrabaTarifario()
                        'SelectMenu(0)
                        Call LimpiaTexBoxs(txtMontoBaseCargaFinal, txtPrecioPesoCargaFinal, txtPrecioVolumenCargaFinal, txtMontoBaseEncomiendaFinal, txtPrecioPesoEncomiendaFinal, txtPrecioVolumenEncomiendaFinal, txtPrecioPostalFinal, txtPrecioPostalPesoFinal, txtPrecioPostalVolumenFinal, txtMontoBaseGiroFinal)
                        txtPorctNormal.Text = "0"
                        txtPorctTelefono.Text = "0"
                        txtID.Text = "0"
                        lista_tarifas = False
                    End If
                Else
                    MessageBox.Show("Hay Campos de tarifa obligatorios.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("No se puede Ingresar las Tarifas por que no tiene " & Chr(13) & " Linea de Credito Activa ,Comunicate con Sistemas", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function F_Valida_LineaCreditoActiva() As String
        'objBuscarTarifaCargaCliente_LN = New Cls_TarifaCargaClientes_LN

        Dim iPersona2 As String
        iPersona2 = Me.txtCodigoCLiente.Text
        'dt_Resultado2 = objBuscarTarifaCargaCliente_LN.BuscarLC_ClienteLN(iPersona2)

    End Function

    Private Function F_BuscarTarifaCargaCliente() As Integer
        'objBuscarTarifaCargaCliente_LN = New Cls_TarifaCargaClientes_LN
        Dim dtResultado As New DataTable
        Dim iOrigen As String
        Dim iDestino As String
        Dim iPersona As String

        Dim dgvr As New DataGridViewRow
        iOrigen = Me.cmbOrigen.SelectedValue
        iDestino = Me.cmbDestino.SelectedValue
        iPersona = Me.txtCodigoCLiente.Text

        'dtResultado = objBuscarTarifaCargaCliente_LN.Buscar_TarifaLN(iOrigen, iDestino, iPersona)
        idTarifa_CargaCliente = IIf(IsDBNull(dtResultado.Rows(0)("IDTARIFAS_CARGA_CLIENTE")), "", dtResultado.Rows(0)("IDTARIFAS_CARGA_CLIENTE"))

    End Function

    Private Function F_Editar_Tarifa() As Integer
        Try
            Dim lStr_MsgGuardar As String
            'objTarifaCargaCliente_LN = New Cls_TarifaCargaClientes_LN
            Dim objTarifaCargaCliente_EN As New Cls_TarifaCargaCliente_EN

            ' Se obtiene la ultima Tarifa Vigente 12/07/2013 - Diego Zegarra T.
            If (F_BuscarTarifaCargaCliente() > 1) Then
                MessageBox.Show("Hay mas de una Tarifa Vigente, Comunicate con Sistemas", "Mensaje Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            With objTarifaCargaCliente_EN

                .iDCENTRO_COSTO = Me.cmbSubCuenta.SelectedValue
                .IDTARIFAS_CARGA_CLIENTE = idTarifa_CargaCliente
                .iCODIGOPERSONA = txtCodigoCLiente.Text
                .iUnidad_Agencia = Me.cmbOrigen.SelectedValue
                .iUnidad_Agencia_Destino = Me.cmbDestino.SelectedValue
                If Me.txtMontoBaseCargaFinal.Text = "" Then
                    .iCG_MONTO_BASE = 0
                Else
                    .iCG_MONTO_BASE = CType(Me.txtMontoBaseCargaFinal.Text, Decimal)
                End If
                If Me.txtPrecioPesoCargaFinal.Text = "" Then
                    .iCG_X_PESO = 0
                Else
                    .iCG_X_PESO = CType(Me.txtPrecioPesoCargaFinal.Text, Decimal)
                End If
                If Me.txtPrecioVolumenCargaFinal.Text = "" Then
                    .iCG_X_VOLUMEN = 0
                Else
                    .iCG_X_VOLUMEN = CType(Me.txtPrecioVolumenCargaFinal.Text, Decimal)
                End If
                .iEC_MONTO_BASE = CType(Me.txtMontoBaseEncomiendaFinal.Text, Decimal)
                .iEC_X_PESO = CType(Me.txtPrecioPesoEncomiendaFinal.Text, Decimal)
                .iEC_X_VOLUMEN = CType(Me.txtPrecioVolumenEncomiendaFinal.Text, Decimal)
                .iPO_MONTO_BASE = CType(Me.txtPrecioPostalFinal.Text, Decimal)
                .iPO_X_PESO = CType(Me.txtPrecioPostalPesoFinal.Text, Decimal)
                .iPO_X_VOLUMEN = CType(Me.txtPrecioPostalVolumenFinal.Text, Decimal)
                .iGI_MONTO_BASE = CType(Me.txtMontoBaseGiroFinal.Text, Decimal)
                .iGI_NORMAL = CType(Me.txtPorctNormalFinal.Text, Decimal)
                .iGI_TELEFONICO = CType(Me.txtPorctTelefonoFinal.Text, Decimal)
                If Me.txtPrecioSobreCargaFinal.Text = "" Then
                    .iCG_X_Sobre = 0
                Else
                    .iCG_X_Sobre = CType(Me.txtPrecioSobreCargaFinal.Text, Double)
                End If
                .iFECHA_ACTIVACION = Now
                .iFECHA_DESACTIVACION = Now
                If ChkVigente.Checked = True Then
                    .iES_VIGENTE = 1
                ElseIf ChkVigente.Checked = False Then
                    .iES_VIGENTE = 0
                End If
                .iIDESTADO_REGISTRO = 1
                .iIDUSUARIO_PERSONAL = MyUsuario
                .iIDROL_USUARIO = MyRol
                .iIP = MyIP
            End With

            'lStr_MsgGuardar = objBuscarTarifaCargaCliente_LN.F_EditarTarifaCliente_LN(objTarifaCargaCliente_EN)

            If lStr_MsgGuardar.Trim.Length > 0 Then
                MsgBox(lStr_MsgGuardar.Trim, MsgBoxStyle.Critical, "Se produjo un error")
                Return -1
            Else
                MessageBox.Show("Se actualizo Satisfactoriamente", "Mensaje Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FrmTarifarioCliente_MenuEditar() 'Se visualiza la modificacion
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Function
    Private Sub FrmTarifarioCliente_MenuImprimir() Handles Me.MenuImprimir
        Dim a As New ClsPrint
        a.Titulo = "CLIENTES CARGA"
        a.DGV = Me.DataGridLista
        Dim MyReport As New Reportes
        'MyReport.MdiParent = FrmContenedor
        MyReport.MdiParent = Principal   ' Tepsa
        MyReport.pd.Document = a
        MyReport.pd.Dock = DockStyle.Fill
        MyReport.WindowState = FormWindowState.Maximized
        'FrmContenedor.SplitContainer1.Panel2.Controls.Add(MyReport)
        MyReport.Show()
        MyReport.BringToFront()
    End Sub

    Private Sub FrmTarifarioCliente_MenuNuevo() Handles Me.MenuNuevo
        Try   
            Me.DataGridLista.Focus()
            If Me.DataGridLista.RowCount > 0 Then
                Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
                If Not dgvr Is Nothing Then
                    txtCodigoCLiente.Text = CType(dgvr.Cells("CODIGO").Value, String)
                    txtNombreCliente.Text = CType(dgvr.Cells("RAZONSOCIAL").Value, String)
                    txtFuncionarioActual.Text = CType(dgvr.Cells("FUNCIONARIO").Value, String)

                    MenuTab.Items(0).Enabled = False
                    MenuTab.Items(1).Enabled = True
                    MenuTab.Items(3).Enabled = True
                    SelectMenu(1)

                    txtID.Text = "0"
                    vAccionRegistro = 1

                    cmbOrigen.Enabled = True
                    cmbDestino.Enabled = True
                    cmbOrigen.BackColor = Color.White
                    cmbDestino.BackColor = Color.White

                    dvOrigen.RowFilter = "IDUNIDAD_AGENCIA<>9999"
                    dvDestino.RowFilter = "IDUNIDAD_AGENCIA<>9999"
                    'Tepsa 04/09/2006
                    cmbOrigen.SelectedValue = idciudad_origen
                    cmbDestino.SelectedValue = idciudad_destino
                    '
                    SelectMenu(2)
                    '
                    SplitContainer2.Panel1Collapsed = True
                    NuevoToolStripMenuItem.Enabled = False
                    EdicionToolStripMenuItem.Enabled = False
                    CancelarToolStripmenuItem.Enabled = True
                    CancelarToolStripmenuItem.Visible = True
                    GrabarToolStripMenuItem.Enabled = True
                    EliminarToolStripMenuItem.Enabled = False
                    ExportarToolStripMenuItem.Enabled = False
                    ImprimirToolStripMenuItem.Enabled = False
                    ' Configurando los campos, cuando ingrese se encuentren inactivo  - Tepsa 
                    'txtMontoBaseCargaFinal.Enabled = False
                    'txtPrecioPesoCargaFinal.Enabled = False
                    'txtPrecioVolumenCargaFinal.Enabled = False
                    txtMontoBaseCargaFinal.ReadOnly = True
                    txtPrecioPesoCargaFinal.ReadOnly = True
                    txtPrecioVolumenCargaFinal.ReadOnly = True
                    '
                    Me.txtMontoBaseCargaFinal.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
                    Me.txtPrecioPesoCargaFinal.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
                    Me.txtPrecioVolumenCargaFinal.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
                    Me.txtPrecioSobreCargaFinal.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
                    '
                    Me.txtMontoBaseCargaFinal.Text = "0.0"
                    Me.txtPrecioPesoCargaFinal.Text = "0.0"
                    Me.txtPrecioVolumenCargaFinal.Text = "0.0"
                    Me.txtPrecioSobreCargaFinal.Text = "0.0"
                    '
                    '
                    lista_tarifas = False
                    '
                    cargar_cmb_centro_costo()

                    '

                Else
                    MessageBox.Show("Seleccione a un Cliente de la Grilla.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Seleccione a un Funcionario y luego a un Cliente.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmTarifarioCliente_MenuSalir() Handles Me.MenuSalir
        Me.Close()
    End Sub

    Private Sub rdbPostales_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPostales.CheckedChanged
        gruPostales.Visible = True
        gruCarga.Visible = False
        gruEncomienda.Visible = False
        gruGiros.Visible = False
    End Sub

    Private Sub rdbCarga_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCarga.CheckedChanged
        gruPostales.Visible = False
        gruCarga.Visible = True
        gruEncomienda.Visible = False
        gruGiros.Visible = False
    End Sub

    Private Sub rdbEncomiendas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbEncomiendas.CheckedChanged
        gruPostales.Visible = False
        gruCarga.Visible = False
        gruEncomienda.Visible = True
        gruGiros.Visible = False
    End Sub

    Private Sub rdbGiros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbGiros.CheckedChanged
        gruPostales.Visible = False
        gruCarga.Visible = False
        gruEncomienda.Visible = False
        gruGiros.Visible = True
    End Sub


    'Private Sub txtMontoBaseCargaFinal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoBaseCargaFinal.KeyPress

    '    Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
    '    If KeyAscii = 13 Then 'Enter
    '        btncargaTarifa_Click(sender, e)
    '    End If

    'End Sub

    Private Sub txtMontoBaseCargaFinal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMontoBaseCargaFinal.KeyUp, txtMontoBaseEncomiendaFinal.KeyUp, txtMontoBaseGiroFinal.KeyUp, txtPrecioPostalFinal.KeyUp
        If e.KeyCode = Keys.Enter Then
            gruCalculos.Visible = True
            gruCalculos.BringToFront()
            Beep()
            txtDecuentoCal.Text = ""
            txtMontoFinalCal.Text = ""
            sender.text = ""
            txtMontoFinalCal.Focus()
            vBase = True
            vPeso = False
            vVolumen = False
        End If
    End Sub

    Private Sub txtPrecioPesoCargaFinal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrecioPesoCargaFinal.KeyUp, txtPrecioPesoEncomiendaFinal.KeyUp, txtPorctNormalFinal.KeyUp, txtPrecioPostalPesoFinal.KeyUp
        If e.KeyCode = Keys.Enter Then
            gruCalculos.Visible = True
            gruCalculos.BringToFront()
            Beep()
            txtDecuentoCal.Text = ""
            txtMontoFinalCal.Text = ""
            sender.text = ""
            txtMontoFinalCal.Focus()
            vBase = False
            vPeso = True
            vVolumen = False
            Vsobre = False
        End If
    End Sub
    Private Sub txtPrecioVolumenCargaFinal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrecioVolumenCargaFinal.KeyUp, txtPrecioVolumenEncomiendaFinal.KeyUp, txtPrecioPostalVolumenFinal.KeyUp, txtPorctTelefonoFinal.KeyUp
        If e.KeyCode = Keys.Enter Then
            gruCalculos.Visible = True
            gruCalculos.BringToFront()
            Beep()
            txtDecuentoCal.Text = ""
            txtMontoFinalCal.Text = ""
            sender.text = ""
            txtMontoFinalCal.Focus()
            vBase = False
            vPeso = False
            vVolumen = True
            Vsobre = False
        End If
    End Sub

    Private Sub txtDecuentoCal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDecuentoCal.KeyUp
        If e.KeyCode = Keys.Enter Then

            If rdbCarga.Checked = True Then
                If vBase = True Then
                    If Len(Trim(txtMontoBaseCarga.Text)) <> 0 And Len(Trim(txtDecuentoCal.Text)) <> 0 Then
                        txtMontoFinalCal.Text = CType(CType(txtMontoBaseCarga.Text, Decimal) * (1 + (CType(txtDecuentoCal.Text, Decimal) / 100)), String)
                        txtMontoFinalCal.Focus()
                    End If
                End If
                If vPeso = True Then
                    If Len(Trim(txtPrecioPesoCarga.Text)) <> 0 And Len(Trim(txtDecuentoCal.Text)) <> 0 Then
                        txtMontoFinalCal.Text = CType(CType(txtPrecioPesoCarga.Text, Decimal) * (1 + (CType(txtDecuentoCal.Text, Decimal) / 100)), String)
                        txtMontoFinalCal.Focus()
                    End If
                End If
                If vVolumen = True Then
                    If Len(Trim(txtPrecioVolumenCarga.Text)) <> 0 And Len(Trim(txtDecuentoCal.Text)) <> 0 Then
                        txtMontoFinalCal.Text = CType(CType(txtPrecioVolumenCarga.Text, Decimal) * (1 + (CType(txtDecuentoCal.Text, Decimal) / 100)), String)
                        txtMontoFinalCal.Focus()
                    End If
                End If
                If Vsobre = True Then
                    If Len(Trim(Me.txt_cg_sobre.Text)) <> 0 And Len(Trim(txtDecuentoCal.Text)) <> 0 Then
                        txtMontoFinalCal.Text = CType(CType(Me.txt_cg_sobre.Text, Decimal) * (1 + (CType(txtDecuentoCal.Text, Decimal) / 100)), String)
                        txtMontoFinalCal.Focus()
                    End If
                End If
            End If

            If rdbEncomiendas.Checked = True Then
                If vBase = True Then
                    If Len(Trim(txtMontoBaseEncomienda.Text)) <> 0 And Len(Trim(txtDecuentoCal.Text)) <> 0 Then
                        txtMontoFinalCal.Text = CType(CType(txtMontoBaseEncomienda.Text, Decimal) * (1 + (CType(txtDecuentoCal.Text, Decimal) / 100)), String)
                        txtMontoFinalCal.Focus()
                    End If
                End If
                If vPeso = True Then
                    If Len(Trim(txtPrecioPesoEncomienda.Text)) <> 0 And Len(Trim(txtDecuentoCal.Text)) <> 0 Then
                        txtMontoFinalCal.Text = CType(CType(txtPrecioPesoEncomienda.Text, Decimal) * (1 + (CType(txtDecuentoCal.Text, Decimal) / 100)), String)
                        txtMontoFinalCal.Focus()
                    End If
                End If
                If vVolumen = True = 0 Then
                    If Len(Trim(txtPrecioVolumenEncomienda.Text)) <> 0 And Len(Trim(txtDecuentoCal.Text)) <> 0 Then
                        txtMontoFinalCal.Text = CType(CType(txtPrecioVolumenEncomienda.Text, Decimal) * (1 + (CType(txtDecuentoCal.Text, Decimal) / 100)), String)
                        txtMontoFinalCal.Focus()
                    End If
                End If
            End If

            If rdbPostales.Checked = True Then
                If vBase = True Then
                    If Len(Trim(txtPrecioPostalBase.Text)) <> 0 And Len(Trim(txtDecuentoCal.Text)) <> 0 Then
                        txtMontoFinalCal.Text = CType(CType(txtPrecioPostalBase.Text, Decimal) * (1 + (CType(txtDecuentoCal.Text, Decimal) / 100)), String)
                        txtMontoFinalCal.Focus()
                    End If
                End If
                If vPeso = True Then
                    If Len(Trim(txtPrecioPostalPeso.Text)) <> 0 And Len(Trim(txtDecuentoCal.Text)) <> 0 Then
                        txtMontoFinalCal.Text = CType(CType(txtPrecioPesoEncomienda.Text, Decimal) * (1 + (CType(txtDecuentoCal.Text, Decimal) / 100)), String)
                        txtMontoFinalCal.Focus()
                    End If

                End If
                If vVolumen = True = 0 Then

                End If
            End If

            If rdbGiros.Checked = True Then
                If vBase = True Then
                    If Len(Trim(txtMontoBaseGiro.Text)) <> 0 And Len(Trim(txtDecuentoCal.Text)) <> 0 Then
                        txtMontoFinalCal.Text = CType(CType(txtMontoBaseGiro.Text, Decimal) * (1 + (CType(txtDecuentoCal.Text, Decimal) / 100)), String)
                        txtMontoFinalCal.Focus()
                    End If
                End If
                If vPeso = True Then
                    If Len(Trim(txtPorctNormal.Text)) <> 0 And Len(Trim(txtDecuentoCal.Text)) <> 0 Then
                        txtMontoFinalCal.Text = CType(CType(txtPorctNormal.Text, Decimal) * (1 + (CType(txtDecuentoCal.Text, Decimal) / 100)), String)
                        txtMontoFinalCal.Focus()
                    End If
                End If
                If vVolumen = True Then
                    If Len(Trim(txtPorctTelefono.Text)) <> 0 And Len(Trim(txtDecuentoCal.Text)) <> 0 Then
                        txtMontoFinalCal.Text = CType(CType(txtPorctTelefono.Text, Decimal) * (1 + (CType(txtDecuentoCal.Text, Decimal) / 100)), String)
                        txtMontoFinalCal.Focus()
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub txtMontoFinalCal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMontoFinalCal.KeyUp
        If e.KeyCode = Keys.Enter Then
            If chkCondicional.Checked = False Then
                If rdbCarga.Checked = True Then
                    If vBase = True Then 'Si esta vacio pinta, sino pasa al segundo casillero.
                        txtMontoBaseCargaFinal.Text = CType(txtMontoFinalCal.Text, String)
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                    If vPeso = True Then
                        txtPrecioPesoCargaFinal.Text = CType(txtMontoFinalCal.Text, String)
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                    If vVolumen = True Then
                        txtPrecioVolumenCargaFinal.Text = CType(txtMontoFinalCal.Text, String)
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                    If Vsobre = True Then
                        txtPrecioSobreCargaFinal.Text = CType(txt_cg_sobre.Text, String)
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                End If
                '
                If rdbEncomiendas.Checked = True Then
                    If vBase = True Then
                        txtMontoBaseEncomiendaFinal.Text = CType(txtMontoFinalCal.Text, String)
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                    If vPeso = True Then
                        txtPrecioPesoEncomiendaFinal.Text = CType(txtMontoFinalCal.Text, String)
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                    If vVolumen = True Then
                        txtPrecioVolumenEncomiendaFinal.Text = CType(txtMontoFinalCal.Text, String)
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                End If

                If rdbPostales.Checked = True Then
                    If vBase = True Then
                        txtPrecioPostalFinal.Text = CType(txtMontoFinalCal.Text, String)
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                    If vPeso = True Then
                        txtPrecioPostalPesoFinal.Text = CType(txtMontoFinalCal.Text, String)
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                    If vVolumen = True Then

                    End If
                End If

                If rdbGiros.Checked = True Then
                    If vBase = True Then
                        txtMontoBaseGiroFinal.Text = CType(txtMontoFinalCal.Text, String)
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                    If vPeso = True Then
                        txtPorctNormalFinal.Text = CType(txtMontoFinalCal.Text, String)
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                    If vVolumen = True Then
                        txtPorctTelefonoFinal.Text = CType(txtMontoFinalCal.Text, String)
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                End If
            ElseIf chkCondicional.Checked = True Then
                If rdbCarga.Checked = True Then
                    If vBase = True Then 'Si esta vacio pinta, sino pasa al segundo casillero.
                        txtMontoBaseCargaFinal.Text = CType(txtMontoFinalCal.Text, String)
                        txtMontoBaseEncomiendaFinal.Text = txtMontoBaseCargaFinal.Text
                        txtPrecioPostalFinal.Text = txtMontoBaseCargaFinal.Text
                        txtMontoBaseGiroFinal.Text = txtPrecioPostalFinal.Text
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                    If vPeso = True Then
                        txtPrecioPesoCargaFinal.Text = CType(txtMontoFinalCal.Text, String)
                        txtPrecioPesoEncomiendaFinal.Text = txtPrecioPesoCargaFinal.Text
                        txtPrecioPostalPesoFinal.Text = txtPrecioPesoCargaFinal.Text
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                    If vVolumen = True Then
                        txtPrecioVolumenCargaFinal.Text = CType(txtMontoFinalCal.Text, String)
                        txtPrecioVolumenEncomiendaFinal.Text = txtPrecioVolumenCargaFinal.Text
                        txtPrecioPostalVolumenFinal.Text = txtPrecioVolumenCargaFinal.Text
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                    If Vsobre = True Then
                        'Me.txt_cg_sobre.Text = CType(txtMontoFinalCal.Text, String)
                        Me.txtPrecioSobreCargaFinal.Text = CType(txtMontoFinalCal.Text, String)
                        gruCalculos.Visible = False
                        txtDecuentoCal.Text = ""
                        txtMontoFinalCal.Text = ""
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub FrmAcuerdoComercial_MenuSalir() Handles Me.MenuSalir
        Me.Close()
    End Sub

    Private Sub DesactivaMontosPublicos(ByVal ParamArray Montos() As TextBox)
        For i As Integer = 0 To UBound(Montos)
            Montos(i).ReadOnly = True
            Montos(i).BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        Next
    End Sub

    Private Sub ActivaMontosPublicos(ByVal ParamArray Montos() As TextBox)
        For i As Integer = 0 To UBound(Montos)
            Montos(i).ReadOnly = False
            Montos(i).BackColor = Color.White
        Next
    End Sub

    Private Sub chkCondicional_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCondicional.CheckedChanged
        If sender.checked = True Then
            Me.rdbCarga.PerformClick()
            DesactivaMontosPublicos(txtMontoBaseEncomiendaFinal, txtPrecioPesoEncomiendaFinal, txtPrecioVolumenEncomiendaFinal, _
                                    txtPrecioPostalFinal, txtPrecioPostalPesoFinal, _
                                    txtMontoBaseGiroFinal, txtPorctNormalFinal, txtPorctTelefonoFinal)
            'txtPrecioPostalVolumenFinal, _   tepsa
        ElseIf sender.checked = False Then
            ActivaMontosPublicos(txtMontoBaseEncomiendaFinal, txtPrecioPesoEncomiendaFinal, txtPrecioVolumenEncomiendaFinal, _
                                                txtPrecioPostalFinal, txtPrecioPostalPesoFinal, _
                                                txtMontoBaseGiroFinal, txtPorctNormalFinal, txtPorctTelefonoFinal)
            ' txtPrecioPostalVolumenFinal, _ tepsa 
        End If
    End Sub


    Private Sub btnCargarClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarClientes.Click
        Try
            If MyTreeView.Nodes(0).Checked = True Then
                'MessageBox.Show("Cargar Todos")
                DataGridLista.Columns.Clear()
                dvListaClientes = Funciones.CargarGrillaClientes(Me.DataGridLista)
                Dim FiltroLista As String = "IDTIPO_PERSONA ='" & 1 & "'"
                dvListaClientes.RowFilter = FiltroLista
                DataGridLista.Columns(4).Visible = True
                DataGridLista.Columns(5).Visible = False
                DataGridLista.Columns(40).Visible = False

            ElseIf MyTreeView.Nodes(0).Checked = False Then
                'MessageBox.Show("Cargar por Funcionario")
                For i As Integer = 0 To MyTreeView.Nodes(0).Nodes.Count - 1
                    If MyTreeView.Nodes(0).Nodes(i).Checked = True Then
                        DataGridLista.Columns.Clear()
                        dvListaClientes = Funciones.CargarGrillaClientes(Me.DataGridLista, MyTreeView.Nodes(0).Nodes(i).Text)

                        DataGridLista.Columns(4).Visible = True
                        DataGridLista.Columns(5).Visible = False
                        DataGridLista.Columns(40).Visible = False

                    End If
                Next
            End If
            txtBusqueda.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rdbArticulos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbArticulos.CheckedChanged
        If sender.checked = True Then
            ContenedorGrillas.Panel2Collapsed = True
        End If
    End Sub

    Private Sub rdbCondicionales_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCondicionales.CheckedChanged
        If sender.checked = True Then
            ContenedorGrillas.Panel1Collapsed = True
        End If
    End Sub

    Private Sub rdbAmbos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAmbos.CheckedChanged
        If sender.checked = True Then
            ContenedorGrillas.Panel1Collapsed = False
            ContenedorGrillas.Panel2Collapsed = False
        End If
    End Sub

    Private Sub rdbJuridicos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbJuridicos.CheckedChanged
        If sender.checked = True Then
            If DataGridLista.Columns.Count > 0 Then
                DataGridLista.Columns(5).Visible = False
                DataGridLista.Columns(4).Visible = True
                Dim FiltroLista As String = "IDTIPO_PERSONA ='" & 1 & "'"
                dvListaClientes.RowFilter = FiltroLista
            End If
        End If
    End Sub

    Private Sub rdbnaturales_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbnaturales.CheckedChanged
        If sender.checked = True Then
            If DataGridLista.Columns.Count > 0 Then
                DataGridLista.Columns(5).Visible = True
                DataGridLista.Columns(4).Visible = False
                Dim FiltroLista As String = "IDTIPO_PERSONA ='" & 2 & "'"
                dvListaClientes.RowFilter = FiltroLista
            End If
        End If
    End Sub

    Private Sub rdbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbTodos.CheckedChanged
        If sender.checked = True Then
            If DataGridLista.Columns.Count > 0 Then
                DataGridLista.Columns(5).Visible = True
                DataGridLista.Columns(4).Visible = True
                Dim FiltroLista As String = ""
                dvListaClientes.RowFilter = FiltroLista
            End If
        End If
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        If rdbJuridicos.Checked = True Then
            'Dim FiltroLista As String = "IDTIPO_PERSONA = 1 and RAZON_SOCIAL LIKE '%" & Me.txtBusqueda.Text & "%' AND FUNCIONARIO ='" & Funcionario & "'"
            Dim FiltroLista As String = "IDTIPO_PERSONA = 1 and RAZON_SOCIAL LIKE '%" & Me.txtBusqueda.Text & "%'"
            dvListaClientes.RowFilter = FiltroLista
        End If
        If rdbnaturales.Checked = True Then
            'Dim FiltroLista As String = "IDTIPO_PERSONA = 2 and NOMNRES_APELLIDOS LIKE '%" & Me.txtBusqueda.Text & "%' AND FUNCIONARIO ='" & Funcionario & "'"
            Dim FiltroLista As String = "IDTIPO_PERSONA = 2 and NOMNRES_APELLIDOS LIKE '%" & Me.txtBusqueda.Text & "%'"
            dvListaClientes.RowFilter = FiltroLista
        End If
        If rdbTodos.Checked = True Then
            'Dim FiltroLista As String = "(IDTIPO_PERSONA = 1 or IDTIPO_PERSONA = 2) and CODIGO_CLIENTE LIKE '%" & Me.txtBusqueda.Text & "%'"
            Dim FiltroLista As String = "(IDTIPO_PERSONA = 1 or IDTIPO_PERSONA = 2) and CODIGO_CLIENTE LIKE '%" & Me.txtBusqueda.Text & "%'"
            dvListaClientes.RowFilter = FiltroLista
        End If
    End Sub

    Private Sub GrabaTarifario()
        Try
            Dim MyTarifarios As New dtoTARIFACLIENTES
            With MyTarifarios
                .Control = vAccionRegistro
                .IDTarifaCargaCLiente = CType(Me.txtID.Text, Decimal)
                .CodigoCliente = Me.txtCodigoCLiente.Text
                .IDCiudadOrigen = Me.cmbOrigen.SelectedValue
                .IDCiudadDestino = Me.cmbDestino.SelectedValue
                If Me.txtMontoBaseCargaFinal.Text = "" Then
                    .CargaMontoBase = 0
                Else
                    .CargaMontoBase = CType(Me.txtMontoBaseCargaFinal.Text, Decimal)
                End If
                If Me.txtPrecioPesoCargaFinal.Text = "" Then
                    .CargaPeso = 0
                Else
                    .CargaPeso = CType(Me.txtPrecioPesoCargaFinal.Text, Decimal)
                End If
                If Me.txtPrecioVolumenCargaFinal.Text = "" Then
                    .CargaVolumen = 0
                Else
                    .CargaVolumen = CType(Me.txtPrecioVolumenCargaFinal.Text, Decimal)
                End If
                .EncomiendaMontoBase = CType(Me.txtMontoBaseEncomiendaFinal.Text, Decimal)
                .EncomiendaPeso = CType(Me.txtPrecioPesoEncomiendaFinal.Text, Decimal)
                .EncomiendaVolumen = CType(Me.txtPrecioVolumenEncomiendaFinal.Text, Decimal)
                .PostalMontoBase = CType(Me.txtPrecioPostalFinal.Text, Decimal)
                .PostalPeso = CType(Me.txtPrecioPostalPesoFinal.Text, Decimal)
                .PostalVolumen = CType(Me.txtPrecioPostalVolumenFinal.Text, Decimal)
                .GiroMontoBase = CType(Me.txtMontoBaseGiroFinal.Text, Decimal)
                .NormalGiroPeso = CType(Me.txtPorctNormalFinal.Text, Decimal)
                .TelefonoGiroVolumen = CType(Me.txtPorctTelefonoFinal.Text, Decimal)
                If Me.txtPrecioSobreCargaFinal.Text = "" Then
                    .sobre_xcarga = 0
                Else
                    .sobre_xcarga = CType(Me.txtPrecioSobreCargaFinal.Text, Double)
                End If
                '
                .FechaActivacion = Me.TxtFecIni._MyFecha
                '
                .FechaDesactivacion = "14/06/2006"  '---> Ojo está com desactivación 
                .CENTRO_COSTO = Me.cmbSubCuenta.SelectedValue
                If ChkVigente.Checked = True Then
                    .EsVigente = 1
                ElseIf ChkVigente.Checked = False Then
                    .EsVigente = 0
                End If
                .EstadoRegistro = 1
                .UsuarioPersonal = MyUsuario
                .RolUsuario = MyRol
                .IP = MyIP

            End With

            'datahelper
            'Dim respTarifarios As ADODB.Recordset
            'respTarifarios = MyTarifarios.GrabaTarifarios_RGT()


            Dim respTarifarios As DataTable = MyTarifarios.GrabaTarifarios_RGT()
            If respTarifarios.Rows.Count = 1 Then 'Se realizo Correctamente.
                MessageBox.Show(respTarifarios.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call GrabaCondicionales()
                Call GrabaArticulos()
                Call AccionesGrabar()
            ElseIf respTarifarios.Rows.Count = 2 And Len(Trim(respTarifarios.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                MessageBox.Show("Descripción: " & respTarifarios.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respTarifarios.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
           




            'datahelper
            'If respTarifarios.Fields.Count = 1 Then 'Se realizo Correctamente.
            '    MessageBox.Show(respTarifarios.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Call GrabaCondicionales()
            '    Call GrabaArticulos()
            '    Call AccionesGrabar()
            'ElseIf respTarifarios.Fields.Count = 2 And Len(Trim(respTarifarios.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
            '    MessageBox.Show("Descripción: " & respTarifarios.Fields(1).Value, "ORACLE -> Error: " & respTarifarios.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvTarifasCliente_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvTarifasCliente.DoubleClick
        'MessageBox.Show(DataGridLista.RowCount)
        'MessageBox.Show(dvTarifasCliente.Table.Rows.Count)
        Try
            Dim origen As Integer
            Dim destino As Integer

            ' If Not IsDBNull(dvTarifasCliente.Table.Rows.Count) Then
            If dvTarifasCliente.Table.Rows.Count > 0 Then
                Dim dgvrCliente As DataGridViewRow = Me.DataGridLista.CurrentRow()
                txtCodigoCLiente.Text = CType(dgvrCliente.Cells("CODIGO").Value, String)
                txtNombreCliente.Text = CType(dgvrCliente.Cells("RAZONSOCIAL").Value, String)
                txtFuncionarioActual.Text = CType(dgvrCliente.Cells("FUNCIONARIO").Value, String)
                Me.txt_porcentaje_descuento.Text = CType(dgvrCliente.Cells("DESCUENTO").Value, String)
                '
                Dim dgvr As DataGridViewRow = Me.dgvTarifasCliente.CurrentRow()
                Dim iidtarifariocliente As Integer
                '
                cmbOrigen.SelectedValue = CType(dgvr.Cells(2).Value, Integer)
                'cmbDestino.SelectedValue = CType(dgvr.Cells(4).Value, Integer) '11/12/2008 
                cmbDestino.SelectedValue = CType(dgvr.Cells(3).Value, Integer)
                ' Tepsa 
                origen = CType(dgvr.Cells(2).Value, Integer)
                'destino = CType(dgvr.Cells(4).Value, Integer) '11/12/2008 
                destino = CType(dgvr.Cells(3).Value, Integer)
                'Call CargaTarifasBase(cmbOrigen.SelectedValue, cmbDestino.SelectedValue)

                'Call CargaTarifasBase(origen, destino) -- Comentado 15/12/2008 

                '
                dvOrigen.RowFilter = "IDUNIDAD_AGENCIA = " & CType(dgvr.Cells(2).Value, Integer)
                'dvDestino.RowFilter = "IDUNIDAD_AGENCIA = " & CType(dgvr.Cells(4).Value, Integer)
                dvDestino.RowFilter = "IDUNIDAD_AGENCIA = " & CType(dgvr.Cells(3).Value, Integer)
                '
                ' Loco 
                '
                If IsDBNull(dgvr.Cells(0).Value) = True Then
                    'recupera los datos cuando no tienen
                    'Recupera_datos_para la nueva tarifa - 13/12/2008 
                    get_datos_tarifa_nueva(dgvr)
                Else
                    txtID.Text = CType(dgvr.Cells(0).Value, String)
                    iidtarifariocliente = CType(txtID.Text, Integer)
                    '
                    txtMontoBaseCargaFinal.Text = CType(dgvr.Cells("pre_base_pers").Value, String)
                    txtPrecioPesoCargaFinal.Text = CType(dgvr.Cells("pre_x_peso_per").Value, String)
                    txtPrecioVolumenCargaFinal.Text = CType(dgvr.Cells("pre_x_volumen_pers").Value, String)
                    Me.txtPrecioSobreCargaFinal.Text = CType(dgvr.Cells("pre_x_sobre_pers").Value, String)
                    '
                End If
                'Else
                '   MsgBox("El destino Seleccionado no Tiene Tarifario")
                'End If
                'No se visuali
                'txtMontoBaseCargaFinal.Text = CType(dgvr.Cells(6).Value, String)
                'txtPrecioPesoCargaFinal.Text = CType(dgvr.Cells(7).Value, String)
                'txtPrecioVolumenCargaFinal.Text = CType(dgvr.Cells(8).Value, String)
                'txtMontoBaseEncomiendaFinal.Text = CType(dgvr.Cells(9).Value, String)
                'txtPrecioPesoEncomiendaFinal.Text = CType(dgvr.Cells(10).Value, String)
                'txtPrecioVolumenEncomiendaFinal.Text = CType(dgvr.Cells(11).Value, String)
                'txtPrecioPostalFinal.Text = CType(dgvr.Cells(12).Value, String)
                'txtPrecioPostalPesoFinal.Text = CType(dgvr.Cells(13).Value, String)
                'txtPrecioPostalVolumenFinal.Text = CType(dgvr.Cells(14).Value, String)
                'txtMontoBaseGiroFinal.Text = CType(dgvr.Cells(15).Value, String)
                'txtPorctNormalFinal.Text = CType(dgvr.Cells(16).Value, String)
                'txtPorctTelefonoFinal.Text = CType(dgvr.Cells(17).Value, String)
                '
                'verificar los datos con respecto a si encuentra en el tarifario publico

                ' Tepsa 
                dvArticulos = Nothing
                dvArticulos = New DataView
                'If dtTarifasPublicas.Rows.Count > 0 Then
                dgvArticulo.Columns.Clear()


                cargar_cmb_centro_costo()
                lista_tarifas = True


                dvArticulos = Funciones.CargarArticulos_x_cliente(dgvArticulo, txtCodigoCLiente.Text, iidtarifariocliente, origen, destino)
                '
                dgvCondicional.Columns.Clear()  ' Adicionado por Tepsa 
                If dtTarifasPublicas.Rows.Count > 0 Then
                    Call CargarTarifasCondicional(Me.dgvCondicional, CType(iidtarifariocliente, Long))
                    For i As Integer = 0 To Me.dgvCondicional.RowCount - 1 Step 2
                        If IsDBNull(dgvCondicional.Rows(i).Cells(3).Value) = True Then   'If agregado por Tepsa 
                            dgvCondicional.Rows(i).Cells(3).Value = 0
                        Else
                            dgvCondicional.Rows(i).Cells(3).Value = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(3)), 2), "####0.00")
                        End If
                    Next
                    For i As Integer = 1 To Me.dgvCondicional.RowCount - 1 Step 2
                        If IsDBNull(dgvCondicional.Rows(i).Cells(3).Value) = True Then 'If agregado por Tepsa 
                            dgvCondicional.Rows(i).Cells(3).Value = 0
                        Else
                            dgvCondicional.Rows(i).Cells(3).Value = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(4)), 2), "####0.00")
                        End If
                    Next
                Else
                    'Carga las condicionales cuando no exista la tarifa - 20/12/2008 - 
                    Call CargarTarifasCondicional(Me.dgvCondicional, 0)
                End If
                'If dvArticulos.Count < 1 Then
                '    dvArticulos = Funciones.CargarArticulos(dgvArticulo)
                'End If
                'Else 
                '    dvArticulos = Funciones.CargarArticulos(dgvArticulo)
                'End If
                vAccionRegistro = 2 'Registro ya existe  tepsa 
                SelectMenu(2)
            Else
                Dim dgvrCliente As DataGridViewRow = Me.DataGridLista.CurrentRow()
                txtCodigoCLiente.Text = CType(dgvrCliente.Cells("CODIGO").Value, String)
                txtNombreCliente.Text = CType(dgvrCliente.Cells("RAZONSOCIAL").Value, String)
                txtFuncionarioActual.Text = CType(dgvrCliente.Cells("FUNCIONARIO").Value, String)
                Me.txt_porcentaje_descuento.Text = CType(dgvrCliente.Cells("PORCENTAJE_DESCUENTO").Value, String)
                MenuTab.Items(1).Visible = False
                SelectMenu(2)
            End If
            ' Configurando se activa los campos  - Tepsa 
            txtMontoBaseCargaFinal.ReadOnly = False
            txtPrecioPesoCargaFinal.ReadOnly = False
            txtPrecioVolumenCargaFinal.ReadOnly = False
            txtPrecioSobreCargaFinal.ReadOnly = False
            txtMontoBaseCargaFinal.BackColor = Color.White
            txtPrecioPesoCargaFinal.BackColor = Color.White
            txtPrecioVolumenCargaFinal.BackColor = Color.White
            txtPrecioSobreCargaFinal.BackColor = Color.Yellow
            '
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function f_Actualizar_Tarifa() As Integer
        'MessageBox.Show("Se actualizo Correctamente")

        txtMontoBaseCargaFinal.ReadOnly = False
        txtPrecioPesoCargaFinal.ReadOnly = False
        txtPrecioVolumenCargaFinal.ReadOnly = False
        txtMontoBaseCargaFinal.BackColor = Color.White
        txtPrecioPesoCargaFinal.BackColor = Color.White
        txtPrecioVolumenCargaFinal.BackColor = Color.White
    End Function

   
    'Private Sub btncargaTarifa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncargaTarifa.Click
    '    'Modificacion Diego Zegarra T.  20/06/2013

    '    Try
    '        Dim bflag As Boolean = False
    '        Dim rstBusqueda As String

    '        rstBusqueda = Funciones.BuscaTarifarioII(txtCodigoCLiente.Text, cmbOrigen.SelectedValue, cmbDestino.SelectedValue)
    '        If rstBusqueda > 0 Then
    '            MessageBox.Show("YA EXISTE UNA TARIFA PARA ESTE ORIGEN Y DESTINO", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            If (MessageBox.Show("Desea Modificar la Tarifa", "Mensaje Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
    '                'FrmTarifarioCliente_MenuEditar()
    '                F_Editar_Tarifa()
    '            Else
    '                txtMontoBaseCargaFinal.Enabled = False
    '                txtPrecioPesoCargaFinal.Enabled = False
    '                txtPrecioVolumenCargaFinal.Enabled = False
    '                txtMontoBaseCargaFinal.Enabled = False
    '                txtPrecioPesoCargaFinal.Enabled = False
    '                txtPrecioVolumenCargaFinal.Enabled = False
    '                txtPrecioSobreCargaFinal.Enabled = False
    '            End If
    '        ElseIf rstBusqueda = 0 Then
    '            Call CargaTarifasBase(cmbOrigen.SelectedValue, cmbDestino.SelectedValue)
    '            ' Tepsa 
    '            txtMontoBaseCargaFinal.ReadOnly = False
    '            txtPrecioPesoCargaFinal.ReadOnly = False
    '            txtPrecioVolumenCargaFinal.ReadOnly = False
    '            txtMontoBaseCargaFinal.BackColor = Color.White
    '            txtPrecioPesoCargaFinal.BackColor = Color.White
    '            txtPrecioVolumenCargaFinal.BackColor = Color.White
    '            bflag = True
    '        End If

    '        If bflag Then
    '            ' Recupera los valores, Tepsa 
    '            idciudad_origen = cmbOrigen.SelectedValue
    '            Dim iidtarifario As Integer
    '            iidtarifario = CType(txtID.Text, Integer)
    '            dgvArticulo.Columns.Clear()
    '            dvArticulos = Funciones.CargarArticulos_x_cliente(dgvArticulo, txtCodigoCLiente.Text, iidtarifario, idciudad_origen, cmbDestino.SelectedValue)
    '            '
    '        End If
    '    Catch Qex As Exception
    '        MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    '    ' Fin Modificacion
    'End Sub

    Private Sub gruCalculos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gruCalculos.DoubleClick
        gruCalculos.Visible = False
    End Sub

    Private Sub LimpiaTexBoxs(ByVal ParamArray Montos() As TextBox)
        For i As Integer = 0 To UBound(Montos)
            Montos(i).Text = ""
        Next
    End Sub

    Private Sub txtMontoBaseCargaFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMontoBaseCargaFinal.TextChanged
        If Me.chkCondicional.Checked = True Then
            Me.txtMontoBaseEncomiendaFinal.Text = Me.txtMontoBaseCargaFinal.Text
            Me.txtPrecioPostalFinal.Text = Me.txtMontoBaseCargaFinal.Text
            Me.txtMontoBaseGiroFinal.Text = Me.txtMontoBaseCargaFinal.Text
        End If
    End Sub

    Private Sub txtPrecioPesoCargaFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecioPesoCargaFinal.TextChanged
        If Me.chkCondicional.Checked = True Then
            Me.txtPrecioPesoEncomiendaFinal.Text = Me.txtPrecioPesoCargaFinal.Text
            Me.txtPrecioPostalPesoFinal.Text = Me.txtPrecioPesoCargaFinal.Text
            Me.txtPorctNormalFinal.Text = 0 'Me.txtPrecioPesoCargaFinal.Text
        End If
    End Sub

    Private Sub txtPrecioVolumenCargaFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecioVolumenCargaFinal.TextChanged
        If Me.chkCondicional.Checked = True Then
            Me.txtPrecioVolumenEncomiendaFinal.Text = Me.txtPrecioVolumenCargaFinal.Text
            Me.txtPrecioPostalVolumenFinal.Text = Me.txtPrecioVolumenCargaFinal.Text
            Me.txtPorctTelefonoFinal.Text = 0 'Me.txtPrecioVolumenCargaFinal.Text
        End If
    End Sub

    Private Sub MyTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyTreeView.AfterSelect
        For i As Integer = 0 To MyTreeView.Nodes(0).Nodes.Count - 1
            MyTreeView.Nodes(0).Nodes(i).Checked = False
        Next
        e.Node.Checked = True
    End Sub

    Private Sub GrabaCondicionales()
        Dim dgvr As DataGridViewRow = dgvCondicional.CurrentRow
        Dim l_idcontrol As Integer = 1
        For i As Integer = 0 To Me.dgvCondicional.RowCount - 1
            '  If IsDBNull(dgvCondicional.Rows(i).Cells(8).Value) = True Or dgvCondicional.Rows(i).Cells(7).Value <> 0 Then
            Try
                Dim MyCondicionales As New dtoCONDICIONALES_TARIFA
                With MyCondicionales
                    'If IsDBNull(dgvCondicional.Rows(i).Cells(8).Value) = True Then ' Recupera la idunidad Agencia 
                    '    l_idcontrol = 1
                    'Else
                    '    If CType(dgvCondicional.Rows(i).Cells(8).Value, Integer) <> 0 Then
                    '        l_idcontrol = 1
                    '    Else
                    '        l_idcontrol = 2
                    '    End If
                    'End If
                    .Control = l_idcontrol 'vAccionRegistro     Tepsa 
                    '.Control = vAccionRegistro
                    .CodigoCliente = Me.txtCodigoCLiente.Text
                    .Origen = Me.cmbOrigen.SelectedValue
                    .Destino = Me.cmbDestino.SelectedValue
                    .IDCondicional = 1 'Momentaneamente
                    .Concepto = dgvCondicional.Rows(i).Cells(0).Value
                    .Unidad = dgvCondicional.Rows(i).Cells(1).Value
                    .Inicio = dgvCondicional.Rows(i).Cells(4).Value
                    .Fin = dgvCondicional.Rows(i).Cells(5).Value
                    .PrecioFinal = dgvCondicional.Rows(i).Cells(7).Value
                End With

                'Dim respCondicionales As ADODB.Recordset
                'respCondicionales = MyCondicionales.GrabaCondicionales
                'datahelper
                Dim respCondicionales As DataTable = MyCondicionales.GrabaCondicionales

                If respCondicionales.Rows.Count = 1 Then 'Se realizo Correctamente.
                ElseIf respCondicionales.Rows.Count = 2 And Len(Trim(respCondicionales.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                End If

                'datahelper
                'If respCondicionales.Fields.Count = 1 Then 'Se realizo Correctamente.
                'ElseIf respCondicionales.Fields.Count = 2 And Len(Trim(respCondicionales.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                'End If

            Catch Qex As Exception
                MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            'End If
        Next
    End Sub

    Private Sub AccionesGrabar()
        SelectMenu(0)
        SplitContainer2.Panel1Collapsed = False
        NuevoToolStripMenuItem.Enabled = True
        EdicionToolStripMenuItem.Enabled = True
        CancelarToolStripmenuItem.Enabled = False
        CancelarToolStripmenuItem.Visible = False
        GrabarToolStripMenuItem.Enabled = False
        EliminarToolStripMenuItem.Enabled = True
        ExportarToolStripMenuItem.Enabled = True
        ImprimirToolStripMenuItem.Enabled = True
    End Sub

    Private Sub dgvArticulo_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArticulo.CellEndEdit
        If e.ColumnIndex = 3 Then
            If IsDBNull(dgvArticulo.Rows(e.RowIndex).Cells(2).Value) Then
                MessageBox.Show("NO HAY MONTO BASE PARA ESTE ARTICULO", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvArticulo.Rows(e.RowIndex).Cells(3).Value = "0"
                dgvArticulo.Rows(e.RowIndex).Cells(4).Value = "0"
            Else
                dgvArticulo.Rows(e.RowIndex).Cells(4).Value = dgvArticulo.Rows(e.RowIndex).Cells(2).Value * (1 + (dgvArticulo.Rows(e.RowIndex).Cells(3).Value / 100))
            End If
        End If
    End Sub
    Private Sub dgvCondicional_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCondicional.CellEndEdit
        If e.ColumnIndex = 6 Then
            dgvCondicional.Rows(e.RowIndex).Cells(7).Value = dgvCondicional.Rows(e.RowIndex).Cells(3).Value * (1 + (dgvCondicional.Rows(e.RowIndex).Cells(6).Value / 100))
        End If
    End Sub
    Private Sub GrabaArticulos2009_eliminarlo()

        'Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_LIMPIA_ARTICULOS", 4, Me.txtCodigoCLiente.Text, 2}
        'Dim a As ADODB.Recordset
        'a = VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)

        'For i As Integer = 0 To Me.dgvArticulo.RowCount - 1
        '    If Me.dgvArticulo.Rows(i).Cells(4).Value <> 0 Then

        '        'MessageBox.Show(i)
        '        Try
        '            Dim MyArticulos As New dtoARTICULOS_CLIENTE
        '            With MyArticulos
        '                .Control = 1 'vAccionRegistro
        '                .CodigoCliente = Me.txtCodigoCLiente.Text
        '                .Origen = Me.cmbOrigen.SelectedValue
        '                .Destino = Me.cmbDestino.SelectedValue
        '                .IDArticulosCliente = 1 'Momentaneamente
        '                '.Articulo = Me.dgvArticulo.Rows(i).Cells(1).Value 'Guarda El Nombre del Articulo
        '                .Articulo = Me.dgvArticulo.Rows(i).Cells(0).Value
        '                .PrecioFinal = Me.dgvArticulo.Rows(i).Cells(4).Value
        '            End With

        '            'Dim respArticulos As ADODB.Recordset
        '            'respArticulos = MyArticulos.GrabaArticulos

        '            MyArticulos.IDTARIFA_CARGA_CLIENTE = Me.txtID.Text

        '            MyArticulos.CENTRO_COSTO = Me.cmbSubCuenta.SelectedValue
        '            'datahelper
        '            'respArticulos = MyArticulos.GrabaArticulos_CC
        '            Dim respArticulos As DataTable = MyArticulos.GrabaArticulos_CC

        '            If respArticulos.Rows.Count = 1 Then 'Se realizo Correctamente.
        '                'MessageBox.Show(respArticulos.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            ElseIf respArticulos.Rows.Count = 2 And Len(Trim(respArticulos.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
        '                MessageBox.Show("Descripción: " & respArticulos.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respArticulos.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            End If

        '            'If respArticulos.Fields.Count = 1 Then 'Se real+izo Correctamente.
        '            'ElseIf respArticulos.Fields.Count = 2 And Len(Trim(respArticulos.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
        '            'MessageBox.Show("Descripción: " & respArticulos.Fields(1).Value, "ORACLE -> Error: " & respArticulos.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            'End If

        '        Catch Qex As Exception
        '            MessageBox.Show(Qex.Message, "Seguridad del Sustema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End Try
        '    End If
        'Next
    End Sub
    Private Sub cmbOrigen_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOrigen.SelectedValueChanged
        Try
            '
            If b_lee = True Then
                get_tarifa_publica(cmbOrigen.SelectedValue, cmbDestino.SelectedValue)
            End If
            dvDestino.RowFilter = "IDUNIDAD_AGENCIA<>9999 AND IDUNIDAD_AGENCIA <> " & Me.cmbOrigen.SelectedValue
            '
        Catch ex As Exception
        End Try
    End Sub
    Private Sub validar_tarifa_cliente()
        '    ' Validar tarifario 
        '    Try
        '        Dim bflag As Boolean = False
        '        Dim rstBusqueda As ADODB.Recordset
        '        rstBusqueda = Funciones.BuscaTarifario(txtCodigoCLiente.Text, cmbOrigen.SelectedValue, cmbDestino.SelectedValue)
        '        If rstBusqueda.Fields.Count > 0 Then
        '            If rstBusqueda.Fields.Item(0).Value = "YA EXISTE UNA TARIFA PARA ESTE ORIGEN Y DESTINO" Then
        '                MessageBox.Show("YA EXISTE UNA TARIFA PARA ESTE ORIGEN Y DESTINO", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '                MenuTab.Items(0).Enabled = False
        '                MenuTab.Items(1).Visible = True
        '                SelectMenu(1)
        '                vAccionRegistro = 2
        '                dvTarifasCliente = Funciones.CargarTarifaCliente(Me.txtCodigoCLiente.Text, dgvTarifasCliente)
        '            Else
        '                Call CargaTarifasBase(cmbOrigen.SelectedValue, cmbDestino.SelectedValue)
        '                bflag = True
        '            End If
        '        ElseIf rstBusqueda.Fields.Count = 0 Then
        '            Call CargaTarifasBase(cmbOrigen.SelectedValue, cmbDestino.SelectedValue)
        '            bflag = True
        '        End If
        '        If bflag Then
        '            ' Recupera los valores, Tepsa 
        '            idciudad_origen = cmbOrigen.SelectedValue
        '            Dim iidtarifario As Integer
        '            iidtarifario = CType(txtID.Text, Integer)
        '            dgvArticulo.Columns.Clear()
        '            dvArticulos = Funciones.CargarArticulos_x_cliente(dgvArticulo, txtCodigoCLiente.Text, iidtarifario, idciudad_origen, cmbDestino.SelectedValue)
        '            '
        '        End If
        '    Catch Qex As Exception
        '        MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
    End Sub

    
    Private Sub dgvTarifasCliente_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTarifasCliente.CellContentClick

    End Sub

    Private Sub cmbSubCuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubCuenta.SelectedIndexChanged
        Try

            If lista_tarifas = False Then Exit Sub

            Dim origen As Integer
            Dim destino As Integer

            Dim dgvrCliente As DataGridViewRow = Me.DataGridLista.CurrentRow()
            txtCodigoCLiente.Text = CType(dgvrCliente.Cells("CODIGO").Value, String)
            txtNombreCliente.Text = CType(dgvrCliente.Cells("RAZONSOCIAL").Value, String)
            txtFuncionarioActual.Text = CType(dgvrCliente.Cells("FUNCIONARIO").Value, String)


            Dim dgvr As DataGridViewRow = Me.dgvTarifasCliente.CurrentRow()
            Dim iidtarifariocliente As Integer

            cmbOrigen.SelectedValue = CType(dgvr.Cells(2).Value, Integer)
            'cmbDestino.SelectedValue = CType(dgvr.Cells(4).Value, Integer)
            cmbDestino.SelectedValue = CType(dgvr.Cells(3).Value, Integer)

            'Tepsa 
            origen = CType(dgvr.Cells(2).Value, Integer)
            'destino = CType(dgvr.Cells(4).Value, Integer)
            destino = CType(dgvr.Cells(3).Value, Integer)   ' 12/12/2008 

            'Call CargaTarifasBase(cmbOrigen.SelectedValue, cmbDestino.SelectedValue)
            Call CargaTarifasBase(origen, destino)

            '
            dvOrigen.RowFilter = "IDUNIDAD_AGENCIA = " & CType(dgvr.Cells(2).Value, Integer)
            'dvDestino.RowFilter = "IDUNIDAD_AGENCIA = " & CType(dgvr.Cells(4).Value, Integer)
            dvDestino.RowFilter = "IDUNIDAD_AGENCIA = " & CType(dgvr.Cells(3).Value, Integer)



            objGuiaEnvio.iIDCENTRO_COSTO = Me.cmbSubCuenta.SelectedValue
            objGuiaEnvio.iIDUNIDAD_AGENCIA = origen
            objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = destino
            'objGuiaEnvio.iarticulo = dgvArticulo.CurrentRow.Cells(0).Value
            objGuiaEnvio.iarticulo = 0
            objGuiaEnvio.iIRuc_Rason_Social = txtCodigoCLiente.Text
            '
            'Mod. 22/08/2009 -->Omendoza - Pasando al datahelper - Puede ser con los valores datables
            '
            If objGuiaEnvio.sp_busca_dtarifa_carga_cli = True Then
                'datahelper
                'txtID.Text = objGuiaEnvio.cur_idtarifas_carga_cliente.Fields(0).Value
                txtID.Text = objGuiaEnvio.dt_cur_idtarifas_carga_cliente.Rows(0).Item(0)
                iidtarifariocliente = CType(txtID.Text, Integer)
            End If
            '
            ' Tepsa 
            dvArticulos = Nothing
            dvArticulos = New DataView

            'If dtTarifasPublicas.Rows.Count > 0 Then
            dgvArticulo.Columns.Clear()

            objGuiaEnvio.iIRuc_Rason_Social = txtCodigoCLiente.Text

            Dim iidcentro_costo As Integer = Me.cmbSubCuenta.SelectedValue

            dvArticulos = Funciones.CargarArticulos_x_cliente_CC(iidcentro_costo, dgvArticulo, txtCodigoCLiente.Text, iidtarifariocliente, origen, destino)


        Catch qex As Exception
            MessageBox.Show(qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub get_datos_tarifa_nueva(ByVal dgvr As DataGridViewRow)
        Try
            txtID.Text = "0"
            vAccionRegistro = 1 '
            Me.cmbOrigen.SelectedValue = CType(dgvr.Cells("IDUNIDAD_AGENCIA").Value, Long)
            Me.cmbDestino.SelectedValue = CType(dgvr.Cells("IDUNIDAD_AGENCIA_DESTINO").Value, Long)
            '
            txtMontoBaseCargaFinal.Text = CType(dgvr.Cells("Neto_base").Value, String)
            txtPrecioPesoCargaFinal.Text = CType(dgvr.Cells("peso_neto").Value, String)
            txtPrecioVolumenCargaFinal.Text = CType(dgvr.Cells("volumen_neto").Value, String)
            txtPrecioSobreCargaFinal.Text = CType(dgvr.Cells("sobre_neto").Value, String)
            '
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtPrecioSobreCargaFinal_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrecioSobreCargaFinal.KeyUp
        If e.KeyCode = Keys.Enter Then
            gruCalculos.Visible = True
            gruCalculos.BringToFront()
            Beep()
            txtDecuentoCal.Text = ""
            txtMontoFinalCal.Text = ""
            sender.text = ""
            txtMontoFinalCal.Focus()
            vBase = False
            vPeso = False
            vVolumen = False
            Vsobre = True
        End If
    End Sub

    Private Sub cargar_cmb_centro_costo2009_eliminarlo()
        ''
        'objGuiaEnvio.iIRuc_Rason_Social = txtCodigoCLiente.Text
        'objGuiaEnvio.SP_SUB_CUENTAS_TARIFAS(dvidcentro_costo, cmbSubCuenta, VOCONTROLUSUARIO)
        ''
        'cmbSubCuenta.SelectedIndex = 0
        ''
    End Sub

    Private Sub cargar_cmb_centro_costo()
        Try
            '
            objGuiaEnvio.iIRuc_Rason_Social = txtCodigoCLiente.Text
            'datahelper
            'objGuiaEnvio.SP_SUB_CUENTAS_TARIFAS(dvidcentro_costo, cmbSubCuenta, VOCONTROLUSUARIO)
            objGuiaEnvio.SP_SUB_CUENTAS_TARIFAS(dvidcentro_costo, cmbSubCuenta)
            '
            cmbSubCuenta.SelectedIndex = 0
            '
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargaTarifasBase2009_eliminarlo(ByVal Origen As Integer, ByVal Destino As Integer)
        'Try
        '    ' Dim dtTarifasPublicas As New DataTable   -- Origen Tepsa 
        '    'dtTarifasPublicas.Clear()
        '    'Iniciando variables - TEpsa
        '    dtTarifasPublicas = Nothing
        '    dtTarifasPublicas = New DataTable
        '    '            
        '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_CARGA_TARIFA_PUBLICA", 6, Origen, 1, Destino, 1}
        '    rstTarifasPublicas = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
        '    Dim da As New OleDbDataAdapter
        '    da.Fill(dtTarifasPublicas, rstTarifasPublicas)
        '    'MessageBox.Show(dtTarifasPublicas.Rows.Count)
        '    If dtTarifasPublicas.Rows.Count > 0 Then
        '        'Format(Math.Round(Convert.ToDouble(DrUnd("CG_MONTO_BASE")), 2), "####0.00")
        '        Me.txtMontoBaseCarga.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
        '        Me.txtPrecioPesoCarga.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(3)), 2), "####0.00")
        '        Me.txtPrecioVolumenCarga.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(4)), 2), "####0.00")
        '        Me.txtMontoBaseEncomienda.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(5)), 2), "####0.00")
        '        Me.txtPrecioPesoEncomienda.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(6)), 2), "####0.00")
        '        Me.txtPrecioVolumenEncomienda.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(7)), 2), "####0.00")
        '        Me.txtPrecioPostalBase.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(8)), 2), "####0.00")
        '        Me.txtPrecioPostalPeso.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(9)), 2), "####0.00")
        '        Me.txtPrecioPostalVolumen.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(10)), 2), "####0.00")
        '        Me.txtMontoBaseGiro.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(11)), 2), "####0.00")
        '        Me.txtPorctNormal.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(12)), 2), "####0.00")
        '        Me.txtPorctTelefono.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(13)), 2), "####0.00")
        '        'Se agrega el campo 
        '        Me.txt_cg_sobre.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(19)), 2), "####0.00")

        '        For i As Integer = 0 To Me.dgvCondicional.RowCount - 1 Step 2
        '            dgvCondicional.Rows(i).Cells(3).Value = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(3)), 2), "####0.00")
        '        Next
        '        For i As Integer = 1 To Me.dgvCondicional.RowCount - 1 Step 2
        '            dgvCondicional.Rows(i).Cells(3).Value = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(4)), 2), "####0.00")
        '        Next
        '    Else
        '        '    MessageBox.Show("No Hay Tarifario Público", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Catch Qex As Exception
        '    MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub CargaTarifasBase(ByVal Origen As Integer, ByVal Destino As Integer)
        Try
            dtTarifasPublicas = Nothing
            dtTarifasPublicas = New DataTable
            '            
            'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_CARGA_TARIFA_PUBLICA", 6, Origen, 1, Destino, 1}
            'rstTarifasPublicas = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
            'Dim da As New OleDbDataAdapter
            'da.Fill(dtTarifasPublicas, rstTarifasPublicas)
            Dim obj As New dtoTARIFACLIENTES

            '  IIf(IsDBNull(dtResultado.Rows(0).Item("CLIENTE")), "", dtResultado.Rows(0).Item("CLIENTE"))
            dtTarifasPublicas = obj.CARGA_TARIFA_PUBLICA(Origen, Destino)
            If dtTarifasPublicas.Rows.Count > 0 Then
                If (IsDBNull(Me.txtMontoBaseCarga.Text)) Then
                    Me.txtMontoBaseCarga.Text = 0
                Else
                    Me.txtMontoBaseCarga.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
                End If

                If (IsDBNull(Me.txtPrecioPesoCarga.Text)) Then
                    Me.txtPrecioPesoCarga.Text = 0
                Else
                    Me.txtPrecioPesoCarga.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
                End If

                If (IsDBNull(Me.txtPrecioVolumenCarga.Text)) Then
                    Me.txtPrecioVolumenCarga.Text = 0
                Else
                    Me.txtPrecioVolumenCarga.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
                End If

                If (IsDBNull(Me.txtMontoBaseEncomienda.Text)) Then
                    Me.txtMontoBaseEncomienda.Text = 0
                Else
                    Me.txtMontoBaseEncomienda.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
                End If

                If (IsDBNull(Me.txtPrecioPesoEncomienda.Text)) Then
                    Me.txtPrecioPesoEncomienda.Text = 0
                Else
                    Me.txtPrecioPesoEncomienda.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
                End If

                If (IsDBNull(Me.txtPrecioVolumenEncomienda.Text)) Then
                    Me.txtPrecioVolumenEncomienda.Text = 0
                Else
                    Me.txtPrecioVolumenEncomienda.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
                End If
                If (IsDBNull(Me.txtPrecioPostalBase.Text)) Then
                    Me.txtPrecioPostalBase.Text = 0
                Else
                    Me.txtPrecioPostalBase.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
                End If
                If (IsDBNull(Me.txtPrecioPostalPeso.Text)) Then
                    Me.txtPrecioPostalPeso.Text = 0
                Else
                    Me.txtPrecioPostalPeso.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
                End If
                If (IsDBNull(Me.txtPrecioPostalVolumen.Text)) Then
                    Me.txtPrecioPostalVolumen.Text = 0
                Else
                    Me.txtPrecioPostalVolumen.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
                End If

                If (IsDBNull(Me.txtMontoBaseGiro.Text)) Then
                    Me.txtMontoBaseGiro.Text = 0
                Else
                    Me.txtMontoBaseGiro.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
                End If

                If (IsDBNull(Me.txtPorctNormal.Text)) Then
                    Me.txtPorctNormal.Text = 0
                Else
                    Me.txtPorctNormal.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
                End If

                If (IsDBNull(Me.txtPorctTelefono.Text)) Then
                    Me.txtPorctTelefono.Text = 0
                Else
                    Me.txtPorctTelefono.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
                End If

                If (IsDBNull(Me.txt_cg_sobre.Text)) Then
                    Me.txt_cg_sobre.Text = 0
                Else
                    Me.txt_cg_sobre.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")
                End If

                'Me.txtMontoBaseCarga.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(2)), 2), "####0.00")1
                'Me.txtPrecioPesoCarga.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(3)), 2), "####0.00")2
                'Me.txtPrecioVolumenCarga.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(4)), 2), "####0.00")3
                'Me.txtMontoBaseEncomienda.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(5)), 2), "####0.00")4
                'Me.txtPrecioPesoEncomienda.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(6)), 2), "####0.00")5
                'Me.txtPrecioVolumenEncomienda.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(7)), 2), "####0.00")6
                'Me.txtPrecioPostalBase.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(8)), 2), "####0.00")7
                'Me.txtPrecioPostalPeso.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(9)), 2), "####0.00")8
                'Me.txtPrecioPostalVolumen.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(10)), 2), "####0.00")9
                'Me.txtMontoBaseGiro.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(11)), 2), "####0.00")10
                'Me.txtPorctNormal.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(12)), 2), "####0.00")11
                'Me.txtPorctTelefono.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(13)), 2), "####0.00")12
                'Me.txt_cg_sobre.Text = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(19)), 2), "####0.00")13

                For i As Integer = 0 To Me.dgvCondicional.RowCount - 1 Step 2
                    dgvCondicional.Rows(i).Cells(3).Value = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(3)), 2), "####0.00")
                Next
                For i As Integer = 1 To Me.dgvCondicional.RowCount - 1 Step 2
                    dgvCondicional.Rows(i).Cells(3).Value = Format(Math.Round(Convert.ToDouble(dtTarifasPublicas.Rows(0)(4)), 2), "####0.00")
                Next
            Else
            End If
           

        Catch Qex As Exception
            'MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New Exception(Qex.Message)
        End Try
    End Sub

    Private Sub GrabaArticulos()

        'Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_LIMPIA_ARTICULOS", 4, Me.txtCodigoCLiente.Text, 2}
        'Dim a As ADODB.Recordset
        'a = VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
        Try
            Dim obj As New dtoTARIFACLIENTES
            obj.LIMPIA_ARTICULOS(Me.txtCodigoCLiente.Text)

            For i As Integer = 0 To Me.dgvArticulo.RowCount - 1
                If Me.dgvArticulo.Rows(i).Cells(4).Value <> 0 Then
                    Dim MyArticulos As New dtoARTICULOS_CLIENTE
                    With MyArticulos
                        .Control = 1 'vAccionRegistro
                        .CodigoCliente = Me.txtCodigoCLiente.Text
                        .Origen = Me.cmbOrigen.SelectedValue
                        .Destino = Me.cmbDestino.SelectedValue
                        .IDArticulosCliente = 1 'Momentaneamente
                        '.Articulo = Me.dgvArticulo.Rows(i).Cells(1).Value 'Guarda El Nombre del Articulo
                        .Articulo = Me.dgvArticulo.Rows(i).Cells(0).Value
                        .PrecioFinal = Me.dgvArticulo.Rows(i).Cells(4).Value
                    End With

                    'Dim respArticulos As ADODB.Recordset
                    'respArticulos = MyArticulos.GrabaArticulos

                    MyArticulos.IDTARIFA_CARGA_CLIENTE = Me.txtID.Text

                    MyArticulos.CENTRO_COSTO = Me.cmbSubCuenta.SelectedValue
                    'datahelper
                    'respArticulos = MyArticulos.GrabaArticulos_CC
                    Dim respArticulos As DataTable = MyArticulos.GrabaArticulos_CC

                    If respArticulos.Rows.Count = 1 Then 'Se realizo Correctamente.
                        'MessageBox.Show(respArticulos.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf respArticulos.Rows.Count = 2 And Len(Trim(respArticulos.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                        MessageBox.Show("Descripción: " & respArticulos.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respArticulos.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    'If respArticulos.Fields.Count = 1 Then 'Se real+izo Correctamente.
                    'ElseIf respArticulos.Fields.Count = 2 And Len(Trim(respArticulos.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                    'MessageBox.Show("Descripción: " & respArticulos.Fields(1).Value, "ORACLE -> Error: " & respArticulos.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End If
                End If
            Next
        Catch Qex As Exception
            'MessageBox.Show(Qex.Message, "Seguridad del Sustema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New Exception(Qex.Message)
        End Try

    End Sub

#Region "tarifa masiva"
    Private Sub btn_tarifa_masiva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tarifa_masiva.Click
        Dim obj_cliente_tarifa_masiva As New frmClientesTarifasMasivas
        Try
            If ls_idpersona = "" Or IsDBNull(ls_idpersona) = True Then
                MsgBox("No se ha seleccionado ningún cliente, para actualizar el tarifario masivo", MsgBoxStyle.Information, "Sistema Tarifa cliente")
                Exit Sub
            End If
            '
            obj_cliente_tarifa_masiva.pl_tipo_tarifa = 1 'Generica
            obj_cliente_tarifa_masiva.ps_idpersona = ls_idpersona
            obj_cliente_tarifa_masiva.ps_razon_social = ls_razon_social
            'obj_cliente_tarifa_masiva.ps_sub_cuenta = "Generica"
            'obj_cliente_tarifa_masiva.ps_idsub_cuenta = "null"            
            '
            Acceso.Asignar(obj_cliente_tarifa_masiva, G_Fila)
            If Acceso.TieneAcceso(1, G_Fila) Then
                obj_cliente_tarifa_masiva.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            'obj_cliente_tarifa_masiva.ShowDialog()

            If obj_cliente_tarifa_masiva.pb_cancelar = False Then
                dvTarifasCliente = Funciones.CargarTarifaCliente(ls_codigo_cliente, dgvTarifasCliente)
            End If
            obj_cliente_tarifa_masiva = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
#Region "Recupera tarifa pública]"
    Private Sub cmbOrigen_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrigen.Leave
        Try
            '            get_tarifa_publica(cmbOrigen.SelectedValue, cmbDestino.SelectedValue)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cmbDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDestino.SelectedIndexChanged
        Try
            'get_tarifa_publica(cmbOrigen.SelectedValue, cmbDestino.SelectedValue)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cmbDestino_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDestino.SelectedValueChanged
        Try
            If b_lee = True Then
                get_tarifa_publica(cmbOrigen.SelectedValue, cmbDestino.SelectedValue)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    'Recuperando la tarifa pública 
    Sub get_tarifa_publica(ByVal al_idunidad_agencia As Long, ByVal al_idunidad_agencia_destino As Long)
        Dim objrecupera_tarifa_x_ruta As New ClsLbTepsa.dtoTARIFAS_CARGA_CLIENTE
        Try
            '
            objrecupera_tarifa_x_ruta.IDUNIDAD_AGENCIA = al_idunidad_agencia
            objrecupera_tarifa_x_ruta.IDUNIDAD_AGENCIA_DESTINO = al_idunidad_agencia_destino
            '
            'datahelper

            'objrecupera_tarifa_x_ruta.get_recupera_tarifa_x_ruta(cnn)
            objrecupera_tarifa_x_ruta.get_recupera_tarifa_x_ruta()
            Me.txtMontoBaseCarga.Text = CType(objrecupera_tarifa_x_ruta.CG_MONTO_BASE, String)
            Me.txtMontoBaseCarga.Text = CType(objrecupera_tarifa_x_ruta.CG_MONTO_BASE, String)
            Me.txtMontoBaseCarga.Text = CType(objrecupera_tarifa_x_ruta.CG_MONTO_BASE, String)
            Me.txtPrecioPesoCarga.Text = CType(objrecupera_tarifa_x_ruta.CG_X_PESO, String)
            Me.txtPrecioVolumenCarga.Text = CType(objrecupera_tarifa_x_ruta.CG_X_VOLUMEN, String)
            Me.txt_cg_sobre.Text = CType(objrecupera_tarifa_x_ruta.CG_X_SOBRE, String)
            '
            'objrecupera_tarifa_x_ruta.CG_X_SOBRE
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region

    'Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged
    '    If bIngreso Then
    '        Acceso.VerificaCambio(sender, e)
    '    End If
    'End Sub

End Class
