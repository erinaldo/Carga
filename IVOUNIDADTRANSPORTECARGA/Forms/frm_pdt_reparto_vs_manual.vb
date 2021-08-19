Public Class frm_pdt_reparto_vs_manual
#Region "Variables"
    'Dim odba As New OleDb.OleDbDataAdapter
    Dim dt_agencias, dt_bultos_leidos_pdt_vs_manual As New DataTable
    Dim dv_agencias, dv_bultos_leidos_pdt_vs_manual As New DataView
    '
    Private ObjReport As ClsLbTepsa.dtoFrmReport
    Dim bIngreso As Boolean = False
    Public hnd As Long
    '
#End Region
#Region "Eventos"

    Private Sub frm_pdt_reparto_vs_manual_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub
    ' Dispose  
    Private Sub frm_pdt_recepcion_vs_manual_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub frm_pdt_reparto_vs_manual_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    'load
    Private Sub frm_pdt_recepcion_vs_manual_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim li_agencia As Long
            'Cargando valores inciales al formulario 
            DTPFECHAINICIOFACTURA.Value = dtoUSUARIOS.dfecha_sistema
            DTPFECHAFINALFACTURA.Value = dtoUSUARIOS.dfecha_sistema
            '-- objsalidavehiculodespacho.fnLoad_salida_vehiculo()
            Me.ShadowLabel1.Text = "Consulta de Bultos leídos con Pdt en el Reparto contra Forma Manual"
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
            ' 
            objbultos_leidos_pdt_vs_manual.li_idagencias = dtoUSUARIOS.iIDAGENCIAS
            objbultos_leidos_pdt_vs_manual.vi_fecha_inicio = CType(DTPFECHAINICIOFACTURA.Value, String)
            objbultos_leidos_pdt_vs_manual.vi_fecha_final = CType(DTPFECHAFINALFACTURA.Value, String)
            '
            li_agencia = dtoUSUARIOS.iIDAGENCIAS
            'Mod.07/10/2009 -->Omendoza - Pasando al datahelper 
            If objbultos_leidos_pdt_vs_manual.fn_load_bultos_leidos_reparto_pdt_vs_manual Then
                '
                'odba.Fill(dt_agencias, objbultos_leidos_pdt_vs_manual.rst_agencia)
                'odba.Fill(dt_bultos_leidos_pdt_vs_manual, objbultos_leidos_pdt_vs_manual.rst_bultos_leidos_pdt_vs_manual)
                '
                dt_agencias = objbultos_leidos_pdt_vs_manual.dt_rst_agencia
                dt_bultos_leidos_pdt_vs_manual = objbultos_leidos_pdt_vs_manual.dt_rst_bultos_leidos_pdt_vs_manual
                '            
                dv_bultos_leidos_pdt_vs_manual = dt_bultos_leidos_pdt_vs_manual.DefaultView
            Else
                MsgBox("No se ha podido establecer, los valores de ayuda", MsgBoxStyle.Critical, "Sistema de Seguridad")
                Me.Close()
                Exit Sub
            End If
            '
            dv_agencias = CargarCombo(Me.cbm_agencias, dt_agencias, "NOMBRE_AGENCIA", "IDAGENCIAS", li_agencia)
            grillaformato()
            dgv_pdt_vs_manual.DataSource = dv_bultos_leidos_pdt_vs_manual
            fn_totalizar()
            '
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    'Imprimir 
    Private Sub frm_pdt_recepcion_vs_manual_MenuImprimir() Handles Me.MenuImprimir
        Try
            ObjReport.Dispose()
        Catch
        End Try
        '"GUIAT015.RPT" antes era el GUIAT014.RPT -->        
        ObjReport = New ClsLbTepsa.dtoFrmReport
        ObjReport.rutaRpt = PathFrmReport
        ObjReport.conectar(rptservice, rptuser, rptpass)
        ObjReport.printrpt(False, "", "GUIAT015.RPT", "VI_AGENCIA;" & Me.cbm_agencias.Text, _
        "NI_IDAGENCIAS;" & Me.cbm_agencias.SelectedValue, _
        "VI_FECHA_INICIO;" & Me.DTPFECHAINICIOFACTURA.Text, _
        "VI_FECHA_FINAL;" & Me.DTPFECHAFINALFACTURA.Text)
    End Sub

    'Salir 
    Private Sub frm_pdt_recepcion_vs_manual_MenuSalir() Handles Me.MenuSalir
        Me.Close()
    End Sub
    'Btn_filtrar 
    Private Sub btn_filtrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_filtrar.Click
        objbultos_leidos_pdt_vs_manual.li_idagencias = CType(Me.cbm_agencias.SelectedValue, Long)
        objbultos_leidos_pdt_vs_manual.vi_fecha_inicio = CType(DTPFECHAINICIOFACTURA.Value, String)
        objbultos_leidos_pdt_vs_manual.vi_fecha_final = CType(DTPFECHAFINALFACTURA.Value, String)
        'Mod.07/10/2009 -->Omendoza - Pasando al datahelper -  
        If objbultos_leidos_pdt_vs_manual.fn_bultos_leidos_reparto_pdt_vs_manual() Then
            dv_bultos_leidos_pdt_vs_manual = Nothing
            dt_bultos_leidos_pdt_vs_manual = Nothing
            dv_bultos_leidos_pdt_vs_manual = New DataView
            dt_bultos_leidos_pdt_vs_manual = New DataTable
            '
            'odba.Fill(dt_bultos_leidos_pdt_vs_manual, objbultos_leidos_pdt_vs_manual.rst_bultos_leidos_pdt_vs_manual)
            '
            dt_bultos_leidos_pdt_vs_manual = objbultos_leidos_pdt_vs_manual.dt_rst_bultos_leidos_pdt_vs_manual
            dv_bultos_leidos_pdt_vs_manual = dt_bultos_leidos_pdt_vs_manual.DefaultView
            grillaformato()
            dgv_pdt_vs_manual.DataSource = dv_bultos_leidos_pdt_vs_manual
            fn_totalizar()
        End If
    End Sub
#End Region
#Region "Procedimientos y Funciones"
    Sub grillaformato()
        Try
            dgv_pdt_vs_manual.Columns.Clear()   'Limpiando la grilla 
            With dgv_pdt_vs_manual
                .AllowUserToAddRows = False
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            '
            Dim agencia_origen As New DataGridViewTextBoxColumn
            With agencia_origen '0
                .DisplayIndex = 0
                .DataPropertyName = "agencia_origen"
                .Name = "agencia_origen"
                .HeaderText = "Agencia Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_pdt_vs_manual.Columns.Add(agencia_origen)
            '
            Dim dgv_fecha_salida As New DataGridViewTextBoxColumn
            With dgv_fecha_salida '1
                .DisplayIndex = 1
                .DataPropertyName = "fecha_salida"
                .Name = "fecha_salida"
                .HeaderText = "Fecha Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_pdt_vs_manual.Columns.Add(dgv_fecha_salida)
            '                        
            Dim dgv_serie_guia_transportista As New DataGridViewTextBoxColumn
            With dgv_serie_guia_transportista  '2
                .DisplayIndex = 2
                .Name = "serie_guia_transportista"
                .DataPropertyName = "serie_guia_transportista"
                .HeaderText = "Serie Guia Transp."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_pdt_vs_manual.Columns.Add(dgv_serie_guia_transportista)
            '
            Dim dvg_nro_guia_transportista As New DataGridViewTextBoxColumn
            With dvg_nro_guia_transportista '3
                .DisplayIndex = 3
                .DataPropertyName = "nro_guia_transportista"
                .Name = "nro_guia_transportista"
                .HeaderText = "Nro Guía Transp."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_pdt_vs_manual.Columns.Add(dvg_nro_guia_transportista)
            ' 
            Dim nro_bus As New DataGridViewTextBoxColumn
            With nro_bus '4
                .DisplayIndex = 4
                .DataPropertyName = "nro_bus"
                .Name = "nro_bus"
                .HeaderText = "Nro Bus"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_pdt_vs_manual.Columns.Add(nro_bus)
            '
            Dim dgv_TIPO_DOC As New DataGridViewTextBoxColumn
            With dgv_TIPO_DOC ' 5
                .DisplayIndex = 5
                .DataPropertyName = "TIPO_DOC"
                .Name = "TIPO_DOC"
                .HeaderText = "Tipo Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_pdt_vs_manual.Columns.Add(dgv_TIPO_DOC)
            '
            Dim origen As New DataGridViewTextBoxColumn
            With origen ' 6
                .DisplayIndex = 6
                .DataPropertyName = "origen"
                .Name = "origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_pdt_vs_manual.Columns.Add(origen)
            '
            Dim destino As New DataGridViewTextBoxColumn
            With destino ' 7
                .DisplayIndex = 7
                .DataPropertyName = "destino"
                .Name = "destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_pdt_vs_manual.Columns.Add(destino)
            '
            Dim remitente As New DataGridViewTextBoxColumn
            With remitente ' 8
                .DisplayIndex = 8
                .DataPropertyName = "remitente"
                .Name = "remitente"
                .HeaderText = "Remitente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_pdt_vs_manual.Columns.Add(remitente)
            '
            Dim dgv_NRO_DOC As New DataGridViewTextBoxColumn
            With dgv_NRO_DOC ' 9
                .DisplayIndex = 9
                .DataPropertyName = "NRO_DOC"
                .Name = "NRO_DOC"
                .HeaderText = "Nro Doc"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_pdt_vs_manual.Columns.Add(dgv_NRO_DOC)
            '
            Dim dgv_cantidad_despachada As New DataGridViewTextBoxColumn
            With dgv_cantidad_despachada ' 10
                .DisplayIndex = 10
                .DataPropertyName = "cantidad_despachada"
                .Name = "cantidad_despachada"
                .HeaderText = "Cantidad Despachada"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_pdt_vs_manual.Columns.Add(dgv_cantidad_despachada)
            '
            Dim dgv_Bultos_Manual As New DataGridViewTextBoxColumn
            With dgv_Bultos_Manual '11
                .DisplayIndex = 11
                .DataPropertyName = "Bultos_Manual"
                .Name = "Bultos_Manual"
                .HeaderText = "Nº Bultos Manual"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dgv_pdt_vs_manual.Columns.Add(dgv_Bultos_Manual)
            '
            Dim dgv_Bultos_Pda As New DataGridViewTextBoxColumn
            With dgv_Bultos_Pda '12
                .DisplayIndex = 12
                .DataPropertyName = "Bultos_Pda"
                .Name = "Bultos_Pda"
                .HeaderText = "Nº Bultos Pdt"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dgv_pdt_vs_manual.Columns.Add(dgv_Bultos_Pda)
            ' 
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    '---
    Sub fn_totalizar()
        Try
            Dim ll_tot_pda As Long = 0
            Dim ll_tot_manual As Long = 0
            Dim ld_porc_manual As Double = 0.0
            Dim ld_porc_pda As Double = 0.0

            For i As Integer = 0 To Me.dgv_pdt_vs_manual.Rows.Count - 1
                ll_tot_pda = ll_tot_pda + CType(Me.dgv_pdt_vs_manual.Rows(i).Cells("Bultos_Pda").Value, Long)
                ll_tot_manual = ll_tot_manual + CType(Me.dgv_pdt_vs_manual.Rows(i).Cells("Bultos_Manual").Value, Long)
            Next
            '
            Me.txt_tot_manual.Text = CType(ll_tot_manual, String)
            Me.txt_tot_pda.Text = CType(ll_tot_pda, String)
            '
            If ll_tot_manual = 0 And ll_tot_pda = 0 Then
                Me.txt_porc_manual.Text = "0"
                Me.txt_porc_pda.Text = "0"
            Else
                Me.txt_porc_manual.Text = FormatNumber((ll_tot_manual / (ll_tot_manual + ll_tot_pda)) * 100, 2)
                Me.txt_porc_pda.Text = FormatNumber((ll_tot_pda / (ll_tot_manual + ll_tot_pda)) * 100, 2)
            End If
            '
            Me.lab_registro.Text = Me.dgv_pdt_vs_manual.Rows.Count
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

    Private Sub dgv_pdt_vs_manual_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_pdt_vs_manual.CellContentClick

    End Sub

    Private Sub dgv_pdt_vs_manual_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv_pdt_vs_manual.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv_pdt_vs_manual), 0)
    End Sub

    Private Sub dgv_pdt_vs_manual_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv_pdt_vs_manual.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv_pdt_vs_manual), 0)
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.dgv_pdt_vs_manual.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.dgv_pdt_vs_manual.DataSource = Nothing
    End Sub

    Private Sub cbm_agencias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbm_agencias.SelectedIndexChanged
        Me.dgv_pdt_vs_manual.DataSource = Nothing
    End Sub
End Class
