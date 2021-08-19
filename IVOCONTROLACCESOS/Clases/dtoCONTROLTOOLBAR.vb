Public Class dtoCONTROLTOOLBAR
#Region "VARIABLES"
    Public vControl As Integer
    Public NUEVO As Integer
    Public EDITAR As Integer
    Public GRABAR As Integer
    Public CANCELAR As Integer
    Public ELIMINAR As Integer
    Public EXPORTAR_WORK As Integer
    Public EXPORTAR_EXCEL As Integer
    Public EXPORTAR_PDF As Integer
    Public IMPRIMIR As Integer
    Public AYUDA As Integer
    Public EMAIL As Integer

    Public TAB_01 As Integer
    Public TAB_02 As Integer
    Public TAB_03 As Integer
    Public TAB_04 As Integer
    Public TAB_05 As Integer
    Public TAB_06 As Integer
    Public TAB_07 As Integer
    Public TAB_08 As Integer
    Public TAB_09 As Integer
    Public TAB_10 As Integer

#End Region
#Region "METODOS"
    Public Function GetControl() As Integer
        Return NUEVO + EDITAR + GRABAR + CANCELAR + ELIMINAR + EXPORTAR_WORK + EXPORTAR_EXCEL + EXPORTAR_PDF + IMPRIMIR + AYUDA + EMAIL
    End Function
#End Region
End Class
