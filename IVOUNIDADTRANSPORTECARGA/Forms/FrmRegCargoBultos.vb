Public Class FrmRegCargoBultos

    Dim dr As Long
    Dim cantidad_recepcionar As Long

    Dim dvguias_transportista_bultos As New DataView
    Dim dvguias_transportista As New DataView

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
        listar_guia_transportista()
    End Sub
    Private Sub listar_guia_transportista()
        Try
            Dim ObjGUIA_TRANSPORTISTA As New ClsLbTepsa.dtoGUIA_TRANSPORTISTA

            If Not IsNothing(CBIDUNIDAD_AGENCIA.SelectedValue) Then
                ObjGUIA_TRANSPORTISTA.IDUNIDAD_AGENCIA = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            Else
                ObjGUIA_TRANSPORTISTA.IDUNIDAD_AGENCIA = 0
            End If
            If Not IsNothing(cmbAgencia.SelectedValue) Then
                ObjGUIA_TRANSPORTISTA.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            Else
                ObjGUIA_TRANSPORTISTA.IDAGENCIAS = 0
            End If



            If Not IsNothing(CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                ObjGUIA_TRANSPORTISTA.IDUNIDAD_AGENCIA_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            Else
                ObjGUIA_TRANSPORTISTA.IDUNIDAD_AGENCIA_DESTINO = 0
            End If
            If Not IsNothing(cmbAgencia_destino.SelectedValue) Then
                ObjGUIA_TRANSPORTISTA.IDAGENCIAS_DESTINO = Me.cmbAgencia_destino.SelectedValue
            Else
                ObjGUIA_TRANSPORTISTA.IDAGENCIAS_DESTINO = 0
            End If



            If Not Len(Me.TBnro_unidad_transporte.Text.Trim) = 0 Then
                Dim a As New ClsLbTepsa.dtoValida
                If a.NUMERO_NO_CERO(Me.TBnro_unidad_transporte, Me) = False Then
                    a = Nothing
                    Exit Sub
                End If
                If a.NUMERO_NO_NEGATIVO(Me.TBnro_unidad_transporte, Me) = False Then
                    Exit Sub
                    a = Nothing
                End If
                If a.NUMERO_ENTERO(Me.TBnro_unidad_transporte, Me) = False Then
                    Exit Sub
                    a = Nothing
                End If
                a = Nothing
                ObjGUIA_TRANSPORTISTA.nro_unidad_transporte = CType(Me.TBnro_unidad_transporte.Text.Trim, Long)
            Else
                ObjGUIA_TRANSPORTISTA.nro_unidad_transporte = 0
            End If


            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjGUIA_TRANSPORTISTA.FECHA_INICIAL = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjGUIA_TRANSPORTISTA.FECHA_INICIAL = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjGUIA_TRANSPORTISTA.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjGUIA_TRANSPORTISTA.FECHA_FINAL = "NULL"

            ObjGUIA_TRANSPORTISTA.TIPO_GUIA = 0
            'Mod.12/10/2009 -->Omendoza - Pasando al datahelper -  
            'dvguias_transportista = ObjGUIA_TRANSPORTISTA.sp_list_guia_transporIV(VOCONTROLUSUARIO)
            dvguias_transportista = ObjGUIA_TRANSPORTISTA.sp_list_guia_transporIV()
            '
            FORMAT_GRILLA3()
            dgv4.DataSource = Nothing
            L2.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub


    Private Sub DGV3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellEnter
        Dim obj As New ClsLbTepsa.dtoGUIA_TRANSPORTISTA
        With obj
            .IDGUIA_TRANSPORTISTA = dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("IDGUIA_TRANSPORTISTA")
            .factura_guia_transportista = 2 'Es un valor para todos los casos (lo mismo para la consulta por guía) 
            'Mod.12/10/2009 -->Omendoza - Pasando al datahelper -  
            'dvguias_transportista_bultos = .sp_list_guia_transpor_deta(VOCONTROLUSUARIO)
            dvguias_transportista_bultos = .sp_list_guia_transpor_deta()
            '
            Call FORMAT_GRILLA4()

        End With
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
            .DataSource = dvguias_transportista_bultos
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "ESTADO_REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
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
        Dim SERIE As New DataGridViewTextBoxColumn
        With SERIE
            .HeaderText = "SERIE"
            .Name = "SERIE_GUIA_ENVIO"
            .DataPropertyName = "SERIE_GUIA_ENVIO"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim NUMERO As New DataGridViewTextBoxColumn
        With NUMERO
            .HeaderText = "NUMERO"
            .Name = "NRO_GUIA"
            .DataPropertyName = "NRO_GUIA"
            .Width = 130
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim CANTIDAD_RECEPCIONAR As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
        With CANTIDAD_RECEPCIONAR
            .HeaderText = "CANTIDAD_RECEPCIONAR"
            .Name = "CANTIDAD_RECEPCIONAR"
            .DataPropertyName = "CANTIDAD_RECEPCIONAR"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            '.DefaultCellStyle.Format = "N0"
            '.DefaultCellStyle.NullValue = "0"
            .ReadOnly = False
            '.Mask = Microsoft.VisualBasic.Right("000000000000000000", 6)
            .Mask = "######"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        With TIPO_COMPROBANTE
            .HeaderText = "TIPO_COMPROBANTE"
            .Name = "TIPO_COMPROBANTE"
            .DataPropertyName = "TIPO_COMPROBANTE"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        With dgv4
            .Columns.AddRange(TIPO_COMPROBANTE, SERIE, NUMERO, FECHA, CANTIDAD, CANTIDAD_RECEPCIONAR)

        End With
        L2.Text = dvguias_transportista_bultos.Count
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


        Dim Es_Recepcionado_decrip As New DataGridViewTextBoxColumn
        With Es_Recepcionado_decrip
            .HeaderText = "Es_Recepcionado_decrip"
            .Name = "Es_Recepcionado_decrip"
            .DataPropertyName = "Es_Recepcionado_decrip"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "ESTADO_REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim TIPO_SERVICIO As New DataGridViewTextBoxColumn
        With TIPO_SERVICIO
            .HeaderText = "TIPO_SERVICIO"
            .Name = "TIPO_SERVICIO"
            .DataPropertyName = "TIPO_SERVICIO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim PILOTO As New DataGridViewTextBoxColumn
        With PILOTO
            .HeaderText = "PILOTO"
            .Name = "PILOTO"
            .DataPropertyName = "PILOTO"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "AGENCIA ORI"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim NOMBRE_AGENCIA_DESTINO As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA_DESTINO
            .HeaderText = "AGENCIA DESTI"
            .Name = "NOMBRE_AGENCIA_DESTINO"
            .DataPropertyName = "NOMBRE_AGENCIA_DESTINO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable

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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With





        With DGV3
            .Columns.AddRange(NOMBRE_UNIDAD_ORI, NOMBRE_AGENCIA, NOMBRE_UNIDAD_DESTI, NOMBRE_AGENCIA_DESTINO, LOGIN, NRO_UNIDAD_TRANSPORTE, PILOTO, TIPO_SERVICIO, FECHA_SALIDA, SERIE_GUIA_TRANSPORTISTA, NRO_GUIA_TRANSPORTISTA, Es_Recepcionado_decrip)
        End With
        L1.Text = dvguias_transportista.Count
    End Sub

    Private Sub FrmRegCargoBultos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmRegCargoBultos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Recepcion de Bultos"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            Me.MenuStrip1.Items(6).Visible = False
            '        
            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0
            '
            'Mod.12/10/2009 -->Omendoza - Pasando al datahelper -  
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            '
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            '
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA)
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA_DESTINO)

            Me.CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
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


                    With ObjFactura

                        .IDFACTURA = Me.dvguias_transportista.Table.Rows(Me.DGV3.CurrentRow.Index)("IDFACTURA")


                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)

                        Dim PREFACTURA As String
                        If Not Me.dvguias_transportista.Table.Rows(Me.DGV3.CurrentRow.Index).IsNull("NRO_PREFACTURA") Then

                            If Not Trim(Me.dvguias_transportista.Table.Rows(Me.DGV3.CurrentRow.Index)("NRO_PREFACTURA")) = "" Then
                                PREFACTURA = "Prefactura Nro.:" & Me.dvguias_transportista.Table.Rows(Me.DGV3.CurrentRow.Index)("NRO_PREFACTURA")
                            Else
                                PREFACTURA = ""
                            End If
                        Else
                            PREFACTURA = ""
                        End If

                        'If Me.rbdeta.Checked = True Then
                        '    ObjReport.printrptB(False, "", "FAC004.RPT", _
                        '    "P_MONTO_IMPUESTO;" & FormatNumber(Me.dvguias_transportista.Table.Rows(Me.DGV3.CurrentRow.Index)("MONTO_IMPUESTO"), 2, , , TriState.True), _
                        '    "P_TOTAL_COSTO;" & FormatNumber(Me.dvguias_transportista.Table.Rows(Me.DGV3.CurrentRow.Index)("TOTAL_COSTO"), 2, , , TriState.True), _
                        '    "P_IDFACTURA;" & .IDFACTURA, _
                        '    "P_NRO_PREFACTURA;" & PREFACTURA)
                        'ElseIf Me.rbgene.Checked = True Then
                        '    ObjReport.printrptB(False, "", "FAC003.RPT", _
                        '    "p_idpersona;" & .IDPERSONA, _
                        '    "p_idforma_pago;" & .IDFORMA_PAGO, _
                        '    "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                        '    "p_idagencias;" & .IDAGENCIAS, _
                        '    "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                        '    "p_fecha_inicial;" & .FECHA_INICIO, _
                        '    "p_fecha_final;" & .FECHA_FINAL)
                        'ElseIf Me.rbcobra.Checked = True Then
                        '    ObjReport.printrptB(False, "", "FAC005.RPT", _
                        '    "P_MONTO_IMPUESTO;" & FormatNumber(Me.dvguias_transportista.Table.Rows(Me.DGV3.CurrentRow.Index)("MONTO_IMPUESTO"), 2, , , TriState.True), _
                        '    "P_TOTAL_COSTO;" & FormatNumber(Me.dvguias_transportista.Table.Rows(Me.DGV3.CurrentRow.Index)("TOTAL_COSTO"), 2, , , TriState.True), _
                        '   "P_IDFACTURA;" & .IDFACTURA, _
                        '    "P_NRO_PREFACTURA;" & PREFACTURA)
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

    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
        L1.Text = ""
        L2.Text = ""
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAINICIOFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPFECHAFINALFACTURA.Focus()
        End If
    End Sub


    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.GotFocus
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
        L1.Text = ""
        L2.Text = ""
    End Sub






    Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub






    Private Sub CBIDUNIDAD_AGENCIA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.GotFocus
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
        L1.Text = ""
        L2.Text = ""
    End Sub


    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.GotFocus
        dgv4.DataSource = Nothing
        DGV3.DataSource = Nothing
        L1.Text = ""
        L2.Text = ""
    End Sub

    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            CBIDUNIDAD_AGENCIA.Focus()
        End If
    End Sub



    Private Sub CBIDUNIDAD_AGENCIA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDUNIDAD_AGENCIA.KeyPress
        If e.KeyChar = Chr(13) Then
            CBIDUNIDAD_AGENCIA_DESTINO.Focus()
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged

    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.KeyPress
        If e.KeyChar = Chr(13) Then
            Button3.Focus()
        End If
    End Sub


    Private Sub RecepcionarTodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecepcionarTodoToolStripMenuItem.Click
        Dim objGUIA_TRANSPORTISTA_DETALL As New ClsLbTepsa.dtoGUIA_TRANSPORTISTA_DETALL

        If dvguias_transportista.Table.Rows.Count <= 0 Then
            MsgBox("No existe ninguna guia de transportista", MsgBoxStyle.Information, "Seguridad el sistema")
            Exit Sub
        End If
        If Not dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("es_recepcionado") = 0 Then
            MsgBox("no se puede realizar la recepción total, existe recepción parcial o total", MsgBoxStyle.Information, "Seguridad el sistema")
            Exit Sub
        End If

        objGUIA_TRANSPORTISTA_DETALL.IDGUIA_TRANSPORTISTA = dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("IDGUIA_TRANSPORTISTA")
        objGUIA_TRANSPORTISTA_DETALL.IDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad
        objGUIA_TRANSPORTISTA_DETALL.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
        'Mod.12/10/2009 -->Omendoza - Pasando al datahelper -  
        'objGUIA_TRANSPORTISTA_DETALL.sp_recepcionar_todosIII(VOCONTROLUSUARIO)
        objGUIA_TRANSPORTISTA_DETALL.sp_recepcionar_todosIII()

        dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("es_recepcionado") = 1

        Dim obj As New ClsLbTepsa.dtoGUIA_TRANSPORTISTA

        With obj
            .factura_guia_transportista = 2
            .IDGUIA_TRANSPORTISTA = dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("IDGUIA_TRANSPORTISTA")
            'Mod.12/10/2009 -->Omendoza - Pasando al datahelper -  
            ' dvguias_transportista_bultos = .sp_list_guia_transpor_deta(VOCONTROLUSUARIO)
            dvguias_transportista_bultos = .sp_list_guia_transpor_deta()
            '
            Call FORMAT_GRILLA4()
            dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("es_recepcionado") = 1
            dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("Es_Recepcionado_decrip") = "RECEP"

        End With
    End Sub

    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellContentClick

    End Sub


    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub
    Private Sub dgv4_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv4.CellValidated
        Try

            If Not dgv4.CurrentCell.ColumnIndex = 5 Then

                Exit Sub
            End If

            If cantidad_recepcionar = 0 And dvguias_transportista_bultos.Table.Rows(dr).IsNull("CANTIDAD_RECEPCIONAR") Then
                Exit Sub
            End If
            If Not dvguias_transportista_bultos.Table.Rows(dr).IsNull("CANTIDAD_RECEPCIONAR") Then
                If cantidad_recepcionar = Val(dvguias_transportista_bultos.Table.Rows(dr)("CANTIDAD_RECEPCIONAR")) Then Exit Sub
            End If





            Dim objGUIA_TRANSPORTISTA_DETALL As New ClsLbTepsa.dtoGUIA_TRANSPORTISTA_DETALL
            Dim dv As New DataView
            objGUIA_TRANSPORTISTA_DETALL.IDGUIA_TRANSPORTISTA_DETALL = dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index)("IDGUIA_TRANSPORTISTA_DETALL")

            If Not dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index).IsNull("CANTIDAD_RECEPCIONAR") Then
                objGUIA_TRANSPORTISTA_DETALL.CANTIDAD_RECEPCIONAR = Val(dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index)("CANTIDAD_RECEPCIONAR"))
                dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index)("CANTIDAD_RECEPCIONAR") = Val(dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index)("CANTIDAD_RECEPCIONAR"))
                If dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index)("CANTIDAD_RECEPCIONAR") > dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index)("CANTIDAD") Then
                    MsgBox("La cantidad a recepcionar no puede ser mayor que la de envio", MsgBoxStyle.Information, "Segurdidad del Sistema")
                    dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index)("CANTIDAD_RECEPCIONAR") = cantidad_recepcionar
                    Exit Sub
                End If
                If dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index)("CANTIDAD_RECEPCIONAR") < 0 Then
                    MsgBox("La cantidad a recepcionar no puede ser negativo", MsgBoxStyle.Information, "Segurdidad del Sistema")
                    dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index)("CANTIDAD_RECEPCIONAR") = cantidad_recepcionar
                    Exit Sub
                End If
            Else
                objGUIA_TRANSPORTISTA_DETALL.CANTIDAD_RECEPCIONAR = 0
            End If
            objGUIA_TRANSPORTISTA_DETALL.IDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad
            objGUIA_TRANSPORTISTA_DETALL.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin

            dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index)("CANTIDAD_RECEPCIONAR") = Val(dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index)("CANTIDAD_RECEPCIONAR"))
            '
            'Mod.12/10/2009 -->Omendoza - Pasando al datahelper -  
            'dv = objGUIA_TRANSPORTISTA_DETALL.sp_RECEPCIONAR_BULTOSIII(VOCONTROLUSUARIO)
            dv = objGUIA_TRANSPORTISTA_DETALL.sp_RECEPCIONAR_BULTOSIII()

            If dv.Table.Rows(0)("retor_es_recepcionado") = 0 Then
                dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("es_recepcionado") = 0
                dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("Es_Recepcionado_decrip") = "DESP."

                Try
                    ObjWebService.fnWebServiceLlegada(objGUIA_TRANSPORTISTA_DETALL.IDGUIA_TRANSPORTISTA_DETALL.ToString())
                Catch ex As Exception
                End Try

            ElseIf dv.Table.Rows(0)("retor_es_recepcionado") = 1 Then
                dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("es_recepcionado") = 1
                dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("Es_Recepcionado_decrip") = "RECEP."

                Try
                    ObjWebService.fnWebServiceLlegada(objGUIA_TRANSPORTISTA_DETALL.IDGUIA_TRANSPORTISTA_DETALL.ToString())
                Catch ex As Exception
                End Try


            ElseIf dv.Table.Rows(0)("retor_es_recepcionado") = 2 Then
                dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("es_recepcionado") = 2
                dvguias_transportista.Table.Rows(DGV3.CurrentRow.Index)("Es_Recepcionado_decrip") = "RECEP. PARCIAL"


                Try
                    ObjWebService.fnWebServiceLlegada(objGUIA_TRANSPORTISTA_DETALL.IDGUIA_TRANSPORTISTA_DETALL.ToString())
                Catch ex As Exception
                End Try


            Else

                MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema...")


                dvguias_transportista_bultos.Table.Rows(dr)("CANTIDAD_RECEPCIONAR") = cantidad_recepcionar

            End If


        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema...")
        End Try
    End Sub


    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndexChanged

    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectionChangeCommitted
        Dim p_idunidad_agencia As Int64

        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
            p_idunidad_agencia = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Int64)
            'datahelper
            objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(Me.cmbAgencia_destino, p_idunidad_agencia)
        Else
            Me.cmbAgencia_destino.DataSource = Nothing

        End If
        Me.cmbAgencia_destino.SelectedIndex = -1
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectionChangeCommitted
        Dim p_idunidad_agencia As Int64

        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
            p_idunidad_agencia = CType(Me.CBIDUNIDAD_AGENCIA.SelectedValue, Int64)
            'Datahelper
            objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(Me.cmbAgencia, p_idunidad_agencia)
        Else
            Me.cmbAgencia.DataSource = Nothing

        End If
        Me.cmbAgencia.SelectedIndex = -1
    End Sub



    Private Sub dgv4_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv4.CellEnter
        If dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index).IsNull("CANTIDAD_RECEPCIONAR") Then
            cantidad_recepcionar = 0
        ElseIf Not IsNumeric(dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index)("CANTIDAD_RECEPCIONAR")) Then
            cantidad_recepcionar = 0
        Else
            cantidad_recepcionar = Val(dvguias_transportista_bultos.Table.Rows(dgv4.CurrentRow.Index)("CANTIDAD_RECEPCIONAR"))
        End If
        dr = dgv4.CurrentRow.Index
    End Sub

    Private Sub dgv4_RowErrorTextChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv4.RowErrorTextChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    'Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
    '    If bIngreso Then
    '        Acceso.VerificaCambio(sender, e)
    '    End If
    'End Sub

    Private Sub RecepcionarTodoToolStripMenuItem_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles RecepcionarTodoToolStripMenuItem.DragEnter

    End Sub

    Private Sub dgv4_CellContentClick_1(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv4.CellContentClick

    End Sub
End Class
