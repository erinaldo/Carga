Imports INTEGRACION_LN
Public Class frmTarifarioAutorizacionDetalle
    Dim utilData As New UtilData_LN
    Dim blnSalir As Boolean
    Public intModo As Integer

#Region "Propiedades"
    Private intOrigen As Integer
    Public Property Origen() As Integer
        Get
            Return intOrigen
        End Get
        Set(ByVal value As Integer)
            intOrigen = value
        End Set
    End Property
    Private intDestino As Integer
    Public Property Destino() As Integer
        Get
            Return intDestino
        End Get
        Set(ByVal value As Integer)
            intDestino = value
        End Set
    End Property
    Private intProducto As Integer
    Public Property Producto() As Integer
        Get
            Return intProducto
        End Get
        Set(ByVal value As Integer)
            intProducto = value
        End Set
    End Property
    Private intTipoTarifa As Integer
    Public Property TipoTarifa() As Integer
        Get
            Return intTipoTarifa
        End Get
        Set(ByVal value As Integer)
            intTipoTarifa = value
        End Set
    End Property
    Private intTipoVisibilidad As Integer
    Public Property TipoVisibilidad() As Integer
        Get
            Return intTipoVisibilidad
        End Get
        Set(ByVal value As Integer)
            intTipoVisibilidad = value
        End Set
    End Property
    Private dblPeso As Double
    Public Property Peso() As Double
        Get
            Return dblPeso
        End Get
        Set(ByVal value As Double)
            dblPeso = value
        End Set
    End Property
    Private dblVolumen As Double
    Public Property Volumen() As Double
        Get
            Return dblVolumen
        End Get
        Set(ByVal value As Double)
            dblVolumen = value
        End Set
    End Property
    Private dblSobre As Double
    Public Property Sobre() As Double
        Get
            Return dblSobre
        End Get
        Set(ByVal value As Double)
            dblSobre = value
        End Set
    End Property
    Private dblBase As Double
    Public Property Base() As Double
        Get
            Return dblBase
        End Get
        Set(ByVal value As Double)
            dblBase = value
        End Set
    End Property
    Private dblPesoMinimo As Double
    Public Property PesoMinimo() As Double
        Get
            Return dblPesoMinimo
        End Get
        Set(ByVal value As Double)
            dblPesoMinimo = value
        End Set
    End Property
    Private dblFleteMinimoPeso As Double
    Public Property FleteMinimoPeso() As Double
        Get
            Return dblFleteMinimoPeso
        End Get
        Set(ByVal value As Double)
            dblFleteMinimoPeso = value
        End Set
    End Property
    Private dblVolumenMinimo As Double
    Public Property VolumenMinimo() As Double
        Get
            Return dblVolumenMinimo
        End Get
        Set(ByVal value As Double)
            dblVolumenMinimo = value
        End Set
    End Property
    Private dblFleteVolumenMinimo As Double
    Public Property FleteVolumenMinimo() As Double
        Get
            Return dblFleteVolumenMinimo
        End Get
        Set(ByVal value As Double)
            dblFleteVolumenMinimo = value
        End Set
    End Property

#End Region

    Private Sub frmTarifarioAutorizacionDetalle_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmTarifarioAutorizacionDetalle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        utilData.cargarCombos("t_unidadAgencia", cboOrigen, True)
        utilData.cargarCombos(, cboDestino, True, cboOrigen.DataSource)
        utilData.cargarCombos("t_procesos", cboProducto)
        utilData.cargarCombos("t_tipotarifa", cboTipoTarifa)
        utilData.cargarTipoVisibilidad(cboTipoVisibilidad, False, 1)

        Me.cboOrigen.SelectedValue = dtoUSUARIOS.m_iIdUnidadAgenciaReal
        Me.cboProducto.Enabled = False
        Me.cboTipoVisibilidad.Enabled = False
        Me.cboProducto.SelectedValue = 8

        If intModo = 2 Then 'Modificar tarifa
            Me.cboOrigen.Enabled = False
            Me.cboDestino.Enabled = False
            Me.cboProducto.Enabled = False
            Me.cboTipoTarifa.Enabled = False
            Me.cboTipoVisibilidad.Enabled = False

            Me.cboOrigen.SelectedValue = Origen
            Me.cboDestino.SelectedValue = Destino
            Me.cboProducto.SelectedValue = Producto
            Me.cboTipoTarifa.SelectedIndex = TipoTarifa
            Me.cboTipoVisibilidad.SelectedIndex = TipoVisibilidad

            If Peso > 0 Then
                Me.txtPeso.Text = Format(Peso, "0.00")
            Else
                Me.txtPeso.Text = ""
            End If
            If Volumen > 0 Then
                Me.txtVolumen.Text = Format(Volumen, "0.00")
            Else
                Me.txtVolumen.Text = ""
            End If
            If Sobre > 0 Then
                Me.txtSobre.Text = Format(Sobre, "0.00")
            Else
                Me.txtSobre.Text = ""
            End If
            If Base > 0 Then
                Me.txtBase.Text = Format(Base, "0.00")
            Else
                Me.txtBase.Text = ""
            End If
            If PesoMinimo > 0 Then
                Me.txtPesoMinimo.Text = Format(PesoMinimo, "0.00")
            Else
                Me.txtPesoMinimo.Text = ""
            End If
            If VolumenMinimo > 0 Then
                Me.txtVolumenMinimo.Text = Format(VolumenMinimo, "0.00")
            Else
                Me.txtVolumenMinimo.Text = ""
            End If
            If FleteMinimoPeso > 0 Then
                Me.txtFleteMinimoPeso.Text = Format(FleteMinimoPeso, "0.00")
            Else
                Me.txtFleteMinimoPeso.Text = ""
            End If
            If FleteVolumenMinimo > 0 Then
                Me.txtFleteMinimoVolumen.Text = Format(FleteVolumenMinimo, "0.00")
            Else
                Me.txtFleteMinimoVolumen.Text = ""
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.cboOrigen.SelectedValue = -1 Then
            MessageBox.Show("Seleccion Origen", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboOrigen.Focus()
            Me.cboOrigen.DroppedDown = True
            blnSalir = False
            Return
        End If
        'If Me.cboDestino.SelectedValue = -1 Then
        '    MessageBox.Show("Seleccion Destino", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.cboDestino.Focus()
        '    Me.cboDestino.DroppedDown = True
        '    blnSalir = False
        '    Return
        'End If
        If Me.cboTipoTarifa.SelectedValue = -1 Then
            MessageBox.Show("Seleccion Tipo de Tarifa", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoTarifa.Focus()
            Me.cboTipoTarifa.DroppedDown = True
            blnSalir = False
            Return
        End If
        If Me.cboProducto.SelectedValue = -1 Then
            MessageBox.Show("Seleccion Producto", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboProducto.Focus()
            Me.cboProducto.DroppedDown = True
            blnSalir = False
            Return
        End If
        If Me.cboTipoVisibilidad.SelectedValue = 0 Then
            MessageBox.Show("Seleccion Tipo de Visibilidad", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoVisibilidad.Focus()
            Me.cboTipoVisibilidad.DroppedDown = True
            blnSalir = False
            Return
        End If

        If intModo = 0 Then
            'Verifica si tarifa ya existe
            Dim obj As New Cls_TarifaPublica_LN
            Dim blnExiste As Boolean = obj.ExisteTarifa(dtoUSUARIOS.m_idciudad, Me.cboOrigen.SelectedValue, Me.cboDestino.SelectedValue, _
                                                      Me.cboProducto.SelectedValue, Me.cboTipoTarifa.SelectedIndex, Me.cboTipoVisibilidad.SelectedIndex)
            If blnExiste Then
                MessageBox.Show("La Tarifa ya Existe", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboOrigen.Focus()
                blnSalir = False
                Return
            End If
        End If

        Dim blnExito As Boolean
        blnExito = Val(Me.txtPeso.Text) > 0 Or Val(Me.txtVolumen.Text) > 0 Or Val(Me.txtSobre.Text) > 0 Or Val(Me.txtBase.Text) > 0 Or _
                   Val(Me.txtPesoMinimo.Text) > 0 Or Val(Me.txtFleteMinimoPeso.Text) > 0 Or Val(Me.txtVolumenMinimo.Text) > 0 Or Val(Me.txtFleteMinimoVolumen.Text) > 0
        If Not blnExito Then
            MessageBox.Show("Ingrese la Tarifa", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPeso.Focus()
            Me.txtPeso.SelectAll()
            blnSalir = False
            Return
        End If
    End Sub

    Private Sub txtPeso_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeso.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtPeso.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPeso_LostFocus(sender As Object, e As System.EventArgs) Handles txtPeso.LostFocus
        If Val(Me.txtPeso.Text) > 0 Then
            Me.txtPeso.Text = Format(Convert.ToDouble(Me.txtPeso.Text), "0.00")
        Else
            Me.txtPeso.Text = ""
        End If
    End Sub

    Private Sub txtVolumen_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtVolumen.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtVolumen.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtVolumen_LostFocus(sender As Object, e As System.EventArgs) Handles txtVolumen.LostFocus
        If Val(Me.txtVolumen.Text) > 0 Then
            Me.txtVolumen.Text = Format(Convert.ToDouble(Me.txtVolumen.Text), "0.00")
        Else
            Me.txtVolumen.Text = ""
        End If
    End Sub

    Private Sub txtSobre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSobre.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtSobre.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSobre_LostFocus(sender As Object, e As System.EventArgs) Handles txtSobre.LostFocus
        If Val(Me.txtSobre.Text) > 0 Then
            Me.txtSobre.Text = Format(Convert.ToDouble(Me.txtSobre.Text), "0.00")
        Else
            Me.txtSobre.Text = ""
        End If
    End Sub

    Private Sub txtBase_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBase.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtBase.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtBase_LostFocus(sender As Object, e As System.EventArgs) Handles txtBase.LostFocus
        If Val(Me.txtBase.Text) > 0 Then
            Me.txtBase.Text = Format(Convert.ToDouble(Me.txtBase.Text), "0.00")
        Else
            Me.txtBase.Text = ""
        End If
    End Sub

    Private Sub txtPesoMinimo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPesoMinimo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtPesoMinimo.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPesoMinimo_LostFocus(sender As Object, e As System.EventArgs) Handles txtPesoMinimo.LostFocus
        If Val(Me.txtPesoMinimo.Text) > 0 Then
            Me.txtPesoMinimo.Text = Format(Convert.ToDouble(Me.txtPesoMinimo.Text), "0.00")
        Else
            Me.txtPesoMinimo.Text = ""
        End If
    End Sub

    Private Sub txtFleteMinimoPeso_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFleteMinimoPeso.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtFleteMinimoPeso.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtFleteMinimoPeso_LostFocus(sender As Object, e As System.EventArgs) Handles txtFleteMinimoPeso.LostFocus
        If Val(Me.txtFleteMinimoPeso.Text) > 0 Then
            Me.txtFleteMinimoPeso.Text = Format(Convert.ToDouble(Me.txtFleteMinimoPeso.Text), "0.00")
        Else
            Me.txtFleteMinimoPeso.Text = ""
        End If
    End Sub

    Private Sub txtVolumenMinimo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtVolumenMinimo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtVolumenMinimo.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtVolumenMinimo_LostFocus(sender As Object, e As System.EventArgs) Handles txtVolumenMinimo.LostFocus
        If Val(Me.txtVolumenMinimo.Text) > 0 Then
            Me.txtVolumenMinimo.Text = Format(Convert.ToDouble(Me.txtVolumenMinimo.Text), "0.00")
        Else
            Me.txtVolumenMinimo.Text = ""
        End If
    End Sub

    Private Sub txtFleteMinimoVolumen_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFleteMinimoVolumen.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtFleteMinimoVolumen.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtFleteMinimoVolumen_LostFocus(sender As Object, e As System.EventArgs) Handles txtFleteMinimoVolumen.LostFocus
        If Val(Me.txtFleteMinimoVolumen.Text) > 0 Then
            Me.txtFleteMinimoVolumen.Text = Format(Convert.ToDouble(Me.txtFleteMinimoVolumen.Text), "0.00")
        Else
            Me.txtFleteMinimoVolumen.Text = ""
        End If
    End Sub
End Class