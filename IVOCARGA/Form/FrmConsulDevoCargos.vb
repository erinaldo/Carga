Public Class FrmConsulDevoCargos
    Dim NUMERO As Long = 0
    Dim dvidtipo_entrega As New DataView

    Dim dvfacturas_guias As New DataView
    Dim dvListar_facturas As New DataView

    Dim Colllistar_persona_todos As New Collection
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection

    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL
    Dim objValida As New ClsLbTepsa.dtoValida

    Dim dvlistar_persona_todos As New DataView
    Dim dvlistar_tipo_moneda As New DataView

    Dim dvlistar_forma_pago As New DataView

    Private ObjReport As ClsLbTepsa.dtoFrmReport '

    Dim objFACTURA As New ClsLbTepsa.dtoFACTURA
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        listar_facturas()
    End Sub

    Private Sub listar_facturas()
        Try
            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                objFACTURA.IDPERSONA = 0
            Else
                objFACTURA.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If

            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then objFACTURA.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else objFACTURA.FECHA_INICIO = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then objFACTURA.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else objFACTURA.FECHA_FINAL = "NULL"

            If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                objFACTURA.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
            Else
                objFACTURA.IDTIPO_COMPROBANTE = 0
            End If

            objFACTURA.IDTIPO_MONEDA = 0

            If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                objFACTURA.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
            Else
                objFACTURA.IDUSUARIO_PERSONAL = 0
            End If

            If Len(Me.tbnro_factura.Text.Trim) = 0 Then
                objFACTURA.NRO_FACTURA = 0
            Else
                objFACTURA.NRO_FACTURA = Me.tbnro_factura.Text.Trim
            End If

            If Len(Me.txtNRO_LIQUI_DEVO_CARGO.Text) = 0 Then
                objFACTURA.NRO_LIQUI_DEVO_CARGO = 0
            Else
                If objValida.NUMERO_ENTERO(txtNRO_LIQUI_DEVO_CARGO, Me) = False Then
                    Exit Sub
                Else
                    objFACTURA.NRO_LIQUI_DEVO_CARGO = Me.txtNRO_LIQUI_DEVO_CARGO.Text.Trim
                End If
            End If

            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                objFACTURA.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            Else
                objFACTURA.IDAGENCIAS = 0
            End If

            If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                objFACTURA.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            Else
                objFACTURA.IDFORMA_PAGO = 0
            End If

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                objFACTURA.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            Else
                objFACTURA.IDUNIDAD_ORIGEN = 0
            End If

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                objFACTURA.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            Else
                objFACTURA.IDUNIDAD_DESTINO = 0
            End If

            If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                objFACTURA.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
            Else
                objFACTURA.IDTIPO_ENTREGA = 0
            End If

            Dim p_idtipo_recep_docu As String = ""

            If Me.chkENCO.Checked Then
                p_idtipo_recep_docu = "'ENCO',"
            End If

            If Me.chkDEVO.Checked Then
                p_idtipo_recep_docu = p_idtipo_recep_docu + "'DEVU',"
            End If

            If Me.chkENOB.Checked Then
                p_idtipo_recep_docu = p_idtipo_recep_docu + "'ENOB',"
            End If

            If Me.chkPEND.Checked Then
                p_idtipo_recep_docu = p_idtipo_recep_docu + "'PEND',"
            End If

            If p_idtipo_recep_docu = "" Then
                p_idtipo_recep_docu = "'ENCO'," + "'DEVU'," + "'ENOB'," + "'PEND',"
            End If

            'If Not IsNothing(Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue) Then
            '    ObjFactura.IDTIPO_RECEPCION_DOCU = Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue
            'Else
            '    ObjFactura.IDTIPO_RECEPCION_DOCU = 0
            'End If
            objFACTURA.IDTIPO_RECEPCION_DOCU = 0

            Dim P_ENTRE As String

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
            If Len(p_idtipo_recep_docu) > 0 Then
                objFACTURA.Idtipo_recep_docuS = Mid(p_idtipo_recep_docu, 1, Len(p_idtipo_recep_docu) - 1)
            Else
                objFACTURA.Idtipo_recep_docuS = "NULL"
            End If

            'Modificado - 12/09/2008 
            'dvListar_facturas = objFACTURA.SP_ConsulFactuDevoCargosVII(VOCONTROLUSUARIO, P_ENTRE)            
            objFACTURA.idusuario_seleccion = dtoUSUARIOS.IdLogin
            '
            'datahelper
            'dvListar_facturas = objFACTURA.SP_ConsulFactuDevoCargos8(VOCONTROLUSUARIO, P_ENTRE)
            dvListar_facturas = objFACTURA.SP_ConsulFactuDevoCargos8(P_ENTRE)

            Label17.Text = dvListar_facturas.Count

            If dvListar_facturas.Count <= 0 Then
                MsgBox("No existen registros", MsgBoxStyle.Information, "Seguridad del Sistema...")
            End If

            FORMAT_GRILLA3()
            Me.txtsub_total.Text = 0
            Me.txtmonto_impuesto.Text = 0
            Me.txttotal_costo.Text = 0

            'Me.txttotal_descu.Text = 0

            NUMERO = 0


            For i As Integer = 0 To dvListar_facturas.Table.Rows.Count - 1

                If dvListar_facturas.Table.Rows(i)("SELECCIONAR") = 1 Then
                    NUMERO = NUMERO + 1
                End If

                'txttotal_descu.Text = Format(CDbl(Me.txttotal_descu.Text) + dvListar_facturas.Table.Rows(i)("MONTO_DESCUENTO"), "###,###,###.00")
                Me.txtsub_total.Text = Format(CDbl(Me.txtsub_total.Text) + dvListar_facturas.Table.Rows(i)("sub_total"), "###,###,###.00")
                Me.txtmonto_impuesto.Text = Format(CDbl(Me.txtmonto_impuesto.Text) + dvListar_facturas.Table.Rows(i)("monto_impuesto"), "###,###,###.00")
                Me.txttotal_costo.Text = Format(CDbl(Me.txttotal_costo.Text) + dvListar_facturas.Table.Rows(i)("total_costo"), "###,###,###.00")

            Next

            Label23.Text = IIf(NUMERO = 0, "", NUMERO)

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

        Dim DEVUELTO As New DataGridViewCheckBoxColumn
        With DEVUELTO
            .HeaderText = "SEL."
            .Name = "SELECCIONAR"
            .DataPropertyName = "SELECCIONAR"
            .ThreeState = False
            .TrueValue = 1
            .Width = 50

            'If Not IsNothing(Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue) Then
            '    If Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue = "PEND" Or Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue = "ENOB" Then
            '        .ReadOnly = False
            '    Else
            '        .ReadOnly = True
            '    End If
            'Else
            '    .ReadOnly = True
            'End If

            .FalseValue = 0
            .SortMode = DataGridViewColumnSortMode.NotSortable

        End With

        Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
        With ANIO_FACTURA
            .HeaderText = "ANIO_FACTURA"
            .Name = "ANIO_FACTURA"
            .DataPropertyName = "ANIO_FACTURA"
            .Width = 4
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "CODIGO_CLIENTE"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            .Width = 20
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With


        Dim OBS_RECEP_DOCU As New DataGridViewTextBoxColumn
        With OBS_RECEP_DOCU
            .HeaderText = "OBS_RECEP_DOCU"
            .Name = "OBS_RECEP_DOCU"
            .DataPropertyName = "OBS_RECEP_DOCU"
            .Width = 182
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With



        Dim DESTINATARIO As New DataGridViewTextBoxColumn
        With DESTINATARIO
            .HeaderText = "DESTINATARIO"
            .Name = "DESTINATARIO"
            .DataPropertyName = "DESTINATARIO"
            .Width = 182
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim DIREC_REMI As New DataGridViewTextBoxColumn
        With DIREC_REMI
            .HeaderText = "DIREC_REMI"
            .Name = "DIREC_REMI"
            .DataPropertyName = "DIREC_REMI"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim DSCTO As New DataGridViewTextBoxColumn
        With DSCTO
            .HeaderText = "DSCTO"
            .Name = "DSCTO"
            .DataPropertyName = "DSCTO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim FECHA_FACTURA As New DataGridViewTextBoxColumn
        With FECHA_FACTURA
            .HeaderText = "FECHA_FACTURA"
            .Name = "FECHA_FACTURA"
            .DataPropertyName = "FECHA_FACTURA"
            .Width = 60
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim FECHA_ENTREGA As New DataGridViewTextBoxColumn
        With FECHA_ENTREGA
            .HeaderText = "FECHA_ENTREGA"
            .Name = "FECHA_ENTREGA"
            .DataPropertyName = "FECHA_ENTREGA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim TIPO_ENTREGA As New DataGridViewTextBoxColumn
        With TIPO_ENTREGA
            .HeaderText = "TIPO_ENTREGA"
            .Name = "TIPO_ENTREGA"
            .DataPropertyName = "TIPO_ENTREGA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        With TIPO_COMPROBANTE
            .HeaderText = "TIPO_COMPROBANTE"
            .Name = "TIPO_COMPROBANTE"
            .DataPropertyName = "TIPO_COMPROBANTE"
            .Width = 40
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim ESTADO_REGISTRO_ENVIO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO_ENVIO
            .HeaderText = "EST. ENVIO."
            .Name = "ESTADO_REGISTRO_ENVIO"
            .DataPropertyName = "ESTADO_REGISTRO_ENVIO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "EST. REG."
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim Nombre_Unidad_ORI As New DataGridViewTextBoxColumn
        With Nombre_Unidad_ORI
            .HeaderText = "Ori."
            .Name = "Nombre_Unidad_ORI"
            .DataPropertyName = "Nombre_Unidad_ORI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim Nombre_Unidad_DESTI As New DataGridViewTextBoxColumn
        With Nombre_Unidad_DESTI
            .HeaderText = "Dest."
            .Name = "Nombre_Unidad_DESTI"
            .DataPropertyName = "Nombre_Unidad_DESTI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
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
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn
        With IDAGENCIAS
            .HeaderText = "IDAGENCIAS"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
        With IDFORMA_PAGO
            .HeaderText = "IDFORMA_PAGO"
            .Name = "IDFORMA_PAGO"
            .DataPropertyName = "IDFORMA_PAGO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
        With IDTIPO_MONEDA
            .HeaderText = "IDTIPO_MONEDA"
            .Name = "IDTIPO_MONEDA"
            .DataPropertyName = "IDTIPO_MONEDA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim MEMO As New DataGridViewTextBoxColumn
        With MEMO
            .HeaderText = "MEMO"
            .Name = "MEMO"
            .DataPropertyName = "MEMO"
            .Width = 100
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim MES_FACTURA As New DataGridViewTextBoxColumn
        With MES_FACTURA
            .HeaderText = "MES_FACTURA"
            .Name = "MES_FACTURA"
            .DataPropertyName = "MES_FACTURA"
            .Width = 10
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
        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "NRO_FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 175
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
        With SERIE_FACTURA
            .HeaderText = "SERIE_FACTURA"
            .Name = "SERIE_FACTURA"
            .DataPropertyName = "SERIE_FACTURA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
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
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "USUARIO ENTREGA"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
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
        Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
        With NRO_PREFACTURA
            .HeaderText = "NRO_PREFACTURA"
            .Name = "NRO_PREFACTURA"
            .DataPropertyName = "NRO_PREFACTURA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim Monto_Descuento As New DataGridViewTextBoxColumn
        With Monto_Descuento
            .HeaderText = "Monto Dscto."
            .Name = "Monto_Descuento"
            .DataPropertyName = "Monto_Descuento"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim Porcent_Descuento As New DataGridViewTextBoxColumn
        With Porcent_Descuento
            .HeaderText = "Porcen Dscto."
            .Name = "Porcent_Descuento"
            .DataPropertyName = "Porcent_Descuento"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim NRO_DOCU_CLIEN As New DataGridViewTextBoxColumn
        With NRO_DOCU_CLIEN
            .HeaderText = "Documentos"
            .Name = "NRO_DOCU_CLIEN"
            .DataPropertyName = "NRO_DOCU_CLIEN"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True

        End With


        Dim TIPO_RECEPCION_DOCU_ As New DataGridViewTextBoxColumn
        With TIPO_RECEPCION_DOCU_
            .HeaderText = "Tipo Recepción Actual"
            .Name = "TIPO_RECEPCION_DOCU_"
            .DataPropertyName = "TIPO_RECEPCION_DOCU_"
            .Width = 150
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True

        End With
        Dim nro_liqui_devo_cargo As New DataGridViewTextBoxColumn
        With nro_liqui_devo_cargo
            .HeaderText = "Nro. Liquid. Dev. Cargo"
            .Name = "nro_liqui_devo_cargo"
            .DataPropertyName = "nro_liqui_devo_cargo"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = ""
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        With DGV3
            .Columns.AddRange(DEVUELTO, nro_liqui_devo_cargo, FECHA_FACTURA, FECHA_ENTREGA, SERIE_FACTURA, NRO_FACTURA, RAZON_SOCIAL, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, NRO_DOCU_CLIEN, TIPO_RECEPCION_DOCU_, Porcent_Descuento, Monto_Descuento, MEMO, LOGIN, TIPO_COMPROBANTE, FORMA_PAGO, ESTADO_REGISTRO, ESTADO_REGISTRO_ENVIO, NOMBRE_AGENCIA, Nombre_Unidad_ORI, Nombre_Unidad_DESTI, TIPO_ENTREGA, OBS_RECEP_DOCU)

        End With
    End Sub

    Private Sub FrmConsulDevoCargos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulDevoCargos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MenuTab.Items(0).Text = "Devolución de Cargos"
        MenuTab.Items(1).Enabled = False
        MenuTab.Items(2).Enabled = False
        MenuTab.Items(3).Enabled = False
        MenuTab.Items(4).Enabled = False
        MenuTab.Items(5).Enabled = False
        '
        Me.ShadowLabel1.Text = "Devolucion de Cargos de Confirm. Entrega"
        Me.MenuStrip1.Items(0).Visible = False
        Me.MenuStrip1.Items(1).Visible = False
        Me.MenuStrip1.Items(2).Visible = False
        Me.MenuStrip1.Items(3).Visible = False
        Me.MenuStrip1.Items(4).Visible = False
        Me.MenuStrip1.Items(5).Visible = False
        '
        Me.MenuStrip1.Items(6).Enabled = False 'imprimir
        'Mod.17/09/2009 -->Omendoza - Pasando al datahelper   
        'objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
        objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago)
        '
        'dvlistar_forma_pago.RowFilter = "idforma_pago <> 2"
        cbidforma_pago.DataSource = dvlistar_forma_pago
        cbidforma_pago.DisplayMember = "FORMA_PAGO"
        cbidforma_pago.ValueMember = "IDFORMA_PAGO"
        ''Mod.17/09/2009 -->Omendoza - Pasando al datahelper   - No se considera el objecto VOCONTROLUSUARIO 
        'objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
        objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante)
        '
        dvlistar_forma_pago.RowFilter = "IDTIPO_COMPROBANTE = 1 or IDTIPO_COMPROBANTE = 2 or IDTIPO_COMPROBANTE = 3"

        'objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
        'datahelper
        'objgeneral.FN_cmb_Listar_agencias(cnn, Me.cmbAgencia)
        objgeneral.FN_cmb_Listar_agencias(Me.cmbAgencia)
        ObjPersona.CODIGO_CLIENTE = "NULL"
        ObjPersona.IDTIPO_PERSONA = 0
        ObjPersona.IDPERSONA = 0
        '
        'objgeneral.FN_cmb_L_tipo_recepcion_docu(cnn, cbIDTIPO_RECEPCION_DOCU)
        '
        'datahelper
        'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
        dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
        Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)

        'datahelper
        'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA)
        objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA)

        'datahelper
        'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA_DESTINO)
        objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA_DESTINO)

        'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
        objgeneral.fn_L_TIPO_ENTREGA(dvidtipo_entrega, Me.cbidtipo_entrega)
        '
        Me.cbidforma_pago.SelectedIndex = -1
        Me.cbidtipo_comprobante.SelectedIndex = -1

        Me.cmbUsuarios.SelectedIndex = -1
        Me.CBIDUNIDAD_AGENCIA.SelectedIndex = -1

        Me.cbidtipo_entrega.SelectedIndex = -1
        'Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue = "PEND"
        Me.cmbUsuarios.SelectedIndex = -1


        Try

            habilitar_por_roles()


            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try

        Me.cmbUsuarios.SelectedIndex = -1

    End Sub
    Private Sub habilitar_por_roles()

        Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue = dtoUSUARIOS.m_idciudad

        'If fnValidar_Rol("37") = True Then  'Supervisor de devolución de cargo 
        If Acceso.SiRol(G_Rol, Me, 1, 1) Then

            Me.CBIDUNIDAD_AGENCIA_DESTINO.Enabled = True
            Me.cmbAgencia.Enabled = True
            Me.cmbUsuarios.Enabled = True


            Dim p_idunidad_agencia As Int64

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                p_idunidad_agencia = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Int64)
                'DAtahelper
                objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(Me.cmbAgencia, p_idunidad_agencia)
                cmbUsuarios.DataSource = Nothing
            Else
                Me.cmbAgencia.DataSource = Nothing
                cmbUsuarios.DataSource = Nothing
            End If

            Me.cmbAgencia.SelectedValue = dtoUSUARIOS.m_iIdAgencia



            Dim p_id_rol_usuario, p_idagencia As Int64
            p_id_rol_usuario = 0
            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
                'objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(cnn, Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
                objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
            Else
                cmbUsuarios.DataSource = Nothing
            End If

            'Me.cmbUsuarios.SelectedValue = dtoUSUARIOS.IdLogin

            'ElseIf fnValidar_Rol("14") = True Then
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then

            Me.cmbAgencia.Enabled = False
            Me.CBIDUNIDAD_AGENCIA_DESTINO.Enabled = False


            Dim p_idunidad_agencia As Int64

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                p_idunidad_agencia = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Int64)
                'Datahelper
                objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(Me.cmbAgencia, p_idunidad_agencia)
                cmbUsuarios.DataSource = Nothing
            Else
                Me.cmbAgencia.DataSource = Nothing
                cmbUsuarios.DataSource = Nothing
            End If

            Me.cmbAgencia.SelectedValue = dtoUSUARIOS.m_iIdAgencia



            Dim p_id_rol_usuario, p_idagencia As Int64
            p_id_rol_usuario = 0
            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
                'datahelper 
                objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
            Else
                cmbUsuarios.DataSource = Nothing
            End If

            'Me.cmbUsuarios.SelectedValue = dtoUSUARIOS.IdLogin
            Me.cmbAgencia.Enabled = False
            Me.cmbUsuarios.Enabled = True

            'ElseIf fnValidar_Rol("7") = True Then
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 3) Then


            Dim p_idunidad_agencia As Int64

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                p_idunidad_agencia = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Int64)
                'Datahelper
                objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(Me.cmbAgencia, p_idunidad_agencia)
                cmbUsuarios.DataSource = Nothing
            Else
                Me.cmbAgencia.DataSource = Nothing
                cmbUsuarios.DataSource = Nothing
            End If

            Me.cmbAgencia.SelectedValue = dtoUSUARIOS.m_iIdAgencia

            Dim p_id_rol_usuario, p_idagencia As Int64
            p_id_rol_usuario = 0
            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
                'datahelper
                objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
            Else
                cmbUsuarios.DataSource = Nothing
            End If
            'Me.cmbUsuarios.SelectedValue = dtoUSUARIOS.IdLogin 
            Me.CBIDUNIDAD_AGENCIA_DESTINO.Enabled = False
            Me.cmbAgencia.Enabled = False
            Me.cmbUsuarios.Enabled = True
            'ElseIf fnValidar_Rol("21") = True Then
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 4) Then
            Dim p_idunidad_agencia As Int64

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                p_idunidad_agencia = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Int64)
                'datahelper
                objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(Me.cmbAgencia, p_idunidad_agencia)
                '
                cmbUsuarios.DataSource = Nothing
            Else
                Me.cmbAgencia.DataSource = Nothing
                cmbUsuarios.DataSource = Nothing
            End If

            Me.cmbAgencia.SelectedValue = dtoUSUARIOS.m_iIdAgencia

            Dim p_id_rol_usuario, p_idagencia As Int64
            p_id_rol_usuario = 0
            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
                'datahelper' 
                objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
            Else
                cmbUsuarios.DataSource = Nothing
            End If


            'Me.cmbUsuarios.SelectedValue = dtoUSUARIOS.IdLogin
            Me.CBIDUNIDAD_AGENCIA_DESTINO.Enabled = False
            Me.cmbAgencia.Enabled = False
            Me.cmbUsuarios.Enabled = True
        Else

            Dim p_idunidad_agencia As Int64

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                p_idunidad_agencia = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Int64)
                'Datahelper
                objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(Me.cmbAgencia, p_idunidad_agencia)
                cmbUsuarios.DataSource = Nothing
            Else
                Me.cmbAgencia.DataSource = Nothing
                cmbUsuarios.DataSource = Nothing
            End If

            Me.cmbAgencia.SelectedValue = dtoUSUARIOS.m_iIdAgencia

            Dim p_id_rol_usuario, p_idagencia As Int64
            p_id_rol_usuario = 0
            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
                'datahelper 
                objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
            Else
                cmbUsuarios.DataSource = Nothing
            End If


            'Me.cmbUsuarios.SelectedValue = dtoUSUARIOS.IdLogin
            Me.CBIDUNIDAD_AGENCIA_DESTINO.Enabled = False
            Me.cmbAgencia.Enabled = False
            Me.cmbUsuarios.Enabled = True
        End If
        Me.cmbUsuarios.SelectedIndex = -1
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
    Private Function imprimir_rpt()
        If Me.DGV3.RowCount <= 0 Then
            MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
            Exit Function
        End If
        '
        Dim IDfacturas As String = ""
        Dim IDtipo_comprobantes As String = ""
        Dim IDTIPO_RECEPCION_DOCUS As String = ""
        Dim AGENCIA As String
        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport

        For K As Integer = 0 To dvListar_facturas.Count - 1
            If dvListar_facturas.Table.Rows(K)("SELECCIONAR") = 1 Then

                IDfacturas = IDfacturas + dvListar_facturas.Table.Rows(K)("IDFACTURA").ToString + ","
                IDtipo_comprobantes = IDtipo_comprobantes + dvListar_facturas.Table.Rows(K)("IDTIPO_COMPROBANTE").ToString + ","
            End If
        Next

        If IDfacturas = "" Then
            MsgBox("No existen registro seleccionado", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
            Exit Function
        End If


        IDfacturas = Mid(IDfacturas, 1, Len(IDfacturas) - 1)
        IDtipo_comprobantes = Mid(IDtipo_comprobantes, 1, Len(IDtipo_comprobantes) - 1)



        Select Case Me.TabMante.SelectedIndex
            Case 0
                Try



                    If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                        objFACTURA.IDPERSONA = 0
                    Else

                        objFACTURA.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    End If
                    If Me.DTPFECHAINICIOFACTURA.Enabled = True Then objFACTURA.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else objFACTURA.FECHA_INICIO = "NULL"
                    If Me.DTPFECHAFINALFACTURA.Enabled = True Then objFACTURA.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else objFACTURA.FECHA_FINAL = "NULL"
                    If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                        objFACTURA.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
                    Else
                        objFACTURA.IDTIPO_COMPROBANTE = 0
                    End If

                    objFACTURA.IDTIPO_MONEDA = 0

                    If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                        objFACTURA.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
                    Else
                        objFACTURA.IDUSUARIO_PERSONAL = 0
                    End If
                    If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                        objFACTURA.IDAGENCIAS = cmbAgencia.SelectedValue
                        AGENCIA = "AGENCIA DESTINO: " + cmbAgencia.Text
                    Else
                        objFACTURA.IDAGENCIAS = 0
                        AGENCIA = ""
                    End If

                    If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                        objFACTURA.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
                    Else
                        objFACTURA.IDFORMA_PAGO = 0
                    End If
                    If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                        objFACTURA.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
                    Else
                        objFACTURA.IDUNIDAD_ORIGEN = 0
                    End If

                    If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                        objFACTURA.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
                    Else
                        objFACTURA.IDUNIDAD_DESTINO = 0
                    End If

                    If Len(Me.tbnro_factura.Text.Trim) = 0 Then
                        objFACTURA.NRO_FACTURA = 0
                    Else
                        objFACTURA.NRO_FACTURA = Me.tbnro_factura.Text.Trim
                    End If

                    If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                        objFACTURA.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
                    Else
                        objFACTURA.IDTIPO_ENTREGA = 0
                    End If
                    Dim TIPO_RECEPCION_DOCU As String = ""
                    'If Not IsNothing(Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue) Then
                    '    ObjFactura.IDTIPO_RECEPCION_DOCU = Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue
                    '    TIPO_RECEPCION_DOCU = "              SITUACION CARGOS: DEVUELTOS"
                    'Else
                    '    ObjFactura.IDTIPO_RECEPCION_DOCU = 0
                    '    TIPO_RECEPCION_DOCU = Me.cbIDTIPO_RECEPCION_DOCU.Text
                    'End If


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

                    If Len(Me.txtNRO_LIQUI_DEVO_CARGO.Text) = 0 Then
                        objFACTURA.NRO_LIQUI_DEVO_CARGO = 0
                    Else
                        If objValida.NUMERO_ENTERO(txtNRO_LIQUI_DEVO_CARGO, Me) = False Then
                            Exit Function
                        Else
                            objFACTURA.NRO_LIQUI_DEVO_CARGO = Me.txtNRO_LIQUI_DEVO_CARGO.Text.Trim
                        End If
                    End If




                    If Me.rbimpri.Checked = True Then
                        IDTIPO_RECEPCION_DOCUS = "0"
                    Else
                        IDTIPO_RECEPCION_DOCUS = "DEVU"
                    End If

                    With objFACTURA

                        '.IDFACTURA = Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("IDFACTURA")


                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)

                        If Me.rbimpri.Checked = True Then

                            ObjReport.printrptB(False, "", "GUI020.RPT", _
                            "P_AGENCIA;" & AGENCIA + TIPO_RECEPCION_DOCU, _
                            "P_AGENCIA_VENTA;" & .agencia_venta, _
                            "p_idpersona;" & .IDPERSONA, _
                            "p_idforma_pago;" & .IDFORMA_PAGO, _
                            "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                            "p_idagencias;" & .IDAGENCIAS, _
                            "p_idagencias_session;" & dtoUSUARIOS.iIDAGENCIAS, _
                            "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                            "p_idusuario_personal_session;" & dtoUSUARIOS.IdLogin, _
                            "p_idunidad_origen;" & .IDUNIDAD_ORIGEN, _
                            "p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
                            "p_nro_factura;" & .NRO_FACTURA, _
                            "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
                            "p_fecha_inicial;" & .FECHA_INICIO, _
                            "p_fecha_final;" & .FECHA_FINAL, _
                            "p_idtipo_entrega;" & .IDTIPO_ENTREGA, _
                            "p_IDTIPO_RECEPCION_DOCU;" & .IDTIPO_RECEPCION_DOCU, _
                            "p_IDFACTURAS;" & IDfacturas, _
                            "p_idtipo_comprobantes;" & IDtipo_comprobantes, _
                            "p_IDtipo_recepcion_docuS;" & IDTIPO_RECEPCION_DOCUS, _
                            "ip_nro_liqui_devo_cargo;" & .NRO_LIQUI_DEVO_CARGO, _
                            "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                            "p_entre;" & P_ENTRE)

                            listar_facturas()

                        Else
                            If MsgBox("Todos estos documentos seleccionados pasaran a un estado devuelto, Seguro que desea continuar...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                ObjReport.printrptB(False, "", "GUI018.RPT", _
                                "P_AGENCIA;" & AGENCIA + TIPO_RECEPCION_DOCU, _
                                "P_AGENCIA_VENTA;" & .agencia_venta, _
                                "p_idpersona;" & .IDPERSONA, _
                                "p_idforma_pago;" & .IDFORMA_PAGO, _
                                "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                                "p_idagencias;" & .IDAGENCIAS, _
                                "p_idagencias_session;" & dtoUSUARIOS.iIDAGENCIAS, _
                                "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                                "p_idusuario_personal_session;" & dtoUSUARIOS.IdLogin, _
                                "p_idunidad_origen;" & .IDUNIDAD_ORIGEN, _
                                "p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
                                "p_nro_factura;" & .NRO_FACTURA, _
                                "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
                                "p_fecha_inicial;" & .FECHA_INICIO, _
                                "p_fecha_final;" & .FECHA_FINAL, _
                                "p_idtipo_entrega;" & .IDTIPO_ENTREGA, _
                                "p_IDTIPO_RECEPCION_DOCU;" & .IDTIPO_RECEPCION_DOCU, _
                                "p_idtipo_comprobantes;" & IDtipo_comprobantes, _
                                "p_IDFACTURAS;" & IDfacturas, _
                                "p_IDtipo_recepcion_docuS;" & IDTIPO_RECEPCION_DOCUS, _
                                "ip_nro_liqui_devo_cargo;" & .NRO_LIQUI_DEVO_CARGO, _
                                "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                                "p_entre;" & P_ENTRE)

                                listar_facturas()

                            End If

                        End If


                    End With
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
                End Try
        End Select
    End Function
    Private Sub FrmConsulFactuEmiti_MenuImprimir() Handles Me.MenuImprimir
        Call imprimir_rpt()
    End Sub

    Private Sub FrmConsulFactuEmiti_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub

    Private Sub tbnro_factura_GiveFeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles tbnro_factura.GiveFeedback

    End Sub

    Private Sub txtidpersona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.GotFocus, _
    DTPFECHAINICIOFACTURA.GotFocus, _
    DTPFECHAFINALFACTURA.GotFocus, _
        cbidtipo_comprobante.GotFocus, _
        cbidforma_pago.GotFocus, _
        tbnro_factura.GotFocus, _
        cmbAgencia.GotFocus, _
        cmbUsuarios.GotFocus, _
        txtCodigoCliente.GotFocus, _
        txtidpersona.GotFocus, _
        CBIDUNIDAD_AGENCIA.GotFocus, _
        CBIDUNIDAD_AGENCIA_DESTINO.GotFocus, _
        cbidtipo_entrega.GotFocus, _
        rbimpri.GotFocus, _
        rbproce.GotFocus, txtNRO_LIQUI_DEVO_CARGO.GotFocus, _
        chkPEND.GotFocus, chkDEVO.GotFocus, chkENCO.GotFocus, chkENOB.GotFocus

        If Me.txtNRO_LIQUI_DEVO_CARGO.Focused Then
            Me.rbimpri.Checked = True
        End If


        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        'DGV3.DataSource = Nothing

        NUMERO = 0
        Label17.Text = ""
        Label23.Text = IIf(NUMERO = 0, "", NUMERO)

        If Len(Me.txtNRO_LIQUI_DEVO_CARGO.Text) > 0 Then
            Me.rbimpri.Checked = True
        End If

    End Sub

    Private Sub txtidpersona_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyUp
        If e.KeyCode = 13 Then
            Try
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
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                Else
                    Me.txtCodigoCliente.Text = ""
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
            End Try
        End If
    End Sub

    Private Sub txtidpersona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.LostFocus
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.GotFocus, tbnro_factura.GotFocus

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

                'datahelper
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

        'If e.KeyChar.IsLetter(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf e.KeyChar.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf e.KeyChar.IsSeparator(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If

        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "-" Then
            e.Handled = False
        ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub txtNRO_LIQUI_DEVO_CARGO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNRO_LIQUI_DEVO_CARGO.KeyPress

        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodigoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.LostFocus, tbnro_factura.LostFocus, txtNRO_LIQUI_DEVO_CARGO.LostFocus
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If

    End Sub

    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus

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

    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.GotFocus

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

    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidtipo_comprobante.GotFocus

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

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDUNIDAD_AGENCIA.KeyPress, cbidtipo_entrega.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.CBIDUNIDAD_AGENCIA_DESTINO.Focus()
        End If
    End Sub

    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub SeleccionarTodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarTodoToolStripMenuItem.Click
        Try
            objFACTURA.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin  ' Add el campo del usuario 
            For i As Integer = 0 To Me.dvListar_facturas.Count - 1

                objFACTURA.IDGUIAS_ENVIO = dvListar_facturas.Table.Rows(i)("idfactura")
                objFACTURA.IDTIPO_COMPROBANTE = dvListar_facturas.Table.Rows(i)("idtipo_comprobante")

                objFACTURA.SELECCIONAR_TO_FACTURA = 1
                'datahelper
                'objFACTURA.fn_UPDATE_SELEC_TO_DEVO(VOCONTROLUSUARIO, cnn)
                'objFACTURA.fn_UPDATE_SELEC_TO_DEVO()
                Me.dvListar_facturas.Table.Rows(i)("SELECCIONAR") = 1
            Next
            NUMERO = dvListar_facturas.Count
            Label23.Text = NUMERO
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub SeleccionarNingunoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarNingunoToolStripMenuItem.Click
        'If Me.rbproce.Checked Then
        '    If Not (Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue = "PEND" Or Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue = "ENOB") Then Exit Sub
        'End If
        For i As Integer = 0 To Me.dvListar_facturas.Count - 1

            objFACTURA.IDGUIAS_ENVIO = dvListar_facturas.Table.Rows(i)("idfactura")
            objFACTURA.IDTIPO_COMPROBANTE = dvListar_facturas.Table.Rows(i)("idtipo_comprobante")

            objFACTURA.SELECCIONAR_TO_FACTURA = 0
            'Datahelper
            'objFACTURA.fn_UPDATE_SELEC_TO_DEVO()
            '
            Me.dvListar_facturas.Table.Rows(i)("SELECCIONAR") = 0
        Next
        '
        NUMERO = 0
        '
        Label23.Text = IIf(NUMERO = 0, "", NUMERO)
    End Sub

    Private Sub InvertirSeleccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertirSeleccionToolStripMenuItem.Click
        Try
            For i As Integer = 0 To Me.dvListar_facturas.Count - 1
                If Me.dvListar_facturas.Table.Rows(i)("SELECCIONAR") = 0 Then

                    objFACTURA.IDGUIAS_ENVIO = dvListar_facturas.Table.Rows(i)("idfactura")
                    objFACTURA.IDTIPO_COMPROBANTE = dvListar_facturas.Table.Rows(i)("idtipo_comprobante")

                    objFACTURA.SELECCIONAR_TO_FACTURA = 1
                    'datahelper
                    'objFACTURA.fn_UPDATE_SELEC_TO_DEVO(VOCONTROLUSUARIO, cnn)
                    'objFACTURA.fn_UPDATE_SELEC_TO_DEVO()

                    Me.dvListar_facturas.Table.Rows(i)("SELECCIONAR") = 1

                Else
                    objFACTURA.IDGUIAS_ENVIO = dvListar_facturas.Table.Rows(i)("idfactura")
                    objFACTURA.IDTIPO_COMPROBANTE = dvListar_facturas.Table.Rows(i)("idtipo_comprobante")

                    objFACTURA.SELECCIONAR_TO_FACTURA = 0
                    'datahelper
                    'objFACTURA.fn_UPDATE_SELEC_TO_DEVO(VOCONTROLUSUARIO, cnn)
                    'objFACTURA.fn_UPDATE_SELEC_TO_DEVO()

                    Me.dvListar_facturas.Table.Rows(i)("SELECCIONAR") = 0
                End If
            Next
            NUMERO = 0
            For j As Long = 0 To dvListar_facturas.Count - 1
                If dvListar_facturas.Table.Rows(j)("SELECCIONAR") = 1 Then
                    NUMERO = NUMERO + 1
                End If
            Next
            Label23.Text = IIf(NUMERO = 0, "", NUMERO)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call imprimir_rpt()
    End Sub

    Private Sub txtNro_guia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNro_guia.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Dim serie As String
                Dim numero As String

                If InStr(txtNro_guia.Text, "-") <> 0 Then

                    serie = Mid(txtNro_guia.Text, 1, InStr(txtNro_guia.Text, "-") - 1)
                    numero = Mid(txtNro_guia.Text, InStr(txtNro_guia.Text, "-") + 1, Len(txtNro_guia.Text) - InStr(txtNro_guia.Text, "-"))

                    serie = LTrim(RTrim(serie))
                    numero = LTrim(RTrim(numero))

                    While Len(serie) < 3
                        serie = "0" + serie
                    End While

                    While Len(numero) < 7
                        numero = "0" + numero
                    End While

                    txtNro_guia.Text = serie + "-" + numero

                Else
                    numero = LTrim(RTrim(txtNro_guia.Text))
                    While Len(numero) < 13
                        numero = "0" + numero
                    End While
                    txtNro_guia.Text = numero
                End If

                For i As Integer = 0 To dvListar_facturas.Count - 1
                    If Replace(dvListar_facturas.Table.Rows(i)("NRO_FACTURA"), " ", "") = Replace(txtNro_guia.Text, " ", "") Then
                        dvListar_facturas.Table.Rows(i)("SELECCIONAR") = 1
                        txtNro_guia.SelectAll()



                        DGV3.CurrentCell = DGV3.Rows(i).Cells(1)
                        '
                        objFACTURA.IDGUIAS_ENVIO = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("idfactura")
                        objFACTURA.IDTIPO_COMPROBANTE = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("idtipo_comprobante")
                        '
                        objFACTURA.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin '11/11/2008 Usuario quien selecciona los dctos a devolver 
                        '
                        objFACTURA.SELECCIONAR_TO_FACTURA = 1
                        'datahelper
                        'objFACTURA.fn_UPDATE_SELEC_TO_DEVO(VOCONTROLUSUARIO, cnn)
                        'objFACTURA.fn_UPDATE_SELEC_TO_DEVO()
                        Exit Sub
                    End If
                Next
                MsgBox("No existe este número de documento en la lista", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.LostFocus, CBIDUNIDAD_AGENCIA_DESTINO.SelectionChangeCommitted
        Dim p_idunidad_agencia As Int64

        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
            p_idunidad_agencia = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Int64)
            'Datahelper
            objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(Me.cmbAgencia, p_idunidad_agencia)
            cmbUsuarios.DataSource = Nothing
        Else
            Me.cmbAgencia.DataSource = Nothing
            cmbUsuarios.DataSource = Nothing
        End If
        Me.cmbAgencia.SelectedIndex = -1


    End Sub
    Private Sub cmbAgencia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectionChangeCommitted, cmbAgencia.LostFocus
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

    Private Function imprimir_rpt_proce()

        If Me.DGV3.RowCount <= 0 Then
            MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
            Exit Function
        End If


        Dim IDfacturas As String = ""
        Dim IDtipo_comprobantes As String = ""
        Dim IDTIPO_RECEPCION_DOCUS As String = ""
        Dim AGENCIA As String
        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport

        For K As Integer = 0 To dvListar_facturas.Count - 1
            If dvListar_facturas.Table.Rows(K)("SELECCIONAR") = 1 Then

                IDfacturas = IDfacturas + dvListar_facturas.Table.Rows(K)("IDFACTURA").ToString + ","
                IDtipo_comprobantes = IDtipo_comprobantes + dvListar_facturas.Table.Rows(K)("IDTIPO_COMPROBANTE").ToString + ","

            End If
        Next

        If IDfacturas = "" Then
            MsgBox("No existen registro seleccionado", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
            Exit Function
        End If


        IDfacturas = Mid(IDfacturas, 1, Len(IDfacturas) - 1)
        IDtipo_comprobantes = Mid(IDtipo_comprobantes, 1, Len(IDtipo_comprobantes) - 1)


        Select Case Me.TabMante.SelectedIndex
            Case 0
                Try
                    If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                        objFACTURA.IDPERSONA = 0
                    Else
                        objFACTURA.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    End If

                    If Me.DTPFECHAINICIOFACTURA.Enabled = True Then objFACTURA.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else objFACTURA.FECHA_INICIO = "NULL"
                    If Me.DTPFECHAFINALFACTURA.Enabled = True Then objFACTURA.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else objFACTURA.FECHA_FINAL = "NULL"

                    If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                        objFACTURA.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
                    Else
                        objFACTURA.IDTIPO_COMPROBANTE = 0
                    End If

                    objFACTURA.IDTIPO_MONEDA = 0

                    If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                        objFACTURA.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
                    Else
                        objFACTURA.IDUSUARIO_PERSONAL = 0
                    End If

                    If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                        objFACTURA.IDAGENCIAS = cmbAgencia.SelectedValue
                        AGENCIA = "AGENCIA DESTINO: " + cmbAgencia.Text
                    Else
                        objFACTURA.IDAGENCIAS = 0
                        AGENCIA = ""
                    End If

                    If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                        objFACTURA.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
                    Else
                        objFACTURA.IDFORMA_PAGO = 0
                    End If

                    If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                        objFACTURA.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
                    Else
                        objFACTURA.IDUNIDAD_ORIGEN = 0
                    End If

                    If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                        objFACTURA.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
                    Else
                        objFACTURA.IDUNIDAD_DESTINO = 0
                    End If

                    If Len(Me.tbnro_factura.Text.Trim) = 0 Then
                        objFACTURA.NRO_FACTURA = 0
                    Else
                        objFACTURA.NRO_FACTURA = Me.tbnro_factura.Text.Trim
                    End If

                    objFACTURA.NRO_LIQUI_DEVO_CARGO = 0


                    If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                        objFACTURA.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
                    Else
                        objFACTURA.IDTIPO_ENTREGA = 0
                    End If

                    Dim TIPO_RECEPCION_DOCU As String = ""

                    Dim P_ENTRE As String

                    P_ENTRE = 0

                    If Me.rbimpri.Checked = True Then
                        IDTIPO_RECEPCION_DOCUS = "0"
                    Else
                        IDTIPO_RECEPCION_DOCUS = "DEVU"
                    End If

                    With objFACTURA

                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)

                        If Me.rbimpri.Checked = True Then

                            For i As Integer = 0 To dvListar_facturas.Count - 1
                                If dvListar_facturas.Table.Rows(i)("SELECCIONAR") = 1 Then
                                    objFACTURA.IDGUIAS_ENVIO = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("idfactura")
                                    objFACTURA.IDTIPO_COMPROBANTE = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("idtipo_comprobante")
                                    '
                                    objFACTURA.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin '11/11/2008 Usuario quien selecciona los dctos a devolver 
                                    '
                                    objFACTURA.SELECCIONAR_TO_FACTURA = 1
                                    'datahelper
                                    'objFACTURA.fn_UPDATE_SELEC_TO_DEVO(VOCONTROLUSUARIO, cnn)
                                    objFACTURA.fn_UPDATE_SELEC_TO_DEVO()
                                End If
                            Next

                            ObjReport.printrptB(False, "", "GUI018.RPT", _
                            "P_AGENCIA;" & AGENCIA + TIPO_RECEPCION_DOCU, _
                            "P_AGENCIA_VENTA;" & .agencia_venta, _
                            "p_idpersona;" & .IDPERSONA, _
                            "p_idforma_pago;" & .IDFORMA_PAGO, _
                            "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                            "p_idagencias;" & .IDAGENCIAS, _
                            "p_idagencias_session;" & dtoUSUARIOS.iIDAGENCIAS, _
                            "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                            "p_idusuario_personal_session;" & dtoUSUARIOS.IdLogin, _
                            "p_idunidad_origen;" & .IDUNIDAD_ORIGEN, _
                            "p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
                            "p_nro_factura;" & .NRO_FACTURA, _
                            "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
                            "p_fecha_inicial;" & .FECHA_INICIO, _
                            "p_fecha_final;" & .FECHA_FINAL, _
                            "p_idtipo_entrega;" & .IDTIPO_ENTREGA, _
                            "p_IDTIPO_RECEPCION_DOCU;" & .IDTIPO_RECEPCION_DOCU, _
                            "p_IDFACTURAS;" & IDfacturas, _
                            "p_IDtipo_recepcion_docuS;" & IDTIPO_RECEPCION_DOCUS, _
                            "p_idtipo_comprobantes;" & IDtipo_comprobantes, _
                            "ip_nro_liqui_devo_cargo;" & .NRO_LIQUI_DEVO_CARGO, _
                            "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                            "p_entre;" & P_ENTRE)

                            listar_facturas()

                        Else
                            If MsgBox("Esta seguro de hacer el cierre de liquidación con un total de " & Me.Label23.Text & _
                            " documentos:" & Chr(13) & "Si:  se hará el cierre y no podrá agregar mas cargos a este número de liquidación " & Chr(13) & _
                            "No: podrá agregar más cargos sin hacer el cierre" & Chr(13) & "Seguro que desea continuar...", MsgBoxStyle.YesNo, "Confirmación de Cierre de Devolución de Cargos") = MsgBoxResult.Yes Then

                                For i As Integer = 0 To dvListar_facturas.Count - 1
                                    If dvListar_facturas.Table.Rows(i)("SELECCIONAR") = 1 Then
                                        objFACTURA.IDGUIAS_ENVIO = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("idfactura")
                                        objFACTURA.IDTIPO_COMPROBANTE = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("idtipo_comprobante")
                                        '
                                        objFACTURA.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin '11/11/2008 Usuario quien selecciona los dctos a devolver 
                                        '
                                        objFACTURA.SELECCIONAR_TO_FACTURA = 1
                                        'datahelper
                                        'objFACTURA.fn_UPDATE_SELEC_TO_DEVO(VOCONTROLUSUARIO, cnn)
                                        objFACTURA.fn_UPDATE_SELEC_TO_DEVO()
                                    End If
                                Next
                                
                                ObjReport.printrptB(False, "", "GUI018.RPT", "P_AGENCIA;" & AGENCIA + TIPO_RECEPCION_DOCU, "P_AGENCIA_VENTA;" & .agencia_venta, _
                                                    "p_idpersona;" & .IDPERSONA, "p_idforma_pago;" & .IDFORMA_PAGO, "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                                                    "p_idagencias;" & .IDAGENCIAS, "p_idagencias_session;" & dtoUSUARIOS.iIDAGENCIAS, "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                                                    "p_idusuario_personal_session;" & dtoUSUARIOS.IdLogin, "p_idunidad_origen;" & .IDUNIDAD_ORIGEN, "p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
                                                    "p_nro_factura;" & .NRO_FACTURA, "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, "p_fecha_inicial;" & .FECHA_INICIO, _
                                                    "p_fecha_final;" & .FECHA_FINAL, "p_idtipo_entrega;" & .IDTIPO_ENTREGA, "p_IDTIPO_RECEPCION_DOCU;" & .IDTIPO_RECEPCION_DOCU, _
                                                    "p_IDFACTURAS;" & IDfacturas, "p_IDtipo_recepcion_docuS;" & IDTIPO_RECEPCION_DOCUS, "p_idtipo_comprobantes;" & IDtipo_comprobantes, _
                                                    "ip_nro_liqui_devo_cargo;" & .NRO_LIQUI_DEVO_CARGO, "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                                                    "p_entre;" & P_ENTRE)

                                listar_facturas()

                            End If

                        End If


                    End With
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
                End Try
        End Select
    End Function

    Private Sub btnacep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnacep.Click
        imprimir_rpt_proce()
    End Sub

    Private Sub rbproce_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbproce.CheckedChanged, rbimpri.CheckedChanged

        If Me.rbproce.Checked = True Then
            btnacep.Enabled = True
            Me.MenuStrip1.Items(6).Enabled = False
        Else
            btnacep.Enabled = False
            Me.MenuStrip1.Items(6).Enabled = True
        End If

        If Len(Me.txtNRO_LIQUI_DEVO_CARGO.Text) > 0 Then
            Me.rbimpri.Checked = True
        End If

    End Sub

    Private Sub cbIDTIPO_RECEPCION_DOCU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If IsNothing(Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue) Then Exit Sub

        'If Not (Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue = "PEND" Or Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue = "ENOB") Then
        '    Me.rbimpri.Checked = True
        'Else
        '    Me.rbproce.Checked = True
        'End If
    End Sub

    Private Sub AgregarDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarDocumentosToolStripMenuItem.Click
        Try
            If Me.DGV3.RowCount <= 0 Then
                MsgBox("Seleccione un elemento de la lista", MsgBoxStyle.Exclamation, "Seguridad del sistema")
                Exit Sub
            End If
            nFrmIngreCargoAdi = New FrmIngreCargoAdi
            nFrmIngreCargoAdi.sIDFACTURA = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDFACTURA").ToString
            nFrmIngreCargoAdi.sIDTipo_Comprobante = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("idtipo_comprobante").ToString
            'nFrmIngreCargoAdi.ShowDialog()

            Acceso.Asignar(nFrmIngreCargoAdi, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                nFrmIngreCargoAdi.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtNRO_LIQUI_DEVO_CARGO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNRO_LIQUI_DEVO_CARGO.TextChanged
        If Len(txtNRO_LIQUI_DEVO_CARGO.Text) = 0 Then
            bloquer_x_nro_liquidacion(True)

            Me.habilitar_por_roles()


        Else
            bloquer_x_nro_liquidacion(False)

        End If
    End Sub

    Private Sub DGV3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV3.KeyUp
        Try
            If e.KeyCode = Keys.Space Then

                If DGV3.RowCount <= 0 Then Exit Sub

                Dim a As DataRowView = Me.dvListar_facturas.Item(Me.DGV3.CurrentRow.Index)

                objFACTURA.IDGUIAS_ENVIO = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("idfactura")
                objFACTURA.IDTIPO_COMPROBANTE = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("idtipo_comprobante")
                objFACTURA.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin '11/11/2008 Usuario quien selecciona los dctos a devolver 

                'If dvListar_facturas.Table.Rows(DGV1.CurrentRow.Index)("LIQUIDADO") = 0 Then
                '    MsgBox("La Guia aun no esta liquidada...", MsgBoxStyle.Information, "Seguridad del Sistema")
                '    DGV1.RefreshEdit()
                '    Exit Sub
                'End If
                'If dvListar_guias.Table.Rows(DGV1.CurrentRow.Index)("FACTURADO") = 1 Then
                '    MsgBox("La Guia ya esta facturado...", MsgBoxStyle.Information, "Seguridad del Sistema")
                '    DGV1.RefreshEdit()
                '    Exit Sub
                'End If
                If a("SELECCIONAR") = 0 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 0 Then
                        dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("SELECCIONAR") = 1
                        DGV3.RefreshEdit()

                        objFACTURA.SELECCIONAR_TO_FACTURA = 1
                        'datahelper
                        'objFACTURA.fn_UPDATE_SELEC_TO_DEVO(VOCONTROLUSUARIO, cnn)
                        'objFACTURA.fn_UPDATE_SELEC_TO_DEVO()
                        Exit Sub
                    End If
                End If

                If a("SELECCIONAR") = 1 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 1 Then

                        dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("SELECCIONAR") = 0
                        DGV3.RefreshEdit()

                        objFACTURA.SELECCIONAR_TO_FACTURA = 0
                        'datahelper
                        'objFACTURA.fn_UPDATE_SELEC_TO_DEVO(VOCONTROLUSUARIO, cnn)
                        'objFACTURA.fn_UPDATE_SELEC_TO_DEVO()
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try


    End Sub

    Private Sub DGV3_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV3.CellMouseUp
        Try
            If IsNothing(dvListar_facturas) Then Exit Sub
            If DGV3.RowCount <= 0 Then Exit Sub
            If e.RowIndex < 0 Then Exit Sub
            If DGV3.CurrentCell.ColumnIndex <> 0 Then Exit Sub
            'If Me.rbproce.Checked Then
            '    If Not (Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue = "PEND" Or Me.cbIDTIPO_RECEPCION_DOCU.SelectedValue = "ENOB") Then Exit Sub
            'End If



            objFACTURA.IDGUIAS_ENVIO = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("idfactura")
            objFACTURA.IDTIPO_COMPROBANTE = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("idtipo_comprobante")
            objFACTURA.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin '11/11/2008 Usuario quien selecciona los dctos a devolver 



            If Not e.Button = Windows.Forms.MouseButtons.Left Then Exit Sub
            If dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("SELECCIONAR") = 1 Then
                dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("SELECCIONAR") = 0

                objFACTURA.SELECCIONAR_TO_FACTURA = 0
                'datahelper
                'objFACTURA.fn_UPDATE_SELEC_TO_DEVO(VOCONTROLUSUARIO, cnn)
                'objFACTURA.fn_UPDATE_SELEC_TO_DEVO()
            Else
                dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("SELECCIONAR") = 1


                objFACTURA.SELECCIONAR_TO_FACTURA = 1
                'datahelper
                'objFACTURA.fn_UPDATE_SELEC_TO_DEVO(VOCONTROLUSUARIO, cnn)
                'objFACTURA.fn_UPDATE_SELEC_TO_DEVO()
            End If
            NUMERO = 0
            For j As Long = 0 To dvListar_facturas.Count - 1
                If dvListar_facturas.Table.Rows(j)("SELECCIONAR") = 1 Then
                    NUMERO = NUMERO + 1
                End If
            Next

            Label23.Text = IIf(NUMERO = 0, "", NUMERO)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

    End Sub

    Private Sub chkENOB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkENOB.CheckedChanged, chkDEVO.CheckedChanged, chkENCO.CheckedChanged, chkPEND.CheckedChanged, rbimpri.CheckedChanged, rbproce.CheckedChanged
        If Not ((Me.chkPEND.Checked Or Me.chkENOB.Checked) And Not (Me.chkDEVO.Checked Or Me.chkENCO.Checked)) Then

            Me.rbimpri.Checked = True

        End If
    End Sub
    Private Sub bloquer_x_nro_liquidacion(ByVal p_valor As Boolean)

        txtCodigoCliente.Enabled = p_valor
        Me.txtCodigoCliente.Text = ""
        txtidpersona.Enabled = p_valor
        txtidpersona.Text = ""
        DTPFECHAINICIOFACTURA.Enabled = p_valor
        DTPFECHAFINALFACTURA.Enabled = p_valor
        cbidtipo_comprobante.Enabled = p_valor
        cbidtipo_comprobante.SelectedIndex = -1
        cbidforma_pago.Enabled = p_valor
        cbidforma_pago.SelectedIndex = -1
        tbnro_factura.Enabled = p_valor
        tbnro_factura.Text = ""
        CBIDUNIDAD_AGENCIA.Enabled = p_valor
        CBIDUNIDAD_AGENCIA.SelectedIndex = -1
        CBIDUNIDAD_AGENCIA_DESTINO.Enabled = p_valor
        CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
        cmbAgencia.Enabled = p_valor
        cmbAgencia.SelectedIndex = -1
        cmbUsuarios.Enabled = p_valor
        cmbUsuarios.SelectedIndex = -1
        chkENCO.Enabled = p_valor
        chkENCO.Checked = False
        chkENOB.Enabled = p_valor
        chkENOB.Checked = False
        chkDEVO.Enabled = p_valor
        chkDEVO.Checked = False
        chkPEND.Enabled = p_valor
        chkPEND.Checked = False
        cbidtipo_entrega.Enabled = p_valor
        cbidtipo_entrega.SelectedIndex = -1
    End Sub

    Private Sub txtNro_guia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNro_guia.TextChanged

    End Sub

    Private Sub tbnro_factura_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbnro_factura.TextChanged

    End Sub
End Class
