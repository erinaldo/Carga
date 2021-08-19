Public Class FrmConsulFactuGe
    Dim Pages As Integer

    Dim Page As Integer

    Dim dvidtipo_entrega As New DataView

    Dim dvfacturas_guias As New DataView
    Dim dvListar_facturas As New DataView

    Dim Colllistar_persona_todos As New Collection
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection

    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL

    Dim dvlistar_persona_todos As New DataView
    Dim dvlistar_tipo_moneda As New DataView

    Dim dvlistar_forma_pago As New DataView
    'Dim DT As New DataTable
    Private ObjReport As ClsLbTepsa.dtoFrmReport

    Dim ObjFactura As New ClsLbTepsa.dtoFACTURA
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub listar_facturas()
        Try
            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                ObjFactura.IDPERSONA = 0
            Else
                ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then
                ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString
                ObjFactura.FECHA_INICIO = "01/" + Format(CDate(ObjFactura.FECHA_INICIO), "MM/yyyy")
            Else
                ObjFactura.FECHA_INICIO = "NULL"
            End If
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then
                ObjFactura.FECHA_FINAL = "01/" + Format(CDate(Me.DTPFECHAFINALFACTURA.Value.ToShortDateString), "MM/yyyy")
                ObjFactura.FECHA_FINAL = DateAdd(DateInterval.Month, 1, CDate(ObjFactura.FECHA_FINAL))
                ObjFactura.FECHA_FINAL = DateAdd(DateInterval.Day, -1, CDate(ObjFactura.FECHA_FINAL))
            Else
                ObjFactura.FECHA_FINAL = "NULL"
            End If
            If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                ObjFactura.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
            Else
                ObjFactura.IDTIPO_COMPROBANTE = 0
            End If
            ObjFactura.IDTIPO_MONEDA = 0
            If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                ObjFactura.IDFUNCIONARIO_ACTUAL = Me.cmbUsuarios.SelectedValue
            Else
                ObjFactura.IDFUNCIONARIO_ACTUAL = 0
            End If

            'If Len(Me.tbnro_factura.Text.Trim) = 0 Then
            '    ObjFactura.NRO_FACTURA = 0
            'Else
            '    ObjFactura.NRO_FACTURA = Me.tbnro_factura.Text.Trim
            'End If
            'If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
            '    ObjFactura.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            'Else
            '    ObjFactura.IDAGENCIAS = 0
            'End If

            If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            Else
                ObjFactura.IDFORMA_PAGO = 0
            End If
            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                ObjFactura.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            Else
                ObjFactura.IDUNIDAD_ORIGEN = 0
            End If
            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                ObjFactura.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            Else
                ObjFactura.IDUNIDAD_DESTINO = 0
            End If

            If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                ObjFactura.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
            Else
                ObjFactura.IDTIPO_ENTREGA = 0
            End If

            Dim P_ENTRE As String

            'If Me.RBENTRE.Checked = True Then
            '    P_ENTRE = 1
            'ElseIf Me.RBSIN_ENTRE.Checked = True Then
            '    P_ENTRE = 0
            'Else
            '    P_ENTRE = 2
            'End If


            'ObjFactura.SP_L_VENTA_PAG(dt, cnn)

            'Datahelper
            dvListar_facturas = ObjFactura.SP_L_VENTA_PAG()

            'FORMAT_GRILLA3()
            'Me.txtsub_total.Text = 0
            'Me.txtmonto_impuesto.Text = 0
            'Me.txttotal_costo.Text = 0

            'For i As Integer = 0 To dvListar_facturas.Table.Rows.Count - 1
            '    'Me.txtsub_total.Text = Format(CDbl(Me.txtsub_total.Text) + dvListar_facturas.Table.Rows(i)("sub_total"), "###,###,###.00")
            '    'Me.txtmonto_impuesto.Text = Format(CDbl(Me.txtmonto_impuesto.Text) + dvListar_facturas.Table.Rows(i)("monto_impuesto"), "###,###,###.00")
            '    Me.txttotal_costo.Text = Format(CDbl(Me.txttotal_costo.Text) + dvListar_facturas.Table.Rows(i)("total_costo"), "###,###,###.00")
            '    Me.txtsub_total.Text = Format(CDbl(Me.txttotal_costo.Text) / 1.19, "###,###,###.00")
            '    Me.txtmonto_impuesto.Text = Format(CDbl(Me.txttotal_costo.Text) - CDbl(Me.txtsub_total.Text), "###,###,###.00")

            'Next

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub FrmConsulFactuGe_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulFactuGe_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    'Sub FORMAT_GRILLA3()
    '    DGV3.Columns.Clear()

    '    With DGV3
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False
    '        .AutoGenerateColumns = False
    '        .DataSource = dvListar_facturas
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .VirtualMode = True
    '        .RowHeadersVisible = True
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    End With


    '    Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
    '    With ANIO_FACTURA
    '        .HeaderText = "ANIO_FACTURA"
    '        .Name = "ANIO_FACTURA"
    '        .DataPropertyName = "ANIO_FACTURA"
    '        .Width = 4
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
    '    With CODIGO_CLIENTE
    '        .HeaderText = "CODIGO_CLIENTE"
    '        .Name = "CODIGO_CLIENTE"
    '        .DataPropertyName = "CODIGO_CLIENTE"
    '        .Width = 20
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DESTINATARIO As New DataGridViewTextBoxColumn
    '    With DESTINATARIO
    '        .HeaderText = "DESTINATARIO"
    '        .Name = "DESTINATARIO"
    '        .DataPropertyName = "DESTINATARIO"
    '        .Width = 182
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DESTINO As New DataGridViewTextBoxColumn
    '    With DESTINO
    '        .HeaderText = "DESTINO"
    '        .Name = "DESTINO"
    '        .DataPropertyName = "DESTINO"

    '        .ReadOnly = True
    '    End With
    '    Dim DIA_FACTURA As New DataGridViewTextBoxColumn
    '    With DIA_FACTURA
    '        .HeaderText = "DIA_FACTURA"
    '        .Name = "DIA_FACTURA"
    '        .DataPropertyName = "DIA_FACTURA"
    '        .Width = 2
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
    '    With DIRECCION_PERSONA
    '        .HeaderText = "DIRECCION_PERSONA"
    '        .Name = "DIRECCION_PERSONA"
    '        .DataPropertyName = "DIRECCION_PERSONA"

    '        .ReadOnly = True
    '    End With
    '    Dim DIREC_DESTI As New DataGridViewTextBoxColumn
    '    With DIREC_DESTI
    '        .HeaderText = "DIREC_DESTI"
    '        .Name = "DIREC_DESTI"
    '        .DataPropertyName = "DIREC_DESTI"
    '        .Width = 200
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DIREC_REMI As New DataGridViewTextBoxColumn
    '    With DIREC_REMI
    '        .HeaderText = "DIREC_REMI"
    '        .Name = "DIREC_REMI"
    '        .DataPropertyName = "DIREC_REMI"
    '        .Width = 200
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DSCTO As New DataGridViewTextBoxColumn
    '    With DSCTO
    '        .HeaderText = "DSCTO"
    '        .Name = "DSCTO"
    '        .DataPropertyName = "DSCTO"

    '        .ReadOnly = True
    '    End With
    '    Dim FECHA_SALIDA_G_T As New DataGridViewTextBoxColumn
    '    With FECHA_SALIDA_G_T
    '        .HeaderText = "FECHA G.T."
    '        .Name = "FECHA_SALIDA_G_T"
    '        .DataPropertyName = "FECHA_SALIDA_G_T"
    '        .Width = 80
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim FECHA_FACTURA As New DataGridViewTextBoxColumn
    '    With FECHA_FACTURA
    '        .HeaderText = "FECHA_FACTURA"
    '        .Name = "FECHA_FACTURA"
    '        .DataPropertyName = "FECHA_FACTURA"
    '        .Width = 80
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim FECHA_ENTREGA As New DataGridViewTextBoxColumn
    '    With FECHA_ENTREGA
    '        .HeaderText = "FECHA_ENTREGA"
    '        .Name = "FECHA_ENTREGA"
    '        .DataPropertyName = "FECHA_ENTREGA"
    '        .Width = 80
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim TIPO_ENTREGA As New DataGridViewTextBoxColumn
    '    With TIPO_ENTREGA
    '        .HeaderText = "TIPO_ENTREGA"
    '        .Name = "TIPO_ENTREGA"
    '        .DataPropertyName = "TIPO_ENTREGA"
    '        .Width = 100
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
    '    With TIPO_COMPROBANTE
    '        .HeaderText = "TIPO_COMPROBANTE"
    '        .Name = "TIPO_COMPROBANTE"
    '        .DataPropertyName = "TIPO_COMPROBANTE"
    '        .Width = 100
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim ESTADO_REGISTRO_ENVIO As New DataGridViewTextBoxColumn
    '    With ESTADO_REGISTRO_ENVIO
    '        .HeaderText = "EST. ENVIO."
    '        .Name = "ESTADO_REGISTRO_ENVIO"
    '        .DataPropertyName = "ESTADO_REGISTRO_ENVIO"
    '        .Width = 100
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
    '    With ESTADO_REGISTRO
    '        .HeaderText = "EST. REG."
    '        .Name = "ESTADO_REGISTRO"
    '        .DataPropertyName = "ESTADO_REGISTRO"
    '        .Width = 100
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim Nombre_Unidad_ORI As New DataGridViewTextBoxColumn
    '    With Nombre_Unidad_ORI
    '        .HeaderText = "Ori."
    '        .Name = "Nombre_Unidad"
    '        .DataPropertyName = "Nombre_Unidad"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim Nombre_Unidad_DESTI_G_T As New DataGridViewTextBoxColumn
    '    With Nombre_Unidad_DESTI_G_T
    '        .HeaderText = "Dest. G. T."
    '        .Name = "Nombre_Unidad_DESTINO_G_T"
    '        .DataPropertyName = "Nombre_Unidad_DESTINO_G_T"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim Nombre_Unidad_DESTI As New DataGridViewTextBoxColumn
    '    With Nombre_Unidad_DESTI
    '        .HeaderText = "Dest."
    '        .Name = "Nombre_Unidad_DESTINO"
    '        .DataPropertyName = "Nombre_Unidad_DESTINO"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
    '    With NOMBRE_AGENCIA
    '        .HeaderText = "NOMBRE_AGENCIA"
    '        .Name = "NOMBRE_AGENCIA_ORI"
    '        .DataPropertyName = "NOMBRE_AGENCIA_ORI"
    '        .Width = 100
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim FORMA_PAGO As New DataGridViewTextBoxColumn
    '    With FORMA_PAGO
    '        .HeaderText = "FORMA_PAGO"
    '        .Name = "FORMA_PAGO"
    '        .DataPropertyName = "FORMA_PAGO"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim IDAGENCIAS As New DataGridViewTextBoxColumn
    '    With IDAGENCIAS
    '        .HeaderText = "IDAGENCIAS"
    '        .Name = "IDAGENCIAS"
    '        .DataPropertyName = "IDAGENCIAS"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim IDFACTURA As New DataGridViewTextBoxColumn
    '    With IDFACTURA
    '        .HeaderText = "IDFACTURA"
    '        .Name = "IDFACTURA"
    '        .DataPropertyName = "IDFACTURA"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '        .Visible = True
    '    End With
    '    Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
    '    With IDFORMA_PAGO
    '        .HeaderText = "IDFORMA_PAGO"
    '        .Name = "IDFORMA_PAGO"
    '        .DataPropertyName = "IDFORMA_PAGO"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
    '    With IDTIPO_MONEDA
    '        .HeaderText = "IDTIPO_MONEDA"
    '        .Name = "IDTIPO_MONEDA"
    '        .DataPropertyName = "IDTIPO_MONEDA"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
    '    With IDUSUARIO_PERSONAL
    '        .HeaderText = "IDUSUARIO_PERSONAL"
    '        .Name = "IDUSUARIO_PERSONAL"
    '        .DataPropertyName = "IDUSUARIO_PERSONAL"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim MEMO As New DataGridViewTextBoxColumn
    '    With MEMO
    '        .HeaderText = "MEMO"
    '        .Name = "MEMO"
    '        .DataPropertyName = "MEMO"

    '        .ReadOnly = True
    '    End With
    '    Dim MES_FACTURA As New DataGridViewTextBoxColumn
    '    With MES_FACTURA
    '        .HeaderText = "MES_FACTURA"
    '        .Name = "MES_FACTURA"
    '        .DataPropertyName = "MES_FACTURA"
    '        .Width = 10
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
    '    With MONTO_IMPUESTO
    '        .HeaderText = "MONTO_IMPUESTO"
    '        .Name = "MONTO_IMPUESTO"
    '        .DataPropertyName = "MONTO_IMPUESTO"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim NRO_GUIA_TRANSPORTISTA_G_T As New DataGridViewTextBoxColumn
    '    With NRO_GUIA_TRANSPORTISTA_G_T
    '        .HeaderText = "NRO. G. T."
    '        .Name = "NRO_GUIA_TRANSPORTISTA_G_T"
    '        .DataPropertyName = "NRO_GUIA_TRANSPORTISTA_G_T"
    '        .Width = 100
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim NRO_FACTURA As New DataGridViewTextBoxColumn
    '    With NRO_FACTURA
    '        .HeaderText = "NRO_FACTURA"
    '        .Name = "NRO_FACTURA"
    '        .DataPropertyName = "NRO_FACTURA"
    '        .Width = 100
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim ORIGEN As New DataGridViewTextBoxColumn
    '    With ORIGEN
    '        .HeaderText = "ORIGEN"
    '        .Name = "ORIGEN"
    '        .DataPropertyName = "ORIGEN"

    '        .ReadOnly = True
    '    End With
    '    Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
    '    With RAZON_SOCIAL
    '        .HeaderText = "RAZON_SOCIAL"
    '        .Name = "RAZON_SOCIAL"
    '        .DataPropertyName = "RAZON_SOCIAL"
    '        .Width = 200
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim REFE As New DataGridViewTextBoxColumn
    '    With REFE
    '        .HeaderText = "REFE"
    '        .Name = "REFE"
    '        .DataPropertyName = "REFE"

    '        .ReadOnly = True
    '    End With
    '    Dim REMITENTE As New DataGridViewTextBoxColumn
    '    With REMITENTE
    '        .HeaderText = "REMITENTE"
    '        .Name = "REMITENTE"
    '        .DataPropertyName = "REMITENTE"
    '        .Width = 182
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
    '    With SERIE_FACTURA
    '        .HeaderText = "SERIE_FACTURA"
    '        .Name = "SERIE_FACTURA"
    '        .DataPropertyName = "SERIE_FACTURA"
    '        .Width = 30
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '        .Visible = False
    '    End With
    '    Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
    '    With SIMBOLO_MONEDA
    '        .HeaderText = "SIMBOLO_MONEDA"
    '        .Name = "SIMBOLO_MONEDA"
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
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim LOGIN As New DataGridViewTextBoxColumn
    '    With LOGIN
    '        .HeaderText = "LOGIN_FUNCIONARIO"
    '        .Name = "LOGIN"
    '        .DataPropertyName = "LOGIN_funcionario"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim NU_DOCU_SUNA As New DataGridViewTextBoxColumn
    '    With NU_DOCU_SUNA
    '        .HeaderText = "RUC"
    '        .Name = "NU_DOCU_SUNA"
    '        .DataPropertyName = "NU_DOCU_SUNA"
    '        .Width = 90
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
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
    '    Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
    '    With NRO_PREFACTURA
    '        .HeaderText = "NRO_PREFACTURA"
    '        .Name = "NRO_PREFACTURA"
    '        .DataPropertyName = "NRO_PREFACTURA"
    '        .Width = 100
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With

    '    With DGV3
    '        .Columns.AddRange(IDFACTURA, NU_DOCU_SUNA, RAZON_SOCIAL, LOGIN, NRO_FACTURA, FECHA_FACTURA, Nombre_Unidad_ORI, Nombre_Unidad_DESTI, TOTAL_COSTO)

    '    End With
    'End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Listado de Ventas Mensual"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False

            Dim dv_funcionar As New DataView

            Me.DTPFECHAINICIOFACTURA.Value = Now.Date.ToShortDateString
            Me.DTPFECHAFINALFACTURA.Value = Now.Date.ToShortDateString
            'datahelper
            'dv_funcionar = objgeneral.sp_L_funcionario_carga(cnn)

            'hlamas 06-01-2014
            'dv_funcionar = objgeneral.sp_L_funcionario_carga()
            'Me.cmbUsuarios.DataSource = dv_funcionar
            'Me.cmbUsuarios.DisplayMember = "usuario_personal"
            'Me.cmbUsuarios.ValueMember = "idusuario_personal"

            'datahelper
            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA)
            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA_DESTINO)
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA)
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA_DESTINO)

            'Mod.17/09/2009 -->Omendoza - Pasando al datahelper   
            'objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
            objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago)
            'dvlistar_forma_pago.RowFilter = "idforma_pago <> 2"
            cbidforma_pago.DataSource = dvlistar_forma_pago
            cbidforma_pago.DisplayMember = "FORMA_PAGO"
            cbidforma_pago.ValueMember = "IDFORMA_PAGO"
            ''Mod.17/09/2009 -->Omendoza - Pasando al datahelper   - No se considera el objeto VOCONTROLUSUARIO 
            'objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
            objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante)
            '
            dvlistar_forma_pago.RowFilter = "IDTIPO_COMPROBANTE = 1 or IDTIPO_COMPROBANTE = 3"

            'objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
            'objgeneral.FN_cmb_Listar_agencias(cnn, Me.cmbAgencia)
            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0

            'datahelper
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)

            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA)
            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA_DESTINO)
            ''Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
            objgeneral.fn_L_TIPO_ENTREGA(dvidtipo_entrega, Me.cbidtipo_entrega)
            '
            Me.cbidforma_pago.SelectedIndex = -1
            Me.cbidtipo_comprobante.SelectedIndex = -1
            'Me.cmbAgencia.SelectedIndex = -1
            Me.cmbUsuarios.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
            Me.cbidtipo_entrega.SelectedIndex = -1

            Dim obj As New dtoVentaCargaContado
            Dim dt1 As DataTable = obj.ListarProducto()
            With Me.CboTipoProducto
                .DataSource = dt1
                .ValueMember = "idprocesos"
                .DisplayMember = "procesos"
            End With

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.txtsub_total.Text = 0
        'Me.txtmonto_impuesto.Text = 0
        'Me.txttotal_costo.Text = 0
        'DGV3.DataSource = Nothing
    End Sub

    'Private Sub cmbAgencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = Chr(13) Then
    '        Me.cmbUsuarios.Focus()
    '    End If
    'End Sub




    'Private Sub cmbAgencia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim p_id_rol_usuario, p_idagencia As Int64
    '    p_id_rol_usuario = 0
    '    If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
    '        p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
    '        objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(cnn, Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
    '    Else
    '        cmbUsuarios.DataSource = Nothing
    '    End If
    '    Me.cmbUsuarios.SelectedIndex = -1

    'End Sub

    Private Sub FrmConsulFactuEmiti_MenuImprimir() Handles Me.MenuImprimir

        Select Case Me.TabMante.SelectedIndex
            Case 0
                Try
                    'If Me.DGV3.RowCount <= 0 Then
                    '    MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                    '    Exit Sub
                    'End If


                    If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                        ObjFactura.IDPERSONA = 0
                    Else

                        ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    End If

                    If Me.DTPFECHAINICIOFACTURA.Enabled = True Then
                        ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString
                        ObjFactura.FECHA_INICIO = "01/" + Format(CDate(ObjFactura.FECHA_INICIO), "MM/yyyy")
                    Else
                        ObjFactura.FECHA_INICIO = "NULL"
                    End If
                    If Me.DTPFECHAFINALFACTURA.Enabled = True Then
                        ObjFactura.FECHA_FINAL = "01/" + Format(CDate(Me.DTPFECHAFINALFACTURA.Value.ToShortDateString), "MM/yyyy")
                        ObjFactura.FECHA_FINAL = DateAdd(DateInterval.Month, 1, CDate(ObjFactura.FECHA_FINAL))
                        ObjFactura.FECHA_FINAL = DateAdd(DateInterval.Day, -1, CDate(ObjFactura.FECHA_FINAL))
                    Else
                        ObjFactura.FECHA_FINAL = "NULL"
                    End If


                    If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                        ObjFactura.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
                    Else
                        ObjFactura.IDTIPO_COMPROBANTE = 0
                    End If

                    ObjFactura.IDTIPO_MONEDA = 0

                    If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                        ObjFactura.IDFUNCIONARIO_ACTUAL = Me.cmbUsuarios.SelectedValue
                    Else
                        ObjFactura.IDFUNCIONARIO_ACTUAL = 0
                    End If
                    'If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                    '    ObjFactura.IDAGENCIAS = cmbAgencia.SelectedValue
                    'Else
                    '    ObjFactura.IDAGENCIAS = 0
                    'End If

                    If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                        ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
                    Else
                        ObjFactura.IDFORMA_PAGO = 0
                    End If
                    If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                        ObjFactura.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
                    Else
                        ObjFactura.IDUNIDAD_ORIGEN = 0
                    End If

                    If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                        ObjFactura.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
                    Else
                        ObjFactura.IDUNIDAD_DESTINO = 0
                    End If

                    'If Len(Me.tbnro_factura.Text.Trim) = 0 Then
                    '    ObjFactura.NRO_FACTURA = 0
                    'Else
                    '    ObjFactura.NRO_FACTURA = Me.tbnro_factura.Text.Trim
                    'End If

                    If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                        ObjFactura.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
                    Else
                        ObjFactura.IDTIPO_ENTREGA = 0
                    End If


                    If Me.CboTipoProducto.SelectedIndex = 0 Then
                        ObjFactura.Producto = -1
                    Else
                        ObjFactura.Producto = Me.CboTipoProducto.SelectedValue
                    End If

                    Dim P_ENTRE As String

                    'If Me.RBENTRE.Checked = True Then
                    '    P_ENTRE = 1
                    'ElseIf Me.RBSIN_ENTRE.Checked = True Then
                    '    P_ENTRE = 0
                    'Else
                    '    P_ENTRE = 2
                    'End If

                    With ObjFactura

                        '.IDFACTURA = Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("IDFACTURA")

                        Try
                            ObjReport.Dispose()
                        Catch
                        End Try
                        ObjReport = New ClsLbTepsa.dtoFrmReport
                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)

                        If Me.RBGENE.Checked = True Then
                            ObjReport.printrptB(False, "", "FAC016.RPT", _
                            "p_idpersona;" & .IDPERSONA, _
                            "p_idforma_pago;" & .IDFORMA_PAGO, _
                            "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
                            "p_fecha_ini;" & .FECHA_INICIO, _
                            "p_fecha_final;" & .FECHA_FINAL, _
                            "p_idfuncionario_actual;" & .IDFUNCIONARIO_ACTUAL, _
                            "p_idunidad_origen;" & .IDUNIDAD_ORIGEN, _
                            "p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
                            "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                            "P_IDTIPO_ENTREGA;" & .IDTIPO_ENTREGA, _
                            "ni_producto;" & .Producto)
                        Else
                            ObjReport.printrptB(False, "", "FAC013.RPT", _
                           "p_idpersona;" & .IDPERSONA, _
                           "p_idforma_pago;" & .IDFORMA_PAGO, _
                           "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
                           "p_fecha_ini;" & .FECHA_INICIO, _
                           "p_fecha_final;" & .FECHA_FINAL, _
                           "p_idfuncionario_actual;" & .IDFUNCIONARIO_ACTUAL, _
                           "p_idunidad_origen;" & .IDUNIDAD_ORIGEN, _
                           "p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
                           "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                           "P_IDTIPO_ENTREGA;" & .IDTIPO_ENTREGA, _
                            "ni_producto;" & .Producto)
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

    Private Sub txtidpersona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.GotFocus, _
    DTPFECHAINICIOFACTURA.GotFocus, _
    DTPFECHAFINALFACTURA.GotFocus, _
        cbidforma_pago.GotFocus, _
        cbidtipo_entrega.GotFocus, _
        CBIDUNIDAD_AGENCIA.GotFocus, _
        CBIDUNIDAD_AGENCIA_DESTINO.GotFocus, _
        cmbUsuarios.GotFocus


        'Me.txtsub_total.Text = 0
        'Me.txtmonto_impuesto.Text = 0
        'Me.txttotal_costo.Text = 0
        'DGV3.DataSource = Nothing
        Me.LPages.Text = ""
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
                        Me.DTPFECHAINICIOFACTURA.Focus()
                    End With

                Else
                    Me.txtCodigoCliente.Text = ""
                End If
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

    End Sub

    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.GotFocus
        'Me.txtsub_total.Text = 0
        'Me.txtmonto_impuesto.Text = 0
        'Me.txttotal_costo.Text = 0
        'DGV3.DataSource = Nothing
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

    'Private Sub tbnro_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = Chr(13) Then
    '        Me.cmbAgencia.Focus()
    '    End If
    'End Sub

    Private Sub txtCodigoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.LostFocus
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub



    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus
        'Me.txtsub_total.Text = 0
        'Me.txtmonto_impuesto.Text = 0
        'Me.txttotal_costo.Text = 0
        'DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAINICIOFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPFECHAFINALFACTURA.Focus()
        End If
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        'hlamas 06-01-2014
        Dim strFechaInicio As String = "01/" & Format(Me.DTPFECHAINICIOFACTURA.Value.Date.Month, "00") & "/" & Me.DTPFECHAINICIOFACTURA.Value.Date.Year
        Dim strFechaFin As String = Date.DaysInMonth(Me.DTPFECHAFINALFACTURA.Value.Date.Year, Me.DTPFECHAFINALFACTURA.Value.Date.Month) & "/" & Format(Me.DTPFECHAFINALFACTURA.Value.Date.Month, "00") & "/" & Me.DTPFECHAFINALFACTURA.Value.Date.Year
        ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cmbUsuarios, strFechaInicio, strFechaFin, 6)
    End Sub

    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.GotFocus
        'Me.txtsub_total.Text = 0
        'Me.txtmonto_impuesto.Text = 0
        'Me.txttotal_costo.Text = 0
        'DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidtipo_comprobante.Focus()
        End If
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        'hlamas 06-01-2014
        Dim strFechaInicio As String = "01/" & Format(Me.DTPFECHAINICIOFACTURA.Value.Date.Month, "00") & "/" & Me.DTPFECHAINICIOFACTURA.Value.Date.Year
        Dim strFechaFin As String = Date.DaysInMonth(Me.DTPFECHAFINALFACTURA.Value.Date.Year, Me.DTPFECHAFINALFACTURA.Value.Date.Month) & "/" & Format(Me.DTPFECHAFINALFACTURA.Value.Date.Month, "00") & "/" & Me.DTPFECHAFINALFACTURA.Value.Date.Year
        ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cmbUsuarios, strFechaInicio, strFechaFin, 6)
    End Sub

    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidtipo_comprobante.GotFocus
        'Me.txtsub_total.Text = 0
        'Me.txtmonto_impuesto.Text = 0
        'Me.txttotal_costo.Text = 0
        'DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_moneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_comprobante.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidforma_pago.Focus()
        End If
    End Sub

    Private Sub cbidforma_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidforma_pago.GotFocus
        'Me.txtsub_total.Text = 0
        'Me.txtmonto_impuesto.Text = 0
        'Me.txttotal_costo.Text = 0
        'DGV3.DataSource = Nothing
    End Sub

    'Private Sub cbidforma_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidforma_pago.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        Me.tbnro_factura.Focus()
    '    End If
    'End Sub

    'Private Sub cmbUsuarios_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUsuarios.GotFocus
    '    Me.txtsub_total.Text = 0
    '    Me.txtmonto_impuesto.Text = 0
    '    Me.txttotal_costo.Text = 0
    '    DGV3.DataSource = Nothing
    'End Sub


    'Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = Chr(13) Then
    '        Me.CBIDUNIDAD_AGENCIA.Focus()
    '    End If
    'End Sub


    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbidforma_pago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidforma_pago.SelectedIndexChanged

    End Sub

    Private Sub tbnro_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub CBIDUNIDAD_AGENCIA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_entrega.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        Me.CBIDUNIDAD_AGENCIA_DESTINO.Focus()
    '    End If
    'End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidtipo_entrega.SelectedIndexChanged

    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub
    Private Sub registros_cero()

    End Sub
    Private Sub move_first()
        ObjFactura.RAZON_SOCIAL = ""
        ObjFactura.PAGI = "F"
        listar_facturas()

        If dvListar_facturas.Count <= 0 Then
            cero_registros()
            Exit Sub
        End If

        dvListar_facturas.Sort = "RAZON_SOCIAL ASC"
        Pages = dvListar_facturas.Table.Rows(0)("pages")
        Page = 1
        Me.LPages.Text = Str(Page) + "/" + Str(Pages)

        'Me.txtsub_total.Text = FormatNumber(dvListar_facturas.Table.Rows(0)("sum_total_costo") / 1.19, 2)
        'Me.txtmonto_impuesto.Text = FormatNumber(dvListar_facturas.Table.Rows(0)("sum_total_costo") - dvListar_facturas.Table.Rows(0)("sum_total_costo") / 1.19, 2)
        'Me.txttotal_costo.Text = FormatNumber(dvListar_facturas.Table.Rows(0)("sum_total_costo"), 2)

    End Sub
    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        move_first()
    End Sub
    Private Sub move_last()
        ObjFactura.RAZON_SOCIAL = ""
        ObjFactura.PAGI = "L"
        listar_facturas()

        If dvListar_facturas.Count <= 0 Then
            cero_registros()
            Exit Sub
        End If

        dvListar_facturas.Sort = "RAZON_SOCIAL ASC"
        If Not dvListar_facturas.Count = 0 Then
            Pages = dvListar_facturas.Table.Rows(0)("pages")
        Else
            Pages = 0
        End If
        Page = Pages
        Me.LPages.Text = Str(Page) + "/" + Str(Pages)

        'Me.txtsub_total.Text = FormatNumber(dvListar_facturas.Table.Rows(0)("sum_total_costo") / 1.19, 2)
        'Me.txtmonto_impuesto.Text = FormatNumber(dvListar_facturas.Table.Rows(0)("sum_total_costo") - dvListar_facturas.Table.Rows(0)("sum_total_costo") / 1.19, 2)
        'Me.txttotal_costo.Text = FormatNumber(dvListar_facturas.Table.Rows(0)("sum_total_costo"), 2)

    End Sub
    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        move_last()
    End Sub
    Private Sub cero_registros()
        Page = 0
        Pages = 0
        Me.LPages.Text = Str(Page) + "/" + Str(Pages)

        'Me.txtsub_total.Text = 0
        'Me.txtmonto_impuesto.Text = 0
        'Me.txttotal_costo.Text = 0

    End Sub
    Private Sub move_previous()
        If dvListar_facturas.Count <= 0 Then
            cero_registros()
            Exit Sub
        End If

        ObjFactura.IDFACTURA = dvListar_facturas.Table.Rows(0)("IDFACTURA")
        For i As Integer = 0 To dvListar_facturas.Count - 1
            If dvListar_facturas.Table.Rows(i)("IDFACTURA") < ObjFactura.IDFACTURA Then
                ObjFactura.IDFACTURA = dvListar_facturas.Table.Rows(i)("IDFACTURA")
                ObjFactura.RAZON_SOCIAL = dvListar_facturas.Table.Rows(0)("RAZON_SOCIAL")
            End If
        Next
        'dvListar_facturas.RowFilter = "IDFACTURA = MAX(IDFACTURA)"
        'ObjFactura.RAZON_SOCIAL = dvListar_facturas.Table.Rows(dvListar_facturas.Count - 1)("RAZON_SOCIAL")
        'ObjFactura.IDFACTURA = dvListar_facturas.Table.Rows(dvListar_facturas.Count - 1)("IDFACTURA")
        ObjFactura.PAGI = "P"
        listar_facturas()


        dvListar_facturas.Sort = "RAZON_SOCIAL ASC"


        Page = Page - 1
        Me.LPages.Text = Str(Page) + "/" + Str(Pages)

        'If Not dvListar_facturas.Count <= 0 Then
        '    Me.txtsub_total.Text = FormatNumber(dvListar_facturas.Table.Rows(0)("sum_total_costo") / 1.19, 2)
        '    Me.txtmonto_impuesto.Text = FormatNumber(dvListar_facturas.Table.Rows(0)("sum_total_costo") - dvListar_facturas.Table.Rows(0)("sum_total_costo") / 1.19, 2)
        '    Me.txttotal_costo.Text = FormatNumber(dvListar_facturas.Table.Rows(0)("sum_total_costo"), 2)
        'End If

        If dvListar_facturas.Count <= 0 Then
            move_last()
        End If

    End Sub
    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        move_previous()
    End Sub
    Private Sub move_next()
        If dvListar_facturas.Count <= 0 Then
            cero_registros()
            Exit Sub
        End If
        ObjFactura.IDFACTURA = dvListar_facturas.Table.Rows(0)("IDFACTURA")
        For i As Integer = 0 To dvListar_facturas.Count - 1
            If dvListar_facturas.Table.Rows(i)("IDFACTURA") > ObjFactura.IDFACTURA Then
                ObjFactura.IDFACTURA = dvListar_facturas.Table.Rows(i)("IDFACTURA")
                ObjFactura.RAZON_SOCIAL = dvListar_facturas.Table.Rows(0)("RAZON_SOCIAL")
            End If
        Next
        'dvListar_facturas.RowFilter = "IDFACTURA = MAX(IDFACTURA)"
        'ObjFactura.RAZON_SOCIAL = dvListar_facturas.Table.Rows(dvListar_facturas.Count - 1)("RAZON_SOCIAL")
        'ObjFactura.IDFACTURA = dvListar_facturas.Table.Rows(dvListar_facturas.Count - 1)("IDFACTURA")
        ObjFactura.PAGI = "N"
        listar_facturas()

        dvListar_facturas.Sort = "RAZON_SOCIAL ASC"

        Page = Page + 1

        Me.LPages.Text = Str(Page) + "/" + Str(Pages)


        'If Not dvListar_facturas.Count <= 0 Then
        '    Me.txtsub_total.Text = FormatNumber(dvListar_facturas.Table.Rows(0)("sum_total_costo") / 1.19, 2)
        '    Me.txtmonto_impuesto.Text = FormatNumber(dvListar_facturas.Table.Rows(0)("sum_total_costo") - dvListar_facturas.Table.Rows(0)("sum_total_costo") / 1.19, 2)
        '    Me.txttotal_costo.Text = FormatNumber(dvListar_facturas.Table.Rows(0)("sum_total_costo"), 2)
        'End If

        If dvListar_facturas.Count <= 0 Then
            move_first()
        End If
    End Sub
    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        move_next()
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
