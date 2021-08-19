Public Class FENota
    Public Overridable Property numeroSerie As String
    Public Overridable Property numeroCorrelativo As String
    Public Overridable Property cliente As FECliente
    Public Overridable Property documentoReferencia As FEDocumentoReferencia
    Public Overridable Property fechaEmison As String
    Public Overridable Property tipoNota As String
    Public Overridable Property descripcionTipoNota As String
    Public Overridable Property descripcionSustento As String
    Public Overridable Property igv As Double
    Public Overridable Property subTotal As Double
    Public Overridable Property total As Double
    Public Overridable Property totalLentras As String
    Public Overridable Property tipoVenta As Integer = 0
    Public Overridable Property id As Integer
    Public Overridable Property tabla As String
    Public Overridable Property agenciaId As Integer
    Public Overridable Property usuarioID As Integer
    Public Overridable Property usuarioInsercion As String
    Public Overridable Property usuarioModificacion As String
    Public Overridable Property isMonedaSoles As Boolean = True

End Class
