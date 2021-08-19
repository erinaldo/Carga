Imports INTEGRACION_AD
Imports INTEGRACION_EN
Public Class Cls_Contabilidad_LN
    Dim objCls_Contabilidad_AD As New Cls_Contabilidad_AD

    Sub AnularTransferencia(ByVal id As Integer, ByVal origen As Integer)
        objCls_Contabilidad_AD.AnularTransferencia(id, origen)
    End Sub

    Sub AnularCuentaContable(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String)
        objCls_Contabilidad_AD.AnularCuentaContable(id, usuario, ip)
    End Sub

    Function ListarTipoComprobante(ByVal opcion As Integer, ByVal concepto As Integer) As DataTable
        Return objCls_Contabilidad_AD.ListarTipoComprobante(opcion, concepto)
    End Function

    Function ListarLog(ByVal comprobante As Integer) As DataTable
        Return objCls_Contabilidad_AD.ListarLog(comprobante)
    End Function

    Function ListarVenta(ByVal inicio As String, ByVal fin As String, ByVal venta As Integer, ByVal transferido As Integer) As DataTable
        Return objCls_Contabilidad_AD.ListarVenta(inicio, fin, venta, transferido)
    End Function

    Function ListarCuentaContable(ByVal venta As Integer, ByVal concepto As Integer, ByVal tipo_comprobante As Integer, ByVal tipo_afectacion As Integer, _
                              ByVal moneda As Integer) As DataTable
        Return objCls_Contabilidad_AD.ListarCuentaContable(venta, concepto, tipo_comprobante, tipo_afectacion, moneda)
    End Function

    Function ListarSubtipo(ByVal concepto As Integer, ByVal tipo As Integer) As DataTable
        Return objCls_Contabilidad_AD.ListarSubtipo(concepto, tipo)
    End Function

    Sub GrabarCuentaContable(ByVal id As Integer, ByVal venta As Integer, ByVal concepto As Integer, ByVal tipo As Integer, ByVal subtipo As Integer, _
                                 ByVal TipoAfectacion As Integer, ByVal moneda As Integer, ByVal CuentaCliente As String, ByVal CuentaImpuesto As String, _
                                 ByVal CuentaVenta As String, ByVal CuentaCosto As String, ByVal actividad As String, ByVal MovimientoCliente As Integer, _
                                 ByVal MovimientoImpuesto As Integer, ByVal MovimientoVenta As Integer, _
                                 ByVal usuario As Integer, ByVal ip As String)
        objCls_Contabilidad_AD.GrabarCuentaContable(id, venta, concepto, tipo, subtipo, TipoAfectacion, moneda, CuentaCliente, CuentaImpuesto, CuentaVenta, _
                                                    CuentaCosto, actividad, MovimientoCliente, MovimientoImpuesto, MovimientoVenta, usuario, ip)
    End Sub
End Class
