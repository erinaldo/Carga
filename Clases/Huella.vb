Imports AccesoDatos
Imports SecuGen.FDxSDKPro.Windows
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Collections.Generic
Imports System.Linq

Public Class Huella
    Dim utf8 As New UTF8Encoding
    Dim con As OracleClient.OracleConnection

    <DllImport("sgwsqlib32.dll", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True, entrypoint:="_SGWSQ_Encode@36")> _
    Public Shared Function _SGWSQ_Encode(ByRef wsq As IntPtr, ByRef longitud As Integer, ratio As Single, imagen() As Byte, _
                                        ancho As Integer, altura As Integer, pixel As Integer, ppi As Integer, comentario() As Byte) As Integer
    End Function

    <DllImport("sgwsqlib32.dll", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True, entrypoint:="_SGWSQ_Decode@32")> _
    Public Shared Function _SGWSQ_Decode(ByRef raw As IntPtr, ByRef ancho As Integer, ByRef altura As Integer, ByRef pixel As Integer, ByRef ppi As Integer, _
                                        ByRef flag As Integer, imagen() As Byte, longitud As Integer) As Integer
    End Function

    <DllImport("sgwsqlib32.dll", entrypoint:="_SGWSQ_Free@4")> _
    Public Shared Function _SGWSQ_Free(wsq As IntPtr) As Integer
    End Function

    <DllImport("sgwsqlib64.dll", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True, entrypoint:="SGWSQ_Encode")> _
    Public Shared Function SGWSQ_Encode(ByRef wsq As IntPtr, ByRef longitud As Integer, ratio As Single, imagen() As Byte, _
                                        ancho As Integer, altura As Integer, pixel As Integer, ppi As Integer, comentario() As Byte) As Integer
    End Function

    <DllImport("sgwsqlib64.dll", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True, entrypoint:="SGWSQ_Decode")> _
    Public Shared Function SGWSQ_Decode(ByRef raw As IntPtr, ByRef ancho As Integer, ByRef altura As Integer, ByRef pixel As Integer, ByRef ppi As Integer, _
                                        ByRef flag As Integer, imagen() As Byte, longitud As Integer) As Integer
    End Function

    <DllImport("sgwsqlib64.dll", entrypoint:="SGWSQ_Free")> _
    Public Shared Function SGWSQ_Free(wsq As IntPtr) As Integer
    End Function
    '    <DllImport("sgwsqlib.dll", entrypoint:="SGWSQ_Free")> _
    '    Public Shared Function SGWSQ_Free(wsq As IntPtr) As Integer
    '   End Function

    Dim mLista() As SGFPMDeviceList
    Dim fpHuella As SGFingerPrintManager
    Const OLEbyte0 As Byte = 21
    Const OLEbyte1 As Byte = 28
    Const OLEheaderLength As Integer = 78

#Region "Propiedades"
    Private intAncho As Integer
    Public ReadOnly Property Ancho() As Integer
        Get
            Return intAncho
        End Get
    End Property

    Private intAlto As Integer
    Public ReadOnly Property Alto() As Integer
        Get
            Return intAlto
        End Get
    End Property


#End Region

    Function MostrarError(ByVal NumeroError As String) As String
        If Not IsNumeric(NumeroError) Then
            Return NumeroError
        End If
        Dim text As String
        text = ""
        Select Case NumeroError
            Case 0                             'SGFDX_ERROR_NONE				= 0,
                text = ""

            Case 1 'SGFDX_ERROR_CREATION_FAILED	= 1,
                text = "No se puede crear objeto"

            Case 2 '   SGFDX_ERROR_FUNCTION_FAILED	= 2,
                text = "Fallo en la función"

            Case 3 '   SGFDX_ERROR_INVALID_PARAM	= 3,
                text = "Parámetro no válido"

            Case 4 '   SGFDX_ERROR_NOT_USED			= 4,
                text = "Función no usada"

            Case 5 'SGFDX_ERROR_DLLLOAD_FAILED	= 5,
                text = "No se puede crear objeto"

            Case 6 'SGFDX_ERROR_DLLLOAD_FAILED_DRV	= 6,
                text = "No se puede cargar driver de dispositivo"

            Case 7 'SGFDX_ERROR_DLLLOAD_FAILED_ALGO = 7,
                text = "No se puede cargar sgfpamx.dll"

            Case 51 'SGFDX_ERROR_SYSLOAD_FAILED	   = 51,	// system file load fail
                text = "No se puede cargar driver de kernel"

            Case 52 'SGFDX_ERROR_INITIALIZE_FAILED  = 52,   // chip initialize fail
                text = "Falla al inicializar el dispositivo"

            Case 53 'SGFDX_ERROR_LINE_DROPPED		   = 53,   // image data drop
                text = "La transmisión de datos no es buena"

            Case 54 'SGFDX_ERROR_TIME_OUT			   = 54,   // getliveimage timeout error
                text = "Tiempo terminado"

            Case 55 'SGFDX_ERROR_DEVICE_NOT_FOUND	= 55,   // device not found
                text = "No se encontró el dispositivo"

            Case 56 'SGFDX_ERROR_DRVLOAD_FAILED	   = 56,   // dll file load fail
                text = "No se puede cargar driver de archivo"

            Case 57 'SGFDX_ERROR_WRONG_IMAGE		   = 57,   // wrong image
                text = "Imagen incorrecta"

            Case 58 'SGFDX_ERROR_LACK_OF_BANDWIDTH  = 58,   // USB Bandwith Lack Error
                text = "Ausencia de USB ancho de banda"

            Case 59 'SGFDX_ERROR_DEV_ALREADY_OPEN	= 59,   // Device Exclusive access Error
                text = "El dispositivo ya se encuentra abierto"

            Case 60 'SGFDX_ERROR_GETSN_FAILED		   = 60,   // Fail to get Device Serial Number
                text = "Error en el nº de serie del dispositivo"

            Case 61 'SGFDX_ERROR_UNSUPPORTED_DEV		   = 61,   // Unsupported device
                text = "Dispositivo no soportado"

                ' Extract & Verification error
            Case 101 'SGFDX_ERROR_FEAT_NUMBER		= 101, // utoo small number of minutiae
                text = "Nº de minucias es muy pequeño"

            Case 102 'SGFDX_ERROR_INVALID_TEMPLATE_TYPE		= 102, // wrong template type
                text = "Plantilla no válida"


            Case 103 'SGFDX_ERROR_INVALID_TEMPLATE1		= 103, // wrong template type
                text = "1ra Plantilla no válida"

            Case 104 'SGFDX_ERROR_INVALID_TEMPLATE2		= 104, // vwrong template type
                text = "2da Plantilla no válida"

            Case 105 'SGFDX_ERROR_EXTRACT_FAIL		= 105, // extraction fail
                text = "Error al extraer minucias"

            Case 106 'SGFDX_ERROR_MATCH_FAIL		= 106, // matching  fail
                text = "Error de coincidencia"


        End Select

        Return text
        'text = NombreError + " Error # " + Convert.ToString(NumeroError) + " :" + text
    End Function

    Sub AbrirDispositivo(id As Integer)
        Dim dispositivo As SGFPMDeviceName
        Dim intIdDispositivo As Integer
        Dim intError As Integer

        dispositivo = mLista(id).DevName
        intIdDispositivo = mLista(id).DevID

        intError = fpHuella.Init(dispositivo)
        intError = fpHuella.OpenDevice(intIdDispositivo)

        If Not (intError = SGFPMError.ERROR_NONE) Then 'error al abrir dispositivo
            Throw New Exception(intError)
        End If
    End Sub

    Function ObtenerDispositivo() As ArrayList
        Dim lista As New ArrayList
        Dim intError As Integer = fpHuella.EnumerateDevice()
        Dim strDispositivo As String

        ReDim mLista(fpHuella.NumberOfDevice)
        For i As Integer = 0 To fpHuella.NumberOfDevice - 1
            mLista(i) = New SGFPMDeviceList
            fpHuella.GetEnumDeviceInfo(i, mLista(i))
            strDispositivo = mLista(i).DevName.ToString() + " : " + Convert.ToString(mLista(i).DevID)
            lista.Add(strDispositivo)
        Next
        Return lista
    End Function

    Sub ObtenerInfoDispositivo()
        Dim info As SGFPMDeviceInfoParam
        Dim intError As Integer

        info = New SGFPMDeviceInfoParam
        intError = fpHuella.GetDeviceInfo(info)

        If (intError = SGFPMError.ERROR_NONE) Then
            intAncho = info.ImageWidth
            intAlto = info.ImageHeight
        Else
            Throw New Exception(intError)
        End If
    End Sub

    Sub CapturarHuella(ByRef imagen() As Byte)
        Dim intError As Integer

        ReDim imagen(intAncho * intAlto)
        intError = fpHuella.GetImage(imagen)
        If Not (intError = SGFPMError.ERROR_NONE) Then
            Throw New Exception(intError)
        End If
    End Sub

    Sub CapturarHuella(ByRef imagen() As Byte, tiempo As Integer, handle As Integer, calidad As Integer)
        Dim intError As Integer

        ReDim imagen(intAncho * intAlto)
        intError = fpHuella.GetImageEx(imagen, tiempo, handle, calidad)
        If Not (intError = SGFPMError.ERROR_NONE) Then
            Throw New Exception(intError)
        End If
    End Sub

    Function byteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Using mStream As New MemoryStream(byteArrayIn)
            Return Image.FromStream(mStream)
        End Using
    End Function

    Sub MostrarHuella(imagen() As Byte, picBox As PictureBox, opcion As Integer, Optional longitud As Integer = 0)
        'opcion 1 muestra raw como imagen
        'opcion 2 muestra wsq como imagen
        If opcion = 1 Then
            Dim colorval As Int32
            Dim bmp As Bitmap
            Dim i, j As Int32

            bmp = New Bitmap(intAncho, intAlto)
            picBox.Image = bmp

            For i = 0 To bmp.Width - 1
                For j = 0 To bmp.Height - 1
                    colorval = imagen((j * intAncho) + i)
                    bmp.SetPixel(i, j, Color.FromArgb(colorval, colorval, colorval))
                Next j
            Next i
        Else
            'hlamas 02-02-2016
            Dim buffer() As Byte
            buffer = Nothing
            Dim ancho As Integer = 0
            Dim altura As Integer = 0
            Dim pixel As Integer = 0
            Dim ppi As Integer = 0
            Dim flag As Integer = 0

            Dim err As Integer = WsqtoRaw(buffer, ancho, altura, pixel, ppi, flag, imagen, 120000)

            Dim pic As New PictureBox
            Dim img As Image
            intAncho = ancho
            intAlto = altura
            MostrarHuella(buffer, pic, 1)
            picBox.Image = pic.Image
        End If
        picBox.Refresh()
    End Sub

    Sub GrabarHuella(tipo As Integer, comprobante As Integer, numero_documento As String, plantilla() As Byte, _
                     usuario As Integer, ip As String, calidad As Integer, problema As Integer, motivo As String, version As Integer)
        'Dim con As OracleClient.OracleConnection
        Try
            Dim block As String
            block = "INSERT INTO t_huella (tipo,comprobante,numero_documento,plantilla,usuario,ip,calidad,problema,motivo,version) "
            block = block & "VALUES (:tipo,:comprobante,:numero_documento,:plantilla,:usuario,:ip,:calidad,:problema,:motivo,:version)"

            Dim cmd As OracleClient.OracleCommand = New OracleClient.OracleCommand
            cmd.CommandText = block
            cmd.CommandType = CommandType.Text

            Dim cadena_conexion = "data source=" + rptservice + "; user id=titan; password=titan"
            con = New System.Data.OracleClient.OracleConnection(cadena_conexion)
            con.Open()
            cmd.Connection = con

            Dim param1 As OracleClient.OracleParameter = cmd.Parameters.Add("tipo", OracleClient.OracleType.Int32)
            param1.Direction = ParameterDirection.Input
            param1.Value = tipo

            Dim param2 As OracleClient.OracleParameter = cmd.Parameters.Add("comprobante", OracleClient.OracleType.Int32)
            param2.Direction = ParameterDirection.Input
            param2.Value = comprobante

            Dim param3 As OracleClient.OracleParameter = cmd.Parameters.Add("numero_documento", OracleClient.OracleType.VarChar)
            param3.Direction = ParameterDirection.Input
            param3.Value = numero_documento

            'Dim param4 As OracleClient.OracleParameter = cmd.Parameters.Add("huella", OracleClient.OracleType.Blob)
            'param4.Direction = ParameterDirection.Input
            'param4.Value = huella

            Dim param5 As OracleClient.OracleParameter = cmd.Parameters.Add("plantilla", OracleClient.OracleType.Blob)
            param5.Direction = ParameterDirection.Input
            param5.Value = plantilla

            Dim param6 As OracleClient.OracleParameter = cmd.Parameters.Add("usuario", OracleClient.OracleType.Int32)
            param6.Direction = ParameterDirection.Input
            param6.Value = usuario

            Dim param7 As OracleClient.OracleParameter = cmd.Parameters.Add("ip", OracleClient.OracleType.VarChar)
            param7.Direction = ParameterDirection.Input
            param7.Value = ip

            Dim param8 As OracleClient.OracleParameter = cmd.Parameters.Add("calidad", OracleClient.OracleType.Int32)
            param8.Direction = ParameterDirection.Input
            param8.Value = calidad

            Dim param9 As OracleClient.OracleParameter = cmd.Parameters.Add("problema", OracleClient.OracleType.Int32)
            param9.Direction = ParameterDirection.Input
            param9.Value = problema

            Dim param10 As OracleClient.OracleParameter = cmd.Parameters.Add("motivo", OracleClient.OracleType.VarChar)
            param10.Direction = ParameterDirection.Input
            param10.Value = motivo

            Dim param11 As OracleClient.OracleParameter = cmd.Parameters.Add("version", OracleClient.OracleType.VarChar)
            param11.Direction = ParameterDirection.Input
            param11.Value = version
            cmd.ExecuteNonQuery()
            CerrarConexion()

        Catch ex As Exception
            CerrarConexion()
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub CargarHuella(tipo As Integer, comprobante As Integer, ByRef huella() As Byte)
        'Dim con As OracleClient.OracleConnection
        Try
            'hlamas 02-02-2016
            Dim block As String = "select plantilla from t_huella where tipo=:tipo and comprobante=:comprobante and version=1"
            Dim cmd As OracleClient.OracleCommand = New OracleClient.OracleCommand
            cmd.CommandText = block
            cmd.CommandType = CommandType.Text

            Dim cadena_conexion = "data source=" + rptservice + "; user id=titan; password=titan"
            con = New System.Data.OracleClient.OracleConnection(cadena_conexion)
            con.Open()
            cmd.Connection = con

            Dim param1 As OracleClient.OracleParameter = cmd.Parameters.Add("tipo", OracleClient.OracleType.Int32)
            param1.Direction = ParameterDirection.Input
            param1.Value = tipo

            Dim param2 As OracleClient.OracleParameter = cmd.Parameters.Add("comprobante", OracleClient.OracleType.Int32)
            param2.Direction = ParameterDirection.Input
            param2.Value = comprobante

            Dim dr As OracleClient.OracleDataReader = cmd.ExecuteReader()
            dr.Read()
            If dr.HasRows Then
                huella = dr(0)
            Else
                huella = Nothing
            End If
            CerrarConexion()

        Catch ex As Exception
            CerrarConexion()
            'Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub CargarHuella(numero As String, ByRef dt As DataTable) 'ByRef dr As OracleClient.OracleDataReader)
        'Dim con As OracleClient.OracleConnection
        Try
            'Dim block As String = "select plantilla from t_huella where numero_documento=:numero and problema=0 and version=1 order by calidad desc"
            Dim block As String
            block = "select plantilla from ("
            block = block & "select plantilla,calidad from t_huella where numero_documento=:numero and problema=0 and version=1 order by calidad desc"
            block = block & ") where rownum<=5"

            Dim cmd As OracleClient.OracleCommand = New OracleClient.OracleCommand
            cmd.CommandText = block
            cmd.CommandType = CommandType.Text

            Dim cadena_conexion = "data source=" + rptservice + "; user id=titan; password=titan"
            con = New System.Data.OracleClient.OracleConnection(cadena_conexion)
            con.Open()
            cmd.Connection = con

            Dim param1 As OracleClient.OracleParameter = cmd.Parameters.Add("numero", OracleClient.OracleType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = numero

            Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
            daora.Fill(dt)
            CerrarConexion()

            'dr = cmd.ExecuteReader()
            'dr.Read()
            'If dr.HasRows Then
            '    huella = dr(0)
            'Else
            '    huella = Nothing
            'End If

        Catch ex As Exception
            CerrarConexion()
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Function LeerArchivo(archivo As String) As Byte()
        Dim len As Integer
        Dim buffer() As Byte

        Dim fs As FileStream = File.OpenRead(archivo)
        len = fs.Length
        ReDim buffer(len)

        fs.Read(buffer, 0, buffer.Length)
        fs.Close()

        Return buffer
    End Function

    Function EscribirArchivo(archivo As String, buffer() As Byte) As Integer
        Dim fs As FileStream = File.Create(archivo)
        fs.Write(buffer, 0, buffer.Length)
        fs.Close()
        Return 0
    End Function

    Sub ObtenerTamañoImagen(buffer() As Byte, ByRef ancho As Integer, ByRef alto As Integer)

        Dim pic As New PictureBox
        Dim imagen As Image
        MostrarHuella(buffer, pic, 1)

        Dim img As Image = pic.Image
        ancho = img.Width
        alto = img.Height

        img.Dispose()
    End Sub

    Sub CrearPlantilla(huella() As Byte, ByRef plantilla() As Byte, opcion As Integer, _
                       Optional ratio As Single = 0, Optional pixel As Integer = 0, Optional ppi As Integer = 0, Optional comentario As String = "")
        'opcion 1 crea una plantilla wsq
        'opcion 2 crea una plantilla secugen
        'hlamas 02-02-2016
        If opcion = 1 Then
            Dim longitud As Integer, ancho As Integer, alto As Integer
            ObtenerTamañoImagen(huella, ancho, alto)
            Dim err As Integer = RawtoWsq(plantilla, longitud, ratio, huella, ancho, alto, pixel, ppi, comentario)
            'Dim strArchivo As String = Application.StartupPath & "\huella.wsq"
            'EscribirArchivo("huella.wsq", plantilla)
        Else
            Dim intError As Integer
            intError = fpHuella.CreateTemplate(huella, plantilla)
            If Not (intError = SGFPMError.ERROR_NONE) Then
                Throw New Exception(intError)
            End If
        End If
    End Sub

    Sub VerificarPlantilla(plantilla1() As Byte, plantilla2() As Byte, NivelSeguridad As Integer, ByRef coinciden As Boolean)
        Dim fpNivelSeguridad As SGFPMSecurityLevel
        Dim intError As Integer

        fpNivelSeguridad = NivelSeguridad
        intError = fpHuella.MatchTemplate(plantilla1, plantilla2, fpNivelSeguridad, coinciden)
        If Not (intError = SGFPMError.ERROR_NONE) Then
            Throw New Exception(intError)
        End If
    End Sub

    Sub LectorAutomatico(activar As Boolean, handle As Integer)
        fpHuella.EnableAutoOnEvent(activar, handle)
    End Sub

    Sub HuellaCapturada(msg As Message, ByRef activo As Boolean)
        If msg.Msg = SGFPMMessages.DEV_AUTOONEVENT Then
            If (msg.WParam.ToInt32 = SGFPMAutoOnEvent.FINGER_ON) Then
                activo = True
            ElseIf (msg.WParam.ToInt32() = SGFPMAutoOnEvent.FINGER_OFF) Then
                activo = False
            End If
        End If
    End Sub

    Sub ObtieneCalidad(ancho As Integer, alto As Integer, imagen() As Byte, ByRef calidad As Integer)
        Dim intError As Integer = fpHuella.GetImageQuality(ancho, alto, imagen, calidad)
        If Not (intError = SGFPMError.ERROR_NONE) Then
            Throw New Exception(intError)
        End If
    End Sub

    Sub CerrarDispositivo()
        Dim intError As Integer = fpHuella.CloseDevice()
        If Not (intError = SGFPMError.ERROR_NONE) Then
            Throw New Exception(intError)
        End If
    End Sub

    Function RawtoWsq(ByRef wsq() As Byte, ByRef longitud As Integer, ratio As Single, imagen() As Byte, _
                                    ancho As Integer, altura As Integer, pixel As Integer, ppi As Integer, comentario As String) As Integer
        Dim buffer As IntPtr
        buffer = IntPtr.Zero

        Dim intRetorno As Integer
        If dtoUSUARIOS.win = 1 Then
            intRetorno = _SGWSQ_Encode(buffer, longitud, ratio, imagen, ancho, altura, pixel, ppi, utf8.GetBytes(comentario))
        Else
            intRetorno = SGWSQ_Encode(buffer, longitud, ratio, imagen, ancho, altura, pixel, ppi, utf8.GetBytes(comentario))
        End If

        ReDim wsq(longitud)
        Marshal.Copy(buffer, wsq, 0, longitud)
        If dtoUSUARIOS.win = 1 Then
            _SGWSQ_Free(buffer)
        Else
            SGWSQ_Free(buffer)
        End If

        Return intRetorno
    End Function

    Function WsqtoRaw(ByRef raw() As Byte, ByRef ancho As Integer, ByRef altura As Integer, ByRef pixel As Integer, ByRef ppi As Integer, ByRef flag As Integer, _
                       imagen() As Byte, longitud As Integer)
        Dim buffer As IntPtr
        buffer = IntPtr.Zero

        Dim intRetorno As Integer
        If dtoUSUARIOS.win = 1 Then
            intRetorno = _SGWSQ_Decode(buffer, ancho, altura, pixel, ppi, flag, imagen, longitud)
        Else
            intRetorno = SGWSQ_Decode(buffer, ancho, altura, pixel, ppi, flag, imagen, longitud)
        End If
        ReDim raw(ancho * altura)
        Marshal.Copy(buffer, raw, 0, ancho * altura)
        If dtoUSUARIOS.win = 1 Then
            _SGWSQ_Free(buffer)
        Else
            SGWSQ_Free(buffer)
        End If


        Return intRetorno
    End Function

    Function WsqtoTemplate(ByRef plantilla() As Byte, ByRef ancho As Integer, ByRef altura As Integer, ByRef pixel As Integer, ByRef ppi As Integer, ByRef flag As Integer, _
                       imagen() As Byte, longitud As Integer)
        Dim raw() As Byte
        Dim buffer As IntPtr
        buffer = IntPtr.Zero

        Dim intRetorno As Integer
        If dtoUSUARIOS.win = 1 Then
            intRetorno = _SGWSQ_Decode(buffer, ancho, altura, pixel, ppi, flag, imagen, longitud)
        Else
            intRetorno = SGWSQ_Decode(buffer, ancho, altura, pixel, ppi, flag, imagen, longitud)
        End If

        ReDim raw(ancho * altura)
        Marshal.Copy(buffer, raw, 0, ancho * altura)
        If dtoUSUARIOS.win = 1 Then
            _SGWSQ_Free(buffer)
        Else
            SGWSQ_Free(buffer)
        End If

        CrearPlantilla(raw, plantilla, 2)

        Return intRetorno
    End Function

    Sub CerrarConexion()
        If con.State = ConnectionState.Open Then con.Close()
    End Sub

    Sub New()
        fpHuella = New SGFingerPrintManager
    End Sub
End Class
