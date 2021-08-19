Public Class FrmDetalleDepacho_VS_Recepcion
    Dim ObjDESPACHO_RECEPCION As New ClsLbTepsa.dtoDESPACHO_RECEPCION
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Private Sub BtnAcep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcep.Click
        Close()
    End Sub

    Private Sub FrmDetalleDepacho_VS_Recepcion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmPass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '    'Limpiando y creando datable y dataview de la busqueda
            '    Dim dtciudad_destino As New DataTable
            '    Dim dvciudad_destino As New DataView
            '    ' 
            With nfrmdespacho_vs_recepcion
                ObjDESPACHO_RECEPCION.FECHA_INI = CType(.dvciudad_destino.Table.Rows(.Dgv_destino.CurrentRow.Index)("fecha_salida"), String)
                ObjDESPACHO_RECEPCION.FECHA_FINAL = .DTPFECHAFINALFACTURA.Value.ToShortDateString
                ObjDESPACHO_RECEPCION.IDUNIDAD_AGENCIA_DESTINO = CType(.dvciudad_destino.Table.Rows(.Dgv_destino.CurrentRow.Index)("idunidad_agencia_destino"), Integer)
                'Datahelper
                Me.DGV.DataSource = ObjDESPACHO_RECEPCION.sp_con_x_recep_vista()
                '
                '    objguia_transp_despacho_vs_recepcion.sfecha_inicio = CType(nfrmdespacho_vs_recepcion.DTPFECHAINICIOFACTURA.Value, String)
                '    objguia_transp_despacho_vs_recepcion.sfecha_final = CType(nfrmdespacho_vs_recepcion.DTPFECHAFINALFACTURA.Value, String)
                '    objguia_transp_despacho_vs_recepcion.lciudad_origen = CType(nfrmdespacho_vs_recepcion.CBIDUNIDAD_AGENCIA.SelectedValue, Long)
                '    objguia_transp_despacho_vs_recepcion.lciudad_destino = CType(nfrmdespacho_vs_recepcion.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Long)
                '    '
                '    'Invocando la consulta 
                '    ' Labnroreg.Text = "Nº de Registro(s) 0 "            
                '    If objguia_transp_despacho_vs_recepcion.fn_destino_trans_despacho_vs_recepcion() Then
                '        odba.Fill(dtciudad_destino, objguia_transp_despacho_vs_recepcion.rst_con_despacho_x_recepcion)
                '        dvciudad_destino = dtciudad_destino.DefaultView
                '        grillaformato()
                '        DGV_destino.DataSource = dvciudad_destino
                '        '
                '        ' Labnroreg.Text = "Nº de Registro(s) " + CType(dv_seguimiento.Count, String)
                '    End If
                '    dtciudad_origen = Nothing
                '    dvciudad_origen = Nothing
                '    grillaformato_det()
                grillaformato()
            End With

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Sub grillaformato()
        Try
            DGV.Columns.Clear()   'Limpiando la grilla 

            With DGV
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
            Dim nombre_unidad_origen As New DataGridViewTextBoxColumn
            With nombre_unidad_origen '0
                .DisplayIndex = 0
                .DataPropertyName = "nombre_unidad_origen"
                .Name = "nombre_unidad_origen"
                .HeaderText = "Unidad Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(nombre_unidad_origen)

            Dim nombre_unidad_destino As New DataGridViewTextBoxColumn
            With nombre_unidad_destino  '0
                .DisplayIndex = 1
                .DataPropertyName = "nombre_unidad_destino"
                .Name = "nombre_unidad_destino"
                .HeaderText = "Unidad Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(nombre_unidad_destino)

            Dim Razon_Social As New DataGridViewTextBoxColumn
            With Razon_Social '1
                .DisplayIndex = 2
                .Name = "razon_social"
                .DataPropertyName = "razon_social"
                .HeaderText = "Razón Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(Razon_Social)

            Dim fecha_guia As New DataGridViewTextBoxColumn
            With fecha_guia '1
                .DisplayIndex = 3
                .Name = "fecha_guia"
                .DataPropertyName = "fecha_guia"
                .HeaderText = "Fecha Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(fecha_guia)

            Dim nro_guia As New DataGridViewTextBoxColumn
            With nro_guia '1
                .DisplayIndex = 4
                .Name = "nro_guia"
                .DataPropertyName = "nro_guia"
                .HeaderText = "Nro. Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(nro_guia)


            '                        
            Dim dgv_Fecha_Salida As New DataGridViewTextBoxColumn
            With dgv_Fecha_Salida  '1
                .DisplayIndex = 5
                .Name = "Fecha_Salida"
                .DataPropertyName = "Fecha_Salida"
                .HeaderText = "Fec. Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(dgv_Fecha_Salida)
            '
            Dim dvg_despacho As New DataGridViewTextBoxColumn
            With dvg_despacho '2
                .DisplayIndex = 6
                .DataPropertyName = "despacho"
                .Name = "despacho"
                .HeaderText = "Despacho"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(dvg_despacho)
            '
            Dim dgv_recepcionar As New DataGridViewTextBoxColumn
            With dgv_recepcionar ' 3
                .DisplayIndex = 7
                .DataPropertyName = "recepcionar"
                .Name = "recepcionar"
                .HeaderText = "Recepción"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(dgv_recepcionar)
            '
            Dim dgv_Por_recepcionar As New DataGridViewTextBoxColumn
            With dgv_Por_recepcionar ' 4
                .DisplayIndex = 8
                .DataPropertyName = "Por_recepcionar"
                .Name = "Por_recepcionar"
                .HeaderText = "Por Recepcionar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(dgv_Por_recepcionar)
            '
            Dim dgv_Entrega_domicilio As New DataGridViewTextBoxColumn
            With dgv_Entrega_domicilio '5
                .DisplayIndex = 9
                .DataPropertyName = "Entrega_domicilio"
                .Name = "Entrega_domicilio"
                .HeaderText = "Entrega Domicilio"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(dgv_Entrega_domicilio)
            '
            Dim dgv_Entrega_agencia As New DataGridViewTextBoxColumn
            With dgv_Entrega_agencia '6
                .DisplayIndex = 10
                .DataPropertyName = "Entrega_agencia"
                .Name = "Entrega_agencia"
                .HeaderText = "Entrega agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(dgv_Entrega_agencia)
            '
            Dim dgv_Total_entregado As New DataGridViewTextBoxColumn
            With dgv_Total_entregado '7
                .DisplayIndex = 11
                .DataPropertyName = "Total_entregado"
                .Name = "Total_entregado"
                .HeaderText = "Total Entregado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(dgv_Total_entregado)
            '
            Dim dgv_Pend_Entrega_domicilio As New DataGridViewTextBoxColumn
            With dgv_Pend_Entrega_domicilio '8
                .DisplayIndex = 12
                .DataPropertyName = "Pend_Entrega_domicilio"
                .Name = "Pend_Entrega_domicilio"
                .HeaderText = "Pend. Entrega Domicilio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(dgv_Pend_Entrega_domicilio)
            '
            Dim dgv_Pend_Entrega_agencia As New DataGridViewTextBoxColumn
            With dgv_Pend_Entrega_agencia '9
                .DisplayIndex = 13
                .Name = "Pend_Entrega_agencia"
                .DataPropertyName = "Pend_Entrega_agencia"
                .HeaderText = "Pend. Entrega Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(dgv_Pend_Entrega_agencia)
            '
            Dim dgv_Total_x_entregar As New DataGridViewTextBoxColumn
            With dgv_Total_x_entregar '10
                .DisplayIndex = 14
                .Name = "Total_x_entregar"
                .DataPropertyName = "Total_x_entregar"
                .HeaderText = "Total x entregar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            DGV.Columns.Add(dgv_Total_x_entregar)
            '
            Dim dgv_idunidad_agencia_destino As New DataGridViewTextBoxColumn
            With dgv_idunidad_agencia_destino '11
                .DisplayIndex = 15
                .Name = "idunidad_agencia_destino"
                .DataPropertyName = "idunidad_agencia_destino"
                .HeaderText = "idciudad_destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            DGV.Columns.Add(dgv_idunidad_agencia_destino)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
End Class