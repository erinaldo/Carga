Imports System.Drawing.Printing
Imports AccesoDatos
Public Class dtoCONFIGURACION_DOCUMENTARIA
#Region "Variables"
    Dim sIP As String
    Dim sIPMOD As String
    Dim sIPMAQUINA As String
    Dim iIDCONTROL_COMPROBANTES As Integer
    Dim iIDROL_USUARIO As Int16
    Dim iIDUSUARIO_PERSONAL As Integer
    Dim iIDAGENCIAS As Int16
    Dim sSERIE As String
    Dim sNRO_DOCUMENTO As String
    Dim sNRO_DOCUMENTO_FIN As String

    'variables que capturan los digitos de la serie y documento
    Public vSerie As Integer
    Public vDoc As Integer
    '19/08/2008 - Hlamas
    Dim sImpresora As String
#End Region
#Region "RecordSet"
    'Public rst_Lista_Control_Comprobante As New ADODB.Recordset
    Public rst_Lista_Control_Comprobante As New DataTable
    'Public rst_Upd_Control_Comprobante As New ADODB.Recordset
    Public rst_Upd_Control_Comprobante As New DataTable
    'Public rst_Upd_Control_Comprobante As New DataTable
    'Public rst_Digitos_Serie_Documento As New ADODB.Recordset
    Public rst_Digitos_Serie_Documento As New DataTable
    'Public rst_Correlativo As New ADODB.Recordset

    'Public rst_Listar_IP As New ADODB.Recordset
    Public rst_Listar_IP As New DataTable
    '19/08/2080 - Hlamas
    Public arrImpresoras As New ArrayList()
#End Region

#Region "Properties"
    Public Property fnIP() As String
        Get
            Return sIP
        End Get
        Set(ByVal value As String)
            sIP = value
        End Set
    End Property
    Public Property fnIPMOD() As String
        Get
            Return sIPMOD
        End Get
        Set(ByVal value As String)
            sIPMOD = value
        End Set
    End Property
    Public Property fnIPMAQUINA() As String
        Get
            Return sIPMAQUINA
        End Get
        Set(ByVal value As String)
            sIPMAQUINA = value
        End Set
    End Property
    Public Property fnIDCONTROL_COMPROBANTES() As Integer
        Get
            Return iIDCONTROL_COMPROBANTES
        End Get
        Set(ByVal value As Integer)
            iIDCONTROL_COMPROBANTES = value
        End Set
    End Property
    Public Property fnIDROL_USUARIO() As Int16
        Get
            Return iIDROL_USUARIO
        End Get
        Set(ByVal value As Int16)
            iIDROL_USUARIO = value
        End Set
    End Property
    Public Property fnIDUSUARIO_PERSONAL() As Integer
        Get
            Return iIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Integer)
            iIDUSUARIO_PERSONAL = value
        End Set
    End Property
    Public Property fnIDAGENCIAS() As Int16
        Get
            Return iIDAGENCIAS
        End Get
        Set(ByVal value As Int16)
            iIDAGENCIAS = value
        End Set
    End Property
    Public Property fnSERIE() As String
        Get
            Return sSERIE
        End Get
        Set(ByVal value As String)
            sSERIE = value
        End Set
    End Property
    Public Property fnNRO_DOCUMENTO() As String
        Get
            Return sNRO_DOCUMENTO
        End Get
        Set(ByVal value As String)
            sNRO_DOCUMENTO = value
        End Set
    End Property
    Public Property fnNRO_DOCUMENTO_FIN() As String
        Get
            Return sNRO_DOCUMENTO_FIN
        End Get
        Set(ByVal value As String)
            sNRO_DOCUMENTO_FIN = value
        End Set
    End Property
    Public Property fnImpresora() As String
        Get
            Return sImpresora
        End Get
        Set(ByVal value As String)
            sImpresora = value
        End Set
    End Property
    Private iTamaño As Integer
    Public Property Tamaño() As Integer
        Get
            Return iTamaño
        End Get
        Set(ByVal value As Integer)
            iTamaño = value
        End Set
    End Property
    Private iSuperior As Integer
    Public Property Superior() As Integer
        Get
            Return iSuperior
        End Get
        Set(ByVal value As Integer)
            iSuperior = value
        End Set
    End Property
    Private iIzquierda As Integer
    Public Property Izquierda() As Integer
        Get
            Return iIzquierda
        End Get
        Set(ByVal value As Integer)
            iIzquierda = value
        End Set
    End Property

#End Region

#Region "Metodos"

    'Public Function fnsp_INCREMENTAR_NRO_DOCUMENTO2009() As Boolean
    'Dim bFlag As Boolean = True
    'Try
    '    Dim varSP_OBJECT() As Object = {"SP_INCREMENTAR_NRO_DOCUMENTO", 8, "192.168.50.195", 2, 1, 1, 1, 1}
    '    rst_Correlativo = Nothing
    '    rst_Correlativo = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_Correlativo.EOF = False And rst_Correlativo.BOF = False Then
    '        'MsgBox("Datos Capturados")
    '        MsgBox(rst_Correlativo.Fields.Item(0).Value)
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")
    '    bFlag = False
    'End Try
    'Return bFlag
    'End Function
    ' Función remplazada con la de abajo 
    'Public Function fnUPD_CONTROL_COMPRO() As Boolean
    '    Dim bFlag As Boolean = True
    '    Try
    '        Dim rst As New ADODB.Recordset

    '        Dim varSP_OBJECT() As Object = {"SP_UPDATE_CONTROL_COMPRO", 22, sIP, 2, iIDAGENCIAS, 1, iIDCONTROL_COMPROBANTES, 1, _
    '        sSERIE, 2, sNRO_DOCUMENTO, 2, sNRO_DOCUMENTO_FIN, 2, sIPMOD, 2, sIPMAQUINA, 2, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IdLogin, 1}
    '        rst_Upd_Control_Comprobante = Nothing
    '        rst_Upd_Control_Comprobante = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        rst = rst_Upd_Control_Comprobante.NextRecordset

    '        'If rst_Upd_Control_Comprobante.EOF = False And rst_Upd_Control_Comprobante.BOF = False Then
    '        'If True Then
    '        '    MsgBox("Datos actualizados", MsgBoxStyle.Information, "Seguridad de Sistema")
    '        'End If
    '        If rst.Fields(0).Value = -1526 Then
    '            MsgBox(rst.Fields(1).Value, MsgBoxStyle.Information, "Seguridad de Sistema")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")
    '        bFlag = False
    '    End Try
    '    Return bFlag
    'End Function
    Public Function fnIMPRESORAS() As Boolean
        arrImpresoras.Clear()
        arrImpresoras.Add("(Ninguna)")
        For Each s As String In PrinterSettings.InstalledPrinters
            arrImpresoras.Add(s.ToString)
        Next

        If arrImpresoras.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    'Public Function fnLISTA_CONTROL_COMPROBANTE2009() As Boolean
    'Dim bFlag As Boolean = True
    'Try
    '    Dim varSP_OBJECT() As Object = {"SP_LISTA_CONTROL_COMPROBANTE", 12, sIP, 2, sIP, 2, iIDROL_USUARIO, 1, iIDUSUARIO_PERSONAL, 1, iIDAGENCIAS, 1}
    '    rst_Lista_Control_Comprobante = Nothing
    '    rst_Lista_Control_Comprobante = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If True Then
    '        ' MsgBox(rst_Lista_Control_Comprobante.Fields(0).Value.ToString)
    '        MsgBox("Iniciando configuracion de datos...", MsgBoxStyle.Information, "Seguridad de Sistema")
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")
    '    bFlag = False
    'End Try
    'Return bFlag
    'End Function

    Public Function fnLISTA_CONTROL_COMPROBANTE() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("SP_LISTA_CONTROL_COMPROBANTE2", CommandType.StoredProcedure)
            db.AsignarParametro("iIP", sIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIPMAQUINA_IMPRESION", sIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDROL_USUARIO", iIDROL_USUARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDAGENCIAS", iIDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", 0, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_Lista_Control_Comprobante = ds.Tables(0)
            Return True

        Catch ex As Excepcion
            Return False
        End Try
        'datahelper
        'Dim bFlag As Boolean = True
        'Try
        '    Dim varSP_OBJECT() As Object = {"SP_LISTA_CONTROL_COMPROBANTE", 12, sIP, 2, sIP, 2, iIDROL_USUARIO, 1, iIDUSUARIO_PERSONAL, 1, iIDAGENCIAS, 1}
        '    rst_Lista_Control_Comprobante = Nothing
        '    rst_Lista_Control_Comprobante = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    If True Then
        '        ' MsgBox(rst_Lista_Control_Comprobante.Fields(0).Value.ToString)
        '        MsgBox("Iniciando configuracion de datos...", MsgBoxStyle.Information, "Seguridad de Sistema")
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")
        '    bFlag = False
        'End Try
        'Return bFlag
    End Function

    'public Function fnUPD_CONTROL_COMPROBANTE2009() As Boolean
    'Dim bFlag As Boolean = True
    'Try
    '    Dim varSP_OBJECT() As Object = {"SP_UPDATE_CONTROL_COMPROBANTE", 22, sIP, 2, iIDAGENCIAS, 1, iIDCONTROL_COMPROBANTES, 1, _
    '    sSERIE, 2, sNRO_DOCUMENTO, 2, sNRO_DOCUMENTO_FIN, 2, sIPMOD, 2, sIPMAQUINA, 2, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IdLogin, 1}
    '    rst_Upd_Control_Comprobante = Nothing
    '    rst_Upd_Control_Comprobante = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    'If rst_Upd_Control_Comprobante.EOF = False And rst_Upd_Control_Comprobante.BOF = False Then
    '    'If True Then
    '    '    MsgBox("Datos actualizados", MsgBoxStyle.Information, "Seguridad de Sistema")
    '    'End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")
    '    bFlag = False
    'End Try
    'Return bFlag
    'End Function

    'Public Function fnDIGITOS_SERIE_DOCUMENTO2009() As Boolean
    'Dim bFlag As Boolean = True
    'Try
    '    Dim varSP_OBJECT() As Object = {"SP_DIGITOS_SERIE_DOCUMENTO", 4, iIDCONTROL_COMPROBANTES, 1}
    '    rst_Digitos_Serie_Documento = Nothing
    '    rst_Digitos_Serie_Documento = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    'If rst_Digitos_Serie_Documento.EOF = False And rst_Digitos_Serie_Documento.BOF = False Then
    '    'vSerie = rst_Digitos_Serie_Documento.Fields.Item(0).Value
    '    'vDoc = rst_Digitos_Serie_Documento.Fields.Item(1).Value
    '    'End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")
    '    bFlag = False
    'End Try
    'Return bFlag
    'End Function

    Public Function fnDIGITOS_SERIE_DOCUMENTO() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("SP_DIGITOS_SERIE_DOCUMENTO", CommandType.StoredProcedure)
            db.AsignarParametro("iIDCONTROL_COMPROBANTES", iIDCONTROL_COMPROBANTES, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_Digitos_Serie_Documento = ds.Tables(0)
            If rst_Digitos_Serie_Documento.Rows.Count > 0 Then
                vSerie = rst_Digitos_Serie_Documento.Rows(0).Item(0).ToString
                vDoc = rst_Digitos_Serie_Documento.Rows(0).Item(1).ToString
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
            'Return False
        End Try
        'datahelper
        'Dim bFlag As Boolean = True
        'Try
        '    Dim varSP_OBJECT() As Object = {"SP_DIGITOS_SERIE_DOCUMENTO", 4, iIDCONTROL_COMPROBANTES, 1}
        '    rst_Digitos_Serie_Documento = Nothing
        '    rst_Digitos_Serie_Documento = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    If rst_Digitos_Serie_Documento.EOF = False And rst_Digitos_Serie_Documento.BOF = False Then
        '        vSerie = rst_Digitos_Serie_Documento.Fields.Item(0).Value
        '        vDoc = rst_Digitos_Serie_Documento.Fields.Item(1).Value
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")
        '    bFlag = False
        'End Try
        'Return bFlag
    End Function
    'Public Function fnLISTAR_IP2009() As Boolean
    'Dim bFlag As Boolean = False
    'Try
    '    'Dim varSP_OBJECT() As Object = {"PKG_IVOUUTILS.SP_LISTAR_IP", 2, dtoUSUARIOS.iIDAGENCIAS, 1}
    '    Dim varSP_OBJECT() As Object = {"SP_LISTAR_IP", 2}
    '    rst_Listar_IP = Nothing
    '    rst_Listar_IP = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If True Then
    '        ' MsgBox("Retorna IPs")
    '        'MsgBox(rst_Listar_IP.Fields.Item(0).Value)
    '        bFlag = True
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")
    '    bFlag = False
    'End Try
    'Return bFlag
    'End Function

    Public Function fnLISTAR_IP() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUUTILS.SP_LISTAR_IP", CommandType.StoredProcedure)
            db.AsignarParametro("idagencia", dtoUSUARIOS.iIDAGENCIAS, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_Listar_IP = ds.Tables(0)
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

        'datahelper
        'Dim bFlag As Boolean = False
        'Try
        '    'Dim varSP_OBJECT() As Object = {"PKG_IVOUUTILS.SP_LISTAR_IP", 2, dtoUSUARIOS.iIDAGENCIAS, 1}
        '    Dim varSP_OBJECT() As Object = {"SP_LISTAR_IP", 2}
        '    rst_Listar_IP = Nothing
        '    rst_Listar_IP = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    If True Then
        '        ' MsgBox("Retorna IPs")
        '        'MsgBox(rst_Listar_IP.Fields.Item(0).Value)
        '        bFlag = True
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")
        '    bFlag = False
        'End Try
        'Return bFlag
    End Function

    'Public Function fnUPD_CONTROL_COMPRO2009() As Boolean
    'Dim bFlag As Boolean = True
    'Try
    '    Dim rst As New ADODB.Recordset

    '    Dim varSP_OBJECT() As Object = {"SP_UPDATE_CONTROL_COMPRO1", 24, _
    '                                     sIP, 2, _
    '                                     iIDAGENCIAS, 1, _
    '                                     CType(iIDCONTROL_COMPROBANTES, String), 2, _
    '                                     sSERIE, 2, _
    '                                     sNRO_DOCUMENTO, 2, _
    '                                     sNRO_DOCUMENTO_FIN, 2, _
    '                                     sIPMOD, 2, _
    '                                     sIPMAQUINA, 2, _
    '                                     dtoUSUARIOS.IdRol, 1, _
    '                                     CType(dtoUSUARIOS.IdLogin, String), 2, _
    '                                     sImpresora, 2}
    '    rst_Upd_Control_Comprobante = Nothing
    '    rst_Upd_Control_Comprobante = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    'rst = rst_Upd_Control_Comprobante.NextRecordset

    '    'If rst_Upd_Control_Comprobante.EOF = False And rst_Upd_Control_Comprobante.BOF = False Then
    '    'If True Then
    '    '    MsgBox("Datos actualizados", MsgBoxStyle.Information, "Seguridad de Sistema")
    '    'End If
    '    If rst.Fields(0).Value = -1526 Then
    '        MsgBox(rst.Fields(1).Value, MsgBoxStyle.Information, "Seguridad de Sistema")
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")
    '    bFlag = False
    'End Try
    'Return bFlag
    'End Function
    Public Function fnUPD_CONTROL_COMPRO() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("SP_UPDATE_CONTROL_COMPRO2", CommandType.StoredProcedure)
            db.AsignarParametro("iIP", sIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDAGENCIAS", iIDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDCONTROL_COMPROBANTES", CType(iIDCONTROL_COMPROBANTES, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("iSERIE", sSERIE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNRO_DOCUMENTO", sNRO_DOCUMENTO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNRO_DOCUMENTO_FIN", sNRO_DOCUMENTO_FIN, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIPMOD", sIPMOD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIPMAQUINA_IMPRESION", sIPMAQUINA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDROL_USUARIOMOD", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDUSUARIO_PERSONALMOD", CType(dtoUSUARIOS.IdLogin, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("iImpresora", sImpresora, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iTamano", iTamaño, OracleClient.OracleType.Int32)
            db.AsignarParametro("iSuperior", iSuperior, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIzquierda", iIzquierda, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_Upd_Control_Comprobante = ds.Tables(0)
            Dim rst As DataTable = ds.Tables(1)
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function ObtieneConfiguracion(ByVal ip As String, ByVal agencia As Integer, ByVal documento As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUUTILS.SP_OBTIENE_CONFIGURACION", CommandType.StoredProcedure)
            db.AsignarParametro("iIP", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("idagencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iComprobante", documento, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function ObtieneConfiguracion(ByVal ip As String, ByVal agencia As Integer, ByVal documento As Integer, ByVal producto As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUUTILS.SP_OBTIENE_CONFIGURACION", CommandType.StoredProcedure)
            db.AsignarParametro("iIP", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("idagencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iComprobante", documento, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ListarAgencias(ciudad As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.sp_listar_oficinas", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarComprobantes(agencia As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.sp_listar_comprobantes", CommandType.StoredProcedure)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub GrabarComprobante(id As Integer, tipo As Integer, serie As String, serie_digitos As Integer, inicio As String, fin As String, _
                          documento_digitos As Integer, ip As String, usuario As Integer, agencia As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGESTION.sp_grabar_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_serie", serie, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_serie_digitos", serie_digitos, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_documento_digitos", documento_digitos, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
#End Region
End Class