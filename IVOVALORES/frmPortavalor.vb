Imports INTEGRACION_LN
Public Class frmPortavalor
    Dim intOperacion As Operacion
    Dim blnInicio As Boolean

    Sub FormateardgvLista()
        With dgvLista
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_tipo_documento As New DataGridViewTextBoxColumn
            With col_tipo_documento
                .Name = "tipo_documento" : .DataPropertyName = "tipo_documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_numero_documento As New DataGridViewTextBoxColumn
            With col_numero_documento
                .Name = "numero_documento" : .DataPropertyName = "numero_documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_idciudad As New DataGridViewTextBoxColumn
            With col_idciudad
                .Name = "idciudad" : .DataPropertyName = "idciudad" : .DisplayIndex = x : .Visible = False : .HeaderText = "idciudad"
            End With

            x += +1
            Dim col_idtipo_documento As New DataGridViewTextBoxColumn
            With col_idtipo_documento
                .Name = "idtipo_documento" : .DataPropertyName = "idtipo_documento" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_documento"
            End With

            .Columns.AddRange(col_id, col_tipo_documento, col_numero_documento, col_nombres, col_codigo, col_idciudad, col_idtipo_documento)
        End With
    End Sub
    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub frmPortavalor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        blnInicio = False
    End Sub

    Private Sub frmPortavalor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        blnInicio = True
        FormateardgvLista()
        Listar()
        If dgvLista.Rows.Count > 0 Then
            tsbEditar.Enabled = True
            tsbAnular.Enabled = True
        Else
            tsbEditar.Enabled = False
            tsbAnular.Enabled = False
        End If
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Try
            If Me.txtDni.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el DNI", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDni.Focus()
                Return
            End If
            If Me.txtDni.Text.Trim.Length <> 8 Then
                MessageBox.Show("Ingrese un DNI válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDni.Focus()
                Return
            End If

            If Me.txtNombres.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombres", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNombres.Text = ""
                txtNombres.Focus()
                Return
            End If

            Grabar()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If Me.txtDni.Enabled Then
                Me.txtDni.Focus()
            Else
                Me.txtNombres.Focus()
            End If
        End Try
    End Sub

    Sub Listar()
        Dim obj As New Cls_LiquidacionValor_LN
        Me.dgvLista.DataSource = obj.ListarPortavalor(dtoUSUARIOS.m_idciudad)
    End Sub

    Sub Limpiar()
        Me.lblCiudad.Text = dtoUSUARIOS.m_iNombreUnidadAgencia
        Me.txtDni.Text = ""
        Me.txtNombres.Text = ""
        Me.txtCodigo.Text = ""
    End Sub

    Sub Grabar()
        Try
            Dim intId As Integer
            Dim strDni As String, strNombres As String, strCodigo As String
            If intOperacion = Operacion.Modificar Then
                intId = Me.dgvLista.CurrentRow.Cells("id").Value
            Else
                intId = 0
            End If
            strDni = Me.txtDni.Text.Trim
            strNombres = Me.txtNombres.Text.Trim
            strCodigo = Me.txtCodigo.Text.Trim

            Dim obj As New Cls_LiquidacionValor_LN
            obj.GrabarPortavalor(intId, 3, strDni, strNombres, dtoUSUARIOS.m_idciudad, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol, strCodigo)
            Me.Limpiar()
            intOperacion = Operacion.Nuevo
            Listar()
            Me.tabProveedor.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        intOperacion = Operacion.Nuevo
        blnInicio = True
        Me.Limpiar()
        tsbGrabar.Enabled = True
        Me.tsbEditar.Enabled = False
        Me.txtDni.Enabled = True
        tabProveedor.SelectedIndex = 1
        Me.txtDni.Focus()
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        With dgvLista
            intOperacion = Operacion.Modificar
            blnInicio = False
            Me.lblCiudad.Text = dtoUSUARIOS.m_iNombreUnidadAgencia

            Me.txtDni.Text = IIf(IsDBNull(.CurrentRow.Cells("numero_documento").Value), "", .CurrentRow.Cells("numero_documento").Value)
            Me.txtNombres.Text = IIf(IsDBNull(.CurrentRow.Cells("nombres").Value), "", .CurrentRow.Cells("nombres").Value)
            Me.txtCodigo.Text = IIf(IsDBNull(.CurrentRow.Cells("codigo").Value), "", .CurrentRow.Cells("codigo").Value)
            Me.txtDni.Enabled = False
            tabProveedor.SelectedIndex = 1

            Me.tsbEditar.Enabled = False
            Me.txtDni.Focus()
        End With
    End Sub

    Private Sub txtDni_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDni.Enter
        Me.txtDni.SelectAll()
    End Sub

    Private Sub txtDni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDni.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNombres_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombres.Enter
        Me.txtNombres.SelectAll()
    End Sub

    Private Sub txtNombres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombres.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodigo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.Enter
        Me.txtCodigo.SelectAll()
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            tsbGrabar_Click(Nothing, Nothing)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Sub Anular()
        Dim intId As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
        Dim obj As New Cls_LiquidacionValor_LN
        obj.AnularPortavalor(intId, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
    End Sub

    Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click
        Try
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de anular el Portavalor?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Anular()
                Listar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Anular", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tabProveedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabProveedor.SelectedIndexChanged
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

    Private Sub dgvLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLista.DoubleClick
        If Me.dgvLista.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgvLista_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter

    End Sub
End Class