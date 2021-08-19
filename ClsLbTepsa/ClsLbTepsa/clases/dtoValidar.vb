Imports System.Windows.Forms
Public Class dtoValida
    Function NO_BLANCO(ByVal MyControl As Control, ByVal MyForm As Form) As Boolean
        NO_BLANCO = False
        If TypeOf MyControl Is TextBox Then
            Dim MyTexBox As TextBox
            MyTexBox = MyControl
            If Len(MyTexBox.Text) = 0 Then
                MessageBox.Show("Ingrese el dato...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                MyTexBox.Focus()
                Exit Function
            End If
        End If
        If TypeOf MyControl Is RichTextBox Then
            Dim MyRichTextBox As RichTextBox
            MyRichTextBox = MyControl
            If Len(MyRichTextBox.Text) = 0 Then
                MessageBox.Show("Ingrese el dato...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                MyRichTextBox.Focus()
                Exit Function
            End If
        End If
        NO_BLANCO = True
    End Function

    Function BUSCA_ITEM_LISTBOX(ByVal MyControl As ListBox, ByVal Valor As String, ByVal Inicio As Integer, ByVal Caracteres As Integer, ByVal MyForm As Form) As Boolean
        If TypeOf MyControl Is ListBox Then
            Dim MyListBox As ListBox, i As Integer
            MyListBox = MyControl
            For i = 0 To MyListBox.Items.Count - 1
                If Mid(MyListBox.Items(i), Inicio, Caracteres) = Valor Then
                    MessageBox.Show("El elemento ya esta en la lista...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    BUSCA_ITEM_LISTBOX = False
                    Exit Function
                End If
            Next
            BUSCA_ITEM_LISTBOX = True
        End If
    End Function
    
    Function NO_SELECCIONADO_ITEM(ByVal MyControl As ComboBox, ByVal MyForm As Form) As Boolean
        If TypeOf MyControl Is ComboBox Then
            Dim MyComboBox As ComboBox
            MyComboBox = MyControl
            If IsNothing(MyComboBox.SelectedItem) Then
                MessageBox.Show("Seleccione un elemento...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                MyComboBox.Focus()
                NO_SELECCIONADO_ITEM = False
                Exit Function
            End If
            NO_SELECCIONADO_ITEM = True
        End If
    End Function
    Function NO_SELECCIONADO_INDEX(ByVal MyControl As ComboBox, ByVal MyForm As Form) As Boolean
        If TypeOf MyControl Is ComboBox Then
            Dim MyComboBox As ComboBox
            MyComboBox = MyControl
            If MyComboBox.SelectedIndex = -1 Then
                MessageBox.Show("Seleccione un elemento...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                MyComboBox.Focus()
                NO_SELECCIONADO_INDEX = False
                Exit Function
            End If
            NO_SELECCIONADO_INDEX = True
        End If
    End Function
    
    Function NUMERO_CERO(ByVal MyControl As Control)
        If TypeOf MyControl Is TextBox Then
            Dim MyTexBox As TextBox
            MyTexBox = MyControl
            If Not IsNumeric(MyTexBox.Text) Then
                MyTexBox.Text = "0.00"
            Else
                MyTexBox.Text = Format(CDbl(MyTexBox.Text), "0.00")
            End If
        End If
    End Function
    Function NO_ESPACIO(ByVal MyControl As Form)
        For Each MyObject As Object In MyControl.Controls
            If TypeOf MyObject Is TabControl Then
                Dim MyTabControl As TabControl
                MyTabControl = MyObject
                Dim i As Integer
                For i = 0 To MyTabControl.TabPages.Count - 1
                    For Each MyObject2 As Object In MyTabControl.TabPages(i).Controls
                        If TypeOf MyObject2 Is TextBox Then
                            Dim MyTextbox As New TextBox
                            MyTextbox = MyObject2
                            MyTextbox.Text = LTrim(Trim(MyTextbox.Text))
                        End If
                        If TypeOf MyObject2 Is TabControl Then
                            Dim MyTabControl1 As TabControl
                            MyTabControl1 = MyObject2
                            Dim j As Integer
                            For j = 0 To MyTabControl1.TabPages.Count - 1
                                For Each MyObject3 As Object In MyTabControl1.TabPages(i).Controls
                                    If TypeOf MyObject3 Is TextBox Then
                                        Dim MyTextbox As New TextBox
                                        MyTextbox = MyObject3
                                        MyTextbox.Text = LTrim(Trim(MyTextbox.Text))
                                    End If

                                Next
                            Next
                        End If

                    Next
                Next
            End If
            If TypeOf MyObject Is TextBox Then
                Dim MyTextbox As New TextBox
                MyTextbox = MyObject
                MyTextbox.Text = LTrim(Trim(MyTextbox.Text))
            End If
        Next
    End Function
    Function NO_REGISTROS(ByVal MyControl As DataTable, ByVal MyForm As Form) As Boolean
        NO_REGISTROS = False
        Dim MyDataTable As DataTable
        MyDataTable = MyControl
        If IsNothing(MyDataTable) Then
            MessageBox.Show("No existen elementos...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Function
        End If
        If MyDataTable.Rows.Count < 1 Then
            MessageBox.Show("No existen elementos...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Function
        End If
        NO_REGISTROS = True
    End Function
    Function NO_REGISTROS_GRILLA(ByVal MyDataGrid As DataGrid, ByVal MyForm As Form) As Boolean
        NO_REGISTROS_GRILLA = False
        If MyDataGrid.CurrentRowIndex = -1 Then
            MessageBox.Show("No existen elementos...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Function
        End If
        NO_REGISTROS_GRILLA = True
    End Function
    Function NO_REGISTROS_GRILLA_SELECT(ByVal MyDataGrid As DataGrid, ByVal MyForm As Form) As Boolean
        NO_REGISTROS_GRILLA_SELECT = False
        If MyDataGrid.CurrentRowIndex = -1 Then
            MessageBox.Show("No existen elementos...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Function
        End If
        If MyDataGrid.IsSelected(MyDataGrid.CurrentRowIndex) = False Then
            MessageBox.Show("No existe elemento Seleccionado...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Function
        End If

        NO_REGISTROS_GRILLA_SELECT = True
    End Function
    Function NO_REGISTROS_CON_VALOR_DADO(ByVal MyControl As DataTable, ByVal MyCampo As String, ByVal MyValor As String, ByVal MyForm As Form) As Boolean
        Dim MyDataTable As DataTable
        MyDataTable = MyControl
        Dim MyRow As DataRow
        For Each MyRow In MyDataTable.Rows
            If MyRow(MyCampo) = MyValor Then
                NO_REGISTROS_CON_VALOR_DADO = False
                MessageBox.Show("El valor del elemento no puede ser cero...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Function
            Else
                NO_REGISTROS_CON_VALOR_DADO = True
            End If
        Next
    End Function
    Function SUMA_DE_REGISTROS(ByVal MyControl As DataTable, ByVal MyCampo As String, ByVal MyValor As Double, ByVal MyForm As Form) As Boolean
        SUMA_DE_REGISTROS = False
        Dim MyDataTable As DataTable
        MyDataTable = MyControl
        Dim MyRow As DataRow, Suma As Double = 0
        For Each MyRow In MyDataTable.Rows
            Suma = Suma + CDbl(MyRow(MyCampo))
        Next
        If Suma > MyValor Then
            MessageBox.Show("La suma de los valores no puede ser mavor que " + Format(MyValor, "0.00") + "...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Function
        End If
        SUMA_DE_REGISTROS = True
    End Function
    Function NO_REGISTROS_REPETIDOS(ByVal MyControl As DataTable, ByVal MyCampo As String, ByVal MyValor As String, ByVal MyForm As Form) As Boolean
        NO_REGISTROS_REPETIDOS = True
        Dim MyDataTable As DataTable
        MyDataTable = MyControl
        Dim MyRow As DataRow
        For Each MyRow In MyDataTable.Rows
            If MyRow(MyCampo) = MyValor Then
                NO_REGISTROS_REPETIDOS = False
                MessageBox.Show("El elmento ya esta en la lista...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Function
            End If
        Next
    End Function
    Function NUMERO_NO_CERO(ByVal MyControl As Control, ByVal MyForm As Form) As Boolean
        If TypeOf MyControl Is TextBox Then
            Dim MyTexBox As TextBox
            MyTexBox = MyControl
            If Not IsNumeric(MyTexBox.Text) Then
                MessageBox.Show("No es un número valido...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                NUMERO_NO_CERO = False
                MyTexBox.Focus()
            ElseIf CDbl(MyTexBox.Text) = 0 Then
                MessageBox.Show("El valor no puede ser cero...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                NUMERO_NO_CERO = False
                MyTexBox.Focus()
            Else
                MyTexBox.Text = Format(CDbl(MyTexBox.Text), "0.00")
                NUMERO_NO_CERO = True
            End If
        End If
    End Function
    Function NO_FECHA_INI_MAYOR(ByVal MyFecha_Ini As DateTimePicker, ByVal MyFecha_Final As DateTimePicker, ByVal MyForm As Form) As Boolean
        If MyFecha_Ini.Value.ToShortDateString > MyFecha_Final.Value.ToShortDateString Then
            NO_FECHA_INI_MAYOR = False
            MessageBox.Show("La Fecha no puede ser mayor que las demás...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            MyFecha_Ini.Focus()
            Exit Function
        Else
            NO_FECHA_INI_MAYOR = True
        End If

    End Function
    Function NO_FECHA_INI_MAYOR_CHK(ByVal MyFecha_Ini As DateTimePicker, ByVal MyFecha_Final As DateTimePicker, ByVal MyForm As Form) As Boolean
        NO_FECHA_INI_MAYOR_CHK = False
        If MyFecha_Ini.Checked = True Then
            If MyFecha_Final.Checked = False Then
                MessageBox.Show("Seleccione la fecha final...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                MyFecha_Final.Focus()
                Exit Function
            End If
        End If
        If MyFecha_Final.Checked = True Then
            If MyFecha_Ini.Checked = False Then
                MessageBox.Show("Seleccione la fecha inicial...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                MyFecha_Ini.Focus()
                Exit Function
            End If
        End If
        If MyFecha_Ini.Value.ToShortDateString > MyFecha_Final.Value.ToShortDateString Then
            NO_FECHA_INI_MAYOR_CHK = False
            MessageBox.Show("La Fecha no puede ser mayor que las demás...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            MyFecha_Ini.Focus()
            Exit Function
        End If
        NO_FECHA_INI_MAYOR_CHK = True
    End Function

    Function NUMERO_ENTERO(ByVal MyControl As Control, ByVal MyForm As Form) As Boolean
        If TypeOf MyControl Is TextBox Then
            Dim MyTexBox As TextBox
            MyTexBox = MyControl
            If Not IsNumeric(MyTexBox.Text) Then
                NUMERO_ENTERO = False
                MessageBox.Show("El Número no es valido...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                MyTexBox.Focus()
                Exit Function
            Else
                MyTexBox.Text = Format(CInt(MyTexBox.Text), "0")
                NUMERO_ENTERO = True
            End If
        End If
    End Function
    Function FECHA_NACI(ByVal MyControl As DateTimePicker, ByVal MyForm As Form) As Boolean
        FECHA_NACI = False
        Dim MyDateTimePicker As DateTimePicker
        MyDateTimePicker = MyControl
        If MyDateTimePicker.Value.ToShortDateString >= Now Then
            MessageBox.Show("La Fecha no puede ser mayor o igual a la actual...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            MyDateTimePicker.Focus()
            Exit Function
        End If
        If DateDiff(DateInterval.Year, MyDateTimePicker.Value, Now) < 18 Then
            MessageBox.Show("Tiene que tener edad mayor o igual que 18 años...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            MyDateTimePicker.Focus()
            Exit Function
        End If
        FECHA_NACI = True
    End Function
    Function RANGO_ANIO(ByVal MyComboBox1 As ComboBox, ByVal MyComboBox2 As ComboBox, ByVal MyForm As Form) As Boolean
        RANGO_ANIO = False
        If ((MyComboBox1.SelectedIndex = -1) And (MyComboBox2.SelectedIndex = -1)) Then
            RANGO_ANIO = True
            Exit Function
        End If
        If MyComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione un elemento...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            MyComboBox1.Focus()
            Exit Function
        End If
        If MyComboBox2.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione un elemento...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            MyComboBox2.Focus()
            Exit Function
        End If
        If MyComboBox1.Text > MyComboBox2.Text Then
            MessageBox.Show("El dato inicial no puede ser mayor a la final...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            MyComboBox1.Focus()
            Exit Function
        End If
        RANGO_ANIO = True
    End Function
    Function NUMERO_NO_NEGATIVO(ByVal MyControl As Control, ByVal MyForm As Form) As Boolean
        If TypeOf MyControl Is TextBox Then
            Dim MyTexBox As TextBox
            MyTexBox = MyControl
            If Not IsNumeric(MyTexBox.Text) Then
                MessageBox.Show("El número no es valido...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                NUMERO_NO_NEGATIVO = False
                MyTexBox.Focus()
                Exit Function
            Else
                MyTexBox.Text = Format(CDbl(MyTexBox.Text), "0.00")
                NUMERO_NO_NEGATIVO = True
            End If
            If MyTexBox.Text < 0 Then
                MessageBox.Show("El número no puede ser negativo...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                NUMERO_NO_NEGATIVO = False
                MyTexBox.Focus()
                Exit Function
            Else
                MyTexBox.Text = Format(CDbl(MyTexBox.Text), "0.00")
                NUMERO_NO_NEGATIVO = True
            End If
        End If
    End Function
    'NUEVAS VALIDACIONES
    '-------------------
    Function TXT_NUMERO_ENTERO(ByRef MyControl As Control, ByVal MyForm As Form) As Boolean
        If TypeOf MyControl Is TextBox Then
            Dim MyTexBox As TextBox
            MyTexBox = MyControl
            If Not IsNumeric(MyTexBox.Text) Then
                TXT_NUMERO_ENTERO = False
                MessageBox.Show("El Número no es valido...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                MyTexBox.Focus()
                Exit Function
            Else
                MyTexBox.Text = CType(MyTexBox.Text, Long)
                TXT_NUMERO_ENTERO = True
            End If
        End If
    End Function
    Function CB_SELECT_VALUE(ByRef MyControl As ComboBox, ByVal MyForm As Form) As Boolean
        If TypeOf MyControl Is ComboBox Then
            Dim MyComboBox As ComboBox
            MyComboBox = MyControl
            If MyComboBox.SelectedValue = Nothing Then
                MessageBox.Show("Seleccione un elemento...", MyForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                MyComboBox.Focus()
                CB_SELECT_VALUE = False
                Exit Function
            End If
            CB_SELECT_VALUE = True
        End If
    End Function

    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function

    Function NingunDato(ByVal Keyascii As Short) As Short
        If InStr("", Chr(Keyascii)) = 0 Then
            NingunDato = 0
        Else
            NingunDato = Keyascii
        End If
        Select Case Keyascii
            Case 8
                NingunDato = Keyascii
            Case 13
                NingunDato = Keyascii
        End Select
    End Function
    Function valida_digto_checkeo(ByVal ValorValidar As String) As Boolean
        Dim VALOR_MULTIPLICADOR As Integer, MONTO As Long, digito_chk As Integer
        VALOR_MULTIPLICADOR = 3
        MONTO = 0
        digito_chk = 0
        ValorValidar = CType(ValorValidar, Long)
        For I As Integer = Len(ValorValidar) - 1 To 1 Step -1
            If VALOR_MULTIPLICADOR = 1 Then
                MONTO = MONTO + Mid(ValorValidar, I, 1) * 1
                VALOR_MULTIPLICADOR = 3
            Else
                MONTO = MONTO + Mid(ValorValidar, I, 1) * 3
                VALOR_MULTIPLICADOR = 1
            End If
        Next

        digito_chk = (Int(MONTO / 10) + 1) * 10 - MONTO

        digito_chk = IIf(digito_chk = 10, 0, digito_chk)

        If Mid(ValorValidar, Len(ValorValidar), 1) <> CStr(digito_chk) Then
            Return False
        Else
            Return True
        End If

    End Function
    Function recupera_digto_checkeo(ByVal ValorValidar As String) As Integer
        Dim VALOR_MULTIPLICADOR As Integer, MONTO As Long, digito_chk As Integer
        VALOR_MULTIPLICADOR = 3
        MONTO = 0
        digito_chk = 0
        ValorValidar = CType(ValorValidar, Long)
        For I As Integer = Len(ValorValidar) - 1 To 1 Step -1
            If VALOR_MULTIPLICADOR = 1 Then
                MONTO = MONTO + Mid(ValorValidar, I, 1) * 1
                VALOR_MULTIPLICADOR = 3
            Else
                MONTO = MONTO + Mid(ValorValidar, I, 1) * 3
                VALOR_MULTIPLICADOR = 1
            End If
        Next

        digito_chk = (Int(MONTO / 10) + 1) * 10 - MONTO

        digito_chk = IIf(digito_chk = 10, 0, digito_chk)

        'If Mid(ValorValidar, Len(ValorValidar), 1) <> CStr(digito_chk) Then
        '    Return False
        'Else
        '    Return True
        'End If

        Return digito_chk

    End Function



End Class