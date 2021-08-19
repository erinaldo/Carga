Imports AccesoDatos
Public Class dtoMigra
    'Public Function FN_L_GUIAS_ENVIO_2009(ByVal VOCONTROLUSUARIO As Object, _
    '    ByVal P_IDAGENCIAS As Integer, _
    '    ByVal P_IDFORMA_PAGO As Integer, _
    '    ByVal P_IDUSUARIO_PERSONAL As Integer, _
    '    ByVal P_IDTIPO_MONEDA As Integer, _
    '    ByVal P_IDPERSONA As Integer, _
    '    ByVal P_FECHA_INICIO As String, _
    '    ByVal P_FECHA_FINAL As String, _
    '    ByVal P_EXPORTADO As Long, _
    '    ByVal P_FACTURADO As Long, _
    '    ByVal P_OPERACION As Long _
    '    ) As DataView
    '    Dim dv As New DataView
    '    Dim Rst As New ADODB.Recordset
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim DT As New DataTable
    '    Dim A As Integer = 0
    '    Dim M As Integer
    '    '
    '    Try
    '        '
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOMIGRA.SP_L_GUIAS_ENVIO", 22, _
    '        IIf(P_IDAGENCIAS = 0, -666, P_IDAGENCIAS), 1, _
    '        IIf(P_IDFORMA_PAGO = 0, -666, P_IDFORMA_PAGO), 1, _
    '        IIf(P_IDUSUARIO_PERSONAL = 0, -666, P_IDUSUARIO_PERSONAL), 1, _
    '        IIf(P_IDTIPO_MONEDA = 0, -666, P_IDTIPO_MONEDA), 1, _
    '        IIf(P_IDPERSONA = 0, -666, P_IDPERSONA), 1, _
    '        P_FECHA_INICIO, 2, _
    '        P_FECHA_FINAL, 2, _
    '        P_EXPORTADO, 1, _
    '        P_FACTURADO, 1, _
    '        P_OPERACION, 1}
    '        '
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        DA.Fill(DT, Rst)
    '        '
    '        dv = DT.DefaultView
    '        '
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    M = 1 / A
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_L_GUIAS_ENVIO(ByVal P_IDAGENCIAS As Integer, _
       ByVal P_IDFORMA_PAGO As Integer, _
       ByVal P_IDUSUARIO_PERSONAL As Integer, _
       ByVal P_IDTIPO_MONEDA As Integer, _
       ByVal P_IDPERSONA As Integer, _
       ByVal P_FECHA_INICIO As String, _
       ByVal P_FECHA_FINAL As String, _
       ByVal P_EXPORTADO As Long, _
       ByVal P_FACTURADO As Long, _
       ByVal P_OPERACION As Long _
       ) As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            P_IDAGENCIAS = IIf(P_IDAGENCIAS = 0, -666, P_IDAGENCIAS)
            P_IDFORMA_PAGO = IIf(P_IDFORMA_PAGO = 0, -666, P_IDFORMA_PAGO)
            P_IDUSUARIO_PERSONAL = IIf(P_IDUSUARIO_PERSONAL = 0, -666, P_IDUSUARIO_PERSONAL)
            P_IDTIPO_MONEDA = IIf(P_IDTIPO_MONEDA = 0, -666, P_IDTIPO_MONEDA)
            P_IDPERSONA = IIf(P_IDPERSONA = 0, -666, P_IDPERSONA)
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOMIGRA.SP_L_GUIAS_ENVIO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_IDAGENCIAS", P_IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDFORMA_PAGO", P_IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUSUARIO_PERSONAL", P_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDTIPO_MONEDA", P_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDPERSONA", P_IDPERSONA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_FECHA_INICIO", P_FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_FECHA_FINAL", P_FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_EXPORTADO", P_EXPORTADO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_FACTURADO", P_FACTURADO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_OPERACION", P_OPERACION, OracleClient.OracleType.Cursor)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_L_GUIAS_ENVIO", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dv = ldt_tmp.DefaultView
            Return dv
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_L_factura_2009(ByVal VOCONTROLUSUARIO As Object, _
    '    ByVal P_IDAGENCIAS As Integer, _
    '    ByVal P_IDFORMA_PAGO As Integer, _
    '    ByVal P_IDUSUARIO_PERSONAL As Integer, _
    '    ByVal P_IDTIPO_MONEDA As Integer, _
    '    ByVal P_IDPERSONA As Integer, _
    '    ByVal P_FECHA_INICIO As String, _
    '    ByVal P_FECHA_FINAL As String, _
    '    ByVal P_EXPORTADO As Long, _
    '    ByVal P_OPERACION As Long _
    '    ) As DataView
    '    Dim dv As New DataView
    '    Dim Rst As New ADODB.Recordset
    '    '
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim DT As New DataTable
    '    Dim A As Integer = 0
    '    Dim M As Integer
    '    '
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOMIGRA.SP_L_FACTURA", 20, _
    '        IIf(P_IDAGENCIAS = 0, -666, P_IDAGENCIAS), 1, _
    '        IIf(P_IDFORMA_PAGO = 0, -666, P_IDFORMA_PAGO), 1, _
    '        IIf(P_IDUSUARIO_PERSONAL = 0, -666, P_IDUSUARIO_PERSONAL), 1, _
    '        IIf(P_IDTIPO_MONEDA = 0, -666, P_IDTIPO_MONEDA), 1, _
    '        IIf(P_IDPERSONA = 0, -666, P_IDPERSONA), 1, _
    '        P_FECHA_INICIO, 2, _
    '        P_FECHA_FINAL, 2, _
    '        P_EXPORTADO, 1, _
    '        P_OPERACION, 1}
    '        '
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        '
    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    M = 1 / A
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_L_factura(ByVal P_IDAGENCIAS As Integer, _
    ByVal P_IDFORMA_PAGO As Integer, _
    ByVal P_IDUSUARIO_PERSONAL As Integer, _
    ByVal P_IDTIPO_MONEDA As Integer, _
    ByVal P_IDPERSONA As Integer, _
    ByVal P_FECHA_INICIO As String, _
    ByVal P_FECHA_FINAL As String, _
    ByVal P_EXPORTADO As Long, _
    ByVal P_OPERACION As Long _
    ) As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            P_IDAGENCIAS = IIf(P_IDAGENCIAS = 0, -666, P_IDAGENCIAS)
            P_IDFORMA_PAGO = IIf(P_IDFORMA_PAGO = 0, -666, P_IDFORMA_PAGO)
            P_IDUSUARIO_PERSONAL = IIf(P_IDUSUARIO_PERSONAL = 0, -666, P_IDUSUARIO_PERSONAL)
            P_IDTIPO_MONEDA = IIf(P_IDTIPO_MONEDA = 0, -666, P_IDTIPO_MONEDA)
            P_IDPERSONA = IIf(P_IDPERSONA = 0, -666, P_IDPERSONA)
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOMIGRA.SP_L_FACTURA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("P_IDAGENCIAS", P_IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDFORMA_PAGO", P_IDFORMA_PAGO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUSUARIO_PERSONAL", P_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDTIPO_MONEDA", P_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDPERSONA", P_IDPERSONA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_FECHA_INICIO", P_FECHA_INICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_FECHA_FINAL", P_FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_EXPORTADO", P_EXPORTADO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_OPERACION", P_OPERACION, OracleClient.OracleType.Cursor)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_L_FACTURA", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dv = ldt_tmp.DefaultView
            Return dv
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
