Imports System.Linq
Enum Operacion
    Nuevo = 1
    Modificar = 2
End Enum
Enum Estado
    Pendiente = 1
    Aprobado = 2
    Desaprobado = 3
    Anulado = 4
End Enum
Enum TabGestionCliente
    FichaCliente = 1
    GestionCartera = 2
    AsignarProducto = 4
End Enum
Enum TabGestionCartera
    Solicitud = 1
    Lista = 2
    Aprobacion = 3
    Transferencia = 4
End Enum
Enum TabAsignarProducto
    Cliente = 1
    Solicitud = 2
    Aprobacion = 3
End Enum
Enum TipoGasto
    Peso = 1
    Hora = 2
    Dia = 3
    Adicional = 10
End Enum

Module Modulo
    Function ObtenerListaCheck(ByVal dgv As DataGridView, ByVal col As String) As List(Of DataGridViewRow)
        Return (From Rows In dgv.Rows.Cast(Of DataGridViewRow)() _
                Where CBool(Rows.Cells(col).Value) = True).ToList
    End Function
End Module
