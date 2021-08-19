Imports System.Data.Odbc

Public Class FrmMonitoreos
    Dim cn As OdbcConnection
    Dim TabGastos As TabPage

    Private Sub FrmMonitoreo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ConfiguraGridAgencia()
        Me.ConfiguraGridUsuario()
        ConfiguraGridLiquidacion()

        Dim obj As New dtoLiquidacionOficina
        With CboAgencia
            Dim dt As DataTable = obj.ListarAgencia
            .DataSource = dt
            .DisplayMember = "Nombre_Unidad"
            .ValueMember = "Idunidad_Agencia"
            .SelectedValue = dtoUSUARIOS.m_iIdAgencia
        End With

        Me.TabGastos = TabLiquidacion.TabPages(2)
        Me.TabLiquidacion.Controls.RemoveAt(2)
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtoLiquidacionOficina
            Dim dt As DataTable = obj.ListarLiquidacion(1, Me.CboAgencia.SelectedValue, DtpInicio.Text, DtpFin.Text)
            'RemoveHandler DgvAgencia.RowEnter, AddressOf DgvAgencia_RowEnter
            With DgvAgencia
                .DataSource = dt
            End With

            If DgvAgencia.Rows.Count > 0 Then
                Me.BtnImp.Enabled = True
                Me.BtnPrv.Enabled = True
            Else
                Me.BtnImp.Enabled = False
                Me.BtnPrv.Enabled = False
                DgvUsuario.DataSource = Nothing
                Me.ConfiguraGridUsuario()

            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try                
    End Sub

    Sub ConfiguraGridAgencia()
        With DgvAgencia
            .Columns.Clear()
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .ReadOnly = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black

            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .DataPropertyName = "Codigo"
                .Name = "codigo"
                .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim Usuario_Creacion As New DataGridViewTextBoxColumn
            With Usuario_Creacion
                .HeaderText = "Usuario_Creacion"
                .DataPropertyName = "Usuario_Creacion"
                .Name = "Usuario_Creacion"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
            End With

            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .DataPropertyName = "Administrador"
                .Name = "Usuario"
                .HeaderText = "Administrador"
                .Width = 250
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            Dim Usuario_Modificacion As New DataGridViewTextBoxColumn
            With Usuario_Modificacion
                .HeaderText = "Usuario_Modificacion"
                .DataPropertyName = "Usuario_Modificacion"
                .Name = "Usuario_Modificacion"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
            End With

            Dim UsuarioCierre As New DataGridViewTextBoxColumn
            With UsuarioCierre
                .HeaderText = "Usuario2"
                .DataPropertyName = "Administrador1"
                .Name = "Usuario1"
                .Width = 200
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
            End With

            Dim col3 As New DataGridViewTextBoxColumn
            With col3
                .DataPropertyName = "fecha_apertura"
                .Name = "fecha_apertura"
                .HeaderText = "Fecha Apertura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .DataPropertyName = "agencia"
                .Name = "agencia"
                .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Dim col5 As New DataGridViewTextBoxColumn
            With col5
                .DataPropertyName = "fecha_cierre"
                .Name = "fecha_cierre"
                .HeaderText = "Fecha Cierre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Dim col6 As New DataGridViewTextBoxColumn
            With col6
                .DataPropertyName = "estado"
                .Name = "estado"
                .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            .Columns.AddRange(col1, col2, col3, col4, col5, col6, Usuario_Creacion, Usuario_Modificacion, UsuarioCierre)
        End With

    End Sub

    Sub ConfiguraGridUsuario()
        With DgvUsuario             
            .Columns.Clear()           
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .AutoGenerateColumns = False
            .AllowUserToResizeColumns = False          

          
            '.BackgroundColor = SystemColors.Window
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 30
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ScrollBars = ScrollBars.Both

            Dim IDLiquiTurno As New DataGridViewTextBoxColumn
            With IDLiquiTurno
                .HeaderText = "IDLiquiTurno"
                .DataPropertyName = "IDLiquiTurno"
                .Name = "IDLiquiTurno"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
            End With

            Dim idusuariocarga As New DataGridViewTextBoxColumn
            With idusuariocarga
                .DataPropertyName = "idusuariocarga"
                .Name = "idusuariocarga"
                .HeaderText = "idusuariocarga"
                .Width = 250
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Visible = False
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            Dim idliquidacionoficina As New DataGridViewTextBoxColumn
            With idliquidacionoficina
                .DataPropertyName = "idliquidacionoficina"
                .Name = "idliquidacionoficina"
                .HeaderText = "idliquidacionoficina"
                .Width = 250
                .Visible = False
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            Dim Tipo As New DataGridViewTextBoxColumn
            With Tipo
                .DataPropertyName = "Tipo"
                .Name = "tipo"
                .HeaderText = "tipo"
                .Width = 55
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .DataPropertyName = "usuario"
                .Name = "usuario"
                .HeaderText = "Usuario"
                .Width = 200
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .HeaderText = "Efectivo"
                .Name = "efectivo"
                .DataPropertyName = "efectivo"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim col3 As New DataGridViewTextBoxColumn
            With col3
                .HeaderText = "PCE Factura"
                .Name = "PCE_FACTURA"
                .DataPropertyName = "PCEFACTURA"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .HeaderText = "PCE Boleta"
                .Name = "PCE_BOLETA"
                .DataPropertyName = "PCEBOLETA"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim col5 As New DataGridViewTextBoxColumn
            With col5
                .HeaderText = "Total Venta"
                .Name = "TOTAL_VENTA"
                .DataPropertyName = "TOTALVENTA"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim col6 As New DataGridViewTextBoxColumn
            With col6
                .HeaderText = "efectivoIngresado"
                .Name = "efectivoIngresado"
                .DataPropertyName = "efectivoIngresado"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
                .Visible = False
            End With
            .Columns.AddRange(IDLiquiTurno, Tipo, idusuariocarga, idliquidacionoficina, col1, col2, col3, col4, col5, col6)
        End With

    End Sub

    Dim sFecha As String
    Private Sub DgvAgencia_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvAgencia.CellEnter
        With DgvAgencia
            If DgvAgencia.Rows.Count > 0 Then
                Dim iLiquidacion As Integer = .CurrentRow.Cells("codigo").Value
                sFecha = .CurrentRow.Cells("fecha_apertura").Value
                Dim obj As New dtoLiquidacionOficina
                Dim dt As DataTable = obj.ListarLiquidacion(iLiquidacion, sFecha, CboAgencia.SelectedValue)
                Me.DgvUsuario.DataSource = dt
            End If
        End With
    End Sub

    Sub ConfiguraGridLiquidacion()
        With DgvLiquidacionesAgencias           
            .Rows.Clear()
            .Columns.Clear()
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .AutoGenerateColumns = False
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.RowHeadersWidth = 30
            '.RowHeadersWidth = 20
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black

            Dim agencia As New DataGridViewTextBoxColumn
            With agencia
                .DataPropertyName = "agencia"
                .Name = "agencia"
                .HeaderText = "Agencia"
                .Width = 190
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            Dim Pasaje As New DataGridViewTextBoxColumn
            With Pasaje
                .HeaderText = "Pasaje"
                .Name = "Pasaje"
                .DataPropertyName = "Pasaje"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Factura As New DataGridViewTextBoxColumn
            With Factura
                .HeaderText = "Factura"
                .Name = "factura"
                .DataPropertyName = "factura"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Boleta As New DataGridViewTextBoxColumn
            With Boleta
                .HeaderText = "Boleta"
                .Name = "boleta"
                .DataPropertyName = "boleta"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim pce As New DataGridViewTextBoxColumn
            With pce
                .HeaderText = "PCE"
                .Name = "pce"
                .DataPropertyName = "pce"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim credito As New DataGridViewTextBoxColumn
            With credito
                .HeaderText = "Crédito"
                .Name = "credito"
                .DataPropertyName = "credito"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Delivery As New DataGridViewTextBoxColumn
            With Delivery
                .HeaderText = "Delivery"
                .Name = "Delivery"
                .DataPropertyName = "Delivery"
                .DefaultCellStyle.Format = "0.00"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable

                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Otros_Ingresos As New DataGridViewTextBoxColumn
            With Otros_Ingresos
                .HeaderText = "Otros_Ingresos"
                .Name = "Otros_Ingresos"
                .DataPropertyName = "Otros_Ingresos"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Egreso As New DataGridViewTextBoxColumn
            With Egreso
                .HeaderText = "Egreso"
                .Name = "Egreso"
                .DataPropertyName = "Egreso"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Saldox As New DataGridViewTextBoxColumn
            With Saldox
                .HeaderText = "Saldo a Depositar"
                .Name = "Saldo"
                .DataPropertyName = "Saldo"
                .DefaultCellStyle.Format = "0.00"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Tarjetax As New DataGridViewTextBoxColumn
            With Tarjetax
                .HeaderText = "Tarjeta"
                .Name = "Tarjeta"
                .DataPropertyName = "Tarjeta"
                .DefaultCellStyle.Format = "0.00"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Observacionx As New DataGridViewTextBoxColumn
            With Observacionx
                .HeaderText = "Observacion"
                .Name = "Observacion"
                .DataPropertyName = "Observacion"
                .DefaultCellStyle.Format = "CERRADO"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                '.DefaultCellStyle.Format = "###,###,###0.00"
            End With

            .Columns.AddRange(agencia, Pasaje, Factura, Boleta, Delivery, Otros_Ingresos, Egreso, Saldox, Tarjetax, Observacionx)
        End With

    End Sub

    Private Sub BtnBuscar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar2.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtoLiquidacionOficina
            Dim dtCarga As DataTable = obj.ListarLiquidacion(Me.DtpFecha.Text)            

            With DgvLiquidacionesAgencias
                .DataSource = dtCarga
            End With
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        
    End Sub

    Function ObtieneDT(ByVal sql As String) As DataTable
        Dim cmd As New OdbcCommand
        cmd.CommandText = sql
        cmd.CommandType = CommandType.Text
        cmd.Connection = cnn
        Dim da As New OdbcDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        Return dt
    End Function

    Private Sub BtnPrv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrv.Click
        Try
            Me.Cursor = Cursors.AppStarting           
            If Not Me.DgvAgencia.Rows.Count > 0 Then
                Me.Cursor = Cursors.Default
                Return
            End If

            Dim row As Integer = DgvAgencia.SelectedRows.Item(0).Index

            Dim iIDliquidacion As Integer = DgvAgencia.Rows(row).Cells("Codigo").Value
            Dim iDocumento As Integer = 1
            '--------------------------------
            Me.imprime(iDocumento, iIDliquidacion)
            '--------------------------------
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Funciones para imprimir
    Dim ObjRptGuiaEnvio As New dtoRptGuiaEnvio()
    Public Sub imprime(ByVal documento As Integer, ByVal IDLiquidacion As Integer)
        Dim obj As New Imprimir
        Try
            Dim ldt_cur_datos_venta As New DataTable
            Dim dtGastosLiquidacion As New DataTable
            Dim lds_tmp As New DataSet
            Dim row As Integer = DgvAgencia.SelectedRows.Item(0).Index
            '
            Dim flag As Boolean = False
            Dim iSubTotal As Double = 0, iImpuesto As Double = 0, iTotal As Double = 0


            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim objImprimir As New ImprimirTexto()
            Dim sImpresora As String = ""
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            '


            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 37)

            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            obj = New Imprimir
            obj.Inicializar()
            obj.Superior = iSuperior
            obj.Izquierda = Iizquierda
            obj.Impresora = sImpresora

            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            Dim iLong As Integer = IIf(iTamaño = 0, 76, iTamaño)
            If dtoUSUARIOS.iIDAGENCIAS = 541 Then
                iLong = 86
            End If
            y = iLong * pagina + 4
            y += 1
            i += 1

            Dim iLinea As Integer = 0
            iLinea = Len("RESUMEN DE LIQUIDACION DE OFICINA " & DgvAgencia.Rows(row).Cells("Agencia").Value)
            obj.EscribirLinea(y - 3, (124 - iLinea) / 2, "RESUMEN DE LIQUIDACION DE OFICINA " & DgvAgencia.Rows(row).Cells("Agencia").Value)

            obj.EscribirLinea(y - 1, 10, "FECHA LIQUID : " & DgvAgencia.Rows(row).Cells("Fecha_Apertura").Value)
            obj.EscribirLinea(y - 1, 60, "US. APERTURA.: " & DgvAgencia.Rows(row).Cells("usuario").Value)
            obj.EscribirLinea(y, 10, "FECHA CIERRE : " & DgvAgencia.Rows(row).Cells("Fecha_Cierre").Value)
            obj.EscribirLinea(y, 60, "US. CIERRE.  : " & DgvAgencia.Rows(row).Cells("usuario1").Value)


            'obj.EscribirLinea(y - 4, 10, "RESUMEN DE LIQUIDACION DE OFICINA " & dtoUSUARIOS.m_iNombreAgencia)
            'obj.EscribirLinea(y - 3, 10, "FECHA LIQ : " & DgvAgencia.Rows(row).Cells("fecha_cierre").Value)
            'obj.EscribirLinea(y - 3, 60, "US. CIERRE.: " & DgvAgencia.Rows(row).Cells("Usuario").Value)

            If DgvAgencia.Rows(row).Cells("Estado").Value = "CERRADA" Then
                obj.EscribirLinea(y + 1, 10, "REIMPRESION ")
            End If

            'obj.EscribirLinea(y - 1, 60, "VENTA DE PASAJES")
            'obj.EscribirLinea(y - 1, 90, "ENCOMIENDAS")
            'obj.EscribirLinea(y, 10, "Caja (s)") 
            'obj.EscribirLinea(y, 61, "Monto Efec'tivo")

            'lds_tmp = ObjVentaCargaContado.ListaReporteLiquidacion(dtoUSUARIOS.m_iIdAgencia, IDLiquidacion)
            lds_tmp = ObjVentaCargaContado.ListaDatosLiquidacion(CboAgencia.SelectedValue, IDLiquidacion, DgvAgencia.Rows(row).Cells("fecha_Apertura").Value, 1)
            ldt_cur_datos_venta = lds_tmp.Tables(0).Copy
            dtGastosLiquidacion = lds_tmp.Tables(1).Copy


            '----------------------------------------------------------------------------------
            Dim objCierreOficina As New dtoCierreOficina
            Dim s As Integer = 5
            Dim totalFacturaCarga As Double, totalBoletaCarga As Double, totalPCECarga As Double, TotalMontoTarjeVisa As Double, TotalMontoTarjeMaster As Double
            Dim totalFacturaPsje As Double, totalBoletaPsje As Double, totalPCEPsje As Double, TotalCredito As Double, totalDevolucionCarga As Double
            Dim totalEncomiendaCortesia As Double
            Dim TotalOtrosIngresos As Double, TotalOtrosIngresosTarjeta As Double
            Dim NCCarga As Double
            Dim NCBoleta As Double, NCFactura As Double

            '====PASAJE=======
            obj.EscribirLinea(y + 3, 10, "VENTA PASAJE")
            obj.EscribirLinea(y + 4, 10, "------------")

            'Me.ListaTotalesPsjes(IDLiquidacion)
            Dim dtListaTotalesPsjes As DataSet = objCierreOficina.PrevistaReporte(1, IDLiquidacion, DgvAgencia.Rows(row).Cells("fecha_Apertura").Value, _
                                                                                  CboAgencia.SelectedValue)
            For Each fila As DataRow In dtListaTotalesPsjes.Tables(1).Rows
                obj.EscribirLinea(y + s, 10, fila.Item("USUARIO")) 'cambio 

                If Trim(fila.Item("montoefectivo").ToString) = "" Then
                    iLinea = Len("0.00")
                    obj.EscribirLinea(y + s, 71 - iLinea, "0.00")
                Else
                    iLinea = Len(FormatNumber(Format(fila.Item("montoefectivo"), "###,###,###.00"), 2))
                    obj.EscribirLinea(y + s, 71 - iLinea, FormatNumber(Format(fila.Item("montoefectivo"), "###,###,###.00"), 2))
                End If
                totalFacturaPsje += IIf(IsDBNull(fila.Item("montoefectivo")), 0, fila.Item("montoefectivo"))
                s += 1
            Next

            obj.EscribirLinea(y + s + 1, 10, "Total")
            obj.EscribirLinea(y + s, 10, "-----------------------------------")
            obj.EscribirLinea(y + s, 61, "-----------")
            obj.EscribirLinea(y + s + 1, 65, FormatNumber(totalFacturaPsje, 2))


            obj.EscribirLinea(y + s + 3, 10, "VENTA CARGA")
            obj.EscribirLinea(y + s + 3, 61, "Factura")
            obj.EscribirLinea(y + s + 3, 75, "Boleta")
            obj.EscribirLinea(y + s + 3, 89, "PCE")
            obj.EscribirLinea(y + s + 3, 103, "Credito")
            obj.EscribirLinea(y + s + 4, 10, "------------")

            s += 5
            For Each fila As DataRow In ldt_cur_datos_venta.Rows
                obj.EscribirLinea(y + s, 10, fila.Item("NOMBRE")) 'cambio 

                If Trim(fila.Item("TOTAL_MONTO_FACTU").ToString) = "" Then
                    iLinea = Len("0.00")
                    obj.EscribirLinea(y + s, 71 - iLinea, "0.00")
                Else
                    iLinea = Len(FormatNumber(Format(fila.Item("TOTAL_MONTO_FACTU"), "###,###,###.00"), 2))
                    obj.EscribirLinea(y + s, 71 - iLinea, FormatNumber(Format(fila.Item("TOTAL_MONTO_FACTU"), "###,###,###.00"), 2))
                End If

                If Trim(fila.Item("TOTAL_MONTO_BOLE").ToString) = "" Then
                    iLinea = Len("0.00")
                    obj.EscribirLinea(y + s, 86 - iLinea, "0.00")
                Else
                    iLinea = Len(FormatNumber(Format(fila.Item("TOTAL_MONTO_BOLE"), "###,###,###.00"), 2))
                    obj.EscribirLinea(y + s, 86 - iLinea, FormatNumber(Format(fila.Item("TOTAL_MONTO_BOLE"), "###,###,###.00"), 2))
                End If

                If Trim(fila.Item("TOTAL_MONTO_PAGO_ENTRE").ToString) = "" Then
                    iLinea = Len("0.00")
                    obj.EscribirLinea(y + s, 99 - iLinea, "0.00")
                Else
                    iLinea = Len(FormatNumber(Format(fila.Item("TOTAL_MONTO_PAGO_ENTRE"), "###,###,###.00"), 2))
                    obj.EscribirLinea(y + s, 99 - iLinea, FormatNumber(Format(fila.Item("TOTAL_MONTO_PAGO_ENTRE"), "###,###,###.00"), 2))
                End If

                If Trim(fila.Item("total_Credito").ToString) = "" Then
                    iLinea = Len("0.00")
                    obj.EscribirLinea(y + s, 112 - iLinea, "0.00")
                Else
                    iLinea = Len(FormatNumber(Format(fila.Item("total_Credito"), "###,###,###.00"), 2))
                    obj.EscribirLinea(y + s, 112 - iLinea, FormatNumber(Format(fila.Item("total_Credito"), "###,###,###.00"), 2))
                End If

                totalFacturaCarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_FACTU")), 0, fila.Item("TOTAL_MONTO_FACTU"))
                totalBoletaCarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_BOLE")), 0, fila.Item("TOTAL_MONTO_BOLE"))
                totalPCECarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_PAGO_ENTRE")), 0, fila.Item("TOTAL_MONTO_PAGO_ENTRE"))
                TotalMontoTarjeVisa += IIf(IsDBNull(fila.Item("total_monto_tarje_Visa")), 0, fila.Item("total_monto_tarje_Visa"))
                TotalMontoTarjeMaster += IIf(IsDBNull(fila.Item("total_monto_tarje_Master")), 0, fila.Item("total_monto_tarje_Master"))
                TotalCredito += IIf(IsDBNull(fila.Item("total_Credito")), 0, fila.Item("total_Credito"))
                totalDevolucionCarga += IIf(IsDBNull(fila.Item("Total_DevolucionCarga")), 0, fila.Item("Total_DevolucionCarga"))
                totalEncomiendaCortesia += IIf(IsDBNull(fila.Item("Total_Encomiendas_Cortesia")), 0, fila.Item("Total_Encomiendas_Cortesia"))
                NCCarga += IIf(IsDBNull(fila.Item("nc")), 0, fila.Item("nc"))
                NCBoleta += IIf(IsDBNull(fila.Item("pagonc_boleta")), 0, fila.Item("pagonc_boleta"))
                NCFactura += IIf(IsDBNull(fila.Item("pagonc_factura")), 0, fila.Item("pagonc_factura"))

                TotalOtrosIngresos += IIf(IsDBNull(fila.Item("total_monto_otros")), 0, fila.Item("total_monto_otros"))
                TotalOtrosIngresosTarjeta += IIf(IsDBNull(fila.Item("total_monto_tarjeta_otros")), 0, fila.Item("total_monto_tarjeta_otros"))

                s += 1
            Next

            obj.EscribirLinea(y + s + 1, 10, "Total")
            obj.EscribirLinea(y + s, 10, "-----------------------------------")
            obj.EscribirLinea(y + s, 61, "-----------")
            obj.EscribirLinea(y + s, 75, "-----------")
            obj.EscribirLinea(y + s, 89, "----------")
            obj.EscribirLinea(y + s, 103, "----------")
            iLinea = Len(IIf(totalFacturaCarga = 0, "0.00", FormatNumber(Format(totalFacturaCarga, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 1, 71 - iLinea, IIf(totalFacturaCarga = 0, "0.00", FormatNumber(Format(totalFacturaCarga, "###,###,###.00"), 2))) '  ,967.50
            iLinea = Len(IIf(totalBoletaCarga = 0, "0.00", FormatNumber(Format(totalBoletaCarga, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 1, 86 - iLinea, IIf(totalBoletaCarga = 0, "0.00", FormatNumber(Format(totalBoletaCarga, "###,###,###.00"), 2)))
            iLinea = Len(IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 1, 99 - iLinea, IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2)))
            iLinea = Len(IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 1, 112 - iLinea, IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2)))


            Dim iReciboCajaPrepagada As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", ""))
            Dim iDelivery As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DELIVERY")), 0, dtGastosLiquidacion.Rows(0).Item("DELIVERY"))
            Dim iOtrosIngresos As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS"))
            Dim iVentaSegurosPaxfre As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXFRE")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXFRE"))
            Dim iVentaSegurosPaxNor As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXNOR")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXNOR"))
            Dim iTotalVentaSeguros As Double = iVentaSegurosPaxfre + iVentaSegurosPaxNor
            Dim poolVentaTotal As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("POOL_TOTAL_VENTA")), 0, dtGastosLiquidacion.Rows(0).Item("POOL_TOTAL_VENTA"))
            'Dim poolVentaVisa As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_VISA")), 0, dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_VISA"))
            Dim pagoEfectivoTotal As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(PAGO_EFECTIVO)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(PAGO_EFECTIVO)", ""))
            Dim poolVentaMAstercard As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_MASTERCARD")), 0, dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_MASTERCARD"))

            TotalOtrosIngresosTarjeta = 0
            TotalOtrosIngresos = 0
            iOtrosIngresos += TotalOtrosIngresos + TotalOtrosIngresosTarjeta

            obj.EscribirLinea(y + s + 3, 10, "OTROS INGRESOS")
            obj.EscribirLinea(y + s + 4, 10, "------------")
            obj.EscribirLinea(y + s + 5, 10, "Recibo. Caja Prepagada")
            iLinea = Len(IIf(iReciboCajaPrepagada = 0, "0.00", FormatNumber(Format(iReciboCajaPrepagada, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 5, 71 - iLinea, IIf(iReciboCajaPrepagada = 0, "0.00", FormatNumber(Format(iReciboCajaPrepagada, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 6, 10, "Delivery")
            iLinea = Len(IIf(iDelivery = 0, "0.00", FormatNumber(Format(iDelivery, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 6, 71 - iLinea, IIf(iDelivery = 0, "0.00", FormatNumber(Format(iDelivery, "###,###,###.00"), 2))) '

            obj.EscribirLinea(y + s + 7, 10, "Otros Ingresos (Fotocopias, etc.)") '2 
            iLinea = Len(IIf(iOtrosIngresos = 0, "0.00", FormatNumber(Format(iOtrosIngresos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 7, 71 - iLinea, IIf(iOtrosIngresos = 0, "0.00", FormatNumber(Format(iOtrosIngresos, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 8, 10, "Venta de Seguros ") '2 
            'iLinea = Len(IIf(iTotalVentaSeguros = 0, "0.00", FormatNumber(Format(iTotalVentaSeguros, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 8, 71 - iLinea, IIf(iTotalVentaSeguros = 0, "0.00", FormatNumber(Format(iTotalVentaSeguros, "###,###,###.00"), 2)))

            '-->Begin - jabanto 20/10/2016
            'obj.EscribirLinea(y + s + 8, 10, "Venta Pool - Pasajes") '2 
            'iLinea = Len(IIf(poolVentaTotal = 0, "0.00", FormatNumber(Format(poolVentaTotal, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 8, 71 - iLinea, IIf(poolVentaTotal = 0, "0.00", FormatNumber(Format(poolVentaTotal, "###,###,###.00"), 2)))

            poolVentaTotal = 0

            obj.EscribirLinea(y + s + 8, 10, "------------------------------")
            obj.EscribirLinea(y + s + 8, 61, "------------")
            obj.EscribirLinea(y + s + 9, 10, "Total")

            Dim iTotalIngresos As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "") +
                                             IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DELIVERY")), 0, dtGastosLiquidacion.Rows(0).Item("DELIVERY")) +
                                             IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS"))) +
                                         iTotalVentaSeguros + TotalOtrosIngresos + TotalOtrosIngresosTarjeta + poolVentaTotal

            iLinea = Len(IIf(iTotalIngresos = 0, "0.00", FormatNumber(Format(iTotalIngresos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 9, 71 - iLinea, IIf(iTotalIngresos = 0, "0.00", FormatNumber(Format(iTotalIngresos, "###,###,###.00"), 2)))

            'hlamas 14-06-2017
            'se agrega pagos con nota de credito referencial, los montos ya estan cargados en el efectivo
            Dim intFilas As Integer, intFilasNC As Integer = 11
            If NCBoleta > 0 Then
                intFilas = 4
                iLinea = Len(Trim(IIf(NCBoleta = 0, "0.00", FormatNumber(Format(NCBoleta, "###,###,###.00"), 2))))
                obj.EscribirLinea(y + s + intFilasNC, 10, "NC. Boleta")
                obj.EscribirLinea(y + s + intFilasNC, 71 - iLinea, IIf(NCBoleta = 0, "0.00", FormatNumber(Format(NCBoleta, "###,###,###.00"), 2)))
            End If
            If NCFactura > 0 Then
                intFilas += 4
                intFilasNC += IIf(NCBoleta > 0, 1, 0)
                obj.EscribirLinea(y + s + intFilasNC, 10, "NC. Factura")
                iLinea = Len(Trim(IIf(NCFactura = 0, "0.00", FormatNumber(Format(NCFactura, "###,###,###.00"), 2))))
                obj.EscribirLinea(y + s + intFilasNC, 71 - iLinea, IIf(NCFactura = 0, "0.00", FormatNumber(Format(NCFactura, "###,###,###.00"), 2)))
            End If
            If NCBoleta + NCFactura > 0 Then
                obj.EscribirLinea(y + s + intFilasNC + 1, 61, "------------")
                obj.EscribirLinea(y + s + intFilasNC + 2, 10, "Total")
                iLinea = Len(Trim(IIf(NCBoleta + NCFactura = 0, "0.00", FormatNumber(Format(NCBoleta + NCFactura, "###,###,###.00"), 2))))
                obj.EscribirLinea(y + s + intFilasNC + 2, 71 - iLinea, IIf(NCBoleta + NCFactura = 0, "0.00", FormatNumber(Format(NCBoleta + NCFactura, "###,###,###.00"), 2)))
                If NCBoleta > 0 And NCFactura > 0 Then
                    intFilas -= 3
                End If
            End If


            '====EGRESOS================================
            Dim VentaPasajeCredito As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", ""))
            Dim VentaPasajePrepagado As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", ""))
            Dim VentaPasajeCortesia As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", ""))
            Dim NCPasaje As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", ""))

            obj.EscribirLinea(y + s + 12 + intFilas, 10, "EGRESOS")
            obj.EscribirLinea(y + s + 13 + intFilas, 10, "--------------")
            obj.EscribirLinea(y + s + 14 + intFilas, 10, "Venta Pasaje Credito")
            iLinea = Len(IIf(VentaPasajeCredito = 0, "0.00", FormatNumber(Format(VentaPasajeCredito, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 14 + intFilas, 71 - iLinea, IIf(VentaPasajeCredito = 0, "0.00", FormatNumber(Format(VentaPasajeCredito, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 15 + intFilas, 10, "Venta Pasaje Prepagados")
            iLinea = Len(IIf(VentaPasajePrepagado = 0, "0.00", FormatNumber(Format(VentaPasajePrepagado, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 15 + intFilas, 71 - iLinea, IIf(VentaPasajePrepagado = 0, "0.00", FormatNumber(Format(VentaPasajePrepagado, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 16 + intFilas, 10, "Venta Pasaje Cortesia")
            iLinea = Len(IIf(VentaPasajeCortesia = 0, "0.00", FormatNumber(Format(VentaPasajeCortesia, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 16 + intFilas, 71 - iLinea, IIf(VentaPasajeCortesia = 0, "0.00", FormatNumber(Format(VentaPasajeCortesia, "###,###,###.00"), 2)))

            'New
            obj.EscribirLinea(y + s + 17 + intFilas, 10, "Venta Carga Cortesia") 'carga
            iLinea = Len(IIf(totalEncomiendaCortesia = 0, "0.00", FormatNumber(Format(totalEncomiendaCortesia, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 17 + intFilas, 71 - iLinea, IIf(totalEncomiendaCortesia = 0, "0.00", FormatNumber(Format(totalEncomiendaCortesia, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 18 + intFilas, 10, "Venta Carga PCE")
            iLinea = Len(IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 18 + intFilas, 71 - iLinea, IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 19 + intFilas, 10, "Venta Carga Credito")
            iLinea = Len(IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 19 + intFilas, 71 - iLinea, IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 20 + intFilas, 10, "Venta Seguros Pasajero Frecuente")
            iLinea = Len(IIf(iVentaSegurosPaxfre = 0, "0.00", FormatNumber(Format(iVentaSegurosPaxfre, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 20 + intFilas, 71 - iLinea, IIf(iVentaSegurosPaxfre = 0, "0.00", FormatNumber(Format(iVentaSegurosPaxfre, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 21 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 21 + intFilas, 61, "------------")
            obj.EscribirLinea(y + s + 22 + intFilas, 10, "Total")
            Dim itotalEgreso1 As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", "")) + _
                              IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", "")) + _
                              IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", "")) + _
                              IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", "")) + _
                              FormatNumber(totalPCECarga, 2) + TotalCredito + totalEncomiendaCortesia + iVentaSegurosPaxfre
            '+ Abs(nc)

            iLinea = Len(IIf(itotalEgreso1 = 0, "0.00", FormatNumber(Format(itotalEgreso1, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 22 + intFilas, 71 - iLinea, IIf(itotalEgreso1 = 0, "0.00", FormatNumber(Format(itotalEgreso1, "###,###,###.00"), 2)))

            Dim iTarjetaVisaPasaje As Double, iTarjetaMasterCard As Double
            iTarjetaVisaPasaje = dtListaTotalesPsjes.Tables(0).Compute("sum(TARJETA_VISA_PASAJE)", "")
            iTarjetaMasterCard = dtListaTotalesPsjes.Tables(0).Compute("sum(TARJETA_MASTER_PASAJE)", "")

            iTarjetaVisaPasaje = iTarjetaVisaPasaje ' + poolVentaVisa
            iTarjetaMasterCard = iTarjetaMasterCard ' + poolVentaMAstercard


            poolVentaMAstercard = 0

            obj.EscribirLinea(y + s + 24, 10, "PagoEfectivo")
            iLinea = Len(IIf(pagoEfectivoTotal = 0, "0.00", FormatNumber(Format(pagoEfectivoTotal, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 24, 71 - iLinea, IIf(pagoEfectivoTotal = 0, "0.00", FormatNumber(Format(pagoEfectivoTotal, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 25 + intFilas, 10, "TC. Visa Pasaje")
            iLinea = Len(IIf(iTarjetaVisaPasaje = 0, "0.00", FormatNumber(Format(iTarjetaVisaPasaje, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 25 + intFilas, 71 - iLinea, IIf(iTarjetaVisaPasaje = 0, "0.00", FormatNumber(Format(iTarjetaVisaPasaje, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 26 + intFilas, 10, "TC. Master Pasaje")
            iLinea = Len(IIf(iTarjetaMasterCard = 0, "0.00", FormatNumber(Format(iTarjetaMasterCard, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 26 + intFilas, 71 - iLinea, IIf(iTarjetaMasterCard = 0, "0.00", FormatNumber(Format(iTarjetaMasterCard, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 27 + intFilas, 10, "TC. Visa Carga")
            iLinea = Len(IIf(TotalMontoTarjeVisa = 0, "0.00", FormatNumber(Format(TotalMontoTarjeVisa, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 27 + intFilas, 71 - iLinea, IIf(TotalMontoTarjeVisa = 0, "0.00", FormatNumber(Format(TotalMontoTarjeVisa, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 28 + intFilas, 10, "TC. Master Carga")
            iLinea = Len(IIf(TotalMontoTarjeMaster = 0, "0.00", FormatNumber(Format(TotalMontoTarjeMaster, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 28 + intFilas, 71 - iLinea, IIf(TotalMontoTarjeMaster = 0, "0.00", FormatNumber(Format(TotalMontoTarjeMaster, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 28, 10, "Pool - TC. Visa Pasajes")
            'iLinea = Len(IIf(poolVentaVisa = 0, "0.00", FormatNumber(Format(poolVentaVisa, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 28, 71 - iLinea, IIf(poolVentaVisa = 0, "0.00", FormatNumber(Format(poolVentaVisa, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 29, 10, "Pool - TC. Master Pasajes")
            'iLinea = Len(IIf(poolVentaMAstercard = 0, "0.00", FormatNumber(Format(poolVentaMAstercard, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 29, 71 - iLinea, IIf(poolVentaMAstercard = 0, "0.00", FormatNumber(Format(poolVentaMAstercard, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 29 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 29 + intFilas, 61, "------------")
            obj.EscribirLinea(y + s + 30 + intFilas, 10, "Total")
            Dim iTotalEgreso2 As Double = (TotalMontoTarjeVisa + TotalMontoTarjeMaster + iTarjetaVisaPasaje + iTarjetaMasterCard + pagoEfectivoTotal + poolVentaMAstercard)

            'New
            Dim iTotalGeneralMaster As Double = (TotalMontoTarjeMaster + iTarjetaMasterCard + poolVentaMAstercard)
            Dim iTotalGeneralVisa As Double = (TotalMontoTarjeVisa + iTarjetaVisaPasaje + pagoEfectivoTotal)
            obj.EscribirLinea(y + s + 29 + intFilas, 75, "-----------")
            obj.EscribirLinea(y + s + 29 + intFilas, 89, "------------------")
            obj.EscribirLinea(y + s + 28 + intFilas, 75, "Total Visa")
            obj.EscribirLinea(y + s + 28 + intFilas, 89, "Total Master Card")

            'iLinea = Len(IIf(iTotalGeneralVisa = 0, "0.00", FormatNumber(Format(iTotalGeneralVisa, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 27, 80 - iLinea, IIf(iTotalGeneralVisa = 0, "0.00", FormatNumber(Format(iTotalGeneralVisa, "###,###,###.00"), 2)))

            'iLinea = Len(IIf(iTotalGeneralMaster = 0, "0.00", FormatNumber(Format(iTotalGeneralMaster, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 27, 99 - iLinea, IIf(iTotalGeneralMaster = 0, "0.00", FormatNumber(Format(iTotalGeneralMaster, "###,###,###.00"), 2)))


            '---
            iLinea = Len(IIf(iTotalGeneralVisa = 0, "0.00", FormatNumber(Format(iTotalGeneralVisa, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 30 + intFilas, 78 - iLinea, IIf(iTotalGeneralVisa = 0, "0.00", Format(iTotalGeneralVisa, "###,###,###.00")))

            '---
            iLinea = Len(IIf(iTotalGeneralMaster = 0, "0.00", FormatNumber(Format(iTotalGeneralMaster, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 30 + intFilas, 99 - iLinea, IIf(iTotalGeneralMaster = 0, "0.00", FormatNumber(Format(iTotalGeneralMaster, "###,###,###.00"), 2)))
            '--


            iLinea = Len(IIf(iTotalEgreso2 = 0, "0.00", FormatNumber(Format(iTotalEgreso2, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 30 + intFilas, 71 - iLinea, IIf(iTotalEgreso2 = 0, "0.00", FormatNumber(Format(iTotalEgreso2, "###,###,###.00"), 2)))


            Dim iDevolucionesPasajes As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", ""))
            obj.EscribirLinea(y + s + 33 + intFilas, 10, "Devoluciones Pasaje")
            iLinea = Len(IIf(iDevolucionesPasajes = 0, "0.00", FormatNumber(Format(iDevolucionesPasajes, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 33 + intFilas, 71 - iLinea, IIf(iDevolucionesPasajes = 0, "0.00", FormatNumber(Format(iDevolucionesPasajes, "###,###,###.00"), 2)))

            'New
            'obj.EscribirLinea(y + s + 29, 10, "Devoluciones Carga")
            'iLinea = Len(IIf(totalDevolucionCarga = 0, "0.00", FormatNumber(Format(totalDevolucionCarga, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 29, 71 - iLinea, IIf(totalDevolucionCarga = 0, "0.00", FormatNumber(Format(totalDevolucionCarga, "###,###,###.00"), 2))) 'p2
            Dim DEVOLUCION_DE_CARGA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")), 0, (dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")))
            obj.EscribirLinea(y + s + 34 + intFilas, 10, "Devoluciones Carga") '
            iLinea = Len(IIf(DEVOLUCION_DE_CARGA = 0, "0.00", FormatNumber(Format(DEVOLUCION_DE_CARGA, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 34 + intFilas, 71 - iLinea, IIf(DEVOLUCION_DE_CARGA = 0, "0.00", FormatNumber(Format(DEVOLUCION_DE_CARGA, "###,###,###.00"), 2))) 'Carga

            obj.EscribirLinea(y + s + 35 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 35 + intFilas, 61, "------------")
            obj.EscribirLinea(y + s + 36 + intFilas, 10, "Total")
            Dim iTotalEgreso3 As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", ""))

            iLinea = Len(IIf(iTotalEgreso3 = 0, "0.00", FormatNumber(Format(iTotalEgreso3, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 36 + intFilas, 71 - iLinea, IIf(iTotalEgreso3 = 0, "0.00", FormatNumber(Format(iTotalEgreso3, "###,###,###.00"), 2)))


            '============================================================
            Dim TRANSFERENCIA_BANCARIA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")), 0, (dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")))
            Dim Gastos_Varios As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")))
            Dim PAGO_PEAJE_FUERA_DEL_COUNT As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")))
            Dim GASTOS_CON_RECIBO_DE_CAJA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")))
            Dim PAGO_GIROS As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")))

            obj.EscribirLinea(y + s + 38 + intFilas, 10, "Transferencia Bancarias")
            iLinea = Len(IIf(TRANSFERENCIA_BANCARIA = 0, "0.00", FormatNumber(Format(TRANSFERENCIA_BANCARIA, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 38 + intFilas, 71 - iLinea, IIf(TRANSFERENCIA_BANCARIA = 0, "0.00", FormatNumber(Format(TRANSFERENCIA_BANCARIA, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 34, 10, "Encomiendas Cortesia") 'carga
            'iLinea = Len(IIf(totalEncomiendaCortesia = 0, "0.00", FormatNumber(Format(totalEncomiendaCortesia, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 34, 71 - iLinea, IIf(totalEncomiendaCortesia = 0, "0.00", FormatNumber(Format(totalEncomiendaCortesia, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 35, 10, "Devoluciones de Encomiendas") '
            'iLinea = Len(IIf(DEVOLUCION_DE_CARGA = 0, "0.00", FormatNumber(Format(DEVOLUCION_DE_CARGA, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 35, 71 - iLinea, IIf(DEVOLUCION_DE_CARGA = 0, "0.00", FormatNumber(Format(DEVOLUCION_DE_CARGA, "###,###,###.00"), 2))) 'Carga

            obj.EscribirLinea(y + s + 39 + intFilas, 10, "Gastos Varios")
            iLinea = Len(IIf(Gastos_Varios = 0, "0.00", FormatNumber(Format(Gastos_Varios, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 39 + intFilas, 71 - iLinea, IIf(Gastos_Varios = 0, "0.00", FormatNumber(Format(Gastos_Varios, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 40 + intFilas, 10, "Peajes(Inc. Fuera del Counter)") '
            iLinea = Len(IIf(PAGO_PEAJE_FUERA_DEL_COUNT = 0, "0.00", FormatNumber(Format(PAGO_PEAJE_FUERA_DEL_COUNT, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 40 + intFilas, 71 - iLinea, IIf(PAGO_PEAJE_FUERA_DEL_COUNT = 0, "0.00", FormatNumber(Format(PAGO_PEAJE_FUERA_DEL_COUNT, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 41 + intFilas, 10, "Giros Pagados") '
            iLinea = Len(IIf(PAGO_GIROS = 0, "0.00", FormatNumber(Format(PAGO_GIROS, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 41 + intFilas, 71 - iLinea, IIf(PAGO_GIROS = 0, "0.00", FormatNumber(Format(PAGO_GIROS, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 42 + intFilas, 10, "Gastos con Recibos de Caja") '
            iLinea = Len(IIf(GASTOS_CON_RECIBO_DE_CAJA = 0, "0.00", FormatNumber(Format(GASTOS_CON_RECIBO_DE_CAJA, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 42 + intFilas, 71 - iLinea, IIf(GASTOS_CON_RECIBO_DE_CAJA = 0, "0.00", FormatNumber(Format(GASTOS_CON_RECIBO_DE_CAJA, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 43 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 43 + intFilas, 61, "------------")
            obj.EscribirLinea(y + s + 44 + intFilas, 10, "Total")
            Dim iTotalEgreso4 As Double = (TRANSFERENCIA_BANCARIA +
                                           DEVOLUCION_DE_CARGA +
                                           Gastos_Varios +
                                           PAGO_PEAJE_FUERA_DEL_COUNT +
                                           GASTOS_CON_RECIBO_DE_CAJA +
                                           PAGO_GIROS
                                           )

            iLinea = Len(IIf(iTotalEgreso4 = 0, "0.00", FormatNumber(Format(iTotalEgreso4, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 44 + intFilas, 71 - iLinea, IIf(iTotalEgreso4 = 0, "0.00", FormatNumber(Format(iTotalEgreso4, "###,###,###.00"), 2)))


            'Nota de Credito
            obj.EscribirLinea(y + s + 46 + intFilas, 10, "NC Carga") '
            iLinea = Len(IIf(NCCarga = 0, "0.00", FormatNumber(Format(NCCarga, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 46 + intFilas, 71 - iLinea, IIf(NCCarga = 0, "0.00", FormatNumber(Format(NCCarga, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 47 + intFilas, 10, "NC Pasaje") '
            iLinea = Len(IIf(NCPasaje = 0, "0.00", FormatNumber(Format(NCPasaje, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 47 + intFilas, 71 - iLinea, IIf(NCPasaje = 0, "0.00", FormatNumber(Format(NCPasaje, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 48 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 48 + intFilas, 61, "------------")
            obj.EscribirLinea(y + s + 49 + intFilas, 10, "Total")
            iLinea = Len(IIf(NCCarga + NCPasaje = 0, "0.00", FormatNumber(Format(NCCarga + NCPasaje, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 49 + intFilas, 71 - iLinea, IIf(NCCarga + NCPasaje = 0, "0.00", FormatNumber(Format(NCCarga + NCPasaje, "###,###,###.00"), 2)))

            Dim iTotalGeneralIngresos As Double = totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + TotalCredito + iTotalIngresos
            Dim iTotalEgresos As Double = itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4
            Dim iSaldoDepositar As Double = (totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + TotalCredito + iTotalIngresos) - (itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4)

            obj.EscribirLinea(y + s + 51 + intFilas, 10, "-----------------------------")
            obj.EscribirLinea(y + s + 51 + intFilas, 61, "------------")
            obj.EscribirLinea(y + s + 52 + intFilas, 10, "Total Ingresos")
            iLinea = Len(IIf(iTotalGeneralIngresos = 0, "0.00", FormatNumber(Format(iTotalGeneralIngresos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 52 + intFilas, 71 - iLinea, IIf(iTotalGeneralIngresos = 0, "0.00", FormatNumber(Format(iTotalGeneralIngresos, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 53 + intFilas, 10, "Total Egresos")
            iLinea = Len(IIf(iTotalEgresos = 0, "0.00", FormatNumber(Format(iTotalEgresos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 53 + intFilas, 71 - iLinea, IIf(iTotalEgresos = 0, "0.00", FormatNumber(Format(iTotalEgresos, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 54 + intFilas, 10, "Saldo a Depositar")
            iLinea = Len(IIf(iSaldoDepositar = 0, "0.00", FormatNumber(Format(iSaldoDepositar, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 54 + intFilas, 71 - iLinea, IIf(iSaldoDepositar = 0, "0.00", FormatNumber(Format(iSaldoDepositar, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 24, 10, "TC. Visa Pasaje")
            'iLinea = Len(IIf(iTarjetaVisaPasaje = 0, "0.00", FormatNumber(Format(iTarjetaVisaPasaje, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 24, 71 - iLinea, IIf(iTarjetaVisaPasaje = 0, "0.00", FormatNumber(Format(iTarjetaVisaPasaje, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 25, 10, "TC. Master Pasaje")
            'iLinea = Len(IIf(iTarjetaMasterCard = 0, "0.00", FormatNumber(Format(iTarjetaMasterCard, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 25, 71 - iLinea, IIf(iTarjetaMasterCard = 0, "0.00", FormatNumber(Format(iTarjetaMasterCard, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 26, 10, "TC. Visa Carga")
            'iLinea = Len(IIf(TotalMontoTarjeVisa = 0, "0.00", FormatNumber(Format(TotalMontoTarjeVisa, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 26, 71 - iLinea, IIf(TotalMontoTarjeVisa = 0, "0.00", FormatNumber(Format(TotalMontoTarjeVisa, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 27, 10, "TC. Master Carga")
            'iLinea = Len(IIf(TotalMontoTarjeMaster = 0, "0.00", FormatNumber(Format(TotalMontoTarjeMaster, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 27, 71 - iLinea, IIf(TotalMontoTarjeMaster = 0, "0.00", FormatNumber(Format(TotalMontoTarjeMaster, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 28, 10, "------------------------------")
            'obj.EscribirLinea(y + s + 28, 61, "------------")
            'obj.EscribirLinea(y + s + 29, 10, "Total")
            'Dim iTotalEgreso2 As Double = (TotalMontoTarjeVisa + TotalMontoTarjeMaster + iTarjetaVisaPasaje + iTarjetaMasterCard)

            ''New
            'Dim iTotalGeneralMaster As Double = (TotalMontoTarjeMaster + iTarjetaMasterCard)
            'Dim iTotalGeneralVisa As Double = (TotalMontoTarjeVisa + iTarjetaVisaPasaje)
            'obj.EscribirLinea(y + s + 28, 75, "-----------")
            'obj.EscribirLinea(y + s + 28, 89, "------------------")
            'obj.EscribirLinea(y + s + 27, 75, "Total Visa")
            'obj.EscribirLinea(y + s + 27, 89, "Total Master Card")

            'iLinea = Len(IIf(iTotalGeneralVisa = 0, "0.00", FormatNumber(Format(iTotalGeneralVisa, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 29, 78 - iLinea, IIf(iTotalGeneralVisa = 0, "0.00", FormatNumber(Format(iTotalGeneralVisa, "###,###,###.00"), 2)))

            'iLinea = Len(IIf(iTotalGeneralMaster = 0, "0.00", FormatNumber(Format(iTotalGeneralMaster, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 29, 99 - iLinea, IIf(iTotalGeneralMaster = 0, "0.00", FormatNumber(Format(iTotalGeneralMaster, "###,###,###.00"), 2)))

            ''--


            'iLinea = Len(IIf(iTotalEgreso2 = 0, "0.00", FormatNumber(Format(iTotalEgreso2, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 29, 71 - iLinea, IIf(iTotalEgreso2 = 0, "0.00", FormatNumber(Format(iTotalEgreso2, "###,###,###.00"), 2)))

            'Dim iDevolucionesPasajes As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", ""))
            'obj.EscribirLinea(y + s + 31, 10, "Devoluciones Pasaje")
            'iLinea = Len(IIf(iDevolucionesPasajes = 0, "0.00", FormatNumber(Format(iDevolucionesPasajes, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 31, 71 - iLinea, IIf(iDevolucionesPasajes = 0, "0.00", FormatNumber(Format(iDevolucionesPasajes, "###,###,###.00"), 2)))

            ''New
            ''obj.EscribirLinea(y + s + 29, 10, "Devoluciones Carga")
            ''iLinea = Len(IIf(totalDevolucionCarga = 0, "0.00", FormatNumber(Format(totalDevolucionCarga, "###,###,###.00"), 2)))
            ''obj.EscribirLinea(y + s + 29, 71 - iLinea, IIf(totalDevolucionCarga = 0, "0.00", FormatNumber(Format(totalDevolucionCarga, "###,###,###.00"), 2))) 'p2
            'Dim DEVOLUCION_DE_CARGA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")), 0, (dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")))
            'obj.EscribirLinea(y + s + 32, 10, "Devoluciones Carga") '
            'iLinea = Len(IIf(DEVOLUCION_DE_CARGA = 0, "0.00", FormatNumber(Format(DEVOLUCION_DE_CARGA, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 32, 71 - iLinea, IIf(DEVOLUCION_DE_CARGA = 0, "0.00", FormatNumber(Format(DEVOLUCION_DE_CARGA, "###,###,###.00"), 2))) 'Carga

            'obj.EscribirLinea(y + s + 33, 10, "------------------------------")
            'obj.EscribirLinea(y + s + 33, 61, "------------")
            'obj.EscribirLinea(y + s + 34, 10, "Total")
            'Dim iTotalEgreso3 As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", ""))

            'iLinea = Len(IIf(iTotalEgreso3 = 0, "0.00", FormatNumber(Format(iTotalEgreso3, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 34, 71 - iLinea, IIf(iTotalEgreso3 = 0, "0.00", FormatNumber(Format(iTotalEgreso3, "###,###,###.00"), 2)))


            ''=====================================================  =======
            'Dim TRANSFERENCIA_BANCARIA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")), 0, (dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")))
            'Dim Gastos_Varios As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")))
            'Dim PAGO_PEAJE_FUERA_DEL_COUNT As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")))
            'Dim GASTOS_CON_RECIBO_DE_CAJA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")))
            'Dim PAGO_GIROS As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")))

            'obj.EscribirLinea(y + s + 36, 10, "Transferencia Bancarias") '
            'iLinea = Len(IIf(TRANSFERENCIA_BANCARIA = 0, "0.00", FormatNumber(Format(TRANSFERENCIA_BANCARIA, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 36, 71 - iLinea, IIf(TRANSFERENCIA_BANCARIA = 0, "0.00", FormatNumber(Format(TRANSFERENCIA_BANCARIA, "###,###,###.00"), 2)))

            ''obj.EscribirLinea(y + s + 34, 10, "Encomiendas Cortesia") 'carga
            ''obj.EscribirLinea(y + s + 34, 61, IIf(totalEncomiendaCortesia = 0, "0.00", FormatNumber(Format(totalEncomiendaCortesia, "###,###,###.00"), 2)))

            ''obj.EscribirLinea(y + s + 35, 10, "Devoluciones de Encomiendas") '
            ''obj.EscribirLinea(y + s + 35, 61, IIf(DEVOLUCION_DE_CARGA = 0, "0.00", FormatNumber(Format(DEVOLUCION_DE_CARGA, "###,###,###.00"), 2))) 'Carga

            'obj.EscribirLinea(y + s + 37, 10, "Gastos Varios")
            'iLinea = Len(IIf(Gastos_Varios = 0, "0.00", FormatNumber(Format(Gastos_Varios, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 37, 71 - iLinea, IIf(Gastos_Varios = 0, "0.00", FormatNumber(Format(Gastos_Varios, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 38, 10, "Peajes(Inc. Fuera del Counter)") '
            'iLinea = Len(IIf(PAGO_PEAJE_FUERA_DEL_COUNT = 0, "0.00", FormatNumber(Format(PAGO_PEAJE_FUERA_DEL_COUNT, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 38, 71 - iLinea, IIf(PAGO_PEAJE_FUERA_DEL_COUNT = 0, "0.00", FormatNumber(Format(PAGO_PEAJE_FUERA_DEL_COUNT, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 39, 10, "Giros Pagados") '
            'iLinea = Len(IIf(PAGO_GIROS = 0, "0.00", FormatNumber(Format(PAGO_GIROS, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 39, 71 - iLinea, IIf(PAGO_GIROS = 0, "0.00", FormatNumber(Format(PAGO_GIROS, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 40, 10, "Gastos con Recibos de Caja") '
            'iLinea = Len(IIf(GASTOS_CON_RECIBO_DE_CAJA = 0, "0.00", FormatNumber(Format(GASTOS_CON_RECIBO_DE_CAJA, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 40, 71 - iLinea, IIf(GASTOS_CON_RECIBO_DE_CAJA = 0, "0.00", FormatNumber(Format(GASTOS_CON_RECIBO_DE_CAJA, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 41, 10, "------------------------------")
            'obj.EscribirLinea(y + s + 41, 61, "------------")
            'obj.EscribirLinea(y + s + 42, 10, "Total")
            'Dim iTotalEgreso4 As Double = (TRANSFERENCIA_BANCARIA + _
            '                               DEVOLUCION_DE_CARGA + _
            '                               Gastos_Varios + _
            '                               PAGO_PEAJE_FUERA_DEL_COUNT + _
            '                               GASTOS_CON_RECIBO_DE_CAJA + _
            '                               PAGO_GIROS
            '                               )

            'iLinea = Len(IIf(iTotalEgreso4 = 0, "0.00", FormatNumber(Format(iTotalEgreso4, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 42, 71 - iLinea, IIf(iTotalEgreso4 = 0, "0.00", FormatNumber(Format(iTotalEgreso4, "###,###,###.00"), 2)))


            'Dim iTotalGeneralIngresos As Double = totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + TotalCredito + iTotalIngresos
            'Dim iTotalEgresos As Double = itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4
            'Dim iSaldoDepositar As Double = (totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + TotalCredito + iTotalIngresos) - (itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4)

            'obj.EscribirLinea(y + s + 44, 10, "-----------------------------")
            'obj.EscribirLinea(y + s + 44, 61, "------------")
            'obj.EscribirLinea(y + s + 45, 10, "Total Ingresos")
            'iLinea = Len(IIf(iTotalGeneralIngresos = 0, "0.00", FormatNumber(Format(iTotalGeneralIngresos, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 45, 71 - iLinea, IIf(iTotalGeneralIngresos = 0, "0.00", FormatNumber(Format(iTotalGeneralIngresos, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 46, 10, "Total Egresos")
            'iLinea = Len(IIf(iTotalEgresos = 0, "0.00", FormatNumber(Format(iTotalEgresos, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 46, 71 - iLinea, IIf(iTotalEgresos = 0, "0.00", FormatNumber(Format(iTotalEgresos, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 47, 10, "Saldo a Depositar")
            'iLinea = Len(IIf(iSaldoDepositar = 0, "0.00", FormatNumber(Format(iSaldoDepositar, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 47, 71 - iLinea, IIf(iSaldoDepositar = 0, "0.00", FormatNumber(Format(iSaldoDepositar, "###,###,###.00"), 2)))

            obj.Comprimido = True
            obj.Preliminar = True
            obj.Tamaño = iLong
            obj.ReglaVertical = False
            obj.Imprimir()
            obj.Finalizar()


            Dim frm As New FrmPreview
            frm.WindowState = FormWindowState.Maximized
            frm.Tamaño = iLong
            frm.Documento = 1
            frm.Text = "Factura"
            frm.ShowDialog()

            objImprimir = Nothing
            objImpresora = Nothing
        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Dim dtListaTotalesPsjes As DataTable
    Sub ListaTotalesPsjes(ByVal IDLiquidacion As Integer)
        Me.ConexionPasajes()
        Dim sql As String
        sql = "SELECT concat(ApellidoPaterno, ' ', ApellidoMaterno,  ' ', Nombres) USUARIO, L.* "
        sql = sql & "FROM (select "
        sql = sql & "idLiquidacionOficina IDLIQOFI, idLiquidacionTurno IDLIQTURNO, EfectivoIngresado EFEINGRE,"
        sql = sql & "CantidadVentaContado CANTCONTADO, TotalVentaContado TOTVTACONTADO,"
        sql = sql & "CantidadPrepagado CANTPREPA, TotalPrepagado TOTPREPA,"
        sql = sql & "CantidadCredito CANTCRED, TotalCredito TOTCRED,"
        sql = sql & "CantidadCortesia CANTCORTE, TotalCortesia TOTCORTE,"
        sql = sql & "CantidadReciboCajaPrepaga CANTRECIBO, TotalReciboCajaPrepagados TOTRECIBO,"
        sql = sql & "CantidadCobradoVoucher CANTTC, TotalCobradoVoucher TOTTC,"
        sql = sql & "CantidadPeajes CANTPEAJES, TotalPeajes TOTPEAJES,"
        sql = sql & "CantidadDevolucionPasajes CANTDEVPSJES, TotalDevolucionPasajes TOTDEVPSJES,"
        sql = sql & "TotalGastosVarios TOTGASTOS, left(FechaLiquidacion, 10) FECHACIERRE,"
        sql = sql & "RIGHT(FechaLiquidacion, 8) HORACIERRE, FechaDiaLiquidacion, idUsuarioSistema "
        sql = sql & "from LiquidacionTurno "
        sql = sql & "where idLiquidacionOficina='" & IDLiquidacion & "') L "
        sql = sql & "inner join UsuariosSistema U on (L.idUsuarioSistema = U.idUsuarioSistema) "
        sql = sql & "ORDER BY FECHACIERRE, HORACIERRE"
        dtListaTotalesPsjes = ObtieneDT(sql)
    End Sub

    Dim cnn As OdbcConnection '-> Conexion Mysql
    Sub ConexionPasajes()
        cnn = New System.Data.Odbc.OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};SERVER=192.168.200.241;DATABASE=Tepsa;UID=ventas;PWD=10913035110;OPTION=18475")
    End Sub

    Private Sub DgvUsuario_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgvUsuario.DoubleClick
        Try
            If DgvUsuario.Rows.Count <= 0 Then
                Return
            End If

            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtoCierreOficina
            Dim row As Integer = DgvUsuario.SelectedRows.Item(0).Index
            Dim dtgastos As DataTable = obj.Gastos(DgvUsuario.Rows(row).Cells("idliquidacionoficina").Value, sFecha, DgvUsuario.Rows(row).Cells("idusuariocarga").Value, DgvUsuario.Rows(row).Cells("IDLiquiTurno").Value)

            If dtgastos.Rows.Count <= 0 Then
                MessageBox.Show("No tiene Gastos ingresados", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                iformato = False
                Me.FormatoDgvGastosXCounter()
                With DgvGastosXCounter
                    .DataSource = dtgastos
                End With

                Me.TabLiquidacion.Controls.Add(TabGastos)
                Me.TabLiquidacion.SelectTab(2)
                LblNombre.Text = DgvUsuario.Rows(row).Cells("usuario").Value
                LblMontoGasto.Text = dtgastos.Compute("sum(MONTO)", "")
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub FormatoDgvGastosXCounter()
        With DgvGastosXCounter
            .Columns.Clear()
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .AllowUserToResizeColumns = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            '.RowHeadersWidth = 20
            .ReadOnly = True
        End With


        If Not iFormato Then
            Dim TIPO_MOVIMIENTO As New DataGridViewTextBoxColumn
            With TIPO_MOVIMIENTO
                .HeaderText = "Tipo_Movimiento"
                .DataPropertyName = "TIPO_MOVIMIENTO"
                .Name = "TIPO_MOVIMIENTO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim MONTO As New DataGridViewTextBoxColumn
            With MONTO
                .HeaderText = "Monto"
                .DataPropertyName = "MONTO"
                .Name = "MONTO"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Width = 65
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim NRO_DOCUMENTO As New DataGridViewTextBoxColumn
            With NRO_DOCUMENTO
                .HeaderText = "Nro_Documento"
                .DataPropertyName = "NRO_DOCUMENTO"
                .Name = "NRO_DOCUMENTO"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim CODIGO_PEAJE As New DataGridViewTextBoxColumn
            With CODIGO_PEAJE
                .HeaderText = "Codigo_Peaje"
                .DataPropertyName = "CODIGO_PEAJE"
                .Name = "CODIGO_PEAJE"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim CUENTA_BANCARIA As New DataGridViewTextBoxColumn
            With CUENTA_BANCARIA
                .HeaderText = "Cuenta_Bancaria"
                .DataPropertyName = "CUENTA_BANCARIA"
                .Name = "CUENTA_BANCARIA"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim DESTINO As New DataGridViewTextBoxColumn
            With DESTINO
                .HeaderText = "Destino"
                .DataPropertyName = "DESTINO"
                .Name = "DESTINO"
                ' .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim DEPOSITANTE As New DataGridViewTextBoxColumn
            With DEPOSITANTE
                .HeaderText = "Depositante"
                .DataPropertyName = "DEPOSITANTE"
                .Name = "DEPOSITANTE"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim CONTACTO As New DataGridViewTextBoxColumn
            With CONTACTO
                .HeaderText = "Contacto"
                .DataPropertyName = "CONTACTO"
                .Name = "CONTACTO"
                ' .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim NRO_BUS As New DataGridViewTextBoxColumn
            With NRO_BUS
                .HeaderText = "Nro_Bus"
                .DataPropertyName = "NRO_BUS"
                .Name = "NRO_BUS"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Width = 55
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim PILOTO As New DataGridViewTextBoxColumn
            With PILOTO
                .HeaderText = "Piloto"
                .DataPropertyName = "PILOTO"
                .Name = "PILOTO"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Width = 250
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim OBSERVACIONES As New DataGridViewTextBoxColumn
            With OBSERVACIONES
                .HeaderText = "Observaciones"
                .DataPropertyName = "OBSERVACIONES"
                .Name = "OBSERVACIONES"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Width = 350
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            DgvGastosXCounter.Columns.AddRange(TIPO_MOVIMIENTO, MONTO, NRO_DOCUMENTO, CODIGO_PEAJE, CUENTA_BANCARIA, DESTINO, DEPOSITANTE, CONTACTO, NRO_BUS, PILOTO, OBSERVACIONES)
        Else
            Dim Administrador As New DataGridViewTextBoxColumn
            With Administrador
                .HeaderText = "Administrador(a)"
                .DataPropertyName = "Administrador"
                .Name = "Administrador"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim IDGastoLiquidacion As New DataGridViewTextBoxColumn
            With IDGastoLiquidacion
                .HeaderText = "IDGastoLiquidacion"
                .DataPropertyName = "IDGastoLiquidacion"
                .Name = "IDGastoLiquidacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
            End With

            Dim Movimiento As New DataGridViewTextBoxColumn
            With Movimiento
                .HeaderText = "Movimiento"
                .DataPropertyName = "Movimiento"
                .Name = "Movimiento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim Monto As New DataGridViewTextBoxColumn
            With Monto
                .HeaderText = "Monto"
                .DataPropertyName = "Monto"
                .Name = "Monto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With

            Dim NroDocumento As New DataGridViewTextBoxColumn
            With NroDocumento
                .HeaderText = "Nro Documento"
                .DataPropertyName = "NroDocumento"
                .Name = "NroDocumento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With

            Dim CodPeaje As New DataGridViewTextBoxColumn
            With CodPeaje
                .HeaderText = "Cod Peaje"
                .DataPropertyName = "CodPeaje"
                .Name = "CodPeaje"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With

            Dim NroOperacion As New DataGridViewTextBoxColumn
            With NroOperacion
                .HeaderText = "Nro Operacion"
                .DataPropertyName = "NroOperacion"
                .Name = "NroOperacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With

            Dim NroBus As New DataGridViewTextBoxColumn
            With NroBus
                .HeaderText = "Nro Bus"
                .DataPropertyName = "NroBus"
                .Name = "NroBus"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With

            '------
            Dim idtipoliquidaciondiaria As New DataGridViewTextBoxColumn
            With idtipoliquidaciondiaria
                .HeaderText = "idtipoliquidaciondiaria"
                .DataPropertyName = "idtipoliquidaciondiaria"
                .Name = "idtipoliquidaciondiaria"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
            End With

            Dim destino As New DataGridViewTextBoxColumn
            With destino
                .HeaderText = "destino"
                .DataPropertyName = "destino"
                .Name = "destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
            End With

            Dim piloto As New DataGridViewTextBoxColumn
            With piloto
                .HeaderText = "piloto"
                .DataPropertyName = "piloto"
                .Name = "piloto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
            End With

            Dim depositante As New DataGridViewTextBoxColumn
            With depositante
                .HeaderText = "depositante"
                .DataPropertyName = "depositante"
                .Name = "depositante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
            End With

            Dim contacto As New DataGridViewTextBoxColumn
            With contacto
                .HeaderText = "contacto"
                .DataPropertyName = "contacto"
                .Name = "contacto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
            End With

            Dim observaciones As New DataGridViewTextBoxColumn
            With observaciones
                .HeaderText = "observaciones"
                .DataPropertyName = "observaciones"
                .Name = "observaciones"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = True
            End With
            DgvGastosXCounter.Columns.AddRange(Administrador, IDGastoLiquidacion, Movimiento, Monto, NroDocumento, CodPeaje, NroOperacion, NroBus, _
                                                  idtipoliquidaciondiaria, destino, piloto, depositante, contacto, observaciones)
        End If
    End Sub

    Private Sub TabLiquidacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabLiquidacion.SelectedIndexChanged
        If TabLiquidacion.TabPages.Count = 3 Then
            If TabLiquidacion.SelectedIndex = 0 Or TabLiquidacion.SelectedIndex = 1 Then
                Me.TabGastos = TabLiquidacion.TabPages(2)
                Me.TabLiquidacion.Controls.RemoveAt(2)
            End If
        End If
    End Sub


    Private Sub BtnPrvVtaCounter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrvVtaCounter.Click
        Try
            If DgvUsuario.Rows.Count <= 0 Then
                Return
            End If

            Me.Cursor = Cursors.AppStarting
            Dim row As Integer = DgvUsuario.SelectedRows.Item(0).Index
            Dim iIDliquidacion As Integer = Convert.ToInt32(DgvUsuario.Rows(row).Cells("idliquidacionoficina").Value)
            Dim iDocumento As Integer = 1
            If DgvUsuario.Rows(row).Cells("Tipo").Value = "Psjes" Then
                Me.DetallePasajes()
            Else
                Me.DetalleCarga(iDocumento, iIDliquidacion)
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'DETALLE X COUNTER PASAJES
    Sub DetallePasajes()
        If DgvUsuario.Rows.Count > 0 Then
            Dim objCierre As New dtoCierreOficina
            Dim row As Integer = DgvUsuario.SelectedRows.Item(0).Index

            Dim dtDetalle As DataSet = objCierre.Detalle(sFecha, sFecha, DgvUsuario.Rows(row).Cells("idusuariocarga").Value, DgvUsuario.Rows(row).Cells("idliquidacionoficina").Value, CboAgencia.SelectedValue)

            Dim flag As Boolean = False
            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim objImprimir As New ImprimirTexto()
            Dim sImpresora As String = ""
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            '

            Dim obj As New Imprimir
            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 37)

            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If


            ' If flag Then

            obj = New Imprimir
            obj.Inicializar()
            obj.Superior = iSuperior
            obj.Izquierda = Iizquierda
            obj.Impresora = sImpresora

            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            Dim iLong As Integer = IIf(iTamaño = 0, 71, iTamaño)

            y = iLong * pagina + 4
            y += 1
            i += 1

            obj.EscribirLinea(y - 4, 35, "LIQUIDACION DIARIA DE VENTAS POR TURNO  " & dtoUSUARIOS.m_iNombreAgencia)
            obj.EscribirLinea(y - 3, 9, "FECHA LIQUID : " & sFecha.Trim)
            obj.EscribirLinea(y - 1, 9, "REPRESENTANTES DE VENTAS")
            obj.EscribirLinea(y - 1, 45, DgvUsuario.Rows(row).Cells("usuario").Value)

            obj.EscribirLinea(y, 9, "ESPECIES VALORADAS UTILIZADAS")
            obj.EscribirLinea(y, 45, "Serie") ': obj.EscribirLinea(y + 1, 30, dtDetalle.Tables(5).Rows(0).Item("Serie"))
            obj.EscribirLinea(y, 60, "Del") ': obj.EscribirLinea(y + 1, 45, dtDetalle.Tables(5).Rows(0).Item("Del"))
            obj.EscribirLinea(y, 75, "Al") ': obj.EscribirLinea(y + 1, 60, dtDetalle.Tables(5).Rows(0).Item("Al"))
            obj.EscribirLinea(y, 90, "Cant") ' : obj.EscribirLinea(y + 1, 75, dtDetalle.Tables(5).Rows(0).Item("cant"))
            obj.EscribirLinea(y, 100, "Corte") ' : obj.EscribirLinea(y + 1, 85, "0")

            Dim Conta As Integer = 1
            For x As Integer = 0 To dtDetalle.Tables(5).Rows.Count - 1
                'If dtDetalle.Tables(5).Rows(x).Item("Serie") <> 200 Then
                obj.EscribirLinea(y + Conta, 9, "Boleto de Viaje")
                obj.EscribirLinea(y + Conta, 45, dtDetalle.Tables(5).Rows(x).Item("Serie"))
                obj.EscribirLinea(y + Conta, 60, dtDetalle.Tables(5).Rows(x).Item("Del"))
                obj.EscribirLinea(y + Conta, 75, dtDetalle.Tables(5).Rows(x).Item("Al"))
                obj.EscribirLinea(y + Conta, 90, dtDetalle.Tables(5).Rows(x).Item("cant"))
                obj.EscribirLinea(y + Conta, 100, "0")
                'Else
                '    obj.EscribirLinea(y + Conta, 9, "Recibos de Caja")
                '    obj.EscribirLinea(y + Conta, 45, dtDetalle.Tables(5).Rows(x).Item("Serie"))
                '    obj.EscribirLinea(y + Conta, 60, dtDetalle.Tables(5).Rows(x).Item("Del"))
                '    obj.EscribirLinea(y + Conta, 75, dtDetalle.Tables(5).Rows(x).Item("Al"))
                '    obj.EscribirLinea(y + Conta, 90, dtDetalle.Tables(5).Rows(x).Item("cant"))
                '    obj.EscribirLinea(y + Conta, 100, "0")
                'End If
                Conta += 1
            Next

            '----------------------------------------------------------------------------------
            Dim s As Integer = 4
            Dim iLinea As Integer = 0
            'Dim totalFacturaCarga As Double, totalBoletaCarga As Double, totalPCECarga As Double
            'Dim totalFacturaPsje As Double, totalBoletaPsje As Double, totalPCEPsje As Double

            Dim iTotalEfectivo As Double = IIf(IsDBNull(DgvUsuario.Rows(row).Cells("efectivoIngresado").Value), 0, DgvUsuario.Rows(row).Cells("efectivoIngresado").Value)

            iLinea = Len("0.00")
            obj.EscribirLinea(y + s + 1, 9, "Reg Tip.Cambio (US$ a S/.)") : obj.EscribirLinea(y + s + 1, 62 - iLinea, "0.00")
            iLinea = Len("0.00")
            obj.EscribirLinea(y + s + 2, 9, "Registro Efectivo Dolares") : obj.EscribirLinea(y + s + 2, 62 - iLinea, "0.00")

            iLinea = Len(IIf(iTotalEfectivo = 0, "0.00", FormatNumber(Format(iTotalEfectivo, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 3, 9, "Registro Efectivo Soles") : obj.EscribirLinea(y + s + 3, 62 - iLinea, IIf(iTotalEfectivo = 0, "0.00", FormatNumber(Format(iTotalEfectivo, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 4, 9, "--------------------------") : obj.EscribirLinea(y + s + 4, 51, "-----------")
            obj.EscribirLinea(y + s + 5, 9, "T.Efectivo (Soles y Dolares)")

            obj.EscribirLinea(y + s + 5, 62 - iLinea, IIf(iTotalEfectivo = 0, "0.00", FormatNumber(Format(iTotalEfectivo, "###,###,###.00"), 2)))

            '**********
            Dim MASTER_CARD As Double = IIf(IsDBNull(dtDetalle.Tables(0).Rows(0).Item("MASTER_CARD")), 0, dtDetalle.Tables(0).Rows(0).Item("MASTER_CARD"))
            Dim VISA As Double = IIf(IsDBNull(dtDetalle.Tables(0).Rows(0).Item("VISA")), 0, dtDetalle.Tables(0).Rows(0).Item("VISA"))
            Dim POOL_MONTO_MASTER_CARD As Double = IIf(IsDBNull(dtDetalle.Tables(11).Rows(0).Item("poolMonMastercard")), 0, dtDetalle.Tables(11).Rows(0).Item("poolMonMastercard"))
            'Dim POOL_MONO_VISA As Double = IIf(IsDBNull(dtDetalle.Tables(11).Rows(0).Item("poolMonVisa")), 0, dtDetalle.Tables(11).Rows(0).Item("poolMonVisa"))
            Dim PAGO_EFETIVO As Double = IIf(IsDBNull(dtDetalle.Tables(0).Rows(0).Item("PAGO_EFECTIVO")), 0, dtDetalle.Tables(0).Rows(0).Item("PAGO_EFECTIVO"))
            Dim NC As Double = IIf(IsDBNull(dtDetalle.Tables(0).Rows(0).Item("NC")), 0, dtDetalle.Tables(0).Rows(0).Item("NC"))

            MASTER_CARD = MASTER_CARD + POOL_MONTO_MASTER_CARD
            'VISA = VISA + PAGO_EFETIVO
            Dim cantidadPagoEfectivo As Integer = 0
            'Dim montoPagoefectivo As Double = 0.0

            iLinea = Len(IIf(MASTER_CARD = 0, "0.00", FormatNumber(Format(MASTER_CARD, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 8, 9, "Monto Tarjeta Master Card") : obj.EscribirLinea(y + s + 8, 62 - iLinea, IIf(MASTER_CARD = 0, "0.00", FormatNumber(Format(MASTER_CARD, "###,###,###.00"), 2)))
            iLinea = Len(IIf(VISA = 0, "0.00", FormatNumber(Format(VISA, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 9, 9, "Monto Tarjeta Visa") : obj.EscribirLinea(y + s + 9, 62 - iLinea, IIf(VISA = 0, "0.00", FormatNumber(Format(VISA, "###,###,###.00"), 2)))
            '-->End begin - jabanto 14/06/2019
            iLinea = Len(Trim(cantidadPagoEfectivo))
            iLinea = Len(IIf(VISA = 0, "0.00", FormatNumber(Format(PAGO_EFETIVO, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 10, 9, "Monto PagoEfectivo") : obj.EscribirLinea(y + s + 10, 62 - iLinea, IIf(PAGO_EFETIVO = 0, "0.00", FormatNumber(Format(PAGO_EFETIVO, "###,###,###.00"), 2)))
            '----
            'iLinea = Len(IIf(POOL_MONTO_MASTER_CARD = 0, "0.00", FormatNumber(Format(POOL_MONTO_MASTER_CARD, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 10, 9, "Venta Pool - Master Card") : obj.EscribirLinea(y + s + 10, 62 - iLinea, IIf(POOL_MONTO_MASTER_CARD = 0, "0.00", FormatNumber(Format(POOL_MONTO_MASTER_CARD, "###,###,###.00"), 2)))
            'iLinea = Len(IIf(POOL_MONO_VISA = 0, "0.00", FormatNumber(Format(POOL_MONO_VISA, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 11, 9, "Venta Pool - Visa") : obj.EscribirLinea(y + s + 11, 62 - iLinea, IIf(POOL_MONO_VISA = 0, "0.00", FormatNumber(Format(POOL_MONO_VISA, "###,###,###.00"), 2)))
            '----

            obj.EscribirLinea(y + s + 11, 9, "----------------------") : obj.EscribirLinea(y + s + 11, 51, "-----------")
            obj.EscribirLinea(y + s + 12, 9, "Mont. Cobrado T.(VOUCHER)")
            Dim iTotalTarjeta As Double = MASTER_CARD + VISA + PAGO_EFETIVO
            iLinea = Len(IIf(iTotalTarjeta = 0, "0.00", FormatNumber(Format(iTotalTarjeta, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 12, 62 - iLinea, IIf(iTotalTarjeta = 0, "0.00", FormatNumber(Format(iTotalTarjeta, "###,###,###.00"), 2)))

            'POOL_MONTO_MASTER_CARD = 0
            'POOL_MONO_VISA = 0

            '**********
            Dim CantVentaContado As Integer = IIf(IsDBNull(dtDetalle.Tables(1).Rows(0).Item("Cant")), 0, dtDetalle.Tables(1).Rows(0).Item("Cant"))
            Dim CantCortesia As Integer = IIf(IsDBNull(dtDetalle.Tables(2).Rows(0).Item("Cant")), 0, dtDetalle.Tables(2).Rows(0).Item("Cant"))
            Dim CantPrepagados As Integer = IIf(IsDBNull(dtDetalle.Tables(3).Rows(0).Item("Cant")), 0, dtDetalle.Tables(3).Rows(0).Item("Cant"))
            Dim CantCreditos As Integer = IIf(IsDBNull(dtDetalle.Tables(4).Rows(0).Item("Cant")), 0, dtDetalle.Tables(4).Rows(0).Item("Cant"))
            Dim MontoVentaContado As Double = IIf(IsDBNull(dtDetalle.Tables(1).Rows(0).Item("MontoVentaContado")), 0, dtDetalle.Tables(1).Rows(0).Item("MontoVentaContado"))
            Dim MontoCortesia As Double = IIf(IsDBNull(dtDetalle.Tables(2).Rows(0).Item("MontoCortesia")), 0, dtDetalle.Tables(2).Rows(0).Item("MontoCortesia"))
            Dim monto_Prepagados As Double = IIf(IsDBNull(dtDetalle.Tables(3).Rows(0).Item("monto_Prepagados")), 0, dtDetalle.Tables(3).Rows(0).Item("monto_Prepagados"))
            Dim monto_Creditos As Double = IIf(IsDBNull(dtDetalle.Tables(4).Rows(0).Item("monto_Creditos")), 0, dtDetalle.Tables(4).Rows(0).Item("monto_Creditos"))

            '-->Venta de seguros
            Dim dtVentaSeguros As DataTable = dtDetalle.Tables(11)
            Dim cantVentaSeguroPaxFree As Integer = IIf(IsDBNull(dtVentaSeguros.Rows(0).Item("cantidadPaxFre")), 0, dtVentaSeguros.Rows(0).Item("cantidadPaxFre"))
            Dim cantVentaSeguroPaxNromal As Integer = IIf(IsDBNull(dtVentaSeguros.Rows(0).Item("cantidadPaxNormal")), 0, dtVentaSeguros.Rows(0).Item("cantidadPaxNormal"))
            Dim montoVentaSeguroPaxFree As Double = IIf(IsDBNull(dtVentaSeguros.Rows(0).Item("totalPaxFre")), 0, dtVentaSeguros.Rows(0).Item("totalPaxFre"))
            Dim montoVentaSeguroPaxNormal As Double = IIf(IsDBNull(dtVentaSeguros.Rows(0).Item("totalPaxNormal")), 0, dtVentaSeguros.Rows(0).Item("totalPaxNormal"))
            'Dim totalVentaSeguros As Double = montoVentaSeguroPaxFree + montoVentaSeguroPaxNormal
            'Dim cantTotalVentaSeguro As Integer = cantVentaSeguroPaxFree + cantVentaSeguroPaxNromal

            obj.EscribirLinea(y + s + 15, 9, "DETALLE DE LIQUIDACION")
            obj.EscribirLinea(y + s + 16, 9, "Tipo") : obj.EscribirLinea(y + s + 16, 54, "Cantidad") : obj.EscribirLinea(y + s + 16, 75, "Monto")
            iLinea = Len(Trim(CantVentaContado))
            obj.EscribirLinea(y + s + 17, 9, "Venta al Contado") : obj.EscribirLinea(y + s + 17, 62 - iLinea, CantVentaContado)
            iLinea = Len(IIf(MontoVentaContado = 0, "0.00", FormatNumber(Format(MontoVentaContado, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 17, 80 - iLinea, IIf(MontoVentaContado = 0, "0.00", FormatNumber(Format(MontoVentaContado, "###,###,###.00"), 2)))

            iLinea = Len(Trim(CantCortesia))
            obj.EscribirLinea(y + s + 18, 9, "Cortesia") : obj.EscribirLinea(y + s + 18, 62 - iLinea, CantCortesia)
            iLinea = Len(IIf(MontoCortesia = 0, "0.00", FormatNumber(Format(MontoCortesia, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 18, 80 - iLinea, IIf(MontoCortesia = 0, "0.00", FormatNumber(Format(MontoCortesia, "###,###,###.00"), 2)))

            iLinea = Len(Trim(CantPrepagados))
            obj.EscribirLinea(y + s + 19, 9, "Prepagados") : obj.EscribirLinea(y + s + 19, 62 - iLinea, CantPrepagados)
            iLinea = Len(IIf(monto_Prepagados = 0, "0.00", FormatNumber(Format(monto_Prepagados, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 19, 80 - iLinea, IIf(monto_Prepagados = 0, "0.00", FormatNumber(Format(monto_Prepagados, "###,###,###.00"), 2)))

            iLinea = Len(Trim(CantCreditos))
            obj.EscribirLinea(y + s + 20, 9, "Creditos") : obj.EscribirLinea(y + s + 20, 62 - iLinea, CantCreditos)
            iLinea = Len(IIf(monto_Creditos = 0, "0.00", FormatNumber(Format(monto_Creditos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 20, 80 - iLinea, IIf(monto_Creditos = 0, "0.00", FormatNumber(Format(monto_Creditos, "###,###,###.00"), 2)))

            '-->End Begin - jabanto 19/10/2016
            'iLinea = Len(Trim(cantTotalVentaSeguro))
            'obj.EscribirLinea(y + s + 19, 9, "Venta de Seguros") : obj.EscribirLinea(y + s + 19, 62 - iLinea, cantTotalVentaSeguro)
            'iLinea = Len(IIf(totalVentaSeguros = 0, "0.00", FormatNumber(Format(totalVentaSeguros, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 19, 80 - iLinea, IIf(totalVentaSeguros = 0, "0.00", FormatNumber(Format(totalVentaSeguros, "###,###,###.00"), 2)))

            '--> Bergin - jabanto 19/10/2016
            Dim pool_cantidad_efectivo As Integer = IIf(IsDBNull(dtDetalle.Tables(11).Rows(0).Item("poolCanEfectivo")), 0, dtDetalle.Tables(11).Rows(0).Item("poolCanEfectivo"))
            Dim pool_monto_efectivo As Double = IIf(IsDBNull(dtDetalle.Tables(11).Rows(0).Item("poolMonEfectivo")), 0, dtDetalle.Tables(11).Rows(0).Item("poolMonEfectivo"))
            'iLinea = Len(Trim(pool_cantidad_efectivo))
            'obj.EscribirLinea(y + s + 21, 9, "Venta Pool - Efectivo") : obj.EscribirLinea(y + s + 21, 62 - iLinea, pool_cantidad_efectivo)
            'iLinea = Len(IIf(pool_monto_efectivo = 0, "0.00", FormatNumber(Format(pool_monto_efectivo, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 21, 80 - iLinea, IIf(pool_monto_efectivo = 0, "0.00", FormatNumber(Format(pool_monto_efectivo, "###,###,###.00"), 2)))

            pool_cantidad_efectivo = 0
            pool_monto_efectivo = 0

            obj.EscribirLinea(y + s + 21, 9, "----------------------") : obj.EscribirLinea(y + s + 21, 51, "-----------") : obj.EscribirLinea(y + s + 21, 70, "-----------")
            obj.EscribirLinea(y + s + 23, 9, "Total")

            iLinea = Len(Trim(CantVentaContado + CantCortesia + CantPrepagados + CantCreditos + pool_cantidad_efectivo))
            obj.EscribirLinea(y + s + 23, 62 - iLinea, CantVentaContado + CantCortesia + CantPrepagados + CantCreditos + pool_cantidad_efectivo)

            Dim iTotalDetalle As Double = (MontoVentaContado + MontoCortesia + monto_Prepagados + monto_Creditos + pool_monto_efectivo)
            iLinea = Len(IIf(iTotalDetalle = 0, "0.00", FormatNumber(Format(iTotalDetalle, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 23, 80 - iLinea, IIf(iTotalDetalle = 0, "0.00", FormatNumber(Format(iTotalDetalle, "###,###,###.00"), 2)))



            '***********
            Dim cantCajaPrepagado As Integer = IIf(IsDBNull(dtDetalle.Tables(6).Rows(0).Item("Cant")), 0, dtDetalle.Tables(6).Rows(0).Item("Cant"))
            Dim cantDelivery As Integer = IIf(IsDBNull(dtDetalle.Tables(6).Rows(1).Item("Cant")), 0, dtDetalle.Tables(6).Rows(1).Item("Cant"))
            Dim MontoCajaPrepagados As Double = IIf(IsDBNull(dtDetalle.Tables(6).Rows(0).Item("MontoCajaPrepagados")), 0, dtDetalle.Tables(6).Rows(0).Item("MontoCajaPrepagados"))
            Dim iDelivery As Double = IIf(IsDBNull(dtDetalle.Tables(6).Rows(1).Item("MontoCajaPrepagados")), 0, dtDetalle.Tables(6).Rows(1).Item("MontoCajaPrepagados"))

            obj.EscribirLinea(y + s + 25, 9, "OTROS INGRESOS")
            obj.EscribirLinea(y + s + 26, 9, "Concepto") : obj.EscribirLinea(y + s + 26, 54, "Cantidad") : obj.EscribirLinea(y + s + 26, 75, "Monto")

            iLinea = Len(Trim(cantDelivery))
            obj.EscribirLinea(y + s + 27, 9, "Delivery") : obj.EscribirLinea(y + s + 27, 62 - iLinea, cantDelivery)
            iLinea = Len(IIf(iDelivery = 0, "0.00", FormatNumber(Format(iDelivery, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 27, 80 - iLinea, IIf(iDelivery = 0, "0.00", FormatNumber(Format(iDelivery, "###,###,###.00"), 2))) '

            iLinea = Len(Trim(cantCajaPrepagado))
            obj.EscribirLinea(y + s + 28, 9, "Recibos de Caja Prepagados") : obj.EscribirLinea(y + s + 28, 62 - iLinea, cantCajaPrepagado)
            iLinea = Len(IIf(MontoCajaPrepagados = 0, "0.00", FormatNumber(Format(MontoCajaPrepagados, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 28, 80 - iLinea, IIf(MontoCajaPrepagados = 0, "0.00", FormatNumber(Format(MontoCajaPrepagados, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 29, 9, "----------------------") : obj.EscribirLinea(y + s + 29, 51, "-----------") : obj.EscribirLinea(y + s + 29, 70, "-----------")

            iLinea = Len(Trim(cantCajaPrepagado))
            obj.EscribirLinea(y + s + 30, 9, "Total") : obj.EscribirLinea(y + s + 30, 62 - iLinea, cantCajaPrepagado + cantDelivery)
            iLinea = Len(IIf(MontoCajaPrepagados + iDelivery = 0, "0.00", FormatNumber(Format(MontoCajaPrepagados + iDelivery, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 30, 80 - iLinea, IIf(MontoCajaPrepagados + iDelivery = 0, "0.00", FormatNumber(Format(MontoCajaPrepagados + iDelivery, "###,###,###.00"), 2)))


            Dim CANTGASTOS_VARIOS As Integer = 0
            Dim CANTPEAJE As Integer = 0
            Dim CANTPAGOS_GIROS As Integer = 0
            Dim GASTOS_VARIOS As Double = 0
            Dim PEAJES As Double = 0
            Dim PAGO_GIROS As Double = 0
            '*********
            If dtDetalle.Tables(9).Rows.Count > 0 Then
                CANTGASTOS_VARIOS = IIf(IsDBNull(dtDetalle.Tables(9).Rows(0).Item("CANTGASTOS_VARIOS")), 0, dtDetalle.Tables(9).Rows(0).Item("CANTGASTOS_VARIOS"))
                CANTPEAJE = IIf(IsDBNull(dtDetalle.Tables(9).Rows(0).Item("CANTPEAJE")), 0, dtDetalle.Tables(9).Rows(0).Item("CANTPEAJE"))
                CANTPAGOS_GIROS = IIf(IsDBNull(dtDetalle.Tables(9).Rows(0).Item("CANTPAGOS_GIROS")), 0, dtDetalle.Tables(9).Rows(0).Item("CANTPAGOS_GIROS"))
                GASTOS_VARIOS = IIf(IsDBNull(dtDetalle.Tables(9).Rows(0).Item("GASTOS_VARIOS")), 0, dtDetalle.Tables(9).Rows(0).Item("GASTOS_VARIOS"))
                PEAJES = IIf(IsDBNull(dtDetalle.Tables(9).Rows(0).Item("PEAJES")), 0, dtDetalle.Tables(9).Rows(0).Item("PEAJES"))
                PAGO_GIROS = IIf(IsDBNull(dtDetalle.Tables(9).Rows(0).Item("PAGO_GIROS")), 0, dtDetalle.Tables(9).Rows(0).Item("PAGO_GIROS"))
            End If


            obj.EscribirLinea(y + s + 32, 9, "EGRESOS")
            obj.EscribirLinea(y + s + 33, 9, "Concepto") : obj.EscribirLinea(y + s + 33, 54, "Cantidad") : obj.EscribirLinea(y + s + 33, 75, "Monto")

            iLinea = Len(Trim(CANTGASTOS_VARIOS))
            obj.EscribirLinea(y + s + 34, 9, "Gastos Varios") : obj.EscribirLinea(y + s + 34, 62 - iLinea, CANTGASTOS_VARIOS)
            iLinea = Len(IIf(GASTOS_VARIOS = 0, "0.00", FormatNumber(Format(GASTOS_VARIOS, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 34, 80 - iLinea, IIf(GASTOS_VARIOS = 0, "0.00", FormatNumber(Format(GASTOS_VARIOS, "###,###,###.00"), 2)))

            iLinea = Len(Trim(CANTPEAJE))
            obj.EscribirLinea(y + s + 35, 9, "Peajes") : obj.EscribirLinea(y + s + 35, 62 - iLinea, CANTPEAJE)
            iLinea = Len(IIf(PEAJES = 0, "0.00", FormatNumber(Format(PEAJES, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 35, 80 - iLinea, IIf(PEAJES = 0, "0.00", FormatNumber(Format(PEAJES, "###,###,###.00"), 2)))

            iLinea = Len(Trim(CANTPAGOS_GIROS))
            obj.EscribirLinea(y + s + 36, 9, "Pago de Giros") : obj.EscribirLinea(y + s + 36, 62 - iLinea, CANTPAGOS_GIROS)
            iLinea = Len(IIf(PAGO_GIROS = 0, "0.00", FormatNumber(Format(PAGO_GIROS, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 36, 80 - iLinea, IIf(PAGO_GIROS = 0, "0.00", FormatNumber(Format(PAGO_GIROS, "###,###,###.00"), 2)))

            iLinea = Len(Trim(cantVentaSeguroPaxFree))
            obj.EscribirLinea(y + s + 37, 9, "Venta de Seguros Pasajero Frecuente") : obj.EscribirLinea(y + s + 37, 62 - iLinea, cantVentaSeguroPaxFree)
            iLinea = Len(IIf(montoVentaSeguroPaxFree = 0, "0.00", FormatNumber(Format(montoVentaSeguroPaxFree, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 37, 80 - iLinea, IIf(montoVentaSeguroPaxFree = 0, "0.00", FormatNumber(Format(montoVentaSeguroPaxFree, "###,###,###.00"), 2)))


            obj.EscribirLinea(y + s + 38, 9, "----------------------") : obj.EscribirLinea(y + s + 38, 51, "-----------") : obj.EscribirLinea(y + s + 38, 70, "-----------")
            obj.EscribirLinea(y + s + 39, 9, "Total")

            iLinea = Len(Trim(CANTGASTOS_VARIOS + CANTPEAJE + CANTPAGOS_GIROS + cantVentaSeguroPaxFree))
            obj.EscribirLinea(y + s + 39, 62 - iLinea, CANTGASTOS_VARIOS + CANTPEAJE + CANTPAGOS_GIROS + cantVentaSeguroPaxFree)

            Dim iTotalGastos As Double = GASTOS_VARIOS + PEAJES + PAGO_GIROS + montoVentaSeguroPaxFree
            iLinea = Len(IIf(iTotalGastos = 0, "0.00", FormatNumber(Format(iTotalGastos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 39, 80 - iLinea, IIf(iTotalGastos = 0, "0.00", FormatNumber(Format(iTotalGastos, "###,###,###.00"), 2)))

            '**************
            Dim Porc100 As Double = IIf(IsDBNull(dtDetalle.Tables(7).Rows(0).Item("Total_Porc100")), 0, dtDetalle.Tables(7).Rows(0).Item("Total_Porc100"))
            Dim Porc80 As Double = IIf(IsDBNull(dtDetalle.Tables(7).Rows(0).Item("Total_Porc80")), 0, dtDetalle.Tables(7).Rows(0).Item("Total_Porc80"))
            Dim cant_Porc80 As Integer = IIf(IsDBNull(dtDetalle.Tables(7).Rows(0).Item("cant_Porc80")), 0, dtDetalle.Tables(7).Rows(0).Item("cant_Porc80"))
            Dim cant_Porc100 As Integer = IIf(IsDBNull(dtDetalle.Tables(7).Rows(0).Item("cant_Porc100")), 0, dtDetalle.Tables(7).Rows(0).Item("cant_Porc100"))

            obj.EscribirLinea(y + s + 41, 9, "DEVOLUCIONES")
            obj.EscribirLinea(y + s + 42, 9, "Nro Documento") : obj.EscribirLinea(y + s + 42, 54, "Cantidad") : obj.EscribirLinea(y + s + 42, 75, "Monto")

            iLinea = Len(Trim(cant_Porc80))
            obj.EscribirLinea(y + s + 43, 9, "Dev.Pasajes 80") : obj.EscribirLinea(y + s + 43, 62 - iLinea, cant_Porc80)
            iLinea = Len(IIf(Porc80 = 0, "0.00", FormatNumber(Format(Porc80, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 43, 80 - iLinea, IIf(Porc80 = 0, "0.00", FormatNumber(Format(Porc80, "###,###,###.00"), 2)))

            iLinea = Len(Trim(cant_Porc100))
            obj.EscribirLinea(y + s + 44, 9, "Dev.Pasajes 100") : obj.EscribirLinea(y + s + 44, 62 - iLinea, cant_Porc100)
            iLinea = Len(IIf(Porc100 = 0, "0.00", FormatNumber(Format(Porc100, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 44, 80 - iLinea, IIf(Porc100 = 0, "0.00", FormatNumber(Format(Porc100, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 45, 9, "----------------------") : obj.EscribirLinea(y + s + 45, 51, "-----------") : obj.EscribirLinea(y + s + 45, 70, "-----------")
            obj.EscribirLinea(y + s + 46, 9, "Total")

            iLinea = Len(Trim(cant_Porc80 + cant_Porc100))
            obj.EscribirLinea(y + s + 46, 62 - iLinea, cant_Porc80 + cant_Porc100)

            Dim iTotalDevoluciones As Double = Porc100 + Porc80
            iLinea = Len(FormatNumber(Format(iTotalDevoluciones, "###,###,###.00"), 2))
            obj.EscribirLinea(y + s + 46, 80 - iLinea, IIf(iTotalDevoluciones = 0, "0.00", FormatNumber(Format(iTotalDevoluciones, "###,###,###.00"), 2)))

            'Nota de Credito
            obj.EscribirLinea(y + s + 48, 9, "NC Pasaje") '
            iLinea = Len(IIf(NC = 0, "0.00", FormatNumber(Format(NC, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 48, 80 - iLinea, IIf(NC = 0, "0.00", FormatNumber(Format(NC, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 49, 9, "----------------------") : obj.EscribirLinea(y + s + 49, 70, "-----------")
            obj.EscribirLinea(y + s + 50, 9, "Total")
            iLinea = Len(IIf(NC = 0, "0.00", FormatNumber(Format(NC, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 50, 80 - iLinea, IIf(NC = 0, "0.00", FormatNumber(Format(NC, "###,###,###.00"), 2)))


            'Dim SaldoEntregar As Double = (MontoVentaContado + MontoCajaPrepagados + iDelivery + totalVentaSeguros) - (iTotalGastos + iTotalDevoluciones + iTotalTarjeta)
            Dim SaldoEntregar As Double = (MontoVentaContado + MontoCajaPrepagados + iDelivery + (0 + 0 + 0)) - (iTotalGastos + iTotalDevoluciones + iTotalTarjeta + NC)
            iLinea = Len(IIf(SaldoEntregar = 0, "0.00", FormatNumber(Format(SaldoEntregar, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 53, 9, "SALDO A ENTREGAR") : obj.EscribirLinea(y + s + 53, 62 - iLinea, IIf(SaldoEntregar = 0, "0.00", FormatNumber(Format(SaldoEntregar, "###,###,###.00"), 2)))

            Dim Diferencia As Double = SaldoEntregar - iTotalEfectivo
            iLinea = Len(IIf(Diferencia = 0, "0.00", FormatNumber(Format(Diferencia, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 54, 9, "DIFERENCIA") : obj.EscribirLinea(y + s + 54, 62 - iLinea, IIf(Diferencia = 0, "0.00", FormatNumber(Format(Diferencia, "###,###,###.00"), 2)))

            obj.Comprimido = True
            obj.Preliminar = True
            obj.Tamaño = iLong
            obj.ReglaVertical = False
            obj.Imprimir()
            obj.Finalizar()

            Dim frm As New FrmPreview
            frm.WindowState = FormWindowState.Normal
            frm.Tamaño = iLong
            frm.Documento = 1
            frm.Text = "Factura"
            frm.ShowDialog()
            'Else
            '    MessageBox.Show("El Documento no tiene asociado una impresora.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
            objImprimir = Nothing
            objImpresora = Nothing

        End If
    End Sub

    'DETALLE X COUNTER CARGA
    Sub DetalleCarga(ByVal documento As Integer, ByVal IDLiquidacion As Integer)
        Dim obj As New Imprimir
        Try
            Dim ldt_cur_datos_venta As New DataTable
            Dim dtGastosLiquidacion As New DataTable
            Dim lds_tmp As New DataSet
            Dim row As Integer = DgvUsuario.SelectedRows.Item(0).Index
            '
            Dim flag As Boolean = False
            Dim iSubTotal As Double = 0, iImpuesto As Double = 0, iTotal As Double = 0
            Dim TotalOtrosIngresos As Double, TotalOtrosIngresosTarjeta As Double


            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim objImprimir As New ImprimirTexto()
            Dim sImpresora As String = ""
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            '


            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 37)

            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            obj = New Imprimir
            obj.Inicializar()
            obj.Superior = iSuperior
            obj.Izquierda = Iizquierda
            obj.Impresora = sImpresora

            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            Dim iLong As Integer = IIf(iTamaño = 0, 75, iTamaño)

            y = iLong * pagina + 4
            y += 1
            i += 1

            lds_tmp = ObjVentaCargaContado.ListaDatosAperturaCarga(DgvUsuario.Rows(row).Cells("idusuariocarga").Value, CboAgencia.SelectedValue, DgvUsuario.Rows(row).Cells("idliquidacionoficina").Value, sFecha)
            ldt_cur_datos_venta = lds_tmp.Tables(0).Copy
            dtGastosLiquidacion = lds_tmp.Tables(1).Copy
            '----------------------------------------------------------------------------------
            Dim objCierreOficina As New dtoCierreOficina
            Dim s As Integer = 5
            Dim totalFacturaCarga As Double, totalBoletaCarga As Double, totalPCECarga As Double, TotalMontoTarjeVisa As Double, TotalMontoTarjeMaster As Double
            Dim totalFacturaPsje As Double, totalBoletaPsje As Double, totalPCEPsje As Double, TotalCredito As Double, totalDevolucionCarga As Double
            Dim totalEncomiendaCortesia As Double
            Dim nc As Double
            Dim NCBoleta As Double, NCFactura As Double

            obj.EscribirLinea(y - 4, 35, "LIQUIDACION DIARIA DE VENTAS POR TURNO  " & dtoUSUARIOS.m_iNombreAgencia)
            obj.EscribirLinea(y - 3, 10, "FECHA : " & sFecha)
            obj.EscribirLinea(y - 1, 10, "REPRESENTANTES DE VENTAS")
            obj.EscribirLinea(y - 1, 45, DgvUsuario.Rows(row).Cells("usuario").Value)

            obj.EscribirLinea(y, 10, "ESPECIES VALORADAS UTILIZADAS")
            obj.EscribirLinea(y, 45, "Serie")
            obj.EscribirLinea(y, 60, "Del")
            obj.EscribirLinea(y, 75, "Al")
            obj.EscribirLinea(y, 90, "Cant")
            obj.EscribirLinea(y, 100, "Corte")


            Dim Conta As Integer = 1
            For x As Integer = 0 To lds_tmp.Tables(2).Rows.Count - 1
                If lds_tmp.Tables(2).Rows(x).Item("idtipo_comprobante") = 2 Then
                    obj.EscribirLinea(y + Conta, 10, "Boleta")
                    obj.EscribirLinea(y + Conta, 45, lds_tmp.Tables(2).Rows(x).Item("Serie"))
                    obj.EscribirLinea(y + Conta, 60, lds_tmp.Tables(2).Rows(x).Item("Del"))
                    obj.EscribirLinea(y + Conta, 75, lds_tmp.Tables(2).Rows(x).Item("Al"))
                    obj.EscribirLinea(y + Conta, 90, lds_tmp.Tables(2).Rows(x).Item("cant"))
                    obj.EscribirLinea(y + Conta, 100, "0")
                Else
                    obj.EscribirLinea(y + Conta, 10, "Factura")
                    obj.EscribirLinea(y + Conta, 45, lds_tmp.Tables(2).Rows(x).Item("Serie"))
                    obj.EscribirLinea(y + Conta, 60, lds_tmp.Tables(2).Rows(x).Item("Del"))
                    obj.EscribirLinea(y + Conta, 75, lds_tmp.Tables(2).Rows(x).Item("Al"))
                    obj.EscribirLinea(y + Conta, 90, lds_tmp.Tables(2).Rows(x).Item("cant"))
                    obj.EscribirLinea(y + Conta, 100, "0")
                End If
                Conta += 1
            Next

            obj.EscribirLinea(y + s + 1, 10, "VENTA CARGA")
            obj.EscribirLinea(y + s + 1, 60, "Factura")
            obj.EscribirLinea(y + s + 1, 75, "Boleta")
            obj.EscribirLinea(y + s + 1, 90, "PCE")
            obj.EscribirLinea(y + s + 1, 100, "Credito")
            obj.EscribirLinea(y + s + 2, 10, "------------")

            s += 3
            Dim iLinea As Integer = 0

            For Each fila As DataRow In ldt_cur_datos_venta.Rows
                obj.EscribirLinea(y + s, 10, fila.Item("NOMBRE")) 'cambio 

                If Trim(fila.Item("TOTAL_MONTO_FACTU").ToString) = "" Then
                    iLinea = Len(Trim("0.00"))
                    obj.EscribirLinea(y + s, 67 - iLinea, "0.00")
                Else
                    iLinea = Len(Trim(FormatNumber(Format(fila.Item("TOTAL_MONTO_FACTU"), "###,###,###.00"), 2)))
                    obj.EscribirLinea(y + s, 67 - iLinea, FormatNumber(Format(fila.Item("TOTAL_MONTO_FACTU"), "###,###,###.00"), 2))
                End If

                If Trim(fila.Item("TOTAL_MONTO_BOLE").ToString) = "" Then
                    iLinea = Len(Trim("0.00"))
                    obj.EscribirLinea(y + s, 81 - iLinea, "0.00")
                Else
                    iLinea = Len(Trim(FormatNumber(Format(fila.Item("TOTAL_MONTO_BOLE"), "###,###,###.00"), 2)))
                    obj.EscribirLinea(y + s, 81 - iLinea, FormatNumber(Format(fila.Item("TOTAL_MONTO_BOLE"), "###,###,###.00"), 2))
                End If

                If Trim(fila.Item("TOTAL_MONTO_PAGO_ENTRE").ToString) = "" Then
                    iLinea = Len(Trim("0.00"))
                    obj.EscribirLinea(y + s, 94 - iLinea, "0.00")
                Else
                    iLinea = Len(Trim(FormatNumber(Format(fila.Item("TOTAL_MONTO_PAGO_ENTRE"), "###,###,###.00"), 2)))
                    obj.EscribirLinea(y + s, 94 - iLinea, FormatNumber(Format(fila.Item("TOTAL_MONTO_PAGO_ENTRE"), "###,###,###.00"), 2))
                End If

                If Trim(fila.Item("total_Credito").ToString) = "" Then
                    iLinea = Len(Trim("0.00"))
                    obj.EscribirLinea(y + s, 108 - iLinea, "0.00")
                Else
                    iLinea = Len(Trim(FormatNumber(Format(fila.Item("total_Credito"), "###,###,###.00"), 2)))
                    obj.EscribirLinea(y + s, 108 - iLinea, FormatNumber(Format(fila.Item("total_Credito"), "###,###,###.00"), 2))
                End If

                totalFacturaCarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_FACTU")), 0, fila.Item("TOTAL_MONTO_FACTU"))
                totalBoletaCarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_BOLE")), 0, fila.Item("TOTAL_MONTO_BOLE"))
                totalPCECarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_PAGO_ENTRE")), 0, fila.Item("TOTAL_MONTO_PAGO_ENTRE"))
                TotalMontoTarjeVisa += IIf(IsDBNull(fila.Item("total_monto_tarje_Visa")), 0, fila.Item("total_monto_tarje_Visa"))
                TotalMontoTarjeMaster += IIf(IsDBNull(fila.Item("total_monto_tarje_Master")), 0, fila.Item("total_monto_tarje_Master"))
                TotalCredito += IIf(IsDBNull(fila.Item("total_Credito")), 0, fila.Item("total_Credito"))
                totalDevolucionCarga += IIf(IsDBNull(fila.Item("Total_DevolucionCarga")), 0, fila.Item("Total_DevolucionCarga"))
                totalEncomiendaCortesia += IIf(IsDBNull(fila.Item("Total_Encomiendas_Cortesia")), 0, fila.Item("Total_Encomiendas_Cortesia"))
                nc += IIf(IsDBNull(fila.Item("nc")), 0, fila.Item("nc"))
                NCBoleta += IIf(IsDBNull(fila.Item("pagonc_boleta")), 0, fila.Item("pagonc_boleta"))
                NCFactura += IIf(IsDBNull(fila.Item("pagonc_factura")), 0, fila.Item("pagonc_factura"))
                s += 1
            Next



            obj.EscribirLinea(y + s + 1, 10, "Total")
            obj.EscribirLinea(y + s, 10, "-----------------------------------")
            obj.EscribirLinea(y + s, 56, "-----------")
            obj.EscribirLinea(y + s, 70, "-----------")
            obj.EscribirLinea(y + s, 84, "----------")
            obj.EscribirLinea(y + s, 99, "----------")

            iLinea = Len(Trim(IIf(totalFacturaCarga = 0, "0.00", FormatNumber(Format(totalFacturaCarga, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 1, 67 - iLinea, IIf(totalFacturaCarga = 0, "0.00", FormatNumber(Format(totalFacturaCarga, "###,###,###.00"), 2)))

            iLinea = Len(Trim(IIf(totalBoletaCarga = 0, "0.00", FormatNumber(Format(totalBoletaCarga, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 1, 81 - iLinea, IIf(totalBoletaCarga = 0, "0.00", FormatNumber(Format(totalBoletaCarga, "###,###,###.00"), 2)))

            iLinea = Len(Trim(IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 1, 94 - iLinea, IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2)))

            iLinea = Len(Trim(IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 1, 108 - iLinea, IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 3, 10, "OTROS INGRESOS")
            obj.EscribirLinea(y + s + 4, 10, "------------")
            'obj.EscribirLinea(y + s + 5, 10, "Recibo. Caja Prepagada")
            ' obj.EscribirLinea(y + s + 5, 61, IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")))

            'Dim iDelivery As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DELIVERY")), 0, dtGastosLiquidacion.Rows(0).Item("DELIVERY"))
            'obj.EscribirLinea(y + s + 5, 10, "Delivery")
            'obj.EscribirLinea(y + s + 5, 61, IIf(iDelivery = 0, "0.00", FormatNumber(Format(iDelivery, "###,###,###.00"), 2))) '

            Dim iTotalOtrosIngresos As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS"))
            iTotalOtrosIngresos += IIf(IsDBNull(ldt_cur_datos_venta.Rows(0).Item("total_monto_otros")), 0, ldt_cur_datos_venta.Rows(0).Item("total_monto_otros"))
            iTotalOtrosIngresos += IIf(IsDBNull(ldt_cur_datos_venta.Rows(0).Item("total_monto_tarjeta_otros")), 0, ldt_cur_datos_venta.Rows(0).Item("total_monto_tarjeta_otros"))

            obj.EscribirLinea(y + s + 5, 10, "Otros Ingresos (Fotocopias, etc.)") '2 

            iLinea = Len(Trim(IIf(iTotalOtrosIngresos = 0, "0.00", FormatNumber(Format(iTotalOtrosIngresos, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 5, 67 - iLinea, IIf(iTotalOtrosIngresos = 0, "0.00", FormatNumber(Format(iTotalOtrosIngresos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 6, 10, "------------------------------")
            obj.EscribirLinea(y + s + 6, 56, "------------")
            obj.EscribirLinea(y + s + 7, 10, "Total")

            'IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DELIVERY")), 0, dtGastosLiquidacion.Rows(0).Item("DELIVERY")) +
            Dim iTotalIngresos As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS"))  'IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "") + _
            iTotalIngresos += IIf(IsDBNull(ldt_cur_datos_venta.Rows(0).Item("total_monto_otros")), 0, ldt_cur_datos_venta.Rows(0).Item("total_monto_otros"))
            iTotalIngresos += IIf(IsDBNull(ldt_cur_datos_venta.Rows(0).Item("total_monto_tarjeta_otros")), 0, ldt_cur_datos_venta.Rows(0).Item("total_monto_tarjeta_otros"))

            iLinea = Len(Trim(IIf(iTotalIngresos = 0, "0.00", FormatNumber(Format(iTotalIngresos, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 7, 67 - iLinea, IIf(iTotalIngresos = 0, "0.00", FormatNumber(Format(iTotalIngresos, "###,###,###.00"), 2)))

            'hlamas 14-06-2017
            'se agrega pagos con nota de credito referencial, los montos ya estan cargados en el efectivo
            Dim intFilas As Integer, intFilasNC As Integer = 9
            If NCBoleta > 0 Then
                intFilas = 4
                iLinea = Len(Trim(IIf(NCBoleta = 0, "0.00", FormatNumber(Format(NCBoleta, "###,###,###.00"), 2))))
                obj.EscribirLinea(y + s + intFilasNC, 10, "NC. Boleta")
                obj.EscribirLinea(y + s + intFilasNC, 67 - iLinea, IIf(NCBoleta = 0, "0.00", FormatNumber(Format(NCBoleta, "###,###,###.00"), 2)))
            End If
            If NCFactura > 0 Then
                intFilas += 4
                intFilasNC += IIf(NCBoleta > 0, 1, 0)
                obj.EscribirLinea(y + s + intFilasNC, 10, "NC. Factura")
                iLinea = Len(Trim(IIf(NCFactura = 0, "0.00", FormatNumber(Format(NCFactura, "###,###,###.00"), 2))))
                obj.EscribirLinea(y + s + intFilasNC, 67 - iLinea, IIf(NCFactura = 0, "0.00", FormatNumber(Format(NCFactura, "###,###,###.00"), 2)))
            End If
            If NCBoleta + NCFactura > 0 Then
                obj.EscribirLinea(y + s + intFilasNC + 1, 56, "------------")
                obj.EscribirLinea(y + s + intFilasNC + 2, 10, "Total")
                iLinea = Len(Trim(IIf(NCBoleta + NCFactura = 0, "0.00", FormatNumber(Format(NCBoleta + NCFactura, "###,###,###.00"), 2))))
                obj.EscribirLinea(y + s + intFilasNC + 2, 67 - iLinea, IIf(NCBoleta + NCFactura = 0, "0.00", FormatNumber(Format(NCBoleta + NCFactura, "###,###,###.00"), 2)))
                If NCBoleta > 0 And NCFactura > 0 Then
                    intFilas -= 3
                End If
            End If

            '====EGRESOS================================
            obj.EscribirLinea(y + s + 9 + intFilas, 10, "EGRESOS")
            obj.EscribirLinea(y + s + 10 + intFilas, 10, "--------------")

            obj.EscribirLinea(y + s + 11 + intFilas, 10, "Venta Carga PCE")
            iLinea = Len(Trim(IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 11 + intFilas, 67 - iLinea, IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2)))


            obj.EscribirLinea(y + s + 12 + intFilas, 10, "Venta Carga Credito")
            iLinea = Len(Trim(IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 12 + intFilas, 67 - iLinea, IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 13 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 13 + intFilas, 56, "------------")
            obj.EscribirLinea(y + s + 14 + intFilas, 10, "Total")
            Dim itotalEgreso1 As Double = FormatNumber(totalPCECarga, 2) + TotalCredito
            '+ Abs(nc)
            iLinea = Len(Trim(IIf(itotalEgreso1 = 0, "0.00", FormatNumber(Format(itotalEgreso1, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 14 + intFilas, 67 - iLinea, IIf(itotalEgreso1 = 0, "0.00", FormatNumber(Format(itotalEgreso1, "###,###,###.00"), 2)))



            obj.EscribirLinea(y + s + 16 + intFilas, 10, "TC. Visa Carga")
            iLinea = Len(Trim(IIf(TotalMontoTarjeVisa = 0, "0.00", FormatNumber(Format(TotalMontoTarjeVisa, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 16 + intFilas, 67 - iLinea, IIf(TotalMontoTarjeVisa = 0, "0.00", FormatNumber(Format(TotalMontoTarjeVisa, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 17 + intFilas, 10, "TC. Master Carga")
            iLinea = Len(Trim(IIf(TotalMontoTarjeMaster = 0, "0.00", FormatNumber(Format(TotalMontoTarjeMaster, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 17 + intFilas, 67 - iLinea, IIf(TotalMontoTarjeMaster = 0, "0.00", FormatNumber(Format(TotalMontoTarjeMaster, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 18 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 18 + intFilas, 56, "------------")
            obj.EscribirLinea(y + s + 19 + intFilas, 10, "Total")
            Dim iTotalEgreso2 As Double = (TotalMontoTarjeVisa + TotalMontoTarjeMaster)
            iLinea = Len(Trim(IIf(iTotalEgreso2 = 0, "0.00", FormatNumber(Format(iTotalEgreso2, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 19 + intFilas, 67 - iLinea, IIf(iTotalEgreso2 = 0, "0.00", FormatNumber(Format(iTotalEgreso2, "###,###,###.00"), 2)))


            obj.EscribirLinea(y + s + 21 + intFilas, 10, "Devoluciones Carga")
            iLinea = Len(Trim(IIf(totalDevolucionCarga = 0, "0.00", FormatNumber(Format(totalDevolucionCarga, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 21 + intFilas, 67 - iLinea, IIf(totalDevolucionCarga = 0, "0.00", FormatNumber(Format(totalDevolucionCarga, "###,###,###.00"), 2))) 'p2
            obj.EscribirLinea(y + s + 22 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 22 + intFilas, 56, "------------")
            obj.EscribirLinea(y + s + 23 + intFilas, 10, "Total")
            Dim iTotalEgreso3 As Double = totalDevolucionCarga
            iLinea = Len(Trim(IIf(iTotalEgreso3 = 0, "0.00", FormatNumber(Format(iTotalEgreso3, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 23 + intFilas, 67 - iLinea, IIf(iTotalEgreso3 = 0, "0.00", FormatNumber(Format(iTotalEgreso3, "###,###,###.00"), 2)))

            '============================================================
            'Dim TRANSFERENCIA_BANCARIA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")), 0, (dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")))
            ' Dim DEVOLUCION_DE_CARGA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")), 0, (dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")))
            'Dim Gastos_Varios As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")))
            'Dim PAGO_PEAJE_FUERA_DEL_COUNT As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")))
            'Dim GASTOS_CON_RECIBO_DE_CAJA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")))
            'Dim PAGO_GIROS As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")))

            'obj.EscribirLinea(y + s + 33, 10, "Transferencia Bancarias") '
            'obj.EscribirLinea(y + s + 33, 61, TRANSFERENCIA_BANCARIA)


            obj.EscribirLinea(y + s + 25 + intFilas, 10, "Encomiendas Cortesia") 'carga
            iLinea = Len(Trim(IIf(totalEncomiendaCortesia = 0, "0.00", FormatNumber(Format(totalEncomiendaCortesia, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 25 + intFilas, 67 - iLinea, IIf(totalEncomiendaCortesia = 0, "0.00", FormatNumber(Format(totalEncomiendaCortesia, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 35, 10, "Devoluciones de Encomiendas") '
            'obj.EscribirLinea(y + s + 35, 61, DEVOLUCION_DE_CARGA) 'Carga

            'obj.EscribirLinea(y + s + 36, 10, "Gastos Varios")
            'obj.EscribirLinea(y + s + 36, 61, Gastos_Varios)

            'obj.EscribirLinea(y + s + 37, 10, "Peajes(Inc. Fuera del Counter)") '
            'obj.EscribirLinea(y + s + 37, 61, PAGO_PEAJE_FUERA_DEL_COUNT)

            'obj.EscribirLinea(y + s + 38, 10, "Giros Pagados") '
            'obj.EscribirLinea(y + s + 38, 61, PAGO_GIROS)

            'obj.EscribirLinea(y + s + 39, 10, "Gastos con Recibos de Caja") '
            'obj.EscribirLinea(y + s + 39, 61, GASTOS_CON_RECIBO_DE_CAJA)

            obj.EscribirLinea(y + s + 26 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 26 + intFilas, 56, "------------")
            obj.EscribirLinea(y + s + 27 + intFilas, 10, "Total")
            Dim iTotalEgreso4 As Double = (totalEncomiendaCortesia)
            iLinea = Len(Trim(IIf(iTotalEgreso4 = 0, "0.00", FormatNumber(Format(iTotalEgreso4, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 27 + intFilas, 67 - iLinea, IIf(iTotalEgreso4 = 0, "0.00", FormatNumber(Format(iTotalEgreso4, "###,###,###.00"), 2)))

            'Nota de Credito
            obj.EscribirLinea(y + s + 29 + intFilas, 10, "NC Carga") '
            iLinea = Len(IIf(nc = 0, "0.00", FormatNumber(Format(nc, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 29 + intFilas, 67 - iLinea, IIf(nc = 0, "0.00", FormatNumber(Format(nc, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 30 + intFilas, 10, "----------------------") : obj.EscribirLinea(y + s + 30, 56, "-----------")
            obj.EscribirLinea(y + s + 31 + intFilas, 10, "Total")
            iLinea = Len(IIf(nc = 0, "0.00", FormatNumber(Format(nc, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 31 + intFilas, 67 - iLinea, IIf(nc = 0, "0.00", FormatNumber(Format(nc, "###,###,###.00"), 2)))


            Dim iTotalOtrosEgresos As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_EGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_EGRESOS"))
            obj.EscribirLinea(y + s + 33 + intFilas, 10, "OTROS EGRESOS") '2 
            iLinea = Len(Trim(IIf(iTotalOtrosEgresos = 0, "0.00", FormatNumber(Format(iTotalOtrosEgresos, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 33 + intFilas, 67 - iLinea, IIf(iTotalOtrosEgresos = 0, "0.00", FormatNumber(Format(iTotalOtrosEgresos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 34 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 34 + intFilas, 56, "------------")
            obj.EscribirLinea(y + s + 35 + intFilas, 10, "Total")
            obj.EscribirLinea(y + s + 35 + intFilas, 67 - iLinea, IIf(iTotalOtrosEgresos = 0, "0.00", FormatNumber(Format(iTotalOtrosEgresos, "###,###,###.00"), 2)))


            Dim iTotalGeneralIngresos2 As Double = totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + TotalCredito + iTotalIngresos
            Dim iTotalEgresos As Double = itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4 + iTotalOtrosEgresos
            Dim iTotalSaldoDepositar As Double = (totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + iTotalIngresos + TotalCredito) - (itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4 + iTotalOtrosEgresos)
            obj.EscribirLinea(y + s + 37 + intFilas, 10, "-----------------------------")
            obj.EscribirLinea(y + s + 37 + intFilas, 56, "------------")
            obj.EscribirLinea(y + s + 38 + intFilas, 10, "Total Ingresos")
            iLinea = Len(Trim(IIf(iTotalGeneralIngresos2 = 0, "0.00", FormatNumber(Format(iTotalGeneralIngresos2, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 38 + intFilas, 67 - iLinea, IIf(iTotalGeneralIngresos2 = 0, "0.00", FormatNumber(Format(iTotalGeneralIngresos2, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 39 + intFilas, 10, "Total Egresos")
            iLinea = Len(Trim(IIf(iTotalEgresos = 0, "0.00", FormatNumber(Format(iTotalEgresos, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 39 + intFilas, 67 - iLinea, IIf(iTotalEgresos = 0, "0.00", FormatNumber(Format(iTotalEgresos, "###,###,###.00"), 2)))


            obj.EscribirLinea(y + s + 40 + intFilas, 10, "Saldo a Entregar")
            iLinea = Len(Trim(IIf(iTotalSaldoDepositar = 0, "0.00", FormatNumber(Format(iTotalSaldoDepositar, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 40 + intFilas, 67 - iLinea, IIf(iTotalSaldoDepositar = 0, "0.00", FormatNumber(Format(iTotalSaldoDepositar, "###,###,###.00"), 2)))

            obj.Comprimido = True
            obj.Preliminar = True
            obj.Tamaño = iLong
            obj.ReglaVertical = False
            obj.Imprimir()
            obj.Finalizar()

            Dim frm As New FrmPreview
            frm.WindowState = FormWindowState.Maximized
            frm.Tamaño = iLong
            frm.Documento = 1
            frm.Text = "Factura"
            frm.ShowDialog()

            objImprimir = Nothing
            objImpresora = Nothing
        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Dim iformato As Boolean
    Private Sub DgvAgencia_DoubleClick(sender As System.Object, e As System.EventArgs) Handles DgvAgencia.DoubleClick
        Try
            If DgvUsuario.Rows.Count <= 0 Then
                Return
            End If

            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtoCierreOficina
            Dim row As Integer = DgvAgencia.SelectedRows.Item(0).Index
            Dim ds As DataSet = obj.ListaGastoLiquidacion(dtoUSUARIOS.m_iIdAgencia, DgvAgencia.Rows(row).Cells("fecha_apertura").Value, _
                                                     DgvAgencia.Rows(row).Cells("Codigo").Value, DgvAgencia.Rows(row).Cells("Usuario_Creacion").Value) 'Usuario_Creacion

            If ds.Tables(0).Rows.Count <= 0 Then
                MessageBox.Show("No tiene Gastos ingresados", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                iFormato = True
                Me.FormatoDgvGastosXCounter()
                With DgvGastosXCounter
                    .DataSource = ds.Tables(0)
                End With


                Me.TabLiquidacion.Controls.Add(TabGastos)
                Me.TabLiquidacion.SelectTab(2)
                LblNombre.Text = DgvAgencia.Rows(row).Cells("Usuario").Value
                LblMontoGasto.Text = ds.Tables(0).Compute("sum(MONTO)", "")
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvAgencia_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvAgencia.CellContentClick

    End Sub

    Private Sub BtnImp_Click(sender As System.Object, e As System.EventArgs) Handles BtnImp.Click

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

    End Sub
End Class