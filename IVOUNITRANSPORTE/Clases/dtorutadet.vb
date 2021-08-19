Imports AccesoDatos
Public Class dtorutadet
    Private iidlogin As Integer
    Private iidruta_entrega_recojo_det As Integer
    Private iidistrito As Integer
    Private iidprovincia As Integer
    Private iidruta_entrega_recojo As Integer
    Private iicontrol As Integer
    Private iddepartamento As Integer
    Private idpais As Integer
    Private iidusuario_personal As Integer
    Private iiip As String
    Private iidrol_usuario As Integer
    Private iidestado_registro As Integer
    Public Property idruta_entrega_recojo() As Integer
        Get
            Return iidruta_entrega_recojo
        End Get
        Set(ByVal value As Integer)
            iidruta_entrega_recojo = value
        End Set
    End Property
    Public Property idusuario() As Integer
        Get
            Return iidlogin
        End Get
        Set(ByVal value As Integer)
            iidlogin = value
        End Set
    End Property
    Public Property control() As Integer
        Get
            Return iicontrol
        End Get
        Set(ByVal value As Integer)
            iicontrol = value
        End Set
    End Property
    Public Property departamento() As Integer
        Get
            Return iddepartamento
        End Get
        Set(ByVal value As Integer)
            iddepartamento = value
        End Set
    End Property
    Public Property pais() As Integer
        Get
            Return idpais
        End Get
        Set(ByVal value As Integer)
            idpais = value
        End Set
    End Property
    Public Property usuario_personal() As Integer
        Get
            Return iidusuario_personal
        End Get
        Set(ByVal value As Integer)
            iidusuario_personal = value
        End Set
    End Property
    Public Property ip() As String
        Get
            Return iiip
        End Get
        Set(ByVal value As String)
            iiip = value
        End Set
    End Property
    Public Property rol_usuario() As Integer
        Get
            Return iidrol_usuario
        End Get
        Set(ByVal value As Integer)
            iidrol_usuario = value
        End Set
    End Property
    Public Property estado_registro() As Integer
        Get
            Return iidestado_registro
        End Get
        Set(ByVal value As Integer)
            iidestado_registro = value
        End Set
    End Property
    Public Property idruta_entrega_recojo_det() As Integer
        Get
            Return iidruta_entrega_recojo_det
        End Get
        Set(ByVal value As Integer)
            iidruta_entrega_recojo_det = value
        End Set
    End Property
    Public Property distrito() As Integer
        Get
            Return iidistrito
        End Get
        Set(ByVal value As Integer)
            iidistrito = value
        End Set
    End Property
    Public Property provincia() As Integer
        Get
            Return iidprovincia
        End Get
        Set(ByVal value As Integer)
            iidprovincia = value
        End Set
    End Property
    'Public Function actualizadetalle20009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVOUNIDADTRANSPORTE.SP_ACTUALIZA_RUTA_DET", 24, _
    '                                                    iicontrol, 1, _
    '                                                    iidruta_entrega_recojo_det, 1, _
    '                                                    iidruta_entrega_recojo, 1, _
    '                                                    iidistrito, 1, _
    '                                                    iidprovincia, 1, _
    '                                                    iddepartamento, 1, _
    '                                                    idpais, 1, _
    '                                                    iidusuario_personal, 1, _
    '                                                    iiip, 2, _
    '                                                    iidrol_usuario, 1, _
    '                                                    iidestado_registro, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function

    Public Function actualizadetalle() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUNIDADTRANSPORTE.SP_ACTUALIZA_RUTA_DET", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", iicontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidruta_entrega_recojo_det", iidruta_entrega_recojo_det, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidruta_entrega_recojo", iidruta_entrega_recojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("iiddistrito", iidistrito, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidprovincia", iidprovincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iiddepartamento", iddepartamento, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidpais", idpais, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidusuario_personal", iidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("iip", iiip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iidrol_usuario", iidrol_usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidestado_registro", iidestado_registro, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_MSG", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_Datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_control", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

End Class