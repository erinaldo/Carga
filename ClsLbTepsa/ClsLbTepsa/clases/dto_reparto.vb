Imports AccesoDatos
Public Class dto_reparto
#Region "Variables"
    Dim my_idunidad_agencia As Long
    Dim my_idagencia As Long
    Dim my_idusuario_responsable As Long
    Dim my_fecha_inicio As String
    Dim my_fecha_fin As String
    Dim my_tipo_operacion As String

#End Region
#Region "Propiedades"
    Public Property idtipo_operacion() As String
        Get
            idtipo_operacion = my_tipo_operacion
        End Get
        Set(ByVal value As String)
            my_tipo_operacion = value
        End Set
    End Property
    Public Property fecha_fin() As String
        Get
            fecha_fin = my_fecha_fin
        End Get
        Set(ByVal value As String)
            my_fecha_fin = value
        End Set
    End Property
    Public Property fecha_inicio() As String
        Get
            fecha_inicio = my_fecha_inicio
        End Get
        Set(ByVal value As String)
            my_fecha_inicio = value
        End Set
    End Property
    Public Property idusuario_responsable() As Long
        Get
            idusuario_responsable = my_idusuario_responsable
        End Get
        Set(ByVal value As Long)
            my_idusuario_responsable = value
        End Set
    End Property
    Public Property idagencia() As Long
        Get
            idagencia = my_idagencia
        End Get
        Set(ByVal value As Long)
            my_idagencia = value
        End Set
    End Property
    Public Property idunidad_agencia() As Long
        Get
            idunidad_agencia = my_idunidad_agencia
        End Get
        Set(ByVal value As Long)
            my_idunidad_agencia = value
        End Set
    End Property
#End Region
#Region "Procedimientos y Funciones"
    'Public Function Fn_resumen_movil_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        '
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_REP_OPERACIONES_MOVILES.sp_get_reparto_movil_resumen"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idunidad_agencia", OracleClient.OracleType.Number)).Value = idunidad_agencia
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idagencia", OracleClient.OracleType.Number)).Value = idagencia
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idusuario_responsable", OracleClient.OracleType.Number)).Value = idusuario_responsable
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_fec_ini", OracleClient.OracleType.VarChar)).Value = my_fecha_inicio
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_fec_fin", OracleClient.OracleType.VarChar)).Value = my_fecha_fin
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_tipo_operacion", OracleClient.OracleType.VarChar)).Value = idtipo_operacion
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_consulta", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Dim dv As New DataView

    '        dv = ds.Tables(0).DefaultView
    '        '
    '        Return dv
    '        '
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    '
    'End Function
    Public Function Fn_resumen_movil() As DataView
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            db.Conectar()
            db.CrearComando("PKG_REP_OPERACIONES_MOVILES.sp_get_reparto_movil_resumen", CommandType.StoredProcedure)
            '
            db.AsignarParametro("ni_idunidad_agencia", idunidad_agencia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idagencia", idagencia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idusuario_responsable", idusuario_responsable, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_fec_ini", my_fecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fec_fin", my_fecha_fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_tipo_operacion", idtipo_operacion, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("ocur_consulta", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            ldt_tmp = db.EjecutarDataTable

            Return ldt_tmp.DefaultView

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function Fn_resumen_x_punto_entrega_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        '
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_REP_OPERACIONES_MOVILES.sp_get_movil_resumen_x_entrega"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idunidad_agencia", OracleClient.OracleType.Number)).Value = idunidad_agencia
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idagencia", OracleClient.OracleType.Number)).Value = idagencia
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idusuario_responsable", OracleClient.OracleType.Number)).Value = idusuario_responsable
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_fec_ini", OracleClient.OracleType.VarChar)).Value = my_fecha_inicio
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_fec_fin", OracleClient.OracleType.VarChar)).Value = my_fecha_fin
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_tipo_operacion", OracleClient.OracleType.VarChar)).Value = idtipo_operacion
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_consulta", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Dim dv As New DataView

    '        dv = ds.Tables(0).DefaultView
    '        '
    '        Return dv
    '        '
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    '
    'End Function
    Public Function Fn_resumen_x_punto_entrega() As DataView
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            db.Conectar()
            db.CrearComando("PKG_REP_OPERACIONES_MOVILES.sp_get_movil_resumen_x_entrega", CommandType.StoredProcedure)
            '
            db.AsignarParametro("ni_idunidad_agencia", idunidad_agencia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idagencia", idagencia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idusuario_responsable", idusuario_responsable, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_fec_ini", my_fecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fec_fin", my_fecha_fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_tipo_operacion", idtipo_operacion, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("ocur_consulta", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function reparto_movil_detalle_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        '
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_REP_OPERACIONES_MOVILES.sp_get_reparto_movil"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idunidad_agencia", OracleClient.OracleType.Number)).Value = idunidad_agencia
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idagencia", OracleClient.OracleType.Number)).Value = idagencia
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idusuario_responsable", OracleClient.OracleType.Number)).Value = idusuario_responsable
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_fec_ini", OracleClient.OracleType.VarChar)).Value = my_fecha_inicio
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_fec_fin", OracleClient.OracleType.VarChar)).Value = my_fecha_fin
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_tipo_operacion", OracleClient.OracleType.VarChar)).Value = idtipo_operacion
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_consulta", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Dim dv As New DataView

    '        dv = ds.Tables(0).DefaultView
    '        '
    '        Return dv
    '        '
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    '
    'End Function
    Public Function reparto_movil_detalle() As DataView
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            db.Conectar()
            db.CrearComando("PKG_REP_OPERACIONES_MOVILES.sp_get_reparto_movil", CommandType.StoredProcedure)
            '
            db.AsignarParametro("ni_idunidad_agencia", idunidad_agencia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idagencia", idagencia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idusuario_responsable", idusuario_responsable, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_fec_ini", my_fecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fec_fin", my_fecha_fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_tipo_operacion", idtipo_operacion, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("ocur_consulta", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function reparto_movil_xpto_entrega_detalle_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        '
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_REP_OPERACIONES_MOVILES.sp_get_movil_x_entrega"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idunidad_agencia", OracleClient.OracleType.Number)).Value = idunidad_agencia
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idagencia", OracleClient.OracleType.Number)).Value = idagencia
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idusuario_responsable", OracleClient.OracleType.Number)).Value = idusuario_responsable
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_fec_ini", OracleClient.OracleType.VarChar)).Value = my_fecha_inicio
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_fec_fin", OracleClient.OracleType.VarChar)).Value = my_fecha_fin
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_tipo_operacion", OracleClient.OracleType.VarChar)).Value = idtipo_operacion
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_consulta", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Dim dv As New DataView

    '        dv = ds.Tables(0).DefaultView
    '        '
    '        Return dv
    '        '
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    '
    'End Function

    Public Function reparto_movil_xpto_entrega_detalle() As DataView
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            db.Conectar()
            db.CrearComando("PKG_REP_OPERACIONES_MOVILES.sp_get_movil_x_entrega", CommandType.StoredProcedure)
            '
            db.AsignarParametro("ni_idunidad_agencia", idunidad_agencia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idagencia", idagencia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idusuario_responsable", idusuario_responsable, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_fec_ini", my_fecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fec_fin", my_fecha_fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_tipo_operacion", idtipo_operacion, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("ocur_consulta", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function reparto_entrega_detalle_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        '
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_REP_OPERACIONES_MOVILES.sp_get_movil_x_entrega"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idunidad_agencia", OracleClient.OracleType.Number)).Value = idunidad_agencia
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idagencia", OracleClient.OracleType.Number)).Value = idagencia
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idusuario_responsable", OracleClient.OracleType.Number)).Value = idusuario_responsable
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_fec_ini", OracleClient.OracleType.VarChar)).Value = my_fecha_inicio
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_fec_fin", OracleClient.OracleType.VarChar)).Value = my_fecha_fin
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_tipo_operacion", OracleClient.OracleType.VarChar)).Value = idtipo_operacion
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_consulta", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Dim dv As New DataView

    '        dv = ds.Tables(0).DefaultView
    '        '
    '        Return dv
    '        '
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    '
    'End Function
    Public Function reparto_entrega_detalle() As DataView       
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            db.Conectar()
            db.CrearComando("PKG_REP_OPERACIONES_MOVILES.sp_get_movil_x_entrega", CommandType.StoredProcedure)
            '
            db.AsignarParametro("ni_idunidad_agencia", idunidad_agencia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idagencia", idagencia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idusuario_responsable", idusuario_responsable, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_fec_ini", my_fecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fec_fin", my_fecha_fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_tipo_operacion", idtipo_operacion, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("ocur_consulta", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function reparto_x_incidencia_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try  'Creado 13/08/2009 
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        '
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_REP_OPERACIONES_MOVILES.sp_get_movil_incidencia"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idunidad_agencia", OracleClient.OracleType.Number)).Value = idunidad_agencia
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idagencia", OracleClient.OracleType.Number)).Value = idagencia
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idusuario_responsable", OracleClient.OracleType.Number)).Value = idusuario_responsable
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_fec_ini", OracleClient.OracleType.VarChar)).Value = my_fecha_inicio
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_fec_fin", OracleClient.OracleType.VarChar)).Value = my_fecha_fin
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_tipo_operacion", OracleClient.OracleType.VarChar)).Value = idtipo_operacion
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_consulta", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Dim dv As New DataView

    '        dv = ds.Tables(0).DefaultView
    '        '
    '        Return dv
    '        '
    '    Catch Ex As System.Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    '
    'End Function
    Public Function reparto_x_incidencia() As DataView
        Try  'Creado 13/08/2009 
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            db.Conectar()
            db.CrearComando("PKG_REP_OPERACIONES_MOVILES.sp_get_movil_incidencia", CommandType.StoredProcedure)
            '
            db.AsignarParametro("ni_idunidad_agencia", idunidad_agencia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idagencia", idagencia, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idusuario_responsable", idusuario_responsable, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_fec_ini", my_fecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fec_fin", my_fecha_fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_tipo_operacion", idtipo_operacion, OracleClient.OracleType.VarChar)
            '
            db.AsignarParametro("ocur_consulta", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class