Imports INTEGRACION_AD
Imports INTEGRACION_EN
Public Class Cls_Contacto_LN
    Dim objCls_Contacto_AD As New Cls_Contacto_AD

    Function ListarTipo() As DataTable
        Return objCls_Contacto_AD.ListarTipo
    End Function

    Function ListarContacto(cliente As Integer, estado As Integer) As DataTable
        Return objCls_Contacto_AD.ListarContacto(cliente, estado)
    End Function

    Function ListarComunicacion(contacto As Integer) As DataTable
        Return objCls_Contacto_AD.ListarComunicacion(contacto)
    End Function

    Function ListarComunicacion() As DataTable
        Return objCls_Contacto_AD.ListarComunicacion()
    End Function

    Function Grabar(contacto As Cls_Contacto_EN) As Integer
        Return objCls_Contacto_AD.Grabar(contacto)
    End Function

    Sub GrabarComunicacion(id As Integer, numero As String, tipo As Integer, contacto As Integer, estado As Integer)
        objCls_Contacto_AD.GrabarComunicacion(id, numero, tipo, contacto, estado)
    End Sub
End Class
