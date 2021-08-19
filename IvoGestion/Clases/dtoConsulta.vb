Imports AccesoDatos
Public Class dtoConsulta
#Region "Propiedades"
    Private strInicio As String
    Public Property Inicio() As String
        Get
            Return strInicio
        End Get
        Set(ByVal value As String)
            strInicio = value
        End Set
    End Property
    Private strFin As String
    Public Property Fin() As String
        Get
            Return strFin
        End Get
        Set(ByVal value As String)
            strFin = value
        End Set
    End Property
    Private intEstado As Integer
    Public Property Estado() As Integer
        Get
            Return intEstado
        End Get
        Set(ByVal value As Integer)
            intEstado = value
        End Set
    End Property
    Private intTipoFacturacion As Integer
    Public Property TipoFacturacion() As Integer
        Get
            Return intTipoFacturacion
        End Get
        Set(ByVal value As Integer)
            intTipoFacturacion = value
        End Set
    End Property
    Private intTipoEntrega As Integer
    Public Property TipoEntrega() As Integer
        Get
            Return intTipoEntrega
        End Get
        Set(ByVal value As Integer)
            intTipoEntrega = value
        End Set
    End Property
    Private intOrigen As Integer
    Public Property Origen() As Integer
        Get
            Return intOrigen
        End Get
        Set(ByVal value As Integer)
            intOrigen = value
        End Set
    End Property
    Private intDestino As Integer
    Public Property Destino() As Integer
        Get
            Return intDestino
        End Get
        Set(ByVal value As Integer)
            intDestino = value
        End Set
    End Property
    Private intAgenciaOrigen As Integer
    Public Property AgenciaOrigen() As Integer
        Get
            Return intAgenciaOrigen
        End Get
        Set(ByVal value As Integer)
            intAgenciaOrigen = value
        End Set
    End Property
    Private intAgenciaDestino As Integer
    Public Property AgenciaDestino() As Integer
        Get
            Return intAgenciaDestino
        End Get
        Set(ByVal value As Integer)
            intAgenciaDestino = value
        End Set
    End Property
    Private intTipoComprobante As Integer
    Public Property TipoComprobante() As Integer
        Get
            Return intTipoComprobante
        End Get
        Set(ByVal value As Integer)
            intTipoComprobante = value
        End Set
    End Property

    Private intTipoPersona As Integer
    Public Property TipoPersona() As Integer
        Get
            Return intTipoPersona
        End Get
        Set(ByVal value As Integer)
            intTipoPersona = value
        End Set
    End Property
    Private intTipoTarjeta As Integer
    Public Property TipoTarjeta() As Integer
        Get
            Return intTipoTarjeta
        End Get
        Set(ByVal value As Integer)
            intTipoTarjeta = value
        End Set
    End Property
    Private strTarjeta As String
    Public Property Tarjeta() As String
        Get
            Return strTarjeta
        End Get
        Set(ByVal value As String)
            strTarjeta = value
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
    Private intCliente As Integer
    Public Property Cliente() As Integer
        Get
            Return intCliente
        End Get
        Set(ByVal value As Integer)
            intCliente = value
        End Set
    End Property
    Private intSubcuenta As Integer
    Public Property Subcuenta() As Integer
        Get
            Return intSubcuenta
        End Get
        Set(ByVal value As Integer)
            intSubcuenta = value
        End Set
    End Property
    Private intFuncionario As Integer
    Public Property Funcionario() As Integer
        Get
            Return intFuncionario
        End Get
        Set(ByVal value As Integer)
            intFuncionario = value
        End Set
    End Property
    Private intProducto As Integer
    Public Property Producto() As Integer
        Get
            Return intProducto
        End Get
        Set(ByVal value As Integer)
            intProducto = value
        End Set
    End Property
    Private strConsignado As String
    Public Property Consignado() As String
        Get
            Return strConsignado
        End Get
        Set(ByVal value As String)
            strConsignado = value
        End Set
    End Property
    Private strCliente As String
    Public Property RazonSocial() As String
        Get
            Return strCliente
        End Get
        Set(ByVal value As String)
            strCliente = value
        End Set
    End Property

    Private strNumeroDocumento As String
    Public Property NumeroDocumento() As String
        Get
            Return strNumeroDocumento
        End Get
        Set(ByVal value As String)
            strNumeroDocumento = value
        End Set
    End Property

    Private strBoleto As String
    Public Property Boleto() As String
        Get
            Return strBoleto
        End Get
        Set(ByVal value As String)
            strBoleto = value
        End Set
    End Property



#End Region
    Function Iniciar() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_CONSULTA.sp_inicio", CommandType.StoredProcedure)
            db.AsignarParametro("co_ciudad", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_agencia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tipo_facturacion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tipo_entrega", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tipo_comprobante", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tipo_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_tarjeta", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_producto", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_funcionario", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(10).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(10).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(10).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function Listar(obj As dtoConsulta) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_CONSULTA.sp_consulta", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", obj.Inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", obj.Fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", obj.Estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_facturacion", obj.TipoFacturacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_entrega", obj.TipoEntrega, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", obj.Origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", obj.Destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia_origen", obj.AgenciaOrigen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia_destino", obj.AgenciaDestino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_comprobante", obj.TipoComprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_persona", obj.TipoPersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_tarjeta", obj.TipoTarjeta, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_tarjeta", obj.Tarjeta, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_cliente", obj.Cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_subcuenta", obj.Subcuenta, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_funcionario", obj.Funcionario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_consignado", obj.Consignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_producto", obj.Producto, OracleClient.OracleType.Int32)

            db.AsignarParametro("vi_cliente", obj.RazonSocial, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_numero_documento", obj.NumeroDocumento, OracleClient.OracleType.VarChar)

            db.AsignarParametro("vi_boleto", obj.Boleto, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function


End Class
