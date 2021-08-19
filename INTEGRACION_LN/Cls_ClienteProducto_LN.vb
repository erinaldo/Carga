Imports INTEGRACION_AD
Imports INTEGRACION_EN
Public Class Cls_ClienteProducto_LN
    Dim objCls_ClienteProducto_AD As New Cls_ClienteProducto_AD

    Function BuscarProducto(cliente As Integer, subcuenta As Integer, origen As Integer, destino As Integer, Optional contado As Integer = 0) As Integer
        Return objCls_ClienteProducto_AD.BuscarProducto(cliente, subcuenta, origen, destino, contado)
    End Function

    Function ListarProducto(cliente As Integer) As DataTable
        Return objCls_ClienteProducto_AD.ListarProducto(cliente)
    End Function

    Public Sub GrabarSolicitud(cliente As Cls_ClienteProducto_EN)
        objCls_ClienteProducto_AD.GrabarSolicitud(cliente)
    End Sub

    Function ListarSolicitud(responsable As Integer, cliente As Integer, estado As Integer) As DataTable
        Return objCls_ClienteProducto_AD.ListarSolicitud(responsable, cliente, estado)
    End Function

    Function ListarSolicitud(estado As Integer) As DataTable
        Return objCls_ClienteProducto_AD.ListarSolicitud(estado)
    End Function

    Public Sub AnularSolicitud(solicitud As Cls_ClienteProducto_EN)
        objCls_ClienteProducto_AD.Anular(solicitud)
    End Sub

    Function ValidarProducto(producto As Cls_ClienteProducto_EN) As Integer
        Return objCls_ClienteProducto_AD.ValidarProducto(producto)
    End Function

    Function CargarDatosProducto(cliente As Integer, producto As Integer) As DataTable
        Return objCls_ClienteProducto_AD.CargarDatosProducto(cliente, producto)
    End Function

    Sub DesactivarProducto(producto As Cls_ClienteProducto_EN)
        objCls_ClienteProducto_AD.DesactivarProducto(producto)
    End Sub

    Sub DesactivarProducto(producto As Cls_ClienteProducto_EN, linea As Integer, defecto As Integer)
        objCls_ClienteProducto_AD.DesactivarProducto(producto, linea, defecto)
    End Sub

    Sub AprobarSolicitud(producto As Cls_ClienteProducto_EN, actualizar As Integer)
        objCls_ClienteProducto_AD.AprobarSolicitud(producto, actualizar)
    End Sub

    Sub DesaprobarSolicitud(producto As Cls_ClienteProducto_EN)
        objCls_ClienteProducto_AD.DesaprobarSolicitud(producto)
    End Sub

    Function ListarClienteAcuerdo(cliente As Integer, producto As Integer) As DataTable
        Return objCls_ClienteProducto_AD.ListarClienteAcuerdo(cliente, producto)
    End Function

    Sub GrabarAcuerdoCliente(producto As Cls_ClienteProducto_EN, tiempo As Integer)
        objCls_ClienteProducto_AD.GrabarAcuerdoCliente(producto, tiempo)
    End Sub
    Shared Function AccedeProducto(cliente As Integer) As Boolean
        Return Cls_ClienteProducto_AD.AccedeProducto(cliente)
    End Function
End Class
