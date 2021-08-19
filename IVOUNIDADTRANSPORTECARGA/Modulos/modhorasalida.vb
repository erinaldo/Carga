Module modhorasalida
    Public Function validar_hora_salida(ByVal shora As String) As String
        Dim dhora As Date
        Dim longitud As Integer
        Dim shoraret As String
        Dim posicion As Integer
        Try
            If IsDBNull(shora) = True Then
                shora = "00:00"
            End If
            '--
            'If shora = "00:00" Then
            '    MessageBox.Show("Hora Vacia...Verifique", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Return ""
            '    Exit Function
            'End If
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
            MessageBox.Show("Formato de Hora Incorrecta...Verifique", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function    
End Module
