Imports AccesoDatos
Enum RECOJO
    PENDIENTE = 1
    APROBADO = 2
    REPROGRAMADO = 3
    PARCIAL = 4
    CERRADO = 5
    CANCELADO = 6
    ATENDIDO = 7
    COMPLETADO = 8
    NOATENDIDO = 9
    RECHAZADO = 10
    ENCURSO = 11
End Enum

Enum TipoCliente
    ENCOMIENDA = 0
    CREDITO = 8
    ACOMPAÑADA = 6
    COURIER = 8
    SOBRE = 10
    TEPSABOX = 81
End Enum
Structure sRecojoReprogramado
    Dim recojo As Integer
    Dim ruta As Integer
    Dim tipo As Integer
End Structure
Module ModRecojo
    Public aRecojo() As sRecojoReprogramado
    Public cRows As DataGridViewSelectedRowCollection
    Public sFechaVigente As String
    Public bNoCambioContacto, bNoCambioFijo, bNoCambioMovil, bNoCambioDireccion As Boolean
    Private EMAIL As String = "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"

    'Declaración de constantes necesarias (valores en hexadecimal)

    Private Const MF_BYPOSITION As Integer = &H400
    Private Const MF_REMOVE As Integer = &H1000
    Private Const MF_DISABLED As Integer = &H2

    'Variable para saber si ya está desactivado el botón X
    Private pulsado As Boolean = True

    'Importación de procedimientos externos almacenados
    'en la librería de Windows USER32.DLL

    'Obtener el menú de sistema
    Private Declare Function GetSystemMenu Lib "User32" _
            (ByVal hWnd As Integer, _
            ByVal bRevert As Boolean) As IntPtr

    'Obtener el número de elementos del menú de sistema
    Private Declare Function GetMenuItemCount Lib "User32" _
             (ByVal hMenu As Integer) As IntPtr

    'Quitar elementos del menú de sistema
    Private Declare Function RemoveMenu Lib "User32" _
        (ByVal hMenu As Integer, _
        ByVal nPosition As Integer, _
        ByVal wFlags As Long) As IntPtr

    'Redibujar la barra de título de la ventana
    Private Declare Function DrawMenuBar Lib "User32" _
            (ByVal hWnd As Integer) As IntPtr

    'Método que desactiva el botón X (cerrar)
    Public Sub DisableCloseButton(ByVal hWnd As IntPtr)
        Try 'captura de excepciones

            Dim menuItemCount As IntPtr
            Dim hMenu As IntPtr
            'Obtener el manejador del menú de sistema del formulario
            hMenu = GetSystemMenu(hWnd.ToInt32(), False)
            'Obtener la cuenta de los ítems del menú de sistema.
            'Es el menú que aparece al pulsar sobre el icono a la izquierda
            'de la Barra de título de la ventana, consta de los ítems: Restaurar, Mover,
            'Tamaño,Minimizar,  Maximizar, Separador, Cerrar.
            menuItemCount = GetMenuItemCount(hMenu.ToInt32())
            'Quitar el ítem Close (Cerrar), que es el último de ese menú
            RemoveMenu(hMenu.ToInt32(), menuItemCount.ToInt32() - 1, MF_DISABLED Or MF_BYPOSITION)
            'Quitar el ítem Separador, el penúltimo de ese menú, entre Maximizar y Cerrar
            RemoveMenu(hMenu.ToInt32(), menuItemCount.ToInt32() - 2, MF_DISABLED Or MF_BYPOSITION)
            'Redibujar la barra de menú
            DrawMenuBar(hWnd.ToInt32())

            'mostrar un mensaje con la excepción producida
        Catch pollo As Exception
            MessageBox.Show("Se ha producido la excepción: " + vbCrLf + pollo.Message, _
            "Error del programa", MessageBoxButtons.OK)
        End Try
    End Sub

    Function FechaServidor() As String
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("select sf_get_fecha_hora_servidor from dual", CommandType.Text)
            Dim sValor As String = db.EjecutarEscalar()
            db.Desconectar()
            Return sValor
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    Function FechaServidor(ByVal i As Integer) As String
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("select sf_get_fecha_servidor from dual", CommandType.Text)
            Dim sValor As String = db.EjecutarEscalar()
            db.Desconectar()
            Return sValor
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    Sub SeleccionarCheckDgv(ByVal dgv As DataGridView, ByVal col As Integer, ByVal estado As Integer)
        Try
            For Each row As DataGridViewRow In dgv.Rows
                row.Cells(col).Value = estado
            Next
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    Sub SeleccionarCheckDgv(ByVal row As DataGridViewRow, ByVal col As Integer, ByVal estado As Integer)
        'Dim obj As New DtoRecojo
        Try
            row.Cells(col).Value = estado
            'obj.ActualizarSeleccion(row.Cells("id_recojo").Value, estado)
            'obj = Nothing

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'Public Function fnValidarRUC(ByVal strRUC As String) As Boolean

    '    Dim ret As Boolean = False
    '    Try
    '        Dim nDig, nd0, nd1, nd2, nd3, nd4, nd5, nd6, nd7, nd8, nd9, nRUC, nRes As Integer
    '        Dim strRes As String
    '        nDig = Int(strRUC.Substring(strRUC.Length - 1).ToString)
    '        nd0 = Int(strRUC.Substring(0, 1).ToString()) * 5
    '        nd1 = Int(strRUC.Substring(1, 1).ToString()) * 4
    '        nd2 = Int(strRUC.Substring(2, 1).ToString()) * 3
    '        nd3 = Int(strRUC.Substring(3, 1).ToString()) * 2
    '        nd4 = Int(strRUC.Substring(4, 1).ToString()) * 7
    '        nd5 = Int(strRUC.Substring(5, 1).ToString()) * 6
    '        nd6 = Int(strRUC.Substring(6, 1).ToString()) * 5
    '        nd7 = Int(strRUC.Substring(7, 1).ToString()) * 4
    '        nd8 = Int(strRUC.Substring(8, 1).ToString()) * 3
    '        nd9 = Int(strRUC.Substring(9, 1).ToString()) * 2
    '        nRUC = nd0 + nd1 + nd2 + nd3 + nd4 + nd5 + nd6 + nd7 + nd8 + nd9
    '        nRes = nRUC Mod 11
    '        strRes = Int(nRes.ToString)
    '        nRes = 11 - Int(strRes.Substring(strRes.Length - 1).ToString)
    '        strRes = Int(nRes)
    '        If nDig = Int(strRes.Substring(strRes.Length - 1).ToString) Then
    '            ret = True
    '        End If
    '    Catch ex As Exception
    '        ret = False
    '    End Try
    '    Return ret
    'End Function
    'Public Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
    '    If UCase(e.KeyChar) Like "[!0-9.-]" Then
    '        If Not Asc(e.KeyChar) = Keys.Back Then
    '            Return True
    '        End If
    '    End If

    '    Dim c As Short = 0
    '    If UCase(e.KeyChar) Like "[.]" Then
    '        If InStr(cajasTexto.Text, ".") > 0 Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    End If
    'End Function

    Public Function ValidarEMail(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex(EMAIL)
        If re.IsMatch(txtStr.ToString()) Then
            ValidarEMail = True
        Else
            ValidarEMail = False
        End If
    End Function

    Public Function ValidarN(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidarN = True
        Else
            ValidarN = False
        End If
    End Function

    Public Function fnTECHO(ByVal monto As String) As String
        Dim monto_total As String = monto
        Try
            Dim varMonto() As String = Split(monto_total, ".")
            If varMonto.Length > 1 Then
                If Val(varMonto(1).ToString) < 50 Then '12/03/2008 - Puedo modificarse acá poniendo igual 
                    monto_total = varMonto(0) & ".50"
                Else
                    Dim Entero As String() = Split(varMonto(0).ToString, ",")
                    Dim i As Integer = 0
                    monto_total = varMonto(0).ToString
                    If Entero.Length >= 1 Then
                        monto_total = ""
                    End If
                    For i = 0 To Entero.Length - 1
                        monto_total = monto_total & Entero(i).ToString
                    Next
                    'monto_total = Val(monto_total) + 1   -- 01/09/2010 
                    If Val(varMonto(1)) > 500 Then
                        monto_total = Val(monto_total) + 1
                    Else
                        monto_total = Val(monto_total) + 0.5
                    End If
                    ' monto_total = monto_total.ToString & ".00"
                End If
            End If
        Catch ex As Exception
            '
        End Try
        'Modificado 12/03/2008 tema de redondeo 
        If monto Mod 0.5 = 0 Then
            Return monto
        Else
            Return monto_total
        End If
    End Function

End Module
