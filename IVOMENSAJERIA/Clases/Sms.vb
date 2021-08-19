Imports System.IO.Ports

Public Class Sms
    Dim port As SerialPort

#Region "Propiedades"
    Private strPuerto As String
    Public Property Puerto() As String
        Get
            Return strPuerto
        End Get
        Set(ByVal value As String)
            strPuerto = value
        End Set
    End Property

    Private strMensaje As String
    Public Property Mensaje() As String
        Get
            Return strMensaje
        End Get
        Set(ByVal value As String)
            strMensaje = value
        End Set
    End Property

    Private strDestino As String
    Public Property Destino() As String
        Get
            Return strDestino
        End Get
        Set(ByVal value As String)
            strDestino = value
        End Set
    End Property
#End Region

    Sub AbrirPuerto()
        port.PortName = Puerto
        port.BaudRate = 19200 '9600 velocidad del puerto 
        port.Parity = Parity.Even ' Paridad 
        port.StopBits = StopBits.Two ' Bit de para 
        port.DataBits = 8 ' Bits de datos

        If port.IsOpen Then
            port.Close()
        End If

        port.Open()
    End Sub

    Sub CerrarPuerto()
        If port.IsOpen Then
            port.Close()
            port.Dispose()
        End If
    End Sub

    Function EnviarMensaje() As Boolean
        Try
            strDestino = Char.ConvertFromUtf32(34) & strDestino.Trim & Char.ConvertFromUtf32(34)
            port.Write("ATZ0" & vbCr)
            port.Write("AT+CMGF=1" & Char.ConvertFromUtf32(13))
            port.Write("AT+CMGS=" & strDestino & Char.ConvertFromUtf32(13))
            port.Write(strMensaje.Trim & Char.ConvertFromUtf32(26) & Char.ConvertFromUtf32(13))
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function Recibir_mensaje(ByVal Tipo As Integer) As String
        Try
            port.Write("ATZ&F" & Chr(13))
            port.Write("AT+CMGF=1" & Chr(13)) 'este comando establece el modo texto

            Select Case Tipo
                Case 0
                    port.Write("AT+CMGL=" & Chr(34) & "REC UNREAD" & Chr(34) & Chr(13)) 'solo recibiremos los sms no leidos
                Case 1
                    port.Write("AT+CMGL=" & Chr(34) & "REC READ" & Chr(34) & Chr(13)) 'solo recibiremos los sms leidos
                Case 2
                    port.Write("AT+CMGL=" & Chr(34) & "STO UNSENT" & Chr(34) & Chr(13)) 'solo recibiremos los sms no enviados
                Case 3
                    port.Write("AT+CMGL=" & Chr(34) & "STO SENT" & Chr(34) & Chr(13)) 'solo recibiremos los sms enviados
                Case 4
                    port.Write("AT+CMGL=" & Chr(34) & "ALL" & Chr(34) & Chr(13)) 'Recibiremos todos los sms

            End Select
            Recibir_mensaje = vbOK
        Catch ex As Exception
            Recibir_mensaje = ex.Message
        End Try
    End Function

    Function Auto_Recibir() As String
        Try
            port.Write("ATZ&F" & Chr(13)) 'reseteamos
            port.Write("AT+CMGF=1" & Chr(13)) 'establecemos el modo texto
            port.Write("AT+CNMI=" & Chr(34) & "1,2,0,0,0" & Chr(34) & Chr(13)) 'esto es más largo de explicar, recomiendo lo investiguen
            Auto_Recibir = vbOK
        Catch ex As Exception

            Auto_Recibir = ex.Message
        End Try

    End Function
    Sub New()
        port = New SerialPort
    End Sub

    Sub New(puerto As String)
        port = New SerialPort
        puerto = puerto
    End Sub
End Class
