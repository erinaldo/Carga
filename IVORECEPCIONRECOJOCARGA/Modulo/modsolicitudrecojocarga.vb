Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Resources
Module ModSolRecojoCarga
    Public busquedapor As Integer
    Public idcliente As Integer
    Public scliente As String
    Public idcontacto As Integer
    Public scontacto As String
    Public idireccion As Integer
    'Llamando a direcciones y contacto del consignado 
    Public idagencia As Integer
    Public frmfilapadre As Integer
    Public bcancelar As Boolean
    'Pasando para el mantenimiento de cliente 
    Public iddireccion_consignado As Integer
    Public tipodireccion As Integer
    Public idubigeo As Integer
    Public idpais As Integer
    Public iddpto As Integer
    Public idprov As Integer
    Public iddistrito As Integer
    Public sdireccion As String
    Public smensaje As String
    Public srefllegada As String
    Public snrodcto As String
    '
    Public sapellidos_nombres As String
    'Public snombre As String
    'Public sapepaterno As String
    'Public sapematerno As String
    Public idsucuenta As Integer
    Public idcargo As Integer
    Public idtipdcto As Integer
    Public idsexo As Integer
    'Validando el formato de la hora 
    '
    Public ps_telefono_contcto As String
    Public Function validar_hora(ByVal shora As String) As String
        Dim dhora As Date
        Dim longitud As Integer
        Dim shoraret As String
        Dim posicion As Integer
        Try
            If IsDBNull(shora) = True Then
                shora = "00:00"
            End If
            '--
            If shora = "00:00" Then
                MessageBox.Show("Hora de Viaje Vacio...Verifique", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ""
                Exit Function
            End If
            '--
            longitud = Len(shora)
            Select Case longitud
                Case 1
                    'HORA = DateAdd(DateInterval.Hour, Convert.ToDouble("0" & Convert.ToString(shora) & ":00"), HORA)
                    dhora = CType(Convert.ToDateTime("0" & shora & ":00"), Date)
                Case 2
                    dhora = CType(Convert.ToDateTime(shora & ":00"), Date)
                    ' HORA = DateAdd(DateInterval.Hour, Convert.ToDouble(Convert.ToString(shora) & ":00"), HORA)
                Case 3
                    posicion = InStrRev(shora, ":")
                    Select Case posicion
                        Case 0
                            dhora = CType(Convert.ToDateTime(Mid(shora, 1, 2) & ":" & Mid(shora, 3, 1) & "0"), Date)
                        Case 1 'Recojo la hora.
                            dhora = CType(Convert.ToDateTime("00" + shora), Date)
                        Case 2
                            dhora = CType(Convert.ToDateTime("0" + Mid(shora, 1, 3) & "0"), Date)
                        Case 3
                            dhora = CType(Convert.ToDateTime(shora & "00"), Date)
                        Case Else
                            dhora = CType(Convert.ToDateTime(shora & "00"), Date)
                    End Select
                Case 4
                    posicion = InStrRev(shora, ":")
                    Select Case posicion
                        Case 0
                            dhora = CType(Convert.ToDateTime(Mid(shora, 1, 2) & ":" & Mid(shora, 3, 2)), Date)
                        Case 2
                            dhora = CType(Convert.ToDateTime("0" + Mid(shora, 1, 4)), Date)
                        Case 3
                            dhora = CType(Convert.ToDateTime(shora & "0"), Date)
                        Case Else
                            dhora = CType(Convert.ToDateTime(shora & "0"), Date)
                    End Select
                Case 5
                    dhora = CType(Convert.ToDateTime(shora), Date)
            End Select
            shoraret = Format(dhora, "HH:mm")
            'fecha_fin = DateAdd(DateInterval.Hour, Convert.ToDouble(Mid(Convert.ToString(shora), 1, 2)), fecha_fin)
            'fecha_fin = DateAdd(DateInterval.Minute, Convert.ToDouble(Mid(Convert.ToString(shora), 4, 2)), fecha_fin)
            Return shoraret
        Catch ex As Exception
            MessageBox.Show("Formato de Fecha Incorrecta...Verifique", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function
    'Validando el número double 
    Public Function valida_numerodouble(ByVal snumero As String) As Boolean
        Dim dnumero As Double
        Try
            If IsDBNull(snumero) = True Then
                Return True
            Else
                If snumero = "" Then
                    Return True
                End If
            End If
                dnumero = Format(Math.Round(Convert.ToDouble(snumero), 2), "###,###0.00")
                Return True
        Catch ex As Exception
            MsgBox("Número no válido", MsgBoxStyle.Critical, "Seguridad Sistema")
            Return False
        End Try
    End Function
    'Validando entero 
    Public Function valida_numeroentero(ByVal snumero As String) As Boolean
        Dim dnumero As Integer
        Try
            If IsDBNull(snumero) = True Then
                Return True
            Else
                If snumero = "" Then
                    Return True
                End If
            End If
            dnumero = Format(Math.Round(Convert.ToInt64(snumero), 2), "###,###,###0")
            Return True
        Catch ex As Exception
            MsgBox("Número no válido", MsgBoxStyle.Critical, "Seguridad Sistema")
            Return False
        End Try
    End Function
End Module