Imports INTEGRACION_LN

Public Class frmTeleventasVer
    Sub FormatearDgv()
        With dgv
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
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
            Dim col_id_cdr As New DataGridViewTextBoxColumn
            With col_id_cdr
                .Name = "id_cdr" : .DataPropertyName = "id_cdr" : .DisplayIndex = x : .HeaderText = "id" : .Visible = False
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_dcontext As New DataGridViewTextBoxColumn
            With col_dcontext
                .Name = "dcontext" : .DataPropertyName = "dcontext"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Llamada" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_agente As New DataGridViewTextBoxColumn
            With col_agente
                .Name = "agente" : .DataPropertyName = "agente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agente" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_nombre_cliente As New DataGridViewTextBoxColumn
            With col_nombre_cliente
                .Name = "nombre_cliente" : .DataPropertyName = "nombre_cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_dato1 As New DataGridViewTextBoxColumn
            With col_dato1
                .Name = "dato1" : .DataPropertyName = "dato1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Documento" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            .Columns.AddRange(col_id_cdr, col_fecha, col_dcontext, col_agente, col_nombre_cliente, col_dato1)
        End With
    End Sub

    Sub Listar()
        Dim obj As New Cls_Televenta_LN
        Me.dgv.DataSource = obj.ListarLlamada()
    End Sub

    Private Sub frmTeleventasVer_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Listar()
        FormatearDgv()
        Me.lblDato.Text = ""
        Me.lblCliente.Text = ""
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        tabLlamada.SelectedTab = tabLlamada.TabPages("tabLista")
    End Sub

    Private Sub tabLlamada_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabLlamada.SelectedIndexChanged
        If tabLlamada.SelectedTab Is tabLlamada.TabPages("tabMantenimiento") Then
            Me.txtDato.Text = ""
            Me.lblCliente.Text = ""
            Me.txtDato.Focus()
            Me.txtDato.SelectAll()

            If Me.dgv.Rows.Count > 0 Then
                Me.lblDato.Text = IIf(IsDBNull(Me.dgv.CurrentRow.Cells("dato1").Value), "", Me.dgv.CurrentRow.Cells("dato1").Value)
                Me.lblCliente.Text = IIf(IsDBNull(Me.dgv.CurrentRow.Cells("nombre_cliente").Value), "", Me.dgv.CurrentRow.Cells("nombre_cliente").Value)
                Me.txtDato.Enabled = True
                Me.btnGrabar.Enabled = True
            Else
                Me.txtDato.Enabled = False
                Me.btnGrabar.Enabled = False
            End If
        End If
    End Sub

    Private Sub dgv_DoubleClick(sender As Object, e As System.EventArgs) Handles dgv.DoubleClick
        If Me.dgv.Rows.Count > 0 Then
            tabLlamada.SelectedIndex = 1
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If Not fnValidarRUC(Me.txtDato.Text) Then
            MessageBox.Show("El Ruc no es válido", "Televentas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDato.Focus()
            Me.txtDato.SelectAll()
            Return
        End If

        Grabar()
    End Sub

    Private Sub txtDato_Enter(sender As Object, e As System.EventArgs) Handles txtDato.Enter
        Me.txtDato.SelectAll()
    End Sub

    Private Sub txtDato_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDato.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Sub Grabar()
        Try
            Cursor = Cursors.AppStarting
            Dim obj As New Cls_Televenta_LN
            Dim intId As Integer

            intId = Me.dgv.CurrentRow.Cells("id_cdr").Value
            obj.ActualizarLlamada(intId, Me.txtDato.Text.Trim)
            tabLlamada.SelectedTab = tabLlamada.TabPages("tabLista")
            Me.Listar()
            Cursor=Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Televentas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtDato_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDato.TextChanged

    End Sub
End Class