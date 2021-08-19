Public Class FrmConsulPreFactuEmi

    Dim dvPrefacturas_guias As New DataView
    Dim dvListar_Prefacturas As New DataView

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
    'hlamas 17-09-2013 personalizado quimica suiza
    Dim ID_PERSONA_QUIMICA_SUIZA As Integer = 1290

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

            ObjFactura.IDTIPO_MONEDA = 0

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

            ObjFactura.IDFORMA_PAGO = 0

            If Me.rbfactu.Checked = True Then
                ObjFactura.FACTURADO = 1
            ElseIf Me.rbpendi.Checked = True Then
                ObjFactura.FACTURADO = 0
            Else
                ObjFactura.FACTURADO = 2
            End If

            ObjFactura.NRO_PREFACTURA = Me.TBNRO_PREFACTURA.Text.ToString.Trim
            ObjFactura.Producto = Me.cmbProducto.SelectedValue

            If Me.RBPREFACTU.Checked = True Then
                'datahelper
                'dvListar_Prefacturas = ObjFactura.FN_ConsulPreFactuEmi(cnn)
                dvListar_Prefacturas = ObjFactura.FN_ConsulPreFactuEmi()
            Else
                'datahelpe
                'dvListar_Prefacturas = ObjFactura.FN_ConsulPreFactuEmi_(cnn)
                dvListar_Prefacturas = ObjFactura.FN_ConsulPreFactuEmi_()
            End If
            FORMAT_GRILLA3()
            dgv4.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DGV3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellEnter
        Try
            Dim obj As New ClsLbTepsa.dtoFACTURA
            With obj
                .IDPREFACTURA = dvListar_Prefacturas.Table.Rows(DGV3.CurrentRow.Index)("IDPREFACTURA")
                'datahelper
                'dvPrefacturas_guias = .FNPREFACTURAS_GUIAS(VOCONTROLUSUARIO)
                dvPrefacturas_guias = .FNPREFACTURAS_GUIAS()
                Call FORMAT_GRILLA4()
            End With
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
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
            .DataSource = dvPrefacturas_guias
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "NOMBRE AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .Width = 130
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "RAZON SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 240
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NRO_GUIA As New DataGridViewTextBoxColumn
        With NRO_GUIA
            .HeaderText = "NRO GUIA"
            .Name = "NRO_GUIA"
            .DataPropertyName = "NRO_GUIA"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
        End With
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            .Width = 60
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUBTOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "IMPUESTOS"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With




        Dim SERIE_GUIA_ENVIO As New DataGridViewTextBoxColumn
        With SERIE_GUIA_ENVIO
            .HeaderText = "SERIE GUIA"
            .Name = "SERIE_GUIA_ENVIO"
            .DataPropertyName = "SERIE_GUIA_ENVIO"
            .Width = 30
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "LOGIN"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim CARGO As New DataGridViewTextBoxColumn
        With CARGO
            .HeaderText = "CARGO"
            .Name = "CARGO"
            .DataPropertyName = "CARGO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            '.Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .ReadOnly = True
        End With

        With dgv4

            '.Columns.AddRange(NOMBRE_AGENCIA, LOGIN, RAZON_SOCIAL, SERIE_GUIA_ENVIO, NRO_GUIA, FECHA, FORMA_PAGO, SIMBOLO_MONEDA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO)
            .Columns.AddRange(NOMBRE_AGENCIA, RAZON_SOCIAL, NRO_GUIA, FECHA, FORMA_PAGO, SIMBOLO_MONEDA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, CARGO)

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
            .DataSource = dvListar_Prefacturas
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "RAZON SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 240
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim MES As New DataGridViewTextBoxColumn
        With MES
            .HeaderText = "MES"
            .Name = "MES"
            .DataPropertyName = "MES"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .Width = 70
            .ReadOnly = True
        End With
        Dim ANIO As New DataGridViewTextBoxColumn
        With ANIO
            .HeaderText = "ANIO"
            .Name = "ANIO"
            .DataPropertyName = "ANIO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .Width = 60
            .ReadOnly = True
        End With
        Dim MES_QUE_CORRESPONDE As New DataGridViewTextBoxColumn
        With MES_QUE_CORRESPONDE
            .HeaderText = "MES"
            .Name = "MES_QUE_CORRESPONDE"
            .DataPropertyName = "MES_QUE_CORRESPONDE"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "NRO FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
        End With
        Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
        With NRO_PREFACTURA
            .HeaderText = "NRO PREFACTURA"
            .Name = "NRO_PREFACTURA"
            .DataPropertyName = "NRO_PREFACTURA"
            .Width = 110
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
        End With
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA    '9
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
            .Width = 90
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO   '11
            .HeaderText = "FORMA PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            .Width = 60
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUBTOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "IMPUESTOS"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim FUNCIONARIO As New DataGridViewTextBoxColumn
        With FUNCIONARIO
            .HeaderText = "FUNCIONARIO"
            .Name = "FUNCIONARIO"
            .DataPropertyName = "FUNCIONARIO"
            .Width = 220
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With



        Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
        With ANIO_FACTURA   '0 
            .HeaderText = "ANIO_FACTURA"
            .Name = "ANIO_FACTURA"
            .DataPropertyName = "ANIO_FACTURA"
            .Width = 4
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE '1
            .HeaderText = "CODIGO_CLIENTE"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            .Width = 20
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim DESTINATARIO As New DataGridViewTextBoxColumn
        With DESTINATARIO  '2
            .HeaderText = "DESTINATARIO"
            .Name = "DESTINATARIO"
            .DataPropertyName = "DESTINATARIO"
            .Width = 182
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO  '3
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim DIA_FACTURA As New DataGridViewTextBoxColumn
        With DIA_FACTURA  '4
            .HeaderText = "DIA_FACTURA"
            .Name = "DIA_FACTURA"
            .DataPropertyName = "DIA_FACTURA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 2
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
        With DIRECCION_PERSONA    '5
            .HeaderText = "DIRECCION_PERSONA"
            .Name = "DIRECCION_PERSONA"
            .DataPropertyName = "DIRECCION_PERSONA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim DIREC_DESTI As New DataGridViewTextBoxColumn
        With DIREC_DESTI   '6
            .HeaderText = "DIREC_DESTI"
            .Name = "DIREC_DESTI"
            .DataPropertyName = "DIREC_DESTI"
            .Width = 200
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIREC_REMI As New DataGridViewTextBoxColumn
        With DIREC_REMI    '7
            .HeaderText = "DIREC_REMI"
            .Name = "DIREC_REMI"
            .DataPropertyName = "DIREC_REMI"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim DSCTO As New DataGridViewTextBoxColumn
        With DSCTO    '8
            .HeaderText = "DSCTO"
            .Name = "DSCTO"
            .DataPropertyName = "DSCTO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA  '10
            .HeaderText = "NOMBRE_AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn
        With IDAGENCIAS   '12
            .HeaderText = "IDAGENCIAS"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDFACTURA As New DataGridViewTextBoxColumn
        With IDFACTURA   '13
            .HeaderText = "IDFACTURA"
            .Name = "IDFACTURA"
            .DataPropertyName = "IDFACTURA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.NullValue = "0,00"
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim NRO_SERIE As New DataGridViewTextBoxColumn
        With NRO_SERIE
            .HeaderText = "NRO_SERIE"
            .Name = "NRO_SERIE"
            .DataPropertyName = "NRO_SERIE"
            .Width = 30
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "USUARIO"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .Width = 50
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

        Dim TOTAL_PESO As New DataGridViewTextBoxColumn
        With TOTAL_PESO
            .HeaderText = "TOTAL PESO"
            .Name = "total_peso"
            .DataPropertyName = "total_peso"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With

        Dim TOTAL_VOLUMEN As New DataGridViewTextBoxColumn
        With TOTAL_VOLUMEN
            .HeaderText = "TOTAL VOLUMEN"
            .Name = "total_volumen"
            .DataPropertyName = "total_volumen"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With

        With DGV3
            '.Columns.AddRange(RAZON_SOCIAL, MES, ANIO, MES_QUE_CORRESPONDE, NRO_FACTURA, NRO_PREFACTURA, FECHA, FORMA_PAGO, SIMBOLO_MONEDA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, ESTADO_REGISTRO)
            .Columns.AddRange(RAZON_SOCIAL, MES, ANIO, FUNCIONARIO, NRO_FACTURA, NRO_PREFACTURA, FECHA, FORMA_PAGO, SIMBOLO_MONEDA, _
                              SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, LOGIN, TOTAL_PESO, TOTAL_VOLUMEN)

        End With
    End Sub

    Private Sub FrmConsulPreFactuEmi_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulPreFactuEmi_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Consulta de Pre-Facturas Emitidas"
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
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)

            Me.cmbAgencia.SelectedIndex = -1
            Me.cmbUsuarios.SelectedIndex = -1

            'hlamas 03-10-2013
            Dim obj As New dtoVentaCargaContado
            With Me.cmbProducto
                .DataSource = obj.ListarProducto(2, 1)
                .ValueMember = "idprocesos"
                .DisplayMember = "procesos"
                .SelectedValue = 0
            End With

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.GotFocus
        dgv4.DataSource = Nothing
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
                'objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(CNN, Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
                objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
            Else
                cmbUsuarios.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
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

                    ObjFactura.IDTIPO_MONEDA = 0

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


                    ObjFactura.IDFORMA_PAGO = 0

                    With ObjFactura


                        .IDPREFACTURA = Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("IDPREFACTURA")



                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)


                        ObjFactura.IDFORMA_PAGO = 0
                        If Me.rbfactu.Checked = True Then
                            ObjFactura.FACTURADO = 1
                        ElseIf Me.rbpendi.Checked = True Then
                            ObjFactura.FACTURADO = 0
                        Else
                            ObjFactura.FACTURADO = 2
                        End If

                        ObjFactura.NRO_PREFACTURA = Me.TBNRO_PREFACTURA.Text.ToString.Trim


                        If Me.rbde.Checked = True Then
                            ObjReport.printrptB(False, "", "PFA002.RPT", _
                            "P_SUBTOTAL;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("SUB_TOTAL"), 2, , , TriState.True), _
                            "P_MONTO_IMPUESTO;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("MONTO_IMPUESTO"), 2, , , TriState.True), _
                            "P_TOTAL_COSTO;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("TOTAL_COSTO"), 2, , , TriState.True), _
                            "P_PESO;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("TOTAL_PESO"), 2, , , TriState.True), _
                            "P_VOLUMEN;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("TOTAL_VOLUMEN"), 2, , , TriState.True), _
                            "P_IDPREFACTURA;" & .IDPREFACTURA)

                        ElseIf Me.rbPorDesti.Checked = True Then
                            ObjReport.printrptB(False, "", "PFA004.RPT", _
                            "P_SUBTOTAL;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("SUB_TOTAL"), 2, , , TriState.True), _
                            "P_MONTO_IMPUESTO;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("MONTO_IMPUESTO"), 2, , , TriState.True), _
                            "P_TOTAL_COSTO;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("TOTAL_COSTO"), 2, , , TriState.True), _
                            "P_IDPREFACTURA;" & .IDPREFACTURA)
                            'hlamas 19-09-2013
                        ElseIf Me.rbPorOrigen.Checked Then
                            ObjReport.printrptB(False, "", "PFA006.RPT", _
                            "P_MONTO_IMPUESTO;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("MONTO_IMPUESTO"), 2, , , TriState.True), _
                            "P_TOTAL_COSTO;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("TOTAL_COSTO"), 2, , , TriState.True), _
                            "P_IDPREFACTURA;" & .IDPREFACTURA)
                        ElseIf Me.rbPorDt.Checked Then
                            ObjReport.printrptB(False, "", "PFA005.RPT", _
                        "P_MONTO_IMPUESTO;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("MONTO_IMPUESTO"), 2, , , TriState.True), _
                        "P_TOTAL_COSTO;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("TOTAL_COSTO"), 2, , , TriState.True), _
                        "P_IDPREFACTURA;" & .IDPREFACTURA)
                        ElseIf Me.rbtSubcuenta.Checked Then
                            ObjReport.printrptB(False, "", "PFA007.RPT", _
                        "P_MONTO_IMPUESTO;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("MONTO_IMPUESTO"), 2, , , TriState.True), _
                        "P_TOTAL_COSTO;" & FormatNumber(Me.dvListar_Prefacturas.Table.Rows(Me.DGV3.CurrentRow.Index)("TOTAL_COSTO"), 2, , , TriState.True), _
                        "P_IDPREFACTURA;" & .IDPREFACTURA)
                        Else
                            If Me.RBPREFACTU.Checked = True Then
                                ObjReport.printrptB(False, "", "PFA001.RPT", _
                                "p_idpersona;" & .IDPERSONA, _
                                "p_idforma_pago;" & .IDFORMA_PAGO, _
                                "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                                "p_idagencias;" & .IDAGENCIAS, _
                                "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                                "p_FACTURADO;" & .FACTURADO, _
                                "p_NRO_PREFACTURA;" & .NRO_PREFACTURA, _
                                "p_fecha_inicial;" & .FECHA_INICIO, _
                                "p_fecha_final;" & .FECHA_FINAL)
                            Else
                                ObjReport.printrptB(False, "", "PFA003.RPT", _
                                "p_idpersona;" & .IDPERSONA, _
                                "p_idforma_pago;" & .IDFORMA_PAGO, _
                                "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                                "p_idagencias;" & .IDAGENCIAS, _
                                "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                                "p_FACTURADO;" & .FACTURADO, _
                                "p_NRO_PREFACTURA;" & .NRO_PREFACTURA, _
                                "p_fecha_inicial;" & .FECHA_INICIO, _
                                "p_fecha_final;" & .FECHA_FINAL)
                            End If
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
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub

    Private Sub txtidpersona_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                    With ObjPersona
                        .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                        .IDTIPO_PERSONA = 0
                        .CODIGO_CLIENTE = "NULL"
                        'datahelper
                        'ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, .IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                        ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                        Me.txtCodigoCliente.Text = .CODIGO_CLIENTE

                        'hlamas 17-09-2013
                        Controla(.IDPERSONA)

                        Me.RBPREFACTU.Focus()
                    End With
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                Else
                    Me.txtCodigoCliente.Text = ""
                    Me.RBPREFACTU.Focus()
                    'hlamas 17-09-2013
                    Controla(0)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.GotFocus
        dgv4.DataSource = Nothing
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
                    txtidpersona.Focus()
                    'hlamas 17-09-2013
                    Controla(ObjPersona.IDPERSONA)
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

                'hlamas 17-09-2013
                Controla(ObjPersona.IDPERSONA)

            End If
        Catch EX As Exception
            MsgBox(EX.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAINICIOFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPFECHAFINALFACTURA.Focus()
        End If
    End Sub


    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.GotFocus
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.TBNRO_PREFACTURA.Focus()
        End If
    End Sub




    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub



    Private Sub cbidforma_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidforma_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            Me.cmbAgencia.Focus()
        End If
    End Sub

    Private Sub cmbUsuarios_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUsuarios.GotFocus
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub


    Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUsuarios.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub

    Private Sub TBNRO_PREFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBNRO_PREFACTURA.GotFocus
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub


    Private Sub rbpendi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbpendi.GotFocus, RBPREFACTU.GotFocus, RBGUIAS_ENVI.GotFocus
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub



    Private Sub rbfactu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbfactu.GotFocus
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub

    Private Sub rbtodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtodos.CheckedChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub

    Private Sub rbtodos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtodos.GotFocus
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
    End Sub


    Private Sub rbpendi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbpendi.KeyPress
        If e.KeyChar = Chr(13) Then
            cmbAgencia.Focus()
        End If
    End Sub

    Private Sub rbfactu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbfactu.KeyPress
        If e.KeyChar = Chr(13) Then
            cmbAgencia.Focus()
        End If
    End Sub

    Private Sub rbtodos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbtodos.KeyPress
        If e.KeyChar = Chr(13) Then
            cmbAgencia.Focus()
        End If
    End Sub

    Private Sub TBNRO_PREFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBNRO_PREFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            rbpendi.Focus()
        End If
    End Sub

    Private Sub TBNRO_PREFACTURA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNRO_PREFACTURA.TextChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub

    Private Sub RBGUIAS_ENVI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RBGUIAS_ENVI.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.DTPFECHAINICIOFACTURA.Focus()
        End If
    End Sub
    Private Sub RBPREFACTU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RBPREFACTU.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.DTPFECHAINICIOFACTURA.Focus()
        End If
    End Sub
    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub
    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.TextChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub
    Private Sub AnularPreFacturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularPreFacturaToolStripMenuItem.Click
        Try
            Dim claseanula As New dtoConsulPreFactuEmi
            Dim rst_anula As New DataTable
            Dim lsnro_prefactura As String
            Dim lsmensaje, lsmensajebd As String
            Dim lcodigo As Long

            Dim ldvgr_dgv3 As DataGridViewRow
            '
            If DGV3.RowCount < 1 Then ' Cuando no existe prefactura 
                MessageBox.Show("No seleccionado ninguna Pre-Factura para anular", "Pre-Factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            ldvgr_dgv3 = Me.DGV3.CurrentRow()
            '        
            lsnro_prefactura = CType(ldvgr_dgv3.Cells("NRO_PREFACTURA").Value, Long)
            lsmensaje = "¿Esta seguro de anular la Pre-Factura  Nº " + lsnro_prefactura + " ? "
            Dim resp As DialogResult = MessageBox.Show(lsmensaje, "Pre-Factura", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            If resp = Windows.Forms.DialogResult.OK Then
                'Se debe anular la Pre_factura  
                claseanula.nro_prefactura = lsnro_prefactura
                claseanula.ip = dtoUSUARIOS.IP
                claseanula.idusuario_personal = dtoUSUARIOS.IdLogin
                claseanula.idrol_usuario = dtoUSUARIOS.IdRol
                '-- 
                rst_anula = claseanula.fn_AnularPrefactura()
                '--
                lcodigo = CType(rst_anula.Rows(0).Item(0).ToString, Long)
                lsmensajebd = CType(rst_anula.Rows(0).Item(1).ToString, String)
                If lcodigo = 0 Then
                    MessageBox.Show(lsmensajebd, "Pre-factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    listar_facturas()  ' Invocando 
                Else
                    MessageBox.Show(CType(lcodigo, String) & " " & lsmensajebd, "Pre-factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        'Dim claseanula As New dtoConsulPreFactuEmi
        'Dim rst_anula As New ADODB.Recordset
        'Dim lsnro_prefactura As String
        'Dim lsmensaje, lsmensajebd As String
        'Dim lcodigo As Long

        'Dim ldvgr_dgv3 As DataGridViewRow
        ''
        'If DGV3.RowCount < 1 Then ' Cuando no existe prefactura 
        '    MessageBox.Show("No seleccionado ninguna Pre-Factura para anular", "Pre-Factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        'ldvgr_dgv3 = Me.DGV3.CurrentRow()
        ''        
        'lsnro_prefactura = CType(ldvgr_dgv3.Cells("NRO_PREFACTURA").Value, Long)
        'lsmensaje = "¿Esta seguro de anular la Pre-Factura  Nº " + lsnro_prefactura + " ? "
        'Dim resp As DialogResult = MessageBox.Show(lsmensaje, "Pre-Factura", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        'If resp = Windows.Forms.DialogResult.OK Then
        '    'Se debe anular la Pre_factura  
        '    claseanula.nro_prefactura = lsnro_prefactura
        '    claseanula.ip = dtoUSUARIOS.IP
        '    claseanula.idusuario_personal = dtoUSUARIOS.IdLogin
        '    claseanula.idrol_usuario = dtoUSUARIOS.IdRol
        '    '-- 
        '    rst_anula = claseanula.fn_AnularPrefactura()
        '    '--
        '    lcodigo = CType(rst_anula.Fields.Item(0).Value, Long)
        '    lsmensajebd = CType(rst_anula.Fields.Item(1).Value, String)
        '    If lcodigo = 0 Then
        '        MessageBox.Show(lsmensajebd, "Pre-factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        listar_facturas()  ' Invocando 
        '    Else
        '        MessageBox.Show(CType(lcodigo, String) & " " & lsmensajebd, "Pre-factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    End If
        'End If

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

    Private Sub dgv4_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv4.CellContentClick

    End Sub

    Private Sub dgv4_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv4.RowsAdded
        Me.LblRegistros2.Text = FormatNumber(NumeroRegistro(Me.dgv4), 0)
    End Sub

    Private Sub dgv4_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv4.RowsRemoved
        Me.LblRegistros2.Text = FormatNumber(NumeroRegistro(Me.dgv4), 0)
    End Sub

    Private Sub RBPREFACTU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPREFACTU.CheckedChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub

    Private Sub RBGUIAS_ENVI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGUIAS_ENVI.CheckedChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub

    Private Sub rbpendi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbpendi.CheckedChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub

    Private Sub rbfactu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbfactu.CheckedChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub

    Private Sub rbgene_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbgene.CheckedChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub

    Private Sub rbde_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbde.CheckedChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub

    Private Sub rbPorDesti_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPorDesti.CheckedChanged, rbtSubcuenta.CheckedChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub

    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
        Me.dgv4.DataSource = Nothing
    End Sub

    Sub Controla(cliente As Integer)
        If ID_PERSONA_QUIMICA_SUIZA = cliente Then
            Me.rbPorDt.Visible = True
            Me.grbReportes.Width = 375
        Else
            Me.rbPorDt.Visible = False
            Me.grbReportes.Width = 326
        End If
    End Sub

    Private Sub DGV3_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellContentClick

    End Sub
End Class
