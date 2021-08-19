Public Class FrmConsultaliquidaciones
#Region "Variables"
    Dim odba As New OleDb.OleDbDataAdapter
    Dim objconsulta_liquidaciones As New dtoconsulta_liquidaciones
    Dim dt_agencias, dt_liquidaciones As New DataTable
    Dim dv_agencias, dv_liquidaciones As New DataView
    '
    Private ObjReport As ClsLbTepsa.dtoFrmReport
    Dim bIngreso As Boolean = False
    Public hnd As Long
    '
#End Region
#Region "Eventos"

    Private Sub FrmConsultaliquidaciones_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub
    ' Dispose  
    Private Sub FrmConsultaliquidaciones_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub FrmConsultaliquidaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    'load
    Private Sub FrmConsultaliquidaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim li_agencia As Long
            'datahelper
            'Dim lrst_listado_liquidacion 'lrst_load As New ADODB.Recordset
            Dim lrst_load As DataTable
            Dim lrst_listado_liquidacion As DataTable
            'Cargando valores inciales al formulario 
            DTPFECHAINICIOFACTURA.Value = dtoUSUARIOS.dfecha_sistema
            DTPFECHAFINALFACTURA.Value = dtoUSUARIOS.dfecha_sistema
            '-- objsalidavehiculodespacho.fnLoad_salida_vehiculo()
            Me.ShadowLabel1.Text = "Consulta de Liquidaciones"
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
            ImprimirToolStripMenuItem.Enabled = False
            ImprimirToolStripMenuItem.Visible = False

            EdicionToolStripMenuItem.Enabled = False
            EdicionToolStripMenuItem.Visible = False
            '
            SalirToolStripMenuItem.Enabled = True
            SalirToolStripMenuItem.Visible = True
            ' 
            objconsulta_liquidaciones.idagencia = dtoUSUARIOS.iIDAGENCIAS
            objconsulta_liquidaciones.fecha_inicio = CType(DTPFECHAINICIOFACTURA.Value, String)
            objconsulta_liquidaciones.fecha_final = CType(DTPFECHAFINALFACTURA.Value, String)
            '
            li_agencia = dtoUSUARIOS.iIDAGENCIAS
            '
            'datahelper
            'lrst_load = objconsulta_liquidaciones.fn_load()
            'lrst_listado_liquidacion = lrst_load.NextRecordset()
            'odba.Fill(dt_agencias, lrst_load)
            'odba.Fill(dt_liquidaciones, lrst_listado_liquidacion)
            'dv_liquidaciones = dt_liquidaciones.DefaultView
            '
            Dim ds As DataSet = objconsulta_liquidaciones.fn_load()
            lrst_load = ds.Tables(0)
            lrst_listado_liquidacion = ds.Tables(1)
            dt_agencias = lrst_load
            dt_liquidaciones = lrst_listado_liquidacion
            dv_liquidaciones = dt_liquidaciones.DefaultView

            dv_agencias = CargarCombo(Me.cbm_agencias, dt_agencias, "NOMBRE_AGENCIA", "IDAGENCIAS", li_agencia)
            grillaformato()
            Me.dgv_lista_liquidaciones.DataSource = dv_liquidaciones
            lab_registros.Text = CType(Me.dgv_lista_liquidaciones.RowCount, String)
            Me.rb_credito.Checked = True
            Me.rb_contado.Checked = False
            Me.lab_titulo.Text = "Liquidaciones Crédito"
            'fn_totalizar()
            ' 
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    'Imprimir 
    Private Sub FrmConsultaliquidaciones_MenuImprimir() Handles Me.MenuImprimir
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
    Private Sub FrmConsultaliquidaciones_MenuSalir() Handles Me.MenuSalir
        Me.Close()
    End Sub
    'Btn_filtrar 
    Private Sub btn_filtrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_filtrar.Click
        'datahelper
        'Dim lrst_liquidaciones As New ADODB.Recordset
        Dim lrst_liquidaciones As New DataTable
        Dim ll_tipo_consulta As Long
        Try
            'Debe 
            If Me.rb_contado.Checked = True Then
                ll_tipo_consulta = 1  'Contado  
            End If
            If Me.rb_credito.Checked = True Then
                ll_tipo_consulta = 0 ' Crédito 
            End If
            '
            objconsulta_liquidaciones.idagencia = CType(Me.cbm_agencias.SelectedValue, Long)
            objconsulta_liquidaciones.fecha_inicio = CType(DTPFECHAINICIOFACTURA.Value, String)
            objconsulta_liquidaciones.fecha_final = CType(DTPFECHAFINALFACTURA.Value, String)
            'datahelper
            'lrst_liquidaciones = objconsulta_liquidaciones.fn_lista_liquidaciones()
            'dt_liquidaciones = Nothing
            'dv_liquidaciones = Nothing
            'dv_liquidaciones = New DataView
            'dt_liquidaciones = New DataTable
            ''
            'odba.Fill(dt_liquidaciones, lrst_liquidaciones)
            lrst_liquidaciones = objconsulta_liquidaciones.fn_lista_liquidaciones()
            dt_liquidaciones = lrst_liquidaciones
            dv_liquidaciones = dt_liquidaciones.DefaultView
            grillaformato()
            Me.dgv_lista_liquidaciones.DataSource = dv_liquidaciones
            lab_registros.Text = CType(Me.dgv_lista_liquidaciones.RowCount, String)
            'fn_totalizar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
#End Region
#Region "Procedimientos y Funciones"
    Sub grillaformato()
        Try
            dgv_lista_liquidaciones.Columns.Clear()   'Limpiando la grilla 
            With dgv_lista_liquidaciones
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
            End With
            '
            Dim nombre_unidad As New DataGridViewTextBoxColumn
            With nombre_unidad '0
                .DisplayIndex = 0
                .DataPropertyName = "nombre_unidad"
                .Name = "nombre_unidad"
                .HeaderText = "Ciudad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_lista_liquidaciones.Columns.Add(nombre_unidad)
            '
            Dim nombre_agencia As New DataGridViewTextBoxColumn
            With nombre_agencia '1
                .DisplayIndex = 1
                .DataPropertyName = "nombre_agencia"
                .Name = "nombre_agencia"
                .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_lista_liquidaciones.Columns.Add(nombre_agencia)
            '                        
            Dim usuario As New DataGridViewTextBoxColumn
            With usuario '2
                .DisplayIndex = 2
                .Name = "usuario"
                .DataPropertyName = "usuario"
                .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_lista_liquidaciones.Columns.Add(usuario)
            '
            Dim fecha_apertura As New DataGridViewTextBoxColumn
            With fecha_apertura '3
                .DisplayIndex = 3
                .DataPropertyName = "fecha_apertura"
                .Name = "fecha_apertura"
                .HeaderText = "Fecha Apertura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_lista_liquidaciones.Columns.Add(fecha_apertura)
            ' 
            Dim fecha_cierre As New DataGridViewTextBoxColumn
            With fecha_cierre '4
                .DisplayIndex = 4
                .DataPropertyName = "fecha_cierre"
                .Name = "fecha_cierre"
                .HeaderText = "Fecha Cierre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_lista_liquidaciones.Columns.Add(fecha_cierre)
            '
            Dim nro_transacciones As New DataGridViewTextBoxColumn
            With nro_transacciones ' 5
                .DisplayIndex = 5
                .DataPropertyName = "nro_transacciones"
                .Name = "nro_transacciones"
                .HeaderText = "nro_transacciones"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_lista_liquidaciones.Columns.Add(nro_transacciones)
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    '---
    Sub fn_totalizar()
        Try
            'Dim ll_tot_pda As Long = 0
            'Dim ll_tot_manual As Long = 0
            'Dim ld_porc_manual As Double = 0.0
            'Dim ld_porc_pda As Double = 0.0

            'For i As Integer = 0 To Me.dgv_lista_liquidaciones.Rows.Count - 1
            '    ll_tot_pda = ll_tot_pda + CType(Me.dgv_lista_liquidaciones.Rows(i).Cells("Bultos_Pda").Value, Long)
            '    ll_tot_manual = ll_tot_manual + CType(Me.dgv_lista_liquidaciones.Rows(i).Cells("Bultos_Manual").Value, Long)
            'Next
            ''
            'Me.txt_tot_manual.Text = CType(ll_tot_manual, String)
            'Me.txt_tot_pda.Text = CType(ll_tot_pda, String)
            ''
            'Me.txt_porc_manual.Text = FormatNumber((ll_tot_manual / (ll_tot_manual + ll_tot_pda)) * 100, 2)
            'Me.txt_porc_pda.Text = FormatNumber((ll_tot_pda / (ll_tot_manual + ll_tot_pda)) * 100, 2)
            '' 
            'Me.lab_registro.Text = Me.dgv_lista_liquidaciones.Rows.Count
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region

    Private Sub rb_credito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_credito.Click
        Try
            Me.rb_credito.Checked = True
            Me.rb_contado.Checked = False
            Me.lab_titulo.Text = "Liquidaciones Crédito"
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rb_contado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_contado.Click
        Try
            Me.rb_credito.Checked = False
            Me.rb_contado.Checked = True
            Me.lab_titulo.Text = "Liquidaciones Contado"
        Catch ex As Exception

        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub dgv_lista_liquidaciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_lista_liquidaciones.CellContentClick

    End Sub

    Private Sub dgv_lista_liquidaciones_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv_lista_liquidaciones.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv_lista_liquidaciones), 0)
    End Sub

    Private Sub dgv_lista_liquidaciones_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv_lista_liquidaciones.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv_lista_liquidaciones), 0)
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.dgv_lista_liquidaciones.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.dgv_lista_liquidaciones.DataSource = Nothing
    End Sub

    Private Sub rb_credito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_credito.CheckedChanged
        Me.dgv_lista_liquidaciones.DataSource = Nothing
    End Sub

    Private Sub rb_contado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_contado.CheckedChanged
        Me.dgv_lista_liquidaciones.DataSource = Nothing
    End Sub

    Private Sub cbm_agencias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbm_agencias.SelectedIndexChanged
        Me.dgv_lista_liquidaciones.DataSource = Nothing
    End Sub
End Class
