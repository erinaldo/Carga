Imports INTEGRACION_LN

Public Class frmMovil
    Dim intOperacion As Operacion
    Dim blnInicio As Boolean
    Dim intLlamada As Integer = 0

    Private Sub frmMovil_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        blnInicio = False
    End Sub

    Private Sub frmMovil_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Text = "Móvil - " & dtoUSUARIOS.m_iNombreUnidadAgencia

        blnInicio = True
        dgvMovil.AllowUserToDeleteRows = False
        dgvMovil.AllowUserToDeleteRows = False
        dgvMovil.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMovil.ReadOnly = True

        dgvMovil.DataSource = Listar()
        'dgvMovil.Columns("id_proveedor").Visible = False

        If dgvMovil.Rows.Count > 0 Then
            tsbEditar.Enabled = True
        Else
            tsbEditar.Enabled = False
        End If
    End Sub

    Function Listar() As DataTable
        Dim obj As New Cls_Reparto_LN
        Return obj.ListarMovil(dtoUSUARIOS.m_idciudad)
    End Function

    Private Sub tsbEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsbEditar.Click
        With dgvMovil
            intOperacion = Operacion.Modificar
            blnInicio = False
            Me.lblCiudad.Text = dtoUSUARIOS.m_iNombreUnidadAgencia
            Me.TxtNumero.Text = .CurrentRow.Cells("numero").Value
            Me.txtPlaca.Text = .CurrentRow.Cells("placa").Value

            'Me.txtRucProveedor.Text = IIf(IsDBNull(.CurrentRow.Cells("ruc").Value), "", .CurrentRow.Cells("ruc").Value)
            'Me.txtRucProveedor.Tag = IIf(.CurrentRow.Cells("id_proveedor").Value = 0, "", (.CurrentRow.Cells("id_proveedor").Value))
            'Me.txtRazonSocialProveedor.Text = IIf(IsDBNull(.CurrentRow.Cells("proveedor").Value), "", .CurrentRow.Cells("proveedor").Value)
            'Me.txtRazonSocialProveedor.Enabled = False

            tabMovil.SelectedIndex = 1

            Me.tsbEditar.Enabled = False
            Me.txtPlaca.Focus()
        End With
    End Sub

    Private Sub dgvMovil_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvMovil.DoubleClick
        If Me.dgvMovil.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
        intOperacion = Operacion.Nuevo
        blnInicio = True
        Me.limpiar()
        tsbGrabar.Enabled = True
        Me.tsbEditar.Enabled = False
        tabMovil.SelectedIndex = 1
        Me.txtPlaca.Focus()
    End Sub

    Sub Limpiar()
        Me.lblCiudad.Text = dtoUSUARIOS.m_iNombreUnidadAgencia
        Me.TxtNumero.Text = ""
        Me.txtPlaca.Text = ""
    End Sub

    Private Sub txtPlaca_Enter(sender As Object, e As System.EventArgs) Handles txtPlaca.Enter
        txtPlaca.SelectAll()
    End Sub

    Private Sub txtPlaca_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlaca.KeyPress
        If (e.KeyChar = Chr(13)) Then
            'SendKeys.Send(vbTab)
            Grabar()
        Else
            If e.KeyChar = "-" Then
                e.Handled = True
            End If
        End If
    End Sub

    Sub Grabar()
        If Me.txtPlaca.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Nº de Placa", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPlaca.Focus()
            Return
        End If

        'Dim blnRucValido As Boolean = fnValidarRUC(txtRucProveedor.Text)
        'intLlamada = 1
        'Me.txtRucProveedor_LostFocus(Nothing, Nothing)
        'intLlamada = 0
        'If Not blnRucValido Then
        '    MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtRucProveedor.Focus()
        '    Return
        'End If

        'If Me.txtRazonSocialProveedor.Text.Trim.Length = 0 Then
        '    MessageBox.Show("Ingrese Razón Social", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtRazonSocialProveedor.Text = ""
        '    txtRazonSocialProveedor.Focus()
        '    Return
        'End If

        Try
            Dim strPlaca As String, intId As Integer
            Dim intProveedor As Integer, strRuc As String, strRazonSocial As String
            If intOperacion = Operacion.Modificar Then
                intId = Me.dgvMovil.CurrentRow.Cells("numero").Value
            Else
                intId = 0
            End If
            strPlaca = Me.txtPlaca.Text.Trim
            'intProveedor = IIf(IsNothing(Me.txtRucProveedor.Tag), 0, Val(Me.txtRucProveedor.Tag))
            'strRuc = Me.txtRucProveedor.Text.Trim
            'strRazonSocial = Me.txtRazonSocialProveedor.Text.Trim


            Dim obj As New Cls_Reparto_LN
            'obj.GrabarMovil(intId, dtoUSUARIOS.m_idciudad, strPlaca, intProveedor, strRuc, strRazonSocial)
            obj.GrabarMovil(intId, dtoUSUARIOS.m_idciudad, strPlaca)
            Me.Limpiar()
            intOperacion = Operacion.Nuevo
            Me.dgvMovil.DataSource = Me.Listar()
            Me.tabMovil.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbGrabar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabar.Click
        Grabar()
    End Sub

    Private Sub tabMovil_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabMovil.SelectedIndexChanged
        If tabMovil.SelectedIndex = 0 Then
            Me.tsbNuevo.Enabled = True
            Me.tsbGrabar.Enabled = False
            If Me.dgvMovil.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                Me.tsbAnular.Enabled = True
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
        Else
            Me.tsbNuevo.Enabled = False
            Me.tsbAnular.Enabled = False
            If Me.dgvMovil.Rows.Count > 0 And blnInicio = False Then
                Me.tsbGrabar.Enabled = True
                Me.tsbEditar_Click(Nothing, Nothing)
            Else
                Me.tsbNuevo_Click(Nothing, Nothing)
            End If
        End If
        blnInicio = False
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    'Private Sub txtRucProveedor_Enter(sender As Object, e As System.EventArgs)
    '    txtRucProveedor.SelectAll()
    'End Sub

    'Private Sub txtRucProveedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
    '    If Asc(e.KeyChar) = Keys.Enter Then
    '        txtRucProveedor_LostFocus(Nothing, Nothing)
    '        If Me.txtRazonSocialProveedor.Enabled Then
    '            Me.txtRazonSocialProveedor.Focus()
    '        End If
    '    ElseIf Not ValidarNumero(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub txtRazonSocialProveedor_Enter(sender As Object, e As System.EventArgs)
    '    txtRazonSocialProveedor.SelectAll()
    'End Sub

    'Private Sub txtRazonSocialProveedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
    '    If Asc(e.KeyChar) = Keys.Enter Then
    '        'Grabar
    '    End If
    'End Sub

    Sub ListarProveedor(ruc As String, ByRef id As Integer, ByRef razon_social As String)
        Try
            Dim obj As New Cls_Gasto_LN

            Dim dt As DataTable = obj.ListarProveedor(ruc)
            If dt.Rows.Count > 0 Then
                id = dt.Rows(0).Item("id").ToString
                razon_social = dt.Rows(0).Item("proveedor").ToString
            Else
                id = 0
                razon_social = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Buscar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub txtRucProveedor_LostFocus(sender As Object, e As System.EventArgs)
    '    If Me.txtRucProveedor.Text.Trim.Length > 0 Then
    '        Dim intId As Integer = 0, strRazonSocial As String = "", strRuc As String
    '        strRuc = Me.txtRucProveedor.Text.Trim
    '        ListarProveedor(strRuc, intId, strRazonSocial)
    '        If intId > 0 Then
    '            Me.txtRucProveedor.Tag = intId
    '            Me.txtRazonSocialProveedor.Text = strRazonSocial
    '            Me.txtRazonSocialProveedor.Enabled = False
    '            'Me.txtObservacionReparto.Focus()
    '        ElseIf intLlamada = 0 Then
    '            Me.txtRucProveedor.Tag = ""
    '            Me.txtRazonSocialProveedor.Text = ""
    '            Me.txtRazonSocialProveedor.Enabled = True
    '        End If
    '    Else
    '        Me.txtRazonSocialProveedor.Focus()
    '    End If
    'End Sub

    'Private Sub txtRucProveedor_TextChanged(sender As System.Object, e As System.EventArgs)
    '    Me.txtRazonSocialProveedor.Text = ""
    '    Me.txtRucProveedor.Tag = ""
    '    Me.txtRazonSocialProveedor.Enabled = True
    'End Sub

    Private Sub tsbAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsbAnular.Click

    End Sub
End Class