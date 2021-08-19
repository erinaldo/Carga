Imports MSScriptControl
Public Class frmUsuarioClave
    Public hnd As Long
    Dim blnExito As Boolean
    Dim strClave As String, strPatron As String

    Private Sub txtClave_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            e.Handled = Not ValidarClave(e.KeyChar)
        End If
    End Sub

    Private Sub txtClave_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClave.TextChanged
        Me.btnAceptar.Enabled = Me.txtClave.Text.Length > 0
        blnExito = False
    End Sub

    Function ClaveValida(clave As String) As Boolean
        Dim strNumero As Char, strOperador As Char
        Dim i As Integer

        i = 0
        Do While i < clave.Length - 1
            strNumero = clave.Substring(i, 1)
            strOperador = clave.Substring(i + 1, 1)

            If Not IsNumeric(strNumero) Then
                Return False
            End If
            If Not (strOperador = "+" Or strOperador = "-" Or strOperador = "*" Or strOperador = "/") Then
                Return False
            End If
            i += 2
        Loop
        If i = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New MSScriptControl.ScriptControl
            obj.Language = "vbscript"

            Dim strClave As String = Me.txtClave.Text.Trim
            Dim dblResultado As Double

            Dim objResultado As Object = obj.Eval(strClave)

            Dim blnClaveValida As Boolean = ClaveValida(strClave)
            If Not blnClaveValida Then
                Cursor = Cursors.Default
                MessageBox.Show("Clave Errónea", "Clave", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtClave.Text = Me.txtClave.Text.Trim
                Me.txtClave.Focus()
                Me.txtClave.SelectAll()
                Return
            End If

            Grabar

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show("Clave Errónea", "Clave", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtClave.Text = Me.txtClave.Text.Trim
            Me.txtClave.Focus()
            Me.txtClave.SelectAll()
        Finally
            Cursor = Cursors.Default
        End Try



        'Cursor = Cursors.WaitCursor
        'Dim xlApp As New Excel.Application()
        'Dim xlBook As Excel.Workbook
        'Dim xlSheet As Excel.Worksheet

        'Try
        '    Dim strClave As String = Me.txtClave.Text.Trim
        '    Dim dblResultado As Double

        '    xlBook = xlApp.Workbooks().Add
        '    xlSheet = xlBook.Worksheets("hoja1")

        '    xlSheet.Cells(1, 1) = "=" & strClave
        '    'xlSheet.Columns.NumberFormat = "0.00"
        '    dblResultado = xlSheet.Range("A1").Value
        '    xlBook.Close(False)

        '    Dim blnClaveValida As Boolean = ClaveValida(strClave)
        '    If Not blnClaveValida Then
        '        Cursor = Cursors.Default
        '        MessageBox.Show("Clave Errónea", "Clave", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Me.txtClave.Text = Me.txtClave.Text.Trim
        '        Me.txtClave.Focus()
        '        Me.txtClave.SelectAll()
        '        Return
        '    End If

        '    Grabar()

        'Catch ex As Exception
        '    Cursor = Cursors.Default
        '    MessageBox.Show("Clave Errónea", "Clave", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.txtClave.Text = Me.txtClave.Text.Trim
        '    Me.txtClave.Focus()
        '    Me.txtClave.SelectAll()
        'Finally
        '    Cursor = Cursors.Default
        '    xlSheet = Nothing
        '    xlBook = Nothing
        '    xlApp.Quit()
        '    xlApp = Nothing
        'End Try
    End Sub

    Sub Grabar()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New ClsLbTepsa.dtoGENERAL
            obj.GrabarPatron(dtoUSUARIOS.IdLogin, Me.txtClave.Text.Trim)
            Cursor = Cursors.Default
            blnExito = True
            MessageBox.Show("Clave Actualizada", "Clave", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnCancelar.Focus()

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Clave", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Listar()
        Try
            Dim obj As New ClsLbTepsa.dtoGENERAL
            Dim dt As DataTable = obj.ListarPatron(dtoUSUARIOS.IdLogin)

            Me.txtClave.Text = dt.Rows(0).Item(0).ToString
            blnExito = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Clave", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub frmUsuarioClave_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        blnExito = False
        strClave = ""
        strPatron = ""
        Me.lblUsuario.Text = dtoUSUARIOS.iLOGIN
        Listar()
    End Sub

    Private Sub tabClave_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabClave.SelectedIndexChanged
        If tabClave.SelectedIndex = 1 Then
            If blnExito Then
                Me.lblClave.Text = Me.txtClave.Text
                Me.txtPatron.Enabled = True
                Me.btnGenerar.Enabled = True
                btnGenerar_Click(Nothing, Nothing)
                Me.txtPatron.Focus()
            Else
                Me.txtPatron.Enabled = False
                Me.btnGenerar.Enabled = False
            End If
        End If
    End Sub

    Private Sub txtPatron_Enter(sender As Object, e As System.EventArgs) Handles txtPatron.Enter
        Me.txtPatron.SelectAll()
    End Sub

    Private Sub txtPatron_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPatron.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            e.Handled = Not ValidarNumeroReal(e.KeyChar, txtPatron.Text)
        End If
    End Sub

    Private Sub txtPatron_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPatron.TextChanged
        Me.btnProbar.Enabled = Me.txtPatron.Text.Length > 0
    End Sub

    Private Sub btnCancelar2_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar2.Click
        tabClave.SelectedIndex = 0
    End Sub

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
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
                Exit Sub
            End If
            strClave = obj_general.clave
            strPatron = obj_general.patron
            Me.lblPatron.Text = strPatron

            Me.txtPatron.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try


        'Dim obj_general As New ClsLbTepsa.dtoGENERAL

        'obj_general.ObtieneClave(dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
        'strClave = obj_general.clave
        'strPatron = obj_general.patron

        'Me.lblPatron.Text = strPatron
    End Sub

    Private Sub btnProbar_Click(sender As System.Object, e As System.EventArgs) Handles btnProbar.Click
        Try
            Dim dblResultado As Double, dblClave As Double
            Dim obj As New MSScriptControl.ScriptControl
            obj.Language = "vbscript"

            Dim obj1 As New ClsLbTepsa.dtoGENERAL
            Dim strExpresion As String = obj1.ObtieneExpresion(dtoUSUARIOS.IdLogin, strClave)

            dblResultado = Format(CType(obj.Eval(strExpresion), Double), "0.00")

            dblClave = Me.txtPatron.Text
            If dblResultado <> dblClave Then
                MessageBox.Show("La Clave es Errónea", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtPatron.Focus()
                Me.txtPatron.SelectAll()
            Else
                MessageBox.Show("La Clave es Correcta", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtPatron.Focus()
                Me.txtPatron.SelectAll()
            End If

        Catch ex As OverflowException
            MessageBox.Show("Error en la Fórmula", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tabClave.SelectedIndex = 0
            Me.txtClave.Focus
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPatron.Focus()
        End Try
    End Sub

    Private Sub frmUsuarioClave_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.txtClave.Focus()
    End Sub
End Class