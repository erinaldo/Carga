Imports INTEGRACION_AD
Imports INTEGRACION_EN
Public Class Cls_LineaCredito_LN
    Dim objCls_LineaCredito_AD As New Cls_LineaCredito_AD

    Function ListarCondicionCredito() As DataTable
        Return objCls_LineaCredito_AD.ListarCondicionCredito()
    End Function

    Function ListarContactoCredito(cliente As Integer, lista As String) As DataTable
        Return objCls_LineaCredito_AD.ListarContacto(cliente, lista)
    End Function

    Function ListarLineaCredito(cliente As Integer, estado As Integer) As DataTable
        Return objCls_LineaCredito_AD.ListarLineaCredito(cliente, estado)
    End Function

    Shared Function LineaCredito(cliente As Integer) As Integer
        Return Cls_LineaCredito_AD.LineaCredito(cliente)
    End Function

    Function ListarSolicitud(responsable As Integer, cliente As Integer, estado As Integer) As DataTable
        Return objCls_LineaCredito_AD.ListarSolicitud(responsable, cliente, estado)
    End Function

    Sub GrabarSolicitud(obj As Cls_LineaCredito_EN, solicitud As Integer)
        objCls_LineaCredito_AD.GrabarSolicitud(obj, solicitud)
    End Sub

    Public Sub AnularSolicitud(solicitud As Cls_LineaCredito_EN)
        objCls_LineaCredito_AD.AnularSolicitud(solicitud)
    End Sub

    Public Function ExisteSolicitud(obj As Cls_LineaCredito_EN) As Boolean
        Return objCls_LineaCredito_AD.ExisteSolicitud(obj)
    End Function

    Function ListarSolicitud(obj As Cls_LineaCredito_EN, Optional fecha1 As String = "", Optional fecha2 As String = "") As DataTable
        Return objCls_LineaCredito_AD.ListarSolicitud(obj, fecha1, fecha2)
    End Function

    Sub Preaprobar(solicitud As Integer, estado As Integer, monto As Double, usuario As Integer, ip As String, Optional observacion As String = "")
        objCls_LineaCredito_AD.Preaprobar(solicitud, estado, monto, usuario, ip, observacion)
    End Sub

    Sub Aprobar(solicitud As Integer, cliente As Integer, numero_documento As String, estado As Integer, _
                monto As Double, sobregiro As Double, total As Double, porcentaje_sobregiro As Double, _
                usuario As Integer, ip As String, Optional observacion As String = "")
        objCls_LineaCredito_AD.Aprobar(solicitud, cliente, numero_documento, estado, monto, sobregiro, total, porcentaje_sobregiro, usuario, ip, observacion)
    End Sub

    Function EstadoActual(cliente As Integer) As DataTable
        Return objCls_LineaCredito_AD.EstadoActual(cliente)
    End Function

    Function ListarClienteCredito() As DataTable
        Return objCls_LineaCredito_AD.ListarClienteCredito()
    End Function

    Sub ActivarDesactivar(id As Integer, cliente As Integer, estado As Integer, usuario As Integer, ip As String, Optional monto As Double = 0)
        objCls_LineaCredito_AD.ActivarDesactivar(id, cliente, estado, usuario, ip, monto)
    End Sub

    Public Sub AnularSolicitudCondicionCredito(solicitud As Cls_LineaCredito_EN)
        objCls_LineaCredito_AD.AnularSolicitudCondicionCredito(solicitud)
    End Sub

    Function ListarSolicitudCondicionCredito(estado As Integer) As DataTable
        Return objCls_LineaCredito_AD.ListarSolicitudCondicionCredito(estado)
    End Function


    Function ListarSolicitudCondicionCredito(responsable As Integer, cliente As Integer, estado As Integer) As DataTable
        Return objCls_LineaCredito_AD.ListarSolicitudCondicionCredito(responsable, cliente, estado)
    End Function

    Public Function ExisteSolicitudCondicionCredito(obj As Cls_LineaCredito_EN) As Boolean
        Return objCls_LineaCredito_AD.ExisteSolicitudCondicionCredito(obj)
    End Function

    Sub GrabarSolicitudCondicionCredito(obj As Cls_LineaCredito_EN)
        objCls_LineaCredito_AD.GrabarSolicitudCondicionCredito(obj)
    End Sub

    Sub AprobarSolicitudCondicionCredito(obj As Cls_LineaCredito_EN)
        objCls_LineaCredito_AD.AprobarSolicitudCondicionCredito(obj)
    End Sub

    Sub DesaprobarSolicitudCondicionCredito(obj As Cls_LineaCredito_EN)
        objCls_LineaCredito_AD.DesaprobarSolicitudCondicionCredito(obj)
    End Sub

    Function ListarLineaCreditoUltima(cliente As Integer, estado As Integer) As DataTable
        Return objCls_LineaCredito_AD.ListarLineaCreditoUltima(cliente, estado)
    End Function

    Function ListarConceptoCredito() As DataTable
        Return objCls_LineaCredito_AD.ListarConceptoCredito()
    End Function

End Class
