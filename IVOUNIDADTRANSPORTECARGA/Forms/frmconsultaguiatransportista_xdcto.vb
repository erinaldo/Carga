Public Class frmconsultaguiatransportista_xdcto
#Region "Variables"
    'Dim odba As New OleDb.OleDbDataAdapter
    Dim dtciudad_origen, dtciudad_destino, dttipo_servicio, dtestado, dt_seguimiento As New DataTable
    Dim dvciudad_origen, dvciudad_destino, dvtipo_servicio, dvestado, dv_seguimiento As New DataView
    Dim bIngreso As Boolean = False
    Public hnd As Long
#End Region
#Region "Eventos"

    Private Sub frmconsultaguiatransportista_xdcto_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmconsultaguiatransportista_xdcto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmconsultaguiatransportista_xdcto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '---------------
            'Cargando valores inciales al formulario 
            DTPFECHAINICIOFACTURA.Value = dtoUSUARIOS.dfecha_sistema
            DTPFECHAFINALFACTURA.Value = dtoUSUARIOS.dfecha_sistema
            '-- objsalidavehiculodespacho.fnLoad_salida_vehiculo()
            Me.ShadowLabel1.Text = "Consulta de Documentos por Guía de Transportista"
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
            'Mod.07/10/2009 -->Omendoza - Pasando al datahelper -  
            If ObjGuia_Transp_xdcto.fn_load_seguimiento_carga Then
                'odba.Fill(dtciudad_origen, ObjGuia_Transp_xdcto.rst_ciudad)
                'odba.Fill(dttipo_servicio, ObjGuia_Transp_xdcto.rst_tipo_servicio)
                'odba.Fill(dtestado, ObjGuia_Transp_xdcto.rst_estado)
                dtciudad_origen = ObjGuia_Transp_xdcto.dt_rst_ciudad
                dttipo_servicio = ObjGuia_Transp_xdcto.dt_rst_tipo_servicio
                dtestado = ObjGuia_Transp_xdcto.dt_rst_estado
                '
                dtciudad_destino = dtciudad_origen.Copy
            Else
                MsgBox("No se ha podido establecer, los valores de ayuda", MsgBoxStyle.Critical, "Sistema de Seguridad")
                Me.Close()
                Exit Sub
            End If
            '
            dvciudad_origen = CargarCombo(Me.CBIDUNIDAD_AGENCIA, dtciudad_origen, "nombre_unidad", "idunidad_agencia", -666)
            dvciudad_destino = CargarCombo(Me.CBIDUNIDAD_AGENCIA_DESTINO, dtciudad_destino, "nombre_unidad", "idunidad_agencia", -666)
            dvtipo_servicio = CargarCombo(Me.cbidtipo_servicio, dttipo_servicio, "tipo_servicio", "idtipo_servicio", -666)  'Servicios 
            dvestado = CargarCombo(Me.cmbestado, dtestado, "estado_registro", "idestado_registro", -666)
            ' Debe cargar toda la grilla. 
            grillaformato()
            '
            Labnroreg.Text = "Nº de Registro(s) 0"
            Me.Txttot_cantidad.Text = 0.0
            Me.txttotdespacho.Text = 0.0
            Me.txttotrecepcionado.Text = 0.0
            Me.txttotal_entregado.Text = 0.0

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub btn_filtrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_filtrar.Click
        Try
            'Limpiando y creando datable y dataview de la busqueda
            dt_seguimiento = Nothing
            dv_seguimiento = Nothing
            ' 
            dt_seguimiento = New DataTable
            dv_seguimiento = New DataView
            '
            ObjGuia_Transp_xdcto.sfecha_inicio = CType(Me.DTPFECHAINICIOFACTURA.Value, String)
            ObjGuia_Transp_xdcto.sfecha_final = CType(Me.DTPFECHAFINALFACTURA.Value, String)
            ObjGuia_Transp_xdcto.lciudad_origen = CType(Me.CBIDUNIDAD_AGENCIA.SelectedValue, Long)
            ObjGuia_Transp_xdcto.lciudad_destino = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Long)
            ObjGuia_Transp_xdcto.lidtipo_servicio = CType(Me.cbidtipo_servicio.SelectedValue, Long)
            If Me.TBnro_unidad_transporte.Text = "" Then
                ObjGuia_Transp_xdcto.lnro_unidad_transporte = -666
            Else
                ObjGuia_Transp_xdcto.lnro_unidad_transporte = CType(Me.TBnro_unidad_transporte.Text, Long)
            End If
            ObjGuia_Transp_xdcto.lidestado = CType(Me.cmbestado.SelectedValue, Long)
            If Me.txtcliente.Text = "" Then
                ObjGuia_Transp_xdcto.srazon_social = "%"
            Else
                ObjGuia_Transp_xdcto.srazon_social = "%" + Me.txtcliente.Text + "%"
            End If
            'Invocando la consulta 
            Labnroreg.Text = "Nº de Registro(s) 0 "
            Me.Txttot_cantidad.Text = 0.0
            Me.txttotdespacho.Text = 0.0
            Me.txttotrecepcionado.Text = 0.0
            Me.txttotal_entregado.Text = 0.0
            If ObjGuia_Transp_xdcto.fn_get_seguimiento_carga() Then
                'Mod.07/10/2009 -->Omendoza - Pasando al datahelper -
                'odba.Fill(dt_seguimiento, ObjGuia_Transp_xdcto.rst_seguimiento_carga)
                dt_seguimiento = ObjGuia_Transp_xdcto.dt_rst_seguimiento_carga
                dv_seguimiento = dt_seguimiento.DefaultView
                dvg_guia_transportista_xdcto.DataSource = dv_seguimiento
                Labnroreg.Text = "Nº de Registro(s) " + CType(dv_seguimiento.Count, String)
                'Totaliza                
                totaliza()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try

    End Sub
#End Region
#Region "Procedimientos y Funciones"
    Sub grillaformato()
        Try
            dvg_guia_transportista_xdcto.Columns.Clear()   'Limpiando la grilla 
            With dvg_guia_transportista_xdcto
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                '    .AutoGenerateColumns = False
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
            Dim dgv_nro_guia As New DataGridViewTextBoxColumn
            With dgv_nro_guia '0
                .DisplayIndex = 0
                .DataPropertyName = "nro_guia"
                .Name = "nro_guia"
                .HeaderText = "Nº Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_nro_guia)
            '                        
            Dim dgv_fecha_guia As New DataGridViewTextBoxColumn
            With dgv_fecha_guia  '1
                .DisplayIndex = 1
                .Name = "fecha_guia"
                .DataPropertyName = "fecha_guia"
                .HeaderText = "Fec. Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_fecha_guia)
            '
            Dim dvg_razon_social As New DataGridViewTextBoxColumn
            With dvg_razon_social '2
                .DisplayIndex = 2
                .DataPropertyName = "razon_social"
                .Name = "dvg_razon_social"
                .HeaderText = "Razón Social y/o Apellido(s) y Nombre(s)"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dvg_razon_social)
            '
            Dim dgv_ciudad_origen As New DataGridViewTextBoxColumn
            With dgv_ciudad_origen ' 3
                .DisplayIndex = 3
                .DataPropertyName = "ciudad_origen"
                .Name = "ciudad_origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_ciudad_origen)
            '
            Dim dgv_ciudad_destino As New DataGridViewTextBoxColumn
            With dgv_ciudad_destino ' 4
                .DisplayIndex = 4
                .DataPropertyName = "ciudad_destino"
                .Name = "ciudad_destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_ciudad_destino)
            '
            Dim dgv_guiatransportista As New DataGridViewTextBoxColumn
            With dgv_guiatransportista '5
                .DisplayIndex = 5
                .DataPropertyName = "guiatransportista"
                .Name = "guiatransportista"
                .HeaderText = "Guía Transportista"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_guiatransportista)
            '
            Dim dgv_Fecha_Salida As New DataGridViewTextBoxColumn
            With dgv_Fecha_Salida '6
                .DisplayIndex = 6
                .DataPropertyName = "Fecha_Salida"
                .Name = "Fecha_Salida"
                .HeaderText = "Fec. Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_Fecha_Salida)
            '
            Dim dgv_hora_salida As New DataGridViewTextBoxColumn
            With dgv_hora_salida '7
                .DisplayIndex = 7
                .DataPropertyName = "hora_salida"
                .Name = "hora_salida"
                .HeaderText = "Hora Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_hora_salida)
            '
            Dim dgv_Estado_guia_tra As New DataGridViewTextBoxColumn
            With dgv_Estado_guia_tra '8
                .DisplayIndex = 8
                .DataPropertyName = "Estado_guia_tra"
                .Name = "Estado_guia_tra"
                .HeaderText = "Estado Guía Trans."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_Estado_guia_tra)
            '
            Dim dgv_tipo_servicio As New DataGridViewTextBoxColumn
            With dgv_tipo_servicio '9
                .DisplayIndex = 9
                .Name = "tipo_servicio"
                .DataPropertyName = "tipo_servicio"
                .HeaderText = "Tipo Servicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_tipo_servicio)
            '
            Dim dgv_fecha_llegada As New DataGridViewTextBoxColumn
            With dgv_fecha_llegada '10
                .DisplayIndex = 10
                .Name = "fecha_llegada"
                .DataPropertyName = "fecha_llegada"
                .HeaderText = "Fecha llegada"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_fecha_llegada)
            '
            Dim dgv_hora_llegada As New DataGridViewTextBoxColumn
            With dgv_hora_llegada '11
                .DisplayIndex = 11
                .DataPropertyName = "hora_llegada"
                .Name = "hora_llegada"
                .HeaderText = "Hora Llegada"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_hora_llegada)
            '
            Dim dgv_idestado_envio As New DataGridViewTextBoxColumn
            With dgv_idestado_envio '12
                .DisplayIndex = 12
                .DataPropertyName = "idestado_envio"
                .Name = "idestado_envio"
                .HeaderText = "Estado Dcto."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_idestado_envio)
            '
            Dim dgv_Fecha_Entrega As New DataGridViewTextBoxColumn
            With dgv_Fecha_Entrega  '13
                .DisplayIndex = 13
                .DataPropertyName = "Fecha_Entrega"
                .Name = "Fecha_Entrega"
                .HeaderText = "Fec. Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_Fecha_Entrega)
            '
            Dim dgv_Hora_Entrega As New DataGridViewTextBoxColumn
            With dgv_Hora_Entrega  '14
                .DisplayIndex = 14
                .DataPropertyName = "Hora_Entrega"
                .Name = "Hora_Entrega"
                .HeaderText = "Hora Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_Hora_Entrega)
            ' 
            Dim dgv_Cantidad As New DataGridViewTextBoxColumn
            With dgv_Cantidad  '15
                .DisplayIndex = 15
                .DataPropertyName = "cantidad"
                .Name = "cantidad"
                .HeaderText = "Cant. Bultos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_Cantidad)
            '
            Dim dgv_Cant_despachada As New DataGridViewTextBoxColumn
            With dgv_Cant_despachada  '16
                .DisplayIndex = 16
                .DataPropertyName = "cantidad_despachada"
                .Name = "cantidad_despachada"
                .HeaderText = "Cant. Despachada"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_Cant_despachada)
            '
            Dim dgv_cantidad_recepcionar As New DataGridViewTextBoxColumn
            With dgv_cantidad_recepcionar  '17
                .DisplayIndex = 17
                .DataPropertyName = "cantidad_recepcionar"
                .Name = "cantidad_recepcionar"
                .HeaderText = "Cant. Recepcionada"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_cantidad_recepcionar)
            '
            Dim dgv_cantidad_entregada As New DataGridViewTextBoxColumn
            With dgv_cantidad_entregada  '18
                .DisplayIndex = 18
                .DataPropertyName = "cantidad_entregada"
                .Name = "cantidad_entregada"
                .HeaderText = "Cant. Entregada"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_cantidad_entregada)
            '
            Dim dgv_cargo_doc As New DataGridViewTextBoxColumn
            With dgv_cargo_doc  '19
                .DisplayIndex = 19
                .DataPropertyName = "cargo_doc"
                .Name = "cargo_doc"
                .HeaderText = "Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_cargo_doc)
            '
            Dim dgv_fecha_doc As New DataGridViewTextBoxColumn
            With dgv_fecha_doc  '20
                .DisplayIndex = 20
                .DataPropertyName = "fecha_doc"
                .Name = "fecha_doc"
                .HeaderText = "Fecha Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_fecha_doc)
            '
            Dim dgv_hora_doc As New DataGridViewTextBoxColumn
            With dgv_hora_doc  '21
                .DisplayIndex = 21
                .DataPropertyName = "hora_doc"
                .Name = "hora_doc"
                .HeaderText = "Hora Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_hora_doc)
            '
            Dim dgv_idtipo_comprobante As New DataGridViewTextBoxColumn
            With dgv_idtipo_comprobante  '22
                .DisplayIndex = 22
                .DataPropertyName = "idtipo_comprobante"
                .Name = "idtipo_comprobante"
                .HeaderText = "tipo_comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_idtipo_comprobante)
            '
            Dim dgv_comprobante As New DataGridViewTextBoxColumn
            With dgv_comprobante  '23
                .DisplayIndex = 23
                .DataPropertyName = "idguias_envio"
                .Name = "idguias_envio"
                .HeaderText = "idcomprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_comprobante)
            ' 
            Dim dgv_idguia_transportista As New DataGridViewTextBoxColumn
            With dgv_idguia_transportista  '24
                .DisplayIndex = 24
                .DataPropertyName = "idguia_transportista"
                .Name = "idguia_transportista"
                .HeaderText = "idguia_transportista"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dvg_guia_transportista_xdcto.Columns.Add(dgv_idguia_transportista)
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub VerDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerDToolStripMenuItem.Click
        Try

        
            'Verifica que existan documentos en la grilla 
            If Me.dvg_guia_transportista_xdcto.RowCount < 1 Or IsDBNull(Me.dvg_guia_transportista_xdcto.Rows(0).Cells("nro_guia").Value) = True Or Me.dvg_guia_transportista_xdcto.Rows(0).Cells("nro_guia").Value = Nothing Then
                MsgBox("No existe ningún registro seleccionado", MsgBoxStyle.Information, "Seguimiento Documento")
                Exit Sub
            End If
            ' Visualiza el documento de carga -  
            Dim row As Integer = Me.dvg_guia_transportista_xdcto.CurrentRow.Index
            If Me.dvg_guia_transportista_xdcto.Rows(row).Cells("idtipo_comprobante").Value = 3 Then
                ObjEntregaCarga.IDPK = 2
            Else
                ObjEntregaCarga.IDPK = 1
            End If
            ObjEntregaCarga.IDDOC = Me.dvg_guia_transportista_xdcto.Rows(row).Cells("idguias_envio").Value
            ' Invocando a la ventana de cargo 
            Dim frmObj As New frmControlEntregasCargo
            frmObj.iVerEntrega = 1
            'If frmObj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'dtGridViewControl_FACBOL.Rows(row).DataGridView(25, row).Value = 21
            'dtGridViewControl_FACBOL.UpdateCellValue(0, row)

            Acceso.Asignar(frmObj, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                If frmObj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                End If
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Sub totaliza()
        Dim ld_total_cantidad, ld_total_despacho, ld_total_recepcion, ld_total_entregado As Double
        'Verifica que existan documentos en la grilla 
        If Me.dvg_guia_transportista_xdcto.RowCount < 1 Or IsDBNull(Me.dvg_guia_transportista_xdcto.Rows(0).Cells("nro_guia").Value) = True Or Me.dvg_guia_transportista_xdcto.Rows(0).Cells("nro_guia").Value = Nothing Then
            Exit Sub
        End If
        ' Dim row As Integer = Me.dvg_guia_transportista_xdcto.CurrentRow.Index
        Dim fila As Long
        ld_total_cantidad = 0
        ld_total_despacho = 0
        ld_total_recepcion = 0
        ld_total_entregado = 0
        For fila = 0 To (dvg_guia_transportista_xdcto.Rows.Count - 1)
            ld_total_cantidad = ld_total_cantidad + CType(Me.dvg_guia_transportista_xdcto.Rows(fila).Cells("Cantidad").Value, Double)
            ld_total_despacho = ld_total_despacho + CType(Me.dvg_guia_transportista_xdcto.Rows(fila).Cells("cantidad_despachada").Value, Double)
            ld_total_recepcion = ld_total_recepcion + CType(Me.dvg_guia_transportista_xdcto.Rows(fila).Cells("cantidad_recepcionar").Value, Double)
            ld_total_entregado = ld_total_entregado + CType(Me.dvg_guia_transportista_xdcto.Rows(fila).Cells("cantidad_entregada").Value, Double)
        Next
        Me.Txttot_cantidad.Text = ld_total_cantidad
        Me.txttotdespacho.Text = ld_total_despacho
        Me.txttotrecepcionado.Text = ld_total_recepcion
        Me.txttotal_entregado.Text = ld_total_entregado
        '
    End Sub
#End Region

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub dvg_guia_transportista_xdcto_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvg_guia_transportista_xdcto.CellContentClick

    End Sub

    Private Sub dvg_guia_transportista_xdcto_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dvg_guia_transportista_xdcto.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(dvg_guia_transportista_xdcto) - 1, 0)
        If Me.lblRegistros.Text = "-1" Then Me.lblRegistros.Text = "0"
    End Sub

    Private Sub dvg_guia_transportista_xdcto_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dvg_guia_transportista_xdcto.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(dvg_guia_transportista_xdcto) - 1, 0)
        If Me.lblRegistros.Text = "-1" Then Me.lblRegistros.Text = "0"
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.dvg_guia_transportista_xdcto.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.dvg_guia_transportista_xdcto.DataSource = Nothing
    End Sub

    Private Sub TBnro_unidad_transporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBnro_unidad_transporte.TextChanged
        Me.dvg_guia_transportista_xdcto.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_servicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidtipo_servicio.SelectedIndexChanged
        Me.dvg_guia_transportista_xdcto.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged
        Me.dvg_guia_transportista_xdcto.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndexChanged
        Me.dvg_guia_transportista_xdcto.DataSource = Nothing
    End Sub

    Private Sub txtcliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcliente.TextChanged
        Me.dvg_guia_transportista_xdcto.DataSource = Nothing
    End Sub

    Private Sub cmbestado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbestado.SelectedIndexChanged
        Me.dvg_guia_transportista_xdcto.DataSource = Nothing
    End Sub
End Class