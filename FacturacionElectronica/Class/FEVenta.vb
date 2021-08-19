Public Class FEVenta
    '-->Obligatorio Para la venta contado, por el tema de la impresion del ticket (no para credito)
    Public Overridable Property origen As String
    Public Overridable Property destino As String
    Public Overridable Property remitenete As String
    Public Overridable Property consignado As String
    Public Overridable Property tipoEntrega As String
    Public Overridable Property direccionEntrega As String
    Public Overridable Property formaPago As String
    Public Overridable Property opExonerada As Double = 0.0
    Public Overridable Property opInafecta As Double = 0.0
    Public Overridable Property agenciaEmision As String
    Public Overridable Property usuarioEmision As String
    Public Overridable Property producto As String
    Public Overridable Property isCortesia As Boolean = False
    Public Overridable Property tipoVenta As Integer = 0
    Public Overridable Property id As Integer
    Public Overridable Property tabla As String
    'hlamas 23-03-2017
    Public Overridable Property TipoAfectacion As Integer

    '-->Opcional 
    Public Overridable Property glosaRetencion As String
    Public Overridable Property numeroPrefactura As String
    Public Overridable Property isSOUE As Boolean = False
    Public Overridable Property agenciaId As Integer
    Public Overridable Property usuarioID As Integer
    Public Overridable Property usuarioInsercion As String
    Public Overridable Property usuarioModificacion As String
    
    '-->Campos Obligatorios para todos los escenarios (credito y contado)
    Public Overridable Property isCredito As Boolean = False
    Public Overridable Property numeroSerie As String
    Public Overridable Property numeroCorrelativo As String
    Public Overridable Property isMonedaSoles As Boolean = True
    Public Overridable Property fechaEmision As String
    Public Overridable Property tipoComprobanteID As Integer
    Public Overridable Property cliente As FECliente
    Public Overridable Property opGravada As Double
    Public Overridable Property igv As Double
    Public Overridable Property total As Double
    Public Overridable Property totalLetras As String
    Public Overridable Property detalleVenta As List(Of FEDetalleVenta)

    'hlamas 22-02-2019
    Public Overridable Property direccionFiscal As String
    Public Overridable Property documentoReferencia As FEDocumentoReferencia
    Public Overridable Property MontoLetras As String

    Public Overridable Property barra() As Byte
End Class
