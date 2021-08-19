Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_ClienteCargo_LN
    Dim objCls_ClienteCargo_AD As New Cls_ClienteCargo_AD

    Function ListarSolicitud(responsable As Integer, cliente As Integer, estado As Integer) As DataTable
        Return objCls_ClienteCargo_AD.ListarSolicitud(responsable, cliente, estado)
    End Function

    Function ListarSolicitud(estado As Integer) As DataTable
        Return objCls_ClienteCargo_AD.ListarSolicitud(estado)
    End Function

    Public Sub GrabarSolicitud(obj As Cls_ClienteCargo_EN)
        objCls_ClienteCargo_AD.GrabarSolicitud(obj)
    End Sub

    Sub AnularSolicitud(obj As Cls_ClienteCargo_EN)
        objCls_ClienteCargo_AD.Anular(obj)
    End Sub

    Function DevolucionCargo(tipo As Integer, cliente As Integer) As Integer
        Return objCls_ClienteCargo_AD.DevolucionCargo(tipo, cliente)
    End Function

    Public Sub AprobarSolicitud(obj As Cls_ClienteCargo_EN)
        objCls_ClienteCargo_AD.AprobarSolicitud(obj)
    End Sub

    Public Sub DesaprobarSolicitud(obj As Cls_ClienteCargo_EN)
        objCls_ClienteCargo_AD.DesaprobarSolicitud(obj)
    End Sub
End Class
