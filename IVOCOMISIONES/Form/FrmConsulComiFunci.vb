Public Class FrmConsulComiFunci
    Dim OBJCOMISIONES As New ClsLbTepsa.dtoComisiones
    Dim OBJGeneral As New ClsLbTepsa.dtoGENERAL
    Dim ObjReport As New ClsLbTepsa.dtoFrmReport
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Dim dv_Listar_funcionarios As New DataView

    Private Sub BtnListarComisiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnListarComisiones.Click
        FORMAT_dgvconsulconce3()
    End Sub
    Sub FORMAT_dgvconsulconce3()

        dgv1.DataSource = Nothing

        dgv1.Columns.Clear()

        OBJCOMISIONES.FECHA_INI = Me.DTPFECHA_INI.Value.ToShortDateString
        OBJCOMISIONES.FECHA_FINAL = Me.DTPFECHA_FINAL.Value.ToShortDateString

        If Not IsNothing(Me.CBIDFUNCIONARIO.SelectedValue) Then
            OBJCOMISIONES.IDFUNCIONARIO = Me.CBIDFUNCIONARIO.SelectedValue
        Else
            OBJCOMISIONES.IDFUNCIONARIO = 0
        End If

        With dgv1
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = OBJCOMISIONES.SP_L_COMI_CONCE_FUNCI_II()
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
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            '.DefaultCellStyle.NullValue = "0,00"
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
            .Width = 70
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
        Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        With TIPO_COMPROBANTE
            .HeaderText = "Tipo de Servicio"
            .Name = "TIPO_COMPROBANTE"
            .DataPropertyName = "TIPO_COMPROBANTE"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With

        Dim AFEC_COMI As New DataGridViewTextBoxColumn
        With AFEC_COMI
            .HeaderText = "¿AFECTO?"
            .Name = "AFEC_COMI"
            .DataPropertyName = "AFEC_COMI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With
        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL_COSTO"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim PORCEN As New DataGridViewTextBoxColumn
        With PORCEN
            .HeaderText = "PORCEN"
            .Name = "PORCEN"
            .DataPropertyName = "PORCEN"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            '.DefaultCellStyle.Format = "N2"
            '.DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim MONTO_PORCEN As New DataGridViewTextBoxColumn
        With MONTO_PORCEN
            .HeaderText = "MONTO_PORCEN"
            .Name = "MONTO_PORCEN"
            .DataPropertyName = "MONTO_PORCEN"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim IDTIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        With IDTIPO_COMPROBANTE
            .HeaderText = "IDTIPO_COMPROBANTE"
            .Name = "IDTIPO_COMPROBANTE"
            .DataPropertyName = "IDTIPO_COMPROBANTE"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            '.DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim NRO As New DataGridViewTextBoxColumn
        With NRO
            .HeaderText = "Nro. Comprob."
            .Name = "NRO"
            .DataPropertyName = "NRO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            '.DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim monto_x_comprobante As New DataGridViewTextBoxColumn
        With monto_x_comprobante
            .HeaderText = "Monto por Comprob."
            .Name = "monto_x_comprobante"
            .DataPropertyName = "monto_x_comprobante"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim Ocupabilidad As New DataGridViewTextBoxColumn
        With Ocupabilidad
            .HeaderText = "Ocupabilidad"
            .Name = "Ocupabilidad"
            .DataPropertyName = "Ocupabilidad"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim sub_total_pagar_comi As New DataGridViewTextBoxColumn
        With sub_total_pagar_comi
            .HeaderText = "Sub Total Comisión"
            .Name = "sub_total_pagar_comi"
            .DataPropertyName = "sub_total_pagar_comi"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim Total_por_compro As New DataGridViewTextBoxColumn
        With Total_por_compro
            .HeaderText = "Total por Comprob."
            .Name = "Total_por_compro"
            .DataPropertyName = "Total_por_compro"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim canti_servi As New DataGridViewTextBoxColumn
        With canti_servi
            .HeaderText = "Cantidad de Servicios"
            .Name = "canti_servi"
            .DataPropertyName = "canti_servi"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim para_monto_comi_ocu As New DataGridViewTextBoxColumn
        With para_monto_comi_ocu
            .HeaderText = "Porcentaje Calculado por Ocupabilidad"
            .Name = "para_monto_comi_ocu"
            .DataPropertyName = "para_monto_comi_ocu"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim monto_ocupa_calcu As New DataGridViewTextBoxColumn
        With monto_ocupa_calcu
            .HeaderText = "Monto Calculado por Ocupabilidad"
            .Name = "monto_ocupa_calcu"
            .DataPropertyName = "monto_ocupa_calcu"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim otros As New DataGridViewTextBoxColumn
        With otros
            .HeaderText = "otros"
            .Name = "otros"
            .DataPropertyName = "otros"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With







        Dim IDCOMI_CALCU_FUNCI As New DataGridViewTextBoxColumn
        With IDCOMI_CALCU_FUNCI
            .HeaderText = "ID"
            .Name = "IDCOMI_CALCU_FUNCI"
            .DataPropertyName = "IDCOMI_CALCU_FUNCI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim TIPO_FUNCI As New DataGridViewTextBoxColumn
        With TIPO_FUNCI
            .HeaderText = "TIPO FUNCIONARIO"
            .Name = "COMI_FUNCI"
            .DataPropertyName = "COMI_FUNCI"
            .Width = 180
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "NOMBRE_AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .Width = 130
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_REGISTRO As New DataGridViewTextBoxColumn
        With FECHA_REGISTRO
            .HeaderText = "FECHA REGISTRO"
            .Name = "FECHA_REGISTRO"
            .DataPropertyName = "FECHA_REGISTRO"
            .Width = 120
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CREADOR As New DataGridViewTextBoxColumn
        With CREADOR
            .HeaderText = "USUARIO CREADOR"
            .Name = "CREADOR"
            .DataPropertyName = "CREADOR"
            .Width = 140
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_INI As New DataGridViewTextBoxColumn
        With FECHA_INI
            .HeaderText = "FECHA INICIAL"
            .Name = "FECHA_INI"
            .DataPropertyName = "FECHA_INI"
            .Width = 90
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
        End With
        Dim FECHA_FINAL As New DataGridViewTextBoxColumn
        With FECHA_FINAL
            .HeaderText = "FECHA FINAL"
            .Name = "FECHA_FINAL"
            .DataPropertyName = "FECHA_FINAL"
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "ESTADO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
        End With
        Dim ID_COMI_FUNCI As New DataGridViewTextBoxColumn
        With ID_COMI_FUNCI
            .HeaderText = "ID_COMI_FUNCI"
            .Name = "ID_COMI_FUNCI"
            .DataPropertyName = "ID_COMI_FUNCI"
            .Width = 0
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
            .Visible = False
        End With
        Dim CERRADO As New DataGridViewTextBoxColumn
        With CERRADO
            .HeaderText = "¿CERRADO?"
            .Name = "CERRADO"
            .DataPropertyName = "CERRADO"
            .Width = 0
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With

        With dgv1
            .Columns.AddRange(IDCOMI_CALCU_FUNCI, FUNCIONARIO, TIPO_FUNCI, NOMBRE_AGENCIA, FECHA_REGISTRO, CREADOR, FECHA_INI, FECHA_FINAL, ESTADO_REGISTRO, ID_COMI_FUNCI, CERRADO)
        End With

        'With dgv1
        '    .Columns.AddRange(IDCOMI_CALCU_FUNCI, FUNCIONARIO, NOMBRE_AGENCIA, FECHA_REGISTRO, LOGIN, FECHA_INI, FECHA_FINAL, ESTADO_REGISTRO, CERRADO)

        'End With

        Me.TxtSubTotalConsulFunci.Text = 0
        Dim iTotal As Double
        If Me.dgv2.Rows.Count > 0 Then
            For i As Integer = 0 To Me.dgv2.Rows.Count - 1
                'iTotal += Me.dgvconsulFunci4.Rows(i).Cells("COMISION").Value
                dgv2.CurrentCell = Me.dgv2.Rows(i).Cells(1)
                If Convert.ToDateTime(Me.dgv1.CurrentRow.Cells("FECHA_FINAL").Value) > Convert.ToDateTime("31/12/2011") And Me.dgv1.CurrentRow.Cells(9).Value <> "FUAG" Then
                    Me.TxtSubTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) + Convert.ToDouble(Me.dgv2.CurrentRow.Cells("COMISION").Value), 2)
                ElseIf Convert.ToDateTime(Me.dgv1.CurrentRow.Cells("FECHA_FINAL").Value) > Convert.ToDateTime("31/12/2011") And Me.dgv1.CurrentRow.Cells(9).Value = "FUAG" Then
                    Me.TxtSubTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.dgv2.CurrentRow.Cells("TOTAL").Value), 2)
                Else
                    Me.TxtSubTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) + CDbl(Me.dgv2.CurrentRow.Cells("sub_total_pagar_comi").Value), 2)
                End If
            Next
            'Me.TxtSubTotalConsulFunci.Text = FormatNumber(iTotal, 2)
            Me.TxtCargoConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto, 2)
            Me.TxtTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto + Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text), 2)
        End If

        'For i As Integer = 0 To Me.dgv2.Rows.Count - 1
        '    dgv2.CurrentCell = Me.dgv2.Rows(i).Cells(1)
        '    Me.TxtSubTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) + CDbl(Me.dgv2.CurrentRow.Cells("sub_total_pagar_comi").Value), 2)

        'Next

        'Me.TxtCargoConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto, 2)
        'Me.TxtTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto + CDbl(Me.TxtSubTotalConsulFunci.Text), 2)

    End Sub

    Private Sub FrmConsulComiFunci_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub FrmConsulComiFunci_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulComiFunci_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Consulta de Comisiones Funcionarios..."
            Me.MenuStrip1.Items(0).Visible = False 'nuevo
            Me.MenuStrip1.Items(1).Visible = False 'edicion 
            Me.MenuStrip1.Items(2).Visible = False 'cancelar
            Me.MenuStrip1.Items(3).Visible = False  'grabar
            Me.MenuStrip1.Items(4).Visible = False 'eliminar
            Me.MenuStrip1.Items(5).Visible = False 'exportar
            Me.MenuStrip1.Items(6).Visible = True 'imprimir
            Me.MenuStrip1.Items(7).Visible = True 'ayuda
            Me.MenuStrip1.Items(8).Visible = True 'salir

            Me.MenuStrip1.Items(6).Text = "Resumen" 'imprimir
            Me.MenuStrip1.Items(7).Text = "Detalle" 'ayuda

            Me.DTPFECHA_INI.Value = Now.Date.ToShortDateString
            Me.DTPFECHA_FINAL.Value = Now.Date.ToShortDateString

            'Datahelper
            'OBJGeneral.FN_cmb_L_FUNCIONARIOS(Me.CBIDFUNCIONARIO)

            'CBIDFUNCIONARIO.SelectedIndex = -1

            Dim flag As Boolean = False

            '27	RESPONSABLE DE COMISION AGENCIAS	1

            '30	RESPONSABLE DE COMISION FUNCIONARIO	1

            'If fnValidar_Rol("11") = True Then
            '    flag = True
            'End If
            'If fnValidar_Rol("28") = True Then
            '    flag = True
            'End If
            'If fnValidar_Rol("30") = True Then
            '    flag = True
            'End If
            'If flag = False Then
            '    MsgBox("Usted no tiene Acceso", MsgBoxStyle.Information, "Seguridad Sistema")
            '    Close()
            'End If
            'CBIDFUNCIONARIO.SelectedValue = dtoUSUARIOS.IdLogin
            'CBIDFUNCIONARIO.Enabled = False

            Me.CBIDFUNCIONARIO.Enabled = True

            Dim cFecha As Date = FechaServidor()
            Dim intAnio As Integer = Year(cFecha)
            If cFecha.Date.Day >= 26 Then
                If cFecha.Date.AddMonths(-1).Date.Month > cFecha.Date.Month Then intAnio -= 1
                DTPFECHA_INI.Value = "26/" & cFecha.Date.AddMonths(-1).Date.Month & "/" & intAnio
                DTPFECHA_FINAL.Value = "25/" & cFecha.Date.Month & "/" & intAnio
            Else
                If cFecha.Date.AddMonths(-2).Date.Month > cFecha.Date.Month Then intAnio -= 1
                DTPFECHA_INI.Value = "26/" & cFecha.Date.AddMonths(-2).Date.Month & "/" & intAnio

                intAnio = Year(cFecha)
                If cFecha.Date.AddMonths(-1).Date.Month > cFecha.Date.Month Then intAnio -= 1
                DTPFECHA_FINAL.Value = "25/" & cFecha.Date.AddMonths(-1).Date.Month & "/" & intAnio + 1
            End If

            'If dtoUSUARIOS.IdLogin = 901 Then

            'End If

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgv1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick

    End Sub

    Private Sub dgv1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellEnter
        FORMAT_dgvconsulFUNCI4()
    End Sub
    Sub FORMAT_dgvconsulFUNCI4()
        dgv2.Columns.Clear()


        OBJCOMISIONES.IDCOMI_CALCU_FUNCI = dgv1.CurrentRow.Cells("IDCOMI_CALCU_FUNCI").Value

        Dim sTipo As String
        With dgv2
            sTipo = dgv1.CurrentRow.Cells("id_comi_funci").Value
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = OBJCOMISIONES.SP_L_COMI_CONCE_detall_FUNCI(sTipo)
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        If sTipo = "FUAG" And Convert.ToDateTime(Me.dgv1.CurrentRow.Cells("FECHA_FINAL").Value) > Convert.ToDateTime("31/12/2011") Then
            Dim ANIO As New DataGridViewTextBoxColumn
            With ANIO
                .HeaderText = "ANIO"
                .Name = "ANIO"
                .DataPropertyName = "ANIO"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 50
                .ReadOnly = True
                .Visible = False
            End With

            Dim AGENCIA As New DataGridViewTextBoxColumn
            With AGENCIA
                .HeaderText = "AGENCIA"
                .Name = "AGENCIA"
                .DataPropertyName = "AGENCIA"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 200
                .ReadOnly = True
            End With

            Dim PRESIDENCIAL_CAMA As New DataGridViewTextBoxColumn
            With PRESIDENCIAL_CAMA
                .HeaderText = "PRESIDENCIAL CAMA"
                .Name = "PRESIDENCIAL_CAMA"
                .DataPropertyName = "PRESIDENCIAL_CAMA"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 100
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim BOLETO_PRESIDENCIAL As New DataGridViewTextBoxColumn
            With BOLETO_PRESIDENCIAL
                .HeaderText = "BOLETO PRESIDENCIAL"
                .Name = "BOLETO_PRESIDENCIAL"
                .DataPropertyName = "BOLETO_PRESIDENCIAL"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 100
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim DELIVERY As New DataGridViewTextBoxColumn
            With DELIVERY
                .HeaderText = "DELIVERY"
                .Name = "DELIVERY"
                .DataPropertyName = "DELIVERY"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 100
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim REC_CAJA_PRESIDENCIAL As New DataGridViewTextBoxColumn
            With REC_CAJA_PRESIDENCIAL
                .HeaderText = "R.C. PRESIDENCIAL"
                .Name = "R.C. PRESIDENCIAL"
                .DataPropertyName = "R.C. PRESIDENCIAL"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 100
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim REC_CAJA_PRESIDENCIAL_CAMA As New DataGridViewTextBoxColumn
            With REC_CAJA_PRESIDENCIAL_CAMA
                .HeaderText = "R.C. PRESIDENCIAL CAMA"
                .Name = "R.C. PRESIDENCIAL CAMA"
                .DataPropertyName = "R.C. PRESIDENCIAL CAMA"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 100
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim TOTAL_ING As New DataGridViewTextBoxColumn
            With TOTAL_ING
                .HeaderText = "TOTAL INGRESO"
                .Name = "TOTAL_ING"
                .DataPropertyName = "TOTAL_INGRESO"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCell
                .Width = 150
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim PREPAGO As New DataGridViewTextBoxColumn
            With PREPAGO
                .HeaderText = "PREPAGO"
                .Name = "PREPAGO"
                .DataPropertyName = "PREPAGO"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 100
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim ORDEN_TRABAJO As New DataGridViewTextBoxColumn
            With ORDEN_TRABAJO
                .HeaderText = "ORDEN TRABAJO"
                .Name = "ORDEN_TRABAJO"
                .DataPropertyName = "ORDEN_TRABAJO"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 100
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim CORTESIA As New DataGridViewTextBoxColumn
            With CORTESIA
                .HeaderText = "CORTESIA"
                .Name = "CORTESIA"
                .DataPropertyName = "CORTESIA"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 100
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim PROMOCION As New DataGridViewTextBoxColumn
            With PROMOCION
                .HeaderText = "PROMOCION"
                .Name = "PROMOCION"
                .DataPropertyName = "PROMOCION"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 100
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim DEVOLUCION As New DataGridViewTextBoxColumn
            With DEVOLUCION
                .HeaderText = "DEVOLUCION"
                .Name = "DEVOLUCION"
                .DataPropertyName = "DEVOLUCION"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 100
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim TOTAL_EGR As New DataGridViewTextBoxColumn
            With TOTAL_EGR
                .HeaderText = "TOTAL EGRESO"
                .Name = "TOTAL_EGR"
                .DataPropertyName = "TOTAL_EGRESO"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 100
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim TOTAL As New DataGridViewTextBoxColumn
            With TOTAL
                .HeaderText = "TOTAL"
                .Name = "TOTAL"
                .DataPropertyName = "TOTAL"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 100
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim PRESIDENCIAL_CAMA_2 As New DataGridViewTextBoxColumn
            With PRESIDENCIAL_CAMA_2
                .HeaderText = "PRESIDENCIAL CAMA"
                .Name = "PRESIDENCIAL_CAMA_2"
                .DataPropertyName = "PRESIDENCIAL_CAMA_2"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim BOLETO_PRESIDENCIAL_2 As New DataGridViewTextBoxColumn
            With BOLETO_PRESIDENCIAL_2
                .HeaderText = "BOLETO PRESIDENCIAL"
                .Name = "BOLETO_PRESIDENCIAL_2"
                .DataPropertyName = "BOLETO_PRESIDENCIAL_2"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim DELIVERY_2 As New DataGridViewTextBoxColumn
            With DELIVERY_2
                .HeaderText = "DELIVERY"
                .Name = "DELIVERY_2"
                .DataPropertyName = "DELIVERY_2"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim TOTAL_ING_2 As New DataGridViewTextBoxColumn
            With TOTAL_ING_2
                .HeaderText = "TOTAL ING"
                .Name = "TOTAL_ING_2"
                .DataPropertyName = "TOTAL_ING_2"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim PREPAGO_2 As New DataGridViewTextBoxColumn
            With PREPAGO_2
                .HeaderText = "PREPAGO"
                .Name = "PREPAGO_2"
                .DataPropertyName = "PREPAGO_2"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim ORDEN_TRABAJO_2 As New DataGridViewTextBoxColumn
            With ORDEN_TRABAJO_2
                .HeaderText = "ORDEN TRABAJO"
                .Name = "ORDEN_TRABAJO_2"
                .DataPropertyName = "ORDEN_TRABAJO_2"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim CORTESIA_2 As New DataGridViewTextBoxColumn
            With CORTESIA_2
                .HeaderText = "CORTESIA"
                .Name = "CORTESIA_2"
                .DataPropertyName = "CORTESIA_2"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim PROMOCION_2 As New DataGridViewTextBoxColumn
            With PROMOCION_2
                .HeaderText = "PROMOCION"
                .Name = "PROMOCION_2"
                .DataPropertyName = "PROMOCION_2"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim DEVOLUCION_2 As New DataGridViewTextBoxColumn
            With DEVOLUCION_2
                .HeaderText = "DEVOLUCION"
                .Name = "DEVOLUCION_2"
                .DataPropertyName = "DEVOLUCION_2"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim TOTAL_EGR_2 As New DataGridViewTextBoxColumn
            With TOTAL_EGR_2
                .HeaderText = "TOTAL EGR"
                .Name = "TOTAL_EGR_2"
                .DataPropertyName = "TOTAL_EGR_2"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim TOTAL_2 As New DataGridViewTextBoxColumn
            With TOTAL_2
                .HeaderText = "TOTAL"
                .Name = "TOTAL_2"
                .DataPropertyName = "TOTAL_2"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim TOTAL_NETO As New DataGridViewTextBoxColumn
            With TOTAL_NETO
                .HeaderText = "BASE COMISION"
                .Name = "TOTAL_NETO"
                .DataPropertyName = "TOTAL_NETO"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim COMISION As New DataGridViewTextBoxColumn
            With COMISION
                .HeaderText = "COMISION"
                .Name = "COMISION"
                .DataPropertyName = "COMISION"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 100
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With
            With dgv2
                .Columns.AddRange(ANIO, AGENCIA, PRESIDENCIAL_CAMA, BOLETO_PRESIDENCIAL, DELIVERY, REC_CAJA_PRESIDENCIAL, REC_CAJA_PRESIDENCIAL_CAMA, TOTAL_ING, PREPAGO, ORDEN_TRABAJO, CORTESIA, PROMOCION, DEVOLUCION, TOTAL_EGR, TOTAL)
            End With

            dgv2.CurrentCell = Me.dgv2.Rows(Me.dgv2.RowCount - 1).Cells(1)
            Me.TxtSubTotalConsulFunci.Text = FormatNumber(CDbl(Me.dgv2.CurrentRow.Cells("TOTAL").Value), 2)

            'For i As Integer = 0 To Me.dgvconsulFunci4.Rows.Count - 1
            '    dgvconsulFunci4.CurrentCell = Me.dgvconsulFunci4.Rows(i).Cells(1)
            '    Me.TxtSubTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) + CDbl(Me.dgvconsulFunci4.CurrentRow.Cells("COMISION").Value), 2)
            'Next

            Me.TxtCargoConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto, 2)
            Me.TxtTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto + CDbl(Me.TxtSubTotalConsulFunci.Text), 2)

            For j As Integer = 0 To Me.dgv2.RowCount - 1
                If dgv2.Rows(j).Cells("ANIO").Value = 0 Then
                    dgv2.Rows(j).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 179)
                    dgv2.Rows(j).DefaultCellStyle.ForeColor = Color.Black
                    dgv2.Rows(j).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
                End If
            Next

        ElseIf sTipo = "FUCA" And Convert.ToDateTime(Me.dgv1.CurrentRow.Cells("FECHA_FINAL").Value) > Convert.ToDateTime("31/12/2011") Then
            '----------------------------------------------------------------------
            'Para el DataGrid de Comisiones de los funcionarios de carga
            '----------------------------------------------------------------------
            Dim IDGRUPO As New DataGridViewTextBoxColumn
            With IDGRUPO
                .HeaderText = "ID"
                .Name = "IDGRUPO"
                .DataPropertyName = "IDGRUPO"
                .Width = 30
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .DefaultCellStyle.Format = "N0"
                .DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim GRUPO As New DataGridViewTextBoxColumn
            With GRUPO
                .HeaderText = "GRUPO"
                .Name = "GRUPO"
                .DataPropertyName = "GRUPO"
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            Dim PORCENTAJE As New DataGridViewTextBoxColumn
            With PORCENTAJE
                .HeaderText = "PORCENTAJE"
                .Name = "PORCENTAJE"
                .DataPropertyName = "PORCENTAJE"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With

            Dim COBRANZA As New DataGridViewTextBoxColumn
            With COBRANZA
                .HeaderText = "COBRANZA"
                .Name = "TOTAL"
                .DataPropertyName = "TOTAL"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .ReadOnly = True
            End With

            Dim COMISION As New DataGridViewTextBoxColumn
            With COMISION
                .HeaderText = "COMISION"
                .Name = "COMISION"
                .DataPropertyName = "COMISION"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"

                .ReadOnly = True
            End With

            With dgv2
                .Columns.AddRange(IDGRUPO, GRUPO, PORCENTAJE, COBRANZA, COMISION)
            End With

            Me.TxtSubTotalConsulFunci.Text = 0
            For i As Integer = 0 To Me.dgv2.Rows.Count - 1
                dgv2.CurrentCell = Me.dgv2.Rows(i).Cells(1)
                Me.TxtSubTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) + Convert.ToDouble(Me.dgv2.CurrentRow.Cells("COMISION").Value), 2)
            Next

            Me.TxtCargoConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto, 2)
            Me.TxtTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto + Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text), 2)


        ElseIf sTipo = "FUPN" And Convert.ToDateTime(Me.dgv1.CurrentRow.Cells("FECHA_FINAL").Value) > Convert.ToDateTime("31/12/2011") Then

            Dim CIUDAD_COMI As New DataGridViewTextBoxColumn
            With CIUDAD_COMI
                .HeaderText = "ORIGEN"
                .Name = "ORIGEN"
                .DataPropertyName = "ORIGEN"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim TIPO_COMI As New DataGridViewTextBoxColumn
            With TIPO_COMI
                .HeaderText = "TIPO COBRANZA"
                .Name = "TIPO_COBRANZA"
                .DataPropertyName = "TIPO_COBRANZA"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim PORCENTAJE_PASAJE As New DataGridViewTextBoxColumn
            With PORCENTAJE_PASAJE
                .HeaderText = "PORCENTAJE"
                .Name = "PORCENTAJE"
                .DataPropertyName = "PORCENTAJE"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With

            Dim TOTAL_COMI_PASAJE As New DataGridViewTextBoxColumn
            With TOTAL_COMI_PASAJE
                .HeaderText = "TOTAL"
                .Name = "TOTAL"
                .DataPropertyName = "TOTAL"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim COMISION As New DataGridViewTextBoxColumn
            With COMISION
                .HeaderText = "COMISION"
                .Name = "COMISION"
                .DataPropertyName = "COMISION"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .ReadOnly = True
            End With

            With dgv2
                .Columns.AddRange(CIUDAD_COMI, TIPO_COMI, PORCENTAJE_PASAJE, TOTAL_COMI_PASAJE, COMISION)
            End With

            Me.TxtSubTotalConsulFunci.Text = 0
            For i As Integer = 0 To Me.dgv2.Rows.Count - 1
                dgv2.CurrentCell = Me.dgv2.Rows(i).Cells(1)
                Me.TxtSubTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) + Convert.ToDouble(Me.dgv2.CurrentRow.Cells("COMISION").Value), 2)
            Next

            Me.TxtCargoConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto, 2)
            Me.TxtTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto + Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text), 2)

        ElseIf sTipo = "EJPA" And Convert.ToDateTime(Me.dgv1.CurrentRow.Cells("FECHA_FINAL").Value) > Convert.ToDateTime("31/12/2011") Then

            Dim CIUDAD_COMI As New DataGridViewTextBoxColumn
            With CIUDAD_COMI
                .HeaderText = "ORIGEN"
                .Name = "ORIGEN"
                .DataPropertyName = "ORIGEN"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim TIPO_COMI As New DataGridViewTextBoxColumn
            With TIPO_COMI
                .HeaderText = "TIPO COBRANZA"
                .Name = "TIPO_COBRANZA"
                .DataPropertyName = "TIPO_COBRANZA"
                .Width = 180
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim PORCENTAJE_PASAJE As New DataGridViewTextBoxColumn
            With PORCENTAJE_PASAJE
                .HeaderText = "PORCENTAJE"
                .Name = "PORCENTAJE"
                .DataPropertyName = "PORCENTAJE"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With

            Dim TOTAL_COMI_PASAJE As New DataGridViewTextBoxColumn
            With TOTAL_COMI_PASAJE
                .HeaderText = "TOTAL"
                .Name = "TOTAL"
                .DataPropertyName = "TOTAL"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim COMISION As New DataGridViewTextBoxColumn
            With COMISION
                .HeaderText = "COMISION"
                .Name = "COMISION"
                .DataPropertyName = "COMISION"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .ReadOnly = True
            End With

            With dgv2
                .Columns.AddRange(CIUDAD_COMI, TIPO_COMI, PORCENTAJE_PASAJE, TOTAL_COMI_PASAJE, COMISION)
            End With

            Me.TxtSubTotalConsulFunci.Text = 0
            For i As Integer = 0 To Me.dgv2.Rows.Count - 1
                dgv2.CurrentCell = Me.dgv2.Rows(i).Cells(1)
                Me.TxtSubTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) + Convert.ToDouble(Me.dgv2.CurrentRow.Cells("COMISION").Value), 2)
            Next

            Me.TxtCargoConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto, 2)
            Me.TxtTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto + Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text), 2)


        Else
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
                .Width = 250
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
                .Width = 30
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N0"
                '.DefaultCellStyle.NullValue = "0,00"
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
                .Width = 70
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
            Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
            With TIPO_COMPROBANTE
                .HeaderText = "Tipo de Servicio"
                .Name = "TIPO_COMPROBANTE"
                .DataPropertyName = "TIPO_COMPROBANTE"
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            Dim AFEC_COMI As New DataGridViewTextBoxColumn
            With AFEC_COMI
                .HeaderText = "¿AFECTO?"
                .Name = "AFEC_COMI"
                .DataPropertyName = "AFEC_COMI"
                .Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With
            Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
            With TOTAL_COSTO
                .HeaderText = "TOTAL_COSTO"
                .Name = "TOTAL_COSTO"
                .DataPropertyName = "TOTAL_COSTO"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            Dim PORCEN As New DataGridViewTextBoxColumn
            With PORCEN
                .HeaderText = "PORCEN"
                .Name = "PORCEN"
                .DataPropertyName = "PORCEN"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.DefaultCellStyle.Format = "N2"
                '.DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            Dim MONTO_PORCEN As New DataGridViewTextBoxColumn
            With MONTO_PORCEN
                .HeaderText = "MONTO_PORCEN"
                .Name = "MONTO_PORCEN"
                .DataPropertyName = "MONTO_PORCEN"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim IDTIPO_COMPROBANTE As New DataGridViewTextBoxColumn
            With IDTIPO_COMPROBANTE
                .HeaderText = "IDTIPO_COMPROBANTE"
                .Name = "IDTIPO_COMPROBANTE"
                .DataPropertyName = "IDTIPO_COMPROBANTE"
                .Width = 30
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N0"
                '.DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim NRO As New DataGridViewTextBoxColumn
            With NRO
                .HeaderText = "Nro. Comprob."
                .Name = "NRO"
                .DataPropertyName = "NRO"
                .Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N0"
                '.DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim monto_x_comprobante As New DataGridViewTextBoxColumn
            With monto_x_comprobante
                .HeaderText = "Monto por Comprob."
                .Name = "monto_x_comprobante"
                .DataPropertyName = "monto_x_comprobante"
                .Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            Dim Ocupabilidad As New DataGridViewTextBoxColumn
            With Ocupabilidad
                .HeaderText = "Ocupabilidad"
                .Name = "Ocupabilidad"
                .DataPropertyName = "Ocupabilidad"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            Dim sub_total_pagar_comi As New DataGridViewTextBoxColumn
            With sub_total_pagar_comi
                .HeaderText = "Sub Total Comisión"
                .Name = "sub_total_pagar_comi"
                .DataPropertyName = "sub_total_pagar_comi"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            Dim Total_por_compro As New DataGridViewTextBoxColumn
            With Total_por_compro
                .HeaderText = "Total por Comprob."
                .Name = "Total_por_compro"
                .DataPropertyName = "Total_por_compro"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim canti_servi As New DataGridViewTextBoxColumn
            With canti_servi
                .HeaderText = "Cantidad de Servicios"
                .Name = "canti_servi"
                .DataPropertyName = "canti_servi"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim para_monto_comi_ocu As New DataGridViewTextBoxColumn
            With para_monto_comi_ocu
                .HeaderText = "Porcentaje Calculado por Ocupabilidad"
                .Name = "para_monto_comi_ocu"
                .DataPropertyName = "para_monto_comi_ocu"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim monto_ocupa_calcu As New DataGridViewTextBoxColumn
            With monto_ocupa_calcu
                .HeaderText = "Monto Calculado por Ocupabilidad"
                .Name = "monto_ocupa_calcu"
                .DataPropertyName = "monto_ocupa_calcu"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim otros As New DataGridViewTextBoxColumn
            With otros
                .HeaderText = "otros"
                .Name = "otros"
                .DataPropertyName = "otros"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim IDCOMI_CALCU As New DataGridViewTextBoxColumn
            With IDCOMI_CALCU
                .HeaderText = "ID"
                .Name = "IDCOMI_CALCU"
                .DataPropertyName = "IDCOMI_CALCU"
                .Width = 30
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N0"
                '.DefaultCellStyle.NullValue = "0,00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With


            With dgv2
                .Columns.AddRange(IDTIPO_COMPROBANTE, TIPO_COMPROBANTE, TOTAL_COSTO, AFEC_COMI, SUB_TOTAL, PORCEN, MONTO_PORCEN, NRO, monto_x_comprobante, Total_por_compro, para_monto_comi_ocu, monto_ocupa_calcu, otros, sub_total_pagar_comi)
            End With

            Me.TxtSubTotalConsulFunci.Text = 0
            For i As Integer = 0 To Me.dgv2.Rows.Count - 1
                dgv2.CurrentCell = Me.dgv2.Rows(i).Cells(1)
                Me.TxtSubTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) + CDbl(Me.dgv2.CurrentRow.Cells("sub_total_pagar_comi").Value), 2)
            Next

            Me.TxtCargoConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto, 2)
            Me.TxtTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto + CDbl(Me.TxtSubTotalConsulFunci.Text), 2)
        End If

        'Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
        'With ANIO_FACTURA
        '    .HeaderText = "ANIO_FACTURA"
        '    .Name = "ANIO_FACTURA"
        '    .DataPropertyName = "ANIO_FACTURA"
        '    .Width = 4
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        'With CODIGO_CLIENTE
        '    .HeaderText = "CODIGO_CLIENTE"
        '    .Name = "CODIGO_CLIENTE"
        '    .DataPropertyName = "CODIGO_CLIENTE"
        '    .Width = 20
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim DESTINATARIO As New DataGridViewTextBoxColumn
        'With DESTINATARIO
        '    .HeaderText = "DESTINATARIO"
        '    .Name = "DESTINATARIO"
        '    .DataPropertyName = "DESTINATARIO"
        '    .Width = 182
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim DESTINO As New DataGridViewTextBoxColumn
        'With DESTINO
        '    .HeaderText = "DESTINO"
        '    .Name = "DESTINO"
        '    .DataPropertyName = "DESTINO"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim DIA_FACTURA As New DataGridViewTextBoxColumn
        'With DIA_FACTURA
        '    .HeaderText = "DIA_FACTURA"
        '    .Name = "DIA_FACTURA"
        '    .DataPropertyName = "DIA_FACTURA"
        '    .Width = 2
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
        'With DIRECCION_PERSONA
        '    .HeaderText = "DIRECCION_PERSONA"
        '    .Name = "DIRECCION_PERSONA"
        '    .DataPropertyName = "DIRECCION_PERSONA"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim DIREC_DESTI As New DataGridViewTextBoxColumn
        'With DIREC_DESTI
        '    .HeaderText = "DIREC_DESTI"
        '    .Name = "DIREC_DESTI"
        '    .DataPropertyName = "DIREC_DESTI"
        '    .Width = 200
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim DIREC_REMI As New DataGridViewTextBoxColumn
        'With DIREC_REMI
        '    .HeaderText = "DIREC_REMI"
        '    .Name = "DIREC_REMI"
        '    .DataPropertyName = "DIREC_REMI"
        '    .Width = 200
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim DSCTO As New DataGridViewTextBoxColumn
        'With DSCTO
        '    .HeaderText = "DSCTO"
        '    .Name = "DSCTO"
        '    .DataPropertyName = "DSCTO"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .Width = 80
        '    .ReadOnly = True
        'End With
        'Dim FECHA As New DataGridViewTextBoxColumn
        'With FECHA
        '    .HeaderText = "FECHA"
        '    .Name = "FECHA"
        '    .DataPropertyName = "FECHA"
        '    .Width = 80
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        'With ESTADO_REGISTRO
        '    .HeaderText = "ESTADO_REGISTRO"
        '    .Name = "ESTADO_REGISTRO"
        '    .DataPropertyName = "ESTADO_REGISTRO"
        '    .Width = 100
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        'With NOMBRE_AGENCIA
        '    .HeaderText = "NOMBRE_AGENCIA"
        '    .Name = "NOMBRE_AGENCIA"
        '    .DataPropertyName = "NOMBRE_AGENCIA"
        '    .Width = 250
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        'With FORMA_PAGO
        '    .HeaderText = "FORMA_PAGO"
        '    .Name = "FORMA_PAGO"
        '    .DataPropertyName = "FORMA_PAGO"
        '    .Width = 50
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim IDAGENCIAS As New DataGridViewTextBoxColumn
        'With IDAGENCIAS
        '    .HeaderText = "IDAGENCIAS"
        '    .Name = "IDAGENCIAS"
        '    .DataPropertyName = "IDAGENCIAS"
        '    .Width = 30
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N0"
        '    '.DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim IDFACTURA As New DataGridViewTextBoxColumn
        'With IDFACTURA
        '    .HeaderText = "IDFACTURA"
        '    .Name = "IDFACTURA"
        '    .DataPropertyName = "IDFACTURA"
        '    .Width = 50
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
        'With IDFORMA_PAGO
        '    .HeaderText = "IDFORMA_PAGO"
        '    .Name = "IDFORMA_PAGO"
        '    .DataPropertyName = "IDFORMA_PAGO"
        '    .Width = 50
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .ReadOnly = True
        'End With
        'Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
        'With IDTIPO_MONEDA
        '    .HeaderText = "IDTIPO_MONEDA"
        '    .Name = "IDTIPO_MONEDA"
        '    .DataPropertyName = "IDTIPO_MONEDA"
        '    .Width = 50
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .ReadOnly = True
        'End With
        'Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
        'With IDUSUARIO_PERSONAL
        '    .HeaderText = "IDUSUARIO_PERSONAL"
        '    .Name = "IDUSUARIO_PERSONAL"
        '    .DataPropertyName = "IDUSUARIO_PERSONAL"
        '    .Width = 50
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim MEMO As New DataGridViewTextBoxColumn
        'With MEMO
        '    .HeaderText = "MEMO"
        '    .Name = "MEMO"
        '    .DataPropertyName = "MEMO"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim MES_FACTURA As New DataGridViewTextBoxColumn
        'With MES_FACTURA
        '    .HeaderText = "MES_FACTURA"
        '    .Name = "MES_FACTURA"
        '    .DataPropertyName = "MES_FACTURA"
        '    .Width = 10
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        'With MONTO_IMPUESTO
        '    .HeaderText = "MONTO_IMPUESTO"
        '    .Name = "MONTO_IMPUESTO"
        '    .DataPropertyName = "MONTO_IMPUESTO"
        '    .Width = 50
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .ReadOnly = True
        'End With
        'Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        'With NRO_FACTURA
        '    .HeaderText = "NRO_FACTURA"
        '    .Name = "NRO_FACTURA"
        '    .DataPropertyName = "NRO_FACTURA"
        '    .Width = 70
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        'End With
        'Dim ORIGEN As New DataGridViewTextBoxColumn
        'With ORIGEN
        '    .HeaderText = "ORIGEN"
        '    .Name = "ORIGEN"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DataPropertyName = "ORIGEN"

        '    .ReadOnly = True
        'End With
        'Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        'With RAZON_SOCIAL
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .HeaderText = "RAZON_SOCIAL"
        '    .Name = "RAZON_SOCIAL"
        '    .DataPropertyName = "RAZON_SOCIAL"
        '    .Width = 200
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim REFE As New DataGridViewTextBoxColumn
        'With REFE
        '    .HeaderText = "REFE"
        '    .Name = "REFE"
        '    .DataPropertyName = "REFE"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim REMITENTE As New DataGridViewTextBoxColumn
        'With REMITENTE
        '    .HeaderText = "REMITENTE"
        '    .Name = "REMITENTE"
        '    .DataPropertyName = "REMITENTE"
        '    .Width = 182
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
        'With SERIE_FACTURA
        '    .HeaderText = "SERIE_FACTURA"
        '    .Name = "SERIE_FACTURA"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DataPropertyName = "SERIE_FACTURA"
        '    .Width = 30
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        'With SIMBOLO_MONEDA
        '    .HeaderText = "SIMBOLO_MONEDA"
        '    .Name = "SIMBOLO_MONEDA"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DataPropertyName = "SIMBOLO_MONEDA"
        '    .Width = 30
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        'With SUB_TOTAL
        '    .HeaderText = "SUB_TOTAL"
        '    .Name = "SUB_TOTAL"
        '    .DataPropertyName = "SUB_TOTAL"
        '    .Width = 70
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim LOGIN As New DataGridViewTextBoxColumn
        'With LOGIN
        '    .HeaderText = "LOGIN"
        '    .Name = "LOGIN"
        '    .DataPropertyName = "LOGIN"
        '    .Width = 50
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
        'With NRO_PREFACTURA
        '    .HeaderText = "NRO_PREFACTURA"
        '    .Name = "NRO_PREFACTURA"
        '    .DataPropertyName = "NRO_PREFACTURA"
        '    .Width = 100
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        '    .ReadOnly = True
        'End With
        'Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        'With TIPO_COMPROBANTE
        '    .HeaderText = "Tipo de Servicio"
        '    .Name = "TIPO_COMPROBANTE"
        '    .DataPropertyName = "TIPO_COMPROBANTE"
        '    .Width = 200
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '    .ReadOnly = True
        'End With

        'Dim AFEC_COMI As New DataGridViewTextBoxColumn
        'With AFEC_COMI
        '    .HeaderText = "¿AFECTO?"
        '    .Name = "AFEC_COMI"
        '    .DataPropertyName = "AFEC_COMI"
        '    .Width = 50
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '    .ReadOnly = True
        'End With
        'Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        'With TOTAL_COSTO
        '    .HeaderText = "TOTAL_COSTO"
        '    .Name = "TOTAL_COSTO"
        '    .DataPropertyName = "TOTAL_COSTO"
        '    .Width = 70
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim PORCEN As New DataGridViewTextBoxColumn
        'With PORCEN
        '    .HeaderText = "PORCEN"
        '    .Name = "PORCEN"
        '    .DataPropertyName = "PORCEN"
        '    .Width = 70
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    '.DefaultCellStyle.Format = "N2"
        '    '.DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim MONTO_PORCEN As New DataGridViewTextBoxColumn
        'With MONTO_PORCEN
        '    .HeaderText = "MONTO_PORCEN"
        '    .Name = "MONTO_PORCEN"
        '    .DataPropertyName = "MONTO_PORCEN"
        '    .Width = 70
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With

        'Dim IDTIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        'With IDTIPO_COMPROBANTE
        '    .HeaderText = "IDTIPO_COMPROBANTE"
        '    .Name = "IDTIPO_COMPROBANTE"
        '    .DataPropertyName = "IDTIPO_COMPROBANTE"
        '    .Width = 30
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N0"
        '    '.DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With

        'Dim NRO As New DataGridViewTextBoxColumn
        'With NRO
        '    .HeaderText = "Nro. Comprob."
        '    .Name = "NRO"
        '    .DataPropertyName = "NRO"
        '    .Width = 50
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N0"
        '    '.DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With

        'Dim monto_x_comprobante As New DataGridViewTextBoxColumn
        'With monto_x_comprobante
        '    .HeaderText = "Monto por Comprob."
        '    .Name = "monto_x_comprobante"
        '    .DataPropertyName = "monto_x_comprobante"
        '    .Width = 50
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim Ocupabilidad As New DataGridViewTextBoxColumn
        'With Ocupabilidad
        '    .HeaderText = "Ocupabilidad"
        '    .Name = "Ocupabilidad"
        '    .DataPropertyName = "Ocupabilidad"
        '    .Width = 70
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim sub_total_pagar_comi As New DataGridViewTextBoxColumn
        'With sub_total_pagar_comi
        '    .HeaderText = "Sub Total Comisión"
        '    .Name = "sub_total_pagar_comi"
        '    .DataPropertyName = "sub_total_pagar_comi"
        '    .Width = 70
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With
        'Dim Total_por_compro As New DataGridViewTextBoxColumn
        'With Total_por_compro
        '    .HeaderText = "Total por Comprob."
        '    .Name = "Total_por_compro"
        '    .DataPropertyName = "Total_por_compro"
        '    .Width = 70
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With

        'Dim canti_servi As New DataGridViewTextBoxColumn
        'With canti_servi
        '    .HeaderText = "Cantidad de Servicios"
        '    .Name = "canti_servi"
        '    .DataPropertyName = "canti_servi"
        '    .Width = 70
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With

        'Dim para_monto_comi_ocu As New DataGridViewTextBoxColumn
        'With para_monto_comi_ocu
        '    .HeaderText = "Porcentaje Calculado por Ocupabilidad"
        '    .Name = "para_monto_comi_ocu"
        '    .DataPropertyName = "para_monto_comi_ocu"
        '    .Width = 70
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With

        'Dim monto_ocupa_calcu As New DataGridViewTextBoxColumn
        'With monto_ocupa_calcu
        '    .HeaderText = "Monto Calculado por Ocupabilidad"
        '    .Name = "monto_ocupa_calcu"
        '    .DataPropertyName = "monto_ocupa_calcu"
        '    .Width = 70
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With

        'Dim otros As New DataGridViewTextBoxColumn
        'With otros
        '    .HeaderText = "otros"
        '    .Name = "otros"
        '    .DataPropertyName = "otros"
        '    .Width = 70
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With

        'Dim IDCOMI_CALCU As New DataGridViewTextBoxColumn
        'With IDCOMI_CALCU
        '    .HeaderText = "ID"
        '    .Name = "IDCOMI_CALCU"
        '    .DataPropertyName = "IDCOMI_CALCU"
        '    .Width = 30
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N0"
        '    '.DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With


        'With dgv2
        '    .Columns.AddRange(IDTIPO_COMPROBANTE, TIPO_COMPROBANTE, TOTAL_COSTO, AFEC_COMI, SUB_TOTAL, PORCEN, MONTO_PORCEN, NRO, monto_x_comprobante, Total_por_compro, para_monto_comi_ocu, monto_ocupa_calcu, otros, sub_total_pagar_comi)

        'End With

        'Me.TxtSubTotalConsulFunci.Text = 0

        'For i As Integer = 0 To Me.dgv2.Rows.Count - 1
        '    dgv2.CurrentCell = Me.dgv2.Rows(i).Cells(1)
        '    Me.TxtSubTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) + CDbl(Me.dgv2.CurrentRow.Cells("sub_total_pagar_comi").Value), 2)

        'Next

        'Me.TxtCargoConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto, 2)
        'Me.TxtTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto + CDbl(Me.TxtSubTotalConsulFunci.Text), 2)

    End Sub

    Private Sub FrmConsulComiFunci_MenuAyuda() Handles Me.MenuAyuda
        Try
            ObjReport.Dispose()
        Catch

        End Try

        ObjReport = New ClsLbTepsa.dtoFrmReport


        Try
            If Convert.ToDateTime(Me.dgv1.CurrentRow.Cells("FECHA_FINAL").Value) < Convert.ToDateTime("31/12/2011") Then
                OBJCOMISIONES.IDCOMI_CALCU_FUNCI = dgv1.CurrentRow.Cells("IDCOMI_CALCU_FUNCI").Value
                ObjReport.rutaRpt = PathFrmReport
                ObjReport.conectar(rptservice, rptuser, rptpass)
                ObjReport.printrpt(False, "", "CC001.RPT", _
                "p_IDCOMI_CALCU_FUNCI;" & OBJCOMISIONES.IDCOMI_CALCU_FUNCI)
            Else
                OBJCOMISIONES.FECHA_INI = Me.DTPFECHA_INI.Value.Date
                OBJCOMISIONES.FECHA_FINAL = Me.DTPFECHA_FINAL.Value.Date

                ObjReport.rutaRpt = PathFrmReport
                ObjReport.conectar(rptservice, rptuser, rptpass)
                ObjReport.printrpt(False, "", "ComisionFuncionario.RPT", "P_IDUSUARIO_PERSONAL_FUNCI;" & OBJCOMISIONES.IDFUNCIONARIO, "P_fecha_Ini;" & OBJCOMISIONES.FECHA_INI, "P_fecha_fin;" & OBJCOMISIONES.FECHA_FINAL)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FrmConsulComiFunci_MenuImprimir() Handles Me.MenuImprimir
        Try
            ObjReport.dispose()
        Catch

        End Try

        ObjReport = New ClsLbTepsa.dtoFrmReport


        Try
            If Convert.ToDateTime(Me.dgv1.CurrentRow.Cells("FECHA_FINAL").Value) < Convert.ToDateTime("31/12/2011") Then
                OBJCOMISIONES.IDCOMI_CALCU_FUNCI = dgv1.CurrentRow.Cells("IDCOMI_CALCU_FUNCI").Value
                ObjReport.rutaRpt = PathFrmReport
                ObjReport.conectar(rptservice, rptuser, rptpass)
                ObjReport.printrpt(False, "", "CC001.RPT", _
                "p_IDCOMI_CALCU_FUNCI;" & OBJCOMISIONES.IDCOMI_CALCU_FUNCI)
            Else
                OBJCOMISIONES.FECHA_INI = Me.DTPFECHA_INI.Value.Date
                OBJCOMISIONES.FECHA_FINAL = Me.DTPFECHA_FINAL.Value.Date

                ObjReport.rutaRpt = PathFrmReport
                ObjReport.conectar(rptservice, rptuser, rptpass)
                ObjReport.printrpt(False, "", "ComisionFuncionarioResumen.RPT", "P_IDUSUARIO_PERSONAL_FUNCI;" & OBJCOMISIONES.IDFUNCIONARIO, "P_fecha_Ini;" & OBJCOMISIONES.FECHA_INI, "P_fecha_fin;" & OBJCOMISIONES.FECHA_FINAL)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub dgv2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv2.CellContentClick

    End Sub

    Private Sub dgv2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv2.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv2), 0)
    End Sub

    Private Sub dgv2_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv2.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv2), 0)
    End Sub

    Private Sub dgv1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv1.RowsAdded
        Me.LblRegistros2.Text = FormatNumber(NumeroRegistro(Me.dgv1), 0)
    End Sub

    Private Sub dgv1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv1.RowsRemoved
        Me.LblRegistros2.Text = FormatNumber(NumeroRegistro(Me.dgv1), 0)
    End Sub

    Private Sub CBIDFUNCIONARIO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDFUNCIONARIO.SelectedIndexChanged
        Me.dgv1.DataSource = Nothing
        Me.dgv2.DataSource = Nothing
    End Sub

    Private Sub DTPFECHA_INI_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHA_INI.ValueChanged
        'If dtoUSUARIOS.IdLogin = 901 Then
        Dim intSel As Integer = Me.CBIDFUNCIONARIO.SelectedValue

        If Acceso.SiRol(G_Rol, Me, 1, 1) Then
            ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.CBIDFUNCIONARIO, Me.DTPFECHA_INI.Value.ToShortDateString, Me.DTPFECHA_FINAL.Value.ToShortDateString, 5, " (TODO)")
            Me.CBIDFUNCIONARIO.SelectedValue = intSel
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then
            ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.CBIDFUNCIONARIO, Me.DTPFECHA_INI.Value.ToShortDateString, Me.DTPFECHA_FINAL.Value.ToShortDateString, 2, " (TODO)")
            Me.CBIDFUNCIONARIO.SelectedValue = intSel
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 3) Then
            ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.CBIDFUNCIONARIO, "", "", 7, " (TODO)")
            Me.CBIDFUNCIONARIO.SelectedValue = intSel
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 4) Then
            ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.CBIDFUNCIONARIO, "", "", 7, " (TODO)")
            CBIDFUNCIONARIO.SelectedValue = dtoUSUARIOS.IdLogin
            CBIDFUNCIONARIO.Enabled = False
        Else
            Me.CBIDFUNCIONARIO.SelectedIndex = -1
        End If

        Me.dgv1.DataSource = Nothing
        Me.dgv2.DataSource = Nothing
    End Sub

    Private Sub DTPFECHA_FINAL_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHA_FINAL.ValueChanged
        'If dtoUSUARIOS.IdLogin = 901 Then
        Dim intSel As Integer = Me.CBIDFUNCIONARIO.SelectedValue
        If Acceso.SiRol(G_Rol, Me, 1, 1) Then
            ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.CBIDFUNCIONARIO, Me.DTPFECHA_INI.Value.ToShortDateString, Me.DTPFECHA_FINAL.Value.ToShortDateString, 5, " (TODO)")
            Me.CBIDFUNCIONARIO.SelectedValue = intSel
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then
            ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.CBIDFUNCIONARIO, Me.DTPFECHA_INI.Value.ToShortDateString, Me.DTPFECHA_FINAL.Value.ToShortDateString, 2, " (TODO)")
            Me.CBIDFUNCIONARIO.SelectedValue = intSel
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 3) Then
            ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.CBIDFUNCIONARIO, "", "", 7, " (TODO)")
            Me.CBIDFUNCIONARIO.SelectedValue = intSel
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 4) Then
            ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.CBIDFUNCIONARIO, "", "", 7, " (TODO)")
            CBIDFUNCIONARIO.SelectedValue = dtoUSUARIOS.IdLogin
            CBIDFUNCIONARIO.Enabled = False
        Else
            Me.CBIDFUNCIONARIO.SelectedIndex = -1
        End If
        Me.dgv1.DataSource = Nothing
        Me.dgv2.DataSource = Nothing
    End Sub

End Class