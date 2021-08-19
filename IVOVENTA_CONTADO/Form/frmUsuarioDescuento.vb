Public Class frmUsuarioDescuento
    Dim strClave As String, strPatron As String
    Dim blnSalir As Boolean

    Private dblDescuento As Double

    Public llamada As Integer = 0

    Public Property Descuento() As Double
        Get
            Return dblDescuento
        End Get
        Set(ByVal value As Double)
            dblDescuento = value
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



    Private Sub frmUsuarioConfirmar_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmUsuarioConfirmar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        strClave = ""
        strPatron = ""

        GenerarClave()
        ListarUsuario()

        blnSalir = True
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.cboUsuario.SelectedValue = 0 Then
            MessageBox.Show("Seleccione el Usuario que autorizará la operación", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboUsuario.Focus()
            blnSalir = False
            Exit Sub
        End If
        If Me.txtClave.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese la Clave", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtClave.Text = ""
            Me.txtClave.Focus()
            blnSalir = False
            Exit Sub
        End If

        Validar()
    End Sub

    Sub Validar()
        Try
            Dim dblResultado As Double, dblClave As Double
            Dim obj As New MSScriptControl.ScriptControl
            obj.Language = "vbscript"

            Dim obj1 As New ClsLbTepsa.dtoGENERAL
            Dim strExpresion As String = obj1.ObtieneExpresion(Me.cboUsuario.SelectedValue, strClave)

            dblResultado = Format(CType(obj.Eval(strExpresion), Double), "0.00")

            dblClave = Me.txtClave.Text
            If dblResultado <> dblClave Then
                MessageBox.Show("La Clave es Errónea", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtClave.Text = Me.txtClave.Text.Trim
                Me.txtClave.Focus()
                blnSalir = False
            End If
        Catch ex As OverflowException
            blnSalir = False
            MessageBox.Show("Error en la Fórmula", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboUsuario.Focus()
        Catch ex As Exception
            blnSalir = False
            MessageBox.Show(ex.Message, "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboUsuario.Focus()
        End Try
    End Sub

    'Sub ValidarUsuario()
    '    Dim intRetorno As Integer
    '    Dim strMensaje As String
    '    Dim intUsuario As Integer
    '    Try
    '        If Me.cboUsuario.SelectedValue = 0 Then
    '            MessageBox.Show("Ingrese el Usuario", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Me.cboUsuario.Focus()
    '            blnSalir = False
    '            Exit Sub
    '        End If

    '        ' Valida el usuario con su respectiva clave y recupera el id del usuario '            
    '        Dim obj_general As New ClsLbTepsa.dtoGENERAL
    '        obj_general.ValidarUsuario(Me.txtUsuario.Text)
    '        intRetorno = obj_general.retorno
    '        If intRetorno > 0 Then
    '            strMensaje = obj_general.mensaje
    '            MessageBox.Show(strMensaje, "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Me.txtUsuario.Text = ""
    '            Me.txtUsuario.Focus()
    '            blnSalir = False
    '            Exit Sub
    '        End If
    '        intUsuario = obj_general.idusuario_personal

    '        'Verifica si usuario puede autorizar descuento
    '        Dim blnUsuarioDescuento As Boolean = obj_general.UsuarioDescuento(dtoUSUARIOS.IdLogin, Descuento)
    '        If Not blnUsuarioDescuento Then
    '            MessageBox.Show("El Usuario " & Me.txtUsuario.Text & " no está autorizado para aprobar el descuento", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Me.txtUsuario.Focus()
    '            Me.txtUsuario.SelectAll()
    '            blnSalir = False
    '            Exit Sub
    '        End If

    '        'Obtiene clave de usuario
    '        obj_general.ObtieneClave(intUsuario, dtoUSUARIOS.IP)
    '        intRetorno = obj_general.retorno
    '        If intRetorno > 0 Then
    '            strMensaje = obj_general.mensaje
    '            MessageBox.Show(strMensaje, "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Me.txtUsuario.Focus()
    '            Me.txtUsuario.SelectAll()
    '            blnSalir = False
    '            Exit Sub
    '        End If
    '        strClave = obj_general.clave
    '        strPatron = obj_general.patron

    '        Me.lblPatron.Text = strPatron
    '        Me.txtClave.Enabled = True
    '        Me.btnAceptar.Enabled = True
    '        Me.txtClave.Focus()

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End Try
    'End Sub

    'Private Sub txtUsuario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
    '    If Asc(e.KeyChar) = Keys.Enter Then
    '        ValidarUsuario()
    '        blnSalir = True
    '    End If
    'End Sub

    Private Sub txtContraseña_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            e.Handled = Not ValidarNumeroReal(e.KeyChar, txtClave.Text)
        End If
    End Sub

    Private Sub frmUsuarioDescuento_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.cboUsuario.Focus()
    End Sub

    Private Sub txtUsuario_TextChanged(sender As System.Object, e As System.EventArgs)
        Limpiar()
    End Sub

    Sub Limpiar()
        Me.lblPatron.Text = ""
        Me.txtClave.Text = ""
        Me.txtClave.Enabled = False
        Me.btnAceptar.Enabled = False
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        blnSalir = True
    End Sub

    Sub ListarUsuario()
        Dim obj As New ClsLbTepsa.dtoGENERAL
        With Me.cboUsuario
            .DisplayMember = "usuario"
            .ValueMember = "id"
            If llamada = 0 Then
                .DataSource = obj.ListarUsuario(Descuento, dtoUSUARIOS.iIDAGENCIAS, Venta)
            Else
                .DataSource = obj.ListarUsuario(1, dtoUSUARIOS.iIDAGENCIAS)
            End If
        End With
    End Sub

    Private Sub cboUsuario_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboUsuario.SelectedValueChanged
        Me.txtClave.Text = ""
        If cboUsuario.SelectedValue > 0 Then
            Me.txtClave.Enabled = True
            Me.btnAceptar.Enabled = True
            Me.txtClave.Focus()
        Else
            Me.txtClave.Enabled = False
            Me.btnAceptar.Enabled = False
        End If
    End Sub

    Sub GenerarClave()
        Try
            Dim obj_general As New ClsLbTepsa.dtoGENERAL
            Dim intRetorno As Integer
            Dim strMensaje As String

            'Obtiene clave de usuario
            obj_general.ObtieneClave()
            intRetorno = obj_general.retorno
            If intRetorno > 0 Then
                strMensaje = obj_general.mensaje
                MessageBox.Show(strMensaje, "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboUsuario.Focus()
                blnSalir = False
                Exit Sub
            End If
            strClave = obj_general.clave
            strPatron = obj_general.patron

            Me.lblPatron.Text = strPatron
            Me.txtClave.Enabled = True
            Me.btnAceptar.Enabled = True
            Me.txtClave.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cboUsuario_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboUsuario.SelectedIndexChanged

    End Sub
End Class