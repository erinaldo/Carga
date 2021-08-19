Imports AccesoDatos
Public Class dtoHorarioSalida
#Region "Propiedades"
    Private m_icontrol As Integer
    Private m_iidruras As Integer
    Private m_idruta_horario As Integer
    Private m_shora As String
    Private m_iestado As Integer
    Private m_sip As String
    Private m_iidusuario_personal As Integer
    Private m_iidrol_usuario As Integer
    '- 
    Public Property control() As Integer
        Get
            Return m_icontrol
        End Get
        Set(ByVal value As Integer)
            m_icontrol = value

        End Set
    End Property
    Public Property idruta_horario() As Integer
        Get
            Return m_idruta_horario
        End Get
        Set(ByVal value As Integer)
            m_idruta_horario = value
        End Set
    End Property
    Public Property idrutas() As Integer
        Get
            Return m_iidruras
        End Get
        Set(ByVal value As Integer)
            m_iidruras = value
        End Set
    End Property
    Public Property hora() As String
        Get
            Return m_shora
        End Get
        Set(ByVal value As String)
            m_shora = value
        End Set
    End Property
    Public Property estado() As Integer
        Get
            Return m_iestado
        End Get
        Set(ByVal value As Integer)
            m_iestado = value
        End Set
    End Property
    Public Property ip() As String
        Get
            Return m_sip
        End Get
        Set(ByVal value As String)
            m_sip = value
        End Set
    End Property
    Public Property idusuario_personal() As Integer
        Get
            Return m_iidusuario_personal
        End Get
        Set(ByVal value As Integer)
            m_iidusuario_personal = value
        End Set
    End Property
    Public Property iidrol_usuario() As Integer
        Get
            Return m_iidrol_usuario
        End Get
        Set(ByVal value As Integer)
            m_iidrol_usuario = value
        End Set
    End Property
#End Region
    '-- Recuperando el horario de salidas 
    'Public Function fn_getcmb_horariosalidas_2009() As ADODB.Recordset
    '    Try
    '        Dim Obj As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_lista_horariosalidas", 0}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function
    Public Function fn_getcmb_horariosalidas() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_lista_horariosalidas", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_unidad_agencia", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_horariosalida", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_rutas", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    ' Actualiza la ruta horario  
    'Public Function fn_actualiza_rutahorario_2009() As ADODB.Recordset
    '    Try
    '        Dim Obj As Object() = {"PKG_IVOTRANSPORTE_CARGA.sf_actualiza_rutahorario", 18, _
    '                                                        m_icontrol, 1, _
    '                                                        m_idruta_horario, 1, _
    '                                                        m_iidruras, 1, _
    '                                                        m_shora, 2, _
    '                                                        m_iestado, 1, _
    '                                                        m_sip, 2, _
    '                                                        m_iidusuario_personal, 1, _
    '                                                        m_iidrol_usuario, 1}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function
    Public Function fn_actualiza_rutahorario() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sf_actualiza_rutahorario", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("icontrol", m_icontrol, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidruta_horario", m_idruta_horario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidrutas", m_iidruras, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ihora", m_shora, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iestado", m_iestado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iip", m_sip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidusuario_personal", m_iidusuario_personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iidrol_usuario", m_iidrol_usuario, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_control", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_refresca_rutahorario_2009() As ADODB.Recordset
    '    Try
    '        Dim Obj As Object() = {"PKG_IVOTRANSPORTE_CARGA.sp_recupera_ruta_horario", 2}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function
    Public Function fn_refresca_rutahorario() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_recupera_ruta_horario", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_horariosalida", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class