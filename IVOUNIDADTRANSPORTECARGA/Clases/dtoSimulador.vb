Imports AccesoDatos
Public Class dtoSimulador
#Region "Variables"
    'Public cur_unidades As New ADODB.Recordset
    Public cur_unidades As DataTable

    'Public cur_documento As New ADODB.Recordset
    Public cur_documento As DataTable

    'Public cur_lista As New ADODB.Recordset
    Public cur_lista As DataTable

    'Public cur_guia_transportista As New ADODB.Recordset

    'Public cur_doc As New ADODB.Recordset
    Public cur_doc As DataTable

    'Public cur_origen As New ADODB.Recordset
    Public cur_origen As DataTable

    'Public cur_destino As New ADODB.Recordset
    Public cur_destino As DataTable

    'Public cur_agencia As New ADODB.Recordset
    Public cur_agencia As DataTable

    'filtro
    'Public cur_origen2 As New ADODB.Recordset
    Public cur_origen2 As DataTable

    'Public cur_destino2 As New ADODB.Recordset
    Public cur_destino2 As DataTable

    'salida
    'Public cur_AgenciaOrigen As New ADODB.Recordset
    Public cur_AgenciaOrigen As DataTable

    'Public cur_AgenciaDestino As New ADODB.Recordset
    Public cur_AgenciaDestino As DataTable

    'Public cur_Tramo As New ADODB.Recordset
    Public cur_Tramo As DataTable

    'Public cur_Tramo2 As New ADODB.Recordset
    Public cur_Tramo2 As DataTable

    'Public cur_usuarios As New ADODB.Recordset
    Public cur_usuarios As DataTable

    'Public cur_salida As New ADODB.Recordset

    'Public cur_numero As New ADODB.Recordset
    Public cur_numero As DataTable

    'Public cur_salida1 As New ADODB.Recordset
    Public cur_salida1 As DataTable

    'Public cur_salida2 As New ADODB.Recordset
    Public cur_salida2 As DataTable

    'Public cur_parcial As New ADODB.Recordset
    Public cur_parcial As DataTable

    Private iAño As Integer
    Private iMes As Integer

    Private dFecha As String
    Private dFecha2 As String

    Private iUsuario As String
    Private iNumero As Integer
    Private iItem As Integer
    Private iBus As Long
    Private iKilometraje As Double
    Private iSpk As Double

    Private iSerie As Integer
    Private iGuia As String

    Private sIni As String
    Private sFin As String
    Private iDocumento As Integer

    Private iTipoComprobante As Integer
    Private iIdComprobante As String
    Private iControl As Integer

    Private iSalida As String
    Private iCantidad As Integer
    Private iSaldo As Integer
    Private iSubtotal As Double
    Private iImpuesto As Double
    Private iTotal As Double

    Private iOrigen As String
    Private iDestino As String

    Private iTramo As String
    Private iOpcion As Integer

    Private iIdParcial As Integer
    Private sParcial As String

    Private iPeso As Double
    Private iVolumen As Double
#End Region

#Region "Propiedades"
    Public Property Peso() As Double
        Get
            Return iPeso
        End Get
        Set(ByVal value As Double)
            iPeso = value
        End Set
    End Property

    Public Property Volumen() As Double
        Get
            Return iVolumen
        End Get
        Set(ByVal value As Double)
            iVolumen = value
        End Set
    End Property

    Public Property IdParcial() As Integer
        Get
            Return iIdParcial
        End Get
        Set(ByVal value As Integer)
            iIdParcial = value
        End Set
    End Property

    Public Property Parcial() As String
        Get
            Return sParcial
        End Get
        Set(ByVal value As String)
            sParcial = value
        End Set
    End Property

    Public Property Opcion() As Integer
        Get
            Return iOpcion
        End Get
        Set(ByVal value As Integer)
            iOpcion = value
        End Set
    End Property

    Public Property Tramo() As String
        Get
            Return iTramo
        End Get
        Set(ByVal value As String)
            iTramo = value
        End Set
    End Property

    Public Property Origen() As String
        Get
            Return iOrigen
        End Get
        Set(ByVal value As String)
            iOrigen = value
        End Set
    End Property

    Public Property Destino() As String
        Get
            Return iDestino
        End Get
        Set(ByVal value As String)
            iDestino = value
        End Set
    End Property

    Public Property Subtotal() As Double
        Get
            Return iSubtotal
        End Get
        Set(ByVal value As Double)
            iSubtotal = value
        End Set
    End Property

    Public Property Impuesto() As Double
        Get
            Return iImpuesto
        End Get
        Set(ByVal value As Double)
            iImpuesto = value
        End Set
    End Property

    Public Property Total() As Double
        Get
            Return iTotal
        End Get
        Set(ByVal value As Double)
            iTotal = value
        End Set
    End Property

    Public Property Cantidad() As Integer
        Get
            Return iCantidad
        End Get
        Set(ByVal value As Integer)
            iCantidad = value
        End Set
    End Property

    Public Property Saldo() As Integer
        Get
            Return iSaldo
        End Get
        Set(ByVal value As Integer)
            iSaldo = value
        End Set
    End Property

    Public Property Salida2() As String
        Get
            Return iSalida
        End Get
        Set(ByVal value As String)
            iSalida = value
        End Set
    End Property

    Public Property Fecha() As String
        Get
            Return dFecha
        End Get
        Set(ByVal value As String)
            dFecha = value
        End Set
    End Property

    Public Property Fecha2() As String
        Get
            Return dFecha2
        End Get
        Set(ByVal value As String)
            dFecha2 = value
        End Set
    End Property

    Public Property Año() As Integer
        Get
            Return iAño
        End Get
        Set(ByVal value As Integer)
            iAño = value
        End Set
    End Property

    Public Property Mes() As Integer
        Get
            Return iMes
        End Get
        Set(ByVal value As Integer)
            iMes = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return iUsuario
        End Get
        Set(ByVal value As String)
            iUsuario = value
        End Set
    End Property

    Public Property Item() As Integer
        Get
            Return iItem
        End Get
        Set(ByVal value As Integer)
            iItem = value
        End Set
    End Property

    Public Property TipoComprobante() As Integer
        Get
            Return iTipoComprobante
        End Get
        Set(ByVal value As Integer)
            iTipoComprobante = value
        End Set
    End Property

    Public Property IdComprobante() As String
        Get
            Return iIdComprobante
        End Get
        Set(ByVal value As String)
            iIdComprobante = value
        End Set
    End Property

    Public Property Bus() As Long
        Get
            Return iBus
        End Get
        Set(ByVal value As Long)
            iBus = value
        End Set
    End Property

    Public Property Kilometraje() As Double
        Get
            Return iKilometraje
        End Get
        Set(ByVal value As Double)
            iKilometraje = value
        End Set
    End Property

    Public Property Spk() As Double
        Get
            Return iSpk
        End Get
        Set(ByVal value As Double)
            iSpk = value
        End Set
    End Property

    Public Property Serie() As Integer
        Get
            Return iSerie
        End Get
        Set(ByVal value As Integer)
            iSerie = value
        End Set
    End Property

    Public Property Guia() As String
        Get
            Return iGuia
        End Get
        Set(ByVal value As String)
            iGuia = value
        End Set
    End Property

    Public Property Numero() As Long
        Get
            Return iNumero
        End Get
        Set(ByVal value As Long)
            iNumero = value
        End Set
    End Property

    Public WriteOnly Property Control() As Integer
        Set(ByVal value As Integer)
            iControl = value
        End Set
    End Property

    Public Property ini() As String
        Get
            Return sIni
        End Get
        Set(ByVal value As String)
            sIni = value
        End Set
    End Property

    Public Property fin() As String
        Get
            Return sFin
        End Get
        Set(ByVal value As String)
            sFin = value
        End Set
    End Property

    Public Property Doc() As Integer
        Get
            Return iDocumento
        End Get
        Set(ByVal value As Integer)
            iDocumento = value
        End Set
    End Property

#End Region

#Region "Metodos"
    Public Sub New()
    End Sub

    'Public Function Grabar2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_ACTUALIZA_SIMULADOR", 38, _
    '                                    iControl, 1, _
    '                                    dFecha, 2, _
    '                                    iUsuario, 2, _
    '                                    iNumero, 1, _
    '                                    iItem, 1, _
    '                                    iBus, 1, _
    '                                    iKilometraje, 3, _
    '                                    iSpk, 3, _
    '                                    iSerie, 1, _
    '                                    iGuia, 2, _
    '                                    iTipoComprobante, 1, _
    '                                    iIdComprobante, 2, _
    '                                    iSalida, 2, iCantidad, 1, iSaldo, 1, iSubtotal, 3, iImpuesto, 3, iTotal, 3}
    '        VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False

    '    End Try
    '    Return flag
    'End Function

    'Public Function CargarGuia2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_CARGAR_SIMULADOR_GUIA", 10, _
    '                                    iAño, 1, _
    '                                    iMes, 1, _
    '                                    iUsuario, 1, _
    '                                    iNumero, 1}
    '        cur_lista = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    'Public Function ListaUnidadSalida2009(ByVal bus As String, ByVal ini As String, ByVal fin As String, ByVal documento As Integer, ByVal opcion As Integer, ByVal usuario As String, ByVal operador As Integer, ByVal peso As Double, ByVal origen As Integer, ByVal ciudad1 As Integer, ByVal ciudad2 As Integer, ByVal tipo As Integer, ByVal nuevo As Integer, ByVal parcial As Integer, ByVal salida As String) As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_LISTA_BUS_SALIDA", 32, bus, 2, ini, 2, fin, 2, documento, 1, opcion, 1, usuario, 2, operador, 1, peso, 3, origen, 1, ciudad1, 1, ciudad2, 1, tipo, 1, nuevo, 1, parcial, 1, salida, 2}

    '        cur_lista = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        'If cur_lista.BOF = False And cur_lista.EOF = False Then
    '        'cur_documento = cur_lista.NextRecordset
    '        'End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    'Public Function DocumentoDisponible2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_DOCUMENTO_DISPONIBLE", 10, _
    '                                    iAño, 1, _
    '                                    iMes, 1, _
    '                                    iUsuario, 1, _
    '                                    iNumero, 1}
    '        cur_lista = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    'Public Function ListaUnidades2009() As Boolean
    '    Dim bExito As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGESTION.SP_LISTA_BUS", 2}
    '        cur_unidades = Nothing
    '        cur_unidades = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        bExito = True
    '    Catch ex As Exception
    '        bExito = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return bExito
    'End Function
    'Public Function Documento2009(ByVal sDocumento As String, ByVal usuario As String) As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_DOCUMENTO", 6, sDocumento, 2, usuario, 2}
    '        cur_doc = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Public Function Documento(ByVal sDocumento As String, ByVal usuario As String) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_DOCUMENTO", CommandType.StoredProcedure)
            db.AsignarParametro("documento", sDocumento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("usuario", usuario, OracleClient.OracleType.Number)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_doc = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function ListaUnidades22009() As Boolean
    '    Dim bExito As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGESTION.SP_LISTA_BUS2", 2}
    '        cur_unidades = Nothing
    '        cur_unidades = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        bExito = True
    '    Catch ex As Exception
    '        bExito = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return bExito
    'End Function

    Public Function ListaUnidades2() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_LISTA_BUS2", CommandType.StoredProcedure)
            db.AsignarParametro("CUR_LISTA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_unidades = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

    End Function

    'Public Function Ciudad22009() As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_CIUDAD2", 2}
    '    cur_AgenciaOrigen = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    cur_AgenciaDestino = cur_AgenciaOrigen.NextRecordset
    '    cur_Tramo = cur_AgenciaOrigen.NextRecordset
    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function Ciudad2() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_CIUDAD2", CommandType.StoredProcedure)
            db.AsignarParametro("cur1", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur3", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_AgenciaOrigen = ds.Tables(0)
            cur_AgenciaDestino = ds.Tables(1)
            cur_Tramo = ds.Tables(2)
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function ListarUsuarios2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_LISTAR_USUARIOS", 2}
    '        cur_usuarios = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Public Function ListarUsuarios() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_LISTAR_USUARIOS", CommandType.StoredProcedure)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_usuarios = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function Estado_Parcial2009(ByVal envio As String, ByVal comprobante As String, ByVal tipo As Integer, ByVal usuario As String, ByVal cantidad As Integer) As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_ESTADO_PARCIAL", 12, _
    '                                envio, 2, _
    '                                comprobante, 2, _
    '                                tipo, 1, _
    '                                usuario, 2, _
    '                                cantidad, 1}
    '    cur_parcial = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    If cur_parcial.BOF = False And cur_parcial.EOF = False Then
    '        flag = True
    '    Else
    '        flag = False
    '    End If
    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function Estado_Parcial(ByVal envio As String, ByVal comprobante As String, ByVal tipo As Integer, ByVal usuario As String, ByVal cantidad As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_ESTADO_PARCIAL", CommandType.StoredProcedure)
            db.AsignarParametro("envio", envio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("comprobante", comprobante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("iusuario", usuario, OracleClient.OracleType.Number)
            db.AsignarParametro("cantidad", cantidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_estado", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_parcial = db.EjecutarDataTable
            If cur_parcial.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function Listar2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_LISTAR_SIMULADOR", 8, _
    '                                    dFecha, 2, _
    '                                    dFecha2, 2, _
    '                                    iUsuario, 2}
    '        cur_lista = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Public Function Listar() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_LISTAR_SIMULADOR", CommandType.StoredProcedure)
            db.AsignarParametro("iFECHA", dFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iFECHA2", dFecha2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iUSUARIO", iUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_lista = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function Cargar2009() As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_CARGAR_SIMULADOR", 8, _
    '                                dFecha, 2, _
    '                                iUsuario, 2, _
    '                                iNumero, 1}

    '    cur_lista = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    If cur_lista.BOF = False And cur_lista.EOF = False Then
    '        cur_documento = cur_lista.NextRecordset
    '    End If

    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function Cargar() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_CARGAR_SIMULADOR", CommandType.StoredProcedure)
            db.AsignarParametro("iFECHA", dFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iUSUARIO", iUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNUMERO", iNumero, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_lista = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function Cargar22009() As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_CARGAR_SIMULADOR2", 8, _
    '                                dFecha, 2, _
    '                                iUsuario, 2, _
    '                                iNumero, 1}

    '    cur_lista = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    If cur_lista.BOF = False And cur_lista.EOF = False Then
    '        cur_Tramo2 = cur_lista.NextRecordset
    '    End If


    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function Cargar2() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_CARGAR_SIMULADOR2_DH", CommandType.StoredProcedure)
            db.AsignarParametro("iFECHA", dFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iUSUARIO", iUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNUMERO", iNumero, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_TRAMO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_lista = ds.Tables(0)
            If cur_lista.Rows.Count > 0 Then
                cur_Tramo2 = ds.Tables(1)
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function Unidad2009(ByVal bus As String, ByVal salida As String) As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_UNIDAD", 6, bus, 2, salida, 2}
    '    cur_origen = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    cur_destino = cur_origen.NextRecordset
    '    If cur_origen.BOF = False And cur_origen.EOF = False Then
    '        flag = True
    '    Else
    '        flag = False
    '    End If
    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function Unidad(ByVal bus As String, ByVal salida As String) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_UNIDAD", CommandType.StoredProcedure)
            db.AsignarParametro("BUS", bus, OracleClient.OracleType.VarChar)
            db.AsignarParametro("SALIDA", salida, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_ORIGEN", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_DESTINO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_origen = ds.Tables(0)
            cur_destino = ds.Tables(1)
            If cur_origen.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function BusDatos22009(ByVal bus As String) As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_BUS_DATOS2", 4, bus, 2}

    '        cur_documento = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Public Function BusDatos2(ByVal bus As String) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_BUS_DATOS2", CommandType.StoredProcedure)
            db.AsignarParametro("BUS", bus, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_DATOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_documento = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function Salida222009(ByVal bus As String) As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_SALIDA2", 4, bus, 2}
    '    cur_salida1 = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    If cur_salida1.BOF = False And cur_salida1.EOF = False Then
    '        cur_salida2 = cur_salida1.NextRecordset
    '        flag = True
    '    Else
    '        flag = False
    '    End If
    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function Salida22(ByVal bus As String) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_SALIDA2", CommandType.StoredProcedure)
            db.AsignarParametro("BUS", bus, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR1", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR2", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_salida1 = ds.Tables(0)
            If cur_salida1.Rows.Count > 0 Then
                cur_salida2 = ds.Tables(1)
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function ActualizaTramoTmp2009() As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_ACTUALIZA_TRAMO_TMP", 10, _
    '                                iUsuario, 2, _
    '                                iTramo, 2, _
    '                                iOpcion, 1, _
    '                                iKilometraje, 3}
    '    VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)

    'Catch ex As Exception
    '    flag = False

    'End Try
    'Return flag
    'End Function

    Public Function ActualizaTramoTmp() As Boolean
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_ACTUALIZA_TRAMO_TMP", CommandType.StoredProcedure)
            db.AsignarParametro("iUSUARIO", iUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iTRAMO", iTramo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iOPCION", iOpcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("iKILOMETRAJE", iKilometraje, OracleClient.OracleType.Number)
            db.EjecutarComando()
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'Public Function ListaUnidadSalida22009(ByVal bus As String, ByVal ini As String, ByVal fin As String, ByVal documento As Integer, ByVal opcion As Integer, ByVal usuario As String, ByVal operador As Integer, ByVal peso As Double, ByVal origen As Integer, ByVal ciudad1 As Integer, ByVal ciudad2 As Integer, ByVal tipo As Integer, ByVal nuevo As Integer, ByVal parcial As Integer, ByVal salida As String, ByVal unidad1 As Integer, ByVal unidad2 As Integer) As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_LISTA_BUS_SALIDA2", 36, bus, 2, ini, 2, fin, 2, documento, 1, opcion, 1, usuario, 2, operador, 1, peso, 3, origen, 1, ciudad1, 1, ciudad2, 1, tipo, 1, nuevo, 1, parcial, 1, salida, 2, unidad1, 1, unidad2, 1}

    '        cur_lista = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        'If cur_lista.BOF = False And cur_lista.EOF = False Then
    '        'cur_documento = cur_lista.NextRecordset
    '        'End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Public Function ListaUnidadSalida2(ByVal bus As String, ByVal ini As String, ByVal fin As String, ByVal documento As Integer, ByVal opcion As Integer, ByVal usuario As String, ByVal operador As Integer, ByVal peso As Double, ByVal origen As Integer, ByVal ciudad1 As Integer, ByVal ciudad2 As Integer, ByVal tipo As Integer, ByVal nuevo As Integer, ByVal parcial As Integer, ByVal salida As String, ByVal unidad1 As Integer, ByVal unidad2 As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_LISTA_BUS_SALIDA2", CommandType.StoredProcedure)
            db.AsignarParametro("BUS", bus, OracleClient.OracleType.VarChar)
            db.AsignarParametro("FECHA_INICIO", ini, OracleClient.OracleType.VarChar)
            db.AsignarParametro("FECHA_FIN", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("DOCUMENTO", documento, OracleClient.OracleType.Int32)
            db.AsignarParametro("OPCION", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("USUARIO", usuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("OPERADOR", operador, OracleClient.OracleType.Int32)
            db.AsignarParametro("PESO", peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ORIGEN", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("CIUDAD1", ciudad1, OracleClient.OracleType.Int32)
            db.AsignarParametro("CIUDAD2", ciudad2, OracleClient.OracleType.Int32)
            db.AsignarParametro("TIPO", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("NUEVO", nuevo, OracleClient.OracleType.Int32)
            db.AsignarParametro("PARCIAL", parcial, OracleClient.OracleType.Int32)
            db.AsignarParametro("SALIDA", salida, OracleClient.OracleType.VarChar)
            db.AsignarParametro("UNIDAD1", unidad1, OracleClient.OracleType.Int32)
            db.AsignarParametro("UNIDAD2", unidad2, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_DOCUMENTO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            'Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_LISTA_BUS_SALIDA2", 36, bus, 2, ini, 2, fin, 2, documento, 1, opcion, 1, usuario, 2, operador, 1, peso, 3, origen, 1, ciudad1, 1, ciudad2, 1, tipo, 1, nuevo, 1, parcial, 1, salida, 2, unidad1, 1, unidad2, 1}
            cur_lista = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function EliminaTramoTmp2009() As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_ELIMINA_TRAMO_TMP", 4, _
    '                                iUsuario, 2}
    '    VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)

    'Catch ex As Exception
    '    flag = False

    'End Try
    'Return flag
    'End Function

    Public Function EliminaTramoTmp() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_ELIMINA_TRAMO_TMP", CommandType.StoredProcedure)
            db.AsignarParametro("iUSUARIO", iUsuario, OracleClient.OracleType.Number)
            db.EjecutarComando()
            db.Desconectar()
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function Eliminar2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_ELIMINAR_SIMULADOR", 8, _
    '                                    dFecha, 2, _
    '                                    iUsuario, 2, _
    '                                    iNumero, 1}
    '        VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Public Function Eliminar() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_ELIMINAR_SIMULADOR", CommandType.StoredProcedure)
            db.AsignarParametro("iFECHA", dFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iUSUARIO", iUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNUMERO", iNumero, OracleClient.OracleType.Int32)
            db.EjecutarComando()
            db.Desconectar()
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function ActualizaTramo2009() As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_ACTUALIZA_TRAMO", 14, _
    '                                dFecha, 2, _
    '                                iUsuario, 2, _
    '                                iNumero, 1, _
    '                                iTramo, 2, _
    '                                iOpcion, 1, _
    '                                iKilometraje, 3}
    '    VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)

    'Catch ex As Exception
    '    flag = False

    'End Try
    'Return flag
    'End Function
    Public Function ActualizaTramo() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_ACTUALIZA_TRAMO", CommandType.StoredProcedure)
            db.AsignarParametro("dFECHA", dFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iUSUARIO", iUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNUMERO", iNumero, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTRAMO", iTramo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iOPCION", iOpcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("iKILOMETRAJE", iKilometraje, OracleClient.OracleType.Number)
            db.EjecutarComando()
            db.Desconectar()
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function Ciudad2009() As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_CIUDAD", 2}
    '    cur_origen2 = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    cur_destino2 = cur_origen2.NextRecordset
    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function Ciudad() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_CIUDAD", CommandType.StoredProcedure)
            db.AsignarParametro("cur1", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur2", OracleClient.OracleType.Cursor)
            db.Desconectar()
            '----
            Dim ds As DataSet
            '
            ds = db.EjecutarDataSet
            '
            cur_origen2 = ds.Tables(0)
            cur_destino2 = ds.Tables(1)
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function Agencia2009(ByVal unidad As String) As Boolean
    '    Dim flag As Boolean = True

    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_AGENCIA", 4, unidad, 2}
    '        cur_agencia = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function Agencia(ByVal unidad As String) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_AGENCIA", CommandType.StoredProcedure)
            db.AsignarParametro("unidad", unidad, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_agencia = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function Grabar22009() As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_ACTUALIZA_SIMULADOR2", 48, _
    '                                iControl, 1, _
    '                                dFecha, 2, _
    '                                iUsuario, 2, _
    '                                iNumero, 1, _
    '                                iItem, 1, _
    '                                iBus, 1, _
    '                                iKilometraje, 3, _
    '                                iSpk, 3, _
    '                                iSerie, 1, _
    '                                iGuia, 2, _
    '                                iTipoComprobante, 1, _
    '                                iIdComprobante, 2, _
    '                                iCantidad, 1, iSaldo, 1, iSubtotal, 3, iImpuesto, 3, iTotal, 3, iOrigen, 2, iDestino, 2, iIdParcial, 1, sParcial, 2, iPeso, 3, iVolumen, 3}
    '    cur_numero = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)

    'Catch ex As Exception
    '    flag = False

    'End Try
    'Return flag
    'End Function
    Public Function Grabar2() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_ACTUALIZA_SIMULADOR2", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", iControl, OracleClient.OracleType.Int32)
            db.AsignarParametro("iFECHA", dFecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iUSUARIO", iUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNUMERO", iNumero, OracleClient.OracleType.Int32)
            db.AsignarParametro("iITEM", iItem, OracleClient.OracleType.Int32)
            db.AsignarParametro("iBUS", iBus, OracleClient.OracleType.Int32)
            db.AsignarParametro("iKILOMETRAJE", iKilometraje, OracleClient.OracleType.Number)
            db.AsignarParametro("iSPK", iSpk, OracleClient.OracleType.Number)
            db.AsignarParametro("iSERIE", iSerie, OracleClient.OracleType.Int32)
            db.AsignarParametro("iGUIA", iGuia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iTIPO", iTipoComprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCOMPROBANTE", iIdComprobante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iCANTIDAD", iCantidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("iSALDO", iSaldo, OracleClient.OracleType.Int32)
            db.AsignarParametro("iSUBTOTAL", iSubtotal, OracleClient.OracleType.Number)
            db.AsignarParametro("iIMPUESTO", iImpuesto, OracleClient.OracleType.Number)
            db.AsignarParametro("iTOTAL", iTotal, OracleClient.OracleType.Number)
            db.AsignarParametro("iORIGEN", iOrigen, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDESTINO", iDestino, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDPARCIAL", iIdParcial, OracleClient.OracleType.Int32)
            db.AsignarParametro("iPARCIAL", sParcial, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iPESO", iPeso, OracleClient.OracleType.Number)
            db.AsignarParametro("iVOLUMEN", iVolumen, OracleClient.OracleType.Number)
            db.AsignarParametro("CUR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_numero = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function BusDatos2009(ByVal bus As String, ByVal salida As String, ByVal opcion As Integer) As Boolean
    'Dim flag As Boolean = True
    'Try
    '    Dim SQLQuery As Object() = {"PKG_IVOGESTION.SP_BUS_DATOS", 8, bus, 2, salida, 2, opcion, 1}

    '    cur_documento = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function BusDatos(ByVal bus As String, ByVal salida As String, ByVal opcion As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.SP_BUS_DATOS", CommandType.StoredProcedure)
            db.AsignarParametro("BUS", bus, OracleClient.OracleType.VarChar)
            db.AsignarParametro("SALIDA", salida, OracleClient.OracleType.Int32)
            db.AsignarParametro("OPCION", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_DATOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_documento = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class
