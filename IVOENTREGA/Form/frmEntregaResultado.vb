Imports INTEGRACION_LN
Imports INTEGRACION_EN
Public Class frmEntregaResultado
    Dim blnInicio As Boolean

    Sub FormatearDGVResultado()
        With dgvResultado
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
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
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .HeaderText = "Agencia" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
            End With
            x += +1
            Dim col_operacion As New DataGridViewTextBoxColumn
            With col_operacion
                .Name = "operacion" : .DataPropertyName = "operacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .HeaderText = "Usuario" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Nº Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_minutos As New DataGridViewTextBoxColumn
            With col_minutos
                .Name = "minutos" : .DataPropertyName = "minutos"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Minutos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_segundos As New DataGridViewTextBoxColumn
            With col_segundos
                .Name = "segundos" : .DataPropertyName = "segundos"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Segundos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_produccion As New DataGridViewTextBoxColumn
            With col_produccion
                .Name = "produccion" : .DataPropertyName = "produccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "En Tiempo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_registros As New DataGridViewTextBoxColumn
            With col_registros
                .Name = "registros" : .DataPropertyName = "registros"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Envíos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_objetivo As New DataGridViewTextBoxColumn
            With col_objetivo
                .Name = "objetivo" : .DataPropertyName = "objetivo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Objetivo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_adicional As New DataGridViewTextBoxColumn
            With col_adicional
                .Name = "adicional" : .DataPropertyName = "adicional"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Adicional"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_objetivo_real As New DataGridViewTextBoxColumn
            With col_objetivo_real
                .Name = "objetivo_real" : .DataPropertyName = "objetivo_real"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Objetivo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_cumplimiento As New DataGridViewTextBoxColumn
            With col_cumplimiento
                .Name = "cumplimiento" : .DataPropertyName = "cumplimiento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cumplimiento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00"
            End With
            .Columns.AddRange(col_agencia, col_fecha, col_operacion, col_usuario, col_tipo, col_comprobante, col_horas, col_minutos, col_segundos, _
                              col_produccion, col_registros, col_cantidad, col_objetivo, col_adicional, col_objetivo_real, col_cumplimiento)
        End With
    End Sub

    Private Sub frmEntregaResultado_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        blnInicio = True
        Inicio()
    End Sub

    Sub Inicio()
        Me.FormatearDGVResultado()
        Dim objLN As New Cls_EntregaCarga_LN
        With cboAgencia
            .ValueMember = "id"
            .DisplayMember = "agencia"
            .DataSource = objLN.ListarAgencia(1)
            .SelectedValue = 51
        End With
        Me.dtpFechaInicio.Value = "01/" & Me.dtpFechaInicio.Value.Month.ToString.PadLeft(2, "0") & "/" & Me.dtpFechaInicio.Value.Year
        blnInicio = False
        Me.cboOperacion.SelectedIndex = 0
    End Sub

    Sub ListarUsuario()
        If blnInicio Then Return
        Try
            Cursor = Cursors.WaitCursor
            Dim objLN As New Cls_EntregaCarga_LN
            Dim objEN As New Cls_EntregaCarga_EN
            objEN.Agencia = Me.cboAgencia.SelectedValue
            objEN.FechaInicio = Me.dtpFechaInicio.Value.ToShortDateString
            objEN.FechaFin = Me.dtpFechaFin.Value.ToShortDateString

            Dim intOperacion As Integer = Me.cboOperacion.SelectedIndex
            'If intOperacion > 0 Then intOperacion += 1
            objEN.Operacion = intOperacion

            Dim dt As DataTable = objLN.ListarUsuario(objEN)
            With cboUsuario
                .DisplayMember = "usuario"
                .ValueMember = "id"
                .DataSource = dt
                .SelectedValue = 0
            End With
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Informe de Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboAgencia_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboAgencia.SelectedValueChanged
        ListarUsuario()
    End Sub

    Private Sub cboOperacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOperacion.SelectedIndexChanged
        ListarUsuario()
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaInicio.ValueChanged
        ListarUsuario()
    End Sub

    Private Sub dtpFechaFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaFin.ValueChanged
        ListarUsuario()
    End Sub

    Private Sub btnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        If Me.cboAgencia.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione la Agencia", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboAgencia.Focus()
            Me.cboAgencia.DroppedDown = True
            Return
        End If

        If Me.cboOperacion.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione la Operación", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboOperacion.Focus()
            Me.cboOperacion.DroppedDown = True
            Return
        End If

        Filtrar()
    End Sub

    Sub Filtrar()
        Try
            Cursor = Cursors.WaitCursor
            Dim objLN As New Cls_EntregaCarga_LN
            Dim objEN As New Cls_EntregaCarga_EN
            objEN.Agencia = Me.cboAgencia.SelectedValue
            objEN.FechaInicio = Me.dtpFechaInicio.Value.ToShortDateString
            objEN.FechaFin = Me.dtpFechaFin.Value.ToShortDateString
            objEN.Usuario = Me.cboUsuario.SelectedValue

            Dim intOperacion As Integer = Me.cboOperacion.SelectedIndex
            'If intOperacion > 0 Then intOperacion += 1
            objEN.Operacion = intOperacion

            Dim dt As DataTable = objLN.ListarResultado(objEN)
            Me.dgvResultado.DataSource = dt

            If dt.Rows.Count > 0 Then
                Dim intRegistro As Integer = IIf(IsDBNull(dt.Compute("sum(registros)", "")), 0, dt.Compute("sum(registros)", ""))
                Dim dblProduccion As Double = IIf(IsDBNull(dt.Compute("sum(produccion)", "")), 0, dt.Compute("sum(produccion)", ""))
                Me.lblCumplimiento.Text = Format(dblProduccion / intRegistro * 100, "###,###,###0.00")
                Me.lblProduccion.Text = dblProduccion
                Me.lblEnvios.Text = intRegistro
            Else
                Me.lblProduccion.Text = "0"
                Me.lblEnvios.Text = "0"
                Me.lblCumplimiento.Text = "0.00"
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Informe de Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgvResultado_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResultado.CellContentClick

    End Sub
End Class