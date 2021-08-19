Imports INTEGRACION_LN
Imports INTEGRACION_EN

Enum TipoPersona
    JURIDICA = 0
    NATURAL = 1
End Enum
Public Class frmRegistrarCliente
    Dim intTipoPersona As TipoPersona
    Dim blnInicio As Boolean
    Dim blnSalir As Boolean
    Public strRuc As String = ""
    Public intTipoDocumento As Integer = 0

    Private Sub CboTipoDocumento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoDocumento.SelectedIndexChanged
        If blnInicio Then Return
        Me.txtNumero.Text = ""
        If Me.cboTipoDocumento.SelectedValue = 3 Then
            Me.txtNumero.MaxLength = 8
        ElseIf Me.cboTipoDocumento.SelectedValue = 9 Then
            'Me.txtNumero.Text = ""
            Me.txtNumero.Enabled = False
        Else
            Me.txtNumero.MaxLength = 20
        End If
        Me.txtNumero.Focus()
    End Sub

    Private Sub frmRegistrarCliente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmRegistrarCliente_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        blnInicio = True
        blnSalir = True
        Me.CboTipoPersona.SelectedIndex = 0

        Dim obj As New dtoVentaCargaContado
        Dim ds As New DataSet
        ds = obj.TipoDocumento()

        With cboTipoDocumento
            .DataSource = ds.Tables(0)
            .DisplayMember = "tipo_doc_identidad"
            .ValueMember = "idtipo_doc_identidad"
            If intTipoDocumento = 0 Then
                .SelectedValue = 1
            Else
                Me.CboTipoPersona.SelectedIndex = IIf(intTipoDocumento = 3, 1, 0)
                Me.CboTipoPersona.Enabled = False
                .SelectedValue = intTipoDocumento
            End If
        End With

        Me.txtNumero.Text = strRuc
    End Sub

    Private Sub frmRegistrarCliente_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        blnInicio = False
        Me.TxtCliente.Focus()
    End Sub

    Private Sub TxtNumero_Enter(sender As Object, e As System.EventArgs) Handles txtNumero.Enter
        txtNumero.SelectAll()
    End Sub

    Private Sub TxtNumero_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub TxtCliente_Enter(sender As Object, e As System.EventArgs) Handles TxtCliente.Enter
        TxtCliente.SelectAll()
    End Sub

    Private Sub TxtCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress
        If Me.CboTipoPersona.SelectedIndex = TipoPersona.JURIDICA Then
            If Not ValidarLetraNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetra(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtAPCliente_Enter(sender As Object, e As System.EventArgs) Handles TxtAPCliente.Enter
        TxtAPCliente.SelectAll()
    End Sub

    Private Sub TxtAPCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAPCliente.KeyPress
        If Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtAMCliente_Enter(sender As Object, e As System.EventArgs) Handles TxtAMCliente.Enter
        TxtAMCliente.SelectAll()
    End Sub

    Private Sub TxtAMCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAMCliente.KeyPress
        If Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim flat As Boolean = True
        If msg.WParam.ToInt32 = Keys.Enter Then
            If (Not Me.btnAceptar.Focused) And (Not Me.btnCancelar.Focused) Then
                SendKeys.Send(vbTab)
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
        Else
            flat = MyBase.ProcessCmdKey(msg, KeyData)
        End If
        Return flat
    End Function

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.CboTipoPersona.SelectedIndex = TipoPersona.JURIDICA Then
            If Me.TxtCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Razón Social del Cliente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCliente.Text = TxtCliente.Text.Trim()
                TxtCliente.Focus()
                blnSalir = False
                Return
            End If
        Else
            If Me.TxtCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombres del Cliente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCliente.Text = TxtCliente.Text.Trim()
                TxtCliente.Focus()
                blnSalir = False
                Return
            End If

            If Me.TxtAPCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Apellido Paterno", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtAPCliente.Text = TxtAPCliente.Text.Trim
                TxtAPCliente.Focus()
                blnSalir = False
                Return
            End If
        End If

        If Me.cboTipoDocumento.SelectedValue = 1 Then
            If Not fnValidarRUC(txtNumero.Text) Then
                MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Focus()
                blnSalir = False
                Return
            End If
        ElseIf Me.cboTipoDocumento.SelectedValue = 3 Then
            If txtNumero.Text.Trim.Length <> 8 Then
                MessageBox.Show("El DNI no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Text = txtNumero.Text.Trim
                txtNumero.Focus()
                blnSalir = False
                Return
            End If
        Else
            If Me.cboTipoDocumento.SelectedValue <> 9 AndAlso txtNumero.Text.Trim.Length < 6 Then
                MessageBox.Show("El Nº de Documento no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Text = txtNumero.Text.Trim
                txtNumero.Focus()
                blnSalir = False
                Return
            End If
        End If

        Dim obj As New dtrecojo
        Dim snum As String = Me.txtNumero.Text
        Dim ds As DataSet = obj.Listar_cli(snum)
        Dim resp As Integer = ds.Tables(0).Rows.Count
        If resp = 1 Then
            MessageBox.Show("EL Nº de Documento ya Existe", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNumero.Focus()
            blnSalir = False
            Return
        End If

        Grabar()
    End Sub

    Private Sub CboTipoPersona_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboTipoPersona.SelectedIndexChanged
        Me.txtNumero.Enabled = True
        Me.cboTipoDocumento.Enabled = False
        If Me.CboTipoPersona.SelectedIndex = TipoPersona.JURIDICA Then
            Me.cboTipoDocumento.SelectedValue = 1
            Me.cboTipoDocumento.Enabled = False
            Me.txtNumero.MaxLength = 11
            Me.LblCliente.Text = "Raz. Soc."
            Me.LblApep.Visible = False
            Me.LblApeM.Visible = False
            Me.TxtAPCliente.Visible = False
            Me.TxtAMCliente.Visible = False
            Me.LblCliente.Top = 68
            Me.TxtCliente.Top = 65
            Me.TxtAPCliente.Text = ""
            Me.TxtAMCliente.Text = ""
        Else
            Me.cboTipoDocumento.SelectedValue = 1
            Me.LblCliente.Text = "Nombres"
            Me.LblCliente.Top = 54
            Me.TxtCliente.Top = 51
            Me.LblApep.Visible = True
            Me.LblApeM.Visible = True
            Me.TxtAPCliente.Visible = True
            Me.TxtAMCliente.Visible = True
        End If
        Me.TxtCliente.Text = Me.TxtCliente.Text.Trim
        Me.TxtCliente.Focus()
    End Sub

    Sub Grabar()
        Try
            Dim objClienteLN As New Cls_Cliente_LN
            Dim objClienteEN As New Cls_Cliente_EN

            With objClienteEN
                .TipoPersona = IIf(Me.CboTipoPersona.SelectedIndex = TipoPersona.JURIDICA, 1, 2)
                .TipoDocumento = Me.cboTipoDocumento.SelectedValue
                .NumeroDocumento = Me.txtNumero.Text.Trim
                If Me.CboTipoPersona.SelectedIndex = TipoPersona.JURIDICA Then
                    .RazonSocial = Me.TxtCliente.Text.Trim
                Else
                    .Nombres = Me.TxtCliente.Text.Trim
                    .ApellidoPaterno = Me.TxtAPCliente.Text.Trim
                    .ApellidoMaterno = Me.TxtAMCliente.Text.Trim
                End If
                .Usuario = dtoUSUARIOS.IdLogin
                .IP = dtoUSUARIOS.IP

                objClienteLN.Grabar(.TipoPersona, .TipoDocumento, .NumeroDocumento, .RazonSocial, .Nombres, .ApellidoPaterno, _
                                    .ApellidoMaterno, .Usuario, .IP)

                MessageBox.Show("Cliente Registrado", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'FrmSolicitudClienteCarteraFuncionario.Cargar(Me.txtNumero.Text.Trim)
                FrmGestionCliente.Cargar(Me.txtNumero.Text.Trim)
            End With
        Catch ex As Exception
            blnSalir = False
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class