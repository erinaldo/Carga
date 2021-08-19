Imports AccesoDatos
Public Class dtoGuiasTranspDet
    Private StAccion As Integer
    Private StId As Integer
    Private StGuiaT As Integer
    Private StCantidad As Integer
    Private StTotPeso As Double
    Private StTotVolumen As Double
    Private StNroDoc As String
    Private StTipoComp As Integer
    Private StComprobante As Integer
    Private StUsuario As Integer
    Private StRol As Integer
    Private StIP As String
    Private StEstado As Integer

    Public Property Accion() As Integer
        Get
            Return StAccion
        End Get
        Set(ByVal value As Integer)
            StAccion = value
        End Set
    End Property
    Public Property ID() As Integer
        Get
            Return StId
        End Get
        Set(ByVal value As Integer)
            StId = value
        End Set
    End Property
    Public Property IDGuia() As Long
        Get
            Return StGuiaT
        End Get
        Set(ByVal value As Long)
            StGuiaT = value
        End Set
    End Property
    Public Property Cantidad() As Integer
        Get
            Return StCantidad
        End Get
        Set(ByVal value As Integer)
            StCantidad = value
        End Set
    End Property
    Public Property TotPeso() As Double
        Get
            Return StTotPeso
        End Get
        Set(ByVal value As Double)
            StTotPeso = value
        End Set
    End Property
    Public Property TotVolumen() As Double
        Get
            Return StTotVolumen
        End Get
        Set(ByVal value As Double)
            StTotVolumen = value
        End Set
    End Property
    Public Property NroDoc() As String
        Get
            Return StNroDoc
        End Get
        Set(ByVal value As String)
            StNroDoc = value
        End Set
    End Property

    Public Property TipoComp() As Integer
        Get
            Return StTipoComp
        End Get
        Set(ByVal value As Integer)
            StTipoComp = value
        End Set
    End Property
    Public Property Comprobante() As Integer
        Get
            Return StComprobante
        End Get
        Set(ByVal value As Integer)
            StComprobante = value
        End Set
    End Property
    Public Property Usuario() As Integer
        Get
            Return StUsuario
        End Get
        Set(ByVal value As Integer)
            StUsuario = value
        End Set
    End Property
    Public Property Rol() As Integer
        Get
            Return StRol
        End Get
        Set(ByVal value As Integer)
            StRol = value
        End Set
    End Property
    Public Property IP() As String
        Get
            Return StIP
        End Get
        Set(ByVal value As String)
            StIP = value
        End Set
    End Property
    Public Property Estado() As Integer
        Get
            Return StEstado
        End Get
        Set(ByVal value As Integer)
            StEstado = value
        End Set
    End Property
    'Public Function Lista_2009() As ADODB.Recordset
    '    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_GUIASTRANSP_DETALLE", 4, StId, 1}
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_GUIASTRANSP_DETALLE1", 4, CType(StId, String), 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Lista() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_GUIASTRANSP_DETALLE1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIDGUIA_TRANSPORTISTA", CType(StId, String), OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_detalle", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function Grabar_2009() As ADODB.Recordset
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_GUIAS_TRANSPORTE_DET", 28, StAccion, 1, StId, 1, StGuiaT, 1, StCantidad, 1, StTotPeso, 3, StTotVolumen, 3, StNroDoc, 2, StTipoComp, 1, StComprobante, 1, StEstado, 1, StUsuario, 1, StRol, 1, StIP, 2}
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_GUIAS_TRANSPORTEDET1", 28, StAccion, 1, StId, 1, CType(StGuiaT, String), 2, StCantidad, 1, StTotPeso, 3, StTotVolumen, 3, StNroDoc, 2, StTipoComp, 1, StComprobante, 1, StEstado, 1, StUsuario, 1, StRol, 1, StIP, 2}
    '    ' Mod 07/12/2007 
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_GUIAS_TRANSPORTEDET2", 28, StAccion, 1, CType(StId, String), 2, CType(StGuiaT, String), 2, StCantidad, 1, StTotPeso, 3, StTotVolumen, 3, StNroDoc, 2, StTipoComp, 1, CType(StComprobante, String), 2, StEstado, 1, StUsuario, 1, StRol, 1, StIP, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Grabar() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_GUIAS_TRANSPORTEDET2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", StAccion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("viIDGUIA_TRANSPORTISTA_DETALL", CType(StId, String), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDGUIA_TRANSPORTISTA", CType(StGuiaT, String), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iCANTIDAD", StCantidad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iTOTAL_PESO", StTotPeso, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iTOTAL_VOLUMEN", StTotVolumen, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iNRO_DOC", StNroDoc, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDTIPO_COMPROBANTE", StTipoComp, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("viIDCOMPROBANTE", CType(StComprobante, String), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDESTADO_REGISTRO", StEstado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", StUsuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", StRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", StIP, OracleClient.OracleType.VarChar)
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
    'Public Function fn_eliminar_det_guiatrans_2009() As ADODB.Recordset
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.sp_elimina_guia_trans_det", 4, StGuiaT, 1}
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.sp_elimina_guia_trans_det1", 4, CType(StGuiaT, String), 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    'Public Function fn_eliminar_item_gtrans_2009() As ADODB.Recordset
    '    'Elimina el item de la guia de Transportista 
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.sp_elimina_item_guia_trans", 12, _
    '                                                           CType(StId, String), 2, _
    '                                                           StCantidad, 1, _
    '                                                           dtoUSUARIOS.m_iIdAgencia, 1, _
    '                                                           dtoUSUARIOS.IP, 2, _
    '                                                           dtoUSUARIOS.IdLogin, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function fn_eliminar_item_gtrans() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.sp_elimina_item_guia_trans", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("vi_idguia_transp_detall", CType(StId, String), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_cantidad", StCantidad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_agencia_recepciona", dtoUSUARIOS.m_iIdAgencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_idusuario_personal", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
