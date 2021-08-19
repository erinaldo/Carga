'Imports System.Data
'Imports System.Data.OleDb
'Imports AccesoDatos

Public Class FrmAsociacionGuiasEnvio
    Public hnd As Long
    ' Variable implementadas por tepsa  
    Dim OBJGENERAL As New ClsLbTepsa.dtoGENERAL
    Dim OBJPERSONA As New ClsLbTepsa.dtoPersona
    Dim OBJCONTACTO_PERSONA As New ClsLbTepsa.dtoCONTACTO_PERSONA
    Dim OBJDIRECCION_CONSIGNADO As New ClsLbTepsa.dtoDIRECCION_CONSIGNADO
    Dim OBJCOMUNICACION_CONTACO As New ClsLbTepsa.dtoCOMUNICACION_CONTACO

    Dim ObjPRE_GUIAS As New ClsLbTepsa.dtoPRE_GUIAS

    'DECLARACIONES DE AutoCompleteStringCollection
    Private iWinPersona As New AutoCompleteStringCollection
    Private iWin_L_CONTACTO_PERSONA_RP As New AutoCompleteStringCollection
    Private iWin_L_CONTACTO_PERSONA_R As New AutoCompleteStringCollection
    Private iWin_L_CONTACTO_PERSONA_D As New AutoCompleteStringCollection
    Private iWin_L_DIECCION_CONSIGNADO_RP As New AutoCompleteStringCollection
    Private iWin_L_DIECCION_CONSIGNADO_D As New AutoCompleteStringCollection
    Private iWin_L_Comunicacion_Contacto_RP As New AutoCompleteStringCollection
    Private iWin_L_Comunicacion_Contacto_D As New AutoCompleteStringCollection
    Private iWin_L_UNIDAD_AGENCIA_O As New AutoCompleteStringCollection
    Private iWin_L_UNIDAD_AGENCIA_D As New AutoCompleteStringCollection

    'DECLARACION DE DATA VIEWS
    Dim dvlistar_forma_pago As New DataView
    Dim dvPERSONA As New DataView
    Dim dvCENTRO_COSTO As New DataView
    Dim dv_L_CONTACTO_PERSONA_RP As New DataView
    Dim dv_L_CONTACTO_PERSONA_R As New DataView
    Dim dv_L_CONTACTO_PERSONA_D As New DataView
    Dim dv_L_DIECCION_CONSIGNADO_RP As New DataView
    Dim dv_L_DIECCION_CONSIGNADO_D As New DataView
    Dim dv_L_Comunicacion_Contacto_RP As New DataView
    Dim dv_L_Comunicacion_Contacto_R As New DataView
    Dim dv_L_Comunicacion_Contacto_D As New DataView
    Private DV_L_UNIDAD_AGENCIA_O As New DataView
    Private DV_L_UNIDAD_AGENCIA_D As New DataView
    Private dvTIPO_ENTREGA As New DataView

    'DECLARACION DE DATA COLLECTIONS
    Private COLLPERSONA As New Collection
    Dim COLL_L_CONTACTO_PERSONA_RP As New Collection
    Dim COLL_L_CONTACTO_PERSONA_R As New Collection
    Dim COLL_L_CONTACTO_PERSONA_D As New Collection
    Dim COLL_L_DIECCION_CONSIGNADO_RP As New Collection
    Dim COLL_L_DIECCION_CONSIGNADO_D As New Collection
    Dim coll_L_Comunicacion_Contacto_RP As New Collection
    Dim coll_L_Comunicacion_Contacto_D As New Collection
    Private COLL_L_UNIDAD_AGENCIA_O As New Collection
    Private COLL_L_UNIDAD_AGENCIA_D As New Collection
    Dim DtPreGuias As New DataTable
    Dim DVPreGuias As New DataView
    'Dim da As New OleDbDataAdapter
    Dim PAGI_SELEC As Integer
    ' Fin Tepsa 
    Dim vAccionRegistro As Integer

    'Dim rstRoles As ADODB.Recordset
    'Dim rstUsuarioRoles As ADODB.Recordset
    Dim dtUsuarioRoles As New DataTable
    Dim dvListaClientes As DataView 'Que se llena por la devolucion de la Funcion CargarGrillaCliente
    Dim dtSubCuenta As New DataTable
    Dim dvSubCuenta As DataView

    Dim dsDetalleGuias As New DataSet
    Dim dtDetalleGuiias As New DataTable("DETALLE")
    Dim dvDetalleGuias As DataView

    Dim dtGuiasKardex As New DataTable
    Dim dvGuiasKardex As New DataView

    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean

    Dim dtContacto, dtContactoParalelo, dtRemitente, dtRemitenteParalelo, dtDireccion As DataTable
    Dim Ciudad As Integer = 0
    Dim obj As New dtoVentaCargaContado
    Public objGuiaEnvio As New dtoGuiaEnvio
    Dim dsContacto As DataSet

    Private Sub FrmAsociacionGuiasEnvio_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmAsociacionGuiasEnvio_ClickTabPage3() Handles Me.ClickTabPage3
        SelectMenu(2)
    End Sub

    Private Sub FrmAsociacionGuiasEnvio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ShadowLabel1.Text = "Asociación Guias Envio a Clientes"
            MenuTab.Items(0).Text = "LISTA CLIENTES"
            MenuTab.Items(1).Text = "GUIAS DE ENVIO"
            MenuTab.Items(3).Text = "GUIAS MASIVA"
            MenuTab.Items(4).Text = "IMPRIMIR GUIAS MASIVA"

            HabilitarMenu(MenuTab)
            MenuTab.Items(0).Enabled = True
            MenuTab.Items(1).Enabled = False
            MenuTab.Items(2).Enabled = False
            MenuTab.Items(3).Enabled = False  'TEsd
            MenuTab.Items(4).Enabled = False


            Me.txtCodigoCLienteGuias.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            Me.txtNombreClienteGuias.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            Me.txtNumInicial.Text = ""
            Me.txtNumFinal.Text = ""
            Me.lblIDEntrega.Text = ""
            ' 
            ' Pasando las variables globales a funciones del formulario - Tepsa 
            MyUsuario = dtoUSUARIOS.IdLogin
            MyRol = dtoUSUARIOS.IdRol
            MyIP = dtoUSUARIOS.IP
            '
            If MyRol <> 11 Then '(32) Supervisor de funcionario de negocios 
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
            '
            'CargarLista()
            'dvListaClientes = Funciones.CargarGrillaClientes(Me.DataGridLista)

            Call GeneraGrillaDetalle()

            If DataGridLista.RowCount > 0 Then
                DataGridLista.Columns(0).ReadOnly = True
                DataGridLista.Columns(5).Visible = False
                DataGridLista.Columns(6).Visible = False
            End If
            vAccionRegistro = 0
            Me.rdbJuridicos.Checked = True

            ' Tepsa - Inicial 
            OBJPERSONA.CODIGO_CLIENTE = "NULL"
            OBJPERSONA.IDTIPO_PERSONA = 0
            OBJPERSONA.IDPERSONA = 0

            'datahelper
            'dvPERSONA = OBJPERSONA.FNLISTAR_PERSONA(VOCONTROLUSUARIO, OBJPERSONA.IDTIPO_PERSONA, OBJPERSONA.IDPERSONA, OBJPERSONA.CODIGO_CLIENTE)
            dvPERSONA = OBJPERSONA.FNLISTAR_PERSONA(OBJPERSONA.IDTIPO_PERSONA, OBJPERSONA.IDPERSONA, OBJPERSONA.CODIGO_CLIENTE)

            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            ObjProcesos.fnCargar_iWin_r(Me.TXTIDPERSONA, dvPERSONA, COLLPERSONA, iWinPersona, 0)
            ''Mod.17/09/2009 -->Omendoza - Pasando al datahelper   
            'OBJGENERAL.fnlistar_forma_pago(dvlistar_forma_pago, Me.CBIDFORMA_PAGO, VOCONTROLUSUARIO)
            OBJGENERAL.fnlistar_forma_pago(dvlistar_forma_pago, Me.CBIDFORMA_PAGO)
            '
            Me.CBIDFORMA_PAGO.SelectedValue = 2
            'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
            OBJGENERAL.fn_L_TIPO_ENTREGA(dvTIPO_ENTREGA, Me.cmbTipo_Entrega)
            '
            'datahelper
            'Me.DV_L_UNIDAD_AGENCIA_O = OBJGENERAL.FN_L_UNIDAD_agencia_ok(VOCONTROLUSUARIO)
            Me.DV_L_UNIDAD_AGENCIA_O = OBJGENERAL.FN_L_UNIDAD_agencia_OK()
            ObjProcesos.fnCargar_iWin_r(Me.TXTIDUNIDAD_AGENCIA_O, Me.DV_L_UNIDAD_AGENCIA_O, Me.COLL_L_UNIDAD_AGENCIA_O, Me.iWin_L_UNIDAD_AGENCIA_O, 0)

            Me.DV_L_UNIDAD_AGENCIA_D = OBJGENERAL.FN_L_UNIDAD_agencia_OK()
            ObjProcesos.fnCargar_iWin_r(Me.TXTIDUNIDAD_AGENCIA_D, Me.DV_L_UNIDAD_AGENCIA_D, Me.COLL_L_UNIDAD_AGENCIA_D, Me.iWin_L_UNIDAD_AGENCIA_D, 0)

            ' Tepsa - final  

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FrmAsociacionGuiasEnvio_MenuCancelar() Handles Me.MenuCancelar
        Me.lblIDEntrega.Text = ""

        Call AccionesGrabar()
        vAccionRegistro = 0

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

    Private Sub FrmAsociacionGuiasEnvio_MenuEditar() Handles Me.MenuEditar
        Try
            vAccionRegistro = 2
            If IsNothing(DataGridLista.CurrentCell) Then
                MsgBox("Seleccine un cliente", MsgBoxStyle.Information, "Seguridad del Sistema")
                Exit Sub
            End If
            Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
            txtCodigoCLienteGuias.Text = CType(dgvr.Cells("CODIGO").Value, String)
            txtNombreClienteGuias.Text = CType(dgvr.Cells("RAZONSOCIAL").Value, String)
            MenuTab.Items(0).Enabled = False
            MenuTab.Items(1).Enabled = True
            MenuTab.Items(2).Enabled = True
            MenuTab.Items(3).Enabled = True
            MenuTab.Items(4).Enabled = True
            '
            SplitContainer2.Panel1Collapsed = True
            SelectMenu(1)
            'datahelper
            'Dim da As New OleDbDataAdapter
            'Dim rstSubCuentas As ADODB.Recordset
            'rstSubCuentas = Funciones.SubCuentasCliente(txtCodigoCLienteGuias.Text)
            'dtSubCuenta.Clear()
            'da.Fill(dtSubCuenta, rstSubCuentas)
            'dvSubCuenta = Funciones.CargarCombo(cmbAreaEmpresa, dtSubCuenta, "CENTRO_COSTO", "IDCENTRO_COSTO")

            Dim rstSubCuentas As DataTable
            rstSubCuentas = Funciones.SubCuentasCliente(txtCodigoCLienteGuias.Text)
            dtSubCuenta.Clear()
            dtSubCuenta = rstSubCuentas
            dvSubCuenta = Funciones.CargarCombo(cmbAreaEmpresa, dtSubCuenta, "CENTRO_COSTO", "IDCENTRO_COSTO")

            'datahelper
            'Dim Lista As ADODB.Recordset
            'dtGuiasKardex.Clear()
            'Lista = Funciones.ListaGuiasEnvio(Me.txtCodigoCLienteGuias.Text)
            'da.Fill(dtGuiasKardex, Lista)
            'dgvKardexGuias.Columns.Clear()
            'dvGuiasKardex = New DataView
            'dvGuiasKardex = dtGuiasKardex.DefaultView

            Dim Lista As DataTable
            dtGuiasKardex.Clear()
            Lista = Funciones.ListaGuiasEnvio(Me.txtCodigoCLienteGuias.Text)
            'da.Fill(dtGuiasKardex, Lista)
            dtGuiasKardex = Lista
            dgvKardexGuias.Columns.Clear()
            dvGuiasKardex = New DataView
            dvGuiasKardex = dtGuiasKardex.DefaultView

            Call GeneraGrillaKardex()

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
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmAsociacionGuiasEnvio_MenuGrabar() Handles Me.MenuGrabar
        Dim Insertar As Boolean = True
        Try
            If PAGI_SELEC = 3 Then
                If Validar() = False Then Exit Sub
                With ObjPRE_GUIAS
                    Dim IndexWin_Perso As Integer = iWinPersona.IndexOf(TXTIDPERSONA.Text)

                    .IDPERSONA = Int(COLLPERSONA.Item(iWinPersona.IndexOf(Me.TXTIDPERSONA.Text).ToString))

                    If CHKIDUNIDAD_AGENCIA_O.Checked = True Then
                        .IDAGENCIAS_ORI = Int(COLL_L_UNIDAD_AGENCIA_O.Item(Me.iWin_L_UNIDAD_AGENCIA_O.IndexOf(TXTIDUNIDAD_AGENCIA_O.Text).ToString))
                    Else
                        .IDAGENCIAS_ORI = 0
                    End If

                    If CHKIDUNIDAD_AGENCIA_D.Checked = True Then
                        .IDAGENCIAS_DESTI = Int(COLL_L_UNIDAD_AGENCIA_D.Item(iWin_L_UNIDAD_AGENCIA_D.IndexOf(TXTIDUNIDAD_AGENCIA_D.Text).ToString))
                    Else
                        .IDAGENCIAS_DESTI = 0
                    End If

                    If Me.CHKTipo_Entrega.Checked = True Then
                        .IDTIPO_ENTREGA_CARGA = Me.cmbTipo_Entrega.SelectedValue
                    Else
                        .IDTIPO_ENTREGA_CARGA = 0
                    End If

                    If Me.CHKIDFORMA_PAGO.Checked = True Then
                        .IDFORMA_PAGO = Me.CBIDFORMA_PAGO.SelectedValue
                    Else
                        .IDFORMA_PAGO = 0
                    End If

                    If Me.CHKIDCENTRO_COSTO.Checked = True Then
                        .IDCENTRO_COSTO = Me.CBIDCENTRO_COSTO.SelectedValue
                    Else
                        .IDCENTRO_COSTO = 0
                    End If

                    'If CHKIDCONTACTO_PERSONA_RP.Checked Then
                    .ID_REMITENTE = Convert.ToInt32(dtRemitente.Rows(CboRemitente.SelectedIndex).Item("idcontacto_persona").ToString)
                    'Else
                    '    .ID_REMITENTE = 0
                    'End If



                    'Try
                    '    If CHKIDDIRECCION_CONSIGNADO_RP.Checked Then
                    .IDDIRECCION_REMITENTE = Convert.ToInt32(dtdireccion.Rows(CboDireccion.SelectedIndex).Item("iddireccion_consignado").ToString)
                    .DIRECCION_REMITENTE = CboDireccion.Text
                    '    Else
                    '        .IDDIRECCION_REMITENTE = 0
                    '        .DIRECCION_REMITENTE = 0
                    '    End If
                    'Catch
                    '    .IDDIRECCION_REMITENTE = 0
                    '    .DIRECCION_REMITENTE = Me.TXTIDDIRECCION_CONSIGNADO_RP.Text
                    'End Try




                    'If CHKIDCOMUNICACION_CONTACTO_RP.Checked Then
                    '    .idcomunicacion_remitente = Int(Me.coll_L_Comunicacion_Contacto_RP.Item(Me.iWin_L_Comunicacion_Contacto_RP.IndexOf(Me.TXTIDCOMUNICACION_CONTACTO_RP.Text).ToString))
                    'Else
                    '    .idcomunicacion_remitente = 0
                    'End If



                    'Try
                    '    If CHKIDCONTACTO_PERSONA_REMITENTE.Checked Then
                    .IDCONTACTO_REMITENTE = Convert.ToInt32(dtContacto.Rows(CboContacto.SelectedIndex).Item("idcontacto_persona").ToString)
                    .CONTACTO_REMITENTE = CboContacto.Text
                    '    Else
                    '        .IDCONTACTO_REMITENTE = 0
                    '        .CONTACTO_REMITENTE = 0
                    '    End If
                    'Catch
                    '    .IDCONTACTO_REMITENTE = 0
                    '    .CONTACTO_REMITENTE = Me.TXTIDCONTACTO_PERSONA_REMITENTE.Text
                    'End Try




                    'Try
                    '    If CHKIDCONTACTO_PERSONA_DESTINATARIO.Checked Then
                    .IDCONTACTO_DESTINATARIO = 0
                    '        .CONTACTO_DESTINATARIO = Me.TXTIDCONTACTO_PERSONA_DESTINATARIO.Text
                    '    Else
                    '        .IDCONTACTO_DESTINATARIO = 0
                    '        .CONTACTO_DESTINATARIO = 0
                    '    End If
                    'Catch
                    '    .IDCONTACTO_DESTINATARIO = 0
                    '    .CONTACTO_DESTINATARIO = Me.TXTIDCONTACTO_PERSONA_DESTINATARIO.Text
                    'End Try


                    'Try
                    '    If CHKIDDIRECCION_CONSIGNADO_D.Checked Then
                    .IDDIRECCION_DESTINATARIO = 0
                    '        .DIRECCION_DESTINATARIO = Me.TXTIDDIRECCION_CONSIGNADO_D.Text
                    '    Else
                    '        .IDDIRECCION_DESTINATARIO = 0
                    '        .DIRECCION_DESTINATARIO = 0
                    '    End If
                    'Catch
                    '    .IDDIRECCION_DESTINATARIO = 0
                    '    .DIRECCION_DESTINATARIO = Me.TXTIDDIRECCION_CONSIGNADO_D.Text
                    'End Try


                    'If CHKIDCOMUNICACION_CONTACTO_D.Checked Then
                    .idcomunicacion_destinatario = 0
                    'Else
                    '    .idcomunicacion_destinatario = 0
                    'End If


                    .IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                    .IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                    .IDROL = dtoUSUARIOS.IdRol
                    .IP = dtoUSUARIOS.m_sIP
                    .NRO_GUIA_INI = Me.TBNRO_GUIA_INI.Text
                    .NRO_GUIA_FINAL = Me.TBNRO_GUIA_FINAL.Text
                    .ULTI_NRO_GUIA_IMPRESO = 0

                    'datahelper
                    'If .fnINSERTAR_GUIAS_PRE_IMPRESAS(VOCONTROLUSUARIO) = True Then
                    If .fnINSERTAR_GUIAS_PRE_IMPRESAS() = True Then
                        MsgBox("Los datos se ingresaron correctamente...", MsgBoxStyle.Information, "Seguridad del sistema")
                    End If
                End With
            Else

                If Me.dgvDetalleGuias.RowCount > 0 Then
                    If vAccionRegistro = 1 Then
                        '   
                        For i As Integer = 0 To Me.dgvKardexGuias.RowCount - 1
                            If Me.cmbAreaEmpresa.Text = Me.dgvKardexGuias.Rows(i).Cells("CENTRO_COSTO").Value And Me.dgvKardexGuias.Rows(i).Cells("CANT_PENDIENTE").Value = 0 Then
                                Insertar = False
                                Exit For
                            Else
                                Insertar = True
                                Exit For
                            End If
                        Next
                        If Insertar = False Then
                            MessageBox.Show("Aun hay guias de envio en la Sub Cuenta: " & Me.cmbAreaEmpresa.Text, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ElseIf Insertar = True Then
                            Call GrabaEntrega()
                            Me.lblIDEntrega.Text = "0"
                        End If
                    End If

                    If vAccionRegistro = 2 Then
                        Call GrabaEntrega()
                        Me.lblIDEntrega.Text = "0"
                    End If

                Else
                    MessageBox.Show("Agregue Rangos de Numeración para la Sub Cuenta de Este Cliente", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If


        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub FrmAsociacionGuiasEnvio_MenuImprimir() Handles Me.MenuImprimir

        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport

        Dim OBJVALIDA As New ClsLbTepsa.dtoValida
        If dgv1.RowCount <= 0 Then
            MsgBox("No existen elementos en la lista", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Sub
        End If

        If OBJVALIDA.TXT_NUMERO_ENTERO(Me.TBNRO_GUIA_INI_IMPRI, Me) = False Then Exit Sub
        If OBJVALIDA.TXT_NUMERO_ENTERO(Me.TBNRO_GUIA_FINAL_IMPRI, Me) = False Then Exit Sub

        If CType(TBNRO_GUIA_INI_IMPRI.Text, Long) > CType(TBNRO_GUIA_FINAL_IMPRI.Text, Long) Then
            MsgBox("El número inicial no puede ser mayor que la final", MsgBoxStyle.Information, "Seguridad del sistema")
            TBNRO_GUIA_INI_IMPRI.Focus()
            Exit Sub
        End If
        If CType(TBNRO_GUIA_INI_IMPRI.Text, Long) < CType(DVPreGuias.Table.Rows(dgv1.CurrentCell.RowIndex)("NRO_GUIA_INI"), Long) Then
            MsgBox("El número inicial esta fuera del rango", MsgBoxStyle.Information, "Seguridad del sistema")
            TBNRO_GUIA_INI_IMPRI.Focus()
            Exit Sub
        End If
        If CType(TBNRO_GUIA_FINAL_IMPRI.Text, Long) > CType(DVPreGuias.Table.Rows(dgv1.CurrentCell.RowIndex)("NRO_GUIA_FINAL"), Long) Then
            MsgBox("El número final esta fuera del rango", MsgBoxStyle.Information, "Seguridad del sistema")
            TBNRO_GUIA_FINAL_IMPRI.Focus()
            Exit Sub
        End If

        Try
            If PAGI_SELEC = 5 Then

                If VALIDAR_IMPRE_PRE_GUIAS() = False Then Exit Sub


                ObjPRE_GUIAS.IDPRE_GUIA = Int(DVPreGuias.Table.Rows(dgv1.CurrentCell.RowIndex)("idpre_guia"))


                ObjReport.rutaRpt = PathFrmReport
                ObjReport.conectar(rptservice, rptuser, rptpass)
                ObjReport.printrpt(True, "", "PG001.RPT", "P_IDPRE_GUIA;" & ObjPRE_GUIAS.IDPRE_GUIA, _
                "P_NRO_GUIA_INI;" & CType(Me.TBNRO_GUIA_INI_IMPRI.Text, Long), _
                "P_NRO_GUIA_FINAL;" & CType(Me.TBNRO_GUIA_FINAL_IMPRI.Text, Long))

            Else
                Dim a As New ClsPrint
                a.Titulo = "CLIENTES CARGA"
                a.DGV = Me.DataGridLista
                Dim MyReport As New Reportes
                'MyReport.MdiParent = FrmContenedor
                MyReport.MdiParent = Principal   'Tepsa 
                MyReport.pd.Document = a
                MyReport.pd.Dock = DockStyle.Fill
                MyReport.WindowState = FormWindowState.Maximized
                'FrmContenedor.SplitContainer1.Panel2.Controls.Add(MyReport)
                'Principal.Panel1.Controls.Add(MyReport)
                ' 
                MyReport.Show()
                MyReport.BringToFront()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad de Sitema")
        End Try
    End Sub

    Private Sub FrmAsociacionGuiasEnvio_MenuNuevo() Handles Me.MenuNuevo
        Try
            If DataGridLista.RowCount > 0 Then
                Me.lblIDEntrega.Text = ""

                Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
                If Not dgvr Is Nothing Then
                    txtCodigoCLienteGuias.Text = CType(dgvr.Cells("CODIGO").Value, String)
                    txtNombreClienteGuias.Text = CType(dgvr.Cells("RAZONSOCIAL").Value, String)
                    MenuTab.Items(0).Enabled = False
                    MenuTab.Items(1).Enabled = True
                    MenuTab.Items(2).Enabled = True
                    SplitContainer2.Panel1Collapsed = True
                    SelectMenu(1)

                    'datahelper
                    'Dim rstSubCuentas As ADODB.Recordset
                    'rstSubCuentas = Funciones.SubCuentasCliente(txtCodigoCLienteGuias.Text)
                    'Dim da As New OleDbDataAdapter
                    'dtSubCuenta.Clear()
                    'da.Fill(dtSubCuenta, rstSubCuentas)
                    'dvSubCuenta = Funciones.CargarCombo(cmbAreaEmpresa, dtSubCuenta, "CENTRO_COSTO", "IDCENTRO_COSTO")

                    Dim rstSubCuentas As DataTable
                    rstSubCuentas = Funciones.SubCuentasCliente(txtCodigoCLienteGuias.Text)
                    dtSubCuenta.Clear()
                    dtSubCuenta = rstSubCuentas
                    dvSubCuenta = Funciones.CargarCombo(cmbAreaEmpresa, dtSubCuenta, "CENTRO_COSTO", "IDCENTRO_COSTO")

                    'datahelper
                    'Dim Lista As ADODB.Recordset
                    'dtGuiasKardex.Clear()
                    'Lista = Funciones.ListaGuiasEnvio(Me.txtCodigoCLienteGuias.Text)
                    'da.Fill(dtGuiasKardex, Lista)
                    'dgvKardexGuias.Columns.Clear()
                    'dvGuiasKardex = New DataView
                    'dvGuiasKardex = dtGuiasKardex.DefaultView

                    Dim Lista As DataTable
                    dtGuiasKardex.Clear()
                    Lista = Funciones.ListaGuiasEnvio(Me.txtCodigoCLienteGuias.Text)
                    'da.Fill(dtGuiasKardex, Lista)
                    dtGuiasKardex = Lista
                    dgvKardexGuias.Columns.Clear()
                    dvGuiasKardex = New DataView
                    dvGuiasKardex = dtGuiasKardex.DefaultView

                    Call GeneraGrillaKardex()
                    vAccionRegistro = 1

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
                    MessageBox.Show("Seleccione a un Cliente de la Grilla.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Seleccione a un Funcionario y luego a un Cliente de la Grilla.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridLista.DoubleClick
        Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
        txtCodigoCLienteGuias.Text = CType(dgvr.Cells("CODIGO").Value, String)
        txtNombreClienteGuias.Text = CType(dgvr.Cells("RAZONSOCIAL").Value, String)
        MenuTab.Items(0).Enabled = False
        MenuTab.Items(1).Enabled = True
        MenuTab.Items(2).Enabled = True
        SplitContainer2.Panel1Collapsed = True
        SelectMenu(1)
    End Sub
    Private Function validar_rangos() As Boolean
        Dim obj As New ClsLbTepsa.dtoValida
        validar_rangos = False
        If obj.TXT_NUMERO_ENTERO(txtNumInicial, Me) = False Then Exit Function
        If obj.TXT_NUMERO_ENTERO(txtNumFinal, Me) = False Then Exit Function
        validar_rangos = True
    End Function
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Try
            If validar_rangos() = False Then Exit Sub
            If vAccionRegistro = 1 Then 'Insercion
                If CType(txtNumInicial.Text, Long) <> 0 And CType(txtNumFinal.Text, Long) <> 0 Then
                    If CType(txtNumInicial.Text, Long) <> CType(txtNumFinal.Text, Long) Then
                        If CType(txtNumInicial.Text, Long) < CType(txtNumFinal.Text, Long) Then
                            If ValidaRangos(CType(txtNumInicial.Text, Long), CType(txtNumFinal.Text, Long)) = True Then
                                MessageBox.Show("Uno de los Rangos, ya esta asociado a una Sub Cuenta.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ElseIf BuscaAsociacion() = False Then
                                Dim drwGuias As DataRow
                                drwGuias = dtDetalleGuiias.NewRow
                                drwGuias(0) = dtDetalleGuiias.Rows.Count + 1
                                drwGuias(1) = Me.cmbAreaEmpresa.SelectedValue
                                drwGuias(2) = Me.cmbAreaEmpresa.Text
                                drwGuias(3) = CType(txtNumInicial.Text, Long)
                                drwGuias(4) = CType(txtNumFinal.Text, Long)
                                dtDetalleGuiias.Rows.Add(drwGuias)
                            End If
                        Else
                            MessageBox.Show("El Número Final tiene que ser mayor que el Número Inicial.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("Los rangos de numeracion no pueden ser iguales.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Ingrese el rango de numeracion de las Guias de Envio", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            ElseIf vAccionRegistro = 2 Then 'Actualizacion

                Dim drwGuias As DataRow
                drwGuias = dtDetalleGuiias.NewRow
                drwGuias(0) = dtDetalleGuiias.Rows.Count + 1
                drwGuias(1) = Me.cmbAreaEmpresa.SelectedValue
                drwGuias(2) = Me.cmbAreaEmpresa.Text
                drwGuias(3) = CType(txtNumInicial.Text, Long)
                drwGuias(4) = CType(txtNumFinal.Text, Long)
                dtDetalleGuiias.Rows.Add(drwGuias)

                Dim drwKardex As DataRow
                drwKardex = dtGuiasKardex.Rows(Me.dgvKardexGuias.CurrentRow.Index)
                drwKardex(3) = cmbAreaEmpresa.SelectedValue
                drwKardex(4) = cmbAreaEmpresa.Text
                drwKardex(5) = CType(txtNumInicial.Text, Long)
                drwKardex(6) = CType(txtNumFinal.Text, Long)



            End If
        Catch Qex As Data.DataException
            MessageBox.Show("Esta Sub Cuenta ya contiene un rango de Guias de Envio", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch Pex As Exception
            MessageBox.Show(Pex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvDetalleGuias_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalleGuias.DoubleClick
        'txtNumInicial.Value
        Dim dgvr As DataGridViewRow = Me.dgvDetalleGuias.CurrentRow()
        txtNumInicial.Text = CType(dgvr.Cells("NUMERO INICIAL").Value, Long)
        txtNumFinal.Text = CType(dgvr.Cells("NUMERO FINAL").Value, Long)
        cmbAreaEmpresa.SelectedValue = CType(dgvr.Cells("IDSUBCUENTA").Value, Integer)
    End Sub

    Private Sub dgvDetalleGuias_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalleGuias.SelectionChanged
        Try
            If dgvDetalleGuias.Rows.Count <> 1 Then
                Dim dgvr As DataGridViewRow = Me.dgvDetalleGuias.CurrentRow()
                txtNumInicial.Text = CType(dgvr.Cells("NUMERO INICIAL").Value, Long)
                txtNumFinal.Text = CType(dgvr.Cells("NUMERO FINAL").Value, Long)
                cmbAreaEmpresa.SelectedValue = CType(dgvr.Cells("IDSUBCUENTA").Value, Integer)
            End If
        Catch Pex As System.NullReferenceException
            'MessageBox.Show(Pex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region " FUNCIONES A NIVEL DEL FORMULARIO "

    ''' <summary>
    ''' Genera la Grilla donde se haran las Inserciones de las Guias. 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneraGrillaDetalle()
        Try
            dtDetalleGuiias = dsDetalleGuias.Tables.Add
            With dtDetalleGuiias
                .Columns.Add("ORDEN", Type.GetType("System.Int16"))
                .Columns.Add("IDSUBCUENTA", Type.GetType("System.Int16"))
                .Columns.Add("SUB CUENTA", Type.GetType("System.String"))
                .Columns.Add("NUMERO INICIAL", Type.GetType("System.Int64"))
                .Columns.Add("NUMERO FINAL", Type.GetType("System.Int64"))
            End With

            With dsDetalleGuias.Tables(0)
                .PrimaryKey = New DataColumn() {.Columns("SUB CUENTA")}
            End With

            dvDetalleGuias = dtDetalleGuiias.DefaultView
            dgvDetalleGuias.DataSource = dvDetalleGuias

            With dgvDetalleGuias
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = True
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = dvDetalleGuias
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .Font = New System.Drawing.Font("Arial", 8.0!, FontStyle.Regular)
                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .VirtualMode = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 15
                .Columns("ORDEN").Width = 50
                .Columns("IDSUBCUENTA").Width = 50
                .Columns("IDSUBCUENTA").Visible = False
                .Columns("ORDEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("SUB CUENTA").Width = 340
                .Columns("NUMERO INICIAL").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("NUMERO FINAL").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Funcion que graba directamente en Oracle dependiendo de las filas insertadas.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GrabaEntrega()
        Dim MyEntrega As New dtoENTREGA_GUIAS_ENVIO
        For i As Integer = 0 To Me.dgvDetalleGuias.RowCount - 1
            Dim dgvr As DataGridViewRow = Me.dgvDetalleGuias.Rows(i)
            With MyEntrega
                .Control = vAccionRegistro
                If vAccionRegistro = 1 Then
                    .IDEntregaGuiasEnvio = 1 'Momentaneamente hasta hacer las actualizaciones.
                ElseIf vAccionRegistro = 2 Then
                    .IDEntregaGuiasEnvio = Me.dvGuiasKardex.Table.Rows(Me.dgvKardexGuias.CurrentRow.Index)("IDENTREGA_GUIAS_ENVIO")
                End If
                .CodigoPersona = Me.txtCodigoCLienteGuias.Text
                .IDCentroCosto = CType(dgvr.Cells("IDSUBCUENTA").Value, Long) 'Me.cmbAreaEmpresa.SelectedValue
                .Serie = 1
                .NroInicial = CType(dgvr.Cells("NUMERO INICIAL").Value, Long) 'Me.txtNumInicial.Value
                .NroFinal = CType(dgvr.Cells("NUMERO FINAL").Value, Long) 'Me.txtNumFinal.Value
                .IDUsuarioPersonal = MyUsuario
                .IDRolUsuario = MyRol
                .IP = MyIP
            End With


            'datahelper
            'Dim RespEntrega As ADODB.Recordset
            'RespEntrega = MyEntrega.GrabaEntregaGuias()
            'If RespEntrega.Fields.Count = 1 Then 'Se realizo Correctamente.
            '    MessageBox.Show(RespEntrega.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'ElseIf RespEntrega.Fields.Count = 2 And Len(Trim(RespEntrega.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
            '    MessageBox.Show("Descripción: " & RespEntrega.Fields(1).Value, "ORACLE -> Error: " & RespEntrega.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

            Dim RespEntrega As DataTable = MyEntrega.GrabaEntregaGuias()
            If RespEntrega.Rows.Count = 1 Then 'Se realizo Correctamente.
                MessageBox.Show(RespEntrega.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf RespEntrega.Rows.Count = 2 And Len(Trim(RespEntrega.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                MessageBox.Show("Descripción: " & RespEntrega.Rows(0).Item(1).ToString, "ORACLE -> Error: " & RespEntrega.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Next
        Call AccionesGrabar()
    End Sub


#End Region

    Private Sub FrmAsociacionGuiasEnvio_MenuSalir() Handles Me.MenuSalir
        Me.Close()
    End Sub

    Private Sub MyTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyTreeView.AfterSelect
        For i As Integer = 0 To MyTreeView.Nodes(0).Nodes.Count - 1
            MyTreeView.Nodes(0).Nodes(i).Checked = False
        Next
        e.Node.Checked = True
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
                Dim DTListaClientes As New DataTable
                DataGridLista.DataSource = Nothing
                For i As Integer = 0 To MyTreeView.Nodes(0).Nodes.Count - 1
                    If MyTreeView.Nodes(0).Nodes(i).Checked = True Then
                        DataGridLista.Columns.Clear()
                        'dvListaClientes = Funciones.CargarGrillaClientes(Me.DataGridLista, MyTreeView.Nodes(0).Nodes(i).Text)
                        dvListaClientes = CargarGrillaClientes_(Me.DataGridLista, MyTreeView.Nodes(0).Nodes(i).Tag, DTListaClientes)
                        'dvListaClientes = Funciones.CargarGrillaClientes(Me.DataGridLista)
                        'Dim FiltroLista As String = "IDTIPO_PERSONA ='" & 1 & "'"
                        'dvListaClientes.RowFilter = FiltroLista

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
        If IsNothing(dvListaClientes) Then Exit Sub
        If IsNothing(dvListaClientes.Table.TableName) Then Exit Sub
        If rdbJuridicos.Checked = True Then
            Dim FiltroLista As String = "IDTIPO_PERSONA = 1 and RAZON_SOCIAL LIKE '%" & Me.txtBusqueda.Text & "%'"
            dvListaClientes.RowFilter = FiltroLista
        End If
        If rdbnaturales.Checked = True Then
            Dim FiltroLista As String = "IDTIPO_PERSONA = 2 and NOMNRES_APELLIDOS LIKE '%" & Me.txtBusqueda.Text & "%'"
            dvListaClientes.RowFilter = FiltroLista
        End If
        If rdbTodos.Checked = True Then
            Dim FiltroLista As String = "(IDTIPO_PERSONA = 1 or IDTIPO_PERSONA = 2) and CODIGO_CLIENTE LIKE '%" & Me.txtBusqueda.Text & "%'"
            dvListaClientes.RowFilter = FiltroLista
        End If
    End Sub

    Private Sub DataGridLista_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridLista.CellClick
        If e.ColumnIndex = 2 Then
            Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
        End If

    End Sub

    Private Function ValidaRangos(ByVal NumInicial As Integer, ByVal NumFinal As Integer) As Integer
        Dim YaExiste As Boolean
        Dim YaExiste1 As Boolean
        Dim YaExiste2 As Boolean
        Dim YaExiste3 As Boolean
        Dim YaExiste4 As Boolean

        If Me.dgvDetalleGuias.RowCount > 0 Then
            For i As Integer = 0 To Me.dgvDetalleGuias.RowCount - 1
                Dim dgvr As DataGridViewRow = Me.dgvDetalleGuias.Rows(i)

                If (NumInicial = dgvr.Cells(3).Value Or NumInicial = dgvr.Cells(4).Value) Then
                    YaExiste1 = True
                End If
                If (NumFinal = dgvr.Cells(3).Value Or NumFinal = dgvr.Cells(4).Value) Then
                    YaExiste2 = True
                End If

                If (NumInicial > dgvr.Cells(3).Value And NumInicial < dgvr.Cells(4).Value) Then
                    YaExiste3 = True
                End If
                If (NumFinal > dgvr.Cells(3).Value And NumFinal < dgvr.Cells(4).Value) Then
                    YaExiste4 = True
                End If
            Next
            If YaExiste1 Or YaExiste2 Or YaExiste3 Or YaExiste4 Then
                YaExiste = True
            End If
        End If

        Return YaExiste
    End Function

    Private Function BuscaAsociacion() As Boolean
        Dim YaEstaAsociado As Boolean
        'datahelper
        'Dim Mybusqueda As ADODB.Recordset
        'Mybusqueda = Funciones.BuscaGuias(CType(txtNumInicial.Text, Integer), CType(txtNumFinal.Text, Integer))
        'If Mybusqueda.Fields.Count > 0 Then
        '    If Len(Trim(Mybusqueda.Fields.Item(0).Value)) <> 0 Then
        '        MessageBox.Show(Mybusqueda.Fields.Item(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        YaEstaAsociado = True
        '    ElseIf Len(Trim(Mybusqueda.Fields.Item(0).Value)) <> 0 Then
        '        YaEstaAsociado = False
        '    End If
        'End If
        Dim Mybusqueda As DataTable
        Mybusqueda = Funciones.BuscaGuias(CType(txtNumInicial.Text, Integer), CType(txtNumFinal.Text, Integer))
        If Mybusqueda.Rows.Count > 0 Then
            If Len(Trim(Mybusqueda.Rows(0).Item(0).ToString)) <> 0 Then
                MessageBox.Show(Mybusqueda.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                YaEstaAsociado = True
            ElseIf Len(Trim(Mybusqueda.Rows(0).Item(0).ToString)) <> 0 Then
                YaEstaAsociado = False
            End If
        End If

        Return YaEstaAsociado
    End Function

    Private Sub AccionesGrabar()
        Me.txtNumInicial.Text = ""
        Me.txtNumFinal.Text = ""
        dtDetalleGuiias.Clear()
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

    Private Sub GeneraGrillaKardex()
        With dgvKardexGuias
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = Me.dvGuiasKardex
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .HeaderText = "ORDEN"
            .Name = "ORDEN"
            .DataPropertyName = "ORDEN"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = "IDENTREGA_GUIAS_ENVIO"
            .Name = "IDENTREGA_GUIAS_ENVIO"
            .DataPropertyName = "IDENTREGA_GUIAS_ENVIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "IDPERSONA"
            .Name = "IDPERSONA"
            .DataPropertyName = "IDPERSONA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "IDCENTRO_COSTO"
            .Name = "IDCENTRO_COSTO"
            .DataPropertyName = "IDCENTRO_COSTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .HeaderText = "CENTRO_COSTO"
            .Name = "CENTRO_COSTO"
            .DataPropertyName = "CENTRO_COSTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .HeaderText = "NRO_INICIAL"
            .Name = "NRO_INICIAL"
            .DataPropertyName = "NRO_INICIAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .HeaderText = "NRO_FINAL"
            .Name = "NRO_FINAL"
            .DataPropertyName = "NRO_FINAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .HeaderText = "CANT_USADA"
            .Name = "CANT_USADA"
            .DataPropertyName = "CANT_USADA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col8 As New DataGridViewTextBoxColumn
        With col8
            .HeaderText = "CANT_PENDIENTE"
            .Name = "CANT_PENDIENTE"
            .DataPropertyName = "CANT_PENDIENTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        dgvKardexGuias.Columns.AddRange(col0, col1, col2, col3, col4, col5, col6, col7, col8)
        dgvKardexGuias.Columns(1).Visible = False
        dgvKardexGuias.Columns(2).Visible = False
        dgvKardexGuias.Columns(3).Visible = False

    End Sub

    Private Sub ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarToolStripMenuItem.Click
        Dim dgvr As DataGridViewRow = Me.dgvKardexGuias.CurrentRow()
        cmbAreaEmpresa.SelectedValue = CType(dgvr.Cells("IDCENTRO_COSTO").Value, Integer)
        Me.txtNumInicial.Text = CType(dgvr.Cells("NRO_INICIAL").Value, Integer)
        Me.txtNumFinal.Text = CType(dgvr.Cells("NRO_FINAL").Value, Integer)
        'cmbAreaEmpresa.Enabled = False
        lblIDEntrega.Text = CType(dgvr.Cells("IDENTREGA_GUIAS_ENVIO").Value, Integer)
    End Sub

    Private Sub txtNumInicialA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumInicial.TextChanged
        Try
            If Len(Trim(txtNumInicial.Text)) <> 0 Then
                Dim dgvr As DataGridViewRow = Me.dgvDetalleGuias.CurrentRow()
                If dgvDetalleGuias.Rows.Count <> 0 Then
                    If CType(dgvr.Cells("IDSUBCUENTA").Value, String) = cmbAreaEmpresa.SelectedValue Then
                        dtDetalleGuiias.Rows(dgvr.Index)(3) = CType(txtNumInicial.Text, Integer)
                    Else

                    End If
                End If
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtNumFinalB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumFinal.TextChanged
        Try
            If Len(Trim(txtNumFinal.Text)) <> 0 Then
                Dim dgvr As DataGridViewRow = Me.dgvDetalleGuias.CurrentRow()
                If dgvDetalleGuias.Rows.Count <> 0 Then
                    If CType(dgvr.Cells("IDSUBCUENTA").Value, String) = cmbAreaEmpresa.SelectedValue Then
                        dtDetalleGuiias.Rows(dgvr.Index)(4) = CType(txtNumFinal.Text, Integer)
                    Else

                    End If
                End If
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtNumInicialA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumInicial.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtNumFinalB_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumFinal.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    

    Private Sub MOSTRAR_CONTACTO_PERSONA()
        ' Procedimiento implementado por Tepsa 
        Try
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos

            OBJCONTACTO_PERSONA.IDPERSONA = Int(COLLPERSONA.Item(iWinPersona.IndexOf(Me.TXTIDPERSONA.Text).ToString))

            ''REMITENTE PRINCIPAL
            'dv_L_CONTACTO_PERSONA_RP = OBJCONTACTO_PERSONA.FN_L_CONTACTO_PERSONA_RP(OBJCONTACTO_PERSONA.IDPERSONA)
            'ObjProcesos.fnCargar_iWin_r(Me.TXTIDCONTACTO_PERSONA_RP, dv_L_CONTACTO_PERSONA_RP, COLL_L_CONTACTO_PERSONA_RP, iWin_L_CONTACTO_PERSONA_RP, 0)

            ''REMITENTE
            'dv_L_CONTACTO_PERSONA_R = OBJCONTACTO_PERSONA.FN_L_CONTACTO_PERSONA_R(OBJCONTACTO_PERSONA.IDPERSONA)
            'ObjProcesos.fnCargar_iWin_r(Me.TXTIDCONTACTO_PERSONA_REMITENTE, dv_L_CONTACTO_PERSONA_R, COLL_L_CONTACTO_PERSONA_R, iWin_L_CONTACTO_PERSONA_R, 0)

            ''DESINATARIO
            'dv_L_CONTACTO_PERSONA_D = OBJCONTACTO_PERSONA.FN_L_CONTACTO_PERSONA_D(OBJCONTACTO_PERSONA.IDPERSONA)
            'ObjProcesos.fnCargar_iWin_r(Me.TXTIDCONTACTO_PERSONA_DESTINATARIO, dv_L_CONTACTO_PERSONA_D, COLL_L_CONTACTO_PERSONA_D, iWin_L_CONTACTO_PERSONA_D, 0)

            ''DIRECCIONES
            'dv_L_DIECCION_CONSIGNADO_RP = OBJDIRECCION_CONSIGNADO.FN_L_DIECCION_CONSIGNADO_RP(OBJCONTACTO_PERSONA.IDPERSONA)
            'ObjProcesos.fnCargar_iWin_r(Me.TXTIDDIRECCION_CONSIGNADO_RP, dv_L_DIECCION_CONSIGNADO_RP, COLL_L_DIECCION_CONSIGNADO_RP, iWin_L_DIECCION_CONSIGNADO_RP, 0)

            'dv_L_DIECCION_CONSIGNADO_D = OBJDIRECCION_CONSIGNADO.FN_L_DIECCION_CONSIGNADO_D(OBJCONTACTO_PERSONA.IDPERSONA)
            'ObjProcesos.fnCargar_iWin_r(Me.TXTIDDIRECCION_CONSIGNADO_D, dv_L_DIECCION_CONSIGNADO_D, COLL_L_DIECCION_CONSIGNADO_D, iWin_L_DIECCION_CONSIGNADO_D, 0)

            'TELEFONOS

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub MOSTRAR_TELEFONOS_RP()
        ' Procedimiento implementado por Tepsa  
        Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        Try
            'If Not Me.iWin_L_CONTACTO_PERSONA_RP.IndexOf(Me.TXTIDCONTACTO_PERSONA_RP.Text) = -1 Then
            '    'datahelper
            '    'dv_L_Comunicacion_Contacto_RP = Me.OBJCOMUNICACION_CONTACO.FN_L_Comunicacion_Contacto_RP(VOCONTROLUSUARIO, Int(Me.COLL_L_CONTACTO_PERSONA_RP.Item(Me.iWin_L_CONTACTO_PERSONA_RP.IndexOf(Me.TXTIDCONTACTO_PERSONA_RP.Text).ToString)))
            '    dv_L_Comunicacion_Contacto_RP = Me.OBJCOMUNICACION_CONTACO.FN_L_Comunicacion_Contacto_RP(Int(Me.COLL_L_CONTACTO_PERSONA_RP.Item(Me.iWin_L_CONTACTO_PERSONA_RP.IndexOf(Me.TXTIDCONTACTO_PERSONA_RP.Text).ToString)))
            '    ObjProcesos.fnCargar_iWin_r(Me.TXTIDCOMUNICACION_CONTACTO_RP, dv_L_Comunicacion_Contacto_RP, coll_L_Comunicacion_Contacto_RP, iWin_L_Comunicacion_Contacto_RP, 0)
            'Else
            '    coll_L_Comunicacion_Contacto_RP = Nothing
            '    dv_L_Comunicacion_Contacto_RP = Nothing
            '    iWin_L_Comunicacion_Contacto_RP = Nothing
            'End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Function VALIDAR_IMPRE_PRE_GUIAS() As Boolean
        ' Implementado por Tepsa 
        VALIDAR_IMPRE_PRE_GUIAS = False

        If IsNothing(dgv1.DataSource) Then
            MsgBox("No existen elementos...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If dgv1.CurrentCell.RowIndex = -1 Then
            MsgBox("No existen elementos...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If

        VALIDAR_IMPRE_PRE_GUIAS = True
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Implementado por Te`sa 
        Try
            DVPreGuias = New DataView
            DtPreGuias = New DataTable
            If Me.iWinPersona.IndexOf(TXTIDPERSONA.Text) = -1 Then
                MsgBox("Seleccione un cliente", MsgBoxStyle.Information, "Seguridad del Sistema")
                Me.TabMante.SelectedIndex = 3
                Exit Sub
            End If
            '
            ObjPRE_GUIAS.IDPERSONA = Int(Me.COLLPERSONA.Item(Me.iWinPersona.IndexOf(Me.TXTIDPERSONA.Text).ToString))
            ObjPRE_GUIAS.FECHA_INI = Me.DTPFECHA_INICIO.Value.ToShortDateString
            ObjPRE_GUIAS.FECHA_FINAL = Me.DTPFECHA_FINAL.Value.ToShortDateString
            '
            'datahelper
            'If ObjPRE_GUIAS.fnlistar_Pre_guias(VOCONTROLUSUARIO) = True Then
            'da.Fill(Me.DtPreGuias, ObjPRE_GUIAS.cur_listar_pre_guias)
            'DVPreGuias = Me.DtPreGuias.DefaultView

            'Me.dgv1.DataSource = DVPreGuias
            'Call FORMATO_LISTA_PRE_GUIAS()
            'End If
            If ObjPRE_GUIAS.fnlistar_Pre_guias() = True Then
                'da.Fill(Me.DtPreGuias, ObjPRE_GUIAS.cur_listar_pre_guias)
                DVPreGuias = ObjPRE_GUIAS.cur_listar_pre_guias.Tables(0).DefaultView

                Me.dgv1.DataSource = DVPreGuias
                Call FORMATO_LISTA_PRE_GUIAS()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub
    Private Sub FORMATO_LISTA_PRE_GUIAS()
        With Me.dgv1
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            '.RowHeadersWidth = 30
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col0 As New DataGridViewCheckBoxColumn
        With col0
            .HeaderText = "¿ACTIVO?"
            .Name = "ACTIVO"
            .DataPropertyName = "IDESTADO_REGISTRO"
            .Width = 62
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Frozen = True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With
        'MyDataGridLista.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = "ID"
            .Name = "ID"
            .DataPropertyName = "IDPERSONA"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ToolTipText = "Identificador del cliente en la Base de Datos"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        End With
        'MyDataGridLista.Columns.Add(col1)

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "CODIGO"
            .Name = "CODIGO"
            .DataPropertyName = "CODIGO_CLIENTE"
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        End With
        'MyDataGridLista.Columns.Add(col2)
        Dim Col4 As New DataGridViewTextBoxColumn
        With Col4
            .HeaderText = "DOCUMENTO"
            .Name = "RUC"
            .DataPropertyName = "RUC"
            .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            .Width = 110
        End With
        dgv1.Columns.Add(Col4)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "RAZON SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .ToolTipText = "Razon Social para Personas Juridicos"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Width = 200
        End With
        dgv1.Columns.Add(col3)

        Dim Col13 As New DataGridViewTextBoxColumn
        With Col13
            .HeaderText = "F. REGISTRO"
            .Name = "FECHA_REGISTRO"
            .DataPropertyName = "FECHA_REGISTRO"
            '.ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            .Width = 60
        End With
        dgv1.Columns.Add(Col13)


        Dim Col5 As New DataGridViewTextBoxColumn
        With Col5
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            '.ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            .Width = 60
        End With
        dgv1.Columns.Add(Col5)

        Dim Col6 As New DataGridViewTextBoxColumn
        With Col6
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            '.ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            .Width = 60
        End With
        dgv1.Columns.Add(Col6)

        Dim Col7 As New DataGridViewTextBoxColumn
        With Col7
            .HeaderText = "FORMA PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            '.ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            .Width = 100
        End With
        dgv1.Columns.Add(Col7)

        Dim Col8 As New DataGridViewTextBoxColumn
        With Col8
            .HeaderText = "TIPO ENTREGA"
            .Name = "TIPO_ENTREGA"
            .DataPropertyName = "TIPO_ENTREGA"
            '.ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            .Width = 100
        End With
        dgv1.Columns.Add(Col8)

        Dim Col9 As New DataGridViewTextBoxColumn
        With Col9
            .HeaderText = "REMITENTE"
            .Name = "REMITENTE"
            .DataPropertyName = "REMITENTE"
            '.ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            .Width = 200
        End With
        dgv1.Columns.Add(Col9)

        Dim Col10 As New DataGridViewTextBoxColumn
        With Col10
            .HeaderText = "DESTINATARIO"
            .Name = "DESTINATARIO"
            .DataPropertyName = "DESTINATARIO"
            '.ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            .Width = 200
        End With
        dgv1.Columns.Add(Col10)

        Dim Col11 As New DataGridViewTextBoxColumn
        With Col11
            .HeaderText = "NRO. INICIAL"
            '.Name = "DESTINATARIO"
            .DataPropertyName = "nro_guia_ini"
            '.ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            .Width = 70
        End With
        dgv1.Columns.Add(Col11)

        Dim Col12 As New DataGridViewTextBoxColumn
        With Col12
            .HeaderText = "NRO. FINAL"
            '.Name = "DESTINATARIO"
            .DataPropertyName = "nro_guia_final"
            '.ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            .Width = 70
        End With
        dgv1.Columns.Add(Col12)
    End Sub
    Private Sub TabMante_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabMante.Selecting
        PAGI_SELEC = e.TabPageIndex
    End Sub
    Function Validar() As Boolean
        Dim ObjValida As New ClsLbTepsa.dtoValida
        Validar = False
        'If Not ((iWin_L_UNIDAD_AGENCIA_O.IndexOf(TXTIDUNIDAD_AGENCIA_O.Text) = -1) And (Me.iWin_L_UNIDAD_AGENCIA_D.IndexOf(TXTIDUNIDAD_AGENCIA_D.Text) = -1)) Then
        '    If iWin_L_UNIDAD_AGENCIA_O.IndexOf(TXTIDUNIDAD_AGENCIA_O.Text) = iWin_L_UNIDAD_AGENCIA_D.IndexOf(TXTIDUNIDAD_AGENCIA_D.Text) Then
        '        MsgBox("No Puede Realizar esta Operacion, Origen y destino idénticos ", MsgBoxStyle.Information, "Seguridad Sistema")
        '        Exit Function
        '    End If
        'End If

        If ObjValida.TXT_NUMERO_ENTERO(Me.TBNRO_GUIA_INI, Me) = False Then Exit Function
        If ObjValida.TXT_NUMERO_ENTERO(Me.TBNRO_GUIA_FINAL, Me) = False Then Exit Function

        If CType(TBNRO_GUIA_INI.Text, Long) > CType(TBNRO_GUIA_FINAL.Text, Long) Then
            MsgBox("El número inicial no puede ser mayor que la final", MsgBoxStyle.Information, "Seguridad del sistema")
            TBNRO_GUIA_INI.Focus()
            Exit Function
        End If
        If CHKIDUNIDAD_AGENCIA_O.Checked = True Then
            If Me.iWin_L_UNIDAD_AGENCIA_O.IndexOf(TXTIDUNIDAD_AGENCIA_O.Text) = -1 Then
                MsgBox("Si va a considerar en la impresion selecciona un elemento", MsgBoxStyle.Information, "Seguridad del Sistema")
                TXTIDUNIDAD_AGENCIA_O.Focus()
                Exit Function
            End If
        End If
        If CHKIDUNIDAD_AGENCIA_D.Checked = True Then
            If Me.iWin_L_UNIDAD_AGENCIA_D.IndexOf(TXTIDUNIDAD_AGENCIA_D.Text) = -1 Then
                MsgBox("Si va a considerar en la impresion selecciona un elemento", MsgBoxStyle.Information, "Seguridad del Sistema")
                TXTIDUNIDAD_AGENCIA_D.Focus()
                Exit Function
            End If
        End If
        If Me.CHKTipo_Entrega.Checked = True Then
            If ObjValida.CB_SELECT_VALUE(Me.cmbTipo_Entrega, Me) = False Then
                Exit Function
            End If
        End If
        'If Me.CHKIDFORMA_PAGO.Checked = True Then
        '    If ObjValida.CB_SELECT_VALUE(Me.CBIDFORMA_PAGO, Me) = False Then
        '        Exit Function
        '    End If
        'End If
        If Me.iWinPersona.IndexOf(TXTIDPERSONA.Text) = -1 Then
            MsgBox("Seleccione un elmento", MsgBoxStyle.Information, "Seguridad del Sistema")
            TXTIDPERSONA.Focus()
            Exit Function
        End If
        If Me.CHKIDCENTRO_COSTO.Checked = True Then
            If ObjValida.CB_SELECT_VALUE(Me.CBIDCENTRO_COSTO, Me) = False Then
                Exit Function
            End If
        End If

        If dtContacto.Rows.Count > 0 Then
            If (dtContacto.Rows(CboContacto.SelectedIndex)("nombres").ToString.Trim = "(SELECCIONE)") Then
                MsgBox("Seleccione la persona de contacto", MsgBoxStyle.Information, "Seguridad del Sistema")
                CboContacto.Focus()
                Exit Function
            End If
        End If

        If dtDireccion.Rows.Count > 0 Then
            If (dtDireccion.Rows(CboDireccion.SelectedIndex)("direccion").ToString.Trim = "(SELECCIONE)") Then
                MsgBox("Seleccione la dirección de contacto", MsgBoxStyle.Information, "Seguridad del Sistema")
                CboDireccion.Focus()
                Exit Function
            End If
        End If

        'If CHKIDDIRECCION_CONSIGNADO_RP.Checked Then
        '    If Me.iWin_L_DIECCION_CONSIGNADO_RP.IndexOf(TXTIDDIRECCION_CONSIGNADO_RP.Text) = -1 Then
        '        MsgBox("Seleccione un elmento", MsgBoxStyle.Information, "Seguridad del Sistema")
        '        TXTIDDIRECCION_CONSIGNADO_RP.Focus()
        '        Exit Function
        '    End If
        'End If

        'If CHKIDCOMUNICACION_CONTACTO_RP.Checked Then
        '    If Me.iWin_L_Comunicacion_Contacto_RP.IndexOf(TXTIDCOMUNICACION_CONTACTO_RP.Text) = -1 Then
        '        MsgBox("Seleccione un elmento", MsgBoxStyle.Information, "Seguridad del Sistema")
        '        TXTIDCOMUNICACION_CONTACTO_RP.Focus()
        '        Exit Function
        '    End If
        'End If

        'If CHKIDCONTACTO_PERSONA_REMITENTE.Checked Then
        '    If Me.iWin_L_CONTACTO_PERSONA_R.IndexOf(TXTIDCONTACTO_PERSONA_REMITENTE.Text) = -1 Then
        '        MsgBox("Seleccione un elmento", MsgBoxStyle.Information, "Seguridad del Sistema")
        '        TXTIDCONTACTO_PERSONA_REMITENTE.Focus()
        '        Exit Function
        '    End If
        'End If
        'If CHKIDCONTACTO_PERSONA_DESTINATARIO.Checked Then
        '    If Me.iWin_L_CONTACTO_PERSONA_D.IndexOf(TXTIDCONTACTO_PERSONA_DESTINATARIO.Text) = -1 Then
        '        MsgBox("Seleccione un elmento", MsgBoxStyle.Information, "Seguridad del Sistema")
        '        TXTIDDIRECCION_CONSIGNADO_D.Focus()
        '        Exit Function
        '    End If
        'End If
        'If CHKIDDIRECCION_CONSIGNADO_D.Checked Then
        '    If Me.iWin_L_DIECCION_CONSIGNADO_D.IndexOf(TXTIDDIRECCION_CONSIGNADO_D.Text) = -1 Then
        '        MsgBox("Seleccione un elmento", MsgBoxStyle.Information, "Seguridad del Sistema")
        '        TXTIDDIRECCION_CONSIGNADO_D.Focus()
        '        Exit Function
        '    End If
        'End If
        'If CHKIDCOMUNICACION_CONTACTO_D.Checked Then
        '    If Me.iWin_L_Comunicacion_Contacto_D.IndexOf(TXTIDCOMUNICACION_CONTACTO_D.Text) = -1 Then
        '        MsgBox("Seleccione un elmento", MsgBoxStyle.Information, "Seguridad del Sistema")
        '        TXTIDCOMUNICACION_CONTACTO_D.Focus()
        '        Exit Function
        '    End If
        'End If

        Validar = True
    End Function
    Private Sub FrmAsociacionGuiasEnvio_ClickTabPage4() Handles Me.ClickTabPage4
        'Tepsa 
        SelectMenu(3) 'GUIAS MASIVAS
        Ciudad = dtoUSUARIOS.m_idciudad
        Inicio()

        SplitContainer2.Panel1Collapsed = True
        GrabarToolStripMenuItem.Enabled = True
        ImprimirToolStripMenuItem.Enabled = False
    End Sub
    Private Sub FrmAsociacionGuiasEnvio_ClickTabPage5() Handles Me.ClickTabPage5
        'tepsa 
        SelectMenu(5) 'UMPRIMIR PRE GUIAS
        SplitContainer2.Panel1Collapsed = True
        GrabarToolStripMenuItem.Enabled = False
        ImprimirToolStripMenuItem.Enabled = True
    End Sub

    Private Sub calcular_nro_guias()
        TBTOTAL_NRO_GUIA_IMPRI.Text = Trim(TBTOTAL_NRO_GUIA_IMPRI.Text)
        TBNRO_GUIA_INI_IMPRI.Text = Trim(TBNRO_GUIA_INI_IMPRI.Text)
        If IsNumeric(TBNRO_GUIA_INI_IMPRI.Text) And IsNumeric(TBTOTAL_NRO_GUIA_IMPRI.Text) Then
            If TBTOTAL_NRO_GUIA_IMPRI.Text <= 0 Then
                TBNRO_GUIA_FINAL_IMPRI.Text = ""
                TBNRO_GUIA_FINAL_IMPRI.Text = ""
                Exit Sub
            End If
            If Len(TBNRO_GUIA_INI_IMPRI.Text) <= 1 Then
                TBNRO_GUIA_FINAL_IMPRI.Text = ""
                TBNRO_GUIA_FINAL_IMPRI.Text = ""
                Exit Sub
            End If
            TBNRO_GUIA_FINAL_IMPRI.Text = CType(Mid(TBNRO_GUIA_INI_IMPRI.Text, 1, Len(TBNRO_GUIA_INI_IMPRI.Text) - 1), Long) + CType(TBTOTAL_NRO_GUIA_IMPRI.Text, Long) - 1
            Me.CODIGO_CHECKEO(TBNRO_GUIA_FINAL_IMPRI)
        Else
            TBNRO_GUIA_FINAL_IMPRI.Text = ""
            TBNRO_GUIA_FINAL_IMPRI.Text = ""
        End If
    End Sub

    Private Sub TBNRO_GUIA_INI_IMPRI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBNRO_GUIA_INI_IMPRI.KeyUp
        If e.KeyCode = Keys.Enter Then
            TBNRO_GUIA_FINAL_IMPRI.Focus()
        End If
    End Sub
    Private Sub TBNRO_GUIA_INI_IMPRI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNRO_GUIA_INI_IMPRI.TextChanged
        Call calcular_nro_guias()
    End Sub

    Private Sub TBNRO_GUIA_FINAL_IMPRI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBNRO_GUIA_FINAL_IMPRI.KeyUp
        If e.KeyCode = Keys.Enter Then
            DTPFECHA_INICIO.Focus()
        End If
    End Sub

    Private Sub DTPFECHA_FINAL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPFECHA_FINAL.KeyUp
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub DTPFECHA_INICIO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPFECHA_INICIO.KeyUp
        If e.KeyCode = Keys.Enter Then
            DTPFECHA_FINAL.Focus()
        End If
    End Sub

    Private Sub TBNRO_GUIA_INI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBNRO_GUIA_INI.KeyUp
        If e.KeyCode = Keys.Enter Then
            TBCANTI_GUIA.Focus()
        End If
    End Sub
    Private Sub TBNRO_GUIA_FINAL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBNRO_GUIA_FINAL.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.TXTIDUNIDAD_AGENCIA_O.Focus()
        End If
    End Sub

    Private Sub txtiWinOrigen_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTIDUNIDAD_AGENCIA_O.KeyUp
        If e.KeyCode = Keys.Enter Then
            If DV_L_UNIDAD_AGENCIA_O.Table.Rows.Count > 0 Then
                For Index As Integer = 0 To DV_L_UNIDAD_AGENCIA_O.Table.Rows.Count - 1
                    If DV_L_UNIDAD_AGENCIA_O.Table.Rows(Index).Item("NOMBRE_UNIDAD").ToString.Trim = TXTIDUNIDAD_AGENCIA_O.Text.Trim Then
                        Ciudad = Convert.ToInt32(DV_L_UNIDAD_AGENCIA_O.Table.Rows(Index).Item("IDUNIDAD_AGENCIA").ToString)
                        Exit For
                    End If
                Next
            End If

            'ObjPRE_GUIAS.IDAGENCIAS_ORI = Int(COLL_L_UNIDAD_AGENCIA_O.Item(Me.iWin_L_UNIDAD_AGENCIA_O.IndexOf(TXTIDUNIDAD_AGENCIA_O.Text).ToString))

            Cursor = Cursors.AppStarting
            ObjVentaCargaContado.fnGetAgencias(Ciudad)
            Dim dt As New DataTable
            dt = ObjVentaCargaContado.dt_VarAgencias.Copy

            With CBAGENCIA_ORIGEN
                .DataSource = dt
                .DisplayMember = "nombre_agencia"
                .ValueMember = "idagencias"
            End With

            If Me.CBAGENCIA_ORIGEN.Focused Then
                Me.DespliegaCboAgencia_Origen()
            End If
            Cursor = Cursors.Default

            CBAGENCIA_ORIGEN.Focus()

            ChkContacto.Checked = False
            ChkCliente.Checked = False

            Inicio()

            CBAGENCIA_ORIGEN.Focus()
            'Me.TXTIDUNIDAD_AGENCIA_D.Focus()
        End If
    End Sub
    Sub DespliegaCboAgencia_Origen()
        With CBAGENCIA_ORIGEN
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
    End Sub

    Private Sub txtiWinDestino_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTIDUNIDAD_AGENCIA_D.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.cmbTipo_Entrega.Focus()
        End If
    End Sub

    Private Sub cmbTipo_Entrega_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTipo_Entrega.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.TXTCODIGO_CLIENTE.Focus()
        End If
    End Sub

    Private Sub TXTCODIGO_CLIENTE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCODIGO_CLIENTE.KeyPress
        Try
            If e.KeyChar = Chr(13) Then

                OBJPERSONA.CODIGO_CLIENTE = Trim(Me.TXTCODIGO_CLIENTE.Text)
                OBJPERSONA.IDTIPO_PERSONA = 0
                OBJPERSONA.IDPERSONA = 0

                If Len(OBJPERSONA.CODIGO_CLIENTE) = 0 Then
                    Me.TXTCODIGO_CLIENTE.Text = ""
                    Me.TXTIDPERSONA.Text = ""
                    Exit Sub
                End If

                'datahelper
                'dvPERSONA = OBJPERSONA.FNLISTAR_PERSONA(VOCONTROLUSUARIO, OBJPERSONA.IDTIPO_PERSONA, OBJPERSONA.IDPERSONA, OBJPERSONA.CODIGO_CLIENTE)
                dvPERSONA = OBJPERSONA.FNLISTAR_PERSONA(OBJPERSONA.IDTIPO_PERSONA, OBJPERSONA.IDPERSONA, OBJPERSONA.CODIGO_CLIENTE)

                If dvPERSONA.Count = 1 Then
                    Me.TXTIDPERSONA.Text = OBJPERSONA.RAZON_SOCIAL
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                    ObjGeneral.fnL_CENTRO_COSTOS_PERSONAS(dvCENTRO_COSTO, Me.CBIDCENTRO_COSTO, OBJPERSONA.IDPERSONA)
                    TXTIDPERSONA.Focus()
                Else
                    Me.CBIDCENTRO_COSTO.DataSource = Nothing
                    MsgBox("No existe el cliente", MsgBoxStyle.Information, "Segurdiad del Sistema")
                    Me.TXTIDPERSONA.Text = ""
                End If
            End If
        Catch EX As Exception
            MsgBox(EX.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub TxtRuc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTCODIGO_CLIENTE.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.TXTIDPERSONA.Focus()
        End If
    End Sub

    Private Sub TxtRasonSocial_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTIDPERSONA.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.CBIDCENTRO_COSTO.Focus()
        End If
    End Sub

    Private Sub TXTIDPERSONA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTIDPERSONA.LostFocus
        If Not iWinPersona.IndexOf(TXTIDPERSONA.Text) = -1 Then
            With OBJPERSONA
                .IDPERSONA = Int(COLLPERSONA.Item(iWinPersona.IndexOf(Me.TXTIDPERSONA.Text).ToString))
                .IDTIPO_PERSONA = 0
                .CODIGO_CLIENTE = "NULL"
                'datahelper
                'OBJPERSONA.FNLISTAR_PERSONA(VOCONTROLUSUARIO, .IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                OBJPERSONA.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                Me.TXTCODIGO_CLIENTE.Text = .CODIGO_CLIENTE
            End With
            Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
            ObjGeneral.fnL_CENTRO_COSTOS_PERSONAS(dvCENTRO_COSTO, Me.CBIDCENTRO_COSTO, OBJPERSONA.IDPERSONA)

            Me.MOSTRAR_CONTACTO_PERSONA()

        Else
            Me.TXTCODIGO_CLIENTE.Text = ""
            Me.CBIDCENTRO_COSTO.DataSource = Nothing

            Me.iWin_L_CONTACTO_PERSONA_RP = Nothing
            Me.COLL_L_CONTACTO_PERSONA_RP = Nothing
            Me.dv_L_CONTACTO_PERSONA_RP = Nothing

            Me.iWin_L_CONTACTO_PERSONA_R = Nothing
            Me.COLL_L_CONTACTO_PERSONA_R = Nothing
            Me.dv_L_CONTACTO_PERSONA_R = Nothing

            Me.iWin_L_CONTACTO_PERSONA_D = Nothing
            Me.COLL_L_CONTACTO_PERSONA_D = Nothing
            Me.dv_L_CONTACTO_PERSONA_D = Nothing

        End If

    End Sub
    Public Function CargarGrillaClientes_(ByVal MyDataGridLista As DataGridView, ByVal MyFuncionario As String, ByRef dtListaClientes As DataTable) As DataView
        'datahelper
        'Dim rstListaClientes As ADODB.Recordset
        'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTES_FUNCIONARIO_", 4, MyFuncionario, 2}
        'rstListaClientes = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
        'Dim da As New OleDbDataAdapter
        'da.Fill(dtListaClientes, rstListaClientes)
        'Dim MydvListaClientes As DataView

        'MydvListaClientes = dtListaClientes.DefaultView

        'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTES_FUNCIONARIO_", 4, MyFuncionario, 2}
        'rstListaClientes = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
        'Dim da As New OleDbDataAdapter
        'da.Fill(dtListaClientes, rstListaClientes)

        'Dim db As New BaseDatos
        'db.Conectar()
        'db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTES_FUNCIONARIO_", CommandType.StoredProcedure)
        'db.AsignarParametro("iNOMBRE_FUNCIONARIO", MyFuncionario, OracleClient.OracleType.VarChar)
        'db.AsignarParametro("oCUR_LISTA_CLIENTES", OracleClient.OracleType.Cursor)
        'db.Desconectar()
        'dtListaClientes = db.EjecutarDataTable
        Dim objClientes As New dtoCLIENTES
        dtListaClientes = objClientes.fn_clientes_funcionario(MyFuncionario)
        Dim MydvListaClientes As DataView
        MydvListaClientes = dtListaClientes.DefaultView

        With MyDataGridLista
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = MydvListaClientes
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            '.RowHeadersWidth = 30
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col0 As New DataGridViewCheckBoxColumn
        With col0
            .HeaderText = "¿ACTIVO?"
            .Name = "ACTIVO"
            .DataPropertyName = "IDESTADO_REGISTRO"
            .Width = 62
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .Frozen = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With
        'MyDataGridLista.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = "ID"
            .Name = "ID"
            .DataPropertyName = "IDPERSONA"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ToolTipText = "Identificador del cliente en la Base de Datos"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        End With
        'MyDataGridLista.Columns.Add(col1)

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "CODIGO"
            .Name = "CODIGO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "CODIGO_CLIENTE"
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        End With
        'MyDataGridLista.Columns.Add(col2)

        Dim Col3 As New DataGridViewTextBoxColumn
        With Col3
            .HeaderText = "DOCT."
            .Name = "DOCUMENTO"
            .DataPropertyName = "NU_DOCU_SUNA"
            .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        End With
        'MyDataGridLista.Columns.Add(Col3)

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .HeaderText = "RAZON SOCIAL"
            .Name = "RAZONSOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .ToolTipText = "Razon Social para Personas Juridicos"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        'MyDataGridLista.Columns.Add(col4)

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .HeaderText = "NOMBRE Y APELLIDOS"
            .Name = "NOMBREYAPELLIDO"
            .DataPropertyName = "NOMNRES_APELLIDOS"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        'MyDataGridLista.Columns.Add(col5)

        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .HeaderText = "TIPO PERSONA"
            .Name = "JURIDICAONATURAL"
            .DataPropertyName = "IDTIPO_PERSONA"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With
        'MyDataGridLista.Columns.Add(col6)

        Dim col7 As New DataGridViewCheckBoxColumn
        With col7
            .HeaderText = "CLIENTE CORPORATIVO"
            .Name = "CLIENTE_CORPORATIVO"
            .DataPropertyName = "CLIENTE_CORPORATIVO"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col8 As New DataGridViewTextBoxColumn
        With col8
            .HeaderText = "GERENTE GENERAL"
            .Name = "GERENTE_GENERAL"
            .DataPropertyName = "GERENTE_GENERAL"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col9 As New DataGridViewTextBoxColumn
        With col9
            .HeaderText = "REPRESENTANTE LEGAL"
            .Name = "REPRESENTANTE_LEGAL"
            .DataPropertyName = "REPRESENTANTE_LEGAL"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col10 As New DataGridViewTextBoxColumn
        With col10
            .HeaderText = "FECHA INGRESO"
            .Name = "FECHA_INGRESO"
            .DataPropertyName = "FECHA_INGRESO"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col11 As New DataGridViewCheckBoxColumn
        With col11
            .HeaderText = "PAGO POST FACTURACION"
            .Name = "PAGO_POST_FACTURACION"
            .DataPropertyName = "PAGO_POST_FACTURACION"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col12 As New DataGridViewTextBoxColumn
        With col12
            .HeaderText = "EMAIL"
            .Name = "EMAIL"
            .DataPropertyName = "EMAIL"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col13 As New DataGridViewTextBoxColumn
        With col13
            .HeaderText = "APELLIDO PATERNO"
            .Name = "APELLIDO_PATERNO"
            .DataPropertyName = "APELLIDO_PATERNO"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col14 As New DataGridViewTextBoxColumn
        With col14
            .HeaderText = "APELLIDO MATERNO"
            .Name = "APELLIDO_MATERNO"
            .DataPropertyName = "APELLIDO_MATERNO"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col15 As New DataGridViewTextBoxColumn
        With col15
            .HeaderText = "NOMPRE PERSONA"
            .Name = "NOMPRE_PERSONA"
            .DataPropertyName = "NOMPRE_PERSONA"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col16 As New DataGridViewTextBoxColumn
        With col16
            .HeaderText = "NOMPRE PERSONA1"
            .Name = "NOMPRE_PERSONA1"
            .DataPropertyName = "NOMPRE_PERSONA1"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col17 As New DataGridViewTextBoxColumn
        With col17
            .HeaderText = "FECHA NACIMIENTO"
            .Name = "FECHA_NACIMIENTO"
            .DataPropertyName = "FECHA_NACIMIENTO"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col18 As New DataGridViewTextBoxColumn
        With col18
            .HeaderText = "SEXO PERSONA"
            .Name = "SEXO_PERSONA"
            .DataPropertyName = "SEXO_PERSONA"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col19 As New DataGridViewCheckBoxColumn
        With col19
            .HeaderText = "ESMENOREDAD"
            .Name = "ESMENOREDAD"
            .DataPropertyName = "ESMENOREDAD"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col20 As New DataGridViewCheckBoxColumn
        With col20
            .HeaderText = "AGENTE RETENCION"
            .Name = "AGENTE_RETENCION"
            .DataPropertyName = "AGENTE_RETENCION"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col21 As New DataGridViewTextBoxColumn
        With col21
            .HeaderText = "IDTIPO DOC IDENTIDAD"
            .Name = "IDTIPO_DOC_IDENTIDAD"
            .DataPropertyName = "IDTIPO_DOC_IDENTIDAD"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col22 As New DataGridViewTextBoxColumn
        With col22
            .HeaderText = "NU RETE SUNA"
            .Name = "NU_RETE_SUNA"
            .DataPropertyName = "NU_RETE_SUNA"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col23 As New DataGridViewTextBoxColumn
        With col23
            .HeaderText = "IDRUBRO"
            .Name = "IDRUBRO"
            .DataPropertyName = "IDRUBRO"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col24 As New DataGridViewTextBoxColumn
        With col24
            .HeaderText = "IDCLASIFICACION PERSONA"
            .Name = "IDCLASIFICACION_PERSONA"
            .DataPropertyName = "IDCLASIFICACION_PERSONA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col25 As New DataGridViewTextBoxColumn
        With col25
            .HeaderText = "IDUSUARIO PERSONAL"
            .Name = "IDUSUARIO_PERSONAL"
            .DataPropertyName = "IDUSUARIO_PERSONAL"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col26 As New DataGridViewTextBoxColumn
        With col26
            .HeaderText = "IDROL USUARIO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Name = "IDROL_USUARIO"
            .DataPropertyName = "IDROL_USUARIO"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col27 As New DataGridViewTextBoxColumn
        With col27
            .HeaderText = "IP"
            .Name = "IP"
            .DataPropertyName = "IP"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col28 As New DataGridViewTextBoxColumn
        With col28
            .HeaderText = "FECHA REGISTRO"
            .Name = "FECHA_REGISTRO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "FECHA_REGISTRO"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col29 As New DataGridViewTextBoxColumn
        With col29
            .HeaderText = "IDUSUARIO PERSONALMOD"
            .Name = "IDUSUARIO_PERSONALMOD"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "IDUSUARIO_PERSONALMOD"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col30 As New DataGridViewTextBoxColumn
        With col30
            .HeaderText = "IDROL USUARIOMOD"
            .Name = "IDROL_USUARIOMOD"
            .DataPropertyName = "IDROL_USUARIOMOD"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col31 As New DataGridViewTextBoxColumn
        With col31
            .HeaderText = "IPMOD"
            .Name = "IPMOD"
            .DataPropertyName = "IPMOD"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col32 As New DataGridViewTextBoxColumn
        With col32
            .HeaderText = "FECHA_ACTUALIZACION"
            .Name = "FECHA_ACTUALIZACION"
            .DataPropertyName = "FECHA_ACTUALIZACION"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col33 As New DataGridViewTextBoxColumn
        With col33
            .HeaderText = "IDPAIS"
            .Name = "IDPAIS"
            .DataPropertyName = "IDPAIS"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col34 As New DataGridViewTextBoxColumn
        With col34
            .HeaderText = "IDDEPARTAMENTO"
            .Name = "IDDEPARTAMENTO"
            .DataPropertyName = "IDDEPARTAMENTO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col35 As New DataGridViewTextBoxColumn
        With col35
            .HeaderText = "IDPROVINCIA"
            .Name = "IDPROVINCIA"
            .DataPropertyName = "IDPROVINCIA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col36 As New DataGridViewTextBoxColumn
        With col36
            .HeaderText = "IDDISTRITO"
            .Name = "IDDISTRITO"
            .DataPropertyName = "IDDISTRITO"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col37 As New DataGridViewTextBoxColumn
        With col37
            .HeaderText = "USUARIO"
            .Name = "USUARIO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "USUARIO"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col38 As New DataGridViewTextBoxColumn
        With col38
            .HeaderText = "ROL USUARIO"
            .Name = "ROL_USUARIO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "ROL_USUARIO"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col39 As New DataGridViewTextBoxColumn
        With col39
            .HeaderText = "IDFUNCIONARIO ACTUAL"
            .Name = "IDFUNCIONARIO_ACTUAL"
            .DataPropertyName = "IDFUNCIONARIO_ACTUAL"
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col40 As New DataGridViewTextBoxColumn
        With col40
            .HeaderText = "FUNCIONARIO"
            .Name = "FUNCIONARIO"
            .DataPropertyName = "FUNCIONARIO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col41 As New DataGridViewTextBoxColumn
        With col41
            .HeaderText = "IDTIPO_FACTURACION"
            .Name = "IDTIPO_FACTURACION"
            .DataPropertyName = "IDTIPO_FACTURACION"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ToolTipText = "Nombres y Apellidos para Personas Naturales"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22, col23, col24, col25, col26, col27, col28, col29, col30, col31, col32, col33, col34, col35, col36, col37, col38, col39, col40, col41)

        For i As Integer = 0 To 41
            MyDataGridLista.Columns(i).Visible = False
        Next

        MyDataGridLista.Columns(0).Visible = True
        MyDataGridLista.Columns(2).Visible = True
        MyDataGridLista.Columns(4).Visible = True
        MyDataGridLista.Columns(5).Visible = True

        Return MydvListaClientes

    End Function

    Private Sub TabMante_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabMante.Selected

        If Len(Me.TXTCODIGO_CLIENTE.Text) = 0 And Len(Me.TXTIDPERSONA.Text) = 0 Then
            Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
            TXTCODIGO_CLIENTE.Text = CType(dgvr.Cells("CODIGO").Value, String)
            TXTIDPERSONA.Text = CType(dgvr.Cells("RAZONSOCIAL").Value, String)
        End If


        'Select Case Me.TabMante.SelectedIndex
        '    Case 3

        'End Select
    End Sub
    Private Function CODIGO_CHECKEO(ByRef TXT As TextBox)
        Dim VALOR_MULTIPLICADOR As Integer, MONTO As Long, digito_chk As Integer
        VALOR_MULTIPLICADOR = 3

        For I As Integer = Len(TXT.Text) To 1 Step -1
            If VALOR_MULTIPLICADOR = 1 Then
                MONTO = MONTO + Mid(TXT.Text, I, 1) * 1
                VALOR_MULTIPLICADOR = 3
            Else
                MONTO = MONTO + Mid(TXT.Text, I, 1) * 3
                VALOR_MULTIPLICADOR = 1
            End If
        Next

        digito_chk = (Int(MONTO / 10) + 1) * 10 - MONTO

        digito_chk = IIf(digito_chk = 10, 0, digito_chk)

        TXT.Text = CStr(TXT.Text) + CStr(digito_chk)
    End Function

    Private Sub TBCANTI_GUIA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBCANTI_GUIA.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.TXTIDUNIDAD_AGENCIA_O.Focus()
        End If
    End Sub

    Private Sub TBCANTI_GUIA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBCANTI_GUIA.LostFocus
        TBNRO_GUIA_INI.Text = Trim(TBNRO_GUIA_INI.Text)
        Me.TBCANTI_GUIA.Text = Trim(Me.TBCANTI_GUIA.Text)

        If IsNumeric(TBNRO_GUIA_INI.Text) Then

            If Len(TBNRO_GUIA_INI.Text) <= 1 Then
                Me.TBNRO_GUIA_FINAL.Text = ""
                Exit Sub
            End If

            If TBNRO_GUIA_INI.Text <= 0 Then
                Me.TBNRO_GUIA_FINAL.Text = ""
                Exit Sub
            End If
            If IsNumeric(Me.TBCANTI_GUIA.Text) Then
                If Me.TBCANTI_GUIA.Text <= 0 Then
                    Me.TBNRO_GUIA_FINAL.Text = ""
                    Me.TBCANTI_GUIA.Text = ""
                    Exit Sub
                End If

                TBNRO_GUIA_INI.Text = Int(TBNRO_GUIA_INI.Text / 10)
                Me.TBCANTI_GUIA.Text = Int(Me.TBCANTI_GUIA.Text)
                Me.TBNRO_GUIA_FINAL.Text = Int(TBNRO_GUIA_INI.Text) + Int(Me.TBCANTI_GUIA.Text) - 1
                CODIGO_CHECKEO(Me.TBNRO_GUIA_INI)
                CODIGO_CHECKEO(Me.TBNRO_GUIA_FINAL)
            Else
                Me.TBNRO_GUIA_FINAL.Text = ""
                Me.TBCANTI_GUIA.Text = ""
            End If
        Else
            Me.TBNRO_GUIA_FINAL.Text = ""
        End If
    End Sub


    Private Sub TBCANTI_GUIA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCANTI_GUIA.TextChanged

    End Sub

    Private Sub TBNRO_GUIA_INI_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBNRO_GUIA_INI.LostFocus
        TBNRO_GUIA_INI.Text = Trim(TBNRO_GUIA_INI.Text)
        Me.TBCANTI_GUIA.Text = Trim(Me.TBCANTI_GUIA.Text)

        If IsNumeric(TBNRO_GUIA_INI.Text) Then
            If Len(TBNRO_GUIA_INI.Text) <= 1 Then
                Me.TBNRO_GUIA_FINAL.Text = ""
                Exit Sub
            End If
            If TBNRO_GUIA_INI.Text <= 0 Then
                Me.TBNRO_GUIA_FINAL.Text = ""
                Exit Sub
            End If
            If IsNumeric(Me.TBCANTI_GUIA.Text) Then
                If Me.TBCANTI_GUIA.Text <= 0 Then
                    Me.TBNRO_GUIA_FINAL.Text = ""
                    Me.TBCANTI_GUIA.Text = ""
                    Exit Sub
                End If

                TBNRO_GUIA_INI.Text = Int(TBNRO_GUIA_INI.Text / 10)
                Me.TBCANTI_GUIA.Text = Int(Me.TBCANTI_GUIA.Text)
                Me.TBNRO_GUIA_FINAL.Text = Int(TBNRO_GUIA_INI.Text) + Int(Me.TBCANTI_GUIA.Text) - 1
                CODIGO_CHECKEO(Me.TBNRO_GUIA_INI)
                CODIGO_CHECKEO(Me.TBNRO_GUIA_FINAL)
            Else
                Me.TBNRO_GUIA_FINAL.Text = ""
                Me.TBCANTI_GUIA.Text = ""
            End If
        Else
            Me.TBNRO_GUIA_FINAL.Text = ""
        End If

    End Sub


    Private Sub TBNRO_GUIA_FINAL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNRO_GUIA_FINAL.TextChanged

    End Sub

    Private Sub TBNRO_GUIA_INI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNRO_GUIA_INI.TextChanged

    End Sub

    Private Sub TBTOTAL_NRO_GUIA_IMPRI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBTOTAL_NRO_GUIA_IMPRI.TextChanged
        Call calcular_nro_guias()
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub MOSTRAR_TELEFONOS_D2009_eliminarlo()
        '' Procedimiento implementado por Tepsa  
        'Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        'Try
        '    If Not Me.iWin_L_CONTACTO_PERSONA_D.IndexOf(Me.TXTIDCONTACTO_PERSONA_DESTINATARIO.Text) = -1 Then
        '        dv_L_Comunicacion_Contacto_D = Me.OBJCOMUNICACION_CONTACO.FN_L_Comunicacion_Contacto_D(VOCONTROLUSUARIO, Int(Me.COLL_L_CONTACTO_PERSONA_D.Item(Me.iWin_L_CONTACTO_PERSONA_D.IndexOf(Me.TXTIDCONTACTO_PERSONA_DESTINATARIO.Text).ToString)))
        '        ObjProcesos.fnCargar_iWin_r(Me.TXTIDCOMUNICACION_CONTACTO_D, dv_L_Comunicacion_Contacto_D, coll_L_Comunicacion_Contacto_D, iWin_L_Comunicacion_Contacto_D, 0)
        '    Else
        '        coll_L_Comunicacion_Contacto_D = Nothing
        '        dv_L_Comunicacion_Contacto_D = Nothing
        '        iWin_L_Comunicacion_Contacto_D = Nothing
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        'End Try
    End Sub

    Private Sub MOSTRAR_TELEFONOS_D()
        ' Procedimiento implementado por Tepsa  
        Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        Try
            'If Not Me.iWin_L_CONTACTO_PERSONA_D.IndexOf(Me.TXTIDCONTACTO_PERSONA_DESTINATARIO.Text) = -1 Then
            '    dv_L_Comunicacion_Contacto_D = Me.OBJCOMUNICACION_CONTACO.FN_L_Comunicacion_Contacto_D(Int(Me.COLL_L_CONTACTO_PERSONA_D.Item(Me.iWin_L_CONTACTO_PERSONA_D.IndexOf(Me.TXTIDCONTACTO_PERSONA_DESTINATARIO.Text).ToString)))
            '    ObjProcesos.fnCargar_iWin_r(Me.TXTIDCOMUNICACION_CONTACTO_D, dv_L_Comunicacion_Contacto_D, coll_L_Comunicacion_Contacto_D, iWin_L_Comunicacion_Contacto_D, 0)
            'Else
            '    coll_L_Comunicacion_Contacto_D = Nothing
            '    dv_L_Comunicacion_Contacto_D = Nothing
            '    iWin_L_Comunicacion_Contacto_D = Nothing
            'End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub FrmAsociacionGuiasEnvio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub


    '-----------------------------------------------------------------------------
    '----------------Modificaciones para las guias pre impresas-------------------
    '------------------------Realizado por: Aldo Chavarria------------------------
    '------------------------------Fecha: 10/03/2012------------------------------
    Sub Inicio()
        Try
            'RemoveHandler CboTipoDocumento.SelectedIndexChanged, AddressOf CboTipoDocumento_SelectedIndexChanged

            Dim ds As DataSet = obj.Inicio(dtoUSUARIOS.iIDAGENCIAS)
            Dim iOpcion As Integer = IIf(Me.ChkContacto.Checked, 1, 2)
            Dim scliente As String = IIf(Me.ChkContacto.Checked = False, Me.TXTIDPERSONA.Text.Trim, Me.TXTCODIGO_CLIENTE.Text)
            dsContacto = objGuiaEnvio.BuscarClienteCredito(scliente, iOpcion, Ciudad, -1)

            With Me.CboRemitente
                dtRemitente = dsContacto.Tables(3).Copy
                dtRemitenteParalelo = dsContacto.Tables(3).Copy
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

            End With

            With Me.CboContacto
                dtContacto = dsContacto.Tables(3)
                dtContactoParalelo = dsContacto.Tables(3).Copy
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
            End With

            dtDireccion = dsContacto.Tables(1).Copy
            CboDireccion.DataSource = dtDireccion
            CboDireccion.DisplayMember = "direccion"
            CboDireccion.ValueMember = "iddireccion_consignado"

            TXTIDPERSONA.Focus()

            ChkContacto.Checked = True
            ChkCliente.Checked = True

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub ChkContacto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkContacto.CheckedChanged
        If (TXTCODIGO_CLIENTE.Text = "") Then
            Return
        End If
        If ChkContacto.Checked = True Then
            Dim iExisteEsElCliente As Integer = ExisteEsElCliente(Me.TXTCODIGO_CLIENTE.Text.Trim, CboContacto, dtContactoParalelo, "nrodocumento", "idcontacto_persona")
            Dim iId As Integer = iExisteEsElCliente

            RemoveHandler Me.CboContacto.SelectedIndexChanged, AddressOf Me.CboContacto_SelectedIndexChanged
            Me.CboContacto.DataSource = Nothing
            Me.CboContacto.Items.Clear()
            Me.CboContacto.Items.Add(" (SELECCIONE)")
            Me.CboContacto.Items.Add(Me.TXTIDPERSONA.Text.Trim)
            Me.TxtNroDocContacto.Text = Me.TXTCODIGO_CLIENTE.Text.Trim

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
            dr("nombres") = Me.TXTIDPERSONA.Text.Trim
            dr("nombre") = IIf(IsDBNull(dsContacto.Tables(0).Rows(0).Item("nombres")), "", dsContacto.Tables(0).Rows(0).Item("nombres"))
            dr("idtipo_documento_contacto") = IIf(IsDBNull(dsContacto.Tables(0).Rows(0).Item("tipo").ToString), "", dsContacto.Tables(0).Rows(0).Item("tipo").ToString)
            dr("nrodocumento") = Me.TXTCODIGO_CLIENTE.Text.Trim
            dr("apepat") = IIf(IsDBNull(dsContacto.Tables(0).Rows(0).Item("ap")), "", dsContacto.Tables(0).Rows(0).Item("ap"))
            dr("apemat") = IIf(IsDBNull(dsContacto.Tables(0).Rows(0).Item("am")), "", dsContacto.Tables(0).Rows(0).Item("am"))
            dtContacto.Rows.Add(dr)

            CboContacto.Enabled = False

            AddHandler Me.CboContacto.SelectedIndexChanged, AddressOf Me.CboContacto_SelectedIndexChanged
            RemoveHandler Me.CboContacto.SelectedIndexChanged, AddressOf Me.CboContacto_SelectedIndexChanged
            Me.CboContacto.SelectedIndex = 1
            AddHandler Me.CboContacto.SelectedIndexChanged, AddressOf Me.CboContacto_SelectedIndexChanged
        Else
            CboContacto.Enabled = True

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


    End Sub

    Private Sub CboContacto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboContacto.SelectedIndexChanged
        If ChkContacto.Checked = False Then
            Me.TxtNroDocContacto.Text = IIf(IsDBNull(dtContacto.Rows(CboContacto.SelectedIndex).Item("nrodocumento")), "", dtContacto.Rows(CboContacto.SelectedIndex).Item("nrodocumento"))
        End If
    End Sub
    
    Private Sub ChkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente.CheckedChanged
        If (TXTCODIGO_CLIENTE.Text = "") Then
            Return
        End If
        If ChkCliente.Checked Then
            If Me.TXTCODIGO_CLIENTE.Text.Trim.Length > 0 Or Me.TXTIDPERSONA.Text.Trim.Length > 0 Then
                Dim iExisteEsElCliente As Integer = ExisteEsElCliente(Me.TXTCODIGO_CLIENTE.Text.Trim, CboRemitente, dtRemitenteParalelo, "nrodocumento", "idcontacto_persona")
                Dim iId As Integer = iExisteEsElCliente

                RemoveHandler Me.CboRemitente.SelectedIndexChanged, AddressOf Me.CboRemitente_SelectedIndexChanged
                Me.CboRemitente.DataSource = Nothing
                Me.CboRemitente.Items.Clear()
                Me.CboRemitente.Items.Add(" (SELECCIONE)")
                Me.CboRemitente.Items.Add(Me.TXTIDPERSONA.Text.Trim)
                Me.TxtNumDocRemitente.Text = Me.TXTCODIGO_CLIENTE.Text.Trim

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
                dr("nombres") = Me.TXTIDPERSONA.Text.Trim
                dr("nombre") = IIf(IsDBNull(dsContacto.Tables(0).Rows(0).Item("nombres")), "", dsContacto.Tables(0).Rows(0).Item("nombres"))
                dr("idtipo_documento_contacto") = IIf(IsDBNull(dsContacto.Tables(0).Rows(0).Item("tipo").ToString), "", dsContacto.Tables(0).Rows(0).Item("tipo").ToString)
                dr("nrodocumento") = Me.TXTCODIGO_CLIENTE.Text.Trim
                dr("apepat") = IIf(IsDBNull(dsContacto.Tables(0).Rows(0).Item("ap")), "", dsContacto.Tables(0).Rows(0).Item("ap"))
                dr("apemat") = IIf(IsDBNull(dsContacto.Tables(0).Rows(0).Item("am")), "", dsContacto.Tables(0).Rows(0).Item("am"))
                dtRemitente.Rows.Add(dr)

                AddHandler Me.CboRemitente.SelectedIndexChanged, AddressOf Me.CboRemitente_SelectedIndexChanged
                RemoveHandler Me.CboRemitente.SelectedIndexChanged, AddressOf Me.CboRemitente_SelectedIndexChanged
                Me.CboRemitente.SelectedIndex = 1
                AddHandler Me.CboRemitente.SelectedIndexChanged, AddressOf Me.CboRemitente_SelectedIndexChanged

                CboRemitente.Enabled = False
                TxtNumDocRemitente.Enabled = False
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
    End Sub

    Private Sub CboRemitente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRemitente.SelectedIndexChanged
        If ChkCliente.Checked = False Then
            Me.TxtNumDocRemitente.Text = IIf(IsDBNull(dtRemitente.Rows(CboRemitente.SelectedIndex).Item("nrodocumento")), "", dtRemitente.Rows(CboRemitente.SelectedIndex).Item("nrodocumento"))
        End If
    End Sub

    '-----------------------------------------------------------------------------
    '-----------------------------------------------------------------------------

End Class
