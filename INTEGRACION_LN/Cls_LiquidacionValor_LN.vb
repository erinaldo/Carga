Imports INTEGRACION_AD

Public Class Cls_LiquidacionValor_LN
    Dim objLiquidacionValorAD As New Cls_LiquidacionValor_AD

    Sub RetornarBolsa(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objLiquidacionValorAD.RetornarBolsa(id, usuario, ip, rol)
    End Sub

    Function ListarRemesa(ByVal inicio As String, ByVal fin As String, ByVal agencia As Integer) As DataTable
        Return objLiquidacionValorAD.ListarRemesa(inicio, fin, agencia)
    End Function

    Function ListarRemesa(ByVal inicio As String, ByVal fin As String, ByVal agencia As Integer, ByVal estado As Integer, ByVal portavalor As Integer) As DataTable
        Return objLiquidacionValorAD.ListarRemesa(inicio, fin, agencia, estado, portavalor)
    End Function

    Function ListarAgencia(Optional ByVal portavalor As Integer = 0) As DataTable
        Return objLiquidacionValorAD.ListarAgencia(portavalor)
    End Function

    Function ListarBanco() As DataTable
        Return objLiquidacionValorAD.ListarBanco()
    End Function

    Function ListarCuentaCorriente(ByVal banco As Integer) As DataTable
        Return objLiquidacionValorAD.ListarCuentaCorriente(banco)
    End Function

    Function ListarProveedor(ByVal dni As String) As DataTable
        Return objLiquidacionValorAD.ListarProveedor(dni)
    End Function

    Function ListarProveedor(Optional ByVal ciudad As Integer = 0) As DataTable
        Return objLiquidacionValorAD.ListarProveedor(ciudad)
    End Function

    Sub AnularPortavalor(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objLiquidacionValorAD.AnularPortavalor(id, usuario, ip, rol)
    End Sub

    Sub AnularRetiro(ByVal id As Integer, ByVal id_cab As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objLiquidacionValorAD.AnularRetiro(id, id_cab, usuario, ip, rol)
    End Sub

    Sub AnularRemesa(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, ByVal portavalor As Integer)
        objLiquidacionValorAD.AnularRemesa(id, usuario, ip, rol, portavalor)
    End Sub

    Sub AnularCierre(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objLiquidacionValorAD.AnularCierre(id, usuario, ip, rol)
    End Sub

    Function RetirarBolsa(ByVal codigo As String, ByVal moneda As Integer, ByVal usuario As Integer, ByVal agencia As Integer, ByVal ip As String, ByVal rol As Integer) As DataSet
        Return objLiquidacionValorAD.RetirarBolsa(codigo, moneda, usuario, agencia, ip, rol)
    End Function

    Function IngresarBolsa(ByVal codigo As String, ByVal fecha As String, ByVal agencia As Integer, _
                           ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, ByVal nivel As Integer) As DataSet
        Return objLiquidacionValorAD.IngresarBolsa(codigo, fecha, agencia, usuario, ip, rol, nivel)
    End Function

    Function ListarCierre(ByVal inicio As String, ByVal fin As String, ByVal agencia As Integer, ByVal usuario As Integer) As DataTable
        Return objLiquidacionValorAD.ListarCierre(inicio, fin, agencia, usuario)
    End Function

    Function ListarRetiro(ByVal id As Integer) As DataTable
        Return objLiquidacionValorAD.ListarRetiro(id)
    End Function

    Function ListarUsuario(ByVal inicio As String, ByVal fin As String, ByVal agencia As Integer, ByVal nivel As Integer, ByVal usuario As Integer) As DataTable
        Return objLiquidacionValorAD.ListarUsuario(inicio, fin, agencia, nivel, usuario)
    End Function

    Function ListarTipoCambio(ByVal inicio As String, ByVal fin As String) As DataTable
        Return objLiquidacionValorAD.ListarTipoCambio(inicio, fin)
    End Function

    Sub GrabarTipoCambio(ByVal id As Integer, ByVal fecha As String, ByVal monto As Double, ByVal usuario As Integer, ByVal ip As String)
        objLiquidacionValorAD.GrabarTipoCambio(id, fecha, monto, usuario, ip)
    End Sub

    Sub AnularTipoCambio(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String)
        objLiquidacionValorAD.AnularTipoCambio(id, usuario, ip)
    End Sub

    Shared Function ObtieneTipoCambio(ByVal fecha As String) As Double
        Return Cls_LiquidacionValor_AD.ObtieneTipoCambio(fecha)
    End Function

    Function ListarComprobante(ByVal agencia As Integer, ByVal fecha As String, ByVal usuario As Integer, ByVal unidad As Integer) As DataSet
        Return objLiquidacionValorAD.ListarComprobante(agencia, fecha, usuario, unidad)
    End Function

    Function ListarComprobante(ByVal id As Integer) As DataTable
        Return objLiquidacionValorAD.ListarComprobante(id)
    End Function

    Function ListarBilletes(ByVal id As Integer) As DataTable
        Return objLiquidacionValorAD.ListarBilletes(id)
    End Function

    Function ListarBillete(ByVal moneda As Integer) As DataTable
        Return objLiquidacionValorAD.ListarBillete(moneda)
    End Function

    Function ListarPortavalor(ByVal ciudad As Integer) As DataTable
        Return objLiquidacionValorAD.ListarPortavalor(ciudad)
    End Function

    Function ListarBolsa(ByVal id As Integer) As DataTable
        Return objLiquidacionValorAD.ListarBolsa(id)
    End Function

    Function CerrarCaja(ByVal fecha As String, ByVal agencia As Integer, ByVal usuario As Integer, _
                        ByVal monto As Double, ByVal TipoCambio As Double, ByVal RetiroSoles As Double, ByVal RetiroDolar As Double, _
                        ByVal ip As String, ByVal rol As Integer) As DataTable
        Return objLiquidacionValorAD.CerrarCaja(fecha, agencia, usuario, monto, TipoCambio, RetiroSoles, RetiroDolar, ip, rol)
    End Function

    Sub GrabarComprobante(ByVal id As Integer, ByVal idcomprobante As Integer, ByVal comprobante As String, ByVal tipo As String, ByVal monto As Double, ByVal unidad As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal total As Double)
        objLiquidacionValorAD.GrabarComprobante(id, idcomprobante, comprobante, tipo, monto, unidad, usuario, ip, total)
    End Sub

    Sub GrabarPortavalor(ByVal id As Integer, ByVal tipo_documento As Integer, ByVal numero_documento As String, ByVal nombres As String, _
                     ByVal ciudad As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, Optional ByVal codigo As String = "")
        objLiquidacionValorAD.GrabarPortavalor(id, tipo_documento, numero_documento, nombres, ciudad, usuario, ip, rol, codigo)
    End Sub

    Sub GrabarBillete(ByVal id As Integer, ByVal billete As Integer, ByVal cantidad As Integer, ByVal usuario As Integer, ByVal ip As String)
        objLiquidacionValorAD.GrabarBillete(id, billete, cantidad, usuario, ip)
    End Sub
    Function GrabarRemesa(ByVal id As Integer, ByVal fecha As String, ByVal agencia As Integer, ByVal moneda As Integer, ByVal monto As Double, ByVal comprobante As String, _
                          ByVal portavalor As Integer, ByVal dni As String, ByVal nombres As String, ByVal codigo As String, _
                          ByVal observacion As String, _
                         ByVal banco As Integer, ByVal cuenta_corriente As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer) As Integer
        Return objLiquidacionValorAD.GrabarRemesa(id, fecha, agencia, moneda, monto, banco, cuenta_corriente, comprobante, portavalor, dni, nombres, codigo, observacion, usuario, ip, rol)
    End Function

    Sub GrabarRemesa(ByVal id_remesa As Integer, ByVal id_preliquidacion As Integer, ByVal id_remesa_anterior As Integer, ByVal id_remesa_det_anterior As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objLiquidacionValorAD.GrabarRemesa(id_remesa, id_preliquidacion, id_remesa_anterior, id_remesa_det_anterior, usuario, ip, rol)
    End Sub

    Sub LiquidarRemesa(ByVal id As Integer, ByVal banco As Integer, ByVal cuenta_corriente As Integer, ByVal fecha_operacion As String, ByVal numero_operacion As String, _
                       ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, ByVal estado As Integer, ByVal estado_parcial As String, _
                       ByVal estado_actual As Integer, ByVal monto As Double)
        objLiquidacionValorAD.LiquidarRemesa(id, banco, cuenta_corriente, fecha_operacion, numero_operacion, usuario, ip, rol, estado, estado_parcial, estado_actual, monto)
    End Sub

    Sub LiquidarRemesa(ByVal id As Integer, ByVal id_det As Integer, ByVal id_preliq As Integer, ByVal id_preliq_det As Integer, _
                       ByVal banco As Integer, ByVal cuenta_corriente As Integer, ByVal fecha_operacion As String, ByVal numero_operacion As String, ByVal estado As Integer, _
                       ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, ByVal registro As Integer, ByVal portavalor As Integer, _
                       ByVal estado_actual As Integer)
        objLiquidacionValorAD.LiquidarRemesa(id, id_det, id_preliq, id_preliq_det, banco, cuenta_corriente, fecha_operacion, numero_operacion, estado, usuario, ip, rol, registro, portavalor, estado_actual)
    End Sub

    Sub GrabarIncidencia(ByVal remesa As Integer, ByVal remesa_det As Integer, ByVal incidencia As Integer, ByVal monto As Double, ByVal observacion As String, ByVal registro As Integer, _
                         ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objLiquidacionValorAD.GrabarIncidencia(remesa, remesa_det, incidencia, monto, observacion, registro, usuario, ip, rol)
    End Sub

    Sub GrabarParcial(ByVal remesa As Integer, ByVal remesa_det As Integer, ByVal banco As Integer, ByVal cuenta_corriente As Integer, ByVal fecha As String, ByVal numero As String, ByVal monto As Double, ByVal observacion As String, ByVal registro As Integer, _
                     ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objLiquidacionValorAD.GrabarParcial(remesa, remesa_det, banco, cuenta_corriente, fecha, numero, monto, observacion, registro, usuario, ip, rol)
    End Sub

    Function ListarIncidencia(ByVal id As Integer) As DataTable
        Return objLiquidacionValorAD.ListarIncidencia(id)
    End Function

    Function ListarParcial(ByVal id As Integer) As DataTable
        Return objLiquidacionValorAD.ListarParcial(id)
    End Function

    Function ListarEstado() As DataTable
        Return objLiquidacionValorAD.ListarEstado()
    End Function

    Function ListarSeguimiento(ByVal inicio As String, ByVal fin As String, ByVal agencia As Integer, ByVal estado As Integer, ByVal ip As String, ByVal portavalor As Integer) As DataTable
        Return objLiquidacionValorAD.ListarSeguimiento(inicio, fin, agencia, estado, ip, portavalor)
    End Function

    Function SaldoPorLiquidar(ByVal agencia As Integer) As DataTable
        Return objLiquidacionValorAD.SaldoPorLiquidar(agencia)
    End Function

    Function ObtieneSaldo(ByVal fecha As String, ByVal agencia As Integer, ByVal usuario As Integer) As Double
        Return objLiquidacionValorAD.ObtieneSaldo(fecha, agencia, usuario)
    End Function
    Function ExisteComprobante(ByVal id As Integer, ByVal unidad As Integer, ByVal opcion As Integer) As Integer
        Return objLiquidacionValorAD.ExisteComprobante(id, unidad, opcion)
    End Function
    Function ComprobanteOriginal(ByVal id As Integer, ByVal unidad As Integer) As Double
        Return objLiquidacionValorAD.ComprobanteOriginal(id, unidad)
    End Function

    Function ListarUsuarioIncidencia(ByVal inicio As String, ByVal fin As String, ByVal agencia As Integer, ByVal estado As Integer) As DataTable
        Return objLiquidacionValorAD.ListarUsuarioIncidencia(inicio, fin, agencia, estado)
    End Function

    Function ListarIncidencia(ByVal inicio As String, ByVal fin As String, ByVal agencia As Integer, ByVal usuario As Integer, _
                              ByVal estado As Integer, ByVal incidencia As Integer) As DataTable
        Return objLiquidacionValorAD.ListarIncidencia(inicio, fin, agencia, usuario, estado, incidencia)
    End Function

    Sub GrabarEstadoIncidencia(ByVal id As Integer, ByVal incidencia As Integer, ByVal remesa As Integer, ByVal fecha As String, ByVal estado As Integer, ByVal observacion As String, _
                               ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, ByVal registro As Integer, _
                               ByVal fecha_operacion As String, ByVal numero_operacion As String, ByVal banco As Integer, ByVal cuenta_corriente As Integer)
        objLiquidacionValorAD.GrabarEstadoIncidencia(id, incidencia, remesa, fecha, estado, observacion, usuario, ip, rol, registro, fecha_operacion, numero_operacion, banco, cuenta_corriente)
    End Sub

    Function ListarEstadoIncidencia(ByVal id As Integer) As DataTable
        Return objLiquidacionValorAD.ListarEstadoIncidencia(id)
    End Function

    Function ObtienePortavalorRemesa(ByVal fecha As String, ByVal agencia As Integer) As String
        Return objLiquidacionValorAD.ObtienePortavalorRemesa(fecha, agencia)
    End Function

    Function ObtieneAgenciaPortavalor(ByVal agencia As Integer) As Integer
        Return objLiquidacionValorAD.ObtieneAgenciaPortavalor(agencia)
    End Function

    Function ListarUsuarioAgencia(ByVal fecha As String, ByVal agencia As Integer) As DataTable
        Return objLiquidacionValorAD.ListarUsuarioAgencia(fecha, agencia)
    End Function

    Function ListarAgenciaOperacion(ByVal operacion As Integer) As DataTable
        Return objLiquidacionValorAD.ListarAgenciaOperacion(operacion)
    End Function

    Function ListarEficiencia(ByVal inicio As String, ByVal fin As String, ByVal agencia As Integer, ByVal usuario As Integer, ByVal opcion As Integer) As DataTable
        Return objLiquidacionValorAD.ListarEficiencia(inicio, fin, agencia, usuario, opcion)
    End Function

    Function BolsasenCofre(ByVal agencia As Integer, ByVal moneda As Integer) As Integer
        Return objLiquidacionValorAD.BolsasenCofre(agencia, moneda)
    End Function

    Function ExisteRemesa(ByVal fecha As String, ByVal agencia As Integer, ByVal moneda As Integer) As Boolean
        Return objLiquidacionValorAD.ExisteRemesa(fecha, agencia, moneda)
    End Function

    Function ListarDeposito(ByVal inicio As String, ByVal fin As String, ByVal agencia As Integer, ByVal estado As Integer, ByVal ip As String) As DataTable
        Return objLiquidacionValorAD.ListarDeposito(inicio, fin, agencia, estado, ip)
    End Function

    Function TotalDeposito(ByVal ip As String) As DataTable
        Return objLiquidacionValorAD.TotalDeposito(ip)
    End Function

    Sub AnularLiquidacionRemesa(ByVal fecha As String, ByVal agencia As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objLiquidacionValorAD.AnularLiquidacionRemesa(fecha, agencia, usuario, ip, rol)
    End Sub

    Sub AnularDeposito(ByVal fecha As String, ByVal agencia As Integer, ByVal remesa As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objLiquidacionValorAD.AnularDeposito(fecha, agencia, remesa, usuario, ip, rol)
    End Sub
End Class
