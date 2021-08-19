Imports INTEGRACION_LN

Public Class frmProveedorOperacion
    Dim intOperacion As Operacion
    Dim blnInicio As Boolean
    Dim intLlamada As Integer = 0

    Private Sub frmProveedorOperacion_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        blnInicio = False
    End Sub

    Private Sub frmProveedorOperacion_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        blnInicio = True
        Inicio()

        dgvLista.AllowUserToDeleteRows = False
        dgvLista.AllowUserToDeleteRows = False
        dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLista.ReadOnly = True

        dgvLista.DataSource = Listar()
        dgvLista.Columns("id").Visible = False
        dgvLista.Columns("id_proveedor").Visible = False
        dgvLista.Columns("id_ciudad").Visible = False
        dgvLista.Columns("id_operacion").Visible = False

        If dgvLista.Rows.Count > 0 Then
            tsbEditar.Enabled = True
        Else
            tsbEditar.Enabled = False
        End If
    End Sub

    Function Listar() As DataTable
        Dim obj As New Cls_Gasto_LN
        Return obj.ListarProveedorOperacion(dtoUSUARIOS.m_idciudad)
    End Function

    Private Sub txtRucProveedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRucProveedor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtRucProveedor_LostFocus(Nothing, Nothing)
            If Me.txtRazonSocialProveedor.Enabled Then
                Me.txtRazonSocialProveedor.Focus()
            Else
                SendKeys.Send(vbTab)
            End If
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRucProveedor_LostFocus(sender As Object, e As System.EventArgs) Handles txtRucProveedor.LostFocus
        If Me.txtRucProveedor.Text.Trim.Length > 0 Then
            Dim intId As Integer = 0, strRazonSocial As String = "", strRuc As String
            strRuc = Me.txtRucProveedor.Text.Trim
            ListarProveedor(strRuc, intId, strRazonSocial)
            If intId > 0 Then
                Me.txtRucProveedor.Tag = intId
                Me.txtRazonSocialProveedor.Text = strRazonSocial
                Me.txtRazonSocialProveedor.Enabled = False
            ElseIf intLlamada = 0 Then
                Me.txtRucProveedor.Tag = ""
                Me.txtRazonSocialProveedor.Text = ""
                Me.txtRazonSocialProveedor.Enabled = True
                Me.txtRazonSocialProveedor.Focus()
            End If
        Else
            Me.txtRazonSocialProveedor.Focus()
        End If
    End Sub

    Private Sub txtRucProveedor_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRucProveedor.TextChanged
        Me.txtRazonSocialProveedor.Text = ""
        Me.txtRucProveedor.Tag = ""
        Me.txtRazonSocialProveedor.Enabled = True
    End Sub

    Private Sub txtRazonSocialProveedor_Enter(sender As Object, e As System.EventArgs) Handles txtRazonSocialProveedor.Enter
        txtRazonSocialProveedor.SelectAll()
    End Sub

    Private Sub txtRazonSocialProveedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazonSocialProveedor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

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

    Sub Limpiar()
        Me.lblCiudad.Text = dtoUSUARIOS.m_iNombreUnidadAgencia
        Me.cboOperacion.SelectedValue = 0
        Me.txtRucProveedor.Text = ""
        Me.txtRazonSocialProveedor.Text = ""
    End Sub

    Private Sub tsbGrabar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabar.Click
        Grabar()
    End Sub

    Sub Grabar()
        If Me.cboOperacion.SelectedValue = 0 Then
            MessageBox.Show("Seleccione la Operación", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboOperacion.DroppedDown = True
            Me.cboOperacion.Focus()
            Return
        End If

        Dim blnRucValido As Boolean = fnValidarRUC(txtRucProveedor.Text)
        intLlamada = 1
        Me.txtRucProveedor_LostFocus(Nothing, Nothing)
        intLlamada = 0
        If Not blnRucValido Then
            MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRucProveedor.Focus()
            Return
        End If

        If Me.txtRazonSocialProveedor.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Razón Social", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRazonSocialProveedor.Text = ""
            txtRazonSocialProveedor.Focus()
            Return
        End If

        Try
            Dim intConcepto As Integer, intId As Integer
            Dim intProveedor As Integer, strRuc As String, strRazonSocial As String
            If intOperacion = Operacion.Modificar Then
                intId = Me.dgvLista.CurrentRow.Cells("id").Value
            Else
                intId = 0
            End If
            intConcepto = Me.cboOperacion.SelectedValue
            intProveedor = IIf(IsNothing(Me.txtRucProveedor.Tag), 0, Val(Me.txtRucProveedor.Tag))
            strRuc = Me.txtRucProveedor.Text.Trim
            strRazonSocial = Me.txtRazonSocialProveedor.Text.Trim

            Dim obj As New Cls_Gasto_LN
            'obj.GrabarMovil(intId, dtoUSUARIOS.m_idciudad, strPlaca, intProveedor, strRuc, strRazonSocial)
            obj.GrabarProveedorOperacion(intId, intProveedor, strRuc, strRazonSocial, dtoUSUARIOS.m_idciudad, intConcepto, _
                                         dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            Me.Limpiar()
            intOperacion = Operacion.Nuevo
            Me.dgvLista.DataSource = Me.Listar()
            Me.tabProveedor.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
        intOperacion = Operacion.Nuevo
        blnInicio = True
        Me.Limpiar()
        tsbGrabar.Enabled = True
        Me.tsbEditar.Enabled = False
        tabProveedor.SelectedIndex = 1
        Me.cboOperacion.Enabled = True
        Me.cboOperacion.Focus()

    End Sub

    Private Sub tsbEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsbEditar.Click
        With dgvLista
            intOperacion = Operacion.Modificar
            blnInicio = False
            Me.lblCiudad.Text = dtoUSUARIOS.m_iNombreUnidadAgencia
            Me.cboOperacion.SelectedValue = .CurrentRow.Cells("id_operacion").Value

            Me.txtRucProveedor.Text = IIf(IsDBNull(.CurrentRow.Cells("ruc").Value), "", .CurrentRow.Cells("ruc").Value)
            Me.txtRucProveedor.Tag = IIf(.CurrentRow.Cells("id_proveedor").Value = 0, "", (.CurrentRow.Cells("id_proveedor").Value))
            Me.txtRazonSocialProveedor.Text = IIf(IsDBNull(.CurrentRow.Cells("proveedor").Value), "", .CurrentRow.Cells("proveedor").Value)
            Me.txtRazonSocialProveedor.Enabled = False
            Me.cboOperacion.Enabled = False

            tabProveedor.SelectedIndex = 1

            Me.tsbEditar.Enabled = False
            Me.cboOperacion.Focus()
        End With

    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub dgvLista_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvLista.DoubleClick
        If Me.dgvLista.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tabProveedor_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabProveedor.SelectedIndexChanged
        If tabProveedor.SelectedIndex = 0 Then
            Me.tsbNuevo.Enabled = True
            Me.tsbGrabar.Enabled = False
            If Me.dgvLista.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                Me.tsbAnular.Enabled = True
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
        Else
            Me.tsbNuevo.Enabled = False
            Me.tsbAnular.Enabled = False
            If Me.dgvLista.Rows.Count > 0 And blnInicio = False Then
                Me.tsbGrabar.Enabled = True
                Me.tsbEditar_Click(Nothing, Nothing)
            Else
                Me.tsbNuevo_Click(Nothing, Nothing)
            End If
        End If
        blnInicio = False

    End Sub

    Sub Inicio()
        Dim obj As New Cls_Gasto_LN
        Dim dt As DataTable = obj.InicioProveedor()

        With Me.cboOperacion
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Private Sub txtRazonSocialProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRazonSocialProveedor.TextChanged

    End Sub

    Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click

    End Sub
End Class