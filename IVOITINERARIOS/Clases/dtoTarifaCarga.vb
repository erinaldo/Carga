Imports AccesoDatos
Public Class dtoTarifaCarga
    Private StAccion As Integer
    Private StID As Integer
    Private StOrigen As Integer
    Private StDestino As Integer
    Private StCMonBas As Double
    Private StCPeso As Double
    Private StCVol As Double
    Private StEMonBas As Double
    Private StEPeso As Double
    Private StEVol As Double
    Private StPMonBas As Double
    Private StPPeso As Double
    Private StPVol As Double
    Private StGMonBas As Double
    Private StGNor As Double
    Private StGTel As Double
    Private StFecIni As String
    Private StFecFin As String
    Private StVigente As Integer
    Private StUsuario As Integer
    Private StRol As Integer
    Private StIP As String
    Private StEstado As Integer
    Private StTarifa As Integer
    Private StArticulo As Integer
    Private StMonto As Double
    Private StCMonBasContado As Double
    Private StCPesoContado As Double
    Private StCVolContado As Double
    Private StCSobreContado As Double
    Private StCSobre As Double
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
            Return StID
        End Get
        Set(ByVal value As Integer)
            StID = value
        End Set
    End Property
    Public Property Origen() As Integer
        Get
            Return StOrigen
        End Get
        Set(ByVal value As Integer)
            StOrigen = value
        End Set
    End Property
    Public Property Destino() As Integer
        Get
            Return StDestino
        End Get
        Set(ByVal value As Integer)
            StDestino = value
        End Set
    End Property
    Public Property CMonBas() As Double
        Get
            Return StCMonBas
        End Get
        Set(ByVal value As Double)
            StCMonBas = value
        End Set
    End Property
    Public Property CPeso() As Double
        Get
            Return StCPeso
        End Get
        Set(ByVal value As Double)
            StCPeso = value
        End Set
    End Property
    Public Property CVol() As Double
        Get
            Return StCVol
        End Get
        Set(ByVal value As Double)
            StCVol = value
        End Set
    End Property
    Public Property EMonBas() As Double
        Get
            Return StEMonBas
        End Get
        Set(ByVal value As Double)
            StEMonBas = value
        End Set
    End Property
    Public Property EPeso() As Double
        Get
            Return StEPeso
        End Get
        Set(ByVal value As Double)
            StEPeso = value
        End Set
    End Property
    Public Property EVol() As Double
        Get
            Return StEVol
        End Get
        Set(ByVal value As Double)
            StEVol = value
        End Set
    End Property
    Public Property PMonBas() As Double
        Get
            Return StPMonBas
        End Get
        Set(ByVal value As Double)
            StPMonBas = value
        End Set
    End Property
    Public Property PPeso() As Double
        Get
            Return StPPeso
        End Get
        Set(ByVal value As Double)
            StPPeso = value
        End Set
    End Property
    Public Property PVol() As Double
        Get
            Return StPVol
        End Get
        Set(ByVal value As Double)
            StPVol = value
        End Set
    End Property
    Public Property GMonBas() As Double
        Get
            Return StGMonBas
        End Get
        Set(ByVal value As Double)
            StGMonBas = value
        End Set
    End Property
    Public Property GNormal() As Double
        Get
            Return StGNor
        End Get
        Set(ByVal value As Double)
            StGNor = value
        End Set
    End Property
    Public Property GTelefono() As Double
        Get
            Return StGTel
        End Get
        Set(ByVal value As Double)
            StGTel = value
        End Set
    End Property

    Public Property Vigente() As Integer
        Get
            Return StVigente
        End Get
        Set(ByVal value As Integer)
            StVigente = value
        End Set
    End Property
    Public Property Fecha_Ini() As String
        Get
            Return StFecIni
        End Get
        Set(ByVal value As String)
            StFecIni = value
        End Set
    End Property
    Public Property Fecha_Fin() As String
        Get
            Return StFecFin
        End Get
        Set(ByVal value As String)
            StFecFin = value
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
    Public Property Tarifa() As Integer
        Get
            Return StTarifa
        End Get
        Set(ByVal value As Integer)
            StTarifa = value
        End Set
    End Property
    Public Property Articulo() As Integer
        Get
            Return StArticulo
        End Get
        Set(ByVal value As Integer)
            StArticulo = value
        End Set
    End Property
    Public Property Monto() As Double
        Get
            Return StMonto
        End Get
        Set(ByVal value As Double)
            StMonto = value
        End Set
    End Property
    Public Property CMonBasContado() As Double
        Get
            Return StCMonBasContado
        End Get
        Set(ByVal value As Double)
            StCMonBasContado = value
        End Set
    End Property
    Public Property CPesoContado() As Double
        Get
            Return StCPesoContado
        End Get
        Set(ByVal value As Double)
            StCPesoContado = value
        End Set
    End Property
    Public Property CVolContado() As Double
        Get
            Return StCVolContado
        End Get
        Set(ByVal value As Double)
            StCVolContado = value
        End Set
    End Property
    Public Property CSobreContado() As Double
        Get
            Return StCSobreContado
        End Get
        Set(ByVal value As Double)
            StCSobreContado = value
        End Set
    End Property
    Public Property CSobre() As Double
        Get
            Return StCSobre
        End Get
        Set(ByVal value As Double)
            StCSobre = value
        End Set
    End Property
    'Public Function Lista_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_TARIFACARGA3", 0}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Lista() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_TARIFACARGA3", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas             
            db_bd.AsignarParametro("cur_tarifas", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_unidad", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_articulos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_detalle", OracleClient.OracleType.Cursor)
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
    'Public Function Buscar_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_TARIFACARGA2", 8, StID, 1, StOrigen, 1, StDestino, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Buscar() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_TARIFACARGA2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIDTARIFAS_CARGA", StID, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", StOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", StDestino, OracleClient.OracleType.Int32)
            'Variables de salidas             
            db_bd.AsignarParametro("cur_tarifas", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_articulos", OracleClient.OracleType.Cursor)
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
    'Public Function Grabar_2009() As ADODB.Recordset
    '    'hlamas
    '    'Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_TARIFACARGA", 48, StAccion, 1, StID, 1, StOrigen, 1, StDestino, 1, StCMonBas, 3, StCPeso, 3, StCVol, 3, StEMonBas, 3, StEPeso, 3, StEVol, 3, StPMonBas, 3, StPPeso, 3, StPVol, 3, StGMonBas, 3, StGNor, 3, StGTel, 3, StFecIni, 2, StFecFin, 2, StVigente, 1, StEstado, 1, StUsuario, 1, StRol, 1, StIP, 2}
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_TARIFACARGA_1", 58, StAccion, 1, StID, 1, StOrigen, 1, StDestino, 1, StCMonBas, 3, StCPeso, 3, StCVol, 3, StCSobre, 3, StEMonBas, 3, StEPeso, 3, StEVol, 3, StPMonBas, 3, StPPeso, 3, StPVol, 3, StGMonBas, 3, StGNor, 3, StGTel, 3, StFecIni, 2, StFecFin, 2, StVigente, 1, StEstado, 1, StUsuario, 1, StRol, 1, StIP, 2, StCMonBasContado, 3, StCPesoContado, 3, StCVolContado, 3, StCSobreContado, 3}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function Grabar() As DataSet
        'hlamas
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_TARIFACARGA_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", StAccion, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIDTARIFAS_CARGA", StID, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", StOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", StDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iCG_MONTO_BASE", StCMonBas, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iCG_X_PESO", StCPeso, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iCG_X_VOLUMEN", StCVol, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iCG_X_SOBRE", StCSobre, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iEC_MONTO_BASE", StEMonBas, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iEC_X_PESO", StEPeso, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iEC_X_VOLUMEN", StEVol, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iPO_MONTO_BASE", StPMonBas, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iPO_X_PESO", StPPeso, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iPO_X_VOLUMEN", StPVol, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iGI_MONTO_BASE", StGMonBas, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iGI_NORMAL", StGNor, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iGI_TELEFONICO", StGTel, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iFECHA_ACTIVACION", StFecIni, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iFECHA_DESACTIVACION", StFecFin, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iES_VIGENTE", StVigente, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIDESTADO_REGISTRO", StEstado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", StUsuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", StRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", StIP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iCG_MONTO_BASE_CONTADO", StCMonBasContado, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iCG_X_PESO_CONTADO", StCPesoContado, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iCG_X_VOLUMEN_CONTADO", StCVolContado, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iCG_X_SOBRE_CONTADO", StCSobreContado, OracleClient.OracleType.Double)
            '
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
    'Public Function GrabarArticulo_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_TARIFACARGA_ARTICULO", 20, 1, 1, StID, 1, StTarifa, 1, StArticulo, 1, StMonto, 3, StEstado, 1, StUsuario, 1, StRol, 1, StIP, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function GrabarArticulo() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOITINERARIOS.SP_INSUPD_TARIFACARGA_ARTICULO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", 1, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIDTARIFAS_CARGA_ARTICULO", StID, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDTARIFAS_CARGA", StTarifa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDARTICULOS", StArticulo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iMONTO", StMonto, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("iIDESTADO_REGISTRO", StEstado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", StUsuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", StRol, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIP", StIP, OracleClient.OracleType.VarChar)
            '
            'Variables de salidas             
            db_bd.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
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
