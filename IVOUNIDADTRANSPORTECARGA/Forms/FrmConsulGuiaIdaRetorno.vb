Public Class FrmConsulGuiaIdaRetorno
    '
    Dim dvguias_transportista_bultos As New DataView
    Dim dvguias_transportista As New DataView
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
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        listar_guia_transportista()
    End Sub

    Private Sub DGV3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellEnter
        'Dim obj As New ClsLbTepsa.dtoGUIA_TRANSPORTISTA

        'With obj
        '    .IDGUIA_TRANSPORTISTA = dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("IDGUIA_TRANSPORTISTA")
        '    '10/09/2007 
        '    '.factura_guia_transportista = Me.cmbestadofactura.SelectedValue
        '    '
        '    dvguias_transportista_bultos = .sp_list_guia_transpor_deta(VOCONTROLUSUARIO)
        '    Call FORMAT_GRILLA4()

        'End With
    End Sub
    Sub FORMAT_GRILLA4()
        'dgv4.Columns.Clear()

        'With dgv4
        '    .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        '    .Font = New Font("Arial", 8.0!, FontStyle.Regular)
        '    .AllowUserToOrderColumns = True
        '    .AllowUserToDeleteRows = False
        '    .AllowUserToAddRows = False
        '    .AutoGenerateColumns = False
        '    .DataSource = dvguias_transportista_bultos
        '    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
        '    .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        '    .VirtualMode = True
        '    .RowHeadersVisible = True
        '    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
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
            .ReadOnly = True
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "NOMBRE_AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO_ENVIO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO_ENVIO
            .HeaderText = "ESTADO_REGISTRO_ENVIO"
            .Name = "ESTADO_REGISTRO_ENVIO"
            .DataPropertyName = "ESTADO_REGISTRO_ENVIO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "ESTADO_REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "LOGIN"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SERIE As New DataGridViewTextBoxColumn
        With SERIE
            .HeaderText = "SERIE"
            .Name = "SERIE_GUIA_ENVIO"
            .DataPropertyName = "SERIE_GUIA_ENVIO"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NUMERO As New DataGridViewTextBoxColumn
        With NUMERO
            .HeaderText = "NUMERO"
            .Name = "NRO_GUIA"
            .DataPropertyName = "NRO_GUIA"
            .Width = 130
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
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
        End With
        Dim TOTAL_SOBRES As New DataGridViewTextBoxColumn
        With TOTAL_SOBRES
            .HeaderText = "TOTAL_SOBRES"
            .Name = "TOTAL_SOBRES"
            .DataPropertyName = "TOTAL_SOBRES"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
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
        End With
        Dim TOTAL_PESO As New DataGridViewTextBoxColumn
        With TOTAL_PESO
            .HeaderText = "T. Peso"
            .Name = "TOTAL_PESO"
            .DataPropertyName = "TOTAL_PESO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim TOTAL_VOLUMEN As New DataGridViewTextBoxColumn
        With TOTAL_VOLUMEN
            .HeaderText = "T. Vol."
            .Name = "TOTAL_VOLUMEN"
            .DataPropertyName = "TOTAL_VOLUMEN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim CANTIDAD As New DataGridViewTextBoxColumn
        With CANTIDAD
            .HeaderText = "CANTIDAD"
            .Name = "CANTIDAD"
            .DataPropertyName = "CANTIDAD"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With
        Dim CANTIDAD_RECEPCIONAR As New DataGridViewTextBoxColumn
        With CANTIDAD_RECEPCIONAR
            .HeaderText = "CANTIDAD_RECEPCIONAR"
            .Name = "CANTIDAD_RECEPCIONAR"
            .DataPropertyName = "CANTIDAD_RECEPCIONAR"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With

        Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        With TIPO_COMPROBANTE
            .HeaderText = "TIPO_COMPROBANTE"
            .Name = "TIPO_COMPROBANTE"
            .DataPropertyName = "TIPO_COMPROBANTE"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With


        'With dgv4
        '    .Columns.AddRange(TIPO_COMPROBANTE, RAZON_SOCIAL, SERIE, NUMERO, FECHA, TOTAL_SOBRES, TOTAL_PESO, TOTAL_VOLUMEN, CANTIDAD, CANTIDAD_RECEPCIONAR, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, ESTADO_REGISTRO, ESTADO_REGISTRO_ENVIO)

        'End With
        'Me.txtSobres_deta.Text = 0
        'Me.txtPeso_deta.Text = 0
        'Me.txtVolumen_deta.Text = 0
        'Me.txtsub_total_deta.Text = 0
        'Me.txtmonto_impuesto_deta.Text = 0
        'Me.txttotal_costo_deta.Text = 0

        'For i As Integer = 0 To dvguias_transportista_bultos.Count - 1
        '    Me.txtSobres_deta.Text = FormatNumber(CDbl(Me.txtSobres_deta.Text) + dvguias_transportista_bultos.Table.Rows(i)("total_sobres"), 2)
        '    Me.txtPeso_deta.Text = FormatNumber(CDbl(Me.txtPeso_deta.Text) + dvguias_transportista_bultos.Table.Rows(i)("total_peso"), 2)
        '    Me.txtVolumen_deta.Text = FormatNumber(CDbl(Me.txtVolumen_deta.Text) + dvguias_transportista_bultos.Table.Rows(i)("total_volumen"), 2)
        '    Me.txtsub_total_deta.Text = FormatNumber(CDbl(Me.txtsub_total_deta.Text) + dvguias_transportista_bultos.Table.Rows(i)("SUB_TOTAL"), 2)
        '    Me.txtmonto_impuesto_deta.Text = FormatNumber(CDbl(Me.txtmonto_impuesto_deta.Text) + dvguias_transportista_bultos.Table.Rows(i)("MONTO_IMPUESTO"), 2)
        '    Me.txttotal_costo_deta.Text = FormatNumber(CDbl(Me.txttotal_costo_deta.Text) + dvguias_transportista_bultos.Table.Rows(i)("TOTAL_COSTO"), 2)
        'Next
        'L2.Text = dvguias_transportista_bultos.Count
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
            .DataSource = dvguias_transportista
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        Dim Es_Recepcionado_decrip As New DataGridViewTextBoxColumn
        With Es_Recepcionado_decrip
            .HeaderText = "Es_Recepcionado_decrip"
            .Name = "Es_Recepcionado_decrip"
            .DataPropertyName = "Es_Recepcionado_decrip"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        '
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "ESTADO_REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        '
        Dim TIPO_SERVICIO As New DataGridViewTextBoxColumn
        With TIPO_SERVICIO
            .HeaderText = "TIPO_SERVICIO"
            .Name = "SERVICIO"
            .DataPropertyName = "SERVICIO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim PILOTO As New DataGridViewTextBoxColumn
        With PILOTO
            .HeaderText = "PILOTO"
            .Name = "PILOTO"
            .DataPropertyName = "PILOTO"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "LOGIN"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim NOMBRE_UNIDAD_ORI As New DataGridViewTextBoxColumn
        With NOMBRE_UNIDAD_ORI
            .HeaderText = "ORI"
            .Name = "NOMBRE_UNIDAD_ORI"
            .DataPropertyName = "NOMBRE_UNIDAD_ORI"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim NOMBRE_UNIDAD_DESTI As New DataGridViewTextBoxColumn
        With NOMBRE_UNIDAD_DESTI
            .HeaderText = "DESTI"
            .Name = "NOMBRE_UNIDAD_DESTI"
            .DataPropertyName = "NOMBRE_UNIDAD_DESTI"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With



        Dim NRO_UNIDAD_TRANSPORTE As New DataGridViewTextBoxColumn
        With NRO_UNIDAD_TRANSPORTE
            .HeaderText = "NRO_UNIDAD_TRANSPORTE"
            .Name = "NRO_UNIDAD_TRANSPORTE"
            .DataPropertyName = "NRO_UNIDAD_TRANSPORTE"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim PLACA As New DataGridViewTextBoxColumn
        With PLACA
            .HeaderText = "PLACA"
            .Name = "PLACA"
            .DataPropertyName = "PLACA"
            .Width = 15
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim NRO_EJES As New DataGridViewTextBoxColumn
        With NRO_EJES
            .HeaderText = "NRO_EJES"
            .Name = "NRO_EJES"
            .DataPropertyName = "NRO_EJES"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDRESPONSABLE As New DataGridViewTextBoxColumn
        With IDRESPONSABLE
            .HeaderText = "IDRESPONSABLE"
            .Name = "IDRESPONSABLE"
            .DataPropertyName = "IDRESPONSABLE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDMODELO_UNIDAD As New DataGridViewTextBoxColumn
        With IDMODELO_UNIDAD
            .HeaderText = "IDMODELO_UNIDAD"
            .Name = "IDMODELO_UNIDAD"
            .DataPropertyName = "IDMODELO_UNIDAD"
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDTIPO_UNIDAD_TRANSPORTE As New DataGridViewTextBoxColumn
        With IDTIPO_UNIDAD_TRANSPORTE
            .HeaderText = "IDTIPO_UNIDAD_TRANSPORTE"
            .Name = "IDTIPO_UNIDAD_TRANSPORTE"
            .DataPropertyName = "IDTIPO_UNIDAD_TRANSPORTE"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NRO_PISOS As New DataGridViewTextBoxColumn
        With NRO_PISOS
            .HeaderText = "NRO_PISOS"
            .Name = "NRO_PISOS"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "NRO_PISOS"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NRO_TELEVISORES As New DataGridViewTextBoxColumn
        With NRO_TELEVISORES
            .HeaderText = "NRO_TELEVISORES"
            .Name = "NRO_TELEVISORES"
            .DataPropertyName = "NRO_TELEVISORES"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim PESO_VEHICULO_TONELADAS As New DataGridViewTextBoxColumn
        With PESO_VEHICULO_TONELADAS
            .HeaderText = "PESO_VEHICULO_TONELADAS"
            .Name = "PESO_VEHICULO_TONELADAS"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "PESO_VEHICULO_TONELADAS"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NRO_BANIOS As New DataGridViewTextBoxColumn
        With NRO_BANIOS
            .HeaderText = "NRO_BANIOS"
            .Name = "NRO_BANIOS"
            .DataPropertyName = "NRO_BANIOS"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim PESO_MAXIMO_CARGA_KG As New DataGridViewTextBoxColumn
        With PESO_MAXIMO_CARGA_KG
            .HeaderText = "PESO_MAXIMO_CARGA_KG"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Name = "PESO_MAXIMO_CARGA_KG"
            .DataPropertyName = "PESO_MAXIMO_CARGA_KG"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim CAPACIDAD As New DataGridViewTextBoxColumn
        With CAPACIDAD
            .HeaderText = "CAPACIDAD"
            .Name = "CAPACIDAD"
            .DataPropertyName = "CAPACIDAD"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim FECHA_LLEGADA As New DataGridViewTextBoxColumn
        With FECHA_LLEGADA
            .HeaderText = "FECHA_LLEGADA"
            .Name = "FECHA_LLEGADA"
            .DataPropertyName = "FECHA_LLEGADA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim HORA_LLEGADA As New DataGridViewTextBoxColumn
        With HORA_LLEGADA
            .HeaderText = "HORA_LLEGADA"
            .Name = "HORA_LLEGADA"
            .DataPropertyName = "HORA_LLEGADA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim IDUSUARIO_RECEPCION As New DataGridViewTextBoxColumn
        With IDUSUARIO_RECEPCION
            .HeaderText = "IDUSUARIO_RECEPCION"
            .Name = "IDUSUARIO_RECEPCION"
            .DataPropertyName = "IDUSUARIO_RECEPCION"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDGUIA_TRANSPORTISTA As New DataGridViewTextBoxColumn
        With IDGUIA_TRANSPORTISTA
            .HeaderText = "IDGUIA_TRANSPORTISTA"
            .Name = "IDGUIA_TRANSPORTISTA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "IDGUIA_TRANSPORTISTA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim SERIE_GUIA_TRANSPORTISTA As New DataGridViewTextBoxColumn
        With SERIE_GUIA_TRANSPORTISTA
            .HeaderText = "SERIE_GUIA_TRANSPORTISTA"
            .Name = "SERIE_GUIA_TRANSPORTISTA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "SERIE_GUIA_TRANSPORTISTA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NRO_GUIA_TRANSPORTISTA As New DataGridViewTextBoxColumn
        With NRO_GUIA_TRANSPORTISTA
            .HeaderText = "NRO_GUIA_TRANSPORTISTA"
            .Name = "NRO_GUIA_TRANSPORTISTA"
            .DataPropertyName = "NRO_GUIA_TRANSPORTISTA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDUNIDAD_AGENCIA As New DataGridViewTextBoxColumn
        With IDUNIDAD_AGENCIA
            .HeaderText = "IDUNIDAD_AGENCIA"
            .Name = "IDUNIDAD_AGENCIA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "IDUNIDAD_AGENCIA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDUNIDAD_AGENCIA_DESTINO As New DataGridViewTextBoxColumn
        With IDUNIDAD_AGENCIA_DESTINO
            .HeaderText = "IDUNIDAD_AGENCIA_DESTINO"
            .Name = "IDUNIDAD_AGENCIA_DESTINO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "IDUNIDAD_AGENCIA_DESTINO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDITINERARIOS As New DataGridViewTextBoxColumn
        With IDITINERARIOS
            .HeaderText = "IDITINERARIOS"
            .SortMode = DataGridViewColumnSortMode.NotSortable

            .Name = "IDITINERARIOS"
            .DataPropertyName = "IDITINERARIOS"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDUNIDAD_TRANSPORTE As New DataGridViewTextBoxColumn
        With IDUNIDAD_TRANSPORTE
            .HeaderText = "IDUNIDAD_TRANSPORTE"
            .Name = "IDUNIDAD_TRANSPORTE"
            .DataPropertyName = "IDUNIDAD_TRANSPORTE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDUSUARIO_PERSONAL_PILOTO As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONAL_PILOTO
            .HeaderText = "IDUSUARIO_PERSONAL_PILOTO"
            .Name = "IDUSUARIO_PERSONAL_PILOTO"
            .DataPropertyName = "IDUSUARIO_PERSONAL_PILOTO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim FECHA_SALIDA As New DataGridViewTextBoxColumn
        With FECHA_SALIDA
            .HeaderText = "FECHA_SALIDA"
            .Name = "FECHA_SALIDA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "FECHA_SALIDA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim HORA_SALIDA As New DataGridViewTextBoxColumn
        With HORA_SALIDA
            .HeaderText = "HORA_SALIDA"
            .Name = "HORA_SALIDA"
            .DataPropertyName = "HORA_SALIDA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONAL
            .HeaderText = "IDUSUARIO_PERSONAL"
            .Name = "IDUSUARIO_PERSONAL"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "IDUSUARIO_PERSONAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDROL_USUARIO As New DataGridViewTextBoxColumn
        With IDROL_USUARIO
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "IDROL_USUARIO"
            .Name = "IDROL_USUARIO"
            .DataPropertyName = "IDROL_USUARIO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IP As New DataGridViewTextBoxColumn
        With IP
            .HeaderText = "IP"
            .Name = "IP"
            .DataPropertyName = "IP"
            .Width = 15
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim IDUSUARIO_PERSONALMOD As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONALMOD
            .HeaderText = "IDUSUARIO_PERSONALMOD"
            .Name = "IDUSUARIO_PERSONALMOD"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "IDUSUARIO_PERSONALMOD"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDROL_USUARIOMOD As New DataGridViewTextBoxColumn
        With IDROL_USUARIOMOD
            .HeaderText = "IDROL_USUARIOMOD"
            .Name = "IDROL_USUARIOMOD"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "IDROL_USUARIOMOD"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IPMOD As New DataGridViewTextBoxColumn
        With IPMOD
            .HeaderText = "IPMOD"
            .Name = "IPMOD"
            .DataPropertyName = "IPMOD"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 15
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim IDESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With IDESTADO_REGISTRO
            .HeaderText = "IDESTADO_REGISTRO"
            .Name = "IDESTADO_REGISTRO"
            .DataPropertyName = "IDESTADO_REGISTRO"
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim FECHA_REGISTRO As New DataGridViewTextBoxColumn
        With FECHA_REGISTRO
            .HeaderText = "FECHA_REGISTRO"
            .Name = "FECHA_REGISTRO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "FECHA_REGISTRO"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim FECHA_ACTUALIZACION As New DataGridViewTextBoxColumn
        With FECHA_ACTUALIZACION
            .HeaderText = "FECHA_ACTUALIZACION"
            .Name = "FECHA_ACTUALIZACION"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "FECHA_ACTUALIZACION"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim NRO_SALIDA As New DataGridViewTextBoxColumn
        With NRO_SALIDA
            .HeaderText = "NRO_SALIDA"
            .Name = "NRO_SALIDA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "NRO_SALIDA"
            .Width = 6
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim IDTIPO_SERVICIO As New DataGridViewTextBoxColumn
        With IDTIPO_SERVICIO
            .HeaderText = "IDTIPO_SERVICIO"
            .Name = "IDTIPO_SERVICIO"
            .DataPropertyName = "IDTIPO_SERVICIO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim MARCA_BUS As New DataGridViewTextBoxColumn
        With MARCA_BUS
            .HeaderText = "MARCA_BUS"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Name = "MARCA_BUS"
            .DataPropertyName = "MARCA_BUS"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim PLACA_BUS As New DataGridViewTextBoxColumn
        With PLACA_BUS
            .HeaderText = "PLACA_BUS"
            .Name = "PLACA_BUS"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "PLACA_BUS"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim NRO_LICENCIA As New DataGridViewTextBoxColumn
        With NRO_LICENCIA
            .HeaderText = "NRO_LICENCIA"
            .Name = "NRO_LICENCIA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "NRO_LICENCIA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim RUC_TERCERO As New DataGridViewTextBoxColumn
        With RUC_TERCERO
            .HeaderText = "RUC_TERCERO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Name = "RUC_TERCERO"
            .DataPropertyName = "RUC_TERCERO"
            .Width = 11
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With
        Dim NOM_TERCERO As New DataGridViewTextBoxColumn
        With NOM_TERCERO
            .HeaderText = "NOM_TERCERO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Name = "NOM_TERCERO"
            .DataPropertyName = "NOM_TERCERO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With

        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "MONTO_IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 70
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUB_TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim TOTAL_SOBRES As New DataGridViewTextBoxColumn
        With TOTAL_SOBRES
            .HeaderText = "TOTAL_SOBRES"
            .Name = "TOTAL_SOBRES"
            .DataPropertyName = "TOTAL_SOBRES"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim TOTAL_PESO As New DataGridViewTextBoxColumn
        With TOTAL_PESO
            .HeaderText = "TOTAL_PESO"
            .Name = "TOTAL_PESO"
            .DataPropertyName = "TOTAL_PESO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim TOTAL_VOLUMEN As New DataGridViewTextBoxColumn
        With TOTAL_VOLUMEN
            .HeaderText = "TOTAL_VOLUMEN"
            .Name = "TOTAL_VOLUMEN"
            .DataPropertyName = "TOTAL_VOLUMEN"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim CANTIDAD As New DataGridViewTextBoxColumn
        With CANTIDAD
            .HeaderText = "CANTIDAD"
            .Name = "CANTIDAD"
            .DataPropertyName = "CANTIDAD"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With

        Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        With TIPO_COMPROBANTE
            .HeaderText = "TIPO_COMPROBANTE"
            .Name = "COMPROBANTE"
            .DataPropertyName = "COMPROBANTE"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim I_R As New DataGridViewTextBoxColumn
        With I_R
            .HeaderText = "Ida/Retor/Inter"
            .Name = "I_R"
            .DataPropertyName = "I_R"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim SOBRES As New DataGridViewTextBoxColumn
        With SOBRES
            .HeaderText = "SOBRES"
            .Name = "SOBRES"
            .DataPropertyName = "SOBRES"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With

        Dim MONTO As New DataGridViewTextBoxColumn
        With MONTO
            .HeaderText = "MONTO"
            .Name = "MONTO"
            .DataPropertyName = "MONTO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim VOLUMEN As New DataGridViewTextBoxColumn
        With VOLUMEN
            .HeaderText = "VOLUMEN"
            .Name = "VOLUMEN"
            .DataPropertyName = "VOLUMEN"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim PESO As New DataGridViewTextBoxColumn
        With PESO
            .HeaderText = "PESO"
            .Name = "PESO"
            .DataPropertyName = "PESO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        With DGV3
            .Columns.AddRange(I_R, TIPO_SERVICIO, TIPO_COMPROBANTE, CANTIDAD, SOBRES, PESO, VOLUMEN, MONTO)
        End With
        'Me.txtSobres_cabe.Text = 0
        'Me.txtPeso_cabe.Text = 0
        'Me.txtVolumen_cabe.Text = 0
        'Me.txtsub_total_cabe.Text = 0
        'Me.txtmonto_impuesto_cabe.Text = 0
        'Me.txttotal_costo_cabe.Text = 0

        'For i As Integer = 0 To dvguias_transportista.Count - 1
        '    Me.txtSobres_cabe.Text = FormatNumber(CDbl(Me.txtSobres_cabe.Text) + dvguias_transportista.Table.Rows(i)("total_sobres"), 2)
        '    Me.txtPeso_cabe.Text = FormatNumber(CDbl(Me.txtPeso_cabe.Text) + dvguias_transportista.Table.Rows(i)("total_peso"), 2)
        '    Me.txtVolumen_cabe.Text = FormatNumber(CDbl(Me.txtVolumen_cabe.Text) + dvguias_transportista.Table.Rows(i)("total_volumen"), 2)
        '    Me.txtsub_total_cabe.Text = FormatNumber(CDbl(Me.txtsub_total_cabe.Text) + dvguias_transportista.Table.Rows(i)("SUB_TOTAL"), 2)
        '    Me.txtmonto_impuesto_cabe.Text = FormatNumber(CDbl(Me.txtmonto_impuesto_cabe.Text) + dvguias_transportista.Table.Rows(i)("MONTO_IMPUESTO"), 2)
        '    Me.txttotal_costo_cabe.Text = FormatNumber(CDbl(Me.txttotal_costo_cabe.Text) + dvguias_transportista.Table.Rows(i)("TOTAL_COSTO"), 2)
        'Next

        L1.Text = dvguias_transportista.Count
    End Sub

    Private Sub FrmConsulGuiaIdaRetorno_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulGuiaIdaRetorno_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Consulta Idas/Retornos"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False

            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0
            'Mod.12/10/2009 -->Omendoza - Pasando al datahelper -  
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            '
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            '
            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA)
            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA_DESTINO)
            'objgeneral.FN_estado_facturado(VOCONTROLUSUARIO, Me.cmbestadofactura)
            '10/09/2007 
            'Me.cmbestadofactura.SelectedValue = 2 ' Por defecto aparece todos 
            '
            'Datahelper
            objgeneral.FN_cmb_sp_L_tipo_servicio(Me.cbidtipo_servicio)

            'Me.CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            'Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
            cbidtipo_servicio.SelectedIndex = -1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub FrmConsulFactuEmiti_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub
    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus
        'Me.Txtguiatransportista.Text = ""
        'dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
        L1.Text = ""
        'L2.Text = ""
    End Sub
    Private Sub DTPFECHAINICIOFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAINICIOFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            'Me.Txtguiatransportista.Text = ""
            DTPFECHAFINALFACTURA.Focus()

        End If
    End Sub
    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.GotFocus
        'Me.Txtguiatransportista.Text = ""
        'dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
        L1.Text = ""
        'L2.Text = ""
    End Sub
    Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub
    Private Sub CBIDUNIDAD_AGENCIA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Txtguiatransportista.Text = ""
        'dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
        L1.Text = ""
        'L2.Text = ""
    End Sub
    Private Sub cmbestadofactura_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
        L1.Text = ""
        'L2.Text = ""
    End Sub
    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidtipo_servicio.GotFocus
        'Me.Txtguiatransportista.Text = ""
        'dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
        L1.Text = ""
        'L2.Text = ""
    End Sub
    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            'CBIDUNIDAD_AGENCIA.Focus()
        End If
    End Sub
    Private Sub CBIDUNIDAD_AGENCIA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            ' CBIDUNIDAD_AGENCIA_DESTINO.Focus()
        End If
    End Sub
    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_servicio.KeyPress
        If e.KeyChar = Chr(13) Then
            Button3.Focus()
        End If
    End Sub
    Private Sub RecepcionarTodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objGUIA_TRANSPORTISTA_DETALL As New ClsLbTepsa.dtoGUIA_TRANSPORTISTA_DETALL

        If dvguias_transportista.Table.Rows.Count <= 0 Then
            MsgBox("No existe ninguna guia de transportista", MsgBoxStyle.Information, "Seguridad el sistema")
            Exit Sub
        End If
        If Not dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("es_recepcionado") = 0 Then
            MsgBox("no se puede realizar la rerecpcion total, existe rececion parcial o total", MsgBoxStyle.Information, "Seguridad el sistema")
            Exit Sub
        End If

        objGUIA_TRANSPORTISTA_DETALL.IDGUIA_TRANSPORTISTA = dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("IDGUIA_TRANSPORTISTA")
        objGUIA_TRANSPORTISTA_DETALL.IDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad
        '
        'Mod.12/10/2009 -->Omendoza - Pasando al datahelper -  
        'objGUIA_TRANSPORTISTA_DETALL.sp_recepcionar_todosII(VOCONTROLUSUARIO)
        '
        objGUIA_TRANSPORTISTA_DETALL.sp_recepcionar_todosII()
        '
        dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("es_recepcionado") = 1

        Dim obj As New ClsLbTepsa.dtoGUIA_TRANSPORTISTA

        With obj
            .IDGUIA_TRANSPORTISTA = dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("IDGUIA_TRANSPORTISTA")
            'Mod.12/10/2009 -->Omendoza - Pasando al datahelper -  
            'dvguias_transportista_bultos = .sp_list_guia_transpor_deta(VOCONTROLUSUARIO)
            dvguias_transportista_bultos = .sp_list_guia_transpor_deta()
            '
            Call FORMAT_GRILLA4()

            dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("es_recepcionado") = 1
            dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("Es_Recepcionado_decrip") = "RECEP"

        End With
    End Sub
    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellContentClick
    End Sub
    Private Sub TabLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabLista.Click
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub
    Private Sub ChkGuiaTranspor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGuiaTranspor.CheckedChanged
        If Me.ChkMani.Checked = False Then
            ChkGuiaTranspor.Checked = True
        End If
        Me.DGV3.DataSource = Nothing
    End Sub
    Private Sub ChkMani_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMani.CheckedChanged
        If Me.ChkGuiaTranspor.Checked = False Then
            Me.ChkMani.Checked = True
        End If
        Me.DGV3.DataSource = Nothing
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
                SendKeys.Send("{Tab}")
                Return True
            End If
            Return MyBase.ProcessCmdKey(msg, KeyData)
            'Dim var As Integer = msg.WParam.ToInt32
            'If msg.WParam.ToInt32 = CInt(Keys.Enter) Then
            '    If Me.Txtguiatransportista.Focused = True Then
            '        fnBuscarguias()
            '        Return True
            '    End If
            'End If
            'Return MyBase.ProcessCmdKey(msg, KeyData)
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function

    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
    '    If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '        Return True
    '    End If
    '    Return MyBase.ProcessCmdKey(msg, keyData)
    'End Function
    Function fnBuscarguias()
        'Try
        '    Dim lserie As String
        '    Dim lnro_serie As String
        '    'Dim strNroDoc As String() = Split(Me.Txtguiatransportista.Text, "-")
        '    Dim ObjGUIA_TRANSPORTISTA As New ClsLbTepsa.dtoGUIA_TRANSPORTISTA
        '    '
        '    If strNroDoc.Length > 1 Then
        '        If Val(strNroDoc(0)) > 0 And Val(strNroDoc(1)) > 0 Then
        '            lserie = strNroDoc(0)
        '            lnro_serie = strNroDoc(1)
        '            'Invoca la busqueda  a partir de la guia de transportista 
        '            ObjGUIA_TRANSPORTISTA.s_SERIE_GUIA_TRANSPORTISTA = lserie
        '            ObjGUIA_TRANSPORTISTA.s_NRO_GUIA_TRANSPORTISTA = lnro_serie
        '            'ObjGUIA_TRANSPORTISTA.factura_guia_transportista = Me.cmbestadofactura.SelectedValue
        '            dvguias_transportista = ObjGUIA_TRANSPORTISTA.sp_get_guia_transportista_i(VOCONTROLUSUARIO)
        '            FORMAT_GRILLA3()
        '            dgv4.DataSource = Nothing
        '            'bbL2.Text = ""
        '        End If
        '    Else
        '        MsgBox("No a ingresado una guia transportista v?lida", MsgBoxStyle.Information, "Consulta gu?a Transportista")
        '        Exit Function
        '    End If
        'Catch ex As Exception

        'End Try
    End Function
    Private Sub TBnro_unidad_transporte_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Me.Txtguiatransportista.Text = ""
    End Sub

    Private Sub Txtguiatransportista_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
        L1.Text = ""
        'L2.Text = ""
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

                    Dim ObjGUIA_TRANSPORTISTA As New ClsLbTepsa.dtoGUIA_TRANSPORTISTA



                    'If Not IsNothing(CBIDUNIDAD_AGENCIA.SelectedValue) Then
                    'ObjGUIA_TRANSPORTISTA.IDUNIDAD_AGENCIA = Me.CBIDUNIDAD_AGENCIA.SelectedValue
                    'Else
                    ObjGUIA_TRANSPORTISTA.IDUNIDAD_AGENCIA = 0
                    'End If


                    'If Not IsNothing(CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                    '                    ObjGUIA_TRANSPORTISTA.IDUNIDAD_AGENCIA_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
                    'Else
                    ObjGUIA_TRANSPORTISTA.IDUNIDAD_AGENCIA_DESTINO = 0
                    'End If



                    'If Not Len(Me.TBnro_unidad_transporte.Text.Trim) = 0 Then
                    '    Dim a As New ClsLbTepsa.dtoValida
                    '    If a.NUMERO_NO_CERO(Me.TBnro_unidad_transporte, Me) = False Then
                    '        a = Nothing
                    '        Exit Sub
                    '    End If
                    '    If a.NUMERO_NO_NEGATIVO(Me.TBnro_unidad_transporte, Me) = False Then
                    '        Exit Sub
                    '        a = Nothing
                    '    End If
                    '    If a.NUMERO_ENTERO(Me.TBnro_unidad_transporte, Me) = False Then
                    '        Exit Sub
                    '        a = Nothing
                    '    End If
                    '    a = Nothing
                    '    ObjGUIA_TRANSPORTISTA.nro_unidad_transporte = CType(Me.TBnro_unidad_transporte.Text.Trim, Long)
                    'Else
                    ObjGUIA_TRANSPORTISTA.nro_unidad_transporte = 0
                    'End If


                    If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjGUIA_TRANSPORTISTA.FECHA_INICIAL = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjGUIA_TRANSPORTISTA.FECHA_INICIAL = "NULL"
                    If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjGUIA_TRANSPORTISTA.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjGUIA_TRANSPORTISTA.FECHA_FINAL = "NULL"

                    If Not IsNothing(cbidtipo_servicio.SelectedValue) Then
                        ObjGUIA_TRANSPORTISTA.IDTIPO_SERVICIO = Me.cbidtipo_servicio.SelectedValue
                    Else
                        ObjGUIA_TRANSPORTISTA.IDTIPO_SERVICIO = 0
                    End If

                    'Dim ObjFrmReport As New ClsLbTepsa.dtoFrmReport

                    If ((Me.ChkGuiaTranspor.Checked = True) And (Me.ChkMani.Checked = True)) Then
                        ObjGUIA_TRANSPORTISTA.TIPO_GUIA = "0"
                    ElseIf ((Me.ChkGuiaTranspor.Checked = True) And (Me.ChkMani.Checked = False)) Then
                        ObjGUIA_TRANSPORTISTA.TIPO_GUIA = "G"
                    Else
                        ObjGUIA_TRANSPORTISTA.TIPO_GUIA = "M"
                    End If
                    'ObjGUIA_TRANSPORTISTA.factura_guia_transportista = Me.cmbestadofactura.SelectedValue



                    If Me.RBIDA.Checked = True Then
                        ObjGUIA_TRANSPORTISTA.IDA_RETORNO = "IDAS"
                    ElseIf Me.RBRETORNO.Checked = True Then
                        ObjGUIA_TRANSPORTISTA.IDA_RETORNO = "RETORNOS"
                    ElseIf Me.RBINTER.Checked = True Then
                        ObjGUIA_TRANSPORTISTA.IDA_RETORNO = "INTERMEDIOS"
                    ElseIf Me.RBAMBOS.Checked = True Then
                        ObjGUIA_TRANSPORTISTA.IDA_RETORNO = "0"
                    End If


                    ObjReport.rutaRpt = PathFrmReport
                    ObjReport.conectar(rptservice, rptuser, rptpass)


                    ObjReport.printrptB(False, "", "GUI019.rpt", _
                    "P_TIPO_GUIA;" & ObjGUIA_TRANSPORTISTA.TIPO_GUIA, _
                    "P_RANGO_FECHA;" & "(Desde " & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString & " al " & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString & ")", _
                    "P_FECHA_INI;" & ObjGUIA_TRANSPORTISTA.FECHA_INICIAL, _
                    "P_FECHA_FINAL;" & ObjGUIA_TRANSPORTISTA.FECHA_FINAL, _
                    "P_IDTIPO_SERVICIO;" & ObjGUIA_TRANSPORTISTA.IDTIPO_SERVICIO, _
                    "P_IDA_RETORNO;" & ObjGUIA_TRANSPORTISTA.IDA_RETORNO)

                    'ObjFrmReport

                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
                End Try
        End Select
    End Sub
    Private Sub listar_guia_transportista()
        Try
            'If Me.Txtguiatransportista.Text <> "" Then
            fnBuscarguias()
            'Else
            '
            Dim ObjGUIA_TRANSPORTISTA As New ClsLbTepsa.dtoGUIA_TRANSPORTISTA
            '
            'If Not IsNothing(CBIDUNIDAD_AGENCIA.SelectedValue) Then
            'ObjGUIA_TRANSPORTISTA.IDUNIDAD_AGENCIA = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            'Else
            ObjGUIA_TRANSPORTISTA.IDUNIDAD_AGENCIA = 0
            'End If
            '
            '            If Not IsNothing(CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
            'ObjGUIA_TRANSPORTISTA.IDUNIDAD_AGENCIA_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            'Else
            ObjGUIA_TRANSPORTISTA.IDUNIDAD_AGENCIA_DESTINO = 0
            'End If
            '
            'If Not Len(Me.TBnro_unidad_transporte.Text.Trim) = 0 Then
            '    Dim a As New ClsLbTepsa.dtoValida
            '    If a.NUMERO_NO_CERO(Me.TBnro_unidad_transporte, Me) = False Then
            '        a = Nothing
            '        Exit Sub
            '    End If
            '    If a.NUMERO_NO_NEGATIVO(Me.TBnro_unidad_transporte, Me) = False Then
            '        Exit Sub
            '        a = Nothing
            '    End If
            '    If a.NUMERO_ENTERO(Me.TBnro_unidad_transporte, Me) = False Then
            '        Exit Sub
            '        a = Nothing
            '    End If
            '    a = Nothing
            '    ObjGUIA_TRANSPORTISTA.nro_unidad_transporte = CType(Me.TBnro_unidad_transporte.Text.Trim, Long)
            'Else
            ObjGUIA_TRANSPORTISTA.nro_unidad_transporte = 0
            'End If
            '
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjGUIA_TRANSPORTISTA.FECHA_INICIAL = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjGUIA_TRANSPORTISTA.FECHA_INICIAL = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjGUIA_TRANSPORTISTA.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjGUIA_TRANSPORTISTA.FECHA_FINAL = "NULL"
            '
            If Not IsNothing(cbidtipo_servicio.SelectedValue) Then
                ObjGUIA_TRANSPORTISTA.IDTIPO_SERVICIO = Me.cbidtipo_servicio.SelectedValue
            Else
                ObjGUIA_TRANSPORTISTA.IDTIPO_SERVICIO = 0
            End If
            '
            If ((Me.ChkGuiaTranspor.Checked = True) And (Me.ChkMani.Checked = True)) Then
                ObjGUIA_TRANSPORTISTA.TIPO_GUIA = "0"
            ElseIf ((Me.ChkGuiaTranspor.Checked = True) And (Me.ChkMani.Checked = False)) Then
                ObjGUIA_TRANSPORTISTA.TIPO_GUIA = "G"
            Else
                ObjGUIA_TRANSPORTISTA.TIPO_GUIA = "M"
            End If
            '10/09/2007 
            'ObjGUIA_TRANSPORTISTA.factura_guia_transportista = Me.cmbestadofactura.SelectedValue
            '

            If Me.RBIDA.Checked = True Then
                ObjGUIA_TRANSPORTISTA.IDA_RETORNO = "IDAS"
            ElseIf Me.RBRETORNO.Checked = True Then
                ObjGUIA_TRANSPORTISTA.IDA_RETORNO = "RETORNOS"
            ElseIf Me.RBINTER.Checked = True Then
                ObjGUIA_TRANSPORTISTA.IDA_RETORNO = "INTERMEDIOS"
            ElseIf Me.RBAMBOS.Checked = True Then
                ObjGUIA_TRANSPORTISTA.IDA_RETORNO = "0"
            End If

            'Mod.12/10/2009 -->Omendoza - Pasando al datahelper -  
            'dvguias_transportista = ObjGUIA_TRANSPORTISTA.SP_IDA_RETORNO(cnn)
            dvguias_transportista = ObjGUIA_TRANSPORTISTA.SP_IDA_RETORNO()

            FORMAT_GRILLA3()
            'dgv4.DataSource = Nothing
            'L2.Text = ""
            'End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
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

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_servicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidtipo_servicio.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBIDA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBIDA.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBRETORNO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBRETORNO.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBINTER_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBINTER.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBAMBOS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBAMBOS.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub
End Class
