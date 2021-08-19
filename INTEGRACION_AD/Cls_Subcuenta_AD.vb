Imports INTEGRACION_EN
Imports AccesoDatos
Public Class Cls_Subcuenta_AD
    ''' <summary>
    ''' REALIZA LA CONSULTA DEL CENTRO DE COSTO
    ''' </summary>
    ''' <param name="idCliente">Identificador del Cliente</param>
    ''' <param name="idCiudadCobertura">Identificador de la ciudad de cobertura</param>
    ''' <returns>listado de subCuentas</returns>
    Public Function buscarSubCuenta(ByVal idCliente As Long, ByVal idCiudadCobertura As Long) As DataTable
        Try
            Dim db As New BaseDatos
            Dim ds As DataSet

            db.CrearComando("PKG_MNTSUBCUENTA.SP_BUSCAR", CommandType.StoredProcedure)
            db.AsignarParametro("v_idPerdona", idCliente, OracleClient.OracleType.Number)
            db.AsignarParametro("v_idUnidad_Agencia", idCiudadCobertura, OracleClient.OracleType.Number)
            db.AsignarParametro("Cur_Lista_SubCuentas", OracleClient.OracleType.Cursor)

            ds = db.EjecutarDataSet()

            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try        
    End Function
    ''' <summary>
    ''' GUARDA EL CENTRO DE COSTO
    ''' </summary>
    ''' <param name="contactoCentroCosto">Objeto Centro de consto</param>
    Public Function guardar(ByVal contactoCentroCosto As Cls_ContactoCentroCosto) As DataTable
        Try
            Dim db As New BaseDatos
            Dim ds As DataSet

            db.CrearComando("PKG_MNTSUBCUENTA.SP_GUARDAR", CommandType.StoredProcedure)
            db.AsignarParametro("v_idCentroCosto", contactoCentroCosto.centroCosto.idCentrocosto, OracleClient.OracleType.Number)
            db.AsignarParametro("v_centroCosto", contactoCentroCosto.centroCosto.centroCosto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_idPersona", contactoCentroCosto.persona.idPersona, OracleClient.OracleType.Number)
            db.AsignarParametro("v_idUnidadAgenica", contactoCentroCosto.unidadAgenica.idUnidadAgencia, OracleClient.OracleType.Number)
            db.AsignarParametro("v_codigoSap", contactoCentroCosto.codigoSap, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_idUsuario", contactoCentroCosto.idUsuarioRegistro, OracleClient.OracleType.Number)
            db.AsignarParametro("v_idRol", contactoCentroCosto.idRolRegistro, OracleClient.OracleType.Number)
            db.AsignarParametro("v_ip", contactoCentroCosto.ipRegistro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("Cur_CentroCostoDuplicado", OracleClient.OracleType.Cursor)

            ds = db.EjecutarDataSet()

            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    ''' <summary>
    ''' REALIZA LA ANULACION DEL CENTRO DE COSTO
    ''' </summary>
    ''' <param name="idCentrocosto">Identificador del Centro de Costo</param>
    ''' <param name="idUsuario">Identificador del usuario que realiza la anulacion</param>
    ''' <param name="idRol">Identificador del rol con el que se esta realizando la anulacion</param>
    ''' <param name="ip">Numero de IP de la Pc de donde se esta realizando la anulacion</param>
    Public Sub anular(ByVal idCentrocosto As Long, ByVal idUsuario As Integer, ByVal idRol As Integer, ByVal ip As String)
        Try
            Dim db As New BaseDatos

            db.CrearComando("PKG_MNTSUBCUENTA.SP_ANULAR", CommandType.StoredProcedure)
            db.AsignarParametro("v_idCentroCosto", idCentrocosto, OracleClient.OracleType.Number)
            db.AsignarParametro("v_idUsuario", idUsuario, OracleClient.OracleType.Number)
            db.AsignarParametro("v_idRol", idRol, OracleClient.OracleType.Number)
            db.AsignarParametro("v_ip", ip, OracleClient.OracleType.VarChar)

            db.EjecutarDataSet()

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

    Public Sub ActualizarSubcuenta(idTipo As Long, idComprobante As Long, idCentroCosto As Long, idUsuario As Integer, idRol As Integer, ip As String, opcion As Integer)
        Dim db As New BaseDatos
        Try
            Dim dt As DataTable
            db.CrearComando("PKG_MNTSUBCUENTA.SP_ACTUALIZAR_VENTA_SUBCUENTA", CommandType.StoredProcedure)
            db.AsignarParametro("v_idtipo_comprobante", idTipo, OracleClient.OracleType.Number)
            db.AsignarParametro("v_idcomprobante", idComprobante, OracleClient.OracleType.Number)
            db.AsignarParametro("v_idCentroCosto", idCentroCosto, OracleClient.OracleType.Number)
            db.AsignarParametro("v_idUsuario", idUsuario, OracleClient.OracleType.Number)
            db.AsignarParametro("v_idRol", idRol, OracleClient.OracleType.Number)
            db.AsignarParametro("v_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            dt = db.EjecutarDataTable()
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0)(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString())
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Public Function BuscarVenta(ByVal idCliente As Long, ByVal idSubcuenta As Long, idCiudad As Long) As DataTable
        Dim db As New BaseDatos
        Try
            Dim ds As DataSet
            db.CrearComando("PKG_MNTSUBCUENTA.SP_BUSCAR_VENTA_SUBCUENTA", CommandType.StoredProcedure)
            db.AsignarParametro("v_cliente", idCliente, OracleClient.OracleType.Number)
            db.AsignarParametro("v_subcuenta", idSubcuenta, OracleClient.OracleType.Number)
            db.AsignarParametro("v_ciudad", idCiudad, OracleClient.OracleType.Number)
            db.AsignarParametro("Cur_Venta", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            ds = db.EjecutarDataSet()
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0)(0)) Then
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

    Function ListarSubcuentaCliente(cliente As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION_CLIENTE.sp_listar_subcuenta_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_subcuenta", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
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

End Class
