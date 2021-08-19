Public Class FrmConfiMensajeria

#Region "Propiedades"
    Private intTipo As Integer
    Public Property Tipo() As Integer
        Get
            Return intTipo
        End Get
        Set(ByVal value As Integer)
            intTipo = value
        End Set
    End Property

    Private intComprobante As Integer
    Public Property Comprobante() As Integer
        Get
            Return intComprobante
        End Get
        Set(ByVal value As Integer)
            intComprobante = value
        End Set
    End Property
#End Region

    Dim ObjMensajeria As New ClsLbTepsa.dtoMensajeria
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmConfiMensajeria_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConfiMensajeria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'ObjMensajeria.IDPERSONA = ObjVentaCargaContado.v_IDPERSONA
            'ObjMensajeria.SP_SELEC_MOVIL_EMAIL_PERSO()
            'If ObjMensajeria.envio_mensageria = 0 Then
            'Me.rbtDesactivado.Checked = True
            'End If
            'If ObjMensajeria.envio_mensageria = 1 Then
            'Me.rbtActivado.Checked = True
            'End If
            Me.rbtActivado.Checked = True
            Me.txtNumero.Text = ObjMensajeria.NRO_MOVIL

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensajería", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub RBENVIO_MENSAJERIA_DESAC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDesactivado.CheckedChanged
        If rbtDesactivado.Checked = True Then
            Me.txtNumero.Text = ""
            Me.txtNumero.ReadOnly = False
            ObjMensajeria.envio_mensageria = 0
            ObjMensajeria.SP_UP_SI_ENVIO_MENSAJERIA()
            Me.txtNumero.MaxLength = 100
            Me.txtNumero.Focus()
            'Me.btnAceptar.Focus()
        End If
    End Sub
    Private Sub RBENVIO_MENSAJERIA_ACTI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtActivado.CheckedChanged
        If rbtActivado.Checked = True Then
            Me.txtNumero.Text = ""
            Me.txtNumero.ReadOnly = False
            ObjMensajeria.envio_mensageria = 1
            ObjMensajeria.SP_UP_SI_ENVIO_MENSAJERIA()
            Me.txtNumero.MaxLength = 12
            Me.txtNumero.Focus()
        End If
    End Sub
    'Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
    '    MyBase.OnPaint(e)
    '    Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
    '    Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
    '    e.Graphics.FillRegion(gradiente, New Region(rec))
    'End Sub

    Private Sub BTNACEP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'If rbtDesactivado.Checked Then
        'Close()
        'Exit Sub
        'End If

        ObjMensajeria.E_MAIL = ""
        If Me.rbtActivado.Checked Then
            If Len(Me.txtNumero.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese el Nº Móvil", "Envío de Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Focus()
                txtNumero.SelectAll()
                Exit Sub
            End If

            If Len(Me.txtNumero.Text.Trim) <> 9 Then
                MessageBox.Show("Ingrese un Nº Móvil válido", "Envío de Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Focus()
                txtNumero.SelectAll()
                Exit Sub
            End If

            Dim strNumero As String = Me.txtNumero.Text.Trim
            ObjMensajeria.GrabarNumeroSMS(Tipo, Comprobante, strNumero)
        Else
            If Len(Me.txtNumero.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese el Motivo del Cliente para no enviarle un SMS", "Envío de Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Focus()
                txtNumero.SelectAll()
                Exit Sub
            End If

            Dim strMotivo As String = Me.txtNumero.Text.Trim
            ObjMensajeria.GrabarSMSMotivo(Tipo, Comprobante, strMotivo)
        End If
        Close()

        'ObjMensajeria.NRO_MOVIL = Me.txtNumero.Text
        'ObjMensajeria.IDESTADO_REGISTRO = 1
        'ObjMensajeria.IDTIPO_MSG_MOVIL = 0
        'ObjMensajeria.IDTIPO_COMUNICACION = 0

        'ObjMensajeria.IDTIPO_MSG_MAIL = 1
        'ObjMensajeria.E_MAIL = ""

        'ObjMensajeria.SP_UPDATE_MOVIL_EMAIL()
        'Close()
    End Sub

    Private Sub TXTNRO_MOVIL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.GotFocus
        Me.txtNumero.SelectionStart = 0
        Me.txtNumero.SelectionLength = Len(txtNumero.Text)
    End Sub

    Private Sub TXTNRO_MOVIL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar

            If Me.rbtActivado.Checked Then
                If chr.IsDigit(chr) Then
                    e.Handled = False
                ElseIf chr.IsControl(chr) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Else
                If Not ValidarLetra(chr) Then
                    e.Handled = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TXTNRO_MOVIL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.btnAceptar.Focus()
        End If
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub
End Class