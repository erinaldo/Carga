Public Class frmconsulta_dctos_despachados
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

    Private Sub frmconsulta_dctos_despachados_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmconsulta_dctos_despachados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
            Me.ShadowLabel1.Text = "Consulta de documentos recepcionados"
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
            'rst_estado_gt = rst_ciudad.NextRecordset
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
            '
            dvciudad_origen = CargarCombo(Me.CBIDUNIDAD_AGENCIA, dtciudad_origen, "nombre_unidad", "idunidad_agencia", 0)
            dvciudad_destino = CargarCombo(Me.CBIDUNIDAD_AGENCIA_DESTINO, dtciudad_destino, "nombre_unidad", "idunidad_agencia", 0)
            '
            dv_agencia_origen = CargarCombo(Me.cmb_agencia_origen, dt_agencia_origen, "nombre_agencia", "idagencias", 0)
            dv_agencia_destino = CargarCombo(Me.cmb_agencia_destino, dt_agencia_destino, "nombre_agencia", "idagencias", 0)
            '
            dv_estado_gt = CargarCombo(Me.cmb_gt, dt_estado_gt, "descripcion", "idestado_gt", -666)
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
            DGV_DCTO_DESPACHADOS.Columns.Clear()   'Limpiando la grilla 
            '
            With DGV_DCTO_DESPACHADOS
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
            Dim gtransportista As New DataGridViewTextBoxColumn
            With gtransportista  '0
                .DisplayIndex = 0
                .DataPropertyName = "gtransportista"
                .Name = "gtransportista"
                .HeaderText = "Guía Transportista"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(gtransportista)
            '                        
            Dim ciudad_origen_gt As New DataGridViewTextBoxColumn
            With ciudad_origen_gt '1
                .DisplayIndex = 1
                .Name = "ciudad_origen_gt"
                .DataPropertyName = "ciudad_origen_gt"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(ciudad_origen_gt)
            '
            Dim ciudad_destino_gt As New DataGridViewTextBoxColumn
            With ciudad_destino_gt '2
                .DisplayIndex = 2
                .DataPropertyName = "ciudad_destino_gt"
                .Name = "ciudad_destino_gt"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(ciudad_destino_gt)
            '
            Dim fecha_salida As New DataGridViewTextBoxColumn
            With fecha_salida ' 3
                .DisplayIndex = 3
                .DataPropertyName = "fecha_salida"
                .Name = "fecha_salida"
                .HeaderText = "Fecha Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(fecha_salida)
            '
            Dim estado_gt As New DataGridViewTextBoxColumn
            With estado_gt ' 4
                .DisplayIndex = 4
                .DataPropertyName = "estado_gt"
                .Name = "estado_gt"
                .HeaderText = "Estado Guía Trans."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(estado_gt)
            '
            Dim fecha_recepcion As New DataGridViewTextBoxColumn
            With fecha_recepcion '5
                .DisplayIndex = 5
                .DataPropertyName = "fecha_recepcion"
                .Name = "fecha_recepcion"
                .HeaderText = "Fecha Recepción"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(fecha_recepcion)
            '
            Dim hora_recepcion As New DataGridViewTextBoxColumn
            With hora_recepcion '6
                .DisplayIndex = 6
                .DataPropertyName = "hora_recepcion"
                .Name = "hora_recepcion"
                .HeaderText = "Hora Recepción"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(hora_recepcion)
            '
            Dim codigo_cliente As New DataGridViewTextBoxColumn
            With codigo_cliente '7
                .DisplayIndex = 7
                .DataPropertyName = "codigo_cliente"
                .Name = "codigo_cliente"
                .HeaderText = "Código cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(codigo_cliente)
            '
            Dim razon_social As New DataGridViewTextBoxColumn
            With razon_social '8
                .DisplayIndex = 8
                .DataPropertyName = "razon_social"
                .Name = "razon_social"
                .HeaderText = "Razon Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(razon_social)
            '
            Dim documento As New DataGridViewTextBoxColumn
            With documento '9
                .DisplayIndex = 9
                .Name = "documento"
                .DataPropertyName = "documento"
                .HeaderText = "Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(documento)
            '
            Dim ciudad_origen_dcto As New DataGridViewTextBoxColumn
            With ciudad_origen_dcto '10
                .DisplayIndex = 10
                .Name = "ciudad_origen_dcto"
                .DataPropertyName = "ciudad_origen_dcto"
                .HeaderText = "Origen Dcto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(ciudad_origen_dcto)
            '
            Dim ciudad_destino_dcto As New DataGridViewTextBoxColumn
            With ciudad_destino_dcto '11
                .DisplayIndex = 11
                .Name = "ciudad_destino_dcto"
                .DataPropertyName = "ciudad_destino_dcto"
                .HeaderText = "Destino Dcto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(ciudad_destino_dcto)
            '
            Dim agencia_destino As New DataGridViewTextBoxColumn
            With agencia_destino '12
                .DisplayIndex = 12
                .Name = "agencia_destino"
                .DataPropertyName = "agencia_destino"
                .HeaderText = "Destino Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(agencia_destino)
            '
            Dim cantidad As New DataGridViewTextBoxColumn
            With cantidad '13
                .DisplayIndex = 13
                .Name = "cantidad"
                .DataPropertyName = "cantidad"
                .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(cantidad)
            '
            Dim cantidad_recepcionar As New DataGridViewTextBoxColumn
            With cantidad_recepcionar '14
                .DisplayIndex = 14
                .Name = "cantidad_recepcionar"
                .DataPropertyName = "cantidad_recepcionar"
                .HeaderText = "Cant. Recepcionar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_DCTO_DESPACHADOS.Columns.Add(cantidad_recepcionar)
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
            If Me.cmb_gt.Text = "" Then
                objconsulta_dctos.idestado_envio = -666
            Else
                objconsulta_dctos.idestado_envio = CType(Me.cmb_gt.SelectedValue, Long)
            End If

            '
            'Invocando la consulta 
            '
            ' Labnroreg.Text = "Nº de Registro(s) 0 "            
            'Mod.06/10/2009 -->Omendoza - Pasando al datahelper -  
            'lrst_recordset = objconsulta_dctos.fn_recupera_datos_dctos_despachados
            'odba.Fill(dt_recupera_datos, lrst_recordset)
            '
            dt_recupera_datos = objconsulta_dctos.fn_recupera_datos_dctos_despachados()
            dv_recupera_datos = dt_recupera_datos.DefaultView
            '
            grillaformato()
            DGV_DCTO_DESPACHADOS.DataSource = dv_recupera_datos
            '
            ' Labnroreg.Text = "Nº de Registro(s) " + CType(dv_seguimiento.Count, String)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
#End Region

    Private Sub DGV_DCTO_DESPACHADOS_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV_DCTO_DESPACHADOS.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV_DCTO_DESPACHADOS) - 1, 0)
    End Sub
    Private Sub DGV_destino_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DGV_DCTO_DESPACHADOS.Scroll
        Dim a As Integer
        Try
            a = e.NewValue
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmconsulta_dctos_registrados_MenuImprimir() Handles Me.MenuImprimir
        Try
            Dim ll_recepcionado As Long
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
            If Me.cmb_gt.Text = "" Then
                ll_recepcionado = -666
            Else
                ll_recepcionado = CType(Me.cmb_gt.SelectedValue, Long)
            End If


            ls_mensaje = "Documentos recepcionados "
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)

            ObjReport.printrptB(False, "", "dcto002.rpt", _
            "p_titulo;" & ls_mensaje & " del " & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString & " al " & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString & "", _
            "VI_FECHA_INCIO;" & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString, _
            "VI_FECHA_FINAL;" & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString, _
            "NI_IDUNIDAD_AGENCIA_ORI;" & ll_ciudad_origen, _
            "NI_IDUNIDAD_AGENCIA_DES;" & ll_ciudad_destino, _
            "NI_IDAGENCIA_ORI;" & ll_agencia_origen, _
            "NI_IDAGENCIA_DES;" & ll_agencia_destino, _
            "NI_RECEPCIONADO;" & ll_recepcionado)

            ' '' '' ''dtciudad_origen = Nothing
            ' '' '' ''dvciudad_origen = Nothing
            ' '' '' ''grillaformato_det()
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

    Private Sub DGV_DCTO_DESPACHADOS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_DCTO_DESPACHADOS.CellContentClick

    End Sub

    Private Sub DGV_DCTO_DESPACHADOS_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGV_DCTO_DESPACHADOS.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV_DCTO_DESPACHADOS) - 1, 0)
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.DGV_DCTO_DESPACHADOS.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.DGV_DCTO_DESPACHADOS.DataSource = Nothing
    End Sub

    Private Sub cmb_gt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_gt.SelectedIndexChanged
        Me.DGV_DCTO_DESPACHADOS.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged
        Me.DGV_DCTO_DESPACHADOS.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndexChanged
        Me.DGV_DCTO_DESPACHADOS.DataSource = Nothing
    End Sub

    Private Sub cmb_agencia_origen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_agencia_origen.SelectedIndexChanged
        Me.DGV_DCTO_DESPACHADOS.DataSource = Nothing
    End Sub

    Private Sub cmb_agencia_destino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_agencia_destino.SelectedIndexChanged
        Me.DGV_DCTO_DESPACHADOS.DataSource = Nothing
    End Sub
End Class
