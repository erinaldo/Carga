Imports AccesoDatos
Public Class dtoSolAsignamovil
    Private Stidcliente As Integer
    Private Stcliente As String
    Private stfecha_hora_recojo As String
    Private stideagencia As Integer
    Private icontrol As Integer
    Private iidsolicitudrecojocarga As Integer
    Private iidruta_entrega_recojo As Integer
    Private iidunidad_transporte As Integer
    Private sipmod As String
    Private iidrol_usuariomod As Integer
    Private iidusuario_personalmod As Integer
    Private iaprobado As Integer
    Private vhora_ini As String
    Private vhora_fin As String
    Private nnro_paquetes As Integer
    Private npeso_kg As Double
    Private nvolumen As Double
    Public Property nro_paquetes() As Integer
        Get
            Return nnro_paquetes
        End Get
        Set(ByVal value As Integer)
            nnro_paquetes = value
        End Set
    End Property
    Public Property peso_kg() As Double
        Get
            Return npeso_kg
        End Get
        Set(ByVal value As Double)
            npeso_kg = value
        End Set
    End Property
    Public Property volumen() As Double
        Get
            Return nvolumen
        End Get
        Set(ByVal value As Double)
            nvolumen = value
        End Set
    End Property
    Public Property hora_ini() As String
        Get
            Return vhora_ini
        End Get
        Set(ByVal value As String)
            vhora_ini = value
        End Set
    End Property
    Public Property hora_fin() As String
        Get
            Return vhora_fin
        End Get
        Set(ByVal value As String)
            vhora_fin = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return Stcliente
        End Get
        Set(ByVal value As String)
            Stcliente = value
        End Set
    End Property
    Public Property Idcliente() As Integer
        Get
            Return Stidcliente
        End Get
        Set(ByVal value As Integer)
            Stidcliente = value
        End Set
    End Property
    Public Property fecharecojo() As String
        Get
            Return stfecha_hora_recojo
        End Get
        Set(ByVal value As String)
            stfecha_hora_recojo = value
        End Set
    End Property
    Public Property idagencia() As Integer
        Get
            Return stideagencia
        End Get
        Set(ByVal value As Integer)
            stideagencia = value
        End Set
    End Property
    Public Property control() As Integer
        Get
            Return icontrol
        End Get
        Set(ByVal value As Integer)
            icontrol = value
        End Set
    End Property
    Public Property idsolicitudrecojocarga() As Integer
        Get
            Return iidsolicitudrecojocarga
        End Get
        Set(ByVal value As Integer)
            iidsolicitudrecojocarga = value
        End Set
    End Property
    Public Property idruta_entrega_recojo() As Integer
        Get
            Return iidruta_entrega_recojo
        End Get
        Set(ByVal value As Integer)
            iidruta_entrega_recojo = value
        End Set
    End Property
    Public Property idunidad_transporte() As Integer
        Get
            Return iidunidad_transporte
        End Get
        Set(ByVal value As Integer)
            iidunidad_transporte = value
        End Set
    End Property
    Public Property ipmod() As String
        Get
            Return sipmod
        End Get
        Set(ByVal value As String)
            sipmod = value
        End Set
    End Property
    Public Property idrol_usuariomod() As Integer
        Get
            Return iidrol_usuariomod
        End Get
        Set(ByVal value As Integer)
            iidrol_usuariomod = value
        End Set
    End Property
    Public Property idusuario_personalmod() As Integer
        Get
            Return iidusuario_personalmod
        End Get
        Set(ByVal value As Integer)
            iidusuario_personalmod = value
        End Set
    End Property
    Public Property aprobado() As Integer
        Get
            Return iaprobado
        End Get
        Set(ByVal value As Integer)
            iaprobado = value
        End Set
    End Property

    'Public Function Get_solicitud_movil2009() As ADODB.Recordset
    '    Dim ObjAge As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_SOLICITUD_MOVIL", 6, stideagencia, 1, stfecha_hora_recojo, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjAge)
    'End Function

    Public Function Get_solicitud_movil() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_SOLICITUD_MOVIL", CommandType.StoredProcedure)
            db.AsignarParametro("in_idagencia", stideagencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iv_fec_solicitada", stfecha_hora_recojo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_solicitud_porMovil", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function actualiza_aprobacion2009() As ADODB.Recordset
    '    Dim ObjAge As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_upd_apruebaasigna", 30, _
    '                                icontrol, 1, _
    '                                iidsolicitudrecojocarga, 1, _
    '                                iidruta_entrega_recojo, 1, _
    '                                iidunidad_transporte, 1, _
    '                                iaprobado, 1, _
    '                                stfecha_hora_recojo, 2, _
    '                                vhora_ini, 2, _
    '                                vhora_fin, 2, _
    '                                nnro_paquetes, 1, _
    '                                npeso_kg, 3, _
    '                                nvolumen, 3, _
    '                                sipmod, 2, _
    '                                iidrol_usuariomod, 1, _
    '                                iidusuario_personalmod, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjAge)
    'End Function
    Public Function actualiza_aprobacion() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_upd_apruebaasigna", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidsolicitudrecojocarga", iidsolicitudrecojocarga, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidruta_entrega_recojo", iidruta_entrega_recojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidunidad_transporte", iidunidad_transporte, OracleClient.OracleType.Int32)
            db.AsignarParametro("iiaprobado", iaprobado, OracleClient.OracleType.Int32)
            db.AsignarParametro("vfecha_recojo", stfecha_hora_recojo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vhora_ini", vhora_ini, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vhora_fin", vhora_fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nnro_paquetes", nnro_paquetes, OracleClient.OracleType.Int32)
            db.AsignarParametro("nnro_peso_kg", npeso_kg, OracleClient.OracleType.Number)
            db.AsignarParametro("nvolumen", nvolumen, OracleClient.OracleType.Number)
            db.AsignarParametro("iipmod", sipmod, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iidrol_usuariomod", iidrol_usuariomod, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidusurio_personalmod", iidusuario_personalmod, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocurdatos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCur_control", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

End Class
