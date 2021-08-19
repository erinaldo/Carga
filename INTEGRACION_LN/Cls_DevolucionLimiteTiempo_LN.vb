Imports INTEGRACION_AD
Public Class Cls_DevolucionLimiteTiempo_LN

    Dim Ob_ClsDevolcion_AD As New Cls_DevolucionLimiteTiempo_AD
    Public Function BuscarDevolucion_LN(ByVal agencia As Integer, ByVal dias As Integer) As DataTable
        Return Ob_ClsDevolcion_AD.BuscarDevolucion_AD(agencia, dias)
    End Function
End Class


