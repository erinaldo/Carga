Public Class frmClientesTarifasMasivas
#Region "Variables Publicas"
    Public pl_tipo_tarifa As Long ' 1 Tarifa Generica 2 Tarifa por Subcuenta
    Public ps_idpersona As String
    Public ps_razon_social As String
    Public ps_sub_cuenta As String
    Public ps_idsub_cuenta As String
    Public pb_cancelar As Boolean
    Public hnd As Long
#End Region
#Region "Variables"
    ' Dim odba_cliente_tarifa As New OleDb.OleDbDataAdapter
    ' Dim rst_rutas, rst_agencias, rst_centro_costo As New ADODB.Recordset
    Dim dt_rutas, dt_agencias, dt_agencias_destino, dt_centro_costo As New DataTable
    Dim dv_rutas, dv_agencias, dv_agencias_destino, dv_centro_costo As New DataView
    Dim obj_tarifamasiva_xcliente As New dtotarifamasiva_xcliente
    Dim lb_lee As Boolean = False
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

    Private Sub frmClientesTarifasMasivas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmClientesTarifasMasivas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmClientesTarifasMasivas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '
            lb_lee = False
            obj_tarifamasiva_xcliente.control = pl_tipo_tarifa
            obj_tarifamasiva_xcliente.idpersona = ps_idpersona
            Me.txtidpersona.Text = ps_idpersona
            Me.txt_razonsocial.Text = ps_razon_social
            'Me.txtidsubcuenta.Text = ps_idsub_cuenta
            'Me.txtsubcuenta.Text = ps_sub_cuenta
            'Mod. 10/09/2009 - por datahelper  
            Dim lds_tmp As New DataSet
            If pl_tipo_tarifa = 1 Then  ' Tarifa generica 
                ' obj_tarifamasiva_xcliente.idcuenta_subcliente = "null"
                obj_tarifamasiva_xcliente.idcuenta_subcliente = ""
                'rst_centro_costo = obj_tarifamasiva_xcliente.lista_masiva_tarifa()
                lds_tmp = obj_tarifamasiva_xcliente.lista_masiva_tarifa()

            Else ' Tarifa generica Subcuenta 
                Me.cmb_centro_costo.Enabled = True
                obj_tarifamasiva_xcliente.idcuenta_subcliente = ps_idsub_cuenta
                lds_tmp = obj_tarifamasiva_xcliente.lista_masiva_tarifa()
            End If
            'rst_agencias = rst_centro_costo.NextRecordset()
            'rst_rutas = rst_centro_costo.NextRecordset
            dt_centro_costo = lds_tmp.Tables(0)
            dt_agencias = lds_tmp.Tables(1)
            dt_rutas = lds_tmp.Tables(2)
            '
            'odba_cliente_tarifa.Fill(dt_centro_costo, rst_centro_costo)
            dv_centro_costo = CargarCombo(Me.cmb_centro_costo, dt_centro_costo, "CENTRO_COSTO", "IDCENTRO_COSTO", -666)
            '
            'odba_cliente_tarifa.Fill(dt_agencias, rst_agencias)
            dv_agencias = CargarCombo(Me.CbOriMas, dt_agencias, "Nombre_Unidad", "Idunidad_Agencia", 9999) ' todos
            dt_agencias_destino = dt_agencias.Copy
            dv_agencias_destino = CargarCombo(Me.CbDesMas, dt_agencias_destino, "Nombre_Unidad", "Idunidad_Agencia", 9999) ' todos
            '
            'odba_cliente_tarifa.Fill(dt_rutas, rst_rutas)
            dv_rutas = dt_rutas.DefaultView
            '
            If pl_tipo_tarifa = 1 Then  ' Tarifa generica 
                Me.cmb_centro_costo.SelectedValue = 999 ' Se visualizara solo generico 
                Me.cmb_centro_costo.Enabled = False
            Else
                Me.cmb_centro_costo.Enabled = True
            End If
            formato_grilla()
            DataGridRutas.DataSource = dv_rutas
            '
            lb_lee = True
            '
            Me.Label34.Text = "    Monto   "
            Me.rgt_descuento.Checked = False
            Me.Rgt_monto.Checked = True
            '
            If pl_tipo_tarifa <> 1 Then  ' Tarifa generica 
                Me.cmb_centro_costo.SelectedValue = ps_idsub_cuenta
            End If
            '

            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        pb_cancelar = True
        Me.Close()
    End Sub
#End Region
#Region "Procedimientos y funciones"
    Sub formato_grilla()
        Try
            DataGridRutas.Columns.Clear()
            With DataGridRutas
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
                .ReadOnly = False
                .AutoGenerateColumns = False
                .VirtualMode = True
                '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            '
            Dim ls_flag As New DataGridViewCheckBoxColumn
            With ls_flag '0
                .DataPropertyName = "flag"
                .Name = "flag"
                .HeaderText = "Selec."
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Width = 20
                .ReadOnly = False
            End With
            DataGridRutas.Columns.Add(ls_flag)
            '
            Dim ls_origen As New DataGridViewTextBoxColumn
            With ls_origen '1
                .DataPropertyName = "origen"
                .Name = "origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = True
            End With
            DataGridRutas.Columns.Add(ls_origen)
            '
            Dim ls_destino As New DataGridViewTextBoxColumn
            With ls_destino
                .DataPropertyName = "destino"
                .Name = "destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = False
            End With
            DataGridRutas.Columns.Add(ls_destino)
            '
            Dim ls_monto_base As New DataGridViewTextBoxColumn
            With ls_monto_base
                .DataPropertyName = "monto_base"
                .Name = "monto_base"
                .HeaderText = "Monto Base"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = False
            End With
            '
            DataGridRutas.Columns.Add(ls_monto_base)
            Dim ls_precio_x_peso As New DataGridViewTextBoxColumn
            With ls_precio_x_peso
                .DataPropertyName = "precio_x_peso"
                .Name = "precio_x_peso"
                .HeaderText = "Precio x peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = False
            End With
            DataGridRutas.Columns.Add(ls_precio_x_peso)
            '
            Dim ls_precio_x_volumen As New DataGridViewTextBoxColumn
            With ls_precio_x_volumen
                .DataPropertyName = "precio_x_volumen"
                .Name = "precio_x_volumen"
                .HeaderText = "Precio x volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = False
            End With
            DataGridRutas.Columns.Add(ls_precio_x_volumen)
            '
            Dim ls_fecha_activacion As New DataGridViewTextBoxColumn
            With ls_fecha_activacion
                .DataPropertyName = "FECHA_ACTIVACION"
                .Name = "FECHA_ACTIVACION"
                .HeaderText = "Fecha activación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = False
            End With
            DataGridRutas.Columns.Add(ls_fecha_activacion)
            '
            Dim ls_idcliente_subcuenta As New DataGridViewTextBoxColumn
            With ls_idcliente_subcuenta
                .DataPropertyName = "idtarifa_sub_cuenta"
                .Name = "idtarifa_sub_cuenta"
                .HeaderText = "Id cliente subcuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = False
                .Visible = False
            End With
            DataGridRutas.Columns.Add(ls_idcliente_subcuenta)
            '
            Dim ls_idcentro_costo As New DataGridViewTextBoxColumn
            With ls_idcentro_costo
                .DataPropertyName = "idcentro_costo"
                .Name = "idcentro_costo"
                .HeaderText = "Id centro costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = False
                .Visible = False
            End With
            DataGridRutas.Columns.Add(ls_idcentro_costo)
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
#Region "Validación de las rutas grabar"
    Private Sub CbOriMas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbOriMas.SelectedIndexChanged
        Dim filcb As Long
        Dim dr As DataRowView
        Dim valor As Long
        Dim ls_filtro As String
        Try            
            If lb_lee Then
                If Me.cmb_centro_costo.SelectedValue < 0 Then
                    'If Me.cmb_centro_costo.SelectedValue < 1 Then
                    MsgBox("No a seleccionado la Sub-Cuenta", MsgBoxStyle.Information, "Tarifa Masiva")
                    Me.cmb_centro_costo.Focus()
                    Exit Sub
                End If
                filcb = CbOriMas.SelectedIndex
                If filcb >= 0 Then
                    dr = dv_agencias.Item(filcb)
                    valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
                    If valor = "9999" Then
                        ls_filtro = "1=1"
                    Else
                        ls_filtro = "idunidad_agencia = " & valor
                    End If
                    filcb = CbDesMas.SelectedIndex
                    If filcb >= 0 Then
                        dr = dv_agencias_destino.Item(filcb)
                        valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
                        If valor <> "9999" Then
                            ls_filtro = ls_filtro & " and idunidad_agencia_destino = " & valor
                        End If
                    End If
                    dv_rutas.RowFilter = ls_filtro
                Else
                    dv_rutas.RowFilter = "idunidad_agencia = 0"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub CbDesMas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbDesMas.SelectedIndexChanged
        Dim filcb As Long
        Dim dr As DataRowView
        Dim valor As Long
        Dim ls_filtro As String
        Try
            If lb_lee Then
                '
                If Me.cmb_centro_costo.SelectedValue < 1 Then
                    MsgBox("No a seleccionado la Sub-Cuenta", MsgBoxStyle.Information, "Tarifa Masiva")
                    Me.cmb_centro_costo.Focus()
                    Exit Sub
                End If
                '
                filcb = CbOriMas.SelectedIndex
                If filcb >= 0 Then
                    dr = dv_agencias.Item(filcb)
                    valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
                    If valor = "9999" Then
                        ls_filtro = "1=1"
                    Else
                        ls_filtro = "idunidad_agencia = " & valor
                    End If
                    filcb = CbDesMas.SelectedIndex
                    If filcb >= 0 Then
                        dr = dv_agencias_destino.Item(filcb)
                        valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
                        If valor <> "9999" Then
                            ls_filtro = ls_filtro & " and idunidad_agencia_destino = " & valor
                        End If
                    End If
                    dv_rutas.RowFilter = ls_filtro
                Else
                    dv_rutas.RowFilter = "idunidad_agencia = 0"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cmb_centro_costo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_centro_costo.SelectedIndexChanged
        Dim ls_idpersona, ls_idcentro_costo As String
        'Dim lrst_tarifa_subcta As New ADODB.Recordset
        Dim ldt_tarifa_subcta As New DataTable
        '
        Try
            If lb_lee Then
                ls_idpersona = Me.txtidpersona.Text
                ls_idcentro_costo = CType(cmb_centro_costo.SelectedValue, String)
                'Recupera datos del Centro de costo seleccionado 
                dt_rutas = Nothing
                dv_rutas = Nothing
                '
                dt_rutas = New DataTable
                dv_rutas = New DataView
                '
                obj_tarifamasiva_xcliente.idpersona = ls_idpersona
                obj_tarifamasiva_xcliente.idcuenta_subcliente = ls_idcentro_costo
                '
                'lrst_tarifa_subcta = obj_tarifamasiva_xcliente.lista_masiva_subcta_tarifa()
                ldt_tarifa_subcta = obj_tarifamasiva_xcliente.lista_masiva_subcta_tarifa()
                '
                ' odba_cliente_tarifa.Fill(dt_rutas, lrst_tarifa_subcta)
                'dv_rutas = dt_rutas.DefaultView
                dv_rutas = ldt_tarifa_subcta.DefaultView
                '
                formato_grilla()
                DataGridRutas.DataSource = dv_rutas
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btn_marcar_rutas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_marcar_rutas.Click
        Dim ll_nro_registro, ll_fila As Long        
        Try
            ll_nro_registro = Me.DataGridRutas.Rows.Count
            For ll_fila = 0 To ll_nro_registro - 1
                DataGridRutas.Rows(ll_fila).Cells("flag").Value = 1
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btn_desmarcar_rutas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_desmarcar_rutas.Click
        Dim ll_nro_registro, ll_fila As Long
        Try
            ll_nro_registro = Me.DataGridRutas.Rows.Count
            For ll_fila = 0 To ll_nro_registro - 1
                DataGridRutas.Rows(ll_fila).Cells("flag").Value = 0
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
#End Region

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim lb_valida As Boolean
        Try
            lb_valida = valida_datos()
            If lb_valida = True Then
                If Me.rgt_descuento.Checked = True Then
                    obj_tarifamasiva_xcliente.tipo_calculo = "D"
                Else
                    obj_tarifamasiva_xcliente.tipo_calculo = "M"
                End If
                If pl_tipo_tarifa = 1 Then  'Graba tarifa a nivel general por cliente 
                    lb_valida = grabar_tarifa()
                Else   'Graba tarifa x sub cuenta de acuerdo al cliente 
                    lb_valida = grabar_tarifa_sub_cuenta()
                End If
            End If
            If lb_valida = True Then
                pb_cancelar = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
    Function valida_datos() As Boolean
        Dim lb_valida As Boolean
        Dim resp As DialogResult        
        Try
            'valida que seleccione datos 
            lb_valida = verifica_seleccion()
            If lb_valida = False Then
                MsgBox("No ha seleccionado ninguna ruta para actualizar la tarifa", MsgBoxStyle.Information, "Tarifa Masiva")
                Return False
            End If
            'Valida Monto base
            If Val(Me.TxtMMbC.Text) = 0 Then 'Or Me.TxtMMbC.Text = "0" Then
                resp = MessageBox.Show("No ha ingresado el monto base. ¿Desea continuar? ", "Tarifa Masiva", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If resp = Windows.Forms.DialogResult.No Then
                    Me.TxtMMbC.Focus()
                    Return False
                    Exit Function
                Else
                    Me.TxtMMbC.Text = 0
                End If
            End If
            'valida monto precio x peso 
            If Val(Me.TxtMppC.Text) = 0 Then 'Or Me.TxtMppC.Text = 0 Then
                resp = MessageBox.Show("No ha ingresado precio por peso. ¿Desea continuar? ", "Tarifa Masiva", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If resp = Windows.Forms.DialogResult.No Then
                    Me.TxtMppC.Focus()
                    Return False
                    Exit Function
                Else
                    Me.TxtMppC.Text = 0
                End If
            End If
            'valida monto precio x volumen 
            If Val(Me.TxtMpvC.Text) = 0 Then 'Or Me.TxtMpvC.Text = 0 Then
                resp = MessageBox.Show("No ha ingresado precio por volumen. ¿Desea continuar? ", "Tarifa Masiva", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If resp = Windows.Forms.DialogResult.No Then
                    Me.TxtMpvC.Focus()
                    Return False
                    Exit Function
                Else
                    Me.TxtMpvC.Text = 0
                End If
            End If
            'valida monto precio x sobre 
            If Val(Me.txt_precio_sobre.Text) = 0 Then 'Or Me.txt_precio_sobre.Text = 0 Then
                resp = MessageBox.Show("No ha ingresado precio por sobre. ¿Desea continuar? ", "Tarifa Masiva", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If resp = Windows.Forms.DialogResult.No Then
                    Me.txt_precio_sobre.Focus()
                    Return False
                    Exit Function
                Else
                    Me.txt_precio_sobre.Text = 0
                End If
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Function
    Function valida_numero(ByVal smonto As String) As Boolean
        Dim dmonto As Double
        Try
            dmonto = CType(smonto, Double)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function verifica_seleccion() As Boolean
        Dim ll_fila, ll_nro_tot_fila, ll_verifica As Long
        Dim lb_retorno As Boolean
        Dim ls_filtro As String
        Dim dr As DataRowView
        Try
            '
            DataGridRutas.CurrentCell = DataGridRutas.Rows(0).Cells(0)
            '
            ls_filtro = CType(dv_rutas.RowFilter, String)
            dv_rutas.RowFilter = "1=1"
            '
            For ll_fila = 0 To dv_rutas.Count - 1
                dr = dv_rutas.Item(ll_fila)
                If IsDBNull(dr("flag")) = True Then
                    dr("flag") = 0
                End If
                If dr("flag") = 1 Then
                    Return True
                    Exit Function
                End If
            Next
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Function
    Function grabar_tarifa_sub_cuenta() As Boolean
        ' Grabar los datos en la tarifa masiva 
        Dim dr As DataRowView
        Dim ll_fila As Long
        Dim valor As Long = 1
        Dim FlgUpd As Long
        Dim ll_registros_grabados As Long
        'Dim rst_grabar As New ADODB.Recordset
        Dim ldt_grabar As New DataTable
        Try
            If Me.cmb_centro_costo.SelectedValue < 1 Then
                MsgBox("Falta seleccionar el centro de costo.", MsgBoxStyle.Information, "Tarifa Masiva")
                Me.cmb_centro_costo.Focus()
                Return False
                Exit Function
            End If
            DataGridRutas.CurrentCell = DataGridRutas.Rows(0).Cells(0)
            FlgUpd = 0
            dv_rutas.RowFilter = "1=1"
            For ll_fila = 0 To dv_rutas.Count - 1
                dr = dv_rutas.Item(ll_fila)
                If IsDBNull(dr("flag")) = True Then
                    dr("flag") = 0
                End If
                If dr("flag") = 1 Then                    
                    If IsDBNull(dr("idtarifa_sub_cuenta")) = True Then
                        obj_tarifamasiva_xcliente.control = 1
                    Else
                        obj_tarifamasiva_xcliente.control = 2
                        obj_tarifamasiva_xcliente.idcuenta_subcliente = CType(dr("idtarifa_sub_cuenta"), String)
                    End If
                    obj_tarifamasiva_xcliente.idpersona = Me.txtidpersona.Text
                    obj_tarifamasiva_xcliente.idcentro_costo = Me.cmb_centro_costo.SelectedValue
                    obj_tarifamasiva_xcliente.idunidad_agencia = dr("idunidad_agencia")
                    obj_tarifamasiva_xcliente.idunidad_agencia_destino = dr("idunidad_agencia_destino")
                    obj_tarifamasiva_xcliente.precio_x_peso = CType(Me.TxtMppC.Text, Double)
                    obj_tarifamasiva_xcliente.precio_x_volumen = CType(Me.TxtMpvC.Text, Double)
                    obj_tarifamasiva_xcliente.precio_x_sobre = CType(Me.txt_precio_sobre.Text, Double)
                    obj_tarifamasiva_xcliente.monto_base = CType(Me.TxtMMbC.Text, Double)
                    obj_tarifamasiva_xcliente.es_vigente = 1 'Siempre va hacer vigente
                    obj_tarifamasiva_xcliente.tipo_moneda = 1 ' Moneda 1 Nuevos soles 
                    obj_tarifamasiva_xcliente.ip = dtoUSUARIOS.IP
                    obj_tarifamasiva_xcliente.idusuario_personal = dtoUSUARIOS.IdLogin
                    obj_tarifamasiva_xcliente.idestado_registro = 1 ' Siempre va hacer activo
                    obj_tarifamasiva_xcliente.fecha_activacion = dtoUSUARIOS.dfecha_sistema
                    obj_tarifamasiva_xcliente.fecha_desactivacion = dtoUSUARIOS.dfecha_sistema
                    obj_tarifamasiva_xcliente.rol_usuario = dtoUSUARIOS.IdRol
                    '
                    ldt_grabar = obj_tarifamasiva_xcliente.graba_tarifa_masiva_sub_cta
                    '
                    If Convert.ToInt16(ldt_grabar.Rows(0).Item(0)) <> 0 Then
                        Dim ls_mensaje As String = CType(ldt_grabar.Rows(0).Item(1), String)
                        MsgBox(ls_mensaje, MsgBoxStyle.Information, "Seguridad del Sistema")
                    Else
                        ll_registros_grabados = ll_registros_grabados + 1
                    End If
                    'Else
                    '    MsgBox("No se Registraron Valores para actualizar", MsgBoxStyle.Information, "Seguridad del Sistema")
                End If
            Next
            MsgBox("Se actualizaron " + CType(ll_registros_grabados, String) + " registro(s) ", MsgBoxStyle.Information, "Tarifa Masiva")
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
            Return False
        End Try
    End Function
    Function grabar_tarifa() As Boolean ' Graba la tarifa generica 
        ' Grabar los datos en la tarifa masiva 
        Dim dr As DataRowView        
        Dim ll_fila As Long
        Dim valor As Long = 1
        Dim FlgUpd As Long
        'Dim rst_grabar As New ADODB.Recordset
        Dim dt_grabar As New DataTable
        '
        Dim ll_registros_grabados As Long = 0
        Try
            DataGridRutas.CurrentCell = DataGridRutas.Rows(0).Cells(0)
            FlgUpd = 0
            dv_rutas.RowFilter = "1=1"
            For ll_fila = 0 To dv_rutas.Count - 1
                dr = dv_rutas.Item(ll_fila)
                If IsDBNull(dr("flag")) = True Then
                    dr("flag") = 0
                End If
                If dr("flag") = 1 Then
                    If IsDBNull(dr("idtarifa_sub_cuenta")) = True Then
                        obj_tarifamasiva_xcliente.control = 1
                        'obj_tarifamasiva_xcliente.idtarifa_cliente = "null"
                        obj_tarifamasiva_xcliente.idtarifa_cliente = ""
                    Else
                        obj_tarifamasiva_xcliente.control = 2
                        obj_tarifamasiva_xcliente.idtarifa_cliente = CType(dr("idtarifa_sub_cuenta"), String)
                    End If
                    obj_tarifamasiva_xcliente.idpersona = Me.txtidpersona.Text
                    obj_tarifamasiva_xcliente.idcentro_costo = Me.cmb_centro_costo.SelectedValue
                    obj_tarifamasiva_xcliente.idunidad_agencia = dr("idunidad_agencia")
                    obj_tarifamasiva_xcliente.idunidad_agencia_destino = dr("idunidad_agencia_destino")
                    obj_tarifamasiva_xcliente.precio_x_peso = CType(Me.TxtMppC.Text, Double)
                    obj_tarifamasiva_xcliente.precio_x_volumen = CType(Me.TxtMpvC.Text, Double)
                    obj_tarifamasiva_xcliente.precio_x_sobre = CType(Me.txt_precio_sobre.Text, Double)
                    obj_tarifamasiva_xcliente.monto_base = CType(Me.TxtMMbC.Text, Double)
                    obj_tarifamasiva_xcliente.es_vigente = 1 'Siempre va hacer vigente
                    obj_tarifamasiva_xcliente.tipo_moneda = 1 ' Moneda 1 Nuevos soles 
                    obj_tarifamasiva_xcliente.ip = dtoUSUARIOS.IP
                    obj_tarifamasiva_xcliente.idusuario_personal = dtoUSUARIOS.IdLogin
                    obj_tarifamasiva_xcliente.idestado_registro = 1 ' Siempre va hacer activo
                    obj_tarifamasiva_xcliente.fecha_activacion = dtoUSUARIOS.dfecha_sistema
                    obj_tarifamasiva_xcliente.fecha_desactivacion = dtoUSUARIOS.dfecha_sistema
                    obj_tarifamasiva_xcliente.rol_usuario = dtoUSUARIOS.IdRol
                    '
                    'rst_grabar = obj_tarifamasiva_xcliente.graba_tarifa_masiva_cliente
                    'Mod.10/09/2009 -->Omendoza - Pasando al datahelper   
                    dt_grabar = obj_tarifamasiva_xcliente.graba_tarifa_masiva_cliente
                    '
                    If Convert.ToInt16(dt_grabar.Rows(0).Item(0)) <> 0 Then
                        Dim ls_mensaje As String = CType(dt_grabar.Rows(0).Item(1), String)
                        MsgBox(ls_mensaje, MsgBoxStyle.Information, "Seguridad del Sistema")
                    Else
                        ll_registros_grabados = ll_registros_grabados + 1
                    End If
                    'Else
                    '    MsgBox("No se Registraron Valores para actualizar", MsgBoxStyle.Information, "Seguridad del Sistema")
                End If
            Next
            MsgBox("Se actualizaron " + CType(ll_registros_grabados, String) + " registro(s) ", MsgBoxStyle.Information, "Tarifa Masiva")
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
            Return False
        End Try
    End Function
    Private Sub rgt_descuento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rgt_descuento.CheckedChanged
        Me.Label34.Text = "% Descuento"
        'Me.rgt_descuento.Checked = True
        'Me.Rgt_monto.Checked = False
    End Sub

    Private Sub Rgt_monto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rgt_monto.CheckedChanged
        Me.Label34.Text = "    Monto   "
        'Me.rgt_descuento.Checked = False
        'Me.Rgt_monto.Checked = True
    End Sub
    Private Sub TxtMMbC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMMbC.KeyPress, TxtMppC.KeyPress, TxtMpvC.KeyPress, txt_precio_sobre.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            '
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
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Private Sub TxtMMbC_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMMbC.Validated
        'rgt_descuento
        If valida_numero(Me.TxtMMbC.Text) = False Then
            MsgBox("El monto del flete no es válido", MsgBoxStyle.Exclamation, "Sistema de Tarifarios Giros")
            TxtMMbC.Text = "0.0"
            TxtMMbC.Focus()
        End If
        '---
        If Me.btn_cancelar.Focused = False Then
            'Validando Porcentaje 
            If Me.rgt_descuento.Checked = True Then
                If CType(Me.TxtMMbC.Text, Double) <= 0 Or _
                    CType(Me.TxtMMbC.Text, Double) >= 100.01 Then
                    MsgBox("Porcentaje no válido", MsgBoxStyle.Exclamation, "Sistema de Tarifarios Giros")
                    TxtMMbC.Text = "0.0"
                    TxtMMbC.Focus()
                End If
            End If
        End If        
    End Sub
    Private Sub TxtMppC_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMppC.Validated
        If valida_numero(Me.TxtMppC.Text) = False Then
            MsgBox("El monto del flete no es válido", MsgBoxStyle.Exclamation, "Sistema de Tarifarios Giros")
            TxtMppC.Text = "0.0"
            TxtMppC.Focus()
        End If
        '---
        If Me.btn_cancelar.Focused = False Then
            'Validando Porcentaje 
            If Me.rgt_descuento.Checked = True Then
                If CType(Me.TxtMppC.Text, Double) <= 0 Or _
                    CType(Me.TxtMppC.Text, Double) >= 100.01 Then
                    MsgBox("Porcentaje no válido", MsgBoxStyle.Exclamation, "Sistema de Tarifarios Giros")
                    TxtMppC.Text = "0.0"
                    TxtMppC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub TxtMpvC_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMpvC.Validated
        '
        If valida_numero(Me.TxtMpvC.Text) = False Then
            MsgBox("El monto del flete no es válido", MsgBoxStyle.Exclamation, "Sistema de Tarifarios Giros")
            TxtMpvC.Text = "0.0"
            TxtMpvC.Focus()
        End If
        '---
        If Me.btn_cancelar.Focused = False Then
            'Validando Porcentaje 
            If Me.rgt_descuento.Checked = True Then
                If CType(Me.TxtMpvC.Text, Double) <= 0 Or _
                    CType(Me.TxtMpvC.Text, Double) >= 100.01 Then
                    MsgBox("Porcentaje no válido", MsgBoxStyle.Exclamation, "Sistema de Tarifarios Giros")
                    TxtMpvC.Text = "0.0"
                    TxtMpvC.Focus()
                End If
            End If
        End If
    End Sub


End Class