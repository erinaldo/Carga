Public Class frm_consulta_reparto_recojo
#Region "Variables Públicas"
    Public hnd As Long
#End Region
#Region "Variables"
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL
    Dim obj_reparto As New ClsLbTepsa.dto_reparto
    Dim b_lee As Boolean
    '
    Private ObjReport As ClsLbTepsa.dtoFrmReport
    Dim bIngreso As Boolean = False
#End Region
#Region "Eventos Adicionales"

#End Region
#Region "Eventos"

    Private Sub frm_consulta_reparto_recojo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frm_consulta_reparto_recojo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '
            Me.ShadowLabel1.Text = "Reporte x responsable"
            ' 
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            '
            'NuevoToolStripMenuItem1.Enabled = False
            'NuevoToolStripMenuItem1.Visible = False
            EdicionToolStripMenuItem.Enabled = False
            EdicionToolStripMenuItem.Visible = False
            '
            SalirToolStripMenuItem.Enabled = True
            SalirToolStripMenuItem.Visible = True
            '
            objgeneral.sp_tipo_operacion_entrega_reparto(Me.cmb_tipo_consulta)
            Me.cmb_tipo_consulta.Enabled = False
            Me.cmb_tipo_consulta.SelectedValue = 1 'Por defecto tiene que estar en raparto
            Me.cmb_tipo_consulta.Enabled = False            '
            '
            b_lee = False
            '
            'Datahelper
            '
            objgeneral.FN_L_UNIDAD_agencia_TODOS(Me.cmb_ciudad)
            cmb_ciudad.SelectedValue = 0
            '
            'objgeneral.FN_cmb_Listar_agencias(cnn, Me.cmbAgencia)
            'Me.cmbAgencia.SelectedValue = 0
            '
            'objgeneral.sp_get_responsable_movil(cnn, Me.cmbUsuarios)
            'cmbUsuarios.SelectedValue = 0
            'Datahelper
            objgeneral.get_tipo_reporte(Me.cmbtiporeporte)
            Me.cmbtiporeporte.SelectedValue = 1 ' Por defecto aparecera en resumen 
            '
            Me.DTPFECHAINICIOFACTURA.Value = dtoUSUARIOS.m_sFecha
            Me.DTPFECHAFINALFACTURA.Value = dtoUSUARIOS.m_sFecha
            '
            grilla_movil_resumen()
            totales()
            '
            b_lee = True
            '
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cmb_ciudad_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_ciudad.SelectedValueChanged
        Try
            If b_lee = True Then
                'Recupera los usuarios de la agencia
                'datahelper
                '
                objgeneral.sp_get_responsable_movil(Me.cmbUsuarios, CType(Me.cmb_ciudad.SelectedValue, Long))
                cmbUsuarios.Text = ""
                cmbUsuarios.SelectedIndex = -1
                'Datahelper                
                objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(Me.cmbAgencia, CType(Me.cmb_ciudad.SelectedValue, Long))
                Me.cmbAgencia.Text = ""
                Me.cmbAgencia.SelectedIndex = -1
                '
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Dim ldv_datos As New DataView
        '
        Try
            obj_reparto.idtipo_operacion = "E"  ' Siempre va hacer de entrega 
            '
            If Me.cmb_ciudad.SelectedValue = Nothing Then
                obj_reparto.idunidad_agencia = 0
            Else
                obj_reparto.idunidad_agencia = Me.cmb_ciudad.SelectedValue
            End If
            '
            If Me.cmbAgencia.SelectedValue = Nothing Then
                obj_reparto.idagencia = 0
            Else
                obj_reparto.idagencia = Me.cmbAgencia.SelectedValue
            End If
            '
            If Me.cmbUsuarios.SelectedValue = Nothing Then
                obj_reparto.idusuario_responsable = 0
            Else
                obj_reparto.idusuario_responsable = Me.cmbUsuarios.SelectedValue
            End If
            obj_reparto.fecha_inicio = CType(Me.DTPFECHAINICIOFACTURA.Value, String)
            obj_reparto.fecha_fin = CType(Me.DTPFECHAFINALFACTURA.Value, String)
            '
            Me.dgv_datos.DataSource = ldv_datos ' Limpiando variables 
            'Recupera la información 
            If Me.cmbtiporeporte.SelectedValue = 1 Then ' Resumen 
                If chk_cantidad_envio.Checked = True Then
                    grilla_resumen_x_entrega()
                    'Datahelper
                    ldv_datos = obj_reparto.Fn_resumen_x_punto_entrega()
                Else
                    grilla_movil_resumen()
                    'datahelper
                    ldv_datos = obj_reparto.Fn_resumen_movil()
                End If
            End If
            If Me.cmbtiporeporte.SelectedValue = 2 Then '  Detallado 
                'Else ' Detallado 
                If chk_cantidad_envio.Checked = True Then
                    grilla_detalle_movil_x_entrega()
                    'Datahelper
                    ldv_datos = obj_reparto.reparto_movil_xpto_entrega_detalle()
                Else
                    grilla_detalle_reparto_movil()
                    'Datahelper
                    ldv_datos = obj_reparto.reparto_movil_xpto_entrega_detalle()
                End If
            End If
            '
            If Me.cmbtiporeporte.SelectedValue = 3 Then '  Incidencia 
                grilla_incidencia()
                'Datahelper
                ldv_datos = obj_reparto.reparto_x_incidencia()
            End If
            '
            Me.dgv_datos.DataSource = ldv_datos
            totales()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub frm_consulta_reparto_recojo_MenuImprimir() Handles Me.MenuImprimir
        Dim ls_idtipo_operacion As String
        Dim ll_idunidad_agencia As Long
        Dim ll_idagencia As Long
        Dim ll_idusuario_responsable As Long
        Dim ls_fecha_inicio, ls_fecha_fin As String

        Try
            ls_idtipo_operacion = "E"  ' Siempre va hacer de entrega 
            '
            If Me.cmb_ciudad.SelectedValue = Nothing Then
                ll_idunidad_agencia = 0
            Else
                ll_idunidad_agencia = Me.cmb_ciudad.SelectedValue
            End If
            '
            If Me.cmbAgencia.SelectedValue = Nothing Then
                ll_idagencia = 0
            Else
                ll_idagencia = Me.cmbAgencia.SelectedValue
            End If
            '
            If Me.cmbUsuarios.SelectedValue = Nothing Then
                ll_idusuario_responsable = 0
            Else
                ll_idusuario_responsable = Me.cmbUsuarios.SelectedValue
            End If
            ls_fecha_inicio = CType(Me.DTPFECHAINICIOFACTURA.Value, String)
            ls_fecha_fin = CType(Me.DTPFECHAFINALFACTURA.Value, String)
            'Recupera la información 
            Try
                ObjReport.Dispose()
            Catch
            End Try
            ObjReport = New ClsLbTepsa.dtoFrmReport
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            '
            If Me.cmbtiporeporte.SelectedValue = 1 Then ' Resumen 
                If chk_cantidad_envio.Checked = True Then
                    ObjReport.printrptB(False, "", "mov011.RPT", _
                        "NI_IDUNIDAD_AGENCIA;" & ll_idunidad_agencia, _
                        "NI_IDAGENCIA;" & ll_idagencia, _
                        "NI_IDUSUARIO_RESPONSABLE;" & ll_idusuario_responsable, _
                        "VI_FEC_INI;" & ls_fecha_inicio, _
                        "VI_FEC_FIN;" & ls_fecha_fin, _
                        "VI_TIPO_OPERACION;" & ls_idtipo_operacion)
                Else
                    ObjReport.printrptB(False, "", "mov010.RPT", _
                        "NI_IDUNIDAD_AGENCIA;" & ll_idunidad_agencia, _
                        "NI_IDAGENCIA;" & ll_idagencia, _
                        "NI_IDUSUARIO_RESPONSABLE;" & ll_idusuario_responsable, _
                        "VI_FEC_INI;" & ls_fecha_inicio, _
                        "VI_FEC_FIN;" & ls_fecha_fin, _
                        "VI_TIPO_OPERACION;" & ls_idtipo_operacion)
                End If
            End If
            If Me.cmbtiporeporte.SelectedValue = 2 Then  ' Detallado 
                If chk_cantidad_envio.Checked = True Then
                    ObjReport.printrptB(False, "", "mov013.RPT", _
                        "NI_IDUNIDAD_AGENCIA;" & ll_idunidad_agencia, _
                        "NI_IDAGENCIA;" & ll_idagencia, _
                        "NI_IDUSUARIO_RESPONSABLE;" & ll_idusuario_responsable, _
                        "VI_FEC_INI;" & ls_fecha_inicio, _
                        "VI_FEC_FIN;" & ls_fecha_fin, _
                        "VI_TIPO_OPERACION;" & ls_idtipo_operacion)
                Else
                    ObjReport.printrptB(False, "", "mov012.RPT", _
                                            "NI_IDUNIDAD_AGENCIA;" & ll_idunidad_agencia, _
                                            "NI_IDAGENCIA;" & ll_idagencia, _
                                            "NI_IDUSUARIO_RESPONSABLE;" & ll_idusuario_responsable, _
                                            "VI_FEC_INI;" & ls_fecha_inicio, _
                                            "VI_FEC_FIN;" & ls_fecha_fin, _
                                            "VI_TIPO_OPERACION;" & ls_idtipo_operacion)
                End If
            End If
            ' 12/08/2009 - Reporte Incidencia 
            If Me.cmbtiporeporte.SelectedValue = 3 Then  ' Incidencia 
                ObjReport.printrptB(False, "", "mov014.RPT", _
                    "NI_IDUNIDAD_AGENCIA;" & ll_idunidad_agencia, _
                    "NI_IDAGENCIA;" & ll_idagencia, _
                    "NI_IDUSUARIO_RESPONSABLE;" & ll_idusuario_responsable, _
                    "VI_FEC_INI;" & ls_fecha_inicio, _
                    "VI_FEC_FIN;" & ls_fecha_fin, _
                    "VI_TIPO_OPERACION;" & ls_idtipo_operacion)
            End If
            ' 
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguidad")
        End Try
    End Sub
    Private Sub cmbtiporeporte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtiporeporte.SelectedIndexChanged
        Me.dgv_datos.DataSource = Nothing
        If b_lee Then
            Me.chk_cantidad_envio.Checked = False
            If Me.cmbtiporeporte.SelectedValue = 3 Then
                Me.chk_cantidad_envio.Enabled = False
            Else
                Me.chk_cantidad_envio.Enabled = True
            End If
        End If
    End Sub
#End Region
#Region "Procedimientos"
    Sub grilla_movil_resumen()
        Try
            dgv_datos.Columns.Clear()   'Limpiando la grilla 
            With dgv_datos
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .ScrollBars = ScrollBars.Both
            End With
            '
            Dim agencia As New DataGridViewTextBoxColumn
            With agencia '0
                .DisplayIndex = 0
                .DataPropertyName = "agencia"
                .Name = "agencia"
                .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(agencia)
            '
            Dim responsable_movil As New DataGridViewTextBoxColumn
            With responsable_movil
                .DisplayIndex = 1
                .DataPropertyName = "responsable_movil"
                .Name = "responsable_movil"
                .HeaderText = "Responsable"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(responsable_movil)
            '                     


            Dim fecha_recojo As New DataGridViewTextBoxColumn
            With fecha_recojo  '2
                .DisplayIndex = 2
                .Name = "fecha_recojo"
                .DataPropertyName = "fecha_recojo"
                .HeaderText = "Fec. Recojo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(fecha_recojo)
            '
            Dim nro_dcto As New DataGridViewTextBoxColumn
            With nro_dcto
                .DisplayIndex = 3
                .DataPropertyName = "nro_dcto"
                .Name = "nro_dcto"
                .HeaderText = "Nº Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(nro_dcto)
            ' 
            Dim sobres As New DataGridViewTextBoxColumn
            With sobres '
                .DisplayIndex = 4
                .DataPropertyName = "sobres"
                .Name = "sobres"
                .HeaderText = "Cant. Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(sobres)
            '
            Dim total_bulto As New DataGridViewTextBoxColumn
            With total_bulto ' 5
                .DisplayIndex = 5
                .DataPropertyName = "total_bulto"
                .Name = "total_bulto"
                .HeaderText = "Cant. bultos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_bulto)
            '
            Dim total_peso As New DataGridViewTextBoxColumn
            With total_peso
                .DisplayIndex = 6
                .DataPropertyName = "total_peso"
                .Name = "total_peso"
                .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_peso)
            '
            Dim total_costo As New DataGridViewTextBoxColumn
            With total_costo
                .DisplayIndex = 7
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = "Total Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_costo)

            Dim nroIncidencia As New DataGridViewTextBoxColumn
            With nroIncidencia
                .DisplayIndex = 8
                .DataPropertyName = "nroIncidencia"
                .Name = "nroIncidencia"
                .HeaderText = "Nº Incidencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(nroIncidencia)
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Sub grilla_resumen_x_entrega()
        Try
            dgv_datos.Columns.Clear()   'Limpiando la grilla 
            With dgv_datos
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10                
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .ScrollBars = ScrollBars.Both
            End With
            '
            Dim agencia As New DataGridViewTextBoxColumn
            With agencia '0
                .DisplayIndex = 0
                .DataPropertyName = "agencia"
                .Name = "agencia"
                .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(agencia)
            '
            Dim direccion_detinatario As New DataGridViewTextBoxColumn
            With direccion_detinatario
                .DisplayIndex = 1
                .DataPropertyName = "direccion_detinatario"
                .Name = "responsable_movil"
                .HeaderText = "Punto entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(direccion_detinatario)
            '                 
            Dim responsable_movil As New DataGridViewTextBoxColumn
            With responsable_movil
                .DisplayIndex = 2
                .Name = "responsable_movil"
                .DataPropertyName = "responsable_movil"
                .HeaderText = "Responsable"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(responsable_movil)
            '
            Dim fecha_recojo As New DataGridViewTextBoxColumn
            With fecha_recojo
                .DisplayIndex = 3
                .Name = "fecha_recojo"
                .DataPropertyName = "fecha_recojo"
                .HeaderText = "Fec. Recojo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(fecha_recojo)
            '
            Dim nro_dcto As New DataGridViewTextBoxColumn
            With nro_dcto
                .DisplayIndex = 4
                .DataPropertyName = "nro_dctos"
                .Name = "nro_dctos"
                .HeaderText = "Nº Documentos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(nro_dcto)
            ' 
            Dim sobres As New DataGridViewTextBoxColumn
            With sobres '
                .DisplayIndex = 5
                .DataPropertyName = "sobres"
                .Name = "sobres"
                .HeaderText = "Cant. Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(sobres)
            '
            Dim total_bulto As New DataGridViewTextBoxColumn
            With total_bulto
                .DisplayIndex = 6
                .DataPropertyName = "total_bulto"
                .Name = "total_bulto"
                .HeaderText = "Cant. bultos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_bulto)
            '
            Dim total_peso As New DataGridViewTextBoxColumn
            With total_peso
                .DisplayIndex = 7
                .DataPropertyName = "total_peso"
                .Name = "total_peso"
                .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_peso)
            '
            Dim total_costo As New DataGridViewTextBoxColumn
            With total_costo
                .DisplayIndex = 8
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = "Total Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_costo)
            '            
            Dim nroIncidencia As New DataGridViewTextBoxColumn
            With nroIncidencia
                .DisplayIndex = 9
                .DataPropertyName = "nroIncidencia"
                .Name = "nroIncidencia"
                .HeaderText = "Nº Incidencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(nroIncidencia)
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Sub grilla_detalle_reparto_movil()
        Try
            dgv_datos.Columns.Clear()   'Limpiando la grilla 
            With dgv_datos
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .BackgroundColor = SystemColors.Window                
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .ScrollBars = ScrollBars.Both
            End With
            '
            Dim agencia As New DataGridViewTextBoxColumn
            With agencia '0
                .DisplayIndex = 0
                .DataPropertyName = "ageencia"
                .Name = "ageencia"
                .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(agencia)
            '
            Dim responsable_movil As New DataGridViewTextBoxColumn
            With responsable_movil
                .DisplayIndex = 1
                .Name = "responsable_movil"
                .DataPropertyName = "responsable_movil"
                .HeaderText = "Responsable"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(responsable_movil)
            '
            Dim dcto_cliente As New DataGridViewTextBoxColumn
            With dcto_cliente
                .DisplayIndex = 2
                .Name = "dcto_cliente"
                .DataPropertyName = "dcto_cliente"
                .HeaderText = "Ruc/Dni"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(dcto_cliente)
            '
            Dim razon_social As New DataGridViewTextBoxColumn
            With razon_social
                .DisplayIndex = 3
                .Name = "razon_social"
                .DataPropertyName = "razon_social"
                .HeaderText = "Razon social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(razon_social)
            '
            Dim tipo_documento As New DataGridViewTextBoxColumn
            With tipo_documento
                .DisplayIndex = 4
                .Name = "tipo_documento"
                .DataPropertyName = "tipo_documento"
                .HeaderText = "Tip Dcto."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(tipo_documento)
            '
            Dim nro_dcto As New DataGridViewTextBoxColumn
            With nro_dcto
                .DisplayIndex = 5
                .Name = "nro_dcto"
                .DataPropertyName = "nro_dcto"
                .HeaderText = "Nº Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(nro_dcto)
            '
            Dim origen As New DataGridViewTextBoxColumn
            With origen
                .DisplayIndex = 6
                .Name = "origen"
                .DataPropertyName = "origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(origen)
            '
            Dim destino As New DataGridViewTextBoxColumn
            With destino
                .DisplayIndex = 7
                .Name = "destino"
                .DataPropertyName = "destino"
                .HeaderText = "destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(destino)
            '
            Dim fecha_llegada As New DataGridViewTextBoxColumn
            With fecha_llegada
                .DisplayIndex = 8
                .DataPropertyName = "fecha_llegada"
                .Name = "fecha_llegada"
                .HeaderText = "Fecha Recepción"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(fecha_llegada)

            Dim fecha_recojo As New DataGridViewTextBoxColumn
            With fecha_recojo
                .DisplayIndex = 9
                .Name = "Fecha"
                .DataPropertyName = "Fecha"
                .HeaderText = "Fec. Reparto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(fecha_recojo)
            ' 
            Dim sobres As New DataGridViewTextBoxColumn
            With sobres '
                .DisplayIndex = 10
                .DataPropertyName = "sobres"
                .Name = "sobres"
                .HeaderText = "Cant. Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(sobres)
            '
            Dim total_bulto As New DataGridViewTextBoxColumn
            With total_bulto
                .DisplayIndex = 11
                .DataPropertyName = "total_bultos"
                .Name = "total_bultos"
                .HeaderText = "Cant. bultos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_bulto)
            '
            Dim total_peso As New DataGridViewTextBoxColumn
            With total_peso
                .DisplayIndex = 12
                .DataPropertyName = "total_peso"
                .Name = "total_peso"
                .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_peso)
            '
            Dim total_costo As New DataGridViewTextBoxColumn
            With total_costo
                .DisplayIndex = 13
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = "Total Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_costo)
            '            
            Dim nroIncidencia As New DataGridViewTextBoxColumn
            With nroIncidencia
                .DisplayIndex = 14
                .DataPropertyName = "nroIncidencia"
                .Name = "nroIncidencia"
                .HeaderText = "Nº Incidencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(nroIncidencia)
            '

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Sub grilla_detalle_movil_x_entrega()
        Try
            dgv_datos.Columns.Clear()   'Limpiando la grilla 
            With dgv_datos               
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .ScrollBars = ScrollBars.Both
            End With
            '
            Dim agencia As New DataGridViewTextBoxColumn
            With agencia '0
                .DisplayIndex = 0
                .DataPropertyName = "ageencia"
                .Name = "ageencia"
                .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(agencia)
            '
            Dim pto_entrega As New DataGridViewTextBoxColumn
            With pto_entrega
                .DisplayIndex = 1
                .Name = "direccion_detinatario()"
                .DataPropertyName = "direccion_detinatario"
                .HeaderText = "Punto de Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(pto_entrega)
            '
            Dim dcto_cliente As New DataGridViewTextBoxColumn
            With dcto_cliente
                .DisplayIndex = 2
                .Name = "dcto_cliente"
                .DataPropertyName = "dcto_cliente"
                .HeaderText = "Ruc/Dni"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(dcto_cliente)
            '
            Dim razon_social As New DataGridViewTextBoxColumn
            With razon_social
                .DisplayIndex = 3
                .Name = "razon_social"
                .DataPropertyName = "razon_social"
                .HeaderText = "Razon social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(razon_social)
            '
            Dim tipo_documento As New DataGridViewTextBoxColumn
            With tipo_documento
                .DisplayIndex = 4
                .Name = "tipo_documento"
                .DataPropertyName = "tipo_documento"
                .HeaderText = "Tip Dcto."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(tipo_documento)
            '
            Dim nro_dcto As New DataGridViewTextBoxColumn
            With nro_dcto
                .DisplayIndex = 5
                .Name = "nro_dcto"
                .DataPropertyName = "nro_dcto"
                .HeaderText = "Nº Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(nro_dcto)
            '
            Dim origen As New DataGridViewTextBoxColumn
            With origen
                .DisplayIndex = 6
                .Name = "origen"
                .DataPropertyName = "origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(origen)
            '
            Dim destino As New DataGridViewTextBoxColumn
            With destino
                .DisplayIndex = 7
                .Name = "destino"
                .DataPropertyName = "destino"
                .HeaderText = "destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(destino)
            '
            Dim fecha_recojo As New DataGridViewTextBoxColumn
            With fecha_recojo
                .DisplayIndex = 8
                .Name = "Fecha"
                .DataPropertyName = "Fecha"
                .HeaderText = "Fec. Reparto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(fecha_recojo)
            ' 
            Dim sobres As New DataGridViewTextBoxColumn
            With sobres '
                .DisplayIndex = 9
                .DataPropertyName = "sobres"
                .Name = "sobres"
                .HeaderText = "Cant. Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(sobres)
            '
            Dim total_bulto As New DataGridViewTextBoxColumn
            With total_bulto
                .DisplayIndex = 10
                .DataPropertyName = "total_bultos"
                .Name = "total_bultos"
                .HeaderText = "Cant. bultos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_bulto)
            '
            Dim total_peso As New DataGridViewTextBoxColumn
            With total_peso
                .DisplayIndex = 11
                .DataPropertyName = "total_peso"
                .Name = "total_peso"
                .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_peso)
            '
            Dim total_costo As New DataGridViewTextBoxColumn
            With total_costo
                .DisplayIndex = 12
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = "Total Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_costo)
            '            
            Dim nroIncidencia As New DataGridViewTextBoxColumn
            With nroIncidencia
                .DisplayIndex = 13
                .DataPropertyName = "nroIncidencia"
                .Name = "nroIncidencia"
                .HeaderText = "Nº Incidencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(nroIncidencia)
            '

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Sub grilla_incidencia()
        Try
            dgv_datos.Columns.Clear()   'Limpiando la grilla 
            With dgv_datos
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .ScrollBars = ScrollBars.Both
            End With
            '
            Dim agencia As New DataGridViewTextBoxColumn
            With agencia '0
                .DisplayIndex = 0
                .DataPropertyName = "agencia"
                .Name = "agencia"
                .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(agencia)
            '
            Dim cliente As New DataGridViewTextBoxColumn
            With cliente
                .DisplayIndex = 1
                .Name = "cliente"
                .DataPropertyName = "cliente"
                .HeaderText = "Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(cliente)
            '
            Dim fec_dcto As New DataGridViewTextBoxColumn
            With fec_dcto
                .DisplayIndex = 2
                .Name = "fec_dcto"
                .DataPropertyName = "fec_dcto"
                .HeaderText = "Fec. Dcto."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(fec_dcto)
            '
            Dim tip_comp As New DataGridViewTextBoxColumn
            With tip_comp
                .DisplayIndex = 3
                .Name = "tip_comp"
                .DataPropertyName = "tip_comp"
                .HeaderText = "Tip. Comp."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(tip_comp)
            '
            Dim nro_dcto As New DataGridViewTextBoxColumn
            With nro_dcto
                .DisplayIndex = 4
                .Name = "nro_dcto"
                .DataPropertyName = "nro_dcto"
                .HeaderText = "Nº Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(nro_dcto)
            '
            Dim direccion As New DataGridViewTextBoxColumn
            With direccion
                .DisplayIndex = 5
                .Name = "direccion"
                .DataPropertyName = "direccion"
                .HeaderText = "Dirección"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(direccion)
            '
            Dim fecha_incidencia As New DataGridViewTextBoxColumn
            With fecha_incidencia
                .DisplayIndex = 6
                .Name = "fecha_incidencia"
                .DataPropertyName = "fecha_incidencia"
                .HeaderText = "Fec. Incidencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(fecha_incidencia)
            '
            Dim incidencia As New DataGridViewTextBoxColumn
            With incidencia
                .DisplayIndex = 7
                .Name = "incidencia"
                .DataPropertyName = "incidencia"
                .HeaderText = "Incidencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(incidencia)
            ' 
            Dim sobres As New DataGridViewTextBoxColumn
            With sobres '
                .DisplayIndex = 8
                .DataPropertyName = "sobres"
                .Name = "sobres"
                .HeaderText = "Cant. Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(sobres)
            '
            Dim total_bulto As New DataGridViewTextBoxColumn
            With total_bulto
                .DisplayIndex = 9
                .DataPropertyName = "total_bultos"
                .Name = "total_bultos"
                .HeaderText = "Cant. bultos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_bulto)
            '
            Dim total_peso As New DataGridViewTextBoxColumn
            With total_peso
                .DisplayIndex = 10
                .DataPropertyName = "total_peso"
                .Name = "total_peso"
                .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_peso)
            '
            Dim total_costo As New DataGridViewTextBoxColumn
            With total_costo
                .DisplayIndex = 11
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = "Total Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos.Columns.Add(total_costo)
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        '
    End Sub

#End Region
#Region "Procedimientos"
    Sub totales()
        Dim ll_cantidad_sobres As Long
        Dim ll_cantidad_bultos As Long
        Dim ld_total_peso As Double
        Dim ld_total_costo As Double
        Dim ll_fila As Long
        Try
            '
            ll_cantidad_sobres = 0
            ll_cantidad_bultos = 0
            ld_total_peso = 0
            ld_total_costo = 0
            '
            For ll_fila = 0 To Me.dgv_datos.Rows.Count - 1
                ll_cantidad_sobres = ll_cantidad_sobres + CType(Me.dgv_datos.Rows(ll_fila).Cells("sobres").Value, Long)
                If Me.cmbtiporeporte.SelectedValue = 1 Then ' Resumen 
                    ll_cantidad_bultos = ll_cantidad_bultos + CType(Me.dgv_datos.Rows(ll_fila).Cells("total_bulto").Value, Long)
                Else
                    ll_cantidad_bultos = ll_cantidad_bultos + CType(Me.dgv_datos.Rows(ll_fila).Cells("total_bultos").Value, Long)
                End If
                ld_total_peso = ld_total_peso + CType(Me.dgv_datos.Rows(ll_fila).Cells("total_peso").Value, Double)
                ld_total_costo = ld_total_costo + CType(Me.dgv_datos.Rows(ll_fila).Cells("total_costo").Value, Double)
            Next
            ' 
            Me.lab_nro_registro.Text = "Total registro : " + CType(Me.dgv_datos.Rows.Count, String)
            Me.txt_costo.Text = Format(ld_total_costo, "###,###,###,###.00")
            Me.txt_tot_sobres.Text = ll_cantidad_sobres
            Me.txt_total_peso.Text = Format(ld_total_peso, "###,###,###,###.00")
            Me.txtbultos.Text = ll_cantidad_bultos
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "sistema de Seguridad")
        End Try
    End Sub
#End Region
    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub dgv_datos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_datos.CellContentClick

    End Sub

    Private Sub dgv_datos_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv_datos.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv_datos), 0)
    End Sub

    Private Sub dgv_datos_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv_datos.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv_datos), 0)
    End Sub

    Private Sub cmb_tipo_consulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_tipo_consulta.SelectedIndexChanged
        Me.dgv_datos.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.dgv_datos.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.dgv_datos.DataSource = Nothing
    End Sub

    Private Sub cmb_ciudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_ciudad.SelectedIndexChanged
        Me.dgv_datos.DataSource = Nothing
    End Sub

    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Me.dgv_datos.DataSource = Nothing
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Me.dgv_datos.DataSource = Nothing
    End Sub

    Private Sub chk_cantidad_envio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cantidad_envio.CheckedChanged
        Me.dgv_datos.DataSource = Nothing
    End Sub
End Class
