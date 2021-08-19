Imports AccesoDatos
Public Class dto_asocia_ciudad_ruta
#Region "Variables"
    Dim ll_nro_salida As Long
    Dim ll_idciudad_ruta As Long
    Dim ll_idciudad_asocia As Long
    Dim ll_idusuario_personal As Long
    '
#End Region
#Region "Atributos"
    Public Property idusuario_personal() As Long
        Get
            idusuario_personal = ll_idusuario_personal
        End Get
        Set(ByVal value As Long)
            ll_idusuario_personal = value
        End Set
    End Property
    Public Property idciudad_asocia() As Long
        Get
            idciudad_asocia = ll_idciudad_asocia
        End Get
        Set(ByVal value As Long)
            ll_idciudad_asocia = value
        End Set
    End Property

    Public Property idciudad_ruta() As Long
        Get
            idciudad_ruta = ll_idciudad_ruta
        End Get
        Set(ByVal value As Long)
            ll_idciudad_ruta = value
        End Set
    End Property
    Public Property idnro_salida() As Long
        Get
            idnro_salida = ll_nro_salida
        End Get
        Set(ByVal value As Long)
            ll_nro_salida = value
        End Set
    End Property
#End Region
#Region "Métodos"
    'Public Function sp_get_ciudad_asocia_salida2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataTable
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    'Parámetro de salida 
    '    cmd.CommandText = "PKG_IVOTRANSPORTE_CARGA.sp_get_ciudad_asocia_salida"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idnro_salida", OracleClient.OracleType.Number)).Value = idnro_salida
    '    'Parámetro de salida 
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("co_ciudad_asocia_salida", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
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
    'Public Function sp_get_ciudad_asocia_ruta2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataTable
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    'Parámetro de salida 
    '    cmd.CommandText = "PKG_IVOTRANSPORTE_CARGA.sp_get_ciudad_asocia_ruta"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idnro_salida", OracleClient.OracleType.Number)).Value = idnro_salida
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idciudad_ruta", OracleClient.OracleType.Number)).Value = idciudad_ruta
    '    'Parámetro de salida 
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("co_ciudad_asocia_ruta", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
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
    'Public Function sp_get_escoje_ciudad_asocia2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataTable
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    'Parámetro de salida 
    '    cmd.CommandText = "PKG_IVOTRANSPORTE_CARGA.sp_get_escoje_ciudad_asocia"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idnro_salida", OracleClient.OracleType.Number)).Value = idnro_salida
    '    'Parámetro de salida 
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("co_ciudad_asocia", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Try
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Dim dt As New DataTable
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
    'Public Function sp_registra_ciudad_asocia2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataSet
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    'Parámetro de salida 
    '    cmd.CommandText = "PKG_IVOTRANSPORTE_CARGA.sp_registra_ciudad_asocia"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idnro_salida", OracleClient.OracleType.Number)).Value = idnro_salida
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_ciudad_ruta", OracleClient.OracleType.Number)).Value = idciudad_ruta
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_ciudad_asocia", OracleClient.OracleType.Number)).Value = idciudad_asocia
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idusuario_personal", OracleClient.OracleType.Number)).Value = idusuario_personal
    '    'Parámetro de salida 
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("co_mensaje", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("co_ciudad_asocia_rutas", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Try
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Return ds
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        '
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function sp_elimina_ciudad_asocia2009(ByVal cnn As Data.OracleClient.OracleConnection) As DataSet
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    'Parámetro de salida 
    '    cmd.CommandText = "PKG_IVOTRANSPORTE_CARGA.sp_elimina_ciudad_asocia"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idnro_salida", OracleClient.OracleType.Number)).Value = idnro_salida
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idunidad_agencia_ruta", OracleClient.OracleType.Number)).Value = idciudad_ruta
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idunidad_agencia_asocia", OracleClient.OracleType.Number)).Value = idciudad_asocia
    '    'Parámetro de salida 
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("co_mensaje", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("co_ciudad_asocia_rutas", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Try
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Return ds
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        '
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Public Function sp_get_ciudad_asocia_salida() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_get_ciudad_asocia_salida", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idnro_salida", idnro_salida, OracleClient.OracleType.Number)
            db.AsignarParametro("co_ciudad_asocia_salida", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function sp_get_escoje_ciudad_asocia() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_get_escoje_ciudad_asocia", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idnro_salida", idnro_salida, OracleClient.OracleType.Number)
            db.AsignarParametro("co_ciudad_asocia", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function sp_get_ciudad_asocia_ruta() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_get_ciudad_asocia_ruta", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idnro_salida", idnro_salida, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idciudad_ruta", idciudad_ruta, OracleClient.OracleType.Number)
            db.AsignarParametro("co_ciudad_asocia_ruta", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function sp_registra_ciudad_asocia() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_registra_ciudad_asocia ", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idnro_salida", idnro_salida, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_ciudad_ruta", idciudad_ruta, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_ciudad_asocia", idciudad_asocia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idusuario_personal", idusuario_personal, OracleClient.OracleType.Number)
            '
            db.AsignarParametro("co_mensaje", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_ciudad_asocia_rutas", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function sp_elimina_ciudad_asocia() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOTRANSPORTE_CARGA.sp_elimina_ciudad_asocia", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idnro_salida", idnro_salida, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idunidad_agencia_ruta", idciudad_ruta, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idunidad_agencia_asocia", idciudad_asocia, OracleClient.OracleType.Number)
            db.AsignarParametro("co_mensaje", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_ciudad_asocia_rutas", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class
