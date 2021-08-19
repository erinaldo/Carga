Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_CierreProvision_LN
    Dim objCls_CierreProvision_AD As New Cls_CierreProvision_AD

    Public Sub AnularComprobante(id As Integer, tipo As Integer, comprobante As Integer, usuario As Integer, ip As String)
        objCls_CierreProvision_AD.AnularComprobante(id, tipo, comprobante, usuario, ip)
    End Sub

    Public Sub AnularProvision(id As Integer, usuario As Integer, ip As String)
        objCls_CierreProvision_AD.AnularProvision(id, usuario, ip)
    End Sub

    Function EstadoProvision(inicio As String) As DataTable
        Return objCls_CierreProvision_AD.EstadoProvision(inicio)
    End Function

    Function ConsultarProvision(id As Integer) As DataTable
        Return objCls_CierreProvision_AD.ConsultarProvision(id)
    End Function

    '-------------------------------------------------------------------------------------
    Public Sub GenerarProvision(inicio As String, fin As String, usuario As Integer, ip As String)
        objCls_CierreProvision_AD.GenerarProvision(inicio, fin, usuario, ip)

    End Sub

    Function ConsultarProvision(fecha As String, estado As Integer) As DataTable
        Return objCls_CierreProvision_AD.ConsultarProvision(fecha, estado)
    End Function

    Public Function CerrarProvision(id As Integer, fecha_cierre As String, fecha As String, agencia As Integer, usuario As Integer, ip As String) As DataTable
        Return objCls_CierreProvision_AD.CerrarProvision(id, fecha_cierre, fecha, agencia, usuario, ip)
    End Function

    Function ExportarProvision(id As Integer) As DataSet
        Return objCls_CierreProvision_AD.ExportarProvision(id)
    End Function

    Function ProvisionAbierta(fecha As String) As Integer
        Return objCls_CierreProvision_AD.ProvisionAbierta(fecha)
    End Function
End Class
