Imports INTEGRACION_LN
Public Class frmEntregaPanelControl
    Dim blnInicio As Boolean

    Sub FormatearDGVFormulario()
        With dgvFormulario
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.7!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "ID" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_formulario As New DataGridViewTextBoxColumn
            With col_formulario
                .Name = "formulario" : .DataPropertyName = "formulario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Formulario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Width = 35
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_formulario)
        End With
    End Sub

    Private Sub frmEntregaPanelControl_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        blnInicio = False
    End Sub

    Private Sub frmEntregaPanelControl_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        blnInicio = True
        FormatearDGVFormulario()
        btnActualizar_Click(Nothing, Nothing)
        If Me.dgvMonitor.Rows.Count > 0 Then
            ListarPantallaFormulario(dgvMonitor.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        'blnInicio = True
        Me.Actualizar()
    End Sub

    Sub Actualizar()
        Cursor = Cursors.WaitCursor
        With dgvMonitor
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .Rows.Clear()
            For Each scrn As Screen In Screen.AllScreens
                .Rows.Add()
                .Rows(.Rows.Count - 1).Cells(0).Value = scrn.DeviceName
                .Rows(.Rows.Count - 1).Cells(1).Value = scrn.Bounds.ToString()
                .Rows(.Rows.Count - 1).Cells(2).Value = scrn.WorkingArea.ToString()
                .Rows(.Rows.Count - 1).Cells(3).Value = scrn.GetType().ToString()
                .Rows(.Rows.Count - 1).Cells(4).Value = IIf(scrn.Primary.ToString(), "Si", "No")
            Next
            'blnInicio = False
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Try
            Dim frm As New frmAgregarFormulario
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                Dim intPantalla As Integer = Me.dgvMonitor.CurrentCell.RowIndex
                Dim intFormulario As Integer = frm.dgv.CurrentRow.Cells("id").Value
                Grabar(intPantalla, intFormulario)

                ListarPantallaFormulario(intPantalla)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Panel de Control", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Grabar(pantalla As Integer, formulario As Integer)
        Dim obj As New Cls_EntregaCarga_LN
        obj.GrabarPantallaFormulario(pantalla, formulario)
        'btnActualizar_Click(Nothing, Nothing)
    End Sub

    Sub ListarPantallaFormulario(pantalla As Integer)
        Dim obj As New Cls_EntregaCarga_LN
        Me.dgvFormulario.DataSource = obj.ListarPantallaFormulario(pantalla)
    End Sub

    Private Sub dgvMonitor_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMonitor.RowEnter
        If blnInicio Then Return
        ListarPantallaFormulario(e.RowIndex)
    End Sub

    Private Sub dgvFormulario_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvFormulario.KeyDown
        If dgvFormulario.Rows.Count > 0 Then
            If e.KeyCode = Keys.Delete Then
                Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está seguro de eliminar el Formulario?", "Panel de Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    Dim intPantalla As Integer = Me.dgvMonitor.CurrentCell.RowIndex
                    Dim intFormulario As Integer = Me.dgvFormulario.CurrentRow.Cells("id").Value

                    Dim obj As New Cls_EntregaCarga_LN
                    obj.EliminarFormulario(intPantalla, intFormulario)
                    Me.ListarPantallaFormulario(intPantalla)
                End If
            End If
        End If
    End Sub

    Private Sub tab_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tab.SelectedIndexChanged
        If tab.SelectedIndex = 1 Then
            ListarPanelControl()
        End If
    End Sub

    Sub ListarPanelControl()
        Try
            Dim obj As New Cls_EntregaCarga_LN
            Dim dt As DataTable = obj.ListarPanelControl()
            Mostrar(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Panel de Control", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Mostrar(dt As DataTable)
        For Each row As DataRow In dt.Rows
            If row.Item("codigo") = 4 Then Me.txtTamaño.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 5 Then Me.chkResaltado.Checked = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 7 Then Me.txtAlto.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 1 Then Me.txtDistancia.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 10 Then Me.txtRetardoAC.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 11 Then Me.txtRetardoDisponible.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 25 Then Me.txtFilaMovimiento.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))

            If row.Item("codigo") = 14 Then Me.txtFilaInicio.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 15 Then Me.txtCol1.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 16 Then Me.txtCol2.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 17 Then Me.txtCol3.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 18 Then Me.txtCol4.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 19 Then Me.txtCol5.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))

            If row.Item("codigo") = 20 Then Me.txtFilas.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 21 Then Me.txtTitulo1.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 22 Then Me.txtTitulo2.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 23 Then Me.txtTitulo3.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 24 Then Me.txtTituloFila.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))

            If row.Item("codigo") = 26 Then Me.txtTamañoAlmacen.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))
            If row.Item("codigo") = 12 Then Me.txtRetardoAlmacen.Text = IIf(IsDBNull(row.Item("valor")), 0, row.Item("valor"))

            'If row.Item("codigo") = 2 Then Me.txtVideo.Text = IIf(IsDBNull(row.Item("valor")), "", row.Item("valor"))
            If row.Item("codigo") = 3 Then Me.txtFuente.Text = IIf(IsDBNull(row.Item("valor")), "", row.Item("valor"))
        Next
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        GrabarPanelControl()
    End Sub

    Sub GrabarPanelControl()
        Try
            Dim obj As New Cls_EntregaCarga_LN

            Dim intTamaño As Integer = Me.txtTamaño.Text
            Dim intAlto As Integer = Me.txtAlto.Text
            Dim intDistancia As Integer = Me.txtDistancia.Text
            Dim intResaltado As Integer = Me.chkResaltado.Checked
            Dim intResaltadoAC As Integer = Me.txtRetardoAC.Text
            Dim intResaltadoDis As Integer = Me.txtRetardoDisponible.Text
            Dim intFilaMovimiento As Integer = Me.txtFilaMovimiento.Text

            Dim intFilaInicio As Integer = Me.txtFilaInicio.Text
            Dim intCol1 As Integer = Me.txtCol1.Text
            Dim intCol2 As Integer = Me.txtCol2.Text
            Dim intCol3 As Integer = Me.txtCol3.Text
            Dim intCol4 As Integer = Me.txtCol4.Text
            Dim intCol5 As Integer = Me.txtCol5.Text

            Dim intFilas As Integer = Me.txtFilas.Text
            Dim intTitulo1 As Integer = Me.txtTitulo1.Text
            Dim intTitulo2 As Integer = Me.txtTitulo2.Text
            Dim intTitulo3 As Integer = Me.txtTitulo3.Text
            Dim intTituloFila As Integer = Me.txtTituloFila.Text

            Dim intTamañoAlmacen As Integer = Me.txtTamañoAlmacen.Text
            Dim intRetardoAlmacen As Integer = Me.txtRetardoAlmacen.Text

            Dim strVideo As String = "" 'Me.txtVideo.Text.Trim
            Dim strFuente As String = Me.txtFuente.Text.Trim

            obj.GrabarPanelControl(intTamaño, intAlto, intDistancia, intResaltado, intResaltadoAC, intResaltadoDis, intFilaMovimiento, _
                                   intFilaInicio, intCol1, intCol2, intCol3, _
                                   intCol4, intCol5, intFilas, intTitulo1, intTitulo2, intTitulo3, intTituloFila, _
                                   intTamañoAlmacen, intRetardoAlmacen, strVideo, strFuente)

            MessageBox.Show("Panel de Control Actualizado", "Panel de Control", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Panel de Control", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.tab.SelectedIndex = 0

    End Sub

    Private Sub btnExaminar_Click(sender As System.Object, e As System.EventArgs) Handles btnExaminar.Click
        Try
            dialogo.Filter = "AVI Files|*.avi|MPG Files|*.mpg|MP4 Files|*.mp4|WMV Files|*.wmv|All Files|*.*"

            If dialogo.ShowDialog = Windows.Forms.DialogResult.OK Then
                'play.URL = dialogo.FileName 'Play
                'PlayPauseToolStripMenuItem.Text = "Pause" 'Change 'Play' To 'Pause' On Menu
                'Dim obj As New Cls_EntregaCarga_LN
                'obj.GrabarAtencionCliente(play.URL)

                'Me.txtVideo.Text = dialogo.FileName.Trim

                Me.lstVideo.Items.Add(dialogo.FileName.Trim)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención al Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtAlto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAlto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub txtAlto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAlto.TextChanged

    End Sub

    Private Sub txtTamaño_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTamaño.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtTamaño_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTamaño.TextChanged

    End Sub

    Private Sub txtDistancia_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDistancia.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub txtDistancia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDistancia.TextChanged

    End Sub

    Private Sub chkResaltado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkResaltado.CheckedChanged

    End Sub

    Private Sub chkResaltado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles chkResaltado.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtRetardoAC_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRetardoAC.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtRetardoAC_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRetardoAC.TextChanged

    End Sub

    Private Sub txtRetardoDisponible_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRetardoDisponible.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtRetardoDisponible_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRetardoDisponible.TextChanged

    End Sub

    Private Sub txtFilaMovimiento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilaMovimiento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtFilaMovimiento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFilaMovimiento.TextChanged

    End Sub

    Private Sub txtFilaInicio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilaInicio.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtFilaInicio_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFilaInicio.TextChanged

    End Sub

    Private Sub txtCol1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCol1.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCol1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCol1.TextChanged

    End Sub

    Private Sub txtCol2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCol2.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCol2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCol2.TextChanged

    End Sub

    Private Sub txtCol3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCol3.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCol3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCol3.TextChanged

    End Sub

    Private Sub txtCol4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCol4.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCol4_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCol4.TextChanged

    End Sub

    Private Sub txtCol5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCol5.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCol5_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCol5.TextChanged

    End Sub

    Private Sub txtFilas_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilas.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtFilas_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFilas.TextChanged

    End Sub

    Private Sub txtTitulo1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTitulo1.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtTitulo1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTitulo1.TextChanged

    End Sub

    Private Sub txtTitulo2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTitulo2.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtTitulo2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTitulo2.TextChanged

    End Sub

    Private Sub txtTitulo3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTitulo3.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtTitulo3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTitulo3.TextChanged

    End Sub

    Private Sub txtTituloFila_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTituloFila.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtTituloFila_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTituloFila.TextChanged

    End Sub

    Private Sub txtTamañoAlmacen_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTamañoAlmacen.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtTamañoAlmacen_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTamañoAlmacen.TextChanged

    End Sub

    Private Sub txtRetardoAlmacen_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRetardoAlmacen.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtRetardoAlmacen_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRetardoAlmacen.TextChanged

    End Sub

    Private Sub txtFuente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFuente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtFuente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFuente.TextChanged

    End Sub

    Private Sub txtVideo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtVideo_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub dgvFormulario_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFormulario.CellContentClick

    End Sub
End Class