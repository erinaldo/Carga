Imports AccesoDatos
Public Class dtoPREFACTURA
    Private vAccion As Integer
    Private vIDPreFactura As Integer
    Private vNroPreFactura As String
    Private vIDPersona As String
    Private vMontoPrefactura As Double
    Private intProducto As Integer
    Public Property Accion() As Integer
        Get
            Return vAccion
        End Get
        Set(ByVal value As Integer)
            vAccion = value
        End Set
    End Property
    Public Property IDPreFactura() As Integer
        Get
            Return vIDPreFactura
        End Get
        Set(ByVal value As Integer)
            vIDPreFactura = value
        End Set
    End Property
    Public Property NroPreFactura() As String
        Get
            Return vNroPreFactura
        End Get
        Set(ByVal value As String)
            vNroPreFactura = value
        End Set
    End Property
    Public Property IDPersona() As String
        Get
            Return vIDPersona
        End Get
        Set(ByVal value As String)
            vIDPersona = value
        End Set
    End Property
    Public Property MontoPrefactura() As Double
        Get
            Return vMontoPrefactura
        End Get
        Set(ByVal value As Double)
            vMontoPrefactura = value
        End Set
    End Property

    Public Property Producto As Integer
        Get
            Return intProducto
        End Get
        Set(value As Integer)
            intProducto = value
        End Set
    End Property

    Private intUsuario As Integer
    Public Property Usuario() As Integer
        Get
            Return intUsuario
        End Get
        Set(ByVal value As Integer)
            intUsuario = value
        End Set
    End Property


    'Public Function AgregaPreFactura2009() As ADODB.Recordset
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_PREFACTURA", 12, _
    '    vAccion, 1, _
    '    vIDPreFactura, 1, _
    '    vNroPreFactura, 2, _
    '    vIDPersona, 2, _
    '    vMontoPrefactura, 3}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function
    Public Function AgregaPreFactura() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_PREFACTURA", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", vAccion, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPREFACTURA", vIDPreFactura, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNRO_PREFACTURA", vNroPreFactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDPERSONA", vIDPersona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iMONTO_PREFACTURA", vMontoPrefactura, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function ASOCIA_GUIA_PREFACTURA(ByVal prefactura As String, ByVal guia As String, ByVal usuario As Integer, ByVal rol As Integer, ByVal ip As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_ASOCIA_GUIA_PREFACTURA", CommandType.StoredProcedure)
            db.AsignarParametro("iIDPREFACTURA", prefactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNRO_GUIA", guia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Sub NoPrefacturarGuiaEnvio(guia As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.sp_NoPrefacturarGuiaEnvio", CommandType.StoredProcedure)
            db.AsignarParametro("ni_guia", guia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
End Class
