Public Class frm_actualiza_venta_contado
#Region "Variables Publicas"
    Public ps_tipo_venta As String ' "C"ontado y c"R"édito 
    Public pl_idtipo_comprobante As Long
    Public ps_tipo_comprobante As String
    Public ps_idcomprobante As String
    Public pl_idagencia_destino As Long
    Public pl_idunidad_agencia As Long
    Public pd_tot_costo As Double
    Public pd_monto_sub_total As Double
    Public pd_monto_impuesto As Double
    Public ps_idpersona As String
    Public ps_razon_social As String
    Public pl_idforma_pago As Long
    Public ps_documento As String
    Public pb_cancela As Boolean = True
    Public ps_agencia_origen As String
    Public ps_fecha_documento As String
    Public pl_idunidad_agencia_origen As Long
    Public pl_idagencia_origen As Long
    Public pl_proceso As Long
    Public pl_envio As Long
    Public pl_doc As Long
    Public ps_boleto As String
    '
    Public ps_documento_identidad As String
    Public pl_idtipo_dcto_identidad As Long  ' todavia no se usa
    '
    Dim intAgenciaDestino As Integer 'agencia destino original
    Dim intConsignados As Integer 'numero consignados original

#End Region
    Dim pl_idunidad_origen As Long
    Dim pl_idunidad_destino As Long
    Dim pl_idnro_salida_vehiculo As Long
    Dim bIngreso As Boolean = False
#Region "Variables"
    Dim obj_actualiza_contado As New dto_actualiza_contado
    'Dim odba_actualiza_contado As New OleDb.OleDbDataAdapter
    'Dim rst_agencias, rst_forma_pago As New ADODB.Recordset
    Dim dt_agencias, dt_agencias_origen, dt_forma_pago As New DataTable
    Dim dv_agencias, dv_agencias_origen, dv_forma_pago As New DataView
    Dim b_nolee As Boolean = False
    Public hnd As Long
#End Region
#Region "Eventos Adicionales"
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region
#Region "Eventos"

    Private Sub frm_actualiza_venta_contado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    'Load
    Private Sub frm_actualiza_venta_contado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            intAgenciaDestino = pl_idagencia_destino
            Dim lds_tmp As New DataSet
            b_nolee = False
            'a.ps_tipo_venta
            'Mod.10/09/2009 -->Omendoza - Pasando al datahelper   
            'rst_agencias = obj_actualiza_contado.fn_datos_cliente()
            'rst_forma_pago = rst_agencias.NextRecordset
            lds_tmp = obj_actualiza_contado.fn_datos_cliente()
            '
            dt_agencias = lds_tmp.Tables(0)
            dt_forma_pago = lds_tmp.Tables(1)
            '
            'odba_actualiza_contado.Fill(dt_agencias, rst_agencias)
            'odba_actualiza_contado.Fill(dt_forma_pago, rst_forma_pago)
            '
            dt_agencias_origen = dt_agencias.Copy
            'Llenar el datatable y el dataview 
            dv_agencias = CargarCombo(Me.cmbagencias_destinos, dt_agencias, "nombre_agencia", "idagencias", pl_idagencia_destino)  ' Agencias 
            dv_agencias_origen = CargarCombo(Me.cmb_agencia_origen, dt_agencias_origen, "nombre_agencia", "idagencias", pl_idagencia_origen)  ' Agencias Origen 
            dv_forma_pago = CargarCombo(Me.cmbforma_pago, dt_forma_pago, "forma_pago", "idforma_pago", pl_idforma_pago)  ' Forma Pago 
            ''''''''''''''
            Me.txt_idunida_agencia_origen.Text = pl_idunidad_agencia_origen
            Me.txtidunidad_agencia.Text = CType(pl_idunidad_agencia, String)
            Me.txtrazon_cliente.Text = ps_razon_social
            Me.txtidcomprobante.Text = ps_idcomprobante
            Me.lab_tipo_comprobante.Text = ps_tipo_comprobante
            Me.txtmonto_sub_total.Text = pd_monto_sub_total
            Me.txtmonto_impuesto.Text = pd_monto_impuesto
            Me.txt_total.Text = pd_tot_costo
            Me.txt_documento.Text = ps_documento
            Me.Text = Me.Text + " Origen (" + ps_agencia_origen + ")"
            Me.DTP_fecha_dcto.Text = CType(ps_fecha_documento, String)
            Me.txt_documento_identidad.Text = ps_documento_identidad

            If pl_idtipo_comprobante = 85 And pl_envio = 18 And pl_doc = 27 Then
                Me.ChkAcompaña.Checked = IIf(pl_proceso = 6, True, False)
                Me.ChkAcompaña.Visible = True
            Else
                Me.ChkAcompaña.Checked = False
                Me.ChkAcompaña.Visible = False
            End If

            ConfigurarDgvConsignado()
            ListarConsignado(pl_idtipo_comprobante, ps_idcomprobante)
            intConsignados = Me.dgvConsignado.Rows.Count

            b_nolee = True

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub

    Sub ListarConsignado(tipo As Integer, comprobante As Integer)
        Dim obj As New dtoEntregaCarga
        Me.dgvConsignado.DataSource = obj.ListarConsignado(tipo, comprobante)
    End Sub

    'aceptar
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        'validaciones
        Dim blnAgencia As Boolean = intAgenciaDestino = Me.cmbagencias_destinos.SelectedValue
        Dim blnConsignado As Boolean = intConsignados = Me.dgvConsignado.Rows.Count

        If blnAgencia And blnConsignado Then
            If intAgenciaDestino = Me.cmbagencias_destinos.SelectedValue Then
                MessageBox.Show("Seleccione una agencia diferente", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbagencias_destinos.Focus()
                Return
            End If
        End If

        'fn_actualiza_clientes
        ' Dim lrst_mensaje As New ADODB.Recordset
        Me.Cursor = Cursors.AppStarting
        Dim ldt_mensaje As New DataTable
        Dim ls_mensaje As String
        Dim ll_codigo As Long
        Try
            obj_actualiza_contado.idfactura = CType(Me.txtidcomprobante.Text, String)
            obj_actualiza_contado.idtipo_comprobante = CType(pl_idtipo_comprobante, Long)
            obj_actualiza_contado.idunidad_agencia = CType(Me.txtidunidad_agencia.Text, Long)
            obj_actualiza_contado.idagencia = CType(Me.cmbagencias_destinos.SelectedValue, Long)
            obj_actualiza_contado.fecha_documento = CType(Me.DTP_fecha_dcto.Text, String)
            obj_actualiza_contado.forma_pago = CType(Me.cmbforma_pago.SelectedValue, Long)
            obj_actualiza_contado.monto_sub_total = CType(Me.txtmonto_sub_total.Text, Double)
            obj_actualiza_contado.monto_impuesto = CType(Me.txtmonto_impuesto.Text, Double)
            obj_actualiza_contado.monto_total = CType(Me.txt_total.Text, Double)
            obj_actualiza_contado.idusuario_personal = CType(dtoUSUARIOS.IdLogin, Long)
            obj_actualiza_contado.ip = CType(dtoUSUARIOS.IP, String)
            obj_actualiza_contado.rol = CType(dtoUSUARIOS.IdRol, Long)
            obj_actualiza_contado.idunidad_agencia_origen = CType(Me.txt_idunida_agencia_origen.Text, Long)
            obj_actualiza_contado.idagencia_origen = CType(Me.cmb_agencia_origen.SelectedValue, Long)
            obj_actualiza_contado.proceso = IIf(ChkAcompaña.Checked, 6, 0)
            'Mod.10/09/2009 -->Omendoza - Pasando al datahelper   
            'lrst_mensaje = obj_actualiza_contado.fn_actualiza_clientes()
            ldt_mensaje = obj_actualiza_contado.fn_actualiza_clientes()
            ls_mensaje = CType(ldt_mensaje.Rows(0).Item(1), String)
            ll_codigo = CType(ldt_mensaje.Rows(0).Item(0), Long)
            '
            Me.Cursor = Cursors.Default
            If ll_codigo <> 0 Then
                MsgBox(ls_mensaje, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
                Exit Sub
            Else
                pb_cancela = False
                If ls_mensaje <> "." Then
                    MsgBox(ls_mensaje, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
                End If
                Me.Close()
                End If
                ' 
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        pb_cancela = True
        Me.Close()
    End Sub
    Private Sub cmbagencias_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbagencias_destinos.SelectedIndexChanged
        'Se hace el cambio
        Try
            If b_nolee = True Then
                Dim dr_agencias As DataRowView
                dr_agencias = dv_agencias.Item(Me.cmbagencias_destinos.SelectedIndex)
                Me.txtidunidad_agencia.Text = CType(dr_agencias("idunidad_agencia"), String)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cmb_agencia_origen_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_agencia_origen.Leave
        'Se hace el cambio
        Try
            If b_nolee = True Then
                Dim dr_agencias As DataRowView
                dr_agencias = dv_agencias_origen.Item(Me.cmb_agencia_origen.SelectedIndex)
                Me.txt_idunida_agencia_origen.Text = CType(dr_agencias("idunidad_agencia"), String)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
    'Txt Total
    Private Sub txt_total_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                Exit Sub
            ElseIf e.KeyChar = "." Then
                e.Handled = False
                Exit Sub
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    'txt_total
    Private Sub txt_total_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            calculo_impuesto(CType(Me.txt_total.Text, Double))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
    'Private Sub txt_documento_identidad_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_documento_identidad.Leave
    '    Try
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
    '    End Try
    'End Sub
#End Region
#Region "Procedimientos y funciones"
    Sub calculo_impuesto(ByVal dmonto_total As Double)
        Dim ld_impuesto As Double
        Try
            ld_impuesto = dtoUSUARIOS.vImpuesto ' FormatNumber(dtoUSUARIOS.vImpuesto / 100, 2)
            Me.txtmonto_sub_total.Text = FormatNumber(dmonto_total / (1 + ld_impuesto), 2)
            Me.txtmonto_impuesto.Text = dmonto_total - CType(Me.txtmonto_sub_total.Text, Double)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
    
    Private Sub ChkAcompaña_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAcompaña.CheckedChanged
        If Not ChkAcompaña.Checked Then
            If ps_boleto.Trim.Length > 0 Then
                MessageBox.Show("La Guía ya está asociado a un Boleto.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ChkAcompaña.Checked = True
            End If
        End If
    End Sub

    Sub ConfigurarDgvConsignado()
        With dgvConsignado
            .Rows.Clear()
            .Columns.Clear()
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            '.BackgroundColor = SystemColors.Window
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .ReadOnly = True
            '.AutoGenerateColumns = False
            '.VirtualMode = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersWidth = 20
            '.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        End With

        Dim col_1 As New DataGridViewTextBoxColumn
        With col_1
            .DisplayIndex = 0
            .DataPropertyName = "id_consignado"
            .Name = "id_consignado"
            .HeaderText = "id_consignado"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .Visible = False
        End With

        Dim col_2 As New DataGridViewTextBoxColumn
        With col_2
            .DisplayIndex = 1
            .DataPropertyName = "nrodocumento"
            .Name = "nrodocumento"
            .HeaderText = "Nº Documento"
            .DefaultCellStyle.ForeColor = Color.Black
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '.MaxInputLength = 13
            '.Mask = "###-########"
            .DefaultCellStyle.NullValue = ""
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Visible = True
        End With

        Dim col_3 As New DataGridViewTextBoxColumn
        With col_3
            .DisplayIndex = 2
            .DataPropertyName = "nombres"
            .Name = "nombres"
            .HeaderText = "Consignado"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.ForeColor = Color.Black
            .Visible = True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        dgvConsignado.Columns.AddRange(col_1, col_2, col_3)
    End Sub

    Private Sub btnConsignado_Click(sender As System.Object, e As System.EventArgs) Handles btnConsignado.Click
        Dim frm As New FrmConsignadoNuevo
        Dim IDConsignado As String = ""
        Dim dtConsignado As DataTable = ObjEntregaCarga.dtConsignado

        frm.IDPersona = ps_idpersona
        frm.IDUnidadDestino = pl_idagencia_destino

        frm.IDComprobante = ps_idcomprobante
        frm.IDTipoComprobante = pl_idtipo_comprobante

        frm.CboTipoDocumento.Enabled = False
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            ListarConsignado(pl_idtipo_comprobante, ps_idcomprobante)
        End If
    End Sub
End Class