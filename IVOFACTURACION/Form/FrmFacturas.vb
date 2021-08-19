Public Class FrmFacturas

    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    'Dim var As ADOSERVERLib.IVOCONCESIONARIO

    Dim dvlistar_centro_costos_personas As New DataView
    Dim dvListar_Centro_Costos_personas_ As New DataView
    Dim dvlistar_persona As New DataView
    Dim dvlistar_persona_todos As New DataView
    Dim dvlistar_forma_pago As New DataView
    Dim dvlistar_tipo_moneda As New DataView
    Dim SumatoriaMonto As Double

    Dim dvListar_guias As New DataView

    Dim dvListar_facturas As New DataView
    Dim dvfacturas_guias As New DataView

    Dim Colllistar_persona_todos As New Collection
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection
    Dim glosa02 As String

    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Sub FORMAT_GRILLA()
        DGV1.Columns.Clear()

        With DGV1
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
            .ReadOnly = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With


        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .ReadOnly = True
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .ReadOnly = True
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With


        Dim SELECCIONAR As New DataGridViewCheckBoxColumn
        With SELECCIONAR
            .HeaderText = "SELECCIONAR"
            .Name = "SELECCIONAR"
            .DataPropertyName = "SELECCIONAR"
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With


        Dim LIQUIDADO As New DataGridViewTextBoxColumn
        With LIQUIDADO
            .HeaderText = "LIQUIDADO"
            .Name = "DESC_LIQUIDADO"
            .DataPropertyName = "DESC_LIQUIDADO"
            .ReadOnly = True
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With


        Dim FACTURADO As New DataGridViewTextBoxColumn
        With FACTURADO
            .HeaderText = "FACTURADO"
            .Name = "DESC_FACTURADO"
            .DataPropertyName = "DESC_FACTURADO"
            .ReadOnly = True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With


        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUB_TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "NOMBRE_AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "LOGIN"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim SERIE_GUIA_ENVIO As New DataGridViewTextBoxColumn
        With SERIE_GUIA_ENVIO
            .HeaderText = "SERIE_GUIA_ENVIO"
            .Name = "SERIE_GUIA_ENVIO"
            .DataPropertyName = "SERIE_GUIA_ENVIO"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .DefaultCellStyle.NullValue = "000"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim NRO_GUIA As New DataGridViewTextBoxColumn
        With NRO_GUIA
            .HeaderText = "NRO_GUIA"
            .Name = "NRO_GUIA"
            .DataPropertyName = "NRO_GUIA"
            .Width = 130
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim FECHA_GUIA As New DataGridViewTextBoxColumn
        With FECHA_GUIA
            .HeaderText = "FECHA_GUIA"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "MONTO_IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL_COSTO"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        With DGV1

            .Columns.AddRange(SELECCIONAR, ORIGEN, DESTINO, RAZON_SOCIAL, SERIE_GUIA_ENVIO, NRO_GUIA, FECHA_GUIA, FORMA_PAGO, SIMBOLO_MONEDA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, LIQUIDADO, FACTURADO)

        End With

    End Sub
    Sub FORMAT_GRILLA2()
        DGV2.Columns.Clear()

        With DGV2
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

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .HeaderText = "ORDEN"
            .Name = "ORDEN"
            .DataPropertyName = "ORDEN"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "FECHA_GUIA"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .HeaderText = "NRO_GUIA"
            .Name = "NRO_GUIA"
            .DataPropertyName = "NRO_GUIA"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .HeaderText = "CANTIDAD"
            .Name = "CANTIDAD"
            .DataPropertyName = "CANTIDAD"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .HeaderText = "TOTAL_PESO"
            .Name = "TOTAL_PESO"
            .DataPropertyName = "TOTAL_PESO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .HeaderText = "TOTAL_VOLUMEN"
            .Name = "TOTAL_VOLUMEN"
            .DataPropertyName = "TOTAL_VOLUMEN"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col8 As New DataGridViewTextBoxColumn
        With col8
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col9 As New DataGridViewTextBoxColumn
        With col9
            .HeaderText = "SUB TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col10 As New DataGridViewTextBoxColumn
        With col10
            .HeaderText = "IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim Col11 As New DataGridViewTextBoxColumn
        With Col11
            .HeaderText = "TOTAL_COSTO"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim Col12 As New DataGridViewTextBoxColumn
        With Col12
            .HeaderText = "CONSIGNADO"
            .Name = "CONSIGNADO"
            .DataPropertyName = "CONSIGNADO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim Col13 As New DataGridViewTextBoxColumn
        With Col13
            .HeaderText = "ESTADO_REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim Col14 As New DataGridViewCheckBoxColumn
        With Col14
            .HeaderText = "SELECCIONAR"
            .Name = "SELECCIONAR"
            .DataPropertyName = "SELECCIONAR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            '.FlatStyle = FlatStyle.Standard
            '.CellTemplate = New DataGridViewCheckBoxCell()
            '.CellTemplate.Style.BackColor = Color.Beige
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Me.DGV2.Columns.AddRange(col0, col1, col2, col3, col4, col5, col6, col7, col8, col9, col10, Col11, Col12, Col13, Col14)
        DGV2.Columns(5).Visible = False
        DGV2.Columns(6).Visible = False
        DGV2.Columns(7).Visible = False
        DGV2.Columns(8).Visible = False
        DGV2.Columns(9).Visible = True
        DGV2.Columns(10).Visible = True
        DGV2.Columns(12).Visible = False

        DGV2.Columns(0).Visible = False
        DGV2.Columns(3).Visible = False
        DGV2.Columns(8).Visible = False
        DGV2.Columns(13).Visible = False
        DGV2.Columns(14).Visible = False

    End Sub

    Private Sub FrmFacturas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmFacturas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            Me.MenuStrip1.Items(6).Visible = False
            Me.MenuStrip1.Items(7).Visible = True
            Me.MenuStrip1.Items(8).Visible = True

            Me.ShadowLabel1.Text = "Facturacion de Guias de Envio"
            Me.MenuTab.Items(0).Text = "GUIAS DE ENVIO"
            Me.MenuTab.Items(1).Text = "FACTURA"
            Me.MenuTab.Items(2).Text = "IMPRESION"

            HabilitarMenu(MenuTab)

            Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL

            'datahelper
            'ObjGeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
            'ObjGeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_moneda, VOCONTROLUSUARIO)
            ObjGeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago)
            ObjGeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_moneda)

            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0

            'datahelper
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA_1_Y_2(VOCONTROLUSUARIO, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA_1_Y_2(ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)

            Me.cbidtipo_moneda.SelectedValue = 1
            Me.cbidtipo_moneda.Enabled = False

            Me.cbidforma_pago.SelectedValue = 2
            Me.cbidforma_pago.Enabled = False

            'datahelper
            'ObjGeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA)
            'ObjGeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA_DESTINO)

            ObjGeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA)
            ObjGeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA_DESTINO)

            Me.CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
            '--
            Me.Labguiasselecciona.Text = "0"
            '

            'hlamas 03-10-2013
            Dim obj As New dtoVentaCargaContado
            With Me.cmbProducto
                .DataSource = obj.ListarProducto(2)
                .ValueMember = "idprocesos"
                .DisplayMember = "procesos"
                .SelectedValue = 8
            End With

            'hlamas 23-03-2017
            With Me.cboTipoAfectacion
                .DisplayMember = "descripcion"
                .ValueMember = "codigo"
                .DataSource = ListarTipoControl(16, 2)
                .SelectedValue = 1
            End With

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub FrmPreFactura_MenuSalir() Handles Me.MenuSalir
        Me.Close()
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
                'dvlistar_persona = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
                dvlistar_persona = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)

                If dvlistar_persona.Count = 1 Then
                    Me.txtidpersona.Text = ObjPersona.RAZON_SOCIAL
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                    ObjGeneral.fnL_CENTRO_COSTOS_PERSONAS(dvlistar_centro_costos_personas, Me.cbidcentro_costo, ObjPersona.IDPERSONA)
                    txtidpersona.Focus()
                Else
                    Me.cbidcentro_costo.DataSource = Nothing
                    MsgBox("No existe el cliente", MsgBoxStyle.Information, "Segurdiad del Sistema")
                    Me.txtidpersona.Text = ""
                End If
            End If
        Catch EX As Exception
            MsgBox(EX.ToString, MsgBoxStyle.Information, "Titan")
        End Try
    End Sub

    Private Sub mostrar_guias()
        Try
            Dim ObjGuias As New ClsLbTepsa.dtoguias
            If Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                MsgBox("Seleccione el Cliente", MsgBoxStyle.Information, "Titan")
                Me.txtidpersona.Focus()
                Exit Sub
            End If

            If Me.cmbProducto.SelectedValue = 0 Then
                MessageBox.Show("Seleccione el Producto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbProducto.Focus()
                Exit Sub
            End If

            ObjGuias.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            ObjGuias.FECHA_INICIO = Me.dtpfecha_inicio.Value.ToShortDateString
            ObjGuias.FECHA_INICIO = "01/" + Format(CDate(ObjGuias.FECHA_INICIO), "MM/yyyy")
            ObjGuias.FECHA_FINAL = "01/" + Format(CDate(Me.dtpfecha_inicio.Value.ToShortDateString), "MM/yyyy")
            ObjGuias.FECHA_FINAL = DateAdd(DateInterval.Month, 1, CDate(ObjGuias.FECHA_FINAL))
            ObjGuias.FECHA_FINAL = DateAdd(DateInterval.Day, -1, CDate(ObjGuias.FECHA_FINAL))
            ObjGuias.IDTIPO_MONEDA = Me.cbidtipo_moneda.SelectedValue

            If IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                ObjGuias.IDUNIDAD_AGENCIA = 0
            Else
                ObjGuias.IDUNIDAD_AGENCIA = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            End If

            If IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                ObjGuias.IDUNIDAD_AGENCIA_DESTINO = 0
            Else
                ObjGuias.IDUNIDAD_AGENCIA_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            End If

            If IsNothing(Me.cbidcentro_costo_.SelectedValue) Then
                ObjGuias.IDCENTRO_COSTO = 0
            Else
                ObjGuias.IDCENTRO_COSTO = Me.cbidcentro_costo_.SelectedValue
            End If

            ObjGuias.LIQUIDADO = IIf(Me.CHKLIQUI.Checked = True, 1, 0)
            ObjGuias.FACTURADO = IIf(Me.CHKFACTU.Checked = True, 1, 0)
            'datahelper
            'dvListar_guias = ObjGuias.FNLISTAR_GUIAS(VOCONTROLUSUARIO)

            'hlamas 03-10-2013
            ObjGuias.Producto = Me.cmbProducto.SelectedValue

            dvListar_guias = ObjGuias.FNLISTAR_GUIAS()
            FORMAT_GRILLA()
            FORMAT_GRILLA5()
            Call CalcularSumatoriaMonto()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        mostrar_guias()
    End Sub
    Private Sub CalcularSumatoriaMonto()

        Dim P_SUB_TOTAL As Double = 0
        Dim P_IMPUESTO As Double = 0
        Dim l_nroguias_seleccion As Long = 0
        SumatoriaMonto = 0
        For i As Integer = 0 To dvListar_guias.Count - 1
            Dim drv As DataRowView = dvListar_guias.Item(i)
            If drv("SELECCIONAR") = 1 Then
                P_SUB_TOTAL = P_SUB_TOTAL + CDbl(drv("SUB_TOTAL"))
                P_IMPUESTO = P_IMPUESTO + CDbl(drv("MONTO_IMPUESTO"))
                SumatoriaMonto = SumatoriaMonto + CDbl(drv("TOTAL_COSTO"))
                l_nroguias_seleccion = l_nroguias_seleccion + 1
            End If
        Next

        Me.TXTSUB_TOTAL.Text = FormatNumber(P_SUB_TOTAL, 2)
        'Me.TXTIMPUESTO.Text = FormatNumber(P_IMPUESTO, 2)
        'Me.txtSumatoriaMonto.Text = FormatNumber(SumatoriaMonto, 2)
        Me.TXTIMPUESTO.Text = FormatNumber(P_SUB_TOTAL * dtoUSUARIOS.vImpuesto, 2)

        Me.txtSumatoriaMonto.Text = FormatNumber(CDbl(Me.TXTSUB_TOTAL.Text) + CDbl(Me.TXTIMPUESTO.Text), 2)
        Me.Labguiasselecciona.Text = CType(l_nroguias_seleccion, String)
    End Sub
    Private Sub SeleccionarHastaEstaPosicionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarHastaEstaPosicionToolStripMenuItem.Click
        Try
            Dim objfactura As New ClsLbTepsa.dtoFACTURA
            For i As Integer = 0 To Me.dvListar_guias.Count - 1
                Me.dvListar_guias.Table.Rows(i)("seleccionar") = 0
                objfactura.IDGUIAS_ENVIO = Me.dvListar_guias.Table.Rows(i)("idguias_envio")
                objfactura.SELECCIONAR_TO_FACTURA = 0
                'datahelper
                'objfactura.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)
                objfactura.fn_UPDATE_SELEC_TO_FACTURA()
            Next

            For i As Integer = 0 To Me.DGV1.CurrentRow.Index
                If dvListar_guias.Table.Rows(i)("liquidado") = 1 And dvListar_guias.Table.Rows(i)("facturado") = 0 Then
                    Me.dvListar_guias.Table.Rows(i)("seleccionar") = 1
                    objfactura.IDGUIAS_ENVIO = Me.dvListar_guias.Table.Rows(i)("idguias_envio")
                    objfactura.SELECCIONAR_TO_FACTURA = 1
                    'datahelper
                    'objfactura.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)
                    objfactura.fn_UPDATE_SELEC_TO_FACTURA()
                End If
            Next
            Me.DGV1.EndEdit()
            Me.CalcularSumatoriaMonto()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub RestablecerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestablecerToolStripMenuItem.Click
        Try
            Dim objfactura As New ClsLbTepsa.dtoFACTURA
            For i As Integer = 0 To Me.dvListar_guias.Count - 1
                Me.dvListar_guias.Table.Rows(i)("seleccionar") = 0
                objfactura.IDGUIAS_ENVIO = Me.dvListar_guias.Table.Rows(i)("idguias_envio")
                objfactura.SELECCIONAR_TO_FACTURA = 0
                'datahelper
                'objfactura.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)
                objfactura.fn_UPDATE_SELEC_TO_FACTURA()
            Next
            Me.DGV1.EndEdit()
            Me.CalcularSumatoriaMonto()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub FrmPrefacturacion_ClickTabPage1() Handles Me.ClickTabPage1

        Me.MenuStrip1.Items(0).Visible = False
        Me.MenuStrip1.Items(1).Visible = False
        Me.MenuStrip1.Items(2).Visible = False
        Me.MenuStrip1.Items(3).Visible = False
        Me.MenuStrip1.Items(4).Visible = False
        Me.MenuStrip1.Items(5).Visible = False
        Me.MenuStrip1.Items(6).Visible = False
        Me.MenuStrip1.Items(7).Visible = True
        Me.MenuStrip1.Items(8).Visible = True

        'Me.dgvGuiasEnvio.EndEdit()

        'MessageBox.Show(dvGuias.Item(0).Item("ORIGEN").ToString)
        'MessageBox.Show(dvGuias.Item(0).Item("SELECCIONAR").ToString)

        Me.dvListar_guias.RowFilter = "SELECCIONAR =0 or SELECCIONAR=1"

    End Sub
    Private Sub FrmPrefacturacion_ClickTabPage2() Handles Me.ClickTabPage2
        Try
            Dim obj As New ClsLbTepsa.dtoCONTROL_COMPROBANTES
            With obj
                'datahelper
                '.FNLISTAR_CONTROL_COMPROBANTES(VOCONTROLUSUARIO, dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, dtoUSUARIOS.IdLogin, 1)
                '.FNLISTAR_CONTROL_COMPROBANTES(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, dtoUSUARIOS.IdLogin, 1)

                'CAMBIAR ESTATITCO
                Me.TXTSERIE.Text = "" '.SERIE
                Me.TXTNRO_DOCUMENTO.Text = "" '.NRO_DOCUMENTO
            End With

            cboTipoAfectacion.SelectedValue = 1
            txtCodigoClienteFinal.Text = txtCodigoCliente.Text
            txtIDPERSONAFinal.Text = txtidpersona.Text
            Me.TXTSUB_TOTALFINAL.Text = Me.TXTSUB_TOTAL.Text
            Me.TXTIMPUESTOFINAL.Text = Me.TXTIMPUESTO.Text

            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = True
            Me.MenuStrip1.Items(3).Enabled = True
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            Me.MenuStrip1.Items(6).Visible = False
            Me.MenuStrip1.Items(7).Visible = True
            Me.MenuStrip1.Items(8).Visible = True
            txtMontoFacturaFinal.Text = Me.txtSumatoriaMonto.Text
            Me.dvListar_guias.RowFilter = "SELECCIONAR = 1"
            Me.FORMAT_GRILLA2()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub FrmPrefacturacion_ClickTabPage3() Handles Me.ClickTabPage3

        Me.MenuStrip1.Items(0).Visible = False
        Me.MenuStrip1.Items(1).Visible = False
        Me.MenuStrip1.Items(2).Visible = False
        Me.MenuStrip1.Items(3).Visible = False
        Me.MenuStrip1.Items(4).Visible = False
        Me.MenuStrip1.Items(5).Visible = False
        Me.MenuStrip1.Items(6).Visible = False '-->Imprimir - jabanto 16/05/2016 (F.E.) 
        Me.MenuStrip1.Items(7).Visible = True
        Me.MenuStrip1.Items(8).Visible = True

        'Me.dgvGuiasEnvio.EndEdit()

        'MessageBox.Show(dvGuias.Item(0).Item("ORIGEN").ToString)
        'MessageBox.Show(dvGuias.Item(0).Item("SELECCIONAR").ToString)
        Dim dv_direccion As New DataView
        Dim objFACTURA As New ClsLbTepsa.dtoFACTURA

        If ObjPersona.IDPERSONA.ToString.Trim.Length > 0 And ObjPersona.CODIGO_CLIENTE.ToString.Trim.Length > 0 Then
            'Carga Direcciones Legales de Cliente
            'datahelper
            'dv_direccion = objFACTURA.sp_cargar_direccion_cliente(cnn, ObjPersona.IDPERSONA)
            dv_direccion = objFACTURA.sp_cargar_direccion_cliente(ObjPersona.IDPERSONA)
            If dv_direccion.Table.Rows.Count > 0 Then
                dv_direccion = CargarCombo(Me.cmbDireccion, dv_direccion, "direccion", "iddireccion_consignado", 0)
            End If
        End If


        Me.dvListar_guias.RowFilter = "SELECCIONAR =0 or SELECCIONAR=1"

    End Sub

    Private Function validar_facturacion() As Boolean
        validar_facturacion = False
        If Me.cboTipoAfectacion.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Tipo de Afectación del Igv", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoAfectacion.Focus()
            Exit Function
        End If

        If DGV2.Rows.Count = 0 Then
            MsgBox("Seleccione las Guías a Facturar", MsgBoxStyle.Information, "Titan")
            Exit Function
        End If
        Dim ObjValida As New ClsLbTepsa.dtoValida
        With ObjValida
            If .CB_SELECT_VALUE(Me.cbidcentro_costo, Me) = False Then Exit Function
        End With
        validar_facturacion = True
    End Function

    Private Sub FrmFacturas_MenuGrabar() Handles Me.MenuGrabar
        Try
            If validar_facturacion() = False Then Exit Sub

            Dim P_CANTIDAD As Double
            Dim P_TOTAL_PESO As Double
            Dim P_TOTAL_VOLUMEN As Double
            Dim P_TOTAL_COSTO As Double
            Dim P_MONTO_IMPUESTO As Double
            Dim P_CANTIDAD_X_UNIDAD_VOLUMEN As Double
            Dim P_CANTIDAD_X_UNIDAD_ARTI As Double
            '
            Dim ObjGuias_Envio_Prefactura As New ClsLbTepsa.dtoGuias_Envio_Prefactura
            '
            Me.dvListar_guias.RowFilter = "SELECCIONAR =0 or SELECCIONAR=1"


            For i As Integer = 0 To Me.dvListar_guias.Count - 1
                If Me.dvListar_guias.Table.Rows(i)("SELECCIONAR") = 1 Then
                    P_CANTIDAD = P_CANTIDAD + Me.dvListar_guias.Table.Rows(i)("CANTIDAD")
                    P_TOTAL_PESO = P_TOTAL_PESO + Me.dvListar_guias.Table.Rows(i)("TOTAL_PESO")
                    P_TOTAL_VOLUMEN = P_TOTAL_VOLUMEN + Me.dvListar_guias.Table.Rows(i)("TOTAL_VOLUMEN")
                    P_TOTAL_COSTO = P_TOTAL_COSTO + Me.dvListar_guias.Table.Rows(i)("TOTAL_COSTO")
                    P_MONTO_IMPUESTO = P_MONTO_IMPUESTO + Me.dvListar_guias.Table.Rows(i)("MONTO_IMPUESTO")
                    P_CANTIDAD_X_UNIDAD_VOLUMEN = P_CANTIDAD_X_UNIDAD_VOLUMEN + Me.dvListar_guias.Table.Rows(i)("CANTIDAD_X_UNIDAD_VOLUMEN")
                    P_CANTIDAD_X_UNIDAD_ARTI = P_CANTIDAD_X_UNIDAD_ARTI + Me.dvListar_guias.Table.Rows(i)("CANTIDAD_X_UNIDAD_ARTI")
                End If
            Next

            If P_TOTAL_COSTO = 0 Then
                MsgBox("El Costo Total no puede ser cero, verifique sus datos", MsgBoxStyle.Information, "Titan")
                Exit Sub
            End If

            P_MONTO_IMPUESTO = CDbl(TXTIMPUESTO.Text)
            P_TOTAL_COSTO = CDbl(txtSumatoriaMonto.Text)

            'hlamas 24-03-2017
            If Me.cboTipoAfectacion.SelectedIndex > 1 Then
                P_MONTO_IMPUESTO = 0
            End If

            Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

            With ObjFactura
                .CANTIDAD_X_UNIDAD_ARTI = P_CANTIDAD_X_UNIDAD_ARTI
                .CANTIDAD_X_UNIDAD_VOLUMEN = P_CANTIDAD_X_UNIDAD_VOLUMEN

                .IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
                .IDESTADO_ENVIO = 19
                .IDESTADO_FACTURA = 1
                '.IDCIUDAD_TRANSITO=VOCONTROLUSUARIO
                .CANTIDAD = P_CANTIDAD
                .TOTAL_PESO = P_TOTAL_PESO
                .TOTAL_VOLUMEN = P_TOTAL_VOLUMEN
                .IDGUIA_TRANSPORTISTA = 0
                .IDGUIA_TRANSPORTISTA_UPD = 0
                .IDUNIDAD_ORIGEN = 0
                .IDUNIDAD_DESTINO = 0
                .IDDIREECION_ORIGEN = 0
                .IDDIREECION_DESTINO = 0
                .MONTO_TIPO_CAMBIO = 3.33 'VOCONTROLUSUARIO
                .IDTIPO_MONEDA = Me.cbidtipo_moneda.SelectedValue
                .FECHA = Me.DTPFECHA.Value.ToShortDateString
                .FECHA_VENCIMIENTO = Me.DTPFECHA_VENCIMIENTO.Value.ToShortDateString
                .IDPERSONA_ORIGEN = 0
                .IDPERSONA_DESTINO = 0
                .IDPERSONA = ObjPersona.IDPERSONA
                .IDTIPO_COMPROBANTE = 1 'FACTURA
                .MONTO_IMPUESTO = P_MONTO_IMPUESTO
                .TOTAL_COSTO = P_TOTAL_COSTO
                .IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia '1 'VOCONTROLUSUARIO
                .IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                .IP = dtoUSUARIOS.IP
                .IDROL_USUARIO = dtoUSUARIOS.IdRol
                .Producto = Me.cmbProducto.SelectedValue
                .TipoAfectacion = Me.cboTipoAfectacion.SelectedIndex
                'datahelper
                'If .FNINUPDE_FACTURA(cnn) = True Then
                If .FNINUPDE_FACTURA() = True Then
                    For i As Integer = 0 To Me.dvListar_guias.Count - 1
                        If dvListar_guias.Table.Rows(i)("SELECCIONAR") = 1 Then
                            ObjGuias_Envio_Prefactura.IDFACTURA = ObjFactura.IDFACTURA
                            ObjGuias_Envio_Prefactura.IDGUIAS_ENVIO = dvListar_guias.Table.Rows(i)("IDGUIAS_ENVIO")
                            ObjGuias_Envio_Prefactura.IDROL_USUARIO = dtoUSUARIOS.IdRol
                            ObjGuias_Envio_Prefactura.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                            ObjGuias_Envio_Prefactura.IP = dtoUSUARIOS.IP
                            'datahelper
                            'ObjGuias_Envio_Prefactura.fnCOMPROMETER_GUIAS_FACTU(VOCONTROLUSUARIO, cnn)
                            ObjGuias_Envio_Prefactura.fnCOMPROMETER_GUIAS_FACTU()
                        End If
                    Next
                    Me.dvListar_guias.RowFilter = "SELECCIONAR=1"
                    MsgBox("Los datos se grabaron satisfactoriamente con el id: " & Str(ObjFactura.IDFACTURA), MsgBoxStyle.Information, "Titan")

                End If
                Call mostrar_guias()
                DGV2.DataSource = Nothing
            End With


        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try

    End Sub




    Private Sub listar_facturas()
        Try


            Dim ObjFactura As New ClsLbTepsa.dtoFACTURA
            If Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                MsgBox("Seleccione un cliente", MsgBoxStyle.Information, "Titan")
                Exit Sub
            End If
            ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"
            ObjFactura.IDTIPO_MONEDA = Me.cbidtipo_moneda.SelectedValue
            'datahelper
            'dvListar_facturas = ObjFactura.FNLISTAR_FACTURAS(cnn)
            dvListar_facturas = ObjFactura.FNLISTAR_FACTURAS()
            FORMAT_GRILLA3()
            dgv4.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        listar_facturas()
        DGV3.Select()
    End Sub



    Sub FORMAT_GRILLA4()
        dgv4.Columns.Clear()

        With dgv4
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvfacturas_guias
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ReadOnly = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With


        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With


        Dim Col1 As New DataGridViewCheckBoxColumn
        With Col1
            .HeaderText = "SELECCIONAR"
            .Name = "SELECCIONAR"
            .DataPropertyName = "SELECCIONAR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            '.FlatStyle = FlatStyle.Standard
            '.CellTemplate = New DataGridViewCheckBoxCell()
            '.CellTemplate.Style.BackColor = Color.Beige
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "FECHA_GUIA"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .HeaderText = "NRO_GUIA"
            .Name = "NRO_GUIA"
            .DataPropertyName = "NRO_GUIA"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .HeaderText = "CANTIDAD"
            .Name = "CANTIDAD"
            .DataPropertyName = "CANTIDAD"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .HeaderText = "TOTAL_PESO"
            .Name = "TOTAL_PESO"
            .DataPropertyName = "TOTAL_PESO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .HeaderText = "TOTAL_VOLUMEN"
            .Name = "TOTAL_VOLUMEN"
            .DataPropertyName = "TOTAL_VOLUMEN"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col8 As New DataGridViewTextBoxColumn
        With col8
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col9 As New DataGridViewTextBoxColumn
        With col9
            .HeaderText = "IMPORTE_BRUTO"
            .Name = "IMPORTE_BRUTO"
            .DataPropertyName = "IMPORTE_BRUTO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col10 As New DataGridViewTextBoxColumn
        With col10
            .HeaderText = "IMPORTE_IGV"
            .Name = "IMPORTE_IGV"
            .DataPropertyName = "IMPORTE_IGV"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim Col11 As New DataGridViewTextBoxColumn
        With Col11
            .HeaderText = "TOTAL_COSTO"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim Col12 As New DataGridViewTextBoxColumn
        With Col12
            .HeaderText = "CONSIGNADO"
            .Name = "CONSIGNADO"
            .DataPropertyName = "CONSIGNADO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim Col13 As New DataGridViewTextBoxColumn
        With Col13
            .HeaderText = "ESTADO_REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim Col14 As New DataGridViewCheckBoxColumn
        With Col14
            .HeaderText = "SELECCIONAR"
            .Name = "SELECCIONAR"
            .DataPropertyName = "SELECCIONAR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            '.FlatStyle = FlatStyle.Standard
            '.CellTemplate = New DataGridViewCheckBoxCell()
            '.CellTemplate.Style.BackColor = Color.Beige
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        With dgv4
            .Columns.AddRange(col0, Col1, col2, col3, col4, col5, col6, col7, col8, col9, col10, Col11, Col12, Col13, Col14)
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(12).Visible = False

            .Columns(0).Visible = False
            .Columns(3).Visible = False
            .Columns(8).Visible = False
            .Columns(13).Visible = False
            .Columns(14).Visible = False
        End With
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
            .DataSource = dvListar_facturas
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ReadOnly = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim Col0 As New DataGridViewCheckBoxColumn
        With Col0
            .HeaderText = "SELECCIONAR"
            .Name = "SELECCIONAR"
            .DataPropertyName = "SELECCIONAR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            '.FlatStyle = FlatStyle.Standard
            '.CellTemplate = New DataGridViewCheckBoxCell()
            '.CellTemplate.Style.BackColor = Color.Beige
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = "SERIE"
            .Name = "SERIE"
            .DataPropertyName = "SERIE_FACTURA"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "NRO."
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "FECHA"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .HeaderText = "SUB TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .HeaderText = "IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .HeaderText = "TOTAL"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .HeaderText = "TOTAL_VOLUMEN"
            .Name = "TOTAL_VOLUMEN"
            .DataPropertyName = "TOTAL_VOLUMEN"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col8 As New DataGridViewTextBoxColumn
        With col8
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "FORMA_PAGO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col9 As New DataGridViewTextBoxColumn
        With col9
            .HeaderText = "SUB TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
        End With

        Dim col10 As New DataGridViewTextBoxColumn
        With col10
            .HeaderText = "IMPORTE_IGV"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Name = "IMPORTE_IGV"
            .DataPropertyName = "IMPORTE_IGV"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
        End With

        Dim Col11 As New DataGridViewTextBoxColumn
        With Col11
            .HeaderText = "TOTAL_COSTO"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim Col12 As New DataGridViewTextBoxColumn
        With Col12
            .HeaderText = "CONSIGNADO"
            .Name = "CONSIGNADO"
            .DataPropertyName = "CONSIGNADO"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim Col13 As New DataGridViewTextBoxColumn
        With Col13
            .HeaderText = "ESTADO_REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim Col14 As New DataGridViewCheckBoxColumn
        With Col14
            .HeaderText = "SELECCIONAR"
            .Name = "SELECCIONAR"
            .DataPropertyName = "SELECCIONAR"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            '.FlatStyle = FlatStyle.Standard
            '.CellTemplate = New DataGridViewCheckBoxCell()
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.CellTemplate.Style.BackColor = Color.Beige
        End With

        Dim Col15 As New DataGridViewTextBoxColumn
        With Col15
            .HeaderText = "APLICADO"
            .Name = "APLICADO"
            .DataPropertyName = "APLICADO"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim Col16 As New DataGridViewTextBoxColumn
        With Col16
            .HeaderText = "TIPO"
            .Name = "TIPO"
            .DataPropertyName = "TIPO"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col_idtipo_afectacion As New DataGridViewTextBoxColumn
        With col_idtipo_afectacion
            .Name = "tipo_afectacion"
            .DataPropertyName = "tipo_afectacion"
            .HeaderText = "tipo_afectacion"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With

        Dim col_tipo_afectacion As New DataGridViewTextBoxColumn
        With col_tipo_afectacion
            .Name = "tipo_afectacion_2"
            .DataPropertyName = "tipo_afectacion_2"
            .HeaderText = "TIPO AFECTACION"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        With DGV3
            .Columns.AddRange(Col0, col1, col2, col3, col4, col5, col6, col7, col8, col9, col10, Col11, Col12, Col13, Col14, Col15, Col16, col_idtipo_afectacion, col_tipo_afectacion)
            .Columns(5).Visible = True
            .Columns(6).Visible = True
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False

            .Columns(0).Visible = False
            .Columns(3).Visible = True
            .Columns(8).Visible = False
            .Columns(13).Visible = True
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            .Columns(16).Visible = False

            .Columns(17).Visible = False
            .Columns(18).Visible = True
        End With
    End Sub
    Private Sub DGV3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellEnter
        Try
            Dim obj As New ClsLbTepsa.dtoFACTURA
            With obj
                .IDFACTURA = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDFACTURA")
                'datahelper
                'dvfacturas_guias = .FNFACTURAS_GUIAS(VOCONTROLUSUARIO)
                dvfacturas_guias = .FNFACTURAS_GUIAS()
                Call FORMAT_GRILLA4()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Sub FORMAT_GRILLA5()
        DGV5.Columns.Clear()

        With DGV5
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
            .ReadOnly = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .ReadOnly = True
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .ReadOnly = True
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With


        Dim SELECCIONAR As New DataGridViewCheckBoxColumn
        With SELECCIONAR
            .HeaderText = "SELECCIONAR"
            .Name = "SELECCIONAR"
            .DataPropertyName = "SELECCIONAR"
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.FlatStyle = FlatStyle.Standard
            '.CellTemplate = New DataGridViewCheckBoxCell()
            '.CellTemplate.Style.BackColor = Color.Beige
            .Width = 50
        End With


        Dim LIQUIDADO As New DataGridViewTextBoxColumn
        With LIQUIDADO
            .HeaderText = "LIUIDADO"
            .Name = "DESC_LIQUIDADO"
            .DataPropertyName = "DESC_LIQUIDADO"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With


        Dim FACTURADO As New DataGridViewTextBoxColumn
        With FACTURADO
            .HeaderText = "FACTURADO"
            .Name = "DESC_FACTURADO"
            .DataPropertyName = "DESC_FACTURADO"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Width = 100
        End With


        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUB_TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "NOMBRE_AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "LOGIN"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SERIE_GUIA_ENVIO As New DataGridViewTextBoxColumn
        With SERIE_GUIA_ENVIO
            .HeaderText = "SERIE_GUIA_ENVIO"
            .Name = "SERIE_GUIA_ENVIO"
            .DataPropertyName = "SERIE_GUIA_ENVIO"
            .Width = 30
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .DefaultCellStyle.NullValue = "000"
        End With
        Dim NRO_GUIA As New DataGridViewTextBoxColumn
        With NRO_GUIA
            .HeaderText = "NRO_GUIA"
            .Name = "NRO_GUIA"
            .DataPropertyName = "NRO_GUIA"
            .Width = 130
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim FECHA_GUIA As New DataGridViewTextBoxColumn
        With FECHA_GUIA
            .HeaderText = "FECHA_GUIA"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "MONTO_IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL_COSTO"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        With DGV5

            .Columns.AddRange(SELECCIONAR, ORIGEN, DESTINO, RAZON_SOCIAL, SERIE_GUIA_ENVIO, NRO_GUIA, FECHA_GUIA, FORMA_PAGO, SIMBOLO_MONEDA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, LIQUIDADO, FACTURADO)

        End With
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If DGV3.Rows.Count = 0 Then
                MsgBox("Seleccione una factura para anular", MsgBoxStyle.Information, "Titan")
                Exit Sub
            End If
            If IsNothing(DGV3.CurrentCell) Then
                MsgBox("Seleccione una factura para anular", MsgBoxStyle.Information, "Titan")
                Exit Sub
            End If
            If Me.dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDESTADO_FACTURA") = 2 Then
                MsgBox("La factura ya esta anulada", MsgBoxStyle.Information, "Titan")
                Exit Sub
            End If
            If Me.dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("APLICADO") = 1 Then
                MsgBox("La Factura ya está Aplicada", MsgBoxStyle.Information, "Titan")
                Exit Sub
            End If
            If Me.dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("n_emife") = 0 Then 'si comprobante no tiene CDR
                Dim strFecha As String = DateAdd(DateInterval.Day, 1, Me.dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("fecha"))
                Dim strFechaServidor As String = FechaServidor(1)
                Dim dias As Long = DateDiff(DateInterval.Day, CType(strFecha, Date), CType(strFechaServidor, Date))
                If dias > 3 Then 'comprobante sin CDR excede plazo de anulacion por baja
                    MessageBox.Show("La Factura excede Plazo de Anulación (3 dias)", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            End If

            If MsgBox("¿Está Seguro de Anular la Factura?", MsgBoxStyle.YesNo, "Titan") = MsgBoxResult.No Then Exit Sub
            Dim strMotivo As String = ""
            Dim obj As New ClsLbTepsa.dtoFACTURA
            With obj
                .IDFACTURA = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDFACTURA")
                .IDROL_USUARIOMOD = dtoUSUARIOS.IdRol   'CAMBIAR ESTATICO
                .IDUSUARIO_PERSONALMOD = dtoUSUARIOS.IdLogin  'CAMBIAR ESTATICO
                .IPMOD = dtoUSUARIOS.IP  'CAMBIAR ESTATICO
                'datahelper
                '.FNANU_FACTURAS_GUIAS(VOCONTROLUSUARIO)

                'hlamas 01-06-2016
                'Valida si comprobante puede ser anulado                
                If DGV3.CurrentRow.Cells("TIPO").Value = 21 Then
                    Dim intOrigen As Integer = 0
                    Dim strFecha As String = DGV3.CurrentRow.Cells("fecha").Value
                    Dim strFechaServidor As String = FechaServidor(1)
                    Dim dias As Long = DateDiff(DateInterval.Day, CType(strFecha, Date), CType(strFechaServidor, Date))
                    If dias <= 3 Then 'validar si mes de comprobante es diferente a mes del sistema
                        If DatePart(DateInterval.Month, CDate(strFecha)) <> DatePart(DateInterval.Month, CDate(strFechaServidor)) Then
                            intOrigen = 1
                        End If
                    End If
                    If intOrigen = 1 Then
                        Cursor = Cursors.Default
                        MessageBox.Show("La Factura no puede ser anulada. El mes de la factura es menor al mes actual" & Chr(13) & "Para Anularla emita una Nota de Crédito", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                    Dim frm As New frmMotivoAnulacion
                    frm.ShowDialog()
                    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                        strMotivo = frm.txtMotivo.Text.Trim()
                        If Me.dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("n_emife") = 1 Then 'valida solo si comprobante fue enviado
                            Dim strTipo As String = "01"
                            'Dim strFecha As String = DGV3.CurrentRow.Cells("fecha").Value
                            'Dim strSerie As String = "F" & DGV3.CurrentRow.Cells("serie").Value
                            Dim strSerie As String = DGV3.CurrentRow.Cells("serie").Value
                            Dim strNumero As String = DGV3.CurrentRow.Cells("NRO_FACTURA").Value
                            strNumero = strNumero.PadLeft(8, "0")
                            Dim blnAnulable As Boolean = FEManager.isAvoidable(strTipo, strFecha, strSerie, strNumero, strMotivo)
                            If Not blnAnulable Then
                                Cursor = Cursors.Default
                                MessageBox.Show("La Factura no puede ser Anulada F.E.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return
                            End If
                        Else
                            Cursor = Cursors.Default
                            MessageBox.Show("La Factura no puede ser Anulada", "Antes de Anularlo, envielo a SUNAT", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return
                        End If
                    Else
                        Return
                    End If
                End If
                .Motivo = strMotivo
                .FNANU_FACTURAS_GUIAS()
            End With
            MsgBox("La factura se anuló con éxito", MsgBoxStyle.Information, "Titan")
            Call listar_facturas()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Dim OBJ As New ClsLbTepsa.dtoFACTURA

            With OBJ
                If DGV5.Rows.Count = 0 Then
                    MsgBox("Seleccione una guia para agregar", MsgBoxStyle.Information, "Titan")
                    Exit Sub
                End If
                If DGV3.Rows.Count = 0 Then
                    MsgBox("Seleccione una factura", MsgBoxStyle.Information, "Titan")
                    Exit Sub
                End If
                If IsNothing(DGV3.CurrentCell) Then
                    MsgBox("Seleccione una factura", MsgBoxStyle.Information, "Titan")
                    Exit Sub
                End If
                If MsgBox("Esta seguro de Agregar esta factura", MsgBoxStyle.YesNo, "Titan") = MsgBoxResult.No Then Exit Sub
                For i As Integer = 0 To dvListar_guias.Count - 1
                    If Me.dvListar_guias.Table.Rows(i)("SELECCIONAR") = 1 Then
                        .OPE = 2
                        .IDGUIAS_ENVIO = Me.dvListar_guias.Table.Rows(i)("IDGUIAS_ENVIO")
                        .IDFACTURA = Me.dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDFACTURA")
                        .IPMOD = dtoUSUARIOS.IP  'CAMBIAR ESTATICO
                        .IDUSUARIO_PERSONALMOD = dtoUSUARIOS.IdLogin  'CAMBIAR ESTATICO
                        .IDROL_USUARIOMOD = dtoUSUARIOS.IdRol  'CAMBIAR ESTATICO
                        'datahelper
                        '.FNQUITAR_FACTURAS_GUIAS(VOCONTROLUSUARIO)
                        .FNQUITAR_FACTURAS_GUIAS()
                    End If
                Next
            End With
            With DGV3
                Dim counter As Integer
                counter = .CurrentRow.Index
                .FirstDisplayedScrollingRowIndex = .Rows(counter).Index
                listar_facturas()
                mostrar_guias()

                .Refresh()

                .CurrentCell = .Rows(counter).Cells(1)
                .Rows(counter).Selected = True

            End With
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim OBJ As New ClsLbTepsa.dtoFACTURA
            With OBJ
                If dgv4.Rows.Count = 0 Then
                    MsgBox("Seleccione una guia para quitar", MsgBoxStyle.Information, "Titan")
                    Exit Sub
                End If
                If dgv4.Rows.Count = 1 Then
                    MsgBox("No se puede quitar, necesariamente tiene que existir mínimo un registro", MsgBoxStyle.Information, "Titan")
                    Exit Sub
                End If
                If DGV3.Rows.Count = 0 Then
                    MsgBox("Seleccione una factura", MsgBoxStyle.Information, "Titan")
                    Exit Sub
                End If
                If IsNothing(DGV3.CurrentCell) Then
                    MsgBox("Seleccione una factura", MsgBoxStyle.Information, "Titan")
                    Exit Sub
                End If
                If MsgBox("Esta seguro de quitar esta factura", MsgBoxStyle.YesNo, "Titan") = MsgBoxResult.No Then Exit Sub
                For i As Integer = 0 To dvfacturas_guias.Count - 1
                    If Me.dvfacturas_guias.Table.Rows(i)("SELECCIONAR") = 1 Then
                        .OPE = 1
                        .IDGUIAS_ENVIO = Me.dvfacturas_guias.Table.Rows(i)("IDGUIAS_ENVIO")
                        .IDFACTURA = Me.dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDFACTURA")
                        .IPMOD = dtoUSUARIOS.IP 'CAMBIAR ESTATICO
                        .IDUSUARIO_PERSONALMOD = dtoUSUARIOS.IdLogin  'CAMBIAR ESTATICO
                        .IDROL_USUARIOMOD = dtoUSUARIOS.IdRol  'CAMBIAR ESTATICO
                        'datahelper
                        '.FNQUITAR_FACTURAS_GUIAS(VOCONTROLUSUARIO)
                        .FNQUITAR_FACTURAS_GUIAS()
                    End If
                Next
            End With
            With DGV3
                Dim counter As Integer
                counter = .CurrentRow.Index
                .FirstDisplayedScrollingRowIndex = .Rows(counter).Index
                listar_facturas()
                mostrar_guias()


                .Refresh()

                .CurrentCell = .Rows(counter).Cells(1)
                .Rows(counter).Selected = True

            End With
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try

    End Sub

    Private Sub DGV1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV1.CellMouseUp
        Dim objfactura As New ClsLbTepsa.dtoFACTURA
        Try

            If e.Button = Windows.Forms.MouseButtons.Left Then

                Dim a As DataRowView = Me.dvListar_guias.Item(Me.DGV1.CurrentRow.Index)

                If DGV1.CurrentCell.ColumnIndex <> 0 Then Exit Sub

                objfactura.IDGUIAS_ENVIO = dvListar_guias.Table.Rows(DGV1.CurrentRow.Index)("IDGUIAS_ENVIO")


                If dvListar_guias.Table.Rows(DGV1.CurrentRow.Index)("LIQUIDADO") = 0 Then
                    MsgBox("La Guia aun no esta liquidada...", MsgBoxStyle.Information, "Titan")
                    DGV1.RefreshEdit()
                    Exit Sub
                End If
                If dvListar_guias.Table.Rows(DGV1.CurrentRow.Index)("FACTURADO") = 1 Then
                    MsgBox("La Guia ya esta facturado...", MsgBoxStyle.Information, "Titan")
                    DGV1.RefreshEdit()
                    Exit Sub
                End If
                If a("SELECCIONAR") = 0 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 0 Then
                        dvListar_guias.Table.Rows(DGV1.CurrentRow.Index)("SELECCIONAR") = 1
                        DGV1.RefreshEdit()
                        CalcularSumatoriaMonto()
                        objfactura.SELECCIONAR_TO_FACTURA = 1
                        'datahelper
                        'objfactura.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)
                        objfactura.fn_UPDATE_SELEC_TO_FACTURA()
                        Exit Sub
                    End If
                End If

                If a("SELECCIONAR") = 1 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 1 Then

                        dvListar_guias.Table.Rows(DGV1.CurrentRow.Index)("SELECCIONAR") = 0
                        DGV1.RefreshEdit()
                        CalcularSumatoriaMonto()
                        objfactura.SELECCIONAR_TO_FACTURA = 0
                        'datahelper
                        'objfactura.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)
                        objfactura.fn_UPDATE_SELEC_TO_FACTURA()
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try
    End Sub
    Private Sub dgv5_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV5.CellMouseUp
        Try
            Dim objfactura As New ClsLbTepsa.dtoFACTURA

            If e.Button = Windows.Forms.MouseButtons.Left Then
                Dim a As DataRowView = Me.dvListar_guias.Item(Me.DGV5.CurrentRow.Index)
                If DGV5.CurrentCell.ColumnIndex <> 0 Then Exit Sub
                If dvListar_guias.Table.Rows(DGV5.CurrentRow.Index)("LIQUIDADO") = 0 Then
                    MsgBox("La Guia aun no esta liquidada...", MsgBoxStyle.Information, "Titan")
                    DGV5.RefreshEdit()
                    CalcularSumatoriaMonto()
                    Exit Sub
                End If
                If dvListar_guias.Table.Rows(DGV5.CurrentRow.Index)("FACTURADO") = 1 Then
                    MsgBox("La Guia ya esta facturado...", MsgBoxStyle.Information, "Titan")
                    DGV5.RefreshEdit()
                    CalcularSumatoriaMonto()
                    Exit Sub
                End If
                If a("SELECCIONAR") = 0 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 0 Then
                        dvListar_guias.Table.Rows(DGV5.CurrentRow.Index)("SELECCIONAR") = 1
                        DGV5.RefreshEdit()
                        CalcularSumatoriaMonto()
                        objfactura.IDGUIAS_ENVIO = Me.dvListar_guias.Table.Rows(DGV5.CurrentRow.Index)("idguias_envio")
                        objfactura.SELECCIONAR_TO_FACTURA = 0
                        'datahelper
                        'objfactura.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)
                        objfactura.fn_UPDATE_SELEC_TO_FACTURA()
                        Exit Sub
                    End If
                End If

                If a("SELECCIONAR") = 1 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 1 Then
                        dvListar_guias.Table.Rows(DGV5.CurrentRow.Index)("SELECCIONAR") = 0
                        DGV5.RefreshEdit()
                        CalcularSumatoriaMonto()
                        objfactura.IDGUIAS_ENVIO = Me.dvListar_guias.Table.Rows(DGV5.CurrentRow.Index)("idguias_envio")
                        objfactura.SELECCIONAR_TO_FACTURA = 0
                        'datahelper
                        'objfactura.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)
                        objfactura.fn_UPDATE_SELEC_TO_FACTURA()
                        Exit Sub
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try
    End Sub

    Private Sub DGV5_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV5.CellContentClick

    End Sub

    Private Sub dgv4_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv4.CellMouseUp
        Try

            If e.Button = Windows.Forms.MouseButtons.Left Then

                Dim a As DataRowView = Me.dvfacturas_guias.Item(Me.dgv4.CurrentRow.Index)

                If dgv4.CurrentCell.ColumnIndex <> 1 Then Exit Sub

                If a("SELECCIONAR") = 0 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 0 Then
                        dvfacturas_guias.Table.Rows(dgv4.CurrentRow.Index)("SELECCIONAR") = 1
                        dgv4.RefreshEdit()
                        Exit Sub
                    End If
                End If

                If a("SELECCIONAR") = 1 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 1 Then
                        dvfacturas_guias.Table.Rows(dgv4.CurrentRow.Index)("SELECCIONAR") = 0
                        dgv4.RefreshEdit()
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try
    End Sub
    Private Sub DGV3_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV3.CellMouseUp
        Try

            If e.Button = Windows.Forms.MouseButtons.Left Then

                Dim a As DataRowView = Me.dvListar_facturas.Item(Me.DGV3.CurrentRow.Index)

                If DGV3.CurrentCell.ColumnIndex <> 1 Then Exit Sub

                If a("SELECCIONAR") = 0 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 0 Then
                        dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("SELECCIONAR") = 1
                        DGV3.RefreshEdit()
                        Exit Sub
                    End If
                End If

                If a("SELECCIONAR") = 1 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 1 Then
                        dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("SELECCIONAR") = 0
                        DGV3.RefreshEdit()
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try
    End Sub



    Private Sub CHKLIQUI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CHKLIQUI.KeyPress
        If e.KeyChar = Chr(13) Then
            CHKFACTU.Focus()
        End If

    End Sub

    Private Sub CHKFACTU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKFACTU.CheckedChanged

    End Sub

    Private Sub CHKFACTU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CHKFACTU.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.dtpfecha_inicio.Focus()
        End If

    End Sub



    Private Sub chkTodos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            Me.Button1.Focus()
        End If
    End Sub

    Private Sub txtidpersona_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyUp
        If e.KeyCode = 13 Then
        End If
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAINICIOFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPFECHAFINALFACTURA.Focus()
        End If
    End Sub


    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            Button3.Focus()
        End If
    End Sub


    Private Sub txtidpersona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.LostFocus
        Try
            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                Me.txtidpersona.Text = ""
                Me.txtCodigoCliente.Text = ""
            Else
                If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                    With ObjPersona
                        .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                        .IDTIPO_PERSONA = 0
                        .CODIGO_CLIENTE = "NULL"
                        'datahelper
                        'ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, .IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                        ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                        Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                        Me.CHKLIQUI.Focus()
                    End With
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL

                    'datahelper
                    'ObjGeneral.fnL_CENTRO_COSTOS_PERSONAS(dvlistar_centro_costos_personas, Me.cbidcentro_costo, VOCONTROLUSUARIO, ObjPersona.IDPERSONA)
                    'ObjGeneral.fnL_CENTRO_COSTOS_PERSONAS(dvListar_Centro_Costos_personas_, Me.cbidcentro_costo_, VOCONTROLUSUARIO, ObjPersona.IDPERSONA)
                    ObjGeneral.fnL_CENTRO_COSTOS_PERSONAS(dvlistar_centro_costos_personas, Me.cbidcentro_costo, ObjPersona.IDPERSONA)
                    ObjGeneral.fnL_CENTRO_COSTOS_PERSONAS(dvListar_Centro_Costos_personas_, Me.cbidcentro_costo_, ObjPersona.IDPERSONA)

                Else
                    Me.txtCodigoCliente.Text = ""
                    Me.cbidcentro_costo.DataSource = Nothing
                    Me.cbidcentro_costo_.DataSource = Nothing
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub


    Private Sub dtpfecha_inicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpfecha_inicio.ValueChanged

    End Sub



    Private Sub DGV1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV1.KeyUp
        Try

            Dim objFACTURA As New ClsLbTepsa.dtoFACTURA

            If e.KeyCode = Keys.Space Then

                If DGV1.RowCount <= 0 Then Exit Sub

                Dim a As DataRowView = Me.dvListar_guias.Item(Me.DGV1.CurrentRow.Index)

                objFACTURA.IDGUIAS_ENVIO = dvListar_guias.Table.Rows(DGV1.CurrentRow.Index)("idguias_envio")

                If dvListar_guias.Table.Rows(DGV1.CurrentRow.Index)("LIQUIDADO") = 0 Then
                    MsgBox("La Guia aun no esta liquidada...", MsgBoxStyle.Information, "Titan")
                    DGV1.RefreshEdit()
                    Exit Sub
                End If
                If dvListar_guias.Table.Rows(DGV1.CurrentRow.Index)("FACTURADO") = 1 Then
                    MsgBox("La Guia ya esta facturado...", MsgBoxStyle.Information, "Titan")
                    DGV1.RefreshEdit()
                    Exit Sub
                End If
                If a("SELECCIONAR") = 0 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 0 Then
                        dvListar_guias.Table.Rows(DGV1.CurrentRow.Index)("SELECCIONAR") = 1
                        DGV1.RefreshEdit()
                        CalcularSumatoriaMonto()
                        objFACTURA.SELECCIONAR_TO_FACTURA = 1
                        'datahelper
                        'objFACTURA.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)
                        objFACTURA.fn_UPDATE_SELEC_TO_FACTURA()
                        Exit Sub
                    End If
                End If

                If a("SELECCIONAR") = 1 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 1 Then

                        dvListar_guias.Table.Rows(DGV1.CurrentRow.Index)("SELECCIONAR") = 0
                        DGV1.RefreshEdit()
                        CalcularSumatoriaMonto()
                        objFACTURA.SELECCIONAR_TO_FACTURA = 0
                        'datahelper
                        'objFACTURA.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)
                        objFACTURA.fn_UPDATE_SELEC_TO_FACTURA()
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try
    End Sub

    Private Sub DGV5_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV5.KeyUp
        Try
            Dim objfactura As New ClsLbTepsa.dtoFACTURA
            If e.KeyCode = Keys.Space Then
                If DGV5.RowCount <= 0 Then Exit Sub
                Dim a As DataRowView = Me.dvListar_guias.Item(Me.DGV5.CurrentRow.Index)
                'If DGV5.CurrentCell.ColumnIndex <> 0 Then Exit Sub
                If dvListar_guias.Table.Rows(DGV5.CurrentRow.Index)("LIQUIDADO") = 0 Then
                    MsgBox("La Guia aun no esta liquidada...", MsgBoxStyle.Information, "Titan")
                    DGV5.RefreshEdit()
                    CalcularSumatoriaMonto()
                    Exit Sub
                End If
                If dvListar_guias.Table.Rows(DGV5.CurrentRow.Index)("FACTURADO") = 1 Then
                    MsgBox("La Guia ya esta facturado...", MsgBoxStyle.Information, "Titan")
                    DGV5.RefreshEdit()
                    CalcularSumatoriaMonto()
                    Exit Sub
                End If
                If a("SELECCIONAR") = 0 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 0 Then
                        dvListar_guias.Table.Rows(DGV5.CurrentRow.Index)("SELECCIONAR") = 1
                        DGV5.RefreshEdit()
                        CalcularSumatoriaMonto()
                        objfactura.IDGUIAS_ENVIO = Me.dvListar_guias.Table.Rows(DGV5.CurrentRow.Index)("idguias_envio")
                        objfactura.SELECCIONAR_TO_FACTURA = 1
                        'datahelper
                        'objfactura.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)
                        objfactura.fn_UPDATE_SELEC_TO_FACTURA()
                        Exit Sub
                    End If
                End If

                If a("SELECCIONAR") = 1 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 1 Then
                        dvListar_guias.Table.Rows(DGV5.CurrentRow.Index)("SELECCIONAR") = 0
                        DGV5.RefreshEdit()
                        CalcularSumatoriaMonto()
                        objfactura.IDGUIAS_ENVIO = Me.dvListar_guias.Table.Rows(DGV5.CurrentRow.Index)("idguias_envio")
                        objfactura.SELECCIONAR_TO_FACTURA = 0
                        'datahelper
                        'objfactura.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)
                        objfactura.fn_UPDATE_SELEC_TO_FACTURA()
                        Exit Sub
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try
    End Sub


    Private Sub dgv4_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv4.KeyUp
        Try

            If e.KeyCode = Keys.Space Then
                If dgv4.RowCount <= 0 Then Exit Sub
                Dim a As DataRowView = Me.dvfacturas_guias.Item(Me.dgv4.CurrentRow.Index)



                If a("SELECCIONAR") = 0 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 0 Then
                        dvfacturas_guias.Table.Rows(dgv4.CurrentRow.Index)("SELECCIONAR") = 1
                        dgv4.RefreshEdit()
                        Exit Sub
                    End If
                End If

                If a("SELECCIONAR") = 1 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 1 Then
                        dvfacturas_guias.Table.Rows(dgv4.CurrentRow.Index)("SELECCIONAR") = 0
                        dgv4.RefreshEdit()
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try
    End Sub

    Private Sub BEli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEli.Click
        Try
            If DGV3.Rows.Count = 0 Then
                MsgBox("Seleccione una factura para Eliminar", MsgBoxStyle.Information, "Titan")
                Exit Sub
            End If
            If IsNothing(DGV3.CurrentCell) Then
                MsgBox("Seleccione una factura para Eliminar", MsgBoxStyle.Information, "Titan")
                Exit Sub
            End If
            If Not Me.dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDESTADO_FACTURA") = 2 Then
                MsgBox("La factura tiene que estar anulada", MsgBoxStyle.Information, "Titan")
                Exit Sub
            End If
            If Me.dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDESTADO_FACTURA") = 3 Then
                MsgBox("La factura ya esta Eliminada", MsgBoxStyle.Information, "Titan")
                Exit Sub
            End If

            If MsgBox("Esta seguro de Eliminar esta factura", MsgBoxStyle.YesNo, "Titan") = MsgBoxResult.No Then Exit Sub
            Dim obj As New ClsLbTepsa.dtoFACTURA
            With obj
                .IDFACTURA = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDFACTURA")
                .IDROL_USUARIOMOD = dtoUSUARIOS.IdRol   'CAMBIAR ESTATICO
                .IDUSUARIO_PERSONALMOD = dtoUSUARIOS.IdLogin  'CAMBIAR ESTATICO
                .IPMOD = dtoUSUARIOS.IP  'CAMBIAR ESTATICO
                'datahelper
                '.FNELI_FACTURAS_GUIAS(VOCONTROLUSUARIO)
                .FNELI_FACTURAS_GUIAS()
            End With
            MsgBox("La factura se Eliminó con éxito", MsgBoxStyle.Information, "Titan")
            Call listar_facturas()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        End Try
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            If Me.txtnroguiaenvio.Focused = True Then
                fn_selecciona_guia() '  Recupera guía
            Else
                SendKeys.Send("{Tab}")
            End If

            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Sub fn_selecciona_guia()
        Dim snro_guia As String
        Dim sliquidado As String
        Dim objfactura As New ClsLbTepsa.dtoFACTURA
        '
        Try
            If Me.txtnroguiaenvio.TextLength = 12 Then
                Me.txtnroguiaenvio.Text = "0" + Me.txtnroguiaenvio.Text
            Else
                Me.txtnroguiaenvio.Text = RellenoRight(13, Me.txtnroguiaenvio.Text)
            End If
            '
            snro_guia = Me.txtnroguiaenvio.Text
            Me.txtnroguiaenvio.Text = ""
            '
            '"NRO_GUIA"
            'SELECCIONAR
            '
            For i As Integer = 0 To Me.DGV1.RowCount - 1
                If Me.DGV1.Rows(i).Cells("NRO_GUIA").Value = snro_guia Then
                    'If IsDBNull(Me.DGV1.Rows(i).Cells("DESC_LIQUIDADO").Value) = True Then
                    '    sliquidado = ""
                    'Else
                    '    sliquidado = Me.DGV1.Rows(i).Cells("DESC_LIQUIDADO").Value
                    'End If
                    ''''''''''''''''''''''''''''''''''''''''''
                    'objfactura.IDGUIAS_ENVIO = dvListar_guias.Table.Rows(DGV1.CurrentRow.Index)("IDGUIAS_ENVIO")
                    objfactura.IDGUIAS_ENVIO = dvListar_guias.Table.Rows(Me.DGV1.Rows(i).Index)("IDGUIAS_ENVIO")
                    '
                    'If dvListar_guias.Table.Rows(DGV1.CurrentRow.Index)("LIQUIDADO") = 0 Then
                    If dvListar_guias.Table.Rows(Me.DGV1.Rows(i).Index)("LIQUIDADO") = 0 Then
                        MsgBox("La Guía aún no está liquidada...", MsgBoxStyle.Information, "Titan")
                        DGV1.RefreshEdit()
                        Exit Sub
                    End If
                    If dvListar_guias.Table.Rows(Me.DGV1.Rows(i).Index)("FACTURADO") = 1 Then
                        MsgBox("La Guía está facturada...", MsgBoxStyle.Information, "Titan")
                        DGV1.RefreshEdit()
                        Exit Sub
                    End If
                    dvListar_guias.Table.Rows(Me.DGV1.Rows(i).Index)("SELECCIONAR") = 1
                    DGV1.RefreshEdit()
                    objfactura.SELECCIONAR_TO_FACTURA = 1
                    'datahelper
                    'objfactura.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)
                    objfactura.fn_UPDATE_SELEC_TO_FACTURA()
                    CalcularSumatoriaMonto()
                    '''''''''''''''''''''''''''''''''''''''''''''
                    'If sliquidado = "LIQUIDADO" Then
                    '    Me.DGV1.Rows(i).Cells("SELECCIONAR").Value = 1
                    '    '
                    '    Me.dvListar_guias.Table.Rows(i)("seleccionar") = 1
                    '    objfactura.IDGUIAS_ENVIO = Me.dvListar_guias.Table.Rows(i)("idguias_envio")
                    '    objfactura.SELECCIONAR_TO_FACTURA = 1
                    '    objfactura.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)                        '
                    '    '
                    '    CalcularSumatoriaMonto()
                    'Else
                    '    MsgBox("Guía no está liquida", MsgBoxStyle.Information, "Facturación")
                    'End If
                    'Me.DGV1.Rows(i).Cells("SELECCIONAR").Value = 1
                    Me.DGV1.CurrentCell = Me.DGV1.Rows(i).Cells("SELECCIONAR")
                    Exit Sub
                End If
            Next
            MsgBox("Guía de envío no encontrada", MsgBoxStyle.Information, "Facturación")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub




    Private Sub SeleccionarTodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarTodosToolStripMenuItem.Click
        Try
            Dim objfactura As New ClsLbTepsa.dtoFACTURA
            For i As Integer = 0 To Me.dvListar_guias.Count - 1
                If dvListar_guias.Table.Rows(i)("liquidado") = 1 And dvListar_guias.Table.Rows(i)("facturado") = 0 Then
                    Me.dvListar_guias.Table.Rows(i)("SELECCIONAR") = 1
                    objfactura.IDGUIAS_ENVIO = Me.dvListar_guias.Table.Rows(i)("idguias_envio")
                    objfactura.SELECCIONAR_TO_FACTURA = 1
                    'datahelper
                    'objfactura.fn_UPDATE_SELEC_TO_FACTURA(VOCONTROLUSUARIO, cnn)
                    objfactura.fn_UPDATE_SELEC_TO_FACTURA()
                End If
            Next
            Me.DGV1.EndEdit()
            Me.CalcularSumatoriaMonto()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub



    Private Sub cmbProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProducto.SelectedIndexChanged
        'If IsReference(Me.cmbProducto.SelectedValue) Then Return
        'If cmbProducto.SelectedValue = 0 Then
        '    Me.Button1.Enabled = False
        'Else
        '    Me.Button1.Enabled = True
        'End If
        Me.DGV1.DataSource = Nothing
    End Sub

    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged

    End Sub

    Private Sub DGV1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellContentClick

    End Sub

    Private Sub cbidcentro_costo__SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidcentro_costo_.SelectedIndexChanged

    End Sub
    Private Sub FrmFacturas_MenuImprimir() Handles Me.MenuImprimir
        '##End Custom 16/05/2016 - jabanto (F.E.)
        'Dim obj As New Imprimir
        'ObjReport = New ClsLbTepsa.dtoFrmReport
        'Select Case Me.TabMante.SelectedIndex
        '    Case 2
        '        If DGV3.Rows.Count = 0 Then
        '            MsgBox("Seleccione una factura", MsgBoxStyle.Information, "Titan")
        '            Exit Sub
        '        End If
        '        If IsNothing(DGV3.CurrentCell) Then
        '            MsgBox("Seleccione una factura", MsgBoxStyle.Information, "Titan")
        '            Exit Sub
        '        End If
        '        Try

        '            Dim TOTAL_COSTO As Double
        '            Dim MONTO_IMPUESTO As Double
        '            Dim INTERES As Double

        '            TOTAL_COSTO = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("TOTAL_COSTO")
        '            MONTO_IMPUESTO = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("MONTO_IMPUESTO")
        '            INTERES = 100 * (MONTO_IMPUESTO) / (TOTAL_COSTO - MONTO_IMPUESTO)
        '            INTERES = Int(FormatNumber(INTERES, 2))

        '            If TOTAL_COSTO > 400 Then
        '                If MsgBox("Posiblemente esta factura este consideranda en la impresion la GLOSA DE DETRACCION" & Chr(13) & Chr(13) & " ¿DESEA IMPRIMIR LA GLOSA?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '                    glosa02 = "OPERACION SUJETA AL SISTEMA DE PAGO DE OPERACIONES TRIBUTARIAS BANCO DE " & vbCrLf & _
        '                              "LA NACION Nº 0019-002829. EXCLUIDOS DE RETENCION DEL 6% DE IGV POR SER  " & vbCrLf & _
        '                              "AGENTES DE RETENCION SEGUN ART. 10 C.T., R.S. 228-2012/SUNAT"
        '                Else
        '                    glosa02 = ""
        '                End If
        '            Else
        '                glosa02 = "EXCLUIDOS DE RETENCION DEL 6% DE IGV POR SER AGENTES DE RETENCION SEGUN " & _
        '                          "ART. 10 C.T., R.S. 228-2012/SUNAT"
        '            End If

        '            If glosa02 = "" Then
        '                If MsgBox("Desea imprimir glosa personalizada?", MsgBoxStyle.YesNo, "Titan...") = MsgBoxResult.Yes Then
        '                    Dim a As New FrmGlosaPersonalizada
        '                    Acceso.Asignar(a, Me.hnd)
        '                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
        '                        a.ShowDialog()
        '                        glosa02 = Glosa_Persona
        '                    Else
        '                        MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                        glosa02 = ""
        '                    End If

        '                End If
        '            End If

        '            '19-07-2010 hlamas
        '            Dim objFac As New ClsLbTepsa.dtoFACTURA
        '            Dim dt As DataTable = objFac.Facturacion(dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDFACTURA"))


        '            obj.Inicializar()
        '            'Dim sImpresora As String = obj.ObtieneImpresora(1, dtoUSUARIOS.IP)
        '            Dim sImpresora As String
        '            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0

        '            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
        '            Dim dt2 As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 1)
        '            If dt2.Rows.Count = 0 Then
        '                sImpresora = ""
        '            Else
        '                If IsDBNull(dt2.Rows(0).Item("impresora")) Then
        '                    sImpresora = ""
        '                Else
        '                    sImpresora = dt2.Rows(0).Item("impresora")
        '                    iTamaño = dt2.Rows(0).Item("tamano")
        '                    iSuperior = dt2.Rows(0).Item("superior")
        '                    Iizquierda = dt2.Rows(0).Item("izquierda")
        '                End If
        '            End If
        '            obj.Impresora = sImpresora
        '            obj.Superior = iSuperior
        '            obj.Izquierda = Iizquierda

        '            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
        '            'Dim iLong As Integer = 36
        '            Dim iLong As Integer = IIf(iTamaño = 0, 38, iTamaño)

        '            y = iLong * pagina + 4
        '            For Each row As DataRow In dt.Rows
        '                y += 1
        '                i += 1
        '                Dim direccion As String = "Av. Manuel Echeandia Nro.303 - San Luis - Lima - Lima"
        '                Dim sDoc As String = row("SERIE_FACTURA") & "-" & row("NRO_FACTURA")
        '                obj.EscribirLinea(y + 2, 10, direccion)
        '                obj.EscribirLinea(y + 1, 80, "Fact: " & sDoc)

        '                'Dim sDoc As String = row("SERIE_FACTURA") & "-" & row("NRO_FACTURA")
        '                'obj.EscribirLinea(y, 48, "Fact: " & sDoc)

        '                obj.EscribirLinea(y + 4, 8, row("DIA_FACTURA"))
        '                obj.EscribirLinea(y + 4, 23, row("MES_FACTURA"))
        '                obj.EscribirLinea(y + 4, 42, row("ANIO_FACTURA"))

        '                obj.EscribirLinea(y + 6, 13, IIf(IsDBNull(row("RAZON_SOCIAL")), "", row("RAZON_SOCIAL")))
        '                obj.EscribirLinea(y + 6, 66, IIf(IsDBNull(row("CODIGO_CLIENTE")), "", row("CODIGO_CLIENTE")))
        '                obj.EscribirLinea(y + 6, 105, IIf(IsDBNull(row("REFE")), "", row("REFE")))

        '                obj.EscribirLinea(y + 7, 13, cmbDireccion.Text)
        '                obj.EscribirLinea(y + 7, 105, IIf(IsDBNull(row("MEMO")), "", row("MEMO")))

        '                obj.EscribirLinea(y + 8, 66, IIf(IsDBNull(row("REMITENTE")), "", row("REMITENTE")))
        '                obj.EscribirLinea(y + 8, 46, IIf(IsDBNull(row("DESTINO")), "", row("DESTINO")))
        '                obj.EscribirLinea(y + 8, 66, IIf(IsDBNull(row("DIREC_REMI")), "", row("DIREC_REMI")))
        '                obj.EscribirLinea(y + 8, 105, IIf(IsDBNull(row("CONDI_PAGO")), "", row("CONDI_PAGO")))

        '                obj.EscribirLinea(y + 9, 13, IIf(IsDBNull(row("NRO_PREFACTURA")), "", row("NRO_PREFACTURA")))
        '                obj.EscribirLinea(y + 9, 66, IIf(IsDBNull(row("DIREC_DESTI")), "", row("DIREC_DESTI")))

        '                If Not IsDBNull(row("GLOSA")) Then
        '                    Dim glosa As String
        '                    glosa = row("GLOSA").ToString.Replace(Chr(13), "")
        '                    glosa = row("GLOSA").ToString.Replace(Chr(10), "")
        '                    glosa = glosa.Trim & Space(300 - glosa.Length)

        '                    'obj.EscribirLinea(y + 13, 0, glosa.Substring(0, 100))
        '                    'obj.EscribirLinea(y + 14, 0, glosa.Substring(100, 100))
        '                    'obj.EscribirLinea(y + 15, 0, glosa.Substring(201, 98))
        '                    'obj.EscribirLinea(y + 13, 16, glosa.Substring(0, 85))
        '                    'obj.EscribirLinea(y + 14, 16, glosa.Substring(85, 85))
        '                    'obj.EscribirLinea(y + 15, 16, glosa.Substring(170, 85))
        '                    'obj.EscribirLinea(y + 16, 16, glosa.Substring(255, 43))
        '                    obj.EscribirLinea(y + 13, 21, glosa.Substring(0, 72))
        '                    obj.EscribirLinea(y + 14, 21, glosa.Substring(72, 72))
        '                    obj.EscribirLinea(y + 15, 21, glosa.Substring(144, 72))
        '                    obj.EscribirLinea(y + 16, 21, glosa.Substring(216, 72))
        '                End If

        '                If glosa02.Trim.Length > 0 Then
        '                    glosa02 = glosa02.Replace(Chr(13), "")
        '                    glosa02 = glosa02.Replace(Chr(10), "")
        '                    glosa02 = glosa02.Trim & Space(300 - glosa02.Length)

        '                    'obj.EscribirLinea(y + 17, 0, glosa02.Substring(0, 100))
        '                    'obj.EscribirLinea(y + 18, 0, glosa02.Substring(100, 100))
        '                    'obj.EscribirLinea(y + 19, 0, glosa02.Substring(200, 100))
        '                    'obj.EscribirLinea(y + 17, 16, glosa02.Substring(0, 85))
        '                    'obj.EscribirLinea(y + 18, 16, glosa02.Substring(85, 85))
        '                    'obj.EscribirLinea(y + 19, 16, glosa02.Substring(170, 85))
        '                    obj.EscribirLinea(y + 17, 21, glosa02.Substring(0, 72))
        '                    obj.EscribirLinea(y + 18, 21, glosa02.Substring(72, 72))
        '                    obj.EscribirLinea(y + 19, 21, glosa02.Substring(144, 72))
        '                    'obj.EscribirLinea(y + 16, 21, glosa02.Substring(234, 64))
        '                End If

        '                obj.EscribirLinea(y + 13, 110, FormatNumber(row("SUB_TOTAL"), 2).PadLeft(10, " "))

        '                obj.EscribirLinea(y + 20, 21, "Son: " & ConvercionNroEnLetras(dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("TOTAL_COSTO")))
        '                obj.EscribirLinea(y + 21, 21, "S.E.U.O.")


        '                obj.EscribirLinea(y + 22, 83, dtoUSUARIOS.iIGV.ToString("0.00"))

        '                obj.EscribirLinea(y + 22, 105, "S/")
        '                obj.EscribirLinea(y + 23, 105, "S/")
        '                obj.EscribirLinea(y + 24, 105, "S/")

        '                obj.EscribirLinea(y + 22, 110, FormatNumber(row("SUB_TOTAL"), 2).PadLeft(10, " "))
        '                obj.EscribirLinea(y + 23, 110, FormatNumber(row("MONTO_IMPUESTO"), 2).PadLeft(10, " "))
        '                obj.EscribirLinea(y + 24, 110, FormatNumber(row("TOTAL_COSTO"), 2).PadLeft(10, " "))

        '                obj.EscribirLinea(y + 26, 54, row("FACTURADOR"))
        '            Next
        '            obj.Comprimido = True
        '            obj.Preliminar = True
        '            obj.Tamaño = iLong
        '            obj.Imprimir()
        '            obj.Finalizar()

        '            Dim frm As New FrmPreview
        '            frm.Documento = 1
        '            frm.Tamaño = iLong
        '            frm.Text = "Facturación Otros"
        '            frm.ShowDialog()

        '            Dim OBJFACTURA As New ClsLbTepsa.dtoFACTURA
        '            OBJFACTURA.IDFACTURA = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDFACTURA")
        '            OBJFACTURA.FN_ESTADO_IMPRESO()
        '            listar_facturas()
        '            mostrar_guias()

        '            Return
        '            ObjReport.rutaRpt = PathFrmReport
        '            ObjReport.conectar(rptservice, rptuser, rptpass)
        '            ObjReport.printrpt(False, "", "FAC001.RPT", "P_IDFACTURA;" & dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDFACTURA"), _
        '            "P_USUARIO;" & "", _
        '            "P_AGENCIA;" & "", _
        '            "P_FECHA_APERTURA;" & "", _
        '            "P_FECHA_CIERRE;" & "", _
        '            "P_MONTO_LETRAS;" & ConvercionNroEnLetras(dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("TOTAL_COSTO")), _
        '            "P_MENSAJE;" & "", _
        '            "P_IGV;" & INTERES, _
        '            "P_GLOSA02;" & glosa02, _
        '            "P_DIRECCION;" & cmbDireccion.Text, _
        '            "P_IMPRESO;" & "")
        '            'Dim OBJFACTURA As New ClsLbTepsa.dtoFACTURA
        '            'OBJFACTURA.IDFACTURA = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDFACTURA")
        '            'datahelper
        '            'OBJFACTURA.FN_ESTADO_IMPRESO(cnn)
        '            'OBJFACTURA.FN_ESTADO_IMPRESO()
        '            'listar_facturas()
        '            'mostrar_guias()
        '        Catch ex As Exception
        '            obj.Finalizar()
        '            MsgBox(ex.ToString, MsgBoxStyle.Information, "Titan")
        '        End Try
        'End Select
    End Sub
    Private Sub btnEmisionfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmisionfe.Click
        '-->####BEGIN 16/05/2016 - JABANTO
        Return
        Try
            If (DGV3.CurrentRow Is Nothing) Then
                MessageBox.Show("Debe de seleccionar una Factura", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            If (MessageBox.Show("¿Realmente esta seguro de emitir la Factura Electrónica?", "Emisión F.E.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                Me.Cursor = Cursors.WaitCursor

                Dim objFac As New ClsLbTepsa.dtoFACTURA
                Dim idFactura As Long = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDFACTURA")
                Dim dt As DataTable = objFac.Facturacion(idFactura)
                If (dt.Rows.Count = 0) Then
                    MessageBox.Show("El documento seleccionado no es válido.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                Dim row As DataRow = dt.Rows(0)


                Dim cliente As New FECliente
                cliente.tipoDocumentoID = 1 'ruc
                cliente.numeroDocumento = row("CODIGO_CLIENTE")
                cliente.nombres = row("RAZON_SOCIAL")
                cliente.direccion = row("DIRECCION_PERSONA")

                Dim venta As New FEVenta
                venta.TipoAfectacion = row("idtipo_afectacion")
                venta.cliente = cliente
                venta.isCredito = True
                venta.numeroSerie = row("SERIE_FACTURA")
                venta.numeroCorrelativo = row("NRO_FACTURA")
                venta.isMonedaSoles = True
                venta.fechaEmision = row("FECHA")
                venta.tipoComprobanteID = 1 'factura
                venta.opGravada = row("SUB_TOTAL")
                venta.igv = row("MONTO_IMPUESTO")
                venta.total = row("TOTAL_COSTO")
                venta.totalLetras = ConvercionNroEnLetras(row("TOTAL_COSTO"))
                venta.isSOUE = True
                venta.tipoVenta = FEManager.TIPO_VENTA_CREDITO
                venta.id = idFactura
                venta.tabla = "T_FACTURA"

                'Glosa Personalizada
                glosa02 = "" : Glosa_Persona = ""
                If MsgBox("¿Desea imprimir una glosa personalizada?", MsgBoxStyle.YesNo, "Titan") = MsgBoxResult.Yes Then
                    Dim a As New FrmGlosaPersonalizada
                    Acceso.Asignar(a, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        a.ShowDialog()
                        glosa02 = Glosa_Persona
                    Else
                        MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        glosa02 = ""
                    End If
                End If
                If (glosa02 = "") Then glosa02 = row("GLOSA")

                Dim detalleVenta As New FEDetalleVenta
                detalleVenta.descripcion = glosa02 'row("GLOSA")
                detalleVenta.cantidad = 1
                detalleVenta.tarifa = venta.total
                detalleVenta.unidadMedida = FEManager.SUNAT_UNIMED_UNIDAD

                Dim listaDetalle As New List(Of FEDetalleVenta)
                listaDetalle.Add(detalleVenta)
                venta.detalleVenta = listaDetalle

                glosa02 = ""
                '*******************************************************************
                '-->Detraccion
                If venta.total > FEManager.DETRACCION_MONTO_MAYOR_400 Then
                    If MsgBox("Posiblemente esta factura este considerando en la impresion la GLOSA DE DETRACCION" & Chr(13) & Chr(13) & " ¿DESEA IMPRIMIR LA GLOSA?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        glosa02 = FEManager.DETRACCION_GLOSA_MAYOR_400
                    Else
                        glosa02 = ""
                    End If
                Else
                    venta.glosaRetencion = FEManager.DETRACCION_GLOSA_MENOR_400
                End If
                If (glosa02 <> "") Then venta.glosaRetencion = glosa02

                'If glosa02 = "" Then
                '    If MsgBox("Desea imprimir glosa personalizada?", MsgBoxStyle.YesNo, "Titan...") = MsgBoxResult.Yes Then
                '        Dim a As New FrmGlosaPersonalizada
                '        Acceso.Asignar(a, Me.hnd)
                '        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                '            a.ShowDialog()
                '            glosa02 = Glosa_Persona
                '        Else
                '            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '            glosa02 = ""
                '        End If
                '    End If
                'End If
                'If (glosa02 <> "") Then venta.glosaRetencion = glosa02

                'Dim result = FEManager.result
                Dim result = FEManager.sendVentaSunat(venta, Nothing)
                If (result.IsCorrect) Then
                    objFac.actualizarEmisonFE(idFactura, "T_FACTURA")
                    Button3_Click(Nothing, Nothing)
                End If
                MessageBox.Show(result.Message, "Respuesta WSSunat", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Actualiza Glosa personalizada
                If Glosa_Persona.Trim.Length > 0 Then
                    Dim obj As New ClsLbTepsa.dtoFACTURA
                    obj.ActualizarGlosa(idFactura, Glosa_Persona)
                End If
            End If

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub DGV3_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV3.CurrentCellChanged
        '-->####BEGIN 17/05/2016 - JABANTO
        Try
            btnEmisionfe.Enabled = True
            Button4.Enabled = True
            Dim row As DataGridViewRow = DGV3.CurrentRow
            If Not (row Is Nothing) Then
                If (dvListar_facturas.Table.Rows(row.Index)("IDTIPO_COMPROBANTE") <> 21) Then '--> si es diferencinte de Factura
                    Button4.Enabled = False
                    btnEmisionfe.Enabled = False
                    Exit Sub
                ElseIf (dvListar_facturas.Table.Rows(row.Index)("IDESTADO_FACTURA") = 3 Or dvListar_facturas.Table.Rows(row.Index)("IDESTADO_FACTURA") = 2) Then
                    Button4.Enabled = False
                    btnEmisionfe.Enabled = False
                    Exit Sub
                ElseIf dvListar_facturas.Table.Rows(row.Index)("APLICADO") = 1 Then
                    Button4.Enabled = False
                    btnEmisionfe.Enabled = False
                    Exit Sub
                End If

                Dim idFactura As Long = dvListar_facturas.Table.Rows(row.Index)("IDFACTURA")
                For Each rowview As DataRowView In DGV3.DataSource
                    If (Convert.ToInt64(rowview.Row("idfactura")) = idFactura) Then
                        If (Convert.ToInt32(rowview.Row("n_emife")) = 1) Then
                            btnEmisionfe.Enabled = False
                            Exit For
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnEmisionfe.Enabled = False
        End Try
    End Sub

    Sub calculo_impuesto()
        Dim dblTotal As Double, dblSubtotal As Double, dblImpuesto As Double
        If Me.cboTipoAfectacion.SelectedIndex <= 1 Then
            Me.txtMontoFacturaFinal.Text = Me.txtSumatoriaMonto.Text
            Me.TXTSUB_TOTALFINAL.Text = Me.TXTSUB_TOTAL.Text
            Me.TXTIMPUESTOFINAL.Text = Me.TXTIMPUESTO.Text
        Else
            Me.txtMontoFacturaFinal.Text = Me.txtSumatoriaMonto.Text
            Me.TXTSUB_TOTALFINAL.Text = Me.txtSumatoriaMonto.Text
            Me.TXTIMPUESTOFINAL.Text = "0.00"
        End If
    End Sub

    Private Sub cboTipoAfectacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoAfectacion.SelectedIndexChanged
        calculo_impuesto()
    End Sub

    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellContentClick

    End Sub

    Private Sub DGV3_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.RowEnter

    End Sub
End Class

