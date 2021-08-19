Imports System.Windows.Forms
Imports AccesoDatos
''' <summary>
''' JOSE ABANTO ABANTO
''' </summary>
Public Class UtilData_AD
    ''' <summary>
    ''' CARGA LOS OBJETOS COMBOBOX
    ''' </summary>
    ''' <param name="table">Nombre de la tabla</param>
    ''' <param name="comboBox">Objeto comboBox</param>
    ''' <param name="todos">true se muestra al inicio del como "TODOS"; false "SELECCIONE"</param>
    ''' <param name="dataTable">Opcional, Objeto con el que se deben cargar los datos</param>
    ''' <remarks>jabanto</remarks>
    Public Sub cargarCombos(Optional ByVal table As String = "", Optional ByVal comboBox As ComboBox = Nothing, Optional ByVal todos As Boolean = False, Optional ByVal dataTable As DataTable = Nothing, _
                            Optional ByVal parametro As Integer = 0, Optional opcion As String = "", Optional idopcion As Integer = -2, Optional fila As Integer = 0)
        Try
            If IsNothing(dataTable) Then
                Dim db_bd As New BaseDatos
                Dim lds_tmp As New DataSet
                db_bd.Conectar()
                db_bd.CrearComando("SP_LISTAR_COMBOS", CommandType.StoredProcedure)
                db_bd.AsignarParametro("PC_NOM_TABLA", table, OracleClient.OracleType.VarChar)
                db_bd.AsignarParametro("PARAMETRO", parametro, OracleClient.OracleType.Int32)
                db_bd.AsignarParametro("CUR_AGENCIA_COMBO", OracleClient.OracleType.Cursor)

                db_bd.Desconectar()
                lds_tmp = db_bd.EjecutarDataSet

                dataTable = New DataTable
                dataTable = lds_tmp.Tables(0)
            End If

            Dim dtCombo As New DataTable
            dtCombo.Columns.Add("id").DataType = GetType(Integer)
            dtCombo.Columns.Add("Nombre").DataType = GetType(String)

            '-->Agrega la seleccione o todos

            If (todos) Then : dtCombo.Rows.Add(-1, "TODOS")
            Else : dtCombo.Rows.Add(-1, "(SELECCIONE)") : End If

            '-->Solo cuando carga el centro de costo
            If (table = "t_CentroCosto") Then
                dtCombo.Rows.Add(999, "GENERICO")
            End If

            '-->Carga registros
            For Each rowC As DataRow In dataTable.Rows
                '-->posicion "0" reprecenta el ID y 1 el nombre o denominacion
                If (rowC(0) >= 0) Then
                    dtCombo.Rows.Add(rowC(0), rowC(1))
                End If
            Next

            If opcion.Trim.Length > 0 Then
                dtCombo.Rows.Add(idopcion, opcion)
            End If

            comboBox.DataSource = dtCombo
            comboBox.DisplayMember = "Nombre"
            comboBox.ValueMember = "id"

            comboBox.SelectedIndex = fila
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub
    ''' <summary>
    ''' BUSCA EL MAESTRO DE ARTICULOS
    ''' </summary>
    ''' <returns>Lista de articulos</returns>
    Public Function buscarArticulos() As DataTable
        Dim db_bd As New BaseDatos
        Dim lds_tmp As New DataSet
        db_bd.Conectar()
        db_bd.CrearComando("SP_LISTAR_COMBOS", CommandType.StoredProcedure)
        db_bd.AsignarParametro("PC_NOM_TABLA", "t_articulos", OracleClient.OracleType.VarChar)
        db_bd.AsignarParametro("CUR_AGENCIA_COMBO", OracleClient.OracleType.Cursor)

        db_bd.Desconectar()
        lds_tmp = db_bd.EjecutarDataSet

        Return lds_tmp.Tables(0)
    End Function
    ''' <summary>
    ''' Determina si la tarifa publica creada es para atencion al publico en general (1) o para clientes corporativos (2).
    ''' </summary>
    Public Sub cargarTipoVisibilidad(ByVal ComboBox As ComboBox, ByVal todos As Boolean, Optional fila As Integer = 0)
        Dim dtVisibilidad As New DataTable
        dtVisibilidad.Columns.Add("idVisibilidad").DataType = GetType(Integer)
        dtVisibilidad.Columns.Add("Nombre").DataType = GetType(String)

        If (todos) Then
            dtVisibilidad.Rows.Add(0, "TODOS")
        Else
            dtVisibilidad.Rows.Add(0, "SELECCIONE")
        End If

        dtVisibilidad.Rows.Add(1, "PUBLICO")
        dtVisibilidad.Rows.Add(2, "CORPORATIVO")
        dtVisibilidad.Rows.Add(3, "AMBOS")

        ComboBox.DataSource = dtVisibilidad
        ComboBox.DisplayMember = "Nombre"
        ComboBox.ValueMember = "idVisibilidad"

        ComboBox.SelectedIndex = fila
    End Sub

    Public Sub cargarTipoEntrega(ByVal ComboBox As ComboBox, ByVal todos As Boolean, Optional fila As Integer = 0)
        Dim dtVisibilidad As New DataTable
        dtVisibilidad.Columns.Add("idEntrega").DataType = GetType(Integer)
        dtVisibilidad.Columns.Add("Nombre").DataType = GetType(String)

        If (todos) Then
            dtVisibilidad.Rows.Add(0, "TODOS")
        Else
            dtVisibilidad.Rows.Add(0, "SELECCIONE")
        End If

        dtVisibilidad.Rows.Add(1, "AGENCIA")
        dtVisibilidad.Rows.Add(2, "DOMICILIO")
        dtVisibilidad.Rows.Add(3, "AMBOS")

        ComboBox.DataSource = dtVisibilidad
        ComboBox.DisplayMember = "Nombre"
        ComboBox.ValueMember = "ideNTREGA"

        ComboBox.SelectedIndex = fila
    End Sub

    Public Function ListarSubcuenta(cliente As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_cliente_subcuenta", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_subcuenta", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function ListarCiudad(Optional opcion As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_ciudad", CommandType.StoredProcedure)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_ciudad", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function ListarProducto(Optional opcion As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_producto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_producto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function ListarTipoFacturacion() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_tipo_facturacion", CommandType.StoredProcedure)
            db.AsignarParametro("co_tipo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function ListarDireccion(cliente As Integer, Optional tipo As Integer = 0) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_cliente_direccion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_direccion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ListarCliente(documento As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("vi_numero_documento", documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ListarCliente(id As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function TipoControl(ByVal tipo As Integer, ByVal opcion As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("sp_tipo_control", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet
            ds = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString())
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
