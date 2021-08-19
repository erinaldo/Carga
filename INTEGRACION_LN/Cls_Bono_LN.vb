Imports INTEGRACION_AD
Imports INTEGRACION_EN

Public Class Cls_Bono_LN
    Dim objCls_Bono_AD As New Cls_Bono_AD

    Function ListarBono(periodo As String, ciudad As Integer) As DataTable
        Return objCls_Bono_AD.ListarBono(periodo, ciudad)
    End Function
End Class
