Imports AccesoDatos
Public Class dtorecojopactadodet
    Private icontrol As Integer
    Private iidentrega_recojo_dia_hora As Integer
    Private iidrecojo_carga_pactado As Integer
    Private idia_semana As Integer
    Private iidtipo_pacto As Integer
    Private vhora_inicio As String
    Private vhora_final As String
    Private idia_activo As Integer
    Private iidusuario_personal As Integer
    Private vip As String
    Private iidrol_usuario As Integer
    Private iidestado_registrado As Integer
    Private dvolumen As Double
    Private dpeso_kg As Double
    Public Property control() As Integer
        Get
            Return icontrol
        End Get
        Set(ByVal value As Integer)
            icontrol = value
        End Set
    End Property
    Public Property identrega_recojo_dia_hora() As Integer
        Get
            Return iidentrega_recojo_dia_hora
        End Get
        Set(ByVal value As Integer)
            iidentrega_recojo_dia_hora = value
        End Set
    End Property
    Public Property dia_semana() As Integer
        Get
            Return idia_semana
        End Get
        Set(ByVal value As Integer)
            idia_semana = value
        End Set
    End Property
    Public Property idtipo_pacto() As Integer
        Get
            Return iidtipo_pacto
        End Get
        Set(ByVal value As Integer)
            iidtipo_pacto = value
        End Set
    End Property
    Public Property hora_inicio() As String
        Get
            Return vhora_inicio
        End Get
        Set(ByVal value As String)
            vhora_inicio = value
        End Set
    End Property
    Public Property hora_final() As String
        Get
            Return vhora_final
        End Get
        Set(ByVal value As String)
            vhora_final = value
        End Set
    End Property
    Public Property dia_activo() As Integer
        Get
            Return idia_activo
        End Get
        Set(ByVal value As Integer)
            idia_activo = value
        End Set
    End Property
    Public Property volumen() As Double
        Get
            Return dvolumen
        End Get
        Set(ByVal value As Double)
            dvolumen = value
        End Set
    End Property
    Public Property peso_kg() As Double
        Get
            Return dpeso_kg
        End Get
        Set(ByVal value As Double)
            dpeso_kg = value
        End Set
    End Property
    Public Property idrecojo_carga_pactado() As Integer
        Get
            Return iidrecojo_carga_pactado
        End Get
        Set(ByVal value As Integer)
            iidrecojo_carga_pactado = value
        End Set
    End Property
    Public Property idusuario_personal() As Integer
        Get
            Return iidusuario_personal
        End Get
        Set(ByVal value As Integer)
            iidusuario_personal = value
        End Set
    End Property
    Public Property ip() As String
        Get
            Return vip
        End Get
        Set(ByVal value As String)
            vip = value
        End Set
    End Property
    Public Property idrol_usuario() As Integer
        Get
            Return iidrol_usuario
        End Get
        Set(ByVal value As Integer)
            iidrol_usuario = value
        End Set
    End Property
    Public Property idestado_registrado() As Integer
        Get
            Return iidestado_registrado
        End Get
        Set(ByVal value As Integer)
            iidestado_registrado = value
        End Set
    End Property
    'Public Function Actualizarecojoacordadodetalle2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_actualiza_pactado_dia_hora", 30, _
    '                                                                           icontrol, 1, _
    '                                                                           iidentrega_recojo_dia_hora, 1, _
    '                                                                           iidrecojo_carga_pactado, 1, _
    '                                                                           idia_semana, 1, _
    '                                                                           iidtipo_pacto, 1, _
    '                                                                           vhora_inicio, 2, _
    '                                                                           vhora_final, 2, _
    '                                                                           idia_activo, 1, _
    '                                                                           dpeso_kg, 3, _
    '                                                                           dvolumen, 3, _
    '                                                                           iidusuario_personal, 1, _
    '                                                                           vip, 2, _
    '                                                                           iidrol_usuario, 1, _
    '                                                                           iidestado_registrado, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function
    Public Function Actualizarecojoacordadodetalle() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_actualiza_pactado_dia_hora", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidentrega_recojo_dia_hora", iidentrega_recojo_dia_hora, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidrecojo_carga_pactado", iidrecojo_carga_pactado, OracleClient.OracleType.Int32)
            db.AsignarParametro("idia_semana", idia_semana, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidtipo_pacto", iidtipo_pacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("vhora_inicio", vhora_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vhora_final", vhora_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("idia_activo", idia_activo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ipeso_kg", dpeso_kg, OracleClient.OracleType.Number)
            db.AsignarParametro("ivolumen", dvolumen, OracleClient.OracleType.Number)
            db.AsignarParametro("iidusuario_personal", iidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("vip", vip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iidrol_usuario", iidrol_usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidestado_registro", iidestado_registrado, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCur_msg", OracleClient.OracleType.Cursor)
            db.AsignarParametro("Ocur_Datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function Getrecojoacordadodetalle2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.GET_RECOJO_ACORDADO_DIA", 4, iidrecojo_carga_pactado, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function
    Public Function Getrecojoacordadodetalle() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.GET_RECOJO_ACORDADO_DIA", CommandType.StoredProcedure)
            db.AsignarParametro("iidrecojo_carga_pactado", iidrecojo_carga_pactado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocursor_recojo_acordado", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCURSOR_recojo_acordado_dia", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function Eliminarrecojoacordadodetalle2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.Sp_elimina_recojo_detalle", 10, _
    '                                                                           iidentrega_recojo_dia_hora, 1, _
    '                                                                           iidusuario_personal, 1, _
    '                                                                           vip, 2, _
    '                                                                           iidrol_usuario, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function
    Public Function Eliminarrecojoacordadodetalle() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.Sp_elimina_recojo_detalle", CommandType.StoredProcedure)
            db.AsignarParametro("iidentrega_recojo_dia_hora", iidentrega_recojo_dia_hora, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidusuario_personalmod", iidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("iipmod", vip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iidrol_usuariomod", OracleClient.OracleType.Int32)
            db.AsignarParametro("oCur_msg", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

End Class