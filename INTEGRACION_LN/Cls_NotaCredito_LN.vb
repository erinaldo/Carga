Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_NotaCredito_LN
    Dim objNotaCreditoAD As New Cls_NotaCredito_AD

    Function ListarComprobante(tipo As Integer, comprobante As Integer) As DataSet
        Return objNotaCreditoAD.ListarComprobante(tipo, comprobante)
    End Function

    Function ListarComprobante(comprobante As Integer) As DataTable
        Return objNotaCreditoAD.ListarComprobante(comprobante)
    End Function

    Sub AnularNotaCredito(tipo As Integer, comprobante As Integer, usuario As Integer, ip As String)
        objNotaCreditoAD.AnularNotaCredito(tipo, comprobante, usuario, ip)
    End Sub

    Function ListarNotaCredito(inicio As String, fin As String, tipo As Integer, serie As String, numero As String, opcion As Integer) As DataTable
        Return objNotaCreditoAD.ListarNotaCredito(inicio, fin, tipo, serie, numero, opcion)
    End Function

    Function ListarOperacion(tipo_registro As Integer, tipo As Integer, tipo_servicio As Integer, tipo_comprobante As Integer, _
                             tipo_emision As Integer, modo As Integer, rol As Integer) As DataTable
        Return objNotaCreditoAD.ListarOperacion(tipo_registro, tipo, tipo_servicio, tipo_comprobante, tipo_emision, modo, rol)
    End Function

    Function BuscarComprobante(tipo As Integer, comprobante As String) As DataTable
        Return objNotaCreditoAD.ListarComprobante(tipo, comprobante)
    End Function

    Function GrabarNotaCredito(ByVal tipo As Integer, ByVal id_original As Integer, ByVal fecha As String, ByVal operacion As Integer, ByVal glosa As String, _
                          ByVal agencia As Integer, ByVal subtotal As Double, ByVal impuesto As Double, ByVal total As Double, _
                             ByVal usuario As Integer, ByVal ip As String, Optional ByVal cuenta_corriente As Integer = 0) As DataRow
        Return objNotaCreditoAD.GrabarNotaCredito(tipo, id_original, fecha, operacion, glosa, agencia, subtotal, impuesto, total, usuario, ip, cuenta_corriente)
    End Function

    '<<<<<<< .mine
    'sub GrabarFactura(tipo As Integer, id_original As Integer, fecha As String, glosa As String, _
    '                       cliente As Integer, tipo_documento As Integer, numero_documento As String, nombres As String, ap As String, am As String, razon_social As String, telefono As String, email As String, _
    '                       iddireccion As Integer, direccion As String, idvia As Integer, via As String, numero As String, manzana As String, lote As String, idnivel As Integer, nivel As String,
    '                       idzona As Integer, zona As String, idclasificacion As Integer, clasificacion As String, _
    '                       iddepartamento As Integer, idprovincia As Integer, iddistrito As Integer, _
    '                       agencia As Integer, subtotal As Double, impuesto As Double, total As Double, usuario As Integer, ip As String) As DataTable
    '    objNotaCreditoAD.GrabarFactura(tipo, id_original, fecha, glosa, _
    '                   cliente, tipo_documento, numero_documento, nombres, ap, am, razon_social, telefono, email, _
    '                   iddireccion, direccion, idvia, via, numero, manzana, lote, idnivel, nivel,
    '                   idzona, zona, idclasificacion, clasificacion, _
    '                   iddepartamento, idprovincia, iddistrito, _
    '                   agencia, subtotal, impuesto, total, usuario, ip)
    'End Sub
    '||||||| .r75
    '    Sub GrabarFactura(tipo As Integer, id_original As Integer, fecha As String, glosa As String, _
    '                           cliente As Integer, tipo_documento As Integer, numero_documento As String, nombres As String, ap As String, am As String, razon_social As String, telefono As String, email As String, _
    '                           iddireccion As Integer, direccion As String, idvia As Integer, via As String, numero As String, manzana As String, lote As String, idnivel As Integer, nivel As String,
    '                           idzona As Integer, zona As String, idclasificacion As Integer, clasificacion As String, _
    '                           iddepartamento As Integer, idprovincia As Integer, iddistrito As Integer, _
    '                           agencia As Integer, subtotal As Double, impuesto As Double, total As Double, usuario As Integer, ip As String)
    '        objNotaCreditoAD.GrabarFactura(tipo, id_original, fecha, glosa, _
    '                       cliente, tipo_documento, numero_documento, nombres, ap, am, razon_social, telefono, email, _
    '                       iddireccion, direccion, idvia, via, numero, manzana, lote, idnivel, nivel,
    '                       idzona, zona, idclasificacion, clasificacion, _
    '                       iddepartamento, idprovincia, iddistrito, _
    '                       agencia, subtotal, impuesto, total, usuario, ip)
    '    End Sub
    '=======
    Function GrabarFactura(tipo As Integer, id_original As Integer, fecha As String, glosa As String, _
                           cliente As Integer, tipo_documento As Integer, numero_documento As String, nombres As String, ap As String, am As String, razon_social As String, telefono As String, email As String, _
                           iddireccion As Integer, direccion As String, idvia As Integer, via As String, numero As String, manzana As String, lote As String, idnivel As Integer, nivel As String,
                           idzona As Integer, zona As String, idclasificacion As Integer, clasificacion As String, _
                           iddepartamento As Integer, idprovincia As Integer, iddistrito As Integer, referencia As String, _
                           agencia As Integer, subtotal As Double, impuesto As Double, total As Double, operacion As Integer, origen As Integer, _
                           usuario As Integer, ip As String) As DataRow

        Return objNotaCreditoAD.GrabarFactura(tipo, id_original, fecha, glosa, _
                       cliente, tipo_documento, numero_documento, nombres, ap, am, razon_social, telefono, email, _
                       iddireccion, direccion, idvia, via, numero, manzana, lote, idnivel, nivel,
                       idzona, zona, idclasificacion, clasificacion, _
                       iddepartamento, idprovincia, iddistrito, referencia, _
                       agencia, subtotal, impuesto, total, operacion, origen, usuario, ip)
    End Function

    Sub AmarrarComprobante(id As Integer, id_ref As Integer, operacion As Integer)
        objNotaCreditoAD.AmarrarComprobante(id, id_ref, operacion)
    End Sub

    Function EmiteComprobante(fecha1 As String, fecha2 As String) As Integer
        Return objNotaCreditoAD.EmiteComprobante(fecha1, fecha2)
    End Function

    Sub AnularComprobante(comprobante As Integer, usuario As Integer, ip As String)
        objNotaCreditoAD.AnularComprobante(comprobante, usuario, ip)
    End Sub

    Function BuscarComprobante(inicio As String, fin As String, origen As Integer, destino As Integer, numero As String, serie As String, _
                       numero_documento As String, cliente As String, opcion As Integer, tipo As Integer, estado As Integer) As DataTable
        Return objNotaCreditoAD.BuscarComprobante(inicio, fin, origen, destino, numero, serie, numero_documento, cliente, opcion, tipo, estado)
    End Function

    Function ListarDatosComprobante(id As Integer) As DataTable
        Return objNotaCreditoAD.ListarDatosComprobante(id)
    End Function
    Function ObtieneSaldoCuentaCorriente(ByVal numero As String) As Double
        Return objNotaCreditoAD.ObtieneSaldoCuentaCorriente(numero)
    End Function
End Class
