Imports INTEGRACION_AD
Public Class Cls_BuscarClienteLN
    Private lObj_ClsBuscarClienteAD As New ClsBuscarClienteAD
    ''' <summary>
    ''' REALIZA LA BUSQUEDA DEL CLIENTE, POR RAZÓN SOCIAL O RUC
    ''' </summary>
    ''' <param name="pStr_Filtro">Razon social del Cliente</param>
    ''' <param name="ruc">Ruc del Cliente</param>
    '''<returns>dataTable</returns>
    Public Function F_BuscarCliente_LN(Optional ByVal pStr_Filtro As String = "", Optional ByVal ruc As String = "", Optional usuario As Integer = 0) As DataTable
        Return lObj_ClsBuscarClienteAD.F_BuscarCliente_AD(pStr_Filtro, ruc, usuario)
    End Function
    Public Function F_BuscarClienteTodos_LN() As DataTable
        Return lObj_ClsBuscarClienteAD.F_BuscarClienteTodos_AD()
    End Function
End Class
