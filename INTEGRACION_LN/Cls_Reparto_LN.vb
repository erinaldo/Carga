Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_Reparto_LN
    Dim objCls_Reparto_AD As New Cls_Reparto_AD

    Function ListarCiudad() As DataTable
        Return objCls_Reparto_AD.ListarCiudad()
    End Function

    Function ListarMovil(ciudad As Integer, opcion As Integer) As DataTable
        Return objCls_Reparto_AD.ListarMovil(ciudad, opcion)
    End Function

    Function ListarProveedorMovil(ciudad As Integer, opcion As Integer)
        Return objCls_Reparto_AD.ListarProveedorMovil(ciudad, opcion)
    End Function

    Function ListarResponsable(ciudad As Integer, opcion As Integer)
        Return objCls_Reparto_AD.ListarResponsable(ciudad, opcion)
    End Function

    Function ListarDisponible(serie As String, numero As String, tipo As Integer) As DataTable
        Return objCls_Reparto_AD.ListarDisponible(serie, numero, tipo)
    End Function

    Function ListarReparto(id As Integer) As DataTable
        Return objCls_Reparto_AD.ListarReparto(id)
    End Function

    Function ListarReparto(ciudad As Integer, fecha As String, movil As Integer, responsable As Integer) As DataTable
        Return objCls_Reparto_AD.ListarReparto(ciudad, fecha, movil, responsable)
    End Function

    Function ListarHoraSalida(ciudad As Integer, fecha As String, responsable As Integer) As DataTable
        Return objCls_Reparto_AD.ListarHoraSalida(ciudad, fecha, responsable)
    End Function

    Function Grabar(id As Integer, ciudad As Integer, fecha As String, movil As Integer, responsable As Integer, hora As String, cantidad_reparto As Integer, _
               tipo As Integer, comprobante As Integer, usuario As Integer, ip As String) As Integer
        Return objCls_Reparto_AD.Grabar(id, ciudad, fecha, movil, responsable, hora, cantidad_reparto, tipo, comprobante, usuario, ip)
    End Function

    Function ListarMovil(ciudad As Integer) As DataTable
        Return objCls_Reparto_AD.ListarMovil(ciudad)
    End Function

    Sub GrabarMovil(id As Integer, ciudad As Integer, placa As String)
        objCls_Reparto_AD.GrabarMovil(id, ciudad, placa)
    End Sub
End Class
