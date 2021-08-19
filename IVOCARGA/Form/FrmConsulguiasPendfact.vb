Public Class FrmConsulguiasPendfact
    '
    ' Recuperando las variables importantes 
    '
    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection
    Dim Colllistar_persona_todos As New Collection
    Dim dvlistar_persona_todos As New DataView
    '
    Dim myclaseguiasinfacturar As New dtoconsultguiapendfact
    'Dim odba_facturapendiente As New OleDb.OleDbDataAdapter    
    'Dim rstipofacturacion, rstfuncionario As New ADODB.Recordset
    Dim dttipofacturacion, dtfuncionario As New DataTable
    Dim dvtipofacturacion, dvfuncionario As New DataView
    'Dim rstguiasinfacturar, rsttipo_reporte As New ADODB.Recordset
    '
    Dim dtguiasinfacturar As New DataTable
    Dim dttiporeporte As New DataTable
    Dim dvguiasinfacturar As New DataView
    Dim dvtiporeporte As DataView
    ' Imprimir de acuerdo a lo seleccionado 
    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    '06/11/2007 
    Dim dt_centro_costo As New DataTable
    Dim dv_centro_costo As New DataView
    '    
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmConsulguiasPendfact_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulguiasPendfact_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmConsulguiasPendfact_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '
            Me.Dtpfecdesde.Text = Now.Date.ToShortDateString
            Me.Dtpfechasta.Text = Now.Date.ToShortDateString

            Me.ShadowLabel1.Text = "Estado Guías"
            Me.MenuStrip1.Items(1).Visible = True
            Me.MenuStrip1.Items(1).Text = "Consulta"
            Me.MenuStrip1.Items(1).Enabled = False
            Me.MenuStrip1.Items(2).Enabled = False
            Me.MenuStrip1.Items(3).Enabled = False
            Me.MenuStrip1.Items(4).Enabled = False
            Me.MenuStrip1.Items(5).Enabled = False
            '
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            '
            ToolStripMenuItem1.Text = "Consulta"
            'ToolStripMenuItem1.Image = ctype("System.Drawing.Bitmap",
            ToolStripMenuItem2.Visible = False
            ToolStripMenuItem2.Enabled = False
            ToolStripMenuItem3.Visible = False
            ToolStripMenuItem3.Enabled = False
            ToolStripMenuItem4.Visible = False
            ToolStripMenuItem4.Enabled = False
            ToolStripMenuItem5.Visible = False
            ToolStripMenuItem5.Enabled = False
            '
            Me.RadBConsguiasinfacturar.Checked = True  'Recupera todas los clientes con el total de guías a facturar 
            'Me.txtCodigoCliente.Enabled = False
            'Me.txtidpersona.Enabled = False
            '
            Me.Radbguiasinprefacturar1.Checked = True
            '
            'Mod. 20/08/2009 -->Omendoza - Pasando al datahelper   
            'If myclaseguiasinfacturar.fngettipofacturacion Then
            '    rstipofacturacion = myclaseguiasinfacturar.cur_datos
            'End If
            'rsttipo_reporte = rstipofacturacion.NextRecordset
            'rstfuncionario = rstipofacturacion.NextRecordset
            '
            'odba_facturapendiente.Fill(dttipofacturacion, rstipofacturacion)
            'odba_facturapendiente.Fill(dttiporeporte, rsttipo_reporte)
            'odba_facturapendiente.Fill(dtfuncionario, rstfuncionario)
            Dim ldset_cursores As New DataSet
            '
            ldset_cursores = myclaseguiasinfacturar.fngettipofacturacion
            dttipofacturacion = ldset_cursores.Tables(0)
            dttiporeporte = ldset_cursores.Tables(1)
            dtfuncionario = ldset_cursores.Tables(2)
            '
            ' Cargando el objeto para la busqueda de cliente 
            'datahelper
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            '
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)
            '            
            ' Cargando combo 
            dvtipofacturacion = CargarCombo(cmbtipofacturacion, dttipofacturacion, "tipo_facturacion", "idtipo_facturacion", 9999)
            dvtiporeporte = CargarCombo(cmbtiporeporte, dttiporeporte, "tipo_reporte", "idtipo_reporte", 1)

            'hlamas 06-01-2014
            'dvfuncionario = CargarCombo(cmbfuncionario, dtfuncionario, "usuario", "idusuario_personal", 9999)

            '
            Dtpfechasta.Value = dtoUSUARIOS.dfecha_sistema
            Dtpfecdesde.Value = dtoUSUARIOS.dfecha_sistema
            'Connectando al reporte
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass) ' ("tepsa", "titan", "titan")

            'datahelper
            'objgeneral.FN_L_UNIDAD_agencia_TODOS(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA)
            'objgeneral.FN_L_UNIDAD_agencia_TODOS(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA_DESTINO)
            objgeneral.FN_L_UNIDAD_agencia_TODOS(Me.CBIDUNIDAD_AGENCIA)
            objgeneral.FN_L_UNIDAD_agencia_TODOS(Me.CBIDUNIDAD_AGENCIA_DESTINO)

            Dim obj As New dtoVentaCargaContado
            Dim dt1 As DataTable = obj.ListarProducto(2, 1)
            With Me.CboTipoProducto
                .DataSource = dt1
                .ValueMember = "idprocesos"
                .DisplayMember = "procesos"
            End With

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch exp As Exception
            MsgBox(exp.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub txtCodigoCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                '
                ObjPersona.CODIGO_CLIENTE = Trim(Me.txtCodigoCliente.Text)
                ObjPersona.IDTIPO_PERSONA = 0
                ObjPersona.IDPERSONA = 0
                '
                If Len(ObjPersona.CODIGO_CLIENTE) = 0 Then
                    Me.txtCodigoCliente.Text = ""
                    Me.txtidpersona.Text = ""
                    cmb_subcuenta.DataSource = Nothing
                    Exit Sub
                End If
                '
                'datahelper
                'If ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                If ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                    Me.txtidpersona.Text = ObjPersona.RAZON_SOCIAL
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL

                    'Recupera la descripción subcuenta - 06/11/2007 - 
                    'datahelper
                    'dt_centro_costo = ObjPersona.SP_recupera_centro_costo_p(cnn)
                    dt_centro_costo = ObjPersona.SP_recupera_centro_costo_p()

                    'Por defecto se carga el generico 
                    dv_centro_costo = CargarCombo(Me.cmb_subcuenta, dt_centro_costo, "CENTRO_COSTO", "IDCENTRO_COSTO", -666)

                    ' ObjPersona.IDPERSONA


                Else
                    MsgBox("No existe el cliente", MsgBoxStyle.Information, "Segurdiad del Sistema")
                    Me.txtidpersona.Text = ""
                End If
            End If
        Catch EX As Exception
            MsgBox(EX.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub txtidpersona_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyUp
        '
        Dim dv_persona As New DataView
        '
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                    With ObjPersona
                        .IDPERSONA = CLng(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                        .IDTIPO_PERSONA = 0
                        .CODIGO_CLIENTE = "NULL" '
                        'datahelper
                        'dv_persona = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, .IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                        dv_persona = ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                        '
                        Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                    End With
                    'Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                    '''
                    If Len(ObjPersona.CODIGO_CLIENTE) = 0 Then
                        Me.txtCodigoCliente.Text = ""
                        Me.txtidpersona.Text = ""
                        cmb_subcuenta.DataSource = Nothing
                        Exit Sub
                    End If
                    '
                    'If ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_FACTURACION, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                    If dv_persona.Count = 1 Then
                        Me.txtidpersona.Text = ObjPersona.RAZON_SOCIAL
                        Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                        'Recupera la descripción subcuenta - 06/11/2007 - 
                        'datahelper
                        'dt_centro_costo = ObjPersona.SP_recupera_centro_costo_p(cnn)
                        dt_centro_costo = ObjPersona.SP_recupera_centro_costo_p()
                        'Por defecto se carga el generico 
                        dv_centro_costo = CargarCombo(Me.cmb_subcuenta, dt_centro_costo, "CENTRO_COSTO", "IDCENTRO_COSTO", -666)

                        ' ObjPersona.IDPERSONA
                    Else
                        MsgBox("No existe el cliente", MsgBoxStyle.Information, "Segurdiad del Sistema")
                        Me.txtidpersona.Text = ""
                    End If
                    '''
                Else
                    Me.txtCodigoCliente.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema e seguridad")
        End Try
    End Sub

    'CheckedChanged de las guias sin prefactura por cliente
    Private Sub Radbguiasinfacturarxcliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radbguiasinprefacturar1.CheckedChanged
        Try
            Me.dgvguiosenvio.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema e seguridad")
        End Try
    End Sub

    'CheckedChanged de las guias con prefactura por cliente
    Private Sub Radbguiasin_prefacturarxcliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radbguiasprefactura1.CheckedChanged
        Try
            Me.RadBConsguiasinfacturar.Checked = False
            Me.Radbguiasinprefacturar1.Checked = False
            Me.Radbprefactura.Checked = False
            Me.txtCodigoCliente.Enabled = True
            Me.txtidpersona.Enabled = True
            Me.dgvguiosenvio.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema e seguridad")
        End Try
    End Sub

    'CheckedChanged de las guias con factura por cliente
    Private Sub Radbprefactura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radbprefactura.CheckedChanged
        Try
            Me.RadBConsguiasinfacturar.Checked = False
            Me.Radbguiasinprefacturar1.Checked = False
            Me.Radbguiasprefactura1.Checked = False
            '
            Me.txtCodigoCliente.Enabled = True
            Me.txtidpersona.Enabled = True
            '            Me.cmbtipofacturacion.Enabled = False
            Me.dgvguiosenvio.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de seguridad")
        End Try
    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Dim scodigo_cliente As String


        limpia_campos()

        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
            myclaseguiasinfacturar.i_idunidad_agencia = Me.CBIDUNIDAD_AGENCIA.SelectedValue
        Else
            myclaseguiasinfacturar.i_idunidad_agencia = 0
        End If


        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
            myclaseguiasinfacturar.i_idunidad_agencia_destino = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
        Else
            myclaseguiasinfacturar.i_idunidad_agencia_destino = 0
        End If

        If Not IsNothing(Me.cboTipoProducto.SelectedValue) Then
            myclaseguiasinfacturar.Producto = Me.cboTipoProducto.SelectedValue
        Else
            myclaseguiasinfacturar.Producto = 0
        End If

        Try
            Select Case cmbtiporeporte.SelectedValue   ' omendoza
                Case 1  'Consolidado ' Sin prefacturar 
                    If Me.Radbguiasinprefacturar1.Checked Then
                        'Recupera todos los clientes que tienen guìas pendiente de pago 
                        format_grillas_allconsolidaguiassinfacturar()
                    End If

                    If Me.Radbguiasprefactura1.Checked Then   ' Prefactura...
                        ' Recuperar todas las guias, que están  prefacturada 
                        format_grillas_allprefacturar()
                    End If
                    If Me.Radbprefactura.Checked Then
                        ' Recuperar todos las guias, que están  facturadas 
                        format_grillas_allfacturar()
                    End If

                    If Me.rbtSinFacturar.Checked Then
                        'Guias sin Facturar
                        FormatoGEsinFacturarResumen()
                    End If

                    total(False)
                Case 2  'Detallado 
                    scodigo_cliente = txtCodigoCliente.Text
                    If Radbguiasinprefacturar1.Checked Then   ' Sin prefacturar 
                        ' Recupera las guias sin facturar 
                        format_grillas_guiassinfacturar_x_clte()
                    End If

                    If Me.Radbguiasprefactura1.Checked Then   ' Prefactura...
                        scodigo_cliente = txtCodigoCliente.Text
                        ' Recupera las guias Prefacturadas 
                        format_grillas_guias_prefacturadas()
                    End If
                    If Me.Radbprefactura.Checked Then
                        'Guias Facturadas
                        format_grillas_guias_facturadas()
                    End If

                    If Me.rbtSinFacturar.Checked Then
                        'Guias sin Facturar
                        FormatoGEsinFacturarDetalle()
                    End If

                    total(True)
            End Select
            '
            'If Me.Radbguiasprefactura1.Checked Then
            '    scodigo_cliente = txtCodigoCliente.Text
            '    'If scodigo_cliente = "" Then 'Valida que el cliente halla sido ingresado 
            '    '    MessageBox.Show("No seleccionado el cliente", "Guías pendiente facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            '    '    txtidpersona.Focus()
            '    '    Exit Sub
            '    'End If
            '    ' Recupera las guias sin facturar 
            '    format_grillas_guiassinprefacturar_x_clte()
            'End If
            '

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema e seguridad")
        End Try
    End Sub

    Private Sub limpia_dgvguiosenvio()
        Try
            dgvguiosenvio.Columns.Clear()
        Catch exp As Exception
            MsgBox(exp.Message, MsgBoxStyle.Critical, "Sistema de seguridad")
        End Try
    End Sub


    Private Sub FormatoGEsinFacturarResumen()
        Dim idtipo_facturacion, idfuncionario As Integer
        Dim sfecha_hasta, sfecha_desde As String
        Dim scodigo_cliente As String
        Try
            dgvguiosenvio.Columns.Clear()
            ' Recupera todos los clientes que tienen guias sin facturar   
            'rstguiasinfacturar = Nothing
            dtguiasinfacturar = Nothing
            dvguiasinfacturar = Nothing
            'rstguiasinfacturar = New ADODB.Recordset
            dtguiasinfacturar = New DataTable
            dvguiasinfacturar = New DataView
            '
            idtipo_facturacion = CType(cmbtipofacturacion.SelectedValue, Integer)
            idfuncionario = CType(cmbfuncionario.SelectedValue, Integer)
            sfecha_hasta = CType(Dtpfechasta.Value, String)
            sfecha_desde = CType(Dtpfecdesde.Value, String)
            '
            If txtCodigoCliente.Text = "" Then
                scodigo_cliente = "null"
            Else
                scodigo_cliente = CType(txtCodigoCliente.Text, String)
            End If
            '
            myclaseguiasinfacturar.codigo_cliente = scodigo_cliente
            myclaseguiasinfacturar.idtipo_facturacion = idtipo_facturacion
            myclaseguiasinfacturar.funcionario = idfuncionario
            myclaseguiasinfacturar.sfecha_desde = sfecha_desde
            myclaseguiasinfacturar.sfecha_hasta = sfecha_hasta
            '07/11/2007 -> Modificado 
            Try 'Valida si existe en la sub-cta los datos 
                myclaseguiasinfacturar.idcentro_costo = CType(Me.cmb_subcuenta.SelectedValue, Long)
            Catch ex As Exception
                myclaseguiasinfacturar.idcentro_costo = -666
            End Try
            '
            'Mod. 20/08/2009 -->Omendoza - Pasando al datahelper   
            'If myclaseguiasinfacturar.fnClientes_allGuiaSinFacturar Then
            '    rstguiasinfacturar = myclaseguiasinfacturar.cur_datos
            'End If
            ' 
            'odba_facturapendiente.Fill(dtguiasinfacturar, rstguiasinfacturar)
            '            
            dtguiasinfacturar = myclaseguiasinfacturar.GuiasinFacturarResumen()
            dvguiasinfacturar = dtguiasinfacturar.DefaultView
            '
            grilla_consolida()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub


    Private Sub format_grillas_allconsolidaguiassinfacturar()
        Dim idtipo_facturacion, idfuncionario As Integer
        Dim sfecha_hasta, sfecha_desde As String
        Dim scodigo_cliente As String
        Try
            dgvguiosenvio.Columns.Clear()
            ' Recupera todos los clientes que tienen guias sin facturar   
            'rstguiasinfacturar = Nothing
            dtguiasinfacturar = Nothing
            dvguiasinfacturar = Nothing
            'rstguiasinfacturar = New ADODB.Recordset
            dtguiasinfacturar = New DataTable
            dvguiasinfacturar = New DataView
            '
            idtipo_facturacion = CType(cmbtipofacturacion.SelectedValue, Integer)
            idfuncionario = CType(cmbfuncionario.SelectedValue, Integer)
            sfecha_hasta = CType(Dtpfechasta.Value, String)
            sfecha_desde = CType(Dtpfecdesde.Value, String)
            '
            If txtCodigoCliente.Text = "" Then
                scodigo_cliente = "null"
            Else
                scodigo_cliente = CType(txtCodigoCliente.Text, String)
            End If
            '
            myclaseguiasinfacturar.codigo_cliente = scodigo_cliente
            myclaseguiasinfacturar.idtipo_facturacion = idtipo_facturacion
            myclaseguiasinfacturar.funcionario = idfuncionario
            myclaseguiasinfacturar.sfecha_desde = sfecha_desde
            myclaseguiasinfacturar.sfecha_hasta = sfecha_hasta
            '07/11/2007 -> Modificado 
            Try 'Valida si existe en la sub-cta los datos 
                myclaseguiasinfacturar.idcentro_costo = CType(Me.cmb_subcuenta.SelectedValue, Long)
            Catch ex As Exception
                myclaseguiasinfacturar.idcentro_costo = -666
            End Try
            '
            'Mod. 20/08/2009 -->Omendoza - Pasando al datahelper   
            'If myclaseguiasinfacturar.fnClientes_allGuiaSinFacturar Then
            '    rstguiasinfacturar = myclaseguiasinfacturar.cur_datos
            'End If
            ' 
            'odba_facturapendiente.Fill(dtguiasinfacturar, rstguiasinfacturar)
            '            
            dtguiasinfacturar = myclaseguiasinfacturar.fnClientes_allGuiaSinFacturar()
            dvguiasinfacturar = dtguiasinfacturar.DefaultView
            '
            grilla_consolida()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub format_grillas_allprefacturar()
        Dim sfecha_hasta, sfecha_desde As String
        Dim scodigo_cliente As String
        Dim idtipo_facturacion, idfuncionario As Integer
        Try
            dgvguiosenvio.Columns.Clear()
            ' Recupera todos los clientes que tienen guias sin facturar   
            'rstguiasinfacturar = Nothing
            dtguiasinfacturar = Nothing
            dvguiasinfacturar = Nothing
            'rstguiasinfacturar = New ADODB.Recordset
            dtguiasinfacturar = New DataTable
            dvguiasinfacturar = New DataView
            '
            If txtCodigoCliente.Text = "" Then
                scodigo_cliente = "null"
            Else
                scodigo_cliente = CType(txtCodigoCliente.Text, String)
            End If
            '            
            '
            idfuncionario = CType(cmbfuncionario.SelectedValue, Integer)
            idtipo_facturacion = CType(cmbtipofacturacion.SelectedValue, Integer)
            sfecha_hasta = CType(Dtpfechasta.Value, String)
            sfecha_desde = CType(Dtpfecdesde.Value, String)
            '
            myclaseguiasinfacturar.codigo_cliente = scodigo_cliente
            myclaseguiasinfacturar.idtipo_facturacion = idtipo_facturacion
            myclaseguiasinfacturar.funcionario = idfuncionario
            myclaseguiasinfacturar.sfecha_desde = sfecha_desde
            myclaseguiasinfacturar.sfecha_hasta = sfecha_hasta
            '
            '07/11/2007 -> Modificado 
            Try 'Valida si existe en la sub-cta los datos 
                myclaseguiasinfacturar.idcentro_costo = CType(Me.cmb_subcuenta.SelectedValue, Long)
            Catch ex As Exception
                myclaseguiasinfacturar.idcentro_costo = -666
            End Try
            'Mod. 19/08/2009 -->Omendoza - Pasando al datahelper  
            'If myclaseguiasinfacturar.fnGuias_consolida_prefactura Then
            '    rstguiasinfacturar = myclaseguiasinfacturar.cur_datos
            'End If
            '' 
            'odba_facturapendiente.Fill(dtguiasinfacturar, rstguiasinfacturar)
            '
            dtguiasinfacturar = myclaseguiasinfacturar.fnGuias_consolida_prefactura
            dvguiasinfacturar = dtguiasinfacturar.DefaultView
            '
            grilla_consolida()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub format_grillas_allfacturar()
        Dim idtipo_facturacion, idtipofuncionario As Integer
        Dim sfecha_hasta, sfecha_desde As String
        Dim scodigo_cliente As String
        Try
            dgvguiosenvio.Columns.Clear()
            ' Recupera todos los clientes que tienen guias sin facturar   
            'rstguiasinfacturar = Nothing
            dtguiasinfacturar = Nothing
            dvguiasinfacturar = Nothing
            'rstguiasinfacturar = New ADODB.Recordset
            dtguiasinfacturar = New DataTable
            dvguiasinfacturar = New DataView
            '
            If txtCodigoCliente.Text = "" Then
                scodigo_cliente = "null"
            Else
                scodigo_cliente = CType(txtCodigoCliente.Text, String)
            End If
            '
            myclaseguiasinfacturar.codigo_cliente = scodigo_cliente
            '
            idtipo_facturacion = CType(cmbtipofacturacion.SelectedValue, Integer)
            idtipofuncionario = CType(cmbfuncionario.SelectedValue, Integer)
            If idtipofuncionario = 0 Then idtipofuncionario = 9999
            sfecha_hasta = CType(Dtpfechasta.Value, String)
            sfecha_desde = CType(Dtpfecdesde.Value, String)
            '
            myclaseguiasinfacturar.idtipo_facturacion = idtipo_facturacion
            myclaseguiasinfacturar.funcionario = idtipofuncionario
            myclaseguiasinfacturar.sfecha_desde = sfecha_desde
            myclaseguiasinfacturar.sfecha_hasta = sfecha_hasta
            '07/11/2007 -> Modificado 
            Try 'Valida si existe en la sub-cta los datos 
                myclaseguiasinfacturar.idcentro_costo = CType(Me.cmb_subcuenta.SelectedValue, Long)
            Catch ex As Exception
                myclaseguiasinfacturar.idcentro_costo = -666
            End Try
            '
            ''Mod. 19/08/2009 -->Omendoza - Pasando al data helper  
            '
            'If myclaseguiasinfacturar.fnGuias_consolida_factura Then
            '    rstguiasinfacturar = myclaseguiasinfacturar.cur_datos
            'End If
            '' 
            ''odba_facturapendiente.Fill(dtguiasinfacturar, rstguiasinfacturar)
            '
            dtguiasinfacturar = myclaseguiasinfacturar.fnGuias_consolida_factura
            dvguiasinfacturar = dtguiasinfacturar.DefaultView
            '
            grilla_consolida()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub format_grillas_guiassinfacturar_x_clte()
        Dim idtipo_facturacion, idtipofuncionario As Integer
        Dim scodigo_cliente As String
        Dim sfecha_hasta As String
        Dim sfecha_desde As String
        Try
            dgvguiosenvio.Columns.Clear()
            ' Recupera todos los clientes que tienen guias sin facturar   
            'rstguiasinfacturar = Nothing
            dtguiasinfacturar = Nothing
            dvguiasinfacturar = Nothing
            'rstguiasinfacturar = New ADODB.Recordset
            dtguiasinfacturar = New DataTable
            dvguiasinfacturar = New DataView
            '
            If txtCodigoCliente.Text = "" Then
                scodigo_cliente = "null"
            Else
                scodigo_cliente = CType(txtCodigoCliente.Text, String)
            End If
            '
            sfecha_desde = CType(Dtpfecdesde.Value, String)
            sfecha_hasta = CType(Dtpfechasta.Value, String)
            '
            idtipo_facturacion = CType(cmbtipofacturacion.SelectedValue, Integer)
            idtipofuncionario = CType(cmbfuncionario.SelectedValue, Integer)
            '            
            myclaseguiasinfacturar.codigo_cliente = scodigo_cliente
            myclaseguiasinfacturar.idtipo_facturacion = idtipo_facturacion
            myclaseguiasinfacturar.funcionario = idtipofuncionario
            myclaseguiasinfacturar.sfecha_desde = sfecha_desde
            myclaseguiasinfacturar.sfecha_hasta = sfecha_hasta
            ' 
            '07/11/2007 -> Modificado 
            Try 'Valida si existe en la sub-cta los datos 
                myclaseguiasinfacturar.idcentro_costo = CType(Me.cmb_subcuenta.SelectedValue, Long)
            Catch ex As Exception
                myclaseguiasinfacturar.idcentro_costo = -666
            End Try
            '
            'Mod. 19/08/2009 -->Omendoza - Pasando al datahelper  
            'If myclaseguiasinfacturar.fnGuias_SinFacturarxcliente Then  'REcuperar la nueva funcion para el cliente
            '    rstguiasinfacturar = myclaseguiasinfacturar.cur_datos
            'End If
            '' 
            'odba_facturapendiente.Fill(dtguiasinfacturar, rstguiasinfacturar)
            '
            If Me.chkDetalle.Checked Then
                dtguiasinfacturar = myclaseguiasinfacturar.ListarGuiaSinprefacturar
            Else
                dtguiasinfacturar = myclaseguiasinfacturar.fnGuias_SinFacturarxcliente
            End If
            dvguiasinfacturar = dtguiasinfacturar.DefaultView
            '
            With dgvguiosenvio
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                .RowHeadersVisible = True
                '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .DataSource = dvguiasinfacturar
            End With
            '
            Dim funcionario As New DataGridViewTextBoxColumn
            With funcionario  '0                
                .DataPropertyName = "usuario"
                .Name = "usuario"
                .HeaderText = "Funcionario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(funcionario)
            '
            Dim razonsocial As New DataGridViewTextBoxColumn
            With razonsocial '1                
                .DataPropertyName = "razon_social"
                .Name = "razon_social"
                .HeaderText = "Razón Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                ' .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(razonsocial)
            '
            Dim centro_costo As New DataGridViewTextBoxColumn
            With centro_costo '2                
                .DataPropertyName = "centro_costo"
                .Name = "centro_costo"
                .HeaderText = "Sub Cuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                ' .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(centro_costo)
            '
            Dim origen As New DataGridViewTextBoxColumn
            With origen '3 
                .DataPropertyName = "origen"
                .Name = "origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(origen)
            '
            Dim destino As New DataGridViewTextBoxColumn
            With destino '4                
                .DataPropertyName = "destino"
                .Name = "destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(destino)
            '
            Dim serie_guia_envio As New DataGridViewTextBoxColumn
            With serie_guia_envio '5
                .DataPropertyName = "serie_guia_envio"
                .Name = "serie_guia_envio"
                .HeaderText = "Serie"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(serie_guia_envio)
            '
            Dim nro_guia As New DataGridViewTextBoxColumn
            With nro_guia   '6
                .DataPropertyName = "nro_guia"
                .Name = "nro_guia"
                .HeaderText = "Nº Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(nro_guia)
            ' 
            Dim fecha_guia As New DataGridViewTextBoxColumn
            With fecha_guia     '  7
                .DataPropertyName = "fecha_guia"
                .Name = "fecha_guia"
                .HeaderText = "Fecha Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(fecha_guia)
            '
            Dim fecha_entrega As New DataGridViewTextBoxColumn
            With fecha_entrega   '8
                .DataPropertyName = "fecha_entrega"
                .Name = "fecha_entrega"
                .HeaderText = "Fecha Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(fecha_entrega)
            '
            Dim fecha_cargos As New DataGridViewTextBoxColumn
            With fecha_cargos   '9
                .DataPropertyName = "fecha_cargos"
                .Name = "fecha_cargos"
                .HeaderText = "Fecha Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(fecha_cargos)
            '
            Dim cantidad As New DataGridViewTextBoxColumn
            With cantidad   '10
                .DataPropertyName = "cantidad"
                .Name = "cantidad"
                .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad)
            '
            Dim cantidad_x_unidad_volumen As New DataGridViewTextBoxColumn
            With cantidad_x_unidad_volumen   '11
                .DataPropertyName = "cantidad_x_unidad_volumen"
                .Name = "cantidad_x_unidad_volumen"
                .HeaderText = "Cantidad x Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad_x_unidad_volumen)
            '
            Dim cantidad_sobres As New DataGridViewTextBoxColumn
            With cantidad_sobres   '12
                .DataPropertyName = "cantidad_sobres"
                .Name = "cantidad_sobres"
                .HeaderText = "Cantidad Sobres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad_sobres)
            '
            Dim total_peso As New DataGridViewTextBoxColumn
            With total_peso   '13
                .DataPropertyName = "total_peso"
                .Name = "total_peso"
                .HeaderText = "Peso total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(total_peso)
            '
            Dim total_volumen As New DataGridViewTextBoxColumn
            With total_volumen  '14
                .DataPropertyName = "total_volumen"
                .Name = "total_volumen"
                .HeaderText = "Volumen Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(total_volumen)
            '
            Dim subtotal As New DataGridViewTextBoxColumn
            With subtotal  '15
                .DataPropertyName = "subtotal"
                .Name = "subtotal"
                .HeaderText = "Sub Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            dgvguiosenvio.Columns.Add(subtotal)
            ' 
            Dim monto_impuesto As New DataGridViewTextBoxColumn
            With monto_impuesto  '16
                .DataPropertyName = "monto_impuesto"
                .Name = "monto_impuesto"
                .HeaderText = "Impuesto Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            dgvguiosenvio.Columns.Add(monto_impuesto)
            '
            Dim total_costo As New DataGridViewTextBoxColumn
            With total_costo  '17
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = " Total "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            dgvguiosenvio.Columns.Add(total_costo)

            Dim producto As New DataGridViewTextBoxColumn
            With producto  '17
                .DataPropertyName = "producto"
                .Name = "producto"
                .HeaderText = " Producto "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(producto)

            Dim estado As New DataGridViewTextBoxColumn
            With estado  '17
                .DataPropertyName = "estado"
                .Name = "estado"
                .HeaderText = " Estado "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(estado)

            Dim situacion As New DataGridViewTextBoxColumn
            With situacion  '17
                .DataPropertyName = "situacion"
                .Name = "situacion"
                .HeaderText = " Situacion Cargo "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(situacion)

            Dim entrega As New DataGridViewTextBoxColumn
            With entrega  '17
                .DataPropertyName = "entrega"
                .Name = "entrega"
                .HeaderText = " Tipo Entrega "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(entrega)

            Dim cargo As New DataGridViewTextBoxColumn
            With cargo  '17
                .DataPropertyName = "cargo"
                .Name = "cargo"
                .HeaderText = " Cargo "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(cargo)

            Dim tipo_facturacion As New DataGridViewTextBoxColumn
            With tipo_facturacion  '17
                .DataPropertyName = "tipo_facturacion"
                .Name = "tipo_facturacion"
                .HeaderText = " Tipo Facturación "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(tipo_facturacion)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub FormatoGEsinFacturarDetalle()
        Dim scodigo_cliente As String
        Dim idtipo_facturacion, idfuncionario As Integer
        Dim sfecha_hasta As String
        Dim sfecha_desde As String
        Try
            dgvguiosenvio.Columns.Clear()
            ' Recupera todos los clientes que tienen guias sin facturar   
            'rstguiasinfacturar = Nothing
            dtguiasinfacturar = Nothing
            dvguiasinfacturar = Nothing
            'rstguiasinfacturar = New ADODB.Recordset
            dtguiasinfacturar = New DataTable
            dvguiasinfacturar = New DataView
            '
            If txtCodigoCliente.Text = "" Then
                scodigo_cliente = "null"
            Else
                scodigo_cliente = CType(txtCodigoCliente.Text, String)
            End If
            '
            sfecha_desde = CType(Dtpfecdesde.Value, String)
            sfecha_hasta = CType(Dtpfechasta.Value, String)
            '
            idtipo_facturacion = CType(cmbtipofacturacion.SelectedValue, Integer)
            idfuncionario = CType(cmbfuncionario.SelectedValue, Integer)
            '
            myclaseguiasinfacturar.idtipo_facturacion = idtipo_facturacion
            myclaseguiasinfacturar.funcionario = idfuncionario
            myclaseguiasinfacturar.codigo_cliente = scodigo_cliente
            myclaseguiasinfacturar.sfecha_desde = sfecha_desde
            myclaseguiasinfacturar.sfecha_hasta = sfecha_hasta
            '
            '07/11/2007 -> Modificado 
            Try 'Valida si existe en la sub-cta los datos 
                myclaseguiasinfacturar.idcentro_costo = CType(Me.cmb_subcuenta.SelectedValue, Long)
            Catch ex As Exception
                myclaseguiasinfacturar.idcentro_costo = -666
            End Try
            ''Mod. 19/08/2009 -->Omendoza - Pasando al data helper  
            'If myclaseguiasinfacturar.fnGuias_prefacturadas Then  'REcuperar la nueva funcion para el cliente
            '    rstguiasinfacturar = myclaseguiasinfacturar.cur_datos
            'End If
            '' 
            'odba_facturapendiente.Fill(dtguiasinfacturar, rstguiasinfacturar)

            If Me.chkDetalle.Checked Then
                dtguiasinfacturar = myclaseguiasinfacturar.ListarGuiaSinFacturar
            Else
                dtguiasinfacturar = myclaseguiasinfacturar.GuiasinFacturar
            End If
            dvguiasinfacturar = dtguiasinfacturar.DefaultView
            '
            With dgvguiosenvio
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                .RowHeadersVisible = True
                '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .DataSource = dvguiasinfacturar
            End With
            '
            Dim funcionario As New DataGridViewTextBoxColumn
            With funcionario '0 
                .DataPropertyName = "usuario"
                .Name = "usuario"
                .HeaderText = "Funcionario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(funcionario)
            '
            Dim razonsocial As New DataGridViewTextBoxColumn
            With razonsocial '1                
                .DataPropertyName = "razon_social"
                .Name = "razon_social"
                .HeaderText = "Razón Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(razonsocial)
            '
            Dim Centro_costo As New DataGridViewTextBoxColumn
            With Centro_costo '1                
                .DataPropertyName = "centro_costo"
                .Name = "centro_costo"
                .HeaderText = "Sub Cuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(Centro_costo)
            '
            Dim fecha_prefactura As New DataGridViewTextBoxColumn
            With fecha_prefactura '2                
                .DataPropertyName = "fecha_prefactura"
                .Name = "fecha_prefactura"
                .HeaderText = "Fecha Prefactura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(fecha_prefactura)

            '
            Dim prefactura As New DataGridViewTextBoxColumn
            With prefactura '2                
                .DataPropertyName = "nro_prefactura"
                .Name = "nro_prefactura"
                .HeaderText = "Nro Prefactura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(prefactura)
            '
            Dim origen As New DataGridViewTextBoxColumn
            With origen '3                
                .DataPropertyName = "origen"
                .Name = "origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(origen)
            '
            Dim destino As New DataGridViewTextBoxColumn
            With destino '4                
                .DataPropertyName = "destino"
                .Name = "destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(destino)
            '
            Dim nro_guia As New DataGridViewTextBoxColumn
            With nro_guia   '5
                .DataPropertyName = "nro_guia"
                .Name = "nro_guia"
                .HeaderText = "Nº Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(nro_guia)
            ' 
            Dim fecha_guia As New DataGridViewTextBoxColumn
            With fecha_guia     '  6
                .DataPropertyName = "fecha_guia"
                .Name = "fecha_guia"
                .HeaderText = "Fecha Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(fecha_guia)
            '
            Dim fecha_cargos As New DataGridViewTextBoxColumn
            With fecha_cargos   '7
                .DataPropertyName = "fecha_cargos"
                .Name = "fecha_cargos"
                .HeaderText = "Fecha Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(fecha_cargos)
            '
            Dim cantidad As New DataGridViewTextBoxColumn
            With cantidad   '8
                .DataPropertyName = "cantidad"
                .Name = "cantidad"
                .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad)
            '
            Dim cantidad_x_unidad_volumen As New DataGridViewTextBoxColumn
            With cantidad_x_unidad_volumen   '9
                .DataPropertyName = "cantidad_x_unidad_volumen"
                .Name = "cantidad_x_unidad_volumen"
                .HeaderText = "Cantidad x Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad_x_unidad_volumen)
            '
            Dim cantidad_sobres As New DataGridViewTextBoxColumn
            With cantidad_sobres   '10
                .DataPropertyName = "cantidad_sobres"
                .Name = "cantidad_sobres"
                .HeaderText = "Cantidad Sobres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad_sobres)
            '
            Dim total_peso As New DataGridViewTextBoxColumn
            With total_peso   '11
                .DataPropertyName = "total_peso"
                .Name = "total_peso"
                .HeaderText = "Peso total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(total_peso)
            '
            Dim total_volumen As New DataGridViewTextBoxColumn
            With total_volumen  '12
                .DataPropertyName = "total_volumen"
                .Name = "total_volumen"
                .HeaderText = "Volumen Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(total_volumen)
            '
            Dim subtotal As New DataGridViewTextBoxColumn
            With subtotal  '13
                .DataPropertyName = "subtotal"
                .Name = "subtotal"
                .HeaderText = "Sub Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            dgvguiosenvio.Columns.Add(subtotal)
            ' 
            Dim monto_impuesto As New DataGridViewTextBoxColumn
            With monto_impuesto  '14
                .DataPropertyName = "monto_impuesto"
                .Name = "monto_impuesto"
                .HeaderText = "Impuesto Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            dgvguiosenvio.Columns.Add(monto_impuesto)
            '
            Dim total_costo As New DataGridViewTextBoxColumn
            With total_costo  '15
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = " Total "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            dgvguiosenvio.Columns.Add(total_costo)

            Dim producto As New DataGridViewTextBoxColumn
            With producto  '17
                .DataPropertyName = "producto"
                .Name = "producto"
                .HeaderText = " Producto "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(producto)

            Dim estado As New DataGridViewTextBoxColumn
            With estado  '17
                .DataPropertyName = "estado"
                .Name = "estado"
                .HeaderText = " Estado "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(estado)

            Dim situacion As New DataGridViewTextBoxColumn
            With situacion  '17
                .DataPropertyName = "situacion"
                .Name = "situacion"
                .HeaderText = " Situacion Cargo "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(situacion)

            Dim entrega As New DataGridViewTextBoxColumn
            With entrega  '17
                .DataPropertyName = "entrega"
                .Name = "entrega"
                .HeaderText = " Tipo Entrega "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(entrega)

            Dim cargo As New DataGridViewTextBoxColumn
            With cargo  '17
                .DataPropertyName = "cargo"
                .Name = "cargo"
                .HeaderText = " Cargo "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(cargo)

            Dim tipo_facturacion As New DataGridViewTextBoxColumn
            With tipo_facturacion  '17
                .DataPropertyName = "tipo_facturacion"
                .Name = "tipo_facturacion"
                .HeaderText = " Tipo Facturación "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(tipo_facturacion)


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub


    Private Sub format_grillas_guias_prefacturadas()
        Dim scodigo_cliente As String
        Dim idtipo_facturacion, idfuncionario As Integer
        Dim sfecha_hasta As String
        Dim sfecha_desde As String
        Try
            dgvguiosenvio.Columns.Clear()
            ' Recupera todos los clientes que tienen guias sin facturar   
            'rstguiasinfacturar = Nothing
            dtguiasinfacturar = Nothing
            dvguiasinfacturar = Nothing
            'rstguiasinfacturar = New ADODB.Recordset
            dtguiasinfacturar = New DataTable
            dvguiasinfacturar = New DataView
            '
            If txtCodigoCliente.Text = "" Then
                scodigo_cliente = "null"
            Else
                scodigo_cliente = CType(txtCodigoCliente.Text, String)
            End If
            '
            sfecha_desde = CType(Dtpfecdesde.Value, String)
            sfecha_hasta = CType(Dtpfechasta.Value, String)
            '
            idtipo_facturacion = CType(cmbtipofacturacion.SelectedValue, Integer)
            idfuncionario = CType(cmbfuncionario.SelectedValue, Integer)
            '
            myclaseguiasinfacturar.idtipo_facturacion = idtipo_facturacion
            myclaseguiasinfacturar.funcionario = idfuncionario
            myclaseguiasinfacturar.codigo_cliente = scodigo_cliente
            myclaseguiasinfacturar.sfecha_desde = sfecha_desde
            myclaseguiasinfacturar.sfecha_hasta = sfecha_hasta
            '
            '07/11/2007 -> Modificado 
            Try 'Valida si existe en la sub-cta los datos 
                myclaseguiasinfacturar.idcentro_costo = CType(Me.cmb_subcuenta.SelectedValue, Long)
            Catch ex As Exception
                myclaseguiasinfacturar.idcentro_costo = -666
            End Try
            ''Mod. 19/08/2009 -->Omendoza - Pasando al data helper  
            'If myclaseguiasinfacturar.fnGuias_prefacturadas Then  'REcuperar la nueva funcion para el cliente
            '    rstguiasinfacturar = myclaseguiasinfacturar.cur_datos
            'End If
            '' 
            'odba_facturapendiente.Fill(dtguiasinfacturar, rstguiasinfacturar)

            If Me.chkDetalle.Checked Then
                dtguiasinfacturar = myclaseguiasinfacturar.ListarGuiaPrefacturada
            Else
                dtguiasinfacturar = myclaseguiasinfacturar.fnGuias_prefacturadas
            End If
            dvguiasinfacturar = dtguiasinfacturar.DefaultView
            '
            With dgvguiosenvio
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                .RowHeadersVisible = True
                '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .DataSource = dvguiasinfacturar
            End With
            '
            Dim funcionario As New DataGridViewTextBoxColumn
            With funcionario '0 
                .DataPropertyName = "usuario"
                .Name = "usuario"
                .HeaderText = "Funcionario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(funcionario)
            '
            Dim razonsocial As New DataGridViewTextBoxColumn
            With razonsocial '1                
                .DataPropertyName = "razon_social"
                .Name = "razon_social"
                .HeaderText = "Razón Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(razonsocial)
            '
            Dim Centro_costo As New DataGridViewTextBoxColumn
            With Centro_costo '1                
                .DataPropertyName = "centro_costo"
                .Name = "centro_costo"
                .HeaderText = "Sub Cuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(Centro_costo)
            '
            Dim prefactura As New DataGridViewTextBoxColumn
            With prefactura '2                
                .DataPropertyName = "nro_prefactura"
                .Name = "nro_prefactura"
                .HeaderText = "Nro Prefactura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(prefactura)
            '
            Dim origen As New DataGridViewTextBoxColumn
            With origen '3                
                .DataPropertyName = "origen"
                .Name = "origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(origen)
            '
            Dim destino As New DataGridViewTextBoxColumn
            With destino '4                
                .DataPropertyName = "destino"
                .Name = "destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(destino)
            '
            Dim nro_guia As New DataGridViewTextBoxColumn
            With nro_guia   '5
                .DataPropertyName = "nro_guia"
                .Name = "nro_guia"
                .HeaderText = "Nº Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(nro_guia)
            ' 
            Dim fecha_guia As New DataGridViewTextBoxColumn
            With fecha_guia     '  6
                .DataPropertyName = "fecha_guia"
                .Name = "fecha_guia"
                .HeaderText = "Fecha Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(fecha_guia)
            '
            Dim fecha_cargos As New DataGridViewTextBoxColumn
            With fecha_cargos   '7
                .DataPropertyName = "fecha_cargos"
                .Name = "fecha_cargos"
                .HeaderText = "Fecha Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(fecha_cargos)
            '
            Dim cantidad As New DataGridViewTextBoxColumn
            With cantidad   '8
                .DataPropertyName = "cantidad"
                .Name = "cantidad"
                .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad)
            '
            Dim cantidad_x_unidad_volumen As New DataGridViewTextBoxColumn
            With cantidad_x_unidad_volumen   '9
                .DataPropertyName = "cantidad_x_unidad_volumen"
                .Name = "cantidad_x_unidad_volumen"
                .HeaderText = "Cantidad x Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad_x_unidad_volumen)
            '
            Dim cantidad_sobres As New DataGridViewTextBoxColumn
            With cantidad_sobres   '10
                .DataPropertyName = "cantidad_sobres"
                .Name = "cantidad_sobres"
                .HeaderText = "Cantidad Sobres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad_sobres)
            '
            Dim total_peso As New DataGridViewTextBoxColumn
            With total_peso   '11
                .DataPropertyName = "total_peso"
                .Name = "total_peso"
                .HeaderText = "Peso total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(total_peso)
            '
            Dim total_volumen As New DataGridViewTextBoxColumn
            With total_volumen  '12
                .DataPropertyName = "total_volumen"
                .Name = "total_volumen"
                .HeaderText = "Volumen Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(total_volumen)
            '
            Dim subtotal As New DataGridViewTextBoxColumn
            With subtotal  '13
                .DataPropertyName = "subtotal"
                .Name = "subtotal"
                .HeaderText = "Sub Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            dgvguiosenvio.Columns.Add(subtotal)
            ' 
            Dim monto_impuesto As New DataGridViewTextBoxColumn
            With monto_impuesto  '14
                .DataPropertyName = "monto_impuesto"
                .Name = "monto_impuesto"
                .HeaderText = "Impuesto Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            dgvguiosenvio.Columns.Add(monto_impuesto)
            '
            Dim total_costo As New DataGridViewTextBoxColumn
            With total_costo  '15
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = " Total "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            dgvguiosenvio.Columns.Add(total_costo)

            Dim producto As New DataGridViewTextBoxColumn
            With producto  '17
                .DataPropertyName = "producto"
                .Name = "producto"
                .HeaderText = " Producto "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(producto)

            Dim estado As New DataGridViewTextBoxColumn
            With estado  '17
                .DataPropertyName = "estado"
                .Name = "estado"
                .HeaderText = " Estado "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(estado)

            Dim situacion As New DataGridViewTextBoxColumn
            With situacion  '17
                .DataPropertyName = "situacion"
                .Name = "situacion"
                .HeaderText = " Situacion Cargo "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(situacion)

            Dim entrega As New DataGridViewTextBoxColumn
            With entrega  '17
                .DataPropertyName = "entrega"
                .Name = "entrega"
                .HeaderText = " Tipo Entrega "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(entrega)

            Dim cargo As New DataGridViewTextBoxColumn
            With cargo  '17
                .DataPropertyName = "cargo"
                .Name = "cargo"
                .HeaderText = " Cargo "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(cargo)

            Dim tipo_facturacion As New DataGridViewTextBoxColumn
            With tipo_facturacion  '17
                .DataPropertyName = "tipo_facturacion"
                .Name = "tipo_facturacion"
                .HeaderText = " Tipo Facturación "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(tipo_facturacion)


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub format_grillas_guias_facturadas()
        Dim scodigo_cliente As String
        Dim idtipo_facturacion, idfuncionario As Integer
        Dim sfecha_hasta As String
        Dim sfecha_desde As String
        Try
            dgvguiosenvio.Columns.Clear()
            ' Recupera todos los clientes que tienen guias sin facturar   
            'rstguiasinfacturar = Nothing
            dtguiasinfacturar = Nothing
            dvguiasinfacturar = Nothing
            'rstguiasinfacturar = New ADODB.Recordset
            dtguiasinfacturar = New DataTable
            dvguiasinfacturar = New DataView
            '
            If txtCodigoCliente.Text = "" Then
                scodigo_cliente = "null"
            Else
                scodigo_cliente = CType(txtCodigoCliente.Text, String)
            End If

            '
            sfecha_desde = CType(Dtpfecdesde.Value, String)
            sfecha_hasta = CType(Dtpfechasta.Value, String)
            '
            idtipo_facturacion = CType(cmbtipofacturacion.SelectedValue, Integer)
            idfuncionario = CType(cmbfuncionario.SelectedValue, Integer)
            '
            myclaseguiasinfacturar.idtipo_facturacion = idtipo_facturacion
            myclaseguiasinfacturar.funcionario = idfuncionario
            '
            myclaseguiasinfacturar.codigo_cliente = scodigo_cliente
            myclaseguiasinfacturar.sfecha_desde = sfecha_desde
            myclaseguiasinfacturar.sfecha_hasta = sfecha_hasta
            '07/11/2007 -> Modificado 
            Try 'Valida si existe en la sub-cta los datos 
                myclaseguiasinfacturar.idcentro_costo = CType(Me.cmb_subcuenta.SelectedValue, Long)
            Catch ex As Exception
                myclaseguiasinfacturar.idcentro_costo = -666
            End Try
            'Mod. 19/08/2009 -->Omendoza - Pasando al data helper  
            'If myclaseguiasinfacturar.fnGuias_facturas Then  'REcuperar la nueva funcion para el cliente
            '    rstguiasinfacturar = myclaseguiasinfacturar.cur_datos
            'End If
            'odba_facturapendiente.Fill(dtguiasinfacturar, rstguiasinfacturar)
            '
            If Me.chkDetalle.Checked Then
                dtguiasinfacturar = myclaseguiasinfacturar.ListarGuiaFacturada
            Else
                dtguiasinfacturar = myclaseguiasinfacturar.fnGuias_facturas
            End If
            '
            dvguiasinfacturar = dtguiasinfacturar.DefaultView
            '
            With dgvguiosenvio
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                .RowHeadersVisible = True
                '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .DataSource = dvguiasinfacturar
            End With
            '
            Dim usuario As New DataGridViewTextBoxColumn
            With usuario '0                
                .DataPropertyName = "usuario"
                .Name = "usuario"
                .HeaderText = "Funcionario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(usuario)
            '
            Dim razonsocial As New DataGridViewTextBoxColumn
            With razonsocial '1                
                .DataPropertyName = "razon_social"
                .Name = "razon_social"
                .HeaderText = "Razón Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(razonsocial)
            '
            Dim centro_costo As New DataGridViewTextBoxColumn
            With centro_costo '1                
                .DataPropertyName = "centro_costo"
                .Name = "centro_costo"
                .HeaderText = "Sub Cuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(centro_costo)
            '
            Dim seriefactura As New DataGridViewTextBoxColumn
            With seriefactura '2                
                .DataPropertyName = "serie_factura"
                .Name = "serie_factura"
                .HeaderText = "Ser. Fact."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(seriefactura)
            '
            Dim nro_factura As New DataGridViewTextBoxColumn
            With nro_factura '3                
                .DataPropertyName = "serie_factura"
                .Name = "nro_factura"
                .HeaderText = "Nro factura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(nro_factura)
            '
            Dim fecha_factura As New DataGridViewTextBoxColumn
            With fecha_factura '4
                .DataPropertyName = "fecha_factura"
                .Name = "fecha_factura"
                .HeaderText = "Fec. Factura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(fecha_factura)
            '
            Dim origen As New DataGridViewTextBoxColumn
            With origen '5          
                .DataPropertyName = "origen"
                .Name = "origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(origen)
            '
            Dim destino As New DataGridViewTextBoxColumn
            With destino '6                
                .DataPropertyName = "destino"
                .Name = "destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(destino)
            '
            Dim nro_guia As New DataGridViewTextBoxColumn
            With nro_guia   '7
                .DataPropertyName = "nro_guia"
                .Name = "nro_guia"
                .HeaderText = "Nº Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(nro_guia)
            ' 
            Dim fecha_guia As New DataGridViewTextBoxColumn
            With fecha_guia     '  8
                .DataPropertyName = "fecha_guia"
                .Name = "fecha_guia"
                .HeaderText = "Fecha Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(fecha_guia)
            '
            Dim fecha_cargos As New DataGridViewTextBoxColumn
            With fecha_cargos   '9
                .DataPropertyName = "fecha_cargos"
                .Name = "fecha_cargos"
                .HeaderText = "Fecha Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(fecha_cargos)
            '
            Dim cantidad As New DataGridViewTextBoxColumn
            With cantidad   '10 
                .DataPropertyName = "cantidad"
                .Name = "cantidad"
                .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad)
            '
            Dim cantidad_x_unidad_volumen As New DataGridViewTextBoxColumn
            With cantidad_x_unidad_volumen   '11
                .DataPropertyName = "cantidad_x_unidad_volumen"
                .Name = "cantidad_x_unidad_volumen"
                .HeaderText = "Cantidad x Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad_x_unidad_volumen)
            '
            Dim cantidad_sobres As New DataGridViewTextBoxColumn
            With cantidad_sobres   '12
                .DataPropertyName = "cantidad_sobres"
                .Name = "cantidad_sobres"
                .HeaderText = "Cantidad Sobres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad_sobres)
            '
            Dim total_peso As New DataGridViewTextBoxColumn
            With total_peso   '13
                .DataPropertyName = "total_peso"
                .Name = "total_peso"
                .HeaderText = "Peso total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(total_peso)
            '
            Dim total_volumen As New DataGridViewTextBoxColumn
            With total_volumen  '14
                .DataPropertyName = "total_volumen"
                .Name = "total_volumen"
                .HeaderText = "Volumen Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(total_volumen)
            '
            Dim subtotal As New DataGridViewTextBoxColumn
            With subtotal  '15
                .DataPropertyName = "sub_total"
                .Name = "sub_total"
                .HeaderText = "Sub Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            dgvguiosenvio.Columns.Add(subtotal)
            ' 
            Dim monto_impuesto As New DataGridViewTextBoxColumn
            With monto_impuesto  '16
                .DataPropertyName = "monto_impuesto"
                .Name = "monto_impuesto"
                .HeaderText = "Impuesto Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            dgvguiosenvio.Columns.Add(monto_impuesto)
            '
            Dim total_costo As New DataGridViewTextBoxColumn
            With total_costo  '17
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = " Total "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            dgvguiosenvio.Columns.Add(total_costo)

            Dim producto As New DataGridViewTextBoxColumn
            With producto  '17
                .DataPropertyName = "producto"
                .Name = "producto"
                .HeaderText = " Producto "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(producto)

            Dim estado As New DataGridViewTextBoxColumn
            With estado  '17
                .DataPropertyName = "estado"
                .Name = "estado"
                .HeaderText = " Estado "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(estado)


            Dim situacion As New DataGridViewTextBoxColumn
            With situacion  '17
                .DataPropertyName = "situacion"
                .Name = "situacion"
                .HeaderText = " Situacion Cargo "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(situacion)

            Dim entrega As New DataGridViewTextBoxColumn
            With entrega  '17
                .DataPropertyName = "entrega"
                .Name = "entrega"
                .HeaderText = " Tipo Entrega "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(entrega)

            Dim cargo As New DataGridViewTextBoxColumn
            With cargo  '17
                .DataPropertyName = "cargo"
                .Name = "cargo"
                .HeaderText = " Cargo "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(cargo)

            Dim tipo_facturacion As New DataGridViewTextBoxColumn
            With tipo_facturacion  '17
                .DataPropertyName = "tipo_facturacion"
                .Name = "tipo_facturacion"
                .HeaderText = " Tipo Facturación "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(tipo_facturacion)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    '-------Esta funcion no se esta usando
    Private Sub format_grillas_guiassinprefacturar_x_clte()
        Dim scodigo_cliente As String
        Dim sfecha_hasta As String
        Dim sfecha_desde As String
        Try
            dgvguiosenvio.Columns.Clear()
            ' Recupera todos los clientes que tienen guias sin facturar   
            'rstguiasinfacturar = Nothing
            dtguiasinfacturar = Nothing
            dvguiasinfacturar = Nothing
            'rstguiasinfacturar = New ADODB.Recordset
            dtguiasinfacturar = New DataTable
            dvguiasinfacturar = New DataView
            '
            If txtCodigoCliente.Text = "" Then
                scodigo_cliente = "null"
            Else
                scodigo_cliente = CType(txtCodigoCliente.Text, String)
            End If
            '
            sfecha_desde = CType(Dtpfecdesde.Value, String)
            sfecha_hasta = CType(Dtpfechasta.Value, String)
            '
            myclaseguiasinfacturar.codigo_cliente = scodigo_cliente
            myclaseguiasinfacturar.sfecha_desde = sfecha_desde
            myclaseguiasinfacturar.sfecha_hasta = sfecha_hasta
            '
            ' 'Mod. 19/08/2009 -->Omendoza - Pasando al datahelper  
            'If myclaseguiasinfacturar.fnGuias_SinPreFacturarxcliente Then  'Recupera las guias sin prefacturar por cliente 
            '    rstguiasinfacturar = myclaseguiasinfacturar.cur_datos
            'End If
            '' 
            'odba_facturapendiente.Fill(dtguiasinfacturar, rstguiasinfacturar)
            '
            dtguiasinfacturar = myclaseguiasinfacturar.fnGuias_SinPreFacturarxcliente
            dvguiasinfacturar = dtguiasinfacturar.DefaultView
            '
            With dgvguiosenvio
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                .RowHeadersVisible = True
                '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .DataSource = dvguiasinfacturar
            End With
            '
            Dim razonsocial As New DataGridViewTextBoxColumn
            With razonsocial '0                
                .DataPropertyName = "razon_social"
                .Name = "razon_social"
                .HeaderText = "Razón Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(razonsocial)
            '
            Dim centro_costo As New DataGridViewTextBoxColumn
            With centro_costo '0                
                .DataPropertyName = "centro_costo"
                .Name = "centro_costo"
                .HeaderText = "Sub Cuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(centro_costo)
            '
            Dim origen As New DataGridViewTextBoxColumn
            With origen '1                
                .DataPropertyName = "origen"
                .Name = "origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(origen)
            '
            Dim destino As New DataGridViewTextBoxColumn
            With destino '2                
                .DataPropertyName = "destino"
                .Name = "destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(destino)
            '
            Dim serie_guia_envio As New DataGridViewTextBoxColumn
            With serie_guia_envio '3
                .DataPropertyName = "serie_guia_envio"
                .Name = "serie_guia_envio"
                .HeaderText = "Serie"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(serie_guia_envio)
            '
            Dim nro_guia As New DataGridViewTextBoxColumn
            With nro_guia   '4
                .DataPropertyName = "nro_guia"
                .Name = "nro_guia"
                .HeaderText = "Nº Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            dgvguiosenvio.Columns.Add(nro_guia)
            ' 
            Dim fecha_guia As New DataGridViewTextBoxColumn
            With fecha_guia     '  5
                .DataPropertyName = "fecha_guia"
                .Name = "fecha_guia"
                .HeaderText = "Fecha Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dgvguiosenvio.Columns.Add(fecha_guia)
            '
            Dim cantidad As New DataGridViewTextBoxColumn
            With cantidad   '8
                .DataPropertyName = "cantidad"
                .Name = "cantidad"
                .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad)
            '
            Dim cantidad_x_unidad_volumen As New DataGridViewTextBoxColumn
            With cantidad_x_unidad_volumen   '9
                .DataPropertyName = "cantidad_x_unidad_volumen"
                .Name = "cantidad_x_unidad_volumen"
                .HeaderText = "Cantidad x Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad_x_unidad_volumen)
            '
            Dim cantidad_sobres As New DataGridViewTextBoxColumn
            With cantidad_sobres   '10  
                .DataPropertyName = "cantidad_sobres"
                .Name = "cantidad_sobres"
                .HeaderText = "Cantidad Sobres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(cantidad_sobres)
            '
            Dim total_peso As New DataGridViewTextBoxColumn
            With total_peso   '11
                .DataPropertyName = "total_peso"
                .Name = "total_peso"
                .HeaderText = "Peso total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(total_peso)
            '
            Dim total_volumen As New DataGridViewTextBoxColumn
            With total_volumen  '12
                .DataPropertyName = "total_volumen"
                .Name = "total_volumen"
                .HeaderText = "Volumen Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(total_volumen)
            '
            Dim subtotal As New DataGridViewTextBoxColumn
            With subtotal  '13
                .DataPropertyName = "subtotal"
                .Name = "subtotal"
                .HeaderText = "Sub Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            dgvguiosenvio.Columns.Add(subtotal)
            ' 
            Dim monto_impuesto As New DataGridViewTextBoxColumn
            With monto_impuesto  '14
                .DataPropertyName = "monto_impuesto"
                .Name = "monto_impuesto"
                .HeaderText = "Impuesto Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            dgvguiosenvio.Columns.Add(monto_impuesto)
            '
            Dim total_costo As New DataGridViewTextBoxColumn
            With total_costo  '15
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = " Total "
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            dgvguiosenvio.Columns.Add(total_costo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    '----------------------------------------------------

    Private Sub Radbguiasinfacturarxcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radbguiasinprefacturar1.Click
        Radbguiasinprefacturar1.Checked = True
    End Sub

    Private Sub RadBConsguiasinfacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadBConsguiasinfacturar.Click
        RadBConsguiasinfacturar.Checked = True
    End Sub

    Private Sub Radbguiasin_prefacturarxcliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Radbguiasprefactura1.Click
        Radbguiasprefactura1.Checked = True
    End Sub

    Private Sub Radbprefactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radbprefactura.Click
        Radbprefactura.Checked = True
    End Sub
    Private Sub FrmConsulguiasPendfact_MenuImprimir() Handles Me.MenuImprimir
        ' Imprimir de acuerdo a lo seleccionado 
        Try
            ObjReport.Dispose()
        Catch
        End Try


        Dim l_IIDTIPO_FACTURACION, idfuncionario As Long
        'dim l_p_razon_social as  String
        Dim l_ICODIGO_CLIENTE As String
        Dim sfecha_hasta, sfecha_hasta1, sfecha_desde, sfecha_desde1 As String
        Dim dfecha_hasta, dfecha_desde As Date
        Dim ll_idcentro_costo As Long
        'Dim ls_cadena As String
        '

        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
            myclaseguiasinfacturar.i_idunidad_agencia = Me.CBIDUNIDAD_AGENCIA.SelectedValue
        Else
            myclaseguiasinfacturar.i_idunidad_agencia = 0
        End If


        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
            myclaseguiasinfacturar.i_idunidad_agencia_destino = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
        Else
            myclaseguiasinfacturar.i_idunidad_agencia_destino = 0
        End If


        sfecha_hasta = CType(Dtpfechasta.Value, String)
        sfecha_hasta1 = CType(Dtpfechasta.Value, String)
        sfecha_desde1 = CType(Dtpfecdesde.Value, String)
        dfecha_hasta = DateAdd(DateInterval.Day, 1, CDate(sfecha_hasta))
        sfecha_hasta = Format(dfecha_hasta, "dd/MM/yyyy")
        sfecha_hasta = Mid$(sfecha_hasta, 7, 4) + "," + Mid$(sfecha_hasta, 4, 2) + "," + Mid$(sfecha_hasta, 1, 2)
        '
        sfecha_desde = CType(Dtpfecdesde.Value, String)
        dfecha_desde = CDate(sfecha_desde)
        sfecha_desde = Format(dfecha_desde, "dd/MM/yyyy")
        sfecha_desde = Mid$(sfecha_desde, 7, 4) + "," + Mid$(sfecha_desde, 4, 2) + "," + Mid$(sfecha_desde, 1, 2)
        '
        If txtCodigoCliente.Text = "" Then
            l_ICODIGO_CLIENTE = ""
        Else
            l_ICODIGO_CLIENTE = CType(txtCodigoCliente.Text, String)
        End If
        l_IIDTIPO_FACTURACION = CType(cmbtipofacturacion.SelectedValue, Integer)
        idfuncionario = CType(cmbfuncionario.SelectedValue, Integer)
        ' 
        Try 'Valida si existe en la sub-cta los datos 
            ll_idcentro_costo = CType(Me.cmb_subcuenta.SelectedValue, Long)
        Catch ex As Exception
            ll_idcentro_costo = -666
        End Try

        Dim intProducto As Integer
        If Not IsNothing(cboTipoProducto.SelectedIndex) Then
            intProducto = IIf(Me.cboTipoProducto.SelectedIndex = 0, 0, Me.cboTipoProducto.SelectedValue)
        Else
            intProducto = 0
        End If

        ObjReport = New ClsLbTepsa.dtoFrmReport


        Select Case cmbtiporeporte.SelectedValue
            Case 1  'Consolidado ' Sin prefacturar 
                If Me.Radbguiasinprefacturar1.Checked Then   'Guias sin Facturar 
                    'ObjReport = Nothing
                    'ObjReport = New ClsLbTepsa.dtoFrmReport
                    '
                    ObjReport.rutaRpt = PathFrmReport
                    ObjReport.conectar(rptservice, rptuser, rptpass) ' ("tepsa", "titan", "titan")
                    ObjReport.printrptB(False, "", "guias100.rpt", _
                    "ICODIGO_CLIENTE;" & l_ICODIGO_CLIENTE, _
                    "IIDTIPO_FACTURACION;" & l_IIDTIPO_FACTURACION, _
                    "IIDFUNCIONARIO_ACTUAL;" & idfuncionario, _
                    "VFECHA_DESDE;" & sfecha_desde1, _
                    "VFECHA_HASTA;" & sfecha_hasta1, _
                    "p_idunidad_agencia;" & myclaseguiasinfacturar.i_idunidad_agencia, _
                    "p_idunidad_agencia_destino;" & myclaseguiasinfacturar.i_idunidad_agencia_destino, _
                    "ni_producto;" & intProducto, _
                    "NI_IDCENTRO_COSTO;" & ll_idcentro_costo)
                End If
                If Me.Radbguiasprefactura1.Checked Then   ' Prefactura...
                    'ObjReport = Nothing
                    'ObjReport = New ClsLbTepsa.dtoFrmReport
                    '
                    ObjReport.rutaRpt = PathFrmReport
                    ObjReport.conectar(rptservice, rptuser, rptpass) ' ("tepsa", "titan", "titan")
                    ObjReport.printrptB(False, "", "guias106.rpt", _
                    "VCODIGO_CLIENTE;" & l_ICODIGO_CLIENTE, _
                    "IIDTIPO_FACTURACION;" & l_IIDTIPO_FACTURACION, _
                    "IIDFUNCIONARIO_ACTUAL;" & idfuncionario, _
                    "VFECHA_DESDE;" & sfecha_desde1, _
                    "VFECHA_HASTA;" & sfecha_hasta1, _
                    "p_idunidad_agencia;" & myclaseguiasinfacturar.i_idunidad_agencia, _
                    "p_idunidad_agencia_destino;" & myclaseguiasinfacturar.i_idunidad_agencia_destino, _
                    "ni_producto;" & intProducto, _
                    "NI_IDCENTRO_COSTO;" & ll_idcentro_costo)

                End If
                If Me.Radbprefactura.Checked Then    ' Guias Facturadas 
                    'ObjReport = Nothing
                    'ObjReport = New ClsLbTepsa.dtoFrmReport
                    '
                    ObjReport.rutaRpt = PathFrmReport
                    ObjReport.conectar(rptservice, rptuser, rptpass) ' ("tepsa", "titan", "titan")
                    ObjReport.printrptB(False, "", "guias104.rpt", _
                    "VCODIGO_CLIENTE;" & l_ICODIGO_CLIENTE, _
                    "IIDTIPO_FACTURACION;" & l_IIDTIPO_FACTURACION, _
                    "IIDFUNCIONARIO;" & idfuncionario, _
                    "VFECHA_DESDE;" & sfecha_desde1, _
                    "VFECHA_HASTA;" & sfecha_hasta1, _
                    "p_idunidad_agencia;" & myclaseguiasinfacturar.i_idunidad_agencia, _
                    "p_idunidad_agencia_destino;" & myclaseguiasinfacturar.i_idunidad_agencia_destino, _
                    "ni_producto;" & intProducto, _
                    "LL_IDCENTRO_COSTO;" & ll_idcentro_costo)
                End If
            Case 2  'Detallado 
                If Radbguiasinprefacturar1.Checked Then   ' Sin prefacturar 
                    'ObjReport = Nothing
                    'ObjReport = New ClsLbTepsa.dtoFrmReport
                    '
                    ObjReport.rutaRpt = PathFrmReport
                    ObjReport.conectar(rptservice, rptuser, rptpass) ' ("tepsa", "titan", "titan")
                    ObjReport.printrptB(False, "", "guias101.rpt", _
                    "ICODIGO_CLIENTE;" & l_ICODIGO_CLIENTE, _
                    "IIDTIPO_FACTURACION;" & l_IIDTIPO_FACTURACION, _
                    "IIDFUNCIONARIO_ACTUAL;" & idfuncionario, _
                    "VFECHA_DESDE;" & sfecha_desde1, _
                    "VFECHA_HASTA;" & sfecha_hasta1, _
                    "p_idunidad_agencia;" & myclaseguiasinfacturar.i_idunidad_agencia, _
                    "p_idunidad_agencia_destino;" & myclaseguiasinfacturar.i_idunidad_agencia_destino, _
                    "NI_IDCENTRO_COSTO;" & ll_idcentro_costo)
                End If
                If Me.Radbguiasprefactura1.Checked Then   ' Prefactura...
                    'ObjReport = Nothing
                    'ObjReport = New ClsLbTepsa.dtoFrmReport
                    '
                    ObjReport.rutaRpt = PathFrmReport
                    ObjReport.conectar(rptservice, rptuser, rptpass) ' ("tepsa", "titan", "titan")
                    ObjReport.printrptB(False, "", "guias102.rpt", _
                    "ICODIGO_CLIENTE;" & l_ICODIGO_CLIENTE, _
                    "IIDTIPO_FACTURACION;" & l_IIDTIPO_FACTURACION, _
                    "IIDFUNCIONARIO;" & idfuncionario, _
                    "IFEC_DESDE;" & sfecha_desde1, _
                    "IFEC_HASTA;" & sfecha_hasta1, _
                    "p_idunidad_agencia;" & myclaseguiasinfacturar.i_idunidad_agencia, _
                    "p_idunidad_agencia_destino;" & myclaseguiasinfacturar.i_idunidad_agencia_destino, _
                    "ni_producto;" & intProducto, _
                    "NI_IDCENTRO_COSTO;" & ll_idcentro_costo)
                End If
                If Me.Radbprefactura.Checked Then    ' Guìas Facturadas 
                    If Me.Radbprefactura.Checked Then    ' Guias Facturadas 
                        'ObjReport = Nothing
                        'ObjReport = New ClsLbTepsa.dtoFrmReport
                        '
                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass) ' ("tepsa", "titan", "titan")
                        ObjReport.printrptB(False, "", "guias105.rpt", _
                        "ICODIGO_CLIENTE;" & l_ICODIGO_CLIENTE, _
                        "IIDTIPO_FACTURACION;" & l_IIDTIPO_FACTURACION, _
                        "IIDFUNCIONARIO;" & idfuncionario, _
                        "IFEC_DESDE;" & sfecha_desde1, _
                        "IFEC_HASTA;" & sfecha_hasta1, _
                        "p_idunidad_agencia;" & myclaseguiasinfacturar.i_idunidad_agencia, _
                        "p_idunidad_agencia_destino;" & myclaseguiasinfacturar.i_idunidad_agencia_destino, _
                        "ni_producto;" & intProducto, _
                        "NI_IDCENTRO_COSTO;" & ll_idcentro_costo)
                    End If
                End If
        End Select
        ''''''
        'If Me.RadBConsguiasinfacturar.Checked Then
        '    '
        '    l_IIDTIPO_FACTURACION = IIf(cmbtipofacturacion.SelectedValue = 9999, -666, cmbtipofacturacion.SelectedValue)
        '    '
        '    ObjReport.rutaRpt = PathFrmReport
        '    ObjReport.conectar(rptservice, rptuser, rptpass) ' ("tepsa", "titan", "titan")
        '    ObjReport.printrptB(False, "", "GUIAS100.rpt", _
        '    "IIDTIPO_FACTURACION;" & l_IIDTIPO_FACTURACION, _
        '    "VFECHA_HASTA;" & sfecha_hasta1, _
        '    "VFECHA_DESDE;" & sfecha_desde1)
        'End If
        ''


        'If Me.Radbguiasinprefacturar1.Checked Then
        '    'If txtCodigoCliente.Text = "" Then
        '    '    MessageBox.Show("No seleccionado el cliente", "Guías pendiente facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '    '    txtidpersona.Focus()
        '    '    Exit Sub
        '    'End If
        '    '
        '    If txtidpersona.Text = "" Then
        '        l_p_razon_social = "Guías sin facturar desde " + sfecha_desde1 + " hasta el día " + sfecha_hasta1
        '    Else
        '        l_p_razon_social = "Guías sin facturar de " + txtidpersona.Text + " desde " + sfecha_desde1 + " hasta el día " + sfecha_hasta1
        '    End If
        '    '
        '    If l_ICODIGO_CLIENTE = "NULL" Then
        '        ls_cadena = "({t_guias_envio.fecha_guia} >= date(" & sfecha_desde & ")" & _
        '                        " and {t_guias_envio.fecha_guia} < date(" & sfecha_hasta & ")" & _
        '                        " and {t_guias_envio.idestado_registro} <> 2 and {t_guias_envio.idestado_registro} <> 3 and " & _
        '                        " {t_guias_envio.idestado_registro} <> 9 and {t_guias_envio.idestado_registro} <> 25 and {t_guias_envio.facturado} <> 1 )"
        '    Else
        '        ls_cadena = "({t_persona.codigo_cliente} = '" & l_ICODIGO_CLIENTE & "' and {t_guias_envio.fecha_guia} >= date(" & sfecha_desde & ")" & _
        '                    " and {t_guias_envio.fecha_guia} < date(" & sfecha_hasta & ")" & _
        '                    " and {t_guias_envio.idestado_registro} <> 2 and {t_guias_envio.idestado_registro} <> 3 and " & _
        '                    " {t_guias_envio.idestado_registro} <> 9 and {t_guias_envio.idestado_registro} <> 25 and {t_guias_envio.facturado} <> 1 )"
        '    End If
        '    '
        '    ' Solo es de prueba 
        '    '
        '    ' ls_cadena = "({t_guias_envio.fecha_guia} < date(" & sfecha_hasta & "))"
        '    '

        '    ObjReport.rutaRpt = PathFrmReport
        '    ObjReport.conectar(rptservice, rptuser, rptpass) ' ("tepsa", "titan", "titan")

        '    ObjReport.printrptB(False, ls_cadena, "GUIAS101.rpt", _
        '                            "P_titulo;" & l_p_razon_social)

        '    ' Anterior - 04/10/2006 Tepsa 
        '    'ObjReport.printrptB(False, "", "GUIAS101.rpt", _
        '    '            "ICODIGO_CLIENTE;" & l_ICODIGO_CLIENTE, _
        '    '            "VFECHA_HASTA;" & sfecha_hasta, _
        '    '            "P_titulo;" & l_p_razon_social)
        'End If
        'If Radbguiasprefactura1.Checked Then
        '    If txtidpersona.Text = "" Then
        '        l_p_razon_social = "Guías sin Pre-Facturar desde " + sfecha_desde1 + " hasta el día " + sfecha_hasta1
        '    Else
        '        l_p_razon_social = "Guías sin Pre-Facturar de " + txtidpersona.Text + " desde " + sfecha_desde1 + " hasta el día " + sfecha_hasta1
        '    End If
        '    '
        '    If l_ICODIGO_CLIENTE = "NULL" Then
        '        ls_cadena = "({t_persona.idtipo_facturacion} = 3 " & _
        '                    " and  {t_guias_envio.fecha_guia} >= date(" & sfecha_desde & ")" & _
        '                    " and {t_guias_envio.fecha_guia} < date(" & sfecha_hasta & ")" & _
        '                    " and isnull({t_guias_envio.idprefactura}) = true  " & _
        '                    " and {t_guias_envio.idestado_registro} <> 2 and {t_guias_envio.idestado_registro} <> 3 and " & _
        '                    " {t_guias_envio.idestado_registro} <> 9 and {t_guias_envio.idestado_registro} <> 25 and {t_guias_envio.facturado} <> 1 )"
        '    Else
        '        ls_cadena = "({t_persona.codigo_cliente} = '" & l_ICODIGO_CLIENTE & "' and {t_persona.idtipo_facturacion} = 3 " & _
        '                    " and {t_guias_envio.fecha_guia} >= date(" & sfecha_desde & ")" & _
        '                    " and {t_guias_envio.fecha_guia} < date(" & sfecha_hasta & ")" & _
        '                    " and isnull({t_guias_envio.idprefactura}) = true  " & _
        '                    " and {t_guias_envio.idestado_registro} <> 2 and {t_guias_envio.idestado_registro} <> 3 and " & _
        '                    " {t_guias_envio.idestado_registro} <> 9 and {t_guias_envio.idestado_registro} <> 25 and {t_guias_envio.facturado} <> 1 )"
        '    End If
        '    '
        '    ObjReport.rutaRpt = PathFrmReport
        '    ObjReport.conectar(rptservice, rptuser, rptpass) ' ("tepsa", "titan", "titan")
        '    ObjReport.printrptB(False, ls_cadena, "GUIAS103.rpt", _
        '                            "P_titulo;" & l_p_razon_social)

        'End If
        ''
        'If Radbprefactura.Checked Then
        '    If txtidpersona.Text = "" Then
        '        l_p_razon_social = "Guías Pre-Facturadas desde " + sfecha_desde1 + " hasta el día " + sfecha_hasta1
        '    Else
        '        l_p_razon_social = "Guías Pre-Facturadas de " + txtidpersona.Text + " desde " + sfecha_desde1 + " hasta el día " + sfecha_hasta1
        '    End If
        '    '
        '    If l_ICODIGO_CLIENTE = "NULL" Then
        '        ls_cadena = "({t_persona.idtipo_facturacion} = 3 " & _
        '                    " and  {t_guias_envio.fecha_guia} >= date(" & sfecha_desde & ")" & _
        '                    " and {t_guias_envio.fecha_guia} < date(" & sfecha_hasta & ")" & _
        '                    " and {t_guias_envio.idestado_registro} <> 2 and {t_guias_envio.idestado_registro} <> 3 and " & _
        '                    " {t_guias_envio.idestado_registro} <> 9 and {t_guias_envio.idestado_registro} <> 25 and {t_guias_envio.facturado} <> 1 )"
        '    Else
        '        ls_cadena = "({t_persona.codigo_cliente} = '" & l_ICODIGO_CLIENTE & " and {t_persona.idtipo_facturacion} = 3 " & _
        '                    " and {t_guias_envio.fecha_guia} >= date(" & sfecha_desde & ")" & _
        '                    " and {t_guias_envio.fecha_guia} < date(" & sfecha_hasta & ")" & _
        '                    " and {t_guias_envio.idestado_registro} <> 2 and {t_guias_envio.idestado_registro} <> 3 and " & _
        '                    " {t_guias_envio.idestado_registro} <> 9 and {t_guias_envio.idestado_registro} <> 25 and {t_guias_envio.facturado} <> 1 )"
        '    End If
        '    '
        '    ObjReport.rutaRpt = PathFrmReport
        '    ObjReport.conectar(rptservice, rptuser, rptpass) ' ("tepsa", "titan", "titan")
        '    ObjReport.printrptB(False, ls_cadena, "GUIAS102.rpt", _
        '                            "P_titulo;" & l_p_razon_social)
        'End If
        '
    End Sub
    Sub grilla_consolida()
        Try
            With dgvguiosenvio
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DataSource = dvguiasinfacturar
                .ReadOnly = True
            End With
            '
            Dim usuario As New DataGridViewTextBoxColumn
            With usuario '0                
                .DataPropertyName = "usuario"
                .Name = "usuario"
                .HeaderText = "Funcionario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet

            End With
            dgvguiosenvio.Columns.Add(usuario)
            '
            Dim stipo_facturacion As New DataGridViewTextBoxColumn
            With stipo_facturacion '1                
                .DataPropertyName = "tipo_facturacion"
                .Name = "tipo_facturacion"
                .HeaderText = "Tipo Facturación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            End With
            dgvguiosenvio.Columns.Add(stipo_facturacion)
            '
            Dim razon_social As New DataGridViewTextBoxColumn
            With razon_social '2
                .DataPropertyName = "razon_social"
                .Name = "razon_social"
                .HeaderText = "Cliente"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(razon_social)
            '
            Dim centro_costo As New DataGridViewTextBoxColumn
            With centro_costo '3
                .DataPropertyName = "centro_costo"
                .Name = "centro_costo"
                .HeaderText = "Sub Cuenta"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End With
            dgvguiosenvio.Columns.Add(centro_costo)
            '
            Dim nro_guias As New DataGridViewTextBoxColumn
            With nro_guias   '4
                .DataPropertyName = "nro_guias"
                .Name = "nro_guias"
                .HeaderText = "Nº Guías"
                .DefaultCellStyle.BackColor = SystemColors.Info
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                ' .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            dgvguiosenvio.Columns.Add(nro_guias)
            ' 
            Dim total_peso As New DataGridViewTextBoxColumn
            With total_peso     '  5
                .DataPropertyName = "TOTAL_peso"
                .Name = "TOTAL_peso"
                .HeaderText = "Peso Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(total_peso)
            '
            Dim Total_volumen As New DataGridViewTextBoxColumn
            With Total_volumen   '6 
                .DataPropertyName = "Total_volumen"
                .Name = "Total_volumen"
                .HeaderText = "Volumen total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(Total_volumen)
            '
            Dim monto_sin_igv As New DataGridViewTextBoxColumn
            With monto_sin_igv   '7 
                .DataPropertyName = "monto_sin_igv"
                .Name = "monto_sin_igv"
                .HeaderText = "Total sin IGV"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(monto_sin_igv)
            '
            Dim monto_impuesto As New DataGridViewTextBoxColumn
            With monto_impuesto   '8
                .DataPropertyName = "monto_impuesto"
                .Name = "monto_impuesto"
                .HeaderText = "Total Impuesto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(monto_impuesto)
            '
            Dim montototal As New DataGridViewTextBoxColumn
            With montototal   '9 
                .DataPropertyName = "montototal"
                .Name = "montototal"
                .HeaderText = "Total Guía"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgvguiosenvio.Columns.Add(montototal)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub txtidpersona_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.Leave, txtidpersona.LostFocus
        If Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
            Me.txtCodigoCliente.Text = ""
            Me.txtidpersona.Text = ""
            cmb_subcuenta.DataSource = Nothing
        End If
    End Sub

    Private Sub txtCodigoCliente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.Leave, txtCodigoCliente.LostFocus
        Try
            ObjPersona.CODIGO_CLIENTE = Trim(Me.txtCodigoCliente.Text)
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0
            '
            If Len(ObjPersona.CODIGO_CLIENTE) = 0 Then
                Me.txtCodigoCliente.Text = ""
                Me.txtidpersona.Text = ""
                cmb_subcuenta.DataSource = Nothing
                Exit Sub
            End If
            '
            'datahelper
            'If ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
            If ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                Me.txtidpersona.Text = ObjPersona.RAZON_SOCIAL
                Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                'Recupera la descripción subcuenta - 06/11/2007 - 
                'datahelper
                'dt_centro_costo = ObjPersona.SP_recupera_centro_costo_p(cnn)
                dt_centro_costo = ObjPersona.SP_recupera_centro_costo_p()
                'Por defecto se carga el generico 
                dv_centro_costo = CargarCombo(Me.cmb_subcuenta, dt_centro_costo, "CENTRO_COSTO", "IDCENTRO_COSTO", 999)

                ' ObjPersona.IDPERSONA


            Else
                MsgBox("No existe el cliente", MsgBoxStyle.Information, "Segurdiad del Sistema")
                Me.txtidpersona.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub
    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.TextChanged
        Me.dgvguiosenvio.DataSource = Nothing
    End Sub

    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Me.dgvguiosenvio.DataSource = Nothing
    End Sub
    Sub total(ByVal ab_total_costo As Boolean)
        Dim l_monto_total As Double
        Dim l_monto_impuesto As Double
        Dim l_monto_sin_igv As Double
        Dim l_total_peso As Double
        Dim l_total_volumen As Double
        Dim l_fila As Long
        '
        l_monto_total = 0
        l_monto_impuesto = 0
        l_monto_sin_igv = 0
        l_total_peso = 0
        l_total_volumen = 0
        Dim i As Integer = 0
        Try
            For l_fila = 0 To Me.dgvguiosenvio.Rows.Count - 1
                If ab_total_costo = False Then
                    l_monto_total = l_monto_total + CType(Me.dgvguiosenvio.Rows(l_fila).Cells("montototal").Value, Double)
                    l_monto_sin_igv = l_monto_sin_igv + CType(Me.dgvguiosenvio.Rows(l_fila).Cells("monto_sin_igv").Value, Double)
                Else
                    l_monto_total = l_monto_total + CType(Me.dgvguiosenvio.Rows(l_fila).Cells("total_costo").Value, Double)
                    'l_monto_sin_igv = l_monto_sin_igv + CType(Me.dgvguiosenvio.Rows(l_fila).Cells("sub_total").Value, Double)
                    Try
                        l_monto_sin_igv = l_monto_sin_igv + CType(Me.dgvguiosenvio.Rows(l_fila).Cells("subtotal").Value, Double)   'Cells("sub_total").Value, Double)
                    Catch ex As Exception
                        l_monto_sin_igv = l_monto_sin_igv + CType(Me.dgvguiosenvio.Rows(l_fila).Cells("sub_total").Value, Double)
                    End Try
                End If

                l_monto_impuesto = l_monto_impuesto + CType(Me.dgvguiosenvio.Rows(l_fila).Cells("monto_impuesto").Value, Double)

                l_total_volumen = l_total_volumen + CType(Me.dgvguiosenvio.Rows(l_fila).Cells("Total_volumen").Value, Double)
                l_total_peso = l_total_peso + CType(Me.dgvguiosenvio.Rows(l_fila).Cells("TOTAL_peso").Value, Double)

            Next
            Me.txt_tot_peso.Text = FormatNumber(l_total_peso)
            Me.Txt_tot_volumen.Text = FormatNumber(l_total_volumen)
            Me.txt_tot_sub_total.Text = FormatNumber(l_monto_sin_igv)
            Me.txt_tot_igv.Text = FormatNumber(l_monto_impuesto)
            Me.txt_tot_total.Text = FormatNumber(l_monto_total)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Sub limpia_campos()
        Try
            Me.txt_tot_peso.Text = 0
            Me.Txt_tot_volumen.Text = 0
            Me.txt_tot_sub_total.Text = 0
            Me.txt_tot_igv.Text = 0
            Me.txt_tot_total.Text = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub dgvguiosenvio_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvguiosenvio.CellContentClick

    End Sub

    Private Sub dgvguiosenvio_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvguiosenvio.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgvguiosenvio), 0)
    End Sub

    Private Sub dgvguiosenvio_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvguiosenvio.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgvguiosenvio), 0)
    End Sub

    Private Sub cmbtipofacturacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtipofacturacion.SelectedIndexChanged
        Me.dgvguiosenvio.DataSource = Nothing
    End Sub

    Private Sub Dtpfecdesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtpfecdesde.ValueChanged
        Me.dgvguiosenvio.DataSource = Nothing

        'hlamas 06-01-2014
        ClsLbTepsa.dtoGENERAL.CarteraResponsable(cmbfuncionario, Me.Dtpfecdesde.Text, Me.Dtpfechasta.Text, 1, " (TODOS)")
    End Sub

    Private Sub Dtpfechasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtpfechasta.ValueChanged
        Me.dgvguiosenvio.DataSource = Nothing

        'hlamas 06-01-2014
        ClsLbTepsa.dtoGENERAL.CarteraResponsable(cmbfuncionario, Me.Dtpfecdesde.Text, Me.Dtpfechasta.Text, 1, " (TODOS)")
    End Sub

    Private Sub cmbfuncionario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbfuncionario.SelectedIndexChanged
        Me.dgvguiosenvio.DataSource = Nothing
    End Sub

    Private Sub cmb_subcuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_subcuenta.SelectedIndexChanged
        Me.dgvguiosenvio.DataSource = Nothing
    End Sub

    Private Sub cmbtiporeporte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtiporeporte.SelectedIndexChanged
        Me.chkDetalle.Enabled = Me.cmbtiporeporte.SelectedIndex = 1
        Me.chkDetalle.Checked = False
        Me.dgvguiosenvio.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged
        Me.dgvguiosenvio.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndexChanged
        Me.dgvguiosenvio.DataSource = Nothing
    End Sub

    Private Sub rbtSinFacturar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtSinFacturar.CheckedChanged
        Try
            Me.RadBConsguiasinfacturar.Checked = False
            Me.Radbguiasinprefacturar1.Checked = False
            Me.Radbguiasprefactura1.Checked = False
            Me.Radbprefactura.Checked = False
            '
            Me.txtCodigoCliente.Enabled = True
            Me.txtidpersona.Enabled = True
            '            Me.cmbtipofacturacion.Enabled = False
            Me.dgvguiosenvio.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de seguridad")
        End Try
    End Sub

    Private Sub rbtSinFacturar_Click(sender As Object, e As System.EventArgs) Handles rbtSinFacturar.Click
        Me.rbtSinFacturar.Checked = True
    End Sub
End Class
