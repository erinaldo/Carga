Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_NotaDebito_LN
    Dim objNotaDebitoAD As New Cls_NotaDebito_AD

    Function ListarOperacion() As DataTable
        Return objNotaDebitoAD.ListarOperacion
    End Function

    Function ListarNotaDebito(ByVal inicio As String, ByVal fin As String) As DataTable
        Return objNotaDebitoAD.ListarNotaDebito(inicio, fin)
    End Function

    Function ListarComprobante(ByVal tipo As Integer, ByVal serie As String, ByVal numero As String) As DataTable
        Return objNotaDebitoAD.ListarComprobante(tipo, serie, numero)
    End Function

    Function GrabarNotaDebito(ByVal id As Integer, ByVal serie As String, ByVal numero As String, ByVal fecha As String, ByVal glosa As String, _
                              ByVal impuesto As Double, ByVal total As Double, ByVal operacion As Integer, ByVal agencia As Integer, ByVal tipo As Integer, _
                              ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer) As DataTable
        Return objNotaDebitoAD.GrabarNotaDebito(id, serie, numero, fecha, glosa, impuesto, total, operacion, agencia, tipo, usuario, ip, rol)
    End Function
End Class
