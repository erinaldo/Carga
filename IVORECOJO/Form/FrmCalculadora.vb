Public Class FrmCalculadora
    Public bNuevo As Boolean
    Dim bsalir As Boolean = True
    Dim bInicio As Boolean = True
    Dim dtOrigen As DataTable
    Dim dtCondicion As New DataTable
    Private Sub FrmCalculadora_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bNuevo Then
            CboOrigen.Focus()
        End If
    End Sub
    Private Sub FrmCalculadora_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bsalir Then
            bsalir = True
            e.Cancel = True
        End If
    End Sub
    Private Sub FrmCalculadora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        ElseIf Asc(e.KeyChar) = Keys.Escape Then
            Close()
        End If
    End Sub
    Private Sub FrmCalculadora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            bInicio = True
            Dim obj As New dtrecojo
            Dim ds As DataSet = obj.InicioCalculadora

            dtOrigen = ds.Tables(0)
            CboOrigen.DataSource = dtOrigen
            CboOrigen.DisplayMember = "nombre_unidad"
            CboOrigen.ValueMember = "idunidad_agencia"
            CboOrigen.SelectedValue = 5100

            CboDestino.DataSource = ds.Tables(1)
            CboDestino.DisplayMember = "nombre_unidad"
            CboDestino.ValueMember = "idunidad_agencia"
            CboDestino.SelectedValue = 5100

            CboProducto.DataSource = ds.Tables(2)
            CboProducto.DisplayMember = "procesos"
            CboProducto.ValueMember = "idprocesos"
            CboTarifa.SelectedIndex = 0

            CboTipoEntrega.DataSource = ds.Tables(3)
            CboTipoEntrega.DisplayMember = "tipo_entrega"
            CboTipoEntrega.ValueMember = "idtipo_entrega"
            CboTipoEntrega.SelectedIndex = 0

            CboTipo.SelectedIndex = 0

            Me.Panel1.Left = Me.Panel2.Left
            Me.Panel1.Top = Me.Panel2.Top
            Me.Width = 359

            bInicio = False
            obj = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TxtPeso_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPeso.Enter
        Dim iValor As Double = 0
        If Me.TxtPeso.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtPeso.Text
        End If
        Me.TxtPeso.Text = Format(CDbl(iValor), "########0.00")
        If Val(TxtPeso.Text) = 0 Then
            TxtPeso.Text = ""
        End If
    End Sub
    Private Sub TxtVolumen_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVolumen.Enter
        Dim iValor As Double = 0
        If Me.TxtVolumen.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtVolumen.Text
        End If
        Me.TxtVolumen.Text = Format(CDbl(iValor), "########0.00")
        If Val(TxtVolumen.Text) = 0 Then
            TxtVolumen.Text = ""
        End If
    End Sub

    Private Sub TxtVolumen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVolumen.LostFocus
        Dim iValor As Double = 0
        If Me.TxtVolumen.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtVolumen.Text
        End If
        Me.TxtVolumen.Text = Format(CDbl(iValor), "##,###,###0.00")
        If Val(TxtVolumen.Text) = 0 Then
            TxtVolumen.Text = ""
        End If
    End Sub

    Private Sub TxtPeso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPeso.LostFocus
        Dim iValor As Double = 0
        If Me.TxtPeso.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtPeso.Text
        End If
        Me.TxtPeso.Text = Format(CDbl(iValor), "##,###,###0.00")
        If Val(TxtPeso.Text) = 0 Then
            TxtPeso.Text = ""
        End If
    End Sub

    Private Sub TxtPeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPeso.KeyPress
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = Numero(e, TxtPeso)
    End Sub

    Private Sub TxtVolumen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVolumen.KeyPress
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = Numero(e, TxtVolumen)
    End Sub

    Private Sub TxtSobre2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSobre.GotFocus
        TxtSobre.SelectAll()
    End Sub

    Private Sub TxtSobre2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSobre2.KeyPress
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtSobre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSobre.GotFocus
        TxtSobre.SelectAll()
    End Sub

    Private Sub TxtSobre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSobre.KeyPress
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub TxtValor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtValor.Enter
        Dim iValor As Double = 0
        If Me.TxtValor.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtValor.Text
        End If
        Me.TxtValor.Text = Format(CDbl(iValor), "########0.00")
        If Val(TxtValor.Text) = 0 Then
            TxtValor.Text = ""
        End If
    End Sub

    Private Sub TxtValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtValor.KeyPress
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = Numero(e, TxtPeso)
    End Sub

    Private Sub TxtValor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtValor.LostFocus
        Dim iValor As Double = 0
        If Me.TxtValor.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtValor.Text
        End If
        Me.TxtValor.Text = Format(CDbl(iValor), "##,###,###0.00")
        If Val(TxtValor.Text) = 0 Then
            TxtValor.Text = ""
        End If
    End Sub

    Sub Tarifa() Handles CboOrigen.SelectedIndexChanged, CboDestino.SelectedIndexChanged, CboProducto.SelectedIndexChanged, CboTarifa.SelectedIndexChanged, CboTipoEntrega.SelectedIndexChanged, CboTipo.SelectedIndexChanged
        Try
            If bInicio Then Return


            Dim iOrigen As Integer = Me.CboOrigen.SelectedValue
            Dim iDestino As Integer = Me.CboDestino.SelectedValue
            If iOrigen = iDestino Then Return

            Dim iProducto As Integer = Me.CboProducto.SelectedValue
            Dim iTarifa As Integer = Me.CboTarifa.SelectedIndex
            Dim iEntrega As Integer = Me.CboTipoEntrega.SelectedValue

            Dim obj As New dtoCalculadora
            dtCondicion = obj.TarifaPublica(iOrigen, iDestino, iProducto, iTarifa, iEntrega)

            Dim iPeso As Double = obj.Peso
            Dim iVolumen As Double = obj.Volumen
            Dim iBase As Double = obj.Base
            Dim iSobre As Double = obj.Sobre

            'If Me.Panel2.Visible Then
            Me.TxtCostoPeso.Text = Format(iPeso, "###,###,###0.00")
            Me.TxtCostoVolumen.Text = Format(iVolumen, "###,###,###0.00")
            Me.TxtCostoBase.Text = Format(iBase, "###,###,###0.00")
            Me.TxtCostoSobre.Text = Format(iSobre, "###,###,###0.00")

            Me.TxtCosto2.Text = Format(iPeso, "###,###,###0.00")
            Me.TxtCostoBase2.Text = Format(iBase, "###,###,###0.00")
            Me.TxtCostoSobre2.Text = Format(iSobre, "###,###,###0.00")

            If Me.Panel2.Visible Then
                Me.Precalcular()
            Else
                Me.PrecalcularM3()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Precalcular() Handles TxtPeso.TextChanged, TxtVolumen.TextChanged, TxtSobre.TextChanged, TxtValor.TextChanged
        If bInicio Then Return

        Dim iPeso As Double = Convert.ToDouble(IIf(Val(Me.TxtPeso.Text) = 0, 0, Me.TxtPeso.Text))
        Dim iCostoPeso As Double = Me.TxtCostoPeso.Text
        Dim iSubNetoP As Double = iPeso * iCostoPeso

        Dim iMonto As Double = 0, iPeso2 As Double = 0
        If dtCondicion.Rows.Count > 0 Then
            If Not IsDBNull(dtCondicion.Rows(0).Item(0)) Then
                Dim iTotalCondicion = Me.MontoCondicion(1, iPeso, iCostoPeso)
                If iTotalCondicion > 0 Then
                    iSubNetoP = iTotalCondicion
                End If
            End If
        End If

        Me.TxtSubNetoP.Text = Format(iSubNetoP, "###,###,###0.00")

        Dim iVolumen As Double = Convert.ToDouble(IIf(Val(Me.TxtVolumen.Text) = 0, 0, Me.TxtVolumen.Text))
        Dim iCostoVolumen As Double = Me.TxtCostoVolumen.Text
        Dim iSubNetoV As Double = iVolumen * iCostoVolumen
        Me.TxtSubNetoV.Text = Format(iSubNetoV, "###,###,###0.00")

        Dim iSobre As Double = Convert.ToDouble(IIf(Val(Me.TxtSobre.Text) = 0, 0, Me.TxtSobre.Text))
        Dim iCostoSobre As Integer = Me.TxtCostoSobre.Text
        Dim iSubNetoS As Double = iSobre * iCostoSobre
        Me.TxtSubNetoS.Text = Format(iSubNetoS, "###,###,###0.00")

        Dim iCostoBase As Double
        If iSubNetoP = 0 And iSubNetoS = 0 And iSubNetoV = 0 Then
            iCostoBase = 0
        Else
            iCostoBase = Convert.ToDouble(IIf(Val(Me.TxtCostoBase.Text) = 0, 0, Me.TxtCostoBase.Text))
        End If
        Dim iSubNetoB As Double = iCostoBase
        Me.TxtSubNetoB.Text = Format(iSubNetoB, "###,###,###0.00")

        Dim iCostoValor, iSubNetoValor As Double
        Dim iValor As Double = Convert.ToDouble(IIf(Val(Me.TxtValor.Text) = 0, 0, Me.TxtValor.Text))
        If iValor > 0 Then
            Dim obj As New dtoCalculadora
            Dim iTipo As Integer, iPorcentaje As Double
            obj.ObtieneSeguro(iValor, iTipo, iPorcentaje)
            iCostoValor = iPorcentaje
            If iPorcentaje > 0 Then
                If iTipo = 1 Then
                    iSubNetoValor = (iValor * (iPorcentaje / 100))
                Else
                    iSubNetoValor = iPorcentaje
                End If
            Else
                iCostoValor = 0
                iSubNetoValor = 0
            End If
        Else
            iCostoValor = 0
            iSubNetoValor = 0
        End If
        Me.TxtCostoValor.Text = Format(iCostoValor, "###,###,###0.00")
        Me.TxtSubNetoValor.Text = Format(iSubNetoValor, "###,###,###0.00")

        Me.Calcular()
    End Sub

    Private Sub TxtAltura_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAltura.Enter
        Dim iValor As Double = 0
        If Me.TxtAltura.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtAltura.Text
        End If
        Me.TxtAltura.Text = Format(CDbl(iValor), "########0.00")
        If Val(TxtAltura.Text) = 0 Then
            TxtAltura.Text = ""
        End If
    End Sub

    Private Sub TxtAltura_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAltura.GotFocus
        TxtAltura.SelectAll()
    End Sub

    Private Sub TxtAltura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAltura.KeyPress
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = Numero(e, TxtAltura)
    End Sub

    Private Sub TxtAltura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAltura.LostFocus
        Dim iValor As Double = 0
        If Me.TxtAltura.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtAltura.Text
        End If
        Me.TxtAltura.Text = Format(CDbl(iValor), "##,###,###0.00")
        If Val(TxtAltura.Text) = 0 Then
            TxtAltura.Text = ""
        End If
    End Sub

    Private Sub TxtAncho_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAncho.GotFocus
        TxtAncho.SelectAll()
    End Sub

    Private Sub TxtAncho_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAncho.KeyPress
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = Numero(e, TxtAncho)
    End Sub

    Private Sub TxtAncho_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAncho.LostFocus
        Dim iValor As Double = 0
        If Me.TxtAncho.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtAncho.Text
        End If
        Me.TxtAncho.Text = Format(CDbl(iValor), "##,###,###0.00")
        If Val(TxtAncho.Text) = 0 Then
            TxtAncho.Text = ""
        End If
    End Sub

    Private Sub TxtLargo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLargo.GotFocus
        TxtLargo.SelectAll()
    End Sub

    Private Sub TxtLargo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLargo.KeyPress
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = Numero(e, TxtAncho)
    End Sub

    Private Sub TxtLargo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLargo.LostFocus
        Dim iValor As Double = 0
        If Me.TxtLargo.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtLargo.Text
        End If
        Me.TxtLargo.Text = Format(CDbl(iValor), "##,###,###0.00")
        If Val(TxtLargo.Text) = 0 Then
            TxtLargo.Text = ""
        End If
    End Sub

    Private Sub TxtValor2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtValor2.KeyPress
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = Numero(e, TxtValor2)
    End Sub

    Sub PrecalcularM3() Handles TxtSobre2.TextChanged, TxtValor2.TextChanged, TxtAltura.TextChanged, TxtAncho.TextChanged, TxtLargo.TextChanged
        If bInicio Then Return

        Dim iSobre As Integer = Convert.ToDouble(IIf(Val(Me.TxtSobre2.Text) = 0, 0, Me.TxtSobre2.Text))
        Dim iCostoSobre As Integer = Me.TxtCostoSobre2.Text
        Dim iSubNetoS As Double = iSobre * iCostoSobre
        Me.TxtSubNetoS2.Text = Format(iSubNetoS, "###,###,###0.00")

        Dim iCostoBase As Double
        If iSubNetoS = 0 Then
            iCostoBase = 0
        Else
            iCostoBase = Me.TxtCostoBase2.Text
        End If
        Dim iSubNetoB As Double = iCostoBase
        Me.TxtSubNetoB2.Text = Format(iSubNetoB, "###,###,###0.00")

        Dim iCostoValor, iSubNetoValor As Double
        Dim iValor As Double = Convert.ToDouble(IIf(Val(Me.TxtValor2.Text) = 0, 0, Me.TxtValor2.Text))
        If iValor > 0 Then
            Dim obj As New dtoCalculadora
            Dim iTipo As Integer, iPorcentaje As Double
            obj.ObtieneSeguro(iValor, iTipo, iPorcentaje)
            iCostoValor = iPorcentaje
            If iPorcentaje > 0 Then
                If iTipo = 1 Then
                    iSubNetoValor = (iValor * (iPorcentaje / 100))
                Else
                    iSubNetoValor = iPorcentaje
                End If
            Else
                iCostoValor = 0
                iSubNetoValor = 0
            End If
        Else
            iCostoValor = 0
            iSubNetoValor = 0
        End If
        Me.TxtCostoValor2.Text = Format(iCostoValor, "###,###,###0.00")
        Me.TxtSubNetoValor2.Text = Format(iSubNetoValor, "###,###,###0.00")

        Dim iAltura As Double = Convert.ToDouble(IIf(Val(Me.TxtAltura.Text) = 0, 0, Me.TxtAltura.Text))
        Dim iAncho As Double = Convert.ToDouble(IIf(Val(Me.TxtAncho.Text) = 0, 0, Me.TxtAncho.Text))
        Dim iLargo As Double = Convert.ToDouble(IIf(Val(Me.TxtLargo.Text) = 0, 0, Me.TxtLargo.Text))
        Dim iFactor As Double = Convert.ToDouble(TxtFactor.Text)
        Dim iCosto As Double = Convert.ToDouble(IIf(Val(Me.TxtCosto2.Text) = 0, 0, Me.TxtCosto2.Text))

        Dim iM3 = iAltura * iAncho * iLargo
        Dim iKg = iM3 * iFactor
        Dim iSubNeto As Double = iKg * iCosto

        Dim iMonto As Double = 0, iPeso2 As Double = 0
        If dtCondicion.Rows.Count > 0 Then
            If Not IsDBNull(dtCondicion.Rows(0).Item(0)) Then
                Dim iTotalCondicion = Me.MontoCondicion(1, iKg, iCosto)
                If iTotalCondicion > 0 Then
                    iSubNeto = iTotalCondicion
                End If
            End If
        End If

        Me.TxtPeso2.Text = Format(iKg, "###,###,###0.00")
        Me.TxtSubNeto.Text = Format(iSubNeto, "###,###,###0.00")

        Me.CalcularM3()
    End Sub

    Private Sub TxtSobre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSobre.LostFocus
        Dim iValor As Double = 0
        If Me.TxtSobre.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtSobre.Text
        End If
        Me.TxtSobre.Text = Format(CDbl(iValor), "##,###,###0.00")
        If Val(TxtSobre.Text) = 0 Then
            TxtSobre.Text = ""
        End If
    End Sub

    Private Sub TxtSobre2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSobre2.LostFocus
        Dim iValor As Double = 0
        If Me.TxtSobre2.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtSobre2.Text
        End If
        Me.TxtSobre2.Text = Format(CDbl(iValor), "##,###,###0.00")
        If Val(TxtSobre2.Text) = 0 Then
            TxtSobre2.Text = ""
        End If
    End Sub

    Private Sub TxtCostoSobre2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCostoSobre2.Enter
        Dim iValor As Double = 0
        If Me.TxtCostoSobre2.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtCostoSobre2.Text
        End If
        Me.TxtCostoSobre2.Text = Format(CDbl(iValor), "########0.00")
        If Val(TxtCostoSobre2.Text) = 0 Then
            TxtCostoSobre2.Text = ""
        End If
    End Sub

    Private Sub TxtValor2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtValor2.LostFocus
        Dim iValor As Double = 0
        If Me.TxtValor2.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtValor2.Text
        End If
        Me.TxtValor2.Text = Format(CDbl(iValor), "##,###,###0.00")
        If Val(TxtValor2.Text) = 0 Then
            TxtValor2.Text = ""
        End If
    End Sub

    Private Sub TxtValor2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtValor2.Enter
        Dim iValor As Double = 0
        If Me.TxtValor2.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtValor2.Text
        End If
        Me.TxtValor2.Text = Format(CDbl(iValor), "########0.00")
        If Val(TxtValor2.Text) = 0 Then
            TxtValor2.Text = ""
        End If
    End Sub

    Sub Formato() Handles CboTipo.SelectedIndexChanged
        Me.limpiar()
        If CboTipo.SelectedIndex = 0 Then
            Me.Panel1.Visible = False
            Me.Panel2.Visible = True
            Me.Panel1.TabStop = False
            Me.Panel2.TabStop = True
        Else
            Me.Panel1.Visible = True
            Me.Panel2.Visible = False
            Me.Panel1.TabStop = True
            Me.Panel2.TabStop = False

            TxtFactor.Text = "250.00"
        End If
    End Sub

    Sub limpiar()
        Me.TxtPeso.Text = ""
        Me.TxtVolumen.Text = ""
        Me.TxtSobre.Text = ""
        Me.TxtCostoBase.Text = "0.00"
        Me.TxtValor.Text = ""

        Me.TxtSobre2.Text = ""
        Me.TxtValor2.Text = ""
        Me.TxtAltura.Text = ""
        Me.TxtAncho.Text = ""
        Me.TxtLargo.Text = ""
        Me.TxtCostoBase2.Text = "0.00"
    End Sub

    Private Sub TxtSobre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSobre.KeyDown
        If e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub TxtPeso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPeso.KeyDown
        If e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub TxtVolumen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVolumen.KeyDown
        If e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub TxtValor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtValor.KeyDown
        If e.KeyCode = Keys.Down Then
            Me.TxtSobre.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub TxtSobre2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSobre2.KeyDown
        If e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub TxtValor2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtValor2.KeyDown
        If e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub TxtLargo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLargo.KeyDown
        If e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub TxtAncho_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAncho.KeyDown
        If e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub TxtAltura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAltura.KeyDown
        If e.KeyCode = Keys.Down Then
            Me.TxtSobre2.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Function ObtieneUnidad(ByVal unidad As Integer) As String
        Dim s As String = ""
        Select Case unidad
            Case 1
                s = "PESO"
            Case 2
                s = "VOLUMEN"
        End Select
        Return s
    End Function
    Function MontoCondicion(ByVal unidad As Integer, ByVal peso As Double, ByRef costo As Double) As Double
        Dim bCondicion As Boolean = False
        Dim iMonto As Double = 0, iDiferencia As Double = 0, iTotal As Double = 0
        For Each row As DataRow In dtCondicion.Rows
            If ObtieneUnidad(unidad) = row.Item("unidad") Then
                iMonto = row.Item("monto")
                If peso > 0 Then
                    If peso <= row.Item("fin") Then
                        iDiferencia = 0
                    Else
                        iDiferencia = peso - row.Item("fin")
                    End If
                    iTotal = iMonto + (iDiferencia * costo)
                    Exit For
                Else
                    iTotal = 0
                End If
            End If
        Next
        Return iTotal
    End Function

    Sub CalcularM3() ' Handles TxtSobre2.TextChanged, TxtValor2.TextChanged, TxtAltura.TextChanged, TxtAncho.TextChanged, TxtLargo.TextChanged
        Dim iSubnetoS As Double = Me.TxtSubNetoS2.Text
        Dim iSubnetoB As Double = Me.TxtSubNetoB2.Text
        Dim iSubnetoValor As Double = Me.TxtSubNetoValor2.Text
        Dim iSubNeto As Double = Convert.ToDouble(IIf(Val(Me.TxtSubNeto.Text) = 0, 0, Me.TxtSubNeto.Text))

        Dim iSub As Double = iSubnetoS + iSubnetoB + iSubnetoValor + iSubNeto

        Dim iSubtotalGeneral As Double = fnTECHO(Format(iSub, "0.00"))

        Dim iTotal As Double = iSubtotalGeneral
        Dim iSubtotal As Double = iTotal / 1.18
        Dim iImpuesto As Double = iSubtotal * 0.18

        Me.TxtSubtotal.Text = Format(iSubtotal, "###,###,###0.00")
        Me.TxtImpuesto.Text = Format(iImpuesto, "###,###,###0.00")
        Me.TxtTotal.Text = Format(iTotal, "###,###,###0.00")

    End Sub

    Sub Calcular()
        Dim iSubnetoP As Double = Me.TxtSubNetoP.Text
        Dim iSubnetoV As Double = Me.TxtSubNetoV.Text
        Dim iSubnetoS As Double = Me.TxtSubNetoS.Text
        Dim iSubnetoB As Double = Me.TxtSubNetoB.Text
        Dim iSubnetoValor As Double = Me.TxtSubNetoValor.Text

        Dim iSub As Double = iSubnetoP + iSubnetoV + iSubnetoS + iSubnetoB + iSubnetoValor
        Dim iSubtotalGeneral As Double = fnTECHO(Format(iSub, "0.00"))

        Dim iTotal As Double = iSubtotalGeneral
        Dim iSubtotal As Double = iTotal / 1.18
        Dim iImpuesto As Double = iSubtotal * 0.18

        Me.TxtSubtotal.Text = Format(iSubtotal, "###,###,###0.00")
        Me.TxtImpuesto.Text = Format(iImpuesto, "###,###,###0.00")
        Me.TxtTotal.Text = Format(iTotal, "###,###,###0.00")
    End Sub
End Class