Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_DevolucionCargo_LN
    Dim objCls_DevolucionCargo_AD As New Cls_DevolucionCargo_AD

    Function Inicio() As DataSet
        Return objCls_DevolucionCargo_AD.Inicio
    End Function

    Function ListarCargo(tipo As Integer, comprobante As Integer) As DataTable
        Return objCls_DevolucionCargo_AD.ListarCargo(tipo, comprobante)
    End Function

    Function ListarCarga(serie As Integer, numero As Integer, usuario As Integer, ip As String) As DataTable
        Return objCls_DevolucionCargo_AD.ListarCarga(serie, numero, usuario, ip)
    End Function

    Function ListarCarga(inicio As String, fin As String, origen As Integer, destino As Integer, _
                         numero_documento As String, serie_comprobante As String, numero_comprobante As String, nombres As String) As DataTable
        Return objCls_DevolucionCargo_AD.ListarCarga(inicio, fin, origen, destino, numero_documento, serie_comprobante, _
                                                  numero_comprobante, nombres)
    End Function

    Sub AnularCargo(tipo As Integer, comprobante As Integer, serie As String, numero As String, usuario As Integer, ip As String)
        objCls_DevolucionCargo_AD.AnularCargo(tipo, comprobante, serie, numero, usuario, ip)
    End Sub

    Sub GrabarCargo(id As Integer, tipo As Integer, comprobante As Integer, serie As String, numero As String, cliente As Integer, usuario As Integer, ip As String)
        objCls_DevolucionCargo_AD.GrabarCargo(id, tipo, comprobante, serie, numero, cliente, usuario, ip)
    End Sub
End Class
