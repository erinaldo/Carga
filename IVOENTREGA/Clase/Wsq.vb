Imports System.Runtime.InteropServices
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO

Public Class Wsq
    Dim utf8 As New UTF8Encoding

    <DllImport("sgwsqlib.dll", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True, entrypoint:="_SGWSQ_Encode@36")> _
    Public Shared Function SGWSQ_Encode(ByRef wsq As IntPtr, ByRef longitud As Integer, ratio As Single, imagen() As Byte, _
                                        ancho As Integer, altura As Integer, pixel As Integer, ppi As Integer, comentario() As Byte) As Integer
    End Function

    <DllImport("sgwsqlib.dll", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True, entrypoint:="_SGWSQ_Decode@32")> _
    Public Shared Function SGWSQ_Decode(ByRef raw As IntPtr, ByRef ancho As Integer, ByRef altura As Integer, ByRef pixel As Integer, ByRef ppi As Integer, _
                                        ByRef flag As Integer, imagen() As Byte, longitud As Integer) As Integer
    End Function

    <DllImport("sgwsqlib.dll", entrypoint:="_SGWSQ_Free@4")> _
    Public Shared Function SGWSQ_Free(wsq As IntPtr) As Integer
    End Function

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

    Function Decodificar(ByRef wsq() As Byte, ByRef longitud As Integer, ratio As Single, imagen() As Byte, _
                                        ancho As Integer, altura As Integer, pixel As Integer, ppi As Integer, comentario As String) As Integer
        Dim buffer As IntPtr
        buffer = IntPtr.Zero

        Dim intRetorno As Integer = SGWSQ_Encode(buffer, longitud, ratio, imagen, ancho, altura, pixel, ppi, utf8.GetBytes(comentario))
        ReDim wsq(longitud)
        Marshal.Copy(buffer, wsq, 0, longitud)
        SGWSQ_Free(buffer)

        Return intRetorno
    End Function

    Function Codificar(ByRef raw() As Byte, ByRef ancho As Integer, ByRef altura As Integer, ByRef pixel As Integer, ByRef ppi As Integer, ByRef flag As Integer, _
                       imagen() As Byte, longitud As Integer)
        Dim buffer As IntPtr
        buffer = IntPtr.Zero

        Dim intRetorno As Integer = SGWSQ_Decode(buffer, ancho, altura, pixel, ppi, flag, imagen, longitud)
        ReDim raw(ancho * altura)
        Marshal.Copy(buffer, raw, 0, ancho * altura)
        SGWSQ_Free(buffer)

        Return intRetorno
    End Function
End Class
