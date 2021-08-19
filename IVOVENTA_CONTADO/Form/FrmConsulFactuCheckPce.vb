Public Class FrmConsulFactuCheckPce
    '
    Dim dvidtipo_entrega As New DataView
    Dim dvfacturas_guias As New DataView
    Dim dvListar_facturas As New DataView
    '
    Dim Colllistar_persona_todos As New Collection
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection
    '
    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL
    '
    Dim dvlistar_persona_todos As New DataView
    Dim dvlistar_tipo_moneda As New DataView
    '
    Dim dvlistar_forma_pago As New DataView
    '
    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim ObjFactura As New ClsLbTepsa.dtoFACTURA
    Dim bIngreso As Boolean
    Public hnd As Long
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        listar_facturas()
    End Sub
    Private Sub listar_facturas()
        Try




            'If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            '    ObjFactura.IDPERSONA = 0
            'Else

            '    ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            'End If
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"

            If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                ObjFactura.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
            Else
                ObjFactura.IDTIPO_COMPROBANTE = 0
            End If

            ObjFactura.SERIE_FACTURA = Mid(Me.MTBNro_factura.Text, 1, 3)
            ObjFactura.NRO_FACTURA = Mid(Me.MTBNro_factura.Text, 5, 7)

            ObjFactura.SERIE_FACTURA = IIf(ObjFactura.SERIE_FACTURA.Trim = "", 0, ObjFactura.SERIE_FACTURA.Trim)
            ObjFactura.NRO_FACTURA = IIf(ObjFactura.NRO_FACTURA.Trim = "", 0, ObjFactura.NRO_FACTURA.Trim)



            ObjFactura.IDTIPO_MONEDA = 0
            'If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
            '    ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
            'Else
            '    ObjFactura.IDUSUARIO_PERSONAL = 0
            'End If

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

            'If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
            '    ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            'Else
            '    ObjFactura.IDFORMA_PAGO = 0
            'End If
            'If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
            '    ObjFactura.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            'Else
            '    ObjFactura.IDUNIDAD_ORIGEN = 0
            'End If

            'If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
            '    ObjFactura.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            'Else
            '    ObjFactura.IDUNIDAD_DESTINO = 0
            'End If

            If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                ObjFactura.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
            Else
                ObjFactura.IDTIPO_ENTREGA = 0
            End If

            'Dim P_ENTRE As String

            'If Me.RBENTRE.Checked = True Then
            '    P_ENTRE = 1
            'ElseIf Me.RBSIN_ENTRE.Checked = True Then
            '    P_ENTRE = 0
            'Else
            '    P_ENTRE = 2
            'End If

            If Not IsNothing(Me.CBIDAGENCIAS_DESTINO.SelectedValue) Then
                ObjFactura.IDAGENCIAS_DESTINO = Me.CBIDAGENCIAS_DESTINO.SelectedValue
            Else
                ObjFactura.IDAGENCIAS_DESTINO = 0
            End If
            'datahelper
            dvListar_facturas = ObjFactura.sp_L_CARGA_CONTA_CHECK_PCE()
            FORMAT_GRILLA3()
            Me.txtsub_total.Text = 0
            Me.txtmonto_impuesto.Text = 0
            Me.txttotal_costo.Text = 0

            For i As Integer = 0 To dvListar_facturas.Table.Rows.Count - 1
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
            .Visible = False
        End With
        Dim SERIE_FACTURA As New DataGridViewTextBoxColumn

        With SERIE_FACTURA
            .HeaderText = "SERIE_FACTURA"
            .Name = "SERIE_FACTURA"
            .DataPropertyName = "SERIE_FACTURA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With
        Dim NRO_FACTURA As New DataGridViewTextBoxColumn

        With NRO_FACTURA
            .HeaderText = "NRO_FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            .Width = 120
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With
        Dim FECHA_FACTURA As New DataGridViewTextBoxColumn

        With FECHA_FACTURA
            .HeaderText = "FECHA_FACTURA"
            .Name = "FECHA_FACTURA"
            .DataPropertyName = "FECHA_FACTURA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With
        Dim FECHA_ENTREGA As New DataGridViewTextBoxColumn

        With FECHA_ENTREGA
            .HeaderText = "FECHA_ENTREGA"
            .Name = "FECHA_ENTREGA"
            .DataPropertyName = "FECHA_ENTREGA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .DefaultCellStyle.Format = "d"
            .ReadOnly = False
            .Visible = True
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
            .Visible = True
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
            .Visible = True
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
            .Visible = True
        End With
        Dim TOTAL_PESO As New DataGridViewTextBoxColumn

        With TOTAL_PESO
            .HeaderText = "TOTAL_PESO"
            .Name = "TOTAL_PESO"
            .DataPropertyName = "TOTAL_PESO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim TOTAL_VOLUMEN As New DataGridViewTextBoxColumn

        With TOTAL_VOLUMEN
            .HeaderText = "TOTAL_VOLUMEN"
            .Name = "TOTAL_VOLUMEN"
            .DataPropertyName = "TOTAL_VOLUMEN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim TOTAL_ARTICULO As New DataGridViewTextBoxColumn

        With TOTAL_ARTICULO
            .HeaderText = "TOTAL_ARTICULO"
            .Name = "TOTAL_ARTICULO"
            .DataPropertyName = "TOTAL_ARTICULO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim CANTIDAD As New DataGridViewTextBoxColumn

        With CANTIDAD
            .HeaderText = "CANTIDAD"
            .Name = "CANTIDAD"
            .DataPropertyName = "CANTIDAD"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim CANTIDAD_X_VOLUMEN As New DataGridViewTextBoxColumn

        With CANTIDAD_X_VOLUMEN
            .HeaderText = "CANTIDAD_X_VOLUMEN"
            .Name = "CANTIDAD_X_VOLUMEN"
            .DataPropertyName = "CANTIDAD_X_VOLUMEN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim CANTIDAD_X_UNIDAD_ARTI As New DataGridViewTextBoxColumn

        With CANTIDAD_X_UNIDAD_ARTI
            .HeaderText = "CANTIDAD_X_UNIDAD_ARTI"
            .Name = "CANTIDAD_X_UNIDAD_ARTI"
            .DataPropertyName = "CANTIDAD_X_UNIDAD_ARTI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim CANTIDAD_X_SOBRE As New DataGridViewTextBoxColumn

        With CANTIDAD_X_SOBRE
            .HeaderText = "CANTIDAD_X_SOBRE"
            .Name = "CANTIDAD_X_SOBRE"
            .DataPropertyName = "CANTIDAD_X_SOBRE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
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
            .Visible = True
        End With
        Dim NOMBRE_AGENCIA_ORI As New DataGridViewTextBoxColumn

        With NOMBRE_AGENCIA_ORI
            .HeaderText = "NOMBRE_AGENCIA_ORI"
            .Name = "NOMBRE_AGENCIA_ORI"
            .DataPropertyName = "NOMBRE_AGENCIA_ORI"
            .Width = 500
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With
        Dim IDAGENCIAS_DESTINO As New DataGridViewTextBoxColumn

        With IDAGENCIAS_DESTINO
            .HeaderText = "IDAGENCIAS_DESTINO"
            .Name = "IDAGENCIAS_DESTINO"
            .DataPropertyName = "IDAGENCIAS_DESTINO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim NOMBRE_AGENCIA_DESTI As New DataGridViewTextBoxColumn

        With NOMBRE_AGENCIA_DESTI
            .HeaderText = "NOMBRE_AGENCIA_DESTI"
            .Name = "NOMBRE_AGENCIA_DESTI"
            .DataPropertyName = "NOMBRE_AGENCIA_DESTI"
            .Width = 500
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With
        Dim IDESTADO_FACTURA As New DataGridViewTextBoxColumn

        With IDESTADO_FACTURA
            .HeaderText = "IDESTADO_FACTURA"
            .Name = "IDESTADO_FACTURA"
            .DataPropertyName = "IDESTADO_FACTURA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn

        With ESTADO_REGISTRO
            .HeaderText = "ESTADO_REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With
        Dim IDESTADO_ENVIO As New DataGridViewTextBoxColumn

        With IDESTADO_ENVIO
            .HeaderText = "IDESTADO_ENVIO"
            .Name = "IDESTADO_ENVIO"
            .DataPropertyName = "IDESTADO_ENVIO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim ESTADO_REGISTRO_ENVIO As New DataGridViewTextBoxColumn

        With ESTADO_REGISTRO_ENVIO
            .HeaderText = "ESTADO_REGISTRO_ENVIO"
            .Name = "ESTADO_REGISTRO_ENVIO"
            .DataPropertyName = "ESTADO_REGISTRO_ENVIO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With
        Dim IDPERSONA As New DataGridViewTextBoxColumn

        With IDPERSONA
            .HeaderText = "IDPERSONA"
            .Name = "IDPERSONA"
            .DataPropertyName = "IDPERSONA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn

        With RAZON_SOCIAL
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With
        Dim NU_DOCU_SUNA As New DataGridViewTextBoxColumn

        With NU_DOCU_SUNA
            .HeaderText = "NU_DOCU_SUNA"
            .Name = "NU_DOCU_SUNA"
            .DataPropertyName = "NU_DOCU_SUNA"
            .Width = 40000
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
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
            .Visible = True
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn

        With LOGIN
            .HeaderText = "LOGIN"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .Width = 150
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With
        Dim USUARIO As New DataGridViewTextBoxColumn

        With USUARIO
            .HeaderText = "USUARIO"
            .Name = "USUARIO"
            .DataPropertyName = "USUARIO"
            .Width = 1220
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With
        Dim IDTIPO_ENTREGA As New DataGridViewTextBoxColumn

        With IDTIPO_ENTREGA
            .HeaderText = "IDTIPO_ENTREGA"
            .Name = "IDTIPO_ENTREGA"
            .DataPropertyName = "IDTIPO_ENTREGA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim TIPO_ENTREGA As New DataGridViewTextBoxColumn

        With TIPO_ENTREGA
            .HeaderText = "TIPO_ENTREGA"
            .Name = "TIPO_ENTREGA"
            .DataPropertyName = "TIPO_ENTREGA"
            .Width = 400
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
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
            .Visible = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn

        With FORMA_PAGO
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .Width = 300
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With
        Dim IDTIPO_COMPROBANTE As New DataGridViewTextBoxColumn

        With IDTIPO_COMPROBANTE
            .HeaderText = "IDTIPO_COMPROBANTE"
            .Name = "IDTIPO_COMPROBANTE"
            .DataPropertyName = "IDTIPO_COMPROBANTE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn

        With TIPO_COMPROBANTE
            .HeaderText = "TIPO_COMPROBANTE"
            .Name = "TIPO_COMPROBANTE"
            .DataPropertyName = "TIPO_COMPROBANTE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With
        Dim IDUNIDAD_ORIGEN As New DataGridViewTextBoxColumn

        With IDUNIDAD_ORIGEN
            .HeaderText = "IDUNIDAD_ORIGEN"
            .Name = "IDUNIDAD_ORIGEN"
            .DataPropertyName = "IDUNIDAD_ORIGEN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim NOMBRE_UNIDAD As New DataGridViewTextBoxColumn

        With NOMBRE_UNIDAD
            .HeaderText = "NOMBRE_UNIDAD"
            .Name = "NOMBRE_UNIDAD"
            .DataPropertyName = "NOMBRE_UNIDAD"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With
        Dim IDUNIDAD_DESTINO As New DataGridViewTextBoxColumn

        With IDUNIDAD_DESTINO
            .HeaderText = "IDUNIDAD_DESTINO"
            .Name = "IDUNIDAD_DESTINO"
            .DataPropertyName = "IDUNIDAD_DESTINO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With
        Dim NOMBRE_UNIDAD_DESTINO As New DataGridViewTextBoxColumn

        With NOMBRE_UNIDAD_DESTINO
            .HeaderText = "NOMBRE_UNIDAD_DESTINO"
            .Name = "NOMBRE_UNIDAD_DESTINO"
            .DataPropertyName = "NOMBRE_UNIDAD_DESTINO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
        End With


        With DGV3
            .Columns.AddRange(IDFACTURA, _
            FECHA_ENTREGA, _
            FECHA_FACTURA, _
            SERIE_FACTURA, _
            NRO_FACTURA, _
            ESTADO_REGISTRO_ENVIO, _
            TIPO_COMPROBANTE, _
            ESTADO_REGISTRO, _
            RAZON_SOCIAL, _
            NOMBRE_UNIDAD, _
            NOMBRE_UNIDAD_DESTINO, _
            SUB_TOTAL, _
            TOTAL_COSTO, _
            MONTO_IMPUESTO _
            )
            'TOTAL_VOLUMEN, _
            'TOTAL_PESO _
            'TOTAL_ARTICULO, _
            'CANTIDAD, _
            'CANTIDAD_X_VOLUMEN, _
            'CANTIDAD_X_UNIDAD_ARTI, _
            'CANTIDAD_X_SOBRE, _
            'IDAGENCIAS, _
            'NOMBRE_AGENCIA_ORI, _
            'IDAGENCIAS_DESTINO, _
            'NOMBRE_AGENCIA_DESTI, _
            'IDESTADO_FACTURA, _
            'ESTADO_REGISTRO, _
            'IDESTADO_ENVIO, _
            'ESTADO_REGISTRO_ENVIO, _
            'IDPERSONA, _
            'NU_DOCU_SUNA, _
            'IDUSUARIO_PERSONAL, _
            'LOGIN, _
            'USUARIO, _
            'IDTIPO_ENTREGA, _
            'TIPO_ENTREGA, _
            'IDFORMA_PAGO, _
            'FORMA_PAGO, _
            'IDTIPO_COMPROBANTE, _
            'TIPO_COMPROBANTE, _
            'IDUNIDAD_ORIGEN, _
            'NOMBRE_UNIDAD_DESTINO)


        End With
    End Sub

    Private Sub FrmConsulFactuCheckPce_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Verificación de PCE"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = True
            Me.MenuStrip1.Items(3).Enabled = True
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False


            cnnSQL.Open()


            'objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
            'dvlistar_forma_pago.RowFilter = "idforma_pago <> 2"
            'cbidforma_pago.DataSource = dvlistar_forma_pago
            'cbidforma_pago.DisplayMember = "FORMA_PAGO"
            'cbidforma_pago.ValueMember = "IDFORMA_PAGO"

            ''Mod.17/09/2009 -->Omendoza - Pasando al datahelper   - No se considera el objeto VOCONTROLUSUARIO 
            'objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
            objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante)
            '
            dvlistar_forma_pago.RowFilter = "IDTIPO_COMPROBANTE = 1 or IDTIPO_COMPROBANTE = 2 or IDTIPO_COMPROBANTE = 3"

            'objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
            objgeneral.FN_cmb_Listar_agencias(Me.CBIDAGENCIAS_DESTINO)
            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0
            '
            'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            '
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            'ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)



            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA)
            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA_DESTINO)
            '
            'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
            '
            objgeneral.fn_L_TIPO_ENTREGA(dvidtipo_entrega, Me.cbidtipo_entrega)
            '
            'Me.cbidforma_pago.SelectedIndex = -1
            Me.cbidtipo_comprobante.SelectedIndex = -1
            'Me.cmbAgencia.SelectedIndex = -1
            'Me.cmbUsuarios.SelectedIndex = -1
            'Me.CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            'Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
            Me.cbidtipo_entrega.SelectedIndex = -1
            Me.CBIDAGENCIAS_DESTINO.SelectedIndex = -1


            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
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

                    Dim titulo_fecha As String


                    If Me.DGV3.RowCount <= 0 Then
                        MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                        Exit Sub
                    End If
                    Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

                    If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
                    If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"

                    If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                        ObjFactura.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
                    Else
                        ObjFactura.IDTIPO_COMPROBANTE = 0
                    End If

                    ObjFactura.SERIE_FACTURA = Mid(Me.MTBNro_factura.Text, 1, 3)
                    ObjFactura.NRO_FACTURA = Mid(Me.MTBNro_factura.Text, 5, 7)

                    ObjFactura.SERIE_FACTURA = IIf(ObjFactura.SERIE_FACTURA.Trim = "", 0, ObjFactura.SERIE_FACTURA.Trim)
                    ObjFactura.NRO_FACTURA = IIf(ObjFactura.NRO_FACTURA.Trim = "", 0, ObjFactura.NRO_FACTURA.Trim)



                    ObjFactura.IDTIPO_MONEDA = 0
                    'If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                    '    ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
                    'Else
                    '    ObjFactura.IDUSUARIO_PERSONAL = 0
                    'End If

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

                    'If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                    '    ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
                    'Else
                    '    ObjFactura.IDFORMA_PAGO = 0
                    'End If
                    'If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                    '    ObjFactura.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
                    'Else
                    '    ObjFactura.IDUNIDAD_ORIGEN = 0
                    'End If

                    'If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                    '    ObjFactura.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
                    'Else
                    '    ObjFactura.IDUNIDAD_DESTINO = 0
                    'End If

                    If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                        ObjFactura.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
                    Else
                        ObjFactura.IDTIPO_ENTREGA = 0
                    End If

                    'Dim P_ENTRE As String

                    'If Me.RBENTRE.Checked = True Then
                    '    P_ENTRE = 1
                    'ElseIf Me.RBSIN_ENTRE.Checked = True Then
                    '    P_ENTRE = 0
                    'Else
                    '    P_ENTRE = 2
                    'End If



                    With ObjFactura

                        .IDFACTURA = Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("IDFACTURA")

                        Try
                            ObjReport.Dispose()
                        Catch
                        End Try

                        If Me.DTPFECHAINICIOFACTURA.Enabled = True Then titulo_fecha = "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")" Else titulo_fecha = ""

                        ObjReport = New ClsLbTepsa.dtoFrmReport
                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)

                        'If Me.RBGENE.Checked = True Then
                        ObjReport.printrptB(False, "", "FAC015.RPT", _
                        "p_serie_factura;" & .SERIE_FACTURA, _
                        "p_nro_factura;" & .NRO_FACTURA, _
                        "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
                        "p_fecha_ini;" & .FECHA_INICIO, _
                        "p_fecha_final;" & .FECHA_FINAL, _
                        "p_titulo_fecha;" & titulo_fecha, _
                        "P_IDTIPO_ENTREGA;" & .IDTIPO_ENTREGA)
                        'Else
                        '    ObjReport.printrptB(False, "", "FAC011.RPT", _
                        '     "p_idpersona;" & .IDPERSONA, _
                        '     "p_idforma_pago;" & .IDFORMA_PAGO, _
                        '     "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                        '     "p_idagencias;" & .IDAGENCIAS, _
                        '     "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                        '     "p_idunidad_origen;" & .IDUNIDAD_ORIGEN, _
                        '     "p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
                        '     "p_nro_factura;" & .NRO_FACTURA, _
                        '     "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
                        '     "p_fecha_inicial;" & .FECHA_INICIO, _
                        '     "p_fecha_final;" & .FECHA_FINAL, _
                        '     "p_idtipo_entrega;" & .IDTIPO_ENTREGA, _
                        '     "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                        '     "p_entre;" & P_ENTRE)
                        'End If

                    End With
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
                End Try
        End Select
    End Sub

    Private Sub FrmConsulFactuEmiti_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub

    Private Sub txtidpersona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
    DTPFECHAINICIOFACTURA.GotFocus, _
    DTPFECHAFINALFACTURA.GotFocus, _
 _
        cbidtipo_entrega.GotFocus

        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    'Private Sub txtidpersona_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = 13 Then
    '        'If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
    '        With ObjPersona
    '            .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
    '            .IDTIPO_PERSONA = 0
    '            .CODIGO_CLIENTE = "NULL"
    '            ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, .IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
    '            'Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
    '            Me.DTPFECHAINICIOFACTURA.Focus()
    '        End With
    '        Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
    '    Else
    '        'Me.txtCodigoCliente.Text = ""
    '    End If
    '    End If
    'End Sub

    'Private Sub txtidpersona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
    '        Me.txtidpersona.Text = ""
    '        Me.txtCodigoCliente.Text = ""
    '    End If
    'End Sub

    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    'Private Sub txtCodigoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Try
    '        If e.KeyChar = Chr(13) Then

    '            ObjPersona.CODIGO_CLIENTE = Trim(Me.txtCodigoCliente.Text)
    '            ObjPersona.IDTIPO_PERSONA = 0
    '            ObjPersona.IDPERSONA = 0

    '            If Len(ObjPersona.CODIGO_CLIENTE) = 0 Then
    '                Me.txtCodigoCliente.Text = ""
    '                Me.txtidpersona.Text = ""
    '                Exit Sub
    '            End If

    '            If ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
    '                Me.txtidpersona.Text = ObjPersona.RAZON_SOCIAL
    '                Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
    '                txtidpersona.Focus()
    '            Else
    '                MsgBox("No existe el cliente", MsgBoxStyle.Information, "Segurdiad del Sistema")
    '                Me.txtidpersona.Text = ""
    '            End If
    '        End If
    '    Catch EX As Exception
    '        MsgBox(EX.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub

    'Private Sub tbnro_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = Chr(13) Then
    '        Me.cmbAgencia.Focus()
    '    End If
    'End Sub

    'Private Sub txtCodigoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
    '        Me.txtidpersona.Text = ""
    '        Me.txtCodigoCliente.Text = ""
    '    End If
    'End Sub



    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAINICIOFACTURA.KeyPress

    End Sub

    Private Sub DTPFECHAINICIOFACTURA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPFECHAINICIOFACTURA.KeyUp
        If e.KeyCode = Keys.Enter Then
            DTPFECHAFINALFACTURA.Focus()
        End If
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged

    End Sub

    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.GotFocus
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress

    End Sub



    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidtipo_comprobante.GotFocus
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    'Private Sub cbidtipo_moneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_comprobante.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        Me.cbidforma_pago.Focus()
    '    End If
    'End Sub

    'Private Sub cbidforma_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidforma_pago.GotFocus
    '    Me.txtsub_total.Text = 0
    '    Me.txtmonto_impuesto.Text = 0
    '    Me.txttotal_costo.Text = 0
    '    DGV3.DataSource = Nothing
    'End Sub

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

    Private Sub cbidforma_pago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub tbnro_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbidtipo_entrega_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbidtipo_entrega.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.MTBNro_factura.Focus()
        End If
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

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)


    End Sub



    Private Sub DTPEdi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FrmConsulFactuCheckPce_MenuGrabar() Handles Me.MenuGrabar

        Me.MTBNro_factura.Focus()

        Dim ObjFactura As ClsLbTepsa.dtoFACTURA = New ClsLbTepsa.dtoFACTURA

        ObjFactura.IDFACTURA = Me.DGV3.CurrentRow.Cells("IDFACTURA").Value
        If IsDBNull(Me.DGV3.CurrentRow.Cells("FECHA_ENTREGA").Value) Then ObjFactura.FECHA_ENTREGA = "NULL" Else ObjFactura.FECHA_ENTREGA = Me.DGV3.CurrentRow.Cells("FECHA_ENTREGA").Value
        ObjFactura.IPMOD = dtoUSUARIOS.m_sIP
        ObjFactura.IDROL_USUARIOMOD = dtoUSUARIOS.m_iIdRol
        ObjFactura.IDUSUARIO_PERSONALMOD = dtoUSUARIOS.IdLogin
        'Datahelper
        ObjFactura.SP_ENTREGAR_BULTO()

    End Sub

    Private Sub ChkRangoFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRangoFecha.CheckedChanged
        If ChkRangoFecha.Checked = True Then
            Me.DTPFECHAFINALFACTURA.Enabled = True
            Me.DTPFECHAINICIOFACTURA.Enabled = True
        Else
            Me.DTPFECHAFINALFACTURA.Enabled = False
            Me.DTPFECHAINICIOFACTURA.Enabled = False
        End If
    End Sub

    Private Sub cbidtipo_comprobante_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbidtipo_comprobante.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.cbidtipo_entrega.Focus()
        End If
    End Sub

    Private Sub cbidtipo_comprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidtipo_comprobante.SelectedIndexChanged

    End Sub

    Private Sub MTBNro_factura_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MTBNro_factura.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.Button3.Focus()
        End If

    End Sub

    Private Sub MTBNro_factura_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MTBNro_factura.MaskInputRejected

    End Sub

    Private Sub DTPFECHAFINALFACTURA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPFECHAFINALFACTURA.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.cbidtipo_comprobante.Focus()
        End If
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged

    End Sub

    Private Sub CBIDAGENCIAS_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CBIDAGENCIAS_DESTINO.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.DTPFECHAINICIOFACTURA.Focus()
        End If
    End Sub

    Private Sub CBIDAGENCIAS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDAGENCIAS_DESTINO.SelectedIndexChanged

    End Sub

    Private Sub BtnActu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActu.Click
        For i As Integer = 0 To dvListar_facturas.Count - 1
            Try
                Dim DV As New DataView
                ObjFactura.IDFACTURA = dvListar_facturas.Table.Rows(i)("IDFACTURA")
                ObjFactura.SERIE_FACTURA = dvListar_facturas.Table.Rows(i)("SERIE_FACTURA")
                ObjFactura.NRO_FACTURA = dvListar_facturas.Table.Rows(i)("NRO_FACTURA")
                'ObjFactura.SERIE_FACTURA = 907
                'ObjFactura.NRO_FACTURA = 125155
                DV = ObjFactura.RGT_BUSCA_FECHA_PAGO_PCE(cnnSQL)
                If DV.Count > 0 Then
                    If Not DV.Table.Rows(0).IsNull("fe_oper") Then ObjFactura.FECHA_ENTREGA = DV.Table.Rows(0)("fe_oper") Else ObjFactura.FECHA_ENTREGA = 0
                    'datahelper
                    ObjFactura.sp_upda_fecha_entre_pce()
                End If
            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad del Sistema")
            Catch exo As System.Data.OracleClient.OracleException
                MsgBox(exo.ToString, MsgBoxStyle.Exclamation, "Seguridad del Sistema")

            End Try
        Next

        MsgBox("Proceso terminado correctamente...", MsgBoxStyle.Information, "Seguridad del Sistema")
        listar_facturas()
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged, GrabarToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
