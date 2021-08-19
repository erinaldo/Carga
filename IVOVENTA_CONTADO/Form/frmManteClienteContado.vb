Public Class frmManteClienteContado
    Public iPersonaContacto As Integer = 1
    Public cur_Movil As New ADODB.Recordset
    Public col_Movil As New Collection
    Dim ObjCTRL_MSG_CLIENTE As New dtoCTRL_MSG_CLIENTE
    Public hnd As Long

    Private Sub frmManteClienteContado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmManteClienteContado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.BackColor = Color.Chocolate
            Me.Opacity = 0.9
            If ObjManteClienteContado.v_idContacto = 0 Then
                ObjManteClienteContado.v_idContacto = ObjManteClienteContado.v_idpersona
            End If
            If ObjManteClienteContado.v_idContacto > 0 Or ObjManteClienteContado.v_idpersona > 0 Then
                'Mod.15/09/2009 -->Omendoza - Pasando al datahelper   
                If ObjManteClienteContado.fnListaContactoPersona() = True Then
                    'txtNroDoc.Text = ObjManteClienteContado.cur_datos.Fields.Item("Nrodocumento").Value
                    'txtNombres.Text = ObjManteClienteContado.cur_datos.Fields.Item("Nombres").Value
                    txtNroDoc.Text = ObjManteClienteContado.dt_cur_datos.Rows(0).Item("Nrodocumento")
                    txtNombres.Text = ObjManteClienteContado.dt_cur_datos.Rows(0).Item("Nombres")
                    txtDireccion.Text = ObjManteClienteContado.v_Direccion
                    'If ObjManteClienteContado.cur_datos.Fields.Item("Sexo").Value = "F" Then
                    If ObjManteClienteContado.dt_cur_datos.Rows(0).Item("Sexo") = "F" Then
                        rbMasculino.Checked = False
                        rbFemenino.Checked = True
                    Else
                        rbMasculino.Checked = True
                        rbFemenino.Checked = False
                    End If
                    '
                    'txtFechaNac.Text = ObjManteClienteContado.cur_datos.Fields.Item("Fecha_Nacimiento").Value
                    'txtTelefono.Text  = ObjManteClienteContado.cur_datos.Fields.Item("Telefono").Value
                    'txtProcentDescuento.Text = ObjManteClienteContado.cur_datos.Fields.Item("Porcentage_Descuento").Value
                    'ObjManteClienteContado.v_Facturacion = ObjManteClienteContado.cur_datos.Fields.Item("Facturacion").Value
                    '
                    txtFechaNac.Text = ObjManteClienteContado.dt_cur_datos.Rows(0).Item("Fecha_Nacimiento")
                    txtTelefono.Text = ObjManteClienteContado.dt_cur_datos.Rows(0).Item("Telefono")
                    txtProcentDescuento.Text = ObjManteClienteContado.dt_cur_datos.Rows(0).Item("Porcentage_Descuento")
                    ObjManteClienteContado.v_Facturacion = ObjManteClienteContado.dt_cur_datos.Rows(0).Item("Facturacion")
                    checkMontoBase.Checked = False
                    '
                    checkMontoBase.Text = "NO"
                    '   If ObjManteClienteContado.cur_datos.Fields.Item("Monto_Base").Value = 1 Then
                    If ObjManteClienteContado.dt_cur_datos.Rows(0).Item("Monto_Base") = 1 Then
                        checkMontoBase.Checked = True
                        checkMontoBase.Text = "SI"
                    End If
                    '
                    checkMovil.Checked = False
                    If ObjManteClienteContado.dt_cur_datos.Rows(0).Item("Envio_Mensageria") = 1 Then
                        'If ObjManteClienteContado.cur_datos.Fields.Item("Envio_Mensageria").Value = 1 Then
                        checkMovil.Checked = True
                    End If

                    'cur_Movil = ObjManteClienteContado.cur_datos.NextRecordset

                    ' ObjManteClienteContado.cur_celulares
                    ' ObjManteClienteContado.cur_E_Mail
                    '
                    'ObjManteClienteContado.cur_tipo_celulares = ObjManteClienteContado.cur_datos.NextRecordset()
                    'ObjManteClienteContado.cur_celulares = ObjManteClienteContado.cur_datos.NextRecordset()
                    'ObjManteClienteContado.cur_E_Mail = ObjManteClienteContado.cur_datos.NextRecordset()
                    '
                    'If ObjManteClienteContado.cur_tipo_celulares.EOF = False And ObjManteClienteContado.cur_tipo_celulares.BOF = False Then
                    '    If ObjManteClienteContado.cur_celulares.EOF = False And ObjManteClienteContado.cur_celulares.BOF = False Then
                    '        ObjCTRL_MSG_CLIENTE.v_Idtipo_Msg_Movil = ObjManteClienteContado.cur_celulares.Fields.Item("Idtipo_Msg_Movil").Value
                    '        ObjCTRL_MSG_CLIENTE.v_IDTIPO_COMUNICACION = ObjManteClienteContado.cur_celulares.Fields.Item("Idtipo_Comunicacion").Value
                    '        ObjCTRL_MSG_CLIENTE.v_NRO_MOVIL = ObjManteClienteContado.cur_celulares.Fields.Item("Nro_Movil").Value
                    '        ModuUtil.LlenarComboIDs(ObjManteClienteContado.cur_tipo_celulares, cmbMovil, col_Movil, ObjCTRL_MSG_CLIENTE.v_IDTIPO_COMUNICACION)
                    '        txCeltMovil.Text = ObjCTRL_MSG_CLIENTE.v_NRO_MOVIL
                    '    Else
                    '        ModuUtil.LlenarComboIDs(ObjManteClienteContado.cur_tipo_celulares, cmbMovil, col_Movil, 1)
                    '        txCeltMovil.Text = ""
                    '        ObjCTRL_MSG_CLIENTE.v_Idtipo_Msg_Movil = 0
                    '        ObjCTRL_MSG_CLIENTE.v_IDTIPO_COMUNICACION = 0
                    '        ObjCTRL_MSG_CLIENTE.v_NRO_MOVIL = "NULL"
                    '    End If
                    'End If

                    Try
                        If ObjManteClienteContado.dt_cur_tipo_celulares.Rows.Count > 0 Then
                            If ObjManteClienteContado.dt_cur_celulares.Rows.Count > 0 Then
                                ObjCTRL_MSG_CLIENTE.v_Idtipo_Msg_Movil = ObjManteClienteContado.dt_cur_celulares.Rows(0).Item("Idtipo_Msg_Movil")
                                ObjCTRL_MSG_CLIENTE.v_IDTIPO_COMUNICACION = ObjManteClienteContado.dt_cur_celulares.Rows(0).Item("Idtipo_Comunicacion")
                                ObjCTRL_MSG_CLIENTE.v_NRO_MOVIL = ObjManteClienteContado.dt_cur_celulares.Rows(0).Item("Nro_Movil")
                                ModuUtil.LlenarComboIDs_dt(ObjManteClienteContado.dt_cur_tipo_celulares, cmbMovil, col_Movil, ObjCTRL_MSG_CLIENTE.v_IDTIPO_COMUNICACION)
                                txCeltMovil.Text = ObjCTRL_MSG_CLIENTE.v_NRO_MOVIL
                            Else
                                ModuUtil.LlenarComboIDs_dt(ObjManteClienteContado.dt_cur_tipo_celulares, cmbMovil, col_Movil, 1)
                                txCeltMovil.Text = ""
                                ObjCTRL_MSG_CLIENTE.v_Idtipo_Msg_Movil = 0
                                ObjCTRL_MSG_CLIENTE.v_IDTIPO_COMUNICACION = 0
                                ObjCTRL_MSG_CLIENTE.v_NRO_MOVIL = "NULL"
                            End If
                        End If

                    Catch ex As Exception
                        ModuUtil.LlenarComboIDs_dt(ObjManteClienteContado.dt_cur_tipo_celulares, cmbMovil, col_Movil, 1)
                        txCeltMovil.Text = ""
                        ObjCTRL_MSG_CLIENTE.v_Idtipo_Msg_Movil = 0
                        ObjCTRL_MSG_CLIENTE.v_IDTIPO_COMUNICACION = 0
                        ObjCTRL_MSG_CLIENTE.v_NRO_MOVIL = "NULL"
                    End Try

                    '
                    Try
                        'If ObjManteClienteContado.cur_E_Mail.EOF = False And ObjManteClienteContado.cur_E_Mail.BOF = False Then
                        '    ObjCTRL_MSG_CLIENTE.v_E_MAIL = ObjManteClienteContado.cur_E_Mail.Fields.Item("E_MAIL").Value
                        '    ObjCTRL_MSG_CLIENTE.v_IDTIPO_MSG_MAIL = ObjManteClienteContado.cur_E_Mail.Fields.Item("Idtipo_Msg_Mail").Value
                        '    txtMail.Text = ObjCTRL_MSG_CLIENTE.v_E_MAIL
                        'Else
                        '    txtMail.Text = ""
                        '    ObjCTRL_MSG_CLIENTE.v_IDTIPO_MSG_MAIL = 0
                        '    ObjCTRL_MSG_CLIENTE.v_ENVIO_EMAIL = 0
                        'End If
                        If ObjManteClienteContado.dt_cur_E_Mail.Rows.Count > 0 Then
                            ObjCTRL_MSG_CLIENTE.v_E_MAIL = ObjManteClienteContado.dt_cur_E_Mail.Rows(0).Item("E_MAIL")
                            ObjCTRL_MSG_CLIENTE.v_IDTIPO_MSG_MAIL = ObjManteClienteContado.dt_cur_E_Mail.Rows(0).Item("Idtipo_Msg_Mail")
                            txtMail.Text = ObjCTRL_MSG_CLIENTE.v_E_MAIL
                        Else
                            txtMail.Text = ""
                            ObjCTRL_MSG_CLIENTE.v_IDTIPO_MSG_MAIL = 0
                            ObjCTRL_MSG_CLIENTE.v_ENVIO_EMAIL = 0
                        End If

                    Catch ex As Exception
                        txtMail.Text = ""
                        ObjCTRL_MSG_CLIENTE.v_IDTIPO_MSG_MAIL = 0
                        ObjCTRL_MSG_CLIENTE.v_ENVIO_EMAIL = 0
                    End Try

                    btnGrabar.Enabled = True
                End If

                If ObjManteClienteContado.v_idpersona > 0 Then
                    btnGrabar.Enabled = True
                End If

                If ObjManteClienteContado.v_idDireccion = 0 Then
                    txtDireccion.Enabled = False
                Else
                    txtDireccion.Enabled = True
                End If

                If iPersonaContacto = 1 Then
                    txtProcentDescuento.Enabled = True
                    'checkMontoBase.Enabled = True

                    ' Confirmaciones de Entrega
                    ObjCTRL_MSG_CLIENTE.v_IDPERSONA = ObjManteClienteContado.v_idpersona

                Else
                    txtProcentDescuento.Enabled = False
                    'checkMontoBase.Enabled = False
                End If


                'If ObjManteClienteContado.OgirenDestino = 1 Then

                'End If

                txtNroDoc.Focus()
                txtNroDoc.SelectAll()

            Else
                btnGrabar.Enabled = False
            End If

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Public Function fnGrabar() As Boolean

        Try
            ObjManteClienteContado.v_NroDoc = IIf(txtNroDoc.Text <> "", txtNroDoc.Text, "@")
            ObjManteClienteContado.v_Rason_Social = IIf(txtNombres.Text <> "", txtNombres.Text, "@")
            If rbMasculino.Checked = True Then
                ObjManteClienteContado.v_sexo = "M"
            Else
                ObjManteClienteContado.v_sexo = "F"
            End If
            ObjManteClienteContado.v_telefono = IIf(txtTelefono.Text <> "", txtTelefono.Text, "@")
            ObjManteClienteContado.v_fecha_nacimiento = IIf(txtFechaNac.Text <> "", txtFechaNac.Text, "@")
            ObjManteClienteContado.v_Direccion = Me.txtDireccion.Text
            ObjManteClienteContado.v_porcentage_descuento = Val(txtProcentDescuento.Text)

            ObjManteClienteContado.v_base = 1
            If checkMontoBase.Checked = False Then
                ObjManteClienteContado.v_base = 0
            End If

            If ObjManteClienteContado.fnManteClientes() = True Then

                ObjCTRL_MSG_CLIENTE.V_ICONTROL = 1
                ObjCTRL_MSG_CLIENTE.v_IDCTRL_MSG_CLIENTE = 0
                ObjCTRL_MSG_CLIENTE.v_IDPERSONA = ObjManteClienteContado.v_idpersona
                ObjCTRL_MSG_CLIENTE.v_IDPROCESOS = 20
                ObjCTRL_MSG_CLIENTE.v_IDESTADO_ENVIO = 21
                ObjCTRL_MSG_CLIENTE.v_ENVIO_MOVIL = 1
                ObjCTRL_MSG_CLIENTE.v_ENVIO_EMAIL = 1
                ObjCTRL_MSG_CLIENTE.v_ENVIO_CONSOLIDADO = 0

                '------------------------------------------------------------------------------

                If txCeltMovil.Text <> "" Then
                    ObjCTRL_MSG_CLIENTE.v_NRO_MOVIL = txCeltMovil.Text
                    ObjCTRL_MSG_CLIENTE.v_IDTIPO_COMUNICACION = Int(col_Movil.Item(cmbMovil.SelectedIndex.ToString()))
                Else
                    ObjCTRL_MSG_CLIENTE.v_Idtipo_Msg_Movil = 0
                    ObjCTRL_MSG_CLIENTE.v_NRO_MOVIL = "NULL"
                    ObjCTRL_MSG_CLIENTE.v_IDTIPO_COMUNICACION = Int(col_Movil.Item(cmbMovil.SelectedIndex.ToString()))
                End If
                
                '-------------------------------------------------------------------------------
                If txtMail.Text <> "" Then
                    'ObjCTRL_MSG_CLIENTE.v_IDTIPO_MSG_MAIL = 0
                    ObjCTRL_MSG_CLIENTE.v_E_MAIL = txtMail.Text
                Else
                    ObjCTRL_MSG_CLIENTE.v_IDTIPO_MSG_MAIL = 0
                    ObjCTRL_MSG_CLIENTE.v_E_MAIL = "NULL"
                End If

                If checkMovil.Checked = True Then
                    ObjCTRL_MSG_CLIENTE.v_IDESTADO_REGISTRO = 1
                Else
                    ObjCTRL_MSG_CLIENTE.v_IDESTADO_REGISTRO = 0
                End If
                Try
                    If ObjCTRL_MSG_CLIENTE.fnISNUP_CTRL_MSG_CLIENTE() Then

                    End If
                Catch ex As Exception

                End Try
                

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Close()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try

        Return False
    End Function
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.Enter Then
                'If rbMasculino.Checked = True Then
                '    rbFemenino.Focus()
                'Else
                '    SendKeys.Send("{Tab}")
                'End If
                SendKeys.Send("{Tab}")
            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                If Me.btnGrabar.Enabled Then
                    fnGrabar()
                End If
                ElseIf msg.WParam.ToInt32 = Keys.Escape Then
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Close()
                Else
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                End If

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Try
            If Me.txtMail.Text <> "" Then
                If (ValiadarEXP_REG_Mail(Me.txtMail.Text)) = False Then
                    MsgBox("No puede Realizar esta OPeracion, Direccion Electronica mal Escrita...", MsgBoxStyle.Information, "Seguridad Sistema")
                    ErrorProvider1.SetError(txtNombres, "Debe Ingresar Un Valor valido para el Nombre de Cliente")
                    Return
                End If
            End If

            If txtNombres.Text = "" Then
                ErrorProvider1.SetError(txtNombres, "Debe Ingresar Un Valor valido para el Nombre de Cliente")
                Return
            End If

            If txCeltMovil.Text <> "" Then
                If Int(col_Movil.Item(cmbMovil.SelectedIndex.ToString())) = 5 Then
                    If txCeltMovil.Text.Length <> 8 Then
                        MsgBox("Debe ingresar un nro valido de la forma: 000*0000 ", MsgBoxStyle.Information, "Seguridad Sistema")
                        Return
                    End If
                Else
                    If txCeltMovil.Text.Length <> 8 And txCeltMovil.Text.Length <> 9 And txCeltMovil.Text.Length <> 10 Then
                        MsgBox("Debe ingresar un nro valido...de 10 digitos cod.ciudad + nro celular", MsgBoxStyle.Information, "Seguridad Sistema")
                        Return
                    End If
                End If

            End If
            fnGrabar()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    '
    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDoc.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                'ElseIf e.KeyChar = "." Then
                'If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                'e.Handled = True
                'End If
                'ElseIf e.KeyChar = "-" Then
                'If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                'e.Handled = True
                'End If
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Private Sub DatosPersonalesboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombres.KeyPress, txtDistrito.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            If Not IsNumeric(e.KeyChar) And Char.IsLetter(e.KeyChar) Then
                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
              '  If e.KeyChar = " " Then
                    'ElseIf e.KeyChar = " " Then
                'If tb.Text.Substring(tb.Text.Length() - 1) = " " Then
                '    e.Handled = True
                'Else
                '    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                'End If
                ElseIf e.KeyChar = "." Then
                    If tb.Text.Substring(tb.Text.Length() - 1) = "." Then
                        e.Handled = True
                    Else
                        e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                    End If
                ElseIf e.KeyChar = "," Then
                    If tb.Text.Substring(tb.Text.Length() - 1) = "," Then
                        e.Handled = True
                    Else
                        e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                    End If
                ElseIf e.KeyChar = "@" Then
                    If tb.Text.Substring(tb.Text.Length() - 1) = "@" Then
                        e.Handled = True
                    Else
                        e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                    End If
                ElseIf e.KeyChar = "&" Then
                    If tb.Text.Substring(tb.Text.Length() - 1) = "&" Then
                        e.Handled = True
                    Else
                        e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                    End If
                ElseIf e.KeyChar = "-" Then
                    If tb.Text.Substring(tb.Text.Length() - 1) = "-" Then
                        e.Handled = True
                    Else
                        e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                    End If
                ElseIf e.KeyChar = "'" Then
                    e.Handled = True
                    'ElseIf Not Char.IsControl(e.KeyChar) Then
                    '    e.Handled = True
                End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub checkMontoBase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkMontoBase.CheckedChanged
        Try
            If checkMontoBase.Checked = False Then
                checkMontoBase.Text = "NO"
            Else
                checkMontoBase.Text = "SI"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Dim bIngreso As Boolean = False
End Class