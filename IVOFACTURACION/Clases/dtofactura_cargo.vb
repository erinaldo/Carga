Imports AccesoDatos
Public Class dtofactura_cargo
#Region "RECORDSET"
    ' Load 
    'Public rst_mensaje As New ADODB.Recordset
    Public rst_mensaje As New DataTable
#End Region
#Region "Variables"
    Public sidpersona As String
    Public sidfactura As String
    Public sfecha_cargo As String
    Public smensajero As String
    Public sidusuario As String
    ' Codigo de oracle 
    Public lcodoracle As Long
    Public smensaje As String
#End Region
#Region "Funciones"


    'Public Function fn_actualiza_fecha_cargo2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOFACTURACION.sp_actualiza_fec_vencimiento", 12, _
    '                                                              sidpersona, 2, _
    '                                                              sidfactura, 2, _
    '                                                              sfecha_cargo, 2, _
    '                                                              smensajero, 2, _
    '                                                              sidusuario, 2}
    '        'rst_mensaje = Nothing
    '        'rst_mensaje = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        'If rst_mensaje.State = 1 Then
    '        '    If rst_mensaje.EOF = False And rst_mensaje.BOF = False Then
    '        '        lcodoracle = CType(rst_mensaje.Fields.Item(0).Value, Long)
    '        '        smensaje = rst_mensaje.Fields.Item(1).Value.ToString
    '        '        flag = True
    '        '    End If
    '        'End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Public Function fn_actualiza_fecha_cargo() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.sp_actualiza_fec_vencimiento", CommandType.StoredProcedure)
            db.AsignarParametro("vidpersona", sidpersona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vidfactura", sidfactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_cargo", sfecha_cargo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vmensajero", smensajero, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vidusuario", sidusuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_mensaje = db.EjecutarDataTable
            If rst_mensaje.Rows.Count > 0 Then
                lcodoracle = CType(rst_mensaje.Rows(0).Item(0).ToString, Long)
                smensaje = rst_mensaje.Rows(0).Item(1).ToString
            Else
                smensaje = ""
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

        'Dim flag As Boolean = False
        'Try
        '    Dim SQLQuery As Object() = {"PKG_IVOFACTURACION.sp_actualiza_fec_vencimiento", 12, _
        '                                                          sidpersona, 2, _
        '                                                          sidfactura, 2, _
        '                                                          sfecha_cargo, 2, _
        '                                                          smensajero, 2, _
        '                                                          sidusuario, 2}
        '    rst_mensaje = Nothing
        '    rst_mensaje = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
        '    If rst_mensaje.State = 1 Then
        '        If rst_mensaje.EOF = False And rst_mensaje.BOF = False Then
        '            lcodoracle = CType(rst_mensaje.Fields.Item(0).Value, Long)
        '            smensaje = rst_mensaje.Fields.Item(1).Value.ToString
        '            flag = True
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        '    flag = False
        'End Try
        'Return flag
    End Function
#End Region
End Class

