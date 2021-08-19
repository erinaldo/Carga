Imports System.Data.OleDb

Public Class frmHoraExtraPlan
#Region "Publico"
    Public Shared dtHora As DataTable
    Dim dt As DataTable
    Dim dtHorario As New DataTable
    'Dim intDia As Integer
    Dim blnNuevo As Boolean
    Dim strFechaOriginal As String
#End Region
#Region "Propiedades"
    Private strFecha As String
    Public Property Fecha() As String
        Get
            Return strFecha
        End Get
        Set(ByVal value As String)
            strFecha = value
        End Set
    End Property

    Private strCodigo As String
    Public Property Codigo() As String
        Get
            Return strCodigo
        End Get
        Set(ByVal value As String)
            strCodigo = value
        End Set
    End Property

    Private strHorario As String
    Public Property Horario() As String
        Get
            Return strHorario
        End Get
        Set(ByVal value As String)
            strHorario = value
        End Set
    End Property

    Private strTrabajador As String
    Public Property Trabajador() As String
        Get
            Return strTrabajador
        End Get
        Set(ByVal value As String)
            strTrabajador = value
        End Set
    End Property

    Private dblRemuneracion As Double
    Public Property Remuneracion() As Double
        Get
            Return dblRemuneracion
        End Get
        Set(ByVal value As Double)
            dblRemuneracion = value
        End Set
    End Property

    Private dtHoraExtra As DataTable
    Public Property HoraExtra() As DataTable
        Get
            Return dtHoraExtra
        End Get
        Set(ByVal value As DataTable)
            dtHoraExtra = value
        End Set
    End Property

    Private intEstado As Integer
    Public Property Estado() As Integer
        Get
            Return intEstado
        End Get
        Set(ByVal value As Integer)
            intEstado = value
        End Set
    End Property

    Private dColor As Color
    Public Property Color() As Color
        Get
            Return dColor
        End Get
        Set(ByVal value As Color)
            dColor = value
        End Set
    End Property

#End Region
    Sub ConfigurarDTHora()
        If dtHora.Columns.Count > 0 Then Return
        With Me.dgvHora
            Dim col As DataColumn
            dtHora = New DataTable
            For i As Integer = 0 To .Columns.Count - 1
                col = New DataColumn
                col.ColumnName = .Columns(i).Name
                col.Caption = .Columns(i).HeaderText
                dtHora.Columns.Add(col)
            Next
        End With
    End Sub

    Sub ConfigurardgvHora()
        With dgvHora
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF
            Dim x As Integer
            x = 0
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo" : .DisplayIndex = x : .Visible = False : .HeaderText = "Código"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_motivo As New DataGridViewTextBoxColumn
            With col_motivo
                .Name = "motivo" : .DataPropertyName = "motivo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Motivo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_compensacion As New DataGridViewTextBoxColumn
            With col_compensacion
                .Name = "compensacion" : .DataPropertyName = "compensacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Compensación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_inicio As New DataGridViewTextBoxColumn
            With col_inicio
                .Name = "inicio" : .DataPropertyName = "inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fin As New DataGridViewTextBoxColumn
            With col_fin
                .Name = "fin" : .DataPropertyName = "fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_hora As New DataGridViewTextBoxColumn
            With col_hora
                .Name = "hora" : .DataPropertyName = "hora"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_costo As New DataGridViewTextBoxColumn
            With col_costo
                .Name = "costo" : .DataPropertyName = "costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Costo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_tipo_dia As New DataGridViewTextBoxColumn
            With col_tipo_dia
                .Name = "tipo_dia" : .DataPropertyName = "tipo_dia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Día"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_ingreso As New DataGridViewTextBoxColumn
            With col_ingreso
                .Name = "ingreso" : .DataPropertyName = "ingreso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_salida As New DataGridViewTextBoxColumn
            With col_salida
                .Name = "salida" : .DataPropertyName = "salida"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_actividad As New DataGridViewTextBoxColumn
            With col_actividad
                .Name = "actividad" : .DataPropertyName = "actividad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Actividad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_motivo As New DataGridViewTextBoxColumn
            With col_id_motivo
                .Name = "id_motivo" : .DataPropertyName = "id_motivo" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_motivo"
            End With
            x += +1
            Dim col_id_compensacion As New DataGridViewTextBoxColumn
            With col_id_compensacion
                .Name = "id_compensacion" : .DataPropertyName = "id_compensacion" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_compensacion"
            End With
            x += +1
            Dim col_id_tipo_dia As New DataGridViewTextBoxColumn
            With col_id_tipo_dia
                .Name = "id_tipo_dia" : .DataPropertyName = "id_tipo_dia" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_tipo_dia"
            End With
            x += +1
            Dim col_hora25 As New DataGridViewTextBoxColumn
            With col_hora25
                .Name = "hora25" : .DataPropertyName = "hora25"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Horas 25%"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_hora35 As New DataGridViewTextBoxColumn
            With col_hora35
                .Name = "hora35" : .DataPropertyName = "hora35"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Horas 35%"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_hora100 As New DataGridViewTextBoxColumn
            With col_hora100
                .Name = "hora100" : .DataPropertyName = "hora100"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Nº Horas 100%"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_costo25 As New DataGridViewTextBoxColumn
            With col_costo25
                .Name = "costo25" : .DataPropertyName = "costo25"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Costo 25%"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_costo35 As New DataGridViewTextBoxColumn
            With col_costo35
                .Name = "costo35" : .DataPropertyName = "costo35"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Costo 35%"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_costo100 As New DataGridViewTextBoxColumn
            With col_costo100
                .Name = "costo100" : .DataPropertyName = "costo100"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Costo 100%"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_codigo, col_fecha, col_motivo, col_compensacion, col_inicio, col_fin, col_hora, col_costo, col_tipo_dia, _
                              col_ingreso, col_salida, col_actividad, col_id_motivo, col_id_compensacion, col_id_tipo_dia, _
                              col_hora25, col_hora35, col_hora100, col_costo25, col_costo35, col_costo100, col_id_estado, col_estado)
        End With
    End Sub

    Sub Inicio()
        blnNuevo = True
        ConfigurardgvHora()
        ConfigurarDTHora()
        Dim dtMotivo As DataTable = ListarTipoControl(18, 2)
        With cboMotivo
            .DisplayMember = "descripcion"
            .ValueMember = "codigo"
            .DataSource = dtMotivo
            .SelectedValue = 0
        End With
        Me.cboCompensacion.SelectedIndex = 0
        Me.lblFecha.Text = Fecha
        Me.Text = "Horas Extras - " & Codigo & " " & Trabajador
    End Sub

    Private Sub frmHoraExtraPlan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Inicio()
            Dim blnFeriado As Boolean = EsFeriado(Fecha)
            dtHorario = ListarHorario(Horario, Codigo)
            Dim intDia As Integer = CType(Fecha, Date).DayOfWeek
            Dim blnDescanso As Boolean = dtHorario.Rows(0).Item(intDia) = 1

            Me.lblTipoDia.Text = IIf(blnDescanso Or blnFeriado, "DOBLE", "SIMPLE")
            AsignarHorario(intDia)
            Me.dgvHora.DataSource = dtHora
            dt = dtHora.Copy

            If Me.dgvHora.Rows.Count > 0 Then
                Mostrar(0)
                blnNuevo = False
            End If
            Total()

            Me.lblEstadoFiltro.Visible = False
            Me.cboEstadoFiltro.Visible = False
            If Estado > 1 Then 'planificacion aprobada
                Me.btnAgregar.Enabled = False
                Me.btnNuevo.Enabled = False
                Me.btnEliminar.Enabled = False
                Me.btnAceptar.Enabled = False
            Else 'planificacion pendiente
                Dim intEstado As Integer
                If Color = Drawing.Color.White Then
                    intEstado = 1
                    Me.lblEstado.Text = "PENDIENTE"
                ElseIf Color = Drawing.Color.Silver Then
                    intEstado = 2
                    Me.lblEstado.Text = "APROBADO"
                ElseIf Color = Drawing.Color.Red Then
                    intEstado = 3
                    Me.lblEstado.Text = "DESAPROBADO"
                End If
                If intEstado = 2 Then
                    Me.btnAgregar.Enabled = False
                    Me.btnNuevo.Enabled = False
                    Me.btnEliminar.Enabled = False
                    Me.btnAceptar.Enabled = False
                    Me.cboMotivo.Enabled = False
                    Me.cboCompensacion.Enabled = False
                    Me.dtpInicio.Enabled = False
                    Me.dtpFin.Enabled = False
                ElseIf intEstado = 3 Then
                    Me.lblEstadoFiltro.Visible = True
                    Me.cboEstadoFiltro.Visible = True
                    Me.cboEstadoFiltro.SelectedIndex = 1
                Else
                    Me.btnAceptar.Enabled = Me.dgvHora.Rows.Count > 0
                End If
            End If
            Accion()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AsignarHorario(ByVal dia As Integer)
        MostrarHorario(dia, Me.lblIngreso, Me.lblSalida, dtHorario)
        Me.dtpInicio.Value = Format(CType(Me.dtpInicio.Value.ToShortDateString & " " & Me.lblSalida.Text, Date), "").ToString
        Me.dtpFin.Value = Me.dtpInicio.Value
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If Me.cboMotivo.SelectedValue = 0 Then
            MessageBox.Show("Seleccione el motivo", "Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboMotivo.Focus()
            Me.cboMotivo.DroppedDown = True
            Return
        End If
        If Me.cboCompensacion.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el tipo de  compensación", "Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboCompensacion.Focus()
            Me.cboCompensacion.DroppedDown = True
            Return
        End If
        If Me.dtpInicio.Value = Me.dtpFin.Value Then
            MessageBox.Show("La Hora inicio no puede ser igual a la Hora fin", "Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpInicio.Focus()
            Return
        End If
        If Me.dtpInicio.Value > Me.dtpFin.Value Then
            MessageBox.Show("La Hora inicio no puede ser mayor a la Hora fin", "Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpInicio.Focus()
            Return
        End If
        If DateDiff(DateInterval.Minute, Me.dtpInicio.Value, Me.dtpFin.Value) < 30 Then
            MessageBox.Show("El sobretiempo debe ser a partir de media hora", "Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpInicio.Focus()
            Return
        End If
        If Me.txtActividad.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el detalle de las actividades a realizar", "Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtActividad.Text = ""
            Me.txtActividad.Focus()
            Return
        End If

        If Validar() Then
            Agregar()
            Total()
        End If
    End Sub

    Sub Total()
        Me.lblTotalCosto.Text = Format(SumaGrid2(Me.dgvHora, "costo"), "0.00")
        Me.lblTotalHoras.Text = SumaHoras(Me.dgvHora, "hora")

        Me.lblcosto25.Text = Format(SumaGrid2(Me.dgvHora, "costo25"), "0.00")
        Me.lblcosto35.Text = Format(SumaGrid2(Me.dgvHora, "costo35"), "0.00")
        Me.lblcosto100.Text = Format(SumaGrid2(Me.dgvHora, "costo100"), "0.00")

        Me.lblhora25.Text = SumaHoras(Me.dgvHora, "hora25")
        Me.lblhora35.Text = SumaHoras(Me.dgvHora, "hora35")
        Me.lblhora100.Text = SumaHoras(Me.dgvHora, "hora100")

        If Val(Me.lblhora100.Text) > 0 Then
            Me.lblhora100.ForeColor = Color.Red
            Me.lblcosto100.ForeColor = Color.Red
        Else
            Me.lblhora100.ForeColor = Color.Black
            Me.lblcosto100.ForeColor = Color.Black
        End If

        If Val(Me.lblhora35.Text) > 0 Then
            Me.lblhora35.ForeColor = Color.Orange
            Me.lblcosto35.ForeColor = Color.Orange
        Else
            Me.lblhora35.ForeColor = Color.Black
            Me.lblcosto35.ForeColor = Color.Black
        End If
    End Sub

    Function Validar() As Boolean
        Dim blnOK As Boolean
        Dim fecha1 As Date, fecha2 As Date, fechagrid1 As Date, fechagrid2 As Date, fechahorario1 As Date, fechahorario2 As Date
        With Me.dgvHora
            blnOK = True
            If Me.lblTipoDia.Text <> "DOBLE" Then
                If Me.lblIngreso.Text.Trim.Length > 0 And Me.lblSalida.Text.Trim.Length > 0 Then
                    fecha1 = Me.dtpInicio.Value
                    fecha2 = Me.dtpFin.Value
                    fechahorario1 = Me.dtpInicio.Value.ToShortDateString & " " & Format(CType(Me.lblIngreso.Text, Date), "HH:mm")
                    fechahorario2 = Me.dtpInicio.Value.ToShortDateString & " " & Format(CType(Me.lblSalida.Text, Date), "HH:mm")
                    If fecha1 <> fechahorario1 Then
                        If fecha1 < fechahorario1 Then
                            If fecha2 <= fechahorario1 Then
                                blnOK = True
                            Else
                                blnOK = False
                            End If
                        ElseIf fecha1 > fechahorario1 Then
                            If fecha1 >= fechahorario2 Then
                                blnOK = True
                            Else
                                blnOK = False
                            End If
                        End If
                    Else
                        blnOK = False
                    End If
                End If
                If Not blnOK Then
                    MessageBox.Show("El trabajador no puede realizar sobretiempo dentro de su horario", "Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dtpInicio.Focus()
                End If
            End If
            If blnOK Then
                Dim blnPasa As Boolean
                For Each row As DataGridViewRow In .Rows
                    blnPasa = True
                    If Not blnNuevo Then
                        If .CurrentCell.RowIndex = row.Index Then
                            blnPasa = False
                        End If
                    End If
                    If blnPasa Then
                        fechagrid1 = Me.dtpInicio.Value.ToShortDateString & " " & Format(CType(row.Cells("inicio").Value, Date), "HH:mm")
                        fechagrid2 = Me.dtpInicio.Value.ToShortDateString & " " & Format(CType(row.Cells("fin").Value, Date), "HH:mm")
                        If fecha1 <> fechagrid1 Then
                            If fecha1 < fechagrid1 Then
                                If fecha2 <= fechagrid1 Then
                                    blnOK = True
                                Else
                                    blnOK = False
                                    Exit For
                                End If
                            ElseIf fecha1 > fechagrid1 Then
                                If fecha1 >= fechagrid2 Then
                                    blnOK = True
                                Else
                                    blnOK = False
                                    Exit For
                                End If
                            Else
                                blnOK = False
                                Exit For
                            End If
                        Else
                            blnOK = False
                            Exit For
                        End If
                    End If
                Next
                If Not blnOK Then
                    MessageBox.Show("El horario de sobretiempo ya existe", "Horas Extras", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dtpInicio.Focus()
                End If
            End If
        End With
        Return blnOK
    End Function

    Private Sub dtpFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFin.KeyPress, dtpInicio.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub dtpInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicio.ValueChanged, dtpFin.ValueChanged
        Try
            Dim strInicio As String = CType(Me.dtpInicio.Value, Date).ToShortDateString
            Dim strFin As String = CType(Me.dtpFin.Value, Date).ToShortDateString
            If CDate(strInicio).ToShortDateString <> Now.ToShortDateString Then
                Me.dtpInicio.Value = Now.ToShortDateString & " " & Format(Me.dtpInicio.Value, "HH:mm")
            End If
            If CDate(strFin).ToShortDateString <> Now.ToShortDateString Then
                Me.dtpFin.Value = Now.ToShortDateString & " " & Format(Me.dtpFin.Value, "HH:mm")
            End If

            Dim intMinutos As Integer, intHoras As Integer
            intHoras = DateDiff(DateInterval.Hour, Me.dtpInicio.Value, Me.dtpFin.Value)
            intMinutos = DateDiff(DateInterval.Minute, Me.dtpInicio.Value, Me.dtpFin.Value)
            intMinutos = intMinutos - (intHoras * 60)
            If intMinutos > 0 Then
                If intMinutos < 30 Then
                    intMinutos = 0
                ElseIf intMinutos > 30 Then
                    intMinutos = 30
                End If
            End If
            Me.lblHoras.Text = Format(intHoras, "00") & ":" & Format(intMinutos, "00")
            If Me.cboCompensacion.SelectedIndex = 1 Then
                Me.lblCosto.Text = Format(CalcularHE(), "0.00")
            Else
                Me.lblCosto.Text = "0.00"
            End If
        Catch
        End Try
    End Sub

    Private Sub txtActividad_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtActividad.Enter
        Me.txtActividad.SelectAll()
    End Sub

    Private Sub txtActividad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtActividad.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            Me.btnAgregar.Focus()
        Else
            e.Handled = Me.btnAgregar.Enabled = False
        End If
    End Sub

    Private Sub txtActividad_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtActividad.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Me.btnAceptar.Enabled = False
        Nuevo()
    End Sub

    Sub Nuevo()
        blnNuevo = True
        Me.cboMotivo.SelectedValue = 0
        Me.cboCompensacion.SelectedIndex = 0

        Dim intDia As Integer = CType(Fecha, Date).DayOfWeek
        AsignarHorario(intDia)

        Me.txtActividad.Text = ""

        Me.btnAgregar.Enabled = True
        If Me.dgvHora.Rows.Count > 0 Then
            Me.btnEliminar.Enabled = Me.dgvHora.CurrentRow.Cells("id_estado").Value = 1
        Else
            Me.btnEliminar.Enabled = False
        End If

        Me.cboMotivo.Enabled = True
        Me.cboCompensacion.Enabled = True
        Me.dtpInicio.Enabled = True
        Me.dtpFin.Enabled = True

        Me.cboMotivo.Focus()
        Accion()
    End Sub

    Function NumeroEstado() As Integer
        With Me.dgvHora
            Dim intEstado As Integer = 0, contador As Integer = 1
            For Each row As DataGridViewRow In .Rows
                If intEstado > 0 Then
                    If intEstado <> row.Cells("id_estado").Value Then
                        contador += 1
                    End If
                End If
                intEstado = row.Cells("id_estado").Value
            Next
            Return contador
        End With
    End Function

    Private Sub dgvHora_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvHora.RowsAdded
        If Me.cboEstadoFiltro.Visible Then
            If Me.cboEstadoFiltro.SelectedIndex = 0 Then
                Me.btnEliminar.Enabled = True
                Me.btnAceptar.Enabled = True
            Else
                Me.btnEliminar.Enabled = False
                Me.btnAceptar.Enabled = False
            End If
        Else
            Me.btnEliminar.Enabled = True
            Me.btnAceptar.Enabled = True
        End If
    End Sub

    Private Sub dgvHora_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvHora.RowsRemoved
        If Me.cboEstadoFiltro.Visible Then
            If Me.cboEstadoFiltro.SelectedIndex = 0 Then
                Me.btnEliminar.Enabled = Me.dgvHora.Rows.Count > 0
                Me.btnAceptar.Enabled = Me.dgvHora.Rows.Count > 0
            Else
                Me.btnEliminar.Enabled = False
                Me.btnAceptar.Enabled = False
            End If
        Else
            Me.btnEliminar.Enabled = Me.dgvHora.Rows.Count > 0
            Me.btnAceptar.Enabled = Me.dgvHora.Rows.Count > 0
        End If
    End Sub

    Private Sub cboMotivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMotivo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub cboCompensacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCompensacion.KeyPress
        SendKeys.Send("{Tab}")
    End Sub

    Sub Mostrar(ByVal fila As Integer)
        With Me.dgvHora
            Me.cboMotivo.SelectedValue = .Rows(fila).Cells("id_motivo").Value
            Me.cboCompensacion.SelectedIndex = .Rows(fila).Cells("id_compensacion").Value
            Me.dtpInicio.Value = Me.dtpInicio.Value.ToShortDateString & " " & Format(CType(dgvHora.Rows(fila).Cells("inicio").Value, Date), "HH:mm")
            strFechaOriginal = Format(CType(dgvHora.Rows(fila).Cells("inicio").Value, Date), "HH:mm")

            Me.dtpFin.Value = Me.dtpFin.Value.ToShortDateString & " " & Format(CType(dgvHora.Rows(fila).Cells("fin").Value, Date), "HH:mm")
            Me.txtActividad.Text = .Rows(fila).Cells("actividad").Value
        End With
    End Sub

    Private Sub dgvHora_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHora.RowEnter
        If IsNothing(dgvHora.CurrentRow) Then Return
        Mostrar(e.RowIndex)
        Me.btnEliminar.Enabled = Me.dgvHora.Rows(e.RowIndex).Cells("id_estado").Value = 1
        blnNuevo = False
        Accion()
    End Sub

    Sub Agregar()
        With dtHora
            Dim row As DataRow
            row = dtHora.NewRow
            row.Item(0) = Codigo
            row.Item(1) = Me.lblFecha.Text
            row.Item(2) = cboMotivo.Text
            row.Item(3) = cboCompensacion.Text
            row.Item(4) = dtpInicio.Text
            row.Item(5) = dtpFin.Text
            row.Item(6) = Me.lblHoras.Text
            row.Item(7) = Me.lblCosto.Text
            row.Item(8) = Me.lblTipoDia.Text
            row.Item(9) = Me.lblIngreso.Text
            row.Item(10) = Me.lblSalida.Text
            row.Item(11) = Me.txtActividad.Text.Trim
            row.Item(12) = Me.cboMotivo.SelectedValue
            row.Item(13) = Me.cboCompensacion.SelectedIndex
            row.Item(14) = IIf(Me.lblTipoDia.Text.Substring(0, 1) = "S", 1, 2)
            row.Item(21) = 1
            row.Item(22) = "PENDIENTE"
            If Not blnNuevo Then
                Dim rows() As DataRow
                rows = dtHora.Select("inicio='" & strFechaOriginal & "'")
                rows(0).Delete()
                dtHora.AcceptChanges()
            End If
            dtHora.Rows.Add(row)
            dtHora.AcceptChanges()
            If Me.cboCompensacion.SelectedIndex = 1 Then 'efectivo
                If row.Item(14) = 1 Then
                    Me.CalcularHESubtotal()
                Else
                    row.Item("hora100") = Me.lblHoras.Text
                    row.Item("costo100") = Me.lblCosto.Text
                End If
            End If
        End With
        Nuevo()
    End Sub

    Sub CalcularHESubtotal()
        Dim dbl25 As Double = 0, dbl35 As Double = 0, dblMonto As Double = 0, dblDiferencia As Double = 0
        Dim intHoras As Integer, intMinutos As Integer
        Dim dblTiempo As Double = 0
        Dim dblRemuneracion As Double
        dblRemuneracion = Remuneracion / 240
        Dim dv As New DataView
        dv = dtHora.DefaultView
        dv.Sort = "inicio"
        dtHora = dv.ToTable
        Dim dblTotal As Double
        For i As Integer = 0 To dtHora.Rows.Count - 1
            If dtHora.Rows(i).Item("compensacion").ToString.Substring(0, 1) = "E" Then
                intHoras = CType(dtHora.Rows(i)("hora").ToString.Substring(0, 2), Integer)
                intMinutos = CType(dtHora.Rows(i)("hora").ToString.Substring(3, 2), Integer)
                dblTiempo = intHoras + (intMinutos / 60)

                dbl25 += dblTiempo
                dblDiferencia = dbl25 - 2
                If dblDiferencia > 0 Then
                    dbl35 = dblDiferencia
                End If
                dbl25 = dblTiempo - IIf(dblDiferencia < 0, 0, dblDiferencia)

                dtHora.Rows(i).Item("hora25") = Format(dbl25, "00.00").Substring(0, 2) & ":" & Format(dbl25, "00.00").Substring(3, 2)
                dtHora.Rows(i).Item("hora35") = Format(dbl35, "00.00").Substring(0, 2) & ":" & Format(dbl35, "00.00").Substring(3, 2)

                dtHora.Rows(i).Item("hora25") = dtHora.Rows(i).Item("hora25").ToString.Replace("50", "30")
                dtHora.Rows(i).Item("hora35") = dtHora.Rows(i).Item("hora35").ToString.Replace("50", "30")


                dtHora.Rows(i).Item("costo25") = Format(dbl25 * dblRemuneracion * 0.25, "0.00")
                dtHora.Rows(i).Item("costo35") = Format(dbl35 * dblRemuneracion * 0.35, "0.00")

                dblTotal = CDbl(dtHora.Rows(i).Item("costo25")) + CDbl(dtHora.Rows(i).Item("costo35"))
                dtHora.Rows(i).Item("costo") = Format(dblTotal, "0.00")
            End If
        Next
        dtHora.AcceptChanges()
        Me.dgvHora.DataSource = dtHora
    End Sub

    Function CalcularHE() As Double
        Dim dblRemuneracion As Double
        Dim intTipoDia As Integer
        Dim intHoras As Integer, intMinutos As Integer
        Dim dblTiempo As Double
        Dim dblCosto As Double, dblDiferencia As Double

        dblRemuneracion = Remuneracion / 240
        intTipoDia = IIf(Me.lblTipoDia.Text.Substring(0, 1) = "S", 1, 2)
        intHoras = CType(Me.lblHoras.Text.Substring(0, 2), Integer)
        intMinutos = CType(Me.lblHoras.Text.Substring(3, 2), Integer)
        dblTiempo = intHoras + (intMinutos / 60)
        If intTipoDia = 1 Then 'simple
            If dblTiempo <= 2 Then
                dblCosto = dblTiempo * dblRemuneracion * 0.25
            Else
                dblDiferencia = dblTiempo - 2
                dblCosto = 2 * dblRemuneracion * 0.25
                dblCosto = dblCosto + dblDiferencia * dblRemuneracion * 0.35
            End If
        Else 'doble
            dblCosto = dblTiempo * dblRemuneracion * 1
        End If
        Return dblCosto
    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de eliminar el item?", "Horas Extras", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Eliminar()
            If Me.lblTipoDia.Text.Substring(0, 1) = "S" Then
                Me.CalcularHESubtotal()
            End If
            Total()
            Nuevo()
        End If
    End Sub

    Sub Eliminar()
        With Me.dgvHora
            dtHora.Rows(.CurrentCell.RowIndex).Delete()
            dtHora.AcceptChanges()

            For Each row As DataRow In dtHora.Rows
                row.Item("hora25") = ""
                row.Item("hora35") = ""
                row.Item("costo25") = 0
                row.Item("costo35") = 0
            Next
            dtHora.AcceptChanges()
        End With
    End Sub

    Private Sub cboEstadoFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstadoFiltro.SelectedIndexChanged
        Dim intOpcion As Integer = Me.cboEstadoFiltro.SelectedIndex
        Dim intEstado As Integer = IIf(intOpcion = 0, 1, 3)
        dtHora = dt.Copy
        Try
            dtHora = dtHora.Select("id_estado=" & intEstado & "").CopyToDataTable
            dtHora.AcceptChanges()
        Catch ex As Exception
            dtHora.Rows.Clear()
        End Try
        Me.dgvHora.DataSource = dtHora
        If Me.btnNuevo.Enabled Then
            Me.btnNuevo_Click(Nothing, Nothing)
        End If
        Total()

        If intOpcion = 0 Then
            Me.btnAgregar.Enabled = True
            Me.btnNuevo.Enabled = True
            Me.btnEliminar.Enabled = Me.dgvHora.Rows.Count > 0
            Me.btnAceptar.Enabled = Me.dgvHora.Rows.Count > 0

            Me.cboMotivo.Enabled = True
            Me.cboCompensacion.Enabled = True
            Me.dtpInicio.Enabled = True
            Me.dtpFin.Enabled = True
        Else
            Me.btnAgregar.Enabled = False
            Me.btnNuevo.Enabled = False
            Me.btnEliminar.Enabled = False
            Me.btnAceptar.Enabled = False

            Me.cboMotivo.Enabled = False
            Me.cboCompensacion.Enabled = False
            Me.dtpInicio.Enabled = False
            Me.dtpFin.Enabled = False
        End If
    End Sub

    Private Sub cboCompensacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCompensacion.SelectedIndexChanged
        dtpInicio_ValueChanged(Nothing, Nothing)
    End Sub

    Sub Accion()
        Me.lblAccion.Text = IIf(blnNuevo, "AGREGANDO", "MODIFICANDO")
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

    End Sub
End Class