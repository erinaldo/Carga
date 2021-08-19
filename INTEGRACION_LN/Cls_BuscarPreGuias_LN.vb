Imports INTEGRACION_AD
Public Class Cls_BuscarPreGuias_LN

    Dim Ob_ClsPreguias_AD As New Cls_BuscarPreGuias_AD
    Public Function BuscarNroGuia_LN(ByVal v_Preguias As String) As DataTable
        Return Ob_ClsPreguias_AD.BuscarPreguias_AD(v_Preguias)
    End Function

End Class
