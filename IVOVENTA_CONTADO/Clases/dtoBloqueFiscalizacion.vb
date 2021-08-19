Public Class dtoBloqueFiscalizacion
    Public v_iControl As Integer
    Public v_fecha_ini As String
    Public v_fecha_fin As String
    Public v_idAgencias As Integer
    Public v_Bloquear_Desbloquear As Integer
    Public v_Pasajes As Integer
    Public v_Contado_carga As Integer
    Public v_Credito_carga As Integer

    'Public CUR_DATOS As New ADODB.Recordset
    'Public Function fnSP_LISTA_CAJAS_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOMIGRACION_ERP.SP_LISTA_CAJAS", 2}
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If CUR_DATOS.BOF = False And CUR_DATOS.EOF = False Then
    '            flat = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    'Public Function fnSP_BLOQUEAR_REGISTROS_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOMIGRACION_ERP.SP_BLOQUEAR_REGISTROS_II", 18, v_iControl, 1, v_fecha_ini, 2, v_fecha_fin, 2, v_idAgencias, 1, v_Bloquear_Desbloquear, 1, v_Pasajes, 1, v_Contado_carga, 1, v_Credito_carga, 1}
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If CUR_DATOS.BOF = False And CUR_DATOS.EOF = False Then
    '            flat = True
    '            MsgBox(CUR_DATOS.Fields.Item("MsgBox").Value, MsgBoxStyle.Information, "Seguridad Sisteme")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    'Public Function fnSP_BUSCAR_BLOQUEOS_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOMIGRACION_ERP.SP_BUSCAR_BLOQUEOS", 8, v_iControl, 1, v_fecha_ini, 2, v_fecha_fin, 2}
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        flat = True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
End Class
