Public Class FrmConsulFactuEmiConta
    Dim dv_idcentro_costo As New DataView
    Dim dvidtipo_entrega As New DataView
    '
    Dim dvfacturas_guias As New DataView
    Dim dvListar_facturas As New DataView
    '
    Dim Colllistar_persona_todos As New Collection
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection
    '
    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL

    Dim dvlistar_persona_todos As New DataView
    Dim dvlistar_tipo_moneda As New DataView

    Dim dvlistar_forma_pago As New DataView

    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Dim blnInicio As Boolean

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


            If Not IsNothing(Me.cbidcentro_costo.SelectedValue) Then
                ObjFactura.idcentro_costo = Me.cbidcentro_costo.SelectedValue
            Else
                ObjFactura.idcentro_costo = 0
            End If

            Dim P_ENTRE As String

            If Me.RBENTRE.Checked = True Then
                P_ENTRE = 1
            ElseIf Me.RBSIN_ENTRE.Checked = True Then
                P_ENTRE = 0
            Else
                P_ENTRE = 2
            End If

            If Me.RBAGENCIA_VENTA.Checked = True Then
                ObjFactura.agencia_venta = 1
            Else
                ObjFactura.agencia_venta = 0
            End If
            '
            If Me.rbcarga.Checked Then

                ObjFactura.ES_CARGA_ASEGURADA = 0

            ElseIf rbcarga_asegurada.Checked Then
                ObjFactura.ES_CARGA_ASEGURADA = 1
            ElseIf Me.rbambos_cargas.Checked Then
                ObjFactura.ES_CARGA_ASEGURADA = -1
            End If
            '09/08/2010 - Tipo de Entrega 
            'If Me.rbticarga_ambos.Checked Then ' Todos 
            '    ObjFactura.carga_acompanada = 2
            'ElseIf Me.rbtipocarga_normal.Checked Then ' No Carga acompañadas
            '    ObjFactura.carga_acompanada = 0
            'ElseIf Me.rbtipocarga_acompanada.Checked Then
            '    ObjFactura.carga_acompanada = 1
            'ElseIf Me.rbPyme.Checked Then
            '    ObjFactura.carga_acompanada = 3
            'End If
            '


            '-->Modificado 15/08/2013 (jabanto)
            If (CboTipoProducto.SelectedIndex = 0) Then
                ObjFactura.carga_acompanada = -1
            Else
                ObjFactura.carga_acompanada = CboTipoProducto.SelectedValue
            End If

            ObjFactura.Usuario = dtoUSUARIOS.IdLogin
            ObjFactura.IP = dtoUSUARIOS.IP

            'If Me.CboTipoProducto.SelectedValue = 0 And CboTipoProducto.SelectedIndex = 0 Then ' Todos 
            '    ObjFactura.carga_acompanada = 2
            'ElseIf Me.CboTipoProducto.SelectedValue = 0 Then ' No Carga acompañadas
            '    ObjFactura.carga_acompanada = 0
            'ElseIf Me.CboTipoProducto.SelectedValue = 6 Then
            '    ObjFactura.carga_acompanada = 1
            'ElseIf Me.CboTipoProducto.SelectedValue = 7 Then
            '    ObjFactura.carga_acompanada = 3
            'ElseIf Me.CboTipoProducto.SelectedValue = 8 Then
            '    ObjFactura.carga_acompanada = 4
            'ElseIf Me.CboTipoProducto.SelectedValue = 81 Then
            '    ObjFactura.carga_acompanada = 5
            'End If

            If Me.txtCodigoCliente.Text.Trim.Length > 0 Then
                ObjFactura.NumeroDocumento = Me.txtCodigoCliente.Text.Trim
                ObjFactura.RazonSocial = ""
            ElseIf Me.txtidpersona.Text.Trim.Length > 0 Then
                ObjFactura.NumeroDocumento = ""
                ObjFactura.RazonSocial = Me.txtidpersona.Text.Trim
            Else
                ObjFactura.NumeroDocumento = ""
                ObjFactura.RazonSocial = ""
            End If

            Me.Cursor = Cursors.AppStarting
            dvListar_facturas = ObjFactura.SP_ConsulFactuEmiContaX(P_ENTRE)
            Me.Cursor = Cursors.Default

            If dvListar_facturas.Count <= 0 Then
                MsgBox("No existen registros", MsgBoxStyle.Information, "Seguridad del Sistema...")
            End If

            FORMAT_GRILLA3()
            Me.txtsub_total.Text = 0
            Me.txtmonto_impuesto.Text = 0
            Me.txttotal_costo.Text = 0
            Me.TxtTotal_peso.Text = 0
            Me.txtVolumen.Text = 0
            Me.txtPeso.Text = 0

            Me.txtEntregaDomicilio.Text = 0
            Me.txtDevolucionCargo.Text = 0

            Me.txtSubtotal.Text = 0
            Me.txtImpuesto.Text = 0
            Me.txtTotal.Text = 0

            For i As Integer = 0 To dvListar_facturas.Table.Rows.Count - 1

                Me.txtsub_total.Text = Format(CDbl(Me.txtsub_total.Text) + dvListar_facturas.Table.Rows(i)("sub_total"), "###,###,###.00")
                Me.txtmonto_impuesto.Text = Format(CDbl(Me.txtmonto_impuesto.Text) + dvListar_facturas.Table.Rows(i)("monto_impuesto"), "###,###,###.00")
                Me.txttotal_costo.Text = Format(CDbl(Me.txttotal_costo.Text) + dvListar_facturas.Table.Rows(i)("total_costo"), "###,###,###.00")

                Me.txtEntregaDomicilio.Text = Format(CDbl(Me.txtEntregaDomicilio.Text) + dvListar_facturas.Table.Rows(i)("monto_entrega_domicilio"), "###,###,###.00")

                Me.txtDevolucionCargo.Text = Format(CDbl(Me.txtDevolucionCargo.Text) + dvListar_facturas.Table.Rows(i)("monto_devolucion_cargo"), "###,###,###.00")

                Me.TxtTotal_peso.Text = Format(CDbl(Me.TxtTotal_peso.Text) + dvListar_facturas.Table.Rows(i)("total_peso"), "###,###,###.00")

                Me.txtPeso.Text = Format(CDbl(Me.txtPeso.Text) + dvListar_facturas.Table.Rows(i)("peso"), "###,###,###.00")
                Me.txtVolumen.Text = Format(CDbl(Me.txtVolumen.Text) + dvListar_facturas.Table.Rows(i)("volumen"), "###,###,###.00")

                Me.txtSubtotal.Text = Format(CDbl(Me.txtSubtotal.Text) + IIf(IsDBNull(dvListar_facturas.Table.Rows(i)("a")), 0, dvListar_facturas.Table.Rows(i)("a")), "###,###,###.00")
                Me.txtImpuesto.Text = Format(CDbl(Me.txtImpuesto.Text) + IIf(IsDBNull(dvListar_facturas.Table.Rows(i)("b")), 0, dvListar_facturas.Table.Rows(i)("b")), "###,###,###.00")
                Me.txtTotal.Text = Format(CDbl(Me.txtTotal.Text) + IIf(IsDBNull(dvListar_facturas.Table.Rows(i)("c")), 0, dvListar_facturas.Table.Rows(i)("c")), "###,###,###.00")
            Next

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellContentClick
        '
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
            .HeaderText = "Año Factura"
            .Name = "ANIO_FACTURA"
            .DataPropertyName = "ANIO_FACTURA"
            .Width = 4
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "Cod. Cliente"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            .Width = 20
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINATARIO As New DataGridViewTextBoxColumn
        With DESTINATARIO
            .HeaderText = "Destinatario"
            .Name = "DESTINATARIO"
            .DataPropertyName = "DESTINATARIO"
            .Width = 182
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "Destino"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"

            .ReadOnly = True
        End With
        Dim DIA_FACTURA As New DataGridViewTextBoxColumn
        With DIA_FACTURA
            .HeaderText = "Dia Factura"
            .Name = "DIA_FACTURA"
            .DataPropertyName = "DIA_FACTURA"
            .Width = 2
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
        With DIRECCION_PERSONA
            .HeaderText = "Dir. Persona"
            .Name = "DIRECCION_PERSONA"
            .DataPropertyName = "DIRECCION_PERSONA"

            .ReadOnly = True
        End With
        Dim DIREC_DESTI As New DataGridViewTextBoxColumn
        With DIREC_DESTI
            .HeaderText = "Dir. Desti."
            .Name = "DIREC_DESTI"
            .DataPropertyName = "DIREC_DESTI"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIREC_REMI As New DataGridViewTextBoxColumn
        With DIREC_REMI
            .HeaderText = "Dir. Remi."
            .Name = "DIREC_REMI"
            .DataPropertyName = "DIREC_REMI"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DSCTO As New DataGridViewTextBoxColumn
        With DSCTO
            .HeaderText = "Descuento"
            .Name = "DSCTO"
            .DataPropertyName = "DSCTO"

            .ReadOnly = True
        End With
        Dim FECHA_FACTURA As New DataGridViewTextBoxColumn
        With FECHA_FACTURA
            .HeaderText = "Fecha Factura"
            .Name = "FECHA_FACTURA"
            .DataPropertyName = "FECHA_FACTURA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_ENTREGA As New DataGridViewTextBoxColumn
        With FECHA_ENTREGA
            .HeaderText = "Fecha Entrega"
            .Name = "FECHA_ENTREGA"
            .DataPropertyName = "FECHA_ENTREGA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim TIPO_ENTREGA As New DataGridViewTextBoxColumn
        With TIPO_ENTREGA
            .HeaderText = "Tipo Entrega"
            .Name = "TIPO_ENTREGA"
            .DataPropertyName = "TIPO_ENTREGA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        With TIPO_COMPROBANTE
            .HeaderText = "Tipo Comprob."
            .Name = "TIPO_COMPROBANTE"
            .DataPropertyName = "TIPO_COMPROBANTE"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO_ENVIO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO_ENVIO
            .HeaderText = "Est. Envío"
            .Name = "ESTADO_REGISTRO_ENVIO"
            .DataPropertyName = "ESTADO_REGISTRO_ENVIO"
            .Width = 120
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "Est. Reg."
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim Nombre_Unidad_ORI As New DataGridViewTextBoxColumn
        With Nombre_Unidad_ORI
            .HeaderText = "Ori."
            .Name = "Nombre_Unidad_ORI"
            .DataPropertyName = "Nombre_Unidad_ORI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim Nombre_Unidad_DESTI As New DataGridViewTextBoxColumn
        With Nombre_Unidad_DESTI
            .HeaderText = "Dest."
            .Name = "Nombre_Unidad_DESTI"
            .DataPropertyName = "Nombre_Unidad_DESTI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "Agencia"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .Width = 150
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "Forma Pago"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn
        With IDAGENCIAS
            .HeaderText = "Id Agencias"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDFACTURA As New DataGridViewTextBoxColumn
        With IDFACTURA
            .HeaderText = "Id Factura"
            .Name = "IDFACTURA"
            .DataPropertyName = "IDFACTURA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
        With IDFORMA_PAGO
            .HeaderText = "Forma Pago"
            .Name = "IDFORMA_PAGO"
            .DataPropertyName = "IDFORMA_PAGO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
        With IDTIPO_MONEDA
            .HeaderText = "Moneda"
            .Name = "IDTIPO_MONEDA"
            .DataPropertyName = "IDTIPO_MONEDA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONAL
            .HeaderText = "Usuario"
            .Name = "IDUSUARIO_PERSONAL"
            .DataPropertyName = "IDUSUARIO_PERSONAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim MEMO As New DataGridViewTextBoxColumn
        With MEMO
            .HeaderText = "Memo"
            .Name = "MEMO"
            .DataPropertyName = "MEMO"

            .ReadOnly = True
        End With
        Dim MES_FACTURA As New DataGridViewTextBoxColumn
        With MES_FACTURA
            .HeaderText = "Mes Factura"
            .Name = "MES_FACTURA"
            .DataPropertyName = "MES_FACTURA"
            .Width = 10
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "Impuesto"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "Nº Factura"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "Orígen"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"

            .ReadOnly = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "Razón Social"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim REFE As New DataGridViewTextBoxColumn
        With REFE
            .HeaderText = "Ref."
            .Name = "REFE"
            .DataPropertyName = "REFE"

            .ReadOnly = True
        End With
        Dim REMITENTE As New DataGridViewTextBoxColumn
        With REMITENTE
            .HeaderText = "Remitente"
            .Name = "REMITENTE"
            .DataPropertyName = "REMITENTE"
            .Width = 182
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
        With SERIE_FACTURA
            .HeaderText = "Nº Serie"
            .Name = "SERIE_FACTURA"
            .DataPropertyName = "SERIE_FACTURA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "Moneda"
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            .Width = 60
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "Subtotal"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "Usuario"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "Total Costo"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
        With NRO_PREFACTURA
            .HeaderText = "Nº Prefactura"
            .Name = "NRO_PREFACTURA"
            .DataPropertyName = "NRO_PREFACTURA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim TOTAL_PESO As New DataGridViewTextBoxColumn
        With TOTAL_PESO
            .HeaderText = "Total Peso"
            .Name = "TOTAL_PESO"
            .DataPropertyName = "TOTAL_PESO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim CENTRO_COSTO As New DataGridViewTextBoxColumn
        With CENTRO_COSTO
            .HeaderText = "Subcuenta"
            .Name = "CENTRO_COSTO"
            .DataPropertyName = "CENTRO_COSTO"
            .Width = 60
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim ca1 As New DataGridViewTextBoxColumn
        With ca1
            .HeaderText = "CA Subtotal"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "a"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim ca2 As New DataGridViewTextBoxColumn
        With ca2
            .HeaderText = "CA Impuesto"
            .Name = "impuesto"
            .DataPropertyName = "b"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim ca3 As New DataGridViewTextBoxColumn
        With ca3
            .HeaderText = "CA Total"
            .Name = "total"
            .DataPropertyName = "c"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        '12/08/2010 - Venta con carga acompañada 
        Dim tipo_venta As New DataGridViewTextBoxColumn
        With tipo_venta
            .HeaderText = "Tipo Carga"
            .Name = "tipo_venta"
            .DataPropertyName = "tipo_venta"
            .Width = 60
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '19-11-2013 hlamas
        Dim col_entrega_domicilio As New DataGridViewTextBoxColumn
        With col_entrega_domicilio
            .HeaderText = "Monto Entrega Domicilio"
            .Name = "monto_entrega_domicilio"
            .DataPropertyName = "monto_entrega_domicilio"
            '.Width = 60
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        '20-02-2014 hlamas
        Dim col_devolucion_cargo As New DataGridViewTextBoxColumn
        With col_devolucion_cargo
            .HeaderText = "Monto Devolución Cargo"
            .Name = "monto_devolucion_cargo"
            .DataPropertyName = "monto_devolucion_cargo"
            '.Width = 60
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        '06-12-2011 hlamas
        Dim col_producto As New DataGridViewTextBoxColumn
        With col_producto
            .HeaderText = "Producto"
            .Name = "producto"
            .DataPropertyName = "producto"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '.Width = 60
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim col_referencia As New DataGridViewTextBoxColumn
        With col_referencia
            .HeaderText = "Referencia Nota Crédito"
            .Name = "referencia"
            .DataPropertyName = "referencia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '.Width = 60
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        With DGV3
            .Columns.AddRange(RAZON_SOCIAL, CENTRO_COSTO, tipo_venta, TIPO_COMPROBANTE, SERIE_FACTURA, NRO_FACTURA, FECHA_FACTURA, TOTAL_PESO, SIMBOLO_MONEDA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, FORMA_PAGO, LOGIN, ESTADO_REGISTRO, ESTADO_REGISTRO_ENVIO, NOMBRE_AGENCIA, Nombre_Unidad_ORI, Nombre_Unidad_DESTI, TIPO_ENTREGA, FECHA_ENTREGA, ca1, ca2, ca3, col_entrega_domicilio, col_devolucion_cargo, col_producto, col_referencia)
        End With
    End Sub

    Private Sub FrmConsulFactuEmiConta_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        blnInicio = False
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulFactuEmiConta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            blnInicio = True
            Me.ShadowLabel1.Text = "Venta Cliente Corporativo/No Corporativo"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            '
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
            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0
            'Mod.18/09/2009 --> Omendoza - Pasando al datahelper   
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            '
            'Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            'ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)
            '
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA)
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA_DESTINO)
            'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
            objgeneral.fn_L_TIPO_ENTREGA(dvidtipo_entrega, Me.cbidtipo_entrega)
            '
            'objgeneral.FNLISTAR_CENTRO_COSTO(dv_idcentro_costo, Me.cbidcentro_costo, VOCONTROLUSUARIO)


            Me.cbidforma_pago.SelectedIndex = -1
            Me.cbidtipo_comprobante.SelectedIndex = -1
            Me.cmbAgencia.SelectedIndex = -1
            Me.cmbUsuarios.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
            Me.cbidtipo_entrega.SelectedIndex = -1
            Me.cbidcentro_costo.SelectedIndex = -1

            '--> carga productos (15/08/2013 jabanto)
            Dim obj As New dtoVentaCargaContado
            Dim dt As DataTable = obj.ListarProducto()
            'Dim dt As DataTable = obj.ListarProceso(0)
            ''-->
            'Dim ndt As New DataTable
            'ndt.Columns.Add("idprocesos").DataType = GetType(Integer)
            'ndt.Columns.Add("nombre_secundario").DataType = GetType(String)
            ''-->
            'ndt.Rows.Add(0, "TODOS")
            'For Each row As DataRow In dt.Rows
            '    ndt.Rows.Add(row("idprocesos"), row("nombre_secundario"))
            'Next
            With Me.CboTipoProducto
                .DataSource = dt
                .ValueMember = "idprocesos"
                .DisplayMember = "procesos"
            End With


            bIngreso = False
            Dim dt2 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt2, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.GotFocus
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        Me.TxtTotal_peso.Text = 0
        Me.txtVolumen.Text = 0
        Me.txtPeso.Text = 0

        Me.txtEntregaDomicilio.Text = 0
        Me.txtDevolucionCargo.Text = 0

        Me.txtVolumen.Text = 0
        Me.txtPeso.Text = 0

        Me.txtSubtotal.Text = 0
        Me.txtImpuesto.Text = 0
        Me.txtTotal.Text = 0

        DGV3.DataSource = Nothing
    End Sub

    Private Sub cmbAgencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbAgencia.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbUsuarios.Focus()
        End If
        e.KeyChar = UCase(e.KeyChar)
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

                    If Not IsNothing(Me.cbidcentro_costo.SelectedValue) Then
                        ObjFactura.idcentro_costo = Me.cbidcentro_costo.SelectedValue
                    Else
                        ObjFactura.idcentro_costo = 0
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

                    If Me.RBENTRE.Checked = True Then
                        P_ENTRE = 1
                    ElseIf Me.RBSIN_ENTRE.Checked = True Then
                        P_ENTRE = 0
                    Else
                        P_ENTRE = 2
                    End If


                    If Me.RBAGENCIA_VENTA.Checked = True Then
                        ObjFactura.agencia_venta = 1
                    Else
                        ObjFactura.agencia_venta = 0
                    End If


                    If Me.rbcarga.Checked Then

                        ObjFactura.ES_CARGA_ASEGURADA = 0

                    ElseIf rbcarga_asegurada.Checked Then

                        ObjFactura.ES_CARGA_ASEGURADA = 1

                    ElseIf Me.rbambos_cargas.Checked Then

                        ObjFactura.ES_CARGA_ASEGURADA = -1

                    End If
                    '
                    '12/08/2010 - Tipo de Entrega 
                    '
                    'If Me.rbticarga_ambos.Checked Then ' Todos 
                    '    ObjFactura.carga_acompanada = 2
                    'ElseIf Me.rbtipocarga_normal.Checked Then ' No Carga acompañadas
                    '    ObjFactura.carga_acompanada = 0
                    'ElseIf Me.rbtipocarga_acompanada.Checked Then
                    '    ObjFactura.carga_acompanada = 1
                    'ElseIf Me.rbPyme.Checked Then
                    '    ObjFactura.carga_acompanada = 3
                    'End If
                    '
                    '13/07/2011 richard el chikito
                    'If Me.CboTipoProducto.SelectedValue = 0 And CboTipoProducto.SelectedIndex = 0 Then ' Todos 
                    '    ObjFactura.carga_acompanada = 2
                    'ElseIf Me.CboTipoProducto.SelectedValue = 0 Then ' No Carga acompañadas
                    '    ObjFactura.carga_acompanada = 0
                    'ElseIf Me.CboTipoProducto.SelectedValue = 6 Then
                    '    ObjFactura.carga_acompanada = 1
                    'ElseIf Me.CboTipoProducto.SelectedValue = 7 Then
                    '    ObjFactura.carga_acompanada = 3
                    'ElseIf Me.CboTipoProducto.SelectedValue = 8 Then
                    '    ObjFactura.carga_acompanada = 4
                    'End If


                    '-->15/08/2013 jabanto
                    If (CboTipoProducto.SelectedIndex <= 0) Then
                        ObjFactura.carga_acompanada = -1
                    Else
                        ObjFactura.carga_acompanada = CboTipoProducto.SelectedValue
                    End If


                    With ObjFactura
                        .IDFACTURA = Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("IDFACTURA")
                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)

                        If Me.RBGENE.Checked = True Then
                            'ObjReport.printrptB(False, "", "FAC018-1.RPT", _
                            ObjReport.printrptB(False, "", "FAC018.RPT", _
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
                            "p_idcentro_costo;" & .idcentro_costo, _
                            "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                            "p_es_carga_asegurada;" & .ES_CARGA_ASEGURADA, _
                            "p_entre;" & P_ENTRE, _
                            "ni_carga_acompanada;" & .carga_acompanada)   'Mod. 12/08/2010
                        Else
                            'ObjReport.printrptB(False, "", "FAC019-1.RPT", _
                            ObjReport.printrptB(False, "", "FAC019.RPT", _
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
                             "p_idcentro_costo;" & .idcentro_costo, _
                             "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                             "p_es_carga_asegurada;" & .ES_CARGA_ASEGURADA, _
                             "p_entre;" & P_ENTRE, _
                             "ni_carga_acompanada;" & .carga_acompanada)   'Mod. 12/08/2010)
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

    Private Sub txtidpersona_GiveFeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles txtidpersona.GiveFeedback

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
        cbidtipo_entrega.GotFocus, _
        RBENTRE.GotFocus, _
        RBSIN_ENTRE.GotFocus, _
        RBAMBOS_INCLU.GotFocus, rbambos_cargas.GotFocus, rbcarga.GotFocus, rbcarga_asegurada.GotFocus

        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        Me.TxtTotal_peso.Text = 0

        Me.txtVolumen.Text = 0
        Me.txtPeso.Text = 0

        Me.txtEntregaDomicilio.Text = 0
        Me.txtDevolucionCargo.Text = 0

        Me.txtSubtotal.Text = 0
        Me.txtImpuesto.Text = 0
        Me.txtTotal.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    Private Sub txtidpersona_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyUp
        Return
        Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
        If e.KeyCode = 13 Then

            If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                With ObjPersona

                    .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
                    'ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, .IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                    ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)

                    Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                    Me.DTPFECHAINICIOFACTURA.Focus()
                    'Mod. 17/09/2009 - Por dhelper - Hlamas 
                    'ObjGeneral.fnL_CENTRO_COSTOS_PERSONAS(dv_idcentro_costo, Me.cbidcentro_costo, VOCONTROLUSUARIO, ObjPersona.IDPERSONA)
                    ObjGeneral.fnL_CENTRO_COSTOS_PERSONAS(dv_idcentro_costo, Me.cbidcentro_costo, ObjPersona.IDPERSONA)
                    '
                    cbidcentro_costo.SelectedIndex = -1
                End With

            Else
                Me.txtCodigoCliente.Text = ""
                Me.cbidcentro_costo.DataSource = Nothing
                Me.cbidcentro_costo.Text = ""
            End If
        End If
    End Sub

    Private Sub txtidpersona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.LostFocus
        'If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
        '    Me.txtidpersona.Text = ""
        '    Me.txtCodigoCliente.Text = ""
        '    Me.cbidcentro_costo.DataSource = Nothing
        '    Me.cbidcentro_costo.Text = ""

        'End If
    End Sub

    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.TextChanged
        Me.DGV3.DataSource = Nothing
        Me.txtCodigoCliente.Text = ""
    End Sub

    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.GotFocus, tbnro_factura.GotFocus
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        Me.TxtTotal_peso.Text = 0

        Me.txtVolumen.Text = 0
        Me.txtPeso.Text = 0

        Me.txtEntregaDomicilio.Text = 0
        Me.txtDevolucionCargo.Text = 0

        Me.txtSubtotal.Text = 0
        Me.txtImpuesto.Text = 0
        Me.txtTotal.Text = 0

        DGV3.DataSource = Nothing
    End Sub

    Private Sub txtCodigoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        Return
        Try
            If e.KeyChar = Chr(13) Then

                ObjPersona.CODIGO_CLIENTE = Trim(Me.txtCodigoCliente.Text)
                ObjPersona.IDTIPO_PERSONA = 0
                ObjPersona.IDPERSONA = 0

                If Len(ObjPersona.CODIGO_CLIENTE) = 0 Then
                    Me.txtCodigoCliente.Text = ""
                    Me.txtidpersona.Text = ""
                    Me.cbidcentro_costo.DataSource = Nothing
                    Me.cbidcentro_costo.Text = ""
                    Exit Sub
                End If
                'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
                'If ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                If ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                    Me.txtidpersona.Text = ObjPersona.RAZON_SOCIAL
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                    'Mod. 17/09/2009 - Por dhelper - Hlamas 
                    'ObjGeneral.fnL_CENTRO_COSTOS_PERSONAS(dv_idcentro_costo, Me.cbidcentro_costo, VOCONTROLUSUARIO, ObjPersona.IDPERSONA)
                    ObjGeneral.fnL_CENTRO_COSTOS_PERSONAS(dv_idcentro_costo, Me.cbidcentro_costo, ObjPersona.IDPERSONA)
                    '
                    cbidcentro_costo.SelectedIndex = -1
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
        ElseIf ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodigoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.LostFocus, tbnro_factura.LostFocus
        'If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
        '    Me.txtidpersona.Text = ""
        '    Me.txtCodigoCliente.Text = ""
        '    Me.cbidcentro_costo.DataSource = Nothing
        '    Me.cbidcentro_costo.Text = ""
        'End If
    End Sub
    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        Me.TxtTotal_peso.Text = 0
        '
        Me.txtVolumen.Text = 0
        Me.txtPeso.Text = 0
        '
        Me.txtSubtotal.Text = 0
        Me.txtImpuesto.Text = 0
        Me.txtTotal.Text = 0
        '
        Me.txtEntregaDomicilio.Text = 0
        Me.txtDevolucionCargo.Text = 0

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
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        Me.TxtTotal_peso.Text = 0
        '
        Me.txtVolumen.Text = 0
        Me.txtPeso.Text = 0
        '
        Me.txtSubtotal.Text = 0
        Me.txtImpuesto.Text = 0
        Me.txtTotal.Text = 0
        '
        Me.txtEntregaDomicilio.Text = 0
        Me.txtDevolucionCargo.Text = 0
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
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        Me.TxtTotal_peso.Text = 0

        Me.txtVolumen.Text = 0
        Me.txtPeso.Text = 0


        Me.txtSubtotal.Text = 0
        Me.txtImpuesto.Text = 0
        Me.txtTotal.Text = 0

        Me.txtEntregaDomicilio.Text = 0
        Me.txtDevolucionCargo.Text = 0

        DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_moneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_comprobante.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidforma_pago.Focus()
        End If
    End Sub

    Private Sub cbidforma_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidforma_pago.GotFocus
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        Me.TxtTotal_peso.Text = 0
        '
        Me.txtVolumen.Text = 0
        Me.txtPeso.Text = 0
        '
        Me.txtSubtotal.Text = 0
        Me.txtImpuesto.Text = 0
        Me.txtTotal.Text = 0
        '
        Me.txtEntregaDomicilio.Text = 0
        Me.txtDevolucionCargo.Text = 0

        DGV3.DataSource = Nothing
    End Sub
    Private Sub cbidforma_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidforma_pago.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.tbnro_factura.Focus()
        End If
    End Sub

    Private Sub cmbUsuarios_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUsuarios.GotFocus
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        Me.TxtTotal_peso.Text = 0
        '
        Me.txtVolumen.Text = 0
        Me.txtPeso.Text = 0
        '
        Me.txtSubtotal.Text = 0
        Me.txtImpuesto.Text = 0
        Me.txtTotal.Text = 0

        Me.txtEntregaDomicilio.Text = 0
        Me.txtDevolucionCargo.Text = 0

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

    Private Sub cbidforma_pago_LostFocus(sender As Object, e As System.EventArgs) Handles cbidforma_pago.LostFocus
        If IsNothing(Me.cbidforma_pago.SelectedValue) Then
            Me.cbidforma_pago.Text = ""
        End If
    End Sub

    Private Sub cbidforma_pago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidforma_pago.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub tbnro_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnro_factura.TextChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cmbUsuarios_LostFocus(sender As Object, e As System.EventArgs) Handles cmbUsuarios.LostFocus
        If IsNothing(Me.cmbUsuarios.SelectedValue) Then
            Me.cmbUsuarios.Text = ""
        End If
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If

        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_LostFocus(sender As Object, e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.LostFocus
        If IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
            Me.CBIDUNIDAD_AGENCIA_DESTINO.Text = ""
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDUNIDAD_AGENCIA.KeyPress, cbidtipo_entrega.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.CBIDUNIDAD_AGENCIA_DESTINO.Focus()
        End If
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub cbidtipo_entrega_LostFocus(sender As Object, e As System.EventArgs) Handles cbidtipo_entrega.LostFocus
        If IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
            Me.cbidtipo_entrega.Text = ""
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_LostFocus(sender As Object, e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.LostFocus
        If IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
            Me.CBIDUNIDAD_AGENCIA.Text = ""
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged
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
        Me.txtidpersona.Text = ""
    End Sub

    Private Sub cbidtipo_comprobante_LostFocus(sender As Object, e As System.EventArgs) Handles cbidtipo_comprobante.LostFocus
        If IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
            Me.cbidtipo_comprobante.Text = ""
        End If
    End Sub

    Private Sub cbidtipo_comprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidtipo_comprobante.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBENTRE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBENTRE.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBSIN_ENTRE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSIN_ENTRE.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBAMBOS_INCLU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBAMBOS_INCLU.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBAGENCIA_VENTA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBAGENCIA_VENTA.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBAGENCIA_EMISOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBAGENCIA_EMISOR.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidcentro_costo_LostFocus(sender As Object, e As System.EventArgs) Handles cbidcentro_costo.LostFocus
        If IsNothing(Me.cbidcentro_costo.SelectedValue) Then
            Me.cbidcentro_costo.Text = ""
        End If
    End Sub

    Private Sub cbidcentro_costo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidcentro_costo.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbcarga_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcarga.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbcarga_asegurada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcarga_asegurada.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbambos_cargas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbambos_cargas.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBGENE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGENE.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBDIA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBDIA.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbtipocarga_normal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbtipocarga_acompanada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbticarga_ambos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbPyme_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_comprobante_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbidtipo_comprobante.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Private Sub cbidforma_pago_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbidforma_pago.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Private Sub cmbAgencia_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cmbAgencia.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Private Sub cmbUsuarios_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cmbUsuarios.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Private Sub cbidtipo_entrega_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbidtipo_entrega.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Private Sub cbidcentro_costo_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbidcentro_costo.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Private Sub cmbAgencia_LostFocus(sender As Object, e As System.EventArgs) Handles cmbAgencia.LostFocus
        If IsNothing(Me.cmbAgencia.SelectedValue) Then
            Me.cmbAgencia.Text = ""
        End If
    End Sub
End Class
