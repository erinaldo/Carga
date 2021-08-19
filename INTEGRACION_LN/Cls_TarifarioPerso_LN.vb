Imports INTEGRACION_AD
Imports INTEGRACION_EN
Public Class Cls_TarifarioPerso_LN

    Dim ObjTarifarioPerso_AD As New Cls_TarifarioPerso_AD
    'Public Function BuscarTarifaCliente_LN(ByVal iOrigen As Integer, ByVal iDestino As Integer, ByVal iCliente As String, ByVal iControl As Integer) As DataTable
    '    Return ObjTarifarioPerso_AD.BuscarTarifaCliente_AD(iOrigen, iDestino, iCliente, iControl)
    'End Function
    ''' <summary>
    ''' BUSCA TARIFARIO PERSONALISADO DE UN CLIENTE
    ''' </summary>
    ''' <param name="idPersona">Identificador del Cliente</param>
    ''' <param name="idOrigen">Identificador del Origen</param>
    ''' <param name="idDestino">Identificador del Destino</param>
    ''' <param name="idProducto">Idenficador del Producto</param>
    ''' <param name="idTipoTarifa">Idenficador del Tipo de tarifa</param>
    ''' <returns>Listado de Tarifas (Objeto DataTable)</returns>
    ''' <param name="idCentroCosto">Identificador del Centro de costo</param>
    Public Function BuscarTarifa(ByVal idPersona As String, Optional ByVal idOrigen As Integer = 0, Optional ByVal idDestino As Integer = 0, Optional ByVal idProducto As Integer = 0, _
                                    Optional ByVal idTipoTarifa As Integer = 0, Optional ByVal idCentroCosto As Integer = 0) As DataSet
        Return ObjTarifarioPerso_AD.BuscarTarifa(idPersona, idOrigen, idDestino, idProducto, idTipoTarifa, idCentroCosto)
    End Function
    Public Sub F_InsTarifario_LN(ByVal objTarifaCliente_EN As Cls_TarifaPersona_EN)
        ObjTarifarioPerso_AD.F_InsTarifario_AD(objTarifaCliente_EN)
    End Sub
    Public Sub F_InsTarifario_Articulo_AD(ByVal tarifaClienteArticulo As Cls_TarifaClienteArticulo)
        ObjTarifarioPerso_AD.F_InsTarifario_Articulo_AD(tarifaClienteArticulo)
    End Sub
    Public Sub F_InactivarTarifa_Cliente_AD(ByVal v_idTarifaClienteCargo As Long, ByVal idUsuario As Integer, ByVal ip As String)
        ObjTarifarioPerso_AD.F_InactivarTarifa_Cliente_AD(v_idTarifaClienteCargo, idUsuario, ip)
    End Sub
    Public Sub F_InactivarTarifa_Cliente_Articulo_AD(ByVal v_idTarifaClArticulo As Long, ByVal idUsuario As Integer, ByVal ip As String)
        ObjTarifarioPerso_AD.F_InactivarTarifa_Cliente_Articulo_AD(v_idTarifaClArticulo, idUsuario, ip)
    End Sub
    ' ''' <summary>
    ' ''' BUSCA EL MAESTRO DE ARTICULOS
    ' ''' </summary>
    ' ''' <returns>Lista de articulos</returns>
    'Public Function buscarArticulos() As DataTable
    '    Return ObjTarifarioPerso_AD.buscarArticulos()
    'End Function


End Class
