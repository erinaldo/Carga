Imports AccesoDatos
Public Class dtorepartoparcial
#Region "variables"
    Private s_IDSOLICITUD_RECOJO_CARGA As String
    Private l_cantidad_repartir As Long
    Private l_idusuario_persona As Long

#End Region
#Region "Propiedades"
    Public Property idusuario_persona() As Long
        Get
            Return l_idusuario_persona
        End Get
        Set(ByVal value As Long)
            l_idusuario_persona = value
        End Set
    End Property
    Public Property cantidad_repartir() As Long
        Get
            Return l_cantidad_repartir
        End Get
        Set(ByVal value As Long)
            l_cantidad_repartir = value
        End Set
    End Property
    Public Property idsolicitud_recojo_carga() As String
        Get
            Return s_IDSOLICITUD_RECOJO_CARGA
        End Get
        Set(ByVal value As String)
            s_IDSOLICITUD_RECOJO_CARGA = value
        End Set
    End Property
#End Region
#Region "Eventos y funciones"
    'Public Function fn_recupera_datos_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOOPERACIONES_MOVILES.sp_get_datos_repartir", 4, _
    '                                                                                                    s_IDSOLICITUD_RECOJO_CARGA, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_recupera_datos() As DataTable
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.sp_get_datos_repartir", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_IDSOLICITUD_RECOJO_CARGA", s_IDSOLICITUD_RECOJO_CARGA, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_act_reparto_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOOPERACIONES_MOVILES.sp_act_nro_reparto", 10, _
    '                                                                                                    s_IDSOLICITUD_RECOJO_CARGA, 2, _
    '                                                                                                    l_cantidad_repartir, 1, _
    '                                                                                                    l_idusuario_persona, 1, _
    '                                                                                                    dtoUSUARIOS.IP, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_act_reparto() As DataTable
        Try
            '            
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.sp_act_nro_reparto", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idsolicitud_recojo_carga", s_IDSOLICITUD_RECOJO_CARGA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_cantidad_entrega", l_cantidad_repartir, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_idusuario_personal", l_idusuario_persona, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_mensajes", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

End Class