Imports INTEGRACION_AD
Public Class Cls_HoraExtra_LN
    Dim objCls_HoraExtra_AD As New Cls_HoraExtra_AD

    Shared Function TipoDia(ByVal codigo As String, ByVal fecha As String) As Integer
        Return Cls_HoraExtra_AD.TipoDia(codigo, fecha)
    End Function

    Shared Function ValorHE(ByVal hora As String) As Double
        Return Cls_HoraExtra_AD.ValorHE(hora)
    End Function

    Shared Function ValorCadena(ByVal hora As Double) As String
        Return Cls_HoraExtra_AD.ValorCadena(hora)
    End Function

    Function ListarAsistencia(ByVal fecha As String, ByVal codigo As String) As DataTable
        Return objCls_HoraExtra_AD.ListarAsistencia(fecha, codigo)
    End Function

    Function ListarHorario(ByVal horario As String, ByVal codigo As String) As DataTable
        Return objCls_HoraExtra_AD.ListarHorario(horario, codigo)
    End Function

    Function ListarHorario(ByVal trabajador As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarHorario(trabajador)
    End Function

    Function ListarTrabajador(ByVal codigo As String) As DataTable
        Return objCls_HoraExtra_AD.ListarTrabajador(codigo)
    End Function

    Function ListarTrabajador(ByVal area As Integer, ByVal inicio As String, ByVal fin As String, ByVal estado As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarTrabajador(area, inicio, fin, estado)
    End Function

    Function ListarTrabajadorSolicitud(ByVal area As Integer, ByVal inicio As String, ByVal fin As String, ByVal estado As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarTrabajadorSolicitud(area, inicio, fin, estado)
    End Function

    Function ListarTrabajador(ByVal usuario As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarTrabajador(usuario)
    End Function

    Function EsFeriado(ByVal fecha As String) As Boolean
        Return objCls_HoraExtra_AD.EsFeriado(fecha)
    End Function

    Function EsVacaciones(ByVal periodo As String, ByVal codigo As String) As Boolean
        Return objCls_HoraExtra_AD.EsVacaciones(periodo, codigo)
    End Function

    Function GrabarTrabajador(ByVal codigo As String, ByVal nombres As String, ByVal cargo As String, ByVal centro_costo As String, ByVal area As String, ByVal remuneracion As Double, _
                              ByVal horario As String, ByVal situacion As String, ByVal cap As Integer, ByVal fecha_ingreso As String, _
                              ByVal tipo_via As String, ByVal via As String, ByVal numero As String, ByVal interior As String, ByVal tipo_zona As String, ByVal zona As String, _
                              ByVal direccion As String, ByVal numero_documento As String) As DataTable
        Return objCls_HoraExtra_AD.GrabarTrabajador(codigo, nombres, cargo, centro_costo, area, remuneracion, horario, situacion, cap, fecha_ingreso, _
                                                    tipo_via, via, numero, interior, tipo_zona, zona, direccion, numero_documento)
    End Function

    Sub GrabarAsistencia(ByVal planilla As String, ByVal fecha As String, ByVal codigo As String, ByVal concepto As String, ByVal valor As Double, ByVal glosa As String, ByVal registro As Integer)
        objCls_HoraExtra_AD.GrabarAsistencia(planilla, fecha, codigo, concepto, valor, glosa, registro)
    End Sub

    Sub GrabarFeriado(ByVal fecha As String, ByVal descripcion As String, ByVal estado As String)
        objCls_HoraExtra_AD.GrabarFeriado(fecha, descripcion, estado)
    End Sub

    Sub GrabarVacaciones(ByVal codigo As String, ByVal inicio As String, ByVal fin As String, ByVal periodo As String, ByVal registro As Integer)
        objCls_HoraExtra_AD.GrabarVacaciones(codigo, inicio, fin, periodo, registro)
    End Sub

    Sub GrabarTrabajadorHorario(ByVal trabajador As Integer, ByVal horario As Integer, ByVal inicio As String, ByVal fin As String, ByVal descanso As Integer, ByVal dia As Integer)
        objCls_HoraExtra_AD.GrabarTrabajadorHorario(trabajador, horario, inicio, fin, descanso, dia)
    End Sub

    Sub GrabarTrabajadorHorario(ByVal trabajador As Integer, ByVal horario As Integer)
        objCls_HoraExtra_AD.GrabarTrabajadorHorario(trabajador, horario)
    End Sub

    Function GrabarHorario(ByVal codigo As String, ByVal inilun As String, ByVal finlun As String, ByVal lun As Integer, _
                           ByVal inimar As String, ByVal finmar As String, ByVal mar As Integer,
                           ByVal inimie As String, ByVal finmie As String, ByVal mie As Integer,
                           ByVal inijue As String, ByVal finjue As String, ByVal jue As Integer,
                           ByVal inivie As String, ByVal finvie As String, ByVal vie As Integer,
                           ByVal inisab As String, ByVal finsab As String, ByVal sab As Integer,
                           ByVal inidom As String, ByVal findom As String, ByVal dom As Integer) As Integer
        Return objCls_HoraExtra_AD.GrabarHorario(codigo, inilun, finlun, lun, inimar, finmar, mar, inimie, finmie, mie, _
        inijue, finjue, jue, inivie, finvie, vie, inisab, finsab, sab, inidom, findom, dom)

    End Function

    Function ValidarPlanificacion(ByVal area As Integer, ByVal inicio As String, ByVal fin As String) As Boolean
        Return objCls_HoraExtra_AD.ValidarPlanificacion(area, inicio, fin)
    End Function

    Sub AnularPlanificacion(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objCls_HoraExtra_AD.AnularPlanificacion(id, usuario, ip, rol)
    End Sub

    Function GrabarPlanificacion(ByVal id As Integer, ByVal inicio As String, ByVal fin As String, ByVal area As Integer, ByVal usuario As Integer, _
                    ByVal horas As String, ByVal costo As Double, ByVal ip As String, ByVal rol As Integer) As Integer
        Return objCls_HoraExtra_AD.GrabarPlanificacion(id, inicio, fin, area, usuario, horas, costo, ip, rol)
    End Function

    Function GrabarPlanificacionDetalle(ByVal id As Integer, ByVal codigo As String, ByVal nombres As String, ByVal cargo As String, ByVal centro_costo As String, _
                                   ByVal remuneracion As Double, ByVal horario As Integer, ByVal horas As String, ByVal costo As Double) As Integer
        Return objCls_HoraExtra_AD.GrabarPlanificacionDetalle(id, codigo, nombres, cargo, centro_costo, remuneracion, horario, horas, costo)
    End Function

    Sub GrabarPlanificacionDetalle2(ByVal id As Integer, ByVal id_det As Integer, ByVal fecha As String, ByVal hora_inicio As String, ByVal hora_fin As String, _
                                    ByVal tipo_dia As Integer, ByVal motivo As Integer, ByVal compensacion As Integer, ByVal actividad As String, _
                                    ByVal horas As String, ByVal costo As Double, ByVal ingreso As String, ByVal salida As String, _
                                    ByVal horas25 As String, ByVal costo25 As Double, ByVal horas35 As String, ByVal costo35 As Double, _
                                    ByVal horas100 As String, ByVal costo100 As Double, ByVal estado As Integer)
        objCls_HoraExtra_AD.GrabarPlanificacionDetalle2(id, id_det, fecha, hora_inicio, hora_fin, tipo_dia, motivo, compensacion, actividad, _
                                                        horas, costo, ingreso, salida, horas25, costo25, horas35, costo35, horas100, costo100, estado)
    End Sub

    Function ListarPlanificacionCab(ByVal inicio As String, ByVal fin As String, ByVal usuario As Integer, ByVal estado As Integer, ByVal opcion As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarPlanificacionCab(inicio, fin, usuario, estado, opcion)
    End Function

    Function ListarPlanificacion(ByVal inicio As String, ByVal fin As String, ByVal area As Integer, ByVal estado As Integer, ByVal opcion As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarPlanificacion(inicio, fin, area, estado, opcion)
    End Function

    Function ListarPlanificacion(ByVal id As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarPlanificacion(id)
    End Function

    Function ListarPlanificacionDetalle(ByVal id As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarPlanificacionDetalle(id)
    End Function

    Function ListarPlanificacionDetalle2(ByVal id As Integer, Optional ByVal estado As Integer = 0) As DataTable
        Return objCls_HoraExtra_AD.ListarPlanificacionDetalle2(id, estado)
    End Function

    '--------------------------------------------------------------------------------------------------------------------------------------------------------
    Sub AnularSolicitud(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, ByVal perfil As Integer, ByVal estado As Integer, ByVal opcion As Integer)
        objCls_HoraExtra_AD.AnularSolicitud(id, usuario, ip, rol, perfil, estado, opcion)
    End Sub

    Function ListarSolicitud(ByVal inicio As String, ByVal fin As String, ByVal estado As Integer, ByVal usuario As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarSolicitud(inicio, fin, estado, usuario)
    End Function

    Function ListarSolicitud(ByVal inicio As String, ByVal fin As String, ByVal codigo As String, ByVal estado As Integer, ByVal area As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarSolicitud(inicio, fin, codigo, estado, area)
    End Function

    Function ListarSolicitud(ByVal id As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarSolicitud(id)
    End Function

    Function GrabarSolicitud(ByVal id As Integer, ByVal codigo As String, ByVal nombres As String, ByVal cargo As String, ByVal centro_costo As String, ByVal area As String, _
                            ByVal fecha As String, ByVal ingreso As String, ByVal salida As String, ByVal IngresoAsistencia As String, _
                            ByVal SalidaAsistencia As String, ByVal horario As String, ByVal remuneracion As Double, _
                            ByVal horas As String, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, ByVal agencia As Integer, ByVal marcador As Integer) As Integer
        Return objCls_HoraExtra_AD.GrabarSolicitud(id, codigo, nombres, cargo, centro_costo, area, fecha, ingreso, salida, IngresoAsistencia, _
                                                   SalidaAsistencia, horario, remuneracion, _
                                                   horas, usuario, ip, rol, agencia, marcador)
    End Function

    Sub GrabarSolicitudDetalle(ByVal id As Integer, ByVal hora_inicio As String, ByVal hora_fin As String, ByVal horas As String, ByVal actividad As String)
        objCls_HoraExtra_AD.GrabarSolicitudDetalle(id, hora_inicio, hora_fin, horas, actividad)
    End Sub

    Sub AutorizarSolicitud(ByVal id As Integer, ByVal estado As Integer, ByVal observacion As String, _
                           ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, _
                           ByVal costo As Double, ByVal HorasEfectivo As String, ByVal tipo_dia As Integer, ByVal tipo_compensacion As Integer)
        objCls_HoraExtra_AD.AutorizarSolicitud(id, estado, observacion, usuario, ip, rol, costo, HorasEfectivo, tipo_dia, tipo_compensacion)
    End Sub

    Sub AprobarSolicitud(ByVal id As Integer, ByVal estado As Integer, ByVal observacion As String, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objCls_HoraExtra_AD.AprobarSolicitud(id, estado, observacion, usuario, ip, rol)
    End Sub

    Sub AprobarSolicitudPlan(ByVal id As Integer, ByVal estado As Integer, ByVal observacion As String, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objCls_HoraExtra_AD.AprobarSolicitudPlan(id, estado, observacion, usuario, ip, rol)
    End Sub

    Sub AprobarSolicitudPlanDet(ByVal id As Integer, ByVal id_det As Integer, ByVal fecha As String, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objCls_HoraExtra_AD.AprobarSolicitudPlanDet(id, id_det, fecha, usuario, ip, rol)
    End Sub

    Sub DesaprobarPlanDet(ByVal id As Integer, ByVal id_det As Integer, ByVal fecha As String, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, ByVal motivo As String)
        objCls_HoraExtra_AD.DesaprobarSolicitudPlanDet(id, id_det, fecha, usuario, ip, rol, motivo)
    End Sub

    Function ListarPlanReal(ByVal inicio As String, ByVal fin As String) As DataTable
        Return objCls_HoraExtra_AD.ListarPlanReal(inicio, fin)
    End Function

    Sub GrabarHECompensada(ByVal codigo As String, ByVal fecha As String, ByVal horas As String, ByVal nombres As String, ByVal solicitud As Integer, _
                           ByVal tipo_compensacion As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objCls_HoraExtra_AD.GrabarHECompensada(codigo, fecha, horas, nombres, solicitud, tipo_compensacion, usuario, ip, rol)
    End Sub

    Function ListarHECompensada(ByVal estado As Integer, ByVal usuario As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarHECompensada(estado, usuario)
    End Function

    Function ListarHECompensada(ByVal codigo As String) As DataTable
        Return objCls_HoraExtra_AD.ListarHECompensada(codigo)
    End Function

    Function ListarHECompensada(ByVal id As Integer, ByVal inicio As String, ByVal fin As String, ByVal estado As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarHECompensada(id, inicio, fin, estado)
    End Function

    Function ListarHECompensada(ByVal codigo As String, ByVal fecha As String) As DataTable
        Return objCls_HoraExtra_AD.ListarHECompensada(codigo, fecha)
    End Function

    Function ListarPlanAprobacion(ByVal id As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarPlanAprobacion(id)
    End Function

    Function ListarHECompensadaDet(ByVal id As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarHECompensadaDet(id)
    End Function

    Function ListarHECompensadaDet(ByVal inicio As String, ByVal fin As String, ByVal codigo As String, ByVal estado As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarHECompensadaDet(inicio, fin, codigo, estado)
    End Function

    Function ListarHECompensadaDet(ByVal id As Integer, ByVal id_det As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarHECompensadaDet(id, id_det)
    End Function

    Shared Sub GrabarHECompensada(ByVal codigo As String, ByVal horas As String)
        Cls_HoraExtra_AD.GrabarHECompensada(codigo, horas)
    End Sub

    Sub GrabarHECompensada(ByVal id As Integer, ByVal id_det As Integer, ByVal fecha As String, ByVal tipo_compensacion As Integer, ByVal horas As String, _
                           ByVal observacion As String, ByVal horas_compensadas As String, ByVal saldo As String, ByVal registro As Integer, ByVal estado As Integer, _
                           ByVal UsuarioAceptacion As Integer, ByVal FechaAceptacion As String, ByVal IpAceptacion As String, ByVal RolAceptacion As Integer, _
                           ByVal UsuarioEnvio As Integer, ByVal FechaEnvio As String, ByVal IpEnvio As String)
        objCls_HoraExtra_AD.GrabarHECompensada(id, id_det, fecha, tipo_compensacion, horas, observacion, horas_compensadas, saldo, registro, estado, _
                                               UsuarioAceptacion, FechaAceptacion, IpAceptacion, RolAceptacion, _
                                               UsuarioEnvio, FechaEnvio, IpEnvio)
    End Sub

    Sub AceptarCompensacion(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objCls_HoraExtra_AD.AceptarCompensacion(id, usuario, ip, rol)
    End Sub

    Function ListarCompensado(ByVal tipo As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarCompensado(tipo)
    End Function

    Sub CerrarPlanificacion(ByVal id As Integer, ByVal cerrado As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objCls_HoraExtra_AD.CerrarPlanificacion(id, cerrado, usuario, ip, rol)
    End Sub

    Shared Sub ActualizarCompensado(ByVal tipo As Integer, ByVal periodo As String)
        Cls_HoraExtra_AD.ActualizarCompensado(tipo, periodo)
    End Sub

    Shared Function TieneAsistencia(ByVal fecha As String) As Boolean
        Return Cls_HoraExtra_AD.TieneAsistencia(fecha)
    End Function

    Function ListarArea(ByVal usuario As Integer, ByVal perfil As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarArea(usuario, perfil)
    End Function

    Function ListarConvenio(ByVal id As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarConvenio(id)
    End Function

    Function ListarUsuarioArea() As DataTable
        Return objCls_HoraExtra_AD.ListarUsuarioArea()
    End Function

    Function ListarUsuarioArea(ByVal cap As Integer, ByVal nivel As Integer, ByVal id As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarUsuarioArea(cap, nivel, id)
    End Function

    Function ListarAreaTrabajador(ByVal nivel As Integer, ByVal padre As Integer, ByVal abuelo As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarAreaTrabajador(nivel, padre, abuelo)
    End Function

    Sub GrabarAreaTrabajador(ByVal codigo As String, ByVal area As Integer)
        objCls_HoraExtra_AD.GrabarAreaTrabajador(codigo, area)
    End Sub

    Function ListarHHEE(ByVal inicio As String, ByVal fin As String, ByVal area As Integer, ByVal codigo As String, ByVal usuario As Integer, ByVal perfil As Integer, ByVal estado As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarHHEE(inicio, fin, area, codigo, usuario, perfil, estado)
    End Function

    Function ListarHHEESolicitud(ByVal inicio As String, ByVal fin As String, ByVal area As Integer, ByVal codigo As String, ByVal usuario As Integer, ByVal perfil As Integer, ByVal estado As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarHHEESolicitud(inicio, fin, area, codigo, usuario, perfil, estado)
    End Function

    Sub GrabarObrero(ByVal codigo As String, ByVal obrero As Integer)
        objCls_HoraExtra_AD.GrabarObrero(codigo, obrero)
    End Sub

    Shared Function PeriodoActual(ByVal fecha As String) As String
        Return Cls_HoraExtra_AD.PeriodoActual(fecha)
    End Function

    Function ListarTipoCompensacion(ByVal id As Integer, ByVal id_det As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarTipoCompensacion(id, id_det)
    End Function

    Sub GrabarSolicitudCompensado(ByVal id As Integer, ByVal id_2 As Integer, ByVal id_det_2 As Integer, ByVal horas As String, ByVal tipo_compensacion As Integer, _
                                  ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer, ByVal observaciones As String)
        objCls_HoraExtra_AD.GrabarSolicitudCompensado(id, id_2, id_det_2, horas, tipo_compensacion, usuario, ip, rol, observaciones)
    End Sub

    Function ListarHECompensadaDet(ByVal inicio As String, ByVal fin As String, ByVal usuario As Integer, ByVal estado As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarHECompensadaDet(inicio, fin, usuario, estado)
    End Function

    Function ListarSolicitudCompensado(ByVal id As Integer, ByVal id_det As Integer, ByVal estado As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarSolicitudCompensado(id, id_det, estado)
    End Function

    Function ListarSolicitudCompensado(ByVal inicio As String, ByVal fin As String, ByVal estado As Integer, ByVal usuario As Integer) As DataTable
        Return objCls_HoraExtra_AD.ListarSolicitudCompensado(inicio, fin, estado, usuario)
    End Function

    Sub AnularSolicitudCompensado(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objCls_HoraExtra_AD.AnularSolicitudCompensado(id, usuario, ip, rol)
    End Sub

    Sub AprobarSolicitudCompensado(ByVal id As Integer, ByVal estado As Integer, ByVal observacion As String, ByVal id_2 As Integer, ByVal id_2_det As Integer, ByVal horas As String, ByVal tipo_compensacion As Integer, ByVal horas_total As String, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objCls_HoraExtra_AD.AprobarSolicitudCompensado(id, estado, observacion, id_2, id_2_det, horas, tipo_compensacion, horas_total, usuario, ip, rol)
    End Sub

    Shared Function TieneSolicitudCompensado(ByVal id As Integer, ByVal id_det As Integer) As Integer
        Return Cls_HoraExtra_AD.TieneSolicitudCompensado(id, id_det)
    End Function

    Sub EliminarAsistencia()
        objCls_HoraExtra_AD.EliminarAsistencia()
    End Sub

    Sub AnularCompensacion(ByVal id As Integer, ByVal id_det As Integer, ByVal id_det2 As Integer, ByVal hora As String, ByVal usuario As Integer, ByVal ip As String, ByVal rol As Integer)
        objCls_HoraExtra_AD.AnularCompensacion(id, id_det, id_det2, hora, usuario, ip, rol)
    End Sub

    Sub GrabarHoraExtra(ByVal periodo As String, ByVal fecha As String, ByVal codigo As String, ByVal concepto As Integer, ByVal cantidad As Double, ByVal registro As Integer)
        objCls_HoraExtra_AD.GrabarHoraExtra(periodo, fecha, codigo, concepto, cantidad, registro)
    End Sub
End Class

