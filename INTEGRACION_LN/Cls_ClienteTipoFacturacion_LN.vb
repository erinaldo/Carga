Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_ClienteTipoFacturacion_LN
    Dim objCls_ClienteTipoFacturacion_AD As New Cls_ClienteTipoFacturacion_AD

    Function ListarTipoFacturacion(cliente As Integer) As DataTable
        Return objCls_ClienteTipoFacturacion_AD.ListarTipoFacturacion(cliente)
    End Function

    Function ListarSolicitud(responsable As Integer, cliente As Integer, estado As Integer) As DataTable
        Return objCls_ClienteTipoFacturacion_AD.ListarSolicitud(responsable, cliente, estado)
    End Function

    Function ListarSolicitud(estado As Integer) As DataTable
        Return objCls_ClienteTipoFacturacion_AD.ListarSolicitud(estado)
    End Function

    Public Function ExisteTipoFacturacion(obj As Cls_ClienteTipoFacturacion_EN) As Boolean
        Return objCls_ClienteTipoFacturacion_AD.ExisteTipoFacturacion(obj)
    End Function

    Public Function ExisteSolicitud(obj As Cls_ClienteTipoFacturacion_EN) As Boolean
        Return objCls_ClienteTipoFacturacion_AD.ExisteSolicitud(obj)
    End Function

    Public Sub GrabarSolicitud(cliente As Cls_ClienteTipoFacturacion_EN)
        objCls_ClienteTipoFacturacion_AD.GrabarSolicitud(cliente)
    End Sub

    Public Sub AnularSolicitud(solicitud As Cls_ClienteTipoFacturacion_EN)
        objCls_ClienteTipoFacturacion_AD.Anular(solicitud)
    End Sub

    Public Sub AprobarSolicitud(solicitud As Cls_ClienteTipoFacturacion_EN)
        objCls_ClienteTipoFacturacion_AD.AprobarSolicitud(solicitud)
    End Sub

    Public Sub DesaprobarSolicitud(solicitud As Cls_ClienteTipoFacturacion_EN)
        objCls_ClienteTipoFacturacion_AD.DesaprobarSolicitud(solicitud)
    End Sub

    Function ListarCargos() As DataTable
        Return objCls_ClienteTipoFacturacion_AD.ListarCargos()
    End Function

    Sub GrabarCargo(id As Integer, cliente As Integer, subcuenta As Integer, cargo As Integer, estado As Integer, usuario As Integer, ip As String)
        objCls_ClienteTipoFacturacion_AD.GrabarCargo(id, cliente, subcuenta, cargo, estado, usuario, ip)
    End Sub

    Function ListarCargos(cliente As Integer, opcion As Integer) As DataTable
        Return objCls_ClienteTipoFacturacion_AD.ListarCargos(cliente, opcion)
    End Function

    Function ListarFormaFacturacion() As DataTable
        Return objCls_ClienteTipoFacturacion_AD.ListarFormaFacturacion()
    End Function

    Function ListarClienteCargo(cliente As Integer, opcion As Integer) As DataTable
        Return objCls_ClienteTipoFacturacion_AD.ListarClienteCargo(cliente, opcion)
    End Function

    Function ListarClienteCargos(cliente As Integer) As DataTable
        Return objCls_ClienteTipoFacturacion_AD.ListarClienteCargos(cliente)
    End Function
End Class
