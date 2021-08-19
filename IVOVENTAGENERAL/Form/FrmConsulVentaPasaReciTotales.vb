Public Class FrmConsulVentaPasaReciTotales

    Dim dvfacturas_guias As New DataView
    Dim dvListar_facturas As New DataView

    Dim Colllistar_persona_todos As New Collection
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection

    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL

    Dim dvlistar_persona_todos As New DataView
    Dim dvlistar_tipo_moneda As New DataView

    Dim dvlistar_forma_pago As New DataView

    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        listar_ventas_pasajes()
    End Sub
    Private Sub listar_ventas_pasajes()
        Try


            Dim ObjGiros As New ClsLbTepsa.dtoGiros

            'If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            'ObjFactura.IDPERSONA = 0
            'Else

            'ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            'End If
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjGiros.FECHA_INI = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjGiros.FECHA_INI = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjGiros.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjGiros.FECHA_FINAL = "NULL"
            'If Not IsNothing(Me.cbidtipo_moneda.SelectedValue) Then
            'ObjFactura.IDTIPO_MONEDA = Me.cbidtipo_moneda.SelectedValue
            'Else
            'ObjFactura.IDTIPO_MONEDA = 0
            'End If
            If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                ObjGiros.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
            Else
                ObjGiros.IDUSUARIO_PERSONAL = 0
            End If
            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                ObjGiros.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            Else
                ObjGiros.IDAGENCIAS = 0
            End If

            'If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
            ' ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            'Else
            'ObjFactura.IDFORMA_PAGO = 0
            'End If


            'datahelper
            'dvListar_facturas = ObjGiros.SP_CONSUL_CRUCE_BOLE_PASA(cnn)
            dvListar_facturas = ObjGiros.SP_CONSUL_CRUCE_BOLE_PASA()
            FORMAT_GRILLA3()
            'dgv4.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellContentClick

    End Sub


    'Sub FORMAT_GRILLA4()
    '    dgv4.Columns.Clear()

    '    With dgv4
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False
    '        .AutoGenerateColumns = False
    '        .DataSource = dvfacturas_guias
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .VirtualMode = True
    '        .RowHeadersVisible = True
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    End With
    '    Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
    '    With SIMBOLO_MONEDA
    '        .HeaderText = "SIMBOLO_MONEDA"
    '        .Name = "SIMBOLO_MONEDA"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DataPropertyName = "SIMBOLO_MONEDA"
    '        .Width = 30
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim SUB_TOTAL As New DataGridViewTextBoxColumn
    '    With SUB_TOTAL
    '        .HeaderText = "SUB_TOTAL"
    '        .Name = "SUB_TOTAL"
    '        .DataPropertyName = "SUB_TOTAL"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
    '    With NOMBRE_AGENCIA
    '        .HeaderText = "NOMBRE_AGENCIA"
    '        .Name = "NOMBRE_AGENCIA"
    '        .DataPropertyName = "NOMBRE_AGENCIA"
    '        .Width = 100
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
    '    With ESTADO_REGISTRO
    '        .HeaderText = "ESTADO_REGISTRO"
    '        .Name = "ESTADO_REGISTRO"
    '        .DataPropertyName = "ESTADO_REGISTRO"
    '        .Width = 100
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim LOGIN As New DataGridViewTextBoxColumn
    '    With LOGIN
    '        .HeaderText = "LOGIN"
    '        .Name = "LOGIN"
    '        .DataPropertyName = "LOGIN"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
    '    With RAZON_SOCIAL
    '        .HeaderText = "RAZON_SOCIAL"
    '        .Name = "RAZON_SOCIAL"
    '        .DataPropertyName = "RAZON_SOCIAL"
    '        .Width = 200
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim SERIE_GUIA_ENVIO As New DataGridViewTextBoxColumn
    '    With SERIE_GUIA_ENVIO
    '        .HeaderText = "SERIE_GUIA_ENVIO"
    '        .Name = "SERIE_GUIA_ENVIO"
    '        .DataPropertyName = "SERIE_GUIA_ENVIO"
    '        .Width = 30
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim NRO_GUIA As New DataGridViewTextBoxColumn
    '    With NRO_GUIA
    '        .HeaderText = "NRO_GUIA"
    '        .Name = "NRO_GUIA"
    '        .DataPropertyName = "NRO_GUIA"
    '        .Width = 130
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim FECHA As New DataGridViewTextBoxColumn
    '    With FECHA
    '        .HeaderText = "FECHA"
    '        .Name = "FECHA"
    '        .DataPropertyName = "FECHA"
    '        .Width = 80
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim FORMA_PAGO As New DataGridViewTextBoxColumn
    '    With FORMA_PAGO
    '        .HeaderText = "FORMA_PAGO"
    '        .Name = "FORMA_PAGO"
    '        .DataPropertyName = "FORMA_PAGO"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
    '    With MONTO_IMPUESTO
    '        .HeaderText = "MONTO_IMPUESTO"
    '        .Name = "MONTO_IMPUESTO"
    '        .DataPropertyName = "MONTO_IMPUESTO"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
    '    With TOTAL_COSTO
    '        .HeaderText = "TOTAL_COSTO"
    '        .Name = "TOTAL_COSTO"
    '        .DataPropertyName = "TOTAL_COSTO"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With

    '    With dgv4

    '        .Columns.AddRange(NOMBRE_AGENCIA, LOGIN, RAZON_SOCIAL, SERIE_GUIA_ENVIO, NRO_GUIA, FECHA, FORMA_PAGO, SIMBOLO_MONEDA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, ESTADO_REGISTRO)

    '    End With
    'End Sub
    Sub FORMAT_GRILLA3()
        DGV3.Columns.Clear()

        With DGV3
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvListar_facturas
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With



        Dim SERIE_COMPROBANTE As New DataGridViewTextBoxColumn
        With SERIE_COMPROBANTE
            .HeaderText = "Serie Comprobante Recibo"
            .Name = "SERIE_COMPROBANTE"
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "SERIE_COMPROBANTE"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NRO_COMPROBANTE As New DataGridViewTextBoxColumn
        With NRO_COMPROBANTE
            .HeaderText = "Nro. Comprobante Boleto"
            .Name = "NRO_COMPROBANTE"
            .DataPropertyName = "NRO_COMPROBANTE"
            .Width = 70
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim Fecha_Emision As New DataGridViewTextBoxColumn
        With Fecha_Emision
            .HeaderText = "Fecha Emisión Boleto"
            .Name = "Fecha_Emision_REFE"
            .DataPropertyName = "Fecha_Emision_REFE"
            .Width = 80
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim tipo_comprobante As New DataGridViewTextBoxColumn
        With tipo_comprobante
            .HeaderText = "Tipo Comprobante Recibo"
            .Name = "tipo_comprobante"
            .DataPropertyName = "tipo_comprobante"
            .Width = 100
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "Origen Recibo"
            .Name = "ORIGEN"
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "ORIGEN"

            .ReadOnly = True
        End With

        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "Destino Recibo"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim CONDICION As New DataGridViewTextBoxColumn
        With CONDICION
            .HeaderText = "Condición Recibo"
            .Name = "condicion"
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "condicion"

            .ReadOnly = True
        End With
        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "Total Costo Recibo"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .Width = 50
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With











        Dim SERIE_COMPROBANTE_REFE As New DataGridViewTextBoxColumn
        With SERIE_COMPROBANTE_REFE
            .HeaderText = "Serie Comprobante Boleto"
            .Name = "SERIE_COMPROBANTE_REFE"
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "SERIE_COMPROBANTE_REFE"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NRO_COMPROBANTE_REFE As New DataGridViewTextBoxColumn
        With NRO_COMPROBANTE_REFE
            .HeaderText = "Nro. Comprobante Boleto"
            .Name = "NRO_COMPROBANTE_REFE"
            .DataPropertyName = "NRO_COMPROBANTE_REFE"
            .Width = 70
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim Fecha_Emision_REFE As New DataGridViewTextBoxColumn
        With Fecha_Emision_REFE
            .HeaderText = "Fecha Emisión Boleto"
            .Name = "Fecha_Emision_REFE"
            .DataPropertyName = "Fecha_Emision_REFE"
            .Width = 80
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim tipo_comprobante_REFE As New DataGridViewTextBoxColumn
        With tipo_comprobante_REFE
            .HeaderText = "Tipo Comprobante Boleto"
            .Name = "tipo_comprobante_REFE"
            .DataPropertyName = "tipo_comprobante_REFE"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ORIGEN_REFE As New DataGridViewTextBoxColumn
        With ORIGEN_REFE
            .HeaderText = "Origen Boleto"
            .Name = "ORIGEN_REFE"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "ORIGEN_REFE"

            .ReadOnly = True
        End With
        Dim DESTINO_REFE As New DataGridViewTextBoxColumn
        With DESTINO_REFE
            .HeaderText = "Destino Boleto"
            .Name = "DESTINO_REFE"
            .DataPropertyName = "DESTINO_REFE"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim CONDICION_REFE As New DataGridViewTextBoxColumn
        With CONDICION_REFE
            .HeaderText = "Condición Boleto"
            .Name = "condicion_REFE"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "condicion_REFE"

            .ReadOnly = True
        End With
        Dim TOTAL_COSTO_REFE As New DataGridViewTextBoxColumn
        With TOTAL_COSTO_REFE
            .HeaderText = "Total Costo Boleto"
            .Name = "TOTAL_COSTO_REFE"
            .DataPropertyName = "TOTAL_COSTO_REFE"
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim estado_pago As New DataGridViewTextBoxColumn
        With estado_pago
            .HeaderText = ""
            .Name = "estado_pago"
            .DataPropertyName = "estado_pago"
            .Width = 15
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            '.DefaultCellStyle.Format = "N2"
            '.DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        With DGV3
            .Columns.AddRange(estado_pago, SERIE_COMPROBANTE, NRO_COMPROBANTE, Fecha_Emision, tipo_comprobante, ORIGEN, DESTINO, CONDICION, TOTAL_COSTO, _
            SERIE_COMPROBANTE_REFE, NRO_COMPROBANTE_REFE, Fecha_Emision_REFE, tipo_comprobante_REFE, ORIGEN_REFE, DESTINO_REFE, CONDICION_REFE, TOTAL_COSTO_REFE)

        End With
    End Sub

    Private Sub FrmConsulVentaPasaReciTotales_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Cruce de Boletos Prepagados/Recibo de caja"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False

            'datahelper
            'objgeneral.FN_cmb_Listar_agencias(cnn, Me.cmbAgencia)
            objgeneral.FN_cmb_Listar_agencias(Me.cmbAgencia)
            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0

            'datahelper
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            Me.cmbAgencia.SelectedIndex = -1
            Me.cmbUsuarios.SelectedIndex = -1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.GotFocus
        'dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub

    Private Sub cmbAgencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbAgencia.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbUsuarios.Focus()
        End If
    End Sub

    Private Sub cmbAgencia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectionChangeCommitted
        Try
            Dim p_id_rol_usuario, p_idagencia As Int64
            p_id_rol_usuario = 0
            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
                'datahelper
                'objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(cnn, Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
                objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
            Else
                cmbUsuarios.DataSource = Nothing
            End If
            Me.cmbUsuarios.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub FrmConsulFactuEmiti_MenuImprimir() Handles Me.MenuImprimir
        Try
            ObjReport.Dispose()
        Catch

        End Try

        ObjReport = New ClsLbTepsa.dtoFrmReport

        Select Case Me.TabMante.SelectedIndex
            Case 0
                Try

                    Dim v_usuario_personal, v_nombre_agencia
                    If Me.DGV3.RowCount <= 0 Then
                        MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                        Exit Sub
                    End If
                    Dim ObjGiros As New ClsLbTepsa.dtoGiros

                    'If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                    'ObjFactura.IDPERSONA = 0
                    'Else

                    'ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    'End If
                    If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjGiros.FECHA_INI = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjGiros.FECHA_INI = "NULL"
                    If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjGiros.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjGiros.FECHA_FINAL = "NULL"
                    'If Not IsNothing(Me.cbidtipo_moneda.SelectedValue) Then
                    'ObjFactura.IDTIPO_MONEDA = Me.cbidtipo_moneda.SelectedValue
                    'Else
                    'ObjFactura.IDTIPO_MONEDA = 0
                    'End If
                    If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                        ObjGiros.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
                        v_usuario_personal = "USUARIO: " & Me.cmbUsuarios.Text
                    Else
                        ObjGiros.IDUSUARIO_PERSONAL = 0
                        v_usuario_personal = ""
                    End If
                    If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                        ObjGiros.IDAGENCIAS = cmbAgencia.SelectedValue
                        v_nombre_agencia = "AGENCIA: " & Me.cmbAgencia.Text
                    Else
                        ObjGiros.IDAGENCIAS = 0
                        v_nombre_agencia = ""
                    End If

                    'If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                    'ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
                    'Else
                    'ObjFactura.IDFORMA_PAGO = 0
                    'End If

                    With ObjGiros

                        '.IDFACTURA = Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("IDFACTURA")

                        'ObjReport = New ClsLbTepsa.dtoFrmReport
                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)

                        'Dim PREFACTURA As String
                        'If Not Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index).IsNull("NRO_PREFACTURA") Then

                        '    If Not Trim(Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("NRO_PREFACTURA")) = "" Then
                        '        PREFACTURA = "Prefactura Nro.:" & Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("NRO_PREFACTURA")
                        '    Else
                        '        PREFACTURA = ""
                        '    End If
                        'Else
                        '    PREFACTURA = ""
                        'End If



                        If Me.rbgene.Checked = True Then
                            ObjReport.printrpt(False, "", "VPA007.RPT", _
                            "p_nombre_agencia;" & v_nombre_agencia, _
                            "p_USUARIO_PERSONAL;" & v_usuario_personal, _
                            "p_IDUSUARIO_PERSONAL;" & .IDUSUARIO_PERSONAL, _
                            "p_idagencias;" & .IDAGENCIAS, _
                            "p_RANGO_FECHA;" & "(DESDE " & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString & " HASTA " & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString & ")", _
                            "p_fecha_ini;" & .FECHA_INI, _
                            "p_fecha_final;" & .FECHA_FINAL)

                        End If



                    End With
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
                End Try
        End Select
    End Sub

    Private Sub FrmConsulFactuEmiti_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub

    Private Sub txtidpersona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub



    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus
        'dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAINICIOFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPFECHAFINALFACTURA.Focus()
        End If
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.GotFocus
        ' dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub



    Private Sub cbidforma_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidforma_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            Me.cmbAgencia.Focus()
        End If
    End Sub

    Private Sub cmbUsuarios_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUsuarios.GotFocus
        'dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub


    Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUsuarios.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
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

    Private Sub DGV3_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV3.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV3), 0)
    End Sub

    Private Sub DGV3_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGV3.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV3), 0)
    End Sub

    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub
End Class
