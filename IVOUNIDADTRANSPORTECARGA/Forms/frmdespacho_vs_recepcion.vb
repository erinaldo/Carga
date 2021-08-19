Public Class frmdespacho_vs_recepcion
    Dim ObjReport As ClsLbTepsa.dtoFrmReport
    Dim bIngreso As Boolean = False
    Public hnd As Long
#Region "Variables"
    Dim dtciudad_origen, dtciudad_destino As New DataTable
    Public dvciudad_origen, dvciudad_destino As New DataView
    'Variables generales 
    Dim odba As New OleDb.OleDbDataAdapter
#End Region
#Region "Eventos y Funciones"

    Private Sub frmdespacho_vs_recepcion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
            Me.ShadowLabel1.Text = "Resumen Despacho y Recepción Guía de Transportista"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            ' 
            MenuTab.Items(0).Text = "Resumen"
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
            '
            If objguia_transp_despacho_vs_recepcion.fn_load_guia_trans_despacho_vs_recepcion Then
                'Mod.07/10/2009 -->Omendoza - Pasando al datahelper -  
                'odba.Fill(dtciudad_origen, objguia_transp_despacho_vs_recepcion.rst_ciudad)
                dtciudad_origen = objguia_transp_despacho_vs_recepcion.dt_rst_ciudad
                dtciudad_destino = dtciudad_origen.Copy
            Else
                MsgBox("No se ha podido establecer, los valores de ayuda", MsgBoxStyle.Critical, "Sistema de Seguridad")
                Me.Close()
                Exit Sub
            End If
            '
            dvciudad_origen = CargarCombo(Me.CBIDUNIDAD_AGENCIA, dtciudad_origen, "nombre_unidad", "idunidad_agencia", -666)
            dvciudad_destino = CargarCombo(Me.CBIDUNIDAD_AGENCIA_DESTINO, dtciudad_destino, "nombre_unidad", "idunidad_agencia", -666)
            ' Debe cargar toda la grilla. 
            grillaformato()
            '
            grillaformato_det()
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
            Dgv_destino.Columns.Clear()   'Limpiando la grilla 

            With Dgv_destino
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
            Dim dgv_ciudad_destino As New DataGridViewTextBoxColumn
            With dgv_ciudad_destino  '0
                .DisplayIndex = 0
                .DataPropertyName = "ciudad_destino"
                .Name = "dgv_ciudad_destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            Dgv_destino.Columns.Add(dgv_ciudad_destino)
            '                        
            Dim dgv_Fecha_Salida As New DataGridViewTextBoxColumn
            With dgv_Fecha_Salida  '1
                .DisplayIndex = 1
                .Name = "Fecha_Salida"
                .DataPropertyName = "Fecha_Salida"
                .HeaderText = "Fec. Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            Dgv_destino.Columns.Add(dgv_Fecha_Salida)
            '
            Dim dvg_despacho As New DataGridViewTextBoxColumn
            With dvg_despacho '2
                .DisplayIndex = 2
                .DataPropertyName = "despacho"
                .Name = "despacho"
                .HeaderText = "Despacho"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            Dgv_destino.Columns.Add(dvg_despacho)
            '
            Dim dgv_recepcionar As New DataGridViewTextBoxColumn
            With dgv_recepcionar ' 3
                .DisplayIndex = 3
                .DataPropertyName = "recepcionar"
                .Name = "recepcionar"
                .HeaderText = "Recepción"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            Dgv_destino.Columns.Add(dgv_recepcionar)
            '
            Dim dgv_Por_recepcionar As New DataGridViewTextBoxColumn
            With dgv_Por_recepcionar ' 4
                .DisplayIndex = 4
                .DataPropertyName = "Por_recepcionar"
                .Name = "Por_recepcionar"
                .HeaderText = "Por Recepcionar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            Dgv_destino.Columns.Add(dgv_Por_recepcionar)
            '
            Dim dgv_Entrega_domicilio As New DataGridViewTextBoxColumn
            With dgv_Entrega_domicilio '5
                .DisplayIndex = 5
                .DataPropertyName = "Entrega_domicilio"
                .Name = "Entrega_domicilio"
                .HeaderText = "Entrega Domicilio"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            Dgv_destino.Columns.Add(dgv_Entrega_domicilio)
            '
            Dim dgv_Entrega_agencia As New DataGridViewTextBoxColumn
            With dgv_Entrega_agencia '6
                .DisplayIndex = 6
                .DataPropertyName = "Entrega_agencia"
                .Name = "Entrega_agencia"
                .HeaderText = "Entrega agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            Dgv_destino.Columns.Add(dgv_Entrega_agencia)
            '
            Dim dgv_Total_entregado As New DataGridViewTextBoxColumn
            With dgv_Total_entregado '7
                .DisplayIndex = 7
                .DataPropertyName = "Total_entregado"
                .Name = "Total_entregado"
                .HeaderText = "Total Entregado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            Dgv_destino.Columns.Add(dgv_Total_entregado)
            '
            Dim dgv_Pend_Entrega_domicilio As New DataGridViewTextBoxColumn
            With dgv_Pend_Entrega_domicilio '8
                .DisplayIndex = 8
                .DataPropertyName = "Pend_Entrega_domicilio"
                .Name = "Pend_Entrega_domicilio"
                .HeaderText = "Pend. Entrega Domicilio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            Dgv_destino.Columns.Add(dgv_Pend_Entrega_domicilio)
            '
            Dim dgv_Pend_Entrega_agencia As New DataGridViewTextBoxColumn
            With dgv_Pend_Entrega_agencia '9
                .DisplayIndex = 9
                .Name = "Pend_Entrega_agencia"
                .DataPropertyName = "Pend_Entrega_agencia"
                .HeaderText = "Pend. Entrega Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            Dgv_destino.Columns.Add(dgv_Pend_Entrega_agencia)
            '
            Dim dgv_Total_x_entregar As New DataGridViewTextBoxColumn
            With dgv_Total_x_entregar '10
                .DisplayIndex = 10
                .Name = "Total_x_entregar"
                .DataPropertyName = "Total_x_entregar"
                .HeaderText = "Total x entregar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            Dgv_destino.Columns.Add(dgv_Total_x_entregar)
            '
            Dim dgv_idunidad_agencia_destino As New DataGridViewTextBoxColumn
            With dgv_idunidad_agencia_destino '11
                .DisplayIndex = 11
                .Name = "idunidad_agencia_destino"
                .DataPropertyName = "idunidad_agencia_destino"
                .HeaderText = "idciudad_destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            Dgv_destino.Columns.Add(dgv_idunidad_agencia_destino)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Sub grillaformato_det()
        Try
            DGV_origen.Columns.Clear()   'Limpiando la grilla 
            With DGV_origen
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
            Dim dgv_ciudad_origen As New DataGridViewTextBoxColumn
            With dgv_ciudad_origen  '0
                .DisplayIndex = 0
                .DataPropertyName = "ciudad_origen"
                .Name = "dgv_ciudad_origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_origen.Columns.Add(dgv_ciudad_origen)
            '                        
            Dim dgv_Fecha_Salida As New DataGridViewTextBoxColumn
            With dgv_Fecha_Salida  '1
                .DisplayIndex = 1
                .Name = "Fecha_Salida"
                .DataPropertyName = "Fecha_Salida"
                .HeaderText = "Fec. Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_origen.Columns.Add(dgv_Fecha_Salida)
            '
            Dim dvg_despacho As New DataGridViewTextBoxColumn
            With dvg_despacho '2
                .DisplayIndex = 2
                .DataPropertyName = "despacho"
                .Name = "despacho"
                .HeaderText = "Despacho"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_origen.Columns.Add(dvg_despacho)
            '
            Dim dgv_recepcionar As New DataGridViewTextBoxColumn
            With dgv_recepcionar ' 3
                .DisplayIndex = 3
                .DataPropertyName = "recepcionar"
                .Name = "recepcionar"
                .HeaderText = "Recepción"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_origen.Columns.Add(dgv_recepcionar)
            '
            Dim dgv_Por_recepcionar As New DataGridViewTextBoxColumn
            With dgv_Por_recepcionar ' 4
                .DisplayIndex = 4
                .DataPropertyName = "Por_recepcionar"
                .Name = "Por_recepcionar"
                .HeaderText = "Por Recepcionar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_origen.Columns.Add(dgv_Por_recepcionar)
            '
            Dim dgv_Entrega_domicilio As New DataGridViewTextBoxColumn
            With dgv_Entrega_domicilio '5
                .DisplayIndex = 5
                .DataPropertyName = "Entrega_domicilio"
                .Name = "Entrega_domicilio"
                .HeaderText = "Entrega Domicilio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_origen.Columns.Add(dgv_Entrega_domicilio)
            '
            Dim dgv_Entrega_agencia As New DataGridViewTextBoxColumn
            With dgv_Entrega_agencia '6
                .DisplayIndex = 6
                .DataPropertyName = "Entrega_agencia"
                .Name = "Entrega_agencia"
                .HeaderText = "Entrega agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_origen.Columns.Add(dgv_Entrega_agencia)
            '
            Dim dgv_Total_entregado As New DataGridViewTextBoxColumn
            With dgv_Total_entregado '7
                .DisplayIndex = 7
                .DataPropertyName = "Total_entregado"
                .Name = "Total_entregado"
                .HeaderText = "Total Entregado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_origen.Columns.Add(dgv_Total_entregado)
            '
            Dim dgv_Pend_Entrega_domicilio As New DataGridViewTextBoxColumn
            With dgv_Pend_Entrega_domicilio '8
                .DisplayIndex = 8
                .DataPropertyName = "Pend_Entrega_domicilio"
                .Name = "Pend_Entrega_domicilio"
                .HeaderText = "Pend. Entrega Domicilio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_origen.Columns.Add(dgv_Pend_Entrega_domicilio)
            '
            Dim dgv_Pend_Entrega_agencia As New DataGridViewTextBoxColumn
            With dgv_Pend_Entrega_agencia '9
                .DisplayIndex = 9
                .Name = "Pend_Entrega_agencia"
                .DataPropertyName = "Pend_Entrega_agencia"
                .HeaderText = "Pend. Entrega Domicilio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_origen.Columns.Add(dgv_Pend_Entrega_agencia)
            '
            Dim dgv_Total_x_entregar As New DataGridViewTextBoxColumn
            With dgv_Total_x_entregar '10
                .DisplayIndex = 10
                .Name = "Total_x_entregar"
                .DataPropertyName = "Total_x_entregar"
                .HeaderText = "Total x entregar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_origen.Columns.Add(dgv_Total_x_entregar)
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub DGV_destino_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_destino.CellEnter
        Try
            '
            dtciudad_origen = Nothing
            dvciudad_origen = Nothing
            '
            dtciudad_origen = New DataTable
            dvciudad_origen = New DataView
            '
            objguia_transp_despacho_vs_recepcion.sfecha_inicio = CType(dvciudad_destino.Table.Rows(Dgv_destino.CurrentRow.Index)("Fecha_Salida"), String)
            objguia_transp_despacho_vs_recepcion.sfecha_final = CType(dvciudad_destino.Table.Rows(Dgv_destino.CurrentRow.Index)("Fecha_Salida"), String)
            objguia_transp_despacho_vs_recepcion.lciudad_destino = CType(dvciudad_destino.Table.Rows(Dgv_destino.CurrentRow.Index)("idunidad_agencia_destino"), Integer)
            objguia_transp_despacho_vs_recepcion.lciudad_origen = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            ' 
            If objguia_transp_despacho_vs_recepcion.fn_origen_guia_trans_despacho_vs_recepcion() Then
                'Mod.07/10/2009 -->Omendoza - Pasando al datahelper -  
                'odba.Fill(dtciudad_origen, objguia_transp_despacho_vs_recepcion.rst_con_despacho_x_recepcion_origen)
                '
                dtciudad_origen = objguia_transp_despacho_vs_recepcion.dt_rst_con_despacho_x_recepcion_origen
                dvciudad_origen = dtciudad_origen.DefaultView
                Call grillaformato_det()
                DGV_origen.DataSource = dvciudad_origen
                ' Labnroreg.Text = "Nº de Registro(s) " + CType(dv_seguimiento.Count, String)
            End If

            'Dim obj As New ClsLbTepsa.dtoGUIA_TRANSPORTISTA
            'With obj
            '    .IDGUIA_TRANSPORTISTA = dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("IDGUIA_TRANSPORTISTA")
            '    dvguias_transportista_bultos = .sp_list_guia_transpor_deta(VOCONTROLUSUARIO)
            '
            'End With
        Catch ex As Exception
            Call grillaformato_det()
        End Try
    End Sub
    Private Sub btn_filtrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_filtrar.Click
        Try
            'Limpiando y creando datable y dataview de la busqueda
            dtciudad_destino = Nothing
            dvciudad_destino = Nothing
            ' 
            dtciudad_destino = New DataTable
            dvciudad_destino = New DataView
            '
            objguia_transp_despacho_vs_recepcion.sfecha_inicio = CType(Me.DTPFECHAINICIOFACTURA.Value, String)
            objguia_transp_despacho_vs_recepcion.sfecha_final = CType(Me.DTPFECHAFINALFACTURA.Value, String)
            objguia_transp_despacho_vs_recepcion.lciudad_origen = CType(Me.CBIDUNIDAD_AGENCIA.SelectedValue, Long)
            objguia_transp_despacho_vs_recepcion.lciudad_destino = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Long)
            '
            'Invocando la consulta 
            ' Labnroreg.Text = "Nº de Registro(s) 0 "            
            If objguia_transp_despacho_vs_recepcion.fn_destino_trans_despacho_vs_recepcion() Then
                '
                'Mod.07/10/2009 -->Omendoza - Pasando al datahelper -  
                'odba.Fill(dtciudad_destino, objguia_transp_despacho_vs_recepcion.rst_con_despacho_x_recepcion)
                '
                dtciudad_destino = objguia_transp_despacho_vs_recepcion.dt_rst_con_despacho_x_recepcion
                dvciudad_destino = dtciudad_destino.DefaultView
                grillaformato()
                Dgv_destino.DataSource = dvciudad_destino
                '
                ' Labnroreg.Text = "Nº de Registro(s) " + CType(dv_seguimiento.Count, String)
            End If
            dtciudad_origen = Nothing
            dvciudad_origen = Nothing
            grillaformato_det()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
#End Region

    Private Sub DGV_destino_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Dgv_destino.Scroll
        Dim a As Integer
        Try

            a = e.NewValue

        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmdespacho_vs_recepcion_MenuImprimir() Handles Me.MenuImprimir
        Try

            Try
                ObjReport.Dispose()
            Catch
            End Try

            ObjReport = New ClsLbTepsa.dtoFrmReport

            'Limpiando y creando datable y dataview de la busqueda
            '' '' ''dtciudad_destino = Nothing
            '' '' ''dvciudad_destino = Nothing
            ' '' '' '' 
            '' '' ''dtciudad_destino = New DataTable
            '' '' ''dvciudad_destino = New DataView
            '
            objguia_transp_despacho_vs_recepcion.sfecha_inicio = CType(Me.DTPFECHAINICIOFACTURA.Value, String)
            objguia_transp_despacho_vs_recepcion.sfecha_final = CType(Me.DTPFECHAFINALFACTURA.Value, String)
            objguia_transp_despacho_vs_recepcion.lciudad_origen = CType(Me.CBIDUNIDAD_AGENCIA.SelectedValue, Long)
            objguia_transp_despacho_vs_recepcion.lciudad_destino = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Long)

            Dim origen As Long, destino As Long
            origen = IIf(objguia_transp_despacho_vs_recepcion.lciudad_origen = -666, 0, objguia_transp_despacho_vs_recepcion.lciudad_origen)
            destino = IIf(objguia_transp_despacho_vs_recepcion.lciudad_destino = -666, 0, objguia_transp_despacho_vs_recepcion.lciudad_destino)

            '
            'Invocando la consulta 
            ' Labnroreg.Text = "Nº de Registro(s) 0 "            
            '' ''If objguia_transp_despacho_vs_recepcion.fn_destino_trans_despacho_vs_recepcion() Then
            '' ''    odba.Fill(dtciudad_destino, objguia_transp_despacho_vs_recepcion.rst_con_despacho_x_recepcion)
            '' ''    dvciudad_destino = dtciudad_destino.DefaultView
            '' ''    grillaformato()
            '' ''    DGV_destino.DataSource = dvciudad_destino
            '' ''    '
            '' ''    ' Labnroreg.Text = "Nº de Registro(s) " + CType(dv_seguimiento.Count, String)
            '' ''End If

            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)

            ObjReport.printrptB(False, "", "GUIAT009.RPT", _
            "P_RANGO_FECHA;" & "(Del " & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString & " al " & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString & ")", _
            "VFECHA_INICIO;" & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString, _
            "VFECHA_FINAL;" & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString, _
            "NICIUDAD_ORIGEN;" & origen, _
            "NCIUDAD_DESTINO;" & destino)


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

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub DGV_destino_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_destino.CellContentClick

    End Sub

    Private Sub DGV_destino_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgv_destino.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.Dgv_destino) - 1, 0)
        If Me.lblRegistros.Text = "-1" Then Me.lblRegistros.Text = "0"
    End Sub

    Private Sub DGV_destino_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles Dgv_destino.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.Dgv_destino) - 1, 0)
        If Me.lblRegistros.Text = "-1" Then Me.lblRegistros.Text = "0"
    End Sub

    Private Sub DGV_origen_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_origen.CellContentClick

    End Sub

    Private Sub DGV_origen_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV_origen.RowsAdded
        Me.LblRegistros2.Text = FormatNumber(NumeroRegistro(Me.DGV_origen) - 1, 0)
        If Me.LblRegistros2.Text = "-1" Then Me.LblRegistros2.Text = "0"
    End Sub

    Private Sub DGV_origen_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGV_origen.RowsRemoved
        Me.LblRegistros2.Text = FormatNumber(NumeroRegistro(Me.DGV_origen) - 1, 0)
        If Me.LblRegistros2.Text = "-1" Then Me.LblRegistros2.Text = "0"
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.Dgv_destino.DataSource = Nothing
        Me.DGV_origen.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.Dgv_destino.DataSource = Nothing
        Me.DGV_origen.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged
        Me.Dgv_destino.DataSource = Nothing
        Me.DGV_origen.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndexChanged
        Me.Dgv_destino.DataSource = Nothing
        Me.DGV_origen.DataSource = Nothing
    End Sub
End Class
