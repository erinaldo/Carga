Imports INTEGRACION_LN
Public Class frmCuentaContableDetalle
    Dim blnSalir As Boolean

#Region "Propiedad"
    Private intId As Integer
    Public Property Id() As Integer
        Get
            Return intId
        End Get
        Set(ByVal value As Integer)
            intId = value
        End Set
    End Property

    Private intVenta As Integer
    Public Property Venta() As Integer
        Get
            Return intVenta
        End Get
        Set(ByVal value As Integer)
            intVenta = value
        End Set
    End Property

    Private intConcepto As Integer
    Public Property Concepto() As Integer
        Get
            Return intConcepto
        End Get
        Set(ByVal value As Integer)
            intConcepto = value
        End Set
    End Property

    Private intTipoComprobante As Integer
    Public Property TipoComprobante() As Integer
        Get
            Return intTipoComprobante
        End Get
        Set(ByVal value As Integer)
            intTipoComprobante = value
        End Set
    End Property

    Private intTipoComprobante2 As Integer
    Public Property TipoComprobante2() As Integer
        Get
            Return intTipoComprobante2
        End Get
        Set(ByVal value As Integer)
            intTipoComprobante2 = value
        End Set
    End Property

    Private intSubtipo As Integer
    Public Property Subtipo As Integer
        Get
            Return intSubtipo
        End Get
        Set(ByVal value As Integer)
            intSubtipo = value
        End Set
    End Property

    Private intTipoAfectacion As Integer
    Public Property TipoAfectacion() As Integer
        Get
            Return intTipoAfectacion
        End Get
        Set(ByVal value As Integer)
            intTipoAfectacion = value
        End Set
    End Property

    Private intMoneda As Integer
    Public Property Moneda() As Integer
        Get
            Return intMoneda
        End Get
        Set(ByVal value As Integer)
            intMoneda = value
        End Set
    End Property

    Private strCuentaCliente As String
    Public Property CuentaCliente() As String
        Get
            Return strCuentaCliente
        End Get
        Set(ByVal value As String)
            strCuentaCliente = value
        End Set
    End Property

    Private strCuentaImpuesto As String
    Public Property CuentaImpuesto() As String
        Get
            Return strCuentaImpuesto
        End Get
        Set(ByVal value As String)
            strCuentaImpuesto = value
        End Set
    End Property

    Private strCuentaVenta As String
    Public Property CuentaVenta() As String
        Get
            Return strCuentaVenta
        End Get
        Set(ByVal value As String)
            strCuentaVenta = value
        End Set
    End Property

    Private strCuentaCosto As String
    Public Property CuentaCosto() As String
        Get
            Return strCuentaCosto
        End Get
        Set(ByVal value As String)
            strCuentaCosto = value
        End Set
    End Property

    Private strCuentaActividad As String
    Public Property CuentaActividad() As String
        Get
            Return strCuentaActividad
        End Get
        Set(ByVal value As String)
            strCuentaActividad = value
        End Set
    End Property

    Private intMovimientoCliente As Integer
    Public Property MovimientoCliente() As Integer
        Get
            Return intMovimientoCliente
        End Get
        Set(ByVal value As Integer)
            intMovimientoCliente = value
        End Set
    End Property

    Private intMovimientoImpuesto As Integer
    Public Property MovimientoImpuesto() As Integer
        Get
            Return intMovimientoImpuesto
        End Get
        Set(ByVal value As Integer)
            intMovimientoImpuesto = value
        End Set
    End Property

    Private intMovimientoVenta As Integer
    Public Property MovimientoVenta() As Integer
        Get
            Return intMovimientoVenta
        End Get
        Set(ByVal value As Integer)
            intMovimientoVenta = value
        End Set
    End Property

    Private intUsuario As Integer
    Public Property Usuario As Integer
        Get
            Return intUsuario
        End Get
        Set(ByVal value As Integer)
            intUsuario = value
        End Set
    End Property

    Private strIP As String
    Public Property Ip As String
        Get
            Return strIP
        End Get
        Set(ByVal value As String)
            strIP = value
        End Set
    End Property
#End Region

    Sub ListarTipoComprobante(ByVal concepto As Integer)
        Dim obj As New Cls_Contabilidad_LN
        Dim dt As DataTable = obj.ListarTipoComprobante(2, concepto)
        With Me.cboTipoComprobante
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Sub ListarSubtipo(ByVal concepto As Integer, ByVal tipo As Integer)
        Dim obj As New Cls_Contabilidad_LN
        Dim dt As DataTable = obj.ListarSubtipo(concepto, tipo)
        With Me.cboSubtipo
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Private Sub frmCuentaContableDetalle_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Cursor = Cursors.Default
    End Sub

    Private Sub frmCuentaContableDetalle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmCuentaContableDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            blnSalir = True
            If Id > 0 Then
                Me.cboVenta.Enabled = False
                Me.cboConcepto.Enabled = False
                Me.cboTipoComprobante.Enabled = False
                Me.cboSubtipo.Enabled = False
                Me.cboTipoAfectacion.Enabled = False
                Me.cboMoneda.Enabled = False

                Me.cboVenta.SelectedIndex = Venta
                Me.cboConcepto.SelectedIndex = Concepto

                Me.ListarTipoComprobante(Concepto)
                Me.cboTipoComprobante.SelectedValue = TipoComprobante

                Me.cboSubtipo.SelectedValue = Subtipo
                Me.cboTipoAfectacion.SelectedIndex = TipoAfectacion
                Me.cboMoneda.SelectedIndex = Moneda

                Me.txtCuentaCliente.Text = CuentaCliente
                Me.txtCuentaImpuesto.Text = CuentaImpuesto
                Me.txtCuentaVenta.Text = CuentaVenta

                Me.txtCuentaCosto.Text = CuentaCosto
                Me.txtCuentaActividad.Text = CuentaActividad

                If intMovimientoCliente = 1 Then
                    Me.rbtCargoCliente.Checked = True
                Else
                    Me.rbtAbonoCliente.Checked = True
                End If
                If intMovimientoImpuesto = 1 Then
                    Me.rbtCargoImpuesto.Checked = True
                Else
                    Me.rbtAbonoImpuesto.Checked = True
                End If
                If intMovimientoVenta = 1 Then
                    Me.rbtCargoVenta.Checked = True
                Else
                    Me.rbtAbonoVenta.Checked = True
                End If
                Me.btnGrabar.Focus()
            Else
                Me.cboVenta.SelectedIndex = 0
                Me.cboConcepto.SelectedIndex = 0
                Me.cboTipoComprobante.SelectedValue = 0
                Me.cboSubtipo.SelectedValue = 0
                Me.cboTipoAfectacion.SelectedIndex = 0
                Me.cboMoneda.SelectedIndex = 0
                Me.cboVenta.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Grabar()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Contabilidad_LN
            Venta = Me.cboVenta.SelectedIndex
            Concepto = Me.cboConcepto.SelectedIndex
            TipoComprobante = Me.cboTipoComprobante.SelectedValue
            Subtipo = IIf(Me.cboSubtipo.SelectedValue = 0, 0, Me.cboSubtipo.SelectedValue)
            TipoAfectacion = Me.cboTipoAfectacion.SelectedIndex
            Moneda = Me.cboMoneda.SelectedIndex
            CuentaCliente = Me.txtCuentaCliente.Text
            CuentaImpuesto = Me.txtCuentaImpuesto.Text
            CuentaVenta = Me.txtCuentaVenta.Text
            CuentaCosto = Me.txtCuentaCosto.Text
            CuentaActividad = Me.txtCuentaActividad.Text
            MovimientoCliente = IIf(Me.rbtCargoCliente.Checked, 1, 2)
            MovimientoImpuesto = IIf(Me.rbtCargoImpuesto.Checked, 1, 2)
            MovimientoVenta = IIf(Me.rbtCargoVenta.Checked, 1, 2)

            obj.GrabarCuentaContable(Id, Venta, Concepto, TipoComprobante, Subtipo, TipoAfectacion, Moneda, CuentaCliente, CuentaImpuesto, CuentaVenta, CuentaCosto, _
                                     CuentaActividad, MovimientoCliente, MovimientoImpuesto, MovimientoVenta, Usuario, Ip)
            Cursor = Cursors.Default
        Catch ex As Exception
            blnSalir = False
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Me.cboVenta.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Tipo de Venta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboVenta.Focus()
            Me.cboVenta.DroppedDown = True
            blnSalir = False
            Return
        End If

        If Me.cboConcepto.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Concepto", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboConcepto.Focus()
            Me.cboConcepto.DroppedDown = True
            blnSalir = False
            Return
        End If

        If Me.cboTipoComprobante.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Tipo de Comprobante", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoComprobante.Focus()
            Me.cboTipoComprobante.DroppedDown = True
            blnSalir = False
            Return
        End If

        If Me.cboTipoAfectacion.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Tipo de Afectación", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoAfectacion.Focus()
            Me.cboTipoAfectacion.DroppedDown = True
            blnSalir = False
            Return
        End If

        If Me.cboMoneda.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Moneda", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboMoneda.Focus()
            Me.cboMoneda.DroppedDown = True
            blnSalir = False
            Return
        End If

        If Me.txtCuentaCliente.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Cuenta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCuentaCliente.Focus()
            blnSalir = False
            Return
        End If

        If Me.txtCuentaImpuesto.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Cuenta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCuentaImpuesto.Focus()
            blnSalir = False
            Return
        End If

        If Me.txtCuentaVenta.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Cuenta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCuentaVenta.Focus()
            Return
        End If

        If Me.txtCuentaActividad.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Cuenta", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCuentaActividad.Focus()
            blnSalir = False
            Return
        End If

        If Not Me.rbtCargoCliente.Checked And Not Me.rbtAbonoCliente.Checked Then
            MessageBox.Show("Seleccione tipo de Movimiento", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.rbtCargoCliente.Focus()
            blnSalir = False
            Return
        End If

        If Not Me.rbtCargoImpuesto.Checked And Not Me.rbtAbonoImpuesto.Checked Then
            MessageBox.Show("Seleccione tipo de Movimiento", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.rbtCargoImpuesto.Focus()
            blnSalir = False
            Return
        End If

        If Not Me.rbtCargoVenta.Checked And Not Me.rbtAbonoVenta.Checked Then
            MessageBox.Show("Seleccione tipo de Movimiento", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.rbtCargoVenta.Focus()
            blnSalir = False
            Return
        End If

        Me.Grabar()
    End Sub

    Private Sub cboConcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboConcepto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboConcepto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboConcepto.SelectedIndexChanged
        Try
            Dim obj As New Cls_Contabilidad_LN
            Me.ListarTipoComprobante(Me.cboConcepto.SelectedIndex)

            Dim dt As DataTable = obj.ListarSubtipo(Me.cboConcepto.SelectedIndex, Me.cboTipoComprobante.SelectedValue)
            With Me.cboSubtipo
                .ValueMember = "id"
                .DisplayMember = "descripcion"
                .DataSource = dt
                Me.cboSubtipo.SelectedValue = 0
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboTipoComprobante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoComprobante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboTipoComprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoComprobante.SelectedIndexChanged
        Dim obj As New Cls_Contabilidad_LN
        Dim dt As DataTable = obj.ListarSubtipo(Me.cboConcepto.SelectedIndex, Me.cboTipoComprobante.SelectedValue)
        With Me.cboSubtipo
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = dt
            Me.cboSubtipo.SelectedValue = 0
        End With
    End Sub

    Private Sub txtCuentaCliente_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuentaCliente.Enter
        Me.txtCuentaCliente.SelectAll()
    End Sub

    Private Sub txtCuentaCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCuentaImpuesto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuentaImpuesto.Enter
        Me.txtCuentaImpuesto.SelectAll()
    End Sub

    Private Sub txtCuentaImpuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaImpuesto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCuentaVenta_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuentaVenta.Enter
        Me.txtCuentaVenta.SelectAll()
    End Sub

    Private Sub txtCuentaVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaVenta.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCuentaCosto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuentaCosto.Enter
        Me.txtCuentaCosto.SelectAll()
    End Sub

    Private Sub txtCuentaCosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaCosto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCuentaActividad_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuentaActividad.Enter
        Me.txtCuentaActividad.SelectAll()
    End Sub

    Private Sub txtCuentaActividad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaActividad.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cboVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVenta.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboSubtipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSubtipo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboTipoAfectacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoAfectacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMoneda.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub rbtCargoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbtCargoCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub rbtAbonoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbtAbonoCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub rbtCargoImpuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbtCargoImpuesto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub rbtAbonoImpuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbtAbonoImpuesto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub rbtCargoVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbtCargoVenta.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub rbtAbonoVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbtAbonoVenta.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtCuentaCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuentaCliente.TextChanged

    End Sub
End Class