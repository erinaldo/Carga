Imports System.IO
Imports System.Runtime.InteropServices
Imports AccesoDatos
Public Class Imprimir
    Dim sArchivo As String
    Dim Archivo As StreamWriter
    Dim sLista(500) As String
    Dim iFila(500) As Integer
    Dim item As Integer = 0
#Region "Propiedad"
    Private sImpresora As String
    Public Property Impresora() As String
        Get
            Return sImpresora
        End Get
        Set(ByVal value As String)
            sImpresora = value
        End Set
    End Property

    Private bComprimido As Boolean
    Public Property Comprimido() As Boolean
        Get
            Return bComprimido
        End Get
        Set(ByVal value As Boolean)
            bComprimido = value
        End Set
    End Property
    Private bPreliminar As Boolean
    Public Property Preliminar() As Boolean
        Get
            Return bPreliminar
        End Get
        Set(ByVal value As Boolean)
            bPreliminar = value
        End Set
    End Property
    Private bReglaVertical As Boolean
    Public Property ReglaVertical() As Boolean
        Get
            Return bReglaVertical
        End Get
        Set(ByVal value As Boolean)
            bReglaVertical = value
        End Set
    End Property
    Private bReglaHorizontal As Boolean
    Public Property ReglaHorizontal() As Boolean
        Get
            Return bReglaHorizontal
        End Get
        Set(ByVal value As Boolean)
            bReglaHorizontal = value
        End Set
    End Property

    Private iPaginas As Integer
    Public Property Paginas() As Integer
        Get
            Return iPaginas
        End Get
        Set(ByVal value As Integer)
            iPaginas = value
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
    ' Structure and API declarions:
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure DOCINFOW
        <MarshalAs(UnmanagedType.LPWStr)> Public pDocName As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pDataType As String
    End Structure

    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterW", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function OpenPrinter(ByVal src As String, ByRef hPrinter As IntPtr, ByVal pd As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterW", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, ByRef pDI As DOCINFOW) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="WritePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
    End Function

    ' SendBytesToPrinter()
    ' When the function is given a printer name and an unmanaged array of  
    ' bytes, the function sends those bytes to the print queue.
    ' Returns True on success or False on failure.
    Private Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean
        Dim hPrinter As IntPtr      ' The printer handle.
        Dim dwError As Int32        ' Last error - in case there was trouble.
        Dim di As DOCINFOW          ' Describes your document (name, port, data type).
        Dim dwWritten As Int32      ' The number of bytes written by WritePrinter().
        Dim bSuccess As Boolean     ' Your success code.

        ' Set up the DOCINFO structure.
        With di
            .pDocName = "My Visual Basic .NET RAW Document"
            .pDataType = "RAW"
        End With
        ' Assume failure unless you specifically succeed.
        bSuccess = False
        Dim ii As Long = 0
        If OpenPrinter(szPrinterName, hPrinter, 0) Then
            If StartDocPrinter(hPrinter, 1, di) Then
                If StartPagePrinter(hPrinter) Then
                    ' Write your printer-specific bytes to the printer.
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                    EndPagePrinter(hPrinter)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        ' If you did not succeed, GetLastError may give more information
        ' about why not.
        If bSuccess = False Then
            dwError = Marshal.GetLastWin32Error()
        End If
        Return bSuccess
    End Function ' SendBytesToPrinter()

    ' SendFileToPrinter()
    ' When the function is given a file name and a printer name, 
    ' the function reads the contents of the file and sends the
    ' contents to the printer.
    ' Presumes that the file contains printer-ready data.
    ' Shows how to use the SendBytesToPrinter function.
    ' Returns True on success or False on failure.
    Public Function EnviarArchivoImpresora(ByVal szPrinterName As String, ByVal szFileName As String) As Boolean
        ' Open the file.
        Dim fs As New FileStream(szFileName, FileMode.Open)
        '  Dim fs As New FileStream("c:\temp.txt", FileMode.Open)
        ' Create a BinaryReader on the file.
        Dim br As New BinaryReader(fs)
        ' Dim an array of bytes large enough to hold the file's contents.
        Dim bytes(fs.Length) As Byte
        Dim bSuccess As Boolean
        ' Your unmanaged pointer.
        Dim pUnmanagedBytes As IntPtr

        ' Read the contents of the file into the array.
        bytes = br.ReadBytes(fs.Length)
        ' Allocate some unmanaged memory for those bytes.
        pUnmanagedBytes = Marshal.AllocCoTaskMem(fs.Length)
        ' Copy the managed byte array into the unmanaged array.
        Marshal.Copy(bytes, 0, pUnmanagedBytes, fs.Length)
        ' Send the unmanaged bytes to the printer.
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, fs.Length)
        ' Free the unmanaged memory that you allocated earlier.
        Marshal.FreeCoTaskMem(pUnmanagedBytes)
        fs.Close()
        Return bSuccess
    End Function ' SendFileToPrinter()

    ' When the function is given a string and a printer name,
    ' the function sends the string to the printer as raw bytes.
    Public Function EnviarCadenaImpresora(ByVal szPrinterName As String, ByVal szString As String)
        Dim pBytes As IntPtr
        Dim dwCount As Int32
        ' How many characters are in the string?
        dwCount = szString.Length()
        ' Assume that the printer is expecting ANSI text, and then convert
        ' the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        ' Send the converted ANSI string to the printer.
        SendBytesToPrinter(szPrinterName, pBytes, dwCount)
        Marshal.FreeCoTaskMem(pBytes)
    End Function

    Public Shared Function ObtieneImpresora(ByVal iDocumento As Integer, ByVal ip As String) As String
        Dim s As String = ""
        Try
            Dim db_bd As New BaseDatos
            '
            Dim li_idproceso As Integer
            'Por defecto 4 Guias de Envio 
            li_idproceso = 4
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("SP_BUSCAR_IMPRESORA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_IdTipoComprobante", iDocumento, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_ip", ip, OracleClient.OracleType.VarChar)
            'Variables de salidas
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            Dim dt As DataTable = db_bd.EjecutarDataTable
            ' 
            If dt.Rows.Count > 0 Then
                s = IIf(IsDBNull(dt.Rows(0).Item("impresora")), "", dt.Rows(0).Item("impresora"))
            End If
            '
            Return s
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Private Function CrearArchivo(ByVal archivo As String) As StreamWriter
        Try
            If File.Exists(archivo) Then
                File.Delete(archivo)
            End If
            Return File.CreateText(archivo)
        Catch ex As DirectoryNotFoundException
            Throw New Exception(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Sub Inicializar()
        'Dim PathSys As String = Application.StartupPath()
        'sArchivo = "d:\temp.txt"
        sArchivo = PathSys + "\temp.txt"
        Archivo = CrearArchivo(sArchivo)
        bPreliminar = False
        bReglaVertical = False
        bReglaHorizontal = False
        iTamaño = 66
    End Sub

    Public Sub Inicializar(ByVal s As String)
        sArchivo = s
        Archivo = CrearArchivo(sArchivo)
        bPreliminar = False
        bReglaVertical = False
        bReglaHorizontal = False
        iTamaño = 66
    End Sub

    Public Sub EscribirLinea(ByVal s As String)
        Archivo.WriteLine(s)
    End Sub

    Private Function Existe(ByVal y As Integer) As Boolean
        For i As Integer = 1 To iFila.Length - 1
            If y = iFila(i) Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Sub EscribirLinea(ByVal yy As Integer, ByVal xx As Integer, ByVal s As String)
        Dim y As Integer = yy + iSuperior
        Dim x As Integer = xx + iIzquierda
        Dim str As String = IIf(IsNothing(sLista(y)), Space(500), sLista(y))
        str = str.Insert(x, s)
        sLista(y) = str

        If Not Existe(y) Then
            item += 1
            ReDim Preserve iFila(item)
            iFila(item) = y
        End If
    End Sub

    Private Sub GeneraReglaHorizontal()
        Dim z As Integer = 0
        For w As Integer = 1 To 140
            If z + 1 = 10 Then
                z = 0
            Else
                z += 1
            End If
            Archivo.Write(z)
        Next
        Archivo.WriteLine(" ")
    End Sub
    Public Sub Imprimir()
        Try
            If Comprimido AndAlso Not bPreliminar Then
                EnviarCadenaImpresora(sImpresora, Chr(27) & "SI" & Chr(15))
            End If

            'Ordena
            iFila.Sort(iFila)

            Dim num As Integer = 0
            If ReglaHorizontal Then
                'Activa regla horizontal
                GeneraReglaHorizontal()
                num += 1
            End If

            For i As Integer = 1 To iFila.Length - 1
                num += 1
                If num < iFila(i) Then
                    For j As Integer = num To iFila(i) - 1
                        If bReglaVertical Then
                            Archivo.Write(num)
                        Else
                            Archivo.Write(" ")
                        End If
                        num += 1
                        Archivo.WriteLine()
                    Next
                End If

                If bReglaVertical Then
                    If IsNothing(sLista(iFila(i))) Then
                        Archivo.WriteLine(num)
                    Else
                        Archivo.WriteLine(num & " " & sLista(iFila(i)).TrimEnd)
                    End If
                Else
                    If IsNothing(sLista(iFila(i))) Then
                        Archivo.WriteLine("")
                    Else
                        Archivo.WriteLine(sLista(iFila(i)).TrimEnd)
                    End If
                End If
            Next
            If num Mod iTamaño > 0 Then
                Do
                    num += 1
                    If bReglaVertical Then
                        Archivo.WriteLine(num & "")
                    Else
                        Archivo.WriteLine("")
                    End If
                Loop Until num Mod iTamaño = 0
            End If
            Archivo.AutoFlush = True
            Archivo.Close()

            If Not bPreliminar Then
                Dim bExito As Boolean = EnviarArchivoImpresora(Impresora, sArchivo)
                If Comprimido AndAlso Not bPreliminar Then
                    EnviarCadenaImpresora(sImpresora, Chr(27) & "SI" & Chr(18))
                End If

                If Not bExito Then
                    If sArchivo.Trim.Length = 0 Then
                        Throw New Exception("El Documento no tiene asociado una impresora.")
                    Else
                        Throw New Exception("Se ha producido un error en la impresión.")
                    End If
                End If
            End If

        Catch ex As Exception
            EnviarCadenaImpresora(sImpresora, Chr(27) & "SI" & Chr(18))
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub Finalizar()
        Archivo.Close()
        Archivo.Dispose()
        Archivo = Nothing
        If Not Preliminar Then
            File.Delete(sArchivo)
        End If
    End Sub
    Sub New()
    End Sub

    Sub AvanceLinea(Optional ByVal lineas As Integer = 1)
        For i As Integer = 1 To lineas
            EnviarCadenaImpresora(Impresora, ControlChars.CrLf)
        Next
    End Sub
    Sub AvancePagina()
        EnviarCadenaImpresora(Impresora, ControlChars.FormFeed)
    End Sub

    Public Sub EnviarArchivoImpresora()
        Try
            Archivo.AutoFlush = True
            Archivo.Close()

            Dim bExito As Boolean = EnviarArchivoImpresora(Impresora, sArchivo)
            If Not bExito Then
                If sArchivo.Trim.Length = 0 Then
                    Throw New Exception("El Documento no tiene asociado una impresora.")
                Else
                    Throw New Exception("Se ha producido un error en la impresión.")
                End If
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
