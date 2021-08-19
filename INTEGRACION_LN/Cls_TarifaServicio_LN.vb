Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_TarifaServicio_LN
    Dim objCls_TarifaServicio_AD As New Cls_TarifaServicio_AD

    Public Function ListarUnidad() As DataTable
        Return objCls_TarifaServicio_AD.ListarUnidad()
    End Function

    Public Function ListarTarifaServicio(origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer, servicio As Integer) As DataTable
        Return objCls_TarifaServicio_AD.ListarTarifaServicio(origen, destino, producto, tipo_tarifa, tipo_visibilidad, servicio)
    End Function

    Public Function ListarTarifaServicio(tarifa As Integer) As DataSet
        Return objCls_TarifaServicio_AD.ListarTarifaServicio(tarifa)
    End Function

    Public Function GrabarTarifa(tarifa As Cls_TarifaServicio_EN) As Integer
        Return objCls_TarifaServicio_AD.Grabar(tarifa)
    End Function

    Public Sub Anular(tarifa As Cls_TarifaServicio_EN)
        objCls_TarifaServicio_AD.Anular(tarifa)
    End Sub

    Function ExisteTarifaServicio(tarifa As Cls_TarifaServicio_EN) As Boolean
        Return objCls_TarifaServicio_AD.ExisteTarifaServicio(tarifa)
    End Function

    Function ObtenerTarifaServicio(ByVal origen As Integer, ByVal destino As Integer, ByVal producto As Integer, ByVal tipo_tarifa As Integer, ByVal tipo_visibilidad As Integer, ByVal servicio As Integer, ByVal cliente As Integer, ByVal proceso As Integer) As DataTable
        Return objCls_TarifaServicio_AD.ObtenerTarifaServicio(origen, destino, producto, tipo_tarifa, tipo_visibilidad, servicio, cliente, proceso)
    End Function

    Function ObtenerMontoVenta(tipo As Integer, comprobante As Integer) As Double
        Return objCls_TarifaServicio_AD.ObtenerMontoVenta(tipo, comprobante)
    End Function
End Class
