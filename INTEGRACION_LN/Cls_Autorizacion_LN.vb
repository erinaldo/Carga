Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_Autorizacion_LN
    Dim objAutorizacionAD As New Cls_Autorizacion_AD

    Function ListarCiudad() As DataTable
        Return objAutorizacionAD.ListarCiudad
    End Function

    Function ListarAgencia(ciudad As Integer) As DataTable
        Return objAutorizacionAD.ListarAgencia(ciudad)
    End Function

    Function ListarDireccion(cliente As Integer) As DataTable
        Return objAutorizacionAD.ListarDireccion(cliente)
    End Function

    Sub AnularSolicitud(obj As Cls_Autorizacion_EN)
        objAutorizacionAD.AnularSolicitud(obj)
    End Sub

    Function ListarComprobante(id As Integer) As DataTable
        Return objAutorizacionAD.ListarComprobante(id)
    End Function

    Function ListarComprobante(comprobante As String, tipo As Integer, Optional opcion As Integer = 0) As DataTable
        Return objAutorizacionAD.BuscarComprobante(comprobante, tipo, opcion)
    End Function


    Function ListarSolicitud(ByVal ciudad As Integer, ByVal agencia As Integer, ByVal estado As Integer, ByVal opcion As Integer, _
                             ByVal rol As Integer, ByVal inicio As String, ByVal fin As String) As DataTable
        Return objAutorizacionAD.ListarSolicitud(ciudad, agencia, estado, opcion, rol, inicio, fin)
    End Function

    Function ListarOperacion(solicitud As Integer) As DataTable
        Return objAutorizacionAD.ListarOperacion(solicitud)
    End Function

    Function ListarDatos(id As Integer, operacion As Integer) As DataTable
        Return objAutorizacionAD.ListarDatos(id, operacion)
    End Function

    Function GrabarSolicitud(obj As Cls_Autorizacion_EN) As Integer
        Return objAutorizacionAD.GrabarSolicitud(obj)
    End Function

    Function GrabarSolicitudDetalle(obj As Cls_Autorizacion_EN) As Integer
        Return objAutorizacionAD.GrabarSolicitudDetalle(obj)
    End Function

    Sub GrabarDato(obj As Cls_Autorizacion_EN)
        objAutorizacionAD.GrabarDato(obj)
    End Sub

    Sub AprobarSolicitud(obj As Cls_Autorizacion_EN)
        objAutorizacionAD.AprobarSolicitud(obj)
    End Sub

    Function ListarArticulo(id As Integer, cliente As Integer, origen As Integer, destino As Integer) As DataTable
        Return objAutorizacionAD.ListarArticulo(id, cliente, origen, destino)
    End Function

    Function ListarVenta(id As Integer) As DataTable
        Return objAutorizacionAD.ListarVenta(id)
    End Function

    Function ListarTarifa(producto As Integer, origen As Integer, destino As Integer, cliente As Integer, tipo_tarifa As Integer, _
                          tipo_visibilidad As Integer, tipo_entrega As Integer) As DataTable
        Return objAutorizacionAD.ListarTarifa(producto, origen, destino, cliente, tipo_tarifa, tipo_visibilidad, tipo_entrega)
    End Function

    Function ListarFormaPago() As DataTable
        Return objAutorizacionAD.ListarFormaPago
    End Function

    Function ListarUsuario(ciudad As Integer, agencia As Integer) As DataTable
        Return objAutorizacionAD.ListarUsuario(ciudad, agencia)
    End Function

    Sub ActualizarSolicitud(ByVal id As Integer, ByVal estado As Integer)
        objAutorizacionAD.ActualizarSolicitud(id, estado)
    End Sub
End Class
