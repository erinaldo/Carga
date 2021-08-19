Imports AccesoDatos
Public Class dtoGuias_Envio_Prefactura
#Region "VARIABLES"
    Dim MyIDFACTURA As Integer
    Dim MyFECHA_REGISTRO As String
    Dim MyIDPREFACTURA As Integer
    Dim MyIDGUIAS_ENVIO As Integer
    Dim MyIDUSUARIO_PERSONAL As Integer
    Dim MyIDROL_USUARIO As Integer
    Dim MyIP As String
#End Region
#Region "PROPIEDADES"

    Public Property IDFACTURA() As Integer
        Get
            IDFACTURA = MyIDFACTURA
        End Get
        Set(ByVal value As Integer)
            MyIDFACTURA = value
        End Set
    End Property
    Public Property FECHA_REGISTRO() As String
        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = value
        End Set
    End Property
    Public Property IDPREFACTURA() As Integer
        Get
            IDPREFACTURA = MyIDPREFACTURA
        End Get
        Set(ByVal value As Integer)
            MyIDPREFACTURA = value
        End Set
    End Property
    Public Property IDGUIAS_ENVIO() As Integer
        Get
            IDGUIAS_ENVIO = MyIDGUIAS_ENVIO
        End Get
        Set(ByVal value As Integer)
            MyIDGUIAS_ENVIO = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL() As Integer
        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Integer)
            MyIDUSUARIO_PERSONAL = value
        End Set
    End Property
    Public Property IDROL_USUARIO() As Integer
        Get
            IDROL_USUARIO = MyIDROL_USUARIO
        End Get
        Set(ByVal value As Integer)
            MyIDROL_USUARIO = value
        End Set
    End Property
    Public Property IP() As String
        Get
            IP = MyIP
        End Get
        Set(ByVal value As String)
            MyIP = value
        End Set
    End Property
#End Region
#Region "METODOS"
    'Public Function fnCOMPROMETER_PREFACTU_FACTU_2009(ByVal VOCONTROLUSUARIO As Object, ByVal cnn As System.Data.OracleClient.OracleConnection) As Boolean
    '    fnCOMPROMETER_PREFACTU_FACTU = True
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOFACTURACION.SP_COMPROMETER_PREFACTU_FACTU"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ope", OracleClient.OracleType.Number)).Value = 1
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_Idfactura", OracleClient.OracleType.Number)).Value = IDFACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_IdPREFACTURA", OracleClient.OracleType.Number)).Value = IDPREFACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_Idusuario_Personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_Idrol_Usuario", OracleClient.OracleType.Number)).Value = IDROL_USUARIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_Ip", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_ERR", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        'Dim ds As New DataSet
    '        daora.Fill(ds)
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        fnCOMPROMETER_PREFACTU_FACTU = False
    '    End Try

    '    'Try
    '    '    Dim Rst As New ADODB.Recordset
    '    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_COMPROMETER_PREFACTU_FACTU", 14, _
    '    '    1, 1, _
    '    '    IDFACTURA, 1, _
    '    '    IDPREFACTURA, 1, _
    '    '    IDUSUARIO_PERSONAL, 1, _
    '    '    IDROL_USUARIO, 1, _
    '    '    IP, 2}
    '    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    'Catch ex As Exception
    '    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    '    fnCOMPROMETER_PREFACTU_FACTU = False
    '    'End Try
    'End Function
    Public Function fnCOMPROMETER_PREFACTU_FACTU() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_COMPROMETER_PREFACTU_FACTU", CommandType.StoredProcedure)
            db.AsignarParametro("ope", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_Idfactura", IDFACTURA, OracleClient.OracleType.Number)
            db.AsignarParametro("p_IdPREFACTURA", IDPREFACTURA, OracleClient.OracleType.Number)
            db.AsignarParametro("p_Idusuario_Personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db.AsignarParametro("p_Idrol_Usuario", IDROL_USUARIO, OracleClient.OracleType.Number)
            db.AsignarParametro("p_Ip", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            db.EjecutarDataTable()
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnCOMPROMETER_GUIAS_FACTU_2009(ByVal VOCONTROLUSUARIO As Object, ByVal cnn As System.Data.OracleClient.OracleConnection) As Boolean
    '    fnCOMPROMETER_GUIAS_FACTU = True
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOFACTURACION.SP_COMPROMETER_GUIAS_FACTU"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ope", OracleClient.OracleType.Number)).Value = 1
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_Idfactura", OracleClient.OracleType.Number)).Value = IDFACTURA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_Idguias_Envio", OracleClient.OracleType.Number)).Value = IDGUIAS_ENVIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_Idusuario_Personal", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_Idrol_Usuario", OracleClient.OracleType.Number)).Value = IDROL_USUARIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_Ip", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_ERR", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        fnCOMPROMETER_GUIAS_FACTU = False
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        fnCOMPROMETER_GUIAS_FACTU = False
    '    End Try
    '    'Try
    '    '    Dim Rst As New ADODB.Recordset
    '    '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTURACION.SP_COMPROMETER_GUIAS_FACTU", 14, _
    '    '    1, 1, _
    '    '    IDFACTURA, 1, _
    '    '    IDGUIAS_ENVIO, 1, _
    '    '    IDUSUARIO_PERSONAL, 1, _
    '    '    IDROL_USUARIO, 1, _
    '    '    IP, 2}
    '    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    'Catch ex As Exception
    '    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    '    fnCOMPROMETER_GUIAS_FACTU = False
    '    'End Try
    'End Function
    Public Function fnCOMPROMETER_GUIAS_FACTU() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.SP_COMPROMETER_GUIAS_FACTU", CommandType.StoredProcedure)
            db.AsignarParametro("ope", 1, OracleClient.OracleType.Number)
            db.AsignarParametro("p_Idfactura", IDFACTURA, OracleClient.OracleType.Number)
            db.AsignarParametro("p_Idguias_Envio", IDGUIAS_ENVIO, OracleClient.OracleType.Number)
            db.AsignarParametro("p_Idusuario_Personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Number)
            db.AsignarParametro("p_Idrol_Usuario", IDROL_USUARIO, OracleClient.OracleType.Number)
            db.AsignarParametro("p_Ip", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_ERR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            db.EjecutarDataTable()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class
