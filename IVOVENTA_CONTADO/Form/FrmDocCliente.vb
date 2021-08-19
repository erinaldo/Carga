Imports ClsLbTepsa
Public Class FrmDocCliente
    Dim dvIDTIPO_MONEDA As DataView
    Dim dvIDTIPO_COMPROBANTE As DataView
    Dim indice As Integer = -1
    Dim t_indices As Integer = 0
    Dim ObjCargaAsegurada As New ClsLbTepsa.dtoCargaAsegurada
    Dim objGeneral As New ClsLbTepsa.dtoGENERAL
    Dim objValida As New ClsLbTepsa.dtoValida
    Dim bNuevo As Boolean
    Public Es_Carga_Asegurada As Boolean
    Dim bNada As Boolean = False
    Public iTotal As Double
    Public sDocCliente As String
    Public bVentaGrabada As Boolean
    Public iProcedencia As Integer
    Public sFecha As String
    Public iFormulario As Integer = 0
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCE.Click
        Close()
    End Sub
    Private Function guardar(ByVal indice As Integer) As Boolean
        guardar = False
        If validar() = False Then Exit Function
        If IsNothing(objComprobanteAsegurada(indice).ID_GUIAS_ENVIO_DOC) Then
            objComprobanteAsegurada(indice).ID_GUIAS_ENVIO_DOC = 0
        End If
        objComprobanteAsegurada(indice).FECHA = DTPFECHA.Value.ToShortDateString
        objComprobanteAsegurada(indice).IDTIPO_MONEDA = CLng(Me.CBIDTIPO_MONEDA.SelectedValue)
        objComprobanteAsegurada(indice).IDTIPO_COMPROBANTE = CLng(Me.CBIDTIPO_COMPROBANTE.SelectedValue)

        If objComprobanteAsegurada(indice).IDTIPO_MONEDA = 1 Then
            objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO = 1
        Else
            objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO = CDbl(Me.TXTMONTO_TIPO_CAMBIO.Text)
        End If

        objComprobanteAsegurada(indice).NRO_SERIE = Mid(MTBNRO_FACTURA.Text, 1, 3)
        objComprobanteAsegurada(indice).NRO_SERIE = Replace(objComprobanteAsegurada(indice).NRO_SERIE, " ", "")
        While Len(objComprobanteAsegurada(indice).NRO_SERIE) < 3
            objComprobanteAsegurada(indice).NRO_SERIE = "0" & objComprobanteAsegurada(indice).NRO_SERIE
        End While

        objComprobanteAsegurada(indice).NRO_DOCU = Mid(MTBNRO_FACTURA.Text, InStr(MTBNRO_FACTURA.Text, "-") + 1, 8)
        objComprobanteAsegurada(indice).NRO_DOCU = Replace(objComprobanteAsegurada(indice).NRO_DOCU, " ", "")
        While Len(objComprobanteAsegurada(indice).NRO_DOCU) < 8
            objComprobanteAsegurada(indice).NRO_DOCU = "0" & objComprobanteAsegurada(indice).NRO_DOCU
        End While
        objComprobanteAsegurada(indice).MONTO_SUB_TOTAL = CDbl(Me.TXTMONTO_SUB_TOTAL.Text)
        objComprobanteAsegurada(indice).MONTO_IMPUESTO = CDbl(Me.TXTMONTO_IMPUESTO.Text)
        objComprobanteAsegurada(indice).TOTAL_COSTO = CDbl(Me.TXTTOTAL_COSTO.Text)
        If ObjCargaAsegurada.TIPO = 0 Then
            ObjCargaAsegurada.TIPO = objComprobanteAsegurada(indice).TIPO
        End If

        If ObjCargaAsegurada.TIPO = 1 Then
            objComprobanteAsegurada(indice).PORCEN = CDbl(Me.TXTPORCEN.Text)
        End If
        objComprobanteAsegurada(indice).TIPO = ObjCargaAsegurada.TIPO
        objComprobanteAsegurada(indice).OBS = Me.TXTOBS.Text
        objComprobanteAsegurada(indice).PROCEDENCIA = iProcedencia
        guardar = True
    End Function
    Private Sub BTNACEP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnACEP.Click

        If guardar(indice) = True Then
            ActualizarGrid()
        End If
        Close()

    End Sub

    Private Sub FrmDocCliente_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmDocCliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmDocCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Controlar(True, False)
            Habilitar(False)

            fnConfigurarGrid()
            'Mod.21/09/2009 -->Omendoza - Pasando al datahelper   
            objGeneral.FNLISTAR_TIPO_MONEDA(dvIDTIPO_MONEDA, Me.CBIDTIPO_MONEDA)
            'Mod.21/09/2009 -->Omendoza - Pasando al datahelper   
            'objGeneral.fnlistar_tipo_comprobanteBF(dvIDTIPO_COMPROBANTE, Me.CBIDTIPO_COMPROBANTE, VOCONTROLUSUARIO)
            objGeneral.fnlistar_tipo_comprobanteBF(dvIDTIPO_COMPROBANTE, Me.CBIDTIPO_COMPROBANTE)
            '
            'ObjCargaAsegurada.SP_RECUPERA_MONTO_PORCE(10 + iTotal, cnn)
            'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
            'ObjCargaAsegurada.SP_RECUPERA_PORCEN_IMPU(cnn)
            ObjCargaAsegurada.SP_RECUPERA_PORCEN_IMPU()
            '
            calculando_totales()
            'hlamas
            For Each obj As ClsLbTepsa.dtoCargaAsegurada.ComprobanteAsegurada In objComprobanteAsegurada
                If Not obj.NRO_DOCU Is Nothing Then
                    t_indices += 1
                End If
            Next
            If t_indices > 0 Then
                indice = t_indices - 1
                Controlar(True, True)
            End If

            MostrarGrid()
            ActualizaTotales()

            If bVentaGrabada Then
                btnNuevo.Enabled = False
            End If


            If iFormulario = 1 Then
                btnNuevo.Enabled = False
                btnModificar.Enabled = False
                btnGrabar.Enabled = False
                btnCancelar.Enabled = False
                btnEliminar.Enabled = False
                grdAsegurado.Enabled = False
            End If
            btnNuevo.Focus()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub BTNNUE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNNUE.Click
        If t_indices > 0 Then
            If guardar(indice) = False Then Exit Sub
            t_indices = t_indices + 1
            indice = t_indices - 1
        Else
            t_indices = t_indices + 1
            indice = t_indices - 1
        End If
        limpiar()
        HABILITAR(True)
        LBLCOTADOR.Text = CStr(indice + 1) & "/" & CStr(t_indices)
        Me.BTNANTE.Enabled = True
        Me.BTNPRIME.Enabled = True
        Me.BTNULTI.Enabled = True
        Me.BTNSIGUI.Enabled = True
    End Sub
    Private Sub Limpiar()
        CBIDTIPO_MONEDA.SelectedIndex = 0
        CBIDTIPO_COMPROBANTE.SelectedIndex = 0
        MTBNRO_FACTURA.Clear()
        MTBNRO_FACTURA.Text = "___-_______"
        TXTMONTO_SUB_TOTAL.Text = ""
        TXTMONTO_IMPUESTO.Text = ""
        TXTTOTAL_COSTO.Text = ""
        TXTPORCEN.Text = String.Empty 'FormatNumber(ObjCargaAsegurada.PORCEN, 2)
        TXTVALOR_CALCU.Text = ""
        TXTOBS.Text = ""
        DTPFECHA.Value = Now
        TXTMONTO_TIPO_CAMBIO.Text = "1"
        TXTMONTO_TIPO_CAMBIO.Enabled = False
    End Sub
    Private Sub Habilitar(ByVal VALOR As Boolean)
        CBIDTIPO_MONEDA.Enabled = VALOR
        CBIDTIPO_COMPROBANTE.Enabled = VALOR
        MTBNRO_FACTURA.Enabled = VALOR
        TXTTOTAL_COSTO.Enabled = VALOR
        If CLng(CBIDTIPO_MONEDA.SelectedValue) = 2 Then
            TXTMONTO_TIPO_CAMBIO.Enabled = VALOR
        End If
        TXTPORCEN.Enabled = VALOR
        TXTVALOR_CALCU.Enabled = VALOR
        TXTOBS.Enabled = VALOR
        DTPFECHA.Enabled = VALOR
        Me.btnACEP.Enabled = VALOR
    End Sub

    Private Sub BTNULTI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNULTI.Click
        If guardar(indice) = False Then Exit Sub
        indice = t_indices - 1
        mostrar(indice)
        LBLCOTADOR.Text = CStr(indice + 1) & "/" & CStr(t_indices)
    End Sub

    Private Sub BTNSIGUI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSIGUI.Click
        If guardar(indice) = False Then Exit Sub
        If indice + 1 >= t_indices Then
            indice = 0
        Else
            indice = indice + 1
        End If
        mostrar(indice)
        LBLCOTADOR.Text = CStr(indice + 1) & "/" & CStr(t_indices)
    End Sub

    Private Sub BTNANTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNANTE.Click
        If guardar(indice) = False Then Exit Sub
        If indice - 1 < 0 Then
            indice = t_indices - 1
        Else
            indice = indice - 1
        End If
        mostrar(indice)
        LBLCOTADOR.Text = CStr(indice + 1) & "/" & CStr(t_indices)
    End Sub

    Private Sub BTNPRIME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPRIME.Click
        If guardar(indice) = False Then Exit Sub
        indice = 0
        mostrar(indice)
        LBLCOTADOR.Text = CStr(indice + 1) & "/" & CStr(t_indices)
    End Sub
    Private Function validar() As Boolean

        validar = False
        If CBIDTIPO_MONEDA.SelectedIndex <> 0 Then
            If Not objValida.NUMERO_NO_CERO(TXTMONTO_TIPO_CAMBIO, Me) Then Exit Function
            If Not objValida.NUMERO_NO_NEGATIVO(TXTMONTO_TIPO_CAMBIO, Me) Then Exit Function
        End If
        If Not objValida.NO_SELECCIONADO_ITEM(Me.CBIDTIPO_MONEDA, Me) Then Exit Function
        If CDate(DTPFECHA.Text) > CDate(sFecha) Then
            MsgBox("La fecha ingresada no puede ser mayor a la fecha del documento de venta.", MsgBoxStyle.Exclamation, Me.Text)
            Me.DTPFECHA.Focus()
            Exit Function
        End If

        If Not objValida.NO_SELECCIONADO_ITEM(Me.CBIDTIPO_COMPROBANTE, Me) Then Exit Function
        If Me.MTBNRO_FACTURA.Text.Trim = "-" Then
            MsgBox("Ingrese un número de documento valido", MsgBoxStyle.Exclamation, Me.Text)
            Me.MTBNRO_FACTURA.Focus()
            Exit Function
        End If
        If Not objValida.NUMERO_NO_CERO(Me.TXTTOTAL_COSTO, Me) Then Exit Function
        If Not objValida.NUMERO_NO_NEGATIVO(Me.TXTTOTAL_COSTO, Me) Then Exit Function

        If ObjCargaAsegurada.TIPO = 1 Then
            If Not objValida.NUMERO_NO_CERO(Me.TXTPORCEN, Me) Then Exit Function
            If Not objValida.NUMERO_NO_NEGATIVO(Me.TXTPORCEN, Me) Then Exit Function
        End If

        Dim NRO_SERIE As String = ""
        Dim NRO_DOCU As String = ""


        If bNuevo Then
            NRO_SERIE = Mid(MTBNRO_FACTURA.Text, 1, 3)
            NRO_SERIE = Replace(NRO_SERIE, " ", "")
            While Len(NRO_SERIE) < 3
                NRO_SERIE = "0" & NRO_SERIE
            End While

            NRO_DOCU = Mid(MTBNRO_FACTURA.Text, InStr(MTBNRO_FACTURA.Text, "-") + 1, 8)
            NRO_DOCU = Replace(NRO_DOCU, " ", "")
            While Len(NRO_DOCU) < 8
                NRO_DOCU = "0" & NRO_DOCU
            End While

            For i As Integer = 0 To 19
                If indice <> i Then
                    If objComprobanteAsegurada(i).NRO_SERIE = NRO_SERIE And _
                        objComprobanteAsegurada(i).NRO_DOCU = NRO_DOCU Then
                        MsgBox("Ya existe este número de documento en la lista", MsgBoxStyle.Exclamation, Me.Text)
                        Me.MTBNRO_FACTURA.Focus()
                        Exit Function
                    End If
                End If
            Next
        End If
        validar = True
    End Function
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Try
            If msg.WParam.ToInt32 = Keys.Enter Then
    
                    If CBIDTIPO_COMPROBANTE.Focused Then
                    Me.MTBNRO_FACTURA.Focus()
                ElseIf TXTOBS.Focused Then
                    Me.btnGrabar.Focus()
                ElseIf Not btnNuevo.Focused Then
                    SendKeys.Send("{Tab}")
                End If
            ElseIf msg.WParam.ToInt32 = Keys.Down Or msg.WParam.ToInt32 = Keys.Up Then
                If grdAsegurado.Focused Then
                    If msg.WParam.ToInt32 = Keys.Down Then
                        indice += 1
                    ElseIf msg.WParam.ToInt32 = Keys.Up Then
                        indice -= 1
                        If indice < 0 Then
                            indice = 0
                        End If
                    End If
                    If indice < t_indices Then
                        bNada = False
                    Else
                        indice = t_indices
                        bNada = True
                    End If
                    If bNada = False Then
                        mostrar(indice)
                    End If
                    Controlar(True, True)
                End If
                '    If indice < t_indices Then
                '        If msg.WParam.ToInt32 = Keys.Down Then
                '            indice += 1
                '            If indice = t_indices Then
                '                indice = t_indices - 1
                '            End If
                '        Else
                '            indice -= 1
                '            If indice < 0 Then
                '                indice = 0
                '                bNada = True
                '            End If
                '        End If
                '        mostrar(indice)
                '        bNada = False
                '    Else
                '        bNada = True
                '    End If
                '    Controlar(True, True)
                'End If
                End If

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try

    End Function

    Private Sub BTNELI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELI.Click
        Me.txtCosto_TotalF.Text = ""
        Me.txtMonto_IGVF.Text = ""
        Me.txtSub_TotalF.Text = ""
        If t_indices = 0 Then Exit Sub

        If (indice = 0 And indice = t_indices - 1) Or (indice = t_indices - 1) Then
            objComprobanteAsegurada(indice).ID_GUIAS_ENVIO_DOC = Nothing
            objComprobanteAsegurada(indice).FECHA = Nothing
            objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO = Nothing
            objComprobanteAsegurada(indice).IDTIPO_MONEDA = Nothing
            objComprobanteAsegurada(indice).IDTIPO_COMPROBANTE = Nothing
            objComprobanteAsegurada(indice).NRO_SERIE = Nothing
            objComprobanteAsegurada(indice).NRO_DOCU = Nothing
            objComprobanteAsegurada(indice).MONTO_IMPUESTO = Nothing
            objComprobanteAsegurada(indice).TOTAL_COSTO = Nothing
            objComprobanteAsegurada(indice).PORCEN = Nothing
            objComprobanteAsegurada(indice).OBS = Nothing
            t_indices = t_indices - 1
            If t_indices = 0 Then
                indice = t_indices - 1
                Limpiar()
                Me.BTNANTE.Enabled = False
                Me.BTNPRIME.Enabled = False
                Me.BTNULTI.Enabled = False
                Me.BTNSIGUI.Enabled = False
            Else
                indice = t_indices - 1
                mostrar(indice)
            End If
        Else
            Dim K As Integer = 0
            For K = indice To t_indices - 2

                objComprobanteAsegurada(K).ID_GUIAS_ENVIO_DOC = objComprobanteAsegurada(K + 1).ID_GUIAS_ENVIO_DOC
                objComprobanteAsegurada(K).FECHA = objComprobanteAsegurada(K + 1).FECHA
                objComprobanteAsegurada(K).MONTO_TIPO_CAMBIO = objComprobanteAsegurada(K + 1).MONTO_TIPO_CAMBIO
                objComprobanteAsegurada(K).IDTIPO_MONEDA = objComprobanteAsegurada(K + 1).IDTIPO_MONEDA
                objComprobanteAsegurada(K).IDTIPO_COMPROBANTE = objComprobanteAsegurada(K + 1).IDTIPO_COMPROBANTE
                objComprobanteAsegurada(K).NRO_SERIE = objComprobanteAsegurada(K + 1).NRO_SERIE
                objComprobanteAsegurada(K).NRO_DOCU = objComprobanteAsegurada(K + 1).NRO_DOCU
                objComprobanteAsegurada(K).MONTO_IMPUESTO = objComprobanteAsegurada(K + 1).MONTO_IMPUESTO
                objComprobanteAsegurada(K).TOTAL_COSTO = objComprobanteAsegurada(K + 1).TOTAL_COSTO
                objComprobanteAsegurada(K).PORCEN = objComprobanteAsegurada(K + 1).PORCEN
                objComprobanteAsegurada(K).OBS = objComprobanteAsegurada(K + 1).OBS

            Next

            K = K - 1

            objComprobanteAsegurada(K + 1).ID_GUIAS_ENVIO_DOC = Nothing
            objComprobanteAsegurada(K + 1).FECHA = Nothing
            objComprobanteAsegurada(K + 1).MONTO_TIPO_CAMBIO = Nothing
            objComprobanteAsegurada(K + 1).IDTIPO_MONEDA = Nothing
            objComprobanteAsegurada(K + 1).IDTIPO_COMPROBANTE = Nothing
            objComprobanteAsegurada(K + 1).NRO_SERIE = Nothing
            objComprobanteAsegurada(K + 1).NRO_DOCU = Nothing
            objComprobanteAsegurada(K + 1).MONTO_IMPUESTO = Nothing
            objComprobanteAsegurada(K + 1).TOTAL_COSTO = Nothing
            objComprobanteAsegurada(K + 1).PORCEN = Nothing
            objComprobanteAsegurada(K + 1).OBS = Nothing

            mostrar(indice)
            t_indices = t_indices - 1

        End If



        LBLCOTADOR.Text = CStr(indice + 1) & "/" & CStr(t_indices)

        If t_indices = 0 Then Habilitar(False)

    End Sub

    Private Sub TXTTOTAL_COSTO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTOTAL_COSTO.GotFocus
        TXTTOTAL_COSTO.SelectionStart = 0
        TXTTOTAL_COSTO.SelectionLength = TXTTOTAL_COSTO.TextLength
    End Sub

    Private Sub TXTTOTAL_COSTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTOTAL_COSTO.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar


            If chr.IsDigit(chr) Then
                e.Handled = False
            ElseIf chr.IsControl(chr) Then
                e.Handled = False
            ElseIf chr = "." And Not tb.Text.IndexOf(".") = -1 Then
                e.Handled = True
            ElseIf e.KeyChar = "." Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try


    End Sub

    Private Sub calculando_totales()

        If CLng(Me.CBIDTIPO_MONEDA.SelectedValue) = 1 Then
            Me.TXTMONTO_TIPO_CAMBIO.Text = "1"
            Me.TXTMONTO_TIPO_CAMBIO.Enabled = False
        Else
            Me.TXTMONTO_TIPO_CAMBIO.Enabled = True
        End If

        If IsNumeric(Me.TXTTOTAL_COSTO.Text) And IsNumeric(Me.TXTMONTO_TIPO_CAMBIO.Text) Then
            'If CLng(Me.CBIDTIPO_MONEDA.SelectedValue) = 1 Then
            objComprobanteAsegurada(indice).TOTAL_COSTO = CDbl(Me.TXTTOTAL_COSTO.Text)
            'Else
            'objComprobanteAsegurada(indice).TOTAL_COSTO = CDbl(Me.TXTTOTAL_COSTO.Text) * CDbl(Me.TXTMONTO_TIPO_CAMBIO.Text)
            'End If
            objComprobanteAsegurada(indice).IDTIPO_MONEDA = CLng(Me.CBIDTIPO_MONEDA.SelectedValue)
            objComprobanteAsegurada(indice).PORCEN_IMPUESTO = ObjCargaAsegurada.PORCEN_IMPUESTO
            objComprobanteAsegurada(indice).PORCEN = ObjCargaAsegurada.PORCEN

            'If CLng(Me.CBIDTIPO_MONEDA.SelectedValue) = 1 Then
            objComprobanteAsegurada(indice).MONTO_SUB_TOTAL = objComprobanteAsegurada(indice).TOTAL_COSTO / (1 + objComprobanteAsegurada(indice).PORCEN_IMPUESTO / 100)
            objComprobanteAsegurada(indice).MONTO_IMPUESTO = objComprobanteAsegurada(indice).TOTAL_COSTO - objComprobanteAsegurada(indice).MONTO_SUB_TOTAL
            'Else
            'objComprobanteAsegurada(indice).MONTO_SUB_TOTAL = objComprobanteAsegurada(indice).TOTAL_COSTO * CDbl(Me.TXTMONTO_TIPO_CAMBIO.Text) / (1 + objComprobanteAsegurada(indice).PORCEN_IMPUESTO / 100)
            'objComprobanteAsegurada(indice).MONTO_IMPUESTO = objComprobanteAsegurada(indice).TOTAL_COSTO - objComprobanteAsegurada(indice).MONTO_SUB_TOTAL
            'End If

            If objComprobanteAsegurada(indice).IDTIPO_MONEDA = 1 Then
                objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO = 1
            Else
                objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO = CDbl(Me.TXTMONTO_TIPO_CAMBIO.Text)
            End If

            Me.TXTMONTO_SUB_TOTAL.Text = FormatNumber(objComprobanteAsegurada(indice).MONTO_SUB_TOTAL, 2)
            Me.TXTMONTO_IMPUESTO.Text = FormatNumber(objComprobanteAsegurada(indice).TOTAL_COSTO - objComprobanteAsegurada(indice).MONTO_SUB_TOTAL, 2)

            If ObjCargaAsegurada.TIPO = 1 Then
                Me.TXTVALOR_CALCU.Text = FormatNumber(objComprobanteAsegurada(indice).TOTAL_COSTO * objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO * objComprobanteAsegurada(indice).PORCEN / 100, 2)
            Else
                Me.TXTVALOR_CALCU.Text = FormatNumber(objComprobanteAsegurada(indice).PORCEN, 2)
            End If

            'Me.txtCosto_TotalF.Text = "0"
            'Me.txtMonto_IGVF.Text = "0"
            'Me.txtSub_TotalF.Text = "0"

            'Dim k As Integer = 0
            'For k = 0 To t_indices - 1

            '    Me.txtSub_TotalF.Text = FormatNumber(CDbl(Me.txtSub_TotalF.Text) + (objComprobanteAsegurada(k).MONTO_SUB_TOTAL * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100, 2)
            '    Me.txtMonto_IGVF.Text = FormatNumber(CDbl(Me.txtMonto_IGVF.Text) + (objComprobanteAsegurada(k).MONTO_IMPUESTO * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100, 2)
            '    Me.txtCosto_TotalF.Text = FormatNumber(CDbl(Me.txtCosto_TotalF.Text) + (objComprobanteAsegurada(k).TOTAL_COSTO * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100, 2)

            'Next
        Else
            Me.TXTMONTO_SUB_TOTAL.Text = ""
            Me.TXTMONTO_IMPUESTO.Text = ""
            Me.TXTVALOR_CALCU.Text = ""

            If Val(txtCosto_TotalF.Text) = 0 Then
                Me.txtSub_TotalF.Text = ""
                Me.txtMonto_IGVF.Text = ""
                Me.txtCosto_TotalF.Text = ""
            End If
        End If
    End Sub

    Private Sub CBIDTIPO_MONEDA_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDTIPO_MONEDA.SelectionChangeCommitted
        calculando_totales()
    End Sub

    Private Sub TXTMONTO_TIPO_CAMBIO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMONTO_TIPO_CAMBIO.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar


            If chr.IsDigit(chr) Then
                e.Handled = False
            ElseIf chr.IsControl(chr) Then
                e.Handled = False
            ElseIf chr = "." And Not tb.Text.IndexOf(".") = -1 Then
                e.Handled = True
            ElseIf e.KeyChar = "." Then
                e.Handled = False
            Else
                e.Handled = True
            End If



        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TXTMONTO_TIPO_CAMBIO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTMONTO_TIPO_CAMBIO.Validated
        calculando_totales()
    End Sub

    Public Sub Opciones(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click, btnModificar.Click, btnGrabar.Click, btnCancelar.Click, btnEliminar.Click, btnSalir.Click
        'Dim sOpcion As String = CType(CType(sender, Button).Tag, String)
        Dim sopcion = CType(sender, Button).Name
        Dim bGrabo As Boolean

        Select Case sopcion.ToString.ToUpper
            Case "btnnuevo".ToUpper
                bNuevo = True
                If t_indices > 0 Then
                    'If guardar(indice) = False Then Exit Sub
                    t_indices = t_indices + 1
                    indice = t_indices - 1
                Else
                    t_indices = t_indices + 1
                    indice = t_indices - 1
                End If
                Limpiar()
                Habilitar(True)
                Controlar(False)
                grdAsegurado.Enabled = False
                CBIDTIPO_MONEDA.Focus()

            Case "btnmodificar".ToUpper
                bNuevo = False
                Controlar(False)
                Habilitar(True)
                indice = grdAsegurado.SelectedRows.Item(0).Index
                CBIDTIPO_MONEDA.Focus()

            Case "btngrabar".ToUpper
                'If t_indices > 0 Then
                't_indices = t_indices + 1
                'indice = t_indices - 1
                'Else
                't_indices = t_indices + 1
                'indice = t_indices - 1
                'End If
                bGrabo = guardar(indice)
                If bGrabo Then
                    ActualizarGrid()
                    Controlar(True)
                    Habilitar(False)

                    ActualizaTotales()
                    grdAsegurado.Enabled = True
                    lblDescripcion.Text = DescribeOperacion(indice)
                    btnNuevo.Focus()
                End If

            Case "btncancelar".ToUpper
                If bNuevo Then
                    t_indices = t_indices - 1
                    indice = t_indices - 1
                End If

                Controlar(True)
                Habilitar(False)
                grdAsegurado.Enabled = True

                If Not grdAsegurado(0, 0).Value Is Nothing Then
                    mostrar(grdAsegurado.SelectedRows.Item(0).Index)
                    btnModificar.Enabled = True
                    btnEliminar.Enabled = True
                Else
                    btnModificar.Enabled = False
                    btnEliminar.Enabled = False
                End If
                If bNuevo Then
                    btnNuevo.Focus()
                Else
                    btnModificar.Focus()
                End If

            Case "btneliminar".ToUpper
                Dim iResp As Integer = MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If iResp = vbYes Then
                    indice = grdAsegurado.SelectedRows.Item(0).Index
                    If (indice = 0 And indice = t_indices - 1) Or (indice = t_indices - 1) Then
                        objComprobanteAsegurada(indice).ID_GUIAS_ENVIO_DOC = Nothing
                        objComprobanteAsegurada(indice).FECHA = Nothing
                        objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO = Nothing
                        objComprobanteAsegurada(indice).IDTIPO_MONEDA = Nothing
                        objComprobanteAsegurada(indice).IDTIPO_COMPROBANTE = Nothing
                        objComprobanteAsegurada(indice).NRO_SERIE = Nothing
                        objComprobanteAsegurada(indice).NRO_DOCU = Nothing
                        objComprobanteAsegurada(indice).MONTO_IMPUESTO = Nothing
                        objComprobanteAsegurada(indice).TOTAL_COSTO = Nothing
                        objComprobanteAsegurada(indice).PORCEN = Nothing
                        objComprobanteAsegurada(indice).OBS = Nothing
                        t_indices = t_indices - 1
                        If t_indices = 0 Then
                            indice = t_indices - 1
                            Limpiar()
                            Controlar(True, False)
                            btnNuevo.Focus()
                        Else
                            indice = t_indices - 1
                            mostrar(indice)
                            Controlar(True)
                        End If
                        ActualizaTotales()
                        MostrarGrid()
                    Else
                        Dim K As Integer = 0
                        For K = indice To t_indices - 2
                            objComprobanteAsegurada(K).ID_GUIAS_ENVIO_DOC = objComprobanteAsegurada(K + 1).ID_GUIAS_ENVIO_DOC
                            objComprobanteAsegurada(K).FECHA = objComprobanteAsegurada(K + 1).FECHA
                            objComprobanteAsegurada(K).MONTO_TIPO_CAMBIO = objComprobanteAsegurada(K + 1).MONTO_TIPO_CAMBIO
                            objComprobanteAsegurada(K).IDTIPO_MONEDA = objComprobanteAsegurada(K + 1).IDTIPO_MONEDA
                            objComprobanteAsegurada(K).IDTIPO_COMPROBANTE = objComprobanteAsegurada(K + 1).IDTIPO_COMPROBANTE
                            objComprobanteAsegurada(K).NRO_SERIE = objComprobanteAsegurada(K + 1).NRO_SERIE
                            objComprobanteAsegurada(K).NRO_DOCU = objComprobanteAsegurada(K + 1).NRO_DOCU
                            objComprobanteAsegurada(K).MONTO_IMPUESTO = objComprobanteAsegurada(K + 1).MONTO_IMPUESTO
                            objComprobanteAsegurada(K).TOTAL_COSTO = objComprobanteAsegurada(K + 1).TOTAL_COSTO
                            objComprobanteAsegurada(K).PORCEN = objComprobanteAsegurada(K + 1).PORCEN
                            objComprobanteAsegurada(K).OBS = objComprobanteAsegurada(K + 1).OBS
                        Next
                        K = K - 1
                        objComprobanteAsegurada(K + 1).ID_GUIAS_ENVIO_DOC = Nothing
                        objComprobanteAsegurada(K + 1).FECHA = Nothing
                        objComprobanteAsegurada(K + 1).MONTO_TIPO_CAMBIO = Nothing
                        objComprobanteAsegurada(K + 1).IDTIPO_MONEDA = Nothing
                        objComprobanteAsegurada(K + 1).IDTIPO_COMPROBANTE = Nothing
                        objComprobanteAsegurada(K + 1).NRO_SERIE = Nothing
                        objComprobanteAsegurada(K + 1).NRO_DOCU = Nothing
                        objComprobanteAsegurada(K + 1).MONTO_IMPUESTO = Nothing
                        objComprobanteAsegurada(K + 1).TOTAL_COSTO = Nothing
                        objComprobanteAsegurada(K + 1).PORCEN = Nothing
                        objComprobanteAsegurada(K + 1).OBS = Nothing
                        mostrar(indice)
                        t_indices = t_indices - 1
                        MostrarGrid()
                    End If
                End If
            Case "btnsalir".ToUpper
                If Not bNuevo Then
                    Dim iValorCalculado As Double = 0
                    If Me.TXTVALOR_CALCU.Text.Trim.Length > 0 Then
                        iValorCalculado = Convert.ToDouble(TXTVALOR_CALCU.Text)
                    End If
                    If iValorCalculado > 0 Then
                        bGrabo = guardar(indice)
                        ActualizaTotales()
                    End If
                End If
                Me.Close()
        End Select
    End Sub

    Private Sub Controlar(ByVal estado As Boolean, Optional ByVal HayDatos As Boolean = True)
        btnNuevo.Enabled = estado
        btnModificar.Enabled = estado
        btnGrabar.Enabled = Not estado
        btnCancelar.Enabled = Not estado
        btnEliminar.Enabled = estado

        If Not HayDatos Then
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        End If

        'If HayDatos Then
        If recuperando_datos_contado Or bNada Then
            If bNada Then
                btnNuevo.Enabled = False
            End If
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            'End If
        End If
    End Sub

    Private Sub fnConfigurarGrid()
        grdAsegurado.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Dim col As New DataGridViewTextBoxColumn
        With col
            .DisplayIndex = 0
            .DataPropertyName = "fecha"
            .HeaderText = "Fecha"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .Width = 80
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        grdAsegurado.Columns.Add(col)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DisplayIndex = 1
            .DataPropertyName = "tipo_comprobante"
            .HeaderText = "Tipo Comprob."
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        grdAsegurado.Columns.Add(col1)

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DisplayIndex = 2
            .DataPropertyName = "numero_comprobante"
            .HeaderText = "Nº Comprob."
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        grdAsegurado.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DisplayIndex = 3
            .DataPropertyName = "subtotal"
            .HeaderText = "Sub Total"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        grdAsegurado.Columns.Add(col3)

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DisplayIndex = 4
            .DataPropertyName = "impuesto"
            .HeaderText = "Impuesto"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        grdAsegurado.Columns.Add(col4)

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DisplayIndex = 5
            .DataPropertyName = "total"
            .HeaderText = "Total Costo"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        grdAsegurado.Columns.Add(col5)

        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .DisplayIndex = 6
            .DataPropertyName = "porcentaje"
            .HeaderText = "Porcentaje"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        grdAsegurado.Columns.Add(col6)

        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .DisplayIndex = 7
            .DataPropertyName = "valor_calculado"
            .HeaderText = "Valor Calculado"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        grdAsegurado.Columns.Add(col7)
    End Sub

    Private Sub ActualizarGrid()
        If bNuevo Then
            grdAsegurado.Rows.Add(1)
        End If
        grdAsegurado(0, indice).Value = objComprobanteAsegurada(indice).FECHA
        grdAsegurado(1, indice).Value = CBIDTIPO_COMPROBANTE.Text
        grdAsegurado(2, indice).Value = objComprobanteAsegurada(indice).NRO_SERIE & "-" & objComprobanteAsegurada(indice).NRO_DOCU
        grdAsegurado(3, indice).Value = FormatNumber(objComprobanteAsegurada(indice).MONTO_SUB_TOTAL, 2)
        grdAsegurado(4, indice).Value = FormatNumber(objComprobanteAsegurada(indice).MONTO_IMPUESTO, 2)
        grdAsegurado(5, indice).Value = FormatNumber(objComprobanteAsegurada(indice).TOTAL_COSTO, 2)
        If ObjCargaAsegurada.TIPO = 1 Then
            grdAsegurado(6, indice).Value = FormatNumber(objComprobanteAsegurada(indice).PORCEN, 2)
        Else
            grdAsegurado(6, indice).Value = "0"
        End If
        grdAsegurado(7, indice).Value = FormatNumber(TXTVALOR_CALCU.Text, 2)
        grdAsegurado.CurrentCell = grdAsegurado.Rows(indice).Cells(0)

        'Dim obj As New ClsLbTepsa.dtoCargaAsegurada.ComprobanteAsegurada
        'For Each obj In objComprobanteAsegurada
        'MessageBox.Show(obj.NRO_DOCU.ToString)
        'Next

        Exit Sub
        'DTPFECHA.Value = CDate(objComprobanteAsegurada(indice).FECHA)
        'Me.TXTMONTO_TIPO_CAMBIO.Text = CStr(objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO)
        'Me.CBIDTIPO_MONEDA.SelectedValue = objComprobanteAsegurada(indice).IDTIPO_MONEDA
        'Me.CBIDTIPO_COMPROBANTE.SelectedValue = objComprobanteAsegurada(indice).IDTIPO_COMPROBANTE

        'If objComprobanteAsegurada(indice).IDTIPO_MONEDA = 1 Then
        '    Me.TXTMONTO_TIPO_CAMBIO.Enabled = False
        'Else
        '    Me.TXTMONTO_TIPO_CAMBIO.Enabled = True
        'End If
        'Me.MTBNRO_FACTURA.Text = objComprobanteAsegurada(indice).NRO_SERIE & "-" & objComprobanteAsegurada(indice).NRO_DOCU
        'Me.TXTTOTAL_COSTO.Text = FormatNumber(objComprobanteAsegurada(indice).TOTAL_COSTO, 2)

        'objComprobanteAsegurada(indice).PORCEN_IMPUESTO = ObjCargaAsegurada.PORCEN_IMPUESTO
        'objComprobanteAsegurada(indice).PORCEN = ObjCargaAsegurada.PORCEN
        'objComprobanteAsegurada(indice).MONTO_SUB_TOTAL = objComprobanteAsegurada(indice).TOTAL_COSTO / (1 + objComprobanteAsegurada(indice).PORCEN_IMPUESTO / 100)

        'Me.TXTMONTO_SUB_TOTAL.Text = FormatNumber(objComprobanteAsegurada(indice).MONTO_SUB_TOTAL, 2)
        'Me.TXTMONTO_IMPUESTO.Text = FormatNumber(objComprobanteAsegurada(indice).TOTAL_COSTO - objComprobanteAsegurada(indice).MONTO_SUB_TOTAL, 2)

        'Me.TXTPORCEN.Text = FormatNumber(objComprobanteAsegurada(indice).PORCEN, 2)
        'Me.TXTOBS.Text = objComprobanteAsegurada(indice).OBS
        'Me.TXTVALOR_CALCU.Text = FormatNumber(objComprobanteAsegurada(indice).TOTAL_COSTO * objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO * objComprobanteAsegurada(indice).PORCEN / 100, 2)

        'Me.txtCosto_TotalF.Text = "0"
        'Me.txtMonto_IGVF.Text = "0"
        'Me.txtSub_TotalF.Text = "0"

        'Dim k As Integer = 0
        'For k = 0 To t_indices - 1
        '    Me.txtSub_TotalF.Text = FormatNumber(CDbl(Me.txtSub_TotalF.Text) + (objComprobanteAsegurada(k).MONTO_SUB_TOTAL * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100, 2)
        '    Me.txtMonto_IGVF.Text = FormatNumber(CDbl(Me.txtMonto_IGVF.Text) + (objComprobanteAsegurada(k).MONTO_IMPUESTO * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100, 2)
        '    Me.txtCosto_TotalF.Text = FormatNumber(CDbl(Me.txtCosto_TotalF.Text) + (objComprobanteAsegurada(k).TOTAL_COSTO * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100, 2)
        'Next
    End Sub

    Private Sub TXTOBS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOBS.KeyPress
        Dim chr As Char = e.KeyChar
        If chr.IsControl(chr) Then
            e.Handled = False
        End If
    End Sub

    Private Sub MostrarGrid()
        'grdAsegurado.Rows.Add(1)
        'grdAsegurado(0, indice).Value = objComprobanteAsegurada(indice).FECHA
        'grdAsegurado(1, indice).Value = CBIDTIPO_COMPROBANTE.Text
        'grdAsegurado(2, indice).Value = objComprobanteAsegurada(indice).NRO_SERIE & "-" & objComprobanteAsegurada(indice).NRO_DOCU
        'grdAsegurado(3, indice).Value = FormatNumber(objComprobanteAsegurada(indice).MONTO_SUB_TOTAL, 2)
        'grdAsegurado(4, indice).Value = FormatNumber(objComprobanteAsegurada(indice).MONTO_IMPUESTO, 2)
        'grdAsegurado(5, indice).Value = FormatNumber(objComprobanteAsegurada(indice).TOTAL_COSTO, 2)
        'grdAsegurado(6, indice).Value = FormatNumber(objComprobanteAsegurada(indice).PORCEN, 2)
        'grdAsegurado(7, indice).Value = FormatNumber(TXTVALOR_CALCU.Text, 2)

        Dim obj As New ClsLbTepsa.dtoCargaAsegurada.ComprobanteAsegurada
        Dim i As Integer = 0

        grdAsegurado.Rows.Clear()
        For Each obj In objComprobanteAsegurada
            'MessageBox.Show(obj.NRO_DOCU.ToString)
            If Not objComprobanteAsegurada(i).FECHA Is Nothing Then
                grdAsegurado.Rows.Add()
                grdAsegurado(0, i).Value = objComprobanteAsegurada(i).FECHA
                If objComprobanteAsegurada(i).IDTIPO_COMPROBANTE = 1 Then
                    grdAsegurado(1, i).Value = "FACTURA"
                ElseIf objComprobanteAsegurada(i).IDTIPO_COMPROBANTE = 2 Then
                    grdAsegurado(1, i).Value = "BOLETA VENTA"
                End If
                grdAsegurado(2, i).Value = objComprobanteAsegurada(i).NRO_SERIE & "-" & objComprobanteAsegurada(i).NRO_DOCU
                grdAsegurado(3, i).Value = FormatNumber(objComprobanteAsegurada(i).MONTO_SUB_TOTAL, 2)
                grdAsegurado(4, i).Value = FormatNumber(objComprobanteAsegurada(i).MONTO_IMPUESTO, 2)
                grdAsegurado(5, i).Value = FormatNumber(objComprobanteAsegurada(i).TOTAL_COSTO, 2)
                If objComprobanteAsegurada(i).TIPO = 1 Or objComprobanteAsegurada(i).TIPO = 0 Then
                    grdAsegurado(6, i).Value = FormatNumber(objComprobanteAsegurada(i).PORCEN, 2)
                    grdAsegurado(7, i).Value = FormatNumber(objComprobanteAsegurada(i).TOTAL_COSTO * objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO * (objComprobanteAsegurada(i).PORCEN / 100), 2)
                Else
                    grdAsegurado(6, i).Value = 0
                    grdAsegurado(7, i).Value = FormatNumber(objComprobanteAsegurada(i).PORCEN, 2)
                End If
                i += 1
            End If
        Next

        If i > 0 Then
            mostrar(0)
        End If
        Exit Sub
        'DTPFECHA.Value = CDate(objComprobanteAsegurada(indice).FECHA)
        'Me.TXTMONTO_TIPO_CAMBIO.Text = CStr(objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO)
        'Me.CBIDTIPO_MONEDA.SelectedValue = objComprobanteAsegurada(indice).IDTIPO_MONEDA
        'Me.CBIDTIPO_COMPROBANTE.SelectedValue = objComprobanteAsegurada(indice).IDTIPO_COMPROBANTE

        'If objComprobanteAsegurada(indice).IDTIPO_MONEDA = 1 Then
        '    Me.TXTMONTO_TIPO_CAMBIO.Enabled = False
        'Else
        '    Me.TXTMONTO_TIPO_CAMBIO.Enabled = True
        'End If
        'Me.MTBNRO_FACTURA.Text = objComprobanteAsegurada(indice).NRO_SERIE & "-" & objComprobanteAsegurada(indice).NRO_DOCU
        'Me.TXTTOTAL_COSTO.Text = FormatNumber(objComprobanteAsegurada(indice).TOTAL_COSTO, 2)

        'objComprobanteAsegurada(indice).PORCEN_IMPUESTO = ObjCargaAsegurada.PORCEN_IMPUESTO
        'objComprobanteAsegurada(indice).PORCEN = ObjCargaAsegurada.PORCEN
        'objComprobanteAsegurada(indice).MONTO_SUB_TOTAL = objComprobanteAsegurada(indice).TOTAL_COSTO / (1 + objComprobanteAsegurada(indice).PORCEN_IMPUESTO / 100)

        'Me.TXTMONTO_SUB_TOTAL.Text = FormatNumber(objComprobanteAsegurada(indice).MONTO_SUB_TOTAL, 2)
        'Me.TXTMONTO_IMPUESTO.Text = FormatNumber(objComprobanteAsegurada(indice).TOTAL_COSTO - objComprobanteAsegurada(indice).MONTO_SUB_TOTAL, 2)

        'Me.TXTPORCEN.Text = FormatNumber(objComprobanteAsegurada(indice).PORCEN, 2)
        'Me.TXTOBS.Text = objComprobanteAsegurada(indice).OBS
        'Me.TXTVALOR_CALCU.Text = FormatNumber(objComprobanteAsegurada(indice).TOTAL_COSTO * objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO * objComprobanteAsegurada(indice).PORCEN / 100, 2)

        'Me.txtCosto_TotalF.Text = "0"
        'Me.txtMonto_IGVF.Text = "0"
        'Me.txtSub_TotalF.Text = "0"

        'Dim k As Integer = 0
        'For k = 0 To t_indices - 1
        '    Me.txtSub_TotalF.Text = FormatNumber(CDbl(Me.txtSub_TotalF.Text) + (objComprobanteAsegurada(k).MONTO_SUB_TOTAL * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100, 2)
        '    Me.txtMonto_IGVF.Text = FormatNumber(CDbl(Me.txtMonto_IGVF.Text) + (objComprobanteAsegurada(k).MONTO_IMPUESTO * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100, 2)
        '    Me.txtCosto_TotalF.Text = FormatNumber(CDbl(Me.txtCosto_TotalF.Text) + (objComprobanteAsegurada(k).TOTAL_COSTO * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100, 2)
        'Next
    End Sub

    Private Sub ActualizaTotales()
        Dim k As Integer = 0
        Dim iSub As Double
        Dim iIgv As Double
        Dim iTotal As Double
        Dim iSubtotal As Double

        Me.txtSub_TotalF.Text = ""
        Me.txtMonto_IGVF.Text = ""
        Me.txtCosto_TotalF.Text = ""
        iSub = 0
        iIgv = CDbl(IIf(Val(Me.txtMonto_IGVF.Text) = 0, 0, txtMonto_IGVF.Text))
        iTotal = CDbl(IIf(Val(Me.txtCosto_TotalF.Text) = 0, 0, Me.txtCosto_TotalF.Text))
        iSubtotal = CDbl(IIf(Val(Me.txtSub_TotalF.Text) = 0, 0, Me.txtSub_TotalF.Text))

        For k = 0 To t_indices - 1
            If objComprobanteAsegurada(k).TIPO = 1 Or objComprobanteAsegurada(k).TIPO = 0 Then
                iSubtotal = iSubtotal + (objComprobanteAsegurada(k).MONTO_SUB_TOTAL * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100
                iIgv = iIgv + (objComprobanteAsegurada(k).MONTO_IMPUESTO * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100
                iTotal = iTotal + (objComprobanteAsegurada(k).TOTAL_COSTO * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100
                'Me.txtSub_TotalF.Text = FormatNumber(Val(Me.txtSub_TotalF.Text) + (objComprobanteAsegurada(k).MONTO_SUB_TOTAL * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100, 2)
                'Me.txtMonto_IGVF.Text = FormatNumber(Val(Me.txtMonto_IGVF.Text) + (objComprobanteAsegurada(k).MONTO_IMPUESTO * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100, 2)
                'Me.txtCosto_TotalF.Text = FormatNumber(Val(Me.txtCosto_TotalF.Text) + (objComprobanteAsegurada(k).TOTAL_COSTO * objComprobanteAsegurada(k).MONTO_TIPO_CAMBIO) * objComprobanteAsegurada(k).PORCEN / 100, 2)
            ElseIf objComprobanteAsegurada(k).TIPO = 2 Then
                'Me.txtSub_TotalF.Text = FormatNumber(Val(Me.txtSub_TotalF.Text) + (objComprobanteAsegurada(k).PORCEN / (1 + 19 / 100)), 2)
                iSubtotal = iSubtotal + (objComprobanteAsegurada(k).PORCEN / (1 + dtoUSUARIOS.vImpuesto))
                iSub = objComprobanteAsegurada(k).PORCEN / (1 + dtoUSUARIOS.vImpuesto)
                iIgv = iIgv + (iSub * (dtoUSUARIOS.vImpuesto))
                iTotal = iTotal + (objComprobanteAsegurada(k).PORCEN)
                'Me.txtMonto_IGVF.Text = FormatNumber(Val(Me.txtMonto_IGVF.Text) + (iSub * (19 / 100)), 2)
                'Me.txtCosto_TotalF.Text = FormatNumber(Val(Me.txtCosto_TotalF.Text) + (objComprobanteAsegurada(k).PORCEN), 2)
            End If
        Next
        Me.txtSub_TotalF.Text = FormatNumber(iSubtotal, 2)
        Me.txtMonto_IGVF.Text = FormatNumber(iIgv, 2)
        Me.txtCosto_TotalF.Text = FormatNumber(iTotal, 2)
    End Sub

    Private Sub grdAsegurado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAsegurado.Click
        If grdAsegurado.SelectedRows.Item(0).Index < t_indices Then
            indice = grdAsegurado.SelectedRows.Item(0).Index
            mostrar(grdAsegurado.SelectedRows.Item(0).Index)
            If bNuevo Or bNada Then
                bNada = False
                Controlar(True, True)
            Else
                bNada = False
            End If
        Else
            If Not (grdAsegurado(0, 0).Value Is Nothing) Then
                bNada = True
                Controlar(True, True)
            End If
        End If
    End Sub

    Private Sub CBIDTIPO_MONEDA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDTIPO_MONEDA.SelectedIndexChanged

    End Sub

    Private Sub TXTMONTO_TIPO_CAMBIO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTMONTO_TIPO_CAMBIO.TextChanged

    End Sub

    Private Sub TXTTOTAL_COSTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTTOTAL_COSTO.TextChanged

    End Sub

    Private Sub TXTMONTO_TIPO_CAMBIO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTMONTO_TIPO_CAMBIO.LostFocus
        TXTMONTO_TIPO_CAMBIO.Text = FormatNumber(TXTMONTO_TIPO_CAMBIO.Text, 2)
    End Sub

    Private Sub TXTTOTAL_COSTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTOTAL_COSTO.Validating
        Dim iValor As Double = 0

        iTotal = Val(TXTTOTAL_COSTO.Text)

        TXTTOTAL_COSTO.Text = Format(CDbl(iTotal), "0.00")
        If CBIDTIPO_MONEDA.SelectedIndex = 1 Then
            iTotal = iTotal * Val(TXTMONTO_TIPO_CAMBIO.Text)
        End If

        iValor = -1
        If (Not IsDBNull(sDocCliente)) And sDocCliente.Trim.Length > 0 Then     'Tarifa personalizada
            'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
            'ObjCargaAsegurada.SP_RECUPERA_MONTO_PORCE_CLI(sDocCliente, iTotal, cnn)
            ObjCargaAsegurada.SP_RECUPERA_MONTO_PORCE_CLI(sDocCliente, iTotal)
            '
            iValor = ObjCargaAsegurada.PORCEN
            If iValor >= 0 Then
                iProcedencia = 1
            End If
        End If

        If iValor < 0 Then 'Tarifa general
            'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
            'ObjCargaAsegurada.SP_RECUPERA_MONTO_PORCE(iTotal, cnn)
            ObjCargaAsegurada.SP_RECUPERA_MONTO_PORCE(iTotal)
            iValor = ObjCargaAsegurada.PORCEN
            If iValor >= 0 Then
                iProcedencia = 2
            End If
        End If

        If iValor < 0 Then
            iValor = 0
            iProcedencia = 0
        End If
        If ObjCargaAsegurada.TIPO = 1 Then
            TXTPORCEN.Text = FormatNumber(iValor, 2)
        Else
            TXTPORCEN.Text = "0"
        End If
        calculando_totales()
    End Sub

    Private Sub mostrar(ByVal indice As Integer)
        Dim iSub As Double

        DTPFECHA.Value = CDate(objComprobanteAsegurada(indice).FECHA)
        Me.TXTMONTO_TIPO_CAMBIO.Text = CStr(objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO)
        Me.CBIDTIPO_MONEDA.SelectedValue = objComprobanteAsegurada(indice).IDTIPO_MONEDA
        Me.CBIDTIPO_COMPROBANTE.SelectedValue = objComprobanteAsegurada(indice).IDTIPO_COMPROBANTE
        Me.MTBNRO_FACTURA.Text = objComprobanteAsegurada(indice).NRO_SERIE & "-" & objComprobanteAsegurada(indice).NRO_DOCU
        Me.TXTTOTAL_COSTO.Text = Format(objComprobanteAsegurada(indice).TOTAL_COSTO, "0.00")
        objComprobanteAsegurada(indice).PORCEN_IMPUESTO = ObjCargaAsegurada.PORCEN_IMPUESTO
        objComprobanteAsegurada(indice).MONTO_SUB_TOTAL = objComprobanteAsegurada(indice).TOTAL_COSTO / (1 + objComprobanteAsegurada(indice).PORCEN_IMPUESTO / 100)

        Me.TXTMONTO_SUB_TOTAL.Text = Format(objComprobanteAsegurada(indice).MONTO_SUB_TOTAL, "0.00")
        Me.TXTMONTO_IMPUESTO.Text = Format(objComprobanteAsegurada(indice).TOTAL_COSTO - objComprobanteAsegurada(indice).MONTO_SUB_TOTAL, "0.00")

        If objComprobanteAsegurada(indice).TIPO = 1 Or objComprobanteAsegurada(indice).TIPO = 0 Then
            Me.TXTPORCEN.Text = Format(objComprobanteAsegurada(indice).PORCEN, "0.00")
            Me.TXTVALOR_CALCU.Text = Format(objComprobanteAsegurada(indice).TOTAL_COSTO * objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO * objComprobanteAsegurada(indice).PORCEN / 100, "0.00")
        ElseIf objComprobanteAsegurada(indice).TIPO = 2 Then
            Me.TXTPORCEN.Text = "0"
            Me.TXTVALOR_CALCU.Text = Format(objComprobanteAsegurada(indice).PORCEN, "0.00")
        End If
        Me.TXTOBS.Text = objComprobanteAsegurada(indice).OBS

        lblDescripcion.Text = DescribeOperacion(indice)
        ActualizaTotales()
    End Sub

    Private Function DescribeOperacion(ByVal i As Integer) As String
        Dim sTipo As String
        Dim sProcedencia As String
        Dim sResultado As String

        Try
            If objComprobanteAsegurada(i).TIPO = 1 Then
                sTipo = "%"
            ElseIf objComprobanteAsegurada(i).TIPO = 2 Then
                sTipo = "Monto Mínimo"
            Else
                sTipo = ""
            End If

            If objComprobanteAsegurada(i).PROCEDENCIA = 1 Then
                sProcedencia = "Tarifa Personalizada"
            ElseIf objComprobanteAsegurada(i).PROCEDENCIA = 2 Then
                sProcedencia = "Tarifa General"
            Else
                sProcedencia = ""
            End If
            If objComprobanteAsegurada(i).TIPO = 1 Then
                sResultado = "Total Costo (" & FormatNumber(objComprobanteAsegurada(i).TOTAL_COSTO, 2) & ")  *  "
                sResultado = sResultado & sTipo & " " & sProcedencia & " (" & FormatNumber(objComprobanteAsegurada(i).PORCEN, 2) & ")"
                sResultado = sResultado & "  =  Valor Calculado (" & TXTVALOR_CALCU.Text & ")"
            ElseIf objComprobanteAsegurada(i).TIPO = 2 Then
                sResultado = sTipo & " " & sProcedencia & " (" & FormatNumber(objComprobanteAsegurada(i).PORCEN, 2) & ")"
            End If
            Return sResultado
        Catch
            Return ""
        End Try
    End Function

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevo.EnabledChanged, btnModificar.EnabledChanged, btnEliminar.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub TXTOBS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTOBS.TextChanged

    End Sub

    Private Sub grdAsegurado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAsegurado.CellContentClick

    End Sub

    Private Sub grdAsegurado_ColumnHeadersBorderStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAsegurado.ColumnHeadersBorderStyleChanged

    End Sub
End Class