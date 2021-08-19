Imports INTEGRACION_LN

Public Class frmTeleventa
    Dim dt As DataTable
    Sub FormatearDgvConversion()
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
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .HeaderText = "Cartera" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_llamadas As New DataGridViewTextBoxColumn
            With col_llamadas
                .Name = "llamadas" : .DataPropertyName = "llamadas"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Llamadas (I/O)"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_conversion1 As New DataGridViewTextBoxColumn
            With col_conversion1
                .Name = "conversion1" : .DataPropertyName = "conversion1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Conversión (Llamadas)" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_conversion2 As New DataGridViewTextBoxColumn
            With col_conversion2
                .Name = "conversion2" : .DataPropertyName = "conversion2"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Conversión (%)" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_conversion4 As New DataGridViewTextBoxColumn
            With col_conversion4
                .Name = "conversion4" : .DataPropertyName = "conversion4"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Conversión (%)" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_conversion3 As New DataGridViewTextBoxColumn
            With col_conversion3
                .Name = "conversion3" : .DataPropertyName = "conversion3"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Conversión (S/.)" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            .Columns.AddRange(col_usuario, col_llamadas, col_conversion1, col_conversion2, col_conversion4, col_conversion3)
        End With
    End Sub
    Sub FormatearDgvCierre()
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
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .HeaderText = "Cartera" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_conversion1 As New DataGridViewTextBoxColumn
            With col_conversion1
                .Name = "conversion1" : .DataPropertyName = "conversion1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Prospecto Trabajado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_conversion2 As New DataGridViewTextBoxColumn
            With col_conversion2
                .Name = "conversion2" : .DataPropertyName = "conversion2"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cierres (Nº Clientes)" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_eficiencia As New DataGridViewTextBoxColumn
            With col_eficiencia
                .Name = "eficiencia" : .DataPropertyName = "eficiencia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Eficiencia %"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_conversion3 As New DataGridViewTextBoxColumn
            With col_conversion3
                .Name = "conversion3" : .DataPropertyName = "conversion3"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Venta Nueva (S/.)" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_objetivo As New DataGridViewTextBoxColumn
            With col_objetivo
                .Name = "objetivo" : .DataPropertyName = "objetivo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Objetivo (S/.)" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_logro As New DataGridViewTextBoxColumn
            With col_logro
                .Name = "logro" : .DataPropertyName = "logro"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Logro (%)" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            .Columns.AddRange(col_usuario, col_conversion1, col_conversion2, col_eficiencia, col_conversion3, col_objetivo, col_logro)
        End With
    End Sub
    Sub FormatearDgvLlamadaResumen(opcion As Integer)
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
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .HeaderText = "Cartera" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_llamadas As New DataGridViewTextBoxColumn
            With col_llamadas
                .Name = "llamadas" : .DataPropertyName = "llamadas"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Llamadas Período" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_inbound As New DataGridViewTextBoxColumn
            With col_inbound
                .Name = "inbound" : .DataPropertyName = "inbound"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Llamadas I/B" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_outbound As New DataGridViewTextBoxColumn
            With col_outbound
                .Name = "outbound" : .DataPropertyName = "outbound"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Llamadas O/B" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_llamadasc As New DataGridViewTextBoxColumn
            With col_llamadasc
                .Name = "llamadasc" : .DataPropertyName = "llamadasc"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Llamadas Convertidas" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            If opcion = 1 Then
                x += +1
                Dim col_objetivo As New DataGridViewTextBoxColumn
                With col_objetivo
                    .Name = "objetivo" : .DataPropertyName = "objetivo"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Objetivo (Llamadas)" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
                End With
                x += +1
                Dim col_logro As New DataGridViewTextBoxColumn
                With col_logro
                    .Name = "logro" : .DataPropertyName = "logro"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Logro (%)" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
                End With
                .Columns.AddRange(col_usuario, col_llamadas, col_inbound, col_outbound, col_llamadasc, col_objetivo, col_logro)
            Else
                x += +1
                Dim col_objetivo As New DataGridViewTextBoxColumn
                With col_objetivo
                    .Name = "objetivo" : .DataPropertyName = "objetivo"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Conversión (%)" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
                End With
                .Columns.AddRange(col_usuario, col_llamadas, col_inbound, col_outbound, col_llamadasc, col_objetivo)
            End If
        End With
    End Sub
    Sub FormatearDgvLlamadaDia()
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
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .HeaderText = "Cartera" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_llamadas As New DataGridViewTextBoxColumn
            With col_llamadas
                .Name = "llamadas" : .DataPropertyName = "llamadas"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Llamadas Período" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_inbound As New DataGridViewTextBoxColumn
            With col_inbound
                .Name = "inbound" : .DataPropertyName = "inbound"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Llamadas I/B" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_outbound As New DataGridViewTextBoxColumn
            With col_outbound
                .Name = "outbound" : .DataPropertyName = "outbound"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Llamadas O/B" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_llamadasc As New DataGridViewTextBoxColumn
            With col_llamadasc
                .Name = "llamadasc" : .DataPropertyName = "llamadasc"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Llamadas Convertidas" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_objetivo As New DataGridViewTextBoxColumn
            With col_objetivo
                .Name = "objetivo" : .DataPropertyName = "objetivo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Conversión (%)" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ': .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            .Columns.AddRange(col_fecha, col_llamadas, col_inbound, col_outbound, col_llamadasc, col_objetivo)
        End With
    End Sub

    Sub ListarUsuario()
        Dim obj As New Cls_Televenta_LN
        With cboCartera
            .DisplayMember = "nombre"
            .ValueMember = "id"
            .DataSource = obj.ListarUsuario()
            .SelectedValue = 0
        End With
    End Sub

    Sub ListarFuente(usuario As Integer)
        Dim obj As New Cls_Televenta_LN
        With cboFuente
            .DisplayMember = "nombre"
            .ValueMember = "id"
            If usuario > 0 Then
                .DataSource = obj.ListarFuente(usuario)
            Else
                .DataSource = obj.ListarFuente()
            End If
            .SelectedValue = 0
        End With
    End Sub

    Private Sub frmTeleventa_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ListarUsuario()

        Me.dtpFechaInicio.Value = DateAdd(DateInterval.Day, -1, Me.dtpFechaInicio.Value)
    End Sub

    Private Sub cboCartera_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCartera.SelectedIndexChanged
        ListarFuente(cboCartera.SelectedValue)
    End Sub

    Private Sub rbtConversion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtConversion.CheckedChanged
        Me.dgvLista.DataSource = Nothing
        FormatearDgvConversion()
        Controlar(1)
        LimpiarReporte(1)
    End Sub

    Private Sub rbtCierre_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtCierre.CheckedChanged
        Me.dgvLista.DataSource = Nothing
        FormatearDgvCierre()
        Controlar(2)
        LimpiarReporte(2)
    End Sub

    Private Sub rbtLlamada_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtLlamada.CheckedChanged
        Me.dgvLista.DataSource = Nothing
        Controlar(3)
        If Me.rbtDia.Checked Then
            Me.cboGrupo.Visible = False
            FormatearDgvLlamadaDia()
        Else
            Me.cboGrupo.Visible = True
            Me.cboGrupo.SelectedIndex = 0
            FormatearDgvLlamadaResumen(1)
        End If
        Dim intOpcion As Integer
        If Me.rbtDia.Checked Then
            intOpcion = 5
        Else
            intOpcion = IIf(Me.cboGrupo.SelectedIndex = 0, 3, 4)
        End If
        LimpiarReporte(intOpcion)
    End Sub

    Sub Controlar(opcion As Integer)
        If opcion = 3 Then
            Me.rbtDia.Visible = True
            Me.rbtResumen.Visible = True
            Me.cboGrupo.Visible = True
        Else
            Me.rbtDia.Visible = False
            Me.rbtResumen.Visible = False
            Me.cboGrupo.Visible = False
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

    Sub Consultar()
        Try
            Dim intOpcion2 As Integer
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Televenta_LN
            If Me.rbtConversion.Checked Then
                dt = obj.ListarConversion(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, cboCartera.SelectedValue, _
                                     cboFuente.SelectedValue, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                intOpcion2 = 1
            ElseIf Me.rbtCierre.Checked Then
                dt = obj.ListarCierre(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, cboCartera.SelectedValue, _
                                      cboFuente.SelectedValue, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                intOpcion2 = 2
            Else
                Dim intOpcion As Integer
                If Me.rbtResumen.Checked Then
                    intOpcion = IIf(Me.cboGrupo.SelectedIndex = 0, 2, 3)
                Else
                    intOpcion = 1
                End If

                dt = obj.ListarLlamada(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, cboCartera.SelectedValue, _
                                       cboFuente.SelectedValue, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, intOpcion)
                If Me.rbtResumen.Checked Then
                    intOpcion2 = IIf(Me.cboGrupo.SelectedIndex = 0, 3, 4)
                Else
                    intOpcion2 = 5
                End If
            End If
            Me.dgvLista.DataSource = dt
            Me.tsbExportar.Enabled = Me.dgvLista.Rows.Count > 0
            Resumen(intOpcion2)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Televentas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtDia_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtDia.CheckedChanged
        If Me.rbtLlamada.Checked Then
            Me.dgvLista.DataSource = Nothing
            FormatearDgvLlamadaDia()
            LimpiarReporte(5)
            Me.cboGrupo.Visible = False
        End If
    End Sub

    Private Sub rbtResumen_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtResumen.CheckedChanged
        If Me.rbtLlamada.Checked Then
            Me.dgvLista.DataSource = Nothing
            FormatearDgvLlamadaResumen(IIf(Me.cboGrupo.SelectedIndex = 0, 1, 2))
            LimpiarReporte(IIf(Me.cboGrupo.SelectedIndex = 0, 3, 4))
            Me.cboGrupo.Visible = True
            'Me.cboGrupo.SelectedIndex = 0
        End If
    End Sub

    Sub LimpiarReporte(opcion As Integer)
        Me.tsbExportar.Enabled = False
        If opcion = 1 Then
            Me.lbl11.Text = "0" : Me.lbl12.Text = "0" : Me.lbl13.Text = "0" : Me.lbl14.Text = "0" : Me.lbl15.Text = "0.00"
            Me.Panel2.Visible = False
            Me.Panel3.Visible = False
            Me.Panel1.Visible = True
        ElseIf opcion = 2 Then
            Me.lbl21.Text = "0" : Me.lbl22.Text = "0" : Me.lbl23.Text = "0" : Me.lbl24.Text = "0" : Me.lbl25.Text = "0.00"
            Me.Panel1.Visible = False
            Me.Panel3.Visible = False
            Me.Panel2.Visible = True
        ElseIf opcion >= 3 Then
            Me.lbl31.Text = "0" : Me.lbl32.Text = "0" : Me.lbl33.Text = "0" : Me.lbl34.Text = "0" : Me.lbl35.Text = "0.00" : Me.lbl36.Text = "0"

            If opcion = 3 Then
                Me.Label9.Visible = True : Me.lbl35.Visible = True
                Me.Label7.Text = "Objetivo"
            Else
                Me.Label9.Visible = False : Me.lbl35.Visible = False
                Me.Label7.Text = "Conversión"
            End If

            Me.Panel1.Visible = False
            Me.Panel2.Visible = False
            Me.Panel3.Visible = True
        End If
    End Sub

    Sub Resumen(opcion As Integer)
        Dim intValor1 As Integer, intValor2 As Integer, dblValor1 As Double, dblValor2 As Double
        With dgvLista
            If opcion = 1 Then
                intValor1 = IIf(IsDBNull(dt.Compute("sum(llamadas)", "")), 0, dt.Compute("sum(llamadas)", ""))
                Me.lbl11.Text = Format(intValor1, "###,###,###")
                intValor2 = IIf(IsDBNull(dt.Compute("sum(conversion1)", "")), 0, dt.Compute("sum(conversion1)", ""))
                Me.lbl12.Text = intValor2
                dblValor1 = IIf(IsDBNull(dt.Compute("sum(conversion3)", "")), 0, dt.Compute("sum(conversion3)", ""))
                Me.lbl14.Text = Format(dblValor1, "###,###,###0.00")

                'intValor1 = Me.dgvLista.Rows.Count
                'dblValor1 = IIf(IsDBNull(dt.Compute("sum(conversion2)", "")), 0, dt.Compute("sum(conversion2)", ""))
                Me.lbl13.Text = Format(Math.Round(intValor2 / IIf(intValor1 = 0, 1, intValor1) * 100, 2), "0.00")

                'dblValor1 = IIf(IsDBNull(dt.Compute("sum(conversion4)", "")), 0, dt.Compute("sum(conversion4)", ""))
                'Me.lbl15.Text = Format(Math.Round(dblValor1 / IIf(intValor1 = 0, 1, intValor1), 2), "0.00")

            ElseIf opcion = 2 Then
                intValor1 = IIf(IsDBNull(dt.Compute("sum(conversion1)", "")), 0, dt.Compute("sum(conversion1)", ""))
                Me.lbl21.Text = Format(intValor1, "###,###,###")
                intValor2 = IIf(IsDBNull(dt.Compute("sum(conversion2)", "")), 0, dt.Compute("sum(conversion2)", ""))
                Me.lbl22.Text = intValor2
                dblValor1 = IIf(IsDBNull(dt.Compute("sum(conversion3)", "")), 0, dt.Compute("sum(conversion3)", ""))
                Me.lbl24.Text = Format(dblValor1, "###,###,###0.00")

                Me.lbl23.Text = Format(Math.Round(intValor2 / IIf(intValor1 = 0, 1, intValor1) * 100, 2), "0.00")

                intValor1 = IIf(IsDBNull(dt.Compute("sum(objetivo)", "")), 0, dt.Compute("sum(objetivo)", ""))
                Me.lbl25.Text = Format(Math.Round(IIf(intValor1 = 0, 0, dblValor1 / IIf(intValor1 = 0, 1, intValor1) * 100), 2), "0.00")

            ElseIf opcion >= 3 Then
                intValor1 = IIf(IsDBNull(dt.Compute("sum(inbound)", "")), 0, dt.Compute("sum(inbound)", ""))
                Me.lbl32.Text = Format(intValor1, "###,###,###")
                intValor1 = IIf(IsDBNull(dt.Compute("sum(outbound)", "")), 0, dt.Compute("sum(outbound)", ""))
                Me.lbl33.Text = Format(intValor1, "###,###,###")
                intValor1 = IIf(IsDBNull(dt.Compute("sum(llamadas)", "")), 0, dt.Compute("sum(llamadas)", ""))
                Me.lbl31.Text = Format(intValor1, "###,###,###")

                If opcion = 3 Then
                    intValor1 = IIf(IsDBNull(dt.Compute("sum(objetivo)", "")), 0, dt.Compute("sum(objetivo)", ""))
                    Me.lbl34.Text = Format(intValor1, "###,###,###0")
                End If

                intValor2 = IIf(IsDBNull(dt.Compute("sum(llamadasc)", "")), 0, dt.Compute("sum(llamadasc)", ""))
                Me.lbl36.Text = Format(intValor2, "###,###,###")

                If opcion >= 4 Then
                    Me.lbl34.Text = Format(intValor2 / IIf(intValor1 = 0, 1, intValor1) * 100, "###,###,###0.00")
                End If

                Me.lbl35.Text = Format(IIf(intValor1 = 0, 0, intValor2 / IIf(intValor1 = 0, 1, intValor1) * 100), "0.00")
                End If
        End With
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub tsbExportar_Click(sender As System.Object, e As System.EventArgs) Handles tsbExportar.Click
        Exportar()
    End Sub

    Sub Exportar()
        Dim xlApp As New Excel.Application()
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        Try
            Cursor = Cursors.AppStarting
            Dim rowIndex, colIndex, i, j As Integer
            rowIndex = 1
            colIndex = 0
            xlBook = xlApp.Workbooks().Add
            xlSheet = xlBook.Worksheets("hoja1")

            For i = 0 To dgvLista.Columns().Count - 1
                If dgvLista.Columns().Item(i).Visible = True Then
                    colIndex = colIndex + 1
                    'xlApp.Cells(1, colIndex) = dgvResultado.Columns().Item(i).DataPropertyName
                    'If i > 3 Then
                    'xlApp.Cells(1, colIndex) = " " & dgvResultado.Columns().Item(i).HeaderText
                    'Else
                    xlApp.Cells(1, colIndex) = dgvLista.Columns().Item(i).HeaderText
                    'End If
                End If
            Next
            For i = 0 To dgvLista.Rows().Count - 1
                rowIndex = rowIndex + 1
                colIndex = 0

                For j = 0 To dgvLista.Columns().Count - 1
                    If dgvLista.Columns().Item(j).Visible = True Then
                        colIndex = colIndex + 1
                        xlApp.Cells(rowIndex, colIndex) = dgvLista.Rows(i).Cells(j).Value
                    End If
                Next
            Next
            With xlSheet
                '.Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Name = "Arial"
                .Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Bold = True
                .Range(.Cells(1, 1), .Cells(1, colIndex)).NumberFormat = "###,###,###0.00"
                .Columns.AutoFit()
                '.Range(.Cells(1, 1), .Cells(rowIndex, colIndex)).Borders.LineStyle = 1
            End With
            Cursor = Cursors.Default
            xlApp.Visible = True
            xlApp.UserControl = False

            xlSheet = Nothing
            xlBook = Nothing
            'xlApp.Quit()
            xlApp = Nothing

        Catch ex As Exception
            xlSheet = Nothing
            xlBook = Nothing
            'xlApp.Quit()
            xlApp = Nothing
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsbAnular.Click
        Dim frm As New frmTeleventaConfiguracion
        frm.ShowDialog()
    End Sub

    Private Sub tsbVer_Click(sender As System.Object, e As System.EventArgs) Handles tsbVer.Click
        Dim frm As New frmTeleventasVer
        frm.Left = 0
        frm.Top = 0
        frm.MdiParent = Principal
        frm.Show()
    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrupo.SelectedIndexChanged
        Me.rbtResumen_CheckedChanged(Nothing, Nothing)
    End Sub

End Class