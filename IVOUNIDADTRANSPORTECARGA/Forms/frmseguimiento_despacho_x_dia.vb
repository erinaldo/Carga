Public Class frmseguimiento_despacho_x_dia
    Dim ObjReport As ClsLbTepsa.dtoFrmReport
    Dim bIngreso As Boolean = False
    Public hnd As Long
#Region "Variables"
    Dim dtciudad, dtciudad_xdia, dtciudad_destino_xdia As New DataTable
    Dim dvciudad, dvciudad_xdia, dvciudad_destino_xdia As New DataView
    'Variables generales 
    'Dim odba As New OleDb.OleDbDataAdapter
#End Region
#Region "Eventos y Funciones"

    Private Sub frmseguimiento_despacho_x_dia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
            '
            EdicionToolStripMenuItem.Enabled = False
            EdicionToolStripMenuItem.Visible = False
            '
            SalirToolStripMenuItem.Enabled = True
            SalirToolStripMenuItem.Visible = True
            '
            If objseguimiento_despacho_x_dia.fn_load_guia_seguimiento_despacho_x_fecha() Then
                'Mod.12/10/2009 -->Omendoza - Pasando al datahelper -  
                'odba.Fill(dtciudad, objseguimiento_despacho_x_dia.rst_ciudad)
                '
                dtciudad = objseguimiento_despacho_x_dia.dt_rst_ciudad
            Else
                MsgBox("No se ha podido establecer, los valores de ayuda", MsgBoxStyle.Critical, "Sistema de Seguridad")
                Me.Close()
                Exit Sub
            End If
            '
            Me.lab_saldofecha.Text = "Saldo a la fecha"
            '
            dvciudad = CargarCombo(Me.CBIDUNIDAD_AGENCIA, dtciudad, "nombre_unidad", "idunidad_agencia", -666)
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
            DGV_seg_x_fecha.Columns.Clear()   'Limpiando la grilla 

            With DGV_seg_x_fecha
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
            Dim dgv_fecha As New DataGridViewTextBoxColumn
            With dgv_fecha  '0
                .DisplayIndex = 0
                .DataPropertyName = "fecha"
                .Name = "fecha"
                .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .Visible = True
            End With
            DGV_seg_x_fecha.Columns.Add(dgv_fecha)
            '                        
            'Dim dgv_Pendiente_anterior As New DataGridViewTextBoxColumn
            'With dgv_Pendiente_anterior  '1
            '    .DisplayIndex = 1
            '    .Name = "Pendiente_anterior"
            '    .DataPropertyName = "Pendiente_anterior"
            '    .HeaderText = "Pendiente Anterior"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'DGV_seg_x_fecha.Columns.Add(dgv_Pendiente_anterior)
            '
            Dim dvg_Registrado As New DataGridViewTextBoxColumn
            With dvg_Registrado '1
                .DisplayIndex = 1
                .DataPropertyName = "Registrado"
                .Name = "Registrado"
                .HeaderText = "Total Registrado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_seg_x_fecha.Columns.Add(dvg_Registrado)
            '
            Dim dgv_total_despacho As New DataGridViewTextBoxColumn
            With dgv_total_despacho ' 2
                .DisplayIndex = 2
                .DataPropertyName = "total_despacho"
                .Name = "total_despacho"
                .HeaderText = "Total Despacho"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_seg_x_fecha.Columns.Add(dgv_total_despacho)
            '
            'Dim dgv_Pend_x_enviar As New DataGridViewTextBoxColumn
            'With dgv_Pend_x_enviar ' 4
            '    .DisplayIndex = 4
            '    .DataPropertyName = "Pend_x_enviar"
            '    .Name = "Pend_x_enviar"
            '    .HeaderText = "Pendiente x Enviar"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'DGV_seg_x_fecha.Columns.Add(dgv_Pend_x_enviar)
            '
            Dim dgv_total_recepcionado As New DataGridViewTextBoxColumn
            With dgv_total_recepcionado '3
                .DisplayIndex = 3
                .DataPropertyName = "total_recepcionado"
                .Name = "total_recepcionado"
                .HeaderText = "Total Recepcionado"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_seg_x_fecha.Columns.Add(dgv_total_recepcionado)
            '
            Dim dgv_Dif_x_recepcionar As New DataGridViewTextBoxColumn
            With dgv_Dif_x_recepcionar '4
                .DisplayIndex = 4
                .DataPropertyName = "Dif_x_recepcionar"
                .Name = "Dif_x_recepcionar"
                .HeaderText = "Dif. x Recepcionar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_seg_x_fecha.Columns.Add(dgv_Dif_x_recepcionar)
            '
            Dim dgv_Entrega_domicilio As New DataGridViewTextBoxColumn
            With dgv_Entrega_domicilio '5
                .DisplayIndex = 5
                .DataPropertyName = "Entrega_domicilio"
                .Name = "Entrega_domicilio"
                .HeaderText = "Entrega Domicilio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_seg_x_fecha.Columns.Add(dgv_Entrega_domicilio)
            '
            Dim dgv_Entrega_agencia As New DataGridViewTextBoxColumn
            With dgv_Entrega_agencia '6
                .DisplayIndex = 6
                .DataPropertyName = "Entrega_agencia"
                .Name = "Entrega_agencia"
                .HeaderText = "Entrega Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_seg_x_fecha.Columns.Add(dgv_Entrega_agencia)
            '
            Dim dgv_pendiente_domicilio As New DataGridViewTextBoxColumn
            With dgv_pendiente_domicilio '7
                .DisplayIndex = 7
                .Name = "pendiente_domicilio"
                .DataPropertyName = "pendiente_domicilio"
                .HeaderText = "Pend. Domicilio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_seg_x_fecha.Columns.Add(dgv_pendiente_domicilio)
            '
            Dim dgv_pendiente_agencia As New DataGridViewTextBoxColumn
            With dgv_pendiente_agencia '8
                .DisplayIndex = 8
                .Name = "pendiente_agencia"
                .DataPropertyName = "pendiente_agencia"
                .HeaderText = "Pendiente Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_seg_x_fecha.Columns.Add(dgv_pendiente_agencia)
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Sub grillaformato_det()
        Try
            DGV_destino_x_fecha.Columns.Clear()   'Limpiando la grilla 
            With DGV_destino_x_fecha
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
            Dim dgv_destino As New DataGridViewTextBoxColumn
            With dgv_destino  '0
                .DisplayIndex = 0
                .DataPropertyName = "destino"
                .Name = "destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_destino_x_fecha.Columns.Add(dgv_destino)
            '                        
            'Dim dgv_Pendiente_anterior As New DataGridViewTextBoxColumn
            'With dgv_Pendiente_anterior '1
            '    .DisplayIndex = 1
            '    .Name = "Pendiente_anterior"
            '    .DataPropertyName = "Pendiente_anterior"
            '    .HeaderText = "Pendiente Anterior"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'DGV_destino_x_fecha.Columns.Add(dgv_Pendiente_anterior)
            '
            Dim dvg_Registrado As New DataGridViewTextBoxColumn
            With dvg_Registrado '1
                .DisplayIndex = 1
                .DataPropertyName = "Registrado"
                .Name = "Registrado"
                .HeaderText = "Total Registrado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_destino_x_fecha.Columns.Add(dvg_Registrado)
            '
            Dim dgv_total_despacho As New DataGridViewTextBoxColumn
            With dgv_total_despacho ' 2
                .DisplayIndex = 2
                .DataPropertyName = "total_despacho"
                .Name = "total_despacho"
                .HeaderText = "Total Despacho"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_destino_x_fecha.Columns.Add(dgv_total_despacho)
            '
            'Dim dgv_Pend_x_enviar As New DataGridViewTextBoxColumn
            'With dgv_Pend_x_enviar ' 4
            '    .DisplayIndex = 4
            '    .DataPropertyName = "Pend_x_enviar"
            '    .Name = "Pend_x_enviar"
            '    .HeaderText = "Pendiente x enviar"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'DGV_destino_x_fecha.Columns.Add(dgv_Pend_x_enviar)
            '
            Dim dgv_total_recepcionado As New DataGridViewTextBoxColumn
            With dgv_total_recepcionado '3
                .DisplayIndex = 3
                .DataPropertyName = "total_recepcionado"
                .Name = "total_recepcionado"
                .HeaderText = "Total Recepcionado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_destino_x_fecha.Columns.Add(dgv_total_recepcionado)
            '
            Dim dgv_Dif_x_recepcionar As New DataGridViewTextBoxColumn
            With dgv_Dif_x_recepcionar '4
                .DisplayIndex = 4
                .DataPropertyName = "Dif_x_recepcionar"
                .Name = "Dif_x_recepcionar"
                .HeaderText = "Dif. x Recepcionar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_destino_x_fecha.Columns.Add(dgv_Dif_x_recepcionar)
            '
            Dim dgv_Entrega_domicilio As New DataGridViewTextBoxColumn
            With dgv_Entrega_domicilio '5
                .DisplayIndex = 5
                .DataPropertyName = "Entrega_domicilio"
                .Name = "Entrega_domicilio"
                .HeaderText = "Entregado Domicilio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV_destino_x_fecha.Columns.Add(dgv_Entrega_domicilio)
            '
            Dim dgv_Entrega_agencia As New DataGridViewTextBoxColumn
            With dgv_Entrega_agencia '6
                .DisplayIndex = 6
                .DataPropertyName = "Entrega_agencia"
                .Name = "Entrega_agencia"
                .HeaderText = "Entregado Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_destino_x_fecha.Columns.Add(dgv_Entrega_agencia)
            '
            Dim dgv_pendiente_domicilio As New DataGridViewTextBoxColumn
            With dgv_pendiente_domicilio '7
                .DisplayIndex = 7
                .Name = "pendiente_domicilio"
                .DataPropertyName = "pendiente_domicilio"
                .HeaderText = "Pend. domicilio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_destino_x_fecha.Columns.Add(dgv_pendiente_domicilio)
            '
            Dim dgv_pendiente_agencia As New DataGridViewTextBoxColumn
            With dgv_pendiente_agencia '8
                .DisplayIndex = 8
                .Name = "pendiente_agencia"
                .DataPropertyName = "pendiente_agencia"
                .HeaderText = "Pendiente Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_destino_x_fecha.Columns.Add(dgv_pendiente_agencia)
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub DGV_seg_x_fecha_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_seg_x_fecha.CellEnter
        Try
            dtciudad_destino_xdia = Nothing
            dvciudad_destino_xdia = Nothing
            '
            dtciudad_destino_xdia = New DataTable
            dvciudad_destino_xdia = New DataView
            '
            objseguimiento_despacho_x_dia.sfecha_inicio = CType(dvciudad_xdia.Table.Rows(DGV_seg_x_fecha.CurrentRow.Index)("fecha"), String)
            'objseguimiento_despacho_x_dia.sfecha_final = "15/03/2007" ' CType(Me.DTPFECHAINICIOFACTURA.Value, String) 'Se necesita la fecha inicial, Fecha Tope, Se incluye como fecha tope el 15/03/2007  
            objseguimiento_despacho_x_dia.lciudad_origen = CType(Me.CBIDUNIDAD_AGENCIA.SelectedValue, Long)
            ' 
            If objseguimiento_despacho_x_dia.fn_seg_despacho_destino_x_dia() Then
                'Mod.12/10/2009 -->Omendoza - Pasando al datahelper -  
                'odba.Fill(dtciudad_destino_xdia, objseguimiento_despacho_x_dia.rst_seg_despacho_x_fecha_destino)
                dtciudad_destino_xdia = objseguimiento_despacho_x_dia.dt_rst_seg_despacho_x_fecha_destino
                dvciudad_destino_xdia = dtciudad_destino_xdia.DefaultView
                Call grillaformato_det()
                DGV_destino_x_fecha.DataSource = dvciudad_destino_xdia
                ' Labnroreg.Text = "Nº de Registro(s) " + CType(dv_seguimiento.Count, String)
            End If
            '
            'Dim obj As New ClsLbTepsa.dtoGUIA_TRANSPORTISTA
            'With obj
            '    .IDGUIA_TRANSPORTISTA = dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("IDGUIA_TRANSPORTISTA")
            '    dvguias_transportista_bultos = .sp_list_guia_transpor_deta(VOCONTROLUSUARIO)
            '
            'End With
        Catch ex As Exception
            dtciudad_destino_xdia = Nothing
            dvciudad_destino_xdia = Nothing
            ' grillaformato_det()
            Call grillaformato_det()
        End Try
    End Sub
    Private Sub DGV_seg_x_fecha_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGV_seg_x_fecha.CellFormatting
        Try
            If IsDBNull(DGV_seg_x_fecha.Rows(e.RowIndex).Cells("Pend_x_enviar").Value) = False Then
                If DGV_seg_x_fecha.Rows(e.RowIndex).Cells("Pend_x_enviar").Value > 0 Then
                    DGV_seg_x_fecha.Rows(e.RowIndex).Cells("Pend_x_enviar").Style.ForeColor = Color.Red
                End If
            End If

            '
            If IsDBNull(DGV_seg_x_fecha.Rows(e.RowIndex).Cells("Dif_x_recepcionar").Value) = False Then
                If DGV_seg_x_fecha.Rows(e.RowIndex).Cells("Dif_x_recepcionar").Value > 0 Then
                    DGV_seg_x_fecha.Rows(e.RowIndex).Cells("Dif_x_recepcionar").Style.ForeColor = Color.Red
                End If
            End If
            '
            If IsDBNull(DGV_seg_x_fecha.Rows(e.RowIndex).Cells("pendiente_domicilio").Value) = False Then
                If DGV_seg_x_fecha.Rows(e.RowIndex).Cells("pendiente_domicilio").Value > 0 Then
                    DGV_seg_x_fecha.Rows(e.RowIndex).Cells("pendiente_domicilio").Style.ForeColor = Color.Red
                End If
            End If
            '
        Catch ex As Exception


        End Try
    End Sub
    Private Sub btn_filtrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_filtrar.Click
        Try
            'Limpiando y creando datable y dataview de la busqueda
            dtciudad_xdia = Nothing
            dvciudad_xdia = Nothing
            ' 
            dtciudad_xdia = New DataTable
            dvciudad_xdia = New DataView
            '
            objseguimiento_despacho_x_dia.sfecha_inicio = CType(Me.DTPFECHAINICIOFACTURA.Value, String)
            objseguimiento_despacho_x_dia.sfecha_final = CType(Me.DTPFECHAFINALFACTURA.Value, String)
            objseguimiento_despacho_x_dia.lciudad_origen = CType(Me.CBIDUNIDAD_AGENCIA.SelectedValue, Long)
            '
            'Invocando la consulta 
            ' Labnroreg.Text = "Nº de Registro(s) 0 "            
            If objseguimiento_despacho_x_dia.fn_seg_despacho_dia_origen() Then
                'Mod.12/10/2009 -->Omendoza - Pasando al datahelper -  
                'odba.Fill(dtciudad_xdia, objseguimiento_despacho_x_dia.rst_seg_despacho_x_fecha)
                dtciudad_xdia = objseguimiento_despacho_x_dia.dt_rst_seg_despacho_x_fecha
                '
                dvciudad_xdia = dtciudad_xdia.DefaultView
                grillaformato()
                DGV_seg_x_fecha.DataSource = dvciudad_xdia
                'rst_edtventa_pasaje.Fields.Item("idforma_pago").Value
                'If IsDBNull(objseguimiento_despacho_x_dia.rst_saldo_despacho_x_dia.Fields.Item("saldo").Value) = True Then
                If IsDBNull(objseguimiento_despacho_x_dia.dt_rst_saldo_despacho_x_dia.Rows(0).Item("saldo")) = True Then
                    Me.Txtsaldoalafecha.Text = "0"
                Else
                    Me.Txtsaldoalafecha.Text = CType(objseguimiento_despacho_x_dia.dt_rst_saldo_despacho_x_dia.Rows(0).Item("saldo"), Long)
                End If
                ' Labnroreg.Text = "Nº de Registro(s) " + CType(dv_seguimiento.Count, String)
            End If
            Me.lab_saldofecha.Text = "Saldo a la fecha " + CType(DateAdd(DateInterval.Day, -1, Me.DTPFECHAINICIOFACTURA.Value), String)
            dtciudad_destino_xdia = Nothing
            dvciudad_destino_xdia = Nothing
            grillaformato_det()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
    Private Sub DGV_destino_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DGV_seg_x_fecha.Scroll
        Dim a As Integer
        Try
            a = e.NewValue
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmdespacho_vs_recepcion_MenuImprimir() Handles Me.MenuImprimir
        'Try

        '    Try
        '        ObjReport.dispose()
        '    Catch
        '    End Try

        '    ObjReport = New ClsLbTepsa.dtoFrmReport

        '    'Limpiando y creando datable y dataview de la busqueda
        '    '' '' ''dtciudad_destino = Nothing
        '    '' '' ''dvciudad_destino = Nothing
        '    ' '' '' '' 
        '    '' '' ''dtciudad_destino = New DataTable
        '    '' '' ''dvciudad_destino = New DataView
        '    '
        '    objguia_transp_despacho_vs_recepcion.sfecha_inicio = CType(Me.DTPFECHAINICIOFACTURA.Value, String)
        '    objguia_transp_despacho_vs_recepcion.sfecha_final = CType(Me.DTPFECHAFINALFACTURA.Value, String)
        '    objguia_transp_despacho_vs_recepcion.lciudad_origen = CType(Me.CBIDUNIDAD_AGENCIA.SelectedValue, Long)
        '    objguia_transp_despacho_vs_recepcion.lciudad_destino = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Long)

        '    Dim origen As Long, destino As Long
        '    origen = IIf(objseguimiento_despacho_x_dia.lciudad_origen = -666, 0, objseguimiento_despacho_x_dia.lciudad_origen)
        '    'destino = IIf(objseguimiento_despacho_x_dia.lciudad_destino = -666, 0, objseguimiento_despacho_x_dia.lciudad_destino)

        '    '
        '    'Invocando la consulta 
        '    ' Labnroreg.Text = "Nº de Registro(s) 0 "            
        '    '' ''If objguia_transp_despacho_vs_recepcion.fn_destino_trans_despacho_vs_recepcion() Then
        '    '' ''    odba.Fill(dtciudad_destino, objguia_transp_despacho_vs_recepcion.rst_con_despacho_x_recepcion)
        '    '' ''    dvciudad_destino = dtciudad_destino.DefaultView
        '    '' ''    grillaformato()
        '    '' ''    DGV_destino.DataSource = dvciudad_destino
        '    '' ''    '
        '    '' ''    ' Labnroreg.Text = "Nº de Registro(s) " + CType(dv_seguimiento.Count, String)
        '    '' ''End If

        '    ObjReport.rutaRpt = PathFrmReport
        '    ObjReport.conectar(rptservice, rptuser, rptpass)

        '    ObjReport.printrptB(False, "", "GUIAT009.RPT", _
        '    "P_RANGO_FECHA;" & "(Del " & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString & " al " & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString & ")", _
        '    "VFECHA_INICIO;" & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString, _
        '    "VFECHA_FINAL;" & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString, _
        '    "NICIUDAD_ORIGEN;" & origen, _
        '    "NCIUDAD_DESTINO;" & destino)


        '    ' '' '' ''dtciudad_origen = Nothing
        '    ' '' '' ''dvciudad_origen = Nothing
        '    ' '' '' ''grillaformato_det()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        'End Try
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        '    Try
        '        ObjReport.Dispose()
        '    Catch
        '    End Try
    End Sub
    Private Sub DGV_destino_x_fecha_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGV_destino_x_fecha.CellFormatting
        Try
            If IsDBNull(DGV_destino_x_fecha.Rows(e.RowIndex).Cells("Pend_x_enviar")) = False Then
                If DGV_destino_x_fecha.Rows(e.RowIndex).Cells("Pend_x_enviar").Value > 0 Then
                    DGV_destino_x_fecha.Rows(e.RowIndex).Cells("Pend_x_enviar").Style.ForeColor = Color.Red
                End If
            End If
            '
            If IsDBNull(DGV_destino_x_fecha.Rows(e.RowIndex).Cells("Dif_x_recepcionar").Value) = False Then
                If DGV_destino_x_fecha.Rows(e.RowIndex).Cells("Dif_x_recepcionar").Value > 0 Then
                    DGV_destino_x_fecha.Rows(e.RowIndex).Cells("Dif_x_recepcionar").Style.ForeColor = Color.Red
                End If
            End If
            '
            If IsDBNull(DGV_destino_x_fecha.Rows(e.RowIndex).Cells("pendiente_domicilio").Value) = False Then
                If DGV_destino_x_fecha.Rows(e.RowIndex).Cells("pendiente_domicilio").Value > 0 Then
                    DGV_destino_x_fecha.Rows(e.RowIndex).Cells("pendiente_domicilio").Style.ForeColor = Color.Red
                End If
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub DGV_seg_x_fecha_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_seg_x_fecha.CellContentClick

    End Sub

    Private Sub DGV_seg_x_fecha_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV_seg_x_fecha.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV_seg_x_fecha) - 1, 0)
        If Me.lblRegistros.Text = "-1" Then Me.lblRegistros.Text = "0"
    End Sub

    Private Sub DGV_seg_x_fecha_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGV_seg_x_fecha.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV_seg_x_fecha) - 1, 0)
        If Me.lblRegistros.Text = "-1" Then Me.lblRegistros.Text = "0"
    End Sub

    Private Sub DGV_destino_x_fecha_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_destino_x_fecha.CellContentClick

    End Sub

    Private Sub DGV_destino_x_fecha_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV_destino_x_fecha.RowsAdded
        Me.LblRegistros2.Text = FormatNumber(NumeroRegistro(Me.DGV_destino_x_fecha) - 1, 0)
        If Me.LblRegistros2.Text = "-1" Then Me.LblRegistros2.Text = "0"
    End Sub

    Private Sub DGV_destino_x_fecha_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGV_destino_x_fecha.RowsRemoved
        Me.LblRegistros2.Text = FormatNumber(NumeroRegistro(Me.DGV_destino_x_fecha) - 1, 0)
        If Me.LblRegistros2.Text = "-1" Then Me.LblRegistros2.Text = "0"
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.DGV_destino_x_fecha.DataSource = Nothing
        Me.DGV_seg_x_fecha.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.DGV_destino_x_fecha.DataSource = Nothing
        Me.DGV_seg_x_fecha.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged
        Me.DGV_destino_x_fecha.DataSource = Nothing
        Me.DGV_seg_x_fecha.DataSource = Nothing
    End Sub

    Private Sub Txtsaldoalafecha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtsaldoalafecha.TextChanged
        Me.DGV_destino_x_fecha.DataSource = Nothing
        Me.DGV_seg_x_fecha.DataSource = Nothing
    End Sub
End Class
