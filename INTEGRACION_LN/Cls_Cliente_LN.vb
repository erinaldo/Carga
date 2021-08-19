Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_Cliente_LN
    Dim objCls_Cliente_AD As New Cls_Cliente_AD

    Function ListarClasificacion() As DataTable
        Return objCls_Cliente_AD.ListarClasificacion
    End Function
    Function ListarDocumentoIdentidad() As DataTable
        Return objCls_Cliente_AD.ListarDocumentoIdentidad
    End Function

    Function ListarRubro() As DataTable
        Return objCls_Cliente_AD.ListarRubro
    End Function

    Function ObtieneCliente(cliente As Integer) As DataTable
        Return objCls_Cliente_AD.ObtieneCliente(cliente)
    End Function

    Function BuscarCliente(cliente As String, opcion As Integer, Optional usuario As Integer = 0) As DataTable
        Return objCls_Cliente_AD.BuscarCliente(cliente, opcion, usuario)
    End Function

    Public Sub Grabar(tipo_persona As Integer, tipo_documento As Integer, numero_documento As String, razon_social As String, _
               nombre As String, apellido_paterno As String, apellido_materno As String, usuario As Integer, ip As String)
        objCls_Cliente_AD.Grabar(tipo_persona, tipo_documento, numero_documento, razon_social, _
               nombre, apellido_paterno, apellido_materno, usuario, ip)
    End Sub

    Public Sub Grabar(cliente As Cls_Cliente_EN)
        objCls_Cliente_AD.Grabar(cliente)
    End Sub

    Function ConsultaCliente(cliente As Integer) As DataSet
        Return objCls_Cliente_AD.ConsultaCliente(cliente)
    End Function

    Function ConsultaClienteDetalle(cliente As Integer, Optional opcion As Integer = 0, Optional estado As Integer = 1, _
                                    Optional estado1 As Integer = 1, Optional estado2 As Integer = 1, Optional estado3 As Integer = 1) As DataSet
        Return objCls_Cliente_AD.ConsultaClienteDetalle(cliente, opcion, estado, estado1, estado2, estado3)
    End Function

    '-------------------------------------------------CLIENTE NO CORPORATIVO----------------------------------------------------
    Function BuscarClienteNoCorporativo(cliente As String, opcion As Integer, Optional usuario As Integer = 0) As DataTable
        Return objCls_Cliente_AD.BuscarClienteNoCorporativo(cliente, opcion, usuario)
    End Function
    Function ObtieneSituacionCliente(cliente As Integer, funcionario As Integer) As Integer
        Return objCls_Cliente_AD.ObtieneSituacionCliente(cliente, funcionario)
    End Function
    Sub AsociarCliente(cliente As Integer, producto As Integer, funcionario As Integer, usuario As Integer, ip As String)
        objCls_Cliente_AD.AsociarCliente(cliente, producto, funcionario, usuario, ip)
    End Sub
End Class
