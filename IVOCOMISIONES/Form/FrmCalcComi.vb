Public Class FrmCalcComi
    Dim nodo As TreeNode
    Dim dataSetArbol As DataSet
    Dim dScomisiones_funci As New DataTable
    Dim DTcomisiones As New DataTable
    Dim dvcomisiones_funci_credi As New DataView
    Dim dvcomisiones_funci_conta As New DataView
    Dim dvcomisiones_funci_pasa As New DataView
    Dim dvcomisiones_funci_funci As New DataView
    Dim dv_Listar_funcionarios As New DataView
    Dim dv_Listar_agencias As DataView
    Dim dt_Listar_porcentaje As DataTable
    Dim ObjComisiones As ClsLbTepsa.dtoComisiones = New ClsLbTepsa.dtoComisiones
    Dim ObjAgencias As ClsLbTepsa.dtoAgencias = New ClsLbTepsa.dtoAgencias

    Dim dblMetaLima As Double = 0
    Dim dblMetaProvincia As Double = 0
    Dim dblMeta As Double = 0

    Dim dsVentaTotal As DataSet
    Dim dvVentaTotal As DataView

    Dim dsCobranzaTotal As DataSet
    Dim dvCobranzaTotal As DataView

    Dim dsComisionTotal As DataTable
    Dim dvComisionTotal As DataView

    Dim dsPorcentaje As DataSet
    Dim dvPorcentaje As DataView

    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlComision.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub FrmCalcComi_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmCalcComi_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmCalcComi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            llenar_agencias()
            'hlamas 06-01-2014
            'Llenar_Funcionarios()
            Dim cFecha As Date = FechaServidor()
            Dim intAnio As Integer = Year(cFecha)
            If cFecha.Date.Day > 26 Then
                'If cFecha.Date.AddMonths(-1).Date.Month > cFecha.Date.Month Then intAnio -= 1
                DTPFECHAINICIO_funci.Value = "26/" & cFecha.Date.AddMonths(-1).Date.Month & "/" & intAnio
                DTPFECHAFINAL_funci.Value = "25/" & cFecha.Date.Month & "/" & intAnio
            Else
                'If cFecha.Date.AddMonths(-2).Date.Month > cFecha.Date.Month Then intAnio -= 1
                DTPFECHAINICIO_funci.Value = "26/" & cFecha.Date.AddMonths(-2).Date.Month & "/" & intAnio

                intAnio = Year(cFecha)
                'If cFecha.Date.AddMonths(-1).Date.Month > cFecha.Date.Month Then intAnio -= 1
                DTPFECHAFINAL_funci.Value = "25/" & cFecha.Date.AddMonths(-1).Date.Month & "/" & intAnio
            End If

            Dt_Otros_Gastos = New DataTable

            Dim MyDataColum As DataColumn

            MyDataColum = New DataColumn
            MyDataColum.DataType = System.Type.GetType("System.String")
            MyDataColum.ColumnName = "fecha"
            MyDataColum.AutoIncrement = False
            MyDataColum.ReadOnly = False
            MyDataColum.Unique = False
            Dt_Otros_Gastos.Columns.Add(MyDataColum)


            MyDataColum = New DataColumn
            MyDataColum.DataType = System.Type.GetType("System.String")
            MyDataColum.ColumnName = "concep"
            MyDataColum.AutoIncrement = False
            MyDataColum.ReadOnly = False
            MyDataColum.Unique = False
            Dt_Otros_Gastos.Columns.Add(MyDataColum)

            MyDataColum = New DataColumn
            MyDataColum.DataType = System.Type.GetType("System.Double")
            MyDataColum.ColumnName = "Valor"
            MyDataColum.AutoIncrement = False
            MyDataColum.ReadOnly = False
            MyDataColum.Unique = False
            Dt_Otros_Gastos.Columns.Add(MyDataColum)

            'If fnValidar_Rol("27") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 1) Then
                Select Case tc1.SelectedIndex
                    Case 2, 3
                        Me.tc1.SelectedIndex = 0
                End Select
            End If
            'If fnValidar_Rol("30") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 2) Then
                Select Case tc1.SelectedIndex
                    Case 0, 1
                        Me.tc1.SelectedIndex = 2
                End Select
            End If

            FORMAT_GRILLA4()
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Llenar_Funcionarios()
        Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL

        Dim nuevaFila As DataRow
        Dim TablaArbol As DataTable
        Dim NombreNodoTipo As String = String.Empty
        Dim DescNodoTipo As String = String.Empty
        Dim CodigoNodoFunc As String = String.Empty
        Dim NombreNodoFunc As String = String.Empty
        'Dim NroFuncionario As Integer = 0
        Dim NroFilaRecorrida As Integer = 0
        Dim Correlativo As Integer = 0
        Dim blnExisteNodoPadre As Boolean = False
        Dim blnExisteNodoHijo As Boolean = False

        Dim NombreNodoFunc2 As String = String.Empty

        dataSetArbol = New DataSet("DataSetArbol")

        TablaArbol = dataSetArbol.Tables.Add("TablaArbol")
        'TablaArbol.Columns.Add("NombreNodo", GetType(String))
        TablaArbol.Columns.Add("TipoFun", GetType(String))
        TablaArbol.Columns.Add("DesFun", GetType(String))
        TablaArbol.Columns.Add("IdPersona", GetType(String))
        TablaArbol.Columns.Add("IdentificadorNodo", GetType(Integer))
        TablaArbol.Columns.Add("IdentificadorPadre", GetType(Integer))

        'hlamas 06-01-2014
        'dv_Listar_funcionarios = ObjGeneral.SP_LISTAR_FUNCIONARIO()
        tv2.Nodes.Clear()
        dv_Listar_funcionarios = ClsLbTepsa.dtoGENERAL.CarteraResponsable(Nothing, Me.DTPFECHAINICIO_funci.Value.Date.ToShortDateString, Me.DTPFECHAFINAL_funci.Value.Date.ToShortDateString, 4, "")

        'Recorrer para insertar los tipos de funcionario
        For i As Integer = 0 To dv_Listar_funcionarios.Table.Rows.Count - 1
            NombreNodoTipo = dv_Listar_funcionarios.Table().Rows(i)("TIPOFUN").ToString()
            DescNodoTipo = dv_Listar_funcionarios.Table().Rows(i)("DESFUNCI").ToString()

            If dataSetArbol.Tables("TablaArbol").Rows.Count = 0 Then
                nuevaFila = dataSetArbol.Tables("TablaArbol").NewRow()
                nuevaFila("TipoFun") = NombreNodoTipo
                nuevaFila("DesFun") = DescNodoTipo
                nuevaFila("IdPersona") = ""
                nuevaFila("IdentificadorNodo") = i + 1
                nuevaFila("IdentificadorPadre") = i
                dataSetArbol.Tables("TablaArbol").Rows.Add(nuevaFila)
                Correlativo = Correlativo + 1
                NroFilaRecorrida = 1
                i = i - 1
            Else
                'Recorrer para verificar si el tipo de funcionario ya existe en la tabla arbol
                For j As Integer = 0 To dataSetArbol.Tables("TablaArbol").Rows.Count - 1
                    If NombreNodoTipo = dataSetArbol.Tables("TablaArbol").Rows(j)("TipoFun").ToString Then
                        blnExisteNodoPadre = True
                        Exit For
                    Else
                        blnExisteNodoPadre = False
                    End If
                Next

                blnExisteNodoHijo = False
                If blnExisteNodoPadre = True Then
                    For p As Integer = 0 To dv_Listar_funcionarios.Table.Rows.Count - 1
                        If NombreNodoTipo = dv_Listar_funcionarios.Table().Rows(p)("TIPOFUN").ToString() Then
                            'Recorrer para insertar el funcionario
                            NombreNodoFunc = dv_Listar_funcionarios.Table().Rows(p)("USUARIO_PERSONAL").ToString()
                            For n As Integer = 0 To dataSetArbol.Tables("TablaArbol").Rows.Count - 1
                                If NombreNodoFunc = dataSetArbol.Tables("TablaArbol").Rows(n)("TipoFun").ToString Then
                                    blnExisteNodoHijo = True
                                    Exit For
                                Else
                                    blnExisteNodoHijo = False
                                End If
                            Next

                            If blnExisteNodoHijo = False Then
                                nuevaFila = dataSetArbol.Tables("TablaArbol").NewRow()
                                nuevaFila("TipoFun") = NombreNodoFunc
                                nuevaFila("DesFun") = ""
                                nuevaFila("IdPersona") = dv_Listar_funcionarios.Table().Rows(p)("IDUSUARIO_PERSONAL").ToString()
                                nuevaFila("IdentificadorNodo") = Correlativo + 1
                                nuevaFila("IdentificadorPadre") = NroFilaRecorrida
                                dataSetArbol.Tables("TablaArbol").Rows.Add(nuevaFila)
                                Correlativo = Correlativo + 1
                            End If
                        End If
                    Next
                ElseIf blnExisteNodoPadre = False Then
                    nuevaFila = dataSetArbol.Tables("TablaArbol").NewRow()
                    nuevaFila("TipoFun") = NombreNodoTipo
                    nuevaFila("DesFun") = DescNodoTipo
                    nuevaFila("IdPersona") = ""
                    nuevaFila("IdentificadorNodo") = Correlativo + 1
                    nuevaFila("IdentificadorPadre") = 0
                    dataSetArbol.Tables("TablaArbol").Rows.Add(nuevaFila)
                    Correlativo = Correlativo + 1
                    i = i - 1
                    NroFilaRecorrida = Correlativo
                End If
            End If
        Next

        Dim oHijo As DataTable
        Dim vHijo As DataView
        Dim Nivel As Integer = 0

        oHijo = dataSetArbol.Tables("TablaArbol")
        vHijo = oHijo.DefaultView

        nodo = tv2.Nodes.Add("TIPO DE FUNCIONARIO")

        For fila As Integer = 0 To dataSetArbol.Tables("TablaArbol").Rows.Count - 1
            If Convert.ToInt32(dataSetArbol.Tables("TablaArbol").Rows(fila)("IdentificadorPadre").ToString()) = 0 Then
                nodo = tv2.Nodes(0).Nodes.Add(Trim(dataSetArbol.Tables("TablaArbol").Rows(fila)("DesFun").ToString()))
                nodo.Tag = dataSetArbol.Tables("TablaArbol").Rows(fila)("TipoFun").ToString
                'tv2.Nodes(0).Nodes(i).Tag
                ' realizo un filtro dentro de la vista
                vHijo.RowFilter = "IdentificadorPadre = " & Convert.ToInt32(dataSetArbol.Tables("TablaArbol").Rows(fila)("IdentificadorNodo").ToString())

                Dim a As Integer
                For a = 0 To vHijo.Count - 1
                    ' agrego el nodo en el tercer nivel
                    nodo = tv2.Nodes(0).Nodes(Nivel).Nodes.Add(Trim(vHijo.Item(a).Row("TipoFun").ToString()))
                    Me.tv2.Nodes(0).Nodes(Nivel).Nodes(a).Tag = vHijo.Item(a).Row("IdPersona").ToString()
                    'nodo.Tag = vHijo.Item(a).Row("IdPersona").ToString()
                Next
                ' expando todos los nodos de árbol secundario
                nodo.ExpandAll()
                Nivel = Nivel + 1
            End If
        Next

        'dv_Listar_funcionarios = New DataView
        ''Mod.21/09/2009 -->Omendoza - Pasando al datahelper
        'dv_Listar_funcionarios = ObjGeneral.sp_L_funcionario_carga

        '
        Try
            'tv2.Nodes.Clear()
            'tv2.CheckBoxes = False
            ''Llenamos los Nodos Primarios

            'tv2.Nodes.Add("Funcionarios")
            'For i As Integer = 0 To dv_Listar_funcionarios.Table.Rows.Count - 1
            '    tv2.Nodes(0).Nodes.Add(dv_Listar_funcionarios.Table.Rows(i)("usuario_personal").ToString)
            '    tv2.Nodes(0).Nodes(i).Tag = dv_Listar_funcionarios.Table.Rows(i)("idusuario_personal").ToString 'Tepsa 
            '    tv2.Nodes(0).Nodes(i).NodeFont = New Font("Arial", 8, FontStyle.Regular)
            'Next

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        tv2.ExpandAll()
    End Sub

    Private Sub llenar_agencias()
        Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
        dv_Listar_agencias = New DataView
        'datahelper
        dv_Listar_agencias = ObjGeneral.SP_Listar_agencias()
        '
        Try
            tv1.Nodes.Clear()
            tv1.CheckBoxes = False
            'Llenamos los Nodos Primarios
            tv1.Nodes.Add("Agencias")
            For i As Integer = 0 To dv_Listar_agencias.Table.Rows.Count - 1
                tv1.Nodes(0).Nodes.Add(dv_Listar_agencias.Table.Rows(i)("nombre_agencia").ToString)
                tv1.Nodes(0).Nodes(i).Tag = dv_Listar_agencias.Table.Rows(i)("idagencias").ToString 'Tepsa 
                tv1.Nodes(0).Nodes(i).NodeFont = New Font("Arial", 8, FontStyle.Regular)
            Next
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
        tv1.ExpandAll()
        '
    End Sub


    'Sub FORMAT_GRILLA1()
    '    DGV1.Columns.Clear()
    '    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL

    '    With DGV1
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False
    '        .AutoGenerateColumns = False
    '        Try
    '            .DataSource = ObjGeneral.SP_Listar_agencias(cnn)
    '        Catch OEx As System.Data.OracleClient.OracleException
    '            MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        End Try
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .VirtualMode = True
    '        .RowHeadersVisible = True
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    End With


    '    Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
    '    With ANIO_FACTURA
    '        .HeaderText = "ANIO_FACTURA"
    '        .Name = "ANIO_FACTURA"
    '        .DataPropertyName = "ANIO_FACTURA"
    '        .Width = 4
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
    '    With CODIGO_CLIENTE
    '        .HeaderText = "CODIGO_CLIENTE"
    '        .Name = "CODIGO_CLIENTE"
    '        .DataPropertyName = "CODIGO_CLIENTE"
    '        .Width = 20
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DESTINATARIO As New DataGridViewTextBoxColumn
    '    With DESTINATARIO
    '        .HeaderText = "DESTINATARIO"
    '        .Name = "DESTINATARIO"
    '        .DataPropertyName = "DESTINATARIO"
    '        .Width = 182
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DESTINO As New DataGridViewTextBoxColumn
    '    With DESTINO
    '        .HeaderText = "DESTINO"
    '        .Name = "DESTINO"
    '        .DataPropertyName = "DESTINO"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim DIA_FACTURA As New DataGridViewTextBoxColumn
    '    With DIA_FACTURA
    '        .HeaderText = "DIA_FACTURA"
    '        .Name = "DIA_FACTURA"
    '        .DataPropertyName = "DIA_FACTURA"
    '        .Width = 2
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
    '    With DIRECCION_PERSONA
    '        .HeaderText = "DIRECCION_PERSONA"
    '        .Name = "DIRECCION_PERSONA"
    '        .DataPropertyName = "DIRECCION_PERSONA"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim DIREC_DESTI As New DataGridViewTextBoxColumn
    '    With DIREC_DESTI
    '        .HeaderText = "DIREC_DESTI"
    '        .Name = "DIREC_DESTI"
    '        .DataPropertyName = "DIREC_DESTI"
    '        .Width = 200
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DIREC_REMI As New DataGridViewTextBoxColumn
    '    With DIREC_REMI
    '        .HeaderText = "DIREC_REMI"
    '        .Name = "DIREC_REMI"
    '        .DataPropertyName = "DIREC_REMI"
    '        .Width = 200
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DSCTO As New DataGridViewTextBoxColumn
    '    With DSCTO
    '        .HeaderText = "DSCTO"
    '        .Name = "DSCTO"
    '        .DataPropertyName = "DSCTO"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .Width = 80
    '        .ReadOnly = True
    '    End With
    '    Dim FECHA As New DataGridViewTextBoxColumn
    '    With FECHA
    '        .HeaderText = "FECHA"
    '        .Name = "FECHA"
    '        .DataPropertyName = "FECHA"
    '        .Width = 80
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
    '    With ESTADO_REGISTRO
    '        .HeaderText = "ESTADO_REGISTRO"
    '        .Name = "ESTADO_REGISTRO"
    '        .DataPropertyName = "ESTADO_REGISTRO"
    '        .Width = 100
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
    '    With NOMBRE_AGENCIA
    '        .HeaderText = "NOMBRE_AGENCIA"
    '        .Name = "NOMBRE_AGENCIA"
    '        .DataPropertyName = "NOMBRE_AGENCIA"
    '        .Width = 150
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim FORMA_PAGO As New DataGridViewTextBoxColumn
    '    With FORMA_PAGO
    '        .HeaderText = "FORMA_PAGO"
    '        .Name = "FORMA_PAGO"
    '        .DataPropertyName = "FORMA_PAGO"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim IDAGENCIAS As New DataGridViewTextBoxColumn
    '    With IDAGENCIAS
    '        .HeaderText = "IDAGENCIAS"
    '        .Name = "IDAGENCIAS"
    '        .DataPropertyName = "IDAGENCIAS"
    '        .Width = 30
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N0"
    '        '.DefaultCellStyle.NullValue = "0,00"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim IDFACTURA As New DataGridViewTextBoxColumn
    '    With IDFACTURA
    '        .HeaderText = "IDFACTURA"
    '        .Name = "IDFACTURA"
    '        .DataPropertyName = "IDFACTURA"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
    '    With IDFORMA_PAGO
    '        .HeaderText = "IDFORMA_PAGO"
    '        .Name = "IDFORMA_PAGO"
    '        .DataPropertyName = "IDFORMA_PAGO"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
    '    With IDTIPO_MONEDA
    '        .HeaderText = "IDTIPO_MONEDA"
    '        .Name = "IDTIPO_MONEDA"
    '        .DataPropertyName = "IDTIPO_MONEDA"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
    '    With IDUSUARIO_PERSONAL
    '        .HeaderText = "IDUSUARIO_PERSONAL"
    '        .Name = "IDUSUARIO_PERSONAL"
    '        .DataPropertyName = "IDUSUARIO_PERSONAL"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim MEMO As New DataGridViewTextBoxColumn
    '    With MEMO
    '        .HeaderText = "MEMO"
    '        .Name = "MEMO"
    '        .DataPropertyName = "MEMO"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim MES_FACTURA As New DataGridViewTextBoxColumn
    '    With MES_FACTURA
    '        .HeaderText = "MES_FACTURA"
    '        .Name = "MES_FACTURA"
    '        .DataPropertyName = "MES_FACTURA"
    '        .Width = 10
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
    '    With MONTO_IMPUESTO
    '        .HeaderText = "MONTO_IMPUESTO"
    '        .Name = "MONTO_IMPUESTO"
    '        .DataPropertyName = "MONTO_IMPUESTO"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim NRO_FACTURA As New DataGridViewTextBoxColumn
    '    With NRO_FACTURA
    '        .HeaderText = "NRO_FACTURA"
    '        .Name = "NRO_FACTURA"
    '        .DataPropertyName = "NRO_FACTURA"
    '        .Width = 70
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '    End With
    '    Dim ORIGEN As New DataGridViewTextBoxColumn
    '    With ORIGEN
    '        .HeaderText = "ORIGEN"
    '        .Name = "ORIGEN"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DataPropertyName = "ORIGEN"

    '        .ReadOnly = True
    '    End With
    '    Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
    '    With RAZON_SOCIAL
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .HeaderText = "RAZON_SOCIAL"
    '        .Name = "RAZON_SOCIAL"
    '        .DataPropertyName = "RAZON_SOCIAL"
    '        .Width = 200
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim REFE As New DataGridViewTextBoxColumn
    '    With REFE
    '        .HeaderText = "REFE"
    '        .Name = "REFE"
    '        .DataPropertyName = "REFE"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim REMITENTE As New DataGridViewTextBoxColumn
    '    With REMITENTE
    '        .HeaderText = "REMITENTE"
    '        .Name = "REMITENTE"
    '        .DataPropertyName = "REMITENTE"
    '        .Width = 182
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
    '    With SERIE_FACTURA
    '        .HeaderText = "SERIE_FACTURA"
    '        .Name = "SERIE_FACTURA"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DataPropertyName = "SERIE_FACTURA"
    '        .Width = 30
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
    '    With SIMBOLO_MONEDA
    '        .HeaderText = "SIMBOLO_MONEDA"
    '        .Name = "SIMBOLO_MONEDA"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DataPropertyName = "SIMBOLO_MONEDA"
    '        .Width = 30
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim SUB_TOTAL As New DataGridViewTextBoxColumn
    '    With SUB_TOTAL
    '        .HeaderText = "SUB_TOTAL"
    '        .Name = "SUB_TOTAL"
    '        .DataPropertyName = "SUB_TOTAL"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim LOGIN As New DataGridViewTextBoxColumn
    '    With LOGIN
    '        .HeaderText = "LOGIN"
    '        .Name = "LOGIN"
    '        .DataPropertyName = "LOGIN"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
    '    With TOTAL_COSTO
    '        .HeaderText = "TOTAL_COSTO"
    '        .Name = "TOTAL_COSTO"
    '        .DataPropertyName = "TOTAL_COSTO"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
    '    With NRO_PREFACTURA
    '        .HeaderText = "NRO_PREFACTURA"
    '        .Name = "NRO_PREFACTURA"
    '        .DataPropertyName = "NRO_PREFACTURA"
    '        .Width = 100
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With

    '    With DGV1
    '        .Columns.AddRange(IDAGENCIAS, NOMBRE_AGENCIA)

    '    End With
    'End Sub
    'Sub FORMAT_GRILLA3()
    '    dgv3.Columns.Clear()
    '    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL

    '    With dgv3
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False
    '        .AutoGenerateColumns = False
    '        Try
    '            .DataSource = ObjGeneral.sp_L_funcionario_carga(cnn)
    '        Catch OEx As System.Data.OracleClient.OracleException
    '            MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        End Try

    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .VirtualMode = True
    '        .RowHeadersVisible = True
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    End With

    '    Dim USUARIO_PERSONAL As New DataGridViewTextBoxColumn
    '    With USUARIO_PERSONAL
    '        .HeaderText = "USUARIO_PERSONAL"
    '        .Name = "USUARIO_PERSONAL"
    '        .DataPropertyName = "USUARIO_PERSONAL"
    '        .Width = 150
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
    '    With IDUSUARIO_PERSONAL
    '        .HeaderText = "IDUSUARIO_PERSONAL"
    '        .Name = "IDUSUARIO_PERSONAL"
    '        .DataPropertyName = "IDUSUARIO_PERSONAL"
    '        .Width = 30
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N0"
    '        '.DefaultCellStyle.NullValue = "0,00"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With


    '    With dgv3
    '        .Columns.AddRange(IDUSUARIO_PERSONAL, USUARIO_PERSONAL)

    '    End With
    'End Sub

    Sub FORMAT_GRILLA2()
        DGV2.Columns.Clear()

        ObjComisiones.FECHA_INI = Me.DTPFECHAINICIO.Value.ToShortDateString
        ObjComisiones.FECHA_FINAL = Me.DTPFECHAFINAL.Value.ToShortDateString
        'ObjComisiones.IDAGENCIAS = Me.DGV1.CurrentRow.Cells("IDAGENCIAS").Value
        For i As Integer = 0 To Me.tv1.Nodes(0).Nodes.Count - 1
            If Me.tv1.Nodes(0).Nodes(i).IsSelected Then
                ObjComisiones.IDAGENCIAS = Me.tv1.Nodes(0).Nodes(i).Tag
                ObjAgencias.IDAGENCIAS = Me.tv1.Nodes(0).Nodes(i).Tag
                'Datahelper
                ObjAgencias.SP_SELEC_AGENCIA()
                Label8.Text = Me.tv1.Nodes(0).Nodes(i).Tag + " " + Me.tv1.Nodes(0).Nodes(i).Text
                Exit For
            End If
        Next

        With DGV2
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False

            DTcomisiones = New DataTable

            DTcomisiones = ObjComisiones.SP_L_SERVICIOS_MONTO()

            Dim MyDataColum As DataColumn

            MyDataColum = New DataColumn
            MyDataColum.DataType = System.Type.GetType("System.Int32")
            MyDataColum.ColumnName = "Ordenar_Fisca"
            MyDataColum.AutoIncrement = False
            MyDataColum.ReadOnly = False
            MyDataColum.Unique = False
            DTcomisiones.Columns.Add(MyDataColum)

            Dim MyDataRowTotal As DataRow
            MyDataRowTotal = DTcomisiones.NewRow
            MyDataRowTotal("idtipo_comprobante") = 74
            MyDataRowTotal("TIPO_COMPROBANTE") = "TOTAL"
            MyDataRowTotal("TOTAL_COSTO") = 0
            MyDataRowTotal("AFEC_COMI") = 0
            MyDataRowTotal("SUB_TOTAL") = 0
            MyDataRowTotal("PORCEN") = 0
            MyDataRowTotal("MONTO_PORCEN") = 0
            MyDataRowTotal("NRO") = 0
            MyDataRowTotal("monto_x_comprobante") = 0
            MyDataRowTotal("Total_por_compro") = 0
            MyDataRowTotal("Ocupabilidad") = 0
            MyDataRowTotal("canti_servi") = 0
            MyDataRowTotal("para_monto_comi_ocu") = 0
            MyDataRowTotal("monto_ocupa_calcu") = 0
            MyDataRowTotal("otros") = 0
            MyDataRowTotal("sub_total_pagar_comi") = 0
            MyDataRowTotal("Ordenar_Fisca") = 100

            Dim MyDataRowTotalOtros As DataRow
            MyDataRowTotalOtros = DTcomisiones.NewRow
            MyDataRowTotalOtros("idtipo_comprobante") = 73
            MyDataRowTotalOtros("TIPO_COMPROBANTE") = "TOTAL OTROS"
            MyDataRowTotalOtros("TOTAL_COSTO") = 0
            MyDataRowTotalOtros("AFEC_COMI") = 0
            MyDataRowTotalOtros("SUB_TOTAL") = 0
            MyDataRowTotalOtros("PORCEN") = 0
            MyDataRowTotalOtros("MONTO_PORCEN") = 0
            MyDataRowTotalOtros("NRO") = 0
            MyDataRowTotalOtros("monto_x_comprobante") = 0
            MyDataRowTotalOtros("Total_por_compro") = 0
            MyDataRowTotalOtros("Ocupabilidad") = 0
            MyDataRowTotalOtros("canti_servi") = 0
            MyDataRowTotalOtros("para_monto_comi_ocu") = 0
            MyDataRowTotalOtros("monto_ocupa_calcu") = 0
            MyDataRowTotalOtros("otros") = 0
            MyDataRowTotalOtros("sub_total_pagar_comi") = 0
            MyDataRowTotalOtros("Ordenar_Fisca") = 95

            Dim MyDataRowTotalPasa As DataRow
            MyDataRowTotalPasa = DTcomisiones.NewRow
            MyDataRowTotalPasa("idtipo_comprobante") = 72
            MyDataRowTotalPasa("TIPO_COMPROBANTE") = "TOTAL PASAJES"
            MyDataRowTotalPasa("TOTAL_COSTO") = 0
            MyDataRowTotalPasa("AFEC_COMI") = 0
            MyDataRowTotalPasa("SUB_TOTAL") = 0
            MyDataRowTotalPasa("PORCEN") = 0
            MyDataRowTotalPasa("MONTO_PORCEN") = 0
            MyDataRowTotalPasa("NRO") = 0
            MyDataRowTotalPasa("monto_x_comprobante") = 0
            MyDataRowTotalPasa("Total_por_compro") = 0
            MyDataRowTotalPasa("Ocupabilidad") = 0
            MyDataRowTotalPasa("canti_servi") = 0
            MyDataRowTotalPasa("para_monto_comi_ocu") = 0
            MyDataRowTotalPasa("monto_ocupa_calcu") = 0
            MyDataRowTotalPasa("otros") = 0
            MyDataRowTotalPasa("sub_total_pagar_comi") = 0
            MyDataRowTotalPasa("Ordenar_Fisca") = 21

            Dim MyDataRowTotalPasajesPresi As DataRow
            MyDataRowTotalPasajesPresi = DTcomisiones.NewRow
            MyDataRowTotalPasajesPresi("idtipo_comprobante") = 70
            MyDataRowTotalPasajesPresi("TIPO_COMPROBANTE") = "TOTAL PASAJES PRESIDENCIALES"
            MyDataRowTotalPasajesPresi("TOTAL_COSTO") = 0
            MyDataRowTotalPasajesPresi("AFEC_COMI") = 0
            MyDataRowTotalPasajesPresi("SUB_TOTAL") = 0
            MyDataRowTotalPasajesPresi("PORCEN") = 0
            MyDataRowTotalPasajesPresi("MONTO_PORCEN") = 0
            MyDataRowTotalPasajesPresi("NRO") = 0
            MyDataRowTotalPasajesPresi("monto_x_comprobante") = 0
            MyDataRowTotalPasajesPresi("Total_por_compro") = 0
            MyDataRowTotalPasajesPresi("Ocupabilidad") = 0
            MyDataRowTotalPasajesPresi("canti_servi") = 0
            MyDataRowTotalPasajesPresi("para_monto_comi_ocu") = 0
            MyDataRowTotalPasajesPresi("monto_ocupa_calcu") = 0
            MyDataRowTotalPasajesPresi("otros") = 0
            MyDataRowTotalPasajesPresi("sub_total_pagar_comi") = 0
            MyDataRowTotalPasajesPresi("Ordenar_Fisca") = 31

            Dim MyDataRowTotalCarga As DataRow
            MyDataRowTotalCarga = DTcomisiones.NewRow
            MyDataRowTotalCarga("idtipo_comprobante") = 71
            MyDataRowTotalCarga("TIPO_COMPROBANTE") = "TOTAL CARGA"
            MyDataRowTotalCarga("TOTAL_COSTO") = 0
            MyDataRowTotalCarga("AFEC_COMI") = 0
            MyDataRowTotalCarga("SUB_TOTAL") = 0
            MyDataRowTotalCarga("PORCEN") = 0
            MyDataRowTotalCarga("MONTO_PORCEN") = 0
            MyDataRowTotalCarga("NRO") = 0
            MyDataRowTotalCarga("monto_x_comprobante") = 0
            MyDataRowTotalCarga("Total_por_compro") = 0
            MyDataRowTotalCarga("Ocupabilidad") = 0
            MyDataRowTotalCarga("canti_servi") = 0
            MyDataRowTotalCarga("para_monto_comi_ocu") = 0
            MyDataRowTotalCarga("monto_ocupa_calcu") = 0
            MyDataRowTotalCarga("otros") = 0
            MyDataRowTotalCarga("sub_total_pagar_comi") = 0
            MyDataRowTotalCarga("Ordenar_Fisca") = 61

            Dim valor_orden As New Integer

            ObjComisiones.IDTIPO_COMPROBANTE = 12
            ObjComisiones.SP_SELEC_TIPO_COMPRO_AGEN()


            For i As Integer = 0 To DTcomisiones.Rows.Count - 1
                Select Case DTcomisiones.Rows(i)("idtipo_comprobante")
                    'inicio boletos de viaje y recibos pasajes
                    '---------------------------------------------
                    Case 11 'BOLETO PREMIER
                        valor_orden = 5

                        MyDataRowTotalPasa("TOTAL_COSTO") = MyDataRowTotalPasa("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalPasa("AFEC_COMI") = 0
                        MyDataRowTotalPasa("SUB_TOTAL") = MyDataRowTotalPasa("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalPasa("PORCEN") = 0
                        MyDataRowTotalPasa("MONTO_PORCEN") = MyDataRowTotalPasa("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalPasa("NRO") = MyDataRowTotalPasa("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalPasa("monto_x_comprobante") = MyDataRowTotalPasa("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalPasa("Total_por_compro") = MyDataRowTotalPasa("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        MyDataRowTotalPasa("otros") = MyDataRowTotalPasa("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalPasa("sub_total_pagar_comi") = MyDataRowTotalPasa("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")

                    Case 17 'RECIBOS DE CAJAS CLASICOS
                        valor_orden = 10

                        MyDataRowTotalPasa("TOTAL_COSTO") = MyDataRowTotalPasa("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalPasa("AFEC_COMI") = 0
                        MyDataRowTotalPasa("SUB_TOTAL") = MyDataRowTotalPasa("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalPasa("PORCEN") = 0
                        MyDataRowTotalPasa("MONTO_PORCEN") = MyDataRowTotalPasa("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalPasa("NRO") = MyDataRowTotalPasa("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalPasa("monto_x_comprobante") = MyDataRowTotalPasa("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalPasa("Total_por_compro") = MyDataRowTotalPasa("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        MyDataRowTotalPasa("otros") = MyDataRowTotalPasa("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalPasa("sub_total_pagar_comi") = MyDataRowTotalPasa("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")
                    Case 10 'BOLETO PREMIER
                        valor_orden = 15

                        MyDataRowTotalPasa("TOTAL_COSTO") = MyDataRowTotalPasa("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalPasa("AFEC_COMI") = 0
                        MyDataRowTotalPasa("SUB_TOTAL") = MyDataRowTotalPasa("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalPasa("PORCEN") = 0
                        MyDataRowTotalPasa("MONTO_PORCEN") = MyDataRowTotalPasa("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalPasa("NRO") = MyDataRowTotalPasa("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalPasa("monto_x_comprobante") = MyDataRowTotalPasa("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalPasa("Total_por_compro") = MyDataRowTotalPasa("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        MyDataRowTotalPasa("otros") = MyDataRowTotalPasa("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalPasa("sub_total_pagar_comi") = MyDataRowTotalPasa("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")

                    Case 16 'RECIBOS DE CAJAS PREMIER
                        valor_orden = 20

                        MyDataRowTotalPasa("TOTAL_COSTO") = MyDataRowTotalPasa("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalPasa("AFEC_COMI") = 0
                        MyDataRowTotalPasa("SUB_TOTAL") = MyDataRowTotalPasa("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalPasa("PORCEN") = 0
                        MyDataRowTotalPasa("MONTO_PORCEN") = MyDataRowTotalPasa("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalPasa("NRO") = MyDataRowTotalPasa("NRO") + DTcomisiones.Rows(i)("NRO")
                        MyDataRowTotalPasa("monto_x_comprobante") = MyDataRowTotalPasa("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalPasa("Total_por_compro") = MyDataRowTotalPasa("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        MyDataRowTotalPasa("otros") = MyDataRowTotalPasa("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalPasa("sub_total_pagar_comi") = MyDataRowTotalPasa("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")

                    Case 12 'BOLETO PRESIDENCIAL
                        valor_orden = 25
                        MyDataRowTotalPasajesPresi("TOTAL_COSTO") = MyDataRowTotalPasajesPresi("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalPasajesPresi("AFEC_COMI") = 0
                        MyDataRowTotalPasajesPresi("SUB_TOTAL") = MyDataRowTotalPasajesPresi("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalPasajesPresi("PORCEN") = 0
                        MyDataRowTotalPasajesPresi("MONTO_PORCEN") = MyDataRowTotalPasajesPresi("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalPasajesPresi("NRO") = MyDataRowTotalPasajesPresi("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalPasajesPresi("monto_x_comprobante") = MyDataRowTotalPasajesPresi("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalPasajesPresi("Total_por_compro") = MyDataRowTotalPasajesPresi("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        MyDataRowTotalPasajesPresi("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        MyDataRowTotalPasajesPresi("canti_servi") = ObjComisiones.CANTI_SERVI
                        If ObjComisiones.OCUPABILIDAD = 0 Or ObjComisiones.CANTI_SERVI = 0 Then
                            ObjComisiones.para_monto_comi_ocu = 0
                        Else
                            ObjComisiones.para_monto_comi_ocu = FormatNumber(MyDataRowTotalPasajesPresi("NRO") / (ObjComisiones.OCUPABILIDAD * ObjComisiones.CANTI_SERVI), 2) * 100
                        End If
                        MyDataRowTotalPasajesPresi("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        '
                        MyDataRowTotalPasajesPresi("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa()
                        MyDataRowTotalPasajesPresi("otros") = MyDataRowTotalPasajesPresi("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalPasajesPresi("sub_total_pagar_comi") = MyDataRowTotalPasajesPresi("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")
                        'MyDataRowTotalPasajesPresi("Ordenar_Fisca") = 31

                    Case 18 'RECIBOS DE CAJAS PRESIDENCIAL
                        valor_orden = 30
                        MyDataRowTotalPasajesPresi("TOTAL_COSTO") = MyDataRowTotalPasajesPresi("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalPasajesPresi("AFEC_COMI") = 0
                        MyDataRowTotalPasajesPresi("SUB_TOTAL") = MyDataRowTotalPasajesPresi("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalPasajesPresi("PORCEN") = 0
                        MyDataRowTotalPasajesPresi("MONTO_PORCEN") = MyDataRowTotalPasajesPresi("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalPasajesPresi("NRO") = MyDataRowTotalPasajesPresi("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalPasajesPresi("monto_x_comprobante") = MyDataRowTotalPasajesPresi("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalPasajesPresi("Total_por_compro") = MyDataRowTotalPasajesPresi("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        MyDataRowTotalPasajesPresi("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        MyDataRowTotalPasajesPresi("canti_servi") = ObjComisiones.CANTI_SERVI
                        If ObjComisiones.OCUPABILIDAD = 0 Or ObjComisiones.CANTI_SERVI = 0 Then
                            ObjComisiones.para_monto_comi_ocu = 0
                        Else
                            ObjComisiones.para_monto_comi_ocu = FormatNumber(MyDataRowTotalPasajesPresi("NRO") / (ObjComisiones.OCUPABILIDAD * ObjComisiones.CANTI_SERVI), 2) * 100
                        End If
                        MyDataRowTotalPasajesPresi("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        MyDataRowTotalPasajesPresi("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa()
                        MyDataRowTotalPasajesPresi("otros") = MyDataRowTotalPasajesPresi("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalPasajesPresi("sub_total_pagar_comi") = MyDataRowTotalPasajesPresi("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")
                        'MyDataRowTotalPasajesPresi("Ordenar_Fisca") = 31
                    Case 34 'BOLETO PRESIDENCIAL CAMA
                        valor_orden = 26
                        MyDataRowTotalPasajesPresi("TOTAL_COSTO") = MyDataRowTotalPasajesPresi("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalPasajesPresi("AFEC_COMI") = 0
                        MyDataRowTotalPasajesPresi("SUB_TOTAL") = MyDataRowTotalPasajesPresi("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalPasajesPresi("PORCEN") = 0
                        MyDataRowTotalPasajesPresi("MONTO_PORCEN") = MyDataRowTotalPasajesPresi("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalPasajesPresi("NRO") = MyDataRowTotalPasajesPresi("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalPasajesPresi("monto_x_comprobante") = MyDataRowTotalPasajesPresi("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalPasajesPresi("Total_por_compro") = MyDataRowTotalPasajesPresi("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        MyDataRowTotalPasajesPresi("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        MyDataRowTotalPasajesPresi("canti_servi") = ObjComisiones.CANTI_SERVI
                        If ObjComisiones.OCUPABILIDAD = 0 Or ObjComisiones.CANTI_SERVI = 0 Then
                            ObjComisiones.para_monto_comi_ocu = 0
                        Else
                            ObjComisiones.para_monto_comi_ocu = FormatNumber(MyDataRowTotalPasajesPresi("NRO") / (ObjComisiones.OCUPABILIDAD * ObjComisiones.CANTI_SERVI), 2) * 100
                        End If
                        MyDataRowTotalPasajesPresi("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        MyDataRowTotalPasajesPresi("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa()
                        MyDataRowTotalPasajesPresi("otros") = MyDataRowTotalPasajesPresi("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalPasajesPresi("sub_total_pagar_comi") = MyDataRowTotalPasajesPresi("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")
                        'MyDataRowTotalPasajesPresi("Ordenar_Fisca") = 31
                    Case 35 'RECIBOS DE CAJAS PRESIDENCIAL
                        valor_orden = 31
                        MyDataRowTotalPasajesPresi("TOTAL_COSTO") = MyDataRowTotalPasajesPresi("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalPasajesPresi("AFEC_COMI") = 0
                        MyDataRowTotalPasajesPresi("SUB_TOTAL") = MyDataRowTotalPasajesPresi("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalPasajesPresi("PORCEN") = 0
                        MyDataRowTotalPasajesPresi("MONTO_PORCEN") = MyDataRowTotalPasajesPresi("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalPasajesPresi("NRO") = MyDataRowTotalPasajesPresi("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalPasajesPresi("monto_x_comprobante") = MyDataRowTotalPasajesPresi("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalPasajesPresi("Total_por_compro") = MyDataRowTotalPasajesPresi("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        MyDataRowTotalPasajesPresi("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        MyDataRowTotalPasajesPresi("canti_servi") = ObjComisiones.CANTI_SERVI
                        If ObjComisiones.OCUPABILIDAD = 0 Or ObjComisiones.CANTI_SERVI = 0 Then
                            ObjComisiones.para_monto_comi_ocu = 0
                        Else
                            ObjComisiones.para_monto_comi_ocu = FormatNumber(MyDataRowTotalPasajesPresi("NRO") / (ObjComisiones.OCUPABILIDAD * ObjComisiones.CANTI_SERVI), 2) * 100
                        End If
                        MyDataRowTotalPasajesPresi("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        MyDataRowTotalPasajesPresi("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa()
                        MyDataRowTotalPasajesPresi("otros") = MyDataRowTotalPasajesPresi("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalPasajesPresi("sub_total_pagar_comi") = MyDataRowTotalPasajesPresi("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")
                    Case 87 'TEPSA SUITE
                        valor_orden = 27
                        MyDataRowTotalPasajesPresi("TOTAL_COSTO") = MyDataRowTotalPasajesPresi("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalPasajesPresi("AFEC_COMI") = 0
                        MyDataRowTotalPasajesPresi("SUB_TOTAL") = MyDataRowTotalPasajesPresi("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalPasajesPresi("PORCEN") = 0
                        MyDataRowTotalPasajesPresi("MONTO_PORCEN") = MyDataRowTotalPasajesPresi("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalPasajesPresi("NRO") = MyDataRowTotalPasajesPresi("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalPasajesPresi("monto_x_comprobante") = MyDataRowTotalPasajesPresi("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalPasajesPresi("Total_por_compro") = MyDataRowTotalPasajesPresi("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        MyDataRowTotalPasajesPresi("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        MyDataRowTotalPasajesPresi("canti_servi") = ObjComisiones.CANTI_SERVI
                        If ObjComisiones.OCUPABILIDAD = 0 Or ObjComisiones.CANTI_SERVI = 0 Then
                            ObjComisiones.para_monto_comi_ocu = 0
                        Else
                            ObjComisiones.para_monto_comi_ocu = FormatNumber(MyDataRowTotalPasajesPresi("NRO") / (ObjComisiones.OCUPABILIDAD * ObjComisiones.CANTI_SERVI), 2) * 100
                        End If
                        MyDataRowTotalPasajesPresi("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        MyDataRowTotalPasajesPresi("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa()
                        MyDataRowTotalPasajesPresi("otros") = MyDataRowTotalPasajesPresi("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalPasajesPresi("sub_total_pagar_comi") = MyDataRowTotalPasajesPresi("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")
                    Case 88 'RECIBOS DE CAJA TEPSA SUITE
                        valor_orden = 28
                        MyDataRowTotalPasajesPresi("TOTAL_COSTO") = MyDataRowTotalPasajesPresi("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalPasajesPresi("AFEC_COMI") = 0
                        MyDataRowTotalPasajesPresi("SUB_TOTAL") = MyDataRowTotalPasajesPresi("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalPasajesPresi("PORCEN") = 0
                        MyDataRowTotalPasajesPresi("MONTO_PORCEN") = MyDataRowTotalPasajesPresi("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalPasajesPresi("NRO") = MyDataRowTotalPasajesPresi("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalPasajesPresi("monto_x_comprobante") = MyDataRowTotalPasajesPresi("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalPasajesPresi("Total_por_compro") = MyDataRowTotalPasajesPresi("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        MyDataRowTotalPasajesPresi("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        MyDataRowTotalPasajesPresi("canti_servi") = ObjComisiones.CANTI_SERVI
                        If ObjComisiones.OCUPABILIDAD = 0 Or ObjComisiones.CANTI_SERVI = 0 Then
                            ObjComisiones.para_monto_comi_ocu = 0
                        Else
                            ObjComisiones.para_monto_comi_ocu = FormatNumber(MyDataRowTotalPasajesPresi("NRO") / (ObjComisiones.OCUPABILIDAD * ObjComisiones.CANTI_SERVI), 2) * 100
                        End If
                        MyDataRowTotalPasajesPresi("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        MyDataRowTotalPasajesPresi("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa()
                        MyDataRowTotalPasajesPresi("otros") = MyDataRowTotalPasajesPresi("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalPasajesPresi("sub_total_pagar_comi") = MyDataRowTotalPasajesPresi("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")
                    Case 89 'BOLETO TEPSA CAMA SUITE
                        valor_orden = 29
                        MyDataRowTotalPasajesPresi("TOTAL_COSTO") = MyDataRowTotalPasajesPresi("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalPasajesPresi("AFEC_COMI") = 0
                        MyDataRowTotalPasajesPresi("SUB_TOTAL") = MyDataRowTotalPasajesPresi("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalPasajesPresi("PORCEN") = 0
                        MyDataRowTotalPasajesPresi("MONTO_PORCEN") = MyDataRowTotalPasajesPresi("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalPasajesPresi("NRO") = MyDataRowTotalPasajesPresi("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalPasajesPresi("monto_x_comprobante") = MyDataRowTotalPasajesPresi("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalPasajesPresi("Total_por_compro") = MyDataRowTotalPasajesPresi("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        MyDataRowTotalPasajesPresi("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        MyDataRowTotalPasajesPresi("canti_servi") = ObjComisiones.CANTI_SERVI
                        If ObjComisiones.OCUPABILIDAD = 0 Or ObjComisiones.CANTI_SERVI = 0 Then
                            ObjComisiones.para_monto_comi_ocu = 0
                        Else
                            ObjComisiones.para_monto_comi_ocu = FormatNumber(MyDataRowTotalPasajesPresi("NRO") / (ObjComisiones.OCUPABILIDAD * ObjComisiones.CANTI_SERVI), 2) * 100
                        End If
                        MyDataRowTotalPasajesPresi("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        MyDataRowTotalPasajesPresi("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa()
                        MyDataRowTotalPasajesPresi("otros") = MyDataRowTotalPasajesPresi("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalPasajesPresi("sub_total_pagar_comi") = MyDataRowTotalPasajesPresi("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")
                    Case 90 'RECIBO DE CAJA TEPSA CAMA SUITE
                        valor_orden = 30
                        MyDataRowTotalPasajesPresi("TOTAL_COSTO") = MyDataRowTotalPasajesPresi("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalPasajesPresi("AFEC_COMI") = 0
                        MyDataRowTotalPasajesPresi("SUB_TOTAL") = MyDataRowTotalPasajesPresi("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalPasajesPresi("PORCEN") = 0
                        MyDataRowTotalPasajesPresi("MONTO_PORCEN") = MyDataRowTotalPasajesPresi("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalPasajesPresi("NRO") = MyDataRowTotalPasajesPresi("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalPasajesPresi("monto_x_comprobante") = MyDataRowTotalPasajesPresi("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalPasajesPresi("Total_por_compro") = MyDataRowTotalPasajesPresi("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        MyDataRowTotalPasajesPresi("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        MyDataRowTotalPasajesPresi("canti_servi") = ObjComisiones.CANTI_SERVI
                        If ObjComisiones.OCUPABILIDAD = 0 Or ObjComisiones.CANTI_SERVI = 0 Then
                            ObjComisiones.para_monto_comi_ocu = 0
                        Else
                            ObjComisiones.para_monto_comi_ocu = FormatNumber(MyDataRowTotalPasajesPresi("NRO") / (ObjComisiones.OCUPABILIDAD * ObjComisiones.CANTI_SERVI), 2) * 100
                        End If
                        MyDataRowTotalPasajesPresi("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        MyDataRowTotalPasajesPresi("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa()
                        MyDataRowTotalPasajesPresi("otros") = MyDataRowTotalPasajesPresi("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalPasajesPresi("sub_total_pagar_comi") = MyDataRowTotalPasajesPresi("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")

                        '---------------------------------------------
                        'fin boletos de viaje y recibos pasajes
                        '---------------------------------------------
                        'Inicio boletos de Carga
                    Case 2 'BOLETA VENTA
                        valor_orden = 45
                        MyDataRowTotalCarga("TOTAL_COSTO") = MyDataRowTotalCarga("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalCarga("AFEC_COMI") = 0
                        MyDataRowTotalCarga("SUB_TOTAL") = MyDataRowTotalCarga("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalCarga("PORCEN") = 0
                        MyDataRowTotalCarga("MONTO_PORCEN") = MyDataRowTotalCarga("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalCarga("NRO") = MyDataRowTotalCarga("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalCarga("monto_x_comprobante") = MyDataRowTotalCarga("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalCarga("Total_por_compro") = MyDataRowTotalCarga("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        'MyDataRowTotalCarga("Ocupabilidad") = 0
                        'MyDataRowTotalCarga("canti_servi") = 0
                        'MyDataRowTotalCarga("para_monto_comi_ocu") = 0
                        'MyDataRowTotalCarga("monto_ocupa_calcu") = 0
                        MyDataRowTotalCarga("otros") = MyDataRowTotalCarga("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalCarga("sub_total_pagar_comi") = MyDataRowTotalCarga("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")
                        'MyDataRowTotalPasajesPresi("Ordenar_Fisca") = 31

                    Case 1 'FACTURA 
                        valor_orden = 50
                        MyDataRowTotalCarga("TOTAL_COSTO") = MyDataRowTotalCarga("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalCarga("AFEC_COMI") = 0
                        MyDataRowTotalCarga("SUB_TOTAL") = MyDataRowTotalCarga("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalCarga("PORCEN") = 0
                        MyDataRowTotalCarga("MONTO_PORCEN") = MyDataRowTotalCarga("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalCarga("NRO") = MyDataRowTotalCarga("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalCarga("monto_x_comprobante") = MyDataRowTotalCarga("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalCarga("Total_por_compro") = MyDataRowTotalCarga("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        'MyDataRowTotalCarga("Ocupabilidad") = 0
                        'MyDataRowTotalCarga("canti_servi") = 0
                        'MyDataRowTotalCarga("para_monto_comi_ocu") = 0
                        'MyDataRowTotalCarga("monto_ocupa_calcu") = 0
                        MyDataRowTotalCarga("otros") = MyDataRowTotalCarga("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalCarga("sub_total_pagar_comi") = MyDataRowTotalCarga("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")
                        'MyDataRowTotalPasajesPresi("Ordenar_Fisca") = 31

                    Case 3 'GUIAS DE ENVIO
                        valor_orden = 55
                        MyDataRowTotalCarga("TOTAL_COSTO") = MyDataRowTotalCarga("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalCarga("AFEC_COMI") = 0
                        MyDataRowTotalCarga("SUB_TOTAL") = MyDataRowTotalCarga("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalCarga("PORCEN") = 0
                        MyDataRowTotalCarga("MONTO_PORCEN") = MyDataRowTotalCarga("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalCarga("NRO") = MyDataRowTotalCarga("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalCarga("monto_x_comprobante") = MyDataRowTotalCarga("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalCarga("Total_por_compro") = MyDataRowTotalCarga("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        'MyDataRowTotalCarga("Ocupabilidad") = 0
                        'MyDataRowTotalCarga("canti_servi") = 0
                        'MyDataRowTotalCarga("para_monto_comi_ocu") = 0
                        'MyDataRowTotalCarga("monto_ocupa_calcu") = 0
                        MyDataRowTotalCarga("otros") = MyDataRowTotalCarga("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalCarga("sub_total_pagar_comi") = MyDataRowTotalCarga("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")
                        'MyDataRowTotalPasajesPresi("Ordenar_Fisca") = 31

                    Case 15 'BOLETAS DE EXCESO
                        valor_orden = 60
                        MyDataRowTotalCarga("TOTAL_COSTO") = MyDataRowTotalCarga("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalCarga("AFEC_COMI") = 0
                        MyDataRowTotalCarga("SUB_TOTAL") = MyDataRowTotalCarga("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalCarga("PORCEN") = 0
                        MyDataRowTotalCarga("MONTO_PORCEN") = MyDataRowTotalCarga("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalCarga("NRO") = MyDataRowTotalCarga("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalCarga("monto_x_comprobante") = MyDataRowTotalCarga("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalCarga("Total_por_compro") = MyDataRowTotalCarga("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        'MyDataRowTotalCarga("Ocupabilidad") = 0
                        'MyDataRowTotalCarga("canti_servi") = 0
                        'MyDataRowTotalCarga("para_monto_comi_ocu") = 0
                        'MyDataRowTotalCarga("monto_ocupa_calcu") = 0
                        MyDataRowTotalCarga("otros") = MyDataRowTotalCarga("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalCarga("sub_total_pagar_comi") = MyDataRowTotalCarga("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")
                        'MyDataRowTotalPasajesPresi("Ordenar_Fisca") = 31

                    Case 25 'BOLETA VENTA (GIROS)
                        valor_orden = 46
                        MyDataRowTotalCarga("TOTAL_COSTO") = MyDataRowTotalCarga("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalCarga("AFEC_COMI") = 0
                        MyDataRowTotalCarga("SUB_TOTAL") = MyDataRowTotalCarga("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalCarga("PORCEN") = 0
                        MyDataRowTotalCarga("MONTO_PORCEN") = MyDataRowTotalCarga("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalCarga("NRO") = MyDataRowTotalCarga("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalCarga("monto_x_comprobante") = MyDataRowTotalCarga("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalCarga("Total_por_compro") = MyDataRowTotalCarga("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        'MyDataRowTotalCarga("Ocupabilidad") = 0
                        'MyDataRowTotalCarga("canti_servi") = 0
                        'MyDataRowTotalCarga("para_monto_comi_ocu") = 0
                        'MyDataRowTotalCarga("monto_ocupa_calcu") = 0
                        MyDataRowTotalCarga("otros") = MyDataRowTotalCarga("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalCarga("sub_total_pagar_comi") = MyDataRowTotalCarga("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")
                        'MyDataRowTotalPasajesPresi("Ordenar_Fisca") = 31

                    Case 26 'BASICO
                        valor_orden = 65

                        MyDataRowTotalOtros("TOTAL_COSTO") = MyDataRowTotalOtros("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalOtros("AFEC_COMI") = 0
                        MyDataRowTotalOtros("SUB_TOTAL") = MyDataRowTotalOtros("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalOtros("PORCEN") = 0
                        MyDataRowTotalOtros("MONTO_PORCEN") = MyDataRowTotalOtros("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalOtros("NRO") = MyDataRowTotalOtros("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalOtros("monto_x_comprobante") = MyDataRowTotalOtros("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalOtros("Total_por_compro") = MyDataRowTotalOtros("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        'MyDataRowTotalOtros("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        'MyDataRowTotalOtros("canti_servi") = ObjComisiones.CANTI_SERVI
                        'MyDataRowTotalOtros("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        'MyDataRowTotalOtros("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa(cnn)
                        MyDataRowTotalOtros("otros") = MyDataRowTotalOtros("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalOtros("sub_total_pagar_comi") = MyDataRowTotalOtros("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")

                    Case 20 'DEVOLUCION DE CARGO
                        valor_orden = 70

                        MyDataRowTotalOtros("TOTAL_COSTO") = MyDataRowTotalOtros("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalOtros("AFEC_COMI") = 0
                        MyDataRowTotalOtros("SUB_TOTAL") = MyDataRowTotalOtros("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalOtros("PORCEN") = 0
                        MyDataRowTotalOtros("MONTO_PORCEN") = MyDataRowTotalOtros("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalOtros("NRO") = MyDataRowTotalOtros("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalOtros("monto_x_comprobante") = MyDataRowTotalOtros("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalOtros("Total_por_compro") = MyDataRowTotalOtros("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        'MyDataRowTotalOtros("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        'MyDataRowTotalOtros("canti_servi") = ObjComisiones.CANTI_SERVI
                        'MyDataRowTotalOtros("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        'MyDataRowTotalOtros("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa(cnn)
                        MyDataRowTotalOtros("otros") = MyDataRowTotalOtros("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalOtros("sub_total_pagar_comi") = MyDataRowTotalOtros("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")

                    Case 29 'GARANTIA 10%
                        valor_orden = 75

                        MyDataRowTotalOtros("TOTAL_COSTO") = MyDataRowTotalOtros("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalOtros("AFEC_COMI") = 0
                        MyDataRowTotalOtros("SUB_TOTAL") = MyDataRowTotalOtros("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalOtros("PORCEN") = 0
                        MyDataRowTotalOtros("MONTO_PORCEN") = MyDataRowTotalOtros("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalOtros("NRO") = MyDataRowTotalOtros("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalOtros("monto_x_comprobante") = MyDataRowTotalOtros("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalOtros("Total_por_compro") = MyDataRowTotalOtros("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        'MyDataRowTotalOtros("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        'MyDataRowTotalOtros("canti_servi") = ObjComisiones.CANTI_SERVI
                        'MyDataRowTotalOtros("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        'MyDataRowTotalOtros("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa(cnn)
                        MyDataRowTotalOtros("otros") = MyDataRowTotalOtros("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalOtros("sub_total_pagar_comi") = MyDataRowTotalOtros("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")

                    Case 28 'GASTOS FIJOS
                        valor_orden = 80

                        MyDataRowTotalOtros("TOTAL_COSTO") = MyDataRowTotalOtros("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalOtros("AFEC_COMI") = 0
                        MyDataRowTotalOtros("SUB_TOTAL") = MyDataRowTotalOtros("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalOtros("PORCEN") = 0
                        MyDataRowTotalOtros("MONTO_PORCEN") = MyDataRowTotalOtros("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalOtros("NRO") = MyDataRowTotalOtros("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalOtros("monto_x_comprobante") = MyDataRowTotalOtros("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalOtros("Total_por_compro") = MyDataRowTotalOtros("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        'MyDataRowTotalOtros("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        'MyDataRowTotalOtros("canti_servi") = ObjComisiones.CANTI_SERVI
                        'MyDataRowTotalOtros("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        'MyDataRowTotalOtros("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa(cnn)
                        MyDataRowTotalOtros("otros") = MyDataRowTotalOtros("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalOtros("sub_total_pagar_comi") = MyDataRowTotalOtros("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")

                    Case 27 'PAGO DE PERSONAL
                        valor_orden = 85

                        MyDataRowTotalOtros("TOTAL_COSTO") = MyDataRowTotalOtros("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalOtros("AFEC_COMI") = 0
                        MyDataRowTotalOtros("SUB_TOTAL") = MyDataRowTotalOtros("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalOtros("PORCEN") = 0
                        MyDataRowTotalOtros("MONTO_PORCEN") = MyDataRowTotalOtros("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalOtros("NRO") = MyDataRowTotalOtros("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalOtros("monto_x_comprobante") = MyDataRowTotalOtros("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalOtros("Total_por_compro") = MyDataRowTotalOtros("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        'MyDataRowTotalOtros("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        'MyDataRowTotalOtros("canti_servi") = ObjComisiones.CANTI_SERVI
                        'MyDataRowTotalOtros("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        'MyDataRowTotalOtros("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa(cnn)
                        MyDataRowTotalOtros("otros") = MyDataRowTotalOtros("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalOtros("sub_total_pagar_comi") = MyDataRowTotalOtros("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")

                    Case 19 'REPARTO DE CARGA
                        valor_orden = 90

                        MyDataRowTotalOtros("TOTAL_COSTO") = MyDataRowTotalOtros("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalOtros("AFEC_COMI") = 0
                        MyDataRowTotalOtros("SUB_TOTAL") = MyDataRowTotalOtros("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalOtros("PORCEN") = 0
                        MyDataRowTotalOtros("MONTO_PORCEN") = MyDataRowTotalOtros("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalOtros("NRO") = MyDataRowTotalOtros("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalOtros("monto_x_comprobante") = MyDataRowTotalOtros("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalOtros("Total_por_compro") = MyDataRowTotalOtros("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        'MyDataRowTotalOtros("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        'MyDataRowTotalOtros("canti_servi") = ObjComisiones.CANTI_SERVI
                        'MyDataRowTotalOtros("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        'MyDataRowTotalOtros("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa(cnn)
                        MyDataRowTotalOtros("otros") = MyDataRowTotalOtros("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalOtros("sub_total_pagar_comi") = MyDataRowTotalOtros("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")

                    Case 33 'REINTEGRO AFECTO
                        valor_orden = 91

                        MyDataRowTotalOtros("TOTAL_COSTO") = MyDataRowTotalOtros("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotalOtros("AFEC_COMI") = 0
                        MyDataRowTotalOtros("SUB_TOTAL") = MyDataRowTotalOtros("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotalOtros("PORCEN") = 0
                        MyDataRowTotalOtros("MONTO_PORCEN") = MyDataRowTotalOtros("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotalOtros("NRO") = MyDataRowTotalOtros("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotalOtros("monto_x_comprobante") = MyDataRowTotalOtros("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotalOtros("Total_por_compro") = MyDataRowTotalOtros("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        'MyDataRowTotalOtros("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        'MyDataRowTotalOtros("canti_servi") = ObjComisiones.CANTI_SERVI
                        'MyDataRowTotalOtros("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        'MyDataRowTotalOtros("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa(cnn)
                        MyDataRowTotalOtros("otros") = MyDataRowTotalOtros("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotalOtros("sub_total_pagar_comi") = MyDataRowTotalOtros("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")


                    Case Else
                        valor_orden = 500
                End Select



                DTcomisiones.Rows(i).BeginEdit()
                DTcomisiones.Rows(i)("ordenar_fisca") = valor_orden
                DTcomisiones.Rows(i).EndEdit()

            Next

            Dim a As DataView

            'calculando para carga
            If ObjAgencias.IDTIPO_COMI_AGEN = "TIP2" Then
                ObjComisiones.ParaMontoCarga = MyDataRowTotalCarga("sub_total")
                MyDataRowTotalCarga("porcen") = ObjComisiones.f_porcen_carga()
                MyDataRowTotalCarga("MONTO_PORCEN") = MyDataRowTotalCarga("SUB_TOTAL") * ObjComisiones.PorcenCarga / 100
                MyDataRowTotalCarga("sub_total_pagar_comi") = MyDataRowTotalCarga("SUB_TOTAL") * ObjComisiones.PorcenCarga / 100
            Else
                ObjComisiones.ParaMontoCarga = MyDataRowTotalCarga("sub_total")
                MyDataRowTotalCarga("porcen") = 0
                MyDataRowTotalCarga("MONTO_PORCEN") = 0
                'MyDataRowTotalCarga("sub_total_pagar_comi") = 0
            End If

            'calculando para pasaje
            MyDataRowTotalPasajesPresi("sub_total_pagar_comi") += ObjComisiones.monto_ocupa_calcu

            DTcomisiones.Rows.Add(MyDataRowTotalOtros)
            DTcomisiones.Rows.Add(MyDataRowTotalPasa)
            DTcomisiones.Rows.Add(MyDataRowTotalPasajesPresi)
            DTcomisiones.Rows.Add(MyDataRowTotalCarga)

            For i As Integer = 0 To DTcomisiones.Rows.Count - 1
                Select Case DTcomisiones.Rows(i)("idtipo_comprobante")
                    Case 70, 71, 72, 73
                        MyDataRowTotal("TOTAL_COSTO") = MyDataRowTotal("TOTAL_COSTO") + DTcomisiones.Rows(i)("TOTAL_COSTO")
                        'MyDataRowTotal("AFEC_COMI") = 0
                        MyDataRowTotal("SUB_TOTAL") = MyDataRowTotal("SUB_TOTAL") + DTcomisiones.Rows(i)("SUB_TOTAL")
                        'MyDataRowTotal("PORCEN") = 0
                        MyDataRowTotal("MONTO_PORCEN") = MyDataRowTotal("MONTO_PORCEN") + DTcomisiones.Rows(i)("MONTO_PORCEN")
                        MyDataRowTotal("NRO") = MyDataRowTotal("NRO") + DTcomisiones.Rows(i)("NRO")
                        'MyDataRowTotal("monto_x_comprobante") = MyDataRowTotal("monto_x_comprobante") + DTcomisiones.Rows(i)("monto_x_comprobante")
                        MyDataRowTotal("Total_por_compro") = MyDataRowTotal("Total_por_compro") + DTcomisiones.Rows(i)("Total_por_compro")
                        'MyDataRowTotal("Ocupabilidad") = ObjComisiones.OCUPABILIDAD
                        'MyDataRowTotal("canti_servi") = ObjComisiones.CANTI_SERVI
                        'MyDataRowTotal("para_monto_comi_ocu") = ObjComisiones.para_monto_comi_ocu
                        MyDataRowTotal("monto_ocupa_calcu") = ObjComisiones.f_monto_ocupa()
                        MyDataRowTotal("otros") = MyDataRowTotal("otros") + DTcomisiones.Rows(i)("otros")
                        MyDataRowTotal("sub_total_pagar_comi") = MyDataRowTotal("sub_total_pagar_comi") + DTcomisiones.Rows(i)("sub_total_pagar_comi")

                End Select

            Next

            DTcomisiones.Rows.Add(MyDataRowTotal)
            'MsgBox(DTcomisiones.Rows.Count)
            DTcomisiones.Select("", "ordenar_fisca ASC")
            a = DTcomisiones.DefaultView
            a.Sort = "ordenar_fisca ASC"
            'MsgBox(DTcomisiones.Rows.Count)


            '.DataSource = DTcomisiones.DefaultView
            .DataSource = a
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With



        Dim Ordenar_Fisca As New DataGridViewTextBoxColumn
        With Ordenar_Fisca
            .HeaderText = "Ordenar_Fisca"
            .Name = "Ordenar_Fisca"
            .DataPropertyName = "Ordenar_Fisca"
            .Width = 10
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
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
            '.DefaultCellStyle.NullValue = " "
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
            .DefaultCellStyle.NullValue = " "
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
            .DefaultCellStyle.NullValue = " "
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
            .DefaultCellStyle.NullValue = " "
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
            .DefaultCellStyle.NullValue = " "
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
            .DefaultCellStyle.NullValue = " "
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
            .DefaultCellStyle.NullValue = " "
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .ReadOnly = False
            .DefaultCellStyle.Format.ToUpper()
        End With
        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL_COSTO"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = " "
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim PORCEN As New DataGridViewTextBoxColumn
        With PORCEN
            .HeaderText = "PORCEN %"
            .Name = "PORCEN"
            .DataPropertyName = "PORCEN"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = " "
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = False
        End With
        Dim MONTO_PORCEN As New DataGridViewTextBoxColumn
        With MONTO_PORCEN
            .HeaderText = "MONTO_PORCEN"
            .Name = "MONTO_PORCEN"
            .DataPropertyName = "MONTO_PORCEN"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = " "
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
            '.DefaultCellStyle.NullValue = " "
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
            '.DefaultCellStyle.NullValue = " "
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
            .DefaultCellStyle.NullValue = " "
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = False
        End With
        Dim Ocupabilidad As New DataGridViewTextBoxColumn
        With Ocupabilidad
            .HeaderText = "Ocupabilidad"
            .Name = "Ocupabilidad"
            .DataPropertyName = "Ocupabilidad"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = " "
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = False
        End With
        Dim sub_total_pagar_comi As New DataGridViewTextBoxColumn
        With sub_total_pagar_comi
            .HeaderText = "Sub Total Comisión"
            .Name = "sub_total_pagar_comi"
            .DataPropertyName = "sub_total_pagar_comi"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = " "
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
            .DefaultCellStyle.NullValue = " "
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
            .DefaultCellStyle.NullValue = " "
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = False
        End With

        Dim para_monto_comi_ocu As New DataGridViewTextBoxColumn
        With para_monto_comi_ocu
            .HeaderText = "Porcentaje Calculado por Ocupabilidad"
            .Name = "para_monto_comi_ocu"
            .DataPropertyName = "para_monto_comi_ocu"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = " "
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
            .DefaultCellStyle.NullValue = " "
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
            .DefaultCellStyle.NullValue = " "
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = False
        End With


        With DGV2
            .Columns.AddRange(IDTIPO_COMPROBANTE, TIPO_COMPROBANTE, TOTAL_COSTO, AFEC_COMI, SUB_TOTAL, PORCEN, MONTO_PORCEN, NRO, monto_x_comprobante, Total_por_compro, Ocupabilidad, canti_servi, para_monto_comi_ocu, monto_ocupa_calcu, otros, sub_total_pagar_comi, Ordenar_Fisca)
        End With
        Me.txtcomi_factu.Text = 0
        For i As Integer = 0 To DTcomisiones.Rows.Count - 1
            If DTcomisiones.Rows(i)("idtipo_comprobante") = 74 Then
                Me.txtcomi_factu.Text = FormatNumber(CDbl(Me.txtcomi_factu.Text) + CDbl(DTcomisiones.Rows(i)("sub_total_pagar_comi")), 2)
            End If
        Next

        Me.txtigv_comi_factu.Text = FormatNumber(CDbl(Me.txtcomi_factu.Text) * dtoUSUARIOS.vImpuesto, 2)
        Me.txttotal_comi_factu.Text = FormatNumber(CDbl(Me.txtcomi_factu.Text) * dtoUSUARIOS.vImpuesto + CDbl(Me.txtcomi_factu.Text), 2)

        PINTAR_TOTALES()
    End Sub

    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub Panel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub Panel6_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub tv1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tv1.AfterSelect
        FORMAT_GRILLA2()
    End Sub

    Private Sub BTNACEP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNACEP.Click
        Try
            Cursor = Cursors.AppStarting
            Select Case tc1.SelectedIndex
                Case 1
                    ObjComisiones.FECHA_INI = Me.DTPFECHAINICIO.Value.ToShortDateString
                    ObjComisiones.FECHA_FINAL = Me.DTPFECHAFINAL.Value.ToShortDateString
                    'ObjComisiones.IDAGENCIAS = Me.DGV1.CurrentRow.Cells("IDAGENCIAS").Value
                    ObjComisiones.IDAGENCIAS_STRING = ""

                    For i As Integer = 0 To Me.tv1.Nodes(0).Nodes.Count - 1
                        If Me.tv1.Nodes(0).Nodes(i).IsSelected Then
                            ObjComisiones.IDAGENCIAS = Me.tv1.Nodes(0).Nodes(i).Tag
                            ObjComisiones.IDAGENCIAS_STRING = Me.tv1.Nodes(0).Nodes(i).Tag + ";"

                            Exit For
                        End If
                    Next

                    ObjComisiones.IP = dtoUSUARIOS.IP
                    ObjComisiones.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                    ObjComisiones.IDROL_USUARIO = dtoUSUARIOS.IdRol
                    ObjComisiones.SP_IUPD_COMISIONES()

                    If ObjComisiones.IDCOMI_CALCU = Nothing Then
                        Exit Sub
                    End If

                    For I As Integer = 0 To Dt_Otros_Gastos.Rows.Count - 1
                        ObjComisiones.FECHA = Dt_Otros_Gastos.Rows(I)("FECHA")
                        ObjComisiones.SUB_TOTAL_PAGAR_COMI = Dt_Otros_Gastos.Rows(I)("VALOR")
                        ObjComisiones.TIPO_COMPROBANTE = Dt_Otros_Gastos.Rows(I)("CONCEP")
                        ObjComisiones.SP_IUPDE_AGRE_OTROS_DESCU()
                    Next

                Case 3
                    Dim comifunci As String = String.Empty

                    ObjComisiones.FECHA_INI = Me.DTPFECHAINICIO_funci.Value.ToShortDateString
                    ObjComisiones.FECHA_FINAL = Me.DTPFECHAFINAL_funci.Value.ToShortDateString

                    ObjComisiones.IDUSUARIO_FUNCI_STRING = ""

                    For i As Integer = 0 To Me.tv2.Nodes(0).Nodes.Count - 1
                        For j As Integer = 0 To tv2.Nodes(0).Nodes(i).Nodes.Count - 1
                            If tv2.Nodes(0).Nodes(i).Nodes(j).IsSelected Then
                                ObjComisiones.IDUSUARIO_PERSONAL_FUNCI = Me.tv2.Nodes(0).Nodes(i).Nodes(j).Tag

                                comifunci = Me.tv2.Nodes(0).Nodes(i).Tag
                                Exit For
                            End If
                        Next
                    Next

                    ObjComisiones.IP = dtoUSUARIOS.IP
                    ObjComisiones.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
                    ObjComisiones.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                    ObjComisiones.IDROL_USUARIO = dtoUSUARIOS.IdRol

                    'Llama al procedimiento de grabar las comisiones
                    If comifunci.Trim = "FUCA" Then
                        ObjComisiones.MetaLima = dblMetaLima
                        ObjComisiones.MetaProvincia = dblMetaProvincia

                        'Registra el encabezado de las comisiones
                        ObjComisiones.InsertCabeceraComisionCargaPasaje()
                        If ObjComisiones.EXISTE_COMISION = 0 Then
                            'Registra el detalle de la venta del funcionario
                            For iventa As Integer = 0 To dsVentaTotal.Tables(0).Rows.Count - 1
                                ObjComisiones.CONCEPTO = "VENTA"
                                ObjComisiones.NOMBRE_ORIGEN = ""
                                ObjComisiones.FORMA_PAGO = dsVentaTotal.Tables(0).Rows(iventa)("TIPO_COMPROBANTE").ToString.Trim
                                ObjComisiones.TOTAL_FORMA_PAGO = Convert.ToDouble(dsVentaTotal.Tables(0).Rows(iventa)("TOTALVENTA").ToString.Trim)

                                ObjComisiones.InsertDetalleComisionCargaPasaje()
                            Next

                            'Registra el detalle de la cobranza del funcionario
                            For icobro As Integer = 0 To dsCobranzaTotal.Tables(0).Rows.Count - 1
                                ObjComisiones.CONCEPTO = "COBRANZA"
                                ObjComisiones.NOMBRE_ORIGEN = ""
                                ObjComisiones.FORMA_PAGO = dsCobranzaTotal.Tables(0).Rows(icobro)("TIPO_COMPROBANTE").ToString.Trim
                                ObjComisiones.TOTAL_FORMA_PAGO = Convert.ToDouble(dsCobranzaTotal.Tables(0).Rows(icobro)("TOTALCOBRANZA").ToString.Trim)

                                ObjComisiones.InsertDetalleComisionCargaPasaje()
                            Next

                            'Registra el detalle de las comisiones del funcionario
                            For icomi As Integer = 0 To dsComisionTotal.Rows.Count - 1
                                ObjComisiones.IDGRUPO = Convert.ToInt32(dsComisionTotal.Rows(icomi)("IDGRUPO").ToString)
                                ObjComisiones.GRUPO = dsComisionTotal.Rows(icomi)("GRUPO").ToString
                                ObjComisiones.NOMBRE_ORIGEN = ""
                                ObjComisiones.TIPO_COBRANZA = ""
                                ObjComisiones.NombreProducto = dsComisionTotal.Rows(icomi)("PRODUCTO").ToString
                                ObjComisiones.PORCENTAJE_COMISION = Convert.ToDouble(dsComisionTotal.Rows(icomi)("PORCENTAJE").ToString.Trim)
                                ObjComisiones.TOTAL_COBRANZA = Convert.ToDouble(dsComisionTotal.Rows(icomi)("COBRANZA").ToString.Trim)
                                ObjComisiones.TOTAL_COMISION = Convert.ToDouble(dsComisionTotal.Rows(icomi)("COMISION").ToString.Trim)

                                ObjComisiones.InsertTotalComisionCargaPasaje()
                            Next
                        End If
                    ElseIf comifunci.Trim = "FUPN" Then
                        ObjComisiones.MetaLima = dblMetaLima
                        ObjComisiones.MetaProvincia = dblMetaProvincia

                        'Registra la cabecera de la comision
                        ObjComisiones.InsertCabeceraComisionCargaPasaje()

                        If ObjComisiones.EXISTE_COMISION = 0 Then
                            'Registra el detalle de la venta del funcionario
                            For iventa As Integer = 0 To dsVentaTotal.Tables(0).Rows.Count - 1
                                ObjComisiones.CONCEPTO = "VENTA"
                                ObjComisiones.NOMBRE_ORIGEN = dsVentaTotal.Tables(0).Rows(iventa)("ORIGEN").ToString.Trim
                                ObjComisiones.FORMA_PAGO = dsVentaTotal.Tables(0).Rows(iventa)("TIPOVENTA").ToString.Trim
                                ObjComisiones.TOTAL_FORMA_PAGO = Convert.ToDouble(dsVentaTotal.Tables(0).Rows(iventa)("TOTAL").ToString.Trim)

                                ObjComisiones.InsertDetalleComisionCargaPasaje()
                            Next

                            'Registra el detalle de la cobranza del funcionario
                            For icobro As Integer = 0 To dsCobranzaTotal.Tables(0).Rows.Count - 1
                                ObjComisiones.CONCEPTO = "COBRANZA"
                                ObjComisiones.NOMBRE_ORIGEN = dsCobranzaTotal.Tables(0).Rows(icobro)("ORIGEN").ToString.Trim
                                ObjComisiones.FORMA_PAGO = dsCobranzaTotal.Tables(0).Rows(icobro)("TIPOVENTA").ToString.Trim
                                ObjComisiones.TOTAL_FORMA_PAGO = Convert.ToDouble(dsCobranzaTotal.Tables(0).Rows(icobro)("TOTAL").ToString.Trim)

                                ObjComisiones.InsertDetalleComisionCargaPasaje()
                            Next

                            'Registra el detalle de las comisiones del funcionario
                            For icomi As Integer = 0 To dsComisionTotal.Rows.Count - 1
                                ObjComisiones.IDGRUPO = 0
                                ObjComisiones.GRUPO = ""
                                ObjComisiones.NOMBRE_ORIGEN = dsComisionTotal.Rows(icomi)("ORIGEN").ToString.Trim
                                ObjComisiones.TIPO_COBRANZA = dsComisionTotal.Rows(icomi)("TIPOVENTA").ToString.Trim
                                ObjComisiones.PORCENTAJE_COMISION = Convert.ToDouble(dsComisionTotal.Rows(icomi)("PORCENTAJE").ToString.Trim)
                                ObjComisiones.TOTAL_COBRANZA = Convert.ToDouble(dsComisionTotal.Rows(icomi)("TOTAL").ToString.Trim)
                                ObjComisiones.TOTAL_COMISION = Convert.ToDouble(dsComisionTotal.Rows(icomi)("COMISION").ToString.Trim)

                                ObjComisiones.InsertTotalComisionCargaPasaje()
                            Next
                        End If
                    ElseIf comifunci.Trim = "EJPA" Then
                        ObjComisiones.MetaLima = 0
                        ObjComisiones.MetaProvincia = 0

                        'Registra la cabecera de la comision
                        ObjComisiones.InsertCabeceraComisionCargaPasaje()

                        If ObjComisiones.EXISTE_COMISION = 0 Then
                            'Registra el detalle de la venta del funcionario
                            For iventa As Integer = 0 To dsVentaTotal.Tables(0).Rows.Count - 1
                                ObjComisiones.CONCEPTO = "VENTA"
                                ObjComisiones.NOMBRE_ORIGEN = dsVentaTotal.Tables(0).Rows(iventa)("ORIGEN").ToString.Trim
                                ObjComisiones.FORMA_PAGO = dsVentaTotal.Tables(0).Rows(iventa)("TIPOVENTA").ToString.Trim
                                ObjComisiones.TOTAL_FORMA_PAGO = Convert.ToDouble(dsVentaTotal.Tables(0).Rows(iventa)("TOTAL").ToString.Trim)

                                ObjComisiones.InsertDetalleComisionCargaPasaje()
                            Next

                            'Registra el detalle de la cobranza del funcionario
                            For icobro As Integer = 0 To dsCobranzaTotal.Tables(0).Rows.Count - 1
                                ObjComisiones.CONCEPTO = "COBRANZA"
                                ObjComisiones.NOMBRE_ORIGEN = dsCobranzaTotal.Tables(0).Rows(icobro)("ORIGEN").ToString.Trim
                                ObjComisiones.FORMA_PAGO = dsCobranzaTotal.Tables(0).Rows(icobro)("FUNCIONARIO").ToString.Trim
                                ObjComisiones.TOTAL_FORMA_PAGO = Convert.ToDouble(dsCobranzaTotal.Tables(0).Rows(icobro)("TOTAL").ToString.Trim)

                                ObjComisiones.InsertDetalleComisionCargaPasaje()
                            Next

                            'Registra el detalle de las comisiones del funcionario
                            For icomi As Integer = 0 To dsComisionTotal.Rows.Count - 1
                                ObjComisiones.IDGRUPO = 0
                                ObjComisiones.GRUPO = ""
                                ObjComisiones.NOMBRE_ORIGEN = dsComisionTotal.Rows(icomi)("ORIGEN").ToString.Trim
                                ObjComisiones.TIPO_COBRANZA = dsComisionTotal.Rows(icomi)("FUNCIONARIO").ToString.Trim
                                ObjComisiones.PORCENTAJE_COMISION = Convert.ToDouble(dsComisionTotal.Rows(icomi)("PORCENTAJE").ToString.Trim)
                                ObjComisiones.TOTAL_COBRANZA = Convert.ToDouble(dsComisionTotal.Rows(icomi)("TOTAL").ToString.Trim)
                                ObjComisiones.TOTAL_COMISION = Convert.ToDouble(dsComisionTotal.Rows(icomi)("COMISION").ToString.Trim)
                                ObjComisiones.InsertTotalComisionCargaPasaje()
                            Next

                        End If
                    Else
                        ObjComisiones.SP_IUPD_COMISIONES_FUNCI()
                    End If

            End Select
            'MsgBox(ObjComisiones.IDAGENCIAS_STRING)
        Catch k As Exception
            Cursor = Cursors.Default
            MsgBox(k.Message, MsgBoxStyle.Information, "Seguridad del Sistema...")
        Finally
            Cursor = Cursors.Default
            MsgBox("Proceso terminado con exito", MsgBoxStyle.Information, "Seguridad del Sistema...")
        End Try

    End Sub

    Private Sub tv2_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tv2.AfterSelect
        FORMAT_GRILLA4()
    End Sub
    Sub FORMAT_dgvconsulconce1()
        dgvconsulconce1.Columns.Clear()

        ObjComisiones.FECHA_INI = Me.DTPconsulconce1.Value.ToShortDateString
        ObjComisiones.FECHA_FINAL = Me.DTPconsulconce2.Value.ToShortDateString



        With dgvconsulconce1
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '
            .DataSource = ObjComisiones.SP_L_COMI_CONCE()
            '
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
        Dim FECHA_INI As New DataGridViewTextBoxColumn
        With FECHA_INI
            .HeaderText = "FECHA INICIAL"
            .Name = "FECHA_INI"
            .DataPropertyName = "FECHA_INI"
            .Width = 80
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

        Dim CERRADO As New DataGridViewTextBoxColumn
        With CERRADO
            .HeaderText = "¿CERRADO?"
            .Name = "CERRADO"
            .DataPropertyName = "CERRADO"
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FECHA_FINAL As New DataGridViewTextBoxColumn
        With FECHA_FINAL
            .HeaderText = "FECHA FINAL"
            .Name = "FECHA_FINAL"
            .DataPropertyName = "FECHA_FINAL"
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
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

        With dgvconsulconce1
            .Columns.AddRange(IDCOMI_CALCU, NOMBRE_AGENCIA, FECHA_REGISTRO, LOGIN, FECHA_INI, FECHA_FINAL, ESTADO_REGISTRO, IDAGENCIAS, CERRADO)

        End With
        dgvconsulconce2.DataSource = Nothing
        'Me.txtcomi_factu.Text = 0
        'For i As Integer = 0 To dvcomisiones.Count - 1
        '    Me.txtcomi_factu.Text = FormatNumber(CDbl(Me.txtcomi_factu.Text) + CDbl(dvcomisiones.Table.Rows(i)("sub_total_pagar_comi")), 2)

        'Next

        'Me.txtigv_comi_factu.Text = FormatNumber(CDbl(Me.txtcomi_factu.Text) * 0.19, 2)
        'Me.txttotal_comi_factu.Text = FormatNumber(CDbl(Me.txtcomi_factu.Text) * 0.19 + CDbl(Me.txtcomi_factu.Text), 2)
    End Sub

    Private Sub btnbuscacomiFunci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscacomiConce.Click
        FORMAT_dgvconsulconce1()

    End Sub
    Sub FORMAT_dgvconsulconce2()
        dgvconsulconce2.Columns.Clear()



        ObjComisiones.IDCOMI_CALCU = dgvconsulconce1.CurrentRow.Cells("IDCOMI_CALCU").Value
        'ObjComisiones.IDAGENCIAS = Me.DGV1.CurrentRow.Cells("IDAGENCIAS").Value
        'For i As Integer = 0 To Me.tv1.Nodes(0).Nodes.Count - 1
        '    If Me.tv1.Nodes(0).Nodes(i).IsSelected Then
        '        ObjComisiones.IDAGENCIAS = Me.tv1.Nodes(0).Nodes(i).Tag
        '        Exit For
        '    End If
        'Next

        With dgvconsulconce2
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '
            .DataSource = ObjComisiones.SP_L_COMI_CONCE_detall()
            '
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


        With dgvconsulconce2
            .Columns.AddRange(IDTIPO_COMPROBANTE, TIPO_COMPROBANTE, TOTAL_COSTO, AFEC_COMI, SUB_TOTAL, PORCEN, MONTO_PORCEN, NRO, monto_x_comprobante, Total_por_compro, Ocupabilidad, canti_servi, para_monto_comi_ocu, monto_ocupa_calcu, otros, sub_total_pagar_comi)

        End With

        Me.TxtSubTotalConsulConce.Text = 0

        For i As Integer = 0 To Me.dgvconsulconce2.Rows.Count - 1
            dgvconsulconce2.CurrentCell = Me.dgvconsulconce2.Rows(i).Cells(1)
            If (Me.dgvconsulconce2.CurrentRow.Cells("idtipo_comprobante").Value = 72 Or _
            Me.dgvconsulconce2.CurrentRow.Cells("idtipo_comprobante").Value = 70 Or _
            Me.dgvconsulconce2.CurrentRow.Cells("idtipo_comprobante").Value = 71 Or _
            Me.dgvconsulconce2.CurrentRow.Cells("idtipo_comprobante").Value = 73) Then

                Me.TxtSubTotalConsulConce.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulConce.Text) + CDbl(Me.dgvconsulconce2.CurrentRow.Cells("sub_total_pagar_comi").Value), 2)
            End If
        Next

        Me.TxtCargoConsulConce.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulConce.Text) * dtoUSUARIOS.vImpuesto, 2)
        Me.TxtTotalConsulConce.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulConce.Text) * dtoUSUARIOS.vImpuesto + CDbl(Me.TxtSubTotalConsulConce.Text), 2)

        PINTAR_TOTALES_CALCULADO()

    End Sub


    Private Sub dgvconsulconce1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvconsulconce1.CellEnter
        FORMAT_dgvconsulconce2()
    End Sub


    Private Sub btnbuscacomiFunci_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscacomiFunci.Click
        FORMAT_dgvconsulconce3()
    End Sub
    Sub FORMAT_dgvconsulconce3()

        dgvconsulFunci4.DataSource = Nothing

        dgvconsulFunci3.Columns.Clear()

        ObjComisiones.FECHA_INI = Me.DTPConsulFunci1.Value.ToShortDateString
        ObjComisiones.FECHA_FINAL = Me.DTPConsulFunci2.Value.ToShortDateString

        With dgvconsulFunci3
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = ObjComisiones.SP_L_COMI_CONCE_FUNCI()
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

        '--------------------------------------------------------------------------------------------
        '---------------Para las consulta de encabezados de las Comisiones--------------------------
        '--------------------------------------------------------------------------------------------
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

        With dgvconsulFunci3
            .Columns.AddRange(IDCOMI_CALCU_FUNCI, FUNCIONARIO, TIPO_FUNCI, NOMBRE_AGENCIA, FECHA_REGISTRO, CREADOR, FECHA_INI, FECHA_FINAL, ESTADO_REGISTRO, ID_COMI_FUNCI, CERRADO)
        End With

        Me.TxtSubTotalConsulFunci.Text = 0
        Dim iTotal As Double
        If Me.dgvconsulFunci4.Rows.Count > 0 Then
            For i As Integer = 0 To Me.dgvconsulFunci4.Rows.Count - 1
                dgvconsulFunci4.CurrentCell = Me.dgvconsulFunci4.Rows(i).Cells(1)
                If Convert.ToDateTime(Me.dgvconsulFunci3.CurrentRow.Cells("FECHA_FINAL").Value) > Convert.ToDateTime("31/12/2011") And Me.dgvconsulFunci3.CurrentRow.Cells(9).Value <> "FUAG" Then
                    Me.TxtSubTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) + Convert.ToDouble(Me.dgvconsulFunci4.CurrentRow.Cells("COMISION").Value), 2)
                ElseIf Convert.ToDateTime(Me.dgvconsulFunci3.CurrentRow.Cells("FECHA_FINAL").Value) > Convert.ToDateTime("31/12/2011") And Me.dgvconsulFunci3.CurrentRow.Cells(9).Value = "FUAG" Then
                    Me.TxtSubTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.dgvconsulFunci4.CurrentRow.Cells("TOTAL").Value), 2)
                Else
                    Me.TxtSubTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) + CDbl(Me.dgvconsulFunci4.CurrentRow.Cells("sub_total_pagar_comi").Value), 2)
                End If
            Next
            Me.TxtCargoConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto, 2)
            Me.TxtTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto + Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text), 2)
        End If
    End Sub

    Private Sub dgvconsulFunci3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvconsulFunci3.CellEnter
        FORMAT_dgvconsulFUNCI4()
    End Sub
    Sub FORMAT_dgvconsulFUNCI4()
        dgvconsulFunci4.Columns.Clear()


        ObjComisiones.IDCOMI_CALCU_FUNCI = dgvconsulFunci3.CurrentRow.Cells("IDCOMI_CALCU_FUNCI").Value
        'ObjComisiones.IDAGENCIAS = Me.DGV1.CurrentRow.Cells("IDAGENCIAS").Value
        'For i As Integer = 0 To Me.tv1.Nodes(0).Nodes.Count - 1
        '    If Me.tv1.Nodes(0).Nodes(i).IsSelected Then
        '        ObjComisiones.IDAGENCIAS = Me.tv1.Nodes(0).Nodes(i).Tag
        '        Exit For
        '    End If
        'Next

        Dim sTipo As String
        With dgvconsulFunci4
            sTipo = dgvconsulFunci3.CurrentRow.Cells("id_comi_funci").Value
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = ObjComisiones.SP_L_COMI_CONCE_detall_FUNCI(sTipo)
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        If dgvconsulFunci3.CurrentRow.Cells("ESTADO_REGISTRO").Value = "ANULADO" Then
            dgvconsulFunci4.DataSource = Nothing
        Else
            dgvconsulFunci4.DataSource = ObjComisiones.SP_L_COMI_CONCE_detall_FUNCI(sTipo)
        End If

        If sTipo = "FUAG" And Convert.ToDateTime(Me.dgvconsulFunci3.CurrentRow.Cells("FECHA_FINAL").Value) > Convert.ToDateTime("31/12/2011") Then
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
            With dgvconsulFunci4
                .Columns.AddRange(ANIO, AGENCIA, PRESIDENCIAL_CAMA, BOLETO_PRESIDENCIAL, DELIVERY, REC_CAJA_PRESIDENCIAL, REC_CAJA_PRESIDENCIAL_CAMA, TOTAL_ING, PREPAGO, ORDEN_TRABAJO, CORTESIA, PROMOCION, DEVOLUCION, TOTAL_EGR, TOTAL)
            End With

            dgvconsulFunci4.CurrentCell = Me.dgvconsulFunci4.Rows(Me.dgvconsulFunci4.RowCount - 1).Cells(1)
            Me.TxtSubTotalConsulFunci.Text = FormatNumber(CDbl(Me.dgvconsulFunci4.CurrentRow.Cells("TOTAL").Value), 2)

            'For i As Integer = 0 To Me.dgvconsulFunci4.Rows.Count - 1
            '    dgvconsulFunci4.CurrentCell = Me.dgvconsulFunci4.Rows(i).Cells(1)
            '    Me.TxtSubTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) + CDbl(Me.dgvconsulFunci4.CurrentRow.Cells("COMISION").Value), 2)
            'Next

            Me.TxtCargoConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto, 2)
            Me.TxtTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto + CDbl(Me.TxtSubTotalConsulFunci.Text), 2)

            For j As Integer = 0 To Me.dgvconsulFunci4.RowCount - 1
                If dgvconsulFunci4.Rows(j).Cells("ANIO").Value = 0 Then
                    dgvconsulFunci4.Rows(j).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 179)
                    dgvconsulFunci4.Rows(j).DefaultCellStyle.ForeColor = Color.Black
                    dgvconsulFunci4.Rows(j).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
                End If
            Next

        ElseIf sTipo = "FUCA" Or sTipo = "FUCC" And Convert.ToDateTime(Me.dgvconsulFunci3.CurrentRow.Cells("FECHA_FINAL").Value) > Convert.ToDateTime("31/12/2011") Then
            '----------------------------------------------------------------------
            'Para el DataGrid de Comisiones de los funcionarios de carga
            '----------------------------------------------------------------------
            Dim col_Producto As New DataGridViewTextBoxColumn
            With col_Producto
                .HeaderText = "PRODUCTO"
                .Name = "PRODUCTO"
                .DataPropertyName = "PRODUCTO"
                .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

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

            With dgvconsulFunci4
                .Columns.AddRange(col_Producto, IDGRUPO, GRUPO, PORCENTAJE, COBRANZA, COMISION)
            End With

            Me.TxtSubTotalConsulFunci.Text = 0
            For i As Integer = 0 To Me.dgvconsulFunci4.Rows.Count - 1
                dgvconsulFunci4.CurrentCell = Me.dgvconsulFunci4.Rows(i).Cells(1)
                Me.TxtSubTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) + Convert.ToDouble(Me.dgvconsulFunci4.CurrentRow.Cells("COMISION").Value), 2)
            Next

            Me.TxtCargoConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto, 2)
            Me.TxtTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto + Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text), 2)


        ElseIf sTipo = "FUPN" And Convert.ToDateTime(Me.dgvconsulFunci3.CurrentRow.Cells("FECHA_FINAL").Value) > Convert.ToDateTime("31/12/2011") Then

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

            With dgvconsulFunci4
                .Columns.AddRange(CIUDAD_COMI, TIPO_COMI, PORCENTAJE_PASAJE, TOTAL_COMI_PASAJE, COMISION)
            End With

            Me.TxtSubTotalConsulFunci.Text = 0
            For i As Integer = 0 To Me.dgvconsulFunci4.Rows.Count - 1
                dgvconsulFunci4.CurrentCell = Me.dgvconsulFunci4.Rows(i).Cells(1)
                Me.TxtSubTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) + Convert.ToDouble(Me.dgvconsulFunci4.CurrentRow.Cells("COMISION").Value), 2)
            Next

            Me.TxtCargoConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto, 2)
            Me.TxtTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto + Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text), 2)

        ElseIf sTipo = "EJPA" And Convert.ToDateTime(Me.dgvconsulFunci3.CurrentRow.Cells("FECHA_FINAL").Value) > Convert.ToDateTime("31/12/2011") Then

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

            With dgvconsulFunci4
                .Columns.AddRange(CIUDAD_COMI, TIPO_COMI, PORCENTAJE_PASAJE, TOTAL_COMI_PASAJE, COMISION)
            End With

            Me.TxtSubTotalConsulFunci.Text = 0
            For i As Integer = 0 To Me.dgvconsulFunci4.Rows.Count - 1
                dgvconsulFunci4.CurrentCell = Me.dgvconsulFunci4.Rows(i).Cells(1)
                Me.TxtSubTotalConsulFunci.Text = FormatNumber(Convert.ToDouble(Me.TxtSubTotalConsulFunci.Text) + Convert.ToDouble(Me.dgvconsulFunci4.CurrentRow.Cells("COMISION").Value), 2)
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


            With dgvconsulFunci4
                .Columns.AddRange(IDTIPO_COMPROBANTE, TIPO_COMPROBANTE, TOTAL_COSTO, AFEC_COMI, SUB_TOTAL, PORCEN, MONTO_PORCEN, NRO, monto_x_comprobante, Total_por_compro, para_monto_comi_ocu, monto_ocupa_calcu, otros, sub_total_pagar_comi)
            End With

            Me.TxtSubTotalConsulFunci.Text = 0
            For i As Integer = 0 To Me.dgvconsulFunci4.Rows.Count - 1
                dgvconsulFunci4.CurrentCell = Me.dgvconsulFunci4.Rows(i).Cells(1)
                Me.TxtSubTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) + CDbl(Me.dgvconsulFunci4.CurrentRow.Cells("sub_total_pagar_comi").Value), 2)
            Next

            Me.TxtCargoConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto, 2)
            Me.TxtTotalConsulFunci.Text = FormatNumber(CDbl(Me.TxtSubTotalConsulFunci.Text) * dtoUSUARIOS.vImpuesto + CDbl(Me.TxtSubTotalConsulFunci.Text), 2)
        End If

    End Sub

    Private Sub BtnEliComiConce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliComiConce.Click
        Try

            If Not dgvconsulconce1.CurrentRow.Cells("CERRADO").Value = "SI" Then
                ObjComisiones.IDCOMI_CALCU = dgvconsulconce1.CurrentRow.Cells("IDCOMI_CALCU").Value
                If MsgBox("Seguro que desea anular este calculo de comsión...?", MsgBoxStyle.YesNo, "Seguridad del Sistema...") = MsgBoxResult.Yes Then
                    '
                    ObjComisiones.SP_ANU_COMI_CONCE()
                    FORMAT_dgvconsulconce1()
                End If
            Else
                MsgBox("No se puede ANULAR el registro ya esta cerrada...", MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
        End Try

    End Sub

    Private Sub BtnAnuComiFunci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnuComiFunci.Click
        Try
            If dgvconsulFunci3.Rows.Count > 0 Then
                If Not dgvconsulFunci3.CurrentRow.Cells("CERRADO").Value = "SI" Then
                    ObjComisiones.IDCOMI_CALCU_FUNCI = dgvconsulFunci3.CurrentRow.Cells("IDCOMI_CALCU_FUNCI").Value
                    If MsgBox("Seguro que desea anular este calculo de comsión...?", MsgBoxStyle.YesNo, "Seguridad del Sistema...") = MsgBoxResult.Yes Then
                        '
                        ObjComisiones.SP_ANU_COMI_FUNCI()
                        FORMAT_dgvconsulconce3()
                    End If
                Else
                    MsgBox("No se puede ANULAR el registro ya esta cerrada...", MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
                End If
            Else
                MsgBox("No existen datos registrados para la anulación de comisión...", MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
            End If
            
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
        End Try
    End Sub

    Private Sub BtnImpriFunci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpriFunci.Click

        Try
            ObjReport.Dispose()
        Catch

        End Try

        ObjReport = New ClsLbTepsa.dtoFrmReport
        Try

            ObjComisiones.IDCOMI_CALCU_FUNCI = dgvconsulFunci3.CurrentRow.Cells("IDCOMI_CALCU_FUNCI").Value

            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            If rbdeta_funci.Checked = True Then
                ObjReport.printrpt(False, "", "CC001.RPT", "p_IDCOMI_CALCU_FUNCI;" & ObjComisiones.IDCOMI_CALCU_FUNCI)

            ElseIf RBResumen2012.Checked = True Then
                'Dim dsReporteResumen2012 As DataSet
                'ObjComisiones.FECHA_INI = Me.DTPConsulFunci1.Value.ToShortDateString
                'ObjComisiones.FECHA_FINAL = Me.DTPConsulFunci2.Value.ToShortDateString

                'dsReporteResumen2012 = ObjComisiones.ReporteTotalComisiones
                'If Not IsNothing(dsReporteResumen2012) Then
                '    If dsReporteResumen2012.Tables(0).Rows.Count > 0 Then
                '        ObjReport.CrearXML(dsReporteResumen2012, "CC009_1.Xml")
                '    End If

                'End If
                ObjReport.printrpt(False, "", "rptComisiones_Funcionarios.rpt", "p_fecha_ini;" & DTPConsulFunci1.Value.ToShortDateString, "p_fecha_final;" & DTPConsulFunci2.Value.ToShortDateString)
            ElseIf RBResuFunci.Checked = True Then
                ObjReport.printrpt(False, "", "CC009.RPT", "p_fecha_ini;" & DTPConsulFunci1.Value.ToShortDateString, "p_fecha_final;" & DTPConsulFunci2.Value.ToShortDateString)

            End If

        Catch
        End Try
    End Sub

    Private Sub BtnImpriConce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpriConce.Click

        Try
            ObjReport.Dispose()
        Catch

        End Try

        ObjReport = New ClsLbTepsa.dtoFrmReport
        Try
            ObjAgencias.IDAGENCIAS = dgvconsulconce1.CurrentRow.Cells("IDAGENCIAS").Value
            'Datahelper
            ObjAgencias.SP_SELEC_AGENCIA()
            '
            ObjComisiones.IDCOMI_CALCU = dgvconsulconce1.CurrentRow.Cells("IDCOMI_CALCU").Value

            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)

            If rbdeta_conce.Checked = True Then

                If ObjAgencias.IDTIPO_COMI_AGEN = "TIP2" Then
                    ObjReport.printrpt(False, "", "CC002.RPT", _
                    "p_IDCOMI_CALCU;" & ObjComisiones.IDCOMI_CALCU)
                Else
                    ObjReport.printrpt(False, "", "CC004.RPT", _
                                        "p_IDCOMI_CALCU;" & ObjComisiones.IDCOMI_CALCU)

                End If
            ElseIf Me.RBResuTipoI.Checked = True Then
                ObjReport.printrpt(False, "", "CC006.RPT", _
                                    "p_FECHA_INI;" & Me.DTPconsulconce1.Value.ToShortDateString, _
                                    "p_FECHA_FINAL;" & Me.DTPconsulconce2.Value.ToShortDateString, _
                                    "p_RANGO_FECHA;" & "(DEL " & Me.DTPconsulconce1.Value.ToShortDateString & " AL " & Me.DTPconsulconce2.Value.ToShortDateString & ")")
            ElseIf Me.RBResuTipoII.Checked = True Then
                ObjReport.printrpt(False, "", "CC005.RPT", _
                                    "p_FECHA_INI;" & Me.DTPconsulconce1.Value.ToShortDateString, _
                                    "p_FECHA_FINAL;" & Me.DTPconsulconce2.Value.ToShortDateString, _
                                    "p_RANGO_FECHA;" & "(DEL " & Me.DTPconsulconce1.Value.ToShortDateString & " AL " & Me.DTPconsulconce2.Value.ToShortDateString & ")")
            End If

        Catch
        End Try
    End Sub

    Private Sub DGV2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellEnter



        ObjComisiones.IDTIPO_COMPROBANTE = DGV2.CurrentRow.Cells("idtipo_comprobante").Value
        If IsDBNull(DGV2.CurrentRow.Cells("AFEC_COMI").Value) Then
            ObjComisiones.AFEC_COMI = 0
            DGV2.CurrentRow.Cells("AFEC_COMI").Value = "NO"
        End If
        ObjComisiones.AFEC_COMI = IIf(DGV2.CurrentRow.Cells("AFEC_COMI").Value = "SI", 1, 0)

        If DGV2.CurrentRow.Cells("PORCEN").Value.ToString.Trim = "" Then
            DGV2.CurrentRow.Cells("PORCEN").Value = "0.00"
            ObjComisiones.PORCEN = 0
            Exit Sub
        End If
        If DGV2.CurrentRow.Cells("PORCEN").Value.ToString.Trim = "0" Then
            DGV2.CurrentRow.Cells("PORCEN").Value = "0.00"
            ObjComisiones.PORCEN = 0
            Exit Sub
        End If
        'MsgBox(DGV2.CurrentRow.Cells("PORCEN").Value.ToString.Trim)
        ObjComisiones.PORCEN = CDbl(DGV2.CurrentRow.Cells("PORCEN").Value.ToString.Trim)
        ObjComisiones.MONTO_X_COMPROBANTE = DGV2.CurrentRow.Cells("MONTO_X_COMPROBANTE").Value
        ObjComisiones.OCUPABILIDAD = DGV2.CurrentRow.Cells("OCUPABILIDAD").Value
        ObjComisiones.CANTI_SERVI = DGV2.CurrentRow.Cells("CANTI_SERVI").Value
        ObjComisiones.OTROS = DGV2.CurrentRow.Cells("OTROS").Value

    End Sub

    Private Sub DGV2_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellValidated

        ObjComisiones.IDTIPO_COMPROBANTE = DGV2.CurrentRow.Cells("idtipo_comprobante").Value
        If Not (UCase(DGV2.CurrentRow.Cells("AFEC_COMI").Value) = "SI" Or UCase(DGV2.CurrentRow.Cells("AFEC_COMI").Value) = "NO") Then
            DGV2.CurrentRow.Cells("AFEC_COMI").Value = IIf(ObjComisiones.AFEC_COMI = 1, "SI", "NO")
            Exit Sub
        End If
        If IsDBNull(DGV2.CurrentRow.Cells("PORCEN").Value) Then
            DGV2.CurrentRow.Cells("PORCEN").Value = "0.00"
            ObjComisiones.PORCEN = 0
            Exit Sub
        End If
        If Not IsNumeric(DGV2.CurrentRow.Cells("PORCEN").Value.ToString.Trim) Then
            DGV2.CurrentRow.Cells("PORCEN").Value = "0.00"
            ObjComisiones.PORCEN = 0
            Exit Sub
        End If


        DGV2.CurrentRow.Cells("PORCEN").Value = DGV2.CurrentRow.Cells("PORCEN").Value.ToString.Trim
        ObjComisiones.PORCEN = DGV2.CurrentRow.Cells("PORCEN").Value.ToString.Trim
        ObjComisiones.AFEC_COMI = IIf(DGV2.CurrentRow.Cells("AFEC_COMI").Value = "SI", 1, 0)
        ObjComisiones.MONTO_X_COMPROBANTE = DGV2.CurrentRow.Cells("MONTO_X_COMPROBANTE").Value
        ObjComisiones.OCUPABILIDAD = DGV2.CurrentRow.Cells("OCUPABILIDAD").Value
        ObjComisiones.CANTI_SERVI = DGV2.CurrentRow.Cells("CANTI_SERVI").Value
        ObjComisiones.OTROS = DGV2.CurrentRow.Cells("OTROS").Value

    End Sub

    Private Sub BtnActu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActu.Click
        Dim fila, columna As Integer
        If DGV2.RowCount <= 0 Then Exit Sub
        fila = DGV2.CurrentCell.RowIndex
        columna = DGV2.CurrentCell.ColumnIndex
        For i As Integer = 0 To DGV2.RowCount - 1
            DGV2.CurrentCell = DGV2.Rows(i).Cells(1)

            ObjComisiones.IDTIPO_COMPROBANTE = DGV2.CurrentRow.Cells("idtipo_comprobante").Value
            ObjComisiones.PORCEN = DGV2.CurrentRow.Cells("PORCEN").Value
            ObjComisiones.AFEC_COMI = IIf(UCase(DGV2.CurrentRow.Cells("AFEC_COMI").Value.ToString.Trim) = "SI", 1, 0)
            ObjComisiones.MONTO_X_COMPROBANTE = DGV2.CurrentRow.Cells("MONTO_X_COMPROBANTE").Value
            ObjComisiones.OCUPABILIDAD = DGV2.CurrentRow.Cells("OCUPABILIDAD").Value
            ObjComisiones.CANTI_SERVI = DGV2.CurrentRow.Cells("CANTI_SERVI").Value
            ObjComisiones.OTROS = DGV2.CurrentRow.Cells("OTROS").Value

            ObjComisiones.sp_up_TIPO_COMPRO_AGEN()

        Next
        FORMAT_GRILLA2()
        DGV2.Focus()
        DGV2.CurrentCell = DGV2.Rows(fila).Cells(columna)

    End Sub

    Sub PINTAR_TOTALES_CALCULADO()
        For I As Integer = 0 To dgvconsulconce2.RowCount - 1

            dgvconsulconce2.CurrentCell = dgvconsulconce2.Rows(I).Cells(1)

            If (dgvconsulconce2.CurrentRow.Cells("IDTIPO_COMPROBANTE").Value = 70 Or _
            dgvconsulconce2.CurrentRow.Cells("IDTIPO_COMPROBANTE").Value = 71 Or _
            dgvconsulconce2.CurrentRow.Cells("IDTIPO_COMPROBANTE").Value = 72 Or _
            dgvconsulconce2.CurrentRow.Cells("IDTIPO_COMPROBANTE").Value = 73) Then
                dgvconsulconce2.Rows(I).DefaultCellStyle.BackColor = Color.Yellow
            End If

            If (dgvconsulconce2.CurrentRow.Cells("IDTIPO_COMPROBANTE").Value = 74) Then

                dgvconsulconce2.Rows(I).DefaultCellStyle.BackColor = Color.LimeGreen
            End If

            dgvconsulconce2.Columns("sub_total").DefaultCellStyle.ForeColor = Color.Red
            dgvconsulconce2.Columns("total_costo").DefaultCellStyle.ForeColor = Color.Red
            dgvconsulconce2.Columns("monto_porcen").DefaultCellStyle.ForeColor = Color.Red
            dgvconsulconce2.Columns("total_por_compro").DefaultCellStyle.ForeColor = Color.Red
            dgvconsulconce2.Columns("monto_ocupa_calcu").DefaultCellStyle.ForeColor = Color.Red
            dgvconsulconce2.Columns("otros").DefaultCellStyle.ForeColor = Color.Red
            dgvconsulconce2.Columns("sub_total_pagar_comi").DefaultCellStyle.ForeColor = Color.Red


        Next
    End Sub

    Sub PINTAR_TOTALES()
        For I As Integer = 0 To DGV2.RowCount - 1

            DGV2.CurrentCell = DGV2.Rows(I).Cells(1)

            If (DGV2.CurrentRow.Cells("IDTIPO_COMPROBANTE").Value = 70 Or _
            DGV2.CurrentRow.Cells("IDTIPO_COMPROBANTE").Value = 71 Or _
            DGV2.CurrentRow.Cells("IDTIPO_COMPROBANTE").Value = 72 Or _
            DGV2.CurrentRow.Cells("IDTIPO_COMPROBANTE").Value = 73) Then
                DGV2.Rows(I).DefaultCellStyle.BackColor = Color.Yellow
            End If

            If (DGV2.CurrentRow.Cells("IDTIPO_COMPROBANTE").Value = 74) Then

                DGV2.Rows(I).DefaultCellStyle.BackColor = Color.LimeGreen
            End If

            DGV2.Columns("sub_total").DefaultCellStyle.ForeColor = Color.Red
            DGV2.Columns("total_costo").DefaultCellStyle.ForeColor = Color.Red
            DGV2.Columns("monto_porcen").DefaultCellStyle.ForeColor = Color.Red
            DGV2.Columns("total_por_compro").DefaultCellStyle.ForeColor = Color.Red
            DGV2.Columns("monto_ocupa_calcu").DefaultCellStyle.ForeColor = Color.Red
            DGV2.Columns("otros").DefaultCellStyle.ForeColor = Color.Red
            DGV2.Columns("sub_total_pagar_comi").DefaultCellStyle.ForeColor = Color.Red


        Next
    End Sub

    Private Sub BtnActuFunci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActuFunci.Click
        Dim fila, columna As Integer
        fila = DGV4.CurrentCell.RowIndex
        columna = DGV4.CurrentCell.ColumnIndex
        'Dim m_iditipo_comprobante() As Integer, maximo_indice_matris As Integer, encontrado As Boolean

        'maximo_indice_matris = 0

        'For i As Integer = 0 To DGV4.RowCount - 1
        '    DGV4.Rows(i).Selected = True
        '    DGV4.CurrentCell = DGV4.Rows(i).Cells(1)
        '    For j As Integer = 0 To maximo_indice_matris

        '    Next

        '    If encontrado = False Then
        '        m_iditipo_comprobante(indice_matris) = DGV4.CurrentRow.Cells("idtipo_comprobante").Value
        '        maximo_indice_matris()
        '    End If


        'Next

        For i As Integer = 0 To DGV4.RowCount - 1
            DGV4.Rows(i).Selected = True
            DGV4.CurrentCell = DGV4.Rows(i).Cells(1)

            ObjComisiones.IDTIPO_COMPROBANTE = DGV4.CurrentRow.Cells("idtipo_comprobante").Value
            ObjComisiones.TIPO_COMPROBANTE = DGV4.CurrentRow.Cells("tipo_comprobante").Value
            ObjComisiones.PORCEN = DGV4.CurrentRow.Cells("PORCEN").Value
            ObjComisiones.AFEC_COMI = IIf(UCase(DGV4.CurrentRow.Cells("AFEC_COMI").Value.ToString.Trim) = "SI", 1, 0)
            ObjComisiones.MONTO_X_COMPROBANTE = DGV4.CurrentRow.Cells("MONTO_X_COMPROBANTE").Value
            ObjComisiones.OTROS = DGV4.CurrentRow.Cells("OTROS").Value
            '
            ObjComisiones.sp_up_TIPO_COMPRO_FUNCI()

        Next
        'FORMAT_GRILLA4()
        DGV4.Focus()
        DGV4.CurrentCell = DGV4.Rows(fila).Cells(columna)

    End Sub

    Private Sub DGV4_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV4.CellEnter


        'ObjComisiones.IDTIPO_COMPROBANTE = DGV4.CurrentRow.Cells("idtipo_comprobante").Value
        'If IsDBNull(DGV4.CurrentRow.Cells("AFEC_COMI").Value) Then
        '    ObjComisiones.AFEC_COMI = 0
        '    DGV4.CurrentRow.Cells("AFEC_COMI").Value = "NO"
        'End If
        'ObjComisiones.AFEC_COMI = IIf(DGV4.CurrentRow.Cells("AFEC_COMI").Value = "SI", 1, 0)

        'If IsDBNull(DGV4.CurrentRow.Cells("PORCEN").Value) = Nothing Then
        '    DGV4.CurrentRow.Cells("PORCEN").Value = "0.00"
        '    ObjComisiones.PORCEN = 0
        '    Exit Sub
        'End If

        'If DGV4.CurrentRow.Cells("PORCEN").Value.ToString.Trim = "" Then
        '    DGV4.CurrentRow.Cells("PORCEN").Value = "0.00"
        '    ObjComisiones.PORCEN = 0
        '    Exit Sub
        'End If
        'If DGV4.CurrentRow.Cells("PORCEN").Value.ToString.Trim = "0" Then
        '    DGV4.CurrentRow.Cells("PORCEN").Value = "0.00"
        '    ObjComisiones.PORCEN = 0
        '    Exit Sub
        'End If
        ''MsgBox(DGV2.CurrentRow.Cells("PORCEN").Value.ToString.Trim)
        'ObjComisiones.PORCEN = CDbl(DGV4.CurrentRow.Cells("PORCEN").Value.ToString.Trim)
        'ObjComisiones.MONTO_X_COMPROBANTE = DGV4.CurrentRow.Cells("MONTO_X_COMPROBANTE").Value


        'ObjComisiones.OTROS = DGV4.CurrentRow.Cells("OTROS").Value
    End Sub

    Private Sub DGV4_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV4.CellValidated

        'ObjComisiones.IDTIPO_COMPROBANTE = DGV4.CurrentRow.Cells("idtipo_comprobante").Value
        'If Not (UCase(DGV4.CurrentRow.Cells("AFEC_COMI").Value) = "SI" Or UCase(DGV4.CurrentRow.Cells("AFEC_COMI").Value) = "NO") Then
        '    DGV4.CurrentRow.Cells("AFEC_COMI").Value = IIf(ObjComisiones.AFEC_COMI = 1, "SI", "NO")
        '    Exit Sub
        'End If
        'If IsDBNull(DGV4.CurrentRow.Cells("PORCEN").Value) Then
        '    DGV4.CurrentRow.Cells("PORCEN").Value = "0.00"
        '    ObjComisiones.PORCEN = 0
        '    Exit Sub
        'End If
        'If Not IsNumeric(DGV4.CurrentRow.Cells("PORCEN").Value.ToString.Trim) Then
        '    DGV4.CurrentRow.Cells("PORCEN").Value = "0.00"
        '    ObjComisiones.PORCEN = 0
        '    Exit Sub
        'End If

        'DGV4.CurrentRow.Cells("PORCEN").Value = DGV4.CurrentRow.Cells("PORCEN").Value.ToString.Trim
        'ObjComisiones.PORCEN = DGV4.CurrentRow.Cells("PORCEN").Value.ToString.Trim
        'ObjComisiones.AFEC_COMI = IIf(DGV4.CurrentRow.Cells("AFEC_COMI").Value = "SI", 1, 0)
        'ObjComisiones.MONTO_X_COMPROBANTE = DGV4.CurrentRow.Cells("MONTO_X_COMPROBANTE").Value
        'ObjComisiones.OTROS = DGV4.CurrentRow.Cells("OTROS").Value
    End Sub

    Private Sub Panel6_Paint_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel6.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub BtnOtrosGastos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOtrosGastos.Click
        Dim frm As New FrmAgreDescu
        'frm.ShowDialog(Me)

        Acceso.Asignar(frm, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            frm.ShowDialog(Me)
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub DTPFECHAFINAL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAFINAL.GotFocus, DTPFECHAINICIO.GotFocus
        DGV2.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINAL_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINAL.ValueChanged

    End Sub

    Private Sub DTPFECHAFINAL_funci_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAFINAL_funci.GotFocus, DTPFECHAINICIO_funci.GotFocus
        DGV4.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINAL_funci_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINAL_funci.ValueChanged
        'hlamas 06-01-2014
        Llenar_Funcionarios()
    End Sub

    Private Sub tv1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tv1.GotFocus
        FORMAT_GRILLA2()
    End Sub

    Private Sub tv2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tv2.GotFocus
        'FORMAT_GRILLA4()
    End Sub

    Private Sub tc1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tc1.Click
        'If fnValidar_Rol("27") = True Then
        'bloque
        If Acceso.SiRol(G_Rol, Me, 3) Then
            Select Case tc1.SelectedIndex
                Case 2, 3
                    Me.tc1.SelectedIndex = 0
            End Select
        End If
        'If fnValidar_Rol("30") = True Then
        'bloque
        If Acceso.SiRol(G_Rol, Me, 4) Then
            Select Case tc1.SelectedIndex
                Case 0, 1
                    Me.tc1.SelectedIndex = 2
            End Select
        End If
    End Sub

    Private Sub BtnCerrarCalcuFunci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarCalcuFunci.Click


        If MsgBox("Cerrado el calculo de comision no podra realizar modificaciones a los registros ya considerados. ¿Seguro que desea realizar el cierre?...", MsgBoxStyle.YesNo, "Seguridad del Sistema..") = MsgBoxResult.Yes Then
            Try
                ObjComisiones.FECHA_INI = DTPConsulFunci1.Value.ToShortDateString
                ObjComisiones.FECHA_FINAL = DTPConsulFunci2.Value.ToShortDateString
                '
                ObjComisiones.sp_cierre_comi_funci()

            Catch k As Exception
                MsgBox("Error de proceso", MsgBoxStyle.Information, "Seguridad del Sistema...")
            Finally
                MsgBox("Proceso terminado con exito", MsgBoxStyle.Information, "Seguridad del Sistema...")
            End Try
        End If



    End Sub

    Private Sub BtnCerrarCalcuConce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarCalcuConce.Click

        If MsgBox("Cerrado el calculo de comision no podra realizar modificaciones a los registros ya considerados. ¿Seguro que desea realizar el cierre?...", MsgBoxStyle.YesNo, "Seguridad del Sistema..") = MsgBoxResult.Yes Then
            Try
                ObjComisiones.FECHA_INI = DTPconsulconce1.Value.ToShortDateString
                ObjComisiones.FECHA_FINAL = DTPconsulconce2.Value.ToShortDateString
                '
                ObjComisiones.sp_cierre_comi()

            Catch k As Exception
                MsgBox("Error de proceso: " + k.ToString, MsgBoxStyle.Information, "Seguridad del Sistema...")
            Finally
                MsgBox("Proceso terminado con exito", MsgBoxStyle.Information, "Seguridad del Sistema...")
            End Try
        End If

    End Sub

    Private Sub Panel5_Paint_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel5.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub


    Dim dtTempcomisiones_funci As DataTable
    Dim PresidencialCama1 As Double = 0
    Dim BOLETO_PRESIDENCIAL1 As Double = 0
    Dim BOLETO_TEPSA_SUITE As Double = 0
    Dim DELIVERY1 As Double = 0
    Dim RC_PRESIDENCIAL As Double = 0
    Dim RC_PRESIDENCIAL_CAMA As Double = 0
    Dim RC_TEPSA_SUITE As Double = 0
    Dim PREPAGO1 As Double = 0
    Dim ORDEN_TRABAJO1 As Double = 0
    Dim CORTESIA1 As Double = 0
    Dim PROMOCION1 As Double = 0
    Dim DEVOLUCION1 As Double = 0


    Sub FORMAT_GRILLA4()
        Try
            Cursor = Cursors.AppStarting

            Dim comifunci As String = String.Empty
            'lblMetaProvincia.Visible = False
            'lblDatoMetaProvincia.Visible = False
            'lblTotalventaProvincia.Visible = False
            'lblDatoTotalVentaProvincia.Visible = False
            'lblCobranzaProvincia.Visible = False
            'lblDatoTotalCobranzaProvincia.Visible = False
            'lblPorcentajeProvincia.Visible = False
            'lblDatoPorcentajeProvincia.Visible = False
            'lblBonoProvincia.Visible = False
            'lblDatoBonoProvincia.Visible = False

            lblMeta.Text = "Meta TC:"
            lblTotalventa.Text = "Tot. Venta TC:"
            lblCobranza.Text = "Tot. Cobranza:"
            lblPorcentaje.Text = "Porcentaje TC (%):"
            lblBono.Text = "Bono:"
            'lblDatoMeta.Location = New Point(67, 4)
            'lblDatoTotalVenta.Location = New Point(225, 4)
            'lblDatoTotalCobranza.Location = New Point(210, 4)
            'lblDatoPorcentaje.Location = New Point(120, 240)
            'lblDatoBono.Location = New Point(245, 240)


            DGV4.Columns.Clear()
            ObjComisiones.FECHA_INI = Me.DTPFECHAINICIO_funci.Value.ToShortDateString
            ObjComisiones.FECHA_FINAL = Me.DTPFECHAFINAL_funci.Value.ToShortDateString

            If DateDiff(DateInterval.Month, Me.DTPFECHAINICIO_funci.Value.Date, Me.DTPFECHAFINAL_funci.Value.Date) <> 1 Then
                MsgBox("Las fechas seleccionadas para el cálculo de las comisiones no son correctas", MsgBoxStyle.Information, "Seguridad del Sistema...")
                DGV4.Columns.Clear()
                dgdCobranza.Columns.Clear()
                dgdComision.Columns.Clear()
                dgdPorcentaje.Columns.Clear()
                Return
            End If

            'ObjComisiones.IDAGENCIAS = Me.DGV1.CurrentRow.Cells("IDAGENCIAS").Value

            For i As Integer = 0 To Me.tv2.Nodes(0).Nodes.Count - 1
                For j As Integer = 0 To tv2.Nodes(0).Nodes(i).Nodes.Count - 1
                    If tv2.Nodes(0).Nodes(i).Nodes(j).IsSelected Then
                        ObjComisiones.IDUSUARIO_PERSONAL_FUNCI = Me.tv2.Nodes(0).Nodes(i).Nodes(j).Tag '.ToString.Substring(0, Me.tv2.Nodes(0).Nodes(i).Nodes(j).Tag.ToString.Length - 1)

                        Label2.Text = Me.tv2.Nodes(0).Nodes(i).Nodes(j).Tag + " " + Me.tv2.Nodes(0).Nodes(i).Nodes(j).Text
                        comifunci = Me.tv2.Nodes(0).Nodes(i).Tag
                        Exit For
                    End If

                Next
            Next

            Dim iOpcion As Integer = 1
            If comifunci.Trim = "FUAG" Then
                iOpcion = 0
            End If

            If iOpcion = 0 Then
                dScomisiones_funci = ObjComisiones.SP_L_SERVICIOS_FUNCI_MONTO()

                '---Calculo Señora Silvana---
                Dim año As String
                Dim total1, total2, total3 As Double
                Dim i As Integer
                PresidencialCama1 = 0
                BOLETO_PRESIDENCIAL1 = 0
                BOLETO_TEPSA_SUITE = 0
                DELIVERY1 = 0
                RC_PRESIDENCIAL = 0
                RC_PRESIDENCIAL_CAMA = 0
                RC_TEPSA_SUITE = 0
                DELIVERY1 = 0
                PREPAGO1 = 0
                ORDEN_TRABAJO1 = 0
                CORTESIA1 = 0
                PROMOCION1 = 0
                DEVOLUCION1 = 0
                total1 = 0
                total2 = 0
                Dim dr As DataRow
                For Each row As DataRow In dScomisiones_funci.Rows
                    If i = 0 Then año = row.Item("ANIO")
                    If row.Item("ANIO") = año Then
                        PresidencialCama1 += row.Item("PRESIDENCIAL_CAMA")
                        BOLETO_PRESIDENCIAL1 += row.Item("BOLETO_PRESIDENCIAL")
                        BOLETO_TEPSA_SUITE += row.Item("BOLETO_TEPSA_SUITE")
                        DELIVERY1 += row.Item("DELIVERY")
                        RC_PRESIDENCIAL += row.Item("R.C. PRESIDENCIAL")
                        RC_PRESIDENCIAL_CAMA += row.Item("R.C. PRESIDENCIAL CAMA")
                        RC_TEPSA_SUITE += row.Item("R.C. SUITE")
                        PREPAGO1 += row.Item("PREPAGO")
                        ORDEN_TRABAJO1 += row.Item("ORDEN_TRABAJO")
                        CORTESIA1 += row.Item("CORTESIA")
                        PROMOCION1 += row.Item("PROMOCION")
                        DEVOLUCION1 += row.Item("DEVOLUCION")

                        If i = 0 Then
                            dtTempcomisiones_funci = New DataTable
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("ANIO", GetType(String)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("AGENCIA", GetType(String)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("ID_AGENCIA", GetType(String)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("PRESIDENCIAL_CAMA", GetType(Double)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("BOLETO_PRESIDENCIAL", GetType(Double)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("BOLETO_TEPSA_SUITE", GetType(Double)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("DELIVERY", GetType(Double)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("RCPRESIDENCIAL", GetType(Double)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("RCPRESIDENCIALCAMA", GetType(Double)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("RC_TEPSA_SUITE", GetType(Double)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("PREPAGO", GetType(Double)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("ORDEN_TRABAJO", GetType(Double)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("CORTESIA", GetType(Double)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("PROMOCION", GetType(Double)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("DEVOLUCION", GetType(Double)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("monto_total", GetType(Double)))
                            dtTempcomisiones_funci.Columns.Add(New DataColumn("total", GetType(Double)))
                        End If


                        dr = dtTempcomisiones_funci.NewRow
                        dr("ANIO") = row.Item("ANIO")
                        dr("AGENCIA") = row.Item("AGENCIA")
                        dr("ID_AGENCIA") = row.Item("ID_AGENCIA")
                        dr("PRESIDENCIAL_CAMA") = row.Item("PRESIDENCIAL_CAMA")
                        dr("BOLETO_PRESIDENCIAL") = row.Item("BOLETO_PRESIDENCIAL")
                        dr("BOLETO_TEPSA_SUITE") = row.Item("BOLETO_TEPSA_SUITE")
                        dr("DELIVERY") = row.Item("DELIVERY")
                        dr("RCPRESIDENCIAL") = row.Item("R.C. PRESIDENCIAL")
                        dr("RCPRESIDENCIALCAMA") = row.Item("R.C. PRESIDENCIAL CAMA")
                        dr("RC_TEPSA_SUITE") = row.Item("R.C. SUITE")
                        dr("PREPAGO") = row.Item("PREPAGO")
                        dr("ORDEN_TRABAJO") = row.Item("ORDEN_TRABAJO")
                        dr("CORTESIA") = row.Item("CORTESIA")
                        dr("PROMOCION") = row.Item("PROMOCION")
                        dr("DEVOLUCION") = row.Item("DEVOLUCION")
                        dr("monto_total") = 0
                        dr("total") = 0
                        dtTempcomisiones_funci.Rows.Add(dr)
                    Else
                        dr = dtTempcomisiones_funci.NewRow
                        dr("ANIO") = 0
                        dr("AGENCIA") = "TOTAL"
                        dr("ID_AGENCIA") = 0
                        dr("PRESIDENCIAL_CAMA") = PresidencialCama1
                        dr("BOLETO_PRESIDENCIAL") = BOLETO_PRESIDENCIAL1
                        dr("BOLETO_TEPSA_SUITE") = BOLETO_TEPSA_SUITE
                        dr("DELIVERY") = DELIVERY1
                        dr("RCPRESIDENCIAL") = RC_PRESIDENCIAL
                        dr("RCPRESIDENCIALCAMA") = RC_PRESIDENCIAL_CAMA
                        dr("RC_TEPSA_SUITE") = RC_TEPSA_SUITE
                        dr("PREPAGO") = PREPAGO1
                        dr("ORDEN_TRABAJO") = ORDEN_TRABAJO1
                        dr("CORTESIA") = CORTESIA1
                        dr("PROMOCION") = PROMOCION1
                        dr("DEVOLUCION") = DEVOLUCION1
                        dr("monto_total") = 0
                        dr("total") = (PresidencialCama1 + BOLETO_PRESIDENCIAL1 + BOLETO_TEPSA_SUITE + _
                                       DELIVERY1 + RC_PRESIDENCIAL + RC_PRESIDENCIAL_CAMA + RC_TEPSA_SUITE - _
                                       PREPAGO1 - ORDEN_TRABAJO1 - CORTESIA1 - _
                                       PROMOCION1 - DEVOLUCION1)
                        dtTempcomisiones_funci.Rows.Add(dr)

                        If total1 = 0 Then
                            total1 = (PresidencialCama1 + BOLETO_PRESIDENCIAL1 + BOLETO_TEPSA_SUITE + DELIVERY1 + RC_PRESIDENCIAL + RC_PRESIDENCIAL_CAMA + RC_TEPSA_SUITE - PREPAGO1 - ORDEN_TRABAJO1 - CORTESIA1 - PROMOCION1 - DEVOLUCION1)
                        End If

                        '----------------------------------------------------
                        dr = dtTempcomisiones_funci.NewRow
                        dr("ANIO") = row.Item("ANIO")
                        dr("AGENCIA") = row.Item("AGENCIA")
                        dr("ID_AGENCIA") = row.Item("ID_AGENCIA")
                        dr("PRESIDENCIAL_CAMA") = row.Item("PRESIDENCIAL_CAMA")
                        dr("BOLETO_PRESIDENCIAL") = row.Item("BOLETO_PRESIDENCIAL")
                        dr("BOLETO_TEPSA_SUITE") = row.Item("BOLETO_TEPSA_SUITE")
                        dr("DELIVERY") = row.Item("DELIVERY")
                        dr("RCPRESIDENCIAL") = row.Item("R.C. PRESIDENCIAL")
                        dr("RCPRESIDENCIALCAMA") = row.Item("R.C. PRESIDENCIAL CAMA")
                        dr("RC_TEPSA_SUITE") = row.Item("R.C. SUITE")
                        dr("PREPAGO") = row.Item("PREPAGO")
                        dr("ORDEN_TRABAJO") = row.Item("ORDEN_TRABAJO")
                        dr("CORTESIA") = row.Item("CORTESIA")
                        dr("PROMOCION") = row.Item("PROMOCION")
                        dr("DEVOLUCION") = row.Item("DEVOLUCION")
                        dr("monto_total") = 0
                        dr("total") = 0
                        dtTempcomisiones_funci.Rows.Add(dr)

                        PresidencialCama1 = 0
                        BOLETO_PRESIDENCIAL1 = 0
                        BOLETO_TEPSA_SUITE = 0
                        DELIVERY1 = 0
                        RC_PRESIDENCIAL = 0
                        RC_PRESIDENCIAL_CAMA = 0
                        RC_TEPSA_SUITE = 0
                        PREPAGO1 = 0
                        ORDEN_TRABAJO1 = 0
                        CORTESIA1 = 0
                        PROMOCION1 = 0
                        DEVOLUCION1 = 0

                        PresidencialCama1 += row.Item("PRESIDENCIAL_CAMA")
                        BOLETO_PRESIDENCIAL1 += row.Item("BOLETO_PRESIDENCIAL")
                        BOLETO_TEPSA_SUITE += row.Item("BOLETO_TEPSA_SUITE")
                        DELIVERY1 += row.Item("DELIVERY")
                        RC_PRESIDENCIAL += row.Item("R.C. PRESIDENCIAL")
                        RC_PRESIDENCIAL_CAMA += row.Item("R.C. PRESIDENCIAL CAMA")
                        RC_TEPSA_SUITE += row.Item("R.C. SUITE")
                        PREPAGO1 += row.Item("PREPAGO")
                        ORDEN_TRABAJO1 += row.Item("ORDEN_TRABAJO")
                        CORTESIA1 += row.Item("CORTESIA")
                        PROMOCION1 += row.Item("PROMOCION")
                        DEVOLUCION1 += row.Item("DEVOLUCION")
                    End If
                    i += 1
                    año = row.Item("ANIO")
                Next

                '---total
                dr = dtTempcomisiones_funci.NewRow
                dr("ANIO") = 0
                dr("AGENCIA") = "TOTAL"
                dr("ID_AGENCIA") = 0
                dr("PRESIDENCIAL_CAMA") = PresidencialCama1
                dr("BOLETO_PRESIDENCIAL") = BOLETO_PRESIDENCIAL1
                dr("BOLETO_TEPSA_SUITE") = BOLETO_TEPSA_SUITE
                dr("DELIVERY") = DELIVERY1
                dr("RCPRESIDENCIAL") = RC_PRESIDENCIAL
                dr("RCPRESIDENCIALCAMA") = RC_PRESIDENCIAL_CAMA
                dr("RC_TEPSA_SUITE") = RC_TEPSA_SUITE
                dr("PREPAGO") = PREPAGO1
                dr("ORDEN_TRABAJO") = ORDEN_TRABAJO1
                dr("CORTESIA") = CORTESIA1
                dr("PROMOCION") = PROMOCION1
                dr("DEVOLUCION") = DEVOLUCION1
                dr("monto_total") = 0
                total2 = (PresidencialCama1 + BOLETO_PRESIDENCIAL1 + BOLETO_TEPSA_SUITE + DELIVERY1 + RC_PRESIDENCIAL + RC_PRESIDENCIAL_CAMA + RC_TEPSA_SUITE - PREPAGO1 - ORDEN_TRABAJO1 - CORTESIA1 - PROMOCION1 - DEVOLUCION1)
                dr("total") = (total2)
                dtTempcomisiones_funci.Rows.Add(dr)

                '--DIFERENCIA
                Dim Diferencia As Double = 0
                dr = dtTempcomisiones_funci.NewRow
                dr("ANIO") = 0
                dr("AGENCIA") = "DIFERENCIA"
                dr("ID_AGENCIA") = 0
                dr("PRESIDENCIAL_CAMA") = 0
                dr("BOLETO_PRESIDENCIAL") = 0
                dr("BOLETO_TEPSA_SUITE") = 0
                dr("DELIVERY") = 0
                dr("RCPRESIDENCIAL") = 0
                dr("RCPRESIDENCIALCAMA") = 0
                dr("RC_TEPSA_SUITE") = 0
                dr("PREPAGO") = 0
                dr("ORDEN_TRABAJO") = 0
                dr("CORTESIA") = 0
                dr("PROMOCION") = 0
                dr("DEVOLUCION") = 0
                dr("monto_total") = 0
                dr("total") = (total1 - total2)
                Diferencia = (total1 - total2)
                dtTempcomisiones_funci.Rows.Add(dr)

                '--TOTAL A PAGAR
                dr = dtTempcomisiones_funci.NewRow
                dr("ANIO") = 0
                dr("AGENCIA") = "COMISION"
                dr("ID_AGENCIA") = 0
                dr("PRESIDENCIAL_CAMA") = 0
                dr("BOLETO_PRESIDENCIAL") = 0
                dr("BOLETO_TEPSA_SUITE") = 0
                dr("DELIVERY") = 0
                dr("RCPRESIDENCIAL") = 0
                dr("RCPRESIDENCIALCAMA") = 0
                dr("RC_TEPSA_SUITE") = 0
                dr("PREPAGO") = 0
                dr("ORDEN_TRABAJO") = 0
                dr("CORTESIA") = 0
                dr("PROMOCION") = 0
                dr("DEVOLUCION") = 0
                dr("monto_total") = 0
                dr("total") = (Diferencia * 0.03)
                dtTempcomisiones_funci.Rows.Add(dr)

                dScomisiones_funci = dtTempcomisiones_funci.Copy
                '----Fin Comision Sivana
                If Not IsNothing(dScomisiones_funci) Then
                    dvcomisiones_funci_credi = dScomisiones_funci.DefaultView
                End If

            End If

            If iOpcion = 0 Then
                With DGV4
                    .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                    .AllowUserToOrderColumns = True
                    .AllowUserToDeleteRows = False
                    .AllowUserToAddRows = False
                    .AutoGenerateColumns = False
                    .DataSource = dvcomisiones_funci_credi
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    .SelectionMode = DataGridViewSelectionMode.CellSelect
                    .VirtualMode = True
                    .RowHeadersVisible = True
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
            ElseIf iOpcion = 1 And comifunci.Trim <> "FUCA" Then
                With DGV4
                    .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                    .AllowUserToOrderColumns = True
                    .AllowUserToDeleteRows = False
                    .AllowUserToAddRows = False
                    .AutoGenerateColumns = False
                    .DataSource = dvcomisiones_funci_credi
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    .SelectionMode = DataGridViewSelectionMode.CellSelect
                    .VirtualMode = True
                    .RowHeadersVisible = True
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
            End If

            If iOpcion = 0 Then
                pnlPorcentaje2.Visible = False
                pnlTotalCobranza.Visible = False
                pnlMeta.Visible = False
                pnlDetalleComision.Visible = False

                Label11.Visible = True
                Label14.Visible = True
                txtigv_comi_factu_funci.Visible = True
                txttotal_comi_factu_funci.Visible = True

                pnlTotalVenta.Dock = System.Windows.Forms.DockStyle.Fill
                DGV4.Dock = System.Windows.Forms.DockStyle.Fill

                Dim ANIO As New DataGridViewTextBoxColumn
                With ANIO
                    .HeaderText = "AÑO"
                    .Name = "ANIO"
                    .DataPropertyName = "ANIO"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .ReadOnly = True
                End With

                Dim AGENCIA As New DataGridViewTextBoxColumn
                With AGENCIA
                    .HeaderText = "AGENCIA"
                    .Name = "AGENCIA"
                    .DataPropertyName = "AGENCIA"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .ReadOnly = True
                End With

                Dim PRESIDENCIAL_CAMA As New DataGridViewTextBoxColumn
                With PRESIDENCIAL_CAMA
                    .HeaderText = "PRESIDENCIAL CAMA"
                    .Name = "PRESIDENCIAL_CAMA"
                    .DataPropertyName = "PRESIDENCIAL_CAMA"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.NullValue = "0,00"
                End With
                Dim BOLETO_PRESIDENCIAL As New DataGridViewTextBoxColumn
                With BOLETO_PRESIDENCIAL
                    .HeaderText = "BOLETO PRESIDENCIAL"
                    .Name = "BOLETO_PRESIDENCIAL"
                    .DataPropertyName = "BOLETO_PRESIDENCIAL"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.NullValue = "0,00"
                End With
                Dim BOLETO_TEPSA_SUITE As New DataGridViewTextBoxColumn
                With BOLETO_TEPSA_SUITE
                    .HeaderText = "BOLETO SUITE"
                    .Name = "BOLETO_TEPSA_SUITE"
                    .DataPropertyName = "BOLETO_TEPSA_SUITE"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.NullValue = "0,00"
                End With
                Dim DELIVERY As New DataGridViewTextBoxColumn
                With DELIVERY
                    .HeaderText = "DELIVERY"
                    .Name = "DELIVERY"
                    .DataPropertyName = "DELIVERY"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.NullValue = "0,00"
                End With
                Dim RC_PRESIDENCIAL As New DataGridViewTextBoxColumn
                With RC_PRESIDENCIAL
                    .HeaderText = "R.C. PRESIDENCIAL"
                    .Name = "R.C. PRESIDENCIAL"
                    .DataPropertyName = "RCPRESIDENCIAL"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.NullValue = "0,00"
                End With
                Dim RC_PRESIDENCIAL_CAMA As New DataGridViewTextBoxColumn
                With RC_PRESIDENCIAL_CAMA
                    .HeaderText = "R.C. PRESIDENCIAL CAMA"
                    .Name = "R.C. PRESIDENCIAL CAMA"
                    .DataPropertyName = "RCPRESIDENCIALCAMA"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.NullValue = "0,00"
                End With
                Dim RC_TEPSA_SUITE As New DataGridViewTextBoxColumn
                With RC_TEPSA_SUITE
                    .HeaderText = "R.C. SUITE"
                    .Name = "RC_TEPSA_SUITE"
                    .DataPropertyName = "RC_TEPSA_SUITE"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.NullValue = "0,00"
                End With
                Dim PREPAGO As New DataGridViewTextBoxColumn
                With PREPAGO
                    .HeaderText = "PREPAGO"
                    .Name = "PREPAGO"
                    .DataPropertyName = "PREPAGO"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.NullValue = "0,00"
                End With
                Dim ORDEN_TRABAJO As New DataGridViewTextBoxColumn
                With ORDEN_TRABAJO
                    .HeaderText = "ORDEN TRABAJO"
                    .Name = "ORDEN_TRABAJO"
                    .DataPropertyName = "ORDEN_TRABAJO"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.NullValue = "0,00"
                End With
                Dim CORTESIA As New DataGridViewTextBoxColumn
                With CORTESIA
                    .HeaderText = "CORTESIA"
                    .Name = "CORTESIA"
                    .DataPropertyName = "CORTESIA"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.NullValue = "0,00"
                End With
                Dim PROMOCION As New DataGridViewTextBoxColumn
                With PROMOCION
                    .HeaderText = "PROMOCION"
                    .Name = "PROMOCION"
                    .DataPropertyName = "PROMOCION"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.NullValue = "0,00"
                End With
                Dim DEVOLUCION As New DataGridViewTextBoxColumn
                With DEVOLUCION
                    .HeaderText = "DEVOLUCION"
                    .Name = "DEVOLUCION"
                    .DataPropertyName = "DEVOLUCION"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.NullValue = "0,00"
                End With

                Dim total As New DataGridViewTextBoxColumn
                With total
                    .HeaderText = "TOTAL"
                    .Name = "total"
                    .DataPropertyName = "total"
                    '.Width = 4
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.NullValue = "0,00"
                End With

                With DGV4
                    .Columns.AddRange(ANIO, AGENCIA, PRESIDENCIAL_CAMA, BOLETO_PRESIDENCIAL, BOLETO_TEPSA_SUITE, DELIVERY, RC_PRESIDENCIAL, RC_PRESIDENCIAL_CAMA, RC_TEPSA_SUITE, PREPAGO, ORDEN_TRABAJO, CORTESIA, PROMOCION, DEVOLUCION, total)
                End With

                'Me.txtcomi_factu_funci.Text = 0
                Dim iIngreso1 As Double = 0
                Dim iEgreso1 As Double = 0
                Dim iIngreso2 As Double = 0
                Dim iEgreso2 As Double = 0
                For x As Integer = 0 To dvcomisiones_funci_credi.Count - 1
                    If dvcomisiones_funci_credi.Table.Rows(x)("ANIO") > 0 Then 'Silvana
                        If dvcomisiones_funci_credi.Table.Rows(x)("ANIO") = Year(Me.DTPFECHAFINAL_funci.Value) Then
                            iIngreso1 += dvcomisiones_funci_credi.Table.Rows(x)("PRESIDENCIAL_CAMA") + dvcomisiones_funci_credi.Table.Rows(x)("BOLETO_PRESIDENCIAL") + dvcomisiones_funci_credi.Table.Rows(x)("BOLETO_TEPSA_SUITE") + dvcomisiones_funci_credi.Table.Rows(x)("DELIVERY") + dvcomisiones_funci_credi.Table.Rows(x)("RCPRESIDENCIAL") + dvcomisiones_funci_credi.Table.Rows(x)("RCPRESIDENCIALCAMA") + dvcomisiones_funci_credi.Table.Rows(x)("RC_TEPSA_SUITE")
                            iEgreso1 += dvcomisiones_funci_credi.Table.Rows(x)("PREPAGO") + dvcomisiones_funci_credi.Table.Rows(x)("ORDEN_TRABAJO") + dvcomisiones_funci_credi.Table.Rows(x)("CORTESIA") + dvcomisiones_funci_credi.Table.Rows(x)("PROMOCION") + dvcomisiones_funci_credi.Table.Rows(x)("DEVOLUCION")
                        Else
                            iIngreso2 += dvcomisiones_funci_credi.Table.Rows(x)("PRESIDENCIAL_CAMA") + dvcomisiones_funci_credi.Table.Rows(x)("BOLETO_PRESIDENCIAL") + dvcomisiones_funci_credi.Table.Rows(x)("BOLETO_TEPSA_SUITE") + dvcomisiones_funci_credi.Table.Rows(x)("DELIVERY") + dvcomisiones_funci_credi.Table.Rows(x)("RCPRESIDENCIAL") + dvcomisiones_funci_credi.Table.Rows(x)("RCPRESIDENCIALCAMA") + dvcomisiones_funci_credi.Table.Rows(x)("RC_TEPSA_SUITE")
                            iEgreso2 += dvcomisiones_funci_credi.Table.Rows(x)("PREPAGO") + dvcomisiones_funci_credi.Table.Rows(x)("ORDEN_TRABAJO") + dvcomisiones_funci_credi.Table.Rows(x)("CORTESIA") + dvcomisiones_funci_credi.Table.Rows(x)("PROMOCION") + dvcomisiones_funci_credi.Table.Rows(x)("DEVOLUCION")
                        End If
                    End If
                Next
                Dim iTotal1 As Double = iIngreso1 - iEgreso1
                Dim iTotal2 As Double = iIngreso2 - iEgreso2
                Dim iTotal As Double = (iTotal1 - iTotal2) * 0.03

                Me.txtcomi_factu_funci.Text = FormatNumber(iTotal, 2) 'CDbl(Me.txtcomi_factu_funci.Text) '+ CDbl(dvcomisiones_funci_credi.Table.Rows(i)("total"))
                Me.txtigv_comi_factu_funci.Text = FormatNumber(CDbl(Me.txtcomi_factu_funci.Text) * dtoUSUARIOS.vImpuesto, 2)
                Me.txttotal_comi_factu_funci.Text = FormatNumber(CDbl(Me.txtcomi_factu_funci.Text) * dtoUSUARIOS.vImpuesto + CDbl(Me.txtcomi_factu_funci.Text), 2)


                For j As Integer = 0 To Me.DGV4.RowCount - 1
                    If DGV4.Rows(j).Cells("ANIO").Value = 0 Then
                        DGV4.Rows(j).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 179)
                        DGV4.Rows(j).DefaultCellStyle.ForeColor = Color.Black
                        DGV4.Rows(j).DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
                        DGV4.Rows(j).Cells("ANIO").Value = ""
                    End If
                Next
            Else
                pnlTotalComision.Visible = True
                pnlTotalComision.Dock = System.Windows.Forms.DockStyle.Bottom

                pnlDetalleComision.Visible = True
                pnlDetalleComision.Dock = System.Windows.Forms.DockStyle.Bottom

                pnlTotalVenta.Visible = True
                pnlMeta.Visible = True
                pnlTotalVenta.Dock = System.Windows.Forms.DockStyle.Left
                DGV4.Dock = System.Windows.Forms.DockStyle.Top

                pnlTotalCobranza.Visible = True
                pnlTotalCobranza.Dock = System.Windows.Forms.DockStyle.Left
                'DGV4.Dock = System.Windows.Forms.DockStyle.Top

                pnlPorcentaje2.Visible = True
                pnlPorcentaje2.Dock = System.Windows.Forms.DockStyle.Left
                'DGV4.Dock = System.Windows.Forms.DockStyle.Fill

                Label11.Visible = True
                Label14.Visible = True
                txtigv_comi_factu_funci.Visible = True
                txttotal_comi_factu_funci.Visible = True

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
                    '.ReadOnly = True
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
                    '.ReadOnly = True
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
                    '.ReadOnly = True
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
                    '.ReadOnly = True
                End With

                '-----------------------------------------------------------------------------------------
                '-----------------------Columna para FUPN--------------------------------------
                '-----------------------------------------------------------------------------------------
                Dim ORIGEN As New DataGridViewTextBoxColumn
                With ORIGEN
                    .HeaderText = "ORIGEN"
                    .Name = "ORIGEN"
                    .DataPropertyName = "ORIGEN"
                    .Width = 70
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .ReadOnly = True
                End With
                '-----------------------------------------------------------------------------------------
                '-----------------------------------------------------------------------------------------

                If comifunci.Trim <> "FUCA" And comifunci.Trim <> "FUPN" And comifunci.Trim <> "EJPA" And comifunci.Trim <> "FUCC" Then

                    'pnlTotalCobranza.Visible = False
                    'pnlTotalComision.Visible = False
                    'pnlPorcentaje.Visible = False
                    'pnlDetalleComision.Visible = False
                    'pnlMeta.Visible = False

                    'pnlTotalCobranza.Visible = False
                    'pnlTotalComision.Visible = False
                    'pnlPorcentaje.Visible = False
                    'pnlDetalleComision.Visible = False
                    'pnlMeta.Visible = False

                    pnlPorcentaje2.Visible = False
                    pnlTotalCobranza.Visible = False
                    pnlMeta.Visible = False
                    pnlDetalleComision.Visible = False

                    'Label11.Visible = True
                    'Label14.Visible = True
                    'txtigv_comi_factu_funci.Visible = True
                    'txttotal_comi_factu_funci.Visible = True

                    pnlTotalVenta.Dock = System.Windows.Forms.DockStyle.Fill
                    DGV4.Dock = System.Windows.Forms.DockStyle.Fill

                    'pnlTotalVenta.Dock = System.Windows.Forms.DockStyle.Fill
                    'DGV4.Dock = System.Windows.Forms.DockStyle.Fill

                    dScomisiones_funci = ObjComisiones.SP_L_SERVICIOS_FUNCI_MONTO()

                    If Not IsNothing(dScomisiones_funci) Then
                        dvcomisiones_funci_credi = dScomisiones_funci.DefaultView
                    End If

                    DGV4.DataSource = dvcomisiones_funci_credi

                    With DGV4
                        .Columns.AddRange(IDTIPO_COMPROBANTE, TIPO_COMPROBANTE, TOTAL_COSTO, AFEC_COMI, SUB_TOTAL, PORCEN, MONTO_PORCEN, NRO, monto_x_comprobante, Total_por_compro, otros, sub_total_pagar_comi)
                    End With

                    Me.txtcomi_factu_funci.Text = 0
                    For i As Integer = 0 To dvcomisiones_funci_credi.Count - 1
                        Try
                            Me.txtcomi_factu_funci.Text = CDbl(Me.txtcomi_factu_funci.Text) + CDbl(dvcomisiones_funci_credi.Table.Rows(i)("sub_total_pagar_comi"))
                        Catch
                        End Try
                    Next
                    Me.txtigv_comi_factu_funci.Text = FormatNumber(CDbl(Me.txtcomi_factu_funci.Text) * dtoUSUARIOS.vImpuesto, 2)
                    Me.txttotal_comi_factu_funci.Text = FormatNumber(CDbl(Me.txtcomi_factu_funci.Text) * dtoUSUARIOS.vImpuesto + CDbl(Me.txtcomi_factu_funci.Text), 2)

                ElseIf comifunci.Trim = "FUCA" Or comifunci.Trim = "FUCC" Then
                    'hlamas
                    'pnlTotalVenta.Visible = True
                    'pnlTotalCobranza.Visible = True
                    'pnlTotalComision.Visible = True
                    'pnlPorcentaje.Visible = True
                    'pnlDetalleComision.Visible = True
                    'pnlMeta.Visible = True

                    Label11.Visible = False
                    Label14.Visible = False
                    txtigv_comi_factu_funci.Visible = False
                    txttotal_comi_factu_funci.Visible = False

                    lblMeta.Visible = True
                    lblDatoMeta.Visible = True
                    'lblMetaProvincia.Visible = False
                    'lblDatoMetaProvincia.Visible = False

                    lblTotalventa.Visible = True
                    lblDatoTotalVenta.Visible = True
                    'lblTotalventaProvincia.Visible = False
                    'lblDatoTotalVentaProvincia.Visible = False

                    lblCobranza.Visible = True
                    lblDatoTotalCobranza.Visible = True
                    'lblCobranzaProvincia.Visible = False
                    'lblDatoTotalCobranzaProvincia.Visible = False

                    lblPorcentaje.Visible = True
                    lblDatoPorcentaje.Visible = True
                    'lblPorcentajeProvincia.Visible = False
                    'lblDatoPorcentajeProvincia.Visible = False

                    lblBono.Visible = True
                    lblDatoBono.Visible = True
                    'lblBonoProvincia.Visible = False
                    'lblDatoBonoProvincia.Visible = False

                    'aqi
                    lblMeta.Text = "Meta TC:"
                    lblTotalventa.Text = "Tot. Venta TC:"
                    lblCobranza.Text = "Tot. Cobranza TC:"
                    lblPorcentaje.Text = "Porcentaje TC (%):"
                    lblBono.Text = "Bono TC:"
                    'lblDatoMeta.Location = New Point(67, 4)
                    'lblDatoTotalVenta.Location = New Point(225, 4)
                    'lblDatoTotalCobranza.Location = New Point(210, 4)
                    'lblDatoPorcentaje.Location = New Point(120, 240)
                    'lblDatoBono.Location = New Point(245, 240)

                    Me.lblMetaProvincia.Text = "Meta CE"
                    Me.lblTotalventaProvincia.Text = "Tot. Venta CE:"
                    lblPorcentajeProvincia.Text = "Porcentaje CE (%):"
                    lblCobranzaProvincia.Text = "Tot. Cobranza CE:"
                    lblBonoProvincia.Text = "Bono CE:"

                    lblDatoMeta.Text = "0"
                    lblDatoTotalVenta.Text = "0"
                    lblDatoTotalCobranza.Text = "0"
                    lblDatoPorcentaje.Text = "0"
                    lblDatoBono.Text = "0"

                    lblDatoMetaProvincia.Text = "0"
                    lblDatoTotalVentaProvincia.Text = "0"
                    lblDatoTotalCobranzaProvincia.Text = "0"
                    lblDatoPorcentajeProvincia.Text = "0"
                    lblDatoBonoProvincia.Text = "0"

                    Dim dblTotalVenta As Double = 0
                    Dim dblTotalVentaLima As Double = 0
                    Dim dblTotalVentaProvincia As Double = 0

                    Dim dblTotalCobranza As Double = 0

                    DGV4.Columns.Clear()
                    dgdCobranza.Columns.Clear()
                    dgdComision.Columns.Clear()
                    dgdPorcentaje.Columns.Clear()

                    With DGV4
                        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                        .AllowUserToOrderColumns = True
                        .AllowUserToDeleteRows = False
                        .AllowUserToAddRows = False
                        .AutoGenerateColumns = False
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .VirtualMode = True
                        .RowHeadersVisible = True
                        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    With dgdCobranza
                        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                        .AllowUserToOrderColumns = True
                        .AllowUserToDeleteRows = False
                        .AllowUserToAddRows = False
                        .AutoGenerateColumns = False
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .VirtualMode = True
                        .RowHeadersVisible = True
                        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    With dgdComision
                        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                        .AllowUserToOrderColumns = True
                        .AllowUserToDeleteRows = False
                        .AllowUserToAddRows = False
                        .AutoGenerateColumns = False
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .VirtualMode = True
                        .RowHeadersVisible = True
                        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    With dgdPorcentaje
                        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                        .AllowUserToOrderColumns = True
                        .AllowUserToDeleteRows = False
                        .AllowUserToAddRows = False
                        .AutoGenerateColumns = False
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .VirtualMode = True
                        .RowHeadersVisible = True
                        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    '----------------------------------------------------------------------
                    'Para el DataGrid de Porcentaje de Bonificación o Penalidad
                    '----------------------------------------------------------------------
                    Dim RANGO As New DataGridViewTextBoxColumn
                    With RANGO
                        .HeaderText = "RANGO"
                        .Name = "RANGO"
                        .DataPropertyName = "RANGO"
                        .Width = 100
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With

                    Dim BONO As New DataGridViewTextBoxColumn
                    With BONO
                        .HeaderText = "COMISIÓN"
                        .Name = "COMISION"
                        .DataPropertyName = "COMISION"
                        .Width = 90
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                        .ReadOnly = True
                    End With
                    '----------------------------------------------------------------------

                    '----------------------------------------------------------------------
                    'Para el DataGrid de Documentos de Venta
                    '----------------------------------------------------------------------
                    Dim col_producto As New DataGridViewTextBoxColumn
                    With col_producto
                        .HeaderText = "PRODUCTO"
                        .Name = "producto"
                        .DataPropertyName = "PRODUCTO"
                        .Width = 103
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .ReadOnly = True
                    End With

                    Dim TOTALVENTA As New DataGridViewTextBoxColumn
                    With TOTALVENTA
                        .HeaderText = "SUB TOTAL"
                        .Name = "TOTALVENTA"
                        .DataPropertyName = "TOTALVENTA"
                        .Width = 68
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .DefaultCellStyle.Format = "N2"
                        .DefaultCellStyle.NullValue = "0,00"
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With

                    Dim TIPO_COMPROBANTE_VENTA As New DataGridViewTextBoxColumn
                    With TIPO_COMPROBANTE_VENTA
                        .HeaderText = "TIPO"
                        .Name = "TIPO_COMPROBANTE"
                        .DataPropertyName = "TIPO_COMPROBANTE"
                        .Width = 97
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .ReadOnly = True
                    End With
                    '----------------------------------------------------------------------

                    '----------------------------------------------------------------------
                    'Para el DataGrid de Documentos de Cobranza
                    '----------------------------------------------------------------------
                    Dim col_producto_1 As New DataGridViewTextBoxColumn
                    With col_producto_1
                        .HeaderText = "PRODUCTO"
                        .Name = "producto"
                        .DataPropertyName = "PRODUCTO"
                        .Width = 103
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .ReadOnly = True
                    End With

                    Dim TOTALCOBRANZA As New DataGridViewTextBoxColumn
                    With TOTALCOBRANZA
                        .HeaderText = "SUB TOTAL"
                        .Name = "TOTALCOBRANZA"
                        .DataPropertyName = "TOTALCOBRANZA"
                        .Width = 68
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .DefaultCellStyle.Format = "N2"
                        .DefaultCellStyle.NullValue = "0,00"
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With

                    Dim TIPO_COMPROBANTE_COBRANZA As New DataGridViewTextBoxColumn
                    With TIPO_COMPROBANTE_COBRANZA
                        .HeaderText = "TIPO"
                        .Name = "TIPO_COMPROBANTE"
                        .DataPropertyName = "TIPO_COMPROBANTE"
                        .Width = 90
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .ReadOnly = True
                    End With
                    '----------------------------------------------------------------------

                    '----------------------------------------------------------------------
                    'Para el DataGrid de Comisiones de los funcionarios de carga
                    '----------------------------------------------------------------------
                    Dim col_producto_2 As New DataGridViewTextBoxColumn
                    With col_producto_2
                        .HeaderText = "PRODUCTO"
                        .Name = "producto"
                        .DataPropertyName = "PRODUCTO"
                        .Width = 103
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .ReadOnly = True
                    End With
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
                        .Name = "COBRANZA"
                        .DataPropertyName = "COBRANZA"
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
                    '----------------------------------------------------------------------

                    ' Funcion para obtener los rangos de porcentajes
                    dsPorcentaje = ObjComisiones.ListarPorcentajeCarga()
                    If Not IsNothing(dsPorcentaje) Then
                        dvPorcentaje = dsPorcentaje.Tables(0).DefaultView

                        dgdPorcentaje.DataSource = dvPorcentaje

                        With dgdPorcentaje
                            .Columns.AddRange(RANGO, BONO)
                        End With
                    End If
                    ' ---------------------------------------------

                    'dblMeta = ObjComisiones.ObtnerMetaFuncionario
                    dblMetaLima = 0
                    dblMetaProvincia = 0
                    Dim dt As DataTable = ObjComisiones.ObtnerMetaFuncionario
                    If dt.Rows.Count > 0 Then
                        For Each row As DataRow In dt.Rows
                            If row.Item("producto").ToString = 8 Then
                                dblMetaLima = row.Item("monto")
                            End If
                            If row.Item("producto").ToString = 5 Then
                                dblMetaProvincia = row.Item("monto")
                            End If
                        Next
                    Else
                        dblMetaLima = 0
                        dblMetaProvincia = 0
                    End If
                    lblDatoMeta.Text = "S/. " & dblMetaLima.ToString()
                    lblDatoMetaProvincia.Text = "S/. " & dblMetaProvincia.ToString()

                    'lblDatoMeta.Text = "S/. " & dblMeta.ToString()

                    'Función para obtener la venta de documentos por funcionario
                    dsVentaTotal = ObjComisiones.ListarVentaTotalFuncionario()
                    If Not IsNothing(dsVentaTotal) Then
                        dvVentaTotal = dsVentaTotal.Tables(0).DefaultView
                        DGV4.DataSource = dvVentaTotal

                        With DGV4
                            .Columns.AddRange(col_producto, TIPO_COMPROBANTE_VENTA, TOTALVENTA)
                        End With

                        If dsVentaTotal.Tables(0).Rows.Count > 0 Then
                            dblTotalVentaLima = Math.Round(IIf(IsDBNull(dsVentaTotal.Tables(0).Compute("Sum(TOTALVENTA)", "PRODUCTO='COURIER'")), 0, dsVentaTotal.Tables(0).Compute("Sum(TOTALVENTA)", "PRODUCTO='COURIER'")), 2)
                            lblDatoTotalVenta.Text = "S/. " & dblTotalVentaLima.ToString()
                            dblTotalVentaProvincia = Math.Round(IIf(IsDBNull(dsVentaTotal.Tables(0).Compute("Sum(TOTALVENTA)", "PRODUCTO='CARGA EXPRESSA'")), 0, dsVentaTotal.Tables(0).Compute("Sum(TOTALVENTA)", "PRODUCTO='CARGA EXPRESSA'")), 2)
                            lblDatoTotalVentaProvincia.Text = "S/. " & dblTotalVentaProvincia.ToString()
                            dblTotalVenta = dblTotalVentaLima + dblTotalVentaProvincia
                        Else
                            lblDatoTotalVenta.Text = "S/. 0.00"
                            lblDatoTotalVentaProvincia.Text = "S/. 0.00"
                        End If

                        If dblMetaLima = 0 Then
                            ObjComisiones.PorcentajeVenta = 0
                            lblDatoPorcentaje.Text = Math.Round(ObjComisiones.PorcentajeVenta, 2)
                            lblDatoBono.Text = "0"
                        Else
                            ObjComisiones.PorcentajeVenta = (dblTotalVentaLima / dblMetaLima) * 100
                            lblDatoPorcentaje.Text = Math.Round(ObjComisiones.PorcentajeVenta, 2)
                            lblDatoBono.Text = ObjComisiones.ObtnerBonoPenalidad.ToString()
                        End If
                        If dblMetaProvincia = 0 Then
                            ObjComisiones.PorcentajeVenta = 0
                            lblDatoPorcentajeProvincia.Text = Math.Round(ObjComisiones.PorcentajeVenta, 2)
                            lblDatoBonoProvincia.Text = "0"
                        Else
                            ObjComisiones.PorcentajeVenta = (dblTotalVentaProvincia / dblMetaProvincia) * 100
                            lblDatoPorcentajeProvincia.Text = Math.Round(ObjComisiones.PorcentajeVenta, 2)
                            lblDatoBonoProvincia.Text = ObjComisiones.ObtnerBonoPenalidad.ToString()
                        End If
                    End If
                    ' ---------------------------------------------

                    'Función para obtener la cobranza de documentos por funcionario
                    dsCobranzaTotal = ObjComisiones.ListarCobranzaTotalFuncionario()
                    If Not IsNothing(dsCobranzaTotal) Then
                        dvCobranzaTotal = dsCobranzaTotal.Tables(0).DefaultView
                        dgdCobranza.DataSource = dvCobranzaTotal

                        With dgdCobranza
                            .Columns.AddRange(col_producto_1, TIPO_COMPROBANTE_COBRANZA, TOTALCOBRANZA)
                        End With

                        If dsCobranzaTotal.Tables(0).Rows.Count > 0 Then
                            dblTotalCobranza = Math.Round(IIf(IsDBNull(dsCobranzaTotal.Tables(0).Compute("Sum(TOTALCOBRANZA)", "PRODUCTO='COURIER'")), 0, dsCobranzaTotal.Tables(0).Compute("Sum(TOTALCOBRANZA)", "PRODUCTO='COURIER'")), 2)
                            lblDatoTotalCobranza.Text = "S/. " & dblTotalCobranza.ToString()
                            dblTotalCobranza = Math.Round(IIf(IsDBNull(dsCobranzaTotal.Tables(0).Compute("Sum(TOTALCOBRANZA)", "PRODUCTO='CARGA EXPRESSA'")), 0, dsCobranzaTotal.Tables(0).Compute("Sum(TOTALCOBRANZA)", "PRODUCTO='CARGA EXPRESSA'")), 2)
                            lblDatoTotalCobranzaProvincia.Text = "S/. " & dblTotalCobranza.ToString()
                        Else
                            lblDatoTotalCobranza.Text = "S/. 0.00"
                            lblDatoTotalCobranzaProvincia.Text = "S/. 0.00"
                        End If
                    End If
                    ' ---------------------------------------------

                    ObjComisiones.TASA = Convert.ToDouble(lblDatoBono.Text)
                    'ObjComisiones.TASA_LIMA = Convert.ToDouble(lblDatoBono.Text)
                    ObjComisiones.TASA2 = Convert.ToDouble(lblDatoBonoProvincia.Text)

                    'Función para calcular las comisiones de los funcionarios de carga
                    dsComisionTotal = ObjComisiones.SP_L_SERVICIOS_FUNCI_MONTO()
                    If Not IsNothing(dsComisionTotal) Then
                        dvComisionTotal = dsComisionTotal.DefaultView
                        dgdComision.DataSource = dvComisionTotal

                        With dgdComision
                            .Columns.AddRange(col_producto_2,IDGRUPO, GRUPO, PORCENTAJE, COBRANZA, COMISION)
                        End With
                        If dsComisionTotal.Rows.Count > 0 Then
                            txtcomi_factu_funci.Text = Math.Round(dsComisionTotal.Compute("Sum(COMISION)", ""), 2).ToString()
                        End If

                    End If
                ElseIf comifunci.Trim = "FUPN" Then
                    'pnlTotalVenta.Visible = True
                    'pnlTotalCobranza.Visible = True
                    'pnlTotalComision.Visible = True
                    'pnlPorcentaje.Visible = True
                    'pnlDetalleComision.Visible = True
                    'pnlMeta.Visible = True

                    Label11.Visible = False
                    Label14.Visible = False
                    txtigv_comi_factu_funci.Visible = False
                    txttotal_comi_factu_funci.Visible = False

                    lblMeta.Visible = True
                    lblDatoMeta.Visible = True
                    lblMetaProvincia.Visible = True
                    lblDatoMetaProvincia.Visible = True

                    lblTotalventa.Visible = True
                    lblDatoTotalVenta.Visible = True
                    lblTotalventaProvincia.Visible = True
                    lblDatoTotalVentaProvincia.Visible = True

                    lblCobranza.Visible = True
                    lblDatoTotalCobranza.Visible = True
                    lblCobranzaProvincia.Visible = True
                    lblDatoTotalCobranzaProvincia.Visible = True

                    lblPorcentaje.Visible = True
                    lblDatoPorcentaje.Visible = True
                    lblPorcentajeProvincia.Visible = True
                    lblDatoPorcentajeProvincia.Visible = True

                    lblBono.Visible = True
                    lblDatoBono.Visible = True
                    lblBonoProvincia.Visible = True
                    lblDatoBonoProvincia.Visible = True



                    lblMeta.Text = "Meta Lima:"
                    lblTotalventa.Text = "Tot. Venta Lima:"
                    lblCobranza.Text = "Tot. Cobranza Lima:"
                    lblPorcentaje.Text = "Porcentaje Lima (%):"
                    lblBono.Text = "Bono Lima:"
                    'lblDatoMeta.Location = New Point(77, 4)
                    'lblDatoTotalVenta.Location = New Point(242, 4)
                    'lblDatoTotalCobranza.Location = New Point(229, 4)
                    'lblDatoPorcentaje.Location = New Point(140, 240)
                    'lblDatoBono.Location = New Point(265, 240)

                    lblDatoMeta.Text = "S/. 0.00"
                    lblDatoMetaProvincia.Text = "S/. 0.00"
                    lblDatoTotalVenta.Text = "S/. 0.00"
                    lblDatoTotalVentaProvincia.Text = "S/. 0.00"
                    lblDatoTotalCobranza.Text = "S/. 0.00"
                    lblDatoTotalCobranzaProvincia.Text = "S/. 0.00"
                    lblDatoPorcentaje.Text = "0"
                    lblDatoPorcentajeProvincia.Text = "0"
                    lblDatoBono.Text = "0"
                    lblDatoBonoProvincia.Text = "0"

                    lblDatoMetaProvincia.Text = "0"
                    lblDatoTotalVentaProvincia.Text = "0"
                    lblDatoTotalCobranzaProvincia.Text = "0"
                    lblDatoPorcentajeProvincia.Text = "0"
                    lblDatoBonoProvincia.Text = "0"

                    dblMetaLima = 0
                    dblMetaProvincia = 0

                    Dim dblTotalVentaLima As Double = 0
                    Dim dblTotalVentaProvincia As Double = 0

                    Dim dblTotalCobranzaLima As Double = 0
                    Dim dblTotalCobranzaProvincia As Double = 0

                    Dim dsMeta As DataSet
                    Dim dvMeta As DataView

                    DGV4.Columns.Clear()
                    dgdCobranza.Columns.Clear()
                    dgdComision.Columns.Clear()
                    dgdPorcentaje.Columns.Clear()

                    With DGV4
                        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                        .AllowUserToOrderColumns = True
                        .AllowUserToDeleteRows = False
                        .AllowUserToAddRows = False
                        .AutoGenerateColumns = False
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .VirtualMode = True
                        .RowHeadersVisible = True
                        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    With dgdCobranza
                        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                        .AllowUserToOrderColumns = True
                        .AllowUserToDeleteRows = False
                        .AllowUserToAddRows = False
                        .AutoGenerateColumns = False
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .VirtualMode = True
                        .RowHeadersVisible = True
                        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    With dgdComision
                        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                        .AllowUserToOrderColumns = True
                        .AllowUserToDeleteRows = False
                        .AllowUserToAddRows = False
                        .AutoGenerateColumns = False
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .VirtualMode = True
                        .RowHeadersVisible = True
                        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    With dgdPorcentaje
                        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                        .AllowUserToOrderColumns = True
                        .AllowUserToDeleteRows = False
                        .AllowUserToAddRows = False
                        .AutoGenerateColumns = False
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .VirtualMode = True
                        .RowHeadersVisible = True
                        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    '----------------------------------------------------------------------
                    'Para el DataGrid de Bonificación o Penalidad
                    '----------------------------------------------------------------------
                    Dim CIUDAD As New DataGridViewTextBoxColumn
                    With CIUDAD
                        .HeaderText = "ORIGEN"
                        .Name = "ORIGEN"
                        .DataPropertyName = "ORIGEN"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With

                    Dim RANGO As New DataGridViewTextBoxColumn
                    With RANGO
                        .HeaderText = "RANGO"
                        .Name = "RANGO"
                        .DataPropertyName = "RANGO"
                        .Width = 85
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With

                    Dim BONO As New DataGridViewTextBoxColumn
                    With BONO
                        .HeaderText = "COMISIÓN"
                        .Name = "COMISION"
                        .DataPropertyName = "COMISION"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                        .ReadOnly = True
                    End With
                    '----------------------------------------------------------------------
                    '----------------------------------------------------------------------
                    'Para el DataGrid de Documentos de Venta
                    '----------------------------------------------------------------------

                    Dim TIPO_VENTA As New DataGridViewTextBoxColumn
                    With TIPO_VENTA
                        .HeaderText = "TIPO VENTA"
                        .Name = "TIPOVENTA"
                        .DataPropertyName = "TIPOVENTA"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .ReadOnly = True
                    End With

                    Dim TOTALVENTA As New DataGridViewTextBoxColumn
                    With TOTALVENTA
                        .HeaderText = "TOTAL"
                        .Name = "TOTAL"
                        .DataPropertyName = "TOTAL"
                        .Width = 70
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .DefaultCellStyle.Format = "N2"
                        .DefaultCellStyle.NullValue = "0,00"
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With
                    '----------------------------------------------------------------------
                    '----------------------------------------------------------------------
                    'Para el DataGrid de Cobranza
                    '----------------------------------------------------------------------
                    Dim CIUDAD_COB As New DataGridViewTextBoxColumn
                    With CIUDAD_COB
                        .HeaderText = "ORIGEN"
                        .Name = "ORIGEN"
                        .DataPropertyName = "ORIGEN"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With

                    Dim TIPO_COB As New DataGridViewTextBoxColumn
                    With TIPO_COB
                        .HeaderText = "TIPO COBRANZA"
                        .Name = "TIPOVENTA"
                        .DataPropertyName = "TIPOVENTA"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With

                    Dim TOTALCOBPASAJE As New DataGridViewTextBoxColumn
                    With TOTALCOBPASAJE
                        .HeaderText = "TOTAL"
                        .Name = "TOTAL"
                        .DataPropertyName = "TOTAL"
                        .Width = 70
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .DefaultCellStyle.Format = "N2"
                        .DefaultCellStyle.NullValue = "0,00"
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With
                    '----------------------------------------------------------------------

                    '----------------------------------------------------------------------
                    'Para el DataGrid de Comisiones de los funcionarios de Pasaje
                    '----------------------------------------------------------------------
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
                        .Name = "TIPOVENTA"
                        .DataPropertyName = "TIPOVENTA"
                        .Width = 120
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
                    '----------------------------------------------------------------------

                    ' Funcion para obtener los rangos de porcentajes
                    dsPorcentaje = ObjComisiones.ListarPorcentajePasaje()
                    If Not IsNothing(dsPorcentaje) Then
                        dvPorcentaje = dsPorcentaje.Tables(0).DefaultView

                        dgdPorcentaje.DataSource = dvPorcentaje

                        With dgdPorcentaje
                            .Columns.AddRange(CIUDAD, RANGO, BONO)
                        End With
                    End If
                    ' ---------------------------------------------

                    dsMeta = ObjComisiones.ObtnerMetaFuncionarioPasaje
                    If Not IsNothing(dsMeta) Then
                        If dsMeta.Tables(0).Rows.Count > 0 Then
                            For Fila As Integer = 0 To dsMeta.Tables(0).Rows.Count - 1
                                'Meta de Lima
                                If Convert.ToInt32(dsMeta.Tables(0).Rows(Fila)("ID_CIUDAD").ToString) = 1 Then
                                    dblMetaLima = dblMetaLima + Convert.ToDouble(dsMeta.Tables(0).Rows(Fila)("MONTO").ToString)
                                    'Meta de Provincia
                                ElseIf Convert.ToInt32(dsMeta.Tables(0).Rows(Fila)("ID_CIUDAD").ToString) = 2 Then
                                    dblMetaProvincia = dblMetaProvincia + Convert.ToDouble(dsMeta.Tables(0).Rows(Fila)("MONTO").ToString)
                                End If
                            Next
                            dblMetaLima = Math.Round(dblMetaLima, 2)
                            dblMetaProvincia = Math.Round(dblMetaProvincia, 2)
                            lblDatoMeta.Text = "S/. " & dblMetaLima.ToString
                            lblDatoMetaProvincia.Text = "S/. " & dblMetaProvincia.ToString
                        Else
                            lblDatoMeta.Text = "S/. 0.00"
                            lblDatoMetaProvincia.Text = "S/. 0.00"
                        End If
                    End If

                    'Función para obtener la venta de documentos por funcionario
                    dsVentaTotal = ObjComisiones.ListarVentaTotalFuncionarioPasaje()
                    If Not IsNothing(dsVentaTotal) Then
                        dvVentaTotal = dsVentaTotal.Tables(0).DefaultView
                        DGV4.DataSource = dvVentaTotal

                        With DGV4
                            .Columns.AddRange(ORIGEN, TIPO_VENTA, TOTALVENTA)
                        End With

                        If dsVentaTotal.Tables(0).Rows.Count > 0 Then
                            For FilaVenta As Integer = 0 To dsVentaTotal.Tables(0).Rows.Count - 1
                                If dsVentaTotal.Tables(0).Rows(FilaVenta)("ORIGEN").ToString = "LIMA" Then
                                    dblTotalVentaLima = dblTotalVentaLima + Convert.ToDouble(dsVentaTotal.Tables(0).Rows(FilaVenta)("TOTAL").ToString)
                                ElseIf dsVentaTotal.Tables(0).Rows(FilaVenta)("ORIGEN").ToString = "PROVINCIA" Then
                                    dblTotalVentaProvincia = dblTotalVentaProvincia + Convert.ToDouble(dsVentaTotal.Tables(0).Rows(FilaVenta)("TOTAL").ToString)
                                End If
                            Next
                            dblTotalVentaLima = Math.Round(dblTotalVentaLima, 2)
                            dblTotalVentaProvincia = Math.Round(dblTotalVentaProvincia, 2)
                            lblDatoTotalVenta.Text = "S/. " & dblTotalVentaLima.ToString()
                            lblDatoTotalVentaProvincia.Text = "S/. " & dblTotalVentaProvincia.ToString()
                        Else
                            lblDatoTotalVenta.Text = "S/. 0.00"
                            lblDatoTotalVentaProvincia.Text = "S/. 0.00"
                        End If

                        If dblMetaLima > 0 Then
                            ObjComisiones.Origen = 1
                            ObjComisiones.PorcentajeVentaLima = (dblTotalVentaLima / dblMetaLima) * 100
                            lblDatoPorcentaje.Text = Math.Round((dblTotalVentaLima / dblMetaLima) * 100, 2).ToString
                            lblDatoBono.Text = ObjComisiones.ObtenerBonoPenalidadPasaje.ToString()
                        Else
                            ObjComisiones.PorcentajeVentaLima = "0"
                            lblDatoPorcentaje.Text = "0"
                            lblDatoBono.Text = "0"
                        End If

                        If dblMetaProvincia > 0 Then
                            ObjComisiones.Origen = 2
                            ObjComisiones.PorcentajeVentaProvincia = (dblTotalVentaProvincia / dblMetaProvincia) * 100
                            lblDatoPorcentajeProvincia.Text = Math.Round((dblTotalVentaProvincia / dblMetaProvincia) * 100, 2).ToString
                            lblDatoBonoProvincia.Text = ObjComisiones.ObtenerBonoPenalidadPasaje.ToString()
                        Else
                            ObjComisiones.PorcentajeVentaProvincia = "0"
                            lblDatoPorcentajeProvincia.Text = "0"
                            lblDatoBonoProvincia.Text = "0"
                        End If



                    End If

                    '-----------------------------------------------------------------

                    'Función para obtener la cobranza de documentos por funcionario
                    dsCobranzaTotal = ObjComisiones.ListarCobranzaTotalFuncionarioPasaje()
                    If Not IsNothing(dsCobranzaTotal) Then
                        dvCobranzaTotal = dsCobranzaTotal.Tables(0).DefaultView
                        dgdCobranza.DataSource = dvCobranzaTotal

                        With dgdCobranza
                            .Columns.AddRange(CIUDAD_COB, TIPO_COB, TOTALCOBPASAJE)
                        End With

                        If dsCobranzaTotal.Tables(0).Rows.Count > 0 Then
                            For FilaCobro As Integer = 0 To dsCobranzaTotal.Tables(0).Rows.Count - 1
                                If dsCobranzaTotal.Tables(0).Rows(FilaCobro)("ORIGEN").ToString = "LIMA" Then
                                    dblTotalCobranzaLima = dblTotalCobranzaLima + Convert.ToDouble(dsCobranzaTotal.Tables(0).Rows(FilaCobro)("TOTAL").ToString)
                                ElseIf dsCobranzaTotal.Tables(0).Rows(FilaCobro)("ORIGEN").ToString = "PROVINCIA" Then
                                    dblTotalCobranzaProvincia = dblTotalCobranzaProvincia + Convert.ToDouble(dsCobranzaTotal.Tables(0).Rows(FilaCobro)("TOTAL").ToString)
                                End If
                            Next
                            dblTotalCobranzaLima = Math.Round(dblTotalCobranzaLima, 2)
                            dblTotalCobranzaProvincia = Math.Round(dblTotalCobranzaProvincia, 2)
                            lblDatoTotalCobranza.Text = "S/. " & dblTotalCobranzaLima.ToString()
                            lblDatoTotalCobranzaProvincia.Text = "S/. " & dblTotalCobranzaProvincia.ToString()
                        Else
                            lblDatoTotalCobranza.Text = "S/. 0.00"
                            lblDatoTotalCobranzaProvincia.Text = "S/. 0.00"
                        End If
                    End If

                    '-----------------------------------------------------------------

                    ObjComisiones.TASA_LIMA = Convert.ToDouble(lblDatoBono.Text)
                    ObjComisiones.TASA_PROVINCIA = Convert.ToDouble(lblDatoBonoProvincia.Text)

                    'Función para calcular las comisiones de los funcionarios de pasaje
                    dsComisionTotal = ObjComisiones.SP_L_SERVICIOS_FUNCI_MONTO()
                    If Not IsNothing(dsComisionTotal) Then
                        dvComisionTotal = dsComisionTotal.DefaultView
                        dgdComision.DataSource = dvComisionTotal

                        With dgdComision
                            .Columns.AddRange(CIUDAD_COMI, TIPO_COMI, PORCENTAJE_PASAJE, TOTAL_COMI_PASAJE, COMISION)
                        End With
                        If dsComisionTotal.Rows.Count > 0 Then
                            txtcomi_factu_funci.Text = Math.Round(dsComisionTotal.Compute("Sum(COMISION)", ""), 2).ToString()
                        End If

                    End If

                ElseIf comifunci.Trim = "EJPA" Then
                    'pnlTotalVenta.Visible = True
                    'pnlTotalCobranza.Visible = True
                    'pnlTotalComision.Visible = True
                    'pnlPorcentaje.Visible = True
                    'pnlDetalleComision.Visible = True
                    'pnlMeta.Visible = True

                    Label14.Visible = False
                    Label11.Visible = False
                    txtigv_comi_factu_funci.Visible = False
                    txttotal_comi_factu_funci.Visible = False

                    lblBono.Visible = False
                    lblDatoBono.Visible = False
                    lblBonoProvincia.Visible = False
                    lblDatoBonoProvincia.Visible = False

                    lblPorcentaje.Visible = False
                    lblPorcentajeProvincia.Visible = False
                    lblDatoPorcentaje.Visible = False
                    lblDatoPorcentajeProvincia.Visible = False

                    lblMeta.Visible = False
                    lblDatoMeta.Visible = False
                    lblMetaProvincia.Visible = False
                    lblDatoMetaProvincia.Visible = False

                    Dim dblTotalFuncionario As Double = 0
                    Dim dblTotalCobranzaFuncionario As Double = 0

                    DGV4.Columns.Clear()
                    dgdCobranza.Columns.Clear()
                    dgdComision.Columns.Clear()
                    dgdPorcentaje.Columns.Clear()

                    With DGV4
                        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                        .AllowUserToOrderColumns = True
                        .AllowUserToDeleteRows = False
                        .AllowUserToAddRows = False
                        .AutoGenerateColumns = False
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .VirtualMode = True
                        .RowHeadersVisible = True
                        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    With dgdCobranza
                        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                        .AllowUserToOrderColumns = True
                        .AllowUserToDeleteRows = False
                        .AllowUserToAddRows = False
                        .AutoGenerateColumns = False
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .VirtualMode = True
                        .RowHeadersVisible = True
                        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    With dgdComision
                        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                        .AllowUserToOrderColumns = True
                        .AllowUserToDeleteRows = False
                        .AllowUserToAddRows = False
                        .AutoGenerateColumns = False
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .VirtualMode = True
                        .RowHeadersVisible = True
                        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    With dgdPorcentaje
                        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                        .AllowUserToOrderColumns = True
                        .AllowUserToDeleteRows = False
                        .AllowUserToAddRows = False
                        .AutoGenerateColumns = False
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .VirtualMode = True
                        .RowHeadersVisible = True
                        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    '----------------------------------------------------------------------
                    'Para el DataGrid de Porcentaje de Bonificación o Penalidad
                    '----------------------------------------------------------------------
                    Dim TIPO_FUNCI_PORCENTAJE As New DataGridViewTextBoxColumn
                    With TIPO_FUNCI_PORCENTAJE
                        .HeaderText = "TIPO FUNCIONARIO"
                        .Name = "DESFUNCI"
                        .DataPropertyName = "DESFUNCI"
                        .Width = 170
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With

                    Dim BONO_EJEC_PASAJE As New DataGridViewTextBoxColumn
                    With BONO_EJEC_PASAJE
                        .HeaderText = "COMISIÓN"
                        .Name = "COMISION"
                        .DataPropertyName = "COMISION"
                        .Width = 70
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                        .ReadOnly = True
                    End With

                    '----------------------------------------------------------------------
                    '----------------------------------------------------------------------
                    'Para el DataGrid de Documentos de Venta
                    '----------------------------------------------------------------------

                    Dim TIPO_VENTA As New DataGridViewTextBoxColumn
                    With TIPO_VENTA
                        .HeaderText = "TIPO VENTA"
                        .Name = "TIPOVENTA"
                        .DataPropertyName = "TIPOVENTA"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .ReadOnly = True
                    End With

                    Dim TOTALVENTA As New DataGridViewTextBoxColumn
                    With TOTALVENTA
                        .HeaderText = "TOTAL"
                        .Name = "TOTAL"
                        .DataPropertyName = "TOTAL"
                        .Width = 70
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .DefaultCellStyle.Format = "N2"
                        .DefaultCellStyle.NullValue = "0,00"
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With
                    '----------------------------------------------------------------------
                    '----------------------------------------------------------------------
                    'Para el DataGrid de Cobranza
                    '----------------------------------------------------------------------
                    Dim FUNCIONARIO_COBRO As New DataGridViewTextBoxColumn
                    With FUNCIONARIO_COBRO
                        .HeaderText = "FUNCIONARIO"
                        .Name = "FUNCIONARIO"
                        .DataPropertyName = "FUNCIONARIO"
                        .Width = 180
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .ReadOnly = True
                    End With

                    Dim CIUDAD_ORIGEN_FUNCI As New DataGridViewTextBoxColumn
                    With CIUDAD_ORIGEN_FUNCI
                        .HeaderText = "ORIGEN"
                        .Name = "ORIGEN"
                        .DataPropertyName = "ORIGEN"
                        .Width = 60
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With

                    Dim TOTALCOBROFUNCI As New DataGridViewTextBoxColumn
                    With TOTALCOBROFUNCI
                        .HeaderText = "TOTAL"
                        .Name = "TOTAL"
                        .DataPropertyName = "TOTAL"
                        .Width = 70
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .DefaultCellStyle.Format = "N2"
                        .DefaultCellStyle.NullValue = "0,00"
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With
                    '----------------------------------------------------------------------

                    '----------------------------------------------------------------------
                    'Para el DataGrid de Comisiones de los funcionarios de Pasaje
                    '----------------------------------------------------------------------
                    Dim ID_FUNCIONARIO As New DataGridViewTextBoxColumn
                    With ID_FUNCIONARIO
                        .HeaderText = "ID"
                        .Name = "IDFUNCIONARIO"
                        .DataPropertyName = "IDFUNCIONARIO"
                        .Width = 40
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With

                    Dim NOMBRE_FUNCIONARIO As New DataGridViewTextBoxColumn
                    With NOMBRE_FUNCIONARIO
                        .HeaderText = "FUNCIONARIO"
                        .Name = "FUNCIONARIO"
                        .DataPropertyName = "FUNCIONARIO"
                        .Width = 180
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With

                    Dim ORIGEN_FUNCIONARIO As New DataGridViewTextBoxColumn
                    With ORIGEN_FUNCIONARIO
                        .HeaderText = "ORIGEN"
                        .Name = "ORIGEN"
                        .DataPropertyName = "ORIGEN"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .ReadOnly = True
                    End With

                    Dim PORCENTAJE_FUNCIONARIO As New DataGridViewTextBoxColumn
                    With PORCENTAJE_FUNCIONARIO
                        .HeaderText = "PORCENTAJE"
                        .Name = "PORCENTAJE"
                        .DataPropertyName = "PORCENTAJE"
                        .Width = 70
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .DefaultCellStyle.Format = "N2"
                        .DefaultCellStyle.NullValue = "0,00"
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .ReadOnly = True
                    End With

                    Dim TOTAL_FUNCIONARIO As New DataGridViewTextBoxColumn
                    With TOTAL_FUNCIONARIO
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

                    Dim COMISION_FUNCIONARIO As New DataGridViewTextBoxColumn
                    With COMISION_FUNCIONARIO
                        .HeaderText = "COMISION"
                        .Name = "COMISION"
                        .DataPropertyName = "COMISION"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .DefaultCellStyle.Format = "N2"
                        .DefaultCellStyle.NullValue = "0,00"
                        .ReadOnly = True
                    End With
                    '----------------------------------------------------------------------


                    ' Funcion para obtener los rangos de porcentajes
                    dsPorcentaje = ObjComisiones.ListarPorcentajeEjecutivoPasaje()
                    If Not IsNothing(dsPorcentaje) Then
                        dvPorcentaje = dsPorcentaje.Tables(0).DefaultView

                        dgdPorcentaje.DataSource = dvPorcentaje

                        With dgdPorcentaje
                            .Columns.AddRange(TIPO_FUNCI_PORCENTAJE, BONO_EJEC_PASAJE)
                        End With
                    End If

                    '----------------------------------------------------------------------
                    'Función para obtener la venta de documentos por funcionario
                    dsVentaTotal = ObjComisiones.ListarVentaEjecutivoPasaje()
                    If Not IsNothing(dsVentaTotal) Then
                        dvVentaTotal = dsVentaTotal.Tables(0).DefaultView
                        DGV4.DataSource = dvVentaTotal

                        With DGV4
                            .Columns.AddRange(ORIGEN, TIPO_VENTA, TOTALVENTA)
                        End With

                        If dsVentaTotal.Tables(0).Rows.Count > 0 Then
                            dblTotalFuncionario = dsVentaTotal.Tables(0).Compute("Sum(TOTAL)", "")
                        Else
                            dblTotalFuncionario = 0
                        End If

                        lblDatoTotalVenta.Text = "S/. " & Math.Round(dblTotalFuncionario, 2)
                    End If

                    '----------------------------------------------------------------------
                    'Función para obtener la cobranza de documentos por funcionario
                    dsCobranzaTotal = ObjComisiones.ListarCobranzaTotalEjecutivoPasaje()
                    If Not IsNothing(dsCobranzaTotal) Then
                        dvCobranzaTotal = dsCobranzaTotal.Tables(0).DefaultView
                        dgdCobranza.DataSource = dvCobranzaTotal

                        With dgdCobranza
                            .Columns.AddRange(FUNCIONARIO_COBRO, CIUDAD_ORIGEN_FUNCI, TOTALCOBROFUNCI)
                        End With

                        If dsCobranzaTotal.Tables(0).Rows.Count > 0 Then
                            dblTotalCobranzaFuncionario = dsCobranzaTotal.Tables(0).Compute("Sum(TOTAL)", "")
                        Else
                            dblTotalCobranzaFuncionario = 0
                        End If

                        lblDatoTotalCobranza.Text = "S/. " & Math.Round(dblTotalCobranzaFuncionario, 2)
                    End If

                    '-----------------------------------------------------------------
                    'Función para calcular las comisiones de los funcionarios de pasaje
                    dsComisionTotal = ObjComisiones.SP_L_SERVICIOS_FUNCI_MONTO()
                    If Not IsNothing(dsComisionTotal) Then
                        dvComisionTotal = dsComisionTotal.DefaultView
                        dgdComision.DataSource = dvComisionTotal

                        With dgdComision
                            .Columns.AddRange(ID_FUNCIONARIO, NOMBRE_FUNCIONARIO, ORIGEN_FUNCIONARIO, PORCENTAJE_FUNCIONARIO, TOTAL_FUNCIONARIO, COMISION_FUNCIONARIO)
                        End With
                        If dsComisionTotal.Rows.Count > 0 Then
                            txtcomi_factu_funci.Text = Math.Round(dsComisionTotal.Compute("Sum(COMISION)", ""), 2).ToString()
                        End If

                    End If


                End If
            End If


        Catch ex As Exception
            Cursor = Cursors.Default
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DTPFECHAINICIO_funci_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DTPFECHAINICIO_funci.ValueChanged
        'hlamas 06-01-2014
        Llenar_Funcionarios()
    End Sub

    Private Sub dgvconsulFunci3_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvconsulFunci3.CellContentClick

    End Sub
End Class