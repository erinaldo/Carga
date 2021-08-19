Imports INTEGRACION_AD

Public Class Cls_Huella_LN
    Dim objCls_Huella_AD As New Cls_Huella_AD

    Function ListarParametro() As DataTable
        Return objCls_Huella_AD.ListarParametro()
    End Function

    Function ListarHuella() As DataTable
        Return objCls_Huella_AD.ListarHuella
    End Function

End Class
