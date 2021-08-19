imports AccesoDatos
Public Class dtobusquedaunidadtransporte
#Region "RECORSET"
    'datahelper
    'Public rst_lista_tipounidad As New ADODB.Recordset
    'Public rst_control As New ADODB.Recordset
    'Public rst_lista_modelounidad As New ADODB.Recordset
    Public rst_lista_tipounidad As DataTable
    Public rst_control As DataTable
    Public rst_lista_modelounidad As DataTable
    '
    Public coll_lista_tipounidad As New Collection
    Public coll_lista_modelounidad As New Collection
    '
#End Region
#Region "METODOS GUIAS DE ENVIO"
    Private iiCONTROL As Integer
    Private iIDTIPOUNIDAD_TRANSPORTE As Integer
    Private sTIPO_UNIDAD_TRANSPORTE As String
    Private iIDMODELO_MOVIL As Integer
    Private sMODELO_MOVIL As String
    Private iIDROL_USUARIO As Integer
    Private sip As String
    Private iIDUSUARIO_PERSONAL As Integer
    Private iIDESTADO_REGISTRO As Integer
    Public Property control() As Integer
        Get
            Return iiCONTROL
        End Get
        Set(ByVal value As Integer)
            iiCONTROL = value
        End Set
    End Property
    Public Property IDTIPOUNIDAD_TRANSPORTE() As Integer
        Get
            Return iIDTIPOUNIDAD_TRANSPORTE
        End Get
        Set(ByVal value As Integer)
            iIDTIPOUNIDAD_TRANSPORTE = value
        End Set
    End Property
    Public Property TIPO_UNIDAD_TRANSPORTE() As String
        Get
            Return sTIPO_UNIDAD_TRANSPORTE
        End Get
        Set(ByVal value As String)
            sTIPO_UNIDAD_TRANSPORTE = value
        End Set
    End Property
    Public Property IDMODELO_MOVIL() As Integer
        Get
            Return iIDMODELO_MOVIL
        End Get
        Set(ByVal value As Integer)
            iIDTIPOUNIDAD_TRANSPORTE = value
        End Set
    End Property
    Public Property MODELO_MOVIL() As String
        Get
            Return sMODELO_MOVIL
        End Get
        Set(ByVal value As String)
            sMODELO_MOVIL = value
        End Set
    End Property
    Public Property IDROL_USUARIO() As Integer
        Get
            Return iIDROL_USUARIO
        End Get
        Set(ByVal value As Integer)
            iIDROL_USUARIO = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL() As Integer
        Get
            Return iIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Integer)
            iIDUSUARIO_PERSONAL = value
        End Set
    End Property

    Public Property IDESTADO_REGISTRO() As Integer
        Get
            Return iIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Integer)
            iIDESTADO_REGISTRO = value
        End Set
    End Property

    ' Actualiza la el tipo unidad de transportes
    Public Function fn_INSUPD_tipo_uni_trans2009() As Boolean
        'Dim flat As Boolean = False
        'Try
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOUNIDADTRANSPORTE.SP_INSUPD_tipo_uni_trans", 8, _
        '                                                     iiCONTROL, 1, _
        '                                                     iIDTIPOUNIDAD_TRANSPORTE, 1, _
        '                                                     sTIPO_UNIDAD_TRANSPORTE, 2}
        '    rst_lista_tipounidad = Nothing
        '    rst_control = Nothing
        '    rst_lista_tipounidad = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    rst_control = rst_lista_tipounidad.NextRecordset()
        '    flat = True
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function

    Public Function fn_INSUPD_tipo_uni_trans() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUNIDADTRANSPORTE.SP_INSUPD_tipo_uni_trans", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", iiCONTROL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDTIPOUNIDAD_TRANSPORTE", iIDTIPOUNIDAD_TRANSPORTE, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTIPO_UNIDAD_TRANSPORTE", sTIPO_UNIDAD_TRANSPORTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_TIPO_UNIDAD_TRANSPORTE", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_lista_tipounidad = ds.Tables(0)
            rst_control = ds.Tables(1)
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_LISTA_TIPOUNIDAD2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOUNIDADTRANSPORTE.SP_LISTA_TIPOUNIDAD", 0}
    '        rst_lista_tipounidad = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    Public Function fn_LISTA_TIPOUNIDAD() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUNIDADTRANSPORTE.SP_LISTA_TIPOUNIDAD", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_TIPOUNIDAD", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_lista_tipounidad = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Recupera el modelo de la unidad de transporte 
    'Public Function fn_LISTA_MODELO_MOVIL2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOUNIDADTRANSPORTE.SP_LISTA_MODELO_MOVIL", 0}
    '        rst_lista_modelounidad = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    'Recupera el modelo de la unidad de transporte 
    Public Function fn_LISTA_MODELO_MOVIL() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUNIDADTRANSPORTE.SP_LISTA_MODELO_MOVIL", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_MODELOMOVIL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_lista_modelounidad = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    ' Actualiza la el tipo unidad de transportes
    'Public Function fn_INSUPD_modelo_movil2009() As Boolean
    'Dim flat As Boolean = False
    'Try
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOUNIDADTRANSPORTE.SP_INSUPD_modelo_movil", 16, _
    '                                                     iiCONTROL, 1, _
    '                                                     iIDMODELO_MOVIL, 1, _
    '                                                     sMODELO_MOVIL, 2, _
    '                                                     iIDROL_USUARIO, 1, _
    '                                                     sip, 2, _
    '                                                     iIDUSUARIO_PERSONAL, 1, _
    '                                                     iIDESTADO_REGISTRO, 1}
    '    rst_lista_modelounidad = Nothing
    '    rst_control = Nothing
    '    rst_lista_modelounidad = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    rst_control = rst_lista_modelounidad.NextRecordset()
    '    flat = True
    'Catch ex As Exception
    '    flat = False
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    'End Try
    'Return flat
    'End Function
    ' Actualiza la el tipo unidad de transportes
    Public Function fn_INSUPD_modelo_movil() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUNIDADTRANSPORTE.SP_INSUPD_modelo_movil", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", iiCONTROL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDMODELO_MOVIL", iIDMODELO_MOVIL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iMODELO_MOVIL", sMODELO_MOVIL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDROL_USUARIO", iIDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDESTADO_REGISTRO", iIDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCUR_MODELOMOVIL", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_lista_modelounidad = ds.Tables(0)
            rst_control = ds.Tables(1)
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class
