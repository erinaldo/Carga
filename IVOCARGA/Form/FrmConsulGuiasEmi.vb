Public Class FrmConsulGuiasEmi
    Dim dvListar_guias As New DataView
    Dim dv_idcentro_costo As New DataView

    Dim Colllistar_persona_todos As New Collection
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection

    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL

    Dim dvlistar_persona_todos As New DataView
    Dim dvlistar_tipo_moneda As New DataView

    Dim dvlistar_forma_pago As New DataView

    Dim ID_PERSONA_ECKERD As Integer = 1266

    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        listar_GUIAS()
    End Sub
    Private Sub listar_GUIAS()
        Try


            Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                ObjFactura.IDPERSONA = 0
            Else
                ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"
            If Not IsNothing(Me.cbidtipo_moneda.SelectedValue) Then
                ObjFactura.IDTIPO_MONEDA = Me.cbidtipo_moneda.SelectedValue
            Else
                ObjFactura.IDTIPO_MONEDA = 0
            End If
            If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
            Else
                ObjFactura.IDUSUARIO_PERSONAL = 0
            End If
            If Not IsNothing(cmbAgencia.SelectedValue) Then
                ObjFactura.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            Else
                ObjFactura.IDAGENCIAS = 0
            End If

            If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            Else
                ObjFactura.IDFORMA_PAGO = 0
            End If

            If Not IsNothing(Me.cbidcentro_costo.SelectedValue) Then
                ObjFactura.idcentro_costo = Me.cbidcentro_costo.SelectedValue
            Else
                ObjFactura.idcentro_costo = 0
            End If

            If Not IsNothing(Me.cboTipoProducto.SelectedValue) Then
                If Me.cboTipoProducto.SelectedIndex = 0 Then
                    ObjFactura.Producto = -1
                Else
                    ObjFactura.Producto = Me.cboTipoProducto.SelectedValue
                End If
            Else
                ObjFactura.Producto = -1
            End If

                If Me.cboFacturado.SelectedIndex <> -1 Then
                    If Me.cboFacturado.SelectedIndex = 0 Then
                        ObjFactura.FACTURADO = -1
                    ElseIf Me.cboFacturado.SelectedIndex = 1 Then
                        ObjFactura.FACTURADO = 1
                    Else
                        ObjFactura.FACTURADO = 0
                    End If
                Else
                    ObjFactura.FACTURADO = -1
                End If

                'Datahelper
                dvListar_guias = ObjFactura.FN_CONSUL_GUIAS_EMI_DG_II()
                FORMAT_GRILLA3()
                '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Sub FORMAT_GRILLA3()
        DGV3.Columns.Clear()

        With DGV3
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvListar_guias
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            '.Width = 30
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUBTOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            '.Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "USUARIO"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            '.Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .ReadOnly = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "CLIENTE"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            '.Width = 200
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SERIE_GUIA_ENVIO As New DataGridViewTextBoxColumn
        With SERIE_GUIA_ENVIO
            .HeaderText = "Nº SERIE"
            .Name = "SERIE_GUIA_ENVIO"
            .DataPropertyName = "SERIE_GUIA_ENVIO"
            '.Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.NullValue = "000"
        End With
        Dim NRO_GUIA As New DataGridViewTextBoxColumn
        With NRO_GUIA
            .HeaderText = "Nº GUIA"
            .Name = "NRO_GUIA"
            .DataPropertyName = "NRO_GUIA"
            '.Width = 130
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_GUIA As New DataGridViewTextBoxColumn
        With FECHA_GUIA
            .HeaderText = "FECHA GUIA"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            '.Width = 80
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            '.Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim CENTRO_COSTO As New DataGridViewTextBoxColumn
        With CENTRO_COSTO
            .HeaderText = "CENTRO COSTO"
            .Name = "CENTRO_COSTO"
            .DataPropertyName = "CENTRO_COSTO"
            '.Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            '.Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            '.Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "ESTADO REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            '.Width = 100
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim producto As New DataGridViewTextBoxColumn
        With producto
            .HeaderText = "PRODUCTO"
            .Name = "producto"
            .DataPropertyName = "producto"
            '.Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        End With
        Dim facturado As New DataGridViewTextBoxColumn
        With facturado
            .HeaderText = "FACTURADO"
            .Name = "facturado"
            .DataPropertyName = "factura"
            '.Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        End With
        With DGV3
            .Columns.AddRange(NOMBRE_AGENCIA, LOGIN, RAZON_SOCIAL, SERIE_GUIA_ENVIO, NRO_GUIA, FECHA_GUIA, FORMA_PAGO, SIMBOLO_MONEDA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, ESTADO_REGISTRO, CENTRO_COSTO, producto, facturado)
        End With
    End Sub

    Private Sub FrmConsulGuiasEmi_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulGuiasEmi_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Consulta de Guias Emitidas"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            'Mod.17/09/2009 -->Omendoza - Pasando al datahelper   
            'objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
            objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago)
            '
            'datahelper
            'objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_moneda, VOCONTROLUSUARIO)
            objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_moneda)

            'datahelper
            'objgeneral.FNLISTAR_CENTRO_COSTO(dv_idcentro_costo, Me.cbidcentro_costo, VOCONTROLUSUARIO)
            objgeneral.FNLISTAR_CENTRO_COSTO(dv_idcentro_costo, Me.cbidcentro_costo)

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
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)

            Dim obj As New dtoVentaCargaContado
            'Dim dt1 As DataTable = obj.ListarProducto(2, 1)
            Dim dt1 As DataTable = obj.ListarProducto()
            With Me.cboTipoProducto
                .DataSource = dt1
                .ValueMember = "idprocesos"
                .DisplayMember = "procesos"
            End With

            Me.cbidtipo_moneda.SelectedIndex = -1
            Me.cbidforma_pago.SelectedIndex = -1
            Me.cmbAgencia.SelectedIndex = -1
            Me.cmbUsuarios.SelectedIndex = -1
            Me.cbidcentro_costo.SelectedIndex = -1
            Me.cboFacturado.SelectedIndex = 0

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.GotFocus
        DGV3.DataSource = Nothing
    End Sub

    Private Sub cmbAgencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbAgencia.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbUsuarios.Focus()
        End If
    End Sub




    Private Sub cmbAgencia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectionChangeCommitted
        Dim p_id_rol_usuario, p_idagencia As Int64
        p_id_rol_usuario = 0
        If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
            p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
            'datahelper
            objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
        Else
            cmbUsuarios.DataSource = Nothing
        End If


    End Sub

    Private Sub FrmConsulFactuEmiti_MenuImprimir() Handles Me.MenuImprimir

        Select Case Me.TabMante.SelectedIndex
            Case 0
                Try
                    If Me.DGV3.RowCount <= 0 Then
                        MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                        Exit Sub
                    End If
                    Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

                    If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                        ObjFactura.IDPERSONA = 0
                    Else

                        ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    End If
                    If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
                    If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"
                    If Not IsNothing(Me.cbidtipo_moneda.SelectedValue) Then
                        ObjFactura.IDTIPO_MONEDA = Me.cbidtipo_moneda.SelectedValue
                    Else
                        ObjFactura.IDTIPO_MONEDA = 0
                    End If
                    If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                        ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
                    Else
                        ObjFactura.IDUSUARIO_PERSONAL = 0
                    End If
                    If Not IsNothing(cmbAgencia.SelectedValue) Then
                        ObjFactura.IDAGENCIAS = Me.cmbAgencia.SelectedValue
                    Else
                        ObjFactura.IDAGENCIAS = 0
                    End If

                    If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                        ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
                    Else
                        ObjFactura.IDFORMA_PAGO = 0
                    End If

                    If Not IsNothing(Me.cbidcentro_costo.SelectedValue) Then
                        ObjFactura.idcentro_costo = Me.cbidcentro_costo.SelectedValue
                    Else
                        ObjFactura.idcentro_costo = 0
                    End If

                    If Not IsNothing(cboTipoProducto.SelectedIndex) Then
                        ObjFactura.Producto = IIf(Me.cboTipoProducto.SelectedIndex = 0, -1, Me.cboTipoProducto.SelectedValue)
                    Else
                        ObjFactura.Producto = -1
                    End If

                    If Not IsNothing(cboFacturado.SelectedIndex) Then
                        ObjFactura.FACTURADO = IIf(Me.cboFacturado.SelectedIndex = 0, -1, Me.cboFacturado.SelectedValue)
                    Else
                        ObjFactura.FACTURADO = -1
                    End If

                    With ObjFactura

                        .IDGUIAS_ENVIO = Me.dvListar_guias.Table.Rows(Me.DGV3.CurrentRow.Index)("IDGUIAS_ENVIO")

                        Try
                            ObjReport.Dispose()
                        Catch
                        End Try
                        ObjReport = New ClsLbTepsa.dtoFrmReport
                        'ClsLbTepsa.dtoFrmReport.rutaRpt = ""
                        'ClsLbTepsa.dtoFrmReport.conectar(rptservice, rptuser, rptpass)

                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)
                        If Me.rbge.Checked = True Then
                            ObjReport.printrptB(False, "", "GUI002.RPT", _
                            "p_idpersona;" & .IDPERSONA, _
                            "p_idforma_pago;" & .IDFORMA_PAGO, _
                            "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                            "p_idcentro_costo;" & .idcentro_costo, _
                            "p_idagencias;" & .IDAGENCIAS, _
                            "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                            "p_fecha_inicial;" & .FECHA_INICIO, _
                            "p_fecha_final;" & .FECHA_FINAL, _
                            "ni_producto;" & .Producto, _
                            "ni_facturado;" & .FACTURADO, _
                            "p_titulo_fecha;" & "Del " & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString & " Al " & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString)
                        ElseIf Me.rbcge.Checked = True Then
                            ObjReport.printrptB(False, "", "GUI004.RPT", _
                            "p_idpersona;" & .IDPERSONA, _
                            "p_idforma_pago;" & .IDFORMA_PAGO, _
                            "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                            "p_idagencias;" & .IDAGENCIAS, _
                            "p_idcentro_costo;" & .idcentro_costo, _
                            "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                            "p_fecha_inicial;" & .FECHA_INICIO, _
                            "p_fecha_final;" & .FECHA_FINAL, _
                            "ni_producto;" & .Producto, _
                            "ni_facturado;" & .FACTURADO, _
                            "p_titulo_fecha;" & "Del " & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString & " Al " & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString)
                        ElseIf Me.rbseguientre.Checked = True Then
                            ObjReport.printrptB(False, "", "GUI005.RPT", _
                            "p_idpersona;" & .IDPERSONA, _
                            "p_idforma_pago;" & .IDFORMA_PAGO, _
                            "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                            "p_idcentro_costo;" & .idcentro_costo, _
                            "p_idagencias;" & .IDAGENCIAS, _
                            "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                            "p_fecha_inicial;" & .FECHA_INICIO, _
                            "p_fecha_final;" & .FECHA_FINAL, _
                            "ni_producto;" & .Producto, _
                            "ni_facturado;" & .FACTURADO, _
                            "p_titulo_fecha;" & "Del " & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString & " Al " & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString)
                        ElseIf Me.rbGeSap.Checked = True Then
                            ObjReport.printrptB(False, "", "GUI023.RPT", _
                            "p_idpersona;" & .IDPERSONA, _
                            "p_idforma_pago;" & .IDFORMA_PAGO, _
                            "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                            "p_idcentro_costo;" & .idcentro_costo, _
                            "p_idagencias;" & .IDAGENCIAS, _
                            "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                            "p_fecha_inicial;" & .FECHA_INICIO, _
                            "p_fecha_final;" & .FECHA_FINAL, _
                            "p_titulo_fecha;" & "Del " & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString & " Al " & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString)
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

    Private Sub txtidpersona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.GotFocus
        DGV3.DataSource = Nothing
    End Sub

    Private Sub txtidpersona_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyUp
        Try
            If e.KeyCode = 13 Then
                If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                    With ObjPersona
                        .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                        .IDTIPO_PERSONA = 0
                        .CODIGO_CLIENTE = "NULL"
                        'datahelper
                        'ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, .IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                        ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                        Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                    End With
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL

                    If ID_PERSONA_ECKERD = ObjPersona.IDPERSONA Then
                        Me.rbGeSap.Visible = True
                    Else
                        Me.rbGeSap.Visible = False
                    End If
                Else
                    Me.rbGeSap.Visible = False
                    Me.txtCodigoCliente.Text = ""
                End If
                Me.DTPFECHAINICIOFACTURA.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub txtidpersona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.LostFocus
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.TextChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.GotFocus
        DGV3.DataSource = Nothing
    End Sub

    Private Sub txtCodigoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        Try
            If e.KeyChar = Chr(13) Then

                ObjPersona.CODIGO_CLIENTE = Trim(Me.txtCodigoCliente.Text)
                ObjPersona.IDTIPO_PERSONA = 0
                ObjPersona.IDPERSONA = 0

                If Len(ObjPersona.CODIGO_CLIENTE) = 0 Then
                    Me.txtCodigoCliente.Text = ""
                    Me.txtidpersona.Text = ""
                    Exit Sub
                End If

                'datahelper
                'If ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                If ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                    Me.txtidpersona.Text = ObjPersona.RAZON_SOCIAL
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                    txtidpersona.Focus()
                Else
                    MsgBox("No existe el cliente", MsgBoxStyle.Information, "Segurdiad del Sistema")
                    Me.txtidpersona.Text = ""
                    Me.rbGeSap.Visible = False
                End If
            End If
        Catch EX As Exception
            MsgBox(EX.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub txtCodigoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.LostFocus
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus
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
        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidtipo_moneda.Focus()
        End If
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidtipo_moneda.GotFocus

        DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_moneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_moneda.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidforma_pago.Focus()
        End If
    End Sub

    Private Sub cbidforma_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidforma_pago.GotFocus
        DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidforma_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidforma_pago.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbAgencia.Focus()
        End If
    End Sub

    Private Sub cmbUsuarios_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUsuarios.GotFocus
        DGV3.DataSource = Nothing
    End Sub
    Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUsuarios.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub

    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub TabLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabLista.Click

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

    Private Sub cbidtipo_moneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidtipo_moneda.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidforma_pago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidforma_pago.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbge.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbcge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcge.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbseguientre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbseguientre.CheckedChanged, rbGeSap.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub
End Class
