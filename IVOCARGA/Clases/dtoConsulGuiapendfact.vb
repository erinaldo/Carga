Imports AccesoDatos
Public Class dtoconsultguiapendfact
#Region "Recordset"
    'Public cur_datos As New ADODB.Recordset
    'Public cur_Error As New ADODB.Recordset
#End Region
#Region "Propiedades"
    Public i_idunidad_agencia As Long
    Public i_idunidad_agencia_destino As Long
    Private m_iidtipo_facturacion As Integer
    Private m_codigo_cliente As String
    Private m_sfecha_hasta As String
    Private m_sfecha_desde As String
    Private m_idfuncionario As Integer
    Private ll_idcentro_costo As Long
    Public Property idcentro_costo() As Long
        Get
            Return ll_idcentro_costo
        End Get
        Set(ByVal value As Long)
            ll_idcentro_costo = value
        End Set
    End Property
    Public Property codigo_cliente() As String
        Get
            Return m_codigo_cliente
        End Get
        Set(ByVal value As String)
            m_codigo_cliente = value
        End Set
    End Property
    Public Property idtipo_facturacion() As Integer
        Get
            Return m_iidtipo_facturacion
        End Get
        Set(ByVal value As Integer)
            m_iidtipo_facturacion = value
        End Set
    End Property
    Public Property sfecha_hasta() As String
        Get
            Return m_sfecha_hasta
        End Get
        Set(ByVal value As String)
            m_sfecha_hasta = value
        End Set
    End Property
    Public Property sfecha_desde() As String
        Get
            Return m_sfecha_desde
        End Get
        Set(ByVal value As String)
            m_sfecha_desde = value
        End Set
    End Property
    Public Property funcionario() As Integer
        Get
            Return m_idfuncionario
        End Get
        Set(ByVal value As Integer)
            m_idfuncionario = value
        End Set
    End Property

    Private intProducto As Integer
    Public Property Producto() As Integer
        Get
            Return intProducto
        End Get
        Set(ByVal value As Integer)
            intProducto = value
        End Set
    End Property

#End Region
#Region "METODOS"
    'Public Function fngettipofacturacion_2009() As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOUUTILS.sp_get_tipo_facturacion", 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fngettipofacturacion() As DataSet
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOUUTILS.sp_get_tipo_facturacion", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            ' Sin Parametros 
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_tipofacturacion", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_tipo_reporte", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("ocur_usuario", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnClientes_allGuiaSinFacturar_2009() As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.SP_GUIAS_SINFACTURAR_new", 10, _
    '        'Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.SP_GUIAS_SINFACTURAR", 12, _
    '        Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.SP_GUIAS_SINFACTURAR_3", 18, _
    '                                                             m_codigo_cliente, 2, _
    '                                                             m_iidtipo_facturacion, 1, _
    '                                                             m_idfuncionario, 1, _
    '                                                             m_sfecha_desde, 2, _
    '                                                             m_sfecha_hasta, 2, _
    '                                                             ll_idcentro_costo, 1, _
    '                                                            i_idunidad_agencia, 1, _
    '                                                            i_idunidad_agencia_destino, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnClientes_allGuiaSinFacturar() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.SP_GUIAS_SINFACTURAR_3", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("icodigo_cliente", m_codigo_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidtipo_facturacion", m_iidtipo_facturacion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidfuncionario_actual", m_idfuncionario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vfecha_desde", m_sfecha_desde, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_hasta", m_sfecha_hasta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idcentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia", i_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", i_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnGuias_SinFacturarxcliente_2009() As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_get_guiasinfactura_xcliente", 8, _
    '        'Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_get_guiasinfacturar_new", 10, _
    '        'Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_get_guiasinfacturar", 12, _
    '        Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_get_guiasinfacturar3", 18, _
    '                                                             m_codigo_cliente, 2, _
    '                                                             m_iidtipo_facturacion, 1, _
    '                                                             m_idfuncionario, 1, _
    '                                                             m_sfecha_desde, 2, _
    '                                                             m_sfecha_hasta, 2, _
    '                                                             ll_idcentro_costo, 1, _
    '                                                             i_idunidad_agencia, 1, _
    '                                                             i_idunidad_agencia_destino, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnGuias_SinFacturarxcliente() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            'hlamas 06-01-2014
            'db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.SP_GET_GUIASINFACTURAR3", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_get_guiasinfacturar33", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("icodigo_cliente", m_codigo_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidtipo_facturacion", m_iidtipo_facturacion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidfuncionario_actual", m_idfuncionario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vfecha_desde", m_sfecha_desde, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_hasta", m_sfecha_hasta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idcentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia", i_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", i_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_guiassinfacturar", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnGuias_SinPreFacturarxcliente_2009() As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_obt_guias_sin_prefacturar", 8, _
    '                                                             m_codigo_cliente, 2, _
    '                                                             m_sfecha_desde, 2, _
    '                                                             m_sfecha_hasta, 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnGuias_SinPreFacturarxcliente() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_obt_guias_sin_prefacturar", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("icodigo_cliente", m_codigo_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ifec_desde", m_sfecha_desde, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ifec_hasta", m_sfecha_hasta, OracleClient.OracleType.VarChar)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_guiassinprectura", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnGuias_prefacturadas_2009() As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_obt_guias_prefacturar", 8, _
    '        'Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_obt_guias_prefacturar_new", 10, _
    '        'Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_obt_guias_prefacturar", 12, _
    '        Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_obt_guias_prefacturar3", 18, _
    '                                                             m_codigo_cliente, 2, _
    '                                                             m_iidtipo_facturacion, 1, _
    '                                                             m_idfuncionario, 1, _
    '                                                             m_sfecha_desde, 2, _
    '                                                             m_sfecha_hasta, 2, _
    '                                                             ll_idcentro_costo, 1, _
    '                                                             i_idunidad_agencia, 1, _
    '                                                             i_idunidad_agencia_destino, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    Public Function GuiasinFacturar() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_ge_sin_facturar", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("icodigo_cliente", m_codigo_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidtipo_facturacion", m_iidtipo_facturacion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidfuncionario_actual", m_idfuncionario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vfecha_desde", m_sfecha_desde, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_hasta", m_sfecha_hasta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idcentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia", i_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", i_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_guiafacturar", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function


    Public Function fnGuias_prefacturadas() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_obt_guias_prefacturar3", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("icodigo_cliente", m_codigo_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidtipo_facturacion", m_iidtipo_facturacion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidfuncionario", m_idfuncionario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ifec_desde", m_sfecha_desde, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ifec_hasta", m_sfecha_hasta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idcentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia", i_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", i_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_guiassinprectura", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnGuias_consolida_prefactura_2009() As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_consolida_guiaprefactura", 12, _
    '        'Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_consolida_guiaprefac_new", 12, _
    '        Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_consolida_guiaprefac_3", 18, _
    '                                                             m_codigo_cliente, 2, _
    '                                                             m_iidtipo_facturacion, 1, _
    '                                                             m_idfuncionario, 1, _
    '                                                             m_sfecha_desde, 2, _
    '                                                             m_sfecha_hasta, 2, _
    '                                                             ll_idcentro_costo, 1, _
    '                                                             i_idunidad_agencia, 1, _
    '                                                             i_idunidad_agencia_destino, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    Public Function GuiasinFacturarResumen() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_guia_sin_facturar_resumen", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("icodigo_cliente", m_codigo_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidtipo_facturacion", m_iidtipo_facturacion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidfuncionario_actual", m_idfuncionario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vfecha_desde", m_sfecha_desde, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_hasta", m_sfecha_hasta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idcentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia", i_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", i_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function


    Public Function fnGuias_consolida_prefactura() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_consolida_guiaprefac_3", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("vcodigo_cliente", m_codigo_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidtipo_facturacion", m_iidtipo_facturacion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidfuncionario_actual", m_idfuncionario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vfecha_desde", m_sfecha_desde, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_hasta", m_sfecha_hasta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idcentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia", i_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", i_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnGuias_consolida_factura_2009() As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_consolida_guiafactura", 10, _
    '        'Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_consolida_guiafactura_new", 12, _
    '        Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_consolida_guiafactura_3", 18, _
    '                                                             m_codigo_cliente, 2, _
    '                                                             m_iidtipo_facturacion, 1, _
    '                                                             m_idfuncionario, 1, _
    '                                                             m_sfecha_desde, 2, _
    '                                                             m_sfecha_hasta, 2, _
    '                                                             ll_idcentro_costo, 1, _
    '                                                             i_idunidad_agencia, 1, _
    '                                                             i_idunidad_agencia_destino, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnGuias_consolida_factura() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_consolida_guiafactura_3", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("vcodigo_cliente", m_codigo_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidtipo_facturacion", m_iidtipo_facturacion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidfuncionario", m_idfuncionario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vfecha_desde", m_sfecha_desde, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_hasta", m_sfecha_hasta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ll_idcentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia", i_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", i_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnGuias_facturas_2009() As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_obt_guias_factura_new", 12, _
    '        Dim varSP_OBJECT() As Object = {"PKG_REP_GUIAS_ENVIO.sp_obt_guias_factura3", 18, _
    '                                                             m_codigo_cliente, 2, _
    '                                                             m_iidtipo_facturacion, 1, _
    '                                                             m_idfuncionario, 1, _
    '                                                             m_sfecha_desde, 2, _
    '                                                             m_sfecha_hasta, 2, _
    '                                                             ll_idcentro_costo, 1, _
    '                                                             i_idunidad_agencia, 1, _
    '                                                             i_idunidad_agencia_destino, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnGuias_facturas() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_obt_guias_factura3", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("icodigo_cliente", m_codigo_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidtipo_facturacion", m_iidtipo_facturacion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidfuncionario", m_idfuncionario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ifec_desde", m_sfecha_desde, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ifec_hasta", m_sfecha_hasta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idcentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia", i_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", i_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_guiafactura", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function ListarGuiaSinprefacturar() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            'hlamas 06-01-2014
            'db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.SP_GET_GUIASINFACTURAR3", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_listar_ge_sinprefacturar", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("icodigo_cliente", m_codigo_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidtipo_facturacion", m_iidtipo_facturacion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidfuncionario_actual", m_idfuncionario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vfecha_desde", m_sfecha_desde, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_hasta", m_sfecha_hasta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idcentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia", i_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", i_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_guiassinfacturar", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function ListarGuiaPrefacturada() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_listar_ge_prefacturada", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("icodigo_cliente", m_codigo_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidtipo_facturacion", m_iidtipo_facturacion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidfuncionario", m_idfuncionario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ifec_desde", m_sfecha_desde, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ifec_hasta", m_sfecha_hasta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idcentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia", i_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", i_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_guiassinprectura", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function ListarGuiaFacturada() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_listar_ge_facturada", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("icodigo_cliente", m_codigo_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidtipo_facturacion", m_iidtipo_facturacion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidfuncionario", m_idfuncionario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ifec_desde", m_sfecha_desde, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ifec_hasta", m_sfecha_hasta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idcentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia", i_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", i_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_guiafactura", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function ListarGuiaSinFacturar() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.sp_listar_ge_sin_facturar", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("icodigo_cliente", m_codigo_cliente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iidtipo_facturacion", m_iidtipo_facturacion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iidfuncionario_actual", m_idfuncionario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vfecha_desde", m_sfecha_desde, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vfecha_hasta", m_sfecha_hasta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idcentro_costo", ll_idcentro_costo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia", i_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", i_idunidad_agencia_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("ocur_guiafacturar", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado - Para datatable 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class