Public Class FrmConsulFactuEmiDescu

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

    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        listar_facturas()
    End Sub
    Private Sub listar_facturas()
        Try


            Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                ObjFactura.IDPERSONA = 0
            Else

                ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"
            If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                ObjFactura.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
            Else
                ObjFactura.IDTIPO_COMPROBANTE = 0
            End If
            ObjFactura.IDTIPO_MONEDA = 0
            If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
            Else
                ObjFactura.IDUSUARIO_PERSONAL = 0
            End If

            If Len(Me.tbnro_factura.Text.Trim) = 0 Then
                ObjFactura.NRO_FACTURA = 0
            Else
                ObjFactura.NRO_FACTURA = Me.tbnro_factura.Text.Trim
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

            ObjFactura.Producto = IIf(Me.cboProducto.SelectedIndex = 0, -1, Me.cboProducto.SelectedValue)

            'If Me.RBENTRE.Checked = True Then
            '    P_ENTRE = 1
            'ElseIf Me.RBSIN_ENTRE.Checked = True Then
            '    P_ENTRE = 0
            'Else
            '    P_ENTRE = 2
            'End If

            'If Me.RBAGENCIA_VENTA.Checked = True Then
            '    ObjFactura.agencia_venta = 1
            'Else
            '    ObjFactura.agencia_venta = 0
            'End If
            'Mod.21/09/2009 -->Omendoza - Pasando al datahelper, quito VOCONTROLUSUARIO   
            dvListar_facturas = ObjFactura.SP_ConsulFactuEmiContaDescu(P_ENTRE)
            '

            If dvListar_facturas.Count <= 0 Then
                MsgBox("No existen registros", MsgBoxStyle.Information, "Seguridad del Sistema...")
            End If

            FORMAT_GRILLA3()
            Me.txtsub_total.Text = 0
            Me.txtmonto_impuesto.Text = 0
            Me.txttotal_costo.Text = 0

            Me.txttotal_descu.Text = 0

            For i As Integer = 0 To dvListar_facturas.Table.Rows.Count - 1
                txttotal_descu.Text = Format(CDbl(Me.txttotal_descu.Text) + dvListar_facturas.Table.Rows(i)("MONTO_DESCUENTO"), "###,###,###.00")
                Me.txtsub_total.Text = Format(CDbl(Me.txtsub_total.Text) + dvListar_facturas.Table.Rows(i)("sub_total"), "###,###,###.00")
                Me.txtmonto_impuesto.Text = Format(CDbl(Me.txtmonto_impuesto.Text) + dvListar_facturas.Table.Rows(i)("monto_impuesto"), "###,###,###.00")
                Me.txttotal_costo.Text = Format(CDbl(Me.txttotal_costo.Text) + dvListar_facturas.Table.Rows(i)("total_costo"), "###,###,###.00")

            Next

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellContentClick

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
            .HeaderText = "ANIO FACTURA"
            .Name = "ANIO_FACTURA"
            .DataPropertyName = "ANIO_FACTURA"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "CODIGO CLIENTE"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINATARIO As New DataGridViewTextBoxColumn
        With DESTINATARIO
            .HeaderText = "DESTINATARIO"
            .Name = "DESTINATARIO"
            .DataPropertyName = "DESTINATARIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"

            .ReadOnly = True
        End With
        Dim DIA_FACTURA As New DataGridViewTextBoxColumn
        With DIA_FACTURA
            .HeaderText = "DIA FACTURA"
            .Name = "DIA_FACTURA"
            .DataPropertyName = "DIA_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
        With DIRECCION_PERSONA
            .HeaderText = "DIRECCION PERSONA"
            .Name = "DIRECCION_PERSONA"
            .DataPropertyName = "DIRECCION_PERSONA"

            .ReadOnly = True
        End With
        Dim DIREC_DESTI As New DataGridViewTextBoxColumn
        With DIREC_DESTI
            .HeaderText = "DIREC DESTI"
            .Name = "DIREC_DESTI"
            .DataPropertyName = "DIREC_DESTI"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIREC_REMI As New DataGridViewTextBoxColumn
        With DIREC_REMI
            .HeaderText = "DIREC REMI"
            .Name = "DIREC_REMI"
            .DataPropertyName = "DIREC_REMI"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DSCTO As New DataGridViewTextBoxColumn
        With DSCTO
            .HeaderText = "DSCTO"
            .Name = "DSCTO"
            .DataPropertyName = "DSCTO"

            .ReadOnly = True
        End With
        Dim FECHA_FACTURA As New DataGridViewTextBoxColumn
        With FECHA_FACTURA
            .HeaderText = "FECHA"
            .Name = "FECHA_FACTURA"
            .DataPropertyName = "FECHA_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_ENTREGA As New DataGridViewTextBoxColumn
        With FECHA_ENTREGA
            .HeaderText = "FECHA ENTREGA"
            .Name = "FECHA_ENTREGA"
            .DataPropertyName = "FECHA_ENTREGA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim TIPO_ENTREGA As New DataGridViewTextBoxColumn
        With TIPO_ENTREGA
            .HeaderText = "TIPO ENTREGA"
            .Name = "TIPO_ENTREGA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        With TIPO_COMPROBANTE
            .HeaderText = "TIPO COMPROBANTE"
            .Name = "TIPO_COMPROBANTE"
            .DataPropertyName = "TIPO_COMPROBANTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO_ENVIO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO_ENVIO
            .HeaderText = "EST. ENVIO."
            .Name = "ESTADO_REGISTRO_ENVIO"
            .DataPropertyName = "ESTADO_REGISTRO_ENVIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "EST. REG."
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim Nombre_Unidad_ORI As New DataGridViewTextBoxColumn
        With Nombre_Unidad_ORI
            .HeaderText = "ORIGEN"
            .Name = "Nombre_Unidad_ORI"
            .DataPropertyName = "Nombre_Unidad_ORI"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim Nombre_Unidad_DESTI As New DataGridViewTextBoxColumn
        With Nombre_Unidad_DESTI
            .HeaderText = "DESTINO"
            .Name = "Nombre_Unidad_DESTI"
            .DataPropertyName = "Nombre_Unidad_DESTI"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn
        With IDAGENCIAS
            .HeaderText = "IDAGENCIAS"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDFACTURA As New DataGridViewTextBoxColumn
        With IDFACTURA
            .HeaderText = "IDFACTURA"
            .Name = "IDFACTURA"
            .DataPropertyName = "IDFACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
        With IDFORMA_PAGO
            .HeaderText = "IDFORMA_PAGO"
            .Name = "IDFORMA_PAGO"
            .DataPropertyName = "IDFORMA_PAGO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim MEMO As New DataGridViewTextBoxColumn
        With MEMO
            .HeaderText = "AUTORIZA"
            .Name = "MEMO"
            .DataPropertyName = "MEMO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim MES_FACTURA As New DataGridViewTextBoxColumn
        With MES_FACTURA
            .HeaderText = "MES FACTURA"
            .Name = "MES_FACTURA"
            .DataPropertyName = "MES_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "NRO FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .ReadOnly = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "RAZON SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim REFE As New DataGridViewTextBoxColumn
        With REFE
            .HeaderText = "REFE"
            .Name = "REFE"
            .DataPropertyName = "REFE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .ReadOnly = True
        End With
        Dim REMITENTE As New DataGridViewTextBoxColumn
        With REMITENTE
            .HeaderText = "REMITENTE"
            .Name = "REMITENTE"
            .DataPropertyName = "REMITENTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
        With SERIE_FACTURA
            .HeaderText = "SERIE FACTURA"
            .Name = "SERIE_FACTURA"
            .DataPropertyName = "SERIE_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUBTOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "USUARIO"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim Monto_Descuento As New DataGridViewTextBoxColumn
        With Monto_Descuento
            .HeaderText = "MONTO DSCTO."
            .Name = "Monto_Descuento"
            .DataPropertyName = "Monto_Descuento"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim Porcent_Descuento As New DataGridViewTextBoxColumn
        With Porcent_Descuento
            .HeaderText = "PORCEN DSCTO."
            .Name = "Porcent_Descuento"
            .DataPropertyName = "Porcent_Descuento"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim MotivoDescuento As New DataGridViewTextBoxColumn
        With MotivoDescuento
            .HeaderText = "SUSTENTO DESCUENTO"
            .Name = "motivo_descuento"
            .DataPropertyName = "motivo_descuento"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        With DGV3
            .Columns.AddRange(RAZON_SOCIAL, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, Porcent_Descuento, Monto_Descuento, MEMO, LOGIN, FECHA_FACTURA, TIPO_COMPROBANTE, SERIE_FACTURA, NRO_FACTURA, FORMA_PAGO, ESTADO_REGISTRO, ESTADO_REGISTRO_ENVIO, NOMBRE_AGENCIA, Nombre_Unidad_ORI, Nombre_Unidad_DESTI, TIPO_ENTREGA, FECHA_ENTREGA, MotivoDescuento)

        End With
    End Sub

    Private Sub FrmConsulFactuEmiDescu_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulFactuEmiDescu_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Ventas con Descuentos"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            ''Mod.17/09/2009 -->Omendoza - Pasando al datahelper   
            'objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
            objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago)
            '
            'dvlistar_forma_pago.RowFilter = "idforma_pago <> 2"
            cbidforma_pago.DataSource = dvlistar_forma_pago
            cbidforma_pago.DisplayMember = "FORMA_PAGO"
            cbidforma_pago.ValueMember = "IDFORMA_PAGO"
            ''Mod.17/09/2009 -->Omendoza - Pasando al datahelper   - No se considera el objeto VOCONTROLUSUARIO 
            'objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
            objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante)
            '
            dvlistar_forma_pago.RowFilter = "IDTIPO_COMPROBANTE = 1 or IDTIPO_COMPROBANTE = 2 or IDTIPO_COMPROBANTE = 3"

            'objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
            objgeneral.FN_cmb_Listar_agencias(Me.cmbAgencia)
            Me.cmbAgencia.SelectedValue = 0
            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0
            'Mod.21/09/2009 -->Omendoza - Pasando al datahelper   
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            dvlistar_persona_todos = ObjPersona.ListarClienteDescuento(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)


            'Mod.21/09/2009 -->Omendoza - Pasando al datahelper   
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA)
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA_DESTINO)
            'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
            objgeneral.fn_L_TIPO_ENTREGA(dvidtipo_entrega, Me.cbidtipo_entrega)
            '
            Me.cbidforma_pago.SelectedIndex = -1
            Me.cbidtipo_comprobante.SelectedIndex = -1
            Me.cmbAgencia.SelectedIndex = -1
            Me.cmbUsuarios.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
            Me.cbidtipo_entrega.SelectedIndex = -1

            'producto
            Dim dt1 As DataTable = objgeneral.ListarProductos(1)
            With Me.cboProducto
                .DisplayMember = "producto"
                .ValueMember = "id"
                .DataSource = dt1
                .SelectedValue = 0
            End With


            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.GotFocus
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
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
            objgeneral.ListarAgenciaUsuario(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia, Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString, Me.DTPFECHAFINALFACTURA.Value.ToShortDateString)
        Else
            cmbUsuarios.DataSource = Nothing
        End If
        Me.cmbUsuarios.SelectedIndex = 0

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
                    If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                        ObjFactura.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
                    Else
                        ObjFactura.IDTIPO_COMPROBANTE = 0
                    End If

                    ObjFactura.IDTIPO_MONEDA = 0

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

                    If Len(Me.tbnro_factura.Text.Trim) = 0 Then
                        ObjFactura.NRO_FACTURA = 0
                    Else
                        ObjFactura.NRO_FACTURA = Me.tbnro_factura.Text.Trim
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
                    P_ENTRE = 0
                    'Else
                    '    P_ENTRE = 2
                    'End If


                    'If Me.RBAGENCIA_VENTA.Checked = True Then
                    '    ObjFactura.agencia_venta = 1
                    'Else
                    '    ObjFactura.agencia_venta = 0
                    'End If


                    If Not IsNothing(cboProducto.SelectedIndex) Then
                        ObjFactura.Producto = IIf(Me.cboProducto.SelectedIndex = 0, -1, Me.cboProducto.SelectedValue)
                    Else
                        ObjFactura.Producto = -1
                    End If


                    With ObjFactura

                        .IDFACTURA = Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("IDFACTURA")


                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)

                        ObjReport.printrptB(False, "", "FAC020.RPT", _
                        "P_AGENCIA_VENTA;" & .agencia_venta, _
                        "p_idpersona;" & .IDPERSONA, _
                        "p_idforma_pago;" & .IDFORMA_PAGO, _
                        "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                        "p_idagencias;" & .IDAGENCIAS, _
                        "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                        "p_idunidad_origen;" & .IDUNIDAD_ORIGEN, _
                        "p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
                        "p_nro_factura;" & .NRO_FACTURA, _
                        "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
                        "p_fecha_inicial;" & .FECHA_INICIO, _
                        "p_fecha_final;" & .FECHA_FINAL, _
                        "p_idtipo_entrega;" & .IDTIPO_ENTREGA, _
                        "ni_producto;" & .Producto, _
                        "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                        "p_entre;" & P_ENTRE)


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
        cbidtipo_comprobante.GotFocus, _
        cbidforma_pago.GotFocus, _
        tbnro_factura.GotFocus, _
        cmbAgencia.GotFocus, _
        cmbUsuarios.GotFocus, _
        CBIDUNIDAD_AGENCIA.GotFocus, _
        CBIDUNIDAD_AGENCIA_DESTINO.GotFocus, _
        cbidtipo_entrega.GotFocus, cboProducto.GotFocus

        Me.txttotal_descu.Text = 0
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    Private Sub txtidpersona_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyUp
        If e.KeyCode = 13 Then
            If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                With ObjPersona
                    .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'Mod.21/09/2009 -->Omendoza - Pasando al datahelper   
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

    Private Sub txtidpersona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.LostFocus
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.TextChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.GotFocus, tbnro_factura.GotFocus
        Me.txttotal_descu.Text = 0
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
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
                'Mod.21/09/2009 -->Omendoza - Pasando al datahelper   
                'If ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
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

    Private Sub tbnro_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbnro_factura.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbAgencia.Focus()
        End If
    End Sub

    Private Sub txtCodigoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.LostFocus, tbnro_factura.LostFocus
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub



    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus
        Me.txttotal_descu.Text = 0
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
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
        Me.txttotal_descu.Text = 0
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidtipo_comprobante.Focus()
        End If
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidtipo_comprobante.GotFocus
        Me.txttotal_descu.Text = 0
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_moneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_comprobante.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidforma_pago.Focus()
        End If
    End Sub

    Private Sub cbidforma_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidforma_pago.GotFocus
        Me.txttotal_descu.Text = 0
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidforma_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidforma_pago.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.tbnro_factura.Focus()
        End If
    End Sub

    Private Sub cmbUsuarios_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUsuarios.GotFocus
        Me.txttotal_descu.Text = 0
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub


    Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUsuarios.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.CBIDUNIDAD_AGENCIA.Focus()
        End If
    End Sub


    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub cbidforma_pago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidforma_pago.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub tbnro_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnro_factura.TextChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDUNIDAD_AGENCIA.KeyPress, cbidtipo_entrega.KeyPress, cboProducto.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.CBIDUNIDAD_AGENCIA_DESTINO.Focus()
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged, cbidtipo_entrega.SelectedIndexChanged, cboProducto.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
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

    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_comprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidtipo_comprobante.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub
End Class
