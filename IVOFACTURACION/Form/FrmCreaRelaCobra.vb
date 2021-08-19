Public Class FrmCreaRelaCobra
    Dim OBJVenta_pasajes As New ClsLbTepsa.dtoVenta_Pasajes
    'Dim DT_DGV2 As New DataTable
    Dim bIngreso As Boolean = False  ' 14/08/2010 
    Public hnd As Long
    '
    Private ObjReport As ClsLbTepsa.dtoFrmReport '

    Private Sub tp2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tp2.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub


    Private Sub tp1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub Panel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub


    'Private Sub BtnAgre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try

    '        If Me.Txtrazon_social.Text = "" Then
    '            MsgBox("Ingrese un cliente", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
    '            Exit Sub
    '        End If

    '        With OBJVenta_pasajes

    '            '.SERIE_COMPROBANTE = Mid(Me.MBNRO_COMPROBANTE.Text, 1, 3)
    '            '.NRO_COMPROBANTE = Mid(Me.MBNRO_COMPROBANTE.Text, 5, 7)

    '            .IDPERSONA = (Me.Txtrazon_social.Tag)
    '            .FECHA_INI = Me.DTPFECHA_INI.Value.ToShortDateString
    '            .FECHA_FINAL = Me.DTPFECHA_FINAL.Value.ToShortDateString
    '            Dim DV As DataView = New DataView


    '            DV = .SP_SELEC_BOLE_COBRA_CLIE(cnn)

    '            For I As Integer = 0 To DV.Count - 1
    '                Dim myDataRow As DataRow
    '                myDataRow = DT_DGV2.NewRow()
    '                myDataRow("Idventa_Pasajes") = DV.Table.Rows(I)("Idventa_Pasajes")
    '                myDataRow("nro_comprobante") = DV.Table.Rows(I)("nro_comprobante")
    '                myDataRow("serie_comprobante") = DV.Table.Rows(I)("serie_comprobante")
    '                myDataRow("razon_social") = DV.Table.Rows(I)("razon_social")
    '                myDataRow("nu_docu_suna") = DV.Table.Rows(I)("nu_docu_suna")
    '                myDataRow("fecha_emision") = DV.Table.Rows(I)("fecha_emision")
    '                myDataRow("condicion") = DV.Table.Rows(I)("condicion")
    '                myDataRow("monto_total") = DV.Table.Rows(I)("monto_total")
    '                myDataRow("estado_registro") = DV.Table.Rows(I)("estado_registro")
    '                myDataRow("idtipo_comprobante") = DV.Table.Rows(I)("idtipo_comprobante")
    '                myDataRow("tipo_comprobante") = DV.Table.Rows(I)("tipo_comprobante")
    '                DT_DGV2.Rows.Add(myDataRow)
    '            Next
    '        End With
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema...")

    '    End Try
    'End Sub

    'Private Sub FrmCreaRelaCobra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    DT_DGV2 = New DataTable("T_VENTA_PASAJES")

    '    Dim myDataColumn As DataColumn

    '    myDataColumn = New DataColumn
    '    myDataColumn.DataType = System.Type.GetType("System.Int32")
    '    myDataColumn.ColumnName = "Idventa_Pasajes"
    '    myDataColumn.AutoIncrement = False
    '    myDataColumn.Caption = "Idventa_Pasajes"
    '    myDataColumn.ReadOnly = False
    '    myDataColumn.Unique = False
    '    DT_DGV2.Columns.Add(myDataColumn)

    '    myDataColumn = New DataColumn
    '    myDataColumn.DataType = System.Type.GetType("System.String")
    '    myDataColumn.ColumnName = "nro_comprobante"
    '    myDataColumn.AutoIncrement = False
    '    myDataColumn.Caption = "nro_comprobante"
    '    myDataColumn.ReadOnly = False
    '    myDataColumn.Unique = False
    '    DT_DGV2.Columns.Add(myDataColumn)

    '    myDataColumn = New DataColumn
    '    myDataColumn.DataType = System.Type.GetType("System.String")
    '    myDataColumn.ColumnName = "serie_comprobante"
    '    myDataColumn.AutoIncrement = False
    '    myDataColumn.Caption = "serie_comprobante"
    '    myDataColumn.ReadOnly = False
    '    myDataColumn.Unique = False
    '    myDataColumn.AllowDBNull = False
    '    DT_DGV2.Columns.Add(myDataColumn)

    '    myDataColumn = New DataColumn
    '    myDataColumn.DataType = System.Type.GetType("System.String")
    '    myDataColumn.ColumnName = "razon_social"
    '    myDataColumn.AutoIncrement = False
    '    myDataColumn.Caption = "razon_social"
    '    myDataColumn.ReadOnly = False
    '    myDataColumn.Unique = False
    '    myDataColumn.AllowDBNull = True
    '    DT_DGV2.Columns.Add(myDataColumn)

    '    myDataColumn = New DataColumn
    '    myDataColumn.DataType = System.Type.GetType("System.String")
    '    myDataColumn.ColumnName = "nu_docu_suna"
    '    myDataColumn.AutoIncrement = False
    '    myDataColumn.Caption = "nu_docu_suna"
    '    myDataColumn.ReadOnly = False
    '    myDataColumn.Unique = False
    '    myDataColumn.AllowDBNull = False
    '    DT_DGV2.Columns.Add(myDataColumn)

    '    myDataColumn = New DataColumn
    '    myDataColumn.DataType = System.Type.GetType("System.String")
    '    myDataColumn.ColumnName = "fecha_emision"
    '    myDataColumn.AutoIncrement = False
    '    myDataColumn.Caption = "fecha_emision"
    '    myDataColumn.ReadOnly = False
    '    myDataColumn.Unique = False
    '    myDataColumn.AllowDBNull = False
    '    DT_DGV2.Columns.Add(myDataColumn)

    '    myDataColumn = New DataColumn
    '    myDataColumn.DataType = System.Type.GetType("System.String")
    '    myDataColumn.ColumnName = "condicion"
    '    myDataColumn.AutoIncrement = False
    '    myDataColumn.Caption = "condicion"
    '    myDataColumn.ReadOnly = False
    '    myDataColumn.Unique = False
    '    myDataColumn.AllowDBNull = False
    '    DT_DGV2.Columns.Add(myDataColumn)

    '    myDataColumn = New DataColumn
    '    myDataColumn.DataType = System.Type.GetType("System.Double")
    '    myDataColumn.ColumnName = "monto_total"
    '    myDataColumn.AutoIncrement = False
    '    myDataColumn.Caption = "monto_total"
    '    myDataColumn.ReadOnly = False
    '    myDataColumn.Unique = False
    '    myDataColumn.AllowDBNull = False
    '    DT_DGV2.Columns.Add(myDataColumn)

    '    myDataColumn = New DataColumn
    '    myDataColumn.DataType = System.Type.GetType("System.String")
    '    myDataColumn.ColumnName = "estado_registro"
    '    myDataColumn.AutoIncrement = False
    '    myDataColumn.Caption = "estado_registro"
    '    myDataColumn.ReadOnly = False
    '    myDataColumn.Unique = False
    '    myDataColumn.AllowDBNull = True
    '    DT_DGV2.Columns.Add(myDataColumn)

    '    myDataColumn = New DataColumn
    '    myDataColumn.DataType = System.Type.GetType("System.Int32")
    '    myDataColumn.ColumnName = "idtipo_comprobante"
    '    myDataColumn.AutoIncrement = False
    '    myDataColumn.Caption = "idtipo_comprobante"
    '    myDataColumn.ReadOnly = False
    '    myDataColumn.Unique = False
    '    myDataColumn.AllowDBNull = True
    '    DT_DGV2.Columns.Add(myDataColumn)

    '    myDataColumn = New DataColumn
    '    myDataColumn.DataType = System.Type.GetType("System.String")
    '    myDataColumn.ColumnName = "tipo_comprobante"
    '    myDataColumn.AutoIncrement = False
    '    myDataColumn.Caption = "tipo_comprobante"
    '    myDataColumn.ReadOnly = False
    '    myDataColumn.Unique = False
    '    myDataColumn.AllowDBNull = True
    '    DT_DGV2.Columns.Add(myDataColumn)


    '    Dim PrimaryKeyColumns(0) As DataColumn
    '    PrimaryKeyColumns(0) = DT_DGV2.Columns("Idventa_Pasajes")
    '    DT_DGV2.PrimaryKey = PrimaryKeyColumns

    '    format2()

    'End Sub
    Private Sub format2()
        '17/06/2010
        DGV2.Columns.Clear()

        If (Me.Txtrazon_social.Text) = "" Then
            OBJVenta_pasajes.IDPERSONA = 0
        Else
            OBJVenta_pasajes.IDPERSONA = (Me.Txtrazon_social.Tag)
        End If


        OBJVenta_pasajes.FECHA_INI = Me.DTPFECHA_INI.Value.ToShortDateString
        OBJVenta_pasajes.FECHA_FINAL = Me.DTPFECHA_FINAL.Value.ToShortDateString
        OBJVenta_pasajes.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin

        Dim DV As DataView = New DataView
        'datahelper
        'DV = OBJVenta_pasajes.SP_REP_cobranza_pasajes(cnn)
        DV = OBJVenta_pasajes.SP_REP_cobranza_pasajes()

        With DGV2
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = DV
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With


        Dim Idventa_Pasajes As New DataGridViewTextBoxColumn
        With Idventa_Pasajes
            .HeaderText = "Idventa_Pasajes"
            .Name = "Idventa_Pasajes"
            .DataPropertyName = "Idventa_Pasajes"
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
            .ReadOnly = True
        End With
        Dim nro_comprobante As New DataGridViewTextBoxColumn
        With nro_comprobante
            .HeaderText = "Nro Compro."
            .Name = "nro_comprobante"
            .DataPropertyName = "nro_comprobante"
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim serie_comprobante As New DataGridViewTextBoxColumn
        With serie_comprobante
            .HeaderText = "serie"
            .Name = "serie_comprobante"
            .DataPropertyName = "serie_comprobante"
            .Width = 40
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
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
        '
        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        '
        Dim condicion As New DataGridViewTextBoxColumn
        With condicion
            .HeaderText = "Condición"
            .Name = "condicion"
            .DataPropertyName = "condicion"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        '
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
            .HeaderText = "Estado"
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
            .Width = 100
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
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
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
            .Visible = False   'Agregado por omendoza 11/02/2007
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
            .HeaderText = "Total"
            .Name = "monto_total"
            .DataPropertyName = "monto_total"
            .Width = 70
            '.SortMode = DataGridViewColumnSortMode.NotSortable
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
            .HeaderText = "Pasajero"
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
            .Width = 50
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
        Dim monto_total As New DataGridViewTextBoxColumn
        With monto_total
            .HeaderText = "Total Pago"
            .Name = "monto_total"
            .DataPropertyName = "monto_total"
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        'Creado por Omendoza 11-02-2007 
        Dim tipo_comprobante As New DataGridViewTextBoxColumn
        With tipo_comprobante
            .HeaderText = "Tipo Comprobante"
            .Name = "tipo_comprobante"
            .DataPropertyName = "tipo_comprobante"
            .Width = 150
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            .Visible = True
            .ReadOnly = True
        End With
        '
        Dim fecha_emision As New DataGridViewTextBoxColumn
        With fecha_emision
            .HeaderText = "Fecha Emision"
            .Name = "fecha_emision"
            .DataPropertyName = "fecha_emision"
            '.Width = 18
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            .Visible = True
            .ReadOnly = True
        End With
        '
        Dim l_idpersona As New DataGridViewTextBoxColumn
        With l_idpersona
            .HeaderText = "IDPERSONA"
            .Name = "IDPERSONA"
            .DataPropertyName = "IDPERSONA"
            .Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
            .ReadOnly = True
        End With
        '
        Dim nu_docu_suna As New DataGridViewTextBoxColumn
        With nu_docu_suna
            .HeaderText = "nu_docu_suna"
            .Name = "nu_docu_suna"
            .DataPropertyName = "nu_docu_suna"
            .Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
            .ReadOnly = True
        End With
        '27/04/2010 - Nuevo
        Dim razon_social_cobrar As New DataGridViewTextBoxColumn
        With razon_social_cobrar
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Cliente"
            .Name = "razon_social_cobrar"
            .DataPropertyName = "razon_social_cobrar"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim tipo_credito As New DataGridViewTextBoxColumn
        With tipo_credito
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Tipo Credito"
            .Name = "tipo_credito"
            .DataPropertyName = "tipo_credito"
            .Width = 60
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim ruta As New DataGridViewTextBoxColumn
        With ruta
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Ori-Des"
            .Name = "ruta"
            .DataPropertyName = "ruta"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        'Mod. 14-jul-2010 
        Dim Funcionario As New DataGridViewTextBoxColumn
        With Funcionario
            .SortMode = DataGridViewColumnSortMode.Automatic
            .HeaderText = "Funcionario"
            .Name = "Funcionario"
            .DataPropertyName = "Funcionario"
            .Width = 120
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        With DGV2
            '.Columns.AddRange(Idventa_Pasajes, tipo_comprobante, serie_comprobante, nro_comprobante, RAZON_SOCIAL, nu_docu_suna, fecha_emision, condicion, monto_total, ESTADO_REGISTRO, razon_social_cobrar, tipo_credito)
            .Columns.AddRange(Idventa_Pasajes, tipo_comprobante, nro_comprobante, RAZON_SOCIAL, nu_docu_suna, ruta, fecha_emision, condicion, monto_total, ESTADO_REGISTRO, razon_social_cobrar, tipo_credito, Funcionario)
        End With
        '
        total()
    End Sub

    Sub total()
        Dim fila As Long
        Dim total_pago As Double = 0.0

        Try
            For fila = 0 To DGV2.Rows.Count - 1
                total_pago = total_pago + CType(DGV2.Rows(fila).Cells("monto_total").Value, Double)
            Next
            lab_total_reg.Text = "Total Registro : " & CType(DGV2.Rows.Count, String)
            Me.txt_total_costo.Text = CType(FormatNumber(total_pago, 2), String)
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub BtnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    DT_DGV2.Rows.Remove(DT_DGV2.Rows(DGV2.CurrentRow.Index))
        'Catch
        'End Try
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Close()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Txtnu_docu_suna.Text = ""
        Me.Txtrazon_social.Text = ""
        Me.Txtrazon_social.Tag = ""
        DGV2.DataSource = Nothing
    End Sub
    Private Sub BtnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarCliente.Click
        Dim a As New FrmBuscaClien
        'a.ShowDialog(Me)
        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            a.ShowDialog(Me)
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BntGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        OBJVenta_pasajes.IDPERSONA = Me.Txtrazon_social.Tag
        'datahelper
        'OBJVenta_pasajes.SP_IUPD_cobranza_pasajes(cnn)
        OBJVenta_pasajes.SP_IUPD_cobranza_pasajes()

        For i As Integer = 0 To DGV2.Rows.Count - 1
            DGV2.Rows(i).Selected = True
            DGV2.CurrentCell = DGV2.Rows(i).Cells(1)

            OBJVenta_pasajes.IDVENTA_PASAJES = DGV2.CurrentRow.Cells("IDVENTA_PASAJES").Value
            'datahelper
            'OBJVenta_pasajes.SP_IUPD_cobranza_pasajes_deta(cnn)
            OBJVenta_pasajes.SP_IUPD_cobranza_pasajes_deta()
        Next

    End Sub

    Private Sub BtnBuscarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarLista.Click
        Try
            format2()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub BtnImpri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpri.Click
        Try
            ObjReport.Dispose()
        Catch
        End Try

        ObjReport = New ClsLbTepsa.dtoFrmReport

        If DGV2.Rows.Count <= 0 Then Exit Sub


        'OBJVenta_pasajes.IDcobran_pasa = DGV1.CurrentRow.Cells("IDCOBRAN_PASA").Value

        If (Me.Txtrazon_social.Text) = "" Then
            OBJVenta_pasajes.IDPERSONA = 0
        Else
            OBJVenta_pasajes.IDPERSONA = (Me.Txtrazon_social.Tag)
        End If


        OBJVenta_pasajes.FECHA_INI = Me.DTPFECHA_INI.Value.ToShortDateString
        OBJVenta_pasajes.FECHA_FINAL = Me.DTPFECHA_FINAL.Value.ToShortDateString


        ObjReport.rutaRpt = PathFrmReport
        ObjReport.conectar(rptservice, rptuser, rptpass)
        'ObjReport.printrpt(False, "", "CC008.RPT", _
        '"P_RANGO_FECHA;" & "DEL " & OBJVenta_pasajes.FECHA_INI + " AL " + OBJVenta_pasajes.FECHA_FINAL, _
        '"P_IDPERSONA;" & OBJVenta_pasajes.IDPERSONA, _
        '"P_FECHA_INI;" & OBJVenta_pasajes.FECHA_INI, _
        '"P_FECHA_FINAL;" & OBJVenta_pasajes.FECHA_FINAL)
        '
        ObjReport.conectar(rptservice, rptuser, rptpass)
        ObjReport.printrpt(False, "", "CC008_1.RPT", _
        "P_IDPERSONA;" & OBJVenta_pasajes.IDPERSONA, _
        "P_FECHA_INI;" & OBJVenta_pasajes.FECHA_INI, _
        "P_FECHA_FINAL;" & OBJVenta_pasajes.FECHA_FINAL, _
        "P_IDUSUARIO_PERSONAL;" & dtoUSUARIOS.IdLogin, _
        "P_RANGO_FECHA;" & "DEL " & OBJVenta_pasajes.FECHA_INI + " AL " + OBJVenta_pasajes.FECHA_FINAL + "" _
        )
        '

    End Sub
    Private Sub FrmCreaRelaCobra_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub
    Private Sub FrmCreaRelaCobra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmCreaRelaCobra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class