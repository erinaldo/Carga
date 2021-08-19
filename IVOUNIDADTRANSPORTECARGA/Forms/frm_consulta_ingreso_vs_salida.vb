Public Class frm_consulta_ingreso_vs_salida
#Region "Variables publicas"
    Public hnd As Long
#End Region
#Region "Variables privadas"
    'Dim odba_conecta As New OleDb.OleDbDataAdapter
    Dim obj_ingresos_vs_salida As New dto_ingresos_vs_salida
    Dim ldt_idagencia_origen, ldt_idagencia_destino, ldt_idunidad_origen, ldt_idunidad_destino As New DataTable
    Dim ldv_idagencia_origen, ldv_idagencia_destino, ldv_idunidad_origen, ldv_idunidad_destino As New DataView
    Dim b_lee As Boolean = True
    Dim bIngreso As Boolean = False
#End Region
#Region "Eventos adicionales"

#End Region
#Region "Eventos"

    Private Sub frm_consulta_ingreso_vs_salida_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frm_consulta_ingreso_vs_salida_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frm_consulta_ingreso_vs_salida_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Dim lrst_carga_datos_ciudad, lrst_carga_datos_agencia As New ADODB.Recordset
        Try
            'Configura
            'Cargando valores inciales al formulario 
            DTPFECHAINICIOFACTURA.Value = dtoUSUARIOS.dfecha_sistema
            DTPFECHAFINALFACTURA.Value = dtoUSUARIOS.dfecha_sistema
            '-- objsalidavehiculodespacho.fnLoad_salida_vehiculo()
            Me.ShadowLabel1.Text = "Consulta de los ingresos contra los despachos"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            Me.MenuStrip1.Items(1).Enabled = False
            Me.MenuStrip1.Items(2).Enabled = False
            Me.MenuStrip1.Items(3).Enabled = False
            Me.MenuStrip1.Items(4).Enabled = False
            Me.MenuStrip1.Items(5).Enabled = False
            ' 
            MenuTab.Items(0).Text = "Consulta"
            '
            MenuTab.Items(0).Enabled = True
            MenuTab.Items(0).Visible = True
            'Recupera lista
            'Mod.07/10/2009 -->Omendoza - Pasando al datahelper -  
            'lrst_carga_datos_ciudad = obj_ingresos_vs_salida.fn_carga_datos
            'lrst_carga_datos_agencia = lrst_carga_datos_ciudad.NextRecordset
            'odba_conecta.Fill(ldt_idunidad_origen, lrst_carga_datos_ciudad)
            'odba_conecta.Fill(ldt_idagencia_origen, lrst_carga_datos_agencia)
            Dim lds_tmp As New DataSet
            '
            lds_tmp = obj_ingresos_vs_salida.fn_carga_datos_datos
            '
            ldt_idunidad_origen = lds_tmp.Tables(0)
            ldt_idagencia_origen = lds_tmp.Tables(1)
            '
            ldt_idunidad_destino = ldt_idunidad_origen.Copy()
            ldt_idagencia_destino = ldt_idagencia_origen.Copy()
            '
            ldv_idagencia_origen = ldt_idagencia_origen.DefaultView
            ldv_idagencia_destino = ldt_idagencia_destino.DefaultView
            '
            b_lee = False
            ldv_idunidad_origen = CargarCombo(Me.cmb_ciudad_origen, ldt_idunidad_origen, "nombre_unidad", "idunidad_agencia", 0)
            ldv_idunidad_destino = CargarCombo(Me.cmb_ciudad_destino, ldt_idunidad_destino, "nombre_unidad", "idunidad_agencia", 0)
            ldv_idagencia_origen = CargarCombo(Me.cmb_agencia_origen, ldt_idagencia_origen, "NOMBRE_AGENCIA", "IDAGENCIAS", 0)
            'ldv_idagencia_origen = ldt_idagencia_origen.DefaultView
            ldv_idagencia_destino = CargarCombo(Me.cmb_agencia_destino, ldt_idagencia_destino, "NOMBRE_AGENCIA", "IDAGENCIAS", 0)
            'ldv_idagencia_destino = ldt_idagencia_destino.DefaultView
            b_lee = True
            '
            grillaformato()
            fn_totalizar()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub btn_filtrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_filtrar.Click
        'Dim ll_idagencia_origen, ll_idagencia_destino, ll_idunidad_origen, ll_idunidad_destino As Long
        'Dim lrst_salida_vs_despacho As New ADODB.Recordset
        Dim ldt_consulta_salida_vs_despacho As New DataTable
        'Dim ls_fecha_inicio, ls_fecha_destino As String
        Try
            obj_ingresos_vs_salida.idciudad_origen = Me.cmb_ciudad_origen.SelectedValue
            obj_ingresos_vs_salida.idunidad_destino = Me.cmb_ciudad_destino.SelectedValue
            obj_ingresos_vs_salida.idagencia_origen = Me.cmb_agencia_origen.SelectedValue
            obj_ingresos_vs_salida.idagencia_destino = Me.cmb_agencia_destino.SelectedValue
            obj_ingresos_vs_salida.fecha_inicio = CType(Me.DTPFECHAINICIOFACTURA.Value, String)
            obj_ingresos_vs_salida.fecha_final = CType(Me.DTPFECHAFINALFACTURA.Value, String)
            '

            'Mod.07/10/2009 -->Omendoza - Pasando al datahelper -  
            'lrst_salida_vs_despacho = obj_ingresos_vs_salida.fn_recupera_consulta()
            'odba_conecta.Fill(ldt_consulta_salida_vs_despacho, lrst_salida_vs_despacho)
            ldt_consulta_salida_vs_despacho = obj_ingresos_vs_salida.fn_recupera_consulta()
            '
            grillaformato()
            Me.dgv_consulta.DataSource = ldt_consulta_salida_vs_despacho.DefaultView
            fn_totalizar()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cmb_ciudad_origen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_ciudad_origen.SelectedIndexChanged
        Dim ll_idunidad_agencia As Long
        Try
            Me.dgv_consulta.DataSource = Nothing
            If b_lee = True Then
                ll_idunidad_agencia = Me.cmb_ciudad_origen.SelectedValue
                If ll_idunidad_agencia = 0 Then
                    ldv_idagencia_origen.RowFilter = ""
                Else
                    ldv_idagencia_origen.RowFilter = "idunidad_agencia = " & ll_idunidad_agencia
                End If
                Me.cmb_agencia_origen.DataSource = ldv_idagencia_origen
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cmb_ciudad_destino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_ciudad_destino.SelectedIndexChanged
        Dim ll_idunidad_agencia As Long
        Try
            Me.dgv_consulta.DataSource = Nothing
            If b_lee = True Then
                ll_idunidad_agencia = Me.cmb_ciudad_destino.SelectedValue
                If ll_idunidad_agencia = 0 Then
                    ldv_idagencia_destino.RowFilter = ""
                Else
                    ldv_idagencia_destino.RowFilter = "idunidad_agencia = " & ll_idunidad_agencia
                End If
                Me.cmb_agencia_destino.DataSource = ldv_idagencia_destino
            End If
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
#Region "Funciones y Procedimientos"
    Sub grillaformato()
        Try
            dgv_consulta.Columns.Clear()   'Limpiando la grilla 
            With dgv_consulta
                .AllowUserToAddRows = False
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                .AutoGenerateColumns = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            '
            Dim fecha_guia As New DataGridViewTextBoxColumn
            With fecha_guia '0
                .DisplayIndex = 0
                .DataPropertyName = "fecha_guia"
                .Name = "fecha_guia"
                .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(fecha_guia)
            '
            Dim ciudad_origen As New DataGridViewTextBoxColumn
            With ciudad_origen
                .DisplayIndex = 1
                .DataPropertyName = "ciudad_origen"
                .Name = "ciudad_origen"
                .HeaderText = "Ciudad Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(ciudad_origen)
            '
            Dim ciudad_destino As New DataGridViewTextBoxColumn
            With ciudad_destino
                .DisplayIndex = 2
                .DataPropertyName = "ciudad_destino"
                .Name = "ciudad_destino"
                .HeaderText = "Ciudad Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(ciudad_destino)
            '                        
            Dim agencia_origen As New DataGridViewTextBoxColumn
            With agencia_origen
                .DisplayIndex = 3
                .Name = "agencia_origen"
                .DataPropertyName = "agencia_origen"
                .HeaderText = "Ag. Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(agencia_origen)
            '
            Dim agencia_destino As New DataGridViewTextBoxColumn
            With agencia_destino
                .DisplayIndex = 4
                .DataPropertyName = "agencia_destino"
                .Name = "agencia_destino"
                .HeaderText = "Ag. Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(agencia_destino)
            ' 
            Dim nro_documentos As New DataGridViewTextBoxColumn
            With nro_documentos
                .DisplayIndex = 5
                .DataPropertyName = "nro_documentos"
                .Name = "nro_documentos"
                .HeaderText = "Tot. Dctos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(nro_documentos)
            '
            Dim cantidad_total As New DataGridViewTextBoxColumn
            With cantidad_total
                .DisplayIndex = 6
                .DataPropertyName = "cantidad_total"
                .Name = "cantidad_total"
                .HeaderText = "Bultos Ingresados"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(cantidad_total)
            '
            Dim peso_total As New DataGridViewTextBoxColumn
            With peso_total
                .DisplayIndex = 7
                .DataPropertyName = "peso_total"
                .Name = "peso_total"
                .HeaderText = "Peso Ingresado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(peso_total)
            '
            Dim tot_bulto_x_otro_ingreso As New DataGridViewTextBoxColumn
            With tot_bulto_x_otro_ingreso
                .DisplayIndex = 8
                .DataPropertyName = "tot_bulto_x_otro_ingreso"
                .Name = "tot_bulto_x_otro_ingreso"
                .HeaderText = "Bultos Transferidos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(tot_bulto_x_otro_ingreso)
            '
            Dim tot_peso_x_otro_ingreso As New DataGridViewTextBoxColumn
            With tot_peso_x_otro_ingreso
                .DisplayIndex = 9
                .DataPropertyName = "tot_peso_x_otro_ingreso"
                .Name = "tot_peso_x_otro_ingreso"
                .HeaderText = "Peso Transferidos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(tot_peso_x_otro_ingreso)
            '
            Dim tot_bulto_despacho_x_dia As New DataGridViewTextBoxColumn
            With tot_bulto_despacho_x_dia
                .DisplayIndex = 10
                .DataPropertyName = "tot_bulto_despacho_x_dia"
                .Name = "tot_bulto_despacho_x_dia"
                .HeaderText = "Bultos Despachados"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(tot_bulto_despacho_x_dia)
            '
            Dim tot_peso_despacho_x_dia As New DataGridViewTextBoxColumn
            With tot_peso_despacho_x_dia
                .DisplayIndex = 11
                .DataPropertyName = "tot_peso_despacho_x_dia"
                .Name = "tot_peso_despacho_x_dia"
                .HeaderText = "Peso Despachado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(tot_peso_despacho_x_dia)
            '
            Dim tot_bulto_dias_ante As New DataGridViewTextBoxColumn
            With tot_bulto_dias_ante
                .DisplayIndex = 12
                .DataPropertyName = "tot_bulto_dias_ante"
                .Name = "tot_bulto_dias_ante"
                .HeaderText = "Bultos Despa. dias anteriores"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(tot_bulto_dias_ante)
            '
            Dim tot_peso_dias_ante As New DataGridViewTextBoxColumn
            With tot_peso_dias_ante
                .DisplayIndex = 13
                .DataPropertyName = "tot_peso_dias_ante"
                .Name = "tot_peso_dias_ante"
                .HeaderText = "Peso Despa. dias anteriores"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(tot_peso_dias_ante)
            '
            Dim tot_costo_despacho As New DataGridViewTextBoxColumn
            With tot_costo_despacho
                .DisplayIndex = 14
                .DataPropertyName = "tot_costo_despacho"
                .Name = "tot_costo_despacho"
                .HeaderText = "Costo Despacho"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(tot_costo_despacho)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Sub fn_totalizar()
        Try
            Dim ll_tot_ingresado As Long = 0
            Dim ll_tot_depacho_dia As Long = 0
            Dim ll_tot_depacho_anterior As Long = 0
            Dim ld_porc_manual As Double = 0.0
            Dim ld_porc_pda As Double = 0.0

            For i As Integer = 0 To Me.dgv_consulta.Rows.Count - 1
                ll_tot_ingresado = ll_tot_ingresado + CType(Me.dgv_consulta.Rows(i).Cells("cantidad_total").Value, Long) + CType(Me.dgv_consulta.Rows(i).Cells("tot_bulto_x_otro_ingreso").Value, Long)
                ll_tot_depacho_dia = ll_tot_depacho_dia + CType(Me.dgv_consulta.Rows(i).Cells("tot_bulto_despacho_x_dia").Value, Long)
                ll_tot_depacho_anterior = ll_tot_depacho_anterior + CType(Me.dgv_consulta.Rows(i).Cells("tot_bulto_dias_ante").Value, Long)
            Next
            '
            Me.txt_tot_bultos_ingresado.Text = CType(ll_tot_ingresado, String)
            Me.txt_tot_despa_dia.Text = CType(ll_tot_depacho_dia, String)
            Me.txt_tot_desp_anterior.Text = CType(ll_tot_depacho_anterior, String)
            '
            If ll_tot_depacho_dia = 0 And ll_tot_depacho_anterior = 0 Then
                Me.txt_porc_dia.Text = "0"
                Me.txt_porc_anterior.Text = "0"
            Else
                Me.txt_porc_dia.Text = FormatNumber((ll_tot_depacho_dia / (ll_tot_depacho_dia + ll_tot_depacho_anterior)) * 100, 2)
                Me.txt_porc_anterior.Text = FormatNumber((ll_tot_depacho_anterior / (ll_tot_depacho_dia + ll_tot_depacho_anterior)) * 100, 2)
            End If
            ' 
            Me.lab_registro.Text = Me.dgv_consulta.Rows.Count
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub dgv_consulta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_consulta.CellContentClick

    End Sub

    Private Sub dgv_consulta_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv_consulta.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv_consulta), 0)
    End Sub

    Private Sub dgv_consulta_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv_consulta.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv_consulta), 0)
    End Sub

    Private Sub cmb_agencia_origen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_agencia_origen.SelectedIndexChanged
        Me.dgv_consulta.DataSource = Nothing
    End Sub

    Private Sub cmb_agencia_destino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_agencia_destino.SelectedIndexChanged
        Me.dgv_consulta.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.dgv_consulta.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.dgv_consulta.DataSource = Nothing
    End Sub
End Class
