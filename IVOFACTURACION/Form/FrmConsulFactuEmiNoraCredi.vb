Public Class FrmConsulFactuEmiNoraCredi

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
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        listar_facturas()
    End Sub
    Public Sub listar_facturas()
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
            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                ObjFactura.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            Else
                ObjFactura.IDAGENCIAS = 0
            End If

            If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            Else
                ObjFactura.IDFORMA_PAGO = 0
            End If
            'Datahelper
            dvListar_facturas = ObjFactura.FN_ConsulFactuEmi_movi_Nota_credi()
            FORMAT_GRILLA3()
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellContentClick

    End Sub

    Private Sub DGV3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellEnter
        Try
            Dim obj As New ClsLbTepsa.dtoFACTURA
            With obj
                .IDFACTURA = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDFACTURA")
                'dvfacturas_guias = .FNFACTURAS_GUIAS(VOCONTROLUSUARIO)
                dvfacturas_guias = .FNFACTURAS_GUIAS()
                '
            End With
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
            .DataSource = dvListar_facturas
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With


        Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
        With ANIO_FACTURA
            .HeaderText = "ANIO_FACTURA"
            .Name = "ANIO_FACTURA"
            .DataPropertyName = "ANIO_FACTURA"
            .Width = 4
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "CODIGO_CLIENTE"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            .Width = 20
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINATARIO As New DataGridViewTextBoxColumn
        With DESTINATARIO
            .HeaderText = "DESTINATARIO"
            .Name = "DESTINATARIO"
            .DataPropertyName = "DESTINATARIO"
            .Width = 182
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim DIA_FACTURA As New DataGridViewTextBoxColumn
        With DIA_FACTURA
            .HeaderText = "DIA_FACTURA"
            .Name = "DIA_FACTURA"
            .DataPropertyName = "DIA_FACTURA"
            .Width = 2
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
        With DIRECCION_PERSONA
            .HeaderText = "DIRECCION_PERSONA"
            .Name = "DIRECCION_PERSONA"
            .DataPropertyName = "DIRECCION_PERSONA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim DIREC_DESTI As New DataGridViewTextBoxColumn
        With DIREC_DESTI
            .HeaderText = "DIREC_DESTI"
            .Name = "DIREC_DESTI"
            .DataPropertyName = "DIREC_DESTI"
            .Width = 200
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIREC_REMI As New DataGridViewTextBoxColumn
        With DIREC_REMI
            .HeaderText = "DIREC_REMI"
            .Name = "DIREC_REMI"
            .DataPropertyName = "DIREC_REMI"
            .Width = 200
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DSCTO As New DataGridViewTextBoxColumn
        With DSCTO
            .HeaderText = "DSCTO"
            .Name = "DSCTO"
            .DataPropertyName = "DSCTO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 80
            .ReadOnly = True
        End With
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "ESTADO_REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
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

        Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        With TIPO_COMPROBANTE
            .HeaderText = "TIPO_COMPROBANTE"
            .Name = "TIPO_COMPROBANTE"
            .DataPropertyName = "TIPO_COMPROBANTE"
            .Width = 100
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
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn
        With IDAGENCIAS
            .HeaderText = "IDAGENCIAS"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim IDFACTURA As New DataGridViewTextBoxColumn
        With IDFACTURA
            .HeaderText = "IDFACTURA"
            .Name = "IDFACTURA"
            .DataPropertyName = "IDFACTURA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .Visible = False   'Agregado por omendoza 11/02/2007
        End With
        Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
        With IDFORMA_PAGO
            .HeaderText = "IDFORMA_PAGO"
            .Name = "IDFORMA_PAGO"
            .DataPropertyName = "IDFORMA_PAGO"
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
        With IDTIPO_MONEDA
            .HeaderText = "IDTIPO_MONEDA"
            .Name = "IDTIPO_MONEDA"
            .DataPropertyName = "IDTIPO_MONEDA"
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONAL
            .HeaderText = "IDUSUARIO_PERSONAL"
            .Name = "IDUSUARIO_PERSONAL"
            .DataPropertyName = "IDUSUARIO_PERSONAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim MEMO As New DataGridViewTextBoxColumn
        With MEMO
            .HeaderText = "MEMO"
            .Name = "MEMO"
            .DataPropertyName = "MEMO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim MES_FACTURA As New DataGridViewTextBoxColumn
        With MES_FACTURA
            .HeaderText = "MES_FACTURA"
            .Name = "MES_FACTURA"
            .DataPropertyName = "MES_FACTURA"
            .Width = 10
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "NRO_FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "ORIGEN"

            .ReadOnly = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim REFE As New DataGridViewTextBoxColumn
        With REFE
            .HeaderText = "REFE"
            .Name = "REFE"
            .DataPropertyName = "REFE"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim REMITENTE As New DataGridViewTextBoxColumn
        With REMITENTE
            .HeaderText = "REMITENTE"
            .Name = "REMITENTE"
            .DataPropertyName = "REMITENTE"
            .Width = 182
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
        With SERIE_FACTURA
            .HeaderText = "SERIE_FACTURA"
            .Name = "SERIE_FACTURA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "SERIE_FACTURA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "SIMBOLO_MONEDA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
        With NRO_PREFACTURA
            .HeaderText = "NRO_PREFACTURA"
            .Name = "NRO_PREFACTURA"
            .DataPropertyName = "NRO_PREFACTURA"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        'Creado por Omendoza 11-02-2007 
        Dim l_fecha_cargo As New DataGridViewTextBoxColumn
        With l_fecha_cargo
            .HeaderText = "Fecha Cargo"
            .Name = "fecha_cargo"
            .DataPropertyName = "fecha_cargo"
            '.Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            .Visible = True
            .ReadOnly = True
        End With
        '
        Dim l_fecha_vencimiento As New DataGridViewTextBoxColumn
        With l_fecha_vencimiento
            .HeaderText = "Fecha Vencimiento"
            .Name = "FECHA_VENCIMIENTO"
            .DataPropertyName = "FECHA_VENCIMIENTO"
            '.Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            .Visible = True
            .ReadOnly = True
        End With
        '
        Dim l_idpersona As New DataGridViewTextBoxColumn
        With l_idpersona
            .HeaderText = "IDPERSONA"
            .Name = "IDPERSONA"
            .DataPropertyName = "IDPERSONA"
            .Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
            .ReadOnly = True
        End With
        '
        Dim l_idestado_factura As New DataGridViewTextBoxColumn
        With l_idestado_factura
            .HeaderText = "idestado_factura"
            .Name = "idestado_factura"
            .DataPropertyName = "idestado_factura"
            .Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
            .ReadOnly = True
        End With

        Dim MES_CORRESPONDE As New DataGridViewTextBoxColumn
        With MES_CORRESPONDE
            .HeaderText = "Mes Corresponde"
            .Name = "mes_CORRESPONDE"
            .DataPropertyName = "mes_CORRESPONDE"
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With


        '
        With DGV3
            .Columns.AddRange(TIPO_COMPROBANTE, NOMBRE_AGENCIA, LOGIN, RAZON_SOCIAL, SERIE_FACTURA, NRO_FACTURA, MES_CORRESPONDE, FECHA, NRO_PREFACTURA, FORMA_PAGO, SIMBOLO_MONEDA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, ESTADO_REGISTRO, l_idpersona, l_idestado_factura, IDFACTURA, l_fecha_cargo, l_fecha_vencimiento)
        End With
    End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ShadowLabel1.Text = "Consulta de Facturas Emitidas/Notas Crédito"
        Me.MenuStrip1.Items(0).Visible = False
        Me.MenuStrip1.Items(1).Visible = False
        Me.MenuStrip1.Items(2).Visible = False
        Me.MenuStrip1.Items(3).Visible = False
        Me.MenuStrip1.Items(4).Visible = False
        Me.MenuStrip1.Items(5).Visible = False
        ''Mod.17/09/2009 -->Omendoza - Pasando al datahelper   
        'objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
        objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago)
        'Datahelper
        objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_moneda)
        'objgeneral.FN_cmb_Listar_agencias(CNN, Me.cmbAgencia)
        objgeneral.FN_cmb_Listar_agencias(Me.cmbAgencia)
        ObjPersona.CODIGO_CLIENTE = "NULL"
        ObjPersona.IDTIPO_PERSONA = 0
        ObjPersona.IDPERSONA = 0
        'DataHelper
        dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
        Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)
        '
        Me.cbidforma_pago.SelectedIndex = -1
        Me.cbidtipo_moneda.SelectedIndex = -1
        Me.cmbAgencia.SelectedIndex = -1
        Me.cmbUsuarios.SelectedIndex = -1
    End Sub

    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

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
            objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
        Else
            cmbUsuarios.DataSource = Nothing
        End If
        Me.cmbUsuarios.SelectedIndex = -1

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
                    If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                        ObjFactura.IDAGENCIAS = cmbAgencia.SelectedValue
                    Else
                        ObjFactura.IDAGENCIAS = 0
                    End If

                    If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                        ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
                    Else
                        ObjFactura.IDFORMA_PAGO = 0
                    End If
                    With ObjFactura

                        .IDFACTURA = Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("IDFACTURA")

                        'Try ObjReport.Dispose() Catch End Try ObjReport = New ClsLbTepsa.dtoFrmReport
                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)

                        Dim PREFACTURA As String


                        If Not Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index).IsNull("NRO_PREFACTURA") Then

                            If Not Trim(Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("NRO_PREFACTURA")) = "" Then
                                PREFACTURA = "Prefactura Nro.:" & Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("NRO_PREFACTURA")
                            Else
                                PREFACTURA = ""
                            End If
                        Else
                            PREFACTURA = ""
                        End If


                        ObjReport.printrptB(False, "", "FAC033.rpt", _
                        "p_idpersona;" & .IDPERSONA, _
                        "p_idforma_pago;" & .IDFORMA_PAGO, _
                        "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                        "p_idagencias;" & .IDAGENCIAS, _
                        "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                        "p_fecha_inicial;" & .FECHA_INICIO, _
                        "p_fecha_final;" & .FECHA_FINAL)


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

        DGV3.DataSource = Nothing
    End Sub

    Private Sub txtidpersona_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyUp
        If e.KeyCode = 13 Then
            If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                With ObjPersona
                    .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'datahelper
                    ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                    Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                    Me.DTPFECHAINICIOFACTURA.Focus()
                End With
                Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
            Else
                Me.txtCodigoCliente.Text = ""
            End If
        End If
    End Sub

    Private Sub txtidpersona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
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

                If ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                    Me.txtidpersona.Text = ObjPersona.RAZON_SOCIAL
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                    txtidpersona.Focus()
                Else
                    MsgBox("No existe el cliente", MsgBoxStyle.Information, "Segurdiad del Sistema")
                    Me.txtidpersona.Text = ""
                End If
            End If
        Catch EX As Exception
            MsgBox(EX.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub txtCodigoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged

    End Sub

    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAINICIOFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPFECHAFINALFACTURA.Focus()
        End If
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged

    End Sub

    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidtipo_moneda.Focus()
        End If
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged

    End Sub

    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_moneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_moneda.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidforma_pago.Focus()
        End If
    End Sub

    Private Sub cbidforma_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidforma_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidforma_pago.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbAgencia.Focus()
        End If
    End Sub

    Private Sub cmbUsuarios_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        DGV3.DataSource = Nothing
    End Sub


    Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUsuarios.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub
    Private Sub CargoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargoToolStripMenuItem.Click
        'Implementado por Omendoza 10-02-2007 
        'Rol (15) CREDITO Y COBRANZA
        Dim flag As Boolean
        Dim l_idpersona, l_idfactura, l_idestado_factura As Long
        Dim s_razon_social, s_serie_factura, s_nro_factura As String

        Try
            'bloque
            If Acceso.SiRol(G_Rol, Me, 1) Then
                'If fnValidar_Rol("15") Then
                flag = True
            End If
            If flag = False Then
                MsgBox("Usted no tiene Acceso", MsgBoxStyle.Information, "Seguridad Sistema")
                Exit Sub
            End If
            'Recuperando los datos 
            Dim dgrv0 As DataGridViewRow
            '
            dgrv0 = Me.DGV3.CurrentRow()
            l_idpersona = CType(dgrv0.Cells("IDPERSONA").Value, Long)
            l_idfactura = CType(dgrv0.Cells("IDFACTURA").Value, Long)
            s_razon_social = CType(dgrv0.Cells("RAZON_SOCIAL").Value, String)
            s_serie_factura = CType(dgrv0.Cells("SERIE_FACTURA").Value, String)
            s_nro_factura = CType(dgrv0.Cells("NRO_FACTURA").Value, String)
            l_idestado_factura = CType(dgrv0.Cells("idestado_factura").Value, Long)
            If l_idestado_factura = 2 Then
                MsgBox("La factura está anulada, no puede actualizar la fecha de cargo", MsgBoxStyle.Information, "Facturación")
                Exit Sub
            End If
            If l_idestado_factura = 3 Then
                MsgBox("La factura está eliminada, no puede actualizar la fecha de cargo", MsgBoxStyle.Information, "Facturación")
                Exit Sub
            End If
            '
            Dim a As New frmcargofactura
            a.txtcomprobante.Text = s_serie_factura + " - " + s_nro_factura
            a.txtidfactura.Text = l_idfactura
            a.txtrazon_social.Text = s_razon_social
            a.txtidpersona.Text = l_idpersona
            a.ShowDialog()
            If a.brefrescar Then
                listar_facturas()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub rbcobra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub rblistmovimensu_Enter(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub rbcobra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtCodigoCliente.GotFocus, _
    txtidpersona.GotFocus, _
    DTPFECHAINICIOFACTURA.GotFocus, _
    DTPFECHAFINALFACTURA.GotFocus, _
    cbidtipo_moneda.GotFocus, _
    cbidforma_pago.GotFocus, _
    cmbAgencia.GotFocus, _
    cmbUsuarios.GotFocus
        limpiar()
    End Sub
    Private Sub limpiar()

        DGV3.DataSource = Nothing

        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            txtCodigoCliente.Text = ""
            txtidpersona.Text = ""
        Else
            With ObjPersona
                .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                .IDTIPO_PERSONA = 0
                .CODIGO_CLIENTE = "NULL"
                'Datahelper
                ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
            End With
        End If
    End Sub



    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.TextChanged

    End Sub
End Class
