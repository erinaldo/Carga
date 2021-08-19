Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_Gasto_LN
    Dim objCls_Gasto_AD As New Cls_Gasto_AD

    Function ListarPeriodo(tipo As Integer, año As Integer) As DataTable
        Return objCls_Gasto_AD.ListarPeriodo(tipo, año)
    End Function

    Function ListarCiudadTipoPago() As DataTable
        Return objCls_Gasto_AD.ListarCiudadTipoPago
    End Function

    Function ListarCiudad(Optional opcion As Integer = 0) As DataTable
        Return objCls_Gasto_AD.ListarCiudad(opcion)
    End Function

    Function ListarAgencia() As DataTable
        Return objCls_Gasto_AD.ListarAgencia()
    End Function

    Function ListarAgencia(ciudad As Integer) As DataTable
        Return objCls_Gasto_AD.ListarAgencia(ciudad)
    End Function

    Function CalcularGasto(ciudad As Integer, fecha_inicio As String, fecha_fin As String, opcion As Integer, usuario As Integer, ip As String)
        Return objCls_Gasto_AD.CalcularGasto(ciudad, fecha_inicio, fecha_fin, opcion, usuario, ip)
    End Function

    Sub GrabarGasto(obj As Cls_Gasto_EN)
        objCls_Gasto_AD.GrabarGasto(obj)
    End Sub

    Function ListarGasto(obj As Cls_Gasto_EN) As DataTable
        Return objCls_Gasto_AD.ListarGasto(obj)
    End Function

    Function ListarGasto(id As Integer) As DataTable
        Return objCls_Gasto_AD.ListarGasto(id)
    End Function

    Sub AnularGasto(obj As Cls_Gasto_EN)
        objCls_Gasto_AD.AnularGasto(obj)
    End Sub

    Function ObtieneNumeroSolicitud() As Integer
        Return objCls_Gasto_AD.ObtieneNumeroSolicitud()
    End Function

    Function ListarHojaRuta(ByVal obj As Cls_Gasto_EN, ByVal opcion As Integer) As DataTable
        Return objCls_Gasto_AD.ListarHojaRuta(obj, opcion)
    End Function

    Function ListarReparto(obj As Cls_Gasto_EN) As DataTable
        Return objCls_Gasto_AD.ListarReparto(obj)
    End Function

    Function ObtieneTarifaGasto(ciudad As Integer, tipo As Integer) As Double
        Return objCls_Gasto_AD.ObtieneTarifaGasto(ciudad, tipo)
    End Function

    Function GrabarSolicitud(obj As Cls_Gasto_EN) As Integer
        Return objCls_Gasto_AD.GrabarSolicitud(obj)
    End Function

    Function ListarSolicitud(obj As Cls_Gasto_EN) As DataTable
        Return objCls_Gasto_AD.ListarSolicitud(obj)
    End Function

    Sub GrabarSolicitudDetalle(obj As Cls_Gasto_EN)
        objCls_Gasto_AD.GrabarSolicitudDetalle(obj)
    End Sub

    Sub AnularSolicitud(obj As Cls_Gasto_EN)
        objCls_Gasto_AD.AnularSolicitud(obj)
    End Sub

    Function ListarTipoGasto(obj As Cls_Gasto_EN)
        Return objCls_Gasto_AD.ListarTipoGasto(obj)
    End Function

    Sub AprobarSolicitud(obj As Cls_Gasto_EN)
        objCls_Gasto_AD.AprobarSolicitud(obj)
    End Sub

    Function InicioResumen() As DataSet
        Return objCls_Gasto_AD.InicioResumen()
    End Function

    Function ListarResumen(obj As Cls_Gasto_EN) As DataTable
        Return objCls_Gasto_AD.ListarResumen(obj)
    End Function

    Sub AprobarTipoGasto(obj As Cls_Gasto_EN)
        objCls_Gasto_AD.AprobarTipoGasto(obj)
    End Sub

    Function ListarTipoGasto(tipo_gasto As Integer) As DataTable
        Return objCls_Gasto_AD.ListarTipoGasto(tipo_gasto)
    End Function

    Function ListarTipoPago(opcion As Integer, Optional tipo As Integer = 0)
        Return objCls_Gasto_AD.ListarTipoPago(opcion, tipo)
    End Function

    Function ListarResponsable(obj As Cls_Gasto_EN) As DataTable
        Return objCls_Gasto_AD.ListarResponsable(obj)
    End Function

    Function ListarReparto(ciudad As Integer, fecha As String, responsable As Integer, reparto As Integer) As DataTable
        Return objCls_Gasto_AD.ListarReparto(ciudad, fecha, responsable, reparto)
    End Function

    Function ListarHojaRuta(ciudad As Integer, fecha As String, responsable As Integer) As DataTable
        Return objCls_Gasto_AD.ListarHojaRuta(ciudad, fecha, responsable)
    End Function

    Sub GrabarSolicitudTipoGasto(obj As Cls_Gasto_EN)
        objCls_Gasto_AD.GrabarSolicitudTipoGasto(obj)
    End Sub

    Function TipoGasto(ciudad As Integer) As DataTable
        Return objCls_Gasto_AD.TipoGasto(ciudad)
    End Function

    Function ListarSolicitudTipoGasto(estado As Integer) As DataTable
        Return objCls_Gasto_AD.ListarSolicitudTipoGasto(estado)
    End Function

    Function ListarSolicitudTipoGasto(ciudad As Integer, estado As Integer) As DataTable
        Return objCls_Gasto_AD.ListarSolicitudTipoGasto(ciudad, estado)
    End Function

    Sub AnularSolicitudTipogasto(obj As Cls_Gasto_EN)
        objCls_Gasto_AD.AnularSolicitudTipoGasto(obj)
    End Sub

    Sub AprobarSolicitudTipoGasto(obj As Cls_Gasto_EN)
        objCls_Gasto_AD.AprobarSolicitudTipoGasto(obj)
    End Sub

    Function ListarProveedor(ruc As String) As DataTable
        Return objCls_Gasto_AD.ListarProveedor(ruc)
    End Function

    Function ListarFactura(inicio As String, fin As String, ruc As String) As DataTable
        Return objCls_Gasto_AD.ListarFactura(inicio, fin, ruc)
    End Function

    Function ListarFactura(ByVal ciudad As Integer, ByVal inicio As String, ByVal fin As String, ByVal rol As Integer, ByVal rol2 As Integer) As DataTable
        Return objCls_Gasto_AD.ListarFactura(ciudad, inicio, fin, rol, rol2)
    End Function

    Function ListarFactura(id As Integer) As DataTable
        Return objCls_Gasto_AD.ListarFactura(id)
    End Function

    Function ListarGastoAprobado(ByVal obj As Cls_Gasto_EN, ByVal rol As Integer) As DataTable
        Return objCls_Gasto_AD.ListarGastoAprobado(obj, rol)
    End Function

    Sub GrabarTarifa(obj As Cls_Gasto_EN)
        objCls_Gasto_AD.GrabarTarifa(obj)
    End Sub

    Sub GrabarCiudadTipoPago(obj As Cls_Gasto_EN)
        objCls_Gasto_AD.GrabarCiudadTipoPago(obj)
    End Sub

    Function ListarTarifa(obj As Cls_Gasto_EN)
        Return objCls_Gasto_AD.ListarTarifa(obj)
    End Function

    Sub AnularTarifa(obj As Cls_Gasto_EN)
        objCls_Gasto_AD.AnularTarifa(obj)
    End Sub

    Sub AnularCiudadTipoPago(obj As Cls_Gasto_EN)
        objCls_Gasto_AD.AnularCiudadTipoPago(obj)
    End Sub

    Function GrabarFactura(ByVal fecha As String, ByVal serie As String, ByVal numero As String, ByVal ruc As String, ByVal razon_social As String, _
                           ByVal ciudad As Integer, ByVal agencia As Integer, ByVal concepto As String,
                           ByVal subtotal As Double, ByVal impuesto As Double, ByVal total As Double, _
                           ByVal id As Integer, ByVal solicitud As Integer, _
                           ByVal usuario As Integer, ByVal ip As String, ByVal TipoAfectacion As Integer) As Integer
        Dim intID As Integer = objCls_Gasto_AD.GrabarFactura(fecha, serie, numero, ruc, razon_social, ciudad, agencia, concepto, subtotal, impuesto, total, _
                                      id, solicitud, usuario, ip, TipoAfectacion)
        Return intID
    End Function

    Function ObtieneTipoPago(ciudad As Integer) As Integer
        Return objCls_Gasto_AD.ObtieneTipoPago(ciudad)
    End Function

    Function LiquidarFactura(id As Integer, usuario As Integer, ip As String) As Integer
        Return objCls_Gasto_AD.LiquidarFactura(id, usuario, ip)
    End Function

    Function ListarSolicitudRecojo(ByVal ciudad As Integer, ByVal estado As Integer, ByVal inicio As String, ByVal fin As String) As DataTable
        Return objCls_Gasto_AD.ListarSolicitudRecojo(ciudad, estado, inicio, fin)
    End Function

    Function ListarRecojo(id As Integer) As DataTable
        Return objCls_Gasto_AD.ListarRecojo(id)
    End Function

    Function ListarRecojoDetalle(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal formato As Integer, ByVal mixto As Integer) As DataTable
        Return objCls_Gasto_AD.ListarRecojoDetalle(id, usuario, ip, formato, mixto)
    End Function

    Function ListarRecojoDetalle(id As Integer) As DataTable
        Return objCls_Gasto_AD.ListarRecojoDetalle(id)
    End Function

    Function ListarDisponible(serie As String, numero As String, tipo As Integer) As DataTable
        Return objCls_Gasto_AD.ListarDisponible(serie, numero, tipo)
    End Function

    Sub AnularSolicitudRecojo(id As Integer, usuario As Integer, ip As String)
        objCls_Gasto_AD.AnularSolicitudRecojo(id, usuario, ip)
    End Sub

    Sub AprobarSolicitudRecojo(id As Integer, observacion As String, estado As Integer, usuario As Integer, ip As String)
        objCls_Gasto_AD.AprobarSolicitudRecojo(id, observacion, estado, usuario, ip)
    End Sub

    Function GrabarSolicitudRecojo(ByVal id As Integer, ByVal id_2 As Integer, ByVal ciudad As Integer, ByVal fecha_operacion As String, ByVal agencia As Integer, _
                              ByVal solicitante As Integer, ByVal observacion As String, ByVal monto As Double, ByVal tipo As Integer, ByVal comprobante As Integer, _
                              ByVal fecha As String, ByVal origen As Integer, ByVal destino As Integer, ByVal cliente As Integer, ByVal peso As Double, ByVal cantidad As Integer, ByVal producto As Integer, ByVal estado As Integer, _
                              ByVal proveedor As Integer, ByVal ruc As String, ByVal razon_social As String, _
                              ByVal usuario As Integer, ByVal ip As String, ByVal tipo_gasto As Integer, ByVal monto_tarifa As Double) As DataTable
        Return objCls_Gasto_AD.GrabarSolicitudRecojo(id, id_2, ciudad, fecha_operacion, agencia, solicitante, observacion, monto, _
                                                     tipo, comprobante, fecha, origen, destino, cliente, peso, cantidad, producto, estado, _
                                                     proveedor, ruc, razon_social, _
                                                     usuario, ip, tipo_gasto, monto_tarifa)
    End Function

    Function GrabarSolicitudRecojo(ByVal id As Integer, ByVal ciudad As Integer, ByVal fecha_operacion As String, ByVal agencia As Integer,
                               ByVal proveedor As Integer, ByVal ruc As String, ByVal razon_social As String, _
                               ByVal solicitante As Integer, ByVal observacion As String, ByVal monto As Double, ByVal peso As Double, ByVal cantidad As Integer, _
                               ByVal grt As Integer, ByVal estado As Integer, _
                               ByVal usuario As Integer, ByVal ip As String, ByVal tipo_gasto As Integer, ByVal monto_tarifa As Double) As DataTable
        Return objCls_Gasto_AD.GrabarSolicitudRecojo(id, ciudad, fecha_operacion, agencia, proveedor, ruc, razon_social, solicitante, _
                                                     observacion, monto, peso, cantidad, grt, estado, usuario, ip, tipo_gasto, monto_tarifa)

    End Function

    '--------------------------------------------------- ESTIBA ---------------------------------------------------
    Sub AprobarSolicitudEstiba(ByVal id As Integer, ByVal observacion As String, ByVal estado As Integer, ByVal usuario As Integer, ByVal ip As String)
        objCls_Gasto_AD.AprobarSolicitudEstiba(id, observacion, estado, usuario, ip)
    End Sub

    Sub AnularSolicitudEstiba(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String)
        objCls_Gasto_AD.AnularSolicitudEstiba(id, usuario, ip)
    End Sub

    Sub LimpiarEstiba(ByVal usuario As Integer, ByVal ip As String)
        objCls_Gasto_AD.LimpiarEstiba(usuario, ip)
    End Sub

    Function ListarEstibaDetalle(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal formato As Integer) As DataTable
        Return objCls_Gasto_AD.ListarEstibaDetalle(id, usuario, ip, formato)
    End Function

    Function ListarEstiba(ByVal ciudad As Integer, ByVal estado As Integer, ByVal inicio As String, ByVal fin As String, ByVal comprobante As String) As DataTable
        Return objCls_Gasto_AD.ListarEstiba(ciudad, estado, inicio, fin, comprobante)
    End Function

    Function ListarGrt(ByVal serie As Integer, ByVal numero As Integer, ByVal operacion As Integer, ByVal usuario As Integer, ByVal ip As String, Optional ByVal opcion As Integer = 0) As DataTable
        Return objCls_Gasto_AD.ListarGrt(serie, numero, operacion, usuario, ip, opcion)
    End Function

    Function GrabarSolicitudEstiba(ByVal id As Integer, ByVal ciudad As Integer, ByVal operacion As Integer, ByVal fecha_operacion As String, ByVal agencia As Integer,
                                   ByVal proveedor As Integer, ByVal ruc As String, ByVal razon_social As String, _
                                   ByVal solicitante As Integer, ByVal observacion As String, ByVal monto As Double, ByVal peso As Double, ByVal cantidad As Integer, _
                                   ByVal numero_estiba As Integer, ByVal hora_inicio As String, ByVal hora_fin As String, ByVal grt As Integer, ByVal estado As Integer, _
                                   ByVal usuario As Integer, ByVal ip As String) As DataTable
        Return objCls_Gasto_AD.GrabarSolicitudEstiba(id, ciudad, operacion, fecha_operacion, agencia, proveedor, ruc, razon_social, solicitante, _
                                                     observacion, monto, peso, cantidad, numero_estiba, hora_inicio, hora_fin, grt, estado, usuario, ip)
    End Function

    Function ListarGastoProveedor(ByVal ciudad As Integer, ByVal inicio As String, ByVal fin As String, ByVal concepto As Integer, ByVal estado As Integer) As DataTable
        Return objCls_Gasto_AD.ListarGastoProveedor(ciudad, inicio, fin, concepto, estado)
    End Function

    Function ListarProvision(ByVal inicio As String, ByVal fin As String, ByVal ciudad As Integer, ByVal concepto As Integer, ByVal usuario As Integer, ByVal ip As String) As DataSet
        Return objCls_Gasto_AD.ListarProvision(inicio, fin, ciudad, concepto, usuario, ip)
    End Function

    Function EstadoProvision(ByVal inicio As String) As DataTable
        Return objCls_Gasto_AD.EstadoProvision(inicio)
    End Function

    Function ConsultarProvision(ByVal inicio As String, ByVal ciudad As Integer, ByVal concepto As String) As DataTable
        Return objCls_Gasto_AD.ConsultarProvision(inicio, ciudad, concepto)
    End Function

    Function CerrarProvision(ByVal id As Integer, ByVal fecha As String, ByVal fecha_cierre As String, ByVal ciudad As Integer, _
                             ByVal proveedor As Integer, ByVal factura As String, ByVal solicitud As Integer, _
                             ByVal concepto As String, ByVal monto As Double, _
                             ByVal usuario As Integer, ByVal ip As String) As DataTable

        Return objCls_Gasto_AD.CerrarProvision(id, fecha, fecha_cierre, ciudad, proveedor, factura, solicitud, concepto, monto, usuario, ip)
    End Function

    Function InicioProvision() As DataSet
        Return objCls_Gasto_AD.InicioProvision
    End Function


    '-------------------------------------------------------------- TRASLADO -----------------------------------------------------------

    Function ListarTraslado(ByVal ciudad As Integer, ByVal estado As Integer, ByVal inicio As String, ByVal fin As String, ByVal comprobante As String) As DataTable
        Return objCls_Gasto_AD.ListarTraslado(ciudad, estado, inicio, fin, comprobante)
    End Function

    Function ListarGrtTraslado(ByVal serie As Integer, ByVal numero As Integer, ByVal usuario As Integer, ByVal ip As String, Optional ByVal opcion As Integer = 0) As DataTable
        Return objCls_Gasto_AD.ListarGrtTraslado(serie, numero, usuario, ip, opcion)
    End Function

    Function ListarTrasladoDetalle(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal formato As Integer) As DataTable
        Return objCls_Gasto_AD.ListarTrasladoDetalle(id, usuario, ip, formato)
    End Function

    Sub AprobarSolicitudTraslado(ByVal id As Integer, ByVal observacion As String, ByVal estado As Integer, ByVal usuario As Integer, ByVal ip As String)
        objCls_Gasto_AD.AprobarSolicitudTraslado(id, observacion, estado, usuario, ip)
    End Sub

    Sub AnularSolicitudTraslado(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String)
        objCls_Gasto_AD.AnularSolicitudTraslado(id, usuario, ip)
    End Sub

    Function GrabarSolicitudTraslado(ByVal id As Integer, ByVal ciudad As Integer, ByVal fecha_operacion As String, ByVal agencia As Integer,
                               ByVal proveedor As Integer, ByVal ruc As String, ByVal razon_social As String, _
                               ByVal solicitante As Integer, ByVal observacion As String, ByVal monto As Double, ByVal peso As Double, ByVal cantidad As Integer, _
                               ByVal grt As Integer, ByVal estado As Integer, _
                               ByVal usuario As Integer, ByVal ip As String) As DataTable
        Return objCls_Gasto_AD.GrabarSolicitudTraslado(id, ciudad, fecha_operacion, agencia, proveedor, ruc, razon_social, solicitante, _
                                                     observacion, monto, peso, cantidad, grt, estado, usuario, ip)
    End Function

    Function GrabarSolicitudTraslado(ByVal id As Integer, ByVal id_2 As Integer, ByVal ciudad As Integer, ByVal fecha_operacion As String, ByVal agencia As Integer, _
                               ByVal solicitante As Integer, ByVal observacion As String, ByVal monto As Double, _
                               ByVal tipo As Integer, ByVal comprobante As Integer, ByVal fecha As String, ByVal origen As Integer, ByVal destino As Integer, ByVal cliente As Integer, _
                               ByVal peso As Double, ByVal cantidad As Integer, ByVal producto As Integer, ByVal estado As Integer, _
                               ByVal proveedor As Integer, ByVal ruc As String, ByVal razon_social As String, _
                               ByVal usuario As Integer, ByVal ip As String) As DataTable
        Return objCls_Gasto_AD.GrabarSolicitudTraslado(id, id_2, ciudad, fecha_operacion, agencia, solicitante, observacion, monto, _
                                                       tipo, comprobante, fecha, origen, destino, cliente, peso, cantidad, producto, estado, _
                                                       proveedor, ruc, razon_social, usuario, ip)
    End Function

    '-------------------------------------------------PROVEEDOR---------------------------------------------------
    Function ObtieneProveedor(ByVal ciudad As Integer, ByVal operacion As Integer) As DataTable
        Return objCls_Gasto_AD.ObtieneProveedor(ciudad, operacion)
    End Function

    Function InicioProveedor() As DataTable
        Return objCls_Gasto_AD.InicioProveedor()
    End Function

    Function ListarProveedorOperacion(ByVal ciudad As Integer) As DataTable
        Return objCls_Gasto_AD.ListarProveedorOperacion(ciudad)
    End Function

    Sub GrabarProveedorOperacion(ByVal id As Integer, ByVal proveedor As Integer, ByVal ruc As String, ByVal razon_social As String, _
                                 ByVal ciudad As Integer, ByVal operacion As Integer, ByVal usuario As Integer, ByVal ip As String)
        objCls_Gasto_AD.GrabarProveedorOperacion(id, proveedor, ruc, razon_social, ciudad, operacion, usuario, ip)
    End Sub

    Function ListarGRT(ByVal id As Integer) As DataTable
        Return objCls_Gasto_AD.ListarGrt(id)
    End Function

    Function ListarDisponibleEstiba(ByVal serie As String, ByVal numero As String, ByVal tipo As Integer) As DataTable
        Return objCls_Gasto_AD.ListarDisponibleEstiba(serie, numero, tipo)
    End Function

    Function GrabarSolicitudEstiba(ByVal id As Integer, ByVal id_2 As Integer, ByVal ciudad As Integer, ByVal operacion As Integer, _
                                   ByVal hora_inicio As String, ByVal hora_fin As String, ByVal numero_estiba As Integer, _
                                   ByVal fecha_operacion As String, ByVal agencia As Integer, ByVal solicitante As Integer, ByVal observacion As String, ByVal monto As Double, _
                          ByVal tipo As Integer, ByVal comprobante As Integer, ByVal fecha As String, ByVal origen As Integer, ByVal destino As Integer, ByVal cliente As Integer, _
                          ByVal peso As Double, ByVal cantidad As Integer, ByVal producto As Integer, ByVal estado As Integer, ByVal proveedor As Integer, ByVal ruc As String, ByVal razon_social As String, _
                          ByVal usuario As Integer, ByVal ip As String) As DataTable
        Return objCls_Gasto_AD.GrabarSolicitudEstiba(id, id_2, ciudad, operacion, hora_inicio, hora_fin, numero_estiba, fecha_operacion, agencia, solicitante, observacion, monto, _
                                                     tipo, comprobante, fecha, origen, destino, cliente, peso, cantidad, producto, estado, proveedor, ruc, razon_social, _
                                                     usuario, ip)

    End Function

    Function ListarDisponibleTraslado(ByVal serie As String, ByVal numero As String, ByVal tipo As Integer) As DataTable
        Return objCls_Gasto_AD.ListarDisponibleTraslado(serie, numero, tipo)
    End Function

    Function ListarSolicitudRepartoRecojo(ByVal obj As Cls_Gasto_EN) As DataTable
        Return objCls_Gasto_AD.ListarSolicitudRepartoRecojo(obj)
    End Function

    Function ListarGrtRecojo(ByVal serie As Integer, ByVal numero As Integer, ByVal usuario As Integer, ByVal ip As String, Optional ByVal opcion As Integer = 0) As DataTable
        Return objCls_Gasto_AD.ListarGrtRecojo(serie, numero, usuario, ip, opcion)
    End Function

    Sub GrabarSolicitudCabecera(ByVal id As Integer, ByVal reparto As Integer, ByVal recojo As Integer, ByVal ciudad As Integer, _
                                     ByVal FechaOperacion As String, ByVal monto As Double, ByVal observacion As String, ByVal proveedor As Integer, _
                                     ByVal TipoGasto As Integer, ByVal peso As Double, ByVal cantidad As Integer, _
                                     ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, ByVal MontoTarifa As Double)
        objCls_Gasto_AD.GrabarSolicitudCabecera(id, reparto, recojo, ciudad, FechaOperacion, monto, observacion, proveedor, _
                                                TipoGasto, peso, cantidad, _
                                                usuario, ip, rol, MontoTarifa)
    End Sub
    Sub AnularSolicitudCabecera(ByVal id As Integer, ByVal reparto As Integer, ByVal recojo As Integer, ByVal usuario As Integer, ByVal ip As String)
        objCls_Gasto_AD.AnularSolicitudCabecera(id, reparto, recojo, usuario, ip)
    End Sub

    Function RecuperarReparto(ByVal id As Integer) As DataTable
        Return objCls_Gasto_AD.RecuperarReparto(id)
    End Function

    Sub AprobarSolicitudCabecera(ByVal obj As Cls_Gasto_EN)
        objCls_Gasto_AD.AprobarSolicitudCabecera(obj)
    End Sub

    Function ValidaRepartoRecojo(ByVal ciudad As Integer, ByVal fecha_operacion As String) As Boolean
        Return objCls_Gasto_AD.ValidaRepartoRecojo(ciudad, fecha_operacion)
    End Function

    Function ExisteComprobanteRecojo(ByVal tipo As Integer, ByVal comprobante As Integer) As Boolean
        Return objCls_Gasto_AD.ExisteComprobanteRecojo(tipo, comprobante)
    End Function
End Class
