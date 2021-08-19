Public Class FrmNivelServicio
    Dim colCliente As New Collection
    Dim autoCliente As New AutoCompleteStringCollection

    Private Sub FrmNivelServicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim tip As New ToolTip
        tip.ShowAlways = True
        tip.SetToolTip(Me.btnVerInconsistencia, "Ver Inconsistencias")
        Me.Inicio()
    End Sub

    Sub Inicio()
        Dim obj As New dtoCarga
        Dim ds As DataSet = obj.Inicio

        Me.cboTipoEntrega.SelectedIndex = 0

        With cboEstadoOrigen
            .DataSource = ds.Tables(0)
            .DisplayMember = "estado"
            .ValueMember = "id"
            .SelectedIndex = 0
        End With
        With cboEstadoDestino
            .DataSource = ds.Tables(0).Copy
            .DisplayMember = "estado"
            .ValueMember = "id"
            .SelectedIndex = 0
        End With
        With cboProducto
            .DataSource = ds.Tables(1)
            .DisplayMember = "producto"
            .ValueMember = "id"
            .SelectedIndex = 0
        End With
        With cboOrigen
            .DataSource = ds.Tables(2)
            .DisplayMember = "ciudad"
            .ValueMember = "id"
            .SelectedIndex = 0
        End With
        With cboDestino
            .DataSource = ds.Tables(2).Copy
            .DisplayMember = "ciudad"
            .ValueMember = "id"
            .SelectedIndex = 0
        End With

        Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        ObjProcesos.fnCargar_iWin_r(Me.txtCliente, ds.Tables(3).DefaultView, colCliente, autoCliente, 0)

        ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cboFuncionario, "", "", 3, " (TODO)")

        Me.cboOrigen_SelectedIndexChanged(Nothing, Nothing)
        Me.cbodestino_SelectedIndexChanged(Nothing, Nothing)

        Me.ConfigurarDGVResultado()
    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress

    End Sub

    Private Sub txtCliente_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Not autoCliente.IndexOf(txtCliente.Text) = -1 Then
                Dim ObjPersona As New ClsLbTepsa.dtoPersona
                With ObjPersona
                    .IDPERSONA = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'Datahelper
                    ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                    Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                End With
            Else
                Me.txtCodigoCliente.Text = ""
            End If
        End If
    End Sub

    Private Sub txtCodigoCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                If Me.txtCodigoCliente.Text.Trim.Length > 0 Then
                    Dim obj As New dtoCarga
                    Dim strCodigoCliente As String = Me.txtCodigoCliente.Text.Trim
                    Dim dt As DataTable = obj.ObtieneCliente(strCodigoCliente)
                    If dt.Rows.Count > 0 Then
                        Me.txtCliente.Text = dt.Rows(0).Item("cliente")
                    Else
                        MessageBox.Show("El Cliente no Existe", "Nivel de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Nivel de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCodigoCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtCodigoCliente.LostFocus
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            Me.txtCliente.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtCodigoCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Me.Limpiar()
    End Sub

    Private Sub txtCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtCliente.LostFocus
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            Me.txtCliente.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCliente.TextChanged
        Me.Limpiar()
    End Sub

    Private Sub ConfigurarDGVResultado()
        With dgvResultado
            Cls_Utilitarios.FormatDataGridView(dgvResultado)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 9.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 9.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .Width = 100
            End With
            x += +1
            Dim col_tiempo As New DataGridViewTextBoxColumn
            With col_tiempo
                .Name = "tiempo" : .DataPropertyName = "tiempo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Tiempo" : .DefaultCellStyle.Format = "#,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Width = 150
            End With
            x += +1
            Dim col_totalenvios As New DataGridViewTextBoxColumn
            With col_totalenvios
                .Name = "totalenvios" : .DataPropertyName = "totalenvios"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Envios" : .DefaultCellStyle.Format = "#,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 150
            End With
            x += +1
            Dim col_envios As New DataGridViewTextBoxColumn
            With col_envios
                .Name = "envios" : .DataPropertyName = "envios"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Envios" : .DefaultCellStyle.Format = "#,###,###0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Width = 150
            End With
            x += +1
            Dim col_promedio As New DataGridViewTextBoxColumn
            With col_promedio
                .Name = "promedio" : .DataPropertyName = "promedio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Promedio" : .DefaultCellStyle.Format = "#,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 150
            End With

            .Columns.AddRange(col_fecha, col_tiempo, col_envios, col_totalenvios, col_promedio)
        End With
    End Sub

    Private Sub BtnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltrar.Click
        Try
            If Me.cboEstadoOrigen.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Carga de Inicio", "Nivel de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboEstadoOrigen.Focus()
                Return
            End If
            If Me.cboEstadoDestino.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Carga Final", "Nivel de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboEstadoDestino.Focus()
                Return
            End If
            If Me.cboEstadoOrigen.SelectedValue = Me.cboEstadoDestino.SelectedValue Then
                MessageBox.Show("La Carga Inicio y Final no pueden ser iguales", "Nivel de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboEstadoOrigen.Focus()
                Return
            End If

            Me.Cursor = Cursors.AppStarting
            Me.Actualizar()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Nivel de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvResultado_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvResultado.DoubleClick
        If Me.dgvResultado.Rows.Count > 0 Then
            Me.Cursor = Cursors.AppStarting
            'Dim strFecha As String = DateAdd("d", 1, Me.dgvResultado.CurrentRow.Cells("fecha").Value)
            Dim strFecha As String = Me.dgvResultado.CurrentRow.Cells("fecha").Value
            Dim frm As New frmNivelServicioDetalle
            'frm.StartPosition = FormStartPosition.Manual
            'frm.ControlBox = True
            frm.Cargar(strFecha, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, Me.dgvResultado.CurrentRow.Cells("envios").Value, Me.cboEstadoOrigen.SelectedValue, Me.cboEstadoDestino.SelectedValue, IIf(Me.chkTodo.Checked, 1, 0))
            'Acceso.Asignar(frm)
            'frm.MdiParent = Me
            'frm.hnd = Hnd

            frm.ShowDialog()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Sub Actualizar()
        Dim obj As New dtoCarga
        Dim intCliente As Integer
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            intCliente = 0
        Else
            intCliente = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
        End If
        Dim dt As DataTable = obj.ActualizarNivelServicio(Me.cboEstadoOrigen.SelectedValue, Me.cboEstadoDestino.SelectedValue, Me.cboProducto.SelectedValue, _
        Me.cboOrigen.SelectedValue, Me.cboDestino.SelectedValue, Me.cboAgenciaOrigen.SelectedValue, Me.cboAgenciaDestino.SelectedValue, Me.dtpFechaInicio.Value.ToShortDateString, intCliente, _
        dtpFechaFin.Value.ToShortDateString, Me.cboFuncionario.SelectedValue, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, Me.cboTipoEntrega.SelectedIndex, IIf(Me.chkTodo.Checked, 1, 0))
        Me.dgvResultado.DataSource = dt

        If dgvResultado.Rows.Count > 0 Then
            Dim dblTiempo As Double = IIf(IsDBNull(dt.Compute("sum(tiempo)", "")), 0, dt.Compute("sum(tiempo)", ""))
            Me.lblTiempo.Text = dblTiempo.ToString("#,###,###0.00")

            Dim dblTotalEnvios As Double = Me.dgvResultado.CurrentRow.Cells("totalenvios").Value
            Me.lblEnvios.Text = dblTotalEnvios.ToString("#,###,###0")

            Dim dblPromedio As Double = dblTiempo / dblTotalEnvios 'IIf(IsDBNull(dt.Compute("sum(promedio)", "")), 0, dt.Compute("sum(promedio)", ""))
            Me.lblPromedio.Text = dblPromedio.ToString("#,###,###0.00")
        Else
            Me.lblTiempo.Text = "0.00"
            Me.lblEnvios.Text = "0"
            Me.lblPromedio.Text="0.00"
        End If
    End Sub

    Private Sub cboOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOrigen.SelectedIndexChanged
        If IsReference(cboOrigen.SelectedValue) Then Return
        Me.Limpiar()

        Dim obj As New dtoCarga
        Dim dt As DataTable = obj.ListarAgencias(Me.cboOrigen.SelectedValue)
        With cboAgenciaOrigen
            .DataSource = dt
            .DisplayMember = "agencia"
            .ValueMember = "id"
        End With
    End Sub

    Private Sub cboDestino_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDestino.SelectedIndexChanged
        If IsReference(cboDestino.SelectedValue) Then Return
        Me.Limpiar()

        Dim obj As New dtoCarga
        Dim dt As DataTable = obj.ListarAgencias(Me.cboDestino.SelectedValue)
        With cboAgenciaDestino
            .DataSource = dt
            .DisplayMember = "agencia"
            .ValueMember = "id"
        End With
    End Sub

    Private Sub btnVerInconsistencia_Click(sender As System.Object, e As System.EventArgs) Handles btnVerInconsistencia.Click
        Me.Cursor = Cursors.AppStarting
        Dim frm As New frmNivelServicioDetalle
        frm.intOpcion = 1
        frm.Cargar(cboEstadoDestino.SelectedValue, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
        frm.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboEstadoOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoOrigen.SelectedIndexChanged
        Me.Limpiar()
    End Sub

    Private Sub cboEstadoDestino_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoDestino.SelectedIndexChanged
        Me.Limpiar()
    End Sub

    Private Sub cboAgenciaOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAgenciaOrigen.SelectedIndexChanged
        Me.Limpiar()
    End Sub

    Private Sub cboAgenciaDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgenciaDestino.SelectedIndexChanged
        Me.Limpiar()
    End Sub

    Private Sub cboProducto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProducto.SelectedIndexChanged
        Me.Limpiar()
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaInicio.ValueChanged
        Me.Limpiar()
    End Sub

    Private Sub dtpFechaFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaFin.ValueChanged
        Me.Limpiar()
    End Sub

    Private Sub cboFuncionario_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboFuncionario.SelectedIndexChanged
        Me.Limpiar()
    End Sub

    Sub Limpiar()
        Try
            dgvResultado.DataSource = Nothing
            lblTiempo.Text = "0.00"
            lblEnvios.Text = "0"
            lblPromedio.Text = "0.00"

            Dim obj As New dtoCarga
            obj.LimpiarNivelServicio(dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvResultado_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResultado.CellContentClick

    End Sub

    Private Sub cboTipoEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoEntrega.SelectedIndexChanged
        Me.Limpiar()
    End Sub
End Class