Imports INTEGRACION_AD
Imports INTEGRACION_EN
Public Class Cls_SubCuenta_LN
    Dim getSubcuenta As New Cls_Subcuenta_AD
    ''' <summary>
    ''' REALIZA LA CONSULTA DEL CENTRO DE COSTO
    ''' </summary>
    ''' <param name="idCliente">Identificador del Cliente</param>
    ''' <param name="idCiudadCobertura">Identificador de la ciudad de cobertura</param>
    ''' <returns>Datatable con el resultado</returns>
    Public Function buscarSubCuenta(ByVal idCliente As Long, ByVal idCiudadCobertura As Long) As DataTable
        Return getSubcuenta.buscarSubCuenta(idCliente, idCiudadCobertura)
    End Function

    Public Function buscarVenta(ByVal idCliente As Long, ByVal idSubcuenta As Long, idCiudad As Long) As DataTable
        Return getSubcuenta.buscarVenta(idCliente, idSubcuenta, idCiudad)
    End Function

    Public Sub ActualizarSubcuenta(idTipo As Long, idComprobante As Long, idCentroCosto As Long, idUsuario As Integer, idRol As Integer, ip As String, opcion As Integer)
        getSubcuenta.ActualizarSubcuenta(idTipo, idComprobante, idCentroCosto, idUsuario, idRol, ip, opcion)
    End Sub
    ''' <summary>
    ''' GUARDA EL CENTRO DE COSTO
    ''' </summary>
    ''' <param name="contactoCentroCosto">Objeto Centro de consto</param>
    Public Function guardar(ByVal contactoCentroCosto As Cls_ContactoCentroCosto) As DataTable
        Return getSubcuenta.guardar(contactoCentroCosto)
    End Function
    ''' <summary>
    ''' REALIZA LA ANULACION DEL CENTRO DE COSTO
    ''' </summary>
    ''' <param name="idCentrocosto">Identificador del Centro de Costo</param>
    ''' <param name="idUsuario">Identificador del usuario que realiza la anulacion</param>
    ''' <param name="idRol">Identificador del rol con el que se esta realizando la anulacion</param>
    ''' <param name="ip">Numero de IP de la Pc de donde se esta realizando la anulacion</param>
    Public Sub anular(ByVal idCentrocosto As Long, ByVal idUsuario As Integer, ByVal idRol As Integer, ByVal ip As String)
        getSubcuenta.anular(idCentrocosto, idUsuario, idRol, ip)
    End Sub

    Function ListarSubcuentaCliente(cliente As Integer) As DataTable
        Return getSubcuenta.ListarSubcuentaCliente(cliente)
    End Function

End Class
