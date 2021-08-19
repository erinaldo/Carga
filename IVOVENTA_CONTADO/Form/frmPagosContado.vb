Imports System.Drawing
Public Class frmPagosContado

    Private Sub frmPagosContado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.txtPagoSoles.Focus()
    End Sub

    Private Sub frmPagosContado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Me.Opacity = 0.92
            txtSubTotal.Text = ObjVentaCargaContado.v_MONTO_SUB_TOTAL
            txtMontoImpuesto.Text = ObjVentaCargaContado.v_MONTO_IMPUESTO
            txtTotal.Text = ObjVentaCargaContado.v_TOTAL_COSTO

            txtPagoSoles.Focus()
        Catch ex As Exception
            txtSubTotal.Text = "0.00"
            txtMontoImpuesto.Text = "0.00"
            txtTotal.Text = "0.00"
        End Try
    End Sub
    Private Sub GroupBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Function fnGrillas() As Boolean
        Try
            'With dtGridViewpagos
            '    .AllowUserToAddRows = True
            '    .AllowUserToDeleteRows = True
            '    .AllowUserToOrderColumns = False
            '    .AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
            '    .BackgroundColor = SystemColors.Window
            '    .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            '    .ReadOnly = False
            '    .AutoGenerateColumns = False
            '    '.DataSource = dtable_Lista_Control_Comprobante
            '    .VirtualMode = False
            '    .SelectionMode = DataGridViewSelectionMode.CellSelect
            '    .RowHeadersWidth = 14
            '    .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            '    .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            '    .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            '    .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            'End With
            'Dim col As New DataGridViewTextBoxColumn
            'With col
            '    .DisplayIndex = 0
            '    .DataPropertyName = "var"
            '    .HeaderText = "ID"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = False
            'End With
            'dtGridViewpagos.Columns.Add(col)
            'Dim ColTargetas As New DataGridViewComboBoxColumn
            'Dim da As New OleDb.OleDbDataAdapter
            'Dim dt As New System.Data.DataTable
            'Dim dv As New System.Data.DataView

            'da.Fill(dt, ObjVentaCargaContado.fnTarjetas())
            'dv = dt.DefaultView
            'With ColTargetas
            '    .Name = "IDTARJETAS"
            '    .DataPropertyName = "IDTARJETAS"
            '    .HeaderText = "TARJETAS"
            '    .DataSource = dv
            '    .DisplayMember = "DESCRIPCION"
            '    .ValueMember = "IDTARJETAS"
            '    .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
            '    .Width = 130
            'End With
            'dtGridViewpagos.Columns.Add(ColTargetas)

            'Dim col2 As New DataGridViewComboBoxColumn
            'da.Fill(dt, ObjVentaCargaContado.fnTipoMonedas())
            'dv = dt.DefaultView
            'With col2
            '    .Name = "IDTIPO_MONEDA"
            '    .DataPropertyName = "IDTIPO_MONEDA"
            '    .HeaderText = "MONEDA"
            '    .DataSource = dv
            '    .ValueMember = "IDTIPO_MONEDA"
            '    .DisplayMember = "SIMBOLO_MONEDA"
            '    .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
            '    .Width = 80
            'End With
            'dtGridViewpagos.Columns.Add(col2)

            'Dim col3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            ''Dim col2 As New DataGridViewTextBoxColumn
            'With col3
            '    .DisplayIndex = 3
            '    .DataPropertyName = "MONTOAFECTO"
            '    .HeaderText = "MONTOAFECTO"
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    .ReadOnly = False
            'End With
            'dtGridViewpagos.Columns.Add(col3)

            'Dim col4 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            ''Dim col2 As New DataGridViewTextBoxColumn
            'With col4
            '    .DisplayIndex = 4
            '    .DataPropertyName = "DIFERENCIA"
            '    .HeaderText = "DIFERENCIA"
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    '.Mask = "####0.00"
            '    .ReadOnly = False
            'End With
            'dtGridViewpagos.Columns.Add(col4)

            'Dim col5 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            ''Dim col2 As New DataGridViewTextBoxColumn
            'With col5
            '    .DisplayIndex = 5
            '    .DataPropertyName = "MONTOAFECTO"
            '    .HeaderText = "MONTO AFECTO"
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    '.Mask = "####0.00"
            '    .ReadOnly = False
            'End With
            'dtGridViewpagos.Columns.Add(col5)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try

        Return False

    End Function
    Private Sub GroupBox2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox2.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub txtPagoSoles_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPagoSoles.Enter
        Me.txtPagoSoles.SelectAll()
    End Sub

    Private Sub txtPagoSoles_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPagoSoles.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub txtPagoSoles_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPagoSoles.TextChanged
        Try
            If Val(txtPagoSoles.Text) + Val(txtAfectoDolares.Text) > Val(txtTotal.Text) Then
                txtAfectoSoles.Text = Format(Val(txtTotal.Text) - Val(txtAfectoDolares.Text), "##,###,###.00")
                txtVuelto.Text = Format(Val(txtPagoSoles.Text) + Val(txtPagoDolares.Text) * Val(txtCambioDolares.Text) - Val(txtTotal.Text), "##,###,###.00")
                btnAceptar.Enabled = True
            ElseIf Val(txtPagoSoles.Text) + Val(txtAfectoDolares.Text) <= Val(txtTotal.Text) Then
                txtAfectoSoles.Text = Format(Val(txtPagoSoles.Text), "##,###,###.00")
                txtVuelto.Text = Format(Val(txtPagoSoles.Text) + Val(txtPagoDolares.Text) * Val(txtCambioDolares.Text) - Val(txtTotal.Text), "##,###,###.00")
                btnAceptar.Enabled = True
            End If
            'fnPagos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPagoDolares_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPagoDolares.Enter
        Me.txtPagoDolares.SelectAll()
    End Sub

    Private Sub txtPagoDolares_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPagoDolares.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub txtPagoDolares_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPagoDolares.TextChanged
        Try
            fnPagosDolares()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try

    End Sub
    Public Function fnPagosDolares() As Boolean
        Try
            If Val(txtPagoDolares.Text) * Val(txtCambioDolares.Text) + Val(txtAfectoSoles.Text) > Val(txtTotal.Text) Then
                txtAfectoDolares.Text = Format(Val(txtTotal.Text) - Val(txtAfectoSoles.Text), "##,###,###.00")
                txtVuelto.Text = Format(Val(txtPagoSoles.Text) + Val(txtPagoDolares.Text) * Val(txtCambioDolares.Text) - Val(txtTotal.Text), "##,###,###.00")
                btnAceptar.Enabled = True
            ElseIf Val(txtPagoDolares.Text) * Val(txtCambioDolares.Text) + Val(txtAfectoSoles.Text) <= Val(txtTotal.Text) Then
                txtAfectoDolares.Text = Format(Val(txtPagoDolares.Text) * Val(txtCambioDolares.Text), "##,###,###.00")
                txtVuelto.Text = Format(Val(txtPagoSoles.Text) + Val(txtPagoDolares.Text) * Val(txtCambioDolares.Text) - Val(txtTotal.Text), "##,###,###.00")
                btnAceptar.Enabled = True
            End If
            ' fnPagos()
        Catch ex As Exception

        End Try
        Return False
    End Function

    Private Sub txtCambioDolares_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCambioDolares.Enter
        Me.txtCambioDolares.SelectAll()
    End Sub

    Private Sub txtCambioDolares_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCambioDolares.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub
    Private Sub txtCambioDolares_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCambioDolares.TextChanged
        Try
            fnPagosDolares()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Function fnPagos() As Boolean
        Try
            txtAfectoSoles.Text = Val(txtTotal.Text) - Val(txtPagoSoles.Text)
            txtAfectoDolares.Text = Val(txtTotal.Text) - Val(txtAfectoSoles.Text) - Val(txtPagoDolares.Text) * Val(txtCambioDolares.Text)
            txtVuelto.Text = Val(txtTotal.Text) - (Val(txtAfectoSoles.Text) + Val(txtAfectoDolares.Text))
        Catch ex As Exception
        End Try
        Return False
    End Function
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        fnAceptar()
    End Sub
    Private Function fnAceptar() As Boolean
        Try
            If Val(txtAfectoSoles.Text) + Val(txtAfectoDolares.Text) <= 0 And Val(txtTotal.Text) <> 0 Then
                MsgBox("Ingrese Monto de Pago.", MsgBoxStyle.Information, "Seguridad Sistema")
                Me.txtPagoSoles.Focus()
                Return False
            End If

            If Val(txtVuelto.Text) < 0 Then
                MsgBox("El Monto de Pago es menor al Total de la Venta.", MsgBoxStyle.Information, "Seguridad Sistema")
                Me.txtPagoSoles.Focus()
                Return False
            End If
            If Val(txtPagoDolares.Text) > 0 Then
                If Val(txtCambioDolares.Text) < 3 And Val(txtCambioDolares.Text) > 4 Then
                    MsgBox("Ingrese Tipo de Cambio.", MsgBoxStyle.Information, "Seguridad Sistema")
                    Me.txtCambioDolares.Focus()
                    Return False
                End If
            End If
            ObjPagosSoles.v_idtipo_moneda = 1
            ObjPagosSoles.v_control = 1
            ObjPagosSoles.v_monto_cambio = 1
            ObjPagosSoles.v_monto_afecto = Val(txtAfectoSoles.Text)
            ObjPagosSoles.v_billete_pago = Val(txtPagoSoles.Text)
            ObjPagosSoles.v_diferencia_pago = ObjPagosSoles.v_billete_pago - ObjPagosSoles.v_monto_afecto
            ObjPagosDolares.v_idtipo_moneda = 2
            ObjPagosDolares.v_control = 1
            ObjPagosDolares.v_monto_cambio = Val(txtCambioDolares.Text)
            ObjPagosDolares.v_billete_pago = Val(txtPagoDolares.Text)
            ObjPagosDolares.v_monto_afecto = Val(txtAfectoDolares.Text)
            ObjPagosDolares.v_diferencia_pago = ObjPagosDolares.v_billete_pago * ObjPagosDolares.v_monto_cambio - ObjPagosDolares.v_monto_afecto
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
        FrmVentaContado.iTotalPagado = Val(txtPagoSoles.Text) + (Val(txtPagoDolares.Text) * Val(txtCambioDolares.Text))
        FrmVentaContado.iVuelto = txtVuelto.Text
        Return False
    End Function
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.Escape Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Close()
            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                fnAceptar()
            ElseIf msg.WParam.ToInt32 = Keys.Enter And Me.btnAceptar.Focused = False And Me.btnCancelar.Focused = False Then
                SendKeys.Send("{TAB}")
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return flat
    End Function
End Class