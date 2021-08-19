Module ModContado
    Public Function ValidaNumero(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[0-9\b]") '("^\d+$")  

        If re.IsMatch(txtStr.ToString()) Then
            ValidaNumero = True
        Else
            ValidaNumero = False
        End If
    End Function

    Public Function ValidarClave(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        're = New System.Text.RegularExpressions.Regex("[0-9A-ZñÑ.a-z\b\s]")
        re = New System.Text.RegularExpressions.Regex("[0-9\-+*/\b\s]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidarClave = True
        Else
            ValidarClave = False
        End If
    End Function

    Public Function ValidaNumero2(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[-0-9\b]") '("^\d+$")  
        If re.IsMatch(txtStr.ToString()) Then
            ValidaNumero2 = True
        Else
            ValidaNumero2 = False
        End If
    End Function

    Public Function ValidarNumero(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidarNumero = True
        Else
            ValidarNumero = False
        End If
    End Function

    Public Function ValidarNumeroReal(ByRef txtStr As String, Optional txt As String = "") As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[0-9.\-\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            If txtStr.Trim = "." And (txt.Contains(".") Or txt.Trim.Length = 0) Then
                ValidarNumeroReal = False
            ElseIf txtStr.Trim = "-" And txt.Contains("-") Then
                ValidarNumeroReal = False
            Else
                ValidarNumeroReal = True
            End If
        Else
            ValidarNumeroReal = False
        End If
    End Function

    Public Function ValidarLetra(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[A-ZñÑa-z\b\s]")
        If re.IsMatch(txtStr.ToString()) Then
            ValidarLetra = True
        Else
            ValidarLetra = False
        End If
    End Function

    Public Function ValidarLetra(ByRef txtStr As String, ByVal espacio As Boolean) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        If espacio Then
            re = New System.Text.RegularExpressions.Regex("[A-ZñÑa-z\b\s]")
        Else
            re = New System.Text.RegularExpressions.Regex("[A-ZñÑa-z\b]")
        End If
        If re.IsMatch(txtStr.ToString()) Then
            ValidarLetra = True
        Else
            ValidarLetra = False
        End If
    End Function

    Public Function ValidarLetraNumero(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[0-9A-ZñÑ.a-z\b\s]")
        If re.IsMatch(txtStr.ToString()) Then
            ValidarLetraNumero = True
        Else
            ValidarLetraNumero = False
        End If
    End Function

    Function ExisteEsElCliente(ByVal numero As String, ByVal cbo As ComboBox, ByVal dt As DataTable, ByVal campo As String, ByVal campo2 As String) As Integer
        Dim sNumero As String
        For i As Integer = 1 To dt.Rows.Count - 1
            sNumero = IIf(IsDBNull(dt.Rows(i).Item(campo)), "", dt.Rows(i).Item(campo))
            If numero.Trim = sNumero.Trim Then
                Return dt.Rows(i).Item(campo2)
            End If
        Next
        Return 0
    End Function

    Public Function ObtieneMontoTarifaServicio(unidad As Integer, peso As Double, dt As DataTable) As Double
        Dim intUnidad As Integer, dblInicio As Double, dblFin As Double, dblMonto As Double
        Dim dblPeso As Double

        dblPeso = Format(peso, "0.00")
        dblPeso = Math.Ceiling(dblPeso)
        For Each row As DataRow In dt.Rows
            intUnidad = CType(row.Item("idunidad"), Integer)
            dblInicio = CType(row.Item("inicio"), Double)
            dblFin = CType(row.Item("fin"), Double)
            dblMonto = CType(row.Item("monto"), Double)

            If intUnidad = unidad Then
                If dblFin = 0 Then
                    dblFin = 99999999999
                End If
                If intUnidad <> 3 Then
                    If dblPeso >= dblInicio And dblPeso <= dblFin Then
                        Return dblMonto
                    End If
                Else
                    Return dblMonto
                End If
            End If
        Next
        Return 0
    End Function

    Function Redondear(numero As Double) As Double
        If numero > 0 And numero < 1 Then
            Return 1
        ElseIf numero = 1 Then
            Return 1
        End If
    End Function

    Function BuscarItemVenta(clave As String, GrdDetalleVenta As DataGridView) As Integer
        With GrdDetalleVenta
            For i As Integer = 0 To .Rows.Count - 1
                If .Rows(i).Cells(0).Value.ToString.Contains(clave) Then
                    Return i
                End If
            Next
            Return 0
        End With
    End Function

    Sub EliminarItemVenta(clave As String, GrdDetalleVenta As DataGridView)
        With GrdDetalleVenta
            Dim intFila As Integer
            intFila = BuscarItemVenta(clave, GrdDetalleVenta)
            If intFila > 0 Then
                'dtTarifaServicio = Nothing
                'dblMontoEntregaDomicilio = 0
                'fnTotalPago()
                .Rows.RemoveAt(intFila)
            Else
                'dtTarifaServicio = Nothing
                'dblMontoEntregaDomicilio = 0
            End If
        End With
    End Sub

    Sub AgregarItemVenta(clave As String, GrdDetalleVenta As DataGridView)
        With GrdDetalleVenta
            Dim intFila As Integer
            intFila = BuscarItemVenta(clave, GrdDetalleVenta)
            If intFila = 0 And GrdDetalleVenta.Rows.Count > 0 Then
                'Dim row0 As String() = {"ENTREGA DOM.", "", "0.00", "0.00", "0.00", "0.00", "0.00"}
                Dim row0 As String() = {clave, "", "0.00", "0.00", "0.00", "0.00", "0.00"}
                .Rows.Add(row0)
                'fnTotalPago()
            End If
        End With
    End Sub

    Function GestionaMontoTarifaDomicilio(dtTarifaServicio As DataTable, GrdDetalleVenta As DataGridView, Optional tipo As String = "") As Double
        Dim dblMonto As Double
        If IsNothing(dtTarifaServicio) Then
            dblMonto = 0
        Else
            If tipo = "" Then
                Dim dblPeso As Double, dblVolumen As Double, intSobre As Integer
                Dim dblTotal As Double, dblTotalGenerico As Double, dblTotalPersonalizado As Double, dblTotalPeso As Double, dblTotalVolumen As Double, dblTotalSobre As Double

                dblPeso = GrdDetalleVenta("Peso/Volumen", 0).Value
                dblVolumen = GrdDetalleVenta("Peso/Volumen", 1).Value
                intSobre = IIf(IsNumeric(GrdDetalleVenta("Bulto", 2).Value), GrdDetalleVenta("Bulto", 2).Value, 0)

                'Busca tarifa por unidad
                Dim intFila As Integer = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
                dblTotalPeso = ObtieneMontoTarifaServicio(1, dblPeso, dtTarifaServicio)
                dblTotalVolumen = ObtieneMontoTarifaServicio(2, dblVolumen, dtTarifaServicio)
                dblTotalSobre = ObtieneMontoTarifaServicio(3, intSobre, dtTarifaServicio)
                dblTotalPersonalizado = dblTotalPeso + dblTotalVolumen + dblTotalSobre
                dblMonto += dblTotalPersonalizado

                If dblTotalPeso = 0 Then dblTotalGenerico += dblPeso
                If dblTotalVolumen = 0 Then dblTotalGenerico += dblVolumen

                'Eliminar sobre si va a compañado
                If dblTotalGenerico = 0 And intSobre > 0 Then
                    If dblTotalSobre = 0 Then dblTotalGenerico += IIf(intSobre > 0, 1, 0)
                End If

                'Busca tarifa por generico
                dblMonto += ObtieneMontoTarifaServicio(100, dblTotalGenerico, dtTarifaServicio)

                GrdDetalleVenta("Sub Neto", intFila).Value = Format(dblMonto, "0.00")
            Else    'volumetrico
                Dim dblPeso As Double, dblTotalPeso As Double, dblTotalGenerico As Double, dblTotalPersonalizado As Double
                dblPeso = GrdDetalleVenta("Peso Kg", 0).Value
                dblTotalPeso = ObtieneMontoTarifaServicio(1, dblPeso, dtTarifaServicio)
                dblTotalPersonalizado = dblTotalPeso
                dblMonto += dblTotalPersonalizado

                If dblTotalPeso = 0 Then dblTotalGenerico += dblPeso

                'Busca tarifa por generico
                dblMonto += ObtieneMontoTarifaServicio(100, dblTotalGenerico, dtTarifaServicio)
                Dim intFila As Integer = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
                GrdDetalleVenta("Sub Neto", intFila).Value = Format(dblMonto, "0.00")
            End If
        End If
        Return dblMonto
    End Function

End Module
