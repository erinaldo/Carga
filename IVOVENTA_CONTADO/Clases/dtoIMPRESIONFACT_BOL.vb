Imports AccesoDatos
Public Class dtoIMPRESIONFACT_BOL
    Public xIdFactura As String
    Public xAgenciaDestino As String
    Public xOrigen As String
    Public xDestino As String
    Public xNRODOCFAC_BOL As String
    Public xRazonSocial As String
    Public xDireccionRemitente As String
    Public xRuc As String
    Public xRemitente As String
    Public xConsignado As String
    Public xDireccionConsignado As String
    Public xfecha_factura As String
    '
    Public xCantidad_Peso As String
    Public xCantidad_Vol As String
    Public xCantidad_Sobre As String
    '
    Public xTotalPeso As String
    Public xTotalVolumen As String
    Public xTotalSobres As String
    Public xDescuento As String = ""
    '
    Public xFormaPago As String = ""
    Public xNroRef As String = ""
    Public xMemo As String
    Public xMonto_Sub_Total As String
    Public xMonto_Impuesto As String
    Public xTotal_Costo As Double
    Public xMonto_Sub_Total_Peso As String
    Public xMonto_Sub_Total_Vol As String
    Public xMonto_Sub_Total_Sobre As String
    Public xTIPO_ENTREGA As String
    Public Function fnClear() As Boolean
        Try
            xIdFactura = ""
            xOrigen = ""
            xDestino = ""
            xNRODOCFAC_BOL = ""
            xRazonSocial = ""
            xDireccionRemitente = ""
            xRuc = ""
            xRemitente = ""
            xConsignado = ""
            xDireccionConsignado = ""
            xfecha_factura = ""
            xCantidad_Peso = ""
            xCantidad_Sobre = ""
            xCantidad_Vol = ""
            xTotalPeso = ""
            xTotalVolumen = ""
            xTotalSobres = ""
            xFormaPago = ""
            xNroRef = ""
            xMemo = ""
            xMonto_Sub_Total = ""
            xMonto_Impuesto = ""
            xTotal_Costo = 0
        Catch ex As Exception

        End Try
    End Function

    Public Function TelefonoCliente(ByVal cliente As Integer) As String
        Dim flag As String = ""
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select sf_get_celular(" & cliente & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            'db_bd.AsignarParametro("ni_idunidad_agencia", idUnidadCiudad, OracleClient.OracleType.Int32)
            'Variables de salidas 
            flag = db_bd.EjecutarEscalar()
            'Desconectar 
            db_bd.Desconectar()
            'Ejecutando el escalar 
            'Return db_bd.EjecutarEscalar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

End Class
