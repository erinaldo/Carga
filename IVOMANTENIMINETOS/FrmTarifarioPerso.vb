Imports INTEGRACION_LN
Imports INTEGRACION_EN
Imports System.Windows.Forms
Public Class FrmTarifarioPerso
    Dim blnActualizar As Boolean
    Public hnd As Long
    Private objTarifarioPerso_LN As Cls_TarifaPublica_LN
    Private lobj_Frm_BuscarClientes As Frm_BuscarCliente
    Private objTarifaCliente As New Cls_TarifarioPerso_LN
    Private lcls_Utilitarios As Cls_Utilitarios
    Private lObj_ClsBuscarClienteLN As Cls_BuscarClienteLN
    ' Private objTarifaSubCuenta As Cls_TarifaSubCuentaLN
    Dim lclsUtilitarios As New Cls_Utilitarios

    Private WithEvents celda As DataGridViewTextBoxEditingControl
    Dim dtArticulos As New DataTable '-->Guarda el maestro de articulos (esto se carga al momento de cargar en el Load)
    Dim utilData As New UtilData_LN
    Dim action As Integer
    Dim ACTION_NEW As Integer = 0
    Dim ACTION_UPDATE As Integer = 1
    Dim bIngreso As Boolean
#Region "CONFIG DGV"
    Private Sub dgConfigDGVClientes()
        With DgvClientes
            Dim Col_idPersona As New DataGridViewTextBoxColumn
            With Col_idPersona
                .Name = "idpersona" : .DataPropertyName = "idpersona"
                .DisplayIndex = 1 : .Visible = False
            End With
            Dim Col_Ruc As New DataGridViewTextBoxColumn
            With Col_Ruc
                .HeaderText = "NÚMERO RUC"
                .DisplayIndex = 2 : .Width = 80
                .DefaultCellStyle.Font = New Font("tahoma", 8, FontStyle.Regular)
                .Name = "Ruc" : .DataPropertyName = "Ruc"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            Dim Col_RazonSocial As New DataGridViewTextBoxColumn
            With Col_RazonSocial
                .HeaderText = "RAZÓN SOCIAL"
                .DisplayIndex = 3 : .Width = 400
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            Dim Col_telefono As New DataGridViewTextBoxColumn
            With Col_telefono
                .HeaderText = "TELÉFONO" : .Name = "telefono" : .DataPropertyName = "telefono"
                .DisplayIndex = 4 : .Width = 60
                .DefaultCellStyle.Font = New Font("tahoma", 8, FontStyle.Regular)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            'hlamas 21-01-2016
            Dim Col_corporativo As New DataGridViewTextBoxColumn
            With Col_corporativo
                .Name = "corporativo" : .DataPropertyName = "corporativo" : .HeaderText = "Corporativo"
                .DisplayIndex = 5 : .Visible = False
            End With
            .Columns.AddRange(Col_idPersona, Col_Ruc, Col_RazonSocial, Col_telefono, Col_corporativo)
        End With
    End Sub
    Private Sub dgConfigDGVTarifaCliente()
        Dim x As Integer = 0
        With DgvListTarifasPeso
            Dim Col_idTarifaClienteCargo As New DataGridViewTextBoxColumn
            With Col_idTarifaClienteCargo
                .Name = "idtarifa_cliente_cargo" : .DataPropertyName = "idtarifa_cliente_cargo"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_idTarifaCliente As New DataGridViewTextBoxColumn
            With Col_idTarifaCliente
                .Name = "idtarifa_cliente" : .DataPropertyName = "idtarifa_cliente"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_idPersona As New DataGridViewTextBoxColumn
            With Col_idPersona
                .Name = "idpersona" : .DataPropertyName = "idpersona"
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
            Dim Col_idSubCuenta As New DataGridViewTextBoxColumn
            With Col_idSubCuenta
                .Name = "idSubCuenta" : .DataPropertyName = "idSubCuenta"
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
                .HeaderText = "PRECIO SOBRE" : .Name = "sobre" : .DataPropertyName = "N_sobre"
                .DisplayIndex = x : .Width = 50
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim Col_peso_minimo As New DataGridViewTextBoxColumn
            With Col_peso_minimo
                .HeaderText = "PESO MINIMO" : .Name = "peso_minimo" : .DataPropertyName = "peso_minimo"
                .DisplayIndex = x : .Width = 50
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim Col_peso_minimo_flete As New DataGridViewTextBoxColumn
            With Col_peso_minimo_flete
                .HeaderText = "FLETE PESO MINIMO" : .Name = "peso_minimo_flete" : .DataPropertyName = "peso_minimo_flete"
                .DisplayIndex = x : .Width = 50
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim Col_volumen_minimo As New DataGridViewTextBoxColumn
            With Col_volumen_minimo
                .HeaderText = "VOLUMEN MINIMO" : .Name = "volumen_minimo" : .DataPropertyName = "volumen_minimo"
                .DisplayIndex = x : .Width = 50
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim Col_volumen_minimo_flete As New DataGridViewTextBoxColumn
            With Col_volumen_minimo_flete
                .HeaderText = "FLETE VOLUMEN MINIMO" : .Name = "volumen_minimo_flete" : .DataPropertyName = "volumen_minimo_flete"
                .DisplayIndex = x : .Width = 50
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_SubCuenta As New DataGridViewTextBoxColumn
            With col_SubCuenta
                .HeaderText = "SUB-CUENTA" : .Name = "SubCuenta" : .DataPropertyName = "SubCuenta"
                .DisplayIndex = x : .Width = 100
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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
                .HeaderText = "TIPO TARIFA" : .Name = "tipoTarifa" : .DataPropertyName = "tipoTarifa"
                .DisplayIndex = x : .Width = 70
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
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
            Dim Col_UsuarioRegistro As New DataGridViewTextBoxColumn
            With Col_UsuarioRegistro
                .HeaderText = "USUARIO REGISTRO" : .Name = "nombre_personal" : .DataPropertyName = "nombre_personal"
                .DisplayIndex = x : .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(Col_idTarifaClienteCargo, Col_idTarifaCliente, Col_idPersona, Col_idOrigen, Col_idDestino, Col_idSubCuenta, _
                              Col_Origen, Col_Destino, Col_Base, Col_Peso, Col_Volumen, Col_Sobre, _
                              Col_peso_minimo, Col_peso_minimo_flete, Col_volumen_minimo, Col_volumen_minimo_flete, _
                              col_SubCuenta, col_Producto, col_TipoTarifa, Col_FechaActivacion, Col_UsuarioRegistro)
        End With
    End Sub
    Private Sub dgConfigDGVMntTarifasArticulos()
        Dim x As Integer = 0
        With DgvMntTarifaArticulos
            Dim Col_idTarifaClienteArticulo As New DataGridViewTextBoxColumn
            With Col_idTarifaClienteArticulo
                .Name = "idtarifa_cliente_articulo" : .DataPropertyName = "idtarifa_cliente_articulo"
                .DisplayIndex = x : .Visible = False : .ReadOnly = True
            End With
            x += +1
            Dim Col_idTarifaCliente As New DataGridViewTextBoxColumn
            With Col_idTarifaCliente
                .Name = "idtarifa_cliente" : .DataPropertyName = "idtarifa_cliente"
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
            x += +1
            Dim Col_minimo As New DataGridViewTextBoxColumn
            With Col_minimo
                .HeaderText = "BASE ENVIOS MENOR O IGUAL A" : .Name = "minimo" : .DataPropertyName = "minimo"
                .DisplayIndex = x : .Width = 100
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
            End With
            .Columns.AddRange(Col_idTarifaClienteArticulo, Col_idTarifaCliente, Col_idArticulo, Col_Nombre_Articulo, Col_Importe, Col_minimo)
        End With
    End Sub
    Private Sub dgConfigDGVTarifasArticulos()
        Dim x As Integer = 0
        With DgvListTarifasArticulos
            Dim Col_idTarifaClienteArticulo As New DataGridViewTextBoxColumn
            With Col_idTarifaClienteArticulo
                .Name = "idtarifa_cliente_articulo" : .DataPropertyName = "idtarifa_cliente_articulo"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_idTarifaCliente As New DataGridViewTextBoxColumn
            With Col_idTarifaCliente
                .Name = "idtarifa_cliente" : .DataPropertyName = "idtarifa_cliente"
                .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim Col_idPersona As New DataGridViewTextBoxColumn
            With Col_idPersona
                .Name = "idpersona" : .DataPropertyName = "idpersona"
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
            Dim Col_idSubCuenta As New DataGridViewTextBoxColumn
            With Col_idSubCuenta
                .Name = "idSubCuenta" : .DataPropertyName = "idSubCuenta"
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
            Dim Col_SubCuenta As New DataGridViewTextBoxColumn
            With Col_SubCuenta
                .HeaderText = "SUB-CUENTA" : .Name = "SubCuenta" : .DataPropertyName = "SubCuenta"
                .DisplayIndex = x : .Width = 140
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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
            x += +1
            Dim Col_minimo As New DataGridViewTextBoxColumn
            With Col_minimo
                .HeaderText = "BASE ENVIOS MENOR O IGUAL A" : .Name = "minimo" : .DataPropertyName = "minimo"
                .DisplayIndex = x : .Width = 70
                .DefaultCellStyle.Font = New Font("tahoma", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.Format = "#,###.#0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
            End With
            .Columns.AddRange(Col_idTarifaClienteArticulo, Col_idTarifaCliente, Col_idPersona, Col_idProceso, Col_idArticulo, Col_idOrigen, Col_idDestino, Col_idSubCuenta, Col_Origen, _
                              Col_Destino, Col_Nombre_Articulo, Col_Importe, Col_SubCuenta, Col_FechaActivacion, Col_UsuarioRegistro, Col_minimo)
        End With
    End Sub
#End Region
#Region "FUNCIONES"
    ''' <summary>
    ''' Carga tarifas personalisadas de un Cliente
    ''' </summary>
    ''' <param name="dataSet">Registro a cargar en el Grid</param>
    Sub cargarDataGridTarifas(ByVal dataSet As DataSet)
        '-->Carga tarifas por peso
        DgvListTarifasPeso.Columns.Clear()
        lclsUtilitarios.FormatDataGridView(DgvListTarifasPeso)
        dgConfigDGVTarifaCliente()
        DgvListTarifasPeso.RowHeadersWidth = 20
        DgvListTarifasPeso.DataSource = dataSet.Tables(0)
        DgvListTarifasPeso.ReadOnly = True

        '-->Carga tarifas por Articulo
        DgvListTarifasArticulos.Columns.Clear()
        lclsUtilitarios.FormatDataGridView(DgvListTarifasArticulos)
        dgConfigDGVTarifasArticulos()
        DgvListTarifasArticulos.DataSource = dataSet.Tables(1)
        DgvListTarifasArticulos.ReadOnly = True

        If DirectCast(DgvListTarifasPeso.DataSource, DataTable).Rows.Count = 0 And _
            DirectCast(DgvListTarifasArticulos.DataSource, DataTable).Rows.Count = 0 Then
            MsgBox("No se Encontraron Registros", MsgBoxStyle.Information, "Aviso")
            lblCantRegXPeso.Text = "0"
        Else
            txtCliente_Cliente.Text = DirectCast(DgvClientes.DataSource, DataTable).Rows(0).Item("cliente")

            If (DirectCast(DgvListTarifasPeso.DataSource, DataTable).Rows.Count > 0) Then
                tcListaTarifas.SelectedIndex = 0
            ElseIf (DirectCast(DgvListTarifasArticulos.DataSource, DataTable).Rows.Count > 0) Then
                tcListaTarifas.SelectedIndex = 1
            End If

            lblCantRegXArticulos.Text = DirectCast(DgvListTarifasArticulos.DataSource, DataTable).Rows.Count
            lblCantRegXPeso.Text = DirectCast(DgvListTarifasPeso.DataSource, DataTable).Rows.Count
        End If

        TabCliente.Parent = Me.tcTarifas
        tcTarifas.SelectedIndex = 1
    End Sub
    Sub enabledControlsListTarifas(ByVal estado As Boolean)
        cboSubCuenta_Cliente.Enabled = estado
        cboOrigen_Cliente.Enabled = estado
        cboDestino_Cliente.Enabled = estado
        'ckbSubCuenta_Articulos.Enabled = estado
        NuevoToolStripMenuItem.Enabled = estado
        btnBuscarTarifas.Enabled = estado
        'ckbArticulos.Enabled = estado
        lblCantRegXArticulos.Text = 0.0
    End Sub
    Sub enabledControlsMnt(ByVal estado As Boolean)
        cboOrigen_Mnt.Enabled = estado
        cboDestino_Mnt.Enabled = estado
        cboProducto_peso.Enabled = estado
        cboProducto_Articulos.Enabled = estado
        cboTipoTarifa.Enabled = estado
        TxtBase.Enabled = estado
        TxtPeso.Enabled = estado
        TxtVolumen.Enabled = estado
        TxtSobre.Enabled = estado

        txtPesoMinimo.Enabled = estado
        txtFleteMinimoPeso.Enabled = estado
        txtVolumenMinimo.Enabled = estado
        txtFleteMinimoVolumen.Enabled = estado

        dtpFechaActivacion_Peso.Enabled = estado
        dtpFechaActivacion_Articulos.Enabled = estado
        'Me.txtBaseArticulo.Enabled = estado

        cboSubCuenta_Articulos.Enabled = estado
        cboSubCuenta_Peso.Enabled = estado
        ckbTarifaNormal.Enabled = estado
        ckbTarifaArticulos.Enabled = estado
        btnGuardar.Enabled = estado
    End Sub
    Sub clearMntTarifas()
        TxtCodigo.Clear()
        txtCliente.Clear()
        TxtBase.Text = 0.0
        TxtPeso.Text = 0.0
        TxtVolumen.Text = 0.0
        TxtSobre.Text = 0.0

        txtPesoMinimo.Text = 0.0
        txtFleteMinimoPeso.Text = 0.0
        txtVolumenMinimo.Text = 0.0
        txtFleteMinimoVolumen.Text = 0.0

        cboOrigen_Mnt.SelectedIndex = 0
        cboDestino_Mnt.SelectedIndex = 0
        cboProducto_peso.SelectedIndex = 0
        cboProducto_Articulos.SelectedIndex = 0
        cboTipoTarifa.SelectedIndex = 0
        tcTipo.SelectedIndex = 0
        ckbTarifaArticulos.Checked = False
        ckbTarifaNormal.Checked = False
        cboSubCuenta_Articulos.DataSource = Nothing
        cboSubCuenta_Peso.DataSource = Nothing
        DgvMntTarifaArticulos.DataSource = Nothing
    End Sub
    Sub clearListTarifas()
        txtCliente_Cliente.Clear()
        cboOrigen_Cliente.SelectedIndex = 0
        cboDestino_Cliente.SelectedIndex = 0
        tcListaTarifas.SelectedIndex = 0
        lblCantRegXPeso.Text = 0
        'ckbArticulos.Checked = False
        cboSubCuenta_Cliente.DataSource = Nothing
        DgvListTarifasPeso.DataSource = Nothing
        DgvListTarifasArticulos.DataSource = Nothing
    End Sub
    Function iniColumnsDgvMntTarifasArticulos() As DataTable
        Dim dtTarifaArticulos As New DataTable
        dtTarifaArticulos.Columns.Add("idtarifa_cliente_articulo").DataType = GetType(Integer)
        dtTarifaArticulos.Columns.Add("idtarifa_cliente").DataType = GetType(Integer)
        dtTarifaArticulos.Columns.Add("idArticulos").DataType = GetType(Integer)
        dtTarifaArticulos.Columns.Add("Nombre_Articulo").DataType = GetType(String)
        dtTarifaArticulos.Columns.Add("importe").DataType = GetType(Double)
        dtTarifaArticulos.Columns.Add("minimo").DataType = GetType(Double)

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
                                 importe, 0.0)
        Next

        '-->Cuando es una edición
        If (action = ACTION_UPDATE And IsNothing(dtTarifaXArticulo) = False) Then
            For Each rowAC As DataRow In dtTarifaXArticulo '-->Articulos recuperados del cliente
                For Each rowAr As DataRow In dtArticulo.Rows '-->Articulos cargados en al paso anterior
                    '-->Compara los articulos del cliente con los del maestro cargado anteriormente
                    If (rowAC("idArticulos") = rowAr("idArticulos")) Then
                        rowAr("idtarifa_cliente_articulo") = rowAC("idtarifa_cliente_articulo")
                        rowAr("idtarifa_cliente") = rowAC("idtarifa_cliente")
                        rowAr("importe") = rowAC("importe")
                        rowAr("minimo") = rowAC("minimo")
                        Exit For
                    End If
                Next
            Next
        End If

        '-->Caga el DgvMntArticulos
        DgvMntTarifaArticulos.Columns.Clear()
        lclsUtilitarios.FormatDataGridView(DgvMntTarifaArticulos)
        dgConfigDGVMntTarifasArticulos()
        DgvMntTarifaArticulos.DataSource = dtArticulo
        '-->
        DgvMntTarifaArticulos.Columns("Importe").ReadOnly = False
        DgvMntTarifaArticulos.Columns("Nombre_Articulo").ReadOnly = True
        DgvMntTarifaArticulos.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
    End Sub
#End Region
#Region "CONSTANTES"
    ReadOnly ID_SUBCUENTA_GENERRICO As Integer = 999
    ReadOnly ID_PRODUCTO_CARGAEXPRESSA As Integer = 5
    ReadOnly SOLO_PRODUCTOS_CREDITO As Integer = 1
    ReadOnly SOLO_PRODUCTOS_CONTADO As Integer = 2
#End Region

    Private Sub FrmTarifarioPerso_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub
    Private Sub FrmTarifarioPerso_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmTarifarioPerso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            blnActualizar = Acceso.SiRol(G_Rol, Me, 1)

            objTarifarioPerso_LN = New Cls_TarifaPublica_LN 'refereanciamos la clase a mostrar

            utilData.cargarCombos("t_unidadAgencia", cboOrigen_Cliente, True)
            '-->Pasa solamente el DataSouce del Combo Origen para cargar los demas combos y evitar el acceso al Sever
            'ya que se trata de la carga de los mismos datos de la misma tabla t_unidad_Agencia
            utilData.cargarCombos(, cboDestino_Cliente, True, cboOrigen_Cliente.DataSource)
            utilData.cargarCombos(, cboOrigen_Mnt, False, cboOrigen_Cliente.DataSource)
            utilData.cargarCombos(, cboDestino_Mnt, False, cboOrigen_Cliente.DataSource)
            utilData.cargarCombos("t_procesos", cboProducto_peso, False, , SOLO_PRODUCTOS_CREDITO)
            utilData.cargarCombos(, cboProducto_Articulos, False, cboProducto_peso.DataSource, SOLO_PRODUCTOS_CREDITO)
            utilData.cargarCombos("t_tipotarifa", cboTipoTarifa, False)

            Inicializar()

            '-->Carga maestro de articulos
            'dtArticulos = objTarifaCliente.buscarArticulos()
            dtArticulos = utilData.buscarArticulos()

            enabledControlsListTarifas(False)
            enabledControlsMnt(False)

            txtCliente_Buscar.Focus()

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True

            'EditarToolStripMenuItem.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Inicializar()

        TxtBase.Text = 0.0
        TxtPeso.Text = 0.0
        TxtVolumen.Text = 0.0
        TxtSobre.Text = 0.0

    End Sub
    Private Sub SalirToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarTarifas.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim idOrigen As Integer = cboOrigen_Cliente.SelectedValue
            Dim idDestino As Integer = cboDestino_Cliente.SelectedValue
            Dim idCentroCosto As Integer = cboSubCuenta_Cliente.SelectedValue
            Dim idPersona As Integer = 0
            If (DirectCast(DgvClientes.DataSource, DataTable).Rows.Count > 0) Then
                idPersona = DgvClientes.CurrentRow.Cells("idPersona").Value
                cargarDataGridTarifas(objTarifaCliente.BuscarTarifa(idPersona, idOrigen, idDestino, , , idCentroCosto))
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TextCliente_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.Cursor = Cursors.AppStarting
            btnConsultar_Click(sender, e)
        End If
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try

            Me.Label8.Text = 0
            DgvClientes.DataSource = Nothing
            If (txtCliente_Buscar.Text.Length = 0) Then
                MessageBox.Show("Debe de ingresar algún criterio de búsqueda.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            Dim lStr_Busqueda As String
            lObj_ClsBuscarClienteLN = New Cls_BuscarClienteLN

            '-->Limpia y deshabilita 
            clearMntTarifas()
            enabledControlsMnt(False)
            clearListTarifas()
            enabledControlsListTarifas(False)

            txtCliente_Buscar.Text = UCase(txtCliente_Buscar.Text)
            lStr_Busqueda = txtCliente_Buscar.Text.Trim
            lStr_Busqueda = lStr_Busqueda + "%"

            DgvClientes.Columns.Clear()
            lclsUtilitarios.FormatDataGridView(DgvClientes)
            dgConfigDGVClientes()

            Dim intUsuario As Integer = 0
            If Not Acceso.SiRol(G_Rol, Me, 1) Then
                intUsuario = dtoUSUARIOS.IdLogin
            End If

            If (rbRuc.Checked) Then
                If intUsuario = 0 Then
                    DgvClientes.DataSource = lObj_ClsBuscarClienteLN.F_BuscarCliente_LN(, txtCliente_Buscar.Text.Trim)
                Else
                    DgvClientes.DataSource = lObj_ClsBuscarClienteLN.F_BuscarCliente_LN(, txtCliente_Buscar.Text.Trim, intUsuario)
                End If
            Else
                If intUsuario = 0 Then
                    DgvClientes.DataSource = lObj_ClsBuscarClienteLN.F_BuscarCliente_LN(lStr_Busqueda)
                Else
                    DgvClientes.DataSource = lObj_ClsBuscarClienteLN.F_BuscarCliente_LN(lStr_Busqueda, "", intUsuario)
                End If
            End If

            DgvClientes.ReadOnly = True

            If DirectCast(DgvClientes.DataSource, DataTable).Rows.Count > 0 Then
                Label8.Text = DirectCast(DgvClientes.DataSource, DataTable).Rows.Count
            Else
                Me.Label8.Text = 0
                MsgBox("No se encontraron Registros", MsgBoxStyle.Information, "Aviso")
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TxtBuscardor1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente_Buscar.KeyPress
        If (e.KeyChar = Chr(13)) Then
            btnBuscar_Click(1, Nothing)
        End If
    End Sub
    Private Sub DgvClientes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvClientes.DoubleClick
        Try
            If (DgvClientes.Rows.Count <= 0) Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            Dim idPersona As Integer = DgvClientes.CurrentRow.Cells("idPersona").Value

            'hlamas 21-01-2016
            Dim intCorporativo As Integer = Me.DgvClientes.CurrentRow.Cells("corporativo").Value
            utilData.cargarCombos("t_procesos", cboProducto_peso, False, , IIf(intCorporativo = 1, SOLO_PRODUCTOS_CREDITO, SOLO_PRODUCTOS_CONTADO))
            utilData.cargarCombos(, cboProducto_Articulos, False, cboProducto_peso.DataSource, IIf(intCorporativo = 1, SOLO_PRODUCTOS_CREDITO, SOLO_PRODUCTOS_CONTADO))

            '-->Carga SubCuentas del Cliente
            utilData.cargarCombos("t_CentroCosto", cboSubCuenta_Cliente, True, , idPersona)
            cboSubCuenta_Cliente.SelectedValue = ID_SUBCUENTA_GENERRICO

            enabledControlsListTarifas(True)

            cboOrigen_Cliente.SelectedValue = 5100 '-->Por defaul lima
            '-->Carga Tarifas  del Cliente
            cargarDataGridTarifas(objTarifaCliente.BuscarTarifa(idPersona, cboOrigen_Cliente.SelectedValue, , , , cboSubCuenta_Cliente.SelectedValue))

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarToolStripMenuItem.Click
        TabListar.Parent = Me.tcTarifas
        tcTarifas.SelectedIndex = 0
    End Sub
    Sub Inicio()
        cboOrigen_Mnt.Text = "TODOS"
        cboDestino_Mnt.Text = "TODOS"
        'TsbGuardar.Text = "Guardar"
        cboSubCuenta_Articulos.Text = ""

    End Sub
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Inicializar()
            Inicio()
            action = ACTION_NEW
            clearMntTarifas()

            ckbTarifaNormal.Checked = True
            ckbTarifaArticulos.Checked = True

            ''-->Carga subCuenta para el mantenimineto de las tarifas, vasado en el combo SubCuenta_Cliente
            utilData.cargarCombos(, cboSubCuenta_Articulos, True, cboSubCuenta_Cliente.DataSource)
            utilData.cargarCombos(, cboSubCuenta_Peso, True, cboSubCuenta_Cliente.DataSource)

            Dim row As DataRow
            row = DirectCast(DgvClientes.DataSource, DataTable).Rows(DgvClientes.CurrentRow.Index)
            TxtCodigo.Text = row("ruc")
            txtCliente.Text = row("Cliente")
            cboSubCuenta_Articulos.SelectedValue = ID_SUBCUENTA_GENERRICO
            cboSubCuenta_Peso.SelectedValue = ID_SUBCUENTA_GENERRICO
            cboTipoTarifa.SelectedIndex = 0
            cboProducto_peso.SelectedValue = ID_PRODUCTO_CARGAEXPRESSA
            cboProducto_Articulos.SelectedValue = ID_PRODUCTO_CARGAEXPRESSA
            cboOrigen_Mnt.SelectedIndex = 0
            cboDestino_Mnt.SelectedIndex = 0
            dtpFechaActivacion_Peso.Text = dtoUSUARIOS.m_sFecha

            '-->Carga articulos
            cargarDataGridMntTarifasArticulos()

            tcTipo.SelectedIndex = 0

            enabledControlsMnt(True)
            dtpFechaActivacion_Peso.Enabled = False
            dtpFechaActivacion_Articulos.Enabled = False
            'Me.txtBaseArticulo.Enabled = False

            ckbTarifaNormal.Checked = False
            ckbTarifaArticulos.Checked = False

            TabTarifa.Parent = Me.tcTarifas
            tcTarifas.SelectedIndex = 2
            cboOrigen_Mnt.Focus()
            cboOrigen_Mnt.SelectAll()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DgvTarifaCliente_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvListTarifasPeso.DoubleClick
        Try
            If (DgvListTarifasPeso.Rows.Count <= 0) Then
                Exit Sub
            End If

            '-->cuando el botón del menu editar esta desactivado no permite realizar ediciones.
            If (EditarToolStripMenuItem.Enabled = False) Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            action = ACTION_UPDATE

            ckbTarifaArticulos.Enabled = False
            ckbTarifaArticulos.Checked = False
            ckbTarifaNormal.Checked = True

            TabTarifa.Parent = Me.tcTarifas
            '-->Carga subCuenta para el mantenimineto de las tarifas, vasado en el combo SubCuenta_Cliente
            utilData.cargarCombos(, cboSubCuenta_Peso, True, cboSubCuenta_Cliente.DataSource)
            cboSubCuenta_Peso.SelectedIndex = 0

            Dim row As DataRow
            row = DirectCast(DgvListTarifasPeso.DataSource, DataTable).Rows(DgvListTarifasPeso.CurrentRow.Index)

            TxtCodigo.Text = DgvClientes.CurrentRow.Cells("ruc").Value
            txtCliente.Text = txtCliente_Cliente.Text
            cboSubCuenta_Peso.Text = row("subCuenta")
            cboProducto_peso.Text = row("producto")
            cboTipoTarifa.Text = row("tipoTarifa")
            cboOrigen_Mnt.Text = row("origen")
            cboDestino_Mnt.Text = row("destino")
            TxtBase.Text = Format(row("base"), "#,###.#0")
            TxtPeso.Text = Format(row("peso"), "#,###.#0")
            TxtVolumen.Text = Format(row("volumen"), "#,###.#0")
            TxtSobre.Text = Format(row("n_Sobre"), "#,###.#0")

            txtPesoMinimo.Text = Format(row("peso_minimo"), "#,###.#0")
            txtFleteMinimoPeso.Text = Format(row("peso_minimo_flete"), "#,###.#0")
            txtVolumenMinimo.Text = Format(row("volumen_minimo"), "#,###.#0")
            txtFleteMinimoVolumen.Text = Format(row("volumen_minimo_flete"), "#,###.#0")

            dtpFechaActivacion_Peso.Text = row("fecha_Activacion")

            cboSubCuenta_Peso.Enabled = False

            TxtBase.Enabled = True
            TxtPeso.Enabled = True
            TxtVolumen.Enabled = True
            TxtSobre.Enabled = True

            txtPesoMinimo.Enabled = True
            txtFleteMinimoPeso.Enabled = True
            txtVolumenMinimo.Enabled = True
            txtFleteMinimoVolumen.Enabled = True

            btnGuardar.Enabled = True
            tcTarifas.SelectedIndex = 2
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cboOrigen_Cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboOrigen_Cliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub cboDestino_Cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDestino_Cliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub cboOrigen_Mnt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboOrigen_Mnt.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub cboDestino_Mnt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDestino_Mnt.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub tcTarifas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcTarifas.SelectedIndexChanged
        Try
            Select Case tcTarifas.SelectedIndex
                Case Is = 0 '-->Limpia controles del Matenimiento de tarifas
                    enabledControlsMnt(False)
                    clearMntTarifas()
                    enabledControlsListTarifas(False)
                    clearListTarifas()
                Case Is = 1 '-->Limpia controles del Matenimiento de tarifas
                    enabledControlsMnt(False)
                    clearMntTarifas()
                Case Is = 2
                    If Me.cboProducto_peso.SelectedIndex = -1 Then
                        Me.cboProducto_peso.SelectedIndex = 0
                    End If
                    If Me.cboProducto_Articulos.SelectedIndex = -1 Then
                        Me.cboProducto_Articulos.SelectedIndex = 0
                    End If
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TxtPeso_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPeso.GotFocus
        TxtPeso.SelectAll()
    End Sub
    Private Sub TextPeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPeso.KeyPress
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
    Private Sub TxtVolumen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVolumen.GotFocus
        TxtVolumen.SelectAll()
    End Sub
    Private Sub TextVolumen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVolumen.KeyPress
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
    Private Sub TxtSobre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSobre.GotFocus
        TxtSobre.SelectAll()
    End Sub
    Private Sub TextSobre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSobre.KeyPress
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
    Private Sub cboOrigen_Cliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOrigen_Cliente.KeyUp
        If (e.KeyCode = Keys.Enter) Then cboDestino_Cliente.Focus() : cboDestino_Cliente.SelectAll()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Not blnActualizar Then
                MessageBox.Show("No está autorizado para actualizar el tarifario.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If (cboOrigen_Mnt.SelectedIndex = 0) Then
                MessageBox.Show("Debe de seleccionar el Origen.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboOrigen_Mnt.Focus()
                Exit Sub
            ElseIf (cboDestino_Mnt.SelectedIndex = 0) Then
                MessageBox.Show("Debe de seleccionar el Destino.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboDestino_Mnt.Focus()
                Exit Sub
            End If

            If (ckbTarifaNormal.Checked) Then '-->Valida tarifa normal
                If (cboProducto_peso.SelectedIndex = 0) Then
                    MessageBox.Show("Debe de seleccionar el Producto.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tpNormal.Select()
                    cboProducto_peso.Focus()
                    Exit Sub
                ElseIf (cboTipoTarifa.SelectedIndex = 0) Then
                    MessageBox.Show("Debe de seleccionar el tipo de tarifa.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tpNormal.Select()
                    cboTipoTarifa.Focus()
                    Exit Sub
                End If
            End If

            If (ckbTarifaArticulos.Checked) Then '-->Valida tarifas por articulo
                If (cboProducto_Articulos.SelectedIndex = 0) Then
                    MessageBox.Show("Debe de seleccionar el Producto.", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tpArticulo.Select()
                    cboProducto_Articulos.Focus()
                    Exit Sub
                End If

                '-->Valida articulos
                Dim correcto As Boolean = False
                For Each rowArt As DataRow In DirectCast(DgvMntTarifaArticulos.DataSource, DataTable).Rows
                    If IsDBNull(rowArt("importe")) = False Then
                        If (rowArt("importe") > 0) Then
                            correcto = True
                            Exit For
                        End If
                    End If
                Next

                If (correcto = False) Then
                    MessageBox.Show("Debe ingresar el importe de al menos " & Chr(13) & "un articulo para continuar", "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tpArticulo.Select()
                    Exit Sub
                End If

            End If

            Me.Cursor = Cursors.WaitCursor

            Dim mensa_Confirmacion As String = ""
            Dim mensa_ConfirmacionProceso As String = ""
            Dim idPersona As String = DirectCast(DgvClientes.DataSource, DataTable).Rows(DgvClientes.CurrentRow.Index).Item("idPersona")
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
                        dtsTrifa_Peso = objTarifaCliente.BuscarTarifa(idPersona, cboOrigen_Mnt.SelectedValue, cboDestino_Mnt.SelectedValue, _
                                                  cboProducto_peso.SelectedValue, cboTipoTarifa.SelectedValue, cboSubCuenta_Peso.SelectedValue)
                        If (dtsTrifa_Peso.Tables(0).Rows.Count > 0) Then existeTarifaPeso = True
                    End If


                    '-->Valida si existe tarifa x Articulo
                    If (ckbTarifaArticulos.Checked) Then
                        '-->Consulta la existencia de algun tarifario para la ruta y demas parametros seleccionados
                        dtsTrifa_Articulo = objTarifaCliente.BuscarTarifa(idPersona, cboOrigen_Mnt.SelectedValue, cboDestino_Mnt.SelectedValue, _
                                                  cboProducto_Articulos.SelectedValue, 999, cboSubCuenta_Articulos.SelectedValue)
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
                       cboOrigen_Mnt.Text & "-" & cboDestino_Mnt.Text & ", " & Chr(13) & "con el mismo producto y tipo de tarifa." & Chr(13) & _
                       "¿Desea reemplazarla?", "Tarifa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) _
                   = Windows.Forms.DialogResult.Yes) Then
                    Else
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If

                '-->si existe tarifa por Articulos muestra una alerta con los articulos y importes del mismo
                If (existeTarifaArticulos.Length > 0) Then
                    If (MessageBox.Show("Existe(n) tarifa(s) registrada(s) para la ruta" & Chr(13) & cboOrigen_Mnt.Text & "-" & cboDestino_Mnt.Text _
                                        & Chr(13) & " " & Chr(13) & _
                                        existeTarifaArticulos & Chr(13) & Chr(13) &
                       "¿Desea reemplazarlos?", "Tarifa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) _
                   = Windows.Forms.DialogResult.Yes) Then
                    Else
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If


                Dim tarifaCliente As New Cls_TarifaPersona_EN

                If (action = ACTION_UPDATE) Then
                    If (ckbTarifaNormal.Checked) Then '-->Tarifa normal
                        '-->Para el caso de la una actualizacion
                        Dim row As DataRow
                        row = DirectCast(DgvListTarifasPeso.DataSource, DataTable).Rows(DgvListTarifasPeso.CurrentRow.Index)
                        tarifaCliente.idTarifaCliente = row("idtarifa_cliente")
                        tarifaCliente.idTarifaClienteCardo = row("idtarifa_cliente_cargo")

                        If (row("Peso") = TxtPeso.Text.Trim And row("volumen") = TxtVolumen.Text.Trim _
                                And row("base") = TxtBase.Text.Trim And row("n_Sobre") = TxtSobre.Text.Trim _
                                And row("peso_minimo") = txtPesoMinimo.Text.Trim And row("peso_minimo_flete") = txtFleteMinimoPeso.Text.Trim _
                                And row("volumen_minimo") = txtVolumenMinimo.Text.Trim And row("volumen_minimo_flete") = txtFleteMinimoVolumen.Text.Trim) Then
                            MessageBox.Show(mensa_ConfirmacionProceso, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            tcTarifas.SelectedIndex = 1
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End If
                Else '-->Cuando es nuevo
                    If (ckbTarifaNormal.Checked) Then '-->Tarifa normal
                        If (dtsTrifa_Peso.Tables(0).Rows.Count > 0) Then '-->Si la tarifa x peso existe envia los ids, para anular dicha tarifa
                            Dim rowTa As DataRow
                            rowTa = dtsTrifa_Peso.Tables(0).Rows(0)
                            tarifaCliente.idTarifaCliente = rowTa("idtarifa_cliente")
                            tarifaCliente.idTarifaClienteCardo = rowTa("idtarifa_cliente_cargo")
                        End If
                    End If
                End If

                tarifaCliente.Origen = cboOrigen_Mnt.SelectedValue
                tarifaCliente.Destino = cboDestino_Mnt.SelectedValue
                tarifaCliente.idPersona = idPersona
                tarifaCliente.fechaActivacion = Now.Date
                tarifaCliente.iP = dtoUSUARIOS.IP
                tarifaCliente.Usuario = dtoUSUARIOS.IdLogin

                If (ckbTarifaNormal.Checked) Then '-->Guarda tarifa normal
                    '-->Setea tarifa_Cliente
                    tarifaCliente.SubCuenta = cboSubCuenta_Peso.SelectedValue
                    tarifaCliente.TipoTarifa = cboTipoTarifa.SelectedValue
                    tarifaCliente.PROCESO = cboProducto_peso.SelectedValue
                    tarifaCliente.BASE = IIf(TxtBase.Text.Trim = "", 0.0, TxtBase.Text.Trim)
                    tarifaCliente.Peso = IIf(TxtPeso.Text.Trim = "", 0.0, TxtPeso.Text.Trim)
                    tarifaCliente.Volumen = IIf(TxtVolumen.Text.Trim = "", 0.0, TxtVolumen.Text.Trim)
                    tarifaCliente.Sobre = IIf(TxtSobre.Text.Trim = "", 0.0, TxtSobre.Text.Trim)

                    'hlamas 07-05-2015
                    tarifaCliente.PesoMinimo = IIf(txtPesoMinimo.Text.Trim = "", 0.0, txtPesoMinimo.Text.Trim)
                    tarifaCliente.PesoMinimoFlete = IIf(txtFleteMinimoPeso.Text.Trim = "", 0.0, txtFleteMinimoPeso.Text.Trim)
                    tarifaCliente.VolumenMinimo = IIf(txtVolumenMinimo.Text.Trim = "", 0.0, txtVolumenMinimo.Text.Trim)
                    tarifaCliente.VolumenMinimoFlete = IIf(txtFleteMinimoVolumen.Text.Trim = "", 0.0, txtFleteMinimoVolumen.Text.Trim)

                    objTarifaCliente.F_InsTarifario_LN(tarifaCliente)

                    cboSubCuenta_Cliente.SelectedValue = cboSubCuenta_Peso.SelectedValue
                End If

                If (ckbTarifaArticulos.Checked) Then '-->Guarda tarifa x articulos
                    tarifaCliente.idTarifaCliente = 0
                    If (action = ACTION_NEW) Then
                        '-->Verifa tarifas x articulos existentes, para anularlas antes de realizar el nuevo insert
                        For Each rowArt As DataRow In dtsTrifa_Articulo.Tables(1).Rows
                            'If (rowArt("importe") > 0) Then
                            Dim tarifaClienteArticulo As New Cls_TarifaClienteArticulo
                            tarifaClienteArticulo.idTarifaClienteArticulo = rowArt("idtarifa_cliente_articulo")
                            tarifaCliente.idTarifaCliente = rowArt("idtarifa_cliente")
                            tarifaCliente.SubCuenta = cboSubCuenta_Articulos.SelectedValue
                            tarifaClienteArticulo.importe = 0.0
                            tarifaClienteArticulo.minimo = 0
                            tarifaClienteArticulo.tarifaCliente = tarifaCliente
                            objTarifaCliente.F_InsTarifario_Articulo_AD(tarifaClienteArticulo) '-->Realiza la anulacion la tarifa x articulo
                            'End If
                        Next
                    Else
                        '-->Verifica
                        For Each rowArt As DataRow In DirectCast(DgvMntTarifaArticulos.DataSource, DataTable).Rows
                            If (rowArt("idtarifa_cliente_articulo") > 0) Then
                                Dim tarifaClienteArticulo As New Cls_TarifaClienteArticulo
                                tarifaClienteArticulo.importe = 0
                                tarifaClienteArticulo.minimo = 0
                                tarifaClienteArticulo.idTarifaClienteArticulo = rowArt("idtarifa_cliente_articulo")
                                tarifaCliente.idTarifaCliente = rowArt("idtarifa_cliente")

                                tarifaClienteArticulo.tarifaCliente = tarifaCliente
                                objTarifaCliente.F_InsTarifario_Articulo_AD(tarifaClienteArticulo) '-->Realiza la anulacion la tarifa x articulo
                            End If
                        Next
                    End If

                    For Each rowArt As DataRow In DirectCast(DgvMntTarifaArticulos.DataSource, DataTable).Rows
                        If IsDBNull(rowArt("importe")) = False Then
                            If (rowArt("importe") > 0) Then
                                Dim tarifaClienteArticulo As New Cls_TarifaClienteArticulo
                                tarifaClienteArticulo.idArticulo = rowArt("idArticulos")
                                tarifaClienteArticulo.importe = rowArt("importe")
                                If IsDBNull(rowArt("minimo")) Then
                                    tarifaClienteArticulo.minimo = 0
                                Else
                                    tarifaClienteArticulo.minimo = IIf(Val(rowArt("minimo")) = 0, 0, rowArt("minimo"))
                                End If
                                tarifaCliente.PROCESO = cboProducto_Articulos.SelectedValue
                                tarifaCliente.SubCuenta = cboSubCuenta_Articulos.SelectedValue
                                tarifaClienteArticulo.fechaActivacion = dtpFechaActivacion_Articulos.Text
                                tarifaClienteArticulo.tarifaCliente = tarifaCliente

                                objTarifaCliente.F_InsTarifario_Articulo_AD(tarifaClienteArticulo) '-->inserta la tarifa x articulo
                            End If
                        End If
                    Next

                    cboSubCuenta_Cliente.SelectedValue = cboSubCuenta_Articulos.SelectedValue
                End If

                MessageBox.Show(mensa_ConfirmacionProceso, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information)

                cboOrigen_Cliente.SelectedValue = cboOrigen_Mnt.SelectedValue
                cboDestino_Cliente.SelectedValue = cboDestino_Mnt.SelectedValue

                cargarDataGridTarifas(objTarifaCliente.BuscarTarifa(idPersona, tarifaCliente.Origen, tarifaCliente.Destino, _
                                             tarifaCliente.PROCESO, tarifaCliente.TipoTarifa, tarifaCliente.SubCuenta))
                tcTarifas.SelectedIndex = 1
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        tcTarifas.SelectedIndex = 1
    End Sub
    Private Sub cboDestino_Cliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDestino_Cliente.KeyUp
        If (e.KeyCode = Keys.Enter) Then btnBuscarTarifas.Focus()
    End Sub
    Private Sub cboOrigen_Mnt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOrigen_Mnt.KeyUp
        If (e.KeyCode = Keys.Enter) Then cboDestino_Mnt.Focus()
    End Sub
    Private Sub cboDestino_Mnt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDestino_Mnt.KeyUp
        If (e.KeyCode = Keys.Enter) Then TxtPeso.Focus()
    End Sub
    Private Sub TxtBase_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBase.GotFocus
        TxtBase.SelectAll()
    End Sub
    Private Sub TxtBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBase.KeyPress
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
    Private Sub ckbTarifaNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbTarifaNormal.CheckedChanged
        Try
            btnGuardar.Enabled = True

            If (ckbTarifaNormal.Checked And ckbTarifaArticulos.Checked = False) Then
                tpArticulo.Parent = Nothing
                tpNormal.Parent = tcTipo
            ElseIf (ckbTarifaNormal.Checked = False And ckbTarifaArticulos.Checked) Then
                tpNormal.Parent = Nothing
            ElseIf (ckbTarifaNormal.Checked And ckbTarifaArticulos.Checked) Then
                tpNormal.Parent = tcTipo
                tpNormal.Select()
            Else
                tpArticulo.Parent = Nothing
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

            If (ckbTarifaArticulos.Checked And ckbTarifaNormal.Checked = False) Then
                tpArticulo.Parent = tcTipo
                tpNormal.Parent = Nothing
            ElseIf (ckbTarifaArticulos.Checked = False And ckbTarifaNormal.Checked) Then
                tpArticulo.Parent = Nothing
            ElseIf (ckbTarifaArticulos.Checked And ckbTarifaNormal.Checked) Then
                tpArticulo.Parent = tcTipo
                tpArticulo.Select()
            Else
                tpArticulo.Parent = Nothing
                tpNormal.Parent = Nothing
                btnGuardar.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DgvListTarifasArticulos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvListTarifasArticulos.DoubleClick
        Try
            If (DgvListTarifasArticulos.Rows.Count <= 0) Then
                Exit Sub
            End If

            '-->cuando el botón del menu editar esta desactivado no permite realizar ediciones.
            If (EditarToolStripMenuItem.Enabled = False) Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            action = ACTION_UPDATE

            ckbTarifaNormal.Enabled = False
            ckbTarifaNormal.Checked = False
            ckbTarifaArticulos.Checked = True

            TabTarifa.Parent = Me.tcTarifas
            '-->Carga subCuenta para el mantenimineto de las tarifas, vasado en el combo SubCuenta_Cliente
            utilData.cargarCombos(, cboSubCuenta_Articulos, True, cboSubCuenta_Cliente.DataSource)
            cboSubCuenta_Articulos.SelectedIndex = 0

            Dim row As DataRow
            row = DirectCast(DgvListTarifasArticulos.DataSource, DataTable).Rows(DgvListTarifasArticulos.CurrentRow.Index)

            TxtCodigo.Text = DgvClientes.CurrentRow.Cells("ruc").Value
            txtCliente.Text = txtCliente_Cliente.Text
            cboOrigen_Mnt.Text = row("origen")
            cboDestino_Mnt.Text = row("destino")
            cboSubCuenta_Articulos.Text = row("subCuenta")
            cboProducto_Articulos.SelectedValue = row("idProcesos")
            dtpFechaActivacion_Articulos.Text = row("fecha_Activacion")

            '-->Carga tarifas x articulos, si es que lo tubiese
            Dim dtTarifasArticulos As New DataTable
            Dim rowTA As DataRow()
            dtTarifasArticulos = DgvListTarifasArticulos.DataSource
            If (dtTarifasArticulos.Rows.Count > 0) Then
                rowTA = dtTarifasArticulos.Select("idCiudadOrigen=" & cboOrigen_Mnt.SelectedValue & " AND idCiudadDestino=" _
                                                  & cboDestino_Mnt.SelectedValue & " AND idSubCuenta=" & cboSubCuenta_Articulos.SelectedValue)
                If (rowTA.Length > 0) Then
                    cargarDataGridMntTarifasArticulos(rowTA)
                Else
                    cargarDataGridMntTarifasArticulos()
                End If
            Else
                cargarDataGridMntTarifasArticulos()
            End If

            cboSubCuenta_Articulos.Enabled = False

            TxtBase.Enabled = True
            TxtPeso.Enabled = True
            TxtVolumen.Enabled = True
            TxtSobre.Enabled = True

            txtPesoMinimo.Enabled = True
            txtFleteMinimoPeso.Enabled = True
            txtVolumenMinimo.Enabled = True
            txtFleteMinimoVolumen.Enabled = True

            btnGuardar.Enabled = True
            tcTarifas.SelectedIndex = 2
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub rbRazonSocial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRazonSocial.CheckedChanged
        txtCliente_Buscar.Clear()
        txtCliente_Buscar.Focus()
    End Sub
    Private Sub rbRuc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRuc.CheckedChanged
        txtCliente_Buscar.Clear()
        txtCliente_Buscar.Focus()
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
                Case Is = DgvMntTarifaArticulos.CurrentRow.Cells("minimo").ColumnIndex
                    If IsDBNull(DgvMntTarifaArticulos.CurrentRow.Cells("minimo").Value) Then
                        DgvMntTarifaArticulos.CurrentRow.Cells("minimo").Value = 0.0
                    ElseIf (DgvMntTarifaArticulos.CurrentRow.Cells("minimo").Value = "") Then
                        DgvMntTarifaArticulos.CurrentRow.Cells("minimo").Value = 0.0
                    End If
                Case Is = DgvMntTarifaArticulos.CurrentRow.Cells("base").ColumnIndex
                    If IsDBNull(DgvMntTarifaArticulos.CurrentRow.Cells("base").Value) Then
                        DgvMntTarifaArticulos.CurrentRow.Cells("base").Value = 0.0
                    ElseIf (DgvMntTarifaArticulos.CurrentRow.Cells("base").Value = "") Then
                        DgvMntTarifaArticulos.CurrentRow.Cells("base").Value = 0.0
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
    Private Sub tspAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If (tcListaTarifas.SelectedIndex = 0 And DgvListTarifasPeso.Rows.Count > 0) Then
                Dim ruta As String
                ruta = DgvListTarifasPeso.CurrentRow.Cells("Origen").Value & " - " & DgvListTarifasPeso.CurrentRow.Cells("Destino").Value

                If (MessageBox.Show("Esta seguro de realizar la anulación de la tarifa " & Chr(13) & ruta, "Tarifa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                    Dim idTarifaclienteCargo As Long = DgvListTarifasPeso.CurrentRow.Cells("idTarifa_Cliente_Cargo").Value
                    objTarifaCliente.F_InactivarTarifa_Cliente_AD(idTarifaclienteCargo, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

                    btnConsultar_Click(1, Nothing)
                End If

            ElseIf (tcListaTarifas.SelectedIndex = 1 And DgvListTarifasArticulos.Rows.Count > 0) Then
                Dim ruta As String
                ruta = DgvListTarifasArticulos.CurrentRow.Cells("Origen").Value & " - " & DgvListTarifasArticulos.CurrentRow.Cells("Destino").Value

                If (MessageBox.Show("Esta seguro de realizar la anulación de la tarifa " & Chr(13) & ruta, "Tarifa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                    Dim idTarifaclienteArticulo As Long = DgvListTarifasArticulos.CurrentRow.Cells("idTarifa_Cliente_Articulo").Value
                    objTarifaCliente.F_InactivarTarifa_Cliente_Articulo_AD(idTarifaclienteArticulo, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

                    btnConsultar_Click(1, Nothing)
                End If

            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TxtPeso_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtPeso.KeyUp
        If (e.KeyCode = 13) Then TxtVolumen.Focus()
    End Sub
    Private Sub TxtPeso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPeso.LostFocus
        If (TxtPeso.Text.Trim = "") Then TxtPeso.Text = 0.0

        Dim monto As Double = TxtPeso.Text
        TxtPeso.Text = Format(monto, "#,###.#0")
    End Sub

    Private Sub TxtVolumen_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtVolumen.KeyUp
        If (e.KeyCode = 13) Then TxtSobre.Focus()
    End Sub
    Private Sub TxtVolumen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVolumen.LostFocus
        If (TxtVolumen.Text.Trim = "") Then TxtVolumen.Text = 0.0

        Dim monto As Double = TxtVolumen.Text
        TxtVolumen.Text = Format(monto, "#,###.#0")
    End Sub

    Private Sub TxtSobre_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtSobre.KeyUp
        If (e.KeyCode = 13) Then TxtBase.Focus()
    End Sub
    Private Sub TxtSobre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSobre.LostFocus
        If (TxtSobre.Text.Trim = "") Then TxtSobre.Text = 0.0

        Dim monto As Double = TxtSobre.Text
        TxtSobre.Text = Format(monto, "#,###.#0")
    End Sub

    Private Sub TxtBase_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtBase.KeyUp
        If (e.KeyCode = Keys.Enter) Then txtPesoMinimo.Focus()
    End Sub
    Private Sub TxtBase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBase.LostFocus
        If (TxtBase.Text.Trim = "") Then TxtBase.Text = 0.0

        Dim monto As Double = TxtBase.Text
        TxtBase.Text = Format(monto, "#,###.#0")
    End Sub
    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, AnularToolStripMenuItem.EnabledChanged, EditarToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
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
        If (e.KeyChar = Chr(13)) Then btnGuardar.Focus()
    End Sub
    Private Sub txtFleteMinimoVolumen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFleteMinimoVolumen.LostFocus
        If (txtFleteMinimoVolumen.Text = "") Then txtFleteMinimoVolumen.Text = 0.0

        Dim monto As Double = txtFleteMinimoVolumen.Text
        txtFleteMinimoVolumen.Text = Format(monto, "#,###.#0")
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

End Class