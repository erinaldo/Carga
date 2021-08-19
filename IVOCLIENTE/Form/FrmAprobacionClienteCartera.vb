Imports INTEGRACION_LN
Imports INTEGRACION_EN

'Enum Estado
'    Pendiente = 1
'    Aprobado = 2
'    Desaprobado = 3
'    Anulado = 4
'End Enum

Public Class FrmAprobacionClienteCartera
    Public hnd As Long
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL

    Dim blnInicio As Boolean = True

    Private Sub FrmAprobacionClienteCartera_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        blnInicio = False
    End Sub

    Private Sub FrmAprobacionClienteCartera_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        blnInicio = True
        Cls_Utilitarios.FormatDataGridView(dgv)
        ConfigurarDGV()
        ConfigurarDGV1()
        ConfigurarDGV2()
        CargarCombos()
        'objgeneral.FN_cmb_L_FUNCIONARIOS(Me.cmbFuncionario1)
        ListarSolicitudes()
    End Sub

    Sub CargarCombos()
        'Dim objLN As New Cls_ClienteCarteraFuncionario_LN
        'Dim dt As DataTable = objLN.ListarFuncionario()
        'Dim dt2 As DataTable = dt.Copy

        'CargarCombo(Me.cmbFuncionario1, dt, "nombres", "id", 0)
        'CargarCombo(Me.cmbFuncionario2, dt2, "nombres", "id", 0)

        ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cmbFuncionario1, "", "", 3, " (SELECCIONE)")
        ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cmbFuncionario2, "", "", 3, " (SELECCIONE)")
    End Sub

    Private Sub ConfigurarDGV()
        With dgv
            'utilitario.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
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
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_solicitud As New DataGridViewTextBoxColumn
            With col_solicitud
                .Name = "numero_solicitud" : .DataPropertyName = "numero_solicitud"
                .DisplayIndex = x : .HeaderText = "Nº Solicitud"
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
            End With
            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
            End With

            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
            End With
            x += +1
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Cliente"
            End With

            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Solicitante"
            End With
            x += +1
            Dim col_usuario_solicitud As New DataGridViewTextBoxColumn
            With col_usuario_solicitud
                .Name = "usuario_solicitud" : .DataPropertyName = "usuario_solicitud"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Usuario Solicitud"
            End With
            x += +1
            Dim col_sustento As New DataGridViewTextBoxColumn
            With col_sustento
                .Name = "sustento" : .DataPropertyName = "sustento"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Sustento"
            End With

            x += +1
            Dim col_responsable As New DataGridViewTextBoxColumn
            With col_responsable
                .Name = "responsable_actual" : .DataPropertyName = "responsable_actual"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Responsable Actual"
            End With
            x += +1
            Dim col_idresponsable As New DataGridViewTextBoxColumn
            With col_idresponsable
                .Name = "idresponsable" : .DataPropertyName = "idresponsable"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Responsable"
            End With
            x += +1
            Dim col_fechainicio As New DataGridViewTextBoxColumn
            With col_fechainicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Fecha Inicio" : .DefaultCellStyle.NullValue = ""
            End With

            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "ID"
            End With
            .Columns.AddRange(col_solicitud, col_fecha, col_codigo, col_cliente, col_idcliente, col_solicitante, _
                              col_usuario_solicitud, col_sustento, col_responsable, col_idresponsable, col_fechainicio, _
                              col_id)
        End With
    End Sub

    Private Sub ConfigurarDGV1()
        With dgv1
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
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
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            .ReadOnly = False

            Dim x As Integer = 0
            Dim col_sel As New DataGridViewCheckBoxColumn
            With col_sel
                .HeaderText = "Sel"
                .Name = "sel"
                '.DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 50
                '.ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                '.Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DisplayIndex = x
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
                .Width = 220
            End With
            x += +1
            Dim col_FechaInicio As New DataGridViewTextBoxColumn
            With col_FechaInicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Ini."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            .Columns.AddRange(col_sel, col_id, col_codigo, col_cliente, col_FechaInicio)
        End With
    End Sub
    Private Sub ConfigurarDGV2()
        With dgv2
            'utilitario.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
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
            '.RowHeadersWidth = 1

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
                .Width = 220
            End With
            x += +1
            Dim col_FechaInicio As New DataGridViewTextBoxColumn
            With col_FechaInicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Ini."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            .Columns.AddRange(col_id, col_codigo, col_cliente, col_FechaInicio)
        End With
    End Sub
    Sub ListarSolicitudes()
        Try
            Dim obj As New Cls_ClienteCarteraFuncionario_LN
            Dim objEN As New Cls_ClienteCarteraFuncionario_EN

            objEN.Estado = Estado.Pendiente
            dgv.DataSource = obj.ListarSolicitud(objEN.Estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RbtSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtSi.CheckedChanged
        Me.TxtObservacion.Enabled = False
        Me.TxtObservacion.Text = ""
        Me.BtnAceptar.Text = "&Aprobar"
        Me.TxtObservacion.Focus()
    End Sub

    Private Sub RbtNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtNo.CheckedChanged
        Me.TxtObservacion.Enabled = True
        Me.BtnAceptar.Text = "&Desaprobar"
        Me.TxtObservacion.Focus()
    End Sub

    Private Sub dgv_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub dgv_DoubleClick(sender As Object, e As System.EventArgs) Handles dgv.DoubleClick
        If Me.dgv.Rows.Count > 0 Then
            Me.tab.SelectedIndex = 1
            Me.tab_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Sub Limpiar()
        Me.lblCodigo.Text = ""
        Me.lblRazonSocial.Text = ""
        Me.lblFuncionarioActual.Text = ""
        Me.lblFechaInicio.Text = ""
        Me.dtpFechaFin.Text = ""
        Me.lblFuncionarioNuevo.Text = ""
        Me.lblSustento.Text = ""
        Me.RbtSi.Checked = True
        Me.TxtObservacion.Text = ""
    End Sub

    Private Sub tab_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tab.SelectedIndexChanged
        If tab.SelectedIndex = 1 Then
            If dgv.Rows.Count > 0 Then
                BtnAceptar.Enabled = True
                Me.dtpFechaActivacion.Enabled = True
                Me.dtpFechaFin.Enabled = True
                Me.RbtSi.Enabled = True
                Me.RbtNo.Enabled = True

                Me.dtpFechaActivacion.Value = DateAdd("d", 1, Now).ToString("dd/MM/yyyy")
                Me.dtpFechaActivacion.Focus()
            Else
                Limpiar()
                Me.dtpFechaActivacion.Enabled = False
                Me.dtpFechaFin.Enabled = False
                BtnAceptar.Enabled = False
                Me.RbtSi.Enabled = False
                Me.RbtNo.Enabled = False
            End If
        End If
    End Sub

    Private Sub dgv_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.RowEnter
        With dgv
            If .Rows.Count > 0 Then
                BtnAceptar.Enabled = True

                Dim row As DataGridViewRow = .Rows(e.RowIndex)

                Me.lblCodigo.Text = row.Cells("codigo").Value
                Me.lblRazonSocial.Text = row.Cells("cliente").Value

                Me.lblFuncionarioActual.Text = row.Cells("responsable_actual").Value
                Me.lblFechaInicio.Text = IIf(IsDBNull(row.Cells("fecha_inicio").Value), "", row.Cells("fecha_inicio").Value)

                Me.lblFuncionarioNuevo.Text = row.Cells("solicitante").Value
                Me.lblSustento.Text = row.Cells("sustento").Value

                If Me.lblFuncionarioActual.Text = "SIN FUNCIONARIO" Then
                    Me.dtpFechaFin.Text = ""
                End If
            End If
        End With
    End Sub

    Private Sub dtpFechaActivacion_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaActivacion.ValueChanged
        'If blnInicio = True Then Return
        'If Me.tab.SelectedIndex = 1 Then
        '    If Date.Compare(Me.dtpFechaFin.Value, Me.dtpFechaActivacion.Value) >= 0 Then
        '        Me.dtpFechaFin.Text = DateAdd("d", -1, dtpFechaActivacion.Value).ToString("dd/MM/yyyy")
        '    End If
        'End If
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Try
            Dim sAprobar As String
            If Me.RbtSi.Checked Then
                sAprobar = Me.LblAprobar.Text
            Else
                sAprobar = "Desaprobar"
            End If

            If Me.RbtSi.Checked Then
                If Date.Compare(Me.dtpFechaFin.Value, Me.dtpFechaActivacion.Text) >= 0 Then
                    MessageBox.Show("La Fecha Inicio " & Format(Me.dtpFechaActivacion.Value, "short date") & " de Nueva Cuenta debe ser mayor a la " & Chr(13) & "Fecha Fin " & Format(Me.dtpFechaFin.Value, "short date") & " de Cuenta Actual", "Aprobar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.dtpFechaFin.Focus()
                    Return
                End If
            Else
                If Me.TxtObservacion.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe Ingresar Motivo de la Desaprobación.", "Aprobar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtObservacion.Text = ""
                    Me.TxtObservacion.Focus()
                    Return
                End If
            End If

            Dim iRespuesta As DialogResult
            iRespuesta = MessageBox.Show("¿Está Seguro de " & sAprobar & " la Solicitud?", "Aprobar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If iRespuesta = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim intOpcion As Integer = IIf(Me.RbtSi.Checked, 1, 2)
                Aceptar(intOpcion)
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Aceptar(opcion As Integer)
        Try
            Dim objEN As New Cls_ClienteCarteraFuncionario_EN
            Dim objLN As New Cls_ClienteCarteraFuncionario_LN

            objEN.ID = Me.dgv.CurrentRow.Cells("id").Value
            objEN.Cliente = Me.dgv.CurrentRow.Cells("idcliente").Value
            objEN.Responsable = Me.dgv.CurrentRow.Cells("usuario_solicitud").Value
            objEN.Fecha = Me.dtpFechaActivacion.Value.Date.ToShortDateString
            objEN.Observaciones = Me.TxtObservacion.Text.Trim

            objEN.ResponsableActual = Me.dgv.CurrentRow.Cells("idresponsable").Value
            objEN.ResponsableFechaFin = Me.dtpFechaFin.Text

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            objLN.AprobarSolicitud(objEN, opcion)
            Me.ListarSolicitudes()
            tab.SelectedIndex = 0

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub CargarCartera(funcionario As Integer, dgv As DataGridView)
        Dim obj As New Cls_ClienteCarteraFuncionario_LN
        Dim dt As DataTable = obj.ListarCartera(funcionario)

        dgv.DataSource = dt
    End Sub

    Private Sub dgv1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        If e.ColumnIndex <> 0 Then Return

        Activar()
    End Sub

    Private Sub dgv1_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgv1.CurrentCellDirtyStateChanged
        dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Function ExisteCheck(ByVal dgv As DataGridView) As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsNothing(row.Cells(0).Value) Then
                If row.Cells(0).Value = 1 Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Sub SeleccionarCheckDgv(ByVal dgv As DataGridView, ByVal col As Integer, ByVal estado As Integer)
        For Each row As DataGridViewRow In dgv.Rows
            row.Cells(col).Value = estado
        Next
    End Sub

    Sub Controla(sender As Object, e As EventArgs) Handles cmbFuncionario1.SelectedIndexChanged, cmbFuncionario2.SelectedIndexChanged
        Dim strNombre As String = CType(sender, ComboBox).Name
        If strNombre = "cmbFuncionario1" Then
            CargarCartera(Me.cmbFuncionario1.SelectedValue, dgv1)
            Me.LblNumero1.Text = "0/" & Me.dgv1.Rows.Count
        Else
            CargarCartera(Me.cmbFuncionario2.SelectedValue, dgv2)
            Me.lblNumero2.Text = Me.dgv2.Rows.Count
        End If

        Activar()
    End Sub

    Private Sub btnSeleccionarTodo_Click(sender As System.Object, e As System.EventArgs) Handles btnSeleccionarTodo.Click
        SeleccionarCheckDgv(Me.dgv1, 0, 1)
        Activar()
    End Sub

    Private Sub btnEliminarSeleccion_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarSeleccion.Click
        SeleccionarCheckDgv(Me.dgv1, 0, 0)
        Activar()
    End Sub

    Sub Transferir()
        Dim objEN As New Cls_ClienteCarteraFuncionario_EN
        Dim objLN As New Cls_ClienteCarteraFuncionario_LN
        For Each row As DataGridViewRow In dgv1.Rows
            If Not IsNothing(row.Cells(0).Value) Then
                If row.Cells(0).Value = 1 Then
                    objEN.Cliente = Me.dgv.CurrentRow.Cells("idcliente").Value
                    objEN.ResponsableActual = Me.cmbFuncionario1.SelectedValue 'Me.dgv.CurrentRow.Cells("responsable_actual").Value
                    objEN.Responsable = Me.cmbFuncionario2.SelectedValue
                    'objEN.Fecha = row.Cells("fecha").Value

                    'objLN.TransferirCuenta(objEN)
                    'MessageBox.Show(row.Cells(1).Value)
                End If
            End If
        Next
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Dim lista As List(Of DataGridViewRow) = ObtenerListaCheck(dgv1, "sel")
        Dim frm As New frmTransferenciaCartera
        frm.Cargar(Me.cmbFuncionario1.SelectedValue, Me.cmbFuncionario1.Text, Me.cmbFuncionario2.SelectedValue, Me.cmbFuncionario2.Text, lista)
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            'Transferir()
            CargarCartera(Me.cmbFuncionario1.SelectedValue, dgv1)
            Me.LblNumero1.Text = "0/" & Me.dgv1.Rows.Count

            CargarCartera(Me.cmbFuncionario2.SelectedValue, dgv2)
            Me.lblNumero2.Text = Me.dgv2.Rows.Count

            Activar()
        End If
    End Sub

    Private Sub btnRetirar_Click(sender As System.Object, e As System.EventArgs) Handles btnRetirar.Click
        Dim lista As List(Of DataGridViewRow) = ObtenerListaCheck(dgv1, "sel")
        Dim frm As New frmRetirarClienteCartera
        frm.Cargar(Me.cmbFuncionario1.SelectedValue, lista)
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            CargarCartera(Me.cmbFuncionario1.SelectedValue, dgv1)
            Me.LblNumero1.Text = "0/" & Me.dgv1.Rows.Count

            CargarCartera(Me.cmbFuncionario2.SelectedValue, dgv2)
            Me.lblNumero2.Text = Me.dgv2.Rows.Count

            Activar()
        End If
    End Sub

    Sub Activar()
        Dim intNumero As Integer = NumeroCheck(dgv1)
        If intNumero > 0 And Me.cmbFuncionario2.SelectedValue > 0 And Me.cmbFuncionario1.SelectedValue <> Me.cmbFuncionario2.SelectedValue Then
            Me.btnAgregar.Enabled = True
        Else
            Me.btnAgregar.Enabled = False
        End If

        If intNumero > 0 Then
            Me.btnRetirar.Enabled = True
        Else
            Me.btnRetirar.Enabled = False
        End If

        Me.LblNumero1.Text = intNumero & "/" & dgv1.Rows.Count
    End Sub

    Function NumeroCheck(ByVal dgv As DataGridView) As Integer
        Dim intNumero As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsNothing(row.Cells(0).Value) Then
                If row.Cells(0).Value = 1 Then
                    intNumero += 1
                End If
            End If
        Next
        Return intNumero
    End Function

    Private Sub dtpFechaFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaFin.ValueChanged

    End Sub
End Class