Module ModAcceso
    Structure sLista
        Dim form As String
        Dim id As Long
    End Structure
    Public Const G_Mje As String = "No tiene acceso."
    Public G_Fila As Integer
    Public G_lista(20, 20) As sLista
    Public G_Rol As Integer = 1
    '19/05/2010  
    Public G_Rol_descripcion As String
    '31/05/2010
    'Public FrmActivo As Form
    Public Hnd As Long

    Public gStr_Origen As Integer

End Module
