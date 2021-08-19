Public Class frmconsulta_dctos_registrados
    Dim ObjReport As ClsLbTepsa.dtoFrmReport
    Dim objconsulta_dctos As New dto_consulta_dctos
    Dim bIngreso As Boolean = False
    Public hnd As Long
#Region "Variables"
    Dim dt_estado_envio, dtciudad_origen, dtciudad_destino, dt_agencia_origen, dt_agencia_destino As New DataTable
    Dim dt_recupera_datos As New DataTable
    Dim dv_recupera_datos As New DataView
    Dim dv_estado_envio, dv_agencia_origen, dv_agencia_destino As New DataView
    'Dim rst_agencia, rst_ciudad, rst_estado As New ADODB.Recordset
    Public dvciudad_origen, dvciudad_destino As New DataView
    'Variables generales 
    'Dim odba As New OleDb.OleDbDataAdapter
#End Region
#Region "Eventos y Funciones"

    Private Sub frmconsulta_dctos_registrados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmdespacho_vs_recepcion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '---------------
            'Cargando valores inciales al formulario 
            Me.DTPFECHAINICIOFACTURA.Value = dtoUSUARIOS.dfecha_sistema
            Me.DTPFECHAFINALFACTURA.Value = dtoUSUARIOS.dfecha_sistema
            '-- objsalidavehiculodespacho.fnLoad_salida_vehiculo()
            Me.ShadowLabel1.Text = "Consulta de documentos registrados"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            ' 
            MenuTab.Items(0).Text = "Consulta"
            '
            MenuTab.Items(0).Enabled = True
            MenuTab.Items(0).Visible = True
            '
            'NuevoToolStripMenuItem1.Enabled = False
            'NuevoToolStripMenuItem1.Visible = False
            EdicionToolStripMenuItem.Enabled = False
            EdicionToolStripMenuItem.Visible = False
            '
            SalirToolStripMenuItem.Enabled = True
            SalirToolStripMenuItem.Visible = True
            'Mod.06/10/2009 -->Omendoza - Pasando al datahelper -  

            'rst_ciudad = objconsulta_dctos.fn_carga_datos()
            'rst_agencia = rst_ciudad.NextRecordset
            'rst_estado = rst_ciudad.NextRecordset
            ' odba.Fill(dtciudad_origen, rst_ciudad)
            '       odba.Fill(dt_agencia_origen, rst_agencia)
            'odba.Fill(dt_estado_envio, rst_estado)
            '
            Dim lds_tmp As New DataSet
            lds_tmp = objconsulta_dctos.fn_carga_datos()
            '
            dtciudad_origen = lds_tmp.Tables(0)
            dt_agencia_origen = lds_tmp.Tables(1)
            dt_estado_envio = lds_tmp.Tables(2)
            '
            dtciudad_destino = dtciudad_origen.Copy
            dt_agencia_destino = dt_agencia_origen.Copy
            '
            dvciudad_origen = CargarCombo(Me.CBIDUNIDAD_AGENCIA, dtciudad_origen, "nombre_unidad", "idunidad_agencia", 0)
            dvciudad_destino = CargarCombo(Me.CBIDUNIDAD_AGENCIA_DESTINO, dtciudad_destino, "nombre_unidad", "idunidad_agencia", 0)
            '
            dv_agencia_origen = CargarCombo(Me.cmb_agencia_origen, dt_agencia_origen, "nombre_agencia", "idagencias", 0)
            dv_agencia_destino = CargarCombo(Me.cmb_agencia_destino, dt_agencia_destino, "nombre_agencia", "idagencias", 0)
            '
            dv_estado_envio = CargarCombo(Me.cmb_estado_envio, dt_estado_envio, "estado_registro", "idestado_registro", 0)
            ' Debe cargar toda la grilla. 
            grillaformato()
            '
            ' Labnroreg.Text = "Nº de Registro(s) 0"

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub grillaformato()
        Try
            DGV_documentos.Columns.Clear()   'Limpiando la grilla 

            With DGV_documentos
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                .AutoGenerateColumns = False
                '    '.DataSource = dtable_Lista_Control_Comprobante
                '    .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            '
            Dim codigo_cliente As New DataGridViewTextBoxColumn
            With codigo_cliente  '0
                .DisplayIndex = 0
                .DataPropertyName = "codigo_cliente"
                .Name = "codigo_cliente"
                .HeaderText = "Codigo Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(codigo_cliente)
            '                        
            Dim razon_social As New DataGridViewTextBoxColumn
            With razon_social '1
                .DisplayIndex = 1
                .Name = "razon_social"
                .DataPropertyName = "razon_social"
                .HeaderText = "Razón Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(razon_social)
            '
            Dim nro_documento As New DataGridViewTextBoxColumn
            With nro_documento '2
                .DisplayIndex = 2
                .DataPropertyName = "nro_documento"
                .Name = "nro_documento"
                .HeaderText = "Nº Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(nro_documento)
            '
            Dim fecha_guia As New DataGridViewTextBoxColumn
            With fecha_guia ' 3
                .DisplayIndex = 3
                .DataPropertyName = "fecha_guia"
                .Name = "fecha_guia"
                .HeaderText = "Fecha Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(fecha_guia)
            '
            Dim cod_iata_origen As New DataGridViewTextBoxColumn
            With cod_iata_origen ' 4
                .DisplayIndex = 4
                .DataPropertyName = "cod_iata_origen"
                .Name = "cod_iata_origen"
                .HeaderText = "Ciudad Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(cod_iata_origen)
            '
            Dim cod_iata_destino As New DataGridViewTextBoxColumn
            With cod_iata_destino '5
                .DisplayIndex = 5
                .DataPropertyName = "cod_iata_destino"
                .Name = "cod_iata_destino"
                .HeaderText = "Ciudad Destino"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(cod_iata_destino)
            '
            Dim cantidad_bultos As New DataGridViewTextBoxColumn
            With cantidad_bultos '6
                .DisplayIndex = 6
                .DataPropertyName = "cantidad_bultos"
                .Name = "cantidad_bultos"
                .HeaderText = "Cantidad Bultos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(cantidad_bultos)
            '
            Dim cant_xvolumen As New DataGridViewTextBoxColumn
            With cant_xvolumen '7
                .DisplayIndex = 7
                .DataPropertyName = "cant_xvolumen"
                .Name = "cant_xvolumen"
                .HeaderText = "Cant.Volumen "
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(cant_xvolumen)
            '
            Dim cant_articulo As New DataGridViewTextBoxColumn
            With cant_articulo '8
                .DisplayIndex = 8
                .DataPropertyName = "cant_articulo"
                .Name = "cant_articulo"
                .HeaderText = "Cant. Artículo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(cant_articulo)
            '
            Dim cant_sobre As New DataGridViewTextBoxColumn
            With cant_sobre '9
                .DisplayIndex = 9
                .Name = "cant_sobre"
                .DataPropertyName = "cant_sobre"
                .HeaderText = "Cant. Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(cant_sobre)
            '
            Dim tot_peso As New DataGridViewTextBoxColumn
            With tot_peso '10
                .DisplayIndex = 10
                .Name = "tot_peso"
                .DataPropertyName = "tot_peso"
                .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(tot_peso)
            '
            Dim tot_volumen As New DataGridViewTextBoxColumn
            With tot_volumen '11
                .DisplayIndex = 11
                .Name = "tot_volumen"
                .DataPropertyName = "tot_volumen"
                .HeaderText = "Total Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(tot_volumen)
            '
            Dim tot_subtotal As New DataGridViewTextBoxColumn
            With tot_subtotal '12
                .DisplayIndex = 12
                .Name = "tot_subtotal"
                .DataPropertyName = "tot_subtotal"
                .HeaderText = "Sub Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(tot_subtotal)
            '
            Dim tot_impuesto As New DataGridViewTextBoxColumn
            With tot_impuesto '13
                .DisplayIndex = 13
                .Name = "tot_impuesto"
                .DataPropertyName = "tot_impuesto"
                .HeaderText = "Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(tot_impuesto)
            '
            Dim tot_costo As New DataGridViewTextBoxColumn
            With tot_costo '14
                .DisplayIndex = 14
                .Name = "tot_costo"
                .DataPropertyName = "tot_costo"
                .HeaderText = "Tot. Importe"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(tot_costo)
            ' 
            Dim informacion As New DataGridViewTextBoxColumn
            With informacion '15
                .DisplayIndex = 15
                .Name = "informacion"
                .DataPropertyName = "informacion"
                .HeaderText = "Facturado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_documentos.Columns.Add(informacion)
            ' 
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btn_filtrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_filtrar.Click
        Dim lrst_recordset As New ADODB.Recordset
        Try
            'Limpiando y creando datable y dataview de la busqueda
            dt_recupera_datos = Nothing
            dv_recupera_datos = Nothing
            ' 
            dt_recupera_datos = New DataTable
            dv_recupera_datos = New DataView
            '
            objconsulta_dctos.fecha_inicio = CType(Me.DTPFECHAINICIOFACTURA.Value, String)
            objconsulta_dctos.fecha_final = CType(Me.DTPFECHAFINALFACTURA.Value, String)
            '
            objconsulta_dctos.idunidad_agencia_ori = CType(Me.CBIDUNIDAD_AGENCIA.SelectedValue, Long)
            objconsulta_dctos.idunidad_agencia_des = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Long)

            objconsulta_dctos.idagencia_ori = CType(Me.cmb_agencia_origen.SelectedValue, Long)
            objconsulta_dctos.idagencia_des = CType(Me.cmb_agencia_destino.SelectedValue, Long)
            '
            objconsulta_dctos.idestado_envio = CType(Me.cmb_estado_envio.SelectedValue, Long)
            '
            'Invocando la consulta 
            '
            ' Labnroreg.Text = "Nº de Registro(s) 0 "          
            'Mod.06/10/2009 -->Omendoza - Pasando al datahelper -  
            'lrst_recordset = objconsulta_dctos.fn_recupera_datos_dctos_registrados
            'odba.Fill(dt_recupera_datos, lrst_recordset)
            dt_recupera_datos = objconsulta_dctos.fn_recupera_datos_dctos_registrados
            dv_recupera_datos = dt_recupera_datos.DefaultView
            '
            grillaformato()
            DGV_documentos.DataSource = dv_recupera_datos
            '
            ' Labnroreg.Text = "Nº de Registro(s) " + CType(dv_seguimiento.Count, String)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
    Private Sub DGV_destino_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DGV_documentos.Scroll
        Dim a As Integer
        Try
            a = e.NewValue
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmconsulta_dctos_registrados_MenuImprimir() Handles Me.MenuImprimir
        Try
            Dim ll_estado_envio As Long
            Dim ls_mensaje As String
            Dim ll_ciudad_origen, ll_ciudad_destino, ll_agencia_origen, ll_agencia_destino As Long
            '
            Try
                ObjReport.Dispose()
            Catch
            End Try
            ObjReport = New ClsLbTepsa.dtoFrmReport
            ll_ciudad_origen = CType(Me.CBIDUNIDAD_AGENCIA.SelectedValue, Long)
            ll_ciudad_destino = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Long)
            ll_agencia_origen = CType(Me.cmb_agencia_origen.SelectedValue, Long)
            ll_agencia_destino = CType(Me.cmb_agencia_destino.SelectedValue, Long)
            ll_estado_envio = CType(Me.cmb_estado_envio.SelectedValue, Long)
            ls_mensaje = "Documentos registrados "
            '
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            '
            ObjReport.printrptB(False, "", "dcto001.rpt", _
            "p_titulo;" & ls_mensaje & " del " & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString & " al " & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString & "", _
            "VI_FECHA_INCIO;" & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString, _
            "VI_FECHA_FINAL;" & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString, _
            "NI_IDESTADO_ENVIO;" & ll_estado_envio, _
            "NI_IDUNIDAD_AGENCIA_ORI;" & ll_ciudad_origen, _
            "NI_IDUNIDAD_AGENCIA_DES;" & ll_ciudad_destino, _
            "NI_IDAGENCIA_ORI;" & ll_agencia_origen, _
            "NI_IDAGENCIA_DES;" & ll_agencia_destino)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub
    Private Sub PorRecepcionarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorRecepcionarToolStripMenuItem.Click
        Dim a As New FrmDetalleDepacho_VS_Recepcion
        'a.ShowDialog(Me)
        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            a.ShowDialog(Me)
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub PendienteDeEntregaADomicilioToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PendienteDeEntregaADomicilioToolStripMenuItem.Click
        Dim a As New FrmDetalleEntreDomiDepacho_VS_Recepcion()
        'a.ShowDialog(Me)
        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            a.ShowDialog(Me)
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
