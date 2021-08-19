Public Class frmconsulta_dctos_entregados
    Dim ObjReport As ClsLbTepsa.dtoFrmReport
    Dim objconsulta_dctos As New dto_consulta_dctos
    Dim bIngreso As Boolean = False
    Public hnd As Long
#Region "Variables"
    Dim dt_estado_gt, dtciudad_origen, dtciudad_destino, dt_agencia_origen, dt_agencia_destino As New DataTable
    Dim dt_recupera_datos As New DataTable
    Dim dv_recupera_datos As New DataView
    Dim dv_estado_gt, dv_agencia_origen, dv_agencia_destino As New DataView
    Public dvciudad_origen, dvciudad_destino As New DataView
    'Variables generales 
    'Dim odba As New OleDb.OleDbDataAdapter
#End Region
#Region "Eventos y Funciones"

    Private Sub frmconsulta_dctos_entregados_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmconsulta_dctos_entregados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmdespacho_vs_recepcion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Dim rst_agencia, rst_ciudad, rst_estado As New ADODB.Recordset
            'Dim rst_estado_gt As New ADODB.Recordset
            '---------------
            'Cargando valores inciales al formulario 
            Me.DTPFECHAINICIOFACTURA.Value = dtoUSUARIOS.dfecha_sistema
            Me.DTPFECHAFINALFACTURA.Value = dtoUSUARIOS.dfecha_sistema
            '-- objsalidavehiculodespacho.fnLoad_salida_vehiculo()
            Me.ShadowLabel1.Text = "Consulta de documentos entregado"
            '
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
            'odba.Fill(dtciudad_origen, rst_ciudad)
            'odba.Fill(dt_agencia_origen, rst_agencia)
            'odba.Fill(dt_estado_gt, rst_estado_gt)
            ' 
            Dim lds_tmp As New DataSet
            lds_tmp = objconsulta_dctos.fn_carga_datos()
            dtciudad_origen = lds_tmp.Tables(0)
            dt_agencia_origen = lds_tmp.Tables(1)
            'dt_estado = lds_tmp.Tables(2)
            dt_estado_gt = lds_tmp.Tables(3)
            '
            dtciudad_destino = dtciudad_origen.Copy
            dt_agencia_destino = dt_agencia_origen.Copy
            dvciudad_origen = CargarCombo(Me.CBIDUNIDAD_AGENCIA, dtciudad_origen, "nombre_unidad", "idunidad_agencia", 0)
            dvciudad_destino = CargarCombo(Me.CBIDUNIDAD_AGENCIA_DESTINO, dtciudad_destino, "nombre_unidad", "idunidad_agencia", 0)
            dv_agencia_origen = CargarCombo(Me.cmb_agencia_origen, dt_agencia_origen, "nombre_agencia", "idagencias", 0)
            dv_agencia_destino = CargarCombo(Me.cmb_agencia_destino, dt_agencia_destino, "nombre_agencia", "idagencias", 0)
            '
            Me.rb_entregado.Checked = True
            '
            ' Debe cargar toda la grilla. 
            grillaformato()
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
            '
            dgv_datos_entregados.Columns.Clear()   'Limpiando la grilla 
            '
            With dgv_datos_entregados
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
            Dim nu_docu_suna As New DataGridViewTextBoxColumn
            With nu_docu_suna  '0
                .DisplayIndex = 0
                .DataPropertyName = "nu_docu_suna"
                .Name = "nu_docu_suna"
                .HeaderText = "Codigo Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(nu_docu_suna)
            '                        
            Dim razon_social As New DataGridViewTextBoxColumn
            With razon_social '1
                .DisplayIndex = 1
                .Name = "razon_social"
                .DataPropertyName = "razon_social"
                .HeaderText = "Razón Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(razon_social)
            '
            Dim documento As New DataGridViewTextBoxColumn
            With documento '2
                .DisplayIndex = 2
                .DataPropertyName = "documento"
                .Name = "documento"
                .HeaderText = "Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(documento)
            '
            Dim fecha_guia As New DataGridViewTextBoxColumn
            With fecha_guia ' 3
                .DisplayIndex = 3
                .DataPropertyName = "fecha_guia"
                .Name = "fecha_guia"
                .HeaderText = "Fecha Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(fecha_guia)
            '
            Dim codigo_iata_origen As New DataGridViewTextBoxColumn
            With codigo_iata_origen ' 4
                .DisplayIndex = 4
                .DataPropertyName = "codigo_iata_origen"
                .Name = "codigo_iata_origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(codigo_iata_origen)
            '
            Dim codigo_iata_destino As New DataGridViewTextBoxColumn
            With codigo_iata_destino '5
                .DisplayIndex = 5
                .DataPropertyName = "codigo_iata_destino"
                .Name = "codigo_iata_destino"
                .HeaderText = "Destino"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(codigo_iata_destino)
            '
            Dim fecha_llegada_bus As New DataGridViewTextBoxColumn
            With fecha_llegada_bus  '6
                .DisplayIndex = 6
                .DataPropertyName = "fecha_llegada_bus"
                .Name = "fecha_llegada_bus"
                .HeaderText = "Fecha recepción"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(fecha_llegada_bus)
            '
            Dim tipo_entrega_carga As New DataGridViewTextBoxColumn
            With tipo_entrega_carga  '7
                .DisplayIndex = 7
                .DataPropertyName = "tipo_entrega_carga"
                .Name = "tipo_entrega_carga"
                .HeaderText = "Se entrega en"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(tipo_entrega_carga)
            '
            Dim estado_registro As New DataGridViewTextBoxColumn
            With estado_registro '8
                .DisplayIndex = 8
                .DataPropertyName = "estado_registro"
                .Name = "estado_registro"
                .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(estado_registro)
            '
            Dim total_bultos As New DataGridViewTextBoxColumn
            With total_bultos '9
                .DisplayIndex = 9
                .DataPropertyName = "total_bultos"
                .Name = "total_bultos"
                .HeaderText = "Total Bultos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(total_bultos)
            '
            Dim total_costo As New DataGridViewTextBoxColumn
            With total_costo '10
                .DisplayIndex = 10
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = "Total Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(total_costo)
            '
            Dim fecha_entrega As New DataGridViewTextBoxColumn
            With fecha_entrega '11
                .DisplayIndex = 11
                .Name = "fecha_entrega"
                .DataPropertyName = "fecha_entrega"
                .HeaderText = "Fec. Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(fecha_entrega)
            '
            Dim nombre_entrega As New DataGridViewTextBoxColumn
            With nombre_entrega '12
                .DisplayIndex = 12
                .Name = "nombre_entrega"
                .DataPropertyName = "nombre_entrega"
                .HeaderText = "Entregado a"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(nombre_entrega)
            ' 
            Dim dctos_anexos As New DataGridViewTextBoxColumn
            With dctos_anexos '13
                .DisplayIndex = 13
                .Name = "dctos_anexos"
                .DataPropertyName = "dctos_anexos"
                .HeaderText = "Dctos Anexos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(dctos_anexos)
            ' 
            Dim responsable As New DataGridViewTextBoxColumn
            With responsable '14
                .DisplayIndex = 14
                .Name = "responsable"
                .DataPropertyName = "responsable"
                .HeaderText = "Responsable"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(responsable)
            '
            Dim nro_incidencia As New DataGridViewTextBoxColumn
            With nro_incidencia '15
                .DisplayIndex = 15
                .Name = "nro_incidencia"
                .DataPropertyName = "nro_incidencia"
                .HeaderText = "Nº Incidencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(nro_incidencia)
            '
            Dim fec_incidencia_ult As New DataGridViewTextBoxColumn
            With fec_incidencia_ult '15
                .DisplayIndex = 16
                .Name = "fec_incidencia_ult"
                .DataPropertyName = "fec_incidencia_ult"
                .HeaderText = "Fec. Ult. Incidencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dgv_datos_entregados.Columns.Add(fec_incidencia_ult)
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btn_filtrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_filtrar.Click
        '   Dim lrst_recordset As New ADODB.Recordset
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
            If Me.rb_entregado.Checked = True Then
                objconsulta_dctos.idestado_envio = 1
            End If
            If Me.rb_no_entregado.Checked = True Then
                objconsulta_dctos.idestado_envio = 0
            End If
            '
            'Invocando la consulta 
            '
            ' Labnroreg.Text = "Nº de Registro(s) 0 "            
            'Mod.06/10/2009 -->Omendoza - Pasando al datahelper -  
            'lrst_recordset = objconsulta_dctos.fn_recupera_datos_dctos_entregado
            'odba.Fill(dt_recupera_datos, lrst_recordset)
            '
            dt_recupera_datos = objconsulta_dctos.fn_recupera_datos_dctos_entregado
            dv_recupera_datos = dt_recupera_datos.DefaultView
            '
            grillaformato()
            dgv_datos_entregados.DataSource = dv_recupera_datos
            '
            ' Labnroreg.Text = "Nº de Registro(s) " + CType(dv_seguimiento.Count, String)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
#End Region

    Private Sub dgv_datos_entregados_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv_datos_entregados.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv_datos_entregados) - 1, 0)
    End Sub
    Private Sub DGV_destino_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgv_datos_entregados.Scroll
        Dim a As Integer
        Try
            a = e.NewValue
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmconsulta_dctos_registrados_MenuImprimir() Handles Me.MenuImprimir
        Try
            Dim ll_entregado As Long
            Dim ls_mensaje As String
            Dim ll_ciudad_origen, ll_ciudad_destino, ll_agencia_origen, ll_agencia_destino As Long
            Try
                ObjReport.Dispose()
            Catch
            End Try
            ObjReport = New ClsLbTepsa.dtoFrmReport
            '
            ll_ciudad_origen = CType(Me.CBIDUNIDAD_AGENCIA.SelectedValue, Long)
            ll_ciudad_destino = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Long)
            ll_agencia_origen = CType(Me.cmb_agencia_origen.SelectedValue, Long)
            ll_agencia_destino = CType(Me.cmb_agencia_destino.SelectedValue, Long)
            '
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            '
            If Me.rb_entregado.Checked = True Then
                ll_entregado = 1
                ls_mensaje = "Documentos Entregados "
            End If
            If Me.rb_no_entregado.Checked = True Then
                ll_entregado = 0
                ls_mensaje = "Documentos No Entregados "
            End If
            ObjReport.printrptB(False, "", "DCTO003.rpt", _
            "p_titulo;" & ls_mensaje + " del " & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString & " al " & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString & "", _
            "VI_FECHA_INCIO;" & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString, _
            "VI_FECHA_FINAL;" & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString, _
            "NI_IND_ENTREGADO;" & ll_entregado, _
            "NI_IDUNIDAD_AGENCIA_ORI;" & ll_ciudad_origen, _
            "NI_IDUNIDAD_AGENCIA_DES;" & ll_ciudad_destino, _
            "NI_IDAGENCIA_ORI;" & ll_agencia_origen, _
            "NI_IDAGENCIA_DES;" & ll_agencia_destino)


            '    ' '' '' ''dtciudad_origen = Nothing
            '    ' '' '' ''dvciudad_origen = Nothing
            '    ' '' '' ''grillaformato_det()
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

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub dgv_datos_entregados_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_datos_entregados.CellContentClick

    End Sub

    Private Sub dgv_datos_entregados_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv_datos_entregados.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv_datos_entregados) - 1, 0)
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.dgv_datos_entregados.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.dgv_datos_entregados.DataSource = Nothing
    End Sub

    Private Sub rb_entregado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_entregado.CheckedChanged
        Me.dgv_datos_entregados.DataSource = Nothing
    End Sub

    Private Sub rb_no_entregado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_no_entregado.CheckedChanged
        Me.dgv_datos_entregados.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged
        Me.dgv_datos_entregados.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndexChanged
        Me.dgv_datos_entregados.DataSource = Nothing
    End Sub

    Private Sub cmb_agencia_origen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_agencia_origen.SelectedIndexChanged
        Me.dgv_datos_entregados.DataSource = Nothing
    End Sub

    Private Sub cmb_agencia_destino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_agencia_destino.SelectedIndexChanged
        Me.dgv_datos_entregados.DataSource = Nothing
    End Sub
End Class
