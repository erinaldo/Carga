Imports INTEGRACION_AD
Imports INTEGRACION_EN
Public Class Cls_TarifaPublica_LN
    Dim Ob_ClsTarifarioPublico_AD As New Cls_TarifaPublica_AD
    Public Sub F_InsTarifaArticulo_AD(ByVal tarifaAticulo As Cls_TarifaArticulo)
        Ob_ClsTarifarioPublico_AD.F_InsTarifaArticulo_AD(tarifaAticulo)
    End Sub
    Public Function BuscarTarifarioPublico(ByVal iOrigen As String, ByVal iDestino As String, ByVal iVisibilidad As String, _
                                              ByVal iiProducto As String, ByVal StrTipoTarifa As String, TipoEntrega As Integer, ciudad As Integer) As DataSet
        Return Ob_ClsTarifarioPublico_AD.BuscarTarifarioPublico_AD(iOrigen, iDestino, iVisibilidad, iiProducto, StrTipoTarifa, TipoEntrega, ciudad)
    End Function
    Public Function F_InsTarifarioPublico_LN(ByVal tarifaCargo As Cls_TarifaCargo) As String
        Return Ob_ClsTarifarioPublico_AD.F_InsTarifarioPublico_AD(tarifaCargo)
    End Function
    Public Sub Anular_Tarifa_AD(ByVal idTarifa_cargo As Long, ByVal idUsuario As Integer, ByVal ip As String)
        Ob_ClsTarifarioPublico_AD.Anular_Tarifa_AD(idTarifa_cargo, idUsuario, ip)
    End Sub
    Public Sub Anular_TarifaArticulo_AD(ByVal idTarifa_Articulo As Long, ByVal idUsuario As Integer, ByVal ip As String)
        Ob_ClsTarifarioPublico_AD.Anular_TarifaArticulo_AD(idTarifa_Articulo, idUsuario, ip)
    End Sub
    Function GrabarSolicitud(id As Integer, oficina As Integer, ciudad As Integer, observacion As String, _
                             usuario As Integer, ip As String) As Integer
        Return Ob_ClsTarifarioPublico_AD.GrabarSolicitud(id, oficina, ciudad, observacion, usuario, ip)
    End Function
    Sub GrabarSolicitudDetalle(id As Integer, id_cab As Integer, origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, _
                                    tipo_visibilidad As Integer, peso As Double, volumen As Double, sobre As Double, base As Double, _
                                    peso_minimo As Double, flete_minimo As Double, volumen_minimo As Double, flete_volumen_minimo As Double, _
                                    usuario As Integer, ip As String, estado As Integer)
        Ob_ClsTarifarioPublico_AD.GrabarSolicitudDetalle(id, id_cab, origen, destino, producto, tipo_tarifa, tipo_visibilidad, peso, volumen, sobre, base, _
                                                         peso_minimo, flete_minimo, volumen_minimo, flete_volumen_minimo, usuario, ip, estado)

    End Sub
    Function ListarSolicitud(inicio As String, fin As String, ciudad As Integer, estado As Integer) As DataTable
        Return Ob_ClsTarifarioPublico_AD.ListarSolicitud(inicio, fin, ciudad, estado)
    End Function
    Function ListarSolicitud(id As Integer) As DataTable
        Return Ob_ClsTarifarioPublico_AD.ListarSolicitud(id)
    End Function
    Sub AnularSolicitud(id As Integer, usuario As Integer, ip As String)
        Ob_ClsTarifarioPublico_AD.AnularSolicitud(id, usuario, ip)
    End Sub
    Function ExisteTarifa(ciudad As Integer, origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer) As Boolean
        Return Ob_ClsTarifarioPublico_AD.ExisteTarifa(ciudad, origen, destino, producto, tipo_tarifa, tipo_visibilidad)
    End Function
    Sub GrabarTarifa(ciudad As Integer, origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer, _
                     peso As Double, volumen As Double, sobre As Double, base As Double, peso_minimo As Double, flete_minimo As Double, _
                     volumen_minimo As Double, flete_minimo_volumen As Double, _
                     usuario As Integer, ip As String)
        Ob_ClsTarifarioPublico_AD.GrabarTarifa(ciudad, origen, destino, producto, tipo_tarifa, tipo_visibilidad, _
                                               peso, volumen, sobre, base, peso_minimo, flete_minimo, volumen_minimo, flete_minimo_volumen, _
                                               usuario, ip)
    End Sub
    Sub AprobarSolicitud(id As Integer, observacion As String, estado As Integer, usuario As Integer, ip As String)
        Ob_ClsTarifarioPublico_AD.AprobarSolicitud(id, observacion, estado, usuario, ip)
    End Sub
End Class
