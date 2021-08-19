Public Class FrmConfiMensajeriaGiro
    Dim dv_movil As DataView
    Dim dv_mail As DataView
    Dim ObjMensajeria As New ClsLbTepsa.dtoMensajeria


    Private Sub FrmConfiMensajeria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ObjMensajeria.IDPERSONA = ObjVentaCargaContado.v_IDPERSONA


        'ObjMensajeria.IDPERSONA = 164122

        ObjMensajeria.FN_cmb_listar_tipo_comunicacion(Me.CBIDTIPO_COMUNICACION)
        CBIDTIPO_COMUNICACION.SelectedIndex = -1

        ObjMensajeria.FN_cmb_listar_tipo_comunicacion(Me.CBIDTIPO_COMUNICACION2)
        CBIDTIPO_COMUNICACION2.SelectedIndex = -1
        '
        ObjMensajeria.SP_SELEC_MOVIL_EMAIL_PERSOII(dv_mail, dv_movil)
        '
        If dv_mail.Count > 0 Then
            Me.TXTE_MAIL.Text = dv_mail.Table.Rows(0)("E_MAIL")
            If dv_mail.Count > 1 Then
                Me.TXTE_MAIL2.Text = dv_mail.Table.Rows(1)("E_MAIL")
            End If
        End If
        '
        If dv_movil.Count > 0 Then
            CBIDTIPO_COMUNICACION.SelectedValue = dv_movil.Table.Rows(0)("IDTIPO_COMUNICACION")
            Me.TXTNRO_MOVIL.Text = dv_movil.Table.Rows(0)("NRO_MOVIL")
            If dv_movil.Count > 1 Then
                CBIDTIPO_COMUNICACION2.SelectedValue = dv_movil.Table.Rows(1)("IDTIPO_COMUNICACION")
                Me.TXTNRO_MOVIL2.Text = dv_movil.Table.Rows(1)("NRO_MOVIL")
            End If
        End If




        If ObjMensajeria.envio_mensageria = 0 Then
            Me.RBENVIO_MENSAJERIA_DESAC.Checked = True
        End If
        If ObjMensajeria.envio_mensageria = 1 Then
            Me.RBENVIO_MENSAJERIA_ACTI.Checked = True
        End If

        Me.RBENVIO_MENSAJERIA_ACTI.Checked = True

        



    End Sub

    Private Sub RBENVIO_MENSAJERIA_DESAC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBENVIO_MENSAJERIA_DESAC.CheckedChanged
        If RBENVIO_MENSAJERIA_DESAC.Checked = True Then
            ObjMensajeria.envio_mensageria = 0
            'ObjMensajeria.SP_UP_SI_ENVIO_MENSAJERIA(cnn)
            ObjMensajeria.SP_UP_SI_ENVIO_MENSAJERIA()
        End If
    End Sub

    Private Sub RBENVIO_MENSAJERIA_ACTI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBENVIO_MENSAJERIA_ACTI.CheckedChanged
        If RBENVIO_MENSAJERIA_ACTI.Checked = True Then
            ObjMensajeria.envio_mensageria = 1
            '
            ObjMensajeria.SP_UP_SI_ENVIO_MENSAJERIA()
        End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub CBIDTIPO_COMUNICACION_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CBIDTIPO_COMUNICACION.KeyUp
        If e.KeyCode = Keys.Enter Then
            TXTNRO_MOVIL.Focus()
        End If
    End Sub

    Private Sub CBIDTIPO_COMUNICACION_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDTIPO_COMUNICACION.SelectedIndexChanged

    End Sub

    Private Sub CBIDTIPO_COMUNICACION_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDTIPO_COMUNICACION.SelectedValueChanged

    End Sub

    Private Sub BTNCANCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCE.Click
        Close()
    End Sub

    Private Sub BTNACEP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNACEP.Click

        ObjMensajeria.NRO_MOVIL = Me.TXTNRO_MOVIL.Text
        ObjMensajeria.E_MAIL = Me.TXTE_MAIL.Text

        If Not IsNothing(Me.CBIDTIPO_COMUNICACION.SelectedValue) Then
            If Len(Me.TXTNRO_MOVIL.Text.Trim) = 0 Then
                MsgBox("Ingrese un número...", MsgBoxStyle.Exclamation, "Segurdiad del Sistema...")
                Exit Sub
            End If

        End If

        If Not Len(Me.TXTNRO_MOVIL.Text.Trim) = 0 Then
            If IsNothing(Me.CBIDTIPO_COMUNICACION.SelectedValue) Then
                MsgBox("Seleccione el tipo de móvil...", MsgBoxStyle.Exclamation, "Segurdiad del Sistema...")
                Exit Sub
            End If

        End If

        If (Len(Me.TXTNRO_MOVIL.Text.Trim) = 0) And (Len(Me.TXTE_MAIL.Text.Trim) = 0) Then
            MsgBox("Ingrese un telefono o ingrese un mail...", MsgBoxStyle.Exclamation, "Segurdiad del Sistema...")
            Exit Sub
        End If

        If (IsNothing(Me.CBIDTIPO_COMUNICACION.SelectedValue)) And (Len(Me.TXTE_MAIL.Text.Trim) = 0) Then
            MsgBox("Ingrese un telefono o ingrese un mail...", MsgBoxStyle.Exclamation, "Segurdiad del Sistema...")
            Exit Sub
        End If

        If Not Len(Me.TXTNRO_MOVIL.Text.Trim) = 0 Then
            ObjMensajeria.NRO_MOVIL = Me.TXTNRO_MOVIL.Text.Trim
        Else
            ObjMensajeria.NRO_MOVIL = 0
        End If



        ObjMensajeria.IDESTADO_REGISTRO = 1

        ObjMensajeria.IDTIPO_MSG_MOVIL = 0
        If Not IsNothing(Me.CBIDTIPO_COMUNICACION.SelectedValue) Then
            ObjMensajeria.IDTIPO_COMUNICACION = Me.CBIDTIPO_COMUNICACION.SelectedValue
        Else
            ObjMensajeria.IDTIPO_COMUNICACION = 0
        End If

        ObjMensajeria.IDTIPO_MSG_MAIL = 1

        If Not Len(Me.TXTE_MAIL.Text.Trim) = 0 Then
            ObjMensajeria.E_MAIL = Me.TXTE_MAIL.Text.Trim
        Else
            ObjMensajeria.E_MAIL = 0
        End If






        ObjMensajeria.IDTIPO_COMUNICACION2 = Me.CBIDTIPO_COMUNICACION2.SelectedValue
        ObjMensajeria.NRO_MOVIL2 = Me.TXTNRO_MOVIL2.Text

        If Not IsNothing(Me.CBIDTIPO_COMUNICACION2.SelectedValue) Then
            If Len(Me.TXTNRO_MOVIL2.Text.Trim) = 0 Then
                ObjMensajeria.IDTIPO_COMUNICACION2 = 0
            End If
        End If

        If Not Len(Me.TXTNRO_MOVIL.Text.Trim) = 0 Then
            If IsNothing(Me.CBIDTIPO_COMUNICACION.SelectedValue) Then
                ObjMensajeria.IDTIPO_COMUNICACION2 = 0
            End If
        End If




        'segundo correo y movil
        ObjMensajeria.IDESTADO_REGISTRO = 1

        ObjMensajeria.IDTIPO_MSG_MOVIL = 0
        

        ObjMensajeria.IDTIPO_MSG_MAIL = 1

        If Not Len(Me.TXTE_MAIL2.Text.Trim) = 0 Then
            ObjMensajeria.E_MAIL2 = Me.TXTE_MAIL2.Text.Trim
        Else
            ObjMensajeria.E_MAIL2 = 0
        End If
        'datahelper
        ObjMensajeria.SP_UPDATE_MOVIL_EMAILII()
        Close()
    End Sub

    Private Sub TXTNRO_MOVIL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTNRO_MOVIL.GotFocus
        Me.TXTNRO_MOVIL.SelectionStart = 0
        Me.TXTNRO_MOVIL.SelectionLength = Len(TXTNRO_MOVIL.Text)
    End Sub

    Private Sub TXTNRO_MOVIL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTNRO_MOVIL.KeyUp
        If e.KeyCode = Keys.Enter Then
            TXTE_MAIL.Focus()
        End If
    End Sub

    Private Sub TXTNRO_MOVIL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTNRO_MOVIL.TextChanged

    End Sub

    Private Sub TXTE_MAIL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTE_MAIL.GotFocus

        Me.TXTE_MAIL.SelectionStart = 0
        Me.TXTE_MAIL.SelectionLength = Len(TXTE_MAIL.Text)
    End Sub

    Private Sub TXTE_MAIL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTE_MAIL.KeyUp
        If e.KeyCode = Keys.Enter Then
            BTNACEP.Focus()
        End If
    End Sub

    Private Sub TXTE_MAIL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTE_MAIL.TextChanged

    End Sub
End Class