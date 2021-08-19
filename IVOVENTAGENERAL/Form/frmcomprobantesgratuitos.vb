Public Class frmcomprobantesgratuitos
#Region "Variables"
    'Dim odba As New OleDb.OleDbDataAdapter
    Dim dtagencias, dtcondicion, dtcomprobante As New DataTable
    Dim dvagencias, dvcondicion, dvcomprobante As New DataView
    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long
#End Region

    Private Sub frmcomprobantesgratuitos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmcomprobantesgratuitos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ShadowLabel1.Text = "Consulta de Comprobantes Gratuitos"
            MenuTab.Items(0).Text = "Consulta"
            '
            Me.GrabarToolStripMenuItem.Visible = False
            Me.CancelarToolStripmenuItem.Visible = False
            Me.EdicionToolStripMenuItem.Visible = False
            Me.EliminarToolStripMenuItem.Visible = False
            Me.NuevoToolStripMenuItem.Visible = False
            Me.ExcelToolStripMenuItem.Visible = False
            '
            MenuTab.Items(1).Enabled = False
            MenuTab.Items(2).Enabled = False
            MenuTab.Items(3).Enabled = False
            MenuTab.Items(4).Enabled = False
            MenuTab.Items(5).Enabled = False
            Label3.Text = "Nº de Comprobantes : 0"
            ' Recuperar listado 
            If ObjDctogratuitos.fnLISTA_INICIAL_COMPROBANTE_GRATUITO = True Then
                'datahelper
                'odba.Fill(dtagencias, ObjDctogratuitos.rst_agencias_10)
                'odba.Fill(dtcondicion, ObjDctogratuitos.rst_condicion)
                'dvagencias = dtagencias.DefaultView
                'dvcondicion = dtcondicion.DefaultView
                'dvagencias = CargarCombo(Me.cmbAgencia, dtagencias, "nombre_agencia", "idagencias", -666)
                'dvcondicion = CargarCombo(Me.cmbcondicion, dtcondicion, "condicion", "idcondicion_boleto", -666)
                dvagencias = CargarCombo(Me.cmbAgencia, ObjDctogratuitos.rst_agencias_10, "nombre_agencia", "idagencias", -666)
                dvcondicion = CargarCombo(Me.cmbcondicion, ObjDctogratuitos.rst_condicion, "condicion", "idcondicion_boleto", -666)
                ' Activa pasajes 
                Me.Rb_pasajes.Checked = True
                ' Formateando la grilla 
                format_grilla()
            End If
            Me.DTPFECHAINICIOFACTURA.Value = dtoUSUARIOS.m_sFecha
            Me.DTPFECHAFINALFACTURA.Value = dtoUSUARIOS.m_sFecha

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub RB_Carga_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Carga.CheckedChanged
        Me.cmbAgencia.SelectedValue = -666
        Me.cmbcondicion.SelectedValue = -666
        '--
        Me.cmbAgencia.Enabled = False
        Me.cmbcondicion.Enabled = False
        Me.txtmemo.Enabled = False
        Me.DGV_comprobante.DataSource = Nothing
        '--
    End Sub
    Private Sub Rb_pasajes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rb_pasajes.CheckedChanged
        Me.cmbAgencia.Enabled = True
        Me.cmbcondicion.Enabled = True
        Me.txtmemo.Enabled = True
        Me.DGV_comprobante.DataSource = Nothing
    End Sub
    Private Sub listar_comprobantes_gratuitos()
        Try
            '
            ObjDctogratuitos.iidagencias = CType(Me.cmbAgencia.SelectedValue, Long)
            ObjDctogratuitos.iidcondicion = CType(Me.cmbcondicion.SelectedValue, Long)
            ObjDctogratuitos.sfecha_inicio = CType(Me.DTPFECHAINICIOFACTURA.Value, String)
            ObjDctogratuitos.sfecha_final = CType(Me.DTPFECHAFINALFACTURA.Value, String)
            '
            If Me.Rb_pasajes.Checked = True Then
                If Me.txtmemo.Text = "" Then
                    ObjDctogratuitos.smemo = "%"
                Else
                    ObjDctogratuitos.smemo = Me.txtmemo.Text
                End If
            Else
                Me.txtmemo.Text = ""
                ObjDctogratuitos.smemo = "null"
            End If            
            '
            If Me.Rb_pasajes.Checked = True Then
                ObjDctogratuitos.fn_pasajes_asumidos_xempresa()
            Else
                ObjDctogratuitos.fn_carga_asumidos_xempresa()
            End If
            'datahelper
            'dtcomprobante.Clear()
            'DGV_comprobante.Columns.Clear()

            DGV_comprobante.Refresh()
            'odba.Fill(dtcomprobante, ObjDctogratuitos.rst_comprobante)
            'dvcomprobante = dtcomprobante.DefaultView

            dvcomprobante = ObjDctogratuitos.rst_comprobante.DefaultView
            DGV_comprobante.DataSource = dvcomprobante
            DGV_comprobante.Refresh()
            Label3.Text = "Nº de Comprobantes : " + CType(dvcomprobante.Count, String)
            '
            If dvcomprobante.Count = 0 Then
                MsgBox("No se ha encontrado ningún resultado para esta busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            format_grilla()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    'Formateando la grilla
    Sub format_grilla()
        ' DGV_comprobante.Columns.Clear()
        With DGV_comprobante
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvcomprobante
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        Dim snombre_agencia As New DataGridViewTextBoxColumn
        With snombre_agencia  '0 
            .HeaderText = "Agencia"
            .Name = "nombre_agencia"
            .DataPropertyName = "nombre_agencia"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim sFecha_Emision As New DataGridViewTextBoxColumn
        With sFecha_Emision
            .HeaderText = "Fecha Emisión"
            .Name = "Fecha_Emision"
            .DataPropertyName = "Fecha_Emision"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim sboleto As New DataGridViewTextBoxColumn
        With sboleto
            .HeaderText = "Comprobante"
            .Name = "boleto"
            .DataPropertyName = "boleto"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim sdatos_personales As New DataGridViewTextBoxColumn
        With sdatos_personales
            .HeaderText = "Persona"
            .Name = "datos_personales"
            .DataPropertyName = "datos_personales"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        '
        Dim scondicion As New DataGridViewTextBoxColumn
        With scondicion
            .HeaderText = "Condición"
            .Name = "condicion"
            .DataPropertyName = "condicion"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim sMemo As New DataGridViewTextBoxColumn
        With sMemo
            .HeaderText = "Observaciones"
            .Name = "Memo"
            .DataPropertyName = "Memo"
            .ReadOnly = True
        End With
        '
        Dim nmonto_total As New DataGridViewTextBoxColumn
        With nmonto_total
            .HeaderText = "Total"
            .Name = "monto_total"
            .DataPropertyName = "monto_total"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        With DGV_comprobante
            .Columns.AddRange(snombre_agencia, sFecha_Emision, sboleto, sdatos_personales, scondicion, sMemo, nmonto_total)
        End With
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'If Me.Rb_pasajes.Checked = True Then
        listar_comprobantes_gratuitos()
        'Else
        ''fnBuscar_recibo_caja()
        'End If
    End Sub
    Private Sub frmcomprobantesgratuitos_MenuImprimir() Handles Me.MenuImprimir
        ObjDctogratuitos.iidagencias = CType(Me.cmbAgencia.SelectedValue, Long)
        ObjDctogratuitos.iidcondicion = CType(Me.cmbcondicion.SelectedValue, Long)
        ObjDctogratuitos.sfecha_inicio = CType(Me.DTPFECHAINICIOFACTURA.Value, String)
        ObjDctogratuitos.sfecha_final = CType(Me.DTPFECHAFINALFACTURA.Value, String)
        '
        If Me.Rb_pasajes.Checked = True Then
            If Me.txtmemo.Text = "" Then
                ObjDctogratuitos.smemo = "%"
            Else
                ObjDctogratuitos.smemo = Me.txtmemo.Text
            End If
        Else
            Me.txtmemo.Text = ""
            ObjDctogratuitos.smemo = "null"
        End If
        Try
            ObjReport.dispose()
        Catch

        End Try
        ObjReport.rutaRpt = PathFrmReport
        ObjReport.conectar(rptservice, rptuser, rptpass)
        '
        If Me.Rb_pasajes.Checked = True Then
            ObjReport.printrpt(False, "", "PAS004.RPT", _
            "P_SUBTITULO;" & "Del " + ObjDctogratuitos.sfecha_inicio + " hasta " + ObjDctogratuitos.sfecha_final, _
            "NIDAGENCIA;" & ObjDctogratuitos.iidagencias, _
            "VFEC_INICIO;" & ObjDctogratuitos.sfecha_inicio, _
            "VFEC_FINAL;" & ObjDctogratuitos.sfecha_final, _
            "NCONDICION;" & ObjDctogratuitos.iidcondicion, _
            "VMEMO;" & ObjDctogratuitos.smemo)
        Else
            ObjReport.printrpt(False, "", "FAC101.RPT", _
            "P_SUBTITULO;" & "Del " + ObjDctogratuitos.sfecha_inicio + " hasta " + ObjDctogratuitos.sfecha_final, _
            "NIDAGENCIA;" & ObjDctogratuitos.iidagencias, _
            "VFEC_INICIO;" & ObjDctogratuitos.sfecha_inicio, _
            "VFEC_FINAL;" & ObjDctogratuitos.sfecha_final)
            '
        End If
    End Sub
    Private Sub txtmemo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmemo.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            If Not IsNumeric(e.KeyChar) And Char.IsLetter(e.KeyChar) Then
                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
            ElseIf e.KeyChar = " " Then
                If tb.Text.Substring(tb.Text.Length() - 1) = " " Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "." Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "." Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "," Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "," Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "@" Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "@" Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "&" Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "&" Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "-" Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "-" Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "%" Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "%" Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "'" Then
                e.Handled = True
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
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

    Private Sub DGV_comprobante_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_comprobante.CellContentClick

    End Sub

    Private Sub DGV_comprobante_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV_comprobante.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV_comprobante), 0)
    End Sub

    Private Sub DGV_comprobante_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGV_comprobante.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV_comprobante), 0)
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.DGV_comprobante.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.DGV_comprobante.DataSource = Nothing
    End Sub

    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Me.DGV_comprobante.DataSource = Nothing
    End Sub

    Private Sub cmbcondicion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcondicion.SelectedIndexChanged
        Me.DGV_comprobante.DataSource = Nothing
    End Sub

    Private Sub txtmemo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmemo.TextChanged
        Me.DGV_comprobante.DataSource = Nothing
    End Sub
End Class
