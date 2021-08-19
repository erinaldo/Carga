Imports INTEGRACION_AD
Imports INTEGRACION_EN
Public Class Cls_ClienteCarteraFuncionario_LN
    Dim objCls_ClienteCarteraFuncionario_AD As New Cls_ClienteCarteraFuncionario_AD

    Public Function ObtieneCliente(numero_documento As String) As DataTable
        Return objCls_ClienteCarteraFuncionario_AD.ObtieneCliente(numero_documento)
    End Function

    Public Sub GrabarSolicitud(cliente As Cls_ClienteCarteraFuncionario_EN)
        objCls_ClienteCarteraFuncionario_AD.GrabarSolicitud(cliente)
    End Sub

    Public Function ListarSolicitud(responsable As Integer, estado As Integer)
        Return objCls_ClienteCarteraFuncionario_AD.ListarSolicitud(responsable, estado)
    End Function

    Public Function ListarSolicitud(estado As Integer)
        Return objCls_ClienteCarteraFuncionario_AD.ListarSolicitud(estado)
    End Function

    Public Sub AnularSolicitud(solicitud As Cls_ClienteCarteraFuncionario_EN)
        objCls_ClienteCarteraFuncionario_AD.Anular(solicitud)
    End Sub

    Public Function ExisteSolicitud(obj As Cls_ClienteCarteraFuncionario_EN) As Boolean
        Return objCls_ClienteCarteraFuncionario_AD.ExisteSolicitud(obj)
    End Function

    Public Sub AprobarSolicitud(obj As Cls_ClienteCarteraFuncionario_EN, opcion As Integer)
        objCls_ClienteCarteraFuncionario_AD.AprobarSolicitud(obj, opcion)
    End Sub

    Public Function ListarFuncionario() As DataTable
        Return objCls_ClienteCarteraFuncionario_AD.ListarFuncionario()
    End Function

    Public Function ListarCartera(funcionario As Integer, Optional credito As Integer = 0) As DataTable
        Return objCls_ClienteCarteraFuncionario_AD.ListarCartera(funcionario, credito)
    End Function

    Public Sub TransferirCuenta(obj As Cls_ClienteCarteraFuncionario_EN)
        objCls_ClienteCarteraFuncionario_AD.TranseferirCuenta(obj)
    End Sub

    Public Sub RetirarClienteCartera(obj As Cls_ClienteCarteraFuncionario_EN, desactiva As Integer)
        objCls_ClienteCarteraFuncionario_AD.RetirarClienteCartera(obj, desactiva)
    End Sub

    Function ListarCarteraNoCorporativo(funcionario As Integer) As DataTable
        Return objCls_ClienteCarteraFuncionario_AD.ListarCarteraNoCorporativo(funcionario)
    End Function

    Function ListarTipoCartera(opcion As Integer) As DataTable
        Return objCls_ClienteCarteraFuncionario_AD.ListarTipoCartera(opcion)
    End Function

    Function ListarGC1(usuario As Integer, ip As String, inicio As String, fin As String, responsable As Integer, fecha As String, opcion As Integer) As DataTable
        Return objCls_ClienteCarteraFuncionario_AD.ListarGC1(usuario, ip, inicio, fin, responsable, fecha, opcion)
    End Function
End Class
