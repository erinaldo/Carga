Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class FrmTarifarioPublico
    Dim blnActualizar As Boolean
    'Dim dtOrigen, dtRemitenteParalelo As DataTable
    Private ObjTarifaPublica As New Cls_TarifaPublica_LN
    Private utilitarios As New Cls_Utilitarios
    Public hnd As Long
    Dim bIngreso As Boolean
    'Dim idTarifaCarga As String
    Dim dtArticulos As New DataTable '-->Guarda el maestro de articulos (esto se carga al momento de cargar en el Load)
    Dim utilData As New UtilData_LN
    Dim SOLO_PRODUCTOS_CONTADO As Integer = 0
    Dim action As Integer
    Dim ACTION_NEW As Integer = 0
    Dim ACTION_UPDATE As Integer = 1
    Private WithEvents celda As DataGridViewTextBoxEditingControl
#Region "CONFIG DGV"
    Private Sub configDGVTarifa()
        Dim x As Integer = 0
        With DgvTarifasPeso
            Dim Col_idTarifaCargo As New DataGridViewTextBoxColumn
            With Col_idTarifaCargo
                .Name = "idTarifa_Cargo" : .DataPropertyName = "idTarifa_Cargo"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_idTarifaPublica As New DataGridViewTextBoxColumn
            With Col_idTarifaPublica
                .Name = "idTarifa_Publica" : .DataPropertyName = "idTarifa_Publica"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_idOrigen As New DataGridViewTextBoxColumn
            With Col_idOrigen
                .Name = "idCiudadOrigen" : .DataPropertyName = "idCiudadOrigen"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_idDestino As New DataGridViewTextBoxColumn
            With Col_idDestino
                .Name = "idCiudadDestino" : .DataPropertyName = "idCiudadDestino"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_Origen As New DataGridViewTextBoxColumn
            With Col_Origen
                .HeaderText = "ORIGEN" : .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim Col_Destino As New DataGridViewTextBoxColumn
            With Col_Destino
                .HeaderText = "DESTINO" : .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim Col_Base As New DataGridViewTextBoxColumn
            With Col_Base
                .HeaderText = "PRECIO BASE" : .Name = "base" : .DataPropertyName = "base"
                .DisplayIndex = x : .Width = 50
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim Col_Peso As New DataGridViewTextBoxColumn
            With Col_Peso
                .HeaderText = "PRECIO PESO" : .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Width = 50
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim Col_Volumen As New DataGridViewTextBoxColumn
            With Col_Volumen
                .HeaderText = "PRECIO VOLUMEN" : .Name = "volumen" : .DataPropertyName = "volumen"
                .DisplayIndex = x : .Width = 50
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim Col_Sobre As New DataGridViewTextBoxColumn
            With Col_Sobre
                .HeaderText = "PRECIO SOBRE" : .Name = "sobre" : .DataPropertyName = "sobre"
                .DisplayIndex = x : .Width = 50
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim Col_PesoMinimo As New DataGridViewTextBoxColumn
            With Col_PesoMinimo
                .HeaderText = "PESO MINIMO" : .Name = "PesoMinimo" : .DataPropertyName = "PesoMinimo"
                .DisplayIndex = x : .Width = 50
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim Col_FletePesoMinimo As New DataGridViewTextBoxColumn
            With Col_FletePesoMinimo
                .HeaderText = "FLETE PESO MINIMO" : .Name = "FletePesoMinimo" : .DataPropertyName = "FletePesoMinimo"
                .DisplayIndex = x : .Width = 50
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim Col_VolMinimo As New DataGridViewTextBoxColumn
            With Col_VolMinimo
                .HeaderText = "VOLUMEN MINIMO" : .Name = "VolMinimo" : .DataPropertyName = "VolMinimo"
                .DisplayIndex = x : .Width = 50
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim Col_FleteVolMinimo As New DataGridViewTextBoxColumn
            With Col_FleteVolMinimo
                .HeaderText = "FLETE VOLUMEN MINIMO" : .Name = "FleteVolMinimo" : .DataPropertyName = "FleteVolMinimo"
                .DisplayIndex = x : .Width = 50
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim col_Producto As New DataGridViewTextBoxColumn
            With col_Producto
                .HeaderText = "PRODUCTO" : .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Width = 100
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_TipoTarifa As New DataGridViewTextBoxColumn
            With col_TipoTarifa
                .HeaderText = "TIPO TARIFA" : .Name = "tipo_Tarifa" : .DataPropertyName = "tipo_Tarifa"
                .DisplayIndex = x : .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim Col_idtipo_entrega As New DataGridViewTextBoxColumn
            With Col_idtipo_entrega
                .HeaderText = "IDTIPO_ENTREGA" : .Name = "idtipo_entrega" : .DataPropertyName = "idtipo_entrega"
                .DisplayIndex = x : .Width = 80 : .Visible = False
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim Col_idciudad As New DataGridViewTextBoxColumn
            With Col_idciudad
                .HeaderText = "IDCIUDAD" : .Name = "idciudad" : .DataPropertyName = "idciudad"
                .DisplayIndex = x : .Width = 80 : .Visible = False
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim Col_ciudad As New DataGridViewTextBoxColumn
            With Col_ciudad
                .HeaderText = "CIUDAD" : .Name = "ciudad" : .DataPropertyName = "ciudad"
                .DisplayIndex = x : .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim Col_FechaActivacion As New DataGridViewTextBoxColumn
            With Col_FechaActivacion
                .HeaderText = "FECHA ACTIVACION" : .Name = "fecha_Activacion" : .DataPropertyName = "fecha_Activacion"
                .DisplayIndex = x : .Width = 70
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_Visibilidad As New DataGridViewTextBoxColumn
            With col_Visibilidad
                .HeaderText = "TIPO VISIBILIDAD" : .Name = "visibilidad" : .DataPropertyName = "visibilidad"
                .DisplayIndex = x : .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim Col_UsuarioRegistro As New DataGridViewTextBoxColumn
            With Col_UsuarioRegistro
                .HeaderText = "USUARIO REGISTRO" : .Name = "nombre_personal" : .DataPropertyName = "nombre_personal"
                .DisplayIndex = x : .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(Col_idTarifaCargo, Col_idTarifaPublica, Col_idOrigen, Col_idDestino, _
                              Col_Origen, Col_Destino, Col_Base, Col_Peso, Col_Volumen, Col_Sobre, Col_PesoMinimo, Col_FletePesoMinimo, _
                              Col_VolMinimo, Col_FleteVolMinimo, col_Producto, col_TipoTarifa, Col_idtipo_entrega, Col_idciudad, Col_ciudad, Col_FechaActivacion, col_Visibilidad, Col_UsuarioRegistro)
        End With
    End Sub
    Private Sub configDGVTarifasArticulos()
        Dim x As Integer = 0
        With DgvTarifaArticulos
            Dim Col_idTarifaArticulo As New DataGridViewTextBoxColumn
            With Col_idTarifaArticulo
                .Name = "idTarifa_Articulo" : .DataPropertyName = "idTarifa_Articulo"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_idTarifaPublica As New DataGridViewTextBoxColumn
            With Col_idTarifaPublica
                .Name = "idtarifa_publica" : .DataPropertyName = "idtarifa_publica"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_idTipoTarifa As New DataGridViewTextBoxColumn
            With Col_idTipoTarifa
                .Name = "idTipo_tarifa" : .DataPropertyName = "idTipo_tarifa"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_idProceso As New DataGridViewTextBoxColumn
            With Col_idProceso
                .Name = "idProcesos" : .DataPropertyName = "idProcesos"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_idArticulo As New DataGridViewTextBoxColumn
            With Col_idArticulo
                .Name = "idArticulos" : .DataPropertyName = "idArticulos"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_idOrigen As New DataGridViewTextBoxColumn
            With Col_idOrigen
                .Name = "idCiudadOrigen" : .DataPropertyName = "idCiudadOrigen"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_idDestino As New DataGridViewTextBoxColumn
            With Col_idDestino
                .Name = "idCiudadDestino" : .DataPropertyName = "idCiudadDestino"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_Origen As New DataGridViewTextBoxColumn
            With Col_Origen
                .HeaderText = "ORIGEN" : .Name = "Origen" : .DataPropertyName = "Origen"
                .DisplayIndex = x : .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
            End With
            x += +1
            Dim Col_Destino As New DataGridViewTextBoxColumn
            With Col_Destino
                .HeaderText = "DESTINO" : .Name = "Destino" : .DataPropertyName = "Destino"
                .DisplayIndex = x : .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
            End With
            x += +1
            Dim Col_idtipo_entrega As New DataGridViewTextBoxColumn
            With Col_idtipo_entrega
                .Name = "idtipo_entrega" : .DataPropertyName = "idtipo_entrega"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_tipo_entrega As New DataGridViewTextBoxColumn
            With Col_tipo_entrega
                .HeaderText = "TIPO ENTREGA" : .Name = "tipo_entrega" : .DataPropertyName = "tipo_entrega"
                .DisplayIndex = x : .Visible = True : .Width = 80
            End With
            x += +1
            Dim Col_Nombre_Articulo As New DataGridViewTextBoxColumn
            With Col_Nombre_Articulo
                .HeaderText = "NOMBRE ARTICULO" : .Name = "Nombre_Articulo" : .DataPropertyName = "Nombre_Articulo"
                .DisplayIndex = x : .Width = 240
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
            End With
            x += +1
            Dim Col_Importe As New DataGridViewTextBoxColumn
            With Col_Importe
                .HeaderText = "IMPORTE" : .Name = "importe" : .DataPropertyName = "importe"
                .DisplayIndex = x : .Width = 70
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
            End With
            x += +1
            Dim Col_FechaActivacion As New DataGridViewTextBoxColumn
            With Col_FechaActivacion
                .HeaderText = "FECHA ACTIVACION" : .Name = "fecha_Activacion" : .DataPropertyName = "fecha_Activacion"
                .DisplayIndex = x : .Width = 65
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim Col_UsuarioRegistro As New DataGridViewTextBoxColumn
            With Col_UsuarioRegistro
                .HeaderText = "USUARIO REGISTRO" : .Name = "nombre_personal" : .DataPropertyName = "nombre_personal"
                .DisplayIndex = x : .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.AddRange(Col_idTarifaArticulo, Col_idTarifaPublica, Col_idTipoTarifa, Col_idProceso, Col_idArticulo, Col_idOrigen, Col_idDestino, Col_Origen, _
                              Col_Destino, Col_idtipo_entrega, Col_tipo_entrega, Col_Nombre_Articulo, Col_Importe, Col_FechaActivacion, Col_UsuarioRegistro)
        End With
    End Sub
    Private Sub configDGVMntTarifasArticulos()
        Dim x As Integer = 0
        With DgvMntTarifaArticulos
            Dim Col_idTarifaClienteArticulo As New DataGridViewTextBoxColumn
            With Col_idTarifaClienteArticulo
                .Name = "idTarifa_Articulo" : .DataPropertyName = "idTarifa_Articulo"
                .DisplayIndex = x : .Visible = False : .ReadOnly = True
            End With
            x += +1
            Dim Col_idTarifaCliente As New DataGridViewTextBoxColumn
            With Col_idTarifaCliente
                .Name = "idTarifa_Publica" : .DataPropertyName = "idTarifa_Publica"
                .DisplayIndex = x : .Visible = False : .ReadOnly = True
            End With
            x += +1
            Dim Col_idArticulo As New DataGridViewTextBoxColumn
            With Col_idArticulo
                .Name = "idArticulos" : .DataPropertyName = "idArticulos"
                .DisplayIndex = x : .Visible = False : .ReadOnly = True
            End With
            x += +1
            Dim Col_Nombre_Articulo As New DataGridViewTextBoxColumn
            With Col_Nombre_Articulo
                .HeaderText = "NOMBRE ARTICULO" : .Name = "Nombre_Articulo" : .DataPropertyName = "Nombre_Articulo"
                .DisplayIndex = x : .Width = 320
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
            End With
            x += +1
            Dim Col_Importe As New DataGridViewTextBoxColumn
            With Col_Importe
                .HeaderText = "IMPORTE" : .Name = "importe" : .DataPropertyName = "importe"
                .DisplayIndex = x : .Width = 100
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
            End With

            .Columns.AddRange(Col_idTarifaClienteArticulo, Col_idTarifaCliente, Col_idArticulo, Col_Nombre_Articulo, Col_Importe)
        End With
    End Sub
#End Region
#Region "FUNCIONES"
    ''' <summary>
    ''' Carga tarifas publicas
    ''' </summary>
    ''' <param name="dataSet">Registro a cargar en el Grid</param>
    Sub cargarDataGridTarifas(ByVal dataSet As DataSet)
        '-->Carga tarifas por peso
        DgvTarifasPeso.Columns.Clear()
        utilitarios.FormatDataGridView(DgvTarifasPeso)
        configDGVTarifa()
        DgvTarifasPeso.RowHeadersWidth = 20
        DgvTarifasPeso.DataSource = dataSet.Tables(0)
        DgvTarifasPeso.ReadOnly = True

        '-->Carga tarifas por Articulo
        DgvTarifaArticulos.Columns.Clear()
        utilitarios.FormatDataGridView(DgvTarifaArticulos)
        configDGVTarifasArticulos()
        DgvTarifaArticulos.DataSource = dataSet.Tables(1)
        DgvTarifaArticulos.ReadOnly = True

        If DirectCast(DgvTarifasPeso.DataSource, DataTable).Rows.Count = 0 And _
            DirectCast(DgvTarifaArticulos.DataSource, DataTable).Rows.Count = 0 Then
            MsgBox("No se Encontraron Registros", MsgBoxStyle.Information, "Aviso")
            lblCantRegXPeso.Text = "0"
        Else
            If (DirectCast(DgvTarifasPeso.DataSource, DataTable).Rows.Count > 0) Then
                tcListaTarifas.SelectedIndex = 0
            ElseIf (DirectCast(DgvTarifaArticulos.DataSource, DataTable).Rows.Count > 0) Then
                tcListaTarifas.SelectedIndex = 1
            End If

            lblCantRegXArticulos.Text = DirectCast(DgvTarifaArticulos.DataSource, DataTable).Rows.Count
            lblCantRegXPeso.Text = DirectCast(DgvTarifasPeso.DataSource, DataTable).Rows.Count
        End If

        'TabCliente.Parent = Me.tcTarifas
        'tcTarifario.SelectedIndex = 1
    End Sub
    Sub enabledControlMnt(ByVal estado As Boolean)
        CboOrigen_Mnt.Enabled = estado
        cboDestino_Mnt.Enabled = estado
        ckbTarifaNormal.Enabled = estado
        ckbTarifaArticulos.Enabled = estado

        '-->Tarifa Normal
        cboProducto_Peso.Enabled = estado
        cboTipoTarifa_Peso.Enabled = estado
        cboVisibilidad_Peso.Enabled = estado
        cboTipoEntrega.Enabled = estado
        cboCiudad.Enabled = estado
        dtpFechaActivacion_Peso.Enabled = estado
        txtBase.Enabled = estado
        txtPeso.Enabled = estado
        txtVolumen.Enabled = estado
        txtSobre.Enabled = estado
        txtPesoMinimo.Enabled = estado
        txtFleteMinimoPeso.Enabled = estado
        txtVolumenMinimo.Enabled = estado
        txtFleteMinimoVolumen.Enabled = estado

        '-->Articulos
        cboProducto_Articulos.Enabled = estado
        cboTipoTarifa_Articulos.Enabled = estado
        dtpFechaActivacion_Articulos.Enabled = estado
    End Sub
    Sub clearMnt()
        CboOrigen_Mnt.SelectedIndex = 0
        cboDestino_Mnt.SelectedIndex = 0
        ckbTarifaNormal.Checked = False
        ckbTarifaArticulos.Checked = False

        '-->Tarifa Normal
        cboProducto_Peso.SelectedIndex = 0
        cboTipoTarifa_Peso.SelectedIndex = 0
        cboVisibilidad_Peso.SelectedIndex = 0
        cboTipoEntrega.SelectedIndex = 0
        cboCiudad.SelectedIndex = 0
        dtpFechaActivacion_Peso.Text = "01/01/1990"
        txtBase.Text = 0.0
        txtPeso.Text = 0.0
        txtVolumen.Text = 0.0
        txtSobre.Text = 0.0
        txtPesoMinimo.Text = 0.0
        txtFleteMinimoPeso.Text = 0.0
        txtVolumenMinimo.Text = 0.0
        txtFleteMinimoVolumen.Text = 0.0

        '-->Articulos
        cboProducto_Articulos.SelectedIndex = 0
        cboTipoTarifa_Articulos.SelectedIndex = 0
        DgvMntTarifaArticulos.DataSource = Nothing
        dtpFechaActivacion_Articulos.Text = "01/01/1990"
    End Sub
    Function iniColumnsDgvMntTarifasArticulos() As DataTable
        Dim dtTarifaArticulos As New DataTable
        dtTarifaArticulos.Columns.Add("idTarifa_Articulo").DataType = GetType(Integer)
        dtTarifaArticulos.Columns.Add("idTarifa_Publica").DataType = GetType(Integer)
        dtTarifaArticulos.Columns.Add("idArticulos").DataType = GetType(Integer)
        dtTarifaArticulos.Columns.Add("Nombre_Articulo").DataType = GetType(String)
        dtTarifaArticulos.Columns.Add("importe").DataType = GetType(Double)

        Return dtTarifaArticulos
    End Function
    Sub cargarDataGridMntTarifasArticulos(Optional ByVal dtTarifaXArticulo As DataRow() = Nothing)
        DgvMntTarifaArticulos.DataSource = Nothing

        Dim dtArticulo As New DataTable
        '-->inicia columns
        dtArticulo = iniColumnsDgvMntTarifasArticulos()

        '-->Carga articulos del maestro
        Dim idTarifaClienteArticulo As Integer = 0
        Dim idtarifa_cliente As Integer = 0
        Dim importe As Double = 0.0
        For Each rowAr As DataRow In dtArticulos.Rows
            dtArticulo.Rows.Add(idTarifaClienteArticulo,
                                 idtarifa_cliente,
                                 rowAr("idArticulos"),
                                 rowAr("Nombre_Articulo"),
                                 importe)
        Next

        '-->Cuando es una edición
        If (action = ACTION_UPDATE And IsNothing(dtTarifaXArticulo) = False) Then
            For Each rowAC As DataRow In dtTarifaXArticulo '-->Articulos recuperados del cliente
                For Each rowAr As DataRow In dtArticulo.Rows '-->Articulos cargados en al paso anterior
                    '-->Compara los articulos del cliente con los del maestro cargado anteriormente
                    If (rowAC("idArticulos") = rowAr("idArticulos")) Then
                        rowAr("idTarifa_Articulo") = rowAC("idTarifa_Articulo")
                        rowAr("idTarifa_Publica") = rowAC("idTarifa_Publica")
                        rowAr("importe") = rowAC("importe")
                        Exit For
                    End If
                Next
            Next
        End If

        '-->Caga el DgvMntArticulos
        DgvMntTarifaArticulos.Columns.Clear()
        utilitarios.FormatDataGridView(DgvMntTarifaArticulos)
        configDGVMntTarifasArticulos()
        DgvMntTarifaArticulos.DataSource = dtArticulo
        '-->
        DgvMntTarifaArticulos.Columns("Importe").ReadOnly = False
        DgvMntTarifaArticulos.Columns("Nombre_Articulo").ReadOnly = True
        DgvMntTarifaArticulos.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
    End Sub
#End Region
    Private Sub FrmTarifarioPublico_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub
    Private Sub FrmTarifarioPublico_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmTarifarioPublico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            blnActualizar = Acceso.SiRol(G_Rol, Me, 1)


            utilData.cargarCombos("t_unidadAgencia", cboBusq_Origen, True)
            '-->Pasa solamente el DataSouce del Combo Origen para cargar los demas combos y evitar el acceso al Sever
            'ya que se trata de la carga de los mismos datos de la misma tabla t_unidad_Agencia
            utilData.cargarCombos(, cboBusq_Destino, True, cboBusq_Origen.DataSource)
            utilData.cargarCombos("t_procesos", CboBusq_Producto, True, , SOLO_PRODUCTOS_CONTADO)
            utilData.cargarCombos("t_tipotarifa", cboBusq_TipoTarifa, True)
            utilData.cargarTipoVisibilidad(CboBusq_TipoVisibildad, True)

            utilData.cargarCombos(, CboOrigen_Mnt, False, cboBusq_Origen.DataSource)
            utilData.cargarCombos(, cboDestino_Mnt, False, cboBusq_Origen.DataSource)
            utilData.cargarCombos(, cboCiudad, False, cboBusq_Origen.DataSource)

            utilData.cargarCombos(, cboProducto_Peso, False, CboBusq_Producto.DataSource)
            utilData.cargarCombos(, cboTipoTarifa_Peso, False, cboBusq_TipoTarifa.DataSource)
            utilData.cargarTipoVisibilidad(cboVisibilidad_Peso, False)
            utilData.cargarTipoEntrega(cboTipoEntrega, False)

            utilData.cargarCombos(, cboProducto_Articulos, False, CboBusq_Producto.DataSource)
            utilData.cargarCombos(, cboTipoTarifa_Articulos, False, cboBusq_TipoTarifa.DataSource)

            dtArticulos = utilData.buscarArticulos()

            enabledControlMnt(False)

            tpArticulos.Parent = Nothing
            tpNormal.Parent = Nothing

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)

            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SalirToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim idOrigen As Integer = cboBusq_Origen.SelectedValue
            Dim idDestino As Integer = cboBusq_Destino.SelectedValue
            Dim idProducto As Integer = CboBusq_Producto.SelectedValue
            Dim idTipoTarifa As Integer = cboBusq_TipoTarifa.SelectedValue
            Dim idTipoVisivilidad As Integer = CboBusq_TipoVisibildad.SelectedValue

            cargarDataGridTarifas(ObjTarifaPublica.BuscarTarifarioPublico(idOrigen, idDestino, idTipoVisivilidad, idProducto, idTipoTarifa, 0, -1))

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbNuevo.Click
        action = ACTION_NEW
        clearMnt()
        '-->Carga articulos
        cargarDataGridMntTarifasArticulos()
        enabledControlMnt(True)
        tcTarifario.SelectedIndex = 1
        CboOrigen_Mnt.Focus()
    End Sub
    Private Sub ExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DgvTarifasPeso.RowCount < 1 Then
            Return
        Else
            Dim lcls_Utilitarios As New Cls_Utilitarios
            With lcls_Utilitarios
                .fnEXCELGrid_ConFormato(Me.DgvTarifasPeso)
            End With
            lcls_Utilitarios = Nothing
        End If
    End Sub
    Private Sub ckbTarifaNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbTarifaNormal.CheckedChanged
        Try
            btnGuardar.Enabled = True
            dtpFechaActivacion_Peso.Text = dtoUSUARIOS.m_sFecha

            If (ckbTarifaNormal.Checked And ckbTarifaArticulos.Checked = False) Then
                tpArticulos.Parent = Nothing
                tpNormal.Parent = tcTipo
            ElseIf (ckbTarifaNormal.Checked = False And ckbTarifaArticulos.Checked) Then
                tpNormal.Parent = Nothing
            ElseIf (ckbTarifaNormal.Checked And ckbTarifaArticulos.Checked) Then
                tpNormal.Parent = tcTipo
                tpNormal.Select()
            Else
                tpArticulos.Parent = Nothing
                tpNormal.Parent = Nothing
                btnGuardar.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ckbTarifaArticulos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbTarifaArticulos.CheckedChanged
        Try
            btnGuardar.Enabled = True
            dtpFechaActivacion_Articulos.Text = dtoUSUARIOS.m_sFecha

            If (ckbTarifaArticulos.Checked And ckbTarifaNormal.Checked = False) Then
                tpArticulos.Parent = tcTipo
                tpNormal.Parent = Nothing
            ElseIf (ckbTarifaArticulos.Checked = False And ckbTarifaNormal.Checked) Then
                tpArticulos.Parent = Nothing
            ElseIf (ckbTarifaArticulos.Checked And ckbTarifaNormal.Checked) Then
                tpArticulos.Parent = tcTipo
                tpArticulos.Select()
            Else
                tpArticulos.Parent = Nothing
                tpNormal.Parent = Nothing
                btnGuardar.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tcTarifario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcTarifario.SelectedIndexChanged
        Try
            If (tcTarifario.SelectedIndex = 0) Then
                btnCancelar_Click(1, Nothing)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            tcTarifario.SelectedIndex = 0
            enabledControlMnt(False)
            clearMnt()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cboBusq_Origen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboBusq_Origen.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub cboBusq_Destino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboBusq_Destino.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub CboOrigen_Mnt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboOrigen_Mnt.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub cboDestino_Mnt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDestino_Mnt.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub txtBase_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBase.GotFocus
        txtBase.SelectAll()
    End Sub
    Private Sub txtPeso_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeso.GotFocus
        txtPeso.SelectAll()
    End Sub
    Private Sub txtVolumen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVolumen.GotFocus
        txtVolumen.SelectAll()
    End Sub
    Private Sub txtSobre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSobre.GotFocus
        txtSobre.SelectAll()
    End Sub
    Private Sub txtPesoMinimo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPesoMinimo.GotFocus
        txtPesoMinimo.SelectAll()
    End Sub
    Private Sub txtFleteMinimoPeso_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFleteMinimoPeso.GotFocus
        txtFleteMinimoPeso.SelectAll()
    End Sub
    Private Sub txtVolumenMinimo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVolumenMinimo.GotFocus
        txtVolumenMinimo.SelectAll()
    End Sub
    Private Sub txtFleteMinimoVolumen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFleteMinimoVolumen.GotFocus
        txtFleteMinimoVolumen.SelectAll()
    End Sub

    Private Sub txtBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBase.KeyPress
        If (Char.IsDigit(e.KeyChar)) Then
            e.Handled = False
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        ElseIf (e.KeyChar = ".") Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtBase_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBase.KeyUp
        If (e.KeyCode = Keys.Enter) Then txtPesoMinimo.Focus()
    End Sub

    Private Sub txtPeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeso.KeyPress
        If (Char.IsDigit(e.KeyChar)) Then
            e.Handled = False
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        ElseIf (e.KeyChar = ".") Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtPeso_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPeso.KeyUp
        If (e.KeyCode = Keys.Enter) Then txtVolumen.Focus()
    End Sub

    Private Sub txtVolumen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVolumen.KeyPress
        If (Char.IsDigit(e.KeyChar)) Then
            e.Handled = False
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        ElseIf (e.KeyChar = ".") Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtVolumen_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVolumen.KeyUp
        If (e.KeyCode = Keys.Enter) Then txtSobre.Focus()
    End Sub

    Private Sub txtSobre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSobre.KeyPress
        If (Char.IsDigit(e.KeyChar)) Then
            e.Handled = False
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        ElseIf (e.KeyChar = ".") Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtSobre_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSobre.KeyUp
        If (e.KeyCode = Keys.Enter) Then txtBase.Focus()
    End Sub

    Private Sub txtPesoMinimo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPesoMinimo.KeyPress
        If (Char.IsDigit(e.KeyChar)) Then
            e.Handled = False
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        ElseIf (e.KeyChar = ".") Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtPesoMinimo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPesoMinimo.KeyUp
        If (e.KeyCode = Keys.Enter) Then txtFleteMinimoPeso.Focus()
    End Sub

    Private Sub txtFleteMinimoPeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFleteMinimoPeso.KeyPress
        If (Char.IsDigit(e.KeyChar)) Then
            e.Handled = False
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        ElseIf (e.KeyChar = ".") Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtFleteMinimoPeso_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFleteMinimoPeso.KeyUp
        If (e.KeyCode = Keys.Enter) Then txtVolumenMinimo.Focus()
    End Sub

    Private Sub txtVolumenMinimo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVolumenMinimo.KeyPress
        If (Char.IsDigit(e.KeyChar)) Then
            e.Handled = False
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        ElseIf (e.KeyChar = ".") Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtVolumenMinimo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVolumenMinimo.KeyUp
        If (e.KeyCode = Keys.Enter) Then txtFleteMinimoVolumen.Focus()
    End Sub
    Private Sub DgvTarifaArticulos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvTarifaArticulos.DoubleClick
        Try
            Me.Cursor = Cursors.WaitCursor
            action = ACTION_UPDATE

            ckbTarifaNormal.Enabled = False
            ckbTarifaNormal.Checked = False
            ckbTarifaArticulos.Checked = True

            Dim row As DataRow
            row = DirectCast(DgvTarifaArticulos.DataSource, DataTable).Rows(DgvTarifaArticulos.CurrentRow.Index)

            CboOrigen_Mnt.Text = row("origen")
            cboDestino_Mnt.Text = row("destino")
            cboProducto_Articulos.SelectedValue = row("idProcesos")
            cboTipoTarifa_Articulos.SelectedValue = row("idTipo_Tarifa")
            cboTipoEntrega.SelectedValue = row("idtipo_entrega")
            dtpFechaActivacion_Articulos.Text = IIf(IsDBNull(row("fecha_Activacion")), "01/01/1990", row("fecha_Activacion"))

            '-->Carga tarifas x articulos, si es que lo tubiese
            Dim dtTarifasArticulos As New DataTable
            Dim rowTA As DataRow()
            dtTarifasArticulos = DgvTarifaArticulos.DataSource
            If (dtTarifasArticulos.Rows.Count > 0) Then
                rowTA = dtTarifasArticulos.Select("idTarifa_Publica=" & DgvTarifaArticulos.CurrentRow.Cells("idTarifa_Publica").Value)

                'rowTA = dtTarifasArticulos.Select("idCiudadOrigen=" & CboOrigen_Mnt.SelectedValue & " AND idCiudadDestino=" _
                '                                  & cboDestino_Mnt.SelectedValue & " AND idProcesos=" & CboBusq_Producto.SelectedValue & _
                '                                  " AND idTipo_Tarifa=" & cboBusq_TipoTarifa.SelectedValue)
                If (rowTA.Length > 0) Then
                    cargarDataGridMntTarifasArticulos(rowTA)
                Else
                    cargarDataGridMntTarifasArticulos()
                End If
            Else
                cargarDataGridMntTarifasArticulos()
            End If

            enabledControlMnt(False)

            btnGuardar.Enabled = True
            tcTarifario.SelectedIndex = 1
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DgvTarifasPeso_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvTarifasPeso.DoubleClick
        Try
            Me.Cursor = Cursors.WaitCursor
            action = ACTION_UPDATE

            ckbTarifaArticulos.Enabled = False
            ckbTarifaArticulos.Checked = False
            ckbTarifaNormal.Checked = True

            Dim row As DataRow
            row = DirectCast(DgvTarifasPeso.DataSource, DataTable).Rows(DgvTarifasPeso.CurrentRow.Index)


            CboOrigen_Mnt.Text = row("origen")
            cboDestino_Mnt.Text = row("destino")
            cboProducto_Peso.Text = row("producto")
            cboTipoTarifa_Peso.Text = row("tipo_Tarifa")
            cboVisibilidad_Peso.Text = row("visibilidad")
            cboTipoEntrega.Text = row("tipoentrega")
            cboCiudad.SelectedValue = IIf(IsDBNull(row("idciudad")), -1, row("idciudad"))
            dtpFechaActivacion_Peso.Text = IIf(IsDBNull(row("fecha_Activacion")), "01/01/1990", row("fecha_Activacion"))

            txtBase.Text = Format(row("base"), "#,###.#0")
            txtPeso.Text = Format(row("peso"), "#,###.#0")
            txtVolumen.Text = Format(row("volumen"), "#,###.#0")
            txtSobre.Text = Format(row("Sobre"), "#,###.#0")
            txtPesoMinimo.Text = Format(row("PesoMinimo"), "#,###.#0")
            txtFleteMinimoPeso.Text = Format(row("FletePesoMinimo"), "#,###.#0")
            txtVolumenMinimo.Text = Format(row("VolMinimo"), "#,###.#0")
            txtFleteMinimoVolumen.Text = Format(row("FleteVolMinimo"), "#,###.#0")

            enabledControlMnt(True)
            CboOrigen_Mnt.Enabled = False
            cboDestino_Mnt.Enabled = False
            ckbTarifaArticulos.Enabled = False
            ckbTarifaNormal.Enabled = False
            cboProducto_Peso.Enabled = False
            cboTipoTarifa_Peso.Enabled = False
            cboVisibilidad_Peso.Enabled = False
            cboTipoEntrega.Enabled = False
            cboCiudad.Enabled = False
            dtpFechaActivacion_Peso.Enabled = False

            btnGuardar.Enabled = True
            tcTarifario.SelectedIndex = 1

            cboProducto_Peso_SelectedIndexChanged(Nothing, Nothing)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Not blnActualizar Then
                MessageBox.Show("No está autorizado para actualizar el tarifario.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If (CboOrigen_Mnt.SelectedIndex = 0) Then
                MessageBox.Show("Debe de seleccionar el Origen.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CboOrigen_Mnt.Focus()
                Exit Sub
            ElseIf (cboDestino_Mnt.SelectedIndex = 0) Then
                MessageBox.Show("Debe de seleccionar el Destino.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboDestino_Mnt.Focus()
                Exit Sub
            End If

            If (ckbTarifaNormal.Checked) Then
                If (cboProducto_Peso.SelectedIndex = 0) Then
                    MessageBox.Show("Debe de seleccionar el producto.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tpNormal.Select()
                    cboProducto_Peso.Focus()
                    Exit Sub
                ElseIf (cboTipoTarifa_Peso.SelectedIndex = 0) Then
                    MessageBox.Show("Debe de seleccionar el tipo de tarifa", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tpNormal.Select()
                    cboTipoTarifa_Peso.Focus()
                    Exit Sub
                ElseIf (cboVisibilidad_Peso.SelectedIndex = 0) Then
                    MessageBox.Show("Debe de seleccionar el tipo de visibilidad.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tpNormal.Select()
                    cboVisibilidad_Peso.Focus()
                    Exit Sub
                End If

                'si se selecciona tarifa por ciudad
                If Me.cboCiudad.SelectedValue > 0 Then
                    If Me.cboCiudad.SelectedValue <> Me.CboOrigen_Mnt.SelectedValue Then 'si ciudad es diferente a origen
                        MessageBox.Show("En la tarifa por ciudad, el origen y ciudad deben ser iguales", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        tpNormal.Select()
                        Me.cboCiudad.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If (ckbTarifaArticulos.Checked) Then
                If (cboProducto_Articulos.SelectedIndex = 0) Then
                    MessageBox.Show("Debe de seleccionar el producto.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tpArticulos.Select()
                    cboProducto_Articulos.Focus()
                    Exit Sub
                ElseIf (cboTipoTarifa_Articulos.SelectedIndex = 0) Then
                    MessageBox.Show("Debe de seleccionar el tipo de tarifa.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tpArticulos.Select()
                    cboTipoTarifa_Articulos.Focus()
                    Exit Sub
                ElseIf cboTipoEntrega.SelectedIndex = 0 Then
                    MessageBox.Show("Debe de seleccionar el tipo de entrega.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tpArticulos.Select()
                    cboTipoEntrega.Focus()
                    Exit Sub
                End If
                '-->Valida que se aya ingresado el importe de por lomenos un articulo
                Dim correcto As Boolean = False
                For Each row As DataRow In DirectCast(DgvMntTarifaArticulos.DataSource, DataTable).Rows
                    If IsDBNull(row("importe")) = False Then
                        If (row("importe") > 0) Then
                            correcto = True
                            Exit For
                        End If
                    End If
                Next
                If (correcto = False) Then
                    MessageBox.Show("Debe de ingresar el importe de por lo menos un artículo para continuar.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            Me.Cursor = Cursors.WaitCursor

            Dim mensa_Confirmacion As String = ""
            Dim mensa_ConfirmacionProceso As String = ""
            If (action = ACTION_NEW) Then
                mensa_Confirmacion = "¿Está seguro de crear la nueva tarifa?"
                mensa_ConfirmacionProceso = "Se guardo correctamente."
            Else
                mensa_Confirmacion = "¿Está seguro de actualizar la tarifa?"
                mensa_ConfirmacionProceso = "Se actualizo correctamente."
            End If

            If (MessageBox.Show(mensa_Confirmacion, "Tarifario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                Dim existeTarifaPeso As Boolean = False
                Dim existeTarifaArticulos As String = ""

                Dim dtsTrifa_Peso As New DataSet
                Dim dtsTrifa_Articulo As New DataSet

                If (action = ACTION_NEW) Then
                    '-->Valida si existe tarifa x peso
                    If (ckbTarifaNormal.Checked) Then
                        '-->Consulta la existencia de algun tarifario para la ruta y demas parametros seleccionados
                        dtsTrifa_Peso = ObjTarifaPublica.BuscarTarifarioPublico(CboOrigen_Mnt.SelectedValue, _
                                                                                cboDestino_Mnt.SelectedValue, _
                                                                                cboVisibilidad_Peso.SelectedValue, _
                                                                                cboProducto_Peso.SelectedValue, _
                                                                                cboTipoTarifa_Peso.SelectedValue, 0, _
                                                                                cboCiudad.SelectedValue)
                        If (dtsTrifa_Peso.Tables(0).Rows.Count > 0) Then existeTarifaPeso = True
                    End If


                    '-->Valida si existe tarifa x Articulo
                    If (ckbTarifaArticulos.Checked) Then
                        '-->Consulta la existencia de algun tarifario para la ruta y demas parametros seleccionados
                        dtsTrifa_Articulo = ObjTarifaPublica.BuscarTarifarioPublico(CboOrigen_Mnt.SelectedValue, _
                                                                                cboDestino_Mnt.SelectedValue, -1, _
                                                                                cboProducto_Articulos.SelectedValue, _
                                                                                cboTipoTarifa_Articulos.SelectedValue,
                                                                                cboTipoEntrega.SelectedValue, 0)
                        If (dtsTrifa_Articulo.Tables(1).Rows.Count > 0) Then
                            For Each rowAr As DataRow In dtsTrifa_Articulo.Tables(1).Rows
                                If (existeTarifaArticulos.Length = 0) Then
                                    existeTarifaArticulos = "- " & rowAr("nombre_articulo")
                                Else
                                    existeTarifaArticulos += ";" & Chr(13) & "- " & rowAr("nombre_articulo")
                                End If
                            Next
                        End If
                    End If
                End If

                '-->si existe tarifa por peso muestra una alerta 
                If (existeTarifaPeso) Then
                    If (MessageBox.Show("Existe una tarifa registrada para la ruta" & Chr(13) & _
                       CboOrigen_Mnt.Text & "-" & cboDestino_Mnt.Text & ", " & Chr(13) & "con el mismo producto y tipo de tarifa." & Chr(13) & _
                       "¿Desea reemplazarla?", "Tarifa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) _
                   = Windows.Forms.DialogResult.Yes) Then
                    Else
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If

                '-->si existe tarifa por Articulos muestra una alerta con los articulos y importes del mismo
                If (existeTarifaArticulos.Length > 0) Then
                    If (MessageBox.Show("Existe(n) tarifa(s) registrada(s) para la ruta" & Chr(13) & CboOrigen_Mnt.Text & "-" & cboDestino_Mnt.Text _
                                        & Chr(13) & " " & Chr(13) & _
                                        existeTarifaArticulos & Chr(13) & Chr(13) &
                       "¿Desea reemplazarlos?", "Tarifa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) _
                   = Windows.Forms.DialogResult.Yes) Then
                    Else
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If

                Dim tarifaCargo As New Cls_TarifaCargo
                Dim tarifaPublica As New Cls_TarifaPublica_EN

                If (action = ACTION_UPDATE) Then
                    If (ckbTarifaNormal.Checked) Then '-->Tarifa normal
                        '-->Para el caso de la una actualizacion
                        Dim row As DataRow
                        row = DirectCast(DgvTarifasPeso.DataSource, DataTable).Rows(DgvTarifasPeso.CurrentRow.Index)
                        tarifaPublica.idTarifaPublica = row("idTarifa_Publica")
                        tarifaCargo.idTarifaCargo = row("idTarifa_Cargo")

                        tarifaCargo.tarifaPublica = tarifaPublica

                        'If (row("Peso") = txtPeso.Text.Trim And row("volumen") = txtVolumen.Text.Trim _
                        '        And row("base") = txtBase.Text.Trim And row("n_Sobre") = txtSobre.Text.Trim) Then
                        '    MessageBox.Show(mensa_ConfirmacionProceso, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '    tcTarifas.SelectedIndex = 1
                        '    Me.Cursor = Cursors.Default
                        '    Exit Sub
                        'End If
                    End If
                Else '-->Cuando es nuevo
                    If (ckbTarifaNormal.Checked) Then '-->Tarifa normal
                        If (dtsTrifa_Peso.Tables(0).Rows.Count > 0) Then '-->Si la tarifa x peso existe envia los ids, para anular dicha tarifa
                            Dim rowTa As DataRow
                            rowTa = dtsTrifa_Peso.Tables(0).Rows(0)
                            tarifaPublica.idTipoTarifa = rowTa("idTarifa_Publica")
                            tarifaCargo.idTarifaCargo = rowTa("idTarifa_Cargo")

                            tarifaCargo.tarifaPublica = tarifaPublica
                        End If
                    End If
                End If

                tarifaPublica.UnidadOrigen = CboOrigen_Mnt.SelectedValue
                tarifaPublica.UnidadDestino = cboDestino_Mnt.SelectedValue

                If (ckbTarifaNormal.Checked) Then '-->Guarda tarifa normal
                    '-->Setea tarifa_Cliente
                    tarifaCargo.idTipoTarifa = cboTipoTarifa_Peso.SelectedValue()
                    tarifaCargo.idProcesos = cboProducto_Peso.SelectedValue
                    tarifaCargo.Base = IIf(txtBase.Text.Trim = "", 0.0, txtBase.Text.Trim)
                    tarifaCargo.Peso = IIf(txtPeso.Text.Trim = "", 0.0, txtPeso.Text.Trim)
                    tarifaCargo.Volumen = IIf(txtVolumen.Text.Trim = "", 0.0, txtVolumen.Text.Trim)
                    tarifaCargo.Sobre = IIf(txtSobre.Text.Trim = "", 0.0, txtSobre.Text.Trim)
                    tarifaCargo.FleteMinimoPeso = IIf(txtFleteMinimoPeso.Text.Trim = "", 0.0, txtFleteMinimoPeso.Text.Trim)
                    tarifaCargo.PesoMinimo = IIf(txtPesoMinimo.Text.Trim = "", 0.0, txtPesoMinimo.Text.Trim)
                    tarifaCargo.FleteMinimoVol = IIf(txtFleteMinimoVolumen.Text.Trim = "", 0.0, txtFleteMinimoVolumen.Text.Trim)
                    tarifaCargo.VolumenMinimo = IIf(txtVolumenMinimo.Text.Trim = "", 0.0, txtVolumenMinimo.Text.Trim)
                    tarifaCargo.tipoVisibilidad = cboVisibilidad_Peso.SelectedValue
                    tarifaCargo.idUsuario = dtoUSUARIOS.IdLogin
                    tarifaCargo.ip = dtoUSUARIOS.IP
                    tarifaCargo.fechaActivacion = dtoUSUARIOS.m_sFecha ' Now.Date
                    tarifaCargo.tarifaPublica = tarifaPublica
                    tarifaCargo.Ciudad = Me.cboCiudad.SelectedValue
                    ObjTarifaPublica.F_InsTarifarioPublico_LN(tarifaCargo)

                    CboBusq_Producto.SelectedValue = cboProducto_Peso.SelectedValue
                    cboBusq_TipoTarifa.SelectedValue = cboTipoTarifa_Peso.SelectedValue
                    CboBusq_TipoVisibildad.SelectedValue = cboVisibilidad_Peso.SelectedValue
                End If


                If (ckbTarifaArticulos.Checked) Then
                    tarifaCargo.idTipoTarifa = 0
                    If (action = ACTION_NEW) Then
                        '-->Verifa tarifas x articulos existentes, para anularlas antes de realizar el nuevo insert
                        For Each rowArt As DataRow In dtsTrifa_Articulo.Tables(1).Rows
                            Dim tarifaArticulo As New Cls_TarifaArticulo

                            tarifaArticulo.idTarifaArticulo = rowArt("idTarifa_articulo")
                            tarifaPublica.idTarifaPublica = rowArt("idtarifa_Publica")
                            tarifaArticulo.ip = dtoUSUARIOS.IP
                            tarifaArticulo.idUsuario = dtoUSUARIOS.IdLogin
                            tarifaArticulo.importe = 0.0
                            tarifaArticulo.tarifaPublica = tarifaPublica

                            ObjTarifaPublica.F_InsTarifaArticulo_AD(tarifaArticulo) '-->Realiza la anulacion la tarifa x articulo
                        Next
                    Else
                        '-->Verifica
                        For Each rowArt As DataRow In DirectCast(DgvMntTarifaArticulos.DataSource, DataTable).Rows
                            If (rowArt("idTarifa_articulo") > 0) Then
                                Dim tarifaArticulo As New Cls_TarifaArticulo

                                tarifaArticulo.importe = 0
                                tarifaArticulo.idTarifaArticulo = rowArt("idTarifa_articulo")
                                tarifaPublica.idTarifaPublica = rowArt("idtarifa_Publica")
                                tarifaArticulo.ip = dtoUSUARIOS.IP
                                tarifaArticulo.idUsuario = dtoUSUARIOS.IdLogin
                                tarifaArticulo.tarifaPublica = tarifaPublica
                                ObjTarifaPublica.F_InsTarifaArticulo_AD(tarifaArticulo) '-->Realiza la anulacion la tarifa x articulo
                            End If
                        Next
                    End If

                    For Each rowArt As DataRow In DirectCast(DgvMntTarifaArticulos.DataSource, DataTable).Rows
                        If IsDBNull(rowArt("importe")) = False Then
                            If (rowArt("importe") > 0) Then
                                Dim tarifaArticulo As New Cls_TarifaArticulo
                                tarifaArticulo.idArticulo = rowArt("idArticulos")
                                tarifaArticulo.importe = rowArt("importe")

                                tarifaArticulo.idProcesos = cboProducto_Articulos.SelectedValue
                                tarifaArticulo.fechaActivacion = dtpFechaActivacion_Articulos.Text
                                tarifaArticulo.tarifaPublica = tarifaPublica
                                tarifaArticulo.ip = dtoUSUARIOS.IP
                                tarifaArticulo.idUsuario = dtoUSUARIOS.IdLogin
                                tarifaArticulo.idTipoTarifa = cboTipoTarifa_Articulos.SelectedValue
                                tarifaArticulo.TipoEntrega = cboTipoEntrega.SelectedValue
                                tarifaArticulo.fechaActivacion = dtoUSUARIOS.m_sFecha
                                ObjTarifaPublica.F_InsTarifaArticulo_AD(tarifaArticulo) '-->inserta la tarifa x articulo
                            End If
                        End If
                    Next

                    CboBusq_Producto.SelectedValue = cboProducto_Articulos.SelectedValue
                    cboBusq_TipoTarifa.SelectedValue = cboTipoTarifa_Articulos.SelectedValue
                    CboBusq_TipoVisibildad.SelectedValue = 0
                End If


                MessageBox.Show(mensa_ConfirmacionProceso, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboBusq_Origen.SelectedValue = CboOrigen_Mnt.SelectedValue
                cboBusq_Destino.SelectedValue = cboDestino_Mnt.SelectedValue
            Else
                Exit Sub
            End If

            btnConsultar_Click(1, Nothing)
            tcTarifario.SelectedIndex = 0

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DgvMntTarifaArticulos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMntTarifaArticulos.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case Is = DgvMntTarifaArticulos.CurrentRow.Cells("importe").ColumnIndex
                    If IsDBNull(DgvMntTarifaArticulos.CurrentRow.Cells("importe").Value) Then
                        DgvMntTarifaArticulos.CurrentRow.Cells("Importe").Value = 0.0
                    ElseIf (DgvMntTarifaArticulos.CurrentRow.Cells("importe").Value = "") Then
                        DgvMntTarifaArticulos.CurrentRow.Cells("Importe").Value = 0.0
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DgvMntTarifaArticulos_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgvMntTarifaArticulos.EditingControlShowing
        celda = TryCast(e.Control, DataGridViewTextBoxEditingControl)
    End Sub
    Private Sub celda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles celda.KeyPress
        e.Handled = Me.Numero(e, celda)
    End Sub
    Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef Celda As TextBox) As Boolean
        Try
            If UCase(e.KeyChar) Like "[!0-9.]" Then
                If Not Asc(e.KeyChar) = Keys.Back Then
                    Return True
                End If
            End If

            Dim c As Short = 0
            If UCase(e.KeyChar) Like "[.]" Then
                If InStr(Celda.Text, ".") > 0 Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Private Sub txtPeso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeso.LostFocus
        If (txtPeso.Text = "") Then txtPeso.Text = 0.0

        Dim monto As Double = txtPeso.Text
        txtPeso.Text = Format(monto, "#,###.#0")
    End Sub
    Private Sub txtVolumen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVolumen.LostFocus
        If (txtVolumen.Text = "") Then txtVolumen.Text = 0.0

        Dim monto As Double = txtVolumen.Text
        txtVolumen.Text = Format(monto, "#,###.#0")
    End Sub
    Private Sub txtSobre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSobre.LostFocus
        If (txtSobre.Text = "") Then txtSobre.Text = 0.0

        Dim monto As Double = txtSobre.Text
        txtSobre.Text = Format(monto, "#,###.#0")
    End Sub
    Private Sub txtBase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBase.LostFocus
        If (txtBase.Text = "") Then txtBase.Text = 0.0

        Dim monto As Double = txtBase.Text
        txtBase.Text = Format(monto, "#,###.#0")
    End Sub
    Private Sub txtPesoMinimo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPesoMinimo.LostFocus
        If (txtPesoMinimo.Text = "") Then txtPesoMinimo.Text = 0.0

        Dim monto As Double = txtPesoMinimo.Text
        txtPesoMinimo.Text = Format(monto, "#,###.#0")
    End Sub
    Private Sub txtFleteMinimoPeso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFleteMinimoPeso.LostFocus
        If (txtFleteMinimoPeso.Text = "") Then txtFleteMinimoPeso.Text = 0.0

        Dim monto As Double = txtFleteMinimoPeso.Text
        txtFleteMinimoPeso.Text = Format(monto, "#,###.#0")
    End Sub
    Private Sub txtVolumenMinimo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVolumenMinimo.LostFocus
        If (txtVolumenMinimo.Text = "") Then txtVolumenMinimo.Text = 0.0

        Dim monto As Double = txtVolumenMinimo.Text
        txtVolumenMinimo.Text = Format(monto, "#,###.#0")
    End Sub
    Private Sub txtFleteMinimoVolumen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFleteMinimoVolumen.KeyPress
        If (Char.IsDigit(e.KeyChar)) Then
            e.Handled = False
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        ElseIf (e.KeyChar = ".") Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtFleteMinimoVolumen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFleteMinimoVolumen.LostFocus
        If (txtFleteMinimoVolumen.Text = "") Then txtFleteMinimoVolumen.Text = 0.0

        Dim monto As Double = txtFleteMinimoVolumen.Text
        txtFleteMinimoVolumen.Text = Format(monto, "#,###.#0")
    End Sub
    Private Sub tspAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tspAnular.Click
        Try
            
            If (tcListaTarifas.SelectedIndex = 0) Then
                If IsNothing(DgvTarifasPeso.DataSource) = False And DgvTarifasPeso.Rows.Count > 0 Then
                    Dim ruta As String
                    ruta = DgvTarifasPeso.CurrentRow.Cells("Origen").Value & " - " & DgvTarifasPeso.CurrentRow.Cells("Destino").Value

                    If (MessageBox.Show("Esta seguro de realizar la anulación de la tarifa " & Chr(13) & ruta, "Tarifa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                        Dim idTarifa_Publica As Long = DgvTarifasPeso.CurrentRow.Cells("idTarifa_Cargo").Value
                        ObjTarifaPublica.Anular_Tarifa_AD(idTarifa_Publica, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                        btnConsultar_Click(1, Nothing)
                    End If
                End If

            ElseIf (tcListaTarifas.SelectedIndex = 1) Then '-->Anula tarifa por articulos
                If IsNothing(DgvTarifaArticulos.DataSource) = False And DgvTarifaArticulos.Rows.Count > 0 Then
                    Dim ruta As String
                    ruta = DgvTarifaArticulos.CurrentRow.Cells("Origen").Value & " - " & DgvTarifaArticulos.CurrentRow.Cells("Destino").Value

                    If (MessageBox.Show("Esta seguro de realizar la anulación de la tarifa " & Chr(13) & ruta, "Tarifa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                        Dim idTarifa_Articulo As Long = DgvTarifaArticulos.CurrentRow.Cells("idTarifa_Articulo").Value
                        ObjTarifaPublica.Anular_TarifaArticulo_AD(idTarifa_Articulo, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                        btnConsultar_Click(1, Nothing)
                    End If
                End If
               
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cboBusq_Origen_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBusq_Origen.KeyUp
        If (e.KeyCode = Keys.Enter) Then
            cboBusq_Destino.Focus()
            cboBusq_Destino.SelectAll()
        End If
    End Sub
    Private Sub CboOrigen_Mnt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboOrigen_Mnt.KeyUp
        If (e.KeyCode = Keys.Enter) Then cboDestino_Mnt.Focus()
    End Sub

    Private Sub txtPeso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPeso.TextChanged

    End Sub

    Private Sub txtBase_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBase.TextChanged

    End Sub

    Private Sub cboProducto_Peso_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProducto_Peso.SelectedIndexChanged
        If IsReference(Me.cboProducto_Peso.SelectedValue) Then Return
        If Me.cboProducto_Peso.SelectedValue = 10 Then
            Me.txtPeso.Enabled = False
            Me.txtVolumen.Enabled = False
            Me.txtSobre.Enabled = True
            Me.txtBase.Enabled = False
            Me.txtPesoMinimo.Enabled = False
            Me.txtFleteMinimoPeso.Enabled = False
            Me.txtVolumenMinimo.Enabled = False
            Me.txtFleteMinimoVolumen.Enabled = False
        Else
            Me.txtPeso.Enabled = True
            Me.txtVolumen.Enabled = True
            If Me.cboProducto_Peso.SelectedValue = 0 Then
                Me.txtSobre.Enabled = False
            Else
                Me.txtSobre.Enabled = True
            End If
            Me.txtBase.Enabled = True
            Me.txtPesoMinimo.Enabled = True
            Me.txtFleteMinimoPeso.Enabled = True
            Me.txtVolumenMinimo.Enabled = True
            Me.txtFleteMinimoVolumen.Enabled = True
        End If
    End Sub

    Private Sub DgvTarifaArticulos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTarifaArticulos.CellContentClick

    End Sub
End Class