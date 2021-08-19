Imports INTEGRACION_AD
Imports INTEGRACION_EN
Public Class Cls_EntregaCarga_LN
    Dim objCls_EntregaCarga_AD As New Cls_EntregaCarga_AD

    Function TipoAlmacen(obj As Cls_EntregaCarga_EN) As DataTable
        Return objCls_EntregaCarga_AD.TipoAlmacen(obj)
    End Function
    Function ConfigurarAC(Optional tipo As Integer = 2, Optional codigo As Integer = 0) As DataSet
        Return objCls_EntregaCarga_AD.ConfigurarAtencionCliente(tipo, codigo)
    End Function

    Function Inicio() As DataSet
        Return objCls_EntregaCarga_AD.Inicio()
    End Function

    Function Inicio(origen As Integer, agencia_origen As Integer) As DataSet
        Return objCls_EntregaCarga_AD.Inicio(origen, agencia_origen)
    End Function

    Function ListarBultoAnaquel(obj As Cls_EntregaCarga_EN) As DataTable
        Return objCls_EntregaCarga_AD.ListarBultoAnaquel(obj)
    End Function

    Function ListarCarga(obj As Cls_EntregaCarga_EN) As DataTable
        Return objCls_EntregaCarga_AD.ListarCarga(obj)
    End Function

    Function ListarEntrega(obj As Cls_EntregaCarga_EN) As DataSet
        Return objCls_EntregaCarga_AD.ListarEntrega(obj)
    End Function

    Sub Atender(obj As Cls_EntregaCarga_EN)
        objCls_EntregaCarga_AD.Atender(obj)
    End Sub

    Function ListarAC(agencia As Integer) As DataSet
        Return objCls_EntregaCarga_AD.ListarAtencionCliente(agencia)
    End Function

    Function ListarAlmacen() As DataTable
        Return objCls_EntregaCarga_AD.ListarAlmacen()
    End Function

    Function ListarAlmacen(id As Integer) As DataTable
        Return objCls_EntregaCarga_AD.ListarAlmacen(id)
    End Function

    Function LeerBulto(codigo As String, agencia As Integer, tipo As Integer, usuario As Integer, ip As String) As DataSet
        Return objCls_EntregaCarga_AD.LeerBulto(codigo, agencia, tipo, usuario, ip)
    End Function

    Function ListarConsignado(obj As Cls_EntregaCarga_EN) As DataTable
        Return objCls_EntregaCarga_AD.ListarConsignado(obj)
    End Function

    Sub Anular(obj As Cls_EntregaCarga_EN)
        objCls_EntregaCarga_AD.Anular(obj)
    End Sub

    Function TiempoPromedioAC(fecha As String, agencia As Integer, operacion As Integer) As Double
        Return objCls_EntregaCarga_AD.TiempoPromedioAC(fecha, agencia, operacion)
    End Function

    Function CumplimientoObjetivoAC(fecha As String, agencia As Integer, operacion As Integer) As Double
        Return objCls_EntregaCarga_AD.CumplimientoObjetivoAC(fecha, agencia, operacion)
    End Function

    Function NoCumplimientoObjetivoAC(fecha As String, agencia As Integer, operacion As Integer) As Double
        Return objCls_EntregaCarga_AD.NoCumplimientoObjetivoAC(fecha, agencia, operacion)
    End Function

    Sub GrabarEntrega(obj As Cls_EntregaCarga_EN)
        objCls_EntregaCarga_AD.GrabarEntrega(obj)
    End Sub

    Function ListarPeriodo(tipo As Integer, año As Integer) As DataTable
        Return objCls_EntregaCarga_AD.ListarPeriodo(tipo, año)
    End Function

    Function ListarAgencia(Optional opcion As Integer = 0) As DataTable
        Return objCls_EntregaCarga_AD.ListarAgencia(opcion)
    End Function

    Function CalcularBono(agencia As Integer, periodo As Integer, operacion As Integer, usuario As Integer, ip As String)
        Return objCls_EntregaCarga_AD.CalcularBono(agencia, periodo, operacion, usuario, ip)
    End Function

    Sub GrabarBono(periodo As Integer, operacion As Integer, usuario As Integer, ip As String)
        objCls_EntregaCarga_AD.GrabarBono(periodo, operacion, usuario, ip)
    End Sub

    Function ListarBono(agencia As Integer, periodo As Integer, operacion As Integer) As DataTable
        Return objCls_EntregaCarga_AD.ListarBono(agencia, periodo, operacion)
    End Function

    Sub AnularBono(periodo As Integer, operacion As Integer, usuario As Integer, ip As String)
        objCls_EntregaCarga_AD.AnularBono(periodo, operacion, usuario, ip)
    End Sub

    Function ListarPantallaFormulario() As DataTable
        Return objCls_EntregaCarga_AD.ListarPantallaFormulario
    End Function

    Function ListarUsuario(obj As Cls_EntregaCarga_EN) As DataTable
        Return objCls_EntregaCarga_AD.ListarUsuario(obj)
    End Function

    Function ListarResultado(obj As Cls_EntregaCarga_EN) As DataTable
        Return objCls_EntregaCarga_AD.ListarResultado(obj)
    End Function

    Function ListarBono(operacion As Integer, opcion As Integer) As DataTable
        Return objCls_EntregaCarga_AD.ListarBono(operacion, opcion)
    End Function

    Function ExisteBono(obj As Cls_EntregaCarga_EN) As Boolean
        Return objCls_EntregaCarga_AD.ExisteBono(obj)
    End Function

    Function GrabarBono(opcion As Integer, id As Integer, operacion As Integer, inicio As Double, fin As Double, valor As Double, _
                        fecha_inicio As String) As Integer
        Return objCls_EntregaCarga_AD.GrabarBono(opcion, id, operacion, inicio, fin, valor, fecha_inicio)
    End Function

    Sub AnularBono(operacion As Integer)
        objCls_EntregaCarga_AD.AnularBono(operacion)
    End Sub

    Function ListarFormulario() As DataTable
        Return objCls_EntregaCarga_AD.ListarFormulario
    End Function

    Sub GrabarPantallaFormulario(pantalla As Integer, formulario As Integer)
        objCls_EntregaCarga_AD.GrabarPantallaFormulario(pantalla, formulario)
    End Sub

    Function ListarPantallaFormulario(pantalla As Integer) As DataTable
        Return objCls_EntregaCarga_AD.ListarPantallaFormulario(pantalla)
    End Function

    Sub EliminarFormulario(pantalla As Integer, formulario As Integer)
        objCls_EntregaCarga_AD.EliminarFormulario(pantalla, formulario)
    End Sub

    Function ListarPanelControl() As DataTable
        Return objCls_EntregaCarga_AD.ListarPanelControl()
    End Function

    Sub GrabarPanelControl(tamaño As Integer, alto As Integer, distancia As Integer, resaltado As Integer, _
                           resaltadoac As Integer, resaltadodis As Integer, filamovimiento As Integer, _
                           filainicio As Integer, col1 As Integer, col2 As Integer, col3 As Integer, col4 As Integer, col5 As Integer, _
                           filas As Integer, titulo1 As Integer, titulo2 As Integer, titulo3 As Integer, titulofila As Integer, _
                           tamañoalmacen As Integer, retardoalmacen As Integer, _
                           video As String, fuente As String)
        objCls_EntregaCarga_AD.GrabarPanelControl(tamaño, alto, distancia, resaltado, resaltadoac, resaltadodis, filamovimiento, _
                                                  filainicio, col1, col2, col3, col4, col5, _
                                                  filas, titulo1, titulo2, titulo3, titulofila, _
                                                  tamañoalmacen, retardoalmacen, video, fuente)
    End Sub

    Function ListarObjetivo(operacion As Integer, opcion As Integer) As DataTable
        Return objCls_EntregaCarga_AD.ListarObjetivo(operacion, opcion)
    End Function

    Function GrabarObjetivo(opcion As Integer, id As Integer, operacion As Integer, adicional As Double, adicional_pce As Double, _
                            inicio As Double, fin As Double, valor As Double, _
                    fecha_inicio As String) As Integer
        Return objCls_EntregaCarga_AD.GrabarObjetivo(opcion, id, operacion, adicional, adicional_pce, inicio, fin, valor, fecha_inicio)
    End Function

    Sub AnularObjetivo(operacion As Integer)
        objCls_EntregaCarga_AD.AnularObjetivo(operacion)
    End Sub

    Function ExisteObjetivo(operacion As Integer) As Boolean
        Return objCls_EntregaCarga_AD.ExisteObjetivo(operacion)
    End Function

    Sub GenerarIncidencia(tipo As Integer, comprobante As Integer, incidencia As Integer, observacion As String, usuario As Integer, ip As String)
        objCls_EntregaCarga_AD.GenerarIncidencia(tipo, comprobante, incidencia, observacion, usuario, ip)
    End Sub

    Function ListarCarga(inicio As String, fin As String, origen As Integer, destino As Integer, _
                         numero_documento As String, serie_comprobante As String, numero_comprobante As String, nombres As String, tipo As Integer) As DataTable
        Return objCls_EntregaCarga_AD.ListarCarga(inicio, fin, origen, destino, numero_documento, serie_comprobante, _
                                                  numero_comprobante, nombres, tipo)
    End Function

    Sub GrabarEntrega(tipo As Integer, comprobante As Integer, fecha_entrega As String, hora_entrega As String, _
                      nombre As String, numero As String, usuario As Integer, ip As String)
        objCls_EntregaCarga_AD.GrabarEntrega(tipo, comprobante, fecha_entrega, hora_entrega, nombre, numero, usuario, ip)
    End Sub

    Function ListarEntrega(agencia As Integer, inicio As String, fin As String, problema As Integer, huella As Integer, tipo As Integer) As DataTable
        Return objCls_EntregaCarga_AD.ListarEntrega(agencia, inicio, fin, problema, huella, tipo)
    End Function
    Function ListarEntregaDomicilio(agencia As Integer, inicio As String, fin As String, movil As Integer, tipo As Integer) As DataTable
        Return objCls_EntregaCarga_AD.ListarEntregaDomicilio(agencia, inicio, fin, movil, tipo)
    End Function
End Class
