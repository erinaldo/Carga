Public Class frmConsultaDocumento
    Public hnd As Long

    Dim objConsultaGeneral1 As dtoConsultaGeneral
    Dim iComprobante As Integer = 0
    Dim iComprobante2 As Integer = 0
    Dim iTipo As Integer
    Dim iTipoComprobante As Integer
    Dim bRegistros As Boolean = False
    Dim bInicio As Boolean

    Dim bNada As Boolean

    Dim colCliente As New Collection
    Dim autoCliente As New AutoCompleteStringCollection

    'hlamas 11-01-2015
    Dim imagen() As Byte

#Region "Configurar Grid"
    Sub ConfigurarDGVArticulo()
        With dgvVenta
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 7, FontStyle.Regular)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")


            Dim x As Integer = 0
            Dim col_Nombre_Articulo As New DataGridViewTextBoxColumn
            With col_Nombre_Articulo
                .Name = "Nombre_Articulo" : .DataPropertyName = "Nombre_Articulo"
                .DisplayIndex = x : .HeaderText = "Artículo" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_Precio_x_Articulo As New DataGridViewTextBoxColumn
            With col_Precio_x_Articulo
                .Name = "Precio_x_Articulo" : .DataPropertyName = "Precio_x_Articulo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.Format = "####,###,###0.00"
            End With
            x += +1
            Dim col_Cantidad_Articulos As New DataGridViewTextBoxColumn
            With col_Cantidad_Articulos
                .Name = "Cantidad_Articulos" : .DataPropertyName = "Cantidad_Articulos"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.Format = "####,###,###0.00"
            End With
            x += +1
            Dim col_Total As New DataGridViewTextBoxColumn
            With col_Total
                .Name = "Total" : .DataPropertyName = "Total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.Format = "####,###,###0.00"
            End With
            .Columns.AddRange(col_Nombre_Articulo, col_Precio_x_Articulo, col_Cantidad_Articulos, col_peso, col_Total)
        End With
    End Sub
    Public Sub ConfigurarDGVVenta()
        With dgvVenta
            .Columns.Clear()
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .BackgroundColor = SystemColors.Window
            .Font = New System.Drawing.Font("Tahoma", 7.0!, FontStyle.Bold)
            .ReadOnly = False
            .AutoGenerateColumns = False
            .ScrollBars = ScrollBars.Both
            '.DataSource = dtable_Lista_Control_Comprobante
            .VirtualMode = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 7, FontStyle.Regular)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

            Dim c1 As New DataGridViewTextBoxColumn
            With c1
                .DisplayIndex = 0
                .HeaderText = "TIPO"
                .DefaultCellStyle.ForeColor = Color.Black
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            .Columns.Add(c1)

            Dim c2 As New DataGridViewTextBoxColumn
            With c2
                .DisplayIndex = 1
                .HeaderText = "BULTO"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Width = 80
            End With
            .Columns.Add(c2)

            Dim c3 As New DataGridViewTextBoxColumn
            With c3
                .DisplayIndex = 2
                .HeaderText = "PESO/VOL"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Width = 90
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            .Columns.Add(c3)

            Dim c4 As New DataGridViewTextBoxColumn
            With c4
                .DisplayIndex = 3
                .HeaderText = "COSTO"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Width = 90
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With
            .Columns.Add(c4)

            Dim c5 As New DataGridViewTextBoxColumn
            With c5
                .DisplayIndex = 4
                .HeaderText = "SUBNETO"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 90
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With
            .Columns.Add(c5)

            Dim row0 As String() = {"PESO", "0", "0.00", "0.00", "0.00"}
            .Rows().Add(row0)
            Dim row1 As String() = {"VOLUMEN", "0", "0.00", "0.00", "0.00"}
            .Rows().Add(row1)
            Dim row2 As String() = {"SOBRE", "0", "0.00", "0.00", "0.00"}
            .Rows().Add(row2)
            Dim row3 As String() = {"BASE", "0", "0.00", "0.00", "0.00"}
            .Rows().Add(row3)
            Dim row4 As String() = {"CA", "0", "0.00", "0.00", "0.00"}
            .Rows().Add(row4)
            Dim row5 As String() = {"ENTREGA DOM.", "0", "0.00", "0.00", "0.00"}
            .Rows().Add(row5)
            Dim row6 As String() = {"FUERA ZONA", "0", "0.00", "0.00", "0.00"}
            .Rows().Add(row6)
            Dim row7 As String() = {"DEV CARGO", "0", "0.00", "0.00", "0.00"}
            .Rows().Add(row7)
        End With
    End Sub
    Sub ConfiguraGrid()
        If bNada = False Then
            ConfigurarDGVVenta()
            ConfiguraDGVDocumentos()
            With dgvCheckpoint
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToOrderColumns = True
                '.BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                .AutoGenerateColumns = False
                '    '.DataSource = dtable_Lista_Control_Comprobante
                .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With


            Dim IDVAR As New DataGridViewTextBoxColumn
            With IDVAR
                .DisplayIndex = 0
                .DataPropertyName = "ID_VAR"
                .HeaderText = "PK"

                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dgvCheckpoint.Columns.Add(IDVAR)

            Dim FECHA As New DataGridViewTextBoxColumn
            With FECHA
                .DisplayIndex = 1
                .DataPropertyName = "Fecha"
                .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgvCheckpoint.Columns.Add(FECHA)


            Dim HORA As New DataGridViewTextBoxColumn
            With HORA
                .DisplayIndex = 2
                .DataPropertyName = "HORA"
                .HeaderText = "Hora"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgvCheckpoint.Columns.Add(HORA)

            Dim CIUDAD As New DataGridViewTextBoxColumn
            With CIUDAD
                .DisplayIndex = 3
                .DataPropertyName = "Nombre_Unidad"
                .HeaderText = "Ciudad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgvCheckpoint.Columns.Add(CIUDAD)

            Dim USUARIO As New DataGridViewTextBoxColumn
            With USUARIO
                .DisplayIndex = 4
                .DataPropertyName = "usuario"
                .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgvCheckpoint.Columns.Add(USUARIO)


            Dim OBS As New DataGridViewTextBoxColumn
            With OBS
                .DisplayIndex = 5
                .DataPropertyName = "OBS"
                .HeaderText = "Descripción"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgvCheckpoint.Columns.Add(OBS)
        End If
    End Sub
    Sub FormatearDGVLista()
        With dgvLista
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.7!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_numero_comprobante As New DataGridViewTextBoxColumn
            With col_numero_comprobante
                .Name = "numero_comprobante" : .DataPropertyName = "numero_comprobante"
                .DisplayIndex = x : .HeaderText = "Nº Doc." : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_comprobante As New DataGridViewTextBoxColumn
            With col_tipo_comprobante
                .Name = "tipo_comprobante" : .DataPropertyName = "tipo_comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_comprobante As New DataGridViewTextBoxColumn
            With col_fecha_comprobante
                .Name = "fecha_comprobante" : .DataPropertyName = "fecha_comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero_documento As New DataGridViewTextBoxColumn
            With col_numero_documento
                .Name = "numero_documento" : .DataPropertyName = "numero_documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ruc/Dni"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_razon_social As New DataGridViewTextBoxColumn
            With col_razon_social
                .Name = "razon_social" : .DataPropertyName = "razon_social"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Razón Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 235 '280 '325
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "subcuenta" : .DataPropertyName = "subcuenta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subcuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_facturacion As New DataGridViewTextBoxColumn
            With col_tipo_facturacion
                .Name = "tipo_facturacion" : .DataPropertyName = "tipo_facturacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Facturacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_forma_pago As New DataGridViewTextBoxColumn
            With col_forma_pago
                .Name = "forma_pago" : .DataPropertyName = "forma_pago"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Forma Pago"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_estado_documento As New DataGridViewTextBoxColumn
            With col_estado_documento
                .Name = "estado_documento" : .DataPropertyName = "estado_documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_estado_envio As New DataGridViewTextBoxColumn
            With col_estado_envio
                .Name = "estado_envio" : .DataPropertyName = "estado_envio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado Envío"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cantidad_peso As New DataGridViewTextBoxColumn
            With col_cantidad_peso
                .Name = "cantidad_peso" : .DataPropertyName = "cantidad_peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad_volumen As New DataGridViewTextBoxColumn
            With col_cantidad_volumen
                .Name = "cantidad_volumen" : .DataPropertyName = "cantidad_volumen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad_articulos As New DataGridViewTextBoxColumn
            With col_cantidad_articulos
                .Name = "cantidad_articulos" : .DataPropertyName = "cantidad_articulos"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad Artículo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad_sobres As New DataGridViewTextBoxColumn
            With col_cantidad_sobres
                .Name = "cantidad_sobres" : .DataPropertyName = "cantidad_sobres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_precio_sobre As New DataGridViewTextBoxColumn
            With col_precio_sobre
                .Name = "precio_sobre" : .DataPropertyName = "precio_sobre"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total_peso As New DataGridViewTextBoxColumn
            With col_total_peso
                .Name = "total_peso" : .DataPropertyName = "total_peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_precio_peso As New DataGridViewTextBoxColumn
            With col_precio_peso
                .Name = "precio_peso" : .DataPropertyName = "precio_peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total_volumen As New DataGridViewTextBoxColumn
            With col_total_volumen
                .Name = "total_volumen" : .DataPropertyName = "total_volumen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_precio_volumen As New DataGridViewTextBoxColumn
            With col_precio_volumen
                .Name = "precio_volumen" : .DataPropertyName = "precio_volumen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_monto_base As New DataGridViewTextBoxColumn
            With col_monto_base
                .Name = "monto_base" : .DataPropertyName = "monto_base"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Base"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_porcentaje_descuento As New DataGridViewTextBoxColumn
            With col_porcentaje_descuento
                .Name = "porcentaje_descuento" : .DataPropertyName = "porcentaje_descuento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "% Descuento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_monto_descuento As New DataGridViewTextBoxColumn
            With col_monto_descuento
                .Name = "monto_descuento" : .DataPropertyName = "monto_descuento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Descuento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_memo As New DataGridViewTextBoxColumn
            With col_memo
                .Name = "memo" : .DataPropertyName = "memo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dscto Autorizado por"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_liquidado As New DataGridViewTextBoxColumn
            With col_liquidado
                .Name = "liquidado" : .DataPropertyName = "liquidado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Liquidado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_prefacturado As New DataGridViewTextBoxColumn
            With col_prefacturado
                .Name = "prefacturado" : .DataPropertyName = "prefacturado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Prefacturado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_facturado As New DataGridViewTextBoxColumn
            With col_facturado
                .Name = "facturado" : .DataPropertyName = "facturado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Facturado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_subtotal_ca As New DataGridViewTextBoxColumn
            With col_subtotal_ca
                .Name = "subtotal_ca" : .DataPropertyName = "subtotal_ca"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subtotal CA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_impuesto_ca As New DataGridViewTextBoxColumn
            With col_impuesto_ca
                .Name = "impuesto_ca" : .DataPropertyName = "impuesto_ca"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Impuesto CA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total_ca As New DataGridViewTextBoxColumn
            With col_total_ca
                .Name = "total_ca" : .DataPropertyName = "total_ca"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total CA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_subtotal As New DataGridViewTextBoxColumn
            With col_subtotal
                .Name = "subtotal" : .DataPropertyName = "subtotal"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subtotal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_impuesto As New DataGridViewTextBoxColumn
            With col_impuesto
                .Name = "impuesto" : .DataPropertyName = "impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_Usuario_ingreso As New DataGridViewTextBoxColumn
            With col_Usuario_ingreso
                .Name = "Usuario_ingreso" : .DataPropertyName = "Usuario_ingreso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario_ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_entrega As New DataGridViewTextBoxColumn
            With col_tipo_entrega
                .Name = "tipo_entrega" : .DataPropertyName = "tipo_entrega"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_entrega As New DataGridViewTextBoxColumn
            With col_fecha_entrega
                .Name = "fecha_entrega" : .DataPropertyName = "fecha_entrega"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_usuario_entrega As New DataGridViewTextBoxColumn
            With col_usuario_entrega
                .Name = "usuario_entrega" : .DataPropertyName = "usuario_entrega"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Producto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_consignado As New DataGridViewTextBoxColumn
            With col_consignado
                .Name = "consignado" : .DataPropertyName = "consignado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Consignado Envío"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_nombre_entrega As New DataGridViewTextBoxColumn
            With col_nombre_entrega
                .Name = "nombre_entrega" : .DataPropertyName = "nombre_entrega"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Consignado Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_factura As New DataGridViewTextBoxColumn
            With col_factura
                .Name = "factura" : .DataPropertyName = "factura"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Factura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_idcomprobante As New DataGridViewTextBoxColumn
            With col_idcomprobante
                .Name = "idcomprobante" : .DataPropertyName = "idcomprobante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcomprobante"
            End With
            x += +1
            Dim col_remitente As New DataGridViewTextBoxColumn
            With col_remitente
                .Name = "remitente" : .DataPropertyName = "remitente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Remitente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_numero_comprobante, col_tipo_comprobante, col_fecha_comprobante, col_origen, col_destino, col_numero_documento, col_razon_social, col_subcuenta, _
                              col_tipo_facturacion, col_forma_pago, col_estado_documento, col_estado_envio, col_cantidad_peso, col_cantidad_volumen, _
                              col_cantidad_articulos, col_cantidad_sobres, col_precio_sobre, col_total_peso, col_precio_peso, col_total_volumen, col_precio_volumen, _
                              col_monto_base, col_porcentaje_descuento, col_monto_descuento, col_memo, col_cargo, col_liquidado, col_prefacturado, col_facturado, _
                              col_subtotal_ca, col_impuesto_ca, col_total_ca, col_subtotal, col_impuesto, col_total, col_Usuario_ingreso,
                              col_tipo_entrega, col_fecha_entrega, col_usuario_entrega, col_producto, col_consignado, col_nombre_entrega, col_factura, col_idcomprobante, col_remitente)
        End With
    End Sub
    Private Sub ConfiguraDGVDocumentos()
        With dgvDocumentos
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            '.BackgroundColor = SystemColors.Window
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .ReadOnly = False
            .AutoGenerateColumns = False
            '.ScrollBars = ScrollBars.None
            '.DataSource = dtable_Lista_Control_Comprobante
            .VirtualMode = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

            Dim d1 As New DataGridViewTextBoxColumn
            With d1
                .DisplayIndex = 0
                .HeaderText = "Doc. Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(d1)

            Dim d2 As New DataGridViewTextBoxColumn
            With d2
                .DisplayIndex = 1
                .HeaderText = "Doc. Seguro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                '.Width = 100
            End With
            .Columns.Add(d2)
        End With
    End Sub
#End Region

    Sub Inicio()
        Dim obj As New dtoConsulta
        Dim ds As DataSet = obj.Iniciar
        Me.cboEstadoEnvio.SelectedIndex = 0
        With cboOrigen
            .ValueMember = "id"
            .DisplayMember = "nombre"
            .DataSource = ds.Tables(0)
            .SelectedValue = 0
        End With
        With cboDestino
            .ValueMember = "id"
            .DisplayMember = "nombre"
            .DataSource = ds.Tables(0).Copy
            .SelectedValue = 0
        End With
        With cboAgenciaOrigen
            .ValueMember = "id"
            .DisplayMember = "nombre"
            .DataSource = ds.Tables(1)
            .SelectedValue = 0
        End With
        With cboAgenciaDestino
            .ValueMember = "id"
            .DisplayMember = "nombre"
            .DataSource = ds.Tables(1).Copy
            .SelectedValue = 0
        End With
        With cboTipoFacturacion
            .ValueMember = "id"
            .DisplayMember = "nombre"
            .DataSource = ds.Tables(2)
            .SelectedValue = 0
        End With
        With cboTipoEntrega
            .ValueMember = "id"
            .DisplayMember = "nombre"
            .DataSource = ds.Tables(3)
            .SelectedValue = 0
        End With
        With cboTipoComprobante
            .ValueMember = "id"
            .DisplayMember = "nombre"
            .DataSource = ds.Tables(4)
            .SelectedValue = 0
        End With
        With cboTipoCliente
            .ValueMember = "id"
            .DisplayMember = "nombre"
            .DataSource = ds.Tables(5)
            .SelectedValue = 0
        End With
        With cboTarjeta
            .ValueMember = "id"
            .DisplayMember = "nombre"
            .DataSource = ds.Tables(6)
            .SelectedValue = 0
        End With
        With cboProducto
            .ValueMember = "id"
            .DisplayMember = "nombre"
            .DataSource = ds.Tables(7)
            .SelectedValue = 0
        End With
        With cboFuncionario
            .ValueMember = "id"
            .DisplayMember = "nombre"
            .DataSource = ds.Tables(8)
            .SelectedValue = 0
        End With

        'Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        'ObjProcesos.fnCargar_iWin_r(Me.txtCliente, ds.Tables(9).DefaultView, colCliente, autoCliente, 0)

        Me.tabConsulta.SelectedIndex = 1
    End Sub

    Function ObtieneEstado(estado As Integer) As Integer
        Dim intEstado As Integer
        Select Case estado
            Case 0 : intEstado = 0
            Case 1 : intEstado = 18
            Case 2 : intEstado = 19
            Case 3 : intEstado = 41
            Case 4 : intEstado = 20
            Case 5 : intEstado = 40
            Case 6 : intEstado = 47
            Case 7 : intEstado = 21
        End Select
        Return intEstado
    End Function

    Private Sub frmConsultaDocumento_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Cursor = Cursors.Default
    End Sub

    Private Sub frmConsultaDocumento_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Cursor = Cursors.WaitCursor
        Me.FormatearDGVLista()
        ConfiguraGrid()
        Inicio()
        If dtoUSUARIOS.huella = 1 Then
            Me.btnHuella.Visible = True
        Else
            Me.btnHuella.Visible = False
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New dtoConsulta
            obj.Inicio = Me.dtpFechaInicio.Value.ToShortDateString
            obj.Fin = Me.dtpFechaFin.Value.ToShortDateString
            obj.Estado = ObtieneEstado(Me.cboEstadoEnvio.SelectedIndex)
            obj.TipoFacturacion = Me.cboTipoFacturacion.SelectedValue
            obj.TipoEntrega = Me.cboTipoEntrega.SelectedValue
            obj.Origen = Me.cboOrigen.SelectedValue
            obj.Destino = Me.cboDestino.SelectedValue
            obj.AgenciaOrigen = Me.cboAgenciaOrigen.SelectedValue
            obj.AgenciaDestino = Me.cboAgenciaDestino.SelectedValue
            obj.TipoComprobante = Me.cboTipoComprobante.SelectedValue
            obj.TipoPersona = Me.cboTipoCliente.SelectedValue
            obj.TipoTarjeta = Me.cboTarjeta.SelectedValue
            obj.Tarjeta = Me.txtTarjeta.Text.Trim
            obj.Subcuenta = Me.cboSubcuenta.SelectedValue
            obj.Funcionario = Me.cboFuncionario.SelectedValue
            obj.Producto = IIf(Me.cboProducto.SelectedIndex = 0, -1, Me.cboProducto.SelectedValue)


            'Dim intCliente As Integer
            'If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            'intCliente = 0
            'Else
            'intCliente = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
            'End If
            'obj.Cliente = intCliente

            If Me.txtConsignado.Text.Trim.Length > 0 Then
                obj.Consignado = Me.txtConsignado.Text.Trim
            Else
                obj.Consignado = ""
            End If

            If Me.txtCliente.Text.Trim.Length > 0 Then
                obj.RazonSocial = Me.txtCliente.Text.Trim
            Else
                obj.RazonSocial = ""
            End If

            If Me.txtCodigoCliente.Text.Trim.Length > 0 Then
                obj.NumeroDocumento = Me.txtCodigoCliente.Text.Trim
            Else
                obj.NumeroDocumento = ""
            End If

            If Me.TxtBoletoViaje.Text.Trim.Length > 0 Then
                obj.Boleto = Me.TxtBoletoViaje.Text.Trim
            Else
                obj.Boleto = "x"
            End If

            Dim dt As DataTable = obj.Listar(obj)
            Me.dgvLista.DataSource = dt
            Me.lblRegistros.Text = Me.dgvLista.Rows.Count

            'dblPeso = IIf(IsDBNull(dt.Compute("sum(" & strPeso & ")", "nivel=1")), 0, dt.Compute("sum(" & strPeso & ")", "nivel=1"))
            Me.lblPeso.Text = Format(IIf(IsDBNull(dt.Compute("Sum(total_peso)", "")), 0, dt.Compute("Sum(total_peso)", "")), "###,###,###0.00")
            Me.lblVolumen.Text = Format(IIf(IsDBNull(dt.Compute("Sum(total_volumen)", "")), 0, dt.Compute("Sum(total_volumen)", "")), "###,###,###0.00")

            Me.lblSubtotal.Text = Format(IIf(IsDBNull(dt.Compute("Sum(subtotal)", "")), 0, dt.Compute("Sum(subtotal)", "")), "###,###,###0.00")
            Me.lblImpuesto.Text = Format(IIf(IsDBNull(dt.Compute("Sum(impuesto)", "")), 0, dt.Compute("Sum(impuesto)", "")), "###,###,###0.00")
            Me.lblTotal.Text = Format(IIf(IsDBNull(dt.Compute("Sum(total)", "")), 0, dt.Compute("Sum(total)", "")), "###,###,###0.00")

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Consulta de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtCliente.Text.Trim.Length > 0 Then
                Me.btnConsultar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub txtCliente_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyUp
        'If e.KeyCode = Keys.Enter Then
        '    If Not autoCliente.IndexOf(txtCliente.Text) = -1 Then
        '        Dim ObjPersona As New ClsLbTepsa.dtoPersona
        '        With ObjPersona
        '            .IDPERSONA = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
        '            .IDTIPO_PERSONA = 0
        '            .CODIGO_CLIENTE = "NULL"
        '            'Datahelper
        '            ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
        '            Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
        '        End With
        '    Else
        '        Me.txtCodigoCliente.Text = ""
        '    End If
        'End If
    End Sub

    Private Sub txtCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtCliente.LostFocus
        'If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
        '    Me.txtCliente.Text = ""
        '    Me.txtCodigoCliente.Text = ""
        'End If
    End Sub

    Private Sub txtCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCliente.TextChanged

    End Sub

    Private Sub txtCodigoCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtCodigoCliente.Text.Trim.Length > 0 Then
                Me.btnConsultar_Click(Nothing, Nothing)
            End If
        End If

        'Try
        '    If Asc(e.KeyChar) = Keys.Enter Then
        '        If Me.txtCodigoCliente.Text.Trim.Length > 0 Then
        '            Dim obj As New dtoCarga
        '            Dim strCodigoCliente As String = Me.txtCodigoCliente.Text.Trim
        '            Dim dt As DataTable = obj.ObtieneCliente(strCodigoCliente)
        '            If dt.Rows.Count > 0 Then
        '                Me.txtCliente.Text = dt.Rows(0).Item("cliente")
        '            Else
        '                MessageBox.Show("El Cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    Private Sub txtCodigoCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtCodigoCliente.LostFocus
        'If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
        '    Me.txtCliente.Text = ""
        '    Me.txtCodigoCliente.Text = ""
        'End If
    End Sub

    Private Sub Limpiar()
        Me.lblFuncionario.Text = ""
        Me.txtFechaDocumento.Text = ""
        Me.txtTipoDocumento.Text = ""
        Me.txtFormaPago.Text = ""
        Me.txtRuc1.Text = ""
        Me.txtRucCliente1.Text = ""
        Me.txtRemitente1.Text = ""
        Me.txtDireccion1.Text = ""
        Me.txtContacto1.Text = ""
        Me.txtDescuento.Text = ""
        Me.txtMemo.Text = ""
        Me.txtOrigen.Text = ""
        Me.txtDestino.Text = ""
        txtTipoEntrega.Text = ""
        Me.txtAgenciaOrigen.Text = ""
        Me.txtAgenciaDestino.Text = ""
        Me.txtTipoTarjeta.Text = ""
        Me.txtNumeroTarjeta1.Text = ""
        Me.txtSubcuenta.Text = ""
        Me.txtSubcuentaOrigen.Text = ""
        'Me.tabDocumento.Text = ""
        Me.txtSubtotal.Text = ""
        Me.txtImpuesto.Text = ""
        Me.txtTotal.Text = ""
        Me.labrl51.Text = ""
        Me.label72.Text = ""
        Me.txtConsignado1.Text = ""
        Me.lblRecepcion.Text = ""
        '
        '09/08/2010 - 
        '
        Me.txt_nro_boleto.Text = ""
        'Me.txt_nro_boleto.Visible = False
        'Me.Lab_boleto.Visible = False
        Me.Lab_tipo_carga.Text = ""
        '
        btnCargaAsegurada.Enabled = False

        Me.dgvVenta.DataSource = Nothing
        If Me.dgvVenta.Rows.Count < 3 Then
            Me.dgvVenta.DataSource = Nothing
        Else
            dgvVenta(1, 0).Value = 0
            dgvVenta(1, 1).Value = 0
            dgvVenta(1, 2).Value = 0

            dgvVenta(2, 0).Value = "0.00"
            dgvVenta(2, 1).Value = "0.00"

            dgvVenta(3, 0).Value = "0.00"
            dgvVenta(3, 1).Value = "0.00"
            dgvVenta(3, 2).Value = "0.00"
            dgvVenta(3, 3).Value = "0.00"

            dgvVenta(4, 0).Value = "0.00"
            dgvVenta(4, 1).Value = "0.00"
            dgvVenta(4, 2).Value = "0.00"
            dgvVenta(4, 3).Value = "0.00"
            dgvVenta(4, 4).Value = "0.00"
            dgvVenta(4, 5).Value = "0.00"
            dgvVenta(4, 6).Value = "0.00"
        End If

        If dgvDocumentos.Rows.Count > 0 Then
            dgvDocumentos.Rows.Clear()
        End If

        If dgvCheckpoint.Rows.Count > 0 Then
            dgvCheckpoint.DataSource = Nothing
        End If

        btnAnterior.Enabled = False
        btnSiguiente.Enabled = False

        lblRegistro.Text = "(0/0)"
        lblEstado.Text = ""

        TxtPaginaWebCliente.Text = ""
        txtRepresentante.Text = ""
        TxtTelefonoCliente.Text = ""
        txtGerenteGeneral.Text = ""
        TxtCelularMsg.Text = ""
        TxtCorreoMsg.Text = ""
        txtPrefactura.Text = ""
        txtFechaEmision.Text = ""
        txtEstado.Text = ""
        txtFechaEstado.Text = ""
        TxtNroLiqDevCarg.Text = ""
        Me.txtCargo.Text = ""
        TxtFecEmiLiqDev.Text = ""
        dgvFactura.Rows.Clear()
        dgvDetalle.Rows.Clear()

        Me.txtDireccion2.Text = ""
        Me.txtReferencia.Text = ""

        Me.btnCargaAsegurada.Enabled = False
        Me.btnUbicacion.Enabled = False
        Me.btnBultosnoLeidos.Enabled = False
        Me.btnHuella.Enabled = False
        Me.btnPago.Enabled = False

        txtDocumento.Focus()



    End Sub
    Private Sub Ejecutar2()
        Try
            Dim sDocumento As String

            sDocumento = txtDocumento.Text.Trim
            If sDocumento = "" Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            objConsultaGeneral1 = New dtoConsultaGeneral
            With objConsultaGeneral1
                .Documento = sDocumento

                If .ObtenerDocumento() Then
                    If objConsultaGeneral1.curId.Rows.Count >= 1 Then
                        For index As Integer = 0 To objConsultaGeneral1.curId.Rows.Count - 1
                            If .EjecutarConsultaDocumento(Convert.ToInt32(objConsultaGeneral1.curId.Rows(index).Item("IdFactura").ToString), Convert.ToInt32(objConsultaGeneral1.curId.Rows(index).Item("IdPersona").ToString), Convert.ToInt32(objConsultaGeneral1.curId.Rows(index).Item("IdPrefactura").ToString), Convert.ToInt32(objConsultaGeneral1.curId.Rows(index).Item("Facturado").ToString), Convert.ToInt32(objConsultaGeneral1.curId.Rows(index).Item("IdTipo_Comprobante").ToString)) Then   'exito
                                If objConsultaGeneral1.curId.Rows.Count = 1 Then
                                    bRegistros = False
                                ElseIf objConsultaGeneral1.curId.Rows.Count >= 2 Then
                                    bRegistros = True
                                End If
                                'huella
                                If dtoUSUARIOS.huella = 1 Then
                                    Try 'si pc cliente no tiene instalado drivers biometrico prosigue el flujo
                                        CargarHuella(Convert.ToInt32(objConsultaGeneral1.curId.Rows(index).Item("IdTipo_Comprobante").ToString), Convert.ToInt32(objConsultaGeneral1.curId.Rows(index).Item("IdFactura").ToString))
                                    Catch ex As Exception
                                        Dim a As String = ex.Message
                                    End Try
                                End If
                            Else
                                bRegistros = False
                            End If
                        Next

                        If objConsultaGeneral1.curVenta.Rows.Count > 0 Then
                            Mostrar(0)
                            If bRegistros Then
                                lblRegistro.Text = "(1/2)"
                                btnAnterior.Enabled = False
                                btnSiguiente.Enabled = True
                            Else
                                lblRegistro.Text = "(0/0)"
                                btnAnterior.Enabled = False
                                btnSiguiente.Enabled = False
                            End If
                        Else
                            btnAnterior.Enabled = False
                            btnSiguiente.Enabled = False
                            Me.Cursor = Cursors.Default
                            MessageBox.Show("No se Encontraron Registros.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Limpiar()
                        End If
                    Else
                        btnAnterior.Enabled = False
                        btnSiguiente.Enabled = False
                        Me.Cursor = Cursors.Default
                        MessageBox.Show("No se Encontraron Registros.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End With
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Mostrar(ByVal n As Integer)
        Dim iPersona As Integer
        With objConsultaGeneral1.curVenta
            bInicio = True
            txtDocumento.Text = CType(.Rows(n).Item("nro"), String)
            bInicio = False
            lblEstado.Text = CType(.Rows(n).Item("estado"), String)
            'hlamas 18-09-2013
            If objConsultaGeneral1.curVenta.Rows(n).Item("dt").ToString.Trim.Length > 0 Then
                lblEstado.Text = lblEstado.Text & " DT " & CType(.Rows(n).Item("dt"), String)
            End If

            iComprobante = CType(.Rows(n).Item("idfactura"), Integer)
            iTipoComprobante = CType(.Rows(n).Item("idtipo_comprobante"), Integer)
            iTipo = CType(.Rows(n).Item("tipo"), Integer)

            txtFechaDocumento.Text = CType(.Rows(n).Item("fecha_factura"), Date)
            txtTipoDocumento.Text = .Rows(n).Item("tipo_documento")
            txtFormaPago.Text = .Rows(n).Item("forma_pago")
            txtRuc1.Text = IIf(IsDBNull(.Rows(n).Item("numero_documento")), "", .Rows(n).Item("numero_documento"))
            txtRucCliente1.Text = .Rows(n).Item("razon_social")
            txtRemitente1.Text = "" & .Rows(n).Item("remitente")
            txtDireccion1.Text = "" & .Rows(n).Item("direccion1")
            txtDireccion2.Text = "" & .Rows(n).Item("direccion2")
            txtReferencia.Text = .Rows(n).Item("referencia")
            txtContacto1.Text = IIf(IsDBNull(.Rows(n).Item("contacto")), "", .Rows(n).Item("contacto"))
            txtDescuento.Text = FormatNumber(.Rows(n).Item("descuento"), 2)
            txtMemo.Text = IIf(IsDBNull(.Rows(n).Item("memo")), "", .Rows(n).Item("memo"))
            txtOrigen.Text = .Rows(n).Item("origen")
            txtDestino.Text = .Rows(n).Item("destino")
            txtAgenciaOrigen.Text = .Rows(n).Item("agencia_origen")
            txtAgenciaDestino.Text = .Rows(n).Item("agencia_destino")
            txtTipoTarjeta.Text = IIf(IsDBNull(.Rows(n).Item("tipo_tarjeta")), "", .Rows(n).Item("tipo_tarjeta"))
            txtNumeroTarjeta1.Text = IIf(IsDBNull(.Rows(n).Item("numero_tarjeta")), "", .Rows(n).Item("numero_tarjeta"))
            txtConsignado1.Text = IIf(IsDBNull(.Rows(n).Item("consignado")), "", .Rows(n).Item("consignado"))
            txtSubtotal.Text = FormatNumber(.Rows(n).Item("subtotal"), 2)
            txtImpuesto.Text = FormatNumber(.Rows(n).Item("impuesto"), 2)
            txtTotal.Text = FormatNumber(.Rows(n).Item("total"), 2)
            lblFuncionario.Text = IIf(IsDBNull(.Rows(n).Item("funcionario")), "", .Rows(n).Item("funcionario"))
            txtSubcuenta.Text = .Rows(n).Item("subcuenta")
            txtSubcuentaOrigen.Text = IIf(IsDBNull(.Rows(n).Item("subcuenta_origen")), "", .Rows(n).Item("subcuenta_origen"))
            Me.txtTipoEntrega.Text = .Rows(n).Item("entrega")
            Me.lblRecepcion.Text = .Rows(n).Item("recepcion")
            '' 09/08/2010 
            If .Rows(n).Item("idprocesos") = 6 Or .Rows(n).Item("idprocesos") = 11 Then   'Carga  Acompañada 
                Me.txt_nro_boleto.Visible = True
                Me.txt_nro_boleto.Text = IIf(IsDBNull(.Rows(n).Item("nroboleto")), "", .Rows(n).Item("nroboleto"))
                Me.Lab_boleto.Visible = True
            Else
                'Me.Lab_boleto.Visible = False
                'Me.txt_nro_boleto.Visible = False
            End If
            Me.Lab_boleto.Refresh()
            Me.Lab_tipo_carga.Text = IIf(IsDBNull(.Rows(n).Item("tipo_carga")), "", .Rows(n).Item("tipo_carga"))

            Dim inta As Integer = .Rows(n).Item("Cantidad_x_Articulo")
            If .Rows(n).Item("Cantidad_x_Articulo") > 0 Then 'articulo
                ConfigurarDGVArticulo()
                dgvVenta.DataSource = objConsultaGeneral1.curArticulo
            ElseIf .Rows(n).Item("Cantidad_x_Articulo") > 0 Then 'tepsa box

            Else
                ConfigurarDGVVenta()
                dgvVenta(1, 0).Value = .Rows(n).Item("cantidad_x_peso")
                dgvVenta(1, 1).Value = .Rows(n).Item("cantidad_x_volumen")
                dgvVenta(1, 2).Value = .Rows(n).Item("cantidad_x_sobre")

                dgvVenta(2, 0).Value = .Rows(n).Item("total_peso")
                dgvVenta(2, 1).Value = .Rows(n).Item("total_volumen")

                dgvVenta(3, 0).Value = FormatNumber(IIf(IsDBNull(.Rows(n).Item("precio_x_peso")), 0, .Rows(n).Item("precio_x_peso")), 2)
                dgvVenta(3, 1).Value = FormatNumber(IIf(IsDBNull(.Rows(n).Item("precio_x_volumen")), 0, .Rows(n).Item("precio_x_volumen")), 2)
                dgvVenta(3, 2).Value = FormatNumber(IIf(IsDBNull(.Rows(n).Item("precio_x_sobre")), 0, .Rows(n).Item("precio_x_sobre")), 2)
                dgvVenta(3, 3).Value = FormatNumber(IIf(IsDBNull(.Rows(n).Item("monto_base")), 0, .Rows(n).Item("monto_base")), 2)

                dgvVenta(4, 0).Value = FormatNumber(IIf(IsDBNull(.Rows(n).Item("total_peso")), 0, .Rows(n).Item("total_peso")) * IIf(IsDBNull(.Rows(n).Item("precio_x_peso")), 0, .Rows(n).Item("precio_x_peso")), 2)
                dgvVenta(4, 1).Value = FormatNumber(IIf(IsDBNull(.Rows(n).Item("total_volumen")), 0, .Rows(n).Item("total_volumen")) * IIf(IsDBNull(.Rows(n).Item("precio_x_volumen")), 0, .Rows(n).Item("precio_x_volumen")), 2)
                dgvVenta(4, 2).Value = FormatNumber(IIf(IsDBNull(.Rows(n).Item("cantidad_x_sobre")), 0, .Rows(n).Item("cantidad_x_sobre")) * IIf(IsDBNull(.Rows(n).Item("precio_x_sobre")), 0, .Rows(n).Item("precio_x_sobre")), 2)
                dgvVenta(4, 3).Value = FormatNumber(IIf(IsDBNull(.Rows(n).Item("monto_base")), 0, .Rows(n).Item("monto_base")), 2)
                dgvVenta(4, 4).Value = FormatNumber(IIf(IsDBNull(.Rows(n).Item("sub_total_ca")), 0, .Rows(n).Item("sub_total_ca")), 2)

                dgvVenta(4, 5).Value = FormatNumber(.Rows(n).Item("monto_entrega_domicilio"), 2)

                'hlamas 02-10-2014
                'si existe cobro por fuera de zona se adiciona al detalle de la venta
                If .Rows(n).Item("monto_fuera_zona") > 0 Then
                    dgvVenta(4, 6).Value = FormatNumber(.Rows(n).Item("monto_fuera_zona"), 2)
                End If

                'hlamas 19-02-2015
                'si existe cobro por devolucion de cargo
                If .Rows(n).Item("monto_devolucion_cargo") > 0 Then
                    dgvVenta(4, 7).Value = FormatNumber(.Rows(n).Item("monto_devolucion_cargo"), 2)
                End If

            End If

            iPersona = .Rows(n).Item("idpersona")
            If Val(IIf(IsDBNull(.Rows(n).Item("sub_total_ca")), 0, .Rows(n).Item("sub_total_ca"))) > 0 Then
                btnCargaAsegurada.Enabled = True
            Else
                btnCargaAsegurada.Enabled = False
            End If

            If iTipoComprobante = 1 Or iTipoComprobante = 2 Or iTipoComprobante = 30 Then
                Me.btnPago.Enabled = True
            Else
                Me.btnPago.Enabled = False
            End If

            'Actualiza Separador Detalle
            LblNombreCliente.Text = .Rows(n).Item("razon_social")
            TxtNroLiqDevCarg.Text = IIf(Val(.Rows(n).Item("cargo")) = 0, "", .Rows(n).Item("cargo"))
            TxtFecEmiLiqDev.Text = IIf(IsDBNull(.Rows(n).Item("cargofecha")), " ", .Rows(n).Item("cargofecha"))
            Me.txtCargo.Text = IIf(Val(.Rows(n).Item("cargos")) = 0, "NO", "SI")
        End With

        Dim dt As DataTable = objConsultaGeneral1.curDocumento
        'dt = FiltrarDataTable(objConsultaGeneral1.curDocumento, "idtipo_comprobante=" & iTipoComprobante & "", "")
        dt = FiltrarDataTable(objConsultaGeneral1.curDocumento, "idguias_envio=" & iComprobante & "", "")
        With dt 'objConsultaGeneral1.curDocumento
            dgvDocumentos.Rows.Clear()
            If .Rows.Count > 0 Then
                Dim iFila1 As Integer = 0
                Dim iFila2 As Integer = 0
                For Each obj As DataRow In .Rows
                    dgvDocumentos.Rows.Add()
                    If .Rows(0).Item("PORCEN") > 0 Then
                        dgvDocumentos(1, iFila1).Value = obj.Item(3) & "-" & obj.Item(4)
                        iFila1 += 1
                    Else
                        dgvDocumentos(0, iFila2).Value = obj.Item(3) & "-" & obj.Item(4)
                        iFila2 += 1
                    End If
                Next
            End If
        End With

        'Checkpoint
        MostrarCheckPoint()

        'Cliente
        With objConsultaGeneral1.curCliente
            If .Rows.Count > n Then
                txtGerenteGeneral.Text = Trim(.Rows(n).Item(0))
                txtRepresentante.Text = Trim(.Rows(n).Item(1))
                TxtPaginaWebCliente.Text = Trim(.Rows(n).Item(2))
                TxtTelefonoCliente.Text = Trim(.Rows(n).Item(3))
            End If
        End With

        'email
        Dim dtEmail As DataTable = objConsultaGeneral1.curEmail
        'dtEmail = objConsultaGeneral1.curEmail
        With dtEmail 'objConsultaGeneral1.curEmail
            dtEmail = FiltrarDataTable(objConsultaGeneral1.curEmail, "idpersona=" & iPersona & "", "")
            Dim s As String = ""
            If .Rows.Count > 0 Then
                For Each obj As DataRow In .Rows
                    s = s & obj.Item(0) & ","
                Next
                s = s.Substring(0, s.ToString.Trim.Length - 1)
            Else
                s = ""
            End If
            TxtCorreoMsg.Text = s
        End With

        'cel
        Dim dtCel As DataTable = objConsultaGeneral1.curCel
        dtCel = FiltrarDataTable(objConsultaGeneral1.curCel, "idpersona=" & iPersona & "", "")
        With dtCel 'objConsultaGeneral1.curCel
            Dim s As String = ""
            If .Rows.Count > 0 Then
                For Each obj As DataRow In .Rows
                    s = s & obj.Item(2) & " " & obj.Item(1) & ","
                Next
                s = s.Trim.Substring(0, s.ToString.Trim.Length - 1)
            End If
            TxtCelularMsg.Text = s
        End With

        'Prefactura
        With objConsultaGeneral1.curPrefactura
            If .Rows.Count > n Then
                txtPrefactura.Text = Trim(.Rows(n).Item(0))
                txtFechaEmision.Text = Trim(.Rows(n).Item(1))
                txtEstado.Text = Trim(.Rows(n).Item(2))
                txtFechaEstado.Text = Trim(.Rows(n).Item(3))
            Else
                txtPrefactura.Text = ""
                txtFechaEmision.Text = ""
                txtEstado.Text = ""
                txtFechaEstado.Text = ""
            End If
        End With

        'Factura
        dgvFactura.Rows.Clear()
        Dim dtFactura As DataTable = objConsultaGeneral1.curFactura
        With dtFactura 'objConsultaGeneral1.curFactura
            If .Rows.Count > 0 And IsDBNull(.Rows(0).Item(0)) = False Then
                dtFactura = FiltrarDataTable(objConsultaGeneral1.curFactura, "idpersona=" & iPersona & "", "")
                For Each obj As DataRow In .Rows
                    dgvFactura.Rows.Add()
                    dgvFactura.Rows(dgvFactura.Rows.Count - 1).Cells(1).Value = Trim(obj.Item(0))
                    dgvFactura.Rows(dgvFactura.Rows.Count - 1).Cells(2).Value = Trim(obj.Item(1))
                    dgvFactura.Rows(dgvFactura.Rows.Count - 1).Cells(3).Value = Trim(obj.Item(2))
                    dgvFactura.Rows(dgvFactura.Rows.Count - 1).Cells(0).Value = IIf(IsDBNull(obj.Item(3)), "", obj.Item(3))
                Next
            End If
        End With

        'Detalle de Bultos
        dgvDetalle.Rows.Clear()
        Dim dtBultos As DataTable = objConsultaGeneral1.curBultos
        dtBultos = FiltrarDataTable(objConsultaGeneral1.curBultos, "idtipo_comprobante=" & iTipoComprobante & " and idcomprobante=" & iComprobante & "", "")
        With dtBultos 'objConsultaGeneral1.curBultos
            If .Rows.Count > 0 Then
                For Each obj As DataRow In .Rows
                    dgvDetalle.Rows.Add()
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(0).Value = Trim(obj.Item(2))
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(1).Value = Trim(obj.Item(3))
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(2).Value = Trim(obj.Item(4))
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(3).Value = Trim(obj.Item(5))
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(4).Value = Trim(obj.Item(6))
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(5).Value = Trim(obj.Item(7))
                Next
            End If
        End With
    End Sub

    Private Sub MostrarCheckPoint()
        Try
            Dim ObjEntregaCarga As New dtoEntregaCarga
            'Dim daControl_FAC As New OleDb.OleDbDataAdapter
            'Dim dtControl_FAC As New System.Data.DataTable
            'Dim dvControl_FAC As System.Data.DataView

            ObjEntregaCarga.IDPK = iTipo
            ObjEntregaCarga.IDDOC = iComprobante

            dgvCheckpoint.DataSource = ObjEntregaCarga.fnSP_LIST_CHECK_POINT_2.DefaultView

            'datahelper
            'daControl_FAC.Fill(dtControl_FAC, ObjEntregaCarga.fnSP_LIST_CHECK_POINT_2())
            'dvControl_FAC = dtControl_FAC.DefaultView
            'dgvCheckpoint.DataSource = dvControl_FAC
            dgvCheckpoint.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Function FiltrarDataTable(ByVal dt As DataTable, ByVal filter As String, ByVal sort As String) As DataTable
        Try
            Dim rows As DataRow()
            Dim dtNew As DataTable

            dtNew = dt.Clone()
            rows = dt.Select(filter, sort)

            For Each dr As DataRow In rows
                dtNew.ImportRow(dr)
            Next
            Return dtNew

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub btnConsultar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar2.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Ejecutar2()

            If Me.dgvCheckpoint.Rows.Count > 0 Then
                Me.btnUbicacion.Enabled = True
                Me.btnBultosnoLeidos.Enabled = True
            Else
                Me.btnCargaAsegurada.Enabled = False
                Me.btnUbicacion.Enabled = False
                Me.btnBultosnoLeidos.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCargaAsegurada_Click(sender As System.Object, e As System.EventArgs) Handles btnCargaAsegurada.Click
        If asignar_seleccionados(objConsultaGeneral1.curDocumento) = True Then
            Dim A As New FrmDocCliente

            A.bVentaGrabada = True
            A.iFormulario = 1
            A.sFecha = txtFechaDocumento.Text
            'A.ShowDialog()
            Acceso.Asignar(A, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                A.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Function asignar_seleccionados(ByVal rst As DataTable) As Boolean
        asignar_seleccionados = False
        Dim indice As Integer = 0
        If rst.Rows.Count > 0 Then
            ReDim objComprobanteAsegurada(19)
            For Each obj As DataRow In rst.Rows
                If Not obj.Item("fecha") Is DBNull.Value Then
                    Try
                        objComprobanteAsegurada(indice).ID_GUIAS_ENVIO_DOC = obj.Item("ID_GUIAS_ENVIO_DOC")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDGUIAS_ENVIO = obj.Item("IDGUIAS_ENVIO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDTIPO_COMPROBANTE = obj.Item("IDTIPO_COMPROBANTE")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).NRO_SERIE = obj.Item("NRO_SERIE")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).NRO_DOCU = obj.Item("NRO_DOCU")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDUSUARIO_PERSONAL = obj.Item("IDUSUARIO_PERSONAL")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDUSUARIO_PERSONALMOD = obj.Item("IDUSUARIO_PERSONALMOD")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDROL_USUARIO = obj.Item("IDROL_USUARIO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDROL_USUARIOMOD = obj.Item("IDROL_USUARIOMOD")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IP = obj.Item("IP")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IPMOD = obj.Item("IPMOD")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).FECHA_REGISTRO = obj.Item("FECHA_REGISTRO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).FECHA_ACTUALIZACION = obj.Item("FECHA_ACTUALIZACION")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDESTADO_REGISTRO = obj.Item("IDESTADO_REGISTRO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).FECHA = obj.Item("FECHA")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO = obj.Item("MONTO_TIPO_CAMBIO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).MONTO_SUB_TOTAL = obj.Item("MONTO_SUB_TOTAL")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).MONTO_IMPUESTO = obj.Item("MONTO_IMPUESTO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).TOTAL_COSTO = obj.Item("TOTAL_COSTO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).OBS = obj.Item("OBS")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDTIPO_MONEDA = obj.Item("IDTIPO_MONEDA")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).PORCEN = obj.Item("PORCEN")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).TIPO = obj.Item("TIPO_MONTO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).PROCEDENCIA = obj.Item("IND_PROCEDENCIA")
                    Catch
                    End Try
                    asignar_seleccionados = True
                    indice = indice + 1
                End If
            Next
        End If
    End Function

    Private Sub btnBultosnoLeidos_Click(sender As System.Object, e As System.EventArgs) Handles btnBultosnoLeidos.Click
        'If txtTipoDocumento.Text.Trim.Length = 0 Then Exit Sub
        Dim frm As New frmBultosNoLeidos

        frm.sDocumento = iComprobante
        frm.iTipo = iTipoComprobante
        frm.sDoc = txtTipoDocumento.Text & " " & txtDocumento.Text

        'frm.ShowDialog()

        Acceso.Asignar(frm, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            frm.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnUbicacion_Click(sender As System.Object, e As System.EventArgs) Handles btnUbicacion.Click
        Dim frm As New FrmUbicacion
        frm.iComprobante = iComprobante
        frm.iTipoComprobante = iTipo
        'frm.ShowDialog()
        Acceso.Asignar(frm, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            frm.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub dgvLista_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvLista.DoubleClick
        With dgvLista
            If .Rows.Count > 0 Then
                Me.Cursor = Cursors.AppStarting

                Dim iDocumento As Integer = .CurrentRow.Cells("idcomprobante").Value
                Dim sDoc As String = .CurrentRow.Cells("numero_comprobante").Value

                tabConsulta.SelectedIndex = 1
                'MenuTab.Items(1).Select()

                dgvDocumentos.Columns.Clear()
                ConfiguraDGVDocumentos()

                dgvVenta.Columns.Clear()

                txtDocumento.Text = sDoc
                btnConsultar2_Click(Nothing, Nothing)
                Me.Cursor = Cursors.Default
            End If
        End With
    End Sub

    Private Sub btnSiguiente_Click(sender As System.Object, e As System.EventArgs) Handles btnSiguiente.Click, btnAnterior.Click
        Mostrar2(sender, e)
    End Sub

    Private Sub Mostrar2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CType(sender, Button).Tag = 1 Then
            If objConsultaGeneral1.curVenta.Rows.Count > 0 Then
                Mostrar(0)
                lblRegistro.Text = "(1/2)"
                btnAnterior.Enabled = False
                btnSiguiente.Enabled = True
            End If
        Else
            If objConsultaGeneral1.curVenta.Rows.Count > 0 Then
                Mostrar(1)
                lblRegistro.Text = "(2/2)"
                btnAnterior.Enabled = True
                btnSiguiente.Enabled = False
            End If
        End If
    End Sub

    Private Sub txtDocumento_Enter(sender As Object, e As System.EventArgs) Handles txtDocumento.Enter
        Me.txtDocumento.SelectAll()
    End Sub

    Private Sub tabConsulta_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabConsulta.SelectedIndexChanged
        If tabConsulta.SelectedIndex = 1 Then
            Me.txtDocumento.Focus()
        End If
    End Sub

    Private Sub txtDocumento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDocumento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnConsultar2_Click(Nothing, Nothing)
        ElseIf ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtDocumento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDocumento.TextChanged
        Limpiar()
    End Sub

    Private Sub txtFechaDocumento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaDocumento.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtOrigen_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrigen.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtOrigen_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOrigen.TextChanged

    End Sub

    Private Sub txtDestino_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDestino.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtDestino_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDestino.TextChanged

    End Sub

    Private Sub txtTipoDocumento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoDocumento.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtTipoDocumento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoDocumento.TextChanged

    End Sub

    Private Sub txtAgenciaOrigen_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAgenciaOrigen.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtAgenciaOrigen_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAgenciaOrigen.TextChanged

    End Sub

    Private Sub txtAgenciaDestino_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAgenciaDestino.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtAgenciaDestino_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAgenciaDestino.TextChanged

    End Sub

    Private Sub txtFormaPago_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFormaPago.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtFormaPago_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFormaPago.TextChanged

    End Sub

    Private Sub txtTipoTarjeta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoTarjeta.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtTipoTarjeta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoTarjeta.TextChanged

    End Sub

    Private Sub txtNumeroTarjeta1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroTarjeta1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtNumeroTarjeta1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroTarjeta1.TextChanged

    End Sub

    Private Sub txtTipoEntrega_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoEntrega.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtTipoEntrega_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoEntrega.TextChanged

    End Sub

    Private Sub txtRuc1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRuc1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtRuc1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRuc1.TextChanged

    End Sub

    Private Sub txtRucCliente1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRucCliente1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtRucCliente1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRucCliente1.TextChanged

    End Sub

    Private Sub txtSubcuentaOrigen_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubcuentaOrigen.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtSubcuentaOrigen_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubcuentaOrigen.TextChanged

    End Sub

    Private Sub txtSubcuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubcuenta.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtSubcuenta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubcuenta.TextChanged

    End Sub

    Private Sub txtRemitente1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemitente1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtRemitente1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRemitente1.TextChanged

    End Sub

    Private Sub txtConsignado1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtConsignado1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtConsignado1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtConsignado1.TextChanged

    End Sub

    Private Sub txtDireccion1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccion1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtDireccion1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDireccion1.TextChanged

    End Sub

    Private Sub txtDireccion2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccion2.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtDireccion2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDireccion2.TextChanged

    End Sub

    Private Sub txtContacto1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtContacto1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtContacto1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtContacto1.TextChanged

    End Sub

    Private Sub txtDescuento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuento.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtDescuento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescuento.TextChanged

    End Sub

    Private Sub txtMemo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMemo.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtMemo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMemo.TextChanged

    End Sub

    Private Sub txtSubtotal_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubtotal.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtSubtotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubtotal.TextChanged

    End Sub

    Private Sub txtImpuesto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtImpuesto.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtImpuesto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtImpuesto.TextChanged

    End Sub

    Private Sub txtTotal_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotal.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotal.TextChanged

    End Sub

    Private Sub txt_nro_boleto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_boleto.KeyPress
        e.Handled = True
    End Sub

    Private Sub txt_nro_boleto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_nro_boleto.TextChanged

    End Sub

    Private Sub TxtPaginaWebCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPaginaWebCliente.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtPaginaWebCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtPaginaWebCliente.TextChanged

    End Sub

    Private Sub txtRepresentante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRepresentante.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtRepresentante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRepresentante.TextChanged

    End Sub

    Private Sub TxtTelefonoCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelefonoCliente.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtTelefonoCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtTelefonoCliente.TextChanged

    End Sub

    Private Sub txtGerenteGeneral_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtGerenteGeneral.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtGerenteGeneral_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGerenteGeneral.TextChanged

    End Sub

    Private Sub TxtCelularMsg_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCelularMsg.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtCelularMsg_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCelularMsg.TextChanged

    End Sub

    Private Sub TxtCorreoMsg_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCorreoMsg.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtCorreoMsg_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCorreoMsg.TextChanged

    End Sub

    Private Sub txtPrefactura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrefactura.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtPrefactura_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPrefactura.TextChanged

    End Sub

    Private Sub txtFechaEmision_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaEmision.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtFechaEmision_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFechaEmision.TextChanged

    End Sub

    Private Sub txtEstado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEstado.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtEstado_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEstado.TextChanged

    End Sub

    Private Sub txtFechaEstado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaEstado.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtFechaEstado_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFechaEstado.TextChanged

    End Sub

    Private Sub TxtNroLiqDevCarg_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroLiqDevCarg.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtNroLiqDevCarg_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNroLiqDevCarg.TextChanged

    End Sub

    Private Sub TxtFecEmiLiqDev_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFecEmiLiqDev.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtFecEmiLiqDev_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtFecEmiLiqDev.TextChanged

    End Sub

    Private Sub frmConsultaDocumento_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.txtDocumento.Focus()
    End Sub

    Private Sub dgvLista_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellContentClick

    End Sub

    Private Sub txtCodigoCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCodigoCliente.TextChanged

    End Sub

    Private Sub txtConsignado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtConsignado.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtConsignado.Text.Trim.Length > 0 Then
                Me.btnConsultar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub txtConsignado_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtConsignado.TextChanged

    End Sub

    Private Sub btnHuella_Click(sender As System.Object, e As System.EventArgs) Handles btnHuella.Click
        Try
            Dim frm As New frmVerHuella
            frm.imagen = picHuella.Image
            frm.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Sub CargarHuella(TipoComprobante As Integer, comprobante As Integer)
        Try
            Dim huella As New Huella

            huella.CargarHuella(TipoComprobante, comprobante, imagen)
            If imagen Is Nothing Then
                Me.picHuella.Image = Nothing
                Me.btnHuella.Enabled = False
            Else
                huella.MostrarHuella(imagen, Me.picHuella, 2)
                Me.btnHuella.Enabled = True
            End If
            Me.picHuella.SizeMode = PictureBoxSizeMode.StretchImage
        Catch
            Me.picHuella.Image = Nothing
            Me.btnHuella.Enabled = False
        End Try
    End Sub

    Private Sub btnPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPago.Click
        'hlamas 16-05-2017
        Dim frm As New frmPagos
        frm.Comprobante = iComprobante
        frm.ShowDialog()
    End Sub

    Private Sub TxtBoletoViaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBoletoViaje.KeyPress
        If ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf Asc(e.KeyChar.ToString.ToUpper) >= 65 And Asc(e.KeyChar.ToString.ToUpper) <= 90 Then 'e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtReferencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReferencia.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtReferencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReferencia.TextChanged

    End Sub
End Class