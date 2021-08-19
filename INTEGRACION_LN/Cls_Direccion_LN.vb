Imports INTEGRACION_AD
Imports INTEGRACION_EN
Public Class Cls_Direccion_LN
    Dim objCls_Direccion_AD As New Cls_Direccion_AD

    Function ListarTipo() As DataTable
        Return objCls_Direccion_AD.ListarTipo
    End Function

    Function ListarDepartamento() As DataTable
        Return objCls_Direccion_AD.ListarDepartamento
    End Function

    Function ListarProvincia(departamento As Integer) As DataTable
        Return objCls_Direccion_AD.ListarProvincia(departamento)
    End Function

    Function ListarDistrito(departamento As Integer, provincia As Integer) As DataTable
        Return objCls_Direccion_AD.ListarDistrito(departamento, provincia)
    End Function

    Function ListarVia() As DataTable
        Return objCls_Direccion_AD.ListarVia
    End Function

    Function ListarZona() As DataTable
        Return objCls_Direccion_AD.ListarZona
    End Function

    Function ListarNivel() As DataTable
        Return objCls_Direccion_AD.ListarNivel
    End Function

    Function ListarClasificacion() As DataTable
        Return objCls_Direccion_AD.ListarClasificacion
    End Function

    Function ListarContactoDireccion(direccion As Integer) As DataTable
        Return objCls_Direccion_AD.ListarContactoDireccion(direccion)
    End Function

    Function ListarDireccion(cliente As Integer, estado As Integer) As DataTable
        Return objCls_Direccion_AD.ListarDireccion(cliente, estado)
    End Function

    Function Grabar(direccion As Cls_Direccion_EN) As Integer
        Return objCls_Direccion_AD.Grabar(direccion)
    End Function

    Sub GrabarContacto(id As Integer, centro_costo As Integer, contacto As Integer, estado As Integer)
        objCls_Direccion_AD.GrabarContacto(id, centro_costo, contacto, estado)
    End Sub
End Class
