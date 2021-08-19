Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_FacturaAdicional_LN
    Dim objFacturaAdicionalAD As New Cls_FacturaAdicional_AD

    Function ListarTipoTarjeta() As DataTable
        Return objFacturaAdicionalAD.ListarTipoTarjeta
    End Function

    Function ListarFacturaAdicional(id As Integer) As DataTable
        Return objFacturaAdicionalAD.ListarFacturaAdicional(id)
    End Function

    Function ListarSolicitud(tipo As Integer, comprobante As Integer, estado As Integer, facturado As Integer, Optional solicitud As Integer = 0) As DataTable
        Return objFacturaAdicionalAD.ListarSolicitud(tipo, comprobante, estado, facturado, solicitud)
    End Function

    Function BuscarComprobante(inicio As String, fin As String, origen As Integer, destino As Integer, numero As String, serie As String, _
                               numero_documento As String, cliente As String, opcion As Integer, tipo As Integer, facturado As Integer) As DataTable
        Return objFacturaAdicionalAD.BuscarComprobante(inicio, fin, origen, destino, numero, serie, numero_documento, cliente, opcion, tipo, facturado)
    End Function

    Function BuscarCliente(numero_documento As String) As DataTable
        Return objFacturaAdicionalAD.BuscarCliente(numero_documento)
    End Function

    Function GrabarFactura(ByVal tipo As Integer, ByVal id_original As Integer, _
                       ByVal cliente As Integer, ByVal tipo_documento As Integer, ByVal numero_documento As String, ByVal nombres As String, ByVal ap As String, ByVal am As String, ByVal razon_social As String, ByVal telefono As String, ByVal email As String, _
                       ByVal iddireccion As Integer, ByVal direccion As String, ByVal idvia As Integer, ByVal via As String, ByVal numero As String, ByVal manzana As String, ByVal lote As String, ByVal idnivel As Integer, ByVal nivel As String,
                       ByVal idzona As Integer, ByVal zona As String, ByVal idclasificacion As Integer, ByVal clasificacion As String, _
                       ByVal iddepartamento As Integer, ByVal idprovincia As Integer, ByVal iddistrito As Integer, _
                       ByVal agencia As Integer, ByVal forma_pago As Integer, ByVal tipo_tarjeta As Integer, ByVal tarjeta As String, _
                       ByVal subtotal As Double, ByVal impuesto As Double, ByVal total As Double, _
                       ByVal domicilio As Double, ByVal cargo As Double, ByVal fz As Double, _
                       ByVal usuario As Integer, ByVal ip As String, ByVal solicitud As Integer)

        Return objFacturaAdicionalAD.GrabarFactura(tipo, id_original, _
                       cliente, tipo_documento, numero_documento, nombres, ap, am, razon_social, telefono, email, _
                       iddireccion, direccion, idvia, via, numero, manzana, lote, idnivel, nivel,
                       idzona, zona, idclasificacion, clasificacion, _
                       iddepartamento, idprovincia, iddistrito, _
                       agencia, forma_pago, tipo_tarjeta, tarjeta, _
                       subtotal, impuesto, total, _
                       domicilio, cargo, fz, _
                       usuario, ip, solicitud)
    End Function
    Function ComprobanteOperacion(comprobante As Integer) As String
        Return objFacturaAdicionalAD.ComprobanteOperacion(comprobante)
    End Function
End Class
