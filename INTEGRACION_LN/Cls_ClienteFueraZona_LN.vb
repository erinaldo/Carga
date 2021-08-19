Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_ClienteFueraZona_LN
    Dim objCls_ClienteFueraZona_AD As New Cls_ClienteFueraZona_AD

    Function ListarSolicitud(estado As Integer) As DataTable
        Return objCls_ClienteFueraZona_AD.ListarSolicitud(estado)
    End Function

    Function ListarSolicitud(responsable As Integer, cliente As Integer, estado As Integer) As DataTable
        Return objCls_ClienteFueraZona_AD.ListarSolicitud(responsable, cliente, estado)
    End Function

    Function ListarGuiaEnvio(id As Integer) As DataTable
        Return objCls_ClienteFueraZona_AD.ListarGuiaEnvio(id)
    End Function

    Function BuscarGuiaEnvio(guia As Integer) As DataTable
        Return objCls_ClienteFueraZona_AD.BuscarGuiaEnvio(guia)
    End Function

    Function ExisteSolicitud(obj As Cls_ClienteFueraZona_EN) As Boolean
        Return objCls_ClienteFueraZona_AD.ExisteSolicitud(obj)
    End Function

    Sub Anular(obj As Cls_ClienteFueraZona_EN)
        objCls_ClienteFueraZona_AD.Anular(obj)
    End Sub

    Sub DesaprobarSolicitud(obj As Cls_ClienteFueraZona_EN)
        objCls_ClienteFueraZona_AD.DesaprobarSolicitud(obj)
    End Sub
    Sub AprobarSolicitud(obj As Cls_ClienteFueraZona_EN)
        objCls_ClienteFueraZona_AD.AprobarSolicitud(obj)
    End Sub

    Function GrabarSolicitud(ByVal obj As Cls_ClienteFueraZona_EN) As Integer
        Return objCls_ClienteFueraZona_AD.GrabarSolicitud(obj)
    End Function

    Sub GrabarGuiaEnvio(id As Integer, idfz As Integer, ge As Integer, estado As Integer, origen As String, destino As String, _
                        total_costo As Double, guia As String, agencia_origen As Integer, agencia_destino As Integer, usuario As Integer, ip As String)
        objCls_ClienteFueraZona_AD.GrabarGuiaEnvio(id, idfz, ge, estado, origen, destino, total_costo, guia, agencia_origen, agencia_destino, usuario, ip)
    End Sub
End Class
