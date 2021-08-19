'Imports System.Data
'Imports System.Data.OleDb
'Imports AccesoDatos
Public Class FrmCtaCte
    Public hnd As Long
    Dim vAccionRegistro As Integer

    Dim dvListaClientes As DataView
    'Dim rstCodicionPago As ADODB.Recordset
    Dim dtCondicionPago As New DataTable
    Dim dvCondicionPago As New DataView

    Dim dtRutas As New DataTable
    Dim dtDocumentos As New DataTable
    Dim dvRutas As New DataView
    Dim dvDocumentos As New DataView

    '''''''''Para ser usado solo cuado hagamos una modificacion o Aprobacion
    Dim dtDatosSolicitud As New DataTable
    'Dim dtConsideracionePago As New DataTable
    Dim dtProveedoresSolicitud As New DataTable
    Dim dtClientesSolicitud As New DataTable
    Dim dtDestinosViaje As New DataTable
    Dim dtReferenciaBancaria As New DataTable
    Dim dtDocumentosRecibidos As New DataTable

    Dim vAccionAprobacion As Integer
    Dim vNroPagina As Integer = 1
    Dim var_idpersona As Integer
    Dim bIngreso As Boolean

    Private Sub FrmCtaCte_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmCtaCte_ClickTabPage3() Handles Me.ClickTabPage3
        If vAccionAprobacion = 1 Then
            SelectMenu(2)
            txtLineaSolicitadaClon.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            cmbEstadoSolicitud.SelectedIndex = 3
        End If

        If vAccionRegistro = 1 Then
            SelectMenu(2)
            txtLineaSolicitadaClon.Text = txtCreditoSolicitado.Text
            txtLineaSolicitadaClon.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            txtCreditoAsignado.Text = txtCreditoSolicitado.Text
            cmbEstadoSolicitud.SelectedIndex = 0
        End If
        If vAccionRegistro = 2 Then
            SelectMenu(2)
            txtLineaSolicitadaClon.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            cmbEstadoSolicitud.SelectedIndex = 0
            gruCtaCteFinal.Enabled = False
        End If

    End Sub

    Private Sub FrmCtaCte_ClickTabPage4() Handles Me.ClickTabPage4
        SelectMenu(3)
    End Sub

    Private Sub FrmCtaCte_ClickTabPage5() Handles Me.ClickTabPage5
        SelectMenu(4)
    End Sub

    Private Sub FrmCtaCte_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmCtaCte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ShadowLabel1.Text = "Línea de Crédito"
            MenuTab.Items(0).Text = "LISTA CLIENTES"
            MenuTab.Items(1).Text = "SOLICITUD DE CREDITO"
            MenuTab.Items(2).Text = "CONSIDERACIONES"
            MenuTab.Items(3).Text = "ESTADO LINEA DE CREDITO"
            MenuTab.Items(4).Text = ""
            HabilitarMenu(MenuTab)

            MenuTab.Items(0).Enabled = True
            MenuTab.Items(1).Enabled = False
            MenuTab.Items(2).Enabled = False
            MenuTab.Items(3).Enabled = False
            MenuTab.Items(4).Enabled = False
            '
            btnultimo.Enabled = False
            btnprimero.Enabled = False
            ' Pasando las variables globales a funciones del formulario - Tepsa 
            MyUsuario = dtoUSUARIOS.IdLogin
            MyRol = dtoUSUARIOS.IdRol
            MyIP = dtoUSUARIOS.IP
            '

            'If MyRol = 15 Then   ' Tepsa 
            'If fnValidar_Rol("15") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 1) Then
                Me.AprobaciónToolStripMenuItem.Enabled = True
                Me.chkSoloPendientes.Enabled = True
                Me.chkSoloPendientes.Checked = True
            Else 'If fnValidar_Rol("15") = False Then
                ' ElseIf MyRol <> 15 Then   tepsa
                Me.AprobaciónToolStripMenuItem.Enabled = False
                Me.chkSoloPendientes.Enabled = False
                Me.chkSoloPendientes.Checked = False
            End If

            Me.txtTOTALFINAL.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            Me.txtLINEAFINAL.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            Me.txtSOBREGIROLINEAFINAL.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")

            Me.txtNroSolicitud.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            Me.txtFuncionarioActual.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            Me.txtCodigoCliente.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            Me.txtNombreCliente.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            Me.txtDireccionLegal.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            Me.txtRepresentanteLegal.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            Me.txtGiroNegocio.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")

            Me.rdbProveedores.Checked = True
            Me.rdbSobregiroMonto.Checked = True
            Me.rdbSemanal.Checked = True
            vAccionRegistro = 0
            vAccionAprobacion = 0
            'If MyRol <> 11 Then '(32) Supervisor de funcionario de negocios (15) Credito y cobranzas
            'bloque
            If Acceso.SiRol(G_Rol, Me, 2) Then
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
            'Modificado 25/06/2007 - Omendoza
            'Call Funciones.LlenaTreeFuncionarios(MyTreeView)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''' Pa Activar los controles exclusivos de Credito y Cobranza ''''
            'If MyRol = 15 Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 3) Then
                gruCtaCteFinal.Enabled = True
            Else 'If MyRol <> 15 Then
                gruCtaCteFinal.Enabled = False
            End If

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FrmCtaCte_MenuCancelar() Handles Me.MenuCancelar
        dtCondicionPago.Clear()

        vAccionRegistro = 0
        vAccionAprobacion = 0
        dtProveedoresSolicitud.Clear()
        dtClientesSolicitud.Clear()
        dtDestinosViaje.Clear()
        dtReferenciaBancaria.Clear()
        dtDocumentosRecibidos.Clear()
        ActivaCamposCtaCte(Me.txtCreditoSolicitado, Me.txtNroSolicitud, Me.txtTelefonoDireccionLegal, Me.txtFaxDireccionLegal, Me.txtEmailRepLegal, Me.txtTelefonoRepLegal, Me.txtMovilRepLegal, Me.txtGerenteFinanciero, Me.txtEmailGerFinanciero, Me.txtTelefonoGerFinanciero, Me.txtMovilGerFinanciero, Me.txtEncargadoPagos, Me.txtEmailEncPagos, Me.txtTelefonoEncPagos, Me.txtMovilEncPagos, Me.txtPersonaContacto, Me.txtEmailPersonaContacto, Me.txtTelefonoPersonaContacto, Me.txtMovilPersonaContacto)

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

    Private Sub FrmCtaCte_MenuEditar() Handles Me.MenuEditar

        Try
            'Tepsa 
            MenuTab.Items(4).Enabled = False
            MenuTab.Items(4).Visible = False
            '
            btnultimo.Enabled = False
            btnprimero.Enabled = False
            '
            Dim drvr As DataGridViewRow = DataGridLista.CurrentRow
            'datahelper
            'If Not drvr Is Nothing Then
            '    'Dim rstClienteConfig As ADODB.Recordset = Funciones.BuscaClienteConfig(drvr.Cells("CODIGO").Value.ToString)
            '    Dim dtClienteConfig As New DataTable
            '    Dim MyAdapter As New OleDbDataAdapter
            '    MyAdapter.Fill(dtClienteConfig, rstClienteConfig)
            '    If dtClienteConfig.Rows.Count > 0 Then
            '        If dtClienteConfig.Rows(0)(0) = 0 Then
            '            vAccionRegistro = 2

            '            Call EdicionSolicitud()

            '            DesactivaCamposCtaCte(Me.txtNroSolicitud)
            '        Else
            '            MessageBox.Show("No puede Cambiar Datos porque la Solicitud Esta Aprobada.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        End If
            '    End If
            If Not drvr Is Nothing Then
                'Dim rstClienteConfig As ADODB.Recordset = Funciones.BuscaClienteConfig(drvr.Cells("CODIGO").Value.ToString)
                Dim dtClienteConfig As DataTable
                dtClienteConfig = Funciones.BuscaClienteConfig(drvr.Cells("CODIGO").Value.ToString)
                If dtClienteConfig.Rows.Count > 0 Then
                    If dtClienteConfig.Rows(0)(0) = 0 Then
                        vAccionRegistro = 2

                        Call EdicionSolicitud()

                        DesactivaCamposCtaCte(Me.txtNroSolicitud)
                    Else
                        MessageBox.Show("No puede Cambiar Datos porque la Solicitud Esta Aprobada.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else
                MessageBox.Show("Seleccione a un Cliente.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmCtaCte_MenuGrabar() Handles Me.MenuGrabar
        'Dim MyObligatorios As Object() = {Me.txtCreditoSolicitado, Me.txtTelefonoDireccionLegal, Me.txtFaxDireccionLegal, Me.txtEmailRepLegal, Me.txtTelefonoRepLegal, Me.txtMovilRepLegal, Me.txtGerenteFinanciero, Me.txtEmailGerFinanciero, Me.txtTelefonoGerFinanciero, Me.txtMovilGerFinanciero, Me.txtEncargadoPagos, Me.txtEmailEncPagos, Me.txtTelefonoEncPagos, Me.txtMovilEncPagos, Me.txtPersonaContacto, Me.txtEmailPersonaContacto, Me.txtTelefonoPersonaContacto, Me.txtMovilPersonaContacto}
        '''
        Dim MyObligatorios As Object() = {Me.txtCreditoSolicitado, Me.txtPersonaContacto, Me.txtTelefonoPersonaContacto, Me.txtMovilPersonaContacto, Me.txtEncargadoPagos, Me.txtMovilEncPagos, Me.txtTelefonoEncPagos}
        If Funciones.Validaciones(MyObligatorios) = 0 Then
            Call GrabaSolicitud()

            ActivaCamposCtaCte(Me.txtCreditoSolicitado, Me.txtNroSolicitud, Me.txtTelefonoDireccionLegal, Me.txtFaxDireccionLegal, Me.txtEmailRepLegal, Me.txtTelefonoRepLegal, Me.txtMovilRepLegal, Me.txtGerenteFinanciero, Me.txtEmailGerFinanciero, Me.txtTelefonoGerFinanciero, Me.txtMovilGerFinanciero, Me.txtEncargadoPagos, Me.txtEmailEncPagos, Me.txtTelefonoEncPagos, Me.txtMovilEncPagos, Me.txtPersonaContacto, Me.txtEmailPersonaContacto, Me.txtTelefonoPersonaContacto, Me.txtMovilPersonaContacto)
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
        End If
    End Sub

    Private Sub FrmCtaCte_MenuImprimir() Handles Me.MenuImprimir
        Dim a As New ClsPrint
        a.Titulo = "CLIENTES CARGA"
        a.DGV = Me.DataGridLista
        Dim MyReport As New Reportes
        'MyReport.MdiParent = FrmContenedor  ' Tepsa 
        MyReport.MdiParent = Principal
        MyReport.pd.Document = a
        MyReport.pd.Dock = DockStyle.Fill
        MyReport.WindowState = FormWindowState.Maximized
        '
        'FrmContenedor.SplitContainer1.Panel2.Controls.Add(MyReport) ' Tepsa 
        'Principal.Panel1.Controls.Add(MyReport)
        '
        MyReport.Show()
        MyReport.BringToFront()
    End Sub
    Private Sub FrmCtaCte_MenuNuevo() Handles Me.MenuNuevo
        Try
            'If MyRol = 15 Then 'Si se trata de alguien de Creditos
            'bloque
            If Acceso.SiRol(G_Rol, Me, 4) Then
                Me.gruCtaCteFinal.Enabled = True
            Else 'If MyRol <> 15 Then 'Para cualquiera que no sea de Creditos
                Me.gruCtaCteFinal.Enabled = False
            End If

            If DataGridLista.RowCount > 0 Then
                Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
                If Not dgvr Is Nothing Then
                    If Len(Trim(CType(dgvr.Cells("FUNCIONARIO").Value, String))) <> 0 Then
                        dtCondicionPago.Clear()
                        Call CreaGrillaProveedores()
                        Call CreaGrillaClientes()
                        Me.dgv4.Text = "Ninguno..."
                        Call CreaGrillaBancos()

                        dtpDias.SelectedIndex = 0

                        'datahelper
                        'Carga de Data Generica
                        'Dim rstRutas As ADODB.Recordset = Funciones.CargaRecorsetCtaCte(99999)
                        'Dim rstDocumentos As ADODB.Recordset = rstRutas.NextRecordset
                        'Dim daCreacion As New OleDbDataAdapter
                        'dtRutas.Clear()
                        'dtDocumentos.Clear()
                        'daCreacion.Fill(dtRutas, rstRutas)
                        'daCreacion.Fill(dtDocumentos, rstDocumentos)
                        Dim rstrutas As DataSet = Funciones.CargaRecorsetCtaCte(99999)
                        dtRutas = rstrutas.Tables(0)
                        dtDocumentos = rstrutas.Tables(1)

                        Call GeneraGrillaRutas()
                        Call GeneraGrillaDocumentos()


                        vAccionRegistro = 1

                        Me.txtNroSolicitud.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
                        Me.txtNroSolicitud.ReadOnly = True

                        txtNroSolicitud.Text = 0 'CType(dgvr.Cells("CODIGO").Value, String)
                        txtFuncionarioActual.Text = CType(dgvr.Cells("FUNCIONARIO").Value, String)
                        txtCodigoCliente.Text = CType(dgvr.Cells("CODIGO").Value, String)
                        txtNombreCliente.Text = CType(dgvr.Cells("RAZONSOCIAL").Value, String)
                        txtRepresentanteLegal.Text = CType(IIf(IsDBNull(dgvr.Cells("REPRESENTANTE_LEGAL").Value), "", dgvr.Cells("REPRESENTANTE_LEGAL").Value), String)

                        'datahelper
                        'Dim rstDirecciones As ADODB.Recordset
                        'Dim rstRubro As ADODB.Recordset
                        'Dim da As New OleDbDataAdapter
                        'Dim dtDirecciones As New DataTable
                        'Dim dtRubro As New DataTable
                        'rstDirecciones = Funciones.LeerDireccionRubro(txtCodigoCliente.Text)
                        'rstRubro = rstDirecciones.NextRecordset
                        'rstCodicionPago = rstDirecciones.NextRecordset
                        'dtDirecciones.Clear()
                        'dtRubro.Clear()
                        'da.Fill(dtDirecciones, rstDirecciones)
                        'da.Fill(dtRubro, rstRubro)
                        'da.Fill(dtCondicionPago, rstCodicionPago)
                        Dim ds As DataSet = Funciones.LeerDireccionRubro(txtCodigoCliente.Text)
                        Dim dtDirecciones As DataTable = ds.Tables(0)
                        Dim dtRubro As DataTable = ds.Tables(1)
                        dtCondicionPago = ds.Tables(2)

                        dvCondicionPago = Funciones.CargarCombo(Me.cmbCondicionPago, dtCondicionPago, "CONDICION", "IDCONDICION_PLAZO", 1)

                        'TODO 1: Establecer condicoonales cuando las direcciones esten Vacias.
                        If dtDirecciones.Rows.Count = 0 Then
                            txtDireccionLegal.Text = ""
                            txtGiroNegocio.Text = ""
                        ElseIf dtDirecciones.Rows.Count = 1 Then
                            txtDireccionLegal.Text = dtDirecciones.Rows(0)(0)
                            txtGiroNegocio.Text = dtRubro.Rows(0)(0)
                        Else
                            txtDireccionLegal.Text = ""
                            txtGiroNegocio.Text = ""
                        End If
                        If txtDireccionLegal.Text = "" Then
                            MessageBox.Show("El cliente no tiene registrado dirección legal", "Solicitud de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        MenuTab.Items(0).Enabled = False
                        MenuTab.Items(1).Enabled = True
                        MenuTab.Items(2).Enabled = True
                        MenuTab.Items(3).Enabled = True
                        MenuTab.Items(4).Enabled = True
                        SelectMenu(1)

                        SplitContainer2.Panel1Collapsed = True
                        NuevoToolStripMenuItem.Enabled = False
                        EdicionToolStripMenuItem.Enabled = False
                        CancelarToolStripmenuItem.Enabled = True
                        CancelarToolStripmenuItem.Visible = True
                        GrabarToolStripMenuItem.Enabled = True
                        EliminarToolStripMenuItem.Enabled = False
                        ExportarToolStripMenuItem.Enabled = False
                        ImprimirToolStripMenuItem.Enabled = False
                    Else
                        MessageBox.Show("El Cliente no posee un Funcionario, Posiblemente sea un Cliente a Contado, asigne primero un funcionario.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Seleccione a un Cliente de la Grilla.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Seleccione un o mas Funcionarios de la Lista y Cargue los Datos del Cliente", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbProveedores.CheckedChanged
        dgv1.Visible = True
        dgv2.Visible = False
        dgv3.Visible = False
        dgv4.Visible = False
        dgv5.Visible = False
        dgv6.Visible = False

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbBancos.CheckedChanged
        dgv1.Visible = False
        dgv2.Visible = True
        dgv3.Visible = False
        dgv4.Visible = False
        dgv5.Visible = False
        dgv6.Visible = False

    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDocumentos.CheckedChanged
        dgv1.Visible = False
        dgv2.Visible = False
        dgv3.Visible = True
        dgv4.Visible = False
        dgv5.Visible = False
        dgv6.Visible = False

    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbObservaciones.CheckedChanged
        dgv1.Visible = False
        dgv2.Visible = False
        dgv3.Visible = False
        dgv4.Visible = True
        dgv5.Visible = False
        dgv6.Visible = False

    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbClientes.CheckedChanged
        dgv1.Visible = False
        dgv2.Visible = False
        dgv3.Visible = False
        dgv4.Visible = False
        dgv5.Visible = True
        dgv6.Visible = False
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDestinosFrecuentes.CheckedChanged
        dgv1.Visible = False
        dgv2.Visible = False
        dgv3.Visible = False
        dgv4.Visible = False
        dgv5.Visible = False
        dgv6.Visible = True
    End Sub

    Private Sub rdbSemanal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSemanal.CheckedChanged
        If sender.checked = True Then
            For Each MyObjects As Object In Me.gruPagos.Controls
                If TypeOf MyObjects Is DateTimePicker Then
                    If CType(MyObjects, DateTimePicker).Name <> "dtpDias" And CType(MyObjects, DateTimePicker).Name <> "dtpHoraInicio" And CType(MyObjects, DateTimePicker).Name <> "dtpHoraFin" Then
                        CType(MyObjects, DateTimePicker).Enabled = False
                    End If
                End If
                If TypeOf MyObjects Is CheckBox Then
                    CType(MyObjects, CheckBox).Enabled = False
                    CType(MyObjects, CheckBox).Checked = False
                End If
            Next
        End If
    End Sub

    Private Sub rdbMensual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMensual.CheckedChanged
        If sender.checked = True Then
            For Each MyObjects As Object In Me.gruPagos.Controls
                If TypeOf MyObjects Is DateTimePicker Then
                    If CType(MyObjects, DateTimePicker).Name <> "dtpDias" And CType(MyObjects, DateTimePicker).Name <> "dtpHoraInicio" And CType(MyObjects, DateTimePicker).Name <> "dtpHoraFin" Then
                        If CType(MyObjects, DateTimePicker).Name = "dtpA" Then
                            CType(MyObjects, DateTimePicker).Enabled = True
                        End If
                    End If
                End If
                If TypeOf MyObjects Is CheckBox Then
                    If CType(MyObjects, CheckBox).Name = "chkYA" Then
                        CType(MyObjects, CheckBox).Enabled = True
                    End If
                End If
            Next
        End If
    End Sub


    Private Sub chkYA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkYA.CheckedChanged
        If sender.checked = True Then
            Me.dtpB.Enabled = True
            Me.chkYB.Enabled = True
        Else
            Me.dtpB.Enabled = False
            Me.chkYB.Enabled = False
            Me.dtpC.Enabled = False
            Me.chkYC.Enabled = False
            Me.dtpD.Enabled = False

            Me.chkYB.Checked = False
            Me.chkYC.Checked = False

        End If
    End Sub

    Private Sub chkYB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkYB.CheckedChanged
        If sender.checked = True Then
            Me.dtpC.Enabled = True
            Me.chkYC.Enabled = True
        Else
            Me.dtpC.Enabled = False
            Me.chkYC.Enabled = False
            Me.dtpD.Enabled = False

            Me.chkYC.Checked = False

        End If
    End Sub

    Private Sub chkYC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkYC.CheckedChanged
        If sender.checked = True Then
            Me.dtpD.Enabled = True
        Else
            Me.dtpD.Enabled = False
        End If
    End Sub

    Private Sub rdbSobregiroMonto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSobregiroMonto.CheckedChanged
        If sender.checked = True Then
            txtSobregiroPorct.Enabled = False
            txtSobregiroPorct.Text = ""
            txtSobregiroPorct.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            txtSobregiroFinal.Focus()
        End If
    End Sub

    Private Sub rdbSobregiroPorct_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSobregiroPorct.CheckedChanged
        If sender.checked = True Then
            txtSobregiroPorct.Enabled = True
            txtSobregiroPorct.BackColor = Color.White
            txtSobregiroFinal.Text = ""
            txtSobregiroPorct.Focus()
        End If
    End Sub

    Private Sub txtSobregiroPorct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSobregiroPorct.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCreditoAsignado.Text)) <> 0 Then
                txtSobregiroFinal.Text = CType((CType(txtCreditoAsignado.Text, Decimal) * ((1 + CType(txtSobregiroPorct.Text, Decimal) / 100)) - CType(txtCreditoAsignado.Text, Decimal)), String)
            Else
                txtSobregiroFinal.Text = ""
                txtSobregiroPorct.Text = ""
            End If
        End If
    End Sub

    Private Sub rdbAprobado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAprobado.CheckedChanged
        If Len(Trim(txtCreditoAsignado.Text)) <> 0 And Len(Trim(txtSobregiroFinal.Text)) <> 0 Then
            If sender.checked = True Then
                txtTOTALFINAL.Text = CType(CType(txtCreditoAsignado.Text, Decimal) + CType(txtSobregiroFinal.Text, Decimal), String)
                txtLINEAFINAL.Text = txtCreditoAsignado.Text
                txtSOBREGIROLINEAFINAL.Text = txtSobregiroFinal.Text
                txtsaldoactual.Text = txtTOTALFINAL.Text  'Tepsa 

                '''''''''''''''Proceso de Guardado'''''''''''''''''''''
                Dim resp As DialogResult = MessageBox.Show("¿Esta seguro de Aprobar esta Linea de Credito?" & vbCrLf & " " & vbCrLf & "Linea Aprobado Final : " & txtLINEAFINAL.Text & vbCrLf & "Sobre Giro Final : " & txtSOBREGIROLINEAFINAL.Text & vbCrLf & "Monto Final : " & txtTOTALFINAL.Text, "Seguridad del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                If resp = Windows.Forms.DialogResult.Yes Then
                    ' Actualiza los valores de la solicitud - Tepsa 
                    vAccionRegistro = 2
                    Call GrabaSolicitud()
                    '
                    Call AprobadoDenegado() ' Omendoza 
                    '
                    dtProveedoresSolicitud.Clear()
                    dtClientesSolicitud.Clear()
                    dtDestinosViaje.Clear()
                    dgv4.Text = "Ninguno..."
                    dtReferenciaBancaria.Clear()
                    dtDocumentosRecibidos.Clear()
                    ActivaCamposCtaCte(Me.txtCreditoSolicitado, Me.txtNroSolicitud, Me.txtTelefonoDireccionLegal, Me.txtFaxDireccionLegal, Me.txtEmailRepLegal, Me.txtTelefonoRepLegal, Me.txtMovilRepLegal, Me.txtGerenteFinanciero, Me.txtEmailGerFinanciero, Me.txtTelefonoGerFinanciero, Me.txtMovilGerFinanciero, Me.txtEncargadoPagos, Me.txtEmailEncPagos, Me.txtTelefonoEncPagos, Me.txtMovilEncPagos, Me.txtPersonaContacto, Me.txtEmailPersonaContacto, Me.txtTelefonoPersonaContacto, Me.txtMovilPersonaContacto)
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

                    Me.MyTreeView.Nodes(0).Checked = False
                    Me.DataGridLista.Columns.Clear()

                End If
            Else
                txtTOTALFINAL.Text = ""
                txtLINEAFINAL.Text = ""
                txtSOBREGIROLINEAFINAL.Text = ""
            End If
        Else
            sender.checked = False
        End If
    End Sub

    Private Sub txtCreditoAsignado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCreditoAsignado.TextChanged ', txtSobregiroFinal.TextChanged
        Me.rdbAprobado.Checked = False
        Me.rdbDenegado.Checked = False
        txtTOTALFINAL.Text = ""
        txtLINEAFINAL.Text = ""
        txtSOBREGIROLINEAFINAL.Text = ""
        txtSobregiroFinal.Text = ""
        txtSobregiroPorct.Text = ""
    End Sub

    Private Sub GeneraGrillaRutas()
        dvRutas = dtRutas.DefaultView
        dgv6.Columns.Clear()
        With dgv6
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvRutas
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            '.RowHeadersWidth = 30
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .HeaderText = "IDRUTAS"
            .Name = "IDRUTAS"
            .DataPropertyName = "IDRUTAS"
            .Width = 62
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .Name = "NOMBRE_RUTA"
            .DataPropertyName = "NOMBRE_RUTA"
            .ReadOnly = True
            .ToolTipText = "Nombre de la Ruta: Orige-Destino"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col2 As New DataGridViewCheckBoxColumn
        With col2
            .HeaderText = "SELECCION"
            .Name = "SELECCION"
            .DataPropertyName = "SELECCION"
            .Width = 62
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim Col4 As New DataGridViewTextBoxColumn
        With Col4
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        dgv6.Columns.AddRange(col0, col1, col2, col3, Col4)
        dgv6.Columns(0).Visible = False
        dgv6.Columns(3).Visible = False
        dgv6.Columns(4).Visible = False

    End Sub

    Private Sub GeneraGrillaDocumentos()
        dvDocumentos = dtDocumentos.DefaultView
        dgv3.Columns.Clear()
        With dgv3
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvDocumentos
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            '.RowHeadersWidth = 30
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .HeaderText = "IDDOCUMENTO_CTACTE"
            .Name = "IDDOCUMENTO_CTACTE"
            .DataPropertyName = "IDDOCUMENTO_CTACTE"
            .Width = 62
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .Name = "DOCUMENTOS"
            .DataPropertyName = "DOCUMENTOS"
            .ReadOnly = True
            .ToolTipText = "Documento a Adjuntar por el Cliente."
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col2 As New DataGridViewCheckBoxColumn
        With col2
            .HeaderText = "SELECCION"
            .Name = "SELECCION"
            .DataPropertyName = "SELECCION"
            .Width = 62
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        dgv3.Columns.AddRange(col0, col1, col2)
        dgv3.Columns(0).Visible = False

    End Sub

    Private Sub FormatoGrilla(ByVal MyGrilla As DataGridView)
        With MyGrilla
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            '.AllowUserToOrderColumns = True
            '.AllowUserToDeleteRows = True
            '.AllowUserToAddRows = True
            '.AutoGenerateColumns = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersVisible = True
            .RowHeadersWidth = 20
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Private Sub dgv6_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv6.DoubleClick
        gruCtaCteFinal.Visible = False
        gruBusqueda.Visible = True
        gruBusqueda.BringToFront()
        txtBusqueda.Focus()
    End Sub

    Private Sub gruBusqueda_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gruBusqueda.DoubleClick
        gruCtaCteFinal.Visible = True
        gruBusqueda.Visible = False
        gruCtaCteFinal.BringToFront()
        dvRutas.RowFilter = ""
    End Sub

    Private Sub txtBusqueda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBusqueda.GotFocus
        Me.rdbTodos.Checked = True
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        dvRutas.RowFilter = "NOMBRE_RUTA LIKE '" & txtBusqueda.Text & "%'"
    End Sub

    Private Sub rdbSeleccionados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSeleccionados.CheckedChanged
        If sender.checked = True Then
            dvRutas.RowFilter = "SELECCION = 1"
        ElseIf rdbNoSeleccionados.Checked = True Then
            dvRutas.RowFilter = "SELECCION = 0"
        Else
            dvRutas.RowFilter = ""
        End If
    End Sub


    Private Sub txtSobregiroFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSobregiroFinal.TextChanged
        'Me.rdbAprobado.Checked = False
        'Me.rdbDenegado.Checked = False
        'txtTOTALFINAL.Text = ""
        'txtLINEAFINAL.Text = ""
        'txtSOBREGIROLINEAFINAL.Text = ""
        'txtSobregiroFinal.Text = ""
        'txtSobregiroPorct.Text = ""
    End Sub
    Private Sub btnCargarClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarClientes.Click
        Try
            If MyTreeView.Nodes(0).Checked = True Then
                'MessageBox.Show("Cargar Todos")
                DataGridLista.Columns.Clear()

                If MyRol <> 15 Then '= 11 Then 'Funcionario --> Muestra todos sus Clientes
                    dvListaClientes = Funciones.CargarGrillaClientes(Me.DataGridLista)
                    Dim FiltroLista As String = "IDTIPO_PERSONA ='" & 1 & "'"
                    dvListaClientes.RowFilter = FiltroLista
                    DataGridLista.Columns(4).Visible = True
                    DataGridLista.Columns(5).Visible = False
                    DataGridLista.Columns(40).Visible = False
                ElseIf MyRol = 15 Then 'Creditos --> Muestra todos los clientes con Solicitud Pendiente
                    dvListaClientes = Funciones.CargarGrillaClientesSolicitudPendiente(Me.DataGridLista)
                    chkSoloPendientes.Checked = True
                    Dim FiltroLista As String = "IDTIPO_PERSONA ='" & 1 & "' and APROBADO = 0"
                    dvListaClientes.RowFilter = FiltroLista
                    DataGridLista.Columns(4).Visible = True
                    DataGridLista.Columns(5).Visible = False
                    DataGridLista.Columns(40).Visible = False
                End If

                'Dim FiltroLista As String = "IDTIPO_PERSONA ='" & 1 & "' and APROBADO = 0"
                'dvListaClientes.RowFilter = FiltroLista
                'DataGridLista.Columns(4).Visible = True
                'DataGridLista.Columns(5).Visible = False
                'DataGridLista.Columns(40).Visible = False

            ElseIf MyTreeView.Nodes(0).Checked = False Then
                'MessageBox.Show("Cargar por Funcionario")
                For i As Integer = 0 To MyTreeView.Nodes(0).Nodes.Count - 1
                    If MyTreeView.Nodes(0).Nodes(i).Checked = True Then
                        DataGridLista.Columns.Clear()

                        If MyRol <> 15 Then '= 11 Then 'Funcionario --> Muestra todos sus Clientes
                            dvListaClientes = Funciones.CargarGrillaClientes(Me.DataGridLista, MyTreeView.Nodes(0).Nodes(i).Text)
                            Dim FiltroLista As String = "IDTIPO_PERSONA ='" & 1 & "'"
                            dvListaClientes.RowFilter = FiltroLista
                            chkSoloPendientes.Checked = True
                        ElseIf MyRol = 15 Then 'Creditos --> Muestra todos los clientes con Solicitud Pendiente
                            dvListaClientes = Funciones.CargarGrillaClientesSolicitudPendiente(Me.DataGridLista, MyTreeView.Nodes(0).Nodes(i).Text)
                            Dim FiltroLista As String = "IDTIPO_PERSONA ='" & 1 & "' and APROBADO = 0"
                            dvListaClientes.RowFilter = FiltroLista
                            chkSoloPendientes.Checked = True
                        End If

                        DataGridLista.Columns(4).Visible = True
                        DataGridLista.Columns(5).Visible = False
                        DataGridLista.Columns(40).Visible = False
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub RadioButton1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If sender.checked = True Then
            If DataGridLista.Columns.Count > 0 Then
                DataGridLista.Columns(5).Visible = True
                DataGridLista.Columns(4).Visible = True
                Dim FiltroLista As String = ""
                dvListaClientes.RowFilter = FiltroLista
            End If
        End If
    End Sub


    Private Sub txtBusquedaClientes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusquedaClientes.TextChanged
        Try
            If rdbJuridicos.Checked = True Then
                Dim FiltroLista As String = "IDTIPO_PERSONA = 1 and RAZON_SOCIAL LIKE '%" & Me.txtBusquedaClientes.Text & "%'"
                dvListaClientes.RowFilter = FiltroLista
            End If
            If rdbnaturales.Checked = True Then
                Dim FiltroLista As String = "IDTIPO_PERSONA = 2 and NOMNRES_APELLIDOS LIKE '%" & Me.txtBusquedaClientes.Text & "%'"
                dvListaClientes.RowFilter = FiltroLista
            End If
            If rdbTodos.Checked = True Then
                Dim FiltroLista As String = "(IDTIPO_PERSONA = 1 or IDTIPO_PERSONA = 2) and CODIGO_CLIENTE LIKE '%" & Me.txtBusquedaClientes.Text & "%'"
                dvListaClientes.RowFilter = FiltroLista
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub FrmCtaCte_MenuSalir() Handles Me.MenuSalir
        Me.Close()
    End Sub

    Private Sub txtTelefonoDireccionLegal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefonoDireccionLegal.KeyPress, txtFaxDireccionLegal.KeyPress, txtTelefonoRepLegal.KeyPress, txtMovilRepLegal.KeyPress, txtTelefonoGerFinanciero.KeyPress, txtMovilGerFinanciero.KeyPress, txtTelefonoEncPagos.KeyPress, txtMovilEncPagos.KeyPress, txtTelefonoPersonaContacto.KeyPress, txtMovilPersonaContacto.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub GrabaSolicitud()
        Try
            'MessageBox.Show(Me.dtpA.Value.ToString, "Antes de Grabar Campos")
            'MessageBox.Show(Me.dtpB.Value.ToString, "Antes de Grabar Campos")
            'MessageBox.Show(Me.dtpC.Value.ToString, "Antes de Grabar Campos")
            'MessageBox.Show(Me.dtpD.Value.ToString, "Antes de Grabar Campos")
            '--- 
            If Me.txtDireccionLegal.Text = "" Then
                MessageBox.Show("El cliente no tiene registrado dirección legal", "Solicitud de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            '--- 
            Dim MySolicitud As New dtoSOLICITUD_CREDITO
            With MySolicitud
                .Control = vAccionRegistro
                .IDSolicitudCredito = Me.lblIDSolicitudCredito.Text '1 'Momentaneamente
                .CodigoPersona = Me.txtCodigoCliente.Text
                .NombreCliente = Me.txtNombreCliente.Text
                .DireccionLegal = Me.txtDireccionLegal.Text
                .TelefonoDireccion = Me.txtTelefonoDireccionLegal.Text
                .FaxDireccion = Me.txtFaxDireccionLegal.Text
                .RepresentanteLegal = Me.txtRepresentanteLegal.Text
                .EmailRepresentanteLegal = Me.txtEmailRepLegal.Text
                .TelefonoRepresentanteLegal = Me.txtTelefonoRepLegal.Text
                .MovilRepresentanteLegal = Me.txtMovilRepLegal.Text
                .GerenteFinanciero = Me.txtGerenteFinanciero.Text
                .EmailGerenteFinanciero = Me.txtEmailGerFinanciero.Text
                .TelefonoGerenteFinanciero = Me.txtTelefonoGerFinanciero.Text
                .MovilGerenteFinanciero = Me.txtMovilGerFinanciero.Text
                .Gironegocio = Me.txtGiroNegocio.Text
                .EncargadoPagos = Me.txtEncargadoPagos.Text
                .EmailEncargadoPagos = Me.txtEmailEncPagos.Text
                .TelefonoEncargadoPagos = Me.txtTelefonoEncPagos.Text
                .MovilEncargadoPagos = Me.txtMovilEncPagos.Text
                .PersonaContacto = Me.txtPersonaContacto.Text
                .EmailPersonaContacto = Me.txtEmailPersonaContacto.Text
                .TelefonoPersonaContacto = Me.txtTelefonoPersonaContacto.Text
                .MovilPersonaContacto = Me.txtMovilPersonaContacto.Text
                .UsuarioPersonal = MyUsuario
                .RolUusario = MyRol
                .IP = MyIP
                .LineaSolicitada = CType(Me.txtCreditoSolicitado.Text, Double)

                .PeriodoPago = Me.cmbCondicionPago.SelectedValue 'Fact.1 ,2,3...
                .DiasPago = Me.dtpDias.Text
                If rdbSemanal.Checked = True Then
                    .Fecha1 = 0
                    .Fecha2 = 0
                    .Fecha3 = 0
                    .Fecha4 = 0
                ElseIf rdbSemanal.Checked = False Then

                    If dtpA.Enabled = True Then
                        .Fecha1 = CType(Format(CType(Me.dtpA.Value, Date), "dd"), Integer)
                    ElseIf dtpA.Enabled = False Then
                        .Fecha1 = 0
                    End If
                    If dtpB.Enabled = True Then
                        .Fecha2 = CType(Format(CType(Me.dtpB.Value, Date), "dd"), Integer)
                    ElseIf dtpB.Enabled = False Then
                        .Fecha2 = 0
                    End If
                    If dtpC.Enabled = True Then
                        .Fecha3 = CType(Format(CType(Me.dtpC.Value, Date), "dd"), Integer)
                    ElseIf dtpC.Enabled = False Then
                        .Fecha3 = 0
                    End If
                    If dtpD.Enabled = True Then
                        .Fecha4 = CType(Format(CType(Me.dtpD.Value, Date), "dd"), Integer)
                    ElseIf dtpD.Enabled = False Then
                        .Fecha4 = 0
                    End If

                End If
                .HoraPagoIni = Format(CType(Me.dtpHoraInicio.Value, Date), "HH:mm:ss tt").ToString
                .HoraPagoFin = Format(CType(Me.dtpHoraFin.Value, Date), "HH:mm:ss tt").ToString
                .TipoPago = 3 'Momentaneamente hasta poner un combo box Credito Soles y Crdito Dolares.
                .Observaciones = Me.dgv4.Text

            End With

            'datahelper
            'Dim RespSolicitud As ADODB.Recordset
            'RespSolicitud = MySolicitud.GrabaSolicitud
            Dim RespSolicitud As DataTable = MySolicitud.GrabaSolicitud

            If RespSolicitud.Rows.Count = 1 Then 'Se realizo Correctamente.
                MessageBox.Show(RespSolicitud.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call GrabaProvSolicitud()
                Call GrabaClienteSolicitud()
                Call GrabaDestFrecuenteViaje()
                Call GrabaReferBancaria()
                Call GrabaDocumentosRecibidos()
            ElseIf RespSolicitud.Rows.Count = 2 And Len(Trim(RespSolicitud.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                MessageBox.Show("Descripción: " & RespSolicitud.Rows(0).Item(1).ToString, "ORACLE -> Error: " & RespSolicitud.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            'datahelper
            'If RespSolicitud.Fields.Count = 1 Then 'Se realizo Correctamente.
            '    MessageBox.Show(RespSolicitud.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Call GrabaProvSolicitud()
            '    Call GrabaClienteSolicitud()
            '    Call GrabaDestFrecuenteViaje()
            '    Call GrabaReferBancaria()
            '    Call GrabaDocumentosRecibidos()
            'ElseIf RespSolicitud.Fields.Count = 2 And Len(Trim(RespSolicitud.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
            '    MessageBox.Show("Descripción: " & RespSolicitud.Fields(1).Value, "ORACLE -> Error: " & RespSolicitud.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GrabaConsideracionesPago()
        Try
            Dim MyConsideracion As New dtoCONSIDERACIONESPAGO
            With MyConsideracion
                .Control = vAccionRegistro
                If vAccionRegistro = 1 Then
                    .CodigoCliente = Me.txtCodigoCliente.Text
                ElseIf vAccionRegistro = 2 Then
                    .CodigoCliente = Me.lblIDSolicitudCredito.Text
                End If
                .IDConsideracionesPago = 1 'Momentaneamente
                .PeriodoPago = Me.cmbCondicionPago.SelectedValue
                .DiasPago = Me.dtpDias.Text

                'MessageBox.Show("*" & Me.dtpA.Value & "*", "A")
                'MessageBox.Show("*" & Me.dtpB.Text & "*", "A")
                'MessageBox.Show("*" & Me.dtpC.Text & "*", "A")
                'MessageBox.Show("*" & Me.dtpD.Text & "*", "A")
                'MessageBox.Show("*" & Me.dtpHoraInicio.Text & "*", "dtpHoraInicio")
                'MessageBox.Show("*" & Me.dtpHoraFin.Text & "*", "HoraFin")

                'MessageBox.Show("*" & Format(CType(Me.dtpHoraInicio.Value, Date), "HH:mm:ss tt") & "*", "A")


                If rdbSemanal.Checked = True Then
                    .Fecha1 = 0
                    .Fecha2 = 0
                    .Fecha3 = 0
                    .Fecha4 = 0
                ElseIf rdbSemanal.Checked = False Then

                    If dtpA.Enabled = True Then
                        .Fecha1 = CType(Format(CType(Me.dtpA.Value, Date), "dd"), Integer)
                    ElseIf dtpA.Enabled = False Then
                        .Fecha1 = 0
                    End If
                    If dtpB.Enabled = True Then
                        .Fecha2 = CType(Format(CType(Me.dtpB.Value, Date), "dd"), Integer)
                    ElseIf dtpB.Enabled = False Then
                        .Fecha2 = 0
                    End If
                    If dtpC.Enabled = True Then
                        .Fecha3 = CType(Format(CType(Me.dtpC.Value, Date), "dd"), Integer)
                    ElseIf dtpC.Enabled = False Then
                        .Fecha3 = 0
                    End If
                    If dtpD.Enabled = True Then
                        .Fecha4 = CType(Format(CType(Me.dtpD.Value, Date), "dd"), Integer)
                    ElseIf dtpD.Enabled = False Then
                        .Fecha4 = 0
                    End If

                End If
                .HoraPagoIni = Format(CType(Me.dtpHoraInicio.Value, Date), "HH:mm:ss tt").ToString
                .HoraPagoFin = Format(CType(Me.dtpHoraFin.Value, Date), "HH:mm:ss tt").ToString
                .TipoPago = 3 'Momentaneamente hasta poner un combo box Credito Soles y Crdito Dolares.
                .Observaciones = Me.dgv4.Text
            End With

            'datahelper
            'Dim respConsideracion As ADODB.Recordset
            'respConsideracion = MyConsideracion.GrabaConsideracionPago
            Dim respConsideracion As DataTable = MyConsideracion.GrabaConsideracionPago

            If respConsideracion.Rows.Count = 1 Then 'Se realizo Correctamente.
                Call GrabaProvSolicitud()
                Call GrabaClienteSolicitud()
                Call GrabaDestFrecuenteViaje()
                Call GrabaReferBancaria()
                Call GrabaDocumentosRecibidos()

            ElseIf respConsideracion.Rows.Count = 2 And Len(Trim(respConsideracion.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                MessageBox.Show("Descripción: " & respConsideracion.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respConsideracion.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            'datahelper
            'If respConsideracion.Fields.Count = 1 Then 'Se realizo Correctamente.
            '    Call GrabaProvSolicitud()
            '    Call GrabaClienteSolicitud()
            '    Call GrabaDestFrecuenteViaje()
            '    Call GrabaReferBancaria()
            '    Call GrabaDocumentosRecibidos()

            'ElseIf respConsideracion.Fields.Count = 2 And Len(Trim(respConsideracion.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
            '    MessageBox.Show("Descripción: " & respConsideracion.Fields(1).Value, "ORACLE -> Error: " & respConsideracion.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GrabaProvSolicitud()
        Try
            If vAccionRegistro = 1 Then
                For i As Integer = 0 To Me.dgv1.RowCount - 2

                    Dim MyProvedores As New dtoPROVEEDORES_SOLICITUD
                    'MessageBox.Show(dgv1.Columns.Count)
                    With MyProvedores
                        .Control = vAccionRegistro
                        .IDProveedorSolicitud = 1 'Momentaneamente
                        .CodigoCliente = Me.txtCodigoCliente.Text

                        .Proveedor = dgv1.Rows(i).Cells("PROVEEDOR").Value
                        .Telefono = dgv1.Rows(i).Cells("TELEFONO").Value
                        .Contacto = dgv1.Rows(i).Cells("CONTACTO").Value

                    End With

                    'datahelper
                    'Dim respProvvedores As ADODB.Recordset
                    'respProvvedores = MyProvedores.GrabaProveedoresSolicitud
                    Dim respProvvedores As DataTable = MyProvedores.GrabaProveedoresSolicitud
                    If respProvvedores.Rows.Count = 1 Then 'Se realizo Correctamente.
                    ElseIf respProvvedores.Rows.Count = 2 And Len(Trim(respProvvedores.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                        MessageBox.Show("Descripción: " & respProvvedores.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respProvvedores.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    'datahelper
                    'If respProvvedores.Fields.Count = 1 Then 'Se realizo Correctamente.
                    'ElseIf respProvvedores.Fields.Count = 2 And Len(Trim(respProvvedores.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                    '    MessageBox.Show("Descripción: " & respProvvedores.Fields(1).Value, "ORACLE -> Error: " & respProvvedores.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End If
                Next
            End If

            If vAccionRegistro = 2 Then
                Dim MyProvedoresD As New dtoPROVEEDORES_SOLICITUD
                'MessageBox.Show(dgv1.Columns.Count)
                With MyProvedoresD
                    .Control = 2
                    .IDProveedorSolicitud = Me.lblIDSolicitudCredito.Text '1 'Momentaneamente
                    .CodigoCliente = Me.txtCodigoCliente.Text
                    .Proveedor = "NULL"
                    .Telefono = "NULL"
                    .Contacto = "NULL"
                End With

                'datahelper
                'Dim respProvvedoresD As ADODB.Recordset
                'respProvvedoresD = MyProvedoresD.GrabaProveedoresSolicitud
                Dim respProvvedoresD As DataTable = MyProvedoresD.GrabaProveedoresSolicitud
                If respProvvedoresD.Rows.Count = 1 Then 'Se realizo Correctamente.
                    For i As Integer = 0 To Me.dgv1.RowCount - 2

                        Dim MyProvedores As New dtoPROVEEDORES_SOLICITUD
                        With MyProvedores
                            .Control = 1
                            .IDProveedorSolicitud = Me.lblIDSolicitudCredito.Text '1 'Momentaneamente
                            .CodigoCliente = Me.txtCodigoCliente.Text
                            .Proveedor = dgv1.Rows(i).Cells("PROVEEDOR").Value
                            .Telefono = dgv1.Rows(i).Cells("TELEFONO").Value
                            .Contacto = dgv1.Rows(i).Cells("CONTACTO").Value
                        End With

                        'datahelper
                        'Dim respProvvedores As ADODB.Recordset
                        'respProvvedores = MyProvedores.GrabaProveedoresSolicitud
                        Dim respProvvedores As DataTable = MyProvedores.GrabaProveedoresSolicitud

                        If respProvvedores.Rows.Count = 1 Then 'Se realizo Correctamente.
                        ElseIf respProvvedores.Rows.Count = 2 And Len(Trim(respProvvedores.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                            MessageBox.Show("Descripción: " & respProvvedores.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respProvvedores.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Next
                ElseIf respProvvedoresD.Rows.Count = 2 And Len(Trim(respProvvedoresD.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                    MessageBox.Show("Descripción: " & respProvvedoresD.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respProvvedoresD.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                'datahelper
                'If respProvvedoresD.Fields.Count = 1 Then 'Se realizo Correctamente.
                '    For i As Integer = 0 To Me.dgv1.RowCount - 2

                '        Dim MyProvedores As New dtoPROVEEDORES_SOLICITUD
                '        With MyProvedores
                '            .Control = 1
                '            .IDProveedorSolicitud = Me.lblIDSolicitudCredito.Text '1 'Momentaneamente
                '            .CodigoCliente = Me.txtCodigoCliente.Text
                '            .Proveedor = dgv1.Rows(i).Cells("PROVEEDOR").Value
                '            .Telefono = dgv1.Rows(i).Cells("TELEFONO").Value
                '            .Contacto = dgv1.Rows(i).Cells("CONTACTO").Value
                '        End With

                '        Dim respProvvedores As ADODB.Recordset
                '        respProvvedores = MyProvedores.GrabaProveedoresSolicitud

                '        If respProvvedores.Fields.Count = 1 Then 'Se realizo Correctamente.
                '        ElseIf respProvvedores.Fields.Count = 2 And Len(Trim(respProvvedores.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '            MessageBox.Show("Descripción: " & respProvvedores.Fields(1).Value, "ORACLE -> Error: " & respProvvedores.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '        End If
                '    Next
                'ElseIf respProvvedoresD.Fields.Count = 2 And Len(Trim(respProvvedoresD.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '    MessageBox.Show("Descripción: " & respProvvedoresD.Fields(1).Value, "ORACLE -> Error: " & respProvvedoresD.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GrabaClienteSolicitud()
        Try
            If vAccionRegistro = 1 Then
                For i As Integer = 0 To Me.dgv5.RowCount - 2
                    Dim MyProvedores As New dtoCLIENTES_SOLICITUD
                    With MyProvedores
                        .Control = 1 'vAccionRegistro
                        .IDClientesSolicitud = 1 'Momentaneamente
                        .CodigoCliente = Me.txtCodigoCliente.Text

                        .Clientes = dgv5.Rows(i).Cells("CLIENTE").Value
                        .Telefono = dgv5.Rows(i).Cells("TELEFONO").Value
                        .Contacto = dgv5.Rows(i).Cells("CONTACTO").Value

                    End With

                    'datahelper
                    'Dim respClientes As ADODB.Recordset
                    Dim respClientes As DataTable = MyProvedores.GrabaClientesSolicitud

                    If respClientes.Rows.Count = 1 Then 'Se realizo Correctamente.
                    ElseIf respClientes.Rows.Count = 2 And Len(Trim(respClientes.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                        MessageBox.Show("Descripción: " & respClientes.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respClientes.Rows.Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    'datahelper
                    'If respClientes.Fields.Count = 1 Then 'Se realizo Correctamente.
                    'ElseIf respClientes.Fields.Count = 2 And Len(Trim(respClientes.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                    '    MessageBox.Show("Descripción: " & respClientes.Fields(1).Value, "ORACLE -> Error: " & respClientes.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End If
                Next
            End If

            If vAccionRegistro = 2 Then

                Dim MyProvedoresD As New dtoCLIENTES_SOLICITUD
                With MyProvedoresD
                    .Control = 2
                    .IDClientesSolicitud = Me.lblIDSolicitudCredito.Text ' 1 'Momentaneamente
                    .CodigoCliente = Me.txtCodigoCliente.Text

                    .Clientes = "NULL"
                    .Telefono = "NULL"
                    .Contacto = "NULL"

                End With

                'datahelper
                'Dim respClientesD As ADODB.Recordset
                'respClientesD = MyProvedoresD.GrabaClientesSolicitud
                Dim respClientesD As DataTable = MyProvedoresD.GrabaClientesSolicitud
                If respClientesD.Rows.Count = 1 Then 'Se realizo Correctamente.
                    For i As Integer = 0 To Me.dgv5.RowCount - 2
                        Dim MyProvedores As New dtoCLIENTES_SOLICITUD
                        With MyProvedores
                            .Control = 1
                            .IDClientesSolicitud = Me.lblIDSolicitudCredito.Text '1 'Momentaneamente
                            .CodigoCliente = Me.txtCodigoCliente.Text

                            .Clientes = dgv5.Rows(i).Cells("CLIENTE").Value
                            .Telefono = dgv5.Rows(i).Cells("TELEFONO").Value
                            .Contacto = dgv5.Rows(i).Cells("CONTACTO").Value

                        End With

                        'datahelper
                        'Dim respClientes As ADODB.Recordset
                        'respClientes = MyProvedores.GrabaClientesSolicitud
                        Dim respClientes As DataTable = MyProvedores.GrabaClientesSolicitud

                        If respClientes.Rows.Count = 1 Then 'Se realizo Correctamente.
                        ElseIf respClientes.Rows.Count = 2 And Len(Trim(respClientes.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                            MessageBox.Show("Descripción: " & respClientes.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respClientes.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Next
                ElseIf respClientesD.Rows.Count = 2 And Len(Trim(respClientesD.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                    MessageBox.Show("Descripción: " & respClientesD.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respClientesD.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If


                'datahelper
                'If respClientesD.Fields.Count = 1 Then 'Se realizo Correctamente.
                '    For i As Integer = 0 To Me.dgv5.RowCount - 2
                '        Dim MyProvedores As New dtoCLIENTES_SOLICITUD
                '        With MyProvedores
                '            .Control = 1
                '            .IDClientesSolicitud = Me.lblIDSolicitudCredito.Text '1 'Momentaneamente
                '            .CodigoCliente = Me.txtCodigoCliente.Text

                '            .Clientes = dgv5.Rows(i).Cells("CLIENTE").Value
                '            .Telefono = dgv5.Rows(i).Cells("TELEFONO").Value
                '            .Contacto = dgv5.Rows(i).Cells("CONTACTO").Value

                '        End With

                '        Dim respClientes As ADODB.Recordset
                '        respClientes = MyProvedores.GrabaClientesSolicitud

                '        If respClientes.Fields.Count = 1 Then 'Se realizo Correctamente.
                '        ElseIf respClientes.Fields.Count = 2 And Len(Trim(respClientes.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '            MessageBox.Show("Descripción: " & respClientes.Fields(1).Value, "ORACLE -> Error: " & respClientes.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '        End If
                '    Next
                'ElseIf respClientesD.Fields.Count = 2 And Len(Trim(respClientesD.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '    MessageBox.Show("Descripción: " & respClientesD.Fields(1).Value, "ORACLE -> Error: " & respClientesD.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
            End If

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GrabaDestFrecuenteViaje()
        Try
            If vAccionRegistro = 1 Then
                For i As Integer = 0 To dgv6.RowCount - 1
                    If dgv6.Rows(i).Cells("SELECCION").Value = 1 Then

                        Dim MyDestinos As New dtoDESTINOS_VIAJE_SOLICITUD
                        With MyDestinos
                            .Control = vAccionRegistro
                            .IDDestinosViaje = 1 'Momentaneamente
                            .CodigoCliente = Me.txtCodigoCliente.Text
                            .IDRuta = dgv6.Rows(i).Cells("IDRUTAS").Value
                            .NombreRuta = dgv6.Rows(i).Cells("NOMBRE_RUTA").Value
                            .Seleccion = dgv6.Rows(i).Cells("SELECCION").Value
                            .Origen = dgv6.Rows(i).Cells("ORIGEN").Value
                            .Destino = dgv6.Rows(i).Cells("DESTINO").Value
                        End With

                        'datahelper
                        'Dim respDestinos As ADODB.Recordset
                        'respDestinos = MyDestinos.GrabaDestinosViaje
                        Dim respDestinos As DataTable = MyDestinos.GrabaDestinosViaje
                        If respDestinos.Rows.Count = 1 Then 'Se realizo Correctamente.
                        ElseIf respDestinos.Rows.Count = 2 And Len(Trim(respDestinos.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                            MessageBox.Show("Descripción: " & respDestinos.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respDestinos.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                        'datahelper
                        'If respDestinos.Fields.Count = 1 Then 'Se realizo Correctamente.
                        'ElseIf respDestinos.Fields.Count = 2 And Len(Trim(respDestinos.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                        '    MessageBox.Show("Descripción: " & respDestinos.Fields(1).Value, "ORACLE -> Error: " & respDestinos.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'End If
                    End If
                Next
            End If
            If vAccionRegistro = 2 Then
                Dim MyDestinosD As New dtoDESTINOS_VIAJE_SOLICITUD
                With MyDestinosD
                    .Control = 2
                    .IDDestinosViaje = Me.lblIDSolicitudCredito.Text '1 'Momentaneamente
                    .CodigoCliente = Me.txtCodigoCliente.Text
                    .IDRuta = 1
                    .NombreRuta = "NULL"
                    .Seleccion = 1
                    .Origen = "NULL"
                    .Destino = "NULL"
                End With

                'datahelper
                'Dim respDestinosD As ADODB.Recordset
                'respDestinosD = MyDestinosD.GrabaDestinosViaje
                Dim respDestinosD As DataTable = MyDestinosD.GrabaDestinosViaje

                If respDestinosD.Rows.Count = 1 Then 'Se realizo Correctamente.
                    For i As Integer = 0 To dgv6.RowCount - 1
                        If dgv6.Rows(i).Cells("SELECCION").Value = 1 Then

                            Dim MyDestinos As New dtoDESTINOS_VIAJE_SOLICITUD
                            With MyDestinos
                                .Control = 1
                                .IDDestinosViaje = Me.lblIDSolicitudCredito.Text '1 'Momentaneamente
                                .CodigoCliente = Me.txtCodigoCliente.Text
                                .IDRuta = dgv6.Rows(i).Cells("IDRUTAS").Value
                                .NombreRuta = dgv6.Rows(i).Cells("NOMBRE_RUTA").Value
                                .Seleccion = dgv6.Rows(i).Cells("SELECCION").Value
                                .Origen = dgv6.Rows(i).Cells("ORIGEN").Value
                                .Destino = dgv6.Rows(i).Cells("DESTINO").Value
                            End With

                            'datahelper
                            'Dim respDestinos As ADODB.Recordset
                            'respDestinos = MyDestinos.GrabaDestinosViaje
                            Dim respDestinos As DataTable = MyDestinos.GrabaDestinosViaje
                            If respDestinos.Rows.Count = 1 Then 'Se realizo Correctamente.
                                'MessageBox.Show(respDestinos.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ElseIf respDestinos.Rows.Count = 2 And Len(Trim(respDestinos.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                                MessageBox.Show("Descripción: " & respDestinos.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respDestinos.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    Next
                ElseIf respDestinosD.Rows.Count = 2 And Len(Trim(respDestinosD.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                    MessageBox.Show("Descripción: " & respDestinosD.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respDestinosD.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If


                'datahelper
                'If respDestinosD.Fields.Count = 1 Then 'Se realizo Correctamente.
                '    For i As Integer = 0 To dgv6.RowCount - 1
                '        If dgv6.Rows(i).Cells("SELECCION").Value = 1 Then

                '            Dim MyDestinos As New dtoDESTINOS_VIAJE_SOLICITUD
                '            With MyDestinos
                '                .Control = 1
                '                .IDDestinosViaje = Me.lblIDSolicitudCredito.Text '1 'Momentaneamente
                '                .CodigoCliente = Me.txtCodigoCliente.Text
                '                .IDRuta = dgv6.Rows(i).Cells("IDRUTAS").Value
                '                .NombreRuta = dgv6.Rows(i).Cells("NOMBRE_RUTA").Value
                '                .Seleccion = dgv6.Rows(i).Cells("SELECCION").Value
                '                .Origen = dgv6.Rows(i).Cells("ORIGEN").Value
                '                .Destino = dgv6.Rows(i).Cells("DESTINO").Value
                '            End With

                '            Dim respDestinos As ADODB.Recordset
                '            respDestinos = MyDestinos.GrabaDestinosViaje

                '            If respDestinos.Fields.Count = 1 Then 'Se realizo Correctamente.
                '                'MessageBox.Show(respDestinos.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '            ElseIf respDestinos.Fields.Count = 2 And Len(Trim(respDestinos.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '                MessageBox.Show("Descripción: " & respDestinos.Fields(1).Value, "ORACLE -> Error: " & respDestinos.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '            End If
                '        End If
                '    Next
                'ElseIf respDestinosD.Fields.Count = 2 And Len(Trim(respDestinosD.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '    MessageBox.Show("Descripción: " & respDestinosD.Fields(1).Value, "ORACLE -> Error: " & respDestinosD.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If

            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GrabaReferBancaria()
        Try
            If vAccionRegistro = 1 Then
                For i As Integer = 0 To Me.dgv2.RowCount - 2
                    Dim MyBancos As New dtoREFERENCIA_BANCARIA
                    With MyBancos
                        .Control = vAccionRegistro
                        .IDReferenciaBancaria = Me.lblIDSolicitudCredito.Text '1 'Momentaneamente
                        .CodigoCliente = Me.txtCodigoCliente.Text
                        .Banco = dgv2.Rows(i).Cells("BANCO").Value
                        .CtaCte = dgv2.Rows(i).Cells("CTACTE").Value
                        .Telefonos = dgv2.Rows(i).Cells("TELEFONOS").Value
                        .Sectorista = dgv2.Rows(i).Cells("SECTORISTA").Value
                    End With

                    'datahelper
                    'Dim respBancos As ADODB.Recordset
                    'respBancos = MyBancos.GrabaReferenciaBancaria
                    Dim respBancos As DataTable = MyBancos.GrabaReferenciaBancaria
                    If respBancos.Rows.Count = 1 Then 'Se realizo Correctamente.
                    ElseIf respBancos.Rows.Count = 2 And Len(Trim(respBancos.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                        MessageBox.Show("Descripción: " & respBancos.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respBancos.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    'If respBancos.Fields.Count = 1 Then 'Se realizo Correctamente.
                    'ElseIf respBancos.Fields.Count = 2 And Len(Trim(respBancos.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                    '    MessageBox.Show("Descripción: " & respBancos.Fields(1).Value, "ORACLE -> Error: " & respBancos.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End If
                Next
            End If
            If vAccionRegistro = 2 Then
                Dim MyBancosD As New dtoREFERENCIA_BANCARIA
                With MyBancosD
                    .Control = 2
                    .IDReferenciaBancaria = Me.lblIDSolicitudCredito.Text '1 'Momentaneamente
                    .CodigoCliente = Me.txtCodigoCliente.Text
                    .Banco = "NULL"
                    .CtaCte = "NULL"
                    .Telefonos = "NULL"
                    .Sectorista = "NULL"
                End With

                'datahelper
                'Dim respBancosD As ADODB.Recordset
                'respBancosD = MyBancosD.GrabaReferenciaBancaria
                Dim respBancosD As DataTable = MyBancosD.GrabaReferenciaBancaria
                If respBancosD.Rows.Count = 1 Then 'Se realizo Correctamente.
                    For i As Integer = 0 To Me.dgv2.RowCount - 2
                        Dim MyBancos As New dtoREFERENCIA_BANCARIA
                        With MyBancos
                            .Control = 1
                            .IDReferenciaBancaria = Me.lblIDSolicitudCredito.Text '1 'Momentaneamente
                            .CodigoCliente = Me.txtCodigoCliente.Text
                            .Banco = dgv2.Rows(i).Cells("BANCO").Value
                            .CtaCte = dgv2.Rows(i).Cells("CTACTE").Value
                            .Telefonos = dgv2.Rows(i).Cells("TELEFONOS").Value
                            .Sectorista = dgv2.Rows(i).Cells("SECTORISTA").Value
                        End With

                        'datahelper
                        'Dim respBancos As ADODB.Recordset
                        'respBancos = MyBancos.GrabaReferenciaBancaria
                        Dim respBancos As DataTable = MyBancos.GrabaReferenciaBancaria

                        If respBancos.Rows.Count = 1 Then 'Se realizo Correctamente.
                        ElseIf respBancos.Rows.Count = 2 And Len(Trim(respBancos.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                            MessageBox.Show("Descripción: " & respBancos.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respBancos.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Next

                ElseIf respBancosD.Rows.Count = 2 And Len(Trim(respBancosD.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                    MessageBox.Show("Descripción: " & respBancosD.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respBancosD.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If


                'datahelper
                'If respBancosD.Fields.Count = 1 Then 'Se realizo Correctamente.
                '    For i As Integer = 0 To Me.dgv2.RowCount - 2
                '        Dim MyBancos As New dtoREFERENCIA_BANCARIA
                '        With MyBancos
                '            .Control = 1
                '            .IDReferenciaBancaria = Me.lblIDSolicitudCredito.Text '1 'Momentaneamente
                '            .CodigoCliente = Me.txtCodigoCliente.Text
                '            .Banco = dgv2.Rows(i).Cells("BANCO").Value
                '            .CtaCte = dgv2.Rows(i).Cells("CTACTE").Value
                '            .Telefonos = dgv2.Rows(i).Cells("TELEFONOS").Value
                '            .Sectorista = dgv2.Rows(i).Cells("SECTORISTA").Value
                '        End With

                '        Dim respBancos As ADODB.Recordset
                '        respBancos = MyBancos.GrabaReferenciaBancaria

                '        If respBancos.Fields.Count = 1 Then 'Se realizo Correctamente.
                '        ElseIf respBancos.Fields.Count = 2 And Len(Trim(respBancos.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '            MessageBox.Show("Descripción: " & respBancos.Fields(1).Value, "ORACLE -> Error: " & respBancos.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '        End If
                '    Next

                'ElseIf respBancosD.Fields.Count = 2 And Len(Trim(respBancosD.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '    MessageBox.Show("Descripción: " & respBancosD.Fields(1).Value, "ORACLE -> Error: " & respBancosD.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GrabaDocumentosRecibidos()

        If vAccionRegistro = 1 Then
            For i As Integer = 0 To dgv3.RowCount - 1
                If dgv3.Rows(i).Cells("SELECCION").Value = 1 Then
                    Try
                        Dim MyDocumentos As New dtoDOCUMENTOS_SOLICITUD
                        With MyDocumentos
                            .Control = vAccionRegistro
                            .IDDocumentosSolicitud = Me.lblIDSolicitudCredito.Text 'IIf(IsDBNull(dgv3.Rows(i).Cells("IDDOCUMENTO_CTACTE").Value), 1, dgv3.Rows(i).Cells("IDDOCUMENTO_CTACTE").Value) '1 'Momentaneamente
                            .CodigoCliente = Me.txtCodigoCliente.Text
                            .Documentos = dgv3.Rows(i).Cells("DOCUMENTOS").Value
                            .Seleccion = dgv3.Rows(i).Cells("SELECCION").Value
                        End With

                        'datahelper
                        'Dim respDocumentos As ADODB.Recordset
                        'respDocumentos = MyDocumentos.GrabaReferenciaBancaria
                        Dim respDocumentos As DataTable = MyDocumentos.GrabaReferenciaBancaria
                        If respDocumentos.Rows.Count = 1 Then 'Se realizo Correctamente.
                        ElseIf respDocumentos.Rows.Count = 2 And Len(Trim(respDocumentos.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                            MessageBox.Show("Descripción: " & respDocumentos.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respDocumentos.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                        'datahelper
                        'If respDocumentos.Fields.Count = 1 Then 'Se realizo Correctamente.
                        'ElseIf respDocumentos.Fields.Count = 2 And Len(Trim(respDocumentos.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                        '    MessageBox.Show("Descripción: " & respDocumentos.Fields(1).Value, "ORACLE -> Error: " & respDocumentos.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'End If
                    Catch Qex As Exception
                        MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Next
        End If

        If vAccionRegistro = 2 Then
            Dim MyDocumentosDeleted As New dtoDOCUMENTOS_SOLICITUD
            With MyDocumentosDeleted
                .Control = 2
                .IDDocumentosSolicitud = Me.lblIDSolicitudCredito.Text 'IIf(IsDBNull(dgv3.Rows(i).Cells("IDDOCUMENTO_CTACTE").Value), 1, dgv3.Rows(i).Cells("IDDOCUMENTO_CTACTE").Value) '1 'Momentaneamente
                .CodigoCliente = Me.txtCodigoCliente.Text
                .Documentos = "NULL"
                .Seleccion = 1
            End With

            'datahelper
            'Dim respDocumentosDeleted As ADODB.Recordset
            'respDocumentosDeleted = MyDocumentosDeleted.GrabaReferenciaBancaria
            Dim respDocumentosDeleted As DataTable = MyDocumentosDeleted.GrabaReferenciaBancaria
            If respDocumentosDeleted.Rows.Count = 1 Then 'Se realizo Correctamente.
            ElseIf respDocumentosDeleted.Rows.Count = 2 And Len(Trim(respDocumentosDeleted.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                MessageBox.Show("Descripción: " & respDocumentosDeleted.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respDocumentosDeleted.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            'datahelper
            'If respDocumentosDeleted.Fields.Count = 1 Then 'Se realizo Correctamente.
            'ElseIf respDocumentosDeleted.Fields.Count = 2 And Len(Trim(respDocumentosDeleted.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
            '    MessageBox.Show("Descripción: " & respDocumentosDeleted.Fields(1).Value, "ORACLE -> Error: " & respDocumentosDeleted.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

            For i As Integer = 0 To dgv3.RowCount - 1
                If dgv3.Rows(i).Cells("SELECCION").Value = 1 Then
                    Try
                        Dim MyDocumentos As New dtoDOCUMENTOS_SOLICITUD
                        With MyDocumentos
                            .Control = 1
                            .IDDocumentosSolicitud = Me.lblIDSolicitudCredito.Text 'IIf(IsDBNull(dgv3.Rows(i).Cells("IDDOCUMENTO_CTACTE").Value), 1, dgv3.Rows(i).Cells("IDDOCUMENTO_CTACTE").Value) '1 'Momentaneamente
                            .CodigoCliente = Me.txtCodigoCliente.Text
                            .Documentos = dgv3.Rows(i).Cells("DOCUMENTOS").Value
                            .Seleccion = dgv3.Rows(i).Cells("SELECCION").Value
                        End With

                        'datahelper
                        'Dim respDocumentos As ADODB.Recordset
                        'respDocumentos = MyDocumentos.GrabaReferenciaBancaria
                        Dim respDocumentos As DataTable = MyDocumentos.GrabaReferenciaBancaria
                        If respDocumentos.Rows.Count = 1 Then 'Se realizo Correctamente.
                        ElseIf respDocumentos.Rows.Count = 2 And Len(Trim(respDocumentos.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                            MessageBox.Show("Descripción: " & respDocumentos.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respDocumentos.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                        'datahelper
                        'If respDocumentos.Fields.Count = 1 Then 'Se realizo Correctamente.
                        'ElseIf respDocumentos.Fields.Count = 2 And Len(Trim(respDocumentos.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                        '    MessageBox.Show("Descripción: " & respDocumentos.Fields(1).Value, "ORACLE -> Error: " & respDocumentos.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'End If
                    Catch Qex As Exception
                        MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Next
        End If

    End Sub

    Private Sub MyTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyTreeView.AfterSelect
        For i As Integer = 0 To MyTreeView.Nodes(0).Nodes.Count - 1
            MyTreeView.Nodes(0).Nodes(i).Checked = False
        Next
        e.Node.Checked = True
    End Sub

    Private Sub LLenaCamposSolicitud()
        Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
        'txtNroSolicitud.Text = CType(dgvr.Cells("CODIGO").Value, String)
        txtFuncionarioActual.Text = CType(dgvr.Cells("FUNCIONARIO").Value, String)
        txtCodigoCliente.Text = CType(dgvr.Cells("CODIGO").Value, String)
        txtNombreCliente.Text = CType(dgvr.Cells("RAZONSOCIAL").Value, String)
        txtRepresentanteLegal.Text = CType(dgvr.Cells("REPRESENTANTE_LEGAL").Value, String)

        'datahelper
        'Dim rstDirecciones As ADODB.Recordset
        'Dim rstRubro As ADODB.Recordset
        'Dim da As New OleDbDataAdapter
        'Dim dtDirecciones As New DataTable
        'Dim dtRubro As New DataTable
        'rstDirecciones = Funciones.LeerDireccionRubro(txtCodigoCliente.Text)
        'rstRubro = rstDirecciones.NextRecordset
        'rstCodicionPago = rstDirecciones.NextRecordset
        'da.Fill(dtDirecciones, rstDirecciones)
        'da.Fill(dtRubro, rstRubro)
        'da.Fill(dtCondicionPago, rstCodicionPago)

        Dim ds As DataSet = Funciones.LeerDireccionRubro(txtCodigoCliente.Text)
        Dim dtDirecciones As DataTable = ds.Tables(0)
        Dim dtRubro As DataTable = ds.Tables(1)
        dtCondicionPago = ds.Tables(2)

        dvCondicionPago = Funciones.CargarCombo(Me.cmbCondicionPago, dtCondicionPago, "CONDICION", "IDCONDICION_PLAZO", 1)
        If dtDirecciones.Rows.Count = 0 Then
            txtDireccionLegal.Text = ""
            txtGiroNegocio.Text = ""
        ElseIf dtDirecciones.Rows.Count = 1 Then
            txtDireccionLegal.Text = dtDirecciones.Rows(0)(0)
            txtGiroNegocio.Text = dtRubro.Rows(0)(0)
        Else
            txtDireccionLegal.Text = ""
            txtGiroNegocio.Text = ""
        End If

        MenuTab.Items(0).Enabled = False
        MenuTab.Items(1).Enabled = True
        MenuTab.Items(2).Enabled = True
        MenuTab.Items(3).Enabled = True
        MenuTab.Items(4).Enabled = True
        Me.SplitContainer2.Panel1Collapsed = True
        SelectMenu(1)
        NuevoToolStripMenuItem.Enabled = False
        EdicionToolStripMenuItem.Enabled = False
        CancelarToolStripmenuItem.Enabled = True
        CancelarToolStripmenuItem.Visible = True
        GrabarToolStripMenuItem.Enabled = False 'Colocar en todos los formualrios esto, luego de dshabilitarlos.
        EliminarToolStripMenuItem.Enabled = False
        ExportarToolStripMenuItem.Enabled = False
        ImprimirToolStripMenuItem.Enabled = False


        Dim MyDrw As DataRow = dtDatosSolicitud.Rows(0)

        Me.txtCreditoSolicitado.Text = Format(Math.Round(Convert.ToDouble(MyDrw(25)), 2), "#########0.00")
        Me.txtNroSolicitud.Text = IIf(IsDBNull(MyDrw(4)) = True, "", MyDrw(4))
        Me.txtTelefonoDireccionLegal.Text = IIf(IsDBNull(MyDrw(6)) = True, "", MyDrw(6)) 'MyDrw(6)
        Me.txtFaxDireccionLegal.Text = IIf(IsDBNull(MyDrw(7)) = True, "", MyDrw(7)) 'MyDrw(7)
        Me.txtEmailRepLegal.Text = IIf(IsDBNull(MyDrw(9)) = True, "", MyDrw(9)) ' MyDrw(9)
        Me.txtTelefonoRepLegal.Text = IIf(IsDBNull(MyDrw(10)) = True, "", MyDrw(10)) ' MyDrw(10)
        Me.txtMovilRepLegal.Text = IIf(IsDBNull(MyDrw(11)) = True, "", MyDrw(11)) ' MyDrw(11)
        Me.txtGerenteFinanciero.Text = IIf(IsDBNull(MyDrw(12)) = True, "", MyDrw(12)) ' MyDrw(12)
        Me.txtEmailGerFinanciero.Text = IIf(IsDBNull(MyDrw(13)) = True, "", MyDrw(13)) 'MyDrw(13)
        Me.txtTelefonoGerFinanciero.Text = IIf(IsDBNull(MyDrw(14)) = True, "", MyDrw(14)) 'MyDrw(14)
        Me.txtMovilGerFinanciero.Text = IIf(IsDBNull(MyDrw(15)) = True, "", MyDrw(15)) 'MyDrw(15)
        Me.txtEncargadoPagos.Text = IIf(IsDBNull(MyDrw(17)) = True, "", MyDrw(17)) 'MyDrw(17)
        Me.txtEmailEncPagos.Text = IIf(IsDBNull(MyDrw(18)) = True, "", MyDrw(18)) 'MyDrw(18)
        Me.txtTelefonoEncPagos.Text = IIf(IsDBNull(MyDrw(19)) = True, "", MyDrw(19)) ' MyDrw(19)
        Me.txtMovilEncPagos.Text = IIf(IsDBNull(MyDrw(20)) = True, "", MyDrw(20)) 'MyDrw(20)
        Me.txtPersonaContacto.Text = IIf(IsDBNull(MyDrw(21)) = True, "", MyDrw(21)) 'MyDrw(21)
        Me.txtEmailPersonaContacto.Text = IIf(IsDBNull(MyDrw(22)) = True, "", MyDrw(22)) ' MyDrw(22)
        Me.txtTelefonoPersonaContacto.Text = IIf(IsDBNull(MyDrw(23)) = True, "", MyDrw(23)) 'MyDrw(23)
        Me.txtMovilPersonaContacto.Text = IIf(IsDBNull(MyDrw(24)) = True, "", MyDrw(24))  'MyDrw(24)

        'Dim MyDrwPagos As DataRow = dtConsideracionePago.Rows(0)

        Me.dgv4.Text = IIf(IsDBNull(MyDrw(35)) = True, "", MyDrw(35)) ' MyDrw(35)
        Me.cmbCondicionPago.SelectedValue = MyDrw(26)
        Me.dtpDias.SelectedItem = MyDrw(27)
        Me.dtpHoraInicio.Text = IIf(IsDBNull(MyDrw(32)) = True, "", MyDrw(32)) ' MyDrw(32)
        Me.dtpHoraFin.Text = IIf(IsDBNull(MyDrw(33)) = True, "", MyDrw(33)) 'MyDrw(33)
        'if MyDrw(28) = 0 Then
        If IIf(IsDBNull(MyDrw(28)) = True, 0, MyDrw(28)) = 0 Then
            'MessageBox.Show("Igual a Cero")
            Me.rdbSemanal.Checked = True
        ElseIf IIf(IsDBNull(MyDrw(28)) = True, 0, MyDrw(28)) <> 0 Then
            'MessageBox.Show("Deferente a Cero")
            Me.rdbMensual.Checked = True
        End If

        If IIf(IsDBNull(MyDrw(28)) = True, 0, MyDrw(28)) <> 0 Then
            Me.dtpA.Value = (MyDrw(28) & "/01/1900 04:52:43 p.m.")
            Me.dtpA.Enabled = True
            Me.chkYA.Enabled = False
        ElseIf IIf(IsDBNull(MyDrw(28)) = True, 0, MyDrw(28)) = 0 Then
            Me.dtpA.Enabled = False
        End If
        If IIf(IsDBNull(MyDrw(29)) = True, 0, MyDrw(29)) <> 0 Then
            Me.dtpB.Value = (MyDrw(29) & "/01/1900 04:52:43 p.m.")
            Me.dtpB.Enabled = True
        ElseIf IIf(IsDBNull(MyDrw(29)) = True, 0, MyDrw(29)) = 0 Then
            Me.dtpB.Enabled = False
        End If
        If IIf(IsDBNull(MyDrw(30)) = True, 0, MyDrw(30)) <> 0 Then
            Me.dtpC.Value = (MyDrw(30) & "/01/1900 04:52:43 p.m.")
            Me.dtpC.Enabled = True
        ElseIf IIf(IsDBNull(MyDrw(30)) = True, 0, MyDrw(30)) = 0 Then
            Me.dtpC.Enabled = False
        End If
        If IIf(IsDBNull(MyDrw(31)) = True, 0, MyDrw(31)) <> 0 Then
            Me.dtpD.Value = (MyDrw(31) & "/01/1900 04:52:43 p.m.")
            Me.dtpD.Enabled = True
        ElseIf IIf(IsDBNull(MyDrw(31)) = True, 0, MyDrw(31)) = 0 Then
            Me.dtpD.Enabled = False
        End If

        DesactivaCamposCtaCte(Me.txtCreditoSolicitado, Me.txtNroSolicitud, Me.txtTelefonoDireccionLegal, Me.txtFaxDireccionLegal, Me.txtEmailRepLegal, Me.txtTelefonoRepLegal, Me.txtMovilRepLegal, Me.txtGerenteFinanciero, Me.txtEmailGerFinanciero, Me.txtTelefonoGerFinanciero, Me.txtMovilGerFinanciero, Me.txtEncargadoPagos, Me.txtEmailEncPagos, Me.txtTelefonoEncPagos, Me.txtMovilEncPagos, Me.txtPersonaContacto, Me.txtEmailPersonaContacto, Me.txtTelefonoPersonaContacto, Me.txtMovilPersonaContacto)

        dgv1.Columns.Clear()
        Call CargaDatosProveedores(True, True, True)
        dgv5.Columns.Clear()
        Call CargaDatosCliente(True, True, True)
        dgv6.Columns.Clear()
        Call CargaDestinosViaje(True, False, False)
        dgv2.Columns.Clear()
        Call CargaReferenciabancaria(True, True, True)
        dgv3.Columns.Clear()
        Call CargaDocumentos(True, False, False)

        Me.gruCtaCteFinal.Enabled = True

    End Sub

    Private Sub DesactivaCamposCtaCte(ByVal ParamArray Montos() As TextBox)
        For i As Integer = 0 To UBound(Montos)
            Montos(i).ReadOnly = True
            Montos(i).BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        Next
    End Sub
    Private Sub ActivaCamposCtaCte(ByVal ParamArray Montos() As TextBox)
        For i As Integer = 0 To UBound(Montos)
            Montos(i).ReadOnly = False
            Montos(i).BackColor = Color.White
            Montos(i).Text = ""
        Next
    End Sub
    Private Sub CargaDatosProveedores(Optional ByVal Editable As Boolean = False, Optional ByVal AddRows As Boolean = False, Optional ByVal DeletedRows As Boolean = True)
        With dgv1
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = DeletedRows
            .AllowUserToAddRows = AddRows
            .AutoGenerateColumns = False
            .DataSource = dtProveedoresSolicitud.DefaultView
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = True
            '.RowHeadersWidth = 20
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = Editable
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .HeaderText = "IDPROVEEDOR_SOLICITUD"
            .Name = "IDPROVEEDOR_SOLICITUD"
            .DataPropertyName = "IDPROVEEDOR_SOLICITUD"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = "IDSOLICITUD_CREDITO"
            .Name = "IDSOLICITUD_CREDITO"
            .DataPropertyName = "IDSOLICITUD_CREDITO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "PROVEEDOR"
            .Name = "PROVEEDOR"
            .DataPropertyName = "PROVEEDOR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "TELEFONO"
            .Name = "TELEFONO"
            .DataPropertyName = "TELEFONO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .HeaderText = "CONTACTO"
            .Name = "CONTACTO"
            .DataPropertyName = "CONTACTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        dgv1.Columns.AddRange(col0, col1, col2, col3, col4)
        dgv1.Columns(0).Visible = False
        dgv1.Columns(1).Visible = False
    End Sub
    Private Sub CargaDatosCliente(Optional ByVal Editable As Boolean = False, Optional ByVal AddRows As Boolean = False, Optional ByVal DeletedRows As Boolean = True)
        With dgv5
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = DeletedRows
            .AllowUserToAddRows = AddRows
            .AutoGenerateColumns = False
            .DataSource = dtClientesSolicitud.DefaultView
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = True
            '.RowHeadersWidth = 20
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = Editable
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .HeaderText = "IDCLIENTES_SOLICITUD"
            .Name = "IDCLIENTES_SOLICITUD"
            .DataPropertyName = "IDCLIENTES_SOLICITUD"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = "IDSOLICITUD_CREDITO"
            .Name = "IDSOLICITUD_CREDITO"
            .DataPropertyName = "IDSOLICITUD_CREDITO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "CLIENTE"
            .Name = "CLIENTE"
            .DataPropertyName = "CLIENTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "TELEFONO"
            .Name = "TELEFONO"
            .DataPropertyName = "TELEFONO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .HeaderText = "CONTACTO"
            .Name = "CONTACTO"
            .DataPropertyName = "CONTACTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        dgv5.Columns.AddRange(col0, col1, col2, col3, col4)
        dgv5.Columns(0).Visible = False
        dgv5.Columns(1).Visible = False
    End Sub
    Private Sub CargaDestinosViaje(Optional ByVal Editable As Boolean = False, Optional ByVal AddRows As Boolean = False, Optional ByVal DeletedRows As Boolean = True)
        'With dgv6
        '    .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        '    .Font = New Font("Arial", 8.0!, FontStyle.Regular)
        '    .AllowUserToOrderColumns = True
        '    .AllowUserToDeleteRows = DeletedRows
        '    .AllowUserToAddRows = AddRows
        '    .AutoGenerateColumns = False
        '    .DataSource = dtRutas.DefaultView 'dtDestinosViaje.DefaultView
        '    .SelectionMode = DataGridViewSelectionMode.CellSelect
        '    .RowHeadersVisible = False
        '    '.RowHeadersWidth = 20
        '    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    .ReadOnly = Editable
        'End With

        'Dim col0 As New DataGridViewTextBoxColumn
        'With col0
        '    .HeaderText = "IDDESTINO_VIAJE"
        '    .Name = "IDDESTINO_VIAJE"
        '    .DataPropertyName = "IDDESTINO_VIAJE"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With
        'Dim col1 As New DataGridViewTextBoxColumn
        'With col1
        '    .HeaderText = "IDSOLICITUD_CREDITO"
        '    .Name = "IDSOLICITUD_CREDITO"
        '    .DataPropertyName = "IDSOLICITUD_CREDITO"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With
        'Dim col2 As New DataGridViewTextBoxColumn
        'With col2
        '    .HeaderText = "IDRUTA"
        '    .Name = "IDRUTA"
        '    .DataPropertyName = "IDRUTA"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With
        'Dim col3 As New DataGridViewTextBoxColumn
        'With col3
        '    .HeaderText = "NOMBRE_RUTA"
        '    .Name = "NOMBRE_RUTA"
        '    .DataPropertyName = "NOMBRE_RUTA"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With
        'Dim col4 As New DataGridViewCheckBoxColumn
        'With col4
        '    .HeaderText = "SELECCION"
        '    .Name = "SELECCION"
        '    .DataPropertyName = "SELECCION"
        '    .ThreeState = False
        '    .TrueValue = 1
        '    .FalseValue = 0
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With
        'Dim col5 As New DataGridViewTextBoxColumn
        'With col5
        '    .HeaderText = "ORIGEN"
        '    .Name = "ORIGEN"
        '    .DataPropertyName = "ORIGEN"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With
        'Dim col6 As New DataGridViewTextBoxColumn
        'With col6
        '    .HeaderText = "DESTINO"
        '    .Name = "DESTINO"
        '    .DataPropertyName = "DESTINO"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With
        'dgv6.Columns.AddRange(col0, col1, col2, col3, col4, col5, col6)
        'dgv6.Columns(0).Visible = False
        'dgv6.Columns(1).Visible = False
        'dgv6.Columns(2).Visible = False
        'dgv6.Columns(5).Visible = False
        'dgv6.Columns(6).Visible = False
        dvRutas = dtRutas.DefaultView
        dgv6.Columns.Clear()
        With dgv6
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvRutas
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            '.RowHeadersWidth = 30
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .HeaderText = "IDRUTAS"
            .Name = "IDRUTAS"
            .DataPropertyName = "IDRUTAS"
            .Width = 62
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .Name = "NOMBRE_RUTA"
            .DataPropertyName = "NOMBRE_RUTA"
            .ReadOnly = True
            .ToolTipText = "Nombre de la Ruta: Orige-Destino"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col2 As New DataGridViewCheckBoxColumn
        With col2
            .HeaderText = "SELECCION"
            .Name = "SELECCION"
            .DataPropertyName = "SELECCION"
            .Width = 62
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim Col4 As New DataGridViewTextBoxColumn
        With Col4
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        dgv6.Columns.AddRange(col0, col1, col2, col3, Col4)
        dgv6.Columns(0).Visible = False
        dgv6.Columns(3).Visible = False
        dgv6.Columns(4).Visible = False
    End Sub
    Private Sub CargaReferenciabancaria(Optional ByVal Editable As Boolean = False, Optional ByVal AddRows As Boolean = False, Optional ByVal DeletedRows As Boolean = True)
        With dgv2
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = DeletedRows
            .AllowUserToAddRows = AddRows
            .AutoGenerateColumns = False
            .DataSource = dtReferenciaBancaria.DefaultView
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = True
            '.RowHeadersWidth = 20
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = Editable
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .HeaderText = "IDREFERENCIA_BANCARIA"
            .Name = "IDREFERENCIA_BANCARIA"
            .DataPropertyName = "IDREFERENCIA_BANCARIA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = "IDSOLICITUD_CREDITO"
            .Name = "IDSOLICITUD_CREDITO"
            .DataPropertyName = "IDSOLICITUD_CREDITO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "BANCO"
            .Name = "BANCO"
            .DataPropertyName = "BANCO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "CTACTE"
            .Name = "CTACTE"
            .DataPropertyName = "CTACTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .HeaderText = "TELEFONOS"
            .Name = "TELEFONOS"
            .DataPropertyName = "TELEFONOS"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .HeaderText = "SECTORISTA"
            .Name = "SECTORISTA"
            .DataPropertyName = "SECTORISTA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        dgv2.Columns.AddRange(col0, col1, col2, col3, col4, col5)
        dgv2.Columns(0).Visible = False
        dgv2.Columns(1).Visible = False

    End Sub
    Private Sub CargaDocumentos(Optional ByVal Editable As Boolean = False, Optional ByVal AddRows As Boolean = False, Optional ByVal DeletedRows As Boolean = True)
        'With dgv3
        '    .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        '    .Font = New Font("Arial", 8.0!, FontStyle.Regular)
        '    .AllowUserToOrderColumns = True
        '    .AllowUserToDeleteRows = DeletedRows
        '    .AllowUserToAddRows = AddRows
        '    .AutoGenerateColumns = False
        '    .DataSource = dtDocumentosRecibidos.DefaultView
        '    .SelectionMode = DataGridViewSelectionMode.CellSelect
        '    .RowHeadersVisible = False
        '    '.RowHeadersWidth = 20
        '    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    .ReadOnly = Editable
        'End With

        'Dim col0 As New DataGridViewTextBoxColumn
        'With col0
        '    .HeaderText = "IDDOCUMENTOS_SOLICITUD"
        '    .Name = "IDDOCUMENTO_CTACTE"
        '    .DataPropertyName = "IDDOCUMENTOS_SOLICITUD"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With
        'Dim col1 As New DataGridViewTextBoxColumn
        'With col1
        '    .HeaderText = "IDSOLICITUD_CREDITO"
        '    .Name = "IDSOLICITUD_CREDITO"
        '    .DataPropertyName = "IDSOLICITUD_CREDITO"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With
        'Dim col2 As New DataGridViewTextBoxColumn
        'With col2
        '    .HeaderText = "DOCUMENTOS"
        '    .Name = "DOCUMENTOS"
        '    .DataPropertyName = "DOCUMENTOS"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With
        'Dim col3 As New DataGridViewCheckBoxColumn
        'With col3
        '    .HeaderText = "SELECCION"
        '    .Name = "SELECCION"
        '    .DataPropertyName = "SELECCION"
        '    .ThreeState = False
        '    .TrueValue = 1
        '    .FalseValue = 0
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With

        'dgv3.Columns.AddRange(col0, col1, col2, col3)
        'dgv3.Columns(0).Visible = False
        'dgv3.Columns(1).Visible = False
        dvDocumentos = dtDocumentos.DefaultView
        dgv3.Columns.Clear()
        With dgv3
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvDocumentos
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            '.RowHeadersWidth = 30
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .HeaderText = "IDDOCUMENTO_CTACTE"
            .Name = "IDDOCUMENTO_CTACTE"
            .DataPropertyName = "IDDOCUMENTO_CTACTE"
            .Width = 62
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .Name = "DOCUMENTOS"
            .DataPropertyName = "DOCUMENTOS"
            .ReadOnly = True
            .ToolTipText = "Documento a Adjuntar por el Cliente."
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col2 As New DataGridViewCheckBoxColumn
        With col2
            .HeaderText = "SELECCION"
            .Name = "SELECCION"
            .DataPropertyName = "SELECCION"
            .Width = 62
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        dgv3.Columns.AddRange(col0, col1, col2)
        dgv3.Columns(0).Visible = False

    End Sub

    Private Sub AprobadoDenegado()
        Try
            Dim MyAprobado As New dtoAPROBACION_CTACTE
            With MyAprobado
                .Control = vAccionAprobacion
                .CodigoPersona = Me.txtCodigoCliente.Text
                .IDConfigCtaCte = IIf(Len(Trim(Me.txtIDAprobacion.Text)) = 0, 0, Me.txtIDAprobacion.Text) '1 'Momentaneamente
                .NumeroControl = Me.txtCodigoCliente.Text
                .LineaOtorgada = CType(Me.txtLINEAFINAL.Text, Double)
                .SobreGiro = CType(Me.txtSOBREGIROLINEAFINAL.Text, Double)
                .TotalAsignado = CType(Me.txtTOTALFINAL.Text, Double)
                .EstadoRegistro = 1
                .UsuarioPersonal = MyUsuario
                .IDRolUsuario = MyRol
                .IP = MyIP
            End With

            'Dim respAprobacion As ADODB.Recordset
            'datahelper
            'respAprobacion = MyAprobado.GrabaAprobacion
            Dim respAprobacion As DataTable = MyAprobado.GrabaAprobacion

            'If respAprobacion.Fields.Count = 1 Then 'Se realizo Correctamente.
            If respAprobacion.Rows.Count = 1 Then 'Se realizo Correctamente.
                'MessageBox.Show(respAprobacion.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MessageBox.Show(respAprobacion.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.gruCtaCteFinal.Enabled = False
                txtLineaSolicitadaClon.Text = ""
                txtIDAprobacion.Text = ""
                txtCreditoAsignado.Text = ""
                txtSobregiroFinal.Text = ""
                cmbEstadoSolicitud.SelectedIndex = 0

                'ElseIf respAprobacion.Fields.Count = 2 And Len(Trim(respAprobacion.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '   MessageBox.Show("Descripción: " & respAprobacion.Fields(1).Value, "ORACLE -> Error: " & respAprobacion.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf respAprobacion.Rows.Count = 2 And Len(Trim(respAprobacion.Rows.Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                MessageBox.Show("Descripción: " & respAprobacion.Rows.Item(1).ToString, "ORACLE -> Error: " & respAprobacion.Rows.Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AprobaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AprobaciónToolStripMenuItem.Click
        Try
            btnultimo.Enabled = False
            btnprimero.Enabled = False
            '
            DataGridLista.Focus() ' Tepsa 
            Dim dgvr As DataGridViewRow = DataGridLista.CurrentRow
            txtsaldoactual.Text = ""    ' Tepsa 
            If Not dgvr Is Nothing Then
                vAccionAprobacion = 1

                Call EdicionSolicitud()
                Me.dgv1.ReadOnly = True
                Me.dgv2.ReadOnly = True
                Me.dgv3.ReadOnly = True
                Me.dgv4.ReadOnly = True
                Me.dgv5.ReadOnly = True
                Me.dgv6.ReadOnly = True

                Call AccionesAprobacion()

                'datahelper
                'Dim rstMontos As ADODB.Recordset = Funciones.CargaConfigCtaCte(dgvr.Cells("CODIGO").Value.ToString)
                'Dim dtMontos As New DataTable
                'Dim MyAdapter As New OleDbDataAdapter
                'MyAdapter.Fill(dtMontos, rstMontos)

                Dim dtMontos As DataTable = Funciones.CargaConfigCtaCte(dgvr.Cells("CODIGO").Value.ToString)
                If dtMontos.Rows.Count > 0 Then
                    'If IsDBNull(dtMontos.Rows(0).Item(0)) > 0 Then
                    MessageBox.Show("Ya se aprobo esta solicitud.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtLineaSolicitadaClon.Text = txtCreditoSolicitado.Text
                    If Not IsDBNull(dtMontos.Rows(0).Item(0)) Then
                        txtIDAprobacion.Text = dtMontos.Rows(0)(0)
                        txtCreditoAsignado.Text = dtMontos.Rows(0)(4)
                        txtTOTALFINAL.Text = dtMontos.Rows(0)(4)
                        txtSobregiroFinal.Text = dtMontos.Rows(0)(2)
                        txtsaldoactual.Text = dtMontos.Rows(0)(3)   ' Tepsa 
                        txtLINEAFINAL.Text = dtMontos.Rows(0)(4)
                        txtSOBREGIROLINEAFINAL.Text = dtMontos.Rows(0)(2)
                    End If
                Else
                    txtLineaSolicitadaClon.Text = txtCreditoSolicitado.Text
                    txtCreditoAsignado.Text = txtLineaSolicitadaClon.Text
                    txtIDAprobacion.Text = 1
                    txtSobregiroFinal.Text = ""
                    txtTOTALFINAL.Text = ""
                    txtLINEAFINAL.Text = ""
                    txtSOBREGIROLINEAFINAL.Text = ""
                End If
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AccionesAprobacion2009_eliminarlo()
        'Try
        '    If Me.DataGridLista.RowCount > 0 Then
        '        Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow
        '        Dim rstDatosSolicitud As ADODB.Recordset
        '        Dim rstProveedoresSolicitud As ADODB.Recordset
        '        Dim rstClientesSolicitud As ADODB.Recordset
        '        Dim rstDestinosViaje As ADODB.Recordset
        '        Dim rstReferenciaBancaria As ADODB.Recordset
        '        Dim rstDocumentosRecibidos As ADODB.Recordset
        '        Dim rstEstado As ADODB.Recordset
        '        Dim dtEstado As New DataTable

        '        rstDatosSolicitud = Funciones.CargaDataSolicitud(CType(dgvr.Cells("CODIGO").Value, String))
        '        rstProveedoresSolicitud = rstDatosSolicitud.NextRecordset
        '        rstClientesSolicitud = rstDatosSolicitud.NextRecordset
        '        rstDestinosViaje = rstDatosSolicitud.NextRecordset
        '        rstReferenciaBancaria = rstDatosSolicitud.NextRecordset
        '        rstDocumentosRecibidos = rstDatosSolicitud.NextRecordset
        '        rstEstado = rstDatosSolicitud.NextRecordset

        '        dtDatosSolicitud.Clear()
        '        dtProveedoresSolicitud.Clear()
        '        dtClientesSolicitud.Clear()
        '        dtDestinosViaje.Clear()
        '        dtReferenciaBancaria.Clear()
        '        dtDocumentosRecibidos.Clear()
        '        dtEstado.Clear()

        '        'Dim MyAdaptador As New OleDbDataAdapter
        '        'MyAdaptador.Fill(dtDatosSolicitud, rstDatosSolicitud)
        '        'MyAdaptador.Fill(dtProveedoresSolicitud, rstProveedoresSolicitud)
        '        'MyAdaptador.Fill(dtClientesSolicitud, rstClientesSolicitud)
        '        'MyAdaptador.Fill(dtDestinosViaje, rstDestinosViaje)
        '        'MyAdaptador.Fill(dtReferenciaBancaria, rstReferenciaBancaria)
        '        'MyAdaptador.Fill(dtDocumentosRecibidos, rstDocumentosRecibidos)
        '        'MyAdaptador.Fill(dtEstado, rstEstado)

        '        If dtEstado.Rows.Count = 0 Then 'El Cliente si presento una Solicitud.
        '            Call LLenaCamposAprobacion()
        '        ElseIf dtEstado.Rows.Count <> 0 Then 'El Cliente no Presento Ninguna Solicitud.
        '            MessageBox.Show(dtEstado.Rows(0)(0), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        End If
        '    End If
        'Catch Qex As Exception
        '    MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub EdicionSolicitud()
        Try
            If Me.DataGridLista.RowCount > 0 Then

                Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow

                'datahelper
                'Dim rstDatosSolicitud As ADODB.Recordset
                'Dim rstProveedoresSolicitud As ADODB.Recordset
                'Dim rstClientesSolicitud As ADODB.Recordset
                'Dim rstDestinosViaje As ADODB.Recordset
                'Dim rstReferenciaBancaria As ADODB.Recordset
                'Dim rstDocumentosRecibidos As ADODB.Recordset
                'Dim rstEstado As ADODB.Recordset

                'Dim dtEstado As New DataTable
                'rstDatosSolicitud = Funciones.CargaDataSolicitud(CType(dgvr.Cells("CODIGO").Value, String))
                'rstProveedoresSolicitud = rstDatosSolicitud.NextRecordset
                'rstClientesSolicitud = rstDatosSolicitud.NextRecordset
                'rstDestinosViaje = rstDatosSolicitud.NextRecordset
                'rstReferenciaBancaria = rstDatosSolicitud.NextRecordset
                'rstDocumentosRecibidos = rstDatosSolicitud.NextRecordset
                'rstEstado = rstDatosSolicitud.NextRecordset
                'dtDatosSolicitud.Clear()
                'dtProveedoresSolicitud.Clear()
                'dtClientesSolicitud.Clear()
                'dtDestinosViaje.Clear()
                'dtReferenciaBancaria.Clear()
                'dtDocumentosRecibidos.Clear()
                'dtEstado.Clear()
                'Dim MyAdaptador As New OleDbDataAdapter
                'MyAdaptador.Fill(dtDatosSolicitud, rstDatosSolicitud)
                'MyAdaptador.Fill(dtProveedoresSolicitud, rstProveedoresSolicitud)
                'MyAdaptador.Fill(dtClientesSolicitud, rstClientesSolicitud)
                'MyAdaptador.Fill(dtDestinosViaje, rstDestinosViaje)
                'MyAdaptador.Fill(dtReferenciaBancaria, rstReferenciaBancaria)
                'MyAdaptador.Fill(dtDocumentosRecibidos, rstDocumentosRecibidos)
                'MyAdaptador.Fill(dtEstado, rstEstado)

                Dim ds As DataSet = Funciones.CargaDataSolicitud(CType(dgvr.Cells("CODIGO").Value, String))
                dtDatosSolicitud = ds.Tables(0)
                dtProveedoresSolicitud = ds.Tables(1)
                dtClientesSolicitud = ds.Tables(2)
                dtDestinosViaje = ds.Tables(3)
                dtReferenciaBancaria = ds.Tables(4)
                dtDocumentosRecibidos = ds.Tables(5)
                Dim dtEstado As DataTable = ds.Tables(6)

                If IsDBNull(dtEstado.Rows(0).Item(0)) Then
                    '  Recupera la consulta de la cuenta corriente 0 Tepsa 
                    Dim l_idpersona As Integer
                    'datahelper
                    'If dtDatosSolicitud.Rows.Count > 0 Then
                    If Not IsDBNull(dtDatosSolicitud.Rows(0).Item(0)) Then
                        ' If IsDBNull(dtDatosSolicitud.Rows(0)(1)) = True Then
                        l_idpersona = CType(dtDatosSolicitud.Rows(0)(1), Integer)
                        '
                        Formato_GridView(Me.DGVconsultactacte)
                        'ModControlCtaCtePersona.fnESTADO_CTACTE_PERSONA(Me.DGVconsultactacte, l_idpersona,1,10,null,null)

                    End If
                    '

                    Call LLenaCamposSolicitudEdicion()

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
                    'ElseIf dtEstado.Rows.Count <> 0 Then
                ElseIf IsDBNull(dtEstado.Rows(0).Item(0)) Then
                    MessageBox.Show(IIf(IsDBNull(dtEstado.Rows(0)(0)), "NULO", dtEstado.Rows(0)(0)), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LLenaCamposSolicitudEdicion()
        Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
        'txtNroSolicitud.Text = CType(dgvr.Cells("CODIGO").Value, String)
        txtFuncionarioActual.Text = CType(dgvr.Cells("FUNCIONARIO").Value, String)
        txtCodigoCliente.Text = CType(dgvr.Cells("CODIGO").Value, String)
        txtNombreCliente.Text = CType(dgvr.Cells("RAZONSOCIAL").Value, String)
        txtRepresentanteLegal.Text = CType(IIf(IsDBNull(dgvr.Cells("REPRESENTANTE_LEGAL").Value), "", dgvr.Cells("REPRESENTANTE_LEGAL").Value), String)

        'datahelper
        'Dim rstDirecciones As ADODB.Recordset
        'Dim rstRubro As ADODB.Recordset
        'Dim da As New OleDbDataAdapter
        'Dim dtDirecciones As New DataTable
        'Dim dtRubro As New DataTable
        'rstDirecciones = Funciones.LeerDireccionRubro(txtCodigoCliente.Text)
        'rstRubro = rstDirecciones.NextRecordset
        'rstCodicionPago = rstDirecciones.NextRecordset
        'da.Fill(dtDirecciones, rstDirecciones)
        'da.Fill(dtRubro, rstRubro)
        'da.Fill(dtCondicionPago, rstCodicionPago)
        Dim ds As DataSet = Funciones.LeerDireccionRubro(txtCodigoCliente.Text)
        Dim dtDirecciones As DataTable = ds.Tables(0)
        Dim dtRubro As DataTable = ds.Tables(1)
        dtCondicionPago = ds.Tables(2)

        dvCondicionPago = Funciones.CargarCombo(Me.cmbCondicionPago, dtCondicionPago, "CONDICION", "IDCONDICION_PLAZO", 1)
        If dtDirecciones.Rows.Count = 0 Then
            txtDireccionLegal.Text = ""
            txtGiroNegocio.Text = ""
        ElseIf dtDirecciones.Rows.Count = 1 Then
            txtDireccionLegal.Text = dtDirecciones.Rows(0)(0)
            txtGiroNegocio.Text = dtRubro.Rows(0)(0)
        Else
            txtDireccionLegal.Text = ""
            txtGiroNegocio.Text = ""
        End If

        MenuTab.Items(0).Enabled = False
        MenuTab.Items(1).Enabled = True
        MenuTab.Items(2).Enabled = True
        MenuTab.Items(3).Enabled = True
        MenuTab.Items(4).Enabled = True
        Me.SplitContainer2.Panel1Collapsed = True
        SelectMenu(1)
        NuevoToolStripMenuItem.Enabled = False
        EdicionToolStripMenuItem.Enabled = False
        CancelarToolStripmenuItem.Enabled = True
        CancelarToolStripmenuItem.Visible = True
        GrabarToolStripMenuItem.Enabled = False 'Colocar en todos los formualrios esto, luego de dshabilitarlos.
        EliminarToolStripMenuItem.Enabled = False
        ExportarToolStripMenuItem.Enabled = False
        ImprimirToolStripMenuItem.Enabled = False


        Dim MyDrw As DataRow = dtDatosSolicitud.Rows(0)

        Me.lblIDSolicitudCredito.Text = MyDrw(0)
        Me.txtCreditoSolicitado.Text = Format(Math.Round(Convert.ToDouble(MyDrw(25)), 2), "#########0.00")
        Me.txtNroSolicitud.Text = MyDrw(4)
        Me.txtTelefonoDireccionLegal.Text = IIf(IsDBNull(MyDrw(6)) = True, "", MyDrw(6)) ' Tepsa MyDrw(6)
        Me.txtFaxDireccionLegal.Text = IIf(IsDBNull(MyDrw(7)) = True, "", MyDrw(7))  ' Tepsa MyDrw(7)
        Me.txtEmailRepLegal.Text = IIf(IsDBNull(MyDrw(9)) = True, "", MyDrw(9)) ' Tepsa  MyDrw(9)
        Me.txtTelefonoRepLegal.Text = IIf(IsDBNull(MyDrw(10)) = True, "", MyDrw(10)) 'Tepsa  MyDrw(10)
        Me.txtMovilRepLegal.Text = IIf(IsDBNull(MyDrw(11)) = True, "", MyDrw(11)) ' Tepsa  MyDrw(11)
        Me.txtGerenteFinanciero.Text = IIf(IsDBNull(MyDrw(12)) = True, "", MyDrw(12)) ' Tepsa   MyDrw(12)
        Me.txtEmailGerFinanciero.Text = IIf(IsDBNull(MyDrw(13)) = True, "", MyDrw(13)) ' Tepsa  MyDrw(13)
        Me.txtTelefonoGerFinanciero.Text = IIf(IsDBNull(MyDrw(14)) = True, "", MyDrw(14)) ' Tepsa MyDrw(14)
        Me.txtMovilGerFinanciero.Text = IIf(IsDBNull(MyDrw(15)) = True, "", MyDrw(15)) ' Tepsa  MyDrw(15)
        Me.txtEncargadoPagos.Text = IIf(IsDBNull(MyDrw(17)) = True, "", MyDrw(17)) ' Tepsa  MyDrw(17)
        Me.txtEmailEncPagos.Text = IIf(IsDBNull(MyDrw(18)) = True, "", MyDrw(18)) ' Tepsa  MyDrw(18)
        Me.txtTelefonoEncPagos.Text = IIf(IsDBNull(MyDrw(19)) = True, "", MyDrw(19)) ' Tepsa MyDrw(19)
        Me.txtMovilEncPagos.Text = IIf(IsDBNull(MyDrw(20)) = True, "", MyDrw(20)) ' Tepsa  MyDrw(20)
        Me.txtPersonaContacto.Text = IIf(IsDBNull(MyDrw(21)) = True, "", MyDrw(21)) ' Tepsa MyDrw(21)
        Me.txtEmailPersonaContacto.Text = IIf(IsDBNull(MyDrw(22)) = True, "", MyDrw(22)) ' Tepsa MyDrw(22)
        Me.txtTelefonoPersonaContacto.Text = IIf(IsDBNull(MyDrw(23)) = True, "", MyDrw(23)) ' Tepsa MyDrw(23)
        Me.txtMovilPersonaContacto.Text = IIf(IsDBNull(MyDrw(24)) = True, "", MyDrw(24)) ' Tepsa MyDrw(24)

        'Dim MyDrwPagos As DataRow = dtConsideracionePago.Rows(0)

        Me.dgv4.Text = IIf(IsDBNull(MyDrw(35)) = True, "", MyDrw(35)) ' Tepsa MyDrw(35)
        Me.cmbCondicionPago.SelectedValue = MyDrw(26)
        Me.dtpDias.SelectedItem = MyDrw(27)
        Me.dtpHoraInicio.Text = IIf(IsDBNull(MyDrw(32)) = True, "", MyDrw(32)) ' Tepsa MyDrw(32)
        Me.dtpHoraFin.Text = IIf(IsDBNull(MyDrw(33)) = True, "", MyDrw(33)) ' Tepsa MyDrw(33)
        If IIf(IsDBNull(MyDrw(28)) = True, 0, MyDrw(28)) = 0 Then
            'MessageBox.Show("Igual a Cero")
            Me.rdbSemanal.Checked = True
        ElseIf IIf(IsDBNull(MyDrw(28)) = True, 0, MyDrw(28)) <> 0 Then
            'MessageBox.Show("Deferente a Cero")
            Me.rdbMensual.Checked = True
        End If

        'If MyDrw(28) <> 0 Then     Tepsa 
        If IIf(IsDBNull(MyDrw(28)) = True, 0, MyDrw(28)) <> 0 Then
            Me.dtpA.Value = (MyDrw(28) & "/01/1900 04:52:43 p.m.")
            Me.dtpA.Enabled = True
            Me.chkYA.Enabled = False
        ElseIf IIf(IsDBNull(MyDrw(28)) = True, 0, MyDrw(28)) = 0 Then
            Me.dtpA.Enabled = False
        End If
        If IIf(IsDBNull(MyDrw(29)) = True, 0, MyDrw(29)) <> 0 Then
            Me.dtpB.Value = (MyDrw(29) & "/01/1900 04:52:43 p.m.")
            Me.dtpB.Enabled = True
        ElseIf IIf(IsDBNull(MyDrw(29)) = True, 0, MyDrw(29)) = 0 Then
            Me.dtpB.Enabled = False
        End If
        If IIf(IsDBNull(MyDrw(30)) = True, 0, MyDrw(30)) <> 0 Then
            Me.dtpC.Value = (MyDrw(30) & "/01/1900 04:52:43 p.m.")
            Me.dtpC.Enabled = True
        ElseIf IIf(IsDBNull(MyDrw(30)) = True, 0, MyDrw(30)) = 0 Then
            Me.dtpC.Enabled = False
        End If
        If IIf(IsDBNull(MyDrw(31)) = True, 0, MyDrw(31)) <> 0 Then
            Me.dtpD.Value = (MyDrw(31) & "/01/1900 04:52:43 p.m.")
            Me.dtpD.Enabled = True
        ElseIf IIf(IsDBNull(MyDrw(31)) = True, 0, MyDrw(31)) = 0 Then
            Me.dtpD.Enabled = False
        End If

        'ActivaCamposCtaCte(Me.txtCreditoSolicitado, Me.txtNroSolicitud, Me.txtTelefonoDireccionLegal, Me.txtFaxDireccionLegal, Me.txtEmailRepLegal, Me.txtTelefonoRepLegal, Me.txtMovilRepLegal, Me.txtGerenteFinanciero, Me.txtEmailGerFinanciero, Me.txtTelefonoGerFinanciero, Me.txtMovilGerFinanciero, Me.txtEncargadoPagos, Me.txtEmailEncPagos, Me.txtTelefonoEncPagos, Me.txtMovilEncPagos, Me.txtPersonaContacto, Me.txtEmailPersonaContacto, Me.txtTelefonoPersonaContacto, Me.txtMovilPersonaContacto)

        dgv1.Columns.Clear()
        Call CargaDatosProveedores(False, True, True)
        dgv5.Columns.Clear()
        Call CargaDatosCliente(False, True, True)
        dgv6.Columns.Clear()

        'datahelper
        'Carga de Data Generica
        'Dim rstRutas As ADODB.Recordset = Funciones.CargaRecorsetCtaCte(Me.lblIDSolicitudCredito.Text)
        'Dim rstDocumentos As ADODB.Recordset = rstRutas.NextRecordset
        'Dim daCreacion As New OleDbDataAdapter
        'dtRutas.Clear()
        'dtDocumentos.Clear()
        'daCreacion.Fill(dtRutas, rstRutas)
        'daCreacion.Fill(dtDocumentos, rstDocumentos)
        Dim rstrutas As DataSet = Funciones.CargaRecorsetCtaCte(Me.lblIDSolicitudCredito.Text)
        dtRutas = rstrutas.Tables(0)
        dtDocumentos = rstrutas.Tables(1)

        Call GeneraGrillaRutas()
        Call GeneraGrillaDocumentos()

        Call CargaDestinosViaje(False, False, False)
        dgv2.Columns.Clear()
        Call CargaReferenciabancaria(False, True, True)
        dgv3.Columns.Clear()
        Call CargaDocumentos(False, False, False)

        Me.gruCtaCteFinal.Enabled = True

    End Sub

    Private Sub LLenaCamposAprobacion()
        Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
        'txtNroSolicitud.Text = CType(dgvr.Cells("NRO_SOLICITUD").Value, String)
        txtFuncionarioActual.Text = CType(dgvr.Cells("FUNCIONARIO").Value, String)
        txtCodigoCliente.Text = CType(dgvr.Cells("CODIGO").Value, String)
        txtNombreCliente.Text = CType(dgvr.Cells("RAZONSOCIAL").Value, String)
        txtRepresentanteLegal.Text = CType(dgvr.Cells("REPRESENTANTE_LEGAL").Value, String)

        'datahelper
        'Dim rstDirecciones As ADODB.Recordset
        'Dim rstRubro As ADODB.Recordset
        'Dim da As New OleDbDataAdapter
        'Dim dtDirecciones As New DataTable
        'Dim dtRubro As New DataTable
        'rstDirecciones = Funciones.LeerDireccionRubro(txtCodigoCliente.Text)
        'rstRubro = rstDirecciones.NextRecordset
        'rstCodicionPago = rstDirecciones.NextRecordset
        'da.Fill(dtDirecciones, rstDirecciones)
        'da.Fill(dtRubro, rstRubro)
        'da.Fill(dtCondicionPago, rstCodicionPago)
        Dim ds As DataSet = Funciones.LeerDireccionRubro(txtCodigoCliente.Text)
        Dim dtDirecciones As DataTable = ds.Tables(0)
        Dim dtRubro As DataTable = ds.Tables(1)
        dtCondicionPago = ds.Tables(2)

        dvCondicionPago = Funciones.CargarCombo(Me.cmbCondicionPago, dtCondicionPago, "CONDICION", "IDCONDICION_PLAZO", 1)
        If dtDirecciones.Rows.Count = 0 Then
            txtDireccionLegal.Text = ""
            txtGiroNegocio.Text = ""
        ElseIf dtDirecciones.Rows.Count = 1 Then
            txtDireccionLegal.Text = dtDirecciones.Rows(0)(0)
            txtGiroNegocio.Text = dtRubro.Rows(0)(0)
        Else
            txtDireccionLegal.Text = ""
            txtGiroNegocio.Text = ""
        End If

        MenuTab.Items(0).Enabled = False
        MenuTab.Items(1).Enabled = True
        MenuTab.Items(2).Enabled = True
        MenuTab.Items(3).Enabled = True
        MenuTab.Items(4).Enabled = True
        Me.SplitContainer2.Panel1Collapsed = True
        SelectMenu(1)
        NuevoToolStripMenuItem.Enabled = False
        EdicionToolStripMenuItem.Enabled = False
        CancelarToolStripmenuItem.Enabled = True
        CancelarToolStripmenuItem.Visible = True
        GrabarToolStripMenuItem.Enabled = False 'Colocar en todos los formualrios esto, luego de dshabilitarlos.
        EliminarToolStripMenuItem.Enabled = False
        ExportarToolStripMenuItem.Enabled = False
        ImprimirToolStripMenuItem.Enabled = False


        Dim MyDrw As DataRow = dtDatosSolicitud.Rows(0)

        Me.txtCreditoSolicitado.Text = Format(Math.Round(Convert.ToDouble(MyDrw(25)), 2), "#########0.00")
        Me.txtNroSolicitud.Text = MyDrw(4)
        Me.txtTelefonoDireccionLegal.Text = IIf(IsDBNull(MyDrw(6)) = True, "", MyDrw(6)) ' Tepsa MyDrw(6)
        Me.txtFaxDireccionLegal.Text = IIf(IsDBNull(MyDrw(7)) = True, "", MyDrw(7)) ' Tepsa MyDrw(7)
        Me.txtEmailRepLegal.Text = IIf(IsDBNull(MyDrw(9)) = True, "", MyDrw(9)) ' Tepsa MyDrw(9)
        Me.txtTelefonoRepLegal.Text = IIf(IsDBNull(MyDrw(10)) = True, "", MyDrw(10)) ' Tepsa MyDrw(10)
        Me.txtMovilRepLegal.Text = IIf(IsDBNull(MyDrw(11)) = True, "", MyDrw(11)) ' Tepsa  MyDrw(11)
        Me.txtGerenteFinanciero.Text = IIf(IsDBNull(MyDrw(12)) = True, "", MyDrw(12)) ' Tepsa  MyDrw(12)
        Me.txtEmailGerFinanciero.Text = IIf(IsDBNull(MyDrw(13)) = True, "", MyDrw(13)) ' Tepsa  MyDrw(13)
        Me.txtTelefonoGerFinanciero.Text = IIf(IsDBNull(MyDrw(14)) = True, "", MyDrw(14)) ' Tepsa  MyDrw(14)
        Me.txtMovilGerFinanciero.Text = IIf(IsDBNull(MyDrw(15)) = True, "", MyDrw(15)) ' Tepsa MyDrw(15)
        Me.txtEncargadoPagos.Text = IIf(IsDBNull(MyDrw(17)) = True, "", MyDrw(17)) ' Tepsa MyDrw(17)
        Me.txtEmailEncPagos.Text = IIf(IsDBNull(MyDrw(18)) = True, "", MyDrw(18)) ' Tepsa MyDrw(18)
        Me.txtTelefonoEncPagos.Text = IIf(IsDBNull(MyDrw(19)) = True, "", MyDrw(19)) ' Tepsa MyDrw(19)
        Me.txtMovilEncPagos.Text = IIf(IsDBNull(MyDrw(20)) = True, "", MyDrw(20)) ' Tepsa MyDrw(20)
        Me.txtPersonaContacto.Text = IIf(IsDBNull(MyDrw(21)) = True, "", MyDrw(21)) ' Tepsa MyDrw(21)
        Me.txtEmailPersonaContacto.Text = IIf(IsDBNull(MyDrw(22)) = True, "", MyDrw(22)) ' Tepsa MyDrw(22)
        Me.txtTelefonoPersonaContacto.Text = IIf(IsDBNull(MyDrw(23)) = True, "", MyDrw(23)) ' Tepsa MyDrw(23)
        Me.txtMovilPersonaContacto.Text = IIf(IsDBNull(MyDrw(24)) = True, "", MyDrw(24)) ' Tepsa MyDrw(24)

        'Dim MyDrwPagos As DataRow = dtConsideracionePago.Rows(0)

        Me.dgv4.Text = IIf(IsDBNull(MyDrw(35)) = True, "", MyDrw(35))
        Me.cmbCondicionPago.SelectedValue = MyDrw(26)
        Me.dtpDias.SelectedItem = MyDrw(27)
        Me.dtpHoraInicio.Text = IIf(IsDBNull(MyDrw(32)) = True, "", MyDrw(32)) 'MyDrw(32)
        Me.dtpHoraFin.Text = IIf(IsDBNull(MyDrw(33)) = True, "", MyDrw(33))  'MyDrw(33)
        If IIf(IsDBNull(MyDrw(28)) = True, 0, MyDrw(28)) = 0 Then
            'MessageBox.Show("Igual a Cero")
            Me.rdbSemanal.Checked = True
        ElseIf IIf(IsDBNull(MyDrw(28)) = True, 0, MyDrw(28)) <> 0 Then
            'MessageBox.Show("Deferente a Cero")
            Me.rdbMensual.Checked = True
        End If

        If IIf(IsDBNull(MyDrw(28)) = True, 0, MyDrw(28)) <> 0 Then
            Me.dtpA.Value = (MyDrw(28) & "/01/1900 04:52:43 p.m.")
            Me.dtpA.Enabled = True
            Me.chkYA.Enabled = False
        ElseIf IIf(IsDBNull(MyDrw(28)) = True, 0, MyDrw(28)) = 0 Then
            Me.dtpA.Enabled = False
        End If
        If IIf(IsDBNull(MyDrw(29)) = True, 0, MyDrw(29)) <> 0 Then
            Me.dtpB.Value = (MyDrw(29) & "/01/1900 04:52:43 p.m.")
            Me.dtpB.Enabled = True
        ElseIf IIf(IsDBNull(MyDrw(29)) = True, 0, MyDrw(29)) = 0 Then
            Me.dtpB.Enabled = False
        End If
        If IIf(IsDBNull(MyDrw(30)) = True, 0, MyDrw(30)) <> 0 Then
            Me.dtpC.Value = (MyDrw(30) & "/01/1900 04:52:43 p.m.")
            Me.dtpC.Enabled = True
        ElseIf IIf(IsDBNull(MyDrw(30)) = True, 0, MyDrw(30)) = 0 Then
            Me.dtpC.Enabled = False
        End If
        If IIf(IsDBNull(MyDrw(31)) = True, 0, MyDrw(31)) <> 0 Then
            Me.dtpD.Value = (MyDrw(31) & "/01/1900 04:52:43 p.m.")
            Me.dtpD.Enabled = True
        ElseIf IIf(IsDBNull(MyDrw(31)) = True, 0, MyDrw(31)) = 0 Then
            Me.dtpD.Enabled = False
        End If

        DesactivaCamposCtaCte(Me.txtCreditoSolicitado, Me.txtNroSolicitud, Me.txtTelefonoDireccionLegal, Me.txtFaxDireccionLegal, Me.txtEmailRepLegal, Me.txtTelefonoRepLegal, Me.txtMovilRepLegal, Me.txtGerenteFinanciero, Me.txtEmailGerFinanciero, Me.txtTelefonoGerFinanciero, Me.txtMovilGerFinanciero, Me.txtEncargadoPagos, Me.txtEmailEncPagos, Me.txtTelefonoEncPagos, Me.txtMovilEncPagos, Me.txtPersonaContacto, Me.txtEmailPersonaContacto, Me.txtTelefonoPersonaContacto, Me.txtMovilPersonaContacto)

        dgv1.Columns.Clear()
        Call CargaDatosProveedores(True, False, False)
        dgv5.Columns.Clear()
        Call CargaDatosCliente(True, False, False)
        dgv6.Columns.Clear()
        Call CargaDestinosViaje(True, False, False)
        dgv2.Columns.Clear()
        Call CargaReferenciabancaria(True, False, False)
        dgv3.Columns.Clear()
        Call CargaDocumentos(True, False, False)

        Me.gruCtaCteFinal.Enabled = True

    End Sub

    Private Sub CreaGrillaProveedores()
        Me.dgv1.Columns.Clear()
        Me.dgv1.Columns.Add("PROVEEDOR", "PROVEEDOR")
        Me.dgv1.Columns.Add("TELEFONO", "TELEFONO")
        Me.dgv1.Columns.Add("CONTACTO", "CONTACTO")
        dgv1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        dgv1.Font = New Font("Arial", 8.0!, FontStyle.Regular)
        dgv1.AllowUserToOrderColumns = True
        dgv1.AllowUserToDeleteRows = True
        dgv1.AllowUserToAddRows = True
        dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv1.RowHeadersVisible = True
        dgv1.ReadOnly = False
    End Sub

    Private Sub CreaGrillaClientes()
        Me.dgv5.Columns.Clear()
        Me.dgv5.Columns.Add("CLIENTE", "CLIENTE")
        Me.dgv5.Columns.Add("TELEFONO", "TELEFONO")
        Me.dgv5.Columns.Add("CONTACTO", "CONTACTO")
        dgv5.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv5.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv5.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv5.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        dgv5.Font = New Font("Arial", 8.0!, FontStyle.Regular)
        dgv5.AllowUserToOrderColumns = True
        dgv5.AllowUserToDeleteRows = True
        dgv5.AllowUserToAddRows = True
        dgv5.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv5.RowHeadersVisible = True
        dgv5.ReadOnly = False
    End Sub

    Private Sub CreaGrillaBancos()
        Me.dgv2.Columns.Clear()
        Me.dgv2.Columns.Add("BANCO", "BANCO")
        Me.dgv2.Columns.Add("CTACTE", "CUENTA CORRIENTE")
        Me.dgv2.Columns.Add("TELEFONOS", "TELEFONO")
        Me.dgv2.Columns.Add("SECTORISTA", "SECTORISTA")
        dgv2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv2.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv2.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv2.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        dgv2.Font = New Font("Arial", 8.0!, FontStyle.Regular)
        dgv2.AllowUserToOrderColumns = True
        dgv2.AllowUserToDeleteRows = True
        dgv2.AllowUserToAddRows = True
        dgv2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv2.RowHeadersVisible = True
        dgv2.ReadOnly = False
    End Sub


    Private Sub chkSoloPendientes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSoloPendientes.CheckedChanged
        If Not dvListaClientes Is Nothing Then
            'If sender.checked = True Then
            '    Dim FiltroLista As String = "APROBADO ='" & 0 & "'"
            '    dvListaClientes.RowFilter = FiltroLista
            'ElseIf sender.checked = False Then
            '    Dim FiltroLista As String = "APROBADO = 1 or APROBADO = 0"
            '    dvListaClientes.RowFilter = FiltroLista
            'End If

            'If MyRol = 15 Then 'Creditos --> Muestra todos los clientes con Solicitud Pendiente
            'bloque
            If Acceso.SiRol(G_Rol, Me, 5) Then
                If sender.checked = True Then
                    Dim FiltroLista As String = "APROBADO ='" & 0 & "'"
                    dvListaClientes.RowFilter = FiltroLista
                ElseIf sender.checked = False Then
                    Dim FiltroLista As String = "APROBADO = 1 or APROBADO = 0"
                    dvListaClientes.RowFilter = FiltroLista
                End If
            End If

        End If
    End Sub

    Private Sub rdbDenegado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDenegado.CheckedChanged
        Try
            If Len(Trim(txtCreditoAsignado.Text)) <> 0 And Len(Trim(txtSobregiroFinal.Text)) <> 0 Then
                If sender.checked = True Then
                    Dim resp As DialogResult = MessageBox.Show("¿Esta seguro de Inactivar esta Linea de Credito?", "Seguridad del Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If resp = Windows.Forms.DialogResult.Yes Then
                        'datahelper
                        'Dim respta As ADODB.Recordset
                        'Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INACTIVA_CTACTE", 14, Me.txtCodigoCliente.Text, 2, MyUsuario, 1, MyRol, 1, MyIP, 2, CType(Me.txtIDAprobacion.Text, Integer), 1}
                        'respta = VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
                        'MessageBox.Show(respta.Fields.Item(0).Value.ToString)

                        Dim respta As DataTable
                        Dim obj As New dtoCLIENTES
                        respta = obj.INACTIVA_CTACTE(Me.txtCodigoCliente.Text, MyUsuario, MyRol, MyIP, CType(Me.txtIDAprobacion.Text, Integer))
                        MessageBox.Show(respta.Rows(0).Item(0).ToString)

                        'respta = VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
                        'MessageBox.Show(respta.Fields.Item(0).Value.ToString)

                    End If
                ElseIf sender.checked = False Then

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub btnrefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefrescar.Click
        ' Funcion creado por Tepsa 
        Try
            Dim l_idpersona As Integer
            '
            btnultimo.Enabled = True
            btnprimero.Enabled = True
            vNroPagina = 1
            If dtDatosSolicitud.Rows.Count > 0 Then
                ' If IsDBNull(dtDatosSolicitud.Rows(0)(1)) = True Then
                l_idpersona = CType(dtDatosSolicitud.Rows(0)(1), Integer)
                var_idpersona = CType(dtDatosSolicitud.Rows(0)(1), Integer)
                '
                Formato_GridView(Me.DGVconsultactacte)

                ModControlCtaCtePersona.fnESTADO_CTACTE_PERSONA(Me.DGVconsultactacte, l_idpersona, 1, Int(txtTANPAG.Text), Me.txtNroPAG, Me.txtNroREG)

                txtsaldoactual.Text = CType(IIf(IsDBNull(Me.DGVconsultactacte.Rows(0).Cells(5).Value) = True, 0, Me.DGVconsultactacte.Rows(0).Cells(5).Value), String)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub MenuAprobar_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MenuAprobar.Opening

    End Sub
    Private Sub btnprimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprimero.Click
        Try
            vNroPagina = 1
            ModControlCtaCtePersona.fnESTADO_CTACTE_PERSONA(Me.DGVconsultactacte, var_idpersona, vNroPagina, Int(txtTANPAG.Text), Me.txtNroPAG, Me.txtNroREG)
            'txtNroREG.Text = DGVconsultactacte.RowCount
            txtnropagina.Text = vNroPagina
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnultimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnultimo.Click
        Try
            vNroPagina = Int(txtNroPAG.Text)
            ModControlCtaCtePersona.fnESTADO_CTACTE_PERSONA(Me.DGVconsultactacte, var_idpersona, vNroPagina, Int(txtTANPAG.Text), Me.txtNroPAG, Me.txtNroREG)
            'Me.txtNroREG.Text = Me.DGVconsultactacte.RowCount
            Me.txtnropagina.Text = vNroPagina
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnant.Click
        Try
            vNroPagina = vNroPagina - 1
            If vNroPagina < 1 Then
                vNroPagina = 1
            End If
            ModControlCtaCtePersona.fnESTADO_CTACTE_PERSONA(Me.DGVconsultactacte, var_idpersona, vNroPagina, Int(txtTANPAG.Text), Me.txtNroPAG, Me.txtNroREG)
            txtnropagina.Text = vNroPagina
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnsig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsig.Click
        Try
            vNroPagina = vNroPagina + 1
            If txtNroPAG.Text <> "" Then
                If vNroPagina > Int(txtNroPAG.Text) Then
                    vNroPagina = Int(txtNroPAG.Text)
                End If
            End If
            ModControlCtaCtePersona.fnESTADO_CTACTE_PERSONA(Me.DGVconsultactacte, var_idpersona, vNroPagina, Int(txtTANPAG.Text), Me.txtNroPAG, Me.txtNroREG)
            txtnropagina.Text = vNroPagina
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AccionesAprobacion()
        Try
            If Me.DataGridLista.RowCount > 0 Then
                Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow
                Dim ds As DataSet = Funciones.CargaDataSolicitud(CType(dgvr.Cells("CODIGO").Value, String))

                Dim dtEstado As New DataTable
                dtDatosSolicitud = ds.Tables(0)
                dtProveedoresSolicitud = ds.Tables(1)
                dtClientesSolicitud = ds.Tables(2)
                dtDestinosViaje = ds.Tables(3)
                dtReferenciaBancaria = ds.Tables(4)
                dtDocumentosRecibidos = ds.Tables(5)
                dtEstado = ds.Tables(6)

                'If dtEstado.Rows.Count = 0 Then 'El Cliente si presento una Solicitud.
                If IsDBNull(dtEstado.Rows(0).Item(0)) Then
                    Call LLenaCamposAprobacion()
                ElseIf dtEstado.Rows.Count <> 0 Then 'El Cliente no Presento Ninguna Solicitud.
                    MessageBox.Show(dtEstado.Rows(0)(0), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If


                'Dim rstDatosSolicitud As ADODB.Recordset
                'Dim rstProveedoresSolicitud As ADODB.Recordset
                'Dim rstClientesSolicitud As ADODB.Recordset
                'Dim rstDestinosViaje As ADODB.Recordset
                'Dim rstReferenciaBancaria As ADODB.Recordset
                'Dim rstDocumentosRecibidos As ADODB.Recordset
                'Dim rstEstado As ADODB.Recordset
                'Dim dtEstado As New DataTable

                'Dim ds As DataSet = Funciones.CargaDataSolicitud(CType(dgvr.Cells("CODIGO").Value, String))
                'rstDatosSolicitud = ds.Tables(0)
                'rstProveedoresSolicitud = rstDatosSolicitud.NextRecordset
                'rstClientesSolicitud = rstDatosSolicitud.NextRecordset
                'rstDestinosViaje = rstDatosSolicitud.NextRecordset
                'rstReferenciaBancaria = rstDatosSolicitud.NextRecordset
                'rstDocumentosRecibidos = rstDatosSolicitud.NextRecordset
                'rstEstado = rstDatosSolicitud.NextRecordset

                'dtDatosSolicitud.Clear()
                'dtProveedoresSolicitud.Clear()
                'dtClientesSolicitud.Clear()
                'dtDestinosViaje.Clear()
                'dtReferenciaBancaria.Clear()
                'dtDocumentosRecibidos.Clear()
                'dtEstado.Clear()

                'Dim MyAdaptador As New OleDbDataAdapter
                'MyAdaptador.Fill(dtDatosSolicitud, rstDatosSolicitud)
                'MyAdaptador.Fill(dtProveedoresSolicitud, rstProveedoresSolicitud)
                'MyAdaptador.Fill(dtClientesSolicitud, rstClientesSolicitud)
                'MyAdaptador.Fill(dtDestinosViaje, rstDestinosViaje)
                'MyAdaptador.Fill(dtReferenciaBancaria, rstReferenciaBancaria)
                'MyAdaptador.Fill(dtDocumentosRecibidos, rstDocumentosRecibidos)
                'MyAdaptador.Fill(dtEstado, rstEstado)

                'If dtEstado.Rows.Count = 0 Then 'El Cliente si presento una Solicitud.
                'Call LLenaCamposAprobacion()
                'ElseIf dtEstado.Rows.Count <> 0 Then 'El Cliente no Presento Ninguna Solicitud.
                'MessageBox.Show(dtEstado.Rows(0)(0), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged, GrabarToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
