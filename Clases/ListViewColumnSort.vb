Imports System.Windows.Forms
Imports System.Collections
Public Class ListViewColumnSort
    Implements IComparer
    '
    Public Enum TipoCompare
        Cadena
        Numero
        Fecha
    End Enum
    Public CompararPor As TipoCompare
    Public ColumnIndex As Integer = 0
    Public Sorting As SortOrder = SortOrder.Ascending
    '
    ' Constructores
    Sub New()
        ' no es necesario indicar nada,
        ' ya que impl�citamente se llama a MyBase.New
    End Sub
    Sub New(ByVal columna As Integer)
        ColumnIndex = columna
    End Sub
    '
    Public Overridable Function Compare(ByVal a As Object, _
                                        ByVal b As Object) As Integer _
                                        Implements IComparer.Compare
        '
        ' Esta funci�n devolver�:
        '   -1 si el primer elemento es menor que el segundo
        '    0 si los dos son iguales
        '    1 si el primero es mayor que el segundo
        '
        Dim menor As Integer = -1, mayor As Integer = 1
        Dim s1, s2 As String
        '
        If Sorting = SortOrder.None Then
            Return 0
        End If
        '
        ' Convertir el texto en el formato adecuado
        ' y tomar el texto de la columna en la que se ha pulsado
        s1 = DirectCast(a, ListViewItem).SubItems(ColumnIndex).Text
        s2 = DirectCast(b, ListViewItem).SubItems(ColumnIndex).Text
        '
        ' Asignar cuando es menor o mayor,
        ' dependiendo del orden de clasificaci�n
        If Sorting = SortOrder.Descending Then
            menor = 1
            mayor = -1
        End If
        '
        Select Case CompararPor
            Case TipoCompare.Fecha
                ' Si da error, se comparan como cadenas
                Try
                    Dim f1 As Date = DateTime.Parse(s1)
                    Dim f2 As Date = DateTime.Parse(s2)
                    If f1 < f2 Then
                        Return menor
                    ElseIf f1 = f2 Then
                        Return 0
                    Else
                        Return mayor
                    End If
                Catch
                    'Return s1.CompareTo(s2) * mayor
                    Return System.String.Compare(s1, s2, True) * mayor
                End Try
            Case TipoCompare.Numero
                ' Si da error, se comparan como cadenas
                Try
                    Dim n1 As Decimal = Decimal.Parse(s1)
                    Dim n2 As Decimal = Decimal.Parse(s2)
                    If n1 < n2 Then
                        Return menor
                    ElseIf n1 = n2 Then
                        Return 0
                    Else
                        Return mayor
                    End If
                Catch
                    Return System.String.Compare(s1, s2, True) * mayor
                End Try
            Case Else
                'Case TipoCompare.Cadena
                Return System.String.Compare(s1, s2, True) * mayor
        End Select
    End Function
End Class
