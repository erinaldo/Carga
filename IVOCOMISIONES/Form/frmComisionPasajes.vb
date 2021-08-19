Public Class frmComisionPasajes

    'Instancia la Clase General
    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL

    'Dataview para listar los funcionarios
    Dim dvFuncionarios As New DataView

    'Dataset y datatable para cargar el treeview
    Dim dsArbol As DataSet
    Dim TablaArbol As DataTable

    'Datarow para agregar filas al datatable Arbol
    Dim FilaArbol As DataRow

    Dim dtHijo As DataTable
    Dim dvHijo As DataView
    Dim Nivel As Integer = 0

    'Variable nodo que se agrega al treeview
    Dim Nodo As TreeNode

    'Declaramos una varibale instancia la clase de Comisiones
    Dim ObjComisiones As ClsLbTepsa.dtoComisiones = New ClsLbTepsa.dtoComisiones

    'Variable para obtener el tipo de funcionario
    Dim strIdTipoFuncionario As String = String.Empty

    'Variables para obtener las ventas por funcionario
    Dim dsVenta As DataSet
    Dim dsMeta As DataSet
    Dim dsBase As DataSet

    'Variables para Obtener los Porcentajes y Bonos por Funcionario
    Dim dsPorcentaje As DataSet

    'Variables para Obtener las Cobranzas por Funcionario
    Dim dsCobranza As DataSet
    Dim iContadorCobranzaLima As Integer = 0
    Dim iContadorCobranzaProv As Integer = 0
    Dim dblDatoDivisionBaseLima As Double = 0
    Dim dblDatoDivisionBaseProv As Double = 0

    'Variables para Obtener la Comision por Funcionario
    Dim dtComision As DataTable
    Dim dcComision As DataColumn
    Dim drComision As DataRow

    'Variables para obtener el Encabezado de Comisión por funcionario
    Dim dvEncabezadoComision As DataView
    Dim dvDetalleComision As DataView

    Dim dsReporteComision As DataSet

    'Declaramos una variable instancia la clase Reporte
    Dim ObjAgencias As ClsLbTepsa.dtoAgencias = New ClsLbTepsa.dtoAgencias

    '------------------------------------------------------------------------------------------------------------
    '--------------- Pestaña de Calculo de las Comisiones de los Funcionarios de Pasajes ------------------------
    '------------------------------------------------------------------------------------------------------------
    Private Sub frmComisionPasajes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized
            NuevoToolStripMenuItem.Visible = False
            EdicionToolStripMenuItem.Visible = False
            CancelarToolStripmenuItem.Visible = False
            AnularToolStripMenuItem.Visible = False
            ExportarToolStripMenuItem.Visible = False
            ImprimirToolStripMenuItem.Visible = False
            ConsultarToolStripMenuItem.Visible = False
            ReporteToolStripMenuItem.Visible = False
            CierreComisionesToolStripMenuItem.Visible = False

            Llenar_Funcionarios()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Llenar_Funcionarios()

        Dim NroFilaRecorrida As Integer = 0
        Dim Correlativo As Integer = 0
        Dim blnExisteNodoPadre As Boolean = False
        Dim blnExisteNodoHijo As Boolean = False

        'Consulta para obtener un listado de los funcionarios
        dvFuncionarios = ObjGeneral.SP_LISTAR_FUNCIONARIO_PASAJE()

        'Crear el dataset Arbol para cargar el treeview
        dsArbol = New DataSet("DataSetArbol")

        'Crear el datatable y agregarlo al dataset Arbol
        TablaArbol = dsArbol.Tables.Add("TablaArbol")

        'Crear las columnas del datatble arbol
        TablaArbol.Columns.Add("TipoFun", GetType(String))
        TablaArbol.Columns.Add("DesFun", GetType(String))
        TablaArbol.Columns.Add("IdPersona", GetType(String))
        TablaArbol.Columns.Add("IdentificadorNodo", GetType(Integer))
        TablaArbol.Columns.Add("IdentificadorPadre", GetType(Integer))

        'Recorrer el dataview para insertar los tipos de funcionario
        For i As Integer = 0 To dvFuncionarios.Table.Rows.Count - 1

            'Almacenamos los datos del tipo de funcionario
            If dsArbol.Tables("TablaArbol").Rows.Count = 0 Then
                FilaArbol = dsArbol.Tables("TablaArbol").NewRow()
                FilaArbol("TipoFun") = dvFuncionarios.Table().Rows(i)("TIPOFUN").ToString()
                FilaArbol("DesFun") = dvFuncionarios.Table().Rows(i)("DESFUNCI").ToString()
                FilaArbol("IdPersona") = ""
                FilaArbol("IdentificadorNodo") = i + 1
                FilaArbol("IdentificadorPadre") = i
                dsArbol.Tables("TablaArbol").Rows.Add(FilaArbol)
                Correlativo = Correlativo + 1
                NroFilaRecorrida = 1
                i = i - 1
            Else
                'Recorrer el datatable Arbol para verificar si el tipo de funcionario ya existe en la tabla Arbol
                For j As Integer = 0 To dsArbol.Tables("TablaArbol").Rows.Count - 1
                    If dvFuncionarios.Table().Rows(i)("TIPOFUN").ToString() = dsArbol.Tables("TablaArbol").Rows(j)("TipoFun").ToString Then
                        blnExisteNodoPadre = True
                        Exit For
                    Else
                        blnExisteNodoPadre = False
                    End If
                Next

                blnExisteNodoHijo = False

                'Si el tipo funcionario existe en la tabla Arbol
                If blnExisteNodoPadre = True Then

                    'Recorremos el dataview para insertar los funcionarios
                    For p As Integer = 0 To dvFuncionarios.Table.Rows.Count - 1

                        If dvFuncionarios.Table().Rows(i)("TIPOFUN").ToString() = dvFuncionarios.Table().Rows(p)("TIPOFUN").ToString() Then

                            'Recorrer para insertar el funcionario
                            For n As Integer = 0 To dsArbol.Tables("TablaArbol").Rows.Count - 1
                                If dvFuncionarios.Table().Rows(p)("USUARIO_PERSONAL").ToString() = dsArbol.Tables("TablaArbol").Rows(n)("TipoFun").ToString Then
                                    blnExisteNodoHijo = True
                                    Exit For
                                Else
                                    blnExisteNodoHijo = False
                                End If
                            Next

                            'Almacenamos los datos del funcionario
                            If blnExisteNodoHijo = False Then
                                FilaArbol = dsArbol.Tables("TablaArbol").NewRow()
                                FilaArbol("TipoFun") = dvFuncionarios.Table().Rows(p)("USUARIO_PERSONAL").ToString()
                                FilaArbol("DesFun") = ""
                                FilaArbol("IdPersona") = dvFuncionarios.Table().Rows(p)("IDUSUARIO_PERSONAL").ToString()
                                FilaArbol("IdentificadorNodo") = Correlativo + 1
                                FilaArbol("IdentificadorPadre") = NroFilaRecorrida
                                dsArbol.Tables("TablaArbol").Rows.Add(FilaArbol)
                                Correlativo = Correlativo + 1
                            End If
                        End If
                    Next
                ElseIf blnExisteNodoPadre = False Then
                    'Almacenamos los datos del tipo de funcionario
                    FilaArbol = dsArbol.Tables("TablaArbol").NewRow()
                    FilaArbol("TipoFun") = dvFuncionarios.Table().Rows(i)("TIPOFUN").ToString()
                    FilaArbol("DesFun") = dvFuncionarios.Table().Rows(i)("DESFUNCI").ToString()
                    FilaArbol("IdPersona") = ""
                    FilaArbol("IdentificadorNodo") = Correlativo + 1
                    FilaArbol("IdentificadorPadre") = 0
                    dsArbol.Tables("TablaArbol").Rows.Add(FilaArbol)
                    Correlativo = Correlativo + 1
                    i = i - 1
                    NroFilaRecorrida = Correlativo
                End If
            End If
        Next

        dtHijo = dsArbol.Tables("TablaArbol")
        dvHijo = dtHijo.DefaultView
        Nodo = TVFuncionario.Nodes.Add("TIPO DE FUNCIONARIO")

        For fila As Integer = 0 To dsArbol.Tables("TablaArbol").Rows.Count - 1
            If Convert.ToInt32(dsArbol.Tables("TablaArbol").Rows(fila)("IdentificadorPadre").ToString()) = 0 Then
                nodo = TVFuncionario.Nodes(0).Nodes.Add(Trim(dsArbol.Tables("TablaArbol").Rows(fila)("DesFun").ToString()))
                nodo.Tag = dsArbol.Tables("TablaArbol").Rows(fila)("TipoFun").ToString

                'Realizo un filtro dentro de la vista
                dvHijo.RowFilter = "IdentificadorPadre = " & Convert.ToInt32(dsArbol.Tables("TablaArbol").Rows(fila)("IdentificadorNodo").ToString())

                Dim a As Integer
                For a = 0 To dvHijo.Count - 1
                    'Agrego el nodo en el tercer nivel
                    nodo = TVFuncionario.Nodes(0).Nodes(Nivel).Nodes.Add(Trim(dvHijo.Item(a).Row("TipoFun").ToString()))
                    Me.TVFuncionario.Nodes(0).Nodes(Nivel).Nodes(a).Tag = dvHijo.Item(a).Row("IdPersona").ToString()
                Next

                'Expando todos los nodos de árbol secundario
                nodo.ExpandAll()
                Nivel = Nivel + 1
            End If
        Next

        TVFuncionario.ExpandAll()
    End Sub

    Private Sub TVFuncionario_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TVFuncionario.AfterSelect
        Try
            Cursor.Current = Cursors.AppStarting
            ObjComisiones.FECHA_INI = Me.DTPFechaInicio.Value.ToShortDateString
            ObjComisiones.FECHA_FINAL = Me.DTPFechaFinal.Value.ToShortDateString

            If Me.DTPFechaInicio.Value.Date.Day <> 26 Then
                MessageBox.Show("Las fecha de inicio de cálculo de las comisiones es del 26 del mes anterior al 25 del mes actual", "Titän", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If

            If Me.DTPFechaFinal.Value.Date.Day <> 25 Then
                MessageBox.Show("Las fecha de inicio de cálculo de las comisiones es del 26 del mes anterior al 25 del mes actual", "Titän", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If

            If DateDiff(DateInterval.Month, Me.DTPFechaInicio.Value.Date, Me.DTPFechaFinal.Value.Date) <> 1 Then
                MessageBox.Show("Las fechas seleccionadas para el cálculo de las comisiones no son correctas", "Titän", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If

            For i As Integer = 0 To Me.TVFuncionario.Nodes(0).Nodes.Count - 1
                For j As Integer = 0 To TVFuncionario.Nodes(0).Nodes(i).Nodes.Count - 1
                    If TVFuncionario.Nodes(0).Nodes(i).Nodes(j).IsSelected Then
                        ObjComisiones.IDUSUARIO_PERSONAL_FUNCI = Me.TVFuncionario.Nodes(0).Nodes(i).Nodes(j).Tag
                        lblFuncionario.Text = Me.TVFuncionario.Nodes(0).Nodes(i).Nodes(j).Tag + " - " + Me.TVFuncionario.Nodes(0).Nodes(i).Nodes(j).Text
                        strIdTipoFuncionario = Me.TVFuncionario.Nodes(0).Nodes(i).Tag
                        Exit For
                    End If
                Next
            Next

            LimpiarDatos()

            CalcularVentas()
            CalcularPorcBonoFuncionario()
            CalcularCobranzas()
            CalcularComision()
            Cursor.Current = Cursors.WaitCursor
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Private Sub LimpiarDatos()
        'Limpiar variables para el calculo de la venta
        dgdVenta.Columns.Clear()
        lblDatoMetaLima.Text = "0.00"
        lblDatoMetaProv.Text = "0.00"
        lblDatoTotalVentaLima.Text = "0.00"
        lblDatoTotalVentaProv.Text = "0.00"
        lblDatoBaseLima.Text = "0.00"
        lblDatoBaseProv.Text = "0.00"

        'Limpiar variables para el calculo del bono por funcionario
        dgdRangoFuncionario.Columns.Clear()
        lblDatoPorcLimaAnt.Text = "0.00"
        lblDatoBonoLimaAnt.Text = "0.00"
        lblDatoPorcProvAnt.Text = "0.00"
        lblDatoBonoProvAnt.Text = "0.00"
        lblDatoPorcLimaNuevo.Text = "0.00"
        lblDatoBonoLimaNuevo.Text = "0.00"
        lblDatoPorcProvNuevo.Text = "0.00"
        lblDatoBonoProvNuevo.Text = "0.00"

        'Limpiar variables para el calculo de la cobranza
        dgdCobranza.Columns.Clear()
        lblDatoCantDocLimaAnt.Text = "0"
        lblDatoCantDocProvAnt.Text = "0"
        lblDatoCantDocLimaNuevo.Text = "0"
        lblDatoCantDocProvNuevo.Text = "0"
        lblDatoCobroDocLimaAnt.Text = "0.00"
        lblDatoCobroDocProvAnt.Text = "0.00"
        lblDatoCobroDocLimaNuevo.Text = "0.00"
        lblDatoCobroDocProvNuevo.Text = "0.00"
        iContadorCobranzaLima = 0
        iContadorCobranzaProv = 0

        'Limpiar variables para el calculo de la comision
        dgdComision.Columns.Clear()
        lblDatoTotalComision.Text = "0.00"

        Me.Refresh()
    End Sub

    '------------------------------------------ Ventas por Funcionario ------------------------------------------
    Private Sub CalcularVentas()
        Try
            'Obtener la meta del funcionario Lima y Provincia
            dsMeta = ObjComisiones.ObtnerMetaFuncionarioPasaje
            If Not IsNothing(dsMeta) Then
                If dsMeta.Tables(0).Rows.Count > 0 Then
                    For Fila As Integer = 0 To dsMeta.Tables(0).Rows.Count - 1
                        If Convert.ToInt32(dsMeta.Tables(0).Rows(Fila)("ID_CIUDAD").ToString) = 1 Then
                            lblDatoMetaLima.Text = FormatNumber(Convert.ToDouble(lblDatoMetaLima.Text) + Convert.ToDouble(dsMeta.Tables(0).Rows(Fila)("MONTO").ToString), 2).ToString
                        ElseIf Convert.ToInt32(dsMeta.Tables(0).Rows(Fila)("ID_CIUDAD").ToString) = 2 Then
                            lblDatoMetaProv.Text = FormatNumber(Convert.ToDouble(lblDatoMetaProv.Text) + Convert.ToDouble(dsMeta.Tables(0).Rows(Fila)("MONTO").ToString), 2).ToString
                        End If
                    Next
                Else
                    lblDatoMetaLima.Text = "0.00"
                    lblDatoMetaProv.Text = "0.00"
                End If
            End If

            'Obtener la venta del funcionario Lima y Provincia
            dsVenta = ObjComisiones.ListarVentaTotalFuncionarioPasaje()
            If Not IsNothing(dsVenta) Then
                dgdVenta.Columns.Clear()
                If dsVenta.Tables(0).Rows.Count > 0 Then
                    AgregarColumnasVentas()
                    dgdVenta.DataSource = dsVenta.Tables(0)
                Else

                End If
            End If

            If dsVenta.Tables(0).Rows.Count > 0 Then
                For FilaVenta As Integer = 0 To dsVenta.Tables(0).Rows.Count - 1
                    If dsVenta.Tables(0).Rows(FilaVenta)("ORIGEN").ToString = "LIMA" Then
                        lblDatoTotalVentaLima.Text = FormatNumber(Convert.ToDouble(lblDatoTotalVentaLima.Text) + Convert.ToDouble(dsVenta.Tables(0).Rows(FilaVenta)("TOTAL").ToString), 2).ToString
                    ElseIf dsVenta.Tables(0).Rows(FilaVenta)("ORIGEN").ToString = "PROVINCIA" Then
                        lblDatoTotalVentaProv.Text = FormatNumber(Convert.ToDouble(lblDatoTotalVentaProv.Text) + Convert.ToDouble(dsVenta.Tables(0).Rows(FilaVenta)("TOTAL").ToString), 2).ToString
                    End If
                Next
            Else
                lblDatoTotalVentaLima.Text = "0.00"
                lblDatoTotalVentaProv.Text = "0.00"
            End If

            'Obtener la sumatoria de bases historicas de clientes Lima y Provincia
            dsBase = ObjComisiones.ListarBaseTotalFuncionarioPasaje(strIdTipoFuncionario)
            If Not IsNothing(dsBase) Then
                If dsBase.Tables(0).Rows.Count > 0 Then
                    For Fila As Integer = 0 To dsBase.Tables(0).Rows.Count - 1
                        If Convert.ToInt32(dsBase.Tables(0).Rows(Fila)("ID_CIUDAD").ToString) = 1 Then
                            lblDatoBaseLima.Text = FormatNumber(Convert.ToDouble(lblDatoBaseLima.Text) + Convert.ToDouble(dsBase.Tables(0).Rows(Fila)("BASE").ToString), 2).ToString
                        ElseIf Convert.ToInt32(dsBase.Tables(0).Rows(Fila)("ID_CIUDAD").ToString) = 2 Then
                            lblDatoBaseProv.Text = FormatNumber(Convert.ToDouble(lblDatoBaseProv.Text) + Convert.ToDouble(dsBase.Tables(0).Rows(Fila)("BASE").ToString), 2).ToString
                        End If
                    Next
                Else
                    lblDatoBaseLima.Text = "0.00"
                    lblDatoBaseProv.Text = "0.00"
                End If
            End If

            lblDatoBaseCalculo.Text = FormatNumber(Convert.ToDouble(lblDatoTotalVentaLima.Text.Trim) - Convert.ToDouble(lblDatoBaseLima.Text.Trim), 2)

            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Private Sub AgregarColumnasVentas()
        Dim Origen As New DataGridViewTextBoxColumn
        With Origen
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim TipoVenta As New DataGridViewTextBoxColumn
        With TipoVenta
            .HeaderText = "TIPO VENTA"
            .Name = "TIPOVENTA"
            .DataPropertyName = "TIPOVENTA"
            .Width = 120
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With

        Dim TotalVenta As New DataGridViewTextBoxColumn
        With TotalVenta
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

        Dim Funcionario As New DataGridViewTextBoxColumn
        With Funcionario
            .HeaderText = "FUNCIONARIO"
            .Name = "FUNCIONARIO"
            .DataPropertyName = "FUNCIONARIO"
            .Visible = False
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        dgdVenta.Columns.AddRange(Origen, TipoVenta, TotalVenta, Funcionario)

    End Sub

    '------------------------------------------- Bono por Funcionario -------------------------------------------
    Private Sub CalcularPorcBonoFuncionario()
        Try
            'Obtener el Porcentaje y Bono por Funcionario Lima y Provincia
            Dim iValor As Double = 0
            dsPorcentaje = ObjComisiones.ListarPorcentajePasaje()
            If Not IsNothing(dsPorcentaje) Then
                dgdRangoFuncionario.Columns.Clear()
                If dsPorcentaje.Tables(0).Rows.Count > 0 Then
                    AgregarColumnasPorcBonoFuncionario()
                    dgdRangoFuncionario.DataSource = dsPorcentaje.Tables(0)

                    'Calculo del Porcentaje y Bono de Lima para Calculo de Comisiones Hasta el 26/09/2012
                    If Convert.ToDouble(lblDatoMetaLima.Text.Trim) > 0 Then
                        ObjComisiones.Origen = 1
                        iValor = Convert.ToDouble(lblDatoTotalVentaLima.Text.Trim) - Convert.ToDouble(lblDatoBaseLima.Text.Trim)
                        'lblDatoPorcLimaAnt.Text = FormatNumber((Convert.ToDouble(lblDatoTotalVentaLima.Text.Trim) / Convert.ToDouble(lblDatoMetaLima.Text.Trim)) * 100, 2).ToString
                        lblDatoPorcLimaAnt.Text = FormatNumber((Convert.ToDouble(iValor) / Convert.ToDouble(lblDatoMetaLima.Text.Trim)) * 100, 2).ToString

                        ObjComisiones.PorcentajeVentaLima = Convert.ToDouble(lblDatoPorcLimaAnt.Text.Trim)
                        lblDatoBonoLimaAnt.Text = ObjComisiones.ObtenerBonoPenalidadPasaje.ToString()
                    Else
                        lblDatoPorcLimaAnt.Text = "0.00"
                        lblDatoBonoLimaAnt.Text = "0.00"
                    End If

                    'Calculo del Porcentaje y Bono de Provincia para Calculo de Comisiones Hasta el 26/09/2012
                    If Convert.ToDouble(lblDatoMetaProv.Text.Trim) > 0 Then
                        ObjComisiones.Origen = 2
                        iValor = Convert.ToDouble(lblDatoTotalVentaProv.Text.Trim) - Convert.ToDouble(lblDatoBaseProv.Text.Trim)
                        'lblDatoPorcProvAnt.Text = FormatNumber((Convert.ToDouble(lblDatoTotalVentaProv.Text.Trim) / Convert.ToDouble(lblDatoMetaProv.Text.Trim)) * 100, 2).ToString
                        lblDatoPorcProvAnt.Text = FormatNumber((Convert.ToDouble(iValor) / Convert.ToDouble(lblDatoMetaProv.Text.Trim)) * 100, 2).ToString
                        ObjComisiones.PorcentajeVentaProvincia = Convert.ToDouble(lblDatoPorcProvAnt.Text.Trim)
                        lblDatoBonoProvAnt.Text = ObjComisiones.ObtenerBonoPenalidadPasaje.ToString()
                    Else
                        lblDatoPorcProvAnt.Text = "0.00"
                        lblDatoBonoProvAnt.Text = "0.00"
                    End If

                    'Calculo del Porcentaje y Bono de Lima para Calculo de Comisiones Desde el 26/09/2012
                    If Convert.ToDouble(lblDatoMetaLima.Text.Trim) > 0 Then
                        ObjComisiones.Origen = 1
                        iValor = Convert.ToDouble(lblDatoTotalVentaLima.Text.Trim) - Convert.ToDouble(lblDatoBaseLima.Text.Trim)
                        'lblDatoPorcLimaNuevo.Text = FormatNumber(((Convert.ToDouble(lblDatoTotalVentaLima.Text.Trim) - Convert.ToDouble(lblDatoBaseLima.Text.Trim)) / Convert.ToDouble(lblDatoMetaLima.Text.Trim)) * 100, 2).ToString
                        lblDatoPorcLimaNuevo.Text = FormatNumber(((Convert.ToDouble(iValor)) / Convert.ToDouble(lblDatoMetaLima.Text.Trim)) * 100, 2).ToString
                        ObjComisiones.PorcentajeVentaLima = Convert.ToDouble(lblDatoPorcLimaNuevo.Text.Trim)
                        lblDatoBonoLimaNuevo.Text = ObjComisiones.ObtenerBonoPenalidadPasaje.ToString()
                    Else
                        lblDatoPorcLimaNuevo.Text = "0.00"
                        lblDatoBonoLimaNuevo.Text = "0.00"
                    End If

                    'Calculo del Porcentaje y Bono de Provincia para Calculo de Comisiones Desde el 26/09/2012
                    If Convert.ToDouble(lblDatoMetaProv.Text.Trim) > 0 Then
                        ObjComisiones.Origen = 2
                        iValor = Convert.ToDouble(lblDatoTotalVentaProv.Text.Trim) - Convert.ToDouble(lblDatoBaseProv.Text.Trim)
                        'lblDatoPorcProvNuevo.Text = FormatNumber(((Convert.ToDouble(lblDatoTotalVentaProv.Text.Trim) - Convert.ToDouble(lblDatoBaseProv.Text.Trim)) / Convert.ToDouble(lblDatoMetaProv.Text.Trim)) * 100, 2).ToString
                        lblDatoPorcProvNuevo.Text = FormatNumber(((Convert.ToDouble(iValor)) / Convert.ToDouble(lblDatoMetaProv.Text.Trim)) * 100, 2).ToString
                        ObjComisiones.PorcentajeVentaProvincia = Convert.ToDouble(lblDatoPorcProvNuevo.Text.Trim)
                        lblDatoBonoProvNuevo.Text = ObjComisiones.ObtenerBonoPenalidadPasaje.ToString()
                    Else
                        lblDatoPorcProvNuevo.Text = "0.00"
                        lblDatoBonoProvNuevo.Text = "0.00"
                    End If
                Else

                End If
            End If
            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Private Sub AgregarColumnasPorcBonoFuncionario()
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

        dgdRangoFuncionario.Columns.AddRange(CIUDAD, RANGO, BONO)

    End Sub

    '----------------------------------------- Cobranza por Funcionario -----------------------------------------
    Private Sub CalcularCobranzas()
        Dim blnOk As Boolean = False
        Try
            'Obtener laa cobranzas del funcionario en Lima y Provincia
            dsCobranza = ObjComisiones.ListarCobranzaTotalFuncionarioPasaje2(strIdTipoFuncionario)
            If Not IsNothing(dsCobranza) Then
                dgdCobranza.Columns.Clear()
                If dsCobranza.Tables(1).Rows.Count > 0 Then
                    AgregarColumnasCobranza()
                    dgdCobranza.DataSource = dsCobranza.Tables(1)

                    'Obtener los montos cobrados de Lima y Provincia para Calculo de Comisiones por funcionario
                    For Index As Integer = 0 To dsCobranza.Tables(1).Rows.Count - 1
                        If Convert.ToInt32(dsCobranza.Tables(1).Rows(Index).Item("ID").ToString) = 1 And dsCobranza.Tables(1).Rows(Index).Item("ORIGEN").ToString = "LIMA" Then
                            lblDatoCobroDocLimaAnt.Text = FormatNumber(Convert.ToDouble(lblDatoCobroDocLimaAnt.Text) + Convert.ToDouble(dsCobranza.Tables(1).Rows(Index).Item("Total").ToString), 2).ToString
                        ElseIf Convert.ToInt32(dsCobranza.Tables(1).Rows(Index).Item("ID").ToString) = 1 And dsCobranza.Tables(1).Rows(Index).Item("ORIGEN").ToString = "PROVINCIA" Then
                            lblDatoCobroDocProvAnt.Text = FormatNumber(Convert.ToDouble(lblDatoCobroDocProvAnt.Text) + Convert.ToDouble(dsCobranza.Tables(1).Rows(Index).Item("Total").ToString), 2).ToString
                        ElseIf Convert.ToInt32(dsCobranza.Tables(1).Rows(Index).Item("ID").ToString) = 2 And dsCobranza.Tables(1).Rows(Index).Item("ORIGEN").ToString = "LIMA" Then
                            lblDatoCobroDocLimaNuevo.Text = FormatNumber(Convert.ToDouble(lblDatoCobroDocLimaNuevo.Text) + Convert.ToDouble(dsCobranza.Tables(1).Rows(Index).Item("Total").ToString), 2).ToString
                            iContadorCobranzaLima = iContadorCobranzaLima + 1
                        ElseIf Convert.ToInt32(dsCobranza.Tables(1).Rows(Index).Item("ID").ToString) = 2 And dsCobranza.Tables(1).Rows(Index).Item("ORIGEN").ToString = "PROVINCIA" Then
                            lblDatoCobroDocProvNuevo.Text = FormatNumber(Convert.ToDouble(lblDatoCobroDocProvNuevo.Text) + Convert.ToDouble(dsCobranza.Tables(1).Rows(Index).Item("Total").ToString), 2).ToString
                            iContadorCobranzaProv = iContadorCobranzaProv + 1
                        End If
                    Next
                    blnOk = True
                Else
                    MessageBox.Show("No existen documentos cancelados en el rango de fecha seleccionado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    lblDatoCantDocLimaAnt.Text = "0"
                    lblDatoCantDocProvAnt.Text = "0"
                    lblDatoCantDocLimaNuevo.Text = "0"
                    lblDatoCantDocProvNuevo.Text = "0"
                    blnOk = False
                    Cursor.Current = Cursors.WaitCursor
                End If

                If blnOk = True Then
                    'Obtener la cantidad de documentos cobrados de Lima y Provincia para Calculo de Comisiones por funcionario
                    If dsCobranza.Tables(0).Rows.Count > 0 Then
                        For Index As Integer = 0 To dsCobranza.Tables(0).Rows.Count - 1
                            If Convert.ToInt32(dsCobranza.Tables(0).Rows(Index).Item("ID").ToString) = 1 And dsCobranza.Tables(0).Rows(Index).Item("ORIGEN").ToString = "LIMA" Then
                                lblDatoCantDocLimaAnt.Text = Convert.ToInt32(lblDatoCantDocLimaAnt.Text) + Convert.ToInt32(dsCobranza.Tables(0).Rows(Index).Item("Cantidad").ToString)
                            ElseIf Convert.ToInt32(dsCobranza.Tables(0).Rows(Index).Item("ID").ToString) = 1 And dsCobranza.Tables(0).Rows(Index).Item("ORIGEN").ToString = "PROVINCIA" Then
                                lblDatoCantDocProvAnt.Text = Convert.ToInt32(lblDatoCantDocProvAnt.Text) + Convert.ToInt32(dsCobranza.Tables(0).Rows(Index).Item("Cantidad").ToString)
                            ElseIf Convert.ToInt32(dsCobranza.Tables(0).Rows(Index).Item("ID").ToString) = 2 And dsCobranza.Tables(0).Rows(Index).Item("ORIGEN").ToString = "LIMA" Then
                                lblDatoCantDocLimaNuevo.Text = Convert.ToInt32(lblDatoCantDocLimaNuevo.Text) + Convert.ToInt32(dsCobranza.Tables(0).Rows(Index).Item("Cantidad").ToString)
                            ElseIf Convert.ToInt32(dsCobranza.Tables(0).Rows(Index).Item("ID").ToString) = 2 And dsCobranza.Tables(0).Rows(Index).Item("ORIGEN").ToString = "PROVINCIA" Then
                                lblDatoCantDocProvNuevo.Text = Convert.ToInt32(lblDatoCantDocProvNuevo.Text) + Convert.ToInt32(dsCobranza.Tables(0).Rows(Index).Item("Cantidad").ToString)
                            End If
                        Next
                    End If
                End If

                If iContadorCobranzaLima > 0 Then
                    dblDatoDivisionBaseLima = Convert.ToDouble(lblDatoBaseLima.Text) / iContadorCobranzaLima
                End If
                If iContadorCobranzaProv > 0 Then
                    dblDatoDivisionBaseProv = Convert.ToDouble(lblDatoBaseProv.Text) / iContadorCobranzaProv
                End If
                Me.Refresh()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Private Sub AgregarColumnasCobranza()
        Dim ID As New DataGridViewTextBoxColumn
        With ID
            .HeaderText = "ID"
            .Name = "ID"
            .DataPropertyName = "ID"
            .Width = 10
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .Visible = False
        End With

        Dim DOCUMENTOS As New DataGridViewTextBoxColumn
        With DOCUMENTOS
            .HeaderText = "DOCUMENTOS"
            .Name = "DOCUMENTOS"
            .DataPropertyName = "DOCUMENTOS"
            .Width = 120
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim TIPOVENTA As New DataGridViewTextBoxColumn
        With TIPOVENTA
            .HeaderText = "TIPOVENTA"
            .Name = "TIPOVENTA"
            .DataPropertyName = "TIPOVENTA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FUNCIONARIO As New DataGridViewTextBoxColumn
        With FUNCIONARIO
            .HeaderText = "FUNCIONARIO"
            .Name = "FUNCIONARIO"
            .DataPropertyName = "FUNCIONARIO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
            .Visible = False
        End With

        Dim TOTAL As New DataGridViewTextBoxColumn
        With TOTAL
            .HeaderText = "TOTAL"
            .Name = "TOTAL"
            .DataPropertyName = "TOTAL"
            .Width = 100
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With

        dgdCobranza.Columns.AddRange(ID, DOCUMENTOS, TIPOVENTA, ORIGEN, FUNCIONARIO, TOTAL)

    End Sub

    '----------------------------------------- Comisión por Funcionario -----------------------------------------
    Private Sub CalcularComision()
        Try
            'Obtener la comision de los documentos cobrandos del funcionario en Lima y Provincia
            If Not IsNothing(dsCobranza) Then
                dgdComision.Columns.Clear()
                If dsCobranza.Tables(1).Rows.Count > 0 Then
                    AgregarColumnasComision()

                    dtComision = dsCobranza.Tables(1).Copy

                    dcComision = New DataColumn
                    dcComision.ColumnName = "BASE"
                    dtComision.Columns.Add(dcComision)

                    dcComision = New DataColumn
                    dcComision.ColumnName = "MONTO"
                    dtComision.Columns.Add(dcComision)

                    dcComision = New DataColumn
                    dcComision.ColumnName = "PORCFUNCIONARIO"
                    dtComision.Columns.Add(dcComision)

                    dcComision = New DataColumn
                    dcComision.ColumnName = "PORCCOMERCIAL"
                    dtComision.Columns.Add(dcComision)

                    dcComision = New DataColumn
                    dcComision.ColumnName = "PORCEQUIVALENTE"
                    dtComision.Columns.Add(dcComision)

                    dcComision = New DataColumn
                    dcComision.ColumnName = "COMISION"
                    dtComision.Columns.Add(dcComision)

                    For Index As Integer = 0 To dtComision.Rows.Count - 1
                        If Convert.ToInt32(dtComision.Rows(Index).Item("ID").ToString) = 1 And dtComision.Rows(Index).Item("ORIGEN").ToString = "LIMA" Then
                            If Convert.ToDouble(lblDatoBonoLimaAnt.Text) = 0 Then
                                dtComision.Rows(Index).Item("PORCFUNCIONARIO") = 3.0
                            Else
                                dtComision.Rows(Index).Item("PORCFUNCIONARIO") = Convert.ToDouble(lblDatoBonoLimaAnt.Text)
                            End If
                            dtComision.Rows(Index).Item("MONTO") = FormatNumber(Convert.ToDouble(dtComision.Rows(Index).Item("TOTAL").ToString), 2)
                            dtComision.Rows(Index).Item("PORCEQUIVALENTE") = Convert.ToDouble(dtComision.Rows(Index).Item("PORCFUNCIONARIO").ToString)
                            dtComision.Rows(Index).Item("COMISION") = FormatNumber((Convert.ToDouble(dtComision.Rows(Index).Item("MONTO").ToString) * Convert.ToDouble(dtComision.Rows(Index).Item("PORCEQUIVALENTE").ToString)) / 100, 2)
                        ElseIf Convert.ToInt32(dtComision.Rows(Index).Item("ID").ToString) = 1 And dtComision.Rows(Index).Item("ORIGEN").ToString = "PROVINCIA" Then
                            If Convert.ToDouble(lblDatoBonoProvAnt.Text) = 0 Then
                                dtComision.Rows(Index).Item("PORCFUNCIONARIO") = 3.0
                            Else
                                dtComision.Rows(Index).Item("PORCFUNCIONARIO") = Convert.ToDouble(lblDatoBonoProvAnt.Text)
                            End If
                            dtComision.Rows(Index).Item("MONTO") = FormatNumber(Convert.ToDouble(dtComision.Rows(Index).Item("TOTAL").ToString), 2)
                            dtComision.Rows(Index).Item("PORCEQUIVALENTE") = Convert.ToDouble(dtComision.Rows(Index).Item("PORCFUNCIONARIO").ToString)
                            dtComision.Rows(Index).Item("COMISION") = FormatNumber((Convert.ToDouble(dtComision.Rows(Index).Item("MONTO").ToString) * Convert.ToDouble(dtComision.Rows(Index).Item("PORCEQUIVALENTE").ToString)) / 100, 2)
                        ElseIf Convert.ToInt32(dtComision.Rows(Index).Item("ID").ToString) = 2 And dtComision.Rows(Index).Item("ORIGEN").ToString = "LIMA" Then
                            If Convert.ToDouble(lblDatoBonoLimaNuevo.Text) = 0 Then
                                dtComision.Rows(Index).Item("PORCFUNCIONARIO") = 3.0
                            Else
                                dtComision.Rows(Index).Item("PORCFUNCIONARIO") = Convert.ToDouble(lblDatoBonoLimaNuevo.Text)
                            End If
                            dtComision.Rows(Index).Item("BASE") = FormatNumber(dblDatoDivisionBaseLima, 2)

                            'If Convert.ToDouble(dtComision.Rows(Index).Item("TOTAL").ToString) >= Convert.ToDouble(dtComision.Rows(Index).Item("BASE").ToString) Then
                            'dtComision.Rows(Index).Item("MONTO") = FormatNumber(Convert.ToDouble(dtComision.Rows(Index).Item("TOTAL").ToString) - Convert.ToDouble(dtComision.Rows(Index).Item("BASE").ToString), 2)
                            dtComision.Rows(Index).Item("MONTO") = FormatNumber(Convert.ToDouble(dtComision.Rows(Index).Item("TOTAL").ToString), 2)
                            'Else
                            'dtComision.Rows(Index).Item("MONTO") = "0.00"
                            'End If

                            dtComision.Rows(Index).Item("PORCCOMERCIAL") = FormatNumber(dsCobranza.Tables(2).Rows(0).Item("COMISION").ToString, 2)
                            dtComision.Rows(Index).Item("PORCEQUIVALENTE") = (Convert.ToDouble(dtComision.Rows(Index).Item("PORCFUNCIONARIO").ToString) * Convert.ToDouble(dtComision.Rows(Index).Item("PORCCOMERCIAL").ToString)) / 100
                            dtComision.Rows(Index).Item("COMISION") = FormatNumber((Convert.ToDouble(dtComision.Rows(Index).Item("MONTO").ToString) * Convert.ToDouble(dtComision.Rows(Index).Item("PORCEQUIVALENTE").ToString)) / 100, 2)
                        ElseIf Convert.ToInt32(dtComision.Rows(Index).Item("ID").ToString) = 2 And dtComision.Rows(Index).Item("ORIGEN").ToString = "PROVINCIA" Then
                            If Convert.ToDouble(lblDatoBonoProvNuevo.Text) = 0 Then
                                dtComision.Rows(Index).Item("PORCFUNCIONARIO") = 3.0
                            Else
                                dtComision.Rows(Index).Item("PORCFUNCIONARIO") = Convert.ToDouble(lblDatoBonoProvNuevo.Text)
                            End If
                            dtComision.Rows(Index).Item("BASE") = FormatNumber(dblDatoDivisionBaseProv, 2)

                            'If Convert.ToDouble(dtComision.Rows(Index).Item("TOTAL").ToString) >= Convert.ToDouble(dtComision.Rows(Index).Item("BASE").ToString) Then
                            'dtComision.Rows(Index).Item("MONTO") = FormatNumber(Convert.ToDouble(dtComision.Rows(Index).Item("TOTAL").ToString) - Convert.ToDouble(dtComision.Rows(Index).Item("BASE").ToString), 2)
                            dtComision.Rows(Index).Item("MONTO") = FormatNumber(Convert.ToDouble(dtComision.Rows(Index).Item("TOTAL").ToString), 2)
                            'Else
                            'dtComision.Rows(Index).Item("MONTO") = "0.00"
                            'End If

                            dtComision.Rows(Index).Item("PORCCOMERCIAL") = FormatNumber(dsCobranza.Tables(2).Rows(0).Item("COMISION").ToString, 2)
                            dtComision.Rows(Index).Item("PORCEQUIVALENTE") = (Convert.ToDouble(dtComision.Rows(Index).Item("PORCFUNCIONARIO").ToString) * Convert.ToDouble(dtComision.Rows(Index).Item("PORCCOMERCIAL").ToString)) / 100
                            dtComision.Rows(Index).Item("COMISION") = FormatNumber((Convert.ToDouble(dtComision.Rows(Index).Item("MONTO").ToString) * Convert.ToDouble(dtComision.Rows(Index).Item("PORCEQUIVALENTE").ToString)) / 100, 2)
                        End If
                    Next

                    For Index As Integer = 0 To dtComision.Rows.Count - 1
                        lblDatoTotalComision.Text = FormatNumber(Convert.ToDouble(lblDatoTotalComision.Text) + Convert.ToDouble(dtComision.Rows(Index).Item("COMISION").ToString), 2)
                    Next

                    dgdComision.DataSource = dtComision
                End If
            End If
            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Private Sub AgregarColumnasComision()
        Dim ID As New DataGridViewTextBoxColumn
        With ID
            .HeaderText = "ID"
            .Name = "ID"
            .DataPropertyName = "ID"
            .Width = 10
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .Visible = False
        End With

        Dim DOCUMENTOS As New DataGridViewTextBoxColumn
        With DOCUMENTOS
            .HeaderText = "DOCUMENTOS"
            .Name = "DOCUMENTOS"
            .DataPropertyName = "DOCUMENTOS"
            .Width = 120
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim TIPOVENTA As New DataGridViewTextBoxColumn
        With TIPOVENTA
            .HeaderText = "TIPOVENTA"
            .Name = "TIPOVENTA"
            .DataPropertyName = "TIPOVENTA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FUNCIONARIO As New DataGridViewTextBoxColumn
        With FUNCIONARIO
            .HeaderText = "FUNCIONARIO"
            .Name = "FUNCIONARIO"
            .DataPropertyName = "FUNCIONARIO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .ReadOnly = True
            .Visible = False
        End With

        Dim COBRANZA As New DataGridViewTextBoxColumn
        With COBRANZA
            .HeaderText = "COBRANZA"
            .Name = "TOTAL"
            .DataPropertyName = "TOTAL"
            .Width = 95
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With

        Dim BASE As New DataGridViewTextBoxColumn
        With BASE
            .HeaderText = "BASE"
            .Name = "BASE"
            .DataPropertyName = "BASE"
            .Width = 65
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
            .Visible = False
        End With

        Dim TOTAL As New DataGridViewTextBoxColumn
        With TOTAL
            .HeaderText = "MONTO TOTAL"
            .Name = "MONTO"
            .DataPropertyName = "MONTO"
            .Width = 110
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
            .Visible = False
        End With

        Dim PORCFUNCIONARIO As New DataGridViewTextBoxColumn
        With PORCFUNCIONARIO
            .HeaderText = "% FUNCIONARIO"
            .Name = "PORCFUNCIONARIO"
            .DataPropertyName = "PORCFUNCIONARIO"
            .Width = 120
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With

        Dim PORCCOMERCIAL As New DataGridViewTextBoxColumn
        With PORCCOMERCIAL
            .HeaderText = "% COMERCIAL"
            .Name = "PORCCOMERCIAL"
            .DataPropertyName = "PORCCOMERCIAL"
            .Width = 120
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With

        Dim PORCEQUIVALENTE As New DataGridViewTextBoxColumn
        With PORCEQUIVALENTE
            .HeaderText = "% EQUIVALENTE"
            .Name = "PORCEQUIVALENTE"
            .DataPropertyName = "PORCEQUIVALENTE"
            .Width = 120
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With

        Dim COMISION As New DataGridViewTextBoxColumn
        With COMISION
            .HeaderText = "COMISION"
            .Name = "COMISION"
            .DataPropertyName = "COMISION"
            .Width = 95
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With

        dgdComision.Columns.AddRange(ID, DOCUMENTOS, TIPOVENTA, ORIGEN, FUNCIONARIO, COBRANZA, BASE, TOTAL, PORCFUNCIONARIO, PORCCOMERCIAL, PORCEQUIVALENTE, COMISION)

    End Sub

    '------------------------------- Grabar Comisiones Calculadas por Funcionario -------------------------------
    Private Sub GrabarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GrabarToolStripMenuItem.Click
        Try
            ObjComisiones.FECHA_INI = Me.DTPFechaInicio.Value.ToShortDateString
            ObjComisiones.FECHA_FINAL = Me.DTPFechaFinal.Value.ToShortDateString

            ObjComisiones.IDUSUARIO_FUNCI_STRING = ""

            For i As Integer = 0 To Me.TVFuncionario.Nodes(0).Nodes.Count - 1
                For j As Integer = 0 To TVFuncionario.Nodes(0).Nodes(i).Nodes.Count - 1
                    If TVFuncionario.Nodes(0).Nodes(i).Nodes(j).IsSelected Then
                        ObjComisiones.IDUSUARIO_PERSONAL_FUNCI = Me.TVFuncionario.Nodes(0).Nodes(i).Nodes(j).Tag
                        strIdTipoFuncionario = Me.TVFuncionario.Nodes(0).Nodes(i).Tag
                        Exit For
                    End If
                Next
            Next

            ObjComisiones.IP = dtoUSUARIOS.IP
            ObjComisiones.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            ObjComisiones.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            ObjComisiones.IDROL_USUARIO = dtoUSUARIOS.IdRol
            ObjComisiones.MetaLima = Convert.ToDouble(lblDatoMetaLima.Text)
            ObjComisiones.MetaProvincia = Convert.ToDouble(lblDatoMetaProv.Text)

            'Registra la cabecera de la comision
            ObjComisiones.InsertCabeceraComisionCargaPasaje()

            'Registra los detalles de las comisiones por funcionario
            If ObjComisiones.EXISTE_COMISION = 0 Then
                'Registra el detalle de la venta del funcionario
                For iVenta As Integer = 0 To dsVenta.Tables(0).Rows.Count - 1
                    ObjComisiones.CONCEPTO = "VENTA"
                    ObjComisiones.NOMBRE_ORIGEN = dsVenta.Tables(0).Rows(iVenta)("ORIGEN").ToString.Trim
                    ObjComisiones.FORMA_PAGO = dsVenta.Tables(0).Rows(iVenta)("TIPOVENTA").ToString.Trim
                    ObjComisiones.TOTAL_FORMA_PAGO = Convert.ToDouble(dsVenta.Tables(0).Rows(iVenta)("TOTAL").ToString.Trim)

                    ObjComisiones.InsertDetalleComisionCargaPasaje()
                Next

                'Registra el detalle de la cobranza del funcionario
                For iCobranza As Integer = 0 To dsCobranza.Tables(1).Rows.Count - 1
                    ObjComisiones.CONCEPTO = "COBRANZA"
                    ObjComisiones.NOMBRE_ORIGEN = dsCobranza.Tables(1).Rows(iCobranza)("ORIGEN").ToString.Trim
                    ObjComisiones.FORMA_PAGO = dsCobranza.Tables(1).Rows(iCobranza)("TIPOVENTA").ToString.Trim
                    ObjComisiones.TOTAL_FORMA_PAGO = Convert.ToDouble(dsCobranza.Tables(1).Rows(iCobranza)("TOTAL").ToString.Trim)

                    ObjComisiones.InsertDetalleComisionCargaPasaje()
                Next

                'Registra el detalle de las comisiones del funcionario
                For icomi As Integer = 0 To dtComision.Rows.Count - 1
                    ObjComisiones.IDGRUPO = 0
                    ObjComisiones.GRUPO = ""
                    ObjComisiones.NOMBRE_ORIGEN = dtComision.Rows(icomi)("ORIGEN").ToString.Trim
                    ObjComisiones.TIPO_COBRANZA = dtComision.Rows(icomi)("TIPOVENTA").ToString.Trim
                    ObjComisiones.PORCENTAJE_COMISION = Convert.ToDouble(dtComision.Rows(icomi)("PORCEQUIVALENTE").ToString.Trim)
                    ObjComisiones.TOTAL_COBRANZA = Convert.ToDouble(dtComision.Rows(icomi)("MONTO").ToString.Trim)
                    ObjComisiones.TOTAL_COMISION = Convert.ToDouble(dtComision.Rows(icomi)("COMISION").ToString.Trim)

                    ObjComisiones.InsertTotalComisionCargaPasaje()
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '--------------- Pestaña de Consulta de las Comisiones de los Funcionarios de Pasajes -----------------------
    '------------------------------------------------------------------------------------------------------------
    Private Sub TCComisionPasajes_Selecting(sender As System.Object, e As System.Windows.Forms.TabControlCancelEventArgs) Handles TCComisionPasajes.Selecting
        Try
            If TCComisionPasajes.SelectedIndex = 0 Then
                GrabarToolStripMenuItem.Visible = True
                ConsultarToolStripMenuItem.Visible = False
                AnularToolStripMenuItem.Visible = False
                ReporteToolStripMenuItem.Visible = False
                CierreComisionesToolStripMenuItem.Visible = False
            ElseIf TCComisionPasajes.SelectedIndex = 1 Then
                GrabarToolStripMenuItem.Visible = False
                ConsultarToolStripMenuItem.Visible = True
                AnularToolStripMenuItem.Visible = True
                ReporteToolStripMenuItem.Visible = True
                CierreComisionesToolStripMenuItem.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ConsultarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConsultarToolStripMenuItem.Click
        Try
            ConsultarEncabezadoComision()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '------------------------------ Muestra Funcionarios con Comisiones Calculadas ------------------------------
    Private Sub ConsultarEncabezadoComision()
        Try
            ObjComisiones.FECHA_INI = Me.DTPFechaInicioConsulta.Value.ToShortDateString
            ObjComisiones.FECHA_FINAL = Me.DTPFechaFinalConsulta.Value.ToShortDateString

            dvEncabezadoComision = ObjComisiones.SP_COMISION_FUNCI_PASAJE()
            If Not IsNothing(dvEncabezadoComision) Then
                dgdConsultaCabeceraComision.Columns.Clear()
                If dvEncabezadoComision.Table.Rows.Count > 0 Then
                    AgregarColumnasEncabezadoComision()
                    dgdConsultaCabeceraComision.DataSource = dvEncabezadoComision.Table
                Else
                    MessageBox.Show("No existe comisión calculadas en el rango de fecha seleccionadas", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AgregarColumnasEncabezadoComision()
        Try
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

            Dim FUNCIONARIO As New DataGridViewTextBoxColumn
            With FUNCIONARIO
                .HeaderText = "FUNCIONARIO"
                .Name = "FUNCIONARIO"
                .DataPropertyName = "FUNCIONARIO"
                .Width = 240
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With

            Dim TIPO_FUNCI As New DataGridViewTextBoxColumn
            With TIPO_FUNCI
                .HeaderText = "TIPO FUNCIONARIO"
                .Name = "COMI_FUNCI"
                .DataPropertyName = "COMI_FUNCI"
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
            With NOMBRE_AGENCIA
                .HeaderText = "NOMBRE_AGENCIA"
                .Name = "NOMBRE_AGENCIA"
                .DataPropertyName = "NOMBRE_AGENCIA"
                .Width = 140
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With

            Dim FECHA_REGISTRO As New DataGridViewTextBoxColumn
            With FECHA_REGISTRO
                .HeaderText = "FECHA REGISTRO"
                .Name = "FECHA_REGISTRO"
                .DataPropertyName = "FECHA_REGISTRO"
                .Width = 130
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
                .Width = 90
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

            Dim IDAGENCIAS As New DataGridViewTextBoxColumn
            With IDAGENCIAS
                .HeaderText = "IDAGENCIAS"
                .Name = "IDAGENCIAS"
                .DataPropertyName = "IDAGENCIAS"
                .Width = 0
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N0"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
            With IDUSUARIO_PERSONAL
                .HeaderText = "IDUSUARIO_PERSONAL"
                .Name = "IDUSUARIO_PERSONAL"
                .DataPropertyName = "IDUSUARIO_PERSONAL"
                .Width = 0
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim IDUSUARIO_PERSONALMOD As New DataGridViewTextBoxColumn
            With IDUSUARIO_PERSONALMOD
                .HeaderText = "IDUSUARIO_PERSONALMOD"
                .Name = "IDUSUARIO_PERSONALMOD"
                .DataPropertyName = "IDUSUARIO_PERSONALMOD"
                .Width = 0
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim IDROL_USUARIO As New DataGridViewTextBoxColumn
            With IDROL_USUARIO
                .HeaderText = "IDROL_USUARIO"
                .Name = "IDROL_USUARIO"
                .DataPropertyName = "IDROL_USUARIO"
                .Width = 0
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim IDROL_USUARIOMOD As New DataGridViewTextBoxColumn
            With IDROL_USUARIOMOD
                .HeaderText = "IDROL_USUARIOMOD"
                .Name = "IDROL_USUARIOMOD"
                .DataPropertyName = "IDROL_USUARIOMOD"
                .Width = 0
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim IP As New DataGridViewTextBoxColumn
            With IP
                .HeaderText = "IP"
                .Name = "IP"
                .DataPropertyName = "IP"
                .Width = 0
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim IPMOD As New DataGridViewTextBoxColumn
            With IPMOD
                .HeaderText = "IPMOD"
                .Name = "IPMOD"
                .DataPropertyName = "IPMOD"
                .Width = 0
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim LOGIN As New DataGridViewTextBoxColumn
            With LOGIN
                .HeaderText = "LOGIN"
                .Name = "LOGIN"
                .DataPropertyName = "LOGIN"
                .Width = 0
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim IDFUNCIONARIO As New DataGridViewTextBoxColumn
            With IDFUNCIONARIO
                .HeaderText = "IDFUNCIONARIO"
                .Name = "IDFUNCIONARIO"
                .DataPropertyName = "IDFUNCIONARIO"
                .Width = 0
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim FECHA_ACTUALIZACION As New DataGridViewTextBoxColumn
            With FECHA_ACTUALIZACION
                .HeaderText = "FECHA_ACTUALIZACION"
                .Name = "FECHA_ACTUALIZACION"
                .DataPropertyName = "FECHA_ACTUALIZACION"
                .Width = 0
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim IDESTADO_REGISTRO As New DataGridViewTextBoxColumn
            With IDESTADO_REGISTRO
                .HeaderText = "IDESTADO_REGISTRO"
                .Name = "IDESTADO_REGISTRO"
                .DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 0
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .Visible = False
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

            Dim CERRADO1 As New DataGridViewTextBoxColumn
            With CERRADO1
                .HeaderText = "CERRADO1"
                .Name = "CERRADO1"
                .DataPropertyName = "CERRADO1"
                .Width = 0
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim METALIMA As New DataGridViewTextBoxColumn
            With METALIMA
                .HeaderText = "METALIMA"
                .Name = "METALIMA"
                .DataPropertyName = "META_LIMA"
                .Width = 0
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim METAPROVINCIA As New DataGridViewTextBoxColumn
            With METAPROVINCIA
                .HeaderText = "METAPROVINCIA"
                .Name = "METAPROVINCIA"
                .DataPropertyName = "META_PROVINCIA"
                .Width = 0
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            dgdConsultaCabeceraComision.Columns.AddRange(IDCOMI_CALCU_FUNCI, FUNCIONARIO, TIPO_FUNCI, NOMBRE_AGENCIA, FECHA_REGISTRO, CREADOR, FECHA_INI, FECHA_FINAL, ESTADO_REGISTRO, IDAGENCIAS, IDUSUARIO_PERSONAL, IDUSUARIO_PERSONALMOD, IDROL_USUARIO, IDROL_USUARIOMOD, IP, IPMOD, LOGIN, IDFUNCIONARIO, FECHA_ACTUALIZACION, IDESTADO_REGISTRO, ID_COMI_FUNCI, CERRADO, CERRADO1, METALIMA, METAPROVINCIA)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '------------------------- Muestra Detalle de Comisiones Calculadas por Funcionario -------------------------
    Private Sub dgdConsultaCabeceraComision_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdConsultaCabeceraComision.CellEnter
        Try
            ObjComisiones.IDCOMI_CALCU_FUNCI = dgdConsultaCabeceraComision.CurrentRow.Cells("IDCOMI_CALCU_FUNCI").Value
            dvDetalleComision = ObjComisiones.SP_L_COMI_CONCE_detall_FUNCI(dgdConsultaCabeceraComision.CurrentRow.Cells("id_comi_funci").Value)
            If Not IsNothing(dvDetalleComision) Then
                dgdConsultaDetalleComision.Columns.Clear()
                If dvDetalleComision.Table.Rows.Count > 0 Then
                    AgregarColumnasDetalleComision()
                    dgdConsultaDetalleComision.DataSource = dvDetalleComision.Table

                    lblDatoConsultaTotalComision.Text = "0.00"
                    For Index As Integer = 0 To dvDetalleComision.Table.Rows.Count - 1
                        lblDatoConsultaTotalComision.Text = FormatNumber(Convert.ToDouble(lblDatoConsultaTotalComision.Text) + Convert.ToDouble(dvDetalleComision.Table.Rows(Index).Item("Comision").ToString), 2)
                    Next
                Else

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AgregarColumnasDetalleComision()
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
            .Width = 200
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
            .Visible = False
        End With

        Dim GRUPO As New DataGridViewTextBoxColumn
        With GRUPO
            .HeaderText = "GRUPO"
            .Name = "GRUPO"
            .DataPropertyName = "GRUPO"
            .Width = 90
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
            .Visible = False
        End With

        Dim IDCOMI_CALCU As New DataGridViewTextBoxColumn
        With IDCOMI_CALCU
            .HeaderText = "ID"
            .Name = "IDCOMI_CALCU"
            .DataPropertyName = "IDCOMI_CALCU_FUNCI"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            '.DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .Visible = False
        End With

        dgdConsultaDetalleComision.Columns.AddRange(CIUDAD_COMI, TIPO_COMI, PORCENTAJE_PASAJE, TOTAL_COMI_PASAJE, COMISION, IDGRUPO, GRUPO, IDCOMI_CALCU)

    End Sub

    '----------------------------- Reporte de Comisiones Calculadas por Funcionario -----------------------------
    Private Sub ReporteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReporteToolStripMenuItem.Click
        Dim ObjReport As ClsLbTepsa.dtoFrmReport = New ClsLbTepsa.dtoFrmReport
        Try
            If Not IsNothing(dgdConsultaCabeceraComision.DataSource) Then

                ObjReport.rutaRpt = PathFrmReport
                'dsReporteComision = ObjComisiones.ReporteTotalComisiones()
                'dsReporteComision.WriteXmlSchema(ObjReport.rutaRpt & "\rptComisiones_Funcionarios.xml")
                'ObjReport.printrptXML(False, "", "rptComisiones_Funcionarios1.rpt", dsReporteComision)

                ObjComisiones.IDCOMI_CALCU_FUNCI = dgdConsultaCabeceraComision.CurrentRow.Cells("IDCOMI_CALCU_FUNCI").Value
                ObjReport.rutaRpt = PathFrmReport
                ObjReport.conectar(rptservice, rptuser, rptpass)

                ObjReport.printrpt(False, "", "rptComisiones_Funcionarios.rpt", "p_fecha_ini;" & DTPFechaInicioConsulta.Value.ToShortDateString, "p_fecha_final;" & DTPFechaFinalConsulta.Value.ToShortDateString)
            Else
                MessageBox.Show("Debe de consultar la información de las comisiones antes de obtener el reporte", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.InnerException.InnerException.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '------------------------------ Cierre de Comisiones Calculadas por Funcionario -----------------------------
    Private Sub CierreComisionesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CierreComisionesToolStripMenuItem.Click
        Try
            If MessageBox.Show("Cerrado el cálculo de comisión no podra realizar modificaciones a los registros ya considerados. ¿Seguro que desea realizar el cierre?...", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Try
                    Cursor.Current = Cursors.AppStarting
                    ObjComisiones.FECHA_INI = DTPFechaInicioConsulta.Value.ToShortDateString
                    ObjComisiones.FECHA_FINAL = DTPFechaFinalConsulta.Value.ToShortDateString
                    ObjComisiones.sp_cierre_comi_funci()
                    Cursor.Current = Cursors.WaitCursor
                Catch k As Exception
                    MessageBox.Show("Error de proceso", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Cursor.Current = Cursors.WaitCursor
                Finally
                    MessageBox.Show("Proceso terminado con exito", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Cursor.Current = Cursors.WaitCursor
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    '------------------------------ Salir de Comisiones Calculadas por Funcionario ------------------------------
    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Try
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '------------------------------- Anular Comisiones Calculadas por Funcionario -------------------------------
    Private Sub AnularToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AnularToolStripMenuItem.Click
        Try
            If dgdConsultaCabeceraComision.Rows.Count > 0 Then
                If Not dgdConsultaCabeceraComision.CurrentRow.Cells("CERRADO").Value = "SI" Then
                    ObjComisiones.IDCOMI_CALCU_FUNCI = dgdConsultaCabeceraComision.CurrentRow.Cells("IDCOMI_CALCU_FUNCI").Value
                    If MessageBox.Show("Esta seguro que desea anular este calculo de comsión...?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        ObjComisiones.SP_ANU_COMI_FUNCI()
                        ConsultarEncabezadoComision()
                    End If
                Else
                    MessageBox.Show("No se puede anular el registro ya esta cerrada...", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Else
                MessageBox.Show("No existen datos registrados para la anulación de comisión...", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub dgdCobranza_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCobranza.CellContentClick

    End Sub

    Private Sub dgdConsultaCabeceraComision_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdConsultaCabeceraComision.CellContentClick

    End Sub

    Private Sub dgdRangoFuncionario_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdRangoFuncionario.CellContentClick

    End Sub
End Class