Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_Televenta_LN
    Dim objCls_Televenta_AD As New Cls_Televenta_AD

    Function ListarUsuario() As DataTable
        Return objCls_Televenta_AD.ListarUsuario
    End Function

    Function ListarFuente() As DataTable
        Return objCls_Televenta_AD.ListarFuente
    End Function

    Function ListarFuente(usuario As Integer) As DataTable
        Return objCls_Televenta_AD.ListarFuente(usuario)
    End Function

    Function ListarConversion(inicio As String, fin As String, agente As Integer, fuente As Integer, usuario As Integer, ip As String) As DataTable
        Return objCls_Televenta_AD.ListarConversion(inicio, fin, agente, fuente, usuario, ip)
    End Function

    Function ListarCierre(inicio As String, fin As String, agente As Integer, fuente As Integer, usuario As Integer, ip As String) As DataTable
        Return objCls_Televenta_AD.ListarCierre(inicio, fin, agente, fuente, usuario, ip)
    End Function

    Function ListarLlamada(inicio As String, fin As String, agente As Integer, fuente As Integer, usuario As Integer, ip As String, opcion As Integer) As DataTable
        Return objCls_Televenta_AD.ListarLlamada(inicio, fin, agente, fuente, usuario, ip, opcion)
    End Function

    Function ListarLlamada() As DataTable
        Return objCls_Televenta_AD.ListarLlamada
    End Function

    Function ListarParametro(tipo As Integer, codigo As Integer) As DataTable
        Return objCls_Televenta_AD.ListarParametro(tipo, codigo)
    End Function

    Sub GrabarParametro(tipo As Integer, codigo As Integer, valor As Double)
        objCls_Televenta_AD.GrabarParametro(tipo, codigo, valor)
    End Sub

    Sub GrabarObjetivo(id As Integer, periodo As String, agente As Integer, valor As Double, tipo As Integer)
        objCls_Televenta_AD.GrabarObjetivo(id, periodo, agente, valor, tipo)
    End Sub

    Function ListarObjetivo() As DataTable
        Return objCls_Televenta_AD.ListarObjetivo()
    End Function

    Sub AnularObjetivo(id As Integer)
        objCls_Televenta_AD.AnularObjetivo(id)
    End Sub

    Sub ActualizarLlamada(id As Integer, dato As String)
        objCls_Televenta_AD.ActualizarLlamada(id, dato)
    End Sub
End Class
