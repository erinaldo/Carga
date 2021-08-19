Option Strict On

Imports System.Collections
Imports System.Windows.Forms

Public Class ListViewColumnSortSimple
    ' Esta clase implementa la interfaz IComparer
    Implements IComparer
    '
    ' La columna por la que queremos clasificar
    Public ColumnIndex As Integer = 0
    ' El tipo de clasificaci�n a realizar
    Public Sorting As SortOrder = SortOrder.Ascending
    '
    ' Funci�n que se usar� para comparar los dos elementos
    Public Overridable Function Compare(ByVal a As Object, _
                                        ByVal b As Object) As Integer _
                                        Implements IComparer.Compare
        '
        ' Esta funci�n devolver�:
        '   -1 si el primer elemento es menor que el segundo
        '    0 si los dos son iguales
        '    1 si el primero es mayor que el segundo
        '
        Dim menor, mayor As Integer
        Dim s1, s2 As String
        '
        ' Los objetos pasados a esta funci�n ser�n del tipo ListViewItem.
        ' Convertir el texto en el formato adecuado
        ' y tomar el texto de la columna en la que se ha pulsado
        s1 = CType(a, ListViewItem).SubItems(ColumnIndex).Text
        s2 = CType(b, ListViewItem).SubItems(ColumnIndex).Text
        '
        ' Asignar cuando es menor o mayor, dependiendo del orden de clasificaci�n
        Select Case Sorting
            Case SortOrder.Ascending
                ' Esta es la forma predeterminada
                menor = -1
                mayor = 1
            Case SortOrder.Descending
                ' invertimos los valores predeterminados
                menor = 1
                mayor = -1
            Case SortOrder.None
                ' Todos los elementos se considerar�n iguales
                menor = 0
                mayor = 0
        End Select
        '
        ' Realizamos la comparaci�n y devolvemos el valor esperado
        If s1 < s2 Then
            Return menor
        ElseIf s1 = s2 Then
            Return 0
        Else
            Return mayor
        End If
    End Function
End Class
