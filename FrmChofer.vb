
Public Class FrmChofer
    Dim action As Integer
    Dim blnInicio As Boolean
    Public hnd As Long
    Dim bIngreso As Boolean

    Private Sub NuevoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        action = 1
        blnInicio = True
        Me.limpiar()
        btnGuardar.Enabled = True
        Me.EditarToolStripMenuItem.Enabled = False
        tabChofer.SelectedIndex = 1
        Me.txtAP.Focus()
    End Sub

    Sub Limpiar()
        Me.txtCodigo.Text = ""
        Me.txtAP.Text = ""
        Me.txtAM.Text = ""
        Me.txtNombres.Text = ""
        Me.txtLicencia.Text = ""
    End Sub

    Private Sub txtAP_Enter(sender As Object, e As System.EventArgs) Handles txtAP.Enter
        txtAP.SelectAll()
    End Sub

    Private Sub txtAP_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAP.KeyPress
        If (e.KeyChar = Chr(13)) Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtAP_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAP.TextChanged

    End Sub

    Private Sub txtAM_Enter(sender As Object, e As System.EventArgs) Handles txtAM.Enter
        txtAM.SelectAll()
    End Sub

    Private Sub txtAM_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAM.KeyPress
        If (e.KeyChar = Chr(13)) Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtAM_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAM.TextChanged

    End Sub

    Private Sub txtNombres_Enter(sender As Object, e As System.EventArgs) Handles txtNombres.Enter
        txtNombres.SelectAll()
    End Sub

    Private Sub txtNombres_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombres.KeyPress
        If (e.KeyChar = Chr(13)) Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtNombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombres.TextChanged

    End Sub

    Private Sub txtLicencia_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLicencia.Enter
        txtLicencia.SelectAll()
    End Sub

    Private Sub txtLicencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLicencia.KeyPress
        If (e.KeyChar = Chr(13)) Then
            SendKeys.Send(vbTab)
        Else
            If ValidarLetraNumero(e.KeyChar) = False Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Me.txtAP.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Apellido Paterno del Piloto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtAP.Text = ""
                Me.txtAP.Focus()
                Exit Sub
            End If

            If Me.txtAM.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Apellido Materno del Piloto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtAM.Text = ""
                Me.txtAM.Focus()
                Exit Sub
            End If

            If Me.txtNombres.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombres del Piloto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtNombres.Text = ""
                Me.txtNombres.Focus()
                Exit Sub
            End If

            If Me.txtLicencia.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Licencia de Conducir del Piloto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtLicencia.Text = ""
                Me.txtLicencia.Focus()
                Exit Sub
            End If

            Grabar(Me.action)

            Me.Limpiar()
            Me.action = 1
            Me.dgvChofer.DataSource = Me.Listar()
            Me.tabChofer.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Grabar(control As Integer)
        Dim obj As New dtoCONTROLUSUARIOS

        obj.iCONTROL = control
        If control = 2 Then
            obj.iIDUSUARIO_PERSONAL = Me.txtCodigo.Text.Trim
        Else
            obj.iIDUSUARIO_PERSONAL = 0
        End If
        obj.iAPEPAT = Me.txtAP.Text.Trim
        obj.iAPEMAT = Me.txtAM.Text.Trim
        obj.iNOMPER = Me.txtNombres.Text.Trim
        obj.snro_licencia = Me.txtLicencia.Text.Trim
        obj.iIDUSUARIO_CREADOR = dtoUSUARIOS.IdLogin
        obj.iIDROL_CREADOR = dtoUSUARIOS.IdRol

        obj.GrabarChofer()
    End Sub

    Function Listar() As DataTable
        Dim obj As New dtoCONTROLUSUARIOS

        Return obj.ListarChofer()
    End Function

    Private Sub FrmChofer_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        blnInicio = False
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmChofer_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmChofer_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        dgvChofer.AllowUserToDeleteRows = False
        dgvChofer.AllowUserToDeleteRows = False
        dgvChofer.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvChofer.ReadOnly = True

        blnInicio = True
        dgvChofer.DataSource = Listar()
        If dgvChofer.Rows.Count > 0 Then
            EditarToolStripMenuItem.Enabled = True
        Else
            EditarToolStripMenuItem.Enabled = False
        End If

        bIngreso = False
        Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
        Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
        bIngreso = True
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditarToolStripMenuItem.Click
        With dgvChofer
            Me.action = 2
            blnInicio = False
            Me.txtCodigo.Text = .CurrentRow.Cells(0).Value
            Me.txtAP.Text = .CurrentRow.Cells(1).Value
            Me.txtAM.Text = .CurrentRow.Cells(2).Value
            Me.txtNombres.Text = .CurrentRow.Cells(3).Value
            Me.txtLicencia.Text = .CurrentRow.Cells(4).Value

            tabChofer.SelectedIndex = 1

            Me.EditarToolStripMenuItem.Enabled = False
            Me.txtAP.Focus()
        End With
    End Sub

    Private Sub dgvChofer_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChofer.CellContentClick

    End Sub

    Private Sub dgvChofer_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvChofer.DoubleClick
        If Me.dgvChofer.Rows.Count > 0 Then
            Me.EditarToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, AnularToolStripMenuItem.EnabledChanged, EditarToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub tabChofer_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabChofer.SelectedIndexChanged
        If tabChofer.SelectedIndex = 0 Then
            If Me.dgvChofer.Rows.Count > 0 Then
                Me.EditarToolStripMenuItem.Enabled = True
            End If
        Else
            If Me.dgvChofer.Rows.Count > 0 And blnInicio = False Then
                Me.EditarToolStripMenuItem_Click(Nothing, Nothing)
            Else
                Me.NuevoToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End If
    End Sub
End Class