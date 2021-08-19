Imports AccesoDatos
Class dtomantablas
#Region "Privadas"
    Private ll_idusuario As Long
    Private li_control As Integer
    Private li_idunidad_agencia As Integer
    Private ls_nombre_agencia As String
    Private ls_codigo_iata As String
    Private ll_iddistrito As Int32
    Private ll_idprovincia As Int32
    Private ll_iddepartamento As Int32
    Private ll_idpais As Int32
    Private ll_IDUSUARIO_PERSONAL As Int32
    Private ll_idrol As Int32
    Private ls_ip As String
    Private ll_IDARTICULOS As Int32
    Private ls_NOMBRE_ARTICULO As String
#End Region
#Region "Propiedades"
    Public Property NOMBRE_ARTICULO() As String
        Get
            Return ls_NOMBRE_ARTICULO
        End Get
        Set(ByVal value As String)
            ls_NOMBRE_ARTICULO = value
        End Set
    End Property
    Public Property IDARTICULOS() As Int32
        Get
            Return ll_IDARTICULOS
        End Get
        Set(ByVal value As Int32)
            ll_IDARTICULOS = value
        End Set
    End Property
    Public Property ip() As String
        Get
            Return ls_ip
        End Get
        Set(ByVal value As String)
            ls_ip = value
        End Set
    End Property
    Public Property idrol() As Int32
        Get
            Return ll_idrol
        End Get
        Set(ByVal value As Int32)
            ll_idrol = value
        End Set
    End Property
    Public Property iIDUSUARIO_PERSONAL() As Int32
        Get
            Return ll_IDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Int32)
            ll_IDUSUARIO_PERSONAL = value
        End Set
    End Property
    Public Property pais() As Int32
        Get
            Return ll_idpais
        End Get
        Set(ByVal value As Int32)
            ll_idpais = value
        End Set
    End Property
    Public Property departamento() As Int32
        Get
            Return ll_iddepartamento
        End Get
        Set(ByVal value As Int32)
            ll_iddepartamento = value
        End Set
    End Property
    Public Property provincia() As Int32
        Get
            Return ll_idprovincia
        End Get
        Set(ByVal value As Int32)
            ll_idprovincia = value
        End Set
    End Property
    Public Property distrito() As Int32
        Get
            Return ll_iddistrito
        End Get
        Set(ByVal value As Int32)
            ll_iddistrito = value
        End Set
    End Property
    Public Property codigo_iata() As String
        Get
            Return ls_codigo_iata
        End Get
        Set(ByVal value As String)
            ls_codigo_iata = value
        End Set
    End Property
    Public Property nombre_agencia() As String
        Get
            Return ls_nombre_agencia
        End Get
        Set(ByVal value As String)
            ls_nombre_agencia = value
        End Set
    End Property
    Public Property idusuario() As Long
        Get
            Return ll_idusuario
        End Get
        Set(ByVal value As Long)
            ll_idusuario = value
        End Set
    End Property
    Public Property control() As Integer
        Get
            Return li_control
        End Get
        Set(ByVal value As Integer)
            li_control = value
        End Set
    End Property
    Public Property idunidad_agencia() As Long
        Get
            Return li_idunidad_agencia
        End Get
        Set(ByVal value As Long)
            li_idunidad_agencia = value
        End Set
    End Property
#End Region
#Region "Procedimientos y Funciones"
    Public Function fn_get_busca_procedimiento(ByVal ls_procedimiento As String) As DataSet
        Dim lds_tmp As New DataSet
        '
        Select Case ls_procedimiento
            Case "PKG_IVOITINERARIOS.SP_LISTA_UNIDADES"
                lds_tmp = fn_get_lista_unidad()
            Case "PKG_IVOITINERARIOS.SP_INSUPD_UNIDAD_AGENCIA"
                lds_tmp = fn_upd_lista_unidad_agencia()
            Case "PKG_IVOITINERARIOS.SP_LISTA_ARTICULOS"
                lds_tmp = fn_get_lista_articulos()
            Case "PKG_IVOITINERARIOS.SP_INSUPD_ARTICULOS"
                lds_tmp = fn_upd_lista_articulos()
        End Select
        Return lds_tmp
    End Function
    Private Function fn_get_lista_unidad() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_UNIDADES", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas             
            db_bd.AsignarParametro("cur_Agencia", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_pais", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_depar", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_prov", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_distrito", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Private Function fn_get_lista_articulos() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_ARTICULOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas             
            db_bd.AsignarParametro("cur_agencias", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Private Function fn_upd_lista_unidad_agencia() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_UNIDAD_AGENCIA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", li_control, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", li_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNOMBRE_UNIDAD", ls_nombre_agencia, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iCODIGO_IATA", ls_codigo_iata, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDDISTRITO", ll_iddistrito, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDPROVINCIA", ll_idprovincia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDDEPARTAMENTO", ll_iddepartamento, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDPAIS", ll_idpais, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", ll_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", ll_idrol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", ls_ip, OracleClient.OracleType.VarChar)
            'Variables de salidas             
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_lista", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Private Function fn_upd_lista_articulos() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_ARTICULOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", li_control, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIDARTICULOS", ll_IDARTICULOS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iNOMBRE_ARTICULO", ls_NOMBRE_ARTICULO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", ll_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", ll_idrol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", ls_ip, OracleClient.OracleType.VarChar)
            'Variables de salidas             
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_lista", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class