'Imports System.Windows.Forms
'Imports System.ComponentModel
'Imports System.Resources

Module ModuUtilom
    Public Function Validaciones(ByVal MyObligatorios As Object) As Integer
        'Dim Resp As Integer = 0
        'Static MyError As New ErrorProvider
        'For i As Integer = 0 To UBound(MyObligatorios)
        '    If Len(Trim(CType(MyObligatorios(i), TextBox).Text)) = 0 Then
        '        MyError.SetError(CType(MyObligatorios(i), TextBox), "Campo Obligatorio")
        '        Resp = 1
        '    Else
        '        MyError.SetError(CType(MyObligatorios(i), TextBox), "")
        '    End If
        'Next
        'Return Resp

        Dim Resp As Integer = 0
        Static MyError As New ErrorProvider
        For i As Integer = 0 To UBound(MyObligatorios)
            'Si la validacion sera en un TextBox con un Button
            If TypeOf MyObligatorios(i) Is Button Then
                If TypeOf MyObligatorios(i - 1) Is TextBox Then
                    If Len(Trim(CType(MyObligatorios(i - 1), TextBox).Text)) = 0 Then
                        MyError.SetError(CType(MyObligatorios(i), Button), "Campo Obligatorio para Guardar el Registro")
                        MyError.SetError(CType(MyObligatorios(i - 1), TextBox), "")
                        Resp = 1
                    Else
                        MyError.SetError(CType(MyObligatorios(i), Button), "")
                    End If
                End If
            ElseIf TypeOf MyObligatorios(i) Is TextBox Then
                If Len(Trim(CType(MyObligatorios(i), TextBox).Text)) = 0 Then
                    MyError.SetError(CType(MyObligatorios(i), TextBox), "Campo Obligatorio para Guardar el Registro")
                    Resp = 1
                Else
                    MyError.SetError(CType(MyObligatorios(i), TextBox), "")
                End If
            End If

            'Si la validacion sera en un ComboBox
            If TypeOf MyObligatorios(i) Is ComboBox Then
                If Len(Trim(CType(MyObligatorios(i), ComboBox).Text)) = 0 Then
                    MyError.SetError(CType(MyObligatorios(i + 1), Button), "Campo Obligatorio para Guardar el Registro")
                    Resp = 1
                Else
                    MyError.SetError(CType(MyObligatorios(i + 1), Button), "")
                End If
            End If

            'Si la validacion es en un DataPickerMasked
            'If TypeOf MyObligatorios(i) Is ControlsTepsa.DataPickerMasked Then
            '    If Len(Trim(CType(MyObligatorios(i), ControlsTepsa.DataPickerMasked).GetMyFecha)) = 0 Then
            '        MyError.SetError(CType(MyObligatorios(i), ControlsTepsa.DataPickerMasked), "Campo Obligatorio para Guardar el Registro")
            '        Resp = 1
            '    Else
            '        MyError.SetError(CType(MyObligatorios(i), ControlsTepsa.DataPickerMasked), "")
            '    End If
            'End If

            'Si la validacion sera en un Label como contenedor de dos RadioButton
            If i >= 3 Then
                If TypeOf MyObligatorios(i - 2) Is Label And TypeOf MyObligatorios(i - 1) Is RadioButton And TypeOf MyObligatorios(i) Is RadioButton Then
                    If CType(MyObligatorios(i - 1), RadioButton).Checked = False And CType(MyObligatorios(i), RadioButton).Checked = False Then
                        MyError.SetError(CType(MyObligatorios(i - 2), Label), "Campo Obligatorio para Guardar el Registro")
                        Resp = 1
                    Else
                        MyError.SetError(CType(MyObligatorios(i - 2), Label), "")
                    End If
                End If
            End If

            'Si la validacion sera en un DataGridView con filas, sino no.
            If TypeOf MyObligatorios(i) Is DataGridView Then
                If CType(MyObligatorios(i), DataGridView).RowCount <= 1 Then
                    MyError.SetError(CType(MyObligatorios(i), DataGridView), "Campo Obligatorio para Guardar el Registro")
                    Resp = 1
                Else
                    MyError.SetError(CType(MyObligatorios(i), DataGridView), "")
                End If
            End If

        Next
        Return Resp

    End Function

End Module
