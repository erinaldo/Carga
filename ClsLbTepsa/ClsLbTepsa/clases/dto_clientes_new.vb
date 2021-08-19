Imports AccesoDatos
Public Class dto_clientes_new
#Region "Variables"
    Dim ll_idpersona As Long
    Dim ls_login As String
    Dim ls_password As String
    Dim ll_nro_digito_serie As Long
    '
#End Region
#Region "Atributos"
    Public Property idpersona() As Long
        Get
            idpersona = ll_idpersona
        End Get
        Set(ByVal value As Long)
            ll_idpersona = value
        End Set
    End Property
    Public Property login() As String
        Get
            login = ls_login
        End Get
        Set(ByVal value As String)
            ls_login = value
        End Set
    End Property
    Public Property password() As String
        Get
            password = ls_password
        End Get
        Set(ByVal value As String)
            ls_password = value
        End Set
    End Property
    Public Property nro_digito_serie() As Long
        Get
            nro_digito_serie = ll_nro_digito_serie
        End Get
        Set(ByVal value As Long)
            ll_nro_digito_serie = value
        End Set
    End Property
#End Region
#Region "Métodos"

    'Public Function sp_get_configurar_clte_2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataTable
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    'Parámetro de salida 
    '    cmd.CommandText = "PKG_IVOPERSONA.sp_get_configurar_clte"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idpersona", OracleClient.OracleType.Number)).Value = idpersona
    '    'Parámetro de salida 
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("co_datos", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Try
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '            
    '        Dim dt As New DataTable
    '        '
    '        dt = ds.Tables(0)
    '        '
    '        Return dt

    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        '
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Public Function sp_get_configurar_clte() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.sp_get_configurar_clte", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idpersona", idpersona, OracleClient.OracleType.Number)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function sf_actualiza_configura_clte_2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataTable
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    'Parámetro de salida 
    '    cmd.CommandText = "PKG_IVOPERSONA.sf_actualiza_configura_clte"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idpersona", OracleClient.OracleType.Number)).Value = idpersona
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("vi_login", OracleClient.OracleType.VarChar)).Value = login
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("vi_password", OracleClient.OracleType.VarChar)).Value = password
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_nro_digito", OracleClient.OracleType.Number)).Value = nro_digito_serie
    '    'Parámetro de salida 
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("oc_mensaje", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Try
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Dim dt As New DataTable
    '        '
    '        dt = ds.Tables(0)
    '        '
    '        Return dt
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        '
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Public Function sf_actualiza_configura_clte() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.sf_actualiza_configura_clte", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idpersona", idpersona, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_login", login, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_password", password, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_nro_digito", nro_digito_serie, OracleClient.OracleType.Number)
            db.AsignarParametro("oc_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class
