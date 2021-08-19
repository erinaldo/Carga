Imports System.IO
Imports System.Runtime.InteropServices
Public Class LogSistemaTitan_prueba
    Dim strNombreFile As String
    Dim strNombreFileErr As String
    Dim strFullPath As String
    Public Function CrearFolderLog(ByVal unidad As String, ByVal usuario As String, ByVal nombreFile As String) As Boolean
        Try
            strNombreFile = nombreFile
            strFullPath = unidad & "LOG_TITAN\" & nombreFile
            Directory.CreateDirectory(strFullPath)
            strNombreFile = strFullPath & "\" & usuario & nombreFile & ".log"
            strNombreFileErr = strFullPath & "\" & usuario & nombreFile & "Err.log"
            'System.IO.File.Create(strNombreFile)
            'strNombreFile = "C:\LOG_TITAN\21092009.txt"
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
        Return False
    End Function
    Public Function fnLog(ByVal str As String) As Boolean
        Try
            Dim fs As FileStream
            fs = File.Open(strNombreFile, FileMode.Append, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.WriteLine("[" & Now & "] User: " & dtoUSUARIOS.iLOGIN & " IP:" & dtoUSUARIOS.IP & " " & str)
            s.Flush()
            fs.Flush()
            s.Close()
            fs.Close()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function
    Public Function fnLogErr(ByVal str As String) As Boolean
        Try
            Dim fs As FileStream
            fs = File.Open(strNombreFileErr, FileMode.Append, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.WriteLine("[" & Now & "] User: " & dtoUSUARIOS.iLOGIN & " IP:" & dtoUSUARIOS.IP & " " & str)
            s.Flush()
            fs.Flush()
            s.Close()
            fs.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function

    Public Function fnLPT(ByVal fullPatLPT As String, ByVal str As String) As Boolean
        Try
            Dim fs As FileStream
            fs = File.Open(strNombreFile, FileMode.Append, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.WriteLine("\u0027 \u0112 \u0000 \u0064 \u0240")
            '& Environment.new
            s.WriteLine(Now & "  " & str)
            fs.Flush()
            s.Flush()
            s.Close()
            fs.Close()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function
    ' Public FILE_ATTRIBUTE_NORMAL As String = "0x80"
    'public INVALID_HANDLE_VALUE = -1;
    'public const uint GENERIC_READ = 0x80000000;
    'public const uint GENERIC_WRITE = 0x40000000;
    'public const uint CREATE_NEW = 1;
    'public const uint CREATE_ALWAYS = 2;
    'public const uint OPEN_EXISTING = 3;        
    Public Const GENERIC_WRITE = &H40000000
    Public Const OPEN_EXISTING = 3

    Public Const FILE_SHARE_WRITE = &H2

    Dim LPTPORT As String

    Dim hPort As Integer, hPortP As IntPtr

    Dim retval As Integer

    'Public Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" ( _

    Private nLength As Integer

    Private lpSecurityDescriptor As Integer

    Private bInheritHandle As Integer


    Public Function fnPrinterLPT() As Boolean
        Try


            ' Dim Texxxt As String   Tepsa 

            'Dim SA As SECURITY_ATTRIBUTES

            ' Dim outFile As FileStream Tepsa

            LPTPORT = "LPT1"

            '      hPort = CreateFile(LPTPORT, GENERIC_WRITE, FILE_SHARE_WRITE, SA, 
            'OPEN_EXISTING, 0, 0)

            '            hPortP = New IntPtr(hPort)  'convert Integer to IntPtr

            '            outFile = New FileStream(hPortP, FileAccess.Write, False) 'Create 
            '                FileStream using Handle

            '            Dim fileWriter As New StreamWriter(outFile)

            '            fileWriter.WriteLine("First test line.")

            '            fileWriter.WriteLine("Second test line.")

            '            fileWriter.WriteLine("Third and final test line.")

            '            fileWriter.Write(Chr(12))  'FormFeed Character

            '            fileWriter.Flush()

            '            fileWriter.Close()

            '            outFile.Close()

            '            retval = CloseHandle(hPort)

            '***********************************************
            'Dim intFileNo As Integer = FreeFile()
            ''m_handle = CreateFile(Prt, GENERIC_READ + GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0)
            ''FileOpen(intFileNo, "LPT1", OpenMode.Output, OpenAccess.Write)
            ''Print(intFileNo, Chr(27) & "W1")

            'Dim fs As FileStream
            'fs = File.Open("\\.\LPT1", FileMode.OpenOrCreate, FileAccess.Write)
            'Dim s As New StreamWriter(fs)
            's.WriteLine(Now & "  " & "Hola Muchas...")

            's.Flush()
            'fs.Flush()
            's.Close()
            'fs.Close()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Segurida Sistema")
        End Try

        Return False
    End Function
End Class
